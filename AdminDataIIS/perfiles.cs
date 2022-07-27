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
   public class perfiles : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A11UsuariosId = (int)(NumberUtil.Val( GetNextPar( ), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A11UsuariosId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridperfiles_usuariosperfil") == 0 )
         {
            nRC_GXsfl_53 = (int)(NumberUtil.Val( GetNextPar( ), "."));
            nGXsfl_53_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
            sGXsfl_53_idx = GetNextPar( );
            Gx_mode = GetNextPar( );
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridperfiles_usuariosperfil_newrow( ) ;
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
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7Perfiles_Id = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignAttri("", false, "AV7Perfiles_Id", StringUtil.LTrimStr( (decimal)(AV7Perfiles_Id), 9, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPERFILES_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7Perfiles_Id), "ZZZZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Perfiles", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPerfiles_Nombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public perfiles( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public perfiles( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( String aP0_Gx_mode ,
                           int aP1_Perfiles_Id )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7Perfiles_Id = aP1_Perfiles_Id;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbPerfiles_Estatus = new GXCombobox();
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
         if ( cmbPerfiles_Estatus.ItemCount > 0 )
         {
            A280Perfiles_Estatus = (short)(NumberUtil.Val( cmbPerfiles_Estatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A280Perfiles_Estatus), 4, 0))), "."));
            AssignAttri("", false, "A280Perfiles_Estatus", StringUtil.LTrimStr( (decimal)(A280Perfiles_Estatus), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPerfiles_Estatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A280Perfiles_Estatus), 4, 0));
            AssignProp("", false, cmbPerfiles_Estatus_Internalname, "Values", cmbPerfiles_Estatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Perfiles", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_Perfiles.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Perfiles.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Perfiles.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Perfiles.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Perfiles.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Perfiles.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPerfiles_Id_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPerfiles_Id_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPerfiles_Id_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A278Perfiles_Id), 9, 0, ",", "")), ((edtPerfiles_Id_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A278Perfiles_Id), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A278Perfiles_Id), "ZZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPerfiles_Id_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPerfiles_Id_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Perfiles.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPerfiles_Nombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPerfiles_Nombre_Internalname, "Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPerfiles_Nombre_Internalname, A279Perfiles_Nombre, StringUtil.RTrim( context.localUtil.Format( A279Perfiles_Nombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPerfiles_Nombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPerfiles_Nombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Perfiles.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbPerfiles_Estatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbPerfiles_Estatus_Internalname, "Estatús", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbPerfiles_Estatus, cmbPerfiles_Estatus_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A280Perfiles_Estatus), 4, 0)), 1, cmbPerfiles_Estatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbPerfiles_Estatus.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, "HLP_Perfiles.htm");
         cmbPerfiles_Estatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A280Perfiles_Estatus), 4, 0));
         AssignProp("", false, cmbPerfiles_Estatus_Internalname, "Values", (String)(cmbPerfiles_Estatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUsuariosperfiltable_Internalname, 1, 0, "px", 0, "px", "LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleusuariosperfil_Internalname, "Usuarios Perfil", "", "", lblTitleusuariosperfil_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_Perfiles.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridperfiles_usuariosperfil( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Perfiles.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Perfiles.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Perfiles.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridperfiles_usuariosperfil( )
      {
         /*  Grid Control  */
         Gridperfiles_usuariosperfilContainer.AddObjectProperty("GridName", "Gridperfiles_usuariosperfil");
         Gridperfiles_usuariosperfilContainer.AddObjectProperty("Header", subGridperfiles_usuariosperfil_Header);
         Gridperfiles_usuariosperfilContainer.AddObjectProperty("Class", "Grid");
         Gridperfiles_usuariosperfilContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridperfiles_usuariosperfilContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridperfiles_usuariosperfilContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridperfiles_usuariosperfil_Backcolorstyle), 1, 0, ".", "")));
         Gridperfiles_usuariosperfilContainer.AddObjectProperty("CmpContext", "");
         Gridperfiles_usuariosperfilContainer.AddObjectProperty("InMasterPage", "false");
         Gridperfiles_usuariosperfilColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridperfiles_usuariosperfilColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ".", "")));
         Gridperfiles_usuariosperfilColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosId_Enabled), 5, 0, ".", "")));
         Gridperfiles_usuariosperfilContainer.AddColumnProperties(Gridperfiles_usuariosperfilColumn);
         Gridperfiles_usuariosperfilColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridperfiles_usuariosperfilColumn.AddObjectProperty("Value", A66UsuariosNombre);
         Gridperfiles_usuariosperfilColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosNombre_Enabled), 5, 0, ".", "")));
         Gridperfiles_usuariosperfilContainer.AddColumnProperties(Gridperfiles_usuariosperfilColumn);
         Gridperfiles_usuariosperfilColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridperfiles_usuariosperfilColumn.AddObjectProperty("Value", A65UsuariosApPat);
         Gridperfiles_usuariosperfilColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosApPat_Enabled), 5, 0, ".", "")));
         Gridperfiles_usuariosperfilContainer.AddColumnProperties(Gridperfiles_usuariosperfilColumn);
         Gridperfiles_usuariosperfilColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridperfiles_usuariosperfilColumn.AddObjectProperty("Value", A64UsuariosApMat);
         Gridperfiles_usuariosperfilColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosApMat_Enabled), 5, 0, ".", "")));
         Gridperfiles_usuariosperfilContainer.AddColumnProperties(Gridperfiles_usuariosperfilColumn);
         Gridperfiles_usuariosperfilColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridperfiles_usuariosperfilColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A283PerfilesUsuariosEstatus), 1, 0, ".", "")));
         Gridperfiles_usuariosperfilColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPerfilesUsuariosEstatus_Enabled), 5, 0, ".", "")));
         Gridperfiles_usuariosperfilContainer.AddColumnProperties(Gridperfiles_usuariosperfilColumn);
         Gridperfiles_usuariosperfilContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridperfiles_usuariosperfil_Selectedindex), 4, 0, ".", "")));
         Gridperfiles_usuariosperfilContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridperfiles_usuariosperfil_Allowselection), 1, 0, ".", "")));
         Gridperfiles_usuariosperfilContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridperfiles_usuariosperfil_Selectioncolor), 9, 0, ".", "")));
         Gridperfiles_usuariosperfilContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridperfiles_usuariosperfil_Allowhovering), 1, 0, ".", "")));
         Gridperfiles_usuariosperfilContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridperfiles_usuariosperfil_Hoveringcolor), 9, 0, ".", "")));
         Gridperfiles_usuariosperfilContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridperfiles_usuariosperfil_Allowcollapsing), 1, 0, ".", "")));
         Gridperfiles_usuariosperfilContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridperfiles_usuariosperfil_Collapsed), 1, 0, ".", "")));
         nGXsfl_53_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount27 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_27 = 1;
               ScanStart0J27( ) ;
               while ( RcdFound27 != 0 )
               {
                  init_level_properties27( ) ;
                  getByPrimaryKey0J27( ) ;
                  AddRow0J27( ) ;
                  ScanNext0J27( ) ;
               }
               ScanEnd0J27( ) ;
               nBlankRcdCount27 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0J27( ) ;
            standaloneModal0J27( ) ;
            sMode27 = Gx_mode;
            while ( nGXsfl_53_idx < nRC_GXsfl_53 )
            {
               bGXsfl_53_Refreshing = true;
               ReadRow0J27( ) ;
               edtUsuariosId_Enabled = (int)(context.localUtil.CToN( cgiGet( "USUARIOSID_"+sGXsfl_53_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtUsuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtUsuariosNombre_Enabled = (int)(context.localUtil.CToN( cgiGet( "USUARIOSNOMBRE_"+sGXsfl_53_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtUsuariosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosNombre_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtUsuariosApPat_Enabled = (int)(context.localUtil.CToN( cgiGet( "USUARIOSAPPAT_"+sGXsfl_53_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtUsuariosApPat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosApPat_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtUsuariosApMat_Enabled = (int)(context.localUtil.CToN( cgiGet( "USUARIOSAPMAT_"+sGXsfl_53_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtUsuariosApMat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosApMat_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtPerfilesUsuariosEstatus_Enabled = (int)(context.localUtil.CToN( cgiGet( "PERFILESUSUARIOSESTATUS_"+sGXsfl_53_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtPerfilesUsuariosEstatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerfilesUsuariosEstatus_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               if ( ( nRcdExists_27 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0J27( ) ;
               }
               SendRow0J27( ) ;
               bGXsfl_53_Refreshing = false;
            }
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount27 = 5;
            nRcdExists_27 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0J27( ) ;
               while ( RcdFound27 != 0 )
               {
                  sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_5327( ) ;
                  init_level_properties27( ) ;
                  standaloneNotModal0J27( ) ;
                  getByPrimaryKey0J27( ) ;
                  standaloneModal0J27( ) ;
                  AddRow0J27( ) ;
                  ScanNext0J27( ) ;
               }
               ScanEnd0J27( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode27 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
            SubsflControlProps_5327( ) ;
            InitAll0J27( ) ;
            init_level_properties27( ) ;
            nRcdExists_27 = 0;
            nIsMod_27 = 0;
            nRcdDeleted_27 = 0;
            nBlankRcdCount27 = (short)(nBlankRcdUsr27+nBlankRcdCount27);
            fRowAdded = 0;
            while ( nBlankRcdCount27 > 0 )
            {
               standaloneNotModal0J27( ) ;
               standaloneModal0J27( ) ;
               AddRow0J27( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtUsuariosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount27 = (short)(nBlankRcdCount27-1);
            }
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridperfiles_usuariosperfilContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridperfiles_usuariosperfil", Gridperfiles_usuariosperfilContainer);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridperfiles_usuariosperfilContainerData", Gridperfiles_usuariosperfilContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridperfiles_usuariosperfilContainerData"+"V", Gridperfiles_usuariosperfilContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridperfiles_usuariosperfilContainerData"+"V"+"\" value='"+Gridperfiles_usuariosperfilContainer.GridValuesHidden()+"'/>") ;
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
         E110J2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z278Perfiles_Id = (int)(context.localUtil.CToN( cgiGet( "Z278Perfiles_Id"), ",", "."));
               Z279Perfiles_Nombre = cgiGet( "Z279Perfiles_Nombre");
               Z280Perfiles_Estatus = (short)(context.localUtil.CToN( cgiGet( "Z280Perfiles_Estatus"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_53 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_53"), ",", "."));
               AV7Perfiles_Id = (int)(context.localUtil.CToN( cgiGet( "vPERFILES_ID"), ",", "."));
               AV11Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A278Perfiles_Id = (int)(context.localUtil.CToN( cgiGet( edtPerfiles_Id_Internalname), ",", "."));
               AssignAttri("", false, "A278Perfiles_Id", StringUtil.LTrimStr( (decimal)(A278Perfiles_Id), 9, 0));
               A279Perfiles_Nombre = cgiGet( edtPerfiles_Nombre_Internalname);
               AssignAttri("", false, "A279Perfiles_Nombre", A279Perfiles_Nombre);
               cmbPerfiles_Estatus.Name = cmbPerfiles_Estatus_Internalname;
               cmbPerfiles_Estatus.CurrentValue = cgiGet( cmbPerfiles_Estatus_Internalname);
               A280Perfiles_Estatus = (short)(NumberUtil.Val( cgiGet( cmbPerfiles_Estatus_Internalname), "."));
               AssignAttri("", false, "A280Perfiles_Estatus", StringUtil.LTrimStr( (decimal)(A280Perfiles_Estatus), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Perfiles");
               A278Perfiles_Id = (int)(context.localUtil.CToN( cgiGet( edtPerfiles_Id_Internalname), ",", "."));
               AssignAttri("", false, "A278Perfiles_Id", StringUtil.LTrimStr( (decimal)(A278Perfiles_Id), 9, 0));
               forbiddenHiddens.Add("Perfiles_Id", context.localUtil.Format( (decimal)(A278Perfiles_Id), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A278Perfiles_Id != Z278Perfiles_Id ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("perfiles:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A278Perfiles_Id = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri("", false, "A278Perfiles_Id", StringUtil.LTrimStr( (decimal)(A278Perfiles_Id), 9, 0));
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
                     sMode24 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode24;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound24 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0J0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PERFILES_ID");
                        AnyError = 1;
                        GX_FocusControl = edtPerfiles_Id_Internalname;
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
                           E110J2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120J2 ();
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
            E120J2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0J24( ) ;
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
            DisableAttributes0J24( ) ;
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

      protected void CONFIRM_0J0( )
      {
         BeforeValidate0J24( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0J24( ) ;
            }
            else
            {
               CheckExtendedTable0J24( ) ;
               CloseExtendedTableCursors0J24( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode24 = Gx_mode;
            CONFIRM_0J27( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode24;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode24;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0J27( )
      {
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow0J27( ) ;
            if ( ( nRcdExists_27 != 0 ) || ( nIsMod_27 != 0 ) )
            {
               GetKey0J27( ) ;
               if ( ( nRcdExists_27 == 0 ) && ( nRcdDeleted_27 == 0 ) )
               {
                  if ( RcdFound27 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0J27( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0J27( ) ;
                        CloseExtendedTableCursors0J27( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "USUARIOSID_" + sGXsfl_53_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtUsuariosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound27 != 0 )
                  {
                     if ( nRcdDeleted_27 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0J27( ) ;
                        Load0J27( ) ;
                        BeforeValidate0J27( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0J27( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_27 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0J27( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0J27( ) ;
                              CloseExtendedTableCursors0J27( ) ;
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
                     if ( nRcdDeleted_27 == 0 )
                     {
                        GXCCtl = "USUARIOSID_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtUsuariosId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtUsuariosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", ""))) ;
            ChangePostValue( edtUsuariosNombre_Internalname, A66UsuariosNombre) ;
            ChangePostValue( edtUsuariosApPat_Internalname, A65UsuariosApPat) ;
            ChangePostValue( edtUsuariosApMat_Internalname, A64UsuariosApMat) ;
            ChangePostValue( edtPerfilesUsuariosEstatus_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A283PerfilesUsuariosEstatus), 1, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z11UsuariosId_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11UsuariosId), 6, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z283PerfilesUsuariosEstatus_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z283PerfilesUsuariosEstatus), 1, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_27_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_27), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_27_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_27), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_27_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_27), 4, 0, ",", ""))) ;
            if ( nIsMod_27 != 0 )
            {
               ChangePostValue( "USUARIOSID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSNOMBRE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSAPPAT_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosApPat_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSAPMAT_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosApMat_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PERFILESUSUARIOSESTATUS_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPerfilesUsuariosEstatus_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0J0( )
      {
      }

      protected void E110J2( )
      {
         /* Start Routine */
         if ( ! new isauthorized(context).executeUdp(  AV11Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV11Pgmname)));
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "TransactionContext", "ADMINDATA1");
      }

      protected void E120J2( )
      {
         /* After Trn Routine */
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwperfiles.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0J24( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z279Perfiles_Nombre = T000J6_A279Perfiles_Nombre[0];
               Z280Perfiles_Estatus = T000J6_A280Perfiles_Estatus[0];
            }
            else
            {
               Z279Perfiles_Nombre = A279Perfiles_Nombre;
               Z280Perfiles_Estatus = A280Perfiles_Estatus;
            }
         }
         if ( GX_JID == -3 )
         {
            Z278Perfiles_Id = A278Perfiles_Id;
            Z279Perfiles_Nombre = A279Perfiles_Nombre;
            Z280Perfiles_Estatus = A280Perfiles_Estatus;
         }
      }

      protected void standaloneNotModal( )
      {
         edtPerfiles_Id_Enabled = 0;
         AssignProp("", false, edtPerfiles_Id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerfiles_Id_Enabled), 5, 0), true);
         edtPerfiles_Id_Enabled = 0;
         AssignProp("", false, edtPerfiles_Id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerfiles_Id_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7Perfiles_Id) )
         {
            A278Perfiles_Id = AV7Perfiles_Id;
            AssignAttri("", false, "A278Perfiles_Id", StringUtil.LTrimStr( (decimal)(A278Perfiles_Id), 9, 0));
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

      protected void Load0J24( )
      {
         /* Using cursor T000J7 */
         pr_default.execute(5, new Object[] {A278Perfiles_Id});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound24 = 1;
            A279Perfiles_Nombre = T000J7_A279Perfiles_Nombre[0];
            AssignAttri("", false, "A279Perfiles_Nombre", A279Perfiles_Nombre);
            A280Perfiles_Estatus = T000J7_A280Perfiles_Estatus[0];
            AssignAttri("", false, "A280Perfiles_Estatus", StringUtil.LTrimStr( (decimal)(A280Perfiles_Estatus), 4, 0));
            ZM0J24( -3) ;
         }
         pr_default.close(5);
         OnLoadActions0J24( ) ;
      }

      protected void OnLoadActions0J24( )
      {
         AV11Pgmname = "Perfiles";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CheckExtendedTable0J24( )
      {
         nIsDirty_24 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV11Pgmname = "Perfiles";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CloseExtendedTableCursors0J24( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0J24( )
      {
         /* Using cursor T000J8 */
         pr_default.execute(6, new Object[] {A278Perfiles_Id});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound24 = 1;
         }
         else
         {
            RcdFound24 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000J6 */
         pr_default.execute(4, new Object[] {A278Perfiles_Id});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0J24( 3) ;
            RcdFound24 = 1;
            A278Perfiles_Id = T000J6_A278Perfiles_Id[0];
            AssignAttri("", false, "A278Perfiles_Id", StringUtil.LTrimStr( (decimal)(A278Perfiles_Id), 9, 0));
            A279Perfiles_Nombre = T000J6_A279Perfiles_Nombre[0];
            AssignAttri("", false, "A279Perfiles_Nombre", A279Perfiles_Nombre);
            A280Perfiles_Estatus = T000J6_A280Perfiles_Estatus[0];
            AssignAttri("", false, "A280Perfiles_Estatus", StringUtil.LTrimStr( (decimal)(A280Perfiles_Estatus), 4, 0));
            Z278Perfiles_Id = A278Perfiles_Id;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0J24( ) ;
            if ( AnyError == 1 )
            {
               RcdFound24 = 0;
               InitializeNonKey0J24( ) ;
            }
            Gx_mode = sMode24;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound24 = 0;
            InitializeNonKey0J24( ) ;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode24;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey0J24( ) ;
         if ( RcdFound24 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound24 = 0;
         /* Using cursor T000J9 */
         pr_default.execute(7, new Object[] {A278Perfiles_Id});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000J9_A278Perfiles_Id[0] < A278Perfiles_Id ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000J9_A278Perfiles_Id[0] > A278Perfiles_Id ) ) )
            {
               A278Perfiles_Id = T000J9_A278Perfiles_Id[0];
               AssignAttri("", false, "A278Perfiles_Id", StringUtil.LTrimStr( (decimal)(A278Perfiles_Id), 9, 0));
               RcdFound24 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound24 = 0;
         /* Using cursor T000J10 */
         pr_default.execute(8, new Object[] {A278Perfiles_Id});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000J10_A278Perfiles_Id[0] > A278Perfiles_Id ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000J10_A278Perfiles_Id[0] < A278Perfiles_Id ) ) )
            {
               A278Perfiles_Id = T000J10_A278Perfiles_Id[0];
               AssignAttri("", false, "A278Perfiles_Id", StringUtil.LTrimStr( (decimal)(A278Perfiles_Id), 9, 0));
               RcdFound24 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0J24( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPerfiles_Nombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0J24( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound24 == 1 )
            {
               if ( A278Perfiles_Id != Z278Perfiles_Id )
               {
                  A278Perfiles_Id = Z278Perfiles_Id;
                  AssignAttri("", false, "A278Perfiles_Id", StringUtil.LTrimStr( (decimal)(A278Perfiles_Id), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PERFILES_ID");
                  AnyError = 1;
                  GX_FocusControl = edtPerfiles_Id_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPerfiles_Nombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0J24( ) ;
                  GX_FocusControl = edtPerfiles_Nombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A278Perfiles_Id != Z278Perfiles_Id )
               {
                  /* Insert record */
                  GX_FocusControl = edtPerfiles_Nombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0J24( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PERFILES_ID");
                     AnyError = 1;
                     GX_FocusControl = edtPerfiles_Id_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPerfiles_Nombre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0J24( ) ;
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
         if ( A278Perfiles_Id != Z278Perfiles_Id )
         {
            A278Perfiles_Id = Z278Perfiles_Id;
            AssignAttri("", false, "A278Perfiles_Id", StringUtil.LTrimStr( (decimal)(A278Perfiles_Id), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PERFILES_ID");
            AnyError = 1;
            GX_FocusControl = edtPerfiles_Id_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPerfiles_Nombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0J24( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000J5 */
            pr_default.execute(3, new Object[] {A278Perfiles_Id});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Perfiles"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z279Perfiles_Nombre, T000J5_A279Perfiles_Nombre[0]) != 0 ) || ( Z280Perfiles_Estatus != T000J5_A280Perfiles_Estatus[0] ) )
            {
               if ( StringUtil.StrCmp(Z279Perfiles_Nombre, T000J5_A279Perfiles_Nombre[0]) != 0 )
               {
                  GXUtil.WriteLog("perfiles:[seudo value changed for attri]"+"Perfiles_Nombre");
                  GXUtil.WriteLogRaw("Old: ",Z279Perfiles_Nombre);
                  GXUtil.WriteLogRaw("Current: ",T000J5_A279Perfiles_Nombre[0]);
               }
               if ( Z280Perfiles_Estatus != T000J5_A280Perfiles_Estatus[0] )
               {
                  GXUtil.WriteLog("perfiles:[seudo value changed for attri]"+"Perfiles_Estatus");
                  GXUtil.WriteLogRaw("Old: ",Z280Perfiles_Estatus);
                  GXUtil.WriteLogRaw("Current: ",T000J5_A280Perfiles_Estatus[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Perfiles"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0J24( )
      {
         BeforeValidate0J24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J24( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0J24( 0) ;
            CheckOptimisticConcurrency0J24( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J24( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0J24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J11 */
                     pr_default.execute(9, new Object[] {A279Perfiles_Nombre, A280Perfiles_Estatus});
                     pr_default.close(9);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000J12 */
                     pr_default.execute(10);
                     A278Perfiles_Id = T000J12_A278Perfiles_Id[0];
                     AssignAttri("", false, "A278Perfiles_Id", StringUtil.LTrimStr( (decimal)(A278Perfiles_Id), 9, 0));
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("Perfiles") ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0J24( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0J0( ) ;
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
               Load0J24( ) ;
            }
            EndLevel0J24( ) ;
         }
         CloseExtendedTableCursors0J24( ) ;
      }

      protected void Update0J24( )
      {
         BeforeValidate0J24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J24( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J24( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J24( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0J24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J13 */
                     pr_default.execute(11, new Object[] {A279Perfiles_Nombre, A280Perfiles_Estatus, A278Perfiles_Id});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("Perfiles") ;
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Perfiles"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0J24( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0J24( ) ;
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
            EndLevel0J24( ) ;
         }
         CloseExtendedTableCursors0J24( ) ;
      }

      protected void DeferredUpdate0J24( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0J24( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J24( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0J24( ) ;
            AfterConfirm0J24( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0J24( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0J27( ) ;
                  while ( RcdFound27 != 0 )
                  {
                     getByPrimaryKey0J27( ) ;
                     Delete0J27( ) ;
                     ScanNext0J27( ) ;
                  }
                  ScanEnd0J27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J14 */
                     pr_default.execute(12, new Object[] {A278Perfiles_Id});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("Perfiles") ;
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
         sMode24 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0J24( ) ;
         Gx_mode = sMode24;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0J24( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV11Pgmname = "Perfiles";
            AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         }
      }

      protected void ProcessNestedLevel0J27( )
      {
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow0J27( ) ;
            if ( ( nRcdExists_27 != 0 ) || ( nIsMod_27 != 0 ) )
            {
               standaloneNotModal0J27( ) ;
               GetKey0J27( ) ;
               if ( ( nRcdExists_27 == 0 ) && ( nRcdDeleted_27 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0J27( ) ;
               }
               else
               {
                  if ( RcdFound27 != 0 )
                  {
                     if ( ( nRcdDeleted_27 != 0 ) && ( nRcdExists_27 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0J27( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_27 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0J27( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_27 == 0 )
                     {
                        GXCCtl = "USUARIOSID_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtUsuariosId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtUsuariosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", ""))) ;
            ChangePostValue( edtUsuariosNombre_Internalname, A66UsuariosNombre) ;
            ChangePostValue( edtUsuariosApPat_Internalname, A65UsuariosApPat) ;
            ChangePostValue( edtUsuariosApMat_Internalname, A64UsuariosApMat) ;
            ChangePostValue( edtPerfilesUsuariosEstatus_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A283PerfilesUsuariosEstatus), 1, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z11UsuariosId_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11UsuariosId), 6, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z283PerfilesUsuariosEstatus_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z283PerfilesUsuariosEstatus), 1, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_27_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_27), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_27_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_27), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_27_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_27), 4, 0, ",", ""))) ;
            if ( nIsMod_27 != 0 )
            {
               ChangePostValue( "USUARIOSID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSNOMBRE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSAPPAT_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosApPat_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSAPMAT_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosApMat_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PERFILESUSUARIOSESTATUS_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPerfilesUsuariosEstatus_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0J27( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_27 = 0;
         nIsMod_27 = 0;
         nRcdDeleted_27 = 0;
      }

      protected void ProcessLevel0J24( )
      {
         /* Save parent mode. */
         sMode24 = Gx_mode;
         ProcessNestedLevel0J27( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode24;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0J24( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0J24( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("perfiles",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0J0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("perfiles",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0J24( )
      {
         /* Scan By routine */
         /* Using cursor T000J15 */
         pr_default.execute(13);
         RcdFound24 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound24 = 1;
            A278Perfiles_Id = T000J15_A278Perfiles_Id[0];
            AssignAttri("", false, "A278Perfiles_Id", StringUtil.LTrimStr( (decimal)(A278Perfiles_Id), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0J24( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound24 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound24 = 1;
            A278Perfiles_Id = T000J15_A278Perfiles_Id[0];
            AssignAttri("", false, "A278Perfiles_Id", StringUtil.LTrimStr( (decimal)(A278Perfiles_Id), 9, 0));
         }
      }

      protected void ScanEnd0J24( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0J24( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0J24( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0J24( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0J24( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0J24( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0J24( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0J24( )
      {
         edtPerfiles_Id_Enabled = 0;
         AssignProp("", false, edtPerfiles_Id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerfiles_Id_Enabled), 5, 0), true);
         edtPerfiles_Nombre_Enabled = 0;
         AssignProp("", false, edtPerfiles_Nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerfiles_Nombre_Enabled), 5, 0), true);
         cmbPerfiles_Estatus.Enabled = 0;
         AssignProp("", false, cmbPerfiles_Estatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPerfiles_Estatus.Enabled), 5, 0), true);
      }

      protected void ZM0J27( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z283PerfilesUsuariosEstatus = T000J3_A283PerfilesUsuariosEstatus[0];
            }
            else
            {
               Z283PerfilesUsuariosEstatus = A283PerfilesUsuariosEstatus;
            }
         }
         if ( GX_JID == -4 )
         {
            Z278Perfiles_Id = A278Perfiles_Id;
            Z283PerfilesUsuariosEstatus = A283PerfilesUsuariosEstatus;
            Z11UsuariosId = A11UsuariosId;
            Z66UsuariosNombre = A66UsuariosNombre;
            Z65UsuariosApPat = A65UsuariosApPat;
            Z64UsuariosApMat = A64UsuariosApMat;
         }
      }

      protected void standaloneNotModal0J27( )
      {
      }

      protected void standaloneModal0J27( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtUsuariosId_Enabled = 0;
            AssignProp("", false, edtUsuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
         else
         {
            edtUsuariosId_Enabled = 1;
            AssignProp("", false, edtUsuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
      }

      protected void Load0J27( )
      {
         /* Using cursor T000J16 */
         pr_default.execute(14, new Object[] {A278Perfiles_Id, A11UsuariosId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound27 = 1;
            A66UsuariosNombre = T000J16_A66UsuariosNombre[0];
            A65UsuariosApPat = T000J16_A65UsuariosApPat[0];
            A64UsuariosApMat = T000J16_A64UsuariosApMat[0];
            A283PerfilesUsuariosEstatus = T000J16_A283PerfilesUsuariosEstatus[0];
            ZM0J27( -4) ;
         }
         pr_default.close(14);
         OnLoadActions0J27( ) ;
      }

      protected void OnLoadActions0J27( )
      {
      }

      protected void CheckExtendedTable0J27( )
      {
         nIsDirty_27 = 0;
         Gx_BScreen = 1;
         standaloneModal0J27( ) ;
         /* Using cursor T000J4 */
         pr_default.execute(2, new Object[] {A11UsuariosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "USUARIOSID_" + sGXsfl_53_idx;
            GX_msglist.addItem("No existe 'Tabla de usuarios'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtUsuariosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A66UsuariosNombre = T000J4_A66UsuariosNombre[0];
         A65UsuariosApPat = T000J4_A65UsuariosApPat[0];
         A64UsuariosApMat = T000J4_A64UsuariosApMat[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0J27( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0J27( )
      {
      }

      protected void gxLoad_5( int A11UsuariosId )
      {
         /* Using cursor T000J17 */
         pr_default.execute(15, new Object[] {A11UsuariosId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GXCCtl = "USUARIOSID_" + sGXsfl_53_idx;
            GX_msglist.addItem("No existe 'Tabla de usuarios'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtUsuariosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A66UsuariosNombre = T000J17_A66UsuariosNombre[0];
         A65UsuariosApPat = T000J17_A65UsuariosApPat[0];
         A64UsuariosApMat = T000J17_A64UsuariosApMat[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A66UsuariosNombre)+"\""+","+"\""+GXUtil.EncodeJSConstant( A65UsuariosApPat)+"\""+","+"\""+GXUtil.EncodeJSConstant( A64UsuariosApMat)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void GetKey0J27( )
      {
         /* Using cursor T000J18 */
         pr_default.execute(16, new Object[] {A278Perfiles_Id, A11UsuariosId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound27 = 1;
         }
         else
         {
            RcdFound27 = 0;
         }
         pr_default.close(16);
      }

      protected void getByPrimaryKey0J27( )
      {
         /* Using cursor T000J3 */
         pr_default.execute(1, new Object[] {A278Perfiles_Id, A11UsuariosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0J27( 4) ;
            RcdFound27 = 1;
            InitializeNonKey0J27( ) ;
            A283PerfilesUsuariosEstatus = T000J3_A283PerfilesUsuariosEstatus[0];
            A11UsuariosId = T000J3_A11UsuariosId[0];
            Z278Perfiles_Id = A278Perfiles_Id;
            Z11UsuariosId = A11UsuariosId;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0J27( ) ;
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound27 = 0;
            InitializeNonKey0J27( ) ;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0J27( ) ;
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0J27( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0J27( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000J2 */
            pr_default.execute(0, new Object[] {A278Perfiles_Id, A11UsuariosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PerfilesUsuariosPerfil"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z283PerfilesUsuariosEstatus != T000J2_A283PerfilesUsuariosEstatus[0] ) )
            {
               if ( Z283PerfilesUsuariosEstatus != T000J2_A283PerfilesUsuariosEstatus[0] )
               {
                  GXUtil.WriteLog("perfiles:[seudo value changed for attri]"+"PerfilesUsuariosEstatus");
                  GXUtil.WriteLogRaw("Old: ",Z283PerfilesUsuariosEstatus);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A283PerfilesUsuariosEstatus[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PerfilesUsuariosPerfil"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0J27( )
      {
         BeforeValidate0J27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J27( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0J27( 0) ;
            CheckOptimisticConcurrency0J27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0J27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J19 */
                     pr_default.execute(17, new Object[] {A278Perfiles_Id, A283PerfilesUsuariosEstatus, A11UsuariosId});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("PerfilesUsuariosPerfil") ;
                     if ( (pr_default.getStatus(17) == 1) )
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
               Load0J27( ) ;
            }
            EndLevel0J27( ) ;
         }
         CloseExtendedTableCursors0J27( ) ;
      }

      protected void Update0J27( )
      {
         BeforeValidate0J27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J27( ) ;
         }
         if ( ( nIsMod_27 != 0 ) || ( nIsDirty_27 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0J27( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0J27( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0J27( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000J20 */
                        pr_default.execute(18, new Object[] {A283PerfilesUsuariosEstatus, A278Perfiles_Id, A11UsuariosId});
                        pr_default.close(18);
                        dsDefault.SmartCacheProvider.SetUpdated("PerfilesUsuariosPerfil") ;
                        if ( (pr_default.getStatus(18) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PerfilesUsuariosPerfil"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0J27( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0J27( ) ;
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
               EndLevel0J27( ) ;
            }
         }
         CloseExtendedTableCursors0J27( ) ;
      }

      protected void DeferredUpdate0J27( )
      {
      }

      protected void Delete0J27( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0J27( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J27( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0J27( ) ;
            AfterConfirm0J27( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0J27( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000J21 */
                  pr_default.execute(19, new Object[] {A278Perfiles_Id, A11UsuariosId});
                  pr_default.close(19);
                  dsDefault.SmartCacheProvider.SetUpdated("PerfilesUsuariosPerfil") ;
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
         sMode27 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0J27( ) ;
         Gx_mode = sMode27;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0J27( )
      {
         standaloneModal0J27( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000J22 */
            pr_default.execute(20, new Object[] {A11UsuariosId});
            A66UsuariosNombre = T000J22_A66UsuariosNombre[0];
            A65UsuariosApPat = T000J22_A65UsuariosApPat[0];
            A64UsuariosApMat = T000J22_A64UsuariosApMat[0];
            pr_default.close(20);
         }
      }

      protected void EndLevel0J27( )
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

      public void ScanStart0J27( )
      {
         /* Scan By routine */
         /* Using cursor T000J23 */
         pr_default.execute(21, new Object[] {A278Perfiles_Id});
         RcdFound27 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound27 = 1;
            A11UsuariosId = T000J23_A11UsuariosId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0J27( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound27 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound27 = 1;
            A11UsuariosId = T000J23_A11UsuariosId[0];
         }
      }

      protected void ScanEnd0J27( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm0J27( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0J27( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0J27( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0J27( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0J27( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0J27( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0J27( )
      {
         edtUsuariosId_Enabled = 0;
         AssignProp("", false, edtUsuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtUsuariosNombre_Enabled = 0;
         AssignProp("", false, edtUsuariosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosNombre_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtUsuariosApPat_Enabled = 0;
         AssignProp("", false, edtUsuariosApPat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosApPat_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtUsuariosApMat_Enabled = 0;
         AssignProp("", false, edtUsuariosApMat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosApMat_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtPerfilesUsuariosEstatus_Enabled = 0;
         AssignProp("", false, edtPerfilesUsuariosEstatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerfilesUsuariosEstatus_Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void send_integrity_lvl_hashes0J27( )
      {
      }

      protected void send_integrity_lvl_hashes0J24( )
      {
      }

      protected void SubsflControlProps_5327( )
      {
         edtUsuariosId_Internalname = "USUARIOSID_"+sGXsfl_53_idx;
         edtUsuariosNombre_Internalname = "USUARIOSNOMBRE_"+sGXsfl_53_idx;
         edtUsuariosApPat_Internalname = "USUARIOSAPPAT_"+sGXsfl_53_idx;
         edtUsuariosApMat_Internalname = "USUARIOSAPMAT_"+sGXsfl_53_idx;
         edtPerfilesUsuariosEstatus_Internalname = "PERFILESUSUARIOSESTATUS_"+sGXsfl_53_idx;
      }

      protected void SubsflControlProps_fel_5327( )
      {
         edtUsuariosId_Internalname = "USUARIOSID_"+sGXsfl_53_fel_idx;
         edtUsuariosNombre_Internalname = "USUARIOSNOMBRE_"+sGXsfl_53_fel_idx;
         edtUsuariosApPat_Internalname = "USUARIOSAPPAT_"+sGXsfl_53_fel_idx;
         edtUsuariosApMat_Internalname = "USUARIOSAPMAT_"+sGXsfl_53_fel_idx;
         edtPerfilesUsuariosEstatus_Internalname = "PERFILESUSUARIOSESTATUS_"+sGXsfl_53_fel_idx;
      }

      protected void AddRow0J27( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_5327( ) ;
         SendRow0J27( ) ;
      }

      protected void SendRow0J27( )
      {
         Gridperfiles_usuariosperfilRow = GXWebRow.GetNew(context);
         if ( subGridperfiles_usuariosperfil_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridperfiles_usuariosperfil_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridperfiles_usuariosperfil_Class, "") != 0 )
            {
               subGridperfiles_usuariosperfil_Linesclass = subGridperfiles_usuariosperfil_Class+"Odd";
            }
         }
         else if ( subGridperfiles_usuariosperfil_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridperfiles_usuariosperfil_Backstyle = 0;
            subGridperfiles_usuariosperfil_Backcolor = subGridperfiles_usuariosperfil_Allbackcolor;
            if ( StringUtil.StrCmp(subGridperfiles_usuariosperfil_Class, "") != 0 )
            {
               subGridperfiles_usuariosperfil_Linesclass = subGridperfiles_usuariosperfil_Class+"Uniform";
            }
         }
         else if ( subGridperfiles_usuariosperfil_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridperfiles_usuariosperfil_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridperfiles_usuariosperfil_Class, "") != 0 )
            {
               subGridperfiles_usuariosperfil_Linesclass = subGridperfiles_usuariosperfil_Class+"Odd";
            }
            subGridperfiles_usuariosperfil_Backcolor = (int)(0x0);
         }
         else if ( subGridperfiles_usuariosperfil_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridperfiles_usuariosperfil_Backstyle = 1;
            if ( ((int)((nGXsfl_53_idx) % (2))) == 0 )
            {
               subGridperfiles_usuariosperfil_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridperfiles_usuariosperfil_Class, "") != 0 )
               {
                  subGridperfiles_usuariosperfil_Linesclass = subGridperfiles_usuariosperfil_Class+"Even";
               }
            }
            else
            {
               subGridperfiles_usuariosperfil_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridperfiles_usuariosperfil_Class, "") != 0 )
               {
                  subGridperfiles_usuariosperfil_Linesclass = subGridperfiles_usuariosperfil_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_27_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridperfiles_usuariosperfilRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosId_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(int)edtUsuariosId_Enabled,(short)1,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)6,(short)0,(short)0,(short)53,(short)1,(short)-1,(short)0,(bool)true,(String)"NumId",(String)"right",(bool)false,(String)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridperfiles_usuariosperfilRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosNombre_Internalname,(String)A66UsuariosNombre,StringUtil.RTrim( context.localUtil.Format( A66UsuariosNombre, "@!")),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosNombre_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(int)edtUsuariosNombre_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)40,(short)0,(short)0,(short)53,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridperfiles_usuariosperfilRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosApPat_Internalname,(String)A65UsuariosApPat,StringUtil.RTrim( context.localUtil.Format( A65UsuariosApPat, "@!")),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosApPat_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(int)edtUsuariosApPat_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)40,(short)0,(short)0,(short)53,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridperfiles_usuariosperfilRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosApMat_Internalname,(String)A64UsuariosApMat,StringUtil.RTrim( context.localUtil.Format( A64UsuariosApMat, "@!")),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosApMat_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(int)edtUsuariosApMat_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)40,(short)0,(short)0,(short)53,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_27_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridperfiles_usuariosperfilRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPerfilesUsuariosEstatus_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A283PerfilesUsuariosEstatus), 1, 0, ",", "")),((edtPerfilesUsuariosEstatus_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A283PerfilesUsuariosEstatus), "9")) : context.localUtil.Format( (decimal)(A283PerfilesUsuariosEstatus), "9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,58);\"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtPerfilesUsuariosEstatus_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(int)edtPerfilesUsuariosEstatus_Enabled,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)1,(short)0,(short)0,(short)53,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridperfiles_usuariosperfilRow);
         send_integrity_lvl_hashes0J27( ) ;
         GXCCtl = "Z11UsuariosId_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11UsuariosId), 6, 0, ",", "")));
         GXCCtl = "Z283PerfilesUsuariosEstatus_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z283PerfilesUsuariosEstatus), 1, 0, ",", "")));
         GXCCtl = "nRcdDeleted_27_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_27), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_27_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_27), 4, 0, ",", "")));
         GXCCtl = "nIsMod_27_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_27), 4, 0, ",", "")));
         GXCCtl = "vMODE_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_53_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vPERFILES_ID_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Perfiles_Id), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSNOMBRE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSAPPAT_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosApPat_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSAPMAT_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosApMat_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PERFILESUSUARIOSESTATUS_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPerfilesUsuariosEstatus_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridperfiles_usuariosperfilContainer.AddRow(Gridperfiles_usuariosperfilRow);
      }

      protected void ReadRow0J27( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_5327( ) ;
         edtUsuariosId_Enabled = (int)(context.localUtil.CToN( cgiGet( "USUARIOSID_"+sGXsfl_53_idx+"Enabled"), ",", "."));
         edtUsuariosNombre_Enabled = (int)(context.localUtil.CToN( cgiGet( "USUARIOSNOMBRE_"+sGXsfl_53_idx+"Enabled"), ",", "."));
         edtUsuariosApPat_Enabled = (int)(context.localUtil.CToN( cgiGet( "USUARIOSAPPAT_"+sGXsfl_53_idx+"Enabled"), ",", "."));
         edtUsuariosApMat_Enabled = (int)(context.localUtil.CToN( cgiGet( "USUARIOSAPMAT_"+sGXsfl_53_idx+"Enabled"), ",", "."));
         edtPerfilesUsuariosEstatus_Enabled = (int)(context.localUtil.CToN( cgiGet( "PERFILESUSUARIOSESTATUS_"+sGXsfl_53_idx+"Enabled"), ",", "."));
         if ( ( ( context.localUtil.CToN( cgiGet( edtUsuariosId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuariosId_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "USUARIOSID_" + sGXsfl_53_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtUsuariosId_Internalname;
            wbErr = true;
            A11UsuariosId = 0;
         }
         else
         {
            A11UsuariosId = (int)(context.localUtil.CToN( cgiGet( edtUsuariosId_Internalname), ",", "."));
         }
         A66UsuariosNombre = StringUtil.Upper( cgiGet( edtUsuariosNombre_Internalname));
         A65UsuariosApPat = StringUtil.Upper( cgiGet( edtUsuariosApPat_Internalname));
         A64UsuariosApMat = StringUtil.Upper( cgiGet( edtUsuariosApMat_Internalname));
         if ( ( ( context.localUtil.CToN( cgiGet( edtPerfilesUsuariosEstatus_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPerfilesUsuariosEstatus_Internalname), ",", ".") > Convert.ToDecimal( 9 )) ) )
         {
            GXCCtl = "PERFILESUSUARIOSESTATUS_" + sGXsfl_53_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPerfilesUsuariosEstatus_Internalname;
            wbErr = true;
            A283PerfilesUsuariosEstatus = 0;
         }
         else
         {
            A283PerfilesUsuariosEstatus = (short)(context.localUtil.CToN( cgiGet( edtPerfilesUsuariosEstatus_Internalname), ",", "."));
         }
         GXCCtl = "Z11UsuariosId_" + sGXsfl_53_idx;
         Z11UsuariosId = (int)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "Z283PerfilesUsuariosEstatus_" + sGXsfl_53_idx;
         Z283PerfilesUsuariosEstatus = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nRcdDeleted_27_" + sGXsfl_53_idx;
         nRcdDeleted_27 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nRcdExists_27_" + sGXsfl_53_idx;
         nRcdExists_27 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nIsMod_27_" + sGXsfl_53_idx;
         nIsMod_27 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
      }

      protected void assign_properties_default( )
      {
         defedtUsuariosId_Enabled = edtUsuariosId_Enabled;
      }

      protected void ConfirmValues0J0( )
      {
         nGXsfl_53_idx = 0;
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_5327( ) ;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_5327( ) ;
            ChangePostValue( "Z11UsuariosId_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z11UsuariosId_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z11UsuariosId_"+sGXsfl_53_idx) ;
            ChangePostValue( "Z283PerfilesUsuariosEstatus_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z283PerfilesUsuariosEstatus_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z283PerfilesUsuariosEstatus_"+sGXsfl_53_idx) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714344416", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("perfiles.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode("" +AV7Perfiles_Id)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Perfiles");
         forbiddenHiddens.Add("Perfiles_Id", context.localUtil.Format( (decimal)(A278Perfiles_Id), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("perfiles:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z278Perfiles_Id", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z278Perfiles_Id), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z279Perfiles_Nombre", Z279Perfiles_Nombre);
         GxWebStd.gx_hidden_field( context, "Z280Perfiles_Estatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z280Perfiles_Estatus), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_53", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_53_idx), 8, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vPERFILES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Perfiles_Id), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPERFILES_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7Perfiles_Id), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV11Pgmname));
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
         return formatLink("perfiles.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode("" +AV7Perfiles_Id) ;
      }

      public override String GetPgmname( )
      {
         return "Perfiles" ;
      }

      public override String GetPgmdesc( )
      {
         return "Perfiles" ;
      }

      protected void InitializeNonKey0J24( )
      {
         A279Perfiles_Nombre = "";
         AssignAttri("", false, "A279Perfiles_Nombre", A279Perfiles_Nombre);
         A280Perfiles_Estatus = 0;
         AssignAttri("", false, "A280Perfiles_Estatus", StringUtil.LTrimStr( (decimal)(A280Perfiles_Estatus), 4, 0));
         Z279Perfiles_Nombre = "";
         Z280Perfiles_Estatus = 0;
      }

      protected void InitAll0J24( )
      {
         A278Perfiles_Id = 0;
         AssignAttri("", false, "A278Perfiles_Id", StringUtil.LTrimStr( (decimal)(A278Perfiles_Id), 9, 0));
         InitializeNonKey0J24( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0J27( )
      {
         A66UsuariosNombre = "";
         A65UsuariosApPat = "";
         A64UsuariosApMat = "";
         A283PerfilesUsuariosEstatus = 0;
         Z283PerfilesUsuariosEstatus = 0;
      }

      protected void InitAll0J27( )
      {
         A11UsuariosId = 0;
         InitializeNonKey0J27( ) ;
      }

      protected void StandaloneModalInsert0J27( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714344421", true, true);
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
         context.AddJavascriptSource("perfiles.js", "?202262714344421", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties27( )
      {
         edtUsuariosId_Enabled = defedtUsuariosId_Enabled;
         AssignProp("", false, edtUsuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
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
         edtPerfiles_Id_Internalname = "PERFILES_ID";
         edtPerfiles_Nombre_Internalname = "PERFILES_NOMBRE";
         cmbPerfiles_Estatus_Internalname = "PERFILES_ESTATUS";
         lblTitleusuariosperfil_Internalname = "TITLEUSUARIOSPERFIL";
         edtUsuariosId_Internalname = "USUARIOSID";
         edtUsuariosNombre_Internalname = "USUARIOSNOMBRE";
         edtUsuariosApPat_Internalname = "USUARIOSAPPAT";
         edtUsuariosApMat_Internalname = "USUARIOSAPMAT";
         edtPerfilesUsuariosEstatus_Internalname = "PERFILESUSUARIOSESTATUS";
         divUsuariosperfiltable_Internalname = "USUARIOSPERFILTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridperfiles_usuariosperfil_Internalname = "GRIDPERFILES_USUARIOSPERFIL";
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
         Form.Caption = "Perfiles";
         edtPerfilesUsuariosEstatus_Jsonclick = "";
         edtUsuariosApMat_Jsonclick = "";
         edtUsuariosApPat_Jsonclick = "";
         edtUsuariosNombre_Jsonclick = "";
         edtUsuariosId_Jsonclick = "";
         subGridperfiles_usuariosperfil_Class = "Grid";
         subGridperfiles_usuariosperfil_Backcolorstyle = 0;
         subGridperfiles_usuariosperfil_Allowcollapsing = 0;
         subGridperfiles_usuariosperfil_Allowselection = 0;
         edtPerfilesUsuariosEstatus_Enabled = 1;
         edtUsuariosApMat_Enabled = 0;
         edtUsuariosApPat_Enabled = 0;
         edtUsuariosNombre_Enabled = 0;
         edtUsuariosId_Enabled = 1;
         subGridperfiles_usuariosperfil_Header = "";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbPerfiles_Estatus_Jsonclick = "";
         cmbPerfiles_Estatus.Enabled = 1;
         edtPerfiles_Nombre_Jsonclick = "";
         edtPerfiles_Nombre_Enabled = 1;
         edtPerfiles_Id_Jsonclick = "";
         edtPerfiles_Id_Enabled = 0;
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

      protected void gxnrGridperfiles_usuariosperfil_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_5327( ) ;
         while ( nGXsfl_53_idx <= nRC_GXsfl_53 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0J27( ) ;
            standaloneModal0J27( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0J27( ) ;
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_5327( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridperfiles_usuariosperfilContainer)) ;
         /* End function gxnrGridperfiles_usuariosperfil_newrow */
      }

      protected void init_web_controls( )
      {
         cmbPerfiles_Estatus.Name = "PERFILES_ESTATUS";
         cmbPerfiles_Estatus.WebTags = "";
         cmbPerfiles_Estatus.addItem("1", "Activo", 0);
         cmbPerfiles_Estatus.addItem("2", "Inactivo", 0);
         cmbPerfiles_Estatus.addItem("3", "Espera", 0);
         if ( cmbPerfiles_Estatus.ItemCount > 0 )
         {
            A280Perfiles_Estatus = (short)(NumberUtil.Val( cmbPerfiles_Estatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A280Perfiles_Estatus), 4, 0))), "."));
            AssignAttri("", false, "A280Perfiles_Estatus", StringUtil.LTrimStr( (decimal)(A280Perfiles_Estatus), 4, 0));
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

      public void Valid_Usuariosid( )
      {
         /* Using cursor T000J22 */
         pr_default.execute(20, new Object[] {A11UsuariosId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Tabla de usuarios'.", "ForeignKeyNotFound", 1, "USUARIOSID");
            AnyError = 1;
            GX_FocusControl = edtUsuariosId_Internalname;
         }
         A66UsuariosNombre = T000J22_A66UsuariosNombre[0];
         A65UsuariosApPat = T000J22_A65UsuariosApPat[0];
         A64UsuariosApMat = T000J22_A64UsuariosApMat[0];
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A66UsuariosNombre", A66UsuariosNombre);
         AssignAttri("", false, "A65UsuariosApPat", A65UsuariosApPat);
         AssignAttri("", false, "A64UsuariosApMat", A64UsuariosApMat);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7Perfiles_Id',fld:'vPERFILES_ID',pic:'ZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7Perfiles_Id',fld:'vPERFILES_ID',pic:'ZZZZZZZZ9',hsh:true},{av:'A278Perfiles_Id',fld:'PERFILES_ID',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120J2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PERFILES_ID","{handler:'Valid_Perfiles_id',iparms:[]");
         setEventMetadata("VALID_PERFILES_ID",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSID","{handler:'Valid_Usuariosid',iparms:[{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A66UsuariosNombre',fld:'USUARIOSNOMBRE',pic:'@!'},{av:'A65UsuariosApPat',fld:'USUARIOSAPPAT',pic:'@!'},{av:'A64UsuariosApMat',fld:'USUARIOSAPMAT',pic:'@!'}]");
         setEventMetadata("VALID_USUARIOSID",",oparms:[{av:'A66UsuariosNombre',fld:'USUARIOSNOMBRE',pic:'@!'},{av:'A65UsuariosApPat',fld:'USUARIOSAPPAT',pic:'@!'},{av:'A64UsuariosApMat',fld:'USUARIOSAPMAT',pic:'@!'}]}");
         setEventMetadata("NULL","{handler:'Valid_Perfilesusuariosestatus',iparms:[]");
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
         Z279Perfiles_Nombre = "";
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
         A279Perfiles_Nombre = "";
         lblTitleusuariosperfil_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridperfiles_usuariosperfilContainer = new GXWebGrid( context);
         Gridperfiles_usuariosperfilColumn = new GXWebColumn();
         A66UsuariosNombre = "";
         A65UsuariosApPat = "";
         A64UsuariosApMat = "";
         sMode27 = "";
         sStyleString = "";
         AV11Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode24 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         T000J7_A278Perfiles_Id = new int[1] ;
         T000J7_A279Perfiles_Nombre = new String[] {""} ;
         T000J7_A280Perfiles_Estatus = new short[1] ;
         T000J8_A278Perfiles_Id = new int[1] ;
         T000J6_A278Perfiles_Id = new int[1] ;
         T000J6_A279Perfiles_Nombre = new String[] {""} ;
         T000J6_A280Perfiles_Estatus = new short[1] ;
         T000J9_A278Perfiles_Id = new int[1] ;
         T000J10_A278Perfiles_Id = new int[1] ;
         T000J5_A278Perfiles_Id = new int[1] ;
         T000J5_A279Perfiles_Nombre = new String[] {""} ;
         T000J5_A280Perfiles_Estatus = new short[1] ;
         T000J12_A278Perfiles_Id = new int[1] ;
         T000J15_A278Perfiles_Id = new int[1] ;
         Z66UsuariosNombre = "";
         Z65UsuariosApPat = "";
         Z64UsuariosApMat = "";
         T000J16_A278Perfiles_Id = new int[1] ;
         T000J16_A66UsuariosNombre = new String[] {""} ;
         T000J16_A65UsuariosApPat = new String[] {""} ;
         T000J16_A64UsuariosApMat = new String[] {""} ;
         T000J16_A283PerfilesUsuariosEstatus = new short[1] ;
         T000J16_A11UsuariosId = new int[1] ;
         T000J4_A66UsuariosNombre = new String[] {""} ;
         T000J4_A65UsuariosApPat = new String[] {""} ;
         T000J4_A64UsuariosApMat = new String[] {""} ;
         T000J17_A66UsuariosNombre = new String[] {""} ;
         T000J17_A65UsuariosApPat = new String[] {""} ;
         T000J17_A64UsuariosApMat = new String[] {""} ;
         T000J18_A278Perfiles_Id = new int[1] ;
         T000J18_A11UsuariosId = new int[1] ;
         T000J3_A278Perfiles_Id = new int[1] ;
         T000J3_A283PerfilesUsuariosEstatus = new short[1] ;
         T000J3_A11UsuariosId = new int[1] ;
         T000J2_A278Perfiles_Id = new int[1] ;
         T000J2_A283PerfilesUsuariosEstatus = new short[1] ;
         T000J2_A11UsuariosId = new int[1] ;
         T000J22_A66UsuariosNombre = new String[] {""} ;
         T000J22_A65UsuariosApPat = new String[] {""} ;
         T000J22_A64UsuariosApMat = new String[] {""} ;
         T000J23_A278Perfiles_Id = new int[1] ;
         T000J23_A11UsuariosId = new int[1] ;
         Gridperfiles_usuariosperfilRow = new GXWebRow();
         subGridperfiles_usuariosperfil_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.perfiles__default(),
            new Object[][] {
                new Object[] {
               T000J2_A278Perfiles_Id, T000J2_A283PerfilesUsuariosEstatus, T000J2_A11UsuariosId
               }
               , new Object[] {
               T000J3_A278Perfiles_Id, T000J3_A283PerfilesUsuariosEstatus, T000J3_A11UsuariosId
               }
               , new Object[] {
               T000J4_A66UsuariosNombre, T000J4_A65UsuariosApPat, T000J4_A64UsuariosApMat
               }
               , new Object[] {
               T000J5_A278Perfiles_Id, T000J5_A279Perfiles_Nombre, T000J5_A280Perfiles_Estatus
               }
               , new Object[] {
               T000J6_A278Perfiles_Id, T000J6_A279Perfiles_Nombre, T000J6_A280Perfiles_Estatus
               }
               , new Object[] {
               T000J7_A278Perfiles_Id, T000J7_A279Perfiles_Nombre, T000J7_A280Perfiles_Estatus
               }
               , new Object[] {
               T000J8_A278Perfiles_Id
               }
               , new Object[] {
               T000J9_A278Perfiles_Id
               }
               , new Object[] {
               T000J10_A278Perfiles_Id
               }
               , new Object[] {
               }
               , new Object[] {
               T000J12_A278Perfiles_Id
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000J15_A278Perfiles_Id
               }
               , new Object[] {
               T000J16_A278Perfiles_Id, T000J16_A66UsuariosNombre, T000J16_A65UsuariosApPat, T000J16_A64UsuariosApMat, T000J16_A283PerfilesUsuariosEstatus, T000J16_A11UsuariosId
               }
               , new Object[] {
               T000J17_A66UsuariosNombre, T000J17_A65UsuariosApPat, T000J17_A64UsuariosApMat
               }
               , new Object[] {
               T000J18_A278Perfiles_Id, T000J18_A11UsuariosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000J22_A66UsuariosNombre, T000J22_A65UsuariosApPat, T000J22_A64UsuariosApMat
               }
               , new Object[] {
               T000J23_A278Perfiles_Id, T000J23_A11UsuariosId
               }
            }
         );
         AV11Pgmname = "Perfiles";
      }

      private short Z280Perfiles_Estatus ;
      private short Z283PerfilesUsuariosEstatus ;
      private short nRcdDeleted_27 ;
      private short nRcdExists_27 ;
      private short nIsMod_27 ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A280Perfiles_Estatus ;
      private short subGridperfiles_usuariosperfil_Backcolorstyle ;
      private short A283PerfilesUsuariosEstatus ;
      private short subGridperfiles_usuariosperfil_Allowselection ;
      private short subGridperfiles_usuariosperfil_Allowhovering ;
      private short subGridperfiles_usuariosperfil_Allowcollapsing ;
      private short subGridperfiles_usuariosperfil_Collapsed ;
      private short nBlankRcdCount27 ;
      private short RcdFound27 ;
      private short nBlankRcdUsr27 ;
      private short RcdFound24 ;
      private short GX_JID ;
      private short nIsDirty_24 ;
      private short Gx_BScreen ;
      private short nIsDirty_27 ;
      private short subGridperfiles_usuariosperfil_Backstyle ;
      private short gxajaxcallmode ;
      private int wcpOAV7Perfiles_Id ;
      private int Z278Perfiles_Id ;
      private int nRC_GXsfl_53 ;
      private int nGXsfl_53_idx=1 ;
      private int Z11UsuariosId ;
      private int A11UsuariosId ;
      private int AV7Perfiles_Id ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A278Perfiles_Id ;
      private int edtPerfiles_Id_Enabled ;
      private int edtPerfiles_Nombre_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtUsuariosId_Enabled ;
      private int edtUsuariosNombre_Enabled ;
      private int edtUsuariosApPat_Enabled ;
      private int edtUsuariosApMat_Enabled ;
      private int edtPerfilesUsuariosEstatus_Enabled ;
      private int subGridperfiles_usuariosperfil_Selectedindex ;
      private int subGridperfiles_usuariosperfil_Selectioncolor ;
      private int subGridperfiles_usuariosperfil_Hoveringcolor ;
      private int fRowAdded ;
      private int subGridperfiles_usuariosperfil_Backcolor ;
      private int subGridperfiles_usuariosperfil_Allbackcolor ;
      private int defedtUsuariosId_Enabled ;
      private int idxLst ;
      private long GRIDPERFILES_USUARIOSPERFIL_nFirstRecordOnPage ;
      private String sPrefix ;
      private String wcpOGx_mode ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_53_idx="0001" ;
      private String Gx_mode ;
      private String GXKey ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String GX_FocusControl ;
      private String edtPerfiles_Nombre_Internalname ;
      private String cmbPerfiles_Estatus_Internalname ;
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
      private String edtPerfiles_Id_Internalname ;
      private String edtPerfiles_Id_Jsonclick ;
      private String edtPerfiles_Nombre_Jsonclick ;
      private String cmbPerfiles_Estatus_Jsonclick ;
      private String divUsuariosperfiltable_Internalname ;
      private String lblTitleusuariosperfil_Internalname ;
      private String lblTitleusuariosperfil_Jsonclick ;
      private String bttBtn_enter_Internalname ;
      private String bttBtn_enter_Jsonclick ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String bttBtn_delete_Internalname ;
      private String bttBtn_delete_Jsonclick ;
      private String subGridperfiles_usuariosperfil_Header ;
      private String sMode27 ;
      private String edtUsuariosId_Internalname ;
      private String edtUsuariosNombre_Internalname ;
      private String edtUsuariosApPat_Internalname ;
      private String edtUsuariosApMat_Internalname ;
      private String edtPerfilesUsuariosEstatus_Internalname ;
      private String sStyleString ;
      private String AV11Pgmname ;
      private String hsh ;
      private String sMode24 ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String endTrnMsgTxt ;
      private String endTrnMsgCod ;
      private String GXCCtl ;
      private String sGXsfl_53_fel_idx="0001" ;
      private String subGridperfiles_usuariosperfil_Class ;
      private String subGridperfiles_usuariosperfil_Linesclass ;
      private String ROClassString ;
      private String edtUsuariosId_Jsonclick ;
      private String edtUsuariosNombre_Jsonclick ;
      private String edtUsuariosApPat_Jsonclick ;
      private String edtUsuariosApMat_Jsonclick ;
      private String edtPerfilesUsuariosEstatus_Jsonclick ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String subGridperfiles_usuariosperfil_Internalname ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_53_Refreshing=false ;
      private bool returnInSub ;
      private String Z279Perfiles_Nombre ;
      private String A279Perfiles_Nombre ;
      private String A66UsuariosNombre ;
      private String A65UsuariosApPat ;
      private String A64UsuariosApMat ;
      private String Z66UsuariosNombre ;
      private String Z65UsuariosApPat ;
      private String Z64UsuariosApMat ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridperfiles_usuariosperfilContainer ;
      private GXWebRow Gridperfiles_usuariosperfilRow ;
      private GXWebColumn Gridperfiles_usuariosperfilColumn ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbPerfiles_Estatus ;
      private IDataStoreProvider pr_default ;
      private int[] T000J7_A278Perfiles_Id ;
      private String[] T000J7_A279Perfiles_Nombre ;
      private short[] T000J7_A280Perfiles_Estatus ;
      private int[] T000J8_A278Perfiles_Id ;
      private int[] T000J6_A278Perfiles_Id ;
      private String[] T000J6_A279Perfiles_Nombre ;
      private short[] T000J6_A280Perfiles_Estatus ;
      private int[] T000J9_A278Perfiles_Id ;
      private int[] T000J10_A278Perfiles_Id ;
      private int[] T000J5_A278Perfiles_Id ;
      private String[] T000J5_A279Perfiles_Nombre ;
      private short[] T000J5_A280Perfiles_Estatus ;
      private int[] T000J12_A278Perfiles_Id ;
      private int[] T000J15_A278Perfiles_Id ;
      private int[] T000J16_A278Perfiles_Id ;
      private String[] T000J16_A66UsuariosNombre ;
      private String[] T000J16_A65UsuariosApPat ;
      private String[] T000J16_A64UsuariosApMat ;
      private short[] T000J16_A283PerfilesUsuariosEstatus ;
      private int[] T000J16_A11UsuariosId ;
      private String[] T000J4_A66UsuariosNombre ;
      private String[] T000J4_A65UsuariosApPat ;
      private String[] T000J4_A64UsuariosApMat ;
      private String[] T000J17_A66UsuariosNombre ;
      private String[] T000J17_A65UsuariosApPat ;
      private String[] T000J17_A64UsuariosApMat ;
      private int[] T000J18_A278Perfiles_Id ;
      private int[] T000J18_A11UsuariosId ;
      private int[] T000J3_A278Perfiles_Id ;
      private short[] T000J3_A283PerfilesUsuariosEstatus ;
      private int[] T000J3_A11UsuariosId ;
      private int[] T000J2_A278Perfiles_Id ;
      private short[] T000J2_A283PerfilesUsuariosEstatus ;
      private int[] T000J2_A11UsuariosId ;
      private String[] T000J22_A66UsuariosNombre ;
      private String[] T000J22_A65UsuariosApPat ;
      private String[] T000J22_A64UsuariosApMat ;
      private int[] T000J23_A278Perfiles_Id ;
      private int[] T000J23_A11UsuariosId ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
   }

   public class perfiles__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new UpdateCursor(def[17])
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
          Object[] prmT000J7 ;
          prmT000J7 = new Object[] {
          new Object[] {"Perfiles_Id",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000J8 ;
          prmT000J8 = new Object[] {
          new Object[] {"Perfiles_Id",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000J6 ;
          prmT000J6 = new Object[] {
          new Object[] {"Perfiles_Id",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000J9 ;
          prmT000J9 = new Object[] {
          new Object[] {"Perfiles_Id",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000J10 ;
          prmT000J10 = new Object[] {
          new Object[] {"Perfiles_Id",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000J5 ;
          prmT000J5 = new Object[] {
          new Object[] {"Perfiles_Id",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000J11 ;
          prmT000J11 = new Object[] {
          new Object[] {"Perfiles_Nombre",System.Data.DbType.String,40,0} ,
          new Object[] {"Perfiles_Estatus",System.Data.DbType.Int16,4,0}
          } ;
          Object[] prmT000J12 ;
          prmT000J12 = new Object[] {
          } ;
          Object[] prmT000J13 ;
          prmT000J13 = new Object[] {
          new Object[] {"Perfiles_Nombre",System.Data.DbType.String,40,0} ,
          new Object[] {"Perfiles_Estatus",System.Data.DbType.Int16,4,0} ,
          new Object[] {"Perfiles_Id",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000J14 ;
          prmT000J14 = new Object[] {
          new Object[] {"Perfiles_Id",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000J15 ;
          prmT000J15 = new Object[] {
          } ;
          Object[] prmT000J16 ;
          prmT000J16 = new Object[] {
          new Object[] {"Perfiles_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000J4 ;
          prmT000J4 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000J17 ;
          prmT000J17 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000J18 ;
          prmT000J18 = new Object[] {
          new Object[] {"Perfiles_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000J3 ;
          prmT000J3 = new Object[] {
          new Object[] {"Perfiles_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000J2 ;
          prmT000J2 = new Object[] {
          new Object[] {"Perfiles_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000J19 ;
          prmT000J19 = new Object[] {
          new Object[] {"Perfiles_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"PerfilesUsuariosEstatus",System.Data.DbType.Byte,1,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000J20 ;
          prmT000J20 = new Object[] {
          new Object[] {"PerfilesUsuariosEstatus",System.Data.DbType.Byte,1,0} ,
          new Object[] {"Perfiles_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000J21 ;
          prmT000J21 = new Object[] {
          new Object[] {"Perfiles_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000J23 ;
          prmT000J23 = new Object[] {
          new Object[] {"Perfiles_Id",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000J22 ;
          prmT000J22 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("T000J2", "SELECT `Perfiles_Id`, `PerfilesUsuariosEstatus`, `UsuariosId` FROM `PerfilesUsuariosPerfil` WHERE `Perfiles_Id` = ? AND `UsuariosId` = ?  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J3", "SELECT `Perfiles_Id`, `PerfilesUsuariosEstatus`, `UsuariosId` FROM `PerfilesUsuariosPerfil` WHERE `Perfiles_Id` = ? AND `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J4", "SELECT `UsuariosNombre`, `UsuariosApPat`, `UsuariosApMat` FROM `Usuarios` WHERE `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J5", "SELECT `Perfiles_Id`, `Perfiles_Nombre`, `Perfiles_Estatus` FROM `Perfiles` WHERE `Perfiles_Id` = ?  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J6", "SELECT `Perfiles_Id`, `Perfiles_Nombre`, `Perfiles_Estatus` FROM `Perfiles` WHERE `Perfiles_Id` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J7", "SELECT TM1.`Perfiles_Id`, TM1.`Perfiles_Nombre`, TM1.`Perfiles_Estatus` FROM `Perfiles` TM1 WHERE TM1.`Perfiles_Id` = ? ORDER BY TM1.`Perfiles_Id` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J8", "SELECT `Perfiles_Id` FROM `Perfiles` WHERE `Perfiles_Id` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J9", "SELECT `Perfiles_Id` FROM `Perfiles` WHERE ( `Perfiles_Id` > ?) ORDER BY `Perfiles_Id`  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000J9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000J10", "SELECT `Perfiles_Id` FROM `Perfiles` WHERE ( `Perfiles_Id` < ?) ORDER BY `Perfiles_Id` DESC  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000J10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000J11", "INSERT INTO `Perfiles`(`Perfiles_Nombre`, `Perfiles_Estatus`) VALUES(?, ?)", GxErrorMask.GX_NOMASK,prmT000J11)
             ,new CursorDef("T000J12", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J13", "UPDATE `Perfiles` SET `Perfiles_Nombre`=?, `Perfiles_Estatus`=?  WHERE `Perfiles_Id` = ?", GxErrorMask.GX_NOMASK,prmT000J13)
             ,new CursorDef("T000J14", "DELETE FROM `Perfiles`  WHERE `Perfiles_Id` = ?", GxErrorMask.GX_NOMASK,prmT000J14)
             ,new CursorDef("T000J15", "SELECT `Perfiles_Id` FROM `Perfiles` ORDER BY `Perfiles_Id` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J16", "SELECT T1.`Perfiles_Id`, T2.`UsuariosNombre`, T2.`UsuariosApPat`, T2.`UsuariosApMat`, T1.`PerfilesUsuariosEstatus`, T1.`UsuariosId` FROM (`PerfilesUsuariosPerfil` T1 INNER JOIN `Usuarios` T2 ON T2.`UsuariosId` = T1.`UsuariosId`) WHERE T1.`Perfiles_Id` = ? and T1.`UsuariosId` = ? ORDER BY T1.`Perfiles_Id`, T1.`UsuariosId` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J16,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J17", "SELECT `UsuariosNombre`, `UsuariosApPat`, `UsuariosApMat` FROM `Usuarios` WHERE `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J18", "SELECT `Perfiles_Id`, `UsuariosId` FROM `PerfilesUsuariosPerfil` WHERE `Perfiles_Id` = ? AND `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J19", "INSERT INTO `PerfilesUsuariosPerfil`(`Perfiles_Id`, `PerfilesUsuariosEstatus`, `UsuariosId`) VALUES(?, ?, ?)", GxErrorMask.GX_NOMASK,prmT000J19)
             ,new CursorDef("T000J20", "UPDATE `PerfilesUsuariosPerfil` SET `PerfilesUsuariosEstatus`=?  WHERE `Perfiles_Id` = ? AND `UsuariosId` = ?", GxErrorMask.GX_NOMASK,prmT000J20)
             ,new CursorDef("T000J21", "DELETE FROM `PerfilesUsuariosPerfil`  WHERE `Perfiles_Id` = ? AND `UsuariosId` = ?", GxErrorMask.GX_NOMASK,prmT000J21)
             ,new CursorDef("T000J22", "SELECT `UsuariosNombre`, `UsuariosApPat`, `UsuariosApMat` FROM `Usuarios` WHERE `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J22,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J23", "SELECT `Perfiles_Id`, `UsuariosId` FROM `PerfilesUsuariosPerfil` WHERE `Perfiles_Id` = ? ORDER BY `Perfiles_Id`, `UsuariosId` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J23,11, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                return;
             case 2 :
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((String[]) buf[3])[0] = rslt.getVarchar(4) ;
                ((short[]) buf[4])[0] = rslt.getShort(5) ;
                ((int[]) buf[5])[0] = rslt.getInt(6) ;
                return;
             case 15 :
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                return;
             case 20 :
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
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
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
             case 1 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
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
                return;
             case 7 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 8 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 9 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                return;
             case 11 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                return;
             case 12 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 14 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
             case 15 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 16 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
             case 17 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                return;
             case 18 :
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                return;
             case 19 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
             case 20 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 21 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

}
