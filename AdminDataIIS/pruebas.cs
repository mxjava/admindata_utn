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
   public class pruebas : GXProcedure
   {
      public pruebas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public pruebas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( out String aP0_Texto )
      {
         this.AV2Texto = "" ;
         initialize();
         executePrivate();
         aP0_Texto=this.AV2Texto;
      }

      public String executeUdp( )
      {
         execute(out aP0_Texto);
         return AV2Texto ;
      }

      public void executeSubmit( out String aP0_Texto )
      {
         pruebas objpruebas;
         objpruebas = new pruebas();
         objpruebas.AV2Texto = "" ;
         objpruebas.context.SetSubmitInitialConfig(context);
         objpruebas.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpruebas);
         aP0_Texto=this.AV2Texto;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pruebas)stateInfo).executePrivate();
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
         args = new Object[] {(String)AV2Texto} ;
         ClassLoader.Execute("apruebas","GeneXus.Programs","apruebas", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
            AV2Texto = (String)(args[0]) ;
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

      private String AV2Texto ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private String aP0_Texto ;
   }

}
