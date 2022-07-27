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
   public class wpselvacante : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpselvacante( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public wpselvacante( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_UsuariosId ,
                           String aP1_UsuariosCurp ,
                           int aP2_UsuarioReclutador )
      {
         this.AV5UsuariosId = aP0_UsuariosId;
         this.AV6UsuariosCurp = aP1_UsuariosCurp;
         this.AV18UsuarioReclutador = aP2_UsuarioReclutador;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxSuggest"+"_"+"vVACANTES_NOMBRE") == 0 )
            {
               A264Vacantes_Nombre = GetNextPar( );
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXSGVvVACANTES_NOMBRE2B0( A264Vacantes_Nombre) ;
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
               nRC_GXsfl_20 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_20_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_20_idx = GetNextPar( );
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
               AV10Vacantes_Nombre = GetNextPar( );
               A11UsuariosId = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV5UsuariosId = (int)(NumberUtil.Val( GetNextPar( ), "."));
               A273UsuariosVacanteEstatus = (short)(NumberUtil.Val( GetNextPar( ), "."));
               AV18UsuarioReclutador = (int)(NumberUtil.Val( GetNextPar( ), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrStselecvacante_grid2_refresh( AV10Vacantes_Nombre, A11UsuariosId, AV5UsuariosId, A273UsuariosVacanteEstatus, AV18UsuarioReclutador) ;
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
         PA2B2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2B2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714345073", false, true);
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
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wpselvacante.aspx"+UrlEncode("" +AV5UsuariosId) + "," + UrlEncode(StringUtil.RTrim(AV6UsuariosCurp)) + "," + UrlEncode("" +AV18UsuarioReclutador);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpselvacante.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5UsuariosId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIORECLUTADOR", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV18UsuarioReclutador), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vVACANTES_NOMBRE", AV10Vacantes_Nombre);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_20", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_20), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vALERTPROPERTIES", AV11AlertProperties);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vALERTPROPERTIES", AV11AlertProperties);
         }
         GxWebStd.gx_hidden_field( context, "USUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5UsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5UsuariosId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "USUARIOSVACANTEESTATUS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A273UsuariosVacanteEstatus), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vUSUARIORECLUTADOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18UsuarioReclutador), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIORECLUTADOR", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV18UsuarioReclutador), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vVACANTES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15vacantes_Id), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSCURP", AV6UsuariosCurp);
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
            WE2B2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2B2( ) ;
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
         GXEncryptionTmp = "wpselvacante.aspx"+UrlEncode("" +AV5UsuariosId) + "," + UrlEncode(StringUtil.RTrim(AV6UsuariosCurp)) + "," + UrlEncode("" +AV18UsuarioReclutador);
         return formatLink("wpselvacante.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override String GetPgmname( )
      {
         return "wpSelVacante" ;
      }

      public override String GetPgmdesc( )
      {
         return "wp Candidatos" ;
      }

      protected void WB2B0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, "Vacantes", "", "", lblTitletext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SubTitle", 0, "", 1, 1, 0, "HLP_wpSelVacante.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavVacantes_nombre_Internalname, "Nombre", "col-sm-3 FilterSearchAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'" + sGXsfl_20_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVacantes_nombre_Internalname, AV10Vacantes_Nombre, StringUtil.RTrim( context.localUtil.Format( AV10Vacantes_Nombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,9);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Nombre", edtavVacantes_nombre_Jsonclick, 0, "FilterSearchAttribute", "", "", "", "", 1, edtavVacantes_nombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, 0, 0, true, "", "left", true, "", "HLP_wpSelVacante.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblViellall_Internalname, "Candidato", "", "", lblViellall_Jsonclick, "'"+""+"'"+",false,"+"'"+"e112b1_client"+"'", "", "BtnTextBlockBack", 7, "", 1, 1, 0, "HLP_wpSelVacante.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
               context.WriteHtmlText( "<div id=\""+"Stselecvacante_grid2Container"+"DivS\" data-gxgridid=\"20\">") ;
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
               Stselecvacante_grid2Container.AddObjectProperty("CmpContext", "");
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
         if ( wbEnd == 20 )
         {
            wbEnd = 0;
            nRC_GXsfl_20 = (int)(nGXsfl_20_idx-1);
            if ( Stselecvacante_grid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Stselecvacante_grid2Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Stselecvacante_grid2", Stselecvacante_grid2Container);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Stselecvacante_grid2ContainerData", Stselecvacante_grid2Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Stselecvacante_grid2ContainerData"+"V", Stselecvacante_grid2Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Stselecvacante_grid2ContainerData"+"V"+"\" value='"+Stselecvacante_grid2Container.GridValuesHidden()+"'/>") ;
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
            ucUcalertas.SetProperty("Propiedades", AV11AlertProperties);
            ucUcalertas.Render(context, "sweetalert2", Ucalertas_Internalname, "UCALERTASContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 20 )
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
                  context.WriteHtmlText( "<div id=\""+"Stselecvacante_grid2Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Stselecvacante_grid2", Stselecvacante_grid2Container);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Stselecvacante_grid2ContainerData", Stselecvacante_grid2Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Stselecvacante_grid2ContainerData"+"V", Stselecvacante_grid2Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Stselecvacante_grid2ContainerData"+"V"+"\" value='"+Stselecvacante_grid2Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2B2( )
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
         STRUP2B0( ) ;
      }

      protected void WS2B2( )
      {
         START2B2( ) ;
         EVT2B2( ) ;
      }

      protected void EVT2B2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "UCALERTAS.ACCEPT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E122B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'POSTULARSE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Postularse' */
                              E132B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DECLINAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Declinar' */
                              E142B2 ();
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 25), "STSELECVACANTE_GRID2.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "'POSTULARSE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'DECLINAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_20_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
                              SubsflControlProps_202( ) ;
                              A264Vacantes_Nombre = cgiGet( edtVacantes_Nombre_Internalname);
                              A267Vacantes_Sueldo = context.localUtil.CToN( cgiGet( edtVacantes_Sueldo_Internalname), ",", ".");
                              A263Vacantes_Id = (int)(context.localUtil.CToN( cgiGet( edtVacantes_Id_Internalname), ",", "."));
                              A274Vacantes_Descripcion = cgiGet( edtVacantes_Descripcion_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "STSELECVACANTE_GRID2.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E152B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'POSTULARSE'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Postularse' */
                                    E132B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DECLINAR'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Declinar' */
                                    E142B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Vacantes_nombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vVACANTES_NOMBRE"), AV10Vacantes_Nombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE2B2( )
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

      protected void PA2B2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpselvacante.aspx")), "wpselvacante.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpselvacante.aspx")))) ;
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
                     AV5UsuariosId = (int)(NumberUtil.Val( gxfirstwebparm, "."));
                     AssignAttri("", false, "AV5UsuariosId", StringUtil.LTrimStr( (decimal)(AV5UsuariosId), 6, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5UsuariosId), "ZZZZZ9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV6UsuariosCurp = GetNextPar( );
                        AssignAttri("", false, "AV6UsuariosCurp", AV6UsuariosCurp);
                        AV18UsuarioReclutador = (int)(NumberUtil.Val( GetNextPar( ), "."));
                        AssignAttri("", false, "AV18UsuarioReclutador", StringUtil.LTrimStr( (decimal)(AV18UsuarioReclutador), 9, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIORECLUTADOR", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV18UsuarioReclutador), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavVacantes_nombre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXSGVvVACANTES_NOMBRE2B0( String A264Vacantes_Nombre )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXSGVvVACANTES_NOMBRE_data2B0( A264Vacantes_Nombre) ;
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

      protected void GXSGVvVACANTES_NOMBRE_data2B0( String A264Vacantes_Nombre )
      {
         l264Vacantes_Nombre = StringUtil.Concat( StringUtil.RTrim( A264Vacantes_Nombre), "%", "");
         /* Using cursor H002B2 */
         pr_default.execute(0, new Object[] {l264Vacantes_Nombre});
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(H002B2_A264Vacantes_Nombre[0]);
            gxdynajaxctrldescr.Add(H002B2_A264Vacantes_Nombre[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrStselecvacante_grid2_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_202( ) ;
         while ( nGXsfl_20_idx <= nRC_GXsfl_20 )
         {
            sendrow_202( ) ;
            nGXsfl_20_idx = ((subStselecvacante_grid2_Islastpage==1)&&(nGXsfl_20_idx+1>subStselecvacante_grid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_20_idx+1);
            sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
            SubsflControlProps_202( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Stselecvacante_grid2Container)) ;
         /* End function gxnrStselecvacante_grid2_newrow */
      }

      protected void gxgrStselecvacante_grid2_refresh( String AV10Vacantes_Nombre ,
                                                       int A11UsuariosId ,
                                                       int AV5UsuariosId ,
                                                       short A273UsuariosVacanteEstatus ,
                                                       int AV18UsuarioReclutador )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         STSELECVACANTE_GRID2_nCurrentRecord = 0;
         RF2B2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrStselecvacante_grid2_refresh */
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
         RF2B2( ) ;
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

      protected void RF2B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Stselecvacante_grid2Container.ClearRows();
         }
         wbStart = 20;
         nGXsfl_20_idx = 1;
         sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
         SubsflControlProps_202( ) ;
         bGXsfl_20_Refreshing = true;
         Stselecvacante_grid2Container.AddObjectProperty("GridName", "Stselecvacante_grid2");
         Stselecvacante_grid2Container.AddObjectProperty("CmpContext", "");
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
            SubsflControlProps_202( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV10Vacantes_Nombre ,
                                                 A264Vacantes_Nombre ,
                                                 A265Vacantes_Status } ,
                                                 new int[]{
                                                 TypeConstants.STRING, TypeConstants.STRING, TypeConstants.SHORT
                                                 }
            } ) ;
            lV10Vacantes_Nombre = StringUtil.Concat( StringUtil.RTrim( AV10Vacantes_Nombre), "%", "");
            /* Using cursor H002B3 */
            pr_default.execute(1, new Object[] {lV10Vacantes_Nombre});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A263Vacantes_Id = H002B3_A263Vacantes_Id[0];
               A265Vacantes_Status = H002B3_A265Vacantes_Status[0];
               A274Vacantes_Descripcion = H002B3_A274Vacantes_Descripcion[0];
               A267Vacantes_Sueldo = H002B3_A267Vacantes_Sueldo[0];
               A264Vacantes_Nombre = H002B3_A264Vacantes_Nombre[0];
               E152B2 ();
               pr_default.readNext(1);
            }
            pr_default.close(1);
            wbEnd = 20;
            WB2B0( ) ;
         }
         bGXsfl_20_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2B2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_VACANTES_ID"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sGXsfl_20_idx, context.localUtil.Format( (decimal)(A263Vacantes_Id), "ZZZZZZZZ9"), context));
      }

      protected int subStselecvacante_grid2_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subStselecvacante_grid2_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subStselecvacante_grid2_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subStselecvacante_grid2_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP2B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vALERTPROPERTIES"), AV11AlertProperties);
            /* Read saved values. */
            nRC_GXsfl_20 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_20"), ",", "."));
            /* Read variables values. */
            AV10Vacantes_Nombre = cgiGet( edtavVacantes_nombre_Internalname);
            AssignAttri("", false, "AV10Vacantes_Nombre", AV10Vacantes_Nombre);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      private void E152B2( )
      {
         /* Stselecvacante_grid2_Load Routine */
         edtVacantes_Id_Visible = 0;
         /* Using cursor H002B4 */
         pr_default.execute(2, new Object[] {A263Vacantes_Id, AV5UsuariosId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A273UsuariosVacanteEstatus = H002B4_A273UsuariosVacanteEstatus[0];
            A11UsuariosId = H002B4_A11UsuariosId[0];
            AV16vacantes_IdRec = A263Vacantes_Id;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         if ( A263Vacantes_Id == AV16vacantes_IdRec )
         {
            bttStselecvacante_postularse_Visible = 0;
            AssignProp("", false, bttStselecvacante_postularse_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttStselecvacante_postularse_Visible), 5, 0), !bGXsfl_20_Refreshing);
            bttStselecvacante_declinar_Visible = 1;
            AssignProp("", false, bttStselecvacante_declinar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttStselecvacante_declinar_Visible), 5, 0), !bGXsfl_20_Refreshing);
            tblStselecvacante_table3_Bordercolor = GXUtil.RGB( 119, 221, 119);
            tblStselecvacante_table3_Backcolor = GXUtil.RGB( 242, 253, 245);
            AssignProp("", false, tblStselecvacante_table3_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(tblStselecvacante_table3_Backcolor), 9, 0), !bGXsfl_20_Refreshing);
         }
         else
         {
            bttStselecvacante_postularse_Visible = 1;
            AssignProp("", false, bttStselecvacante_postularse_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttStselecvacante_postularse_Visible), 5, 0), !bGXsfl_20_Refreshing);
            bttStselecvacante_declinar_Visible = 0;
            AssignProp("", false, bttStselecvacante_declinar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttStselecvacante_declinar_Visible), 5, 0), !bGXsfl_20_Refreshing);
            tblStselecvacante_table3_Bordercolor = GXUtil.RGB( 132, 182, 244);
            tblStselecvacante_table3_Backcolor = GXUtil.RGB( 0, 0, 0);
            AssignProp("", false, tblStselecvacante_table3_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(tblStselecvacante_table3_Backcolor), 9, 0), !bGXsfl_20_Refreshing);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 20;
         }
         sendrow_202( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_20_Refreshing )
         {
            context.DoAjaxLoad(20, Stselecvacante_grid2Row);
         }
         /*  Sending Event outputs  */
      }

      protected void E132B2( )
      {
         /* 'Postularse' Routine */
         AV15vacantes_Id = A263Vacantes_Id;
         AssignAttri("", false, "AV15vacantes_Id", StringUtil.LTrimStr( (decimal)(AV15vacantes_Id), 9, 0));
         /* Execute user subroutine: 'BUSCAVACANTEUUSARIOS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11AlertProperties", AV11AlertProperties);
      }

      protected void E142B2( )
      {
         /* 'Declinar' Routine */
         AV15vacantes_Id = A263Vacantes_Id;
         AssignAttri("", false, "AV15vacantes_Id", StringUtil.LTrimStr( (decimal)(AV15vacantes_Id), 9, 0));
         new pr_guardavacanteusuario(context ).execute(  AV5UsuariosId,  AV15vacantes_Id,  "Declinar",  AV18UsuarioReclutador) ;
         GXt_SdtPropiedades1 = AV11AlertProperties;
         new getsweetmessage(context ).execute(  "success",  "Información Modificada Exitosamente",  "",  true,  false, out  GXt_SdtPropiedades1) ;
         AV11AlertProperties = GXt_SdtPropiedades1;
         this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11AlertProperties", AV11AlertProperties);
      }

      protected void E122B2( )
      {
         /* Ucalertas_Accept Routine */
         new pr_guardavacanteusuario(context ).execute(  AV5UsuariosId,  AV15vacantes_Id,  "Postularse",  AV18UsuarioReclutador) ;
         GXt_SdtPropiedades1 = AV11AlertProperties;
         new getsweetmessage(context ).execute(  "success",  "Información Guardada Exitosamente",  "",  true,  false, out  GXt_SdtPropiedades1) ;
         AV11AlertProperties = GXt_SdtPropiedades1;
         this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11AlertProperties", AV11AlertProperties);
      }

      protected void S112( )
      {
         /* 'BUSCAVACANTEUUSARIOS' Routine */
         AV17Contador = 0;
         AV22GXLvl56 = 0;
         /* Using cursor H002B5 */
         pr_default.execute(3, new Object[] {AV5UsuariosId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A273UsuariosVacanteEstatus = H002B5_A273UsuariosVacanteEstatus[0];
            A11UsuariosId = H002B5_A11UsuariosId[0];
            AV22GXLvl56 = 1;
            AV17Contador = (short)(AV17Contador+1);
            if ( AV17Contador >= 2 )
            {
               GXt_SdtPropiedades1 = AV11AlertProperties;
               new getsweetmessage(context ).execute(  "error",  "No puede postularse a mas de 2 vacantes",  "",  true,  false, out  GXt_SdtPropiedades1) ;
               AV11AlertProperties = GXt_SdtPropiedades1;
               this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
               context.DoAjaxRefresh();
            }
            else
            {
               /* Execute user subroutine: 'ALERTAS' */
               S124 ();
               if ( returnInSub )
               {
                  pr_default.close(3);
                  returnInSub = true;
                  if (true) return;
               }
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
         if ( AV22GXLvl56 == 0 )
         {
            /* Execute user subroutine: 'ALERTAS' */
            S124 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void S124( )
      {
         /* 'ALERTAS' Routine */
         GXt_SdtPropiedades1 = AV11AlertProperties;
         new getsweetmessage(context ).execute(  "question",  "Esta seguro de postularse en esta vacante",  "",  false,  true, out  GXt_SdtPropiedades1) ;
         AV11AlertProperties = GXt_SdtPropiedades1;
         AV11AlertProperties.gxTpr_Showconfirmbutton = true;
         AV11AlertProperties.gxTpr_Confirmbuttontext = "Aceptar";
         AV11AlertProperties.gxTpr_Confirmbuttoncolor = "rgb(76,173,76)";
         AV11AlertProperties.gxTpr_Showcancelbutton = true;
         AV11AlertProperties.gxTpr_Cancelbuttontext = "Cancelar";
         AV11AlertProperties.gxTpr_Cancelbuttoncolor = "rgb(255,105,97)";
         this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV5UsuariosId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV5UsuariosId", StringUtil.LTrimStr( (decimal)(AV5UsuariosId), 6, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5UsuariosId), "ZZZZZ9"), context));
         AV6UsuariosCurp = (String)getParm(obj,1);
         AssignAttri("", false, "AV6UsuariosCurp", AV6UsuariosCurp);
         AV18UsuarioReclutador = Convert.ToInt32(getParm(obj,2));
         AssignAttri("", false, "AV18UsuarioReclutador", StringUtil.LTrimStr( (decimal)(AV18UsuarioReclutador), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIORECLUTADOR", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV18UsuarioReclutador), "ZZZZZZZZ9"), context));
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
         PA2B2( ) ;
         WS2B2( ) ;
         WE2B2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?20226271434513", true, true);
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
            context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("wpselvacante.js", "?20226271434514", false, true);
            context.AddJavascriptSource("SweetAlert2/sweetalert2.all.min.js", "", false, true);
            context.AddJavascriptSource("SweetAlert2/SweetAlert2Render.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_202( )
      {
         edtVacantes_Nombre_Internalname = "VACANTES_NOMBRE_"+sGXsfl_20_idx;
         edtVacantes_Sueldo_Internalname = "VACANTES_SUELDO_"+sGXsfl_20_idx;
         edtVacantes_Id_Internalname = "VACANTES_ID_"+sGXsfl_20_idx;
         edtVacantes_Descripcion_Internalname = "VACANTES_DESCRIPCION_"+sGXsfl_20_idx;
         lblStselecvacante_textblock1_Internalname = "STSELECVACANTE_TEXTBLOCK1_"+sGXsfl_20_idx;
      }

      protected void SubsflControlProps_fel_202( )
      {
         edtVacantes_Nombre_Internalname = "VACANTES_NOMBRE_"+sGXsfl_20_fel_idx;
         edtVacantes_Sueldo_Internalname = "VACANTES_SUELDO_"+sGXsfl_20_fel_idx;
         edtVacantes_Id_Internalname = "VACANTES_ID_"+sGXsfl_20_fel_idx;
         edtVacantes_Descripcion_Internalname = "VACANTES_DESCRIPCION_"+sGXsfl_20_fel_idx;
         lblStselecvacante_textblock1_Internalname = "STSELECVACANTE_TEXTBLOCK1_"+sGXsfl_20_fel_idx;
      }

      protected void sendrow_202( )
      {
         SubsflControlProps_202( ) ;
         WB2B0( ) ;
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
            if ( ((int)((nGXsfl_20_idx) % (2))) == 0 )
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
            context.WriteHtmlText( "<tr"+" class=\""+subStselecvacante_grid2_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_20_idx+"\">") ;
         }
         /* Div Control */
         Stselecvacante_grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)divStselecvacante_grid2table1_Internalname+"_"+sGXsfl_20_idx,(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"Table",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         Stselecvacante_grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"row",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         Stselecvacante_grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"col-xs-12",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Table start */
         Stselecvacante_grid2Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(String)tblStselecvacante_table3_Internalname+"_"+sGXsfl_20_idx,(short)1,(String)"TablaRedondeada",(String)"",(int)tblStselecvacante_table3_Backcolor,(int)tblStselecvacante_table3_Bordercolor,(String)"",(String)"",(String)"",(short)1,(short)2,(String)"",(String)"",(String)"",(String)"px",(String)"px",(String)""});
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
         Stselecvacante_grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtVacantes_Nombre_Internalname,(String)A264Vacantes_Nombre,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtVacantes_Nombre_Jsonclick,(short)0,(String)"AttributeTitle",(String)"",(String)ROClassString,(String)"",(String)"",(short)1,(short)0,(short)0,(String)"text",(String)"",(short)40,(String)"chr",(short)1,(String)"row",(short)40,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
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
         Stselecvacante_grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtVacantes_Sueldo_Internalname,StringUtil.LTrim( StringUtil.NToC( A267Vacantes_Sueldo, 6, 3, ",", "")),context.localUtil.Format( A267Vacantes_Sueldo, "Z9.999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtVacantes_Sueldo_Jsonclick,(short)0,(String)"AttributeTitle",(String)"",(String)ROClassString,(String)"",(String)"",(short)1,(short)0,(short)0,(String)"text",(String)"",(short)6,(String)"chr",(short)1,(String)"row",(short)6,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
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
         Stselecvacante_grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtVacantes_Id_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A263Vacantes_Id), 9, 0, ",", "")),context.localUtil.Format( (decimal)(A263Vacantes_Id), "ZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtVacantes_Id_Jsonclick,(short)0,(String)"AttBlanco",(String)"",(String)ROClassString,(String)"",(String)"",(int)edtVacantes_Id_Visible,(short)0,(short)0,(String)"number",(String)"1",(short)9,(String)"chr",(short)1,(String)"row",(short)9,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)0,(bool)true,(String)"Id",(String)"right",(bool)false,(String)""});
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
         Stselecvacante_grid2Row.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(String)edtVacantes_Descripcion_Internalname,(String)A274Vacantes_Descripcion,(String)"",(String)"",(short)0,(short)1,(short)0,(short)0,(short)80,(String)"chr",(short)10,(String)"row",(String)StyleString,(String)ClassString,(String)"",(String)"",(String)"1000",(short)-1,(short)0,(String)"",(String)"",(short)-1,(bool)true,(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(short)0});
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         Stselecvacante_grid2Row.AddColumnProperties("button", 2, isAjaxCallMode( ), new Object[] {(String)bttStselecvacante_postularse_Internalname+"_"+sGXsfl_20_idx,"gx.evt.setGridEvt("+StringUtil.Str( (decimal)(20), 2, 0)+","+"null"+");",(String)"Postularse",(String)bttStselecvacante_postularse_Jsonclick,(short)5,(String)"Postularse",(String)"",(String)StyleString,(String)ClassString,(int)bttStselecvacante_postularse_Visible,(short)1,(String)"standard","'"+""+"'"+",false,"+"'"+"E\\'POSTULARSE\\'."+"'",(String)TempTags,(String)"",context.GetButtonType( )});
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         Stselecvacante_grid2Row.AddColumnProperties("button", 2, isAjaxCallMode( ), new Object[] {(String)bttStselecvacante_declinar_Internalname+"_"+sGXsfl_20_idx,"gx.evt.setGridEvt("+StringUtil.Str( (decimal)(20), 2, 0)+","+"null"+");",(String)"Declinar",(String)bttStselecvacante_declinar_Jsonclick,(short)5,(String)"Declinar",(String)"",(String)StyleString,(String)ClassString,(int)bttStselecvacante_declinar_Visible,(short)1,(String)"standard","'"+""+"'"+",false,"+"'"+"E\\'DECLINAR\\'."+"'",(String)TempTags,(String)"",context.GetButtonType( )});
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
         sendrow_20230( ) ;
      }

      protected void sendrow_20230( )
      {
         /* Text block */
         Stselecvacante_grid2Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(String)lblStselecvacante_textblock1_Internalname,".",(String)"",(String)"",(String)lblStselecvacante_textblock1_Jsonclick,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"BigTitle1",(short)0,(String)"",(short)1,(short)1,(short)0});
         Stselecvacante_grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"Center",(String)"top",(String)"div"});
         Stselecvacante_grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         Stselecvacante_grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         send_integrity_lvl_hashes2B2( ) ;
         /* End of Columns property logic. */
         Stselecvacante_grid2Container.AddRow(Stselecvacante_grid2Row);
         nGXsfl_20_idx = ((subStselecvacante_grid2_Islastpage==1)&&(nGXsfl_20_idx+1>subStselecvacante_grid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_20_idx+1);
         sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
         SubsflControlProps_202( ) ;
         /* End function sendrow_202 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitletext_Internalname = "TITLETEXT";
         edtavVacantes_nombre_Internalname = "vVACANTES_NOMBRE";
         lblViellall_Internalname = "VIELLALL";
         edtVacantes_Nombre_Internalname = "VACANTES_NOMBRE";
         edtVacantes_Sueldo_Internalname = "VACANTES_SUELDO";
         edtVacantes_Id_Internalname = "VACANTES_ID";
         edtVacantes_Descripcion_Internalname = "VACANTES_DESCRIPCION";
         bttStselecvacante_postularse_Internalname = "STSELECVACANTE_POSTULARSE";
         bttStselecvacante_declinar_Internalname = "STSELECVACANTE_DECLINAR";
         tblStselecvacante_table3_Internalname = "STSELECVACANTE_TABLE3";
         lblStselecvacante_textblock1_Internalname = "STSELECVACANTE_TEXTBLOCK1";
         divStselecvacante_grid2table1_Internalname = "STSELECVACANTE_GRID2TABLE1";
         divStselecvacante_Internalname = "STSELECVACANTE";
         Ucalertas_Internalname = "UCALERTAS";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subStselecvacante_grid2_Internalname = "STSELECVACANTE_GRID2";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "wp Candidatos";
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'STSELECVACANTE_GRID2_nFirstRecordOnPage'},{av:'STSELECVACANTE_GRID2_nEOF'},{av:'AV10Vacantes_Nombre',fld:'vVACANTES_NOMBRE',pic:''},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A273UsuariosVacanteEstatus',fld:'USUARIOSVACANTEESTATUS',pic:'9'},{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true},{av:'AV18UsuarioReclutador',fld:'vUSUARIORECLUTADOR',pic:'ZZZZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("STSELECVACANTE_GRID2.LOAD","{handler:'E152B2',iparms:[{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true},{av:'A273UsuariosVacanteEstatus',fld:'USUARIOSVACANTEESTATUS',pic:'9'},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9',hsh:true}]");
         setEventMetadata("STSELECVACANTE_GRID2.LOAD",",oparms:[{av:'edtVacantes_Id_Visible',ctrl:'VACANTES_ID',prop:'Visible'},{ctrl:'STSELECVACANTE_POSTULARSE',prop:'Visible'},{ctrl:'STSELECVACANTE_DECLINAR',prop:'Visible'},{av:'tblStselecvacante_table3_Bordercolor',ctrl:'STSELECVACANTE_TABLE3',prop:'Bordercolor'},{av:'tblStselecvacante_table3_Backcolor',ctrl:'STSELECVACANTE_TABLE3',prop:'Backcolor'}]}");
         setEventMetadata("'POSTULARSE'","{handler:'E132B2',iparms:[{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9',hsh:true},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true},{av:'A273UsuariosVacanteEstatus',fld:'USUARIOSVACANTEESTATUS',pic:'9'}]");
         setEventMetadata("'POSTULARSE'",",oparms:[{av:'AV15vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV11AlertProperties',fld:'vALERTPROPERTIES',pic:''}]}");
         setEventMetadata("'DECLINAR'","{handler:'E142B2',iparms:[{av:'STSELECVACANTE_GRID2_nFirstRecordOnPage'},{av:'STSELECVACANTE_GRID2_nEOF'},{av:'AV10Vacantes_Nombre',fld:'vVACANTES_NOMBRE',pic:''},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true},{av:'A273UsuariosVacanteEstatus',fld:'USUARIOSVACANTEESTATUS',pic:'9'},{av:'AV18UsuarioReclutador',fld:'vUSUARIORECLUTADOR',pic:'ZZZZZZZZ9',hsh:true},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'DECLINAR'",",oparms:[{av:'AV15vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV11AlertProperties',fld:'vALERTPROPERTIES',pic:''}]}");
         setEventMetadata("UCALERTAS.ACCEPT","{handler:'E122B2',iparms:[{av:'STSELECVACANTE_GRID2_nFirstRecordOnPage'},{av:'STSELECVACANTE_GRID2_nEOF'},{av:'AV10Vacantes_Nombre',fld:'vVACANTES_NOMBRE',pic:''},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true},{av:'A273UsuariosVacanteEstatus',fld:'USUARIOSVACANTEESTATUS',pic:'9'},{av:'AV18UsuarioReclutador',fld:'vUSUARIORECLUTADOR',pic:'ZZZZZZZZ9',hsh:true},{av:'AV15vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("UCALERTAS.ACCEPT",",oparms:[{av:'AV11AlertProperties',fld:'vALERTPROPERTIES',pic:''}]}");
         setEventMetadata("'PROSPECTOS'","{handler:'E112B1',iparms:[]");
         setEventMetadata("'PROSPECTOS'",",oparms:[]}");
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
         wcpOAV6UsuariosCurp = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A264Vacantes_Nombre = "";
         AV10Vacantes_Nombre = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV11AlertProperties = new SdtPropiedades(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitletext_Jsonclick = "";
         TempTags = "";
         lblViellall_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         Stselecvacante_grid2Container = new GXWebGrid( context);
         sStyleString = "";
         subStselecvacante_grid2_Header = "";
         Stselecvacante_grid2Column = new GXWebColumn();
         A274Vacantes_Descripcion = "";
         ucUcalertas = new GXUserControl();
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
         H002B2_A264Vacantes_Nombre = new String[] {""} ;
         lV10Vacantes_Nombre = "";
         H002B3_A263Vacantes_Id = new int[1] ;
         H002B3_A265Vacantes_Status = new short[1] ;
         H002B3_A274Vacantes_Descripcion = new String[] {""} ;
         H002B3_A267Vacantes_Sueldo = new decimal[1] ;
         H002B3_A264Vacantes_Nombre = new String[] {""} ;
         H002B4_A263Vacantes_Id = new int[1] ;
         H002B4_A273UsuariosVacanteEstatus = new short[1] ;
         H002B4_A11UsuariosId = new int[1] ;
         Stselecvacante_grid2Row = new GXWebRow();
         H002B5_A263Vacantes_Id = new int[1] ;
         H002B5_A273UsuariosVacanteEstatus = new short[1] ;
         H002B5_A11UsuariosId = new int[1] ;
         GXt_SdtPropiedades1 = new SdtPropiedades(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subStselecvacante_grid2_Linesclass = "";
         ROClassString = "";
         bttStselecvacante_postularse_Jsonclick = "";
         bttStselecvacante_declinar_Jsonclick = "";
         lblStselecvacante_textblock1_Jsonclick = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpselvacante__default(),
            new Object[][] {
                new Object[] {
               H002B2_A264Vacantes_Nombre
               }
               , new Object[] {
               H002B3_A263Vacantes_Id, H002B3_A265Vacantes_Status, H002B3_A274Vacantes_Descripcion, H002B3_A267Vacantes_Sueldo, H002B3_A264Vacantes_Nombre
               }
               , new Object[] {
               H002B4_A263Vacantes_Id, H002B4_A273UsuariosVacanteEstatus, H002B4_A11UsuariosId
               }
               , new Object[] {
               H002B5_A263Vacantes_Id, H002B5_A273UsuariosVacanteEstatus, H002B5_A11UsuariosId
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
      private short A273UsuariosVacanteEstatus ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short subStselecvacante_grid2_Backcolorstyle ;
      private short subStselecvacante_grid2_Allowselection ;
      private short subStselecvacante_grid2_Allowhovering ;
      private short subStselecvacante_grid2_Allowcollapsing ;
      private short subStselecvacante_grid2_Collapsed ;
      private short nDonePA ;
      private short A265Vacantes_Status ;
      private short STSELECVACANTE_GRID2_nEOF ;
      private short AV17Contador ;
      private short AV22GXLvl56 ;
      private short subStselecvacante_grid2_Backstyle ;
      private int AV5UsuariosId ;
      private int AV18UsuarioReclutador ;
      private int wcpOAV5UsuariosId ;
      private int wcpOAV18UsuarioReclutador ;
      private int nRC_GXsfl_20 ;
      private int nGXsfl_20_idx=1 ;
      private int A11UsuariosId ;
      private int AV15vacantes_Id ;
      private int edtavVacantes_nombre_Enabled ;
      private int A263Vacantes_Id ;
      private int edtVacantes_Id_Visible ;
      private int subStselecvacante_grid2_Selectedindex ;
      private int subStselecvacante_grid2_Selectioncolor ;
      private int subStselecvacante_grid2_Hoveringcolor ;
      private int gxdynajaxindex ;
      private int subStselecvacante_grid2_Islastpage ;
      private int AV16vacantes_IdRec ;
      private int bttStselecvacante_postularse_Visible ;
      private int bttStselecvacante_declinar_Visible ;
      private int tblStselecvacante_table3_Bordercolor ;
      private int tblStselecvacante_table3_Backcolor ;
      private int idxLst ;
      private int subStselecvacante_grid2_Backcolor ;
      private int subStselecvacante_grid2_Allbackcolor ;
      private long STSELECVACANTE_GRID2_nCurrentRecord ;
      private long STSELECVACANTE_GRID2_nFirstRecordOnPage ;
      private decimal A267Vacantes_Sueldo ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_20_idx="0001" ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GXEncryptionTmp ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String lblTitletext_Internalname ;
      private String lblTitletext_Jsonclick ;
      private String edtavVacantes_nombre_Internalname ;
      private String TempTags ;
      private String edtavVacantes_nombre_Jsonclick ;
      private String lblViellall_Internalname ;
      private String lblViellall_Jsonclick ;
      private String ClassString ;
      private String StyleString ;
      private String divStselecvacante_Internalname ;
      private String sStyleString ;
      private String subStselecvacante_grid2_Internalname ;
      private String subStselecvacante_grid2_Header ;
      private String lblStselecvacante_textblock1_Caption ;
      private String Ucalertas_Internalname ;
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
      private String lblStselecvacante_textblock1_Internalname ;
      private String sGXsfl_20_fel_idx="0001" ;
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
      private bool bGXsfl_20_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private String AV6UsuariosCurp ;
      private String wcpOAV6UsuariosCurp ;
      private String A264Vacantes_Nombre ;
      private String AV10Vacantes_Nombre ;
      private String A274Vacantes_Descripcion ;
      private String l264Vacantes_Nombre ;
      private String lV10Vacantes_Nombre ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Stselecvacante_grid2Container ;
      private GXWebRow Stselecvacante_grid2Row ;
      private GXWebColumn Stselecvacante_grid2Column ;
      private GXUserControl ucUcalertas ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private String[] H002B2_A264Vacantes_Nombre ;
      private int[] H002B3_A263Vacantes_Id ;
      private short[] H002B3_A265Vacantes_Status ;
      private String[] H002B3_A274Vacantes_Descripcion ;
      private decimal[] H002B3_A267Vacantes_Sueldo ;
      private String[] H002B3_A264Vacantes_Nombre ;
      private int[] H002B4_A263Vacantes_Id ;
      private short[] H002B4_A273UsuariosVacanteEstatus ;
      private int[] H002B4_A11UsuariosId ;
      private int[] H002B5_A263Vacantes_Id ;
      private short[] H002B5_A273UsuariosVacanteEstatus ;
      private int[] H002B5_A11UsuariosId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private SdtPropiedades AV11AlertProperties ;
      private SdtPropiedades GXt_SdtPropiedades1 ;
   }

   public class wpselvacante__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002B3( IGxContext context ,
                                             String AV10Vacantes_Nombre ,
                                             String A264Vacantes_Nombre ,
                                             short A265Vacantes_Status )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int2 ;
         GXv_int2 = new short [1] ;
         Object[] GXv_Object3 ;
         GXv_Object3 = new Object [2] ;
         scmdbuf = "SELECT `Vacantes_Id`, `Vacantes_Status`, `Vacantes_Descripcion`, `Vacantes_Sueldo`, `Vacantes_Nombre` FROM `Vacantes`";
         scmdbuf = scmdbuf + " WHERE (`Vacantes_Status` = 1)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Vacantes_Nombre)) )
         {
            sWhereString = sWhereString + " and (`Vacantes_Nombre` like CONCAT(CONCAT('%', ?), '%'))";
         }
         else
         {
            GXv_int2[0] = 1;
         }
         scmdbuf = scmdbuf + sWhereString;
         scmdbuf = scmdbuf + " ORDER BY `Vacantes_Id`";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_H002B3(context, (String)dynConstraints[0] , (String)dynConstraints[1] , (short)dynConstraints[2] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002B2 ;
          prmH002B2 = new Object[] {
          new Object[] {"l264Vacantes_Nombre",System.Data.DbType.String,40,0}
          } ;
          Object[] prmH002B4 ;
          prmH002B4 = new Object[] {
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"AV5UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmH002B5 ;
          prmH002B5 = new Object[] {
          new Object[] {"AV5UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmH002B3 ;
          prmH002B3 = new Object[] {
          new Object[] {"lV10Vacantes_Nombre",System.Data.DbType.String,40,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H002B2", "SELECT DISTINCT `Vacantes_Nombre` FROM `Vacantes` WHERE (UPPER(`Vacantes_Nombre`) like UPPER(?)) AND (`Vacantes_Status` = 1) ORDER BY `Vacantes_Nombre`  LIMIT 5",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002B2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002B3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002B3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002B4", "SELECT `Vacantes_Id`, `UsuariosVacanteEstatus`, `UsuariosId` FROM `VacantesUsuariosVacante` WHERE (`Vacantes_Id` = ? and `UsuariosId` = ?) AND (`UsuariosVacanteEstatus` = 1) ORDER BY `Vacantes_Id`, `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002B4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H002B5", "SELECT `Vacantes_Id`, `UsuariosVacanteEstatus`, `UsuariosId` FROM `VacantesUsuariosVacante` WHERE (`UsuariosId` = ?) AND (`UsuariosVacanteEstatus` = 1) ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002B5,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                return;
             case 3 :
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
                   stmt.SetParameter(sIdx, (String)parms[1]);
                }
                return;
             case 2 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
             case 3 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

}
