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
   public class bitacces : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
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
            gxLoad_3( A11UsuariosId) ;
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
            Form.Meta.addItem("description", "Bitacora acceso", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtbitAccesFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public bitacces( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public bitacces( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Bitacora acceso", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_bitAcces.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_bitAcces.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_bitAcces.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_bitAcces.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_bitAcces.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_bitAcces.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtbitAccesFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtbitAccesFec_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtbitAccesFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtbitAccesFec_Internalname, context.localUtil.TToC( A61bitAccesFec, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A61bitAccesFec, "99/99/99 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',8,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',8,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtbitAccesFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtbitAccesFec_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_bitAcces.htm");
         GxWebStd.gx_bitmap( context, edtbitAccesFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtbitAccesFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_bitAcces.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtbitAccesIp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtbitAccesIp_Internalname, "Ip", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtbitAccesIp_Internalname, A75bitAccesIp, StringUtil.RTrim( context.localUtil.Format( A75bitAccesIp, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtbitAccesIp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtbitAccesIp_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_bitAcces.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosId_Internalname, "ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuariosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")), ((edtUsuariosId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9")) : context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosId_Enabled, 0, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "NumId", "right", false, "", "HLP_bitAcces.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_bitAcces.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_bitAcces.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_bitAcces.htm");
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
            Z61bitAccesFec = context.localUtil.CToT( cgiGet( "Z61bitAccesFec"), 0);
            Z75bitAccesIp = cgiGet( "Z75bitAccesIp");
            Z11UsuariosId = (int)(context.localUtil.CToN( cgiGet( "Z11UsuariosId"), ",", "."));
            n11UsuariosId = ((0==A11UsuariosId) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( context.localUtil.VCDateTime( cgiGet( edtbitAccesFec_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha"}), 1, "BITACCESFEC");
               AnyError = 1;
               GX_FocusControl = edtbitAccesFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A61bitAccesFec = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A61bitAccesFec", context.localUtil.TToC( A61bitAccesFec, 8, 8, 0, 3, "/", ":", " "));
            }
            else
            {
               A61bitAccesFec = context.localUtil.CToT( cgiGet( edtbitAccesFec_Internalname));
               AssignAttri("", false, "A61bitAccesFec", context.localUtil.TToC( A61bitAccesFec, 8, 8, 0, 3, "/", ":", " "));
            }
            A75bitAccesIp = cgiGet( edtbitAccesIp_Internalname);
            AssignAttri("", false, "A75bitAccesIp", A75bitAccesIp);
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
            n11UsuariosId = ((0==A11UsuariosId) ? true : false);
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
               A61bitAccesFec = context.localUtil.ParseDTimeParm( GetNextPar( ));
               AssignAttri("", false, "A61bitAccesFec", context.localUtil.TToC( A61bitAccesFec, 8, 8, 0, 3, "/", ":", " "));
               A75bitAccesIp = GetNextPar( );
               AssignAttri("", false, "A75bitAccesIp", A75bitAccesIp);
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
               InitAll0811( ) ;
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
         DisableAttributes0811( ) ;
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

      protected void ResetCaption080( )
      {
      }

      protected void ZM0811( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z11UsuariosId = T00083_A11UsuariosId[0];
            }
            else
            {
               Z11UsuariosId = A11UsuariosId;
            }
         }
         if ( GX_JID == -2 )
         {
            Z61bitAccesFec = A61bitAccesFec;
            Z75bitAccesIp = A75bitAccesIp;
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

      protected void Load0811( )
      {
         /* Using cursor T00085 */
         pr_default.execute(3, new Object[] {A61bitAccesFec, A75bitAccesIp});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound11 = 1;
            A11UsuariosId = T00085_A11UsuariosId[0];
            n11UsuariosId = T00085_n11UsuariosId[0];
            AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
            ZM0811( -2) ;
         }
         pr_default.close(3);
         OnLoadActions0811( ) ;
      }

      protected void OnLoadActions0811( )
      {
      }

      protected void CheckExtendedTable0811( )
      {
         nIsDirty_11 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A61bitAccesFec) || ( A61bitAccesFec >= context.localUtil.YMDHMSToT( 1000, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "BITACCESFEC");
            AnyError = 1;
            GX_FocusControl = edtbitAccesFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00084 */
         pr_default.execute(2, new Object[] {n11UsuariosId, A11UsuariosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A11UsuariosId) ) )
            {
               GX_msglist.addItem("No existe 'Tabla de usuarios'.", "ForeignKeyNotFound", 1, "USUARIOSID");
               AnyError = 1;
               GX_FocusControl = edtUsuariosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0811( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A11UsuariosId )
      {
         /* Using cursor T00086 */
         pr_default.execute(4, new Object[] {n11UsuariosId, A11UsuariosId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A11UsuariosId) ) )
            {
               GX_msglist.addItem("No existe 'Tabla de usuarios'.", "ForeignKeyNotFound", 1, "USUARIOSID");
               AnyError = 1;
               GX_FocusControl = edtUsuariosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
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

      protected void GetKey0811( )
      {
         /* Using cursor T00087 */
         pr_default.execute(5, new Object[] {A61bitAccesFec, A75bitAccesIp});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00083 */
         pr_default.execute(1, new Object[] {A61bitAccesFec, A75bitAccesIp});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0811( 2) ;
            RcdFound11 = 1;
            A61bitAccesFec = T00083_A61bitAccesFec[0];
            AssignAttri("", false, "A61bitAccesFec", context.localUtil.TToC( A61bitAccesFec, 8, 8, 0, 3, "/", ":", " "));
            A75bitAccesIp = T00083_A75bitAccesIp[0];
            AssignAttri("", false, "A75bitAccesIp", A75bitAccesIp);
            A11UsuariosId = T00083_A11UsuariosId[0];
            n11UsuariosId = T00083_n11UsuariosId[0];
            AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
            Z61bitAccesFec = A61bitAccesFec;
            Z75bitAccesIp = A75bitAccesIp;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0811( ) ;
            if ( AnyError == 1 )
            {
               RcdFound11 = 0;
               InitializeNonKey0811( ) ;
            }
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0811( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0811( ) ;
         if ( RcdFound11 == 0 )
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
         RcdFound11 = 0;
         /* Using cursor T00088 */
         pr_default.execute(6, new Object[] {A61bitAccesFec, A61bitAccesFec, A75bitAccesIp});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00088_A61bitAccesFec[0] < A61bitAccesFec ) || ( T00088_A61bitAccesFec[0] == A61bitAccesFec ) && ( StringUtil.StrCmp(T00088_A75bitAccesIp[0], A75bitAccesIp) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00088_A61bitAccesFec[0] > A61bitAccesFec ) || ( T00088_A61bitAccesFec[0] == A61bitAccesFec ) && ( StringUtil.StrCmp(T00088_A75bitAccesIp[0], A75bitAccesIp) > 0 ) ) )
            {
               A61bitAccesFec = T00088_A61bitAccesFec[0];
               AssignAttri("", false, "A61bitAccesFec", context.localUtil.TToC( A61bitAccesFec, 8, 8, 0, 3, "/", ":", " "));
               A75bitAccesIp = T00088_A75bitAccesIp[0];
               AssignAttri("", false, "A75bitAccesIp", A75bitAccesIp);
               RcdFound11 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound11 = 0;
         /* Using cursor T00089 */
         pr_default.execute(7, new Object[] {A61bitAccesFec, A61bitAccesFec, A75bitAccesIp});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00089_A61bitAccesFec[0] > A61bitAccesFec ) || ( T00089_A61bitAccesFec[0] == A61bitAccesFec ) && ( StringUtil.StrCmp(T00089_A75bitAccesIp[0], A75bitAccesIp) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00089_A61bitAccesFec[0] < A61bitAccesFec ) || ( T00089_A61bitAccesFec[0] == A61bitAccesFec ) && ( StringUtil.StrCmp(T00089_A75bitAccesIp[0], A75bitAccesIp) < 0 ) ) )
            {
               A61bitAccesFec = T00089_A61bitAccesFec[0];
               AssignAttri("", false, "A61bitAccesFec", context.localUtil.TToC( A61bitAccesFec, 8, 8, 0, 3, "/", ":", " "));
               A75bitAccesIp = T00089_A75bitAccesIp[0];
               AssignAttri("", false, "A75bitAccesIp", A75bitAccesIp);
               RcdFound11 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0811( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtbitAccesFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0811( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound11 == 1 )
            {
               if ( ( A61bitAccesFec != Z61bitAccesFec ) || ( StringUtil.StrCmp(A75bitAccesIp, Z75bitAccesIp) != 0 ) )
               {
                  A61bitAccesFec = Z61bitAccesFec;
                  AssignAttri("", false, "A61bitAccesFec", context.localUtil.TToC( A61bitAccesFec, 8, 8, 0, 3, "/", ":", " "));
                  A75bitAccesIp = Z75bitAccesIp;
                  AssignAttri("", false, "A75bitAccesIp", A75bitAccesIp);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "BITACCESFEC");
                  AnyError = 1;
                  GX_FocusControl = edtbitAccesFec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtbitAccesFec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0811( ) ;
                  GX_FocusControl = edtbitAccesFec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A61bitAccesFec != Z61bitAccesFec ) || ( StringUtil.StrCmp(A75bitAccesIp, Z75bitAccesIp) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtbitAccesFec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0811( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "BITACCESFEC");
                     AnyError = 1;
                     GX_FocusControl = edtbitAccesFec_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtbitAccesFec_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0811( ) ;
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
         if ( ( A61bitAccesFec != Z61bitAccesFec ) || ( StringUtil.StrCmp(A75bitAccesIp, Z75bitAccesIp) != 0 ) )
         {
            A61bitAccesFec = Z61bitAccesFec;
            AssignAttri("", false, "A61bitAccesFec", context.localUtil.TToC( A61bitAccesFec, 8, 8, 0, 3, "/", ":", " "));
            A75bitAccesIp = Z75bitAccesIp;
            AssignAttri("", false, "A75bitAccesIp", A75bitAccesIp);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "BITACCESFEC");
            AnyError = 1;
            GX_FocusControl = edtbitAccesFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtbitAccesFec_Internalname;
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
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "BITACCESFEC");
            AnyError = 1;
            GX_FocusControl = edtbitAccesFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtUsuariosId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0811( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuariosId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0811( ) ;
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
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuariosId_Internalname;
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
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuariosId_Internalname;
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
         ScanStart0811( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound11 != 0 )
            {
               ScanNext0811( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuariosId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0811( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0811( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00082 */
            pr_default.execute(0, new Object[] {A61bitAccesFec, A75bitAccesIp});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"bitAcces"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z11UsuariosId != T00082_A11UsuariosId[0] ) )
            {
               if ( Z11UsuariosId != T00082_A11UsuariosId[0] )
               {
                  GXUtil.WriteLog("bitacces:[seudo value changed for attri]"+"UsuariosId");
                  GXUtil.WriteLogRaw("Old: ",Z11UsuariosId);
                  GXUtil.WriteLogRaw("Current: ",T00082_A11UsuariosId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"bitAcces"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0811( )
      {
         BeforeValidate0811( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0811( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0811( 0) ;
            CheckOptimisticConcurrency0811( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0811( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0811( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000810 */
                     pr_default.execute(8, new Object[] {A61bitAccesFec, A75bitAccesIp, n11UsuariosId, A11UsuariosId});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("bitAcces") ;
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
                           ResetCaption080( ) ;
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
               Load0811( ) ;
            }
            EndLevel0811( ) ;
         }
         CloseExtendedTableCursors0811( ) ;
      }

      protected void Update0811( )
      {
         BeforeValidate0811( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0811( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0811( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0811( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0811( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000811 */
                     pr_default.execute(9, new Object[] {n11UsuariosId, A11UsuariosId, A61bitAccesFec, A75bitAccesIp});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("bitAcces") ;
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"bitAcces"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0811( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption080( ) ;
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
            EndLevel0811( ) ;
         }
         CloseExtendedTableCursors0811( ) ;
      }

      protected void DeferredUpdate0811( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0811( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0811( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0811( ) ;
            AfterConfirm0811( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0811( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000812 */
                  pr_default.execute(10, new Object[] {A61bitAccesFec, A75bitAccesIp});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("bitAcces") ;
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound11 == 0 )
                        {
                           InitAll0811( ) ;
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
                        ResetCaption080( ) ;
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
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0811( ) ;
         Gx_mode = sMode11;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0811( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0811( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0811( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("bitacces",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues080( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("bitacces",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0811( )
      {
         /* Using cursor T000813 */
         pr_default.execute(11);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound11 = 1;
            A61bitAccesFec = T000813_A61bitAccesFec[0];
            AssignAttri("", false, "A61bitAccesFec", context.localUtil.TToC( A61bitAccesFec, 8, 8, 0, 3, "/", ":", " "));
            A75bitAccesIp = T000813_A75bitAccesIp[0];
            AssignAttri("", false, "A75bitAccesIp", A75bitAccesIp);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0811( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound11 = 1;
            A61bitAccesFec = T000813_A61bitAccesFec[0];
            AssignAttri("", false, "A61bitAccesFec", context.localUtil.TToC( A61bitAccesFec, 8, 8, 0, 3, "/", ":", " "));
            A75bitAccesIp = T000813_A75bitAccesIp[0];
            AssignAttri("", false, "A75bitAccesIp", A75bitAccesIp);
         }
      }

      protected void ScanEnd0811( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0811( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0811( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0811( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0811( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0811( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0811( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0811( )
      {
         edtbitAccesFec_Enabled = 0;
         AssignProp("", false, edtbitAccesFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtbitAccesFec_Enabled), 5, 0), true);
         edtbitAccesIp_Enabled = 0;
         AssignProp("", false, edtbitAccesIp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtbitAccesIp_Enabled), 5, 0), true);
         edtUsuariosId_Enabled = 0;
         AssignProp("", false, edtUsuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0811( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues080( )
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
         context.AddJavascriptSource("gxcfg.js", "?202262714344031", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("bitacces.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z61bitAccesFec", context.localUtil.TToC( Z61bitAccesFec, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z75bitAccesIp", Z75bitAccesIp);
         GxWebStd.gx_hidden_field( context, "Z11UsuariosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11UsuariosId), 6, 0, ",", "")));
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
         return formatLink("bitacces.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "bitAcces" ;
      }

      public override String GetPgmdesc( )
      {
         return "Bitacora acceso" ;
      }

      protected void InitializeNonKey0811( )
      {
         A11UsuariosId = 0;
         n11UsuariosId = false;
         AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
         n11UsuariosId = ((0==A11UsuariosId) ? true : false);
         Z11UsuariosId = 0;
      }

      protected void InitAll0811( )
      {
         A61bitAccesFec = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A61bitAccesFec", context.localUtil.TToC( A61bitAccesFec, 8, 8, 0, 3, "/", ":", " "));
         A75bitAccesIp = "";
         AssignAttri("", false, "A75bitAccesIp", A75bitAccesIp);
         InitializeNonKey0811( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714344033", true, true);
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
         context.AddJavascriptSource("bitacces.js", "?202262714344033", false, true);
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
         edtbitAccesFec_Internalname = "BITACCESFEC";
         edtbitAccesIp_Internalname = "BITACCESIP";
         edtUsuariosId_Internalname = "USUARIOSID";
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
         Form.Caption = "Bitacora acceso";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtUsuariosId_Jsonclick = "";
         edtUsuariosId_Enabled = 1;
         edtbitAccesIp_Jsonclick = "";
         edtbitAccesIp_Enabled = 1;
         edtbitAccesFec_Jsonclick = "";
         edtbitAccesFec_Enabled = 1;
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
         GX_FocusControl = edtUsuariosId_Internalname;
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

      public void Valid_Bitaccesip( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A11UsuariosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z61bitAccesFec", context.localUtil.TToC( Z61bitAccesFec, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z75bitAccesIp", Z75bitAccesIp);
         GxWebStd.gx_hidden_field( context, "Z11UsuariosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11UsuariosId), 6, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Usuariosid( )
      {
         n11UsuariosId = false;
         /* Using cursor T000814 */
         pr_default.execute(12, new Object[] {n11UsuariosId, A11UsuariosId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A11UsuariosId) ) )
            {
               GX_msglist.addItem("No existe 'Tabla de usuarios'.", "ForeignKeyNotFound", 1, "USUARIOSID");
               AnyError = 1;
               GX_FocusControl = edtUsuariosId_Internalname;
            }
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
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
         setEventMetadata("VALID_BITACCESFEC","{handler:'Valid_Bitaccesfec',iparms:[]");
         setEventMetadata("VALID_BITACCESFEC",",oparms:[]}");
         setEventMetadata("VALID_BITACCESIP","{handler:'Valid_Bitaccesip',iparms:[{av:'A61bitAccesFec',fld:'BITACCESFEC',pic:'99/99/99 99:99:99'},{av:'A75bitAccesIp',fld:'BITACCESIP',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_BITACCESIP",",oparms:[{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z61bitAccesFec'},{av:'Z75bitAccesIp'},{av:'Z11UsuariosId'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_USUARIOSID","{handler:'Valid_Usuariosid',iparms:[{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_USUARIOSID",",oparms:[]}");
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
         Z61bitAccesFec = (DateTime)(DateTime.MinValue);
         Z75bitAccesIp = "";
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
         A61bitAccesFec = (DateTime)(DateTime.MinValue);
         A75bitAccesIp = "";
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
         T00085_A61bitAccesFec = new DateTime[] {DateTime.MinValue} ;
         T00085_A75bitAccesIp = new String[] {""} ;
         T00085_A11UsuariosId = new int[1] ;
         T00085_n11UsuariosId = new bool[] {false} ;
         T00084_A11UsuariosId = new int[1] ;
         T00084_n11UsuariosId = new bool[] {false} ;
         T00086_A11UsuariosId = new int[1] ;
         T00086_n11UsuariosId = new bool[] {false} ;
         T00087_A61bitAccesFec = new DateTime[] {DateTime.MinValue} ;
         T00087_A75bitAccesIp = new String[] {""} ;
         T00083_A61bitAccesFec = new DateTime[] {DateTime.MinValue} ;
         T00083_A75bitAccesIp = new String[] {""} ;
         T00083_A11UsuariosId = new int[1] ;
         T00083_n11UsuariosId = new bool[] {false} ;
         sMode11 = "";
         T00088_A61bitAccesFec = new DateTime[] {DateTime.MinValue} ;
         T00088_A75bitAccesIp = new String[] {""} ;
         T00089_A61bitAccesFec = new DateTime[] {DateTime.MinValue} ;
         T00089_A75bitAccesIp = new String[] {""} ;
         T00082_A61bitAccesFec = new DateTime[] {DateTime.MinValue} ;
         T00082_A75bitAccesIp = new String[] {""} ;
         T00082_A11UsuariosId = new int[1] ;
         T00082_n11UsuariosId = new bool[] {false} ;
         T000813_A61bitAccesFec = new DateTime[] {DateTime.MinValue} ;
         T000813_A75bitAccesIp = new String[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ61bitAccesFec = (DateTime)(DateTime.MinValue);
         ZZ75bitAccesIp = "";
         T000814_A11UsuariosId = new int[1] ;
         T000814_n11UsuariosId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bitacces__default(),
            new Object[][] {
                new Object[] {
               T00082_A61bitAccesFec, T00082_A75bitAccesIp, T00082_A11UsuariosId, T00082_n11UsuariosId
               }
               , new Object[] {
               T00083_A61bitAccesFec, T00083_A75bitAccesIp, T00083_A11UsuariosId, T00083_n11UsuariosId
               }
               , new Object[] {
               T00084_A11UsuariosId
               }
               , new Object[] {
               T00085_A61bitAccesFec, T00085_A75bitAccesIp, T00085_A11UsuariosId, T00085_n11UsuariosId
               }
               , new Object[] {
               T00086_A11UsuariosId
               }
               , new Object[] {
               T00087_A61bitAccesFec, T00087_A75bitAccesIp
               }
               , new Object[] {
               T00088_A61bitAccesFec, T00088_A75bitAccesIp
               }
               , new Object[] {
               T00089_A61bitAccesFec, T00089_A75bitAccesIp
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000813_A61bitAccesFec, T000813_A75bitAccesIp
               }
               , new Object[] {
               T000814_A11UsuariosId
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
      private short RcdFound11 ;
      private short nIsDirty_11 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z11UsuariosId ;
      private int A11UsuariosId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtbitAccesFec_Enabled ;
      private int edtbitAccesIp_Enabled ;
      private int edtUsuariosId_Enabled ;
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
      private String edtbitAccesFec_Internalname ;
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
      private String edtbitAccesFec_Jsonclick ;
      private String edtbitAccesIp_Internalname ;
      private String edtbitAccesIp_Jsonclick ;
      private String edtUsuariosId_Internalname ;
      private String edtUsuariosId_Jsonclick ;
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
      private String sMode11 ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private DateTime Z61bitAccesFec ;
      private DateTime A61bitAccesFec ;
      private DateTime ZZ61bitAccesFec ;
      private bool entryPointCalled ;
      private bool n11UsuariosId ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private String Z75bitAccesIp ;
      private String A75bitAccesIp ;
      private String ZZ75bitAccesIp ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T00085_A61bitAccesFec ;
      private String[] T00085_A75bitAccesIp ;
      private int[] T00085_A11UsuariosId ;
      private bool[] T00085_n11UsuariosId ;
      private int[] T00084_A11UsuariosId ;
      private bool[] T00084_n11UsuariosId ;
      private int[] T00086_A11UsuariosId ;
      private bool[] T00086_n11UsuariosId ;
      private DateTime[] T00087_A61bitAccesFec ;
      private String[] T00087_A75bitAccesIp ;
      private DateTime[] T00083_A61bitAccesFec ;
      private String[] T00083_A75bitAccesIp ;
      private int[] T00083_A11UsuariosId ;
      private bool[] T00083_n11UsuariosId ;
      private DateTime[] T00088_A61bitAccesFec ;
      private String[] T00088_A75bitAccesIp ;
      private DateTime[] T00089_A61bitAccesFec ;
      private String[] T00089_A75bitAccesIp ;
      private DateTime[] T00082_A61bitAccesFec ;
      private String[] T00082_A75bitAccesIp ;
      private int[] T00082_A11UsuariosId ;
      private bool[] T00082_n11UsuariosId ;
      private DateTime[] T000813_A61bitAccesFec ;
      private String[] T000813_A75bitAccesIp ;
      private int[] T000814_A11UsuariosId ;
      private bool[] T000814_n11UsuariosId ;
      private GXWebForm Form ;
   }

   public class bitacces__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT00085 ;
          prmT00085 = new Object[] {
          new Object[] {"bitAccesFec",System.Data.DbType.DateTime,8,8} ,
          new Object[] {"bitAccesIp",System.Data.DbType.String,15,0}
          } ;
          Object[] prmT00084 ;
          prmT00084 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT00086 ;
          prmT00086 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT00087 ;
          prmT00087 = new Object[] {
          new Object[] {"bitAccesFec",System.Data.DbType.DateTime,8,8} ,
          new Object[] {"bitAccesIp",System.Data.DbType.String,15,0}
          } ;
          Object[] prmT00083 ;
          prmT00083 = new Object[] {
          new Object[] {"bitAccesFec",System.Data.DbType.DateTime,8,8} ,
          new Object[] {"bitAccesIp",System.Data.DbType.String,15,0}
          } ;
          Object[] prmT00088 ;
          prmT00088 = new Object[] {
          new Object[] {"bitAccesFec",System.Data.DbType.DateTime,8,8} ,
          new Object[] {"bitAccesFec",System.Data.DbType.DateTime,8,8} ,
          new Object[] {"bitAccesIp",System.Data.DbType.String,15,0}
          } ;
          Object[] prmT00089 ;
          prmT00089 = new Object[] {
          new Object[] {"bitAccesFec",System.Data.DbType.DateTime,8,8} ,
          new Object[] {"bitAccesFec",System.Data.DbType.DateTime,8,8} ,
          new Object[] {"bitAccesIp",System.Data.DbType.String,15,0}
          } ;
          Object[] prmT00082 ;
          prmT00082 = new Object[] {
          new Object[] {"bitAccesFec",System.Data.DbType.DateTime,8,8} ,
          new Object[] {"bitAccesIp",System.Data.DbType.String,15,0}
          } ;
          Object[] prmT000810 ;
          prmT000810 = new Object[] {
          new Object[] {"bitAccesFec",System.Data.DbType.DateTime,8,8} ,
          new Object[] {"bitAccesIp",System.Data.DbType.String,15,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000811 ;
          prmT000811 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"bitAccesFec",System.Data.DbType.DateTime,8,8} ,
          new Object[] {"bitAccesIp",System.Data.DbType.String,15,0}
          } ;
          Object[] prmT000812 ;
          prmT000812 = new Object[] {
          new Object[] {"bitAccesFec",System.Data.DbType.DateTime,8,8} ,
          new Object[] {"bitAccesIp",System.Data.DbType.String,15,0}
          } ;
          Object[] prmT000813 ;
          prmT000813 = new Object[] {
          } ;
          Object[] prmT000814 ;
          prmT000814 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("T00082", "SELECT `bitAccesFec`, `bitAccesIp`, `UsuariosId` FROM `bitAcces` WHERE `bitAccesFec` = ? AND `bitAccesIp` = ?  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT00082,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00083", "SELECT `bitAccesFec`, `bitAccesIp`, `UsuariosId` FROM `bitAcces` WHERE `bitAccesFec` = ? AND `bitAccesIp` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00083,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00084", "SELECT `UsuariosId` FROM `Usuarios` WHERE `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00084,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00085", "SELECT TM1.`bitAccesFec`, TM1.`bitAccesIp`, TM1.`UsuariosId` FROM `bitAcces` TM1 WHERE TM1.`bitAccesFec` = ? and TM1.`bitAccesIp` = ? ORDER BY TM1.`bitAccesFec`, TM1.`bitAccesIp` ",true, GxErrorMask.GX_NOMASK, false, this,prmT00085,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00086", "SELECT `UsuariosId` FROM `Usuarios` WHERE `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00086,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00087", "SELECT `bitAccesFec`, `bitAccesIp` FROM `bitAcces` WHERE `bitAccesFec` = ? AND `bitAccesIp` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00087,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00088", "SELECT `bitAccesFec`, `bitAccesIp` FROM `bitAcces` WHERE ( `bitAccesFec` > ? or `bitAccesFec` = ? and `bitAccesIp` > ?) ORDER BY `bitAccesFec`, `bitAccesIp`  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT00088,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00089", "SELECT `bitAccesFec`, `bitAccesIp` FROM `bitAcces` WHERE ( `bitAccesFec` < ? or `bitAccesFec` = ? and `bitAccesIp` < ?) ORDER BY `bitAccesFec` DESC, `bitAccesIp` DESC  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT00089,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000810", "INSERT INTO `bitAcces`(`bitAccesFec`, `bitAccesIp`, `UsuariosId`) VALUES(?, ?, ?)", GxErrorMask.GX_NOMASK,prmT000810)
             ,new CursorDef("T000811", "UPDATE `bitAcces` SET `UsuariosId`=?  WHERE `bitAccesFec` = ? AND `bitAccesIp` = ?", GxErrorMask.GX_NOMASK,prmT000811)
             ,new CursorDef("T000812", "DELETE FROM `bitAcces`  WHERE `bitAccesFec` = ? AND `bitAccesIp` = ?", GxErrorMask.GX_NOMASK,prmT000812)
             ,new CursorDef("T000813", "SELECT `bitAccesFec`, `bitAccesIp` FROM `bitAcces` ORDER BY `bitAccesFec`, `bitAccesIp` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000813,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000814", "SELECT `UsuariosId` FROM `Usuarios` WHERE `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000814,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 3 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 5 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                return;
             case 6 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                return;
             case 7 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                return;
             case 11 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
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
                stmt.SetParameterDatetime(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                return;
             case 1 :
                stmt.SetParameterDatetime(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                return;
             case 2 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 3 :
                stmt.SetParameterDatetime(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                return;
             case 4 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 5 :
                stmt.SetParameterDatetime(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                return;
             case 6 :
                stmt.SetParameterDatetime(1, (DateTime)parms[0]);
                stmt.SetParameterDatetime(2, (DateTime)parms[1]);
                stmt.SetParameter(3, (String)parms[2]);
                return;
             case 7 :
                stmt.SetParameterDatetime(1, (DateTime)parms[0]);
                stmt.SetParameterDatetime(2, (DateTime)parms[1]);
                stmt.SetParameter(3, (String)parms[2]);
                return;
             case 8 :
                stmt.SetParameterDatetime(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                if ( (bool)parms[2] )
                {
                   stmt.setNull( 3 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(3, (int)parms[3]);
                }
                return;
             case 9 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                stmt.SetParameterDatetime(2, (DateTime)parms[2]);
                stmt.SetParameter(3, (String)parms[3]);
                return;
             case 10 :
                stmt.SetParameterDatetime(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
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
       }
    }

 }

}
