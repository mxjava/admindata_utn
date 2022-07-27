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
   public class wpinfge : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpinfge( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public wpinfge( IGxContext context )
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
         dynavSelecperfil = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vSELECPERFIL") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvSELECPERFIL2J2( ) ;
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
         PA2J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2J2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714345218", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpinfge.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27UsuarioId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Usuarioalta", AV28UsuarioAlta);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Usuarioalta", AV28UsuarioAlta);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUPLOADEDFILES", AV36UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUPLOADEDFILES", AV36UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vALERTPROPERTIES", AV39AlertProperties);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vALERTPROPERTIES", AV39AlertProperties);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSUARIOALTA", AV28UsuarioAlta);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSUARIOALTA", AV28UsuarioAlta);
         }
         GxWebStd.gx_hidden_field( context, "vIMAGE_GXI", AV55Image_GXI);
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27UsuarioId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27UsuarioId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "FILEUPLOAD1_Maxnumberoffiles", StringUtil.LTrim( StringUtil.NToC( (decimal)(Fileupload1_Maxnumberoffiles), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILEUPLOAD1_Acceptedfiletypes", StringUtil.RTrim( Fileupload1_Acceptedfiletypes));
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
         if ( ! ( WebComp_Component1 == null ) )
         {
            WebComp_Component1.componentjscripts();
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
            WE2J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2J2( ) ;
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
         return formatLink("wpinfge.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "wpInfGe" ;
      }

      public override String GetPgmdesc( )
      {
         return "Informacion General" ;
      }

      protected void WB2J0( )
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "FormContainer1", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Datos Personales", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "BigGlobalTitle", 0, "", 1, 1, 0, "HLP_wpInfGe.htm");
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 col-md-3 col-lg-2", "left", "top", "", "", "div");
            wb_table1_15_2J2( true) ;
         }
         else
         {
            wb_table1_15_2J2( false) ;
         }
         return  ;
      }

      protected void wb_table1_15_2J2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-md-9 col-lg-10", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCtlusuariosnombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtlusuariosnombre_Internalname, "Nombre", "col-sm-3 AttributeTitleLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariosnombre_Internalname, AV28UsuarioAlta.gxTpr_Usuariosnombre, StringUtil.RTrim( context.localUtil.Format( AV28UsuarioAlta.gxTpr_Usuariosnombre, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariosnombre_Jsonclick, 0, "AttributeTitle", "", "", "", "", 1, edtavCtlusuariosnombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpInfGe.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCtlusuariosappat_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtlusuariosappat_Internalname, "Primer Apellido", "col-sm-3 AttributeTitleLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariosappat_Internalname, AV28UsuarioAlta.gxTpr_Usuariosappat, StringUtil.RTrim( context.localUtil.Format( AV28UsuarioAlta.gxTpr_Usuariosappat, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariosappat_Jsonclick, 0, "AttributeTitle", "", "", "", "", 1, edtavCtlusuariosappat_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpInfGe.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCtlusuariosapmat_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtlusuariosapmat_Internalname, "Segundo Apellido", "col-sm-3 AttributeTitleLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariosapmat_Internalname, AV28UsuarioAlta.gxTpr_Usuariosapmat, StringUtil.RTrim( context.localUtil.Format( AV28UsuarioAlta.gxTpr_Usuariosapmat, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariosapmat_Jsonclick, 0, "AttributeTitle", "", "", "", "", 1, edtavCtlusuariosapmat_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpInfGe.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCtlusuariosfecnacimiento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtlusuariosfecnacimiento_Internalname, "Fecha Nacimiento", "col-sm-3 AttributeTitleLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtavCtlusuariosfecnacimiento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariosfecnacimiento_Internalname, context.localUtil.Format(AV28UsuarioAlta.gxTpr_Usuariosfecnacimiento, "99/99/99"), context.localUtil.Format( AV28UsuarioAlta.gxTpr_Usuariosfecnacimiento, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariosfecnacimiento_Jsonclick, 0, "AttributeTitle", "", "", "", "", 1, edtavCtlusuariosfecnacimiento_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_wpInfGe.htm");
            GxWebStd.gx_bitmap( context, edtavCtlusuariosfecnacimiento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavCtlusuariosfecnacimiento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_wpInfGe.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCtlusuariosedad_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtlusuariosedad_Internalname, "Edad", "col-sm-3 AttributeTitleLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariosedad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28UsuarioAlta.gxTpr_Usuariosedad), 4, 0, ",", "")), ((edtavCtlusuariosedad_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV28UsuarioAlta.gxTpr_Usuariosedad), "ZZZ9")) : context.localUtil.Format( (decimal)(AV28UsuarioAlta.gxTpr_Usuariosedad), "ZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariosedad_Jsonclick, 0, "AttributeTitle", "", "", "", "", 1, edtavCtlusuariosedad_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_wpInfGe.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCtlusuariossexofor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtlusuariossexofor_Internalname, "Sexo", "col-sm-3 AttributeTitleLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariossexofor_Internalname, StringUtil.RTrim( AV28UsuarioAlta.gxTpr_Usuariossexofor), StringUtil.RTrim( context.localUtil.Format( AV28UsuarioAlta.gxTpr_Usuariossexofor, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariossexofor_Jsonclick, 0, "AttributeTitle", "", "", "", "", 1, edtavCtlusuariossexofor_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpInfGe.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCtlusuariostelef_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtlusuariostelef_Internalname, "Teléfono", "col-sm-3 AttributeTitleLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariostelef_Internalname, StringUtil.RTrim( AV28UsuarioAlta.gxTpr_Usuariostelef), StringUtil.RTrim( context.localUtil.Format( AV28UsuarioAlta.gxTpr_Usuariostelef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariostelef_Jsonclick, 0, "AttributeTitle", "", "", "", "", 1, edtavCtlusuariostelef_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpInfGe.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCtlusuarioscorreo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtlusuarioscorreo_Internalname, "Correo electrónico", "col-sm-3 AttributeTitleLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtlusuarioscorreo_Internalname, AV28UsuarioAlta.gxTpr_Usuarioscorreo, StringUtil.RTrim( context.localUtil.Format( AV28UsuarioAlta.gxTpr_Usuarioscorreo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuarioscorreo_Jsonclick, 0, "AttributeTitle", "", "", "", "", 1, edtavCtlusuarioscorreo_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "", "left", true, "", "HLP_wpInfGe.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCtlusuarioscurp_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtlusuarioscurp_Internalname, "CURP", "col-sm-3 AttributeTitleLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtlusuarioscurp_Internalname, AV28UsuarioAlta.gxTpr_Usuarioscurp, StringUtil.RTrim( context.localUtil.Format( AV28UsuarioAlta.gxTpr_Usuarioscurp, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuarioscurp_Jsonclick, 0, "AttributeTitle", "", "", "", "", 1, edtavCtlusuarioscurp_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpInfGe.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 col-md-4 col-lg-5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavSelecperfil_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavSelecperfil_Internalname, "*Seleecione Perfil", "col-sm-3 AttributeTitleLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSelecperfil, dynavSelecperfil_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV38SelecPerfil), 9, 0)), 1, dynavSelecperfil_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSelecperfil.Enabled, 0, 0, 0, "em", 0, "", ((dynavSelecperfil.FontBold==1) ? "font-weight:bold;" : "font-weight:normal;")+((dynavSelecperfil.BackColor==-1) ? "" : "background-color:"+context.BuildHTMLColor( dynavSelecperfil.BackColor)+";"), "AttributeTitle", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "", true, "HLP_wpInfGe.htm");
            dynavSelecperfil.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV38SelecPerfil), 9, 0));
            AssignProp("", false, dynavSelecperfil_Internalname, "Values", (String)(dynavSelecperfil.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 col-md-2", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 col-lg-2", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_wpInfGe.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "Right", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "c437546b-f1bf-4dfc-bbef-ae4524ef2773", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Modificar la información", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ACTUALIZAR\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_wpInfGe.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
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
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0086"+"", StringUtil.RTrim( WebComp_Component1_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0086"+""+"\""+((WebComp_Component1_Visible==1) ? "" : " style=\"display:none;\"")) ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Component1_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldComponent1), StringUtil.Lower( WebComp_Component1_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0086"+"");
                  }
                  WebComp_Component1.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldComponent1), StringUtil.Lower( WebComp_Component1_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucUcalertas.SetProperty("Propiedades", AV39AlertProperties);
            ucUcalertas.Render(context, "sweetalert2", Ucalertas_Internalname, "UCALERTASContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START2J2( )
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
            Form.Meta.addItem("description", "Informacion General", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2J0( ) ;
      }

      protected void WS2J2( )
      {
         START2J2( ) ;
         EVT2J2( ) ;
      }

      protected void EVT2J2( )
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
                              E112J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ACTUALIZAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Actualizar' */
                              E122J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E132J2 ();
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
                        if ( nCmpId == 86 )
                        {
                           OldComponent1 = cgiGet( "W0086");
                           if ( ( StringUtil.Len( OldComponent1) == 0 ) || ( StringUtil.StrCmp(OldComponent1, WebComp_Component1_Component) != 0 ) )
                           {
                              WebComp_Component1 = getWebComponent(GetType(), "GeneXus.Programs", OldComponent1, new Object[] {context} );
                              WebComp_Component1.ComponentInit();
                              WebComp_Component1.Name = "OldComponent1";
                              WebComp_Component1_Component = OldComponent1;
                           }
                           if ( StringUtil.Len( WebComp_Component1_Component) != 0 )
                           {
                              WebComp_Component1.componentprocess("W0086", "", sEvt);
                           }
                           WebComp_Component1_Component = OldComponent1;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE2J2( )
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

      protected void PA2J2( )
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
               GX_FocusControl = edtavCtlusuariosnombre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvSELECPERFIL2J2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSELECPERFIL_data2J2( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((String)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((String)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvSELECPERFIL_html2J2( )
      {
         int gxdynajaxvalue ;
         GXDLVvSELECPERFIL_data2J2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavSelecperfil.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((String)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavSelecperfil.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 9, 0)), ((String)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvSELECPERFIL_data2J2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("--Seleccione--");
         /* Using cursor H002J2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002J2_A278Perfiles_Id[0]), 9, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002J2_A279Perfiles_Nombre[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvSELECPERFIL_html2J2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavSelecperfil.ItemCount > 0 )
         {
            AV38SelecPerfil = (int)(NumberUtil.Val( dynavSelecperfil.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV38SelecPerfil), 9, 0))), "."));
            AssignAttri("", false, "AV38SelecPerfil", StringUtil.LTrimStr( (decimal)(AV38SelecPerfil), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSelecperfil.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV38SelecPerfil), 9, 0));
            AssignProp("", false, dynavSelecperfil_Internalname, "Values", dynavSelecperfil.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2J2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlusuariosfecnacimiento_Enabled = 0;
         AssignProp("", false, edtavCtlusuariosfecnacimiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlusuariosfecnacimiento_Enabled), 5, 0), true);
         edtavCtlusuariosedad_Enabled = 0;
         AssignProp("", false, edtavCtlusuariosedad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlusuariosedad_Enabled), 5, 0), true);
         edtavCtlusuariossexofor_Enabled = 0;
         AssignProp("", false, edtavCtlusuariossexofor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlusuariossexofor_Enabled), 5, 0), true);
      }

      protected void RF2J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( WebComp_Component1_Visible != 0 )
            {
               if ( StringUtil.Len( WebComp_Component1_Component) != 0 )
               {
                  WebComp_Component1.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E132J2 ();
            WB2J0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2J2( )
      {
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27UsuarioId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27UsuarioId), "ZZZZZZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavCtlusuariosfecnacimiento_Enabled = 0;
         AssignProp("", false, edtavCtlusuariosfecnacimiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlusuariosfecnacimiento_Enabled), 5, 0), true);
         edtavCtlusuariosedad_Enabled = 0;
         AssignProp("", false, edtavCtlusuariosedad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlusuariosedad_Enabled), 5, 0), true);
         edtavCtlusuariossexofor_Enabled = 0;
         AssignProp("", false, edtavCtlusuariossexofor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlusuariossexofor_Enabled), 5, 0), true);
         GXVvSELECPERFIL_html2J2( ) ;
      }

      protected void STRUP2J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Usuarioalta"), AV28UsuarioAlta);
            ajax_req_read_hidden_sdt(cgiGet( "vUPLOADEDFILES"), AV36UploadedFiles);
            ajax_req_read_hidden_sdt(cgiGet( "vALERTPROPERTIES"), AV39AlertProperties);
            /* Read saved values. */
            Fileupload1_Maxnumberoffiles = (int)(context.localUtil.CToN( cgiGet( "FILEUPLOAD1_Maxnumberoffiles"), ",", "."));
            Fileupload1_Acceptedfiletypes = cgiGet( "FILEUPLOAD1_Acceptedfiletypes");
            /* Read variables values. */
            AV30VarImagen = cgiGet( imgavVarimagen_Internalname);
            AV28UsuarioAlta.gxTpr_Usuariosnombre = StringUtil.Upper( cgiGet( edtavCtlusuariosnombre_Internalname));
            AV28UsuarioAlta.gxTpr_Usuariosappat = StringUtil.Upper( cgiGet( edtavCtlusuariosappat_Internalname));
            AV28UsuarioAlta.gxTpr_Usuariosapmat = StringUtil.Upper( cgiGet( edtavCtlusuariosapmat_Internalname));
            if ( context.localUtil.VCDate( cgiGet( edtavCtlusuariosfecnacimiento_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Nacimiento"}), 1, "CTLUSUARIOSFECNACIMIENTO");
               GX_FocusControl = edtavCtlusuariosfecnacimiento_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV28UsuarioAlta.gxTpr_Usuariosfecnacimiento = DateTime.MinValue;
            }
            else
            {
               AV28UsuarioAlta.gxTpr_Usuariosfecnacimiento = context.localUtil.CToD( cgiGet( edtavCtlusuariosfecnacimiento_Internalname), 2);
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCtlusuariosedad_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCtlusuariosedad_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CTLUSUARIOSEDAD");
               GX_FocusControl = edtavCtlusuariosedad_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV28UsuarioAlta.gxTpr_Usuariosedad = 0;
            }
            else
            {
               AV28UsuarioAlta.gxTpr_Usuariosedad = (short)(context.localUtil.CToN( cgiGet( edtavCtlusuariosedad_Internalname), ",", "."));
            }
            AV28UsuarioAlta.gxTpr_Usuariossexofor = cgiGet( edtavCtlusuariossexofor_Internalname);
            AV28UsuarioAlta.gxTpr_Usuariostelef = cgiGet( edtavCtlusuariostelef_Internalname);
            AV28UsuarioAlta.gxTpr_Usuarioscorreo = cgiGet( edtavCtlusuarioscorreo_Internalname);
            AV28UsuarioAlta.gxTpr_Usuarioscurp = StringUtil.Upper( cgiGet( edtavCtlusuarioscurp_Internalname));
            dynavSelecperfil.CurrentValue = cgiGet( dynavSelecperfil_Internalname);
            AV38SelecPerfil = (int)(NumberUtil.Val( cgiGet( dynavSelecperfil_Internalname), "."));
            AssignAttri("", false, "AV38SelecPerfil", StringUtil.LTrimStr( (decimal)(AV38SelecPerfil), 9, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXVvSELECPERFIL_html2J2( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E112J2 ();
         if (returnInSub) return;
      }

      protected void E112J2( )
      {
         /* Start Routine */
         AV27UsuarioId = (int)(NumberUtil.Val( AV26WebSession.Get("UsuarioId"), "."));
         AssignAttri("", false, "AV27UsuarioId", StringUtil.LTrimStr( (decimal)(AV27UsuarioId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27UsuarioId), "ZZZZZZZZ9"), context));
         AV28UsuarioAlta.Load(AV27UsuarioId);
         AV30VarImagen = AV28UsuarioAlta.gxTpr_Usuariosicono;
         AssignProp("", false, imgavVarimagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV30VarImagen)) ? AV52Varimagen_GXI : context.convertURL( context.PathToRelativeUrl( AV30VarImagen))), true);
         AssignProp("", false, imgavVarimagen_Internalname, "SrcSet", context.GetImageSrcSet( AV30VarImagen), true);
         AV52Varimagen_GXI = AV28UsuarioAlta.gxTpr_Usuariosicono_gxi;
         AssignProp("", false, imgavVarimagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV30VarImagen)) ? AV52Varimagen_GXI : context.convertURL( context.PathToRelativeUrl( AV30VarImagen))), true);
         AssignProp("", false, imgavVarimagen_Internalname, "SrcSet", context.GetImageSrcSet( AV30VarImagen), true);
         AV53GXLvl11 = 0;
         /* Using cursor H002J3 */
         pr_default.execute(1, new Object[] {AV27UsuarioId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A283PerfilesUsuariosEstatus = H002J3_A283PerfilesUsuariosEstatus[0];
            A11UsuariosId = H002J3_A11UsuariosId[0];
            A278Perfiles_Id = H002J3_A278Perfiles_Id[0];
            AV53GXLvl11 = 1;
            AV38SelecPerfil = A278Perfiles_Id;
            AssignAttri("", false, "AV38SelecPerfil", StringUtil.LTrimStr( (decimal)(AV38SelecPerfil), 9, 0));
            dynavSelecperfil.BackColor = GXUtil.RGB( 217, 231, 252);
            AssignProp("", false, dynavSelecperfil_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(dynavSelecperfil.BackColor), 9, 0), true);
            dynavSelecperfil.FontBold = 1;
            AssignProp("", false, dynavSelecperfil_Internalname, "Fontbold", StringUtil.Str( (decimal)(dynavSelecperfil.FontBold), 1, 0), true);
            WebComp_Component1_Visible = 1;
            AssignProp("", false, "gxHTMLWrpW0086"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Component1_Visible), 5, 0), true);
            /* Object Property */
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Component1_Component), StringUtil.Lower( "wpSelVacanteRegistro")) != 0 )
            {
               WebComp_Component1 = getWebComponent(GetType(), "GeneXus.Programs", "wpselvacanteregistro", new Object[] {context} );
               WebComp_Component1.ComponentInit();
               WebComp_Component1.Name = "wpSelVacanteRegistro";
               WebComp_Component1_Component = "wpSelVacanteRegistro";
            }
            if ( StringUtil.Len( WebComp_Component1_Component) != 0 )
            {
               WebComp_Component1.setjustcreated();
               WebComp_Component1.componentprepare(new Object[] {(String)"W0086",(String)"",(int)AV27UsuarioId});
               WebComp_Component1.componentbind(new Object[] {(String)""});
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( AV53GXLvl11 == 0 )
         {
            dynavSelecperfil.BackColor = GXUtil.RGB( 255, 142, 127);
            AssignProp("", false, dynavSelecperfil_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(dynavSelecperfil.BackColor), 9, 0), true);
            dynavSelecperfil.FontBold = 1;
            AssignProp("", false, dynavSelecperfil_Internalname, "Fontbold", StringUtil.Str( (decimal)(dynavSelecperfil.FontBold), 1, 0), true);
            WebComp_Component1_Visible = 0;
            AssignProp("", false, "gxHTMLWrpW0086"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Component1_Visible), 5, 0), true);
         }
      }

      protected void E122J2( )
      {
         /* 'Actualizar' Routine */
         AV54GXV10 = 1;
         while ( AV54GXV10 <= AV36UploadedFiles.Count )
         {
            AV37FileUploadData = ((SdtFileUploadData)AV36UploadedFiles.Item(AV54GXV10));
            AV32Image = AV37FileUploadData.gxTpr_File;
            AV55Image_GXI = GXDbFile.GetUriFromFile( "", "", AV37FileUploadData.gxTpr_File);
            AV28UsuarioAlta.gxTpr_Usuariosicono = AV32Image;
            AV28UsuarioAlta.gxTpr_Usuariosicono_gxi = AV55Image_GXI;
            AV54GXV10 = (int)(AV54GXV10+1);
         }
         AV28UsuarioAlta.Save();
         if ( (0==AV38SelecPerfil) )
         {
            GXt_SdtPropiedades1 = AV39AlertProperties;
            new getsweetmessage(context ).execute(  "warning",  "Favor de seleccionar un perfil",  "",  true,  false, out  GXt_SdtPropiedades1) ;
            AV39AlertProperties = GXt_SdtPropiedades1;
            this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
         }
         else
         {
            if ( AV28UsuarioAlta.Success() )
            {
               context.CommitDataStores("wpinfge",pr_default);
               new pr_guardaperfilusuario(context ).execute(  AV27UsuarioId,  AV38SelecPerfil,  "Personal") ;
               new pr_cambtipo(context ).execute(  AV27UsuarioId,  0,  "Prospecto") ;
               context.DoAjaxRefresh();
               CallWebObject(formatLink("wpinfge.aspx") );
               context.wjLocDisableFrm = 1;
            }
            else
            {
               context.RollbackDataStores("wpinfge",pr_default);
               GXt_SdtPropiedades1 = AV39AlertProperties;
               new getsweetmessage(context ).execute(  "warning",  AV28UsuarioAlta.GetMessages().ToJSonString(false),  "",  true,  false, out  GXt_SdtPropiedades1) ;
               AV39AlertProperties = GXt_SdtPropiedades1;
               this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28UsuarioAlta", AV28UsuarioAlta);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39AlertProperties", AV39AlertProperties);
      }

      protected void nextLoad( )
      {
      }

      protected void E132J2( )
      {
         /* Load Routine */
      }

      protected void wb_table1_15_2J2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable3_Internalname, tblTable3_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+imgavVarimagen_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Fixed300";
            StyleString = "";
            AV30VarImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV30VarImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( AV52Varimagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV30VarImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV30VarImagen)) ? AV52Varimagen_GXI : context.PathToRelativeUrl( AV30VarImagen));
            GxWebStd.gx_bitmap( context, imgavVarimagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"maximumuploadsize=\"actual\""+" ", "", "", 1, AV30VarImagen_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_wpInfGe.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucFileupload1.SetProperty("TooltipText", Fileupload1_Tooltiptext);
            ucFileupload1.SetProperty("MaxNumberOfFiles", Fileupload1_Maxnumberoffiles);
            ucFileupload1.SetProperty("AcceptedFileTypes", Fileupload1_Acceptedfiletypes);
            ucFileupload1.SetProperty("UploadedFiles", AV36UploadedFiles);
            ucFileupload1.Render(context, "fileupload", Fileupload1_Internalname, "FILEUPLOAD1Container");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_15_2J2e( true) ;
         }
         else
         {
            wb_table1_15_2J2e( false) ;
         }
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
         PA2J2( ) ;
         WS2J2( ) ;
         WE2J2( ) ;
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
         AddStyleSheetFile("FileUpload/fileupload.min.css", "");
         AddStyleSheetFile("SweetAlert2/css/font-awesome.min.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Component1 == null ) )
         {
            if ( StringUtil.Len( WebComp_Component1_Component) != 0 )
            {
               WebComp_Component1.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714345271", true, true);
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
         context.AddJavascriptSource("wpinfge.js", "?202262714345271", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         context.AddJavascriptSource("SweetAlert2/sweetalert2.all.min.js", "", false, true);
         context.AddJavascriptSource("SweetAlert2/SweetAlert2Render.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynavSelecperfil.Name = "vSELECPERFIL";
         dynavSelecperfil.WebTags = "";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = "TEXTBLOCK1";
         imgavVarimagen_Internalname = "vVARIMAGEN";
         Fileupload1_Internalname = "FILEUPLOAD1";
         tblTable3_Internalname = "TABLE3";
         edtavCtlusuariosnombre_Internalname = "CTLUSUARIOSNOMBRE";
         edtavCtlusuariosappat_Internalname = "CTLUSUARIOSAPPAT";
         edtavCtlusuariosapmat_Internalname = "CTLUSUARIOSAPMAT";
         edtavCtlusuariosfecnacimiento_Internalname = "CTLUSUARIOSFECNACIMIENTO";
         edtavCtlusuariosedad_Internalname = "CTLUSUARIOSEDAD";
         edtavCtlusuariossexofor_Internalname = "CTLUSUARIOSSEXOFOR";
         edtavCtlusuariostelef_Internalname = "CTLUSUARIOSTELEF";
         edtavCtlusuarioscorreo_Internalname = "CTLUSUARIOSCORREO";
         edtavCtlusuarioscurp_Internalname = "CTLUSUARIOSCURP";
         dynavSelecperfil_Internalname = "vSELECPERFIL";
         divTable2_Internalname = "TABLE2";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         imgImage3_Internalname = "IMAGE3";
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
         Fileupload1_Tooltiptext = "";
         edtavCtlusuariossexofor_Enabled = -1;
         edtavCtlusuariosedad_Enabled = -1;
         edtavCtlusuariosfecnacimiento_Enabled = -1;
         WebComp_Component1_Visible = 1;
         AssignProp("", false, "gxHTMLWrpW0086"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Component1_Visible), 5, 0), true);
         dynavSelecperfil_Jsonclick = "";
         dynavSelecperfil.Enabled = 1;
         dynavSelecperfil.BackStyle = -1;
         dynavSelecperfil.BackColor = (int)(0xFFFFFF);
         dynavSelecperfil.FontBold = 0;
         edtavCtlusuarioscurp_Jsonclick = "";
         edtavCtlusuarioscurp_Enabled = 1;
         edtavCtlusuarioscorreo_Jsonclick = "";
         edtavCtlusuarioscorreo_Enabled = 1;
         edtavCtlusuariostelef_Jsonclick = "";
         edtavCtlusuariostelef_Enabled = 1;
         edtavCtlusuariossexofor_Jsonclick = "";
         edtavCtlusuariossexofor_Enabled = 0;
         edtavCtlusuariosedad_Jsonclick = "";
         edtavCtlusuariosedad_Enabled = 0;
         edtavCtlusuariosfecnacimiento_Jsonclick = "";
         edtavCtlusuariosfecnacimiento_Enabled = 0;
         edtavCtlusuariosapmat_Jsonclick = "";
         edtavCtlusuariosapmat_Enabled = 1;
         edtavCtlusuariosappat_Jsonclick = "";
         edtavCtlusuariosappat_Enabled = 1;
         edtavCtlusuariosnombre_Jsonclick = "";
         edtavCtlusuariosnombre_Enabled = 1;
         Fileupload1_Acceptedfiletypes = "image";
         Fileupload1_Maxnumberoffiles = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Informacion General";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV27UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZ9',hsh:true},{av:'dynavSelecperfil'},{av:'AV38SelecPerfil',fld:'vSELECPERFIL',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynavSelecperfil'},{av:'AV38SelecPerfil',fld:'vSELECPERFIL',pic:'ZZZZZZZZ9'}]}");
         setEventMetadata("'ACTUALIZAR'","{handler:'E122J2',iparms:[{av:'AV36UploadedFiles',fld:'vUPLOADEDFILES',pic:''},{av:'AV28UsuarioAlta',fld:'vUSUARIOALTA',pic:''},{av:'AV55Image_GXI',fld:'vIMAGE_GXI',pic:''},{av:'AV27UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZ9',hsh:true},{av:'dynavSelecperfil'},{av:'AV38SelecPerfil',fld:'vSELECPERFIL',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("'ACTUALIZAR'",",oparms:[{av:'AV28UsuarioAlta',fld:'vUSUARIOALTA',pic:''},{av:'AV39AlertProperties',fld:'vALERTPROPERTIES',pic:''},{av:'dynavSelecperfil'},{av:'AV38SelecPerfil',fld:'vSELECPERFIL',pic:'ZZZZZZZZ9'}]}");
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
         AV28UsuarioAlta = new SdtUsuarios(context);
         AV36UploadedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "ADMINDATA1");
         AV39AlertProperties = new SdtPropiedades(context);
         AV55Image_GXI = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock1_Jsonclick = "";
         TempTags = "";
         lblTextblock4_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         imgImage3_Jsonclick = "";
         WebComp_Component1_Component = "";
         OldComponent1 = "";
         ucUcalertas = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H002J2_A278Perfiles_Id = new int[1] ;
         H002J2_A279Perfiles_Nombre = new String[] {""} ;
         H002J2_A280Perfiles_Estatus = new short[1] ;
         AV30VarImagen = "";
         AV26WebSession = context.GetSession();
         AV52Varimagen_GXI = "";
         H002J3_A283PerfilesUsuariosEstatus = new short[1] ;
         H002J3_A11UsuariosId = new int[1] ;
         H002J3_A278Perfiles_Id = new int[1] ;
         AV37FileUploadData = new SdtFileUploadData(context);
         AV32Image = "";
         GXt_SdtPropiedades1 = new SdtPropiedades(context);
         sStyleString = "";
         ucFileupload1 = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpinfge__default(),
            new Object[][] {
                new Object[] {
               H002J2_A278Perfiles_Id, H002J2_A279Perfiles_Nombre, H002J2_A280Perfiles_Estatus
               }
               , new Object[] {
               H002J3_A283PerfilesUsuariosEstatus, H002J3_A11UsuariosId, H002J3_A278Perfiles_Id
               }
            }
         );
         WebComp_Component1 = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlusuariosfecnacimiento_Enabled = 0;
         edtavCtlusuariosedad_Enabled = 0;
         edtavCtlusuariossexofor_Enabled = 0;
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
      private short AV53GXLvl11 ;
      private short A283PerfilesUsuariosEstatus ;
      private short nGXWrapped ;
      private int AV27UsuarioId ;
      private int Fileupload1_Maxnumberoffiles ;
      private int edtavCtlusuariosnombre_Enabled ;
      private int edtavCtlusuariosappat_Enabled ;
      private int edtavCtlusuariosapmat_Enabled ;
      private int edtavCtlusuariosfecnacimiento_Enabled ;
      private int edtavCtlusuariosedad_Enabled ;
      private int edtavCtlusuariossexofor_Enabled ;
      private int edtavCtlusuariostelef_Enabled ;
      private int edtavCtlusuarioscorreo_Enabled ;
      private int edtavCtlusuarioscurp_Enabled ;
      private int AV38SelecPerfil ;
      private int WebComp_Component1_Visible ;
      private int gxdynajaxindex ;
      private int A11UsuariosId ;
      private int A278Perfiles_Id ;
      private int AV54GXV10 ;
      private int idxLst ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String Fileupload1_Acceptedfiletypes ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String divTable1_Internalname ;
      private String lblTextblock1_Internalname ;
      private String lblTextblock1_Jsonclick ;
      private String divTable2_Internalname ;
      private String edtavCtlusuariosnombre_Internalname ;
      private String TempTags ;
      private String edtavCtlusuariosnombre_Jsonclick ;
      private String edtavCtlusuariosappat_Internalname ;
      private String edtavCtlusuariosappat_Jsonclick ;
      private String edtavCtlusuariosapmat_Internalname ;
      private String edtavCtlusuariosapmat_Jsonclick ;
      private String edtavCtlusuariosfecnacimiento_Internalname ;
      private String edtavCtlusuariosfecnacimiento_Jsonclick ;
      private String edtavCtlusuariosedad_Internalname ;
      private String edtavCtlusuariosedad_Jsonclick ;
      private String edtavCtlusuariossexofor_Internalname ;
      private String edtavCtlusuariossexofor_Jsonclick ;
      private String edtavCtlusuariostelef_Internalname ;
      private String edtavCtlusuariostelef_Jsonclick ;
      private String edtavCtlusuarioscorreo_Internalname ;
      private String edtavCtlusuarioscorreo_Jsonclick ;
      private String edtavCtlusuarioscurp_Internalname ;
      private String edtavCtlusuarioscurp_Jsonclick ;
      private String dynavSelecperfil_Internalname ;
      private String dynavSelecperfil_Jsonclick ;
      private String lblTextblock4_Internalname ;
      private String lblTextblock4_Jsonclick ;
      private String ClassString ;
      private String StyleString ;
      private String sImgUrl ;
      private String imgImage3_Internalname ;
      private String imgImage3_Jsonclick ;
      private String WebComp_Component1_Component ;
      private String OldComponent1 ;
      private String Ucalertas_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String gxwrpcisep ;
      private String scmdbuf ;
      private String imgavVarimagen_Internalname ;
      private String sStyleString ;
      private String tblTable3_Internalname ;
      private String Fileupload1_Tooltiptext ;
      private String Fileupload1_Internalname ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV30VarImagen_IsBlob ;
      private String AV55Image_GXI ;
      private String AV52Varimagen_GXI ;
      private String AV30VarImagen ;
      private String AV32Image ;
      private IGxSession AV26WebSession ;
      private GXWebComponent WebComp_Component1 ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXUserControl ucUcalertas ;
      private GXUserControl ucFileupload1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavSelecperfil ;
      private IDataStoreProvider pr_default ;
      private int[] H002J2_A278Perfiles_Id ;
      private String[] H002J2_A279Perfiles_Nombre ;
      private short[] H002J2_A280Perfiles_Estatus ;
      private short[] H002J3_A283PerfilesUsuariosEstatus ;
      private int[] H002J3_A11UsuariosId ;
      private int[] H002J3_A278Perfiles_Id ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtFileUploadData> AV36UploadedFiles ;
      private GXWebForm Form ;
      private SdtFileUploadData AV37FileUploadData ;
      private SdtUsuarios AV28UsuarioAlta ;
      private SdtPropiedades AV39AlertProperties ;
      private SdtPropiedades GXt_SdtPropiedades1 ;
   }

   public class wpinfge__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH002J2 ;
          prmH002J2 = new Object[] {
          } ;
          Object[] prmH002J3 ;
          prmH002J3 = new Object[] {
          new Object[] {"AV27UsuarioId",System.Data.DbType.Int32,9,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H002J2", "SELECT `Perfiles_Id`, `Perfiles_Nombre`, `Perfiles_Estatus` FROM `Perfiles` WHERE `Perfiles_Estatus` = 1 ORDER BY `Perfiles_Nombre` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002J2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002J3", "SELECT `PerfilesUsuariosEstatus`, `UsuariosId`, `Perfiles_Id` FROM `PerfilesUsuariosPerfil` WHERE (`UsuariosId` = ?) AND (`PerfilesUsuariosEstatus` = 1) ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002J3,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
             case 1 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

}
