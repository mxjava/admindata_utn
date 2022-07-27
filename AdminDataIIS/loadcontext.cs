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
   public class loadcontext : GXProcedure
   {
      public loadcontext( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public loadcontext( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out SdtContext aP0_Context )
      {
         this.AV8Context = new SdtContext(context) ;
         initialize();
         executePrivate();
         aP0_Context=this.AV8Context;
      }

      public SdtContext executeUdp( )
      {
         execute(out aP0_Context);
         return AV8Context ;
      }

      public void executeSubmit( out SdtContext aP0_Context )
      {
         loadcontext objloadcontext;
         objloadcontext = new loadcontext();
         objloadcontext.AV8Context = new SdtContext(context) ;
         objloadcontext.context.SetSubmitInitialConfig(context);
         objloadcontext.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objloadcontext);
         aP0_Context=this.AV8Context;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadcontext)stateInfo).executePrivate();
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
         AV8Context.FromXml(AV9Session.Get("context"), null, "Context", "ADMINDATA1");
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
         AV9Session = context.GetSession();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private IGxSession AV9Session ;
      private SdtContext aP0_Context ;
      private SdtContext AV8Context ;
   }

}
