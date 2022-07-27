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
   public class wpaltausuarios : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpaltausuarios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public wpaltausuarios( IGxContext context )
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
         PA2P2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2P2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714345284", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpaltausuarios.aspx") +"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Usuarioalta", AV5UsuarioAlta);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Usuarioalta", AV5UsuarioAlta);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vALERTPROPERTIES", AV7AlertProperties);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vALERTPROPERTIES", AV7AlertProperties);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSUARIOALTA", AV5UsuarioAlta);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSUARIOALTA", AV5UsuarioAlta);
         }
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
            WE2P2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2P2( ) ;
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
         return formatLink("wpaltausuarios.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "wpAltaUsuarios" ;
      }

      public override String GetPgmdesc( )
      {
         return "wp Alta Usuarios" ;
      }

      protected void WB2P0( )
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
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Alta Usuario", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_wpAltaUsuarios.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "Right", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblViellall_Internalname, "Regresar", "", "", lblViellall_Jsonclick, "'"+""+"'"+",false,"+"'"+"e112p1_client"+"'", "", "BtnTextBlockBack", 7, "", 1, 1, 0, "HLP_wpAltaUsuarios.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCtlusuarioscurp_Internalname, AV5UsuarioAlta.gxTpr_Usuarioscurp, StringUtil.RTrim( context.localUtil.Format( AV5UsuarioAlta.gxTpr_Usuarioscurp, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuarioscurp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtlusuarioscurp_Enabled, 0, "text", "", 40, "chr", 1, "row", 18, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpAltaUsuarios.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariosnombre_Internalname, AV5UsuarioAlta.gxTpr_Usuariosnombre, StringUtil.RTrim( context.localUtil.Format( AV5UsuarioAlta.gxTpr_Usuariosnombre, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariosnombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtlusuariosnombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpAltaUsuarios.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariosappat_Internalname, AV5UsuarioAlta.gxTpr_Usuariosappat, StringUtil.RTrim( context.localUtil.Format( AV5UsuarioAlta.gxTpr_Usuariosappat, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariosappat_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtlusuariosappat_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpAltaUsuarios.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariosapmat_Internalname, AV5UsuarioAlta.gxTpr_Usuariosapmat, StringUtil.RTrim( context.localUtil.Format( AV5UsuarioAlta.gxTpr_Usuariosapmat, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariosapmat_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtlusuariosapmat_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpAltaUsuarios.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariospwd_Internalname, AV5UsuarioAlta.gxTpr_Usuariospwd, StringUtil.RTrim( context.localUtil.Format( AV5UsuarioAlta.gxTpr_Usuariospwd, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariospwd_Jsonclick, 0, "Attribute", "color:"+context.BuildHTMLColor( edtavCtlusuariospwd_Forecolor)+";", "", "", "", 1, edtavCtlusuariospwd_Enabled, 0, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpAltaUsuarios.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariostelef_Internalname, StringUtil.RTrim( AV5UsuarioAlta.gxTpr_Usuariostelef), StringUtil.RTrim( context.localUtil.Format( AV5UsuarioAlta.gxTpr_Usuariostelef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariostelef_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtlusuariostelef_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpAltaUsuarios.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCtlusuarioscorreo_Internalname, AV5UsuarioAlta.gxTpr_Usuarioscorreo, StringUtil.RTrim( context.localUtil.Format( AV5UsuarioAlta.gxTpr_Usuarioscorreo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuarioscorreo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtlusuarioscorreo_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "", "left", true, "", "HLP_wpAltaUsuarios.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "d0e5d738-d4cd-4148-98b7-bf2166bc1ffa", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Guardar Información", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'GUARDAR\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_wpAltaUsuarios.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "93b2d7e5-9a13-41d9-baee-ede2124078b4", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage2_Jsonclick, "'"+""+"'"+",false,"+"'"+"e112p1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_wpAltaUsuarios.htm");
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
            ucUcalertas.SetProperty("Propiedades", AV7AlertProperties);
            ucUcalertas.Render(context, "sweetalert2", Ucalertas_Internalname, "UCALERTASContainer");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START2P2( )
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
            Form.Meta.addItem("description", "wp Alta Usuarios", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2P0( ) ;
      }

      protected void WS2P2( )
      {
         START2P2( ) ;
         EVT2P2( ) ;
      }

      protected void EVT2P2( )
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
                              E122P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'GUARDAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Guardar' */
                              E132P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E142P2 ();
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

      protected void WE2P2( )
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

      protected void PA2P2( )
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2P2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlusuariospwd_Enabled = 0;
         AssignProp("", false, edtavCtlusuariospwd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlusuariospwd_Enabled), 5, 0), true);
      }

      protected void RF2P2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E142P2 ();
            WB2P0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2P2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavCtlusuariospwd_Enabled = 0;
         AssignProp("", false, edtavCtlusuariospwd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlusuariospwd_Enabled), 5, 0), true);
      }

      protected void STRUP2P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E122P2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Usuarioalta"), AV5UsuarioAlta);
            ajax_req_read_hidden_sdt(cgiGet( "vALERTPROPERTIES"), AV7AlertProperties);
            /* Read saved values. */
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
         E122P2 ();
         if (returnInSub) return;
      }

      protected void E122P2( )
      {
         /* Start Routine */
         edtavCtlusuariospwd_Forecolor = GXUtil.RGB( 255, 0, 0);
         AssignProp("", false, edtavCtlusuariospwd_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavCtlusuariospwd_Forecolor), 9, 0), true);
         AV5UsuarioAlta.gxTpr_Usuariospwd = "AdminData*2022";
      }

      protected void E132P2( )
      {
         /* 'Guardar' Routine */
         AV5UsuarioAlta.gxTpr_Usuariosstatus = 1;
         AV5UsuarioAlta.gxTpr_Usuariostipo = 6;
         AV5UsuarioAlta.gxTpr_Rolid = 6;
         AV5UsuarioAlta.Save();
         if ( AV5UsuarioAlta.Success() )
         {
            context.CommitDataStores("wpaltausuarios",pr_default);
            GXt_SdtPropiedades1 = AV7AlertProperties;
            new getsweetmessage(context ).execute(  "success",  "Información Guardada Exitosamente",  "",  true,  false, out  GXt_SdtPropiedades1) ;
            AV7AlertProperties = GXt_SdtPropiedades1;
            this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
            CallWebObject(formatLink("accesobak.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            context.RollbackDataStores("wpaltausuarios",pr_default);
            GXt_SdtPropiedades1 = AV7AlertProperties;
            new getsweetmessage(context ).execute(  "warning",  AV5UsuarioAlta.GetMessages().ToJSonString(false),  "",  true,  false, out  GXt_SdtPropiedades1) ;
            AV7AlertProperties = GXt_SdtPropiedades1;
            this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5UsuarioAlta", AV5UsuarioAlta);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7AlertProperties", AV7AlertProperties);
      }

      protected void nextLoad( )
      {
      }

      protected void E142P2( )
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
         PA2P2( ) ;
         WS2P2( ) ;
         WE2P2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714345310", true, true);
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
         context.AddJavascriptSource("wpaltausuarios.js", "?202262714345311", false, true);
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
         edtavCtlusuarioscurp_Internalname = "CTLUSUARIOSCURP";
         edtavCtlusuariosnombre_Internalname = "CTLUSUARIOSNOMBRE";
         edtavCtlusuariosappat_Internalname = "CTLUSUARIOSAPPAT";
         edtavCtlusuariosapmat_Internalname = "CTLUSUARIOSAPMAT";
         edtavCtlusuariospwd_Internalname = "CTLUSUARIOSPWD";
         edtavCtlusuariostelef_Internalname = "CTLUSUARIOSTELEF";
         edtavCtlusuarioscorreo_Internalname = "CTLUSUARIOSCORREO";
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
         edtavCtlusuariospwd_Forecolor = (int)(0x000000);
         edtavCtlusuariospwd_Enabled = -1;
         edtavCtlusuarioscorreo_Jsonclick = "";
         edtavCtlusuarioscorreo_Enabled = 1;
         edtavCtlusuariostelef_Jsonclick = "";
         edtavCtlusuariostelef_Enabled = 1;
         edtavCtlusuariospwd_Jsonclick = "";
         edtavCtlusuariospwd_Forecolor = (int)(0x000000);
         edtavCtlusuariospwd_Enabled = 0;
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
         Form.Caption = "wp Alta Usuarios";
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
         setEventMetadata("'GUARDAR'","{handler:'E132P2',iparms:[{av:'AV5UsuarioAlta',fld:'vUSUARIOALTA',pic:''}]");
         setEventMetadata("'GUARDAR'",",oparms:[{av:'AV5UsuarioAlta',fld:'vUSUARIOALTA',pic:''},{av:'AV7AlertProperties',fld:'vALERTPROPERTIES',pic:''}]}");
         setEventMetadata("'REGRESAR'","{handler:'E112P1',iparms:[]");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV5UsuarioAlta = new SdtUsuarios(context);
         AV7AlertProperties = new SdtPropiedades(context);
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
         GXt_SdtPropiedades1 = new SdtPropiedades(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpaltausuarios__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlusuariospwd_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavCtlusuarioscurp_Enabled ;
      private int edtavCtlusuariosnombre_Enabled ;
      private int edtavCtlusuariosappat_Enabled ;
      private int edtavCtlusuariosapmat_Enabled ;
      private int edtavCtlusuariospwd_Forecolor ;
      private int edtavCtlusuariospwd_Enabled ;
      private int edtavCtlusuariostelef_Enabled ;
      private int edtavCtlusuarioscorreo_Enabled ;
      private int idxLst ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
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
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GXUserControl ucUcalertas ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private SdtUsuarios AV5UsuarioAlta ;
      private SdtPropiedades AV7AlertProperties ;
      private SdtPropiedades GXt_SdtPropiedades1 ;
   }

   public class wpaltausuarios__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
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
