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
   public class rolesusuarios : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
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
               AV8UsuariosId = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignAttri("", false, "AV8UsuariosId", StringUtil.LTrimStr( (decimal)(AV8UsuariosId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8UsuariosId), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Roles Usuarios", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtUsuariosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public rolesusuarios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public rolesusuarios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( String aP0_Gx_mode ,
                           int aP1_UsuariosId ,
                           int aP2_RolId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV8UsuariosId = aP1_UsuariosId;
         this.AV7RolId = aP2_RolId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Roles Usuarios", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_RolesUsuarios.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_RolesUsuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_RolesUsuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_RolesUsuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_RolesUsuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_RolesUsuarios.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosId_Internalname, "Clave de usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuariosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")), ((edtUsuariosId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9")) : context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosId_Enabled, 0, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "NumId", "right", false, "", "HLP_RolesUsuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRolId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRolId_Internalname, "Clave del rol", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRolId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A24RolId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A24RolId), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRolId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRolId_Enabled, 1, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_RolesUsuarios.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_RolesUsuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_RolesUsuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_RolesUsuarios.htm");
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
            Z11UsuariosId = (int)(context.localUtil.CToN( cgiGet( "Z11UsuariosId"), ",", "."));
            Z24RolId = (int)(context.localUtil.CToN( cgiGet( "Z24RolId"), ",", "."));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
            Gx_mode = cgiGet( "Mode");
            AV8UsuariosId = (int)(context.localUtil.CToN( cgiGet( "vUSUARIOSID"), ",", "."));
            AV7RolId = (int)(context.localUtil.CToN( cgiGet( "vROLID"), ",", "."));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtUsuariosId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuariosId_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIOSID");
               AnyError = 1;
               GX_FocusControl = edtUsuariosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A11UsuariosId = 0;
               n11UsuariosId = false;
               AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
            }
            else
            {
               A11UsuariosId = (int)(context.localUtil.CToN( cgiGet( edtUsuariosId_Internalname), ",", "."));
               n11UsuariosId = false;
               AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
            }
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
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"RolesUsuarios");
            forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( A11UsuariosId != Z11UsuariosId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("rolesusuarios:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A11UsuariosId = (int)(NumberUtil.Val( GetNextPar( ), "."));
               n11UsuariosId = false;
               AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
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
                  sMode9 = Gx_mode;
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Gx_mode = sMode9;
                  AssignAttri("", false, "Gx_mode", Gx_mode);
               }
               standaloneModal( ) ;
               if ( ! IsIns( ) )
               {
                  getByPrimaryKey( ) ;
                  if ( RcdFound9 == 1 )
                  {
                     if ( IsDlt( ) )
                     {
                        /* Confirm record */
                        CONFIRM_0C0( ) ;
                        if ( AnyError == 0 )
                        {
                           GX_FocusControl = bttBtn_enter_Internalname;
                           AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "USUARIOSID");
                     AnyError = 1;
                     GX_FocusControl = edtUsuariosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
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
               InitAll0C9( ) ;
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
            DisableAttributes0C9( ) ;
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

      protected void CONFIRM_0C0( )
      {
         BeforeValidate0C9( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0C9( ) ;
            }
            else
            {
               CheckExtendedTable0C9( ) ;
               CloseExtendedTableCursors0C9( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0C0( )
      {
      }

      protected void ZM0C9( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z24RolId = T000C3_A24RolId[0];
            }
            else
            {
               Z24RolId = A24RolId;
            }
         }
         if ( GX_JID == -5 )
         {
            Z11UsuariosId = A11UsuariosId;
            Z24RolId = A24RolId;
         }
      }

      protected void standaloneNotModal( )
      {
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV8UsuariosId) )
         {
            A11UsuariosId = AV8UsuariosId;
            n11UsuariosId = false;
            AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
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
         if ( ! (0==AV7RolId) )
         {
            A24RolId = AV7RolId;
            AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
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

      protected void Load0C9( )
      {
         /* Using cursor T000C5 */
         pr_default.execute(3, new Object[] {n11UsuariosId, A11UsuariosId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound9 = 1;
            A24RolId = T000C5_A24RolId[0];
            AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
            ZM0C9( -5) ;
         }
         pr_default.close(3);
         OnLoadActions0C9( ) ;
      }

      protected void OnLoadActions0C9( )
      {
      }

      protected void CheckExtendedTable0C9( )
      {
         nIsDirty_9 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000C4 */
         pr_default.execute(2, new Object[] {A24RolId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Roles'.", "ForeignKeyNotFound", 1, "ROLID");
            AnyError = 1;
            GX_FocusControl = edtRolId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0C9( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_6( int A24RolId )
      {
         /* Using cursor T000C6 */
         pr_default.execute(4, new Object[] {A24RolId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Roles'.", "ForeignKeyNotFound", 1, "ROLID");
            AnyError = 1;
            GX_FocusControl = edtRolId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0C9( )
      {
         /* Using cursor T000C7 */
         pr_default.execute(5, new Object[] {n11UsuariosId, A11UsuariosId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000C3 */
         pr_default.execute(1, new Object[] {n11UsuariosId, A11UsuariosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C9( 5) ;
            RcdFound9 = 1;
            A11UsuariosId = T000C3_A11UsuariosId[0];
            n11UsuariosId = T000C3_n11UsuariosId[0];
            AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
            A24RolId = T000C3_A24RolId[0];
            AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
            Z11UsuariosId = A11UsuariosId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0C9( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey0C9( ) ;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey0C9( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C9( ) ;
         if ( RcdFound9 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound9 = 0;
         /* Using cursor T000C8 */
         pr_default.execute(6, new Object[] {n11UsuariosId, A11UsuariosId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000C8_A11UsuariosId[0] < A11UsuariosId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000C8_A11UsuariosId[0] > A11UsuariosId ) ) )
            {
               A11UsuariosId = T000C8_A11UsuariosId[0];
               n11UsuariosId = T000C8_n11UsuariosId[0];
               AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound9 = 0;
         /* Using cursor T000C9 */
         pr_default.execute(7, new Object[] {n11UsuariosId, A11UsuariosId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000C9_A11UsuariosId[0] > A11UsuariosId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000C9_A11UsuariosId[0] < A11UsuariosId ) ) )
            {
               A11UsuariosId = T000C9_A11UsuariosId[0];
               n11UsuariosId = T000C9_n11UsuariosId[0];
               AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0C9( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUsuariosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0C9( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A11UsuariosId != Z11UsuariosId )
               {
                  A11UsuariosId = Z11UsuariosId;
                  n11UsuariosId = false;
                  AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "USUARIOSID");
                  AnyError = 1;
                  GX_FocusControl = edtUsuariosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtUsuariosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0C9( ) ;
                  GX_FocusControl = edtUsuariosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A11UsuariosId != Z11UsuariosId )
               {
                  /* Insert record */
                  GX_FocusControl = edtUsuariosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0C9( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "USUARIOSID");
                     AnyError = 1;
                     GX_FocusControl = edtUsuariosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtUsuariosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0C9( ) ;
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
         if ( A11UsuariosId != Z11UsuariosId )
         {
            A11UsuariosId = Z11UsuariosId;
            n11UsuariosId = false;
            AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "USUARIOSID");
            AnyError = 1;
            GX_FocusControl = edtUsuariosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtUsuariosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0C9( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000C2 */
            pr_default.execute(0, new Object[] {n11UsuariosId, A11UsuariosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Usuarios"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z24RolId != T000C2_A24RolId[0] ) )
            {
               if ( Z24RolId != T000C2_A24RolId[0] )
               {
                  GXUtil.WriteLog("rolesusuarios:[seudo value changed for attri]"+"RolId");
                  GXUtil.WriteLogRaw("Old: ",Z24RolId);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A24RolId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Usuarios"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C9( )
      {
         BeforeValidate0C9( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C9( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C9( 0) ;
            CheckOptimisticConcurrency0C9( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C9( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C9( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C10 */
                     pr_default.execute(8, new Object[] {n11UsuariosId, A11UsuariosId, A24RolId});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("Usuarios") ;
                     if ( (pr_default.getStatus(8) == 1) )
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
                           ResetCaption0C0( ) ;
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
               Load0C9( ) ;
            }
            EndLevel0C9( ) ;
         }
         CloseExtendedTableCursors0C9( ) ;
      }

      protected void Update0C9( )
      {
         BeforeValidate0C9( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C9( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C9( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C9( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C9( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C11 */
                     pr_default.execute(9, new Object[] {A24RolId, n11UsuariosId, A11UsuariosId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Usuarios") ;
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Usuarios"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C9( ) ;
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
            EndLevel0C9( ) ;
         }
         CloseExtendedTableCursors0C9( ) ;
      }

      protected void DeferredUpdate0C9( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0C9( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C9( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C9( ) ;
            AfterConfirm0C9( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C9( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000C12 */
                  pr_default.execute(10, new Object[] {n11UsuariosId, A11UsuariosId});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("Usuarios") ;
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0C9( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0C9( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000C13 */
            pr_default.execute(11, new Object[] {n11UsuariosId, A11UsuariosId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"bitAcces"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T000C14 */
            pr_default.execute(12, new Object[] {n11UsuariosId, A11UsuariosId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"VacantesUsuariosVacante"+" ("+"SUBT_Reclutador"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000C15 */
            pr_default.execute(13, new Object[] {n11UsuariosId, A11UsuariosId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"VacantesUsuariosVacante"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000C16 */
            pr_default.execute(14, new Object[] {n11UsuariosId, A11UsuariosId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios Perfil"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T000C17 */
            pr_default.execute(15, new Object[] {n11UsuariosId, A11UsuariosId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Intentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T000C18 */
            pr_default.execute(16, new Object[] {n11UsuariosId, A11UsuariosId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Historico de Contrasenas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void EndLevel0C9( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C9( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("rolesusuarios",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0C0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("rolesusuarios",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0C9( )
      {
         /* Scan By routine */
         /* Using cursor T000C19 */
         pr_default.execute(17);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound9 = 1;
            A11UsuariosId = T000C19_A11UsuariosId[0];
            n11UsuariosId = T000C19_n11UsuariosId[0];
            AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0C9( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound9 = 1;
            A11UsuariosId = T000C19_A11UsuariosId[0];
            n11UsuariosId = T000C19_n11UsuariosId[0];
            AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
         }
      }

      protected void ScanEnd0C9( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm0C9( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C9( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C9( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C9( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C9( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C9( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C9( )
      {
         edtUsuariosId_Enabled = 0;
         AssignProp("", false, edtUsuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosId_Enabled), 5, 0), true);
         edtRolId_Enabled = 0;
         AssignProp("", false, edtRolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRolId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0C9( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0C0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202262714344156", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("rolesusuarios.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode("" +AV8UsuariosId) + "," + UrlEncode("" +AV7RolId)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"RolesUsuarios");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("rolesusuarios:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z11UsuariosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11UsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z24RolId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z24RolId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8UsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8UsuariosId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vROLID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7RolId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vROLID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7RolId), "ZZZZZZZZ9"), context));
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
         return formatLink("rolesusuarios.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode("" +AV8UsuariosId) + "," + UrlEncode("" +AV7RolId) ;
      }

      public override String GetPgmname( )
      {
         return "RolesUsuarios" ;
      }

      public override String GetPgmdesc( )
      {
         return "Roles Usuarios" ;
      }

      protected void InitializeNonKey0C9( )
      {
         A24RolId = 0;
         AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
         Z24RolId = 0;
      }

      protected void InitAll0C9( )
      {
         A11UsuariosId = 0;
         n11UsuariosId = false;
         AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
         InitializeNonKey0C9( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714344159", true, true);
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
         context.AddJavascriptSource("rolesusuarios.js", "?202262714344160", false, true);
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
         edtUsuariosId_Internalname = "USUARIOSID";
         edtRolId_Internalname = "ROLID";
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
         Form.Caption = "Roles Usuarios";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtRolId_Jsonclick = "";
         edtRolId_Enabled = 1;
         edtUsuariosId_Jsonclick = "";
         edtUsuariosId_Enabled = 1;
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
         /* Using cursor T000C20 */
         pr_default.execute(18, new Object[] {A24RolId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Roles'.", "ForeignKeyNotFound", 1, "ROLID");
            AnyError = 1;
            GX_FocusControl = edtRolId_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV8UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true},{av:'AV7RolId',fld:'vROLID',pic:'ZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV8UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true},{av:'AV7RolId',fld:'vROLID',pic:'ZZZZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSID","{handler:'Valid_Usuariosid',iparms:[]");
         setEventMetadata("VALID_USUARIOSID",",oparms:[]}");
         setEventMetadata("VALID_ROLID","{handler:'Valid_Rolid',iparms:[{av:'A24RolId',fld:'ROLID',pic:'ZZZZZZZZ9'}]");
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
         pr_default.close(18);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
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
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode9 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T000C5_A11UsuariosId = new int[1] ;
         T000C5_n11UsuariosId = new bool[] {false} ;
         T000C5_A24RolId = new int[1] ;
         T000C4_A24RolId = new int[1] ;
         T000C6_A24RolId = new int[1] ;
         T000C7_A11UsuariosId = new int[1] ;
         T000C7_n11UsuariosId = new bool[] {false} ;
         T000C3_A11UsuariosId = new int[1] ;
         T000C3_n11UsuariosId = new bool[] {false} ;
         T000C3_A24RolId = new int[1] ;
         T000C8_A11UsuariosId = new int[1] ;
         T000C8_n11UsuariosId = new bool[] {false} ;
         T000C9_A11UsuariosId = new int[1] ;
         T000C9_n11UsuariosId = new bool[] {false} ;
         T000C2_A11UsuariosId = new int[1] ;
         T000C2_n11UsuariosId = new bool[] {false} ;
         T000C2_A24RolId = new int[1] ;
         T000C13_A61bitAccesFec = new DateTime[] {DateTime.MinValue} ;
         T000C13_A75bitAccesIp = new String[] {""} ;
         T000C14_A263Vacantes_Id = new int[1] ;
         T000C14_A11UsuariosId = new int[1] ;
         T000C14_n11UsuariosId = new bool[] {false} ;
         T000C15_A263Vacantes_Id = new int[1] ;
         T000C15_A11UsuariosId = new int[1] ;
         T000C15_n11UsuariosId = new bool[] {false} ;
         T000C16_A278Perfiles_Id = new int[1] ;
         T000C16_A11UsuariosId = new int[1] ;
         T000C16_n11UsuariosId = new bool[] {false} ;
         T000C17_A11UsuariosId = new int[1] ;
         T000C17_n11UsuariosId = new bool[] {false} ;
         T000C17_A30FechaIntento = new DateTime[] {DateTime.MinValue} ;
         T000C18_A11UsuariosId = new int[1] ;
         T000C18_n11UsuariosId = new bool[] {false} ;
         T000C18_A62HisPwdFecha = new DateTime[] {DateTime.MinValue} ;
         T000C19_A11UsuariosId = new int[1] ;
         T000C19_n11UsuariosId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000C20_A24RolId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rolesusuarios__default(),
            new Object[][] {
                new Object[] {
               T000C2_A11UsuariosId, T000C2_A24RolId
               }
               , new Object[] {
               T000C3_A11UsuariosId, T000C3_A24RolId
               }
               , new Object[] {
               T000C4_A24RolId
               }
               , new Object[] {
               T000C5_A11UsuariosId, T000C5_A24RolId
               }
               , new Object[] {
               T000C6_A24RolId
               }
               , new Object[] {
               T000C7_A11UsuariosId
               }
               , new Object[] {
               T000C8_A11UsuariosId
               }
               , new Object[] {
               T000C9_A11UsuariosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000C13_A61bitAccesFec, T000C13_A75bitAccesIp
               }
               , new Object[] {
               T000C14_A263Vacantes_Id, T000C14_A11UsuariosId
               }
               , new Object[] {
               T000C15_A263Vacantes_Id, T000C15_A11UsuariosId
               }
               , new Object[] {
               T000C16_A278Perfiles_Id, T000C16_A11UsuariosId
               }
               , new Object[] {
               T000C17_A11UsuariosId, T000C17_A30FechaIntento
               }
               , new Object[] {
               T000C18_A11UsuariosId, T000C18_A62HisPwdFecha
               }
               , new Object[] {
               T000C19_A11UsuariosId
               }
               , new Object[] {
               T000C20_A24RolId
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
      private short RcdFound9 ;
      private short GX_JID ;
      private short nIsDirty_9 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV8UsuariosId ;
      private int wcpOAV7RolId ;
      private int Z11UsuariosId ;
      private int Z24RolId ;
      private int A24RolId ;
      private int AV8UsuariosId ;
      private int AV7RolId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A11UsuariosId ;
      private int edtUsuariosId_Enabled ;
      private int edtRolId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
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
      private String edtUsuariosId_Internalname ;
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
      private String edtUsuariosId_Jsonclick ;
      private String edtRolId_Internalname ;
      private String edtRolId_Jsonclick ;
      private String bttBtn_enter_Internalname ;
      private String bttBtn_enter_Jsonclick ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String bttBtn_delete_Internalname ;
      private String bttBtn_delete_Jsonclick ;
      private String hsh ;
      private String sMode9 ;
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
      private bool n11UsuariosId ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T000C5_A11UsuariosId ;
      private bool[] T000C5_n11UsuariosId ;
      private int[] T000C5_A24RolId ;
      private int[] T000C4_A24RolId ;
      private int[] T000C6_A24RolId ;
      private int[] T000C7_A11UsuariosId ;
      private bool[] T000C7_n11UsuariosId ;
      private int[] T000C3_A11UsuariosId ;
      private bool[] T000C3_n11UsuariosId ;
      private int[] T000C3_A24RolId ;
      private int[] T000C8_A11UsuariosId ;
      private bool[] T000C8_n11UsuariosId ;
      private int[] T000C9_A11UsuariosId ;
      private bool[] T000C9_n11UsuariosId ;
      private int[] T000C2_A11UsuariosId ;
      private bool[] T000C2_n11UsuariosId ;
      private int[] T000C2_A24RolId ;
      private DateTime[] T000C13_A61bitAccesFec ;
      private String[] T000C13_A75bitAccesIp ;
      private int[] T000C14_A263Vacantes_Id ;
      private int[] T000C14_A11UsuariosId ;
      private bool[] T000C14_n11UsuariosId ;
      private int[] T000C15_A263Vacantes_Id ;
      private int[] T000C15_A11UsuariosId ;
      private bool[] T000C15_n11UsuariosId ;
      private int[] T000C16_A278Perfiles_Id ;
      private int[] T000C16_A11UsuariosId ;
      private bool[] T000C16_n11UsuariosId ;
      private int[] T000C17_A11UsuariosId ;
      private bool[] T000C17_n11UsuariosId ;
      private DateTime[] T000C17_A30FechaIntento ;
      private int[] T000C18_A11UsuariosId ;
      private bool[] T000C18_n11UsuariosId ;
      private DateTime[] T000C18_A62HisPwdFecha ;
      private int[] T000C19_A11UsuariosId ;
      private bool[] T000C19_n11UsuariosId ;
      private int[] T000C20_A24RolId ;
      private GXWebForm Form ;
   }

   public class rolesusuarios__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000C5 ;
          prmT000C5 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000C4 ;
          prmT000C4 = new Object[] {
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000C6 ;
          prmT000C6 = new Object[] {
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000C7 ;
          prmT000C7 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000C3 ;
          prmT000C3 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000C8 ;
          prmT000C8 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000C9 ;
          prmT000C9 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000C2 ;
          prmT000C2 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000C10 ;
          prmT000C10 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000C11 ;
          prmT000C11 = new Object[] {
          new Object[] {"RolId",System.Data.DbType.Int32,9,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000C12 ;
          prmT000C12 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000C13 ;
          prmT000C13 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000C14 ;
          prmT000C14 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000C15 ;
          prmT000C15 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000C16 ;
          prmT000C16 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000C17 ;
          prmT000C17 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000C18 ;
          prmT000C18 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000C19 ;
          prmT000C19 = new Object[] {
          } ;
          Object[] prmT000C20 ;
          prmT000C20 = new Object[] {
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("T000C2", "SELECT `UsuariosId`, `RolId` FROM `Usuarios` WHERE `UsuariosId` = ?  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C3", "SELECT `UsuariosId`, `RolId` FROM `Usuarios` WHERE `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C4", "SELECT `RolId` FROM `Roles` WHERE `RolId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C5", "SELECT TM1.`UsuariosId`, TM1.`RolId` FROM `Usuarios` TM1 WHERE TM1.`UsuariosId` = ? ORDER BY TM1.`UsuariosId` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C6", "SELECT `RolId` FROM `Roles` WHERE `RolId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C7", "SELECT `UsuariosId` FROM `Usuarios` WHERE `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C8", "SELECT `UsuariosId` FROM `Usuarios` WHERE ( `UsuariosId` > ?) ORDER BY `UsuariosId`  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000C8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C9", "SELECT `UsuariosId` FROM `Usuarios` WHERE ( `UsuariosId` < ?) ORDER BY `UsuariosId` DESC  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000C9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C10", "INSERT INTO `Usuarios`(`UsuariosId`, `RolId`, `UsuariosNombre`, `UsuariosApPat`, `UsuariosApMat`, `UsuariosUsr`, `UsuariosIcono`, `UsuariosIcono_GXI`, `UsuariosPwd`, `UsuariosKey`, `UsuariosVigIni`, `UsuariosVigFin`, `UsuariosFecCap`, `UsuariosIP`, `UsuariosCurp`, `UsuariosFecNacimiento`, `UsuariosEdad`, `UsuariosSexo`, `UsuariosTelef`, `UsuariosCorreo`, `UsuariosTipo`, `UsuariosStatus`) VALUES(?, ?, '', '', '', '', '', '', '', '', '1000-01-01', '1000-01-01', '1000-01-01', '', '', '1000-01-01', 0, '', '', '', 0, 0)", GxErrorMask.GX_NOMASK,prmT000C10)
             ,new CursorDef("T000C11", "UPDATE `Usuarios` SET `RolId`=?  WHERE `UsuariosId` = ?", GxErrorMask.GX_NOMASK,prmT000C11)
             ,new CursorDef("T000C12", "DELETE FROM `Usuarios`  WHERE `UsuariosId` = ?", GxErrorMask.GX_NOMASK,prmT000C12)
             ,new CursorDef("T000C13", "SELECT `bitAccesFec`, `bitAccesIp` FROM `bitAcces` WHERE `UsuariosId` = ?  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000C13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C14", "SELECT `Vacantes_Id`, `UsuariosId` FROM `VacantesUsuariosVacante` WHERE `SUBT_ReclutadorId` = ?  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000C14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C15", "SELECT `Vacantes_Id`, `UsuariosId` FROM `VacantesUsuariosVacante` WHERE `UsuariosId` = ?  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000C15,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C16", "SELECT `Perfiles_Id`, `UsuariosId` FROM `PerfilesUsuariosPerfil` WHERE `UsuariosId` = ?  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000C16,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C17", "SELECT `UsuariosId`, `FechaIntento` FROM `Intentos` WHERE `UsuariosId` = ?  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000C17,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C18", "SELECT `UsuariosId`, `HisPwdFecha` FROM `HistPwd` WHERE `UsuariosId` = ?  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000C18,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C19", "SELECT `UsuariosId` FROM `Usuarios` ORDER BY `UsuariosId` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C19,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C20", "SELECT `RolId` FROM `Roles` WHERE `RolId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C20,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 11 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2) ;
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2) ;
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 18 :
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
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 1 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 2 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 3 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 4 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 5 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 6 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 7 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 8 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                stmt.SetParameter(2, (int)parms[2]);
                return;
             case 9 :
                stmt.SetParameter(1, (int)parms[0]);
                if ( (bool)parms[1] )
                {
                   stmt.setNull( 2 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(2, (int)parms[2]);
                }
                return;
             case 10 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 11 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 12 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 13 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 14 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 15 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 16 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 18 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

}
