using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class apruebas : GXProcedure
   {
      public apruebas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public apruebas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out String aP0_Texto )
      {
         this.AV8Texto = "" ;
         initialize();
         executePrivate();
         aP0_Texto=this.AV8Texto;
      }

      public String executeUdp( )
      {
         execute(out aP0_Texto);
         return AV8Texto ;
      }

      public void executeSubmit( out String aP0_Texto )
      {
         apruebas objapruebas;
         objapruebas = new apruebas();
         objapruebas.AV8Texto = "" ;
         objapruebas.context.SetSubmitInitialConfig(context);
         objapruebas.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objapruebas);
         aP0_Texto=this.AV8Texto;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((apruebas)stateInfo).executePrivate();
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
         AV8Texto = "HOLA MUNDO";
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
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private String AV8Texto ;
      private String aP0_Texto ;
   }

   [ServiceContract(Namespace = "GeneXus.Programs.pruebas_services")]
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class pruebas_services : GxRestService
   {
      [OperationContract]
      [WebInvoke(Method =  "POST" ,
      	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/")]
      public void execute( out String Texto )
      {
         Texto = "" ;
         try
         {
            if ( ! ProcessHeaders("pruebas") )
            {
               return  ;
            }
            apruebas worker = new apruebas(context) ;
            worker.IsMain = RunAsMain ;
            worker.execute(out Texto );
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
