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
   public class cierramens : GXProcedure
   {
      public cierramens( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public cierramens( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         cierramens objcierramens;
         objcierramens = new cierramens();
         objcierramens.context.SetSubmitInitialConfig(context);
         objcierramens.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcierramens);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((cierramens)stateInfo).executePrivate();
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
         AV9Fecha = DateTimeUtil.ServerDate( context, pr_default);
         /* Using cursor P000Z2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A77menInicioStat = P000Z2_A77menInicioStat[0];
            A76menInicioFecFin = P000Z2_A76menInicioFecFin[0];
            A58menInicioId = P000Z2_A58menInicioId[0];
            if ( ( AV9Fecha > A76menInicioFecFin ) && ( A77menInicioStat == 1 ) )
            {
               A77menInicioStat = 0;
            }
            /* Using cursor P000Z3 */
            pr_default.execute(1, new Object[] {A77menInicioStat, A58menInicioId});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("menInicio") ;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("cierramens",pr_default);
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
         AV9Fecha = DateTime.MinValue;
         scmdbuf = "";
         P000Z2_A77menInicioStat = new short[1] ;
         P000Z2_A76menInicioFecFin = new DateTime[] {DateTime.MinValue} ;
         P000Z2_A58menInicioId = new int[1] ;
         A76menInicioFecFin = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cierramens__default(),
            new Object[][] {
                new Object[] {
               P000Z2_A77menInicioStat, P000Z2_A76menInicioFecFin, P000Z2_A58menInicioId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A77menInicioStat ;
      private int A58menInicioId ;
      private String scmdbuf ;
      private DateTime AV9Fecha ;
      private DateTime A76menInicioFecFin ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000Z2_A77menInicioStat ;
      private DateTime[] P000Z2_A76menInicioFecFin ;
      private int[] P000Z2_A58menInicioId ;
   }

   public class cierramens__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000Z2 ;
          prmP000Z2 = new Object[] {
          } ;
          Object[] prmP000Z3 ;
          prmP000Z3 = new Object[] {
          new Object[] {"menInicioStat",System.Data.DbType.Byte,1,0} ,
          new Object[] {"menInicioId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P000Z2", "SELECT `menInicioStat`, `menInicioFecFin`, `menInicioId` FROM `menInicio` ORDER BY `menInicioId`  FOR UPDATE ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000Z2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000Z3", "UPDATE `menInicio` SET `menInicioStat`=?  WHERE `menInicioId` = ?", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000Z3)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
             case 1 :
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
       }
    }

 }

}
