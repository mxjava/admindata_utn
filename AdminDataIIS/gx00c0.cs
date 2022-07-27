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
   public class gx00c0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00c0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public gx00c0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( out int aP0_pUsuariosId ,
                           out DateTime aP1_pHisPwdFecha )
      {
         this.AV11pUsuariosId = 0 ;
         this.AV12pHisPwdFecha = DateTime.MinValue ;
         executePrivate();
         aP0_pUsuariosId=this.AV11pUsuariosId;
         aP1_pHisPwdFecha=this.AV12pHisPwdFecha;
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
               nRC_GXsfl_64 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_64_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_64_idx = GetNextPar( );
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
               AV7cHisPwdFecha = context.localUtil.ParseDTimeParm( GetNextPar( ));
               AV8cHistPwdConstra = GetNextPar( );
               AV9cHistPwdLlave = GetNextPar( );
               AV10cHistPwdInd = (short)(NumberUtil.Val( GetNextPar( ), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuariosId, AV7cHisPwdFecha, AV8cHistPwdConstra, AV9cHistPwdLlave, AV10cHistPwdInd) ;
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
               AV11pUsuariosId = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV11pUsuariosId", StringUtil.LTrimStr( (decimal)(AV11pUsuariosId), 6, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV12pHisPwdFecha = context.localUtil.ParseDTimeParm( GetNextPar( ));
                  AssignAttri("", false, "AV12pHisPwdFecha", context.localUtil.TToC( AV12pHisPwdFecha, 10, 8, 0, 3, "/", ":", " "));
               }
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
         PA1J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1J2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20226271435618", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00c0.aspx") + "?" + UrlEncode("" +AV11pUsuariosId) + "," + UrlEncode(DateTimeUtil.FormatDateTimeParm(AV12pHisPwdFecha))+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCHISPWDFECHA", context.localUtil.TToC( AV7cHisPwdFecha, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vCHISTPWDCONSTRA", AV8cHistPwdConstra);
         GxWebStd.gx_hidden_field( context, "GXH_vCHISTPWDLLAVE", AV9cHistPwdLlave);
         GxWebStd.gx_hidden_field( context, "GXH_vCHISTPWDIND", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cHistPwdInd), 1, 0, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_64), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPUSUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11pUsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPHISPWDFECHA", context.localUtil.TToC( AV12pHisPwdFecha, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOSIDFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariosidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "HISPWDFECHAFILTERCONTAINER_Class", StringUtil.RTrim( divHispwdfechafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "HISTPWDCONSTRAFILTERCONTAINER_Class", StringUtil.RTrim( divHistpwdconstrafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "HISTPWDLLAVEFILTERCONTAINER_Class", StringUtil.RTrim( divHistpwdllavefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "HISTPWDINDFILTERCONTAINER_Class", StringUtil.RTrim( divHistpwdindfiltercontainer_Class));
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
            WE1J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1J2( ) ;
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
         return formatLink("gx00c0.aspx") + "?" + UrlEncode("" +AV11pUsuariosId) + "," + UrlEncode(DateTimeUtil.FormatDateTimeParm(AV12pHisPwdFecha)) ;
      }

      public override String GetPgmname( )
      {
         return "Gx00C0" ;
      }

      public override String GetPgmdesc( )
      {
         return "Selection List Historico de Contrasenas" ;
      }

      protected void WB1J0( )
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
            GxWebStd.gx_label_ctrl( context, lblLblusuariosidfilter_Internalname, "ID", "", "", lblLblusuariosidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e111j1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx00C0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuariosid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cUsuariosId), 6, 0, ",", "")), ((edtavCusuariosid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV6cUsuariosId), "ZZZZZ9")) : context.localUtil.Format( (decimal)(AV6cUsuariosId), "ZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuariosid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuariosid_Visible, edtavCusuariosid_Enabled, 0, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00C0.htm");
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
            GxWebStd.gx_div_start( context, divHispwdfechafiltercontainer_Internalname, 1, 0, "px", 0, "px", divHispwdfechafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblhispwdfechafilter_Internalname, "Fecha de la Contrasena", "", "", lblLblhispwdfechafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e121j1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 1, "HLP_Gx00C0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChispwdfecha_Internalname, "Fecha de la Contrasena", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_64_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavChispwdfecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavChispwdfecha_Internalname, context.localUtil.TToC( AV7cHisPwdFecha, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV7cHisPwdFecha, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'spa',false,0);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChispwdfecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavChispwdfecha_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00C0.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divHistpwdconstrafiltercontainer_Internalname, 1, 0, "px", 0, "px", divHistpwdconstrafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblhistpwdconstrafilter_Internalname, "Constrasena ", "", "", lblLblhistpwdconstrafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e131j1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx00C0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChistpwdconstra_Internalname, "Constrasena ", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChistpwdconstra_Internalname, AV8cHistPwdConstra, StringUtil.RTrim( context.localUtil.Format( AV8cHistPwdConstra, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChistpwdconstra_Jsonclick, 0, "Attribute", "", "", "", "", edtavChistpwdconstra_Visible, edtavChistpwdconstra_Enabled, 0, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx00C0.htm");
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
            GxWebStd.gx_div_start( context, divHistpwdllavefiltercontainer_Internalname, 1, 0, "px", 0, "px", divHistpwdllavefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblhistpwdllavefilter_Internalname, "Llave de la contrasena", "", "", lblLblhistpwdllavefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e141j1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx00C0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChistpwdllave_Internalname, "Llave de la contrasena", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChistpwdllave_Internalname, AV9cHistPwdLlave, StringUtil.RTrim( context.localUtil.Format( AV9cHistPwdLlave, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChistpwdllave_Jsonclick, 0, "Attribute", "", "", "", "", edtavChistpwdllave_Visible, edtavChistpwdllave_Enabled, 0, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx00C0.htm");
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
            GxWebStd.gx_div_start( context, divHistpwdindfiltercontainer_Internalname, 1, 0, "px", 0, "px", divHistpwdindfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblhistpwdindfilter_Internalname, "Indicador de quien cambio la contraseña", "", "", lblLblhistpwdindfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e151j1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx00C0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChistpwdind_Internalname, "Indicador de quien cambio la contraseña", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChistpwdind_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cHistPwdInd), 1, 0, ",", "")), ((edtavChistpwdind_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV10cHistPwdInd), "9")) : context.localUtil.Format( (decimal)(AV10cHistPwdInd), "9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChistpwdind_Jsonclick, 0, "Attribute", "", "", "", "", edtavChistpwdind_Visible, edtavChistpwdind_Enabled, 0, "number", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00C0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e161j1_client"+"'", TempTags, "", 2, "HLP_Gx00C0.htm");
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
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"64\">") ;
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
               context.SendWebValue( "ID") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha de la Contrasena") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Constrasena") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Llave de la contrasena") ;
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
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.TToC( A62HisPwdFecha, 10, 8, 0, 3, "/", ":", " "));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", A110HistPwdConstra);
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtHistPwdConstra_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", A111HistPwdLlave);
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
         if ( wbEnd == 64 )
         {
            wbEnd = 0;
            nRC_GXsfl_64 = (int)(nGXsfl_64_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00C0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 64 )
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

      protected void START1J2( )
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
            Form.Meta.addItem("description", "Selection List Historico de Contrasenas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1J0( ) ;
      }

      protected void WS1J2( )
      {
         START1J2( ) ;
         EVT1J2( ) ;
      }

      protected void EVT1J2( )
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
                              nGXsfl_64_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
                              SubsflControlProps_642( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV16Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_64_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A11UsuariosId = (int)(context.localUtil.CToN( cgiGet( edtUsuariosId_Internalname), ",", "."));
                              A62HisPwdFecha = context.localUtil.CToT( cgiGet( edtHisPwdFecha_Internalname), 0);
                              A110HistPwdConstra = cgiGet( edtHistPwdConstra_Internalname);
                              A111HistPwdLlave = cgiGet( edtHistPwdLlave_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E171J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E181J2 ();
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
                                       /* Set Refresh If Chispwdfecha Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCHISPWDFECHA"), 0) != AV7cHisPwdFecha )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Chistpwdconstra Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCHISTPWDCONSTRA"), AV8cHistPwdConstra) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Chistpwdllave Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCHISTPWDLLAVE"), AV9cHistPwdLlave) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Chistpwdind Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCHISTPWDIND"), ",", ".") != Convert.ToDecimal( AV10cHistPwdInd )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E191J2 ();
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

      protected void WE1J2( )
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

      protected void PA1J2( )
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
         SubsflControlProps_642( ) ;
         while ( nGXsfl_64_idx <= nRC_GXsfl_64 )
         {
            sendrow_642( ) ;
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        int AV6cUsuariosId ,
                                        DateTime AV7cHisPwdFecha ,
                                        String AV8cHistPwdConstra ,
                                        String AV9cHistPwdLlave ,
                                        short AV10cHistPwdInd )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF1J2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "USUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_HISPWDFECHA", GetSecureSignedToken( "", context.localUtil.Format( A62HisPwdFecha, "99/99/9999 99:99:99"), context));
         GxWebStd.gx_hidden_field( context, "HISPWDFECHA", context.localUtil.TToC( A62HisPwdFecha, 10, 8, 0, 3, "/", ":", " "));
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
         RF1J2( ) ;
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

      protected void RF1J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 64;
         nGXsfl_64_idx = 1;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         bGXsfl_64_Refreshing = true;
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
            SubsflControlProps_642( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV8cHistPwdConstra ,
                                                 AV9cHistPwdLlave ,
                                                 AV10cHistPwdInd ,
                                                 A110HistPwdConstra ,
                                                 A111HistPwdLlave ,
                                                 A73HistPwdInd ,
                                                 AV6cUsuariosId ,
                                                 AV7cHisPwdFecha } ,
                                                 new int[]{
                                                 TypeConstants.STRING, TypeConstants.STRING, TypeConstants.SHORT, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DATE
                                                 }
            } ) ;
            lV8cHistPwdConstra = StringUtil.Concat( StringUtil.RTrim( AV8cHistPwdConstra), "%", "");
            lV9cHistPwdLlave = StringUtil.Concat( StringUtil.RTrim( AV9cHistPwdLlave), "%", "");
            /* Using cursor H001J2 */
            pr_default.execute(0, new Object[] {AV6cUsuariosId, AV7cHisPwdFecha, lV8cHistPwdConstra, lV9cHistPwdLlave, AV10cHistPwdInd, GXPagingFrom2, GXPagingTo2});
            nGXsfl_64_idx = 1;
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A73HistPwdInd = H001J2_A73HistPwdInd[0];
               A111HistPwdLlave = H001J2_A111HistPwdLlave[0];
               A110HistPwdConstra = H001J2_A110HistPwdConstra[0];
               A62HisPwdFecha = H001J2_A62HisPwdFecha[0];
               A11UsuariosId = H001J2_A11UsuariosId[0];
               /* Execute user event: Load */
               E181J2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 64;
            WB1J0( ) ;
         }
         bGXsfl_64_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1J2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOSID"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_HISPWDFECHA"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, context.localUtil.Format( A62HisPwdFecha, "99/99/9999 99:99:99"), context));
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
                                              AV8cHistPwdConstra ,
                                              AV9cHistPwdLlave ,
                                              AV10cHistPwdInd ,
                                              A110HistPwdConstra ,
                                              A111HistPwdLlave ,
                                              A73HistPwdInd ,
                                              AV6cUsuariosId ,
                                              AV7cHisPwdFecha } ,
                                              new int[]{
                                              TypeConstants.STRING, TypeConstants.STRING, TypeConstants.SHORT, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DATE
                                              }
         } ) ;
         lV8cHistPwdConstra = StringUtil.Concat( StringUtil.RTrim( AV8cHistPwdConstra), "%", "");
         lV9cHistPwdLlave = StringUtil.Concat( StringUtil.RTrim( AV9cHistPwdLlave), "%", "");
         /* Using cursor H001J3 */
         pr_default.execute(1, new Object[] {AV6cUsuariosId, AV7cHisPwdFecha, lV8cHistPwdConstra, lV9cHistPwdLlave, AV10cHistPwdInd});
         GRID1_nRecordCount = H001J3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuariosId, AV7cHisPwdFecha, AV8cHistPwdConstra, AV9cHistPwdLlave, AV10cHistPwdInd) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuariosId, AV7cHisPwdFecha, AV8cHistPwdConstra, AV9cHistPwdLlave, AV10cHistPwdInd) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuariosId, AV7cHisPwdFecha, AV8cHistPwdConstra, AV9cHistPwdLlave, AV10cHistPwdInd) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuariosId, AV7cHisPwdFecha, AV8cHistPwdConstra, AV9cHistPwdLlave, AV10cHistPwdInd) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuariosId, AV7cHisPwdFecha, AV8cHistPwdConstra, AV9cHistPwdLlave, AV10cHistPwdInd) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP1J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E171J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_64 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_64"), ",", "."));
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
            if ( context.localUtil.VCDateTime( cgiGet( edtavChispwdfecha_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha de la Contrasena"}), 1, "vCHISPWDFECHA");
               GX_FocusControl = edtavChispwdfecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cHisPwdFecha = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV7cHisPwdFecha", context.localUtil.TToC( AV7cHisPwdFecha, 10, 8, 0, 3, "/", ":", " "));
            }
            else
            {
               AV7cHisPwdFecha = context.localUtil.CToT( cgiGet( edtavChispwdfecha_Internalname));
               AssignAttri("", false, "AV7cHisPwdFecha", context.localUtil.TToC( AV7cHisPwdFecha, 10, 8, 0, 3, "/", ":", " "));
            }
            AV8cHistPwdConstra = cgiGet( edtavChistpwdconstra_Internalname);
            AssignAttri("", false, "AV8cHistPwdConstra", AV8cHistPwdConstra);
            AV9cHistPwdLlave = cgiGet( edtavChistpwdllave_Internalname);
            AssignAttri("", false, "AV9cHistPwdLlave", AV9cHistPwdLlave);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavChistpwdind_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavChistpwdind_Internalname), ",", ".") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCHISTPWDIND");
               GX_FocusControl = edtavChistpwdind_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cHistPwdInd = 0;
               AssignAttri("", false, "AV10cHistPwdInd", StringUtil.Str( (decimal)(AV10cHistPwdInd), 1, 0));
            }
            else
            {
               AV10cHistPwdInd = (short)(context.localUtil.CToN( cgiGet( edtavChistpwdind_Internalname), ",", "."));
               AssignAttri("", false, "AV10cHistPwdInd", StringUtil.Str( (decimal)(AV10cHistPwdInd), 1, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUSUARIOSID"), ",", ".") != Convert.ToDecimal( AV6cUsuariosId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCHISPWDFECHA")) != AV7cHisPwdFecha )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCHISTPWDCONSTRA"), AV8cHistPwdConstra) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCHISTPWDLLAVE"), AV9cHistPwdLlave) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCHISTPWDIND"), ",", ".") != Convert.ToDecimal( AV10cHistPwdInd )) )
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
         E171J2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E171J2( )
      {
         /* Start Routine */
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "Historico de Contrasenas", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV13ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E181J2( )
      {
         /* Load Routine */
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV16Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_642( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_64_Refreshing )
         {
            context.DoAjaxLoad(64, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E191J2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E191J2( )
      {
         /* Enter Routine */
         AV11pUsuariosId = A11UsuariosId;
         AssignAttri("", false, "AV11pUsuariosId", StringUtil.LTrimStr( (decimal)(AV11pUsuariosId), 6, 0));
         AV12pHisPwdFecha = A62HisPwdFecha;
         AssignAttri("", false, "AV12pHisPwdFecha", context.localUtil.TToC( AV12pHisPwdFecha, 10, 8, 0, 3, "/", ":", " "));
         context.setWebReturnParms(new Object[] {(int)AV11pUsuariosId,context.localUtil.Format( AV12pHisPwdFecha, "99/99/9999 99:99:99")});
         context.setWebReturnParmsMetadata(new Object[] {"AV11pUsuariosId","AV12pHisPwdFecha"});
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
         AV11pUsuariosId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV11pUsuariosId", StringUtil.LTrimStr( (decimal)(AV11pUsuariosId), 6, 0));
         AV12pHisPwdFecha = (DateTime)getParm(obj,1);
         AssignAttri("", false, "AV12pHisPwdFecha", context.localUtil.TToC( AV12pHisPwdFecha, 10, 8, 0, 3, "/", ":", " "));
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
         PA1J2( ) ;
         WS1J2( ) ;
         WE1J2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?20226271435658", true, true);
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
         context.AddJavascriptSource("gx00c0.js", "?20226271435658", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_idx;
         edtUsuariosId_Internalname = "USUARIOSID_"+sGXsfl_64_idx;
         edtHisPwdFecha_Internalname = "HISPWDFECHA_"+sGXsfl_64_idx;
         edtHistPwdConstra_Internalname = "HISTPWDCONSTRA_"+sGXsfl_64_idx;
         edtHistPwdLlave_Internalname = "HISTPWDLLAVE_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_fel_idx;
         edtUsuariosId_Internalname = "USUARIOSID_"+sGXsfl_64_fel_idx;
         edtHisPwdFecha_Internalname = "HISPWDFECHA_"+sGXsfl_64_fel_idx;
         edtHistPwdConstra_Internalname = "HISTPWDCONSTRA_"+sGXsfl_64_fel_idx;
         edtHistPwdLlave_Internalname = "HISTPWDLLAVE_"+sGXsfl_64_fel_idx;
      }

      protected void sendrow_642( )
      {
         SubsflControlProps_642( ) ;
         WB1J0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_64_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_64_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_64_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( context.localUtil.TToC( A62HisPwdFecha, 10, 8, 0, 3, "/", ":", " "))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_64_Refreshing);
            ClassString = "SelectionAttribute";
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV16Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV16Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavLinkselection_Internalname,(String)sImgUrl,(String)edtavLinkselection_Link,(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"",(String)"",(short)1,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"WWActionColumn",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")),context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosId_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)6,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(String)"NumId",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtHisPwdFecha_Internalname,context.localUtil.TToC( A62HisPwdFecha, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A62HisPwdFecha, "99/99/9999 99:99:99"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtHisPwdFecha_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)19,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaTiempo",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtHistPwdConstra_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( context.localUtil.TToC( A62HisPwdFecha, 10, 8, 0, 3, "/", ":", " "))+"'"+"]);";
            AssignProp("", false, edtHistPwdConstra_Internalname, "Link", edtHistPwdConstra_Link, !bGXsfl_64_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtHistPwdConstra_Internalname,(String)A110HistPwdConstra,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)edtHistPwdConstra_Link,(String)"",(String)"",(String)"",(String)edtHistPwdConstra_Jsonclick,(short)0,(String)"DescriptionAttribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)32,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtHistPwdLlave_Internalname,(String)A111HistPwdLlave,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtHistPwdLlave_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)32,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            send_integrity_lvl_hashes1J2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         /* End function sendrow_642 */
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
         lblLblhispwdfechafilter_Internalname = "LBLHISPWDFECHAFILTER";
         edtavChispwdfecha_Internalname = "vCHISPWDFECHA";
         divHispwdfechafiltercontainer_Internalname = "HISPWDFECHAFILTERCONTAINER";
         lblLblhistpwdconstrafilter_Internalname = "LBLHISTPWDCONSTRAFILTER";
         edtavChistpwdconstra_Internalname = "vCHISTPWDCONSTRA";
         divHistpwdconstrafiltercontainer_Internalname = "HISTPWDCONSTRAFILTERCONTAINER";
         lblLblhistpwdllavefilter_Internalname = "LBLHISTPWDLLAVEFILTER";
         edtavChistpwdllave_Internalname = "vCHISTPWDLLAVE";
         divHistpwdllavefiltercontainer_Internalname = "HISTPWDLLAVEFILTERCONTAINER";
         lblLblhistpwdindfilter_Internalname = "LBLHISTPWDINDFILTER";
         edtavChistpwdind_Internalname = "vCHISTPWDIND";
         divHistpwdindfiltercontainer_Internalname = "HISTPWDINDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtUsuariosId_Internalname = "USUARIOSID";
         edtHisPwdFecha_Internalname = "HISPWDFECHA";
         edtHistPwdConstra_Internalname = "HISTPWDCONSTRA";
         edtHistPwdLlave_Internalname = "HISTPWDLLAVE";
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
         edtHistPwdLlave_Jsonclick = "";
         edtHistPwdConstra_Jsonclick = "";
         edtHisPwdFecha_Jsonclick = "";
         edtUsuariosId_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtHistPwdConstra_Link = "";
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavChistpwdind_Jsonclick = "";
         edtavChistpwdind_Enabled = 1;
         edtavChistpwdind_Visible = 1;
         edtavChistpwdllave_Jsonclick = "";
         edtavChistpwdllave_Enabled = 1;
         edtavChistpwdllave_Visible = 1;
         edtavChistpwdconstra_Jsonclick = "";
         edtavChistpwdconstra_Enabled = 1;
         edtavChistpwdconstra_Visible = 1;
         edtavChispwdfecha_Jsonclick = "";
         edtavChispwdfecha_Enabled = 1;
         edtavCusuariosid_Jsonclick = "";
         edtavCusuariosid_Enabled = 1;
         edtavCusuariosid_Visible = 1;
         divHistpwdindfiltercontainer_Class = "AdvancedContainerItem";
         divHistpwdllavefiltercontainer_Class = "AdvancedContainerItem";
         divHistpwdconstrafiltercontainer_Class = "AdvancedContainerItem";
         divHispwdfechafiltercontainer_Class = "AdvancedContainerItem";
         divUsuariosidfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Historico de Contrasenas";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUsuariosId',fld:'vCUSUARIOSID',pic:'ZZZZZ9'},{av:'AV7cHisPwdFecha',fld:'vCHISPWDFECHA',pic:'99/99/9999 99:99:99'},{av:'AV8cHistPwdConstra',fld:'vCHISTPWDCONSTRA',pic:''},{av:'AV9cHistPwdLlave',fld:'vCHISTPWDLLAVE',pic:''},{av:'AV10cHistPwdInd',fld:'vCHISTPWDIND',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E161J1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLUSUARIOSIDFILTER.CLICK","{handler:'E111J1',iparms:[{av:'divUsuariosidfiltercontainer_Class',ctrl:'USUARIOSIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOSIDFILTER.CLICK",",oparms:[{av:'divUsuariosidfiltercontainer_Class',ctrl:'USUARIOSIDFILTERCONTAINER',prop:'Class'},{av:'edtavCusuariosid_Visible',ctrl:'vCUSUARIOSID',prop:'Visible'}]}");
         setEventMetadata("LBLHISPWDFECHAFILTER.CLICK","{handler:'E121J1',iparms:[{av:'divHispwdfechafiltercontainer_Class',ctrl:'HISPWDFECHAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLHISPWDFECHAFILTER.CLICK",",oparms:[{av:'divHispwdfechafiltercontainer_Class',ctrl:'HISPWDFECHAFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLHISTPWDCONSTRAFILTER.CLICK","{handler:'E131J1',iparms:[{av:'divHistpwdconstrafiltercontainer_Class',ctrl:'HISTPWDCONSTRAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLHISTPWDCONSTRAFILTER.CLICK",",oparms:[{av:'divHistpwdconstrafiltercontainer_Class',ctrl:'HISTPWDCONSTRAFILTERCONTAINER',prop:'Class'},{av:'edtavChistpwdconstra_Visible',ctrl:'vCHISTPWDCONSTRA',prop:'Visible'}]}");
         setEventMetadata("LBLHISTPWDLLAVEFILTER.CLICK","{handler:'E141J1',iparms:[{av:'divHistpwdllavefiltercontainer_Class',ctrl:'HISTPWDLLAVEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLHISTPWDLLAVEFILTER.CLICK",",oparms:[{av:'divHistpwdllavefiltercontainer_Class',ctrl:'HISTPWDLLAVEFILTERCONTAINER',prop:'Class'},{av:'edtavChistpwdllave_Visible',ctrl:'vCHISTPWDLLAVE',prop:'Visible'}]}");
         setEventMetadata("LBLHISTPWDINDFILTER.CLICK","{handler:'E151J1',iparms:[{av:'divHistpwdindfiltercontainer_Class',ctrl:'HISTPWDINDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLHISTPWDINDFILTER.CLICK",",oparms:[{av:'divHistpwdindfiltercontainer_Class',ctrl:'HISTPWDINDFILTERCONTAINER',prop:'Class'},{av:'edtavChistpwdind_Visible',ctrl:'vCHISTPWDIND',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E191J2',iparms:[{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9',hsh:true},{av:'A62HisPwdFecha',fld:'HISPWDFECHA',pic:'99/99/9999 99:99:99',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV11pUsuariosId',fld:'vPUSUARIOSID',pic:'ZZZZZ9'},{av:'AV12pHisPwdFecha',fld:'vPHISPWDFECHA',pic:'99/99/9999 99:99:99'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUsuariosId',fld:'vCUSUARIOSID',pic:'ZZZZZ9'},{av:'AV7cHisPwdFecha',fld:'vCHISPWDFECHA',pic:'99/99/9999 99:99:99'},{av:'AV8cHistPwdConstra',fld:'vCHISTPWDCONSTRA',pic:''},{av:'AV9cHistPwdLlave',fld:'vCHISTPWDLLAVE',pic:''},{av:'AV10cHistPwdInd',fld:'vCHISTPWDIND',pic:'9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUsuariosId',fld:'vCUSUARIOSID',pic:'ZZZZZ9'},{av:'AV7cHisPwdFecha',fld:'vCHISPWDFECHA',pic:'99/99/9999 99:99:99'},{av:'AV8cHistPwdConstra',fld:'vCHISTPWDCONSTRA',pic:''},{av:'AV9cHistPwdLlave',fld:'vCHISTPWDLLAVE',pic:''},{av:'AV10cHistPwdInd',fld:'vCHISTPWDIND',pic:'9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUsuariosId',fld:'vCUSUARIOSID',pic:'ZZZZZ9'},{av:'AV7cHisPwdFecha',fld:'vCHISPWDFECHA',pic:'99/99/9999 99:99:99'},{av:'AV8cHistPwdConstra',fld:'vCHISTPWDCONSTRA',pic:''},{av:'AV9cHistPwdLlave',fld:'vCHISTPWDLLAVE',pic:''},{av:'AV10cHistPwdInd',fld:'vCHISTPWDIND',pic:'9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUsuariosId',fld:'vCUSUARIOSID',pic:'ZZZZZ9'},{av:'AV7cHisPwdFecha',fld:'vCHISPWDFECHA',pic:'99/99/9999 99:99:99'},{av:'AV8cHistPwdConstra',fld:'vCHISTPWDCONSTRA',pic:''},{av:'AV9cHistPwdLlave',fld:'vCHISTPWDLLAVE',pic:''},{av:'AV10cHistPwdInd',fld:'vCHISTPWDIND',pic:'9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CHISPWDFECHA","{handler:'Validv_Chispwdfecha',iparms:[]");
         setEventMetadata("VALIDV_CHISPWDFECHA",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Histpwdllave',iparms:[]");
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
         AV7cHisPwdFecha = (DateTime)(DateTime.MinValue);
         AV8cHistPwdConstra = "";
         AV9cHistPwdLlave = "";
         AV12pHisPwdFecha = (DateTime)(DateTime.MinValue);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblusuariosidfilter_Jsonclick = "";
         TempTags = "";
         lblLblhispwdfechafilter_Jsonclick = "";
         lblLblhistpwdconstrafilter_Jsonclick = "";
         lblLblhistpwdllavefilter_Jsonclick = "";
         lblLblhistpwdindfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A62HisPwdFecha = (DateTime)(DateTime.MinValue);
         A110HistPwdConstra = "";
         A111HistPwdLlave = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV16Linkselection_GXI = "";
         scmdbuf = "";
         lV8cHistPwdConstra = "";
         lV9cHistPwdLlave = "";
         H001J2_A73HistPwdInd = new short[1] ;
         H001J2_A111HistPwdLlave = new String[] {""} ;
         H001J2_A110HistPwdConstra = new String[] {""} ;
         H001J2_A62HisPwdFecha = new DateTime[] {DateTime.MinValue} ;
         H001J2_A11UsuariosId = new int[1] ;
         H001J3_AGRID1_nRecordCount = new long[1] ;
         AV13ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00c0__default(),
            new Object[][] {
                new Object[] {
               H001J2_A73HistPwdInd, H001J2_A111HistPwdLlave, H001J2_A110HistPwdConstra, H001J2_A62HisPwdFecha, H001J2_A11UsuariosId
               }
               , new Object[] {
               H001J3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV10cHistPwdInd ;
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
      private short A73HistPwdInd ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_64 ;
      private int nGXsfl_64_idx=1 ;
      private int subGrid1_Rows ;
      private int AV6cUsuariosId ;
      private int AV11pUsuariosId ;
      private int edtavCusuariosid_Enabled ;
      private int edtavCusuariosid_Visible ;
      private int edtavChispwdfecha_Enabled ;
      private int edtavChistpwdconstra_Visible ;
      private int edtavChistpwdconstra_Enabled ;
      private int edtavChistpwdllave_Visible ;
      private int edtavChistpwdllave_Enabled ;
      private int edtavChistpwdind_Enabled ;
      private int edtavChistpwdind_Visible ;
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
      private String divHispwdfechafiltercontainer_Class ;
      private String divHistpwdconstrafiltercontainer_Class ;
      private String divHistpwdllavefiltercontainer_Class ;
      private String divHistpwdindfiltercontainer_Class ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_64_idx="0001" ;
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
      private String divHispwdfechafiltercontainer_Internalname ;
      private String lblLblhispwdfechafilter_Internalname ;
      private String lblLblhispwdfechafilter_Jsonclick ;
      private String edtavChispwdfecha_Internalname ;
      private String edtavChispwdfecha_Jsonclick ;
      private String divHistpwdconstrafiltercontainer_Internalname ;
      private String lblLblhistpwdconstrafilter_Internalname ;
      private String lblLblhistpwdconstrafilter_Jsonclick ;
      private String edtavChistpwdconstra_Internalname ;
      private String edtavChistpwdconstra_Jsonclick ;
      private String divHistpwdllavefiltercontainer_Internalname ;
      private String lblLblhistpwdllavefilter_Internalname ;
      private String lblLblhistpwdllavefilter_Jsonclick ;
      private String edtavChistpwdllave_Internalname ;
      private String edtavChistpwdllave_Jsonclick ;
      private String divHistpwdindfiltercontainer_Internalname ;
      private String lblLblhistpwdindfilter_Internalname ;
      private String lblLblhistpwdindfilter_Jsonclick ;
      private String edtavChistpwdind_Internalname ;
      private String edtavChistpwdind_Jsonclick ;
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
      private String edtHistPwdConstra_Link ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavLinkselection_Internalname ;
      private String edtUsuariosId_Internalname ;
      private String edtHisPwdFecha_Internalname ;
      private String edtHistPwdConstra_Internalname ;
      private String edtHistPwdLlave_Internalname ;
      private String scmdbuf ;
      private String AV13ADVANCED_LABEL_TEMPLATE ;
      private String sGXsfl_64_fel_idx="0001" ;
      private String sImgUrl ;
      private String ROClassString ;
      private String edtUsuariosId_Jsonclick ;
      private String edtHisPwdFecha_Jsonclick ;
      private String edtHistPwdConstra_Jsonclick ;
      private String edtHistPwdLlave_Jsonclick ;
      private DateTime AV7cHisPwdFecha ;
      private DateTime AV12pHisPwdFecha ;
      private DateTime A62HisPwdFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private String AV8cHistPwdConstra ;
      private String AV9cHistPwdLlave ;
      private String A110HistPwdConstra ;
      private String A111HistPwdLlave ;
      private String AV16Linkselection_GXI ;
      private String lV8cHistPwdConstra ;
      private String lV9cHistPwdLlave ;
      private String AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H001J2_A73HistPwdInd ;
      private String[] H001J2_A111HistPwdLlave ;
      private String[] H001J2_A110HistPwdConstra ;
      private DateTime[] H001J2_A62HisPwdFecha ;
      private int[] H001J2_A11UsuariosId ;
      private long[] H001J3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int aP0_pUsuariosId ;
      private DateTime aP1_pHisPwdFecha ;
      private GXWebForm Form ;
   }

   public class gx00c0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001J2( IGxContext context ,
                                             String AV8cHistPwdConstra ,
                                             String AV9cHistPwdLlave ,
                                             short AV10cHistPwdInd ,
                                             String A110HistPwdConstra ,
                                             String A111HistPwdLlave ,
                                             short A73HistPwdInd ,
                                             int AV6cUsuariosId ,
                                             DateTime AV7cHisPwdFecha )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int1 ;
         GXv_int1 = new short [7] ;
         Object[] GXv_Object2 ;
         GXv_Object2 = new Object [2] ;
         String sSelectString ;
         String sFromString ;
         String sOrderString ;
         sSelectString = " `HistPwdInd`, `HistPwdLlave`, `HistPwdConstra`, `HisPwdFecha`, `UsuariosId`";
         sFromString = " FROM `HistPwd`";
         sOrderString = "";
         sWhereString = sWhereString + " WHERE (`UsuariosId` >= ? and `HisPwdFecha` >= ?)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cHistPwdConstra)) )
         {
            sWhereString = sWhereString + " and (`HistPwdConstra` like ?)";
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cHistPwdLlave)) )
         {
            sWhereString = sWhereString + " and (`HistPwdLlave` like ?)";
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV10cHistPwdInd) )
         {
            sWhereString = sWhereString + " and (`HistPwdInd` >= ?)";
         }
         else
         {
            GXv_int1[4] = 1;
         }
         sOrderString = sOrderString + " ORDER BY `UsuariosId`, `HisPwdFecha`";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " LIMIT " + "?" + ", " + "?";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H001J3( IGxContext context ,
                                             String AV8cHistPwdConstra ,
                                             String AV9cHistPwdLlave ,
                                             short AV10cHistPwdInd ,
                                             String A110HistPwdConstra ,
                                             String A111HistPwdLlave ,
                                             short A73HistPwdInd ,
                                             int AV6cUsuariosId ,
                                             DateTime AV7cHisPwdFecha )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int3 ;
         GXv_int3 = new short [5] ;
         Object[] GXv_Object4 ;
         GXv_Object4 = new Object [2] ;
         scmdbuf = "SELECT COUNT(*) FROM `HistPwd`";
         scmdbuf = scmdbuf + " WHERE (`UsuariosId` >= ? and `HisPwdFecha` >= ?)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cHistPwdConstra)) )
         {
            sWhereString = sWhereString + " and (`HistPwdConstra` like ?)";
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cHistPwdLlave)) )
         {
            sWhereString = sWhereString + " and (`HistPwdLlave` like ?)";
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV10cHistPwdInd) )
         {
            sWhereString = sWhereString + " and (`HistPwdInd` >= ?)";
         }
         else
         {
            GXv_int3[4] = 1;
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
                     return conditional_H001J2(context, (String)dynConstraints[0] , (String)dynConstraints[1] , (short)dynConstraints[2] , (String)dynConstraints[3] , (String)dynConstraints[4] , (short)dynConstraints[5] , (int)dynConstraints[6] , (DateTime)dynConstraints[7] );
               case 1 :
                     return conditional_H001J3(context, (String)dynConstraints[0] , (String)dynConstraints[1] , (short)dynConstraints[2] , (String)dynConstraints[3] , (String)dynConstraints[4] , (short)dynConstraints[5] , (int)dynConstraints[6] , (DateTime)dynConstraints[7] );
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
          Object[] prmH001J2 ;
          prmH001J2 = new Object[] {
          new Object[] {"AV6cUsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"AV7cHisPwdFecha",System.Data.DbType.DateTime,10,8} ,
          new Object[] {"lV8cHistPwdConstra",System.Data.DbType.String,32,0} ,
          new Object[] {"lV9cHistPwdLlave",System.Data.DbType.String,32,0} ,
          new Object[] {"AV10cHistPwdInd",System.Data.DbType.Byte,1,0} ,
          new Object[] {"GXPagingFrom2",System.Data.DbType.Int32,9,0} ,
          new Object[] {"GXPagingTo2",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmH001J3 ;
          prmH001J3 = new Object[] {
          new Object[] {"AV6cUsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"AV7cHisPwdFecha",System.Data.DbType.DateTime,10,8} ,
          new Object[] {"lV8cHistPwdConstra",System.Data.DbType.String,32,0} ,
          new Object[] {"lV9cHistPwdLlave",System.Data.DbType.String,32,0} ,
          new Object[] {"AV10cHistPwdInd",System.Data.DbType.Byte,1,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H001J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001J2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H001J3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001J3,1, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4) ;
                ((int[]) buf[4])[0] = rslt.getInt(5) ;
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
                   stmt.SetParameter(sIdx, (int)parms[7]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameterDatetime(sIdx, (DateTime)parms[8]);
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
                   stmt.SetParameter(sIdx, (short)parms[11]);
                }
                if ( (short)parms[5] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[12]);
                }
                if ( (short)parms[6] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[13]);
                }
                return;
             case 1 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[5]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameterDatetime(sIdx, (DateTime)parms[6]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[7]);
                }
                if ( (short)parms[3] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[8]);
                }
                if ( (short)parms[4] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (short)parms[9]);
                }
                return;
       }
    }

 }

}
