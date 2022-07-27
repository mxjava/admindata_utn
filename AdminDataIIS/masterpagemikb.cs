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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class masterpagemikb : GXMasterPage, System.Web.SessionState.IRequiresSessionState
   {
      public masterpagemikb( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public masterpagemikb( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            PA072( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS072( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE072( ) ;
               }
            }
         }
         this.cleanup();
      }

      protected void RenderHtmlHeaders( )
      {
         getDataAreaObject().RenderHtmlHeaders();
      }

      protected void RenderHtmlOpenForm( )
      {
         getDataAreaObject().RenderHtmlOpenForm();
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
      }

      protected void RenderHtmlCloseForm072( )
      {
         SendCloseFormHiddens( ) ;
         SendSecurityToken((String)(sPrefix));
         getDataAreaObject().RenderHtmlCloseForm();
         context.AddJavascriptSource("masterpagemikb.js", "?202262714344493", false, true);
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
      }

      public override String GetPgmname( )
      {
         return "MasterPageMiKb" ;
      }

      public override String GetPgmdesc( )
      {
         return "Master Page" ;
      }

      protected void WB070( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            if ( ! ShowMPWhenPopUp( ) && context.isPopUpObject( ) )
            {
               /* Content placeholder */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gx-content-placeholder");
               context.WriteHtmlText( ">") ;
               getDataAreaObject().RenderHtmlContent();
               context.WriteHtmlText( "</div>") ;
               wbLoad = true;
               return  ;
            }
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtscrip1_Internalname, lblTxtscrip1_Caption, "", "", lblTxtscrip1_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "TextBlock", 0, "", 1, 1, 2, "HLP_MasterPageMiKb.htm");
            /* Content placeholder */
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-content-placeholder");
            context.WriteHtmlText( ">") ;
            getDataAreaObject().RenderHtmlContent();
            context.WriteHtmlText( "</div>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtscript2_Internalname, lblTxtscript2_Caption, "", "", lblTxtscript2_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "TextBlock", 0, "", 1, 1, 2, "HLP_MasterPageMiKb.htm");
         }
         wbLoad = true;
      }

      protected void START072( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP070( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( getDataAreaObject().ExecuteStartEvent() != 0 )
            {
               setAjaxCallMode();
            }
         }
      }

      protected void WS072( )
      {
         START072( ) ;
         EVT072( ) ;
      }

      protected void EVT072( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "RFR_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11072 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E12072 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! wbErr )
                           {
                              Rfr0gs = false;
                              if ( ! Rfr0gs )
                              {
                              }
                              dynload_actions( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           dynload_actions( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  if ( context.wbHandled == 0 )
                  {
                     getDataAreaObject().DispatchEvents();
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void WE072( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm072( ) ;
            }
         }
      }

      protected void PA072( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
            }
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF072( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF072( )
      {
         if ( ShowMPWhenPopUp( ) || ! context.isPopUpObject( ) )
         {
            gxdyncontrolsrefreshing = true;
            fix_multi_value_controls( ) ;
            gxdyncontrolsrefreshing = false;
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E12072 ();
            WB070( ) ;
         }
      }

      protected void send_integrity_lvl_hashes072( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP070( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11072 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11072 ();
         if (returnInSub) return;
      }

      protected void E11072( )
      {
         /* Start Routine */
         AV5vRuta = "../static/Resources/";
         AV15SesRolId = AV10Sesion.Get("RolId");
         AV16RolId = (int)(NumberUtil.Val( AV15SesRolId, "."));
         AssignAttri("", true, "AV16RolId", StringUtil.LTrimStr( (decimal)(AV16RolId), 9, 0));
         AV18Objeto = (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption;
         AssignAttri("", true, "AV18Objeto", AV18Objeto);
         if ( ! ( StringUtil.StrCmp(AV18Objeto, "SinAcceso") == 0 ) )
         {
            /* Execute user subroutine: 'VALIDAAUTH' */
            S112 ();
            if (returnInSub) return;
         }
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml = "<meta content=\"width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no\" name=\"viewport\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV5vRuta+"MyMaster/bower_components/font-awesome/css/font-awesome.min.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV5vRuta+"MyMaster/bower_components/Ionicons/css/ionicons.min.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV5vRuta+"MyMaster/dist/css/AdminLTE.min.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV5vRuta+"MyMaster/dist/css/skins/_all-skins.min.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV5vRuta+"MyMaster/bower_components/morris.js/morris.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV5vRuta+"MyMaster/bower_components/jvectormap/jquery-jvectormap.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV5vRuta+"MyMaster/bower_components/bootstrap-daterangepicker/daterangepicker.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV5vRuta+"MyMaster/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css\">"+StringUtil.NewLine( )+"<script>window.onload = function(){document.body.className = \"form-horizontal Form form-horizontal-fx hold-transition skin-blue sidebar-mini\";}</script>"+"<link href=\""+context.convertURL( (String)(context.GetImagePath( "6c4e657c-6882-474f-9ba4-cffe7e37d7b8", "", context.GetTheme( ))))+"\" rel=\"shortcut icon\">";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption = "AdminData";
         AssignProp("", true, "FORM", "Caption", (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption, true);
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Meta.addItem("charset", "UTF-8", 0) ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/bower_components/jquery/dist/jquery.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/bower_components/jquery-ui/jquery-ui.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/bower_components/raphael/raphael.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/bower_components/jquery-sparkline/dist/jquery.sparkline.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/plugins/jvectormap/jquery-jvectormap-world-mill-en.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/bower_components/jquery-knob/dist/jquery.knob.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/bower_components/moment/min/moment.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/bower_components/bootstrap-daterangepicker/daterangepicker.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/bower_components/jquery-slimscroll/jquery.slimscroll.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/bower_components/fastclick/lib/fastclick.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/dist/js/adminlte.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/dist/js/demo.js") ;
         AV12SesUsuarioId = AV10Sesion.Get("UsuarioId");
         AV11UsuarioId = (int)(NumberUtil.Val( AV12SesUsuarioId, "."));
         AssignAttri("", true, "AV11UsuarioId", StringUtil.LTrimStr( (decimal)(AV11UsuarioId), 9, 0));
         /* Using cursor H00072 */
         pr_default.execute(0, new Object[] {AV11UsuarioId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A24RolId = H00072_A24RolId[0];
            A11UsuariosId = H00072_A11UsuariosId[0];
            A40000UsuariosIcono_GXI = H00072_A40000UsuariosIcono_GXI[0];
            A64UsuariosApMat = H00072_A64UsuariosApMat[0];
            A65UsuariosApPat = H00072_A65UsuariosApPat[0];
            A66UsuariosNombre = H00072_A66UsuariosNombre[0];
            A128RolDescripcion = H00072_A128RolDescripcion[0];
            A128RolDescripcion = H00072_A128RolDescripcion[0];
            AV13UsuarioFoto = A40000UsuariosIcono_GXI;
            AV14UsuarioNombre = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + A64UsuariosApMat;
            AV17RolDesc = A128RolDescripcion;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV11UsuarioId == 0 )
         {
            CallWebObject(formatLink("acceso.aspx") );
            context.wjLocDisableFrm = 1;
         }
         AV7vScript = "<div class=\"wrapper\">" + StringUtil.NewLine( ) + "<header class=\"main-header\">" + StringUtil.NewLine( ) + "<a href=\"#\" class=\"logo\">" + StringUtil.NewLine( ) + "<span class=\"logo-mini\"><b>A</b>LT</span>" + StringUtil.NewLine( ) + "<span class=\"logo-lg\"><b>Admin</b>DATA</span>" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "<nav class=\"navbar navbar-static-top\">" + StringUtil.NewLine( ) + "<a href=\"#\" class=\"sidebar-toggle\" data-toggle=\"push-menu\" role=\"button\">" + StringUtil.NewLine( ) + " <span class=\"sr-only\"></span>" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "<div class=\"navbar-custom-menu\">" + StringUtil.NewLine( ) + "<ul class=\"nav navbar-nav\">" + StringUtil.NewLine( ) + "<li class=\"dropdown notifications-menu\">" + StringUtil.NewLine( ) + "<a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">" + StringUtil.NewLine( ) + "<i class=\"fa fa-bell-o\"></i>" + StringUtil.NewLine( ) + "<span class=\"label label-warning\">5</span>" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "<ul class=\"dropdown-menu\">" + StringUtil.NewLine( ) + "<li class=\"header\">Tienes 5 Notificaciones</li>" + StringUtil.NewLine( ) + "<li>" + StringUtil.NewLine( ) + "<ul class=\"menu\">" + StringUtil.NewLine( ) + "<li>" + StringUtil.NewLine( ) + "<a href=\"#\">" + StringUtil.NewLine( ) + "<i class=\"fa fa-users text-aqua\"></i> 5 new members joined today" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "</li>" + StringUtil.NewLine( ) + "</ul>" + StringUtil.NewLine( ) + "</li>" + StringUtil.NewLine( ) + "<li class=\"footer\"><a href=\"#\">Ver Todo</a></li>" + StringUtil.NewLine( ) + "</ul>" + StringUtil.NewLine( ) + "</li>" + StringUtil.NewLine( ) + "</ul>" + StringUtil.NewLine( ) + "</div>" + StringUtil.NewLine( ) + "</nav>" + StringUtil.NewLine( ) + "</header>" + StringUtil.NewLine( ) + "<aside class=\"main-sidebar\" style=\"max-height: 100%;\">" + StringUtil.NewLine( ) + "<section class=\"sidebar\">" + StringUtil.NewLine( ) + "<div class=\"user-panel\">" + StringUtil.NewLine( ) + "<div class=\"pull-left image\">" + StringUtil.NewLine( ) + "<img src=\"" + StringUtil.Trim( AV13UsuarioFoto) + "\" class=\"img-circle\" alt=\"User Image\">" + StringUtil.NewLine( ) + "</div>" + StringUtil.NewLine( ) + "<div class=\"pull-left info\">" + StringUtil.NewLine( ) + "<p>" + StringUtil.Trim( AV14UsuarioNombre) + "</p>" + StringUtil.NewLine( ) + "<a href=\"#\"><i class=\"fa fa-circle text-success\"></i>" + StringUtil.Trim( AV17RolDesc) + "</a>" + StringUtil.NewLine( ) + "</div>" + StringUtil.NewLine( ) + "</div>" + StringUtil.NewLine( ) + "<ul class=\"sidebar-menu\" data-widget=\"tree\">" + StringUtil.NewLine( );
         /* Using cursor H00073 */
         pr_default.execute(1, new Object[] {AV16RolId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A1MenuXid = H00073_A1MenuXid[0];
            A24RolId = H00073_A24RolId[0];
            A5MenXEst = H00073_A5MenXEst[0];
            n5MenXEst = H00073_n5MenXEst[0];
            A258MenPadre = H00073_A258MenPadre[0];
            n258MenPadre = H00073_n258MenPadre[0];
            A2MenuXDesc = H00073_A2MenuXDesc[0];
            n2MenuXDesc = H00073_n2MenuXDesc[0];
            A40001MenIcono_GXI = H00073_A40001MenIcono_GXI[0];
            n40001MenIcono_GXI = H00073_n40001MenIcono_GXI[0];
            A4MenXUrl = H00073_A4MenXUrl[0];
            n4MenXUrl = H00073_n4MenXUrl[0];
            A3MenuXPosi = H00073_A3MenuXPosi[0];
            n3MenuXPosi = H00073_n3MenuXPosi[0];
            A5MenXEst = H00073_A5MenXEst[0];
            n5MenXEst = H00073_n5MenXEst[0];
            A258MenPadre = H00073_A258MenPadre[0];
            n258MenPadre = H00073_n258MenPadre[0];
            A2MenuXDesc = H00073_A2MenuXDesc[0];
            n2MenuXDesc = H00073_n2MenuXDesc[0];
            A40001MenIcono_GXI = H00073_A40001MenIcono_GXI[0];
            n40001MenIcono_GXI = H00073_n40001MenIcono_GXI[0];
            A4MenXUrl = H00073_A4MenXUrl[0];
            n4MenXUrl = H00073_n4MenXUrl[0];
            A3MenuXPosi = H00073_A3MenuXPosi[0];
            n3MenuXPosi = H00073_n3MenuXPosi[0];
            if ( A258MenPadre == 0 )
            {
               AV9vScript11 = AV9vScript11 + "<li class=\"header\">" + StringUtil.Trim( A2MenuXDesc) + "</li>";
               AssignAttri("", true, "AV9vScript11", AV9vScript11);
            }
            else
            {
               AV9vScript11 = AV9vScript11 + "<li class=\"active treeview\">" + StringUtil.NewLine( ) + "<a href=\"" + StringUtil.Trim( A4MenXUrl) + "\">" + StringUtil.NewLine( ) + "<i><img src=\"" + A40001MenIcono_GXI + "\"  alt=\"User Image\"></i> <span>" + StringUtil.Trim( A2MenuXDesc) + "</span>" + StringUtil.NewLine( ) + "<span class=\"pull-right-container\">" + StringUtil.NewLine( ) + "<i class=\"fa fa-angle-left pull-right\"></i>" + StringUtil.NewLine( ) + "</span>" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "</li>";
               AssignAttri("", true, "AV9vScript11", AV9vScript11);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV7vScript = AV7vScript + AV9vScript11 + "</ul>" + StringUtil.NewLine( ) + "</section>" + StringUtil.NewLine( ) + "</aside>" + StringUtil.NewLine( ) + "<div class=\"content-wrapper\" >" + StringUtil.NewLine( ) + "<section class=\"content-header\">" + StringUtil.NewLine( ) + "<ol class=\"breadcrumb\" style=\"position:static;\">" + StringUtil.NewLine( ) + "<li><a href=\"#\"><i class=\"fa fa-dashboard\"></i> Posición</a></li>" + StringUtil.NewLine( ) + "<li class=\"active\">" + (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption + "</li>" + StringUtil.NewLine( ) + "</ol>" + StringUtil.NewLine( ) + "</section>" + StringUtil.NewLine( ) + "<section class=\"content\" >";
         AV8vScript2 = "  </section></div></div>";
         lblTxtscrip1_Caption = AV7vScript;
         AssignProp("", true, lblTxtscrip1_Internalname, "Caption", lblTxtscrip1_Caption, true);
         lblTxtscript2_Caption = AV8vScript2;
         AssignProp("", true, lblTxtscript2_Internalname, "Caption", lblTxtscript2_Caption, true);
      }

      protected void S112( )
      {
         /* 'VALIDAAUTH' Routine */
         GXt_boolean1 = AV23Acceso;
         new getauth(context ).execute(  AV18Objeto,  AV16RolId, out  GXt_boolean1) ;
         AV23Acceso = GXt_boolean1;
         if ( ! AV23Acceso )
         {
            CallWebObject(formatLink("sinacceso.aspx") );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E12072( )
      {
         /* Load Routine */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override String getresponse( String sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA072( ) ;
         WS072( ) ;
         WE072( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( String sGXDynURL )
      {
      }

      public override void master_styles( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( ) ;
         idxLst = 1;
         while ( idxLst <= (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)(getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Item(idxLst))), "?20226271434451", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("masterpagemikb.js", "?20226271434451", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTxtscrip1_Internalname = "TXTSCRIP1_MPAGE";
         lblTxtscript2_Internalname = "TXTSCRIPT2_MPAGE";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Internalname = "FORM_MPAGE";
      }

      public override void initialize_properties( )
      {
         init_default_properties( ) ;
         lblTxtscript2_Caption = "Script2";
         lblTxtscrip1_Caption = "Script1";
         Contholder1.setDataArea(getDataAreaObject());
      }

      protected override bool IsSpaSupported( )
      {
         return false ;
      }

      public override void InitializeDynEvents( )
      {
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
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
         Contholder1 = new GXDataAreaControl();
         GXKey = "";
         sPrefix = "";
         lblTxtscrip1_Jsonclick = "";
         lblTxtscript2_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5vRuta = "";
         AV15SesRolId = "";
         AV10Sesion = context.GetSession();
         AV18Objeto = "";
         AV12SesUsuarioId = "";
         scmdbuf = "";
         H00072_A24RolId = new int[1] ;
         H00072_A11UsuariosId = new int[1] ;
         H00072_A40000UsuariosIcono_GXI = new String[] {""} ;
         H00072_A64UsuariosApMat = new String[] {""} ;
         H00072_A65UsuariosApPat = new String[] {""} ;
         H00072_A66UsuariosNombre = new String[] {""} ;
         H00072_A128RolDescripcion = new String[] {""} ;
         A40000UsuariosIcono_GXI = "";
         A64UsuariosApMat = "";
         A65UsuariosApPat = "";
         A66UsuariosNombre = "";
         A128RolDescripcion = "";
         AV13UsuarioFoto = "";
         AV14UsuarioNombre = "";
         AV17RolDesc = "";
         AV7vScript = "";
         H00073_A1MenuXid = new short[1] ;
         H00073_A24RolId = new int[1] ;
         H00073_A5MenXEst = new String[] {""} ;
         H00073_n5MenXEst = new bool[] {false} ;
         H00073_A258MenPadre = new short[1] ;
         H00073_n258MenPadre = new bool[] {false} ;
         H00073_A2MenuXDesc = new String[] {""} ;
         H00073_n2MenuXDesc = new bool[] {false} ;
         H00073_A40001MenIcono_GXI = new String[] {""} ;
         H00073_n40001MenIcono_GXI = new bool[] {false} ;
         H00073_A4MenXUrl = new String[] {""} ;
         H00073_n4MenXUrl = new bool[] {false} ;
         H00073_A3MenuXPosi = new short[1] ;
         H00073_n3MenuXPosi = new bool[] {false} ;
         A5MenXEst = "";
         A2MenuXDesc = "";
         A40001MenIcono_GXI = "";
         A4MenXUrl = "";
         AV9vScript11 = "";
         AV8vScript2 = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sDynURL = "";
         Form = new GXWebForm();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.masterpagemikb__default(),
            new Object[][] {
                new Object[] {
               H00072_A24RolId, H00072_A11UsuariosId, H00072_A40000UsuariosIcono_GXI, H00072_A64UsuariosApMat, H00072_A65UsuariosApPat, H00072_A66UsuariosNombre, H00072_A128RolDescripcion
               }
               , new Object[] {
               H00073_A1MenuXid, H00073_A24RolId, H00073_A5MenXEst, H00073_n5MenXEst, H00073_A258MenPadre, H00073_n258MenPadre, H00073_A2MenuXDesc, H00073_n2MenuXDesc, H00073_A40001MenIcono_GXI, H00073_n40001MenIcono_GXI,
               H00073_A4MenXUrl, H00073_n4MenXUrl, H00073_A3MenuXPosi, H00073_n3MenuXPosi
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short initialized ;
      private short GxWebError ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A1MenuXid ;
      private short A258MenPadre ;
      private short A3MenuXPosi ;
      private short nGotPars ;
      private short nGXWrapped ;
      private int AV16RolId ;
      private int AV11UsuarioId ;
      private int A24RolId ;
      private int A11UsuariosId ;
      private int idxLst ;
      private String GXKey ;
      private String sPrefix ;
      private String lblTxtscrip1_Internalname ;
      private String lblTxtscrip1_Caption ;
      private String lblTxtscrip1_Jsonclick ;
      private String lblTxtscript2_Internalname ;
      private String lblTxtscript2_Caption ;
      private String lblTxtscript2_Jsonclick ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String scmdbuf ;
      private String A5MenXEst ;
      private String sDynURL ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool toggleJsOutput ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n5MenXEst ;
      private bool n258MenPadre ;
      private bool n2MenuXDesc ;
      private bool n40001MenIcono_GXI ;
      private bool n4MenXUrl ;
      private bool n3MenuXPosi ;
      private bool AV23Acceso ;
      private bool GXt_boolean1 ;
      private String AV7vScript ;
      private String AV9vScript11 ;
      private String AV8vScript2 ;
      private String AV5vRuta ;
      private String AV15SesRolId ;
      private String AV18Objeto ;
      private String AV12SesUsuarioId ;
      private String A40000UsuariosIcono_GXI ;
      private String A64UsuariosApMat ;
      private String A65UsuariosApPat ;
      private String A66UsuariosNombre ;
      private String A128RolDescripcion ;
      private String AV13UsuarioFoto ;
      private String AV14UsuarioNombre ;
      private String AV17RolDesc ;
      private String A2MenuXDesc ;
      private String A40001MenIcono_GXI ;
      private String A4MenXUrl ;
      private IGxSession AV10Sesion ;
      private IGxDataStore dsDefault ;
      private GXDataAreaControl Contholder1 ;
      private IDataStoreProvider pr_default ;
      private int[] H00072_A24RolId ;
      private int[] H00072_A11UsuariosId ;
      private String[] H00072_A40000UsuariosIcono_GXI ;
      private String[] H00072_A64UsuariosApMat ;
      private String[] H00072_A65UsuariosApPat ;
      private String[] H00072_A66UsuariosNombre ;
      private String[] H00072_A128RolDescripcion ;
      private short[] H00073_A1MenuXid ;
      private int[] H00073_A24RolId ;
      private String[] H00073_A5MenXEst ;
      private bool[] H00073_n5MenXEst ;
      private short[] H00073_A258MenPadre ;
      private bool[] H00073_n258MenPadre ;
      private String[] H00073_A2MenuXDesc ;
      private bool[] H00073_n2MenuXDesc ;
      private String[] H00073_A40001MenIcono_GXI ;
      private bool[] H00073_n40001MenIcono_GXI ;
      private String[] H00073_A4MenXUrl ;
      private bool[] H00073_n4MenXUrl ;
      private short[] H00073_A3MenuXPosi ;
      private bool[] H00073_n3MenuXPosi ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

   public class masterpagemikb__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00072 ;
          prmH00072 = new Object[] {
          new Object[] {"AV11UsuarioId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmH00073 ;
          prmH00073 = new Object[] {
          new Object[] {"AV16RolId",System.Data.DbType.Int32,9,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H00072", "SELECT T1.`RolId`, T1.`UsuariosId`, T1.`UsuariosIcono_GXI`, T1.`UsuariosApMat`, T1.`UsuariosApPat`, T1.`UsuariosNombre`, T2.`RolDescripcion` FROM (`Usuarios` T1 INNER JOIN `Roles` T2 ON T2.`RolId` = T1.`RolId`) WHERE T1.`UsuariosId` = ? ORDER BY T1.`UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00072,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00073", "SELECT T1.`MenuXid`, T1.`RolId`, T2.`MenXEst`, T2.`MenPadre`, T2.`MenuXDesc`, T2.`MenIcono_GXI`, T2.`MenXUrl`, T2.`MenuXPosi` FROM (`MenuRol` T1 INNER JOIN `Menu` T2 ON T2.`MenuXid` = T1.`MenuXid`) WHERE (T1.`RolId` = ?) AND (T2.`MenXEst` = 'A') ORDER BY T2.`MenuXPosi` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00073,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((String[]) buf[2])[0] = rslt.getMultimediaUri(3) ;
                ((String[]) buf[3])[0] = rslt.getVarchar(4) ;
                ((String[]) buf[4])[0] = rslt.getVarchar(5) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
                ((String[]) buf[6])[0] = rslt.getVarchar(7) ;
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 1) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((String[]) buf[6])[0] = rslt.getVarchar(5) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((String[]) buf[8])[0] = rslt.getMultimediaUri(6) ;
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((String[]) buf[10])[0] = rslt.getVarchar(7) ;
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((short[]) buf[12])[0] = rslt.getShort(8) ;
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
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
                return;
             case 1 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

}
