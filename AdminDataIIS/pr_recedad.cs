using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class pr_recedad : GXProcedure
   {
      public pr_recedad( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public pr_recedad( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( String aP0_UsuariosCurp ,
                           out short aP1_anios )
      {
         this.AV10UsuariosCurp = aP0_UsuariosCurp;
         this.AV18anios = 0 ;
         initialize();
         executePrivate();
         aP1_anios=this.AV18anios;
      }

      public short executeUdp( String aP0_UsuariosCurp )
      {
         execute(aP0_UsuariosCurp, out aP1_anios);
         return AV18anios ;
      }

      public void executeSubmit( String aP0_UsuariosCurp ,
                                 out short aP1_anios )
      {
         pr_recedad objpr_recedad;
         objpr_recedad = new pr_recedad();
         objpr_recedad.AV10UsuariosCurp = aP0_UsuariosCurp;
         objpr_recedad.AV18anios = 0 ;
         objpr_recedad.context.SetSubmitInitialConfig(context);
         objpr_recedad.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpr_recedad);
         aP1_anios=this.AV18anios;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pr_recedad)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw e ;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Dia = StringUtil.Substring( AV10UsuariosCurp, 9, 2);
         AV9Mes = StringUtil.Substring( AV10UsuariosCurp, 7, 2);
         AV12Anio = StringUtil.Substring( AV10UsuariosCurp, 5, 2);
         AV11UsuariosFecNacimiento = context.localUtil.YMDToD( (int)(NumberUtil.Val( AV12Anio, ".")), (int)(NumberUtil.Val( AV9Mes, ".")), (int)(NumberUtil.Val( AV8Dia, ".")));
         AV19fechainicio = AV11UsuariosFecNacimiento;
         AV20fechames = DateTimeUtil.ServerDate( context, pr_default);
         AV22anioini = (short)(DateTimeUtil.Year( AV19fechainicio));
         AV30mesini = (short)(DateTimeUtil.Month( AV19fechainicio));
         AV24diaini = (short)(DateTimeUtil.Day( AV19fechainicio));
         AV21aniofin = (short)(DateTimeUtil.Year( AV20fechames));
         AV29mesfin = (short)(DateTimeUtil.Month( AV20fechames));
         AV23diafin = (short)(DateTimeUtil.Day( AV20fechames));
         if ( AV24diaini > AV23diafin )
         {
            AV27fechamayor = DateTimeUtil.DateEndOfMonth( AV19fechainicio);
            AV26dias = (short)(DateTimeUtil.Day( AV27fechamayor)-AV24diaini+AV23diafin);
            if ( AV30mesini < AV29mesfin )
            {
               AV28meses = (short)(AV29mesfin-AV30mesini-1);
               if ( AV28meses < 0 )
               {
                  AV28meses = 0;
               }
               AV18anios = (short)(AV21aniofin-AV22anioini);
            }
            else
            {
               AV28meses = (short)(AV30mesini-AV29mesfin);
               AV28meses = (short)(12-AV28meses-1);
               if ( AV28meses < 0 )
               {
                  AV28meses = 0;
               }
               AV18anios = (short)(AV21aniofin-AV22anioini-1);
               if ( AV18anios < 0 )
               {
                  AV18anios = 0;
               }
            }
            if ( AV28meses == 0 )
            {
               AV27fechamayor = DateTimeUtil.AddMth( AV19fechainicio, 1);
            }
            else
            {
               AV27fechamayor = DateTimeUtil.AddMth( AV19fechainicio, AV28meses);
               AV27fechamayor = DateTimeUtil.AddMth( AV27fechamayor, 1);
            }
            if ( AV18anios > 0 )
            {
               AV27fechamayor = DateTimeUtil.AddYr( AV27fechamayor, AV18anios);
            }
            AV27fechamayor = DateTimeUtil.DAdd(AV27fechamayor,-((int)(1)));
            if ( AV27fechamayor == AV20fechames )
            {
               AV28meses = (short)(AV28meses+1);
               AV26dias = 0;
               if ( AV28meses == 12 )
               {
                  AV18anios = (short)(AV18anios+1);
                  AV28meses = 0;
               }
               else
               {
                  if ( AV28meses > 12 )
                  {
                     AV18anios = (short)(AV18anios+1);
                     AV28meses = (short)(AV28meses-12);
                  }
               }
            }
            else
            {
               AV26dias = (short)(AV26dias+1);
               if ( AV26dias == DateTimeUtil.Day( DateTimeUtil.DateEndOfMonth( DateTimeUtil.ServerDate( context, pr_default))) )
               {
                  AV28meses = (short)(AV28meses+1);
                  AV26dias = 0;
                  if ( AV28meses == 12 )
                  {
                     AV18anios = (short)(AV18anios+1);
                     AV28meses = 0;
                  }
                  else
                  {
                     if ( AV28meses > 12 )
                     {
                        AV18anios = (short)(AV18anios+1);
                        AV28meses = (short)(AV28meses-12);
                     }
                  }
               }
            }
         }
         else
         {
            AV26dias = (short)(AV23diafin-AV24diaini);
            if ( AV30mesini > AV29mesfin )
            {
               AV28meses = (short)(12-AV30mesini+AV29mesfin);
               AV18anios = (short)(AV21aniofin-AV22anioini-1);
               if ( AV18anios < 0 )
               {
                  AV18anios = 0;
               }
            }
            else
            {
               AV28meses = (short)(AV29mesfin-AV30mesini);
               AV18anios = (short)(AV21aniofin-AV22anioini);
            }
            if ( AV28meses == 0 )
            {
               AV27fechamayor = DateTimeUtil.AddMth( AV19fechainicio, 1);
            }
            else
            {
               AV27fechamayor = DateTimeUtil.AddMth( AV19fechainicio, AV28meses);
               AV27fechamayor = DateTimeUtil.AddMth( AV27fechamayor, 1);
            }
            if ( AV18anios > 0 )
            {
               AV27fechamayor = DateTimeUtil.AddYr( AV27fechamayor, AV18anios);
            }
            AV27fechamayor = DateTimeUtil.DAdd(AV27fechamayor,-((int)(1)));
            if ( AV27fechamayor == AV20fechames )
            {
               AV28meses = (short)(AV28meses+1);
               AV26dias = 0;
               if ( AV28meses == 12 )
               {
                  AV18anios = (short)(AV18anios+1);
                  AV28meses = 0;
               }
            }
            else
            {
               AV26dias = (short)(AV26dias+1);
            }
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections() ;
         }
         exitApplication();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV8Dia = "";
         AV9Mes = "";
         AV12Anio = "";
         AV11UsuariosFecNacimiento = DateTime.MinValue;
         AV19fechainicio = DateTime.MinValue;
         AV20fechames = DateTime.MinValue;
         AV27fechamayor = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pr_recedad__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV18anios ;
      private short AV22anioini ;
      private short AV30mesini ;
      private short AV24diaini ;
      private short AV21aniofin ;
      private short AV29mesfin ;
      private short AV23diafin ;
      private short AV26dias ;
      private short AV28meses ;
      private String AV8Dia ;
      private String AV9Mes ;
      private String AV12Anio ;
      private DateTime AV11UsuariosFecNacimiento ;
      private DateTime AV19fechainicio ;
      private DateTime AV20fechames ;
      private DateTime AV27fechamayor ;
      private String AV10UsuariosCurp ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short aP1_anios ;
   }

   public class pr_recedad__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
       }
    }

 }

}
