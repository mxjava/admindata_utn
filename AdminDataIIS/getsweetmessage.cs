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
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class getsweetmessage : GXProcedure
   {
      public getsweetmessage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public getsweetmessage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( String aP0_sw_type ,
                           String aP1_title ,
                           String aP2_html ,
                           bool aP3_showCloseButton ,
                           bool aP4_showConfirmButton ,
                           out SdtPropiedades aP5_Propiedades )
      {
         this.AV12sw_type = aP0_sw_type;
         this.AV13title = aP1_title;
         this.AV8html = aP2_html;
         this.AV10showCloseButton = aP3_showCloseButton;
         this.AV11showConfirmButton = aP4_showConfirmButton;
         this.AV9Propiedades = new SdtPropiedades(context) ;
         initialize();
         executePrivate();
         aP5_Propiedades=this.AV9Propiedades;
      }

      public SdtPropiedades executeUdp( String aP0_sw_type ,
                                        String aP1_title ,
                                        String aP2_html ,
                                        bool aP3_showCloseButton ,
                                        bool aP4_showConfirmButton )
      {
         execute(aP0_sw_type, aP1_title, aP2_html, aP3_showCloseButton, aP4_showConfirmButton, out aP5_Propiedades);
         return AV9Propiedades ;
      }

      public void executeSubmit( String aP0_sw_type ,
                                 String aP1_title ,
                                 String aP2_html ,
                                 bool aP3_showCloseButton ,
                                 bool aP4_showConfirmButton ,
                                 out SdtPropiedades aP5_Propiedades )
      {
         getsweetmessage objgetsweetmessage;
         objgetsweetmessage = new getsweetmessage();
         objgetsweetmessage.AV12sw_type = aP0_sw_type;
         objgetsweetmessage.AV13title = aP1_title;
         objgetsweetmessage.AV8html = aP2_html;
         objgetsweetmessage.AV10showCloseButton = aP3_showCloseButton;
         objgetsweetmessage.AV11showConfirmButton = aP4_showConfirmButton;
         objgetsweetmessage.AV9Propiedades = new SdtPropiedades(context) ;
         objgetsweetmessage.context.SetSubmitInitialConfig(context);
         objgetsweetmessage.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgetsweetmessage);
         aP5_Propiedades=this.AV9Propiedades;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getsweetmessage)stateInfo).executePrivate();
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
         AV9Propiedades.gxTpr_Title = AV13title;
         AV9Propiedades.gxTpr_Showclosebutton = AV10showCloseButton;
         AV9Propiedades.gxTpr_Showconfirmbutton = AV11showConfirmButton;
         AV9Propiedades.gxTpr_Html = AV8html;
         AV9Propiedades.gxTpr_Icon = AV12sw_type;
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

      private String AV12sw_type ;
      private bool AV10showCloseButton ;
      private bool AV11showConfirmButton ;
      private String AV8html ;
      private String AV13title ;
      private SdtPropiedades aP5_Propiedades ;
      private SdtPropiedades AV9Propiedades ;
   }

}
