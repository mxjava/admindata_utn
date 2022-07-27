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
   public class workwithdevicesusuarios_usuarios_detail : GXProcedure
   {
      public workwithdevicesusuarios_usuarios_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public workwithdevicesusuarios_usuarios_detail( IGxContext context )
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
                           out SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt aP2_GXM2WorkWithDevicesUsuarios_Usuarios_DetailSdt )
      {
         this.A11UsuariosId = aP0_UsuariosId;
         this.AV6gxid = aP1_gxid;
         this.AV11GXM2WorkWithDevicesUsuarios_Usuarios_DetailSdt = new SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt(context) ;
         initialize();
         executePrivate();
         aP2_GXM2WorkWithDevicesUsuarios_Usuarios_DetailSdt=this.AV11GXM2WorkWithDevicesUsuarios_Usuarios_DetailSdt;
      }

      public SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt executeUdp( int aP0_UsuariosId ,
                                                                       int aP1_gxid )
      {
         execute(aP0_UsuariosId, aP1_gxid, out aP2_GXM2WorkWithDevicesUsuarios_Usuarios_DetailSdt);
         return AV11GXM2WorkWithDevicesUsuarios_Usuarios_DetailSdt ;
      }

      public void executeSubmit( int aP0_UsuariosId ,
                                 int aP1_gxid ,
                                 out SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt aP2_GXM2WorkWithDevicesUsuarios_Usuarios_DetailSdt )
      {
         workwithdevicesusuarios_usuarios_detail objworkwithdevicesusuarios_usuarios_detail;
         objworkwithdevicesusuarios_usuarios_detail = new workwithdevicesusuarios_usuarios_detail();
         objworkwithdevicesusuarios_usuarios_detail.A11UsuariosId = aP0_UsuariosId;
         objworkwithdevicesusuarios_usuarios_detail.AV6gxid = aP1_gxid;
         objworkwithdevicesusuarios_usuarios_detail.AV11GXM2WorkWithDevicesUsuarios_Usuarios_DetailSdt = new SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt(context) ;
         objworkwithdevicesusuarios_usuarios_detail.context.SetSubmitInitialConfig(context);
         objworkwithdevicesusuarios_usuarios_detail.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objworkwithdevicesusuarios_usuarios_detail);
         aP2_GXM2WorkWithDevicesUsuarios_Usuarios_DetailSdt=this.AV11GXM2WorkWithDevicesUsuarios_Usuarios_DetailSdt;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((workwithdevicesusuarios_usuarios_detail)stateInfo).executePrivate();
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
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV6gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            /* Using cursor P00002 */
            pr_default.execute(0, new Object[] {A11UsuariosId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A105UsuariosCurp = P00002_A105UsuariosCurp[0];
               Gxdynprop1 = A105UsuariosCurp;
               Gxdynprop = Gxdynprop + ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Form\",\"Caption\",\"" + StringUtil.JSONEncode( Gxdynprop1) + "\"]";
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            Gxwebsession.Set(Gxids, "true");
         }
         AV11GXM2WorkWithDevicesUsuarios_Usuarios_DetailSdt.gxTpr_Gxdynprop = "[ "+Gxdynprop+" ]";
         Gxdynprop = "";
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
         Gxids = "";
         Gxwebsession = context.GetSession();
         scmdbuf = "";
         P00002_A11UsuariosId = new int[1] ;
         P00002_A105UsuariosCurp = new String[] {""} ;
         A105UsuariosCurp = "";
         Gxdynprop1 = "";
         Gxdynprop = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithdevicesusuarios_usuarios_detail__default(),
            new Object[][] {
                new Object[] {
               P00002_A11UsuariosId, P00002_A105UsuariosCurp
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A11UsuariosId ;
      private int AV6gxid ;
      private String Gxids ;
      private String scmdbuf ;
      private String A105UsuariosCurp ;
      private String Gxdynprop1 ;
      private String Gxdynprop ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00002_A11UsuariosId ;
      private String[] P00002_A105UsuariosCurp ;
      private SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt aP2_GXM2WorkWithDevicesUsuarios_Usuarios_DetailSdt ;
      private IGxSession Gxwebsession ;
      private SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt AV11GXM2WorkWithDevicesUsuarios_Usuarios_DetailSdt ;
   }

   public class workwithdevicesusuarios_usuarios_detail__default : DataStoreHelperBase, IDataStoreHelper
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
              new CursorDef("P00002", "SELECT `UsuariosId`, `UsuariosCurp` FROM `Usuarios` WHERE `UsuariosId` = ? ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00002,1, GxCacheFrequency.OFF ,false,true )
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

 [ServiceContract(Namespace = "GeneXus.Programs.workwithdevicesusuarios_usuarios_detail_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class workwithdevicesusuarios_usuarios_detail_services : GxRestService
 {
    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Bare  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/?UsuariosId={UsuariosId}&gxid={gxid}")]
    public SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt_RESTInterface execute( int UsuariosId ,
                                                                                String gxid )
    {
       SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt_RESTInterface GXM2WorkWithDevicesUsuarios_Usuarios_DetailSdt = new SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt_RESTInterface() ;
       try
       {
          if ( ! ProcessHeaders("workwithdevicesusuarios_usuarios_detail") )
          {
             return null ;
          }
          workwithdevicesusuarios_usuarios_detail worker = new workwithdevicesusuarios_usuarios_detail(context) ;
          worker.IsMain = RunAsMain ;
          int gxrgxid = 0 ;
          gxrgxid = (int)(NumberUtil.Val( (String)(gxid), "."));
          SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt gxrGXM2WorkWithDevicesUsuarios_Usuarios_DetailSdt = GXM2WorkWithDevicesUsuarios_Usuarios_DetailSdt.sdt ;
          worker.execute(UsuariosId,gxrgxid,out gxrGXM2WorkWithDevicesUsuarios_Usuarios_DetailSdt );
          worker.cleanup( );
          GXM2WorkWithDevicesUsuarios_Usuarios_DetailSdt = new SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt_RESTInterface(gxrGXM2WorkWithDevicesUsuarios_Usuarios_DetailSdt) ;
          return GXM2WorkWithDevicesUsuarios_Usuarios_DetailSdt ;
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
