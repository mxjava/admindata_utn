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
   public class vacantes : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A11UsuariosId = (int)(NumberUtil.Val( GetNextPar( ), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A11UsuariosId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridvacantes_usuariosvacante") == 0 )
         {
            nRC_GXsfl_90 = (int)(NumberUtil.Val( GetNextPar( ), "."));
            nGXsfl_90_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
            sGXsfl_90_idx = GetNextPar( );
            Gx_mode = GetNextPar( );
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridvacantes_usuariosvacante_newrow( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "vacantes.aspx")), "vacantes.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "vacantes.aspx")))) ;
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
                  AV7Vacantes_Id = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri("", false, "AV7Vacantes_Id", StringUtil.LTrimStr( (decimal)(AV7Vacantes_Id), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vVACANTES_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7Vacantes_Id), "ZZZZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Work With Vacantes", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtVacantes_Nombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public vacantes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public vacantes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( String aP0_Gx_mode ,
                           int aP1_Vacantes_Id )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7Vacantes_Id = aP1_Vacantes_Id;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbVacantes_Status = new GXCombobox();
         cmbVacantes_Tipo = new GXCombobox();
         cmbVacantes_Duracion_Nom = new GXCombobox();
         cmbUsuariosVacanteEstatus = new GXCombobox();
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
         if ( cmbVacantes_Status.ItemCount > 0 )
         {
            A265Vacantes_Status = (short)(NumberUtil.Val( cmbVacantes_Status.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A265Vacantes_Status), 4, 0))), "."));
            AssignAttri("", false, "A265Vacantes_Status", StringUtil.LTrimStr( (decimal)(A265Vacantes_Status), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbVacantes_Status.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A265Vacantes_Status), 4, 0));
            AssignProp("", false, cmbVacantes_Status_Internalname, "Values", cmbVacantes_Status.ToJavascriptSource(), true);
         }
         if ( cmbVacantes_Tipo.ItemCount > 0 )
         {
            A268Vacantes_Tipo = (short)(NumberUtil.Val( cmbVacantes_Tipo.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A268Vacantes_Tipo), 4, 0))), "."));
            AssignAttri("", false, "A268Vacantes_Tipo", StringUtil.LTrimStr( (decimal)(A268Vacantes_Tipo), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbVacantes_Tipo.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A268Vacantes_Tipo), 4, 0));
            AssignProp("", false, cmbVacantes_Tipo_Internalname, "Values", cmbVacantes_Tipo.ToJavascriptSource(), true);
         }
         if ( cmbVacantes_Duracion_Nom.ItemCount > 0 )
         {
            A270Vacantes_Duracion_Nom = (short)(NumberUtil.Val( cmbVacantes_Duracion_Nom.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A270Vacantes_Duracion_Nom), 4, 0))), "."));
            AssignAttri("", false, "A270Vacantes_Duracion_Nom", StringUtil.LTrimStr( (decimal)(A270Vacantes_Duracion_Nom), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbVacantes_Duracion_Nom.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A270Vacantes_Duracion_Nom), 4, 0));
            AssignProp("", false, cmbVacantes_Duracion_Nom_Internalname, "Values", cmbVacantes_Duracion_Nom.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Vacantes", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_Vacantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 ViewActionsBackCell", "Right", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblViellall_Internalname, "Vacantes", "", "", lblViellall_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110h21_client"+"'", "", "BtnTextBlockBack", 7, "", 1, 1, 0, "HLP_Vacantes.htm");
         GxWebStd.gx_div_end( context, "Right", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Vacantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Vacantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Vacantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Vacantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Vacantes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVacantes_Id_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVacantes_Id_Internalname, "ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtVacantes_Id_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A263Vacantes_Id), 9, 0, ",", "")), ((edtVacantes_Id_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A263Vacantes_Id), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A263Vacantes_Id), "ZZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVacantes_Id_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVacantes_Id_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Vacantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVacantes_Nombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVacantes_Nombre_Internalname, "Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVacantes_Nombre_Internalname, A264Vacantes_Nombre, StringUtil.RTrim( context.localUtil.Format( A264Vacantes_Nombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVacantes_Nombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVacantes_Nombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Vacantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVacantes_Descripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVacantes_Descripcion_Internalname, "Descripción", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtVacantes_Descripcion_Internalname, A274Vacantes_Descripcion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", 0, 1, edtVacantes_Descripcion_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "1000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Vacantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbVacantes_Status_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbVacantes_Status_Internalname, "Estatus", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbVacantes_Status, cmbVacantes_Status_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A265Vacantes_Status), 4, 0)), 1, cmbVacantes_Status_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbVacantes_Status.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "", true, "HLP_Vacantes.htm");
         cmbVacantes_Status.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A265Vacantes_Status), 4, 0));
         AssignProp("", false, cmbVacantes_Status_Internalname, "Values", (String)(cmbVacantes_Status.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVacantes_FechaInicio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVacantes_FechaInicio_Internalname, "Fecha Inicio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtVacantes_FechaInicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtVacantes_FechaInicio_Internalname, context.localUtil.Format(A266Vacantes_FechaInicio, "99/99/99"), context.localUtil.Format( A266Vacantes_FechaInicio, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVacantes_FechaInicio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVacantes_FechaInicio_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Vacantes.htm");
         GxWebStd.gx_bitmap( context, edtVacantes_FechaInicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVacantes_FechaInicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Vacantes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVacantes_Sueldo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVacantes_Sueldo_Internalname, "Sueldo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVacantes_Sueldo_Internalname, StringUtil.LTrim( StringUtil.NToC( A267Vacantes_Sueldo, 6, 3, ",", "")), ((edtVacantes_Sueldo_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A267Vacantes_Sueldo, "Z9.999")) : context.localUtil.Format( A267Vacantes_Sueldo, "Z9.999")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','3');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','3');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVacantes_Sueldo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVacantes_Sueldo_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Vacantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbVacantes_Tipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbVacantes_Tipo_Internalname, "Tipo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbVacantes_Tipo, cmbVacantes_Tipo_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A268Vacantes_Tipo), 4, 0)), 1, cmbVacantes_Tipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbVacantes_Tipo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "", true, "HLP_Vacantes.htm");
         cmbVacantes_Tipo.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A268Vacantes_Tipo), 4, 0));
         AssignProp("", false, cmbVacantes_Tipo_Internalname, "Values", (String)(cmbVacantes_Tipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVacantes_Duracion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVacantes_Duracion_Internalname, "Duración", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVacantes_Duracion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A269Vacantes_Duracion), 4, 0, ",", "")), ((edtVacantes_Duracion_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A269Vacantes_Duracion), "ZZZ9")) : context.localUtil.Format( (decimal)(A269Vacantes_Duracion), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVacantes_Duracion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVacantes_Duracion_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Vacantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbVacantes_Duracion_Nom_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbVacantes_Duracion_Nom_Internalname, "----", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbVacantes_Duracion_Nom, cmbVacantes_Duracion_Nom_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A270Vacantes_Duracion_Nom), 4, 0)), 1, cmbVacantes_Duracion_Nom_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbVacantes_Duracion_Nom.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "", true, "HLP_Vacantes.htm");
         cmbVacantes_Duracion_Nom.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A270Vacantes_Duracion_Nom), 4, 0));
         AssignProp("", false, cmbVacantes_Duracion_Nom_Internalname, "Values", (String)(cmbVacantes_Duracion_Nom.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVacantes_Plazas_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVacantes_Plazas_Internalname, "Vacantes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVacantes_Plazas_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A277Vacantes_Plazas), 4, 0, ",", "")), ((edtVacantes_Plazas_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A277Vacantes_Plazas), "ZZZ9")) : context.localUtil.Format( (decimal)(A277Vacantes_Plazas), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVacantes_Plazas_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVacantes_Plazas_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Vacantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUsuariosvacantetable_Internalname, 1, 0, "px", 0, "px", "LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleusuariosvacante_Internalname, "Usuarios Vacante", "", "", lblTitleusuariosvacante_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_Vacantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridvacantes_usuariosvacante( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Vacantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Vacantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Vacantes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridvacantes_usuariosvacante( )
      {
         /*  Grid Control  */
         Gridvacantes_usuariosvacanteContainer.AddObjectProperty("GridName", "Gridvacantes_usuariosvacante");
         Gridvacantes_usuariosvacanteContainer.AddObjectProperty("Header", subGridvacantes_usuariosvacante_Header);
         Gridvacantes_usuariosvacanteContainer.AddObjectProperty("Class", "Grid");
         Gridvacantes_usuariosvacanteContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridvacantes_usuariosvacanteContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridvacantes_usuariosvacanteContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvacantes_usuariosvacante_Backcolorstyle), 1, 0, ".", "")));
         Gridvacantes_usuariosvacanteContainer.AddObjectProperty("CmpContext", "");
         Gridvacantes_usuariosvacanteContainer.AddObjectProperty("InMasterPage", "false");
         Gridvacantes_usuariosvacanteColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridvacantes_usuariosvacanteColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ".", "")));
         Gridvacantes_usuariosvacanteColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosId_Enabled), 5, 0, ".", "")));
         Gridvacantes_usuariosvacanteContainer.AddColumnProperties(Gridvacantes_usuariosvacanteColumn);
         Gridvacantes_usuariosvacanteColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridvacantes_usuariosvacanteColumn.AddObjectProperty("Value", A66UsuariosNombre);
         Gridvacantes_usuariosvacanteColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosNombre_Enabled), 5, 0, ".", "")));
         Gridvacantes_usuariosvacanteContainer.AddColumnProperties(Gridvacantes_usuariosvacanteColumn);
         Gridvacantes_usuariosvacanteColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridvacantes_usuariosvacanteColumn.AddObjectProperty("Value", A65UsuariosApPat);
         Gridvacantes_usuariosvacanteColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosApPat_Enabled), 5, 0, ".", "")));
         Gridvacantes_usuariosvacanteContainer.AddColumnProperties(Gridvacantes_usuariosvacanteColumn);
         Gridvacantes_usuariosvacanteColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridvacantes_usuariosvacanteColumn.AddObjectProperty("Value", A64UsuariosApMat);
         Gridvacantes_usuariosvacanteColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosApMat_Enabled), 5, 0, ".", "")));
         Gridvacantes_usuariosvacanteContainer.AddColumnProperties(Gridvacantes_usuariosvacanteColumn);
         Gridvacantes_usuariosvacanteColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridvacantes_usuariosvacanteColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A273UsuariosVacanteEstatus), 1, 0, ".", "")));
         Gridvacantes_usuariosvacanteColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbUsuariosVacanteEstatus.Enabled), 5, 0, ".", "")));
         Gridvacantes_usuariosvacanteContainer.AddColumnProperties(Gridvacantes_usuariosvacanteColumn);
         Gridvacantes_usuariosvacanteContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvacantes_usuariosvacante_Selectedindex), 4, 0, ".", "")));
         Gridvacantes_usuariosvacanteContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvacantes_usuariosvacante_Allowselection), 1, 0, ".", "")));
         Gridvacantes_usuariosvacanteContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvacantes_usuariosvacante_Selectioncolor), 9, 0, ".", "")));
         Gridvacantes_usuariosvacanteContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvacantes_usuariosvacante_Allowhovering), 1, 0, ".", "")));
         Gridvacantes_usuariosvacanteContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvacantes_usuariosvacante_Hoveringcolor), 9, 0, ".", "")));
         Gridvacantes_usuariosvacanteContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvacantes_usuariosvacante_Allowcollapsing), 1, 0, ".", "")));
         Gridvacantes_usuariosvacanteContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvacantes_usuariosvacante_Collapsed), 1, 0, ".", "")));
         nGXsfl_90_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount28 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_28 = 1;
               ScanStart0H28( ) ;
               while ( RcdFound28 != 0 )
               {
                  init_level_properties28( ) ;
                  getByPrimaryKey0H28( ) ;
                  AddRow0H28( ) ;
                  ScanNext0H28( ) ;
               }
               ScanEnd0H28( ) ;
               nBlankRcdCount28 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0H28( ) ;
            standaloneModal0H28( ) ;
            sMode28 = Gx_mode;
            while ( nGXsfl_90_idx < nRC_GXsfl_90 )
            {
               bGXsfl_90_Refreshing = true;
               ReadRow0H28( ) ;
               edtUsuariosId_Enabled = (int)(context.localUtil.CToN( cgiGet( "USUARIOSID_"+sGXsfl_90_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtUsuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosId_Enabled), 5, 0), !bGXsfl_90_Refreshing);
               edtUsuariosNombre_Enabled = (int)(context.localUtil.CToN( cgiGet( "USUARIOSNOMBRE_"+sGXsfl_90_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtUsuariosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosNombre_Enabled), 5, 0), !bGXsfl_90_Refreshing);
               edtUsuariosApPat_Enabled = (int)(context.localUtil.CToN( cgiGet( "USUARIOSAPPAT_"+sGXsfl_90_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtUsuariosApPat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosApPat_Enabled), 5, 0), !bGXsfl_90_Refreshing);
               edtUsuariosApMat_Enabled = (int)(context.localUtil.CToN( cgiGet( "USUARIOSAPMAT_"+sGXsfl_90_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtUsuariosApMat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosApMat_Enabled), 5, 0), !bGXsfl_90_Refreshing);
               cmbUsuariosVacanteEstatus.Enabled = (int)(context.localUtil.CToN( cgiGet( "USUARIOSVACANTEESTATUS_"+sGXsfl_90_idx+"Enabled"), ",", "."));
               AssignProp("", false, cmbUsuariosVacanteEstatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUsuariosVacanteEstatus.Enabled), 5, 0), !bGXsfl_90_Refreshing);
               if ( ( nRcdExists_28 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0H28( ) ;
               }
               SendRow0H28( ) ;
               bGXsfl_90_Refreshing = false;
            }
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount28 = 5;
            nRcdExists_28 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0H28( ) ;
               while ( RcdFound28 != 0 )
               {
                  sGXsfl_90_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_90_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_9028( ) ;
                  init_level_properties28( ) ;
                  standaloneNotModal0H28( ) ;
                  getByPrimaryKey0H28( ) ;
                  standaloneModal0H28( ) ;
                  AddRow0H28( ) ;
                  ScanNext0H28( ) ;
               }
               ScanEnd0H28( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode28 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_90_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_90_idx+1), 4, 0), 4, "0");
            SubsflControlProps_9028( ) ;
            InitAll0H28( ) ;
            init_level_properties28( ) ;
            nRcdExists_28 = 0;
            nIsMod_28 = 0;
            nRcdDeleted_28 = 0;
            nBlankRcdCount28 = (short)(nBlankRcdUsr28+nBlankRcdCount28);
            fRowAdded = 0;
            while ( nBlankRcdCount28 > 0 )
            {
               standaloneNotModal0H28( ) ;
               standaloneModal0H28( ) ;
               AddRow0H28( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtUsuariosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount28 = (short)(nBlankRcdCount28-1);
            }
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridvacantes_usuariosvacanteContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridvacantes_usuariosvacante", Gridvacantes_usuariosvacanteContainer);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridvacantes_usuariosvacanteContainerData", Gridvacantes_usuariosvacanteContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridvacantes_usuariosvacanteContainerData"+"V", Gridvacantes_usuariosvacanteContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridvacantes_usuariosvacanteContainerData"+"V"+"\" value='"+Gridvacantes_usuariosvacanteContainer.GridValuesHidden()+"'/>") ;
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
         E120H2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z263Vacantes_Id = (int)(context.localUtil.CToN( cgiGet( "Z263Vacantes_Id"), ",", "."));
               Z264Vacantes_Nombre = cgiGet( "Z264Vacantes_Nombre");
               Z274Vacantes_Descripcion = cgiGet( "Z274Vacantes_Descripcion");
               Z265Vacantes_Status = (short)(context.localUtil.CToN( cgiGet( "Z265Vacantes_Status"), ",", "."));
               Z266Vacantes_FechaInicio = context.localUtil.CToD( cgiGet( "Z266Vacantes_FechaInicio"), 0);
               Z267Vacantes_Sueldo = context.localUtil.CToN( cgiGet( "Z267Vacantes_Sueldo"), ",", ".");
               Z268Vacantes_Tipo = (short)(context.localUtil.CToN( cgiGet( "Z268Vacantes_Tipo"), ",", "."));
               Z269Vacantes_Duracion = (short)(context.localUtil.CToN( cgiGet( "Z269Vacantes_Duracion"), ",", "."));
               Z270Vacantes_Duracion_Nom = (short)(context.localUtil.CToN( cgiGet( "Z270Vacantes_Duracion_Nom"), ",", "."));
               Z277Vacantes_Plazas = (short)(context.localUtil.CToN( cgiGet( "Z277Vacantes_Plazas"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_90 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_90"), ",", "."));
               AV7Vacantes_Id = (int)(context.localUtil.CToN( cgiGet( "vVACANTES_ID"), ",", "."));
               AV12Pgmname = cgiGet( "vPGMNAME");
               A287SUBT_ReclutadorNombre = cgiGet( "SUBT_RECLUTADORNOMBRE");
               A288VacantesUsuariosFechaP = context.localUtil.CToT( cgiGet( "VACANTESUSUARIOSFECHAP"), 0);
               A289VacantesUsuariosFechaD = context.localUtil.CToT( cgiGet( "VACANTESUSUARIOSFECHAD"), 0);
               n289VacantesUsuariosFechaD = false;
               n289VacantesUsuariosFechaD = ((DateTime.MinValue==A289VacantesUsuariosFechaD) ? true : false);
               A313VacantesUsuariosFechaA = context.localUtil.CToT( cgiGet( "VACANTESUSUARIOSFECHAA"), 0);
               n313VacantesUsuariosFechaA = false;
               n313VacantesUsuariosFechaA = ((DateTime.MinValue==A313VacantesUsuariosFechaA) ? true : false);
               A314VacantesUsuariosFecha3 = context.localUtil.CToT( cgiGet( "VACANTESUSUARIOSFECHA3"), 0);
               n314VacantesUsuariosFecha3 = false;
               n314VacantesUsuariosFecha3 = ((DateTime.MinValue==A314VacantesUsuariosFecha3) ? true : false);
               A294VacantesUsuariosMotD = cgiGet( "VACANTESUSUARIOSMOTD");
               n294VacantesUsuariosMotD = false;
               n294VacantesUsuariosMotD = (String.IsNullOrEmpty(StringUtil.RTrim( A294VacantesUsuariosMotD)) ? true : false);
               A290VacantesUsuariosEstatus = (short)(context.localUtil.CToN( cgiGet( "VACANTESUSUARIOSESTATUS"), ",", "."));
               n290VacantesUsuariosEstatus = false;
               n290VacantesUsuariosEstatus = ((0==A290VacantesUsuariosEstatus) ? true : false);
               A291VacantesUsuariosPrefiltro = (short)(context.localUtil.CToN( cgiGet( "VACANTESUSUARIOSPREFILTRO"), ",", "."));
               n291VacantesUsuariosPrefiltro = false;
               n291VacantesUsuariosPrefiltro = ((0==A291VacantesUsuariosPrefiltro) ? true : false);
               A292VacantesUsuariosCV = (short)(context.localUtil.CToN( cgiGet( "VACANTESUSUARIOSCV"), ",", "."));
               n292VacantesUsuariosCV = false;
               n292VacantesUsuariosCV = ((0==A292VacantesUsuariosCV) ? true : false);
               A293VacantesUsuariosExTec = (short)(context.localUtil.CToN( cgiGet( "VACANTESUSUARIOSEXTEC"), ",", "."));
               n293VacantesUsuariosExTec = false;
               n293VacantesUsuariosExTec = ((0==A293VacantesUsuariosExTec) ? true : false);
               A299VacantesUsuariosCVRec = (short)(context.localUtil.CToN( cgiGet( "VACANTESUSUARIOSCVREC"), ",", "."));
               n299VacantesUsuariosCVRec = false;
               n299VacantesUsuariosCVRec = ((0==A299VacantesUsuariosCVRec) ? true : false);
               A300VacantesUsuariosRefLab = (short)(context.localUtil.CToN( cgiGet( "VACANTESUSUARIOSREFLAB"), ",", "."));
               n300VacantesUsuariosRefLab = false;
               n300VacantesUsuariosRefLab = ((0==A300VacantesUsuariosRefLab) ? true : false);
               A301VacantesUsuariosExPsi = (short)(context.localUtil.CToN( cgiGet( "VACANTESUSUARIOSEXPSI"), ",", "."));
               n301VacantesUsuariosExPsi = false;
               n301VacantesUsuariosExPsi = ((0==A301VacantesUsuariosExPsi) ? true : false);
               A302VacantesUsuariosBusWeb = (short)(context.localUtil.CToN( cgiGet( "VACANTESUSUARIOSBUSWEB"), ",", "."));
               n302VacantesUsuariosBusWeb = false;
               n302VacantesUsuariosBusWeb = ((0==A302VacantesUsuariosBusWeb) ? true : false);
               A303VacantesUsuariosAvPriv = (short)(context.localUtil.CToN( cgiGet( "VACANTESUSUARIOSAVPRIV"), ",", "."));
               n303VacantesUsuariosAvPriv = false;
               n303VacantesUsuariosAvPriv = ((0==A303VacantesUsuariosAvPriv) ? true : false);
               A304VacantesUsuariosAvConf = (short)(context.localUtil.CToN( cgiGet( "VACANTESUSUARIOSAVCONF"), ",", "."));
               n304VacantesUsuariosAvConf = false;
               n304VacantesUsuariosAvConf = ((0==A304VacantesUsuariosAvConf) ? true : false);
               A296VacantesUsuariosDocP = cgiGet( "VACANTESUSUARIOSDOCP");
               n296VacantesUsuariosDocP = false;
               n296VacantesUsuariosDocP = (String.IsNullOrEmpty(StringUtil.RTrim( A296VacantesUsuariosDocP)) ? true : false);
               A297VacantesUsuariosDocCV = cgiGet( "VACANTESUSUARIOSDOCCV");
               n297VacantesUsuariosDocCV = false;
               n297VacantesUsuariosDocCV = (String.IsNullOrEmpty(StringUtil.RTrim( A297VacantesUsuariosDocCV)) ? true : false);
               A298VacantesUsuariosDocTec = cgiGet( "VACANTESUSUARIOSDOCTEC");
               n298VacantesUsuariosDocTec = false;
               n298VacantesUsuariosDocTec = (String.IsNullOrEmpty(StringUtil.RTrim( A298VacantesUsuariosDocTec)) ? true : false);
               A295VacantesUsuariosFechaE = context.localUtil.CToT( cgiGet( "VACANTESUSUARIOSFECHAE"), 0);
               n295VacantesUsuariosFechaE = false;
               n295VacantesUsuariosFechaE = ((DateTime.MinValue==A295VacantesUsuariosFechaE) ? true : false);
               A305VacantesUsuariosDocCVRec = cgiGet( "VACANTESUSUARIOSDOCCVREC");
               n305VacantesUsuariosDocCVRec = false;
               n305VacantesUsuariosDocCVRec = (String.IsNullOrEmpty(StringUtil.RTrim( A305VacantesUsuariosDocCVRec)) ? true : false);
               A306VacantesUsuariosDocRefLab = cgiGet( "VACANTESUSUARIOSDOCREFLAB");
               n306VacantesUsuariosDocRefLab = false;
               n306VacantesUsuariosDocRefLab = (String.IsNullOrEmpty(StringUtil.RTrim( A306VacantesUsuariosDocRefLab)) ? true : false);
               A307VacantesUsuariosDocExPsi = cgiGet( "VACANTESUSUARIOSDOCEXPSI");
               n307VacantesUsuariosDocExPsi = false;
               n307VacantesUsuariosDocExPsi = (String.IsNullOrEmpty(StringUtil.RTrim( A307VacantesUsuariosDocExPsi)) ? true : false);
               A308VacantesUsuariosDocBusWeb = cgiGet( "VACANTESUSUARIOSDOCBUSWEB");
               n308VacantesUsuariosDocBusWeb = false;
               n308VacantesUsuariosDocBusWeb = (String.IsNullOrEmpty(StringUtil.RTrim( A308VacantesUsuariosDocBusWeb)) ? true : false);
               A309VacantesUsuariosDocAvPriv = cgiGet( "VACANTESUSUARIOSDOCAVPRIV");
               n309VacantesUsuariosDocAvPriv = false;
               n309VacantesUsuariosDocAvPriv = (String.IsNullOrEmpty(StringUtil.RTrim( A309VacantesUsuariosDocAvPriv)) ? true : false);
               A310VacantesUsuariosDocAvConf = cgiGet( "VACANTESUSUARIOSDOCAVCONF");
               n310VacantesUsuariosDocAvConf = false;
               n310VacantesUsuariosDocAvConf = (String.IsNullOrEmpty(StringUtil.RTrim( A310VacantesUsuariosDocAvConf)) ? true : false);
               A311VacantesUsuariosFechaEnvOp = context.localUtil.CToT( cgiGet( "VACANTESUSUARIOSFECHAENVOP"), 0);
               n311VacantesUsuariosFechaEnvOp = false;
               n311VacantesUsuariosFechaEnvOp = ((DateTime.MinValue==A311VacantesUsuariosFechaEnvOp) ? true : false);
               A312VacantesUsuariosFechaEnvCli = context.localUtil.CToT( cgiGet( "VACANTESUSUARIOSFECHAENVCLI"), 0);
               n312VacantesUsuariosFechaEnvCli = false;
               n312VacantesUsuariosFechaEnvCli = ((DateTime.MinValue==A312VacantesUsuariosFechaEnvCli) ? true : false);
               A284SUBT_ReclutadorId = (int)(context.localUtil.CToN( cgiGet( "SUBT_RECLUTADORID"), ",", "."));
               /* Read variables values. */
               A263Vacantes_Id = (int)(context.localUtil.CToN( cgiGet( edtVacantes_Id_Internalname), ",", "."));
               AssignAttri("", false, "A263Vacantes_Id", StringUtil.LTrimStr( (decimal)(A263Vacantes_Id), 9, 0));
               A264Vacantes_Nombre = cgiGet( edtVacantes_Nombre_Internalname);
               AssignAttri("", false, "A264Vacantes_Nombre", A264Vacantes_Nombre);
               A274Vacantes_Descripcion = cgiGet( edtVacantes_Descripcion_Internalname);
               AssignAttri("", false, "A274Vacantes_Descripcion", A274Vacantes_Descripcion);
               cmbVacantes_Status.Name = cmbVacantes_Status_Internalname;
               cmbVacantes_Status.CurrentValue = cgiGet( cmbVacantes_Status_Internalname);
               A265Vacantes_Status = (short)(NumberUtil.Val( cgiGet( cmbVacantes_Status_Internalname), "."));
               AssignAttri("", false, "A265Vacantes_Status", StringUtil.LTrimStr( (decimal)(A265Vacantes_Status), 4, 0));
               if ( context.localUtil.VCDate( cgiGet( edtVacantes_FechaInicio_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Inicio"}), 1, "VACANTES_FECHAINICIO");
                  AnyError = 1;
                  GX_FocusControl = edtVacantes_FechaInicio_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A266Vacantes_FechaInicio = DateTime.MinValue;
                  AssignAttri("", false, "A266Vacantes_FechaInicio", context.localUtil.Format(A266Vacantes_FechaInicio, "99/99/99"));
               }
               else
               {
                  A266Vacantes_FechaInicio = context.localUtil.CToD( cgiGet( edtVacantes_FechaInicio_Internalname), 2);
                  AssignAttri("", false, "A266Vacantes_FechaInicio", context.localUtil.Format(A266Vacantes_FechaInicio, "99/99/99"));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtVacantes_Sueldo_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVacantes_Sueldo_Internalname), ",", ".") > 99.999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VACANTES_SUELDO");
                  AnyError = 1;
                  GX_FocusControl = edtVacantes_Sueldo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A267Vacantes_Sueldo = 0;
                  AssignAttri("", false, "A267Vacantes_Sueldo", StringUtil.LTrimStr( A267Vacantes_Sueldo, 6, 3));
               }
               else
               {
                  A267Vacantes_Sueldo = context.localUtil.CToN( cgiGet( edtVacantes_Sueldo_Internalname), ",", ".");
                  AssignAttri("", false, "A267Vacantes_Sueldo", StringUtil.LTrimStr( A267Vacantes_Sueldo, 6, 3));
               }
               cmbVacantes_Tipo.Name = cmbVacantes_Tipo_Internalname;
               cmbVacantes_Tipo.CurrentValue = cgiGet( cmbVacantes_Tipo_Internalname);
               A268Vacantes_Tipo = (short)(NumberUtil.Val( cgiGet( cmbVacantes_Tipo_Internalname), "."));
               AssignAttri("", false, "A268Vacantes_Tipo", StringUtil.LTrimStr( (decimal)(A268Vacantes_Tipo), 4, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtVacantes_Duracion_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVacantes_Duracion_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VACANTES_DURACION");
                  AnyError = 1;
                  GX_FocusControl = edtVacantes_Duracion_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A269Vacantes_Duracion = 0;
                  AssignAttri("", false, "A269Vacantes_Duracion", StringUtil.LTrimStr( (decimal)(A269Vacantes_Duracion), 4, 0));
               }
               else
               {
                  A269Vacantes_Duracion = (short)(context.localUtil.CToN( cgiGet( edtVacantes_Duracion_Internalname), ",", "."));
                  AssignAttri("", false, "A269Vacantes_Duracion", StringUtil.LTrimStr( (decimal)(A269Vacantes_Duracion), 4, 0));
               }
               cmbVacantes_Duracion_Nom.Name = cmbVacantes_Duracion_Nom_Internalname;
               cmbVacantes_Duracion_Nom.CurrentValue = cgiGet( cmbVacantes_Duracion_Nom_Internalname);
               A270Vacantes_Duracion_Nom = (short)(NumberUtil.Val( cgiGet( cmbVacantes_Duracion_Nom_Internalname), "."));
               AssignAttri("", false, "A270Vacantes_Duracion_Nom", StringUtil.LTrimStr( (decimal)(A270Vacantes_Duracion_Nom), 4, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtVacantes_Plazas_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVacantes_Plazas_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VACANTES_PLAZAS");
                  AnyError = 1;
                  GX_FocusControl = edtVacantes_Plazas_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A277Vacantes_Plazas = 0;
                  AssignAttri("", false, "A277Vacantes_Plazas", StringUtil.LTrimStr( (decimal)(A277Vacantes_Plazas), 4, 0));
               }
               else
               {
                  A277Vacantes_Plazas = (short)(context.localUtil.CToN( cgiGet( edtVacantes_Plazas_Internalname), ",", "."));
                  AssignAttri("", false, "A277Vacantes_Plazas", StringUtil.LTrimStr( (decimal)(A277Vacantes_Plazas), 4, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Vacantes");
               A263Vacantes_Id = (int)(context.localUtil.CToN( cgiGet( edtVacantes_Id_Internalname), ",", "."));
               AssignAttri("", false, "A263Vacantes_Id", StringUtil.LTrimStr( (decimal)(A263Vacantes_Id), 9, 0));
               forbiddenHiddens.Add("Vacantes_Id", context.localUtil.Format( (decimal)(A263Vacantes_Id), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A263Vacantes_Id != Z263Vacantes_Id ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("vacantes:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A263Vacantes_Id = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri("", false, "A263Vacantes_Id", StringUtil.LTrimStr( (decimal)(A263Vacantes_Id), 9, 0));
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
                     sMode21 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode21;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound21 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0H0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "VACANTES_ID");
                        AnyError = 1;
                        GX_FocusControl = edtVacantes_Id_Internalname;
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
                           E120H2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E130H2 ();
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
            E130H2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0H21( ) ;
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
            DisableAttributes0H21( ) ;
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

      protected void CONFIRM_0H0( )
      {
         BeforeValidate0H21( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0H21( ) ;
            }
            else
            {
               CheckExtendedTable0H21( ) ;
               CloseExtendedTableCursors0H21( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode21 = Gx_mode;
            CONFIRM_0H28( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode21;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode21;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0H28( )
      {
         nGXsfl_90_idx = 0;
         while ( nGXsfl_90_idx < nRC_GXsfl_90 )
         {
            ReadRow0H28( ) ;
            if ( ( nRcdExists_28 != 0 ) || ( nIsMod_28 != 0 ) )
            {
               GetKey0H28( ) ;
               if ( ( nRcdExists_28 == 0 ) && ( nRcdDeleted_28 == 0 ) )
               {
                  if ( RcdFound28 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0H28( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0H28( ) ;
                        CloseExtendedTableCursors0H28( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "USUARIOSID_" + sGXsfl_90_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtUsuariosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound28 != 0 )
                  {
                     if ( nRcdDeleted_28 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0H28( ) ;
                        Load0H28( ) ;
                        BeforeValidate0H28( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0H28( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_28 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0H28( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0H28( ) ;
                              CloseExtendedTableCursors0H28( ) ;
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
                     if ( nRcdDeleted_28 == 0 )
                     {
                        GXCCtl = "USUARIOSID_" + sGXsfl_90_idx;
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
            ChangePostValue( cmbUsuariosVacanteEstatus_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A273UsuariosVacanteEstatus), 1, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z11UsuariosId_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11UsuariosId), 6, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z273UsuariosVacanteEstatus_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z273UsuariosVacanteEstatus), 1, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z288VacantesUsuariosFechaP_"+sGXsfl_90_idx, context.localUtil.TToC( Z288VacantesUsuariosFechaP, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z289VacantesUsuariosFechaD_"+sGXsfl_90_idx, context.localUtil.TToC( Z289VacantesUsuariosFechaD, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z313VacantesUsuariosFechaA_"+sGXsfl_90_idx, context.localUtil.TToC( Z313VacantesUsuariosFechaA, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z314VacantesUsuariosFecha3_"+sGXsfl_90_idx, context.localUtil.TToC( Z314VacantesUsuariosFecha3, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z294VacantesUsuariosMotD_"+sGXsfl_90_idx, Z294VacantesUsuariosMotD) ;
            ChangePostValue( "ZT_"+"Z290VacantesUsuariosEstatus_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z290VacantesUsuariosEstatus), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z291VacantesUsuariosPrefiltro_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z291VacantesUsuariosPrefiltro), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z292VacantesUsuariosCV_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z292VacantesUsuariosCV), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z293VacantesUsuariosExTec_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z293VacantesUsuariosExTec), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z299VacantesUsuariosCVRec_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z299VacantesUsuariosCVRec), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z300VacantesUsuariosRefLab_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z300VacantesUsuariosRefLab), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z301VacantesUsuariosExPsi_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z301VacantesUsuariosExPsi), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z302VacantesUsuariosBusWeb_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z302VacantesUsuariosBusWeb), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z303VacantesUsuariosAvPriv_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z303VacantesUsuariosAvPriv), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z304VacantesUsuariosAvConf_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z304VacantesUsuariosAvConf), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z296VacantesUsuariosDocP_"+sGXsfl_90_idx, Z296VacantesUsuariosDocP) ;
            ChangePostValue( "ZT_"+"Z297VacantesUsuariosDocCV_"+sGXsfl_90_idx, Z297VacantesUsuariosDocCV) ;
            ChangePostValue( "ZT_"+"Z298VacantesUsuariosDocTec_"+sGXsfl_90_idx, Z298VacantesUsuariosDocTec) ;
            ChangePostValue( "ZT_"+"Z295VacantesUsuariosFechaE_"+sGXsfl_90_idx, context.localUtil.TToC( Z295VacantesUsuariosFechaE, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z305VacantesUsuariosDocCVRec_"+sGXsfl_90_idx, Z305VacantesUsuariosDocCVRec) ;
            ChangePostValue( "ZT_"+"Z306VacantesUsuariosDocRefLab_"+sGXsfl_90_idx, Z306VacantesUsuariosDocRefLab) ;
            ChangePostValue( "ZT_"+"Z307VacantesUsuariosDocExPsi_"+sGXsfl_90_idx, Z307VacantesUsuariosDocExPsi) ;
            ChangePostValue( "ZT_"+"Z308VacantesUsuariosDocBusWeb_"+sGXsfl_90_idx, Z308VacantesUsuariosDocBusWeb) ;
            ChangePostValue( "ZT_"+"Z309VacantesUsuariosDocAvPriv_"+sGXsfl_90_idx, Z309VacantesUsuariosDocAvPriv) ;
            ChangePostValue( "ZT_"+"Z310VacantesUsuariosDocAvConf_"+sGXsfl_90_idx, Z310VacantesUsuariosDocAvConf) ;
            ChangePostValue( "ZT_"+"Z311VacantesUsuariosFechaEnvOp_"+sGXsfl_90_idx, context.localUtil.TToC( Z311VacantesUsuariosFechaEnvOp, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z312VacantesUsuariosFechaEnvCli_"+sGXsfl_90_idx, context.localUtil.TToC( Z312VacantesUsuariosFechaEnvCli, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z284SUBT_ReclutadorId_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z284SUBT_ReclutadorId), 6, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_28_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_28), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_28_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_28), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_28_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_28), 4, 0, ",", ""))) ;
            if ( nIsMod_28 != 0 )
            {
               ChangePostValue( "USUARIOSID_"+sGXsfl_90_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSNOMBRE_"+sGXsfl_90_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSAPPAT_"+sGXsfl_90_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosApPat_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSAPMAT_"+sGXsfl_90_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosApMat_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSVACANTEESTATUS_"+sGXsfl_90_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbUsuariosVacanteEstatus.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0H0( )
      {
      }

      protected void E120H2( )
      {
         /* Start Routine */
         if ( ! new isauthorized(context).executeUdp(  AV12Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV12Pgmname)));
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "TransactionContext", "ADMINDATA1");
      }

      protected void E130H2( )
      {
         /* After Trn Routine */
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwvacantes.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0H21( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z264Vacantes_Nombre = T000H7_A264Vacantes_Nombre[0];
               Z274Vacantes_Descripcion = T000H7_A274Vacantes_Descripcion[0];
               Z265Vacantes_Status = T000H7_A265Vacantes_Status[0];
               Z266Vacantes_FechaInicio = T000H7_A266Vacantes_FechaInicio[0];
               Z267Vacantes_Sueldo = T000H7_A267Vacantes_Sueldo[0];
               Z268Vacantes_Tipo = T000H7_A268Vacantes_Tipo[0];
               Z269Vacantes_Duracion = T000H7_A269Vacantes_Duracion[0];
               Z270Vacantes_Duracion_Nom = T000H7_A270Vacantes_Duracion_Nom[0];
               Z277Vacantes_Plazas = T000H7_A277Vacantes_Plazas[0];
            }
            else
            {
               Z264Vacantes_Nombre = A264Vacantes_Nombre;
               Z274Vacantes_Descripcion = A274Vacantes_Descripcion;
               Z265Vacantes_Status = A265Vacantes_Status;
               Z266Vacantes_FechaInicio = A266Vacantes_FechaInicio;
               Z267Vacantes_Sueldo = A267Vacantes_Sueldo;
               Z268Vacantes_Tipo = A268Vacantes_Tipo;
               Z269Vacantes_Duracion = A269Vacantes_Duracion;
               Z270Vacantes_Duracion_Nom = A270Vacantes_Duracion_Nom;
               Z277Vacantes_Plazas = A277Vacantes_Plazas;
            }
         }
         if ( GX_JID == -5 )
         {
            Z263Vacantes_Id = A263Vacantes_Id;
            Z264Vacantes_Nombre = A264Vacantes_Nombre;
            Z274Vacantes_Descripcion = A274Vacantes_Descripcion;
            Z265Vacantes_Status = A265Vacantes_Status;
            Z266Vacantes_FechaInicio = A266Vacantes_FechaInicio;
            Z267Vacantes_Sueldo = A267Vacantes_Sueldo;
            Z268Vacantes_Tipo = A268Vacantes_Tipo;
            Z269Vacantes_Duracion = A269Vacantes_Duracion;
            Z270Vacantes_Duracion_Nom = A270Vacantes_Duracion_Nom;
            Z277Vacantes_Plazas = A277Vacantes_Plazas;
         }
      }

      protected void standaloneNotModal( )
      {
         edtVacantes_Id_Enabled = 0;
         AssignProp("", false, edtVacantes_Id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVacantes_Id_Enabled), 5, 0), true);
         edtVacantes_Id_Enabled = 0;
         AssignProp("", false, edtVacantes_Id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVacantes_Id_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7Vacantes_Id) )
         {
            A263Vacantes_Id = AV7Vacantes_Id;
            AssignAttri("", false, "A263Vacantes_Id", StringUtil.LTrimStr( (decimal)(A263Vacantes_Id), 9, 0));
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

      protected void Load0H21( )
      {
         /* Using cursor T000H8 */
         pr_default.execute(6, new Object[] {A263Vacantes_Id});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound21 = 1;
            A264Vacantes_Nombre = T000H8_A264Vacantes_Nombre[0];
            AssignAttri("", false, "A264Vacantes_Nombre", A264Vacantes_Nombre);
            A274Vacantes_Descripcion = T000H8_A274Vacantes_Descripcion[0];
            AssignAttri("", false, "A274Vacantes_Descripcion", A274Vacantes_Descripcion);
            A265Vacantes_Status = T000H8_A265Vacantes_Status[0];
            AssignAttri("", false, "A265Vacantes_Status", StringUtil.LTrimStr( (decimal)(A265Vacantes_Status), 4, 0));
            A266Vacantes_FechaInicio = T000H8_A266Vacantes_FechaInicio[0];
            AssignAttri("", false, "A266Vacantes_FechaInicio", context.localUtil.Format(A266Vacantes_FechaInicio, "99/99/99"));
            A267Vacantes_Sueldo = T000H8_A267Vacantes_Sueldo[0];
            AssignAttri("", false, "A267Vacantes_Sueldo", StringUtil.LTrimStr( A267Vacantes_Sueldo, 6, 3));
            A268Vacantes_Tipo = T000H8_A268Vacantes_Tipo[0];
            AssignAttri("", false, "A268Vacantes_Tipo", StringUtil.LTrimStr( (decimal)(A268Vacantes_Tipo), 4, 0));
            A269Vacantes_Duracion = T000H8_A269Vacantes_Duracion[0];
            AssignAttri("", false, "A269Vacantes_Duracion", StringUtil.LTrimStr( (decimal)(A269Vacantes_Duracion), 4, 0));
            A270Vacantes_Duracion_Nom = T000H8_A270Vacantes_Duracion_Nom[0];
            AssignAttri("", false, "A270Vacantes_Duracion_Nom", StringUtil.LTrimStr( (decimal)(A270Vacantes_Duracion_Nom), 4, 0));
            A277Vacantes_Plazas = T000H8_A277Vacantes_Plazas[0];
            AssignAttri("", false, "A277Vacantes_Plazas", StringUtil.LTrimStr( (decimal)(A277Vacantes_Plazas), 4, 0));
            ZM0H21( -5) ;
         }
         pr_default.close(6);
         OnLoadActions0H21( ) ;
      }

      protected void OnLoadActions0H21( )
      {
         AV12Pgmname = "Vacantes";
         AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
      }

      protected void CheckExtendedTable0H21( )
      {
         nIsDirty_21 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV12Pgmname = "Vacantes";
         AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
         if ( ! ( (DateTime.MinValue==A266Vacantes_FechaInicio) || ( A266Vacantes_FechaInicio >= context.localUtil.YMDToD( 1000, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Inicio fuera de rango", "OutOfRange", 1, "VACANTES_FECHAINICIO");
            AnyError = 1;
            GX_FocusControl = edtVacantes_FechaInicio_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0H21( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0H21( )
      {
         /* Using cursor T000H9 */
         pr_default.execute(7, new Object[] {A263Vacantes_Id});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound21 = 1;
         }
         else
         {
            RcdFound21 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000H7 */
         pr_default.execute(5, new Object[] {A263Vacantes_Id});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM0H21( 5) ;
            RcdFound21 = 1;
            A263Vacantes_Id = T000H7_A263Vacantes_Id[0];
            AssignAttri("", false, "A263Vacantes_Id", StringUtil.LTrimStr( (decimal)(A263Vacantes_Id), 9, 0));
            A264Vacantes_Nombre = T000H7_A264Vacantes_Nombre[0];
            AssignAttri("", false, "A264Vacantes_Nombre", A264Vacantes_Nombre);
            A274Vacantes_Descripcion = T000H7_A274Vacantes_Descripcion[0];
            AssignAttri("", false, "A274Vacantes_Descripcion", A274Vacantes_Descripcion);
            A265Vacantes_Status = T000H7_A265Vacantes_Status[0];
            AssignAttri("", false, "A265Vacantes_Status", StringUtil.LTrimStr( (decimal)(A265Vacantes_Status), 4, 0));
            A266Vacantes_FechaInicio = T000H7_A266Vacantes_FechaInicio[0];
            AssignAttri("", false, "A266Vacantes_FechaInicio", context.localUtil.Format(A266Vacantes_FechaInicio, "99/99/99"));
            A267Vacantes_Sueldo = T000H7_A267Vacantes_Sueldo[0];
            AssignAttri("", false, "A267Vacantes_Sueldo", StringUtil.LTrimStr( A267Vacantes_Sueldo, 6, 3));
            A268Vacantes_Tipo = T000H7_A268Vacantes_Tipo[0];
            AssignAttri("", false, "A268Vacantes_Tipo", StringUtil.LTrimStr( (decimal)(A268Vacantes_Tipo), 4, 0));
            A269Vacantes_Duracion = T000H7_A269Vacantes_Duracion[0];
            AssignAttri("", false, "A269Vacantes_Duracion", StringUtil.LTrimStr( (decimal)(A269Vacantes_Duracion), 4, 0));
            A270Vacantes_Duracion_Nom = T000H7_A270Vacantes_Duracion_Nom[0];
            AssignAttri("", false, "A270Vacantes_Duracion_Nom", StringUtil.LTrimStr( (decimal)(A270Vacantes_Duracion_Nom), 4, 0));
            A277Vacantes_Plazas = T000H7_A277Vacantes_Plazas[0];
            AssignAttri("", false, "A277Vacantes_Plazas", StringUtil.LTrimStr( (decimal)(A277Vacantes_Plazas), 4, 0));
            Z263Vacantes_Id = A263Vacantes_Id;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0H21( ) ;
            if ( AnyError == 1 )
            {
               RcdFound21 = 0;
               InitializeNonKey0H21( ) ;
            }
            Gx_mode = sMode21;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound21 = 0;
            InitializeNonKey0H21( ) ;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode21;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey0H21( ) ;
         if ( RcdFound21 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound21 = 0;
         /* Using cursor T000H10 */
         pr_default.execute(8, new Object[] {A263Vacantes_Id});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000H10_A263Vacantes_Id[0] < A263Vacantes_Id ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000H10_A263Vacantes_Id[0] > A263Vacantes_Id ) ) )
            {
               A263Vacantes_Id = T000H10_A263Vacantes_Id[0];
               AssignAttri("", false, "A263Vacantes_Id", StringUtil.LTrimStr( (decimal)(A263Vacantes_Id), 9, 0));
               RcdFound21 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound21 = 0;
         /* Using cursor T000H11 */
         pr_default.execute(9, new Object[] {A263Vacantes_Id});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000H11_A263Vacantes_Id[0] > A263Vacantes_Id ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000H11_A263Vacantes_Id[0] < A263Vacantes_Id ) ) )
            {
               A263Vacantes_Id = T000H11_A263Vacantes_Id[0];
               AssignAttri("", false, "A263Vacantes_Id", StringUtil.LTrimStr( (decimal)(A263Vacantes_Id), 9, 0));
               RcdFound21 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0H21( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtVacantes_Nombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0H21( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound21 == 1 )
            {
               if ( A263Vacantes_Id != Z263Vacantes_Id )
               {
                  A263Vacantes_Id = Z263Vacantes_Id;
                  AssignAttri("", false, "A263Vacantes_Id", StringUtil.LTrimStr( (decimal)(A263Vacantes_Id), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "VACANTES_ID");
                  AnyError = 1;
                  GX_FocusControl = edtVacantes_Id_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtVacantes_Nombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0H21( ) ;
                  GX_FocusControl = edtVacantes_Nombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A263Vacantes_Id != Z263Vacantes_Id )
               {
                  /* Insert record */
                  GX_FocusControl = edtVacantes_Nombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0H21( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "VACANTES_ID");
                     AnyError = 1;
                     GX_FocusControl = edtVacantes_Id_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtVacantes_Nombre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0H21( ) ;
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
         if ( A263Vacantes_Id != Z263Vacantes_Id )
         {
            A263Vacantes_Id = Z263Vacantes_Id;
            AssignAttri("", false, "A263Vacantes_Id", StringUtil.LTrimStr( (decimal)(A263Vacantes_Id), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "VACANTES_ID");
            AnyError = 1;
            GX_FocusControl = edtVacantes_Id_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtVacantes_Nombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0H21( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000H6 */
            pr_default.execute(4, new Object[] {A263Vacantes_Id});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Vacantes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(4) == 101) || ( StringUtil.StrCmp(Z264Vacantes_Nombre, T000H6_A264Vacantes_Nombre[0]) != 0 ) || ( StringUtil.StrCmp(Z274Vacantes_Descripcion, T000H6_A274Vacantes_Descripcion[0]) != 0 ) || ( Z265Vacantes_Status != T000H6_A265Vacantes_Status[0] ) || ( Z266Vacantes_FechaInicio != T000H6_A266Vacantes_FechaInicio[0] ) || ( Z267Vacantes_Sueldo != T000H6_A267Vacantes_Sueldo[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z268Vacantes_Tipo != T000H6_A268Vacantes_Tipo[0] ) || ( Z269Vacantes_Duracion != T000H6_A269Vacantes_Duracion[0] ) || ( Z270Vacantes_Duracion_Nom != T000H6_A270Vacantes_Duracion_Nom[0] ) || ( Z277Vacantes_Plazas != T000H6_A277Vacantes_Plazas[0] ) )
            {
               if ( StringUtil.StrCmp(Z264Vacantes_Nombre, T000H6_A264Vacantes_Nombre[0]) != 0 )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"Vacantes_Nombre");
                  GXUtil.WriteLogRaw("Old: ",Z264Vacantes_Nombre);
                  GXUtil.WriteLogRaw("Current: ",T000H6_A264Vacantes_Nombre[0]);
               }
               if ( StringUtil.StrCmp(Z274Vacantes_Descripcion, T000H6_A274Vacantes_Descripcion[0]) != 0 )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"Vacantes_Descripcion");
                  GXUtil.WriteLogRaw("Old: ",Z274Vacantes_Descripcion);
                  GXUtil.WriteLogRaw("Current: ",T000H6_A274Vacantes_Descripcion[0]);
               }
               if ( Z265Vacantes_Status != T000H6_A265Vacantes_Status[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"Vacantes_Status");
                  GXUtil.WriteLogRaw("Old: ",Z265Vacantes_Status);
                  GXUtil.WriteLogRaw("Current: ",T000H6_A265Vacantes_Status[0]);
               }
               if ( Z266Vacantes_FechaInicio != T000H6_A266Vacantes_FechaInicio[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"Vacantes_FechaInicio");
                  GXUtil.WriteLogRaw("Old: ",Z266Vacantes_FechaInicio);
                  GXUtil.WriteLogRaw("Current: ",T000H6_A266Vacantes_FechaInicio[0]);
               }
               if ( Z267Vacantes_Sueldo != T000H6_A267Vacantes_Sueldo[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"Vacantes_Sueldo");
                  GXUtil.WriteLogRaw("Old: ",Z267Vacantes_Sueldo);
                  GXUtil.WriteLogRaw("Current: ",T000H6_A267Vacantes_Sueldo[0]);
               }
               if ( Z268Vacantes_Tipo != T000H6_A268Vacantes_Tipo[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"Vacantes_Tipo");
                  GXUtil.WriteLogRaw("Old: ",Z268Vacantes_Tipo);
                  GXUtil.WriteLogRaw("Current: ",T000H6_A268Vacantes_Tipo[0]);
               }
               if ( Z269Vacantes_Duracion != T000H6_A269Vacantes_Duracion[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"Vacantes_Duracion");
                  GXUtil.WriteLogRaw("Old: ",Z269Vacantes_Duracion);
                  GXUtil.WriteLogRaw("Current: ",T000H6_A269Vacantes_Duracion[0]);
               }
               if ( Z270Vacantes_Duracion_Nom != T000H6_A270Vacantes_Duracion_Nom[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"Vacantes_Duracion_Nom");
                  GXUtil.WriteLogRaw("Old: ",Z270Vacantes_Duracion_Nom);
                  GXUtil.WriteLogRaw("Current: ",T000H6_A270Vacantes_Duracion_Nom[0]);
               }
               if ( Z277Vacantes_Plazas != T000H6_A277Vacantes_Plazas[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"Vacantes_Plazas");
                  GXUtil.WriteLogRaw("Old: ",Z277Vacantes_Plazas);
                  GXUtil.WriteLogRaw("Current: ",T000H6_A277Vacantes_Plazas[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Vacantes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0H21( )
      {
         BeforeValidate0H21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H21( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0H21( 0) ;
            CheckOptimisticConcurrency0H21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0H21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000H12 */
                     pr_default.execute(10, new Object[] {A264Vacantes_Nombre, A274Vacantes_Descripcion, A265Vacantes_Status, A266Vacantes_FechaInicio, A267Vacantes_Sueldo, A268Vacantes_Tipo, A269Vacantes_Duracion, A270Vacantes_Duracion_Nom, A277Vacantes_Plazas});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000H13 */
                     pr_default.execute(11);
                     A263Vacantes_Id = T000H13_A263Vacantes_Id[0];
                     AssignAttri("", false, "A263Vacantes_Id", StringUtil.LTrimStr( (decimal)(A263Vacantes_Id), 9, 0));
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("Vacantes") ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0H21( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0H0( ) ;
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
               Load0H21( ) ;
            }
            EndLevel0H21( ) ;
         }
         CloseExtendedTableCursors0H21( ) ;
      }

      protected void Update0H21( )
      {
         BeforeValidate0H21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H21( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0H21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000H14 */
                     pr_default.execute(12, new Object[] {A264Vacantes_Nombre, A274Vacantes_Descripcion, A265Vacantes_Status, A266Vacantes_FechaInicio, A267Vacantes_Sueldo, A268Vacantes_Tipo, A269Vacantes_Duracion, A270Vacantes_Duracion_Nom, A277Vacantes_Plazas, A263Vacantes_Id});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("Vacantes") ;
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Vacantes"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0H21( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0H21( ) ;
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
            EndLevel0H21( ) ;
         }
         CloseExtendedTableCursors0H21( ) ;
      }

      protected void DeferredUpdate0H21( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0H21( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H21( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0H21( ) ;
            AfterConfirm0H21( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0H21( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0H28( ) ;
                  while ( RcdFound28 != 0 )
                  {
                     getByPrimaryKey0H28( ) ;
                     Delete0H28( ) ;
                     ScanNext0H28( ) ;
                  }
                  ScanEnd0H28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000H15 */
                     pr_default.execute(13, new Object[] {A263Vacantes_Id});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("Vacantes") ;
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
         sMode21 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0H21( ) ;
         Gx_mode = sMode21;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0H21( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV12Pgmname = "Vacantes";
            AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
         }
      }

      protected void ProcessNestedLevel0H28( )
      {
         nGXsfl_90_idx = 0;
         while ( nGXsfl_90_idx < nRC_GXsfl_90 )
         {
            ReadRow0H28( ) ;
            if ( ( nRcdExists_28 != 0 ) || ( nIsMod_28 != 0 ) )
            {
               standaloneNotModal0H28( ) ;
               GetKey0H28( ) ;
               if ( ( nRcdExists_28 == 0 ) && ( nRcdDeleted_28 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0H28( ) ;
               }
               else
               {
                  if ( RcdFound28 != 0 )
                  {
                     if ( ( nRcdDeleted_28 != 0 ) && ( nRcdExists_28 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0H28( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_28 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0H28( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_28 == 0 )
                     {
                        GXCCtl = "USUARIOSID_" + sGXsfl_90_idx;
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
            ChangePostValue( cmbUsuariosVacanteEstatus_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A273UsuariosVacanteEstatus), 1, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z11UsuariosId_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11UsuariosId), 6, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z273UsuariosVacanteEstatus_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z273UsuariosVacanteEstatus), 1, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z288VacantesUsuariosFechaP_"+sGXsfl_90_idx, context.localUtil.TToC( Z288VacantesUsuariosFechaP, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z289VacantesUsuariosFechaD_"+sGXsfl_90_idx, context.localUtil.TToC( Z289VacantesUsuariosFechaD, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z313VacantesUsuariosFechaA_"+sGXsfl_90_idx, context.localUtil.TToC( Z313VacantesUsuariosFechaA, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z314VacantesUsuariosFecha3_"+sGXsfl_90_idx, context.localUtil.TToC( Z314VacantesUsuariosFecha3, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z294VacantesUsuariosMotD_"+sGXsfl_90_idx, Z294VacantesUsuariosMotD) ;
            ChangePostValue( "ZT_"+"Z290VacantesUsuariosEstatus_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z290VacantesUsuariosEstatus), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z291VacantesUsuariosPrefiltro_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z291VacantesUsuariosPrefiltro), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z292VacantesUsuariosCV_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z292VacantesUsuariosCV), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z293VacantesUsuariosExTec_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z293VacantesUsuariosExTec), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z299VacantesUsuariosCVRec_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z299VacantesUsuariosCVRec), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z300VacantesUsuariosRefLab_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z300VacantesUsuariosRefLab), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z301VacantesUsuariosExPsi_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z301VacantesUsuariosExPsi), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z302VacantesUsuariosBusWeb_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z302VacantesUsuariosBusWeb), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z303VacantesUsuariosAvPriv_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z303VacantesUsuariosAvPriv), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z304VacantesUsuariosAvConf_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z304VacantesUsuariosAvConf), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z296VacantesUsuariosDocP_"+sGXsfl_90_idx, Z296VacantesUsuariosDocP) ;
            ChangePostValue( "ZT_"+"Z297VacantesUsuariosDocCV_"+sGXsfl_90_idx, Z297VacantesUsuariosDocCV) ;
            ChangePostValue( "ZT_"+"Z298VacantesUsuariosDocTec_"+sGXsfl_90_idx, Z298VacantesUsuariosDocTec) ;
            ChangePostValue( "ZT_"+"Z295VacantesUsuariosFechaE_"+sGXsfl_90_idx, context.localUtil.TToC( Z295VacantesUsuariosFechaE, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z305VacantesUsuariosDocCVRec_"+sGXsfl_90_idx, Z305VacantesUsuariosDocCVRec) ;
            ChangePostValue( "ZT_"+"Z306VacantesUsuariosDocRefLab_"+sGXsfl_90_idx, Z306VacantesUsuariosDocRefLab) ;
            ChangePostValue( "ZT_"+"Z307VacantesUsuariosDocExPsi_"+sGXsfl_90_idx, Z307VacantesUsuariosDocExPsi) ;
            ChangePostValue( "ZT_"+"Z308VacantesUsuariosDocBusWeb_"+sGXsfl_90_idx, Z308VacantesUsuariosDocBusWeb) ;
            ChangePostValue( "ZT_"+"Z309VacantesUsuariosDocAvPriv_"+sGXsfl_90_idx, Z309VacantesUsuariosDocAvPriv) ;
            ChangePostValue( "ZT_"+"Z310VacantesUsuariosDocAvConf_"+sGXsfl_90_idx, Z310VacantesUsuariosDocAvConf) ;
            ChangePostValue( "ZT_"+"Z311VacantesUsuariosFechaEnvOp_"+sGXsfl_90_idx, context.localUtil.TToC( Z311VacantesUsuariosFechaEnvOp, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z312VacantesUsuariosFechaEnvCli_"+sGXsfl_90_idx, context.localUtil.TToC( Z312VacantesUsuariosFechaEnvCli, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z284SUBT_ReclutadorId_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z284SUBT_ReclutadorId), 6, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_28_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_28), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_28_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_28), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_28_"+sGXsfl_90_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_28), 4, 0, ",", ""))) ;
            if ( nIsMod_28 != 0 )
            {
               ChangePostValue( "USUARIOSID_"+sGXsfl_90_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSNOMBRE_"+sGXsfl_90_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSAPPAT_"+sGXsfl_90_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosApPat_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSAPMAT_"+sGXsfl_90_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosApMat_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSVACANTEESTATUS_"+sGXsfl_90_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbUsuariosVacanteEstatus.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0H28( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_28 = 0;
         nIsMod_28 = 0;
         nRcdDeleted_28 = 0;
      }

      protected void ProcessLevel0H21( )
      {
         /* Save parent mode. */
         sMode21 = Gx_mode;
         ProcessNestedLevel0H28( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode21;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0H21( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0H21( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("vacantes",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0H0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("vacantes",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0H21( )
      {
         /* Scan By routine */
         /* Using cursor T000H16 */
         pr_default.execute(14);
         RcdFound21 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound21 = 1;
            A263Vacantes_Id = T000H16_A263Vacantes_Id[0];
            AssignAttri("", false, "A263Vacantes_Id", StringUtil.LTrimStr( (decimal)(A263Vacantes_Id), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0H21( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound21 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound21 = 1;
            A263Vacantes_Id = T000H16_A263Vacantes_Id[0];
            AssignAttri("", false, "A263Vacantes_Id", StringUtil.LTrimStr( (decimal)(A263Vacantes_Id), 9, 0));
         }
      }

      protected void ScanEnd0H21( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0H21( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0H21( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0H21( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0H21( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0H21( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0H21( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0H21( )
      {
         edtVacantes_Id_Enabled = 0;
         AssignProp("", false, edtVacantes_Id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVacantes_Id_Enabled), 5, 0), true);
         edtVacantes_Nombre_Enabled = 0;
         AssignProp("", false, edtVacantes_Nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVacantes_Nombre_Enabled), 5, 0), true);
         edtVacantes_Descripcion_Enabled = 0;
         AssignProp("", false, edtVacantes_Descripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVacantes_Descripcion_Enabled), 5, 0), true);
         cmbVacantes_Status.Enabled = 0;
         AssignProp("", false, cmbVacantes_Status_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbVacantes_Status.Enabled), 5, 0), true);
         edtVacantes_FechaInicio_Enabled = 0;
         AssignProp("", false, edtVacantes_FechaInicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVacantes_FechaInicio_Enabled), 5, 0), true);
         edtVacantes_Sueldo_Enabled = 0;
         AssignProp("", false, edtVacantes_Sueldo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVacantes_Sueldo_Enabled), 5, 0), true);
         cmbVacantes_Tipo.Enabled = 0;
         AssignProp("", false, cmbVacantes_Tipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbVacantes_Tipo.Enabled), 5, 0), true);
         edtVacantes_Duracion_Enabled = 0;
         AssignProp("", false, edtVacantes_Duracion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVacantes_Duracion_Enabled), 5, 0), true);
         cmbVacantes_Duracion_Nom.Enabled = 0;
         AssignProp("", false, cmbVacantes_Duracion_Nom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbVacantes_Duracion_Nom.Enabled), 5, 0), true);
         edtVacantes_Plazas_Enabled = 0;
         AssignProp("", false, edtVacantes_Plazas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVacantes_Plazas_Enabled), 5, 0), true);
      }

      protected void ZM0H28( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z273UsuariosVacanteEstatus = T000H3_A273UsuariosVacanteEstatus[0];
               Z288VacantesUsuariosFechaP = T000H3_A288VacantesUsuariosFechaP[0];
               Z289VacantesUsuariosFechaD = T000H3_A289VacantesUsuariosFechaD[0];
               Z313VacantesUsuariosFechaA = T000H3_A313VacantesUsuariosFechaA[0];
               Z314VacantesUsuariosFecha3 = T000H3_A314VacantesUsuariosFecha3[0];
               Z294VacantesUsuariosMotD = T000H3_A294VacantesUsuariosMotD[0];
               Z290VacantesUsuariosEstatus = T000H3_A290VacantesUsuariosEstatus[0];
               Z291VacantesUsuariosPrefiltro = T000H3_A291VacantesUsuariosPrefiltro[0];
               Z292VacantesUsuariosCV = T000H3_A292VacantesUsuariosCV[0];
               Z293VacantesUsuariosExTec = T000H3_A293VacantesUsuariosExTec[0];
               Z299VacantesUsuariosCVRec = T000H3_A299VacantesUsuariosCVRec[0];
               Z300VacantesUsuariosRefLab = T000H3_A300VacantesUsuariosRefLab[0];
               Z301VacantesUsuariosExPsi = T000H3_A301VacantesUsuariosExPsi[0];
               Z302VacantesUsuariosBusWeb = T000H3_A302VacantesUsuariosBusWeb[0];
               Z303VacantesUsuariosAvPriv = T000H3_A303VacantesUsuariosAvPriv[0];
               Z304VacantesUsuariosAvConf = T000H3_A304VacantesUsuariosAvConf[0];
               Z296VacantesUsuariosDocP = T000H3_A296VacantesUsuariosDocP[0];
               Z297VacantesUsuariosDocCV = T000H3_A297VacantesUsuariosDocCV[0];
               Z298VacantesUsuariosDocTec = T000H3_A298VacantesUsuariosDocTec[0];
               Z295VacantesUsuariosFechaE = T000H3_A295VacantesUsuariosFechaE[0];
               Z305VacantesUsuariosDocCVRec = T000H3_A305VacantesUsuariosDocCVRec[0];
               Z306VacantesUsuariosDocRefLab = T000H3_A306VacantesUsuariosDocRefLab[0];
               Z307VacantesUsuariosDocExPsi = T000H3_A307VacantesUsuariosDocExPsi[0];
               Z308VacantesUsuariosDocBusWeb = T000H3_A308VacantesUsuariosDocBusWeb[0];
               Z309VacantesUsuariosDocAvPriv = T000H3_A309VacantesUsuariosDocAvPriv[0];
               Z310VacantesUsuariosDocAvConf = T000H3_A310VacantesUsuariosDocAvConf[0];
               Z311VacantesUsuariosFechaEnvOp = T000H3_A311VacantesUsuariosFechaEnvOp[0];
               Z312VacantesUsuariosFechaEnvCli = T000H3_A312VacantesUsuariosFechaEnvCli[0];
               Z284SUBT_ReclutadorId = T000H3_A284SUBT_ReclutadorId[0];
            }
            else
            {
               Z273UsuariosVacanteEstatus = A273UsuariosVacanteEstatus;
               Z288VacantesUsuariosFechaP = A288VacantesUsuariosFechaP;
               Z289VacantesUsuariosFechaD = A289VacantesUsuariosFechaD;
               Z313VacantesUsuariosFechaA = A313VacantesUsuariosFechaA;
               Z314VacantesUsuariosFecha3 = A314VacantesUsuariosFecha3;
               Z294VacantesUsuariosMotD = A294VacantesUsuariosMotD;
               Z290VacantesUsuariosEstatus = A290VacantesUsuariosEstatus;
               Z291VacantesUsuariosPrefiltro = A291VacantesUsuariosPrefiltro;
               Z292VacantesUsuariosCV = A292VacantesUsuariosCV;
               Z293VacantesUsuariosExTec = A293VacantesUsuariosExTec;
               Z299VacantesUsuariosCVRec = A299VacantesUsuariosCVRec;
               Z300VacantesUsuariosRefLab = A300VacantesUsuariosRefLab;
               Z301VacantesUsuariosExPsi = A301VacantesUsuariosExPsi;
               Z302VacantesUsuariosBusWeb = A302VacantesUsuariosBusWeb;
               Z303VacantesUsuariosAvPriv = A303VacantesUsuariosAvPriv;
               Z304VacantesUsuariosAvConf = A304VacantesUsuariosAvConf;
               Z296VacantesUsuariosDocP = A296VacantesUsuariosDocP;
               Z297VacantesUsuariosDocCV = A297VacantesUsuariosDocCV;
               Z298VacantesUsuariosDocTec = A298VacantesUsuariosDocTec;
               Z295VacantesUsuariosFechaE = A295VacantesUsuariosFechaE;
               Z305VacantesUsuariosDocCVRec = A305VacantesUsuariosDocCVRec;
               Z306VacantesUsuariosDocRefLab = A306VacantesUsuariosDocRefLab;
               Z307VacantesUsuariosDocExPsi = A307VacantesUsuariosDocExPsi;
               Z308VacantesUsuariosDocBusWeb = A308VacantesUsuariosDocBusWeb;
               Z309VacantesUsuariosDocAvPriv = A309VacantesUsuariosDocAvPriv;
               Z310VacantesUsuariosDocAvConf = A310VacantesUsuariosDocAvConf;
               Z311VacantesUsuariosFechaEnvOp = A311VacantesUsuariosFechaEnvOp;
               Z312VacantesUsuariosFechaEnvCli = A312VacantesUsuariosFechaEnvCli;
               Z284SUBT_ReclutadorId = A284SUBT_ReclutadorId;
            }
         }
         if ( GX_JID == -6 )
         {
            Z263Vacantes_Id = A263Vacantes_Id;
            Z273UsuariosVacanteEstatus = A273UsuariosVacanteEstatus;
            Z288VacantesUsuariosFechaP = A288VacantesUsuariosFechaP;
            Z289VacantesUsuariosFechaD = A289VacantesUsuariosFechaD;
            Z313VacantesUsuariosFechaA = A313VacantesUsuariosFechaA;
            Z314VacantesUsuariosFecha3 = A314VacantesUsuariosFecha3;
            Z294VacantesUsuariosMotD = A294VacantesUsuariosMotD;
            Z290VacantesUsuariosEstatus = A290VacantesUsuariosEstatus;
            Z291VacantesUsuariosPrefiltro = A291VacantesUsuariosPrefiltro;
            Z292VacantesUsuariosCV = A292VacantesUsuariosCV;
            Z293VacantesUsuariosExTec = A293VacantesUsuariosExTec;
            Z299VacantesUsuariosCVRec = A299VacantesUsuariosCVRec;
            Z300VacantesUsuariosRefLab = A300VacantesUsuariosRefLab;
            Z301VacantesUsuariosExPsi = A301VacantesUsuariosExPsi;
            Z302VacantesUsuariosBusWeb = A302VacantesUsuariosBusWeb;
            Z303VacantesUsuariosAvPriv = A303VacantesUsuariosAvPriv;
            Z304VacantesUsuariosAvConf = A304VacantesUsuariosAvConf;
            Z296VacantesUsuariosDocP = A296VacantesUsuariosDocP;
            Z297VacantesUsuariosDocCV = A297VacantesUsuariosDocCV;
            Z298VacantesUsuariosDocTec = A298VacantesUsuariosDocTec;
            Z295VacantesUsuariosFechaE = A295VacantesUsuariosFechaE;
            Z305VacantesUsuariosDocCVRec = A305VacantesUsuariosDocCVRec;
            Z306VacantesUsuariosDocRefLab = A306VacantesUsuariosDocRefLab;
            Z307VacantesUsuariosDocExPsi = A307VacantesUsuariosDocExPsi;
            Z308VacantesUsuariosDocBusWeb = A308VacantesUsuariosDocBusWeb;
            Z309VacantesUsuariosDocAvPriv = A309VacantesUsuariosDocAvPriv;
            Z310VacantesUsuariosDocAvConf = A310VacantesUsuariosDocAvConf;
            Z311VacantesUsuariosFechaEnvOp = A311VacantesUsuariosFechaEnvOp;
            Z312VacantesUsuariosFechaEnvCli = A312VacantesUsuariosFechaEnvCli;
            Z11UsuariosId = A11UsuariosId;
            Z284SUBT_ReclutadorId = A284SUBT_ReclutadorId;
            Z66UsuariosNombre = A66UsuariosNombre;
            Z65UsuariosApPat = A65UsuariosApPat;
            Z64UsuariosApMat = A64UsuariosApMat;
         }
      }

      protected void standaloneNotModal0H28( )
      {
      }

      protected void standaloneModal0H28( )
      {
         /* Using cursor T000H5 */
         pr_default.execute(3, new Object[] {A284SUBT_ReclutadorId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'SUBT_Reclutador'.", "ForeignKeyNotFound", 1, "");
            AnyError = 1;
         }
         pr_default.close(3);
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtUsuariosId_Enabled = 0;
            AssignProp("", false, edtUsuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosId_Enabled), 5, 0), !bGXsfl_90_Refreshing);
         }
         else
         {
            edtUsuariosId_Enabled = 1;
            AssignProp("", false, edtUsuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosId_Enabled), 5, 0), !bGXsfl_90_Refreshing);
         }
      }

      protected void Load0H28( )
      {
         /* Using cursor T000H17 */
         pr_default.execute(15, new Object[] {A263Vacantes_Id, A11UsuariosId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound28 = 1;
            A66UsuariosNombre = T000H17_A66UsuariosNombre[0];
            A65UsuariosApPat = T000H17_A65UsuariosApPat[0];
            A64UsuariosApMat = T000H17_A64UsuariosApMat[0];
            A273UsuariosVacanteEstatus = T000H17_A273UsuariosVacanteEstatus[0];
            A288VacantesUsuariosFechaP = T000H17_A288VacantesUsuariosFechaP[0];
            A289VacantesUsuariosFechaD = T000H17_A289VacantesUsuariosFechaD[0];
            n289VacantesUsuariosFechaD = T000H17_n289VacantesUsuariosFechaD[0];
            A313VacantesUsuariosFechaA = T000H17_A313VacantesUsuariosFechaA[0];
            n313VacantesUsuariosFechaA = T000H17_n313VacantesUsuariosFechaA[0];
            A314VacantesUsuariosFecha3 = T000H17_A314VacantesUsuariosFecha3[0];
            n314VacantesUsuariosFecha3 = T000H17_n314VacantesUsuariosFecha3[0];
            A294VacantesUsuariosMotD = T000H17_A294VacantesUsuariosMotD[0];
            n294VacantesUsuariosMotD = T000H17_n294VacantesUsuariosMotD[0];
            A290VacantesUsuariosEstatus = T000H17_A290VacantesUsuariosEstatus[0];
            n290VacantesUsuariosEstatus = T000H17_n290VacantesUsuariosEstatus[0];
            A291VacantesUsuariosPrefiltro = T000H17_A291VacantesUsuariosPrefiltro[0];
            n291VacantesUsuariosPrefiltro = T000H17_n291VacantesUsuariosPrefiltro[0];
            A292VacantesUsuariosCV = T000H17_A292VacantesUsuariosCV[0];
            n292VacantesUsuariosCV = T000H17_n292VacantesUsuariosCV[0];
            A293VacantesUsuariosExTec = T000H17_A293VacantesUsuariosExTec[0];
            n293VacantesUsuariosExTec = T000H17_n293VacantesUsuariosExTec[0];
            A299VacantesUsuariosCVRec = T000H17_A299VacantesUsuariosCVRec[0];
            n299VacantesUsuariosCVRec = T000H17_n299VacantesUsuariosCVRec[0];
            A300VacantesUsuariosRefLab = T000H17_A300VacantesUsuariosRefLab[0];
            n300VacantesUsuariosRefLab = T000H17_n300VacantesUsuariosRefLab[0];
            A301VacantesUsuariosExPsi = T000H17_A301VacantesUsuariosExPsi[0];
            n301VacantesUsuariosExPsi = T000H17_n301VacantesUsuariosExPsi[0];
            A302VacantesUsuariosBusWeb = T000H17_A302VacantesUsuariosBusWeb[0];
            n302VacantesUsuariosBusWeb = T000H17_n302VacantesUsuariosBusWeb[0];
            A303VacantesUsuariosAvPriv = T000H17_A303VacantesUsuariosAvPriv[0];
            n303VacantesUsuariosAvPriv = T000H17_n303VacantesUsuariosAvPriv[0];
            A304VacantesUsuariosAvConf = T000H17_A304VacantesUsuariosAvConf[0];
            n304VacantesUsuariosAvConf = T000H17_n304VacantesUsuariosAvConf[0];
            A296VacantesUsuariosDocP = T000H17_A296VacantesUsuariosDocP[0];
            n296VacantesUsuariosDocP = T000H17_n296VacantesUsuariosDocP[0];
            A297VacantesUsuariosDocCV = T000H17_A297VacantesUsuariosDocCV[0];
            n297VacantesUsuariosDocCV = T000H17_n297VacantesUsuariosDocCV[0];
            A298VacantesUsuariosDocTec = T000H17_A298VacantesUsuariosDocTec[0];
            n298VacantesUsuariosDocTec = T000H17_n298VacantesUsuariosDocTec[0];
            A295VacantesUsuariosFechaE = T000H17_A295VacantesUsuariosFechaE[0];
            n295VacantesUsuariosFechaE = T000H17_n295VacantesUsuariosFechaE[0];
            A305VacantesUsuariosDocCVRec = T000H17_A305VacantesUsuariosDocCVRec[0];
            n305VacantesUsuariosDocCVRec = T000H17_n305VacantesUsuariosDocCVRec[0];
            A306VacantesUsuariosDocRefLab = T000H17_A306VacantesUsuariosDocRefLab[0];
            n306VacantesUsuariosDocRefLab = T000H17_n306VacantesUsuariosDocRefLab[0];
            A307VacantesUsuariosDocExPsi = T000H17_A307VacantesUsuariosDocExPsi[0];
            n307VacantesUsuariosDocExPsi = T000H17_n307VacantesUsuariosDocExPsi[0];
            A308VacantesUsuariosDocBusWeb = T000H17_A308VacantesUsuariosDocBusWeb[0];
            n308VacantesUsuariosDocBusWeb = T000H17_n308VacantesUsuariosDocBusWeb[0];
            A309VacantesUsuariosDocAvPriv = T000H17_A309VacantesUsuariosDocAvPriv[0];
            n309VacantesUsuariosDocAvPriv = T000H17_n309VacantesUsuariosDocAvPriv[0];
            A310VacantesUsuariosDocAvConf = T000H17_A310VacantesUsuariosDocAvConf[0];
            n310VacantesUsuariosDocAvConf = T000H17_n310VacantesUsuariosDocAvConf[0];
            A311VacantesUsuariosFechaEnvOp = T000H17_A311VacantesUsuariosFechaEnvOp[0];
            n311VacantesUsuariosFechaEnvOp = T000H17_n311VacantesUsuariosFechaEnvOp[0];
            A312VacantesUsuariosFechaEnvCli = T000H17_A312VacantesUsuariosFechaEnvCli[0];
            n312VacantesUsuariosFechaEnvCli = T000H17_n312VacantesUsuariosFechaEnvCli[0];
            A284SUBT_ReclutadorId = T000H17_A284SUBT_ReclutadorId[0];
            ZM0H28( -6) ;
         }
         pr_default.close(15);
         OnLoadActions0H28( ) ;
      }

      protected void OnLoadActions0H28( )
      {
         A287SUBT_ReclutadorNombre = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + StringUtil.Trim( A64UsuariosApMat);
         AssignAttri("", false, "A287SUBT_ReclutadorNombre", A287SUBT_ReclutadorNombre);
      }

      protected void CheckExtendedTable0H28( )
      {
         nIsDirty_28 = 0;
         Gx_BScreen = 1;
         standaloneModal0H28( ) ;
         /* Using cursor T000H4 */
         pr_default.execute(2, new Object[] {A11UsuariosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "USUARIOSID_" + sGXsfl_90_idx;
            GX_msglist.addItem("No existe 'Tabla de usuarios'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtUsuariosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A66UsuariosNombre = T000H4_A66UsuariosNombre[0];
         A65UsuariosApPat = T000H4_A65UsuariosApPat[0];
         A64UsuariosApMat = T000H4_A64UsuariosApMat[0];
         pr_default.close(2);
         nIsDirty_28 = 1;
         A287SUBT_ReclutadorNombre = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + StringUtil.Trim( A64UsuariosApMat);
         AssignAttri("", false, "A287SUBT_ReclutadorNombre", A287SUBT_ReclutadorNombre);
      }

      protected void CloseExtendedTableCursors0H28( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0H28( )
      {
      }

      protected void gxLoad_7( int A11UsuariosId )
      {
         /* Using cursor T000H18 */
         pr_default.execute(16, new Object[] {A11UsuariosId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GXCCtl = "USUARIOSID_" + sGXsfl_90_idx;
            GX_msglist.addItem("No existe 'Tabla de usuarios'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtUsuariosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A66UsuariosNombre = T000H18_A66UsuariosNombre[0];
         A65UsuariosApPat = T000H18_A65UsuariosApPat[0];
         A64UsuariosApMat = T000H18_A64UsuariosApMat[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A66UsuariosNombre)+"\""+","+"\""+GXUtil.EncodeJSConstant( A65UsuariosApPat)+"\""+","+"\""+GXUtil.EncodeJSConstant( A64UsuariosApMat)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void GetKey0H28( )
      {
         /* Using cursor T000H19 */
         pr_default.execute(17, new Object[] {A263Vacantes_Id, A11UsuariosId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound28 = 1;
         }
         else
         {
            RcdFound28 = 0;
         }
         pr_default.close(17);
      }

      protected void getByPrimaryKey0H28( )
      {
         /* Using cursor T000H3 */
         pr_default.execute(1, new Object[] {A263Vacantes_Id, A11UsuariosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0H28( 6) ;
            RcdFound28 = 1;
            InitializeNonKey0H28( ) ;
            A273UsuariosVacanteEstatus = T000H3_A273UsuariosVacanteEstatus[0];
            A288VacantesUsuariosFechaP = T000H3_A288VacantesUsuariosFechaP[0];
            A289VacantesUsuariosFechaD = T000H3_A289VacantesUsuariosFechaD[0];
            n289VacantesUsuariosFechaD = T000H3_n289VacantesUsuariosFechaD[0];
            A313VacantesUsuariosFechaA = T000H3_A313VacantesUsuariosFechaA[0];
            n313VacantesUsuariosFechaA = T000H3_n313VacantesUsuariosFechaA[0];
            A314VacantesUsuariosFecha3 = T000H3_A314VacantesUsuariosFecha3[0];
            n314VacantesUsuariosFecha3 = T000H3_n314VacantesUsuariosFecha3[0];
            A294VacantesUsuariosMotD = T000H3_A294VacantesUsuariosMotD[0];
            n294VacantesUsuariosMotD = T000H3_n294VacantesUsuariosMotD[0];
            A290VacantesUsuariosEstatus = T000H3_A290VacantesUsuariosEstatus[0];
            n290VacantesUsuariosEstatus = T000H3_n290VacantesUsuariosEstatus[0];
            A291VacantesUsuariosPrefiltro = T000H3_A291VacantesUsuariosPrefiltro[0];
            n291VacantesUsuariosPrefiltro = T000H3_n291VacantesUsuariosPrefiltro[0];
            A292VacantesUsuariosCV = T000H3_A292VacantesUsuariosCV[0];
            n292VacantesUsuariosCV = T000H3_n292VacantesUsuariosCV[0];
            A293VacantesUsuariosExTec = T000H3_A293VacantesUsuariosExTec[0];
            n293VacantesUsuariosExTec = T000H3_n293VacantesUsuariosExTec[0];
            A299VacantesUsuariosCVRec = T000H3_A299VacantesUsuariosCVRec[0];
            n299VacantesUsuariosCVRec = T000H3_n299VacantesUsuariosCVRec[0];
            A300VacantesUsuariosRefLab = T000H3_A300VacantesUsuariosRefLab[0];
            n300VacantesUsuariosRefLab = T000H3_n300VacantesUsuariosRefLab[0];
            A301VacantesUsuariosExPsi = T000H3_A301VacantesUsuariosExPsi[0];
            n301VacantesUsuariosExPsi = T000H3_n301VacantesUsuariosExPsi[0];
            A302VacantesUsuariosBusWeb = T000H3_A302VacantesUsuariosBusWeb[0];
            n302VacantesUsuariosBusWeb = T000H3_n302VacantesUsuariosBusWeb[0];
            A303VacantesUsuariosAvPriv = T000H3_A303VacantesUsuariosAvPriv[0];
            n303VacantesUsuariosAvPriv = T000H3_n303VacantesUsuariosAvPriv[0];
            A304VacantesUsuariosAvConf = T000H3_A304VacantesUsuariosAvConf[0];
            n304VacantesUsuariosAvConf = T000H3_n304VacantesUsuariosAvConf[0];
            A296VacantesUsuariosDocP = T000H3_A296VacantesUsuariosDocP[0];
            n296VacantesUsuariosDocP = T000H3_n296VacantesUsuariosDocP[0];
            A297VacantesUsuariosDocCV = T000H3_A297VacantesUsuariosDocCV[0];
            n297VacantesUsuariosDocCV = T000H3_n297VacantesUsuariosDocCV[0];
            A298VacantesUsuariosDocTec = T000H3_A298VacantesUsuariosDocTec[0];
            n298VacantesUsuariosDocTec = T000H3_n298VacantesUsuariosDocTec[0];
            A295VacantesUsuariosFechaE = T000H3_A295VacantesUsuariosFechaE[0];
            n295VacantesUsuariosFechaE = T000H3_n295VacantesUsuariosFechaE[0];
            A305VacantesUsuariosDocCVRec = T000H3_A305VacantesUsuariosDocCVRec[0];
            n305VacantesUsuariosDocCVRec = T000H3_n305VacantesUsuariosDocCVRec[0];
            A306VacantesUsuariosDocRefLab = T000H3_A306VacantesUsuariosDocRefLab[0];
            n306VacantesUsuariosDocRefLab = T000H3_n306VacantesUsuariosDocRefLab[0];
            A307VacantesUsuariosDocExPsi = T000H3_A307VacantesUsuariosDocExPsi[0];
            n307VacantesUsuariosDocExPsi = T000H3_n307VacantesUsuariosDocExPsi[0];
            A308VacantesUsuariosDocBusWeb = T000H3_A308VacantesUsuariosDocBusWeb[0];
            n308VacantesUsuariosDocBusWeb = T000H3_n308VacantesUsuariosDocBusWeb[0];
            A309VacantesUsuariosDocAvPriv = T000H3_A309VacantesUsuariosDocAvPriv[0];
            n309VacantesUsuariosDocAvPriv = T000H3_n309VacantesUsuariosDocAvPriv[0];
            A310VacantesUsuariosDocAvConf = T000H3_A310VacantesUsuariosDocAvConf[0];
            n310VacantesUsuariosDocAvConf = T000H3_n310VacantesUsuariosDocAvConf[0];
            A311VacantesUsuariosFechaEnvOp = T000H3_A311VacantesUsuariosFechaEnvOp[0];
            n311VacantesUsuariosFechaEnvOp = T000H3_n311VacantesUsuariosFechaEnvOp[0];
            A312VacantesUsuariosFechaEnvCli = T000H3_A312VacantesUsuariosFechaEnvCli[0];
            n312VacantesUsuariosFechaEnvCli = T000H3_n312VacantesUsuariosFechaEnvCli[0];
            A11UsuariosId = T000H3_A11UsuariosId[0];
            A284SUBT_ReclutadorId = T000H3_A284SUBT_ReclutadorId[0];
            Z263Vacantes_Id = A263Vacantes_Id;
            Z11UsuariosId = A11UsuariosId;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0H28( ) ;
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound28 = 0;
            InitializeNonKey0H28( ) ;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0H28( ) ;
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0H28( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0H28( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000H2 */
            pr_default.execute(0, new Object[] {A263Vacantes_Id, A11UsuariosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"VacantesUsuariosVacante"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z273UsuariosVacanteEstatus != T000H2_A273UsuariosVacanteEstatus[0] ) || ( Z288VacantesUsuariosFechaP != T000H2_A288VacantesUsuariosFechaP[0] ) || ( Z289VacantesUsuariosFechaD != T000H2_A289VacantesUsuariosFechaD[0] ) || ( Z313VacantesUsuariosFechaA != T000H2_A313VacantesUsuariosFechaA[0] ) || ( Z314VacantesUsuariosFecha3 != T000H2_A314VacantesUsuariosFecha3[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z294VacantesUsuariosMotD, T000H2_A294VacantesUsuariosMotD[0]) != 0 ) || ( Z290VacantesUsuariosEstatus != T000H2_A290VacantesUsuariosEstatus[0] ) || ( Z291VacantesUsuariosPrefiltro != T000H2_A291VacantesUsuariosPrefiltro[0] ) || ( Z292VacantesUsuariosCV != T000H2_A292VacantesUsuariosCV[0] ) || ( Z293VacantesUsuariosExTec != T000H2_A293VacantesUsuariosExTec[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z299VacantesUsuariosCVRec != T000H2_A299VacantesUsuariosCVRec[0] ) || ( Z300VacantesUsuariosRefLab != T000H2_A300VacantesUsuariosRefLab[0] ) || ( Z301VacantesUsuariosExPsi != T000H2_A301VacantesUsuariosExPsi[0] ) || ( Z302VacantesUsuariosBusWeb != T000H2_A302VacantesUsuariosBusWeb[0] ) || ( Z303VacantesUsuariosAvPriv != T000H2_A303VacantesUsuariosAvPriv[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z304VacantesUsuariosAvConf != T000H2_A304VacantesUsuariosAvConf[0] ) || ( StringUtil.StrCmp(Z296VacantesUsuariosDocP, T000H2_A296VacantesUsuariosDocP[0]) != 0 ) || ( StringUtil.StrCmp(Z297VacantesUsuariosDocCV, T000H2_A297VacantesUsuariosDocCV[0]) != 0 ) || ( StringUtil.StrCmp(Z298VacantesUsuariosDocTec, T000H2_A298VacantesUsuariosDocTec[0]) != 0 ) || ( Z295VacantesUsuariosFechaE != T000H2_A295VacantesUsuariosFechaE[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z305VacantesUsuariosDocCVRec, T000H2_A305VacantesUsuariosDocCVRec[0]) != 0 ) || ( StringUtil.StrCmp(Z306VacantesUsuariosDocRefLab, T000H2_A306VacantesUsuariosDocRefLab[0]) != 0 ) || ( StringUtil.StrCmp(Z307VacantesUsuariosDocExPsi, T000H2_A307VacantesUsuariosDocExPsi[0]) != 0 ) || ( StringUtil.StrCmp(Z308VacantesUsuariosDocBusWeb, T000H2_A308VacantesUsuariosDocBusWeb[0]) != 0 ) || ( StringUtil.StrCmp(Z309VacantesUsuariosDocAvPriv, T000H2_A309VacantesUsuariosDocAvPriv[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z310VacantesUsuariosDocAvConf, T000H2_A310VacantesUsuariosDocAvConf[0]) != 0 ) || ( Z311VacantesUsuariosFechaEnvOp != T000H2_A311VacantesUsuariosFechaEnvOp[0] ) || ( Z312VacantesUsuariosFechaEnvCli != T000H2_A312VacantesUsuariosFechaEnvCli[0] ) || ( Z284SUBT_ReclutadorId != T000H2_A284SUBT_ReclutadorId[0] ) )
            {
               if ( Z273UsuariosVacanteEstatus != T000H2_A273UsuariosVacanteEstatus[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"UsuariosVacanteEstatus");
                  GXUtil.WriteLogRaw("Old: ",Z273UsuariosVacanteEstatus);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A273UsuariosVacanteEstatus[0]);
               }
               if ( Z288VacantesUsuariosFechaP != T000H2_A288VacantesUsuariosFechaP[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosFechaP");
                  GXUtil.WriteLogRaw("Old: ",Z288VacantesUsuariosFechaP);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A288VacantesUsuariosFechaP[0]);
               }
               if ( Z289VacantesUsuariosFechaD != T000H2_A289VacantesUsuariosFechaD[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosFechaD");
                  GXUtil.WriteLogRaw("Old: ",Z289VacantesUsuariosFechaD);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A289VacantesUsuariosFechaD[0]);
               }
               if ( Z313VacantesUsuariosFechaA != T000H2_A313VacantesUsuariosFechaA[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosFechaA");
                  GXUtil.WriteLogRaw("Old: ",Z313VacantesUsuariosFechaA);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A313VacantesUsuariosFechaA[0]);
               }
               if ( Z314VacantesUsuariosFecha3 != T000H2_A314VacantesUsuariosFecha3[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosFecha3");
                  GXUtil.WriteLogRaw("Old: ",Z314VacantesUsuariosFecha3);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A314VacantesUsuariosFecha3[0]);
               }
               if ( StringUtil.StrCmp(Z294VacantesUsuariosMotD, T000H2_A294VacantesUsuariosMotD[0]) != 0 )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosMotD");
                  GXUtil.WriteLogRaw("Old: ",Z294VacantesUsuariosMotD);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A294VacantesUsuariosMotD[0]);
               }
               if ( Z290VacantesUsuariosEstatus != T000H2_A290VacantesUsuariosEstatus[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosEstatus");
                  GXUtil.WriteLogRaw("Old: ",Z290VacantesUsuariosEstatus);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A290VacantesUsuariosEstatus[0]);
               }
               if ( Z291VacantesUsuariosPrefiltro != T000H2_A291VacantesUsuariosPrefiltro[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosPrefiltro");
                  GXUtil.WriteLogRaw("Old: ",Z291VacantesUsuariosPrefiltro);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A291VacantesUsuariosPrefiltro[0]);
               }
               if ( Z292VacantesUsuariosCV != T000H2_A292VacantesUsuariosCV[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosCV");
                  GXUtil.WriteLogRaw("Old: ",Z292VacantesUsuariosCV);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A292VacantesUsuariosCV[0]);
               }
               if ( Z293VacantesUsuariosExTec != T000H2_A293VacantesUsuariosExTec[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosExTec");
                  GXUtil.WriteLogRaw("Old: ",Z293VacantesUsuariosExTec);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A293VacantesUsuariosExTec[0]);
               }
               if ( Z299VacantesUsuariosCVRec != T000H2_A299VacantesUsuariosCVRec[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosCVRec");
                  GXUtil.WriteLogRaw("Old: ",Z299VacantesUsuariosCVRec);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A299VacantesUsuariosCVRec[0]);
               }
               if ( Z300VacantesUsuariosRefLab != T000H2_A300VacantesUsuariosRefLab[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosRefLab");
                  GXUtil.WriteLogRaw("Old: ",Z300VacantesUsuariosRefLab);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A300VacantesUsuariosRefLab[0]);
               }
               if ( Z301VacantesUsuariosExPsi != T000H2_A301VacantesUsuariosExPsi[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosExPsi");
                  GXUtil.WriteLogRaw("Old: ",Z301VacantesUsuariosExPsi);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A301VacantesUsuariosExPsi[0]);
               }
               if ( Z302VacantesUsuariosBusWeb != T000H2_A302VacantesUsuariosBusWeb[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosBusWeb");
                  GXUtil.WriteLogRaw("Old: ",Z302VacantesUsuariosBusWeb);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A302VacantesUsuariosBusWeb[0]);
               }
               if ( Z303VacantesUsuariosAvPriv != T000H2_A303VacantesUsuariosAvPriv[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosAvPriv");
                  GXUtil.WriteLogRaw("Old: ",Z303VacantesUsuariosAvPriv);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A303VacantesUsuariosAvPriv[0]);
               }
               if ( Z304VacantesUsuariosAvConf != T000H2_A304VacantesUsuariosAvConf[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosAvConf");
                  GXUtil.WriteLogRaw("Old: ",Z304VacantesUsuariosAvConf);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A304VacantesUsuariosAvConf[0]);
               }
               if ( StringUtil.StrCmp(Z296VacantesUsuariosDocP, T000H2_A296VacantesUsuariosDocP[0]) != 0 )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosDocP");
                  GXUtil.WriteLogRaw("Old: ",Z296VacantesUsuariosDocP);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A296VacantesUsuariosDocP[0]);
               }
               if ( StringUtil.StrCmp(Z297VacantesUsuariosDocCV, T000H2_A297VacantesUsuariosDocCV[0]) != 0 )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosDocCV");
                  GXUtil.WriteLogRaw("Old: ",Z297VacantesUsuariosDocCV);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A297VacantesUsuariosDocCV[0]);
               }
               if ( StringUtil.StrCmp(Z298VacantesUsuariosDocTec, T000H2_A298VacantesUsuariosDocTec[0]) != 0 )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosDocTec");
                  GXUtil.WriteLogRaw("Old: ",Z298VacantesUsuariosDocTec);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A298VacantesUsuariosDocTec[0]);
               }
               if ( Z295VacantesUsuariosFechaE != T000H2_A295VacantesUsuariosFechaE[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosFechaE");
                  GXUtil.WriteLogRaw("Old: ",Z295VacantesUsuariosFechaE);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A295VacantesUsuariosFechaE[0]);
               }
               if ( StringUtil.StrCmp(Z305VacantesUsuariosDocCVRec, T000H2_A305VacantesUsuariosDocCVRec[0]) != 0 )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosDocCVRec");
                  GXUtil.WriteLogRaw("Old: ",Z305VacantesUsuariosDocCVRec);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A305VacantesUsuariosDocCVRec[0]);
               }
               if ( StringUtil.StrCmp(Z306VacantesUsuariosDocRefLab, T000H2_A306VacantesUsuariosDocRefLab[0]) != 0 )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosDocRefLab");
                  GXUtil.WriteLogRaw("Old: ",Z306VacantesUsuariosDocRefLab);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A306VacantesUsuariosDocRefLab[0]);
               }
               if ( StringUtil.StrCmp(Z307VacantesUsuariosDocExPsi, T000H2_A307VacantesUsuariosDocExPsi[0]) != 0 )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosDocExPsi");
                  GXUtil.WriteLogRaw("Old: ",Z307VacantesUsuariosDocExPsi);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A307VacantesUsuariosDocExPsi[0]);
               }
               if ( StringUtil.StrCmp(Z308VacantesUsuariosDocBusWeb, T000H2_A308VacantesUsuariosDocBusWeb[0]) != 0 )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosDocBusWeb");
                  GXUtil.WriteLogRaw("Old: ",Z308VacantesUsuariosDocBusWeb);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A308VacantesUsuariosDocBusWeb[0]);
               }
               if ( StringUtil.StrCmp(Z309VacantesUsuariosDocAvPriv, T000H2_A309VacantesUsuariosDocAvPriv[0]) != 0 )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosDocAvPriv");
                  GXUtil.WriteLogRaw("Old: ",Z309VacantesUsuariosDocAvPriv);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A309VacantesUsuariosDocAvPriv[0]);
               }
               if ( StringUtil.StrCmp(Z310VacantesUsuariosDocAvConf, T000H2_A310VacantesUsuariosDocAvConf[0]) != 0 )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosDocAvConf");
                  GXUtil.WriteLogRaw("Old: ",Z310VacantesUsuariosDocAvConf);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A310VacantesUsuariosDocAvConf[0]);
               }
               if ( Z311VacantesUsuariosFechaEnvOp != T000H2_A311VacantesUsuariosFechaEnvOp[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosFechaEnvOp");
                  GXUtil.WriteLogRaw("Old: ",Z311VacantesUsuariosFechaEnvOp);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A311VacantesUsuariosFechaEnvOp[0]);
               }
               if ( Z312VacantesUsuariosFechaEnvCli != T000H2_A312VacantesUsuariosFechaEnvCli[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"VacantesUsuariosFechaEnvCli");
                  GXUtil.WriteLogRaw("Old: ",Z312VacantesUsuariosFechaEnvCli);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A312VacantesUsuariosFechaEnvCli[0]);
               }
               if ( Z284SUBT_ReclutadorId != T000H2_A284SUBT_ReclutadorId[0] )
               {
                  GXUtil.WriteLog("vacantes:[seudo value changed for attri]"+"SUBT_ReclutadorId");
                  GXUtil.WriteLogRaw("Old: ",Z284SUBT_ReclutadorId);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A284SUBT_ReclutadorId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"VacantesUsuariosVacante"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0H28( )
      {
         BeforeValidate0H28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H28( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0H28( 0) ;
            CheckOptimisticConcurrency0H28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0H28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000H20 */
                     pr_default.execute(18, new Object[] {A263Vacantes_Id, A273UsuariosVacanteEstatus, A288VacantesUsuariosFechaP, n289VacantesUsuariosFechaD, A289VacantesUsuariosFechaD, n313VacantesUsuariosFechaA, A313VacantesUsuariosFechaA, n314VacantesUsuariosFecha3, A314VacantesUsuariosFecha3, n294VacantesUsuariosMotD, A294VacantesUsuariosMotD, n290VacantesUsuariosEstatus, A290VacantesUsuariosEstatus, n291VacantesUsuariosPrefiltro, A291VacantesUsuariosPrefiltro, n292VacantesUsuariosCV, A292VacantesUsuariosCV, n293VacantesUsuariosExTec, A293VacantesUsuariosExTec, n299VacantesUsuariosCVRec, A299VacantesUsuariosCVRec, n300VacantesUsuariosRefLab, A300VacantesUsuariosRefLab, n301VacantesUsuariosExPsi, A301VacantesUsuariosExPsi, n302VacantesUsuariosBusWeb, A302VacantesUsuariosBusWeb, n303VacantesUsuariosAvPriv, A303VacantesUsuariosAvPriv, n304VacantesUsuariosAvConf, A304VacantesUsuariosAvConf, n296VacantesUsuariosDocP, A296VacantesUsuariosDocP, n297VacantesUsuariosDocCV, A297VacantesUsuariosDocCV, n298VacantesUsuariosDocTec, A298VacantesUsuariosDocTec, n295VacantesUsuariosFechaE, A295VacantesUsuariosFechaE, n305VacantesUsuariosDocCVRec, A305VacantesUsuariosDocCVRec, n306VacantesUsuariosDocRefLab, A306VacantesUsuariosDocRefLab, n307VacantesUsuariosDocExPsi, A307VacantesUsuariosDocExPsi, n308VacantesUsuariosDocBusWeb, A308VacantesUsuariosDocBusWeb, n309VacantesUsuariosDocAvPriv, A309VacantesUsuariosDocAvPriv, n310VacantesUsuariosDocAvConf, A310VacantesUsuariosDocAvConf, n311VacantesUsuariosFechaEnvOp, A311VacantesUsuariosFechaEnvOp, n312VacantesUsuariosFechaEnvCli, A312VacantesUsuariosFechaEnvCli, A11UsuariosId, A284SUBT_ReclutadorId});
                     pr_default.close(18);
                     dsDefault.SmartCacheProvider.SetUpdated("VacantesUsuariosVacante") ;
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
               Load0H28( ) ;
            }
            EndLevel0H28( ) ;
         }
         CloseExtendedTableCursors0H28( ) ;
      }

      protected void Update0H28( )
      {
         BeforeValidate0H28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H28( ) ;
         }
         if ( ( nIsMod_28 != 0 ) || ( nIsDirty_28 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0H28( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0H28( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0H28( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000H21 */
                        pr_default.execute(19, new Object[] {A273UsuariosVacanteEstatus, A288VacantesUsuariosFechaP, n289VacantesUsuariosFechaD, A289VacantesUsuariosFechaD, n313VacantesUsuariosFechaA, A313VacantesUsuariosFechaA, n314VacantesUsuariosFecha3, A314VacantesUsuariosFecha3, n294VacantesUsuariosMotD, A294VacantesUsuariosMotD, n290VacantesUsuariosEstatus, A290VacantesUsuariosEstatus, n291VacantesUsuariosPrefiltro, A291VacantesUsuariosPrefiltro, n292VacantesUsuariosCV, A292VacantesUsuariosCV, n293VacantesUsuariosExTec, A293VacantesUsuariosExTec, n299VacantesUsuariosCVRec, A299VacantesUsuariosCVRec, n300VacantesUsuariosRefLab, A300VacantesUsuariosRefLab, n301VacantesUsuariosExPsi, A301VacantesUsuariosExPsi, n302VacantesUsuariosBusWeb, A302VacantesUsuariosBusWeb, n303VacantesUsuariosAvPriv, A303VacantesUsuariosAvPriv, n304VacantesUsuariosAvConf, A304VacantesUsuariosAvConf, n296VacantesUsuariosDocP, A296VacantesUsuariosDocP, n297VacantesUsuariosDocCV, A297VacantesUsuariosDocCV, n298VacantesUsuariosDocTec, A298VacantesUsuariosDocTec, n295VacantesUsuariosFechaE, A295VacantesUsuariosFechaE, n305VacantesUsuariosDocCVRec, A305VacantesUsuariosDocCVRec, n306VacantesUsuariosDocRefLab, A306VacantesUsuariosDocRefLab, n307VacantesUsuariosDocExPsi, A307VacantesUsuariosDocExPsi, n308VacantesUsuariosDocBusWeb, A308VacantesUsuariosDocBusWeb, n309VacantesUsuariosDocAvPriv, A309VacantesUsuariosDocAvPriv, n310VacantesUsuariosDocAvConf, A310VacantesUsuariosDocAvConf, n311VacantesUsuariosFechaEnvOp, A311VacantesUsuariosFechaEnvOp, n312VacantesUsuariosFechaEnvCli, A312VacantesUsuariosFechaEnvCli, A284SUBT_ReclutadorId, A263Vacantes_Id, A11UsuariosId});
                        pr_default.close(19);
                        dsDefault.SmartCacheProvider.SetUpdated("VacantesUsuariosVacante") ;
                        if ( (pr_default.getStatus(19) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"VacantesUsuariosVacante"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0H28( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0H28( ) ;
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
               EndLevel0H28( ) ;
            }
         }
         CloseExtendedTableCursors0H28( ) ;
      }

      protected void DeferredUpdate0H28( )
      {
      }

      protected void Delete0H28( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0H28( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H28( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0H28( ) ;
            AfterConfirm0H28( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0H28( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000H22 */
                  pr_default.execute(20, new Object[] {A263Vacantes_Id, A11UsuariosId});
                  pr_default.close(20);
                  dsDefault.SmartCacheProvider.SetUpdated("VacantesUsuariosVacante") ;
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
         sMode28 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0H28( ) ;
         Gx_mode = sMode28;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0H28( )
      {
         standaloneModal0H28( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000H23 */
            pr_default.execute(21, new Object[] {A11UsuariosId});
            A66UsuariosNombre = T000H23_A66UsuariosNombre[0];
            A65UsuariosApPat = T000H23_A65UsuariosApPat[0];
            A64UsuariosApMat = T000H23_A64UsuariosApMat[0];
            pr_default.close(21);
            A287SUBT_ReclutadorNombre = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + StringUtil.Trim( A64UsuariosApMat);
            AssignAttri("", false, "A287SUBT_ReclutadorNombre", A287SUBT_ReclutadorNombre);
         }
      }

      protected void EndLevel0H28( )
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

      public void ScanStart0H28( )
      {
         /* Scan By routine */
         /* Using cursor T000H24 */
         pr_default.execute(22, new Object[] {A263Vacantes_Id});
         RcdFound28 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound28 = 1;
            A11UsuariosId = T000H24_A11UsuariosId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0H28( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound28 = 1;
            A11UsuariosId = T000H24_A11UsuariosId[0];
         }
      }

      protected void ScanEnd0H28( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm0H28( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0H28( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0H28( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0H28( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0H28( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0H28( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0H28( )
      {
         edtUsuariosId_Enabled = 0;
         AssignProp("", false, edtUsuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosId_Enabled), 5, 0), !bGXsfl_90_Refreshing);
         edtUsuariosNombre_Enabled = 0;
         AssignProp("", false, edtUsuariosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosNombre_Enabled), 5, 0), !bGXsfl_90_Refreshing);
         edtUsuariosApPat_Enabled = 0;
         AssignProp("", false, edtUsuariosApPat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosApPat_Enabled), 5, 0), !bGXsfl_90_Refreshing);
         edtUsuariosApMat_Enabled = 0;
         AssignProp("", false, edtUsuariosApMat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosApMat_Enabled), 5, 0), !bGXsfl_90_Refreshing);
         cmbUsuariosVacanteEstatus.Enabled = 0;
         AssignProp("", false, cmbUsuariosVacanteEstatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUsuariosVacanteEstatus.Enabled), 5, 0), !bGXsfl_90_Refreshing);
      }

      protected void send_integrity_lvl_hashes0H28( )
      {
      }

      protected void send_integrity_lvl_hashes0H21( )
      {
      }

      protected void SubsflControlProps_9028( )
      {
         edtUsuariosId_Internalname = "USUARIOSID_"+sGXsfl_90_idx;
         edtUsuariosNombre_Internalname = "USUARIOSNOMBRE_"+sGXsfl_90_idx;
         edtUsuariosApPat_Internalname = "USUARIOSAPPAT_"+sGXsfl_90_idx;
         edtUsuariosApMat_Internalname = "USUARIOSAPMAT_"+sGXsfl_90_idx;
         cmbUsuariosVacanteEstatus_Internalname = "USUARIOSVACANTEESTATUS_"+sGXsfl_90_idx;
      }

      protected void SubsflControlProps_fel_9028( )
      {
         edtUsuariosId_Internalname = "USUARIOSID_"+sGXsfl_90_fel_idx;
         edtUsuariosNombre_Internalname = "USUARIOSNOMBRE_"+sGXsfl_90_fel_idx;
         edtUsuariosApPat_Internalname = "USUARIOSAPPAT_"+sGXsfl_90_fel_idx;
         edtUsuariosApMat_Internalname = "USUARIOSAPMAT_"+sGXsfl_90_fel_idx;
         cmbUsuariosVacanteEstatus_Internalname = "USUARIOSVACANTEESTATUS_"+sGXsfl_90_fel_idx;
      }

      protected void AddRow0H28( )
      {
         nGXsfl_90_idx = (int)(nGXsfl_90_idx+1);
         sGXsfl_90_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_90_idx), 4, 0), 4, "0");
         SubsflControlProps_9028( ) ;
         SendRow0H28( ) ;
      }

      protected void SendRow0H28( )
      {
         Gridvacantes_usuariosvacanteRow = GXWebRow.GetNew(context);
         if ( subGridvacantes_usuariosvacante_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridvacantes_usuariosvacante_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridvacantes_usuariosvacante_Class, "") != 0 )
            {
               subGridvacantes_usuariosvacante_Linesclass = subGridvacantes_usuariosvacante_Class+"Odd";
            }
         }
         else if ( subGridvacantes_usuariosvacante_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridvacantes_usuariosvacante_Backstyle = 0;
            subGridvacantes_usuariosvacante_Backcolor = subGridvacantes_usuariosvacante_Allbackcolor;
            if ( StringUtil.StrCmp(subGridvacantes_usuariosvacante_Class, "") != 0 )
            {
               subGridvacantes_usuariosvacante_Linesclass = subGridvacantes_usuariosvacante_Class+"Uniform";
            }
         }
         else if ( subGridvacantes_usuariosvacante_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridvacantes_usuariosvacante_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridvacantes_usuariosvacante_Class, "") != 0 )
            {
               subGridvacantes_usuariosvacante_Linesclass = subGridvacantes_usuariosvacante_Class+"Odd";
            }
            subGridvacantes_usuariosvacante_Backcolor = (int)(0x0);
         }
         else if ( subGridvacantes_usuariosvacante_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridvacantes_usuariosvacante_Backstyle = 1;
            if ( ((int)((nGXsfl_90_idx) % (2))) == 0 )
            {
               subGridvacantes_usuariosvacante_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridvacantes_usuariosvacante_Class, "") != 0 )
               {
                  subGridvacantes_usuariosvacante_Linesclass = subGridvacantes_usuariosvacante_Class+"Even";
               }
            }
            else
            {
               subGridvacantes_usuariosvacante_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridvacantes_usuariosvacante_Class, "") != 0 )
               {
                  subGridvacantes_usuariosvacante_Linesclass = subGridvacantes_usuariosvacante_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_28_" + sGXsfl_90_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_90_idx + "',90)\"";
         ROClassString = "Attribute";
         Gridvacantes_usuariosvacanteRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,91);\"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosId_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(int)edtUsuariosId_Enabled,(short)1,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)6,(short)0,(short)0,(short)90,(short)1,(short)-1,(short)0,(bool)true,(String)"NumId",(String)"right",(bool)false,(String)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridvacantes_usuariosvacanteRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosNombre_Internalname,(String)A66UsuariosNombre,StringUtil.RTrim( context.localUtil.Format( A66UsuariosNombre, "@!")),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosNombre_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(int)edtUsuariosNombre_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)40,(short)0,(short)0,(short)90,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridvacantes_usuariosvacanteRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosApPat_Internalname,(String)A65UsuariosApPat,StringUtil.RTrim( context.localUtil.Format( A65UsuariosApPat, "@!")),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosApPat_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(int)edtUsuariosApPat_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)40,(short)0,(short)0,(short)90,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridvacantes_usuariosvacanteRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosApMat_Internalname,(String)A64UsuariosApMat,StringUtil.RTrim( context.localUtil.Format( A64UsuariosApMat, "@!")),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosApMat_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(int)edtUsuariosApMat_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)40,(short)0,(short)0,(short)90,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_28_" + sGXsfl_90_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 95,'',false,'" + sGXsfl_90_idx + "',90)\"";
         if ( ( cmbUsuariosVacanteEstatus.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "USUARIOSVACANTEESTATUS_" + sGXsfl_90_idx;
            cmbUsuariosVacanteEstatus.Name = GXCCtl;
            cmbUsuariosVacanteEstatus.WebTags = "";
            cmbUsuariosVacanteEstatus.addItem("0", "1er Filtro", 0);
            cmbUsuariosVacanteEstatus.addItem("1", "2do Filtro", 0);
            cmbUsuariosVacanteEstatus.addItem("2", "3er Filtro", 0);
            cmbUsuariosVacanteEstatus.addItem("3", "Todo Proceso", 0);
            cmbUsuariosVacanteEstatus.addItem("4", "Enviado Cliente", 0);
            if ( cmbUsuariosVacanteEstatus.ItemCount > 0 )
            {
               A273UsuariosVacanteEstatus = (short)(NumberUtil.Val( cmbUsuariosVacanteEstatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A273UsuariosVacanteEstatus), 1, 0))), "."));
            }
         }
         /* ComboBox */
         Gridvacantes_usuariosvacanteRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbUsuariosVacanteEstatus,(String)cmbUsuariosVacanteEstatus_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A273UsuariosVacanteEstatus), 1, 0)),(short)1,(String)cmbUsuariosVacanteEstatus_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,cmbUsuariosVacanteEstatus.Enabled,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute",(String)"",(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"",(String)"",(bool)true});
         cmbUsuariosVacanteEstatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A273UsuariosVacanteEstatus), 1, 0));
         AssignProp("", false, cmbUsuariosVacanteEstatus_Internalname, "Values", (String)(cmbUsuariosVacanteEstatus.ToJavascriptSource()), !bGXsfl_90_Refreshing);
         context.httpAjaxContext.ajax_sending_grid_row(Gridvacantes_usuariosvacanteRow);
         send_integrity_lvl_hashes0H28( ) ;
         GXCCtl = "Z11UsuariosId_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11UsuariosId), 6, 0, ",", "")));
         GXCCtl = "Z273UsuariosVacanteEstatus_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z273UsuariosVacanteEstatus), 1, 0, ",", "")));
         GXCCtl = "Z288VacantesUsuariosFechaP_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z288VacantesUsuariosFechaP, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z289VacantesUsuariosFechaD_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z289VacantesUsuariosFechaD, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z313VacantesUsuariosFechaA_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z313VacantesUsuariosFechaA, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z314VacantesUsuariosFecha3_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z314VacantesUsuariosFecha3, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z294VacantesUsuariosMotD_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z294VacantesUsuariosMotD);
         GXCCtl = "Z290VacantesUsuariosEstatus_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z290VacantesUsuariosEstatus), 4, 0, ",", "")));
         GXCCtl = "Z291VacantesUsuariosPrefiltro_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z291VacantesUsuariosPrefiltro), 4, 0, ",", "")));
         GXCCtl = "Z292VacantesUsuariosCV_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z292VacantesUsuariosCV), 4, 0, ",", "")));
         GXCCtl = "Z293VacantesUsuariosExTec_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z293VacantesUsuariosExTec), 4, 0, ",", "")));
         GXCCtl = "Z299VacantesUsuariosCVRec_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z299VacantesUsuariosCVRec), 4, 0, ",", "")));
         GXCCtl = "Z300VacantesUsuariosRefLab_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z300VacantesUsuariosRefLab), 4, 0, ",", "")));
         GXCCtl = "Z301VacantesUsuariosExPsi_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z301VacantesUsuariosExPsi), 4, 0, ",", "")));
         GXCCtl = "Z302VacantesUsuariosBusWeb_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z302VacantesUsuariosBusWeb), 4, 0, ",", "")));
         GXCCtl = "Z303VacantesUsuariosAvPriv_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z303VacantesUsuariosAvPriv), 4, 0, ",", "")));
         GXCCtl = "Z304VacantesUsuariosAvConf_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z304VacantesUsuariosAvConf), 4, 0, ",", "")));
         GXCCtl = "Z296VacantesUsuariosDocP_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z296VacantesUsuariosDocP);
         GXCCtl = "Z297VacantesUsuariosDocCV_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z297VacantesUsuariosDocCV);
         GXCCtl = "Z298VacantesUsuariosDocTec_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z298VacantesUsuariosDocTec);
         GXCCtl = "Z295VacantesUsuariosFechaE_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z295VacantesUsuariosFechaE, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z305VacantesUsuariosDocCVRec_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z305VacantesUsuariosDocCVRec);
         GXCCtl = "Z306VacantesUsuariosDocRefLab_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z306VacantesUsuariosDocRefLab);
         GXCCtl = "Z307VacantesUsuariosDocExPsi_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z307VacantesUsuariosDocExPsi);
         GXCCtl = "Z308VacantesUsuariosDocBusWeb_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z308VacantesUsuariosDocBusWeb);
         GXCCtl = "Z309VacantesUsuariosDocAvPriv_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z309VacantesUsuariosDocAvPriv);
         GXCCtl = "Z310VacantesUsuariosDocAvConf_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z310VacantesUsuariosDocAvConf);
         GXCCtl = "Z311VacantesUsuariosFechaEnvOp_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z311VacantesUsuariosFechaEnvOp, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z312VacantesUsuariosFechaEnvCli_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z312VacantesUsuariosFechaEnvCli, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z284SUBT_ReclutadorId_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z284SUBT_ReclutadorId), 6, 0, ",", "")));
         GXCCtl = "nRcdDeleted_28_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_28), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_28_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_28), 4, 0, ",", "")));
         GXCCtl = "nIsMod_28_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_28), 4, 0, ",", "")));
         GXCCtl = "vMODE_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_90_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vVACANTES_ID_" + sGXsfl_90_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Vacantes_Id), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSID_"+sGXsfl_90_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSNOMBRE_"+sGXsfl_90_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSAPPAT_"+sGXsfl_90_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosApPat_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSAPMAT_"+sGXsfl_90_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuariosApMat_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSVACANTEESTATUS_"+sGXsfl_90_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbUsuariosVacanteEstatus.Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridvacantes_usuariosvacanteContainer.AddRow(Gridvacantes_usuariosvacanteRow);
      }

      protected void ReadRow0H28( )
      {
         nGXsfl_90_idx = (int)(nGXsfl_90_idx+1);
         sGXsfl_90_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_90_idx), 4, 0), 4, "0");
         SubsflControlProps_9028( ) ;
         edtUsuariosId_Enabled = (int)(context.localUtil.CToN( cgiGet( "USUARIOSID_"+sGXsfl_90_idx+"Enabled"), ",", "."));
         edtUsuariosNombre_Enabled = (int)(context.localUtil.CToN( cgiGet( "USUARIOSNOMBRE_"+sGXsfl_90_idx+"Enabled"), ",", "."));
         edtUsuariosApPat_Enabled = (int)(context.localUtil.CToN( cgiGet( "USUARIOSAPPAT_"+sGXsfl_90_idx+"Enabled"), ",", "."));
         edtUsuariosApMat_Enabled = (int)(context.localUtil.CToN( cgiGet( "USUARIOSAPMAT_"+sGXsfl_90_idx+"Enabled"), ",", "."));
         cmbUsuariosVacanteEstatus.Enabled = (int)(context.localUtil.CToN( cgiGet( "USUARIOSVACANTEESTATUS_"+sGXsfl_90_idx+"Enabled"), ",", "."));
         if ( ( ( context.localUtil.CToN( cgiGet( edtUsuariosId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuariosId_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "USUARIOSID_" + sGXsfl_90_idx;
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
         cmbUsuariosVacanteEstatus.Name = cmbUsuariosVacanteEstatus_Internalname;
         cmbUsuariosVacanteEstatus.CurrentValue = cgiGet( cmbUsuariosVacanteEstatus_Internalname);
         A273UsuariosVacanteEstatus = (short)(NumberUtil.Val( cgiGet( cmbUsuariosVacanteEstatus_Internalname), "."));
         GXCCtl = "Z11UsuariosId_" + sGXsfl_90_idx;
         Z11UsuariosId = (int)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "Z273UsuariosVacanteEstatus_" + sGXsfl_90_idx;
         Z273UsuariosVacanteEstatus = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "Z288VacantesUsuariosFechaP_" + sGXsfl_90_idx;
         Z288VacantesUsuariosFechaP = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         GXCCtl = "Z289VacantesUsuariosFechaD_" + sGXsfl_90_idx;
         Z289VacantesUsuariosFechaD = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n289VacantesUsuariosFechaD = ((DateTime.MinValue==A289VacantesUsuariosFechaD) ? true : false);
         GXCCtl = "Z313VacantesUsuariosFechaA_" + sGXsfl_90_idx;
         Z313VacantesUsuariosFechaA = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n313VacantesUsuariosFechaA = ((DateTime.MinValue==A313VacantesUsuariosFechaA) ? true : false);
         GXCCtl = "Z314VacantesUsuariosFecha3_" + sGXsfl_90_idx;
         Z314VacantesUsuariosFecha3 = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n314VacantesUsuariosFecha3 = ((DateTime.MinValue==A314VacantesUsuariosFecha3) ? true : false);
         GXCCtl = "Z294VacantesUsuariosMotD_" + sGXsfl_90_idx;
         Z294VacantesUsuariosMotD = cgiGet( GXCCtl);
         n294VacantesUsuariosMotD = (String.IsNullOrEmpty(StringUtil.RTrim( A294VacantesUsuariosMotD)) ? true : false);
         GXCCtl = "Z290VacantesUsuariosEstatus_" + sGXsfl_90_idx;
         Z290VacantesUsuariosEstatus = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         n290VacantesUsuariosEstatus = ((0==A290VacantesUsuariosEstatus) ? true : false);
         GXCCtl = "Z291VacantesUsuariosPrefiltro_" + sGXsfl_90_idx;
         Z291VacantesUsuariosPrefiltro = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         n291VacantesUsuariosPrefiltro = ((0==A291VacantesUsuariosPrefiltro) ? true : false);
         GXCCtl = "Z292VacantesUsuariosCV_" + sGXsfl_90_idx;
         Z292VacantesUsuariosCV = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         n292VacantesUsuariosCV = ((0==A292VacantesUsuariosCV) ? true : false);
         GXCCtl = "Z293VacantesUsuariosExTec_" + sGXsfl_90_idx;
         Z293VacantesUsuariosExTec = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         n293VacantesUsuariosExTec = ((0==A293VacantesUsuariosExTec) ? true : false);
         GXCCtl = "Z299VacantesUsuariosCVRec_" + sGXsfl_90_idx;
         Z299VacantesUsuariosCVRec = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         n299VacantesUsuariosCVRec = ((0==A299VacantesUsuariosCVRec) ? true : false);
         GXCCtl = "Z300VacantesUsuariosRefLab_" + sGXsfl_90_idx;
         Z300VacantesUsuariosRefLab = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         n300VacantesUsuariosRefLab = ((0==A300VacantesUsuariosRefLab) ? true : false);
         GXCCtl = "Z301VacantesUsuariosExPsi_" + sGXsfl_90_idx;
         Z301VacantesUsuariosExPsi = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         n301VacantesUsuariosExPsi = ((0==A301VacantesUsuariosExPsi) ? true : false);
         GXCCtl = "Z302VacantesUsuariosBusWeb_" + sGXsfl_90_idx;
         Z302VacantesUsuariosBusWeb = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         n302VacantesUsuariosBusWeb = ((0==A302VacantesUsuariosBusWeb) ? true : false);
         GXCCtl = "Z303VacantesUsuariosAvPriv_" + sGXsfl_90_idx;
         Z303VacantesUsuariosAvPriv = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         n303VacantesUsuariosAvPriv = ((0==A303VacantesUsuariosAvPriv) ? true : false);
         GXCCtl = "Z304VacantesUsuariosAvConf_" + sGXsfl_90_idx;
         Z304VacantesUsuariosAvConf = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         n304VacantesUsuariosAvConf = ((0==A304VacantesUsuariosAvConf) ? true : false);
         GXCCtl = "Z296VacantesUsuariosDocP_" + sGXsfl_90_idx;
         Z296VacantesUsuariosDocP = cgiGet( GXCCtl);
         n296VacantesUsuariosDocP = (String.IsNullOrEmpty(StringUtil.RTrim( A296VacantesUsuariosDocP)) ? true : false);
         GXCCtl = "Z297VacantesUsuariosDocCV_" + sGXsfl_90_idx;
         Z297VacantesUsuariosDocCV = cgiGet( GXCCtl);
         n297VacantesUsuariosDocCV = (String.IsNullOrEmpty(StringUtil.RTrim( A297VacantesUsuariosDocCV)) ? true : false);
         GXCCtl = "Z298VacantesUsuariosDocTec_" + sGXsfl_90_idx;
         Z298VacantesUsuariosDocTec = cgiGet( GXCCtl);
         n298VacantesUsuariosDocTec = (String.IsNullOrEmpty(StringUtil.RTrim( A298VacantesUsuariosDocTec)) ? true : false);
         GXCCtl = "Z295VacantesUsuariosFechaE_" + sGXsfl_90_idx;
         Z295VacantesUsuariosFechaE = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n295VacantesUsuariosFechaE = ((DateTime.MinValue==A295VacantesUsuariosFechaE) ? true : false);
         GXCCtl = "Z305VacantesUsuariosDocCVRec_" + sGXsfl_90_idx;
         Z305VacantesUsuariosDocCVRec = cgiGet( GXCCtl);
         n305VacantesUsuariosDocCVRec = (String.IsNullOrEmpty(StringUtil.RTrim( A305VacantesUsuariosDocCVRec)) ? true : false);
         GXCCtl = "Z306VacantesUsuariosDocRefLab_" + sGXsfl_90_idx;
         Z306VacantesUsuariosDocRefLab = cgiGet( GXCCtl);
         n306VacantesUsuariosDocRefLab = (String.IsNullOrEmpty(StringUtil.RTrim( A306VacantesUsuariosDocRefLab)) ? true : false);
         GXCCtl = "Z307VacantesUsuariosDocExPsi_" + sGXsfl_90_idx;
         Z307VacantesUsuariosDocExPsi = cgiGet( GXCCtl);
         n307VacantesUsuariosDocExPsi = (String.IsNullOrEmpty(StringUtil.RTrim( A307VacantesUsuariosDocExPsi)) ? true : false);
         GXCCtl = "Z308VacantesUsuariosDocBusWeb_" + sGXsfl_90_idx;
         Z308VacantesUsuariosDocBusWeb = cgiGet( GXCCtl);
         n308VacantesUsuariosDocBusWeb = (String.IsNullOrEmpty(StringUtil.RTrim( A308VacantesUsuariosDocBusWeb)) ? true : false);
         GXCCtl = "Z309VacantesUsuariosDocAvPriv_" + sGXsfl_90_idx;
         Z309VacantesUsuariosDocAvPriv = cgiGet( GXCCtl);
         n309VacantesUsuariosDocAvPriv = (String.IsNullOrEmpty(StringUtil.RTrim( A309VacantesUsuariosDocAvPriv)) ? true : false);
         GXCCtl = "Z310VacantesUsuariosDocAvConf_" + sGXsfl_90_idx;
         Z310VacantesUsuariosDocAvConf = cgiGet( GXCCtl);
         n310VacantesUsuariosDocAvConf = (String.IsNullOrEmpty(StringUtil.RTrim( A310VacantesUsuariosDocAvConf)) ? true : false);
         GXCCtl = "Z311VacantesUsuariosFechaEnvOp_" + sGXsfl_90_idx;
         Z311VacantesUsuariosFechaEnvOp = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n311VacantesUsuariosFechaEnvOp = ((DateTime.MinValue==A311VacantesUsuariosFechaEnvOp) ? true : false);
         GXCCtl = "Z312VacantesUsuariosFechaEnvCli_" + sGXsfl_90_idx;
         Z312VacantesUsuariosFechaEnvCli = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n312VacantesUsuariosFechaEnvCli = ((DateTime.MinValue==A312VacantesUsuariosFechaEnvCli) ? true : false);
         GXCCtl = "Z284SUBT_ReclutadorId_" + sGXsfl_90_idx;
         Z284SUBT_ReclutadorId = (int)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "Z288VacantesUsuariosFechaP_" + sGXsfl_90_idx;
         A288VacantesUsuariosFechaP = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         GXCCtl = "Z289VacantesUsuariosFechaD_" + sGXsfl_90_idx;
         A289VacantesUsuariosFechaD = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n289VacantesUsuariosFechaD = false;
         n289VacantesUsuariosFechaD = ((DateTime.MinValue==A289VacantesUsuariosFechaD) ? true : false);
         GXCCtl = "Z313VacantesUsuariosFechaA_" + sGXsfl_90_idx;
         A313VacantesUsuariosFechaA = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n313VacantesUsuariosFechaA = false;
         n313VacantesUsuariosFechaA = ((DateTime.MinValue==A313VacantesUsuariosFechaA) ? true : false);
         GXCCtl = "Z314VacantesUsuariosFecha3_" + sGXsfl_90_idx;
         A314VacantesUsuariosFecha3 = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n314VacantesUsuariosFecha3 = false;
         n314VacantesUsuariosFecha3 = ((DateTime.MinValue==A314VacantesUsuariosFecha3) ? true : false);
         GXCCtl = "Z294VacantesUsuariosMotD_" + sGXsfl_90_idx;
         A294VacantesUsuariosMotD = cgiGet( GXCCtl);
         n294VacantesUsuariosMotD = false;
         n294VacantesUsuariosMotD = (String.IsNullOrEmpty(StringUtil.RTrim( A294VacantesUsuariosMotD)) ? true : false);
         GXCCtl = "Z290VacantesUsuariosEstatus_" + sGXsfl_90_idx;
         A290VacantesUsuariosEstatus = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         n290VacantesUsuariosEstatus = false;
         n290VacantesUsuariosEstatus = ((0==A290VacantesUsuariosEstatus) ? true : false);
         GXCCtl = "Z291VacantesUsuariosPrefiltro_" + sGXsfl_90_idx;
         A291VacantesUsuariosPrefiltro = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         n291VacantesUsuariosPrefiltro = false;
         n291VacantesUsuariosPrefiltro = ((0==A291VacantesUsuariosPrefiltro) ? true : false);
         GXCCtl = "Z292VacantesUsuariosCV_" + sGXsfl_90_idx;
         A292VacantesUsuariosCV = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         n292VacantesUsuariosCV = false;
         n292VacantesUsuariosCV = ((0==A292VacantesUsuariosCV) ? true : false);
         GXCCtl = "Z293VacantesUsuariosExTec_" + sGXsfl_90_idx;
         A293VacantesUsuariosExTec = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         n293VacantesUsuariosExTec = false;
         n293VacantesUsuariosExTec = ((0==A293VacantesUsuariosExTec) ? true : false);
         GXCCtl = "Z299VacantesUsuariosCVRec_" + sGXsfl_90_idx;
         A299VacantesUsuariosCVRec = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         n299VacantesUsuariosCVRec = false;
         n299VacantesUsuariosCVRec = ((0==A299VacantesUsuariosCVRec) ? true : false);
         GXCCtl = "Z300VacantesUsuariosRefLab_" + sGXsfl_90_idx;
         A300VacantesUsuariosRefLab = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         n300VacantesUsuariosRefLab = false;
         n300VacantesUsuariosRefLab = ((0==A300VacantesUsuariosRefLab) ? true : false);
         GXCCtl = "Z301VacantesUsuariosExPsi_" + sGXsfl_90_idx;
         A301VacantesUsuariosExPsi = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         n301VacantesUsuariosExPsi = false;
         n301VacantesUsuariosExPsi = ((0==A301VacantesUsuariosExPsi) ? true : false);
         GXCCtl = "Z302VacantesUsuariosBusWeb_" + sGXsfl_90_idx;
         A302VacantesUsuariosBusWeb = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         n302VacantesUsuariosBusWeb = false;
         n302VacantesUsuariosBusWeb = ((0==A302VacantesUsuariosBusWeb) ? true : false);
         GXCCtl = "Z303VacantesUsuariosAvPriv_" + sGXsfl_90_idx;
         A303VacantesUsuariosAvPriv = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         n303VacantesUsuariosAvPriv = false;
         n303VacantesUsuariosAvPriv = ((0==A303VacantesUsuariosAvPriv) ? true : false);
         GXCCtl = "Z304VacantesUsuariosAvConf_" + sGXsfl_90_idx;
         A304VacantesUsuariosAvConf = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         n304VacantesUsuariosAvConf = false;
         n304VacantesUsuariosAvConf = ((0==A304VacantesUsuariosAvConf) ? true : false);
         GXCCtl = "Z296VacantesUsuariosDocP_" + sGXsfl_90_idx;
         A296VacantesUsuariosDocP = cgiGet( GXCCtl);
         n296VacantesUsuariosDocP = false;
         n296VacantesUsuariosDocP = (String.IsNullOrEmpty(StringUtil.RTrim( A296VacantesUsuariosDocP)) ? true : false);
         GXCCtl = "Z297VacantesUsuariosDocCV_" + sGXsfl_90_idx;
         A297VacantesUsuariosDocCV = cgiGet( GXCCtl);
         n297VacantesUsuariosDocCV = false;
         n297VacantesUsuariosDocCV = (String.IsNullOrEmpty(StringUtil.RTrim( A297VacantesUsuariosDocCV)) ? true : false);
         GXCCtl = "Z298VacantesUsuariosDocTec_" + sGXsfl_90_idx;
         A298VacantesUsuariosDocTec = cgiGet( GXCCtl);
         n298VacantesUsuariosDocTec = false;
         n298VacantesUsuariosDocTec = (String.IsNullOrEmpty(StringUtil.RTrim( A298VacantesUsuariosDocTec)) ? true : false);
         GXCCtl = "Z295VacantesUsuariosFechaE_" + sGXsfl_90_idx;
         A295VacantesUsuariosFechaE = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n295VacantesUsuariosFechaE = false;
         n295VacantesUsuariosFechaE = ((DateTime.MinValue==A295VacantesUsuariosFechaE) ? true : false);
         GXCCtl = "Z305VacantesUsuariosDocCVRec_" + sGXsfl_90_idx;
         A305VacantesUsuariosDocCVRec = cgiGet( GXCCtl);
         n305VacantesUsuariosDocCVRec = false;
         n305VacantesUsuariosDocCVRec = (String.IsNullOrEmpty(StringUtil.RTrim( A305VacantesUsuariosDocCVRec)) ? true : false);
         GXCCtl = "Z306VacantesUsuariosDocRefLab_" + sGXsfl_90_idx;
         A306VacantesUsuariosDocRefLab = cgiGet( GXCCtl);
         n306VacantesUsuariosDocRefLab = false;
         n306VacantesUsuariosDocRefLab = (String.IsNullOrEmpty(StringUtil.RTrim( A306VacantesUsuariosDocRefLab)) ? true : false);
         GXCCtl = "Z307VacantesUsuariosDocExPsi_" + sGXsfl_90_idx;
         A307VacantesUsuariosDocExPsi = cgiGet( GXCCtl);
         n307VacantesUsuariosDocExPsi = false;
         n307VacantesUsuariosDocExPsi = (String.IsNullOrEmpty(StringUtil.RTrim( A307VacantesUsuariosDocExPsi)) ? true : false);
         GXCCtl = "Z308VacantesUsuariosDocBusWeb_" + sGXsfl_90_idx;
         A308VacantesUsuariosDocBusWeb = cgiGet( GXCCtl);
         n308VacantesUsuariosDocBusWeb = false;
         n308VacantesUsuariosDocBusWeb = (String.IsNullOrEmpty(StringUtil.RTrim( A308VacantesUsuariosDocBusWeb)) ? true : false);
         GXCCtl = "Z309VacantesUsuariosDocAvPriv_" + sGXsfl_90_idx;
         A309VacantesUsuariosDocAvPriv = cgiGet( GXCCtl);
         n309VacantesUsuariosDocAvPriv = false;
         n309VacantesUsuariosDocAvPriv = (String.IsNullOrEmpty(StringUtil.RTrim( A309VacantesUsuariosDocAvPriv)) ? true : false);
         GXCCtl = "Z310VacantesUsuariosDocAvConf_" + sGXsfl_90_idx;
         A310VacantesUsuariosDocAvConf = cgiGet( GXCCtl);
         n310VacantesUsuariosDocAvConf = false;
         n310VacantesUsuariosDocAvConf = (String.IsNullOrEmpty(StringUtil.RTrim( A310VacantesUsuariosDocAvConf)) ? true : false);
         GXCCtl = "Z311VacantesUsuariosFechaEnvOp_" + sGXsfl_90_idx;
         A311VacantesUsuariosFechaEnvOp = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n311VacantesUsuariosFechaEnvOp = false;
         n311VacantesUsuariosFechaEnvOp = ((DateTime.MinValue==A311VacantesUsuariosFechaEnvOp) ? true : false);
         GXCCtl = "Z312VacantesUsuariosFechaEnvCli_" + sGXsfl_90_idx;
         A312VacantesUsuariosFechaEnvCli = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n312VacantesUsuariosFechaEnvCli = false;
         n312VacantesUsuariosFechaEnvCli = ((DateTime.MinValue==A312VacantesUsuariosFechaEnvCli) ? true : false);
         GXCCtl = "Z284SUBT_ReclutadorId_" + sGXsfl_90_idx;
         A284SUBT_ReclutadorId = (int)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nRcdDeleted_28_" + sGXsfl_90_idx;
         nRcdDeleted_28 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nRcdExists_28_" + sGXsfl_90_idx;
         nRcdExists_28 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nIsMod_28_" + sGXsfl_90_idx;
         nIsMod_28 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
      }

      protected void assign_properties_default( )
      {
         defedtUsuariosId_Enabled = edtUsuariosId_Enabled;
      }

      protected void ConfirmValues0H0( )
      {
         nGXsfl_90_idx = 0;
         sGXsfl_90_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_90_idx), 4, 0), 4, "0");
         SubsflControlProps_9028( ) ;
         while ( nGXsfl_90_idx < nRC_GXsfl_90 )
         {
            nGXsfl_90_idx = (int)(nGXsfl_90_idx+1);
            sGXsfl_90_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_90_idx), 4, 0), 4, "0");
            SubsflControlProps_9028( ) ;
            ChangePostValue( "Z11UsuariosId_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z11UsuariosId_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z11UsuariosId_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z273UsuariosVacanteEstatus_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z273UsuariosVacanteEstatus_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z273UsuariosVacanteEstatus_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z288VacantesUsuariosFechaP_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z288VacantesUsuariosFechaP_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z288VacantesUsuariosFechaP_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z289VacantesUsuariosFechaD_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z289VacantesUsuariosFechaD_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z289VacantesUsuariosFechaD_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z313VacantesUsuariosFechaA_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z313VacantesUsuariosFechaA_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z313VacantesUsuariosFechaA_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z314VacantesUsuariosFecha3_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z314VacantesUsuariosFecha3_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z314VacantesUsuariosFecha3_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z294VacantesUsuariosMotD_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z294VacantesUsuariosMotD_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z294VacantesUsuariosMotD_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z290VacantesUsuariosEstatus_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z290VacantesUsuariosEstatus_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z290VacantesUsuariosEstatus_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z291VacantesUsuariosPrefiltro_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z291VacantesUsuariosPrefiltro_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z291VacantesUsuariosPrefiltro_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z292VacantesUsuariosCV_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z292VacantesUsuariosCV_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z292VacantesUsuariosCV_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z293VacantesUsuariosExTec_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z293VacantesUsuariosExTec_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z293VacantesUsuariosExTec_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z299VacantesUsuariosCVRec_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z299VacantesUsuariosCVRec_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z299VacantesUsuariosCVRec_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z300VacantesUsuariosRefLab_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z300VacantesUsuariosRefLab_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z300VacantesUsuariosRefLab_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z301VacantesUsuariosExPsi_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z301VacantesUsuariosExPsi_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z301VacantesUsuariosExPsi_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z302VacantesUsuariosBusWeb_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z302VacantesUsuariosBusWeb_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z302VacantesUsuariosBusWeb_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z303VacantesUsuariosAvPriv_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z303VacantesUsuariosAvPriv_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z303VacantesUsuariosAvPriv_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z304VacantesUsuariosAvConf_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z304VacantesUsuariosAvConf_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z304VacantesUsuariosAvConf_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z296VacantesUsuariosDocP_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z296VacantesUsuariosDocP_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z296VacantesUsuariosDocP_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z297VacantesUsuariosDocCV_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z297VacantesUsuariosDocCV_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z297VacantesUsuariosDocCV_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z298VacantesUsuariosDocTec_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z298VacantesUsuariosDocTec_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z298VacantesUsuariosDocTec_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z295VacantesUsuariosFechaE_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z295VacantesUsuariosFechaE_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z295VacantesUsuariosFechaE_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z305VacantesUsuariosDocCVRec_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z305VacantesUsuariosDocCVRec_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z305VacantesUsuariosDocCVRec_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z306VacantesUsuariosDocRefLab_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z306VacantesUsuariosDocRefLab_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z306VacantesUsuariosDocRefLab_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z307VacantesUsuariosDocExPsi_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z307VacantesUsuariosDocExPsi_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z307VacantesUsuariosDocExPsi_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z308VacantesUsuariosDocBusWeb_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z308VacantesUsuariosDocBusWeb_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z308VacantesUsuariosDocBusWeb_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z309VacantesUsuariosDocAvPriv_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z309VacantesUsuariosDocAvPriv_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z309VacantesUsuariosDocAvPriv_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z310VacantesUsuariosDocAvConf_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z310VacantesUsuariosDocAvConf_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z310VacantesUsuariosDocAvConf_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z311VacantesUsuariosFechaEnvOp_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z311VacantesUsuariosFechaEnvOp_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z311VacantesUsuariosFechaEnvOp_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z312VacantesUsuariosFechaEnvCli_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z312VacantesUsuariosFechaEnvCli_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z312VacantesUsuariosFechaEnvCli_"+sGXsfl_90_idx) ;
            ChangePostValue( "Z284SUBT_ReclutadorId_"+sGXsfl_90_idx, cgiGet( "ZT_"+"Z284SUBT_ReclutadorId_"+sGXsfl_90_idx)) ;
            DeletePostValue( "ZT_"+"Z284SUBT_ReclutadorId_"+sGXsfl_90_idx) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20226271434441", false, true);
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
         GXEncryptionTmp = "vacantes.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode("" +AV7Vacantes_Id);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("vacantes.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Vacantes");
         forbiddenHiddens.Add("Vacantes_Id", context.localUtil.Format( (decimal)(A263Vacantes_Id), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("vacantes:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z263Vacantes_Id", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z263Vacantes_Id), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z264Vacantes_Nombre", Z264Vacantes_Nombre);
         GxWebStd.gx_hidden_field( context, "Z274Vacantes_Descripcion", Z274Vacantes_Descripcion);
         GxWebStd.gx_hidden_field( context, "Z265Vacantes_Status", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z265Vacantes_Status), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z266Vacantes_FechaInicio", context.localUtil.DToC( Z266Vacantes_FechaInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z267Vacantes_Sueldo", StringUtil.LTrim( StringUtil.NToC( Z267Vacantes_Sueldo, 6, 3, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z268Vacantes_Tipo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z268Vacantes_Tipo), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z269Vacantes_Duracion", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z269Vacantes_Duracion), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z270Vacantes_Duracion_Nom", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z270Vacantes_Duracion_Nom), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z277Vacantes_Plazas", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z277Vacantes_Plazas), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_90", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_90_idx), 8, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vVACANTES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Vacantes_Id), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vVACANTES_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7Vacantes_Id), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV12Pgmname));
         GxWebStd.gx_hidden_field( context, "SUBT_RECLUTADORNOMBRE", A287SUBT_ReclutadorNombre);
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSFECHAP", context.localUtil.TToC( A288VacantesUsuariosFechaP, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSFECHAD", context.localUtil.TToC( A289VacantesUsuariosFechaD, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSFECHAA", context.localUtil.TToC( A313VacantesUsuariosFechaA, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSFECHA3", context.localUtil.TToC( A314VacantesUsuariosFecha3, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSMOTD", A294VacantesUsuariosMotD);
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSESTATUS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A290VacantesUsuariosEstatus), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSPREFILTRO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A291VacantesUsuariosPrefiltro), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSCV", StringUtil.LTrim( StringUtil.NToC( (decimal)(A292VacantesUsuariosCV), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSEXTEC", StringUtil.LTrim( StringUtil.NToC( (decimal)(A293VacantesUsuariosExTec), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSCVREC", StringUtil.LTrim( StringUtil.NToC( (decimal)(A299VacantesUsuariosCVRec), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSREFLAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(A300VacantesUsuariosRefLab), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSEXPSI", StringUtil.LTrim( StringUtil.NToC( (decimal)(A301VacantesUsuariosExPsi), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSBUSWEB", StringUtil.LTrim( StringUtil.NToC( (decimal)(A302VacantesUsuariosBusWeb), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSAVPRIV", StringUtil.LTrim( StringUtil.NToC( (decimal)(A303VacantesUsuariosAvPriv), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSAVCONF", StringUtil.LTrim( StringUtil.NToC( (decimal)(A304VacantesUsuariosAvConf), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSDOCP", A296VacantesUsuariosDocP);
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSDOCCV", A297VacantesUsuariosDocCV);
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSDOCTEC", A298VacantesUsuariosDocTec);
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSFECHAE", context.localUtil.TToC( A295VacantesUsuariosFechaE, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSDOCCVREC", A305VacantesUsuariosDocCVRec);
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSDOCREFLAB", A306VacantesUsuariosDocRefLab);
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSDOCEXPSI", A307VacantesUsuariosDocExPsi);
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSDOCBUSWEB", A308VacantesUsuariosDocBusWeb);
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSDOCAVPRIV", A309VacantesUsuariosDocAvPriv);
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSDOCAVCONF", A310VacantesUsuariosDocAvConf);
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSFECHAENVOP", context.localUtil.TToC( A311VacantesUsuariosFechaEnvOp, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSFECHAENVCLI", context.localUtil.TToC( A312VacantesUsuariosFechaEnvCli, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "SUBT_RECLUTADORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A284SUBT_ReclutadorId), 6, 0, ",", "")));
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
         GXEncryptionTmp = "vacantes.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode("" +AV7Vacantes_Id);
         return formatLink("vacantes.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override String GetPgmname( )
      {
         return "Vacantes" ;
      }

      public override String GetPgmdesc( )
      {
         return "Work With Vacantes" ;
      }

      protected void InitializeNonKey0H21( )
      {
         A264Vacantes_Nombre = "";
         AssignAttri("", false, "A264Vacantes_Nombre", A264Vacantes_Nombre);
         A274Vacantes_Descripcion = "";
         AssignAttri("", false, "A274Vacantes_Descripcion", A274Vacantes_Descripcion);
         A265Vacantes_Status = 0;
         AssignAttri("", false, "A265Vacantes_Status", StringUtil.LTrimStr( (decimal)(A265Vacantes_Status), 4, 0));
         A266Vacantes_FechaInicio = DateTime.MinValue;
         AssignAttri("", false, "A266Vacantes_FechaInicio", context.localUtil.Format(A266Vacantes_FechaInicio, "99/99/99"));
         A267Vacantes_Sueldo = 0;
         AssignAttri("", false, "A267Vacantes_Sueldo", StringUtil.LTrimStr( A267Vacantes_Sueldo, 6, 3));
         A268Vacantes_Tipo = 0;
         AssignAttri("", false, "A268Vacantes_Tipo", StringUtil.LTrimStr( (decimal)(A268Vacantes_Tipo), 4, 0));
         A269Vacantes_Duracion = 0;
         AssignAttri("", false, "A269Vacantes_Duracion", StringUtil.LTrimStr( (decimal)(A269Vacantes_Duracion), 4, 0));
         A270Vacantes_Duracion_Nom = 0;
         AssignAttri("", false, "A270Vacantes_Duracion_Nom", StringUtil.LTrimStr( (decimal)(A270Vacantes_Duracion_Nom), 4, 0));
         A277Vacantes_Plazas = 0;
         AssignAttri("", false, "A277Vacantes_Plazas", StringUtil.LTrimStr( (decimal)(A277Vacantes_Plazas), 4, 0));
         Z264Vacantes_Nombre = "";
         Z274Vacantes_Descripcion = "";
         Z265Vacantes_Status = 0;
         Z266Vacantes_FechaInicio = DateTime.MinValue;
         Z267Vacantes_Sueldo = 0;
         Z268Vacantes_Tipo = 0;
         Z269Vacantes_Duracion = 0;
         Z270Vacantes_Duracion_Nom = 0;
         Z277Vacantes_Plazas = 0;
      }

      protected void InitAll0H21( )
      {
         A263Vacantes_Id = 0;
         AssignAttri("", false, "A263Vacantes_Id", StringUtil.LTrimStr( (decimal)(A263Vacantes_Id), 9, 0));
         InitializeNonKey0H21( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0H28( )
      {
         A66UsuariosNombre = "";
         A65UsuariosApPat = "";
         A64UsuariosApMat = "";
         A273UsuariosVacanteEstatus = 0;
         A284SUBT_ReclutadorId = 0;
         AssignAttri("", false, "A284SUBT_ReclutadorId", StringUtil.LTrimStr( (decimal)(A284SUBT_ReclutadorId), 6, 0));
         A287SUBT_ReclutadorNombre = "";
         AssignAttri("", false, "A287SUBT_ReclutadorNombre", A287SUBT_ReclutadorNombre);
         A288VacantesUsuariosFechaP = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A288VacantesUsuariosFechaP", context.localUtil.TToC( A288VacantesUsuariosFechaP, 10, 5, 0, 3, "/", ":", " "));
         A289VacantesUsuariosFechaD = (DateTime)(DateTime.MinValue);
         n289VacantesUsuariosFechaD = false;
         AssignAttri("", false, "A289VacantesUsuariosFechaD", context.localUtil.TToC( A289VacantesUsuariosFechaD, 8, 5, 0, 3, "/", ":", " "));
         A313VacantesUsuariosFechaA = (DateTime)(DateTime.MinValue);
         n313VacantesUsuariosFechaA = false;
         AssignAttri("", false, "A313VacantesUsuariosFechaA", context.localUtil.TToC( A313VacantesUsuariosFechaA, 8, 5, 0, 3, "/", ":", " "));
         A314VacantesUsuariosFecha3 = (DateTime)(DateTime.MinValue);
         n314VacantesUsuariosFecha3 = false;
         AssignAttri("", false, "A314VacantesUsuariosFecha3", context.localUtil.TToC( A314VacantesUsuariosFecha3, 8, 5, 0, 3, "/", ":", " "));
         A294VacantesUsuariosMotD = "";
         n294VacantesUsuariosMotD = false;
         AssignAttri("", false, "A294VacantesUsuariosMotD", A294VacantesUsuariosMotD);
         A290VacantesUsuariosEstatus = 0;
         n290VacantesUsuariosEstatus = false;
         AssignAttri("", false, "A290VacantesUsuariosEstatus", StringUtil.LTrimStr( (decimal)(A290VacantesUsuariosEstatus), 4, 0));
         A291VacantesUsuariosPrefiltro = 0;
         n291VacantesUsuariosPrefiltro = false;
         AssignAttri("", false, "A291VacantesUsuariosPrefiltro", StringUtil.LTrimStr( (decimal)(A291VacantesUsuariosPrefiltro), 4, 0));
         A292VacantesUsuariosCV = 0;
         n292VacantesUsuariosCV = false;
         AssignAttri("", false, "A292VacantesUsuariosCV", StringUtil.LTrimStr( (decimal)(A292VacantesUsuariosCV), 4, 0));
         A293VacantesUsuariosExTec = 0;
         n293VacantesUsuariosExTec = false;
         AssignAttri("", false, "A293VacantesUsuariosExTec", StringUtil.LTrimStr( (decimal)(A293VacantesUsuariosExTec), 4, 0));
         A299VacantesUsuariosCVRec = 0;
         n299VacantesUsuariosCVRec = false;
         AssignAttri("", false, "A299VacantesUsuariosCVRec", StringUtil.LTrimStr( (decimal)(A299VacantesUsuariosCVRec), 4, 0));
         A300VacantesUsuariosRefLab = 0;
         n300VacantesUsuariosRefLab = false;
         AssignAttri("", false, "A300VacantesUsuariosRefLab", StringUtil.LTrimStr( (decimal)(A300VacantesUsuariosRefLab), 4, 0));
         A301VacantesUsuariosExPsi = 0;
         n301VacantesUsuariosExPsi = false;
         AssignAttri("", false, "A301VacantesUsuariosExPsi", StringUtil.LTrimStr( (decimal)(A301VacantesUsuariosExPsi), 4, 0));
         A302VacantesUsuariosBusWeb = 0;
         n302VacantesUsuariosBusWeb = false;
         AssignAttri("", false, "A302VacantesUsuariosBusWeb", StringUtil.LTrimStr( (decimal)(A302VacantesUsuariosBusWeb), 4, 0));
         A303VacantesUsuariosAvPriv = 0;
         n303VacantesUsuariosAvPriv = false;
         AssignAttri("", false, "A303VacantesUsuariosAvPriv", StringUtil.LTrimStr( (decimal)(A303VacantesUsuariosAvPriv), 4, 0));
         A304VacantesUsuariosAvConf = 0;
         n304VacantesUsuariosAvConf = false;
         AssignAttri("", false, "A304VacantesUsuariosAvConf", StringUtil.LTrimStr( (decimal)(A304VacantesUsuariosAvConf), 4, 0));
         A296VacantesUsuariosDocP = "";
         n296VacantesUsuariosDocP = false;
         AssignAttri("", false, "A296VacantesUsuariosDocP", A296VacantesUsuariosDocP);
         A297VacantesUsuariosDocCV = "";
         n297VacantesUsuariosDocCV = false;
         AssignAttri("", false, "A297VacantesUsuariosDocCV", A297VacantesUsuariosDocCV);
         A298VacantesUsuariosDocTec = "";
         n298VacantesUsuariosDocTec = false;
         AssignAttri("", false, "A298VacantesUsuariosDocTec", A298VacantesUsuariosDocTec);
         A295VacantesUsuariosFechaE = (DateTime)(DateTime.MinValue);
         n295VacantesUsuariosFechaE = false;
         AssignAttri("", false, "A295VacantesUsuariosFechaE", context.localUtil.TToC( A295VacantesUsuariosFechaE, 8, 5, 0, 3, "/", ":", " "));
         A305VacantesUsuariosDocCVRec = "";
         n305VacantesUsuariosDocCVRec = false;
         AssignAttri("", false, "A305VacantesUsuariosDocCVRec", A305VacantesUsuariosDocCVRec);
         A306VacantesUsuariosDocRefLab = "";
         n306VacantesUsuariosDocRefLab = false;
         AssignAttri("", false, "A306VacantesUsuariosDocRefLab", A306VacantesUsuariosDocRefLab);
         A307VacantesUsuariosDocExPsi = "";
         n307VacantesUsuariosDocExPsi = false;
         AssignAttri("", false, "A307VacantesUsuariosDocExPsi", A307VacantesUsuariosDocExPsi);
         A308VacantesUsuariosDocBusWeb = "";
         n308VacantesUsuariosDocBusWeb = false;
         AssignAttri("", false, "A308VacantesUsuariosDocBusWeb", A308VacantesUsuariosDocBusWeb);
         A309VacantesUsuariosDocAvPriv = "";
         n309VacantesUsuariosDocAvPriv = false;
         AssignAttri("", false, "A309VacantesUsuariosDocAvPriv", A309VacantesUsuariosDocAvPriv);
         A310VacantesUsuariosDocAvConf = "";
         n310VacantesUsuariosDocAvConf = false;
         AssignAttri("", false, "A310VacantesUsuariosDocAvConf", A310VacantesUsuariosDocAvConf);
         A311VacantesUsuariosFechaEnvOp = (DateTime)(DateTime.MinValue);
         n311VacantesUsuariosFechaEnvOp = false;
         AssignAttri("", false, "A311VacantesUsuariosFechaEnvOp", context.localUtil.TToC( A311VacantesUsuariosFechaEnvOp, 8, 5, 0, 3, "/", ":", " "));
         A312VacantesUsuariosFechaEnvCli = (DateTime)(DateTime.MinValue);
         n312VacantesUsuariosFechaEnvCli = false;
         AssignAttri("", false, "A312VacantesUsuariosFechaEnvCli", context.localUtil.TToC( A312VacantesUsuariosFechaEnvCli, 8, 5, 0, 3, "/", ":", " "));
         Z273UsuariosVacanteEstatus = 0;
         Z288VacantesUsuariosFechaP = (DateTime)(DateTime.MinValue);
         Z289VacantesUsuariosFechaD = (DateTime)(DateTime.MinValue);
         Z313VacantesUsuariosFechaA = (DateTime)(DateTime.MinValue);
         Z314VacantesUsuariosFecha3 = (DateTime)(DateTime.MinValue);
         Z294VacantesUsuariosMotD = "";
         Z290VacantesUsuariosEstatus = 0;
         Z291VacantesUsuariosPrefiltro = 0;
         Z292VacantesUsuariosCV = 0;
         Z293VacantesUsuariosExTec = 0;
         Z299VacantesUsuariosCVRec = 0;
         Z300VacantesUsuariosRefLab = 0;
         Z301VacantesUsuariosExPsi = 0;
         Z302VacantesUsuariosBusWeb = 0;
         Z303VacantesUsuariosAvPriv = 0;
         Z304VacantesUsuariosAvConf = 0;
         Z296VacantesUsuariosDocP = "";
         Z297VacantesUsuariosDocCV = "";
         Z298VacantesUsuariosDocTec = "";
         Z295VacantesUsuariosFechaE = (DateTime)(DateTime.MinValue);
         Z305VacantesUsuariosDocCVRec = "";
         Z306VacantesUsuariosDocRefLab = "";
         Z307VacantesUsuariosDocExPsi = "";
         Z308VacantesUsuariosDocBusWeb = "";
         Z309VacantesUsuariosDocAvPriv = "";
         Z310VacantesUsuariosDocAvConf = "";
         Z311VacantesUsuariosFechaEnvOp = (DateTime)(DateTime.MinValue);
         Z312VacantesUsuariosFechaEnvCli = (DateTime)(DateTime.MinValue);
         Z284SUBT_ReclutadorId = 0;
      }

      protected void InitAll0H28( )
      {
         A11UsuariosId = 0;
         InitializeNonKey0H28( ) ;
      }

      protected void StandaloneModalInsert0H28( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714344419", true, true);
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
         context.AddJavascriptSource("vacantes.js", "?202262714344419", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties28( )
      {
         edtUsuariosId_Enabled = defedtUsuariosId_Enabled;
         AssignProp("", false, edtUsuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosId_Enabled), 5, 0), !bGXsfl_90_Refreshing);
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         lblViellall_Internalname = "VIELLALL";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtVacantes_Id_Internalname = "VACANTES_ID";
         edtVacantes_Nombre_Internalname = "VACANTES_NOMBRE";
         edtVacantes_Descripcion_Internalname = "VACANTES_DESCRIPCION";
         cmbVacantes_Status_Internalname = "VACANTES_STATUS";
         edtVacantes_FechaInicio_Internalname = "VACANTES_FECHAINICIO";
         edtVacantes_Sueldo_Internalname = "VACANTES_SUELDO";
         cmbVacantes_Tipo_Internalname = "VACANTES_TIPO";
         edtVacantes_Duracion_Internalname = "VACANTES_DURACION";
         cmbVacantes_Duracion_Nom_Internalname = "VACANTES_DURACION_NOM";
         edtVacantes_Plazas_Internalname = "VACANTES_PLAZAS";
         lblTitleusuariosvacante_Internalname = "TITLEUSUARIOSVACANTE";
         edtUsuariosId_Internalname = "USUARIOSID";
         edtUsuariosNombre_Internalname = "USUARIOSNOMBRE";
         edtUsuariosApPat_Internalname = "USUARIOSAPPAT";
         edtUsuariosApMat_Internalname = "USUARIOSAPMAT";
         cmbUsuariosVacanteEstatus_Internalname = "USUARIOSVACANTEESTATUS";
         divUsuariosvacantetable_Internalname = "USUARIOSVACANTETABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridvacantes_usuariosvacante_Internalname = "GRIDVACANTES_USUARIOSVACANTE";
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
         Form.Caption = "Work With Vacantes";
         cmbUsuariosVacanteEstatus_Jsonclick = "";
         edtUsuariosApMat_Jsonclick = "";
         edtUsuariosApPat_Jsonclick = "";
         edtUsuariosNombre_Jsonclick = "";
         edtUsuariosId_Jsonclick = "";
         subGridvacantes_usuariosvacante_Class = "Grid";
         subGridvacantes_usuariosvacante_Backcolorstyle = 0;
         subGridvacantes_usuariosvacante_Allowcollapsing = 0;
         subGridvacantes_usuariosvacante_Allowselection = 0;
         cmbUsuariosVacanteEstatus.Enabled = 1;
         edtUsuariosApMat_Enabled = 0;
         edtUsuariosApPat_Enabled = 0;
         edtUsuariosNombre_Enabled = 0;
         edtUsuariosId_Enabled = 1;
         subGridvacantes_usuariosvacante_Header = "";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtVacantes_Plazas_Jsonclick = "";
         edtVacantes_Plazas_Enabled = 1;
         cmbVacantes_Duracion_Nom_Jsonclick = "";
         cmbVacantes_Duracion_Nom.Enabled = 1;
         edtVacantes_Duracion_Jsonclick = "";
         edtVacantes_Duracion_Enabled = 1;
         cmbVacantes_Tipo_Jsonclick = "";
         cmbVacantes_Tipo.Enabled = 1;
         edtVacantes_Sueldo_Jsonclick = "";
         edtVacantes_Sueldo_Enabled = 1;
         edtVacantes_FechaInicio_Jsonclick = "";
         edtVacantes_FechaInicio_Enabled = 1;
         cmbVacantes_Status_Jsonclick = "";
         cmbVacantes_Status.Enabled = 1;
         edtVacantes_Descripcion_Enabled = 1;
         edtVacantes_Nombre_Jsonclick = "";
         edtVacantes_Nombre_Enabled = 1;
         edtVacantes_Id_Jsonclick = "";
         edtVacantes_Id_Enabled = 0;
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

      protected void gxnrGridvacantes_usuariosvacante_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_9028( ) ;
         while ( nGXsfl_90_idx <= nRC_GXsfl_90 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0H28( ) ;
            standaloneModal0H28( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0H28( ) ;
            nGXsfl_90_idx = (int)(nGXsfl_90_idx+1);
            sGXsfl_90_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_90_idx), 4, 0), 4, "0");
            SubsflControlProps_9028( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridvacantes_usuariosvacanteContainer)) ;
         /* End function gxnrGridvacantes_usuariosvacante_newrow */
      }

      protected void init_web_controls( )
      {
         cmbVacantes_Status.Name = "VACANTES_STATUS";
         cmbVacantes_Status.WebTags = "";
         cmbVacantes_Status.addItem("1", "Activo", 0);
         cmbVacantes_Status.addItem("2", "Inactivo", 0);
         cmbVacantes_Status.addItem("3", "Espera", 0);
         if ( cmbVacantes_Status.ItemCount > 0 )
         {
            A265Vacantes_Status = (short)(NumberUtil.Val( cmbVacantes_Status.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A265Vacantes_Status), 4, 0))), "."));
            AssignAttri("", false, "A265Vacantes_Status", StringUtil.LTrimStr( (decimal)(A265Vacantes_Status), 4, 0));
         }
         cmbVacantes_Tipo.Name = "VACANTES_TIPO";
         cmbVacantes_Tipo.WebTags = "";
         cmbVacantes_Tipo.addItem("1", "Home Office", 0);
         cmbVacantes_Tipo.addItem("2", "Presencial", 0);
         cmbVacantes_Tipo.addItem("3", "Mixto", 0);
         if ( cmbVacantes_Tipo.ItemCount > 0 )
         {
            A268Vacantes_Tipo = (short)(NumberUtil.Val( cmbVacantes_Tipo.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A268Vacantes_Tipo), 4, 0))), "."));
            AssignAttri("", false, "A268Vacantes_Tipo", StringUtil.LTrimStr( (decimal)(A268Vacantes_Tipo), 4, 0));
         }
         cmbVacantes_Duracion_Nom.Name = "VACANTES_DURACION_NOM";
         cmbVacantes_Duracion_Nom.WebTags = "";
         cmbVacantes_Duracion_Nom.addItem("1", "Dias", 0);
         cmbVacantes_Duracion_Nom.addItem("2", "Meses", 0);
         cmbVacantes_Duracion_Nom.addItem("3", "Años", 0);
         if ( cmbVacantes_Duracion_Nom.ItemCount > 0 )
         {
            A270Vacantes_Duracion_Nom = (short)(NumberUtil.Val( cmbVacantes_Duracion_Nom.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A270Vacantes_Duracion_Nom), 4, 0))), "."));
            AssignAttri("", false, "A270Vacantes_Duracion_Nom", StringUtil.LTrimStr( (decimal)(A270Vacantes_Duracion_Nom), 4, 0));
         }
         GXCCtl = "USUARIOSVACANTEESTATUS_" + sGXsfl_90_idx;
         cmbUsuariosVacanteEstatus.Name = GXCCtl;
         cmbUsuariosVacanteEstatus.WebTags = "";
         cmbUsuariosVacanteEstatus.addItem("0", "1er Filtro", 0);
         cmbUsuariosVacanteEstatus.addItem("1", "2do Filtro", 0);
         cmbUsuariosVacanteEstatus.addItem("2", "3er Filtro", 0);
         cmbUsuariosVacanteEstatus.addItem("3", "Todo Proceso", 0);
         cmbUsuariosVacanteEstatus.addItem("4", "Enviado Cliente", 0);
         if ( cmbUsuariosVacanteEstatus.ItemCount > 0 )
         {
            A273UsuariosVacanteEstatus = (short)(NumberUtil.Val( cmbUsuariosVacanteEstatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A273UsuariosVacanteEstatus), 1, 0))), "."));
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
         /* Using cursor T000H23 */
         pr_default.execute(21, new Object[] {A11UsuariosId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Tabla de usuarios'.", "ForeignKeyNotFound", 1, "USUARIOSID");
            AnyError = 1;
            GX_FocusControl = edtUsuariosId_Internalname;
         }
         A66UsuariosNombre = T000H23_A66UsuariosNombre[0];
         A65UsuariosApPat = T000H23_A65UsuariosApPat[0];
         A64UsuariosApMat = T000H23_A64UsuariosApMat[0];
         pr_default.close(21);
         A287SUBT_ReclutadorNombre = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + StringUtil.Trim( A64UsuariosApMat);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A66UsuariosNombre", A66UsuariosNombre);
         AssignAttri("", false, "A65UsuariosApPat", A65UsuariosApPat);
         AssignAttri("", false, "A64UsuariosApMat", A64UsuariosApMat);
         AssignAttri("", false, "A287SUBT_ReclutadorNombre", A287SUBT_ReclutadorNombre);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9',hsh:true},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E130H2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("'RETORNO'","{handler:'E110H21',iparms:[]");
         setEventMetadata("'RETORNO'",",oparms:[]}");
         setEventMetadata("VALID_VACANTES_ID","{handler:'Valid_Vacantes_id',iparms:[]");
         setEventMetadata("VALID_VACANTES_ID",",oparms:[]}");
         setEventMetadata("VALID_VACANTES_FECHAINICIO","{handler:'Valid_Vacantes_fechainicio',iparms:[]");
         setEventMetadata("VALID_VACANTES_FECHAINICIO",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSID","{handler:'Valid_Usuariosid',iparms:[{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A66UsuariosNombre',fld:'USUARIOSNOMBRE',pic:'@!'},{av:'A65UsuariosApPat',fld:'USUARIOSAPPAT',pic:'@!'},{av:'A64UsuariosApMat',fld:'USUARIOSAPMAT',pic:'@!'},{av:'A287SUBT_ReclutadorNombre',fld:'SUBT_RECLUTADORNOMBRE',pic:''}]");
         setEventMetadata("VALID_USUARIOSID",",oparms:[{av:'A66UsuariosNombre',fld:'USUARIOSNOMBRE',pic:'@!'},{av:'A65UsuariosApPat',fld:'USUARIOSAPPAT',pic:'@!'},{av:'A64UsuariosApMat',fld:'USUARIOSAPMAT',pic:'@!'},{av:'A287SUBT_ReclutadorNombre',fld:'SUBT_RECLUTADORNOMBRE',pic:''}]}");
         setEventMetadata("VALID_USUARIOSNOMBRE","{handler:'Valid_Usuariosnombre',iparms:[]");
         setEventMetadata("VALID_USUARIOSNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSAPPAT","{handler:'Valid_Usuariosappat',iparms:[]");
         setEventMetadata("VALID_USUARIOSAPPAT",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSAPMAT","{handler:'Valid_Usuariosapmat',iparms:[]");
         setEventMetadata("VALID_USUARIOSAPMAT",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Usuariosvacanteestatus',iparms:[]");
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
         pr_default.close(21);
         pr_default.close(5);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z264Vacantes_Nombre = "";
         Z274Vacantes_Descripcion = "";
         Z266Vacantes_FechaInicio = DateTime.MinValue;
         Z288VacantesUsuariosFechaP = (DateTime)(DateTime.MinValue);
         Z289VacantesUsuariosFechaD = (DateTime)(DateTime.MinValue);
         Z313VacantesUsuariosFechaA = (DateTime)(DateTime.MinValue);
         Z314VacantesUsuariosFecha3 = (DateTime)(DateTime.MinValue);
         Z294VacantesUsuariosMotD = "";
         Z296VacantesUsuariosDocP = "";
         Z297VacantesUsuariosDocCV = "";
         Z298VacantesUsuariosDocTec = "";
         Z295VacantesUsuariosFechaE = (DateTime)(DateTime.MinValue);
         Z305VacantesUsuariosDocCVRec = "";
         Z306VacantesUsuariosDocRefLab = "";
         Z307VacantesUsuariosDocExPsi = "";
         Z308VacantesUsuariosDocBusWeb = "";
         Z309VacantesUsuariosDocAvPriv = "";
         Z310VacantesUsuariosDocAvConf = "";
         Z311VacantesUsuariosFechaEnvOp = (DateTime)(DateTime.MinValue);
         Z312VacantesUsuariosFechaEnvCli = (DateTime)(DateTime.MinValue);
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         lblViellall_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A264Vacantes_Nombre = "";
         A274Vacantes_Descripcion = "";
         A266Vacantes_FechaInicio = DateTime.MinValue;
         lblTitleusuariosvacante_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridvacantes_usuariosvacanteContainer = new GXWebGrid( context);
         Gridvacantes_usuariosvacanteColumn = new GXWebColumn();
         A66UsuariosNombre = "";
         A65UsuariosApPat = "";
         A64UsuariosApMat = "";
         sMode28 = "";
         sStyleString = "";
         AV12Pgmname = "";
         A287SUBT_ReclutadorNombre = "";
         A288VacantesUsuariosFechaP = (DateTime)(DateTime.MinValue);
         A289VacantesUsuariosFechaD = (DateTime)(DateTime.MinValue);
         A313VacantesUsuariosFechaA = (DateTime)(DateTime.MinValue);
         A314VacantesUsuariosFecha3 = (DateTime)(DateTime.MinValue);
         A294VacantesUsuariosMotD = "";
         A296VacantesUsuariosDocP = "";
         A297VacantesUsuariosDocCV = "";
         A298VacantesUsuariosDocTec = "";
         A295VacantesUsuariosFechaE = (DateTime)(DateTime.MinValue);
         A305VacantesUsuariosDocCVRec = "";
         A306VacantesUsuariosDocRefLab = "";
         A307VacantesUsuariosDocExPsi = "";
         A308VacantesUsuariosDocBusWeb = "";
         A309VacantesUsuariosDocAvPriv = "";
         A310VacantesUsuariosDocAvConf = "";
         A311VacantesUsuariosFechaEnvOp = (DateTime)(DateTime.MinValue);
         A312VacantesUsuariosFechaEnvCli = (DateTime)(DateTime.MinValue);
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode21 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         T000H8_A263Vacantes_Id = new int[1] ;
         T000H8_A264Vacantes_Nombre = new String[] {""} ;
         T000H8_A274Vacantes_Descripcion = new String[] {""} ;
         T000H8_A265Vacantes_Status = new short[1] ;
         T000H8_A266Vacantes_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         T000H8_A267Vacantes_Sueldo = new decimal[1] ;
         T000H8_A268Vacantes_Tipo = new short[1] ;
         T000H8_A269Vacantes_Duracion = new short[1] ;
         T000H8_A270Vacantes_Duracion_Nom = new short[1] ;
         T000H8_A277Vacantes_Plazas = new short[1] ;
         T000H9_A263Vacantes_Id = new int[1] ;
         T000H7_A263Vacantes_Id = new int[1] ;
         T000H7_A264Vacantes_Nombre = new String[] {""} ;
         T000H7_A274Vacantes_Descripcion = new String[] {""} ;
         T000H7_A265Vacantes_Status = new short[1] ;
         T000H7_A266Vacantes_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         T000H7_A267Vacantes_Sueldo = new decimal[1] ;
         T000H7_A268Vacantes_Tipo = new short[1] ;
         T000H7_A269Vacantes_Duracion = new short[1] ;
         T000H7_A270Vacantes_Duracion_Nom = new short[1] ;
         T000H7_A277Vacantes_Plazas = new short[1] ;
         T000H10_A263Vacantes_Id = new int[1] ;
         T000H11_A263Vacantes_Id = new int[1] ;
         T000H6_A263Vacantes_Id = new int[1] ;
         T000H6_A264Vacantes_Nombre = new String[] {""} ;
         T000H6_A274Vacantes_Descripcion = new String[] {""} ;
         T000H6_A265Vacantes_Status = new short[1] ;
         T000H6_A266Vacantes_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         T000H6_A267Vacantes_Sueldo = new decimal[1] ;
         T000H6_A268Vacantes_Tipo = new short[1] ;
         T000H6_A269Vacantes_Duracion = new short[1] ;
         T000H6_A270Vacantes_Duracion_Nom = new short[1] ;
         T000H6_A277Vacantes_Plazas = new short[1] ;
         T000H13_A263Vacantes_Id = new int[1] ;
         T000H16_A263Vacantes_Id = new int[1] ;
         Z66UsuariosNombre = "";
         Z65UsuariosApPat = "";
         Z64UsuariosApMat = "";
         T000H5_A284SUBT_ReclutadorId = new int[1] ;
         T000H17_A263Vacantes_Id = new int[1] ;
         T000H17_A66UsuariosNombre = new String[] {""} ;
         T000H17_A65UsuariosApPat = new String[] {""} ;
         T000H17_A64UsuariosApMat = new String[] {""} ;
         T000H17_A273UsuariosVacanteEstatus = new short[1] ;
         T000H17_A288VacantesUsuariosFechaP = new DateTime[] {DateTime.MinValue} ;
         T000H17_A289VacantesUsuariosFechaD = new DateTime[] {DateTime.MinValue} ;
         T000H17_n289VacantesUsuariosFechaD = new bool[] {false} ;
         T000H17_A313VacantesUsuariosFechaA = new DateTime[] {DateTime.MinValue} ;
         T000H17_n313VacantesUsuariosFechaA = new bool[] {false} ;
         T000H17_A314VacantesUsuariosFecha3 = new DateTime[] {DateTime.MinValue} ;
         T000H17_n314VacantesUsuariosFecha3 = new bool[] {false} ;
         T000H17_A294VacantesUsuariosMotD = new String[] {""} ;
         T000H17_n294VacantesUsuariosMotD = new bool[] {false} ;
         T000H17_A290VacantesUsuariosEstatus = new short[1] ;
         T000H17_n290VacantesUsuariosEstatus = new bool[] {false} ;
         T000H17_A291VacantesUsuariosPrefiltro = new short[1] ;
         T000H17_n291VacantesUsuariosPrefiltro = new bool[] {false} ;
         T000H17_A292VacantesUsuariosCV = new short[1] ;
         T000H17_n292VacantesUsuariosCV = new bool[] {false} ;
         T000H17_A293VacantesUsuariosExTec = new short[1] ;
         T000H17_n293VacantesUsuariosExTec = new bool[] {false} ;
         T000H17_A299VacantesUsuariosCVRec = new short[1] ;
         T000H17_n299VacantesUsuariosCVRec = new bool[] {false} ;
         T000H17_A300VacantesUsuariosRefLab = new short[1] ;
         T000H17_n300VacantesUsuariosRefLab = new bool[] {false} ;
         T000H17_A301VacantesUsuariosExPsi = new short[1] ;
         T000H17_n301VacantesUsuariosExPsi = new bool[] {false} ;
         T000H17_A302VacantesUsuariosBusWeb = new short[1] ;
         T000H17_n302VacantesUsuariosBusWeb = new bool[] {false} ;
         T000H17_A303VacantesUsuariosAvPriv = new short[1] ;
         T000H17_n303VacantesUsuariosAvPriv = new bool[] {false} ;
         T000H17_A304VacantesUsuariosAvConf = new short[1] ;
         T000H17_n304VacantesUsuariosAvConf = new bool[] {false} ;
         T000H17_A296VacantesUsuariosDocP = new String[] {""} ;
         T000H17_n296VacantesUsuariosDocP = new bool[] {false} ;
         T000H17_A297VacantesUsuariosDocCV = new String[] {""} ;
         T000H17_n297VacantesUsuariosDocCV = new bool[] {false} ;
         T000H17_A298VacantesUsuariosDocTec = new String[] {""} ;
         T000H17_n298VacantesUsuariosDocTec = new bool[] {false} ;
         T000H17_A295VacantesUsuariosFechaE = new DateTime[] {DateTime.MinValue} ;
         T000H17_n295VacantesUsuariosFechaE = new bool[] {false} ;
         T000H17_A305VacantesUsuariosDocCVRec = new String[] {""} ;
         T000H17_n305VacantesUsuariosDocCVRec = new bool[] {false} ;
         T000H17_A306VacantesUsuariosDocRefLab = new String[] {""} ;
         T000H17_n306VacantesUsuariosDocRefLab = new bool[] {false} ;
         T000H17_A307VacantesUsuariosDocExPsi = new String[] {""} ;
         T000H17_n307VacantesUsuariosDocExPsi = new bool[] {false} ;
         T000H17_A308VacantesUsuariosDocBusWeb = new String[] {""} ;
         T000H17_n308VacantesUsuariosDocBusWeb = new bool[] {false} ;
         T000H17_A309VacantesUsuariosDocAvPriv = new String[] {""} ;
         T000H17_n309VacantesUsuariosDocAvPriv = new bool[] {false} ;
         T000H17_A310VacantesUsuariosDocAvConf = new String[] {""} ;
         T000H17_n310VacantesUsuariosDocAvConf = new bool[] {false} ;
         T000H17_A311VacantesUsuariosFechaEnvOp = new DateTime[] {DateTime.MinValue} ;
         T000H17_n311VacantesUsuariosFechaEnvOp = new bool[] {false} ;
         T000H17_A312VacantesUsuariosFechaEnvCli = new DateTime[] {DateTime.MinValue} ;
         T000H17_n312VacantesUsuariosFechaEnvCli = new bool[] {false} ;
         T000H17_A11UsuariosId = new int[1] ;
         T000H17_A284SUBT_ReclutadorId = new int[1] ;
         T000H4_A66UsuariosNombre = new String[] {""} ;
         T000H4_A65UsuariosApPat = new String[] {""} ;
         T000H4_A64UsuariosApMat = new String[] {""} ;
         T000H18_A66UsuariosNombre = new String[] {""} ;
         T000H18_A65UsuariosApPat = new String[] {""} ;
         T000H18_A64UsuariosApMat = new String[] {""} ;
         T000H19_A263Vacantes_Id = new int[1] ;
         T000H19_A11UsuariosId = new int[1] ;
         T000H3_A263Vacantes_Id = new int[1] ;
         T000H3_A273UsuariosVacanteEstatus = new short[1] ;
         T000H3_A288VacantesUsuariosFechaP = new DateTime[] {DateTime.MinValue} ;
         T000H3_A289VacantesUsuariosFechaD = new DateTime[] {DateTime.MinValue} ;
         T000H3_n289VacantesUsuariosFechaD = new bool[] {false} ;
         T000H3_A313VacantesUsuariosFechaA = new DateTime[] {DateTime.MinValue} ;
         T000H3_n313VacantesUsuariosFechaA = new bool[] {false} ;
         T000H3_A314VacantesUsuariosFecha3 = new DateTime[] {DateTime.MinValue} ;
         T000H3_n314VacantesUsuariosFecha3 = new bool[] {false} ;
         T000H3_A294VacantesUsuariosMotD = new String[] {""} ;
         T000H3_n294VacantesUsuariosMotD = new bool[] {false} ;
         T000H3_A290VacantesUsuariosEstatus = new short[1] ;
         T000H3_n290VacantesUsuariosEstatus = new bool[] {false} ;
         T000H3_A291VacantesUsuariosPrefiltro = new short[1] ;
         T000H3_n291VacantesUsuariosPrefiltro = new bool[] {false} ;
         T000H3_A292VacantesUsuariosCV = new short[1] ;
         T000H3_n292VacantesUsuariosCV = new bool[] {false} ;
         T000H3_A293VacantesUsuariosExTec = new short[1] ;
         T000H3_n293VacantesUsuariosExTec = new bool[] {false} ;
         T000H3_A299VacantesUsuariosCVRec = new short[1] ;
         T000H3_n299VacantesUsuariosCVRec = new bool[] {false} ;
         T000H3_A300VacantesUsuariosRefLab = new short[1] ;
         T000H3_n300VacantesUsuariosRefLab = new bool[] {false} ;
         T000H3_A301VacantesUsuariosExPsi = new short[1] ;
         T000H3_n301VacantesUsuariosExPsi = new bool[] {false} ;
         T000H3_A302VacantesUsuariosBusWeb = new short[1] ;
         T000H3_n302VacantesUsuariosBusWeb = new bool[] {false} ;
         T000H3_A303VacantesUsuariosAvPriv = new short[1] ;
         T000H3_n303VacantesUsuariosAvPriv = new bool[] {false} ;
         T000H3_A304VacantesUsuariosAvConf = new short[1] ;
         T000H3_n304VacantesUsuariosAvConf = new bool[] {false} ;
         T000H3_A296VacantesUsuariosDocP = new String[] {""} ;
         T000H3_n296VacantesUsuariosDocP = new bool[] {false} ;
         T000H3_A297VacantesUsuariosDocCV = new String[] {""} ;
         T000H3_n297VacantesUsuariosDocCV = new bool[] {false} ;
         T000H3_A298VacantesUsuariosDocTec = new String[] {""} ;
         T000H3_n298VacantesUsuariosDocTec = new bool[] {false} ;
         T000H3_A295VacantesUsuariosFechaE = new DateTime[] {DateTime.MinValue} ;
         T000H3_n295VacantesUsuariosFechaE = new bool[] {false} ;
         T000H3_A305VacantesUsuariosDocCVRec = new String[] {""} ;
         T000H3_n305VacantesUsuariosDocCVRec = new bool[] {false} ;
         T000H3_A306VacantesUsuariosDocRefLab = new String[] {""} ;
         T000H3_n306VacantesUsuariosDocRefLab = new bool[] {false} ;
         T000H3_A307VacantesUsuariosDocExPsi = new String[] {""} ;
         T000H3_n307VacantesUsuariosDocExPsi = new bool[] {false} ;
         T000H3_A308VacantesUsuariosDocBusWeb = new String[] {""} ;
         T000H3_n308VacantesUsuariosDocBusWeb = new bool[] {false} ;
         T000H3_A309VacantesUsuariosDocAvPriv = new String[] {""} ;
         T000H3_n309VacantesUsuariosDocAvPriv = new bool[] {false} ;
         T000H3_A310VacantesUsuariosDocAvConf = new String[] {""} ;
         T000H3_n310VacantesUsuariosDocAvConf = new bool[] {false} ;
         T000H3_A311VacantesUsuariosFechaEnvOp = new DateTime[] {DateTime.MinValue} ;
         T000H3_n311VacantesUsuariosFechaEnvOp = new bool[] {false} ;
         T000H3_A312VacantesUsuariosFechaEnvCli = new DateTime[] {DateTime.MinValue} ;
         T000H3_n312VacantesUsuariosFechaEnvCli = new bool[] {false} ;
         T000H3_A11UsuariosId = new int[1] ;
         T000H3_A284SUBT_ReclutadorId = new int[1] ;
         T000H2_A263Vacantes_Id = new int[1] ;
         T000H2_A273UsuariosVacanteEstatus = new short[1] ;
         T000H2_A288VacantesUsuariosFechaP = new DateTime[] {DateTime.MinValue} ;
         T000H2_A289VacantesUsuariosFechaD = new DateTime[] {DateTime.MinValue} ;
         T000H2_n289VacantesUsuariosFechaD = new bool[] {false} ;
         T000H2_A313VacantesUsuariosFechaA = new DateTime[] {DateTime.MinValue} ;
         T000H2_n313VacantesUsuariosFechaA = new bool[] {false} ;
         T000H2_A314VacantesUsuariosFecha3 = new DateTime[] {DateTime.MinValue} ;
         T000H2_n314VacantesUsuariosFecha3 = new bool[] {false} ;
         T000H2_A294VacantesUsuariosMotD = new String[] {""} ;
         T000H2_n294VacantesUsuariosMotD = new bool[] {false} ;
         T000H2_A290VacantesUsuariosEstatus = new short[1] ;
         T000H2_n290VacantesUsuariosEstatus = new bool[] {false} ;
         T000H2_A291VacantesUsuariosPrefiltro = new short[1] ;
         T000H2_n291VacantesUsuariosPrefiltro = new bool[] {false} ;
         T000H2_A292VacantesUsuariosCV = new short[1] ;
         T000H2_n292VacantesUsuariosCV = new bool[] {false} ;
         T000H2_A293VacantesUsuariosExTec = new short[1] ;
         T000H2_n293VacantesUsuariosExTec = new bool[] {false} ;
         T000H2_A299VacantesUsuariosCVRec = new short[1] ;
         T000H2_n299VacantesUsuariosCVRec = new bool[] {false} ;
         T000H2_A300VacantesUsuariosRefLab = new short[1] ;
         T000H2_n300VacantesUsuariosRefLab = new bool[] {false} ;
         T000H2_A301VacantesUsuariosExPsi = new short[1] ;
         T000H2_n301VacantesUsuariosExPsi = new bool[] {false} ;
         T000H2_A302VacantesUsuariosBusWeb = new short[1] ;
         T000H2_n302VacantesUsuariosBusWeb = new bool[] {false} ;
         T000H2_A303VacantesUsuariosAvPriv = new short[1] ;
         T000H2_n303VacantesUsuariosAvPriv = new bool[] {false} ;
         T000H2_A304VacantesUsuariosAvConf = new short[1] ;
         T000H2_n304VacantesUsuariosAvConf = new bool[] {false} ;
         T000H2_A296VacantesUsuariosDocP = new String[] {""} ;
         T000H2_n296VacantesUsuariosDocP = new bool[] {false} ;
         T000H2_A297VacantesUsuariosDocCV = new String[] {""} ;
         T000H2_n297VacantesUsuariosDocCV = new bool[] {false} ;
         T000H2_A298VacantesUsuariosDocTec = new String[] {""} ;
         T000H2_n298VacantesUsuariosDocTec = new bool[] {false} ;
         T000H2_A295VacantesUsuariosFechaE = new DateTime[] {DateTime.MinValue} ;
         T000H2_n295VacantesUsuariosFechaE = new bool[] {false} ;
         T000H2_A305VacantesUsuariosDocCVRec = new String[] {""} ;
         T000H2_n305VacantesUsuariosDocCVRec = new bool[] {false} ;
         T000H2_A306VacantesUsuariosDocRefLab = new String[] {""} ;
         T000H2_n306VacantesUsuariosDocRefLab = new bool[] {false} ;
         T000H2_A307VacantesUsuariosDocExPsi = new String[] {""} ;
         T000H2_n307VacantesUsuariosDocExPsi = new bool[] {false} ;
         T000H2_A308VacantesUsuariosDocBusWeb = new String[] {""} ;
         T000H2_n308VacantesUsuariosDocBusWeb = new bool[] {false} ;
         T000H2_A309VacantesUsuariosDocAvPriv = new String[] {""} ;
         T000H2_n309VacantesUsuariosDocAvPriv = new bool[] {false} ;
         T000H2_A310VacantesUsuariosDocAvConf = new String[] {""} ;
         T000H2_n310VacantesUsuariosDocAvConf = new bool[] {false} ;
         T000H2_A311VacantesUsuariosFechaEnvOp = new DateTime[] {DateTime.MinValue} ;
         T000H2_n311VacantesUsuariosFechaEnvOp = new bool[] {false} ;
         T000H2_A312VacantesUsuariosFechaEnvCli = new DateTime[] {DateTime.MinValue} ;
         T000H2_n312VacantesUsuariosFechaEnvCli = new bool[] {false} ;
         T000H2_A11UsuariosId = new int[1] ;
         T000H2_A284SUBT_ReclutadorId = new int[1] ;
         T000H23_A66UsuariosNombre = new String[] {""} ;
         T000H23_A65UsuariosApPat = new String[] {""} ;
         T000H23_A64UsuariosApMat = new String[] {""} ;
         T000H24_A263Vacantes_Id = new int[1] ;
         T000H24_A11UsuariosId = new int[1] ;
         Gridvacantes_usuariosvacanteRow = new GXWebRow();
         subGridvacantes_usuariosvacante_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         Z287SUBT_ReclutadorNombre = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.vacantes__default(),
            new Object[][] {
                new Object[] {
               T000H2_A263Vacantes_Id, T000H2_A273UsuariosVacanteEstatus, T000H2_A288VacantesUsuariosFechaP, T000H2_A289VacantesUsuariosFechaD, T000H2_n289VacantesUsuariosFechaD, T000H2_A313VacantesUsuariosFechaA, T000H2_n313VacantesUsuariosFechaA, T000H2_A314VacantesUsuariosFecha3, T000H2_n314VacantesUsuariosFecha3, T000H2_A294VacantesUsuariosMotD,
               T000H2_n294VacantesUsuariosMotD, T000H2_A290VacantesUsuariosEstatus, T000H2_n290VacantesUsuariosEstatus, T000H2_A291VacantesUsuariosPrefiltro, T000H2_n291VacantesUsuariosPrefiltro, T000H2_A292VacantesUsuariosCV, T000H2_n292VacantesUsuariosCV, T000H2_A293VacantesUsuariosExTec, T000H2_n293VacantesUsuariosExTec, T000H2_A299VacantesUsuariosCVRec,
               T000H2_n299VacantesUsuariosCVRec, T000H2_A300VacantesUsuariosRefLab, T000H2_n300VacantesUsuariosRefLab, T000H2_A301VacantesUsuariosExPsi, T000H2_n301VacantesUsuariosExPsi, T000H2_A302VacantesUsuariosBusWeb, T000H2_n302VacantesUsuariosBusWeb, T000H2_A303VacantesUsuariosAvPriv, T000H2_n303VacantesUsuariosAvPriv, T000H2_A304VacantesUsuariosAvConf,
               T000H2_n304VacantesUsuariosAvConf, T000H2_A296VacantesUsuariosDocP, T000H2_n296VacantesUsuariosDocP, T000H2_A297VacantesUsuariosDocCV, T000H2_n297VacantesUsuariosDocCV, T000H2_A298VacantesUsuariosDocTec, T000H2_n298VacantesUsuariosDocTec, T000H2_A295VacantesUsuariosFechaE, T000H2_n295VacantesUsuariosFechaE, T000H2_A305VacantesUsuariosDocCVRec,
               T000H2_n305VacantesUsuariosDocCVRec, T000H2_A306VacantesUsuariosDocRefLab, T000H2_n306VacantesUsuariosDocRefLab, T000H2_A307VacantesUsuariosDocExPsi, T000H2_n307VacantesUsuariosDocExPsi, T000H2_A308VacantesUsuariosDocBusWeb, T000H2_n308VacantesUsuariosDocBusWeb, T000H2_A309VacantesUsuariosDocAvPriv, T000H2_n309VacantesUsuariosDocAvPriv, T000H2_A310VacantesUsuariosDocAvConf,
               T000H2_n310VacantesUsuariosDocAvConf, T000H2_A311VacantesUsuariosFechaEnvOp, T000H2_n311VacantesUsuariosFechaEnvOp, T000H2_A312VacantesUsuariosFechaEnvCli, T000H2_n312VacantesUsuariosFechaEnvCli, T000H2_A11UsuariosId, T000H2_A284SUBT_ReclutadorId
               }
               , new Object[] {
               T000H3_A263Vacantes_Id, T000H3_A273UsuariosVacanteEstatus, T000H3_A288VacantesUsuariosFechaP, T000H3_A289VacantesUsuariosFechaD, T000H3_n289VacantesUsuariosFechaD, T000H3_A313VacantesUsuariosFechaA, T000H3_n313VacantesUsuariosFechaA, T000H3_A314VacantesUsuariosFecha3, T000H3_n314VacantesUsuariosFecha3, T000H3_A294VacantesUsuariosMotD,
               T000H3_n294VacantesUsuariosMotD, T000H3_A290VacantesUsuariosEstatus, T000H3_n290VacantesUsuariosEstatus, T000H3_A291VacantesUsuariosPrefiltro, T000H3_n291VacantesUsuariosPrefiltro, T000H3_A292VacantesUsuariosCV, T000H3_n292VacantesUsuariosCV, T000H3_A293VacantesUsuariosExTec, T000H3_n293VacantesUsuariosExTec, T000H3_A299VacantesUsuariosCVRec,
               T000H3_n299VacantesUsuariosCVRec, T000H3_A300VacantesUsuariosRefLab, T000H3_n300VacantesUsuariosRefLab, T000H3_A301VacantesUsuariosExPsi, T000H3_n301VacantesUsuariosExPsi, T000H3_A302VacantesUsuariosBusWeb, T000H3_n302VacantesUsuariosBusWeb, T000H3_A303VacantesUsuariosAvPriv, T000H3_n303VacantesUsuariosAvPriv, T000H3_A304VacantesUsuariosAvConf,
               T000H3_n304VacantesUsuariosAvConf, T000H3_A296VacantesUsuariosDocP, T000H3_n296VacantesUsuariosDocP, T000H3_A297VacantesUsuariosDocCV, T000H3_n297VacantesUsuariosDocCV, T000H3_A298VacantesUsuariosDocTec, T000H3_n298VacantesUsuariosDocTec, T000H3_A295VacantesUsuariosFechaE, T000H3_n295VacantesUsuariosFechaE, T000H3_A305VacantesUsuariosDocCVRec,
               T000H3_n305VacantesUsuariosDocCVRec, T000H3_A306VacantesUsuariosDocRefLab, T000H3_n306VacantesUsuariosDocRefLab, T000H3_A307VacantesUsuariosDocExPsi, T000H3_n307VacantesUsuariosDocExPsi, T000H3_A308VacantesUsuariosDocBusWeb, T000H3_n308VacantesUsuariosDocBusWeb, T000H3_A309VacantesUsuariosDocAvPriv, T000H3_n309VacantesUsuariosDocAvPriv, T000H3_A310VacantesUsuariosDocAvConf,
               T000H3_n310VacantesUsuariosDocAvConf, T000H3_A311VacantesUsuariosFechaEnvOp, T000H3_n311VacantesUsuariosFechaEnvOp, T000H3_A312VacantesUsuariosFechaEnvCli, T000H3_n312VacantesUsuariosFechaEnvCli, T000H3_A11UsuariosId, T000H3_A284SUBT_ReclutadorId
               }
               , new Object[] {
               T000H4_A66UsuariosNombre, T000H4_A65UsuariosApPat, T000H4_A64UsuariosApMat
               }
               , new Object[] {
               T000H5_A284SUBT_ReclutadorId
               }
               , new Object[] {
               T000H6_A263Vacantes_Id, T000H6_A264Vacantes_Nombre, T000H6_A274Vacantes_Descripcion, T000H6_A265Vacantes_Status, T000H6_A266Vacantes_FechaInicio, T000H6_A267Vacantes_Sueldo, T000H6_A268Vacantes_Tipo, T000H6_A269Vacantes_Duracion, T000H6_A270Vacantes_Duracion_Nom, T000H6_A277Vacantes_Plazas
               }
               , new Object[] {
               T000H7_A263Vacantes_Id, T000H7_A264Vacantes_Nombre, T000H7_A274Vacantes_Descripcion, T000H7_A265Vacantes_Status, T000H7_A266Vacantes_FechaInicio, T000H7_A267Vacantes_Sueldo, T000H7_A268Vacantes_Tipo, T000H7_A269Vacantes_Duracion, T000H7_A270Vacantes_Duracion_Nom, T000H7_A277Vacantes_Plazas
               }
               , new Object[] {
               T000H8_A263Vacantes_Id, T000H8_A264Vacantes_Nombre, T000H8_A274Vacantes_Descripcion, T000H8_A265Vacantes_Status, T000H8_A266Vacantes_FechaInicio, T000H8_A267Vacantes_Sueldo, T000H8_A268Vacantes_Tipo, T000H8_A269Vacantes_Duracion, T000H8_A270Vacantes_Duracion_Nom, T000H8_A277Vacantes_Plazas
               }
               , new Object[] {
               T000H9_A263Vacantes_Id
               }
               , new Object[] {
               T000H10_A263Vacantes_Id
               }
               , new Object[] {
               T000H11_A263Vacantes_Id
               }
               , new Object[] {
               }
               , new Object[] {
               T000H13_A263Vacantes_Id
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000H16_A263Vacantes_Id
               }
               , new Object[] {
               T000H17_A263Vacantes_Id, T000H17_A66UsuariosNombre, T000H17_A65UsuariosApPat, T000H17_A64UsuariosApMat, T000H17_A273UsuariosVacanteEstatus, T000H17_A288VacantesUsuariosFechaP, T000H17_A289VacantesUsuariosFechaD, T000H17_n289VacantesUsuariosFechaD, T000H17_A313VacantesUsuariosFechaA, T000H17_n313VacantesUsuariosFechaA,
               T000H17_A314VacantesUsuariosFecha3, T000H17_n314VacantesUsuariosFecha3, T000H17_A294VacantesUsuariosMotD, T000H17_n294VacantesUsuariosMotD, T000H17_A290VacantesUsuariosEstatus, T000H17_n290VacantesUsuariosEstatus, T000H17_A291VacantesUsuariosPrefiltro, T000H17_n291VacantesUsuariosPrefiltro, T000H17_A292VacantesUsuariosCV, T000H17_n292VacantesUsuariosCV,
               T000H17_A293VacantesUsuariosExTec, T000H17_n293VacantesUsuariosExTec, T000H17_A299VacantesUsuariosCVRec, T000H17_n299VacantesUsuariosCVRec, T000H17_A300VacantesUsuariosRefLab, T000H17_n300VacantesUsuariosRefLab, T000H17_A301VacantesUsuariosExPsi, T000H17_n301VacantesUsuariosExPsi, T000H17_A302VacantesUsuariosBusWeb, T000H17_n302VacantesUsuariosBusWeb,
               T000H17_A303VacantesUsuariosAvPriv, T000H17_n303VacantesUsuariosAvPriv, T000H17_A304VacantesUsuariosAvConf, T000H17_n304VacantesUsuariosAvConf, T000H17_A296VacantesUsuariosDocP, T000H17_n296VacantesUsuariosDocP, T000H17_A297VacantesUsuariosDocCV, T000H17_n297VacantesUsuariosDocCV, T000H17_A298VacantesUsuariosDocTec, T000H17_n298VacantesUsuariosDocTec,
               T000H17_A295VacantesUsuariosFechaE, T000H17_n295VacantesUsuariosFechaE, T000H17_A305VacantesUsuariosDocCVRec, T000H17_n305VacantesUsuariosDocCVRec, T000H17_A306VacantesUsuariosDocRefLab, T000H17_n306VacantesUsuariosDocRefLab, T000H17_A307VacantesUsuariosDocExPsi, T000H17_n307VacantesUsuariosDocExPsi, T000H17_A308VacantesUsuariosDocBusWeb, T000H17_n308VacantesUsuariosDocBusWeb,
               T000H17_A309VacantesUsuariosDocAvPriv, T000H17_n309VacantesUsuariosDocAvPriv, T000H17_A310VacantesUsuariosDocAvConf, T000H17_n310VacantesUsuariosDocAvConf, T000H17_A311VacantesUsuariosFechaEnvOp, T000H17_n311VacantesUsuariosFechaEnvOp, T000H17_A312VacantesUsuariosFechaEnvCli, T000H17_n312VacantesUsuariosFechaEnvCli, T000H17_A11UsuariosId, T000H17_A284SUBT_ReclutadorId
               }
               , new Object[] {
               T000H18_A66UsuariosNombre, T000H18_A65UsuariosApPat, T000H18_A64UsuariosApMat
               }
               , new Object[] {
               T000H19_A263Vacantes_Id, T000H19_A11UsuariosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000H23_A66UsuariosNombre, T000H23_A65UsuariosApPat, T000H23_A64UsuariosApMat
               }
               , new Object[] {
               T000H24_A263Vacantes_Id, T000H24_A11UsuariosId
               }
            }
         );
         AV12Pgmname = "Vacantes";
      }

      private short Z265Vacantes_Status ;
      private short Z268Vacantes_Tipo ;
      private short Z269Vacantes_Duracion ;
      private short Z270Vacantes_Duracion_Nom ;
      private short Z277Vacantes_Plazas ;
      private short Z273UsuariosVacanteEstatus ;
      private short Z290VacantesUsuariosEstatus ;
      private short Z291VacantesUsuariosPrefiltro ;
      private short Z292VacantesUsuariosCV ;
      private short Z293VacantesUsuariosExTec ;
      private short Z299VacantesUsuariosCVRec ;
      private short Z300VacantesUsuariosRefLab ;
      private short Z301VacantesUsuariosExPsi ;
      private short Z302VacantesUsuariosBusWeb ;
      private short Z303VacantesUsuariosAvPriv ;
      private short Z304VacantesUsuariosAvConf ;
      private short nRcdDeleted_28 ;
      private short nRcdExists_28 ;
      private short nIsMod_28 ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A265Vacantes_Status ;
      private short A268Vacantes_Tipo ;
      private short A270Vacantes_Duracion_Nom ;
      private short A269Vacantes_Duracion ;
      private short A277Vacantes_Plazas ;
      private short subGridvacantes_usuariosvacante_Backcolorstyle ;
      private short A273UsuariosVacanteEstatus ;
      private short subGridvacantes_usuariosvacante_Allowselection ;
      private short subGridvacantes_usuariosvacante_Allowhovering ;
      private short subGridvacantes_usuariosvacante_Allowcollapsing ;
      private short subGridvacantes_usuariosvacante_Collapsed ;
      private short nBlankRcdCount28 ;
      private short RcdFound28 ;
      private short nBlankRcdUsr28 ;
      private short A290VacantesUsuariosEstatus ;
      private short A291VacantesUsuariosPrefiltro ;
      private short A292VacantesUsuariosCV ;
      private short A293VacantesUsuariosExTec ;
      private short A299VacantesUsuariosCVRec ;
      private short A300VacantesUsuariosRefLab ;
      private short A301VacantesUsuariosExPsi ;
      private short A302VacantesUsuariosBusWeb ;
      private short A303VacantesUsuariosAvPriv ;
      private short A304VacantesUsuariosAvConf ;
      private short RcdFound21 ;
      private short GX_JID ;
      private short nIsDirty_21 ;
      private short Gx_BScreen ;
      private short nIsDirty_28 ;
      private short subGridvacantes_usuariosvacante_Backstyle ;
      private short gxajaxcallmode ;
      private int wcpOAV7Vacantes_Id ;
      private int Z263Vacantes_Id ;
      private int nRC_GXsfl_90 ;
      private int nGXsfl_90_idx=1 ;
      private int Z11UsuariosId ;
      private int Z284SUBT_ReclutadorId ;
      private int A11UsuariosId ;
      private int AV7Vacantes_Id ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A263Vacantes_Id ;
      private int edtVacantes_Id_Enabled ;
      private int edtVacantes_Nombre_Enabled ;
      private int edtVacantes_Descripcion_Enabled ;
      private int edtVacantes_FechaInicio_Enabled ;
      private int edtVacantes_Sueldo_Enabled ;
      private int edtVacantes_Duracion_Enabled ;
      private int edtVacantes_Plazas_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtUsuariosId_Enabled ;
      private int edtUsuariosNombre_Enabled ;
      private int edtUsuariosApPat_Enabled ;
      private int edtUsuariosApMat_Enabled ;
      private int subGridvacantes_usuariosvacante_Selectedindex ;
      private int subGridvacantes_usuariosvacante_Selectioncolor ;
      private int subGridvacantes_usuariosvacante_Hoveringcolor ;
      private int fRowAdded ;
      private int A284SUBT_ReclutadorId ;
      private int subGridvacantes_usuariosvacante_Backcolor ;
      private int subGridvacantes_usuariosvacante_Allbackcolor ;
      private int defedtUsuariosId_Enabled ;
      private int idxLst ;
      private long GRIDVACANTES_USUARIOSVACANTE_nFirstRecordOnPage ;
      private decimal Z267Vacantes_Sueldo ;
      private decimal A267Vacantes_Sueldo ;
      private String sPrefix ;
      private String wcpOGx_mode ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_90_idx="0001" ;
      private String Gx_mode ;
      private String GXKey ;
      private String GXDecQS ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String GX_FocusControl ;
      private String edtVacantes_Nombre_Internalname ;
      private String cmbVacantes_Status_Internalname ;
      private String cmbVacantes_Tipo_Internalname ;
      private String cmbVacantes_Duracion_Nom_Internalname ;
      private String divMaintable_Internalname ;
      private String divTitlecontainer_Internalname ;
      private String lblTitle_Internalname ;
      private String lblTitle_Jsonclick ;
      private String lblViellall_Internalname ;
      private String lblViellall_Jsonclick ;
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
      private String edtVacantes_Id_Internalname ;
      private String edtVacantes_Id_Jsonclick ;
      private String edtVacantes_Nombre_Jsonclick ;
      private String edtVacantes_Descripcion_Internalname ;
      private String cmbVacantes_Status_Jsonclick ;
      private String edtVacantes_FechaInicio_Internalname ;
      private String edtVacantes_FechaInicio_Jsonclick ;
      private String edtVacantes_Sueldo_Internalname ;
      private String edtVacantes_Sueldo_Jsonclick ;
      private String cmbVacantes_Tipo_Jsonclick ;
      private String edtVacantes_Duracion_Internalname ;
      private String edtVacantes_Duracion_Jsonclick ;
      private String cmbVacantes_Duracion_Nom_Jsonclick ;
      private String edtVacantes_Plazas_Internalname ;
      private String edtVacantes_Plazas_Jsonclick ;
      private String divUsuariosvacantetable_Internalname ;
      private String lblTitleusuariosvacante_Internalname ;
      private String lblTitleusuariosvacante_Jsonclick ;
      private String bttBtn_enter_Internalname ;
      private String bttBtn_enter_Jsonclick ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String bttBtn_delete_Internalname ;
      private String bttBtn_delete_Jsonclick ;
      private String subGridvacantes_usuariosvacante_Header ;
      private String sMode28 ;
      private String edtUsuariosId_Internalname ;
      private String edtUsuariosNombre_Internalname ;
      private String edtUsuariosApPat_Internalname ;
      private String edtUsuariosApMat_Internalname ;
      private String cmbUsuariosVacanteEstatus_Internalname ;
      private String sStyleString ;
      private String AV12Pgmname ;
      private String hsh ;
      private String sMode21 ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String endTrnMsgTxt ;
      private String endTrnMsgCod ;
      private String GXCCtl ;
      private String sGXsfl_90_fel_idx="0001" ;
      private String subGridvacantes_usuariosvacante_Class ;
      private String subGridvacantes_usuariosvacante_Linesclass ;
      private String ROClassString ;
      private String edtUsuariosId_Jsonclick ;
      private String edtUsuariosNombre_Jsonclick ;
      private String edtUsuariosApPat_Jsonclick ;
      private String edtUsuariosApMat_Jsonclick ;
      private String cmbUsuariosVacanteEstatus_Jsonclick ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXEncryptionTmp ;
      private String subGridvacantes_usuariosvacante_Internalname ;
      private DateTime Z288VacantesUsuariosFechaP ;
      private DateTime Z289VacantesUsuariosFechaD ;
      private DateTime Z313VacantesUsuariosFechaA ;
      private DateTime Z314VacantesUsuariosFecha3 ;
      private DateTime Z295VacantesUsuariosFechaE ;
      private DateTime Z311VacantesUsuariosFechaEnvOp ;
      private DateTime Z312VacantesUsuariosFechaEnvCli ;
      private DateTime A288VacantesUsuariosFechaP ;
      private DateTime A289VacantesUsuariosFechaD ;
      private DateTime A313VacantesUsuariosFechaA ;
      private DateTime A314VacantesUsuariosFecha3 ;
      private DateTime A295VacantesUsuariosFechaE ;
      private DateTime A311VacantesUsuariosFechaEnvOp ;
      private DateTime A312VacantesUsuariosFechaEnvCli ;
      private DateTime Z266Vacantes_FechaInicio ;
      private DateTime A266Vacantes_FechaInicio ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_90_Refreshing=false ;
      private bool n289VacantesUsuariosFechaD ;
      private bool n313VacantesUsuariosFechaA ;
      private bool n314VacantesUsuariosFecha3 ;
      private bool n294VacantesUsuariosMotD ;
      private bool n290VacantesUsuariosEstatus ;
      private bool n291VacantesUsuariosPrefiltro ;
      private bool n292VacantesUsuariosCV ;
      private bool n293VacantesUsuariosExTec ;
      private bool n299VacantesUsuariosCVRec ;
      private bool n300VacantesUsuariosRefLab ;
      private bool n301VacantesUsuariosExPsi ;
      private bool n302VacantesUsuariosBusWeb ;
      private bool n303VacantesUsuariosAvPriv ;
      private bool n304VacantesUsuariosAvConf ;
      private bool n296VacantesUsuariosDocP ;
      private bool n297VacantesUsuariosDocCV ;
      private bool n298VacantesUsuariosDocTec ;
      private bool n295VacantesUsuariosFechaE ;
      private bool n305VacantesUsuariosDocCVRec ;
      private bool n306VacantesUsuariosDocRefLab ;
      private bool n307VacantesUsuariosDocExPsi ;
      private bool n308VacantesUsuariosDocBusWeb ;
      private bool n309VacantesUsuariosDocAvPriv ;
      private bool n310VacantesUsuariosDocAvConf ;
      private bool n311VacantesUsuariosFechaEnvOp ;
      private bool n312VacantesUsuariosFechaEnvCli ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private String Z264Vacantes_Nombre ;
      private String Z274Vacantes_Descripcion ;
      private String Z294VacantesUsuariosMotD ;
      private String Z296VacantesUsuariosDocP ;
      private String Z297VacantesUsuariosDocCV ;
      private String Z298VacantesUsuariosDocTec ;
      private String Z305VacantesUsuariosDocCVRec ;
      private String Z306VacantesUsuariosDocRefLab ;
      private String Z307VacantesUsuariosDocExPsi ;
      private String Z308VacantesUsuariosDocBusWeb ;
      private String Z309VacantesUsuariosDocAvPriv ;
      private String Z310VacantesUsuariosDocAvConf ;
      private String A264Vacantes_Nombre ;
      private String A274Vacantes_Descripcion ;
      private String A66UsuariosNombre ;
      private String A65UsuariosApPat ;
      private String A64UsuariosApMat ;
      private String A287SUBT_ReclutadorNombre ;
      private String A294VacantesUsuariosMotD ;
      private String A296VacantesUsuariosDocP ;
      private String A297VacantesUsuariosDocCV ;
      private String A298VacantesUsuariosDocTec ;
      private String A305VacantesUsuariosDocCVRec ;
      private String A306VacantesUsuariosDocRefLab ;
      private String A307VacantesUsuariosDocExPsi ;
      private String A308VacantesUsuariosDocBusWeb ;
      private String A309VacantesUsuariosDocAvPriv ;
      private String A310VacantesUsuariosDocAvConf ;
      private String Z66UsuariosNombre ;
      private String Z65UsuariosApPat ;
      private String Z64UsuariosApMat ;
      private String Z287SUBT_ReclutadorNombre ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridvacantes_usuariosvacanteContainer ;
      private GXWebRow Gridvacantes_usuariosvacanteRow ;
      private GXWebColumn Gridvacantes_usuariosvacanteColumn ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbVacantes_Status ;
      private GXCombobox cmbVacantes_Tipo ;
      private GXCombobox cmbVacantes_Duracion_Nom ;
      private GXCombobox cmbUsuariosVacanteEstatus ;
      private IDataStoreProvider pr_default ;
      private int[] T000H8_A263Vacantes_Id ;
      private String[] T000H8_A264Vacantes_Nombre ;
      private String[] T000H8_A274Vacantes_Descripcion ;
      private short[] T000H8_A265Vacantes_Status ;
      private DateTime[] T000H8_A266Vacantes_FechaInicio ;
      private decimal[] T000H8_A267Vacantes_Sueldo ;
      private short[] T000H8_A268Vacantes_Tipo ;
      private short[] T000H8_A269Vacantes_Duracion ;
      private short[] T000H8_A270Vacantes_Duracion_Nom ;
      private short[] T000H8_A277Vacantes_Plazas ;
      private int[] T000H9_A263Vacantes_Id ;
      private int[] T000H7_A263Vacantes_Id ;
      private String[] T000H7_A264Vacantes_Nombre ;
      private String[] T000H7_A274Vacantes_Descripcion ;
      private short[] T000H7_A265Vacantes_Status ;
      private DateTime[] T000H7_A266Vacantes_FechaInicio ;
      private decimal[] T000H7_A267Vacantes_Sueldo ;
      private short[] T000H7_A268Vacantes_Tipo ;
      private short[] T000H7_A269Vacantes_Duracion ;
      private short[] T000H7_A270Vacantes_Duracion_Nom ;
      private short[] T000H7_A277Vacantes_Plazas ;
      private int[] T000H10_A263Vacantes_Id ;
      private int[] T000H11_A263Vacantes_Id ;
      private int[] T000H6_A263Vacantes_Id ;
      private String[] T000H6_A264Vacantes_Nombre ;
      private String[] T000H6_A274Vacantes_Descripcion ;
      private short[] T000H6_A265Vacantes_Status ;
      private DateTime[] T000H6_A266Vacantes_FechaInicio ;
      private decimal[] T000H6_A267Vacantes_Sueldo ;
      private short[] T000H6_A268Vacantes_Tipo ;
      private short[] T000H6_A269Vacantes_Duracion ;
      private short[] T000H6_A270Vacantes_Duracion_Nom ;
      private short[] T000H6_A277Vacantes_Plazas ;
      private int[] T000H13_A263Vacantes_Id ;
      private int[] T000H16_A263Vacantes_Id ;
      private int[] T000H5_A284SUBT_ReclutadorId ;
      private int[] T000H17_A263Vacantes_Id ;
      private String[] T000H17_A66UsuariosNombre ;
      private String[] T000H17_A65UsuariosApPat ;
      private String[] T000H17_A64UsuariosApMat ;
      private short[] T000H17_A273UsuariosVacanteEstatus ;
      private DateTime[] T000H17_A288VacantesUsuariosFechaP ;
      private DateTime[] T000H17_A289VacantesUsuariosFechaD ;
      private bool[] T000H17_n289VacantesUsuariosFechaD ;
      private DateTime[] T000H17_A313VacantesUsuariosFechaA ;
      private bool[] T000H17_n313VacantesUsuariosFechaA ;
      private DateTime[] T000H17_A314VacantesUsuariosFecha3 ;
      private bool[] T000H17_n314VacantesUsuariosFecha3 ;
      private String[] T000H17_A294VacantesUsuariosMotD ;
      private bool[] T000H17_n294VacantesUsuariosMotD ;
      private short[] T000H17_A290VacantesUsuariosEstatus ;
      private bool[] T000H17_n290VacantesUsuariosEstatus ;
      private short[] T000H17_A291VacantesUsuariosPrefiltro ;
      private bool[] T000H17_n291VacantesUsuariosPrefiltro ;
      private short[] T000H17_A292VacantesUsuariosCV ;
      private bool[] T000H17_n292VacantesUsuariosCV ;
      private short[] T000H17_A293VacantesUsuariosExTec ;
      private bool[] T000H17_n293VacantesUsuariosExTec ;
      private short[] T000H17_A299VacantesUsuariosCVRec ;
      private bool[] T000H17_n299VacantesUsuariosCVRec ;
      private short[] T000H17_A300VacantesUsuariosRefLab ;
      private bool[] T000H17_n300VacantesUsuariosRefLab ;
      private short[] T000H17_A301VacantesUsuariosExPsi ;
      private bool[] T000H17_n301VacantesUsuariosExPsi ;
      private short[] T000H17_A302VacantesUsuariosBusWeb ;
      private bool[] T000H17_n302VacantesUsuariosBusWeb ;
      private short[] T000H17_A303VacantesUsuariosAvPriv ;
      private bool[] T000H17_n303VacantesUsuariosAvPriv ;
      private short[] T000H17_A304VacantesUsuariosAvConf ;
      private bool[] T000H17_n304VacantesUsuariosAvConf ;
      private String[] T000H17_A296VacantesUsuariosDocP ;
      private bool[] T000H17_n296VacantesUsuariosDocP ;
      private String[] T000H17_A297VacantesUsuariosDocCV ;
      private bool[] T000H17_n297VacantesUsuariosDocCV ;
      private String[] T000H17_A298VacantesUsuariosDocTec ;
      private bool[] T000H17_n298VacantesUsuariosDocTec ;
      private DateTime[] T000H17_A295VacantesUsuariosFechaE ;
      private bool[] T000H17_n295VacantesUsuariosFechaE ;
      private String[] T000H17_A305VacantesUsuariosDocCVRec ;
      private bool[] T000H17_n305VacantesUsuariosDocCVRec ;
      private String[] T000H17_A306VacantesUsuariosDocRefLab ;
      private bool[] T000H17_n306VacantesUsuariosDocRefLab ;
      private String[] T000H17_A307VacantesUsuariosDocExPsi ;
      private bool[] T000H17_n307VacantesUsuariosDocExPsi ;
      private String[] T000H17_A308VacantesUsuariosDocBusWeb ;
      private bool[] T000H17_n308VacantesUsuariosDocBusWeb ;
      private String[] T000H17_A309VacantesUsuariosDocAvPriv ;
      private bool[] T000H17_n309VacantesUsuariosDocAvPriv ;
      private String[] T000H17_A310VacantesUsuariosDocAvConf ;
      private bool[] T000H17_n310VacantesUsuariosDocAvConf ;
      private DateTime[] T000H17_A311VacantesUsuariosFechaEnvOp ;
      private bool[] T000H17_n311VacantesUsuariosFechaEnvOp ;
      private DateTime[] T000H17_A312VacantesUsuariosFechaEnvCli ;
      private bool[] T000H17_n312VacantesUsuariosFechaEnvCli ;
      private int[] T000H17_A11UsuariosId ;
      private int[] T000H17_A284SUBT_ReclutadorId ;
      private String[] T000H4_A66UsuariosNombre ;
      private String[] T000H4_A65UsuariosApPat ;
      private String[] T000H4_A64UsuariosApMat ;
      private String[] T000H18_A66UsuariosNombre ;
      private String[] T000H18_A65UsuariosApPat ;
      private String[] T000H18_A64UsuariosApMat ;
      private int[] T000H19_A263Vacantes_Id ;
      private int[] T000H19_A11UsuariosId ;
      private int[] T000H3_A263Vacantes_Id ;
      private short[] T000H3_A273UsuariosVacanteEstatus ;
      private DateTime[] T000H3_A288VacantesUsuariosFechaP ;
      private DateTime[] T000H3_A289VacantesUsuariosFechaD ;
      private bool[] T000H3_n289VacantesUsuariosFechaD ;
      private DateTime[] T000H3_A313VacantesUsuariosFechaA ;
      private bool[] T000H3_n313VacantesUsuariosFechaA ;
      private DateTime[] T000H3_A314VacantesUsuariosFecha3 ;
      private bool[] T000H3_n314VacantesUsuariosFecha3 ;
      private String[] T000H3_A294VacantesUsuariosMotD ;
      private bool[] T000H3_n294VacantesUsuariosMotD ;
      private short[] T000H3_A290VacantesUsuariosEstatus ;
      private bool[] T000H3_n290VacantesUsuariosEstatus ;
      private short[] T000H3_A291VacantesUsuariosPrefiltro ;
      private bool[] T000H3_n291VacantesUsuariosPrefiltro ;
      private short[] T000H3_A292VacantesUsuariosCV ;
      private bool[] T000H3_n292VacantesUsuariosCV ;
      private short[] T000H3_A293VacantesUsuariosExTec ;
      private bool[] T000H3_n293VacantesUsuariosExTec ;
      private short[] T000H3_A299VacantesUsuariosCVRec ;
      private bool[] T000H3_n299VacantesUsuariosCVRec ;
      private short[] T000H3_A300VacantesUsuariosRefLab ;
      private bool[] T000H3_n300VacantesUsuariosRefLab ;
      private short[] T000H3_A301VacantesUsuariosExPsi ;
      private bool[] T000H3_n301VacantesUsuariosExPsi ;
      private short[] T000H3_A302VacantesUsuariosBusWeb ;
      private bool[] T000H3_n302VacantesUsuariosBusWeb ;
      private short[] T000H3_A303VacantesUsuariosAvPriv ;
      private bool[] T000H3_n303VacantesUsuariosAvPriv ;
      private short[] T000H3_A304VacantesUsuariosAvConf ;
      private bool[] T000H3_n304VacantesUsuariosAvConf ;
      private String[] T000H3_A296VacantesUsuariosDocP ;
      private bool[] T000H3_n296VacantesUsuariosDocP ;
      private String[] T000H3_A297VacantesUsuariosDocCV ;
      private bool[] T000H3_n297VacantesUsuariosDocCV ;
      private String[] T000H3_A298VacantesUsuariosDocTec ;
      private bool[] T000H3_n298VacantesUsuariosDocTec ;
      private DateTime[] T000H3_A295VacantesUsuariosFechaE ;
      private bool[] T000H3_n295VacantesUsuariosFechaE ;
      private String[] T000H3_A305VacantesUsuariosDocCVRec ;
      private bool[] T000H3_n305VacantesUsuariosDocCVRec ;
      private String[] T000H3_A306VacantesUsuariosDocRefLab ;
      private bool[] T000H3_n306VacantesUsuariosDocRefLab ;
      private String[] T000H3_A307VacantesUsuariosDocExPsi ;
      private bool[] T000H3_n307VacantesUsuariosDocExPsi ;
      private String[] T000H3_A308VacantesUsuariosDocBusWeb ;
      private bool[] T000H3_n308VacantesUsuariosDocBusWeb ;
      private String[] T000H3_A309VacantesUsuariosDocAvPriv ;
      private bool[] T000H3_n309VacantesUsuariosDocAvPriv ;
      private String[] T000H3_A310VacantesUsuariosDocAvConf ;
      private bool[] T000H3_n310VacantesUsuariosDocAvConf ;
      private DateTime[] T000H3_A311VacantesUsuariosFechaEnvOp ;
      private bool[] T000H3_n311VacantesUsuariosFechaEnvOp ;
      private DateTime[] T000H3_A312VacantesUsuariosFechaEnvCli ;
      private bool[] T000H3_n312VacantesUsuariosFechaEnvCli ;
      private int[] T000H3_A11UsuariosId ;
      private int[] T000H3_A284SUBT_ReclutadorId ;
      private int[] T000H2_A263Vacantes_Id ;
      private short[] T000H2_A273UsuariosVacanteEstatus ;
      private DateTime[] T000H2_A288VacantesUsuariosFechaP ;
      private DateTime[] T000H2_A289VacantesUsuariosFechaD ;
      private bool[] T000H2_n289VacantesUsuariosFechaD ;
      private DateTime[] T000H2_A313VacantesUsuariosFechaA ;
      private bool[] T000H2_n313VacantesUsuariosFechaA ;
      private DateTime[] T000H2_A314VacantesUsuariosFecha3 ;
      private bool[] T000H2_n314VacantesUsuariosFecha3 ;
      private String[] T000H2_A294VacantesUsuariosMotD ;
      private bool[] T000H2_n294VacantesUsuariosMotD ;
      private short[] T000H2_A290VacantesUsuariosEstatus ;
      private bool[] T000H2_n290VacantesUsuariosEstatus ;
      private short[] T000H2_A291VacantesUsuariosPrefiltro ;
      private bool[] T000H2_n291VacantesUsuariosPrefiltro ;
      private short[] T000H2_A292VacantesUsuariosCV ;
      private bool[] T000H2_n292VacantesUsuariosCV ;
      private short[] T000H2_A293VacantesUsuariosExTec ;
      private bool[] T000H2_n293VacantesUsuariosExTec ;
      private short[] T000H2_A299VacantesUsuariosCVRec ;
      private bool[] T000H2_n299VacantesUsuariosCVRec ;
      private short[] T000H2_A300VacantesUsuariosRefLab ;
      private bool[] T000H2_n300VacantesUsuariosRefLab ;
      private short[] T000H2_A301VacantesUsuariosExPsi ;
      private bool[] T000H2_n301VacantesUsuariosExPsi ;
      private short[] T000H2_A302VacantesUsuariosBusWeb ;
      private bool[] T000H2_n302VacantesUsuariosBusWeb ;
      private short[] T000H2_A303VacantesUsuariosAvPriv ;
      private bool[] T000H2_n303VacantesUsuariosAvPriv ;
      private short[] T000H2_A304VacantesUsuariosAvConf ;
      private bool[] T000H2_n304VacantesUsuariosAvConf ;
      private String[] T000H2_A296VacantesUsuariosDocP ;
      private bool[] T000H2_n296VacantesUsuariosDocP ;
      private String[] T000H2_A297VacantesUsuariosDocCV ;
      private bool[] T000H2_n297VacantesUsuariosDocCV ;
      private String[] T000H2_A298VacantesUsuariosDocTec ;
      private bool[] T000H2_n298VacantesUsuariosDocTec ;
      private DateTime[] T000H2_A295VacantesUsuariosFechaE ;
      private bool[] T000H2_n295VacantesUsuariosFechaE ;
      private String[] T000H2_A305VacantesUsuariosDocCVRec ;
      private bool[] T000H2_n305VacantesUsuariosDocCVRec ;
      private String[] T000H2_A306VacantesUsuariosDocRefLab ;
      private bool[] T000H2_n306VacantesUsuariosDocRefLab ;
      private String[] T000H2_A307VacantesUsuariosDocExPsi ;
      private bool[] T000H2_n307VacantesUsuariosDocExPsi ;
      private String[] T000H2_A308VacantesUsuariosDocBusWeb ;
      private bool[] T000H2_n308VacantesUsuariosDocBusWeb ;
      private String[] T000H2_A309VacantesUsuariosDocAvPriv ;
      private bool[] T000H2_n309VacantesUsuariosDocAvPriv ;
      private String[] T000H2_A310VacantesUsuariosDocAvConf ;
      private bool[] T000H2_n310VacantesUsuariosDocAvConf ;
      private DateTime[] T000H2_A311VacantesUsuariosFechaEnvOp ;
      private bool[] T000H2_n311VacantesUsuariosFechaEnvOp ;
      private DateTime[] T000H2_A312VacantesUsuariosFechaEnvCli ;
      private bool[] T000H2_n312VacantesUsuariosFechaEnvCli ;
      private int[] T000H2_A11UsuariosId ;
      private int[] T000H2_A284SUBT_ReclutadorId ;
      private String[] T000H23_A66UsuariosNombre ;
      private String[] T000H23_A65UsuariosApPat ;
      private String[] T000H23_A64UsuariosApMat ;
      private int[] T000H24_A263Vacantes_Id ;
      private int[] T000H24_A11UsuariosId ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
   }

   public class vacantes__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new UpdateCursor(def[19])
         ,new UpdateCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000H8 ;
          prmT000H8 = new Object[] {
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000H9 ;
          prmT000H9 = new Object[] {
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000H7 ;
          prmT000H7 = new Object[] {
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000H10 ;
          prmT000H10 = new Object[] {
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000H11 ;
          prmT000H11 = new Object[] {
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000H6 ;
          prmT000H6 = new Object[] {
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000H12 ;
          prmT000H12 = new Object[] {
          new Object[] {"Vacantes_Nombre",System.Data.DbType.String,40,0} ,
          new Object[] {"Vacantes_Descripcion",System.Data.DbType.String,1000,0} ,
          new Object[] {"Vacantes_Status",System.Data.DbType.Int16,4,0} ,
          new Object[] {"Vacantes_FechaInicio",System.Data.DbType.Date,8,0} ,
          new Object[] {"Vacantes_Sueldo",System.Data.DbType.Single,6,3} ,
          new Object[] {"Vacantes_Tipo",System.Data.DbType.Int16,4,0} ,
          new Object[] {"Vacantes_Duracion",System.Data.DbType.Int16,4,0} ,
          new Object[] {"Vacantes_Duracion_Nom",System.Data.DbType.Int16,4,0} ,
          new Object[] {"Vacantes_Plazas",System.Data.DbType.Int16,4,0}
          } ;
          Object[] prmT000H13 ;
          prmT000H13 = new Object[] {
          } ;
          Object[] prmT000H14 ;
          prmT000H14 = new Object[] {
          new Object[] {"Vacantes_Nombre",System.Data.DbType.String,40,0} ,
          new Object[] {"Vacantes_Descripcion",System.Data.DbType.String,1000,0} ,
          new Object[] {"Vacantes_Status",System.Data.DbType.Int16,4,0} ,
          new Object[] {"Vacantes_FechaInicio",System.Data.DbType.Date,8,0} ,
          new Object[] {"Vacantes_Sueldo",System.Data.DbType.Single,6,3} ,
          new Object[] {"Vacantes_Tipo",System.Data.DbType.Int16,4,0} ,
          new Object[] {"Vacantes_Duracion",System.Data.DbType.Int16,4,0} ,
          new Object[] {"Vacantes_Duracion_Nom",System.Data.DbType.Int16,4,0} ,
          new Object[] {"Vacantes_Plazas",System.Data.DbType.Int16,4,0} ,
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000H15 ;
          prmT000H15 = new Object[] {
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000H16 ;
          prmT000H16 = new Object[] {
          } ;
          Object[] prmT000H5 ;
          prmT000H5 = new Object[] {
          new Object[] {"SUBT_ReclutadorId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000H17 ;
          prmT000H17 = new Object[] {
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000H4 ;
          prmT000H4 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000H18 ;
          prmT000H18 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000H19 ;
          prmT000H19 = new Object[] {
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000H3 ;
          prmT000H3 = new Object[] {
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000H2 ;
          prmT000H2 = new Object[] {
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000H20 ;
          prmT000H20 = new Object[] {
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"UsuariosVacanteEstatus",System.Data.DbType.Byte,1,0} ,
          new Object[] {"VacantesUsuariosFechaP",System.Data.DbType.DateTime,10,5} ,
          new Object[] {"VacantesUsuariosFechaD",System.Data.DbType.DateTime,8,5} ,
          new Object[] {"VacantesUsuariosFechaA",System.Data.DbType.DateTime,8,5} ,
          new Object[] {"VacantesUsuariosFecha3",System.Data.DbType.DateTime,8,5} ,
          new Object[] {"VacantesUsuariosMotD",System.Data.DbType.String,2048,0} ,
          new Object[] {"VacantesUsuariosEstatus",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosPrefiltro",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosCV",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosExTec",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosCVRec",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosRefLab",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosExPsi",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosBusWeb",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosAvPriv",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosAvConf",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosDocP",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosDocCV",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosDocTec",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosFechaE",System.Data.DbType.DateTime,8,5} ,
          new Object[] {"VacantesUsuariosDocCVRec",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosDocRefLab",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosDocExPsi",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosDocBusWeb",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosDocAvPriv",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosDocAvConf",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosFechaEnvOp",System.Data.DbType.DateTime,8,5} ,
          new Object[] {"VacantesUsuariosFechaEnvCli",System.Data.DbType.DateTime,8,5} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"SUBT_ReclutadorId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000H21 ;
          prmT000H21 = new Object[] {
          new Object[] {"UsuariosVacanteEstatus",System.Data.DbType.Byte,1,0} ,
          new Object[] {"VacantesUsuariosFechaP",System.Data.DbType.DateTime,10,5} ,
          new Object[] {"VacantesUsuariosFechaD",System.Data.DbType.DateTime,8,5} ,
          new Object[] {"VacantesUsuariosFechaA",System.Data.DbType.DateTime,8,5} ,
          new Object[] {"VacantesUsuariosFecha3",System.Data.DbType.DateTime,8,5} ,
          new Object[] {"VacantesUsuariosMotD",System.Data.DbType.String,2048,0} ,
          new Object[] {"VacantesUsuariosEstatus",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosPrefiltro",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosCV",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosExTec",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosCVRec",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosRefLab",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosExPsi",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosBusWeb",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosAvPriv",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosAvConf",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosDocP",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosDocCV",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosDocTec",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosFechaE",System.Data.DbType.DateTime,8,5} ,
          new Object[] {"VacantesUsuariosDocCVRec",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosDocRefLab",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosDocExPsi",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosDocBusWeb",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosDocAvPriv",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosDocAvConf",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosFechaEnvOp",System.Data.DbType.DateTime,8,5} ,
          new Object[] {"VacantesUsuariosFechaEnvCli",System.Data.DbType.DateTime,8,5} ,
          new Object[] {"SUBT_ReclutadorId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000H22 ;
          prmT000H22 = new Object[] {
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000H24 ;
          prmT000H24 = new Object[] {
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000H23 ;
          prmT000H23 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("T000H2", "SELECT `Vacantes_Id`, `UsuariosVacanteEstatus`, `VacantesUsuariosFechaP`, `VacantesUsuariosFechaD`, `VacantesUsuariosFechaA`, `VacantesUsuariosFecha3`, `VacantesUsuariosMotD`, `VacantesUsuariosEstatus`, `VacantesUsuariosPrefiltro`, `VacantesUsuariosCV`, `VacantesUsuariosExTec`, `VacantesUsuariosCVRec`, `VacantesUsuariosRefLab`, `VacantesUsuariosExPsi`, `VacantesUsuariosBusWeb`, `VacantesUsuariosAvPriv`, `VacantesUsuariosAvConf`, `VacantesUsuariosDocP`, `VacantesUsuariosDocCV`, `VacantesUsuariosDocTec`, `VacantesUsuariosFechaE`, `VacantesUsuariosDocCVRec`, `VacantesUsuariosDocRefLab`, `VacantesUsuariosDocExPsi`, `VacantesUsuariosDocBusWeb`, `VacantesUsuariosDocAvPriv`, `VacantesUsuariosDocAvConf`, `VacantesUsuariosFechaEnvOp`, `VacantesUsuariosFechaEnvCli`, `UsuariosId`, `SUBT_ReclutadorId` AS SUBT_ReclutadorId FROM `VacantesUsuariosVacante` WHERE `Vacantes_Id` = ? AND `UsuariosId` = ?  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H3", "SELECT `Vacantes_Id`, `UsuariosVacanteEstatus`, `VacantesUsuariosFechaP`, `VacantesUsuariosFechaD`, `VacantesUsuariosFechaA`, `VacantesUsuariosFecha3`, `VacantesUsuariosMotD`, `VacantesUsuariosEstatus`, `VacantesUsuariosPrefiltro`, `VacantesUsuariosCV`, `VacantesUsuariosExTec`, `VacantesUsuariosCVRec`, `VacantesUsuariosRefLab`, `VacantesUsuariosExPsi`, `VacantesUsuariosBusWeb`, `VacantesUsuariosAvPriv`, `VacantesUsuariosAvConf`, `VacantesUsuariosDocP`, `VacantesUsuariosDocCV`, `VacantesUsuariosDocTec`, `VacantesUsuariosFechaE`, `VacantesUsuariosDocCVRec`, `VacantesUsuariosDocRefLab`, `VacantesUsuariosDocExPsi`, `VacantesUsuariosDocBusWeb`, `VacantesUsuariosDocAvPriv`, `VacantesUsuariosDocAvConf`, `VacantesUsuariosFechaEnvOp`, `VacantesUsuariosFechaEnvCli`, `UsuariosId`, `SUBT_ReclutadorId` AS SUBT_ReclutadorId FROM `VacantesUsuariosVacante` WHERE `Vacantes_Id` = ? AND `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H4", "SELECT `UsuariosNombre`, `UsuariosApPat`, `UsuariosApMat` FROM `Usuarios` WHERE `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H5", "SELECT `UsuariosId` AS SUBT_ReclutadorId FROM `Usuarios` WHERE `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H6", "SELECT `Vacantes_Id`, `Vacantes_Nombre`, `Vacantes_Descripcion`, `Vacantes_Status`, `Vacantes_FechaInicio`, `Vacantes_Sueldo`, `Vacantes_Tipo`, `Vacantes_Duracion`, `Vacantes_Duracion_Nom`, `Vacantes_Plazas` FROM `Vacantes` WHERE `Vacantes_Id` = ?  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H7", "SELECT `Vacantes_Id`, `Vacantes_Nombre`, `Vacantes_Descripcion`, `Vacantes_Status`, `Vacantes_FechaInicio`, `Vacantes_Sueldo`, `Vacantes_Tipo`, `Vacantes_Duracion`, `Vacantes_Duracion_Nom`, `Vacantes_Plazas` FROM `Vacantes` WHERE `Vacantes_Id` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H8", "SELECT TM1.`Vacantes_Id`, TM1.`Vacantes_Nombre`, TM1.`Vacantes_Descripcion`, TM1.`Vacantes_Status`, TM1.`Vacantes_FechaInicio`, TM1.`Vacantes_Sueldo`, TM1.`Vacantes_Tipo`, TM1.`Vacantes_Duracion`, TM1.`Vacantes_Duracion_Nom`, TM1.`Vacantes_Plazas` FROM `Vacantes` TM1 WHERE TM1.`Vacantes_Id` = ? ORDER BY TM1.`Vacantes_Id` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H9", "SELECT `Vacantes_Id` FROM `Vacantes` WHERE `Vacantes_Id` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H10", "SELECT `Vacantes_Id` FROM `Vacantes` WHERE ( `Vacantes_Id` > ?) ORDER BY `Vacantes_Id`  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000H10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000H11", "SELECT `Vacantes_Id` FROM `Vacantes` WHERE ( `Vacantes_Id` < ?) ORDER BY `Vacantes_Id` DESC  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000H11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000H12", "INSERT INTO `Vacantes`(`Vacantes_Nombre`, `Vacantes_Descripcion`, `Vacantes_Status`, `Vacantes_FechaInicio`, `Vacantes_Sueldo`, `Vacantes_Tipo`, `Vacantes_Duracion`, `Vacantes_Duracion_Nom`, `Vacantes_Plazas`) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?)", GxErrorMask.GX_NOMASK,prmT000H12)
             ,new CursorDef("T000H13", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H14", "UPDATE `Vacantes` SET `Vacantes_Nombre`=?, `Vacantes_Descripcion`=?, `Vacantes_Status`=?, `Vacantes_FechaInicio`=?, `Vacantes_Sueldo`=?, `Vacantes_Tipo`=?, `Vacantes_Duracion`=?, `Vacantes_Duracion_Nom`=?, `Vacantes_Plazas`=?  WHERE `Vacantes_Id` = ?", GxErrorMask.GX_NOMASK,prmT000H14)
             ,new CursorDef("T000H15", "DELETE FROM `Vacantes`  WHERE `Vacantes_Id` = ?", GxErrorMask.GX_NOMASK,prmT000H15)
             ,new CursorDef("T000H16", "SELECT `Vacantes_Id` FROM `Vacantes` ORDER BY `Vacantes_Id` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H16,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H17", "SELECT T1.`Vacantes_Id`, T2.`UsuariosNombre`, T2.`UsuariosApPat`, T2.`UsuariosApMat`, T1.`UsuariosVacanteEstatus`, T1.`VacantesUsuariosFechaP`, T1.`VacantesUsuariosFechaD`, T1.`VacantesUsuariosFechaA`, T1.`VacantesUsuariosFecha3`, T1.`VacantesUsuariosMotD`, T1.`VacantesUsuariosEstatus`, T1.`VacantesUsuariosPrefiltro`, T1.`VacantesUsuariosCV`, T1.`VacantesUsuariosExTec`, T1.`VacantesUsuariosCVRec`, T1.`VacantesUsuariosRefLab`, T1.`VacantesUsuariosExPsi`, T1.`VacantesUsuariosBusWeb`, T1.`VacantesUsuariosAvPriv`, T1.`VacantesUsuariosAvConf`, T1.`VacantesUsuariosDocP`, T1.`VacantesUsuariosDocCV`, T1.`VacantesUsuariosDocTec`, T1.`VacantesUsuariosFechaE`, T1.`VacantesUsuariosDocCVRec`, T1.`VacantesUsuariosDocRefLab`, T1.`VacantesUsuariosDocExPsi`, T1.`VacantesUsuariosDocBusWeb`, T1.`VacantesUsuariosDocAvPriv`, T1.`VacantesUsuariosDocAvConf`, T1.`VacantesUsuariosFechaEnvOp`, T1.`VacantesUsuariosFechaEnvCli`, T1.`UsuariosId`, T1.`SUBT_ReclutadorId` AS SUBT_ReclutadorId FROM (`VacantesUsuariosVacante` T1 INNER JOIN `Usuarios` T2 ON T2.`UsuariosId` = T1.`UsuariosId`) WHERE T1.`Vacantes_Id` = ? and T1.`UsuariosId` = ? ORDER BY T1.`Vacantes_Id`, T1.`UsuariosId` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H17,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H18", "SELECT `UsuariosNombre`, `UsuariosApPat`, `UsuariosApMat` FROM `Usuarios` WHERE `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H19", "SELECT `Vacantes_Id`, `UsuariosId` FROM `VacantesUsuariosVacante` WHERE `Vacantes_Id` = ? AND `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H20", "INSERT INTO `VacantesUsuariosVacante`(`Vacantes_Id`, `UsuariosVacanteEstatus`, `VacantesUsuariosFechaP`, `VacantesUsuariosFechaD`, `VacantesUsuariosFechaA`, `VacantesUsuariosFecha3`, `VacantesUsuariosMotD`, `VacantesUsuariosEstatus`, `VacantesUsuariosPrefiltro`, `VacantesUsuariosCV`, `VacantesUsuariosExTec`, `VacantesUsuariosCVRec`, `VacantesUsuariosRefLab`, `VacantesUsuariosExPsi`, `VacantesUsuariosBusWeb`, `VacantesUsuariosAvPriv`, `VacantesUsuariosAvConf`, `VacantesUsuariosDocP`, `VacantesUsuariosDocCV`, `VacantesUsuariosDocTec`, `VacantesUsuariosFechaE`, `VacantesUsuariosDocCVRec`, `VacantesUsuariosDocRefLab`, `VacantesUsuariosDocExPsi`, `VacantesUsuariosDocBusWeb`, `VacantesUsuariosDocAvPriv`, `VacantesUsuariosDocAvConf`, `VacantesUsuariosFechaEnvOp`, `VacantesUsuariosFechaEnvCli`, `UsuariosId`, `SUBT_ReclutadorId`) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", GxErrorMask.GX_NOMASK,prmT000H20)
             ,new CursorDef("T000H21", "UPDATE `VacantesUsuariosVacante` SET `UsuariosVacanteEstatus`=?, `VacantesUsuariosFechaP`=?, `VacantesUsuariosFechaD`=?, `VacantesUsuariosFechaA`=?, `VacantesUsuariosFecha3`=?, `VacantesUsuariosMotD`=?, `VacantesUsuariosEstatus`=?, `VacantesUsuariosPrefiltro`=?, `VacantesUsuariosCV`=?, `VacantesUsuariosExTec`=?, `VacantesUsuariosCVRec`=?, `VacantesUsuariosRefLab`=?, `VacantesUsuariosExPsi`=?, `VacantesUsuariosBusWeb`=?, `VacantesUsuariosAvPriv`=?, `VacantesUsuariosAvConf`=?, `VacantesUsuariosDocP`=?, `VacantesUsuariosDocCV`=?, `VacantesUsuariosDocTec`=?, `VacantesUsuariosFechaE`=?, `VacantesUsuariosDocCVRec`=?, `VacantesUsuariosDocRefLab`=?, `VacantesUsuariosDocExPsi`=?, `VacantesUsuariosDocBusWeb`=?, `VacantesUsuariosDocAvPriv`=?, `VacantesUsuariosDocAvConf`=?, `VacantesUsuariosFechaEnvOp`=?, `VacantesUsuariosFechaEnvCli`=?, `SUBT_ReclutadorId`=?  WHERE `Vacantes_Id` = ? AND `UsuariosId` = ?", GxErrorMask.GX_NOMASK,prmT000H21)
             ,new CursorDef("T000H22", "DELETE FROM `VacantesUsuariosVacante`  WHERE `Vacantes_Id` = ? AND `UsuariosId` = ?", GxErrorMask.GX_NOMASK,prmT000H22)
             ,new CursorDef("T000H23", "SELECT `UsuariosNombre`, `UsuariosApPat`, `UsuariosApMat` FROM `Usuarios` WHERE `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H23,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H24", "SELECT `Vacantes_Id`, `UsuariosId` FROM `VacantesUsuariosVacante` WHERE `Vacantes_Id` = ? ORDER BY `Vacantes_Id`, `UsuariosId` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H24,11, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3) ;
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(6) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((String[]) buf[9])[0] = rslt.getVarchar(7) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((short[]) buf[11])[0] = rslt.getShort(8) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((short[]) buf[13])[0] = rslt.getShort(9) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((short[]) buf[15])[0] = rslt.getShort(10) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(10);
                ((short[]) buf[17])[0] = rslt.getShort(11) ;
                ((bool[]) buf[18])[0] = rslt.wasNull(11);
                ((short[]) buf[19])[0] = rslt.getShort(12) ;
                ((bool[]) buf[20])[0] = rslt.wasNull(12);
                ((short[]) buf[21])[0] = rslt.getShort(13) ;
                ((bool[]) buf[22])[0] = rslt.wasNull(13);
                ((short[]) buf[23])[0] = rslt.getShort(14) ;
                ((bool[]) buf[24])[0] = rslt.wasNull(14);
                ((short[]) buf[25])[0] = rslt.getShort(15) ;
                ((bool[]) buf[26])[0] = rslt.wasNull(15);
                ((short[]) buf[27])[0] = rslt.getShort(16) ;
                ((bool[]) buf[28])[0] = rslt.wasNull(16);
                ((short[]) buf[29])[0] = rslt.getShort(17) ;
                ((bool[]) buf[30])[0] = rslt.wasNull(17);
                ((String[]) buf[31])[0] = rslt.getVarchar(18) ;
                ((bool[]) buf[32])[0] = rslt.wasNull(18);
                ((String[]) buf[33])[0] = rslt.getVarchar(19) ;
                ((bool[]) buf[34])[0] = rslt.wasNull(19);
                ((String[]) buf[35])[0] = rslt.getVarchar(20) ;
                ((bool[]) buf[36])[0] = rslt.wasNull(20);
                ((DateTime[]) buf[37])[0] = rslt.getGXDateTime(21) ;
                ((bool[]) buf[38])[0] = rslt.wasNull(21);
                ((String[]) buf[39])[0] = rslt.getVarchar(22) ;
                ((bool[]) buf[40])[0] = rslt.wasNull(22);
                ((String[]) buf[41])[0] = rslt.getVarchar(23) ;
                ((bool[]) buf[42])[0] = rslt.wasNull(23);
                ((String[]) buf[43])[0] = rslt.getVarchar(24) ;
                ((bool[]) buf[44])[0] = rslt.wasNull(24);
                ((String[]) buf[45])[0] = rslt.getVarchar(25) ;
                ((bool[]) buf[46])[0] = rslt.wasNull(25);
                ((String[]) buf[47])[0] = rslt.getVarchar(26) ;
                ((bool[]) buf[48])[0] = rslt.wasNull(26);
                ((String[]) buf[49])[0] = rslt.getVarchar(27) ;
                ((bool[]) buf[50])[0] = rslt.wasNull(27);
                ((DateTime[]) buf[51])[0] = rslt.getGXDateTime(28) ;
                ((bool[]) buf[52])[0] = rslt.wasNull(28);
                ((DateTime[]) buf[53])[0] = rslt.getGXDateTime(29) ;
                ((bool[]) buf[54])[0] = rslt.wasNull(29);
                ((int[]) buf[55])[0] = rslt.getInt(30) ;
                ((int[]) buf[56])[0] = rslt.getInt(31) ;
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3) ;
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(6) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((String[]) buf[9])[0] = rslt.getVarchar(7) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((short[]) buf[11])[0] = rslt.getShort(8) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((short[]) buf[13])[0] = rslt.getShort(9) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((short[]) buf[15])[0] = rslt.getShort(10) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(10);
                ((short[]) buf[17])[0] = rslt.getShort(11) ;
                ((bool[]) buf[18])[0] = rslt.wasNull(11);
                ((short[]) buf[19])[0] = rslt.getShort(12) ;
                ((bool[]) buf[20])[0] = rslt.wasNull(12);
                ((short[]) buf[21])[0] = rslt.getShort(13) ;
                ((bool[]) buf[22])[0] = rslt.wasNull(13);
                ((short[]) buf[23])[0] = rslt.getShort(14) ;
                ((bool[]) buf[24])[0] = rslt.wasNull(14);
                ((short[]) buf[25])[0] = rslt.getShort(15) ;
                ((bool[]) buf[26])[0] = rslt.wasNull(15);
                ((short[]) buf[27])[0] = rslt.getShort(16) ;
                ((bool[]) buf[28])[0] = rslt.wasNull(16);
                ((short[]) buf[29])[0] = rslt.getShort(17) ;
                ((bool[]) buf[30])[0] = rslt.wasNull(17);
                ((String[]) buf[31])[0] = rslt.getVarchar(18) ;
                ((bool[]) buf[32])[0] = rslt.wasNull(18);
                ((String[]) buf[33])[0] = rslt.getVarchar(19) ;
                ((bool[]) buf[34])[0] = rslt.wasNull(19);
                ((String[]) buf[35])[0] = rslt.getVarchar(20) ;
                ((bool[]) buf[36])[0] = rslt.wasNull(20);
                ((DateTime[]) buf[37])[0] = rslt.getGXDateTime(21) ;
                ((bool[]) buf[38])[0] = rslt.wasNull(21);
                ((String[]) buf[39])[0] = rslt.getVarchar(22) ;
                ((bool[]) buf[40])[0] = rslt.wasNull(22);
                ((String[]) buf[41])[0] = rslt.getVarchar(23) ;
                ((bool[]) buf[42])[0] = rslt.wasNull(23);
                ((String[]) buf[43])[0] = rslt.getVarchar(24) ;
                ((bool[]) buf[44])[0] = rslt.wasNull(24);
                ((String[]) buf[45])[0] = rslt.getVarchar(25) ;
                ((bool[]) buf[46])[0] = rslt.wasNull(25);
                ((String[]) buf[47])[0] = rslt.getVarchar(26) ;
                ((bool[]) buf[48])[0] = rslt.wasNull(26);
                ((String[]) buf[49])[0] = rslt.getVarchar(27) ;
                ((bool[]) buf[50])[0] = rslt.wasNull(27);
                ((DateTime[]) buf[51])[0] = rslt.getGXDateTime(28) ;
                ((bool[]) buf[52])[0] = rslt.wasNull(28);
                ((DateTime[]) buf[53])[0] = rslt.getGXDateTime(29) ;
                ((bool[]) buf[54])[0] = rslt.wasNull(29);
                ((int[]) buf[55])[0] = rslt.getInt(30) ;
                ((int[]) buf[56])[0] = rslt.getInt(31) ;
                return;
             case 2 :
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((short[]) buf[3])[0] = rslt.getShort(4) ;
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5) ;
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6) ;
                ((short[]) buf[6])[0] = rslt.getShort(7) ;
                ((short[]) buf[7])[0] = rslt.getShort(8) ;
                ((short[]) buf[8])[0] = rslt.getShort(9) ;
                ((short[]) buf[9])[0] = rslt.getShort(10) ;
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((short[]) buf[3])[0] = rslt.getShort(4) ;
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5) ;
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6) ;
                ((short[]) buf[6])[0] = rslt.getShort(7) ;
                ((short[]) buf[7])[0] = rslt.getShort(8) ;
                ((short[]) buf[8])[0] = rslt.getShort(9) ;
                ((short[]) buf[9])[0] = rslt.getShort(10) ;
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((short[]) buf[3])[0] = rslt.getShort(4) ;
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5) ;
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6) ;
                ((short[]) buf[6])[0] = rslt.getShort(7) ;
                ((short[]) buf[7])[0] = rslt.getShort(8) ;
                ((short[]) buf[8])[0] = rslt.getShort(9) ;
                ((short[]) buf[9])[0] = rslt.getShort(10) ;
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((String[]) buf[3])[0] = rslt.getVarchar(4) ;
                ((short[]) buf[4])[0] = rslt.getShort(5) ;
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6) ;
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8) ;
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(9) ;
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((String[]) buf[12])[0] = rslt.getVarchar(10) ;
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((short[]) buf[14])[0] = rslt.getShort(11) ;
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((short[]) buf[16])[0] = rslt.getShort(12) ;
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((short[]) buf[18])[0] = rslt.getShort(13) ;
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((short[]) buf[20])[0] = rslt.getShort(14) ;
                ((bool[]) buf[21])[0] = rslt.wasNull(14);
                ((short[]) buf[22])[0] = rslt.getShort(15) ;
                ((bool[]) buf[23])[0] = rslt.wasNull(15);
                ((short[]) buf[24])[0] = rslt.getShort(16) ;
                ((bool[]) buf[25])[0] = rslt.wasNull(16);
                ((short[]) buf[26])[0] = rslt.getShort(17) ;
                ((bool[]) buf[27])[0] = rslt.wasNull(17);
                ((short[]) buf[28])[0] = rslt.getShort(18) ;
                ((bool[]) buf[29])[0] = rslt.wasNull(18);
                ((short[]) buf[30])[0] = rslt.getShort(19) ;
                ((bool[]) buf[31])[0] = rslt.wasNull(19);
                ((short[]) buf[32])[0] = rslt.getShort(20) ;
                ((bool[]) buf[33])[0] = rslt.wasNull(20);
                ((String[]) buf[34])[0] = rslt.getVarchar(21) ;
                ((bool[]) buf[35])[0] = rslt.wasNull(21);
                ((String[]) buf[36])[0] = rslt.getVarchar(22) ;
                ((bool[]) buf[37])[0] = rslt.wasNull(22);
                ((String[]) buf[38])[0] = rslt.getVarchar(23) ;
                ((bool[]) buf[39])[0] = rslt.wasNull(23);
                ((DateTime[]) buf[40])[0] = rslt.getGXDateTime(24) ;
                ((bool[]) buf[41])[0] = rslt.wasNull(24);
                ((String[]) buf[42])[0] = rslt.getVarchar(25) ;
                ((bool[]) buf[43])[0] = rslt.wasNull(25);
                ((String[]) buf[44])[0] = rslt.getVarchar(26) ;
                ((bool[]) buf[45])[0] = rslt.wasNull(26);
                ((String[]) buf[46])[0] = rslt.getVarchar(27) ;
                ((bool[]) buf[47])[0] = rslt.wasNull(27);
                ((String[]) buf[48])[0] = rslt.getVarchar(28) ;
                ((bool[]) buf[49])[0] = rslt.wasNull(28);
                ((String[]) buf[50])[0] = rslt.getVarchar(29) ;
                ((bool[]) buf[51])[0] = rslt.wasNull(29);
                ((String[]) buf[52])[0] = rslt.getVarchar(30) ;
                ((bool[]) buf[53])[0] = rslt.wasNull(30);
                ((DateTime[]) buf[54])[0] = rslt.getGXDateTime(31) ;
                ((bool[]) buf[55])[0] = rslt.wasNull(31);
                ((DateTime[]) buf[56])[0] = rslt.getGXDateTime(32) ;
                ((bool[]) buf[57])[0] = rslt.wasNull(32);
                ((int[]) buf[58])[0] = rslt.getInt(33) ;
                ((int[]) buf[59])[0] = rslt.getInt(34) ;
                return;
             case 16 :
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                return;
             case 21 :
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                return;
             case 22 :
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
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 10 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                stmt.SetParameter(4, (DateTime)parms[3]);
                stmt.SetParameter(5, (decimal)parms[4]);
                stmt.SetParameter(6, (short)parms[5]);
                stmt.SetParameter(7, (short)parms[6]);
                stmt.SetParameter(8, (short)parms[7]);
                stmt.SetParameter(9, (short)parms[8]);
                return;
             case 12 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                stmt.SetParameter(4, (DateTime)parms[3]);
                stmt.SetParameter(5, (decimal)parms[4]);
                stmt.SetParameter(6, (short)parms[5]);
                stmt.SetParameter(7, (short)parms[6]);
                stmt.SetParameter(8, (short)parms[7]);
                stmt.SetParameter(9, (short)parms[8]);
                stmt.SetParameter(10, (int)parms[9]);
                return;
             case 13 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 15 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
             case 16 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 17 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
             case 18 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                stmt.SetParameterDatetime(3, (DateTime)parms[2]);
                if ( (bool)parms[3] )
                {
                   stmt.setNull( 4 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameterDatetime(4, (DateTime)parms[4]);
                }
                if ( (bool)parms[5] )
                {
                   stmt.setNull( 5 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameterDatetime(5, (DateTime)parms[6]);
                }
                if ( (bool)parms[7] )
                {
                   stmt.setNull( 6 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameterDatetime(6, (DateTime)parms[8]);
                }
                if ( (bool)parms[9] )
                {
                   stmt.setNull( 7 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(7, (String)parms[10]);
                }
                if ( (bool)parms[11] )
                {
                   stmt.setNull( 8 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(8, (short)parms[12]);
                }
                if ( (bool)parms[13] )
                {
                   stmt.setNull( 9 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(9, (short)parms[14]);
                }
                if ( (bool)parms[15] )
                {
                   stmt.setNull( 10 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(10, (short)parms[16]);
                }
                if ( (bool)parms[17] )
                {
                   stmt.setNull( 11 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(11, (short)parms[18]);
                }
                if ( (bool)parms[19] )
                {
                   stmt.setNull( 12 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(12, (short)parms[20]);
                }
                if ( (bool)parms[21] )
                {
                   stmt.setNull( 13 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(13, (short)parms[22]);
                }
                if ( (bool)parms[23] )
                {
                   stmt.setNull( 14 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(14, (short)parms[24]);
                }
                if ( (bool)parms[25] )
                {
                   stmt.setNull( 15 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(15, (short)parms[26]);
                }
                if ( (bool)parms[27] )
                {
                   stmt.setNull( 16 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(16, (short)parms[28]);
                }
                if ( (bool)parms[29] )
                {
                   stmt.setNull( 17 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(17, (short)parms[30]);
                }
                if ( (bool)parms[31] )
                {
                   stmt.setNull( 18 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(18, (String)parms[32]);
                }
                if ( (bool)parms[33] )
                {
                   stmt.setNull( 19 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(19, (String)parms[34]);
                }
                if ( (bool)parms[35] )
                {
                   stmt.setNull( 20 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(20, (String)parms[36]);
                }
                if ( (bool)parms[37] )
                {
                   stmt.setNull( 21 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameterDatetime(21, (DateTime)parms[38]);
                }
                if ( (bool)parms[39] )
                {
                   stmt.setNull( 22 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(22, (String)parms[40]);
                }
                if ( (bool)parms[41] )
                {
                   stmt.setNull( 23 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(23, (String)parms[42]);
                }
                if ( (bool)parms[43] )
                {
                   stmt.setNull( 24 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(24, (String)parms[44]);
                }
                if ( (bool)parms[45] )
                {
                   stmt.setNull( 25 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(25, (String)parms[46]);
                }
                if ( (bool)parms[47] )
                {
                   stmt.setNull( 26 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(26, (String)parms[48]);
                }
                if ( (bool)parms[49] )
                {
                   stmt.setNull( 27 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(27, (String)parms[50]);
                }
                if ( (bool)parms[51] )
                {
                   stmt.setNull( 28 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameterDatetime(28, (DateTime)parms[52]);
                }
                if ( (bool)parms[53] )
                {
                   stmt.setNull( 29 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameterDatetime(29, (DateTime)parms[54]);
                }
                stmt.SetParameter(30, (int)parms[55]);
                stmt.SetParameter(31, (int)parms[56]);
                return;
             case 19 :
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameterDatetime(2, (DateTime)parms[1]);
                if ( (bool)parms[2] )
                {
                   stmt.setNull( 3 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameterDatetime(3, (DateTime)parms[3]);
                }
                if ( (bool)parms[4] )
                {
                   stmt.setNull( 4 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameterDatetime(4, (DateTime)parms[5]);
                }
                if ( (bool)parms[6] )
                {
                   stmt.setNull( 5 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameterDatetime(5, (DateTime)parms[7]);
                }
                if ( (bool)parms[8] )
                {
                   stmt.setNull( 6 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(6, (String)parms[9]);
                }
                if ( (bool)parms[10] )
                {
                   stmt.setNull( 7 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(7, (short)parms[11]);
                }
                if ( (bool)parms[12] )
                {
                   stmt.setNull( 8 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(8, (short)parms[13]);
                }
                if ( (bool)parms[14] )
                {
                   stmt.setNull( 9 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(9, (short)parms[15]);
                }
                if ( (bool)parms[16] )
                {
                   stmt.setNull( 10 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(10, (short)parms[17]);
                }
                if ( (bool)parms[18] )
                {
                   stmt.setNull( 11 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(11, (short)parms[19]);
                }
                if ( (bool)parms[20] )
                {
                   stmt.setNull( 12 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(12, (short)parms[21]);
                }
                if ( (bool)parms[22] )
                {
                   stmt.setNull( 13 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(13, (short)parms[23]);
                }
                if ( (bool)parms[24] )
                {
                   stmt.setNull( 14 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(14, (short)parms[25]);
                }
                if ( (bool)parms[26] )
                {
                   stmt.setNull( 15 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(15, (short)parms[27]);
                }
                if ( (bool)parms[28] )
                {
                   stmt.setNull( 16 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(16, (short)parms[29]);
                }
                if ( (bool)parms[30] )
                {
                   stmt.setNull( 17 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(17, (String)parms[31]);
                }
                if ( (bool)parms[32] )
                {
                   stmt.setNull( 18 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(18, (String)parms[33]);
                }
                if ( (bool)parms[34] )
                {
                   stmt.setNull( 19 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(19, (String)parms[35]);
                }
                if ( (bool)parms[36] )
                {
                   stmt.setNull( 20 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameterDatetime(20, (DateTime)parms[37]);
                }
                if ( (bool)parms[38] )
                {
                   stmt.setNull( 21 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(21, (String)parms[39]);
                }
                if ( (bool)parms[40] )
                {
                   stmt.setNull( 22 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(22, (String)parms[41]);
                }
                if ( (bool)parms[42] )
                {
                   stmt.setNull( 23 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(23, (String)parms[43]);
                }
                if ( (bool)parms[44] )
                {
                   stmt.setNull( 24 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(24, (String)parms[45]);
                }
                if ( (bool)parms[46] )
                {
                   stmt.setNull( 25 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(25, (String)parms[47]);
                }
                if ( (bool)parms[48] )
                {
                   stmt.setNull( 26 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(26, (String)parms[49]);
                }
                if ( (bool)parms[50] )
                {
                   stmt.setNull( 27 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameterDatetime(27, (DateTime)parms[51]);
                }
                if ( (bool)parms[52] )
                {
                   stmt.setNull( 28 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameterDatetime(28, (DateTime)parms[53]);
                }
                stmt.SetParameter(29, (int)parms[54]);
                stmt.SetParameter(30, (int)parms[55]);
                stmt.SetParameter(31, (int)parms[56]);
                return;
             case 20 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
             case 21 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 22 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

}
