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
   public class parametros : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
               AV11ParametroId = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignAttri("", false, "AV11ParametroId", StringUtil.LTrimStr( (decimal)(AV11ParametroId), 9, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPARAMETROID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11ParametroId), "ZZZZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Parametros", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtParametroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public parametros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public parametros( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( String aP0_Gx_mode ,
                           int aP1_ParametroId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV11ParametroId = aP1_ParametroId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkParametroWebService = new GXCheckbox();
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
         A134ParametroWebService = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A134ParametroWebService), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A134ParametroWebService", StringUtil.Str( (decimal)(A134ParametroWebService), 1, 0));
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Parametros", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_Parametros.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Parametros.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametroId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametroId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametroId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A29ParametroId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A29ParametroId), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParametroId_Enabled, 1, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametroHoraIni_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametroHoraIni_Internalname, "Ini", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametroHoraIni_Internalname, StringUtil.RTrim( A133ParametroHoraIni), StringUtil.RTrim( context.localUtil.Format( A133ParametroHoraIni, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroHoraIni_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParametroHoraIni_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametroHoraFin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametroHoraFin_Internalname, "Fin", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametroHoraFin_Internalname, StringUtil.RTrim( A132ParametroHoraFin), StringUtil.RTrim( context.localUtil.Format( A132ParametroHoraFin, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroHoraFin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParametroHoraFin_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametroValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametroValor_Internalname, "Valor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtParametroValor_Internalname, A129ParametroValor, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtParametroValor_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "1000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametroDesc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametroDesc_Internalname, "Desc", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametroDesc_Internalname, A130ParametroDesc, StringUtil.RTrim( context.localUtil.Format( A130ParametroDesc, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroDesc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParametroDesc_Enabled, 0, "text", "", 35, "chr", 1, "row", 35, 0, 0, 0, 1, -1, -1, true, "DescripCorta", "left", true, "", "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametroDescLarg_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametroDescLarg_Internalname, "Desc Larg", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtParametroDescLarg_Internalname, A131ParametroDescLarg, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", 0, 1, edtParametroDescLarg_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2048", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkParametroWebService_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkParametroWebService_Internalname, "Web Services?", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkParametroWebService_Internalname, StringUtil.Str( (decimal)(A134ParametroWebService), 1, 0), "", "Web Services?", 1, chkParametroWebService.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(64, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,64);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrosBloqueo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametrosBloqueo_Internalname, "Bloqueo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametrosBloqueo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A71ParametrosBloqueo), 4, 0, ",", "")), ((edtParametrosBloqueo_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A71ParametrosBloqueo), "ZZZ9")) : context.localUtil.Format( (decimal)(A71ParametrosBloqueo), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrosBloqueo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParametrosBloqueo_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrosusername_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametrosusername_Internalname, "Parametrosusername", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametrosusername_Internalname, A135Parametrosusername, StringUtil.RTrim( context.localUtil.Format( A135Parametrosusername, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrosusername_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParametrosusername_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrospassword_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametrospassword_Internalname, "Parametrospassword", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametrospassword_Internalname, A136Parametrospassword, StringUtil.RTrim( context.localUtil.Format( A136Parametrospassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrospassword_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParametrospassword_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrosAddHeader_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametrosAddHeader_Internalname, "Add Header", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtParametrosAddHeader_Internalname, A137ParametrosAddHeader, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", 0, 1, edtParametrosAddHeader_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrosHost_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametrosHost_Internalname, "Host", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametrosHost_Internalname, A138ParametrosHost, StringUtil.RTrim( context.localUtil.Format( A138ParametrosHost, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrosHost_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParametrosHost_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrosPort_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametrosPort_Internalname, "Port", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametrosPort_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A139ParametrosPort), 8, 0, ",", "")), ((edtParametrosPort_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A139ParametrosPort), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(A139ParametrosPort), "ZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrosPort_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParametrosPort_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrosBaseUrl_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametrosBaseUrl_Internalname, "Base Url", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametrosBaseUrl_Internalname, A140ParametrosBaseUrl, StringUtil.RTrim( context.localUtil.Format( A140ParametrosBaseUrl, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrosBaseUrl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParametrosBaseUrl_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrosExecute_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametrosExecute_Internalname, "Execute", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametrosExecute_Internalname, StringUtil.RTrim( A141ParametrosExecute), StringUtil.RTrim( context.localUtil.Format( A141ParametrosExecute, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrosExecute_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParametrosExecute_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrosRuta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametrosRuta_Internalname, "Ruta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametrosRuta_Internalname, A142ParametrosRuta, StringUtil.RTrim( context.localUtil.Format( A142ParametrosRuta, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrosRuta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParametrosRuta_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrosRutaPDF_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametrosRutaPDF_Internalname, "Ruta PDF", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtParametrosRutaPDF_Internalname, A143ParametrosRutaPDF, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", 0, 1, edtParametrosRutaPDF_Enabled, 0, 80, "chr", 8, "row", StyleString, ClassString, "", "", "600", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Parametros.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Parametros.htm");
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
         E11052 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z29ParametroId = (int)(context.localUtil.CToN( cgiGet( "Z29ParametroId"), ",", "."));
               Z133ParametroHoraIni = cgiGet( "Z133ParametroHoraIni");
               Z132ParametroHoraFin = cgiGet( "Z132ParametroHoraFin");
               Z129ParametroValor = cgiGet( "Z129ParametroValor");
               Z130ParametroDesc = cgiGet( "Z130ParametroDesc");
               Z131ParametroDescLarg = cgiGet( "Z131ParametroDescLarg");
               Z134ParametroWebService = (short)(context.localUtil.CToN( cgiGet( "Z134ParametroWebService"), ",", "."));
               Z71ParametrosBloqueo = (short)(context.localUtil.CToN( cgiGet( "Z71ParametrosBloqueo"), ",", "."));
               n71ParametrosBloqueo = ((0==A71ParametrosBloqueo) ? true : false);
               Z135Parametrosusername = cgiGet( "Z135Parametrosusername");
               n135Parametrosusername = (String.IsNullOrEmpty(StringUtil.RTrim( A135Parametrosusername)) ? true : false);
               Z136Parametrospassword = cgiGet( "Z136Parametrospassword");
               n136Parametrospassword = (String.IsNullOrEmpty(StringUtil.RTrim( A136Parametrospassword)) ? true : false);
               Z137ParametrosAddHeader = cgiGet( "Z137ParametrosAddHeader");
               n137ParametrosAddHeader = (String.IsNullOrEmpty(StringUtil.RTrim( A137ParametrosAddHeader)) ? true : false);
               Z138ParametrosHost = cgiGet( "Z138ParametrosHost");
               n138ParametrosHost = (String.IsNullOrEmpty(StringUtil.RTrim( A138ParametrosHost)) ? true : false);
               Z139ParametrosPort = (int)(context.localUtil.CToN( cgiGet( "Z139ParametrosPort"), ",", "."));
               n139ParametrosPort = ((0==A139ParametrosPort) ? true : false);
               Z140ParametrosBaseUrl = cgiGet( "Z140ParametrosBaseUrl");
               n140ParametrosBaseUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A140ParametrosBaseUrl)) ? true : false);
               Z141ParametrosExecute = cgiGet( "Z141ParametrosExecute");
               n141ParametrosExecute = (String.IsNullOrEmpty(StringUtil.RTrim( A141ParametrosExecute)) ? true : false);
               Z142ParametrosRuta = cgiGet( "Z142ParametrosRuta");
               n142ParametrosRuta = (String.IsNullOrEmpty(StringUtil.RTrim( A142ParametrosRuta)) ? true : false);
               Z143ParametrosRutaPDF = cgiGet( "Z143ParametrosRutaPDF");
               n143ParametrosRutaPDF = (String.IsNullOrEmpty(StringUtil.RTrim( A143ParametrosRutaPDF)) ? true : false);
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               AV11ParametroId = (int)(context.localUtil.CToN( cgiGet( "vPARAMETROID"), ",", "."));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."));
               AV12Motivo = cgiGet( "vMOTIVO");
               Gx_mode = cgiGet( "vMODE");
               AV14Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtParametroId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParametroId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARAMETROID");
                  AnyError = 1;
                  GX_FocusControl = edtParametroId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A29ParametroId = 0;
                  AssignAttri("", false, "A29ParametroId", StringUtil.LTrimStr( (decimal)(A29ParametroId), 9, 0));
               }
               else
               {
                  A29ParametroId = (int)(context.localUtil.CToN( cgiGet( edtParametroId_Internalname), ",", "."));
                  AssignAttri("", false, "A29ParametroId", StringUtil.LTrimStr( (decimal)(A29ParametroId), 9, 0));
               }
               A133ParametroHoraIni = cgiGet( edtParametroHoraIni_Internalname);
               AssignAttri("", false, "A133ParametroHoraIni", A133ParametroHoraIni);
               A132ParametroHoraFin = cgiGet( edtParametroHoraFin_Internalname);
               AssignAttri("", false, "A132ParametroHoraFin", A132ParametroHoraFin);
               A129ParametroValor = cgiGet( edtParametroValor_Internalname);
               AssignAttri("", false, "A129ParametroValor", A129ParametroValor);
               A130ParametroDesc = StringUtil.Upper( cgiGet( edtParametroDesc_Internalname));
               AssignAttri("", false, "A130ParametroDesc", A130ParametroDesc);
               A131ParametroDescLarg = cgiGet( edtParametroDescLarg_Internalname);
               AssignAttri("", false, "A131ParametroDescLarg", A131ParametroDescLarg);
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkParametroWebService_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkParametroWebService_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARAMETROWEBSERVICE");
                  AnyError = 1;
                  GX_FocusControl = chkParametroWebService_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A134ParametroWebService = 0;
                  AssignAttri("", false, "A134ParametroWebService", StringUtil.Str( (decimal)(A134ParametroWebService), 1, 0));
               }
               else
               {
                  A134ParametroWebService = (short)(((StringUtil.StrCmp(cgiGet( chkParametroWebService_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri("", false, "A134ParametroWebService", StringUtil.Str( (decimal)(A134ParametroWebService), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtParametrosBloqueo_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParametrosBloqueo_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARAMETROSBLOQUEO");
                  AnyError = 1;
                  GX_FocusControl = edtParametrosBloqueo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A71ParametrosBloqueo = 0;
                  n71ParametrosBloqueo = false;
                  AssignAttri("", false, "A71ParametrosBloqueo", StringUtil.LTrimStr( (decimal)(A71ParametrosBloqueo), 4, 0));
               }
               else
               {
                  A71ParametrosBloqueo = (short)(context.localUtil.CToN( cgiGet( edtParametrosBloqueo_Internalname), ",", "."));
                  n71ParametrosBloqueo = false;
                  AssignAttri("", false, "A71ParametrosBloqueo", StringUtil.LTrimStr( (decimal)(A71ParametrosBloqueo), 4, 0));
               }
               n71ParametrosBloqueo = ((0==A71ParametrosBloqueo) ? true : false);
               A135Parametrosusername = cgiGet( edtParametrosusername_Internalname);
               n135Parametrosusername = false;
               AssignAttri("", false, "A135Parametrosusername", A135Parametrosusername);
               n135Parametrosusername = (String.IsNullOrEmpty(StringUtil.RTrim( A135Parametrosusername)) ? true : false);
               A136Parametrospassword = cgiGet( edtParametrospassword_Internalname);
               n136Parametrospassword = false;
               AssignAttri("", false, "A136Parametrospassword", A136Parametrospassword);
               n136Parametrospassword = (String.IsNullOrEmpty(StringUtil.RTrim( A136Parametrospassword)) ? true : false);
               A137ParametrosAddHeader = cgiGet( edtParametrosAddHeader_Internalname);
               n137ParametrosAddHeader = false;
               AssignAttri("", false, "A137ParametrosAddHeader", A137ParametrosAddHeader);
               n137ParametrosAddHeader = (String.IsNullOrEmpty(StringUtil.RTrim( A137ParametrosAddHeader)) ? true : false);
               A138ParametrosHost = cgiGet( edtParametrosHost_Internalname);
               n138ParametrosHost = false;
               AssignAttri("", false, "A138ParametrosHost", A138ParametrosHost);
               n138ParametrosHost = (String.IsNullOrEmpty(StringUtil.RTrim( A138ParametrosHost)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtParametrosPort_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParametrosPort_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARAMETROSPORT");
                  AnyError = 1;
                  GX_FocusControl = edtParametrosPort_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A139ParametrosPort = 0;
                  n139ParametrosPort = false;
                  AssignAttri("", false, "A139ParametrosPort", StringUtil.LTrimStr( (decimal)(A139ParametrosPort), 8, 0));
               }
               else
               {
                  A139ParametrosPort = (int)(context.localUtil.CToN( cgiGet( edtParametrosPort_Internalname), ",", "."));
                  n139ParametrosPort = false;
                  AssignAttri("", false, "A139ParametrosPort", StringUtil.LTrimStr( (decimal)(A139ParametrosPort), 8, 0));
               }
               n139ParametrosPort = ((0==A139ParametrosPort) ? true : false);
               A140ParametrosBaseUrl = cgiGet( edtParametrosBaseUrl_Internalname);
               n140ParametrosBaseUrl = false;
               AssignAttri("", false, "A140ParametrosBaseUrl", A140ParametrosBaseUrl);
               n140ParametrosBaseUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A140ParametrosBaseUrl)) ? true : false);
               A141ParametrosExecute = cgiGet( edtParametrosExecute_Internalname);
               n141ParametrosExecute = false;
               AssignAttri("", false, "A141ParametrosExecute", A141ParametrosExecute);
               n141ParametrosExecute = (String.IsNullOrEmpty(StringUtil.RTrim( A141ParametrosExecute)) ? true : false);
               A142ParametrosRuta = cgiGet( edtParametrosRuta_Internalname);
               n142ParametrosRuta = false;
               AssignAttri("", false, "A142ParametrosRuta", A142ParametrosRuta);
               n142ParametrosRuta = (String.IsNullOrEmpty(StringUtil.RTrim( A142ParametrosRuta)) ? true : false);
               A143ParametrosRutaPDF = cgiGet( edtParametrosRutaPDF_Internalname);
               n143ParametrosRutaPDF = false;
               AssignAttri("", false, "A143ParametrosRutaPDF", A143ParametrosRutaPDF);
               n143ParametrosRutaPDF = (String.IsNullOrEmpty(StringUtil.RTrim( A143ParametrosRutaPDF)) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Parametros");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A29ParametroId != Z29ParametroId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("parametros:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A29ParametroId = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri("", false, "A29ParametroId", StringUtil.LTrimStr( (decimal)(A29ParametroId), 9, 0));
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
                     sMode6 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode6;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound6 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_050( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PARAMETROID");
                        AnyError = 1;
                        GX_FocusControl = edtParametroId_Internalname;
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
                           E11052 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12052 ();
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
            E12052 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll056( ) ;
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
            DisableAttributes056( ) ;
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

      protected void CONFIRM_050( )
      {
         BeforeValidate056( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls056( ) ;
            }
            else
            {
               CheckExtendedTable056( ) ;
               CloseExtendedTableCursors056( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption050( )
      {
      }

      protected void E11052( )
      {
         /* Start Routine */
         if ( ! new isauthorized(context).executeUdp(  AV14Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV14Pgmname)));
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "TransactionContext", "ADMINDATA1");
         AV13Fechahora = DateTimeUtil.ServerNow( context, pr_default);
         AssignAttri("", false, "AV13Fechahora", context.localUtil.TToC( AV13Fechahora, 8, 5, 0, 3, "/", ":", " "));
      }

      protected void E12052( )
      {
         /* After Trn Routine */
         if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV12Motivo)) )
         {
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwparametros.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM056( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z133ParametroHoraIni = T00053_A133ParametroHoraIni[0];
               Z132ParametroHoraFin = T00053_A132ParametroHoraFin[0];
               Z129ParametroValor = T00053_A129ParametroValor[0];
               Z130ParametroDesc = T00053_A130ParametroDesc[0];
               Z131ParametroDescLarg = T00053_A131ParametroDescLarg[0];
               Z134ParametroWebService = T00053_A134ParametroWebService[0];
               Z71ParametrosBloqueo = T00053_A71ParametrosBloqueo[0];
               Z135Parametrosusername = T00053_A135Parametrosusername[0];
               Z136Parametrospassword = T00053_A136Parametrospassword[0];
               Z137ParametrosAddHeader = T00053_A137ParametrosAddHeader[0];
               Z138ParametrosHost = T00053_A138ParametrosHost[0];
               Z139ParametrosPort = T00053_A139ParametrosPort[0];
               Z140ParametrosBaseUrl = T00053_A140ParametrosBaseUrl[0];
               Z141ParametrosExecute = T00053_A141ParametrosExecute[0];
               Z142ParametrosRuta = T00053_A142ParametrosRuta[0];
               Z143ParametrosRutaPDF = T00053_A143ParametrosRutaPDF[0];
            }
            else
            {
               Z133ParametroHoraIni = A133ParametroHoraIni;
               Z132ParametroHoraFin = A132ParametroHoraFin;
               Z129ParametroValor = A129ParametroValor;
               Z130ParametroDesc = A130ParametroDesc;
               Z131ParametroDescLarg = A131ParametroDescLarg;
               Z134ParametroWebService = A134ParametroWebService;
               Z71ParametrosBloqueo = A71ParametrosBloqueo;
               Z135Parametrosusername = A135Parametrosusername;
               Z136Parametrospassword = A136Parametrospassword;
               Z137ParametrosAddHeader = A137ParametrosAddHeader;
               Z138ParametrosHost = A138ParametrosHost;
               Z139ParametrosPort = A139ParametrosPort;
               Z140ParametrosBaseUrl = A140ParametrosBaseUrl;
               Z141ParametrosExecute = A141ParametrosExecute;
               Z142ParametrosRuta = A142ParametrosRuta;
               Z143ParametrosRutaPDF = A143ParametrosRutaPDF;
            }
         }
         if ( GX_JID == -9 )
         {
            Z29ParametroId = A29ParametroId;
            Z133ParametroHoraIni = A133ParametroHoraIni;
            Z132ParametroHoraFin = A132ParametroHoraFin;
            Z129ParametroValor = A129ParametroValor;
            Z130ParametroDesc = A130ParametroDesc;
            Z131ParametroDescLarg = A131ParametroDescLarg;
            Z134ParametroWebService = A134ParametroWebService;
            Z71ParametrosBloqueo = A71ParametrosBloqueo;
            Z135Parametrosusername = A135Parametrosusername;
            Z136Parametrospassword = A136Parametrospassword;
            Z137ParametrosAddHeader = A137ParametrosAddHeader;
            Z138ParametrosHost = A138ParametrosHost;
            Z139ParametrosPort = A139ParametrosPort;
            Z140ParametrosBaseUrl = A140ParametrosBaseUrl;
            Z141ParametrosExecute = A141ParametrosExecute;
            Z142ParametrosRuta = A142ParametrosRuta;
            Z143ParametrosRutaPDF = A143ParametrosRutaPDF;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV11ParametroId) )
         {
            A29ParametroId = AV11ParametroId;
            AssignAttri("", false, "A29ParametroId", StringUtil.LTrimStr( (decimal)(A29ParametroId), 9, 0));
         }
         if ( ! (0==AV11ParametroId) )
         {
            edtParametroId_Enabled = 0;
            AssignProp("", false, edtParametroId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroId_Enabled), 5, 0), true);
         }
         else
         {
            edtParametroId_Enabled = 1;
            AssignProp("", false, edtParametroId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV11ParametroId) )
         {
            edtParametroId_Enabled = 0;
            AssignProp("", false, edtParametroId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroId_Enabled), 5, 0), true);
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
         if ( IsIns( )  && (0==A134ParametroWebService) && ( Gx_BScreen == 0 ) )
         {
            A134ParametroWebService = 0;
            AssignAttri("", false, "A134ParametroWebService", StringUtil.Str( (decimal)(A134ParametroWebService), 1, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV14Pgmname = "Parametros";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         }
      }

      protected void Load056( )
      {
         /* Using cursor T00054 */
         pr_default.execute(2, new Object[] {A29ParametroId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound6 = 1;
            A133ParametroHoraIni = T00054_A133ParametroHoraIni[0];
            AssignAttri("", false, "A133ParametroHoraIni", A133ParametroHoraIni);
            A132ParametroHoraFin = T00054_A132ParametroHoraFin[0];
            AssignAttri("", false, "A132ParametroHoraFin", A132ParametroHoraFin);
            A129ParametroValor = T00054_A129ParametroValor[0];
            AssignAttri("", false, "A129ParametroValor", A129ParametroValor);
            A130ParametroDesc = T00054_A130ParametroDesc[0];
            AssignAttri("", false, "A130ParametroDesc", A130ParametroDesc);
            A131ParametroDescLarg = T00054_A131ParametroDescLarg[0];
            AssignAttri("", false, "A131ParametroDescLarg", A131ParametroDescLarg);
            A134ParametroWebService = T00054_A134ParametroWebService[0];
            AssignAttri("", false, "A134ParametroWebService", StringUtil.Str( (decimal)(A134ParametroWebService), 1, 0));
            A71ParametrosBloqueo = T00054_A71ParametrosBloqueo[0];
            n71ParametrosBloqueo = T00054_n71ParametrosBloqueo[0];
            AssignAttri("", false, "A71ParametrosBloqueo", StringUtil.LTrimStr( (decimal)(A71ParametrosBloqueo), 4, 0));
            A135Parametrosusername = T00054_A135Parametrosusername[0];
            n135Parametrosusername = T00054_n135Parametrosusername[0];
            AssignAttri("", false, "A135Parametrosusername", A135Parametrosusername);
            A136Parametrospassword = T00054_A136Parametrospassword[0];
            n136Parametrospassword = T00054_n136Parametrospassword[0];
            AssignAttri("", false, "A136Parametrospassword", A136Parametrospassword);
            A137ParametrosAddHeader = T00054_A137ParametrosAddHeader[0];
            n137ParametrosAddHeader = T00054_n137ParametrosAddHeader[0];
            AssignAttri("", false, "A137ParametrosAddHeader", A137ParametrosAddHeader);
            A138ParametrosHost = T00054_A138ParametrosHost[0];
            n138ParametrosHost = T00054_n138ParametrosHost[0];
            AssignAttri("", false, "A138ParametrosHost", A138ParametrosHost);
            A139ParametrosPort = T00054_A139ParametrosPort[0];
            n139ParametrosPort = T00054_n139ParametrosPort[0];
            AssignAttri("", false, "A139ParametrosPort", StringUtil.LTrimStr( (decimal)(A139ParametrosPort), 8, 0));
            A140ParametrosBaseUrl = T00054_A140ParametrosBaseUrl[0];
            n140ParametrosBaseUrl = T00054_n140ParametrosBaseUrl[0];
            AssignAttri("", false, "A140ParametrosBaseUrl", A140ParametrosBaseUrl);
            A141ParametrosExecute = T00054_A141ParametrosExecute[0];
            n141ParametrosExecute = T00054_n141ParametrosExecute[0];
            AssignAttri("", false, "A141ParametrosExecute", A141ParametrosExecute);
            A142ParametrosRuta = T00054_A142ParametrosRuta[0];
            n142ParametrosRuta = T00054_n142ParametrosRuta[0];
            AssignAttri("", false, "A142ParametrosRuta", A142ParametrosRuta);
            A143ParametrosRutaPDF = T00054_A143ParametrosRutaPDF[0];
            n143ParametrosRutaPDF = T00054_n143ParametrosRutaPDF[0];
            AssignAttri("", false, "A143ParametrosRutaPDF", A143ParametrosRutaPDF);
            ZM056( -9) ;
         }
         pr_default.close(2);
         OnLoadActions056( ) ;
      }

      protected void OnLoadActions056( )
      {
         AV14Pgmname = "Parametros";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
      }

      protected void CheckExtendedTable056( )
      {
         nIsDirty_6 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV14Pgmname = "Parametros";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A129ParametroValor)) )
         {
            GX_msglist.addItem("El valor no puede quedar vacío.", 1, "PARAMETROVALOR");
            AnyError = 1;
            GX_FocusControl = edtParametroValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A130ParametroDesc)) )
         {
            GX_msglist.addItem("La descripción no puede quedar vacía.", 1, "PARAMETRODESC");
            AnyError = 1;
            GX_FocusControl = edtParametroDesc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A131ParametroDescLarg)) )
         {
            GX_msglist.addItem("La descripción no puede quedar vacía.", 1, "PARAMETRODESCLARG");
            AnyError = 1;
            GX_FocusControl = edtParametroDescLarg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12Motivo)) && ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            GX_msglist.addItem("capture el motivo de la modificación", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors056( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey056( )
      {
         /* Using cursor T00055 */
         pr_default.execute(3, new Object[] {A29ParametroId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00053 */
         pr_default.execute(1, new Object[] {A29ParametroId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM056( 9) ;
            RcdFound6 = 1;
            A29ParametroId = T00053_A29ParametroId[0];
            AssignAttri("", false, "A29ParametroId", StringUtil.LTrimStr( (decimal)(A29ParametroId), 9, 0));
            A133ParametroHoraIni = T00053_A133ParametroHoraIni[0];
            AssignAttri("", false, "A133ParametroHoraIni", A133ParametroHoraIni);
            A132ParametroHoraFin = T00053_A132ParametroHoraFin[0];
            AssignAttri("", false, "A132ParametroHoraFin", A132ParametroHoraFin);
            A129ParametroValor = T00053_A129ParametroValor[0];
            AssignAttri("", false, "A129ParametroValor", A129ParametroValor);
            A130ParametroDesc = T00053_A130ParametroDesc[0];
            AssignAttri("", false, "A130ParametroDesc", A130ParametroDesc);
            A131ParametroDescLarg = T00053_A131ParametroDescLarg[0];
            AssignAttri("", false, "A131ParametroDescLarg", A131ParametroDescLarg);
            A134ParametroWebService = T00053_A134ParametroWebService[0];
            AssignAttri("", false, "A134ParametroWebService", StringUtil.Str( (decimal)(A134ParametroWebService), 1, 0));
            A71ParametrosBloqueo = T00053_A71ParametrosBloqueo[0];
            n71ParametrosBloqueo = T00053_n71ParametrosBloqueo[0];
            AssignAttri("", false, "A71ParametrosBloqueo", StringUtil.LTrimStr( (decimal)(A71ParametrosBloqueo), 4, 0));
            A135Parametrosusername = T00053_A135Parametrosusername[0];
            n135Parametrosusername = T00053_n135Parametrosusername[0];
            AssignAttri("", false, "A135Parametrosusername", A135Parametrosusername);
            A136Parametrospassword = T00053_A136Parametrospassword[0];
            n136Parametrospassword = T00053_n136Parametrospassword[0];
            AssignAttri("", false, "A136Parametrospassword", A136Parametrospassword);
            A137ParametrosAddHeader = T00053_A137ParametrosAddHeader[0];
            n137ParametrosAddHeader = T00053_n137ParametrosAddHeader[0];
            AssignAttri("", false, "A137ParametrosAddHeader", A137ParametrosAddHeader);
            A138ParametrosHost = T00053_A138ParametrosHost[0];
            n138ParametrosHost = T00053_n138ParametrosHost[0];
            AssignAttri("", false, "A138ParametrosHost", A138ParametrosHost);
            A139ParametrosPort = T00053_A139ParametrosPort[0];
            n139ParametrosPort = T00053_n139ParametrosPort[0];
            AssignAttri("", false, "A139ParametrosPort", StringUtil.LTrimStr( (decimal)(A139ParametrosPort), 8, 0));
            A140ParametrosBaseUrl = T00053_A140ParametrosBaseUrl[0];
            n140ParametrosBaseUrl = T00053_n140ParametrosBaseUrl[0];
            AssignAttri("", false, "A140ParametrosBaseUrl", A140ParametrosBaseUrl);
            A141ParametrosExecute = T00053_A141ParametrosExecute[0];
            n141ParametrosExecute = T00053_n141ParametrosExecute[0];
            AssignAttri("", false, "A141ParametrosExecute", A141ParametrosExecute);
            A142ParametrosRuta = T00053_A142ParametrosRuta[0];
            n142ParametrosRuta = T00053_n142ParametrosRuta[0];
            AssignAttri("", false, "A142ParametrosRuta", A142ParametrosRuta);
            A143ParametrosRutaPDF = T00053_A143ParametrosRutaPDF[0];
            n143ParametrosRutaPDF = T00053_n143ParametrosRutaPDF[0];
            AssignAttri("", false, "A143ParametrosRutaPDF", A143ParametrosRutaPDF);
            Z29ParametroId = A29ParametroId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load056( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey056( ) ;
            }
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey056( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey056( ) ;
         if ( RcdFound6 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound6 = 0;
         /* Using cursor T00056 */
         pr_default.execute(4, new Object[] {A29ParametroId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00056_A29ParametroId[0] < A29ParametroId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00056_A29ParametroId[0] > A29ParametroId ) ) )
            {
               A29ParametroId = T00056_A29ParametroId[0];
               AssignAttri("", false, "A29ParametroId", StringUtil.LTrimStr( (decimal)(A29ParametroId), 9, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound6 = 0;
         /* Using cursor T00057 */
         pr_default.execute(5, new Object[] {A29ParametroId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00057_A29ParametroId[0] > A29ParametroId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00057_A29ParametroId[0] < A29ParametroId ) ) )
            {
               A29ParametroId = T00057_A29ParametroId[0];
               AssignAttri("", false, "A29ParametroId", StringUtil.LTrimStr( (decimal)(A29ParametroId), 9, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey056( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtParametroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert056( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( A29ParametroId != Z29ParametroId )
               {
                  A29ParametroId = Z29ParametroId;
                  AssignAttri("", false, "A29ParametroId", StringUtil.LTrimStr( (decimal)(A29ParametroId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PARAMETROID");
                  AnyError = 1;
                  GX_FocusControl = edtParametroId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtParametroId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update056( ) ;
                  GX_FocusControl = edtParametroId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A29ParametroId != Z29ParametroId )
               {
                  /* Insert record */
                  GX_FocusControl = edtParametroId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert056( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PARAMETROID");
                     AnyError = 1;
                     GX_FocusControl = edtParametroId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtParametroId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert056( ) ;
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
         if ( A29ParametroId != Z29ParametroId )
         {
            A29ParametroId = Z29ParametroId;
            AssignAttri("", false, "A29ParametroId", StringUtil.LTrimStr( (decimal)(A29ParametroId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PARAMETROID");
            AnyError = 1;
            GX_FocusControl = edtParametroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtParametroId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency056( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00052 */
            pr_default.execute(0, new Object[] {A29ParametroId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Parametros"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z133ParametroHoraIni, T00052_A133ParametroHoraIni[0]) != 0 ) || ( StringUtil.StrCmp(Z132ParametroHoraFin, T00052_A132ParametroHoraFin[0]) != 0 ) || ( StringUtil.StrCmp(Z129ParametroValor, T00052_A129ParametroValor[0]) != 0 ) || ( StringUtil.StrCmp(Z130ParametroDesc, T00052_A130ParametroDesc[0]) != 0 ) || ( StringUtil.StrCmp(Z131ParametroDescLarg, T00052_A131ParametroDescLarg[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z134ParametroWebService != T00052_A134ParametroWebService[0] ) || ( Z71ParametrosBloqueo != T00052_A71ParametrosBloqueo[0] ) || ( StringUtil.StrCmp(Z135Parametrosusername, T00052_A135Parametrosusername[0]) != 0 ) || ( StringUtil.StrCmp(Z136Parametrospassword, T00052_A136Parametrospassword[0]) != 0 ) || ( StringUtil.StrCmp(Z137ParametrosAddHeader, T00052_A137ParametrosAddHeader[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z138ParametrosHost, T00052_A138ParametrosHost[0]) != 0 ) || ( Z139ParametrosPort != T00052_A139ParametrosPort[0] ) || ( StringUtil.StrCmp(Z140ParametrosBaseUrl, T00052_A140ParametrosBaseUrl[0]) != 0 ) || ( StringUtil.StrCmp(Z141ParametrosExecute, T00052_A141ParametrosExecute[0]) != 0 ) || ( StringUtil.StrCmp(Z142ParametrosRuta, T00052_A142ParametrosRuta[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z143ParametrosRutaPDF, T00052_A143ParametrosRutaPDF[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z133ParametroHoraIni, T00052_A133ParametroHoraIni[0]) != 0 )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametroHoraIni");
                  GXUtil.WriteLogRaw("Old: ",Z133ParametroHoraIni);
                  GXUtil.WriteLogRaw("Current: ",T00052_A133ParametroHoraIni[0]);
               }
               if ( StringUtil.StrCmp(Z132ParametroHoraFin, T00052_A132ParametroHoraFin[0]) != 0 )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametroHoraFin");
                  GXUtil.WriteLogRaw("Old: ",Z132ParametroHoraFin);
                  GXUtil.WriteLogRaw("Current: ",T00052_A132ParametroHoraFin[0]);
               }
               if ( StringUtil.StrCmp(Z129ParametroValor, T00052_A129ParametroValor[0]) != 0 )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametroValor");
                  GXUtil.WriteLogRaw("Old: ",Z129ParametroValor);
                  GXUtil.WriteLogRaw("Current: ",T00052_A129ParametroValor[0]);
               }
               if ( StringUtil.StrCmp(Z130ParametroDesc, T00052_A130ParametroDesc[0]) != 0 )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametroDesc");
                  GXUtil.WriteLogRaw("Old: ",Z130ParametroDesc);
                  GXUtil.WriteLogRaw("Current: ",T00052_A130ParametroDesc[0]);
               }
               if ( StringUtil.StrCmp(Z131ParametroDescLarg, T00052_A131ParametroDescLarg[0]) != 0 )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametroDescLarg");
                  GXUtil.WriteLogRaw("Old: ",Z131ParametroDescLarg);
                  GXUtil.WriteLogRaw("Current: ",T00052_A131ParametroDescLarg[0]);
               }
               if ( Z134ParametroWebService != T00052_A134ParametroWebService[0] )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametroWebService");
                  GXUtil.WriteLogRaw("Old: ",Z134ParametroWebService);
                  GXUtil.WriteLogRaw("Current: ",T00052_A134ParametroWebService[0]);
               }
               if ( Z71ParametrosBloqueo != T00052_A71ParametrosBloqueo[0] )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametrosBloqueo");
                  GXUtil.WriteLogRaw("Old: ",Z71ParametrosBloqueo);
                  GXUtil.WriteLogRaw("Current: ",T00052_A71ParametrosBloqueo[0]);
               }
               if ( StringUtil.StrCmp(Z135Parametrosusername, T00052_A135Parametrosusername[0]) != 0 )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"Parametrosusername");
                  GXUtil.WriteLogRaw("Old: ",Z135Parametrosusername);
                  GXUtil.WriteLogRaw("Current: ",T00052_A135Parametrosusername[0]);
               }
               if ( StringUtil.StrCmp(Z136Parametrospassword, T00052_A136Parametrospassword[0]) != 0 )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"Parametrospassword");
                  GXUtil.WriteLogRaw("Old: ",Z136Parametrospassword);
                  GXUtil.WriteLogRaw("Current: ",T00052_A136Parametrospassword[0]);
               }
               if ( StringUtil.StrCmp(Z137ParametrosAddHeader, T00052_A137ParametrosAddHeader[0]) != 0 )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametrosAddHeader");
                  GXUtil.WriteLogRaw("Old: ",Z137ParametrosAddHeader);
                  GXUtil.WriteLogRaw("Current: ",T00052_A137ParametrosAddHeader[0]);
               }
               if ( StringUtil.StrCmp(Z138ParametrosHost, T00052_A138ParametrosHost[0]) != 0 )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametrosHost");
                  GXUtil.WriteLogRaw("Old: ",Z138ParametrosHost);
                  GXUtil.WriteLogRaw("Current: ",T00052_A138ParametrosHost[0]);
               }
               if ( Z139ParametrosPort != T00052_A139ParametrosPort[0] )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametrosPort");
                  GXUtil.WriteLogRaw("Old: ",Z139ParametrosPort);
                  GXUtil.WriteLogRaw("Current: ",T00052_A139ParametrosPort[0]);
               }
               if ( StringUtil.StrCmp(Z140ParametrosBaseUrl, T00052_A140ParametrosBaseUrl[0]) != 0 )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametrosBaseUrl");
                  GXUtil.WriteLogRaw("Old: ",Z140ParametrosBaseUrl);
                  GXUtil.WriteLogRaw("Current: ",T00052_A140ParametrosBaseUrl[0]);
               }
               if ( StringUtil.StrCmp(Z141ParametrosExecute, T00052_A141ParametrosExecute[0]) != 0 )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametrosExecute");
                  GXUtil.WriteLogRaw("Old: ",Z141ParametrosExecute);
                  GXUtil.WriteLogRaw("Current: ",T00052_A141ParametrosExecute[0]);
               }
               if ( StringUtil.StrCmp(Z142ParametrosRuta, T00052_A142ParametrosRuta[0]) != 0 )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametrosRuta");
                  GXUtil.WriteLogRaw("Old: ",Z142ParametrosRuta);
                  GXUtil.WriteLogRaw("Current: ",T00052_A142ParametrosRuta[0]);
               }
               if ( StringUtil.StrCmp(Z143ParametrosRutaPDF, T00052_A143ParametrosRutaPDF[0]) != 0 )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametrosRutaPDF");
                  GXUtil.WriteLogRaw("Old: ",Z143ParametrosRutaPDF);
                  GXUtil.WriteLogRaw("Current: ",T00052_A143ParametrosRutaPDF[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Parametros"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert056( )
      {
         BeforeValidate056( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable056( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM056( 0) ;
            CheckOptimisticConcurrency056( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm056( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert056( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00058 */
                     pr_default.execute(6, new Object[] {A29ParametroId, A133ParametroHoraIni, A132ParametroHoraFin, A129ParametroValor, A130ParametroDesc, A131ParametroDescLarg, A134ParametroWebService, n71ParametrosBloqueo, A71ParametrosBloqueo, n135Parametrosusername, A135Parametrosusername, n136Parametrospassword, A136Parametrospassword, n137ParametrosAddHeader, A137ParametrosAddHeader, n138ParametrosHost, A138ParametrosHost, n139ParametrosPort, A139ParametrosPort, n140ParametrosBaseUrl, A140ParametrosBaseUrl, n141ParametrosExecute, A141ParametrosExecute, n142ParametrosRuta, A142ParametrosRuta, n143ParametrosRutaPDF, A143ParametrosRutaPDF});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Parametros") ;
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
                           ResetCaption050( ) ;
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
               Load056( ) ;
            }
            EndLevel056( ) ;
         }
         CloseExtendedTableCursors056( ) ;
      }

      protected void Update056( )
      {
         BeforeValidate056( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable056( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency056( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm056( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate056( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00059 */
                     pr_default.execute(7, new Object[] {A133ParametroHoraIni, A132ParametroHoraFin, A129ParametroValor, A130ParametroDesc, A131ParametroDescLarg, A134ParametroWebService, n71ParametrosBloqueo, A71ParametrosBloqueo, n135Parametrosusername, A135Parametrosusername, n136Parametrospassword, A136Parametrospassword, n137ParametrosAddHeader, A137ParametrosAddHeader, n138ParametrosHost, A138ParametrosHost, n139ParametrosPort, A139ParametrosPort, n140ParametrosBaseUrl, A140ParametrosBaseUrl, n141ParametrosExecute, A141ParametrosExecute, n142ParametrosRuta, A142ParametrosRuta, n143ParametrosRutaPDF, A143ParametrosRutaPDF, A29ParametroId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("Parametros") ;
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Parametros"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate056( ) ;
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
            EndLevel056( ) ;
         }
         CloseExtendedTableCursors056( ) ;
      }

      protected void DeferredUpdate056( )
      {
      }

      protected void delete( )
      {
         BeforeValidate056( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency056( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls056( ) ;
            AfterConfirm056( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete056( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000510 */
                  pr_default.execute(8, new Object[] {A29ParametroId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("Parametros") ;
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel056( ) ;
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls056( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV14Pgmname = "Parametros";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         }
      }

      protected void EndLevel056( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete056( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("parametros",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues050( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("parametros",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart056( )
      {
         /* Scan By routine */
         /* Using cursor T000511 */
         pr_default.execute(9);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound6 = 1;
            A29ParametroId = T000511_A29ParametroId[0];
            AssignAttri("", false, "A29ParametroId", StringUtil.LTrimStr( (decimal)(A29ParametroId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext056( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound6 = 1;
            A29ParametroId = T000511_A29ParametroId[0];
            AssignAttri("", false, "A29ParametroId", StringUtil.LTrimStr( (decimal)(A29ParametroId), 9, 0));
         }
      }

      protected void ScanEnd056( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm056( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert056( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate056( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete056( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete056( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate056( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes056( )
      {
         edtParametroId_Enabled = 0;
         AssignProp("", false, edtParametroId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroId_Enabled), 5, 0), true);
         edtParametroHoraIni_Enabled = 0;
         AssignProp("", false, edtParametroHoraIni_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroHoraIni_Enabled), 5, 0), true);
         edtParametroHoraFin_Enabled = 0;
         AssignProp("", false, edtParametroHoraFin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroHoraFin_Enabled), 5, 0), true);
         edtParametroValor_Enabled = 0;
         AssignProp("", false, edtParametroValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroValor_Enabled), 5, 0), true);
         edtParametroDesc_Enabled = 0;
         AssignProp("", false, edtParametroDesc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroDesc_Enabled), 5, 0), true);
         edtParametroDescLarg_Enabled = 0;
         AssignProp("", false, edtParametroDescLarg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroDescLarg_Enabled), 5, 0), true);
         chkParametroWebService.Enabled = 0;
         AssignProp("", false, chkParametroWebService_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkParametroWebService.Enabled), 5, 0), true);
         edtParametrosBloqueo_Enabled = 0;
         AssignProp("", false, edtParametrosBloqueo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametrosBloqueo_Enabled), 5, 0), true);
         edtParametrosusername_Enabled = 0;
         AssignProp("", false, edtParametrosusername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametrosusername_Enabled), 5, 0), true);
         edtParametrospassword_Enabled = 0;
         AssignProp("", false, edtParametrospassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametrospassword_Enabled), 5, 0), true);
         edtParametrosAddHeader_Enabled = 0;
         AssignProp("", false, edtParametrosAddHeader_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametrosAddHeader_Enabled), 5, 0), true);
         edtParametrosHost_Enabled = 0;
         AssignProp("", false, edtParametrosHost_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametrosHost_Enabled), 5, 0), true);
         edtParametrosPort_Enabled = 0;
         AssignProp("", false, edtParametrosPort_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametrosPort_Enabled), 5, 0), true);
         edtParametrosBaseUrl_Enabled = 0;
         AssignProp("", false, edtParametrosBaseUrl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametrosBaseUrl_Enabled), 5, 0), true);
         edtParametrosExecute_Enabled = 0;
         AssignProp("", false, edtParametrosExecute_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametrosExecute_Enabled), 5, 0), true);
         edtParametrosRuta_Enabled = 0;
         AssignProp("", false, edtParametrosRuta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametrosRuta_Enabled), 5, 0), true);
         edtParametrosRutaPDF_Enabled = 0;
         AssignProp("", false, edtParametrosRutaPDF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametrosRutaPDF_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes056( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues050( )
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
         context.AddJavascriptSource("gxcfg.js", "?202262714343775", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("parametros.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode("" +AV11ParametroId)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Parametros");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("parametros:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z29ParametroId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29ParametroId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z133ParametroHoraIni", StringUtil.RTrim( Z133ParametroHoraIni));
         GxWebStd.gx_hidden_field( context, "Z132ParametroHoraFin", StringUtil.RTrim( Z132ParametroHoraFin));
         GxWebStd.gx_hidden_field( context, "Z129ParametroValor", Z129ParametroValor);
         GxWebStd.gx_hidden_field( context, "Z130ParametroDesc", Z130ParametroDesc);
         GxWebStd.gx_hidden_field( context, "Z131ParametroDescLarg", Z131ParametroDescLarg);
         GxWebStd.gx_hidden_field( context, "Z134ParametroWebService", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z134ParametroWebService), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z71ParametrosBloqueo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z71ParametrosBloqueo), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z135Parametrosusername", Z135Parametrosusername);
         GxWebStd.gx_hidden_field( context, "Z136Parametrospassword", Z136Parametrospassword);
         GxWebStd.gx_hidden_field( context, "Z137ParametrosAddHeader", Z137ParametrosAddHeader);
         GxWebStd.gx_hidden_field( context, "Z138ParametrosHost", Z138ParametrosHost);
         GxWebStd.gx_hidden_field( context, "Z139ParametrosPort", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z139ParametrosPort), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z140ParametrosBaseUrl", Z140ParametrosBaseUrl);
         GxWebStd.gx_hidden_field( context, "Z141ParametrosExecute", StringUtil.RTrim( Z141ParametrosExecute));
         GxWebStd.gx_hidden_field( context, "Z142ParametrosRuta", Z142ParametrosRuta);
         GxWebStd.gx_hidden_field( context, "Z143ParametrosRutaPDF", Z143ParametrosRutaPDF);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vPARAMETROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11ParametroId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPARAMETROID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11ParametroId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMOTIVO", AV12Motivo);
         GxWebStd.gx_hidden_field( context, "gxhash_vMOTIVO", GetSecureSignedToken( "", AV12Motivo, context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV14Pgmname));
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
         return formatLink("parametros.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode("" +AV11ParametroId) ;
      }

      public override String GetPgmname( )
      {
         return "Parametros" ;
      }

      public override String GetPgmdesc( )
      {
         return "Parametros" ;
      }

      protected void InitializeNonKey056( )
      {
         AV12Motivo = "";
         AssignAttri("", false, "AV12Motivo", AV12Motivo);
         GxWebStd.gx_hidden_field( context, "gxhash_vMOTIVO", GetSecureSignedToken( "", AV12Motivo, context));
         A133ParametroHoraIni = "";
         AssignAttri("", false, "A133ParametroHoraIni", A133ParametroHoraIni);
         A132ParametroHoraFin = "";
         AssignAttri("", false, "A132ParametroHoraFin", A132ParametroHoraFin);
         A129ParametroValor = "";
         AssignAttri("", false, "A129ParametroValor", A129ParametroValor);
         A130ParametroDesc = "";
         AssignAttri("", false, "A130ParametroDesc", A130ParametroDesc);
         A131ParametroDescLarg = "";
         AssignAttri("", false, "A131ParametroDescLarg", A131ParametroDescLarg);
         A71ParametrosBloqueo = 0;
         n71ParametrosBloqueo = false;
         AssignAttri("", false, "A71ParametrosBloqueo", StringUtil.LTrimStr( (decimal)(A71ParametrosBloqueo), 4, 0));
         n71ParametrosBloqueo = ((0==A71ParametrosBloqueo) ? true : false);
         A135Parametrosusername = "";
         n135Parametrosusername = false;
         AssignAttri("", false, "A135Parametrosusername", A135Parametrosusername);
         n135Parametrosusername = (String.IsNullOrEmpty(StringUtil.RTrim( A135Parametrosusername)) ? true : false);
         A136Parametrospassword = "";
         n136Parametrospassword = false;
         AssignAttri("", false, "A136Parametrospassword", A136Parametrospassword);
         n136Parametrospassword = (String.IsNullOrEmpty(StringUtil.RTrim( A136Parametrospassword)) ? true : false);
         A137ParametrosAddHeader = "";
         n137ParametrosAddHeader = false;
         AssignAttri("", false, "A137ParametrosAddHeader", A137ParametrosAddHeader);
         n137ParametrosAddHeader = (String.IsNullOrEmpty(StringUtil.RTrim( A137ParametrosAddHeader)) ? true : false);
         A138ParametrosHost = "";
         n138ParametrosHost = false;
         AssignAttri("", false, "A138ParametrosHost", A138ParametrosHost);
         n138ParametrosHost = (String.IsNullOrEmpty(StringUtil.RTrim( A138ParametrosHost)) ? true : false);
         A139ParametrosPort = 0;
         n139ParametrosPort = false;
         AssignAttri("", false, "A139ParametrosPort", StringUtil.LTrimStr( (decimal)(A139ParametrosPort), 8, 0));
         n139ParametrosPort = ((0==A139ParametrosPort) ? true : false);
         A140ParametrosBaseUrl = "";
         n140ParametrosBaseUrl = false;
         AssignAttri("", false, "A140ParametrosBaseUrl", A140ParametrosBaseUrl);
         n140ParametrosBaseUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A140ParametrosBaseUrl)) ? true : false);
         A141ParametrosExecute = "";
         n141ParametrosExecute = false;
         AssignAttri("", false, "A141ParametrosExecute", A141ParametrosExecute);
         n141ParametrosExecute = (String.IsNullOrEmpty(StringUtil.RTrim( A141ParametrosExecute)) ? true : false);
         A142ParametrosRuta = "";
         n142ParametrosRuta = false;
         AssignAttri("", false, "A142ParametrosRuta", A142ParametrosRuta);
         n142ParametrosRuta = (String.IsNullOrEmpty(StringUtil.RTrim( A142ParametrosRuta)) ? true : false);
         A143ParametrosRutaPDF = "";
         n143ParametrosRutaPDF = false;
         AssignAttri("", false, "A143ParametrosRutaPDF", A143ParametrosRutaPDF);
         n143ParametrosRutaPDF = (String.IsNullOrEmpty(StringUtil.RTrim( A143ParametrosRutaPDF)) ? true : false);
         A134ParametroWebService = 0;
         AssignAttri("", false, "A134ParametroWebService", StringUtil.Str( (decimal)(A134ParametroWebService), 1, 0));
         Z133ParametroHoraIni = "";
         Z132ParametroHoraFin = "";
         Z129ParametroValor = "";
         Z130ParametroDesc = "";
         Z131ParametroDescLarg = "";
         Z134ParametroWebService = 0;
         Z71ParametrosBloqueo = 0;
         Z135Parametrosusername = "";
         Z136Parametrospassword = "";
         Z137ParametrosAddHeader = "";
         Z138ParametrosHost = "";
         Z139ParametrosPort = 0;
         Z140ParametrosBaseUrl = "";
         Z141ParametrosExecute = "";
         Z142ParametrosRuta = "";
         Z143ParametrosRutaPDF = "";
      }

      protected void InitAll056( )
      {
         A29ParametroId = 0;
         AssignAttri("", false, "A29ParametroId", StringUtil.LTrimStr( (decimal)(A29ParametroId), 9, 0));
         InitializeNonKey056( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A134ParametroWebService = i134ParametroWebService;
         AssignAttri("", false, "A134ParametroWebService", StringUtil.Str( (decimal)(A134ParametroWebService), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714343786", true, true);
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
         context.AddJavascriptSource("parametros.js", "?202262714343786", false, true);
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
         edtParametroId_Internalname = "PARAMETROID";
         edtParametroHoraIni_Internalname = "PARAMETROHORAINI";
         edtParametroHoraFin_Internalname = "PARAMETROHORAFIN";
         edtParametroValor_Internalname = "PARAMETROVALOR";
         edtParametroDesc_Internalname = "PARAMETRODESC";
         edtParametroDescLarg_Internalname = "PARAMETRODESCLARG";
         chkParametroWebService_Internalname = "PARAMETROWEBSERVICE";
         edtParametrosBloqueo_Internalname = "PARAMETROSBLOQUEO";
         edtParametrosusername_Internalname = "PARAMETROSUSERNAME";
         edtParametrospassword_Internalname = "PARAMETROSPASSWORD";
         edtParametrosAddHeader_Internalname = "PARAMETROSADDHEADER";
         edtParametrosHost_Internalname = "PARAMETROSHOST";
         edtParametrosPort_Internalname = "PARAMETROSPORT";
         edtParametrosBaseUrl_Internalname = "PARAMETROSBASEURL";
         edtParametrosExecute_Internalname = "PARAMETROSEXECUTE";
         edtParametrosRuta_Internalname = "PARAMETROSRUTA";
         edtParametrosRutaPDF_Internalname = "PARAMETROSRUTAPDF";
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
         Form.Caption = "Parametros";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtParametrosRutaPDF_Enabled = 1;
         edtParametrosRuta_Jsonclick = "";
         edtParametrosRuta_Enabled = 1;
         edtParametrosExecute_Jsonclick = "";
         edtParametrosExecute_Enabled = 1;
         edtParametrosBaseUrl_Jsonclick = "";
         edtParametrosBaseUrl_Enabled = 1;
         edtParametrosPort_Jsonclick = "";
         edtParametrosPort_Enabled = 1;
         edtParametrosHost_Jsonclick = "";
         edtParametrosHost_Enabled = 1;
         edtParametrosAddHeader_Enabled = 1;
         edtParametrospassword_Jsonclick = "";
         edtParametrospassword_Enabled = 1;
         edtParametrosusername_Jsonclick = "";
         edtParametrosusername_Enabled = 1;
         edtParametrosBloqueo_Jsonclick = "";
         edtParametrosBloqueo_Enabled = 1;
         chkParametroWebService.Enabled = 1;
         edtParametroDescLarg_Enabled = 1;
         edtParametroDesc_Jsonclick = "";
         edtParametroDesc_Enabled = 1;
         edtParametroValor_Enabled = 1;
         edtParametroHoraFin_Jsonclick = "";
         edtParametroHoraFin_Enabled = 1;
         edtParametroHoraIni_Jsonclick = "";
         edtParametroHoraIni_Enabled = 1;
         edtParametroId_Jsonclick = "";
         edtParametroId_Enabled = 1;
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
         chkParametroWebService.Name = "PARAMETROWEBSERVICE";
         chkParametroWebService.WebTags = "";
         chkParametroWebService.Caption = "";
         AssignProp("", false, chkParametroWebService_Internalname, "TitleCaption", chkParametroWebService.Caption, true);
         chkParametroWebService.CheckedValue = "0";
         if ( (0==A134ParametroWebService) )
         {
            A134ParametroWebService = 0;
            AssignAttri("", false, "A134ParametroWebService", StringUtil.Str( (decimal)(A134ParametroWebService), 1, 0));
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11ParametroId',fld:'vPARAMETROID',pic:'ZZZZZZZZ9',hsh:true},{av:'A134ParametroWebService',fld:'PARAMETROWEBSERVICE',pic:'9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A134ParametroWebService',fld:'PARAMETROWEBSERVICE',pic:'9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV11ParametroId',fld:'vPARAMETROID',pic:'ZZZZZZZZ9',hsh:true},{av:'AV12Motivo',fld:'vMOTIVO',pic:'',hsh:true},{av:'A134ParametroWebService',fld:'PARAMETROWEBSERVICE',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A134ParametroWebService',fld:'PARAMETROWEBSERVICE',pic:'9'}]}");
         setEventMetadata("AFTER TRN","{handler:'E12052',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV12Motivo',fld:'vMOTIVO',pic:'',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A134ParametroWebService',fld:'PARAMETROWEBSERVICE',pic:'9'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A134ParametroWebService',fld:'PARAMETROWEBSERVICE',pic:'9'}]}");
         setEventMetadata("VALID_PARAMETROID","{handler:'Valid_Parametroid',iparms:[{av:'A134ParametroWebService',fld:'PARAMETROWEBSERVICE',pic:'9'}]");
         setEventMetadata("VALID_PARAMETROID",",oparms:[{av:'A134ParametroWebService',fld:'PARAMETROWEBSERVICE',pic:'9'}]}");
         setEventMetadata("VALID_PARAMETROVALOR","{handler:'Valid_Parametrovalor',iparms:[{av:'A134ParametroWebService',fld:'PARAMETROWEBSERVICE',pic:'9'}]");
         setEventMetadata("VALID_PARAMETROVALOR",",oparms:[{av:'A134ParametroWebService',fld:'PARAMETROWEBSERVICE',pic:'9'}]}");
         setEventMetadata("VALID_PARAMETRODESC","{handler:'Valid_Parametrodesc',iparms:[{av:'A134ParametroWebService',fld:'PARAMETROWEBSERVICE',pic:'9'}]");
         setEventMetadata("VALID_PARAMETRODESC",",oparms:[{av:'A134ParametroWebService',fld:'PARAMETROWEBSERVICE',pic:'9'}]}");
         setEventMetadata("VALID_PARAMETRODESCLARG","{handler:'Valid_Parametrodesclarg',iparms:[{av:'A134ParametroWebService',fld:'PARAMETROWEBSERVICE',pic:'9'}]");
         setEventMetadata("VALID_PARAMETRODESCLARG",",oparms:[{av:'A134ParametroWebService',fld:'PARAMETROWEBSERVICE',pic:'9'}]}");
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
         Z133ParametroHoraIni = "";
         Z132ParametroHoraFin = "";
         Z129ParametroValor = "";
         Z130ParametroDesc = "";
         Z131ParametroDescLarg = "";
         Z135Parametrosusername = "";
         Z136Parametrospassword = "";
         Z137ParametrosAddHeader = "";
         Z138ParametrosHost = "";
         Z140ParametrosBaseUrl = "";
         Z141ParametrosExecute = "";
         Z142ParametrosRuta = "";
         Z143ParametrosRutaPDF = "";
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
         A133ParametroHoraIni = "";
         A132ParametroHoraFin = "";
         A129ParametroValor = "";
         A130ParametroDesc = "";
         A131ParametroDescLarg = "";
         A135Parametrosusername = "";
         A136Parametrospassword = "";
         A137ParametrosAddHeader = "";
         A138ParametrosHost = "";
         A140ParametrosBaseUrl = "";
         A141ParametrosExecute = "";
         A142ParametrosRuta = "";
         A143ParametrosRutaPDF = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV12Motivo = "";
         AV14Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode6 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13Fechahora = (DateTime)(DateTime.MinValue);
         T00054_A29ParametroId = new int[1] ;
         T00054_A133ParametroHoraIni = new String[] {""} ;
         T00054_A132ParametroHoraFin = new String[] {""} ;
         T00054_A129ParametroValor = new String[] {""} ;
         T00054_A130ParametroDesc = new String[] {""} ;
         T00054_A131ParametroDescLarg = new String[] {""} ;
         T00054_A134ParametroWebService = new short[1] ;
         T00054_A71ParametrosBloqueo = new short[1] ;
         T00054_n71ParametrosBloqueo = new bool[] {false} ;
         T00054_A135Parametrosusername = new String[] {""} ;
         T00054_n135Parametrosusername = new bool[] {false} ;
         T00054_A136Parametrospassword = new String[] {""} ;
         T00054_n136Parametrospassword = new bool[] {false} ;
         T00054_A137ParametrosAddHeader = new String[] {""} ;
         T00054_n137ParametrosAddHeader = new bool[] {false} ;
         T00054_A138ParametrosHost = new String[] {""} ;
         T00054_n138ParametrosHost = new bool[] {false} ;
         T00054_A139ParametrosPort = new int[1] ;
         T00054_n139ParametrosPort = new bool[] {false} ;
         T00054_A140ParametrosBaseUrl = new String[] {""} ;
         T00054_n140ParametrosBaseUrl = new bool[] {false} ;
         T00054_A141ParametrosExecute = new String[] {""} ;
         T00054_n141ParametrosExecute = new bool[] {false} ;
         T00054_A142ParametrosRuta = new String[] {""} ;
         T00054_n142ParametrosRuta = new bool[] {false} ;
         T00054_A143ParametrosRutaPDF = new String[] {""} ;
         T00054_n143ParametrosRutaPDF = new bool[] {false} ;
         T00055_A29ParametroId = new int[1] ;
         T00053_A29ParametroId = new int[1] ;
         T00053_A133ParametroHoraIni = new String[] {""} ;
         T00053_A132ParametroHoraFin = new String[] {""} ;
         T00053_A129ParametroValor = new String[] {""} ;
         T00053_A130ParametroDesc = new String[] {""} ;
         T00053_A131ParametroDescLarg = new String[] {""} ;
         T00053_A134ParametroWebService = new short[1] ;
         T00053_A71ParametrosBloqueo = new short[1] ;
         T00053_n71ParametrosBloqueo = new bool[] {false} ;
         T00053_A135Parametrosusername = new String[] {""} ;
         T00053_n135Parametrosusername = new bool[] {false} ;
         T00053_A136Parametrospassword = new String[] {""} ;
         T00053_n136Parametrospassword = new bool[] {false} ;
         T00053_A137ParametrosAddHeader = new String[] {""} ;
         T00053_n137ParametrosAddHeader = new bool[] {false} ;
         T00053_A138ParametrosHost = new String[] {""} ;
         T00053_n138ParametrosHost = new bool[] {false} ;
         T00053_A139ParametrosPort = new int[1] ;
         T00053_n139ParametrosPort = new bool[] {false} ;
         T00053_A140ParametrosBaseUrl = new String[] {""} ;
         T00053_n140ParametrosBaseUrl = new bool[] {false} ;
         T00053_A141ParametrosExecute = new String[] {""} ;
         T00053_n141ParametrosExecute = new bool[] {false} ;
         T00053_A142ParametrosRuta = new String[] {""} ;
         T00053_n142ParametrosRuta = new bool[] {false} ;
         T00053_A143ParametrosRutaPDF = new String[] {""} ;
         T00053_n143ParametrosRutaPDF = new bool[] {false} ;
         T00056_A29ParametroId = new int[1] ;
         T00057_A29ParametroId = new int[1] ;
         T00052_A29ParametroId = new int[1] ;
         T00052_A133ParametroHoraIni = new String[] {""} ;
         T00052_A132ParametroHoraFin = new String[] {""} ;
         T00052_A129ParametroValor = new String[] {""} ;
         T00052_A130ParametroDesc = new String[] {""} ;
         T00052_A131ParametroDescLarg = new String[] {""} ;
         T00052_A134ParametroWebService = new short[1] ;
         T00052_A71ParametrosBloqueo = new short[1] ;
         T00052_n71ParametrosBloqueo = new bool[] {false} ;
         T00052_A135Parametrosusername = new String[] {""} ;
         T00052_n135Parametrosusername = new bool[] {false} ;
         T00052_A136Parametrospassword = new String[] {""} ;
         T00052_n136Parametrospassword = new bool[] {false} ;
         T00052_A137ParametrosAddHeader = new String[] {""} ;
         T00052_n137ParametrosAddHeader = new bool[] {false} ;
         T00052_A138ParametrosHost = new String[] {""} ;
         T00052_n138ParametrosHost = new bool[] {false} ;
         T00052_A139ParametrosPort = new int[1] ;
         T00052_n139ParametrosPort = new bool[] {false} ;
         T00052_A140ParametrosBaseUrl = new String[] {""} ;
         T00052_n140ParametrosBaseUrl = new bool[] {false} ;
         T00052_A141ParametrosExecute = new String[] {""} ;
         T00052_n141ParametrosExecute = new bool[] {false} ;
         T00052_A142ParametrosRuta = new String[] {""} ;
         T00052_n142ParametrosRuta = new bool[] {false} ;
         T00052_A143ParametrosRutaPDF = new String[] {""} ;
         T00052_n143ParametrosRutaPDF = new bool[] {false} ;
         T000511_A29ParametroId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.parametros__default(),
            new Object[][] {
                new Object[] {
               T00052_A29ParametroId, T00052_A133ParametroHoraIni, T00052_A132ParametroHoraFin, T00052_A129ParametroValor, T00052_A130ParametroDesc, T00052_A131ParametroDescLarg, T00052_A134ParametroWebService, T00052_A71ParametrosBloqueo, T00052_n71ParametrosBloqueo, T00052_A135Parametrosusername,
               T00052_n135Parametrosusername, T00052_A136Parametrospassword, T00052_n136Parametrospassword, T00052_A137ParametrosAddHeader, T00052_n137ParametrosAddHeader, T00052_A138ParametrosHost, T00052_n138ParametrosHost, T00052_A139ParametrosPort, T00052_n139ParametrosPort, T00052_A140ParametrosBaseUrl,
               T00052_n140ParametrosBaseUrl, T00052_A141ParametrosExecute, T00052_n141ParametrosExecute, T00052_A142ParametrosRuta, T00052_n142ParametrosRuta, T00052_A143ParametrosRutaPDF, T00052_n143ParametrosRutaPDF
               }
               , new Object[] {
               T00053_A29ParametroId, T00053_A133ParametroHoraIni, T00053_A132ParametroHoraFin, T00053_A129ParametroValor, T00053_A130ParametroDesc, T00053_A131ParametroDescLarg, T00053_A134ParametroWebService, T00053_A71ParametrosBloqueo, T00053_n71ParametrosBloqueo, T00053_A135Parametrosusername,
               T00053_n135Parametrosusername, T00053_A136Parametrospassword, T00053_n136Parametrospassword, T00053_A137ParametrosAddHeader, T00053_n137ParametrosAddHeader, T00053_A138ParametrosHost, T00053_n138ParametrosHost, T00053_A139ParametrosPort, T00053_n139ParametrosPort, T00053_A140ParametrosBaseUrl,
               T00053_n140ParametrosBaseUrl, T00053_A141ParametrosExecute, T00053_n141ParametrosExecute, T00053_A142ParametrosRuta, T00053_n142ParametrosRuta, T00053_A143ParametrosRutaPDF, T00053_n143ParametrosRutaPDF
               }
               , new Object[] {
               T00054_A29ParametroId, T00054_A133ParametroHoraIni, T00054_A132ParametroHoraFin, T00054_A129ParametroValor, T00054_A130ParametroDesc, T00054_A131ParametroDescLarg, T00054_A134ParametroWebService, T00054_A71ParametrosBloqueo, T00054_n71ParametrosBloqueo, T00054_A135Parametrosusername,
               T00054_n135Parametrosusername, T00054_A136Parametrospassword, T00054_n136Parametrospassword, T00054_A137ParametrosAddHeader, T00054_n137ParametrosAddHeader, T00054_A138ParametrosHost, T00054_n138ParametrosHost, T00054_A139ParametrosPort, T00054_n139ParametrosPort, T00054_A140ParametrosBaseUrl,
               T00054_n140ParametrosBaseUrl, T00054_A141ParametrosExecute, T00054_n141ParametrosExecute, T00054_A142ParametrosRuta, T00054_n142ParametrosRuta, T00054_A143ParametrosRutaPDF, T00054_n143ParametrosRutaPDF
               }
               , new Object[] {
               T00055_A29ParametroId
               }
               , new Object[] {
               T00056_A29ParametroId
               }
               , new Object[] {
               T00057_A29ParametroId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000511_A29ParametroId
               }
            }
         );
         Z134ParametroWebService = 0;
         A134ParametroWebService = 0;
         i134ParametroWebService = 0;
         AV14Pgmname = "Parametros";
      }

      private short Z134ParametroWebService ;
      private short Z71ParametrosBloqueo ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A134ParametroWebService ;
      private short A71ParametrosBloqueo ;
      private short Gx_BScreen ;
      private short RcdFound6 ;
      private short GX_JID ;
      private short nIsDirty_6 ;
      private short gxajaxcallmode ;
      private short i134ParametroWebService ;
      private int wcpOAV11ParametroId ;
      private int Z29ParametroId ;
      private int Z139ParametrosPort ;
      private int AV11ParametroId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A29ParametroId ;
      private int edtParametroId_Enabled ;
      private int edtParametroHoraIni_Enabled ;
      private int edtParametroHoraFin_Enabled ;
      private int edtParametroValor_Enabled ;
      private int edtParametroDesc_Enabled ;
      private int edtParametroDescLarg_Enabled ;
      private int edtParametrosBloqueo_Enabled ;
      private int edtParametrosusername_Enabled ;
      private int edtParametrospassword_Enabled ;
      private int edtParametrosAddHeader_Enabled ;
      private int edtParametrosHost_Enabled ;
      private int A139ParametrosPort ;
      private int edtParametrosPort_Enabled ;
      private int edtParametrosBaseUrl_Enabled ;
      private int edtParametrosExecute_Enabled ;
      private int edtParametrosRuta_Enabled ;
      private int edtParametrosRutaPDF_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private String sPrefix ;
      private String wcpOGx_mode ;
      private String Z133ParametroHoraIni ;
      private String Z132ParametroHoraFin ;
      private String Z141ParametrosExecute ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String Gx_mode ;
      private String GXKey ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String GX_FocusControl ;
      private String edtParametroId_Internalname ;
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
      private String edtParametroId_Jsonclick ;
      private String edtParametroHoraIni_Internalname ;
      private String A133ParametroHoraIni ;
      private String edtParametroHoraIni_Jsonclick ;
      private String edtParametroHoraFin_Internalname ;
      private String A132ParametroHoraFin ;
      private String edtParametroHoraFin_Jsonclick ;
      private String edtParametroValor_Internalname ;
      private String edtParametroDesc_Internalname ;
      private String edtParametroDesc_Jsonclick ;
      private String edtParametroDescLarg_Internalname ;
      private String chkParametroWebService_Internalname ;
      private String edtParametrosBloqueo_Internalname ;
      private String edtParametrosBloqueo_Jsonclick ;
      private String edtParametrosusername_Internalname ;
      private String edtParametrosusername_Jsonclick ;
      private String edtParametrospassword_Internalname ;
      private String edtParametrospassword_Jsonclick ;
      private String edtParametrosAddHeader_Internalname ;
      private String edtParametrosHost_Internalname ;
      private String edtParametrosHost_Jsonclick ;
      private String edtParametrosPort_Internalname ;
      private String edtParametrosPort_Jsonclick ;
      private String edtParametrosBaseUrl_Internalname ;
      private String edtParametrosBaseUrl_Jsonclick ;
      private String edtParametrosExecute_Internalname ;
      private String A141ParametrosExecute ;
      private String edtParametrosExecute_Jsonclick ;
      private String edtParametrosRuta_Internalname ;
      private String edtParametrosRuta_Jsonclick ;
      private String edtParametrosRutaPDF_Internalname ;
      private String bttBtn_enter_Internalname ;
      private String bttBtn_enter_Jsonclick ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String bttBtn_delete_Internalname ;
      private String bttBtn_delete_Jsonclick ;
      private String AV14Pgmname ;
      private String hsh ;
      private String sMode6 ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String endTrnMsgTxt ;
      private String endTrnMsgCod ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private DateTime AV13Fechahora ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n71ParametrosBloqueo ;
      private bool n135Parametrosusername ;
      private bool n136Parametrospassword ;
      private bool n137ParametrosAddHeader ;
      private bool n138ParametrosHost ;
      private bool n139ParametrosPort ;
      private bool n140ParametrosBaseUrl ;
      private bool n141ParametrosExecute ;
      private bool n142ParametrosRuta ;
      private bool n143ParametrosRutaPDF ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private String AV12Motivo ;
      private String Z129ParametroValor ;
      private String Z130ParametroDesc ;
      private String Z131ParametroDescLarg ;
      private String Z135Parametrosusername ;
      private String Z136Parametrospassword ;
      private String Z137ParametrosAddHeader ;
      private String Z138ParametrosHost ;
      private String Z140ParametrosBaseUrl ;
      private String Z142ParametrosRuta ;
      private String Z143ParametrosRutaPDF ;
      private String A129ParametroValor ;
      private String A130ParametroDesc ;
      private String A131ParametroDescLarg ;
      private String A135Parametrosusername ;
      private String A136Parametrospassword ;
      private String A137ParametrosAddHeader ;
      private String A138ParametrosHost ;
      private String A140ParametrosBaseUrl ;
      private String A142ParametrosRuta ;
      private String A143ParametrosRutaPDF ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkParametroWebService ;
      private IDataStoreProvider pr_default ;
      private int[] T00054_A29ParametroId ;
      private String[] T00054_A133ParametroHoraIni ;
      private String[] T00054_A132ParametroHoraFin ;
      private String[] T00054_A129ParametroValor ;
      private String[] T00054_A130ParametroDesc ;
      private String[] T00054_A131ParametroDescLarg ;
      private short[] T00054_A134ParametroWebService ;
      private short[] T00054_A71ParametrosBloqueo ;
      private bool[] T00054_n71ParametrosBloqueo ;
      private String[] T00054_A135Parametrosusername ;
      private bool[] T00054_n135Parametrosusername ;
      private String[] T00054_A136Parametrospassword ;
      private bool[] T00054_n136Parametrospassword ;
      private String[] T00054_A137ParametrosAddHeader ;
      private bool[] T00054_n137ParametrosAddHeader ;
      private String[] T00054_A138ParametrosHost ;
      private bool[] T00054_n138ParametrosHost ;
      private int[] T00054_A139ParametrosPort ;
      private bool[] T00054_n139ParametrosPort ;
      private String[] T00054_A140ParametrosBaseUrl ;
      private bool[] T00054_n140ParametrosBaseUrl ;
      private String[] T00054_A141ParametrosExecute ;
      private bool[] T00054_n141ParametrosExecute ;
      private String[] T00054_A142ParametrosRuta ;
      private bool[] T00054_n142ParametrosRuta ;
      private String[] T00054_A143ParametrosRutaPDF ;
      private bool[] T00054_n143ParametrosRutaPDF ;
      private int[] T00055_A29ParametroId ;
      private int[] T00053_A29ParametroId ;
      private String[] T00053_A133ParametroHoraIni ;
      private String[] T00053_A132ParametroHoraFin ;
      private String[] T00053_A129ParametroValor ;
      private String[] T00053_A130ParametroDesc ;
      private String[] T00053_A131ParametroDescLarg ;
      private short[] T00053_A134ParametroWebService ;
      private short[] T00053_A71ParametrosBloqueo ;
      private bool[] T00053_n71ParametrosBloqueo ;
      private String[] T00053_A135Parametrosusername ;
      private bool[] T00053_n135Parametrosusername ;
      private String[] T00053_A136Parametrospassword ;
      private bool[] T00053_n136Parametrospassword ;
      private String[] T00053_A137ParametrosAddHeader ;
      private bool[] T00053_n137ParametrosAddHeader ;
      private String[] T00053_A138ParametrosHost ;
      private bool[] T00053_n138ParametrosHost ;
      private int[] T00053_A139ParametrosPort ;
      private bool[] T00053_n139ParametrosPort ;
      private String[] T00053_A140ParametrosBaseUrl ;
      private bool[] T00053_n140ParametrosBaseUrl ;
      private String[] T00053_A141ParametrosExecute ;
      private bool[] T00053_n141ParametrosExecute ;
      private String[] T00053_A142ParametrosRuta ;
      private bool[] T00053_n142ParametrosRuta ;
      private String[] T00053_A143ParametrosRutaPDF ;
      private bool[] T00053_n143ParametrosRutaPDF ;
      private int[] T00056_A29ParametroId ;
      private int[] T00057_A29ParametroId ;
      private int[] T00052_A29ParametroId ;
      private String[] T00052_A133ParametroHoraIni ;
      private String[] T00052_A132ParametroHoraFin ;
      private String[] T00052_A129ParametroValor ;
      private String[] T00052_A130ParametroDesc ;
      private String[] T00052_A131ParametroDescLarg ;
      private short[] T00052_A134ParametroWebService ;
      private short[] T00052_A71ParametrosBloqueo ;
      private bool[] T00052_n71ParametrosBloqueo ;
      private String[] T00052_A135Parametrosusername ;
      private bool[] T00052_n135Parametrosusername ;
      private String[] T00052_A136Parametrospassword ;
      private bool[] T00052_n136Parametrospassword ;
      private String[] T00052_A137ParametrosAddHeader ;
      private bool[] T00052_n137ParametrosAddHeader ;
      private String[] T00052_A138ParametrosHost ;
      private bool[] T00052_n138ParametrosHost ;
      private int[] T00052_A139ParametrosPort ;
      private bool[] T00052_n139ParametrosPort ;
      private String[] T00052_A140ParametrosBaseUrl ;
      private bool[] T00052_n140ParametrosBaseUrl ;
      private String[] T00052_A141ParametrosExecute ;
      private bool[] T00052_n141ParametrosExecute ;
      private String[] T00052_A142ParametrosRuta ;
      private bool[] T00052_n142ParametrosRuta ;
      private String[] T00052_A143ParametrosRutaPDF ;
      private bool[] T00052_n143ParametrosRutaPDF ;
      private int[] T000511_A29ParametroId ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
   }

   public class parametros__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT00054 ;
          prmT00054 = new Object[] {
          new Object[] {"ParametroId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT00055 ;
          prmT00055 = new Object[] {
          new Object[] {"ParametroId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT00053 ;
          prmT00053 = new Object[] {
          new Object[] {"ParametroId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT00056 ;
          prmT00056 = new Object[] {
          new Object[] {"ParametroId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT00057 ;
          prmT00057 = new Object[] {
          new Object[] {"ParametroId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT00052 ;
          prmT00052 = new Object[] {
          new Object[] {"ParametroId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT00058 ;
          prmT00058 = new Object[] {
          new Object[] {"ParametroId",System.Data.DbType.Int32,9,0} ,
          new Object[] {"ParametroHoraIni",System.Data.DbType.String,8,0} ,
          new Object[] {"ParametroHoraFin",System.Data.DbType.String,8,0} ,
          new Object[] {"ParametroValor",System.Data.DbType.String,1000,0} ,
          new Object[] {"ParametroDesc",System.Data.DbType.String,35,0} ,
          new Object[] {"ParametroDescLarg",System.Data.DbType.String,2048,0} ,
          new Object[] {"ParametroWebService",System.Data.DbType.Byte,1,0} ,
          new Object[] {"ParametrosBloqueo",System.Data.DbType.Int16,4,0} ,
          new Object[] {"Parametrosusername",System.Data.DbType.String,40,0} ,
          new Object[] {"Parametrospassword",System.Data.DbType.String,40,0} ,
          new Object[] {"ParametrosAddHeader",System.Data.DbType.String,200,0} ,
          new Object[] {"ParametrosHost",System.Data.DbType.String,100,0} ,
          new Object[] {"ParametrosPort",System.Data.DbType.Int32,8,0} ,
          new Object[] {"ParametrosBaseUrl",System.Data.DbType.String,20,0} ,
          new Object[] {"ParametrosExecute",System.Data.DbType.String,6,0} ,
          new Object[] {"ParametrosRuta",System.Data.DbType.String,40,0} ,
          new Object[] {"ParametrosRutaPDF",System.Data.DbType.String,600,0}
          } ;
          Object[] prmT00059 ;
          prmT00059 = new Object[] {
          new Object[] {"ParametroHoraIni",System.Data.DbType.String,8,0} ,
          new Object[] {"ParametroHoraFin",System.Data.DbType.String,8,0} ,
          new Object[] {"ParametroValor",System.Data.DbType.String,1000,0} ,
          new Object[] {"ParametroDesc",System.Data.DbType.String,35,0} ,
          new Object[] {"ParametroDescLarg",System.Data.DbType.String,2048,0} ,
          new Object[] {"ParametroWebService",System.Data.DbType.Byte,1,0} ,
          new Object[] {"ParametrosBloqueo",System.Data.DbType.Int16,4,0} ,
          new Object[] {"Parametrosusername",System.Data.DbType.String,40,0} ,
          new Object[] {"Parametrospassword",System.Data.DbType.String,40,0} ,
          new Object[] {"ParametrosAddHeader",System.Data.DbType.String,200,0} ,
          new Object[] {"ParametrosHost",System.Data.DbType.String,100,0} ,
          new Object[] {"ParametrosPort",System.Data.DbType.Int32,8,0} ,
          new Object[] {"ParametrosBaseUrl",System.Data.DbType.String,20,0} ,
          new Object[] {"ParametrosExecute",System.Data.DbType.String,6,0} ,
          new Object[] {"ParametrosRuta",System.Data.DbType.String,40,0} ,
          new Object[] {"ParametrosRutaPDF",System.Data.DbType.String,600,0} ,
          new Object[] {"ParametroId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000510 ;
          prmT000510 = new Object[] {
          new Object[] {"ParametroId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmT000511 ;
          prmT000511 = new Object[] {
          } ;
          def= new CursorDef[] {
              new CursorDef("T00052", "SELECT `ParametroId`, `ParametroHoraIni`, `ParametroHoraFin`, `ParametroValor`, `ParametroDesc`, `ParametroDescLarg`, `ParametroWebService`, `ParametrosBloqueo`, `Parametrosusername`, `Parametrospassword`, `ParametrosAddHeader`, `ParametrosHost`, `ParametrosPort`, `ParametrosBaseUrl`, `ParametrosExecute`, `ParametrosRuta`, `ParametrosRutaPDF` FROM `Parametros` WHERE `ParametroId` = ?  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT00052,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00053", "SELECT `ParametroId`, `ParametroHoraIni`, `ParametroHoraFin`, `ParametroValor`, `ParametroDesc`, `ParametroDescLarg`, `ParametroWebService`, `ParametrosBloqueo`, `Parametrosusername`, `Parametrospassword`, `ParametrosAddHeader`, `ParametrosHost`, `ParametrosPort`, `ParametrosBaseUrl`, `ParametrosExecute`, `ParametrosRuta`, `ParametrosRutaPDF` FROM `Parametros` WHERE `ParametroId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00053,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00054", "SELECT TM1.`ParametroId`, TM1.`ParametroHoraIni`, TM1.`ParametroHoraFin`, TM1.`ParametroValor`, TM1.`ParametroDesc`, TM1.`ParametroDescLarg`, TM1.`ParametroWebService`, TM1.`ParametrosBloqueo`, TM1.`Parametrosusername`, TM1.`Parametrospassword`, TM1.`ParametrosAddHeader`, TM1.`ParametrosHost`, TM1.`ParametrosPort`, TM1.`ParametrosBaseUrl`, TM1.`ParametrosExecute`, TM1.`ParametrosRuta`, TM1.`ParametrosRutaPDF` FROM `Parametros` TM1 WHERE TM1.`ParametroId` = ? ORDER BY TM1.`ParametroId` ",true, GxErrorMask.GX_NOMASK, false, this,prmT00054,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00055", "SELECT `ParametroId` FROM `Parametros` WHERE `ParametroId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00055,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00056", "SELECT `ParametroId` FROM `Parametros` WHERE ( `ParametroId` > ?) ORDER BY `ParametroId`  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT00056,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00057", "SELECT `ParametroId` FROM `Parametros` WHERE ( `ParametroId` < ?) ORDER BY `ParametroId` DESC  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT00057,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00058", "INSERT INTO `Parametros`(`ParametroId`, `ParametroHoraIni`, `ParametroHoraFin`, `ParametroValor`, `ParametroDesc`, `ParametroDescLarg`, `ParametroWebService`, `ParametrosBloqueo`, `Parametrosusername`, `Parametrospassword`, `ParametrosAddHeader`, `ParametrosHost`, `ParametrosPort`, `ParametrosBaseUrl`, `ParametrosExecute`, `ParametrosRuta`, `ParametrosRutaPDF`) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", GxErrorMask.GX_NOMASK,prmT00058)
             ,new CursorDef("T00059", "UPDATE `Parametros` SET `ParametroHoraIni`=?, `ParametroHoraFin`=?, `ParametroValor`=?, `ParametroDesc`=?, `ParametroDescLarg`=?, `ParametroWebService`=?, `ParametrosBloqueo`=?, `Parametrosusername`=?, `Parametrospassword`=?, `ParametrosAddHeader`=?, `ParametrosHost`=?, `ParametrosPort`=?, `ParametrosBaseUrl`=?, `ParametrosExecute`=?, `ParametrosRuta`=?, `ParametrosRutaPDF`=?  WHERE `ParametroId` = ?", GxErrorMask.GX_NOMASK,prmT00059)
             ,new CursorDef("T000510", "DELETE FROM `Parametros`  WHERE `ParametroId` = ?", GxErrorMask.GX_NOMASK,prmT000510)
             ,new CursorDef("T000511", "SELECT `ParametroId` FROM `Parametros` ORDER BY `ParametroId` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000511,100, GxCacheFrequency.OFF ,true,false )
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
                ((String[]) buf[1])[0] = rslt.getString(2, 8) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 8) ;
                ((String[]) buf[3])[0] = rslt.getVarchar(4) ;
                ((String[]) buf[4])[0] = rslt.getVarchar(5) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
                ((short[]) buf[6])[0] = rslt.getShort(7) ;
                ((short[]) buf[7])[0] = rslt.getShort(8) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((String[]) buf[9])[0] = rslt.getVarchar(9) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((String[]) buf[11])[0] = rslt.getVarchar(10) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((String[]) buf[13])[0] = rslt.getVarchar(11) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                ((String[]) buf[15])[0] = rslt.getVarchar(12) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(12);
                ((int[]) buf[17])[0] = rslt.getInt(13) ;
                ((bool[]) buf[18])[0] = rslt.wasNull(13);
                ((String[]) buf[19])[0] = rslt.getVarchar(14) ;
                ((bool[]) buf[20])[0] = rslt.wasNull(14);
                ((String[]) buf[21])[0] = rslt.getString(15, 6) ;
                ((bool[]) buf[22])[0] = rslt.wasNull(15);
                ((String[]) buf[23])[0] = rslt.getVarchar(16) ;
                ((bool[]) buf[24])[0] = rslt.wasNull(16);
                ((String[]) buf[25])[0] = rslt.getVarchar(17) ;
                ((bool[]) buf[26])[0] = rslt.wasNull(17);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 8) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 8) ;
                ((String[]) buf[3])[0] = rslt.getVarchar(4) ;
                ((String[]) buf[4])[0] = rslt.getVarchar(5) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
                ((short[]) buf[6])[0] = rslt.getShort(7) ;
                ((short[]) buf[7])[0] = rslt.getShort(8) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((String[]) buf[9])[0] = rslt.getVarchar(9) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((String[]) buf[11])[0] = rslt.getVarchar(10) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((String[]) buf[13])[0] = rslt.getVarchar(11) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                ((String[]) buf[15])[0] = rslt.getVarchar(12) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(12);
                ((int[]) buf[17])[0] = rslt.getInt(13) ;
                ((bool[]) buf[18])[0] = rslt.wasNull(13);
                ((String[]) buf[19])[0] = rslt.getVarchar(14) ;
                ((bool[]) buf[20])[0] = rslt.wasNull(14);
                ((String[]) buf[21])[0] = rslt.getString(15, 6) ;
                ((bool[]) buf[22])[0] = rslt.wasNull(15);
                ((String[]) buf[23])[0] = rslt.getVarchar(16) ;
                ((bool[]) buf[24])[0] = rslt.wasNull(16);
                ((String[]) buf[25])[0] = rslt.getVarchar(17) ;
                ((bool[]) buf[26])[0] = rslt.wasNull(17);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 8) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 8) ;
                ((String[]) buf[3])[0] = rslt.getVarchar(4) ;
                ((String[]) buf[4])[0] = rslt.getVarchar(5) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
                ((short[]) buf[6])[0] = rslt.getShort(7) ;
                ((short[]) buf[7])[0] = rslt.getShort(8) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((String[]) buf[9])[0] = rslt.getVarchar(9) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((String[]) buf[11])[0] = rslt.getVarchar(10) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((String[]) buf[13])[0] = rslt.getVarchar(11) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                ((String[]) buf[15])[0] = rslt.getVarchar(12) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(12);
                ((int[]) buf[17])[0] = rslt.getInt(13) ;
                ((bool[]) buf[18])[0] = rslt.wasNull(13);
                ((String[]) buf[19])[0] = rslt.getVarchar(14) ;
                ((bool[]) buf[20])[0] = rslt.wasNull(14);
                ((String[]) buf[21])[0] = rslt.getString(15, 6) ;
                ((bool[]) buf[22])[0] = rslt.wasNull(15);
                ((String[]) buf[23])[0] = rslt.getVarchar(16) ;
                ((bool[]) buf[24])[0] = rslt.wasNull(16);
                ((String[]) buf[25])[0] = rslt.getVarchar(17) ;
                ((bool[]) buf[26])[0] = rslt.wasNull(17);
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
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (String)parms[2]);
                stmt.SetParameter(4, (String)parms[3]);
                stmt.SetParameter(5, (String)parms[4]);
                stmt.SetParameter(6, (String)parms[5]);
                stmt.SetParameter(7, (short)parms[6]);
                if ( (bool)parms[7] )
                {
                   stmt.setNull( 8 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(8, (short)parms[8]);
                }
                if ( (bool)parms[9] )
                {
                   stmt.setNull( 9 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(9, (String)parms[10]);
                }
                if ( (bool)parms[11] )
                {
                   stmt.setNull( 10 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(10, (String)parms[12]);
                }
                if ( (bool)parms[13] )
                {
                   stmt.setNull( 11 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(11, (String)parms[14]);
                }
                if ( (bool)parms[15] )
                {
                   stmt.setNull( 12 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(12, (String)parms[16]);
                }
                if ( (bool)parms[17] )
                {
                   stmt.setNull( 13 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(13, (int)parms[18]);
                }
                if ( (bool)parms[19] )
                {
                   stmt.setNull( 14 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(14, (String)parms[20]);
                }
                if ( (bool)parms[21] )
                {
                   stmt.setNull( 15 , SqlDbType.NChar );
                }
                else
                {
                   stmt.SetParameter(15, (String)parms[22]);
                }
                if ( (bool)parms[23] )
                {
                   stmt.setNull( 16 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(16, (String)parms[24]);
                }
                if ( (bool)parms[25] )
                {
                   stmt.setNull( 17 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(17, (String)parms[26]);
                }
                return;
             case 7 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (String)parms[2]);
                stmt.SetParameter(4, (String)parms[3]);
                stmt.SetParameter(5, (String)parms[4]);
                stmt.SetParameter(6, (short)parms[5]);
                if ( (bool)parms[6] )
                {
                   stmt.setNull( 7 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(7, (short)parms[7]);
                }
                if ( (bool)parms[8] )
                {
                   stmt.setNull( 8 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(8, (String)parms[9]);
                }
                if ( (bool)parms[10] )
                {
                   stmt.setNull( 9 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(9, (String)parms[11]);
                }
                if ( (bool)parms[12] )
                {
                   stmt.setNull( 10 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(10, (String)parms[13]);
                }
                if ( (bool)parms[14] )
                {
                   stmt.setNull( 11 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(11, (String)parms[15]);
                }
                if ( (bool)parms[16] )
                {
                   stmt.setNull( 12 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(12, (int)parms[17]);
                }
                if ( (bool)parms[18] )
                {
                   stmt.setNull( 13 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(13, (String)parms[19]);
                }
                if ( (bool)parms[20] )
                {
                   stmt.setNull( 14 , SqlDbType.NChar );
                }
                else
                {
                   stmt.SetParameter(14, (String)parms[21]);
                }
                if ( (bool)parms[22] )
                {
                   stmt.setNull( 15 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(15, (String)parms[23]);
                }
                if ( (bool)parms[24] )
                {
                   stmt.setNull( 16 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(16, (String)parms[25]);
                }
                stmt.SetParameter(17, (int)parms[26]);
                return;
             case 8 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

}
