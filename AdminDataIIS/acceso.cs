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
   public class acceso : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public acceso( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public acceso( IGxContext context )
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
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("masterpagemikbreg", "GeneXus.Programs.masterpagemikbreg", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA0J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0J2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 2036420), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202262714344765", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("SweetAlert2/sweetalert2.all.min.js", "", false, true);
         context.AddJavascriptSource("SweetAlert2/SweetAlert2Render.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle = bodyStyle + " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("acceso.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXBANDEREGRESO", GetSecureSignedToken( "", AV6AuxBAnderegreso, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vALERTPROPERTIES", AV42AlertProperties);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vALERTPROPERTIES", AV42AlertProperties);
         }
         GxWebStd.gx_hidden_field( context, "USUARIOSUSR", A244UsuariosUsr);
         GxWebStd.gx_hidden_field( context, "USUARIOSSTATUS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A286UsuariosStatus), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSVIGFIN", context.localUtil.DToC( A70UsuariosVigFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "USUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ROLID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A24RolId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSNOMBRE", A66UsuariosNombre);
         GxWebStd.gx_hidden_field( context, "USUARIOSAPPAT", A65UsuariosApPat);
         GxWebStd.gx_hidden_field( context, "USUARIOSAPMAT", A64UsuariosApMat);
         GxWebStd.gx_hidden_field( context, "vTIEMPO", context.localUtil.DToC( AV36Tiempo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vFECHAACCES", context.localUtil.TToC( AV15FechaAcces, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vHISTPWDIND", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20HistPwdInd), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSPWD", A68UsuariosPwd);
         GxWebStd.gx_hidden_field( context, "USUARIOSKEY", A67UsuariosKey);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTSECURITY", AV30sdtSecurity);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTSECURITY", AV30sdtSecurity);
         }
         GxWebStd.gx_hidden_field( context, "FECHAINTENTO", context.localUtil.DToC( A30FechaIntento, 0, "/"));
         GxWebStd.gx_hidden_field( context, "CONTADOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(A72Contador), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vCONT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10Cont), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINTENTOSHORABLOQUEO", context.localUtil.TToC( AV21IntentosHoraBloqueo, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vCONTADOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12contador), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "INTENTOSHORABLOQUEO", context.localUtil.TToC( A74IntentosHoraBloqueo, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vPARAMETROMINUTOS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25parametroMinutos), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "BITACCESFEC", context.localUtil.TToC( A61bitAccesFec, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39UsuarioId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "HISPWDFECHA", context.localUtil.TToC( A62HisPwdFecha, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "HISTPWDIND", StringUtil.LTrim( StringUtil.NToC( (decimal)(A73HistPwdInd), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINTENTOSHORABLOQUEOCALCULADO", context.localUtil.TToC( AV22IntentosHoraBloqueoCalculado, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "PARAMETROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29ParametroId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PARAMETROSBLOQUEO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A71ParametrosBloqueo), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vAUXBANDEREGRESO", AV6AuxBAnderegreso);
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXBANDEREGRESO", GetSecureSignedToken( "", AV6AuxBAnderegreso, context));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((String)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
         if ( ! ( WebComp_Notificacion == null ) )
         {
            WebComp_Notificacion.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0J2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("acceso.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "Acceso" ;
      }

      public override String GetPgmdesc( )
      {
         return "Acceso" ;
      }

      protected void WB0J0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "center", "middle", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable7_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "TablaLoguinSC1", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "middle", "", "", "div");
            wb_table1_15_0J2( true) ;
         }
         else
         {
            wb_table1_15_0J2( false) ;
         }
         return  ;
      }

      protected void wb_table1_15_0J2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "middle", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "center", "middle", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0J2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 16_0_11-147071", 0) ;
            }
            Form.Meta.addItem("description", "Acceso", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0J0( ) ;
      }

      protected void WS0J2( )
      {
         START0J2( ) ;
         EVT0J2( ) ;
      }

      protected void EVT0J2( )
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
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E110J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'INGRESAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Ingresar' */
                              E120J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E130J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REGISTRARSE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Registrarse' */
                              E140J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E150J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(NumberUtil.Val( sEvtType, "."));
                        if ( nCmpId == 90 )
                        {
                           OldNotificacion = cgiGet( "W0090");
                           if ( ( StringUtil.Len( OldNotificacion) == 0 ) || ( StringUtil.StrCmp(OldNotificacion, WebComp_Notificacion_Component) != 0 ) )
                           {
                              WebComp_Notificacion = getWebComponent(GetType(), "GeneXus.Programs", OldNotificacion, new Object[] {context} );
                              WebComp_Notificacion.ComponentInit();
                              WebComp_Notificacion.Name = "OldNotificacion";
                              WebComp_Notificacion_Component = OldNotificacion;
                           }
                           if ( StringUtil.Len( WebComp_Notificacion_Component) != 0 )
                           {
                              WebComp_Notificacion.componentprocess("W0090", "", sEvt);
                           }
                           WebComp_Notificacion_Component = OldNotificacion;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0J2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0J2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavUsuario_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         RF0J2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      protected void RF0J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E130J2 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Notificacion_Component) != 0 )
               {
                  WebComp_Notificacion.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E150J2 ();
            WB0J0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0J2( )
      {
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_boolean_hidden_field( context, "vAUXBANDEREGRESO", AV6AuxBAnderegreso);
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXBANDEREGRESO", GetSecureSignedToken( "", AV6AuxBAnderegreso, context));
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      protected void STRUP0J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vALERTPROPERTIES"), AV42AlertProperties);
            /* Read saved values. */
            /* Read variables values. */
            AV38Usuario = StringUtil.Upper( cgiGet( edtavUsuario_Internalname));
            AssignAttri("", false, "AV38Usuario", AV38Usuario);
            AV26Password = cgiGet( edtavPassword_Internalname);
            AssignAttri("", false, "AV26Password", AV26Password);
            AV27Password2 = cgiGet( edtavPassword2_Internalname);
            AssignAttri("", false, "AV27Password2", AV27Password2);
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
         E110J2 ();
         if (returnInSub) return;
      }

      protected void E110J2( )
      {
         /* Start Routine */
         /* Object Property */
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Notificacion_Component), StringUtil.Lower( "Mensaje")) != 0 )
         {
            WebComp_Notificacion = getWebComponent(GetType(), "GeneXus.Programs", "mensaje", new Object[] {context} );
            WebComp_Notificacion.ComponentInit();
            WebComp_Notificacion.Name = "Mensaje";
            WebComp_Notificacion_Component = "Mensaje";
         }
         if ( StringUtil.Len( WebComp_Notificacion_Component) != 0 )
         {
            WebComp_Notificacion.setjustcreated();
            WebComp_Notificacion.componentprepare(new Object[] {(String)"W0090",(String)"",(String)"",(String)"",(String)""});
            WebComp_Notificacion.componentbind(new Object[] {(String)"",(String)"",(String)""});
         }
         lblTextblock3_Caption = "<br/>Universidad Tecnológica de Nezahualcóyotl,<br/>";
         AssignProp("", false, lblTextblock3_Internalname, "Caption", lblTextblock3_Caption, true);
         lblTextblock3_Caption = lblTextblock3_Caption+"Cto. Rey Nezahualcóyotl<br/>";
         AssignProp("", false, lblTextblock3_Internalname, "Caption", lblTextblock3_Caption, true);
         lblTextblock3_Caption = lblTextblock3_Caption+"Benito Juárez, 57000 Nezahualcóyotl, Méx.<br />";
         AssignProp("", false, lblTextblock3_Internalname, "Caption", lblTextblock3_Caption, true);
         imgImage8_Visible = 1;
         AssignProp("", false, imgImage8_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage8_Visible), 5, 0), true);
         edtavPassword2_Visible = 0;
         AssignProp("", false, edtavPassword2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPassword2_Visible), 5, 0), true);
         imgImage5_Visible = 0;
         AssignProp("", false, imgImage5_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage5_Visible), 5, 0), true);
         AV41OK = context.SetCookie( "GX_SESSION_ID", "", "", DateTime.MinValue, "", 0);
      }

      protected void E120J2( )
      {
         /* 'Ingresar' Routine */
         AV49GXLvl17 = 0;
         /* Using cursor H000J2 */
         pr_default.execute(0, new Object[] {AV38Usuario, Gx_date});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK0J3 = false;
            A244UsuariosUsr = H000J2_A244UsuariosUsr[0];
            A286UsuariosStatus = H000J2_A286UsuariosStatus[0];
            A11UsuariosId = H000J2_A11UsuariosId[0];
            n11UsuariosId = H000J2_n11UsuariosId[0];
            A70UsuariosVigFin = H000J2_A70UsuariosVigFin[0];
            n70UsuariosVigFin = H000J2_n70UsuariosVigFin[0];
            A24RolId = H000J2_A24RolId[0];
            A64UsuariosApMat = H000J2_A64UsuariosApMat[0];
            A65UsuariosApPat = H000J2_A65UsuariosApPat[0];
            A66UsuariosNombre = H000J2_A66UsuariosNombre[0];
            A67UsuariosKey = H000J2_A67UsuariosKey[0];
            A68UsuariosPwd = H000J2_A68UsuariosPwd[0];
            AV49GXLvl17 = 1;
            AV39UsuarioId = A11UsuariosId;
            AssignAttri("", false, "AV39UsuarioId", StringUtil.LTrimStr( (decimal)(AV39UsuarioId), 6, 0));
            AV45RolId = A24RolId;
            AV24NombreUsu = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + StringUtil.Trim( A64UsuariosApMat);
            AV35Sesion.Set("NombreUsuario", StringUtil.Trim( AV24NombreUsu));
            /* Execute user subroutine: 'VERIFICABITACCES' */
            S113 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'VERIFICAHISPSW' */
            S123 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV18FechaReal = DateTimeUtil.DAdd(AV36Tiempo,+((int)(120)));
            if ( (DateTime.MinValue==AV15FechaAcces) || ( AV18FechaReal <= Gx_date ) || ( AV20HistPwdInd == 1 ) )
            {
               if ( StringUtil.StrCmp(A68UsuariosPwd, Encrypt64( AV26Password, A67UsuariosKey)) == 0 )
               {
                  GXt_int1 = AV33SecRnd;
                  new gensesnum(context ).execute( ref  AV39UsuarioId, ref  GXt_int1) ;
                  AssignAttri("", false, "AV39UsuarioId", StringUtil.LTrimStr( (decimal)(AV39UsuarioId), 6, 0));
                  AV33SecRnd = (int)(GXt_int1);
                  AV30sdtSecurity.gxTpr_Useridentifier = AV39UsuarioId;
                  AV30sdtSecurity.gxTpr_Securityrandom = AV33SecRnd;
                  AV35Sesion.Set("Security", AV30sdtSecurity.ToXml(false, true, "SdtSecurity", "ADMINDATA1"));
                  AV35Sesion.Set("UsuarioId", StringUtil.Str( (decimal)(AV39UsuarioId), 6, 0));
                  AV35Sesion.Set("RolId", StringUtil.Str( (decimal)(AV45RolId), 9, 0));
                  AV35Sesion.Set("Usuario", StringUtil.Trim( AV38Usuario));
                  AV35Sesion.Set("DesdeMenu", "True");
                  AV35Sesion.Set("AN", "2012");
                  AV35Sesion.Set("MES", "1");
                  AV35Sesion.Set("ANF", "2012");
                  AV35Sesion.Set("MESF", "1");
                  AV31SDTUsuArea.Clear();
                  AV35Sesion.Set("UsuArea", AV31SDTUsuArea.ToJSonString(false));
                  while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(H000J2_A244UsuariosUsr[0], A244UsuariosUsr) == 0 ) )
                  {
                     BRK0J3 = false;
                     A286UsuariosStatus = H000J2_A286UsuariosStatus[0];
                     A11UsuariosId = H000J2_A11UsuariosId[0];
                     n11UsuariosId = H000J2_n11UsuariosId[0];
                     A70UsuariosVigFin = H000J2_A70UsuariosVigFin[0];
                     n70UsuariosVigFin = H000J2_n70UsuariosVigFin[0];
                     A24RolId = H000J2_A24RolId[0];
                     A64UsuariosApMat = H000J2_A64UsuariosApMat[0];
                     A65UsuariosApPat = H000J2_A65UsuariosApPat[0];
                     A66UsuariosNombre = H000J2_A66UsuariosNombre[0];
                     A67UsuariosKey = H000J2_A67UsuariosKey[0];
                     A68UsuariosPwd = H000J2_A68UsuariosPwd[0];
                     if ( A30FechaIntento == Gx_date )
                     {
                        if ( A11UsuariosId == AV39UsuarioId )
                        {
                           AV10Cont = A72Contador;
                           AssignAttri("", false, "AV10Cont", StringUtil.LTrimStr( (decimal)(AV10Cont), 2, 0));
                        }
                     }
                     BRK0J3 = true;
                     pr_default.readNext(0);
                  }
                  if ( AV10Cont == 3 )
                  {
                     new inacusr(context ).execute(  AV39UsuarioId) ;
                     GXt_SdtPropiedades2 = AV42AlertProperties;
                     new getsweetmessage(context ).execute(  "error",  "Verificar Información",  "El usuario no está autorizado, consulte con el Administrador",  true,  false, out  GXt_SdtPropiedades2) ;
                     AV42AlertProperties = GXt_SdtPropiedades2;
                     this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
                  }
                  else
                  {
                     AV10Cont = 0;
                     AssignAttri("", false, "AV10Cont", StringUtil.LTrimStr( (decimal)(AV10Cont), 2, 0));
                     new grabaintentos(context ).execute(  AV39UsuarioId,  AV10Cont) ;
                     CallWebObject(formatLink("cambiopwd.aspx") );
                     context.wjLocDisableFrm = 1;
                  }
               }
               else
               {
                  while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(H000J2_A244UsuariosUsr[0], A244UsuariosUsr) == 0 ) )
                  {
                     BRK0J3 = false;
                     A11UsuariosId = H000J2_A11UsuariosId[0];
                     n11UsuariosId = H000J2_n11UsuariosId[0];
                     if ( A30FechaIntento == Gx_date )
                     {
                        if ( A11UsuariosId == AV39UsuarioId )
                        {
                           AV10Cont = A72Contador;
                           AssignAttri("", false, "AV10Cont", StringUtil.LTrimStr( (decimal)(AV10Cont), 2, 0));
                        }
                     }
                     BRK0J3 = true;
                     pr_default.readNext(0);
                  }
                  if ( AV10Cont == 3 )
                  {
                     new inacusr(context ).execute(  AV39UsuarioId) ;
                     GXt_SdtPropiedades2 = AV42AlertProperties;
                     new getsweetmessage(context ).execute(  "warning",  "",  "El usuario no está autorizado, consulte con el Administrador",  true,  false, out  GXt_SdtPropiedades2) ;
                     AV42AlertProperties = GXt_SdtPropiedades2;
                     this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
                  }
                  else
                  {
                     AV10Cont = (short)(AV10Cont+1);
                     AssignAttri("", false, "AV10Cont", StringUtil.LTrimStr( (decimal)(AV10Cont), 2, 0));
                     new grabaintentos(context ).execute(  AV39UsuarioId,  AV10Cont) ;
                     GXt_SdtPropiedades2 = AV42AlertProperties;
                     new getsweetmessage(context ).execute(  "warning",  "",  "Contraseña / Curp Incorrecta, favor de verIficar",  true,  false, out  GXt_SdtPropiedades2) ;
                     AV42AlertProperties = GXt_SdtPropiedades2;
                     this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
                  }
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A68UsuariosPwd, Encrypt64( AV26Password, A67UsuariosKey)) == 0 ) || ( StringUtil.StrCmp(A68UsuariosPwd, Encrypt64( AV27Password2, A67UsuariosKey)) == 0 ) )
               {
                  GXt_int1 = AV33SecRnd;
                  new gensesnum(context ).execute( ref  AV39UsuarioId, ref  GXt_int1) ;
                  AssignAttri("", false, "AV39UsuarioId", StringUtil.LTrimStr( (decimal)(AV39UsuarioId), 6, 0));
                  AV33SecRnd = (int)(GXt_int1);
                  AV30sdtSecurity.gxTpr_Useridentifier = AV39UsuarioId;
                  AV30sdtSecurity.gxTpr_Securityrandom = AV33SecRnd;
                  AV35Sesion.Set("Security", AV30sdtSecurity.ToXml(false, true, "SdtSecurity", "ADMINDATA1"));
                  AV35Sesion.Set("UsuarioId", StringUtil.Str( (decimal)(AV39UsuarioId), 6, 0));
                  AV35Sesion.Set("RolId", StringUtil.Str( (decimal)(AV45RolId), 9, 0));
                  AV35Sesion.Set("Usuario", StringUtil.Trim( AV38Usuario));
                  AV35Sesion.Set("DesdeMenu", "True");
                  AV31SDTUsuArea.Clear();
                  AV35Sesion.Set("UsuArea", AV31SDTUsuArea.ToJSonString(false));
                  new grababitacceso(context ).execute(  AV39UsuarioId) ;
                  AV10Cont = 0;
                  AssignAttri("", false, "AV10Cont", StringUtil.LTrimStr( (decimal)(AV10Cont), 2, 0));
                  new grabaintentos(context ).execute(  AV39UsuarioId,  AV10Cont) ;
                  new cierramens(context ).execute( ) ;
                  CallWebObject(formatLink("inicio.aspx") );
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  if ( AV10Cont == 3 )
                  {
                     new inacusr(context ).execute(  AV39UsuarioId) ;
                     AV22IntentosHoraBloqueoCalculado = AV21IntentosHoraBloqueo;
                     AssignAttri("", false, "AV22IntentosHoraBloqueoCalculado", context.localUtil.TToC( AV22IntentosHoraBloqueoCalculado, 8, 5, 0, 3, "/", ":", " "));
                     /* Execute user subroutine: 'CICLOFECHA' */
                     S133 ();
                     if ( returnInSub )
                     {
                        pr_default.close(0);
                        returnInSub = true;
                        if (true) return;
                     }
                     if ( ! ( AV21IntentosHoraBloqueo < DateTimeUtil.ServerNow( context, pr_default) ) )
                     {
                        AV23MsjTexto = "El usuario está inactivado, favor de esperar " + StringUtil.Str( (decimal)(AV12contador), 4, 0) + " " + "minutos" + " o consulte con el administrador";
                        GXt_SdtPropiedades2 = AV42AlertProperties;
                        new getsweetmessage(context ).execute(  "error",  "",  AV23MsjTexto,  true,  false, out  GXt_SdtPropiedades2) ;
                        AV42AlertProperties = GXt_SdtPropiedades2;
                        this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
                     }
                  }
                  else
                  {
                     AV10Cont = (short)(AV10Cont+1);
                     AssignAttri("", false, "AV10Cont", StringUtil.LTrimStr( (decimal)(AV10Cont), 2, 0));
                     new grabaintentos(context ).execute(  AV39UsuarioId,  AV10Cont) ;
                     GXt_SdtPropiedades2 = AV42AlertProperties;
                     new getsweetmessage(context ).execute(  "warning",  "",  "Contraseña / Curp Incorrecta, favor de verIficar",  true,  false, out  GXt_SdtPropiedades2) ;
                     AV42AlertProperties = GXt_SdtPropiedades2;
                     this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
                  }
               }
            }
            if ( ! BRK0J3 )
            {
               BRK0J3 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         if ( AV49GXLvl17 == 0 )
         {
            /* Execute user subroutine: 'INACTIVA' */
            S162 ();
            if (returnInSub) return;
            /* Using cursor H000J3 */
            pr_default.execute(1, new Object[] {Gx_date, AV39UsuarioId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A11UsuariosId = H000J3_A11UsuariosId[0];
               n11UsuariosId = H000J3_n11UsuariosId[0];
               A30FechaIntento = H000J3_A30FechaIntento[0];
               A72Contador = H000J3_A72Contador[0];
               A74IntentosHoraBloqueo = H000J3_A74IntentosHoraBloqueo[0];
               n74IntentosHoraBloqueo = H000J3_n74IntentosHoraBloqueo[0];
               AV10Cont = A72Contador;
               AssignAttri("", false, "AV10Cont", StringUtil.LTrimStr( (decimal)(AV10Cont), 2, 0));
               AV16fechaBloqueo = A30FechaIntento;
               AV7BloqueoFechaInicial = A74IntentosHoraBloqueo;
               /* Execute user subroutine: 'PARAMETRO' */
               S146 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
               AV21IntentosHoraBloqueo = A74IntentosHoraBloqueo;
               AssignAttri("", false, "AV21IntentosHoraBloqueo", context.localUtil.TToC( AV21IntentosHoraBloqueo, 8, 5, 0, 3, "/", ":", " "));
               AV21IntentosHoraBloqueo = DateTimeUtil.TAdd( AV21IntentosHoraBloqueo, 60*(AV25parametroMinutos));
               AssignAttri("", false, "AV21IntentosHoraBloqueo", context.localUtil.TToC( AV21IntentosHoraBloqueo, 8, 5, 0, 3, "/", ":", " "));
               AV22IntentosHoraBloqueoCalculado = AV21IntentosHoraBloqueo;
               AssignAttri("", false, "AV22IntentosHoraBloqueoCalculado", context.localUtil.TToC( AV22IntentosHoraBloqueoCalculado, 8, 5, 0, 3, "/", ":", " "));
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( ! ( DateTimeUtil.ServerNow( context, pr_default) > AV21IntentosHoraBloqueo ) )
            {
               /* Execute user subroutine: 'CICLOFECHA' */
               S133 ();
               if (returnInSub) return;
               if ( AV12contador == 1 )
               {
                  AV23MsjTexto = "El usuario está inactivado, favor de esperar " + StringUtil.Str( (decimal)(AV12contador), 4, 0) + " " + "minutos" + " o consulte con el administrador";
                  GXt_SdtPropiedades2 = AV42AlertProperties;
                  new getsweetmessage(context ).execute(  "warning",  "",  AV23MsjTexto,  true,  false, out  GXt_SdtPropiedades2) ;
                  AV42AlertProperties = GXt_SdtPropiedades2;
                  this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
               }
               else
               {
                  AV23MsjTexto = "El usuario está inactivado, favor de esperar " + StringUtil.Str( (decimal)(AV12contador), 4, 0) + " " + "minutos" + " o consulte con el administrador";
                  GXt_SdtPropiedades2 = AV42AlertProperties;
                  new getsweetmessage(context ).execute(  "warning",  "",  AV23MsjTexto,  true,  false, out  GXt_SdtPropiedades2) ;
                  AV42AlertProperties = GXt_SdtPropiedades2;
                  this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
               }
            }
            else
            {
               AV53GXLvl182 = 0;
               /* Using cursor H000J4 */
               pr_default.execute(2, new Object[] {AV38Usuario});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A244UsuariosUsr = H000J4_A244UsuariosUsr[0];
                  A70UsuariosVigFin = H000J4_A70UsuariosVigFin[0];
                  n70UsuariosVigFin = H000J4_n70UsuariosVigFin[0];
                  AV53GXLvl182 = 1;
                  AV5AuxBandera = false;
                  AV40vigencia = DateTimeUtil.ResetTime( A70UsuariosVigFin ) ;
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               if ( AV53GXLvl182 == 0 )
               {
                  AV5AuxBandera = true;
               }
               if ( AV5AuxBandera )
               {
                  GXt_SdtPropiedades2 = AV42AlertProperties;
                  new getsweetmessage(context ).execute(  "warning",  "",  "Contraseña / Curp Incorrecta, favor de verIficar",  true,  false, out  GXt_SdtPropiedades2) ;
                  AV42AlertProperties = GXt_SdtPropiedades2;
                  this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
               }
               else
               {
                  if ( AV40vigencia < DateTimeUtil.ServerNow( context, pr_default) )
                  {
                     GXt_SdtPropiedades2 = AV42AlertProperties;
                     new getsweetmessage(context ).execute(  "error",  "",  "Su vigencia ha expirado, favor de verIficar con el administrador",  true,  false, out  GXt_SdtPropiedades2) ;
                     AV42AlertProperties = GXt_SdtPropiedades2;
                     this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
                  }
                  else
                  {
                     GXt_boolean3 = false;
                     new usuarioactivacionautomatica(context ).execute(  AV39UsuarioId,  AV16fechaBloqueo, out  GXt_boolean3) ;
                     /* Execute user subroutine: 'PRUEBA' */
                     S152 ();
                     if (returnInSub) return;
                  }
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30sdtSecurity", AV30sdtSecurity);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42AlertProperties", AV42AlertProperties);
      }

      protected void S133( )
      {
         /* 'CICLOFECHA' Routine */
         AV19FechaServer = DateTimeUtil.ServerNow( context, pr_default);
         while ( AV19FechaServer <= AV22IntentosHoraBloqueoCalculado )
         {
            AV12contador = (short)(AV12contador+1);
            AssignAttri("", false, "AV12contador", StringUtil.LTrimStr( (decimal)(AV12contador), 4, 0));
            AV19FechaServer = DateTimeUtil.TAdd( AV19FechaServer, 60*(1));
         }
      }

      protected void S162( )
      {
         /* 'INACTIVA' Routine */
         /* Using cursor H000J5 */
         pr_default.execute(3, new Object[] {AV38Usuario});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A244UsuariosUsr = H000J5_A244UsuariosUsr[0];
            A11UsuariosId = H000J5_A11UsuariosId[0];
            n11UsuariosId = H000J5_n11UsuariosId[0];
            A70UsuariosVigFin = H000J5_A70UsuariosVigFin[0];
            n70UsuariosVigFin = H000J5_n70UsuariosVigFin[0];
            AV39UsuarioId = A11UsuariosId;
            AssignAttri("", false, "AV39UsuarioId", StringUtil.LTrimStr( (decimal)(AV39UsuarioId), 6, 0));
            if ( A70UsuariosVigFin <= Gx_date )
            {
               new inacusr(context ).execute(  AV39UsuarioId) ;
            }
            else
            {
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S113( )
      {
         /* 'VERIFICABITACCES' Routine */
         /* Using cursor H000J6 */
         pr_default.execute(4, new Object[] {AV39UsuarioId});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A11UsuariosId = H000J6_A11UsuariosId[0];
            n11UsuariosId = H000J6_n11UsuariosId[0];
            A61bitAccesFec = H000J6_A61bitAccesFec[0];
            AV15FechaAcces = A61bitAccesFec;
            AssignAttri("", false, "AV15FechaAcces", context.localUtil.TToC( AV15FechaAcces, 8, 8, 0, 3, "/", ":", " "));
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S123( )
      {
         /* 'VERIFICAHISPSW' Routine */
         /* Using cursor H000J7 */
         pr_default.execute(5, new Object[] {AV39UsuarioId});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A11UsuariosId = H000J7_A11UsuariosId[0];
            n11UsuariosId = H000J7_n11UsuariosId[0];
            A73HistPwdInd = H000J7_A73HistPwdInd[0];
            A62HisPwdFecha = H000J7_A62HisPwdFecha[0];
            AV17FechaCad = A62HisPwdFecha;
            AV20HistPwdInd = A73HistPwdInd;
            AssignAttri("", false, "AV20HistPwdInd", StringUtil.Str( (decimal)(AV20HistPwdInd), 1, 0));
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(5);
         }
         pr_default.close(5);
         AV36Tiempo = DateTimeUtil.ResetTime(AV17FechaCad);
         AssignAttri("", false, "AV36Tiempo", context.localUtil.Format(AV36Tiempo, "99/99/99"));
      }

      protected void S146( )
      {
         /* 'PARAMETRO' Routine */
         /* Using cursor H000J8 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            A29ParametroId = H000J8_A29ParametroId[0];
            A71ParametrosBloqueo = H000J8_A71ParametrosBloqueo[0];
            n71ParametrosBloqueo = H000J8_n71ParametrosBloqueo[0];
            AV25parametroMinutos = A71ParametrosBloqueo;
            AssignAttri("", false, "AV25parametroMinutos", StringUtil.LTrimStr( (decimal)(AV25parametroMinutos), 4, 0));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(6);
      }

      protected void E130J2( )
      {
         /* Refresh Routine */
         edtavPassword_Visible = 1;
         AssignProp("", false, edtavPassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPassword_Visible), 5, 0), true);
         imgImage4_Visible = 1;
         AssignProp("", false, imgImage4_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage4_Visible), 5, 0), true);
         if ( AV6AuxBAnderegreso )
         {
            /* Execute user subroutine: 'PRUEBA' */
            S152 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30sdtSecurity", AV30sdtSecurity);
      }

      protected void S152( )
      {
         /* 'PRUEBA' Routine */
         /* Using cursor H000J9 */
         pr_default.execute(7, new Object[] {AV38Usuario, Gx_date});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A244UsuariosUsr = H000J9_A244UsuariosUsr[0];
            A286UsuariosStatus = H000J9_A286UsuariosStatus[0];
            A70UsuariosVigFin = H000J9_A70UsuariosVigFin[0];
            n70UsuariosVigFin = H000J9_n70UsuariosVigFin[0];
            A11UsuariosId = H000J9_A11UsuariosId[0];
            n11UsuariosId = H000J9_n11UsuariosId[0];
            A64UsuariosApMat = H000J9_A64UsuariosApMat[0];
            A65UsuariosApPat = H000J9_A65UsuariosApPat[0];
            A66UsuariosNombre = H000J9_A66UsuariosNombre[0];
            A67UsuariosKey = H000J9_A67UsuariosKey[0];
            A68UsuariosPwd = H000J9_A68UsuariosPwd[0];
            AV39UsuarioId = A11UsuariosId;
            AssignAttri("", false, "AV39UsuarioId", StringUtil.LTrimStr( (decimal)(AV39UsuarioId), 6, 0));
            AV24NombreUsu = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + StringUtil.Trim( A64UsuariosApMat);
            AV35Sesion.Set("NombreUsuario", StringUtil.Trim( AV24NombreUsu));
            if ( StringUtil.StrCmp(A68UsuariosPwd, Encrypt64( AV26Password, A67UsuariosKey)) == 0 )
            {
               GXt_int1 = AV33SecRnd;
               new gensesnum(context ).execute( ref  AV39UsuarioId, ref  GXt_int1) ;
               AssignAttri("", false, "AV39UsuarioId", StringUtil.LTrimStr( (decimal)(AV39UsuarioId), 6, 0));
               AV33SecRnd = (int)(GXt_int1);
               AV30sdtSecurity.gxTpr_Useridentifier = AV39UsuarioId;
               AV30sdtSecurity.gxTpr_Securityrandom = AV33SecRnd;
               AV35Sesion.Set("Security", AV30sdtSecurity.ToXml(false, true, "SdtSecurity", "ADMINDATA1"));
               AV35Sesion.Set("UsuarioId", StringUtil.Str( (decimal)(AV39UsuarioId), 6, 0));
               AV35Sesion.Set("Usuario", StringUtil.Trim( AV38Usuario));
               AV35Sesion.Set("DesdeMenu", "True");
               AV35Sesion.Set("AN", "2012");
               AV35Sesion.Set("MES", "1");
               AV35Sesion.Set("ANF", "2012");
               AV35Sesion.Set("MESF", "1");
               AV31SDTUsuArea.Clear();
               AV35Sesion.Set("UsuArea", AV31SDTUsuArea.ToJSonString(false));
               if ( StringUtil.StrCmp(A68UsuariosPwd, Encrypt64( AV26Password, A67UsuariosKey)) == 0 )
               {
                  GXt_int1 = AV33SecRnd;
                  new gensesnum(context ).execute( ref  AV39UsuarioId, ref  GXt_int1) ;
                  AssignAttri("", false, "AV39UsuarioId", StringUtil.LTrimStr( (decimal)(AV39UsuarioId), 6, 0));
                  AV33SecRnd = (int)(GXt_int1);
                  AV30sdtSecurity.gxTpr_Useridentifier = AV39UsuarioId;
                  AV30sdtSecurity.gxTpr_Securityrandom = AV33SecRnd;
                  AV35Sesion.Set("Security", AV30sdtSecurity.ToXml(false, true, "SdtSecurity", "ADMINDATA1"));
                  AV35Sesion.Set("UsuarioId", StringUtil.Str( (decimal)(AV39UsuarioId), 6, 0));
                  AV35Sesion.Set("Usuario", StringUtil.Trim( AV38Usuario));
                  AV35Sesion.Set("DesdeMenu", "True");
                  AV31SDTUsuArea.Clear();
                  AV35Sesion.Set("UsuArea", AV31SDTUsuArea.ToJSonString(false));
                  new grababitacceso(context ).execute(  AV39UsuarioId) ;
                  AV10Cont = 0;
                  AssignAttri("", false, "AV10Cont", StringUtil.LTrimStr( (decimal)(AV10Cont), 2, 0));
                  new grabaintentos(context ).execute(  AV39UsuarioId,  AV10Cont) ;
                  new cierramens(context ).execute( ) ;
                  if ( StringUtil.StrCmp(AV38Usuario, "Admin") == 0 )
                  {
                  }
                  else
                  {
                     CallWebObject(formatLink("inicio.aspx") );
                     context.wjLocDisableFrm = 1;
                  }
               }
               else
               {
                  /* Using cursor H000J10 */
                  pr_default.execute(8, new Object[] {AV39UsuarioId, Gx_date});
                  while ( (pr_default.getStatus(8) != 101) )
                  {
                     A30FechaIntento = H000J10_A30FechaIntento[0];
                     A11UsuariosId = H000J10_A11UsuariosId[0];
                     n11UsuariosId = H000J10_n11UsuariosId[0];
                     A72Contador = H000J10_A72Contador[0];
                     A74IntentosHoraBloqueo = H000J10_A74IntentosHoraBloqueo[0];
                     n74IntentosHoraBloqueo = H000J10_n74IntentosHoraBloqueo[0];
                     AV10Cont = A72Contador;
                     AssignAttri("", false, "AV10Cont", StringUtil.LTrimStr( (decimal)(AV10Cont), 2, 0));
                     AV21IntentosHoraBloqueo = A74IntentosHoraBloqueo;
                     AssignAttri("", false, "AV21IntentosHoraBloqueo", context.localUtil.TToC( AV21IntentosHoraBloqueo, 8, 5, 0, 3, "/", ":", " "));
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(8);
                  if ( AV10Cont == 3 )
                  {
                     new inacusr(context ).execute(  AV39UsuarioId) ;
                     /* Using cursor H000J11 */
                     pr_default.execute(9, new Object[] {AV39UsuarioId, Gx_date});
                     while ( (pr_default.getStatus(9) != 101) )
                     {
                        A30FechaIntento = H000J11_A30FechaIntento[0];
                        A11UsuariosId = H000J11_A11UsuariosId[0];
                        n11UsuariosId = H000J11_n11UsuariosId[0];
                        A72Contador = H000J11_A72Contador[0];
                        A74IntentosHoraBloqueo = H000J11_A74IntentosHoraBloqueo[0];
                        n74IntentosHoraBloqueo = H000J11_n74IntentosHoraBloqueo[0];
                        AV10Cont = A72Contador;
                        AssignAttri("", false, "AV10Cont", StringUtil.LTrimStr( (decimal)(AV10Cont), 2, 0));
                        AV21IntentosHoraBloqueo = A74IntentosHoraBloqueo;
                        AssignAttri("", false, "AV21IntentosHoraBloqueo", context.localUtil.TToC( AV21IntentosHoraBloqueo, 8, 5, 0, 3, "/", ":", " "));
                        /* Execute user subroutine: 'PARAMETRO' */
                        S146 ();
                        if ( returnInSub )
                        {
                           pr_default.close(9);
                           returnInSub = true;
                           if (true) return;
                        }
                        AV21IntentosHoraBloqueo = DateTimeUtil.TAdd( AV21IntentosHoraBloqueo, 60*(AV25parametroMinutos));
                        AssignAttri("", false, "AV21IntentosHoraBloqueo", context.localUtil.TToC( AV21IntentosHoraBloqueo, 8, 5, 0, 3, "/", ":", " "));
                        /* Exiting from a For First loop. */
                        if (true) break;
                     }
                     pr_default.close(9);
                     AV22IntentosHoraBloqueoCalculado = AV21IntentosHoraBloqueo;
                     AssignAttri("", false, "AV22IntentosHoraBloqueoCalculado", context.localUtil.TToC( AV22IntentosHoraBloqueoCalculado, 8, 5, 0, 3, "/", ":", " "));
                     /* Execute user subroutine: 'CICLOFECHA' */
                     S133 ();
                     if ( returnInSub )
                     {
                        pr_default.close(7);
                        returnInSub = true;
                        if (true) return;
                     }
                     if ( ! ( AV21IntentosHoraBloqueo < DateTimeUtil.ServerNow( context, pr_default) ) )
                     {
                        GX_msglist.addItem("El usuario está inactivado, favor de esperar "+AV12contador+" "+"minutos"+" o consulte con el administrador");
                     }
                  }
                  else
                  {
                     AV10Cont = (short)(AV10Cont+1);
                     AssignAttri("", false, "AV10Cont", StringUtil.LTrimStr( (decimal)(AV10Cont), 2, 0));
                     new grabaintentos(context ).execute(  AV39UsuarioId,  AV10Cont) ;
                     GX_msglist.addItem("Contraseña incorrecta, favor de verificar");
                  }
                  if ( StringUtil.StrCmp(AV38Usuario, "Admin") == 0 )
                  {
                  }
                  else
                  {
                     CallWebObject(formatLink("inicio.aspx") );
                     context.wjLocDisableFrm = 1;
                  }
               }
            }
            else
            {
               GX_msglist.addItem("Contraseña incorrecta, favor de verificar");
            }
            pr_default.readNext(7);
         }
         pr_default.close(7);
      }

      protected void E140J2( )
      {
         /* 'Registrarse' Routine */
         AV43ipAddress = AV44httpRequest.RemoteAddress;
         CallWebObject(formatLink("wpaltausuarios.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void nextLoad( )
      {
      }

      protected void E150J2( )
      {
         /* Load Routine */
      }

      protected void wb_table1_15_0J2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable4_Internalname, tblTable4_Internalname, "", "TablaRedondeada", 0, "center", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center;vertical-align:middle")+"\">") ;
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = "(none)";
            GxWebStd.gx_bitmap( context, imgImage6_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Acceso.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center;vertical-align:middle")+"\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Bienvenido a SRC", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:#191970;", "TextBlock1", 0, "", 1, 1, 0, "HLP_Acceso.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center;vertical-align:middle")+"\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Sistema de Reclutamiento y Selección", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:#191970;", "TextBlock1", 0, "", 1, 1, 0, "HLP_Acceso.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center;vertical-align:middle")+"\">") ;
            wb_table2_27_0J2( true) ;
         }
         else
         {
            wb_table2_27_0J2( false) ;
         }
         return  ;
      }

      protected void wb_table2_27_0J2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"left\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-left;text-align:-moz-left;text-align:-webkit-left;vertical-align:middle")+"\">") ;
            wb_table3_76_0J2( true) ;
         }
         else
         {
            wb_table3_76_0J2( false) ;
         }
         return  ;
      }

      protected void wb_table3_76_0J2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"left\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-left;text-align:-moz-left;text-align:-webkit-left;vertical-align:middle")+"\">") ;
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0090"+"", StringUtil.RTrim( WebComp_Notificacion_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0090"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Notificacion_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldNotificacion), StringUtil.Lower( WebComp_Notificacion_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0090"+"");
                  }
                  WebComp_Notificacion.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldNotificacion), StringUtil.Lower( WebComp_Notificacion_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center;vertical-align:middle")+"\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, lblTextblock3_Caption, "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:#191970;", "TextBlock1", 0, "", 1, 1, 1, "HLP_Acceso.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center;vertical-align:middle")+"\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "V. 1.0  R.31052022-2", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:#B30D31;", "TextBlock1", 0, "", 1, 1, 0, "HLP_Acceso.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucUcalertas.SetProperty("Propiedades", AV42AlertProperties);
            ucUcalertas.Render(context, "sweetalert2", Ucalertas_Internalname, "UCALERTASContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_15_0J2e( true) ;
         }
         else
         {
            wb_table1_15_0J2e( false) ;
         }
      }

      protected void wb_table3_76_0J2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable5_Internalname, tblTable5_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"left\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-left;text-align:-moz-left;text-align:-webkit-left;vertical-align:middle")+"\">") ;
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "82bcc6ca-c4b2-412c-8a3a-40cf0a136f64", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 35, "px", 35, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Acceso.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"left\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-left;text-align:-moz-left;text-align:-webkit-left;vertical-align:middle")+"\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Recuperar Contraseña", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160j1_client"+"'", "color:#B30D31;", "TextBlock", 7, "", 1, 1, 0, "HLP_Acceso.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"left\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-left;text-align:-moz-left;text-align:-webkit-left;vertical-align:middle")+"\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "-----", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:#FFFFFF;", "TextBlock", 0, "", 1, 1, 0, "HLP_Acceso.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"left\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-left;text-align:-moz-left;text-align:-webkit-left;vertical-align:middle")+"\">") ;
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "5cf22998-87f9-4e3f-ae0a-b0ef576db9d7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 35, "px", 35, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Acceso.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"left\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-left;text-align:-moz-left;text-align:-webkit-left;vertical-align:middle")+"\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Registrarse", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REGISTRARSE\\'."+"'", "color:#B30D31;", "TextBlock", 5, "", 1, 1, 0, "HLP_Acceso.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_76_0J2e( true) ;
         }
         else
         {
            wb_table3_76_0J2e( false) ;
         }
      }

      protected void wb_table2_27_0J2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable8_Internalname, tblTable8_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table4_30_0J2( true) ;
         }
         else
         {
            wb_table4_30_0J2( false) ;
         }
         return  ;
      }

      protected void wb_table4_30_0J2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "781f8fa8-78ed-4f01-9fd5-c6bf321410c4", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage7_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Acceso.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_27_0J2e( true) ;
         }
         else
         {
            wb_table2_27_0J2e( false) ;
         }
      }

      protected void wb_table4_30_0J2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable6_Internalname, tblTable6_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"left\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-left;text-align:-moz-left;text-align:-webkit-left;vertical-align:middle")+"\">") ;
            wb_table5_33_0J2( true) ;
         }
         else
         {
            wb_table5_33_0J2( false) ;
         }
         return  ;
      }

      protected void wb_table5_33_0J2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_30_0J2e( true) ;
         }
         else
         {
            wb_table4_30_0J2e( false) ;
         }
      }

      protected void wb_table5_33_0J2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable1_Internalname, tblTable1_Internalname, "", "Table", 0, "center", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"center\" colspan=\"2\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center;vertical-align:middle")+"\">") ;
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "1ba33e8a-6455-48d7-9718-dc189dad05b3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Acceso.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage8_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage8_Visible, 1, "", "", 0, 0, 35, "px", 35, "px", 0, 0, 7, imgImage8_Jsonclick, "'"+""+"'"+",false,"+"'"+"e170j1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Acceso.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"center\" colspan=\"2\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center;vertical-align:middle")+"\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "CURP:", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:#000000;", "TextBlock", 0, "", 1, 1, 0, "HLP_Acceso.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"center\" colspan=\"2\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center;vertical-align:middle")+"\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_Internalname, "Usuario", "gx-form-item AtributoLoginLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_Internalname, AV38Usuario, StringUtil.RTrim( context.localUtil.Format( AV38Usuario, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "Ingresar su CURP.", "", edtavUsuario_Jsonclick, 0, "AtributoLogin", "", "", "", "", 1, edtavUsuario_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Acceso.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"center\" colspan=\"2\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center;vertical-align:middle")+"\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "CONTRASEÑA:", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:#000000;", "TextBlock", 0, "", 1, 1, 0, "HLP_Acceso.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"left\" colspan=\"2\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-left;text-align:-moz-left;text-align:-webkit-left;vertical-align:middle")+"\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPassword_Internalname, "Password", "gx-form-item AtributoLoginLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPassword_Internalname, AV26Password, StringUtil.RTrim( context.localUtil.Format( AV26Password, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "Ingresar su Contraseña.", "", edtavPassword_Jsonclick, 0, "AtributoLogin", "", "", "", "", edtavPassword_Visible, edtavPassword_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, -1, 0, 0, 1, 0, -1, true, "", "left", true, "", "HLP_Acceso.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"left\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-left;text-align:-moz-left;text-align:-webkit-left;vertical-align:middle")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "a85f757d-2f26-4c15-bc45-94d8e86b9fd3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage4_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage4_Visible, 1, "", "", 0, 0, 35, "px", 35, "px", 0, 0, 7, imgImage4_Jsonclick, "'"+""+"'"+",false,"+"'"+"e170j1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Acceso.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"left\" colspan=\"2\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-left;text-align:-moz-left;text-align:-webkit-left;vertical-align:middle")+"\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPassword2_Internalname, "Password2", "gx-form-item AtributoLoginLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPassword2_Internalname, AV27Password2, StringUtil.RTrim( context.localUtil.Format( AV27Password2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPassword2_Jsonclick, 0, "AtributoLogin", "", "", "", "", edtavPassword2_Visible, edtavPassword2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Acceso.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"left\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-left;text-align:-moz-left;text-align:-webkit-left;vertical-align:middle")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "4a51798c-b921-480a-afb9-a766d1bdba65", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage5_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage5_Visible, 1, "", "", 0, 0, 35, "px", 35, "px", 0, 0, 7, imgImage5_Jsonclick, "'"+""+"'"+",false,"+"'"+"e180j1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Acceso.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"center\" colspan=\"2\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center;vertical-align:middle")+"\">") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            ClassString = "Acceso1";
            StyleString = "background-color:#E8EAEC;";
            GxWebStd.gx_button_ctrl( context, bttButton1_Internalname, "", "Ingresar", bttButton1_Jsonclick, 5, "Ingresar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'INGRESAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Acceso.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_33_0J2e( true) ;
         }
         else
         {
            wb_table5_33_0J2e( false) ;
         }
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
         PA0J2( ) ;
         WS0J2( ) ;
         WE0J2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( String sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("SweetAlert2/css/font-awesome.min.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Notificacion == null ) )
         {
            if ( StringUtil.Len( WebComp_Notificacion_Component) != 0 )
            {
               WebComp_Notificacion.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714344847", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("acceso.js", "?202262714344847", false, true);
         context.AddJavascriptSource("SweetAlert2/sweetalert2.all.min.js", "", false, true);
         context.AddJavascriptSource("SweetAlert2/SweetAlert2Render.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgImage6_Internalname = "IMAGE6";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         imgImage1_Internalname = "IMAGE1";
         imgImage8_Internalname = "IMAGE8";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtavUsuario_Internalname = "vUSUARIO";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtavPassword_Internalname = "vPASSWORD";
         imgImage4_Internalname = "IMAGE4";
         edtavPassword2_Internalname = "vPASSWORD2";
         imgImage5_Internalname = "IMAGE5";
         bttButton1_Internalname = "BUTTON1";
         tblTable1_Internalname = "TABLE1";
         tblTable6_Internalname = "TABLE6";
         imgImage7_Internalname = "IMAGE7";
         tblTable8_Internalname = "TABLE8";
         imgImage2_Internalname = "IMAGE2";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         imgImage3_Internalname = "IMAGE3";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         tblTable5_Internalname = "TABLE5";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         Ucalertas_Internalname = "UCALERTAS";
         tblTable4_Internalname = "TABLE4";
         divTable3_Internalname = "TABLE3";
         divTable7_Internalname = "TABLE7";
         divTable2_Internalname = "TABLE2";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         imgImage5_Visible = 1;
         edtavPassword2_Jsonclick = "";
         edtavPassword2_Enabled = 1;
         imgImage4_Visible = 1;
         edtavPassword_Jsonclick = "";
         edtavPassword_Enabled = 1;
         edtavUsuario_Jsonclick = "";
         edtavUsuario_Enabled = 1;
         imgImage8_Visible = 1;
         edtavPassword_Visible = 1;
         edtavPassword2_Visible = 1;
         lblTextblock3_Caption = "Text Block";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Acceso";
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A244UsuariosUsr',fld:'USUARIOSUSR',pic:''},{av:'AV38Usuario',fld:'vUSUARIO',pic:'@!'},{av:'A286UsuariosStatus',fld:'USUARIOSSTATUS',pic:'9'},{av:'A70UsuariosVigFin',fld:'USUARIOSVIGFIN',pic:''},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A66UsuariosNombre',fld:'USUARIOSNOMBRE',pic:'@!'},{av:'A65UsuariosApPat',fld:'USUARIOSAPPAT',pic:'@!'},{av:'A64UsuariosApMat',fld:'USUARIOSAPMAT',pic:'@!'},{av:'A68UsuariosPwd',fld:'USUARIOSPWD',pic:''},{av:'AV26Password',fld:'vPASSWORD',pic:''},{av:'A67UsuariosKey',fld:'USUARIOSKEY',pic:''},{av:'AV30sdtSecurity',fld:'vSDTSECURITY',pic:''},{av:'A30FechaIntento',fld:'FECHAINTENTO',pic:''},{av:'A72Contador',fld:'CONTADOR',pic:'9'},{av:'A74IntentosHoraBloqueo',fld:'INTENTOSHORABLOQUEO',pic:'99/99/99 99:99'},{av:'AV25parametroMinutos',fld:'vPARAMETROMINUTOS',pic:'ZZZ9'},{av:'AV12contador',fld:'vCONTADOR',pic:'ZZZ9'},{av:'A29ParametroId',fld:'PARAMETROID',pic:'ZZZZZZZZ9'},{av:'A71ParametrosBloqueo',fld:'PARAMETROSBLOQUEO',pic:'ZZZ9'},{av:'AV22IntentosHoraBloqueoCalculado',fld:'vINTENTOSHORABLOQUEOCALCULADO',pic:'99/99/99 99:99'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'AV6AuxBAnderegreso',fld:'vAUXBANDEREGRESO',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'edtavPassword_Visible',ctrl:'vPASSWORD',prop:'Visible'},{av:'imgImage4_Visible',ctrl:'IMAGE4',prop:'Visible'},{av:'AV39UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZ9'},{av:'AV30sdtSecurity',fld:'vSDTSECURITY',pic:''},{av:'AV21IntentosHoraBloqueo',fld:'vINTENTOSHORABLOQUEO',pic:'99/99/99 99:99'},{av:'AV22IntentosHoraBloqueoCalculado',fld:'vINTENTOSHORABLOQUEOCALCULADO',pic:'99/99/99 99:99'},{av:'AV10Cont',fld:'vCONT',pic:'Z9'},{av:'AV25parametroMinutos',fld:'vPARAMETROMINUTOS',pic:'ZZZ9'},{av:'AV12contador',fld:'vCONTADOR',pic:'ZZZ9'}]}");
         setEventMetadata("'INGRESAR'","{handler:'E120J2',iparms:[{av:'A244UsuariosUsr',fld:'USUARIOSUSR',pic:''},{av:'AV38Usuario',fld:'vUSUARIO',pic:'@!'},{av:'A286UsuariosStatus',fld:'USUARIOSSTATUS',pic:'9'},{av:'A70UsuariosVigFin',fld:'USUARIOSVIGFIN',pic:''},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A24RolId',fld:'ROLID',pic:'ZZZZZZZZ9'},{av:'A66UsuariosNombre',fld:'USUARIOSNOMBRE',pic:'@!'},{av:'A65UsuariosApPat',fld:'USUARIOSAPPAT',pic:'@!'},{av:'A64UsuariosApMat',fld:'USUARIOSAPMAT',pic:'@!'},{av:'AV36Tiempo',fld:'vTIEMPO',pic:''},{av:'AV15FechaAcces',fld:'vFECHAACCES',pic:'99/99/99 99:99:99'},{av:'AV20HistPwdInd',fld:'vHISTPWDIND',pic:'9'},{av:'A68UsuariosPwd',fld:'USUARIOSPWD',pic:''},{av:'AV26Password',fld:'vPASSWORD',pic:''},{av:'A67UsuariosKey',fld:'USUARIOSKEY',pic:''},{av:'AV30sdtSecurity',fld:'vSDTSECURITY',pic:''},{av:'A30FechaIntento',fld:'FECHAINTENTO',pic:''},{av:'A72Contador',fld:'CONTADOR',pic:'9'},{av:'AV27Password2',fld:'vPASSWORD2',pic:''},{av:'AV10Cont',fld:'vCONT',pic:'Z9'},{av:'AV21IntentosHoraBloqueo',fld:'vINTENTOSHORABLOQUEO',pic:'99/99/99 99:99'},{av:'AV12contador',fld:'vCONTADOR',pic:'ZZZ9'},{av:'A74IntentosHoraBloqueo',fld:'INTENTOSHORABLOQUEO',pic:'99/99/99 99:99'},{av:'AV25parametroMinutos',fld:'vPARAMETROMINUTOS',pic:'ZZZ9'},{av:'A61bitAccesFec',fld:'BITACCESFEC',pic:'99/99/99 99:99:99'},{av:'AV39UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZ9'},{av:'A62HisPwdFecha',fld:'HISPWDFECHA',pic:'99/99/9999 99:99:99'},{av:'A73HistPwdInd',fld:'HISTPWDIND',pic:'9'},{av:'AV22IntentosHoraBloqueoCalculado',fld:'vINTENTOSHORABLOQUEOCALCULADO',pic:'99/99/99 99:99'},{av:'A29ParametroId',fld:'PARAMETROID',pic:'ZZZZZZZZ9'},{av:'A71ParametrosBloqueo',fld:'PARAMETROSBLOQUEO',pic:'ZZZ9'}]");
         setEventMetadata("'INGRESAR'",",oparms:[{av:'AV39UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZ9'},{av:'AV30sdtSecurity',fld:'vSDTSECURITY',pic:''},{av:'AV42AlertProperties',fld:'vALERTPROPERTIES',pic:''},{av:'AV10Cont',fld:'vCONT',pic:'Z9'},{av:'AV22IntentosHoraBloqueoCalculado',fld:'vINTENTOSHORABLOQUEOCALCULADO',pic:'99/99/99 99:99'},{av:'AV21IntentosHoraBloqueo',fld:'vINTENTOSHORABLOQUEO',pic:'99/99/99 99:99'},{av:'AV15FechaAcces',fld:'vFECHAACCES',pic:'99/99/99 99:99:99'},{av:'AV20HistPwdInd',fld:'vHISTPWDIND',pic:'9'},{av:'AV36Tiempo',fld:'vTIEMPO',pic:''},{av:'AV12contador',fld:'vCONTADOR',pic:'ZZZ9'},{av:'AV25parametroMinutos',fld:'vPARAMETROMINUTOS',pic:'ZZZ9'}]}");
         setEventMetadata("'DESBLOQUEAPASS'","{handler:'E170J1',iparms:[{av:'AV26Password',fld:'vPASSWORD',pic:''}]");
         setEventMetadata("'DESBLOQUEAPASS'",",oparms:[{av:'AV27Password2',fld:'vPASSWORD2',pic:''},{av:'edtavPassword2_Visible',ctrl:'vPASSWORD2',prop:'Visible'},{av:'imgImage5_Visible',ctrl:'IMAGE5',prop:'Visible'},{av:'edtavPassword_Visible',ctrl:'vPASSWORD',prop:'Visible'},{av:'imgImage4_Visible',ctrl:'IMAGE4',prop:'Visible'}]}");
         setEventMetadata("'BLOQUEAPASS'","{handler:'E180J1',iparms:[{av:'AV27Password2',fld:'vPASSWORD2',pic:''}]");
         setEventMetadata("'BLOQUEAPASS'",",oparms:[{av:'AV26Password',fld:'vPASSWORD',pic:''},{av:'edtavPassword2_Visible',ctrl:'vPASSWORD2',prop:'Visible'},{av:'imgImage5_Visible',ctrl:'IMAGE5',prop:'Visible'},{av:'edtavPassword_Visible',ctrl:'vPASSWORD',prop:'Visible'},{av:'imgImage4_Visible',ctrl:'IMAGE4',prop:'Visible'}]}");
         setEventMetadata("'REGISTRARSE'","{handler:'E140J2',iparms:[]");
         setEventMetadata("'REGISTRARSE'",",oparms:[]}");
         setEventMetadata("'RECCONTRASEñA'","{handler:'E160J1',iparms:[]");
         setEventMetadata("'RECCONTRASEñA'",",oparms:[]}");
         setEventMetadata("VALIDV_USUARIO","{handler:'Validv_Usuario',iparms:[]");
         setEventMetadata("VALIDV_USUARIO",",oparms:[]}");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gx_date = DateTime.MinValue;
         GXKey = "";
         AV42AlertProperties = new SdtPropiedades(context);
         A244UsuariosUsr = "";
         A70UsuariosVigFin = DateTime.MinValue;
         A66UsuariosNombre = "";
         A65UsuariosApPat = "";
         A64UsuariosApMat = "";
         AV36Tiempo = DateTime.MinValue;
         AV15FechaAcces = (DateTime)(DateTime.MinValue);
         A68UsuariosPwd = "";
         A67UsuariosKey = "";
         AV30sdtSecurity = new SdtSdtSecurity(context);
         A30FechaIntento = DateTime.MinValue;
         AV21IntentosHoraBloqueo = (DateTime)(DateTime.MinValue);
         A74IntentosHoraBloqueo = (DateTime)(DateTime.MinValue);
         A61bitAccesFec = (DateTime)(DateTime.MinValue);
         A62HisPwdFecha = (DateTime)(DateTime.MinValue);
         AV22IntentosHoraBloqueoCalculado = (DateTime)(DateTime.MinValue);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         OldNotificacion = "";
         WebComp_Notificacion_Component = "";
         AV38Usuario = "";
         AV26Password = "";
         AV27Password2 = "";
         scmdbuf = "";
         H000J2_A244UsuariosUsr = new String[] {""} ;
         H000J2_A286UsuariosStatus = new short[1] ;
         H000J2_A11UsuariosId = new int[1] ;
         H000J2_n11UsuariosId = new bool[] {false} ;
         H000J2_A70UsuariosVigFin = new DateTime[] {DateTime.MinValue} ;
         H000J2_n70UsuariosVigFin = new bool[] {false} ;
         H000J2_A24RolId = new int[1] ;
         H000J2_A64UsuariosApMat = new String[] {""} ;
         H000J2_A65UsuariosApPat = new String[] {""} ;
         H000J2_A66UsuariosNombre = new String[] {""} ;
         H000J2_A67UsuariosKey = new String[] {""} ;
         H000J2_A68UsuariosPwd = new String[] {""} ;
         AV24NombreUsu = "";
         AV35Sesion = context.GetSession();
         AV18FechaReal = DateTime.MinValue;
         AV31SDTUsuArea = new GXBaseCollection<SdtSDTUsuArea_SDTUsuAreaItem>( context, "SDTUsuAreaItem", "ADMINDATA1");
         AV23MsjTexto = "";
         H000J3_A11UsuariosId = new int[1] ;
         H000J3_n11UsuariosId = new bool[] {false} ;
         H000J3_A30FechaIntento = new DateTime[] {DateTime.MinValue} ;
         H000J3_A72Contador = new short[1] ;
         H000J3_A74IntentosHoraBloqueo = new DateTime[] {DateTime.MinValue} ;
         H000J3_n74IntentosHoraBloqueo = new bool[] {false} ;
         AV16fechaBloqueo = DateTime.MinValue;
         AV7BloqueoFechaInicial = (DateTime)(DateTime.MinValue);
         H000J4_A11UsuariosId = new int[1] ;
         H000J4_n11UsuariosId = new bool[] {false} ;
         H000J4_A244UsuariosUsr = new String[] {""} ;
         H000J4_A70UsuariosVigFin = new DateTime[] {DateTime.MinValue} ;
         H000J4_n70UsuariosVigFin = new bool[] {false} ;
         AV40vigencia = (DateTime)(DateTime.MinValue);
         GXt_SdtPropiedades2 = new SdtPropiedades(context);
         AV19FechaServer = (DateTime)(DateTime.MinValue);
         H000J5_A244UsuariosUsr = new String[] {""} ;
         H000J5_A11UsuariosId = new int[1] ;
         H000J5_n11UsuariosId = new bool[] {false} ;
         H000J5_A70UsuariosVigFin = new DateTime[] {DateTime.MinValue} ;
         H000J5_n70UsuariosVigFin = new bool[] {false} ;
         H000J6_A75bitAccesIp = new String[] {""} ;
         H000J6_A11UsuariosId = new int[1] ;
         H000J6_n11UsuariosId = new bool[] {false} ;
         H000J6_A61bitAccesFec = new DateTime[] {DateTime.MinValue} ;
         H000J7_A11UsuariosId = new int[1] ;
         H000J7_n11UsuariosId = new bool[] {false} ;
         H000J7_A73HistPwdInd = new short[1] ;
         H000J7_A62HisPwdFecha = new DateTime[] {DateTime.MinValue} ;
         AV17FechaCad = (DateTime)(DateTime.MinValue);
         H000J8_A29ParametroId = new int[1] ;
         H000J8_A71ParametrosBloqueo = new short[1] ;
         H000J8_n71ParametrosBloqueo = new bool[] {false} ;
         H000J9_A244UsuariosUsr = new String[] {""} ;
         H000J9_A286UsuariosStatus = new short[1] ;
         H000J9_A70UsuariosVigFin = new DateTime[] {DateTime.MinValue} ;
         H000J9_n70UsuariosVigFin = new bool[] {false} ;
         H000J9_A11UsuariosId = new int[1] ;
         H000J9_n11UsuariosId = new bool[] {false} ;
         H000J9_A64UsuariosApMat = new String[] {""} ;
         H000J9_A65UsuariosApPat = new String[] {""} ;
         H000J9_A66UsuariosNombre = new String[] {""} ;
         H000J9_A67UsuariosKey = new String[] {""} ;
         H000J9_A68UsuariosPwd = new String[] {""} ;
         H000J10_A30FechaIntento = new DateTime[] {DateTime.MinValue} ;
         H000J10_A11UsuariosId = new int[1] ;
         H000J10_n11UsuariosId = new bool[] {false} ;
         H000J10_A72Contador = new short[1] ;
         H000J10_A74IntentosHoraBloqueo = new DateTime[] {DateTime.MinValue} ;
         H000J10_n74IntentosHoraBloqueo = new bool[] {false} ;
         H000J11_A30FechaIntento = new DateTime[] {DateTime.MinValue} ;
         H000J11_A11UsuariosId = new int[1] ;
         H000J11_n11UsuariosId = new bool[] {false} ;
         H000J11_A72Contador = new short[1] ;
         H000J11_A74IntentosHoraBloqueo = new DateTime[] {DateTime.MinValue} ;
         H000J11_n74IntentosHoraBloqueo = new bool[] {false} ;
         AV43ipAddress = "";
         AV44httpRequest = new GxHttpRequest( context);
         sStyleString = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         ucUcalertas = new GXUserControl();
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         TempTags = "";
         imgImage8_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         imgImage4_Jsonclick = "";
         imgImage5_Jsonclick = "";
         bttButton1_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.acceso__default(),
            new Object[][] {
                new Object[] {
               H000J2_A244UsuariosUsr, H000J2_A286UsuariosStatus, H000J2_A11UsuariosId, H000J2_A70UsuariosVigFin, H000J2_n70UsuariosVigFin, H000J2_A24RolId, H000J2_A64UsuariosApMat, H000J2_A65UsuariosApPat, H000J2_A66UsuariosNombre, H000J2_A67UsuariosKey,
               H000J2_A68UsuariosPwd
               }
               , new Object[] {
               H000J3_A11UsuariosId, H000J3_A30FechaIntento, H000J3_A72Contador, H000J3_A74IntentosHoraBloqueo, H000J3_n74IntentosHoraBloqueo
               }
               , new Object[] {
               H000J4_A11UsuariosId, H000J4_A244UsuariosUsr, H000J4_A70UsuariosVigFin, H000J4_n70UsuariosVigFin
               }
               , new Object[] {
               H000J5_A244UsuariosUsr, H000J5_A11UsuariosId, H000J5_A70UsuariosVigFin, H000J5_n70UsuariosVigFin
               }
               , new Object[] {
               H000J6_A75bitAccesIp, H000J6_A11UsuariosId, H000J6_n11UsuariosId, H000J6_A61bitAccesFec
               }
               , new Object[] {
               H000J7_A11UsuariosId, H000J7_A73HistPwdInd, H000J7_A62HisPwdFecha
               }
               , new Object[] {
               H000J8_A29ParametroId, H000J8_A71ParametrosBloqueo, H000J8_n71ParametrosBloqueo
               }
               , new Object[] {
               H000J9_A244UsuariosUsr, H000J9_A286UsuariosStatus, H000J9_A70UsuariosVigFin, H000J9_n70UsuariosVigFin, H000J9_A11UsuariosId, H000J9_A64UsuariosApMat, H000J9_A65UsuariosApPat, H000J9_A66UsuariosNombre, H000J9_A67UsuariosKey, H000J9_A68UsuariosPwd
               }
               , new Object[] {
               H000J10_A30FechaIntento, H000J10_A11UsuariosId, H000J10_A72Contador, H000J10_A74IntentosHoraBloqueo, H000J10_n74IntentosHoraBloqueo
               }
               , new Object[] {
               H000J11_A30FechaIntento, H000J11_A11UsuariosId, H000J11_A72Contador, H000J11_A74IntentosHoraBloqueo, H000J11_n74IntentosHoraBloqueo
               }
            }
         );
         WebComp_Notificacion = new GeneXus.Http.GXNullWebComponent();
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short nRcdExists_12 ;
      private short nIsMod_12 ;
      private short nRcdExists_14 ;
      private short nIsMod_14 ;
      private short nRcdExists_13 ;
      private short nIsMod_13 ;
      private short nRcdExists_11 ;
      private short nIsMod_11 ;
      private short nRcdExists_10 ;
      private short nIsMod_10 ;
      private short nRcdExists_9 ;
      private short nIsMod_9 ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short A286UsuariosStatus ;
      private short AV20HistPwdInd ;
      private short A72Contador ;
      private short AV10Cont ;
      private short AV12contador ;
      private short AV25parametroMinutos ;
      private short A73HistPwdInd ;
      private short A71ParametrosBloqueo ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV41OK ;
      private short AV49GXLvl17 ;
      private short AV53GXLvl182 ;
      private short nGXWrapped ;
      private int A11UsuariosId ;
      private int A24RolId ;
      private int AV39UsuarioId ;
      private int A29ParametroId ;
      private int imgImage8_Visible ;
      private int edtavPassword2_Visible ;
      private int imgImage5_Visible ;
      private int AV45RolId ;
      private int AV33SecRnd ;
      private int edtavPassword_Visible ;
      private int imgImage4_Visible ;
      private int edtavUsuario_Enabled ;
      private int edtavPassword_Enabled ;
      private int edtavPassword2_Enabled ;
      private int idxLst ;
      private long GXt_int1 ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String divTable2_Internalname ;
      private String divTable7_Internalname ;
      private String divTable3_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String OldNotificacion ;
      private String WebComp_Notificacion_Component ;
      private String edtavUsuario_Internalname ;
      private String edtavPassword_Internalname ;
      private String edtavPassword2_Internalname ;
      private String lblTextblock3_Caption ;
      private String lblTextblock3_Internalname ;
      private String imgImage8_Internalname ;
      private String imgImage5_Internalname ;
      private String scmdbuf ;
      private String AV24NombreUsu ;
      private String imgImage4_Internalname ;
      private String sStyleString ;
      private String tblTable4_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String sImgUrl ;
      private String imgImage6_Internalname ;
      private String lblTextblock5_Internalname ;
      private String lblTextblock5_Jsonclick ;
      private String lblTextblock7_Internalname ;
      private String lblTextblock7_Jsonclick ;
      private String lblTextblock3_Jsonclick ;
      private String lblTextblock6_Internalname ;
      private String lblTextblock6_Jsonclick ;
      private String Ucalertas_Internalname ;
      private String tblTable5_Internalname ;
      private String imgImage2_Internalname ;
      private String lblTextblock8_Internalname ;
      private String lblTextblock8_Jsonclick ;
      private String lblTextblock9_Internalname ;
      private String lblTextblock9_Jsonclick ;
      private String imgImage3_Internalname ;
      private String lblTextblock4_Internalname ;
      private String lblTextblock4_Jsonclick ;
      private String tblTable8_Internalname ;
      private String imgImage7_Internalname ;
      private String tblTable6_Internalname ;
      private String tblTable1_Internalname ;
      private String imgImage1_Internalname ;
      private String TempTags ;
      private String imgImage8_Jsonclick ;
      private String lblTextblock1_Internalname ;
      private String lblTextblock1_Jsonclick ;
      private String edtavUsuario_Jsonclick ;
      private String lblTextblock2_Internalname ;
      private String lblTextblock2_Jsonclick ;
      private String edtavPassword_Jsonclick ;
      private String imgImage4_Jsonclick ;
      private String edtavPassword2_Jsonclick ;
      private String imgImage5_Jsonclick ;
      private String bttButton1_Internalname ;
      private String bttButton1_Jsonclick ;
      private DateTime AV15FechaAcces ;
      private DateTime AV21IntentosHoraBloqueo ;
      private DateTime A74IntentosHoraBloqueo ;
      private DateTime A61bitAccesFec ;
      private DateTime A62HisPwdFecha ;
      private DateTime AV22IntentosHoraBloqueoCalculado ;
      private DateTime AV7BloqueoFechaInicial ;
      private DateTime AV40vigencia ;
      private DateTime AV19FechaServer ;
      private DateTime AV17FechaCad ;
      private DateTime Gx_date ;
      private DateTime A70UsuariosVigFin ;
      private DateTime AV36Tiempo ;
      private DateTime A30FechaIntento ;
      private DateTime AV18FechaReal ;
      private DateTime AV16fechaBloqueo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV6AuxBAnderegreso ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool BRK0J3 ;
      private bool n11UsuariosId ;
      private bool n70UsuariosVigFin ;
      private bool n74IntentosHoraBloqueo ;
      private bool AV5AuxBandera ;
      private bool GXt_boolean3 ;
      private bool n71ParametrosBloqueo ;
      private String A244UsuariosUsr ;
      private String A66UsuariosNombre ;
      private String A65UsuariosApPat ;
      private String A64UsuariosApMat ;
      private String A68UsuariosPwd ;
      private String A67UsuariosKey ;
      private String AV38Usuario ;
      private String AV26Password ;
      private String AV27Password2 ;
      private String AV23MsjTexto ;
      private String AV43ipAddress ;
      private GXWebComponent WebComp_Notificacion ;
      private GXUserControl ucUcalertas ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private String[] H000J2_A244UsuariosUsr ;
      private short[] H000J2_A286UsuariosStatus ;
      private int[] H000J2_A11UsuariosId ;
      private bool[] H000J2_n11UsuariosId ;
      private DateTime[] H000J2_A70UsuariosVigFin ;
      private bool[] H000J2_n70UsuariosVigFin ;
      private int[] H000J2_A24RolId ;
      private String[] H000J2_A64UsuariosApMat ;
      private String[] H000J2_A65UsuariosApPat ;
      private String[] H000J2_A66UsuariosNombre ;
      private String[] H000J2_A67UsuariosKey ;
      private String[] H000J2_A68UsuariosPwd ;
      private int[] H000J3_A11UsuariosId ;
      private bool[] H000J3_n11UsuariosId ;
      private DateTime[] H000J3_A30FechaIntento ;
      private short[] H000J3_A72Contador ;
      private DateTime[] H000J3_A74IntentosHoraBloqueo ;
      private bool[] H000J3_n74IntentosHoraBloqueo ;
      private int[] H000J4_A11UsuariosId ;
      private bool[] H000J4_n11UsuariosId ;
      private String[] H000J4_A244UsuariosUsr ;
      private DateTime[] H000J4_A70UsuariosVigFin ;
      private bool[] H000J4_n70UsuariosVigFin ;
      private String[] H000J5_A244UsuariosUsr ;
      private int[] H000J5_A11UsuariosId ;
      private bool[] H000J5_n11UsuariosId ;
      private DateTime[] H000J5_A70UsuariosVigFin ;
      private bool[] H000J5_n70UsuariosVigFin ;
      private String[] H000J6_A75bitAccesIp ;
      private int[] H000J6_A11UsuariosId ;
      private bool[] H000J6_n11UsuariosId ;
      private DateTime[] H000J6_A61bitAccesFec ;
      private int[] H000J7_A11UsuariosId ;
      private bool[] H000J7_n11UsuariosId ;
      private short[] H000J7_A73HistPwdInd ;
      private DateTime[] H000J7_A62HisPwdFecha ;
      private int[] H000J8_A29ParametroId ;
      private short[] H000J8_A71ParametrosBloqueo ;
      private bool[] H000J8_n71ParametrosBloqueo ;
      private String[] H000J9_A244UsuariosUsr ;
      private short[] H000J9_A286UsuariosStatus ;
      private DateTime[] H000J9_A70UsuariosVigFin ;
      private bool[] H000J9_n70UsuariosVigFin ;
      private int[] H000J9_A11UsuariosId ;
      private bool[] H000J9_n11UsuariosId ;
      private String[] H000J9_A64UsuariosApMat ;
      private String[] H000J9_A65UsuariosApPat ;
      private String[] H000J9_A66UsuariosNombre ;
      private String[] H000J9_A67UsuariosKey ;
      private String[] H000J9_A68UsuariosPwd ;
      private DateTime[] H000J10_A30FechaIntento ;
      private int[] H000J10_A11UsuariosId ;
      private bool[] H000J10_n11UsuariosId ;
      private short[] H000J10_A72Contador ;
      private DateTime[] H000J10_A74IntentosHoraBloqueo ;
      private bool[] H000J10_n74IntentosHoraBloqueo ;
      private DateTime[] H000J11_A30FechaIntento ;
      private int[] H000J11_A11UsuariosId ;
      private bool[] H000J11_n11UsuariosId ;
      private short[] H000J11_A72Contador ;
      private DateTime[] H000J11_A74IntentosHoraBloqueo ;
      private bool[] H000J11_n74IntentosHoraBloqueo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV44httpRequest ;
      private IGxSession AV35Sesion ;
      private GXBaseCollection<SdtSDTUsuArea_SDTUsuAreaItem> AV31SDTUsuArea ;
      private GXWebForm Form ;
      private SdtSdtSecurity AV30sdtSecurity ;
      private SdtPropiedades AV42AlertProperties ;
      private SdtPropiedades GXt_SdtPropiedades2 ;
   }

   public class acceso__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000J2 ;
          prmH000J2 = new Object[] {
          new Object[] {"AV38Usuario",System.Data.DbType.String,18,0} ,
          new Object[] {"Gx_date",System.Data.DbType.Date,8,0}
          } ;
          Object[] prmH000J3 ;
          prmH000J3 = new Object[] {
          new Object[] {"Gx_date",System.Data.DbType.Date,8,0} ,
          new Object[] {"AV39UsuarioId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmH000J4 ;
          prmH000J4 = new Object[] {
          new Object[] {"AV38Usuario",System.Data.DbType.String,18,0}
          } ;
          Object[] prmH000J5 ;
          prmH000J5 = new Object[] {
          new Object[] {"AV38Usuario",System.Data.DbType.String,18,0}
          } ;
          Object[] prmH000J6 ;
          prmH000J6 = new Object[] {
          new Object[] {"AV39UsuarioId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmH000J7 ;
          prmH000J7 = new Object[] {
          new Object[] {"AV39UsuarioId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmH000J8 ;
          prmH000J8 = new Object[] {
          } ;
          Object[] prmH000J9 ;
          prmH000J9 = new Object[] {
          new Object[] {"AV38Usuario",System.Data.DbType.String,18,0} ,
          new Object[] {"Gx_date",System.Data.DbType.Date,8,0}
          } ;
          Object[] prmH000J10 ;
          prmH000J10 = new Object[] {
          new Object[] {"AV39UsuarioId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"Gx_date",System.Data.DbType.Date,8,0}
          } ;
          Object[] prmH000J11 ;
          prmH000J11 = new Object[] {
          new Object[] {"AV39UsuarioId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"Gx_date",System.Data.DbType.Date,8,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H000J2", "SELECT `UsuariosUsr`, `UsuariosStatus`, `UsuariosId`, `UsuariosVigFin`, `RolId`, `UsuariosApMat`, `UsuariosApPat`, `UsuariosNombre`, `UsuariosKey`, `UsuariosPwd` FROM `Usuarios` WHERE (`UsuariosUsr` = ?) AND (`UsuariosVigFin` > ?) AND (`UsuariosStatus` = 1) ORDER BY `UsuariosUsr` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000J2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000J3", "SELECT `UsuariosId`, `FechaIntento`, `Contador`, `IntentosHoraBloqueo` FROM `Intentos` WHERE (`FechaIntento` = ? or `FechaIntento` <= UTC_TIMESTAMP()) AND (`UsuariosId` = ?) ORDER BY `FechaIntento` DESC  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000J3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H000J4", "SELECT `UsuariosId`, `UsuariosUsr`, `UsuariosVigFin` FROM `Usuarios` WHERE `UsuariosUsr` = ? ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000J4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000J5", "SELECT `UsuariosUsr`, `UsuariosId`, `UsuariosVigFin` FROM `Usuarios` WHERE `UsuariosUsr` = ? ORDER BY `UsuariosUsr` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000J5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000J6", "SELECT `bitAccesIp`, `UsuariosId`, `bitAccesFec` FROM `bitAcces` WHERE `UsuariosId` = ? ORDER BY `UsuariosId`, `bitAccesFec` DESC  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000J6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H000J7", "SELECT `UsuariosId`, `HistPwdInd`, `HisPwdFecha` FROM `HistPwd` WHERE `UsuariosId` = ? ORDER BY `UsuariosId`, `HisPwdFecha` DESC  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000J7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H000J8", "SELECT `ParametroId`, `ParametrosBloqueo` FROM `Parametros` WHERE `ParametroId` = 214 ORDER BY `ParametroId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000J8,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H000J9", "SELECT `UsuariosUsr`, `UsuariosStatus`, `UsuariosVigFin`, `UsuariosId`, `UsuariosApMat`, `UsuariosApPat`, `UsuariosNombre`, `UsuariosKey`, `UsuariosPwd` FROM `Usuarios` WHERE (`UsuariosUsr` = ?) AND (`UsuariosVigFin` > ?) AND (`UsuariosStatus` = 1) ORDER BY `UsuariosUsr` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000J9,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000J10", "SELECT `FechaIntento`, `UsuariosId`, `Contador`, `IntentosHoraBloqueo` FROM `Intentos` WHERE `UsuariosId` = ? and `FechaIntento` = ? ORDER BY `UsuariosId`, `FechaIntento` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000J10,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H000J11", "SELECT `FechaIntento`, `UsuariosId`, `Contador`, `IntentosHoraBloqueo` FROM `Intentos` WHERE `UsuariosId` = ? and `FechaIntento` = ? ORDER BY `UsuariosId`, `FechaIntento` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000J11,1, GxCacheFrequency.OFF ,true,true )
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
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5) ;
                ((String[]) buf[6])[0] = rslt.getVarchar(6) ;
                ((String[]) buf[7])[0] = rslt.getVarchar(7) ;
                ((String[]) buf[8])[0] = rslt.getVarchar(8) ;
                ((String[]) buf[9])[0] = rslt.getVarchar(9) ;
                ((String[]) buf[10])[0] = rslt.getVarchar(10) ;
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
             case 3 :
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
             case 4 :
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3) ;
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3) ;
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 7 :
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(5) ;
                ((String[]) buf[6])[0] = rslt.getVarchar(6) ;
                ((String[]) buf[7])[0] = rslt.getVarchar(7) ;
                ((String[]) buf[8])[0] = rslt.getVarchar(8) ;
                ((String[]) buf[9])[0] = rslt.getVarchar(9) ;
                return;
             case 8 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
             case 9 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
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
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (DateTime)parms[1]);
                return;
             case 1 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
             case 2 :
                stmt.SetParameter(1, (String)parms[0]);
                return;
             case 3 :
                stmt.SetParameter(1, (String)parms[0]);
                return;
             case 4 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 5 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 7 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (DateTime)parms[1]);
                return;
             case 8 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (DateTime)parms[1]);
                return;
             case 9 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (DateTime)parms[1]);
                return;
       }
    }

 }

}
