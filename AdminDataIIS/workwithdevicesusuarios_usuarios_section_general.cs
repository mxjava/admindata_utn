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
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class workwithdevicesusuarios_usuarios_section_general : GXProcedure
   {
      public workwithdevicesusuarios_usuarios_section_general( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public workwithdevicesusuarios_usuarios_section_general( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_UsuariosId ,
                           int aP1_gxid ,
                           out SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt aP2_GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt )
      {
         this.A11UsuariosId = aP0_UsuariosId;
         this.AV6gxid = aP1_gxid;
         this.AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt = new SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt(context) ;
         initialize();
         executePrivate();
         aP2_GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt=this.AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt;
      }

      public SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt executeUdp( int aP0_UsuariosId ,
                                                                                int aP1_gxid )
      {
         execute(aP0_UsuariosId, aP1_gxid, out aP2_GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt);
         return AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt ;
      }

      public void executeSubmit( int aP0_UsuariosId ,
                                 int aP1_gxid ,
                                 out SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt aP2_GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt )
      {
         workwithdevicesusuarios_usuarios_section_general objworkwithdevicesusuarios_usuarios_section_general;
         objworkwithdevicesusuarios_usuarios_section_general = new workwithdevicesusuarios_usuarios_section_general();
         objworkwithdevicesusuarios_usuarios_section_general.A11UsuariosId = aP0_UsuariosId;
         objworkwithdevicesusuarios_usuarios_section_general.AV6gxid = aP1_gxid;
         objworkwithdevicesusuarios_usuarios_section_general.AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt = new SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt(context) ;
         objworkwithdevicesusuarios_usuarios_section_general.context.SetSubmitInitialConfig(context);
         objworkwithdevicesusuarios_usuarios_section_general.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objworkwithdevicesusuarios_usuarios_section_general);
         aP2_GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt=this.AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((workwithdevicesusuarios_usuarios_section_general)stateInfo).executePrivate();
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
         /* Using cursor P00002 */
         pr_default.execute(0, new Object[] {A11UsuariosId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A40000UsuariosIcono_GXI = P00002_A40000UsuariosIcono_GXI[0];
            A105UsuariosCurp = P00002_A105UsuariosCurp[0];
            A66UsuariosNombre = P00002_A66UsuariosNombre[0];
            A65UsuariosApPat = P00002_A65UsuariosApPat[0];
            A64UsuariosApMat = P00002_A64UsuariosApMat[0];
            A272UsuariosTipo = P00002_A272UsuariosTipo[0];
            A260UsuariosTelef = P00002_A260UsuariosTelef[0];
            A261UsuariosCorreo = P00002_A261UsuariosCorreo[0];
            A286UsuariosStatus = P00002_A286UsuariosStatus[0];
            A255UsuariosFecNacimiento = P00002_A255UsuariosFecNacimiento[0];
            A256UsuariosEdad = P00002_A256UsuariosEdad[0];
            A68UsuariosPwd = P00002_A68UsuariosPwd[0];
            A92UsuariosFecCap = P00002_A92UsuariosFecCap[0];
            A96UsuariosVigIni = P00002_A96UsuariosVigIni[0];
            A70UsuariosVigFin = P00002_A70UsuariosVigFin[0];
            n70UsuariosVigFin = P00002_n70UsuariosVigFin[0];
            A93UsuariosIP = P00002_A93UsuariosIP[0];
            A257UsuariosSexo = P00002_A257UsuariosSexo[0];
            A245UsuariosIcono = P00002_A245UsuariosIcono[0];
            if ( StringUtil.StrCmp(A257UsuariosSexo, "H") == 0 )
            {
               A275UsuariosSexoFor = "Hombres";
            }
            else
            {
               if ( StringUtil.StrCmp(A257UsuariosSexo, "M") == 0 )
               {
                  A275UsuariosSexoFor = "Mujeres";
               }
               else
               {
                  A275UsuariosSexoFor = "";
               }
            }
            AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt.gxTpr_Usuariosid = A11UsuariosId;
            AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt.gxTpr_Usuariosicono = A245UsuariosIcono;
            AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt.gxTpr_Usuariosicono_gxi = A40000UsuariosIcono_GXI;
            AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt.gxTpr_Usuarioscurp = A105UsuariosCurp;
            AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt.gxTpr_Usuariosnombre = A66UsuariosNombre;
            AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt.gxTpr_Usuariosappat = A65UsuariosApPat;
            AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt.gxTpr_Usuariosapmat = A64UsuariosApMat;
            AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt.gxTpr_Usuariostipo = A272UsuariosTipo;
            AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt.gxTpr_Usuariostelef = A260UsuariosTelef;
            AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt.gxTpr_Usuarioscorreo = A261UsuariosCorreo;
            AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt.gxTpr_Usuariosstatus = A286UsuariosStatus;
            AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt.gxTpr_Usuariosfecnacimiento = A255UsuariosFecNacimiento;
            AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt.gxTpr_Usuariosedad = A256UsuariosEdad;
            AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt.gxTpr_Usuariossexofor = A275UsuariosSexoFor;
            AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt.gxTpr_Usuariospwd = A68UsuariosPwd;
            AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt.gxTpr_Usuariosfeccap = A92UsuariosFecCap;
            AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt.gxTpr_Usuariosvigini = A96UsuariosVigIni;
            AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt.gxTpr_Usuariosvigfin = A70UsuariosVigFin;
            AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt.gxTpr_Usuariosip = A93UsuariosIP;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
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
         scmdbuf = "";
         P00002_A11UsuariosId = new int[1] ;
         P00002_A40000UsuariosIcono_GXI = new String[] {""} ;
         P00002_A105UsuariosCurp = new String[] {""} ;
         P00002_A66UsuariosNombre = new String[] {""} ;
         P00002_A65UsuariosApPat = new String[] {""} ;
         P00002_A64UsuariosApMat = new String[] {""} ;
         P00002_A272UsuariosTipo = new short[1] ;
         P00002_A260UsuariosTelef = new String[] {""} ;
         P00002_A261UsuariosCorreo = new String[] {""} ;
         P00002_A286UsuariosStatus = new short[1] ;
         P00002_A255UsuariosFecNacimiento = new DateTime[] {DateTime.MinValue} ;
         P00002_A256UsuariosEdad = new short[1] ;
         P00002_A68UsuariosPwd = new String[] {""} ;
         P00002_A92UsuariosFecCap = new DateTime[] {DateTime.MinValue} ;
         P00002_A96UsuariosVigIni = new DateTime[] {DateTime.MinValue} ;
         P00002_A70UsuariosVigFin = new DateTime[] {DateTime.MinValue} ;
         P00002_n70UsuariosVigFin = new bool[] {false} ;
         P00002_A93UsuariosIP = new String[] {""} ;
         P00002_A257UsuariosSexo = new String[] {""} ;
         P00002_A245UsuariosIcono = new String[] {""} ;
         A40000UsuariosIcono_GXI = "";
         A105UsuariosCurp = "";
         A66UsuariosNombre = "";
         A65UsuariosApPat = "";
         A64UsuariosApMat = "";
         A260UsuariosTelef = "";
         A261UsuariosCorreo = "";
         A255UsuariosFecNacimiento = DateTime.MinValue;
         A68UsuariosPwd = "";
         A92UsuariosFecCap = (DateTime)(DateTime.MinValue);
         A96UsuariosVigIni = DateTime.MinValue;
         A70UsuariosVigFin = DateTime.MinValue;
         A93UsuariosIP = "";
         A257UsuariosSexo = "";
         A245UsuariosIcono = "";
         A275UsuariosSexoFor = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithdevicesusuarios_usuarios_section_general__default(),
            new Object[][] {
                new Object[] {
               P00002_A11UsuariosId, P00002_A40000UsuariosIcono_GXI, P00002_A105UsuariosCurp, P00002_A66UsuariosNombre, P00002_A65UsuariosApPat, P00002_A64UsuariosApMat, P00002_A272UsuariosTipo, P00002_A260UsuariosTelef, P00002_A261UsuariosCorreo, P00002_A286UsuariosStatus,
               P00002_A255UsuariosFecNacimiento, P00002_A256UsuariosEdad, P00002_A68UsuariosPwd, P00002_A92UsuariosFecCap, P00002_A96UsuariosVigIni, P00002_A70UsuariosVigFin, P00002_n70UsuariosVigFin, P00002_A93UsuariosIP, P00002_A257UsuariosSexo, P00002_A245UsuariosIcono
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A272UsuariosTipo ;
      private short A286UsuariosStatus ;
      private short A256UsuariosEdad ;
      private int A11UsuariosId ;
      private int AV6gxid ;
      private String scmdbuf ;
      private String A260UsuariosTelef ;
      private String A257UsuariosSexo ;
      private String A275UsuariosSexoFor ;
      private DateTime A92UsuariosFecCap ;
      private DateTime A255UsuariosFecNacimiento ;
      private DateTime A96UsuariosVigIni ;
      private DateTime A70UsuariosVigFin ;
      private bool n70UsuariosVigFin ;
      private String A40000UsuariosIcono_GXI ;
      private String A105UsuariosCurp ;
      private String A66UsuariosNombre ;
      private String A65UsuariosApPat ;
      private String A64UsuariosApMat ;
      private String A261UsuariosCorreo ;
      private String A68UsuariosPwd ;
      private String A93UsuariosIP ;
      private String A245UsuariosIcono ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00002_A11UsuariosId ;
      private String[] P00002_A40000UsuariosIcono_GXI ;
      private String[] P00002_A105UsuariosCurp ;
      private String[] P00002_A66UsuariosNombre ;
      private String[] P00002_A65UsuariosApPat ;
      private String[] P00002_A64UsuariosApMat ;
      private short[] P00002_A272UsuariosTipo ;
      private String[] P00002_A260UsuariosTelef ;
      private String[] P00002_A261UsuariosCorreo ;
      private short[] P00002_A286UsuariosStatus ;
      private DateTime[] P00002_A255UsuariosFecNacimiento ;
      private short[] P00002_A256UsuariosEdad ;
      private String[] P00002_A68UsuariosPwd ;
      private DateTime[] P00002_A92UsuariosFecCap ;
      private DateTime[] P00002_A96UsuariosVigIni ;
      private DateTime[] P00002_A70UsuariosVigFin ;
      private bool[] P00002_n70UsuariosVigFin ;
      private String[] P00002_A93UsuariosIP ;
      private String[] P00002_A257UsuariosSexo ;
      private String[] P00002_A245UsuariosIcono ;
      private SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt aP2_GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt ;
      private SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt AV7GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt ;
   }

   public class workwithdevicesusuarios_usuarios_section_general__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00002 ;
          prmP00002 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P00002", "SELECT `UsuariosId`, `UsuariosIcono_GXI`, `UsuariosCurp`, `UsuariosNombre`, `UsuariosApPat`, `UsuariosApMat`, `UsuariosTipo`, `UsuariosTelef`, `UsuariosCorreo`, `UsuariosStatus`, `UsuariosFecNacimiento`, `UsuariosEdad`, `UsuariosPwd`, `UsuariosFecCap`, `UsuariosVigIni`, `UsuariosVigFin`, `UsuariosIP`, `UsuariosSexo`, `UsuariosIcono` FROM `Usuarios` WHERE `UsuariosId` = ? ORDER BY `UsuariosId`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00002,1, GxCacheFrequency.OFF ,false,true )
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
                ((String[]) buf[1])[0] = rslt.getMultimediaUri(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((String[]) buf[3])[0] = rslt.getVarchar(4) ;
                ((String[]) buf[4])[0] = rslt.getVarchar(5) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
                ((short[]) buf[6])[0] = rslt.getShort(7) ;
                ((String[]) buf[7])[0] = rslt.getString(8, 10) ;
                ((String[]) buf[8])[0] = rslt.getVarchar(9) ;
                ((short[]) buf[9])[0] = rslt.getShort(10) ;
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(11) ;
                ((short[]) buf[11])[0] = rslt.getShort(12) ;
                ((String[]) buf[12])[0] = rslt.getVarchar(13) ;
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(14) ;
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(15) ;
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(16) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(16);
                ((String[]) buf[17])[0] = rslt.getVarchar(17) ;
                ((String[]) buf[18])[0] = rslt.getString(18, 1) ;
                ((String[]) buf[19])[0] = rslt.getMultimediaFile(19, rslt.getVarchar(2)) ;
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
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.workwithdevicesusuarios_usuarios_section_general_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class workwithdevicesusuarios_usuarios_section_general_services : GxRestService
 {
    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Bare  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/?UsuariosId={UsuariosId}&gxid={gxid}")]
    public SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_RESTInterface execute( int UsuariosId ,
                                                                                         String gxid )
    {
       SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_RESTInterface GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt = new SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_RESTInterface() ;
       try
       {
          if ( ! ProcessHeaders("workwithdevicesusuarios_usuarios_section_general") )
          {
             return null ;
          }
          workwithdevicesusuarios_usuarios_section_general worker = new workwithdevicesusuarios_usuarios_section_general(context) ;
          worker.IsMain = RunAsMain ;
          int gxrgxid = 0 ;
          gxrgxid = (int)(NumberUtil.Val( (String)(gxid), "."));
          SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt gxrGXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt = GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt.sdt ;
          worker.execute(UsuariosId,gxrgxid,out gxrGXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt );
          worker.cleanup( );
          GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt = new SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_RESTInterface(gxrGXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt) ;
          return GXM1WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

 }

}
