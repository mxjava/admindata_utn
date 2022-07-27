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
   public class grabaintentos : GXProcedure
   {
      public grabaintentos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public grabaintentos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_UsuariosId ,
                           short aP1_Cont )
      {
         this.AV9UsuariosId = aP0_UsuariosId;
         this.AV8Cont = aP1_Cont;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_UsuariosId ,
                                 short aP1_Cont )
      {
         grabaintentos objgrabaintentos;
         objgrabaintentos = new grabaintentos();
         objgrabaintentos.AV9UsuariosId = aP0_UsuariosId;
         objgrabaintentos.AV8Cont = aP1_Cont;
         objgrabaintentos.context.SetSubmitInitialConfig(context);
         objgrabaintentos.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgrabaintentos);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((grabaintentos)stateInfo).executePrivate();
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
         AV12GXLvl2 = 0;
         /* Using cursor P000Y2 */
         pr_default.execute(0, new Object[] {AV9UsuariosId, Gx_date});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A30FechaIntento = P000Y2_A30FechaIntento[0];
            A11UsuariosId = P000Y2_A11UsuariosId[0];
            A72Contador = P000Y2_A72Contador[0];
            A74IntentosHoraBloqueo = P000Y2_A74IntentosHoraBloqueo[0];
            n74IntentosHoraBloqueo = P000Y2_n74IntentosHoraBloqueo[0];
            AV12GXLvl2 = 1;
            A72Contador = AV8Cont;
            if ( AV8Cont == 3 )
            {
               A74IntentosHoraBloqueo = DateTimeUtil.ServerNow( context, pr_default);
               n74IntentosHoraBloqueo = false;
            }
            /* Using cursor P000Y3 */
            pr_default.execute(1, new Object[] {A72Contador, n74IntentosHoraBloqueo, A74IntentosHoraBloqueo, A11UsuariosId, A30FechaIntento});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("Intentos") ;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV12GXLvl2 == 0 )
         {
            /*
               INSERT RECORD ON TABLE Intentos

            */
            A11UsuariosId = AV9UsuariosId;
            A30FechaIntento = DateTimeUtil.ServerDate( context, pr_default);
            A72Contador = AV8Cont;
            /* Using cursor P000Y4 */
            pr_default.execute(2, new Object[] {A11UsuariosId, A30FechaIntento, A72Contador});
            pr_default.close(2);
            dsDefault.SmartCacheProvider.SetUpdated("Intentos") ;
            if ( (pr_default.getStatus(2) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (String)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("grabaintentos",pr_default);
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
         scmdbuf = "";
         Gx_date = DateTime.MinValue;
         P000Y2_A30FechaIntento = new DateTime[] {DateTime.MinValue} ;
         P000Y2_A11UsuariosId = new int[1] ;
         P000Y2_A72Contador = new short[1] ;
         P000Y2_A74IntentosHoraBloqueo = new DateTime[] {DateTime.MinValue} ;
         P000Y2_n74IntentosHoraBloqueo = new bool[] {false} ;
         A30FechaIntento = DateTime.MinValue;
         A74IntentosHoraBloqueo = (DateTime)(DateTime.MinValue);
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.grabaintentos__default(),
            new Object[][] {
                new Object[] {
               P000Y2_A30FechaIntento, P000Y2_A11UsuariosId, P000Y2_A72Contador, P000Y2_A74IntentosHoraBloqueo, P000Y2_n74IntentosHoraBloqueo
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short AV8Cont ;
      private short AV12GXLvl2 ;
      private short A72Contador ;
      private int AV9UsuariosId ;
      private int A11UsuariosId ;
      private int GX_INS20 ;
      private String scmdbuf ;
      private String Gx_emsg ;
      private DateTime A74IntentosHoraBloqueo ;
      private DateTime Gx_date ;
      private DateTime A30FechaIntento ;
      private bool n74IntentosHoraBloqueo ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P000Y2_A30FechaIntento ;
      private int[] P000Y2_A11UsuariosId ;
      private short[] P000Y2_A72Contador ;
      private DateTime[] P000Y2_A74IntentosHoraBloqueo ;
      private bool[] P000Y2_n74IntentosHoraBloqueo ;
   }

   public class grabaintentos__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000Y2 ;
          prmP000Y2 = new Object[] {
          new Object[] {"AV9UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"Gx_date",System.Data.DbType.Date,8,0}
          } ;
          Object[] prmP000Y3 ;
          prmP000Y3 = new Object[] {
          new Object[] {"Contador",System.Data.DbType.Byte,1,0} ,
          new Object[] {"IntentosHoraBloqueo",System.Data.DbType.DateTime,8,5} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"FechaIntento",System.Data.DbType.Date,8,0}
          } ;
          Object[] prmP000Y4 ;
          prmP000Y4 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"FechaIntento",System.Data.DbType.Date,8,0} ,
          new Object[] {"Contador",System.Data.DbType.Byte,1,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P000Y2", "SELECT `FechaIntento`, `UsuariosId`, `Contador`, `IntentosHoraBloqueo` FROM `Intentos` WHERE `UsuariosId` = ? and `FechaIntento` = ? ORDER BY `UsuariosId`, `FechaIntento`  FOR UPDATE ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000Y2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000Y3", "UPDATE `Intentos` SET `Contador`=?, `IntentosHoraBloqueo`=?  WHERE `UsuariosId` = ? AND `FechaIntento` = ?", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000Y3)
             ,new CursorDef("P000Y4", "INSERT INTO `Intentos`(`UsuariosId`, `FechaIntento`, `Contador`, `IntentosHoraBloqueo`) VALUES(?, ?, ?, '1000-01-01')", GxErrorMask.GX_NOMASK,prmP000Y4)
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
             case 0 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (DateTime)parms[1]);
                return;
             case 1 :
                stmt.SetParameter(1, (short)parms[0]);
                if ( (bool)parms[1] )
                {
                   stmt.setNull( 2 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameterDatetime(2, (DateTime)parms[2]);
                }
                stmt.SetParameter(3, (int)parms[3]);
                stmt.SetParameter(4, (DateTime)parms[4]);
                return;
             case 2 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (DateTime)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                return;
       }
    }

 }

}
