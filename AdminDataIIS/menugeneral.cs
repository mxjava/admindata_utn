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
   public class menugeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public menugeneral( )
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

      public menugeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( short aP0_MenuXid )
      {
         this.A1MenuXid = aP0_MenuXid;
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
         cmbMenXEst = new GXCombobox();
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
                  A1MenuXid = (short)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri(sPrefix, false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(String)sCompPrefix,(String)sSFPrefix,(short)A1MenuXid});
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
            PA232( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "MenuGeneral";
               context.Gx_err = 0;
               WS232( ) ;
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
            context.SendWebValue( "Menu General") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714343095", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("menugeneral.aspx") + "?" + UrlEncode("" +A1MenuXid)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA1MenuXid", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA1MenuXid), 4, 0, ",", "")));
      }

      protected void RenderHtmlCloseForm232( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            context.AddJavascriptSource("menugeneral.js", "?202262714343096", false, true);
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
         return "MenuGeneral" ;
      }

      public override String GetPgmdesc( )
      {
         return "Menu General" ;
      }

      protected void WB230( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "menugeneral.aspx");
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
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Modificar", bttBtnupdate_Jsonclick, 5, "Modificar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_MenuGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Eliminar", bttBtndelete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_MenuGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMenuXid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMenuXid_Internalname, "Xid", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMenuXid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1MenuXid), 4, 0, ",", "")), ((edtMenuXid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A1MenuXid), "ZZZ9")) : context.localUtil.Format( (decimal)(A1MenuXid), "ZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMenuXid_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtMenuXid_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_MenuGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMenuXDesc_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMenuXDesc_Internalname, "XDesc", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMenuXDesc_Internalname, A2MenuXDesc, StringUtil.RTrim( context.localUtil.Format( A2MenuXDesc, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMenuXDesc_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtMenuXDesc_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_MenuGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMenuXPosi_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMenuXPosi_Internalname, "Position", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMenuXPosi_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3MenuXPosi), 4, 0, ",", "")), ((edtMenuXPosi_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A3MenuXPosi), "ZZZ9")) : context.localUtil.Format( (decimal)(A3MenuXPosi), "ZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMenuXPosi_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtMenuXPosi_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_MenuGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMenXUrl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMenXUrl_Internalname, "Url", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMenXUrl_Internalname, A4MenXUrl, StringUtil.RTrim( context.localUtil.Format( A4MenXUrl, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", A4MenXUrl, "_blank", "", "", edtMenXUrl_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtMenXUrl_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Url", "left", true, "", "HLP_MenuGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbMenXEst_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbMenXEst_Internalname, "Estado", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbMenXEst, cmbMenXEst_Internalname, StringUtil.RTrim( A5MenXEst), 1, cmbMenXEst_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbMenXEst.Enabled, 0, 0, 0, "em", 0, "", "", "ReadonlyAttribute", "", "", "", "", true, "HLP_MenuGeneral.htm");
            cmbMenXEst.CurrentValue = StringUtil.RTrim( A5MenXEst);
            AssignProp(sPrefix, false, cmbMenXEst_Internalname, "Values", (String)(cmbMenXEst.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMenPadre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMenPadre_Internalname, "Padre", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMenPadre_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A258MenPadre), 4, 0, ",", "")), ((edtMenPadre_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A258MenPadre), "ZZZ9")) : context.localUtil.Format( (decimal)(A258MenPadre), "ZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMenPadre_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtMenPadre_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_MenuGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDescripcion_Internalname, "Descripcion", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtDescripcion_Internalname, A262Descripcion, StringUtil.RTrim( context.localUtil.Format( A262Descripcion, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDescripcion_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_MenuGeneral.htm");
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
            A259MenIcono_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A259MenIcono))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000MenIcono_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A259MenIcono)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A259MenIcono)) ? A40000MenIcono_GXI : context.PathToRelativeUrl( A259MenIcono));
            GxWebStd.gx_bitmap( context, imgMenIcono_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A259MenIcono_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_MenuGeneral.htm");
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

      protected void START232( )
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
               Form.Meta.addItem("description", "Menu General", 0) ;
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
               STRUP230( ) ;
            }
         }
      }

      protected void WS232( )
      {
         START232( ) ;
         EVT232( ) ;
      }

      protected void EVT232( )
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
                                 STRUP230( ) ;
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
                                 STRUP230( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11232 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP230( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12232 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP230( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E13232 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP230( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E14232 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP230( ) ;
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
                                 STRUP230( ) ;
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

      protected void WE232( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm232( ) ;
            }
         }
      }

      protected void PA232( )
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
         if ( cmbMenXEst.ItemCount > 0 )
         {
            A5MenXEst = cmbMenXEst.getValidValue(A5MenXEst);
            n5MenXEst = false;
            AssignAttri(sPrefix, false, "A5MenXEst", A5MenXEst);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbMenXEst.CurrentValue = StringUtil.RTrim( A5MenXEst);
            AssignProp(sPrefix, false, cmbMenXEst_Internalname, "Values", cmbMenXEst.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF232( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "MenuGeneral";
         context.Gx_err = 0;
      }

      protected void RF232( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00232 */
            pr_default.execute(0, new Object[] {A1MenuXid});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A40000MenIcono_GXI = H00232_A40000MenIcono_GXI[0];
               n40000MenIcono_GXI = H00232_n40000MenIcono_GXI[0];
               AssignProp(sPrefix, false, imgMenIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A259MenIcono)) ? A40000MenIcono_GXI : context.convertURL( context.PathToRelativeUrl( A259MenIcono))), true);
               AssignProp(sPrefix, false, imgMenIcono_Internalname, "SrcSet", context.GetImageSrcSet( A259MenIcono), true);
               A262Descripcion = H00232_A262Descripcion[0];
               AssignAttri(sPrefix, false, "A262Descripcion", A262Descripcion);
               A258MenPadre = H00232_A258MenPadre[0];
               n258MenPadre = H00232_n258MenPadre[0];
               AssignAttri(sPrefix, false, "A258MenPadre", StringUtil.LTrimStr( (decimal)(A258MenPadre), 4, 0));
               A5MenXEst = H00232_A5MenXEst[0];
               n5MenXEst = H00232_n5MenXEst[0];
               AssignAttri(sPrefix, false, "A5MenXEst", A5MenXEst);
               A4MenXUrl = H00232_A4MenXUrl[0];
               n4MenXUrl = H00232_n4MenXUrl[0];
               AssignAttri(sPrefix, false, "A4MenXUrl", A4MenXUrl);
               A3MenuXPosi = H00232_A3MenuXPosi[0];
               n3MenuXPosi = H00232_n3MenuXPosi[0];
               AssignAttri(sPrefix, false, "A3MenuXPosi", StringUtil.LTrimStr( (decimal)(A3MenuXPosi), 4, 0));
               A2MenuXDesc = H00232_A2MenuXDesc[0];
               n2MenuXDesc = H00232_n2MenuXDesc[0];
               AssignAttri(sPrefix, false, "A2MenuXDesc", A2MenuXDesc);
               A259MenIcono = H00232_A259MenIcono[0];
               n259MenIcono = H00232_n259MenIcono[0];
               AssignAttri(sPrefix, false, "A259MenIcono", A259MenIcono);
               AssignProp(sPrefix, false, imgMenIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A259MenIcono)) ? A40000MenIcono_GXI : context.convertURL( context.PathToRelativeUrl( A259MenIcono))), true);
               AssignProp(sPrefix, false, imgMenIcono_Internalname, "SrcSet", context.GetImageSrcSet( A259MenIcono), true);
               /* Execute user event: Load */
               E12232 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB230( ) ;
         }
      }

      protected void send_integrity_lvl_hashes232( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "MenuGeneral";
         context.Gx_err = 0;
      }

      protected void STRUP230( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11232 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA1MenuXid = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA1MenuXid"), ",", "."));
            /* Read variables values. */
            A2MenuXDesc = cgiGet( edtMenuXDesc_Internalname);
            n2MenuXDesc = false;
            AssignAttri(sPrefix, false, "A2MenuXDesc", A2MenuXDesc);
            A3MenuXPosi = (short)(context.localUtil.CToN( cgiGet( edtMenuXPosi_Internalname), ",", "."));
            n3MenuXPosi = false;
            AssignAttri(sPrefix, false, "A3MenuXPosi", StringUtil.LTrimStr( (decimal)(A3MenuXPosi), 4, 0));
            A4MenXUrl = cgiGet( edtMenXUrl_Internalname);
            n4MenXUrl = false;
            AssignAttri(sPrefix, false, "A4MenXUrl", A4MenXUrl);
            cmbMenXEst.CurrentValue = cgiGet( cmbMenXEst_Internalname);
            A5MenXEst = cgiGet( cmbMenXEst_Internalname);
            n5MenXEst = false;
            AssignAttri(sPrefix, false, "A5MenXEst", A5MenXEst);
            A258MenPadre = (short)(context.localUtil.CToN( cgiGet( edtMenPadre_Internalname), ",", "."));
            n258MenPadre = false;
            AssignAttri(sPrefix, false, "A258MenPadre", StringUtil.LTrimStr( (decimal)(A258MenPadre), 4, 0));
            A262Descripcion = cgiGet( edtDescripcion_Internalname);
            AssignAttri(sPrefix, false, "A262Descripcion", A262Descripcion);
            A259MenIcono = cgiGet( imgMenIcono_Internalname);
            n259MenIcono = false;
            AssignAttri(sPrefix, false, "A259MenIcono", A259MenIcono);
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
         E11232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11232( )
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

      protected void E12232( )
      {
         /* Load Routine */
      }

      protected void E13232( )
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
         GXEncryptionTmp = "menu.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode("" +A1MenuXid);
         CallWebObject(formatLink("menu.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E14232( )
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
         GXEncryptionTmp = "menu.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode("" +A1MenuXid);
         CallWebObject(formatLink("menu.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         AV7TrnContext = new SdtTransactionContext(context);
         AV7TrnContext.gxTpr_Callerobject = AV13Pgmname;
         AV7TrnContext.gxTpr_Callerondelete = false;
         AV7TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV7TrnContext.gxTpr_Transactionname = "Menu";
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "MenuXid";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6MenuXid), 4, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "TransactionContext", "ADMINDATA1"));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A1MenuXid = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
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
         PA232( ) ;
         WS232( ) ;
         WE232( ) ;
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
         sCtrlA1MenuXid = (String)((String)getParm(obj,0));
      }

      public override void componentrestorestate( String sPPrefix ,
                                                  String sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA232( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (String)getParm(obj,0);
         sSFPrefix = (String)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "menugeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA232( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A1MenuXid = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
         }
         wcpOA1MenuXid = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA1MenuXid"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( A1MenuXid != wcpOA1MenuXid ) ) )
         {
            setjustcreated();
         }
         wcpOA1MenuXid = A1MenuXid;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA1MenuXid = cgiGet( sPrefix+"A1MenuXid_CTRL");
         if ( StringUtil.Len( sCtrlA1MenuXid) > 0 )
         {
            A1MenuXid = (short)(context.localUtil.CToN( cgiGet( sCtrlA1MenuXid), ",", "."));
            AssignAttri(sPrefix, false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
         }
         else
         {
            A1MenuXid = (short)(context.localUtil.CToN( cgiGet( sPrefix+"A1MenuXid_PARM"), ",", "."));
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
         PA232( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS232( ) ;
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
         WS232( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A1MenuXid_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1MenuXid), 4, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA1MenuXid)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A1MenuXid_CTRL", StringUtil.RTrim( sCtrlA1MenuXid));
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
         WE232( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714343121", true, true);
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
         context.AddJavascriptSource("menugeneral.js", "?202262714343121", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbMenXEst.Name = "MENXEST";
         cmbMenXEst.WebTags = "";
         cmbMenXEst.addItem("A", "Activo", 0);
         cmbMenXEst.addItem("I", "Inactivo", 0);
         if ( cmbMenXEst.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         edtMenuXid_Internalname = sPrefix+"MENUXID";
         edtMenuXDesc_Internalname = sPrefix+"MENUXDESC";
         edtMenuXPosi_Internalname = sPrefix+"MENUXPOSI";
         edtMenXUrl_Internalname = sPrefix+"MENXURL";
         cmbMenXEst_Internalname = sPrefix+"MENXEST";
         edtMenPadre_Internalname = sPrefix+"MENPADRE";
         edtDescripcion_Internalname = sPrefix+"DESCRIPCION";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
         imgMenIcono_Internalname = sPrefix+"MENICONO";
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
         edtDescripcion_Jsonclick = "";
         edtDescripcion_Enabled = 0;
         edtMenPadre_Jsonclick = "";
         edtMenPadre_Enabled = 0;
         cmbMenXEst_Jsonclick = "";
         cmbMenXEst.Enabled = 0;
         edtMenXUrl_Jsonclick = "";
         edtMenXUrl_Enabled = 0;
         edtMenuXPosi_Jsonclick = "";
         edtMenuXPosi_Enabled = 0;
         edtMenuXDesc_Jsonclick = "";
         edtMenuXDesc_Enabled = 0;
         edtMenuXid_Jsonclick = "";
         edtMenuXid_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A1MenuXid',fld:'MENUXID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E13232',iparms:[{av:'A1MenuXid',fld:'MENUXID',pic:'ZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E14232',iparms:[{av:'A1MenuXid',fld:'MENUXID',pic:'ZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_MENUXID","{handler:'Valid_Menuxid',iparms:[]");
         setEventMetadata("VALID_MENUXID",",oparms:[]}");
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
         A2MenuXDesc = "";
         A4MenXUrl = "";
         A5MenXEst = "";
         A262Descripcion = "";
         A259MenIcono = "";
         A40000MenIcono_GXI = "";
         sImgUrl = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H00232_A1MenuXid = new short[1] ;
         H00232_A40000MenIcono_GXI = new String[] {""} ;
         H00232_n40000MenIcono_GXI = new bool[] {false} ;
         H00232_A262Descripcion = new String[] {""} ;
         H00232_A258MenPadre = new short[1] ;
         H00232_n258MenPadre = new bool[] {false} ;
         H00232_A5MenXEst = new String[] {""} ;
         H00232_n5MenXEst = new bool[] {false} ;
         H00232_A4MenXUrl = new String[] {""} ;
         H00232_n4MenXUrl = new bool[] {false} ;
         H00232_A3MenuXPosi = new short[1] ;
         H00232_n3MenuXPosi = new bool[] {false} ;
         H00232_A2MenuXDesc = new String[] {""} ;
         H00232_n2MenuXDesc = new bool[] {false} ;
         H00232_A259MenIcono = new String[] {""} ;
         H00232_n259MenIcono = new bool[] {false} ;
         GXEncryptionTmp = "";
         AV7TrnContext = new SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA1MenuXid = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.menugeneral__default(),
            new Object[][] {
                new Object[] {
               H00232_A1MenuXid, H00232_A40000MenIcono_GXI, H00232_n40000MenIcono_GXI, H00232_A262Descripcion, H00232_A258MenPadre, H00232_n258MenPadre, H00232_A5MenXEst, H00232_n5MenXEst, H00232_A4MenXUrl, H00232_n4MenXUrl,
               H00232_A3MenuXPosi, H00232_n3MenuXPosi, H00232_A2MenuXDesc, H00232_n2MenuXDesc, H00232_A259MenIcono, H00232_n259MenIcono
               }
            }
         );
         AV13Pgmname = "MenuGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "MenuGeneral";
         context.Gx_err = 0;
      }

      private short A1MenuXid ;
      private short wcpOA1MenuXid ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short A3MenuXPosi ;
      private short A258MenPadre ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV6MenuXid ;
      private short nGXWrapped ;
      private int edtMenuXid_Enabled ;
      private int edtMenuXDesc_Enabled ;
      private int edtMenuXPosi_Enabled ;
      private int edtMenXUrl_Enabled ;
      private int edtMenPadre_Enabled ;
      private int edtDescripcion_Enabled ;
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
      private String edtMenuXid_Internalname ;
      private String edtMenuXid_Jsonclick ;
      private String edtMenuXDesc_Internalname ;
      private String edtMenuXDesc_Jsonclick ;
      private String edtMenuXPosi_Internalname ;
      private String edtMenuXPosi_Jsonclick ;
      private String edtMenXUrl_Internalname ;
      private String edtMenXUrl_Jsonclick ;
      private String cmbMenXEst_Internalname ;
      private String A5MenXEst ;
      private String cmbMenXEst_Jsonclick ;
      private String edtMenPadre_Internalname ;
      private String edtMenPadre_Jsonclick ;
      private String edtDescripcion_Internalname ;
      private String edtDescripcion_Jsonclick ;
      private String divImagestable_Internalname ;
      private String sImgUrl ;
      private String imgMenIcono_Internalname ;
      private String sXEvt ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String scmdbuf ;
      private String GXEncryptionTmp ;
      private String sCtrlA1MenuXid ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool A259MenIcono_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n5MenXEst ;
      private bool gxdyncontrolsrefreshing ;
      private bool n40000MenIcono_GXI ;
      private bool n258MenPadre ;
      private bool n4MenXUrl ;
      private bool n3MenuXPosi ;
      private bool n2MenuXDesc ;
      private bool n259MenIcono ;
      private bool returnInSub ;
      private String A2MenuXDesc ;
      private String A4MenXUrl ;
      private String A262Descripcion ;
      private String A40000MenIcono_GXI ;
      private String A259MenIcono ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbMenXEst ;
      private IDataStoreProvider pr_default ;
      private short[] H00232_A1MenuXid ;
      private String[] H00232_A40000MenIcono_GXI ;
      private bool[] H00232_n40000MenIcono_GXI ;
      private String[] H00232_A262Descripcion ;
      private short[] H00232_A258MenPadre ;
      private bool[] H00232_n258MenPadre ;
      private String[] H00232_A5MenXEst ;
      private bool[] H00232_n5MenXEst ;
      private String[] H00232_A4MenXUrl ;
      private bool[] H00232_n4MenXUrl ;
      private short[] H00232_A3MenuXPosi ;
      private bool[] H00232_n3MenuXPosi ;
      private String[] H00232_A2MenuXDesc ;
      private bool[] H00232_n2MenuXDesc ;
      private String[] H00232_A259MenIcono ;
      private bool[] H00232_n259MenIcono ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private SdtTransactionContext AV7TrnContext ;
      private SdtTransactionContext_Attribute AV8TrnContextAtt ;
   }

   public class menugeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00232 ;
          prmH00232 = new Object[] {
          new Object[] {"MenuXid",System.Data.DbType.Int16,4,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H00232", "SELECT `MenuXid`, `MenIcono_GXI`, `Descripcion`, `MenPadre`, `MenXEst`, `MenXUrl`, `MenuXPosi`, `MenuXDesc`, `MenIcono` FROM `Menu` WHERE `MenuXid` = ? ORDER BY `MenuXid` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00232,1, GxCacheFrequency.OFF ,true,true )
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
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((String[]) buf[1])[0] = rslt.getMultimediaUri(2) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((String[]) buf[3])[0] = rslt.getVarchar(3) ;
                ((short[]) buf[4])[0] = rslt.getShort(4) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((String[]) buf[6])[0] = rslt.getString(5, 1) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((String[]) buf[8])[0] = rslt.getVarchar(6) ;
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((short[]) buf[10])[0] = rslt.getShort(7) ;
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((String[]) buf[12])[0] = rslt.getVarchar(8) ;
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((String[]) buf[14])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(2)) ;
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
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
                stmt.SetParameter(1, (short)parms[0]);
                return;
       }
    }

 }

}
