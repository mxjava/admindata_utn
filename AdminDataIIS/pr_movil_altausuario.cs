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
   public class pr_movil_altausuario : GXProcedure
   {
      public pr_movil_altausuario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public pr_movil_altausuario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( String aP0_UsuariosCurp ,
                           String aP1_UsuariosNombre ,
                           String aP2_UsuariosApPat ,
                           String aP3_UsuariosApMat ,
                           String aP4_UsuariosTelef ,
                           String aP5_UsuariosCorreo ,
                           out String aP6_Error )
      {
         this.AV9UsuariosCurp = aP0_UsuariosCurp;
         this.AV10UsuariosNombre = aP1_UsuariosNombre;
         this.AV11UsuariosApPat = aP2_UsuariosApPat;
         this.AV12UsuariosApMat = aP3_UsuariosApMat;
         this.AV13UsuariosTelef = aP4_UsuariosTelef;
         this.AV8UsuariosCorreo = aP5_UsuariosCorreo;
         this.AV19Error = "" ;
         initialize();
         executePrivate();
         aP6_Error=this.AV19Error;
      }

      public String executeUdp( String aP0_UsuariosCurp ,
                                String aP1_UsuariosNombre ,
                                String aP2_UsuariosApPat ,
                                String aP3_UsuariosApMat ,
                                String aP4_UsuariosTelef ,
                                String aP5_UsuariosCorreo )
      {
         execute(aP0_UsuariosCurp, aP1_UsuariosNombre, aP2_UsuariosApPat, aP3_UsuariosApMat, aP4_UsuariosTelef, aP5_UsuariosCorreo, out aP6_Error);
         return AV19Error ;
      }

      public void executeSubmit( String aP0_UsuariosCurp ,
                                 String aP1_UsuariosNombre ,
                                 String aP2_UsuariosApPat ,
                                 String aP3_UsuariosApMat ,
                                 String aP4_UsuariosTelef ,
                                 String aP5_UsuariosCorreo ,
                                 out String aP6_Error )
      {
         pr_movil_altausuario objpr_movil_altausuario;
         objpr_movil_altausuario = new pr_movil_altausuario();
         objpr_movil_altausuario.AV9UsuariosCurp = aP0_UsuariosCurp;
         objpr_movil_altausuario.AV10UsuariosNombre = aP1_UsuariosNombre;
         objpr_movil_altausuario.AV11UsuariosApPat = aP2_UsuariosApPat;
         objpr_movil_altausuario.AV12UsuariosApMat = aP3_UsuariosApMat;
         objpr_movil_altausuario.AV13UsuariosTelef = aP4_UsuariosTelef;
         objpr_movil_altausuario.AV8UsuariosCorreo = aP5_UsuariosCorreo;
         objpr_movil_altausuario.AV19Error = "" ;
         objpr_movil_altausuario.context.SetSubmitInitialConfig(context);
         objpr_movil_altausuario.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpr_movil_altausuario);
         aP6_Error=this.AV19Error;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pr_movil_altausuario)stateInfo).executePrivate();
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
         AV16usuarios.gxTpr_Usuarioscurp = AV9UsuariosCurp;
         AV16usuarios.gxTpr_Usuariosnombre = AV10UsuariosNombre;
         AV16usuarios.gxTpr_Usuariosappat = AV11UsuariosApPat;
         AV16usuarios.gxTpr_Usuariosapmat = AV12UsuariosApMat;
         AV16usuarios.gxTpr_Usuariostelef = AV13UsuariosTelef;
         AV16usuarios.gxTpr_Usuarioscorreo = AV8UsuariosCorreo;
         AV16usuarios.gxTpr_Usuariospwd = "AdminData*2022";
         AV16usuarios.gxTpr_Usuariosstatus = 1;
         AV16usuarios.gxTpr_Usuariostipo = 6;
         AV16usuarios.gxTpr_Rolid = 6;
         AV16usuarios.Save();
         if ( AV16usuarios.Success() )
         {
            context.CommitDataStores("pr_movil_altausuario",pr_default);
            AV19Error = "Datos Guardados Exitosamente";
         }
         else
         {
            context.RollbackDataStores("pr_movil_altausuario",pr_default);
            AV19Error = "Favor de Verificar la información";
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
         AV16usuarios = new SdtUsuarios(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pr_movil_altausuario__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private String AV13UsuariosTelef ;
      private String AV9UsuariosCurp ;
      private String AV10UsuariosNombre ;
      private String AV11UsuariosApPat ;
      private String AV12UsuariosApMat ;
      private String AV8UsuariosCorreo ;
      private String AV19Error ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private String aP6_Error ;
      private SdtUsuarios AV16usuarios ;
   }

   public class pr_movil_altausuario__default : DataStoreHelperBase, IDataStoreHelper
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

 [ServiceContract(Namespace = "GeneXus.Programs.pr_movil_altausuario_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class pr_movil_altausuario_services : GxRestService
 {
    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( String UsuariosCurp ,
                         String UsuariosNombre ,
                         String UsuariosApPat ,
                         String UsuariosApMat ,
                         String UsuariosTelef ,
                         String UsuariosCorreo ,
                         out String Error )
    {
       Error = "" ;
       try
       {
          if ( ! ProcessHeaders("pr_movil_altausuario") )
          {
             return  ;
          }
          pr_movil_altausuario worker = new pr_movil_altausuario(context) ;
          worker.IsMain = RunAsMain ;
          worker.execute(UsuariosCurp,UsuariosNombre,UsuariosApPat,UsuariosApMat,UsuariosTelef,UsuariosCorreo,out Error );
          worker.cleanup( );
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
