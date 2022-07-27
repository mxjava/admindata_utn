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
   public class roles : GXHttpHandler, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel1"+"_"+"ROLID") == 0 )
         {
            AV7RolId = (int)(NumberUtil.Val( GetNextPar( ), "."));
            AssignAttri("", false, "AV7RolId", StringUtil.LTrimStr( (decimal)(AV7RolId), 9, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vROLID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7RolId), "ZZZZZZZZ9"), context));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX1ASAROLID0B15( AV7RolId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel2"+"_"+"ROLID") == 0 )
         {
            Gx_mode = GetNextPar( );
            AssignAttri("", false, "Gx_mode", Gx_mode);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX2ASAROLID0B15( Gx_mode) ;
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
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7RolId = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignAttri("", false, "AV7RolId", StringUtil.LTrimStr( (decimal)(AV7RolId), 9, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vROLID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7RolId), "ZZZZZZZZ9"), context));
            }
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
            Form.Meta.addItem("description", "Roles", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtRolId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public roles( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public roles( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( String aP0_Gx_mode ,
                           int aP1_RolId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7RolId = aP1_RolId;
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
            ValidateSpaRequest();
            UserMain( ) ;
            if ( ! isFullAjaxMode( ) && ( nDynComponent == 0 ) )
            {
               Draw( ) ;
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
            RenderHtmlCloseForm0B15( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         RenderHtmlHeaders( ) ;
         RenderHtmlOpenForm( ) ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Roles", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_Roles.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Roles.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Roles.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Roles.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Roles.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Roles.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRolId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRolId_Internalname, "del rol", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRolId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A24RolId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A24RolId), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRolId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRolId_Enabled, 1, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Roles.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRolNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRolNombre_Internalname, "Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRolNombre_Internalname, A127RolNombre, StringUtil.RTrim( context.localUtil.Format( A127RolNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRolNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRolNombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Roles.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRolDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRolDescripcion_Internalname, "Descripcion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRolDescripcion_Internalname, A128RolDescripcion, StringUtil.RTrim( context.localUtil.Format( A128RolDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRolDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRolDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Roles.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Roles.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Roles.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Roles.htm");
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
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110B2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z24RolId = (int)(context.localUtil.CToN( cgiGet( "Z24RolId"), ",", "."));
               Z127RolNombre = cgiGet( "Z127RolNombre");
               Z128RolDescripcion = cgiGet( "Z128RolDescripcion");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               AV7RolId = (int)(context.localUtil.CToN( cgiGet( "vROLID"), ",", "."));
               AV12Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtRolId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRolId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ROLID");
                  AnyError = 1;
                  GX_FocusControl = edtRolId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A24RolId = 0;
                  AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
               }
               else
               {
                  A24RolId = (int)(context.localUtil.CToN( cgiGet( edtRolId_Internalname), ",", "."));
                  AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
               }
               A127RolNombre = cgiGet( edtRolNombre_Internalname);
               AssignAttri("", false, "A127RolNombre", A127RolNombre);
               A128RolDescripcion = cgiGet( edtRolDescripcion_Internalname);
               AssignAttri("", false, "A128RolDescripcion", A128RolDescripcion);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Roles");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A24RolId != Z24RolId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("roles:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A24RolId = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
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
                     sMode15 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode15;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound15 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0B0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ROLID");
                        AnyError = 1;
                        GX_FocusControl = edtRolId_Internalname;
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
                        E110B2 ();
                     }
                     else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                     {
                        context.wbHandled = 1;
                        dynload_actions( ) ;
                        /* Execute user event: After Trn */
                        E120B2 ();
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
                  }
               }
               context.wbHandled = 1;
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
            E120B2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0B15( ) ;
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
            DisableAttributes0B15( ) ;
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

      protected void CONFIRM_0B0( )
      {
         BeforeValidate0B15( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0B15( ) ;
            }
            else
            {
               CheckExtendedTable0B15( ) ;
               CloseExtendedTableCursors0B15( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0B0( )
      {
      }

      protected void E110B2( )
      {
         /* Start Routine */
         if ( ! new isauthorized(context).executeUdp(  AV12Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV12Pgmname)));
            context.wjLocDisableFrm = 1;
         }
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "TransactionContext", "ADMINDATA1");
      }

      protected void E120B2( )
      {
         /* After Trn Routine */
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwroles.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0B15( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z127RolNombre = T000B3_A127RolNombre[0];
               Z128RolDescripcion = T000B3_A128RolDescripcion[0];
            }
            else
            {
               Z127RolNombre = A127RolNombre;
               Z128RolDescripcion = A128RolDescripcion;
            }
         }
         if ( GX_JID == -5 )
         {
            Z24RolId = A24RolId;
            Z127RolNombre = A127RolNombre;
            Z128RolDescripcion = A128RolDescripcion;
         }
      }

      protected void standaloneNotModal( )
      {
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7RolId) )
         {
            A24RolId = AV7RolId;
            AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
         }
         if ( ! (0==AV7RolId) )
         {
            edtRolId_Enabled = 0;
            AssignProp("", false, edtRolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRolId_Enabled), 5, 0), true);
         }
         else
         {
            edtRolId_Enabled = 1;
            AssignProp("", false, edtRolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRolId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7RolId) )
         {
            edtRolId_Enabled = 0;
            AssignProp("", false, edtRolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRolId_Enabled), 5, 0), true);
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV12Pgmname = "Roles";
            AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
         }
      }

      protected void Load0B15( )
      {
         /* Using cursor T000B4 */
         pr_default.execute(2, new Object[] {A24RolId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound15 = 1;
            A127RolNombre = T000B4_A127RolNombre[0];
            AssignAttri("", false, "A127RolNombre", A127RolNombre);
            A128RolDescripcion = T000B4_A128RolDescripcion[0];
            AssignAttri("", false, "A128RolDescripcion", A128RolDescripcion);
            ZM0B15( -5) ;
         }
         pr_default.close(2);
         OnLoadActions0B15( ) ;
      }

      protected void OnLoadActions0B15( )
      {
         AV12Pgmname = "Roles";
         AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
      }

      protected void CheckExtendedTable0B15( )
      {
         nIsDirty_15 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV12Pgmname = "Roles";
         AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
      }

      protected void CloseExtendedTableCursors0B15( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0B15( )
      {
         /* Using cursor T000B5 */
         pr_default.execute(3, new Object[] {A24RolId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound15 = 1;
         }
         else
         {
            RcdFound15 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000B3 */
         pr_default.execute(1, new Object[] {A24RolId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0B15( 5) ;
            RcdFound15 = 1;
            A24RolId = T000B3_A24RolId[0];
            AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
            A127RolNombre = T000B3_A127RolNombre[0];
            AssignAttri("", false, "A127RolNombre", A127RolNombre);
            A128RolDescripcion = T000B3_A128RolDescripcion[0];
            AssignAttri("", false, "A128RolDescripcion", A128RolDescripcion);
            Z24RolId = A24RolId;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0B15( ) ;
            if ( AnyError == 1 )
            {
               RcdFound15 = 0;
               InitializeNonKey0B15( ) ;
            }
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound15 = 0;
            InitializeNonKey0B15( ) ;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0B15( ) ;
         if ( RcdFound15 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound15 = 0;
         /* Using cursor T000B6 */
         pr_default.execute(4, new Object[] {A24RolId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000B6_A24RolId[0] < A24RolId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000B6_A24RolId[0] > A24RolId ) ) )
            {
               A24RolId = T000B6_A24RolId[0];
               AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound15 = 0;
         /* Using cursor T000B7 */
         pr_default.execute(5, new Object[] {A24RolId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000B7_A24RolId[0] > A24RolId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000B7_A24RolId[0] < A24RolId ) ) )
            {
               A24RolId = T000B7_A24RolId[0];
               AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0B15( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtRolId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0B15( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound15 == 1 )
            {
               if ( A24RolId != Z24RolId )
               {
                  A24RolId = Z24RolId;
                  AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ROLID");
                  AnyError = 1;
                  GX_FocusControl = edtRolId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtRolId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0B15( ) ;
                  GX_FocusControl = edtRolId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A24RolId != Z24RolId )
               {
                  /* Insert record */
                  GX_FocusControl = edtRolId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0B15( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ROLID");
                     AnyError = 1;
                     GX_FocusControl = edtRolId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtRolId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0B15( ) ;
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
         if ( A24RolId != Z24RolId )
         {
            A24RolId = Z24RolId;
            AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ROLID");
            AnyError = 1;
            GX_FocusControl = edtRolId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtRolId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0B15( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000B2 */
            pr_default.execute(0, new Object[] {A24RolId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Roles"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z127RolNombre, T000B2_A127RolNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z128RolDescripcion, T000B2_A128RolDescripcion[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z127RolNombre, T000B2_A127RolNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("roles:[seudo value changed for attri]"+"RolNombre");
                  GXUtil.WriteLogRaw("Old: ",Z127RolNombre);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A127RolNombre[0]);
               }
               if ( StringUtil.StrCmp(Z128RolDescripcion, T000B2_A128RolDescripcion[0]) != 0 )
               {
                  GXUtil.WriteLog("roles:[seudo value changed for attri]"+"RolDescripcion");
                  GXUtil.WriteLogRaw("Old: ",Z128RolDescripcion);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A128RolDescripcion[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Roles"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B15( )
      {
         BeforeValidate0B15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B15( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B15( 0) ;
            CheckOptimisticConcurrency0B15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B8 */
                     pr_default.execute(6, new Object[] {A24RolId, A127RolNombre, A128RolDescripcion});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Roles") ;
                     if ( (pr_default.getStatus(6) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        GXt_int1 = A24RolId;
                        new pnumerar(context ).execute(  "ROL", out  GXt_int1) ;
                        A24RolId = (int)(GXt_int1);
                        AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0B0( ) ;
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
               Load0B15( ) ;
            }
            EndLevel0B15( ) ;
         }
         CloseExtendedTableCursors0B15( ) ;
      }

      protected void Update0B15( )
      {
         BeforeValidate0B15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B15( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0B15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B9 */
                     pr_default.execute(7, new Object[] {A127RolNombre, A128RolDescripcion, A24RolId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("Roles") ;
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Roles"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0B15( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
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
            EndLevel0B15( ) ;
         }
         CloseExtendedTableCursors0B15( ) ;
      }

      protected void DeferredUpdate0B15( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0B15( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B15( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B15( ) ;
            AfterConfirm0B15( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B15( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000B10 */
                  pr_default.execute(8, new Object[] {A24RolId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("Roles") ;
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
         sMode15 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0B15( ) ;
         Gx_mode = sMode15;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0B15( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV12Pgmname = "Roles";
            AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000B11 */
            pr_default.execute(9, new Object[] {A24RolId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tabla de usuarios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T000B12 */
            pr_default.execute(10, new Object[] {A24RolId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"MenuRol"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel0B15( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0B15( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("roles",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0B0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("roles",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0B15( )
      {
         /* Scan By routine */
         /* Using cursor T000B13 */
         pr_default.execute(11);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound15 = 1;
            A24RolId = T000B13_A24RolId[0];
            AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0B15( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound15 = 1;
            A24RolId = T000B13_A24RolId[0];
            AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
         }
      }

      protected void ScanEnd0B15( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0B15( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B15( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B15( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B15( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B15( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B15( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B15( )
      {
         edtRolId_Enabled = 0;
         AssignProp("", false, edtRolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRolId_Enabled), 5, 0), true);
         edtRolNombre_Enabled = 0;
         AssignProp("", false, edtRolNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRolNombre_Enabled), 5, 0), true);
         edtRolDescripcion_Enabled = 0;
         AssignProp("", false, edtRolDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRolDescripcion_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0B15( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0B0( )
      {
      }

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( "Roles") ;
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
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 2036420), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202262714344097", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "";
         bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("roles.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode("" +AV7RolId)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Roles");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("roles:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z24RolId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z24RolId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z127RolNombre", Z127RolNombre);
         GxWebStd.gx_hidden_field( context, "Z128RolDescripcion", Z128RolDescripcion);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV10TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV10TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vROLID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7RolId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vROLID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7RolId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV12Pgmname));
      }

      protected void RenderHtmlCloseForm0B15( )
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
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override String GetPgmname( )
      {
         return "Roles" ;
      }

      public override String GetPgmdesc( )
      {
         return "Roles" ;
      }

      protected void InitializeNonKey0B15( )
      {
         A127RolNombre = "";
         AssignAttri("", false, "A127RolNombre", A127RolNombre);
         A128RolDescripcion = "";
         AssignAttri("", false, "A128RolDescripcion", A128RolDescripcion);
         Z127RolNombre = "";
         Z128RolDescripcion = "";
      }

      protected void InitAll0B15( )
      {
         A24RolId = 0;
         AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
         InitializeNonKey0B15( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?20226271434410", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("roles.js", "?20226271434410", false, true);
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
         edtRolId_Internalname = "ROLID";
         edtRolNombre_Internalname = "ROLNOMBRE";
         edtRolDescripcion_Internalname = "ROLDESCRIPCION";
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
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtRolDescripcion_Jsonclick = "";
         edtRolDescripcion_Enabled = 1;
         edtRolNombre_Jsonclick = "";
         edtRolNombre_Enabled = 1;
         edtRolId_Jsonclick = "";
         edtRolId_Enabled = 1;
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

      protected void GX1ASAROLID0B15( int AV7RolId )
      {
         if ( ! (0==AV7RolId) )
         {
            A24RolId = AV7RolId;
            AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A24RolId), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX2ASAROLID0B15( String Gx_mode )
      {
         GXt_int1 = A24RolId;
         new pnumerar(context ).execute(  "ROL", out  GXt_int1) ;
         A24RolId = (int)(GXt_int1);
         AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A24RolId), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7RolId',fld:'vROLID',pic:'ZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7RolId',fld:'vROLID',pic:'ZZZZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120B2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_ROLID","{handler:'Valid_Rolid',iparms:[]");
         setEventMetadata("VALID_ROLID",",oparms:[]}");
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
         wcpOGx_mode = "";
         Z127RolNombre = "";
         Z128RolDescripcion = "";
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
         A127RolNombre = "";
         A128RolDescripcion = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV12Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode15 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV10TrnContext = new SdtTransactionContext(context);
         AV11WebSession = context.GetSession();
         T000B4_A24RolId = new int[1] ;
         T000B4_A127RolNombre = new String[] {""} ;
         T000B4_A128RolDescripcion = new String[] {""} ;
         T000B5_A24RolId = new int[1] ;
         T000B3_A24RolId = new int[1] ;
         T000B3_A127RolNombre = new String[] {""} ;
         T000B3_A128RolDescripcion = new String[] {""} ;
         T000B6_A24RolId = new int[1] ;
         T000B7_A24RolId = new int[1] ;
         T000B2_A24RolId = new int[1] ;
         T000B2_A127RolNombre = new String[] {""} ;
         T000B2_A128RolDescripcion = new String[] {""} ;
         T000B11_A11UsuariosId = new int[1] ;
         T000B12_A1MenuXid = new short[1] ;
         T000B12_A24RolId = new int[1] ;
         T000B13_A24RolId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.roles__default(),
            new Object[][] {
                new Object[] {
               T000B2_A24RolId, T000B2_A127RolNombre, T000B2_A128RolDescripcion
               }
               , new Object[] {
               T000B3_A24RolId, T000B3_A127RolNombre, T000B3_A128RolDescripcion
               }
               , new Object[] {
               T000B4_A24RolId, T000B4_A127RolNombre, T000B4_A128RolDescripcion
               }
               , new Object[] {
               T000B5_A24RolId
               }
               , new Object[] {
               T000B6_A24RolId
               }
               , new Object[] {
               T000B7_A24RolId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000B11_A11UsuariosId
               }
               , new Object[] {
               T000B12_A1MenuXid, T000B12_A24RolId
               }
               , new Object[] {
               T000B13_A24RolId
               }
            }
         );
         AV12Pgmname = "Roles";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short RcdFound15 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_15 ;
      private int wcpOAV7RolId ;
      private int Z24RolId ;
      private int AV7RolId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A24RolId ;
      private int edtRolId_Enabled ;
      private int edtRolNombre_Enabled ;
      private int edtRolDescripcion_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long GXt_int1 ;
      private String sPrefix ;
      private String wcpOGx_mode ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String Gx_mode ;
      private String GXKey ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String GX_FocusControl ;
      private String edtRolId_Internalname ;
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
      private String edtRolId_Jsonclick ;
      private String edtRolNombre_Internalname ;
      private String edtRolNombre_Jsonclick ;
      private String edtRolDescripcion_Internalname ;
      private String edtRolDescripcion_Jsonclick ;
      private String bttBtn_enter_Internalname ;
      private String bttBtn_enter_Jsonclick ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String bttBtn_delete_Internalname ;
      private String bttBtn_delete_Jsonclick ;
      private String AV12Pgmname ;
      private String hsh ;
      private String sMode15 ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String endTrnMsgTxt ;
      private String endTrnMsgCod ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private String Z127RolNombre ;
      private String Z128RolDescripcion ;
      private String A127RolNombre ;
      private String A128RolDescripcion ;
      private IGxSession AV11WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T000B4_A24RolId ;
      private String[] T000B4_A127RolNombre ;
      private String[] T000B4_A128RolDescripcion ;
      private int[] T000B5_A24RolId ;
      private int[] T000B3_A24RolId ;
      private String[] T000B3_A127RolNombre ;
      private String[] T000B3_A128RolDescripcion ;
      private int[] T000B6_A24RolId ;
      private int[] T000B7_A24RolId ;
      private int[] T000B2_A24RolId ;
      private String[] T000B2_A127RolNombre ;
      private String[] T000B2_A128RolDescripcion ;
      private int[] T000B11_A11UsuariosId ;
      private short[] T000B12_A1MenuXid ;
      private int[] T000B12_A24RolId ;
      private int[] T000B13_A24RolId ;
      private SdtTransactionContext AV10TrnContext ;
   }

   public class roles__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000B4 ;
          prmT000B4 = new Object[] {
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000B5 ;
          prmT000B5 = new Object[] {
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000B3 ;
          prmT000B3 = new Object[] {
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000B6 ;
          prmT000B6 = new Object[] {
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000B7 ;
          prmT000B7 = new Object[] {
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000B2 ;
          prmT000B2 = new Object[] {
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000B8 ;
          prmT000B8 = new Object[] {
          new Object[] {"RolId",System.Data.DbType.Int32,9,0} ,
          new Object[] {"RolNombre",System.Data.DbType.String,40,0} ,
          new Object[] {"RolDescripcion",System.Data.DbType.String,150,0}
          } ;
          Object[] prmT000B9 ;
          prmT000B9 = new Object[] {
          new Object[] {"RolNombre",System.Data.DbType.String,40,0} ,
          new Object[] {"RolDescripcion",System.Data.DbType.String,150,0} ,
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000B10 ;
          prmT000B10 = new Object[] {
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000B11 ;
          prmT000B11 = new Object[] {
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000B12 ;
          prmT000B12 = new Object[] {
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000B13 ;
          prmT000B13 = new Object[] {
          } ;
          def= new CursorDef[] {
              new CursorDef("T000B2", "SELECT `RolId`, `RolNombre`, `RolDescripcion` FROM `Roles` WHERE `RolId` = ?  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B3", "SELECT `RolId`, `RolNombre`, `RolDescripcion` FROM `Roles` WHERE `RolId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B4", "SELECT TM1.`RolId`, TM1.`RolNombre`, TM1.`RolDescripcion` FROM `Roles` TM1 WHERE TM1.`RolId` = ? ORDER BY TM1.`RolId` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B5", "SELECT `RolId` FROM `Roles` WHERE `RolId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B6", "SELECT `RolId` FROM `Roles` WHERE ( `RolId` > ?) ORDER BY `RolId`  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000B6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000B7", "SELECT `RolId` FROM `Roles` WHERE ( `RolId` < ?) ORDER BY `RolId` DESC  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000B7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000B8", "INSERT INTO `Roles`(`RolId`, `RolNombre`, `RolDescripcion`) VALUES(?, ?, ?)", GxErrorMask.GX_NOMASK,prmT000B8)
             ,new CursorDef("T000B9", "UPDATE `Roles` SET `RolNombre`=?, `RolDescripcion`=?  WHERE `RolId` = ?", GxErrorMask.GX_NOMASK,prmT000B9)
             ,new CursorDef("T000B10", "DELETE FROM `Roles`  WHERE `RolId` = ?", GxErrorMask.GX_NOMASK,prmT000B10)
             ,new CursorDef("T000B11", "SELECT `UsuariosId` FROM `Usuarios` WHERE `RolId` = ?  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000B11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000B12", "SELECT `MenuXid`, `RolId` FROM `MenuRol` WHERE `RolId` = ?  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000B12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000B13", "SELECT `RolId` FROM `Roles` ORDER BY `RolId` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B13,100, GxCacheFrequency.OFF ,true,false )
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
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
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
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                return;
             case 11 :
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
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (String)parms[2]);
                return;
             case 7 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                return;
             case 8 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 9 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 10 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

}
