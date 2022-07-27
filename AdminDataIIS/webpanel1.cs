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
   public class webpanel1 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public webpanel1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public webpanel1( IGxContext context )
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
         PA252( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START252( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714345036", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 2036420), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("webpanel1.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_SUBT_RECLUTADORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A284SUBT_ReclutadorId), "ZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "SUBT_RECLUTADORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A284SUBT_ReclutadorId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_SUBT_RECLUTADORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A284SUBT_ReclutadorId), "ZZZZZ9"), context));
         GXCCtlgxBlob = "vBLOB" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, AV23blob);
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
            WE252( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT252( ) ;
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
         return formatLink("webpanel1.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "WebPanel1" ;
      }

      public override String GetPgmdesc( )
      {
         return "Web Panel1" ;
      }

      protected void WB250( )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttButton_Internalname, "", "BUTTON", bttButton_Jsonclick, 5, "BUTTON", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'BUTTON\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WebPanel1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavValor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValor_Internalname, "v ALOR", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavValor_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavValor_Internalname, context.localUtil.Format(AV5vALOR, "99/99/99"), context.localUtil.Format( AV5vALOR, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,11);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavValor_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WebPanel1.htm");
            GxWebStd.gx_bitmap( context, edtavValor_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavValor_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WebPanel1.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "7d6200b0-e2a5-4d7e-8f9d-9c9767ceea34", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WebPanel1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "098e55ac-16ee-4aaf-9d49-dc22f82408fb", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WebPanel1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "c437546b-f1bf-4dfc-bbef-ae4524ef2773", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WebPanel1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 10, "px", "col-xs-12", "Center", "Middle", "", "", "div");
            wb_table1_23_252( true) ;
         }
         else
         {
            wb_table1_23_252( false) ;
         }
         return  ;
      }

      protected void wb_table1_23_252e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "Middle", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavBlob_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBlob_Internalname, "blob", "col-sm-3 ImageLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            ClassString = "Image";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            edtavBlob_Filetype = "tmp";
            AssignProp("", false, edtavBlob_Internalname, "Filetype", edtavBlob_Filetype, true);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23blob)) )
            {
               gxblobfileaux.Source = AV23blob;
               if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtavBlob_Filetype, "tmp") != 0 ) )
               {
                  gxblobfileaux.SetExtension(StringUtil.Trim( edtavBlob_Filetype));
               }
               if ( gxblobfileaux.ErrCode == 0 )
               {
                  AV23blob = gxblobfileaux.GetURI();
                  AssignProp("", false, edtavBlob_Internalname, "URL", context.PathToRelativeUrl( AV23blob), true);
                  edtavBlob_Filetype = gxblobfileaux.GetExtension();
                  AssignProp("", false, edtavBlob_Internalname, "Filetype", edtavBlob_Filetype, true);
               }
               AssignProp("", false, edtavBlob_Internalname, "URL", context.PathToRelativeUrl( AV23blob), true);
            }
            GxWebStd.gx_blob_field( context, edtavBlob_Internalname, StringUtil.RTrim( AV23blob), context.PathToRelativeUrl( AV23blob), (String.IsNullOrEmpty(StringUtil.RTrim( edtavBlob_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtavBlob_Filetype)) ? AV23blob : edtavBlob_Filetype)) : edtavBlob_Contenttype), false, "", edtavBlob_Parameters, 0, edtavBlob_Enabled, 1, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtavBlob_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", "", "HLP_WebPanel1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "49e414a3-8ee9-4e69-bdc5-a9526c95bff1", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage4_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WebPanel1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "3e997551-1e5c-4df7-9720-51b3f49ee88a", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage5_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WebPanel1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "7092c041-c11e-4ed0-a1e0-8d51474fb9d7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage6_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WebPanel1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START252( )
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
            Form.Meta.addItem("description", "Web Panel1", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP250( ) ;
      }

      protected void WS252( )
      {
         START252( ) ;
         EVT252( ) ;
      }

      protected void EVT252( )
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
                              E11252 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'BUTTON'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'BUTTON' */
                              E12252 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E13252 ();
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

      protected void WE252( )
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

      protected void PA252( )
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
               GX_FocusControl = edtavValor_Internalname;
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
         RF252( ) ;
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

      protected void RF252( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E13252 ();
            WB250( ) ;
         }
      }

      protected void send_integrity_lvl_hashes252( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP250( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11252 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtavValor_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"v ALOR"}), 1, "vVALOR");
               GX_FocusControl = edtavValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5vALOR = DateTime.MinValue;
               AssignAttri("", false, "AV5vALOR", context.localUtil.Format(AV5vALOR, "99/99/99"));
            }
            else
            {
               AV5vALOR = context.localUtil.CToD( cgiGet( edtavValor_Internalname), 2);
               AssignAttri("", false, "AV5vALOR", context.localUtil.Format(AV5vALOR, "99/99/99"));
            }
            AV13Image = cgiGet( imgavImage_Internalname);
            AV23blob = cgiGet( edtavBlob_Internalname);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23blob)) )
            {
               GXCCtlgxBlob = "vBLOB" + "_gxBlob";
               AV23blob = cgiGet( GXCCtlgxBlob);
            }
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
         E11252 ();
         if (returnInSub) return;
      }

      protected void E11252( )
      {
         /* Start Routine */
         /* Using cursor H00252 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11UsuariosId = H00252_A11UsuariosId[0];
            A40000UsuariosIcono_GXI = H00252_A40000UsuariosIcono_GXI[0];
            A245UsuariosIcono = H00252_A245UsuariosIcono[0];
            GX_msglist.addItem("entra");
            AV13Image = A245UsuariosIcono;
            AssignProp("", false, imgavImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV13Image)) ? AV27Image_GXI : context.convertURL( context.PathToRelativeUrl( AV13Image))), true);
            AssignProp("", false, imgavImage_Internalname, "SrcSet", context.GetImageSrcSet( AV13Image), true);
            AV27Image_GXI = A40000UsuariosIcono_GXI;
            AssignProp("", false, imgavImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV13Image)) ? AV27Image_GXI : context.convertURL( context.PathToRelativeUrl( AV13Image))), true);
            AssignProp("", false, imgavImage_Internalname, "SrcSet", context.GetImageSrcSet( AV13Image), true);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      protected void E12252( )
      {
         /* 'BUTTON' Routine */
         AV20sdt_Reclutador.Clear();
         /* Using cursor H00253 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK254 = false;
            A284SUBT_ReclutadorId = H00253_A284SUBT_ReclutadorId[0];
            AV18SubT_ReclutadorId = A284SUBT_ReclutadorId;
            AssignAttri("", false, "AV18SubT_ReclutadorId", StringUtil.LTrimStr( (decimal)(AV18SubT_ReclutadorId), 6, 0));
            AV17Conteo = 0;
            while ( (pr_default.getStatus(1) != 101) && ( H00253_A284SUBT_ReclutadorId[0] == A284SUBT_ReclutadorId ) )
            {
               BRK254 = false;
               if ( A284SUBT_ReclutadorId == AV18SubT_ReclutadorId )
               {
                  AV17Conteo = (short)(AV17Conteo+1);
               }
               BRK254 = true;
               pr_default.readNext(1);
            }
            AV21sdt_ReclutadorItem = new Sdtsdt_Reclutador_sdt_ReclutadorItem(context);
            AV21sdt_ReclutadorItem.gxTpr_Subt_reclutadorid = A284SUBT_ReclutadorId;
            AV21sdt_ReclutadorItem.gxTpr_Conteo = AV17Conteo;
            AV20sdt_Reclutador.Add(AV21sdt_ReclutadorItem, 0);
            if ( ! BRK254 )
            {
               BRK254 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         AV20sdt_Reclutador.Sort("conteo");
         AV30GXV1 = 1;
         while ( AV30GXV1 <= AV20sdt_Reclutador.Count )
         {
            AV21sdt_ReclutadorItem = ((Sdtsdt_Reclutador_sdt_ReclutadorItem)AV20sdt_Reclutador.Item(AV30GXV1));
            AV22ValorReclutador = (short)(AV21sdt_ReclutadorItem.gxTpr_Subt_reclutadorid);
            if (true) break;
            AV30GXV1 = (int)(AV30GXV1+1);
         }
         GX_msglist.addItem("-***---"+StringUtil.Str( (decimal)(AV22ValorReclutador), 4, 0));
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E13252( )
      {
         /* Load Routine */
      }

      protected void wb_table1_23_252( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable1_Internalname, tblTable1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+imgavImage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Image", "gx-form-item Fixed300Label", 1, true, "width: 5%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 95, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Fixed300";
            StyleString = "";
            AV13Image_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV13Image))&&String.IsNullOrEmpty(StringUtil.RTrim( AV27Image_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV13Image)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV13Image)) ? AV27Image_GXI : context.PathToRelativeUrl( AV13Image));
            GxWebStd.gx_bitmap( context, imgavImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV13Image_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_WebPanel1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_23_252e( true) ;
         }
         else
         {
            wb_table1_23_252e( false) ;
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
         PA252( ) ;
         WS252( ) ;
         WE252( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714345055", true, true);
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
         context.AddJavascriptSource("webpanel1.js", "?202262714345055", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttButton_Internalname = "BUTTON";
         edtavValor_Internalname = "vVALOR";
         imgImage1_Internalname = "IMAGE1";
         imgImage2_Internalname = "IMAGE2";
         imgImage3_Internalname = "IMAGE3";
         imgavImage_Internalname = "vIMAGE";
         tblTable1_Internalname = "TABLE1";
         edtavBlob_Internalname = "vBLOB";
         imgImage4_Internalname = "IMAGE4";
         imgImage5_Internalname = "IMAGE5";
         imgImage6_Internalname = "IMAGE6";
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
         edtavBlob_Jsonclick = "";
         edtavBlob_Parameters = "";
         edtavBlob_Contenttype = "";
         edtavBlob_Filetype = "";
         edtavBlob_Enabled = 1;
         edtavValor_Jsonclick = "";
         edtavValor_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Web Panel1";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A284SUBT_ReclutadorId',fld:'SUBT_RECLUTADORID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'BUTTON'","{handler:'E12252',iparms:[{av:'A284SUBT_ReclutadorId',fld:'SUBT_RECLUTADORID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("'BUTTON'",",oparms:[{av:'AV18SubT_ReclutadorId',fld:'vSUBT_RECLUTADORID',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALIDV_VALOR","{handler:'Validv_Valor',iparms:[]");
         setEventMetadata("VALIDV_VALOR",",oparms:[]}");
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
         GXCCtlgxBlob = "";
         AV23blob = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttButton_Jsonclick = "";
         AV5vALOR = DateTime.MinValue;
         sImgUrl = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV13Image = "";
         scmdbuf = "";
         H00252_A11UsuariosId = new int[1] ;
         H00252_A40000UsuariosIcono_GXI = new String[] {""} ;
         H00252_A245UsuariosIcono = new String[] {""} ;
         A40000UsuariosIcono_GXI = "";
         A245UsuariosIcono = "";
         AV27Image_GXI = "";
         AV20sdt_Reclutador = new GXBaseCollection<Sdtsdt_Reclutador_sdt_ReclutadorItem>( context, "sdt_ReclutadorItem", "ADMINDATA1");
         H00253_A263Vacantes_Id = new int[1] ;
         H00253_A11UsuariosId = new int[1] ;
         H00253_A284SUBT_ReclutadorId = new int[1] ;
         AV21sdt_ReclutadorItem = new Sdtsdt_Reclutador_sdt_ReclutadorItem(context);
         sStyleString = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.webpanel1__default(),
            new Object[][] {
                new Object[] {
               H00252_A11UsuariosId, H00252_A40000UsuariosIcono_GXI, H00252_A245UsuariosIcono
               }
               , new Object[] {
               H00253_A263Vacantes_Id, H00253_A11UsuariosId, H00253_A284SUBT_ReclutadorId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
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
      private short AV17Conteo ;
      private short AV22ValorReclutador ;
      private short nGXWrapped ;
      private int A284SUBT_ReclutadorId ;
      private int edtavValor_Enabled ;
      private int edtavBlob_Enabled ;
      private int A11UsuariosId ;
      private int AV18SubT_ReclutadorId ;
      private int AV30GXV1 ;
      private int idxLst ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GXCCtlgxBlob ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String TempTags ;
      private String ClassString ;
      private String StyleString ;
      private String bttButton_Internalname ;
      private String bttButton_Jsonclick ;
      private String edtavValor_Internalname ;
      private String edtavValor_Jsonclick ;
      private String sImgUrl ;
      private String imgImage1_Internalname ;
      private String imgImage2_Internalname ;
      private String imgImage3_Internalname ;
      private String edtavBlob_Internalname ;
      private String edtavBlob_Filetype ;
      private String edtavBlob_Contenttype ;
      private String edtavBlob_Parameters ;
      private String edtavBlob_Jsonclick ;
      private String imgImage4_Internalname ;
      private String imgImage5_Internalname ;
      private String imgImage6_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String imgavImage_Internalname ;
      private String scmdbuf ;
      private String sStyleString ;
      private String tblTable1_Internalname ;
      private DateTime AV5vALOR ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool BRK254 ;
      private bool AV13Image_IsBlob ;
      private String A40000UsuariosIcono_GXI ;
      private String AV27Image_GXI ;
      private String AV13Image ;
      private String A245UsuariosIcono ;
      private String AV23blob ;
      private GxFile gxblobfileaux ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H00252_A11UsuariosId ;
      private String[] H00252_A40000UsuariosIcono_GXI ;
      private String[] H00252_A245UsuariosIcono ;
      private int[] H00253_A263Vacantes_Id ;
      private int[] H00253_A11UsuariosId ;
      private int[] H00253_A284SUBT_ReclutadorId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<Sdtsdt_Reclutador_sdt_ReclutadorItem> AV20sdt_Reclutador ;
      private GXWebForm Form ;
      private Sdtsdt_Reclutador_sdt_ReclutadorItem AV21sdt_ReclutadorItem ;
   }

   public class webpanel1__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00252 ;
          prmH00252 = new Object[] {
          } ;
          Object[] prmH00253 ;
          prmH00253 = new Object[] {
          } ;
          def= new CursorDef[] {
              new CursorDef("H00252", "SELECT `UsuariosId`, `UsuariosIcono_GXI`, `UsuariosIcono` FROM `Usuarios` WHERE `UsuariosId` = 1 ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00252,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00253", "SELECT `Vacantes_Id`, `UsuariosId`, `SUBT_ReclutadorId` FROM `VacantesUsuariosVacante` ORDER BY `SUBT_ReclutadorId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00253,100, GxCacheFrequency.OFF ,true,false )
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
                ((String[]) buf[1])[0] = rslt.getMultimediaUri(2) ;
                ((String[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2)) ;
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
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
       }
    }

 }

}
