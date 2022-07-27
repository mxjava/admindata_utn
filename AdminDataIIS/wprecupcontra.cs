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
   public class wprecupcontra : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wprecupcontra( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public wprecupcontra( IGxContext context )
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
         PA1X2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1X2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714344898", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wprecupcontra.aspx") +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vALERTPROPERTIES", AV5AlertProperties);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vALERTPROPERTIES", AV5AlertProperties);
         }
         GxWebStd.gx_hidden_field( context, "USUARIOSNOMBRE", A66UsuariosNombre);
         GxWebStd.gx_hidden_field( context, "USUARIOSCURP", A105UsuariosCurp);
         GxWebStd.gx_hidden_field( context, "USUARIOSTELEF", StringUtil.RTrim( A260UsuariosTelef));
         GxWebStd.gx_hidden_field( context, "USUARIOSCORREO", A261UsuariosCorreo);
         GxWebStd.gx_hidden_field( context, "USUARIOSPWD", A68UsuariosPwd);
         GxWebStd.gx_hidden_field( context, "USUARIOSKEY", A67UsuariosKey);
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE1X2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1X2( ) ;
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
         return formatLink("wprecupcontra.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "wpRecupContra" ;
      }

      public override String GetPgmdesc( )
      {
         return "Recupera Contraseña" ;
      }

      protected void WB1X0( )
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "BodyContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-9 col-sm-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "FormContainerCent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 col-sm-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Verificar tu Identidad", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "font-size:"+StringUtil.Str( (decimal)(lblTextblock1_Fontsize), 3, 0)+"pt;", "SubTitle", 0, "", 1, 1, 0, "HLP_wpRecupContra.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 ViewActionsBackCell", "Right", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblViellall_Internalname, "Acceso", "", "", lblViellall_Jsonclick, "'"+""+"'"+",false,"+"'"+"e111x1_client"+"'", "", "BtnTextBlockBack", 7, "", 1, 1, 0, "HLP_wpRecupContra.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUsuariosnombre_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUsuariosnombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuariosnombre_Internalname, "* Ingresa tu Nombre", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuariosnombre_Internalname, AV7UsuariosNombre, StringUtil.RTrim( context.localUtil.Format( AV7UsuariosNombre, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,19);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuariosnombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsuariosnombre_Visible, edtavUsuariosnombre_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpRecupContra.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttVerificar_Internalname, "", "Validar", bttVerificar_Jsonclick, 5, "Validar", "", StyleString, ClassString, bttVerificar_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'VALIDAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_wpRecupContra.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUsuarioscurp_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUsuarioscurp_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuarioscurp_Internalname, "*  Ingrese su Curp", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuarioscurp_Internalname, AV6UsuariosCurp, StringUtil.RTrim( context.localUtil.Format( AV6UsuariosCurp, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarioscurp_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsuarioscurp_Visible, edtavUsuarioscurp_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpRecupContra.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUsuariostelef_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUsuariostelef_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuariostelef_Internalname, "*  Ingrese su teléfono", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuariostelef_Internalname, StringUtil.RTrim( AV11UsuariosTelef), StringUtil.RTrim( context.localUtil.Format( AV11UsuariosTelef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuariostelef_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsuariostelef_Visible, edtavUsuariostelef_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpRecupContra.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUsuarioscorreo_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUsuarioscorreo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuarioscorreo_Internalname, "*  Ingrese su correo", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuarioscorreo_Internalname, AV12UsuariosCorreo, StringUtil.RTrim( context.localUtil.Format( AV12UsuariosCorreo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarioscorreo_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsuarioscorreo_Visible, edtavUsuarioscorreo_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "", "left", true, "", "HLP_wpRecupContra.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttRecuperar_Internalname, "", "Recuperar", bttRecuperar_Jsonclick, 5, "Recuperar", "", StyleString, ClassString, bttRecuperar_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'RECUPERAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_wpRecupContra.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttRegresar_Internalname, "", "Regresar", bttRegresar_Jsonclick, 5, "Regresar", "", StyleString, ClassString, bttRegresar_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'REGRESAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_wpRecupContra.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-9 col-sm-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucUcalertas.SetProperty("Propiedades", AV5AlertProperties);
            ucUcalertas.Render(context, "sweetalert2", Ucalertas_Internalname, "UCALERTASContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START1X2( )
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
            Form.Meta.addItem("description", "Recupera Contraseña", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1X0( ) ;
      }

      protected void WS1X2( )
      {
         START1X2( ) ;
         EVT1X2( ) ;
      }

      protected void EVT1X2( )
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
                              E121X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'VALIDAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Validar' */
                              E131X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REGRESAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Regresar' */
                              E141X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'RECUPERAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Recuperar' */
                              E151X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E161X2 ();
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE1X2( )
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

      protected void PA1X2( )
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
               GX_FocusControl = edtavUsuariosnombre_Internalname;
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
         RF1X2( ) ;
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

      protected void RF1X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E161X2 ();
            WB1X0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes1X2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP1X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E121X2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vALERTPROPERTIES"), AV5AlertProperties);
            /* Read saved values. */
            /* Read variables values. */
            AV7UsuariosNombre = StringUtil.Upper( cgiGet( edtavUsuariosnombre_Internalname));
            AssignAttri("", false, "AV7UsuariosNombre", AV7UsuariosNombre);
            AV6UsuariosCurp = StringUtil.Upper( cgiGet( edtavUsuarioscurp_Internalname));
            AssignAttri("", false, "AV6UsuariosCurp", AV6UsuariosCurp);
            AV11UsuariosTelef = cgiGet( edtavUsuariostelef_Internalname);
            AssignAttri("", false, "AV11UsuariosTelef", AV11UsuariosTelef);
            AV12UsuariosCorreo = cgiGet( edtavUsuarioscorreo_Internalname);
            AssignAttri("", false, "AV12UsuariosCorreo", AV12UsuariosCorreo);
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
         E121X2 ();
         if (returnInSub) return;
      }

      protected void E121X2( )
      {
         /* Start Routine */
         edtavUsuarioscorreo_Visible = 0;
         AssignProp("", false, edtavUsuarioscorreo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuarioscorreo_Visible), 5, 0), true);
         edtavUsuariostelef_Visible = 0;
         AssignProp("", false, edtavUsuariostelef_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuariostelef_Visible), 5, 0), true);
         edtavUsuarioscurp_Visible = 0;
         AssignProp("", false, edtavUsuarioscurp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuarioscurp_Visible), 5, 0), true);
         lblTextblock1_Fontsize = 14;
         AssignProp("", false, lblTextblock1_Internalname, "Fontsize", StringUtil.LTrimStr( (decimal)(lblTextblock1_Fontsize), 9, 0), true);
         bttRecuperar_Visible = 0;
         AssignProp("", false, bttRecuperar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttRecuperar_Visible), 5, 0), true);
         bttRegresar_Visible = 0;
         AssignProp("", false, bttRegresar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttRegresar_Visible), 5, 0), true);
         context.DoAjaxRefresh();
      }

      protected void E131X2( )
      {
         /* 'Validar' Routine */
         AV15GXLvl15 = 0;
         /* Using cursor H001X2 */
         pr_default.execute(0, new Object[] {AV7UsuariosNombre});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A66UsuariosNombre = H001X2_A66UsuariosNombre[0];
            AV15GXLvl15 = 1;
            edtavUsuarioscurp_Visible = 1;
            AssignProp("", false, edtavUsuarioscurp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuarioscurp_Visible), 5, 0), true);
            edtavUsuariosnombre_Enabled = 0;
            AssignProp("", false, edtavUsuariosnombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuariosnombre_Enabled), 5, 0), true);
            edtavUsuarioscorreo_Visible = 1;
            AssignProp("", false, edtavUsuarioscorreo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuarioscorreo_Visible), 5, 0), true);
            edtavUsuariostelef_Visible = 1;
            AssignProp("", false, edtavUsuariostelef_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuariostelef_Visible), 5, 0), true);
            bttVerificar_Visible = 0;
            AssignProp("", false, bttVerificar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttVerificar_Visible), 5, 0), true);
            bttRecuperar_Visible = 1;
            AssignProp("", false, bttRecuperar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttRecuperar_Visible), 5, 0), true);
            bttRegresar_Visible = 1;
            AssignProp("", false, bttRegresar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttRegresar_Visible), 5, 0), true);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV15GXLvl15 == 0 )
         {
            GXt_SdtPropiedades1 = AV5AlertProperties;
            new getsweetmessage(context ).execute(  "error",  "Usuario No existe",  "Favor de Verificar",  true,  false, out  GXt_SdtPropiedades1) ;
            AV5AlertProperties = GXt_SdtPropiedades1;
            this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5AlertProperties", AV5AlertProperties);
      }

      protected void E141X2( )
      {
         /* 'Regresar' Routine */
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E151X2( )
      {
         /* 'Recuperar' Routine */
         AV16GXLvl37 = 0;
         /* Using cursor H001X3 */
         pr_default.execute(1, new Object[] {AV6UsuariosCurp, AV11UsuariosTelef, AV12UsuariosCorreo});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A261UsuariosCorreo = H001X3_A261UsuariosCorreo[0];
            A260UsuariosTelef = H001X3_A260UsuariosTelef[0];
            A105UsuariosCurp = H001X3_A105UsuariosCurp[0];
            A67UsuariosKey = H001X3_A67UsuariosKey[0];
            A68UsuariosPwd = H001X3_A68UsuariosPwd[0];
            AV16GXLvl37 = 1;
            AV10pass = Decrypt64( A68UsuariosPwd, A67UsuariosKey);
            GXt_SdtPropiedades1 = AV5AlertProperties;
            new getsweetmessage(context ).execute(  "success",  "Tu contraseña es:",  AV10pass,  true,  false, out  GXt_SdtPropiedades1) ;
            AV5AlertProperties = GXt_SdtPropiedades1;
            this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( AV16GXLvl37 == 0 )
         {
            AV7UsuariosNombre = "";
            AssignAttri("", false, "AV7UsuariosNombre", AV7UsuariosNombre);
            edtavUsuariosnombre_Visible = 1;
            AssignProp("", false, edtavUsuariosnombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuariosnombre_Visible), 5, 0), true);
            edtavUsuariosnombre_Enabled = 1;
            AssignProp("", false, edtavUsuariosnombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuariosnombre_Enabled), 5, 0), true);
            AV6UsuariosCurp = "";
            AssignAttri("", false, "AV6UsuariosCurp", AV6UsuariosCurp);
            edtavUsuarioscurp_Visible = 0;
            AssignProp("", false, edtavUsuarioscurp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuarioscurp_Visible), 5, 0), true);
            AV11UsuariosTelef = "";
            AssignAttri("", false, "AV11UsuariosTelef", AV11UsuariosTelef);
            edtavUsuariostelef_Visible = 0;
            AssignProp("", false, edtavUsuariostelef_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuariostelef_Visible), 5, 0), true);
            AV12UsuariosCorreo = "";
            AssignAttri("", false, "AV12UsuariosCorreo", AV12UsuariosCorreo);
            edtavUsuarioscorreo_Visible = 0;
            AssignProp("", false, edtavUsuarioscorreo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuarioscorreo_Visible), 5, 0), true);
            bttVerificar_Visible = 1;
            AssignProp("", false, bttVerificar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttVerificar_Visible), 5, 0), true);
            bttRecuperar_Visible = 0;
            AssignProp("", false, bttRecuperar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttRecuperar_Visible), 5, 0), true);
            bttRegresar_Visible = 0;
            AssignProp("", false, bttRegresar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttRegresar_Visible), 5, 0), true);
            GXt_SdtPropiedades1 = AV5AlertProperties;
            new getsweetmessage(context ).execute(  "warning",  "Información Incorrecta",  "Favor de Verificar",  true,  false, out  GXt_SdtPropiedades1) ;
            AV5AlertProperties = GXt_SdtPropiedades1;
            this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5AlertProperties", AV5AlertProperties);
      }

      protected void nextLoad( )
      {
      }

      protected void E161X2( )
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
         PA1X2( ) ;
         WS1X2( ) ;
         WE1X2( ) ;
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
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714344918", true, true);
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
         context.AddJavascriptSource("wprecupcontra.js", "?202262714344918", false, true);
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
         lblTextblock1_Internalname = "TEXTBLOCK1";
         lblViellall_Internalname = "VIELLALL";
         divTable2_Internalname = "TABLE2";
         edtavUsuariosnombre_Internalname = "vUSUARIOSNOMBRE";
         bttVerificar_Internalname = "VERIFICAR";
         edtavUsuarioscurp_Internalname = "vUSUARIOSCURP";
         edtavUsuariostelef_Internalname = "vUSUARIOSTELEF";
         edtavUsuarioscorreo_Internalname = "vUSUARIOSCORREO";
         bttRecuperar_Internalname = "RECUPERAR";
         bttRegresar_Internalname = "REGRESAR";
         divTable1_Internalname = "TABLE1";
         Ucalertas_Internalname = "UCALERTAS";
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
         bttRegresar_Visible = 1;
         bttRecuperar_Visible = 1;
         edtavUsuarioscorreo_Jsonclick = "";
         edtavUsuarioscorreo_Enabled = 1;
         edtavUsuarioscorreo_Visible = 1;
         edtavUsuariostelef_Jsonclick = "";
         edtavUsuariostelef_Enabled = 1;
         edtavUsuariostelef_Visible = 1;
         edtavUsuarioscurp_Jsonclick = "";
         edtavUsuarioscurp_Enabled = 1;
         edtavUsuarioscurp_Visible = 1;
         bttVerificar_Visible = 1;
         edtavUsuariosnombre_Jsonclick = "";
         edtavUsuariosnombre_Enabled = 1;
         edtavUsuariosnombre_Visible = 1;
         lblTextblock1_Fontsize = (int)(14.0m);
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Recupera Contraseña";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'VALIDAR'","{handler:'E131X2',iparms:[{av:'A66UsuariosNombre',fld:'USUARIOSNOMBRE',pic:'@!'},{av:'AV7UsuariosNombre',fld:'vUSUARIOSNOMBRE',pic:'@!'}]");
         setEventMetadata("'VALIDAR'",",oparms:[{av:'edtavUsuarioscurp_Visible',ctrl:'vUSUARIOSCURP',prop:'Visible'},{av:'edtavUsuariosnombre_Enabled',ctrl:'vUSUARIOSNOMBRE',prop:'Enabled'},{av:'edtavUsuarioscorreo_Visible',ctrl:'vUSUARIOSCORREO',prop:'Visible'},{av:'edtavUsuariostelef_Visible',ctrl:'vUSUARIOSTELEF',prop:'Visible'},{ctrl:'VERIFICAR',prop:'Visible'},{ctrl:'RECUPERAR',prop:'Visible'},{ctrl:'REGRESAR',prop:'Visible'},{av:'AV5AlertProperties',fld:'vALERTPROPERTIES',pic:''}]}");
         setEventMetadata("'REGRESAR'","{handler:'E141X2',iparms:[]");
         setEventMetadata("'REGRESAR'",",oparms:[]}");
         setEventMetadata("'RECUPERAR'","{handler:'E151X2',iparms:[{av:'A105UsuariosCurp',fld:'USUARIOSCURP',pic:'@!'},{av:'AV6UsuariosCurp',fld:'vUSUARIOSCURP',pic:'@!'},{av:'A260UsuariosTelef',fld:'USUARIOSTELEF',pic:''},{av:'AV11UsuariosTelef',fld:'vUSUARIOSTELEF',pic:''},{av:'A261UsuariosCorreo',fld:'USUARIOSCORREO',pic:''},{av:'AV12UsuariosCorreo',fld:'vUSUARIOSCORREO',pic:''},{av:'A68UsuariosPwd',fld:'USUARIOSPWD',pic:''},{av:'A67UsuariosKey',fld:'USUARIOSKEY',pic:''}]");
         setEventMetadata("'RECUPERAR'",",oparms:[{av:'AV5AlertProperties',fld:'vALERTPROPERTIES',pic:''},{av:'AV7UsuariosNombre',fld:'vUSUARIOSNOMBRE',pic:'@!'},{av:'edtavUsuariosnombre_Visible',ctrl:'vUSUARIOSNOMBRE',prop:'Visible'},{av:'edtavUsuariosnombre_Enabled',ctrl:'vUSUARIOSNOMBRE',prop:'Enabled'},{av:'AV6UsuariosCurp',fld:'vUSUARIOSCURP',pic:'@!'},{av:'edtavUsuarioscurp_Visible',ctrl:'vUSUARIOSCURP',prop:'Visible'},{av:'AV11UsuariosTelef',fld:'vUSUARIOSTELEF',pic:''},{av:'edtavUsuariostelef_Visible',ctrl:'vUSUARIOSTELEF',prop:'Visible'},{av:'AV12UsuariosCorreo',fld:'vUSUARIOSCORREO',pic:''},{av:'edtavUsuarioscorreo_Visible',ctrl:'vUSUARIOSCORREO',prop:'Visible'},{ctrl:'VERIFICAR',prop:'Visible'},{ctrl:'RECUPERAR',prop:'Visible'},{ctrl:'REGRESAR',prop:'Visible'}]}");
         setEventMetadata("'RETORNO'","{handler:'E111X1',iparms:[]");
         setEventMetadata("'RETORNO'",",oparms:[]}");
         setEventMetadata("VALIDV_USUARIOSCORREO","{handler:'Validv_Usuarioscorreo',iparms:[]");
         setEventMetadata("VALIDV_USUARIOSCORREO",",oparms:[]}");
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
         GXKey = "";
         AV5AlertProperties = new SdtPropiedades(context);
         A66UsuariosNombre = "";
         A105UsuariosCurp = "";
         A260UsuariosTelef = "";
         A261UsuariosCorreo = "";
         A68UsuariosPwd = "";
         A67UsuariosKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock1_Jsonclick = "";
         lblViellall_Jsonclick = "";
         TempTags = "";
         AV7UsuariosNombre = "";
         ClassString = "";
         StyleString = "";
         bttVerificar_Jsonclick = "";
         AV6UsuariosCurp = "";
         AV11UsuariosTelef = "";
         AV12UsuariosCorreo = "";
         bttRecuperar_Jsonclick = "";
         bttRegresar_Jsonclick = "";
         ucUcalertas = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H001X2_A11UsuariosId = new int[1] ;
         H001X2_A66UsuariosNombre = new String[] {""} ;
         H001X3_A11UsuariosId = new int[1] ;
         H001X3_A261UsuariosCorreo = new String[] {""} ;
         H001X3_A260UsuariosTelef = new String[] {""} ;
         H001X3_A105UsuariosCurp = new String[] {""} ;
         H001X3_A67UsuariosKey = new String[] {""} ;
         H001X3_A68UsuariosPwd = new String[] {""} ;
         AV10pass = "";
         GXt_SdtPropiedades1 = new SdtPropiedades(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wprecupcontra__default(),
            new Object[][] {
                new Object[] {
               H001X2_A11UsuariosId, H001X2_A66UsuariosNombre
               }
               , new Object[] {
               H001X3_A11UsuariosId, H001X3_A261UsuariosCorreo, H001X3_A260UsuariosTelef, H001X3_A105UsuariosCurp, H001X3_A67UsuariosKey, H001X3_A68UsuariosPwd
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
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV15GXLvl15 ;
      private short AV16GXLvl37 ;
      private short nGXWrapped ;
      private int lblTextblock1_Fontsize ;
      private int edtavUsuariosnombre_Visible ;
      private int edtavUsuariosnombre_Enabled ;
      private int bttVerificar_Visible ;
      private int edtavUsuarioscurp_Visible ;
      private int edtavUsuarioscurp_Enabled ;
      private int edtavUsuariostelef_Visible ;
      private int edtavUsuariostelef_Enabled ;
      private int edtavUsuarioscorreo_Visible ;
      private int edtavUsuarioscorreo_Enabled ;
      private int bttRecuperar_Visible ;
      private int bttRegresar_Visible ;
      private int idxLst ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String A260UsuariosTelef ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String divTable1_Internalname ;
      private String divTable2_Internalname ;
      private String lblTextblock1_Internalname ;
      private String lblTextblock1_Jsonclick ;
      private String lblViellall_Internalname ;
      private String lblViellall_Jsonclick ;
      private String edtavUsuariosnombre_Internalname ;
      private String TempTags ;
      private String edtavUsuariosnombre_Jsonclick ;
      private String ClassString ;
      private String StyleString ;
      private String bttVerificar_Internalname ;
      private String bttVerificar_Jsonclick ;
      private String edtavUsuarioscurp_Internalname ;
      private String edtavUsuarioscurp_Jsonclick ;
      private String edtavUsuariostelef_Internalname ;
      private String AV11UsuariosTelef ;
      private String edtavUsuariostelef_Jsonclick ;
      private String edtavUsuarioscorreo_Internalname ;
      private String edtavUsuarioscorreo_Jsonclick ;
      private String bttRecuperar_Internalname ;
      private String bttRecuperar_Jsonclick ;
      private String bttRegresar_Internalname ;
      private String bttRegresar_Jsonclick ;
      private String Ucalertas_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String scmdbuf ;
      private String AV10pass ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private String A66UsuariosNombre ;
      private String A105UsuariosCurp ;
      private String A261UsuariosCorreo ;
      private String A68UsuariosPwd ;
      private String A67UsuariosKey ;
      private String AV7UsuariosNombre ;
      private String AV6UsuariosCurp ;
      private String AV12UsuariosCorreo ;
      private GXUserControl ucUcalertas ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H001X2_A11UsuariosId ;
      private String[] H001X2_A66UsuariosNombre ;
      private int[] H001X3_A11UsuariosId ;
      private String[] H001X3_A261UsuariosCorreo ;
      private String[] H001X3_A260UsuariosTelef ;
      private String[] H001X3_A105UsuariosCurp ;
      private String[] H001X3_A67UsuariosKey ;
      private String[] H001X3_A68UsuariosPwd ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private SdtPropiedades AV5AlertProperties ;
      private SdtPropiedades GXt_SdtPropiedades1 ;
   }

   public class wprecupcontra__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH001X2 ;
          prmH001X2 = new Object[] {
          new Object[] {"AV7UsuariosNombre",System.Data.DbType.String,40,0}
          } ;
          Object[] prmH001X3 ;
          prmH001X3 = new Object[] {
          new Object[] {"AV6UsuariosCurp",System.Data.DbType.String,18,0} ,
          new Object[] {"AV11UsuariosTelef",System.Data.DbType.String,10,0} ,
          new Object[] {"AV12UsuariosCorreo",System.Data.DbType.String,100,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H001X2", "SELECT `UsuariosId`, `UsuariosNombre` FROM `Usuarios` WHERE `UsuariosNombre` = ? ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001X2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H001X3", "SELECT `UsuariosId`, `UsuariosCorreo`, `UsuariosTelef`, `UsuariosCurp`, `UsuariosKey`, `UsuariosPwd` FROM `Usuarios` WHERE (`UsuariosCurp` = ?) AND (`UsuariosTelef` = ?) AND (`UsuariosCorreo` = ?) ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001X3,100, GxCacheFrequency.OFF ,true,false )
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
                ((String[]) buf[2])[0] = rslt.getString(3, 10) ;
                ((String[]) buf[3])[0] = rslt.getVarchar(4) ;
                ((String[]) buf[4])[0] = rslt.getVarchar(5) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
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
                return;
             case 1 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (String)parms[2]);
                return;
       }
    }

 }

}
