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
   public class directionsservicerequest : GXProcedure
   {
      public directionsservicerequest( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public directionsservicerequest( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( String aP0_DirectionsServiceProvider ,
                           GeneXus.Core.genexus.common.SdtDirectionsRequestParameters aP1_DirectionsRequestParameters ,
                           out GXBaseCollection<GeneXus.Core.genexus.common.SdtRoute> aP2_Routes ,
                           out GXBaseCollection<SdtMessages_Message> aP3_errorMessages )
      {
         this.AV9DirectionsServiceProvider = aP0_DirectionsServiceProvider;
         this.AV8DirectionsRequestParameters = aP1_DirectionsRequestParameters;
         this.AV12Routes = new GXBaseCollection<GeneXus.Core.genexus.common.SdtRoute>( context, "Route", "GeneXus") ;
         this.AV11errorMessages = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP2_Routes=this.AV12Routes;
         aP3_errorMessages=this.AV11errorMessages;
      }

      public GXBaseCollection<SdtMessages_Message> executeUdp( String aP0_DirectionsServiceProvider ,
                                                               GeneXus.Core.genexus.common.SdtDirectionsRequestParameters aP1_DirectionsRequestParameters ,
                                                               out GXBaseCollection<GeneXus.Core.genexus.common.SdtRoute> aP2_Routes )
      {
         execute(aP0_DirectionsServiceProvider, aP1_DirectionsRequestParameters, out aP2_Routes, out aP3_errorMessages);
         return AV11errorMessages ;
      }

      public void executeSubmit( String aP0_DirectionsServiceProvider ,
                                 GeneXus.Core.genexus.common.SdtDirectionsRequestParameters aP1_DirectionsRequestParameters ,
                                 out GXBaseCollection<GeneXus.Core.genexus.common.SdtRoute> aP2_Routes ,
                                 out GXBaseCollection<SdtMessages_Message> aP3_errorMessages )
      {
         directionsservicerequest objdirectionsservicerequest;
         objdirectionsservicerequest = new directionsservicerequest();
         objdirectionsservicerequest.AV9DirectionsServiceProvider = aP0_DirectionsServiceProvider;
         objdirectionsservicerequest.AV8DirectionsRequestParameters = aP1_DirectionsRequestParameters;
         objdirectionsservicerequest.AV12Routes = new GXBaseCollection<GeneXus.Core.genexus.common.SdtRoute>( context, "Route", "GeneXus") ;
         objdirectionsservicerequest.AV11errorMessages = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus") ;
         objdirectionsservicerequest.context.SetSubmitInitialConfig(context);
         objdirectionsservicerequest.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objdirectionsservicerequest);
         aP2_Routes=this.AV12Routes;
         aP3_errorMessages=this.AV11errorMessages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((directionsservicerequest)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV9DirectionsServiceProvider, "Google") == 0 )
         {
            new GeneXus.Core.genexus.common.googledirectionsservicerequest(context ).execute(  AV8DirectionsRequestParameters, out  AV12Routes, out  AV11errorMessages) ;
         }
         else
         {
            AV10errorMessage.gxTpr_Description = "Unknown Error";
            AV10errorMessage.gxTpr_Type = 1;
            AV11errorMessages.Add(AV10errorMessage, 0);
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
         AV10errorMessage = new SdtMessages_Message(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private String AV9DirectionsServiceProvider ;
      private GXBaseCollection<GeneXus.Core.genexus.common.SdtRoute> aP2_Routes ;
      private GXBaseCollection<SdtMessages_Message> aP3_errorMessages ;
      private GXBaseCollection<SdtMessages_Message> AV11errorMessages ;
      private GXBaseCollection<GeneXus.Core.genexus.common.SdtRoute> AV12Routes ;
      private GeneXus.Core.genexus.common.SdtDirectionsRequestParameters AV8DirectionsRequestParameters ;
      private SdtMessages_Message AV10errorMessage ;
   }

   [ServiceContract(Namespace = "GeneXus.Programs.directionsservicerequest_services")]
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class directionsservicerequest_services : GxRestService
   {
      [OperationContract]
      [WebInvoke(Method =  "POST" ,
      	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/")]
      public void execute( String DirectionsServiceProvider ,
                           GeneXus.Core.genexus.common.SdtDirectionsRequestParameters_RESTInterface DirectionsRequestParameters ,
                           out GxGenericCollection<GeneXus.Core.genexus.common.SdtRoute_RESTInterface> Routes ,
                           out GxGenericCollection<SdtMessages_Message_RESTInterface> errorMessages )
      {
         Routes = new GxGenericCollection<GeneXus.Core.genexus.common.SdtRoute_RESTInterface>() ;
         errorMessages = new GxGenericCollection<SdtMessages_Message_RESTInterface>() ;
         try
         {
            if ( ! ProcessHeaders("directionsservicerequest") )
            {
               return  ;
            }
            directionsservicerequest worker = new directionsservicerequest(context) ;
            worker.IsMain = RunAsMain ;
            GeneXus.Core.genexus.common.SdtDirectionsRequestParameters gxrDirectionsRequestParameters = DirectionsRequestParameters.sdt ;
            GXBaseCollection<GeneXus.Core.genexus.common.SdtRoute> gxrRoutes = new GXBaseCollection<GeneXus.Core.genexus.common.SdtRoute>() ;
            GXBaseCollection<SdtMessages_Message> gxrerrorMessages = new GXBaseCollection<SdtMessages_Message>() ;
            worker.execute(DirectionsServiceProvider,gxrDirectionsRequestParameters,out gxrRoutes,out gxrerrorMessages );
            worker.cleanup( );
            Routes = new GxGenericCollection<GeneXus.Core.genexus.common.SdtRoute_RESTInterface>(gxrRoutes) ;
            errorMessages = new GxGenericCollection<SdtMessages_Message_RESTInterface>(gxrerrorMessages) ;
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
