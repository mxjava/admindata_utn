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
   public class vacantesgeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public vacantesgeneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (String)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("Carmine");
         }
      }

      public vacantesgeneral( IGxContext context )
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

      public override void SetPrefix( String sPPrefix )
      {
         sPrefix = sPPrefix;
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
         if ( StringUtil.Len( (String)(sPrefix)) == 0 )
         {
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetNextPar( );
                  sSFPrefix = GetNextPar( );
                  A263Vacantes_Id = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri(sPrefix, false, "A263Vacantes_Id", StringUtil.LTrimStr( (decimal)(A263Vacantes_Id), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(String)sCompPrefix,(String)sSFPrefix,(int)A263Vacantes_Id});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA272( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "VacantesGeneral";
               context.Gx_err = 0;
               WS272( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Vacantes General") ;
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
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 2036420), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202262714344519", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 2036420), false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("vacantesgeneral.aspx") + "?" + UrlEncode("" +A263Vacantes_Id)+"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( ) ;
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA263Vacantes_Id", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA263Vacantes_Id), 9, 0, ",", "")));
      }

      protected void RenderHtmlCloseForm272( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            context.AddJavascriptSource("vacantesgeneral.js", "?202262714344520", false, true);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
            SendComponentObjects();
            SendServerCommands();
            SendState();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
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
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override String GetPgmname( )
      {
         return "VacantesGeneral" ;
      }

      public override String GetPgmdesc( )
      {
         return "Vacantes General" ;
      }

      protected void WB270( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "vacantesgeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributestable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
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
            GxWebStd.gx_single_line_edit( context, edtVacantes_Id_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A263Vacantes_Id), 9, 0, ",", "")), ((edtVacantes_Id_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A263Vacantes_Id), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A263Vacantes_Id), "ZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVacantes_Id_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtVacantes_Id_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_VacantesGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtVacantes_Nombre_Internalname, A264Vacantes_Nombre, StringUtil.RTrim( context.localUtil.Format( A264Vacantes_Nombre, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVacantes_Nombre_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtVacantes_Nombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_VacantesGeneral.htm");
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
            GxWebStd.gx_label_element( context, cmbVacantes_Status_Internalname, "Estatus", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbVacantes_Status, cmbVacantes_Status_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A265Vacantes_Status), 4, 0)), 1, cmbVacantes_Status_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbVacantes_Status.Enabled, 0, 0, 0, "em", 0, "", "", "ReadonlyAttribute", "", "", "", "", true, "HLP_VacantesGeneral.htm");
            cmbVacantes_Status.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A265Vacantes_Status), 4, 0));
            AssignProp(sPrefix, false, cmbVacantes_Status_Internalname, "Values", (String)(cmbVacantes_Status.ToJavascriptSource()), true);
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
            GxWebStd.gx_label_element( context, edtVacantes_FechaInicio_Internalname, "Inicio", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtVacantes_FechaInicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtVacantes_FechaInicio_Internalname, context.localUtil.Format(A266Vacantes_FechaInicio, "99/99/99"), context.localUtil.Format( A266Vacantes_FechaInicio, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVacantes_FechaInicio_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtVacantes_FechaInicio_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_VacantesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtVacantes_FechaInicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVacantes_FechaInicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_VacantesGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtVacantes_Sueldo_Internalname, StringUtil.LTrim( StringUtil.NToC( A267Vacantes_Sueldo, 6, 3, ",", "")), ((edtVacantes_Sueldo_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A267Vacantes_Sueldo, "Z9.999")) : context.localUtil.Format( A267Vacantes_Sueldo, "Z9.999")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVacantes_Sueldo_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtVacantes_Sueldo_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_VacantesGeneral.htm");
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
            GxWebStd.gx_combobox_ctrl1( context, cmbVacantes_Tipo, cmbVacantes_Tipo_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A268Vacantes_Tipo), 4, 0)), 1, cmbVacantes_Tipo_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbVacantes_Tipo.Enabled, 0, 0, 0, "em", 0, "", "", "ReadonlyAttribute", "", "", "", "", true, "HLP_VacantesGeneral.htm");
            cmbVacantes_Tipo.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A268Vacantes_Tipo), 4, 0));
            AssignProp(sPrefix, false, cmbVacantes_Tipo_Internalname, "Values", (String)(cmbVacantes_Tipo.ToJavascriptSource()), true);
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
            GxWebStd.gx_single_line_edit( context, edtVacantes_Duracion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A269Vacantes_Duracion), 4, 0, ",", "")), ((edtVacantes_Duracion_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A269Vacantes_Duracion), "ZZZ9")) : context.localUtil.Format( (decimal)(A269Vacantes_Duracion), "ZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVacantes_Duracion_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtVacantes_Duracion_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_VacantesGeneral.htm");
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
            GxWebStd.gx_label_element( context, cmbVacantes_Duracion_Nom_Internalname, "----", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbVacantes_Duracion_Nom, cmbVacantes_Duracion_Nom_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A270Vacantes_Duracion_Nom), 4, 0)), 1, cmbVacantes_Duracion_Nom_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbVacantes_Duracion_Nom.Enabled, 0, 0, 0, "em", 0, "", "", "ReadonlyAttribute", "", "", "", "", true, "HLP_VacantesGeneral.htm");
            cmbVacantes_Duracion_Nom.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A270Vacantes_Duracion_Nom), 4, 0));
            AssignProp(sPrefix, false, cmbVacantes_Duracion_Nom_Internalname, "Values", (String)(cmbVacantes_Duracion_Nom.ToJavascriptSource()), true);
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
            GxWebStd.gx_html_textarea( context, edtVacantes_Descripcion_Internalname, A274Vacantes_Descripcion, "", "", 0, 1, edtVacantes_Descripcion_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "1000", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_VacantesGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtVacantes_Plazas_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A277Vacantes_Plazas), 4, 0, ",", "")), ((edtVacantes_Plazas_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A277Vacantes_Plazas), "ZZZ9")) : context.localUtil.Format( (decimal)(A277Vacantes_Plazas), "ZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVacantes_Plazas_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVacantes_Plazas_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_VacantesGeneral.htm");
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

      protected void START272( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus C# 16_0_11-147071", 0) ;
               }
               Form.Meta.addItem("description", "Vacantes General", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP270( ) ;
            }
         }
      }

      protected void WS272( )
      {
         START272( ) ;
         EVT272( ) ;
      }

      protected void EVT272( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E13272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E14272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
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

      protected void WE272( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm272( ) ;
            }
         }
      }

      protected void PA272( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
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
            AssignAttri(sPrefix, false, "A265Vacantes_Status", StringUtil.LTrimStr( (decimal)(A265Vacantes_Status), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbVacantes_Status.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A265Vacantes_Status), 4, 0));
            AssignProp(sPrefix, false, cmbVacantes_Status_Internalname, "Values", cmbVacantes_Status.ToJavascriptSource(), true);
         }
         if ( cmbVacantes_Tipo.ItemCount > 0 )
         {
            A268Vacantes_Tipo = (short)(NumberUtil.Val( cmbVacantes_Tipo.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A268Vacantes_Tipo), 4, 0))), "."));
            AssignAttri(sPrefix, false, "A268Vacantes_Tipo", StringUtil.LTrimStr( (decimal)(A268Vacantes_Tipo), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbVacantes_Tipo.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A268Vacantes_Tipo), 4, 0));
            AssignProp(sPrefix, false, cmbVacantes_Tipo_Internalname, "Values", cmbVacantes_Tipo.ToJavascriptSource(), true);
         }
         if ( cmbVacantes_Duracion_Nom.ItemCount > 0 )
         {
            A270Vacantes_Duracion_Nom = (short)(NumberUtil.Val( cmbVacantes_Duracion_Nom.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A270Vacantes_Duracion_Nom), 4, 0))), "."));
            AssignAttri(sPrefix, false, "A270Vacantes_Duracion_Nom", StringUtil.LTrimStr( (decimal)(A270Vacantes_Duracion_Nom), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbVacantes_Duracion_Nom.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A270Vacantes_Duracion_Nom), 4, 0));
            AssignProp(sPrefix, false, cmbVacantes_Duracion_Nom_Internalname, "Values", cmbVacantes_Duracion_Nom.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF272( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "VacantesGeneral";
         context.Gx_err = 0;
      }

      protected void RF272( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00272 */
            pr_default.execute(0, new Object[] {A263Vacantes_Id});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A277Vacantes_Plazas = H00272_A277Vacantes_Plazas[0];
               AssignAttri(sPrefix, false, "A277Vacantes_Plazas", StringUtil.LTrimStr( (decimal)(A277Vacantes_Plazas), 4, 0));
               A274Vacantes_Descripcion = H00272_A274Vacantes_Descripcion[0];
               AssignAttri(sPrefix, false, "A274Vacantes_Descripcion", A274Vacantes_Descripcion);
               A270Vacantes_Duracion_Nom = H00272_A270Vacantes_Duracion_Nom[0];
               AssignAttri(sPrefix, false, "A270Vacantes_Duracion_Nom", StringUtil.LTrimStr( (decimal)(A270Vacantes_Duracion_Nom), 4, 0));
               A269Vacantes_Duracion = H00272_A269Vacantes_Duracion[0];
               AssignAttri(sPrefix, false, "A269Vacantes_Duracion", StringUtil.LTrimStr( (decimal)(A269Vacantes_Duracion), 4, 0));
               A268Vacantes_Tipo = H00272_A268Vacantes_Tipo[0];
               AssignAttri(sPrefix, false, "A268Vacantes_Tipo", StringUtil.LTrimStr( (decimal)(A268Vacantes_Tipo), 4, 0));
               A267Vacantes_Sueldo = H00272_A267Vacantes_Sueldo[0];
               AssignAttri(sPrefix, false, "A267Vacantes_Sueldo", StringUtil.LTrimStr( A267Vacantes_Sueldo, 6, 3));
               A266Vacantes_FechaInicio = H00272_A266Vacantes_FechaInicio[0];
               AssignAttri(sPrefix, false, "A266Vacantes_FechaInicio", context.localUtil.Format(A266Vacantes_FechaInicio, "99/99/99"));
               A265Vacantes_Status = H00272_A265Vacantes_Status[0];
               AssignAttri(sPrefix, false, "A265Vacantes_Status", StringUtil.LTrimStr( (decimal)(A265Vacantes_Status), 4, 0));
               A264Vacantes_Nombre = H00272_A264Vacantes_Nombre[0];
               AssignAttri(sPrefix, false, "A264Vacantes_Nombre", A264Vacantes_Nombre);
               /* Execute user event: Load */
               E12272 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB270( ) ;
         }
      }

      protected void send_integrity_lvl_hashes272( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "VacantesGeneral";
         context.Gx_err = 0;
      }

      protected void STRUP270( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11272 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA263Vacantes_Id = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA263Vacantes_Id"), ",", "."));
            /* Read variables values. */
            A264Vacantes_Nombre = cgiGet( edtVacantes_Nombre_Internalname);
            AssignAttri(sPrefix, false, "A264Vacantes_Nombre", A264Vacantes_Nombre);
            cmbVacantes_Status.CurrentValue = cgiGet( cmbVacantes_Status_Internalname);
            A265Vacantes_Status = (short)(NumberUtil.Val( cgiGet( cmbVacantes_Status_Internalname), "."));
            AssignAttri(sPrefix, false, "A265Vacantes_Status", StringUtil.LTrimStr( (decimal)(A265Vacantes_Status), 4, 0));
            A266Vacantes_FechaInicio = context.localUtil.CToD( cgiGet( edtVacantes_FechaInicio_Internalname), 2);
            AssignAttri(sPrefix, false, "A266Vacantes_FechaInicio", context.localUtil.Format(A266Vacantes_FechaInicio, "99/99/99"));
            A267Vacantes_Sueldo = context.localUtil.CToN( cgiGet( edtVacantes_Sueldo_Internalname), ",", ".");
            AssignAttri(sPrefix, false, "A267Vacantes_Sueldo", StringUtil.LTrimStr( A267Vacantes_Sueldo, 6, 3));
            cmbVacantes_Tipo.CurrentValue = cgiGet( cmbVacantes_Tipo_Internalname);
            A268Vacantes_Tipo = (short)(NumberUtil.Val( cgiGet( cmbVacantes_Tipo_Internalname), "."));
            AssignAttri(sPrefix, false, "A268Vacantes_Tipo", StringUtil.LTrimStr( (decimal)(A268Vacantes_Tipo), 4, 0));
            A269Vacantes_Duracion = (short)(context.localUtil.CToN( cgiGet( edtVacantes_Duracion_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A269Vacantes_Duracion", StringUtil.LTrimStr( (decimal)(A269Vacantes_Duracion), 4, 0));
            cmbVacantes_Duracion_Nom.CurrentValue = cgiGet( cmbVacantes_Duracion_Nom_Internalname);
            A270Vacantes_Duracion_Nom = (short)(NumberUtil.Val( cgiGet( cmbVacantes_Duracion_Nom_Internalname), "."));
            AssignAttri(sPrefix, false, "A270Vacantes_Duracion_Nom", StringUtil.LTrimStr( (decimal)(A270Vacantes_Duracion_Nom), 4, 0));
            A274Vacantes_Descripcion = cgiGet( edtVacantes_Descripcion_Internalname);
            AssignAttri(sPrefix, false, "A274Vacantes_Descripcion", A274Vacantes_Descripcion);
            A277Vacantes_Plazas = (short)(context.localUtil.CToN( cgiGet( edtVacantes_Plazas_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A277Vacantes_Plazas", StringUtil.LTrimStr( (decimal)(A277Vacantes_Plazas), 4, 0));
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
         E11272 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11272( )
      {
         /* Start Routine */
         if ( ! new isauthorized(context).executeUdp(  AV13Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV13Pgmname)));
            context.wjLocDisableFrm = 1;
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E12272( )
      {
         /* Load Routine */
      }

      protected void E13272( )
      {
         /* 'DoUpdate' Routine */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "vacantes.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode("" +A263Vacantes_Id);
         CallWebObject(formatLink("vacantes.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E14272( )
      {
         /* 'DoDelete' Routine */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "vacantes.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode("" +A263Vacantes_Id);
         CallWebObject(formatLink("vacantes.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         AV7TrnContext = new SdtTransactionContext(context);
         AV7TrnContext.gxTpr_Callerobject = AV13Pgmname;
         AV7TrnContext.gxTpr_Callerondelete = false;
         AV7TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV7TrnContext.gxTpr_Transactionname = "Vacantes";
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "Vacantes_Id";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6Vacantes_Id), 9, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "TransactionContext", "ADMINDATA1"));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A263Vacantes_Id = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "A263Vacantes_Id", StringUtil.LTrimStr( (decimal)(A263Vacantes_Id), 9, 0));
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
         PA272( ) ;
         WS272( ) ;
         WE272( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( String sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlA263Vacantes_Id = (String)((String)getParm(obj,0));
      }

      public override void componentrestorestate( String sPPrefix ,
                                                  String sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA272( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (String)getParm(obj,0);
         sSFPrefix = (String)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "vacantesgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA272( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A263Vacantes_Id = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "A263Vacantes_Id", StringUtil.LTrimStr( (decimal)(A263Vacantes_Id), 9, 0));
         }
         wcpOA263Vacantes_Id = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA263Vacantes_Id"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( A263Vacantes_Id != wcpOA263Vacantes_Id ) ) )
         {
            setjustcreated();
         }
         wcpOA263Vacantes_Id = A263Vacantes_Id;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA263Vacantes_Id = cgiGet( sPrefix+"A263Vacantes_Id_CTRL");
         if ( StringUtil.Len( sCtrlA263Vacantes_Id) > 0 )
         {
            A263Vacantes_Id = (int)(context.localUtil.CToN( cgiGet( sCtrlA263Vacantes_Id), ",", "."));
            AssignAttri(sPrefix, false, "A263Vacantes_Id", StringUtil.LTrimStr( (decimal)(A263Vacantes_Id), 9, 0));
         }
         else
         {
            A263Vacantes_Id = (int)(context.localUtil.CToN( cgiGet( sPrefix+"A263Vacantes_Id_PARM"), ",", "."));
         }
      }

      public override void componentprocess( String sPPrefix ,
                                             String sPSFPrefix ,
                                             String sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA272( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS272( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS272( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A263Vacantes_Id_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A263Vacantes_Id), 9, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA263Vacantes_Id)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A263Vacantes_Id_CTRL", StringUtil.RTrim( sCtrlA263Vacantes_Id));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE272( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override String getstring( String sGXControl )
      {
         String sCtrlName ;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714344547", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("vacantesgeneral.js", "?202262714344547", false, true);
         }
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
         }
         cmbVacantes_Tipo.Name = "VACANTES_TIPO";
         cmbVacantes_Tipo.WebTags = "";
         cmbVacantes_Tipo.addItem("1", "Home Office", 0);
         cmbVacantes_Tipo.addItem("2", "Presencial", 0);
         cmbVacantes_Tipo.addItem("3", "Mixto", 0);
         if ( cmbVacantes_Tipo.ItemCount > 0 )
         {
         }
         cmbVacantes_Duracion_Nom.Name = "VACANTES_DURACION_NOM";
         cmbVacantes_Duracion_Nom.WebTags = "";
         cmbVacantes_Duracion_Nom.addItem("1", "Dias", 0);
         cmbVacantes_Duracion_Nom.addItem("2", "Meses", 0);
         cmbVacantes_Duracion_Nom.addItem("3", "Años", 0);
         if ( cmbVacantes_Duracion_Nom.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtVacantes_Id_Internalname = sPrefix+"VACANTES_ID";
         edtVacantes_Nombre_Internalname = sPrefix+"VACANTES_NOMBRE";
         cmbVacantes_Status_Internalname = sPrefix+"VACANTES_STATUS";
         edtVacantes_FechaInicio_Internalname = sPrefix+"VACANTES_FECHAINICIO";
         edtVacantes_Sueldo_Internalname = sPrefix+"VACANTES_SUELDO";
         cmbVacantes_Tipo_Internalname = sPrefix+"VACANTES_TIPO";
         edtVacantes_Duracion_Internalname = sPrefix+"VACANTES_DURACION";
         cmbVacantes_Duracion_Nom_Internalname = sPrefix+"VACANTES_DURACION_NOM";
         edtVacantes_Descripcion_Internalname = sPrefix+"VACANTES_DESCRIPCION";
         edtVacantes_Plazas_Internalname = sPrefix+"VACANTES_PLAZAS";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("Carmine");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
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
         edtVacantes_Nombre_Enabled = 0;
         edtVacantes_Id_Jsonclick = "";
         edtVacantes_Id_Enabled = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
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
         setEventMetadata("'DOUPDATE'","{handler:'E13272',iparms:[{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E14272',iparms:[{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
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
         sPrefix = "";
         AV13Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         A264Vacantes_Nombre = "";
         A266Vacantes_FechaInicio = DateTime.MinValue;
         ClassString = "";
         StyleString = "";
         A274Vacantes_Descripcion = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H00272_A263Vacantes_Id = new int[1] ;
         H00272_A277Vacantes_Plazas = new short[1] ;
         H00272_A274Vacantes_Descripcion = new String[] {""} ;
         H00272_A270Vacantes_Duracion_Nom = new short[1] ;
         H00272_A269Vacantes_Duracion = new short[1] ;
         H00272_A268Vacantes_Tipo = new short[1] ;
         H00272_A267Vacantes_Sueldo = new decimal[1] ;
         H00272_A266Vacantes_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         H00272_A265Vacantes_Status = new short[1] ;
         H00272_A264Vacantes_Nombre = new String[] {""} ;
         GXEncryptionTmp = "";
         AV7TrnContext = new SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA263Vacantes_Id = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.vacantesgeneral__default(),
            new Object[][] {
                new Object[] {
               H00272_A263Vacantes_Id, H00272_A277Vacantes_Plazas, H00272_A274Vacantes_Descripcion, H00272_A270Vacantes_Duracion_Nom, H00272_A269Vacantes_Duracion, H00272_A268Vacantes_Tipo, H00272_A267Vacantes_Sueldo, H00272_A266Vacantes_FechaInicio, H00272_A265Vacantes_Status, H00272_A264Vacantes_Nombre
               }
            }
         );
         AV13Pgmname = "VacantesGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "VacantesGeneral";
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short A265Vacantes_Status ;
      private short A268Vacantes_Tipo ;
      private short A269Vacantes_Duracion ;
      private short A270Vacantes_Duracion_Nom ;
      private short A277Vacantes_Plazas ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private int A263Vacantes_Id ;
      private int wcpOA263Vacantes_Id ;
      private int edtVacantes_Id_Enabled ;
      private int edtVacantes_Nombre_Enabled ;
      private int edtVacantes_FechaInicio_Enabled ;
      private int edtVacantes_Sueldo_Enabled ;
      private int edtVacantes_Duracion_Enabled ;
      private int edtVacantes_Descripcion_Enabled ;
      private int edtVacantes_Plazas_Enabled ;
      private int AV6Vacantes_Id ;
      private int idxLst ;
      private decimal A267Vacantes_Sueldo ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sPrefix ;
      private String sCompPrefix ;
      private String sSFPrefix ;
      private String AV13Pgmname ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String divMaintable_Internalname ;
      private String divAttributestable_Internalname ;
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
      private String sXEvt ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String scmdbuf ;
      private String GXEncryptionTmp ;
      private String sCtrlA263Vacantes_Id ;
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
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbVacantes_Status ;
      private GXCombobox cmbVacantes_Tipo ;
      private GXCombobox cmbVacantes_Duracion_Nom ;
      private IDataStoreProvider pr_default ;
      private int[] H00272_A263Vacantes_Id ;
      private short[] H00272_A277Vacantes_Plazas ;
      private String[] H00272_A274Vacantes_Descripcion ;
      private short[] H00272_A270Vacantes_Duracion_Nom ;
      private short[] H00272_A269Vacantes_Duracion ;
      private short[] H00272_A268Vacantes_Tipo ;
      private decimal[] H00272_A267Vacantes_Sueldo ;
      private DateTime[] H00272_A266Vacantes_FechaInicio ;
      private short[] H00272_A265Vacantes_Status ;
      private String[] H00272_A264Vacantes_Nombre ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private SdtTransactionContext AV7TrnContext ;
      private SdtTransactionContext_Attribute AV8TrnContextAtt ;
   }

   public class vacantesgeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00272 ;
          prmH00272 = new Object[] {
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H00272", "SELECT `Vacantes_Id`, `Vacantes_Plazas`, `Vacantes_Descripcion`, `Vacantes_Duracion_Nom`, `Vacantes_Duracion`, `Vacantes_Tipo`, `Vacantes_Sueldo`, `Vacantes_FechaInicio`, `Vacantes_Status`, `Vacantes_Nombre` FROM `Vacantes` WHERE `Vacantes_Id` = ? ORDER BY `Vacantes_Id` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00272,1, GxCacheFrequency.OFF ,true,true )
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
