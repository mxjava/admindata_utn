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
   public class pr_infor_personal : GXProcedure
   {
      public pr_infor_personal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public pr_infor_personal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_Vacantes_Id ,
                           int aP1_UsuarioId )
      {
         this.AV2Vacantes_Id = aP0_Vacantes_Id;
         this.AV3UsuarioId = aP1_UsuarioId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_Vacantes_Id ,
                                 int aP1_UsuarioId )
      {
         pr_infor_personal objpr_infor_personal;
         objpr_infor_personal = new pr_infor_personal();
         objpr_infor_personal.AV2Vacantes_Id = aP0_Vacantes_Id;
         objpr_infor_personal.AV3UsuarioId = aP1_UsuarioId;
         objpr_infor_personal.context.SetSubmitInitialConfig(context);
         objpr_infor_personal.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpr_infor_personal);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pr_infor_personal)stateInfo).executePrivate();
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
         args = new Object[] {(int)AV2Vacantes_Id,(int)AV3UsuarioId} ;
         ClassLoader.Execute("apr_infor_personal","GeneXus.Programs","apr_infor_personal", new Object[] {context }, "execute", args);
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

      private int AV2Vacantes_Id ;
      private int AV3UsuarioId ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
