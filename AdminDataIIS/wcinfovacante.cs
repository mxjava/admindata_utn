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
   public class wcinfovacante : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public wcinfovacante( )
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

      public wcinfovacante( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_UsuariosId ,
                           int aP1_Vacantes_Id )
      {
         this.AV5UsuariosId = aP0_UsuariosId;
         this.AV6Vacantes_Id = aP1_Vacantes_Id;
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
                  AV5UsuariosId = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri(sPrefix, false, "AV5UsuariosId", StringUtil.LTrimStr( (decimal)(AV5UsuariosId), 6, 0));
                  AV6Vacantes_Id = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri(sPrefix, false, "AV6Vacantes_Id", StringUtil.LTrimStr( (decimal)(AV6Vacantes_Id), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(String)sCompPrefix,(String)sSFPrefix,(int)AV5UsuariosId,(int)AV6Vacantes_Id});
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
            PA3B2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               edtavVacantesusuariosfechad_Enabled = 0;
               AssignProp(sPrefix, false, edtavVacantesusuariosfechad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosfechad_Enabled), 5, 0), true);
               edtavVacantesusuariosmotd_Enabled = 0;
               AssignProp(sPrefix, false, edtavVacantesusuariosmotd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosmotd_Enabled), 5, 0), true);
               WS3B2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
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
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
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
            context.SendWebValue( "wc Info Vacante") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714341282", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("SweetAlert2/sweetalert2.all.min.js", "", false, true);
         context.AddJavascriptSource("SweetAlert2/SweetAlert2Render.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wcinfovacante.aspx"+UrlEncode("" +AV5UsuariosId) + "," + UrlEncode("" +AV6Vacantes_Id);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wcinfovacante.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
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
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vALERTPROPERTIES", AV16AlertProperties);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vALERTPROPERTIES", AV16AlertProperties);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV5UsuariosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV5UsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6Vacantes_Id", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV6Vacantes_Id), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5UsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vVACANTES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6Vacantes_Id), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRUTAGUARDADA", AV18RutaGuardada);
      }

      protected void RenderHtmlCloseForm3B2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            context.AddJavascriptSource("wcinfovacante.js", "?202262714341285", false, true);
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
            context.WriteHtmlTextNl( "</form>") ;
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
         return "wcInfoVacante" ;
      }

      public override String GetPgmdesc( )
      {
         return "wc Info Vacante" ;
      }

      protected void WB3B0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wcinfovacante.aspx");
               context.AddJavascriptSource("SweetAlert2/sweetalert2.all.min.js", "", false, true);
               context.AddJavascriptSource("SweetAlert2/SweetAlert2Render.js", "", false, true);
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_6_3B2( true) ;
         }
         else
         {
            wb_table1_6_3B2( false) ;
         }
         return  ;
      }

      protected void wb_table1_6_3B2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucUcalertas.SetProperty("Propiedades", AV16AlertProperties);
            ucUcalertas.Render(context, "sweetalert2", Ucalertas_Internalname, sPrefix+"UCALERTASContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START3B2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus C# 16_0_11-147071", 0) ;
               }
               Form.Meta.addItem("description", "wc Info Vacante", 0) ;
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
               STRUP3B0( ) ;
            }
         }
      }

      protected void WS3B2( )
      {
         START3B2( ) ;
         EVT3B2( ) ;
      }

      protected void EVT3B2( )
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
                                 STRUP3B0( ) ;
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
                                 STRUP3B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E113B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "IMAGE3.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E123B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "IMAGE4.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E133B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "IMAGE5.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E143B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "IMAGE6.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E153B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "IMAGE7.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E163B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "IMAGE8.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E173B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "IMAGE9.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E183B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "IMAGE10.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E193B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "IMAGE11.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E203B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E213B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3B0( ) ;
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
                                 STRUP3B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavVacantesusuariosfechad_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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

      protected void WE3B2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3B2( ) ;
            }
         }
      }

      protected void PA3B2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            if ( StringUtil.Len( sPrefix) == 0 )
            {
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
               if ( ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
               {
                  GXDecQS = Decrypt64( context.GetRequestQueryString( ), GXKey);
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wcinfovacante.aspx")), "wcinfovacante.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wcinfovacante.aspx")))) ;
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
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetNextPar( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
                     }
                     if ( context.isSpaRequest( ) )
                     {
                        enableJsOutput();
                     }
                  }
               }
            }
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
               GX_FocusControl = edtavVacantesusuariosfechad_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         RF3B2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavVacantesusuariosfechad_Enabled = 0;
         AssignProp(sPrefix, false, edtavVacantesusuariosfechad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosfechad_Enabled), 5, 0), true);
         edtavVacantesusuariosmotd_Enabled = 0;
         AssignProp(sPrefix, false, edtavVacantesusuariosmotd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosmotd_Enabled), 5, 0), true);
      }

      protected void RF3B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E213B2 ();
            WB3B0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3B2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavVacantesusuariosfechad_Enabled = 0;
         AssignProp(sPrefix, false, edtavVacantesusuariosfechad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosfechad_Enabled), 5, 0), true);
         edtavVacantesusuariosmotd_Enabled = 0;
         AssignProp(sPrefix, false, edtavVacantesusuariosmotd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosmotd_Enabled), 5, 0), true);
      }

      protected void STRUP3B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E113B2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vALERTPROPERTIES"), AV16AlertProperties);
            /* Read saved values. */
            wcpOAV5UsuariosId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV5UsuariosId"), ",", "."));
            wcpOAV6Vacantes_Id = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6Vacantes_Id"), ",", "."));
            /* Read variables values. */
            AV7PrefiltroSi = cgiGet( imgavPrefiltrosi_Internalname);
            AV8CurriculumVitaeSi = cgiGet( imgavCurriculumvitaesi_Internalname);
            AV9ExamenTecninoSi = cgiGet( imgavExamentecninosi_Internalname);
            AV10AvConfSi = cgiGet( imgavAvconfsi_Internalname);
            AV11AvPrivSi = cgiGet( imgavAvprivsi_Internalname);
            AV12BusWebSi = cgiGet( imgavBuswebsi_Internalname);
            AV13ReferenciaSi = cgiGet( imgavReferenciasi_Internalname);
            AV14ExmPsiSi = cgiGet( imgavExmpsisi_Internalname);
            AV15CVRecSi = cgiGet( imgavCvrecsi_Internalname);
            if ( context.localUtil.VCDateTime( cgiGet( edtavVacantesusuariosfechad_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Descarte"}), 1, "vVACANTESUSUARIOSFECHAD");
               GX_FocusControl = edtavVacantesusuariosfechad_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV20VacantesUsuariosFechaD = (DateTime)(DateTime.MinValue);
               AssignAttri(sPrefix, false, "AV20VacantesUsuariosFechaD", context.localUtil.TToC( AV20VacantesUsuariosFechaD, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV20VacantesUsuariosFechaD = context.localUtil.CToT( cgiGet( edtavVacantesusuariosfechad_Internalname));
               AssignAttri(sPrefix, false, "AV20VacantesUsuariosFechaD", context.localUtil.TToC( AV20VacantesUsuariosFechaD, 8, 5, 0, 3, "/", ":", " "));
            }
            AV21VacantesUsuariosMotD = cgiGet( edtavVacantesusuariosmotd_Internalname);
            AssignAttri(sPrefix, false, "AV21VacantesUsuariosMotD", AV21VacantesUsuariosMotD);
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
         E113B2 ();
         if (returnInSub) return;
      }

      protected void E113B2( )
      {
         /* Start Routine */
         /* Using cursor H003B2 */
         pr_default.execute(0, new Object[] {AV6Vacantes_Id, AV5UsuariosId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11UsuariosId = H003B2_A11UsuariosId[0];
            A263Vacantes_Id = H003B2_A263Vacantes_Id[0];
            A292VacantesUsuariosCV = H003B2_A292VacantesUsuariosCV[0];
            n292VacantesUsuariosCV = H003B2_n292VacantesUsuariosCV[0];
            A291VacantesUsuariosPrefiltro = H003B2_A291VacantesUsuariosPrefiltro[0];
            n291VacantesUsuariosPrefiltro = H003B2_n291VacantesUsuariosPrefiltro[0];
            A290VacantesUsuariosEstatus = H003B2_A290VacantesUsuariosEstatus[0];
            n290VacantesUsuariosEstatus = H003B2_n290VacantesUsuariosEstatus[0];
            A289VacantesUsuariosFechaD = H003B2_A289VacantesUsuariosFechaD[0];
            n289VacantesUsuariosFechaD = H003B2_n289VacantesUsuariosFechaD[0];
            A294VacantesUsuariosMotD = H003B2_A294VacantesUsuariosMotD[0];
            n294VacantesUsuariosMotD = H003B2_n294VacantesUsuariosMotD[0];
            A293VacantesUsuariosExTec = H003B2_A293VacantesUsuariosExTec[0];
            n293VacantesUsuariosExTec = H003B2_n293VacantesUsuariosExTec[0];
            A304VacantesUsuariosAvConf = H003B2_A304VacantesUsuariosAvConf[0];
            n304VacantesUsuariosAvConf = H003B2_n304VacantesUsuariosAvConf[0];
            A303VacantesUsuariosAvPriv = H003B2_A303VacantesUsuariosAvPriv[0];
            n303VacantesUsuariosAvPriv = H003B2_n303VacantesUsuariosAvPriv[0];
            A302VacantesUsuariosBusWeb = H003B2_A302VacantesUsuariosBusWeb[0];
            n302VacantesUsuariosBusWeb = H003B2_n302VacantesUsuariosBusWeb[0];
            A300VacantesUsuariosRefLab = H003B2_A300VacantesUsuariosRefLab[0];
            n300VacantesUsuariosRefLab = H003B2_n300VacantesUsuariosRefLab[0];
            A301VacantesUsuariosExPsi = H003B2_A301VacantesUsuariosExPsi[0];
            n301VacantesUsuariosExPsi = H003B2_n301VacantesUsuariosExPsi[0];
            A299VacantesUsuariosCVRec = H003B2_A299VacantesUsuariosCVRec[0];
            n299VacantesUsuariosCVRec = H003B2_n299VacantesUsuariosCVRec[0];
            if ( ( A291VacantesUsuariosPrefiltro == 0 ) || ( A292VacantesUsuariosCV == 0 ) )
            {
               GXt_SdtPropiedades1 = AV16AlertProperties;
               new getsweetmessage(context ).execute(  "warning",  "Aun no se realiza ningun movimiento",  "",  true,  false, out  GXt_SdtPropiedades1) ;
               AV16AlertProperties = GXt_SdtPropiedades1;
               this.executeUsercontrolMethod(sPrefix, false, "UCALERTASContainer", "showAlert", "", new Object[] {});
            }
            if ( A290VacantesUsuariosEstatus == 5 )
            {
               edtavVacantesusuariosfechad_Visible = 1;
               AssignProp(sPrefix, false, edtavVacantesusuariosfechad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosfechad_Visible), 5, 0), true);
               edtavVacantesusuariosmotd_Visible = 1;
               AssignProp(sPrefix, false, edtavVacantesusuariosmotd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosmotd_Visible), 5, 0), true);
               AV20VacantesUsuariosFechaD = A289VacantesUsuariosFechaD;
               AssignAttri(sPrefix, false, "AV20VacantesUsuariosFechaD", context.localUtil.TToC( AV20VacantesUsuariosFechaD, 8, 5, 0, 3, "/", ":", " "));
               AV21VacantesUsuariosMotD = A294VacantesUsuariosMotD;
               AssignAttri(sPrefix, false, "AV21VacantesUsuariosMotD", AV21VacantesUsuariosMotD);
            }
            else
            {
               edtavVacantesusuariosfechad_Visible = 0;
               AssignProp(sPrefix, false, edtavVacantesusuariosfechad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosfechad_Visible), 5, 0), true);
               edtavVacantesusuariosmotd_Visible = 0;
               AssignProp(sPrefix, false, edtavVacantesusuariosmotd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosmotd_Visible), 5, 0), true);
               lblMotivo_descarte_Visible = 0;
               AssignProp(sPrefix, false, lblMotivo_descarte_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblMotivo_descarte_Visible), 5, 0), true);
               lblDescartado_Visible = 0;
               AssignProp(sPrefix, false, lblDescartado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblDescartado_Visible), 5, 0), true);
            }
            if ( A291VacantesUsuariosPrefiltro == 1 )
            {
               AV7PrefiltroSi = context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( ));
               AssignProp(sPrefix, false, imgavPrefiltrosi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV7PrefiltroSi)) ? AV25Prefiltrosi_GXI : context.convertURL( context.PathToRelativeUrl( AV7PrefiltroSi))), true);
               AssignProp(sPrefix, false, imgavPrefiltrosi_Internalname, "SrcSet", context.GetImageSrcSet( AV7PrefiltroSi), true);
               AV25Prefiltrosi_GXI = GXDbFile.PathToUrl( context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( )));
               AssignProp(sPrefix, false, imgavPrefiltrosi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV7PrefiltroSi)) ? AV25Prefiltrosi_GXI : context.convertURL( context.PathToRelativeUrl( AV7PrefiltroSi))), true);
               AssignProp(sPrefix, false, imgavPrefiltrosi_Internalname, "SrcSet", context.GetImageSrcSet( AV7PrefiltroSi), true);
               imgImage3_Visible = 1;
               AssignProp(sPrefix, false, imgImage3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage3_Visible), 5, 0), true);
            }
            else
            {
               AV7PrefiltroSi = context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( ));
               AssignProp(sPrefix, false, imgavPrefiltrosi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV7PrefiltroSi)) ? AV25Prefiltrosi_GXI : context.convertURL( context.PathToRelativeUrl( AV7PrefiltroSi))), true);
               AssignProp(sPrefix, false, imgavPrefiltrosi_Internalname, "SrcSet", context.GetImageSrcSet( AV7PrefiltroSi), true);
               AV25Prefiltrosi_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( )));
               AssignProp(sPrefix, false, imgavPrefiltrosi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV7PrefiltroSi)) ? AV25Prefiltrosi_GXI : context.convertURL( context.PathToRelativeUrl( AV7PrefiltroSi))), true);
               AssignProp(sPrefix, false, imgavPrefiltrosi_Internalname, "SrcSet", context.GetImageSrcSet( AV7PrefiltroSi), true);
               imgImage3_Visible = 0;
               AssignProp(sPrefix, false, imgImage3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage3_Visible), 5, 0), true);
            }
            if ( A292VacantesUsuariosCV == 1 )
            {
               AV8CurriculumVitaeSi = context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( ));
               AssignProp(sPrefix, false, imgavCurriculumvitaesi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV8CurriculumVitaeSi)) ? AV26Curriculumvitaesi_GXI : context.convertURL( context.PathToRelativeUrl( AV8CurriculumVitaeSi))), true);
               AssignProp(sPrefix, false, imgavCurriculumvitaesi_Internalname, "SrcSet", context.GetImageSrcSet( AV8CurriculumVitaeSi), true);
               AV26Curriculumvitaesi_GXI = GXDbFile.PathToUrl( context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( )));
               AssignProp(sPrefix, false, imgavCurriculumvitaesi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV8CurriculumVitaeSi)) ? AV26Curriculumvitaesi_GXI : context.convertURL( context.PathToRelativeUrl( AV8CurriculumVitaeSi))), true);
               AssignProp(sPrefix, false, imgavCurriculumvitaesi_Internalname, "SrcSet", context.GetImageSrcSet( AV8CurriculumVitaeSi), true);
               imgImage4_Visible = 1;
               AssignProp(sPrefix, false, imgImage4_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage4_Visible), 5, 0), true);
            }
            else
            {
               AV8CurriculumVitaeSi = context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( ));
               AssignProp(sPrefix, false, imgavCurriculumvitaesi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV8CurriculumVitaeSi)) ? AV26Curriculumvitaesi_GXI : context.convertURL( context.PathToRelativeUrl( AV8CurriculumVitaeSi))), true);
               AssignProp(sPrefix, false, imgavCurriculumvitaesi_Internalname, "SrcSet", context.GetImageSrcSet( AV8CurriculumVitaeSi), true);
               AV26Curriculumvitaesi_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( )));
               AssignProp(sPrefix, false, imgavCurriculumvitaesi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV8CurriculumVitaeSi)) ? AV26Curriculumvitaesi_GXI : context.convertURL( context.PathToRelativeUrl( AV8CurriculumVitaeSi))), true);
               AssignProp(sPrefix, false, imgavCurriculumvitaesi_Internalname, "SrcSet", context.GetImageSrcSet( AV8CurriculumVitaeSi), true);
               imgImage4_Visible = 0;
               AssignProp(sPrefix, false, imgImage4_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage4_Visible), 5, 0), true);
            }
            if ( A293VacantesUsuariosExTec == 1 )
            {
               AV9ExamenTecninoSi = context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( ));
               AssignProp(sPrefix, false, imgavExamentecninosi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV9ExamenTecninoSi)) ? AV27Examentecninosi_GXI : context.convertURL( context.PathToRelativeUrl( AV9ExamenTecninoSi))), true);
               AssignProp(sPrefix, false, imgavExamentecninosi_Internalname, "SrcSet", context.GetImageSrcSet( AV9ExamenTecninoSi), true);
               AV27Examentecninosi_GXI = GXDbFile.PathToUrl( context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( )));
               AssignProp(sPrefix, false, imgavExamentecninosi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV9ExamenTecninoSi)) ? AV27Examentecninosi_GXI : context.convertURL( context.PathToRelativeUrl( AV9ExamenTecninoSi))), true);
               AssignProp(sPrefix, false, imgavExamentecninosi_Internalname, "SrcSet", context.GetImageSrcSet( AV9ExamenTecninoSi), true);
               imgImage5_Visible = 1;
               AssignProp(sPrefix, false, imgImage5_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage5_Visible), 5, 0), true);
            }
            else
            {
               AV9ExamenTecninoSi = context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( ));
               AssignProp(sPrefix, false, imgavExamentecninosi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV9ExamenTecninoSi)) ? AV27Examentecninosi_GXI : context.convertURL( context.PathToRelativeUrl( AV9ExamenTecninoSi))), true);
               AssignProp(sPrefix, false, imgavExamentecninosi_Internalname, "SrcSet", context.GetImageSrcSet( AV9ExamenTecninoSi), true);
               AV27Examentecninosi_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( )));
               AssignProp(sPrefix, false, imgavExamentecninosi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV9ExamenTecninoSi)) ? AV27Examentecninosi_GXI : context.convertURL( context.PathToRelativeUrl( AV9ExamenTecninoSi))), true);
               AssignProp(sPrefix, false, imgavExamentecninosi_Internalname, "SrcSet", context.GetImageSrcSet( AV9ExamenTecninoSi), true);
               imgImage5_Visible = 0;
               AssignProp(sPrefix, false, imgImage5_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage5_Visible), 5, 0), true);
            }
            if ( A304VacantesUsuariosAvConf == 1 )
            {
               AV10AvConfSi = context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( ));
               AssignProp(sPrefix, false, imgavAvconfsi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV10AvConfSi)) ? AV28Avconfsi_GXI : context.convertURL( context.PathToRelativeUrl( AV10AvConfSi))), true);
               AssignProp(sPrefix, false, imgavAvconfsi_Internalname, "SrcSet", context.GetImageSrcSet( AV10AvConfSi), true);
               AV28Avconfsi_GXI = GXDbFile.PathToUrl( context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( )));
               AssignProp(sPrefix, false, imgavAvconfsi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV10AvConfSi)) ? AV28Avconfsi_GXI : context.convertURL( context.PathToRelativeUrl( AV10AvConfSi))), true);
               AssignProp(sPrefix, false, imgavAvconfsi_Internalname, "SrcSet", context.GetImageSrcSet( AV10AvConfSi), true);
               imgImage6_Visible = 1;
               AssignProp(sPrefix, false, imgImage6_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage6_Visible), 5, 0), true);
            }
            else
            {
               AV10AvConfSi = context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( ));
               AssignProp(sPrefix, false, imgavAvconfsi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV10AvConfSi)) ? AV28Avconfsi_GXI : context.convertURL( context.PathToRelativeUrl( AV10AvConfSi))), true);
               AssignProp(sPrefix, false, imgavAvconfsi_Internalname, "SrcSet", context.GetImageSrcSet( AV10AvConfSi), true);
               AV28Avconfsi_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( )));
               AssignProp(sPrefix, false, imgavAvconfsi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV10AvConfSi)) ? AV28Avconfsi_GXI : context.convertURL( context.PathToRelativeUrl( AV10AvConfSi))), true);
               AssignProp(sPrefix, false, imgavAvconfsi_Internalname, "SrcSet", context.GetImageSrcSet( AV10AvConfSi), true);
               imgImage6_Visible = 0;
               AssignProp(sPrefix, false, imgImage6_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage6_Visible), 5, 0), true);
            }
            if ( A303VacantesUsuariosAvPriv == 1 )
            {
               AV11AvPrivSi = context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( ));
               AssignProp(sPrefix, false, imgavAvprivsi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV11AvPrivSi)) ? AV29Avprivsi_GXI : context.convertURL( context.PathToRelativeUrl( AV11AvPrivSi))), true);
               AssignProp(sPrefix, false, imgavAvprivsi_Internalname, "SrcSet", context.GetImageSrcSet( AV11AvPrivSi), true);
               AV29Avprivsi_GXI = GXDbFile.PathToUrl( context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( )));
               AssignProp(sPrefix, false, imgavAvprivsi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV11AvPrivSi)) ? AV29Avprivsi_GXI : context.convertURL( context.PathToRelativeUrl( AV11AvPrivSi))), true);
               AssignProp(sPrefix, false, imgavAvprivsi_Internalname, "SrcSet", context.GetImageSrcSet( AV11AvPrivSi), true);
               imgImage7_Visible = 1;
               AssignProp(sPrefix, false, imgImage7_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage7_Visible), 5, 0), true);
            }
            else
            {
               AV11AvPrivSi = context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( ));
               AssignProp(sPrefix, false, imgavAvprivsi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV11AvPrivSi)) ? AV29Avprivsi_GXI : context.convertURL( context.PathToRelativeUrl( AV11AvPrivSi))), true);
               AssignProp(sPrefix, false, imgavAvprivsi_Internalname, "SrcSet", context.GetImageSrcSet( AV11AvPrivSi), true);
               AV29Avprivsi_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( )));
               AssignProp(sPrefix, false, imgavAvprivsi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV11AvPrivSi)) ? AV29Avprivsi_GXI : context.convertURL( context.PathToRelativeUrl( AV11AvPrivSi))), true);
               AssignProp(sPrefix, false, imgavAvprivsi_Internalname, "SrcSet", context.GetImageSrcSet( AV11AvPrivSi), true);
               imgImage7_Visible = 0;
               AssignProp(sPrefix, false, imgImage7_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage7_Visible), 5, 0), true);
            }
            if ( A302VacantesUsuariosBusWeb == 1 )
            {
               AV12BusWebSi = context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( ));
               AssignProp(sPrefix, false, imgavBuswebsi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV12BusWebSi)) ? AV30Buswebsi_GXI : context.convertURL( context.PathToRelativeUrl( AV12BusWebSi))), true);
               AssignProp(sPrefix, false, imgavBuswebsi_Internalname, "SrcSet", context.GetImageSrcSet( AV12BusWebSi), true);
               AV30Buswebsi_GXI = GXDbFile.PathToUrl( context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( )));
               AssignProp(sPrefix, false, imgavBuswebsi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV12BusWebSi)) ? AV30Buswebsi_GXI : context.convertURL( context.PathToRelativeUrl( AV12BusWebSi))), true);
               AssignProp(sPrefix, false, imgavBuswebsi_Internalname, "SrcSet", context.GetImageSrcSet( AV12BusWebSi), true);
               imgImage8_Visible = 1;
               AssignProp(sPrefix, false, imgImage8_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage8_Visible), 5, 0), true);
            }
            else
            {
               AV12BusWebSi = context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( ));
               AssignProp(sPrefix, false, imgavBuswebsi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV12BusWebSi)) ? AV30Buswebsi_GXI : context.convertURL( context.PathToRelativeUrl( AV12BusWebSi))), true);
               AssignProp(sPrefix, false, imgavBuswebsi_Internalname, "SrcSet", context.GetImageSrcSet( AV12BusWebSi), true);
               AV30Buswebsi_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( )));
               AssignProp(sPrefix, false, imgavBuswebsi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV12BusWebSi)) ? AV30Buswebsi_GXI : context.convertURL( context.PathToRelativeUrl( AV12BusWebSi))), true);
               AssignProp(sPrefix, false, imgavBuswebsi_Internalname, "SrcSet", context.GetImageSrcSet( AV12BusWebSi), true);
               imgImage8_Visible = 0;
               AssignProp(sPrefix, false, imgImage8_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage8_Visible), 5, 0), true);
            }
            if ( A300VacantesUsuariosRefLab == 1 )
            {
               AV13ReferenciaSi = context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( ));
               AssignProp(sPrefix, false, imgavReferenciasi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV13ReferenciaSi)) ? AV31Referenciasi_GXI : context.convertURL( context.PathToRelativeUrl( AV13ReferenciaSi))), true);
               AssignProp(sPrefix, false, imgavReferenciasi_Internalname, "SrcSet", context.GetImageSrcSet( AV13ReferenciaSi), true);
               AV31Referenciasi_GXI = GXDbFile.PathToUrl( context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( )));
               AssignProp(sPrefix, false, imgavReferenciasi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV13ReferenciaSi)) ? AV31Referenciasi_GXI : context.convertURL( context.PathToRelativeUrl( AV13ReferenciaSi))), true);
               AssignProp(sPrefix, false, imgavReferenciasi_Internalname, "SrcSet", context.GetImageSrcSet( AV13ReferenciaSi), true);
               imgImage9_Visible = 1;
               AssignProp(sPrefix, false, imgImage9_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage9_Visible), 5, 0), true);
            }
            else
            {
               AV13ReferenciaSi = context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( ));
               AssignProp(sPrefix, false, imgavReferenciasi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV13ReferenciaSi)) ? AV31Referenciasi_GXI : context.convertURL( context.PathToRelativeUrl( AV13ReferenciaSi))), true);
               AssignProp(sPrefix, false, imgavReferenciasi_Internalname, "SrcSet", context.GetImageSrcSet( AV13ReferenciaSi), true);
               AV31Referenciasi_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( )));
               AssignProp(sPrefix, false, imgavReferenciasi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV13ReferenciaSi)) ? AV31Referenciasi_GXI : context.convertURL( context.PathToRelativeUrl( AV13ReferenciaSi))), true);
               AssignProp(sPrefix, false, imgavReferenciasi_Internalname, "SrcSet", context.GetImageSrcSet( AV13ReferenciaSi), true);
               imgImage9_Visible = 0;
               AssignProp(sPrefix, false, imgImage9_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage9_Visible), 5, 0), true);
            }
            if ( A301VacantesUsuariosExPsi == 1 )
            {
               AV14ExmPsiSi = context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( ));
               AssignProp(sPrefix, false, imgavExmpsisi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV14ExmPsiSi)) ? AV32Exmpsisi_GXI : context.convertURL( context.PathToRelativeUrl( AV14ExmPsiSi))), true);
               AssignProp(sPrefix, false, imgavExmpsisi_Internalname, "SrcSet", context.GetImageSrcSet( AV14ExmPsiSi), true);
               AV32Exmpsisi_GXI = GXDbFile.PathToUrl( context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( )));
               AssignProp(sPrefix, false, imgavExmpsisi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV14ExmPsiSi)) ? AV32Exmpsisi_GXI : context.convertURL( context.PathToRelativeUrl( AV14ExmPsiSi))), true);
               AssignProp(sPrefix, false, imgavExmpsisi_Internalname, "SrcSet", context.GetImageSrcSet( AV14ExmPsiSi), true);
               imgImage10_Visible = 1;
               AssignProp(sPrefix, false, imgImage10_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage10_Visible), 5, 0), true);
            }
            else
            {
               AV14ExmPsiSi = context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( ));
               AssignProp(sPrefix, false, imgavExmpsisi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV14ExmPsiSi)) ? AV32Exmpsisi_GXI : context.convertURL( context.PathToRelativeUrl( AV14ExmPsiSi))), true);
               AssignProp(sPrefix, false, imgavExmpsisi_Internalname, "SrcSet", context.GetImageSrcSet( AV14ExmPsiSi), true);
               AV32Exmpsisi_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( )));
               AssignProp(sPrefix, false, imgavExmpsisi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV14ExmPsiSi)) ? AV32Exmpsisi_GXI : context.convertURL( context.PathToRelativeUrl( AV14ExmPsiSi))), true);
               AssignProp(sPrefix, false, imgavExmpsisi_Internalname, "SrcSet", context.GetImageSrcSet( AV14ExmPsiSi), true);
               imgImage10_Visible = 0;
               AssignProp(sPrefix, false, imgImage10_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage10_Visible), 5, 0), true);
            }
            if ( A299VacantesUsuariosCVRec == 1 )
            {
               AV15CVRecSi = context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( ));
               AssignProp(sPrefix, false, imgavCvrecsi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV15CVRecSi)) ? AV33Cvrecsi_GXI : context.convertURL( context.PathToRelativeUrl( AV15CVRecSi))), true);
               AssignProp(sPrefix, false, imgavCvrecsi_Internalname, "SrcSet", context.GetImageSrcSet( AV15CVRecSi), true);
               AV33Cvrecsi_GXI = GXDbFile.PathToUrl( context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( )));
               AssignProp(sPrefix, false, imgavCvrecsi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV15CVRecSi)) ? AV33Cvrecsi_GXI : context.convertURL( context.PathToRelativeUrl( AV15CVRecSi))), true);
               AssignProp(sPrefix, false, imgavCvrecsi_Internalname, "SrcSet", context.GetImageSrcSet( AV15CVRecSi), true);
               imgImage11_Visible = 1;
               AssignProp(sPrefix, false, imgImage11_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage11_Visible), 5, 0), true);
            }
            else
            {
               AV15CVRecSi = context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( ));
               AssignProp(sPrefix, false, imgavCvrecsi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV15CVRecSi)) ? AV33Cvrecsi_GXI : context.convertURL( context.PathToRelativeUrl( AV15CVRecSi))), true);
               AssignProp(sPrefix, false, imgavCvrecsi_Internalname, "SrcSet", context.GetImageSrcSet( AV15CVRecSi), true);
               AV33Cvrecsi_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( )));
               AssignProp(sPrefix, false, imgavCvrecsi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV15CVRecSi)) ? AV33Cvrecsi_GXI : context.convertURL( context.PathToRelativeUrl( AV15CVRecSi))), true);
               AssignProp(sPrefix, false, imgavCvrecsi_Internalname, "SrcSet", context.GetImageSrcSet( AV15CVRecSi), true);
               imgImage11_Visible = 0;
               AssignProp(sPrefix, false, imgImage11_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage11_Visible), 5, 0), true);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      protected void E123B2( )
      {
         /* Image3_Click Routine */
         GXt_char2 = AV18RutaGuardada;
         new pr_recdocvacante(context ).execute(  AV5UsuariosId,  AV6Vacantes_Id,  1, out  GXt_char2) ;
         AV18RutaGuardada = GXt_char2;
         AssignAttri(sPrefix, false, "AV18RutaGuardada", AV18RutaGuardada);
         /* Execute user subroutine: 'ABREARCHIVO' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E133B2( )
      {
         /* Image4_Click Routine */
         GXt_char2 = AV18RutaGuardada;
         new pr_recdocvacante(context ).execute(  AV5UsuariosId,  AV6Vacantes_Id,  2, out  GXt_char2) ;
         AV18RutaGuardada = GXt_char2;
         AssignAttri(sPrefix, false, "AV18RutaGuardada", AV18RutaGuardada);
         /* Execute user subroutine: 'ABREARCHIVO' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E143B2( )
      {
         /* Image5_Click Routine */
         GXt_char2 = AV18RutaGuardada;
         new pr_recdocvacante(context ).execute(  AV5UsuariosId,  AV6Vacantes_Id,  3, out  GXt_char2) ;
         AV18RutaGuardada = GXt_char2;
         AssignAttri(sPrefix, false, "AV18RutaGuardada", AV18RutaGuardada);
         /* Execute user subroutine: 'ABREARCHIVO' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E153B2( )
      {
         /* Image6_Click Routine */
         GXt_char2 = AV18RutaGuardada;
         new pr_recdocvacante(context ).execute(  AV5UsuariosId,  AV6Vacantes_Id,  4, out  GXt_char2) ;
         AV18RutaGuardada = GXt_char2;
         AssignAttri(sPrefix, false, "AV18RutaGuardada", AV18RutaGuardada);
         /* Execute user subroutine: 'ABREARCHIVO' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E163B2( )
      {
         /* Image7_Click Routine */
         GXt_char2 = AV18RutaGuardada;
         new pr_recdocvacante(context ).execute(  AV5UsuariosId,  AV6Vacantes_Id,  5, out  GXt_char2) ;
         AV18RutaGuardada = GXt_char2;
         AssignAttri(sPrefix, false, "AV18RutaGuardada", AV18RutaGuardada);
         /* Execute user subroutine: 'ABREARCHIVO' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E173B2( )
      {
         /* Image8_Click Routine */
         GXt_char2 = AV18RutaGuardada;
         new pr_recdocvacante(context ).execute(  AV5UsuariosId,  AV6Vacantes_Id,  6, out  GXt_char2) ;
         AV18RutaGuardada = GXt_char2;
         AssignAttri(sPrefix, false, "AV18RutaGuardada", AV18RutaGuardada);
         /* Execute user subroutine: 'ABREARCHIVO' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E183B2( )
      {
         /* Image9_Click Routine */
         GXt_char2 = AV18RutaGuardada;
         new pr_recdocvacante(context ).execute(  AV5UsuariosId,  AV6Vacantes_Id,  7, out  GXt_char2) ;
         AV18RutaGuardada = GXt_char2;
         AssignAttri(sPrefix, false, "AV18RutaGuardada", AV18RutaGuardada);
         /* Execute user subroutine: 'ABREARCHIVO' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E193B2( )
      {
         /* Image10_Click Routine */
         GXt_char2 = AV18RutaGuardada;
         new pr_recdocvacante(context ).execute(  AV5UsuariosId,  AV6Vacantes_Id,  8, out  GXt_char2) ;
         AV18RutaGuardada = GXt_char2;
         AssignAttri(sPrefix, false, "AV18RutaGuardada", AV18RutaGuardada);
         /* Execute user subroutine: 'ABREARCHIVO' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E203B2( )
      {
         /* Image11_Click Routine */
         GXt_char2 = AV18RutaGuardada;
         new pr_recdocvacante(context ).execute(  AV5UsuariosId,  AV6Vacantes_Id,  9, out  GXt_char2) ;
         AV18RutaGuardada = GXt_char2;
         AssignAttri(sPrefix, false, "AV18RutaGuardada", AV18RutaGuardada);
         /* Execute user subroutine: 'ABREARCHIVO' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'ABREARCHIVO' Routine */
         AV17FullPathFile = AV18RutaGuardada;
         AV19NombreArchivo = "------------" + ".pdf";
         context.PopUp(formatLink("aviewpdf.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV19NombreArchivo)) + "," + UrlEncode(StringUtil.RTrim(AV17FullPathFile)), new Object[] {});
      }

      protected void nextLoad( )
      {
      }

      protected void E213B2( )
      {
         /* Load Routine */
      }

      protected void wb_table1_6_3B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable1_Internalname, tblTable1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_9_3B2( true) ;
         }
         else
         {
            wb_table2_9_3B2( false) ;
         }
         return  ;
      }

      protected void wb_table2_9_3B2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_6_3B2e( true) ;
         }
         else
         {
            wb_table1_6_3B2e( false) ;
         }
      }

      protected void wb_table2_9_3B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable4_Internalname, tblTable4_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Documento", "", "", lblTextblock10_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "SubTitle", 0, "", 1, 1, 0, "HLP_wcInfoVacante.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Estatús", "", "", lblTextblock11_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "SubTitle", 0, "", 1, 1, 0, "HLP_wcInfoVacante.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Right\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Right;text-align:-moz-Right;text-align:-webkit-Right")+"\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Reporte", "", "", lblTextblock12_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "SubTitle", 0, "", 1, 1, 0, "HLP_wcInfoVacante.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Prefiltro", "", "", lblTextblock1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "SubtitleLabel", 0, "", 1, 1, 0, "HLP_wcInfoVacante.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+imgavPrefiltrosi_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV7PrefiltroSi_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV7PrefiltroSi))&&String.IsNullOrEmpty(StringUtil.RTrim( AV25Prefiltrosi_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV7PrefiltroSi)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV7PrefiltroSi)) ? AV25Prefiltrosi_GXI : context.PathToRelativeUrl( AV7PrefiltroSi));
            GxWebStd.gx_bitmap( context, imgavPrefiltrosi_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV7PrefiltroSi_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_wcInfoVacante.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Left\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Left;text-align:-moz-Left;text-align:-webkit-Left;vertical-align:Top")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "5865f49e-c92c-4d5b-a8d4-45895fa0d0fd", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage3_Visible, 1, "", "Visualizar Prefiltro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EIMAGE3.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_wcInfoVacante.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Curriculum Vitae", "", "", lblTextblock2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "SubtitleLabel", 0, "", 1, 1, 0, "HLP_wcInfoVacante.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+imgavCurriculumvitaesi_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV8CurriculumVitaeSi_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV8CurriculumVitaeSi))&&String.IsNullOrEmpty(StringUtil.RTrim( AV26Curriculumvitaesi_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV8CurriculumVitaeSi)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV8CurriculumVitaeSi)) ? AV26Curriculumvitaesi_GXI : context.PathToRelativeUrl( AV8CurriculumVitaeSi));
            GxWebStd.gx_bitmap( context, imgavCurriculumvitaesi_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV8CurriculumVitaeSi_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_wcInfoVacante.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Left\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Left;text-align:-moz-Left;text-align:-webkit-Left;vertical-align:Top")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "5865f49e-c92c-4d5b-a8d4-45895fa0d0fd", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage4_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage4_Visible, 1, "", "Visualizar  Curriculum Vitae", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage4_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EIMAGE4.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_wcInfoVacante.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Examen Técnico", "", "", lblTextblock3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "SubtitleLabel", 0, "", 1, 1, 0, "HLP_wcInfoVacante.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+imgavExamentecninosi_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV9ExamenTecninoSi_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV9ExamenTecninoSi))&&String.IsNullOrEmpty(StringUtil.RTrim( AV27Examentecninosi_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV9ExamenTecninoSi)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV9ExamenTecninoSi)) ? AV27Examentecninosi_GXI : context.PathToRelativeUrl( AV9ExamenTecninoSi));
            GxWebStd.gx_bitmap( context, imgavExamentecninosi_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV9ExamenTecninoSi_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_wcInfoVacante.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Left\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Left;text-align:-moz-Left;text-align:-webkit-Left;vertical-align:Top")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "5865f49e-c92c-4d5b-a8d4-45895fa0d0fd", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage5_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage5_Visible, 1, "", "Visualizar Examen Técnico", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage5_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EIMAGE5.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_wcInfoVacante.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Aviso Confidencialidad", "", "", lblTextblock4_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "SubtitleLabel", 0, "", 1, 1, 0, "HLP_wcInfoVacante.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+imgavAvconfsi_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV10AvConfSi_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV10AvConfSi))&&String.IsNullOrEmpty(StringUtil.RTrim( AV28Avconfsi_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV10AvConfSi)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV10AvConfSi)) ? AV28Avconfsi_GXI : context.PathToRelativeUrl( AV10AvConfSi));
            GxWebStd.gx_bitmap( context, imgavAvconfsi_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV10AvConfSi_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_wcInfoVacante.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Left\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Left;text-align:-moz-Left;text-align:-webkit-Left;vertical-align:Top")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "5865f49e-c92c-4d5b-a8d4-45895fa0d0fd", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage6_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage6_Visible, 1, "", "Visualizar Aviso Confidencialidad", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage6_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EIMAGE6.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_wcInfoVacante.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Aviso Privacidad", "", "", lblTextblock5_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "SubtitleLabel", 0, "", 1, 1, 0, "HLP_wcInfoVacante.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+imgavAvprivsi_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV11AvPrivSi_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV11AvPrivSi))&&String.IsNullOrEmpty(StringUtil.RTrim( AV29Avprivsi_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV11AvPrivSi)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV11AvPrivSi)) ? AV29Avprivsi_GXI : context.PathToRelativeUrl( AV11AvPrivSi));
            GxWebStd.gx_bitmap( context, imgavAvprivsi_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV11AvPrivSi_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_wcInfoVacante.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Left\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Left;text-align:-moz-Left;text-align:-webkit-Left;vertical-align:Top")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "5865f49e-c92c-4d5b-a8d4-45895fa0d0fd", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage7_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage7_Visible, 1, "", "Visualizar Aviso Privacidad", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage7_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EIMAGE7.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_wcInfoVacante.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Busqueda Web", "", "", lblTextblock6_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "SubtitleLabel", 0, "", 1, 1, 0, "HLP_wcInfoVacante.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+imgavBuswebsi_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV12BusWebSi_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV12BusWebSi))&&String.IsNullOrEmpty(StringUtil.RTrim( AV30Buswebsi_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV12BusWebSi)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV12BusWebSi)) ? AV30Buswebsi_GXI : context.PathToRelativeUrl( AV12BusWebSi));
            GxWebStd.gx_bitmap( context, imgavBuswebsi_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV12BusWebSi_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_wcInfoVacante.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Left\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Left;text-align:-moz-Left;text-align:-webkit-Left;vertical-align:Top")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "5865f49e-c92c-4d5b-a8d4-45895fa0d0fd", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage8_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage8_Visible, 1, "", "Visualizar Busqueda Web", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage8_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EIMAGE8.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_wcInfoVacante.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Referencia", "", "", lblTextblock7_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "SubtitleLabel", 0, "", 1, 1, 0, "HLP_wcInfoVacante.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+imgavReferenciasi_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV13ReferenciaSi_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV13ReferenciaSi))&&String.IsNullOrEmpty(StringUtil.RTrim( AV31Referenciasi_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV13ReferenciaSi)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV13ReferenciaSi)) ? AV31Referenciasi_GXI : context.PathToRelativeUrl( AV13ReferenciaSi));
            GxWebStd.gx_bitmap( context, imgavReferenciasi_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV13ReferenciaSi_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_wcInfoVacante.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Left\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Left;text-align:-moz-Left;text-align:-webkit-Left;vertical-align:Top")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "5865f49e-c92c-4d5b-a8d4-45895fa0d0fd", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage9_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage9_Visible, 1, "", "Visualizar Referencia", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage9_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EIMAGE9.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_wcInfoVacante.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Examen Psicologico", "", "", lblTextblock8_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "SubtitleLabel", 0, "", 1, 1, 0, "HLP_wcInfoVacante.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+imgavExmpsisi_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV14ExmPsiSi_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV14ExmPsiSi))&&String.IsNullOrEmpty(StringUtil.RTrim( AV32Exmpsisi_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV14ExmPsiSi)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV14ExmPsiSi)) ? AV32Exmpsisi_GXI : context.PathToRelativeUrl( AV14ExmPsiSi));
            GxWebStd.gx_bitmap( context, imgavExmpsisi_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV14ExmPsiSi_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_wcInfoVacante.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Left\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Left;text-align:-moz-Left;text-align:-webkit-Left;vertical-align:Top")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "5865f49e-c92c-4d5b-a8d4-45895fa0d0fd", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage10_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage10_Visible, 1, "", "Visualizar Examen Psicologico", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage10_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EIMAGE10.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_wcInfoVacante.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "CV Recortado", "", "", lblTextblock9_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "SubtitleLabel", 0, "", 1, 1, 0, "HLP_wcInfoVacante.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+imgavCvrecsi_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV15CVRecSi_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV15CVRecSi))&&String.IsNullOrEmpty(StringUtil.RTrim( AV33Cvrecsi_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV15CVRecSi)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV15CVRecSi)) ? AV33Cvrecsi_GXI : context.PathToRelativeUrl( AV15CVRecSi));
            GxWebStd.gx_bitmap( context, imgavCvrecsi_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV15CVRecSi_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_wcInfoVacante.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Left\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Left;text-align:-moz-Left;text-align:-webkit-Left;vertical-align:Top")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "5865f49e-c92c-4d5b-a8d4-45895fa0d0fd", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage11_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage11_Visible, 1, "", "Visualizar CV Recortado", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage11_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EIMAGE11.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_wcInfoVacante.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDescartado_Internalname, "Descartado", "", "", lblDescartado_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "SubTitle", 0, "", lblDescartado_Visible, 1, 0, "HLP_wcInfoVacante.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMotivo_descarte_Internalname, "Motivo de Descarte:", "", "", lblMotivo_descarte_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "SubtitleLabel", 0, "", lblMotivo_descarte_Visible, 1, 0, "HLP_wcInfoVacante.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavVacantesusuariosfechad_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+edtavVacantesusuariosfechad_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavVacantesusuariosfechad_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavVacantesusuariosfechad_Internalname, context.localUtil.TToC( AV20VacantesUsuariosFechaD, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV20VacantesUsuariosFechaD, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,107);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVacantesusuariosfechad_Jsonclick, 0, "Attribute", "", "", "", "", edtavVacantesusuariosfechad_Visible, edtavVacantesusuariosfechad_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_wcInfoVacante.htm");
            GxWebStd.gx_bitmap( context, edtavVacantesusuariosfechad_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavVacantesusuariosfechad_Visible==0)||(edtavVacantesusuariosfechad_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_wcInfoVacante.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavVacantesusuariosmotd_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+edtavVacantesusuariosmotd_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavVacantesusuariosmotd_Internalname, AV21VacantesUsuariosMotD, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"", 0, edtavVacantesusuariosmotd_Visible, edtavVacantesusuariosmotd_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2048", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_wcInfoVacante.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_9_3B2e( true) ;
         }
         else
         {
            wb_table2_9_3B2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV5UsuariosId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV5UsuariosId", StringUtil.LTrimStr( (decimal)(AV5UsuariosId), 6, 0));
         AV6Vacantes_Id = Convert.ToInt32(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV6Vacantes_Id", StringUtil.LTrimStr( (decimal)(AV6Vacantes_Id), 9, 0));
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
         PA3B2( ) ;
         WS3B2( ) ;
         WE3B2( ) ;
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
         sCtrlAV5UsuariosId = (String)((String)getParm(obj,0));
         sCtrlAV6Vacantes_Id = (String)((String)getParm(obj,1));
      }

      public override void componentrestorestate( String sPPrefix ,
                                                  String sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3B2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (String)getParm(obj,0);
         sSFPrefix = (String)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wcinfovacante", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3B2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV5UsuariosId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV5UsuariosId", StringUtil.LTrimStr( (decimal)(AV5UsuariosId), 6, 0));
            AV6Vacantes_Id = Convert.ToInt32(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV6Vacantes_Id", StringUtil.LTrimStr( (decimal)(AV6Vacantes_Id), 9, 0));
         }
         wcpOAV5UsuariosId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV5UsuariosId"), ",", "."));
         wcpOAV6Vacantes_Id = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6Vacantes_Id"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( AV5UsuariosId != wcpOAV5UsuariosId ) || ( AV6Vacantes_Id != wcpOAV6Vacantes_Id ) ) )
         {
            setjustcreated();
         }
         wcpOAV5UsuariosId = AV5UsuariosId;
         wcpOAV6Vacantes_Id = AV6Vacantes_Id;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV5UsuariosId = cgiGet( sPrefix+"AV5UsuariosId_CTRL");
         if ( StringUtil.Len( sCtrlAV5UsuariosId) > 0 )
         {
            AV5UsuariosId = (int)(context.localUtil.CToN( cgiGet( sCtrlAV5UsuariosId), ",", "."));
            AssignAttri(sPrefix, false, "AV5UsuariosId", StringUtil.LTrimStr( (decimal)(AV5UsuariosId), 6, 0));
         }
         else
         {
            AV5UsuariosId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV5UsuariosId_PARM"), ",", "."));
         }
         sCtrlAV6Vacantes_Id = cgiGet( sPrefix+"AV6Vacantes_Id_CTRL");
         if ( StringUtil.Len( sCtrlAV6Vacantes_Id) > 0 )
         {
            AV6Vacantes_Id = (int)(context.localUtil.CToN( cgiGet( sCtrlAV6Vacantes_Id), ",", "."));
            AssignAttri(sPrefix, false, "AV6Vacantes_Id", StringUtil.LTrimStr( (decimal)(AV6Vacantes_Id), 9, 0));
         }
         else
         {
            AV6Vacantes_Id = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV6Vacantes_Id_PARM"), ",", "."));
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
         PA3B2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3B2( ) ;
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
         WS3B2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV5UsuariosId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5UsuariosId), 6, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV5UsuariosId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV5UsuariosId_CTRL", StringUtil.RTrim( sCtrlAV5UsuariosId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6Vacantes_Id_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6Vacantes_Id), 9, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6Vacantes_Id)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6Vacantes_Id_CTRL", StringUtil.RTrim( sCtrlAV6Vacantes_Id));
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
         WE3B2( ) ;
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
         AddStyleSheetFile("SweetAlert2/css/font-awesome.min.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714341383", true, true);
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
         context.AddJavascriptSource("wcinfovacante.js", "?202262714341383", false, true);
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
         lblTextblock10_Internalname = sPrefix+"TEXTBLOCK10";
         lblTextblock11_Internalname = sPrefix+"TEXTBLOCK11";
         lblTextblock12_Internalname = sPrefix+"TEXTBLOCK12";
         lblTextblock1_Internalname = sPrefix+"TEXTBLOCK1";
         imgavPrefiltrosi_Internalname = sPrefix+"vPREFILTROSI";
         imgImage3_Internalname = sPrefix+"IMAGE3";
         lblTextblock2_Internalname = sPrefix+"TEXTBLOCK2";
         imgavCurriculumvitaesi_Internalname = sPrefix+"vCURRICULUMVITAESI";
         imgImage4_Internalname = sPrefix+"IMAGE4";
         lblTextblock3_Internalname = sPrefix+"TEXTBLOCK3";
         imgavExamentecninosi_Internalname = sPrefix+"vEXAMENTECNINOSI";
         imgImage5_Internalname = sPrefix+"IMAGE5";
         lblTextblock4_Internalname = sPrefix+"TEXTBLOCK4";
         imgavAvconfsi_Internalname = sPrefix+"vAVCONFSI";
         imgImage6_Internalname = sPrefix+"IMAGE6";
         lblTextblock5_Internalname = sPrefix+"TEXTBLOCK5";
         imgavAvprivsi_Internalname = sPrefix+"vAVPRIVSI";
         imgImage7_Internalname = sPrefix+"IMAGE7";
         lblTextblock6_Internalname = sPrefix+"TEXTBLOCK6";
         imgavBuswebsi_Internalname = sPrefix+"vBUSWEBSI";
         imgImage8_Internalname = sPrefix+"IMAGE8";
         lblTextblock7_Internalname = sPrefix+"TEXTBLOCK7";
         imgavReferenciasi_Internalname = sPrefix+"vREFERENCIASI";
         imgImage9_Internalname = sPrefix+"IMAGE9";
         lblTextblock8_Internalname = sPrefix+"TEXTBLOCK8";
         imgavExmpsisi_Internalname = sPrefix+"vEXMPSISI";
         imgImage10_Internalname = sPrefix+"IMAGE10";
         lblTextblock9_Internalname = sPrefix+"TEXTBLOCK9";
         imgavCvrecsi_Internalname = sPrefix+"vCVRECSI";
         imgImage11_Internalname = sPrefix+"IMAGE11";
         lblDescartado_Internalname = sPrefix+"DESCARTADO";
         lblMotivo_descarte_Internalname = sPrefix+"MOTIVO_DESCARTE";
         edtavVacantesusuariosfechad_Internalname = sPrefix+"vVACANTESUSUARIOSFECHAD";
         edtavVacantesusuariosmotd_Internalname = sPrefix+"vVACANTESUSUARIOSMOTD";
         tblTable4_Internalname = sPrefix+"TABLE4";
         tblTable1_Internalname = sPrefix+"TABLE1";
         Ucalertas_Internalname = sPrefix+"UCALERTAS";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
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
         edtavVacantesusuariosmotd_Enabled = 1;
         edtavVacantesusuariosfechad_Jsonclick = "";
         edtavVacantesusuariosfechad_Enabled = 1;
         lblMotivo_descarte_Visible = 1;
         lblDescartado_Jsonclick = "";
         imgImage11_Visible = 1;
         imgImage10_Visible = 1;
         imgImage9_Visible = 1;
         imgImage8_Visible = 1;
         imgImage7_Visible = 1;
         imgImage6_Visible = 1;
         imgImage5_Visible = 1;
         imgImage4_Visible = 1;
         imgImage3_Visible = 1;
         lblDescartado_Visible = 1;
         edtavVacantesusuariosmotd_Visible = 1;
         edtavVacantesusuariosfechad_Visible = 1;
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
         setEventMetadata("IMAGE3.CLICK","{handler:'E123B2',iparms:[{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]");
         setEventMetadata("IMAGE3.CLICK",",oparms:[{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]}");
         setEventMetadata("IMAGE4.CLICK","{handler:'E133B2',iparms:[{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]");
         setEventMetadata("IMAGE4.CLICK",",oparms:[{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]}");
         setEventMetadata("IMAGE5.CLICK","{handler:'E143B2',iparms:[{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]");
         setEventMetadata("IMAGE5.CLICK",",oparms:[{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]}");
         setEventMetadata("IMAGE6.CLICK","{handler:'E153B2',iparms:[{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]");
         setEventMetadata("IMAGE6.CLICK",",oparms:[{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]}");
         setEventMetadata("IMAGE7.CLICK","{handler:'E163B2',iparms:[{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]");
         setEventMetadata("IMAGE7.CLICK",",oparms:[{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]}");
         setEventMetadata("IMAGE8.CLICK","{handler:'E173B2',iparms:[{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]");
         setEventMetadata("IMAGE8.CLICK",",oparms:[{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]}");
         setEventMetadata("IMAGE9.CLICK","{handler:'E183B2',iparms:[{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]");
         setEventMetadata("IMAGE9.CLICK",",oparms:[{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]}");
         setEventMetadata("IMAGE10.CLICK","{handler:'E193B2',iparms:[{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]");
         setEventMetadata("IMAGE10.CLICK",",oparms:[{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]}");
         setEventMetadata("IMAGE11.CLICK","{handler:'E203B2',iparms:[{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]");
         setEventMetadata("IMAGE11.CLICK",",oparms:[{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]}");
         setEventMetadata("VALIDV_VACANTESUSUARIOSFECHAD","{handler:'Validv_Vacantesusuariosfechad',iparms:[]");
         setEventMetadata("VALIDV_VACANTESUSUARIOSFECHAD",",oparms:[]}");
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
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV16AlertProperties = new SdtPropiedades(context);
         AV18RutaGuardada = "";
         GX_FocusControl = "";
         ucUcalertas = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV7PrefiltroSi = "";
         AV8CurriculumVitaeSi = "";
         AV9ExamenTecninoSi = "";
         AV10AvConfSi = "";
         AV11AvPrivSi = "";
         AV12BusWebSi = "";
         AV13ReferenciaSi = "";
         AV14ExmPsiSi = "";
         AV15CVRecSi = "";
         AV20VacantesUsuariosFechaD = (DateTime)(DateTime.MinValue);
         AV21VacantesUsuariosMotD = "";
         scmdbuf = "";
         H003B2_A11UsuariosId = new int[1] ;
         H003B2_A263Vacantes_Id = new int[1] ;
         H003B2_A292VacantesUsuariosCV = new short[1] ;
         H003B2_n292VacantesUsuariosCV = new bool[] {false} ;
         H003B2_A291VacantesUsuariosPrefiltro = new short[1] ;
         H003B2_n291VacantesUsuariosPrefiltro = new bool[] {false} ;
         H003B2_A290VacantesUsuariosEstatus = new short[1] ;
         H003B2_n290VacantesUsuariosEstatus = new bool[] {false} ;
         H003B2_A289VacantesUsuariosFechaD = new DateTime[] {DateTime.MinValue} ;
         H003B2_n289VacantesUsuariosFechaD = new bool[] {false} ;
         H003B2_A294VacantesUsuariosMotD = new String[] {""} ;
         H003B2_n294VacantesUsuariosMotD = new bool[] {false} ;
         H003B2_A293VacantesUsuariosExTec = new short[1] ;
         H003B2_n293VacantesUsuariosExTec = new bool[] {false} ;
         H003B2_A304VacantesUsuariosAvConf = new short[1] ;
         H003B2_n304VacantesUsuariosAvConf = new bool[] {false} ;
         H003B2_A303VacantesUsuariosAvPriv = new short[1] ;
         H003B2_n303VacantesUsuariosAvPriv = new bool[] {false} ;
         H003B2_A302VacantesUsuariosBusWeb = new short[1] ;
         H003B2_n302VacantesUsuariosBusWeb = new bool[] {false} ;
         H003B2_A300VacantesUsuariosRefLab = new short[1] ;
         H003B2_n300VacantesUsuariosRefLab = new bool[] {false} ;
         H003B2_A301VacantesUsuariosExPsi = new short[1] ;
         H003B2_n301VacantesUsuariosExPsi = new bool[] {false} ;
         H003B2_A299VacantesUsuariosCVRec = new short[1] ;
         H003B2_n299VacantesUsuariosCVRec = new bool[] {false} ;
         A289VacantesUsuariosFechaD = (DateTime)(DateTime.MinValue);
         A294VacantesUsuariosMotD = "";
         GXt_SdtPropiedades1 = new SdtPropiedades(context);
         AV25Prefiltrosi_GXI = "";
         AV26Curriculumvitaesi_GXI = "";
         AV27Examentecninosi_GXI = "";
         AV28Avconfsi_GXI = "";
         AV29Avprivsi_GXI = "";
         AV30Buswebsi_GXI = "";
         AV31Referenciasi_GXI = "";
         AV32Exmpsisi_GXI = "";
         AV33Cvrecsi_GXI = "";
         GXt_char2 = "";
         AV17FullPathFile = "";
         AV19NombreArchivo = "";
         sStyleString = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         TempTags = "";
         imgImage3_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         imgImage4_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         imgImage5_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         imgImage6_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         imgImage7_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         imgImage8_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         imgImage9_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         imgImage10_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         imgImage11_Jsonclick = "";
         lblMotivo_descarte_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV5UsuariosId = "";
         sCtrlAV6Vacantes_Id = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wcinfovacante__default(),
            new Object[][] {
                new Object[] {
               H003B2_A11UsuariosId, H003B2_A263Vacantes_Id, H003B2_A292VacantesUsuariosCV, H003B2_n292VacantesUsuariosCV, H003B2_A291VacantesUsuariosPrefiltro, H003B2_n291VacantesUsuariosPrefiltro, H003B2_A290VacantesUsuariosEstatus, H003B2_n290VacantesUsuariosEstatus, H003B2_A289VacantesUsuariosFechaD, H003B2_n289VacantesUsuariosFechaD,
               H003B2_A294VacantesUsuariosMotD, H003B2_n294VacantesUsuariosMotD, H003B2_A293VacantesUsuariosExTec, H003B2_n293VacantesUsuariosExTec, H003B2_A304VacantesUsuariosAvConf, H003B2_n304VacantesUsuariosAvConf, H003B2_A303VacantesUsuariosAvPriv, H003B2_n303VacantesUsuariosAvPriv, H003B2_A302VacantesUsuariosBusWeb, H003B2_n302VacantesUsuariosBusWeb,
               H003B2_A300VacantesUsuariosRefLab, H003B2_n300VacantesUsuariosRefLab, H003B2_A301VacantesUsuariosExPsi, H003B2_n301VacantesUsuariosExPsi, H003B2_A299VacantesUsuariosCVRec, H003B2_n299VacantesUsuariosCVRec
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavVacantesusuariosfechad_Enabled = 0;
         edtavVacantesusuariosmotd_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short A292VacantesUsuariosCV ;
      private short A291VacantesUsuariosPrefiltro ;
      private short A290VacantesUsuariosEstatus ;
      private short A293VacantesUsuariosExTec ;
      private short A304VacantesUsuariosAvConf ;
      private short A303VacantesUsuariosAvPriv ;
      private short A302VacantesUsuariosBusWeb ;
      private short A300VacantesUsuariosRefLab ;
      private short A301VacantesUsuariosExPsi ;
      private short A299VacantesUsuariosCVRec ;
      private short nGXWrapped ;
      private int AV5UsuariosId ;
      private int AV6Vacantes_Id ;
      private int wcpOAV5UsuariosId ;
      private int wcpOAV6Vacantes_Id ;
      private int edtavVacantesusuariosfechad_Enabled ;
      private int edtavVacantesusuariosmotd_Enabled ;
      private int A11UsuariosId ;
      private int A263Vacantes_Id ;
      private int edtavVacantesusuariosfechad_Visible ;
      private int edtavVacantesusuariosmotd_Visible ;
      private int lblMotivo_descarte_Visible ;
      private int lblDescartado_Visible ;
      private int imgImage3_Visible ;
      private int imgImage4_Visible ;
      private int imgImage5_Visible ;
      private int imgImage6_Visible ;
      private int imgImage7_Visible ;
      private int imgImage8_Visible ;
      private int imgImage9_Visible ;
      private int imgImage10_Visible ;
      private int imgImage11_Visible ;
      private int idxLst ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sPrefix ;
      private String sCompPrefix ;
      private String sSFPrefix ;
      private String edtavVacantesusuariosfechad_Internalname ;
      private String edtavVacantesusuariosmotd_Internalname ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GXEncryptionTmp ;
      private String GX_FocusControl ;
      private String divMaintable_Internalname ;
      private String Ucalertas_Internalname ;
      private String sXEvt ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String GXDecQS ;
      private String imgavPrefiltrosi_Internalname ;
      private String imgavCurriculumvitaesi_Internalname ;
      private String imgavExamentecninosi_Internalname ;
      private String imgavAvconfsi_Internalname ;
      private String imgavAvprivsi_Internalname ;
      private String imgavBuswebsi_Internalname ;
      private String imgavReferenciasi_Internalname ;
      private String imgavExmpsisi_Internalname ;
      private String imgavCvrecsi_Internalname ;
      private String scmdbuf ;
      private String lblMotivo_descarte_Internalname ;
      private String lblDescartado_Internalname ;
      private String imgImage3_Internalname ;
      private String imgImage4_Internalname ;
      private String imgImage5_Internalname ;
      private String imgImage6_Internalname ;
      private String imgImage7_Internalname ;
      private String imgImage8_Internalname ;
      private String imgImage9_Internalname ;
      private String imgImage10_Internalname ;
      private String imgImage11_Internalname ;
      private String GXt_char2 ;
      private String sStyleString ;
      private String tblTable1_Internalname ;
      private String tblTable4_Internalname ;
      private String lblTextblock10_Internalname ;
      private String lblTextblock10_Jsonclick ;
      private String lblTextblock11_Internalname ;
      private String lblTextblock11_Jsonclick ;
      private String lblTextblock12_Internalname ;
      private String lblTextblock12_Jsonclick ;
      private String lblTextblock1_Internalname ;
      private String lblTextblock1_Jsonclick ;
      private String ClassString ;
      private String StyleString ;
      private String sImgUrl ;
      private String TempTags ;
      private String imgImage3_Jsonclick ;
      private String lblTextblock2_Internalname ;
      private String lblTextblock2_Jsonclick ;
      private String imgImage4_Jsonclick ;
      private String lblTextblock3_Internalname ;
      private String lblTextblock3_Jsonclick ;
      private String imgImage5_Jsonclick ;
      private String lblTextblock4_Internalname ;
      private String lblTextblock4_Jsonclick ;
      private String imgImage6_Jsonclick ;
      private String lblTextblock5_Internalname ;
      private String lblTextblock5_Jsonclick ;
      private String imgImage7_Jsonclick ;
      private String lblTextblock6_Internalname ;
      private String lblTextblock6_Jsonclick ;
      private String imgImage8_Jsonclick ;
      private String lblTextblock7_Internalname ;
      private String lblTextblock7_Jsonclick ;
      private String imgImage9_Jsonclick ;
      private String lblTextblock8_Internalname ;
      private String lblTextblock8_Jsonclick ;
      private String imgImage10_Jsonclick ;
      private String lblTextblock9_Internalname ;
      private String lblTextblock9_Jsonclick ;
      private String imgImage11_Jsonclick ;
      private String lblDescartado_Jsonclick ;
      private String lblMotivo_descarte_Jsonclick ;
      private String edtavVacantesusuariosfechad_Jsonclick ;
      private String sCtrlAV5UsuariosId ;
      private String sCtrlAV6Vacantes_Id ;
      private DateTime AV20VacantesUsuariosFechaD ;
      private DateTime A289VacantesUsuariosFechaD ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n292VacantesUsuariosCV ;
      private bool n291VacantesUsuariosPrefiltro ;
      private bool n290VacantesUsuariosEstatus ;
      private bool n289VacantesUsuariosFechaD ;
      private bool n294VacantesUsuariosMotD ;
      private bool n293VacantesUsuariosExTec ;
      private bool n304VacantesUsuariosAvConf ;
      private bool n303VacantesUsuariosAvPriv ;
      private bool n302VacantesUsuariosBusWeb ;
      private bool n300VacantesUsuariosRefLab ;
      private bool n301VacantesUsuariosExPsi ;
      private bool n299VacantesUsuariosCVRec ;
      private bool AV7PrefiltroSi_IsBlob ;
      private bool AV8CurriculumVitaeSi_IsBlob ;
      private bool AV9ExamenTecninoSi_IsBlob ;
      private bool AV10AvConfSi_IsBlob ;
      private bool AV11AvPrivSi_IsBlob ;
      private bool AV12BusWebSi_IsBlob ;
      private bool AV13ReferenciaSi_IsBlob ;
      private bool AV14ExmPsiSi_IsBlob ;
      private bool AV15CVRecSi_IsBlob ;
      private String AV18RutaGuardada ;
      private String AV21VacantesUsuariosMotD ;
      private String A294VacantesUsuariosMotD ;
      private String AV25Prefiltrosi_GXI ;
      private String AV26Curriculumvitaesi_GXI ;
      private String AV27Examentecninosi_GXI ;
      private String AV28Avconfsi_GXI ;
      private String AV29Avprivsi_GXI ;
      private String AV30Buswebsi_GXI ;
      private String AV31Referenciasi_GXI ;
      private String AV32Exmpsisi_GXI ;
      private String AV33Cvrecsi_GXI ;
      private String AV17FullPathFile ;
      private String AV19NombreArchivo ;
      private String AV7PrefiltroSi ;
      private String AV8CurriculumVitaeSi ;
      private String AV9ExamenTecninoSi ;
      private String AV10AvConfSi ;
      private String AV11AvPrivSi ;
      private String AV12BusWebSi ;
      private String AV13ReferenciaSi ;
      private String AV14ExmPsiSi ;
      private String AV15CVRecSi ;
      private GXUserControl ucUcalertas ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H003B2_A11UsuariosId ;
      private int[] H003B2_A263Vacantes_Id ;
      private short[] H003B2_A292VacantesUsuariosCV ;
      private bool[] H003B2_n292VacantesUsuariosCV ;
      private short[] H003B2_A291VacantesUsuariosPrefiltro ;
      private bool[] H003B2_n291VacantesUsuariosPrefiltro ;
      private short[] H003B2_A290VacantesUsuariosEstatus ;
      private bool[] H003B2_n290VacantesUsuariosEstatus ;
      private DateTime[] H003B2_A289VacantesUsuariosFechaD ;
      private bool[] H003B2_n289VacantesUsuariosFechaD ;
      private String[] H003B2_A294VacantesUsuariosMotD ;
      private bool[] H003B2_n294VacantesUsuariosMotD ;
      private short[] H003B2_A293VacantesUsuariosExTec ;
      private bool[] H003B2_n293VacantesUsuariosExTec ;
      private short[] H003B2_A304VacantesUsuariosAvConf ;
      private bool[] H003B2_n304VacantesUsuariosAvConf ;
      private short[] H003B2_A303VacantesUsuariosAvPriv ;
      private bool[] H003B2_n303VacantesUsuariosAvPriv ;
      private short[] H003B2_A302VacantesUsuariosBusWeb ;
      private bool[] H003B2_n302VacantesUsuariosBusWeb ;
      private short[] H003B2_A300VacantesUsuariosRefLab ;
      private bool[] H003B2_n300VacantesUsuariosRefLab ;
      private short[] H003B2_A301VacantesUsuariosExPsi ;
      private bool[] H003B2_n301VacantesUsuariosExPsi ;
      private short[] H003B2_A299VacantesUsuariosCVRec ;
      private bool[] H003B2_n299VacantesUsuariosCVRec ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private SdtPropiedades AV16AlertProperties ;
      private SdtPropiedades GXt_SdtPropiedades1 ;
   }

   public class wcinfovacante__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH003B2 ;
          prmH003B2 = new Object[] {
          new Object[] {"AV6Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"AV5UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H003B2", "SELECT `UsuariosId`, `Vacantes_Id`, `VacantesUsuariosCV`, `VacantesUsuariosPrefiltro`, `VacantesUsuariosEstatus`, `VacantesUsuariosFechaD`, `VacantesUsuariosMotD`, `VacantesUsuariosExTec`, `VacantesUsuariosAvConf`, `VacantesUsuariosAvPriv`, `VacantesUsuariosBusWeb`, `VacantesUsuariosRefLab`, `VacantesUsuariosExPsi`, `VacantesUsuariosCVRec` FROM `VacantesUsuariosVacante` WHERE `Vacantes_Id` = ? and `UsuariosId` = ? ORDER BY `Vacantes_Id`, `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003B2,1, GxCacheFrequency.OFF ,true,true )
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
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((short[]) buf[6])[0] = rslt.getShort(5) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(6) ;
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((String[]) buf[10])[0] = rslt.getVarchar(7) ;
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((short[]) buf[12])[0] = rslt.getShort(8) ;
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((short[]) buf[14])[0] = rslt.getShort(9) ;
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((short[]) buf[16])[0] = rslt.getShort(10) ;
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((short[]) buf[18])[0] = rslt.getShort(11) ;
                ((bool[]) buf[19])[0] = rslt.wasNull(11);
                ((short[]) buf[20])[0] = rslt.getShort(12) ;
                ((bool[]) buf[21])[0] = rslt.wasNull(12);
                ((short[]) buf[22])[0] = rslt.getShort(13) ;
                ((bool[]) buf[23])[0] = rslt.wasNull(13);
                ((short[]) buf[24])[0] = rslt.getShort(14) ;
                ((bool[]) buf[25])[0] = rslt.wasNull(14);
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
       }
    }

 }

}
