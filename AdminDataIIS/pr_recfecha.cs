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
   public class pr_recfecha : GXProcedure
   {
      public pr_recfecha( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public pr_recfecha( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( String aP0_UsuariosCurp ,
                           out DateTime aP1_UsuariosFecNacimiento )
      {
         this.AV10UsuariosCurp = aP0_UsuariosCurp;
         this.AV11UsuariosFecNacimiento = DateTime.MinValue ;
         initialize();
         executePrivate();
         aP1_UsuariosFecNacimiento=this.AV11UsuariosFecNacimiento;
      }

      public DateTime executeUdp( String aP0_UsuariosCurp )
      {
         execute(aP0_UsuariosCurp, out aP1_UsuariosFecNacimiento);
         return AV11UsuariosFecNacimiento ;
      }

      public void executeSubmit( String aP0_UsuariosCurp ,
                                 out DateTime aP1_UsuariosFecNacimiento )
      {
         pr_recfecha objpr_recfecha;
         objpr_recfecha = new pr_recfecha();
         objpr_recfecha.AV10UsuariosCurp = aP0_UsuariosCurp;
         objpr_recfecha.AV11UsuariosFecNacimiento = DateTime.MinValue ;
         objpr_recfecha.context.SetSubmitInitialConfig(context);
         objpr_recfecha.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpr_recfecha);
         aP1_UsuariosFecNacimiento=this.AV11UsuariosFecNacimiento;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pr_recfecha)stateInfo).executePrivate();
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
         AV8Dia = StringUtil.Substring( AV10UsuariosCurp, 9, 2);
         AV9Mes = StringUtil.Substring( AV10UsuariosCurp, 7, 2);
         AV12Anio = StringUtil.Substring( AV10UsuariosCurp, 5, 2);
         AV11UsuariosFecNacimiento = context.localUtil.YMDToD( (int)(NumberUtil.Val( AV12Anio, ".")), (int)(NumberUtil.Val( AV9Mes, ".")), (int)(NumberUtil.Val( AV8Dia, ".")));
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
         AV8Dia = "";
         AV9Mes = "";
         AV12Anio = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private String AV8Dia ;
      private String AV9Mes ;
      private String AV12Anio ;
      private DateTime AV11UsuariosFecNacimiento ;
      private String AV10UsuariosCurp ;
      private DateTime aP1_UsuariosFecNacimiento ;
   }

}
