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
   public class meninicio : GXHttpHandler, System.Web.SessionState.IRequiresSessionState
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
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7menInicioId = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignAttri("", false, "AV7menInicioId", StringUtil.LTrimStr( (decimal)(AV7menInicioId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vMENINICIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7menInicioId), "ZZZZZ9"), context));
               AV20sgUsrMenId = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignAttri("", false, "AV20sgUsrMenId", StringUtil.LTrimStr( (decimal)(AV20sgUsrMenId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vSGUSRMENID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV20sgUsrMenId), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Tabla de mensajes de inicio", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtmenInicioId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public meninicio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public meninicio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( String aP0_Gx_mode ,
                           int aP1_menInicioId ,
                           int aP2_sgUsrMenId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7menInicioId = aP1_menInicioId;
         this.AV20sgUsrMenId = aP2_sgUsrMenId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbmenInicioStat = new GXCombobox();
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
         if ( cmbmenInicioStat.ItemCount > 0 )
         {
            A77menInicioStat = (short)(NumberUtil.Val( cmbmenInicioStat.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A77menInicioStat), 1, 0))), "."));
            AssignAttri("", false, "A77menInicioStat", StringUtil.Str( (decimal)(A77menInicioStat), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbmenInicioStat.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A77menInicioStat), 1, 0));
            AssignProp("", false, cmbmenInicioStat_Internalname, "Values", cmbmenInicioStat.ToJavascriptSource(), true);
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
            RenderHtmlCloseForm0713( ) ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Tabla de mensajes de inicio", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_menInicio.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_menInicio.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_menInicio.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_menInicio.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_menInicio.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_menInicio.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtmenInicioId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtmenInicioId_Internalname, "Clave del mensaje", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtmenInicioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A58menInicioId), 6, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A58menInicioId), "ZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtmenInicioId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtmenInicioId_Enabled, 1, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "NumId", "right", false, "", "HLP_menInicio.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtmenInicioDes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtmenInicioDes_Internalname, "Mensaje", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtmenInicioDes_Internalname, A150menInicioDes, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtmenInicioDes_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_menInicio.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtmenInicioFecIni_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtmenInicioFecIni_Internalname, "Fecha Inicio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtmenInicioFecIni_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtmenInicioFecIni_Internalname, context.localUtil.Format(A186menInicioFecIni, "99/99/9999"), context.localUtil.Format( A186menInicioFecIni, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtmenInicioFecIni_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtmenInicioFecIni_Enabled, 1, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "Fecha", "right", false, "", "HLP_menInicio.htm");
         GxWebStd.gx_bitmap( context, edtmenInicioFecIni_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtmenInicioFecIni_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_menInicio.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtmenInicioFecFin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtmenInicioFecFin_Internalname, "Fecha Fin", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtmenInicioFecFin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtmenInicioFecFin_Internalname, context.localUtil.Format(A76menInicioFecFin, "99/99/9999"), context.localUtil.Format( A76menInicioFecFin, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtmenInicioFecFin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtmenInicioFecFin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "Fecha", "right", false, "", "HLP_menInicio.htm");
         GxWebStd.gx_bitmap( context, edtmenInicioFecFin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtmenInicioFecFin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_menInicio.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbmenInicioStat_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbmenInicioStat_Internalname, "Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbmenInicioStat, cmbmenInicioStat_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A77menInicioStat), 1, 0)), 1, cmbmenInicioStat_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbmenInicioStat.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, "HLP_menInicio.htm");
         cmbmenInicioStat.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A77menInicioStat), 1, 0));
         AssignProp("", false, cmbmenInicioStat_Internalname, "Values", (String)(cmbmenInicioStat.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", edtmenInicioFecCap_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtmenInicioFecCap_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtmenInicioFecCap_Internalname, "Fecha/Hora Captura", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtmenInicioFecCap_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtmenInicioFecCap_Internalname, context.localUtil.TToC( A185menInicioFecCap, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A185menInicioFecCap, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'spa',false,0);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtmenInicioFecCap_Jsonclick, 0, "Attribute", "", "", "", "", edtmenInicioFecCap_Visible, edtmenInicioFecCap_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 1, -1, 0, true, "FechaTiempo", "right", false, "", "HLP_menInicio.htm");
         GxWebStd.gx_bitmap( context, edtmenInicioFecCap_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtmenInicioFecCap_Visible==0)||(edtmenInicioFecCap_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_menInicio.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtsgUsrMenId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsgUsrMenId_Internalname, "Clave de usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsgUsrMenId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A59sgUsrMenId), 6, 0, ",", "")), ((edtsgUsrMenId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A59sgUsrMenId), "ZZZZZ9")) : context.localUtil.Format( (decimal)(A59sgUsrMenId), "ZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsgUsrMenId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsgUsrMenId_Enabled, 0, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_menInicio.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtsgUsrMenNom_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsgUsrMenNom_Internalname, "Usuario Captura", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsgUsrMenNom_Internalname, A187sgUsrMenNom, StringUtil.RTrim( context.localUtil.Format( A187sgUsrMenNom, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsgUsrMenNom_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsgUsrMenNom_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_menInicio.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_menInicio.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_menInicio.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_menInicio.htm");
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
         E11072 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z58menInicioId = (int)(context.localUtil.CToN( cgiGet( "Z58menInicioId"), ",", "."));
               Z59sgUsrMenId = (int)(context.localUtil.CToN( cgiGet( "Z59sgUsrMenId"), ",", "."));
               Z185menInicioFecCap = context.localUtil.CToT( cgiGet( "Z185menInicioFecCap"), 0);
               Z150menInicioDes = cgiGet( "Z150menInicioDes");
               Z186menInicioFecIni = context.localUtil.CToD( cgiGet( "Z186menInicioFecIni"), 0);
               Z76menInicioFecFin = context.localUtil.CToD( cgiGet( "Z76menInicioFecFin"), 0);
               Z77menInicioStat = (short)(context.localUtil.CToN( cgiGet( "Z77menInicioStat"), ",", "."));
               Z187sgUsrMenNom = cgiGet( "Z187sgUsrMenNom");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               AV7menInicioId = (int)(context.localUtil.CToN( cgiGet( "vMENINICIOID"), ",", "."));
               AV19numero = (int)(context.localUtil.CToN( cgiGet( "vNUMERO"), ",", "."));
               AV20sgUsrMenId = (int)(context.localUtil.CToN( cgiGet( "vSGUSRMENID"), ",", "."));
               AV21Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtmenInicioId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtmenInicioId_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MENINICIOID");
                  AnyError = 1;
                  GX_FocusControl = edtmenInicioId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A58menInicioId = 0;
                  AssignAttri("", false, "A58menInicioId", StringUtil.LTrimStr( (decimal)(A58menInicioId), 6, 0));
               }
               else
               {
                  A58menInicioId = (int)(context.localUtil.CToN( cgiGet( edtmenInicioId_Internalname), ",", "."));
                  AssignAttri("", false, "A58menInicioId", StringUtil.LTrimStr( (decimal)(A58menInicioId), 6, 0));
               }
               A150menInicioDes = cgiGet( edtmenInicioDes_Internalname);
               AssignAttri("", false, "A150menInicioDes", A150menInicioDes);
               if ( context.localUtil.VCDate( cgiGet( edtmenInicioFecIni_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha de inicio de vigencia"}), 1, "MENINICIOFECINI");
                  AnyError = 1;
                  GX_FocusControl = edtmenInicioFecIni_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A186menInicioFecIni = DateTime.MinValue;
                  AssignAttri("", false, "A186menInicioFecIni", context.localUtil.Format(A186menInicioFecIni, "99/99/9999"));
               }
               else
               {
                  A186menInicioFecIni = context.localUtil.CToD( cgiGet( edtmenInicioFecIni_Internalname), 2);
                  AssignAttri("", false, "A186menInicioFecIni", context.localUtil.Format(A186menInicioFecIni, "99/99/9999"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtmenInicioFecFin_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha de fin de vigencia"}), 1, "MENINICIOFECFIN");
                  AnyError = 1;
                  GX_FocusControl = edtmenInicioFecFin_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A76menInicioFecFin = DateTime.MinValue;
                  AssignAttri("", false, "A76menInicioFecFin", context.localUtil.Format(A76menInicioFecFin, "99/99/9999"));
               }
               else
               {
                  A76menInicioFecFin = context.localUtil.CToD( cgiGet( edtmenInicioFecFin_Internalname), 2);
                  AssignAttri("", false, "A76menInicioFecFin", context.localUtil.Format(A76menInicioFecFin, "99/99/9999"));
               }
               cmbmenInicioStat.CurrentValue = cgiGet( cmbmenInicioStat_Internalname);
               A77menInicioStat = (short)(NumberUtil.Val( cgiGet( cmbmenInicioStat_Internalname), "."));
               AssignAttri("", false, "A77menInicioStat", StringUtil.Str( (decimal)(A77menInicioStat), 1, 0));
               if ( context.localUtil.VCDateTime( cgiGet( edtmenInicioFecCap_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha de captura"}), 1, "MENINICIOFECCAP");
                  AnyError = 1;
                  GX_FocusControl = edtmenInicioFecCap_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A185menInicioFecCap = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A185menInicioFecCap", context.localUtil.TToC( A185menInicioFecCap, 10, 8, 0, 3, "/", ":", " "));
               }
               else
               {
                  A185menInicioFecCap = context.localUtil.CToT( cgiGet( edtmenInicioFecCap_Internalname));
                  AssignAttri("", false, "A185menInicioFecCap", context.localUtil.TToC( A185menInicioFecCap, 10, 8, 0, 3, "/", ":", " "));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtsgUsrMenId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtsgUsrMenId_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SGUSRMENID");
                  AnyError = 1;
                  GX_FocusControl = edtsgUsrMenId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A59sgUsrMenId = 0;
                  AssignAttri("", false, "A59sgUsrMenId", StringUtil.LTrimStr( (decimal)(A59sgUsrMenId), 6, 0));
               }
               else
               {
                  A59sgUsrMenId = (int)(context.localUtil.CToN( cgiGet( edtsgUsrMenId_Internalname), ",", "."));
                  AssignAttri("", false, "A59sgUsrMenId", StringUtil.LTrimStr( (decimal)(A59sgUsrMenId), 6, 0));
               }
               A187sgUsrMenNom = cgiGet( edtsgUsrMenNom_Internalname);
               AssignAttri("", false, "A187sgUsrMenNom", A187sgUsrMenNom);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"menInicio");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A58menInicioId != Z58menInicioId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("meninicio:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A58menInicioId = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri("", false, "A58menInicioId", StringUtil.LTrimStr( (decimal)(A58menInicioId), 6, 0));
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
                     sMode13 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode13;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound13 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_070( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "MENINICIOID");
                        AnyError = 1;
                        GX_FocusControl = edtmenInicioId_Internalname;
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
                        E11072 ();
                     }
                     else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                     {
                        context.wbHandled = 1;
                        dynload_actions( ) ;
                        /* Execute user event: After Trn */
                        E12072 ();
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
            E12072 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0713( ) ;
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
            DisableAttributes0713( ) ;
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

      protected void CONFIRM_070( )
      {
         BeforeValidate0713( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0713( ) ;
            }
            else
            {
               CheckExtendedTable0713( ) ;
               CloseExtendedTableCursors0713( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption070( )
      {
      }

      protected void E11072( )
      {
         /* Start Routine */
         AV14usuario = AV15sesion.Get("UsuarioId");
         AssignAttri("", false, "AV14usuario", AV14usuario);
         AV16UserLog = (int)(NumberUtil.Val( AV14usuario, "."));
         AssignAttri("", false, "AV16UserLog", StringUtil.LTrimStr( (decimal)(AV16UserLog), 6, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERLOG", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16UserLog), "ZZZZZ9"), context));
         edtmenInicioFecCap_Visible = 0;
         AssignProp("", false, edtmenInicioFecCap_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtmenInicioFecCap_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_int1 = AV19numero;
            new pnumerar(context ).execute(  "MensIni", out  GXt_int1) ;
            AV19numero = (int)(Convert.ToInt32(GXt_int1));
            AssignAttri("", false, "AV19numero", StringUtil.LTrimStr( (decimal)(AV19numero), 6, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vNUMERO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19numero), "ZZZZZ9"), context));
         }
         if ( ! new isauthorized(context).executeUdp(  AV21Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV21Pgmname)));
            context.wjLocDisableFrm = 1;
         }
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "TransactionContext", "ADMINDATA1");
      }

      protected void E12072( )
      {
         /* After Trn Routine */
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            new numerarusur(context ).execute(  "MensIni",  AV19numero) ;
            if ( (0==AV16UserLog) )
            {
               GX_msglist.addItem("Usuario vacio");
            }
            else
            {
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            if ( (0==AV16UserLog) )
            {
               GX_msglist.addItem("Usuario vacio");
            }
            else
            {
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwmeninicio.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0713( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z59sgUsrMenId = T00073_A59sgUsrMenId[0];
               Z185menInicioFecCap = T00073_A185menInicioFecCap[0];
               Z150menInicioDes = T00073_A150menInicioDes[0];
               Z186menInicioFecIni = T00073_A186menInicioFecIni[0];
               Z76menInicioFecFin = T00073_A76menInicioFecFin[0];
               Z77menInicioStat = T00073_A77menInicioStat[0];
               Z187sgUsrMenNom = T00073_A187sgUsrMenNom[0];
            }
            else
            {
               Z59sgUsrMenId = A59sgUsrMenId;
               Z185menInicioFecCap = A185menInicioFecCap;
               Z150menInicioDes = A150menInicioDes;
               Z186menInicioFecIni = A186menInicioFecIni;
               Z76menInicioFecFin = A76menInicioFecFin;
               Z77menInicioStat = A77menInicioStat;
               Z187sgUsrMenNom = A187sgUsrMenNom;
            }
         }
         if ( GX_JID == -11 )
         {
            Z58menInicioId = A58menInicioId;
            Z59sgUsrMenId = A59sgUsrMenId;
            Z185menInicioFecCap = A185menInicioFecCap;
            Z150menInicioDes = A150menInicioDes;
            Z186menInicioFecIni = A186menInicioFecIni;
            Z76menInicioFecFin = A76menInicioFecFin;
            Z77menInicioStat = A77menInicioStat;
            Z187sgUsrMenNom = A187sgUsrMenNom;
         }
      }

      protected void standaloneNotModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            edtmenInicioFecIni_Enabled = 0;
            AssignProp("", false, edtmenInicioFecIni_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtmenInicioFecIni_Enabled), 5, 0), true);
         }
         else
         {
            edtmenInicioFecIni_Enabled = 1;
            AssignProp("", false, edtmenInicioFecIni_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtmenInicioFecIni_Enabled), 5, 0), true);
         }
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7menInicioId) )
         {
            edtmenInicioId_Enabled = 0;
            AssignProp("", false, edtmenInicioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtmenInicioId_Enabled), 5, 0), true);
         }
         else
         {
            edtmenInicioId_Enabled = 1;
            AssignProp("", false, edtmenInicioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtmenInicioId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7menInicioId) )
         {
            edtmenInicioId_Enabled = 0;
            AssignProp("", false, edtmenInicioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtmenInicioId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7menInicioId) )
         {
            A58menInicioId = AV7menInicioId;
            AssignAttri("", false, "A58menInicioId", StringUtil.LTrimStr( (decimal)(A58menInicioId), 6, 0));
         }
         else
         {
            if ( ! (0==AV19numero) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
            {
               A58menInicioId = AV19numero;
               AssignAttri("", false, "A58menInicioId", StringUtil.LTrimStr( (decimal)(A58menInicioId), 6, 0));
            }
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            A185menInicioFecCap = DateTimeUtil.ServerNow( context, pr_default);
            AssignAttri("", false, "A185menInicioFecCap", context.localUtil.TToC( A185menInicioFecCap, 10, 8, 0, 3, "/", ":", " "));
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            A59sgUsrMenId = AV20sgUsrMenId;
            AssignAttri("", false, "A59sgUsrMenId", StringUtil.LTrimStr( (decimal)(A59sgUsrMenId), 6, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            edtmenInicioFecIni_Enabled = 0;
            AssignProp("", false, edtmenInicioFecIni_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtmenInicioFecIni_Enabled), 5, 0), true);
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV21Pgmname = "menInicio";
            AssignAttri("", false, "AV21Pgmname", AV21Pgmname);
         }
      }

      protected void Load0713( )
      {
         /* Using cursor T00074 */
         pr_default.execute(2, new Object[] {A58menInicioId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound13 = 1;
            A59sgUsrMenId = T00074_A59sgUsrMenId[0];
            AssignAttri("", false, "A59sgUsrMenId", StringUtil.LTrimStr( (decimal)(A59sgUsrMenId), 6, 0));
            A185menInicioFecCap = T00074_A185menInicioFecCap[0];
            AssignAttri("", false, "A185menInicioFecCap", context.localUtil.TToC( A185menInicioFecCap, 10, 8, 0, 3, "/", ":", " "));
            A150menInicioDes = T00074_A150menInicioDes[0];
            AssignAttri("", false, "A150menInicioDes", A150menInicioDes);
            A186menInicioFecIni = T00074_A186menInicioFecIni[0];
            AssignAttri("", false, "A186menInicioFecIni", context.localUtil.Format(A186menInicioFecIni, "99/99/9999"));
            A76menInicioFecFin = T00074_A76menInicioFecFin[0];
            AssignAttri("", false, "A76menInicioFecFin", context.localUtil.Format(A76menInicioFecFin, "99/99/9999"));
            A77menInicioStat = T00074_A77menInicioStat[0];
            AssignAttri("", false, "A77menInicioStat", StringUtil.Str( (decimal)(A77menInicioStat), 1, 0));
            A187sgUsrMenNom = T00074_A187sgUsrMenNom[0];
            AssignAttri("", false, "A187sgUsrMenNom", A187sgUsrMenNom);
            ZM0713( -11) ;
         }
         pr_default.close(2);
         OnLoadActions0713( ) ;
      }

      protected void OnLoadActions0713( )
      {
         AV21Pgmname = "menInicio";
         AssignAttri("", false, "AV21Pgmname", AV21Pgmname);
      }

      protected void CheckExtendedTable0713( )
      {
         nIsDirty_13 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV21Pgmname = "menInicio";
         AssignAttri("", false, "AV21Pgmname", AV21Pgmname);
         if ( ! ( (DateTime.MinValue==A186menInicioFecIni) || ( A186menInicioFecIni >= context.localUtil.YMDToD( 1000, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Fecha de inicio de vigencia fuera de rango", "OutOfRange", 1, "MENINICIOFECINI");
            AnyError = 1;
            GX_FocusControl = edtmenInicioFecIni_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A76menInicioFecFin) || ( A76menInicioFecFin >= context.localUtil.YMDToD( 1000, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Fecha de fin de vigencia fuera de rango", "OutOfRange", 1, "MENINICIOFECFIN");
            AnyError = 1;
            GX_FocusControl = edtmenInicioFecFin_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A185menInicioFecCap) || ( A185menInicioFecCap >= context.localUtil.YMDHMSToT( 1000, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha de captura fuera de rango", "OutOfRange", 1, "MENINICIOFECCAP");
            AnyError = 1;
            GX_FocusControl = edtmenInicioFecCap_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0713( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0713( )
      {
         /* Using cursor T00075 */
         pr_default.execute(3, new Object[] {A58menInicioId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00073 */
         pr_default.execute(1, new Object[] {A58menInicioId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0713( 11) ;
            RcdFound13 = 1;
            A58menInicioId = T00073_A58menInicioId[0];
            AssignAttri("", false, "A58menInicioId", StringUtil.LTrimStr( (decimal)(A58menInicioId), 6, 0));
            A59sgUsrMenId = T00073_A59sgUsrMenId[0];
            AssignAttri("", false, "A59sgUsrMenId", StringUtil.LTrimStr( (decimal)(A59sgUsrMenId), 6, 0));
            A185menInicioFecCap = T00073_A185menInicioFecCap[0];
            AssignAttri("", false, "A185menInicioFecCap", context.localUtil.TToC( A185menInicioFecCap, 10, 8, 0, 3, "/", ":", " "));
            A150menInicioDes = T00073_A150menInicioDes[0];
            AssignAttri("", false, "A150menInicioDes", A150menInicioDes);
            A186menInicioFecIni = T00073_A186menInicioFecIni[0];
            AssignAttri("", false, "A186menInicioFecIni", context.localUtil.Format(A186menInicioFecIni, "99/99/9999"));
            A76menInicioFecFin = T00073_A76menInicioFecFin[0];
            AssignAttri("", false, "A76menInicioFecFin", context.localUtil.Format(A76menInicioFecFin, "99/99/9999"));
            A77menInicioStat = T00073_A77menInicioStat[0];
            AssignAttri("", false, "A77menInicioStat", StringUtil.Str( (decimal)(A77menInicioStat), 1, 0));
            A187sgUsrMenNom = T00073_A187sgUsrMenNom[0];
            AssignAttri("", false, "A187sgUsrMenNom", A187sgUsrMenNom);
            Z58menInicioId = A58menInicioId;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0713( ) ;
            if ( AnyError == 1 )
            {
               RcdFound13 = 0;
               InitializeNonKey0713( ) ;
            }
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0713( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0713( ) ;
         if ( RcdFound13 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound13 = 0;
         /* Using cursor T00076 */
         pr_default.execute(4, new Object[] {A58menInicioId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00076_A58menInicioId[0] < A58menInicioId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00076_A58menInicioId[0] > A58menInicioId ) ) )
            {
               A58menInicioId = T00076_A58menInicioId[0];
               AssignAttri("", false, "A58menInicioId", StringUtil.LTrimStr( (decimal)(A58menInicioId), 6, 0));
               RcdFound13 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound13 = 0;
         /* Using cursor T00077 */
         pr_default.execute(5, new Object[] {A58menInicioId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00077_A58menInicioId[0] > A58menInicioId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00077_A58menInicioId[0] < A58menInicioId ) ) )
            {
               A58menInicioId = T00077_A58menInicioId[0];
               AssignAttri("", false, "A58menInicioId", StringUtil.LTrimStr( (decimal)(A58menInicioId), 6, 0));
               RcdFound13 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0713( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtmenInicioId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0713( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound13 == 1 )
            {
               if ( A58menInicioId != Z58menInicioId )
               {
                  A58menInicioId = Z58menInicioId;
                  AssignAttri("", false, "A58menInicioId", StringUtil.LTrimStr( (decimal)(A58menInicioId), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MENINICIOID");
                  AnyError = 1;
                  GX_FocusControl = edtmenInicioId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtmenInicioId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0713( ) ;
                  GX_FocusControl = edtmenInicioId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A58menInicioId != Z58menInicioId )
               {
                  /* Insert record */
                  GX_FocusControl = edtmenInicioId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0713( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MENINICIOID");
                     AnyError = 1;
                     GX_FocusControl = edtmenInicioId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtmenInicioId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0713( ) ;
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
         if ( A58menInicioId != Z58menInicioId )
         {
            A58menInicioId = Z58menInicioId;
            AssignAttri("", false, "A58menInicioId", StringUtil.LTrimStr( (decimal)(A58menInicioId), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MENINICIOID");
            AnyError = 1;
            GX_FocusControl = edtmenInicioId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtmenInicioId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0713( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00072 */
            pr_default.execute(0, new Object[] {A58menInicioId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"menInicio"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z59sgUsrMenId != T00072_A59sgUsrMenId[0] ) || ( Z185menInicioFecCap != T00072_A185menInicioFecCap[0] ) || ( StringUtil.StrCmp(Z150menInicioDes, T00072_A150menInicioDes[0]) != 0 ) || ( Z186menInicioFecIni != T00072_A186menInicioFecIni[0] ) || ( Z76menInicioFecFin != T00072_A76menInicioFecFin[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z77menInicioStat != T00072_A77menInicioStat[0] ) || ( StringUtil.StrCmp(Z187sgUsrMenNom, T00072_A187sgUsrMenNom[0]) != 0 ) )
            {
               if ( Z59sgUsrMenId != T00072_A59sgUsrMenId[0] )
               {
                  GXUtil.WriteLog("meninicio:[seudo value changed for attri]"+"sgUsrMenId");
                  GXUtil.WriteLogRaw("Old: ",Z59sgUsrMenId);
                  GXUtil.WriteLogRaw("Current: ",T00072_A59sgUsrMenId[0]);
               }
               if ( Z185menInicioFecCap != T00072_A185menInicioFecCap[0] )
               {
                  GXUtil.WriteLog("meninicio:[seudo value changed for attri]"+"menInicioFecCap");
                  GXUtil.WriteLogRaw("Old: ",Z185menInicioFecCap);
                  GXUtil.WriteLogRaw("Current: ",T00072_A185menInicioFecCap[0]);
               }
               if ( StringUtil.StrCmp(Z150menInicioDes, T00072_A150menInicioDes[0]) != 0 )
               {
                  GXUtil.WriteLog("meninicio:[seudo value changed for attri]"+"menInicioDes");
                  GXUtil.WriteLogRaw("Old: ",Z150menInicioDes);
                  GXUtil.WriteLogRaw("Current: ",T00072_A150menInicioDes[0]);
               }
               if ( Z186menInicioFecIni != T00072_A186menInicioFecIni[0] )
               {
                  GXUtil.WriteLog("meninicio:[seudo value changed for attri]"+"menInicioFecIni");
                  GXUtil.WriteLogRaw("Old: ",Z186menInicioFecIni);
                  GXUtil.WriteLogRaw("Current: ",T00072_A186menInicioFecIni[0]);
               }
               if ( Z76menInicioFecFin != T00072_A76menInicioFecFin[0] )
               {
                  GXUtil.WriteLog("meninicio:[seudo value changed for attri]"+"menInicioFecFin");
                  GXUtil.WriteLogRaw("Old: ",Z76menInicioFecFin);
                  GXUtil.WriteLogRaw("Current: ",T00072_A76menInicioFecFin[0]);
               }
               if ( Z77menInicioStat != T00072_A77menInicioStat[0] )
               {
                  GXUtil.WriteLog("meninicio:[seudo value changed for attri]"+"menInicioStat");
                  GXUtil.WriteLogRaw("Old: ",Z77menInicioStat);
                  GXUtil.WriteLogRaw("Current: ",T00072_A77menInicioStat[0]);
               }
               if ( StringUtil.StrCmp(Z187sgUsrMenNom, T00072_A187sgUsrMenNom[0]) != 0 )
               {
                  GXUtil.WriteLog("meninicio:[seudo value changed for attri]"+"sgUsrMenNom");
                  GXUtil.WriteLogRaw("Old: ",Z187sgUsrMenNom);
                  GXUtil.WriteLogRaw("Current: ",T00072_A187sgUsrMenNom[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"menInicio"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0713( )
      {
         BeforeValidate0713( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0713( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0713( 0) ;
            CheckOptimisticConcurrency0713( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0713( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0713( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00078 */
                     pr_default.execute(6, new Object[] {A58menInicioId, A59sgUsrMenId, A185menInicioFecCap, A150menInicioDes, A186menInicioFecIni, A76menInicioFecFin, A77menInicioStat, A187sgUsrMenNom});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("menInicio") ;
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
                           ResetCaption070( ) ;
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
               Load0713( ) ;
            }
            EndLevel0713( ) ;
         }
         CloseExtendedTableCursors0713( ) ;
      }

      protected void Update0713( )
      {
         BeforeValidate0713( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0713( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0713( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0713( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0713( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00079 */
                     pr_default.execute(7, new Object[] {A59sgUsrMenId, A185menInicioFecCap, A150menInicioDes, A186menInicioFecIni, A76menInicioFecFin, A77menInicioStat, A187sgUsrMenNom, A58menInicioId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("menInicio") ;
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"menInicio"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0713( ) ;
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
            EndLevel0713( ) ;
         }
         CloseExtendedTableCursors0713( ) ;
      }

      protected void DeferredUpdate0713( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0713( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0713( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0713( ) ;
            AfterConfirm0713( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0713( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000710 */
                  pr_default.execute(8, new Object[] {A58menInicioId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("menInicio") ;
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
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0713( ) ;
         Gx_mode = sMode13;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0713( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV21Pgmname = "menInicio";
            AssignAttri("", false, "AV21Pgmname", AV21Pgmname);
         }
      }

      protected void EndLevel0713( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0713( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("meninicio",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues070( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("meninicio",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0713( )
      {
         /* Scan By routine */
         /* Using cursor T000711 */
         pr_default.execute(9);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound13 = 1;
            A58menInicioId = T000711_A58menInicioId[0];
            AssignAttri("", false, "A58menInicioId", StringUtil.LTrimStr( (decimal)(A58menInicioId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0713( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound13 = 1;
            A58menInicioId = T000711_A58menInicioId[0];
            AssignAttri("", false, "A58menInicioId", StringUtil.LTrimStr( (decimal)(A58menInicioId), 6, 0));
         }
      }

      protected void ScanEnd0713( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0713( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0713( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0713( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0713( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0713( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0713( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0713( )
      {
         edtmenInicioId_Enabled = 0;
         AssignProp("", false, edtmenInicioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtmenInicioId_Enabled), 5, 0), true);
         edtmenInicioDes_Enabled = 0;
         AssignProp("", false, edtmenInicioDes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtmenInicioDes_Enabled), 5, 0), true);
         edtmenInicioFecIni_Enabled = 0;
         AssignProp("", false, edtmenInicioFecIni_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtmenInicioFecIni_Enabled), 5, 0), true);
         edtmenInicioFecFin_Enabled = 0;
         AssignProp("", false, edtmenInicioFecFin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtmenInicioFecFin_Enabled), 5, 0), true);
         cmbmenInicioStat.Enabled = 0;
         AssignProp("", false, cmbmenInicioStat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbmenInicioStat.Enabled), 5, 0), true);
         edtmenInicioFecCap_Enabled = 0;
         AssignProp("", false, edtmenInicioFecCap_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtmenInicioFecCap_Enabled), 5, 0), true);
         edtsgUsrMenId_Enabled = 0;
         AssignProp("", false, edtsgUsrMenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsgUsrMenId_Enabled), 5, 0), true);
         edtsgUsrMenNom_Enabled = 0;
         AssignProp("", false, edtsgUsrMenNom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsgUsrMenNom_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0713( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues070( )
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
         context.SendWebValue( "Tabla de mensajes de inicio") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714343952", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 2036420), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("meninicio.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode("" +AV7menInicioId) + "," + UrlEncode("" +AV20sgUsrMenId)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"menInicio");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("meninicio:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z58menInicioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z58menInicioId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z59sgUsrMenId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z59sgUsrMenId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z185menInicioFecCap", context.localUtil.TToC( Z185menInicioFecCap, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z150menInicioDes", Z150menInicioDes);
         GxWebStd.gx_hidden_field( context, "Z186menInicioFecIni", context.localUtil.DToC( Z186menInicioFecIni, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z76menInicioFecFin", context.localUtil.DToC( Z76menInicioFecFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z77menInicioStat", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z77menInicioStat), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z187sgUsrMenNom", Z187sgUsrMenNom);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vUSERLOG", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16UserLog), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERLOG", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16UserLog), "ZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV10TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV10TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vMENINICIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7menInicioId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMENINICIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7menInicioId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vNUMERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19numero), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vNUMERO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19numero), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vSGUSRMENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20sgUsrMenId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSGUSRMENID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV20sgUsrMenId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV21Pgmname));
      }

      protected void RenderHtmlCloseForm0713( )
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
         return "menInicio" ;
      }

      public override String GetPgmdesc( )
      {
         return "Tabla de mensajes de inicio" ;
      }

      protected void InitializeNonKey0713( )
      {
         A59sgUsrMenId = 0;
         AssignAttri("", false, "A59sgUsrMenId", StringUtil.LTrimStr( (decimal)(A59sgUsrMenId), 6, 0));
         A185menInicioFecCap = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A185menInicioFecCap", context.localUtil.TToC( A185menInicioFecCap, 10, 8, 0, 3, "/", ":", " "));
         A150menInicioDes = "";
         AssignAttri("", false, "A150menInicioDes", A150menInicioDes);
         A186menInicioFecIni = DateTime.MinValue;
         AssignAttri("", false, "A186menInicioFecIni", context.localUtil.Format(A186menInicioFecIni, "99/99/9999"));
         A76menInicioFecFin = DateTime.MinValue;
         AssignAttri("", false, "A76menInicioFecFin", context.localUtil.Format(A76menInicioFecFin, "99/99/9999"));
         A77menInicioStat = 0;
         AssignAttri("", false, "A77menInicioStat", StringUtil.Str( (decimal)(A77menInicioStat), 1, 0));
         A187sgUsrMenNom = "";
         AssignAttri("", false, "A187sgUsrMenNom", A187sgUsrMenNom);
         Z59sgUsrMenId = 0;
         Z185menInicioFecCap = (DateTime)(DateTime.MinValue);
         Z150menInicioDes = "";
         Z186menInicioFecIni = DateTime.MinValue;
         Z76menInicioFecFin = DateTime.MinValue;
         Z77menInicioStat = 0;
         Z187sgUsrMenNom = "";
      }

      protected void InitAll0713( )
      {
         A58menInicioId = 0;
         AssignAttri("", false, "A58menInicioId", StringUtil.LTrimStr( (decimal)(A58menInicioId), 6, 0));
         InitializeNonKey0713( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714343958", true, true);
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
         context.AddJavascriptSource("meninicio.js", "?202262714343958", false, true);
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
         edtmenInicioId_Internalname = "MENINICIOID";
         edtmenInicioDes_Internalname = "MENINICIODES";
         edtmenInicioFecIni_Internalname = "MENINICIOFECINI";
         edtmenInicioFecFin_Internalname = "MENINICIOFECFIN";
         cmbmenInicioStat_Internalname = "MENINICIOSTAT";
         edtmenInicioFecCap_Internalname = "MENINICIOFECCAP";
         edtsgUsrMenId_Internalname = "SGUSRMENID";
         edtsgUsrMenNom_Internalname = "SGUSRMENNOM";
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
         edtsgUsrMenNom_Jsonclick = "";
         edtsgUsrMenNom_Enabled = 1;
         edtsgUsrMenId_Jsonclick = "";
         edtsgUsrMenId_Enabled = 1;
         edtmenInicioFecCap_Jsonclick = "";
         edtmenInicioFecCap_Enabled = 1;
         edtmenInicioFecCap_Visible = 1;
         cmbmenInicioStat_Jsonclick = "";
         cmbmenInicioStat.Enabled = 1;
         edtmenInicioFecFin_Jsonclick = "";
         edtmenInicioFecFin_Enabled = 1;
         edtmenInicioFecIni_Jsonclick = "";
         edtmenInicioFecIni_Enabled = 1;
         edtmenInicioDes_Enabled = 1;
         edtmenInicioId_Jsonclick = "";
         edtmenInicioId_Enabled = 1;
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
         cmbmenInicioStat.Name = "MENINICIOSTAT";
         cmbmenInicioStat.WebTags = "";
         cmbmenInicioStat.addItem("1", "Vigente", 0);
         cmbmenInicioStat.addItem("0", "No Vigente", 0);
         if ( cmbmenInicioStat.ItemCount > 0 )
         {
            A77menInicioStat = (short)(NumberUtil.Val( cmbmenInicioStat.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A77menInicioStat), 1, 0))), "."));
            AssignAttri("", false, "A77menInicioStat", StringUtil.Str( (decimal)(A77menInicioStat), 1, 0));
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7menInicioId',fld:'vMENINICIOID',pic:'ZZZZZ9',hsh:true},{av:'AV20sgUsrMenId',fld:'vSGUSRMENID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV16UserLog',fld:'vUSERLOG',pic:'ZZZZZ9',hsh:true},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7menInicioId',fld:'vMENINICIOID',pic:'ZZZZZ9',hsh:true},{av:'AV19numero',fld:'vNUMERO',pic:'ZZZZZ9',hsh:true},{av:'AV20sgUsrMenId',fld:'vSGUSRMENID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12072',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV19numero',fld:'vNUMERO',pic:'ZZZZZ9',hsh:true},{av:'AV16UserLog',fld:'vUSERLOG',pic:'ZZZZZ9',hsh:true},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_MENINICIOID","{handler:'Valid_Meninicioid',iparms:[]");
         setEventMetadata("VALID_MENINICIOID",",oparms:[]}");
         setEventMetadata("VALID_MENINICIOFECINI","{handler:'Valid_Meniniciofecini',iparms:[]");
         setEventMetadata("VALID_MENINICIOFECINI",",oparms:[]}");
         setEventMetadata("VALID_MENINICIOFECFIN","{handler:'Valid_Meniniciofecfin',iparms:[]");
         setEventMetadata("VALID_MENINICIOFECFIN",",oparms:[]}");
         setEventMetadata("VALID_MENINICIOFECCAP","{handler:'Valid_Meniniciofeccap',iparms:[]");
         setEventMetadata("VALID_MENINICIOFECCAP",",oparms:[]}");
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
         Z185menInicioFecCap = (DateTime)(DateTime.MinValue);
         Z150menInicioDes = "";
         Z186menInicioFecIni = DateTime.MinValue;
         Z76menInicioFecFin = DateTime.MinValue;
         Z187sgUsrMenNom = "";
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
         A150menInicioDes = "";
         A186menInicioFecIni = DateTime.MinValue;
         A76menInicioFecFin = DateTime.MinValue;
         A185menInicioFecCap = (DateTime)(DateTime.MinValue);
         A187sgUsrMenNom = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV21Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode13 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV14usuario = "";
         AV15sesion = context.GetSession();
         AV10TrnContext = new SdtTransactionContext(context);
         AV11WebSession = context.GetSession();
         T00074_A58menInicioId = new int[1] ;
         T00074_A59sgUsrMenId = new int[1] ;
         T00074_A185menInicioFecCap = new DateTime[] {DateTime.MinValue} ;
         T00074_A150menInicioDes = new String[] {""} ;
         T00074_A186menInicioFecIni = new DateTime[] {DateTime.MinValue} ;
         T00074_A76menInicioFecFin = new DateTime[] {DateTime.MinValue} ;
         T00074_A77menInicioStat = new short[1] ;
         T00074_A187sgUsrMenNom = new String[] {""} ;
         T00075_A58menInicioId = new int[1] ;
         T00073_A58menInicioId = new int[1] ;
         T00073_A59sgUsrMenId = new int[1] ;
         T00073_A185menInicioFecCap = new DateTime[] {DateTime.MinValue} ;
         T00073_A150menInicioDes = new String[] {""} ;
         T00073_A186menInicioFecIni = new DateTime[] {DateTime.MinValue} ;
         T00073_A76menInicioFecFin = new DateTime[] {DateTime.MinValue} ;
         T00073_A77menInicioStat = new short[1] ;
         T00073_A187sgUsrMenNom = new String[] {""} ;
         T00076_A58menInicioId = new int[1] ;
         T00077_A58menInicioId = new int[1] ;
         T00072_A58menInicioId = new int[1] ;
         T00072_A59sgUsrMenId = new int[1] ;
         T00072_A185menInicioFecCap = new DateTime[] {DateTime.MinValue} ;
         T00072_A150menInicioDes = new String[] {""} ;
         T00072_A186menInicioFecIni = new DateTime[] {DateTime.MinValue} ;
         T00072_A76menInicioFecFin = new DateTime[] {DateTime.MinValue} ;
         T00072_A77menInicioStat = new short[1] ;
         T00072_A187sgUsrMenNom = new String[] {""} ;
         T000711_A58menInicioId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.meninicio__default(),
            new Object[][] {
                new Object[] {
               T00072_A58menInicioId, T00072_A59sgUsrMenId, T00072_A185menInicioFecCap, T00072_A150menInicioDes, T00072_A186menInicioFecIni, T00072_A76menInicioFecFin, T00072_A77menInicioStat, T00072_A187sgUsrMenNom
               }
               , new Object[] {
               T00073_A58menInicioId, T00073_A59sgUsrMenId, T00073_A185menInicioFecCap, T00073_A150menInicioDes, T00073_A186menInicioFecIni, T00073_A76menInicioFecFin, T00073_A77menInicioStat, T00073_A187sgUsrMenNom
               }
               , new Object[] {
               T00074_A58menInicioId, T00074_A59sgUsrMenId, T00074_A185menInicioFecCap, T00074_A150menInicioDes, T00074_A186menInicioFecIni, T00074_A76menInicioFecFin, T00074_A77menInicioStat, T00074_A187sgUsrMenNom
               }
               , new Object[] {
               T00075_A58menInicioId
               }
               , new Object[] {
               T00076_A58menInicioId
               }
               , new Object[] {
               T00077_A58menInicioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000711_A58menInicioId
               }
            }
         );
         AV21Pgmname = "menInicio";
      }

      private short Z77menInicioStat ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A77menInicioStat ;
      private short RcdFound13 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_13 ;
      private int wcpOAV7menInicioId ;
      private int wcpOAV20sgUsrMenId ;
      private int Z58menInicioId ;
      private int Z59sgUsrMenId ;
      private int AV7menInicioId ;
      private int AV20sgUsrMenId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A58menInicioId ;
      private int edtmenInicioId_Enabled ;
      private int edtmenInicioDes_Enabled ;
      private int edtmenInicioFecIni_Enabled ;
      private int edtmenInicioFecFin_Enabled ;
      private int edtmenInicioFecCap_Visible ;
      private int edtmenInicioFecCap_Enabled ;
      private int A59sgUsrMenId ;
      private int edtsgUsrMenId_Enabled ;
      private int edtsgUsrMenNom_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV19numero ;
      private int AV16UserLog ;
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
      private String edtmenInicioId_Internalname ;
      private String cmbmenInicioStat_Internalname ;
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
      private String edtmenInicioId_Jsonclick ;
      private String edtmenInicioDes_Internalname ;
      private String edtmenInicioFecIni_Internalname ;
      private String edtmenInicioFecIni_Jsonclick ;
      private String edtmenInicioFecFin_Internalname ;
      private String edtmenInicioFecFin_Jsonclick ;
      private String cmbmenInicioStat_Jsonclick ;
      private String edtmenInicioFecCap_Internalname ;
      private String edtmenInicioFecCap_Jsonclick ;
      private String edtsgUsrMenId_Internalname ;
      private String edtsgUsrMenId_Jsonclick ;
      private String edtsgUsrMenNom_Internalname ;
      private String edtsgUsrMenNom_Jsonclick ;
      private String bttBtn_enter_Internalname ;
      private String bttBtn_enter_Jsonclick ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String bttBtn_delete_Internalname ;
      private String bttBtn_delete_Jsonclick ;
      private String AV21Pgmname ;
      private String hsh ;
      private String sMode13 ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String endTrnMsgTxt ;
      private String endTrnMsgCod ;
      private String AV14usuario ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private DateTime Z185menInicioFecCap ;
      private DateTime A185menInicioFecCap ;
      private DateTime Z186menInicioFecIni ;
      private DateTime Z76menInicioFecFin ;
      private DateTime A186menInicioFecIni ;
      private DateTime A76menInicioFecFin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private String Z150menInicioDes ;
      private String Z187sgUsrMenNom ;
      private String A150menInicioDes ;
      private String A187sgUsrMenNom ;
      private IGxSession AV15sesion ;
      private IGxSession AV11WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbmenInicioStat ;
      private IDataStoreProvider pr_default ;
      private int[] T00074_A58menInicioId ;
      private int[] T00074_A59sgUsrMenId ;
      private DateTime[] T00074_A185menInicioFecCap ;
      private String[] T00074_A150menInicioDes ;
      private DateTime[] T00074_A186menInicioFecIni ;
      private DateTime[] T00074_A76menInicioFecFin ;
      private short[] T00074_A77menInicioStat ;
      private String[] T00074_A187sgUsrMenNom ;
      private int[] T00075_A58menInicioId ;
      private int[] T00073_A58menInicioId ;
      private int[] T00073_A59sgUsrMenId ;
      private DateTime[] T00073_A185menInicioFecCap ;
      private String[] T00073_A150menInicioDes ;
      private DateTime[] T00073_A186menInicioFecIni ;
      private DateTime[] T00073_A76menInicioFecFin ;
      private short[] T00073_A77menInicioStat ;
      private String[] T00073_A187sgUsrMenNom ;
      private int[] T00076_A58menInicioId ;
      private int[] T00077_A58menInicioId ;
      private int[] T00072_A58menInicioId ;
      private int[] T00072_A59sgUsrMenId ;
      private DateTime[] T00072_A185menInicioFecCap ;
      private String[] T00072_A150menInicioDes ;
      private DateTime[] T00072_A186menInicioFecIni ;
      private DateTime[] T00072_A76menInicioFecFin ;
      private short[] T00072_A77menInicioStat ;
      private String[] T00072_A187sgUsrMenNom ;
      private int[] T000711_A58menInicioId ;
      private SdtTransactionContext AV10TrnContext ;
   }

   public class meninicio__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT00074 ;
          prmT00074 = new Object[] {
          new Object[] {"menInicioId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT00075 ;
          prmT00075 = new Object[] {
          new Object[] {"menInicioId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT00073 ;
          prmT00073 = new Object[] {
          new Object[] {"menInicioId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT00076 ;
          prmT00076 = new Object[] {
          new Object[] {"menInicioId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT00077 ;
          prmT00077 = new Object[] {
          new Object[] {"menInicioId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT00072 ;
          prmT00072 = new Object[] {
          new Object[] {"menInicioId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT00078 ;
          prmT00078 = new Object[] {
          new Object[] {"menInicioId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"sgUsrMenId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"menInicioFecCap",System.Data.DbType.DateTime,10,8} ,
          new Object[] {"menInicioDes",System.Data.DbType.String,255,0} ,
          new Object[] {"menInicioFecIni",System.Data.DbType.Date,8,0} ,
          new Object[] {"menInicioFecFin",System.Data.DbType.Date,8,0} ,
          new Object[] {"menInicioStat",System.Data.DbType.Byte,1,0} ,
          new Object[] {"sgUsrMenNom",System.Data.DbType.String,20,0}
          } ;
          Object[] prmT00079 ;
          prmT00079 = new Object[] {
          new Object[] {"sgUsrMenId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"menInicioFecCap",System.Data.DbType.DateTime,10,8} ,
          new Object[] {"menInicioDes",System.Data.DbType.String,255,0} ,
          new Object[] {"menInicioFecIni",System.Data.DbType.Date,8,0} ,
          new Object[] {"menInicioFecFin",System.Data.DbType.Date,8,0} ,
          new Object[] {"menInicioStat",System.Data.DbType.Byte,1,0} ,
          new Object[] {"sgUsrMenNom",System.Data.DbType.String,20,0} ,
          new Object[] {"menInicioId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000710 ;
          prmT000710 = new Object[] {
          new Object[] {"menInicioId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000711 ;
          prmT000711 = new Object[] {
          } ;
          def= new CursorDef[] {
              new CursorDef("T00072", "SELECT `menInicioId`, `sgUsrMenId`, `menInicioFecCap`, `menInicioDes`, `menInicioFecIni`, `menInicioFecFin`, `menInicioStat`, `sgUsrMenNom` FROM `menInicio` WHERE `menInicioId` = ?  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT00072,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00073", "SELECT `menInicioId`, `sgUsrMenId`, `menInicioFecCap`, `menInicioDes`, `menInicioFecIni`, `menInicioFecFin`, `menInicioStat`, `sgUsrMenNom` FROM `menInicio` WHERE `menInicioId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00073,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00074", "SELECT TM1.`menInicioId`, TM1.`sgUsrMenId`, TM1.`menInicioFecCap`, TM1.`menInicioDes`, TM1.`menInicioFecIni`, TM1.`menInicioFecFin`, TM1.`menInicioStat`, TM1.`sgUsrMenNom` FROM `menInicio` TM1 WHERE TM1.`menInicioId` = ? ORDER BY TM1.`menInicioId` ",true, GxErrorMask.GX_NOMASK, false, this,prmT00074,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00075", "SELECT `menInicioId` FROM `menInicio` WHERE `menInicioId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00075,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00076", "SELECT `menInicioId` FROM `menInicio` WHERE ( `menInicioId` > ?) ORDER BY `menInicioId`  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT00076,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00077", "SELECT `menInicioId` FROM `menInicio` WHERE ( `menInicioId` < ?) ORDER BY `menInicioId` DESC  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT00077,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00078", "INSERT INTO `menInicio`(`menInicioId`, `sgUsrMenId`, `menInicioFecCap`, `menInicioDes`, `menInicioFecIni`, `menInicioFecFin`, `menInicioStat`, `sgUsrMenNom`) VALUES(?, ?, ?, ?, ?, ?, ?, ?)", GxErrorMask.GX_NOMASK,prmT00078)
             ,new CursorDef("T00079", "UPDATE `menInicio` SET `sgUsrMenId`=?, `menInicioFecCap`=?, `menInicioDes`=?, `menInicioFecIni`=?, `menInicioFecFin`=?, `menInicioStat`=?, `sgUsrMenNom`=?  WHERE `menInicioId` = ?", GxErrorMask.GX_NOMASK,prmT00079)
             ,new CursorDef("T000710", "DELETE FROM `menInicio`  WHERE `menInicioId` = ?", GxErrorMask.GX_NOMASK,prmT000710)
             ,new CursorDef("T000711", "SELECT `menInicioId` FROM `menInicio` ORDER BY `menInicioId` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000711,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3) ;
                ((String[]) buf[3])[0] = rslt.getVarchar(4) ;
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5) ;
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6) ;
                ((short[]) buf[6])[0] = rslt.getShort(7) ;
                ((String[]) buf[7])[0] = rslt.getVarchar(8) ;
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3) ;
                ((String[]) buf[3])[0] = rslt.getVarchar(4) ;
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5) ;
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6) ;
                ((short[]) buf[6])[0] = rslt.getShort(7) ;
                ((String[]) buf[7])[0] = rslt.getVarchar(8) ;
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3) ;
                ((String[]) buf[3])[0] = rslt.getVarchar(4) ;
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5) ;
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6) ;
                ((short[]) buf[6])[0] = rslt.getShort(7) ;
                ((String[]) buf[7])[0] = rslt.getVarchar(8) ;
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
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameterDatetime(3, (DateTime)parms[2]);
                stmt.SetParameter(4, (String)parms[3]);
                stmt.SetParameter(5, (DateTime)parms[4]);
                stmt.SetParameter(6, (DateTime)parms[5]);
                stmt.SetParameter(7, (short)parms[6]);
                stmt.SetParameter(8, (String)parms[7]);
                return;
             case 7 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameterDatetime(2, (DateTime)parms[1]);
                stmt.SetParameter(3, (String)parms[2]);
                stmt.SetParameter(4, (DateTime)parms[3]);
                stmt.SetParameter(5, (DateTime)parms[4]);
                stmt.SetParameter(6, (short)parms[5]);
                stmt.SetParameter(7, (String)parms[6]);
                stmt.SetParameter(8, (int)parms[7]);
                return;
             case 8 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

}
