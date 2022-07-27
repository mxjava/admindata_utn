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
   public class wpselvacanteregistro : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public wpselvacanteregistro( )
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

      public wpselvacanteregistro( IGxContext context )
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
         this.AV12UsuariosId = aP0_UsuariosId;
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
                  AV12UsuariosId = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri(sPrefix, false, "AV12UsuariosId", StringUtil.LTrimStr( (decimal)(AV12UsuariosId), 6, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(String)sCompPrefix,(String)sSFPrefix,(int)AV12UsuariosId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxSuggest"+"_"+"vVACANTES_NOMBRE") == 0 )
               {
                  A264Vacantes_Nombre = GetNextPar( );
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXSGVvVACANTES_NOMBRE2Y0( A264Vacantes_Nombre) ;
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Stselecvacante_grid2") == 0 )
               {
                  nRC_GXsfl_25 = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  nGXsfl_25_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  sGXsfl_25_idx = GetNextPar( );
                  sPrefix = GetNextPar( );
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxnrStselecvacante_grid2_newrow( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Stselecvacante_grid2") == 0 )
               {
                  subStselecvacante_grid2_Rows = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AV15Vacantes_Nombre = GetNextPar( );
                  A11UsuariosId = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AV12UsuariosId = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  A273UsuariosVacanteEstatus = (short)(NumberUtil.Val( GetNextPar( ), "."));
                  sPrefix = GetNextPar( );
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrStselecvacante_grid2_refresh( subStselecvacante_grid2_Rows, AV15Vacantes_Nombre, A11UsuariosId, AV12UsuariosId, A273UsuariosVacanteEstatus, sPrefix) ;
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
            PA2Y2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS2Y2( ) ;
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
            context.SendWebValue( "wp Sel Vacante Registro") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714341435", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("SweetAlert2/sweetalert2.all.min.js", "", false, true);
         context.AddJavascriptSource("SweetAlert2/SweetAlert2Render.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            if ( nGXWrapped != 1 )
            {
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "wpselvacanteregistro.aspx"+UrlEncode("" +AV12UsuariosId);
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpselvacanteregistro.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vVACANTES_NOMBRE", AV15Vacantes_Nombre);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_25", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_25), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vALERTPROPERTIES", AV5AlertProperties);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vALERTPROPERTIES", AV5AlertProperties);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV12UsuariosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV12UsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"USUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12UsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"USUARIOSVACANTEESTATUS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A273UsuariosVacanteEstatus), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIORECLUTADOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10UsuarioReclutador), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SUBT_RECLUTADORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A284SUBT_ReclutadorId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vVACANTES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13vacantes_Id), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"STSELECVACANTE_GRID2_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(STSELECVACANTE_GRID2_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"STSELECVACANTE_GRID2_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(STSELECVACANTE_GRID2_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"STSELECVACANTE_GRID2_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subStselecvacante_grid2_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm2Y2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            context.AddJavascriptSource("wpselvacanteregistro.js", "?202262714341438", false, true);
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
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
         return "wpSelVacanteRegistro" ;
      }

      public override String GetPgmdesc( )
      {
         return "wp Sel Vacante Registro" ;
      }

      protected void WB2Y0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wpselvacanteregistro.aspx");
               context.AddJavascriptSource("SweetAlert2/sweetalert2.all.min.js", "", false, true);
               context.AddJavascriptSource("SweetAlert2/SweetAlert2Render.js", "", false, true);
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, "Vacantes", "", "", lblTitletext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "BigGlobalTitle", 0, "", 1, 1, 0, "HLP_wpSelVacanteRegistro.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-7", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavVacantes_nombre_Internalname, "Nombre", "col-sm-3 FilterSearchAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'" + sPrefix + "',false,'" + sGXsfl_25_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVacantes_nombre_Internalname, AV15Vacantes_Nombre, StringUtil.RTrim( context.localUtil.Format( AV15Vacantes_Nombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,9);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar Vacantes", edtavVacantes_nombre_Jsonclick, 0, "FilterSearchAttribute", "", "", "", "", 1, edtavVacantes_nombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, 0, 0, true, "", "left", true, "", "HLP_wpSelVacanteRegistro.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "Right", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "b0b46857-e88f-49fa-a76e-36ab26e0fd34", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Retroceder", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'RETROCEDER\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_wpSelVacanteRegistro.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "fa4a2720-1114-4089-a06c-a6dd20f2631e", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Siguiente", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'SIGUIENTE\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_wpSelVacanteRegistro.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 TableCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divStselecvacante_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Stselecvacante_grid2Container.SetIsFreestyle(true);
            Stselecvacante_grid2Container.SetWrapped(nGXWrapped);
            if ( Stselecvacante_grid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+sPrefix+"Stselecvacante_grid2Container"+"DivS\" data-gxgridid=\"25\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subStselecvacante_grid2_Internalname, subStselecvacante_grid2_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               Stselecvacante_grid2Container.AddObjectProperty("GridName", "Stselecvacante_grid2");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Stselecvacante_grid2Container = new GXWebGrid( context);
               }
               else
               {
                  Stselecvacante_grid2Container.Clear();
               }
               Stselecvacante_grid2Container.SetIsFreestyle(true);
               Stselecvacante_grid2Container.SetWrapped(nGXWrapped);
               Stselecvacante_grid2Container.AddObjectProperty("GridName", "Stselecvacante_grid2");
               Stselecvacante_grid2Container.AddObjectProperty("Header", subStselecvacante_grid2_Header);
               Stselecvacante_grid2Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
               Stselecvacante_grid2Container.AddObjectProperty("Class", "FreeStyleGrid");
               Stselecvacante_grid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Stselecvacante_grid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Stselecvacante_grid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subStselecvacante_grid2_Backcolorstyle), 1, 0, ".", "")));
               Stselecvacante_grid2Container.AddObjectProperty("CmpContext", sPrefix);
               Stselecvacante_grid2Container.AddObjectProperty("InMasterPage", "false");
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Column.AddObjectProperty("Value", A264Vacantes_Nombre);
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A267Vacantes_Sueldo, 6, 3, ".", "")));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A263Vacantes_Id), 9, 0, ".", "")));
               Stselecvacante_grid2Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVacantes_Id_Visible), 5, 0, ".", "")));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Column.AddObjectProperty("Value", A274Vacantes_Descripcion);
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Stselecvacante_grid2Column.AddObjectProperty("Value", lblStselecvacante_textblock1_Caption);
               Stselecvacante_grid2Container.AddColumnProperties(Stselecvacante_grid2Column);
               Stselecvacante_grid2Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subStselecvacante_grid2_Selectedindex), 4, 0, ".", "")));
               Stselecvacante_grid2Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subStselecvacante_grid2_Allowselection), 1, 0, ".", "")));
               Stselecvacante_grid2Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subStselecvacante_grid2_Selectioncolor), 9, 0, ".", "")));
               Stselecvacante_grid2Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subStselecvacante_grid2_Allowhovering), 1, 0, ".", "")));
               Stselecvacante_grid2Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subStselecvacante_grid2_Hoveringcolor), 9, 0, ".", "")));
               Stselecvacante_grid2Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subStselecvacante_grid2_Allowcollapsing), 1, 0, ".", "")));
               Stselecvacante_grid2Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subStselecvacante_grid2_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 25 )
         {
            wbEnd = 0;
            nRC_GXsfl_25 = (int)(nGXsfl_25_idx-1);
            if ( Stselecvacante_grid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Stselecvacante_grid2Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Stselecvacante_grid2", Stselecvacante_grid2Container);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Stselecvacante_grid2ContainerData", Stselecvacante_grid2Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Stselecvacante_grid2ContainerData"+"V", Stselecvacante_grid2Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Stselecvacante_grid2ContainerData"+"V"+"\" value='"+Stselecvacante_grid2Container.GridValuesHidden()+"'/>") ;
               }
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
            ucUcalertas.SetProperty("Propiedades", AV5AlertProperties);
            ucUcalertas.Render(context, "sweetalert2", Ucalertas_Internalname, sPrefix+"UCALERTASContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 25 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Stselecvacante_grid2Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Stselecvacante_grid2Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Stselecvacante_grid2", Stselecvacante_grid2Container);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Stselecvacante_grid2ContainerData", Stselecvacante_grid2Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Stselecvacante_grid2ContainerData"+"V", Stselecvacante_grid2Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Stselecvacante_grid2ContainerData"+"V"+"\" value='"+Stselecvacante_grid2Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2Y2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus C# 16_0_11-147071", 0) ;
               }
               Form.Meta.addItem("description", "wp Sel Vacante Registro", 0) ;
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
               STRUP2Y0( ) ;
            }
         }
      }

      protected void WS2Y2( )
      {
         START2Y2( ) ;
         EVT2Y2( ) ;
      }

      protected void EVT2Y2( )
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
                                 STRUP2Y0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "UCALERTAS.ACCEPT") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E112Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SIGUIENTE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Siguiente' */
                                    E122Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'RETROCEDER'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Retroceder' */
                                    E132Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'POSTULARSE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Postularse' */
                                    E142Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DECLINAR'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Declinar' */
                                    E152Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavVacantes_nombre_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 25), "STSELECVACANTE_GRID2.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "'POSTULARSE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'DECLINAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Y0( ) ;
                              }
                              nGXsfl_25_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
                              SubsflControlProps_252( ) ;
                              A264Vacantes_Nombre = cgiGet( edtVacantes_Nombre_Internalname);
                              A267Vacantes_Sueldo = context.localUtil.CToN( cgiGet( edtVacantes_Sueldo_Internalname), ",", ".");
                              A263Vacantes_Id = (int)(context.localUtil.CToN( cgiGet( edtVacantes_Id_Internalname), ",", "."));
                              A274Vacantes_Descripcion = cgiGet( edtVacantes_Descripcion_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavVacantes_nombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E162Y2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "STSELECVACANTE_GRID2.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavVacantes_nombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E172Y2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'POSTULARSE'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavVacantes_nombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'Postularse' */
                                          E142Y2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DECLINAR'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavVacantes_nombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'Declinar' */
                                          E152Y2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             /* Set Refresh If Vacantes_nombre Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vVACANTES_NOMBRE"), AV15Vacantes_Nombre) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
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
                                       STRUP2Y0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavVacantes_nombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE2Y2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2Y2( ) ;
            }
         }
      }

      protected void PA2Y2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            if ( StringUtil.Len( sPrefix) == 0 )
            {
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpselvacanteregistro.aspx")), "wpselvacanteregistro.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpselvacanteregistro.aspx")))) ;
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
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetNextPar( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
                     }
                     if ( context.isSpaRequest( ) )
                     {
                        enableJsOutput();
                     }
                  }
               }
            }
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
               GX_FocusControl = edtavVacantes_nombre_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXSGVvVACANTES_NOMBRE2Y0( String A264Vacantes_Nombre )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXSGVvVACANTES_NOMBRE_data2Y0( A264Vacantes_Nombre) ;
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

      protected void GXSGVvVACANTES_NOMBRE_data2Y0( String A264Vacantes_Nombre )
      {
         l264Vacantes_Nombre = StringUtil.Concat( StringUtil.RTrim( A264Vacantes_Nombre), "%", "");
         /* Using cursor H002Y2 */
         pr_default.execute(0, new Object[] {l264Vacantes_Nombre});
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(H002Y2_A264Vacantes_Nombre[0]);
            gxdynajaxctrldescr.Add(H002Y2_A264Vacantes_Nombre[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrStselecvacante_grid2_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_252( ) ;
         while ( nGXsfl_25_idx <= nRC_GXsfl_25 )
         {
            sendrow_252( ) ;
            nGXsfl_25_idx = ((subStselecvacante_grid2_Islastpage==1)&&(nGXsfl_25_idx+1>subStselecvacante_grid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_25_idx+1);
            sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
            SubsflControlProps_252( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Stselecvacante_grid2Container)) ;
         /* End function gxnrStselecvacante_grid2_newrow */
      }

      protected void gxgrStselecvacante_grid2_refresh( int subStselecvacante_grid2_Rows ,
                                                       String AV15Vacantes_Nombre ,
                                                       int A11UsuariosId ,
                                                       int AV12UsuariosId ,
                                                       short A273UsuariosVacanteEstatus ,
                                                       String sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         STSELECVACANTE_GRID2_nCurrentRecord = 0;
         RF2Y2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrStselecvacante_grid2_refresh */
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
         RF2Y2( ) ;
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

      protected void RF2Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Stselecvacante_grid2Container.ClearRows();
         }
         wbStart = 25;
         nGXsfl_25_idx = 1;
         sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
         SubsflControlProps_252( ) ;
         bGXsfl_25_Refreshing = true;
         Stselecvacante_grid2Container.AddObjectProperty("GridName", "Stselecvacante_grid2");
         Stselecvacante_grid2Container.AddObjectProperty("CmpContext", sPrefix);
         Stselecvacante_grid2Container.AddObjectProperty("InMasterPage", "false");
         Stselecvacante_grid2Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         Stselecvacante_grid2Container.AddObjectProperty("Class", "FreeStyleGrid");
         Stselecvacante_grid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Stselecvacante_grid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Stselecvacante_grid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subStselecvacante_grid2_Backcolorstyle), 1, 0, ".", "")));
         Stselecvacante_grid2Container.PageSize = subStselecvacante_grid2_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_252( ) ;
            GXPagingFrom2 = (int)(((subStselecvacante_grid2_Rows==0) ? 0 : STSELECVACANTE_GRID2_nFirstRecordOnPage));
            GXPagingTo2 = ((subStselecvacante_grid2_Rows==0) ? 10000 : subStselecvacante_grid2_fnc_Recordsperpage( )+1);
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV15Vacantes_Nombre ,
                                                 A264Vacantes_Nombre ,
                                                 A265Vacantes_Status } ,
                                                 new int[]{
                                                 TypeConstants.STRING, TypeConstants.STRING, TypeConstants.SHORT
                                                 }
            } ) ;
            lV15Vacantes_Nombre = StringUtil.Concat( StringUtil.RTrim( AV15Vacantes_Nombre), "%", "");
            /* Using cursor H002Y3 */
            pr_default.execute(1, new Object[] {lV15Vacantes_Nombre, GXPagingFrom2, GXPagingTo2});
            nGXsfl_25_idx = 1;
            sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
            SubsflControlProps_252( ) ;
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subStselecvacante_grid2_Rows == 0 ) || ( STSELECVACANTE_GRID2_nCurrentRecord < subStselecvacante_grid2_fnc_Recordsperpage( ) ) ) ) )
            {
               A263Vacantes_Id = H002Y3_A263Vacantes_Id[0];
               A265Vacantes_Status = H002Y3_A265Vacantes_Status[0];
               A274Vacantes_Descripcion = H002Y3_A274Vacantes_Descripcion[0];
               A267Vacantes_Sueldo = H002Y3_A267Vacantes_Sueldo[0];
               A264Vacantes_Nombre = H002Y3_A264Vacantes_Nombre[0];
               E172Y2 ();
               pr_default.readNext(1);
            }
            STSELECVACANTE_GRID2_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"STSELECVACANTE_GRID2_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(STSELECVACANTE_GRID2_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 25;
            WB2Y0( ) ;
         }
         bGXsfl_25_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2Y2( )
      {
      }

      protected int subStselecvacante_grid2_fnc_Pagecount( )
      {
         STSELECVACANTE_GRID2_nRecordCount = subStselecvacante_grid2_fnc_Recordcount( );
         if ( ((int)((STSELECVACANTE_GRID2_nRecordCount) % (subStselecvacante_grid2_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(STSELECVACANTE_GRID2_nRecordCount/ (decimal)(subStselecvacante_grid2_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(STSELECVACANTE_GRID2_nRecordCount/ (decimal)(subStselecvacante_grid2_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subStselecvacante_grid2_fnc_Recordcount( )
      {
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV15Vacantes_Nombre ,
                                              A264Vacantes_Nombre ,
                                              A265Vacantes_Status } ,
                                              new int[]{
                                              TypeConstants.STRING, TypeConstants.STRING, TypeConstants.SHORT
                                              }
         } ) ;
         lV15Vacantes_Nombre = StringUtil.Concat( StringUtil.RTrim( AV15Vacantes_Nombre), "%", "");
         /* Using cursor H002Y4 */
         pr_default.execute(2, new Object[] {lV15Vacantes_Nombre});
         STSELECVACANTE_GRID2_nRecordCount = H002Y4_ASTSELECVACANTE_GRID2_nRecordCount[0];
         pr_default.close(2);
         return (int)(STSELECVACANTE_GRID2_nRecordCount) ;
      }

      protected int subStselecvacante_grid2_fnc_Recordsperpage( )
      {
         if ( subStselecvacante_grid2_Rows > 0 )
         {
            return subStselecvacante_grid2_Rows*3 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subStselecvacante_grid2_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(STSELECVACANTE_GRID2_nFirstRecordOnPage/ (decimal)(subStselecvacante_grid2_fnc_Recordsperpage( ))))+1) ;
      }

      protected short substselecvacante_grid2_firstpage( )
      {
         STSELECVACANTE_GRID2_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"STSELECVACANTE_GRID2_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(STSELECVACANTE_GRID2_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrStselecvacante_grid2_refresh( subStselecvacante_grid2_Rows, AV15Vacantes_Nombre, A11UsuariosId, AV12UsuariosId, A273UsuariosVacanteEstatus, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short substselecvacante_grid2_nextpage( )
      {
         STSELECVACANTE_GRID2_nRecordCount = subStselecvacante_grid2_fnc_Recordcount( );
         if ( ( STSELECVACANTE_GRID2_nRecordCount >= subStselecvacante_grid2_fnc_Recordsperpage( ) ) && ( STSELECVACANTE_GRID2_nEOF == 0 ) )
         {
            STSELECVACANTE_GRID2_nFirstRecordOnPage = (long)(STSELECVACANTE_GRID2_nFirstRecordOnPage+subStselecvacante_grid2_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"STSELECVACANTE_GRID2_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(STSELECVACANTE_GRID2_nFirstRecordOnPage), 15, 0, ".", "")));
         Stselecvacante_grid2Container.AddObjectProperty("STSELECVACANTE_GRID2_nFirstRecordOnPage", STSELECVACANTE_GRID2_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrStselecvacante_grid2_refresh( subStselecvacante_grid2_Rows, AV15Vacantes_Nombre, A11UsuariosId, AV12UsuariosId, A273UsuariosVacanteEstatus, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((STSELECVACANTE_GRID2_nEOF==0) ? 0 : 2)) ;
      }

      protected short substselecvacante_grid2_previouspage( )
      {
         if ( STSELECVACANTE_GRID2_nFirstRecordOnPage >= subStselecvacante_grid2_fnc_Recordsperpage( ) )
         {
            STSELECVACANTE_GRID2_nFirstRecordOnPage = (long)(STSELECVACANTE_GRID2_nFirstRecordOnPage-subStselecvacante_grid2_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"STSELECVACANTE_GRID2_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(STSELECVACANTE_GRID2_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrStselecvacante_grid2_refresh( subStselecvacante_grid2_Rows, AV15Vacantes_Nombre, A11UsuariosId, AV12UsuariosId, A273UsuariosVacanteEstatus, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short substselecvacante_grid2_lastpage( )
      {
         STSELECVACANTE_GRID2_nRecordCount = subStselecvacante_grid2_fnc_Recordcount( );
         if ( STSELECVACANTE_GRID2_nRecordCount > subStselecvacante_grid2_fnc_Recordsperpage( ) )
         {
            if ( ((int)((STSELECVACANTE_GRID2_nRecordCount) % (subStselecvacante_grid2_fnc_Recordsperpage( )))) == 0 )
            {
               STSELECVACANTE_GRID2_nFirstRecordOnPage = (long)(STSELECVACANTE_GRID2_nRecordCount-subStselecvacante_grid2_fnc_Recordsperpage( ));
            }
            else
            {
               STSELECVACANTE_GRID2_nFirstRecordOnPage = (long)(STSELECVACANTE_GRID2_nRecordCount-((int)((STSELECVACANTE_GRID2_nRecordCount) % (subStselecvacante_grid2_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            STSELECVACANTE_GRID2_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"STSELECVACANTE_GRID2_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(STSELECVACANTE_GRID2_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrStselecvacante_grid2_refresh( subStselecvacante_grid2_Rows, AV15Vacantes_Nombre, A11UsuariosId, AV12UsuariosId, A273UsuariosVacanteEstatus, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int substselecvacante_grid2_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            STSELECVACANTE_GRID2_nFirstRecordOnPage = (long)(subStselecvacante_grid2_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            STSELECVACANTE_GRID2_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"STSELECVACANTE_GRID2_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(STSELECVACANTE_GRID2_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrStselecvacante_grid2_refresh( subStselecvacante_grid2_Rows, AV15Vacantes_Nombre, A11UsuariosId, AV12UsuariosId, A273UsuariosVacanteEstatus, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP2Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E162Y2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vALERTPROPERTIES"), AV5AlertProperties);
            /* Read saved values. */
            nRC_GXsfl_25 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_25"), ",", "."));
            wcpOAV12UsuariosId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV12UsuariosId"), ",", "."));
            STSELECVACANTE_GRID2_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( sPrefix+"STSELECVACANTE_GRID2_nFirstRecordOnPage"), ",", "."));
            STSELECVACANTE_GRID2_nEOF = (short)(context.localUtil.CToN( cgiGet( sPrefix+"STSELECVACANTE_GRID2_nEOF"), ",", "."));
            subStselecvacante_grid2_Rows = (int)(context.localUtil.CToN( cgiGet( sPrefix+"STSELECVACANTE_GRID2_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, sPrefix+"STSELECVACANTE_GRID2_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subStselecvacante_grid2_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV15Vacantes_Nombre = cgiGet( edtavVacantes_nombre_Internalname);
            AssignAttri(sPrefix, false, "AV15Vacantes_Nombre", AV15Vacantes_Nombre);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vVACANTES_NOMBRE"), AV15Vacantes_Nombre) != 0 )
            {
               STSELECVACANTE_GRID2_nFirstRecordOnPage = 0;
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
         E162Y2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E162Y2( )
      {
         /* Start Routine */
         subStselecvacante_grid2_Rows = 2;
         GxWebStd.gx_hidden_field( context, sPrefix+"STSELECVACANTE_GRID2_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subStselecvacante_grid2_Rows), 6, 0, ".", "")));
      }

      private void E172Y2( )
      {
         /* Stselecvacante_grid2_Load Routine */
         edtVacantes_Id_Visible = 0;
         /* Using cursor H002Y5 */
         pr_default.execute(3, new Object[] {A263Vacantes_Id, AV12UsuariosId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A273UsuariosVacanteEstatus = H002Y5_A273UsuariosVacanteEstatus[0];
            A11UsuariosId = H002Y5_A11UsuariosId[0];
            AV14vacantes_IdRec = A263Vacantes_Id;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
         if ( A263Vacantes_Id == AV14vacantes_IdRec )
         {
            bttStselecvacante_postularse_Visible = 0;
            AssignProp(sPrefix, false, bttStselecvacante_postularse_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttStselecvacante_postularse_Visible), 5, 0), !bGXsfl_25_Refreshing);
            bttStselecvacante_declinar_Visible = 1;
            AssignProp(sPrefix, false, bttStselecvacante_declinar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttStselecvacante_declinar_Visible), 5, 0), !bGXsfl_25_Refreshing);
            tblStselecvacante_table3_Bordercolor = GXUtil.RGB( 119, 221, 119);
            tblStselecvacante_table3_Backcolor = GXUtil.RGB( 242, 253, 245);
            AssignProp(sPrefix, false, tblStselecvacante_table3_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(tblStselecvacante_table3_Backcolor), 9, 0), !bGXsfl_25_Refreshing);
         }
         else
         {
            bttStselecvacante_postularse_Visible = 1;
            AssignProp(sPrefix, false, bttStselecvacante_postularse_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttStselecvacante_postularse_Visible), 5, 0), !bGXsfl_25_Refreshing);
            bttStselecvacante_declinar_Visible = 0;
            AssignProp(sPrefix, false, bttStselecvacante_declinar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttStselecvacante_declinar_Visible), 5, 0), !bGXsfl_25_Refreshing);
            tblStselecvacante_table3_Bordercolor = GXUtil.RGB( 132, 182, 244);
            tblStselecvacante_table3_Backcolor = GXUtil.RGB( 0, 0, 0);
            AssignProp(sPrefix, false, tblStselecvacante_table3_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(tblStselecvacante_table3_Backcolor), 9, 0), !bGXsfl_25_Refreshing);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 25;
         }
         sendrow_252( ) ;
         STSELECVACANTE_GRID2_nCurrentRecord = (long)(STSELECVACANTE_GRID2_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_25_Refreshing )
         {
            context.DoAjaxLoad(25, Stselecvacante_grid2Row);
         }
         /*  Sending Event outputs  */
      }

      protected void E142Y2( )
      {
         /* 'Postularse' Routine */
         AV13vacantes_Id = A263Vacantes_Id;
         AssignAttri(sPrefix, false, "AV13vacantes_Id", StringUtil.LTrimStr( (decimal)(AV13vacantes_Id), 9, 0));
         /* Execute user subroutine: 'BUSCAVACANTEUUSARIOS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5AlertProperties", AV5AlertProperties);
      }

      protected void E152Y2( )
      {
         /* 'Declinar' Routine */
         AV13vacantes_Id = A263Vacantes_Id;
         AssignAttri(sPrefix, false, "AV13vacantes_Id", StringUtil.LTrimStr( (decimal)(AV13vacantes_Id), 9, 0));
         new pr_guardavacanteusuario(context ).execute(  AV12UsuariosId,  AV13vacantes_Id,  "Declinar",  AV10UsuarioReclutador) ;
         GXt_SdtPropiedades1 = AV5AlertProperties;
         new getsweetmessage(context ).execute(  "success",  "Información Modificada Exitosamente",  "",  true,  false, out  GXt_SdtPropiedades1) ;
         AV5AlertProperties = GXt_SdtPropiedades1;
         this.executeUsercontrolMethod(sPrefix, false, "UCALERTASContainer", "showAlert", "", new Object[] {});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5AlertProperties", AV5AlertProperties);
      }

      protected void E112Y2( )
      {
         /* Ucalertas_Accept Routine */
         /* Using cursor H002Y6 */
         pr_default.execute(4, new Object[] {AV12UsuariosId});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A273UsuariosVacanteEstatus = H002Y6_A273UsuariosVacanteEstatus[0];
            A263Vacantes_Id = H002Y6_A263Vacantes_Id[0];
            A11UsuariosId = H002Y6_A11UsuariosId[0];
            A284SUBT_ReclutadorId = H002Y6_A284SUBT_ReclutadorId[0];
            AV10UsuarioReclutador = A284SUBT_ReclutadorId;
            AssignAttri(sPrefix, false, "AV10UsuarioReclutador", StringUtil.LTrimStr( (decimal)(AV10UsuarioReclutador), 9, 0));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
         new pr_guardavacanteusuario(context ).execute(  AV12UsuariosId,  AV13vacantes_Id,  "Postularse",  AV10UsuarioReclutador) ;
         GXt_SdtPropiedades1 = AV5AlertProperties;
         new getsweetmessage(context ).execute(  "success",  "Información Guardada Exitosamente",  "",  true,  false, out  GXt_SdtPropiedades1) ;
         AV5AlertProperties = GXt_SdtPropiedades1;
         this.executeUsercontrolMethod(sPrefix, false, "UCALERTASContainer", "showAlert", "", new Object[] {});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5AlertProperties", AV5AlertProperties);
      }

      protected void S112( )
      {
         /* 'BUSCAVACANTEUUSARIOS' Routine */
         AV6Contador = 0;
         AV20GXLvl67 = 0;
         /* Using cursor H002Y7 */
         pr_default.execute(5, new Object[] {AV12UsuariosId});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A273UsuariosVacanteEstatus = H002Y7_A273UsuariosVacanteEstatus[0];
            A11UsuariosId = H002Y7_A11UsuariosId[0];
            AV20GXLvl67 = 1;
            AV6Contador = (short)(AV6Contador+1);
            if ( AV6Contador >= 2 )
            {
               GXt_SdtPropiedades1 = AV5AlertProperties;
               new getsweetmessage(context ).execute(  "error",  "No puede postularse a mas de 2 vacantes",  "",  true,  false, out  GXt_SdtPropiedades1) ;
               AV5AlertProperties = GXt_SdtPropiedades1;
               this.executeUsercontrolMethod(sPrefix, false, "UCALERTASContainer", "showAlert", "", new Object[] {});
               context.DoAjaxRefreshCmp(sPrefix);
            }
            else
            {
               /* Execute user subroutine: 'ALERTAS' */
               S125 ();
               if ( returnInSub )
               {
                  pr_default.close(5);
                  returnInSub = true;
                  if (true) return;
               }
            }
            pr_default.readNext(5);
         }
         pr_default.close(5);
         if ( AV20GXLvl67 == 0 )
         {
            /* Execute user subroutine: 'ALERTAS' */
            S125 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void S125( )
      {
         /* 'ALERTAS' Routine */
         GXt_SdtPropiedades1 = AV5AlertProperties;
         new getsweetmessage(context ).execute(  "question",  "Esta seguro de postularse en esta vacante",  "",  false,  true, out  GXt_SdtPropiedades1) ;
         AV5AlertProperties = GXt_SdtPropiedades1;
         AV5AlertProperties.gxTpr_Showconfirmbutton = true;
         AV5AlertProperties.gxTpr_Confirmbuttontext = "Aceptar";
         AV5AlertProperties.gxTpr_Confirmbuttoncolor = "rgb(76,173,76)";
         AV5AlertProperties.gxTpr_Showcancelbutton = true;
         AV5AlertProperties.gxTpr_Cancelbuttontext = "Cancelar";
         AV5AlertProperties.gxTpr_Cancelbuttoncolor = "rgb(255,105,97)";
         this.executeUsercontrolMethod(sPrefix, false, "UCALERTASContainer", "showAlert", "", new Object[] {});
      }

      protected void E122Y2( )
      {
         /* 'Siguiente' Routine */
         substselecvacante_grid2_nextpage( ) ;
      }

      protected void E132Y2( )
      {
         /* 'Retroceder' Routine */
         substselecvacante_grid2_previouspage( ) ;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV12UsuariosId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV12UsuariosId", StringUtil.LTrimStr( (decimal)(AV12UsuariosId), 6, 0));
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
         PA2Y2( ) ;
         WS2Y2( ) ;
         WE2Y2( ) ;
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
         sCtrlAV12UsuariosId = (String)((String)getParm(obj,0));
      }

      public override void componentrestorestate( String sPPrefix ,
                                                  String sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2Y2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (String)getParm(obj,0);
         sSFPrefix = (String)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wpselvacanteregistro", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2Y2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV12UsuariosId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV12UsuariosId", StringUtil.LTrimStr( (decimal)(AV12UsuariosId), 6, 0));
         }
         wcpOAV12UsuariosId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV12UsuariosId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( AV12UsuariosId != wcpOAV12UsuariosId ) ) )
         {
            setjustcreated();
         }
         wcpOAV12UsuariosId = AV12UsuariosId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV12UsuariosId = cgiGet( sPrefix+"AV12UsuariosId_CTRL");
         if ( StringUtil.Len( sCtrlAV12UsuariosId) > 0 )
         {
            AV12UsuariosId = (int)(context.localUtil.CToN( cgiGet( sCtrlAV12UsuariosId), ",", "."));
            AssignAttri(sPrefix, false, "AV12UsuariosId", StringUtil.LTrimStr( (decimal)(AV12UsuariosId), 6, 0));
         }
         else
         {
            AV12UsuariosId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV12UsuariosId_PARM"), ",", "."));
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
         PA2Y2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2Y2( ) ;
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
         WS2Y2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV12UsuariosId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12UsuariosId), 6, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV12UsuariosId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV12UsuariosId_CTRL", StringUtil.RTrim( sCtrlAV12UsuariosId));
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
         WE2Y2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714341497", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("wpselvacanteregistro.js", "?202262714341497", false, true);
            context.AddJavascriptSource("SweetAlert2/sweetalert2.all.min.js", "", false, true);
            context.AddJavascriptSource("SweetAlert2/SweetAlert2Render.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_252( )
      {
         edtVacantes_Nombre_Internalname = sPrefix+"VACANTES_NOMBRE_"+sGXsfl_25_idx;
         edtVacantes_Sueldo_Internalname = sPrefix+"VACANTES_SUELDO_"+sGXsfl_25_idx;
         edtVacantes_Id_Internalname = sPrefix+"VACANTES_ID_"+sGXsfl_25_idx;
         edtVacantes_Descripcion_Internalname = sPrefix+"VACANTES_DESCRIPCION_"+sGXsfl_25_idx;
         lblStselecvacante_textblock1_Internalname = sPrefix+"STSELECVACANTE_TEXTBLOCK1_"+sGXsfl_25_idx;
      }

      protected void SubsflControlProps_fel_252( )
      {
         edtVacantes_Nombre_Internalname = sPrefix+"VACANTES_NOMBRE_"+sGXsfl_25_fel_idx;
         edtVacantes_Sueldo_Internalname = sPrefix+"VACANTES_SUELDO_"+sGXsfl_25_fel_idx;
         edtVacantes_Id_Internalname = sPrefix+"VACANTES_ID_"+sGXsfl_25_fel_idx;
         edtVacantes_Descripcion_Internalname = sPrefix+"VACANTES_DESCRIPCION_"+sGXsfl_25_fel_idx;
         lblStselecvacante_textblock1_Internalname = sPrefix+"STSELECVACANTE_TEXTBLOCK1_"+sGXsfl_25_fel_idx;
      }

      protected void sendrow_252( )
      {
         SubsflControlProps_252( ) ;
         WB2Y0( ) ;
         if ( ( subStselecvacante_grid2_Rows * 3 == 0 ) || ( nGXsfl_25_idx <= subStselecvacante_grid2_fnc_Recordsperpage( ) * 3 ) )
         {
            Stselecvacante_grid2Row = GXWebRow.GetNew(context,Stselecvacante_grid2Container);
            if ( subStselecvacante_grid2_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subStselecvacante_grid2_Backstyle = 0;
               if ( StringUtil.StrCmp(subStselecvacante_grid2_Class, "") != 0 )
               {
                  subStselecvacante_grid2_Linesclass = subStselecvacante_grid2_Class+"Odd";
               }
            }
            else if ( subStselecvacante_grid2_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subStselecvacante_grid2_Backstyle = 0;
               subStselecvacante_grid2_Backcolor = subStselecvacante_grid2_Allbackcolor;
               if ( StringUtil.StrCmp(subStselecvacante_grid2_Class, "") != 0 )
               {
                  subStselecvacante_grid2_Linesclass = subStselecvacante_grid2_Class+"Uniform";
               }
            }
            else if ( subStselecvacante_grid2_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subStselecvacante_grid2_Backstyle = 1;
               if ( StringUtil.StrCmp(subStselecvacante_grid2_Class, "") != 0 )
               {
                  subStselecvacante_grid2_Linesclass = subStselecvacante_grid2_Class+"Odd";
               }
               subStselecvacante_grid2_Backcolor = (int)(0xFFFFFF);
            }
            else if ( subStselecvacante_grid2_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subStselecvacante_grid2_Backstyle = 1;
               if ( ((int)((nGXsfl_25_idx) % (2))) == 0 )
               {
                  subStselecvacante_grid2_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subStselecvacante_grid2_Class, "") != 0 )
                  {
                     subStselecvacante_grid2_Linesclass = subStselecvacante_grid2_Class+"Even";
                  }
               }
               else
               {
                  subStselecvacante_grid2_Backcolor = (int)(0xFFFFFF);
                  if ( StringUtil.StrCmp(subStselecvacante_grid2_Class, "") != 0 )
                  {
                     subStselecvacante_grid2_Linesclass = subStselecvacante_grid2_Class+"Odd";
                  }
               }
            }
            /* Start of Columns property logic. */
            if ( Stselecvacante_grid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr"+" class=\""+subStselecvacante_grid2_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_25_idx+"\">") ;
            }
            /* Div Control */
            Stselecvacante_grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)divStselecvacante_grid2table1_Internalname+"_"+sGXsfl_25_idx,(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"Table",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
            /* Div Control */
            Stselecvacante_grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"row",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
            /* Div Control */
            Stselecvacante_grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"col-xs-12",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
            /* Table start */
            Stselecvacante_grid2Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(String)tblStselecvacante_table3_Internalname+"_"+sGXsfl_25_idx,(short)1,(String)"TablaRedondeada",(String)"",(int)tblStselecvacante_table3_Backcolor,(int)tblStselecvacante_table3_Bordercolor,(String)"",(String)"",(String)"",(short)1,(short)2,(String)"",(String)"",(String)"",(String)"px",(String)"px",(String)""});
            Stselecvacante_grid2Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
            Stselecvacante_grid2Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
            /* Div Control */
            Stselecvacante_grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"form-group gx-form-group gx-default-form-group",(String)"left",(String)"top",(String)""+" data-gx-for=\""+edtVacantes_Nombre_Internalname+"\"",(String)"",(String)"div"});
            /* Attribute/Variable Label */
            Stselecvacante_grid2Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(String)edtVacantes_Nombre_Internalname,(String)"Nombre",(String)"gx-form-item AttributeTitleLabel",(short)1,(bool)true,(String)"width: 25%;"});
            /* Div Control */
            Stselecvacante_grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)75,(String)"%",(short)0,(String)"px",(String)"gx-form-item gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
            /* Single line edit */
            ROClassString = "AttributeTitle";
            Stselecvacante_grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtVacantes_Nombre_Internalname,(String)A264Vacantes_Nombre,(String)"",(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtVacantes_Nombre_Jsonclick,(short)0,(String)"AttributeTitle",(String)"",(String)ROClassString,(String)"",(String)"",(short)1,(short)0,(short)0,(String)"text",(String)"",(short)40,(String)"chr",(short)1,(String)"row",(short)40,(short)0,(short)0,(short)25,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            Stselecvacante_grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
            Stselecvacante_grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
            if ( Stselecvacante_grid2Container.GetWrapped() == 1 )
            {
               Stselecvacante_grid2Container.CloseTag("cell");
            }
            if ( Stselecvacante_grid2Container.GetWrapped() == 1 )
            {
               Stselecvacante_grid2Container.CloseTag("row");
            }
            Stselecvacante_grid2Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
            Stselecvacante_grid2Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
            /* Div Control */
            Stselecvacante_grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"form-group gx-form-group gx-default-form-group",(String)"left",(String)"top",(String)""+" data-gx-for=\""+edtVacantes_Sueldo_Internalname+"\"",(String)"",(String)"div"});
            /* Attribute/Variable Label */
            Stselecvacante_grid2Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(String)edtVacantes_Sueldo_Internalname,(String)"Sueldo",(String)"gx-form-item AttributeTitleLabel",(short)1,(bool)true,(String)"width: 25%;"});
            /* Div Control */
            Stselecvacante_grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)75,(String)"%",(short)0,(String)"px",(String)"gx-form-item gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
            /* Single line edit */
            ROClassString = "AttributeTitle";
            Stselecvacante_grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtVacantes_Sueldo_Internalname,StringUtil.LTrim( StringUtil.NToC( A267Vacantes_Sueldo, 6, 3, ",", "")),context.localUtil.Format( A267Vacantes_Sueldo, "Z9.999"),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtVacantes_Sueldo_Jsonclick,(short)0,(String)"AttributeTitle",(String)"",(String)ROClassString,(String)"",(String)"",(short)1,(short)0,(short)0,(String)"text",(String)"",(short)6,(String)"chr",(short)1,(String)"row",(short)6,(short)0,(short)0,(short)25,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            Stselecvacante_grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
            Stselecvacante_grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
            if ( Stselecvacante_grid2Container.GetWrapped() == 1 )
            {
               Stselecvacante_grid2Container.CloseTag("cell");
            }
            Stselecvacante_grid2Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
            /* Div Control */
            Stselecvacante_grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(int)edtVacantes_Id_Visible,(short)0,(String)"px",(short)0,(String)"px",(String)"form-group gx-form-group gx-default-form-group",(String)"left",(String)"top",(String)""+" data-gx-for=\""+edtVacantes_Id_Internalname+"\"",(String)"",(String)"div"});
            /* Attribute/Variable Label */
            Stselecvacante_grid2Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(String)edtVacantes_Id_Internalname,(String)"ID",(String)"gx-form-item AttBlancoLabel",(short)1,(bool)true,(String)"width: 25%;"});
            /* Div Control */
            Stselecvacante_grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)75,(String)"%",(short)0,(String)"px",(String)"gx-form-item gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
            /* Single line edit */
            ROClassString = "AttBlanco";
            Stselecvacante_grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtVacantes_Id_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A263Vacantes_Id), 9, 0, ",", "")),context.localUtil.Format( (decimal)(A263Vacantes_Id), "ZZZZZZZZ9"),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtVacantes_Id_Jsonclick,(short)0,(String)"AttBlanco",(String)"",(String)ROClassString,(String)"",(String)"",(int)edtVacantes_Id_Visible,(short)0,(short)0,(String)"number",(String)"1",(short)9,(String)"chr",(short)1,(String)"row",(short)9,(short)0,(short)0,(short)25,(short)1,(short)-1,(short)0,(bool)true,(String)"Id",(String)"right",(bool)false,(String)""});
            Stselecvacante_grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
            Stselecvacante_grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
            if ( Stselecvacante_grid2Container.GetWrapped() == 1 )
            {
               Stselecvacante_grid2Container.CloseTag("cell");
            }
            if ( Stselecvacante_grid2Container.GetWrapped() == 1 )
            {
               Stselecvacante_grid2Container.CloseTag("row");
            }
            Stselecvacante_grid2Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
            Stselecvacante_grid2Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
            /* Div Control */
            Stselecvacante_grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"form-group gx-form-group gx-default-form-group",(String)"left",(String)"top",(String)""+" data-gx-for=\""+edtVacantes_Descripcion_Internalname+"\"",(String)"",(String)"div"});
            /* Attribute/Variable Label */
            Stselecvacante_grid2Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(String)edtVacantes_Descripcion_Internalname,(String)"Descripción",(String)"gx-form-item AttributeTitleLabel",(short)1,(bool)true,(String)"width: 25%;"});
            /* Div Control */
            Stselecvacante_grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)75,(String)"%",(short)0,(String)"px",(String)"gx-form-item gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
            /* Multiple line edit */
            ClassString = "AttributeTitle";
            StyleString = "";
            ClassString = "AttributeTitle";
            StyleString = "";
            Stselecvacante_grid2Row.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(String)edtVacantes_Descripcion_Internalname,(String)A274Vacantes_Descripcion,(String)"",(String)"",(short)0,(short)1,(short)0,(short)0,(short)80,(String)"chr",(short)10,(String)"row",(String)StyleString,(String)ClassString,(String)"",(String)"",(String)"1000",(short)-1,(short)0,(String)"",(String)"",(short)-1,(bool)true,(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(short)0});
            Stselecvacante_grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
            Stselecvacante_grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
            if ( Stselecvacante_grid2Container.GetWrapped() == 1 )
            {
               Stselecvacante_grid2Container.CloseTag("cell");
            }
            if ( Stselecvacante_grid2Container.GetWrapped() == 1 )
            {
               Stselecvacante_grid2Container.CloseTag("row");
            }
            Stselecvacante_grid2Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
            Stselecvacante_grid2Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            Stselecvacante_grid2Row.AddColumnProperties("button", 2, isAjaxCallMode( ), new Object[] {(String)bttStselecvacante_postularse_Internalname+"_"+sGXsfl_25_idx,"gx.evt.setGridEvt("+StringUtil.Str( (decimal)(25), 2, 0)+","+"null"+");",(String)"Postularse",(String)bttStselecvacante_postularse_Jsonclick,(short)5,(String)"Postularse",(String)"",(String)StyleString,(String)ClassString,(int)bttStselecvacante_postularse_Visible,(short)1,(String)"standard","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'POSTULARSE\\'."+"'",(String)TempTags,(String)"",context.GetButtonType( )});
            if ( Stselecvacante_grid2Container.GetWrapped() == 1 )
            {
               Stselecvacante_grid2Container.CloseTag("cell");
            }
            if ( Stselecvacante_grid2Container.GetWrapped() == 1 )
            {
               Stselecvacante_grid2Container.CloseTag("row");
            }
            Stselecvacante_grid2Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
            Stselecvacante_grid2Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            Stselecvacante_grid2Row.AddColumnProperties("button", 2, isAjaxCallMode( ), new Object[] {(String)bttStselecvacante_declinar_Internalname+"_"+sGXsfl_25_idx,"gx.evt.setGridEvt("+StringUtil.Str( (decimal)(25), 2, 0)+","+"null"+");",(String)"Declinar",(String)bttStselecvacante_declinar_Jsonclick,(short)5,(String)"Declinar",(String)"",(String)StyleString,(String)ClassString,(int)bttStselecvacante_declinar_Visible,(short)1,(String)"standard","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DECLINAR\\'."+"'",(String)TempTags,(String)"",context.GetButtonType( )});
            if ( Stselecvacante_grid2Container.GetWrapped() == 1 )
            {
               Stselecvacante_grid2Container.CloseTag("cell");
            }
            if ( Stselecvacante_grid2Container.GetWrapped() == 1 )
            {
               Stselecvacante_grid2Container.CloseTag("row");
            }
            if ( Stselecvacante_grid2Container.GetWrapped() == 1 )
            {
               Stselecvacante_grid2Container.CloseTag("table");
            }
            /* End of table */
            Stselecvacante_grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
            Stselecvacante_grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
            /* Div Control */
            Stselecvacante_grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"row",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
            /* Div Control */
            Stselecvacante_grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"col-xs-12",(String)"Center",(String)"top",(String)"",(String)"",(String)"div"});
            sendrow_25230( ) ;
         }
      }

      protected void sendrow_25230( )
      {
         /* Text block */
         Stselecvacante_grid2Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(String)lblStselecvacante_textblock1_Internalname,".",(String)"",(String)"",(String)lblStselecvacante_textblock1_Jsonclick,(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"BigTitle1",(short)0,(String)"",(short)1,(short)1,(short)0});
         Stselecvacante_grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"Center",(String)"top",(String)"div"});
         Stselecvacante_grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         Stselecvacante_grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         send_integrity_lvl_hashes2Y2( ) ;
         /* End of Columns property logic. */
         Stselecvacante_grid2Container.AddRow(Stselecvacante_grid2Row);
         nGXsfl_25_idx = ((subStselecvacante_grid2_Islastpage==1)&&(nGXsfl_25_idx+1>subStselecvacante_grid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_25_idx+1);
         sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
         SubsflControlProps_252( ) ;
         /* End function sendrow_252 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitletext_Internalname = sPrefix+"TITLETEXT";
         edtavVacantes_nombre_Internalname = sPrefix+"vVACANTES_NOMBRE";
         imgImage2_Internalname = sPrefix+"IMAGE2";
         imgImage1_Internalname = sPrefix+"IMAGE1";
         edtVacantes_Nombre_Internalname = sPrefix+"VACANTES_NOMBRE";
         edtVacantes_Sueldo_Internalname = sPrefix+"VACANTES_SUELDO";
         edtVacantes_Id_Internalname = sPrefix+"VACANTES_ID";
         edtVacantes_Descripcion_Internalname = sPrefix+"VACANTES_DESCRIPCION";
         bttStselecvacante_postularse_Internalname = sPrefix+"STSELECVACANTE_POSTULARSE";
         bttStselecvacante_declinar_Internalname = sPrefix+"STSELECVACANTE_DECLINAR";
         tblStselecvacante_table3_Internalname = sPrefix+"STSELECVACANTE_TABLE3";
         lblStselecvacante_textblock1_Internalname = sPrefix+"STSELECVACANTE_TEXTBLOCK1";
         divStselecvacante_grid2table1_Internalname = sPrefix+"STSELECVACANTE_GRID2TABLE1";
         divStselecvacante_Internalname = sPrefix+"STSELECVACANTE";
         Ucalertas_Internalname = sPrefix+"UCALERTAS";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subStselecvacante_grid2_Internalname = sPrefix+"STSELECVACANTE_GRID2";
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
         bttStselecvacante_declinar_Visible = 1;
         bttStselecvacante_postularse_Visible = 1;
         edtVacantes_Id_Jsonclick = "";
         edtVacantes_Sueldo_Jsonclick = "";
         edtVacantes_Nombre_Jsonclick = "";
         tblStselecvacante_table3_Bordercolor = (int)(0x000000);
         subStselecvacante_grid2_Class = "FreeStyleGrid";
         tblStselecvacante_table3_Backcolor = (int)(0x000000);
         subStselecvacante_grid2_Allowcollapsing = 0;
         lblStselecvacante_textblock1_Caption = ".";
         edtVacantes_Id_Visible = 1;
         subStselecvacante_grid2_Backcolorstyle = 0;
         edtavVacantes_nombre_Jsonclick = "";
         edtavVacantes_nombre_Enabled = 1;
         subStselecvacante_grid2_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'STSELECVACANTE_GRID2_nFirstRecordOnPage'},{av:'STSELECVACANTE_GRID2_nEOF'},{av:'subStselecvacante_grid2_Rows',ctrl:'STSELECVACANTE_GRID2',prop:'Rows'},{av:'AV15Vacantes_Nombre',fld:'vVACANTES_NOMBRE',pic:''},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV12UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'A273UsuariosVacanteEstatus',fld:'USUARIOSVACANTEESTATUS',pic:'9'},{av:'sPrefix'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("STSELECVACANTE_GRID2.LOAD","{handler:'E172Y2',iparms:[{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV12UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'A273UsuariosVacanteEstatus',fld:'USUARIOSVACANTEESTATUS',pic:'9'},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("STSELECVACANTE_GRID2.LOAD",",oparms:[{av:'edtVacantes_Id_Visible',ctrl:'VACANTES_ID',prop:'Visible'},{ctrl:'STSELECVACANTE_POSTULARSE',prop:'Visible'},{ctrl:'STSELECVACANTE_DECLINAR',prop:'Visible'},{av:'tblStselecvacante_table3_Bordercolor',ctrl:'STSELECVACANTE_TABLE3',prop:'Bordercolor'},{av:'tblStselecvacante_table3_Backcolor',ctrl:'STSELECVACANTE_TABLE3',prop:'Backcolor'}]}");
         setEventMetadata("'POSTULARSE'","{handler:'E142Y2',iparms:[{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV12UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'A273UsuariosVacanteEstatus',fld:'USUARIOSVACANTEESTATUS',pic:'9'}]");
         setEventMetadata("'POSTULARSE'",",oparms:[{av:'AV13vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV5AlertProperties',fld:'vALERTPROPERTIES',pic:''}]}");
         setEventMetadata("'DECLINAR'","{handler:'E152Y2',iparms:[{av:'STSELECVACANTE_GRID2_nFirstRecordOnPage'},{av:'STSELECVACANTE_GRID2_nEOF'},{av:'subStselecvacante_grid2_Rows',ctrl:'STSELECVACANTE_GRID2',prop:'Rows'},{av:'AV15Vacantes_Nombre',fld:'vVACANTES_NOMBRE',pic:''},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV12UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'A273UsuariosVacanteEstatus',fld:'USUARIOSVACANTEESTATUS',pic:'9'},{av:'sPrefix'},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV10UsuarioReclutador',fld:'vUSUARIORECLUTADOR',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("'DECLINAR'",",oparms:[{av:'AV13vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV5AlertProperties',fld:'vALERTPROPERTIES',pic:''}]}");
         setEventMetadata("UCALERTAS.ACCEPT","{handler:'E112Y2',iparms:[{av:'STSELECVACANTE_GRID2_nFirstRecordOnPage'},{av:'STSELECVACANTE_GRID2_nEOF'},{av:'subStselecvacante_grid2_Rows',ctrl:'STSELECVACANTE_GRID2',prop:'Rows'},{av:'AV15Vacantes_Nombre',fld:'vVACANTES_NOMBRE',pic:''},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV12UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'A273UsuariosVacanteEstatus',fld:'USUARIOSVACANTEESTATUS',pic:'9'},{av:'sPrefix'},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'A284SUBT_ReclutadorId',fld:'SUBT_RECLUTADORID',pic:'ZZZZZ9'},{av:'AV13vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("UCALERTAS.ACCEPT",",oparms:[{av:'AV10UsuarioReclutador',fld:'vUSUARIORECLUTADOR',pic:'ZZZZZZZZ9'},{av:'AV5AlertProperties',fld:'vALERTPROPERTIES',pic:''}]}");
         setEventMetadata("'SIGUIENTE'","{handler:'E122Y2',iparms:[{av:'STSELECVACANTE_GRID2_nFirstRecordOnPage'},{av:'STSELECVACANTE_GRID2_nEOF'},{av:'subStselecvacante_grid2_Rows',ctrl:'STSELECVACANTE_GRID2',prop:'Rows'},{av:'AV15Vacantes_Nombre',fld:'vVACANTES_NOMBRE',pic:''},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV12UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'A273UsuariosVacanteEstatus',fld:'USUARIOSVACANTEESTATUS',pic:'9'},{av:'sPrefix'}]");
         setEventMetadata("'SIGUIENTE'",",oparms:[]}");
         setEventMetadata("'RETROCEDER'","{handler:'E132Y2',iparms:[{av:'STSELECVACANTE_GRID2_nFirstRecordOnPage'},{av:'STSELECVACANTE_GRID2_nEOF'},{av:'subStselecvacante_grid2_Rows',ctrl:'STSELECVACANTE_GRID2',prop:'Rows'},{av:'AV15Vacantes_Nombre',fld:'vVACANTES_NOMBRE',pic:''},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV12UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'A273UsuariosVacanteEstatus',fld:'USUARIOSVACANTEESTATUS',pic:'9'},{av:'sPrefix'}]");
         setEventMetadata("'RETROCEDER'",",oparms:[]}");
         setEventMetadata("VALID_VACANTES_ID","{handler:'Valid_Vacantes_id',iparms:[]");
         setEventMetadata("VALID_VACANTES_ID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Vacantes_descripcion',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         A264Vacantes_Nombre = "";
         AV15Vacantes_Nombre = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV5AlertProperties = new SdtPropiedades(context);
         GX_FocusControl = "";
         lblTitletext_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         imgImage2_Jsonclick = "";
         imgImage1_Jsonclick = "";
         Stselecvacante_grid2Container = new GXWebGrid( context);
         sStyleString = "";
         subStselecvacante_grid2_Header = "";
         Stselecvacante_grid2Column = new GXWebColumn();
         A274Vacantes_Descripcion = "";
         ucUcalertas = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         l264Vacantes_Nombre = "";
         H002Y2_A264Vacantes_Nombre = new String[] {""} ;
         lV15Vacantes_Nombre = "";
         H002Y3_A263Vacantes_Id = new int[1] ;
         H002Y3_A265Vacantes_Status = new short[1] ;
         H002Y3_A274Vacantes_Descripcion = new String[] {""} ;
         H002Y3_A267Vacantes_Sueldo = new decimal[1] ;
         H002Y3_A264Vacantes_Nombre = new String[] {""} ;
         H002Y4_ASTSELECVACANTE_GRID2_nRecordCount = new long[1] ;
         H002Y5_A263Vacantes_Id = new int[1] ;
         H002Y5_A273UsuariosVacanteEstatus = new short[1] ;
         H002Y5_A11UsuariosId = new int[1] ;
         Stselecvacante_grid2Row = new GXWebRow();
         H002Y6_A273UsuariosVacanteEstatus = new short[1] ;
         H002Y6_A263Vacantes_Id = new int[1] ;
         H002Y6_A11UsuariosId = new int[1] ;
         H002Y6_A284SUBT_ReclutadorId = new int[1] ;
         H002Y7_A263Vacantes_Id = new int[1] ;
         H002Y7_A273UsuariosVacanteEstatus = new short[1] ;
         H002Y7_A11UsuariosId = new int[1] ;
         GXt_SdtPropiedades1 = new SdtPropiedades(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV12UsuariosId = "";
         subStselecvacante_grid2_Linesclass = "";
         ROClassString = "";
         bttStselecvacante_postularse_Jsonclick = "";
         bttStselecvacante_declinar_Jsonclick = "";
         lblStselecvacante_textblock1_Jsonclick = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpselvacanteregistro__default(),
            new Object[][] {
                new Object[] {
               H002Y2_A264Vacantes_Nombre
               }
               , new Object[] {
               H002Y3_A263Vacantes_Id, H002Y3_A265Vacantes_Status, H002Y3_A274Vacantes_Descripcion, H002Y3_A267Vacantes_Sueldo, H002Y3_A264Vacantes_Nombre
               }
               , new Object[] {
               H002Y4_ASTSELECVACANTE_GRID2_nRecordCount
               }
               , new Object[] {
               H002Y5_A263Vacantes_Id, H002Y5_A273UsuariosVacanteEstatus, H002Y5_A11UsuariosId
               }
               , new Object[] {
               H002Y6_A273UsuariosVacanteEstatus, H002Y6_A263Vacantes_Id, H002Y6_A11UsuariosId, H002Y6_A284SUBT_ReclutadorId
               }
               , new Object[] {
               H002Y7_A263Vacantes_Id, H002Y7_A273UsuariosVacanteEstatus, H002Y7_A11UsuariosId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short STSELECVACANTE_GRID2_nEOF ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short A273UsuariosVacanteEstatus ;
      private short initialized ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short subStselecvacante_grid2_Backcolorstyle ;
      private short subStselecvacante_grid2_Allowselection ;
      private short subStselecvacante_grid2_Allowhovering ;
      private short subStselecvacante_grid2_Allowcollapsing ;
      private short subStselecvacante_grid2_Collapsed ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short A265Vacantes_Status ;
      private short AV6Contador ;
      private short AV20GXLvl67 ;
      private short subStselecvacante_grid2_Backstyle ;
      private int AV12UsuariosId ;
      private int wcpOAV12UsuariosId ;
      private int nRC_GXsfl_25 ;
      private int nGXsfl_25_idx=1 ;
      private int subStselecvacante_grid2_Rows ;
      private int A11UsuariosId ;
      private int AV10UsuarioReclutador ;
      private int A284SUBT_ReclutadorId ;
      private int AV13vacantes_Id ;
      private int edtavVacantes_nombre_Enabled ;
      private int A263Vacantes_Id ;
      private int edtVacantes_Id_Visible ;
      private int subStselecvacante_grid2_Selectedindex ;
      private int subStselecvacante_grid2_Selectioncolor ;
      private int subStselecvacante_grid2_Hoveringcolor ;
      private int gxdynajaxindex ;
      private int subStselecvacante_grid2_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV14vacantes_IdRec ;
      private int bttStselecvacante_postularse_Visible ;
      private int bttStselecvacante_declinar_Visible ;
      private int tblStselecvacante_table3_Bordercolor ;
      private int tblStselecvacante_table3_Backcolor ;
      private int idxLst ;
      private int subStselecvacante_grid2_Backcolor ;
      private int subStselecvacante_grid2_Allbackcolor ;
      private long STSELECVACANTE_GRID2_nFirstRecordOnPage ;
      private long STSELECVACANTE_GRID2_nCurrentRecord ;
      private long STSELECVACANTE_GRID2_nRecordCount ;
      private decimal A267Vacantes_Sueldo ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sPrefix ;
      private String sCompPrefix ;
      private String sSFPrefix ;
      private String sGXsfl_25_idx="0001" ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GXEncryptionTmp ;
      private String GX_FocusControl ;
      private String divMaintable_Internalname ;
      private String lblTitletext_Internalname ;
      private String lblTitletext_Jsonclick ;
      private String edtavVacantes_nombre_Internalname ;
      private String TempTags ;
      private String edtavVacantes_nombre_Jsonclick ;
      private String ClassString ;
      private String StyleString ;
      private String sImgUrl ;
      private String imgImage2_Internalname ;
      private String imgImage2_Jsonclick ;
      private String imgImage1_Internalname ;
      private String imgImage1_Jsonclick ;
      private String divStselecvacante_Internalname ;
      private String sStyleString ;
      private String subStselecvacante_grid2_Internalname ;
      private String subStselecvacante_grid2_Header ;
      private String lblStselecvacante_textblock1_Caption ;
      private String Ucalertas_Internalname ;
      private String sXEvt ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtVacantes_Nombre_Internalname ;
      private String edtVacantes_Sueldo_Internalname ;
      private String edtVacantes_Id_Internalname ;
      private String edtVacantes_Descripcion_Internalname ;
      private String GXDecQS ;
      private String gxwrpcisep ;
      private String scmdbuf ;
      private String bttStselecvacante_postularse_Internalname ;
      private String bttStselecvacante_declinar_Internalname ;
      private String tblStselecvacante_table3_Internalname ;
      private String sCtrlAV12UsuariosId ;
      private String lblStselecvacante_textblock1_Internalname ;
      private String sGXsfl_25_fel_idx="0001" ;
      private String subStselecvacante_grid2_Class ;
      private String subStselecvacante_grid2_Linesclass ;
      private String divStselecvacante_grid2table1_Internalname ;
      private String ROClassString ;
      private String edtVacantes_Nombre_Jsonclick ;
      private String edtVacantes_Sueldo_Jsonclick ;
      private String edtVacantes_Id_Jsonclick ;
      private String bttStselecvacante_postularse_Jsonclick ;
      private String bttStselecvacante_declinar_Jsonclick ;
      private String lblStselecvacante_textblock1_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_25_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private String A264Vacantes_Nombre ;
      private String AV15Vacantes_Nombre ;
      private String A274Vacantes_Descripcion ;
      private String l264Vacantes_Nombre ;
      private String lV15Vacantes_Nombre ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Stselecvacante_grid2Container ;
      private GXWebRow Stselecvacante_grid2Row ;
      private GXWebColumn Stselecvacante_grid2Column ;
      private GXUserControl ucUcalertas ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private String[] H002Y2_A264Vacantes_Nombre ;
      private int[] H002Y3_A263Vacantes_Id ;
      private short[] H002Y3_A265Vacantes_Status ;
      private String[] H002Y3_A274Vacantes_Descripcion ;
      private decimal[] H002Y3_A267Vacantes_Sueldo ;
      private String[] H002Y3_A264Vacantes_Nombre ;
      private long[] H002Y4_ASTSELECVACANTE_GRID2_nRecordCount ;
      private int[] H002Y5_A263Vacantes_Id ;
      private short[] H002Y5_A273UsuariosVacanteEstatus ;
      private int[] H002Y5_A11UsuariosId ;
      private short[] H002Y6_A273UsuariosVacanteEstatus ;
      private int[] H002Y6_A263Vacantes_Id ;
      private int[] H002Y6_A11UsuariosId ;
      private int[] H002Y6_A284SUBT_ReclutadorId ;
      private int[] H002Y7_A263Vacantes_Id ;
      private short[] H002Y7_A273UsuariosVacanteEstatus ;
      private int[] H002Y7_A11UsuariosId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private SdtPropiedades AV5AlertProperties ;
      private SdtPropiedades GXt_SdtPropiedades1 ;
   }

   public class wpselvacanteregistro__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002Y3( IGxContext context ,
                                             String AV15Vacantes_Nombre ,
                                             String A264Vacantes_Nombre ,
                                             short A265Vacantes_Status )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int2 ;
         GXv_int2 = new short [3] ;
         Object[] GXv_Object3 ;
         GXv_Object3 = new Object [2] ;
         String sSelectString ;
         String sFromString ;
         String sOrderString ;
         sSelectString = " `Vacantes_Id`, `Vacantes_Status`, `Vacantes_Descripcion`, `Vacantes_Sueldo`, `Vacantes_Nombre`";
         sFromString = " FROM `Vacantes`";
         sOrderString = "";
         sWhereString = sWhereString + " WHERE (`Vacantes_Status` = 1)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15Vacantes_Nombre)) )
         {
            sWhereString = sWhereString + " and (`Vacantes_Nombre` like CONCAT(CONCAT('%', ?), '%'))";
         }
         else
         {
            GXv_int2[0] = 1;
         }
         sOrderString = sOrderString + " ORDER BY `Vacantes_Id`";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " LIMIT " + "?" + ", " + "?";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_H002Y4( IGxContext context ,
                                             String AV15Vacantes_Nombre ,
                                             String A264Vacantes_Nombre ,
                                             short A265Vacantes_Status )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int4 ;
         GXv_int4 = new short [1] ;
         Object[] GXv_Object5 ;
         GXv_Object5 = new Object [2] ;
         scmdbuf = "SELECT COUNT(*) FROM `Vacantes`";
         scmdbuf = scmdbuf + " WHERE (`Vacantes_Status` = 1)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15Vacantes_Nombre)) )
         {
            sWhereString = sWhereString + " and (`Vacantes_Nombre` like CONCAT(CONCAT('%', ?), '%'))";
         }
         else
         {
            GXv_int4[0] = 1;
         }
         scmdbuf = scmdbuf + sWhereString;
         scmdbuf = scmdbuf + "";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_H002Y3(context, (String)dynConstraints[0] , (String)dynConstraints[1] , (short)dynConstraints[2] );
               case 2 :
                     return conditional_H002Y4(context, (String)dynConstraints[0] , (String)dynConstraints[1] , (short)dynConstraints[2] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH002Y2 ;
          prmH002Y2 = new Object[] {
          new Object[] {"l264Vacantes_Nombre",System.Data.DbType.String,40,0}
          } ;
          Object[] prmH002Y5 ;
          prmH002Y5 = new Object[] {
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"AV12UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmH002Y6 ;
          prmH002Y6 = new Object[] {
          new Object[] {"AV12UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmH002Y7 ;
          prmH002Y7 = new Object[] {
          new Object[] {"AV12UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmH002Y3 ;
          prmH002Y3 = new Object[] {
          new Object[] {"lV15Vacantes_Nombre",System.Data.DbType.String,40,0} ,
          new Object[] {"GXPagingFrom2",System.Data.DbType.Int32,9,0} ,
          new Object[] {"GXPagingTo2",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmH002Y4 ;
          prmH002Y4 = new Object[] {
          new Object[] {"lV15Vacantes_Nombre",System.Data.DbType.String,40,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H002Y2", "SELECT DISTINCT `Vacantes_Nombre` FROM `Vacantes` WHERE (UPPER(`Vacantes_Nombre`) like UPPER(?)) AND (`Vacantes_Status` = 1) ORDER BY `Vacantes_Nombre`  LIMIT 5",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Y2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002Y3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Y3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002Y4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Y4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002Y5", "SELECT `Vacantes_Id`, `UsuariosVacanteEstatus`, `UsuariosId` FROM `VacantesUsuariosVacante` WHERE (`Vacantes_Id` = ? and `UsuariosId` = ?) AND (`UsuariosVacanteEstatus` = 1) ORDER BY `Vacantes_Id`, `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Y5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H002Y6", "SELECT `UsuariosVacanteEstatus`, `Vacantes_Id`, `UsuariosId`, `SUBT_ReclutadorId` FROM `VacantesUsuariosVacante` WHERE (`Vacantes_Id` = 17 and `UsuariosId` = ?) AND (`UsuariosVacanteEstatus` = 0) ORDER BY `Vacantes_Id`, `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Y6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H002Y7", "SELECT `Vacantes_Id`, `UsuariosVacanteEstatus`, `UsuariosId` FROM `VacantesUsuariosVacante` WHERE (`UsuariosId` = ?) AND (`UsuariosVacanteEstatus` = 1) ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Y7,100, GxCacheFrequency.OFF ,true,false )
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
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4) ;
                ((String[]) buf[4])[0] = rslt.getVarchar(5) ;
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                ((int[]) buf[3])[0] = rslt.getInt(4) ;
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       short sIdx ;
       switch ( cursor )
       {
             case 0 :
                stmt.SetParameter(1, (String)parms[0]);
                return;
             case 1 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[3]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[4]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[5]);
                }
                return;
             case 2 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[1]);
                }
                return;
             case 3 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
             case 4 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 5 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

}
