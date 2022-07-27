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
   public class viewusuarios : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public viewusuarios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public viewusuarios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_UsuariosId ,
                           String aP1_TabCode )
      {
         this.AV12UsuariosId = aP0_UsuariosId;
         this.AV6TabCode = aP1_TabCode;
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV12UsuariosId = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV12UsuariosId", StringUtil.LTrimStr( (decimal)(AV12UsuariosId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12UsuariosId), "ZZZZZ9"), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV6TabCode = GetNextPar( );
                  AssignAttri("", false, "AV6TabCode", AV6TabCode);
                  GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6TabCode, "")), context));
               }
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdmasterpage", "GeneXus.Programs.rwdmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
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
         PA132( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START132( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714344761", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("viewusuarios.aspx") + "?" + UrlEncode("" +AV12UsuariosId) + "," + UrlEncode(StringUtil.RTrim(AV6TabCode))+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12UsuariosId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6TabCode, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"ViewUsuarios");
         forbiddenHiddens.Add("UsuariosCurp", StringUtil.RTrim( context.localUtil.Format( A105UsuariosCurp, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("viewusuarios:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_boolean_hidden_field( context, "vLOADALLTABS", AV11LoadAllTabs);
         GxWebStd.gx_hidden_field( context, "vSELECTEDTABCODE", StringUtil.RTrim( AV7SelectedTabCode));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12UsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12UsuariosId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV6TabCode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6TabCode, "")), context));
         GxWebStd.gx_hidden_field( context, "TAB_Activepagecontrolname", StringUtil.RTrim( Tab_Activepagecontrolname));
         GxWebStd.gx_hidden_field( context, "TAB_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Tab_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TAB_Class", StringUtil.RTrim( Tab_Class));
         GxWebStd.gx_hidden_field( context, "TAB_Historymanagement", StringUtil.BoolToStr( Tab_Historymanagement));
         GxWebStd.gx_hidden_field( context, "TAB_Activepagecontrolname", StringUtil.RTrim( Tab_Activepagecontrolname));
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
         if ( ! ( WebComp_Generalwc == null ) )
         {
            WebComp_Generalwc.componentjscripts();
         }
         if ( ! ( WebComp_Histpwdwc == null ) )
         {
            WebComp_Histpwdwc.componentjscripts();
         }
         if ( ! ( WebComp_Intentoswc == null ) )
         {
            WebComp_Intentoswc.componentjscripts();
         }
         if ( ! ( WebComp_Usuariosvacantewc == null ) )
         {
            WebComp_Usuariosvacantewc.componentjscripts();
         }
         if ( ! ( WebComp_Usuariosperfilwc == null ) )
         {
            WebComp_Usuariosperfilwc.componentjscripts();
         }
         if ( ! ( WebComp_Bitacceswc == null ) )
         {
            WebComp_Bitacceswc.componentjscripts();
         }
         if ( ! ( WebComp_Usuariosvacante1wc == null ) )
         {
            WebComp_Usuariosvacante1wc.componentjscripts();
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
            WE132( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT132( ) ;
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
         return formatLink("viewusuarios.aspx") + "?" + UrlEncode("" +AV12UsuariosId) + "," + UrlEncode(StringUtil.RTrim(AV6TabCode)) ;
      }

      public override String GetPgmname( )
      {
         return "ViewUsuarios" ;
      }

      public override String GetPgmdesc( )
      {
         return "View Usuarios" ;
      }

      protected void WB130( )
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
            GxWebStd.gx_div_start( context, divTabletop_Internalname, 1, 0, "px", 0, "px", "TableTopSearch", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 col-sm-offset-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblViewtitle_Internalname, "Alta Usuarios Information", "", "", lblViewtitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SubTitle", 0, "", 1, 1, 0, "HLP_ViewUsuarios.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 ViewActionsBackCell", "Right", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblViewall_Internalname, "Alta Usuarios", lblViewall_Link, "", lblViewall_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "BtnTextBlockBack", 0, "", lblViewall_Visible, 1, 0, "HLP_ViewUsuarios.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-sm-offset-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabtable_1_Internalname, 1, 0, "px", 0, "px", "ViewTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosCurp_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuariosCurp_Internalname, "CURP", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtUsuariosCurp_Internalname, A105UsuariosCurp, StringUtil.RTrim( context.localUtil.Format( A105UsuariosCurp, "@!")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosCurp_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtUsuariosCurp_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ViewUsuarios.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-10 col-xs-offset-1", "left", "top", "", "", "div");
            /* User Defined Control */
            ucTab.SetProperty("PageCount", Tab_Pagecount);
            ucTab.SetProperty("Class", Tab_Class);
            ucTab.SetProperty("HistoryManagement", Tab_Historymanagement);
            ucTab.Render(context, "tab", Tab_Internalname, "TABContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGeneral_title_Internalname, "General", "", "", lblGeneral_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_ViewUsuarios.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "General") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablegeneral_Internalname, 1, 0, "px", 0, "px", "TabsFormContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0030"+"", StringUtil.RTrim( WebComp_Generalwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0030"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldGeneralwc), StringUtil.Lower( WebComp_Generalwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0030"+"");
                  }
                  WebComp_Generalwc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldGeneralwc), StringUtil.Lower( WebComp_Generalwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblHistpwd_title_Internalname, "Historico de Contrasenas", "", "", lblHistpwd_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_ViewUsuarios.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "HistPwd") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablehistpwd_Internalname, 1, 0, "px", 0, "px", "TabsFormContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0038"+"", StringUtil.RTrim( WebComp_Histpwdwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0038"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Histpwdwc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldHistpwdwc), StringUtil.Lower( WebComp_Histpwdwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0038"+"");
                  }
                  WebComp_Histpwdwc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldHistpwdwc), StringUtil.Lower( WebComp_Histpwdwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABContainer"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblIntentos_title_Internalname, "Intentos", "", "", lblIntentos_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_ViewUsuarios.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Intentos") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABContainer"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableintentos_Internalname, 1, 0, "px", 0, "px", "TabsFormContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0046"+"", StringUtil.RTrim( WebComp_Intentoswc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0046"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Intentoswc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldIntentoswc), StringUtil.Lower( WebComp_Intentoswc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0046"+"");
                  }
                  WebComp_Intentoswc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldIntentoswc), StringUtil.Lower( WebComp_Intentoswc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABContainer"+"title4"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblUsuariosvacante_title_Internalname, "Work With Vacantes", "", "", lblUsuariosvacante_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_ViewUsuarios.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "UsuariosVacante") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABContainer"+"panel4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableusuariosvacante_Internalname, 1, 0, "px", 0, "px", "TabsFormContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0054"+"", StringUtil.RTrim( WebComp_Usuariosvacantewc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0054"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Usuariosvacantewc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldUsuariosvacantewc), StringUtil.Lower( WebComp_Usuariosvacantewc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0054"+"");
                  }
                  WebComp_Usuariosvacantewc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldUsuariosvacantewc), StringUtil.Lower( WebComp_Usuariosvacantewc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABContainer"+"title5"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblUsuariosperfil_title_Internalname, "Perfiles", "", "", lblUsuariosperfil_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_ViewUsuarios.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "UsuariosPerfil") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABContainer"+"panel5"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableusuariosperfil_Internalname, 1, 0, "px", 0, "px", "TabsFormContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0062"+"", StringUtil.RTrim( WebComp_Usuariosperfilwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0062"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Usuariosperfilwc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldUsuariosperfilwc), StringUtil.Lower( WebComp_Usuariosperfilwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0062"+"");
                  }
                  WebComp_Usuariosperfilwc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldUsuariosperfilwc), StringUtil.Lower( WebComp_Usuariosperfilwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABContainer"+"title6"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblBitacces_title_Internalname, "Bitacora acceso", "", "", lblBitacces_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_ViewUsuarios.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "bitAcces") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABContainer"+"panel6"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablebitacces_Internalname, 1, 0, "px", 0, "px", "TabsFormContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0070"+"", StringUtil.RTrim( WebComp_Bitacceswc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0070"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Bitacceswc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldBitacceswc), StringUtil.Lower( WebComp_Bitacceswc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0070"+"");
                  }
                  WebComp_Bitacceswc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldBitacceswc), StringUtil.Lower( WebComp_Bitacceswc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABContainer"+"title7"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblUsuariosvacante1_title_Internalname, "SUBT_Reclutador", "", "", lblUsuariosvacante1_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_ViewUsuarios.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "UsuariosVacante1") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABContainer"+"panel7"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableusuariosvacante1_Internalname, 1, 0, "px", 0, "px", "TabsFormContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0078"+"", StringUtil.RTrim( WebComp_Usuariosvacante1wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0078"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Usuariosvacante1wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldUsuariosvacante1wc), StringUtil.Lower( WebComp_Usuariosvacante1wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0078"+"");
                  }
                  WebComp_Usuariosvacante1wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldUsuariosvacante1wc), StringUtil.Lower( WebComp_Usuariosvacante1wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START132( )
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
            Form.Meta.addItem("description", "View Usuarios", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP130( ) ;
      }

      protected void WS132( )
      {
         START132( ) ;
         EVT132( ) ;
      }

      protected void EVT132( )
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
                              E11132 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E12132 ();
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
                        if ( nCmpId == 30 )
                        {
                           OldGeneralwc = cgiGet( "W0030");
                           if ( ( StringUtil.Len( OldGeneralwc) == 0 ) || ( StringUtil.StrCmp(OldGeneralwc, WebComp_Generalwc_Component) != 0 ) )
                           {
                              WebComp_Generalwc = getWebComponent(GetType(), "GeneXus.Programs", OldGeneralwc, new Object[] {context} );
                              WebComp_Generalwc.ComponentInit();
                              WebComp_Generalwc.Name = "OldGeneralwc";
                              WebComp_Generalwc_Component = OldGeneralwc;
                           }
                           if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
                           {
                              WebComp_Generalwc.componentprocess("W0030", "", sEvt);
                           }
                           WebComp_Generalwc_Component = OldGeneralwc;
                        }
                        else if ( nCmpId == 38 )
                        {
                           OldHistpwdwc = cgiGet( "W0038");
                           if ( ( StringUtil.Len( OldHistpwdwc) == 0 ) || ( StringUtil.StrCmp(OldHistpwdwc, WebComp_Histpwdwc_Component) != 0 ) )
                           {
                              WebComp_Histpwdwc = getWebComponent(GetType(), "GeneXus.Programs", OldHistpwdwc, new Object[] {context} );
                              WebComp_Histpwdwc.ComponentInit();
                              WebComp_Histpwdwc.Name = "OldHistpwdwc";
                              WebComp_Histpwdwc_Component = OldHistpwdwc;
                           }
                           if ( StringUtil.Len( WebComp_Histpwdwc_Component) != 0 )
                           {
                              WebComp_Histpwdwc.componentprocess("W0038", "", sEvt);
                           }
                           WebComp_Histpwdwc_Component = OldHistpwdwc;
                        }
                        else if ( nCmpId == 46 )
                        {
                           OldIntentoswc = cgiGet( "W0046");
                           if ( ( StringUtil.Len( OldIntentoswc) == 0 ) || ( StringUtil.StrCmp(OldIntentoswc, WebComp_Intentoswc_Component) != 0 ) )
                           {
                              WebComp_Intentoswc = getWebComponent(GetType(), "GeneXus.Programs", OldIntentoswc, new Object[] {context} );
                              WebComp_Intentoswc.ComponentInit();
                              WebComp_Intentoswc.Name = "OldIntentoswc";
                              WebComp_Intentoswc_Component = OldIntentoswc;
                           }
                           if ( StringUtil.Len( WebComp_Intentoswc_Component) != 0 )
                           {
                              WebComp_Intentoswc.componentprocess("W0046", "", sEvt);
                           }
                           WebComp_Intentoswc_Component = OldIntentoswc;
                        }
                        else if ( nCmpId == 54 )
                        {
                           OldUsuariosvacantewc = cgiGet( "W0054");
                           if ( ( StringUtil.Len( OldUsuariosvacantewc) == 0 ) || ( StringUtil.StrCmp(OldUsuariosvacantewc, WebComp_Usuariosvacantewc_Component) != 0 ) )
                           {
                              WebComp_Usuariosvacantewc = getWebComponent(GetType(), "GeneXus.Programs", OldUsuariosvacantewc, new Object[] {context} );
                              WebComp_Usuariosvacantewc.ComponentInit();
                              WebComp_Usuariosvacantewc.Name = "OldUsuariosvacantewc";
                              WebComp_Usuariosvacantewc_Component = OldUsuariosvacantewc;
                           }
                           if ( StringUtil.Len( WebComp_Usuariosvacantewc_Component) != 0 )
                           {
                              WebComp_Usuariosvacantewc.componentprocess("W0054", "", sEvt);
                           }
                           WebComp_Usuariosvacantewc_Component = OldUsuariosvacantewc;
                        }
                        else if ( nCmpId == 62 )
                        {
                           OldUsuariosperfilwc = cgiGet( "W0062");
                           if ( ( StringUtil.Len( OldUsuariosperfilwc) == 0 ) || ( StringUtil.StrCmp(OldUsuariosperfilwc, WebComp_Usuariosperfilwc_Component) != 0 ) )
                           {
                              WebComp_Usuariosperfilwc = getWebComponent(GetType(), "GeneXus.Programs", OldUsuariosperfilwc, new Object[] {context} );
                              WebComp_Usuariosperfilwc.ComponentInit();
                              WebComp_Usuariosperfilwc.Name = "OldUsuariosperfilwc";
                              WebComp_Usuariosperfilwc_Component = OldUsuariosperfilwc;
                           }
                           if ( StringUtil.Len( WebComp_Usuariosperfilwc_Component) != 0 )
                           {
                              WebComp_Usuariosperfilwc.componentprocess("W0062", "", sEvt);
                           }
                           WebComp_Usuariosperfilwc_Component = OldUsuariosperfilwc;
                        }
                        else if ( nCmpId == 70 )
                        {
                           OldBitacceswc = cgiGet( "W0070");
                           if ( ( StringUtil.Len( OldBitacceswc) == 0 ) || ( StringUtil.StrCmp(OldBitacceswc, WebComp_Bitacceswc_Component) != 0 ) )
                           {
                              WebComp_Bitacceswc = getWebComponent(GetType(), "GeneXus.Programs", OldBitacceswc, new Object[] {context} );
                              WebComp_Bitacceswc.ComponentInit();
                              WebComp_Bitacceswc.Name = "OldBitacceswc";
                              WebComp_Bitacceswc_Component = OldBitacceswc;
                           }
                           if ( StringUtil.Len( WebComp_Bitacceswc_Component) != 0 )
                           {
                              WebComp_Bitacceswc.componentprocess("W0070", "", sEvt);
                           }
                           WebComp_Bitacceswc_Component = OldBitacceswc;
                        }
                        else if ( nCmpId == 78 )
                        {
                           OldUsuariosvacante1wc = cgiGet( "W0078");
                           if ( ( StringUtil.Len( OldUsuariosvacante1wc) == 0 ) || ( StringUtil.StrCmp(OldUsuariosvacante1wc, WebComp_Usuariosvacante1wc_Component) != 0 ) )
                           {
                              WebComp_Usuariosvacante1wc = getWebComponent(GetType(), "GeneXus.Programs", OldUsuariosvacante1wc, new Object[] {context} );
                              WebComp_Usuariosvacante1wc.ComponentInit();
                              WebComp_Usuariosvacante1wc.Name = "OldUsuariosvacante1wc";
                              WebComp_Usuariosvacante1wc_Component = OldUsuariosvacante1wc;
                           }
                           if ( StringUtil.Len( WebComp_Usuariosvacante1wc_Component) != 0 )
                           {
                              WebComp_Usuariosvacante1wc.componentprocess("W0078", "", sEvt);
                           }
                           WebComp_Usuariosvacante1wc_Component = OldUsuariosvacante1wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE132( )
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

      protected void PA132( )
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
         RF132( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV15Pgmname = "ViewUsuarios";
         context.Gx_err = 0;
      }

      protected void RF132( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
               {
                  WebComp_Generalwc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Histpwdwc_Component) != 0 )
               {
                  WebComp_Histpwdwc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Intentoswc_Component) != 0 )
               {
                  WebComp_Intentoswc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Usuariosvacantewc_Component) != 0 )
               {
                  WebComp_Usuariosvacantewc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Usuariosperfilwc_Component) != 0 )
               {
                  WebComp_Usuariosperfilwc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Bitacceswc_Component) != 0 )
               {
                  WebComp_Bitacceswc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Usuariosvacante1wc_Component) != 0 )
               {
                  WebComp_Usuariosvacante1wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00132 */
            pr_default.execute(0, new Object[] {AV12UsuariosId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A11UsuariosId = H00132_A11UsuariosId[0];
               A105UsuariosCurp = H00132_A105UsuariosCurp[0];
               AssignAttri("", false, "A105UsuariosCurp", A105UsuariosCurp);
               /* Execute user event: Load */
               E12132 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB130( ) ;
         }
      }

      protected void send_integrity_lvl_hashes132( )
      {
      }

      protected void before_start_formulas( )
      {
         AV15Pgmname = "ViewUsuarios";
         context.Gx_err = 0;
      }

      protected void STRUP130( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11132 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            AV12UsuariosId = (int)(context.localUtil.CToN( cgiGet( "vUSUARIOSID"), ",", "."));
            AV11LoadAllTabs = StringUtil.StrToBool( cgiGet( "vLOADALLTABS"));
            AV7SelectedTabCode = cgiGet( "vSELECTEDTABCODE");
            Tab_Activepagecontrolname = cgiGet( "TAB_Activepagecontrolname");
            Tab_Pagecount = (int)(context.localUtil.CToN( cgiGet( "TAB_Pagecount"), ",", "."));
            Tab_Class = cgiGet( "TAB_Class");
            Tab_Historymanagement = StringUtil.StrToBool( cgiGet( "TAB_Historymanagement"));
            /* Read variables values. */
            A105UsuariosCurp = StringUtil.Upper( cgiGet( edtUsuariosCurp_Internalname));
            AssignAttri("", false, "A105UsuariosCurp", A105UsuariosCurp);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"ViewUsuarios");
            A105UsuariosCurp = cgiGet( edtUsuariosCurp_Internalname);
            AssignAttri("", false, "A105UsuariosCurp", A105UsuariosCurp);
            forbiddenHiddens.Add("UsuariosCurp", StringUtil.RTrim( context.localUtil.Format( A105UsuariosCurp, "@!")));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("viewusuarios:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
         E11132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11132( )
      {
         /* Start Routine */
         if ( ! new isauthorized(context).executeUdp(  AV15Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV15Pgmname)));
            context.wjLocDisableFrm = 1;
         }
         AV16GXLvl6 = 0;
         /* Using cursor H00133 */
         pr_default.execute(1, new Object[] {AV12UsuariosId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A11UsuariosId = H00133_A11UsuariosId[0];
            A105UsuariosCurp = H00133_A105UsuariosCurp[0];
            AssignAttri("", false, "A105UsuariosCurp", A105UsuariosCurp);
            AV16GXLvl6 = 1;
            Form.Caption = A105UsuariosCurp;
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            lblViewall_Link = formatLink("wwusuarios.aspx") ;
            AssignProp("", false, lblViewall_Internalname, "Link", lblViewall_Link, true);
            AV10Exists = true;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         if ( AV16GXLvl6 == 0 )
         {
            Form.Caption = "Record not found";
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            lblViewall_Visible = 0;
            AssignProp("", false, lblViewall_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblViewall_Visible), 5, 0), true);
            AV10Exists = false;
         }
         AV11LoadAllTabs = false;
         AssignAttri("", false, "AV11LoadAllTabs", AV11LoadAllTabs);
         if ( AV10Exists )
         {
            AV7SelectedTabCode = AV6TabCode;
            AssignAttri("", false, "AV7SelectedTabCode", AV7SelectedTabCode);
            Tab_Activepagecontrolname = AV7SelectedTabCode;
            ucTab.SendProperty(context, "", false, Tab_Internalname, "ActivePageControlName", Tab_Activepagecontrolname);
            /* Execute user subroutine: 'LOAD TAB' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void S112( )
      {
         /* 'LOAD TAB' Routine */
         if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV7SelectedTabCode, "") == 0 ) || ( StringUtil.StrCmp(AV7SelectedTabCode, "General") == 0 ) )
         {
            /* Object Property */
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Generalwc_Component), StringUtil.Lower( "UsuariosGeneral")) != 0 )
            {
               WebComp_Generalwc = getWebComponent(GetType(), "GeneXus.Programs", "usuariosgeneral", new Object[] {context} );
               WebComp_Generalwc.ComponentInit();
               WebComp_Generalwc.Name = "UsuariosGeneral";
               WebComp_Generalwc_Component = "UsuariosGeneral";
            }
            if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
            {
               WebComp_Generalwc.setjustcreated();
               WebComp_Generalwc.componentprepare(new Object[] {(String)"W0030",(String)"",(int)AV12UsuariosId});
               WebComp_Generalwc.componentbind(new Object[] {(String)""});
            }
            if ( isFullAjaxMode( ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0030"+"");
               WebComp_Generalwc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV7SelectedTabCode, "HistPwd") == 0 ) )
         {
            /* Object Property */
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Histpwdwc_Component), StringUtil.Lower( "UsuariosHistPwdWC")) != 0 )
            {
               WebComp_Histpwdwc = getWebComponent(GetType(), "GeneXus.Programs", "usuarioshistpwdwc", new Object[] {context} );
               WebComp_Histpwdwc.ComponentInit();
               WebComp_Histpwdwc.Name = "UsuariosHistPwdWC";
               WebComp_Histpwdwc_Component = "UsuariosHistPwdWC";
            }
            if ( StringUtil.Len( WebComp_Histpwdwc_Component) != 0 )
            {
               WebComp_Histpwdwc.setjustcreated();
               WebComp_Histpwdwc.componentprepare(new Object[] {(String)"W0038",(String)"",(int)AV12UsuariosId});
               WebComp_Histpwdwc.componentbind(new Object[] {(String)""});
            }
            if ( isFullAjaxMode( ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0038"+"");
               WebComp_Histpwdwc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV7SelectedTabCode, "Intentos") == 0 ) )
         {
            /* Object Property */
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Intentoswc_Component), StringUtil.Lower( "UsuariosIntentosWC")) != 0 )
            {
               WebComp_Intentoswc = getWebComponent(GetType(), "GeneXus.Programs", "usuariosintentoswc", new Object[] {context} );
               WebComp_Intentoswc.ComponentInit();
               WebComp_Intentoswc.Name = "UsuariosIntentosWC";
               WebComp_Intentoswc_Component = "UsuariosIntentosWC";
            }
            if ( StringUtil.Len( WebComp_Intentoswc_Component) != 0 )
            {
               WebComp_Intentoswc.setjustcreated();
               WebComp_Intentoswc.componentprepare(new Object[] {(String)"W0046",(String)"",(int)AV12UsuariosId});
               WebComp_Intentoswc.componentbind(new Object[] {(String)""});
            }
            if ( isFullAjaxMode( ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0046"+"");
               WebComp_Intentoswc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV7SelectedTabCode, "UsuariosVacante") == 0 ) )
         {
            /* Object Property */
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Usuariosvacantewc_Component), StringUtil.Lower( "UsuariosUsuariosVacanteWC")) != 0 )
            {
               WebComp_Usuariosvacantewc = getWebComponent(GetType(), "GeneXus.Programs", "usuariosusuariosvacantewc", new Object[] {context} );
               WebComp_Usuariosvacantewc.ComponentInit();
               WebComp_Usuariosvacantewc.Name = "UsuariosUsuariosVacanteWC";
               WebComp_Usuariosvacantewc_Component = "UsuariosUsuariosVacanteWC";
            }
            if ( StringUtil.Len( WebComp_Usuariosvacantewc_Component) != 0 )
            {
               WebComp_Usuariosvacantewc.setjustcreated();
               WebComp_Usuariosvacantewc.componentprepare(new Object[] {(String)"W0054",(String)"",(int)AV12UsuariosId});
               WebComp_Usuariosvacantewc.componentbind(new Object[] {(String)""});
            }
            if ( isFullAjaxMode( ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0054"+"");
               WebComp_Usuariosvacantewc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV7SelectedTabCode, "UsuariosPerfil") == 0 ) )
         {
            /* Object Property */
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Usuariosperfilwc_Component), StringUtil.Lower( "UsuariosUsuariosPerfilWC")) != 0 )
            {
               WebComp_Usuariosperfilwc = getWebComponent(GetType(), "GeneXus.Programs", "usuariosusuariosperfilwc", new Object[] {context} );
               WebComp_Usuariosperfilwc.ComponentInit();
               WebComp_Usuariosperfilwc.Name = "UsuariosUsuariosPerfilWC";
               WebComp_Usuariosperfilwc_Component = "UsuariosUsuariosPerfilWC";
            }
            if ( StringUtil.Len( WebComp_Usuariosperfilwc_Component) != 0 )
            {
               WebComp_Usuariosperfilwc.setjustcreated();
               WebComp_Usuariosperfilwc.componentprepare(new Object[] {(String)"W0062",(String)"",(int)AV12UsuariosId});
               WebComp_Usuariosperfilwc.componentbind(new Object[] {(String)""});
            }
            if ( isFullAjaxMode( ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0062"+"");
               WebComp_Usuariosperfilwc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV7SelectedTabCode, "bitAcces") == 0 ) )
         {
            /* Object Property */
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Bitacceswc_Component), StringUtil.Lower( "UsuariosbitAccesWC")) != 0 )
            {
               WebComp_Bitacceswc = getWebComponent(GetType(), "GeneXus.Programs", "usuariosbitacceswc", new Object[] {context} );
               WebComp_Bitacceswc.ComponentInit();
               WebComp_Bitacceswc.Name = "UsuariosbitAccesWC";
               WebComp_Bitacceswc_Component = "UsuariosbitAccesWC";
            }
            if ( StringUtil.Len( WebComp_Bitacceswc_Component) != 0 )
            {
               WebComp_Bitacceswc.setjustcreated();
               WebComp_Bitacceswc.componentprepare(new Object[] {(String)"W0070",(String)"",(int)AV12UsuariosId});
               WebComp_Bitacceswc.componentbind(new Object[] {(String)""});
            }
            if ( isFullAjaxMode( ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0070"+"");
               WebComp_Bitacceswc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV7SelectedTabCode, "UsuariosVacante1") == 0 ) )
         {
            /* Object Property */
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Usuariosvacante1wc_Component), StringUtil.Lower( "UsuariosUsuariosVacante1WC")) != 0 )
            {
               WebComp_Usuariosvacante1wc = getWebComponent(GetType(), "GeneXus.Programs", "usuariosusuariosvacante1wc", new Object[] {context} );
               WebComp_Usuariosvacante1wc.ComponentInit();
               WebComp_Usuariosvacante1wc.Name = "UsuariosUsuariosVacante1WC";
               WebComp_Usuariosvacante1wc_Component = "UsuariosUsuariosVacante1WC";
            }
            if ( StringUtil.Len( WebComp_Usuariosvacante1wc_Component) != 0 )
            {
               WebComp_Usuariosvacante1wc.setjustcreated();
               WebComp_Usuariosvacante1wc.componentprepare(new Object[] {(String)"W0078",(String)"",(int)AV12UsuariosId});
               WebComp_Usuariosvacante1wc.componentbind(new Object[] {(String)""});
            }
            if ( isFullAjaxMode( ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0078"+"");
               WebComp_Usuariosvacante1wc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E12132( )
      {
         /* Load Routine */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV12UsuariosId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV12UsuariosId", StringUtil.LTrimStr( (decimal)(AV12UsuariosId), 6, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12UsuariosId), "ZZZZZ9"), context));
         AV6TabCode = (String)getParm(obj,1);
         AssignAttri("", false, "AV6TabCode", AV6TabCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6TabCode, "")), context));
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
         PA132( ) ;
         WS132( ) ;
         WE132( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Generalwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
            {
               WebComp_Generalwc.componentthemes();
            }
         }
         if ( ! ( WebComp_Histpwdwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Histpwdwc_Component) != 0 )
            {
               WebComp_Histpwdwc.componentthemes();
            }
         }
         if ( ! ( WebComp_Intentoswc == null ) )
         {
            if ( StringUtil.Len( WebComp_Intentoswc_Component) != 0 )
            {
               WebComp_Intentoswc.componentthemes();
            }
         }
         if ( ! ( WebComp_Usuariosvacantewc == null ) )
         {
            if ( StringUtil.Len( WebComp_Usuariosvacantewc_Component) != 0 )
            {
               WebComp_Usuariosvacantewc.componentthemes();
            }
         }
         if ( ! ( WebComp_Usuariosperfilwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Usuariosperfilwc_Component) != 0 )
            {
               WebComp_Usuariosperfilwc.componentthemes();
            }
         }
         if ( ! ( WebComp_Bitacceswc == null ) )
         {
            if ( StringUtil.Len( WebComp_Bitacceswc_Component) != 0 )
            {
               WebComp_Bitacceswc.componentthemes();
            }
         }
         if ( ! ( WebComp_Usuariosvacante1wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Usuariosvacante1wc_Component) != 0 )
            {
               WebComp_Usuariosvacante1wc.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714344796", true, true);
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
         context.AddJavascriptSource("viewusuarios.js", "?202262714344796", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblViewtitle_Internalname = "VIEWTITLE";
         lblViewall_Internalname = "VIEWALL";
         divTabletop_Internalname = "TABLETOP";
         edtUsuariosCurp_Internalname = "USUARIOSCURP";
         divTabtable_1_Internalname = "TABTABLE_1";
         lblGeneral_title_Internalname = "GENERAL_TITLE";
         divTablegeneral_Internalname = "TABLEGENERAL";
         lblHistpwd_title_Internalname = "HISTPWD_TITLE";
         divTablehistpwd_Internalname = "TABLEHISTPWD";
         lblIntentos_title_Internalname = "INTENTOS_TITLE";
         divTableintentos_Internalname = "TABLEINTENTOS";
         lblUsuariosvacante_title_Internalname = "USUARIOSVACANTE_TITLE";
         divTableusuariosvacante_Internalname = "TABLEUSUARIOSVACANTE";
         lblUsuariosperfil_title_Internalname = "USUARIOSPERFIL_TITLE";
         divTableusuariosperfil_Internalname = "TABLEUSUARIOSPERFIL";
         lblBitacces_title_Internalname = "BITACCES_TITLE";
         divTablebitacces_Internalname = "TABLEBITACCES";
         lblUsuariosvacante1_title_Internalname = "USUARIOSVACANTE1_TITLE";
         divTableusuariosvacante1_Internalname = "TABLEUSUARIOSVACANTE1";
         Tab_Internalname = "TAB";
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
         edtUsuariosCurp_Jsonclick = "";
         edtUsuariosCurp_Enabled = 0;
         lblViewall_Link = "";
         lblViewall_Visible = 1;
         Tab_Historymanagement = Convert.ToBoolean( -1);
         Tab_Class = "WWTab";
         Tab_Pagecount = 7;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "View Usuarios";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV12UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true},{av:'AV6TabCode',fld:'vTABCODE',pic:'',hsh:true},{av:'A105UsuariosCurp',fld:'USUARIOSCURP',pic:'@!'}]");
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
         wcpOAV6TabCode = "";
         Tab_Activepagecontrolname = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         A105UsuariosCurp = "";
         AV7SelectedTabCode = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblViewtitle_Jsonclick = "";
         lblViewall_Jsonclick = "";
         ucTab = new GXUserControl();
         lblGeneral_title_Jsonclick = "";
         WebComp_Generalwc_Component = "";
         OldGeneralwc = "";
         lblHistpwd_title_Jsonclick = "";
         WebComp_Histpwdwc_Component = "";
         OldHistpwdwc = "";
         lblIntentos_title_Jsonclick = "";
         WebComp_Intentoswc_Component = "";
         OldIntentoswc = "";
         lblUsuariosvacante_title_Jsonclick = "";
         WebComp_Usuariosvacantewc_Component = "";
         OldUsuariosvacantewc = "";
         lblUsuariosperfil_title_Jsonclick = "";
         WebComp_Usuariosperfilwc_Component = "";
         OldUsuariosperfilwc = "";
         lblBitacces_title_Jsonclick = "";
         WebComp_Bitacceswc_Component = "";
         OldBitacceswc = "";
         lblUsuariosvacante1_title_Jsonclick = "";
         WebComp_Usuariosvacante1wc_Component = "";
         OldUsuariosvacante1wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV15Pgmname = "";
         scmdbuf = "";
         H00132_A11UsuariosId = new int[1] ;
         H00132_A105UsuariosCurp = new String[] {""} ;
         hsh = "";
         H00133_A11UsuariosId = new int[1] ;
         H00133_A105UsuariosCurp = new String[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.viewusuarios__default(),
            new Object[][] {
                new Object[] {
               H00132_A11UsuariosId, H00132_A105UsuariosCurp
               }
               , new Object[] {
               H00133_A11UsuariosId, H00133_A105UsuariosCurp
               }
            }
         );
         WebComp_Generalwc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Histpwdwc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Intentoswc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Usuariosvacantewc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Usuariosperfilwc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Bitacceswc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Usuariosvacante1wc = new GeneXus.Http.GXNullWebComponent();
         AV15Pgmname = "ViewUsuarios";
         /* GeneXus formulas. */
         AV15Pgmname = "ViewUsuarios";
         context.Gx_err = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV16GXLvl6 ;
      private short nGXWrapped ;
      private int AV12UsuariosId ;
      private int wcpOAV12UsuariosId ;
      private int Tab_Pagecount ;
      private int lblViewall_Visible ;
      private int edtUsuariosCurp_Enabled ;
      private int A11UsuariosId ;
      private int idxLst ;
      private String AV6TabCode ;
      private String wcpOAV6TabCode ;
      private String Tab_Activepagecontrolname ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String AV7SelectedTabCode ;
      private String Tab_Class ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String divTabletop_Internalname ;
      private String lblViewtitle_Internalname ;
      private String lblViewtitle_Jsonclick ;
      private String lblViewall_Internalname ;
      private String lblViewall_Link ;
      private String lblViewall_Jsonclick ;
      private String divTabtable_1_Internalname ;
      private String edtUsuariosCurp_Internalname ;
      private String edtUsuariosCurp_Jsonclick ;
      private String Tab_Internalname ;
      private String lblGeneral_title_Internalname ;
      private String lblGeneral_title_Jsonclick ;
      private String divTablegeneral_Internalname ;
      private String WebComp_Generalwc_Component ;
      private String OldGeneralwc ;
      private String lblHistpwd_title_Internalname ;
      private String lblHistpwd_title_Jsonclick ;
      private String divTablehistpwd_Internalname ;
      private String WebComp_Histpwdwc_Component ;
      private String OldHistpwdwc ;
      private String lblIntentos_title_Internalname ;
      private String lblIntentos_title_Jsonclick ;
      private String divTableintentos_Internalname ;
      private String WebComp_Intentoswc_Component ;
      private String OldIntentoswc ;
      private String lblUsuariosvacante_title_Internalname ;
      private String lblUsuariosvacante_title_Jsonclick ;
      private String divTableusuariosvacante_Internalname ;
      private String WebComp_Usuariosvacantewc_Component ;
      private String OldUsuariosvacantewc ;
      private String lblUsuariosperfil_title_Internalname ;
      private String lblUsuariosperfil_title_Jsonclick ;
      private String divTableusuariosperfil_Internalname ;
      private String WebComp_Usuariosperfilwc_Component ;
      private String OldUsuariosperfilwc ;
      private String lblBitacces_title_Internalname ;
      private String lblBitacces_title_Jsonclick ;
      private String divTablebitacces_Internalname ;
      private String WebComp_Bitacceswc_Component ;
      private String OldBitacceswc ;
      private String lblUsuariosvacante1_title_Internalname ;
      private String lblUsuariosvacante1_title_Jsonclick ;
      private String divTableusuariosvacante1_Internalname ;
      private String WebComp_Usuariosvacante1wc_Component ;
      private String OldUsuariosvacante1wc ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String AV15Pgmname ;
      private String scmdbuf ;
      private String hsh ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV11LoadAllTabs ;
      private bool Tab_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV10Exists ;
      private String A105UsuariosCurp ;
      private GXWebComponent WebComp_Generalwc ;
      private GXWebComponent WebComp_Histpwdwc ;
      private GXWebComponent WebComp_Intentoswc ;
      private GXWebComponent WebComp_Usuariosvacantewc ;
      private GXWebComponent WebComp_Usuariosperfilwc ;
      private GXWebComponent WebComp_Bitacceswc ;
      private GXWebComponent WebComp_Usuariosvacante1wc ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucTab ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H00132_A11UsuariosId ;
      private String[] H00132_A105UsuariosCurp ;
      private int[] H00133_A11UsuariosId ;
      private String[] H00133_A105UsuariosCurp ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

   public class viewusuarios__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00132 ;
          prmH00132 = new Object[] {
          new Object[] {"AV12UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmH00133 ;
          prmH00133 = new Object[] {
          new Object[] {"AV12UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H00132", "SELECT `UsuariosId`, `UsuariosCurp` FROM `Usuarios` WHERE `UsuariosId` = ? ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00132,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00133", "SELECT `UsuariosId`, `UsuariosCurp` FROM `Usuarios` WHERE `UsuariosId` = ? ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00133,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
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
