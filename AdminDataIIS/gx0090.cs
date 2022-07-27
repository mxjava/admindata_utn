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
   public class gx0090 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0090( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public gx0090( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( out int aP0_pUsuariosId )
      {
         this.AV13pUsuariosId = 0 ;
         executePrivate();
         aP0_pUsuariosId=this.AV13pUsuariosId;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               nRC_GXsfl_84 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_84_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_84_idx = GetNextPar( );
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
               AV6cUsuariosId = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV7cUsuariosNombre = GetNextPar( );
               AV8cUsuariosApPat = GetNextPar( );
               AV9cUsuariosApMat = GetNextPar( );
               AV10cUsuariosUsr = GetNextPar( );
               AV11cUsuariosPwd = GetNextPar( );
               AV12cUsuariosKey = GetNextPar( );
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuariosId, AV7cUsuariosNombre, AV8cUsuariosApPat, AV9cUsuariosApMat, AV10cUsuariosUsr, AV11cUsuariosPwd, AV12cUsuariosKey) ;
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV13pUsuariosId = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV13pUsuariosId", StringUtil.LTrimStr( (decimal)(AV13pUsuariosId), 6, 0));
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdpromptmasterpage", "GeneXus.Programs.rwdpromptmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,true);
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
         PA1E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1E2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20226271435293", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0090.aspx") + "?" + UrlEncode("" +AV13pUsuariosId)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cUsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOSNOMBRE", AV7cUsuariosNombre);
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOSAPPAT", AV8cUsuariosApPat);
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOSAPMAT", AV9cUsuariosApMat);
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOSUSR", AV10cUsuariosUsr);
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOSPWD", AV11cUsuariosPwd);
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOSKEY", AV12cUsuariosKey);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPUSUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pUsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOSIDFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariosidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOSNOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariosnombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOSAPPATFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariosappatfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOSAPMATFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariosapmatfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOSUSRFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariosusrfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOSPWDFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariospwdfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOSKEYFILTERCONTAINER_Class", StringUtil.RTrim( divUsuarioskeyfiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
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
            WE1E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1E2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("gx0090.aspx") + "?" + UrlEncode("" +AV13pUsuariosId) ;
      }

      public override String GetPgmname( )
      {
         return "Gx0090" ;
      }

      public override String GetPgmdesc( )
      {
         return "Selection List Tabla de usuarios" ;
      }

      protected void WB1E0( )
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
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUsuariosidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuariosidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuariosidfilter_Internalname, "ID", "", "", lblLblusuariosidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e111e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuariosid_Internalname, "Clave de usuario", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuariosid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cUsuariosId), 6, 0, ",", "")), ((edtavCusuariosid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV6cUsuariosId), "ZZZZZ9")) : context.localUtil.Format( (decimal)(AV6cUsuariosId), "ZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuariosid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuariosid_Visible, edtavCusuariosid_Enabled, 0, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, divUsuariosnombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuariosnombrefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuariosnombrefilter_Internalname, "Nombre", "", "", lblLblusuariosnombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e121e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuariosnombre_Internalname, "Nombre de Usuario", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuariosnombre_Internalname, AV7cUsuariosNombre, StringUtil.RTrim( context.localUtil.Format( AV7cUsuariosNombre, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuariosnombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuariosnombre_Visible, edtavCusuariosnombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, divUsuariosappatfiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuariosappatfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuariosappatfilter_Internalname, "Primer Apellido", "", "", lblLblusuariosappatfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e131e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuariosappat_Internalname, "Apellido Paterno del Usuario", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuariosappat_Internalname, AV8cUsuariosApPat, StringUtil.RTrim( context.localUtil.Format( AV8cUsuariosApPat, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuariosappat_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuariosappat_Visible, edtavCusuariosappat_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, divUsuariosapmatfiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuariosapmatfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuariosapmatfilter_Internalname, "Segundo Apellido", "", "", lblLblusuariosapmatfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e141e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuariosapmat_Internalname, "Apellido Materno del Usuario", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuariosapmat_Internalname, AV9cUsuariosApMat, StringUtil.RTrim( context.localUtil.Format( AV9cUsuariosApMat, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuariosapmat_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuariosapmat_Visible, edtavCusuariosapmat_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, divUsuariosusrfiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuariosusrfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuariosusrfilter_Internalname, "Usuario", "", "", lblLblusuariosusrfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e151e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuariosusr_Internalname, "Usuarios Usr", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuariosusr_Internalname, AV10cUsuariosUsr, StringUtil.RTrim( context.localUtil.Format( AV10cUsuariosUsr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuariosusr_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuariosusr_Visible, edtavCusuariosusr_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, divUsuariospwdfiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuariospwdfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuariospwdfilter_Internalname, "Contraseña del usuario", "", "", lblLblusuariospwdfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e161e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuariospwd_Internalname, "Contraseña del usuario", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuariospwd_Internalname, AV11cUsuariosPwd, StringUtil.RTrim( context.localUtil.Format( AV11cUsuariosPwd, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuariospwd_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuariospwd_Visible, edtavCusuariospwd_Enabled, 0, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, divUsuarioskeyfiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuarioskeyfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuarioskeyfilter_Internalname, "Llave para encriptar password", "", "", lblLblusuarioskeyfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e171e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuarioskey_Internalname, "Llave para encriptar password", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuarioskey_Internalname, AV12cUsuariosKey, StringUtil.RTrim( context.localUtil.Format( AV12cUsuariosKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuarioskey_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuarioskey_Visible, edtavCusuarioskey_Enabled, 0, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e181e1_client"+"'", TempTags, "", 2, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Clave de usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Apellido Paterno") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Usuario") ;
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
               Grid1Container.AddObjectProperty("Class", "PromptGrid");
               Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("CmpContext", "");
               Grid1Container.AddObjectProperty("InMasterPage", "false");
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ".", "")));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtUsuariosId_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", A66UsuariosNombre);
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", A65UsuariosApPat);
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", A244UsuariosUsr);
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
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 84 )
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

      protected void START1E2( )
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
            Form.Meta.addItem("description", "Selection List Tabla de usuarios", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1E0( ) ;
      }

      protected void WS1E2( )
      {
         START1E2( ) ;
         EVT1E2( ) ;
      }

      protected void EVT1E2( )
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
                              /* No code required for Cancel button. It is implemented as the Reset button. */
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_84_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A11UsuariosId = (int)(context.localUtil.CToN( cgiGet( edtUsuariosId_Internalname), ",", "."));
                              A66UsuariosNombre = StringUtil.Upper( cgiGet( edtUsuariosNombre_Internalname));
                              A65UsuariosApPat = StringUtil.Upper( cgiGet( edtUsuariosApPat_Internalname));
                              A244UsuariosUsr = cgiGet( edtUsuariosUsr_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E191E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E201E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cusuariosid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUSUARIOSID"), ",", ".") != Convert.ToDecimal( AV6cUsuariosId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuariosnombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSNOMBRE"), AV7cUsuariosNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuariosappat Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSAPPAT"), AV8cUsuariosApPat) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuariosapmat Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSAPMAT"), AV9cUsuariosApMat) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuariosusr Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSUSR"), AV10cUsuariosUsr) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuariospwd Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSPWD"), AV11cUsuariosPwd) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuarioskey Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSKEY"), AV12cUsuariosKey) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E211E2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
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

      protected void WE1E2( )
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

      protected void PA1E2( )
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
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        int AV6cUsuariosId ,
                                        String AV7cUsuariosNombre ,
                                        String AV8cUsuariosApPat ,
                                        String AV9cUsuariosApMat ,
                                        String AV10cUsuariosUsr ,
                                        String AV11cUsuariosPwd ,
                                        String AV12cUsuariosKey )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF1E2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "USUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ".", "")));
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
         RF1E2( ) ;
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

      protected void RF1E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cUsuariosNombre ,
                                                 AV8cUsuariosApPat ,
                                                 AV9cUsuariosApMat ,
                                                 AV10cUsuariosUsr ,
                                                 AV11cUsuariosPwd ,
                                                 AV12cUsuariosKey ,
                                                 A66UsuariosNombre ,
                                                 A65UsuariosApPat ,
                                                 A64UsuariosApMat ,
                                                 A244UsuariosUsr ,
                                                 A68UsuariosPwd ,
                                                 A67UsuariosKey ,
                                                 AV6cUsuariosId } ,
                                                 new int[]{
                                                 TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING,
                                                 TypeConstants.STRING, TypeConstants.STRING, TypeConstants.INT
                                                 }
            } ) ;
            lV7cUsuariosNombre = StringUtil.Concat( StringUtil.RTrim( AV7cUsuariosNombre), "%", "");
            lV8cUsuariosApPat = StringUtil.Concat( StringUtil.RTrim( AV8cUsuariosApPat), "%", "");
            lV9cUsuariosApMat = StringUtil.Concat( StringUtil.RTrim( AV9cUsuariosApMat), "%", "");
            lV10cUsuariosUsr = StringUtil.Concat( StringUtil.RTrim( AV10cUsuariosUsr), "%", "");
            lV11cUsuariosPwd = StringUtil.Concat( StringUtil.RTrim( AV11cUsuariosPwd), "%", "");
            lV12cUsuariosKey = StringUtil.Concat( StringUtil.RTrim( AV12cUsuariosKey), "%", "");
            /* Using cursor H001E2 */
            pr_default.execute(0, new Object[] {AV6cUsuariosId, lV7cUsuariosNombre, lV8cUsuariosApPat, lV9cUsuariosApMat, lV10cUsuariosUsr, lV11cUsuariosPwd, lV12cUsuariosKey, GXPagingFrom2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A67UsuariosKey = H001E2_A67UsuariosKey[0];
               A68UsuariosPwd = H001E2_A68UsuariosPwd[0];
               A64UsuariosApMat = H001E2_A64UsuariosApMat[0];
               A244UsuariosUsr = H001E2_A244UsuariosUsr[0];
               A65UsuariosApPat = H001E2_A65UsuariosApPat[0];
               A66UsuariosNombre = H001E2_A66UsuariosNombre[0];
               A11UsuariosId = H001E2_A11UsuariosId[0];
               /* Execute user event: Load */
               E201E2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB1E0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1E2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOSID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9"), context));
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
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cUsuariosNombre ,
                                              AV8cUsuariosApPat ,
                                              AV9cUsuariosApMat ,
                                              AV10cUsuariosUsr ,
                                              AV11cUsuariosPwd ,
                                              AV12cUsuariosKey ,
                                              A66UsuariosNombre ,
                                              A65UsuariosApPat ,
                                              A64UsuariosApMat ,
                                              A244UsuariosUsr ,
                                              A68UsuariosPwd ,
                                              A67UsuariosKey ,
                                              AV6cUsuariosId } ,
                                              new int[]{
                                              TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING,
                                              TypeConstants.STRING, TypeConstants.STRING, TypeConstants.INT
                                              }
         } ) ;
         lV7cUsuariosNombre = StringUtil.Concat( StringUtil.RTrim( AV7cUsuariosNombre), "%", "");
         lV8cUsuariosApPat = StringUtil.Concat( StringUtil.RTrim( AV8cUsuariosApPat), "%", "");
         lV9cUsuariosApMat = StringUtil.Concat( StringUtil.RTrim( AV9cUsuariosApMat), "%", "");
         lV10cUsuariosUsr = StringUtil.Concat( StringUtil.RTrim( AV10cUsuariosUsr), "%", "");
         lV11cUsuariosPwd = StringUtil.Concat( StringUtil.RTrim( AV11cUsuariosPwd), "%", "");
         lV12cUsuariosKey = StringUtil.Concat( StringUtil.RTrim( AV12cUsuariosKey), "%", "");
         /* Using cursor H001E3 */
         pr_default.execute(1, new Object[] {AV6cUsuariosId, lV7cUsuariosNombre, lV8cUsuariosApPat, lV9cUsuariosApMat, lV10cUsuariosUsr, lV11cUsuariosPwd, lV12cUsuariosKey});
         GRID1_nRecordCount = H001E3_AGRID1_nRecordCount[0];
         pr_default.close(1);
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuariosId, AV7cUsuariosNombre, AV8cUsuariosApPat, AV9cUsuariosApMat, AV10cUsuariosUsr, AV11cUsuariosPwd, AV12cUsuariosKey) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuariosId, AV7cUsuariosNombre, AV8cUsuariosApPat, AV9cUsuariosApMat, AV10cUsuariosUsr, AV11cUsuariosPwd, AV12cUsuariosKey) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuariosId, AV7cUsuariosNombre, AV8cUsuariosApPat, AV9cUsuariosApMat, AV10cUsuariosUsr, AV11cUsuariosPwd, AV12cUsuariosKey) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuariosId, AV7cUsuariosNombre, AV8cUsuariosApPat, AV9cUsuariosApMat, AV10cUsuariosUsr, AV11cUsuariosPwd, AV12cUsuariosKey) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuariosId, AV7cUsuariosNombre, AV8cUsuariosApPat, AV9cUsuariosApMat, AV10cUsuariosUsr, AV11cUsuariosPwd, AV12cUsuariosKey) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP1E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E191E2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ",", "."));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ",", "."));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ",", "."));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCusuariosid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCusuariosid_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCUSUARIOSID");
               GX_FocusControl = edtavCusuariosid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cUsuariosId = 0;
               AssignAttri("", false, "AV6cUsuariosId", StringUtil.LTrimStr( (decimal)(AV6cUsuariosId), 6, 0));
            }
            else
            {
               AV6cUsuariosId = (int)(context.localUtil.CToN( cgiGet( edtavCusuariosid_Internalname), ",", "."));
               AssignAttri("", false, "AV6cUsuariosId", StringUtil.LTrimStr( (decimal)(AV6cUsuariosId), 6, 0));
            }
            AV7cUsuariosNombre = StringUtil.Upper( cgiGet( edtavCusuariosnombre_Internalname));
            AssignAttri("", false, "AV7cUsuariosNombre", AV7cUsuariosNombre);
            AV8cUsuariosApPat = StringUtil.Upper( cgiGet( edtavCusuariosappat_Internalname));
            AssignAttri("", false, "AV8cUsuariosApPat", AV8cUsuariosApPat);
            AV9cUsuariosApMat = StringUtil.Upper( cgiGet( edtavCusuariosapmat_Internalname));
            AssignAttri("", false, "AV9cUsuariosApMat", AV9cUsuariosApMat);
            AV10cUsuariosUsr = cgiGet( edtavCusuariosusr_Internalname);
            AssignAttri("", false, "AV10cUsuariosUsr", AV10cUsuariosUsr);
            AV11cUsuariosPwd = cgiGet( edtavCusuariospwd_Internalname);
            AssignAttri("", false, "AV11cUsuariosPwd", AV11cUsuariosPwd);
            AV12cUsuariosKey = cgiGet( edtavCusuarioskey_Internalname);
            AssignAttri("", false, "AV12cUsuariosKey", AV12cUsuariosKey);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUSUARIOSID"), ",", ".") != Convert.ToDecimal( AV6cUsuariosId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSNOMBRE"), AV7cUsuariosNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSAPPAT"), AV8cUsuariosApPat) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSAPMAT"), AV9cUsuariosApMat) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSUSR"), AV10cUsuariosUsr) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSPWD"), AV11cUsuariosPwd) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSKEY"), AV12cUsuariosKey) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
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
         E191E2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E191E2( )
      {
         /* Start Routine */
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "Tabla de usuarios", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E201E2( )
      {
         /* Load Routine */
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV17Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            context.DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E211E2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E211E2( )
      {
         /* Enter Routine */
         AV13pUsuariosId = A11UsuariosId;
         AssignAttri("", false, "AV13pUsuariosId", StringUtil.LTrimStr( (decimal)(AV13pUsuariosId), 6, 0));
         context.setWebReturnParms(new Object[] {(int)AV13pUsuariosId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pUsuariosId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13pUsuariosId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV13pUsuariosId", StringUtil.LTrimStr( (decimal)(AV13pUsuariosId), 6, 0));
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
         PA1E2( ) ;
         WS1E2( ) ;
         WE1E2( ) ;
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
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?20226271435347", true, true);
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
         context.AddJavascriptSource("gx0090.js", "?20226271435347", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtUsuariosId_Internalname = "USUARIOSID_"+sGXsfl_84_idx;
         edtUsuariosNombre_Internalname = "USUARIOSNOMBRE_"+sGXsfl_84_idx;
         edtUsuariosApPat_Internalname = "USUARIOSAPPAT_"+sGXsfl_84_idx;
         edtUsuariosUsr_Internalname = "USUARIOSUSR_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtUsuariosId_Internalname = "USUARIOSID_"+sGXsfl_84_fel_idx;
         edtUsuariosNombre_Internalname = "USUARIOSNOMBRE_"+sGXsfl_84_fel_idx;
         edtUsuariosApPat_Internalname = "USUARIOSAPPAT_"+sGXsfl_84_fel_idx;
         edtUsuariosUsr_Internalname = "USUARIOSUSR_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB1E0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute";
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV17Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavLinkselection_Internalname,(String)sImgUrl,(String)edtavLinkselection_Link,(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"",(String)"",(short)1,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"WWActionColumn",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            edtUsuariosId_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtUsuariosId_Internalname, "Link", edtUsuariosId_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")),context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)edtUsuariosId_Link,(String)"",(String)"",(String)"",(String)edtUsuariosId_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)6,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(String)"NumId",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosNombre_Internalname,(String)A66UsuariosNombre,StringUtil.RTrim( context.localUtil.Format( A66UsuariosNombre, "@!")),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosNombre_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)40,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosApPat_Internalname,(String)A65UsuariosApPat,StringUtil.RTrim( context.localUtil.Format( A65UsuariosApPat, "@!")),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosApPat_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)40,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosUsr_Internalname,(String)A244UsuariosUsr,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosUsr_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)20,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            send_integrity_lvl_hashes1E2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLblusuariosidfilter_Internalname = "LBLUSUARIOSIDFILTER";
         edtavCusuariosid_Internalname = "vCUSUARIOSID";
         divUsuariosidfiltercontainer_Internalname = "USUARIOSIDFILTERCONTAINER";
         lblLblusuariosnombrefilter_Internalname = "LBLUSUARIOSNOMBREFILTER";
         edtavCusuariosnombre_Internalname = "vCUSUARIOSNOMBRE";
         divUsuariosnombrefiltercontainer_Internalname = "USUARIOSNOMBREFILTERCONTAINER";
         lblLblusuariosappatfilter_Internalname = "LBLUSUARIOSAPPATFILTER";
         edtavCusuariosappat_Internalname = "vCUSUARIOSAPPAT";
         divUsuariosappatfiltercontainer_Internalname = "USUARIOSAPPATFILTERCONTAINER";
         lblLblusuariosapmatfilter_Internalname = "LBLUSUARIOSAPMATFILTER";
         edtavCusuariosapmat_Internalname = "vCUSUARIOSAPMAT";
         divUsuariosapmatfiltercontainer_Internalname = "USUARIOSAPMATFILTERCONTAINER";
         lblLblusuariosusrfilter_Internalname = "LBLUSUARIOSUSRFILTER";
         edtavCusuariosusr_Internalname = "vCUSUARIOSUSR";
         divUsuariosusrfiltercontainer_Internalname = "USUARIOSUSRFILTERCONTAINER";
         lblLblusuariospwdfilter_Internalname = "LBLUSUARIOSPWDFILTER";
         edtavCusuariospwd_Internalname = "vCUSUARIOSPWD";
         divUsuariospwdfiltercontainer_Internalname = "USUARIOSPWDFILTERCONTAINER";
         lblLblusuarioskeyfilter_Internalname = "LBLUSUARIOSKEYFILTER";
         edtavCusuarioskey_Internalname = "vCUSUARIOSKEY";
         divUsuarioskeyfiltercontainer_Internalname = "USUARIOSKEYFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtUsuariosId_Internalname = "USUARIOSID";
         edtUsuariosNombre_Internalname = "USUARIOSNOMBRE";
         edtUsuariosApPat_Internalname = "USUARIOSAPPAT";
         edtUsuariosUsr_Internalname = "USUARIOSUSR";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
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
         edtUsuariosUsr_Jsonclick = "";
         edtUsuariosApPat_Jsonclick = "";
         edtUsuariosNombre_Jsonclick = "";
         edtUsuariosId_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtUsuariosId_Link = "";
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCusuarioskey_Jsonclick = "";
         edtavCusuarioskey_Enabled = 1;
         edtavCusuarioskey_Visible = 1;
         edtavCusuariospwd_Jsonclick = "";
         edtavCusuariospwd_Enabled = 1;
         edtavCusuariospwd_Visible = 1;
         edtavCusuariosusr_Jsonclick = "";
         edtavCusuariosusr_Enabled = 1;
         edtavCusuariosusr_Visible = 1;
         edtavCusuariosapmat_Jsonclick = "";
         edtavCusuariosapmat_Enabled = 1;
         edtavCusuariosapmat_Visible = 1;
         edtavCusuariosappat_Jsonclick = "";
         edtavCusuariosappat_Enabled = 1;
         edtavCusuariosappat_Visible = 1;
         edtavCusuariosnombre_Jsonclick = "";
         edtavCusuariosnombre_Enabled = 1;
         edtavCusuariosnombre_Visible = 1;
         edtavCusuariosid_Jsonclick = "";
         edtavCusuariosid_Enabled = 1;
         edtavCusuariosid_Visible = 1;
         divUsuarioskeyfiltercontainer_Class = "AdvancedContainerItem";
         divUsuariospwdfiltercontainer_Class = "AdvancedContainerItem";
         divUsuariosusrfiltercontainer_Class = "AdvancedContainerItem";
         divUsuariosapmatfiltercontainer_Class = "AdvancedContainerItem";
         divUsuariosappatfiltercontainer_Class = "AdvancedContainerItem";
         divUsuariosnombrefiltercontainer_Class = "AdvancedContainerItem";
         divUsuariosidfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Tabla de usuarios";
         subGrid1_Rows = 10;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUsuariosId',fld:'vCUSUARIOSID',pic:'ZZZZZ9'},{av:'AV7cUsuariosNombre',fld:'vCUSUARIOSNOMBRE',pic:'@!'},{av:'AV8cUsuariosApPat',fld:'vCUSUARIOSAPPAT',pic:'@!'},{av:'AV9cUsuariosApMat',fld:'vCUSUARIOSAPMAT',pic:'@!'},{av:'AV10cUsuariosUsr',fld:'vCUSUARIOSUSR',pic:''},{av:'AV11cUsuariosPwd',fld:'vCUSUARIOSPWD',pic:''},{av:'AV12cUsuariosKey',fld:'vCUSUARIOSKEY',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E181E1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLUSUARIOSIDFILTER.CLICK","{handler:'E111E1',iparms:[{av:'divUsuariosidfiltercontainer_Class',ctrl:'USUARIOSIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOSIDFILTER.CLICK",",oparms:[{av:'divUsuariosidfiltercontainer_Class',ctrl:'USUARIOSIDFILTERCONTAINER',prop:'Class'},{av:'edtavCusuariosid_Visible',ctrl:'vCUSUARIOSID',prop:'Visible'}]}");
         setEventMetadata("LBLUSUARIOSNOMBREFILTER.CLICK","{handler:'E121E1',iparms:[{av:'divUsuariosnombrefiltercontainer_Class',ctrl:'USUARIOSNOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOSNOMBREFILTER.CLICK",",oparms:[{av:'divUsuariosnombrefiltercontainer_Class',ctrl:'USUARIOSNOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCusuariosnombre_Visible',ctrl:'vCUSUARIOSNOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLUSUARIOSAPPATFILTER.CLICK","{handler:'E131E1',iparms:[{av:'divUsuariosappatfiltercontainer_Class',ctrl:'USUARIOSAPPATFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOSAPPATFILTER.CLICK",",oparms:[{av:'divUsuariosappatfiltercontainer_Class',ctrl:'USUARIOSAPPATFILTERCONTAINER',prop:'Class'},{av:'edtavCusuariosappat_Visible',ctrl:'vCUSUARIOSAPPAT',prop:'Visible'}]}");
         setEventMetadata("LBLUSUARIOSAPMATFILTER.CLICK","{handler:'E141E1',iparms:[{av:'divUsuariosapmatfiltercontainer_Class',ctrl:'USUARIOSAPMATFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOSAPMATFILTER.CLICK",",oparms:[{av:'divUsuariosapmatfiltercontainer_Class',ctrl:'USUARIOSAPMATFILTERCONTAINER',prop:'Class'},{av:'edtavCusuariosapmat_Visible',ctrl:'vCUSUARIOSAPMAT',prop:'Visible'}]}");
         setEventMetadata("LBLUSUARIOSUSRFILTER.CLICK","{handler:'E151E1',iparms:[{av:'divUsuariosusrfiltercontainer_Class',ctrl:'USUARIOSUSRFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOSUSRFILTER.CLICK",",oparms:[{av:'divUsuariosusrfiltercontainer_Class',ctrl:'USUARIOSUSRFILTERCONTAINER',prop:'Class'},{av:'edtavCusuariosusr_Visible',ctrl:'vCUSUARIOSUSR',prop:'Visible'}]}");
         setEventMetadata("LBLUSUARIOSPWDFILTER.CLICK","{handler:'E161E1',iparms:[{av:'divUsuariospwdfiltercontainer_Class',ctrl:'USUARIOSPWDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOSPWDFILTER.CLICK",",oparms:[{av:'divUsuariospwdfiltercontainer_Class',ctrl:'USUARIOSPWDFILTERCONTAINER',prop:'Class'},{av:'edtavCusuariospwd_Visible',ctrl:'vCUSUARIOSPWD',prop:'Visible'}]}");
         setEventMetadata("LBLUSUARIOSKEYFILTER.CLICK","{handler:'E171E1',iparms:[{av:'divUsuarioskeyfiltercontainer_Class',ctrl:'USUARIOSKEYFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOSKEYFILTER.CLICK",",oparms:[{av:'divUsuarioskeyfiltercontainer_Class',ctrl:'USUARIOSKEYFILTERCONTAINER',prop:'Class'},{av:'edtavCusuarioskey_Visible',ctrl:'vCUSUARIOSKEY',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E211E2',iparms:[{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pUsuariosId',fld:'vPUSUARIOSID',pic:'ZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUsuariosId',fld:'vCUSUARIOSID',pic:'ZZZZZ9'},{av:'AV7cUsuariosNombre',fld:'vCUSUARIOSNOMBRE',pic:'@!'},{av:'AV8cUsuariosApPat',fld:'vCUSUARIOSAPPAT',pic:'@!'},{av:'AV9cUsuariosApMat',fld:'vCUSUARIOSAPMAT',pic:'@!'},{av:'AV10cUsuariosUsr',fld:'vCUSUARIOSUSR',pic:''},{av:'AV11cUsuariosPwd',fld:'vCUSUARIOSPWD',pic:''},{av:'AV12cUsuariosKey',fld:'vCUSUARIOSKEY',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUsuariosId',fld:'vCUSUARIOSID',pic:'ZZZZZ9'},{av:'AV7cUsuariosNombre',fld:'vCUSUARIOSNOMBRE',pic:'@!'},{av:'AV8cUsuariosApPat',fld:'vCUSUARIOSAPPAT',pic:'@!'},{av:'AV9cUsuariosApMat',fld:'vCUSUARIOSAPMAT',pic:'@!'},{av:'AV10cUsuariosUsr',fld:'vCUSUARIOSUSR',pic:''},{av:'AV11cUsuariosPwd',fld:'vCUSUARIOSPWD',pic:''},{av:'AV12cUsuariosKey',fld:'vCUSUARIOSKEY',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUsuariosId',fld:'vCUSUARIOSID',pic:'ZZZZZ9'},{av:'AV7cUsuariosNombre',fld:'vCUSUARIOSNOMBRE',pic:'@!'},{av:'AV8cUsuariosApPat',fld:'vCUSUARIOSAPPAT',pic:'@!'},{av:'AV9cUsuariosApMat',fld:'vCUSUARIOSAPMAT',pic:'@!'},{av:'AV10cUsuariosUsr',fld:'vCUSUARIOSUSR',pic:''},{av:'AV11cUsuariosPwd',fld:'vCUSUARIOSPWD',pic:''},{av:'AV12cUsuariosKey',fld:'vCUSUARIOSKEY',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUsuariosId',fld:'vCUSUARIOSID',pic:'ZZZZZ9'},{av:'AV7cUsuariosNombre',fld:'vCUSUARIOSNOMBRE',pic:'@!'},{av:'AV8cUsuariosApPat',fld:'vCUSUARIOSAPPAT',pic:'@!'},{av:'AV9cUsuariosApMat',fld:'vCUSUARIOSAPMAT',pic:'@!'},{av:'AV10cUsuariosUsr',fld:'vCUSUARIOSUSR',pic:''},{av:'AV11cUsuariosPwd',fld:'vCUSUARIOSPWD',pic:''},{av:'AV12cUsuariosKey',fld:'vCUSUARIOSKEY',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Usuariosusr',iparms:[]");
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
         AV7cUsuariosNombre = "";
         AV8cUsuariosApPat = "";
         AV9cUsuariosApMat = "";
         AV10cUsuariosUsr = "";
         AV11cUsuariosPwd = "";
         AV12cUsuariosKey = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblusuariosidfilter_Jsonclick = "";
         TempTags = "";
         lblLblusuariosnombrefilter_Jsonclick = "";
         lblLblusuariosappatfilter_Jsonclick = "";
         lblLblusuariosapmatfilter_Jsonclick = "";
         lblLblusuariosusrfilter_Jsonclick = "";
         lblLblusuariospwdfilter_Jsonclick = "";
         lblLblusuarioskeyfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A66UsuariosNombre = "";
         A65UsuariosApPat = "";
         A244UsuariosUsr = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV17Linkselection_GXI = "";
         scmdbuf = "";
         lV7cUsuariosNombre = "";
         lV8cUsuariosApPat = "";
         lV9cUsuariosApMat = "";
         lV10cUsuariosUsr = "";
         lV11cUsuariosPwd = "";
         lV12cUsuariosKey = "";
         A64UsuariosApMat = "";
         A68UsuariosPwd = "";
         A67UsuariosKey = "";
         H001E2_A67UsuariosKey = new String[] {""} ;
         H001E2_A68UsuariosPwd = new String[] {""} ;
         H001E2_A64UsuariosApMat = new String[] {""} ;
         H001E2_A244UsuariosUsr = new String[] {""} ;
         H001E2_A65UsuariosApPat = new String[] {""} ;
         H001E2_A66UsuariosNombre = new String[] {""} ;
         H001E2_A11UsuariosId = new int[1] ;
         H001E3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0090__default(),
            new Object[][] {
                new Object[] {
               H001E2_A67UsuariosKey, H001E2_A68UsuariosPwd, H001E2_A64UsuariosApMat, H001E2_A244UsuariosUsr, H001E2_A65UsuariosApPat, H001E2_A66UsuariosNombre, H001E2_A11UsuariosId
               }
               , new Object[] {
               H001E3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_84 ;
      private int nGXsfl_84_idx=1 ;
      private int subGrid1_Rows ;
      private int AV6cUsuariosId ;
      private int AV13pUsuariosId ;
      private int edtavCusuariosid_Enabled ;
      private int edtavCusuariosid_Visible ;
      private int edtavCusuariosnombre_Visible ;
      private int edtavCusuariosnombre_Enabled ;
      private int edtavCusuariosappat_Visible ;
      private int edtavCusuariosappat_Enabled ;
      private int edtavCusuariosapmat_Visible ;
      private int edtavCusuariosapmat_Enabled ;
      private int edtavCusuariosusr_Visible ;
      private int edtavCusuariosusr_Enabled ;
      private int edtavCusuariospwd_Visible ;
      private int edtavCusuariospwd_Enabled ;
      private int edtavCusuarioskey_Visible ;
      private int edtavCusuarioskey_Enabled ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int A11UsuariosId ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private String divAdvancedcontainer_Class ;
      private String bttBtntoggle_Class ;
      private String divUsuariosidfiltercontainer_Class ;
      private String divUsuariosnombrefiltercontainer_Class ;
      private String divUsuariosappatfiltercontainer_Class ;
      private String divUsuariosapmatfiltercontainer_Class ;
      private String divUsuariosusrfiltercontainer_Class ;
      private String divUsuariospwdfiltercontainer_Class ;
      private String divUsuarioskeyfiltercontainer_Class ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_84_idx="0001" ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMain_Internalname ;
      private String divAdvancedcontainer_Internalname ;
      private String divUsuariosidfiltercontainer_Internalname ;
      private String lblLblusuariosidfilter_Internalname ;
      private String lblLblusuariosidfilter_Jsonclick ;
      private String edtavCusuariosid_Internalname ;
      private String TempTags ;
      private String edtavCusuariosid_Jsonclick ;
      private String divUsuariosnombrefiltercontainer_Internalname ;
      private String lblLblusuariosnombrefilter_Internalname ;
      private String lblLblusuariosnombrefilter_Jsonclick ;
      private String edtavCusuariosnombre_Internalname ;
      private String edtavCusuariosnombre_Jsonclick ;
      private String divUsuariosappatfiltercontainer_Internalname ;
      private String lblLblusuariosappatfilter_Internalname ;
      private String lblLblusuariosappatfilter_Jsonclick ;
      private String edtavCusuariosappat_Internalname ;
      private String edtavCusuariosappat_Jsonclick ;
      private String divUsuariosapmatfiltercontainer_Internalname ;
      private String lblLblusuariosapmatfilter_Internalname ;
      private String lblLblusuariosapmatfilter_Jsonclick ;
      private String edtavCusuariosapmat_Internalname ;
      private String edtavCusuariosapmat_Jsonclick ;
      private String divUsuariosusrfiltercontainer_Internalname ;
      private String lblLblusuariosusrfilter_Internalname ;
      private String lblLblusuariosusrfilter_Jsonclick ;
      private String edtavCusuariosusr_Internalname ;
      private String edtavCusuariosusr_Jsonclick ;
      private String divUsuariospwdfiltercontainer_Internalname ;
      private String lblLblusuariospwdfilter_Internalname ;
      private String lblLblusuariospwdfilter_Jsonclick ;
      private String edtavCusuariospwd_Internalname ;
      private String edtavCusuariospwd_Jsonclick ;
      private String divUsuarioskeyfiltercontainer_Internalname ;
      private String lblLblusuarioskeyfilter_Internalname ;
      private String lblLblusuarioskeyfilter_Jsonclick ;
      private String edtavCusuarioskey_Internalname ;
      private String edtavCusuarioskey_Jsonclick ;
      private String divGridtable_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String bttBtntoggle_Internalname ;
      private String bttBtntoggle_Jsonclick ;
      private String sStyleString ;
      private String subGrid1_Internalname ;
      private String subGrid1_Class ;
      private String subGrid1_Linesclass ;
      private String subGrid1_Header ;
      private String edtavLinkselection_Link ;
      private String edtUsuariosId_Link ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavLinkselection_Internalname ;
      private String edtUsuariosId_Internalname ;
      private String edtUsuariosNombre_Internalname ;
      private String edtUsuariosApPat_Internalname ;
      private String edtUsuariosUsr_Internalname ;
      private String scmdbuf ;
      private String AV14ADVANCED_LABEL_TEMPLATE ;
      private String sGXsfl_84_fel_idx="0001" ;
      private String sImgUrl ;
      private String ROClassString ;
      private String edtUsuariosId_Jsonclick ;
      private String edtUsuariosNombre_Jsonclick ;
      private String edtUsuariosApPat_Jsonclick ;
      private String edtUsuariosUsr_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private String AV7cUsuariosNombre ;
      private String AV8cUsuariosApPat ;
      private String AV9cUsuariosApMat ;
      private String AV10cUsuariosUsr ;
      private String AV11cUsuariosPwd ;
      private String AV12cUsuariosKey ;
      private String A66UsuariosNombre ;
      private String A65UsuariosApPat ;
      private String A244UsuariosUsr ;
      private String AV17Linkselection_GXI ;
      private String lV7cUsuariosNombre ;
      private String lV8cUsuariosApPat ;
      private String lV9cUsuariosApMat ;
      private String lV10cUsuariosUsr ;
      private String lV11cUsuariosPwd ;
      private String lV12cUsuariosKey ;
      private String A64UsuariosApMat ;
      private String A68UsuariosPwd ;
      private String A67UsuariosKey ;
      private String AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private String[] H001E2_A67UsuariosKey ;
      private String[] H001E2_A68UsuariosPwd ;
      private String[] H001E2_A64UsuariosApMat ;
      private String[] H001E2_A244UsuariosUsr ;
      private String[] H001E2_A65UsuariosApPat ;
      private String[] H001E2_A66UsuariosNombre ;
      private int[] H001E2_A11UsuariosId ;
      private long[] H001E3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int aP0_pUsuariosId ;
      private GXWebForm Form ;
   }

   public class gx0090__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001E2( IGxContext context ,
                                             String AV7cUsuariosNombre ,
                                             String AV8cUsuariosApPat ,
                                             String AV9cUsuariosApMat ,
                                             String AV10cUsuariosUsr ,
                                             String AV11cUsuariosPwd ,
                                             String AV12cUsuariosKey ,
                                             String A66UsuariosNombre ,
                                             String A65UsuariosApPat ,
                                             String A64UsuariosApMat ,
                                             String A244UsuariosUsr ,
                                             String A68UsuariosPwd ,
                                             String A67UsuariosKey ,
                                             int AV6cUsuariosId )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int1 ;
         GXv_int1 = new short [9] ;
         Object[] GXv_Object2 ;
         GXv_Object2 = new Object [2] ;
         String sSelectString ;
         String sFromString ;
         String sOrderString ;
         sSelectString = " `UsuariosKey`, `UsuariosPwd`, `UsuariosApMat`, `UsuariosUsr`, `UsuariosApPat`, `UsuariosNombre`, `UsuariosId`";
         sFromString = " FROM `Usuarios`";
         sOrderString = "";
         sWhereString = sWhereString + " WHERE (`UsuariosId` >= ?)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cUsuariosNombre)) )
         {
            sWhereString = sWhereString + " and (`UsuariosNombre` like ?)";
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cUsuariosApPat)) )
         {
            sWhereString = sWhereString + " and (`UsuariosApPat` like ?)";
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cUsuariosApMat)) )
         {
            sWhereString = sWhereString + " and (`UsuariosApMat` like ?)";
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cUsuariosUsr)) )
         {
            sWhereString = sWhereString + " and (`UsuariosUsr` like ?)";
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cUsuariosPwd)) )
         {
            sWhereString = sWhereString + " and (`UsuariosPwd` like ?)";
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cUsuariosKey)) )
         {
            sWhereString = sWhereString + " and (`UsuariosKey` like ?)";
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString = sOrderString + " ORDER BY `UsuariosId`";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " LIMIT " + "?" + ", " + "?";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H001E3( IGxContext context ,
                                             String AV7cUsuariosNombre ,
                                             String AV8cUsuariosApPat ,
                                             String AV9cUsuariosApMat ,
                                             String AV10cUsuariosUsr ,
                                             String AV11cUsuariosPwd ,
                                             String AV12cUsuariosKey ,
                                             String A66UsuariosNombre ,
                                             String A65UsuariosApPat ,
                                             String A64UsuariosApMat ,
                                             String A244UsuariosUsr ,
                                             String A68UsuariosPwd ,
                                             String A67UsuariosKey ,
                                             int AV6cUsuariosId )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int3 ;
         GXv_int3 = new short [7] ;
         Object[] GXv_Object4 ;
         GXv_Object4 = new Object [2] ;
         scmdbuf = "SELECT COUNT(*) FROM `Usuarios`";
         scmdbuf = scmdbuf + " WHERE (`UsuariosId` >= ?)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cUsuariosNombre)) )
         {
            sWhereString = sWhereString + " and (`UsuariosNombre` like ?)";
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cUsuariosApPat)) )
         {
            sWhereString = sWhereString + " and (`UsuariosApPat` like ?)";
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cUsuariosApMat)) )
         {
            sWhereString = sWhereString + " and (`UsuariosApMat` like ?)";
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cUsuariosUsr)) )
         {
            sWhereString = sWhereString + " and (`UsuariosUsr` like ?)";
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cUsuariosPwd)) )
         {
            sWhereString = sWhereString + " and (`UsuariosPwd` like ?)";
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cUsuariosKey)) )
         {
            sWhereString = sWhereString + " and (`UsuariosKey` like ?)";
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf = scmdbuf + sWhereString;
         scmdbuf = scmdbuf + "";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H001E2(context, (String)dynConstraints[0] , (String)dynConstraints[1] , (String)dynConstraints[2] , (String)dynConstraints[3] , (String)dynConstraints[4] , (String)dynConstraints[5] , (String)dynConstraints[6] , (String)dynConstraints[7] , (String)dynConstraints[8] , (String)dynConstraints[9] , (String)dynConstraints[10] , (String)dynConstraints[11] , (int)dynConstraints[12] );
               case 1 :
                     return conditional_H001E3(context, (String)dynConstraints[0] , (String)dynConstraints[1] , (String)dynConstraints[2] , (String)dynConstraints[3] , (String)dynConstraints[4] , (String)dynConstraints[5] , (String)dynConstraints[6] , (String)dynConstraints[7] , (String)dynConstraints[8] , (String)dynConstraints[9] , (String)dynConstraints[10] , (String)dynConstraints[11] , (int)dynConstraints[12] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH001E2 ;
          prmH001E2 = new Object[] {
          new Object[] {"AV6cUsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"lV7cUsuariosNombre",System.Data.DbType.String,40,0} ,
          new Object[] {"lV8cUsuariosApPat",System.Data.DbType.String,40,0} ,
          new Object[] {"lV9cUsuariosApMat",System.Data.DbType.String,40,0} ,
          new Object[] {"lV10cUsuariosUsr",System.Data.DbType.String,20,0} ,
          new Object[] {"lV11cUsuariosPwd",System.Data.DbType.String,32,0} ,
          new Object[] {"lV12cUsuariosKey",System.Data.DbType.String,32,0} ,
          new Object[] {"GXPagingFrom2",System.Data.DbType.Int32,9,0} ,
          new Object[] {"GXPagingTo2",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmH001E3 ;
          prmH001E3 = new Object[] {
          new Object[] {"AV6cUsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"lV7cUsuariosNombre",System.Data.DbType.String,40,0} ,
          new Object[] {"lV8cUsuariosApPat",System.Data.DbType.String,40,0} ,
          new Object[] {"lV9cUsuariosApMat",System.Data.DbType.String,40,0} ,
          new Object[] {"lV10cUsuariosUsr",System.Data.DbType.String,20,0} ,
          new Object[] {"lV11cUsuariosPwd",System.Data.DbType.String,32,0} ,
          new Object[] {"lV12cUsuariosKey",System.Data.DbType.String,32,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H001E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001E2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H001E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001E3,1, GxCacheFrequency.OFF ,false,false )
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
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((String[]) buf[3])[0] = rslt.getVarchar(4) ;
                ((String[]) buf[4])[0] = rslt.getVarchar(5) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
                ((int[]) buf[6])[0] = rslt.getInt(7) ;
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
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
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[9]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[10]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[11]);
                }
                if ( (short)parms[3] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[12]);
                }
                if ( (short)parms[4] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[13]);
                }
                if ( (short)parms[5] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[14]);
                }
                if ( (short)parms[6] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[15]);
                }
                if ( (short)parms[7] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[16]);
                }
                if ( (short)parms[8] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[17]);
                }
                return;
             case 1 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[7]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[8]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[9]);
                }
                if ( (short)parms[3] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[10]);
                }
                if ( (short)parms[4] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[11]);
                }
                if ( (short)parms[5] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[12]);
                }
                if ( (short)parms[6] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[13]);
                }
                return;
       }
    }

 }

}
