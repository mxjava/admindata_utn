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
   public class wpinfgetodlados : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpinfgetodlados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public wpinfgetodlados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_UsuarioId )
      {
         this.AV10UsuarioId = aP0_UsuarioId;
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
         dynVacantes_Id = new GXCombobox();
         cmbVacantesUsuariosEstatus = new GXCombobox();
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
               GXDLVvSELECPERFIL3A2( ) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               nRC_GXsfl_93 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_93_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_93_idx = GetNextPar( );
               AV17informacion = GetNextPar( );
               cmbVacantesUsuariosEstatus.FontBold = (short)(NumberUtil.Val( GetNextPar( ), "."));
               AssignProp("", false, cmbVacantesUsuariosEstatus_Internalname, "Fontbold", StringUtil.Str( (decimal)(cmbVacantesUsuariosEstatus.FontBold), 1, 0), !bGXsfl_93_Refreshing);
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid1_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               subGrid1_Rows = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV10UsuarioId = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV17informacion = GetNextPar( );
               cmbVacantesUsuariosEstatus.FontBold = (short)(NumberUtil.Val( GetNextPar( ), "."));
               AssignProp("", false, cmbVacantesUsuariosEstatus_Internalname, "Fontbold", StringUtil.Str( (decimal)(cmbVacantesUsuariosEstatus.FontBold), 1, 0), !bGXsfl_93_Refreshing);
               AV14SelecPerfil = (int)(NumberUtil.Val( GetNextPar( ), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV10UsuarioId, AV17informacion, AV14SelecPerfil) ;
               AddString( context.getJSONResponse( )) ;
               return  ;
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
         PA3A2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3A2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20226271435085", false, true);
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpinfgetodlados.aspx"+UrlEncode("" +AV10UsuarioId);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpinfgetodlados.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10UsuarioId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Usuarioalta", AV9UsuarioAlta);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Usuarioalta", AV9UsuarioAlta);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_93", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_93), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUPLOADEDFILES", AV8UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUPLOADEDFILES", AV8UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vALERTPROPERTIES", AV15AlertProperties);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vALERTPROPERTIES", AV15AlertProperties);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSUARIOALTA", AV9UsuarioAlta);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSUARIOALTA", AV9UsuarioAlta);
         }
         GxWebStd.gx_hidden_field( context, "vIMAGE_GXI", AV33Image_GXI);
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10UsuarioId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10UsuarioId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "FILEUPLOAD1_Maxnumberoffiles", StringUtil.LTrim( StringUtil.NToC( (decimal)(Fileupload1_Maxnumberoffiles), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILEUPLOAD1_Acceptedfiletypes", StringUtil.RTrim( Fileupload1_Acceptedfiletypes));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSESTATUS_Fontbold", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbVacantesUsuariosEstatus.FontBold), 1, 0, ".", "")));
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
            WE3A2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3A2( ) ;
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
         GXEncryptionTmp = "wpinfgetodlados.aspx"+UrlEncode("" +AV10UsuarioId);
         return formatLink("wpinfgetodlados.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override String GetPgmname( )
      {
         return "wpInfGeTodLados" ;
      }

      public override String GetPgmdesc( )
      {
         return "wp Candidatos" ;
      }

      protected void WB3A0( )
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
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Datos Personales", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "BigGlobalTitle", 0, "", 1, 1, 0, "HLP_wpInfGeTodLados.htm");
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
            wb_table1_15_3A2( true) ;
         }
         else
         {
            wb_table1_15_3A2( false) ;
         }
         return  ;
      }

      protected void wb_table1_15_3A2e( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_93_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariosnombre_Internalname, AV9UsuarioAlta.gxTpr_Usuariosnombre, StringUtil.RTrim( context.localUtil.Format( AV9UsuarioAlta.gxTpr_Usuariosnombre, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariosnombre_Jsonclick, 0, "AttributeTitle", "", "", "", "", 1, edtavCtlusuariosnombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpInfGeTodLados.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_93_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariosappat_Internalname, AV9UsuarioAlta.gxTpr_Usuariosappat, StringUtil.RTrim( context.localUtil.Format( AV9UsuarioAlta.gxTpr_Usuariosappat, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariosappat_Jsonclick, 0, "AttributeTitle", "", "", "", "", 1, edtavCtlusuariosappat_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpInfGeTodLados.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'" + sGXsfl_93_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariosapmat_Internalname, AV9UsuarioAlta.gxTpr_Usuariosapmat, StringUtil.RTrim( context.localUtil.Format( AV9UsuarioAlta.gxTpr_Usuariosapmat, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariosapmat_Jsonclick, 0, "AttributeTitle", "", "", "", "", 1, edtavCtlusuariosapmat_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpInfGeTodLados.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariosfecnacimiento_Internalname, context.localUtil.Format(AV9UsuarioAlta.gxTpr_Usuariosfecnacimiento, "99/99/99"), context.localUtil.Format( AV9UsuarioAlta.gxTpr_Usuariosfecnacimiento, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariosfecnacimiento_Jsonclick, 0, "AttributeTitle", "", "", "", "", 1, edtavCtlusuariosfecnacimiento_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_wpInfGeTodLados.htm");
            GxWebStd.gx_bitmap( context, edtavCtlusuariosfecnacimiento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavCtlusuariosfecnacimiento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_wpInfGeTodLados.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariosedad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9UsuarioAlta.gxTpr_Usuariosedad), 4, 0, ",", "")), ((edtavCtlusuariosedad_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV9UsuarioAlta.gxTpr_Usuariosedad), "ZZZ9")) : context.localUtil.Format( (decimal)(AV9UsuarioAlta.gxTpr_Usuariosedad), "ZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariosedad_Jsonclick, 0, "AttributeTitle", "", "", "", "", 1, edtavCtlusuariosedad_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_wpInfGeTodLados.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariossexofor_Internalname, StringUtil.RTrim( AV9UsuarioAlta.gxTpr_Usuariossexofor), StringUtil.RTrim( context.localUtil.Format( AV9UsuarioAlta.gxTpr_Usuariossexofor, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariossexofor_Jsonclick, 0, "AttributeTitle", "", "", "", "", 1, edtavCtlusuariossexofor_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpInfGeTodLados.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_93_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtlusuariostelef_Internalname, StringUtil.RTrim( AV9UsuarioAlta.gxTpr_Usuariostelef), StringUtil.RTrim( context.localUtil.Format( AV9UsuarioAlta.gxTpr_Usuariostelef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuariostelef_Jsonclick, 0, "AttributeTitle", "", "", "", "", 1, edtavCtlusuariostelef_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpInfGeTodLados.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_93_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtlusuarioscorreo_Internalname, AV9UsuarioAlta.gxTpr_Usuarioscorreo, StringUtil.RTrim( context.localUtil.Format( AV9UsuarioAlta.gxTpr_Usuarioscorreo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuarioscorreo_Jsonclick, 0, "AttributeTitle", "", "", "", "", 1, edtavCtlusuarioscorreo_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "", "left", true, "", "HLP_wpInfGeTodLados.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_93_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtlusuarioscurp_Internalname, AV9UsuarioAlta.gxTpr_Usuarioscurp, StringUtil.RTrim( context.localUtil.Format( AV9UsuarioAlta.gxTpr_Usuarioscurp, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlusuarioscurp_Jsonclick, 0, "AttributeTitle", "", "", "", "", 1, edtavCtlusuarioscurp_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpInfGeTodLados.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_93_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSelecperfil, dynavSelecperfil_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV14SelecPerfil), 9, 0)), 1, dynavSelecperfil_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSelecperfil.Enabled, 0, 0, 0, "em", 0, "", ((dynavSelecperfil.FontBold==1) ? "font-weight:bold;" : "font-weight:normal;")+((dynavSelecperfil.BackColor==-1) ? "" : "background-color:"+context.BuildHTMLColor( dynavSelecperfil.BackColor)+";"), "AttributeTitle", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "", true, "HLP_wpInfGeTodLados.htm");
            dynavSelecperfil.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14SelecPerfil), 9, 0));
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Right", "top", "", "", "div");
            wb_table2_75_3A2( true) ;
         }
         else
         {
            wb_table2_75_3A2( false) ;
         }
         return  ;
      }

      protected void wb_table2_75_3A2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Participación en vacantes", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "BigGlobalTitle", 0, "", 1, 1, 0, "HLP_wpInfGeTodLados.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            wb_table3_90_3A2( true) ;
         }
         else
         {
            wb_table3_90_3A2( false) ;
         }
         return  ;
      }

      protected void wb_table3_90_3A2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0100"+"", StringUtil.RTrim( WebComp_Component1_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0100"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Component1_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldComponent1), StringUtil.Lower( WebComp_Component1_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0100"+"");
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
            ucUcalertas.SetProperty("Propiedades", AV15AlertProperties);
            ucUcalertas.Render(context, "sweetalert2", Ucalertas_Internalname, "UCALERTASContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 93 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3A2( )
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
         STRUP3A0( ) ;
      }

      protected void WS3A2( )
      {
         START3A2( ) ;
         EVT3A2( ) ;
      }

      protected void EVT3A2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'ACTUALIZAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Actualizar' */
                              E113A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "'INFVACANTE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "'INFVACANTE'") == 0 ) )
                           {
                              nGXsfl_93_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_93_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_93_idx), 4, 0), 4, "0");
                              SubsflControlProps_932( ) ;
                              A11UsuariosId = (int)(context.localUtil.CToN( cgiGet( edtUsuariosId_Internalname), ",", "."));
                              dynVacantes_Id.Name = dynVacantes_Id_Internalname;
                              dynVacantes_Id.CurrentValue = cgiGet( dynVacantes_Id_Internalname);
                              A263Vacantes_Id = (int)(NumberUtil.Val( cgiGet( dynVacantes_Id_Internalname), "."));
                              cmbVacantesUsuariosEstatus.Name = cmbVacantesUsuariosEstatus_Internalname;
                              cmbVacantesUsuariosEstatus.CurrentValue = cgiGet( cmbVacantesUsuariosEstatus_Internalname);
                              A290VacantesUsuariosEstatus = (short)(NumberUtil.Val( cgiGet( cmbVacantesUsuariosEstatus_Internalname), "."));
                              n290VacantesUsuariosEstatus = false;
                              AV17informacion = cgiGet( edtavInformacion_Internalname);
                              AssignProp("", false, edtavInformacion_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV17informacion)) ? AV29Informacion_GXI : context.convertURL( context.PathToRelativeUrl( AV17informacion))), !bGXsfl_93_Refreshing);
                              AssignProp("", false, edtavInformacion_Internalname, "SrcSet", context.GetImageSrcSet( AV17informacion), true);
                              A288VacantesUsuariosFechaP = context.localUtil.CToT( cgiGet( edtVacantesUsuariosFechaP_Internalname), 0);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E123A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'INFVACANTE'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'InfVacante' */
                                    E133A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E143A2 ();
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
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(NumberUtil.Val( sEvtType, "."));
                        if ( nCmpId == 100 )
                        {
                           OldComponent1 = cgiGet( "W0100");
                           if ( ( StringUtil.Len( OldComponent1) == 0 ) || ( StringUtil.StrCmp(OldComponent1, WebComp_Component1_Component) != 0 ) )
                           {
                              WebComp_Component1 = getWebComponent(GetType(), "GeneXus.Programs", OldComponent1, new Object[] {context} );
                              WebComp_Component1.ComponentInit();
                              WebComp_Component1.Name = "OldComponent1";
                              WebComp_Component1_Component = OldComponent1;
                           }
                           if ( StringUtil.Len( WebComp_Component1_Component) != 0 )
                           {
                              WebComp_Component1.componentprocess("W0100", "", sEvt);
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

      protected void WE3A2( )
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

      protected void PA3A2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpinfgetodlados.aspx")), "wpinfgetodlados.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpinfgetodlados.aspx")))) ;
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
                     AV10UsuarioId = (int)(NumberUtil.Val( gxfirstwebparm, "."));
                     AssignAttri("", false, "AV10UsuarioId", StringUtil.LTrimStr( (decimal)(AV10UsuarioId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10UsuarioId), "ZZZZZZZZ9"), context));
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

      protected void GXDLVvSELECPERFIL3A2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSELECPERFIL_data3A2( ) ;
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

      protected void GXVvSELECPERFIL_html3A2( )
      {
         int gxdynajaxvalue ;
         GXDLVvSELECPERFIL_data3A2( ) ;
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

      protected void GXDLVvSELECPERFIL_data3A2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("--Seleccione--");
         /* Using cursor H003A2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H003A2_A278Perfiles_Id[0]), 9, 0, ".", "")));
            gxdynajaxctrldescr.Add(H003A2_A279Perfiles_Nombre[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_932( ) ;
         while ( nGXsfl_93_idx <= nRC_GXsfl_93 )
         {
            sendrow_932( ) ;
            nGXsfl_93_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_93_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_93_idx+1);
            sGXsfl_93_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_93_idx), 4, 0), 4, "0");
            SubsflControlProps_932( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        int AV10UsuarioId ,
                                        String AV17informacion ,
                                        int AV14SelecPerfil )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF3A2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_VACANTES_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A263Vacantes_Id), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "VACANTES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A263Vacantes_Id), 9, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvSELECPERFIL_html3A2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavSelecperfil.ItemCount > 0 )
         {
            AV14SelecPerfil = (int)(NumberUtil.Val( dynavSelecperfil.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV14SelecPerfil), 9, 0))), "."));
            AssignAttri("", false, "AV14SelecPerfil", StringUtil.LTrimStr( (decimal)(AV14SelecPerfil), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSelecperfil.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14SelecPerfil), 9, 0));
            AssignProp("", false, dynavSelecperfil_Internalname, "Values", dynavSelecperfil.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3A2( ) ;
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

      protected void RF3A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 93;
         nGXsfl_93_idx = 1;
         sGXsfl_93_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_93_idx), 4, 0), 4, "0");
         SubsflControlProps_932( ) ;
         bGXsfl_93_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "WorkWith");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
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
            SubsflControlProps_932( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            /* Using cursor H003A3 */
            pr_default.execute(1, new Object[] {AV10UsuarioId, GXPagingFrom2, GXPagingTo2});
            nGXsfl_93_idx = 1;
            sGXsfl_93_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_93_idx), 4, 0), 4, "0");
            SubsflControlProps_932( ) ;
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A288VacantesUsuariosFechaP = H003A3_A288VacantesUsuariosFechaP[0];
               A290VacantesUsuariosEstatus = H003A3_A290VacantesUsuariosEstatus[0];
               n290VacantesUsuariosEstatus = H003A3_n290VacantesUsuariosEstatus[0];
               A263Vacantes_Id = H003A3_A263Vacantes_Id[0];
               A11UsuariosId = H003A3_A11UsuariosId[0];
               /* Execute user event: Load */
               E143A2 ();
               pr_default.readNext(1);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 93;
            WB3A0( ) ;
         }
         bGXsfl_93_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3A2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_VACANTES_ID"+"_"+sGXsfl_93_idx, GetSecureSignedToken( sGXsfl_93_idx, context.localUtil.Format( (decimal)(A263Vacantes_Id), "ZZZZZZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         /* Using cursor H003A4 */
         pr_default.execute(2, new Object[] {AV10UsuarioId});
         GRID1_nRecordCount = H003A4_AGRID1_nRecordCount[0];
         pr_default.close(2);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV10UsuarioId, AV17informacion, AV14SelecPerfil) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV10UsuarioId, AV17informacion, AV14SelecPerfil) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV10UsuarioId, AV17informacion, AV14SelecPerfil) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV10UsuarioId, AV17informacion, AV14SelecPerfil) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV10UsuarioId, AV17informacion, AV14SelecPerfil) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
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
         GXVvSELECPERFIL_html3A2( ) ;
      }

      protected void STRUP3A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E123A2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Usuarioalta"), AV9UsuarioAlta);
            ajax_req_read_hidden_sdt(cgiGet( "vUPLOADEDFILES"), AV8UploadedFiles);
            ajax_req_read_hidden_sdt(cgiGet( "vALERTPROPERTIES"), AV15AlertProperties);
            /* Read saved values. */
            nRC_GXsfl_93 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_93"), ",", "."));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ",", "."));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ",", "."));
            Fileupload1_Maxnumberoffiles = (int)(context.localUtil.CToN( cgiGet( "FILEUPLOAD1_Maxnumberoffiles"), ",", "."));
            Fileupload1_Acceptedfiletypes = cgiGet( "FILEUPLOAD1_Acceptedfiletypes");
            /* Read variables values. */
            AV12VarImagen = cgiGet( imgavVarimagen_Internalname);
            AV9UsuarioAlta.gxTpr_Usuariosnombre = StringUtil.Upper( cgiGet( edtavCtlusuariosnombre_Internalname));
            AV9UsuarioAlta.gxTpr_Usuariosappat = StringUtil.Upper( cgiGet( edtavCtlusuariosappat_Internalname));
            AV9UsuarioAlta.gxTpr_Usuariosapmat = StringUtil.Upper( cgiGet( edtavCtlusuariosapmat_Internalname));
            if ( context.localUtil.VCDate( cgiGet( edtavCtlusuariosfecnacimiento_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Nacimiento"}), 1, "CTLUSUARIOSFECNACIMIENTO");
               GX_FocusControl = edtavCtlusuariosfecnacimiento_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9UsuarioAlta.gxTpr_Usuariosfecnacimiento = DateTime.MinValue;
            }
            else
            {
               AV9UsuarioAlta.gxTpr_Usuariosfecnacimiento = context.localUtil.CToD( cgiGet( edtavCtlusuariosfecnacimiento_Internalname), 2);
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCtlusuariosedad_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCtlusuariosedad_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CTLUSUARIOSEDAD");
               GX_FocusControl = edtavCtlusuariosedad_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9UsuarioAlta.gxTpr_Usuariosedad = 0;
            }
            else
            {
               AV9UsuarioAlta.gxTpr_Usuariosedad = (short)(context.localUtil.CToN( cgiGet( edtavCtlusuariosedad_Internalname), ",", "."));
            }
            AV9UsuarioAlta.gxTpr_Usuariossexofor = cgiGet( edtavCtlusuariossexofor_Internalname);
            AV9UsuarioAlta.gxTpr_Usuariostelef = cgiGet( edtavCtlusuariostelef_Internalname);
            AV9UsuarioAlta.gxTpr_Usuarioscorreo = cgiGet( edtavCtlusuarioscorreo_Internalname);
            AV9UsuarioAlta.gxTpr_Usuarioscurp = StringUtil.Upper( cgiGet( edtavCtlusuarioscurp_Internalname));
            dynavSelecperfil.Name = dynavSelecperfil_Internalname;
            dynavSelecperfil.CurrentValue = cgiGet( dynavSelecperfil_Internalname);
            AV14SelecPerfil = (int)(NumberUtil.Val( cgiGet( dynavSelecperfil_Internalname), "."));
            AssignAttri("", false, "AV14SelecPerfil", StringUtil.LTrimStr( (decimal)(AV14SelecPerfil), 9, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E123A2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E123A2( )
      {
         /* Start Routine */
         AV9UsuarioAlta.Load(AV10UsuarioId);
         AV17informacion = context.GetImagePath( "3c16001b-f401-4d29-bfd2-36827836eab2", "", context.GetTheme( ));
         AssignProp("", false, edtavInformacion_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV17informacion)) ? AV29Informacion_GXI : context.convertURL( context.PathToRelativeUrl( AV17informacion))), !bGXsfl_93_Refreshing);
         AssignProp("", false, edtavInformacion_Internalname, "SrcSet", context.GetImageSrcSet( AV17informacion), true);
         AV29Informacion_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3c16001b-f401-4d29-bfd2-36827836eab2", "", context.GetTheme( )));
         AssignProp("", false, edtavInformacion_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV17informacion)) ? AV29Informacion_GXI : context.convertURL( context.PathToRelativeUrl( AV17informacion))), !bGXsfl_93_Refreshing);
         AssignProp("", false, edtavInformacion_Internalname, "SrcSet", context.GetImageSrcSet( AV17informacion), true);
         cmbVacantesUsuariosEstatus.FontBold = 1;
         AssignProp("", false, cmbVacantesUsuariosEstatus_Internalname, "Fontbold", StringUtil.Str( (decimal)(cmbVacantesUsuariosEstatus.FontBold), 1, 0), !bGXsfl_93_Refreshing);
         AV12VarImagen = AV9UsuarioAlta.gxTpr_Usuariosicono;
         AssignProp("", false, imgavVarimagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV12VarImagen)) ? AV30Varimagen_GXI : context.convertURL( context.PathToRelativeUrl( AV12VarImagen))), true);
         AssignProp("", false, imgavVarimagen_Internalname, "SrcSet", context.GetImageSrcSet( AV12VarImagen), true);
         AV30Varimagen_GXI = AV9UsuarioAlta.gxTpr_Usuariosicono_gxi;
         AssignProp("", false, imgavVarimagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV12VarImagen)) ? AV30Varimagen_GXI : context.convertURL( context.PathToRelativeUrl( AV12VarImagen))), true);
         AssignProp("", false, imgavVarimagen_Internalname, "SrcSet", context.GetImageSrcSet( AV12VarImagen), true);
         AV31GXLvl12 = 0;
         /* Using cursor H003A5 */
         pr_default.execute(3, new Object[] {AV10UsuarioId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A283PerfilesUsuariosEstatus = H003A5_A283PerfilesUsuariosEstatus[0];
            A11UsuariosId = H003A5_A11UsuariosId[0];
            A278Perfiles_Id = H003A5_A278Perfiles_Id[0];
            AV31GXLvl12 = 1;
            AV14SelecPerfil = A278Perfiles_Id;
            AssignAttri("", false, "AV14SelecPerfil", StringUtil.LTrimStr( (decimal)(AV14SelecPerfil), 9, 0));
            dynavSelecperfil.BackColor = GXUtil.RGB( 217, 231, 252);
            AssignProp("", false, dynavSelecperfil_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(dynavSelecperfil.BackColor), 9, 0), true);
            dynavSelecperfil.FontBold = 1;
            AssignProp("", false, dynavSelecperfil_Internalname, "Fontbold", StringUtil.Str( (decimal)(dynavSelecperfil.FontBold), 1, 0), true);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         if ( AV31GXLvl12 == 0 )
         {
            dynavSelecperfil.BackColor = GXUtil.RGB( 255, 142, 127);
            AssignProp("", false, dynavSelecperfil_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(dynavSelecperfil.BackColor), 9, 0), true);
            dynavSelecperfil.FontBold = 1;
            AssignProp("", false, dynavSelecperfil_Internalname, "Fontbold", StringUtil.Str( (decimal)(dynavSelecperfil.FontBold), 1, 0), true);
         }
      }

      protected void E113A2( )
      {
         /* 'Actualizar' Routine */
         AV32GXV10 = 1;
         while ( AV32GXV10 <= AV8UploadedFiles.Count )
         {
            AV6FileUploadData = ((SdtFileUploadData)AV8UploadedFiles.Item(AV32GXV10));
            AV7Image = AV6FileUploadData.gxTpr_File;
            AV33Image_GXI = GXDbFile.GetUriFromFile( "", "", AV6FileUploadData.gxTpr_File);
            AV9UsuarioAlta.gxTpr_Usuariosicono = AV7Image;
            AV9UsuarioAlta.gxTpr_Usuariosicono_gxi = AV33Image_GXI;
            AV32GXV10 = (int)(AV32GXV10+1);
         }
         AV9UsuarioAlta.Save();
         if ( (0==AV14SelecPerfil) )
         {
            GXt_SdtPropiedades1 = AV15AlertProperties;
            new getsweetmessage(context ).execute(  "warning",  "Favor de seleccionar un perfil",  "",  true,  false, out  GXt_SdtPropiedades1) ;
            AV15AlertProperties = GXt_SdtPropiedades1;
            this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
         }
         else
         {
            if ( AV9UsuarioAlta.Success() )
            {
               context.CommitDataStores("wpinfgetodlados",pr_default);
               new pr_guardaperfilusuario(context ).execute(  AV10UsuarioId,  AV14SelecPerfil,  "Personal") ;
               new pr_cambtipo(context ).execute(  AV10UsuarioId,  0,  "Prospecto") ;
               GXt_SdtPropiedades1 = AV15AlertProperties;
               new getsweetmessage(context ).execute(  "success",  "Información modificada, Exitosamente",  "",  true,  false, out  GXt_SdtPropiedades1) ;
               AV15AlertProperties = GXt_SdtPropiedades1;
               this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
            }
            else
            {
               context.RollbackDataStores("wpinfgetodlados",pr_default);
               GXt_SdtPropiedades1 = AV15AlertProperties;
               new getsweetmessage(context ).execute(  "warning",  AV9UsuarioAlta.GetMessages().ToJSonString(false),  "",  true,  false, out  GXt_SdtPropiedades1) ;
               AV15AlertProperties = GXt_SdtPropiedades1;
               this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9UsuarioAlta", AV9UsuarioAlta);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15AlertProperties", AV15AlertProperties);
      }

      protected void E133A2( )
      {
         /* 'InfVacante' Routine */
         /* Object Property */
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Component1_Component), StringUtil.Lower( "wcInfoVacante")) != 0 )
         {
            WebComp_Component1 = getWebComponent(GetType(), "GeneXus.Programs", "wcinfovacante", new Object[] {context} );
            WebComp_Component1.ComponentInit();
            WebComp_Component1.Name = "wcInfoVacante";
            WebComp_Component1_Component = "wcInfoVacante";
         }
         if ( StringUtil.Len( WebComp_Component1_Component) != 0 )
         {
            WebComp_Component1.setjustcreated();
            WebComp_Component1.componentprepare(new Object[] {(String)"W0100",(String)"",(int)A11UsuariosId,(int)A263Vacantes_Id});
            WebComp_Component1.componentbind(new Object[] {(String)"",(String)""});
         }
         if ( isFullAjaxMode( ) )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0100"+"");
            WebComp_Component1.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      private void E143A2( )
      {
         /* Load Routine */
         sendrow_932( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_93_Refreshing )
         {
            context.DoAjaxLoad(93, Grid1Row);
         }
      }

      protected void wb_table3_90_3A2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable4_Internalname, tblTable4_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"93\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid1_Backcolorstyle == 0 )
               {
                  subGrid1_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
               else
               {
                  subGrid1_Titlebackstyle = 1;
                  if ( subGrid1_Backcolorstyle == 1 )
                  {
                     subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "ID") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Vacante") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Estatús ") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Image"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Información") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha Postulación") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Grid1Container.AddObjectProperty("GridName", "Grid1");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Grid1Container = new GXWebGrid( context);
               }
               else
               {
                  Grid1Container.Clear();
               }
               Grid1Container.SetWrapped(nGXWrapped);
               Grid1Container.AddObjectProperty("GridName", "Grid1");
               Grid1Container.AddObjectProperty("Header", subGrid1_Header);
               Grid1Container.AddObjectProperty("Class", "WorkWith");
               Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("CmpContext", "");
               Grid1Container.AddObjectProperty("InMasterPage", "false");
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A263Vacantes_Id), 9, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A290VacantesUsuariosEstatus), 4, 0, ".", "")));
               Grid1Column.AddObjectProperty("Fontbold", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbVacantesUsuariosEstatus.FontBold), 1, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( AV17informacion));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.TToC( A288VacantesUsuariosFechaP, 10, 8, 0, 3, "/", ":", " "));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 93 )
         {
            wbEnd = 0;
            nRC_GXsfl_93 = (int)(nGXsfl_93_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_90_3A2e( true) ;
         }
         else
         {
            wb_table3_90_3A2e( false) ;
         }
      }

      protected void wb_table2_75_3A2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable5_Internalname, tblTable5_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"Right\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Right;text-align:-moz-Right;text-align:-webkit-Right")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "c437546b-f1bf-4dfc-bbef-ae4524ef2773", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Modificar la información", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ACTUALIZAR\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_wpInfGeTodLados.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Right\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Right;text-align:-moz-Right;text-align:-webkit-Right")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "93b2d7e5-9a13-41d9-baee-ede2124078b4", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"e153a1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_wpInfGeTodLados.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_75_3A2e( true) ;
         }
         else
         {
            wb_table2_75_3A2e( false) ;
         }
      }

      protected void wb_table1_15_3A2( bool wbgen )
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
            AV12VarImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV12VarImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( AV30Varimagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV12VarImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV12VarImagen)) ? AV30Varimagen_GXI : context.PathToRelativeUrl( AV12VarImagen));
            GxWebStd.gx_bitmap( context, imgavVarimagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"maximumuploadsize=\"actual\""+" ", "", "", 1, AV12VarImagen_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_wpInfGeTodLados.htm");
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
            ucFileupload1.SetProperty("UploadedFiles", AV8UploadedFiles);
            ucFileupload1.Render(context, "fileupload", Fileupload1_Internalname, "FILEUPLOAD1Container");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_15_3A2e( true) ;
         }
         else
         {
            wb_table1_15_3A2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV10UsuarioId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV10UsuarioId", StringUtil.LTrimStr( (decimal)(AV10UsuarioId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10UsuarioId), "ZZZZZZZZ9"), context));
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
         PA3A2( ) ;
         WS3A2( ) ;
         WE3A2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?20226271435166", true, true);
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
         context.AddJavascriptSource("wpinfgetodlados.js", "?20226271435167", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         context.AddJavascriptSource("SweetAlert2/sweetalert2.all.min.js", "", false, true);
         context.AddJavascriptSource("SweetAlert2/SweetAlert2Render.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_932( )
      {
         edtUsuariosId_Internalname = "USUARIOSID_"+sGXsfl_93_idx;
         dynVacantes_Id_Internalname = "VACANTES_ID_"+sGXsfl_93_idx;
         cmbVacantesUsuariosEstatus_Internalname = "VACANTESUSUARIOSESTATUS_"+sGXsfl_93_idx;
         edtavInformacion_Internalname = "vINFORMACION_"+sGXsfl_93_idx;
         edtVacantesUsuariosFechaP_Internalname = "VACANTESUSUARIOSFECHAP_"+sGXsfl_93_idx;
      }

      protected void SubsflControlProps_fel_932( )
      {
         edtUsuariosId_Internalname = "USUARIOSID_"+sGXsfl_93_fel_idx;
         dynVacantes_Id_Internalname = "VACANTES_ID_"+sGXsfl_93_fel_idx;
         cmbVacantesUsuariosEstatus_Internalname = "VACANTESUSUARIOSESTATUS_"+sGXsfl_93_fel_idx;
         edtavInformacion_Internalname = "vINFORMACION_"+sGXsfl_93_fel_idx;
         edtVacantesUsuariosFechaP_Internalname = "VACANTESUSUARIOSFECHAP_"+sGXsfl_93_fel_idx;
      }

      protected void sendrow_932( )
      {
         SubsflControlProps_932( ) ;
         WB3A0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_93_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_93_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_93_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")),context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosId_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)0,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)6,(short)0,(short)0,(short)93,(short)1,(short)-1,(short)0,(bool)true,(String)"NumId",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( dynVacantes_Id.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "VACANTES_ID_" + sGXsfl_93_idx;
               dynVacantes_Id.Name = GXCCtl;
               dynVacantes_Id.WebTags = "";
               dynVacantes_Id.removeAllItems();
               /* Using cursor H003A6 */
               pr_default.execute(4);
               while ( (pr_default.getStatus(4) != 101) )
               {
                  dynVacantes_Id.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H003A6_A263Vacantes_Id[0]), 9, 0)), H003A6_A264Vacantes_Nombre[0], 0);
                  pr_default.readNext(4);
               }
               pr_default.close(4);
               if ( dynVacantes_Id.ItemCount > 0 )
               {
                  A263Vacantes_Id = (int)(NumberUtil.Val( dynVacantes_Id.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A263Vacantes_Id), 9, 0))), "."));
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynVacantes_Id,(String)dynVacantes_Id_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A263Vacantes_Id), 9, 0)),(short)1,(String)dynVacantes_Id_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute",(String)"",(String)"",(String)"",(String)"",(bool)true});
            dynVacantes_Id.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A263Vacantes_Id), 9, 0));
            AssignProp("", false, dynVacantes_Id_Internalname, "Values", (String)(dynVacantes_Id.ToJavascriptSource()), !bGXsfl_93_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbVacantesUsuariosEstatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "VACANTESUSUARIOSESTATUS_" + sGXsfl_93_idx;
               cmbVacantesUsuariosEstatus.Name = GXCCtl;
               cmbVacantesUsuariosEstatus.WebTags = "";
               cmbVacantesUsuariosEstatus.addItem("0", "Filtro 1", 0);
               cmbVacantesUsuariosEstatus.addItem("1", "Filtro 2", 0);
               cmbVacantesUsuariosEstatus.addItem("2", "Filtro 3", 0);
               cmbVacantesUsuariosEstatus.addItem("3", "Candidato Todo Proceso", 0);
               cmbVacantesUsuariosEstatus.addItem("4", "Enviado a Cliente", 0);
               cmbVacantesUsuariosEstatus.addItem("5", "Descartado", 0);
               if ( cmbVacantesUsuariosEstatus.ItemCount > 0 )
               {
                  A290VacantesUsuariosEstatus = (short)(NumberUtil.Val( cmbVacantesUsuariosEstatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A290VacantesUsuariosEstatus), 4, 0))), "."));
                  n290VacantesUsuariosEstatus = false;
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbVacantesUsuariosEstatus,(String)cmbVacantesUsuariosEstatus_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A290VacantesUsuariosEstatus), 4, 0)),(short)1,(String)cmbVacantesUsuariosEstatus_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",((cmbVacantesUsuariosEstatus.FontBold==1) ? "font-weight:bold;" : "font-weight:normal;"),(String)"Attribute",(String)"",(String)"",(String)"",(String)"",(bool)true});
            cmbVacantesUsuariosEstatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A290VacantesUsuariosEstatus), 4, 0));
            AssignProp("", false, cmbVacantesUsuariosEstatus_Internalname, "Values", (String)(cmbVacantesUsuariosEstatus.ToJavascriptSource()), !bGXsfl_93_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavInformacion_Enabled!=0)&&(edtavInformacion_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 97,'',false,'',93)\"" : " ");
            ClassString = "Image";
            StyleString = "";
            AV17informacion_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV17informacion))&&String.IsNullOrEmpty(StringUtil.RTrim( AV29Informacion_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV17informacion)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV17informacion)) ? AV29Informacion_GXI : context.PathToRelativeUrl( AV17informacion));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavInformacion_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"",(String)"Información de la Vacante",(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)5,(String)edtavInformacion_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'INFVACANTE\\'."+sGXsfl_93_idx+"'",(String)StyleString,(String)ClassString,(String)"",(String)"",(String)"",(String)"",(String)""+TempTags,(String)"",(String)"",(short)1,(bool)AV17informacion_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtVacantesUsuariosFechaP_Internalname,context.localUtil.TToC( A288VacantesUsuariosFechaP, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A288VacantesUsuariosFechaP, "99/99/9999 99:99"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtVacantesUsuariosFechaP_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)16,(short)0,(short)0,(short)93,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            send_integrity_lvl_hashes3A2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_93_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_93_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_93_idx+1);
            sGXsfl_93_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_93_idx), 4, 0), 4, "0");
            SubsflControlProps_932( ) ;
         }
         /* End function sendrow_932 */
      }

      protected void init_web_controls( )
      {
         dynavSelecperfil.Name = "vSELECPERFIL";
         dynavSelecperfil.WebTags = "";
         GXCCtl = "VACANTES_ID_" + sGXsfl_93_idx;
         dynVacantes_Id.Name = GXCCtl;
         dynVacantes_Id.WebTags = "";
         dynVacantes_Id.removeAllItems();
         /* Using cursor H003A7 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            dynVacantes_Id.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H003A7_A263Vacantes_Id[0]), 9, 0)), H003A7_A264Vacantes_Nombre[0], 0);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         if ( dynVacantes_Id.ItemCount > 0 )
         {
            A263Vacantes_Id = (int)(NumberUtil.Val( dynVacantes_Id.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A263Vacantes_Id), 9, 0))), "."));
         }
         GXCCtl = "VACANTESUSUARIOSESTATUS_" + sGXsfl_93_idx;
         cmbVacantesUsuariosEstatus.Name = GXCCtl;
         cmbVacantesUsuariosEstatus.WebTags = "";
         cmbVacantesUsuariosEstatus.addItem("0", "Filtro 1", 0);
         cmbVacantesUsuariosEstatus.addItem("1", "Filtro 2", 0);
         cmbVacantesUsuariosEstatus.addItem("2", "Filtro 3", 0);
         cmbVacantesUsuariosEstatus.addItem("3", "Candidato Todo Proceso", 0);
         cmbVacantesUsuariosEstatus.addItem("4", "Enviado a Cliente", 0);
         cmbVacantesUsuariosEstatus.addItem("5", "Descartado", 0);
         if ( cmbVacantesUsuariosEstatus.ItemCount > 0 )
         {
            A290VacantesUsuariosEstatus = (short)(NumberUtil.Val( cmbVacantesUsuariosEstatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A290VacantesUsuariosEstatus), 4, 0))), "."));
            n290VacantesUsuariosEstatus = false;
         }
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
         imgImage3_Internalname = "IMAGE3";
         imgImage1_Internalname = "IMAGE1";
         tblTable5_Internalname = "TABLE5";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtUsuariosId_Internalname = "USUARIOSID";
         dynVacantes_Id_Internalname = "VACANTES_ID";
         cmbVacantesUsuariosEstatus_Internalname = "VACANTESUSUARIOSESTATUS";
         edtavInformacion_Internalname = "vINFORMACION";
         edtVacantesUsuariosFechaP_Internalname = "VACANTESUSUARIOSFECHAP";
         tblTable4_Internalname = "TABLE4";
         divTable1_Internalname = "TABLE1";
         Ucalertas_Internalname = "UCALERTAS";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtVacantesUsuariosFechaP_Jsonclick = "";
         edtavInformacion_Jsonclick = "";
         edtavInformacion_Visible = -1;
         edtavInformacion_Enabled = 1;
         cmbVacantesUsuariosEstatus_Jsonclick = "";
         dynVacantes_Id_Jsonclick = "";
         edtUsuariosId_Jsonclick = "";
         Fileupload1_Tooltiptext = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         subGrid1_Class = "WorkWith";
         subGrid1_Backcolorstyle = 0;
         edtavCtlusuariossexofor_Enabled = -1;
         edtavCtlusuariosedad_Enabled = -1;
         edtavCtlusuariosfecnacimiento_Enabled = -1;
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
         Form.Caption = "wp Candidatos";
         subGrid1_Rows = 10;
         cmbVacantesUsuariosEstatus.FontBold = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV17informacion',fld:'vINFORMACION',pic:''},{av:'cmbVacantesUsuariosEstatus'},{av:'AV10UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZ9',hsh:true},{av:'dynavSelecperfil'},{av:'AV14SelecPerfil',fld:'vSELECPERFIL',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynavSelecperfil'},{av:'AV14SelecPerfil',fld:'vSELECPERFIL',pic:'ZZZZZZZZ9'}]}");
         setEventMetadata("'ACTUALIZAR'","{handler:'E113A2',iparms:[{av:'AV8UploadedFiles',fld:'vUPLOADEDFILES',pic:''},{av:'AV9UsuarioAlta',fld:'vUSUARIOALTA',pic:''},{av:'AV33Image_GXI',fld:'vIMAGE_GXI',pic:''},{av:'AV10UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZ9',hsh:true},{av:'dynavSelecperfil'},{av:'AV14SelecPerfil',fld:'vSELECPERFIL',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("'ACTUALIZAR'",",oparms:[{av:'AV9UsuarioAlta',fld:'vUSUARIOALTA',pic:''},{av:'AV15AlertProperties',fld:'vALERTPROPERTIES',pic:''},{av:'dynavSelecperfil'},{av:'AV14SelecPerfil',fld:'vSELECPERFIL',pic:'ZZZZZZZZ9'}]}");
         setEventMetadata("'INFVACANTE'","{handler:'E133A2',iparms:[{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'dynVacantes_Id'},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9',hsh:true},{av:'dynavSelecperfil'},{av:'AV14SelecPerfil',fld:'vSELECPERFIL',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("'INFVACANTE'",",oparms:[{ctrl:'COMPONENT1'},{av:'dynavSelecperfil'},{av:'AV14SelecPerfil',fld:'vSELECPERFIL',pic:'ZZZZZZZZ9'}]}");
         setEventMetadata("'REGRESAR'","{handler:'E153A1',iparms:[{av:'dynavSelecperfil'},{av:'AV14SelecPerfil',fld:'vSELECPERFIL',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("'REGRESAR'",",oparms:[{av:'dynavSelecperfil'},{av:'AV14SelecPerfil',fld:'vSELECPERFIL',pic:'ZZZZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV10UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZ9',hsh:true},{av:'AV17informacion',fld:'vINFORMACION',pic:''},{av:'cmbVacantesUsuariosEstatus'},{av:'dynavSelecperfil'},{av:'AV14SelecPerfil',fld:'vSELECPERFIL',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[{av:'dynavSelecperfil'},{av:'AV14SelecPerfil',fld:'vSELECPERFIL',pic:'ZZZZZZZZ9'}]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV10UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZ9',hsh:true},{av:'AV17informacion',fld:'vINFORMACION',pic:''},{av:'cmbVacantesUsuariosEstatus'},{av:'dynavSelecperfil'},{av:'AV14SelecPerfil',fld:'vSELECPERFIL',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[{av:'dynavSelecperfil'},{av:'AV14SelecPerfil',fld:'vSELECPERFIL',pic:'ZZZZZZZZ9'}]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV10UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZ9',hsh:true},{av:'AV17informacion',fld:'vINFORMACION',pic:''},{av:'cmbVacantesUsuariosEstatus'},{av:'dynavSelecperfil'},{av:'AV14SelecPerfil',fld:'vSELECPERFIL',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[{av:'dynavSelecperfil'},{av:'AV14SelecPerfil',fld:'vSELECPERFIL',pic:'ZZZZZZZZ9'}]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV10UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZ9',hsh:true},{av:'AV17informacion',fld:'vINFORMACION',pic:''},{av:'cmbVacantesUsuariosEstatus'},{av:'dynavSelecperfil'},{av:'AV14SelecPerfil',fld:'vSELECPERFIL',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[{av:'dynavSelecperfil'},{av:'AV14SelecPerfil',fld:'vSELECPERFIL',pic:'ZZZZZZZZ9'}]}");
         setEventMetadata("NULL","{handler:'Valid_Vacantesusuariosfechap',iparms:[{av:'dynavSelecperfil'},{av:'AV14SelecPerfil',fld:'vSELECPERFIL',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("NULL",",oparms:[{av:'dynavSelecperfil'},{av:'AV14SelecPerfil',fld:'vSELECPERFIL',pic:'ZZZZZZZZ9'}]}");
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
         AV17informacion = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9UsuarioAlta = new SdtUsuarios(context);
         AV8UploadedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "ADMINDATA1");
         AV15AlertProperties = new SdtPropiedades(context);
         AV33Image_GXI = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock1_Jsonclick = "";
         TempTags = "";
         lblTextblock2_Jsonclick = "";
         WebComp_Component1_Component = "";
         OldComponent1 = "";
         ucUcalertas = new GXUserControl();
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV29Informacion_GXI = "";
         A288VacantesUsuariosFechaP = (DateTime)(DateTime.MinValue);
         GXDecQS = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H003A2_A278Perfiles_Id = new int[1] ;
         H003A2_A279Perfiles_Nombre = new String[] {""} ;
         H003A2_A280Perfiles_Estatus = new short[1] ;
         H003A3_A288VacantesUsuariosFechaP = new DateTime[] {DateTime.MinValue} ;
         H003A3_A290VacantesUsuariosEstatus = new short[1] ;
         H003A3_n290VacantesUsuariosEstatus = new bool[] {false} ;
         H003A3_A263Vacantes_Id = new int[1] ;
         H003A3_A11UsuariosId = new int[1] ;
         H003A4_AGRID1_nRecordCount = new long[1] ;
         AV12VarImagen = "";
         AV30Varimagen_GXI = "";
         H003A5_A283PerfilesUsuariosEstatus = new short[1] ;
         H003A5_A11UsuariosId = new int[1] ;
         H003A5_A278Perfiles_Id = new int[1] ;
         AV6FileUploadData = new SdtFileUploadData(context);
         AV7Image = "";
         GXt_SdtPropiedades1 = new SdtPropiedades(context);
         Grid1Row = new GXWebRow();
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         imgImage3_Jsonclick = "";
         imgImage1_Jsonclick = "";
         ucFileupload1 = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         GXCCtl = "";
         H003A6_A263Vacantes_Id = new int[1] ;
         H003A6_A264Vacantes_Nombre = new String[] {""} ;
         H003A7_A263Vacantes_Id = new int[1] ;
         H003A7_A264Vacantes_Nombre = new String[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpinfgetodlados__default(),
            new Object[][] {
                new Object[] {
               H003A2_A278Perfiles_Id, H003A2_A279Perfiles_Nombre, H003A2_A280Perfiles_Estatus
               }
               , new Object[] {
               H003A3_A288VacantesUsuariosFechaP, H003A3_A290VacantesUsuariosEstatus, H003A3_n290VacantesUsuariosEstatus, H003A3_A263Vacantes_Id, H003A3_A11UsuariosId
               }
               , new Object[] {
               H003A4_AGRID1_nRecordCount
               }
               , new Object[] {
               H003A5_A283PerfilesUsuariosEstatus, H003A5_A11UsuariosId, H003A5_A278Perfiles_Id
               }
               , new Object[] {
               H003A6_A263Vacantes_Id, H003A6_A264Vacantes_Nombre
               }
               , new Object[] {
               H003A7_A263Vacantes_Id, H003A7_A264Vacantes_Nombre
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

      private short GRID1_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A290VacantesUsuariosEstatus ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid1_Backcolorstyle ;
      private short AV31GXLvl12 ;
      private short A283PerfilesUsuariosEstatus ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int AV10UsuarioId ;
      private int wcpOAV10UsuarioId ;
      private int nRC_GXsfl_93 ;
      private int nGXsfl_93_idx=1 ;
      private int subGrid1_Rows ;
      private int AV14SelecPerfil ;
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
      private int A11UsuariosId ;
      private int A263Vacantes_Id ;
      private int gxdynajaxindex ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A278Perfiles_Id ;
      private int AV32GXV10 ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int edtavInformacion_Enabled ;
      private int edtavInformacion_Visible ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_93_idx="0001" ;
      private String cmbVacantesUsuariosEstatus_Internalname ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GXEncryptionTmp ;
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
      private String lblTextblock2_Internalname ;
      private String lblTextblock2_Jsonclick ;
      private String WebComp_Component1_Component ;
      private String OldComponent1 ;
      private String Ucalertas_Internalname ;
      private String sStyleString ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtUsuariosId_Internalname ;
      private String dynVacantes_Id_Internalname ;
      private String edtavInformacion_Internalname ;
      private String edtVacantesUsuariosFechaP_Internalname ;
      private String GXDecQS ;
      private String gxwrpcisep ;
      private String scmdbuf ;
      private String imgavVarimagen_Internalname ;
      private String tblTable4_Internalname ;
      private String subGrid1_Internalname ;
      private String subGrid1_Class ;
      private String subGrid1_Linesclass ;
      private String subGrid1_Header ;
      private String tblTable5_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String sImgUrl ;
      private String imgImage3_Internalname ;
      private String imgImage3_Jsonclick ;
      private String imgImage1_Internalname ;
      private String imgImage1_Jsonclick ;
      private String tblTable3_Internalname ;
      private String Fileupload1_Tooltiptext ;
      private String Fileupload1_Internalname ;
      private String sGXsfl_93_fel_idx="0001" ;
      private String ROClassString ;
      private String edtUsuariosId_Jsonclick ;
      private String GXCCtl ;
      private String dynVacantes_Id_Jsonclick ;
      private String cmbVacantesUsuariosEstatus_Jsonclick ;
      private String edtavInformacion_Jsonclick ;
      private String edtVacantesUsuariosFechaP_Jsonclick ;
      private DateTime A288VacantesUsuariosFechaP ;
      private bool entryPointCalled ;
      private bool bGXsfl_93_Refreshing=false ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n290VacantesUsuariosEstatus ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV12VarImagen_IsBlob ;
      private bool AV17informacion_IsBlob ;
      private String AV33Image_GXI ;
      private String AV29Informacion_GXI ;
      private String AV30Varimagen_GXI ;
      private String AV17informacion ;
      private String AV12VarImagen ;
      private String AV7Image ;
      private GXWebComponent WebComp_Component1 ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXUserControl ucUcalertas ;
      private GXUserControl ucFileupload1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavSelecperfil ;
      private GXCombobox dynVacantes_Id ;
      private GXCombobox cmbVacantesUsuariosEstatus ;
      private IDataStoreProvider pr_default ;
      private int[] H003A2_A278Perfiles_Id ;
      private String[] H003A2_A279Perfiles_Nombre ;
      private short[] H003A2_A280Perfiles_Estatus ;
      private DateTime[] H003A3_A288VacantesUsuariosFechaP ;
      private short[] H003A3_A290VacantesUsuariosEstatus ;
      private bool[] H003A3_n290VacantesUsuariosEstatus ;
      private int[] H003A3_A263Vacantes_Id ;
      private int[] H003A3_A11UsuariosId ;
      private long[] H003A4_AGRID1_nRecordCount ;
      private short[] H003A5_A283PerfilesUsuariosEstatus ;
      private int[] H003A5_A11UsuariosId ;
      private int[] H003A5_A278Perfiles_Id ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int[] H003A6_A263Vacantes_Id ;
      private String[] H003A6_A264Vacantes_Nombre ;
      private int[] H003A7_A263Vacantes_Id ;
      private String[] H003A7_A264Vacantes_Nombre ;
      private GXBaseCollection<SdtFileUploadData> AV8UploadedFiles ;
      private GXWebForm Form ;
      private SdtFileUploadData AV6FileUploadData ;
      private SdtUsuarios AV9UsuarioAlta ;
      private SdtPropiedades AV15AlertProperties ;
      private SdtPropiedades GXt_SdtPropiedades1 ;
   }

   public class wpinfgetodlados__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH003A2 ;
          prmH003A2 = new Object[] {
          } ;
          Object[] prmH003A3 ;
          prmH003A3 = new Object[] {
          new Object[] {"AV10UsuarioId",System.Data.DbType.Int32,9,0} ,
          new Object[] {"GXPagingFrom2",System.Data.DbType.Int32,9,0} ,
          new Object[] {"GXPagingTo2",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmH003A4 ;
          prmH003A4 = new Object[] {
          new Object[] {"AV10UsuarioId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmH003A5 ;
          prmH003A5 = new Object[] {
          new Object[] {"AV10UsuarioId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmH003A6 ;
          prmH003A6 = new Object[] {
          } ;
          Object[] prmH003A7 ;
          prmH003A7 = new Object[] {
          } ;
          def= new CursorDef[] {
              new CursorDef("H003A2", "SELECT `Perfiles_Id`, `Perfiles_Nombre`, `Perfiles_Estatus` FROM `Perfiles` WHERE `Perfiles_Estatus` = 1 ORDER BY `Perfiles_Nombre` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003A2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003A3", "SELECT `VacantesUsuariosFechaP`, `VacantesUsuariosEstatus`, `Vacantes_Id`, `UsuariosId` FROM `VacantesUsuariosVacante` WHERE (`Vacantes_Id` <> 17) AND (`UsuariosId` = ?) ORDER BY `VacantesUsuariosEstatus` DESC  LIMIT ?, ?",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003A3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003A4", "SELECT COUNT(*) FROM `VacantesUsuariosVacante` WHERE (`Vacantes_Id` <> 17) AND (`UsuariosId` = ?) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003A4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003A5", "SELECT `PerfilesUsuariosEstatus`, `UsuariosId`, `Perfiles_Id` FROM `PerfilesUsuariosPerfil` WHERE (`UsuariosId` = ?) AND (`PerfilesUsuariosEstatus` = 1) ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003A5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003A6", "SELECT `Vacantes_Id`, `Vacantes_Nombre` FROM `Vacantes` ORDER BY `Vacantes_Nombre` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003A6,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003A7", "SELECT `Vacantes_Id`, `Vacantes_Nombre` FROM `Vacantes` ORDER BY `Vacantes_Nombre` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003A7,0, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3) ;
                ((int[]) buf[4])[0] = rslt.getInt(4) ;
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                return;
             case 5 :
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
             case 1 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                return;
             case 2 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 3 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

}
