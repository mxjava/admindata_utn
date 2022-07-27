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
   public class intentos : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A11UsuariosId = (int)(NumberUtil.Val( GetNextPar( ), "."));
            AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A11UsuariosId) ;
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
            Form.Meta.addItem("description", "Intentos", 0) ;
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

      public intentos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public intentos( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Intentos", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_Intentos.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Intentos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Intentos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Intentos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Intentos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Intentos.htm");
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
         GxWebStd.gx_label_element( context, edtUsuariosId_Internalname, "ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuariosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")), ((edtUsuariosId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9")) : context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosId_Enabled, 0, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "NumId", "right", false, "", "HLP_Intentos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFechaIntento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFechaIntento_Internalname, "del Intento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtFechaIntento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFechaIntento_Internalname, context.localUtil.Format(A30FechaIntento, "99/99/99"), context.localUtil.Format( A30FechaIntento, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFechaIntento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFechaIntento_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Intentos.htm");
         GxWebStd.gx_bitmap( context, edtFechaIntento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFechaIntento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Intentos.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtContador_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtContador_Internalname, "los Intentos", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContador_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A72Contador), 1, 0, ",", "")), ((edtContador_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A72Contador), "9")) : context.localUtil.Format( (decimal)(A72Contador), "9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContador_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtContador_Enabled, 0, "number", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Intentos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIntentosHoraBloqueo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIntentosHoraBloqueo_Internalname, "Hora Bloqueo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtIntentosHoraBloqueo_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtIntentosHoraBloqueo_Internalname, context.localUtil.TToC( A74IntentosHoraBloqueo, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A74IntentosHoraBloqueo, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIntentosHoraBloqueo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIntentosHoraBloqueo_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Intentos.htm");
         GxWebStd.gx_bitmap( context, edtIntentosHoraBloqueo_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtIntentosHoraBloqueo_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Intentos.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Intentos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Intentos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Intentos.htm");
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
            Z30FechaIntento = context.localUtil.CToD( cgiGet( "Z30FechaIntento"), 0);
            Z72Contador = (short)(context.localUtil.CToN( cgiGet( "Z72Contador"), ",", "."));
            Z74IntentosHoraBloqueo = context.localUtil.CToT( cgiGet( "Z74IntentosHoraBloqueo"), 0);
            n74IntentosHoraBloqueo = ((DateTime.MinValue==A74IntentosHoraBloqueo) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtUsuariosId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuariosId_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIOSID");
               AnyError = 1;
               GX_FocusControl = edtUsuariosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A11UsuariosId = 0;
               AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
            }
            else
            {
               A11UsuariosId = (int)(context.localUtil.CToN( cgiGet( edtUsuariosId_Internalname), ",", "."));
               AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtFechaIntento_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha del Intento"}), 1, "FECHAINTENTO");
               AnyError = 1;
               GX_FocusControl = edtFechaIntento_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A30FechaIntento = DateTime.MinValue;
               AssignAttri("", false, "A30FechaIntento", context.localUtil.Format(A30FechaIntento, "99/99/99"));
            }
            else
            {
               A30FechaIntento = context.localUtil.CToD( cgiGet( edtFechaIntento_Internalname), 2);
               AssignAttri("", false, "A30FechaIntento", context.localUtil.Format(A30FechaIntento, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtContador_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtContador_Internalname), ",", ".") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONTADOR");
               AnyError = 1;
               GX_FocusControl = edtContador_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A72Contador = 0;
               AssignAttri("", false, "A72Contador", StringUtil.Str( (decimal)(A72Contador), 1, 0));
            }
            else
            {
               A72Contador = (short)(context.localUtil.CToN( cgiGet( edtContador_Internalname), ",", "."));
               AssignAttri("", false, "A72Contador", StringUtil.Str( (decimal)(A72Contador), 1, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtIntentosHoraBloqueo_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Intentos Hora Bloqueo"}), 1, "INTENTOSHORABLOQUEO");
               AnyError = 1;
               GX_FocusControl = edtIntentosHoraBloqueo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A74IntentosHoraBloqueo = (DateTime)(DateTime.MinValue);
               n74IntentosHoraBloqueo = false;
               AssignAttri("", false, "A74IntentosHoraBloqueo", context.localUtil.TToC( A74IntentosHoraBloqueo, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A74IntentosHoraBloqueo = context.localUtil.CToT( cgiGet( edtIntentosHoraBloqueo_Internalname));
               n74IntentosHoraBloqueo = false;
               AssignAttri("", false, "A74IntentosHoraBloqueo", context.localUtil.TToC( A74IntentosHoraBloqueo, 8, 5, 0, 3, "/", ":", " "));
            }
            n74IntentosHoraBloqueo = ((DateTime.MinValue==A74IntentosHoraBloqueo) ? true : false);
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
               A11UsuariosId = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
               A30FechaIntento = context.localUtil.ParseDateParm( GetNextPar( ));
               AssignAttri("", false, "A30FechaIntento", context.localUtil.Format(A30FechaIntento, "99/99/99"));
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
               InitAll0620( ) ;
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
         DisableAttributes0620( ) ;
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

      protected void ResetCaption060( )
      {
      }

      protected void ZM0620( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z72Contador = T00063_A72Contador[0];
               Z74IntentosHoraBloqueo = T00063_A74IntentosHoraBloqueo[0];
            }
            else
            {
               Z72Contador = A72Contador;
               Z74IntentosHoraBloqueo = A74IntentosHoraBloqueo;
            }
         }
         if ( GX_JID == -3 )
         {
            Z30FechaIntento = A30FechaIntento;
            Z72Contador = A72Contador;
            Z74IntentosHoraBloqueo = A74IntentosHoraBloqueo;
            Z11UsuariosId = A11UsuariosId;
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

      protected void Load0620( )
      {
         /* Using cursor T00065 */
         pr_default.execute(3, new Object[] {A11UsuariosId, A30FechaIntento});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound20 = 1;
            A72Contador = T00065_A72Contador[0];
            AssignAttri("", false, "A72Contador", StringUtil.Str( (decimal)(A72Contador), 1, 0));
            A74IntentosHoraBloqueo = T00065_A74IntentosHoraBloqueo[0];
            n74IntentosHoraBloqueo = T00065_n74IntentosHoraBloqueo[0];
            AssignAttri("", false, "A74IntentosHoraBloqueo", context.localUtil.TToC( A74IntentosHoraBloqueo, 8, 5, 0, 3, "/", ":", " "));
            ZM0620( -3) ;
         }
         pr_default.close(3);
         OnLoadActions0620( ) ;
      }

      protected void OnLoadActions0620( )
      {
      }

      protected void CheckExtendedTable0620( )
      {
         nIsDirty_20 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00064 */
         pr_default.execute(2, new Object[] {A11UsuariosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Tabla de usuarios'.", "ForeignKeyNotFound", 1, "USUARIOSID");
            AnyError = 1;
            GX_FocusControl = edtUsuariosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A30FechaIntento) || ( A30FechaIntento >= context.localUtil.YMDToD( 1000, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Fecha del Intento fuera de rango", "OutOfRange", 1, "FECHAINTENTO");
            AnyError = 1;
            GX_FocusControl = edtFechaIntento_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A74IntentosHoraBloqueo) || ( A74IntentosHoraBloqueo >= context.localUtil.YMDHMSToT( 1000, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Intentos Hora Bloqueo fuera de rango", "OutOfRange", 1, "INTENTOSHORABLOQUEO");
            AnyError = 1;
            GX_FocusControl = edtIntentosHoraBloqueo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0620( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( int A11UsuariosId )
      {
         /* Using cursor T00066 */
         pr_default.execute(4, new Object[] {A11UsuariosId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Tabla de usuarios'.", "ForeignKeyNotFound", 1, "USUARIOSID");
            AnyError = 1;
            GX_FocusControl = edtUsuariosId_Internalname;
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

      protected void GetKey0620( )
      {
         /* Using cursor T00067 */
         pr_default.execute(5, new Object[] {A11UsuariosId, A30FechaIntento});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound20 = 1;
         }
         else
         {
            RcdFound20 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00063 */
         pr_default.execute(1, new Object[] {A11UsuariosId, A30FechaIntento});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0620( 3) ;
            RcdFound20 = 1;
            A30FechaIntento = T00063_A30FechaIntento[0];
            AssignAttri("", false, "A30FechaIntento", context.localUtil.Format(A30FechaIntento, "99/99/99"));
            A72Contador = T00063_A72Contador[0];
            AssignAttri("", false, "A72Contador", StringUtil.Str( (decimal)(A72Contador), 1, 0));
            A74IntentosHoraBloqueo = T00063_A74IntentosHoraBloqueo[0];
            n74IntentosHoraBloqueo = T00063_n74IntentosHoraBloqueo[0];
            AssignAttri("", false, "A74IntentosHoraBloqueo", context.localUtil.TToC( A74IntentosHoraBloqueo, 8, 5, 0, 3, "/", ":", " "));
            A11UsuariosId = T00063_A11UsuariosId[0];
            AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
            Z11UsuariosId = A11UsuariosId;
            Z30FechaIntento = A30FechaIntento;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0620( ) ;
            if ( AnyError == 1 )
            {
               RcdFound20 = 0;
               InitializeNonKey0620( ) ;
            }
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound20 = 0;
            InitializeNonKey0620( ) ;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0620( ) ;
         if ( RcdFound20 == 0 )
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
         RcdFound20 = 0;
         /* Using cursor T00068 */
         pr_default.execute(6, new Object[] {A11UsuariosId, A11UsuariosId, A30FechaIntento});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00068_A11UsuariosId[0] < A11UsuariosId ) || ( T00068_A11UsuariosId[0] == A11UsuariosId ) && ( T00068_A30FechaIntento[0] < A30FechaIntento ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00068_A11UsuariosId[0] > A11UsuariosId ) || ( T00068_A11UsuariosId[0] == A11UsuariosId ) && ( T00068_A30FechaIntento[0] > A30FechaIntento ) ) )
            {
               A11UsuariosId = T00068_A11UsuariosId[0];
               AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
               A30FechaIntento = T00068_A30FechaIntento[0];
               AssignAttri("", false, "A30FechaIntento", context.localUtil.Format(A30FechaIntento, "99/99/99"));
               RcdFound20 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound20 = 0;
         /* Using cursor T00069 */
         pr_default.execute(7, new Object[] {A11UsuariosId, A11UsuariosId, A30FechaIntento});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00069_A11UsuariosId[0] > A11UsuariosId ) || ( T00069_A11UsuariosId[0] == A11UsuariosId ) && ( T00069_A30FechaIntento[0] > A30FechaIntento ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00069_A11UsuariosId[0] < A11UsuariosId ) || ( T00069_A11UsuariosId[0] == A11UsuariosId ) && ( T00069_A30FechaIntento[0] < A30FechaIntento ) ) )
            {
               A11UsuariosId = T00069_A11UsuariosId[0];
               AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
               A30FechaIntento = T00069_A30FechaIntento[0];
               AssignAttri("", false, "A30FechaIntento", context.localUtil.Format(A30FechaIntento, "99/99/99"));
               RcdFound20 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0620( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUsuariosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0620( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound20 == 1 )
            {
               if ( ( A11UsuariosId != Z11UsuariosId ) || ( A30FechaIntento != Z30FechaIntento ) )
               {
                  A11UsuariosId = Z11UsuariosId;
                  AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
                  A30FechaIntento = Z30FechaIntento;
                  AssignAttri("", false, "A30FechaIntento", context.localUtil.Format(A30FechaIntento, "99/99/99"));
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
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0620( ) ;
                  GX_FocusControl = edtUsuariosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A11UsuariosId != Z11UsuariosId ) || ( A30FechaIntento != Z30FechaIntento ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtUsuariosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0620( ) ;
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
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtUsuariosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0620( ) ;
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
         if ( ( A11UsuariosId != Z11UsuariosId ) || ( A30FechaIntento != Z30FechaIntento ) )
         {
            A11UsuariosId = Z11UsuariosId;
            AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
            A30FechaIntento = Z30FechaIntento;
            AssignAttri("", false, "A30FechaIntento", context.localUtil.Format(A30FechaIntento, "99/99/99"));
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
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "USUARIOSID");
            AnyError = 1;
            GX_FocusControl = edtUsuariosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtContador_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0620( ) ;
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtContador_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0620( ) ;
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
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtContador_Internalname;
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
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtContador_Internalname;
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
         ScanStart0620( ) ;
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound20 != 0 )
            {
               ScanNext0620( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtContador_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0620( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0620( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00062 */
            pr_default.execute(0, new Object[] {A11UsuariosId, A30FechaIntento});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Intentos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z72Contador != T00062_A72Contador[0] ) || ( Z74IntentosHoraBloqueo != T00062_A74IntentosHoraBloqueo[0] ) )
            {
               if ( Z72Contador != T00062_A72Contador[0] )
               {
                  GXUtil.WriteLog("intentos:[seudo value changed for attri]"+"Contador");
                  GXUtil.WriteLogRaw("Old: ",Z72Contador);
                  GXUtil.WriteLogRaw("Current: ",T00062_A72Contador[0]);
               }
               if ( Z74IntentosHoraBloqueo != T00062_A74IntentosHoraBloqueo[0] )
               {
                  GXUtil.WriteLog("intentos:[seudo value changed for attri]"+"IntentosHoraBloqueo");
                  GXUtil.WriteLogRaw("Old: ",Z74IntentosHoraBloqueo);
                  GXUtil.WriteLogRaw("Current: ",T00062_A74IntentosHoraBloqueo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Intentos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0620( )
      {
         BeforeValidate0620( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0620( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0620( 0) ;
            CheckOptimisticConcurrency0620( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0620( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0620( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000610 */
                     pr_default.execute(8, new Object[] {A30FechaIntento, A72Contador, n74IntentosHoraBloqueo, A74IntentosHoraBloqueo, A11UsuariosId});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("Intentos") ;
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
                           ResetCaption060( ) ;
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
               Load0620( ) ;
            }
            EndLevel0620( ) ;
         }
         CloseExtendedTableCursors0620( ) ;
      }

      protected void Update0620( )
      {
         BeforeValidate0620( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0620( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0620( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0620( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0620( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000611 */
                     pr_default.execute(9, new Object[] {A72Contador, n74IntentosHoraBloqueo, A74IntentosHoraBloqueo, A11UsuariosId, A30FechaIntento});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Intentos") ;
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Intentos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0620( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption060( ) ;
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
            EndLevel0620( ) ;
         }
         CloseExtendedTableCursors0620( ) ;
      }

      protected void DeferredUpdate0620( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0620( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0620( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0620( ) ;
            AfterConfirm0620( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0620( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000612 */
                  pr_default.execute(10, new Object[] {A11UsuariosId, A30FechaIntento});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("Intentos") ;
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound20 == 0 )
                        {
                           InitAll0620( ) ;
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
                        ResetCaption060( ) ;
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
         sMode20 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0620( ) ;
         Gx_mode = sMode20;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0620( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0620( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0620( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("intentos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues060( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("intentos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0620( )
      {
         /* Using cursor T000613 */
         pr_default.execute(11);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound20 = 1;
            A11UsuariosId = T000613_A11UsuariosId[0];
            AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
            A30FechaIntento = T000613_A30FechaIntento[0];
            AssignAttri("", false, "A30FechaIntento", context.localUtil.Format(A30FechaIntento, "99/99/99"));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0620( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound20 = 1;
            A11UsuariosId = T000613_A11UsuariosId[0];
            AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
            A30FechaIntento = T000613_A30FechaIntento[0];
            AssignAttri("", false, "A30FechaIntento", context.localUtil.Format(A30FechaIntento, "99/99/99"));
         }
      }

      protected void ScanEnd0620( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0620( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0620( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0620( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0620( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0620( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0620( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0620( )
      {
         edtUsuariosId_Enabled = 0;
         AssignProp("", false, edtUsuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosId_Enabled), 5, 0), true);
         edtFechaIntento_Enabled = 0;
         AssignProp("", false, edtFechaIntento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFechaIntento_Enabled), 5, 0), true);
         edtContador_Enabled = 0;
         AssignProp("", false, edtContador_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContador_Enabled), 5, 0), true);
         edtIntentosHoraBloqueo_Enabled = 0;
         AssignProp("", false, edtIntentosHoraBloqueo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIntentosHoraBloqueo_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0620( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues060( )
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
         context.AddJavascriptSource("gxcfg.js", "?202262714343788", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("intentos.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z11UsuariosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11UsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z30FechaIntento", context.localUtil.DToC( Z30FechaIntento, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z72Contador", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z72Contador), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z74IntentosHoraBloqueo", context.localUtil.TToC( Z74IntentosHoraBloqueo, 10, 8, 0, 0, "/", ":", " "));
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
         return formatLink("intentos.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "Intentos" ;
      }

      public override String GetPgmdesc( )
      {
         return "Intentos" ;
      }

      protected void InitializeNonKey0620( )
      {
         A72Contador = 0;
         AssignAttri("", false, "A72Contador", StringUtil.Str( (decimal)(A72Contador), 1, 0));
         A74IntentosHoraBloqueo = (DateTime)(DateTime.MinValue);
         n74IntentosHoraBloqueo = false;
         AssignAttri("", false, "A74IntentosHoraBloqueo", context.localUtil.TToC( A74IntentosHoraBloqueo, 8, 5, 0, 3, "/", ":", " "));
         n74IntentosHoraBloqueo = ((DateTime.MinValue==A74IntentosHoraBloqueo) ? true : false);
         Z72Contador = 0;
         Z74IntentosHoraBloqueo = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll0620( )
      {
         A11UsuariosId = 0;
         AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
         A30FechaIntento = DateTime.MinValue;
         AssignAttri("", false, "A30FechaIntento", context.localUtil.Format(A30FechaIntento, "99/99/99"));
         InitializeNonKey0620( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714343791", true, true);
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
         context.AddJavascriptSource("intentos.js", "?202262714343791", false, true);
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
         edtFechaIntento_Internalname = "FECHAINTENTO";
         edtContador_Internalname = "CONTADOR";
         edtIntentosHoraBloqueo_Internalname = "INTENTOSHORABLOQUEO";
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
         Form.Caption = "Intentos";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtIntentosHoraBloqueo_Jsonclick = "";
         edtIntentosHoraBloqueo_Enabled = 1;
         edtContador_Jsonclick = "";
         edtContador_Enabled = 1;
         edtFechaIntento_Jsonclick = "";
         edtFechaIntento_Enabled = 1;
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

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T000614 */
         pr_default.execute(12, new Object[] {A11UsuariosId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Tabla de usuarios'.", "ForeignKeyNotFound", 1, "USUARIOSID");
            AnyError = 1;
            GX_FocusControl = edtUsuariosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(12);
         GX_FocusControl = edtContador_Internalname;
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

      public void Valid_Usuariosid( )
      {
         /* Using cursor T000614 */
         pr_default.execute(12, new Object[] {A11UsuariosId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Tabla de usuarios'.", "ForeignKeyNotFound", 1, "USUARIOSID");
            AnyError = 1;
            GX_FocusControl = edtUsuariosId_Internalname;
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Fechaintento( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         if ( ! ( (DateTime.MinValue==A30FechaIntento) || ( A30FechaIntento >= context.localUtil.YMDToD( 1000, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Fecha del Intento fuera de rango", "OutOfRange", 1, "FECHAINTENTO");
            AnyError = 1;
            GX_FocusControl = edtFechaIntento_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A72Contador", StringUtil.LTrim( StringUtil.NToC( (decimal)(A72Contador), 1, 0, ".", "")));
         AssignAttri("", false, "A74IntentosHoraBloqueo", context.localUtil.TToC( A74IntentosHoraBloqueo, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z11UsuariosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11UsuariosId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z30FechaIntento", context.localUtil.Format(Z30FechaIntento, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z72Contador", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z72Contador), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z74IntentosHoraBloqueo", context.localUtil.TToC( Z74IntentosHoraBloqueo, 10, 8, 0, 3, "/", ":", " "));
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
         setEventMetadata("VALID_USUARIOSID","{handler:'Valid_Usuariosid',iparms:[{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_USUARIOSID",",oparms:[]}");
         setEventMetadata("VALID_FECHAINTENTO","{handler:'Valid_Fechaintento',iparms:[{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A30FechaIntento',fld:'FECHAINTENTO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_FECHAINTENTO",",oparms:[{av:'A72Contador',fld:'CONTADOR',pic:'9'},{av:'A74IntentosHoraBloqueo',fld:'INTENTOSHORABLOQUEO',pic:'99/99/99 99:99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z11UsuariosId'},{av:'Z30FechaIntento'},{av:'Z72Contador'},{av:'Z74IntentosHoraBloqueo'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_INTENTOSHORABLOQUEO","{handler:'Valid_Intentoshorabloqueo',iparms:[]");
         setEventMetadata("VALID_INTENTOSHORABLOQUEO",",oparms:[]}");
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
         Z30FechaIntento = DateTime.MinValue;
         Z74IntentosHoraBloqueo = (DateTime)(DateTime.MinValue);
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
         A30FechaIntento = DateTime.MinValue;
         A74IntentosHoraBloqueo = (DateTime)(DateTime.MinValue);
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
         T00065_A30FechaIntento = new DateTime[] {DateTime.MinValue} ;
         T00065_A72Contador = new short[1] ;
         T00065_A74IntentosHoraBloqueo = new DateTime[] {DateTime.MinValue} ;
         T00065_n74IntentosHoraBloqueo = new bool[] {false} ;
         T00065_A11UsuariosId = new int[1] ;
         T00064_A11UsuariosId = new int[1] ;
         T00066_A11UsuariosId = new int[1] ;
         T00067_A11UsuariosId = new int[1] ;
         T00067_A30FechaIntento = new DateTime[] {DateTime.MinValue} ;
         T00063_A30FechaIntento = new DateTime[] {DateTime.MinValue} ;
         T00063_A72Contador = new short[1] ;
         T00063_A74IntentosHoraBloqueo = new DateTime[] {DateTime.MinValue} ;
         T00063_n74IntentosHoraBloqueo = new bool[] {false} ;
         T00063_A11UsuariosId = new int[1] ;
         sMode20 = "";
         T00068_A11UsuariosId = new int[1] ;
         T00068_A30FechaIntento = new DateTime[] {DateTime.MinValue} ;
         T00069_A11UsuariosId = new int[1] ;
         T00069_A30FechaIntento = new DateTime[] {DateTime.MinValue} ;
         T00062_A30FechaIntento = new DateTime[] {DateTime.MinValue} ;
         T00062_A72Contador = new short[1] ;
         T00062_A74IntentosHoraBloqueo = new DateTime[] {DateTime.MinValue} ;
         T00062_n74IntentosHoraBloqueo = new bool[] {false} ;
         T00062_A11UsuariosId = new int[1] ;
         T000613_A11UsuariosId = new int[1] ;
         T000613_A30FechaIntento = new DateTime[] {DateTime.MinValue} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000614_A11UsuariosId = new int[1] ;
         ZZ30FechaIntento = DateTime.MinValue;
         ZZ74IntentosHoraBloqueo = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.intentos__default(),
            new Object[][] {
                new Object[] {
               T00062_A30FechaIntento, T00062_A72Contador, T00062_A74IntentosHoraBloqueo, T00062_n74IntentosHoraBloqueo, T00062_A11UsuariosId
               }
               , new Object[] {
               T00063_A30FechaIntento, T00063_A72Contador, T00063_A74IntentosHoraBloqueo, T00063_n74IntentosHoraBloqueo, T00063_A11UsuariosId
               }
               , new Object[] {
               T00064_A11UsuariosId
               }
               , new Object[] {
               T00065_A30FechaIntento, T00065_A72Contador, T00065_A74IntentosHoraBloqueo, T00065_n74IntentosHoraBloqueo, T00065_A11UsuariosId
               }
               , new Object[] {
               T00066_A11UsuariosId
               }
               , new Object[] {
               T00067_A11UsuariosId, T00067_A30FechaIntento
               }
               , new Object[] {
               T00068_A11UsuariosId, T00068_A30FechaIntento
               }
               , new Object[] {
               T00069_A11UsuariosId, T00069_A30FechaIntento
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000613_A11UsuariosId, T000613_A30FechaIntento
               }
               , new Object[] {
               T000614_A11UsuariosId
               }
            }
         );
      }

      private short Z72Contador ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A72Contador ;
      private short GX_JID ;
      private short RcdFound20 ;
      private short nIsDirty_20 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ72Contador ;
      private int Z11UsuariosId ;
      private int A11UsuariosId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtUsuariosId_Enabled ;
      private int edtFechaIntento_Enabled ;
      private int edtContador_Enabled ;
      private int edtIntentosHoraBloqueo_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ11UsuariosId ;
      private String sPrefix ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
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
      private String edtFechaIntento_Internalname ;
      private String edtFechaIntento_Jsonclick ;
      private String edtContador_Internalname ;
      private String edtContador_Jsonclick ;
      private String edtIntentosHoraBloqueo_Internalname ;
      private String edtIntentosHoraBloqueo_Jsonclick ;
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
      private String sMode20 ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private DateTime Z74IntentosHoraBloqueo ;
      private DateTime A74IntentosHoraBloqueo ;
      private DateTime ZZ74IntentosHoraBloqueo ;
      private DateTime Z30FechaIntento ;
      private DateTime A30FechaIntento ;
      private DateTime ZZ30FechaIntento ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n74IntentosHoraBloqueo ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T00065_A30FechaIntento ;
      private short[] T00065_A72Contador ;
      private DateTime[] T00065_A74IntentosHoraBloqueo ;
      private bool[] T00065_n74IntentosHoraBloqueo ;
      private int[] T00065_A11UsuariosId ;
      private int[] T00064_A11UsuariosId ;
      private int[] T00066_A11UsuariosId ;
      private int[] T00067_A11UsuariosId ;
      private DateTime[] T00067_A30FechaIntento ;
      private DateTime[] T00063_A30FechaIntento ;
      private short[] T00063_A72Contador ;
      private DateTime[] T00063_A74IntentosHoraBloqueo ;
      private bool[] T00063_n74IntentosHoraBloqueo ;
      private int[] T00063_A11UsuariosId ;
      private int[] T00068_A11UsuariosId ;
      private DateTime[] T00068_A30FechaIntento ;
      private int[] T00069_A11UsuariosId ;
      private DateTime[] T00069_A30FechaIntento ;
      private DateTime[] T00062_A30FechaIntento ;
      private short[] T00062_A72Contador ;
      private DateTime[] T00062_A74IntentosHoraBloqueo ;
      private bool[] T00062_n74IntentosHoraBloqueo ;
      private int[] T00062_A11UsuariosId ;
      private int[] T000613_A11UsuariosId ;
      private DateTime[] T000613_A30FechaIntento ;
      private int[] T000614_A11UsuariosId ;
      private GXWebForm Form ;
   }

   public class intentos__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00065 ;
          prmT00065 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"FechaIntento",System.Data.DbType.Date,8,0}
          } ;
          Object[] prmT00064 ;
          prmT00064 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT00066 ;
          prmT00066 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT00067 ;
          prmT00067 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"FechaIntento",System.Data.DbType.Date,8,0}
          } ;
          Object[] prmT00063 ;
          prmT00063 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"FechaIntento",System.Data.DbType.Date,8,0}
          } ;
          Object[] prmT00068 ;
          prmT00068 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"FechaIntento",System.Data.DbType.Date,8,0}
          } ;
          Object[] prmT00069 ;
          prmT00069 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"FechaIntento",System.Data.DbType.Date,8,0}
          } ;
          Object[] prmT00062 ;
          prmT00062 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"FechaIntento",System.Data.DbType.Date,8,0}
          } ;
          Object[] prmT000610 ;
          prmT000610 = new Object[] {
          new Object[] {"FechaIntento",System.Data.DbType.Date,8,0} ,
          new Object[] {"Contador",System.Data.DbType.Byte,1,0} ,
          new Object[] {"IntentosHoraBloqueo",System.Data.DbType.DateTime,8,5} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000611 ;
          prmT000611 = new Object[] {
          new Object[] {"Contador",System.Data.DbType.Byte,1,0} ,
          new Object[] {"IntentosHoraBloqueo",System.Data.DbType.DateTime,8,5} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"FechaIntento",System.Data.DbType.Date,8,0}
          } ;
          Object[] prmT000612 ;
          prmT000612 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"FechaIntento",System.Data.DbType.Date,8,0}
          } ;
          Object[] prmT000613 ;
          prmT000613 = new Object[] {
          } ;
          Object[] prmT000614 ;
          prmT000614 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("T00062", "SELECT `FechaIntento`, `Contador`, `IntentosHoraBloqueo`, `UsuariosId` FROM `Intentos` WHERE `UsuariosId` = ? AND `FechaIntento` = ?  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT00062,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00063", "SELECT `FechaIntento`, `Contador`, `IntentosHoraBloqueo`, `UsuariosId` FROM `Intentos` WHERE `UsuariosId` = ? AND `FechaIntento` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00063,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00064", "SELECT `UsuariosId` FROM `Usuarios` WHERE `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00064,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00065", "SELECT TM1.`FechaIntento`, TM1.`Contador`, TM1.`IntentosHoraBloqueo`, TM1.`UsuariosId` FROM `Intentos` TM1 WHERE TM1.`UsuariosId` = ? and TM1.`FechaIntento` = ? ORDER BY TM1.`UsuariosId`, TM1.`FechaIntento` ",true, GxErrorMask.GX_NOMASK, false, this,prmT00065,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00066", "SELECT `UsuariosId` FROM `Usuarios` WHERE `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00066,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00067", "SELECT `UsuariosId`, `FechaIntento` FROM `Intentos` WHERE `UsuariosId` = ? AND `FechaIntento` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00067,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00068", "SELECT `UsuariosId`, `FechaIntento` FROM `Intentos` WHERE ( `UsuariosId` > ? or `UsuariosId` = ? and `FechaIntento` > ?) ORDER BY `UsuariosId`, `FechaIntento`  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT00068,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00069", "SELECT `UsuariosId`, `FechaIntento` FROM `Intentos` WHERE ( `UsuariosId` < ? or `UsuariosId` = ? and `FechaIntento` < ?) ORDER BY `UsuariosId` DESC, `FechaIntento` DESC  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT00069,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000610", "INSERT INTO `Intentos`(`FechaIntento`, `Contador`, `IntentosHoraBloqueo`, `UsuariosId`) VALUES(?, ?, ?, ?)", GxErrorMask.GX_NOMASK,prmT000610)
             ,new CursorDef("T000611", "UPDATE `Intentos` SET `Contador`=?, `IntentosHoraBloqueo`=?  WHERE `UsuariosId` = ? AND `FechaIntento` = ?", GxErrorMask.GX_NOMASK,prmT000611)
             ,new CursorDef("T000612", "DELETE FROM `Intentos`  WHERE `UsuariosId` = ? AND `FechaIntento` = ?", GxErrorMask.GX_NOMASK,prmT000612)
             ,new CursorDef("T000613", "SELECT `UsuariosId`, `FechaIntento` FROM `Intentos` ORDER BY `UsuariosId`, `FechaIntento` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000613,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000614", "SELECT `UsuariosId` FROM `Usuarios` WHERE `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000614,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4) ;
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4) ;
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 3 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4) ;
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2) ;
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2) ;
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2) ;
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2) ;
                return;
             case 12 :
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
                stmt.SetParameter(2, (DateTime)parms[1]);
                return;
             case 1 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (DateTime)parms[1]);
                return;
             case 2 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 3 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (DateTime)parms[1]);
                return;
             case 4 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 5 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (DateTime)parms[1]);
                return;
             case 6 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (DateTime)parms[2]);
                return;
             case 7 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (DateTime)parms[2]);
                return;
             case 8 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                if ( (bool)parms[2] )
                {
                   stmt.setNull( 3 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameterDatetime(3, (DateTime)parms[3]);
                }
                stmt.SetParameter(4, (int)parms[4]);
                return;
             case 9 :
                stmt.SetParameter(1, (short)parms[0]);
                if ( (bool)parms[1] )
                {
                   stmt.setNull( 2 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameterDatetime(2, (DateTime)parms[2]);
                }
                stmt.SetParameter(3, (int)parms[3]);
                stmt.SetParameter(4, (DateTime)parms[4]);
                return;
             case 10 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (DateTime)parms[1]);
                return;
             case 12 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

}
