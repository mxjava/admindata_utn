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
   public class menu : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A24RolId = (int)(NumberUtil.Val( GetNextPar( ), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A24RolId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridmenu_rol") == 0 )
         {
            nRC_GXsfl_78 = (int)(NumberUtil.Val( GetNextPar( ), "."));
            nGXsfl_78_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
            sGXsfl_78_idx = GetNextPar( );
            Gx_mode = GetNextPar( );
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridmenu_rol_newrow( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "menu.aspx")), "menu.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "menu.aspx")))) ;
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
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV7MenuXid = (short)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri("", false, "AV7MenuXid", StringUtil.LTrimStr( (decimal)(AV7MenuXid), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vMENUXID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MenuXid), "ZZZ9"), context));
               }
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 16_0_11-147071", 0) ;
            }
            Form.Meta.addItem("description", "Menu", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMenuXDesc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public menu( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public menu( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( String aP0_Gx_mode ,
                           short aP1_MenuXid )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7MenuXid = aP1_MenuXid;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbMenXEst = new GXCombobox();
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

      protected void fix_multi_value_controls( )
      {
         if ( cmbMenXEst.ItemCount > 0 )
         {
            A5MenXEst = cmbMenXEst.getValidValue(A5MenXEst);
            n5MenXEst = false;
            AssignAttri("", false, "A5MenXEst", A5MenXEst);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbMenXEst.CurrentValue = StringUtil.RTrim( A5MenXEst);
            AssignProp("", false, cmbMenXEst_Internalname, "Values", cmbMenXEst.ToJavascriptSource(), true);
         }
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Menu", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_Menu.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Menu.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMenuXid_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMenuXid_Internalname, "Xid", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMenuXid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1MenuXid), 4, 0, ",", "")), ((edtMenuXid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A1MenuXid), "ZZZ9")) : context.localUtil.Format( (decimal)(A1MenuXid), "ZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMenuXid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMenuXid_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMenuXDesc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMenuXDesc_Internalname, "XDesc", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMenuXDesc_Internalname, A2MenuXDesc, StringUtil.RTrim( context.localUtil.Format( A2MenuXDesc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMenuXDesc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMenuXDesc_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMenuXPosi_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMenuXPosi_Internalname, "Position", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMenuXPosi_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3MenuXPosi), 4, 0, ",", "")), ((edtMenuXPosi_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A3MenuXPosi), "ZZZ9")) : context.localUtil.Format( (decimal)(A3MenuXPosi), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMenuXPosi_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMenuXPosi_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMenXUrl_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMenXUrl_Internalname, "Url", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMenXUrl_Internalname, A4MenXUrl, StringUtil.RTrim( context.localUtil.Format( A4MenXUrl, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", A4MenXUrl, "_blank", "", "", edtMenXUrl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMenXUrl_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Url", "left", true, "", "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbMenXEst_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbMenXEst_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbMenXEst, cmbMenXEst_Internalname, StringUtil.RTrim( A5MenXEst), 1, cmbMenXEst_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbMenXEst.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, "HLP_Menu.htm");
         cmbMenXEst.CurrentValue = StringUtil.RTrim( A5MenXEst);
         AssignProp("", false, cmbMenXEst_Internalname, "Values", (String)(cmbMenXEst.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgMenIcono_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Icono", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         A259MenIcono_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A259MenIcono))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000MenIcono_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A259MenIcono)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A259MenIcono)) ? A40000MenIcono_GXI : context.PathToRelativeUrl( A259MenIcono));
         GxWebStd.gx_bitmap( context, imgMenIcono_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgMenIcono_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "", "", "", 0, A259MenIcono_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Menu.htm");
         AssignProp("", false, imgMenIcono_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A259MenIcono)) ? A40000MenIcono_GXI : context.PathToRelativeUrl( A259MenIcono)), true);
         AssignProp("", false, imgMenIcono_Internalname, "IsBlob", StringUtil.BoolToStr( A259MenIcono_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMenPadre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMenPadre_Internalname, "Padre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMenPadre_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A258MenPadre), 4, 0, ",", "")), ((edtMenPadre_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A258MenPadre), "ZZZ9")) : context.localUtil.Format( (decimal)(A258MenPadre), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMenPadre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMenPadre_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDescripcion_Internalname, "Descripcion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDescripcion_Internalname, A262Descripcion, StringUtil.RTrim( context.localUtil.Format( A262Descripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divRoltable_Internalname, 1, 0, "px", 0, "px", "LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlerol_Internalname, "Rol", "", "", lblTitlerol_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridmenu_rol( ) ;
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
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridmenu_rol( )
      {
         /*  Grid Control  */
         Gridmenu_rolContainer.AddObjectProperty("GridName", "Gridmenu_rol");
         Gridmenu_rolContainer.AddObjectProperty("Header", subGridmenu_rol_Header);
         Gridmenu_rolContainer.AddObjectProperty("Class", "Grid");
         Gridmenu_rolContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridmenu_rolContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridmenu_rolContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridmenu_rol_Backcolorstyle), 1, 0, ".", "")));
         Gridmenu_rolContainer.AddObjectProperty("CmpContext", "");
         Gridmenu_rolContainer.AddObjectProperty("InMasterPage", "false");
         Gridmenu_rolColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridmenu_rolColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A24RolId), 9, 0, ".", "")));
         Gridmenu_rolColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRolId_Enabled), 5, 0, ".", "")));
         Gridmenu_rolContainer.AddColumnProperties(Gridmenu_rolColumn);
         Gridmenu_rolColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridmenu_rolColumn.AddObjectProperty("Value", A127RolNombre);
         Gridmenu_rolColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRolNombre_Enabled), 5, 0, ".", "")));
         Gridmenu_rolContainer.AddColumnProperties(Gridmenu_rolColumn);
         Gridmenu_rolColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridmenu_rolColumn.AddObjectProperty("Value", A128RolDescripcion);
         Gridmenu_rolColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRolDescripcion_Enabled), 5, 0, ".", "")));
         Gridmenu_rolContainer.AddColumnProperties(Gridmenu_rolColumn);
         Gridmenu_rolContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridmenu_rol_Selectedindex), 4, 0, ".", "")));
         Gridmenu_rolContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridmenu_rol_Allowselection), 1, 0, ".", "")));
         Gridmenu_rolContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridmenu_rol_Selectioncolor), 9, 0, ".", "")));
         Gridmenu_rolContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridmenu_rol_Allowhovering), 1, 0, ".", "")));
         Gridmenu_rolContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridmenu_rol_Hoveringcolor), 9, 0, ".", "")));
         Gridmenu_rolContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridmenu_rol_Allowcollapsing), 1, 0, ".", "")));
         Gridmenu_rolContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridmenu_rol_Collapsed), 1, 0, ".", "")));
         nGXsfl_78_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount23 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_23 = 1;
               ScanStart0123( ) ;
               while ( RcdFound23 != 0 )
               {
                  init_level_properties23( ) ;
                  getByPrimaryKey0123( ) ;
                  AddRow0123( ) ;
                  ScanNext0123( ) ;
               }
               ScanEnd0123( ) ;
               nBlankRcdCount23 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0123( ) ;
            standaloneModal0123( ) ;
            sMode23 = Gx_mode;
            while ( nGXsfl_78_idx < nRC_GXsfl_78 )
            {
               bGXsfl_78_Refreshing = true;
               ReadRow0123( ) ;
               edtRolId_Enabled = (int)(context.localUtil.CToN( cgiGet( "ROLID_"+sGXsfl_78_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtRolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRolId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               edtRolNombre_Enabled = (int)(context.localUtil.CToN( cgiGet( "ROLNOMBRE_"+sGXsfl_78_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtRolNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRolNombre_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               edtRolDescripcion_Enabled = (int)(context.localUtil.CToN( cgiGet( "ROLDESCRIPCION_"+sGXsfl_78_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtRolDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRolDescripcion_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               if ( ( nRcdExists_23 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0123( ) ;
               }
               SendRow0123( ) ;
               bGXsfl_78_Refreshing = false;
            }
            Gx_mode = sMode23;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount23 = 5;
            nRcdExists_23 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0123( ) ;
               while ( RcdFound23 != 0 )
               {
                  sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_7823( ) ;
                  init_level_properties23( ) ;
                  standaloneNotModal0123( ) ;
                  getByPrimaryKey0123( ) ;
                  standaloneModal0123( ) ;
                  AddRow0123( ) ;
                  ScanNext0123( ) ;
               }
               ScanEnd0123( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode23 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx+1), 4, 0), 4, "0");
            SubsflControlProps_7823( ) ;
            InitAll0123( ) ;
            init_level_properties23( ) ;
            nRcdExists_23 = 0;
            nIsMod_23 = 0;
            nRcdDeleted_23 = 0;
            nBlankRcdCount23 = (short)(nBlankRcdUsr23+nBlankRcdCount23);
            fRowAdded = 0;
            while ( nBlankRcdCount23 > 0 )
            {
               standaloneNotModal0123( ) ;
               standaloneModal0123( ) ;
               AddRow0123( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtRolId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount23 = (short)(nBlankRcdCount23-1);
            }
            Gx_mode = sMode23;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridmenu_rolContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridmenu_rol", Gridmenu_rolContainer);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridmenu_rolContainerData", Gridmenu_rolContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridmenu_rolContainerData"+"V", Gridmenu_rolContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridmenu_rolContainerData"+"V"+"\" value='"+Gridmenu_rolContainer.GridValuesHidden()+"'/>") ;
         }
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
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11012 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z1MenuXid = (short)(context.localUtil.CToN( cgiGet( "Z1MenuXid"), ",", "."));
               Z2MenuXDesc = cgiGet( "Z2MenuXDesc");
               n2MenuXDesc = (String.IsNullOrEmpty(StringUtil.RTrim( A2MenuXDesc)) ? true : false);
               Z3MenuXPosi = (short)(context.localUtil.CToN( cgiGet( "Z3MenuXPosi"), ",", "."));
               n3MenuXPosi = ((0==A3MenuXPosi) ? true : false);
               Z4MenXUrl = cgiGet( "Z4MenXUrl");
               n4MenXUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A4MenXUrl)) ? true : false);
               Z5MenXEst = cgiGet( "Z5MenXEst");
               n5MenXEst = (String.IsNullOrEmpty(StringUtil.RTrim( A5MenXEst)) ? true : false);
               Z258MenPadre = (short)(context.localUtil.CToN( cgiGet( "Z258MenPadre"), ",", "."));
               n258MenPadre = ((0==A258MenPadre) ? true : false);
               Z262Descripcion = cgiGet( "Z262Descripcion");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_78 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_78"), ",", "."));
               AV7MenuXid = (short)(context.localUtil.CToN( cgiGet( "vMENUXID"), ",", "."));
               A40000MenIcono_GXI = cgiGet( "MENICONO_GXI");
               n40000MenIcono_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000MenIcono_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A259MenIcono)) ? true : false);
               AV11Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A1MenuXid = (short)(context.localUtil.CToN( cgiGet( edtMenuXid_Internalname), ",", "."));
               AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
               A2MenuXDesc = cgiGet( edtMenuXDesc_Internalname);
               n2MenuXDesc = false;
               AssignAttri("", false, "A2MenuXDesc", A2MenuXDesc);
               n2MenuXDesc = (String.IsNullOrEmpty(StringUtil.RTrim( A2MenuXDesc)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtMenuXPosi_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMenuXPosi_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MENUXPOSI");
                  AnyError = 1;
                  GX_FocusControl = edtMenuXPosi_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A3MenuXPosi = 0;
                  n3MenuXPosi = false;
                  AssignAttri("", false, "A3MenuXPosi", StringUtil.LTrimStr( (decimal)(A3MenuXPosi), 4, 0));
               }
               else
               {
                  A3MenuXPosi = (short)(context.localUtil.CToN( cgiGet( edtMenuXPosi_Internalname), ",", "."));
                  n3MenuXPosi = false;
                  AssignAttri("", false, "A3MenuXPosi", StringUtil.LTrimStr( (decimal)(A3MenuXPosi), 4, 0));
               }
               n3MenuXPosi = ((0==A3MenuXPosi) ? true : false);
               A4MenXUrl = cgiGet( edtMenXUrl_Internalname);
               n4MenXUrl = false;
               AssignAttri("", false, "A4MenXUrl", A4MenXUrl);
               n4MenXUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A4MenXUrl)) ? true : false);
               cmbMenXEst.Name = cmbMenXEst_Internalname;
               cmbMenXEst.CurrentValue = cgiGet( cmbMenXEst_Internalname);
               A5MenXEst = cgiGet( cmbMenXEst_Internalname);
               n5MenXEst = false;
               AssignAttri("", false, "A5MenXEst", A5MenXEst);
               n5MenXEst = (String.IsNullOrEmpty(StringUtil.RTrim( A5MenXEst)) ? true : false);
               A259MenIcono = cgiGet( imgMenIcono_Internalname);
               n259MenIcono = false;
               AssignAttri("", false, "A259MenIcono", A259MenIcono);
               n259MenIcono = (String.IsNullOrEmpty(StringUtil.RTrim( A259MenIcono)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtMenPadre_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMenPadre_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MENPADRE");
                  AnyError = 1;
                  GX_FocusControl = edtMenPadre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A258MenPadre = 0;
                  n258MenPadre = false;
                  AssignAttri("", false, "A258MenPadre", StringUtil.LTrimStr( (decimal)(A258MenPadre), 4, 0));
               }
               else
               {
                  A258MenPadre = (short)(context.localUtil.CToN( cgiGet( edtMenPadre_Internalname), ",", "."));
                  n258MenPadre = false;
                  AssignAttri("", false, "A258MenPadre", StringUtil.LTrimStr( (decimal)(A258MenPadre), 4, 0));
               }
               n258MenPadre = ((0==A258MenPadre) ? true : false);
               A262Descripcion = cgiGet( edtDescripcion_Internalname);
               AssignAttri("", false, "A262Descripcion", A262Descripcion);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgMenIcono_Internalname, ref  A259MenIcono, ref  A40000MenIcono_GXI);
               n40000MenIcono_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000MenIcono_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A259MenIcono)) ? true : false);
               n259MenIcono = (String.IsNullOrEmpty(StringUtil.RTrim( A259MenIcono)) ? true : false);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Menu");
               A1MenuXid = (short)(context.localUtil.CToN( cgiGet( edtMenuXid_Internalname), ",", "."));
               AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
               forbiddenHiddens.Add("MenuXid", context.localUtil.Format( (decimal)(A1MenuXid), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A1MenuXid != Z1MenuXid ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("menu:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusDescription = 403.ToString();
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A1MenuXid = (short)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode1 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode1;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound1 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_010( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "MENUXID");
                        AnyError = 1;
                        GX_FocusControl = edtMenuXid_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
            /* Execute user event: After Trn */
            E12012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll011( ) ;
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
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes011( ) ;
         }
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

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode1 = Gx_mode;
            CONFIRM_0123( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode1;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0123( )
      {
         nGXsfl_78_idx = 0;
         while ( nGXsfl_78_idx < nRC_GXsfl_78 )
         {
            ReadRow0123( ) ;
            if ( ( nRcdExists_23 != 0 ) || ( nIsMod_23 != 0 ) )
            {
               GetKey0123( ) ;
               if ( ( nRcdExists_23 == 0 ) && ( nRcdDeleted_23 == 0 ) )
               {
                  if ( RcdFound23 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0123( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0123( ) ;
                        CloseExtendedTableCursors0123( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "ROLID_" + sGXsfl_78_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtRolId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound23 != 0 )
                  {
                     if ( nRcdDeleted_23 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0123( ) ;
                        Load0123( ) ;
                        BeforeValidate0123( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0123( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_23 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0123( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0123( ) ;
                              CloseExtendedTableCursors0123( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_23 == 0 )
                     {
                        GXCCtl = "ROLID_" + sGXsfl_78_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtRolId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtRolId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A24RolId), 9, 0, ",", ""))) ;
            ChangePostValue( edtRolNombre_Internalname, A127RolNombre) ;
            ChangePostValue( edtRolDescripcion_Internalname, A128RolDescripcion) ;
            ChangePostValue( "ZT_"+"Z24RolId_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z24RolId), 9, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_23_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_23), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_23_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_23), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_23_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_23), 4, 0, ",", ""))) ;
            if ( nIsMod_23 != 0 )
            {
               ChangePostValue( "ROLID_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRolId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ROLNOMBRE_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRolNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ROLDESCRIPCION_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRolDescripcion_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption010( )
      {
      }

      protected void E11012( )
      {
         /* Start Routine */
         if ( ! new isauthorized(context).executeUdp(  AV11Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV11Pgmname)));
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "TransactionContext", "ADMINDATA1");
      }

      protected void E12012( )
      {
         /* After Trn Routine */
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwmenu.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2MenuXDesc = T00016_A2MenuXDesc[0];
               Z3MenuXPosi = T00016_A3MenuXPosi[0];
               Z4MenXUrl = T00016_A4MenXUrl[0];
               Z5MenXEst = T00016_A5MenXEst[0];
               Z258MenPadre = T00016_A258MenPadre[0];
               Z262Descripcion = T00016_A262Descripcion[0];
            }
            else
            {
               Z2MenuXDesc = A2MenuXDesc;
               Z3MenuXPosi = A3MenuXPosi;
               Z4MenXUrl = A4MenXUrl;
               Z5MenXEst = A5MenXEst;
               Z258MenPadre = A258MenPadre;
               Z262Descripcion = A262Descripcion;
            }
         }
         if ( GX_JID == -4 )
         {
            Z1MenuXid = A1MenuXid;
            Z2MenuXDesc = A2MenuXDesc;
            Z3MenuXPosi = A3MenuXPosi;
            Z4MenXUrl = A4MenXUrl;
            Z5MenXEst = A5MenXEst;
            Z259MenIcono = A259MenIcono;
            Z40000MenIcono_GXI = A40000MenIcono_GXI;
            Z258MenPadre = A258MenPadre;
            Z262Descripcion = A262Descripcion;
         }
      }

      protected void standaloneNotModal( )
      {
         edtMenuXid_Enabled = 0;
         AssignProp("", false, edtMenuXid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenuXid_Enabled), 5, 0), true);
         edtMenuXid_Enabled = 0;
         AssignProp("", false, edtMenuXid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenuXid_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7MenuXid) )
         {
            A1MenuXid = AV7MenuXid;
            AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
         }
      }

      protected void standaloneModal( )
      {
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

      protected void Load011( )
      {
         /* Using cursor T00017 */
         pr_default.execute(5, new Object[] {A1MenuXid});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound1 = 1;
            A2MenuXDesc = T00017_A2MenuXDesc[0];
            n2MenuXDesc = T00017_n2MenuXDesc[0];
            AssignAttri("", false, "A2MenuXDesc", A2MenuXDesc);
            A3MenuXPosi = T00017_A3MenuXPosi[0];
            n3MenuXPosi = T00017_n3MenuXPosi[0];
            AssignAttri("", false, "A3MenuXPosi", StringUtil.LTrimStr( (decimal)(A3MenuXPosi), 4, 0));
            A4MenXUrl = T00017_A4MenXUrl[0];
            n4MenXUrl = T00017_n4MenXUrl[0];
            AssignAttri("", false, "A4MenXUrl", A4MenXUrl);
            A5MenXEst = T00017_A5MenXEst[0];
            n5MenXEst = T00017_n5MenXEst[0];
            AssignAttri("", false, "A5MenXEst", A5MenXEst);
            A40000MenIcono_GXI = T00017_A40000MenIcono_GXI[0];
            n40000MenIcono_GXI = T00017_n40000MenIcono_GXI[0];
            AssignProp("", false, imgMenIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A259MenIcono)) ? A40000MenIcono_GXI : context.convertURL( context.PathToRelativeUrl( A259MenIcono))), true);
            AssignProp("", false, imgMenIcono_Internalname, "SrcSet", context.GetImageSrcSet( A259MenIcono), true);
            A258MenPadre = T00017_A258MenPadre[0];
            n258MenPadre = T00017_n258MenPadre[0];
            AssignAttri("", false, "A258MenPadre", StringUtil.LTrimStr( (decimal)(A258MenPadre), 4, 0));
            A262Descripcion = T00017_A262Descripcion[0];
            AssignAttri("", false, "A262Descripcion", A262Descripcion);
            A259MenIcono = T00017_A259MenIcono[0];
            n259MenIcono = T00017_n259MenIcono[0];
            AssignAttri("", false, "A259MenIcono", A259MenIcono);
            AssignProp("", false, imgMenIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A259MenIcono)) ? A40000MenIcono_GXI : context.convertURL( context.PathToRelativeUrl( A259MenIcono))), true);
            AssignProp("", false, imgMenIcono_Internalname, "SrcSet", context.GetImageSrcSet( A259MenIcono), true);
            ZM011( -4) ;
         }
         pr_default.close(5);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
         AV11Pgmname = "Menu";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CheckExtendedTable011( )
      {
         nIsDirty_1 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV11Pgmname = "Menu";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         if ( ! ( GxRegex.IsMatch(A4MenXUrl,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") || String.IsNullOrEmpty(StringUtil.RTrim( A4MenXUrl)) ) )
         {
            GX_msglist.addItem("El valor de Url no coincide con el patrón especificado", "OutOfRange", 1, "MENXURL");
            AnyError = 1;
            GX_FocusControl = edtMenXUrl_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors011( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor T00018 */
         pr_default.execute(6, new Object[] {A1MenuXid});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00016 */
         pr_default.execute(4, new Object[] {A1MenuXid});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM011( 4) ;
            RcdFound1 = 1;
            A1MenuXid = T00016_A1MenuXid[0];
            AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
            A2MenuXDesc = T00016_A2MenuXDesc[0];
            n2MenuXDesc = T00016_n2MenuXDesc[0];
            AssignAttri("", false, "A2MenuXDesc", A2MenuXDesc);
            A3MenuXPosi = T00016_A3MenuXPosi[0];
            n3MenuXPosi = T00016_n3MenuXPosi[0];
            AssignAttri("", false, "A3MenuXPosi", StringUtil.LTrimStr( (decimal)(A3MenuXPosi), 4, 0));
            A4MenXUrl = T00016_A4MenXUrl[0];
            n4MenXUrl = T00016_n4MenXUrl[0];
            AssignAttri("", false, "A4MenXUrl", A4MenXUrl);
            A5MenXEst = T00016_A5MenXEst[0];
            n5MenXEst = T00016_n5MenXEst[0];
            AssignAttri("", false, "A5MenXEst", A5MenXEst);
            A40000MenIcono_GXI = T00016_A40000MenIcono_GXI[0];
            n40000MenIcono_GXI = T00016_n40000MenIcono_GXI[0];
            AssignProp("", false, imgMenIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A259MenIcono)) ? A40000MenIcono_GXI : context.convertURL( context.PathToRelativeUrl( A259MenIcono))), true);
            AssignProp("", false, imgMenIcono_Internalname, "SrcSet", context.GetImageSrcSet( A259MenIcono), true);
            A258MenPadre = T00016_A258MenPadre[0];
            n258MenPadre = T00016_n258MenPadre[0];
            AssignAttri("", false, "A258MenPadre", StringUtil.LTrimStr( (decimal)(A258MenPadre), 4, 0));
            A262Descripcion = T00016_A262Descripcion[0];
            AssignAttri("", false, "A262Descripcion", A262Descripcion);
            A259MenIcono = T00016_A259MenIcono[0];
            n259MenIcono = T00016_n259MenIcono[0];
            AssignAttri("", false, "A259MenIcono", A259MenIcono);
            AssignProp("", false, imgMenIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A259MenIcono)) ? A40000MenIcono_GXI : context.convertURL( context.PathToRelativeUrl( A259MenIcono))), true);
            AssignProp("", false, imgMenIcono_Internalname, "SrcSet", context.GetImageSrcSet( A259MenIcono), true);
            Z1MenuXid = A1MenuXid;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound1 = 0;
         /* Using cursor T00019 */
         pr_default.execute(7, new Object[] {A1MenuXid});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00019_A1MenuXid[0] < A1MenuXid ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00019_A1MenuXid[0] > A1MenuXid ) ) )
            {
               A1MenuXid = T00019_A1MenuXid[0];
               AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0;
         /* Using cursor T000110 */
         pr_default.execute(8, new Object[] {A1MenuXid});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000110_A1MenuXid[0] > A1MenuXid ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000110_A1MenuXid[0] < A1MenuXid ) ) )
            {
               A1MenuXid = T000110_A1MenuXid[0];
               AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMenuXDesc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert011( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1MenuXid != Z1MenuXid )
               {
                  A1MenuXid = Z1MenuXid;
                  AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MENUXID");
                  AnyError = 1;
                  GX_FocusControl = edtMenuXid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMenuXDesc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update011( ) ;
                  GX_FocusControl = edtMenuXDesc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1MenuXid != Z1MenuXid )
               {
                  /* Insert record */
                  GX_FocusControl = edtMenuXDesc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert011( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MENUXID");
                     AnyError = 1;
                     GX_FocusControl = edtMenuXid_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtMenuXDesc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert011( ) ;
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
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A1MenuXid != Z1MenuXid )
         {
            A1MenuXid = Z1MenuXid;
            AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MENUXID");
            AnyError = 1;
            GX_FocusControl = edtMenuXid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMenuXDesc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00015 */
            pr_default.execute(3, new Object[] {A1MenuXid});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Menu"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z2MenuXDesc, T00015_A2MenuXDesc[0]) != 0 ) || ( Z3MenuXPosi != T00015_A3MenuXPosi[0] ) || ( StringUtil.StrCmp(Z4MenXUrl, T00015_A4MenXUrl[0]) != 0 ) || ( StringUtil.StrCmp(Z5MenXEst, T00015_A5MenXEst[0]) != 0 ) || ( Z258MenPadre != T00015_A258MenPadre[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z262Descripcion, T00015_A262Descripcion[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z2MenuXDesc, T00015_A2MenuXDesc[0]) != 0 )
               {
                  GXUtil.WriteLog("menu:[seudo value changed for attri]"+"MenuXDesc");
                  GXUtil.WriteLogRaw("Old: ",Z2MenuXDesc);
                  GXUtil.WriteLogRaw("Current: ",T00015_A2MenuXDesc[0]);
               }
               if ( Z3MenuXPosi != T00015_A3MenuXPosi[0] )
               {
                  GXUtil.WriteLog("menu:[seudo value changed for attri]"+"MenuXPosi");
                  GXUtil.WriteLogRaw("Old: ",Z3MenuXPosi);
                  GXUtil.WriteLogRaw("Current: ",T00015_A3MenuXPosi[0]);
               }
               if ( StringUtil.StrCmp(Z4MenXUrl, T00015_A4MenXUrl[0]) != 0 )
               {
                  GXUtil.WriteLog("menu:[seudo value changed for attri]"+"MenXUrl");
                  GXUtil.WriteLogRaw("Old: ",Z4MenXUrl);
                  GXUtil.WriteLogRaw("Current: ",T00015_A4MenXUrl[0]);
               }
               if ( StringUtil.StrCmp(Z5MenXEst, T00015_A5MenXEst[0]) != 0 )
               {
                  GXUtil.WriteLog("menu:[seudo value changed for attri]"+"MenXEst");
                  GXUtil.WriteLogRaw("Old: ",Z5MenXEst);
                  GXUtil.WriteLogRaw("Current: ",T00015_A5MenXEst[0]);
               }
               if ( Z258MenPadre != T00015_A258MenPadre[0] )
               {
                  GXUtil.WriteLog("menu:[seudo value changed for attri]"+"MenPadre");
                  GXUtil.WriteLogRaw("Old: ",Z258MenPadre);
                  GXUtil.WriteLogRaw("Current: ",T00015_A258MenPadre[0]);
               }
               if ( StringUtil.StrCmp(Z262Descripcion, T00015_A262Descripcion[0]) != 0 )
               {
                  GXUtil.WriteLog("menu:[seudo value changed for attri]"+"Descripcion");
                  GXUtil.WriteLogRaw("Old: ",Z262Descripcion);
                  GXUtil.WriteLogRaw("Current: ",T00015_A262Descripcion[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Menu"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000111 */
                     pr_default.execute(9, new Object[] {n2MenuXDesc, A2MenuXDesc, n3MenuXPosi, A3MenuXPosi, n4MenXUrl, A4MenXUrl, n5MenXEst, A5MenXEst, n259MenIcono, A259MenIcono, n40000MenIcono_GXI, A40000MenIcono_GXI, n258MenPadre, A258MenPadre, A262Descripcion});
                     pr_default.close(9);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000112 */
                     pr_default.execute(10);
                     A1MenuXid = T000112_A1MenuXid[0];
                     AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("Menu") ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel011( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption010( ) ;
                           }
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
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000113 */
                     pr_default.execute(11, new Object[] {n2MenuXDesc, A2MenuXDesc, n3MenuXPosi, A3MenuXPosi, n4MenXUrl, A4MenXUrl, n5MenXEst, A5MenXEst, n258MenPadre, A258MenPadre, A262Descripcion, A1MenuXid});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("Menu") ;
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Menu"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel011( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
                              }
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
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000114 */
            pr_default.execute(12, new Object[] {n259MenIcono, A259MenIcono, n40000MenIcono_GXI, A40000MenIcono_GXI, A1MenuXid});
            pr_default.close(12);
            dsDefault.SmartCacheProvider.SetUpdated("Menu") ;
         }
      }

      protected void delete( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0123( ) ;
                  while ( RcdFound23 != 0 )
                  {
                     getByPrimaryKey0123( ) ;
                     Delete0123( ) ;
                     ScanNext0123( ) ;
                  }
                  ScanEnd0123( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000115 */
                     pr_default.execute(13, new Object[] {A1MenuXid});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("Menu") ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
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
            }
         }
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel011( ) ;
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV11Pgmname = "Menu";
            AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         }
      }

      protected void ProcessNestedLevel0123( )
      {
         nGXsfl_78_idx = 0;
         while ( nGXsfl_78_idx < nRC_GXsfl_78 )
         {
            ReadRow0123( ) ;
            if ( ( nRcdExists_23 != 0 ) || ( nIsMod_23 != 0 ) )
            {
               standaloneNotModal0123( ) ;
               GetKey0123( ) ;
               if ( ( nRcdExists_23 == 0 ) && ( nRcdDeleted_23 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0123( ) ;
               }
               else
               {
                  if ( RcdFound23 != 0 )
                  {
                     if ( ( nRcdDeleted_23 != 0 ) && ( nRcdExists_23 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0123( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_23 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0123( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_23 == 0 )
                     {
                        GXCCtl = "ROLID_" + sGXsfl_78_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtRolId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtRolId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A24RolId), 9, 0, ",", ""))) ;
            ChangePostValue( edtRolNombre_Internalname, A127RolNombre) ;
            ChangePostValue( edtRolDescripcion_Internalname, A128RolDescripcion) ;
            ChangePostValue( "ZT_"+"Z24RolId_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z24RolId), 9, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_23_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_23), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_23_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_23), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_23_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_23), 4, 0, ",", ""))) ;
            if ( nIsMod_23 != 0 )
            {
               ChangePostValue( "ROLID_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRolId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ROLNOMBRE_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRolNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ROLDESCRIPCION_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRolDescripcion_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0123( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_23 = 0;
         nIsMod_23 = 0;
         nRcdDeleted_23 = 0;
      }

      protected void ProcessLevel011( )
      {
         /* Save parent mode. */
         sMode1 = Gx_mode;
         ProcessNestedLevel0123( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("menu",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("menu",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart011( )
      {
         /* Scan By routine */
         /* Using cursor T000116 */
         pr_default.execute(14);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound1 = 1;
            A1MenuXid = T000116_A1MenuXid[0];
            AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound1 = 1;
            A1MenuXid = T000116_A1MenuXid[0];
            AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
         }
      }

      protected void ScanEnd011( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
         edtMenuXid_Enabled = 0;
         AssignProp("", false, edtMenuXid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenuXid_Enabled), 5, 0), true);
         edtMenuXDesc_Enabled = 0;
         AssignProp("", false, edtMenuXDesc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenuXDesc_Enabled), 5, 0), true);
         edtMenuXPosi_Enabled = 0;
         AssignProp("", false, edtMenuXPosi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenuXPosi_Enabled), 5, 0), true);
         edtMenXUrl_Enabled = 0;
         AssignProp("", false, edtMenXUrl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenXUrl_Enabled), 5, 0), true);
         cmbMenXEst.Enabled = 0;
         AssignProp("", false, cmbMenXEst_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbMenXEst.Enabled), 5, 0), true);
         imgMenIcono_Enabled = 0;
         AssignProp("", false, imgMenIcono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgMenIcono_Enabled), 5, 0), true);
         edtMenPadre_Enabled = 0;
         AssignProp("", false, edtMenPadre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenPadre_Enabled), 5, 0), true);
         edtDescripcion_Enabled = 0;
         AssignProp("", false, edtDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDescripcion_Enabled), 5, 0), true);
      }

      protected void ZM0123( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -5 )
         {
            Z1MenuXid = A1MenuXid;
            Z24RolId = A24RolId;
            Z127RolNombre = A127RolNombre;
            Z128RolDescripcion = A128RolDescripcion;
         }
      }

      protected void standaloneNotModal0123( )
      {
      }

      protected void standaloneModal0123( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtRolId_Enabled = 0;
            AssignProp("", false, edtRolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRolId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         }
         else
         {
            edtRolId_Enabled = 1;
            AssignProp("", false, edtRolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRolId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         }
      }

      protected void Load0123( )
      {
         /* Using cursor T000117 */
         pr_default.execute(15, new Object[] {A1MenuXid, A24RolId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound23 = 1;
            A127RolNombre = T000117_A127RolNombre[0];
            A128RolDescripcion = T000117_A128RolDescripcion[0];
            ZM0123( -5) ;
         }
         pr_default.close(15);
         OnLoadActions0123( ) ;
      }

      protected void OnLoadActions0123( )
      {
      }

      protected void CheckExtendedTable0123( )
      {
         nIsDirty_23 = 0;
         Gx_BScreen = 1;
         standaloneModal0123( ) ;
         /* Using cursor T00014 */
         pr_default.execute(2, new Object[] {A24RolId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "ROLID_" + sGXsfl_78_idx;
            GX_msglist.addItem("No existe 'Roles'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtRolId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A127RolNombre = T00014_A127RolNombre[0];
         A128RolDescripcion = T00014_A128RolDescripcion[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0123( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0123( )
      {
      }

      protected void gxLoad_6( int A24RolId )
      {
         /* Using cursor T000118 */
         pr_default.execute(16, new Object[] {A24RolId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GXCCtl = "ROLID_" + sGXsfl_78_idx;
            GX_msglist.addItem("No existe 'Roles'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtRolId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A127RolNombre = T000118_A127RolNombre[0];
         A128RolDescripcion = T000118_A128RolDescripcion[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A127RolNombre)+"\""+","+"\""+GXUtil.EncodeJSConstant( A128RolDescripcion)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void GetKey0123( )
      {
         /* Using cursor T000119 */
         pr_default.execute(17, new Object[] {A1MenuXid, A24RolId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound23 = 1;
         }
         else
         {
            RcdFound23 = 0;
         }
         pr_default.close(17);
      }

      protected void getByPrimaryKey0123( )
      {
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {A1MenuXid, A24RolId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0123( 5) ;
            RcdFound23 = 1;
            InitializeNonKey0123( ) ;
            A24RolId = T00013_A24RolId[0];
            Z1MenuXid = A1MenuXid;
            Z24RolId = A24RolId;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0123( ) ;
            Gx_mode = sMode23;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound23 = 0;
            InitializeNonKey0123( ) ;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0123( ) ;
            Gx_mode = sMode23;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0123( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0123( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00012 */
            pr_default.execute(0, new Object[] {A1MenuXid, A24RolId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MenuRol"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"MenuRol"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0123( )
      {
         BeforeValidate0123( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0123( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0123( 0) ;
            CheckOptimisticConcurrency0123( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0123( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0123( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000120 */
                     pr_default.execute(18, new Object[] {A1MenuXid, A24RolId});
                     pr_default.close(18);
                     dsDefault.SmartCacheProvider.SetUpdated("MenuRol") ;
                     if ( (pr_default.getStatus(18) == 1) )
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
               Load0123( ) ;
            }
            EndLevel0123( ) ;
         }
         CloseExtendedTableCursors0123( ) ;
      }

      protected void Update0123( )
      {
         BeforeValidate0123( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0123( ) ;
         }
         if ( ( nIsMod_23 != 0 ) || ( nIsDirty_23 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0123( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0123( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0123( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table `MenuRol` */
                        DeferredUpdate0123( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0123( ) ;
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
               EndLevel0123( ) ;
            }
         }
         CloseExtendedTableCursors0123( ) ;
      }

      protected void DeferredUpdate0123( )
      {
      }

      protected void Delete0123( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0123( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0123( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0123( ) ;
            AfterConfirm0123( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0123( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000121 */
                  pr_default.execute(19, new Object[] {A1MenuXid, A24RolId});
                  pr_default.close(19);
                  dsDefault.SmartCacheProvider.SetUpdated("MenuRol") ;
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode23 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0123( ) ;
         Gx_mode = sMode23;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0123( )
      {
         standaloneModal0123( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000122 */
            pr_default.execute(20, new Object[] {A24RolId});
            A127RolNombre = T000122_A127RolNombre[0];
            A128RolDescripcion = T000122_A128RolDescripcion[0];
            pr_default.close(20);
         }
      }

      protected void EndLevel0123( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0123( )
      {
         /* Scan By routine */
         /* Using cursor T000123 */
         pr_default.execute(21, new Object[] {A1MenuXid});
         RcdFound23 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound23 = 1;
            A24RolId = T000123_A24RolId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0123( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound23 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound23 = 1;
            A24RolId = T000123_A24RolId[0];
         }
      }

      protected void ScanEnd0123( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm0123( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0123( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0123( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0123( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0123( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0123( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0123( )
      {
         edtRolId_Enabled = 0;
         AssignProp("", false, edtRolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRolId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         edtRolNombre_Enabled = 0;
         AssignProp("", false, edtRolNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRolNombre_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         edtRolDescripcion_Enabled = 0;
         AssignProp("", false, edtRolDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRolDescripcion_Enabled), 5, 0), !bGXsfl_78_Refreshing);
      }

      protected void send_integrity_lvl_hashes0123( )
      {
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void SubsflControlProps_7823( )
      {
         edtRolId_Internalname = "ROLID_"+sGXsfl_78_idx;
         edtRolNombre_Internalname = "ROLNOMBRE_"+sGXsfl_78_idx;
         edtRolDescripcion_Internalname = "ROLDESCRIPCION_"+sGXsfl_78_idx;
      }

      protected void SubsflControlProps_fel_7823( )
      {
         edtRolId_Internalname = "ROLID_"+sGXsfl_78_fel_idx;
         edtRolNombre_Internalname = "ROLNOMBRE_"+sGXsfl_78_fel_idx;
         edtRolDescripcion_Internalname = "ROLDESCRIPCION_"+sGXsfl_78_fel_idx;
      }

      protected void AddRow0123( )
      {
         nGXsfl_78_idx = (int)(nGXsfl_78_idx+1);
         sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
         SubsflControlProps_7823( ) ;
         SendRow0123( ) ;
      }

      protected void SendRow0123( )
      {
         Gridmenu_rolRow = GXWebRow.GetNew(context);
         if ( subGridmenu_rol_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridmenu_rol_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridmenu_rol_Class, "") != 0 )
            {
               subGridmenu_rol_Linesclass = subGridmenu_rol_Class+"Odd";
            }
         }
         else if ( subGridmenu_rol_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridmenu_rol_Backstyle = 0;
            subGridmenu_rol_Backcolor = subGridmenu_rol_Allbackcolor;
            if ( StringUtil.StrCmp(subGridmenu_rol_Class, "") != 0 )
            {
               subGridmenu_rol_Linesclass = subGridmenu_rol_Class+"Uniform";
            }
         }
         else if ( subGridmenu_rol_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridmenu_rol_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridmenu_rol_Class, "") != 0 )
            {
               subGridmenu_rol_Linesclass = subGridmenu_rol_Class+"Odd";
            }
            subGridmenu_rol_Backcolor = (int)(0x0);
         }
         else if ( subGridmenu_rol_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridmenu_rol_Backstyle = 1;
            if ( ((int)((nGXsfl_78_idx) % (2))) == 0 )
            {
               subGridmenu_rol_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridmenu_rol_Class, "") != 0 )
               {
                  subGridmenu_rol_Linesclass = subGridmenu_rol_Class+"Even";
               }
            }
            else
            {
               subGridmenu_rol_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridmenu_rol_Class, "") != 0 )
               {
                  subGridmenu_rol_Linesclass = subGridmenu_rol_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_23_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ROClassString = "Attribute";
         Gridmenu_rolRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtRolId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A24RolId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A24RolId), "ZZZZZZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,79);\"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtRolId_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(int)edtRolId_Enabled,(short)1,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)9,(short)0,(short)0,(short)78,(short)1,(short)-1,(short)0,(bool)true,(String)"Id",(String)"right",(bool)false,(String)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridmenu_rolRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtRolNombre_Internalname,(String)A127RolNombre,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtRolNombre_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(int)edtRolNombre_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)40,(short)0,(short)0,(short)78,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridmenu_rolRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtRolDescripcion_Internalname,(String)A128RolDescripcion,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtRolDescripcion_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(int)edtRolDescripcion_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)150,(short)0,(short)0,(short)78,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridmenu_rolRow);
         send_integrity_lvl_hashes0123( ) ;
         GXCCtl = "Z24RolId_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z24RolId), 9, 0, ",", "")));
         GXCCtl = "nRcdDeleted_23_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_23), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_23_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_23), 4, 0, ",", "")));
         GXCCtl = "nIsMod_23_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_23), 4, 0, ",", "")));
         GXCCtl = "vMODE_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_78_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vMENUXID_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7MenuXid), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ROLID_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRolId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ROLNOMBRE_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRolNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ROLDESCRIPCION_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRolDescripcion_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridmenu_rolContainer.AddRow(Gridmenu_rolRow);
      }

      protected void ReadRow0123( )
      {
         nGXsfl_78_idx = (int)(nGXsfl_78_idx+1);
         sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
         SubsflControlProps_7823( ) ;
         edtRolId_Enabled = (int)(context.localUtil.CToN( cgiGet( "ROLID_"+sGXsfl_78_idx+"Enabled"), ",", "."));
         edtRolNombre_Enabled = (int)(context.localUtil.CToN( cgiGet( "ROLNOMBRE_"+sGXsfl_78_idx+"Enabled"), ",", "."));
         edtRolDescripcion_Enabled = (int)(context.localUtil.CToN( cgiGet( "ROLDESCRIPCION_"+sGXsfl_78_idx+"Enabled"), ",", "."));
         if ( ( ( context.localUtil.CToN( cgiGet( edtRolId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRolId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
         {
            GXCCtl = "ROLID_" + sGXsfl_78_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtRolId_Internalname;
            wbErr = true;
            A24RolId = 0;
         }
         else
         {
            A24RolId = (int)(context.localUtil.CToN( cgiGet( edtRolId_Internalname), ",", "."));
         }
         A127RolNombre = cgiGet( edtRolNombre_Internalname);
         A128RolDescripcion = cgiGet( edtRolDescripcion_Internalname);
         GXCCtl = "Z24RolId_" + sGXsfl_78_idx;
         Z24RolId = (int)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nRcdDeleted_23_" + sGXsfl_78_idx;
         nRcdDeleted_23 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nRcdExists_23_" + sGXsfl_78_idx;
         nRcdExists_23 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nIsMod_23_" + sGXsfl_78_idx;
         nIsMod_23 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
      }

      protected void assign_properties_default( )
      {
         defedtRolId_Enabled = edtRolId_Enabled;
      }

      protected void ConfirmValues010( )
      {
         nGXsfl_78_idx = 0;
         sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
         SubsflControlProps_7823( ) ;
         while ( nGXsfl_78_idx < nRC_GXsfl_78 )
         {
            nGXsfl_78_idx = (int)(nGXsfl_78_idx+1);
            sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
            SubsflControlProps_7823( ) ;
            ChangePostValue( "Z24RolId_"+sGXsfl_78_idx, cgiGet( "ZT_"+"Z24RolId_"+sGXsfl_78_idx)) ;
            DeletePostValue( "ZT_"+"Z24RolId_"+sGXsfl_78_idx) ;
         }
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
         context.AddJavascriptSource("gxcfg.js", "?20226271434300", false, true);
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
         bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle = bodyStyle + " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "menu.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode("" +AV7MenuXid);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("menu.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Menu");
         forbiddenHiddens.Add("MenuXid", context.localUtil.Format( (decimal)(A1MenuXid), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("menu:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1MenuXid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1MenuXid), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z2MenuXDesc", Z2MenuXDesc);
         GxWebStd.gx_hidden_field( context, "Z3MenuXPosi", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z3MenuXPosi), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z4MenXUrl", Z4MenXUrl);
         GxWebStd.gx_hidden_field( context, "Z5MenXEst", StringUtil.RTrim( Z5MenXEst));
         GxWebStd.gx_hidden_field( context, "Z258MenPadre", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z258MenPadre), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z262Descripcion", Z262Descripcion);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_78", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_78_idx), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vMENUXID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7MenuXid), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMENUXID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MenuXid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "MENICONO_GXI", A40000MenIcono_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV11Pgmname));
         GXCCtlgxBlob = "MENICONO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A259MenIcono);
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "menu.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode("" +AV7MenuXid);
         return formatLink("menu.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override String GetPgmname( )
      {
         return "Menu" ;
      }

      public override String GetPgmdesc( )
      {
         return "Menu" ;
      }

      protected void InitializeNonKey011( )
      {
         A2MenuXDesc = "";
         n2MenuXDesc = false;
         AssignAttri("", false, "A2MenuXDesc", A2MenuXDesc);
         n2MenuXDesc = (String.IsNullOrEmpty(StringUtil.RTrim( A2MenuXDesc)) ? true : false);
         A3MenuXPosi = 0;
         n3MenuXPosi = false;
         AssignAttri("", false, "A3MenuXPosi", StringUtil.LTrimStr( (decimal)(A3MenuXPosi), 4, 0));
         n3MenuXPosi = ((0==A3MenuXPosi) ? true : false);
         A4MenXUrl = "";
         n4MenXUrl = false;
         AssignAttri("", false, "A4MenXUrl", A4MenXUrl);
         n4MenXUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A4MenXUrl)) ? true : false);
         A5MenXEst = "";
         n5MenXEst = false;
         AssignAttri("", false, "A5MenXEst", A5MenXEst);
         n5MenXEst = (String.IsNullOrEmpty(StringUtil.RTrim( A5MenXEst)) ? true : false);
         A259MenIcono = "";
         n259MenIcono = false;
         AssignAttri("", false, "A259MenIcono", A259MenIcono);
         AssignProp("", false, imgMenIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A259MenIcono)) ? A40000MenIcono_GXI : context.convertURL( context.PathToRelativeUrl( A259MenIcono))), true);
         AssignProp("", false, imgMenIcono_Internalname, "SrcSet", context.GetImageSrcSet( A259MenIcono), true);
         n259MenIcono = (String.IsNullOrEmpty(StringUtil.RTrim( A259MenIcono)) ? true : false);
         A40000MenIcono_GXI = "";
         n40000MenIcono_GXI = false;
         AssignProp("", false, imgMenIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A259MenIcono)) ? A40000MenIcono_GXI : context.convertURL( context.PathToRelativeUrl( A259MenIcono))), true);
         AssignProp("", false, imgMenIcono_Internalname, "SrcSet", context.GetImageSrcSet( A259MenIcono), true);
         A258MenPadre = 0;
         n258MenPadre = false;
         AssignAttri("", false, "A258MenPadre", StringUtil.LTrimStr( (decimal)(A258MenPadre), 4, 0));
         n258MenPadre = ((0==A258MenPadre) ? true : false);
         A262Descripcion = "";
         AssignAttri("", false, "A262Descripcion", A262Descripcion);
         Z2MenuXDesc = "";
         Z3MenuXPosi = 0;
         Z4MenXUrl = "";
         Z5MenXEst = "";
         Z258MenPadre = 0;
         Z262Descripcion = "";
      }

      protected void InitAll011( )
      {
         A1MenuXid = 0;
         AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0123( )
      {
         A127RolNombre = "";
         A128RolDescripcion = "";
      }

      protected void InitAll0123( )
      {
         A24RolId = 0;
         InitializeNonKey0123( ) ;
      }

      protected void StandaloneModalInsert0123( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714343012", true, true);
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
         context.AddJavascriptSource("menu.js", "?202262714343013", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties23( )
      {
         edtRolId_Enabled = defedtRolId_Enabled;
         AssignProp("", false, edtRolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRolId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
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
         edtMenuXid_Internalname = "MENUXID";
         edtMenuXDesc_Internalname = "MENUXDESC";
         edtMenuXPosi_Internalname = "MENUXPOSI";
         edtMenXUrl_Internalname = "MENXURL";
         cmbMenXEst_Internalname = "MENXEST";
         imgMenIcono_Internalname = "MENICONO";
         edtMenPadre_Internalname = "MENPADRE";
         edtDescripcion_Internalname = "DESCRIPCION";
         lblTitlerol_Internalname = "TITLEROL";
         edtRolId_Internalname = "ROLID";
         edtRolNombre_Internalname = "ROLNOMBRE";
         edtRolDescripcion_Internalname = "ROLDESCRIPCION";
         divRoltable_Internalname = "ROLTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridmenu_rol_Internalname = "GRIDMENU_ROL";
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
         Form.Caption = "Menu";
         edtRolDescripcion_Jsonclick = "";
         edtRolNombre_Jsonclick = "";
         edtRolId_Jsonclick = "";
         subGridmenu_rol_Class = "Grid";
         subGridmenu_rol_Backcolorstyle = 0;
         subGridmenu_rol_Allowcollapsing = 0;
         subGridmenu_rol_Allowselection = 0;
         edtRolDescripcion_Enabled = 0;
         edtRolNombre_Enabled = 0;
         edtRolId_Enabled = 1;
         subGridmenu_rol_Header = "";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtDescripcion_Jsonclick = "";
         edtDescripcion_Enabled = 1;
         edtMenPadre_Jsonclick = "";
         edtMenPadre_Enabled = 1;
         imgMenIcono_Enabled = 1;
         cmbMenXEst_Jsonclick = "";
         cmbMenXEst.Enabled = 1;
         edtMenXUrl_Jsonclick = "";
         edtMenXUrl_Enabled = 1;
         edtMenuXPosi_Jsonclick = "";
         edtMenuXPosi_Enabled = 1;
         edtMenuXDesc_Jsonclick = "";
         edtMenuXDesc_Enabled = 1;
         edtMenuXid_Jsonclick = "";
         edtMenuXid_Enabled = 0;
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

      protected void gxnrGridmenu_rol_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_7823( ) ;
         while ( nGXsfl_78_idx <= nRC_GXsfl_78 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0123( ) ;
            standaloneModal0123( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0123( ) ;
            nGXsfl_78_idx = (int)(nGXsfl_78_idx+1);
            sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
            SubsflControlProps_7823( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridmenu_rolContainer)) ;
         /* End function gxnrGridmenu_rol_newrow */
      }

      protected void init_web_controls( )
      {
         cmbMenXEst.Name = "MENXEST";
         cmbMenXEst.WebTags = "";
         cmbMenXEst.addItem("A", "Activo", 0);
         cmbMenXEst.addItem("I", "Inactivo", 0);
         if ( cmbMenXEst.ItemCount > 0 )
         {
            A5MenXEst = cmbMenXEst.getValidValue(A5MenXEst);
            n5MenXEst = false;
            AssignAttri("", false, "A5MenXEst", A5MenXEst);
         }
         /* End function init_web_controls */
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

      public void Valid_Rolid( )
      {
         /* Using cursor T000122 */
         pr_default.execute(20, new Object[] {A24RolId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Roles'.", "ForeignKeyNotFound", 1, "ROLID");
            AnyError = 1;
            GX_FocusControl = edtRolId_Internalname;
         }
         A127RolNombre = T000122_A127RolNombre[0];
         A128RolDescripcion = T000122_A128RolDescripcion[0];
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A127RolNombre", A127RolNombre);
         AssignAttri("", false, "A128RolDescripcion", A128RolDescripcion);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7MenuXid',fld:'vMENUXID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7MenuXid',fld:'vMENUXID',pic:'ZZZ9',hsh:true},{av:'A1MenuXid',fld:'MENUXID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12012',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_MENUXID","{handler:'Valid_Menuxid',iparms:[]");
         setEventMetadata("VALID_MENUXID",",oparms:[]}");
         setEventMetadata("VALID_MENXURL","{handler:'Valid_Menxurl',iparms:[]");
         setEventMetadata("VALID_MENXURL",",oparms:[]}");
         setEventMetadata("VALID_ROLID","{handler:'Valid_Rolid',iparms:[{av:'A24RolId',fld:'ROLID',pic:'ZZZZZZZZ9'},{av:'A127RolNombre',fld:'ROLNOMBRE',pic:''},{av:'A128RolDescripcion',fld:'ROLDESCRIPCION',pic:''}]");
         setEventMetadata("VALID_ROLID",",oparms:[{av:'A127RolNombre',fld:'ROLNOMBRE',pic:''},{av:'A128RolDescripcion',fld:'ROLDESCRIPCION',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Roldescripcion',iparms:[]");
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
         pr_default.close(1);
         pr_default.close(20);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z2MenuXDesc = "";
         Z4MenXUrl = "";
         Z5MenXEst = "";
         Z262Descripcion = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A5MenXEst = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A2MenuXDesc = "";
         A4MenXUrl = "";
         A259MenIcono = "";
         A40000MenIcono_GXI = "";
         sImgUrl = "";
         A262Descripcion = "";
         lblTitlerol_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridmenu_rolContainer = new GXWebGrid( context);
         Gridmenu_rolColumn = new GXWebColumn();
         A127RolNombre = "";
         A128RolDescripcion = "";
         sMode23 = "";
         sStyleString = "";
         AV11Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode1 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z259MenIcono = "";
         Z40000MenIcono_GXI = "";
         T00017_A1MenuXid = new short[1] ;
         T00017_A2MenuXDesc = new String[] {""} ;
         T00017_n2MenuXDesc = new bool[] {false} ;
         T00017_A3MenuXPosi = new short[1] ;
         T00017_n3MenuXPosi = new bool[] {false} ;
         T00017_A4MenXUrl = new String[] {""} ;
         T00017_n4MenXUrl = new bool[] {false} ;
         T00017_A5MenXEst = new String[] {""} ;
         T00017_n5MenXEst = new bool[] {false} ;
         T00017_A40000MenIcono_GXI = new String[] {""} ;
         T00017_n40000MenIcono_GXI = new bool[] {false} ;
         T00017_A258MenPadre = new short[1] ;
         T00017_n258MenPadre = new bool[] {false} ;
         T00017_A262Descripcion = new String[] {""} ;
         T00017_A259MenIcono = new String[] {""} ;
         T00017_n259MenIcono = new bool[] {false} ;
         T00018_A1MenuXid = new short[1] ;
         T00016_A1MenuXid = new short[1] ;
         T00016_A2MenuXDesc = new String[] {""} ;
         T00016_n2MenuXDesc = new bool[] {false} ;
         T00016_A3MenuXPosi = new short[1] ;
         T00016_n3MenuXPosi = new bool[] {false} ;
         T00016_A4MenXUrl = new String[] {""} ;
         T00016_n4MenXUrl = new bool[] {false} ;
         T00016_A5MenXEst = new String[] {""} ;
         T00016_n5MenXEst = new bool[] {false} ;
         T00016_A40000MenIcono_GXI = new String[] {""} ;
         T00016_n40000MenIcono_GXI = new bool[] {false} ;
         T00016_A258MenPadre = new short[1] ;
         T00016_n258MenPadre = new bool[] {false} ;
         T00016_A262Descripcion = new String[] {""} ;
         T00016_A259MenIcono = new String[] {""} ;
         T00016_n259MenIcono = new bool[] {false} ;
         T00019_A1MenuXid = new short[1] ;
         T000110_A1MenuXid = new short[1] ;
         T00015_A1MenuXid = new short[1] ;
         T00015_A2MenuXDesc = new String[] {""} ;
         T00015_n2MenuXDesc = new bool[] {false} ;
         T00015_A3MenuXPosi = new short[1] ;
         T00015_n3MenuXPosi = new bool[] {false} ;
         T00015_A4MenXUrl = new String[] {""} ;
         T00015_n4MenXUrl = new bool[] {false} ;
         T00015_A5MenXEst = new String[] {""} ;
         T00015_n5MenXEst = new bool[] {false} ;
         T00015_A40000MenIcono_GXI = new String[] {""} ;
         T00015_n40000MenIcono_GXI = new bool[] {false} ;
         T00015_A258MenPadre = new short[1] ;
         T00015_n258MenPadre = new bool[] {false} ;
         T00015_A262Descripcion = new String[] {""} ;
         T00015_A259MenIcono = new String[] {""} ;
         T00015_n259MenIcono = new bool[] {false} ;
         T000112_A1MenuXid = new short[1] ;
         T000116_A1MenuXid = new short[1] ;
         Z127RolNombre = "";
         Z128RolDescripcion = "";
         T000117_A1MenuXid = new short[1] ;
         T000117_A127RolNombre = new String[] {""} ;
         T000117_A128RolDescripcion = new String[] {""} ;
         T000117_A24RolId = new int[1] ;
         T00014_A127RolNombre = new String[] {""} ;
         T00014_A128RolDescripcion = new String[] {""} ;
         T000118_A127RolNombre = new String[] {""} ;
         T000118_A128RolDescripcion = new String[] {""} ;
         T000119_A1MenuXid = new short[1] ;
         T000119_A24RolId = new int[1] ;
         T00013_A1MenuXid = new short[1] ;
         T00013_A24RolId = new int[1] ;
         T00012_A1MenuXid = new short[1] ;
         T00012_A24RolId = new int[1] ;
         T000122_A127RolNombre = new String[] {""} ;
         T000122_A128RolDescripcion = new String[] {""} ;
         T000123_A1MenuXid = new short[1] ;
         T000123_A24RolId = new int[1] ;
         Gridmenu_rolRow = new GXWebRow();
         subGridmenu_rol_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXCCtlgxBlob = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.menu__default(),
            new Object[][] {
                new Object[] {
               T00012_A1MenuXid, T00012_A24RolId
               }
               , new Object[] {
               T00013_A1MenuXid, T00013_A24RolId
               }
               , new Object[] {
               T00014_A127RolNombre, T00014_A128RolDescripcion
               }
               , new Object[] {
               T00015_A1MenuXid, T00015_A2MenuXDesc, T00015_n2MenuXDesc, T00015_A3MenuXPosi, T00015_n3MenuXPosi, T00015_A4MenXUrl, T00015_n4MenXUrl, T00015_A5MenXEst, T00015_n5MenXEst, T00015_A40000MenIcono_GXI,
               T00015_n40000MenIcono_GXI, T00015_A258MenPadre, T00015_n258MenPadre, T00015_A262Descripcion, T00015_A259MenIcono, T00015_n259MenIcono
               }
               , new Object[] {
               T00016_A1MenuXid, T00016_A2MenuXDesc, T00016_n2MenuXDesc, T00016_A3MenuXPosi, T00016_n3MenuXPosi, T00016_A4MenXUrl, T00016_n4MenXUrl, T00016_A5MenXEst, T00016_n5MenXEst, T00016_A40000MenIcono_GXI,
               T00016_n40000MenIcono_GXI, T00016_A258MenPadre, T00016_n258MenPadre, T00016_A262Descripcion, T00016_A259MenIcono, T00016_n259MenIcono
               }
               , new Object[] {
               T00017_A1MenuXid, T00017_A2MenuXDesc, T00017_n2MenuXDesc, T00017_A3MenuXPosi, T00017_n3MenuXPosi, T00017_A4MenXUrl, T00017_n4MenXUrl, T00017_A5MenXEst, T00017_n5MenXEst, T00017_A40000MenIcono_GXI,
               T00017_n40000MenIcono_GXI, T00017_A258MenPadre, T00017_n258MenPadre, T00017_A262Descripcion, T00017_A259MenIcono, T00017_n259MenIcono
               }
               , new Object[] {
               T00018_A1MenuXid
               }
               , new Object[] {
               T00019_A1MenuXid
               }
               , new Object[] {
               T000110_A1MenuXid
               }
               , new Object[] {
               }
               , new Object[] {
               T000112_A1MenuXid
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000116_A1MenuXid
               }
               , new Object[] {
               T000117_A1MenuXid, T000117_A127RolNombre, T000117_A128RolDescripcion, T000117_A24RolId
               }
               , new Object[] {
               T000118_A127RolNombre, T000118_A128RolDescripcion
               }
               , new Object[] {
               T000119_A1MenuXid, T000119_A24RolId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000122_A127RolNombre, T000122_A128RolDescripcion
               }
               , new Object[] {
               T000123_A1MenuXid, T000123_A24RolId
               }
            }
         );
         AV11Pgmname = "Menu";
      }

      private short wcpOAV7MenuXid ;
      private short Z1MenuXid ;
      private short Z3MenuXPosi ;
      private short Z258MenPadre ;
      private short nRcdDeleted_23 ;
      private short nRcdExists_23 ;
      private short nIsMod_23 ;
      private short GxWebError ;
      private short AV7MenuXid ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1MenuXid ;
      private short A3MenuXPosi ;
      private short A258MenPadre ;
      private short subGridmenu_rol_Backcolorstyle ;
      private short subGridmenu_rol_Allowselection ;
      private short subGridmenu_rol_Allowhovering ;
      private short subGridmenu_rol_Allowcollapsing ;
      private short subGridmenu_rol_Collapsed ;
      private short nBlankRcdCount23 ;
      private short RcdFound23 ;
      private short nBlankRcdUsr23 ;
      private short RcdFound1 ;
      private short GX_JID ;
      private short nIsDirty_1 ;
      private short Gx_BScreen ;
      private short nIsDirty_23 ;
      private short subGridmenu_rol_Backstyle ;
      private short gxajaxcallmode ;
      private int nRC_GXsfl_78 ;
      private int nGXsfl_78_idx=1 ;
      private int Z24RolId ;
      private int A24RolId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtMenuXid_Enabled ;
      private int edtMenuXDesc_Enabled ;
      private int edtMenuXPosi_Enabled ;
      private int edtMenXUrl_Enabled ;
      private int imgMenIcono_Enabled ;
      private int edtMenPadre_Enabled ;
      private int edtDescripcion_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtRolId_Enabled ;
      private int edtRolNombre_Enabled ;
      private int edtRolDescripcion_Enabled ;
      private int subGridmenu_rol_Selectedindex ;
      private int subGridmenu_rol_Selectioncolor ;
      private int subGridmenu_rol_Hoveringcolor ;
      private int fRowAdded ;
      private int subGridmenu_rol_Backcolor ;
      private int subGridmenu_rol_Allbackcolor ;
      private int defedtRolId_Enabled ;
      private int idxLst ;
      private long GRIDMENU_ROL_nFirstRecordOnPage ;
      private String sPrefix ;
      private String wcpOGx_mode ;
      private String Z5MenXEst ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_78_idx="0001" ;
      private String Gx_mode ;
      private String GXKey ;
      private String GXDecQS ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String GX_FocusControl ;
      private String edtMenuXDesc_Internalname ;
      private String A5MenXEst ;
      private String cmbMenXEst_Internalname ;
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
      private String edtMenuXid_Internalname ;
      private String edtMenuXid_Jsonclick ;
      private String edtMenuXDesc_Jsonclick ;
      private String edtMenuXPosi_Internalname ;
      private String edtMenuXPosi_Jsonclick ;
      private String edtMenXUrl_Internalname ;
      private String edtMenXUrl_Jsonclick ;
      private String cmbMenXEst_Jsonclick ;
      private String imgMenIcono_Internalname ;
      private String sImgUrl ;
      private String edtMenPadre_Internalname ;
      private String edtMenPadre_Jsonclick ;
      private String edtDescripcion_Internalname ;
      private String edtDescripcion_Jsonclick ;
      private String divRoltable_Internalname ;
      private String lblTitlerol_Internalname ;
      private String lblTitlerol_Jsonclick ;
      private String bttBtn_enter_Internalname ;
      private String bttBtn_enter_Jsonclick ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String bttBtn_delete_Internalname ;
      private String bttBtn_delete_Jsonclick ;
      private String subGridmenu_rol_Header ;
      private String sMode23 ;
      private String edtRolId_Internalname ;
      private String edtRolNombre_Internalname ;
      private String edtRolDescripcion_Internalname ;
      private String sStyleString ;
      private String AV11Pgmname ;
      private String hsh ;
      private String sMode1 ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String endTrnMsgTxt ;
      private String endTrnMsgCod ;
      private String GXCCtl ;
      private String sGXsfl_78_fel_idx="0001" ;
      private String subGridmenu_rol_Class ;
      private String subGridmenu_rol_Linesclass ;
      private String ROClassString ;
      private String edtRolId_Jsonclick ;
      private String edtRolNombre_Jsonclick ;
      private String edtRolDescripcion_Jsonclick ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXEncryptionTmp ;
      private String GXCCtlgxBlob ;
      private String subGridmenu_rol_Internalname ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n5MenXEst ;
      private bool A259MenIcono_IsBlob ;
      private bool bGXsfl_78_Refreshing=false ;
      private bool n2MenuXDesc ;
      private bool n3MenuXPosi ;
      private bool n4MenXUrl ;
      private bool n258MenPadre ;
      private bool n40000MenIcono_GXI ;
      private bool n259MenIcono ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private String Z2MenuXDesc ;
      private String Z4MenXUrl ;
      private String Z262Descripcion ;
      private String A2MenuXDesc ;
      private String A4MenXUrl ;
      private String A40000MenIcono_GXI ;
      private String A262Descripcion ;
      private String A127RolNombre ;
      private String A128RolDescripcion ;
      private String Z40000MenIcono_GXI ;
      private String Z127RolNombre ;
      private String Z128RolDescripcion ;
      private String A259MenIcono ;
      private String Z259MenIcono ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridmenu_rolContainer ;
      private GXWebRow Gridmenu_rolRow ;
      private GXWebColumn Gridmenu_rolColumn ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbMenXEst ;
      private IDataStoreProvider pr_default ;
      private short[] T00017_A1MenuXid ;
      private String[] T00017_A2MenuXDesc ;
      private bool[] T00017_n2MenuXDesc ;
      private short[] T00017_A3MenuXPosi ;
      private bool[] T00017_n3MenuXPosi ;
      private String[] T00017_A4MenXUrl ;
      private bool[] T00017_n4MenXUrl ;
      private String[] T00017_A5MenXEst ;
      private bool[] T00017_n5MenXEst ;
      private String[] T00017_A40000MenIcono_GXI ;
      private bool[] T00017_n40000MenIcono_GXI ;
      private short[] T00017_A258MenPadre ;
      private bool[] T00017_n258MenPadre ;
      private String[] T00017_A262Descripcion ;
      private String[] T00017_A259MenIcono ;
      private bool[] T00017_n259MenIcono ;
      private short[] T00018_A1MenuXid ;
      private short[] T00016_A1MenuXid ;
      private String[] T00016_A2MenuXDesc ;
      private bool[] T00016_n2MenuXDesc ;
      private short[] T00016_A3MenuXPosi ;
      private bool[] T00016_n3MenuXPosi ;
      private String[] T00016_A4MenXUrl ;
      private bool[] T00016_n4MenXUrl ;
      private String[] T00016_A5MenXEst ;
      private bool[] T00016_n5MenXEst ;
      private String[] T00016_A40000MenIcono_GXI ;
      private bool[] T00016_n40000MenIcono_GXI ;
      private short[] T00016_A258MenPadre ;
      private bool[] T00016_n258MenPadre ;
      private String[] T00016_A262Descripcion ;
      private String[] T00016_A259MenIcono ;
      private bool[] T00016_n259MenIcono ;
      private short[] T00019_A1MenuXid ;
      private short[] T000110_A1MenuXid ;
      private short[] T00015_A1MenuXid ;
      private String[] T00015_A2MenuXDesc ;
      private bool[] T00015_n2MenuXDesc ;
      private short[] T00015_A3MenuXPosi ;
      private bool[] T00015_n3MenuXPosi ;
      private String[] T00015_A4MenXUrl ;
      private bool[] T00015_n4MenXUrl ;
      private String[] T00015_A5MenXEst ;
      private bool[] T00015_n5MenXEst ;
      private String[] T00015_A40000MenIcono_GXI ;
      private bool[] T00015_n40000MenIcono_GXI ;
      private short[] T00015_A258MenPadre ;
      private bool[] T00015_n258MenPadre ;
      private String[] T00015_A262Descripcion ;
      private String[] T00015_A259MenIcono ;
      private bool[] T00015_n259MenIcono ;
      private short[] T000112_A1MenuXid ;
      private short[] T000116_A1MenuXid ;
      private short[] T000117_A1MenuXid ;
      private String[] T000117_A127RolNombre ;
      private String[] T000117_A128RolDescripcion ;
      private int[] T000117_A24RolId ;
      private String[] T00014_A127RolNombre ;
      private String[] T00014_A128RolDescripcion ;
      private String[] T000118_A127RolNombre ;
      private String[] T000118_A128RolDescripcion ;
      private short[] T000119_A1MenuXid ;
      private int[] T000119_A24RolId ;
      private short[] T00013_A1MenuXid ;
      private int[] T00013_A24RolId ;
      private short[] T00012_A1MenuXid ;
      private int[] T00012_A24RolId ;
      private String[] T000122_A127RolNombre ;
      private String[] T000122_A128RolDescripcion ;
      private short[] T000123_A1MenuXid ;
      private int[] T000123_A24RolId ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
   }

   public class menu__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new UpdateCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00017 ;
          prmT00017 = new Object[] {
          new Object[] {"MenuXid",System.Data.DbType.Int16,4,0}
          } ;
          Object[] prmT00018 ;
          prmT00018 = new Object[] {
          new Object[] {"MenuXid",System.Data.DbType.Int16,4,0}
          } ;
          Object[] prmT00016 ;
          prmT00016 = new Object[] {
          new Object[] {"MenuXid",System.Data.DbType.Int16,4,0}
          } ;
          Object[] prmT00019 ;
          prmT00019 = new Object[] {
          new Object[] {"MenuXid",System.Data.DbType.Int16,4,0}
          } ;
          Object[] prmT000110 ;
          prmT000110 = new Object[] {
          new Object[] {"MenuXid",System.Data.DbType.Int16,4,0}
          } ;
          Object[] prmT00015 ;
          prmT00015 = new Object[] {
          new Object[] {"MenuXid",System.Data.DbType.Int16,4,0}
          } ;
          Object[] prmT000111 ;
          prmT000111 = new Object[] {
          new Object[] {"MenuXDesc",System.Data.DbType.String,40,0} ,
          new Object[] {"MenuXPosi",System.Data.DbType.Int16,4,0} ,
          new Object[] {"MenXUrl",System.Data.DbType.String,1000,0} ,
          new Object[] {"MenXEst",System.Data.DbType.String,1,0} ,
          new Object[] {"MenIcono",System.Data.DbType.Binary,1024,0} ,
          new Object[] {"MenIcono_GXI",System.Data.DbType.String,2048,0} ,
          new Object[] {"MenPadre",System.Data.DbType.Int16,4,0} ,
          new Object[] {"Descripcion",System.Data.DbType.String,120,0}
          } ;
          Object[] prmT000112 ;
          prmT000112 = new Object[] {
          } ;
          Object[] prmT000113 ;
          prmT000113 = new Object[] {
          new Object[] {"MenuXDesc",System.Data.DbType.String,40,0} ,
          new Object[] {"MenuXPosi",System.Data.DbType.Int16,4,0} ,
          new Object[] {"MenXUrl",System.Data.DbType.String,1000,0} ,
          new Object[] {"MenXEst",System.Data.DbType.String,1,0} ,
          new Object[] {"MenPadre",System.Data.DbType.Int16,4,0} ,
          new Object[] {"Descripcion",System.Data.DbType.String,120,0} ,
          new Object[] {"MenuXid",System.Data.DbType.Int16,4,0}
          } ;
          Object[] prmT000114 ;
          prmT000114 = new Object[] {
          new Object[] {"MenIcono",System.Data.DbType.Binary,1024,0} ,
          new Object[] {"MenIcono_GXI",System.Data.DbType.String,2048,0} ,
          new Object[] {"MenuXid",System.Data.DbType.Int16,4,0}
          } ;
          Object[] prmT000115 ;
          prmT000115 = new Object[] {
          new Object[] {"MenuXid",System.Data.DbType.Int16,4,0}
          } ;
          Object[] prmT000116 ;
          prmT000116 = new Object[] {
          } ;
          Object[] prmT000117 ;
          prmT000117 = new Object[] {
          new Object[] {"MenuXid",System.Data.DbType.Int16,4,0} ,
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT00014 ;
          prmT00014 = new Object[] {
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000118 ;
          prmT000118 = new Object[] {
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000119 ;
          prmT000119 = new Object[] {
          new Object[] {"MenuXid",System.Data.DbType.Int16,4,0} ,
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT00013 ;
          prmT00013 = new Object[] {
          new Object[] {"MenuXid",System.Data.DbType.Int16,4,0} ,
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT00012 ;
          prmT00012 = new Object[] {
          new Object[] {"MenuXid",System.Data.DbType.Int16,4,0} ,
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000120 ;
          prmT000120 = new Object[] {
          new Object[] {"MenuXid",System.Data.DbType.Int16,4,0} ,
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000121 ;
          prmT000121 = new Object[] {
          new Object[] {"MenuXid",System.Data.DbType.Int16,4,0} ,
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000123 ;
          prmT000123 = new Object[] {
          new Object[] {"MenuXid",System.Data.DbType.Int16,4,0}
          } ;
          Object[] prmT000122 ;
          prmT000122 = new Object[] {
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("T00012", "SELECT `MenuXid`, `RolId` FROM `MenuRol` WHERE `MenuXid` = ? AND `RolId` = ?  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00013", "SELECT `MenuXid`, `RolId` FROM `MenuRol` WHERE `MenuXid` = ? AND `RolId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00014", "SELECT `RolNombre`, `RolDescripcion` FROM `Roles` WHERE `RolId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00015", "SELECT `MenuXid`, `MenuXDesc`, `MenuXPosi`, `MenXUrl`, `MenXEst`, `MenIcono_GXI`, `MenPadre`, `Descripcion`, `MenIcono` FROM `Menu` WHERE `MenuXid` = ?  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00016", "SELECT `MenuXid`, `MenuXDesc`, `MenuXPosi`, `MenXUrl`, `MenXEst`, `MenIcono_GXI`, `MenPadre`, `Descripcion`, `MenIcono` FROM `Menu` WHERE `MenuXid` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00017", "SELECT TM1.`MenuXid`, TM1.`MenuXDesc`, TM1.`MenuXPosi`, TM1.`MenXUrl`, TM1.`MenXEst`, TM1.`MenIcono_GXI`, TM1.`MenPadre`, TM1.`Descripcion`, TM1.`MenIcono` FROM `Menu` TM1 WHERE TM1.`MenuXid` = ? ORDER BY TM1.`MenuXid` ",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00018", "SELECT `MenuXid` FROM `Menu` WHERE `MenuXid` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00018,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00019", "SELECT `MenuXid` FROM `Menu` WHERE ( `MenuXid` > ?) ORDER BY `MenuXid`  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT00019,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000110", "SELECT `MenuXid` FROM `Menu` WHERE ( `MenuXid` < ?) ORDER BY `MenuXid` DESC  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000110,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000111", "INSERT INTO `Menu`(`MenuXDesc`, `MenuXPosi`, `MenXUrl`, `MenXEst`, `MenIcono`, `MenIcono_GXI`, `MenPadre`, `Descripcion`) VALUES(?, ?, ?, ?, ?, ?, ?, ?)", GxErrorMask.GX_NOMASK,prmT000111)
             ,new CursorDef("T000112", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmT000112,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000113", "UPDATE `Menu` SET `MenuXDesc`=?, `MenuXPosi`=?, `MenXUrl`=?, `MenXEst`=?, `MenPadre`=?, `Descripcion`=?  WHERE `MenuXid` = ?", GxErrorMask.GX_NOMASK,prmT000113)
             ,new CursorDef("T000114", "UPDATE `Menu` SET `MenIcono`=?, `MenIcono_GXI`=?  WHERE `MenuXid` = ?", GxErrorMask.GX_NOMASK,prmT000114)
             ,new CursorDef("T000115", "DELETE FROM `Menu`  WHERE `MenuXid` = ?", GxErrorMask.GX_NOMASK,prmT000115)
             ,new CursorDef("T000116", "SELECT `MenuXid` FROM `Menu` ORDER BY `MenuXid` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000116,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000117", "SELECT T1.`MenuXid`, T2.`RolNombre`, T2.`RolDescripcion`, T1.`RolId` FROM (`MenuRol` T1 INNER JOIN `Roles` T2 ON T2.`RolId` = T1.`RolId`) WHERE T1.`MenuXid` = ? and T1.`RolId` = ? ORDER BY T1.`MenuXid`, T1.`RolId` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000117,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000118", "SELECT `RolNombre`, `RolDescripcion` FROM `Roles` WHERE `RolId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000118,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000119", "SELECT `MenuXid`, `RolId` FROM `MenuRol` WHERE `MenuXid` = ? AND `RolId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000119,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000120", "INSERT INTO `MenuRol`(`MenuXid`, `RolId`) VALUES(?, ?)", GxErrorMask.GX_NOMASK,prmT000120)
             ,new CursorDef("T000121", "DELETE FROM `MenuRol`  WHERE `MenuXid` = ? AND `RolId` = ?", GxErrorMask.GX_NOMASK,prmT000121)
             ,new CursorDef("T000122", "SELECT `RolNombre`, `RolDescripcion` FROM `Roles` WHERE `RolId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000122,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000123", "SELECT `MenuXid`, `RolId` FROM `MenuRol` WHERE `MenuXid` = ? ORDER BY `MenuXid`, `RolId` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000123,11, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                return;
             case 2 :
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((String[]) buf[5])[0] = rslt.getVarchar(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((String[]) buf[7])[0] = rslt.getString(5, 1) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((String[]) buf[9])[0] = rslt.getMultimediaUri(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((String[]) buf[13])[0] = rslt.getVarchar(8) ;
                ((String[]) buf[14])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(6)) ;
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((String[]) buf[5])[0] = rslt.getVarchar(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((String[]) buf[7])[0] = rslt.getString(5, 1) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((String[]) buf[9])[0] = rslt.getMultimediaUri(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((String[]) buf[13])[0] = rslt.getVarchar(8) ;
                ((String[]) buf[14])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(6)) ;
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((String[]) buf[5])[0] = rslt.getVarchar(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((String[]) buf[7])[0] = rslt.getString(5, 1) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((String[]) buf[9])[0] = rslt.getMultimediaUri(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((String[]) buf[13])[0] = rslt.getVarchar(8) ;
                ((String[]) buf[14])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(6)) ;
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((int[]) buf[3])[0] = rslt.getInt(4) ;
                return;
             case 16 :
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                return;
             case 20 :
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                return;
             case 21 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
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
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
             case 1 :
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
             case 2 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 3 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 4 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 5 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 6 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 7 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 8 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 9 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(1, (String)parms[1]);
                }
                if ( (bool)parms[2] )
                {
                   stmt.setNull( 2 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(2, (short)parms[3]);
                }
                if ( (bool)parms[4] )
                {
                   stmt.setNull( 3 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(3, (String)parms[5]);
                }
                if ( (bool)parms[6] )
                {
                   stmt.setNull( 4 , SqlDbType.NChar );
                }
                else
                {
                   stmt.SetParameter(4, (String)parms[7]);
                }
                if ( (bool)parms[8] )
                {
                   stmt.setNull( 5 , SqlDbType.VarBinary );
                }
                else
                {
                   stmt.SetParameterBlob(5, (String)parms[9], false);
                }
                if ( (bool)parms[10] )
                {
                   stmt.setNull( 6 , SqlDbType.VarChar );
                }
                else
                {
                   stmt.SetParameterMultimedia(6, (String)parms[11], (String)parms[9], "Menu", "MenIcono");
                }
                if ( (bool)parms[12] )
                {
                   stmt.setNull( 7 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(7, (short)parms[13]);
                }
                stmt.SetParameter(8, (String)parms[14]);
                return;
             case 11 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(1, (String)parms[1]);
                }
                if ( (bool)parms[2] )
                {
                   stmt.setNull( 2 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(2, (short)parms[3]);
                }
                if ( (bool)parms[4] )
                {
                   stmt.setNull( 3 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(3, (String)parms[5]);
                }
                if ( (bool)parms[6] )
                {
                   stmt.setNull( 4 , SqlDbType.NChar );
                }
                else
                {
                   stmt.SetParameter(4, (String)parms[7]);
                }
                if ( (bool)parms[8] )
                {
                   stmt.setNull( 5 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(5, (short)parms[9]);
                }
                stmt.SetParameter(6, (String)parms[10]);
                stmt.SetParameter(7, (short)parms[11]);
                return;
             case 12 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.VarBinary );
                }
                else
                {
                   stmt.SetParameterBlob(1, (String)parms[1], false);
                }
                if ( (bool)parms[2] )
                {
                   stmt.setNull( 2 , SqlDbType.VarChar );
                }
                else
                {
                   stmt.SetParameterMultimedia(2, (String)parms[3], (String)parms[1], "Menu", "MenIcono");
                }
                stmt.SetParameter(3, (short)parms[4]);
                return;
             case 13 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 15 :
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
             case 16 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 17 :
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
             case 18 :
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
             case 19 :
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
             case 20 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 21 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
       }
    }

 }

}
