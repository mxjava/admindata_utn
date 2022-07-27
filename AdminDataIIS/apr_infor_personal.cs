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
using GeneXus.Printer;
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
   public class apr_infor_personal : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("Carmine");
         initialize();
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            GxWebError = 1;
            context.HttpContext.Response.StatusDescription = 403.ToString();
            context.HttpContext.Response.StatusCode = 403;
            context.WriteHtmlText( "<title>403 Forbidden</title>") ;
            context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
            context.WriteHtmlText( "<p /><hr />") ;
            GXUtil.WriteLog("send_http_error_code " + 403.ToString());
         }
         if ( GxWebError == 0 )
         {
            GXDecQS = Decrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "apr_infor_personal.aspx")), "apr_infor_personal.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "apr_infor_personal.aspx")))) ;
            }
            else
            {
               GxWebError = 1;
               context.HttpContext.Response.StatusDescription = 403.ToString();
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
            }
         }
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            if ( ! entryPointCalled )
            {
               AV9Vacantes_Id = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV10UsuarioId = (int)(NumberUtil.Val( GetNextPar( ), "."));
               }
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public apr_infor_personal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public apr_infor_personal( IGxContext context )
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
         this.AV9Vacantes_Id = aP0_Vacantes_Id;
         this.AV10UsuarioId = aP1_UsuarioId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_Vacantes_Id ,
                                 int aP1_UsuarioId )
      {
         apr_infor_personal objapr_infor_personal;
         objapr_infor_personal = new apr_infor_personal();
         objapr_infor_personal.AV9Vacantes_Id = aP0_Vacantes_Id;
         objapr_infor_personal.AV10UsuarioId = aP1_UsuarioId;
         objapr_infor_personal.context.SetSubmitInitialConfig(context);
         objapr_infor_personal.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objapr_infor_personal);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((apr_infor_personal)stateInfo).executePrivate();
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
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 13406, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            /* Using cursor P001Z2 */
            pr_default.execute(0, new Object[] {AV9Vacantes_Id, AV10UsuarioId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRK1Z2 = false;
               A284SUBT_ReclutadorId = P001Z2_A284SUBT_ReclutadorId[0];
               A290VacantesUsuariosEstatus = P001Z2_A290VacantesUsuariosEstatus[0];
               n290VacantesUsuariosEstatus = P001Z2_n290VacantesUsuariosEstatus[0];
               A263Vacantes_Id = P001Z2_A263Vacantes_Id[0];
               A11UsuariosId = P001Z2_A11UsuariosId[0];
               A260UsuariosTelef = P001Z2_A260UsuariosTelef[0];
               A261UsuariosCorreo = P001Z2_A261UsuariosCorreo[0];
               A288VacantesUsuariosFechaP = P001Z2_A288VacantesUsuariosFechaP[0];
               A294VacantesUsuariosMotD = P001Z2_A294VacantesUsuariosMotD[0];
               n294VacantesUsuariosMotD = P001Z2_n294VacantesUsuariosMotD[0];
               A260UsuariosTelef = P001Z2_A260UsuariosTelef[0];
               A261UsuariosCorreo = P001Z2_A261UsuariosCorreo[0];
               AV28VacantesUsuariosEstatus = A290VacantesUsuariosEstatus;
               if ( A290VacantesUsuariosEstatus == 0 )
               {
                  AV23Seguimiento = "1er. Filtro";
                  H1Z0( false, 33) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Seguimiento, "")), 0, Gx_line+0, 334, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+33);
                  H1Z0( false, 21) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Fecha Postulación", 0, Gx_line+0, 100, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Nombre", 117, Gx_line+0, 217, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Teléfono", 375, Gx_line+0, 475, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Correo electónico", 483, Gx_line+0, 583, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Reclutador", 625, Gx_line+0, 725, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(0, Gx_line+17, 917, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(108, Gx_line+0, 108, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(367, Gx_line+0, 367, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(475, Gx_line+0, 475, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(617, Gx_line+0, 617, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(917, Gx_line+0, 917, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(0, Gx_line+0, 0, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(0, Gx_line+0, 917, Gx_line+0, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+21);
               }
               else if ( A290VacantesUsuariosEstatus == 1 )
               {
                  AV23Seguimiento = "2do. Filtro";
                  H1Z0( false, 33) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Seguimiento, "")), 0, Gx_line+0, 334, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+33);
                  H1Z0( false, 21) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Fecha Postulación", 0, Gx_line+0, 100, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Nombre", 117, Gx_line+0, 217, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Teléfono", 375, Gx_line+0, 475, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Correo electónico", 483, Gx_line+0, 583, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Reclutador", 625, Gx_line+0, 725, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(0, Gx_line+17, 917, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(108, Gx_line+0, 108, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(367, Gx_line+0, 367, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(475, Gx_line+0, 475, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(617, Gx_line+0, 617, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(917, Gx_line+0, 917, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(0, Gx_line+0, 0, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(0, Gx_line+0, 917, Gx_line+0, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+21);
               }
               else if ( A290VacantesUsuariosEstatus == 2 )
               {
                  AV23Seguimiento = "3er. Filtro";
                  H1Z0( false, 33) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Seguimiento, "")), 0, Gx_line+0, 334, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+33);
                  H1Z0( false, 21) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Fecha Postulación", 0, Gx_line+0, 100, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Nombre", 117, Gx_line+0, 217, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Teléfono", 375, Gx_line+0, 475, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Correo electónico", 483, Gx_line+0, 583, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Reclutador", 625, Gx_line+0, 725, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(0, Gx_line+17, 917, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(108, Gx_line+0, 108, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(367, Gx_line+0, 367, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(475, Gx_line+0, 475, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(617, Gx_line+0, 617, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(917, Gx_line+0, 917, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(0, Gx_line+0, 0, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(0, Gx_line+0, 917, Gx_line+0, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+21);
               }
               else if ( A290VacantesUsuariosEstatus == 3 )
               {
                  AV23Seguimiento = "Proceso Completo";
                  H1Z0( false, 33) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Seguimiento, "")), 0, Gx_line+0, 334, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+33);
                  H1Z0( false, 21) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Fecha Postulación", 0, Gx_line+0, 100, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Nombre", 117, Gx_line+0, 217, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Teléfono", 375, Gx_line+0, 475, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Correo electónico", 483, Gx_line+0, 583, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Reclutador", 625, Gx_line+0, 725, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(0, Gx_line+17, 917, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(108, Gx_line+0, 108, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(367, Gx_line+0, 367, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(475, Gx_line+0, 475, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(617, Gx_line+0, 617, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(917, Gx_line+0, 917, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(0, Gx_line+0, 0, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(0, Gx_line+0, 917, Gx_line+0, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+21);
               }
               else if ( A290VacantesUsuariosEstatus == 4 )
               {
                  AV23Seguimiento = "Enviado a Cliente";
                  H1Z0( false, 33) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Seguimiento, "")), 0, Gx_line+0, 334, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+33);
                  H1Z0( false, 21) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Fecha Postulación", 0, Gx_line+0, 100, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Nombre", 117, Gx_line+0, 217, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Teléfono", 375, Gx_line+0, 475, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Correo electónico", 483, Gx_line+0, 583, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Reclutador", 625, Gx_line+0, 725, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(0, Gx_line+17, 917, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(108, Gx_line+0, 108, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(367, Gx_line+0, 367, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(475, Gx_line+0, 475, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(617, Gx_line+0, 617, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(917, Gx_line+0, 917, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(0, Gx_line+0, 0, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(0, Gx_line+0, 917, Gx_line+0, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+21);
               }
               else if ( A290VacantesUsuariosEstatus == 5 )
               {
                  AV23Seguimiento = "Descartado";
                  H1Z0( false, 33) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Seguimiento, "")), 0, Gx_line+0, 334, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+33);
                  H1Z0( false, 18) ;
                  getPrinter().GxDrawLine(0, Gx_line+0, 917, Gx_line+0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(0, Gx_line+0, 0, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(917, Gx_line+0, 917, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(617, Gx_line+0, 617, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(475, Gx_line+0, 475, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(367, Gx_line+0, 367, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(108, Gx_line+0, 108, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Motivo de Descarte", 625, Gx_line+0, 725, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Correo electónico", 483, Gx_line+0, 583, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Teléfono", 375, Gx_line+0, 475, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Nombre", 117, Gx_line+0, 217, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Fecha Postulación", 0, Gx_line+0, 100, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(0, Gx_line+0, 0, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(0, Gx_line+17, 917, Gx_line+17, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+18);
               }
               while ( (pr_default.getStatus(0) != 101) && ( P001Z2_A263Vacantes_Id[0] == A263Vacantes_Id ) && ( P001Z2_A284SUBT_ReclutadorId[0] == A284SUBT_ReclutadorId ) && ( P001Z2_A290VacantesUsuariosEstatus[0] == A290VacantesUsuariosEstatus ) )
               {
                  BRK1Z2 = false;
                  A11UsuariosId = P001Z2_A11UsuariosId[0];
                  A260UsuariosTelef = P001Z2_A260UsuariosTelef[0];
                  A261UsuariosCorreo = P001Z2_A261UsuariosCorreo[0];
                  A288VacantesUsuariosFechaP = P001Z2_A288VacantesUsuariosFechaP[0];
                  A294VacantesUsuariosMotD = P001Z2_A294VacantesUsuariosMotD[0];
                  n294VacantesUsuariosMotD = P001Z2_n294VacantesUsuariosMotD[0];
                  A260UsuariosTelef = P001Z2_A260UsuariosTelef[0];
                  A261UsuariosCorreo = P001Z2_A261UsuariosCorreo[0];
                  if ( A263Vacantes_Id != 17 )
                  {
                     if ( A263Vacantes_Id == AV9Vacantes_Id )
                     {
                        if ( A290VacantesUsuariosEstatus == AV28VacantesUsuariosEstatus )
                        {
                           if ( A284SUBT_ReclutadorId == AV10UsuarioId )
                           {
                              AV18usuarios = A11UsuariosId;
                              AV13UsuariosTelef = A260UsuariosTelef;
                              AV14UsuariosCorreo = A261UsuariosCorreo;
                              AV12SubT_ReclutadorId = A284SUBT_ReclutadorId;
                              AV15VacantesUsuariosFechaP = A288VacantesUsuariosFechaP;
                              AV29Fecha = context.localUtil.Format( A288VacantesUsuariosFechaP, "99/99/9999 99:99");
                              AV16vacantes_id_Envio = (short)(A263Vacantes_Id);
                              /* Execute user subroutine: 'NOMBREPACIENTE' */
                              S111 ();
                              if ( returnInSub )
                              {
                                 pr_default.close(0);
                                 this.cleanup();
                                 if (true) return;
                              }
                              if ( A290VacantesUsuariosEstatus == 0 )
                              {
                                 H1Z0( false, 24) ;
                                 getPrinter().GxDrawLine(0, Gx_line+20, 917, Gx_line+20, 1, 0, 0, 0, 2) ;
                                 getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13UsuariosTelef, "")), 383, Gx_line+0, 450, Gx_line+15, 0, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14UsuariosCorreo, "")), 483, Gx_line+0, 608, Gx_line+15, 0, 0, 0, 0) ;
                                 getPrinter().GxDrawText(context.localUtil.Format( AV15VacantesUsuariosFechaP, "99/99/9999 99:99"), 0, Gx_line+0, 93, Gx_line+15, 2+256, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19UsuariosNomCompleto, "")), 117, Gx_line+0, 359, Gx_line+15, 0, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20UsuariosReclutador, "")), 625, Gx_line+0, 917, Gx_line+15, 0, 0, 0, 0) ;
                                 Gx_OldLine = Gx_line;
                                 Gx_line = (int)(Gx_line+24);
                              }
                              else if ( A290VacantesUsuariosEstatus == 1 )
                              {
                                 H1Z0( false, 24) ;
                                 getPrinter().GxDrawLine(0, Gx_line+20, 917, Gx_line+20, 1, 0, 0, 0, 2) ;
                                 getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13UsuariosTelef, "")), 383, Gx_line+0, 450, Gx_line+15, 0, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14UsuariosCorreo, "")), 483, Gx_line+0, 608, Gx_line+15, 0, 0, 0, 0) ;
                                 getPrinter().GxDrawText(context.localUtil.Format( AV15VacantesUsuariosFechaP, "99/99/9999 99:99"), 0, Gx_line+0, 93, Gx_line+15, 2+256, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19UsuariosNomCompleto, "")), 117, Gx_line+0, 359, Gx_line+15, 0, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20UsuariosReclutador, "")), 625, Gx_line+0, 917, Gx_line+15, 0, 0, 0, 0) ;
                                 Gx_OldLine = Gx_line;
                                 Gx_line = (int)(Gx_line+24);
                              }
                              else if ( A290VacantesUsuariosEstatus == 2 )
                              {
                                 H1Z0( false, 24) ;
                                 getPrinter().GxDrawLine(0, Gx_line+20, 917, Gx_line+20, 1, 0, 0, 0, 2) ;
                                 getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13UsuariosTelef, "")), 383, Gx_line+0, 450, Gx_line+15, 0, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14UsuariosCorreo, "")), 483, Gx_line+0, 608, Gx_line+15, 0, 0, 0, 0) ;
                                 getPrinter().GxDrawText(context.localUtil.Format( AV15VacantesUsuariosFechaP, "99/99/9999 99:99"), 0, Gx_line+0, 93, Gx_line+15, 2+256, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19UsuariosNomCompleto, "")), 117, Gx_line+0, 359, Gx_line+15, 0, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20UsuariosReclutador, "")), 625, Gx_line+0, 917, Gx_line+15, 0, 0, 0, 0) ;
                                 Gx_OldLine = Gx_line;
                                 Gx_line = (int)(Gx_line+24);
                              }
                              else if ( A290VacantesUsuariosEstatus == 3 )
                              {
                                 H1Z0( false, 24) ;
                                 getPrinter().GxDrawLine(0, Gx_line+20, 917, Gx_line+20, 1, 0, 0, 0, 2) ;
                                 getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13UsuariosTelef, "")), 383, Gx_line+0, 450, Gx_line+15, 0, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14UsuariosCorreo, "")), 483, Gx_line+0, 608, Gx_line+15, 0, 0, 0, 0) ;
                                 getPrinter().GxDrawText(context.localUtil.Format( AV15VacantesUsuariosFechaP, "99/99/9999 99:99"), 0, Gx_line+0, 93, Gx_line+15, 2+256, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19UsuariosNomCompleto, "")), 117, Gx_line+0, 359, Gx_line+15, 0, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20UsuariosReclutador, "")), 625, Gx_line+0, 917, Gx_line+15, 0, 0, 0, 0) ;
                                 Gx_OldLine = Gx_line;
                                 Gx_line = (int)(Gx_line+24);
                              }
                              else if ( A290VacantesUsuariosEstatus == 4 )
                              {
                                 H1Z0( false, 24) ;
                                 getPrinter().GxDrawLine(0, Gx_line+20, 917, Gx_line+20, 1, 0, 0, 0, 2) ;
                                 getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13UsuariosTelef, "")), 383, Gx_line+0, 450, Gx_line+15, 0, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14UsuariosCorreo, "")), 483, Gx_line+0, 608, Gx_line+15, 0, 0, 0, 0) ;
                                 getPrinter().GxDrawText(context.localUtil.Format( AV15VacantesUsuariosFechaP, "99/99/9999 99:99"), 0, Gx_line+0, 93, Gx_line+15, 2+256, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19UsuariosNomCompleto, "")), 117, Gx_line+0, 359, Gx_line+15, 0, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20UsuariosReclutador, "")), 625, Gx_line+0, 917, Gx_line+15, 0, 0, 0, 0) ;
                                 Gx_OldLine = Gx_line;
                                 Gx_line = (int)(Gx_line+24);
                              }
                              else if ( A290VacantesUsuariosEstatus == 5 )
                              {
                                 AV25nlin1 = (short)(LVCharUtil.LinesWrap( A294VacantesUsuariosMotD, 50));
                                 AV26i1 = 1;
                                 while ( AV26i1 <= AV25nlin1 )
                                 {
                                    if ( AV26i1 != 1 )
                                    {
                                       AV13UsuariosTelef = "";
                                       AV14UsuariosCorreo = "";
                                       AV19UsuariosNomCompleto = "";
                                       AV29Fecha = "";
                                    }
                                    AV24vacantesusuariosmotd = LVCharUtil.GetLineWrap( A294VacantesUsuariosMotD, AV26i1, 50);
                                    H1Z0( false, 15) ;
                                    getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                    getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14UsuariosCorreo, "")), 483, Gx_line+0, 608, Gx_line+15, 0, 0, 0, 0) ;
                                    getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13UsuariosTelef, "")), 383, Gx_line+0, 450, Gx_line+15, 0, 0, 0, 0) ;
                                    getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19UsuariosNomCompleto, "")), 117, Gx_line+0, 359, Gx_line+15, 0, 0, 0, 0) ;
                                    getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24vacantesusuariosmotd, "")), 625, Gx_line+0, 917, Gx_line+15, 0, 0, 0, 0) ;
                                    getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29Fecha, "")), 0, Gx_line+0, 105, Gx_line+15, 0+256, 0, 0, 0) ;
                                    Gx_OldLine = Gx_line;
                                    Gx_line = (int)(Gx_line+15);
                                    AV26i1 = (short)(AV26i1+1);
                                 }
                                 H1Z0( false, 5) ;
                                 getPrinter().GxDrawLine(0, Gx_line+0, 917, Gx_line+0, 1, 0, 0, 0, 2) ;
                                 Gx_OldLine = Gx_line;
                                 Gx_line = (int)(Gx_line+5);
                              }
                           }
                        }
                     }
                  }
                  BRK1Z2 = true;
                  pr_default.readNext(0);
               }
               if ( ! BRK1Z2 )
               {
                  BRK1Z2 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H1Z0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException e )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException e )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'NOMBREPACIENTE' Routine */
         /* Using cursor P001Z3 */
         pr_default.execute(1, new Object[] {AV18usuarios});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A11UsuariosId = P001Z3_A11UsuariosId[0];
            A64UsuariosApMat = P001Z3_A64UsuariosApMat[0];
            A65UsuariosApPat = P001Z3_A65UsuariosApPat[0];
            A66UsuariosNombre = P001Z3_A66UsuariosNombre[0];
            A97UsuariosNomCompleto = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + StringUtil.Trim( A64UsuariosApMat);
            AV19UsuariosNomCompleto = A97UsuariosNomCompleto;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         /* Using cursor P001Z4 */
         pr_default.execute(2, new Object[] {AV12SubT_ReclutadorId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A11UsuariosId = P001Z4_A11UsuariosId[0];
            A64UsuariosApMat = P001Z4_A64UsuariosApMat[0];
            A65UsuariosApPat = P001Z4_A65UsuariosApPat[0];
            A66UsuariosNombre = P001Z4_A66UsuariosNombre[0];
            A97UsuariosNomCompleto = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + StringUtil.Trim( A64UsuariosApMat);
            AV20UsuariosReclutador = A97UsuariosNomCompleto;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
      }

      protected void H1Z0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if (IsMain)	waitPrinterEnd();
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
         GXDecQS = "";
         gxfirstwebparm = "";
         scmdbuf = "";
         P001Z2_A284SUBT_ReclutadorId = new int[1] ;
         P001Z2_A290VacantesUsuariosEstatus = new short[1] ;
         P001Z2_n290VacantesUsuariosEstatus = new bool[] {false} ;
         P001Z2_A263Vacantes_Id = new int[1] ;
         P001Z2_A11UsuariosId = new int[1] ;
         P001Z2_A260UsuariosTelef = new String[] {""} ;
         P001Z2_A261UsuariosCorreo = new String[] {""} ;
         P001Z2_A288VacantesUsuariosFechaP = new DateTime[] {DateTime.MinValue} ;
         P001Z2_A294VacantesUsuariosMotD = new String[] {""} ;
         P001Z2_n294VacantesUsuariosMotD = new bool[] {false} ;
         A260UsuariosTelef = "";
         A261UsuariosCorreo = "";
         A288VacantesUsuariosFechaP = (DateTime)(DateTime.MinValue);
         A294VacantesUsuariosMotD = "";
         AV23Seguimiento = "";
         AV13UsuariosTelef = "";
         AV14UsuariosCorreo = "";
         AV15VacantesUsuariosFechaP = (DateTime)(DateTime.MinValue);
         AV29Fecha = "";
         AV19UsuariosNomCompleto = "";
         AV20UsuariosReclutador = "";
         AV24vacantesusuariosmotd = "";
         P001Z3_A11UsuariosId = new int[1] ;
         P001Z3_A64UsuariosApMat = new String[] {""} ;
         P001Z3_A65UsuariosApPat = new String[] {""} ;
         P001Z3_A66UsuariosNombre = new String[] {""} ;
         A64UsuariosApMat = "";
         A65UsuariosApPat = "";
         A66UsuariosNombre = "";
         A97UsuariosNomCompleto = "";
         P001Z4_A11UsuariosId = new int[1] ;
         P001Z4_A64UsuariosApMat = new String[] {""} ;
         P001Z4_A65UsuariosApPat = new String[] {""} ;
         P001Z4_A66UsuariosNombre = new String[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apr_infor_personal__default(),
            new Object[][] {
                new Object[] {
               P001Z2_A284SUBT_ReclutadorId, P001Z2_A290VacantesUsuariosEstatus, P001Z2_n290VacantesUsuariosEstatus, P001Z2_A263Vacantes_Id, P001Z2_A11UsuariosId, P001Z2_A260UsuariosTelef, P001Z2_A261UsuariosCorreo, P001Z2_A288VacantesUsuariosFechaP, P001Z2_A294VacantesUsuariosMotD, P001Z2_n294VacantesUsuariosMotD
               }
               , new Object[] {
               P001Z3_A11UsuariosId, P001Z3_A64UsuariosApMat, P001Z3_A65UsuariosApPat, P001Z3_A66UsuariosNombre
               }
               , new Object[] {
               P001Z4_A11UsuariosId, P001Z4_A64UsuariosApMat, P001Z4_A65UsuariosApPat, P001Z4_A66UsuariosNombre
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short A290VacantesUsuariosEstatus ;
      private short AV28VacantesUsuariosEstatus ;
      private short AV16vacantes_id_Envio ;
      private short AV25nlin1 ;
      private short AV26i1 ;
      private int AV9Vacantes_Id ;
      private int AV10UsuarioId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A284SUBT_ReclutadorId ;
      private int A263Vacantes_Id ;
      private int A11UsuariosId ;
      private int Gx_OldLine ;
      private int AV18usuarios ;
      private int AV12SubT_ReclutadorId ;
      private String GXKey ;
      private String GXDecQS ;
      private String gxfirstwebparm ;
      private String scmdbuf ;
      private String A260UsuariosTelef ;
      private String AV13UsuariosTelef ;
      private DateTime A288VacantesUsuariosFechaP ;
      private DateTime AV15VacantesUsuariosFechaP ;
      private bool entryPointCalled ;
      private bool BRK1Z2 ;
      private bool n290VacantesUsuariosEstatus ;
      private bool n294VacantesUsuariosMotD ;
      private bool returnInSub ;
      private String A261UsuariosCorreo ;
      private String A294VacantesUsuariosMotD ;
      private String AV23Seguimiento ;
      private String AV14UsuariosCorreo ;
      private String AV29Fecha ;
      private String AV19UsuariosNomCompleto ;
      private String AV20UsuariosReclutador ;
      private String AV24vacantesusuariosmotd ;
      private String A64UsuariosApMat ;
      private String A65UsuariosApPat ;
      private String A66UsuariosNombre ;
      private String A97UsuariosNomCompleto ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P001Z2_A284SUBT_ReclutadorId ;
      private short[] P001Z2_A290VacantesUsuariosEstatus ;
      private bool[] P001Z2_n290VacantesUsuariosEstatus ;
      private int[] P001Z2_A263Vacantes_Id ;
      private int[] P001Z2_A11UsuariosId ;
      private String[] P001Z2_A260UsuariosTelef ;
      private String[] P001Z2_A261UsuariosCorreo ;
      private DateTime[] P001Z2_A288VacantesUsuariosFechaP ;
      private String[] P001Z2_A294VacantesUsuariosMotD ;
      private bool[] P001Z2_n294VacantesUsuariosMotD ;
      private int[] P001Z3_A11UsuariosId ;
      private String[] P001Z3_A64UsuariosApMat ;
      private String[] P001Z3_A65UsuariosApPat ;
      private String[] P001Z3_A66UsuariosNombre ;
      private int[] P001Z4_A11UsuariosId ;
      private String[] P001Z4_A64UsuariosApMat ;
      private String[] P001Z4_A65UsuariosApPat ;
      private String[] P001Z4_A66UsuariosNombre ;
   }

   public class apr_infor_personal__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP001Z2 ;
          prmP001Z2 = new Object[] {
          new Object[] {"AV9Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"AV10UsuarioId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmP001Z3 ;
          prmP001Z3 = new Object[] {
          new Object[] {"AV18usuarios",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmP001Z4 ;
          prmP001Z4 = new Object[] {
          new Object[] {"AV12SubT_ReclutadorId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P001Z2", "SELECT T1.`SUBT_ReclutadorId`, T1.`VacantesUsuariosEstatus`, T1.`Vacantes_Id`, T1.`UsuariosId`, T2.`UsuariosTelef`, T2.`UsuariosCorreo`, T1.`VacantesUsuariosFechaP`, T1.`VacantesUsuariosMotD` FROM (`VacantesUsuariosVacante` T1 INNER JOIN `Usuarios` T2 ON T2.`UsuariosId` = T1.`UsuariosId`) WHERE (T1.`Vacantes_Id` = ? and T1.`SUBT_ReclutadorId` = ?) AND (T1.`Vacantes_Id` <> 17) ORDER BY T1.`Vacantes_Id`, T1.`SUBT_ReclutadorId`, T1.`VacantesUsuariosEstatus` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001Z2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P001Z3", "SELECT `UsuariosId`, `UsuariosApMat`, `UsuariosApPat`, `UsuariosNombre` FROM `Usuarios` WHERE `UsuariosId` = ? ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001Z3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P001Z4", "SELECT `UsuariosId`, `UsuariosApMat`, `UsuariosApPat`, `UsuariosNombre` FROM `Usuarios` WHERE `UsuariosId` = ? ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001Z4,1, GxCacheFrequency.OFF ,false,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3) ;
                ((int[]) buf[4])[0] = rslt.getInt(4) ;
                ((String[]) buf[5])[0] = rslt.getString(5, 10) ;
                ((String[]) buf[6])[0] = rslt.getVarchar(6) ;
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(7) ;
                ((String[]) buf[8])[0] = rslt.getVarchar(8) ;
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((String[]) buf[3])[0] = rslt.getVarchar(4) ;
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((String[]) buf[3])[0] = rslt.getVarchar(4) ;
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
             case 0 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
             case 1 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 2 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

}
