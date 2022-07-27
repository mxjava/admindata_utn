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
   public class wpaltausuariosadm : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpaltausuariosadm( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public wpaltausuariosadm( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( String aP0_Perfil ,
                           int aP1_UsuariosId )
      {
         this.AV7Perfil = aP0_Perfil;
         this.AV8UsuariosId = aP1_UsuariosId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCtlusuariostipo = new GXCombobox();
         cmbavCtlusuariosstatus = new GXCombobox();
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("masterpagemikb", "GeneXus.Programs.masterpagemikb", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
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
         PA2Q2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2Q2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714345317", false, true);
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpaltausuariosadm.aspx"+UrlEncode(StringUtil.RTrim(AV7Perfil)) + "," + UrlEncode("" +AV8UsuariosId);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpaltausuariosadm.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPERFIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7Perfil, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8UsuariosId), "ZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Usuarioalta", AV5UsuarioAlta);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Usuarioalta", AV5UsuarioAlta);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vALERTPROPERTIES", AV6AlertProperties);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vALERTPROPERTIES", AV6AlertProperties);
         }
         GxWebStd.gx_hidden_field( context, "vPERFIL", StringUtil.RTrim( AV7Perfil));
         GxWebStd.gx_hidden_field( context, "gxhash_vPERFIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7Perfil, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSUARIOALTA", AV5UsuarioAlta);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSUARIOALTA", AV5UsuarioAlta);
         }
         GxWebStd.gx_hidden_field( context, "USUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vUSUARIOIDREC", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10UsuarioIdRec), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSTIPO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A272UsuariosTipo), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8UsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8UsuariosId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "UCALERTAS_Width", StringUtil.RTrim( Ucalertas_Width));
         GxWebStd.gx_hidden_field( context, "UCALERTAS_Height", StringUtil.RTrim( Ucalertas_Height));
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
            WE2Q2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2Q2( ) ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpaltausuariosadm.aspx"+UrlEncode(StringUtil.RTrim(AV7Perfil)) + "," + UrlEncode("" +AV8UsuariosId);
         return formatLink("wpaltausuariosadm.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override String GetPgmname( )
      {
         return "wpAltaUsuariosAdm" ;
      }

      public override String GetPgmdesc( )
      {
         return "wp Candidatos" ;
      }

      protected void WB2Q0( )
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "WWAdvancedContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "FormContainer1", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Alta Usuario", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_wpAltaUsuariosAdm.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "Right", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblViellall_Internalname, "Regresar", "", "", lblViellall_Jsonclick, "'"+""+"'"+",false,"+"'"+"e112q1_client"+"'", "", "BtnTextBlockBack", 7, "", 1, 1, 0, "HLP_wpAltaUsuariosAdm.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCtlusuarioscurp_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtlusuarioscurp_Internalname, "*   CURP", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtlusuarioscurp_Internalname, AV5UsuarioAlta.gxTpr_Usuarioscurp, StringUtil.RTrim( context.localUtil.Format( AV5UsuarioAlta.gxTpr_Usuarioscurp, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuarioscurp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtlusuarioscurp_Enabled, 0, "text", "", 40, "chr", 1, "row", 18, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpAltaUsuariosAdm.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCtlusuariosnombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtlusuariosnombre_Internalname, "*   Nombre", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariosnombre_Internalname, AV5UsuarioAlta.gxTpr_Usuariosnombre, StringUtil.RTrim( context.localUtil.Format( AV5UsuarioAlta.gxTpr_Usuariosnombre, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariosnombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtlusuariosnombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpAltaUsuariosAdm.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCtlusuariosappat_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtlusuariosappat_Internalname, "*   Primer Apellido", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariosappat_Internalname, AV5UsuarioAlta.gxTpr_Usuariosappat, StringUtil.RTrim( context.localUtil.Format( AV5UsuarioAlta.gxTpr_Usuariosappat, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariosappat_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtlusuariosappat_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpAltaUsuariosAdm.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCtlusuariosapmat_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtlusuariosapmat_Internalname, "Segundo Apellido", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariosapmat_Internalname, AV5UsuarioAlta.gxTpr_Usuariosapmat, StringUtil.RTrim( context.localUtil.Format( AV5UsuarioAlta.gxTpr_Usuariosapmat, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariosapmat_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtlusuariosapmat_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpAltaUsuariosAdm.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCtlusuariospwd_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtlusuariospwd_Internalname, "Contraseña", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariospwd_Internalname, AV5UsuarioAlta.gxTpr_Usuariospwd, StringUtil.RTrim( context.localUtil.Format( AV5UsuarioAlta.gxTpr_Usuariospwd, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariospwd_Jsonclick, 0, "Attribute", "color:"+context.BuildHTMLColor( edtavCtlusuariospwd_Forecolor)+";", "", "", "", 1, edtavCtlusuariospwd_Enabled, 1, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpAltaUsuariosAdm.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCtlusuariostelef_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtlusuariostelef_Internalname, "*   Teléfono", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariostelef_Internalname, StringUtil.RTrim( AV5UsuarioAlta.gxTpr_Usuariostelef), StringUtil.RTrim( context.localUtil.Format( AV5UsuarioAlta.gxTpr_Usuariostelef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariostelef_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtlusuariostelef_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpAltaUsuariosAdm.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCtlusuarioscorreo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtlusuarioscorreo_Internalname, "*   Correo electrónico", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtlusuarioscorreo_Internalname, AV5UsuarioAlta.gxTpr_Usuarioscorreo, StringUtil.RTrim( context.localUtil.Format( AV5UsuarioAlta.gxTpr_Usuarioscorreo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuarioscorreo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtlusuarioscorreo_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "", "left", true, "", "HLP_wpAltaUsuariosAdm.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavCtlusuariostipo.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavCtlusuariostipo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCtlusuariostipo_Internalname, "*     Tipo", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCtlusuariostipo, cmbavCtlusuariostipo_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV5UsuarioAlta.gxTpr_Usuariostipo), 4, 0)), 1, cmbavCtlusuariostipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavCtlusuariostipo.Visible, cmbavCtlusuariostipo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "", true, "HLP_wpAltaUsuariosAdm.htm");
            cmbavCtlusuariostipo.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5UsuarioAlta.gxTpr_Usuariostipo), 4, 0));
            AssignProp("", false, cmbavCtlusuariostipo_Internalname, "Values", (String)(cmbavCtlusuariostipo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavCtlusuariosstatus.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavCtlusuariosstatus_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCtlusuariosstatus_Internalname, "Estatús", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCtlusuariosstatus, cmbavCtlusuariosstatus_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV5UsuarioAlta.gxTpr_Usuariosstatus), 1, 0)), 1, cmbavCtlusuariosstatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavCtlusuariosstatus.Visible, cmbavCtlusuariosstatus.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "", true, "HLP_wpAltaUsuariosAdm.htm");
            cmbavCtlusuariosstatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5UsuarioAlta.gxTpr_Usuariosstatus), 1, 0));
            AssignProp("", false, cmbavCtlusuariosstatus_Internalname, "Values", (String)(cmbavCtlusuariosstatus.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "Right", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "d0e5d738-d4cd-4148-98b7-bf2166bc1ffa", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Guardar Información", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'GUARDAR\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_wpAltaUsuariosAdm.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "93b2d7e5-9a13-41d9-baee-ede2124078b4", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Regresar", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage2_Jsonclick, "'"+""+"'"+",false,"+"'"+"e112q1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_wpAltaUsuariosAdm.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* User Defined Control */
            ucUcalertas.SetProperty("Width", Ucalertas_Width);
            ucUcalertas.SetProperty("Height", Ucalertas_Height);
            ucUcalertas.SetProperty("Propiedades", AV6AlertProperties);
            ucUcalertas.Render(context, "sweetalert2", Ucalertas_Internalname, "UCALERTASContainer");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START2Q2( )
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
            Form.Meta.addItem("description", "wp Candidatos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2Q0( ) ;
      }

      protected void WS2Q2( )
      {
         START2Q2( ) ;
         EVT2Q2( ) ;
      }

      protected void EVT2Q2( )
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
                              E122Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'GUARDAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Guardar' */
                              E132Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E142Q2 ();
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

      protected void WE2Q2( )
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

      protected void PA2Q2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpaltausuariosadm.aspx")), "wpaltausuariosadm.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpaltausuariosadm.aspx")))) ;
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
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetNextPar( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV7Perfil = gxfirstwebparm;
                     AssignAttri("", false, "AV7Perfil", AV7Perfil);
                     GxWebStd.gx_hidden_field( context, "gxhash_vPERFIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7Perfil, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV8UsuariosId = (int)(NumberUtil.Val( GetNextPar( ), "."));
                        AssignAttri("", false, "AV8UsuariosId", StringUtil.LTrimStr( (decimal)(AV8UsuariosId), 6, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8UsuariosId), "ZZZZZ9"), context));
                     }
                  }
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
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
               GX_FocusControl = edtavCtlusuarioscurp_Internalname;
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
         if ( cmbavCtlusuariostipo.ItemCount > 0 )
         {
            AV5UsuarioAlta.gxTpr_Usuariostipo = (short)(NumberUtil.Val( cmbavCtlusuariostipo.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5UsuarioAlta.gxTpr_Usuariostipo), 4, 0))), "."));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCtlusuariostipo.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5UsuarioAlta.gxTpr_Usuariostipo), 4, 0));
            AssignProp("", false, cmbavCtlusuariostipo_Internalname, "Values", cmbavCtlusuariostipo.ToJavascriptSource(), true);
         }
         if ( cmbavCtlusuariosstatus.ItemCount > 0 )
         {
            AV5UsuarioAlta.gxTpr_Usuariosstatus = (short)(NumberUtil.Val( cmbavCtlusuariosstatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5UsuarioAlta.gxTpr_Usuariosstatus), 1, 0))), "."));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCtlusuariosstatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5UsuarioAlta.gxTpr_Usuariosstatus), 1, 0));
            AssignProp("", false, cmbavCtlusuariosstatus_Internalname, "Values", cmbavCtlusuariosstatus.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2Q2( ) ;
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

      protected void RF2Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E142Q2 ();
            WB2Q0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2Q2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP2Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E122Q2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Usuarioalta"), AV5UsuarioAlta);
            ajax_req_read_hidden_sdt(cgiGet( "vALERTPROPERTIES"), AV6AlertProperties);
            ajax_req_read_hidden_sdt(cgiGet( "vUSUARIOALTA"), AV5UsuarioAlta);
            /* Read saved values. */
            AV7Perfil = cgiGet( "vPERFIL");
            Ucalertas_Width = cgiGet( "UCALERTAS_Width");
            Ucalertas_Height = cgiGet( "UCALERTAS_Height");
            /* Read variables values. */
            AV5UsuarioAlta.gxTpr_Usuarioscurp = StringUtil.Upper( cgiGet( edtavCtlusuarioscurp_Internalname));
            AV5UsuarioAlta.gxTpr_Usuariosnombre = StringUtil.Upper( cgiGet( edtavCtlusuariosnombre_Internalname));
            AV5UsuarioAlta.gxTpr_Usuariosappat = StringUtil.Upper( cgiGet( edtavCtlusuariosappat_Internalname));
            AV5UsuarioAlta.gxTpr_Usuariosapmat = StringUtil.Upper( cgiGet( edtavCtlusuariosapmat_Internalname));
            AV5UsuarioAlta.gxTpr_Usuariospwd = cgiGet( edtavCtlusuariospwd_Internalname);
            AV5UsuarioAlta.gxTpr_Usuariostelef = cgiGet( edtavCtlusuariostelef_Internalname);
            AV5UsuarioAlta.gxTpr_Usuarioscorreo = cgiGet( edtavCtlusuarioscorreo_Internalname);
            cmbavCtlusuariostipo.CurrentValue = cgiGet( cmbavCtlusuariostipo_Internalname);
            AV5UsuarioAlta.gxTpr_Usuariostipo = (short)(NumberUtil.Val( cgiGet( cmbavCtlusuariostipo_Internalname), "."));
            cmbavCtlusuariosstatus.CurrentValue = cgiGet( cmbavCtlusuariosstatus_Internalname);
            AV5UsuarioAlta.gxTpr_Usuariosstatus = (short)(NumberUtil.Val( cgiGet( cmbavCtlusuariosstatus_Internalname), "."));
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
         E122Q2 ();
         if (returnInSub) return;
      }

      protected void E122Q2( )
      {
         /* Start Routine */
         if ( StringUtil.StrCmp(AV7Perfil, "Modificar") == 0 )
         {
            AV5UsuarioAlta.Load(AV8UsuariosId);
         }
         else if ( StringUtil.StrCmp(AV7Perfil, "Candidato") == 0 )
         {
            /* Execute user subroutine: 'OCULTACAMPOS' */
            S112 ();
            if (returnInSub) return;
            cmbavCtlusuariostipo.Visible = 0;
            AssignProp("", false, cmbavCtlusuariostipo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavCtlusuariostipo.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV7Perfil, "Insertar") == 0 )
         {
            /* Execute user subroutine: 'OCULTACAMPOS' */
            S112 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(AV7Perfil, "Postulante") == 0 )
         {
            /* Execute user subroutine: 'OCULTACAMPOS' */
            S112 ();
            if (returnInSub) return;
            cmbavCtlusuariostipo.Visible = 0;
            AssignProp("", false, cmbavCtlusuariostipo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavCtlusuariostipo.Visible), 5, 0), true);
         }
      }

      protected void E132Q2( )
      {
         /* 'Guardar' Routine */
         if ( StringUtil.StrCmp(AV7Perfil, "Modificar") == 0 )
         {
            AV5UsuarioAlta.gxTpr_Rolid = AV5UsuarioAlta.gxTpr_Usuariostipo;
         }
         else if ( StringUtil.StrCmp(AV7Perfil, "Candidato") == 0 )
         {
            AV5UsuarioAlta.gxTpr_Rolid = 6;
            AV5UsuarioAlta.gxTpr_Usuariostipo = 3;
            AV10UsuarioIdRec = (short)(NumberUtil.Val( AV11websesion.Get("UsuarioId"), "."));
            AssignAttri("", false, "AV10UsuarioIdRec", StringUtil.LTrimStr( (decimal)(AV10UsuarioIdRec), 4, 0));
         }
         else if ( StringUtil.StrCmp(AV7Perfil, "Insertar") == 0 )
         {
            AV5UsuarioAlta.gxTpr_Rolid = AV5UsuarioAlta.gxTpr_Usuariostipo;
         }
         else if ( StringUtil.StrCmp(AV7Perfil, "Postulante") == 0 )
         {
            AV5UsuarioAlta.gxTpr_Rolid = 6;
            AV5UsuarioAlta.gxTpr_Usuariostipo = 3;
         }
         AV5UsuarioAlta.Save();
         if ( AV5UsuarioAlta.Success() )
         {
            context.CommitDataStores("wpaltausuariosadm",pr_default);
            GXt_SdtPropiedades1 = AV6AlertProperties;
            new getsweetmessage(context ).execute(  "success",  "Información Guardada Exitosamente",  "",  true,  false, out  GXt_SdtPropiedades1) ;
            AV6AlertProperties = GXt_SdtPropiedades1;
            if ( StringUtil.StrCmp(AV7Perfil, "Candidato") == 0 )
            {
               /* Using cursor H002Q2 */
               pr_default.execute(0);
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A11UsuariosId = H002Q2_A11UsuariosId[0];
                  AV12UltimoUsuario = A11UsuariosId;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  pr_default.readNext(0);
               }
               pr_default.close(0);
               new pr_cambtipo(context ).execute(  AV12UltimoUsuario,  AV10UsuarioIdRec,  "Candidato") ;
            }
            if ( StringUtil.StrCmp(AV7Perfil, "Postulante") == 0 )
            {
               /* Using cursor H002Q3 */
               pr_default.execute(1);
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A272UsuariosTipo = H002Q3_A272UsuariosTipo[0];
                  A11UsuariosId = H002Q3_A11UsuariosId[0];
                  AV10UsuarioIdRec = (short)(A11UsuariosId);
                  AssignAttri("", false, "AV10UsuarioIdRec", StringUtil.LTrimStr( (decimal)(AV10UsuarioIdRec), 4, 0));
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               /* Using cursor H002Q4 */
               pr_default.execute(2);
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A11UsuariosId = H002Q4_A11UsuariosId[0];
                  AV12UltimoUsuario = A11UsuariosId;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               new pr_cambtipo(context ).execute(  AV12UltimoUsuario,  AV10UsuarioIdRec,  "Candidato") ;
            }
            this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
            context.DoAjaxRefresh();
         }
         else
         {
            context.RollbackDataStores("wpaltausuariosadm",pr_default);
            GXt_SdtPropiedades1 = AV6AlertProperties;
            new getsweetmessage(context ).execute(  "warning",  AV5UsuarioAlta.GetMessages().ToJSonString(false),  "",  true,  false, out  GXt_SdtPropiedades1) ;
            AV6AlertProperties = GXt_SdtPropiedades1;
            this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5UsuarioAlta", AV5UsuarioAlta);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6AlertProperties", AV6AlertProperties);
      }

      protected void S112( )
      {
         /* 'OCULTACAMPOS' Routine */
         AV5UsuarioAlta.gxTpr_Usuariospwd = "AdminData*2022";
         AV5UsuarioAlta.gxTpr_Usuariosstatus = 1;
         cmbavCtlusuariosstatus.Visible = 0;
         AssignProp("", false, cmbavCtlusuariosstatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavCtlusuariosstatus.Visible), 5, 0), true);
         edtavCtlusuariospwd_Forecolor = GXUtil.RGB( 255, 0, 0);
         AssignProp("", false, edtavCtlusuariospwd_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavCtlusuariospwd_Forecolor), 9, 0), true);
         edtavCtlusuariospwd_Enabled = 0;
         AssignProp("", false, edtavCtlusuariospwd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlusuariospwd_Enabled), 5, 0), true);
      }

      protected void nextLoad( )
      {
      }

      protected void E142Q2( )
      {
         /* Load Routine */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7Perfil = (String)getParm(obj,0);
         AssignAttri("", false, "AV7Perfil", AV7Perfil);
         GxWebStd.gx_hidden_field( context, "gxhash_vPERFIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7Perfil, "")), context));
         AV8UsuariosId = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV8UsuariosId", StringUtil.LTrimStr( (decimal)(AV8UsuariosId), 6, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8UsuariosId), "ZZZZZ9"), context));
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
         PA2Q2( ) ;
         WS2Q2( ) ;
         WE2Q2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714345358", true, true);
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
         context.AddJavascriptSource("wpaltausuariosadm.js", "?202262714345358", false, true);
         context.AddJavascriptSource("SweetAlert2/sweetalert2.all.min.js", "", false, true);
         context.AddJavascriptSource("SweetAlert2/SweetAlert2Render.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavCtlusuariostipo.Name = "CTLUSUARIOSTIPO";
         cmbavCtlusuariostipo.WebTags = "";
         cmbavCtlusuariostipo.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 4, 0)), "Seleccione", 0);
         cmbavCtlusuariostipo.addItem("1", "Administrador", 0);
         cmbavCtlusuariostipo.addItem("6", "Postulantes", 0);
         cmbavCtlusuariostipo.addItem("4", "Operaciones", 0);
         cmbavCtlusuariostipo.addItem("2", "Coordinador RYS", 0);
         cmbavCtlusuariostipo.addItem("5", "Reclutador", 0);
         cmbavCtlusuariostipo.addItem("3", "Candidatos", 0);
         if ( cmbavCtlusuariostipo.ItemCount > 0 )
         {
            AV5UsuarioAlta.gxTpr_Usuariostipo = (short)(NumberUtil.Val( cmbavCtlusuariostipo.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5UsuarioAlta.gxTpr_Usuariostipo), 4, 0))), "."));
         }
         cmbavCtlusuariosstatus.Name = "CTLUSUARIOSSTATUS";
         cmbavCtlusuariosstatus.WebTags = "";
         cmbavCtlusuariosstatus.addItem("1", "Activo", 0);
         cmbavCtlusuariosstatus.addItem("0", "Inactivo", 0);
         if ( cmbavCtlusuariosstatus.ItemCount > 0 )
         {
            AV5UsuarioAlta.gxTpr_Usuariosstatus = (short)(NumberUtil.Val( cmbavCtlusuariosstatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5UsuarioAlta.gxTpr_Usuariosstatus), 1, 0))), "."));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = "TEXTBLOCK1";
         lblViellall_Internalname = "VIELLALL";
         divTable2_Internalname = "TABLE2";
         edtavCtlusuarioscurp_Internalname = "CTLUSUARIOSCURP";
         edtavCtlusuariosnombre_Internalname = "CTLUSUARIOSNOMBRE";
         edtavCtlusuariosappat_Internalname = "CTLUSUARIOSAPPAT";
         edtavCtlusuariosapmat_Internalname = "CTLUSUARIOSAPMAT";
         edtavCtlusuariospwd_Internalname = "CTLUSUARIOSPWD";
         edtavCtlusuariostelef_Internalname = "CTLUSUARIOSTELEF";
         edtavCtlusuarioscorreo_Internalname = "CTLUSUARIOSCORREO";
         cmbavCtlusuariostipo_Internalname = "CTLUSUARIOSTIPO";
         cmbavCtlusuariosstatus_Internalname = "CTLUSUARIOSSTATUS";
         imgImage1_Internalname = "IMAGE1";
         imgImage2_Internalname = "IMAGE2";
         divTable3_Internalname = "TABLE3";
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
         edtavCtlusuariospwd_Enabled = 1;
         edtavCtlusuariospwd_Forecolor = (int)(0x000000);
         cmbavCtlusuariosstatus_Jsonclick = "";
         cmbavCtlusuariosstatus.Enabled = 1;
         cmbavCtlusuariosstatus.Visible = 1;
         cmbavCtlusuariostipo_Jsonclick = "";
         cmbavCtlusuariostipo.Enabled = 1;
         cmbavCtlusuariostipo.Visible = 1;
         edtavCtlusuarioscorreo_Jsonclick = "";
         edtavCtlusuarioscorreo_Enabled = 1;
         edtavCtlusuariostelef_Jsonclick = "";
         edtavCtlusuariostelef_Enabled = 1;
         edtavCtlusuariospwd_Jsonclick = "";
         edtavCtlusuariospwd_Forecolor = (int)(0x000000);
         edtavCtlusuariospwd_Enabled = 1;
         edtavCtlusuariosapmat_Jsonclick = "";
         edtavCtlusuariosapmat_Enabled = 1;
         edtavCtlusuariosappat_Jsonclick = "";
         edtavCtlusuariosappat_Enabled = 1;
         edtavCtlusuariosnombre_Jsonclick = "";
         edtavCtlusuariosnombre_Enabled = 1;
         edtavCtlusuarioscurp_Jsonclick = "";
         edtavCtlusuarioscurp_Enabled = 1;
         Ucalertas_Height = "150";
         Ucalertas_Width = "150";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "wp Candidatos";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV7Perfil',fld:'vPERFIL',pic:'',hsh:true},{av:'AV8UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'GUARDAR'","{handler:'E132Q2',iparms:[{av:'AV7Perfil',fld:'vPERFIL',pic:'',hsh:true},{av:'AV5UsuarioAlta',fld:'vUSUARIOALTA',pic:''},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV10UsuarioIdRec',fld:'vUSUARIOIDREC',pic:'ZZZ9'},{av:'A272UsuariosTipo',fld:'USUARIOSTIPO',pic:'ZZZ9'}]");
         setEventMetadata("'GUARDAR'",",oparms:[{av:'AV5UsuarioAlta',fld:'vUSUARIOALTA',pic:''},{av:'AV10UsuarioIdRec',fld:'vUSUARIOIDREC',pic:'ZZZ9'},{av:'AV6AlertProperties',fld:'vALERTPROPERTIES',pic:''}]}");
         setEventMetadata("'REGRESAR'","{handler:'E112Q1',iparms:[{av:'AV7Perfil',fld:'vPERFIL',pic:'',hsh:true}]");
         setEventMetadata("'REGRESAR'",",oparms:[]}");
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
         wcpOAV7Perfil = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV5UsuarioAlta = new SdtUsuarios(context);
         AV6AlertProperties = new SdtPropiedades(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock1_Jsonclick = "";
         lblViellall_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         imgImage1_Jsonclick = "";
         imgImage2_Jsonclick = "";
         ucUcalertas = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV11websesion = context.GetSession();
         scmdbuf = "";
         H002Q2_A11UsuariosId = new int[1] ;
         H002Q3_A272UsuariosTipo = new short[1] ;
         H002Q3_A11UsuariosId = new int[1] ;
         H002Q4_A11UsuariosId = new int[1] ;
         GXt_SdtPropiedades1 = new SdtPropiedades(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpaltausuariosadm__default(),
            new Object[][] {
                new Object[] {
               H002Q2_A11UsuariosId
               }
               , new Object[] {
               H002Q3_A272UsuariosTipo, H002Q3_A11UsuariosId
               }
               , new Object[] {
               H002Q4_A11UsuariosId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV10UsuarioIdRec ;
      private short A272UsuariosTipo ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int AV8UsuariosId ;
      private int wcpOAV8UsuariosId ;
      private int A11UsuariosId ;
      private int edtavCtlusuarioscurp_Enabled ;
      private int edtavCtlusuariosnombre_Enabled ;
      private int edtavCtlusuariosappat_Enabled ;
      private int edtavCtlusuariosapmat_Enabled ;
      private int edtavCtlusuariospwd_Forecolor ;
      private int edtavCtlusuariospwd_Enabled ;
      private int edtavCtlusuariostelef_Enabled ;
      private int edtavCtlusuarioscorreo_Enabled ;
      private int AV12UltimoUsuario ;
      private int idxLst ;
      private String AV7Perfil ;
      private String wcpOAV7Perfil ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GXEncryptionTmp ;
      private String Ucalertas_Width ;
      private String Ucalertas_Height ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String divTable1_Internalname ;
      private String divTable2_Internalname ;
      private String lblTextblock1_Internalname ;
      private String lblTextblock1_Jsonclick ;
      private String lblViellall_Internalname ;
      private String lblViellall_Jsonclick ;
      private String edtavCtlusuarioscurp_Internalname ;
      private String TempTags ;
      private String edtavCtlusuarioscurp_Jsonclick ;
      private String edtavCtlusuariosnombre_Internalname ;
      private String edtavCtlusuariosnombre_Jsonclick ;
      private String edtavCtlusuariosappat_Internalname ;
      private String edtavCtlusuariosappat_Jsonclick ;
      private String edtavCtlusuariosapmat_Internalname ;
      private String edtavCtlusuariosapmat_Jsonclick ;
      private String edtavCtlusuariospwd_Internalname ;
      private String edtavCtlusuariospwd_Jsonclick ;
      private String edtavCtlusuariostelef_Internalname ;
      private String edtavCtlusuariostelef_Jsonclick ;
      private String edtavCtlusuarioscorreo_Internalname ;
      private String edtavCtlusuarioscorreo_Jsonclick ;
      private String cmbavCtlusuariostipo_Internalname ;
      private String cmbavCtlusuariostipo_Jsonclick ;
      private String cmbavCtlusuariosstatus_Internalname ;
      private String cmbavCtlusuariosstatus_Jsonclick ;
      private String divTable3_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String sImgUrl ;
      private String imgImage1_Internalname ;
      private String imgImage1_Jsonclick ;
      private String imgImage2_Internalname ;
      private String imgImage2_Jsonclick ;
      private String Ucalertas_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String GXDecQS ;
      private String scmdbuf ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private IGxSession AV11websesion ;
      private GXUserControl ucUcalertas ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCtlusuariostipo ;
      private GXCombobox cmbavCtlusuariosstatus ;
      private IDataStoreProvider pr_default ;
      private int[] H002Q2_A11UsuariosId ;
      private short[] H002Q3_A272UsuariosTipo ;
      private int[] H002Q3_A11UsuariosId ;
      private int[] H002Q4_A11UsuariosId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private SdtPropiedades AV6AlertProperties ;
      private SdtPropiedades GXt_SdtPropiedades1 ;
      private SdtUsuarios AV5UsuarioAlta ;
   }

   public class wpaltausuariosadm__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002Q2 ;
          prmH002Q2 = new Object[] {
          } ;
          Object[] prmH002Q3 ;
          prmH002Q3 = new Object[] {
          } ;
          Object[] prmH002Q4 ;
          prmH002Q4 = new Object[] {
          } ;
          def= new CursorDef[] {
              new CursorDef("H002Q2", "SELECT `UsuariosId` FROM `Usuarios` ORDER BY `UsuariosId` DESC  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Q2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H002Q3", "SELECT `UsuariosTipo`, `UsuariosId` FROM `Usuarios` WHERE `UsuariosTipo` = 5 ORDER BY `UsuariosTipo` DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Q3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H002Q4", "SELECT `UsuariosId` FROM `Usuarios` ORDER BY `UsuariosId` DESC  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Q4,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
       }
    }

 }

}
