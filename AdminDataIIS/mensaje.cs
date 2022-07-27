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
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class mensaje : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public mensaje( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (String)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("Carmine");
         }
      }

      public mensaje( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( String aP0_Mensaje ,
                           String aP1_Clase ,
                           String aP2_Titulo )
      {
         this.AV6Mensaje = aP0_Mensaje;
         this.AV5Clase = aP1_Clase;
         this.AV7Titulo = aP2_Titulo;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( String sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (String)(sPrefix)) == 0 )
         {
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetNextPar( );
                  sSFPrefix = GetNextPar( );
                  AV6Mensaje = GetNextPar( );
                  AssignAttri(sPrefix, false, "AV6Mensaje", AV6Mensaje);
                  AV5Clase = GetNextPar( );
                  AssignAttri(sPrefix, false, "AV5Clase", AV5Clase);
                  AV7Titulo = GetNextPar( );
                  AssignAttri(sPrefix, false, "AV7Titulo", AV7Titulo);
                  setjustcreated();
                  componentprepare(new Object[] {(String)sCompPrefix,(String)sSFPrefix,(String)AV6Mensaje,(String)AV5Clase,(String)AV7Titulo});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
               if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
               {
                  AV6Mensaje = gxfirstwebparm;
                  AssignAttri(sPrefix, false, "AV6Mensaje", AV6Mensaje);
                  if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                  {
                     AV5Clase = GetNextPar( );
                     AssignAttri(sPrefix, false, "AV5Clase", AV5Clase);
                     AV7Titulo = GetNextPar( );
                     AssignAttri(sPrefix, false, "AV7Titulo", AV7Titulo);
                  }
               }
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA0L2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               lblTxtnotificacion_Visible = 0;
               AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTxtnotificacion_Visible), 5, 0), true);
               WS0L2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     WE0L2( ) ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, false);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Mensaje") ;
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
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 2036420), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202262714341935", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("mensaje.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV6Mensaje)) + "," + UrlEncode(StringUtil.RTrim(AV5Clase)) + "," + UrlEncode(StringUtil.RTrim(AV7Titulo))+"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "Form", true);
            }
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( ) ;
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6Mensaje", wcpOAV6Mensaje);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV5Clase", wcpOAV5Clase);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7Titulo", wcpOAV7Titulo);
         GxWebStd.gx_hidden_field( context, sPrefix+"vMENSAJE", AV6Mensaje);
         GxWebStd.gx_hidden_field( context, sPrefix+"vCLASE", AV5Clase);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTITULO", AV7Titulo);
      }

      protected void RenderHtmlCloseForm0L2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            context.AddJavascriptSource("mensaje.js", "?202262714341937", false, true);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
            SendComponentObjects();
            SendServerCommands();
            SendState();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            include_jscripts( ) ;
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override String GetPgmname( )
      {
         return "Mensaje" ;
      }

      public override String GetPgmdesc( )
      {
         return "Mensaje" ;
      }

      protected void WB0L0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "mensaje.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtnotificacion_Internalname, lblTxtnotificacion_Caption, "", "", lblTxtnotificacion_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", lblTxtnotificacion_Visible, 1, 1, "HLP_Mensaje.htm");
         }
         wbLoad = true;
      }

      protected void START0L2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus C# 16_0_11-147071", 0) ;
               }
               Form.Meta.addItem("description", "Mensaje", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP0L0( ) ;
            }
         }
      }

      protected void WS0L2( )
      {
         START0L2( ) ;
         EVT0L2( ) ;
      }

      protected void EVT0L2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E110L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E120L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0L2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0L2( ) ;
            }
         }
      }

      protected void PA0L2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
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
         RF0L2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         lblTxtnotificacion_Visible = 0;
         AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTxtnotificacion_Visible), 5, 0), true);
      }

      protected void RF0L2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E120L2 ();
            WB0L0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0L2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         lblTxtnotificacion_Visible = 0;
         AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTxtnotificacion_Visible), 5, 0), true);
      }

      protected void STRUP0L0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110L2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV6Mensaje = cgiGet( sPrefix+"wcpOAV6Mensaje");
            wcpOAV5Clase = cgiGet( sPrefix+"wcpOAV5Clase");
            wcpOAV7Titulo = cgiGet( sPrefix+"wcpOAV7Titulo");
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
         E110L2 ();
         if (returnInSub) return;
      }

      protected void E110L2( )
      {
         /* Start Routine */
         if ( StringUtil.StrCmp(AV5Clase, "success") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"$(document).ready(function() { "+"$.ambiance({message: '"+AV6Mensaje+"',"+"title: '"+AV7Titulo+"',"+"type: '"+AV5Clase+"'});"+"return false;});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "verificado") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"$(document).ready(function() { "+"$.ambiance({message: '"+AV6Mensaje+"',"+"title: '"+AV7Titulo+"',"+"type: '"+AV5Clase+"'});"+"return false;});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "warning") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"$(document).ready(function() { "+"$.ambiance({message: '"+AV6Mensaje+"',"+"title: '"+AV7Titulo+"',"+"type: '"+AV5Clase+"'});"+"return false;});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "error") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"$(document).ready(function() { "+"$.ambiance({message: '"+AV6Mensaje+"',"+"title: '"+AV7Titulo+"',"+"type: '"+AV5Clase+"',"+"fade: false });"+"return false;});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "finalizado") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"swal({"+"title:'Registro Exitoso',"+"text:'El Usuario ha sido Registrado Exitosamente.Se le enviara un mensaje de texto con su contraseña de acceso',"+"html: true,"+"confirmButtonColor: 'green',"+"type: 'success'"+"},"+"function(){"+"window.location.href='acceso'"+"});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "enviada") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"swal({"+"title:'Solicitud Enviada',"+"text:'La Solicitud a sido Enviada Exitosamenten.Se le enviara un mensaje de texto con la confirmación de su cita.En la cual se le informará de la Hora y Turno Disponible.',"+"html: true,"+"confirmButtonColor: 'green',"+"type: 'success'"+"});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "noenviada") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"swal({"+"title:'Solicitud en Proceso',"+"text:'La Solicitud no ha sido enviada y se encuentra en proceso.',"+"html: true,"+"confirmButtonColor: 'yellow',"+"type: 'warning'"+"});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "recuperada") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"swal({"+"title:'Contraseña Enviada',"+"text:'La contraseña ha sido enviada exitosamente al teléfono asociado a su CURP.',"+"html: true,"+"confirmButtonColor: 'green',"+"type: 'success'"+"},"+"function(){"+"window.location.href='acceso'"+"});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "noregistrado") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"swal({"+"title:'No Encontrado',"+"text:'Usted no se encuentra registrado.Favor de Registrarse',"+"html: true,"+"confirmButtonColor: 'red',"+"type: 'error'"+"});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "registrasolicituderror") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"swal({"+"title:'Verificar',"+"text:'Usted ya realizo una cita el dia de hoy.Solo puede realizar una solicitud de cita por dia.',"+"html: true,"+"confirmButtonColor: 'gray',"+"type: 'warning'"+"});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "sinexpediente") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"swal({"+"title:'No Registrado',"+"text:'Usted no se encuentra registrado en el Establecieminto Seleccionado.Debera acudir a la Unidad Médica para la generación de su Expediente Clinico.',"+"html: true,"+"confirmButtonColor: 'red',"+"type: 'error'"+"});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "actualizatelefono") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"swal({"+"title:'Actualización Exitosa',"+"text:'El Teléfono ha sido Actualizado Exitosamente.',"+"html: true,"+"confirmButtonColor: 'green',"+"type: 'success'"+"});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "sinacceso") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"swal({"+"title:'Sin Acceso',"+"text:'Usted no cuenta con los permisos necesarios para obtener esta información.',"+"html: true,"+"confirmButtonColor: 'red',"+"type: 'error'"+"});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "sinaccesosiss") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"swal({"+"title:'Verificar',"+"text:'El Sistema de Seguridad Social (SISS) no se encuentra disponible.',"+"html: true,"+"confirmButtonColor: 'gray',"+"type: 'warning'"+"});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "pacientenoencontrdo") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"swal({"+"title:'Verificar',"+"text:'EL DH PRESENTA INCONSISTENCIA  FAVOR.DE LLAMAR A DIGASBISO.SI ES MILITAR DEBERÁ DE LLAMAR A DIGACOPER  CON LA FINALIDAD DE VERIFICAR LA SITUACIÓN.',"+"html: true,"+"confirmButtonColor: 'gray',"+"type: 'warning'"+"});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "usuarioinactivo") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"swal({"+"title:'Verificar',"+"text:'"+AV6Mensaje+"',"+"html: true,"+"confirmButtonColor: 'gray',"+"type: 'warning'"+"});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "CitaTelefonica") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"swal({"+"title:'Telefonica',"+"text:'"+AV6Mensaje+"',"+"html: true,"+"confirmButtonColor: 'gray',"+"type: 'warning'"+"});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "enfermeromsj") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"swal({"+"title:'',"+"text:'"+AV6Mensaje+"',"+"imageUrl:'../static/Resources/Spanish/usuario.png',"+"imageSize:'50x50',"+"html: true,"+"confirmButtonColor: 'green'"+"});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "consultaexitosa") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"swal({"+"title:'Éxito',"+"text:'La Consulta ha Sido Generada Exitosamente',"+"html: true,"+"confirmButtonColor: 'green',"+"type: 'success'"+"});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "cerrarconsulta") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"swal({"+"title:'Esta Seguro',"+"text:'"+AV6Mensaje+"',"+"type: 'warning',"+"html: true,"+"showCancelButton: true,"+"confirmButtonColor: '#DD6B55',"+"confirmButtonText: 'Cerrar Consulta',"+"cancelButtonText: 'Cancelar',"+"closeOnConfirm: true,"+"closeOnCancel: true"+"},"+"function(isConfirm){"+"if(isConfirm){"+"document.getElementById('vCIERRA').value = '1';"+"document.getElementById('vCIERRA').focus();"+"document.getElementById('vOTRA').focus();"+"}else{"+"}"+"});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "diagnosticocronico") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"swal({"+"title:'Éxito',"+"text:'Su registro ha sido guardado exitosamente.\\nFavor de Continuar con su Trajeta de Control del Paciente',"+"html: true,"+"confirmButtonColor: 'green',"+"type: 'success'"+"});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "cerrarsesion") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"swal({"+"title:'Esta Seguro',"+"text:'"+AV6Mensaje+"',"+"type: 'warning',"+"html: true,"+"showCancelButton: true,"+"confirmButtonColor: '#DD6B55',"+"cancelButtonText: 'Regresar',"+"confirmButtonText: 'Cerrar',"+"},"+"function(isConfirm){"+"if(isConfirm){"+"window.location.href='asalir'"+"}else{"+"window.location.href='listaconsultas'"+"}"+"});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "exito") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"swal({"+"title: '"+AV7Titulo+"',"+"text: '"+AV6Mensaje+" ',"+"html: true,"+"confirmButtonColor: 'green',"+"type: 'success'"+"});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "fail") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"swal({"+"title: '"+AV7Titulo+"',"+"text: '"+AV6Mensaje+" ',"+"html: true,"+"confirmButtonColor: 'red',"+"type: 'error'"+"});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV5Clase, "WarningPro") == 0 )
         {
            lblTxtnotificacion_Caption = "<script> "+"swal({"+"title: '"+AV7Titulo+"',"+"text: '"+AV6Mensaje+" ',"+"html: true,"+"confirmButtonColor: '#F8BC86',"+"type: 'warning'"+"});"+"</script>";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
         else
         {
            lblTxtnotificacion_Caption = "";
            AssignProp(sPrefix, false, lblTxtnotificacion_Internalname, "Caption", lblTxtnotificacion_Caption, true);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E120L2( )
      {
         /* Load Routine */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6Mensaje = (String)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV6Mensaje", AV6Mensaje);
         AV5Clase = (String)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV5Clase", AV5Clase);
         AV7Titulo = (String)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV7Titulo", AV7Titulo);
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
         PA0L2( ) ;
         WS0L2( ) ;
         WE0L2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( String sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV6Mensaje = (String)((String)getParm(obj,0));
         sCtrlAV5Clase = (String)((String)getParm(obj,1));
         sCtrlAV7Titulo = (String)((String)getParm(obj,2));
      }

      public override void componentrestorestate( String sPPrefix ,
                                                  String sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0L2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (String)getParm(obj,0);
         sSFPrefix = (String)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "mensaje", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0L2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6Mensaje = (String)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV6Mensaje", AV6Mensaje);
            AV5Clase = (String)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV5Clase", AV5Clase);
            AV7Titulo = (String)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV7Titulo", AV7Titulo);
         }
         wcpOAV6Mensaje = cgiGet( sPrefix+"wcpOAV6Mensaje");
         wcpOAV5Clase = cgiGet( sPrefix+"wcpOAV5Clase");
         wcpOAV7Titulo = cgiGet( sPrefix+"wcpOAV7Titulo");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV6Mensaje, wcpOAV6Mensaje) != 0 ) || ( StringUtil.StrCmp(AV5Clase, wcpOAV5Clase) != 0 ) || ( StringUtil.StrCmp(AV7Titulo, wcpOAV7Titulo) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV6Mensaje = AV6Mensaje;
         wcpOAV5Clase = AV5Clase;
         wcpOAV7Titulo = AV7Titulo;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6Mensaje = cgiGet( sPrefix+"AV6Mensaje_CTRL");
         if ( StringUtil.Len( sCtrlAV6Mensaje) > 0 )
         {
            AV6Mensaje = cgiGet( sCtrlAV6Mensaje);
            AssignAttri(sPrefix, false, "AV6Mensaje", AV6Mensaje);
         }
         else
         {
            AV6Mensaje = cgiGet( sPrefix+"AV6Mensaje_PARM");
         }
         sCtrlAV5Clase = cgiGet( sPrefix+"AV5Clase_CTRL");
         if ( StringUtil.Len( sCtrlAV5Clase) > 0 )
         {
            AV5Clase = cgiGet( sCtrlAV5Clase);
            AssignAttri(sPrefix, false, "AV5Clase", AV5Clase);
         }
         else
         {
            AV5Clase = cgiGet( sPrefix+"AV5Clase_PARM");
         }
         sCtrlAV7Titulo = cgiGet( sPrefix+"AV7Titulo_CTRL");
         if ( StringUtil.Len( sCtrlAV7Titulo) > 0 )
         {
            AV7Titulo = cgiGet( sCtrlAV7Titulo);
            AssignAttri(sPrefix, false, "AV7Titulo", AV7Titulo);
         }
         else
         {
            AV7Titulo = cgiGet( sPrefix+"AV7Titulo_PARM");
         }
      }

      public override void componentprocess( String sPPrefix ,
                                             String sPSFPrefix ,
                                             String sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA0L2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0L2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS0L2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6Mensaje_PARM", AV6Mensaje);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6Mensaje)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6Mensaje_CTRL", StringUtil.RTrim( sCtrlAV6Mensaje));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV5Clase_PARM", AV5Clase);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV5Clase)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV5Clase_CTRL", StringUtil.RTrim( sCtrlAV5Clase));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7Titulo_PARM", AV7Titulo);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7Titulo)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7Titulo_CTRL", StringUtil.RTrim( sCtrlAV7Titulo));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE0L2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override String getstring( String sGXControl )
      {
         String sCtrlName ;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714341960", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("mensaje.js", "?202262714341960", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTxtnotificacion_Internalname = sPrefix+"TXTNOTIFICACION";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("Carmine");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         lblTxtnotificacion_Caption = "Text Block";
         lblTxtnotificacion_Visible = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
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
         wcpOAV6Mensaje = "";
         wcpOAV5Clase = "";
         wcpOAV7Titulo = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         lblTxtnotificacion_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6Mensaje = "";
         sCtrlAV5Clase = "";
         sCtrlAV7Titulo = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
         lblTxtnotificacion_Visible = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private int lblTxtnotificacion_Visible ;
      private int idxLst ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sPrefix ;
      private String sCompPrefix ;
      private String sSFPrefix ;
      private String lblTxtnotificacion_Internalname ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String lblTxtnotificacion_Caption ;
      private String lblTxtnotificacion_Jsonclick ;
      private String sXEvt ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String sCtrlAV6Mensaje ;
      private String sCtrlAV5Clase ;
      private String sCtrlAV7Titulo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private String AV6Mensaje ;
      private String AV5Clase ;
      private String AV7Titulo ;
      private String wcpOAV6Mensaje ;
      private String wcpOAV5Clase ;
      private String wcpOAV7Titulo ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
