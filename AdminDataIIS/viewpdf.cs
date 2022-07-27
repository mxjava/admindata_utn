using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using System.Web.Services;
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
   public class viewpdf : GXProcedure
   {
      public viewpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public viewpdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( String aP0_PDFName ,
                           String aP1_FullPathFile )
      {
         this.AV2PDFName = aP0_PDFName;
         this.AV3FullPathFile = aP1_FullPathFile;
         initialize();
         executePrivate();
      }

      public void executeSubmit( String aP0_PDFName ,
                                 String aP1_FullPathFile )
      {
         viewpdf objviewpdf;
         objviewpdf = new viewpdf();
         objviewpdf.AV2PDFName = aP0_PDFName;
         objviewpdf.AV3FullPathFile = aP1_FullPathFile;
         objviewpdf.context.SetSubmitInitialConfig(context);
         objviewpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objviewpdf);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((viewpdf)stateInfo).executePrivate();
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
         args = new Object[] {(String)AV2PDFName,(String)AV3FullPathFile} ;
         ClassLoader.Execute("aviewpdf","GeneXus.Programs","aviewpdf", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
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
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private String AV2PDFName ;
      private String AV3FullPathFile ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
