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
   public class histpwd : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            Form.Meta.addItem("description", "Historico de Contrasenas", 0) ;
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

      public histpwd( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public histpwd( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Historico de Contrasenas", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_HistPwd.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_HistPwd.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_HistPwd.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_HistPwd.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_HistPwd.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_HistPwd.htm");
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
         GxWebStd.gx_single_line_edit( context, edtUsuariosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")), ((edtUsuariosId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9")) : context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosId_Enabled, 0, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "NumId", "right", false, "", "HLP_HistPwd.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHisPwdFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHisPwdFecha_Internalname, "Fecha de la Contrasena", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtHisPwdFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtHisPwdFecha_Internalname, context.localUtil.TToC( A62HisPwdFecha, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A62HisPwdFecha, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'spa',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHisPwdFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHisPwdFecha_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 1, -1, 0, true, "FechaTiempo", "right", false, "", "HLP_HistPwd.htm");
         GxWebStd.gx_bitmap( context, edtHisPwdFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtHisPwdFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_HistPwd.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHistPwdConstra_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistPwdConstra_Internalname, "Constrasena", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistPwdConstra_Internalname, A110HistPwdConstra, StringUtil.RTrim( context.localUtil.Format( A110HistPwdConstra, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistPwdConstra_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHistPwdConstra_Enabled, 0, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_HistPwd.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHistPwdLlave_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistPwdLlave_Internalname, "Llave de la contrasena", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistPwdLlave_Internalname, A111HistPwdLlave, StringUtil.RTrim( context.localUtil.Format( A111HistPwdLlave, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistPwdLlave_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHistPwdLlave_Enabled, 0, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_HistPwd.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHistPwdInd_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistPwdInd_Internalname, "Indicador de la contraseña", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistPwdInd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A73HistPwdInd), 1, 0, ",", "")), ((edtHistPwdInd_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A73HistPwdInd), "9")) : context.localUtil.Format( (decimal)(A73HistPwdInd), "9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistPwdInd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHistPwdInd_Enabled, 0, "number", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_HistPwd.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_HistPwd.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_HistPwd.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_HistPwd.htm");
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
            Z62HisPwdFecha = context.localUtil.CToT( cgiGet( "Z62HisPwdFecha"), 0);
            Z110HistPwdConstra = cgiGet( "Z110HistPwdConstra");
            Z111HistPwdLlave = cgiGet( "Z111HistPwdLlave");
            Z73HistPwdInd = (short)(context.localUtil.CToN( cgiGet( "Z73HistPwdInd"), ",", "."));
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
            if ( context.localUtil.VCDateTime( cgiGet( edtHisPwdFecha_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha de la Contrasena"}), 1, "HISPWDFECHA");
               AnyError = 1;
               GX_FocusControl = edtHisPwdFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A62HisPwdFecha = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A62HisPwdFecha", context.localUtil.TToC( A62HisPwdFecha, 10, 8, 0, 3, "/", ":", " "));
            }
            else
            {
               A62HisPwdFecha = context.localUtil.CToT( cgiGet( edtHisPwdFecha_Internalname));
               AssignAttri("", false, "A62HisPwdFecha", context.localUtil.TToC( A62HisPwdFecha, 10, 8, 0, 3, "/", ":", " "));
            }
            A110HistPwdConstra = cgiGet( edtHistPwdConstra_Internalname);
            AssignAttri("", false, "A110HistPwdConstra", A110HistPwdConstra);
            A111HistPwdLlave = cgiGet( edtHistPwdLlave_Internalname);
            AssignAttri("", false, "A111HistPwdLlave", A111HistPwdLlave);
            if ( ( ( context.localUtil.CToN( cgiGet( edtHistPwdInd_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHistPwdInd_Internalname), ",", ".") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "HISTPWDIND");
               AnyError = 1;
               GX_FocusControl = edtHistPwdInd_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A73HistPwdInd = 0;
               AssignAttri("", false, "A73HistPwdInd", StringUtil.Str( (decimal)(A73HistPwdInd), 1, 0));
            }
            else
            {
               A73HistPwdInd = (short)(context.localUtil.CToN( cgiGet( edtHistPwdInd_Internalname), ",", "."));
               AssignAttri("", false, "A73HistPwdInd", StringUtil.Str( (decimal)(A73HistPwdInd), 1, 0));
            }
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
               A62HisPwdFecha = context.localUtil.ParseDTimeParm( GetNextPar( ));
               AssignAttri("", false, "A62HisPwdFecha", context.localUtil.TToC( A62HisPwdFecha, 10, 8, 0, 3, "/", ":", " "));
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
               InitAll0912( ) ;
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
         DisableAttributes0912( ) ;
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

      protected void ResetCaption090( )
      {
      }

      protected void ZM0912( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z110HistPwdConstra = T00093_A110HistPwdConstra[0];
               Z111HistPwdLlave = T00093_A111HistPwdLlave[0];
               Z73HistPwdInd = T00093_A73HistPwdInd[0];
            }
            else
            {
               Z110HistPwdConstra = A110HistPwdConstra;
               Z111HistPwdLlave = A111HistPwdLlave;
               Z73HistPwdInd = A73HistPwdInd;
            }
         }
         if ( GX_JID == -2 )
         {
            Z62HisPwdFecha = A62HisPwdFecha;
            Z110HistPwdConstra = A110HistPwdConstra;
            Z111HistPwdLlave = A111HistPwdLlave;
            Z73HistPwdInd = A73HistPwdInd;
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

      protected void Load0912( )
      {
         /* Using cursor T00095 */
         pr_default.execute(3, new Object[] {A11UsuariosId, A62HisPwdFecha});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound12 = 1;
            A110HistPwdConstra = T00095_A110HistPwdConstra[0];
            AssignAttri("", false, "A110HistPwdConstra", A110HistPwdConstra);
            A111HistPwdLlave = T00095_A111HistPwdLlave[0];
            AssignAttri("", false, "A111HistPwdLlave", A111HistPwdLlave);
            A73HistPwdInd = T00095_A73HistPwdInd[0];
            AssignAttri("", false, "A73HistPwdInd", StringUtil.Str( (decimal)(A73HistPwdInd), 1, 0));
            ZM0912( -2) ;
         }
         pr_default.close(3);
         OnLoadActions0912( ) ;
      }

      protected void OnLoadActions0912( )
      {
      }

      protected void CheckExtendedTable0912( )
      {
         nIsDirty_12 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00094 */
         pr_default.execute(2, new Object[] {A11UsuariosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Tabla de usuarios'.", "ForeignKeyNotFound", 1, "USUARIOSID");
            AnyError = 1;
            GX_FocusControl = edtUsuariosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A62HisPwdFecha) || ( A62HisPwdFecha >= context.localUtil.YMDHMSToT( 1000, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha de la Contrasena fuera de rango", "OutOfRange", 1, "HISPWDFECHA");
            AnyError = 1;
            GX_FocusControl = edtHisPwdFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0912( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A11UsuariosId )
      {
         /* Using cursor T00096 */
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

      protected void GetKey0912( )
      {
         /* Using cursor T00097 */
         pr_default.execute(5, new Object[] {A11UsuariosId, A62HisPwdFecha});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound12 = 1;
         }
         else
         {
            RcdFound12 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00093 */
         pr_default.execute(1, new Object[] {A11UsuariosId, A62HisPwdFecha});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0912( 2) ;
            RcdFound12 = 1;
            A62HisPwdFecha = T00093_A62HisPwdFecha[0];
            AssignAttri("", false, "A62HisPwdFecha", context.localUtil.TToC( A62HisPwdFecha, 10, 8, 0, 3, "/", ":", " "));
            A110HistPwdConstra = T00093_A110HistPwdConstra[0];
            AssignAttri("", false, "A110HistPwdConstra", A110HistPwdConstra);
            A111HistPwdLlave = T00093_A111HistPwdLlave[0];
            AssignAttri("", false, "A111HistPwdLlave", A111HistPwdLlave);
            A73HistPwdInd = T00093_A73HistPwdInd[0];
            AssignAttri("", false, "A73HistPwdInd", StringUtil.Str( (decimal)(A73HistPwdInd), 1, 0));
            A11UsuariosId = T00093_A11UsuariosId[0];
            AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
            Z11UsuariosId = A11UsuariosId;
            Z62HisPwdFecha = A62HisPwdFecha;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0912( ) ;
            if ( AnyError == 1 )
            {
               RcdFound12 = 0;
               InitializeNonKey0912( ) ;
            }
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound12 = 0;
            InitializeNonKey0912( ) ;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0912( ) ;
         if ( RcdFound12 == 0 )
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
         RcdFound12 = 0;
         /* Using cursor T00098 */
         pr_default.execute(6, new Object[] {A11UsuariosId, A11UsuariosId, A62HisPwdFecha});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00098_A11UsuariosId[0] < A11UsuariosId ) || ( T00098_A11UsuariosId[0] == A11UsuariosId ) && ( T00098_A62HisPwdFecha[0] < A62HisPwdFecha ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00098_A11UsuariosId[0] > A11UsuariosId ) || ( T00098_A11UsuariosId[0] == A11UsuariosId ) && ( T00098_A62HisPwdFecha[0] > A62HisPwdFecha ) ) )
            {
               A11UsuariosId = T00098_A11UsuariosId[0];
               AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
               A62HisPwdFecha = T00098_A62HisPwdFecha[0];
               AssignAttri("", false, "A62HisPwdFecha", context.localUtil.TToC( A62HisPwdFecha, 10, 8, 0, 3, "/", ":", " "));
               RcdFound12 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound12 = 0;
         /* Using cursor T00099 */
         pr_default.execute(7, new Object[] {A11UsuariosId, A11UsuariosId, A62HisPwdFecha});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00099_A11UsuariosId[0] > A11UsuariosId ) || ( T00099_A11UsuariosId[0] == A11UsuariosId ) && ( T00099_A62HisPwdFecha[0] > A62HisPwdFecha ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00099_A11UsuariosId[0] < A11UsuariosId ) || ( T00099_A11UsuariosId[0] == A11UsuariosId ) && ( T00099_A62HisPwdFecha[0] < A62HisPwdFecha ) ) )
            {
               A11UsuariosId = T00099_A11UsuariosId[0];
               AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
               A62HisPwdFecha = T00099_A62HisPwdFecha[0];
               AssignAttri("", false, "A62HisPwdFecha", context.localUtil.TToC( A62HisPwdFecha, 10, 8, 0, 3, "/", ":", " "));
               RcdFound12 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0912( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUsuariosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0912( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound12 == 1 )
            {
               if ( ( A11UsuariosId != Z11UsuariosId ) || ( A62HisPwdFecha != Z62HisPwdFecha ) )
               {
                  A11UsuariosId = Z11UsuariosId;
                  AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
                  A62HisPwdFecha = Z62HisPwdFecha;
                  AssignAttri("", false, "A62HisPwdFecha", context.localUtil.TToC( A62HisPwdFecha, 10, 8, 0, 3, "/", ":", " "));
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
                  Update0912( ) ;
                  GX_FocusControl = edtUsuariosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A11UsuariosId != Z11UsuariosId ) || ( A62HisPwdFecha != Z62HisPwdFecha ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtUsuariosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0912( ) ;
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
                     Insert0912( ) ;
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
         if ( ( A11UsuariosId != Z11UsuariosId ) || ( A62HisPwdFecha != Z62HisPwdFecha ) )
         {
            A11UsuariosId = Z11UsuariosId;
            AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
            A62HisPwdFecha = Z62HisPwdFecha;
            AssignAttri("", false, "A62HisPwdFecha", context.localUtil.TToC( A62HisPwdFecha, 10, 8, 0, 3, "/", ":", " "));
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
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "USUARIOSID");
            AnyError = 1;
            GX_FocusControl = edtUsuariosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtHistPwdConstra_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0912( ) ;
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtHistPwdConstra_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0912( ) ;
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
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtHistPwdConstra_Internalname;
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
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtHistPwdConstra_Internalname;
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
         ScanStart0912( ) ;
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound12 != 0 )
            {
               ScanNext0912( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtHistPwdConstra_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0912( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0912( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00092 */
            pr_default.execute(0, new Object[] {A11UsuariosId, A62HisPwdFecha});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"HistPwd"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z110HistPwdConstra, T00092_A110HistPwdConstra[0]) != 0 ) || ( StringUtil.StrCmp(Z111HistPwdLlave, T00092_A111HistPwdLlave[0]) != 0 ) || ( Z73HistPwdInd != T00092_A73HistPwdInd[0] ) )
            {
               if ( StringUtil.StrCmp(Z110HistPwdConstra, T00092_A110HistPwdConstra[0]) != 0 )
               {
                  GXUtil.WriteLog("histpwd:[seudo value changed for attri]"+"HistPwdConstra");
                  GXUtil.WriteLogRaw("Old: ",Z110HistPwdConstra);
                  GXUtil.WriteLogRaw("Current: ",T00092_A110HistPwdConstra[0]);
               }
               if ( StringUtil.StrCmp(Z111HistPwdLlave, T00092_A111HistPwdLlave[0]) != 0 )
               {
                  GXUtil.WriteLog("histpwd:[seudo value changed for attri]"+"HistPwdLlave");
                  GXUtil.WriteLogRaw("Old: ",Z111HistPwdLlave);
                  GXUtil.WriteLogRaw("Current: ",T00092_A111HistPwdLlave[0]);
               }
               if ( Z73HistPwdInd != T00092_A73HistPwdInd[0] )
               {
                  GXUtil.WriteLog("histpwd:[seudo value changed for attri]"+"HistPwdInd");
                  GXUtil.WriteLogRaw("Old: ",Z73HistPwdInd);
                  GXUtil.WriteLogRaw("Current: ",T00092_A73HistPwdInd[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"HistPwd"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0912( )
      {
         BeforeValidate0912( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0912( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0912( 0) ;
            CheckOptimisticConcurrency0912( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0912( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0912( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000910 */
                     pr_default.execute(8, new Object[] {A62HisPwdFecha, A110HistPwdConstra, A111HistPwdLlave, A73HistPwdInd, A11UsuariosId});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("HistPwd") ;
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
                           ResetCaption090( ) ;
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
               Load0912( ) ;
            }
            EndLevel0912( ) ;
         }
         CloseExtendedTableCursors0912( ) ;
      }

      protected void Update0912( )
      {
         BeforeValidate0912( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0912( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0912( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0912( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0912( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000911 */
                     pr_default.execute(9, new Object[] {A110HistPwdConstra, A111HistPwdLlave, A73HistPwdInd, A11UsuariosId, A62HisPwdFecha});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("HistPwd") ;
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"HistPwd"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0912( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption090( ) ;
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
            EndLevel0912( ) ;
         }
         CloseExtendedTableCursors0912( ) ;
      }

      protected void DeferredUpdate0912( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0912( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0912( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0912( ) ;
            AfterConfirm0912( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0912( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000912 */
                  pr_default.execute(10, new Object[] {A11UsuariosId, A62HisPwdFecha});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("HistPwd") ;
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound12 == 0 )
                        {
                           InitAll0912( ) ;
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
                        ResetCaption090( ) ;
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
         sMode12 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0912( ) ;
         Gx_mode = sMode12;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0912( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0912( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0912( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("histpwd",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues090( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("histpwd",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0912( )
      {
         /* Using cursor T000913 */
         pr_default.execute(11);
         RcdFound12 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound12 = 1;
            A11UsuariosId = T000913_A11UsuariosId[0];
            AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
            A62HisPwdFecha = T000913_A62HisPwdFecha[0];
            AssignAttri("", false, "A62HisPwdFecha", context.localUtil.TToC( A62HisPwdFecha, 10, 8, 0, 3, "/", ":", " "));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0912( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound12 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound12 = 1;
            A11UsuariosId = T000913_A11UsuariosId[0];
            AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
            A62HisPwdFecha = T000913_A62HisPwdFecha[0];
            AssignAttri("", false, "A62HisPwdFecha", context.localUtil.TToC( A62HisPwdFecha, 10, 8, 0, 3, "/", ":", " "));
         }
      }

      protected void ScanEnd0912( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0912( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0912( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0912( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0912( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0912( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0912( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0912( )
      {
         edtUsuariosId_Enabled = 0;
         AssignProp("", false, edtUsuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosId_Enabled), 5, 0), true);
         edtHisPwdFecha_Enabled = 0;
         AssignProp("", false, edtHisPwdFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHisPwdFecha_Enabled), 5, 0), true);
         edtHistPwdConstra_Enabled = 0;
         AssignProp("", false, edtHistPwdConstra_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistPwdConstra_Enabled), 5, 0), true);
         edtHistPwdLlave_Enabled = 0;
         AssignProp("", false, edtHistPwdLlave_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistPwdLlave_Enabled), 5, 0), true);
         edtHistPwdInd_Enabled = 0;
         AssignProp("", false, edtHistPwdInd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistPwdInd_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0912( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues090( )
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
         context.AddJavascriptSource("gxcfg.js", "?202262714344028", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("histpwd.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z62HisPwdFecha", context.localUtil.TToC( Z62HisPwdFecha, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z110HistPwdConstra", Z110HistPwdConstra);
         GxWebStd.gx_hidden_field( context, "Z111HistPwdLlave", Z111HistPwdLlave);
         GxWebStd.gx_hidden_field( context, "Z73HistPwdInd", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z73HistPwdInd), 1, 0, ",", "")));
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
         return formatLink("histpwd.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "HistPwd" ;
      }

      public override String GetPgmdesc( )
      {
         return "Historico de Contrasenas" ;
      }

      protected void InitializeNonKey0912( )
      {
         A110HistPwdConstra = "";
         AssignAttri("", false, "A110HistPwdConstra", A110HistPwdConstra);
         A111HistPwdLlave = "";
         AssignAttri("", false, "A111HistPwdLlave", A111HistPwdLlave);
         A73HistPwdInd = 0;
         AssignAttri("", false, "A73HistPwdInd", StringUtil.Str( (decimal)(A73HistPwdInd), 1, 0));
         Z110HistPwdConstra = "";
         Z111HistPwdLlave = "";
         Z73HistPwdInd = 0;
      }

      protected void InitAll0912( )
      {
         A11UsuariosId = 0;
         AssignAttri("", false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
         A62HisPwdFecha = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A62HisPwdFecha", context.localUtil.TToC( A62HisPwdFecha, 10, 8, 0, 3, "/", ":", " "));
         InitializeNonKey0912( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714344032", true, true);
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
         context.AddJavascriptSource("histpwd.js", "?202262714344032", false, true);
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
         edtHisPwdFecha_Internalname = "HISPWDFECHA";
         edtHistPwdConstra_Internalname = "HISTPWDCONSTRA";
         edtHistPwdLlave_Internalname = "HISTPWDLLAVE";
         edtHistPwdInd_Internalname = "HISTPWDIND";
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
         Form.Caption = "Historico de Contrasenas";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtHistPwdInd_Jsonclick = "";
         edtHistPwdInd_Enabled = 1;
         edtHistPwdLlave_Jsonclick = "";
         edtHistPwdLlave_Enabled = 1;
         edtHistPwdConstra_Jsonclick = "";
         edtHistPwdConstra_Enabled = 1;
         edtHisPwdFecha_Jsonclick = "";
         edtHisPwdFecha_Enabled = 1;
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
         /* Using cursor T000914 */
         pr_default.execute(12, new Object[] {A11UsuariosId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Tabla de usuarios'.", "ForeignKeyNotFound", 1, "USUARIOSID");
            AnyError = 1;
            GX_FocusControl = edtUsuariosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(12);
         GX_FocusControl = edtHistPwdConstra_Internalname;
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
         /* Using cursor T000914 */
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

      public void Valid_Hispwdfecha( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         if ( ! ( (DateTime.MinValue==A62HisPwdFecha) || ( A62HisPwdFecha >= context.localUtil.YMDHMSToT( 1000, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha de la Contrasena fuera de rango", "OutOfRange", 1, "HISPWDFECHA");
            AnyError = 1;
            GX_FocusControl = edtHisPwdFecha_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A110HistPwdConstra", A110HistPwdConstra);
         AssignAttri("", false, "A111HistPwdLlave", A111HistPwdLlave);
         AssignAttri("", false, "A73HistPwdInd", StringUtil.LTrim( StringUtil.NToC( (decimal)(A73HistPwdInd), 1, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z11UsuariosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11UsuariosId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z62HisPwdFecha", context.localUtil.TToC( Z62HisPwdFecha, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z110HistPwdConstra", Z110HistPwdConstra);
         GxWebStd.gx_hidden_field( context, "Z111HistPwdLlave", Z111HistPwdLlave);
         GxWebStd.gx_hidden_field( context, "Z73HistPwdInd", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z73HistPwdInd), 1, 0, ".", "")));
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
         setEventMetadata("VALID_HISPWDFECHA","{handler:'Valid_Hispwdfecha',iparms:[{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A62HisPwdFecha',fld:'HISPWDFECHA',pic:'99/99/9999 99:99:99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_HISPWDFECHA",",oparms:[{av:'A110HistPwdConstra',fld:'HISTPWDCONSTRA',pic:''},{av:'A111HistPwdLlave',fld:'HISTPWDLLAVE',pic:''},{av:'A73HistPwdInd',fld:'HISTPWDIND',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z11UsuariosId'},{av:'Z62HisPwdFecha'},{av:'Z110HistPwdConstra'},{av:'Z111HistPwdLlave'},{av:'Z73HistPwdInd'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z62HisPwdFecha = (DateTime)(DateTime.MinValue);
         Z110HistPwdConstra = "";
         Z111HistPwdLlave = "";
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
         A62HisPwdFecha = (DateTime)(DateTime.MinValue);
         A110HistPwdConstra = "";
         A111HistPwdLlave = "";
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
         T00095_A62HisPwdFecha = new DateTime[] {DateTime.MinValue} ;
         T00095_A110HistPwdConstra = new String[] {""} ;
         T00095_A111HistPwdLlave = new String[] {""} ;
         T00095_A73HistPwdInd = new short[1] ;
         T00095_A11UsuariosId = new int[1] ;
         T00094_A11UsuariosId = new int[1] ;
         T00096_A11UsuariosId = new int[1] ;
         T00097_A11UsuariosId = new int[1] ;
         T00097_A62HisPwdFecha = new DateTime[] {DateTime.MinValue} ;
         T00093_A62HisPwdFecha = new DateTime[] {DateTime.MinValue} ;
         T00093_A110HistPwdConstra = new String[] {""} ;
         T00093_A111HistPwdLlave = new String[] {""} ;
         T00093_A73HistPwdInd = new short[1] ;
         T00093_A11UsuariosId = new int[1] ;
         sMode12 = "";
         T00098_A11UsuariosId = new int[1] ;
         T00098_A62HisPwdFecha = new DateTime[] {DateTime.MinValue} ;
         T00099_A11UsuariosId = new int[1] ;
         T00099_A62HisPwdFecha = new DateTime[] {DateTime.MinValue} ;
         T00092_A62HisPwdFecha = new DateTime[] {DateTime.MinValue} ;
         T00092_A110HistPwdConstra = new String[] {""} ;
         T00092_A111HistPwdLlave = new String[] {""} ;
         T00092_A73HistPwdInd = new short[1] ;
         T00092_A11UsuariosId = new int[1] ;
         T000913_A11UsuariosId = new int[1] ;
         T000913_A62HisPwdFecha = new DateTime[] {DateTime.MinValue} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000914_A11UsuariosId = new int[1] ;
         ZZ62HisPwdFecha = (DateTime)(DateTime.MinValue);
         ZZ110HistPwdConstra = "";
         ZZ111HistPwdLlave = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.histpwd__default(),
            new Object[][] {
                new Object[] {
               T00092_A62HisPwdFecha, T00092_A110HistPwdConstra, T00092_A111HistPwdLlave, T00092_A73HistPwdInd, T00092_A11UsuariosId
               }
               , new Object[] {
               T00093_A62HisPwdFecha, T00093_A110HistPwdConstra, T00093_A111HistPwdLlave, T00093_A73HistPwdInd, T00093_A11UsuariosId
               }
               , new Object[] {
               T00094_A11UsuariosId
               }
               , new Object[] {
               T00095_A62HisPwdFecha, T00095_A110HistPwdConstra, T00095_A111HistPwdLlave, T00095_A73HistPwdInd, T00095_A11UsuariosId
               }
               , new Object[] {
               T00096_A11UsuariosId
               }
               , new Object[] {
               T00097_A11UsuariosId, T00097_A62HisPwdFecha
               }
               , new Object[] {
               T00098_A11UsuariosId, T00098_A62HisPwdFecha
               }
               , new Object[] {
               T00099_A11UsuariosId, T00099_A62HisPwdFecha
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000913_A11UsuariosId, T000913_A62HisPwdFecha
               }
               , new Object[] {
               T000914_A11UsuariosId
               }
            }
         );
      }

      private short Z73HistPwdInd ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A73HistPwdInd ;
      private short GX_JID ;
      private short RcdFound12 ;
      private short nIsDirty_12 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ73HistPwdInd ;
      private int Z11UsuariosId ;
      private int A11UsuariosId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtUsuariosId_Enabled ;
      private int edtHisPwdFecha_Enabled ;
      private int edtHistPwdConstra_Enabled ;
      private int edtHistPwdLlave_Enabled ;
      private int edtHistPwdInd_Enabled ;
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
      private String edtHisPwdFecha_Internalname ;
      private String edtHisPwdFecha_Jsonclick ;
      private String edtHistPwdConstra_Internalname ;
      private String edtHistPwdConstra_Jsonclick ;
      private String edtHistPwdLlave_Internalname ;
      private String edtHistPwdLlave_Jsonclick ;
      private String edtHistPwdInd_Internalname ;
      private String edtHistPwdInd_Jsonclick ;
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
      private String sMode12 ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private DateTime Z62HisPwdFecha ;
      private DateTime A62HisPwdFecha ;
      private DateTime ZZ62HisPwdFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private String Z110HistPwdConstra ;
      private String Z111HistPwdLlave ;
      private String A110HistPwdConstra ;
      private String A111HistPwdLlave ;
      private String ZZ110HistPwdConstra ;
      private String ZZ111HistPwdLlave ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T00095_A62HisPwdFecha ;
      private String[] T00095_A110HistPwdConstra ;
      private String[] T00095_A111HistPwdLlave ;
      private short[] T00095_A73HistPwdInd ;
      private int[] T00095_A11UsuariosId ;
      private int[] T00094_A11UsuariosId ;
      private int[] T00096_A11UsuariosId ;
      private int[] T00097_A11UsuariosId ;
      private DateTime[] T00097_A62HisPwdFecha ;
      private DateTime[] T00093_A62HisPwdFecha ;
      private String[] T00093_A110HistPwdConstra ;
      private String[] T00093_A111HistPwdLlave ;
      private short[] T00093_A73HistPwdInd ;
      private int[] T00093_A11UsuariosId ;
      private int[] T00098_A11UsuariosId ;
      private DateTime[] T00098_A62HisPwdFecha ;
      private int[] T00099_A11UsuariosId ;
      private DateTime[] T00099_A62HisPwdFecha ;
      private DateTime[] T00092_A62HisPwdFecha ;
      private String[] T00092_A110HistPwdConstra ;
      private String[] T00092_A111HistPwdLlave ;
      private short[] T00092_A73HistPwdInd ;
      private int[] T00092_A11UsuariosId ;
      private int[] T000913_A11UsuariosId ;
      private DateTime[] T000913_A62HisPwdFecha ;
      private int[] T000914_A11UsuariosId ;
      private GXWebForm Form ;
   }

   public class histpwd__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT00095 ;
          prmT00095 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"HisPwdFecha",System.Data.DbType.DateTime,10,8}
          } ;
          Object[] prmT00094 ;
          prmT00094 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT00096 ;
          prmT00096 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT00097 ;
          prmT00097 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"HisPwdFecha",System.Data.DbType.DateTime,10,8}
          } ;
          Object[] prmT00093 ;
          prmT00093 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"HisPwdFecha",System.Data.DbType.DateTime,10,8}
          } ;
          Object[] prmT00098 ;
          prmT00098 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"HisPwdFecha",System.Data.DbType.DateTime,10,8}
          } ;
          Object[] prmT00099 ;
          prmT00099 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"HisPwdFecha",System.Data.DbType.DateTime,10,8}
          } ;
          Object[] prmT00092 ;
          prmT00092 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"HisPwdFecha",System.Data.DbType.DateTime,10,8}
          } ;
          Object[] prmT000910 ;
          prmT000910 = new Object[] {
          new Object[] {"HisPwdFecha",System.Data.DbType.DateTime,10,8} ,
          new Object[] {"HistPwdConstra",System.Data.DbType.String,32,0} ,
          new Object[] {"HistPwdLlave",System.Data.DbType.String,32,0} ,
          new Object[] {"HistPwdInd",System.Data.DbType.Byte,1,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmT000911 ;
          prmT000911 = new Object[] {
          new Object[] {"HistPwdConstra",System.Data.DbType.String,32,0} ,
          new Object[] {"HistPwdLlave",System.Data.DbType.String,32,0} ,
          new Object[] {"HistPwdInd",System.Data.DbType.Byte,1,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"HisPwdFecha",System.Data.DbType.DateTime,10,8}
          } ;
          Object[] prmT000912 ;
          prmT000912 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"HisPwdFecha",System.Data.DbType.DateTime,10,8}
          } ;
          Object[] prmT000913 ;
          prmT000913 = new Object[] {
          } ;
          Object[] prmT000914 ;
          prmT000914 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("T00092", "SELECT `HisPwdFecha`, `HistPwdConstra`, `HistPwdLlave`, `HistPwdInd`, `UsuariosId` FROM `HistPwd` WHERE `UsuariosId` = ? AND `HisPwdFecha` = ?  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT00092,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00093", "SELECT `HisPwdFecha`, `HistPwdConstra`, `HistPwdLlave`, `HistPwdInd`, `UsuariosId` FROM `HistPwd` WHERE `UsuariosId` = ? AND `HisPwdFecha` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00093,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00094", "SELECT `UsuariosId` FROM `Usuarios` WHERE `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00094,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00095", "SELECT TM1.`HisPwdFecha`, TM1.`HistPwdConstra`, TM1.`HistPwdLlave`, TM1.`HistPwdInd`, TM1.`UsuariosId` FROM `HistPwd` TM1 WHERE TM1.`UsuariosId` = ? and TM1.`HisPwdFecha` = ? ORDER BY TM1.`UsuariosId`, TM1.`HisPwdFecha` ",true, GxErrorMask.GX_NOMASK, false, this,prmT00095,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00096", "SELECT `UsuariosId` FROM `Usuarios` WHERE `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00096,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00097", "SELECT `UsuariosId`, `HisPwdFecha` FROM `HistPwd` WHERE `UsuariosId` = ? AND `HisPwdFecha` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT00097,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00098", "SELECT `UsuariosId`, `HisPwdFecha` FROM `HistPwd` WHERE ( `UsuariosId` > ? or `UsuariosId` = ? and `HisPwdFecha` > ?) ORDER BY `UsuariosId`, `HisPwdFecha`  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT00098,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00099", "SELECT `UsuariosId`, `HisPwdFecha` FROM `HistPwd` WHERE ( `UsuariosId` < ? or `UsuariosId` = ? and `HisPwdFecha` < ?) ORDER BY `UsuariosId` DESC, `HisPwdFecha` DESC  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT00099,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000910", "INSERT INTO `HistPwd`(`HisPwdFecha`, `HistPwdConstra`, `HistPwdLlave`, `HistPwdInd`, `UsuariosId`) VALUES(?, ?, ?, ?, ?)", GxErrorMask.GX_NOMASK,prmT000910)
             ,new CursorDef("T000911", "UPDATE `HistPwd` SET `HistPwdConstra`=?, `HistPwdLlave`=?, `HistPwdInd`=?  WHERE `UsuariosId` = ? AND `HisPwdFecha` = ?", GxErrorMask.GX_NOMASK,prmT000911)
             ,new CursorDef("T000912", "DELETE FROM `HistPwd`  WHERE `UsuariosId` = ? AND `HisPwdFecha` = ?", GxErrorMask.GX_NOMASK,prmT000912)
             ,new CursorDef("T000913", "SELECT `UsuariosId`, `HisPwdFecha` FROM `HistPwd` ORDER BY `UsuariosId`, `HisPwdFecha` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000913,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000914", "SELECT `UsuariosId` FROM `Usuarios` WHERE `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmT000914,1, GxCacheFrequency.OFF ,true,false )
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
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((short[]) buf[3])[0] = rslt.getShort(4) ;
                ((int[]) buf[4])[0] = rslt.getInt(5) ;
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((short[]) buf[3])[0] = rslt.getShort(4) ;
                ((int[]) buf[4])[0] = rslt.getInt(5) ;
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 3 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((short[]) buf[3])[0] = rslt.getShort(4) ;
                ((int[]) buf[4])[0] = rslt.getInt(5) ;
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2) ;
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2) ;
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2) ;
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2) ;
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
                stmt.SetParameterDatetime(2, (DateTime)parms[1]);
                return;
             case 1 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameterDatetime(2, (DateTime)parms[1]);
                return;
             case 2 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 3 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameterDatetime(2, (DateTime)parms[1]);
                return;
             case 4 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 5 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameterDatetime(2, (DateTime)parms[1]);
                return;
             case 6 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameterDatetime(3, (DateTime)parms[2]);
                return;
             case 7 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameterDatetime(3, (DateTime)parms[2]);
                return;
             case 8 :
                stmt.SetParameterDatetime(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (String)parms[2]);
                stmt.SetParameter(4, (short)parms[3]);
                stmt.SetParameter(5, (int)parms[4]);
                return;
             case 9 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                stmt.SetParameter(4, (int)parms[3]);
                stmt.SetParameterDatetime(5, (DateTime)parms[4]);
                return;
             case 10 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameterDatetime(2, (DateTime)parms[1]);
                return;
             case 12 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

}
