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
   public class security : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 16_0_11-147071", 0) ;
            }
            Form.Meta.addItem("description", "Security", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSecurityIdentifier_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public security( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public security( IGxContext context )
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

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "WWAdvancedContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "TableTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Security", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_Security.htm");
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
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 ToolbarCellClass", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Security.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Security.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Security.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Security.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Security.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCellAdvanced", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSecurityIdentifier_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecurityIdentifier_Internalname, "Security Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecurityIdentifier_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A78SecurityIdentifier), 6, 0, ",", "")), ((edtSecurityIdentifier_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A78SecurityIdentifier), "ZZZZZ9")) : context.localUtil.Format( (decimal)(A78SecurityIdentifier), "ZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecurityIdentifier_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSecurityIdentifier_Enabled, 0, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "NumId", "right", false, "", "HLP_Security.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSecurityRandom_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecurityRandom_Internalname, "Random Session Number", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecurityRandom_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A80SecurityRandom), 10, 0, ",", "")), ((edtSecurityRandom_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A80SecurityRandom), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A80SecurityRandom), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecurityRandom_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSecurityRandom_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Security.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSecurityDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecurityDate_Internalname, "Session Date Beginning", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSecurityDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSecurityDate_Internalname, context.localUtil.TToC( A79SecurityDate, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A79SecurityDate, "99/99/99 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',8,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',8,24,'spa',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecurityDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSecurityDate_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Security.htm");
         GxWebStd.gx_bitmap( context, edtSecurityDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSecurityDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Security.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Security.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Security.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Security.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z78SecurityIdentifier = (int)(context.localUtil.CToN( cgiGet( "Z78SecurityIdentifier"), ",", "."));
            Z80SecurityRandom = (long)(context.localUtil.CToN( cgiGet( "Z80SecurityRandom"), ",", "."));
            Z79SecurityDate = context.localUtil.CToT( cgiGet( "Z79SecurityDate"), 0);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtSecurityIdentifier_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSecurityIdentifier_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SECURITYIDENTIFIER");
               AnyError = 1;
               GX_FocusControl = edtSecurityIdentifier_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A78SecurityIdentifier = 0;
               AssignAttri("", false, "A78SecurityIdentifier", StringUtil.LTrimStr( (decimal)(A78SecurityIdentifier), 6, 0));
            }
            else
            {
               A78SecurityIdentifier = (int)(context.localUtil.CToN( cgiGet( edtSecurityIdentifier_Internalname), ",", "."));
               AssignAttri("", false, "A78SecurityIdentifier", StringUtil.LTrimStr( (decimal)(A78SecurityIdentifier), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSecurityRandom_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSecurityRandom_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SECURITYRANDOM");
               AnyError = 1;
               GX_FocusControl = edtSecurityRandom_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A80SecurityRandom = 0;
               AssignAttri("", false, "A80SecurityRandom", StringUtil.LTrimStr( (decimal)(A80SecurityRandom), 10, 0));
            }
            else
            {
               A80SecurityRandom = (long)(context.localUtil.CToN( cgiGet( edtSecurityRandom_Internalname), ",", "."));
               AssignAttri("", false, "A80SecurityRandom", StringUtil.LTrimStr( (decimal)(A80SecurityRandom), 10, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtSecurityDate_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Session Date Beginning"}), 1, "SECURITYDATE");
               AnyError = 1;
               GX_FocusControl = edtSecurityDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A79SecurityDate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A79SecurityDate", context.localUtil.TToC( A79SecurityDate, 8, 8, 0, 3, "/", ":", " "));
            }
            else
            {
               A79SecurityDate = context.localUtil.CToT( cgiGet( edtSecurityDate_Internalname));
               AssignAttri("", false, "A79SecurityDate", context.localUtil.TToC( A79SecurityDate, 8, 8, 0, 3, "/", ":", " "));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A78SecurityIdentifier = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignAttri("", false, "A78SecurityIdentifier", StringUtil.LTrimStr( (decimal)(A78SecurityIdentifier), 6, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0G18( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override String ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes0G18( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void ResetCaption0G0( )
      {
      }

      protected void ZM0G18( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z80SecurityRandom = T000G3_A80SecurityRandom[0];
               Z79SecurityDate = T000G3_A79SecurityDate[0];
            }
            else
            {
               Z80SecurityRandom = A80SecurityRandom;
               Z79SecurityDate = A79SecurityDate;
            }
         }
         if ( GX_JID == -2 )
         {
            Z78SecurityIdentifier = A78SecurityIdentifier;
            Z80SecurityRandom = A80SecurityRandom;
            Z79SecurityDate = A79SecurityDate;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load0G18( )
      {
         /* Using cursor T000G4 */
         pr_default.execute(2, new Object[] {A78SecurityIdentifier});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound18 = 1;
            A80SecurityRandom = T000G4_A80SecurityRandom[0];
            AssignAttri("", false, "A80SecurityRandom", StringUtil.LTrimStr( (decimal)(A80SecurityRandom), 10, 0));
            A79SecurityDate = T000G4_A79SecurityDate[0];
            AssignAttri("", false, "A79SecurityDate", context.localUtil.TToC( A79SecurityDate, 8, 8, 0, 3, "/", ":", " "));
            ZM0G18( -2) ;
         }
         pr_default.close(2);
         OnLoadActions0G18( ) ;
      }

      protected void OnLoadActions0G18( )
      {
      }

      protected void CheckExtendedTable0G18( )
      {
         nIsDirty_18 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A79SecurityDate) || ( A79SecurityDate >= context.localUtil.YMDHMSToT( 1000, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Session Date Beginning fuera de rango", "OutOfRange", 1, "SECURITYDATE");
            AnyError = 1;
            GX_FocusControl = edtSecurityDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0G18( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0G18( )
      {
         /* Using cursor T000G5 */
         pr_default.execute(3, new Object[] {A78SecurityIdentifier});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound18 = 1;
         }
         else
         {
            RcdFound18 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000G3 */
         pr_default.execute(1, new Object[] {A78SecurityIdentifier});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0G18( 2) ;
            RcdFound18 = 1;
            A78SecurityIdentifier = T000G3_A78SecurityIdentifier[0];
            AssignAttri("", false, "A78SecurityIdentifier", StringUtil.LTrimStr( (decimal)(A78SecurityIdentifier), 6, 0));
            A80SecurityRandom = T000G3_A80SecurityRandom[0];
            AssignAttri("", false, "A80SecurityRandom", StringUtil.LTrimStr( (decimal)(A80SecurityRandom), 10, 0));
            A79SecurityDate = T000G3_A79SecurityDate[0];
            AssignAttri("", false, "A79SecurityDate", context.localUtil.TToC( A79SecurityDate, 8, 8, 0, 3, "/", ":", " "));
            Z78SecurityIdentifier = A78SecurityIdentifier;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0G18( ) ;
            if ( AnyError == 1 )
            {
               RcdFound18 = 0;
               InitializeNonKey0G18( ) ;
            }
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound18 = 0;
            InitializeNonKey0G18( ) ;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0G18( ) ;
         if ( RcdFound18 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound18 = 0;
         /* Using cursor T000G6 */
         pr_default.execute(4, new Object[] {A78SecurityIdentifier});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000G6_A78SecurityIdentifier[0] < A78SecurityIdentifier ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000G6_A78SecurityIdentifier[0] > A78SecurityIdentifier ) ) )
            {
               A78SecurityIdentifier = T000G6_A78SecurityIdentifier[0];
               AssignAttri("", false, "A78SecurityIdentifier", StringUtil.LTrimStr( (decimal)(A78SecurityIdentifier), 6, 0));
               RcdFound18 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound18 = 0;
         /* Using cursor T000G7 */
         pr_default.execute(5, new Object[] {A78SecurityIdentifier});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000G7_A78SecurityIdentifier[0] > A78SecurityIdentifier ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000G7_A78SecurityIdentifier[0] < A78SecurityIdentifier ) ) )
            {
               A78SecurityIdentifier = T000G7_A78SecurityIdentifier[0];
               AssignAttri("", false, "A78SecurityIdentifier", StringUtil.LTrimStr( (decimal)(A78SecurityIdentifier), 6, 0));
               RcdFound18 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0G18( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSecurityIdentifier_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0G18( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound18 == 1 )
            {
               if ( A78SecurityIdentifier != Z78SecurityIdentifier )
               {
                  A78SecurityIdentifier = Z78SecurityIdentifier;
                  AssignAttri("", false, "A78SecurityIdentifier", StringUtil.LTrimStr( (decimal)(A78SecurityIdentifier), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SECURITYIDENTIFIER");
                  AnyError = 1;
                  GX_FocusControl = edtSecurityIdentifier_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSecurityIdentifier_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0G18( ) ;
                  GX_FocusControl = edtSecurityIdentifier_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A78SecurityIdentifier != Z78SecurityIdentifier )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtSecurityIdentifier_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0G18( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SECURITYIDENTIFIER");
                     AnyError = 1;
                     GX_FocusControl = edtSecurityIdentifier_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtSecurityIdentifier_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0G18( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A78SecurityIdentifier != Z78SecurityIdentifier )
         {
            A78SecurityIdentifier = Z78SecurityIdentifier;
            AssignAttri("", false, "A78SecurityIdentifier", StringUtil.LTrimStr( (decimal)(A78SecurityIdentifier), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SECURITYIDENTIFIER");
            AnyError = 1;
            GX_FocusControl = edtSecurityIdentifier_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSecurityIdentifier_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseOpenCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "SECURITYIDENTIFIER");
            AnyError = 1;
            GX_FocusControl = edtSecurityIdentifier_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtSecurityRandom_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0G18( ) ;
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSecurityRandom_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0G18( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSecurityRandom_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSecurityRandom_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0G18( ) ;
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound18 != 0 )
            {
               ScanNext0G18( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSecurityRandom_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0G18( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0G18( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000G2 */
            pr_default.execute(0, new Object[] {A78SecurityIdentifier});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Security"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z80SecurityRandom != T000G2_A80SecurityRandom[0] ) || ( Z79SecurityDate != T000G2_A79SecurityDate[0] ) )
            {
               if ( Z80SecurityRandom != T000G2_A80SecurityRandom[0] )
               {
                  GXUtil.WriteLog("security:[seudo value changed for attri]"+"SecurityRandom");
                  GXUtil.WriteLogRaw("Old: ",Z80SecurityRandom);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A80SecurityRandom[0]);
               }
               if ( Z79SecurityDate != T000G2_A79SecurityDate[0] )
               {
                  GXUtil.WriteLog("security:[seudo value changed for attri]"+"SecurityDate");
                  GXUtil.WriteLogRaw("Old: ",Z79SecurityDate);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A79SecurityDate[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Security"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0G18( )
      {
         BeforeValidate0G18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G18( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0G18( 0) ;
            CheckOptimisticConcurrency0G18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0G18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G8 */
                     pr_default.execute(6, new Object[] {A78SecurityIdentifier, A80SecurityRandom, A79SecurityDate});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Security") ;
                     if ( (pr_default.getStatus(6) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0G0( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0G18( ) ;
            }
            EndLevel0G18( ) ;
         }
         CloseExtendedTableCursors0G18( ) ;
      }

      protected void Update0G18( )
      {
         BeforeValidate0G18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G18( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0G18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G9 */
                     pr_default.execute(7, new Object[] {A80SecurityRandom, A79SecurityDate, A78SecurityIdentifier});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("Security") ;
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Security"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0G18( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0G0( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0G18( ) ;
         }
         CloseExtendedTableCursors0G18( ) ;
      }

      protected void DeferredUpdate0G18( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0G18( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G18( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0G18( ) ;
            AfterConfirm0G18( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0G18( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000G10 */
                  pr_default.execute(8, new Object[] {A78SecurityIdentifier});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("Security") ;
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound18 == 0 )
                        {
                           InitAll0G18( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption0G0( ) ;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode18 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0G18( ) ;
         Gx_mode = sMode18;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0G18( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0G18( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0G18( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("security",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0G0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("security",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0G18( )
      {
         /* Using cursor T000G11 */
         pr_default.execute(9);
         RcdFound18 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound18 = 1;
            A78SecurityIdentifier = T000G11_A78SecurityIdentifier[0];
            AssignAttri("", false, "A78SecurityIdentifier", StringUtil.LTrimStr( (decimal)(A78SecurityIdentifier), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0G18( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound18 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound18 = 1;
            A78SecurityIdentifier = T000G11_A78SecurityIdentifier[0];
            AssignAttri("", false, "A78SecurityIdentifier", StringUtil.LTrimStr( (decimal)(A78SecurityIdentifier), 6, 0));
         }
      }

      protected void ScanEnd0G18( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0G18( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0G18( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0G18( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0G18( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0G18( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0G18( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0G18( )
      {
         edtSecurityIdentifier_Enabled = 0;
         AssignProp("", false, edtSecurityIdentifier_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecurityIdentifier_Enabled), 5, 0), true);
         edtSecurityRandom_Enabled = 0;
         AssignProp("", false, edtSecurityRandom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecurityRandom_Enabled), 5, 0), true);
         edtSecurityDate_Enabled = 0;
         AssignProp("", false, edtSecurityDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecurityDate_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0G18( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0G0( )
      {
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
         MasterPageObj.master_styles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 2036420), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202262714344092", false, true);
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
         bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle = bodyStyle + " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("security.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z78SecurityIdentifier", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z78SecurityIdentifier), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z80SecurityRandom", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z80SecurityRandom), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z79SecurityDate", context.localUtil.TToC( Z79SecurityDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         return formatLink("security.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "Security" ;
      }

      public override String GetPgmdesc( )
      {
         return "Security" ;
      }

      protected void InitializeNonKey0G18( )
      {
         A80SecurityRandom = 0;
         AssignAttri("", false, "A80SecurityRandom", StringUtil.LTrimStr( (decimal)(A80SecurityRandom), 10, 0));
         A79SecurityDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A79SecurityDate", context.localUtil.TToC( A79SecurityDate, 8, 8, 0, 3, "/", ":", " "));
         Z80SecurityRandom = 0;
         Z79SecurityDate = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll0G18( )
      {
         A78SecurityIdentifier = 0;
         AssignAttri("", false, "A78SecurityIdentifier", StringUtil.LTrimStr( (decimal)(A78SecurityIdentifier), 6, 0));
         InitializeNonKey0G18( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714344094", true, true);
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
         context.AddJavascriptSource("security.js", "?202262714344094", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtSecurityIdentifier_Internalname = "SECURITYIDENTIFIER";
         edtSecurityRandom_Internalname = "SECURITYRANDOM";
         edtSecurityDate_Internalname = "SECURITYDATE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Security";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtSecurityDate_Jsonclick = "";
         edtSecurityDate_Enabled = 1;
         edtSecurityRandom_Jsonclick = "";
         edtSecurityRandom_Enabled = 1;
         edtSecurityIdentifier_Jsonclick = "";
         edtSecurityIdentifier_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtSecurityRandom_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Securityidentifier( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A80SecurityRandom", StringUtil.LTrim( StringUtil.NToC( (decimal)(A80SecurityRandom), 10, 0, ".", "")));
         AssignAttri("", false, "A79SecurityDate", context.localUtil.TToC( A79SecurityDate, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z78SecurityIdentifier", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z78SecurityIdentifier), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z80SecurityRandom", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z80SecurityRandom), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z79SecurityDate", context.localUtil.TToC( Z79SecurityDate, 10, 8, 0, 3, "/", ":", " "));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_SECURITYIDENTIFIER","{handler:'Valid_Securityidentifier',iparms:[{av:'A78SecurityIdentifier',fld:'SECURITYIDENTIFIER',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_SECURITYIDENTIFIER",",oparms:[{av:'A80SecurityRandom',fld:'SECURITYRANDOM',pic:'ZZZZZZZZZ9'},{av:'A79SecurityDate',fld:'SECURITYDATE',pic:'99/99/99 99:99:99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z78SecurityIdentifier'},{av:'Z80SecurityRandom'},{av:'Z79SecurityDate'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_SECURITYDATE","{handler:'Valid_Securitydate',iparms:[]");
         setEventMetadata("VALID_SECURITYDATE",",oparms:[]}");
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
         pr_default.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z79SecurityDate = (DateTime)(DateTime.MinValue);
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A79SecurityDate = (DateTime)(DateTime.MinValue);
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T000G4_A78SecurityIdentifier = new int[1] ;
         T000G4_A80SecurityRandom = new long[1] ;
         T000G4_A79SecurityDate = new DateTime[] {DateTime.MinValue} ;
         T000G5_A78SecurityIdentifier = new int[1] ;
         T000G3_A78SecurityIdentifier = new int[1] ;
         T000G3_A80SecurityRandom = new long[1] ;
         T000G3_A79SecurityDate = new DateTime[] {DateTime.MinValue} ;
         sMode18 = "";
         T000G6_A78SecurityIdentifier = new int[1] ;
         T000G7_A78SecurityIdentifier = new int[1] ;
         T000G2_A78SecurityIdentifier = new int[1] ;
         T000G2_A80SecurityRandom = new long[1] ;
         T000G2_A79SecurityDate = new DateTime[] {DateTime.MinValue} ;
         T000G11_A78SecurityIdentifier = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ79SecurityDate = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.security__default(),
            new Object[][] {
                new Object[] {
               T000G2_A78SecurityIdentifier, T000G2_A80SecurityRandom, T000G2_A79SecurityDate
               }
               , new Object[] {
               T000G3_A78SecurityIdentifier, T000G3_A80SecurityRandom, T000G3_A79SecurityDate
               }
               , new Object[] {
               T000G4_A78SecurityIdentifier, T000G4_A80SecurityRandom, T000G4_A79SecurityDate
               }
               , new Object[] {
               T000G5_A78SecurityIdentifier
               }
               , new Object[] {
               T000G6_A78SecurityIdentifier
               }
               , new Object[] {
               T000G7_A78SecurityIdentifier
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000G11_A78SecurityIdentifier
               }
            }
         );
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short GX_JID ;
      private short RcdFound18 ;
      private short nIsDirty_18 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z78SecurityIdentifier ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A78SecurityIdentifier ;
      private int edtSecurityIdentifier_Enabled ;
      private int edtSecurityRandom_Enabled ;
      private int edtSecurityDate_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ78SecurityIdentifier ;
      private long Z80SecurityRandom ;
      private long A80SecurityRandom ;
      private long ZZ80SecurityRandom ;
      private String sPrefix ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String GXKey ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String GX_FocusControl ;
      private String edtSecurityIdentifier_Internalname ;
      private String divMaintable_Internalname ;
      private String divTitlecontainer_Internalname ;
      private String lblTitle_Internalname ;
      private String lblTitle_Jsonclick ;
      private String ClassString ;
      private String StyleString ;
      private String divFormcontainer_Internalname ;
      private String divToolbarcell_Internalname ;
      private String TempTags ;
      private String bttBtn_first_Internalname ;
      private String bttBtn_first_Jsonclick ;
      private String bttBtn_previous_Internalname ;
      private String bttBtn_previous_Jsonclick ;
      private String bttBtn_next_Internalname ;
      private String bttBtn_next_Jsonclick ;
      private String bttBtn_last_Internalname ;
      private String bttBtn_last_Jsonclick ;
      private String bttBtn_select_Internalname ;
      private String bttBtn_select_Jsonclick ;
      private String edtSecurityIdentifier_Jsonclick ;
      private String edtSecurityRandom_Internalname ;
      private String edtSecurityRandom_Jsonclick ;
      private String edtSecurityDate_Internalname ;
      private String edtSecurityDate_Jsonclick ;
      private String bttBtn_enter_Internalname ;
      private String bttBtn_enter_Jsonclick ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String bttBtn_delete_Internalname ;
      private String bttBtn_delete_Jsonclick ;
      private String Gx_mode ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String endTrnMsgTxt ;
      private String endTrnMsgCod ;
      private String sMode18 ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private DateTime Z79SecurityDate ;
      private DateTime A79SecurityDate ;
      private DateTime ZZ79SecurityDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T000G4_A78SecurityIdentifier ;
      private long[] T000G4_A80SecurityRandom ;
      private DateTime[] T000G4_A79SecurityDate ;
      private int[] T000G5_A78SecurityIdentifier ;
      private int[] T000G3_A78SecurityIdentifier ;
      private long[] T000G3_A80SecurityRandom ;
      private DateTime[] T000G3_A79SecurityDate ;
      private int[] T000G6_A78SecurityIdentifier ;
      private int[] T000G7_A78SecurityIdentifier ;
      private int[] T000G2_A78SecurityIdentifier ;
      private long[] T000G2_A80SecurityRandom ;
      private DateTime[] T000G2_A79SecurityDate ;
      private int[] T000G11_A78SecurityIdentifier ;
      private GXWebForm Form ;
   }

   public class security__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000G4 ;
          prmT000G4 = new Object[] {
          new Object[] {"SecurityIdentifier",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000G5 ;
          prmT000G5 = new Object[] {
          new Object[] {"SecurityIdentifier",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000G3 ;
          prmT000G3 = new Object[] {
          new Object[] {"SecurityIdentifier",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000G6 ;
          prmT000G6 = new Object[] {
          new Object[] {"SecurityIdentifier",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000G7 ;
          prmT000G7 = new Object[] {
          new Object[] {"SecurityIdentifier",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000G2 ;
          prmT000G2 = new Object[] {
          new Object[] {"SecurityIdentifier",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000G8 ;
          prmT000G8 = new Object[] {
          new Object[] {"SecurityIdentifier",System.Data.DbType.Int32,6,0} ,
          new Object[] {"SecurityRandom",System.Data.DbType.Int64,10,0} ,
          new Object[] {"SecurityDate",System.Data.DbType.DateTime,8,8}
          } ;
          Object[] prmT000G9 ;
          prmT000G9 = new Object[] {
          new Object[] {"SecurityRandom",System.Data.DbType.Int64,10,0} ,
          new Object[] {"SecurityDate",System.Data.DbType.DateTime,8,8} ,
          new Object[] {"SecurityIdentifier",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000G10 ;
          prmT000G10 = new Object[] {
          new Object[] {"SecurityIdentifier",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000G11 ;
          prmT000G11 = new Object[] {
          } ;
          def= new CursorDef[] {
              new CursorDef("T000G2", "SELECT `SecurityIdentifier`, `SecurityRandom`, `SecurityDate` FROM `Security` WHERE `SecurityIdentifier` = ?  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G3", "SELECT `SecurityIdentifier`, `SecurityRandom`, `SecurityDate` FROM `Security` WHERE `SecurityIdentifier` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G4", "SELECT TM1.`SecurityIdentifier`, TM1.`SecurityRandom`, TM1.`SecurityDate` FROM `Security` TM1 WHERE TM1.`SecurityIdentifier` = ? ORDER BY TM1.`SecurityIdentifier` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G5", "SELECT `SecurityIdentifier` FROM `Security` WHERE `SecurityIdentifier` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G6", "SELECT `SecurityIdentifier` FROM `Security` WHERE ( `SecurityIdentifier` > ?) ORDER BY `SecurityIdentifier`  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000G6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000G7", "SELECT `SecurityIdentifier` FROM `Security` WHERE ( `SecurityIdentifier` < ?) ORDER BY `SecurityIdentifier` DESC  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000G7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000G8", "INSERT INTO `Security`(`SecurityIdentifier`, `SecurityRandom`, `SecurityDate`) VALUES(?, ?, ?)", GxErrorMask.GX_NOMASK,prmT000G8)
             ,new CursorDef("T000G9", "UPDATE `Security` SET `SecurityRandom`=?, `SecurityDate`=?  WHERE `SecurityIdentifier` = ?", GxErrorMask.GX_NOMASK,prmT000G9)
             ,new CursorDef("T000G10", "DELETE FROM `Security`  WHERE `SecurityIdentifier` = ?", GxErrorMask.GX_NOMASK,prmT000G10)
             ,new CursorDef("T000G11", "SELECT `SecurityIdentifier` FROM `Security` ORDER BY `SecurityIdentifier` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G11,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2) ;
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3) ;
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((long[]) buf[1])[0] = rslt.getLong(2) ;
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3) ;
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((long[]) buf[1])[0] = rslt.getLong(2) ;
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3) ;
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 9 :
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
             case 0 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 1 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 2 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 3 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 4 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 5 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 6 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (long)parms[1]);
                stmt.SetParameterDatetime(3, (DateTime)parms[2]);
                return;
             case 7 :
                stmt.SetParameter(1, (long)parms[0]);
                stmt.SetParameterDatetime(2, (DateTime)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                return;
             case 8 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

}
