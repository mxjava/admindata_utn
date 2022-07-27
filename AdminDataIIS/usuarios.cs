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
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class usuarios : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel11"+"_"+"USUARIOSID") == 0 )
         {
            AV40UsuariosId = (int)(NumberUtil.Val( GetNextPar( ), "."));
            AssignAttri("", false, "AV40UsuariosId", StringUtil.LTrimStr( (decimal)(AV40UsuariosId), 6, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV40UsuariosId), "ZZZZZ9"), context));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX11ASAUSUARIOSID029( AV40UsuariosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel12"+"_"+"USUARIOSID") == 0 )
         {
            Gx_mode = GetNextPar( );
            AssignAttri("", false, "Gx_mode", Gx_mode);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX12ASAUSUARIOSID029( Gx_mode) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel16"+"_"+"vUSUARIOSCURPANT") == 0 )
         {
            A11UsuariosId = (int)(NumberUtil.Val( GetNextPar( ), "."));
            n11UsuariosId = false;
            AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX16ASAUSUARIOSCURPANT029( A11UsuariosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel19"+"_"+"USUARIOSFECNACIMIENTO") == 0 )
         {
            A105UsuariosCurp = GetNextPar( );
            AssignAttri("", false, "A105UsuariosCurp", A105UsuariosCurp);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX19ASAUSUARIOSFECNACIMIENTO029( A105UsuariosCurp) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel20"+"_"+"USUARIOSEDAD") == 0 )
         {
            A105UsuariosCurp = GetNextPar( );
            AssignAttri("", false, "A105UsuariosCurp", A105UsuariosCurp);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX20ASAUSUARIOSEDAD029( A105UsuariosCurp) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel25"+"_"+"vERROR1") == 0 )
         {
            A105UsuariosCurp = GetNextPar( );
            AssignAttri("", false, "A105UsuariosCurp", A105UsuariosCurp);
            AV56UsuariosCurpAnt = GetNextPar( );
            AssignAttri("", false, "AV56UsuariosCurpAnt", AV56UsuariosCurpAnt);
            Gx_mode = GetNextPar( );
            AssignAttri("", false, "Gx_mode", Gx_mode);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX25ASAERROR1029( A105UsuariosCurp, AV56UsuariosCurpAnt, Gx_mode) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_36") == 0 )
         {
            A24RolId = (int)(NumberUtil.Val( GetNextPar( ), "."));
            AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_36( A24RolId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "usuarios.aspx")), "usuarios.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "usuarios.aspx")))) ;
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
                  AV40UsuariosId = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri("", false, "AV40UsuariosId", StringUtil.LTrimStr( (decimal)(AV40UsuariosId), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV40UsuariosId), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Alta Usuarios", 0) ;
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

      public usuarios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public usuarios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( String aP0_Gx_mode ,
                           int aP1_UsuariosId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV40UsuariosId = aP1_UsuariosId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbUsuariosTipo = new GXCombobox();
         cmbUsuariosStatus = new GXCombobox();
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("masterpagemikbreg", "GeneXus.Programs.masterpagemikbreg", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
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
         if ( cmbUsuariosTipo.ItemCount > 0 )
         {
            A272UsuariosTipo = (short)(NumberUtil.Val( cmbUsuariosTipo.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A272UsuariosTipo), 4, 0))), "."));
            AssignAttri("", false, "A272UsuariosTipo", StringUtil.LTrimStr( (decimal)(A272UsuariosTipo), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuariosTipo.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A272UsuariosTipo), 4, 0));
            AssignProp("", false, cmbUsuariosTipo_Internalname, "Values", cmbUsuariosTipo.ToJavascriptSource(), true);
         }
         if ( cmbUsuariosStatus.ItemCount > 0 )
         {
            A286UsuariosStatus = (short)(NumberUtil.Val( cmbUsuariosStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A286UsuariosStatus), 1, 0))), "."));
            AssignAttri("", false, "A286UsuariosStatus", StringUtil.Str( (decimal)(A286UsuariosStatus), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuariosStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A286UsuariosStatus), 1, 0));
            AssignProp("", false, cmbUsuariosStatus_Internalname, "Values", cmbUsuariosStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Alta Usuarios", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_Usuarios.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Usuarios.htm");
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
         GxWebStd.gx_single_line_edit( context, edtUsuariosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosId_Enabled, 1, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "NumId", "right", false, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosCurp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosCurp_Internalname, "CURP", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuariosCurp_Internalname, A105UsuariosCurp, StringUtil.RTrim( context.localUtil.Format( A105UsuariosCurp, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosCurp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosCurp_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosNombre_Internalname, "Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuariosNombre_Internalname, A66UsuariosNombre, StringUtil.RTrim( context.localUtil.Format( A66UsuariosNombre, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosNombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosApPat_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosApPat_Internalname, "Apellido Paterno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuariosApPat_Internalname, A65UsuariosApPat, StringUtil.RTrim( context.localUtil.Format( A65UsuariosApPat, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosApPat_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosApPat_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosApMat_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosApMat_Internalname, "Apellido Materno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuariosApMat_Internalname, A64UsuariosApMat, StringUtil.RTrim( context.localUtil.Format( A64UsuariosApMat, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosApMat_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosApMat_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosUsr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosUsr_Internalname, "Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuariosUsr_Internalname, A244UsuariosUsr, StringUtil.RTrim( context.localUtil.Format( A244UsuariosUsr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosUsr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosUsr_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbUsuariosTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbUsuariosTipo_Internalname, "Tipo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUsuariosTipo, cmbUsuariosTipo_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A272UsuariosTipo), 4, 0)), 1, cmbUsuariosTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbUsuariosTipo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", true, "HLP_Usuarios.htm");
         cmbUsuariosTipo.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A272UsuariosTipo), 4, 0));
         AssignProp("", false, cmbUsuariosTipo_Internalname, "Values", (String)(cmbUsuariosTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgUsuariosIcono_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Icono", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         A245UsuariosIcono_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A245UsuariosIcono))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000UsuariosIcono_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A245UsuariosIcono)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A245UsuariosIcono)) ? A40000UsuariosIcono_GXI : context.PathToRelativeUrl( A245UsuariosIcono));
         GxWebStd.gx_bitmap( context, imgUsuariosIcono_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgUsuariosIcono_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "", "", "", 0, A245UsuariosIcono_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Usuarios.htm");
         AssignProp("", false, imgUsuariosIcono_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A245UsuariosIcono)) ? A40000UsuariosIcono_GXI : context.PathToRelativeUrl( A245UsuariosIcono)), true);
         AssignProp("", false, imgUsuariosIcono_Internalname, "IsBlob", StringUtil.BoolToStr( A245UsuariosIcono_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosFecNacimiento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosFecNacimiento_Internalname, "Nacimiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtUsuariosFecNacimiento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtUsuariosFecNacimiento_Internalname, context.localUtil.Format(A255UsuariosFecNacimiento, "99/99/99"), context.localUtil.Format( A255UsuariosFecNacimiento, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosFecNacimiento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosFecNacimiento_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Usuarios.htm");
         GxWebStd.gx_bitmap( context, edtUsuariosFecNacimiento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUsuariosFecNacimiento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Usuarios.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosEdad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosEdad_Internalname, "Edad", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuariosEdad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A256UsuariosEdad), 4, 0, ",", "")), ((edtUsuariosEdad_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A256UsuariosEdad), "ZZZ9")) : context.localUtil.Format( (decimal)(A256UsuariosEdad), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosEdad_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosEdad_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosSexo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosSexo_Internalname, "Sexo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuariosSexo_Internalname, StringUtil.RTrim( A257UsuariosSexo), StringUtil.RTrim( context.localUtil.Format( A257UsuariosSexo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosSexo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosSexo_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "Sexo", "left", true, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosPwd_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosPwd_Internalname, "Contraseña", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuariosPwd_Internalname, A68UsuariosPwd, StringUtil.RTrim( context.localUtil.Format( A68UsuariosPwd, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosPwd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosPwd_Enabled, 0, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosKey_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosKey_Internalname, "Llave para encriptar pwd", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuariosKey_Internalname, A67UsuariosKey, StringUtil.RTrim( context.localUtil.Format( A67UsuariosKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosKey_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosKey_Enabled, 0, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosVigIni_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosVigIni_Internalname, "Inicio de Vigencia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtUsuariosVigIni_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtUsuariosVigIni_Internalname, context.localUtil.Format(A96UsuariosVigIni, "99/99/9999"), context.localUtil.Format( A96UsuariosVigIni, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosVigIni_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosVigIni_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "Fecha", "right", false, "", "HLP_Usuarios.htm");
         GxWebStd.gx_bitmap( context, edtUsuariosVigIni_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUsuariosVigIni_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Usuarios.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosVigFin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosVigFin_Internalname, "Fin de Vigencia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtUsuariosVigFin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtUsuariosVigFin_Internalname, context.localUtil.Format(A70UsuariosVigFin, "99/99/9999"), context.localUtil.Format( A70UsuariosVigFin, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosVigFin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosVigFin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "Fecha", "right", false, "", "HLP_Usuarios.htm");
         GxWebStd.gx_bitmap( context, edtUsuariosVigFin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUsuariosVigFin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Usuarios.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosFecCap_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosFecCap_Internalname, "Fecha de Captura", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtUsuariosFecCap_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtUsuariosFecCap_Internalname, context.localUtil.TToC( A92UsuariosFecCap, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A92UsuariosFecCap, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'spa',false,0);"+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosFecCap_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosFecCap_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 1, -1, 0, true, "FechaTiempo", "right", false, "", "HLP_Usuarios.htm");
         GxWebStd.gx_bitmap( context, edtUsuariosFecCap_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUsuariosFecCap_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Usuarios.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosIP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosIP_Internalname, "Ip de Creación", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuariosIP_Internalname, A93UsuariosIP, StringUtil.RTrim( context.localUtil.Format( A93UsuariosIP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosIP_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosIP_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "Ip", "left", true, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosTelef_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosTelef_Internalname, "Teléfono", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuariosTelef_Internalname, StringUtil.RTrim( A260UsuariosTelef), StringUtil.RTrim( context.localUtil.Format( A260UsuariosTelef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosTelef_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosTelef_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosCorreo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosCorreo_Internalname, "electrónico", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuariosCorreo_Internalname, A261UsuariosCorreo, StringUtil.RTrim( context.localUtil.Format( A261UsuariosCorreo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A261UsuariosCorreo, "", "", "", edtUsuariosCorreo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosCorreo_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosNomCompleto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosNomCompleto_Internalname, "Usuarios Nom Completo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtUsuariosNomCompleto_Internalname, A97UsuariosNomCompleto, StringUtil.RTrim( context.localUtil.Format( A97UsuariosNomCompleto, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosNomCompleto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosNomCompleto_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Usuarios.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRolId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A24RolId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A24RolId), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,134);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRolId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRolId_Enabled, 1, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Usuarios.htm");
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
         GxWebStd.gx_label_element( context, edtRolNombre_Internalname, "Rol Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtRolNombre_Internalname, A127RolNombre, StringUtil.RTrim( context.localUtil.Format( A127RolNombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRolNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRolNombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosSexoFor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosSexoFor_Internalname, "Sexo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtUsuariosSexoFor_Internalname, StringUtil.RTrim( A275UsuariosSexoFor), StringUtil.RTrim( context.localUtil.Format( A275UsuariosSexoFor, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosSexoFor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosSexoFor_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "Sexo", "left", true, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbUsuariosStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbUsuariosStatus_Internalname, "Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUsuariosStatus, cmbUsuariosStatus_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A286UsuariosStatus), 1, 0)), 1, cmbUsuariosStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbUsuariosStatus.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,149);\"", "", true, "HLP_Usuarios.htm");
         cmbUsuariosStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A286UsuariosStatus), 1, 0));
         AssignProp("", false, cmbUsuariosStatus_Internalname, "Values", (String)(cmbUsuariosStatus.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuarios.htm");
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
         E11022 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z11UsuariosId = (int)(context.localUtil.CToN( cgiGet( "Z11UsuariosId"), ",", "."));
               Z244UsuariosUsr = cgiGet( "Z244UsuariosUsr");
               Z93UsuariosIP = cgiGet( "Z93UsuariosIP");
               Z255UsuariosFecNacimiento = context.localUtil.CToD( cgiGet( "Z255UsuariosFecNacimiento"), 0);
               Z256UsuariosEdad = (short)(context.localUtil.CToN( cgiGet( "Z256UsuariosEdad"), ",", "."));
               Z105UsuariosCurp = cgiGet( "Z105UsuariosCurp");
               Z66UsuariosNombre = cgiGet( "Z66UsuariosNombre");
               Z65UsuariosApPat = cgiGet( "Z65UsuariosApPat");
               Z64UsuariosApMat = cgiGet( "Z64UsuariosApMat");
               Z272UsuariosTipo = (short)(context.localUtil.CToN( cgiGet( "Z272UsuariosTipo"), ",", "."));
               Z257UsuariosSexo = cgiGet( "Z257UsuariosSexo");
               Z68UsuariosPwd = cgiGet( "Z68UsuariosPwd");
               Z67UsuariosKey = cgiGet( "Z67UsuariosKey");
               Z96UsuariosVigIni = context.localUtil.CToD( cgiGet( "Z96UsuariosVigIni"), 0);
               Z70UsuariosVigFin = context.localUtil.CToD( cgiGet( "Z70UsuariosVigFin"), 0);
               n70UsuariosVigFin = ((DateTime.MinValue==A70UsuariosVigFin) ? true : false);
               Z92UsuariosFecCap = context.localUtil.CToT( cgiGet( "Z92UsuariosFecCap"), 0);
               Z260UsuariosTelef = cgiGet( "Z260UsuariosTelef");
               Z261UsuariosCorreo = cgiGet( "Z261UsuariosCorreo");
               Z286UsuariosStatus = (short)(context.localUtil.CToN( cgiGet( "Z286UsuariosStatus"), ",", "."));
               Z24RolId = (int)(context.localUtil.CToN( cgiGet( "Z24RolId"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               N24RolId = (int)(context.localUtil.CToN( cgiGet( "N24RolId"), ",", "."));
               AV40UsuariosId = (int)(context.localUtil.CToN( cgiGet( "vUSUARIOSID"), ",", "."));
               AV54Insert_RolId = (int)(context.localUtil.CToN( cgiGet( "vINSERT_ROLID"), ",", "."));
               AV56UsuariosCurpAnt = cgiGet( "vUSUARIOSCURPANT");
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."));
               AV53error1 = (short)(context.localUtil.CToN( cgiGet( "vERROR1"), ",", "."));
               A40000UsuariosIcono_GXI = cgiGet( "USUARIOSICONO_GXI");
               AV60Pgmname = cgiGet( "vPGMNAME");
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
               A105UsuariosCurp = StringUtil.Upper( cgiGet( edtUsuariosCurp_Internalname));
               AssignAttri("", false, "A105UsuariosCurp", A105UsuariosCurp);
               A66UsuariosNombre = StringUtil.Upper( cgiGet( edtUsuariosNombre_Internalname));
               AssignAttri("", false, "A66UsuariosNombre", A66UsuariosNombre);
               A65UsuariosApPat = StringUtil.Upper( cgiGet( edtUsuariosApPat_Internalname));
               AssignAttri("", false, "A65UsuariosApPat", A65UsuariosApPat);
               A64UsuariosApMat = StringUtil.Upper( cgiGet( edtUsuariosApMat_Internalname));
               AssignAttri("", false, "A64UsuariosApMat", A64UsuariosApMat);
               A244UsuariosUsr = cgiGet( edtUsuariosUsr_Internalname);
               AssignAttri("", false, "A244UsuariosUsr", A244UsuariosUsr);
               cmbUsuariosTipo.CurrentValue = cgiGet( cmbUsuariosTipo_Internalname);
               A272UsuariosTipo = (short)(NumberUtil.Val( cgiGet( cmbUsuariosTipo_Internalname), "."));
               AssignAttri("", false, "A272UsuariosTipo", StringUtil.LTrimStr( (decimal)(A272UsuariosTipo), 4, 0));
               A245UsuariosIcono = cgiGet( imgUsuariosIcono_Internalname);
               AssignAttri("", false, "A245UsuariosIcono", A245UsuariosIcono);
               if ( context.localUtil.VCDate( cgiGet( edtUsuariosFecNacimiento_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Nacimiento"}), 1, "USUARIOSFECNACIMIENTO");
                  AnyError = 1;
                  GX_FocusControl = edtUsuariosFecNacimiento_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A255UsuariosFecNacimiento = DateTime.MinValue;
                  AssignAttri("", false, "A255UsuariosFecNacimiento", context.localUtil.Format(A255UsuariosFecNacimiento, "99/99/99"));
               }
               else
               {
                  A255UsuariosFecNacimiento = context.localUtil.CToD( cgiGet( edtUsuariosFecNacimiento_Internalname), 2);
                  AssignAttri("", false, "A255UsuariosFecNacimiento", context.localUtil.Format(A255UsuariosFecNacimiento, "99/99/99"));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtUsuariosEdad_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuariosEdad_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIOSEDAD");
                  AnyError = 1;
                  GX_FocusControl = edtUsuariosEdad_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A256UsuariosEdad = 0;
                  AssignAttri("", false, "A256UsuariosEdad", StringUtil.LTrimStr( (decimal)(A256UsuariosEdad), 4, 0));
               }
               else
               {
                  A256UsuariosEdad = (short)(context.localUtil.CToN( cgiGet( edtUsuariosEdad_Internalname), ",", "."));
                  AssignAttri("", false, "A256UsuariosEdad", StringUtil.LTrimStr( (decimal)(A256UsuariosEdad), 4, 0));
               }
               A257UsuariosSexo = cgiGet( edtUsuariosSexo_Internalname);
               AssignAttri("", false, "A257UsuariosSexo", A257UsuariosSexo);
               A68UsuariosPwd = cgiGet( edtUsuariosPwd_Internalname);
               AssignAttri("", false, "A68UsuariosPwd", A68UsuariosPwd);
               A67UsuariosKey = cgiGet( edtUsuariosKey_Internalname);
               AssignAttri("", false, "A67UsuariosKey", A67UsuariosKey);
               if ( context.localUtil.VCDate( cgiGet( edtUsuariosVigIni_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha de inicio de acceso"}), 1, "USUARIOSVIGINI");
                  AnyError = 1;
                  GX_FocusControl = edtUsuariosVigIni_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A96UsuariosVigIni = DateTime.MinValue;
                  AssignAttri("", false, "A96UsuariosVigIni", context.localUtil.Format(A96UsuariosVigIni, "99/99/9999"));
               }
               else
               {
                  A96UsuariosVigIni = context.localUtil.CToD( cgiGet( edtUsuariosVigIni_Internalname), 2);
                  AssignAttri("", false, "A96UsuariosVigIni", context.localUtil.Format(A96UsuariosVigIni, "99/99/9999"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtUsuariosVigFin_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha de cierre del permiso del usuario"}), 1, "USUARIOSVIGFIN");
                  AnyError = 1;
                  GX_FocusControl = edtUsuariosVigFin_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A70UsuariosVigFin = DateTime.MinValue;
                  n70UsuariosVigFin = false;
                  AssignAttri("", false, "A70UsuariosVigFin", context.localUtil.Format(A70UsuariosVigFin, "99/99/9999"));
               }
               else
               {
                  A70UsuariosVigFin = context.localUtil.CToD( cgiGet( edtUsuariosVigFin_Internalname), 2);
                  n70UsuariosVigFin = false;
                  AssignAttri("", false, "A70UsuariosVigFin", context.localUtil.Format(A70UsuariosVigFin, "99/99/9999"));
               }
               n70UsuariosVigFin = ((DateTime.MinValue==A70UsuariosVigFin) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtUsuariosFecCap_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha de Captura"}), 1, "USUARIOSFECCAP");
                  AnyError = 1;
                  GX_FocusControl = edtUsuariosFecCap_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A92UsuariosFecCap = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A92UsuariosFecCap", context.localUtil.TToC( A92UsuariosFecCap, 10, 8, 0, 3, "/", ":", " "));
               }
               else
               {
                  A92UsuariosFecCap = context.localUtil.CToT( cgiGet( edtUsuariosFecCap_Internalname));
                  AssignAttri("", false, "A92UsuariosFecCap", context.localUtil.TToC( A92UsuariosFecCap, 10, 8, 0, 3, "/", ":", " "));
               }
               A93UsuariosIP = cgiGet( edtUsuariosIP_Internalname);
               AssignAttri("", false, "A93UsuariosIP", A93UsuariosIP);
               A260UsuariosTelef = cgiGet( edtUsuariosTelef_Internalname);
               AssignAttri("", false, "A260UsuariosTelef", A260UsuariosTelef);
               A261UsuariosCorreo = cgiGet( edtUsuariosCorreo_Internalname);
               AssignAttri("", false, "A261UsuariosCorreo", A261UsuariosCorreo);
               A97UsuariosNomCompleto = cgiGet( edtUsuariosNomCompleto_Internalname);
               AssignAttri("", false, "A97UsuariosNomCompleto", A97UsuariosNomCompleto);
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
               A275UsuariosSexoFor = cgiGet( edtUsuariosSexoFor_Internalname);
               AssignAttri("", false, "A275UsuariosSexoFor", A275UsuariosSexoFor);
               cmbUsuariosStatus.CurrentValue = cgiGet( cmbUsuariosStatus_Internalname);
               A286UsuariosStatus = (short)(NumberUtil.Val( cgiGet( cmbUsuariosStatus_Internalname), "."));
               AssignAttri("", false, "A286UsuariosStatus", StringUtil.Str( (decimal)(A286UsuariosStatus), 1, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgUsuariosIcono_Internalname, ref  A245UsuariosIcono, ref  A40000UsuariosIcono_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Usuarios");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A11UsuariosId != Z11UsuariosId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("usuarios:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                           CONFIRM_020( ) ;
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
                           E11022 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12022 ();
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
            E12022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll029( ) ;
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
            DisableAttributes029( ) ;
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

      protected void CONFIRM_020( )
      {
         BeforeValidate029( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls029( ) ;
            }
            else
            {
               CheckExtendedTable029( ) ;
               CloseExtendedTableCursors029( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption020( )
      {
      }

      protected void E11022( )
      {
         /* Start Routine */
         AV35usuario = AV30Sesion.Get("UsuarioId");
         AssignAttri("", false, "AV35usuario", AV35usuario);
         AV34UsrLog = (int)(NumberUtil.Val( AV35usuario, "."));
         AssignAttri("", false, "AV34UsrLog", StringUtil.LTrimStr( (decimal)(AV34UsrLog), 6, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSRLOG", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34UsrLog), "ZZZZZ9"), context));
         if ( ! new isauthorized(context).executeUdp(  AV60Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV60Pgmname)));
            context.wjLocDisableFrm = 1;
         }
         AV32TrnContext.FromXml(AV46WebSession.Get("TrnContext"), null, "TransactionContext", "ADMINDATA1");
         AV54Insert_RolId = 0;
         AssignAttri("", false, "AV54Insert_RolId", StringUtil.LTrimStr( (decimal)(AV54Insert_RolId), 9, 0));
         if ( ( StringUtil.StrCmp(AV32TrnContext.gxTpr_Transactionname, AV60Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV61GXV1 = 1;
            AssignAttri("", false, "AV61GXV1", StringUtil.LTrimStr( (decimal)(AV61GXV1), 8, 0));
            while ( AV61GXV1 <= AV32TrnContext.gxTpr_Attributes.Count )
            {
               AV33TrnContextAtt = ((SdtTransactionContext_Attribute)AV32TrnContext.gxTpr_Attributes.Item(AV61GXV1));
               if ( StringUtil.StrCmp(AV33TrnContextAtt.gxTpr_Attributename, "RolId") == 0 )
               {
                  AV54Insert_RolId = (int)(NumberUtil.Val( AV33TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV54Insert_RolId", StringUtil.LTrimStr( (decimal)(AV54Insert_RolId), 9, 0));
               }
               AV61GXV1 = (int)(AV61GXV1+1);
               AssignAttri("", false, "AV61GXV1", StringUtil.LTrimStr( (decimal)(AV61GXV1), 8, 0));
            }
         }
         if ( ! new isauthorized(context).executeUdp(  AV60Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV60Pgmname)));
            context.wjLocDisableFrm = 1;
         }
         AV32TrnContext.FromXml(AV46WebSession.Get("TrnContext"), null, "TransactionContext", "ADMINDATA1");
         AV54Insert_RolId = 0;
         AssignAttri("", false, "AV54Insert_RolId", StringUtil.LTrimStr( (decimal)(AV54Insert_RolId), 9, 0));
         if ( ( StringUtil.StrCmp(AV32TrnContext.gxTpr_Transactionname, AV60Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV62GXV2 = 1;
            AssignAttri("", false, "AV62GXV2", StringUtil.LTrimStr( (decimal)(AV62GXV2), 8, 0));
            while ( AV62GXV2 <= AV32TrnContext.gxTpr_Attributes.Count )
            {
               AV33TrnContextAtt = ((SdtTransactionContext_Attribute)AV32TrnContext.gxTpr_Attributes.Item(AV62GXV2));
               if ( StringUtil.StrCmp(AV33TrnContextAtt.gxTpr_Attributename, "RolId") == 0 )
               {
                  AV54Insert_RolId = (int)(NumberUtil.Val( AV33TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV54Insert_RolId", StringUtil.LTrimStr( (decimal)(AV54Insert_RolId), 9, 0));
               }
               AV62GXV2 = (int)(AV62GXV2+1);
               AssignAttri("", false, "AV62GXV2", StringUtil.LTrimStr( (decimal)(AV62GXV2), 8, 0));
            }
         }
      }

      protected void E12022( )
      {
         /* After Trn Routine */
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            new creallavepwd(context ).execute(  A11UsuariosId,  A68UsuariosPwd,  A244UsuariosUsr,  AV34UsrLog,  AV7adscId,  AV10comision) ;
            GXt_int1 = AV29SecRnd;
            new insertsec(context ).execute( ref  A11UsuariosId, ref  GXt_int1) ;
            AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
            AV29SecRnd = (int)(GXt_int1);
            if ( (0==AV34UsrLog) )
            {
               GX_msglist.addItem("El usuarioId esta vacio");
            }
            else
            {
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV32TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwusuarios.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM029( short GX_JID )
      {
         if ( ( GX_JID == 35 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z244UsuariosUsr = T00023_A244UsuariosUsr[0];
               Z93UsuariosIP = T00023_A93UsuariosIP[0];
               Z255UsuariosFecNacimiento = T00023_A255UsuariosFecNacimiento[0];
               Z256UsuariosEdad = T00023_A256UsuariosEdad[0];
               Z105UsuariosCurp = T00023_A105UsuariosCurp[0];
               Z66UsuariosNombre = T00023_A66UsuariosNombre[0];
               Z65UsuariosApPat = T00023_A65UsuariosApPat[0];
               Z64UsuariosApMat = T00023_A64UsuariosApMat[0];
               Z272UsuariosTipo = T00023_A272UsuariosTipo[0];
               Z257UsuariosSexo = T00023_A257UsuariosSexo[0];
               Z68UsuariosPwd = T00023_A68UsuariosPwd[0];
               Z67UsuariosKey = T00023_A67UsuariosKey[0];
               Z96UsuariosVigIni = T00023_A96UsuariosVigIni[0];
               Z70UsuariosVigFin = T00023_A70UsuariosVigFin[0];
               Z92UsuariosFecCap = T00023_A92UsuariosFecCap[0];
               Z260UsuariosTelef = T00023_A260UsuariosTelef[0];
               Z261UsuariosCorreo = T00023_A261UsuariosCorreo[0];
               Z286UsuariosStatus = T00023_A286UsuariosStatus[0];
               Z24RolId = T00023_A24RolId[0];
            }
            else
            {
               Z244UsuariosUsr = A244UsuariosUsr;
               Z93UsuariosIP = A93UsuariosIP;
               Z255UsuariosFecNacimiento = A255UsuariosFecNacimiento;
               Z256UsuariosEdad = A256UsuariosEdad;
               Z105UsuariosCurp = A105UsuariosCurp;
               Z66UsuariosNombre = A66UsuariosNombre;
               Z65UsuariosApPat = A65UsuariosApPat;
               Z64UsuariosApMat = A64UsuariosApMat;
               Z272UsuariosTipo = A272UsuariosTipo;
               Z257UsuariosSexo = A257UsuariosSexo;
               Z68UsuariosPwd = A68UsuariosPwd;
               Z67UsuariosKey = A67UsuariosKey;
               Z96UsuariosVigIni = A96UsuariosVigIni;
               Z70UsuariosVigFin = A70UsuariosVigFin;
               Z92UsuariosFecCap = A92UsuariosFecCap;
               Z260UsuariosTelef = A260UsuariosTelef;
               Z261UsuariosCorreo = A261UsuariosCorreo;
               Z286UsuariosStatus = A286UsuariosStatus;
               Z24RolId = A24RolId;
            }
         }
         if ( GX_JID == -35 )
         {
            Z11UsuariosId = A11UsuariosId;
            Z244UsuariosUsr = A244UsuariosUsr;
            Z93UsuariosIP = A93UsuariosIP;
            Z255UsuariosFecNacimiento = A255UsuariosFecNacimiento;
            Z256UsuariosEdad = A256UsuariosEdad;
            Z105UsuariosCurp = A105UsuariosCurp;
            Z66UsuariosNombre = A66UsuariosNombre;
            Z65UsuariosApPat = A65UsuariosApPat;
            Z64UsuariosApMat = A64UsuariosApMat;
            Z272UsuariosTipo = A272UsuariosTipo;
            Z245UsuariosIcono = A245UsuariosIcono;
            Z40000UsuariosIcono_GXI = A40000UsuariosIcono_GXI;
            Z257UsuariosSexo = A257UsuariosSexo;
            Z68UsuariosPwd = A68UsuariosPwd;
            Z67UsuariosKey = A67UsuariosKey;
            Z96UsuariosVigIni = A96UsuariosVigIni;
            Z70UsuariosVigFin = A70UsuariosVigFin;
            Z92UsuariosFecCap = A92UsuariosFecCap;
            Z260UsuariosTelef = A260UsuariosTelef;
            Z261UsuariosCorreo = A261UsuariosCorreo;
            Z286UsuariosStatus = A286UsuariosStatus;
            Z24RolId = A24RolId;
            Z127RolNombre = A127RolNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV40UsuariosId) )
         {
            A11UsuariosId = AV40UsuariosId;
            n11UsuariosId = false;
            AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
         }
         if ( ! (0==AV40UsuariosId) )
         {
            edtUsuariosId_Enabled = 0;
            AssignProp("", false, edtUsuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosId_Enabled), 5, 0), true);
         }
         else
         {
            edtUsuariosId_Enabled = 1;
            AssignProp("", false, edtUsuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV40UsuariosId) )
         {
            edtUsuariosId_Enabled = 0;
            AssignProp("", false, edtUsuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV54Insert_RolId) )
         {
            edtRolId_Enabled = 0;
            AssignProp("", false, edtRolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRolId_Enabled), 5, 0), true);
         }
         else
         {
            edtRolId_Enabled = 1;
            AssignProp("", false, edtRolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRolId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         A93UsuariosIP = context.GetRemoteAddress( );
         AssignAttri("", false, "A93UsuariosIP", A93UsuariosIP);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV54Insert_RolId) )
         {
            A24RolId = AV54Insert_RolId;
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
         if ( IsIns( )  && (DateTime.MinValue==A96UsuariosVigIni) && ( Gx_BScreen == 0 ) )
         {
            A96UsuariosVigIni = Gx_date;
            AssignAttri("", false, "A96UsuariosVigIni", context.localUtil.Format(A96UsuariosVigIni, "99/99/9999"));
         }
         if ( IsIns( )  && (DateTime.MinValue==A70UsuariosVigFin) && ( Gx_BScreen == 0 ) )
         {
            A70UsuariosVigFin = DateTimeUtil.DAdd(Gx_date,+((int)(365)));
            n70UsuariosVigFin = false;
            AssignAttri("", false, "A70UsuariosVigFin", context.localUtil.Format(A70UsuariosVigFin, "99/99/9999"));
         }
         if ( IsIns( )  && (DateTime.MinValue==A92UsuariosFecCap) && ( Gx_BScreen == 0 ) )
         {
            A92UsuariosFecCap = DateTimeUtil.ServerNow( context, pr_default);
            AssignAttri("", false, "A92UsuariosFecCap", context.localUtil.TToC( A92UsuariosFecCap, 10, 8, 0, 3, "/", ":", " "));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            GXt_char2 = AV56UsuariosCurpAnt;
            new pr_recuperacurp(context ).execute(  A11UsuariosId, out  GXt_char2) ;
            AV56UsuariosCurpAnt = GXt_char2;
            AssignAttri("", false, "AV56UsuariosCurpAnt", AV56UsuariosCurpAnt);
            AV60Pgmname = "Usuarios";
            AssignAttri("", false, "AV60Pgmname", AV60Pgmname);
            /* Using cursor T00024 */
            pr_default.execute(2, new Object[] {A24RolId});
            A127RolNombre = T00024_A127RolNombre[0];
            AssignAttri("", false, "A127RolNombre", A127RolNombre);
            pr_default.close(2);
         }
      }

      protected void Load029( )
      {
         /* Using cursor T00025 */
         pr_default.execute(3, new Object[] {n11UsuariosId, A11UsuariosId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound9 = 1;
            A244UsuariosUsr = T00025_A244UsuariosUsr[0];
            AssignAttri("", false, "A244UsuariosUsr", A244UsuariosUsr);
            A93UsuariosIP = T00025_A93UsuariosIP[0];
            AssignAttri("", false, "A93UsuariosIP", A93UsuariosIP);
            A255UsuariosFecNacimiento = T00025_A255UsuariosFecNacimiento[0];
            AssignAttri("", false, "A255UsuariosFecNacimiento", context.localUtil.Format(A255UsuariosFecNacimiento, "99/99/99"));
            A256UsuariosEdad = T00025_A256UsuariosEdad[0];
            AssignAttri("", false, "A256UsuariosEdad", StringUtil.LTrimStr( (decimal)(A256UsuariosEdad), 4, 0));
            A105UsuariosCurp = T00025_A105UsuariosCurp[0];
            AssignAttri("", false, "A105UsuariosCurp", A105UsuariosCurp);
            A66UsuariosNombre = T00025_A66UsuariosNombre[0];
            AssignAttri("", false, "A66UsuariosNombre", A66UsuariosNombre);
            A65UsuariosApPat = T00025_A65UsuariosApPat[0];
            AssignAttri("", false, "A65UsuariosApPat", A65UsuariosApPat);
            A64UsuariosApMat = T00025_A64UsuariosApMat[0];
            AssignAttri("", false, "A64UsuariosApMat", A64UsuariosApMat);
            A272UsuariosTipo = T00025_A272UsuariosTipo[0];
            AssignAttri("", false, "A272UsuariosTipo", StringUtil.LTrimStr( (decimal)(A272UsuariosTipo), 4, 0));
            A40000UsuariosIcono_GXI = T00025_A40000UsuariosIcono_GXI[0];
            AssignProp("", false, imgUsuariosIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A245UsuariosIcono)) ? A40000UsuariosIcono_GXI : context.convertURL( context.PathToRelativeUrl( A245UsuariosIcono))), true);
            AssignProp("", false, imgUsuariosIcono_Internalname, "SrcSet", context.GetImageSrcSet( A245UsuariosIcono), true);
            A257UsuariosSexo = T00025_A257UsuariosSexo[0];
            AssignAttri("", false, "A257UsuariosSexo", A257UsuariosSexo);
            A68UsuariosPwd = T00025_A68UsuariosPwd[0];
            AssignAttri("", false, "A68UsuariosPwd", A68UsuariosPwd);
            A67UsuariosKey = T00025_A67UsuariosKey[0];
            AssignAttri("", false, "A67UsuariosKey", A67UsuariosKey);
            A96UsuariosVigIni = T00025_A96UsuariosVigIni[0];
            AssignAttri("", false, "A96UsuariosVigIni", context.localUtil.Format(A96UsuariosVigIni, "99/99/9999"));
            A70UsuariosVigFin = T00025_A70UsuariosVigFin[0];
            n70UsuariosVigFin = T00025_n70UsuariosVigFin[0];
            AssignAttri("", false, "A70UsuariosVigFin", context.localUtil.Format(A70UsuariosVigFin, "99/99/9999"));
            A92UsuariosFecCap = T00025_A92UsuariosFecCap[0];
            AssignAttri("", false, "A92UsuariosFecCap", context.localUtil.TToC( A92UsuariosFecCap, 10, 8, 0, 3, "/", ":", " "));
            A260UsuariosTelef = T00025_A260UsuariosTelef[0];
            AssignAttri("", false, "A260UsuariosTelef", A260UsuariosTelef);
            A261UsuariosCorreo = T00025_A261UsuariosCorreo[0];
            AssignAttri("", false, "A261UsuariosCorreo", A261UsuariosCorreo);
            A127RolNombre = T00025_A127RolNombre[0];
            AssignAttri("", false, "A127RolNombre", A127RolNombre);
            A286UsuariosStatus = T00025_A286UsuariosStatus[0];
            AssignAttri("", false, "A286UsuariosStatus", StringUtil.Str( (decimal)(A286UsuariosStatus), 1, 0));
            A24RolId = T00025_A24RolId[0];
            AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
            A245UsuariosIcono = T00025_A245UsuariosIcono[0];
            AssignAttri("", false, "A245UsuariosIcono", A245UsuariosIcono);
            AssignProp("", false, imgUsuariosIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A245UsuariosIcono)) ? A40000UsuariosIcono_GXI : context.convertURL( context.PathToRelativeUrl( A245UsuariosIcono))), true);
            AssignProp("", false, imgUsuariosIcono_Internalname, "SrcSet", context.GetImageSrcSet( A245UsuariosIcono), true);
            ZM029( -35) ;
         }
         pr_default.close(3);
         OnLoadActions029( ) ;
      }

      protected void OnLoadActions029( )
      {
         AV60Pgmname = "Usuarios";
         AssignAttri("", false, "AV60Pgmname", AV60Pgmname);
         GXt_char2 = AV56UsuariosCurpAnt;
         new pr_recuperacurp(context ).execute(  A11UsuariosId, out  GXt_char2) ;
         AV56UsuariosCurpAnt = GXt_char2;
         AssignAttri("", false, "AV56UsuariosCurpAnt", AV56UsuariosCurpAnt);
         GXt_int3 = AV53error1;
         new pr_buscacurp(context ).execute(  A105UsuariosCurp,  AV56UsuariosCurpAnt,  Gx_mode, out  GXt_int3) ;
         AV53error1 = GXt_int3;
         AssignAttri("", false, "AV53error1", StringUtil.LTrimStr( (decimal)(AV53error1), 4, 0));
         A244UsuariosUsr = A105UsuariosCurp;
         AssignAttri("", false, "A244UsuariosUsr", A244UsuariosUsr);
         GXt_date4 = A255UsuariosFecNacimiento;
         new pr_recfecha(context ).execute(  A105UsuariosCurp, out  GXt_date4) ;
         A255UsuariosFecNacimiento = GXt_date4;
         AssignAttri("", false, "A255UsuariosFecNacimiento", context.localUtil.Format(A255UsuariosFecNacimiento, "99/99/99"));
         GXt_int3 = A256UsuariosEdad;
         new pr_recedad(context ).execute(  A105UsuariosCurp, out  GXt_int3) ;
         A256UsuariosEdad = GXt_int3;
         AssignAttri("", false, "A256UsuariosEdad", StringUtil.LTrimStr( (decimal)(A256UsuariosEdad), 4, 0));
         A97UsuariosNomCompleto = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + StringUtil.Trim( A64UsuariosApMat);
         AssignAttri("", false, "A97UsuariosNomCompleto", A97UsuariosNomCompleto);
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A257UsuariosSexo)) && ( Gx_BScreen == 0 ) )
         {
            A257UsuariosSexo = StringUtil.Substring( A105UsuariosCurp, 11, 1);
            AssignAttri("", false, "A257UsuariosSexo", A257UsuariosSexo);
         }
         if ( StringUtil.StrCmp(A257UsuariosSexo, "H") == 0 )
         {
            A275UsuariosSexoFor = "Hombres";
            AssignAttri("", false, "A275UsuariosSexoFor", A275UsuariosSexoFor);
         }
         else
         {
            if ( StringUtil.StrCmp(A257UsuariosSexo, "M") == 0 )
            {
               A275UsuariosSexoFor = "Mujeres";
               AssignAttri("", false, "A275UsuariosSexoFor", A275UsuariosSexoFor);
            }
            else
            {
               A275UsuariosSexoFor = "";
               AssignAttri("", false, "A275UsuariosSexoFor", A275UsuariosSexoFor);
            }
         }
      }

      protected void CheckExtendedTable029( )
      {
         nIsDirty_9 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV60Pgmname = "Usuarios";
         AssignAttri("", false, "AV60Pgmname", AV60Pgmname);
         GXt_char2 = AV56UsuariosCurpAnt;
         new pr_recuperacurp(context ).execute(  A11UsuariosId, out  GXt_char2) ;
         AV56UsuariosCurpAnt = GXt_char2;
         AssignAttri("", false, "AV56UsuariosCurpAnt", AV56UsuariosCurpAnt);
         GXt_int3 = AV53error1;
         new pr_buscacurp(context ).execute(  A105UsuariosCurp,  AV56UsuariosCurpAnt,  Gx_mode, out  GXt_int3) ;
         AV53error1 = GXt_int3;
         AssignAttri("", false, "AV53error1", StringUtil.LTrimStr( (decimal)(AV53error1), 4, 0));
         if ( AV53error1 == 1 )
         {
            GX_msglist.addItem("Ya existe la CURP ingresada.  Favor de verificar. !", 1, "");
            AnyError = 1;
         }
         nIsDirty_9 = 1;
         A244UsuariosUsr = A105UsuariosCurp;
         AssignAttri("", false, "A244UsuariosUsr", A244UsuariosUsr);
         nIsDirty_9 = 1;
         GXt_date4 = A255UsuariosFecNacimiento;
         new pr_recfecha(context ).execute(  A105UsuariosCurp, out  GXt_date4) ;
         A255UsuariosFecNacimiento = GXt_date4;
         AssignAttri("", false, "A255UsuariosFecNacimiento", context.localUtil.Format(A255UsuariosFecNacimiento, "99/99/99"));
         nIsDirty_9 = 1;
         GXt_int3 = A256UsuariosEdad;
         new pr_recedad(context ).execute(  A105UsuariosCurp, out  GXt_int3) ;
         A256UsuariosEdad = GXt_int3;
         AssignAttri("", false, "A256UsuariosEdad", StringUtil.LTrimStr( (decimal)(A256UsuariosEdad), 4, 0));
         if ( ! (GxRegex.IsMatch(A105UsuariosCurp,"\\b[A-Z]{4}[0-9]{6}[A-Z]{6}[0-Z]{2}\\b")) )
         {
            GX_msglist.addItem("CURP incorrecta,  Favor de verificar!", 1, "USUARIOSCURP");
            AnyError = 1;
            GX_FocusControl = edtUsuariosCurp_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         nIsDirty_9 = 1;
         A97UsuariosNomCompleto = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + StringUtil.Trim( A64UsuariosApMat);
         AssignAttri("", false, "A97UsuariosNomCompleto", A97UsuariosNomCompleto);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A66UsuariosNombre)) )
         {
            GX_msglist.addItem("El nombre no puede ir vacio, Favor de verificar!", 1, "USUARIOSNOMBRE");
            AnyError = 1;
            GX_FocusControl = edtUsuariosNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A65UsuariosApPat)) )
         {
            GX_msglist.addItem("El primer apellido no puede ir vacio,  Favor de verificar!", 1, "USUARIOSAPPAT");
            AnyError = 1;
            GX_FocusControl = edtUsuariosApPat_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (0==A272UsuariosTipo) )
         {
            GX_msglist.addItem("El tipo de usuario no puede ir vacio,  Favor de verificar!", 1, "USUARIOSTIPO");
            AnyError = 1;
            GX_FocusControl = cmbUsuariosTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A255UsuariosFecNacimiento) || ( A255UsuariosFecNacimiento >= context.localUtil.YMDToD( 1000, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Nacimiento fuera de rango", "OutOfRange", 1, "USUARIOSFECNACIMIENTO");
            AnyError = 1;
            GX_FocusControl = edtUsuariosFecNacimiento_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A96UsuariosVigIni) || ( A96UsuariosVigIni >= context.localUtil.YMDToD( 1000, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Fecha de inicio de acceso fuera de rango", "OutOfRange", 1, "USUARIOSVIGINI");
            AnyError = 1;
            GX_FocusControl = edtUsuariosVigIni_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A70UsuariosVigFin) || ( A70UsuariosVigFin >= context.localUtil.YMDToD( 1000, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Fecha de cierre del permiso del usuario fuera de rango", "OutOfRange", 1, "USUARIOSVIGFIN");
            AnyError = 1;
            GX_FocusControl = edtUsuariosVigFin_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A92UsuariosFecCap) || ( A92UsuariosFecCap >= context.localUtil.YMDHMSToT( 1000, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha de Captura fuera de rango", "OutOfRange", 1, "USUARIOSFECCAP");
            AnyError = 1;
            GX_FocusControl = edtUsuariosFecCap_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! (GxRegex.IsMatch(A260UsuariosTelef,"\\b[0-9]{10}\\b")) )
         {
            GX_msglist.addItem("Telefono incorrecto, Favor de verificar!", 1, "USUARIOSTELEF");
            AnyError = 1;
            GX_FocusControl = edtUsuariosTelef_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A261UsuariosCorreo,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("El valor de Correo electrónico no coincide con el patrón especificado", "OutOfRange", 1, "USUARIOSCORREO");
            AnyError = 1;
            GX_FocusControl = edtUsuariosCorreo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A261UsuariosCorreo)) )
         {
            GX_msglist.addItem("El correo no puede ir vacio,  Favor de verificar!", 1, "USUARIOSCORREO");
            AnyError = 1;
            GX_FocusControl = edtUsuariosCorreo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00024 */
         pr_default.execute(2, new Object[] {A24RolId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Roles'.", "ForeignKeyNotFound", 1, "ROLID");
            AnyError = 1;
            GX_FocusControl = edtRolId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A127RolNombre = T00024_A127RolNombre[0];
         AssignAttri("", false, "A127RolNombre", A127RolNombre);
         pr_default.close(2);
         if ( ! ( ( A286UsuariosStatus == 1 ) || ( A286UsuariosStatus == 0 ) ) )
         {
            GX_msglist.addItem("Campo Usuarios Status fuera de rango", "OutOfRange", 1, "USUARIOSSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbUsuariosStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A257UsuariosSexo)) && ( Gx_BScreen == 0 ) )
         {
            nIsDirty_9 = 1;
            A257UsuariosSexo = StringUtil.Substring( A105UsuariosCurp, 11, 1);
            AssignAttri("", false, "A257UsuariosSexo", A257UsuariosSexo);
         }
         if ( StringUtil.StrCmp(A257UsuariosSexo, "H") == 0 )
         {
            nIsDirty_9 = 1;
            A275UsuariosSexoFor = "Hombres";
            AssignAttri("", false, "A275UsuariosSexoFor", A275UsuariosSexoFor);
         }
         else
         {
            if ( StringUtil.StrCmp(A257UsuariosSexo, "M") == 0 )
            {
               nIsDirty_9 = 1;
               A275UsuariosSexoFor = "Mujeres";
               AssignAttri("", false, "A275UsuariosSexoFor", A275UsuariosSexoFor);
            }
            else
            {
               nIsDirty_9 = 1;
               A275UsuariosSexoFor = "";
               AssignAttri("", false, "A275UsuariosSexoFor", A275UsuariosSexoFor);
            }
         }
      }

      protected void CloseExtendedTableCursors029( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_36( int A24RolId )
      {
         /* Using cursor T00026 */
         pr_default.execute(4, new Object[] {A24RolId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Roles'.", "ForeignKeyNotFound", 1, "ROLID");
            AnyError = 1;
            GX_FocusControl = edtRolId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A127RolNombre = T00026_A127RolNombre[0];
         AssignAttri("", false, "A127RolNombre", A127RolNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A127RolNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey029( )
      {
         /* Using cursor T00027 */
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
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {n11UsuariosId, A11UsuariosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM029( 35) ;
            RcdFound9 = 1;
            A11UsuariosId = T00023_A11UsuariosId[0];
            n11UsuariosId = T00023_n11UsuariosId[0];
            AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
            A244UsuariosUsr = T00023_A244UsuariosUsr[0];
            AssignAttri("", false, "A244UsuariosUsr", A244UsuariosUsr);
            A93UsuariosIP = T00023_A93UsuariosIP[0];
            AssignAttri("", false, "A93UsuariosIP", A93UsuariosIP);
            A255UsuariosFecNacimiento = T00023_A255UsuariosFecNacimiento[0];
            AssignAttri("", false, "A255UsuariosFecNacimiento", context.localUtil.Format(A255UsuariosFecNacimiento, "99/99/99"));
            A256UsuariosEdad = T00023_A256UsuariosEdad[0];
            AssignAttri("", false, "A256UsuariosEdad", StringUtil.LTrimStr( (decimal)(A256UsuariosEdad), 4, 0));
            A105UsuariosCurp = T00023_A105UsuariosCurp[0];
            AssignAttri("", false, "A105UsuariosCurp", A105UsuariosCurp);
            A66UsuariosNombre = T00023_A66UsuariosNombre[0];
            AssignAttri("", false, "A66UsuariosNombre", A66UsuariosNombre);
            A65UsuariosApPat = T00023_A65UsuariosApPat[0];
            AssignAttri("", false, "A65UsuariosApPat", A65UsuariosApPat);
            A64UsuariosApMat = T00023_A64UsuariosApMat[0];
            AssignAttri("", false, "A64UsuariosApMat", A64UsuariosApMat);
            A272UsuariosTipo = T00023_A272UsuariosTipo[0];
            AssignAttri("", false, "A272UsuariosTipo", StringUtil.LTrimStr( (decimal)(A272UsuariosTipo), 4, 0));
            A40000UsuariosIcono_GXI = T00023_A40000UsuariosIcono_GXI[0];
            AssignProp("", false, imgUsuariosIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A245UsuariosIcono)) ? A40000UsuariosIcono_GXI : context.convertURL( context.PathToRelativeUrl( A245UsuariosIcono))), true);
            AssignProp("", false, imgUsuariosIcono_Internalname, "SrcSet", context.GetImageSrcSet( A245UsuariosIcono), true);
            A257UsuariosSexo = T00023_A257UsuariosSexo[0];
            AssignAttri("", false, "A257UsuariosSexo", A257UsuariosSexo);
            A68UsuariosPwd = T00023_A68UsuariosPwd[0];
            AssignAttri("", false, "A68UsuariosPwd", A68UsuariosPwd);
            A67UsuariosKey = T00023_A67UsuariosKey[0];
            AssignAttri("", false, "A67UsuariosKey", A67UsuariosKey);
            A96UsuariosVigIni = T00023_A96UsuariosVigIni[0];
            AssignAttri("", false, "A96UsuariosVigIni", context.localUtil.Format(A96UsuariosVigIni, "99/99/9999"));
            A70UsuariosVigFin = T00023_A70UsuariosVigFin[0];
            n70UsuariosVigFin = T00023_n70UsuariosVigFin[0];
            AssignAttri("", false, "A70UsuariosVigFin", context.localUtil.Format(A70UsuariosVigFin, "99/99/9999"));
            A92UsuariosFecCap = T00023_A92UsuariosFecCap[0];
            AssignAttri("", false, "A92UsuariosFecCap", context.localUtil.TToC( A92UsuariosFecCap, 10, 8, 0, 3, "/", ":", " "));
            A260UsuariosTelef = T00023_A260UsuariosTelef[0];
            AssignAttri("", false, "A260UsuariosTelef", A260UsuariosTelef);
            A261UsuariosCorreo = T00023_A261UsuariosCorreo[0];
            AssignAttri("", false, "A261UsuariosCorreo", A261UsuariosCorreo);
            A286UsuariosStatus = T00023_A286UsuariosStatus[0];
            AssignAttri("", false, "A286UsuariosStatus", StringUtil.Str( (decimal)(A286UsuariosStatus), 1, 0));
            A24RolId = T00023_A24RolId[0];
            AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
            A245UsuariosIcono = T00023_A245UsuariosIcono[0];
            AssignAttri("", false, "A245UsuariosIcono", A245UsuariosIcono);
            AssignProp("", false, imgUsuariosIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A245UsuariosIcono)) ? A40000UsuariosIcono_GXI : context.convertURL( context.PathToRelativeUrl( A245UsuariosIcono))), true);
            AssignProp("", false, imgUsuariosIcono_Internalname, "SrcSet", context.GetImageSrcSet( A245UsuariosIcono), true);
            Z11UsuariosId = A11UsuariosId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load029( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey029( ) ;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey029( ) ;
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
         GetKey029( ) ;
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
         /* Using cursor T00028 */
         pr_default.execute(6, new Object[] {n11UsuariosId, A11UsuariosId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00028_A11UsuariosId[0] < A11UsuariosId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00028_A11UsuariosId[0] > A11UsuariosId ) ) )
            {
               A11UsuariosId = T00028_A11UsuariosId[0];
               n11UsuariosId = T00028_n11UsuariosId[0];
               AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound9 = 0;
         /* Using cursor T00029 */
         pr_default.execute(7, new Object[] {n11UsuariosId, A11UsuariosId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00029_A11UsuariosId[0] > A11UsuariosId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00029_A11UsuariosId[0] < A11UsuariosId ) ) )
            {
               A11UsuariosId = T00029_A11UsuariosId[0];
               n11UsuariosId = T00029_n11UsuariosId[0];
               AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey029( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUsuariosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert029( ) ;
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
                  Update029( ) ;
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
                  Insert029( ) ;
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
                     Insert029( ) ;
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

      protected void CheckOptimisticConcurrency029( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {n11UsuariosId, A11UsuariosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Usuarios"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z244UsuariosUsr, T00022_A244UsuariosUsr[0]) != 0 ) || ( StringUtil.StrCmp(Z93UsuariosIP, T00022_A93UsuariosIP[0]) != 0 ) || ( Z255UsuariosFecNacimiento != T00022_A255UsuariosFecNacimiento[0] ) || ( Z256UsuariosEdad != T00022_A256UsuariosEdad[0] ) || ( StringUtil.StrCmp(Z105UsuariosCurp, T00022_A105UsuariosCurp[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z66UsuariosNombre, T00022_A66UsuariosNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z65UsuariosApPat, T00022_A65UsuariosApPat[0]) != 0 ) || ( StringUtil.StrCmp(Z64UsuariosApMat, T00022_A64UsuariosApMat[0]) != 0 ) || ( Z272UsuariosTipo != T00022_A272UsuariosTipo[0] ) || ( StringUtil.StrCmp(Z257UsuariosSexo, T00022_A257UsuariosSexo[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z68UsuariosPwd, T00022_A68UsuariosPwd[0]) != 0 ) || ( StringUtil.StrCmp(Z67UsuariosKey, T00022_A67UsuariosKey[0]) != 0 ) || ( Z96UsuariosVigIni != T00022_A96UsuariosVigIni[0] ) || ( Z70UsuariosVigFin != T00022_A70UsuariosVigFin[0] ) || ( Z92UsuariosFecCap != T00022_A92UsuariosFecCap[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z260UsuariosTelef, T00022_A260UsuariosTelef[0]) != 0 ) || ( StringUtil.StrCmp(Z261UsuariosCorreo, T00022_A261UsuariosCorreo[0]) != 0 ) || ( Z286UsuariosStatus != T00022_A286UsuariosStatus[0] ) || ( Z24RolId != T00022_A24RolId[0] ) )
            {
               if ( StringUtil.StrCmp(Z244UsuariosUsr, T00022_A244UsuariosUsr[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosUsr");
                  GXUtil.WriteLogRaw("Old: ",Z244UsuariosUsr);
                  GXUtil.WriteLogRaw("Current: ",T00022_A244UsuariosUsr[0]);
               }
               if ( StringUtil.StrCmp(Z93UsuariosIP, T00022_A93UsuariosIP[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosIP");
                  GXUtil.WriteLogRaw("Old: ",Z93UsuariosIP);
                  GXUtil.WriteLogRaw("Current: ",T00022_A93UsuariosIP[0]);
               }
               if ( Z255UsuariosFecNacimiento != T00022_A255UsuariosFecNacimiento[0] )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosFecNacimiento");
                  GXUtil.WriteLogRaw("Old: ",Z255UsuariosFecNacimiento);
                  GXUtil.WriteLogRaw("Current: ",T00022_A255UsuariosFecNacimiento[0]);
               }
               if ( Z256UsuariosEdad != T00022_A256UsuariosEdad[0] )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosEdad");
                  GXUtil.WriteLogRaw("Old: ",Z256UsuariosEdad);
                  GXUtil.WriteLogRaw("Current: ",T00022_A256UsuariosEdad[0]);
               }
               if ( StringUtil.StrCmp(Z105UsuariosCurp, T00022_A105UsuariosCurp[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosCurp");
                  GXUtil.WriteLogRaw("Old: ",Z105UsuariosCurp);
                  GXUtil.WriteLogRaw("Current: ",T00022_A105UsuariosCurp[0]);
               }
               if ( StringUtil.StrCmp(Z66UsuariosNombre, T00022_A66UsuariosNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosNombre");
                  GXUtil.WriteLogRaw("Old: ",Z66UsuariosNombre);
                  GXUtil.WriteLogRaw("Current: ",T00022_A66UsuariosNombre[0]);
               }
               if ( StringUtil.StrCmp(Z65UsuariosApPat, T00022_A65UsuariosApPat[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosApPat");
                  GXUtil.WriteLogRaw("Old: ",Z65UsuariosApPat);
                  GXUtil.WriteLogRaw("Current: ",T00022_A65UsuariosApPat[0]);
               }
               if ( StringUtil.StrCmp(Z64UsuariosApMat, T00022_A64UsuariosApMat[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosApMat");
                  GXUtil.WriteLogRaw("Old: ",Z64UsuariosApMat);
                  GXUtil.WriteLogRaw("Current: ",T00022_A64UsuariosApMat[0]);
               }
               if ( Z272UsuariosTipo != T00022_A272UsuariosTipo[0] )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosTipo");
                  GXUtil.WriteLogRaw("Old: ",Z272UsuariosTipo);
                  GXUtil.WriteLogRaw("Current: ",T00022_A272UsuariosTipo[0]);
               }
               if ( StringUtil.StrCmp(Z257UsuariosSexo, T00022_A257UsuariosSexo[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosSexo");
                  GXUtil.WriteLogRaw("Old: ",Z257UsuariosSexo);
                  GXUtil.WriteLogRaw("Current: ",T00022_A257UsuariosSexo[0]);
               }
               if ( StringUtil.StrCmp(Z68UsuariosPwd, T00022_A68UsuariosPwd[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosPwd");
                  GXUtil.WriteLogRaw("Old: ",Z68UsuariosPwd);
                  GXUtil.WriteLogRaw("Current: ",T00022_A68UsuariosPwd[0]);
               }
               if ( StringUtil.StrCmp(Z67UsuariosKey, T00022_A67UsuariosKey[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosKey");
                  GXUtil.WriteLogRaw("Old: ",Z67UsuariosKey);
                  GXUtil.WriteLogRaw("Current: ",T00022_A67UsuariosKey[0]);
               }
               if ( Z96UsuariosVigIni != T00022_A96UsuariosVigIni[0] )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosVigIni");
                  GXUtil.WriteLogRaw("Old: ",Z96UsuariosVigIni);
                  GXUtil.WriteLogRaw("Current: ",T00022_A96UsuariosVigIni[0]);
               }
               if ( Z70UsuariosVigFin != T00022_A70UsuariosVigFin[0] )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosVigFin");
                  GXUtil.WriteLogRaw("Old: ",Z70UsuariosVigFin);
                  GXUtil.WriteLogRaw("Current: ",T00022_A70UsuariosVigFin[0]);
               }
               if ( Z92UsuariosFecCap != T00022_A92UsuariosFecCap[0] )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosFecCap");
                  GXUtil.WriteLogRaw("Old: ",Z92UsuariosFecCap);
                  GXUtil.WriteLogRaw("Current: ",T00022_A92UsuariosFecCap[0]);
               }
               if ( StringUtil.StrCmp(Z260UsuariosTelef, T00022_A260UsuariosTelef[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosTelef");
                  GXUtil.WriteLogRaw("Old: ",Z260UsuariosTelef);
                  GXUtil.WriteLogRaw("Current: ",T00022_A260UsuariosTelef[0]);
               }
               if ( StringUtil.StrCmp(Z261UsuariosCorreo, T00022_A261UsuariosCorreo[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosCorreo");
                  GXUtil.WriteLogRaw("Old: ",Z261UsuariosCorreo);
                  GXUtil.WriteLogRaw("Current: ",T00022_A261UsuariosCorreo[0]);
               }
               if ( Z286UsuariosStatus != T00022_A286UsuariosStatus[0] )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosStatus");
                  GXUtil.WriteLogRaw("Old: ",Z286UsuariosStatus);
                  GXUtil.WriteLogRaw("Current: ",T00022_A286UsuariosStatus[0]);
               }
               if ( Z24RolId != T00022_A24RolId[0] )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"RolId");
                  GXUtil.WriteLogRaw("Old: ",Z24RolId);
                  GXUtil.WriteLogRaw("Current: ",T00022_A24RolId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Usuarios"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert029( )
      {
         BeforeValidate029( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable029( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM029( 0) ;
            CheckOptimisticConcurrency029( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm029( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert029( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000210 */
                     pr_default.execute(8, new Object[] {n11UsuariosId, A11UsuariosId, A244UsuariosUsr, A93UsuariosIP, A255UsuariosFecNacimiento, A256UsuariosEdad, A105UsuariosCurp, A66UsuariosNombre, A65UsuariosApPat, A64UsuariosApMat, A272UsuariosTipo, A245UsuariosIcono, A40000UsuariosIcono_GXI, A257UsuariosSexo, A68UsuariosPwd, A67UsuariosKey, A96UsuariosVigIni, n70UsuariosVigFin, A70UsuariosVigFin, A92UsuariosFecCap, A260UsuariosTelef, A261UsuariosCorreo, A286UsuariosStatus, A24RolId});
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
                           ResetCaption020( ) ;
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
               Load029( ) ;
            }
            EndLevel029( ) ;
         }
         CloseExtendedTableCursors029( ) ;
      }

      protected void Update029( )
      {
         BeforeValidate029( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable029( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency029( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm029( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate029( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000211 */
                     pr_default.execute(9, new Object[] {A244UsuariosUsr, A93UsuariosIP, A255UsuariosFecNacimiento, A256UsuariosEdad, A105UsuariosCurp, A66UsuariosNombre, A65UsuariosApPat, A64UsuariosApMat, A272UsuariosTipo, A257UsuariosSexo, A68UsuariosPwd, A67UsuariosKey, A96UsuariosVigIni, n70UsuariosVigFin, A70UsuariosVigFin, A92UsuariosFecCap, A260UsuariosTelef, A261UsuariosCorreo, A286UsuariosStatus, A24RolId, n11UsuariosId, A11UsuariosId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Usuarios") ;
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Usuarios"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate029( ) ;
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
            EndLevel029( ) ;
         }
         CloseExtendedTableCursors029( ) ;
      }

      protected void DeferredUpdate029( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000212 */
            pr_default.execute(10, new Object[] {A245UsuariosIcono, A40000UsuariosIcono_GXI, n11UsuariosId, A11UsuariosId});
            pr_default.close(10);
            dsDefault.SmartCacheProvider.SetUpdated("Usuarios") ;
         }
      }

      protected void delete( )
      {
         BeforeValidate029( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency029( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls029( ) ;
            AfterConfirm029( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete029( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000213 */
                  pr_default.execute(11, new Object[] {n11UsuariosId, A11UsuariosId});
                  pr_default.close(11);
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
         EndLevel029( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls029( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV60Pgmname = "Usuarios";
            AssignAttri("", false, "AV60Pgmname", AV60Pgmname);
            GXt_char2 = AV56UsuariosCurpAnt;
            new pr_recuperacurp(context ).execute(  A11UsuariosId, out  GXt_char2) ;
            AV56UsuariosCurpAnt = GXt_char2;
            AssignAttri("", false, "AV56UsuariosCurpAnt", AV56UsuariosCurpAnt);
            GXt_int3 = AV53error1;
            new pr_buscacurp(context ).execute(  A105UsuariosCurp,  AV56UsuariosCurpAnt,  Gx_mode, out  GXt_int3) ;
            AV53error1 = GXt_int3;
            AssignAttri("", false, "AV53error1", StringUtil.LTrimStr( (decimal)(AV53error1), 4, 0));
            A97UsuariosNomCompleto = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + StringUtil.Trim( A64UsuariosApMat);
            AssignAttri("", false, "A97UsuariosNomCompleto", A97UsuariosNomCompleto);
            if ( StringUtil.StrCmp(A257UsuariosSexo, "H") == 0 )
            {
               A275UsuariosSexoFor = "Hombres";
               AssignAttri("", false, "A275UsuariosSexoFor", A275UsuariosSexoFor);
            }
            else
            {
               if ( StringUtil.StrCmp(A257UsuariosSexo, "M") == 0 )
               {
                  A275UsuariosSexoFor = "Mujeres";
                  AssignAttri("", false, "A275UsuariosSexoFor", A275UsuariosSexoFor);
               }
               else
               {
                  A275UsuariosSexoFor = "";
                  AssignAttri("", false, "A275UsuariosSexoFor", A275UsuariosSexoFor);
               }
            }
            /* Using cursor T000214 */
            pr_default.execute(12, new Object[] {A24RolId});
            A127RolNombre = T000214_A127RolNombre[0];
            AssignAttri("", false, "A127RolNombre", A127RolNombre);
            pr_default.close(12);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000215 */
            pr_default.execute(13, new Object[] {n11UsuariosId, A11UsuariosId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"bitAcces"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000216 */
            pr_default.execute(14, new Object[] {n11UsuariosId, A11UsuariosId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"VacantesUsuariosVacante"+" ("+"SUBT_Reclutador"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T000217 */
            pr_default.execute(15, new Object[] {n11UsuariosId, A11UsuariosId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"VacantesUsuariosVacante"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T000218 */
            pr_default.execute(16, new Object[] {n11UsuariosId, A11UsuariosId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios Perfil"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T000219 */
            pr_default.execute(17, new Object[] {n11UsuariosId, A11UsuariosId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Intentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T000220 */
            pr_default.execute(18, new Object[] {n11UsuariosId, A11UsuariosId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Historico de Contrasenas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
         }
      }

      protected void EndLevel029( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete029( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("usuarios",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("usuarios",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart029( )
      {
         /* Scan By routine */
         /* Using cursor T000221 */
         pr_default.execute(19);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound9 = 1;
            A11UsuariosId = T000221_A11UsuariosId[0];
            n11UsuariosId = T000221_n11UsuariosId[0];
            AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext029( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound9 = 1;
            A11UsuariosId = T000221_A11UsuariosId[0];
            n11UsuariosId = T000221_n11UsuariosId[0];
            AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
         }
      }

      protected void ScanEnd029( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm029( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert029( )
      {
         /* Before Insert Rules */
         GXt_int1 = A11UsuariosId;
         new pnumerar(context ).execute(  "Usr", out  GXt_int1) ;
         A11UsuariosId = (int)(GXt_int1);
         n11UsuariosId = false;
         AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
      }

      protected void BeforeUpdate029( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete029( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete029( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate029( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes029( )
      {
         edtUsuariosId_Enabled = 0;
         AssignProp("", false, edtUsuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosId_Enabled), 5, 0), true);
         edtUsuariosCurp_Enabled = 0;
         AssignProp("", false, edtUsuariosCurp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosCurp_Enabled), 5, 0), true);
         edtUsuariosNombre_Enabled = 0;
         AssignProp("", false, edtUsuariosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosNombre_Enabled), 5, 0), true);
         edtUsuariosApPat_Enabled = 0;
         AssignProp("", false, edtUsuariosApPat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosApPat_Enabled), 5, 0), true);
         edtUsuariosApMat_Enabled = 0;
         AssignProp("", false, edtUsuariosApMat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosApMat_Enabled), 5, 0), true);
         edtUsuariosUsr_Enabled = 0;
         AssignProp("", false, edtUsuariosUsr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosUsr_Enabled), 5, 0), true);
         cmbUsuariosTipo.Enabled = 0;
         AssignProp("", false, cmbUsuariosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUsuariosTipo.Enabled), 5, 0), true);
         imgUsuariosIcono_Enabled = 0;
         AssignProp("", false, imgUsuariosIcono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgUsuariosIcono_Enabled), 5, 0), true);
         edtUsuariosFecNacimiento_Enabled = 0;
         AssignProp("", false, edtUsuariosFecNacimiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosFecNacimiento_Enabled), 5, 0), true);
         edtUsuariosEdad_Enabled = 0;
         AssignProp("", false, edtUsuariosEdad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosEdad_Enabled), 5, 0), true);
         edtUsuariosSexo_Enabled = 0;
         AssignProp("", false, edtUsuariosSexo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosSexo_Enabled), 5, 0), true);
         edtUsuariosPwd_Enabled = 0;
         AssignProp("", false, edtUsuariosPwd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosPwd_Enabled), 5, 0), true);
         edtUsuariosKey_Enabled = 0;
         AssignProp("", false, edtUsuariosKey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosKey_Enabled), 5, 0), true);
         edtUsuariosVigIni_Enabled = 0;
         AssignProp("", false, edtUsuariosVigIni_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosVigIni_Enabled), 5, 0), true);
         edtUsuariosVigFin_Enabled = 0;
         AssignProp("", false, edtUsuariosVigFin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosVigFin_Enabled), 5, 0), true);
         edtUsuariosFecCap_Enabled = 0;
         AssignProp("", false, edtUsuariosFecCap_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosFecCap_Enabled), 5, 0), true);
         edtUsuariosIP_Enabled = 0;
         AssignProp("", false, edtUsuariosIP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosIP_Enabled), 5, 0), true);
         edtUsuariosTelef_Enabled = 0;
         AssignProp("", false, edtUsuariosTelef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosTelef_Enabled), 5, 0), true);
         edtUsuariosCorreo_Enabled = 0;
         AssignProp("", false, edtUsuariosCorreo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosCorreo_Enabled), 5, 0), true);
         edtUsuariosNomCompleto_Enabled = 0;
         AssignProp("", false, edtUsuariosNomCompleto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosNomCompleto_Enabled), 5, 0), true);
         edtRolId_Enabled = 0;
         AssignProp("", false, edtRolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRolId_Enabled), 5, 0), true);
         edtRolNombre_Enabled = 0;
         AssignProp("", false, edtRolNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRolNombre_Enabled), 5, 0), true);
         edtUsuariosSexoFor_Enabled = 0;
         AssignProp("", false, edtUsuariosSexoFor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosSexoFor_Enabled), 5, 0), true);
         cmbUsuariosStatus.Enabled = 0;
         AssignProp("", false, cmbUsuariosStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUsuariosStatus.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes029( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues020( )
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
         context.AddJavascriptSource("gxcfg.js", "?202262714343571", false, true);
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "usuarios.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode("" +AV40UsuariosId);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("usuarios.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Usuarios");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("usuarios:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z11UsuariosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11UsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z244UsuariosUsr", Z244UsuariosUsr);
         GxWebStd.gx_hidden_field( context, "Z93UsuariosIP", Z93UsuariosIP);
         GxWebStd.gx_hidden_field( context, "Z255UsuariosFecNacimiento", context.localUtil.DToC( Z255UsuariosFecNacimiento, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z256UsuariosEdad", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z256UsuariosEdad), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z105UsuariosCurp", Z105UsuariosCurp);
         GxWebStd.gx_hidden_field( context, "Z66UsuariosNombre", Z66UsuariosNombre);
         GxWebStd.gx_hidden_field( context, "Z65UsuariosApPat", Z65UsuariosApPat);
         GxWebStd.gx_hidden_field( context, "Z64UsuariosApMat", Z64UsuariosApMat);
         GxWebStd.gx_hidden_field( context, "Z272UsuariosTipo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z272UsuariosTipo), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z257UsuariosSexo", StringUtil.RTrim( Z257UsuariosSexo));
         GxWebStd.gx_hidden_field( context, "Z68UsuariosPwd", Z68UsuariosPwd);
         GxWebStd.gx_hidden_field( context, "Z67UsuariosKey", Z67UsuariosKey);
         GxWebStd.gx_hidden_field( context, "Z96UsuariosVigIni", context.localUtil.DToC( Z96UsuariosVigIni, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z70UsuariosVigFin", context.localUtil.DToC( Z70UsuariosVigFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z92UsuariosFecCap", context.localUtil.TToC( Z92UsuariosFecCap, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z260UsuariosTelef", StringUtil.RTrim( Z260UsuariosTelef));
         GxWebStd.gx_hidden_field( context, "Z261UsuariosCorreo", Z261UsuariosCorreo);
         GxWebStd.gx_hidden_field( context, "Z286UsuariosStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z286UsuariosStatus), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z24RolId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z24RolId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N24RolId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A24RolId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vUSRLOG", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34UsrLog), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSRLOG", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34UsrLog), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vADSCID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7adscId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vADSCID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7adscId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCOMISION", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10comision), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCOMISION", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10comision), "ZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV32TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV32TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV32TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40UsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV40UsuariosId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_ROLID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54Insert_RolId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSCURPANT", AV56UsuariosCurpAnt);
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vERROR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV53error1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSICONO_GXI", A40000UsuariosIcono_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV60Pgmname));
         GXCCtlgxBlob = "USUARIOSICONO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A245UsuariosIcono);
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
         GXEncryptionTmp = "usuarios.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode("" +AV40UsuariosId);
         return formatLink("usuarios.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override String GetPgmname( )
      {
         return "Usuarios" ;
      }

      public override String GetPgmdesc( )
      {
         return "Alta Usuarios" ;
      }

      protected void InitializeNonKey029( )
      {
         A24RolId = 0;
         AssignAttri("", false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
         AV56UsuariosCurpAnt = "";
         AssignAttri("", false, "AV56UsuariosCurpAnt", AV56UsuariosCurpAnt);
         A244UsuariosUsr = "";
         AssignAttri("", false, "A244UsuariosUsr", A244UsuariosUsr);
         A93UsuariosIP = "";
         AssignAttri("", false, "A93UsuariosIP", A93UsuariosIP);
         A255UsuariosFecNacimiento = DateTime.MinValue;
         AssignAttri("", false, "A255UsuariosFecNacimiento", context.localUtil.Format(A255UsuariosFecNacimiento, "99/99/99"));
         A256UsuariosEdad = 0;
         AssignAttri("", false, "A256UsuariosEdad", StringUtil.LTrimStr( (decimal)(A256UsuariosEdad), 4, 0));
         A275UsuariosSexoFor = "";
         AssignAttri("", false, "A275UsuariosSexoFor", A275UsuariosSexoFor);
         A97UsuariosNomCompleto = "";
         AssignAttri("", false, "A97UsuariosNomCompleto", A97UsuariosNomCompleto);
         A105UsuariosCurp = "";
         AssignAttri("", false, "A105UsuariosCurp", A105UsuariosCurp);
         A66UsuariosNombre = "";
         AssignAttri("", false, "A66UsuariosNombre", A66UsuariosNombre);
         A65UsuariosApPat = "";
         AssignAttri("", false, "A65UsuariosApPat", A65UsuariosApPat);
         A64UsuariosApMat = "";
         AssignAttri("", false, "A64UsuariosApMat", A64UsuariosApMat);
         A272UsuariosTipo = 0;
         AssignAttri("", false, "A272UsuariosTipo", StringUtil.LTrimStr( (decimal)(A272UsuariosTipo), 4, 0));
         A245UsuariosIcono = "";
         AssignAttri("", false, "A245UsuariosIcono", A245UsuariosIcono);
         AssignProp("", false, imgUsuariosIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A245UsuariosIcono)) ? A40000UsuariosIcono_GXI : context.convertURL( context.PathToRelativeUrl( A245UsuariosIcono))), true);
         AssignProp("", false, imgUsuariosIcono_Internalname, "SrcSet", context.GetImageSrcSet( A245UsuariosIcono), true);
         A40000UsuariosIcono_GXI = "";
         AssignProp("", false, imgUsuariosIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A245UsuariosIcono)) ? A40000UsuariosIcono_GXI : context.convertURL( context.PathToRelativeUrl( A245UsuariosIcono))), true);
         AssignProp("", false, imgUsuariosIcono_Internalname, "SrcSet", context.GetImageSrcSet( A245UsuariosIcono), true);
         A68UsuariosPwd = "";
         AssignAttri("", false, "A68UsuariosPwd", A68UsuariosPwd);
         A67UsuariosKey = "";
         AssignAttri("", false, "A67UsuariosKey", A67UsuariosKey);
         A260UsuariosTelef = "";
         AssignAttri("", false, "A260UsuariosTelef", A260UsuariosTelef);
         A261UsuariosCorreo = "";
         AssignAttri("", false, "A261UsuariosCorreo", A261UsuariosCorreo);
         A127RolNombre = "";
         AssignAttri("", false, "A127RolNombre", A127RolNombre);
         A286UsuariosStatus = 0;
         AssignAttri("", false, "A286UsuariosStatus", StringUtil.Str( (decimal)(A286UsuariosStatus), 1, 0));
         AV53error1 = 0;
         AssignAttri("", false, "AV53error1", StringUtil.LTrimStr( (decimal)(AV53error1), 4, 0));
         A257UsuariosSexo = StringUtil.Substring( A105UsuariosCurp, 11, 1);
         AssignAttri("", false, "A257UsuariosSexo", A257UsuariosSexo);
         A96UsuariosVigIni = Gx_date;
         AssignAttri("", false, "A96UsuariosVigIni", context.localUtil.Format(A96UsuariosVigIni, "99/99/9999"));
         A70UsuariosVigFin = DateTimeUtil.DAdd(Gx_date,+((int)(365)));
         n70UsuariosVigFin = false;
         AssignAttri("", false, "A70UsuariosVigFin", context.localUtil.Format(A70UsuariosVigFin, "99/99/9999"));
         A92UsuariosFecCap = DateTimeUtil.ServerNow( context, pr_default);
         AssignAttri("", false, "A92UsuariosFecCap", context.localUtil.TToC( A92UsuariosFecCap, 10, 8, 0, 3, "/", ":", " "));
         Z244UsuariosUsr = "";
         Z93UsuariosIP = "";
         Z255UsuariosFecNacimiento = DateTime.MinValue;
         Z256UsuariosEdad = 0;
         Z105UsuariosCurp = "";
         Z66UsuariosNombre = "";
         Z65UsuariosApPat = "";
         Z64UsuariosApMat = "";
         Z272UsuariosTipo = 0;
         Z257UsuariosSexo = "";
         Z68UsuariosPwd = "";
         Z67UsuariosKey = "";
         Z96UsuariosVigIni = DateTime.MinValue;
         Z70UsuariosVigFin = DateTime.MinValue;
         Z92UsuariosFecCap = (DateTime)(DateTime.MinValue);
         Z260UsuariosTelef = "";
         Z261UsuariosCorreo = "";
         Z286UsuariosStatus = 0;
         Z24RolId = 0;
      }

      protected void InitAll029( )
      {
         A11UsuariosId = 0;
         n11UsuariosId = false;
         AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
         InitializeNonKey029( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A93UsuariosIP = i93UsuariosIP;
         AssignAttri("", false, "A93UsuariosIP", A93UsuariosIP);
         A96UsuariosVigIni = i96UsuariosVigIni;
         AssignAttri("", false, "A96UsuariosVigIni", context.localUtil.Format(A96UsuariosVigIni, "99/99/9999"));
         A70UsuariosVigFin = i70UsuariosVigFin;
         n70UsuariosVigFin = false;
         AssignAttri("", false, "A70UsuariosVigFin", context.localUtil.Format(A70UsuariosVigFin, "99/99/9999"));
         A92UsuariosFecCap = i92UsuariosFecCap;
         AssignAttri("", false, "A92UsuariosFecCap", context.localUtil.TToC( A92UsuariosFecCap, 10, 8, 0, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714343588", true, true);
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
         context.AddJavascriptSource("usuarios.js", "?202262714343589", false, true);
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
         edtUsuariosCurp_Internalname = "USUARIOSCURP";
         edtUsuariosNombre_Internalname = "USUARIOSNOMBRE";
         edtUsuariosApPat_Internalname = "USUARIOSAPPAT";
         edtUsuariosApMat_Internalname = "USUARIOSAPMAT";
         edtUsuariosUsr_Internalname = "USUARIOSUSR";
         cmbUsuariosTipo_Internalname = "USUARIOSTIPO";
         imgUsuariosIcono_Internalname = "USUARIOSICONO";
         edtUsuariosFecNacimiento_Internalname = "USUARIOSFECNACIMIENTO";
         edtUsuariosEdad_Internalname = "USUARIOSEDAD";
         edtUsuariosSexo_Internalname = "USUARIOSSEXO";
         edtUsuariosPwd_Internalname = "USUARIOSPWD";
         edtUsuariosKey_Internalname = "USUARIOSKEY";
         edtUsuariosVigIni_Internalname = "USUARIOSVIGINI";
         edtUsuariosVigFin_Internalname = "USUARIOSVIGFIN";
         edtUsuariosFecCap_Internalname = "USUARIOSFECCAP";
         edtUsuariosIP_Internalname = "USUARIOSIP";
         edtUsuariosTelef_Internalname = "USUARIOSTELEF";
         edtUsuariosCorreo_Internalname = "USUARIOSCORREO";
         edtUsuariosNomCompleto_Internalname = "USUARIOSNOMCOMPLETO";
         edtRolId_Internalname = "ROLID";
         edtRolNombre_Internalname = "ROLNOMBRE";
         edtUsuariosSexoFor_Internalname = "USUARIOSSEXOFOR";
         cmbUsuariosStatus_Internalname = "USUARIOSSTATUS";
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
         Form.Caption = "Alta Usuarios";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbUsuariosStatus_Jsonclick = "";
         cmbUsuariosStatus.Enabled = 1;
         edtUsuariosSexoFor_Jsonclick = "";
         edtUsuariosSexoFor_Enabled = 0;
         edtRolNombre_Jsonclick = "";
         edtRolNombre_Enabled = 0;
         edtRolId_Jsonclick = "";
         edtRolId_Enabled = 1;
         edtUsuariosNomCompleto_Jsonclick = "";
         edtUsuariosNomCompleto_Enabled = 0;
         edtUsuariosCorreo_Jsonclick = "";
         edtUsuariosCorreo_Enabled = 1;
         edtUsuariosTelef_Jsonclick = "";
         edtUsuariosTelef_Enabled = 1;
         edtUsuariosIP_Jsonclick = "";
         edtUsuariosIP_Enabled = 1;
         edtUsuariosFecCap_Jsonclick = "";
         edtUsuariosFecCap_Enabled = 1;
         edtUsuariosVigFin_Jsonclick = "";
         edtUsuariosVigFin_Enabled = 1;
         edtUsuariosVigIni_Jsonclick = "";
         edtUsuariosVigIni_Enabled = 1;
         edtUsuariosKey_Jsonclick = "";
         edtUsuariosKey_Enabled = 1;
         edtUsuariosPwd_Jsonclick = "";
         edtUsuariosPwd_Enabled = 1;
         edtUsuariosSexo_Jsonclick = "";
         edtUsuariosSexo_Enabled = 1;
         edtUsuariosEdad_Jsonclick = "";
         edtUsuariosEdad_Enabled = 1;
         edtUsuariosFecNacimiento_Jsonclick = "";
         edtUsuariosFecNacimiento_Enabled = 1;
         imgUsuariosIcono_Enabled = 1;
         cmbUsuariosTipo_Jsonclick = "";
         cmbUsuariosTipo.Enabled = 1;
         edtUsuariosUsr_Jsonclick = "";
         edtUsuariosUsr_Enabled = 1;
         edtUsuariosApMat_Jsonclick = "";
         edtUsuariosApMat_Enabled = 1;
         edtUsuariosApPat_Jsonclick = "";
         edtUsuariosApPat_Enabled = 1;
         edtUsuariosNombre_Jsonclick = "";
         edtUsuariosNombre_Enabled = 1;
         edtUsuariosCurp_Jsonclick = "";
         edtUsuariosCurp_Enabled = 1;
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

      protected void GX11ASAUSUARIOSID029( int AV40UsuariosId )
      {
         if ( ! (0==AV40UsuariosId) )
         {
            A11UsuariosId = AV40UsuariosId;
            n11UsuariosId = false;
            AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX12ASAUSUARIOSID029( String Gx_mode )
      {
         GXt_int1 = A11UsuariosId;
         new pnumerar(context ).execute(  "Usr", out  GXt_int1) ;
         A11UsuariosId = (int)(GXt_int1);
         n11UsuariosId = false;
         AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX16ASAUSUARIOSCURPANT029( int A11UsuariosId )
      {
         GXt_char2 = AV56UsuariosCurpAnt;
         new pr_recuperacurp(context ).execute(  A11UsuariosId, out  GXt_char2) ;
         AV56UsuariosCurpAnt = GXt_char2;
         AssignAttri("", false, "AV56UsuariosCurpAnt", AV56UsuariosCurpAnt);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( AV56UsuariosCurpAnt)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX19ASAUSUARIOSFECNACIMIENTO029( String A105UsuariosCurp )
      {
         GXt_date4 = A255UsuariosFecNacimiento;
         new pr_recfecha(context ).execute(  A105UsuariosCurp, out  GXt_date4) ;
         A255UsuariosFecNacimiento = GXt_date4;
         AssignAttri("", false, "A255UsuariosFecNacimiento", context.localUtil.Format(A255UsuariosFecNacimiento, "99/99/99"));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A255UsuariosFecNacimiento, "99/99/99"))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX20ASAUSUARIOSEDAD029( String A105UsuariosCurp )
      {
         GXt_int3 = A256UsuariosEdad;
         new pr_recedad(context ).execute(  A105UsuariosCurp, out  GXt_int3) ;
         A256UsuariosEdad = GXt_int3;
         AssignAttri("", false, "A256UsuariosEdad", StringUtil.LTrimStr( (decimal)(A256UsuariosEdad), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A256UsuariosEdad), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX25ASAERROR1029( String A105UsuariosCurp ,
                                       String AV56UsuariosCurpAnt ,
                                       String Gx_mode )
      {
         GXt_int3 = AV53error1;
         new pr_buscacurp(context ).execute(  A105UsuariosCurp,  AV56UsuariosCurpAnt,  Gx_mode, out  GXt_int3) ;
         AV53error1 = GXt_int3;
         AssignAttri("", false, "AV53error1", StringUtil.LTrimStr( (decimal)(AV53error1), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV53error1), 4, 0, ".", "")))+"\"") ;
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
         cmbUsuariosTipo.Name = "USUARIOSTIPO";
         cmbUsuariosTipo.WebTags = "";
         cmbUsuariosTipo.addItem("1", "Administrador", 0);
         cmbUsuariosTipo.addItem("6", "Postulantes", 0);
         cmbUsuariosTipo.addItem("4", "Operaciones", 0);
         cmbUsuariosTipo.addItem("2", "Coordinador RYS", 0);
         cmbUsuariosTipo.addItem("5", "Reclutador", 0);
         cmbUsuariosTipo.addItem("3", "Candidatos", 0);
         if ( cmbUsuariosTipo.ItemCount > 0 )
         {
            A272UsuariosTipo = (short)(NumberUtil.Val( cmbUsuariosTipo.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A272UsuariosTipo), 4, 0))), "."));
            AssignAttri("", false, "A272UsuariosTipo", StringUtil.LTrimStr( (decimal)(A272UsuariosTipo), 4, 0));
         }
         cmbUsuariosStatus.Name = "USUARIOSSTATUS";
         cmbUsuariosStatus.WebTags = "";
         cmbUsuariosStatus.addItem("1", "Activo", 0);
         cmbUsuariosStatus.addItem("0", "Inactivo", 0);
         if ( cmbUsuariosStatus.ItemCount > 0 )
         {
            A286UsuariosStatus = (short)(NumberUtil.Val( cmbUsuariosStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A286UsuariosStatus), 1, 0))), "."));
            AssignAttri("", false, "A286UsuariosStatus", StringUtil.Str( (decimal)(A286UsuariosStatus), 1, 0));
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
         n11UsuariosId = false;
         GXt_char2 = AV56UsuariosCurpAnt;
         new pr_recuperacurp(context ).execute(  A11UsuariosId, out  GXt_char2) ;
         AV56UsuariosCurpAnt = GXt_char2;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "AV56UsuariosCurpAnt", AV56UsuariosCurpAnt);
      }

      public void Valid_Usuarioscurp( )
      {
         A244UsuariosUsr = A105UsuariosCurp;
         GXt_date4 = A255UsuariosFecNacimiento;
         new pr_recfecha(context ).execute(  A105UsuariosCurp, out  GXt_date4) ;
         A255UsuariosFecNacimiento = GXt_date4;
         GXt_int3 = A256UsuariosEdad;
         new pr_recedad(context ).execute(  A105UsuariosCurp, out  GXt_int3) ;
         A256UsuariosEdad = GXt_int3;
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A257UsuariosSexo)) && ( Gx_BScreen == 0 ) )
         {
            A257UsuariosSexo = StringUtil.Substring( A105UsuariosCurp, 11, 1);
         }
         GXt_int3 = AV53error1;
         new pr_buscacurp(context ).execute(  A105UsuariosCurp,  AV56UsuariosCurpAnt,  Gx_mode, out  GXt_int3) ;
         AV53error1 = GXt_int3;
         if ( AV53error1 == 1 )
         {
            GX_msglist.addItem("Ya existe la CURP ingresada.  Favor de verificar. !", 1, "USUARIOSCURP");
            AnyError = 1;
            GX_FocusControl = edtUsuariosCurp_Internalname;
         }
         if ( ! (GxRegex.IsMatch(A105UsuariosCurp,"\\b[A-Z]{4}[0-9]{6}[A-Z]{6}[0-Z]{2}\\b")) )
         {
            GX_msglist.addItem("CURP incorrecta,  Favor de verificar!", 1, "USUARIOSCURP");
            AnyError = 1;
            GX_FocusControl = edtUsuariosCurp_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A244UsuariosUsr", A244UsuariosUsr);
         AssignAttri("", false, "A255UsuariosFecNacimiento", context.localUtil.Format(A255UsuariosFecNacimiento, "99/99/99"));
         AssignAttri("", false, "A256UsuariosEdad", StringUtil.LTrim( StringUtil.NToC( (decimal)(A256UsuariosEdad), 4, 0, ".", "")));
         AssignAttri("", false, "A257UsuariosSexo", StringUtil.RTrim( A257UsuariosSexo));
         AssignAttri("", false, "AV53error1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV53error1), 4, 0, ".", "")));
      }

      public void Valid_Rolid( )
      {
         /* Using cursor T000214 */
         pr_default.execute(12, new Object[] {A24RolId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Roles'.", "ForeignKeyNotFound", 1, "ROLID");
            AnyError = 1;
            GX_FocusControl = edtRolId_Internalname;
         }
         A127RolNombre = T000214_A127RolNombre[0];
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A127RolNombre", A127RolNombre);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV40UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV34UsrLog',fld:'vUSRLOG',pic:'ZZZZZ9',hsh:true},{av:'AV7adscId',fld:'vADSCID',pic:'ZZZZZ9',hsh:true},{av:'AV10comision',fld:'vCOMISION',pic:'ZZZZZ9',hsh:true},{av:'AV32TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV40UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12022',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A68UsuariosPwd',fld:'USUARIOSPWD',pic:''},{av:'A244UsuariosUsr',fld:'USUARIOSUSR',pic:''},{av:'AV34UsrLog',fld:'vUSRLOG',pic:'ZZZZZ9',hsh:true},{av:'AV7adscId',fld:'vADSCID',pic:'ZZZZZ9',hsh:true},{av:'AV10comision',fld:'vCOMISION',pic:'ZZZZZ9',hsh:true},{av:'AV32TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSID","{handler:'Valid_Usuariosid',iparms:[{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV56UsuariosCurpAnt',fld:'vUSUARIOSCURPANT',pic:'@!'}]");
         setEventMetadata("VALID_USUARIOSID",",oparms:[{av:'AV56UsuariosCurpAnt',fld:'vUSUARIOSCURPANT',pic:'@!'}]}");
         setEventMetadata("VALID_USUARIOSCURP","{handler:'Valid_Usuarioscurp',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A105UsuariosCurp',fld:'USUARIOSCURP',pic:'@!'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'AV56UsuariosCurpAnt',fld:'vUSUARIOSCURPANT',pic:'@!'},{av:'AV53error1',fld:'vERROR1',pic:'ZZZ9'},{av:'A244UsuariosUsr',fld:'USUARIOSUSR',pic:''},{av:'A255UsuariosFecNacimiento',fld:'USUARIOSFECNACIMIENTO',pic:''},{av:'A256UsuariosEdad',fld:'USUARIOSEDAD',pic:'ZZZ9'},{av:'A257UsuariosSexo',fld:'USUARIOSSEXO',pic:''}]");
         setEventMetadata("VALID_USUARIOSCURP",",oparms:[{av:'A244UsuariosUsr',fld:'USUARIOSUSR',pic:''},{av:'A255UsuariosFecNacimiento',fld:'USUARIOSFECNACIMIENTO',pic:''},{av:'A256UsuariosEdad',fld:'USUARIOSEDAD',pic:'ZZZ9'},{av:'A257UsuariosSexo',fld:'USUARIOSSEXO',pic:''},{av:'AV53error1',fld:'vERROR1',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_USUARIOSNOMBRE","{handler:'Valid_Usuariosnombre',iparms:[]");
         setEventMetadata("VALID_USUARIOSNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSAPPAT","{handler:'Valid_Usuariosappat',iparms:[]");
         setEventMetadata("VALID_USUARIOSAPPAT",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSAPMAT","{handler:'Valid_Usuariosapmat',iparms:[]");
         setEventMetadata("VALID_USUARIOSAPMAT",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSTIPO","{handler:'Valid_Usuariostipo',iparms:[]");
         setEventMetadata("VALID_USUARIOSTIPO",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSFECNACIMIENTO","{handler:'Valid_Usuariosfecnacimiento',iparms:[]");
         setEventMetadata("VALID_USUARIOSFECNACIMIENTO",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSSEXO","{handler:'Valid_Usuariossexo',iparms:[]");
         setEventMetadata("VALID_USUARIOSSEXO",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSVIGINI","{handler:'Valid_Usuariosvigini',iparms:[]");
         setEventMetadata("VALID_USUARIOSVIGINI",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSVIGFIN","{handler:'Valid_Usuariosvigfin',iparms:[]");
         setEventMetadata("VALID_USUARIOSVIGFIN",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSFECCAP","{handler:'Valid_Usuariosfeccap',iparms:[]");
         setEventMetadata("VALID_USUARIOSFECCAP",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSTELEF","{handler:'Valid_Usuariostelef',iparms:[]");
         setEventMetadata("VALID_USUARIOSTELEF",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSCORREO","{handler:'Valid_Usuarioscorreo',iparms:[]");
         setEventMetadata("VALID_USUARIOSCORREO",",oparms:[]}");
         setEventMetadata("VALID_ROLID","{handler:'Valid_Rolid',iparms:[{av:'A24RolId',fld:'ROLID',pic:'ZZZZZZZZ9'},{av:'A127RolNombre',fld:'ROLNOMBRE',pic:''}]");
         setEventMetadata("VALID_ROLID",",oparms:[{av:'A127RolNombre',fld:'ROLNOMBRE',pic:''}]}");
         setEventMetadata("VALID_USUARIOSSTATUS","{handler:'Valid_Usuariosstatus',iparms:[]");
         setEventMetadata("VALID_USUARIOSSTATUS",",oparms:[]}");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z244UsuariosUsr = "";
         Z93UsuariosIP = "";
         Z255UsuariosFecNacimiento = DateTime.MinValue;
         Z105UsuariosCurp = "";
         Z66UsuariosNombre = "";
         Z65UsuariosApPat = "";
         Z64UsuariosApMat = "";
         Z257UsuariosSexo = "";
         Z68UsuariosPwd = "";
         Z67UsuariosKey = "";
         Z96UsuariosVigIni = DateTime.MinValue;
         Z70UsuariosVigFin = DateTime.MinValue;
         Z92UsuariosFecCap = (DateTime)(DateTime.MinValue);
         Z260UsuariosTelef = "";
         Z261UsuariosCorreo = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A105UsuariosCurp = "";
         AV56UsuariosCurpAnt = "";
         GXKey = "";
         GXDecQS = "";
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
         A66UsuariosNombre = "";
         A65UsuariosApPat = "";
         A64UsuariosApMat = "";
         A244UsuariosUsr = "";
         A245UsuariosIcono = "";
         A40000UsuariosIcono_GXI = "";
         sImgUrl = "";
         A255UsuariosFecNacimiento = DateTime.MinValue;
         A257UsuariosSexo = "";
         A68UsuariosPwd = "";
         A67UsuariosKey = "";
         A96UsuariosVigIni = DateTime.MinValue;
         A70UsuariosVigFin = DateTime.MinValue;
         A92UsuariosFecCap = (DateTime)(DateTime.MinValue);
         A93UsuariosIP = "";
         A260UsuariosTelef = "";
         A261UsuariosCorreo = "";
         A97UsuariosNomCompleto = "";
         A127RolNombre = "";
         A275UsuariosSexoFor = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_date = DateTime.MinValue;
         AV60Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode9 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV35usuario = "";
         AV30Sesion = context.GetSession();
         AV32TrnContext = new SdtTransactionContext(context);
         AV46WebSession = context.GetSession();
         AV33TrnContextAtt = new SdtTransactionContext_Attribute(context);
         Z245UsuariosIcono = "";
         Z40000UsuariosIcono_GXI = "";
         Z127RolNombre = "";
         T00024_A127RolNombre = new String[] {""} ;
         T00025_A11UsuariosId = new int[1] ;
         T00025_n11UsuariosId = new bool[] {false} ;
         T00025_A244UsuariosUsr = new String[] {""} ;
         T00025_A93UsuariosIP = new String[] {""} ;
         T00025_A255UsuariosFecNacimiento = new DateTime[] {DateTime.MinValue} ;
         T00025_A256UsuariosEdad = new short[1] ;
         T00025_A105UsuariosCurp = new String[] {""} ;
         T00025_A66UsuariosNombre = new String[] {""} ;
         T00025_A65UsuariosApPat = new String[] {""} ;
         T00025_A64UsuariosApMat = new String[] {""} ;
         T00025_A272UsuariosTipo = new short[1] ;
         T00025_A40000UsuariosIcono_GXI = new String[] {""} ;
         T00025_A257UsuariosSexo = new String[] {""} ;
         T00025_A68UsuariosPwd = new String[] {""} ;
         T00025_A67UsuariosKey = new String[] {""} ;
         T00025_A96UsuariosVigIni = new DateTime[] {DateTime.MinValue} ;
         T00025_A70UsuariosVigFin = new DateTime[] {DateTime.MinValue} ;
         T00025_n70UsuariosVigFin = new bool[] {false} ;
         T00025_A92UsuariosFecCap = new DateTime[] {DateTime.MinValue} ;
         T00025_A260UsuariosTelef = new String[] {""} ;
         T00025_A261UsuariosCorreo = new String[] {""} ;
         T00025_A127RolNombre = new String[] {""} ;
         T00025_A286UsuariosStatus = new short[1] ;
         T00025_A24RolId = new int[1] ;
         T00025_A245UsuariosIcono = new String[] {""} ;
         T00026_A127RolNombre = new String[] {""} ;
         T00027_A11UsuariosId = new int[1] ;
         T00027_n11UsuariosId = new bool[] {false} ;
         T00023_A11UsuariosId = new int[1] ;
         T00023_n11UsuariosId = new bool[] {false} ;
         T00023_A244UsuariosUsr = new String[] {""} ;
         T00023_A93UsuariosIP = new String[] {""} ;
         T00023_A255UsuariosFecNacimiento = new DateTime[] {DateTime.MinValue} ;
         T00023_A256UsuariosEdad = new short[1] ;
         T00023_A105UsuariosCurp = new String[] {""} ;
         T00023_A66UsuariosNombre = new String[] {""} ;
         T00023_A65UsuariosApPat = new String[] {""} ;
         T00023_A64UsuariosApMat = new String[] {""} ;
         T00023_A272UsuariosTipo = new short[1] ;
         T00023_A40000UsuariosIcono_GXI = new String[] {""} ;
         T00023_A257UsuariosSexo = new String[] {""} ;
         T00023_A68UsuariosPwd = new String[] {""} ;
         T00023_A67UsuariosKey = new String[] {""} ;
         T00023_A96UsuariosVigIni = new DateTime[] {DateTime.MinValue} ;
         T00023_A70UsuariosVigFin = new DateTime[] {DateTime.MinValue} ;
         T00023_n70UsuariosVigFin = new bool[] {false} ;
         T00023_A92UsuariosFecCap = new DateTime[] {DateTime.MinValue} ;
         T00023_A260UsuariosTelef = new String[] {""} ;
         T00023_A261UsuariosCorreo = new String[] {""} ;
         T00023_A286UsuariosStatus = new short[1] ;
         T00023_A24RolId = new int[1] ;
         T00023_A245UsuariosIcono = new String[] {""} ;
         T00028_A11UsuariosId = new int[1] ;
         T00028_n11UsuariosId = new bool[] {false} ;
         T00029_A11UsuariosId = new int[1] ;
         T00029_n11UsuariosId = new bool[] {false} ;
         T00022_A11UsuariosId = new int[1] ;
         T00022_n11UsuariosId = new bool[] {false} ;
         T00022_A244UsuariosUsr = new String[] {""} ;
         T00022_A93UsuariosIP = new String[] {""} ;
         T00022_A255UsuariosFecNacimiento = new DateTime[] {DateTime.MinValue} ;
         T00022_A256UsuariosEdad = new short[1] ;
         T00022_A105UsuariosCurp = new String[] {""} ;
         T00022_A66UsuariosNombre = new String[] {""} ;
         T00022_A65UsuariosApPat = new String[] {""} ;
         T00022_A64UsuariosApMat = new String[] {""} ;
         T00022_A272UsuariosTipo = new short[1] ;
         T00022_A40000UsuariosIcono_GXI = new String[] {""} ;
         T00022_A257UsuariosSexo = new String[] {""} ;
         T00022_A68UsuariosPwd = new String[] {""} ;
         T00022_A67UsuariosKey = new String[] {""} ;
         T00022_A96UsuariosVigIni = new DateTime[] {DateTime.MinValue} ;
         T00022_A70UsuariosVigFin = new DateTime[] {DateTime.MinValue} ;
         T00022_n70UsuariosVigFin = new bool[] {false} ;
         T00022_A92UsuariosFecCap = new DateTime[] {DateTime.MinValue} ;
         T00022_A260UsuariosTelef = new String[] {""} ;
         T00022_A261UsuariosCorreo = new String[] {""} ;
         T00022_A286UsuariosStatus = new short[1] ;
         T00022_A24RolId = new int[1] ;
         T00022_A245UsuariosIcono = new String[] {""} ;
         T000214_A127RolNombre = new String[] {""} ;
         T000215_A61bitAccesFec = new DateTime[] {DateTime.MinValue} ;
         T000215_A75bitAccesIp = new String[] {""} ;
         T000216_A263Vacantes_Id = new int[1] ;
         T000216_A11UsuariosId = new int[1] ;
         T000216_n11UsuariosId = new bool[] {false} ;
         T000217_A263Vacantes_Id = new int[1] ;
         T000217_A11UsuariosId = new int[1] ;
         T000217_n11UsuariosId = new bool[] {false} ;
         T000218_A278Perfiles_Id = new int[1] ;
         T000218_A11UsuariosId = new int[1] ;
         T000218_n11UsuariosId = new bool[] {false} ;
         T000219_A11UsuariosId = new int[1] ;
         T000219_n11UsuariosId = new bool[] {false} ;
         T000219_A30FechaIntento = new DateTime[] {DateTime.MinValue} ;
         T000220_A11UsuariosId = new int[1] ;
         T000220_n11UsuariosId = new bool[] {false} ;
         T000220_A62HisPwdFecha = new DateTime[] {DateTime.MinValue} ;
         T000221_A11UsuariosId = new int[1] ;
         T000221_n11UsuariosId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXCCtlgxBlob = "";
         i93UsuariosIP = "";
         i96UsuariosVigIni = DateTime.MinValue;
         i70UsuariosVigFin = DateTime.MinValue;
         i92UsuariosFecCap = (DateTime)(DateTime.MinValue);
         GXt_char2 = "";
         ZV56UsuariosCurpAnt = "";
         GXt_date4 = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usuarios__default(),
            new Object[][] {
                new Object[] {
               T00022_A11UsuariosId, T00022_A244UsuariosUsr, T00022_A93UsuariosIP, T00022_A255UsuariosFecNacimiento, T00022_A256UsuariosEdad, T00022_A105UsuariosCurp, T00022_A66UsuariosNombre, T00022_A65UsuariosApPat, T00022_A64UsuariosApMat, T00022_A272UsuariosTipo,
               T00022_A40000UsuariosIcono_GXI, T00022_A257UsuariosSexo, T00022_A68UsuariosPwd, T00022_A67UsuariosKey, T00022_A96UsuariosVigIni, T00022_A70UsuariosVigFin, T00022_n70UsuariosVigFin, T00022_A92UsuariosFecCap, T00022_A260UsuariosTelef, T00022_A261UsuariosCorreo,
               T00022_A286UsuariosStatus, T00022_A24RolId, T00022_A245UsuariosIcono
               }
               , new Object[] {
               T00023_A11UsuariosId, T00023_A244UsuariosUsr, T00023_A93UsuariosIP, T00023_A255UsuariosFecNacimiento, T00023_A256UsuariosEdad, T00023_A105UsuariosCurp, T00023_A66UsuariosNombre, T00023_A65UsuariosApPat, T00023_A64UsuariosApMat, T00023_A272UsuariosTipo,
               T00023_A40000UsuariosIcono_GXI, T00023_A257UsuariosSexo, T00023_A68UsuariosPwd, T00023_A67UsuariosKey, T00023_A96UsuariosVigIni, T00023_A70UsuariosVigFin, T00023_n70UsuariosVigFin, T00023_A92UsuariosFecCap, T00023_A260UsuariosTelef, T00023_A261UsuariosCorreo,
               T00023_A286UsuariosStatus, T00023_A24RolId, T00023_A245UsuariosIcono
               }
               , new Object[] {
               T00024_A127RolNombre
               }
               , new Object[] {
               T00025_A11UsuariosId, T00025_A244UsuariosUsr, T00025_A93UsuariosIP, T00025_A255UsuariosFecNacimiento, T00025_A256UsuariosEdad, T00025_A105UsuariosCurp, T00025_A66UsuariosNombre, T00025_A65UsuariosApPat, T00025_A64UsuariosApMat, T00025_A272UsuariosTipo,
               T00025_A40000UsuariosIcono_GXI, T00025_A257UsuariosSexo, T00025_A68UsuariosPwd, T00025_A67UsuariosKey, T00025_A96UsuariosVigIni, T00025_A70UsuariosVigFin, T00025_n70UsuariosVigFin, T00025_A92UsuariosFecCap, T00025_A260UsuariosTelef, T00025_A261UsuariosCorreo,
               T00025_A127RolNombre, T00025_A286UsuariosStatus, T00025_A24RolId, T00025_A245UsuariosIcono
               }
               , new Object[] {
               T00026_A127RolNombre
               }
               , new Object[] {
               T00027_A11UsuariosId
               }
               , new Object[] {
               T00028_A11UsuariosId
               }
               , new Object[] {
               T00029_A11UsuariosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000214_A127RolNombre
               }
               , new Object[] {
               T000215_A61bitAccesFec, T000215_A75bitAccesIp
               }
               , new Object[] {
               T000216_A263Vacantes_Id, T000216_A11UsuariosId
               }
               , new Object[] {
               T000217_A263Vacantes_Id, T000217_A11UsuariosId
               }
               , new Object[] {
               T000218_A278Perfiles_Id, T000218_A11UsuariosId
               }
               , new Object[] {
               T000219_A11UsuariosId, T000219_A30FechaIntento
               }
               , new Object[] {
               T000220_A11UsuariosId, T000220_A62HisPwdFecha
               }
               , new Object[] {
               T000221_A11UsuariosId
               }
            }
         );
         AV60Pgmname = "Usuarios";
         Z257UsuariosSexo = "";
         A257UsuariosSexo = "";
         Z92UsuariosFecCap = DateTimeUtil.ServerNow( context, pr_default);
         A92UsuariosFecCap = DateTimeUtil.ServerNow( context, pr_default);
         i92UsuariosFecCap = DateTimeUtil.ServerNow( context, pr_default);
         Z70UsuariosVigFin = DateTime.MinValue;
         n70UsuariosVigFin = false;
         A70UsuariosVigFin = DateTime.MinValue;
         n70UsuariosVigFin = false;
         i70UsuariosVigFin = DateTime.MinValue;
         n70UsuariosVigFin = false;
         Z96UsuariosVigIni = DateTime.MinValue;
         A96UsuariosVigIni = DateTime.MinValue;
         i96UsuariosVigIni = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short Z256UsuariosEdad ;
      private short Z272UsuariosTipo ;
      private short Z286UsuariosStatus ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A272UsuariosTipo ;
      private short A286UsuariosStatus ;
      private short A256UsuariosEdad ;
      private short Gx_BScreen ;
      private short AV53error1 ;
      private short RcdFound9 ;
      private short GX_JID ;
      private short nIsDirty_9 ;
      private short gxajaxcallmode ;
      private short GXt_int3 ;
      private short ZV53error1 ;
      private int wcpOAV40UsuariosId ;
      private int Z11UsuariosId ;
      private int Z24RolId ;
      private int N24RolId ;
      private int AV40UsuariosId ;
      private int A11UsuariosId ;
      private int A24RolId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtUsuariosId_Enabled ;
      private int edtUsuariosCurp_Enabled ;
      private int edtUsuariosNombre_Enabled ;
      private int edtUsuariosApPat_Enabled ;
      private int edtUsuariosApMat_Enabled ;
      private int edtUsuariosUsr_Enabled ;
      private int imgUsuariosIcono_Enabled ;
      private int edtUsuariosFecNacimiento_Enabled ;
      private int edtUsuariosEdad_Enabled ;
      private int edtUsuariosSexo_Enabled ;
      private int edtUsuariosPwd_Enabled ;
      private int edtUsuariosKey_Enabled ;
      private int edtUsuariosVigIni_Enabled ;
      private int edtUsuariosVigFin_Enabled ;
      private int edtUsuariosFecCap_Enabled ;
      private int edtUsuariosIP_Enabled ;
      private int edtUsuariosTelef_Enabled ;
      private int edtUsuariosCorreo_Enabled ;
      private int edtUsuariosNomCompleto_Enabled ;
      private int edtRolId_Enabled ;
      private int edtRolNombre_Enabled ;
      private int edtUsuariosSexoFor_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV54Insert_RolId ;
      private int AV34UsrLog ;
      private int AV61GXV1 ;
      private int AV62GXV2 ;
      private int AV7adscId ;
      private int AV10comision ;
      private int AV29SecRnd ;
      private int idxLst ;
      private long GXt_int1 ;
      private String sPrefix ;
      private String wcpOGx_mode ;
      private String Z257UsuariosSexo ;
      private String Z260UsuariosTelef ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String Gx_mode ;
      private String GXKey ;
      private String GXDecQS ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String GX_FocusControl ;
      private String edtUsuariosId_Internalname ;
      private String cmbUsuariosTipo_Internalname ;
      private String cmbUsuariosStatus_Internalname ;
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
      private String edtUsuariosCurp_Internalname ;
      private String edtUsuariosCurp_Jsonclick ;
      private String edtUsuariosNombre_Internalname ;
      private String edtUsuariosNombre_Jsonclick ;
      private String edtUsuariosApPat_Internalname ;
      private String edtUsuariosApPat_Jsonclick ;
      private String edtUsuariosApMat_Internalname ;
      private String edtUsuariosApMat_Jsonclick ;
      private String edtUsuariosUsr_Internalname ;
      private String edtUsuariosUsr_Jsonclick ;
      private String cmbUsuariosTipo_Jsonclick ;
      private String imgUsuariosIcono_Internalname ;
      private String sImgUrl ;
      private String edtUsuariosFecNacimiento_Internalname ;
      private String edtUsuariosFecNacimiento_Jsonclick ;
      private String edtUsuariosEdad_Internalname ;
      private String edtUsuariosEdad_Jsonclick ;
      private String edtUsuariosSexo_Internalname ;
      private String A257UsuariosSexo ;
      private String edtUsuariosSexo_Jsonclick ;
      private String edtUsuariosPwd_Internalname ;
      private String edtUsuariosPwd_Jsonclick ;
      private String edtUsuariosKey_Internalname ;
      private String edtUsuariosKey_Jsonclick ;
      private String edtUsuariosVigIni_Internalname ;
      private String edtUsuariosVigIni_Jsonclick ;
      private String edtUsuariosVigFin_Internalname ;
      private String edtUsuariosVigFin_Jsonclick ;
      private String edtUsuariosFecCap_Internalname ;
      private String edtUsuariosFecCap_Jsonclick ;
      private String edtUsuariosIP_Internalname ;
      private String edtUsuariosIP_Jsonclick ;
      private String edtUsuariosTelef_Internalname ;
      private String A260UsuariosTelef ;
      private String edtUsuariosTelef_Jsonclick ;
      private String edtUsuariosCorreo_Internalname ;
      private String edtUsuariosCorreo_Jsonclick ;
      private String edtUsuariosNomCompleto_Internalname ;
      private String edtUsuariosNomCompleto_Jsonclick ;
      private String edtRolId_Internalname ;
      private String edtRolId_Jsonclick ;
      private String edtRolNombre_Internalname ;
      private String edtRolNombre_Jsonclick ;
      private String edtUsuariosSexoFor_Internalname ;
      private String A275UsuariosSexoFor ;
      private String edtUsuariosSexoFor_Jsonclick ;
      private String cmbUsuariosStatus_Jsonclick ;
      private String bttBtn_enter_Internalname ;
      private String bttBtn_enter_Jsonclick ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String bttBtn_delete_Internalname ;
      private String bttBtn_delete_Jsonclick ;
      private String AV60Pgmname ;
      private String hsh ;
      private String sMode9 ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String endTrnMsgTxt ;
      private String endTrnMsgCod ;
      private String AV35usuario ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXEncryptionTmp ;
      private String GXCCtlgxBlob ;
      private String GXt_char2 ;
      private DateTime Z92UsuariosFecCap ;
      private DateTime A92UsuariosFecCap ;
      private DateTime i92UsuariosFecCap ;
      private DateTime Z255UsuariosFecNacimiento ;
      private DateTime Z96UsuariosVigIni ;
      private DateTime Z70UsuariosVigFin ;
      private DateTime A255UsuariosFecNacimiento ;
      private DateTime A96UsuariosVigIni ;
      private DateTime A70UsuariosVigFin ;
      private DateTime Gx_date ;
      private DateTime i96UsuariosVigIni ;
      private DateTime i70UsuariosVigFin ;
      private DateTime GXt_date4 ;
      private bool entryPointCalled ;
      private bool n11UsuariosId ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A245UsuariosIcono_IsBlob ;
      private bool n70UsuariosVigFin ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private String Z244UsuariosUsr ;
      private String Z93UsuariosIP ;
      private String Z105UsuariosCurp ;
      private String Z66UsuariosNombre ;
      private String Z65UsuariosApPat ;
      private String Z64UsuariosApMat ;
      private String Z68UsuariosPwd ;
      private String Z67UsuariosKey ;
      private String Z261UsuariosCorreo ;
      private String A105UsuariosCurp ;
      private String AV56UsuariosCurpAnt ;
      private String A66UsuariosNombre ;
      private String A65UsuariosApPat ;
      private String A64UsuariosApMat ;
      private String A244UsuariosUsr ;
      private String A40000UsuariosIcono_GXI ;
      private String A68UsuariosPwd ;
      private String A67UsuariosKey ;
      private String A93UsuariosIP ;
      private String A261UsuariosCorreo ;
      private String A97UsuariosNomCompleto ;
      private String A127RolNombre ;
      private String Z40000UsuariosIcono_GXI ;
      private String Z127RolNombre ;
      private String i93UsuariosIP ;
      private String ZV56UsuariosCurpAnt ;
      private String A245UsuariosIcono ;
      private String Z245UsuariosIcono ;
      private IGxSession AV30Sesion ;
      private IGxSession AV46WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbUsuariosTipo ;
      private GXCombobox cmbUsuariosStatus ;
      private IDataStoreProvider pr_default ;
      private String[] T00024_A127RolNombre ;
      private int[] T00025_A11UsuariosId ;
      private bool[] T00025_n11UsuariosId ;
      private String[] T00025_A244UsuariosUsr ;
      private String[] T00025_A93UsuariosIP ;
      private DateTime[] T00025_A255UsuariosFecNacimiento ;
      private short[] T00025_A256UsuariosEdad ;
      private String[] T00025_A105UsuariosCurp ;
      private String[] T00025_A66UsuariosNombre ;
      private String[] T00025_A65UsuariosApPat ;
      private String[] T00025_A64UsuariosApMat ;
      private short[] T00025_A272UsuariosTipo ;
      private String[] T00025_A40000UsuariosIcono_GXI ;
      private String[] T00025_A257UsuariosSexo ;
      private String[] T00025_A68UsuariosPwd ;
      private String[] T00025_A67UsuariosKey ;
      private DateTime[] T00025_A96UsuariosVigIni ;
      private DateTime[] T00025_A70UsuariosVigFin ;
      private bool[] T00025_n70UsuariosVigFin ;
      private DateTime[] T00025_A92UsuariosFecCap ;
      private String[] T00025_A260UsuariosTelef ;
      private String[] T00025_A261UsuariosCorreo ;
      private String[] T00025_A127RolNombre ;
      private short[] T00025_A286UsuariosStatus ;
      private int[] T00025_A24RolId ;
      private String[] T00025_A245UsuariosIcono ;
      private String[] T00026_A127RolNombre ;
      private int[] T00027_A11UsuariosId ;
      private bool[] T00027_n11UsuariosId ;
      private int[] T00023_A11UsuariosId ;
      private bool[] T00023_n11UsuariosId ;
      private String[] T00023_A244UsuariosUsr ;
      private String[] T00023_A93UsuariosIP ;
      private DateTime[] T00023_A255UsuariosFecNacimiento ;
      private short[] T00023_A256UsuariosEdad ;
      private String[] T00023_A105UsuariosCurp ;
      private String[] T00023_A66UsuariosNombre ;
      private String[] T00023_A65UsuariosApPat ;
      private String[] T00023_A64UsuariosApMat ;
      private short[] T00023_A272UsuariosTipo ;
      private String[] T00023_A40000UsuariosIcono_GXI ;
      private String[] T00023_A257UsuariosSexo ;
      private String[] T00023_A68UsuariosPwd ;
      private String[] T00023_A67UsuariosKey ;
      private DateTime[] T00023_A96UsuariosVigIni ;
      private DateTime[] T00023_A70UsuariosVigFin ;
      private bool[] T00023_n70UsuariosVigFin ;
      private DateTime[] T00023_A92UsuariosFecCap ;
      private String[] T00023_A260UsuariosTelef ;
      private String[] T00023_A261UsuariosCorreo ;
      private short[] T00023_A286UsuariosStatus ;
      private int[] T00023_A24RolId ;
      private String[] T00023_A245UsuariosIcono ;
      private int[] T00028_A11UsuariosId ;
      private bool[] T00028_n11UsuariosId ;
      private int[] T00029_A11UsuariosId ;
      private bool[] T00029_n11UsuariosId ;
      private int[] T00022_A11UsuariosId ;
      private bool[] T00022_n11UsuariosId ;
      private String[] T00022_A244UsuariosUsr ;
      private String[] T00022_A93UsuariosIP ;
      private DateTime[] T00022_A255UsuariosFecNacimiento ;
      private short[] T00022_A256UsuariosEdad ;
      private String[] T00022_A105UsuariosCurp ;
      private String[] T00022_A66UsuariosNombre ;
      private String[] T00022_A65UsuariosApPat ;
      private String[] T00022_A64UsuariosApMat ;
      private short[] T00022_A272UsuariosTipo ;
      private String[] T00022_A40000UsuariosIcono_GXI ;
      private String[] T00022_A257UsuariosSexo ;
      private String[] T00022_A68UsuariosPwd ;
      private String[] T00022_A67UsuariosKey ;
      private DateTime[] T00022_A96UsuariosVigIni ;
      private DateTime[] T00022_A70UsuariosVigFin ;
      private bool[] T00022_n70UsuariosVigFin ;
      private DateTime[] T00022_A92UsuariosFecCap ;
      private String[] T00022_A260UsuariosTelef ;
      private String[] T00022_A261UsuariosCorreo ;
      private short[] T00022_A286UsuariosStatus ;
      private int[] T00022_A24RolId ;
      private String[] T00022_A245UsuariosIcono ;
      private String[] T000214_A127RolNombre ;
      private DateTime[] T000215_A61bitAccesFec ;
      private String[] T000215_A75bitAccesIp ;
      private int[] T000216_A263Vacantes_Id ;
      private int[] T000216_A11UsuariosId ;
      private bool[] T000216_n11UsuariosId ;
      private int[] T000217_A263Vacantes_Id ;
      private int[] T000217_A11UsuariosId ;
      private bool[] T000217_n11UsuariosId ;
      private int[] T000218_A278Perfiles_Id ;
      private int[] T000218_A11UsuariosId ;
      private bool[] T000218_n11UsuariosId ;
      private int[] T000219_A11UsuariosId ;
      private bool[] T000219_n11UsuariosId ;
      private DateTime[] T000219_A30FechaIntento ;
      private int[] T000220_A11UsuariosId ;
      private bool[] T000220_n11UsuariosId ;
      private DateTime[] T000220_A62HisPwdFecha ;
      private int[] T000221_A11UsuariosId ;
      private bool[] T000221_n11UsuariosId ;
      private GXWebForm Form ;
      private SdtTransactionContext AV32TrnContext ;
      private SdtTransactionContext_Attribute AV33TrnContextAtt ;
   }

   public class usuarios__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00025 ;
          prmT00025 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT00024 ;
          prmT00024 = new Object[] {
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT00026 ;
          prmT00026 = new Object[] {
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT00027 ;
          prmT00027 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT00023 ;
          prmT00023 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT00028 ;
          prmT00028 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT00029 ;
          prmT00029 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT00022 ;
          prmT00022 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000210 ;
          prmT000210 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"UsuariosUsr",System.Data.DbType.String,20,0} ,
          new Object[] {"UsuariosIP",System.Data.DbType.String,15,0} ,
          new Object[] {"UsuariosFecNacimiento",System.Data.DbType.Date,8,0} ,
          new Object[] {"UsuariosEdad",System.Data.DbType.Int16,4,0} ,
          new Object[] {"UsuariosCurp",System.Data.DbType.String,18,0} ,
          new Object[] {"UsuariosNombre",System.Data.DbType.String,40,0} ,
          new Object[] {"UsuariosApPat",System.Data.DbType.String,40,0} ,
          new Object[] {"UsuariosApMat",System.Data.DbType.String,40,0} ,
          new Object[] {"UsuariosTipo",System.Data.DbType.Int16,4,0} ,
          new Object[] {"UsuariosIcono",System.Data.DbType.Binary,1024,0} ,
          new Object[] {"UsuariosIcono_GXI",System.Data.DbType.String,2048,0} ,
          new Object[] {"UsuariosSexo",System.Data.DbType.String,1,0} ,
          new Object[] {"UsuariosPwd",System.Data.DbType.String,32,0} ,
          new Object[] {"UsuariosKey",System.Data.DbType.String,32,0} ,
          new Object[] {"UsuariosVigIni",System.Data.DbType.Date,8,0} ,
          new Object[] {"UsuariosVigFin",System.Data.DbType.Date,8,0} ,
          new Object[] {"UsuariosFecCap",System.Data.DbType.DateTime,10,8} ,
          new Object[] {"UsuariosTelef",System.Data.DbType.String,10,0} ,
          new Object[] {"UsuariosCorreo",System.Data.DbType.String,100,0} ,
          new Object[] {"UsuariosStatus",System.Data.DbType.Byte,1,0} ,
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000211 ;
          prmT000211 = new Object[] {
          new Object[] {"UsuariosUsr",System.Data.DbType.String,20,0} ,
          new Object[] {"UsuariosIP",System.Data.DbType.String,15,0} ,
          new Object[] {"UsuariosFecNacimiento",System.Data.DbType.Date,8,0} ,
          new Object[] {"UsuariosEdad",System.Data.DbType.Int16,4,0} ,
          new Object[] {"UsuariosCurp",System.Data.DbType.String,18,0} ,
          new Object[] {"UsuariosNombre",System.Data.DbType.String,40,0} ,
          new Object[] {"UsuariosApPat",System.Data.DbType.String,40,0} ,
          new Object[] {"UsuariosApMat",System.Data.DbType.String,40,0} ,
          new Object[] {"UsuariosTipo",System.Data.DbType.Int16,4,0} ,
          new Object[] {"UsuariosSexo",System.Data.DbType.String,1,0} ,
          new Object[] {"UsuariosPwd",System.Data.DbType.String,32,0} ,
          new Object[] {"UsuariosKey",System.Data.DbType.String,32,0} ,
          new Object[] {"UsuariosVigIni",System.Data.DbType.Date,8,0} ,
          new Object[] {"UsuariosVigFin",System.Data.DbType.Date,8,0} ,
          new Object[] {"UsuariosFecCap",System.Data.DbType.DateTime,10,8} ,
          new Object[] {"UsuariosTelef",System.Data.DbType.String,10,0} ,
          new Object[] {"UsuariosCorreo",System.Data.DbType.String,100,0} ,
          new Object[] {"UsuariosStatus",System.Data.DbType.Byte,1,0} ,
          new Object[] {"RolId",System.Data.DbType.Int32,9,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000212 ;
          prmT000212 = new Object[] {
          new Object[] {"UsuariosIcono",System.Data.DbType.Binary,1024,0} ,
          new Object[] {"UsuariosIcono_GXI",System.Data.DbType.String,2048,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000213 ;
          prmT000213 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000215 ;
          prmT000215 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000216 ;
          prmT000216 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000217 ;
          prmT000217 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000218 ;
          prmT000218 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000219 ;
          prmT000219 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000220 ;
          prmT000220 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000221 ;
          prmT000221 = new Object[] {
          } ;
          Object[] prmT000214 ;
          prmT000214 = new Object[] {
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("T00022", "SELECT `UsuariosId`, `UsuariosUsr`, `UsuariosIP`, `UsuariosFecNacimiento`, `UsuariosEdad`, `UsuariosCurp`, `UsuariosNombre`, `UsuariosApPat`, `UsuariosApMat`, `UsuariosTipo`, `UsuariosIcono_GXI`, `UsuariosSexo`, `UsuariosPwd`, `UsuariosKey`, `UsuariosVigIni`, `UsuariosVigFin`, `UsuariosFecCap`, `UsuariosTelef`, `UsuariosCorreo`, `UsuariosStatus`, `RolId`, `UsuariosIcono` FROM `Usuarios` WHERE `UsuariosId` = ?  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00023", "SELECT `UsuariosId`, `UsuariosUsr`, `UsuariosIP`, `UsuariosFecNacimiento`, `UsuariosEdad`, `UsuariosCurp`, `UsuariosNombre`, `UsuariosApPat`, `UsuariosApMat`, `UsuariosTipo`, `UsuariosIcono_GXI`, `UsuariosSexo`, `UsuariosPwd`, `UsuariosKey`, `UsuariosVigIni`, `UsuariosVigFin`, `UsuariosFecCap`, `UsuariosTelef`, `UsuariosCorreo`, `UsuariosStatus`, `RolId`, `UsuariosIcono` FROM `Usuarios` WHERE `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00024", "SELECT `RolNombre` FROM `Roles` WHERE `RolId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00025", "SELECT TM1.`UsuariosId`, TM1.`UsuariosUsr`, TM1.`UsuariosIP`, TM1.`UsuariosFecNacimiento`, TM1.`UsuariosEdad`, TM1.`UsuariosCurp`, TM1.`UsuariosNombre`, TM1.`UsuariosApPat`, TM1.`UsuariosApMat`, TM1.`UsuariosTipo`, TM1.`UsuariosIcono_GXI`, TM1.`UsuariosSexo`, TM1.`UsuariosPwd`, TM1.`UsuariosKey`, TM1.`UsuariosVigIni`, TM1.`UsuariosVigFin`, TM1.`UsuariosFecCap`, TM1.`UsuariosTelef`, TM1.`UsuariosCorreo`, T2.`RolNombre`, TM1.`UsuariosStatus`, TM1.`RolId`, TM1.`UsuariosIcono` FROM (`Usuarios` TM1 INNER JOIN `Roles` T2 ON T2.`RolId` = TM1.`RolId`) WHERE TM1.`UsuariosId` = ? ORDER BY TM1.`UsuariosId` ",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00026", "SELECT `RolNombre` FROM `Roles` WHERE `RolId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00027", "SELECT `UsuariosId` FROM `Usuarios` WHERE `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00028", "SELECT `UsuariosId` FROM `Usuarios` WHERE ( `UsuariosId` > ?) ORDER BY `UsuariosId`  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT00028,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00029", "SELECT `UsuariosId` FROM `Usuarios` WHERE ( `UsuariosId` < ?) ORDER BY `UsuariosId` DESC  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT00029,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000210", "INSERT INTO `Usuarios`(`UsuariosId`, `UsuariosUsr`, `UsuariosIP`, `UsuariosFecNacimiento`, `UsuariosEdad`, `UsuariosCurp`, `UsuariosNombre`, `UsuariosApPat`, `UsuariosApMat`, `UsuariosTipo`, `UsuariosIcono`, `UsuariosIcono_GXI`, `UsuariosSexo`, `UsuariosPwd`, `UsuariosKey`, `UsuariosVigIni`, `UsuariosVigFin`, `UsuariosFecCap`, `UsuariosTelef`, `UsuariosCorreo`, `UsuariosStatus`, `RolId`) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", GxErrorMask.GX_NOMASK,prmT000210)
             ,new CursorDef("T000211", "UPDATE `Usuarios` SET `UsuariosUsr`=?, `UsuariosIP`=?, `UsuariosFecNacimiento`=?, `UsuariosEdad`=?, `UsuariosCurp`=?, `UsuariosNombre`=?, `UsuariosApPat`=?, `UsuariosApMat`=?, `UsuariosTipo`=?, `UsuariosSexo`=?, `UsuariosPwd`=?, `UsuariosKey`=?, `UsuariosVigIni`=?, `UsuariosVigFin`=?, `UsuariosFecCap`=?, `UsuariosTelef`=?, `UsuariosCorreo`=?, `UsuariosStatus`=?, `RolId`=?  WHERE `UsuariosId` = ?", GxErrorMask.GX_NOMASK,prmT000211)
             ,new CursorDef("T000212", "UPDATE `Usuarios` SET `UsuariosIcono`=?, `UsuariosIcono_GXI`=?  WHERE `UsuariosId` = ?", GxErrorMask.GX_NOMASK,prmT000212)
             ,new CursorDef("T000213", "DELETE FROM `Usuarios`  WHERE `UsuariosId` = ?", GxErrorMask.GX_NOMASK,prmT000213)
             ,new CursorDef("T000214", "SELECT `RolNombre` FROM `Roles` WHERE `RolId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000214,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000215", "SELECT `bitAccesFec`, `bitAccesIp` FROM `bitAcces` WHERE `UsuariosId` = ?  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000215,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000216", "SELECT `Vacantes_Id`, `UsuariosId` FROM `VacantesUsuariosVacante` WHERE `SUBT_ReclutadorId` = ?  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000216,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000217", "SELECT `Vacantes_Id`, `UsuariosId` FROM `VacantesUsuariosVacante` WHERE `UsuariosId` = ?  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000217,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000218", "SELECT `Perfiles_Id`, `UsuariosId` FROM `PerfilesUsuariosPerfil` WHERE `UsuariosId` = ?  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000218,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000219", "SELECT `UsuariosId`, `FechaIntento` FROM `Intentos` WHERE `UsuariosId` = ?  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000219,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000220", "SELECT `UsuariosId`, `HisPwdFecha` FROM `HistPwd` WHERE `UsuariosId` = ?  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000220,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000221", "SELECT `UsuariosId` FROM `Usuarios` ORDER BY `UsuariosId` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000221,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4) ;
                ((short[]) buf[4])[0] = rslt.getShort(5) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
                ((String[]) buf[6])[0] = rslt.getVarchar(7) ;
                ((String[]) buf[7])[0] = rslt.getVarchar(8) ;
                ((String[]) buf[8])[0] = rslt.getVarchar(9) ;
                ((short[]) buf[9])[0] = rslt.getShort(10) ;
                ((String[]) buf[10])[0] = rslt.getMultimediaUri(11) ;
                ((String[]) buf[11])[0] = rslt.getString(12, 1) ;
                ((String[]) buf[12])[0] = rslt.getVarchar(13) ;
                ((String[]) buf[13])[0] = rslt.getVarchar(14) ;
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(15) ;
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(16) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(17) ;
                ((String[]) buf[18])[0] = rslt.getString(18, 10) ;
                ((String[]) buf[19])[0] = rslt.getVarchar(19) ;
                ((short[]) buf[20])[0] = rslt.getShort(20) ;
                ((int[]) buf[21])[0] = rslt.getInt(21) ;
                ((String[]) buf[22])[0] = rslt.getMultimediaFile(22, rslt.getVarchar(11)) ;
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4) ;
                ((short[]) buf[4])[0] = rslt.getShort(5) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
                ((String[]) buf[6])[0] = rslt.getVarchar(7) ;
                ((String[]) buf[7])[0] = rslt.getVarchar(8) ;
                ((String[]) buf[8])[0] = rslt.getVarchar(9) ;
                ((short[]) buf[9])[0] = rslt.getShort(10) ;
                ((String[]) buf[10])[0] = rslt.getMultimediaUri(11) ;
                ((String[]) buf[11])[0] = rslt.getString(12, 1) ;
                ((String[]) buf[12])[0] = rslt.getVarchar(13) ;
                ((String[]) buf[13])[0] = rslt.getVarchar(14) ;
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(15) ;
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(16) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(17) ;
                ((String[]) buf[18])[0] = rslt.getString(18, 10) ;
                ((String[]) buf[19])[0] = rslt.getVarchar(19) ;
                ((short[]) buf[20])[0] = rslt.getShort(20) ;
                ((int[]) buf[21])[0] = rslt.getInt(21) ;
                ((String[]) buf[22])[0] = rslt.getMultimediaFile(22, rslt.getVarchar(11)) ;
                return;
             case 2 :
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4) ;
                ((short[]) buf[4])[0] = rslt.getShort(5) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
                ((String[]) buf[6])[0] = rslt.getVarchar(7) ;
                ((String[]) buf[7])[0] = rslt.getVarchar(8) ;
                ((String[]) buf[8])[0] = rslt.getVarchar(9) ;
                ((short[]) buf[9])[0] = rslt.getShort(10) ;
                ((String[]) buf[10])[0] = rslt.getMultimediaUri(11) ;
                ((String[]) buf[11])[0] = rslt.getString(12, 1) ;
                ((String[]) buf[12])[0] = rslt.getVarchar(13) ;
                ((String[]) buf[13])[0] = rslt.getVarchar(14) ;
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(15) ;
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(16) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(17) ;
                ((String[]) buf[18])[0] = rslt.getString(18, 10) ;
                ((String[]) buf[19])[0] = rslt.getVarchar(19) ;
                ((String[]) buf[20])[0] = rslt.getVarchar(20) ;
                ((short[]) buf[21])[0] = rslt.getShort(21) ;
                ((int[]) buf[22])[0] = rslt.getInt(22) ;
                ((String[]) buf[23])[0] = rslt.getMultimediaFile(23, rslt.getVarchar(11)) ;
                return;
             case 4 :
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
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
             case 12 :
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                return;
             case 13 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2) ;
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2) ;
                return;
             case 19 :
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
                stmt.SetParameter(2, (String)parms[2]);
                stmt.SetParameter(3, (String)parms[3]);
                stmt.SetParameter(4, (DateTime)parms[4]);
                stmt.SetParameter(5, (short)parms[5]);
                stmt.SetParameter(6, (String)parms[6]);
                stmt.SetParameter(7, (String)parms[7]);
                stmt.SetParameter(8, (String)parms[8]);
                stmt.SetParameter(9, (String)parms[9]);
                stmt.SetParameter(10, (short)parms[10]);
                stmt.SetParameterBlob(11, (String)parms[11], false);
                stmt.SetParameterMultimedia(12, (String)parms[12], (String)parms[11], "Usuarios", "UsuariosIcono");
                stmt.SetParameter(13, (String)parms[13]);
                stmt.SetParameter(14, (String)parms[14]);
                stmt.SetParameter(15, (String)parms[15]);
                stmt.SetParameter(16, (DateTime)parms[16]);
                if ( (bool)parms[17] )
                {
                   stmt.setNull( 17 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(17, (DateTime)parms[18]);
                }
                stmt.SetParameterDatetime(18, (DateTime)parms[19]);
                stmt.SetParameter(19, (String)parms[20]);
                stmt.SetParameter(20, (String)parms[21]);
                stmt.SetParameter(21, (short)parms[22]);
                stmt.SetParameter(22, (int)parms[23]);
                return;
             case 9 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (DateTime)parms[2]);
                stmt.SetParameter(4, (short)parms[3]);
                stmt.SetParameter(5, (String)parms[4]);
                stmt.SetParameter(6, (String)parms[5]);
                stmt.SetParameter(7, (String)parms[6]);
                stmt.SetParameter(8, (String)parms[7]);
                stmt.SetParameter(9, (short)parms[8]);
                stmt.SetParameter(10, (String)parms[9]);
                stmt.SetParameter(11, (String)parms[10]);
                stmt.SetParameter(12, (String)parms[11]);
                stmt.SetParameter(13, (DateTime)parms[12]);
                if ( (bool)parms[13] )
                {
                   stmt.setNull( 14 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(14, (DateTime)parms[14]);
                }
                stmt.SetParameterDatetime(15, (DateTime)parms[15]);
                stmt.SetParameter(16, (String)parms[16]);
                stmt.SetParameter(17, (String)parms[17]);
                stmt.SetParameter(18, (short)parms[18]);
                stmt.SetParameter(19, (int)parms[19]);
                if ( (bool)parms[20] )
                {
                   stmt.setNull( 20 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(20, (int)parms[21]);
                }
                return;
             case 10 :
                stmt.SetParameterBlob(1, (String)parms[0], false);
                stmt.SetParameterMultimedia(2, (String)parms[1], (String)parms[0], "Usuarios", "UsuariosIcono");
                if ( (bool)parms[2] )
                {
                   stmt.setNull( 3 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(3, (int)parms[3]);
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
                stmt.SetParameter(1, (int)parms[0]);
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
             case 17 :
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
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
       }
    }

 }

}
