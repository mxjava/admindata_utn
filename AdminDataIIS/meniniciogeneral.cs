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
   public class meniniciogeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public meniniciogeneral( )
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

      public meniniciogeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_menInicioId )
      {
         this.A58menInicioId = aP0_menInicioId;
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
         cmbmenInicioStat = new GXCombobox();
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
                  A58menInicioId = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri(sPrefix, false, "A58menInicioId", StringUtil.LTrimStr( (decimal)(A58menInicioId), 6, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(String)sCompPrefix,(String)sSFPrefix,(int)A58menInicioId});
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
            PA0V2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "menInicioGeneral";
               context.Gx_err = 0;
               WS0V2( ) ;
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
            context.SendWebValue( "men Inicio General") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714343835", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("meniniciogeneral.aspx") + "?" + UrlEncode("" +A58menInicioId)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA58menInicioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA58menInicioId), 6, 0, ",", "")));
      }

      protected void RenderHtmlCloseForm0V2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            context.AddJavascriptSource("meniniciogeneral.js", "?202262714343836", false, true);
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
         return "menInicioGeneral" ;
      }

      public override String GetPgmdesc( )
      {
         return "men Inicio General" ;
      }

      protected void WB0V0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "meniniciogeneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Modificar", bttBtnupdate_Jsonclick, 7, "Modificar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e110v1_client"+"'", TempTags, "", 2, "HLP_menInicioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Eliminar", bttBtndelete_Jsonclick, 7, "Eliminar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e120v1_client"+"'", TempTags, "", 2, "HLP_menInicioGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtmenInicioId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtmenInicioId_Internalname, "Clave del mensaje", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtmenInicioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A58menInicioId), 6, 0, ",", "")), ((edtmenInicioId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A58menInicioId), "ZZZZZ9")) : context.localUtil.Format( (decimal)(A58menInicioId), "ZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtmenInicioId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtmenInicioId_Enabled, 0, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "NumId", "right", false, "", "HLP_menInicioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtmenInicioDes_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtmenInicioDes_Internalname, "Mensaje", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtmenInicioDes_Internalname, A150menInicioDes, "", "", 0, 1, edtmenInicioDes_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_menInicioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtmenInicioFecIni_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtmenInicioFecIni_Internalname, "Fecha Inicio", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtmenInicioFecIni_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtmenInicioFecIni_Internalname, context.localUtil.Format(A186menInicioFecIni, "99/99/9999"), context.localUtil.Format( A186menInicioFecIni, "99/99/9999"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtmenInicioFecIni_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtmenInicioFecIni_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "Fecha", "right", false, "", "HLP_menInicioGeneral.htm");
            GxWebStd.gx_bitmap( context, edtmenInicioFecIni_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtmenInicioFecIni_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_menInicioGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtmenInicioFecFin_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtmenInicioFecFin_Internalname, "Fecha Fin", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtmenInicioFecFin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtmenInicioFecFin_Internalname, context.localUtil.Format(A76menInicioFecFin, "99/99/9999"), context.localUtil.Format( A76menInicioFecFin, "99/99/9999"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtmenInicioFecFin_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtmenInicioFecFin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "Fecha", "right", false, "", "HLP_menInicioGeneral.htm");
            GxWebStd.gx_bitmap( context, edtmenInicioFecFin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtmenInicioFecFin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_menInicioGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbmenInicioStat_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbmenInicioStat_Internalname, "Status", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbmenInicioStat, cmbmenInicioStat_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A77menInicioStat), 1, 0)), 1, cmbmenInicioStat_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbmenInicioStat.Enabled, 0, 0, 0, "em", 0, "", "", "ReadonlyAttribute", "", "", "", "", true, "HLP_menInicioGeneral.htm");
            cmbmenInicioStat.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A77menInicioStat), 1, 0));
            AssignProp(sPrefix, false, cmbmenInicioStat_Internalname, "Values", (String)(cmbmenInicioStat.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtmenInicioFecCap_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtmenInicioFecCap_Internalname, "Fecha/Hora Captura", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtmenInicioFecCap_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtmenInicioFecCap_Internalname, context.localUtil.TToC( A185menInicioFecCap, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A185menInicioFecCap, "99/99/9999 99:99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtmenInicioFecCap_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtmenInicioFecCap_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 1, -1, 0, true, "FechaTiempo", "right", false, "", "HLP_menInicioGeneral.htm");
            GxWebStd.gx_bitmap( context, edtmenInicioFecCap_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtmenInicioFecCap_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_menInicioGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtsgUsrMenId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtsgUsrMenId_Internalname, "Clave de usuario", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtsgUsrMenId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A59sgUsrMenId), 6, 0, ",", "")), ((edtsgUsrMenId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A59sgUsrMenId), "ZZZZZ9")) : context.localUtil.Format( (decimal)(A59sgUsrMenId), "ZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsgUsrMenId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtsgUsrMenId_Enabled, 0, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_menInicioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtsgUsrMenNom_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtsgUsrMenNom_Internalname, "Usuario Captura", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtsgUsrMenNom_Internalname, A187sgUsrMenNom, StringUtil.RTrim( context.localUtil.Format( A187sgUsrMenNom, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsgUsrMenNom_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtsgUsrMenNom_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_menInicioGeneral.htm");
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

      protected void START0V2( )
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
               Form.Meta.addItem("description", "men Inicio General", 0) ;
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
               STRUP0V0( ) ;
            }
         }
      }

      protected void WS0V2( )
      {
         START0V2( ) ;
         EVT0V2( ) ;
      }

      protected void EVT0V2( )
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
                                 STRUP0V0( ) ;
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
                                 STRUP0V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E130V2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E140V2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0V0( ) ;
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
                                 STRUP0V0( ) ;
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

      protected void WE0V2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0V2( ) ;
            }
         }
      }

      protected void PA0V2( )
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
         if ( cmbmenInicioStat.ItemCount > 0 )
         {
            A77menInicioStat = (short)(NumberUtil.Val( cmbmenInicioStat.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A77menInicioStat), 1, 0))), "."));
            AssignAttri(sPrefix, false, "A77menInicioStat", StringUtil.Str( (decimal)(A77menInicioStat), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbmenInicioStat.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A77menInicioStat), 1, 0));
            AssignProp(sPrefix, false, cmbmenInicioStat_Internalname, "Values", cmbmenInicioStat.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "menInicioGeneral";
         context.Gx_err = 0;
      }

      protected void RF0V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H000V2 */
            pr_default.execute(0, new Object[] {A58menInicioId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A187sgUsrMenNom = H000V2_A187sgUsrMenNom[0];
               AssignAttri(sPrefix, false, "A187sgUsrMenNom", A187sgUsrMenNom);
               A59sgUsrMenId = H000V2_A59sgUsrMenId[0];
               AssignAttri(sPrefix, false, "A59sgUsrMenId", StringUtil.LTrimStr( (decimal)(A59sgUsrMenId), 6, 0));
               A185menInicioFecCap = H000V2_A185menInicioFecCap[0];
               AssignAttri(sPrefix, false, "A185menInicioFecCap", context.localUtil.TToC( A185menInicioFecCap, 10, 8, 0, 3, "/", ":", " "));
               A77menInicioStat = H000V2_A77menInicioStat[0];
               AssignAttri(sPrefix, false, "A77menInicioStat", StringUtil.Str( (decimal)(A77menInicioStat), 1, 0));
               A76menInicioFecFin = H000V2_A76menInicioFecFin[0];
               AssignAttri(sPrefix, false, "A76menInicioFecFin", context.localUtil.Format(A76menInicioFecFin, "99/99/9999"));
               A186menInicioFecIni = H000V2_A186menInicioFecIni[0];
               AssignAttri(sPrefix, false, "A186menInicioFecIni", context.localUtil.Format(A186menInicioFecIni, "99/99/9999"));
               A150menInicioDes = H000V2_A150menInicioDes[0];
               AssignAttri(sPrefix, false, "A150menInicioDes", A150menInicioDes);
               /* Execute user event: Load */
               E140V2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB0V0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0V2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "menInicioGeneral";
         context.Gx_err = 0;
      }

      protected void STRUP0V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E130V2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA58menInicioId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA58menInicioId"), ",", "."));
            /* Read variables values. */
            A150menInicioDes = cgiGet( edtmenInicioDes_Internalname);
            AssignAttri(sPrefix, false, "A150menInicioDes", A150menInicioDes);
            A186menInicioFecIni = context.localUtil.CToD( cgiGet( edtmenInicioFecIni_Internalname), 2);
            AssignAttri(sPrefix, false, "A186menInicioFecIni", context.localUtil.Format(A186menInicioFecIni, "99/99/9999"));
            A76menInicioFecFin = context.localUtil.CToD( cgiGet( edtmenInicioFecFin_Internalname), 2);
            AssignAttri(sPrefix, false, "A76menInicioFecFin", context.localUtil.Format(A76menInicioFecFin, "99/99/9999"));
            cmbmenInicioStat.CurrentValue = cgiGet( cmbmenInicioStat_Internalname);
            A77menInicioStat = (short)(NumberUtil.Val( cgiGet( cmbmenInicioStat_Internalname), "."));
            AssignAttri(sPrefix, false, "A77menInicioStat", StringUtil.Str( (decimal)(A77menInicioStat), 1, 0));
            A185menInicioFecCap = context.localUtil.CToT( cgiGet( edtmenInicioFecCap_Internalname));
            AssignAttri(sPrefix, false, "A185menInicioFecCap", context.localUtil.TToC( A185menInicioFecCap, 10, 8, 0, 3, "/", ":", " "));
            A59sgUsrMenId = (int)(context.localUtil.CToN( cgiGet( edtsgUsrMenId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A59sgUsrMenId", StringUtil.LTrimStr( (decimal)(A59sgUsrMenId), 6, 0));
            A187sgUsrMenNom = cgiGet( edtsgUsrMenNom_Internalname);
            AssignAttri(sPrefix, false, "A187sgUsrMenNom", A187sgUsrMenNom);
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
         E130V2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E130V2( )
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

      protected void E140V2( )
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
         AV7TrnContext.gxTpr_Transactionname = "menInicio";
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "menInicioId";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6menInicioId), 6, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "TransactionContext", "ADMINDATA1"));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A58menInicioId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "A58menInicioId", StringUtil.LTrimStr( (decimal)(A58menInicioId), 6, 0));
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
         PA0V2( ) ;
         WS0V2( ) ;
         WE0V2( ) ;
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
         sCtrlA58menInicioId = (String)((String)getParm(obj,0));
      }

      public override void componentrestorestate( String sPPrefix ,
                                                  String sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0V2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (String)getParm(obj,0);
         sSFPrefix = (String)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "meniniciogeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0V2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A58menInicioId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "A58menInicioId", StringUtil.LTrimStr( (decimal)(A58menInicioId), 6, 0));
         }
         wcpOA58menInicioId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA58menInicioId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( A58menInicioId != wcpOA58menInicioId ) ) )
         {
            setjustcreated();
         }
         wcpOA58menInicioId = A58menInicioId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA58menInicioId = cgiGet( sPrefix+"A58menInicioId_CTRL");
         if ( StringUtil.Len( sCtrlA58menInicioId) > 0 )
         {
            A58menInicioId = (int)(context.localUtil.CToN( cgiGet( sCtrlA58menInicioId), ",", "."));
            AssignAttri(sPrefix, false, "A58menInicioId", StringUtil.LTrimStr( (decimal)(A58menInicioId), 6, 0));
         }
         else
         {
            A58menInicioId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"A58menInicioId_PARM"), ",", "."));
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
         PA0V2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0V2( ) ;
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
         WS0V2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A58menInicioId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A58menInicioId), 6, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA58menInicioId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A58menInicioId_CTRL", StringUtil.RTrim( sCtrlA58menInicioId));
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
         WE0V2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714343855", true, true);
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
         context.AddJavascriptSource("meniniciogeneral.js", "?202262714343855", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbmenInicioStat.Name = "MENINICIOSTAT";
         cmbmenInicioStat.WebTags = "";
         cmbmenInicioStat.addItem("1", "Vigente", 0);
         cmbmenInicioStat.addItem("0", "No Vigente", 0);
         if ( cmbmenInicioStat.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         edtmenInicioId_Internalname = sPrefix+"MENINICIOID";
         edtmenInicioDes_Internalname = sPrefix+"MENINICIODES";
         edtmenInicioFecIni_Internalname = sPrefix+"MENINICIOFECINI";
         edtmenInicioFecFin_Internalname = sPrefix+"MENINICIOFECFIN";
         cmbmenInicioStat_Internalname = sPrefix+"MENINICIOSTAT";
         edtmenInicioFecCap_Internalname = sPrefix+"MENINICIOFECCAP";
         edtsgUsrMenId_Internalname = sPrefix+"SGUSRMENID";
         edtsgUsrMenNom_Internalname = sPrefix+"SGUSRMENNOM";
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
         edtsgUsrMenNom_Jsonclick = "";
         edtsgUsrMenNom_Enabled = 0;
         edtsgUsrMenId_Jsonclick = "";
         edtsgUsrMenId_Enabled = 0;
         edtmenInicioFecCap_Jsonclick = "";
         edtmenInicioFecCap_Enabled = 0;
         cmbmenInicioStat_Jsonclick = "";
         cmbmenInicioStat.Enabled = 0;
         edtmenInicioFecFin_Jsonclick = "";
         edtmenInicioFecFin_Enabled = 0;
         edtmenInicioFecIni_Jsonclick = "";
         edtmenInicioFecIni_Enabled = 0;
         edtmenInicioDes_Enabled = 0;
         edtmenInicioId_Jsonclick = "";
         edtmenInicioId_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A58menInicioId',fld:'MENINICIOID',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E110V1',iparms:[{av:'A58menInicioId',fld:'MENINICIOID',pic:'ZZZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E120V1',iparms:[{av:'A58menInicioId',fld:'MENINICIOID',pic:'ZZZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_MENINICIOID","{handler:'Valid_Meninicioid',iparms:[]");
         setEventMetadata("VALID_MENINICIOID",",oparms:[]}");
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
         A150menInicioDes = "";
         A186menInicioFecIni = DateTime.MinValue;
         A76menInicioFecFin = DateTime.MinValue;
         A185menInicioFecCap = (DateTime)(DateTime.MinValue);
         A187sgUsrMenNom = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H000V2_A58menInicioId = new int[1] ;
         H000V2_A187sgUsrMenNom = new String[] {""} ;
         H000V2_A59sgUsrMenId = new int[1] ;
         H000V2_A185menInicioFecCap = new DateTime[] {DateTime.MinValue} ;
         H000V2_A77menInicioStat = new short[1] ;
         H000V2_A76menInicioFecFin = new DateTime[] {DateTime.MinValue} ;
         H000V2_A186menInicioFecIni = new DateTime[] {DateTime.MinValue} ;
         H000V2_A150menInicioDes = new String[] {""} ;
         AV7TrnContext = new SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA58menInicioId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.meniniciogeneral__default(),
            new Object[][] {
                new Object[] {
               H000V2_A58menInicioId, H000V2_A187sgUsrMenNom, H000V2_A59sgUsrMenId, H000V2_A185menInicioFecCap, H000V2_A77menInicioStat, H000V2_A76menInicioFecFin, H000V2_A186menInicioFecIni, H000V2_A150menInicioDes
               }
            }
         );
         AV13Pgmname = "menInicioGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "menInicioGeneral";
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short A77menInicioStat ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int A58menInicioId ;
      private int wcpOA58menInicioId ;
      private int edtmenInicioId_Enabled ;
      private int edtmenInicioDes_Enabled ;
      private int edtmenInicioFecIni_Enabled ;
      private int edtmenInicioFecFin_Enabled ;
      private int edtmenInicioFecCap_Enabled ;
      private int A59sgUsrMenId ;
      private int edtsgUsrMenId_Enabled ;
      private int edtsgUsrMenNom_Enabled ;
      private int AV6menInicioId ;
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
      private String edtmenInicioId_Internalname ;
      private String edtmenInicioId_Jsonclick ;
      private String edtmenInicioDes_Internalname ;
      private String edtmenInicioFecIni_Internalname ;
      private String edtmenInicioFecIni_Jsonclick ;
      private String edtmenInicioFecFin_Internalname ;
      private String edtmenInicioFecFin_Jsonclick ;
      private String cmbmenInicioStat_Internalname ;
      private String cmbmenInicioStat_Jsonclick ;
      private String edtmenInicioFecCap_Internalname ;
      private String edtmenInicioFecCap_Jsonclick ;
      private String edtsgUsrMenId_Internalname ;
      private String edtsgUsrMenId_Jsonclick ;
      private String edtsgUsrMenNom_Internalname ;
      private String edtsgUsrMenNom_Jsonclick ;
      private String sXEvt ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String scmdbuf ;
      private String sCtrlA58menInicioId ;
      private DateTime A185menInicioFecCap ;
      private DateTime A186menInicioFecIni ;
      private DateTime A76menInicioFecFin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private String A150menInicioDes ;
      private String A187sgUsrMenNom ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbmenInicioStat ;
      private IDataStoreProvider pr_default ;
      private int[] H000V2_A58menInicioId ;
      private String[] H000V2_A187sgUsrMenNom ;
      private int[] H000V2_A59sgUsrMenId ;
      private DateTime[] H000V2_A185menInicioFecCap ;
      private short[] H000V2_A77menInicioStat ;
      private DateTime[] H000V2_A76menInicioFecFin ;
      private DateTime[] H000V2_A186menInicioFecIni ;
      private String[] H000V2_A150menInicioDes ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private SdtTransactionContext AV7TrnContext ;
      private SdtTransactionContext_Attribute AV8TrnContextAtt ;
   }

   public class meniniciogeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH000V2 ;
          prmH000V2 = new Object[] {
          new Object[] {"menInicioId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H000V2", "SELECT `menInicioId`, `sgUsrMenNom`, `sgUsrMenId`, `menInicioFecCap`, `menInicioStat`, `menInicioFecFin`, `menInicioFecIni`, `menInicioDes` FROM `menInicio` WHERE `menInicioId` = ? ORDER BY `menInicioId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000V2,1, GxCacheFrequency.OFF ,true,true )
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
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4) ;
                ((short[]) buf[4])[0] = rslt.getShort(5) ;
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6) ;
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7) ;
                ((String[]) buf[7])[0] = rslt.getVarchar(8) ;
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
