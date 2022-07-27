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
   public class popcargdocu : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public popcargdocu( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public popcargdocu( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_UsuariosId ,
                           int aP1_Vacantes_Id ,
                           short aP2_Estatus_Filtro )
      {
         this.AV17UsuariosId = aP0_UsuariosId;
         this.AV22Vacantes_Id = aP1_Vacantes_Id;
         this.AV25Estatus_Filtro = aP2_Estatus_Filtro;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         radavOpdoc = new GXRadio();
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
         PA342( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START342( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714345581", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         GXEncryptionTmp = "popcargdocu.aspx"+UrlEncode("" +AV17UsuariosId) + "," + UrlEncode("" +AV22Vacantes_Id) + "," + UrlEncode("" +AV25Estatus_Filtro);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("popcargdocu.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vRUTA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11ruta, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSCURP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV19UsuariosCurp, "@!")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17UsuariosId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vVACANTES_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22Vacantes_Id), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vESTATUS_FILTRO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV25Estatus_Filtro), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUPLOADEDFILES", AV6UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUPLOADEDFILES", AV6UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vALERTPROPERTIES", AV23AlertProperties);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vALERTPROPERTIES", AV23AlertProperties);
         }
         GxWebStd.gx_hidden_field( context, "vARCHIVO", AV9archivo);
         GxWebStd.gx_hidden_field( context, "vVACANTES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22Vacantes_Id), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vVACANTES_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22Vacantes_Id), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17UsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17UsuariosId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vESTATUS_FILTRO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25Estatus_Filtro), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vESTATUS_FILTRO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV25Estatus_Filtro), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vRUTA", AV11ruta);
         GxWebStd.gx_hidden_field( context, "gxhash_vRUTA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11ruta, "")), context));
         GxWebStd.gx_hidden_field( context, "vVARDOC", StringUtil.RTrim( AV21VarDoc));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSCURP", AV19UsuariosCurp);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSCURP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV19UsuariosCurp, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vRUTAGUARDADA", AV20RutaGuardada);
         GxWebStd.gx_hidden_field( context, "FILEUPLOAD1_Maxnumberoffiles", StringUtil.LTrim( StringUtil.NToC( (decimal)(Fileupload1_Maxnumberoffiles), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILEUPLOAD1_Acceptedfiletypes", StringUtil.RTrim( Fileupload1_Acceptedfiletypes));
         GxWebStd.gx_hidden_field( context, "FILEUPLOAD1_Customfiletypes", StringUtil.RTrim( Fileupload1_Customfiletypes));
         GxWebStd.gx_hidden_field( context, "vOPDOC_Caption", StringUtil.RTrim( radavOpdoc.Caption));
         GxWebStd.gx_hidden_field( context, "vOPDOC_Caption", StringUtil.RTrim( radavOpdoc.Caption));
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
            WE342( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT342( ) ;
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
         GXEncryptionTmp = "popcargdocu.aspx"+UrlEncode("" +AV17UsuariosId) + "," + UrlEncode("" +AV22Vacantes_Id) + "," + UrlEncode("" +AV25Estatus_Filtro);
         return formatLink("popcargdocu.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override String GetPgmname( )
      {
         return "popCargDocu" ;
      }

      public override String GetPgmdesc( )
      {
         return "Home" ;
      }

      protected void WB340( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "TableTopSearch", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 50, "px", "col-xs-6 col-sm-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Documento a Cargar", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_popCargDocu.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "La información debera ser cargada en formato ( .pdf ), No importa el tamaño del archivo.", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_popCargDocu.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            wb_table1_18_342( true) ;
         }
         else
         {
            wb_table1_18_342( false) ;
         }
         return  ;
      }

      protected void wb_table1_18_342e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "Right", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "d0e5d738-d4cd-4148-98b7-bf2166bc1ffa", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Guardar Pdf", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'GUARDAR\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_popCargDocu.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "93b2d7e5-9a13-41d9-baee-ede2124078b4", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Regresar", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REGRESAR\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_popCargDocu.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "Middle", "", "", "div");
            /* User Defined Control */
            ucUcalertas.SetProperty("Propiedades", AV23AlertProperties);
            ucUcalertas.Render(context, "sweetalert2", Ucalertas_Internalname, "UCALERTASContainer");
            GxWebStd.gx_div_end( context, "Center", "Middle", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START342( )
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
            Form.Meta.addItem("description", "Home", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP340( ) ;
      }

      protected void WS342( )
      {
         START342( ) ;
         EVT342( ) ;
      }

      protected void EVT342( )
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
                              E11342 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REGRESAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Regresar' */
                              E12342 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'GUARDAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Guardar' */
                              E13342 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'VISUALIZAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Visualizar' */
                              E14342 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E15342 ();
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

      protected void WE342( )
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

      protected void PA342( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "popcargdocu.aspx")), "popcargdocu.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "popcargdocu.aspx")))) ;
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
                     AV17UsuariosId = (int)(NumberUtil.Val( gxfirstwebparm, "."));
                     AssignAttri("", false, "AV17UsuariosId", StringUtil.LTrimStr( (decimal)(AV17UsuariosId), 6, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17UsuariosId), "ZZZZZ9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV22Vacantes_Id = (int)(NumberUtil.Val( GetNextPar( ), "."));
                        AssignAttri("", false, "AV22Vacantes_Id", StringUtil.LTrimStr( (decimal)(AV22Vacantes_Id), 9, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vVACANTES_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22Vacantes_Id), "ZZZZZZZZ9"), context));
                        AV25Estatus_Filtro = (short)(NumberUtil.Val( GetNextPar( ), "."));
                        AssignAttri("", false, "AV25Estatus_Filtro", StringUtil.LTrimStr( (decimal)(AV25Estatus_Filtro), 4, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vESTATUS_FILTRO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV25Estatus_Filtro), "ZZZ9"), context));
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
         AV7opDoc = (short)(context.localUtil.CToN( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7opDoc), 1, 0, ".", "")), ",", "."));
         AssignAttri("", false, "AV7opDoc", StringUtil.Str( (decimal)(AV7opDoc), 1, 0));
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF342( ) ;
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

      protected void RF342( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E15342 ();
            WB340( ) ;
         }
      }

      protected void send_integrity_lvl_hashes342( )
      {
         GxWebStd.gx_hidden_field( context, "vRUTA", AV11ruta);
         GxWebStd.gx_hidden_field( context, "gxhash_vRUTA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11ruta, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSCURP", AV19UsuariosCurp);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSCURP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV19UsuariosCurp, "@!")), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP340( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11342 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vUPLOADEDFILES"), AV6UploadedFiles);
            ajax_req_read_hidden_sdt(cgiGet( "vALERTPROPERTIES"), AV23AlertProperties);
            /* Read saved values. */
            Fileupload1_Maxnumberoffiles = (int)(context.localUtil.CToN( cgiGet( "FILEUPLOAD1_Maxnumberoffiles"), ",", "."));
            Fileupload1_Acceptedfiletypes = cgiGet( "FILEUPLOAD1_Acceptedfiletypes");
            Fileupload1_Customfiletypes = cgiGet( "FILEUPLOAD1_Customfiletypes");
            radavOpdoc.Caption = cgiGet( "vOPDOC_Caption");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( radavOpdoc_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( radavOpdoc_Internalname), ",", ".") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOPDOC");
               wbErr = true;
               AV7opDoc = 0;
               AssignAttri("", false, "AV7opDoc", StringUtil.Str( (decimal)(AV7opDoc), 1, 0));
            }
            else
            {
               AV7opDoc = (short)(context.localUtil.CToN( cgiGet( radavOpdoc_Internalname), ",", "."));
               AssignAttri("", false, "AV7opDoc", StringUtil.Str( (decimal)(AV7opDoc), 1, 0));
            }
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
         E11342 ();
         if (returnInSub) return;
      }

      protected void E11342( )
      {
         /* Start Routine */
         tblTable6_Visible = 0;
         AssignProp("", false, tblTable6_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTable6_Visible), 5, 0), true);
         lblTextblock1_Visible = 0;
         AssignProp("", false, lblTextblock1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTextblock1_Visible), 5, 0), true);
         /* Using cursor H00342 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29ParametroId = H00342_A29ParametroId[0];
            A129ParametroValor = H00342_A129ParametroValor[0];
            AV11ruta = A129ParametroValor;
            AssignAttri("", false, "AV11ruta", AV11ruta);
            GxWebStd.gx_hidden_field( context, "gxhash_vRUTA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11ruta, "")), context));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor H00343 */
         pr_default.execute(1, new Object[] {AV17UsuariosId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A11UsuariosId = H00343_A11UsuariosId[0];
            A105UsuariosCurp = H00343_A105UsuariosCurp[0];
            AV19UsuariosCurp = A105UsuariosCurp;
            AssignAttri("", false, "AV19UsuariosCurp", AV19UsuariosCurp);
            GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSCURP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV19UsuariosCurp, "@!")), context));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         if ( AV25Estatus_Filtro == 0 )
         {
            radavOpdoc.addItem("1", "Prefiltro", 0);
            radavOpdoc.addItem("2", "Curriculum Vitae", 0);
            /* Execute user subroutine: 'CARGO' */
            S112 ();
            if (returnInSub) return;
         }
         else if ( AV25Estatus_Filtro == 1 )
         {
            radavOpdoc.addItem("1", "Prefiltro", 0);
            radavOpdoc.addItem("2", "Curriculum Vitae", 0);
            radavOpdoc.addItem("3", "Examen Técnico", 0);
            /* Execute user subroutine: 'CARGO' */
            S112 ();
            if (returnInSub) return;
         }
         else if ( AV25Estatus_Filtro == 2 )
         {
            radavOpdoc.addItem("1", "Prefiltro", 0);
            radavOpdoc.addItem("2", "Curriculum Vitae", 0);
            radavOpdoc.addItem("3", "Examen Técnico", 0);
            radavOpdoc.addItem("4", "Aviso Confidencialidad", 0);
            radavOpdoc.addItem("5", "Aviso Privacidad", 0);
            radavOpdoc.addItem("6", "Busqueda Web", 0);
            radavOpdoc.addItem("7", "Referencia", 0);
            radavOpdoc.addItem("8", "Examen Psicologico", 0);
            radavOpdoc.addItem("9", "CV Recortado", 0);
            /* Execute user subroutine: 'CARGO' */
            S112 ();
            if (returnInSub) return;
         }
      }

      protected void E12342( )
      {
         /* 'Regresar' Routine */
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E13342( )
      {
         /* 'Guardar' Routine */
         if ( (0==AV7opDoc) )
         {
            GXt_SdtPropiedades1 = AV23AlertProperties;
            new getsweetmessage(context ).execute(  "error",  "Seleccione el Tipo de Archivo",  "",  true,  false, out  GXt_SdtPropiedades1) ;
            AV23AlertProperties = GXt_SdtPropiedades1;
            this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
         }
         else
         {
            if ( AV7opDoc == 1 )
            {
               AV21VarDoc = "PREF_";
               AssignAttri("", false, "AV21VarDoc", AV21VarDoc);
               /* Execute user subroutine: 'GUARDAIMAGEN' */
               S122 ();
               if (returnInSub) return;
               new pr_actualizavacante(context ).execute(  AV17UsuariosId,  AV22Vacantes_Id,  1, ref  AV9archivo) ;
               AssignAttri("", false, "AV9archivo", AV9archivo);
            }
            else if ( AV7opDoc == 2 )
            {
               AV21VarDoc = "CV_";
               AssignAttri("", false, "AV21VarDoc", AV21VarDoc);
               /* Execute user subroutine: 'GUARDAIMAGEN' */
               S122 ();
               if (returnInSub) return;
               new pr_actualizavacante(context ).execute(  AV17UsuariosId,  AV22Vacantes_Id,  2, ref  AV9archivo) ;
               AssignAttri("", false, "AV9archivo", AV9archivo);
            }
            else if ( AV7opDoc == 3 )
            {
               AV21VarDoc = "EX_TEC_";
               AssignAttri("", false, "AV21VarDoc", AV21VarDoc);
               /* Execute user subroutine: 'GUARDAIMAGEN' */
               S122 ();
               if (returnInSub) return;
               new pr_actualizavacante(context ).execute(  AV17UsuariosId,  AV22Vacantes_Id,  3, ref  AV9archivo) ;
               AssignAttri("", false, "AV9archivo", AV9archivo);
            }
            else if ( AV7opDoc == 4 )
            {
               AV21VarDoc = "AV_CONF_";
               AssignAttri("", false, "AV21VarDoc", AV21VarDoc);
               /* Execute user subroutine: 'GUARDAIMAGEN' */
               S122 ();
               if (returnInSub) return;
               new pr_actualizavacante(context ).execute(  AV17UsuariosId,  AV22Vacantes_Id,  4, ref  AV9archivo) ;
               AssignAttri("", false, "AV9archivo", AV9archivo);
            }
            else if ( AV7opDoc == 5 )
            {
               AV21VarDoc = "AV_PRIV_";
               AssignAttri("", false, "AV21VarDoc", AV21VarDoc);
               /* Execute user subroutine: 'GUARDAIMAGEN' */
               S122 ();
               if (returnInSub) return;
               new pr_actualizavacante(context ).execute(  AV17UsuariosId,  AV22Vacantes_Id,  5, ref  AV9archivo) ;
               AssignAttri("", false, "AV9archivo", AV9archivo);
            }
            else if ( AV7opDoc == 6 )
            {
               AV21VarDoc = "BUS_WEB_";
               AssignAttri("", false, "AV21VarDoc", AV21VarDoc);
               /* Execute user subroutine: 'GUARDAIMAGEN' */
               S122 ();
               if (returnInSub) return;
               new pr_actualizavacante(context ).execute(  AV17UsuariosId,  AV22Vacantes_Id,  6, ref  AV9archivo) ;
               AssignAttri("", false, "AV9archivo", AV9archivo);
            }
            else if ( AV7opDoc == 7 )
            {
               AV21VarDoc = "REF_";
               AssignAttri("", false, "AV21VarDoc", AV21VarDoc);
               /* Execute user subroutine: 'GUARDAIMAGEN' */
               S122 ();
               if (returnInSub) return;
               new pr_actualizavacante(context ).execute(  AV17UsuariosId,  AV22Vacantes_Id,  7, ref  AV9archivo) ;
               AssignAttri("", false, "AV9archivo", AV9archivo);
            }
            else if ( AV7opDoc == 8 )
            {
               AV21VarDoc = "EX_PSICO_";
               AssignAttri("", false, "AV21VarDoc", AV21VarDoc);
               /* Execute user subroutine: 'GUARDAIMAGEN' */
               S122 ();
               if (returnInSub) return;
               new pr_actualizavacante(context ).execute(  AV17UsuariosId,  AV22Vacantes_Id,  8, ref  AV9archivo) ;
               AssignAttri("", false, "AV9archivo", AV9archivo);
            }
            else if ( AV7opDoc == 9 )
            {
               AV21VarDoc = "CV_R_";
               AssignAttri("", false, "AV21VarDoc", AV21VarDoc);
               /* Execute user subroutine: 'GUARDAIMAGEN' */
               S122 ();
               if (returnInSub) return;
               new pr_actualizavacante(context ).execute(  AV17UsuariosId,  AV22Vacantes_Id,  9, ref  AV9archivo) ;
               AssignAttri("", false, "AV9archivo", AV9archivo);
            }
            CallWebObject(formatLink("wppantallacero.aspx") + "?" + UrlEncode("" +AV22Vacantes_Id) + "," + UrlEncode("" +3) + "," + UrlEncode("" +AV17UsuariosId) + "," + UrlEncode("" +AV25Estatus_Filtro));
            context.wjLocDisableFrm = 1;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23AlertProperties", AV23AlertProperties);
      }

      protected void E14342( )
      {
         /* 'Visualizar' Routine */
         if ( (0==AV7opDoc) )
         {
            GXt_SdtPropiedades1 = AV23AlertProperties;
            new getsweetmessage(context ).execute(  "error",  "Seleccione el Tipo de Archivo",  "",  true,  false, out  GXt_SdtPropiedades1) ;
            AV23AlertProperties = GXt_SdtPropiedades1;
            this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
         }
         else
         {
            if ( AV7opDoc == 1 )
            {
               GXt_char2 = AV20RutaGuardada;
               new pr_recdocvacante(context ).execute(  AV17UsuariosId,  AV22Vacantes_Id,  1, out  GXt_char2) ;
               AV20RutaGuardada = GXt_char2;
               AssignAttri("", false, "AV20RutaGuardada", AV20RutaGuardada);
            }
            else if ( AV7opDoc == 2 )
            {
               GXt_char2 = AV20RutaGuardada;
               new pr_recdocvacante(context ).execute(  AV17UsuariosId,  AV22Vacantes_Id,  2, out  GXt_char2) ;
               AV20RutaGuardada = GXt_char2;
               AssignAttri("", false, "AV20RutaGuardada", AV20RutaGuardada);
            }
            else if ( AV7opDoc == 3 )
            {
               GXt_char2 = AV20RutaGuardada;
               new pr_recdocvacante(context ).execute(  AV17UsuariosId,  AV22Vacantes_Id,  3, out  GXt_char2) ;
               AV20RutaGuardada = GXt_char2;
               AssignAttri("", false, "AV20RutaGuardada", AV20RutaGuardada);
            }
            else if ( AV7opDoc == 4 )
            {
               GXt_char2 = AV20RutaGuardada;
               new pr_recdocvacante(context ).execute(  AV17UsuariosId,  AV22Vacantes_Id,  4, out  GXt_char2) ;
               AV20RutaGuardada = GXt_char2;
               AssignAttri("", false, "AV20RutaGuardada", AV20RutaGuardada);
            }
            else if ( AV7opDoc == 5 )
            {
               GXt_char2 = AV20RutaGuardada;
               new pr_recdocvacante(context ).execute(  AV17UsuariosId,  AV22Vacantes_Id,  5, out  GXt_char2) ;
               AV20RutaGuardada = GXt_char2;
               AssignAttri("", false, "AV20RutaGuardada", AV20RutaGuardada);
            }
            else if ( AV7opDoc == 6 )
            {
               GXt_char2 = AV20RutaGuardada;
               new pr_recdocvacante(context ).execute(  AV17UsuariosId,  AV22Vacantes_Id,  6, out  GXt_char2) ;
               AV20RutaGuardada = GXt_char2;
               AssignAttri("", false, "AV20RutaGuardada", AV20RutaGuardada);
            }
            else if ( AV7opDoc == 7 )
            {
               GXt_char2 = AV20RutaGuardada;
               new pr_recdocvacante(context ).execute(  AV17UsuariosId,  AV22Vacantes_Id,  7, out  GXt_char2) ;
               AV20RutaGuardada = GXt_char2;
               AssignAttri("", false, "AV20RutaGuardada", AV20RutaGuardada);
            }
            else if ( AV7opDoc == 8 )
            {
               GXt_char2 = AV20RutaGuardada;
               new pr_recdocvacante(context ).execute(  AV17UsuariosId,  AV22Vacantes_Id,  8, out  GXt_char2) ;
               AV20RutaGuardada = GXt_char2;
               AssignAttri("", false, "AV20RutaGuardada", AV20RutaGuardada);
            }
            else if ( AV7opDoc == 9 )
            {
               GXt_char2 = AV20RutaGuardada;
               new pr_recdocvacante(context ).execute(  AV17UsuariosId,  AV22Vacantes_Id,  9, out  GXt_char2) ;
               AV20RutaGuardada = GXt_char2;
               AssignAttri("", false, "AV20RutaGuardada", AV20RutaGuardada);
            }
            AV15FullPathFile = AV20RutaGuardada;
            AV16NombreArchivo = radavOpdoc.Caption + ".pdf";
            context.PopUp(formatLink("aviewpdf.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV16NombreArchivo)) + "," + UrlEncode(StringUtil.RTrim(AV15FullPathFile)), new Object[] {});
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23AlertProperties", AV23AlertProperties);
      }

      protected void S122( )
      {
         /* 'GUARDAIMAGEN' Routine */
         AV30GXV1 = 1;
         while ( AV30GXV1 <= AV6UploadedFiles.Count )
         {
            AV5FileUploadData = ((SdtFileUploadData)AV6UploadedFiles.Item(AV30GXV1));
            AV8File.Source = AV5FileUploadData.gxTpr_File;
            AV9archivo = AV11ruta + AV21VarDoc + AV19UsuariosCurp + ".pdf";
            AssignAttri("", false, "AV9archivo", AV9archivo);
            AV8File.Copy(AV9archivo);
            AV30GXV1 = (int)(AV30GXV1+1);
         }
      }

      protected void S112( )
      {
         /* 'CARGO' Routine */
         /* Using cursor H00344 */
         pr_default.execute(2, new Object[] {AV22Vacantes_Id, AV17UsuariosId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A11UsuariosId = H00344_A11UsuariosId[0];
            A263Vacantes_Id = H00344_A263Vacantes_Id[0];
            A290VacantesUsuariosEstatus = H00344_A290VacantesUsuariosEstatus[0];
            n290VacantesUsuariosEstatus = H00344_n290VacantesUsuariosEstatus[0];
            A291VacantesUsuariosPrefiltro = H00344_A291VacantesUsuariosPrefiltro[0];
            n291VacantesUsuariosPrefiltro = H00344_n291VacantesUsuariosPrefiltro[0];
            A292VacantesUsuariosCV = H00344_A292VacantesUsuariosCV[0];
            n292VacantesUsuariosCV = H00344_n292VacantesUsuariosCV[0];
            A293VacantesUsuariosExTec = H00344_A293VacantesUsuariosExTec[0];
            n293VacantesUsuariosExTec = H00344_n293VacantesUsuariosExTec[0];
            A304VacantesUsuariosAvConf = H00344_A304VacantesUsuariosAvConf[0];
            n304VacantesUsuariosAvConf = H00344_n304VacantesUsuariosAvConf[0];
            A303VacantesUsuariosAvPriv = H00344_A303VacantesUsuariosAvPriv[0];
            n303VacantesUsuariosAvPriv = H00344_n303VacantesUsuariosAvPriv[0];
            A302VacantesUsuariosBusWeb = H00344_A302VacantesUsuariosBusWeb[0];
            n302VacantesUsuariosBusWeb = H00344_n302VacantesUsuariosBusWeb[0];
            A300VacantesUsuariosRefLab = H00344_A300VacantesUsuariosRefLab[0];
            n300VacantesUsuariosRefLab = H00344_n300VacantesUsuariosRefLab[0];
            A301VacantesUsuariosExPsi = H00344_A301VacantesUsuariosExPsi[0];
            n301VacantesUsuariosExPsi = H00344_n301VacantesUsuariosExPsi[0];
            A299VacantesUsuariosCVRec = H00344_A299VacantesUsuariosCVRec[0];
            n299VacantesUsuariosCVRec = H00344_n299VacantesUsuariosCVRec[0];
            if ( A290VacantesUsuariosEstatus == 0 )
            {
               if ( A291VacantesUsuariosPrefiltro == 1 )
               {
                  imgImage3_Visible = 1;
                  AssignProp("", false, imgImage3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage3_Visible), 5, 0), true);
               }
               else
               {
                  imgImage3_Visible = 0;
                  AssignProp("", false, imgImage3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage3_Visible), 5, 0), true);
               }
               if ( A292VacantesUsuariosCV == 1 )
               {
                  imgImage4_Visible = 1;
                  AssignProp("", false, imgImage4_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage4_Visible), 5, 0), true);
               }
               else
               {
                  imgImage4_Visible = 0;
                  AssignProp("", false, imgImage4_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage4_Visible), 5, 0), true);
               }
               imgImage5_Visible = 0;
               AssignProp("", false, imgImage5_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage5_Visible), 5, 0), true);
               imgImage6_Visible = 0;
               AssignProp("", false, imgImage6_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage6_Visible), 5, 0), true);
               imgImage7_Visible = 0;
               AssignProp("", false, imgImage7_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage7_Visible), 5, 0), true);
               imgImage8_Visible = 0;
               AssignProp("", false, imgImage8_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage8_Visible), 5, 0), true);
               imgImage9_Visible = 0;
               AssignProp("", false, imgImage9_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage9_Visible), 5, 0), true);
               imgImage10_Visible = 0;
               AssignProp("", false, imgImage10_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage10_Visible), 5, 0), true);
               imgImage11_Visible = 0;
               AssignProp("", false, imgImage11_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage11_Visible), 5, 0), true);
            }
            else if ( A290VacantesUsuariosEstatus == 1 )
            {
               imgImage3_Visible = 1;
               AssignProp("", false, imgImage3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage3_Visible), 5, 0), true);
               imgImage4_Visible = 1;
               AssignProp("", false, imgImage4_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage4_Visible), 5, 0), true);
               if ( A293VacantesUsuariosExTec == 1 )
               {
                  imgImage5_Visible = 1;
                  AssignProp("", false, imgImage5_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage5_Visible), 5, 0), true);
               }
               else
               {
                  imgImage5_Visible = 0;
                  AssignProp("", false, imgImage5_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage5_Visible), 5, 0), true);
               }
               imgImage6_Visible = 0;
               AssignProp("", false, imgImage6_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage6_Visible), 5, 0), true);
               imgImage7_Visible = 0;
               AssignProp("", false, imgImage7_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage7_Visible), 5, 0), true);
               imgImage8_Visible = 0;
               AssignProp("", false, imgImage8_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage8_Visible), 5, 0), true);
               imgImage9_Visible = 0;
               AssignProp("", false, imgImage9_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage9_Visible), 5, 0), true);
               imgImage10_Visible = 0;
               AssignProp("", false, imgImage10_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage10_Visible), 5, 0), true);
               imgImage11_Visible = 0;
               AssignProp("", false, imgImage11_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage11_Visible), 5, 0), true);
            }
            else if ( A290VacantesUsuariosEstatus == 2 )
            {
               imgImage3_Visible = 1;
               AssignProp("", false, imgImage3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage3_Visible), 5, 0), true);
               imgImage4_Visible = 1;
               AssignProp("", false, imgImage4_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage4_Visible), 5, 0), true);
               imgImage5_Visible = 1;
               AssignProp("", false, imgImage5_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage5_Visible), 5, 0), true);
               if ( A304VacantesUsuariosAvConf == 1 )
               {
                  imgImage6_Visible = 1;
                  AssignProp("", false, imgImage6_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage6_Visible), 5, 0), true);
               }
               else
               {
                  imgImage6_Visible = 0;
                  AssignProp("", false, imgImage6_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage6_Visible), 5, 0), true);
               }
               if ( A303VacantesUsuariosAvPriv == 1 )
               {
                  imgImage7_Visible = 1;
                  AssignProp("", false, imgImage7_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage7_Visible), 5, 0), true);
               }
               else
               {
                  imgImage7_Visible = 0;
                  AssignProp("", false, imgImage7_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage7_Visible), 5, 0), true);
               }
               if ( A302VacantesUsuariosBusWeb == 1 )
               {
                  imgImage8_Visible = 1;
                  AssignProp("", false, imgImage8_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage8_Visible), 5, 0), true);
               }
               else
               {
                  imgImage8_Visible = 0;
                  AssignProp("", false, imgImage8_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage8_Visible), 5, 0), true);
               }
               if ( A300VacantesUsuariosRefLab == 1 )
               {
                  imgImage9_Visible = 1;
                  AssignProp("", false, imgImage9_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage9_Visible), 5, 0), true);
               }
               else
               {
                  imgImage9_Visible = 0;
                  AssignProp("", false, imgImage9_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage9_Visible), 5, 0), true);
               }
               if ( A301VacantesUsuariosExPsi == 1 )
               {
                  imgImage10_Visible = 1;
                  AssignProp("", false, imgImage10_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage10_Visible), 5, 0), true);
               }
               else
               {
                  imgImage10_Visible = 0;
                  AssignProp("", false, imgImage10_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage10_Visible), 5, 0), true);
               }
               if ( A299VacantesUsuariosCVRec == 1 )
               {
                  imgImage11_Visible = 1;
                  AssignProp("", false, imgImage11_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage11_Visible), 5, 0), true);
               }
               else
               {
                  imgImage11_Visible = 0;
                  AssignProp("", false, imgImage11_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage11_Visible), 5, 0), true);
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
      }

      protected void nextLoad( )
      {
      }

      protected void E15342( )
      {
         /* Load Routine */
      }

      protected void wb_table1_18_342( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable2_Internalname, tblTable2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Text Block", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", lblTextblock1_Visible, 1, 0, "HLP_popCargDocu.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Visualizar", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_popCargDocu.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_26_342( true) ;
         }
         else
         {
            wb_table2_26_342( false) ;
         }
         return  ;
      }

      protected void wb_table2_26_342e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center;vertical-align:Top")+"\">") ;
            wb_table3_33_342( true) ;
         }
         else
         {
            wb_table3_33_342( false) ;
         }
         return  ;
      }

      protected void wb_table3_33_342e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center;vertical-align:Top")+"\">") ;
            wb_table4_62_342( true) ;
         }
         else
         {
            wb_table4_62_342( false) ;
         }
         return  ;
      }

      protected void wb_table4_62_342e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_18_342e( true) ;
         }
         else
         {
            wb_table1_18_342e( false) ;
         }
      }

      protected void wb_table4_62_342( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTable6_Visible == 0 )
            {
               sStyleString = sStyleString + "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTable6_Internalname, tblTable6_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center;vertical-align:Top")+"\">") ;
            /* User Defined Control */
            ucFileupload1.SetProperty("TooltipText", Fileupload1_Tooltiptext);
            ucFileupload1.SetProperty("MaxNumberOfFiles", Fileupload1_Maxnumberoffiles);
            ucFileupload1.SetProperty("AcceptedFileTypes", Fileupload1_Acceptedfiletypes);
            ucFileupload1.SetProperty("CustomFileTypes", Fileupload1_Customfiletypes);
            ucFileupload1.SetProperty("UploadedFiles", AV6UploadedFiles);
            ucFileupload1.Render(context, "fileupload", Fileupload1_Internalname, "FILEUPLOAD1Container");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_62_342e( true) ;
         }
         else
         {
            wb_table4_62_342e( false) ;
         }
      }

      protected void wb_table3_33_342( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable4_Internalname, tblTable4_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center;vertical-align:Top")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "5865f49e-c92c-4d5b-a8d4-45895fa0d0fd", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage3_Visible, 1, "", "Visualizar Prefiltro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'VISUALIZAR\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_popCargDocu.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center;vertical-align:Top")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "5865f49e-c92c-4d5b-a8d4-45895fa0d0fd", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage4_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage4_Visible, 1, "", "Visualizar  Curriculum Vitae", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage4_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'VISUALIZAR\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_popCargDocu.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center;vertical-align:Top")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "5865f49e-c92c-4d5b-a8d4-45895fa0d0fd", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage5_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage5_Visible, 1, "", "Visualizar Examen Técnico", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage5_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'VISUALIZAR\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_popCargDocu.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center;vertical-align:Top")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "5865f49e-c92c-4d5b-a8d4-45895fa0d0fd", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage6_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage6_Visible, 1, "", "Visualizar Aviso Confidencialidad", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage6_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'VISUALIZAR\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_popCargDocu.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center;vertical-align:Top")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "5865f49e-c92c-4d5b-a8d4-45895fa0d0fd", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage7_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage7_Visible, 1, "", "Visualizar Aviso Privacidad", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage7_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'VISUALIZAR\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_popCargDocu.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center;vertical-align:Top")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "5865f49e-c92c-4d5b-a8d4-45895fa0d0fd", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage8_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage8_Visible, 1, "", "Visualizar Busqueda Web", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage8_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'VISUALIZAR\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_popCargDocu.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center;vertical-align:Top")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "5865f49e-c92c-4d5b-a8d4-45895fa0d0fd", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage9_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage9_Visible, 1, "", "Visualizar Referencia", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage9_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'VISUALIZAR\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_popCargDocu.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center;vertical-align:Top")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "5865f49e-c92c-4d5b-a8d4-45895fa0d0fd", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage10_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage10_Visible, 1, "", "Visualizar Examen Psicologico", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage10_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'VISUALIZAR\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_popCargDocu.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center;vertical-align:Top")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "5865f49e-c92c-4d5b-a8d4-45895fa0d0fd", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage11_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage11_Visible, 1, "", "Visualizar CV Recortado", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage11_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'VISUALIZAR\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_popCargDocu.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_33_342e( true) ;
         }
         else
         {
            wb_table3_33_342e( false) ;
         }
      }

      protected void wb_table2_26_342( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable5_Internalname, tblTable5_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+radavOpdoc_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 95, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavOpdoc, radavOpdoc_Internalname, StringUtil.Str( (decimal)(AV7opDoc), 1, 0), "", 1, 1, 1, 1, StyleString, ClassString, "", "", 0, radavOpdoc_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,31);\"", "HLP_popCargDocu.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_26_342e( true) ;
         }
         else
         {
            wb_table2_26_342e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV17UsuariosId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV17UsuariosId", StringUtil.LTrimStr( (decimal)(AV17UsuariosId), 6, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17UsuariosId), "ZZZZZ9"), context));
         AV22Vacantes_Id = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV22Vacantes_Id", StringUtil.LTrimStr( (decimal)(AV22Vacantes_Id), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vVACANTES_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22Vacantes_Id), "ZZZZZZZZ9"), context));
         AV25Estatus_Filtro = Convert.ToInt16(getParm(obj,2));
         AssignAttri("", false, "AV25Estatus_Filtro", StringUtil.LTrimStr( (decimal)(AV25Estatus_Filtro), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vESTATUS_FILTRO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV25Estatus_Filtro), "ZZZ9"), context));
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
         PA342( ) ;
         WS342( ) ;
         WE342( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714345637", true, true);
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
         context.AddJavascriptSource("popcargdocu.js", "?202262714345637", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         context.AddJavascriptSource("SweetAlert2/sweetalert2.all.min.js", "", false, true);
         context.AddJavascriptSource("SweetAlert2/SweetAlert2Render.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         radavOpdoc.Name = "vOPDOC";
         radavOpdoc.WebTags = "";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock2_Internalname = "TEXTBLOCK2";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         divTable3_Internalname = "TABLE3";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         radavOpdoc_Internalname = "vOPDOC";
         tblTable5_Internalname = "TABLE5";
         imgImage3_Internalname = "IMAGE3";
         imgImage4_Internalname = "IMAGE4";
         imgImage5_Internalname = "IMAGE5";
         imgImage6_Internalname = "IMAGE6";
         imgImage7_Internalname = "IMAGE7";
         imgImage8_Internalname = "IMAGE8";
         imgImage9_Internalname = "IMAGE9";
         imgImage10_Internalname = "IMAGE10";
         imgImage11_Internalname = "IMAGE11";
         tblTable4_Internalname = "TABLE4";
         Fileupload1_Internalname = "FILEUPLOAD1";
         tblTable6_Internalname = "TABLE6";
         tblTable2_Internalname = "TABLE2";
         imgImage1_Internalname = "IMAGE1";
         imgImage2_Internalname = "IMAGE2";
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
         radavOpdoc_Jsonclick = "";
         imgImage11_Visible = 1;
         imgImage10_Visible = 1;
         imgImage9_Visible = 1;
         imgImage8_Visible = 1;
         imgImage7_Visible = 1;
         imgImage6_Visible = 1;
         imgImage5_Visible = 1;
         imgImage4_Visible = 1;
         imgImage3_Visible = 1;
         Fileupload1_Tooltiptext = "";
         lblTextblock1_Visible = 1;
         tblTable6_Visible = 1;
         radavOpdoc.Caption = "";
         Fileupload1_Customfiletypes = "PDF";
         Fileupload1_Acceptedfiletypes = "custom";
         Fileupload1_Maxnumberoffiles = 9;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Home";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV22Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9',hsh:true},{av:'AV17UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true},{av:'AV25Estatus_Filtro',fld:'vESTATUS_FILTRO',pic:'ZZZ9',hsh:true},{av:'AV11ruta',fld:'vRUTA',pic:'',hsh:true},{av:'AV19UsuariosCurp',fld:'vUSUARIOSCURP',pic:'@!',hsh:true},{av:'radavOpdoc'},{av:'AV7opDoc',fld:'vOPDOC',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'radavOpdoc'},{av:'AV7opDoc',fld:'vOPDOC',pic:'9'}]}");
         setEventMetadata("'REGRESAR'","{handler:'E12342',iparms:[{av:'radavOpdoc'},{av:'AV7opDoc',fld:'vOPDOC',pic:'9'}]");
         setEventMetadata("'REGRESAR'",",oparms:[{av:'radavOpdoc'},{av:'AV7opDoc',fld:'vOPDOC',pic:'9'}]}");
         setEventMetadata("'GUARDAR'","{handler:'E13342',iparms:[{av:'AV9archivo',fld:'vARCHIVO',pic:''},{av:'AV22Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9',hsh:true},{av:'AV17UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true},{av:'AV25Estatus_Filtro',fld:'vESTATUS_FILTRO',pic:'ZZZ9',hsh:true},{av:'AV6UploadedFiles',fld:'vUPLOADEDFILES',pic:''},{av:'AV11ruta',fld:'vRUTA',pic:'',hsh:true},{av:'AV21VarDoc',fld:'vVARDOC',pic:''},{av:'AV19UsuariosCurp',fld:'vUSUARIOSCURP',pic:'@!',hsh:true},{av:'radavOpdoc'},{av:'AV7opDoc',fld:'vOPDOC',pic:'9'}]");
         setEventMetadata("'GUARDAR'",",oparms:[{av:'AV23AlertProperties',fld:'vALERTPROPERTIES',pic:''},{av:'AV21VarDoc',fld:'vVARDOC',pic:''},{av:'AV9archivo',fld:'vARCHIVO',pic:''},{av:'radavOpdoc'},{av:'AV7opDoc',fld:'vOPDOC',pic:'9'}]}");
         setEventMetadata("'VISUALIZAR'","{handler:'E14342',iparms:[{av:'AV22Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9',hsh:true},{av:'AV17UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true},{av:'AV20RutaGuardada',fld:'vRUTAGUARDADA',pic:''},{av:'radavOpdoc'},{av:'AV7opDoc',fld:'vOPDOC',pic:'9'}]");
         setEventMetadata("'VISUALIZAR'",",oparms:[{av:'AV23AlertProperties',fld:'vALERTPROPERTIES',pic:''},{av:'AV20RutaGuardada',fld:'vRUTAGUARDADA',pic:''},{av:'radavOpdoc'},{av:'AV7opDoc',fld:'vOPDOC',pic:'9'}]}");
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
         GXEncryptionTmp = "";
         AV11ruta = "";
         AV19UsuariosCurp = "";
         AV6UploadedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "ADMINDATA1");
         AV23AlertProperties = new SdtPropiedades(context);
         AV9archivo = "";
         AV21VarDoc = "";
         AV20RutaGuardada = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
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
         scmdbuf = "";
         H00342_A29ParametroId = new int[1] ;
         H00342_A129ParametroValor = new String[] {""} ;
         A129ParametroValor = "";
         H00343_A11UsuariosId = new int[1] ;
         H00343_A105UsuariosCurp = new String[] {""} ;
         A105UsuariosCurp = "";
         GXt_SdtPropiedades1 = new SdtPropiedades(context);
         GXt_char2 = "";
         AV15FullPathFile = "";
         AV16NombreArchivo = "";
         AV5FileUploadData = new SdtFileUploadData(context);
         AV8File = new GxFile(context.GetPhysicalPath());
         H00344_A11UsuariosId = new int[1] ;
         H00344_A263Vacantes_Id = new int[1] ;
         H00344_A290VacantesUsuariosEstatus = new short[1] ;
         H00344_n290VacantesUsuariosEstatus = new bool[] {false} ;
         H00344_A291VacantesUsuariosPrefiltro = new short[1] ;
         H00344_n291VacantesUsuariosPrefiltro = new bool[] {false} ;
         H00344_A292VacantesUsuariosCV = new short[1] ;
         H00344_n292VacantesUsuariosCV = new bool[] {false} ;
         H00344_A293VacantesUsuariosExTec = new short[1] ;
         H00344_n293VacantesUsuariosExTec = new bool[] {false} ;
         H00344_A304VacantesUsuariosAvConf = new short[1] ;
         H00344_n304VacantesUsuariosAvConf = new bool[] {false} ;
         H00344_A303VacantesUsuariosAvPriv = new short[1] ;
         H00344_n303VacantesUsuariosAvPriv = new bool[] {false} ;
         H00344_A302VacantesUsuariosBusWeb = new short[1] ;
         H00344_n302VacantesUsuariosBusWeb = new bool[] {false} ;
         H00344_A300VacantesUsuariosRefLab = new short[1] ;
         H00344_n300VacantesUsuariosRefLab = new bool[] {false} ;
         H00344_A301VacantesUsuariosExPsi = new short[1] ;
         H00344_n301VacantesUsuariosExPsi = new bool[] {false} ;
         H00344_A299VacantesUsuariosCVRec = new short[1] ;
         H00344_n299VacantesUsuariosCVRec = new bool[] {false} ;
         sStyleString = "";
         lblTextblock1_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         ucFileupload1 = new GXUserControl();
         imgImage3_Jsonclick = "";
         imgImage4_Jsonclick = "";
         imgImage5_Jsonclick = "";
         imgImage6_Jsonclick = "";
         imgImage7_Jsonclick = "";
         imgImage8_Jsonclick = "";
         imgImage9_Jsonclick = "";
         imgImage10_Jsonclick = "";
         imgImage11_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.popcargdocu__default(),
            new Object[][] {
                new Object[] {
               H00342_A29ParametroId, H00342_A129ParametroValor
               }
               , new Object[] {
               H00343_A11UsuariosId, H00343_A105UsuariosCurp
               }
               , new Object[] {
               H00344_A11UsuariosId, H00344_A263Vacantes_Id, H00344_A290VacantesUsuariosEstatus, H00344_n290VacantesUsuariosEstatus, H00344_A291VacantesUsuariosPrefiltro, H00344_n291VacantesUsuariosPrefiltro, H00344_A292VacantesUsuariosCV, H00344_n292VacantesUsuariosCV, H00344_A293VacantesUsuariosExTec, H00344_n293VacantesUsuariosExTec,
               H00344_A304VacantesUsuariosAvConf, H00344_n304VacantesUsuariosAvConf, H00344_A303VacantesUsuariosAvPriv, H00344_n303VacantesUsuariosAvPriv, H00344_A302VacantesUsuariosBusWeb, H00344_n302VacantesUsuariosBusWeb, H00344_A300VacantesUsuariosRefLab, H00344_n300VacantesUsuariosRefLab, H00344_A301VacantesUsuariosExPsi, H00344_n301VacantesUsuariosExPsi,
               H00344_A299VacantesUsuariosCVRec, H00344_n299VacantesUsuariosCVRec
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV25Estatus_Filtro ;
      private short wcpOAV25Estatus_Filtro ;
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
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short AV7opDoc ;
      private short A290VacantesUsuariosEstatus ;
      private short A291VacantesUsuariosPrefiltro ;
      private short A292VacantesUsuariosCV ;
      private short A293VacantesUsuariosExTec ;
      private short A304VacantesUsuariosAvConf ;
      private short A303VacantesUsuariosAvPriv ;
      private short A302VacantesUsuariosBusWeb ;
      private short A300VacantesUsuariosRefLab ;
      private short A301VacantesUsuariosExPsi ;
      private short A299VacantesUsuariosCVRec ;
      private short nGXWrapped ;
      private int AV17UsuariosId ;
      private int AV22Vacantes_Id ;
      private int wcpOAV17UsuariosId ;
      private int wcpOAV22Vacantes_Id ;
      private int Fileupload1_Maxnumberoffiles ;
      private int tblTable6_Visible ;
      private int lblTextblock1_Visible ;
      private int A29ParametroId ;
      private int A11UsuariosId ;
      private int AV30GXV1 ;
      private int A263Vacantes_Id ;
      private int imgImage3_Visible ;
      private int imgImage4_Visible ;
      private int imgImage5_Visible ;
      private int imgImage6_Visible ;
      private int imgImage7_Visible ;
      private int imgImage8_Visible ;
      private int imgImage9_Visible ;
      private int imgImage10_Visible ;
      private int imgImage11_Visible ;
      private int idxLst ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GXEncryptionTmp ;
      private String AV21VarDoc ;
      private String Fileupload1_Acceptedfiletypes ;
      private String Fileupload1_Customfiletypes ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String divTable3_Internalname ;
      private String lblTextblock2_Internalname ;
      private String lblTextblock2_Jsonclick ;
      private String lblTextblock3_Internalname ;
      private String lblTextblock3_Jsonclick ;
      private String divTable1_Internalname ;
      private String TempTags ;
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
      private String radavOpdoc_Internalname ;
      private String tblTable6_Internalname ;
      private String lblTextblock1_Internalname ;
      private String scmdbuf ;
      private String GXt_char2 ;
      private String imgImage3_Internalname ;
      private String imgImage4_Internalname ;
      private String imgImage5_Internalname ;
      private String imgImage6_Internalname ;
      private String imgImage7_Internalname ;
      private String imgImage8_Internalname ;
      private String imgImage9_Internalname ;
      private String imgImage10_Internalname ;
      private String imgImage11_Internalname ;
      private String sStyleString ;
      private String tblTable2_Internalname ;
      private String lblTextblock1_Jsonclick ;
      private String lblTextblock4_Internalname ;
      private String lblTextblock4_Jsonclick ;
      private String Fileupload1_Tooltiptext ;
      private String Fileupload1_Internalname ;
      private String tblTable4_Internalname ;
      private String imgImage3_Jsonclick ;
      private String imgImage4_Jsonclick ;
      private String imgImage5_Jsonclick ;
      private String imgImage6_Jsonclick ;
      private String imgImage7_Jsonclick ;
      private String imgImage8_Jsonclick ;
      private String imgImage9_Jsonclick ;
      private String imgImage10_Jsonclick ;
      private String imgImage11_Jsonclick ;
      private String tblTable5_Internalname ;
      private String radavOpdoc_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n290VacantesUsuariosEstatus ;
      private bool n291VacantesUsuariosPrefiltro ;
      private bool n292VacantesUsuariosCV ;
      private bool n293VacantesUsuariosExTec ;
      private bool n304VacantesUsuariosAvConf ;
      private bool n303VacantesUsuariosAvPriv ;
      private bool n302VacantesUsuariosBusWeb ;
      private bool n300VacantesUsuariosRefLab ;
      private bool n301VacantesUsuariosExPsi ;
      private bool n299VacantesUsuariosCVRec ;
      private String AV11ruta ;
      private String AV19UsuariosCurp ;
      private String AV9archivo ;
      private String AV20RutaGuardada ;
      private String A129ParametroValor ;
      private String A105UsuariosCurp ;
      private String AV15FullPathFile ;
      private String AV16NombreArchivo ;
      private GXUserControl ucUcalertas ;
      private GXUserControl ucFileupload1 ;
      private IGxDataStore dsDefault ;
      private GXRadio radavOpdoc ;
      private IDataStoreProvider pr_default ;
      private int[] H00342_A29ParametroId ;
      private String[] H00342_A129ParametroValor ;
      private int[] H00343_A11UsuariosId ;
      private String[] H00343_A105UsuariosCurp ;
      private int[] H00344_A11UsuariosId ;
      private int[] H00344_A263Vacantes_Id ;
      private short[] H00344_A290VacantesUsuariosEstatus ;
      private bool[] H00344_n290VacantesUsuariosEstatus ;
      private short[] H00344_A291VacantesUsuariosPrefiltro ;
      private bool[] H00344_n291VacantesUsuariosPrefiltro ;
      private short[] H00344_A292VacantesUsuariosCV ;
      private bool[] H00344_n292VacantesUsuariosCV ;
      private short[] H00344_A293VacantesUsuariosExTec ;
      private bool[] H00344_n293VacantesUsuariosExTec ;
      private short[] H00344_A304VacantesUsuariosAvConf ;
      private bool[] H00344_n304VacantesUsuariosAvConf ;
      private short[] H00344_A303VacantesUsuariosAvPriv ;
      private bool[] H00344_n303VacantesUsuariosAvPriv ;
      private short[] H00344_A302VacantesUsuariosBusWeb ;
      private bool[] H00344_n302VacantesUsuariosBusWeb ;
      private short[] H00344_A300VacantesUsuariosRefLab ;
      private bool[] H00344_n300VacantesUsuariosRefLab ;
      private short[] H00344_A301VacantesUsuariosExPsi ;
      private bool[] H00344_n301VacantesUsuariosExPsi ;
      private short[] H00344_A299VacantesUsuariosCVRec ;
      private bool[] H00344_n299VacantesUsuariosCVRec ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtFileUploadData> AV6UploadedFiles ;
      private GxFile AV8File ;
      private GXWebForm Form ;
      private SdtFileUploadData AV5FileUploadData ;
      private SdtPropiedades AV23AlertProperties ;
      private SdtPropiedades GXt_SdtPropiedades1 ;
   }

   public class popcargdocu__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00342 ;
          prmH00342 = new Object[] {
          } ;
          Object[] prmH00343 ;
          prmH00343 = new Object[] {
          new Object[] {"AV17UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmH00344 ;
          prmH00344 = new Object[] {
          new Object[] {"AV22Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"AV17UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H00342", "SELECT `ParametroId`, `ParametroValor` FROM `Parametros` WHERE `ParametroId` = 1 ORDER BY `ParametroId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00342,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00343", "SELECT `UsuariosId`, `UsuariosCurp` FROM `Usuarios` WHERE `UsuariosId` = ? ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00343,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00344", "SELECT `UsuariosId`, `Vacantes_Id`, `VacantesUsuariosEstatus`, `VacantesUsuariosPrefiltro`, `VacantesUsuariosCV`, `VacantesUsuariosExTec`, `VacantesUsuariosAvConf`, `VacantesUsuariosAvPriv`, `VacantesUsuariosBusWeb`, `VacantesUsuariosRefLab`, `VacantesUsuariosExPsi`, `VacantesUsuariosCVRec` FROM `VacantesUsuariosVacante` WHERE (`Vacantes_Id` = ? and `UsuariosId` = ?) AND (`Vacantes_Id` <> 17) ORDER BY `Vacantes_Id`, `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00344,1, GxCacheFrequency.OFF ,false,true )
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
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((short[]) buf[6])[0] = rslt.getShort(5) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((short[]) buf[8])[0] = rslt.getShort(6) ;
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((short[]) buf[10])[0] = rslt.getShort(7) ;
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((short[]) buf[12])[0] = rslt.getShort(8) ;
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((short[]) buf[14])[0] = rslt.getShort(9) ;
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((short[]) buf[16])[0] = rslt.getShort(10) ;
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((short[]) buf[18])[0] = rslt.getShort(11) ;
                ((bool[]) buf[19])[0] = rslt.wasNull(11);
                ((short[]) buf[20])[0] = rslt.getShort(12) ;
                ((bool[]) buf[21])[0] = rslt.wasNull(12);
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
             case 2 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
       }
    }

 }

}
