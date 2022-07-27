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
   public class creallavepwd : GXProcedure
   {
      public creallavepwd( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public creallavepwd( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_UsuariosId ,
                           String aP1_pwd ,
                           String aP2_UsuariosNomMay ,
                           int aP3_UsrLogged ,
                           int aP4_adscId ,
                           int aP5_comision )
      {
         this.AV9UsuariosId = aP0_UsuariosId;
         this.AV10pwd = aP1_pwd;
         this.AV11UsuariosNomMay = aP2_UsuariosNomMay;
         this.AV12UsrLogged = aP3_UsrLogged;
         this.AV13adscId = aP4_adscId;
         this.AV14comision = aP5_comision;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_UsuariosId ,
                                 String aP1_pwd ,
                                 String aP2_UsuariosNomMay ,
                                 int aP3_UsrLogged ,
                                 int aP4_adscId ,
                                 int aP5_comision )
      {
         creallavepwd objcreallavepwd;
         objcreallavepwd = new creallavepwd();
         objcreallavepwd.AV9UsuariosId = aP0_UsuariosId;
         objcreallavepwd.AV10pwd = aP1_pwd;
         objcreallavepwd.AV11UsuariosNomMay = aP2_UsuariosNomMay;
         objcreallavepwd.AV12UsrLogged = aP3_UsrLogged;
         objcreallavepwd.AV13adscId = aP4_adscId;
         objcreallavepwd.AV14comision = aP5_comision;
         objcreallavepwd.context.SetSubmitInitialConfig(context);
         objcreallavepwd.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcreallavepwd);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((creallavepwd)stateInfo).executePrivate();
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
         AV8Key = Crypto.GetEncryptionKey( );
         /* Execute user subroutine: 'VERIFICA' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Using cursor P000K2 */
         pr_default.execute(0, new Object[] {AV9UsuariosId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11UsuariosId = P000K2_A11UsuariosId[0];
            A244UsuariosUsr = P000K2_A244UsuariosUsr[0];
            A68UsuariosPwd = P000K2_A68UsuariosPwd[0];
            A67UsuariosKey = P000K2_A67UsuariosKey[0];
            A93UsuariosIP = P000K2_A93UsuariosIP[0];
            A92UsuariosFecCap = P000K2_A92UsuariosFecCap[0];
            A96UsuariosVigIni = P000K2_A96UsuariosVigIni[0];
            A70UsuariosVigFin = P000K2_A70UsuariosVigFin[0];
            n70UsuariosVigFin = P000K2_n70UsuariosVigFin[0];
            A244UsuariosUsr = AV11UsuariosNomMay;
            A68UsuariosPwd = Encrypt64( StringUtil.Trim( AV10pwd), AV8Key);
            A67UsuariosKey = AV8Key;
            A93UsuariosIP = context.GetRemoteAddress( );
            A92UsuariosFecCap = DateTimeUtil.ServerNow( context, pr_default);
            A70UsuariosVigFin = DateTimeUtil.AddYr( A96UsuariosVigIni, 1);
            n70UsuariosVigFin = false;
            AV16UsuariosPwd = A68UsuariosPwd;
            /* Using cursor P000K3 */
            pr_default.execute(1, new Object[] {A244UsuariosUsr, A68UsuariosPwd, A67UsuariosKey, A93UsuariosIP, A92UsuariosFecCap, n70UsuariosVigFin, A70UsuariosVigFin, A11UsuariosId});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("Usuarios") ;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         new guardahispwd(context ).execute(  AV9UsuariosId,  AV16UsuariosPwd,  AV8Key,  1) ;
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'VERIFICA' Routine */
         if ( (0==AV12UsrLogged) )
         {
            AV15bandera = 1;
         }
         else
         {
            AV15bandera = 2;
         }
      }

      public override void cleanup( )
      {
         context.CommitDataStores("creallavepwd",pr_default);
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
         AV8Key = "";
         scmdbuf = "";
         P000K2_A11UsuariosId = new int[1] ;
         P000K2_A244UsuariosUsr = new String[] {""} ;
         P000K2_A68UsuariosPwd = new String[] {""} ;
         P000K2_A67UsuariosKey = new String[] {""} ;
         P000K2_A93UsuariosIP = new String[] {""} ;
         P000K2_A92UsuariosFecCap = new DateTime[] {DateTime.MinValue} ;
         P000K2_A96UsuariosVigIni = new DateTime[] {DateTime.MinValue} ;
         P000K2_A70UsuariosVigFin = new DateTime[] {DateTime.MinValue} ;
         P000K2_n70UsuariosVigFin = new bool[] {false} ;
         A244UsuariosUsr = "";
         A68UsuariosPwd = "";
         A67UsuariosKey = "";
         A93UsuariosIP = "";
         A92UsuariosFecCap = (DateTime)(DateTime.MinValue);
         A96UsuariosVigIni = DateTime.MinValue;
         A70UsuariosVigFin = DateTime.MinValue;
         AV16UsuariosPwd = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.creallavepwd__default(),
            new Object[][] {
                new Object[] {
               P000K2_A11UsuariosId, P000K2_A244UsuariosUsr, P000K2_A68UsuariosPwd, P000K2_A67UsuariosKey, P000K2_A93UsuariosIP, P000K2_A92UsuariosFecCap, P000K2_A96UsuariosVigIni, P000K2_A70UsuariosVigFin, P000K2_n70UsuariosVigFin
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV15bandera ;
      private int AV9UsuariosId ;
      private int AV12UsrLogged ;
      private int AV13adscId ;
      private int AV14comision ;
      private int A11UsuariosId ;
      private String AV10pwd ;
      private String AV8Key ;
      private String scmdbuf ;
      private DateTime A92UsuariosFecCap ;
      private DateTime A96UsuariosVigIni ;
      private DateTime A70UsuariosVigFin ;
      private bool returnInSub ;
      private bool n70UsuariosVigFin ;
      private String AV11UsuariosNomMay ;
      private String A244UsuariosUsr ;
      private String A68UsuariosPwd ;
      private String A67UsuariosKey ;
      private String A93UsuariosIP ;
      private String AV16UsuariosPwd ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P000K2_A11UsuariosId ;
      private String[] P000K2_A244UsuariosUsr ;
      private String[] P000K2_A68UsuariosPwd ;
      private String[] P000K2_A67UsuariosKey ;
      private String[] P000K2_A93UsuariosIP ;
      private DateTime[] P000K2_A92UsuariosFecCap ;
      private DateTime[] P000K2_A96UsuariosVigIni ;
      private DateTime[] P000K2_A70UsuariosVigFin ;
      private bool[] P000K2_n70UsuariosVigFin ;
   }

   public class creallavepwd__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000K2 ;
          prmP000K2 = new Object[] {
          new Object[] {"AV9UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmP000K3 ;
          prmP000K3 = new Object[] {
          new Object[] {"UsuariosUsr",System.Data.DbType.String,20,0} ,
          new Object[] {"UsuariosPwd",System.Data.DbType.String,32,0} ,
          new Object[] {"UsuariosKey",System.Data.DbType.String,32,0} ,
          new Object[] {"UsuariosIP",System.Data.DbType.String,15,0} ,
          new Object[] {"UsuariosFecCap",System.Data.DbType.DateTime,10,8} ,
          new Object[] {"UsuariosVigFin",System.Data.DbType.Date,8,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P000K2", "SELECT `UsuariosId`, `UsuariosUsr`, `UsuariosPwd`, `UsuariosKey`, `UsuariosIP`, `UsuariosFecCap`, `UsuariosVigIni`, `UsuariosVigFin` FROM `Usuarios` WHERE `UsuariosId` = ? ORDER BY `UsuariosId`  FOR UPDATE ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000K2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000K3", "UPDATE `Usuarios` SET `UsuariosUsr`=?, `UsuariosPwd`=?, `UsuariosKey`=?, `UsuariosIP`=?, `UsuariosFecCap`=?, `UsuariosVigFin`=?  WHERE `UsuariosId` = ?", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000K3)
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
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((String[]) buf[3])[0] = rslt.getVarchar(4) ;
                ((String[]) buf[4])[0] = rslt.getVarchar(5) ;
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6) ;
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7) ;
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
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
                return;
             case 1 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (String)parms[2]);
                stmt.SetParameter(4, (String)parms[3]);
                stmt.SetParameterDatetime(5, (DateTime)parms[4]);
                if ( (bool)parms[5] )
                {
                   stmt.setNull( 6 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(6, (DateTime)parms[6]);
                }
                stmt.SetParameter(7, (int)parms[7]);
                return;
       }
    }

 }

}
