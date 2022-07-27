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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class pr_movil_ingreso : GXProcedure
   {
      public pr_movil_ingreso( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public pr_movil_ingreso( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( String aP0_Usuario ,
                           String aP1_Password ,
                           out String aP2_MsjTexto ,
                           out int aP3_RolId ,
                           out int aP4_UsuariosId )
      {
         this.AV56Usuario = aP0_Usuario;
         this.AV43Password = aP1_Password;
         this.AV59MsjTexto = "" ;
         this.AV9RolId = 0 ;
         this.AV62UsuariosId = 0 ;
         initialize();
         executePrivate();
         aP2_MsjTexto=this.AV59MsjTexto;
         aP3_RolId=this.AV9RolId;
         aP4_UsuariosId=this.AV62UsuariosId;
      }

      public int executeUdp( String aP0_Usuario ,
                             String aP1_Password ,
                             out String aP2_MsjTexto ,
                             out int aP3_RolId )
      {
         execute(aP0_Usuario, aP1_Password, out aP2_MsjTexto, out aP3_RolId, out aP4_UsuariosId);
         return AV62UsuariosId ;
      }

      public void executeSubmit( String aP0_Usuario ,
                                 String aP1_Password ,
                                 out String aP2_MsjTexto ,
                                 out int aP3_RolId ,
                                 out int aP4_UsuariosId )
      {
         pr_movil_ingreso objpr_movil_ingreso;
         objpr_movil_ingreso = new pr_movil_ingreso();
         objpr_movil_ingreso.AV56Usuario = aP0_Usuario;
         objpr_movil_ingreso.AV43Password = aP1_Password;
         objpr_movil_ingreso.AV59MsjTexto = "" ;
         objpr_movil_ingreso.AV9RolId = 0 ;
         objpr_movil_ingreso.AV62UsuariosId = 0 ;
         objpr_movil_ingreso.context.SetSubmitInitialConfig(context);
         objpr_movil_ingreso.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpr_movil_ingreso);
         aP2_MsjTexto=this.AV59MsjTexto;
         aP3_RolId=this.AV9RolId;
         aP4_UsuariosId=this.AV62UsuariosId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pr_movil_ingreso)stateInfo).executePrivate();
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
         AV67GXLvl1 = 0;
         /* Using cursor P00212 */
         pr_default.execute(0, new Object[] {AV56Usuario, Gx_date});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A244UsuariosUsr = P00212_A244UsuariosUsr[0];
            A286UsuariosStatus = P00212_A286UsuariosStatus[0];
            A70UsuariosVigFin = P00212_A70UsuariosVigFin[0];
            n70UsuariosVigFin = P00212_n70UsuariosVigFin[0];
            A11UsuariosId = P00212_A11UsuariosId[0];
            n11UsuariosId = P00212_n11UsuariosId[0];
            A24RolId = P00212_A24RolId[0];
            A67UsuariosKey = P00212_A67UsuariosKey[0];
            A68UsuariosPwd = P00212_A68UsuariosPwd[0];
            AV67GXLvl1 = 1;
            AV62UsuariosId = A11UsuariosId;
            AV9RolId = A24RolId;
            /* Execute user subroutine: 'VERIFICABITACCES' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'VERIFICAHISPSW' */
            S131 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            AV32FechaReal = DateTimeUtil.DAdd(AV10Tiempo,+((int)(120)));
            if ( (DateTime.MinValue==AV29FechaAcces) || ( AV32FechaReal <= Gx_date ) || ( AV11HistPwdInd == 1 ) )
            {
               if ( StringUtil.StrCmp(A68UsuariosPwd, Encrypt64( AV43Password, A67UsuariosKey)) == 0 )
               {
                  AV59MsjTexto = "EntraAplicacion";
               }
               else
               {
                  AV59MsjTexto = "NoEntra";
               }
            }
            else
            {
               AV59MsjTexto = "CambiaPassword";
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV67GXLvl1 == 0 )
         {
            AV59MsjTexto = "El usuario o contraseña son incorrectos, Favor de Verificar!!!";
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'INACTIVA' Routine */
         /* Using cursor P00213 */
         pr_default.execute(1, new Object[] {AV56Usuario});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A244UsuariosUsr = P00213_A244UsuariosUsr[0];
            A11UsuariosId = P00213_A11UsuariosId[0];
            n11UsuariosId = P00213_n11UsuariosId[0];
            A70UsuariosVigFin = P00213_A70UsuariosVigFin[0];
            n70UsuariosVigFin = P00213_n70UsuariosVigFin[0];
            AV8UsuarioId = A11UsuariosId;
            if ( A70UsuariosVigFin <= Gx_date )
            {
               new inacusr(context ).execute(  AV8UsuarioId) ;
            }
            else
            {
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S121( )
      {
         /* 'VERIFICABITACCES' Routine */
         /* Using cursor P00214 */
         pr_default.execute(2, new Object[] {AV8UsuarioId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A11UsuariosId = P00214_A11UsuariosId[0];
            n11UsuariosId = P00214_n11UsuariosId[0];
            A61bitAccesFec = P00214_A61bitAccesFec[0];
            A75bitAccesIp = P00214_A75bitAccesIp[0];
            AV29FechaAcces = A61bitAccesFec;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S131( )
      {
         /* 'VERIFICAHISPSW' Routine */
         /* Using cursor P00215 */
         pr_default.execute(3, new Object[] {AV8UsuarioId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A11UsuariosId = P00215_A11UsuariosId[0];
            n11UsuariosId = P00215_n11UsuariosId[0];
            A73HistPwdInd = P00215_A73HistPwdInd[0];
            A62HisPwdFecha = P00215_A62HisPwdFecha[0];
            AV31FechaCad = A62HisPwdFecha;
            AV11HistPwdInd = A73HistPwdInd;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(3);
         }
         pr_default.close(3);
         AV10Tiempo = DateTimeUtil.ResetTime(AV31FechaCad);
      }

      protected void S141( )
      {
         /* 'BUSCAINTENTOS' Routine */
         /* Using cursor P00216 */
         pr_default.execute(4, new Object[] {AV8UsuarioId});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A11UsuariosId = P00216_A11UsuariosId[0];
            n11UsuariosId = P00216_n11UsuariosId[0];
            AV24Cont = A72Contador;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
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
         scmdbuf = "";
         Gx_date = DateTime.MinValue;
         P00212_A244UsuariosUsr = new String[] {""} ;
         P00212_A286UsuariosStatus = new short[1] ;
         P00212_A70UsuariosVigFin = new DateTime[] {DateTime.MinValue} ;
         P00212_n70UsuariosVigFin = new bool[] {false} ;
         P00212_A11UsuariosId = new int[1] ;
         P00212_n11UsuariosId = new bool[] {false} ;
         P00212_A24RolId = new int[1] ;
         P00212_A67UsuariosKey = new String[] {""} ;
         P00212_A68UsuariosPwd = new String[] {""} ;
         A244UsuariosUsr = "";
         A70UsuariosVigFin = DateTime.MinValue;
         A67UsuariosKey = "";
         A68UsuariosPwd = "";
         AV32FechaReal = DateTime.MinValue;
         AV10Tiempo = DateTime.MinValue;
         AV29FechaAcces = (DateTime)(DateTime.MinValue);
         P00213_A244UsuariosUsr = new String[] {""} ;
         P00213_A11UsuariosId = new int[1] ;
         P00213_n11UsuariosId = new bool[] {false} ;
         P00213_A70UsuariosVigFin = new DateTime[] {DateTime.MinValue} ;
         P00213_n70UsuariosVigFin = new bool[] {false} ;
         P00214_A11UsuariosId = new int[1] ;
         P00214_n11UsuariosId = new bool[] {false} ;
         P00214_A61bitAccesFec = new DateTime[] {DateTime.MinValue} ;
         P00214_A75bitAccesIp = new String[] {""} ;
         A61bitAccesFec = (DateTime)(DateTime.MinValue);
         A75bitAccesIp = "";
         P00215_A11UsuariosId = new int[1] ;
         P00215_n11UsuariosId = new bool[] {false} ;
         P00215_A73HistPwdInd = new short[1] ;
         P00215_A62HisPwdFecha = new DateTime[] {DateTime.MinValue} ;
         A62HisPwdFecha = (DateTime)(DateTime.MinValue);
         AV31FechaCad = (DateTime)(DateTime.MinValue);
         P00216_A11UsuariosId = new int[1] ;
         P00216_n11UsuariosId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pr_movil_ingreso__default(),
            new Object[][] {
                new Object[] {
               P00212_A244UsuariosUsr, P00212_A286UsuariosStatus, P00212_A70UsuariosVigFin, P00212_n70UsuariosVigFin, P00212_A11UsuariosId, P00212_A24RolId, P00212_A67UsuariosKey, P00212_A68UsuariosPwd
               }
               , new Object[] {
               P00213_A244UsuariosUsr, P00213_A11UsuariosId, P00213_A70UsuariosVigFin, P00213_n70UsuariosVigFin
               }
               , new Object[] {
               P00214_A11UsuariosId, P00214_n11UsuariosId, P00214_A61bitAccesFec, P00214_A75bitAccesIp
               }
               , new Object[] {
               P00215_A11UsuariosId, P00215_A73HistPwdInd, P00215_A62HisPwdFecha
               }
               , new Object[] {
               P00216_A11UsuariosId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short AV67GXLvl1 ;
      private short A286UsuariosStatus ;
      private short AV11HistPwdInd ;
      private short A73HistPwdInd ;
      private short AV24Cont ;
      private short A72Contador ;
      private int AV62UsuariosId ;
      private int A11UsuariosId ;
      private int A24RolId ;
      private int AV9RolId ;
      private int AV8UsuarioId ;
      private String scmdbuf ;
      private DateTime AV29FechaAcces ;
      private DateTime A61bitAccesFec ;
      private DateTime A62HisPwdFecha ;
      private DateTime AV31FechaCad ;
      private DateTime Gx_date ;
      private DateTime A70UsuariosVigFin ;
      private DateTime AV32FechaReal ;
      private DateTime AV10Tiempo ;
      private bool n70UsuariosVigFin ;
      private bool n11UsuariosId ;
      private bool returnInSub ;
      private String AV56Usuario ;
      private String AV43Password ;
      private String A244UsuariosUsr ;
      private String A67UsuariosKey ;
      private String A68UsuariosPwd ;
      private String AV59MsjTexto ;
      private String A75bitAccesIp ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private String[] P00212_A244UsuariosUsr ;
      private short[] P00212_A286UsuariosStatus ;
      private DateTime[] P00212_A70UsuariosVigFin ;
      private bool[] P00212_n70UsuariosVigFin ;
      private int[] P00212_A11UsuariosId ;
      private bool[] P00212_n11UsuariosId ;
      private int[] P00212_A24RolId ;
      private String[] P00212_A67UsuariosKey ;
      private String[] P00212_A68UsuariosPwd ;
      private String[] P00213_A244UsuariosUsr ;
      private int[] P00213_A11UsuariosId ;
      private bool[] P00213_n11UsuariosId ;
      private DateTime[] P00213_A70UsuariosVigFin ;
      private bool[] P00213_n70UsuariosVigFin ;
      private int[] P00214_A11UsuariosId ;
      private bool[] P00214_n11UsuariosId ;
      private DateTime[] P00214_A61bitAccesFec ;
      private String[] P00214_A75bitAccesIp ;
      private int[] P00215_A11UsuariosId ;
      private bool[] P00215_n11UsuariosId ;
      private short[] P00215_A73HistPwdInd ;
      private DateTime[] P00215_A62HisPwdFecha ;
      private int[] P00216_A11UsuariosId ;
      private bool[] P00216_n11UsuariosId ;
      private String aP2_MsjTexto ;
      private int aP3_RolId ;
      private int aP4_UsuariosId ;
   }

   public class pr_movil_ingreso__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00212 ;
          prmP00212 = new Object[] {
          new Object[] {"AV56Usuario",System.Data.DbType.String,18,0} ,
          new Object[] {"Gx_date",System.Data.DbType.Date,8,0}
          } ;
          Object[] prmP00213 ;
          prmP00213 = new Object[] {
          new Object[] {"AV56Usuario",System.Data.DbType.String,18,0}
          } ;
          Object[] prmP00214 ;
          prmP00214 = new Object[] {
          new Object[] {"AV8UsuarioId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmP00215 ;
          prmP00215 = new Object[] {
          new Object[] {"AV8UsuarioId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmP00216 ;
          prmP00216 = new Object[] {
          new Object[] {"AV8UsuarioId",System.Data.DbType.Int32,9,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P00212", "SELECT `UsuariosUsr`, `UsuariosStatus`, `UsuariosVigFin`, `UsuariosId`, `RolId`, `UsuariosKey`, `UsuariosPwd` FROM `Usuarios` WHERE (`UsuariosUsr` = ?) AND (`UsuariosVigFin` > ?) AND (`UsuariosStatus` = 1) ORDER BY `UsuariosUsr` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00212,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00213", "SELECT `UsuariosUsr`, `UsuariosId`, `UsuariosVigFin` FROM `Usuarios` WHERE `UsuariosUsr` = ? ORDER BY `UsuariosUsr` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00213,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00214", "SELECT `UsuariosId`, `bitAccesFec`, `bitAccesIp` FROM `bitAcces` WHERE `UsuariosId` = ? ORDER BY `UsuariosId`, `bitAccesFec` DESC  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00214,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00215", "SELECT `UsuariosId`, `HistPwdInd`, `HisPwdFecha` FROM `HistPwd` WHERE `UsuariosId` = ? ORDER BY `UsuariosId`, `HisPwdFecha` DESC  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00215,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00216", "SELECT `UsuariosId` FROM `Usuarios` WHERE `UsuariosId` = ? ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00216,1, GxCacheFrequency.OFF ,false,true )
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
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4) ;
                ((int[]) buf[5])[0] = rslt.getInt(5) ;
                ((String[]) buf[6])[0] = rslt.getVarchar(6) ;
                ((String[]) buf[7])[0] = rslt.getVarchar(7) ;
                return;
             case 1 :
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2) ;
                ((String[]) buf[3])[0] = rslt.getVarchar(3) ;
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3) ;
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
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
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (DateTime)parms[1]);
                return;
             case 1 :
                stmt.SetParameter(1, (String)parms[0]);
                return;
             case 2 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 3 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 4 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.pr_movil_ingreso_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class pr_movil_ingreso_services : GxRestService
 {
    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( String Usuario ,
                         String Password ,
                         out String MsjTexto ,
                         out String RolId ,
                         out int UsuariosId )
    {
       MsjTexto = "" ;
       RolId = "" ;
       UsuariosId = 0 ;
       try
       {
          if ( ! ProcessHeaders("pr_movil_ingreso") )
          {
             return  ;
          }
          pr_movil_ingreso worker = new pr_movil_ingreso(context) ;
          worker.IsMain = RunAsMain ;
          int gxrRolId = 0 ;
          gxrRolId = (int)(NumberUtil.Val( (String)(RolId), "."));
          worker.execute(Usuario,Password,out MsjTexto,out gxrRolId,out UsuariosId );
          worker.cleanup( );
          RolId = StringUtil.LTrim( StringUtil.Str( (decimal)(gxrRolId), 9, 0)) ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
    }

 }

}
