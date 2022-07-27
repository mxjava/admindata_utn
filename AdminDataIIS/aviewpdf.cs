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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aviewpdf : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("Carmine");
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            if ( ! entryPointCalled )
            {
               AV10PDFName = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV11FullPathFile = GetNextPar( );
               }
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public aviewpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public aviewpdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( String aP0_PDFName ,
                           String aP1_FullPathFile )
      {
         this.AV10PDFName = aP0_PDFName;
         this.AV11FullPathFile = aP1_FullPathFile;
         initialize();
         executePrivate();
      }

      public void executeSubmit( String aP0_PDFName ,
                                 String aP1_FullPathFile )
      {
         aviewpdf objaviewpdf;
         objaviewpdf = new aviewpdf();
         objaviewpdf.AV10PDFName = aP0_PDFName;
         objaviewpdf.AV11FullPathFile = aP1_FullPathFile;
         objaviewpdf.context.SetSubmitInitialConfig(context);
         objaviewpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objaviewpdf);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aviewpdf)stateInfo).executePrivate();
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
         AV8xmlvar.OpenResponse(AV9httpresponse);
         if ( ! context.isAjaxRequest( ) )
         {
            AV9httpresponse.AppendHeader("Content-Type", "content = application/pdf");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV9httpresponse.AppendHeader("Content-Disposition", "inline;filename="+AV10PDFName);
         }
         AV9httpresponse.AddFile(AV11FullPathFile);
         AV8xmlvar.Close();
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         base.cleanup();
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
         GXKey = "";
         gxfirstwebparm = "";
         AV8xmlvar = new GXXMLWriter(context.GetPhysicalPath());
         AV9httpresponse = new GxHttpResponse( context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private String GXKey ;
      private String gxfirstwebparm ;
      private bool entryPointCalled ;
      private String AV10PDFName ;
      private String AV11FullPathFile ;
      private GXXMLWriter AV8xmlvar ;
      private GxHttpResponse AV9httpresponse ;
   }

}
