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
   public class parametrosgeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public parametrosgeneral( )
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

      public parametrosgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_ParametroId )
      {
         this.A29ParametroId = aP0_ParametroId;
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
         chkParametroWebService = new GXCheckbox();
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
                  A29ParametroId = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri(sPrefix, false, "A29ParametroId", StringUtil.LTrimStr( (decimal)(A29ParametroId), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(String)sCompPrefix,(String)sSFPrefix,(int)A29ParametroId});
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
            PA192( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "ParametrosGeneral";
               context.Gx_err = 0;
               WS192( ) ;
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
            context.SendWebValue( "Parametros General") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714343821", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("parametrosgeneral.aspx") + "?" + UrlEncode("" +A29ParametroId)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA29ParametroId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA29ParametroId), 9, 0, ",", "")));
      }

      protected void RenderHtmlCloseForm192( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            context.AddJavascriptSource("parametrosgeneral.js", "?202262714343823", false, true);
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
         return "ParametrosGeneral" ;
      }

      public override String GetPgmdesc( )
      {
         return "Parametros General" ;
      }

      protected void WB190( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "parametrosgeneral.aspx");
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
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Modificar", bttBtnupdate_Jsonclick, 7, "Modificar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e11191_client"+"'", TempTags, "", 2, "HLP_ParametrosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Eliminar", bttBtndelete_Jsonclick, 7, "Eliminar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e12191_client"+"'", TempTags, "", 2, "HLP_ParametrosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributestable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametroId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtParametroId_Internalname, "Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtParametroId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A29ParametroId), 9, 0, ",", "")), ((edtParametroId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A29ParametroId), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A29ParametroId), "ZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtParametroId_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_ParametrosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametroHoraIni_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtParametroHoraIni_Internalname, "Ini", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtParametroHoraIni_Internalname, StringUtil.RTrim( A133ParametroHoraIni), StringUtil.RTrim( context.localUtil.Format( A133ParametroHoraIni, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroHoraIni_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtParametroHoraIni_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ParametrosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametroHoraFin_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtParametroHoraFin_Internalname, "Fin", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtParametroHoraFin_Internalname, StringUtil.RTrim( A132ParametroHoraFin), StringUtil.RTrim( context.localUtil.Format( A132ParametroHoraFin, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroHoraFin_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtParametroHoraFin_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ParametrosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametroValor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtParametroValor_Internalname, "Valor", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtParametroValor_Internalname, A129ParametroValor, "", "", 0, 1, edtParametroValor_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "1000", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_ParametrosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametroDesc_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtParametroDesc_Internalname, "Desc", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtParametroDesc_Internalname, A130ParametroDesc, StringUtil.RTrim( context.localUtil.Format( A130ParametroDesc, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroDesc_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtParametroDesc_Enabled, 0, "text", "", 35, "chr", 1, "row", 35, 0, 0, 0, 1, -1, -1, true, "DescripCorta", "left", true, "", "HLP_ParametrosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametroDescLarg_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtParametroDescLarg_Internalname, "Desc Larg", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtParametroDescLarg_Internalname, A131ParametroDescLarg, "", "", 0, 1, edtParametroDescLarg_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2048", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_ParametrosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkParametroWebService_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkParametroWebService_Internalname, "Web Services?", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkParametroWebService_Internalname, StringUtil.Str( (decimal)(A134ParametroWebService), 1, 0), "", "Web Services?", 1, chkParametroWebService.Enabled, "1", "", StyleString, ClassString, "", "", "");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrosBloqueo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtParametrosBloqueo_Internalname, "Bloqueo", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtParametrosBloqueo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A71ParametrosBloqueo), 4, 0, ",", "")), ((edtParametrosBloqueo_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A71ParametrosBloqueo), "ZZZ9")) : context.localUtil.Format( (decimal)(A71ParametrosBloqueo), "ZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrosBloqueo_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtParametrosBloqueo_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ParametrosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrosusername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtParametrosusername_Internalname, "Parametrosusername", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtParametrosusername_Internalname, A135Parametrosusername, StringUtil.RTrim( context.localUtil.Format( A135Parametrosusername, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrosusername_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtParametrosusername_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ParametrosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrospassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtParametrospassword_Internalname, "Parametrospassword", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtParametrospassword_Internalname, A136Parametrospassword, StringUtil.RTrim( context.localUtil.Format( A136Parametrospassword, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrospassword_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtParametrospassword_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ParametrosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrosAddHeader_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtParametrosAddHeader_Internalname, "Add Header", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtParametrosAddHeader_Internalname, A137ParametrosAddHeader, "", "", 0, 1, edtParametrosAddHeader_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_ParametrosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrosHost_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtParametrosHost_Internalname, "Host", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtParametrosHost_Internalname, A138ParametrosHost, StringUtil.RTrim( context.localUtil.Format( A138ParametrosHost, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrosHost_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtParametrosHost_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ParametrosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrosPort_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtParametrosPort_Internalname, "Port", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtParametrosPort_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A139ParametrosPort), 8, 0, ",", "")), ((edtParametrosPort_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A139ParametrosPort), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(A139ParametrosPort), "ZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrosPort_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtParametrosPort_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ParametrosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrosBaseUrl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtParametrosBaseUrl_Internalname, "Base Url", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtParametrosBaseUrl_Internalname, A140ParametrosBaseUrl, StringUtil.RTrim( context.localUtil.Format( A140ParametrosBaseUrl, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrosBaseUrl_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtParametrosBaseUrl_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ParametrosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrosExecute_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtParametrosExecute_Internalname, "Execute", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtParametrosExecute_Internalname, StringUtil.RTrim( A141ParametrosExecute), StringUtil.RTrim( context.localUtil.Format( A141ParametrosExecute, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrosExecute_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtParametrosExecute_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ParametrosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrosRuta_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtParametrosRuta_Internalname, "Ruta", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtParametrosRuta_Internalname, A142ParametrosRuta, StringUtil.RTrim( context.localUtil.Format( A142ParametrosRuta, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrosRuta_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtParametrosRuta_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ParametrosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrosRutaPDF_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtParametrosRutaPDF_Internalname, "Ruta PDF", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtParametrosRutaPDF_Internalname, A143ParametrosRutaPDF, "", "", 0, 1, edtParametrosRutaPDF_Enabled, 0, 80, "chr", 8, "row", StyleString, ClassString, "", "", "600", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_ParametrosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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

      protected void START192( )
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
               Form.Meta.addItem("description", "Parametros General", 0) ;
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
               STRUP190( ) ;
            }
         }
      }

      protected void WS192( )
      {
         START192( ) ;
         EVT192( ) ;
      }

      protected void EVT192( )
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
                                 STRUP190( ) ;
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
                                 STRUP190( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E13192 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP190( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E14192 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP190( ) ;
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
                                 STRUP190( ) ;
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

      protected void WE192( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm192( ) ;
            }
         }
      }

      protected void PA192( )
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
         A134ParametroWebService = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A134ParametroWebService), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri(sPrefix, false, "A134ParametroWebService", StringUtil.Str( (decimal)(A134ParametroWebService), 1, 0));
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF192( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "ParametrosGeneral";
         context.Gx_err = 0;
      }

      protected void RF192( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00192 */
            pr_default.execute(0, new Object[] {A29ParametroId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A143ParametrosRutaPDF = H00192_A143ParametrosRutaPDF[0];
               n143ParametrosRutaPDF = H00192_n143ParametrosRutaPDF[0];
               AssignAttri(sPrefix, false, "A143ParametrosRutaPDF", A143ParametrosRutaPDF);
               A142ParametrosRuta = H00192_A142ParametrosRuta[0];
               n142ParametrosRuta = H00192_n142ParametrosRuta[0];
               AssignAttri(sPrefix, false, "A142ParametrosRuta", A142ParametrosRuta);
               A141ParametrosExecute = H00192_A141ParametrosExecute[0];
               n141ParametrosExecute = H00192_n141ParametrosExecute[0];
               AssignAttri(sPrefix, false, "A141ParametrosExecute", A141ParametrosExecute);
               A140ParametrosBaseUrl = H00192_A140ParametrosBaseUrl[0];
               n140ParametrosBaseUrl = H00192_n140ParametrosBaseUrl[0];
               AssignAttri(sPrefix, false, "A140ParametrosBaseUrl", A140ParametrosBaseUrl);
               A139ParametrosPort = H00192_A139ParametrosPort[0];
               n139ParametrosPort = H00192_n139ParametrosPort[0];
               AssignAttri(sPrefix, false, "A139ParametrosPort", StringUtil.LTrimStr( (decimal)(A139ParametrosPort), 8, 0));
               A138ParametrosHost = H00192_A138ParametrosHost[0];
               n138ParametrosHost = H00192_n138ParametrosHost[0];
               AssignAttri(sPrefix, false, "A138ParametrosHost", A138ParametrosHost);
               A137ParametrosAddHeader = H00192_A137ParametrosAddHeader[0];
               n137ParametrosAddHeader = H00192_n137ParametrosAddHeader[0];
               AssignAttri(sPrefix, false, "A137ParametrosAddHeader", A137ParametrosAddHeader);
               A136Parametrospassword = H00192_A136Parametrospassword[0];
               n136Parametrospassword = H00192_n136Parametrospassword[0];
               AssignAttri(sPrefix, false, "A136Parametrospassword", A136Parametrospassword);
               A135Parametrosusername = H00192_A135Parametrosusername[0];
               n135Parametrosusername = H00192_n135Parametrosusername[0];
               AssignAttri(sPrefix, false, "A135Parametrosusername", A135Parametrosusername);
               A71ParametrosBloqueo = H00192_A71ParametrosBloqueo[0];
               n71ParametrosBloqueo = H00192_n71ParametrosBloqueo[0];
               AssignAttri(sPrefix, false, "A71ParametrosBloqueo", StringUtil.LTrimStr( (decimal)(A71ParametrosBloqueo), 4, 0));
               A134ParametroWebService = H00192_A134ParametroWebService[0];
               AssignAttri(sPrefix, false, "A134ParametroWebService", StringUtil.Str( (decimal)(A134ParametroWebService), 1, 0));
               A131ParametroDescLarg = H00192_A131ParametroDescLarg[0];
               AssignAttri(sPrefix, false, "A131ParametroDescLarg", A131ParametroDescLarg);
               A130ParametroDesc = H00192_A130ParametroDesc[0];
               AssignAttri(sPrefix, false, "A130ParametroDesc", A130ParametroDesc);
               A129ParametroValor = H00192_A129ParametroValor[0];
               AssignAttri(sPrefix, false, "A129ParametroValor", A129ParametroValor);
               A132ParametroHoraFin = H00192_A132ParametroHoraFin[0];
               AssignAttri(sPrefix, false, "A132ParametroHoraFin", A132ParametroHoraFin);
               A133ParametroHoraIni = H00192_A133ParametroHoraIni[0];
               AssignAttri(sPrefix, false, "A133ParametroHoraIni", A133ParametroHoraIni);
               /* Execute user event: Load */
               E14192 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB190( ) ;
         }
      }

      protected void send_integrity_lvl_hashes192( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "ParametrosGeneral";
         context.Gx_err = 0;
      }

      protected void STRUP190( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13192 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA29ParametroId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA29ParametroId"), ",", "."));
            /* Read variables values. */
            A133ParametroHoraIni = cgiGet( edtParametroHoraIni_Internalname);
            AssignAttri(sPrefix, false, "A133ParametroHoraIni", A133ParametroHoraIni);
            A132ParametroHoraFin = cgiGet( edtParametroHoraFin_Internalname);
            AssignAttri(sPrefix, false, "A132ParametroHoraFin", A132ParametroHoraFin);
            A129ParametroValor = cgiGet( edtParametroValor_Internalname);
            AssignAttri(sPrefix, false, "A129ParametroValor", A129ParametroValor);
            A130ParametroDesc = StringUtil.Upper( cgiGet( edtParametroDesc_Internalname));
            AssignAttri(sPrefix, false, "A130ParametroDesc", A130ParametroDesc);
            A131ParametroDescLarg = cgiGet( edtParametroDescLarg_Internalname);
            AssignAttri(sPrefix, false, "A131ParametroDescLarg", A131ParametroDescLarg);
            A134ParametroWebService = (short)(((StringUtil.StrCmp(cgiGet( chkParametroWebService_Internalname), "1")==0) ? 1 : 0));
            AssignAttri(sPrefix, false, "A134ParametroWebService", StringUtil.Str( (decimal)(A134ParametroWebService), 1, 0));
            A71ParametrosBloqueo = (short)(context.localUtil.CToN( cgiGet( edtParametrosBloqueo_Internalname), ",", "."));
            n71ParametrosBloqueo = false;
            AssignAttri(sPrefix, false, "A71ParametrosBloqueo", StringUtil.LTrimStr( (decimal)(A71ParametrosBloqueo), 4, 0));
            A135Parametrosusername = cgiGet( edtParametrosusername_Internalname);
            n135Parametrosusername = false;
            AssignAttri(sPrefix, false, "A135Parametrosusername", A135Parametrosusername);
            A136Parametrospassword = cgiGet( edtParametrospassword_Internalname);
            n136Parametrospassword = false;
            AssignAttri(sPrefix, false, "A136Parametrospassword", A136Parametrospassword);
            A137ParametrosAddHeader = cgiGet( edtParametrosAddHeader_Internalname);
            n137ParametrosAddHeader = false;
            AssignAttri(sPrefix, false, "A137ParametrosAddHeader", A137ParametrosAddHeader);
            A138ParametrosHost = cgiGet( edtParametrosHost_Internalname);
            n138ParametrosHost = false;
            AssignAttri(sPrefix, false, "A138ParametrosHost", A138ParametrosHost);
            A139ParametrosPort = (int)(context.localUtil.CToN( cgiGet( edtParametrosPort_Internalname), ",", "."));
            n139ParametrosPort = false;
            AssignAttri(sPrefix, false, "A139ParametrosPort", StringUtil.LTrimStr( (decimal)(A139ParametrosPort), 8, 0));
            A140ParametrosBaseUrl = cgiGet( edtParametrosBaseUrl_Internalname);
            n140ParametrosBaseUrl = false;
            AssignAttri(sPrefix, false, "A140ParametrosBaseUrl", A140ParametrosBaseUrl);
            A141ParametrosExecute = cgiGet( edtParametrosExecute_Internalname);
            n141ParametrosExecute = false;
            AssignAttri(sPrefix, false, "A141ParametrosExecute", A141ParametrosExecute);
            A142ParametrosRuta = cgiGet( edtParametrosRuta_Internalname);
            n142ParametrosRuta = false;
            AssignAttri(sPrefix, false, "A142ParametrosRuta", A142ParametrosRuta);
            A143ParametrosRutaPDF = cgiGet( edtParametrosRutaPDF_Internalname);
            n143ParametrosRutaPDF = false;
            AssignAttri(sPrefix, false, "A143ParametrosRutaPDF", A143ParametrosRutaPDF);
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
         E13192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E13192( )
      {
         /* Start Routine */
         if ( ! new isauthorized(context).executeUdp(  AV13Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV13Pgmname)));
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

      protected void E14192( )
      {
         /* Load Routine */
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         AV7TrnContext = new SdtTransactionContext(context);
         AV7TrnContext.gxTpr_Callerobject = AV13Pgmname;
         AV7TrnContext.gxTpr_Callerondelete = false;
         AV7TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV7TrnContext.gxTpr_Transactionname = "Parametros";
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "ParametroId";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6ParametroId), 9, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "TransactionContext", "ADMINDATA1"));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A29ParametroId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "A29ParametroId", StringUtil.LTrimStr( (decimal)(A29ParametroId), 9, 0));
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
         PA192( ) ;
         WS192( ) ;
         WE192( ) ;
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
         sCtrlA29ParametroId = (String)((String)getParm(obj,0));
      }

      public override void componentrestorestate( String sPPrefix ,
                                                  String sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA192( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (String)getParm(obj,0);
         sSFPrefix = (String)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "parametrosgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA192( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A29ParametroId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "A29ParametroId", StringUtil.LTrimStr( (decimal)(A29ParametroId), 9, 0));
         }
         wcpOA29ParametroId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA29ParametroId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( A29ParametroId != wcpOA29ParametroId ) ) )
         {
            setjustcreated();
         }
         wcpOA29ParametroId = A29ParametroId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA29ParametroId = cgiGet( sPrefix+"A29ParametroId_CTRL");
         if ( StringUtil.Len( sCtrlA29ParametroId) > 0 )
         {
            A29ParametroId = (int)(context.localUtil.CToN( cgiGet( sCtrlA29ParametroId), ",", "."));
            AssignAttri(sPrefix, false, "A29ParametroId", StringUtil.LTrimStr( (decimal)(A29ParametroId), 9, 0));
         }
         else
         {
            A29ParametroId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"A29ParametroId_PARM"), ",", "."));
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
         PA192( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS192( ) ;
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
         WS192( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A29ParametroId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29ParametroId), 9, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA29ParametroId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A29ParametroId_CTRL", StringUtil.RTrim( sCtrlA29ParametroId));
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
         WE192( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714343861", true, true);
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
         context.AddJavascriptSource("parametrosgeneral.js", "?202262714343861", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkParametroWebService.Name = "PARAMETROWEBSERVICE";
         chkParametroWebService.WebTags = "";
         chkParametroWebService.Caption = "";
         AssignProp(sPrefix, false, chkParametroWebService_Internalname, "TitleCaption", chkParametroWebService.Caption, true);
         chkParametroWebService.CheckedValue = "0";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         edtParametroId_Internalname = sPrefix+"PARAMETROID";
         edtParametroHoraIni_Internalname = sPrefix+"PARAMETROHORAINI";
         edtParametroHoraFin_Internalname = sPrefix+"PARAMETROHORAFIN";
         edtParametroValor_Internalname = sPrefix+"PARAMETROVALOR";
         edtParametroDesc_Internalname = sPrefix+"PARAMETRODESC";
         edtParametroDescLarg_Internalname = sPrefix+"PARAMETRODESCLARG";
         chkParametroWebService_Internalname = sPrefix+"PARAMETROWEBSERVICE";
         edtParametrosBloqueo_Internalname = sPrefix+"PARAMETROSBLOQUEO";
         edtParametrosusername_Internalname = sPrefix+"PARAMETROSUSERNAME";
         edtParametrospassword_Internalname = sPrefix+"PARAMETROSPASSWORD";
         edtParametrosAddHeader_Internalname = sPrefix+"PARAMETROSADDHEADER";
         edtParametrosHost_Internalname = sPrefix+"PARAMETROSHOST";
         edtParametrosPort_Internalname = sPrefix+"PARAMETROSPORT";
         edtParametrosBaseUrl_Internalname = sPrefix+"PARAMETROSBASEURL";
         edtParametrosExecute_Internalname = sPrefix+"PARAMETROSEXECUTE";
         edtParametrosRuta_Internalname = sPrefix+"PARAMETROSRUTA";
         edtParametrosRutaPDF_Internalname = sPrefix+"PARAMETROSRUTAPDF";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
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
         chkParametroWebService.Caption = "Web Services?";
         edtParametrosRutaPDF_Enabled = 0;
         edtParametrosRuta_Jsonclick = "";
         edtParametrosRuta_Enabled = 0;
         edtParametrosExecute_Jsonclick = "";
         edtParametrosExecute_Enabled = 0;
         edtParametrosBaseUrl_Jsonclick = "";
         edtParametrosBaseUrl_Enabled = 0;
         edtParametrosPort_Jsonclick = "";
         edtParametrosPort_Enabled = 0;
         edtParametrosHost_Jsonclick = "";
         edtParametrosHost_Enabled = 0;
         edtParametrosAddHeader_Enabled = 0;
         edtParametrospassword_Jsonclick = "";
         edtParametrospassword_Enabled = 0;
         edtParametrosusername_Jsonclick = "";
         edtParametrosusername_Enabled = 0;
         edtParametrosBloqueo_Jsonclick = "";
         edtParametrosBloqueo_Enabled = 0;
         chkParametroWebService.Enabled = 0;
         edtParametroDescLarg_Enabled = 0;
         edtParametroDesc_Jsonclick = "";
         edtParametroDesc_Enabled = 0;
         edtParametroValor_Enabled = 0;
         edtParametroHoraFin_Jsonclick = "";
         edtParametroHoraFin_Enabled = 0;
         edtParametroHoraIni_Jsonclick = "";
         edtParametroHoraIni_Enabled = 0;
         edtParametroId_Jsonclick = "";
         edtParametroId_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A29ParametroId',fld:'PARAMETROID',pic:'ZZZZZZZZ9'},{av:'A134ParametroWebService',fld:'PARAMETROWEBSERVICE',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A134ParametroWebService',fld:'PARAMETROWEBSERVICE',pic:'9'}]}");
         setEventMetadata("'DOUPDATE'","{handler:'E11191',iparms:[{av:'A29ParametroId',fld:'PARAMETROID',pic:'ZZZZZZZZ9'},{av:'A134ParametroWebService',fld:'PARAMETROWEBSERVICE',pic:'9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[{av:'A134ParametroWebService',fld:'PARAMETROWEBSERVICE',pic:'9'}]}");
         setEventMetadata("'DODELETE'","{handler:'E12191',iparms:[{av:'A29ParametroId',fld:'PARAMETROID',pic:'ZZZZZZZZ9'},{av:'A134ParametroWebService',fld:'PARAMETROWEBSERVICE',pic:'9'}]");
         setEventMetadata("'DODELETE'",",oparms:[{av:'A134ParametroWebService',fld:'PARAMETROWEBSERVICE',pic:'9'}]}");
         setEventMetadata("VALID_PARAMETROID","{handler:'Valid_Parametroid',iparms:[{av:'A134ParametroWebService',fld:'PARAMETROWEBSERVICE',pic:'9'}]");
         setEventMetadata("VALID_PARAMETROID",",oparms:[{av:'A134ParametroWebService',fld:'PARAMETROWEBSERVICE',pic:'9'}]}");
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
         AV13Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A133ParametroHoraIni = "";
         A132ParametroHoraFin = "";
         A129ParametroValor = "";
         A130ParametroDesc = "";
         A131ParametroDescLarg = "";
         A135Parametrosusername = "";
         A136Parametrospassword = "";
         A137ParametrosAddHeader = "";
         A138ParametrosHost = "";
         A140ParametrosBaseUrl = "";
         A141ParametrosExecute = "";
         A142ParametrosRuta = "";
         A143ParametrosRutaPDF = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H00192_A29ParametroId = new int[1] ;
         H00192_A143ParametrosRutaPDF = new String[] {""} ;
         H00192_n143ParametrosRutaPDF = new bool[] {false} ;
         H00192_A142ParametrosRuta = new String[] {""} ;
         H00192_n142ParametrosRuta = new bool[] {false} ;
         H00192_A141ParametrosExecute = new String[] {""} ;
         H00192_n141ParametrosExecute = new bool[] {false} ;
         H00192_A140ParametrosBaseUrl = new String[] {""} ;
         H00192_n140ParametrosBaseUrl = new bool[] {false} ;
         H00192_A139ParametrosPort = new int[1] ;
         H00192_n139ParametrosPort = new bool[] {false} ;
         H00192_A138ParametrosHost = new String[] {""} ;
         H00192_n138ParametrosHost = new bool[] {false} ;
         H00192_A137ParametrosAddHeader = new String[] {""} ;
         H00192_n137ParametrosAddHeader = new bool[] {false} ;
         H00192_A136Parametrospassword = new String[] {""} ;
         H00192_n136Parametrospassword = new bool[] {false} ;
         H00192_A135Parametrosusername = new String[] {""} ;
         H00192_n135Parametrosusername = new bool[] {false} ;
         H00192_A71ParametrosBloqueo = new short[1] ;
         H00192_n71ParametrosBloqueo = new bool[] {false} ;
         H00192_A134ParametroWebService = new short[1] ;
         H00192_A131ParametroDescLarg = new String[] {""} ;
         H00192_A130ParametroDesc = new String[] {""} ;
         H00192_A129ParametroValor = new String[] {""} ;
         H00192_A132ParametroHoraFin = new String[] {""} ;
         H00192_A133ParametroHoraIni = new String[] {""} ;
         AV7TrnContext = new SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA29ParametroId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.parametrosgeneral__default(),
            new Object[][] {
                new Object[] {
               H00192_A29ParametroId, H00192_A143ParametrosRutaPDF, H00192_n143ParametrosRutaPDF, H00192_A142ParametrosRuta, H00192_n142ParametrosRuta, H00192_A141ParametrosExecute, H00192_n141ParametrosExecute, H00192_A140ParametrosBaseUrl, H00192_n140ParametrosBaseUrl, H00192_A139ParametrosPort,
               H00192_n139ParametrosPort, H00192_A138ParametrosHost, H00192_n138ParametrosHost, H00192_A137ParametrosAddHeader, H00192_n137ParametrosAddHeader, H00192_A136Parametrospassword, H00192_n136Parametrospassword, H00192_A135Parametrosusername, H00192_n135Parametrosusername, H00192_A71ParametrosBloqueo,
               H00192_n71ParametrosBloqueo, H00192_A134ParametroWebService, H00192_A131ParametroDescLarg, H00192_A130ParametroDesc, H00192_A129ParametroValor, H00192_A132ParametroHoraFin, H00192_A133ParametroHoraIni
               }
            }
         );
         AV13Pgmname = "ParametrosGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "ParametrosGeneral";
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short A134ParametroWebService ;
      private short A71ParametrosBloqueo ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int A29ParametroId ;
      private int wcpOA29ParametroId ;
      private int edtParametroId_Enabled ;
      private int edtParametroHoraIni_Enabled ;
      private int edtParametroHoraFin_Enabled ;
      private int edtParametroValor_Enabled ;
      private int edtParametroDesc_Enabled ;
      private int edtParametroDescLarg_Enabled ;
      private int edtParametrosBloqueo_Enabled ;
      private int edtParametrosusername_Enabled ;
      private int edtParametrospassword_Enabled ;
      private int edtParametrosAddHeader_Enabled ;
      private int edtParametrosHost_Enabled ;
      private int A139ParametrosPort ;
      private int edtParametrosPort_Enabled ;
      private int edtParametrosBaseUrl_Enabled ;
      private int edtParametrosExecute_Enabled ;
      private int edtParametrosRuta_Enabled ;
      private int edtParametrosRutaPDF_Enabled ;
      private int AV6ParametroId ;
      private int idxLst ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sPrefix ;
      private String sCompPrefix ;
      private String sSFPrefix ;
      private String AV13Pgmname ;
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
      private String edtParametroId_Internalname ;
      private String edtParametroId_Jsonclick ;
      private String edtParametroHoraIni_Internalname ;
      private String A133ParametroHoraIni ;
      private String edtParametroHoraIni_Jsonclick ;
      private String edtParametroHoraFin_Internalname ;
      private String A132ParametroHoraFin ;
      private String edtParametroHoraFin_Jsonclick ;
      private String edtParametroValor_Internalname ;
      private String edtParametroDesc_Internalname ;
      private String edtParametroDesc_Jsonclick ;
      private String edtParametroDescLarg_Internalname ;
      private String chkParametroWebService_Internalname ;
      private String edtParametrosBloqueo_Internalname ;
      private String edtParametrosBloqueo_Jsonclick ;
      private String edtParametrosusername_Internalname ;
      private String edtParametrosusername_Jsonclick ;
      private String edtParametrospassword_Internalname ;
      private String edtParametrospassword_Jsonclick ;
      private String edtParametrosAddHeader_Internalname ;
      private String edtParametrosHost_Internalname ;
      private String edtParametrosHost_Jsonclick ;
      private String edtParametrosPort_Internalname ;
      private String edtParametrosPort_Jsonclick ;
      private String edtParametrosBaseUrl_Internalname ;
      private String edtParametrosBaseUrl_Jsonclick ;
      private String edtParametrosExecute_Internalname ;
      private String A141ParametrosExecute ;
      private String edtParametrosExecute_Jsonclick ;
      private String edtParametrosRuta_Internalname ;
      private String edtParametrosRuta_Jsonclick ;
      private String edtParametrosRutaPDF_Internalname ;
      private String sXEvt ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String scmdbuf ;
      private String sCtrlA29ParametroId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n143ParametrosRutaPDF ;
      private bool n142ParametrosRuta ;
      private bool n141ParametrosExecute ;
      private bool n140ParametrosBaseUrl ;
      private bool n139ParametrosPort ;
      private bool n138ParametrosHost ;
      private bool n137ParametrosAddHeader ;
      private bool n136Parametrospassword ;
      private bool n135Parametrosusername ;
      private bool n71ParametrosBloqueo ;
      private bool returnInSub ;
      private String A129ParametroValor ;
      private String A130ParametroDesc ;
      private String A131ParametroDescLarg ;
      private String A135Parametrosusername ;
      private String A136Parametrospassword ;
      private String A137ParametrosAddHeader ;
      private String A138ParametrosHost ;
      private String A140ParametrosBaseUrl ;
      private String A142ParametrosRuta ;
      private String A143ParametrosRutaPDF ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkParametroWebService ;
      private IDataStoreProvider pr_default ;
      private int[] H00192_A29ParametroId ;
      private String[] H00192_A143ParametrosRutaPDF ;
      private bool[] H00192_n143ParametrosRutaPDF ;
      private String[] H00192_A142ParametrosRuta ;
      private bool[] H00192_n142ParametrosRuta ;
      private String[] H00192_A141ParametrosExecute ;
      private bool[] H00192_n141ParametrosExecute ;
      private String[] H00192_A140ParametrosBaseUrl ;
      private bool[] H00192_n140ParametrosBaseUrl ;
      private int[] H00192_A139ParametrosPort ;
      private bool[] H00192_n139ParametrosPort ;
      private String[] H00192_A138ParametrosHost ;
      private bool[] H00192_n138ParametrosHost ;
      private String[] H00192_A137ParametrosAddHeader ;
      private bool[] H00192_n137ParametrosAddHeader ;
      private String[] H00192_A136Parametrospassword ;
      private bool[] H00192_n136Parametrospassword ;
      private String[] H00192_A135Parametrosusername ;
      private bool[] H00192_n135Parametrosusername ;
      private short[] H00192_A71ParametrosBloqueo ;
      private bool[] H00192_n71ParametrosBloqueo ;
      private short[] H00192_A134ParametroWebService ;
      private String[] H00192_A131ParametroDescLarg ;
      private String[] H00192_A130ParametroDesc ;
      private String[] H00192_A129ParametroValor ;
      private String[] H00192_A132ParametroHoraFin ;
      private String[] H00192_A133ParametroHoraIni ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private SdtTransactionContext AV7TrnContext ;
      private SdtTransactionContext_Attribute AV8TrnContextAtt ;
   }

   public class parametrosgeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00192 ;
          prmH00192 = new Object[] {
          new Object[] {"ParametroId",System.Data.DbType.Int32,9,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H00192", "SELECT `ParametroId`, `ParametrosRutaPDF`, `ParametrosRuta`, `ParametrosExecute`, `ParametrosBaseUrl`, `ParametrosPort`, `ParametrosHost`, `ParametrosAddHeader`, `Parametrospassword`, `Parametrosusername`, `ParametrosBloqueo`, `ParametroWebService`, `ParametroDescLarg`, `ParametroDesc`, `ParametroValor`, `ParametroHoraFin`, `ParametroHoraIni` FROM `Parametros` WHERE `ParametroId` = ? ORDER BY `ParametroId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00192,1, GxCacheFrequency.OFF ,true,true )
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
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((String[]) buf[3])[0] = rslt.getVarchar(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((String[]) buf[5])[0] = rslt.getString(4, 6) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((String[]) buf[7])[0] = rslt.getVarchar(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((String[]) buf[11])[0] = rslt.getVarchar(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((String[]) buf[13])[0] = rslt.getVarchar(8) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((String[]) buf[15])[0] = rslt.getVarchar(9) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((String[]) buf[17])[0] = rslt.getVarchar(10) ;
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11) ;
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((short[]) buf[21])[0] = rslt.getShort(12) ;
                ((String[]) buf[22])[0] = rslt.getVarchar(13) ;
                ((String[]) buf[23])[0] = rslt.getVarchar(14) ;
                ((String[]) buf[24])[0] = rslt.getVarchar(15) ;
                ((String[]) buf[25])[0] = rslt.getString(16, 8) ;
                ((String[]) buf[26])[0] = rslt.getString(17, 8) ;
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
