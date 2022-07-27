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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wpvacanteinf : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpvacanteinf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public wpvacanteinf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_Vacantes_Id )
      {
         this.A263Vacantes_Id = aP0_Vacantes_Id;
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
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
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
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
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

      public override short ExecuteStartEvent( )
      {
         PA302( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START302( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 2036420), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202262714345454", false, true);
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
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle = bodyStyle + " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpvacanteinf.aspx"+UrlEncode("" +A263Vacantes_Id);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpvacanteinf.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((String)(sPrefix));
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE302( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT302( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpvacanteinf.aspx"+UrlEncode("" +A263Vacantes_Id);
         return formatLink("wpvacanteinf.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override String GetPgmname( )
      {
         return "wpVacanteInf" ;
      }

      public override String GetPgmdesc( )
      {
         return "wp Candidatos" ;
      }

      protected void WB300( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "WWAdvancedContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributestable_Internalname, 1, 0, "px", 0, "px", "FormContainer1", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Información", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_wpVacanteInf.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "Right", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblViellall_Internalname, "Regresar", "", "", lblViellall_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11301_client"+"'", "", "BtnTextBlockBack", 7, "", 1, 1, 0, "HLP_wpVacanteInf.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVacantes_Id_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtVacantes_Id_Internalname, "ID", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVacantes_Id_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A263Vacantes_Id), 9, 0, ",", "")), ((edtVacantes_Id_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A263Vacantes_Id), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A263Vacantes_Id), "ZZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVacantes_Id_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtVacantes_Id_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_wpVacanteInf.htm");
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
            GxWebStd.gx_label_element( context, edtVacantes_Nombre_Internalname, "Nombre", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVacantes_Nombre_Internalname, A264Vacantes_Nombre, StringUtil.RTrim( context.localUtil.Format( A264Vacantes_Nombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVacantes_Nombre_Jsonclick, 0, "ReadonlyAttribute", ((edtVacantes_Nombre_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;"), "", "", "", 1, edtVacantes_Nombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpVacanteInf.htm");
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
            GxWebStd.gx_label_element( context, cmbVacantes_Status_Internalname, "Estatús", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbVacantes_Status, cmbVacantes_Status_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A265Vacantes_Status), 4, 0)), 1, cmbVacantes_Status_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbVacantes_Status.Enabled, 0, 0, 0, "em", 0, "", "", "ReadonlyAttribute", "", "", "", "", true, "HLP_wpVacanteInf.htm");
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
            GxWebStd.gx_label_element( context, edtVacantes_FechaInicio_Internalname, "Fecha Inicio", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtVacantes_FechaInicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtVacantes_FechaInicio_Internalname, context.localUtil.Format(A266Vacantes_FechaInicio, "99/99/99"), context.localUtil.Format( A266Vacantes_FechaInicio, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVacantes_FechaInicio_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtVacantes_FechaInicio_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_wpVacanteInf.htm");
            GxWebStd.gx_bitmap( context, edtVacantes_FechaInicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVacantes_FechaInicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_wpVacanteInf.htm");
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
            GxWebStd.gx_label_element( context, edtVacantes_Sueldo_Internalname, "Sueldo", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVacantes_Sueldo_Internalname, StringUtil.LTrim( StringUtil.NToC( A267Vacantes_Sueldo, 6, 3, ",", "")), ((edtVacantes_Sueldo_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A267Vacantes_Sueldo, "Z9.999")) : context.localUtil.Format( A267Vacantes_Sueldo, "Z9.999")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVacantes_Sueldo_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtVacantes_Sueldo_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_wpVacanteInf.htm");
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
            GxWebStd.gx_label_element( context, cmbVacantes_Tipo_Internalname, "Tipo", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbVacantes_Tipo, cmbVacantes_Tipo_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A268Vacantes_Tipo), 4, 0)), 1, cmbVacantes_Tipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbVacantes_Tipo.Enabled, 0, 0, 0, "em", 0, "", "", "ReadonlyAttribute", "", "", "", "", true, "HLP_wpVacanteInf.htm");
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
            GxWebStd.gx_label_element( context, edtVacantes_Duracion_Internalname, "Duración", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVacantes_Duracion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A269Vacantes_Duracion), 4, 0, ",", "")), ((edtVacantes_Duracion_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A269Vacantes_Duracion), "ZZZ9")) : context.localUtil.Format( (decimal)(A269Vacantes_Duracion), "ZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVacantes_Duracion_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtVacantes_Duracion_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_wpVacanteInf.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbVacantes_Duracion_Nom_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbVacantes_Duracion_Nom_Internalname, "----", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbVacantes_Duracion_Nom, cmbVacantes_Duracion_Nom_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A270Vacantes_Duracion_Nom), 4, 0)), 1, cmbVacantes_Duracion_Nom_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbVacantes_Duracion_Nom.Enabled, 0, 0, 0, "em", 0, "", "", "ReadonlyAttribute", "", "", "", "", true, "HLP_wpVacanteInf.htm");
            cmbVacantes_Duracion_Nom.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A270Vacantes_Duracion_Nom), 4, 0));
            AssignProp("", false, cmbVacantes_Duracion_Nom_Internalname, "Values", (String)(cmbVacantes_Duracion_Nom.ToJavascriptSource()), true);
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
            GxWebStd.gx_label_element( context, edtVacantes_Descripcion_Internalname, "Descripción", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtVacantes_Descripcion_Internalname, A274Vacantes_Descripcion, "", "", 0, 1, edtVacantes_Descripcion_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "1000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_wpVacanteInf.htm");
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
            GxWebStd.gx_single_line_edit( context, edtVacantes_Plazas_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A277Vacantes_Plazas), 4, 0, ",", "")), ((edtVacantes_Plazas_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A277Vacantes_Plazas), "ZZZ9")) : context.localUtil.Format( (decimal)(A277Vacantes_Plazas), "ZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVacantes_Plazas_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVacantes_Plazas_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_wpVacanteInf.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START302( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 16_0_11-147071", 0) ;
            }
            Form.Meta.addItem("description", "wp Candidatos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP300( ) ;
      }

      protected void WS302( )
      {
         START302( ) ;
         EVT302( ) ;
      }

      protected void EVT302( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E12302 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E13302 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                 }
                                 dynload_actions( ) ;
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
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
      }

      protected void WE302( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA302( )
      {
         if ( nDonePA == 0 )
         {
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpvacanteinf.aspx")), "wpvacanteinf.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpvacanteinf.aspx")))) ;
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
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetNextPar( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     A263Vacantes_Id = (int)(NumberUtil.Val( gxfirstwebparm, "."));
                     AssignAttri("", false, "A263Vacantes_Id", StringUtil.LTrimStr( (decimal)(A263Vacantes_Id), 9, 0));
                  }
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
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
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
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

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF302( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF302( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00302 */
            pr_default.execute(0, new Object[] {A263Vacantes_Id});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A277Vacantes_Plazas = H00302_A277Vacantes_Plazas[0];
               AssignAttri("", false, "A277Vacantes_Plazas", StringUtil.LTrimStr( (decimal)(A277Vacantes_Plazas), 4, 0));
               A274Vacantes_Descripcion = H00302_A274Vacantes_Descripcion[0];
               AssignAttri("", false, "A274Vacantes_Descripcion", A274Vacantes_Descripcion);
               A270Vacantes_Duracion_Nom = H00302_A270Vacantes_Duracion_Nom[0];
               AssignAttri("", false, "A270Vacantes_Duracion_Nom", StringUtil.LTrimStr( (decimal)(A270Vacantes_Duracion_Nom), 4, 0));
               A269Vacantes_Duracion = H00302_A269Vacantes_Duracion[0];
               AssignAttri("", false, "A269Vacantes_Duracion", StringUtil.LTrimStr( (decimal)(A269Vacantes_Duracion), 4, 0));
               A268Vacantes_Tipo = H00302_A268Vacantes_Tipo[0];
               AssignAttri("", false, "A268Vacantes_Tipo", StringUtil.LTrimStr( (decimal)(A268Vacantes_Tipo), 4, 0));
               A267Vacantes_Sueldo = H00302_A267Vacantes_Sueldo[0];
               AssignAttri("", false, "A267Vacantes_Sueldo", StringUtil.LTrimStr( A267Vacantes_Sueldo, 6, 3));
               A266Vacantes_FechaInicio = H00302_A266Vacantes_FechaInicio[0];
               AssignAttri("", false, "A266Vacantes_FechaInicio", context.localUtil.Format(A266Vacantes_FechaInicio, "99/99/99"));
               A265Vacantes_Status = H00302_A265Vacantes_Status[0];
               AssignAttri("", false, "A265Vacantes_Status", StringUtil.LTrimStr( (decimal)(A265Vacantes_Status), 4, 0));
               A264Vacantes_Nombre = H00302_A264Vacantes_Nombre[0];
               AssignAttri("", false, "A264Vacantes_Nombre", A264Vacantes_Nombre);
               /* Execute user event: Load */
               E13302 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB300( ) ;
         }
      }

      protected void send_integrity_lvl_hashes302( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP300( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12302 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            A264Vacantes_Nombre = cgiGet( edtVacantes_Nombre_Internalname);
            AssignAttri("", false, "A264Vacantes_Nombre", A264Vacantes_Nombre);
            cmbVacantes_Status.CurrentValue = cgiGet( cmbVacantes_Status_Internalname);
            A265Vacantes_Status = (short)(NumberUtil.Val( cgiGet( cmbVacantes_Status_Internalname), "."));
            AssignAttri("", false, "A265Vacantes_Status", StringUtil.LTrimStr( (decimal)(A265Vacantes_Status), 4, 0));
            A266Vacantes_FechaInicio = context.localUtil.CToD( cgiGet( edtVacantes_FechaInicio_Internalname), 2);
            AssignAttri("", false, "A266Vacantes_FechaInicio", context.localUtil.Format(A266Vacantes_FechaInicio, "99/99/99"));
            A267Vacantes_Sueldo = context.localUtil.CToN( cgiGet( edtVacantes_Sueldo_Internalname), ",", ".");
            AssignAttri("", false, "A267Vacantes_Sueldo", StringUtil.LTrimStr( A267Vacantes_Sueldo, 6, 3));
            cmbVacantes_Tipo.CurrentValue = cgiGet( cmbVacantes_Tipo_Internalname);
            A268Vacantes_Tipo = (short)(NumberUtil.Val( cgiGet( cmbVacantes_Tipo_Internalname), "."));
            AssignAttri("", false, "A268Vacantes_Tipo", StringUtil.LTrimStr( (decimal)(A268Vacantes_Tipo), 4, 0));
            A269Vacantes_Duracion = (short)(context.localUtil.CToN( cgiGet( edtVacantes_Duracion_Internalname), ",", "."));
            AssignAttri("", false, "A269Vacantes_Duracion", StringUtil.LTrimStr( (decimal)(A269Vacantes_Duracion), 4, 0));
            cmbVacantes_Duracion_Nom.CurrentValue = cgiGet( cmbVacantes_Duracion_Nom_Internalname);
            A270Vacantes_Duracion_Nom = (short)(NumberUtil.Val( cgiGet( cmbVacantes_Duracion_Nom_Internalname), "."));
            AssignAttri("", false, "A270Vacantes_Duracion_Nom", StringUtil.LTrimStr( (decimal)(A270Vacantes_Duracion_Nom), 4, 0));
            A274Vacantes_Descripcion = cgiGet( edtVacantes_Descripcion_Internalname);
            AssignAttri("", false, "A274Vacantes_Descripcion", A274Vacantes_Descripcion);
            A277Vacantes_Plazas = (short)(context.localUtil.CToN( cgiGet( edtVacantes_Plazas_Internalname), ",", "."));
            AssignAttri("", false, "A277Vacantes_Plazas", StringUtil.LTrimStr( (decimal)(A277Vacantes_Plazas), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E12302 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E12302( )
      {
         /* Start Routine */
         edtVacantes_Nombre_Fontbold = 1;
         AssignProp("", false, edtVacantes_Nombre_Internalname, "Fontbold", StringUtil.Str( (decimal)(edtVacantes_Nombre_Fontbold), 1, 0), true);
      }

      protected void nextLoad( )
      {
      }

      protected void E13302( )
      {
         /* Load Routine */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A263Vacantes_Id = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "A263Vacantes_Id", StringUtil.LTrimStr( (decimal)(A263Vacantes_Id), 9, 0));
      }

      public override String getresponse( String sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA302( ) ;
         WS302( ) ;
         WE302( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( String sGXDynURL )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714345474", true, true);
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
         context.AddJavascriptSource("wpvacanteinf.js", "?202262714345474", false, true);
         /* End function include_jscripts */
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
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = "TEXTBLOCK1";
         lblViellall_Internalname = "VIELLALL";
         divTable2_Internalname = "TABLE2";
         edtVacantes_Id_Internalname = "VACANTES_ID";
         edtVacantes_Nombre_Internalname = "VACANTES_NOMBRE";
         cmbVacantes_Status_Internalname = "VACANTES_STATUS";
         edtVacantes_FechaInicio_Internalname = "VACANTES_FECHAINICIO";
         edtVacantes_Sueldo_Internalname = "VACANTES_SUELDO";
         cmbVacantes_Tipo_Internalname = "VACANTES_TIPO";
         edtVacantes_Duracion_Internalname = "VACANTES_DURACION";
         cmbVacantes_Duracion_Nom_Internalname = "VACANTES_DURACION_NOM";
         edtVacantes_Descripcion_Internalname = "VACANTES_DESCRIPCION";
         edtVacantes_Plazas_Internalname = "VACANTES_PLAZAS";
         divAttributestable_Internalname = "ATTRIBUTESTABLE";
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
         edtVacantes_Plazas_Jsonclick = "";
         edtVacantes_Plazas_Enabled = 0;
         edtVacantes_Descripcion_Enabled = 0;
         cmbVacantes_Duracion_Nom_Jsonclick = "";
         cmbVacantes_Duracion_Nom.Enabled = 0;
         edtVacantes_Duracion_Jsonclick = "";
         edtVacantes_Duracion_Enabled = 0;
         cmbVacantes_Tipo_Jsonclick = "";
         cmbVacantes_Tipo.Enabled = 0;
         edtVacantes_Sueldo_Jsonclick = "";
         edtVacantes_Sueldo_Enabled = 0;
         edtVacantes_FechaInicio_Jsonclick = "";
         edtVacantes_FechaInicio_Enabled = 0;
         cmbVacantes_Status_Jsonclick = "";
         cmbVacantes_Status.Enabled = 0;
         edtVacantes_Nombre_Jsonclick = "";
         edtVacantes_Nombre_Fontbold = 0;
         edtVacantes_Nombre_Enabled = 0;
         edtVacantes_Id_Jsonclick = "";
         edtVacantes_Id_Enabled = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "wp Candidatos";
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'REGRESAR'","{handler:'E11301',iparms:[]");
         setEventMetadata("'REGRESAR'",",oparms:[]}");
         setEventMetadata("VALID_VACANTES_ID","{handler:'Valid_Vacantes_id',iparms:[]");
         setEventMetadata("VALID_VACANTES_ID",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock1_Jsonclick = "";
         lblViellall_Jsonclick = "";
         A264Vacantes_Nombre = "";
         A266Vacantes_FechaInicio = DateTime.MinValue;
         ClassString = "";
         StyleString = "";
         A274Vacantes_Descripcion = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         scmdbuf = "";
         H00302_A263Vacantes_Id = new int[1] ;
         H00302_A277Vacantes_Plazas = new short[1] ;
         H00302_A274Vacantes_Descripcion = new String[] {""} ;
         H00302_A270Vacantes_Duracion_Nom = new short[1] ;
         H00302_A269Vacantes_Duracion = new short[1] ;
         H00302_A268Vacantes_Tipo = new short[1] ;
         H00302_A267Vacantes_Sueldo = new decimal[1] ;
         H00302_A266Vacantes_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         H00302_A265Vacantes_Status = new short[1] ;
         H00302_A264Vacantes_Nombre = new String[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpvacanteinf__default(),
            new Object[][] {
                new Object[] {
               H00302_A263Vacantes_Id, H00302_A277Vacantes_Plazas, H00302_A274Vacantes_Descripcion, H00302_A270Vacantes_Duracion_Nom, H00302_A269Vacantes_Duracion, H00302_A268Vacantes_Tipo, H00302_A267Vacantes_Sueldo, H00302_A266Vacantes_FechaInicio, H00302_A265Vacantes_Status, H00302_A264Vacantes_Nombre
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short edtVacantes_Nombre_Fontbold ;
      private short A265Vacantes_Status ;
      private short A268Vacantes_Tipo ;
      private short A269Vacantes_Duracion ;
      private short A270Vacantes_Duracion_Nom ;
      private short A277Vacantes_Plazas ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int A263Vacantes_Id ;
      private int wcpOA263Vacantes_Id ;
      private int edtVacantes_Id_Enabled ;
      private int edtVacantes_Nombre_Enabled ;
      private int edtVacantes_FechaInicio_Enabled ;
      private int edtVacantes_Sueldo_Enabled ;
      private int edtVacantes_Duracion_Enabled ;
      private int edtVacantes_Descripcion_Enabled ;
      private int edtVacantes_Plazas_Enabled ;
      private int idxLst ;
      private decimal A267Vacantes_Sueldo ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GXEncryptionTmp ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String divAttributestable_Internalname ;
      private String divTable2_Internalname ;
      private String lblTextblock1_Internalname ;
      private String lblTextblock1_Jsonclick ;
      private String lblViellall_Internalname ;
      private String lblViellall_Jsonclick ;
      private String edtVacantes_Id_Internalname ;
      private String edtVacantes_Id_Jsonclick ;
      private String edtVacantes_Nombre_Internalname ;
      private String edtVacantes_Nombre_Jsonclick ;
      private String cmbVacantes_Status_Internalname ;
      private String cmbVacantes_Status_Jsonclick ;
      private String edtVacantes_FechaInicio_Internalname ;
      private String edtVacantes_FechaInicio_Jsonclick ;
      private String edtVacantes_Sueldo_Internalname ;
      private String edtVacantes_Sueldo_Jsonclick ;
      private String cmbVacantes_Tipo_Internalname ;
      private String cmbVacantes_Tipo_Jsonclick ;
      private String edtVacantes_Duracion_Internalname ;
      private String edtVacantes_Duracion_Jsonclick ;
      private String cmbVacantes_Duracion_Nom_Internalname ;
      private String cmbVacantes_Duracion_Nom_Jsonclick ;
      private String edtVacantes_Descripcion_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String edtVacantes_Plazas_Internalname ;
      private String edtVacantes_Plazas_Jsonclick ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String GXDecQS ;
      private String scmdbuf ;
      private DateTime A266Vacantes_FechaInicio ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private String A264Vacantes_Nombre ;
      private String A274Vacantes_Descripcion ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbVacantes_Status ;
      private GXCombobox cmbVacantes_Tipo ;
      private GXCombobox cmbVacantes_Duracion_Nom ;
      private IDataStoreProvider pr_default ;
      private int[] H00302_A263Vacantes_Id ;
      private short[] H00302_A277Vacantes_Plazas ;
      private String[] H00302_A274Vacantes_Descripcion ;
      private short[] H00302_A270Vacantes_Duracion_Nom ;
      private short[] H00302_A269Vacantes_Duracion ;
      private short[] H00302_A268Vacantes_Tipo ;
      private decimal[] H00302_A267Vacantes_Sueldo ;
      private DateTime[] H00302_A266Vacantes_FechaInicio ;
      private short[] H00302_A265Vacantes_Status ;
      private String[] H00302_A264Vacantes_Nombre ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

   public class wpvacanteinf__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00302 ;
          prmH00302 = new Object[] {
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H00302", "SELECT `Vacantes_Id`, `Vacantes_Plazas`, `Vacantes_Descripcion`, `Vacantes_Duracion_Nom`, `Vacantes_Duracion`, `Vacantes_Tipo`, `Vacantes_Sueldo`, `Vacantes_FechaInicio`, `Vacantes_Status`, `Vacantes_Nombre` FROM `Vacantes` WHERE `Vacantes_Id` = ? ORDER BY `Vacantes_Id` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00302,1, GxCacheFrequency.OFF ,true,true )
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
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((short[]) buf[3])[0] = rslt.getShort(4) ;
                ((short[]) buf[4])[0] = rslt.getShort(5) ;
                ((short[]) buf[5])[0] = rslt.getShort(6) ;
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7) ;
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8) ;
                ((short[]) buf[8])[0] = rslt.getShort(9) ;
                ((String[]) buf[9])[0] = rslt.getVarchar(10) ;
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
       }
    }

 }

}
