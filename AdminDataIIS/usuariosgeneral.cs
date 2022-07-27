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
   public class usuariosgeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public usuariosgeneral( )
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

      public usuariosgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_UsuariosId )
      {
         this.A11UsuariosId = aP0_UsuariosId;
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
         cmbUsuariosTipo = new GXCombobox();
         cmbUsuariosStatus = new GXCombobox();
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
                  A11UsuariosId = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri(sPrefix, false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(String)sCompPrefix,(String)sSFPrefix,(int)A11UsuariosId});
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
            PA0Y2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV14Pgmname = "UsuariosGeneral";
               context.Gx_err = 0;
               WS0Y2( ) ;
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
            context.SendWebValue( "Usuarios General") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714343147", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 2036420), false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("usuariosgeneral.aspx") + "?" + UrlEncode("" +A11UsuariosId)+"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"UsuariosGeneral");
         forbiddenHiddens.Add("RolId", context.localUtil.Format( (decimal)(A24RolId), "ZZZZZZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("usuariosgeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA11UsuariosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA11UsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"USUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")));
      }

      protected void RenderHtmlCloseForm0Y2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            context.AddJavascriptSource("usuariosgeneral.js", "?202262714343153", false, true);
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
         return "UsuariosGeneral" ;
      }

      public override String GetPgmdesc( )
      {
         return "Usuarios General" ;
      }

      protected void WB0Y0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "usuariosgeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ViewActionsCell", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group WWViewActions", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Modificar", bttBtnupdate_Jsonclick, 5, "Modificar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_UsuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Eliminar", bttBtndelete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_UsuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributestable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosCurp_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuariosCurp_Internalname, "CURP", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtUsuariosCurp_Internalname, A105UsuariosCurp, StringUtil.RTrim( context.localUtil.Format( A105UsuariosCurp, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosCurp_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtUsuariosCurp_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_UsuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuariosNombre_Internalname, "Nombre", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtUsuariosNombre_Internalname, A66UsuariosNombre, StringUtil.RTrim( context.localUtil.Format( A66UsuariosNombre, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosNombre_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtUsuariosNombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_UsuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosApPat_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuariosApPat_Internalname, "Apellido Paterno", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtUsuariosApPat_Internalname, A65UsuariosApPat, StringUtil.RTrim( context.localUtil.Format( A65UsuariosApPat, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosApPat_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtUsuariosApPat_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_UsuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosApMat_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuariosApMat_Internalname, "Apellido Materno", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtUsuariosApMat_Internalname, A64UsuariosApMat, StringUtil.RTrim( context.localUtil.Format( A64UsuariosApMat, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosApMat_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtUsuariosApMat_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_UsuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosUsr_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuariosUsr_Internalname, "Usuario", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtUsuariosUsr_Internalname, A244UsuariosUsr, StringUtil.RTrim( context.localUtil.Format( A244UsuariosUsr, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosUsr_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtUsuariosUsr_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_UsuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbUsuariosTipo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbUsuariosTipo_Internalname, "Tipo", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbUsuariosTipo, cmbUsuariosTipo_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A272UsuariosTipo), 4, 0)), 1, cmbUsuariosTipo_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbUsuariosTipo.Enabled, 0, 0, 0, "em", 0, "", "", "ReadonlyAttribute", "", "", "", "", true, "HLP_UsuariosGeneral.htm");
            cmbUsuariosTipo.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A272UsuariosTipo), 4, 0));
            AssignProp(sPrefix, false, cmbUsuariosTipo_Internalname, "Values", (String)(cmbUsuariosTipo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosFecNacimiento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuariosFecNacimiento_Internalname, "Nacimiento", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtUsuariosFecNacimiento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtUsuariosFecNacimiento_Internalname, context.localUtil.Format(A255UsuariosFecNacimiento, "99/99/99"), context.localUtil.Format( A255UsuariosFecNacimiento, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosFecNacimiento_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtUsuariosFecNacimiento_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_UsuariosGeneral.htm");
            GxWebStd.gx_bitmap( context, edtUsuariosFecNacimiento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUsuariosFecNacimiento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_UsuariosGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosEdad_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuariosEdad_Internalname, "Edad", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtUsuariosEdad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A256UsuariosEdad), 4, 0, ",", "")), ((edtUsuariosEdad_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A256UsuariosEdad), "ZZZ9")) : context.localUtil.Format( (decimal)(A256UsuariosEdad), "ZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosEdad_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtUsuariosEdad_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_UsuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosSexo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuariosSexo_Internalname, "Sexo", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtUsuariosSexo_Internalname, StringUtil.RTrim( A257UsuariosSexo), StringUtil.RTrim( context.localUtil.Format( A257UsuariosSexo, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosSexo_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtUsuariosSexo_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "Sexo", "left", true, "", "HLP_UsuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosPwd_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuariosPwd_Internalname, "Contraseña", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtUsuariosPwd_Internalname, A68UsuariosPwd, StringUtil.RTrim( context.localUtil.Format( A68UsuariosPwd, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosPwd_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtUsuariosPwd_Enabled, 0, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_UsuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosKey_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuariosKey_Internalname, "Llave para encriptar pwd", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtUsuariosKey_Internalname, A67UsuariosKey, StringUtil.RTrim( context.localUtil.Format( A67UsuariosKey, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosKey_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtUsuariosKey_Enabled, 0, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_UsuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosVigIni_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuariosVigIni_Internalname, "Inicio de Vigencia", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtUsuariosVigIni_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtUsuariosVigIni_Internalname, context.localUtil.Format(A96UsuariosVigIni, "99/99/9999"), context.localUtil.Format( A96UsuariosVigIni, "99/99/9999"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosVigIni_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtUsuariosVigIni_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "Fecha", "right", false, "", "HLP_UsuariosGeneral.htm");
            GxWebStd.gx_bitmap( context, edtUsuariosVigIni_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUsuariosVigIni_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_UsuariosGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosVigFin_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuariosVigFin_Internalname, "Fin de Vigencia", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtUsuariosVigFin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtUsuariosVigFin_Internalname, context.localUtil.Format(A70UsuariosVigFin, "99/99/9999"), context.localUtil.Format( A70UsuariosVigFin, "99/99/9999"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosVigFin_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtUsuariosVigFin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "Fecha", "right", false, "", "HLP_UsuariosGeneral.htm");
            GxWebStd.gx_bitmap( context, edtUsuariosVigFin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUsuariosVigFin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_UsuariosGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosFecCap_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuariosFecCap_Internalname, "Fecha de Captura", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtUsuariosFecCap_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtUsuariosFecCap_Internalname, context.localUtil.TToC( A92UsuariosFecCap, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A92UsuariosFecCap, "99/99/9999 99:99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosFecCap_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtUsuariosFecCap_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 1, -1, 0, true, "FechaTiempo", "right", false, "", "HLP_UsuariosGeneral.htm");
            GxWebStd.gx_bitmap( context, edtUsuariosFecCap_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUsuariosFecCap_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_UsuariosGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosIP_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuariosIP_Internalname, "Ip de Creación", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtUsuariosIP_Internalname, A93UsuariosIP, StringUtil.RTrim( context.localUtil.Format( A93UsuariosIP, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosIP_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtUsuariosIP_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "Ip", "left", true, "", "HLP_UsuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosTelef_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuariosTelef_Internalname, "Teléfono", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtUsuariosTelef_Internalname, StringUtil.RTrim( A260UsuariosTelef), StringUtil.RTrim( context.localUtil.Format( A260UsuariosTelef, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosTelef_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtUsuariosTelef_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_UsuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosCorreo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuariosCorreo_Internalname, "electrónico", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtUsuariosCorreo_Internalname, A261UsuariosCorreo, StringUtil.RTrim( context.localUtil.Format( A261UsuariosCorreo, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A261UsuariosCorreo, "", "", "", edtUsuariosCorreo_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtUsuariosCorreo_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_UsuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosNomCompleto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuariosNomCompleto_Internalname, "Usuarios Nom Completo", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtUsuariosNomCompleto_Internalname, A97UsuariosNomCompleto, StringUtil.RTrim( context.localUtil.Format( A97UsuariosNomCompleto, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosNomCompleto_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtUsuariosNomCompleto_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_UsuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRolId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtRolId_Internalname, "Clave del rol", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtRolId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A24RolId), 9, 0, ",", "")), ((edtRolId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A24RolId), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A24RolId), "ZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRolId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtRolId_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_UsuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRolNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtRolNombre_Internalname, "Rol Nombre", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtRolNombre_Internalname, A127RolNombre, StringUtil.RTrim( context.localUtil.Format( A127RolNombre, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtRolNombre_Link, "", "", "", edtRolNombre_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtRolNombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_UsuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosSexoFor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuariosSexoFor_Internalname, "Sexo", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtUsuariosSexoFor_Internalname, StringUtil.RTrim( A275UsuariosSexoFor), StringUtil.RTrim( context.localUtil.Format( A275UsuariosSexoFor, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosSexoFor_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtUsuariosSexoFor_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "Sexo", "left", true, "", "HLP_UsuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbUsuariosStatus_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbUsuariosStatus_Internalname, "Status", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbUsuariosStatus, cmbUsuariosStatus_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A286UsuariosStatus), 1, 0)), 1, cmbUsuariosStatus_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbUsuariosStatus.Enabled, 0, 0, 0, "em", 0, "", "", "ReadonlyAttribute", "", "", "", "", true, "HLP_UsuariosGeneral.htm");
            cmbUsuariosStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A286UsuariosStatus), 1, 0));
            AssignProp(sPrefix, false, cmbUsuariosStatus_Internalname, "Values", (String)(cmbUsuariosStatus.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divImagestable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Icono", "col-sm-3 ReadonlyAttributeLabel ReadonlyResponsiveImageAttributeLabel", 0, true, "");
            /* Static Bitmap Variable */
            ClassString = "ReadonlyAttribute ReadonlyResponsiveImageAttribute";
            StyleString = "";
            A245UsuariosIcono_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A245UsuariosIcono))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000UsuariosIcono_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A245UsuariosIcono)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A245UsuariosIcono)) ? A40000UsuariosIcono_GXI : context.PathToRelativeUrl( A245UsuariosIcono));
            GxWebStd.gx_bitmap( context, imgUsuariosIcono_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A245UsuariosIcono_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_UsuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0Y2( )
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
               Form.Meta.addItem("description", "Usuarios General", 0) ;
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
               STRUP0Y0( ) ;
            }
         }
      }

      protected void WS0Y2( )
      {
         START0Y2( ) ;
         EVT0Y2( ) ;
      }

      protected void EVT0Y2( )
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
                                 STRUP0Y0( ) ;
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
                                 STRUP0Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E110Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E120Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E130Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E140Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0Y0( ) ;
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
                                 STRUP0Y0( ) ;
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

      protected void WE0Y2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0Y2( ) ;
            }
         }
      }

      protected void PA0Y2( )
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
         if ( cmbUsuariosTipo.ItemCount > 0 )
         {
            A272UsuariosTipo = (short)(NumberUtil.Val( cmbUsuariosTipo.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A272UsuariosTipo), 4, 0))), "."));
            AssignAttri(sPrefix, false, "A272UsuariosTipo", StringUtil.LTrimStr( (decimal)(A272UsuariosTipo), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuariosTipo.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A272UsuariosTipo), 4, 0));
            AssignProp(sPrefix, false, cmbUsuariosTipo_Internalname, "Values", cmbUsuariosTipo.ToJavascriptSource(), true);
         }
         if ( cmbUsuariosStatus.ItemCount > 0 )
         {
            A286UsuariosStatus = (short)(NumberUtil.Val( cmbUsuariosStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A286UsuariosStatus), 1, 0))), "."));
            AssignAttri(sPrefix, false, "A286UsuariosStatus", StringUtil.Str( (decimal)(A286UsuariosStatus), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuariosStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A286UsuariosStatus), 1, 0));
            AssignProp(sPrefix, false, cmbUsuariosStatus_Internalname, "Values", cmbUsuariosStatus.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV14Pgmname = "UsuariosGeneral";
         context.Gx_err = 0;
      }

      protected void RF0Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H000Y2 */
            pr_default.execute(0, new Object[] {A11UsuariosId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A40000UsuariosIcono_GXI = H000Y2_A40000UsuariosIcono_GXI[0];
               AssignProp(sPrefix, false, imgUsuariosIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A245UsuariosIcono)) ? A40000UsuariosIcono_GXI : context.convertURL( context.PathToRelativeUrl( A245UsuariosIcono))), true);
               AssignProp(sPrefix, false, imgUsuariosIcono_Internalname, "SrcSet", context.GetImageSrcSet( A245UsuariosIcono), true);
               A286UsuariosStatus = H000Y2_A286UsuariosStatus[0];
               AssignAttri(sPrefix, false, "A286UsuariosStatus", StringUtil.Str( (decimal)(A286UsuariosStatus), 1, 0));
               A127RolNombre = H000Y2_A127RolNombre[0];
               AssignAttri(sPrefix, false, "A127RolNombre", A127RolNombre);
               A24RolId = H000Y2_A24RolId[0];
               AssignAttri(sPrefix, false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
               A261UsuariosCorreo = H000Y2_A261UsuariosCorreo[0];
               AssignAttri(sPrefix, false, "A261UsuariosCorreo", A261UsuariosCorreo);
               A260UsuariosTelef = H000Y2_A260UsuariosTelef[0];
               AssignAttri(sPrefix, false, "A260UsuariosTelef", A260UsuariosTelef);
               A93UsuariosIP = H000Y2_A93UsuariosIP[0];
               AssignAttri(sPrefix, false, "A93UsuariosIP", A93UsuariosIP);
               A92UsuariosFecCap = H000Y2_A92UsuariosFecCap[0];
               AssignAttri(sPrefix, false, "A92UsuariosFecCap", context.localUtil.TToC( A92UsuariosFecCap, 10, 8, 0, 3, "/", ":", " "));
               A70UsuariosVigFin = H000Y2_A70UsuariosVigFin[0];
               n70UsuariosVigFin = H000Y2_n70UsuariosVigFin[0];
               AssignAttri(sPrefix, false, "A70UsuariosVigFin", context.localUtil.Format(A70UsuariosVigFin, "99/99/9999"));
               A96UsuariosVigIni = H000Y2_A96UsuariosVigIni[0];
               AssignAttri(sPrefix, false, "A96UsuariosVigIni", context.localUtil.Format(A96UsuariosVigIni, "99/99/9999"));
               A67UsuariosKey = H000Y2_A67UsuariosKey[0];
               AssignAttri(sPrefix, false, "A67UsuariosKey", A67UsuariosKey);
               A68UsuariosPwd = H000Y2_A68UsuariosPwd[0];
               AssignAttri(sPrefix, false, "A68UsuariosPwd", A68UsuariosPwd);
               A256UsuariosEdad = H000Y2_A256UsuariosEdad[0];
               AssignAttri(sPrefix, false, "A256UsuariosEdad", StringUtil.LTrimStr( (decimal)(A256UsuariosEdad), 4, 0));
               A255UsuariosFecNacimiento = H000Y2_A255UsuariosFecNacimiento[0];
               AssignAttri(sPrefix, false, "A255UsuariosFecNacimiento", context.localUtil.Format(A255UsuariosFecNacimiento, "99/99/99"));
               A272UsuariosTipo = H000Y2_A272UsuariosTipo[0];
               AssignAttri(sPrefix, false, "A272UsuariosTipo", StringUtil.LTrimStr( (decimal)(A272UsuariosTipo), 4, 0));
               A244UsuariosUsr = H000Y2_A244UsuariosUsr[0];
               AssignAttri(sPrefix, false, "A244UsuariosUsr", A244UsuariosUsr);
               A105UsuariosCurp = H000Y2_A105UsuariosCurp[0];
               AssignAttri(sPrefix, false, "A105UsuariosCurp", A105UsuariosCurp);
               A64UsuariosApMat = H000Y2_A64UsuariosApMat[0];
               AssignAttri(sPrefix, false, "A64UsuariosApMat", A64UsuariosApMat);
               A65UsuariosApPat = H000Y2_A65UsuariosApPat[0];
               AssignAttri(sPrefix, false, "A65UsuariosApPat", A65UsuariosApPat);
               A66UsuariosNombre = H000Y2_A66UsuariosNombre[0];
               AssignAttri(sPrefix, false, "A66UsuariosNombre", A66UsuariosNombre);
               A257UsuariosSexo = H000Y2_A257UsuariosSexo[0];
               AssignAttri(sPrefix, false, "A257UsuariosSexo", A257UsuariosSexo);
               A245UsuariosIcono = H000Y2_A245UsuariosIcono[0];
               AssignAttri(sPrefix, false, "A245UsuariosIcono", A245UsuariosIcono);
               AssignProp(sPrefix, false, imgUsuariosIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A245UsuariosIcono)) ? A40000UsuariosIcono_GXI : context.convertURL( context.PathToRelativeUrl( A245UsuariosIcono))), true);
               AssignProp(sPrefix, false, imgUsuariosIcono_Internalname, "SrcSet", context.GetImageSrcSet( A245UsuariosIcono), true);
               A127RolNombre = H000Y2_A127RolNombre[0];
               AssignAttri(sPrefix, false, "A127RolNombre", A127RolNombre);
               if ( StringUtil.StrCmp(A257UsuariosSexo, "H") == 0 )
               {
                  A275UsuariosSexoFor = "Hombres";
                  AssignAttri(sPrefix, false, "A275UsuariosSexoFor", A275UsuariosSexoFor);
               }
               else
               {
                  if ( StringUtil.StrCmp(A257UsuariosSexo, "M") == 0 )
                  {
                     A275UsuariosSexoFor = "Mujeres";
                     AssignAttri(sPrefix, false, "A275UsuariosSexoFor", A275UsuariosSexoFor);
                  }
                  else
                  {
                     A275UsuariosSexoFor = "";
                     AssignAttri(sPrefix, false, "A275UsuariosSexoFor", A275UsuariosSexoFor);
                  }
               }
               A97UsuariosNomCompleto = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + StringUtil.Trim( A64UsuariosApMat);
               AssignAttri(sPrefix, false, "A97UsuariosNomCompleto", A97UsuariosNomCompleto);
               /* Execute user event: Load */
               E120Y2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB0Y0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0Y2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV14Pgmname = "UsuariosGeneral";
         context.Gx_err = 0;
      }

      protected void STRUP0Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110Y2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA11UsuariosId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA11UsuariosId"), ",", "."));
            /* Read variables values. */
            A105UsuariosCurp = StringUtil.Upper( cgiGet( edtUsuariosCurp_Internalname));
            AssignAttri(sPrefix, false, "A105UsuariosCurp", A105UsuariosCurp);
            A66UsuariosNombre = StringUtil.Upper( cgiGet( edtUsuariosNombre_Internalname));
            AssignAttri(sPrefix, false, "A66UsuariosNombre", A66UsuariosNombre);
            A65UsuariosApPat = StringUtil.Upper( cgiGet( edtUsuariosApPat_Internalname));
            AssignAttri(sPrefix, false, "A65UsuariosApPat", A65UsuariosApPat);
            A64UsuariosApMat = StringUtil.Upper( cgiGet( edtUsuariosApMat_Internalname));
            AssignAttri(sPrefix, false, "A64UsuariosApMat", A64UsuariosApMat);
            A244UsuariosUsr = cgiGet( edtUsuariosUsr_Internalname);
            AssignAttri(sPrefix, false, "A244UsuariosUsr", A244UsuariosUsr);
            cmbUsuariosTipo.CurrentValue = cgiGet( cmbUsuariosTipo_Internalname);
            A272UsuariosTipo = (short)(NumberUtil.Val( cgiGet( cmbUsuariosTipo_Internalname), "."));
            AssignAttri(sPrefix, false, "A272UsuariosTipo", StringUtil.LTrimStr( (decimal)(A272UsuariosTipo), 4, 0));
            A255UsuariosFecNacimiento = context.localUtil.CToD( cgiGet( edtUsuariosFecNacimiento_Internalname), 2);
            AssignAttri(sPrefix, false, "A255UsuariosFecNacimiento", context.localUtil.Format(A255UsuariosFecNacimiento, "99/99/99"));
            A256UsuariosEdad = (short)(context.localUtil.CToN( cgiGet( edtUsuariosEdad_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A256UsuariosEdad", StringUtil.LTrimStr( (decimal)(A256UsuariosEdad), 4, 0));
            A257UsuariosSexo = cgiGet( edtUsuariosSexo_Internalname);
            AssignAttri(sPrefix, false, "A257UsuariosSexo", A257UsuariosSexo);
            A68UsuariosPwd = cgiGet( edtUsuariosPwd_Internalname);
            AssignAttri(sPrefix, false, "A68UsuariosPwd", A68UsuariosPwd);
            A67UsuariosKey = cgiGet( edtUsuariosKey_Internalname);
            AssignAttri(sPrefix, false, "A67UsuariosKey", A67UsuariosKey);
            A96UsuariosVigIni = context.localUtil.CToD( cgiGet( edtUsuariosVigIni_Internalname), 2);
            AssignAttri(sPrefix, false, "A96UsuariosVigIni", context.localUtil.Format(A96UsuariosVigIni, "99/99/9999"));
            A70UsuariosVigFin = context.localUtil.CToD( cgiGet( edtUsuariosVigFin_Internalname), 2);
            n70UsuariosVigFin = false;
            AssignAttri(sPrefix, false, "A70UsuariosVigFin", context.localUtil.Format(A70UsuariosVigFin, "99/99/9999"));
            A92UsuariosFecCap = context.localUtil.CToT( cgiGet( edtUsuariosFecCap_Internalname));
            AssignAttri(sPrefix, false, "A92UsuariosFecCap", context.localUtil.TToC( A92UsuariosFecCap, 10, 8, 0, 3, "/", ":", " "));
            A93UsuariosIP = cgiGet( edtUsuariosIP_Internalname);
            AssignAttri(sPrefix, false, "A93UsuariosIP", A93UsuariosIP);
            A260UsuariosTelef = cgiGet( edtUsuariosTelef_Internalname);
            AssignAttri(sPrefix, false, "A260UsuariosTelef", A260UsuariosTelef);
            A261UsuariosCorreo = cgiGet( edtUsuariosCorreo_Internalname);
            AssignAttri(sPrefix, false, "A261UsuariosCorreo", A261UsuariosCorreo);
            A97UsuariosNomCompleto = cgiGet( edtUsuariosNomCompleto_Internalname);
            AssignAttri(sPrefix, false, "A97UsuariosNomCompleto", A97UsuariosNomCompleto);
            A24RolId = (int)(context.localUtil.CToN( cgiGet( edtRolId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
            A127RolNombre = cgiGet( edtRolNombre_Internalname);
            AssignAttri(sPrefix, false, "A127RolNombre", A127RolNombre);
            A275UsuariosSexoFor = cgiGet( edtUsuariosSexoFor_Internalname);
            AssignAttri(sPrefix, false, "A275UsuariosSexoFor", A275UsuariosSexoFor);
            cmbUsuariosStatus.CurrentValue = cgiGet( cmbUsuariosStatus_Internalname);
            A286UsuariosStatus = (short)(NumberUtil.Val( cgiGet( cmbUsuariosStatus_Internalname), "."));
            AssignAttri(sPrefix, false, "A286UsuariosStatus", StringUtil.Str( (decimal)(A286UsuariosStatus), 1, 0));
            A245UsuariosIcono = cgiGet( imgUsuariosIcono_Internalname);
            AssignAttri(sPrefix, false, "A245UsuariosIcono", A245UsuariosIcono);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"UsuariosGeneral");
            A24RolId = (int)(context.localUtil.CToN( cgiGet( edtRolId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
            forbiddenHiddens.Add("RolId", context.localUtil.Format( (decimal)(A24RolId), "ZZZZZZZZ9"));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("usuariosgeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusDescription = 403.ToString();
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E110Y2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E110Y2( )
      {
         /* Start Routine */
         if ( ! new isauthorized(context).executeUdp(  AV14Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV14Pgmname)));
            context.wjLocDisableFrm = 1;
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E120Y2( )
      {
         /* Load Routine */
         edtRolNombre_Link = formatLink("viewroles.aspx") + "?" + UrlEncode("" +A24RolId) + "," + UrlEncode(StringUtil.RTrim(""));
         AssignProp(sPrefix, false, edtRolNombre_Internalname, "Link", edtRolNombre_Link, true);
      }

      protected void E130Y2( )
      {
         /* 'DoUpdate' Routine */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "usuarios.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode("" +A11UsuariosId);
         CallWebObject(formatLink("usuarios.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E140Y2( )
      {
         /* 'DoDelete' Routine */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "usuarios.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode("" +A11UsuariosId);
         CallWebObject(formatLink("usuarios.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         AV8TrnContext = new SdtTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV14Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Usuarios";
         AV9TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "UsuariosId";
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6UsuariosId), 6, 0);
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "TransactionContext", "ADMINDATA1"));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A11UsuariosId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
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
         PA0Y2( ) ;
         WS0Y2( ) ;
         WE0Y2( ) ;
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
         sCtrlA11UsuariosId = (String)((String)getParm(obj,0));
      }

      public override void componentrestorestate( String sPPrefix ,
                                                  String sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0Y2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (String)getParm(obj,0);
         sSFPrefix = (String)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "usuariosgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0Y2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A11UsuariosId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
         }
         wcpOA11UsuariosId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA11UsuariosId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( A11UsuariosId != wcpOA11UsuariosId ) ) )
         {
            setjustcreated();
         }
         wcpOA11UsuariosId = A11UsuariosId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA11UsuariosId = cgiGet( sPrefix+"A11UsuariosId_CTRL");
         if ( StringUtil.Len( sCtrlA11UsuariosId) > 0 )
         {
            A11UsuariosId = (int)(context.localUtil.CToN( cgiGet( sCtrlA11UsuariosId), ",", "."));
            AssignAttri(sPrefix, false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
         }
         else
         {
            A11UsuariosId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"A11UsuariosId_PARM"), ",", "."));
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
         PA0Y2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0Y2( ) ;
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
         WS0Y2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A11UsuariosId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA11UsuariosId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A11UsuariosId_CTRL", StringUtil.RTrim( sCtrlA11UsuariosId));
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
         WE0Y2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714343233", true, true);
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
         context.AddJavascriptSource("usuariosgeneral.js", "?202262714343233", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbUsuariosTipo.Name = "USUARIOSTIPO";
         cmbUsuariosTipo.WebTags = "";
         cmbUsuariosTipo.addItem("1", "Administrador", 0);
         cmbUsuariosTipo.addItem("6", "Postulantes", 0);
         cmbUsuariosTipo.addItem("4", "Operaciones", 0);
         cmbUsuariosTipo.addItem("2", "Coordinador RYS", 0);
         cmbUsuariosTipo.addItem("5", "Reclutador", 0);
         cmbUsuariosTipo.addItem("3", "Candidatos", 0);
         if ( cmbUsuariosTipo.ItemCount > 0 )
         {
         }
         cmbUsuariosStatus.Name = "USUARIOSSTATUS";
         cmbUsuariosStatus.WebTags = "";
         cmbUsuariosStatus.addItem("1", "Activo", 0);
         cmbUsuariosStatus.addItem("0", "Inactivo", 0);
         if ( cmbUsuariosStatus.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         edtUsuariosCurp_Internalname = sPrefix+"USUARIOSCURP";
         edtUsuariosNombre_Internalname = sPrefix+"USUARIOSNOMBRE";
         edtUsuariosApPat_Internalname = sPrefix+"USUARIOSAPPAT";
         edtUsuariosApMat_Internalname = sPrefix+"USUARIOSAPMAT";
         edtUsuariosUsr_Internalname = sPrefix+"USUARIOSUSR";
         cmbUsuariosTipo_Internalname = sPrefix+"USUARIOSTIPO";
         edtUsuariosFecNacimiento_Internalname = sPrefix+"USUARIOSFECNACIMIENTO";
         edtUsuariosEdad_Internalname = sPrefix+"USUARIOSEDAD";
         edtUsuariosSexo_Internalname = sPrefix+"USUARIOSSEXO";
         edtUsuariosPwd_Internalname = sPrefix+"USUARIOSPWD";
         edtUsuariosKey_Internalname = sPrefix+"USUARIOSKEY";
         edtUsuariosVigIni_Internalname = sPrefix+"USUARIOSVIGINI";
         edtUsuariosVigFin_Internalname = sPrefix+"USUARIOSVIGFIN";
         edtUsuariosFecCap_Internalname = sPrefix+"USUARIOSFECCAP";
         edtUsuariosIP_Internalname = sPrefix+"USUARIOSIP";
         edtUsuariosTelef_Internalname = sPrefix+"USUARIOSTELEF";
         edtUsuariosCorreo_Internalname = sPrefix+"USUARIOSCORREO";
         edtUsuariosNomCompleto_Internalname = sPrefix+"USUARIOSNOMCOMPLETO";
         edtRolId_Internalname = sPrefix+"ROLID";
         edtRolNombre_Internalname = sPrefix+"ROLNOMBRE";
         edtUsuariosSexoFor_Internalname = sPrefix+"USUARIOSSEXOFOR";
         cmbUsuariosStatus_Internalname = sPrefix+"USUARIOSSTATUS";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
         imgUsuariosIcono_Internalname = sPrefix+"USUARIOSICONO";
         divImagestable_Internalname = sPrefix+"IMAGESTABLE";
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
         cmbUsuariosStatus_Jsonclick = "";
         cmbUsuariosStatus.Enabled = 0;
         edtUsuariosSexoFor_Jsonclick = "";
         edtUsuariosSexoFor_Enabled = 0;
         edtRolNombre_Jsonclick = "";
         edtRolNombre_Link = "";
         edtRolNombre_Enabled = 0;
         edtRolId_Jsonclick = "";
         edtRolId_Enabled = 0;
         edtUsuariosNomCompleto_Jsonclick = "";
         edtUsuariosNomCompleto_Enabled = 0;
         edtUsuariosCorreo_Jsonclick = "";
         edtUsuariosCorreo_Enabled = 0;
         edtUsuariosTelef_Jsonclick = "";
         edtUsuariosTelef_Enabled = 0;
         edtUsuariosIP_Jsonclick = "";
         edtUsuariosIP_Enabled = 0;
         edtUsuariosFecCap_Jsonclick = "";
         edtUsuariosFecCap_Enabled = 0;
         edtUsuariosVigFin_Jsonclick = "";
         edtUsuariosVigFin_Enabled = 0;
         edtUsuariosVigIni_Jsonclick = "";
         edtUsuariosVigIni_Enabled = 0;
         edtUsuariosKey_Jsonclick = "";
         edtUsuariosKey_Enabled = 0;
         edtUsuariosPwd_Jsonclick = "";
         edtUsuariosPwd_Enabled = 0;
         edtUsuariosSexo_Jsonclick = "";
         edtUsuariosSexo_Enabled = 0;
         edtUsuariosEdad_Jsonclick = "";
         edtUsuariosEdad_Enabled = 0;
         edtUsuariosFecNacimiento_Jsonclick = "";
         edtUsuariosFecNacimiento_Enabled = 0;
         cmbUsuariosTipo_Jsonclick = "";
         cmbUsuariosTipo.Enabled = 0;
         edtUsuariosUsr_Jsonclick = "";
         edtUsuariosUsr_Enabled = 0;
         edtUsuariosApMat_Jsonclick = "";
         edtUsuariosApMat_Enabled = 0;
         edtUsuariosApPat_Jsonclick = "";
         edtUsuariosApPat_Enabled = 0;
         edtUsuariosNombre_Jsonclick = "";
         edtUsuariosNombre_Enabled = 0;
         edtUsuariosCurp_Jsonclick = "";
         edtUsuariosCurp_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A24RolId',fld:'ROLID',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E130Y2',iparms:[{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E140Y2',iparms:[{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSNOMBRE","{handler:'Valid_Usuariosnombre',iparms:[]");
         setEventMetadata("VALID_USUARIOSNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSAPPAT","{handler:'Valid_Usuariosappat',iparms:[]");
         setEventMetadata("VALID_USUARIOSAPPAT",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSAPMAT","{handler:'Valid_Usuariosapmat',iparms:[]");
         setEventMetadata("VALID_USUARIOSAPMAT",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSSEXO","{handler:'Valid_Usuariossexo',iparms:[]");
         setEventMetadata("VALID_USUARIOSSEXO",",oparms:[]}");
         setEventMetadata("VALID_ROLID","{handler:'Valid_Rolid',iparms:[]");
         setEventMetadata("VALID_ROLID",",oparms:[]}");
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
         AV14Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A105UsuariosCurp = "";
         A66UsuariosNombre = "";
         A65UsuariosApPat = "";
         A64UsuariosApMat = "";
         A244UsuariosUsr = "";
         A255UsuariosFecNacimiento = DateTime.MinValue;
         A257UsuariosSexo = "";
         A68UsuariosPwd = "";
         A67UsuariosKey = "";
         A96UsuariosVigIni = DateTime.MinValue;
         A70UsuariosVigFin = DateTime.MinValue;
         A92UsuariosFecCap = (DateTime)(DateTime.MinValue);
         A93UsuariosIP = "";
         A260UsuariosTelef = "";
         A261UsuariosCorreo = "";
         A97UsuariosNomCompleto = "";
         A127RolNombre = "";
         A275UsuariosSexoFor = "";
         A245UsuariosIcono = "";
         A40000UsuariosIcono_GXI = "";
         sImgUrl = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H000Y2_A11UsuariosId = new int[1] ;
         H000Y2_A40000UsuariosIcono_GXI = new String[] {""} ;
         H000Y2_A286UsuariosStatus = new short[1] ;
         H000Y2_A127RolNombre = new String[] {""} ;
         H000Y2_A24RolId = new int[1] ;
         H000Y2_A261UsuariosCorreo = new String[] {""} ;
         H000Y2_A260UsuariosTelef = new String[] {""} ;
         H000Y2_A93UsuariosIP = new String[] {""} ;
         H000Y2_A92UsuariosFecCap = new DateTime[] {DateTime.MinValue} ;
         H000Y2_A70UsuariosVigFin = new DateTime[] {DateTime.MinValue} ;
         H000Y2_n70UsuariosVigFin = new bool[] {false} ;
         H000Y2_A96UsuariosVigIni = new DateTime[] {DateTime.MinValue} ;
         H000Y2_A67UsuariosKey = new String[] {""} ;
         H000Y2_A68UsuariosPwd = new String[] {""} ;
         H000Y2_A256UsuariosEdad = new short[1] ;
         H000Y2_A255UsuariosFecNacimiento = new DateTime[] {DateTime.MinValue} ;
         H000Y2_A272UsuariosTipo = new short[1] ;
         H000Y2_A244UsuariosUsr = new String[] {""} ;
         H000Y2_A105UsuariosCurp = new String[] {""} ;
         H000Y2_A64UsuariosApMat = new String[] {""} ;
         H000Y2_A65UsuariosApPat = new String[] {""} ;
         H000Y2_A66UsuariosNombre = new String[] {""} ;
         H000Y2_A257UsuariosSexo = new String[] {""} ;
         H000Y2_A245UsuariosIcono = new String[] {""} ;
         hsh = "";
         GXEncryptionTmp = "";
         AV8TrnContext = new SdtTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV9TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA11UsuariosId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usuariosgeneral__default(),
            new Object[][] {
                new Object[] {
               H000Y2_A11UsuariosId, H000Y2_A40000UsuariosIcono_GXI, H000Y2_A286UsuariosStatus, H000Y2_A127RolNombre, H000Y2_A24RolId, H000Y2_A261UsuariosCorreo, H000Y2_A260UsuariosTelef, H000Y2_A93UsuariosIP, H000Y2_A92UsuariosFecCap, H000Y2_A70UsuariosVigFin,
               H000Y2_n70UsuariosVigFin, H000Y2_A96UsuariosVigIni, H000Y2_A67UsuariosKey, H000Y2_A68UsuariosPwd, H000Y2_A256UsuariosEdad, H000Y2_A255UsuariosFecNacimiento, H000Y2_A272UsuariosTipo, H000Y2_A244UsuariosUsr, H000Y2_A105UsuariosCurp, H000Y2_A64UsuariosApMat,
               H000Y2_A65UsuariosApPat, H000Y2_A66UsuariosNombre, H000Y2_A257UsuariosSexo, H000Y2_A245UsuariosIcono
               }
            }
         );
         AV14Pgmname = "UsuariosGeneral";
         /* GeneXus formulas. */
         AV14Pgmname = "UsuariosGeneral";
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short A272UsuariosTipo ;
      private short A256UsuariosEdad ;
      private short A286UsuariosStatus ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int A11UsuariosId ;
      private int wcpOA11UsuariosId ;
      private int A24RolId ;
      private int edtUsuariosCurp_Enabled ;
      private int edtUsuariosNombre_Enabled ;
      private int edtUsuariosApPat_Enabled ;
      private int edtUsuariosApMat_Enabled ;
      private int edtUsuariosUsr_Enabled ;
      private int edtUsuariosFecNacimiento_Enabled ;
      private int edtUsuariosEdad_Enabled ;
      private int edtUsuariosSexo_Enabled ;
      private int edtUsuariosPwd_Enabled ;
      private int edtUsuariosKey_Enabled ;
      private int edtUsuariosVigIni_Enabled ;
      private int edtUsuariosVigFin_Enabled ;
      private int edtUsuariosFecCap_Enabled ;
      private int edtUsuariosIP_Enabled ;
      private int edtUsuariosTelef_Enabled ;
      private int edtUsuariosCorreo_Enabled ;
      private int edtUsuariosNomCompleto_Enabled ;
      private int edtRolId_Enabled ;
      private int edtRolNombre_Enabled ;
      private int edtUsuariosSexoFor_Enabled ;
      private int AV6UsuariosId ;
      private int idxLst ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sPrefix ;
      private String sCompPrefix ;
      private String sSFPrefix ;
      private String AV14Pgmname ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String divMaintable_Internalname ;
      private String TempTags ;
      private String ClassString ;
      private String StyleString ;
      private String bttBtnupdate_Internalname ;
      private String bttBtnupdate_Jsonclick ;
      private String bttBtndelete_Internalname ;
      private String bttBtndelete_Jsonclick ;
      private String divAttributestable_Internalname ;
      private String edtUsuariosCurp_Internalname ;
      private String edtUsuariosCurp_Jsonclick ;
      private String edtUsuariosNombre_Internalname ;
      private String edtUsuariosNombre_Jsonclick ;
      private String edtUsuariosApPat_Internalname ;
      private String edtUsuariosApPat_Jsonclick ;
      private String edtUsuariosApMat_Internalname ;
      private String edtUsuariosApMat_Jsonclick ;
      private String edtUsuariosUsr_Internalname ;
      private String edtUsuariosUsr_Jsonclick ;
      private String cmbUsuariosTipo_Internalname ;
      private String cmbUsuariosTipo_Jsonclick ;
      private String edtUsuariosFecNacimiento_Internalname ;
      private String edtUsuariosFecNacimiento_Jsonclick ;
      private String edtUsuariosEdad_Internalname ;
      private String edtUsuariosEdad_Jsonclick ;
      private String edtUsuariosSexo_Internalname ;
      private String A257UsuariosSexo ;
      private String edtUsuariosSexo_Jsonclick ;
      private String edtUsuariosPwd_Internalname ;
      private String edtUsuariosPwd_Jsonclick ;
      private String edtUsuariosKey_Internalname ;
      private String edtUsuariosKey_Jsonclick ;
      private String edtUsuariosVigIni_Internalname ;
      private String edtUsuariosVigIni_Jsonclick ;
      private String edtUsuariosVigFin_Internalname ;
      private String edtUsuariosVigFin_Jsonclick ;
      private String edtUsuariosFecCap_Internalname ;
      private String edtUsuariosFecCap_Jsonclick ;
      private String edtUsuariosIP_Internalname ;
      private String edtUsuariosIP_Jsonclick ;
      private String edtUsuariosTelef_Internalname ;
      private String A260UsuariosTelef ;
      private String edtUsuariosTelef_Jsonclick ;
      private String edtUsuariosCorreo_Internalname ;
      private String edtUsuariosCorreo_Jsonclick ;
      private String edtUsuariosNomCompleto_Internalname ;
      private String edtUsuariosNomCompleto_Jsonclick ;
      private String edtRolId_Internalname ;
      private String edtRolId_Jsonclick ;
      private String edtRolNombre_Internalname ;
      private String edtRolNombre_Link ;
      private String edtRolNombre_Jsonclick ;
      private String edtUsuariosSexoFor_Internalname ;
      private String A275UsuariosSexoFor ;
      private String edtUsuariosSexoFor_Jsonclick ;
      private String cmbUsuariosStatus_Internalname ;
      private String cmbUsuariosStatus_Jsonclick ;
      private String divImagestable_Internalname ;
      private String sImgUrl ;
      private String imgUsuariosIcono_Internalname ;
      private String sXEvt ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String scmdbuf ;
      private String hsh ;
      private String GXEncryptionTmp ;
      private String sCtrlA11UsuariosId ;
      private DateTime A92UsuariosFecCap ;
      private DateTime A255UsuariosFecNacimiento ;
      private DateTime A96UsuariosVigIni ;
      private DateTime A70UsuariosVigFin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool A245UsuariosIcono_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n70UsuariosVigFin ;
      private bool returnInSub ;
      private String A105UsuariosCurp ;
      private String A66UsuariosNombre ;
      private String A65UsuariosApPat ;
      private String A64UsuariosApMat ;
      private String A244UsuariosUsr ;
      private String A68UsuariosPwd ;
      private String A67UsuariosKey ;
      private String A93UsuariosIP ;
      private String A261UsuariosCorreo ;
      private String A97UsuariosNomCompleto ;
      private String A127RolNombre ;
      private String A40000UsuariosIcono_GXI ;
      private String A245UsuariosIcono ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbUsuariosTipo ;
      private GXCombobox cmbUsuariosStatus ;
      private IDataStoreProvider pr_default ;
      private int[] H000Y2_A11UsuariosId ;
      private String[] H000Y2_A40000UsuariosIcono_GXI ;
      private short[] H000Y2_A286UsuariosStatus ;
      private String[] H000Y2_A127RolNombre ;
      private int[] H000Y2_A24RolId ;
      private String[] H000Y2_A261UsuariosCorreo ;
      private String[] H000Y2_A260UsuariosTelef ;
      private String[] H000Y2_A93UsuariosIP ;
      private DateTime[] H000Y2_A92UsuariosFecCap ;
      private DateTime[] H000Y2_A70UsuariosVigFin ;
      private bool[] H000Y2_n70UsuariosVigFin ;
      private DateTime[] H000Y2_A96UsuariosVigIni ;
      private String[] H000Y2_A67UsuariosKey ;
      private String[] H000Y2_A68UsuariosPwd ;
      private short[] H000Y2_A256UsuariosEdad ;
      private DateTime[] H000Y2_A255UsuariosFecNacimiento ;
      private short[] H000Y2_A272UsuariosTipo ;
      private String[] H000Y2_A244UsuariosUsr ;
      private String[] H000Y2_A105UsuariosCurp ;
      private String[] H000Y2_A64UsuariosApMat ;
      private String[] H000Y2_A65UsuariosApPat ;
      private String[] H000Y2_A66UsuariosNombre ;
      private String[] H000Y2_A257UsuariosSexo ;
      private String[] H000Y2_A245UsuariosIcono ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private SdtTransactionContext AV8TrnContext ;
      private SdtTransactionContext_Attribute AV9TrnContextAtt ;
   }

   public class usuariosgeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH000Y2 ;
          prmH000Y2 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H000Y2", "SELECT T1.`UsuariosId`, T1.`UsuariosIcono_GXI`, T1.`UsuariosStatus`, T2.`RolNombre`, T1.`RolId`, T1.`UsuariosCorreo`, T1.`UsuariosTelef`, T1.`UsuariosIP`, T1.`UsuariosFecCap`, T1.`UsuariosVigFin`, T1.`UsuariosVigIni`, T1.`UsuariosKey`, T1.`UsuariosPwd`, T1.`UsuariosEdad`, T1.`UsuariosFecNacimiento`, T1.`UsuariosTipo`, T1.`UsuariosUsr`, T1.`UsuariosCurp`, T1.`UsuariosApMat`, T1.`UsuariosApPat`, T1.`UsuariosNombre`, T1.`UsuariosSexo`, T1.`UsuariosIcono` FROM (`Usuarios` T1 INNER JOIN `Roles` T2 ON T2.`RolId` = T1.`RolId`) WHERE T1.`UsuariosId` = ? ORDER BY T1.`UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Y2,1, GxCacheFrequency.OFF ,true,true )
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
                ((String[]) buf[1])[0] = rslt.getMultimediaUri(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                ((String[]) buf[3])[0] = rslt.getVarchar(4) ;
                ((int[]) buf[4])[0] = rslt.getInt(5) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
                ((String[]) buf[6])[0] = rslt.getString(7, 10) ;
                ((String[]) buf[7])[0] = rslt.getVarchar(8) ;
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9) ;
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(11) ;
                ((String[]) buf[12])[0] = rslt.getVarchar(12) ;
                ((String[]) buf[13])[0] = rslt.getVarchar(13) ;
                ((short[]) buf[14])[0] = rslt.getShort(14) ;
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(15) ;
                ((short[]) buf[16])[0] = rslt.getShort(16) ;
                ((String[]) buf[17])[0] = rslt.getVarchar(17) ;
                ((String[]) buf[18])[0] = rslt.getVarchar(18) ;
                ((String[]) buf[19])[0] = rslt.getVarchar(19) ;
                ((String[]) buf[20])[0] = rslt.getVarchar(20) ;
                ((String[]) buf[21])[0] = rslt.getVarchar(21) ;
                ((String[]) buf[22])[0] = rslt.getString(22, 1) ;
                ((String[]) buf[23])[0] = rslt.getMultimediaFile(23, rslt.getVarchar(2)) ;
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
       }
    }

 }

}
