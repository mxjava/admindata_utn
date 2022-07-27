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
   public class rolesusuarioswc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public rolesusuarioswc( )
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

      public rolesusuarioswc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_RolId )
      {
         this.AV6RolId = aP0_RolId;
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
         cmbUsuariosTipo = new GXCombobox();
         cmbUsuariosStatus = new GXCombobox();
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
                  AV6RolId = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri(sPrefix, false, "AV6RolId", StringUtil.LTrimStr( (decimal)(AV6RolId), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(String)sCompPrefix,(String)sSFPrefix,(int)AV6RolId});
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  nRC_GXsfl_20 = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  nGXsfl_20_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  sGXsfl_20_idx = GetNextPar( );
                  sPrefix = GetNextPar( );
                  AV11Update = GetNextPar( );
                  AV12Delete = GetNextPar( );
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxnrGrid_newrow( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
               {
                  subGrid_Rows = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AV6RolId = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AV11Update = GetNextPar( );
                  AV12Delete = GetNextPar( );
                  sPrefix = GetNextPar( );
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrGrid_refresh( subGrid_Rows, AV6RolId, AV11Update, AV12Delete, sPrefix) ;
                  AddString( context.getJSONResponse( )) ;
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
            PA2E2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV16Pgmname = "RolesUsuariosWC";
               context.Gx_err = 0;
               edtavUpdate_Enabled = 0;
               AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_20_Refreshing);
               edtavDelete_Enabled = 0;
               AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_20_Refreshing);
               WS2E2( ) ;
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
            context.SendWebValue( "Roles Usuarios WC") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714343287", false, true);
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
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("rolesusuarioswc.aspx") + "?" + UrlEncode("" +AV6RolId)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_20", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_20), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6RolId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV6RolId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vROLID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6RolId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm2E2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            context.AddJavascriptSource("rolesusuarioswc.js", "?202262714343290", false, true);
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
         return "RolesUsuariosWC" ;
      }

      public override String GetPgmdesc( )
      {
         return "Roles Usuarios WC" ;
      }

      protected void WB2E0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "rolesusuarioswc.aspx");
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "GridTabMainTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletop_Internalname, 1, 0, "px", 0, "px", "TableTopSearch", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-7 col-sm-2 col-sm-offset-1 ViewGridActionsCell", "Right", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group WWViewActions", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnAdd";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(20), 2, 0)+","+"null"+");", "Agregar", bttBtninsert_Jsonclick, 5, "Agregar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_RolesUsuariosWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 ViewGridCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"20\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "ViewGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid_Backcolorstyle == 0 )
               {
                  subGrid_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
               else
               {
                  subGrid_Titlebackstyle = 1;
                  if ( subGrid_Backcolorstyle == 1 )
                  {
                     subGrid_Titlebackcolor = subGrid_Allbackcolor;
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Clave de usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "CURP") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Apellido Paterno") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Apellido Materno") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tipo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Icono") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Nacimiento") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Edad") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Sexo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Contraseña") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Llave para encriptar pwd") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Inicio de Vigencia") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fin de Vigencia") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha de Captura") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Ip de Creación") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Teléfono") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "electrónico") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Usuarios Nom Completo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Sexo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Status") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               GridContainer.AddObjectProperty("GridName", "Grid");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  GridContainer = new GXWebGrid( context);
               }
               else
               {
                  GridContainer.Clear();
               }
               GridContainer.SetWrapped(nGXWrapped);
               GridContainer.AddObjectProperty("GridName", "Grid");
               GridContainer.AddObjectProperty("Header", subGrid_Header);
               GridContainer.AddObjectProperty("Class", "ViewGrid");
               GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("CmpContext", sPrefix);
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A105UsuariosCurp);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtUsuariosCurp_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A66UsuariosNombre);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A65UsuariosApPat);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A64UsuariosApMat);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A244UsuariosUsr);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A272UsuariosTipo), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( A245UsuariosIcono));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A255UsuariosFecNacimiento, "99/99/99"));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A256UsuariosEdad), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A257UsuariosSexo));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A68UsuariosPwd);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A67UsuariosKey);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A96UsuariosVigIni, "99/99/9999"));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A70UsuariosVigFin, "99/99/9999"));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.TToC( A92UsuariosFecCap, 10, 8, 0, 3, "/", ":", " "));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A93UsuariosIP);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A260UsuariosTelef));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A261UsuariosCorreo);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A97UsuariosNomCompleto);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A275UsuariosSexoFor));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A286UsuariosStatus), 1, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV11Update));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV12Delete));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 20 )
         {
            wbEnd = 0;
            nRC_GXsfl_20 = (int)(nGXsfl_20_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtRolId_Internalname, "Clave del rol", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtRolId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A24RolId), 9, 0, ",", "")), ((edtRolId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A24RolId), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A24RolId), "ZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRolId_Jsonclick, 0, "Attribute", "", "", "", "", edtRolId_Visible, edtRolId_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_RolesUsuariosWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 20 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2E2( )
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
               Form.Meta.addItem("description", "Roles Usuarios WC", 0) ;
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
               STRUP2E0( ) ;
            }
         }
      }

      protected void WS2E2( )
      {
         START2E2( ) ;
         EVT2E2( ) ;
      }

      protected void EVT2E2( )
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
                                 STRUP2E0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E112E2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2E0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2E0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2E0( ) ;
                              }
                              nGXsfl_20_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
                              SubsflControlProps_202( ) ;
                              A11UsuariosId = (int)(context.localUtil.CToN( cgiGet( edtUsuariosId_Internalname), ",", "."));
                              A105UsuariosCurp = StringUtil.Upper( cgiGet( edtUsuariosCurp_Internalname));
                              A66UsuariosNombre = StringUtil.Upper( cgiGet( edtUsuariosNombre_Internalname));
                              A65UsuariosApPat = StringUtil.Upper( cgiGet( edtUsuariosApPat_Internalname));
                              A64UsuariosApMat = StringUtil.Upper( cgiGet( edtUsuariosApMat_Internalname));
                              A244UsuariosUsr = cgiGet( edtUsuariosUsr_Internalname);
                              cmbUsuariosTipo.Name = cmbUsuariosTipo_Internalname;
                              cmbUsuariosTipo.CurrentValue = cgiGet( cmbUsuariosTipo_Internalname);
                              A272UsuariosTipo = (short)(NumberUtil.Val( cgiGet( cmbUsuariosTipo_Internalname), "."));
                              A245UsuariosIcono = cgiGet( edtUsuariosIcono_Internalname);
                              AssignProp(sPrefix, false, edtUsuariosIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A245UsuariosIcono)) ? A40000UsuariosIcono_GXI : context.convertURL( context.PathToRelativeUrl( A245UsuariosIcono))), !bGXsfl_20_Refreshing);
                              AssignProp(sPrefix, false, edtUsuariosIcono_Internalname, "SrcSet", context.GetImageSrcSet( A245UsuariosIcono), true);
                              A255UsuariosFecNacimiento = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtUsuariosFecNacimiento_Internalname), 0));
                              A256UsuariosEdad = (short)(context.localUtil.CToN( cgiGet( edtUsuariosEdad_Internalname), ",", "."));
                              A257UsuariosSexo = cgiGet( edtUsuariosSexo_Internalname);
                              A68UsuariosPwd = cgiGet( edtUsuariosPwd_Internalname);
                              A67UsuariosKey = cgiGet( edtUsuariosKey_Internalname);
                              A96UsuariosVigIni = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtUsuariosVigIni_Internalname), 0));
                              A70UsuariosVigFin = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtUsuariosVigFin_Internalname), 0));
                              n70UsuariosVigFin = false;
                              A92UsuariosFecCap = context.localUtil.CToT( cgiGet( edtUsuariosFecCap_Internalname), 0);
                              A93UsuariosIP = cgiGet( edtUsuariosIP_Internalname);
                              A260UsuariosTelef = cgiGet( edtUsuariosTelef_Internalname);
                              A261UsuariosCorreo = cgiGet( edtUsuariosCorreo_Internalname);
                              A97UsuariosNomCompleto = cgiGet( edtUsuariosNomCompleto_Internalname);
                              A275UsuariosSexoFor = cgiGet( edtUsuariosSexoFor_Internalname);
                              cmbUsuariosStatus.Name = cmbUsuariosStatus_Internalname;
                              cmbUsuariosStatus.CurrentValue = cgiGet( cmbUsuariosStatus_Internalname);
                              A286UsuariosStatus = (short)(NumberUtil.Val( cgiGet( cmbUsuariosStatus_Internalname), "."));
                              AV11Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV11Update);
                              AV12Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri(sPrefix, false, edtavDelete_Internalname, AV12Delete);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Start */
                                          E122E2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          E132E2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
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
                                       STRUP2E0( ) ;
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
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE2E2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2E2( ) ;
            }
         }
      }

      protected void PA2E2( )
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

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_202( ) ;
         while ( nGXsfl_20_idx <= nRC_GXsfl_20 )
         {
            sendrow_202( ) ;
            nGXsfl_20_idx = ((subGrid_Islastpage==1)&&(nGXsfl_20_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_20_idx+1);
            sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
            SubsflControlProps_202( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       int AV6RolId ,
                                       String AV11Update ,
                                       String AV12Delete ,
                                       String sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF2E2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_USUARIOSID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"USUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ".", "")));
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV16Pgmname = "RolesUsuariosWC";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_20_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_20_Refreshing);
      }

      protected void RF2E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 20;
         nGXsfl_20_idx = 1;
         sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
         SubsflControlProps_202( ) ;
         bGXsfl_20_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "ViewGrid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_202( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            /* Using cursor H002E2 */
            pr_default.execute(0, new Object[] {AV6RolId, GXPagingFrom2, GXPagingTo2});
            nGXsfl_20_idx = 1;
            sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
            SubsflControlProps_202( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A24RolId = H002E2_A24RolId[0];
               AssignAttri(sPrefix, false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
               A286UsuariosStatus = H002E2_A286UsuariosStatus[0];
               A261UsuariosCorreo = H002E2_A261UsuariosCorreo[0];
               A260UsuariosTelef = H002E2_A260UsuariosTelef[0];
               A93UsuariosIP = H002E2_A93UsuariosIP[0];
               A92UsuariosFecCap = H002E2_A92UsuariosFecCap[0];
               A70UsuariosVigFin = H002E2_A70UsuariosVigFin[0];
               n70UsuariosVigFin = H002E2_n70UsuariosVigFin[0];
               A96UsuariosVigIni = H002E2_A96UsuariosVigIni[0];
               A67UsuariosKey = H002E2_A67UsuariosKey[0];
               A68UsuariosPwd = H002E2_A68UsuariosPwd[0];
               A256UsuariosEdad = H002E2_A256UsuariosEdad[0];
               A255UsuariosFecNacimiento = H002E2_A255UsuariosFecNacimiento[0];
               A40000UsuariosIcono_GXI = H002E2_A40000UsuariosIcono_GXI[0];
               AssignProp(sPrefix, false, edtUsuariosIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A245UsuariosIcono)) ? A40000UsuariosIcono_GXI : context.convertURL( context.PathToRelativeUrl( A245UsuariosIcono))), !bGXsfl_20_Refreshing);
               AssignProp(sPrefix, false, edtUsuariosIcono_Internalname, "SrcSet", context.GetImageSrcSet( A245UsuariosIcono), true);
               A272UsuariosTipo = H002E2_A272UsuariosTipo[0];
               A244UsuariosUsr = H002E2_A244UsuariosUsr[0];
               A105UsuariosCurp = H002E2_A105UsuariosCurp[0];
               A11UsuariosId = H002E2_A11UsuariosId[0];
               A64UsuariosApMat = H002E2_A64UsuariosApMat[0];
               A65UsuariosApPat = H002E2_A65UsuariosApPat[0];
               A66UsuariosNombre = H002E2_A66UsuariosNombre[0];
               A257UsuariosSexo = H002E2_A257UsuariosSexo[0];
               A245UsuariosIcono = H002E2_A245UsuariosIcono[0];
               AssignProp(sPrefix, false, edtUsuariosIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A245UsuariosIcono)) ? A40000UsuariosIcono_GXI : context.convertURL( context.PathToRelativeUrl( A245UsuariosIcono))), !bGXsfl_20_Refreshing);
               AssignProp(sPrefix, false, edtUsuariosIcono_Internalname, "SrcSet", context.GetImageSrcSet( A245UsuariosIcono), true);
               if ( StringUtil.StrCmp(A257UsuariosSexo, "H") == 0 )
               {
                  A275UsuariosSexoFor = "Hombres";
               }
               else
               {
                  if ( StringUtil.StrCmp(A257UsuariosSexo, "M") == 0 )
                  {
                     A275UsuariosSexoFor = "Mujeres";
                  }
                  else
                  {
                     A275UsuariosSexoFor = "";
                  }
               }
               A97UsuariosNomCompleto = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + StringUtil.Trim( A64UsuariosApMat);
               E132E2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 20;
            WB2E0( ) ;
         }
         bGXsfl_20_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2E2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_USUARIOSID"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sPrefix+sGXsfl_20_idx, context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9"), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         /* Using cursor H002E3 */
         pr_default.execute(1, new Object[] {AV6RolId});
         GRID_nRecordCount = H002E3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV6RolId, AV11Update, AV12Delete, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV6RolId, AV11Update, AV12Delete, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV6RolId, AV11Update, AV12Delete, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV6RolId, AV11Update, AV12Delete, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV6RolId, AV11Update, AV12Delete, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV16Pgmname = "RolesUsuariosWC";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_20_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_20_Refreshing);
      }

      protected void STRUP2E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E122E2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_20 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_20"), ",", "."));
            wcpOAV6RolId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6RolId"), ",", "."));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            A24RolId = (int)(context.localUtil.CToN( cgiGet( edtRolId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A24RolId", StringUtil.LTrimStr( (decimal)(A24RolId), 9, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E122E2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E122E2( )
      {
         /* Start Routine */
         if ( ! new isauthorized(context).executeUdp(  AV16Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV16Pgmname)));
            context.wjLocDisableFrm = 1;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         AV11Update = "Modificar";
         AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV11Update);
         AV12Delete = "Eliminar";
         AssignAttri(sPrefix, false, edtavDelete_Internalname, AV12Delete);
         edtRolId_Visible = 0;
         AssignProp(sPrefix, false, edtRolId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtRolId_Visible), 5, 0), true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      private void E132E2( )
      {
         /* Grid_Load Routine */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "usuarios.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode("" +A11UsuariosId);
         edtavUpdate_Link = formatLink("usuarios.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "usuarios.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode("" +A11UsuariosId);
         edtavDelete_Link = formatLink("usuarios.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         edtUsuariosCurp_Link = formatLink("viewusuarios.aspx") + "?" + UrlEncode("" +A11UsuariosId) + "," + UrlEncode(StringUtil.RTrim(""));
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 20;
         }
         sendrow_202( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_20_Refreshing )
         {
            context.DoAjaxLoad(20, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E112E2( )
      {
         /* 'DoInsert' Routine */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "usuarios.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode("" +0);
         CallWebObject(formatLink("usuarios.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         AV9TrnContext = new SdtTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV16Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Usuarios";
         AV10TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV10TrnContextAtt.gxTpr_Attributename = "RolId";
         AV10TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6RolId), 9, 0);
         AV9TrnContext.gxTpr_Attributes.Add(AV10TrnContextAtt, 0);
         AV7Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "TransactionContext", "ADMINDATA1"));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6RolId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV6RolId", StringUtil.LTrimStr( (decimal)(AV6RolId), 9, 0));
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
         PA2E2( ) ;
         WS2E2( ) ;
         WE2E2( ) ;
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
         sCtrlAV6RolId = (String)((String)getParm(obj,0));
      }

      public override void componentrestorestate( String sPPrefix ,
                                                  String sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2E2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (String)getParm(obj,0);
         sSFPrefix = (String)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "rolesusuarioswc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2E2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6RolId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV6RolId", StringUtil.LTrimStr( (decimal)(AV6RolId), 9, 0));
         }
         wcpOAV6RolId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6RolId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( AV6RolId != wcpOAV6RolId ) ) )
         {
            setjustcreated();
         }
         wcpOAV6RolId = AV6RolId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6RolId = cgiGet( sPrefix+"AV6RolId_CTRL");
         if ( StringUtil.Len( sCtrlAV6RolId) > 0 )
         {
            AV6RolId = (int)(context.localUtil.CToN( cgiGet( sCtrlAV6RolId), ",", "."));
            AssignAttri(sPrefix, false, "AV6RolId", StringUtil.LTrimStr( (decimal)(AV6RolId), 9, 0));
         }
         else
         {
            AV6RolId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV6RolId_PARM"), ",", "."));
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
         PA2E2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2E2( ) ;
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
         WS2E2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6RolId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6RolId), 9, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6RolId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6RolId_CTRL", StringUtil.RTrim( sCtrlAV6RolId));
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
         WE2E2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714343367", true, true);
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
            context.AddJavascriptSource("rolesusuarioswc.js", "?202262714343368", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_202( )
      {
         edtUsuariosId_Internalname = sPrefix+"USUARIOSID_"+sGXsfl_20_idx;
         edtUsuariosCurp_Internalname = sPrefix+"USUARIOSCURP_"+sGXsfl_20_idx;
         edtUsuariosNombre_Internalname = sPrefix+"USUARIOSNOMBRE_"+sGXsfl_20_idx;
         edtUsuariosApPat_Internalname = sPrefix+"USUARIOSAPPAT_"+sGXsfl_20_idx;
         edtUsuariosApMat_Internalname = sPrefix+"USUARIOSAPMAT_"+sGXsfl_20_idx;
         edtUsuariosUsr_Internalname = sPrefix+"USUARIOSUSR_"+sGXsfl_20_idx;
         cmbUsuariosTipo_Internalname = sPrefix+"USUARIOSTIPO_"+sGXsfl_20_idx;
         edtUsuariosIcono_Internalname = sPrefix+"USUARIOSICONO_"+sGXsfl_20_idx;
         edtUsuariosFecNacimiento_Internalname = sPrefix+"USUARIOSFECNACIMIENTO_"+sGXsfl_20_idx;
         edtUsuariosEdad_Internalname = sPrefix+"USUARIOSEDAD_"+sGXsfl_20_idx;
         edtUsuariosSexo_Internalname = sPrefix+"USUARIOSSEXO_"+sGXsfl_20_idx;
         edtUsuariosPwd_Internalname = sPrefix+"USUARIOSPWD_"+sGXsfl_20_idx;
         edtUsuariosKey_Internalname = sPrefix+"USUARIOSKEY_"+sGXsfl_20_idx;
         edtUsuariosVigIni_Internalname = sPrefix+"USUARIOSVIGINI_"+sGXsfl_20_idx;
         edtUsuariosVigFin_Internalname = sPrefix+"USUARIOSVIGFIN_"+sGXsfl_20_idx;
         edtUsuariosFecCap_Internalname = sPrefix+"USUARIOSFECCAP_"+sGXsfl_20_idx;
         edtUsuariosIP_Internalname = sPrefix+"USUARIOSIP_"+sGXsfl_20_idx;
         edtUsuariosTelef_Internalname = sPrefix+"USUARIOSTELEF_"+sGXsfl_20_idx;
         edtUsuariosCorreo_Internalname = sPrefix+"USUARIOSCORREO_"+sGXsfl_20_idx;
         edtUsuariosNomCompleto_Internalname = sPrefix+"USUARIOSNOMCOMPLETO_"+sGXsfl_20_idx;
         edtUsuariosSexoFor_Internalname = sPrefix+"USUARIOSSEXOFOR_"+sGXsfl_20_idx;
         cmbUsuariosStatus_Internalname = sPrefix+"USUARIOSSTATUS_"+sGXsfl_20_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_20_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_20_idx;
      }

      protected void SubsflControlProps_fel_202( )
      {
         edtUsuariosId_Internalname = sPrefix+"USUARIOSID_"+sGXsfl_20_fel_idx;
         edtUsuariosCurp_Internalname = sPrefix+"USUARIOSCURP_"+sGXsfl_20_fel_idx;
         edtUsuariosNombre_Internalname = sPrefix+"USUARIOSNOMBRE_"+sGXsfl_20_fel_idx;
         edtUsuariosApPat_Internalname = sPrefix+"USUARIOSAPPAT_"+sGXsfl_20_fel_idx;
         edtUsuariosApMat_Internalname = sPrefix+"USUARIOSAPMAT_"+sGXsfl_20_fel_idx;
         edtUsuariosUsr_Internalname = sPrefix+"USUARIOSUSR_"+sGXsfl_20_fel_idx;
         cmbUsuariosTipo_Internalname = sPrefix+"USUARIOSTIPO_"+sGXsfl_20_fel_idx;
         edtUsuariosIcono_Internalname = sPrefix+"USUARIOSICONO_"+sGXsfl_20_fel_idx;
         edtUsuariosFecNacimiento_Internalname = sPrefix+"USUARIOSFECNACIMIENTO_"+sGXsfl_20_fel_idx;
         edtUsuariosEdad_Internalname = sPrefix+"USUARIOSEDAD_"+sGXsfl_20_fel_idx;
         edtUsuariosSexo_Internalname = sPrefix+"USUARIOSSEXO_"+sGXsfl_20_fel_idx;
         edtUsuariosPwd_Internalname = sPrefix+"USUARIOSPWD_"+sGXsfl_20_fel_idx;
         edtUsuariosKey_Internalname = sPrefix+"USUARIOSKEY_"+sGXsfl_20_fel_idx;
         edtUsuariosVigIni_Internalname = sPrefix+"USUARIOSVIGINI_"+sGXsfl_20_fel_idx;
         edtUsuariosVigFin_Internalname = sPrefix+"USUARIOSVIGFIN_"+sGXsfl_20_fel_idx;
         edtUsuariosFecCap_Internalname = sPrefix+"USUARIOSFECCAP_"+sGXsfl_20_fel_idx;
         edtUsuariosIP_Internalname = sPrefix+"USUARIOSIP_"+sGXsfl_20_fel_idx;
         edtUsuariosTelef_Internalname = sPrefix+"USUARIOSTELEF_"+sGXsfl_20_fel_idx;
         edtUsuariosCorreo_Internalname = sPrefix+"USUARIOSCORREO_"+sGXsfl_20_fel_idx;
         edtUsuariosNomCompleto_Internalname = sPrefix+"USUARIOSNOMCOMPLETO_"+sGXsfl_20_fel_idx;
         edtUsuariosSexoFor_Internalname = sPrefix+"USUARIOSSEXOFOR_"+sGXsfl_20_fel_idx;
         cmbUsuariosStatus_Internalname = sPrefix+"USUARIOSSTATUS_"+sGXsfl_20_fel_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_20_fel_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_20_fel_idx;
      }

      protected void sendrow_202( )
      {
         SubsflControlProps_202( ) ;
         WB2E0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_20_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_20_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"ViewGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_20_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")),context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9"),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosId_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)6,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)0,(bool)true,(String)"NumId",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosCurp_Internalname,(String)A105UsuariosCurp,StringUtil.RTrim( context.localUtil.Format( A105UsuariosCurp, "@!")),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)edtUsuariosCurp_Link,(String)"",(String)"",(String)"",(String)edtUsuariosCurp_Jsonclick,(short)0,(String)"DescriptionAttribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)18,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosNombre_Internalname,(String)A66UsuariosNombre,StringUtil.RTrim( context.localUtil.Format( A66UsuariosNombre, "@!")),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosNombre_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)40,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosApPat_Internalname,(String)A65UsuariosApPat,StringUtil.RTrim( context.localUtil.Format( A65UsuariosApPat, "@!")),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosApPat_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)40,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosApMat_Internalname,(String)A64UsuariosApMat,StringUtil.RTrim( context.localUtil.Format( A64UsuariosApMat, "@!")),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosApMat_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)40,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosUsr_Internalname,(String)A244UsuariosUsr,(String)"",(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosUsr_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)20,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbUsuariosTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "USUARIOSTIPO_" + sGXsfl_20_idx;
               cmbUsuariosTipo.Name = GXCCtl;
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
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbUsuariosTipo,(String)cmbUsuariosTipo_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A272UsuariosTipo), 4, 0)),(short)1,(String)cmbUsuariosTipo_Jsonclick,(short)0,(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute",(String)"WWColumn WWOptionalColumn",(String)"",(String)"",(String)"",(bool)true});
            cmbUsuariosTipo.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A272UsuariosTipo), 4, 0));
            AssignProp(sPrefix, false, cmbUsuariosTipo_Internalname, "Values", (String)(cmbUsuariosTipo.ToJavascriptSource()), !bGXsfl_20_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "ImageAttribute";
            StyleString = "";
            A245UsuariosIcono_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A245UsuariosIcono))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000UsuariosIcono_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A245UsuariosIcono)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A245UsuariosIcono)) ? A40000UsuariosIcono_GXI : context.PathToRelativeUrl( A245UsuariosIcono));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosIcono_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)-1,(short)0,(String)"",(String)"",(short)1,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"WWColumn WWOptionalColumn",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)A245UsuariosIcono_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosFecNacimiento_Internalname,context.localUtil.Format(A255UsuariosFecNacimiento, "99/99/99"),context.localUtil.Format( A255UsuariosFecNacimiento, "99/99/99"),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosFecNacimiento_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)8,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosEdad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A256UsuariosEdad), 4, 0, ",", "")),context.localUtil.Format( (decimal)(A256UsuariosEdad), "ZZZ9"),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosEdad_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)4,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosSexo_Internalname,StringUtil.RTrim( A257UsuariosSexo),(String)"",(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosSexo_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)1,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(String)"Sexo",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosPwd_Internalname,(String)A68UsuariosPwd,(String)"",(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosPwd_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)32,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosKey_Internalname,(String)A67UsuariosKey,(String)"",(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosKey_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)32,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosVigIni_Internalname,context.localUtil.Format(A96UsuariosVigIni, "99/99/9999"),context.localUtil.Format( A96UsuariosVigIni, "99/99/9999"),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosVigIni_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)0,(bool)true,(String)"Fecha",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosVigFin_Internalname,context.localUtil.Format(A70UsuariosVigFin, "99/99/9999"),context.localUtil.Format( A70UsuariosVigFin, "99/99/9999"),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosVigFin_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)0,(bool)true,(String)"Fecha",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosFecCap_Internalname,context.localUtil.TToC( A92UsuariosFecCap, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A92UsuariosFecCap, "99/99/9999 99:99:99"),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosFecCap_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)19,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaTiempo",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosIP_Internalname,(String)A93UsuariosIP,(String)"",(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosIP_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)15,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(String)"Ip",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosTelef_Internalname,StringUtil.RTrim( A260UsuariosTelef),(String)"",(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosTelef_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosCorreo_Internalname,(String)A261UsuariosCorreo,(String)"",(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"mailto:"+A261UsuariosCorreo,(String)"",(String)"",(String)"",(String)edtUsuariosCorreo_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"email",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)100,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)0,(bool)true,(String)"GeneXus\\Email",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosNomCompleto_Internalname,(String)A97UsuariosNomCompleto,(String)"",(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosNomCompleto_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)90,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosSexoFor_Internalname,StringUtil.RTrim( A275UsuariosSexoFor),(String)"",(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosSexoFor_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)1,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(String)"Sexo",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbUsuariosStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "USUARIOSSTATUS_" + sGXsfl_20_idx;
               cmbUsuariosStatus.Name = GXCCtl;
               cmbUsuariosStatus.WebTags = "";
               cmbUsuariosStatus.addItem("1", "Activo", 0);
               cmbUsuariosStatus.addItem("0", "Inactivo", 0);
               if ( cmbUsuariosStatus.ItemCount > 0 )
               {
                  A286UsuariosStatus = (short)(NumberUtil.Val( cmbUsuariosStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A286UsuariosStatus), 1, 0))), "."));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbUsuariosStatus,(String)cmbUsuariosStatus_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A286UsuariosStatus), 1, 0)),(short)1,(String)cmbUsuariosStatus_Jsonclick,(short)0,(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute",(String)"WWColumn WWOptionalColumn",(String)"",(String)"",(String)"",(bool)true});
            cmbUsuariosStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A286UsuariosStatus), 1, 0));
            AssignProp(sPrefix, false, cmbUsuariosStatus_Internalname, "Values", (String)(cmbUsuariosStatus.ToJavascriptSource()), !bGXsfl_20_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "TextActionAttribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavUpdate_Internalname,StringUtil.RTrim( AV11Update),(String)"",(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)edtavUpdate_Link,(String)"",(String)"",(String)"",(String)edtavUpdate_Jsonclick,(short)0,(String)"TextActionAttribute",(String)"",(String)ROClassString,(String)"WWTextActionColumn",(String)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)20,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "TextActionAttribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavDelete_Internalname,StringUtil.RTrim( AV12Delete),(String)"",(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)edtavDelete_Link,(String)"",(String)"",(String)"",(String)edtavDelete_Jsonclick,(short)0,(String)"TextActionAttribute",(String)"",(String)ROClassString,(String)"WWTextActionColumn",(String)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)20,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            send_integrity_lvl_hashes2E2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_20_idx = ((subGrid_Islastpage==1)&&(nGXsfl_20_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_20_idx+1);
            sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
            SubsflControlProps_202( ) ;
         }
         /* End function sendrow_202 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "USUARIOSTIPO_" + sGXsfl_20_idx;
         cmbUsuariosTipo.Name = GXCCtl;
         cmbUsuariosTipo.WebTags = "";
         cmbUsuariosTipo.addItem("1", "Administrador", 0);
         cmbUsuariosTipo.addItem("6", "Postulantes", 0);
         cmbUsuariosTipo.addItem("4", "Operaciones", 0);
         cmbUsuariosTipo.addItem("2", "Coordinador RYS", 0);
         cmbUsuariosTipo.addItem("5", "Reclutador", 0);
         cmbUsuariosTipo.addItem("3", "Candidatos", 0);
         if ( cmbUsuariosTipo.ItemCount > 0 )
         {
         }
         GXCCtl = "USUARIOSSTATUS_" + sGXsfl_20_idx;
         cmbUsuariosStatus.Name = GXCCtl;
         cmbUsuariosStatus.WebTags = "";
         cmbUsuariosStatus.addItem("1", "Activo", 0);
         cmbUsuariosStatus.addItem("0", "Inactivo", 0);
         if ( cmbUsuariosStatus.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtninsert_Internalname = sPrefix+"BTNINSERT";
         divTabletop_Internalname = sPrefix+"TABLETOP";
         edtUsuariosId_Internalname = sPrefix+"USUARIOSID";
         edtUsuariosCurp_Internalname = sPrefix+"USUARIOSCURP";
         edtUsuariosNombre_Internalname = sPrefix+"USUARIOSNOMBRE";
         edtUsuariosApPat_Internalname = sPrefix+"USUARIOSAPPAT";
         edtUsuariosApMat_Internalname = sPrefix+"USUARIOSAPMAT";
         edtUsuariosUsr_Internalname = sPrefix+"USUARIOSUSR";
         cmbUsuariosTipo_Internalname = sPrefix+"USUARIOSTIPO";
         edtUsuariosIcono_Internalname = sPrefix+"USUARIOSICONO";
         edtUsuariosFecNacimiento_Internalname = sPrefix+"USUARIOSFECNACIMIENTO";
         edtUsuariosEdad_Internalname = sPrefix+"USUARIOSEDAD";
         edtUsuariosSexo_Internalname = sPrefix+"USUARIOSSEXO";
         edtUsuariosPwd_Internalname = sPrefix+"USUARIOSPWD";
         edtUsuariosKey_Internalname = sPrefix+"USUARIOSKEY";
         edtUsuariosVigIni_Internalname = sPrefix+"USUARIOSVIGINI";
         edtUsuariosVigFin_Internalname = sPrefix+"USUARIOSVIGFIN";
         edtUsuariosFecCap_Internalname = sPrefix+"USUARIOSFECCAP";
         edtUsuariosIP_Internalname = sPrefix+"USUARIOSIP";
         edtUsuariosTelef_Internalname = sPrefix+"USUARIOSTELEF";
         edtUsuariosCorreo_Internalname = sPrefix+"USUARIOSCORREO";
         edtUsuariosNomCompleto_Internalname = sPrefix+"USUARIOSNOMCOMPLETO";
         edtUsuariosSexoFor_Internalname = sPrefix+"USUARIOSSEXOFOR";
         cmbUsuariosStatus_Internalname = sPrefix+"USUARIOSSTATUS";
         edtavUpdate_Internalname = sPrefix+"vUPDATE";
         edtavDelete_Internalname = sPrefix+"vDELETE";
         divGridtable_Internalname = sPrefix+"GRIDTABLE";
         divGridcell_Internalname = sPrefix+"GRIDCELL";
         edtRolId_Internalname = sPrefix+"ROLID";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
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
         edtavDelete_Jsonclick = "";
         edtavUpdate_Jsonclick = "";
         cmbUsuariosStatus_Jsonclick = "";
         edtUsuariosSexoFor_Jsonclick = "";
         edtUsuariosNomCompleto_Jsonclick = "";
         edtUsuariosCorreo_Jsonclick = "";
         edtUsuariosTelef_Jsonclick = "";
         edtUsuariosIP_Jsonclick = "";
         edtUsuariosFecCap_Jsonclick = "";
         edtUsuariosVigFin_Jsonclick = "";
         edtUsuariosVigIni_Jsonclick = "";
         edtUsuariosKey_Jsonclick = "";
         edtUsuariosPwd_Jsonclick = "";
         edtUsuariosSexo_Jsonclick = "";
         edtUsuariosEdad_Jsonclick = "";
         edtUsuariosFecNacimiento_Jsonclick = "";
         cmbUsuariosTipo_Jsonclick = "";
         edtUsuariosUsr_Jsonclick = "";
         edtUsuariosApMat_Jsonclick = "";
         edtUsuariosApPat_Jsonclick = "";
         edtUsuariosNombre_Jsonclick = "";
         edtUsuariosCurp_Jsonclick = "";
         edtUsuariosId_Jsonclick = "";
         edtRolId_Jsonclick = "";
         edtRolId_Enabled = 0;
         edtRolId_Visible = 1;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtavDelete_Link = "";
         edtavUpdate_Link = "";
         edtUsuariosCurp_Link = "";
         subGrid_Header = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Enabled = 0;
         subGrid_Class = "ViewGrid";
         subGrid_Backcolorstyle = 0;
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6RolId',fld:'vROLID',pic:'ZZZZZZZZ9'},{av:'AV11Update',fld:'vUPDATE',pic:''},{av:'AV12Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID.LOAD","{handler:'E132E2',iparms:[{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtUsuariosCurp_Link',ctrl:'USUARIOSCURP',prop:'Link'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E112E2',iparms:[{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6RolId',fld:'vROLID',pic:'ZZZZZZZZ9'},{av:'AV11Update',fld:'vUPDATE',pic:''},{av:'AV12Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6RolId',fld:'vROLID',pic:'ZZZZZZZZ9'},{av:'AV11Update',fld:'vUPDATE',pic:''},{av:'AV12Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6RolId',fld:'vROLID',pic:'ZZZZZZZZ9'},{av:'AV11Update',fld:'vUPDATE',pic:''},{av:'AV12Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6RolId',fld:'vROLID',pic:'ZZZZZZZZ9'},{av:'AV11Update',fld:'vUPDATE',pic:''},{av:'AV12Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSNOMBRE","{handler:'Valid_Usuariosnombre',iparms:[]");
         setEventMetadata("VALID_USUARIOSNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSAPPAT","{handler:'Valid_Usuariosappat',iparms:[]");
         setEventMetadata("VALID_USUARIOSAPPAT",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSAPMAT","{handler:'Valid_Usuariosapmat',iparms:[]");
         setEventMetadata("VALID_USUARIOSAPMAT",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSSEXO","{handler:'Valid_Usuariossexo',iparms:[]");
         setEventMetadata("VALID_USUARIOSSEXO",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[]");
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
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV11Update = "";
         AV12Delete = "";
         AV16Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A105UsuariosCurp = "";
         A66UsuariosNombre = "";
         A65UsuariosApPat = "";
         A64UsuariosApMat = "";
         A244UsuariosUsr = "";
         A245UsuariosIcono = "";
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
         A275UsuariosSexoFor = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A40000UsuariosIcono_GXI = "";
         scmdbuf = "";
         H002E2_A24RolId = new int[1] ;
         H002E2_A286UsuariosStatus = new short[1] ;
         H002E2_A261UsuariosCorreo = new String[] {""} ;
         H002E2_A260UsuariosTelef = new String[] {""} ;
         H002E2_A93UsuariosIP = new String[] {""} ;
         H002E2_A92UsuariosFecCap = new DateTime[] {DateTime.MinValue} ;
         H002E2_A70UsuariosVigFin = new DateTime[] {DateTime.MinValue} ;
         H002E2_n70UsuariosVigFin = new bool[] {false} ;
         H002E2_A96UsuariosVigIni = new DateTime[] {DateTime.MinValue} ;
         H002E2_A67UsuariosKey = new String[] {""} ;
         H002E2_A68UsuariosPwd = new String[] {""} ;
         H002E2_A256UsuariosEdad = new short[1] ;
         H002E2_A255UsuariosFecNacimiento = new DateTime[] {DateTime.MinValue} ;
         H002E2_A40000UsuariosIcono_GXI = new String[] {""} ;
         H002E2_A272UsuariosTipo = new short[1] ;
         H002E2_A244UsuariosUsr = new String[] {""} ;
         H002E2_A105UsuariosCurp = new String[] {""} ;
         H002E2_A11UsuariosId = new int[1] ;
         H002E2_A64UsuariosApMat = new String[] {""} ;
         H002E2_A65UsuariosApPat = new String[] {""} ;
         H002E2_A66UsuariosNombre = new String[] {""} ;
         H002E2_A257UsuariosSexo = new String[] {""} ;
         H002E2_A245UsuariosIcono = new String[] {""} ;
         H002E3_AGRID_nRecordCount = new long[1] ;
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV9TrnContext = new SdtTransactionContext(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         AV10TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV7Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6RolId = "";
         ROClassString = "";
         GXCCtl = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rolesusuarioswc__default(),
            new Object[][] {
                new Object[] {
               H002E2_A24RolId, H002E2_A286UsuariosStatus, H002E2_A261UsuariosCorreo, H002E2_A260UsuariosTelef, H002E2_A93UsuariosIP, H002E2_A92UsuariosFecCap, H002E2_A70UsuariosVigFin, H002E2_n70UsuariosVigFin, H002E2_A96UsuariosVigIni, H002E2_A67UsuariosKey,
               H002E2_A68UsuariosPwd, H002E2_A256UsuariosEdad, H002E2_A255UsuariosFecNacimiento, H002E2_A40000UsuariosIcono_GXI, H002E2_A272UsuariosTipo, H002E2_A244UsuariosUsr, H002E2_A105UsuariosCurp, H002E2_A11UsuariosId, H002E2_A64UsuariosApMat, H002E2_A65UsuariosApPat,
               H002E2_A66UsuariosNombre, H002E2_A257UsuariosSexo, H002E2_A245UsuariosIcono
               }
               , new Object[] {
               H002E3_AGRID_nRecordCount
               }
            }
         );
         AV16Pgmname = "RolesUsuariosWC";
         /* GeneXus formulas. */
         AV16Pgmname = "RolesUsuariosWC";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short A272UsuariosTipo ;
      private short A256UsuariosEdad ;
      private short A286UsuariosStatus ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backstyle ;
      private int AV6RolId ;
      private int wcpOAV6RolId ;
      private int nRC_GXsfl_20 ;
      private int nGXsfl_20_idx=1 ;
      private int subGrid_Rows ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int A11UsuariosId ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int A24RolId ;
      private int edtRolId_Enabled ;
      private int edtRolId_Visible ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sPrefix ;
      private String sCompPrefix ;
      private String sSFPrefix ;
      private String sGXsfl_20_idx="0001" ;
      private String AV11Update ;
      private String AV12Delete ;
      private String AV16Pgmname ;
      private String edtavUpdate_Internalname ;
      private String edtavDelete_Internalname ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String divMaintable_Internalname ;
      private String divTabletop_Internalname ;
      private String TempTags ;
      private String ClassString ;
      private String StyleString ;
      private String bttBtninsert_Internalname ;
      private String bttBtninsert_Jsonclick ;
      private String divGridcell_Internalname ;
      private String divGridtable_Internalname ;
      private String sStyleString ;
      private String subGrid_Internalname ;
      private String subGrid_Class ;
      private String subGrid_Linesclass ;
      private String subGrid_Header ;
      private String edtUsuariosCurp_Link ;
      private String A257UsuariosSexo ;
      private String A260UsuariosTelef ;
      private String A275UsuariosSexoFor ;
      private String edtavUpdate_Link ;
      private String edtavDelete_Link ;
      private String edtRolId_Internalname ;
      private String edtRolId_Jsonclick ;
      private String sXEvt ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtUsuariosId_Internalname ;
      private String edtUsuariosCurp_Internalname ;
      private String edtUsuariosNombre_Internalname ;
      private String edtUsuariosApPat_Internalname ;
      private String edtUsuariosApMat_Internalname ;
      private String edtUsuariosUsr_Internalname ;
      private String cmbUsuariosTipo_Internalname ;
      private String edtUsuariosIcono_Internalname ;
      private String edtUsuariosFecNacimiento_Internalname ;
      private String edtUsuariosEdad_Internalname ;
      private String edtUsuariosSexo_Internalname ;
      private String edtUsuariosPwd_Internalname ;
      private String edtUsuariosKey_Internalname ;
      private String edtUsuariosVigIni_Internalname ;
      private String edtUsuariosVigFin_Internalname ;
      private String edtUsuariosFecCap_Internalname ;
      private String edtUsuariosIP_Internalname ;
      private String edtUsuariosTelef_Internalname ;
      private String edtUsuariosCorreo_Internalname ;
      private String edtUsuariosNomCompleto_Internalname ;
      private String edtUsuariosSexoFor_Internalname ;
      private String cmbUsuariosStatus_Internalname ;
      private String scmdbuf ;
      private String GXEncryptionTmp ;
      private String sCtrlAV6RolId ;
      private String sGXsfl_20_fel_idx="0001" ;
      private String ROClassString ;
      private String edtUsuariosId_Jsonclick ;
      private String edtUsuariosCurp_Jsonclick ;
      private String edtUsuariosNombre_Jsonclick ;
      private String edtUsuariosApPat_Jsonclick ;
      private String edtUsuariosApMat_Jsonclick ;
      private String edtUsuariosUsr_Jsonclick ;
      private String GXCCtl ;
      private String cmbUsuariosTipo_Jsonclick ;
      private String sImgUrl ;
      private String edtUsuariosFecNacimiento_Jsonclick ;
      private String edtUsuariosEdad_Jsonclick ;
      private String edtUsuariosSexo_Jsonclick ;
      private String edtUsuariosPwd_Jsonclick ;
      private String edtUsuariosKey_Jsonclick ;
      private String edtUsuariosVigIni_Jsonclick ;
      private String edtUsuariosVigFin_Jsonclick ;
      private String edtUsuariosFecCap_Jsonclick ;
      private String edtUsuariosIP_Jsonclick ;
      private String edtUsuariosTelef_Jsonclick ;
      private String edtUsuariosCorreo_Jsonclick ;
      private String edtUsuariosNomCompleto_Jsonclick ;
      private String edtUsuariosSexoFor_Jsonclick ;
      private String cmbUsuariosStatus_Jsonclick ;
      private String edtavUpdate_Jsonclick ;
      private String edtavDelete_Jsonclick ;
      private DateTime A92UsuariosFecCap ;
      private DateTime A255UsuariosFecNacimiento ;
      private DateTime A96UsuariosVigIni ;
      private DateTime A70UsuariosVigFin ;
      private bool entryPointCalled ;
      private bool bGXsfl_20_Refreshing=false ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n70UsuariosVigFin ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool A245UsuariosIcono_IsBlob ;
      private String A105UsuariosCurp ;
      private String A66UsuariosNombre ;
      private String A65UsuariosApPat ;
      private String A64UsuariosApMat ;
      private String A244UsuariosUsr ;
      private String A68UsuariosPwd ;
      private String A67UsuariosKey ;
      private String A93UsuariosIP ;
      private String A261UsuariosCorreo ;
      private String A97UsuariosNomCompleto ;
      private String A40000UsuariosIcono_GXI ;
      private String A245UsuariosIcono ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbUsuariosTipo ;
      private GXCombobox cmbUsuariosStatus ;
      private IDataStoreProvider pr_default ;
      private int[] H002E2_A24RolId ;
      private short[] H002E2_A286UsuariosStatus ;
      private String[] H002E2_A261UsuariosCorreo ;
      private String[] H002E2_A260UsuariosTelef ;
      private String[] H002E2_A93UsuariosIP ;
      private DateTime[] H002E2_A92UsuariosFecCap ;
      private DateTime[] H002E2_A70UsuariosVigFin ;
      private bool[] H002E2_n70UsuariosVigFin ;
      private DateTime[] H002E2_A96UsuariosVigIni ;
      private String[] H002E2_A67UsuariosKey ;
      private String[] H002E2_A68UsuariosPwd ;
      private short[] H002E2_A256UsuariosEdad ;
      private DateTime[] H002E2_A255UsuariosFecNacimiento ;
      private String[] H002E2_A40000UsuariosIcono_GXI ;
      private short[] H002E2_A272UsuariosTipo ;
      private String[] H002E2_A244UsuariosUsr ;
      private String[] H002E2_A105UsuariosCurp ;
      private int[] H002E2_A11UsuariosId ;
      private String[] H002E2_A64UsuariosApMat ;
      private String[] H002E2_A65UsuariosApPat ;
      private String[] H002E2_A66UsuariosNombre ;
      private String[] H002E2_A257UsuariosSexo ;
      private String[] H002E2_A245UsuariosIcono ;
      private long[] H002E3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private IGxSession AV7Session ;
      private SdtTransactionContext AV9TrnContext ;
      private SdtTransactionContext_Attribute AV10TrnContextAtt ;
   }

   public class rolesusuarioswc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002E2 ;
          prmH002E2 = new Object[] {
          new Object[] {"AV6RolId",System.Data.DbType.Int32,9,0} ,
          new Object[] {"GXPagingFrom2",System.Data.DbType.Int32,9,0} ,
          new Object[] {"GXPagingTo2",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmH002E3 ;
          prmH002E3 = new Object[] {
          new Object[] {"AV6RolId",System.Data.DbType.Int32,9,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H002E2", "SELECT `RolId`, `UsuariosStatus`, `UsuariosCorreo`, `UsuariosTelef`, `UsuariosIP`, `UsuariosFecCap`, `UsuariosVigFin`, `UsuariosVigIni`, `UsuariosKey`, `UsuariosPwd`, `UsuariosEdad`, `UsuariosFecNacimiento`, `UsuariosIcono_GXI`, `UsuariosTipo`, `UsuariosUsr`, `UsuariosCurp`, `UsuariosId`, `UsuariosApMat`, `UsuariosApPat`, `UsuariosNombre`, `UsuariosSexo`, `UsuariosIcono` FROM `Usuarios` WHERE `RolId` = ? ORDER BY `RolId`  LIMIT ?, ?",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002E3", "SELECT COUNT(*) FROM `Usuarios` WHERE `RolId` = ? ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E3,1, GxCacheFrequency.OFF ,true,false )
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
                ((String[]) buf[3])[0] = rslt.getString(4, 10) ;
                ((String[]) buf[4])[0] = rslt.getVarchar(5) ;
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6) ;
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8) ;
                ((String[]) buf[9])[0] = rslt.getVarchar(9) ;
                ((String[]) buf[10])[0] = rslt.getVarchar(10) ;
                ((short[]) buf[11])[0] = rslt.getShort(11) ;
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(12) ;
                ((String[]) buf[13])[0] = rslt.getMultimediaUri(13) ;
                ((short[]) buf[14])[0] = rslt.getShort(14) ;
                ((String[]) buf[15])[0] = rslt.getVarchar(15) ;
                ((String[]) buf[16])[0] = rslt.getVarchar(16) ;
                ((int[]) buf[17])[0] = rslt.getInt(17) ;
                ((String[]) buf[18])[0] = rslt.getVarchar(18) ;
                ((String[]) buf[19])[0] = rslt.getVarchar(19) ;
                ((String[]) buf[20])[0] = rslt.getVarchar(20) ;
                ((String[]) buf[21])[0] = rslt.getString(21, 1) ;
                ((String[]) buf[22])[0] = rslt.getMultimediaFile(22, rslt.getVarchar(13)) ;
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
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
                stmt.SetParameter(3, (int)parms[2]);
                return;
             case 1 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

}
