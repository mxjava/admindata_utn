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
   public class usuariosusuariosvacantewc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public usuariosusuariosvacantewc( )
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

      public usuariosusuariosvacantewc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_UsuariosId )
      {
         this.AV6UsuariosId = aP0_UsuariosId;
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
                  AV6UsuariosId = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri(sPrefix, false, "AV6UsuariosId", StringUtil.LTrimStr( (decimal)(AV6UsuariosId), 6, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(String)sCompPrefix,(String)sSFPrefix,(int)AV6UsuariosId});
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
                  AV6UsuariosId = (int)(NumberUtil.Val( GetNextPar( ), "."));
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
                  gxgrGrid_refresh( subGrid_Rows, AV6UsuariosId, AV11Update, AV12Delete, sPrefix) ;
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
            PA292( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV16Pgmname = "UsuariosUsuariosVacanteWC";
               context.Gx_err = 0;
               edtavUpdate_Enabled = 0;
               AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_20_Refreshing);
               edtavDelete_Enabled = 0;
               AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_20_Refreshing);
               WS292( ) ;
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
            context.SendWebValue( "Usuarios Usuarios Vacante WC") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714344218", false, true);
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
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("usuariosusuariosvacantewc.aspx") + "?" + UrlEncode("" +AV6UsuariosId)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6UsuariosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV6UsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6UsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm292( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            context.AddJavascriptSource("usuariosusuariosvacantewc.js", "?202262714344220", false, true);
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
         return "UsuariosUsuariosVacanteWC" ;
      }

      public override String GetPgmdesc( )
      {
         return "Usuarios Usuarios Vacante WC" ;
      }

      protected void WB290( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "usuariosusuariosvacantewc.aspx");
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(20), 2, 0)+","+"null"+");", "Agregar", bttBtninsert_Jsonclick, 5, "Agregar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_UsuariosUsuariosVacanteWC.htm");
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
               context.SendWebValue( "ID") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Descripción") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Estatus") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Inicio") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Sueldo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tipo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Duración") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "----") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Vacantes") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A263Vacantes_Id), 9, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A264Vacantes_Nombre);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtVacantes_Nombre_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A274Vacantes_Descripcion);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A265Vacantes_Status), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A266Vacantes_FechaInicio, "99/99/99"));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A267Vacantes_Sueldo, 6, 3, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A268Vacantes_Tipo), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A269Vacantes_Duracion), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A270Vacantes_Duracion_Nom), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A277Vacantes_Plazas), 4, 0, ".", "")));
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
            GxWebStd.gx_label_element( context, edtUsuariosId_Internalname, "ID", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtUsuariosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")), ((edtUsuariosId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9")) : context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosId_Jsonclick, 0, "Attribute", "", "", "", "", edtUsuariosId_Visible, edtUsuariosId_Enabled, 0, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "NumId", "right", false, "", "HLP_UsuariosUsuariosVacanteWC.htm");
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

      protected void START292( )
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
               Form.Meta.addItem("description", "Usuarios Usuarios Vacante WC", 0) ;
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
               STRUP290( ) ;
            }
         }
      }

      protected void WS292( )
      {
         START292( ) ;
         EVT292( ) ;
      }

      protected void EVT292( )
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
                                 STRUP290( ) ;
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
                                 STRUP290( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E11292 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP290( ) ;
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
                                 STRUP290( ) ;
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
                                 STRUP290( ) ;
                              }
                              nGXsfl_20_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
                              SubsflControlProps_202( ) ;
                              A263Vacantes_Id = (int)(context.localUtil.CToN( cgiGet( edtVacantes_Id_Internalname), ",", "."));
                              A264Vacantes_Nombre = cgiGet( edtVacantes_Nombre_Internalname);
                              A274Vacantes_Descripcion = cgiGet( edtVacantes_Descripcion_Internalname);
                              cmbVacantes_Status.Name = cmbVacantes_Status_Internalname;
                              cmbVacantes_Status.CurrentValue = cgiGet( cmbVacantes_Status_Internalname);
                              A265Vacantes_Status = (short)(NumberUtil.Val( cgiGet( cmbVacantes_Status_Internalname), "."));
                              A266Vacantes_FechaInicio = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtVacantes_FechaInicio_Internalname), 0));
                              A267Vacantes_Sueldo = context.localUtil.CToN( cgiGet( edtVacantes_Sueldo_Internalname), ",", ".");
                              cmbVacantes_Tipo.Name = cmbVacantes_Tipo_Internalname;
                              cmbVacantes_Tipo.CurrentValue = cgiGet( cmbVacantes_Tipo_Internalname);
                              A268Vacantes_Tipo = (short)(NumberUtil.Val( cgiGet( cmbVacantes_Tipo_Internalname), "."));
                              A269Vacantes_Duracion = (short)(context.localUtil.CToN( cgiGet( edtVacantes_Duracion_Internalname), ",", "."));
                              cmbVacantes_Duracion_Nom.Name = cmbVacantes_Duracion_Nom_Internalname;
                              cmbVacantes_Duracion_Nom.CurrentValue = cgiGet( cmbVacantes_Duracion_Nom_Internalname);
                              A270Vacantes_Duracion_Nom = (short)(NumberUtil.Val( cgiGet( cmbVacantes_Duracion_Nom_Internalname), "."));
                              A277Vacantes_Plazas = (short)(context.localUtil.CToN( cgiGet( edtVacantes_Plazas_Internalname), ",", "."));
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
                                          E12292 ();
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
                                          E13292 ();
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
                                       STRUP290( ) ;
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

      protected void WE292( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm292( ) ;
            }
         }
      }

      protected void PA292( )
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
                                       int AV6UsuariosId ,
                                       String AV11Update ,
                                       String AV12Delete ,
                                       String sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF292( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_VACANTES_ID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A263Vacantes_Id), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"VACANTES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A263Vacantes_Id), 9, 0, ".", "")));
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
         RF292( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV16Pgmname = "UsuariosUsuariosVacanteWC";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_20_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_20_Refreshing);
      }

      protected void RF292( )
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
            /* Using cursor H00292 */
            pr_default.execute(0, new Object[] {AV6UsuariosId, GXPagingFrom2, GXPagingTo2});
            nGXsfl_20_idx = 1;
            sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
            SubsflControlProps_202( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A11UsuariosId = H00292_A11UsuariosId[0];
               AssignAttri(sPrefix, false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
               A277Vacantes_Plazas = H00292_A277Vacantes_Plazas[0];
               A270Vacantes_Duracion_Nom = H00292_A270Vacantes_Duracion_Nom[0];
               A269Vacantes_Duracion = H00292_A269Vacantes_Duracion[0];
               A268Vacantes_Tipo = H00292_A268Vacantes_Tipo[0];
               A267Vacantes_Sueldo = H00292_A267Vacantes_Sueldo[0];
               A266Vacantes_FechaInicio = H00292_A266Vacantes_FechaInicio[0];
               A265Vacantes_Status = H00292_A265Vacantes_Status[0];
               A274Vacantes_Descripcion = H00292_A274Vacantes_Descripcion[0];
               A264Vacantes_Nombre = H00292_A264Vacantes_Nombre[0];
               A263Vacantes_Id = H00292_A263Vacantes_Id[0];
               A277Vacantes_Plazas = H00292_A277Vacantes_Plazas[0];
               A270Vacantes_Duracion_Nom = H00292_A270Vacantes_Duracion_Nom[0];
               A269Vacantes_Duracion = H00292_A269Vacantes_Duracion[0];
               A268Vacantes_Tipo = H00292_A268Vacantes_Tipo[0];
               A267Vacantes_Sueldo = H00292_A267Vacantes_Sueldo[0];
               A266Vacantes_FechaInicio = H00292_A266Vacantes_FechaInicio[0];
               A265Vacantes_Status = H00292_A265Vacantes_Status[0];
               A274Vacantes_Descripcion = H00292_A274Vacantes_Descripcion[0];
               A264Vacantes_Nombre = H00292_A264Vacantes_Nombre[0];
               E13292 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 20;
            WB290( ) ;
         }
         bGXsfl_20_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes292( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_VACANTES_ID"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sPrefix+sGXsfl_20_idx, context.localUtil.Format( (decimal)(A263Vacantes_Id), "ZZZZZZZZ9"), context));
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
         /* Using cursor H00293 */
         pr_default.execute(1, new Object[] {AV6UsuariosId});
         GRID_nRecordCount = H00293_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV6UsuariosId, AV11Update, AV12Delete, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV6UsuariosId, AV11Update, AV12Delete, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV6UsuariosId, AV11Update, AV12Delete, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV6UsuariosId, AV11Update, AV12Delete, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV6UsuariosId, AV11Update, AV12Delete, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV16Pgmname = "UsuariosUsuariosVacanteWC";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_20_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_20_Refreshing);
      }

      protected void STRUP290( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12292 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_20 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_20"), ",", "."));
            wcpOAV6UsuariosId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6UsuariosId"), ",", "."));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            A11UsuariosId = (int)(context.localUtil.CToN( cgiGet( edtUsuariosId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A11UsuariosId", StringUtil.LTrimStr( (decimal)(A11UsuariosId), 6, 0));
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
         E12292 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E12292( )
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
         edtUsuariosId_Visible = 0;
         AssignProp(sPrefix, false, edtUsuariosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuariosId_Visible), 5, 0), true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      private void E13292( )
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
         GXEncryptionTmp = "vacantes.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode("" +A263Vacantes_Id);
         edtavUpdate_Link = formatLink("vacantes.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "vacantes.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode("" +A263Vacantes_Id);
         edtavDelete_Link = formatLink("vacantes.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         edtVacantes_Nombre_Link = formatLink("viewvacantes.aspx") + "?" + UrlEncode("" +A263Vacantes_Id) + "," + UrlEncode(StringUtil.RTrim(""));
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

      protected void E11292( )
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
         GXEncryptionTmp = "vacantes.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode("" +0);
         CallWebObject(formatLink("vacantes.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         AV9TrnContext = new SdtTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV16Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Vacantes";
         AV10TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV10TrnContextAtt.gxTpr_Attributename = "UsuariosId";
         AV10TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6UsuariosId), 6, 0);
         AV9TrnContext.gxTpr_Attributes.Add(AV10TrnContextAtt, 0);
         AV7Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "TransactionContext", "ADMINDATA1"));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6UsuariosId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV6UsuariosId", StringUtil.LTrimStr( (decimal)(AV6UsuariosId), 6, 0));
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
         PA292( ) ;
         WS292( ) ;
         WE292( ) ;
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
         sCtrlAV6UsuariosId = (String)((String)getParm(obj,0));
      }

      public override void componentrestorestate( String sPPrefix ,
                                                  String sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA292( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (String)getParm(obj,0);
         sSFPrefix = (String)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "usuariosusuariosvacantewc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA292( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6UsuariosId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV6UsuariosId", StringUtil.LTrimStr( (decimal)(AV6UsuariosId), 6, 0));
         }
         wcpOAV6UsuariosId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6UsuariosId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( AV6UsuariosId != wcpOAV6UsuariosId ) ) )
         {
            setjustcreated();
         }
         wcpOAV6UsuariosId = AV6UsuariosId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6UsuariosId = cgiGet( sPrefix+"AV6UsuariosId_CTRL");
         if ( StringUtil.Len( sCtrlAV6UsuariosId) > 0 )
         {
            AV6UsuariosId = (int)(context.localUtil.CToN( cgiGet( sCtrlAV6UsuariosId), ",", "."));
            AssignAttri(sPrefix, false, "AV6UsuariosId", StringUtil.LTrimStr( (decimal)(AV6UsuariosId), 6, 0));
         }
         else
         {
            AV6UsuariosId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV6UsuariosId_PARM"), ",", "."));
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
         PA292( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS292( ) ;
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
         WS292( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6UsuariosId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6UsuariosId), 6, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6UsuariosId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6UsuariosId_CTRL", StringUtil.RTrim( sCtrlAV6UsuariosId));
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
         WE292( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714344252", true, true);
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
            context.AddJavascriptSource("usuariosusuariosvacantewc.js", "?202262714344252", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_202( )
      {
         edtVacantes_Id_Internalname = sPrefix+"VACANTES_ID_"+sGXsfl_20_idx;
         edtVacantes_Nombre_Internalname = sPrefix+"VACANTES_NOMBRE_"+sGXsfl_20_idx;
         edtVacantes_Descripcion_Internalname = sPrefix+"VACANTES_DESCRIPCION_"+sGXsfl_20_idx;
         cmbVacantes_Status_Internalname = sPrefix+"VACANTES_STATUS_"+sGXsfl_20_idx;
         edtVacantes_FechaInicio_Internalname = sPrefix+"VACANTES_FECHAINICIO_"+sGXsfl_20_idx;
         edtVacantes_Sueldo_Internalname = sPrefix+"VACANTES_SUELDO_"+sGXsfl_20_idx;
         cmbVacantes_Tipo_Internalname = sPrefix+"VACANTES_TIPO_"+sGXsfl_20_idx;
         edtVacantes_Duracion_Internalname = sPrefix+"VACANTES_DURACION_"+sGXsfl_20_idx;
         cmbVacantes_Duracion_Nom_Internalname = sPrefix+"VACANTES_DURACION_NOM_"+sGXsfl_20_idx;
         edtVacantes_Plazas_Internalname = sPrefix+"VACANTES_PLAZAS_"+sGXsfl_20_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_20_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_20_idx;
      }

      protected void SubsflControlProps_fel_202( )
      {
         edtVacantes_Id_Internalname = sPrefix+"VACANTES_ID_"+sGXsfl_20_fel_idx;
         edtVacantes_Nombre_Internalname = sPrefix+"VACANTES_NOMBRE_"+sGXsfl_20_fel_idx;
         edtVacantes_Descripcion_Internalname = sPrefix+"VACANTES_DESCRIPCION_"+sGXsfl_20_fel_idx;
         cmbVacantes_Status_Internalname = sPrefix+"VACANTES_STATUS_"+sGXsfl_20_fel_idx;
         edtVacantes_FechaInicio_Internalname = sPrefix+"VACANTES_FECHAINICIO_"+sGXsfl_20_fel_idx;
         edtVacantes_Sueldo_Internalname = sPrefix+"VACANTES_SUELDO_"+sGXsfl_20_fel_idx;
         cmbVacantes_Tipo_Internalname = sPrefix+"VACANTES_TIPO_"+sGXsfl_20_fel_idx;
         edtVacantes_Duracion_Internalname = sPrefix+"VACANTES_DURACION_"+sGXsfl_20_fel_idx;
         cmbVacantes_Duracion_Nom_Internalname = sPrefix+"VACANTES_DURACION_NOM_"+sGXsfl_20_fel_idx;
         edtVacantes_Plazas_Internalname = sPrefix+"VACANTES_PLAZAS_"+sGXsfl_20_fel_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_20_fel_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_20_fel_idx;
      }

      protected void sendrow_202( )
      {
         SubsflControlProps_202( ) ;
         WB290( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtVacantes_Id_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A263Vacantes_Id), 9, 0, ",", "")),context.localUtil.Format( (decimal)(A263Vacantes_Id), "ZZZZZZZZ9"),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtVacantes_Id_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)9,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)0,(bool)true,(String)"Id",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtVacantes_Nombre_Internalname,(String)A264Vacantes_Nombre,(String)"",(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)edtVacantes_Nombre_Link,(String)"",(String)"",(String)"",(String)edtVacantes_Nombre_Jsonclick,(short)0,(String)"DescriptionAttribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)40,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtVacantes_Descripcion_Internalname,(String)A274Vacantes_Descripcion,(String)"",(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtVacantes_Descripcion_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)1000,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            GXCCtl = "VACANTES_STATUS_" + sGXsfl_20_idx;
            cmbVacantes_Status.Name = GXCCtl;
            cmbVacantes_Status.WebTags = "";
            cmbVacantes_Status.addItem("1", "Activo", 0);
            cmbVacantes_Status.addItem("2", "Inactivo", 0);
            cmbVacantes_Status.addItem("3", "Espera", 0);
            if ( cmbVacantes_Status.ItemCount > 0 )
            {
               A265Vacantes_Status = (short)(NumberUtil.Val( cmbVacantes_Status.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A265Vacantes_Status), 4, 0))), "."));
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbVacantes_Status,(String)cmbVacantes_Status_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A265Vacantes_Status), 4, 0)),(short)1,(String)cmbVacantes_Status_Jsonclick,(short)0,(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,(short)0,(short)1,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute",(String)"WWColumn WWOptionalColumn",(String)"",(String)"",(String)"",(bool)true});
            cmbVacantes_Status.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A265Vacantes_Status), 4, 0));
            AssignProp(sPrefix, false, cmbVacantes_Status_Internalname, "Values", (String)(cmbVacantes_Status.ToJavascriptSource()), !bGXsfl_20_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtVacantes_FechaInicio_Internalname,context.localUtil.Format(A266Vacantes_FechaInicio, "99/99/99"),context.localUtil.Format( A266Vacantes_FechaInicio, "99/99/99"),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtVacantes_FechaInicio_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)8,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtVacantes_Sueldo_Internalname,StringUtil.LTrim( StringUtil.NToC( A267Vacantes_Sueldo, 6, 3, ",", "")),context.localUtil.Format( A267Vacantes_Sueldo, "Z9.999"),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtVacantes_Sueldo_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)6,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            GXCCtl = "VACANTES_TIPO_" + sGXsfl_20_idx;
            cmbVacantes_Tipo.Name = GXCCtl;
            cmbVacantes_Tipo.WebTags = "";
            cmbVacantes_Tipo.addItem("1", "Home Office", 0);
            cmbVacantes_Tipo.addItem("2", "Presencial", 0);
            cmbVacantes_Tipo.addItem("3", "Mixto", 0);
            if ( cmbVacantes_Tipo.ItemCount > 0 )
            {
               A268Vacantes_Tipo = (short)(NumberUtil.Val( cmbVacantes_Tipo.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A268Vacantes_Tipo), 4, 0))), "."));
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbVacantes_Tipo,(String)cmbVacantes_Tipo_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A268Vacantes_Tipo), 4, 0)),(short)1,(String)cmbVacantes_Tipo_Jsonclick,(short)0,(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,(short)0,(short)1,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute",(String)"WWColumn WWOptionalColumn",(String)"",(String)"",(String)"",(bool)true});
            cmbVacantes_Tipo.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A268Vacantes_Tipo), 4, 0));
            AssignProp(sPrefix, false, cmbVacantes_Tipo_Internalname, "Values", (String)(cmbVacantes_Tipo.ToJavascriptSource()), !bGXsfl_20_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtVacantes_Duracion_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A269Vacantes_Duracion), 4, 0, ",", "")),context.localUtil.Format( (decimal)(A269Vacantes_Duracion), "ZZZ9"),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtVacantes_Duracion_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)4,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            GXCCtl = "VACANTES_DURACION_NOM_" + sGXsfl_20_idx;
            cmbVacantes_Duracion_Nom.Name = GXCCtl;
            cmbVacantes_Duracion_Nom.WebTags = "";
            cmbVacantes_Duracion_Nom.addItem("1", "Dias", 0);
            cmbVacantes_Duracion_Nom.addItem("2", "Meses", 0);
            cmbVacantes_Duracion_Nom.addItem("3", "Años", 0);
            if ( cmbVacantes_Duracion_Nom.ItemCount > 0 )
            {
               A270Vacantes_Duracion_Nom = (short)(NumberUtil.Val( cmbVacantes_Duracion_Nom.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A270Vacantes_Duracion_Nom), 4, 0))), "."));
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbVacantes_Duracion_Nom,(String)cmbVacantes_Duracion_Nom_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A270Vacantes_Duracion_Nom), 4, 0)),(short)1,(String)cmbVacantes_Duracion_Nom_Jsonclick,(short)0,(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,(short)0,(short)1,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute",(String)"WWColumn WWOptionalColumn",(String)"",(String)"",(String)"",(bool)true});
            cmbVacantes_Duracion_Nom.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A270Vacantes_Duracion_Nom), 4, 0));
            AssignProp(sPrefix, false, cmbVacantes_Duracion_Nom_Internalname, "Values", (String)(cmbVacantes_Duracion_Nom.ToJavascriptSource()), !bGXsfl_20_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtVacantes_Plazas_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A277Vacantes_Plazas), 4, 0, ",", "")),context.localUtil.Format( (decimal)(A277Vacantes_Plazas), "ZZZ9"),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtVacantes_Plazas_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)4,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
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
            send_integrity_lvl_hashes292( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_20_idx = ((subGrid_Islastpage==1)&&(nGXsfl_20_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_20_idx+1);
            sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
            SubsflControlProps_202( ) ;
         }
         /* End function sendrow_202 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "VACANTES_STATUS_" + sGXsfl_20_idx;
         cmbVacantes_Status.Name = GXCCtl;
         cmbVacantes_Status.WebTags = "";
         cmbVacantes_Status.addItem("1", "Activo", 0);
         cmbVacantes_Status.addItem("2", "Inactivo", 0);
         cmbVacantes_Status.addItem("3", "Espera", 0);
         if ( cmbVacantes_Status.ItemCount > 0 )
         {
         }
         GXCCtl = "VACANTES_TIPO_" + sGXsfl_20_idx;
         cmbVacantes_Tipo.Name = GXCCtl;
         cmbVacantes_Tipo.WebTags = "";
         cmbVacantes_Tipo.addItem("1", "Home Office", 0);
         cmbVacantes_Tipo.addItem("2", "Presencial", 0);
         cmbVacantes_Tipo.addItem("3", "Mixto", 0);
         if ( cmbVacantes_Tipo.ItemCount > 0 )
         {
         }
         GXCCtl = "VACANTES_DURACION_NOM_" + sGXsfl_20_idx;
         cmbVacantes_Duracion_Nom.Name = GXCCtl;
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
         bttBtninsert_Internalname = sPrefix+"BTNINSERT";
         divTabletop_Internalname = sPrefix+"TABLETOP";
         edtVacantes_Id_Internalname = sPrefix+"VACANTES_ID";
         edtVacantes_Nombre_Internalname = sPrefix+"VACANTES_NOMBRE";
         edtVacantes_Descripcion_Internalname = sPrefix+"VACANTES_DESCRIPCION";
         cmbVacantes_Status_Internalname = sPrefix+"VACANTES_STATUS";
         edtVacantes_FechaInicio_Internalname = sPrefix+"VACANTES_FECHAINICIO";
         edtVacantes_Sueldo_Internalname = sPrefix+"VACANTES_SUELDO";
         cmbVacantes_Tipo_Internalname = sPrefix+"VACANTES_TIPO";
         edtVacantes_Duracion_Internalname = sPrefix+"VACANTES_DURACION";
         cmbVacantes_Duracion_Nom_Internalname = sPrefix+"VACANTES_DURACION_NOM";
         edtVacantes_Plazas_Internalname = sPrefix+"VACANTES_PLAZAS";
         edtavUpdate_Internalname = sPrefix+"vUPDATE";
         edtavDelete_Internalname = sPrefix+"vDELETE";
         divGridtable_Internalname = sPrefix+"GRIDTABLE";
         divGridcell_Internalname = sPrefix+"GRIDCELL";
         edtUsuariosId_Internalname = sPrefix+"USUARIOSID";
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
         edtVacantes_Plazas_Jsonclick = "";
         cmbVacantes_Duracion_Nom_Jsonclick = "";
         edtVacantes_Duracion_Jsonclick = "";
         cmbVacantes_Tipo_Jsonclick = "";
         edtVacantes_Sueldo_Jsonclick = "";
         edtVacantes_FechaInicio_Jsonclick = "";
         cmbVacantes_Status_Jsonclick = "";
         edtVacantes_Descripcion_Jsonclick = "";
         edtVacantes_Nombre_Jsonclick = "";
         edtVacantes_Id_Jsonclick = "";
         edtUsuariosId_Jsonclick = "";
         edtUsuariosId_Enabled = 0;
         edtUsuariosId_Visible = 1;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtavDelete_Link = "";
         edtavUpdate_Link = "";
         edtVacantes_Nombre_Link = "";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV11Update',fld:'vUPDATE',pic:''},{av:'AV12Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID.LOAD","{handler:'E13292',iparms:[{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtVacantes_Nombre_Link',ctrl:'VACANTES_NOMBRE',prop:'Link'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E11292',iparms:[{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV11Update',fld:'vUPDATE',pic:''},{av:'AV12Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV11Update',fld:'vUPDATE',pic:''},{av:'AV12Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV11Update',fld:'vUPDATE',pic:''},{av:'AV12Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV11Update',fld:'vUPDATE',pic:''},{av:'AV12Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALID_VACANTES_ID","{handler:'Valid_Vacantes_id',iparms:[]");
         setEventMetadata("VALID_VACANTES_ID",",oparms:[]}");
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
         A264Vacantes_Nombre = "";
         A274Vacantes_Descripcion = "";
         A266Vacantes_FechaInicio = DateTime.MinValue;
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H00292_A11UsuariosId = new int[1] ;
         H00292_A277Vacantes_Plazas = new short[1] ;
         H00292_A270Vacantes_Duracion_Nom = new short[1] ;
         H00292_A269Vacantes_Duracion = new short[1] ;
         H00292_A268Vacantes_Tipo = new short[1] ;
         H00292_A267Vacantes_Sueldo = new decimal[1] ;
         H00292_A266Vacantes_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         H00292_A265Vacantes_Status = new short[1] ;
         H00292_A274Vacantes_Descripcion = new String[] {""} ;
         H00292_A264Vacantes_Nombre = new String[] {""} ;
         H00292_A263Vacantes_Id = new int[1] ;
         H00293_AGRID_nRecordCount = new long[1] ;
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV9TrnContext = new SdtTransactionContext(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         AV10TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV7Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6UsuariosId = "";
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usuariosusuariosvacantewc__default(),
            new Object[][] {
                new Object[] {
               H00292_A11UsuariosId, H00292_A277Vacantes_Plazas, H00292_A270Vacantes_Duracion_Nom, H00292_A269Vacantes_Duracion, H00292_A268Vacantes_Tipo, H00292_A267Vacantes_Sueldo, H00292_A266Vacantes_FechaInicio, H00292_A265Vacantes_Status, H00292_A274Vacantes_Descripcion, H00292_A264Vacantes_Nombre,
               H00292_A263Vacantes_Id
               }
               , new Object[] {
               H00293_AGRID_nRecordCount
               }
            }
         );
         AV16Pgmname = "UsuariosUsuariosVacanteWC";
         /* GeneXus formulas. */
         AV16Pgmname = "UsuariosUsuariosVacanteWC";
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
      private short A265Vacantes_Status ;
      private short A268Vacantes_Tipo ;
      private short A269Vacantes_Duracion ;
      private short A270Vacantes_Duracion_Nom ;
      private short A277Vacantes_Plazas ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backstyle ;
      private int AV6UsuariosId ;
      private int wcpOAV6UsuariosId ;
      private int nRC_GXsfl_20 ;
      private int nGXsfl_20_idx=1 ;
      private int subGrid_Rows ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int A263Vacantes_Id ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int A11UsuariosId ;
      private int edtUsuariosId_Enabled ;
      private int edtUsuariosId_Visible ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal A267Vacantes_Sueldo ;
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
      private String edtVacantes_Nombre_Link ;
      private String edtavUpdate_Link ;
      private String edtavDelete_Link ;
      private String edtUsuariosId_Internalname ;
      private String edtUsuariosId_Jsonclick ;
      private String sXEvt ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtVacantes_Id_Internalname ;
      private String edtVacantes_Nombre_Internalname ;
      private String edtVacantes_Descripcion_Internalname ;
      private String cmbVacantes_Status_Internalname ;
      private String edtVacantes_FechaInicio_Internalname ;
      private String edtVacantes_Sueldo_Internalname ;
      private String cmbVacantes_Tipo_Internalname ;
      private String edtVacantes_Duracion_Internalname ;
      private String cmbVacantes_Duracion_Nom_Internalname ;
      private String edtVacantes_Plazas_Internalname ;
      private String scmdbuf ;
      private String GXEncryptionTmp ;
      private String sCtrlAV6UsuariosId ;
      private String sGXsfl_20_fel_idx="0001" ;
      private String ROClassString ;
      private String edtVacantes_Id_Jsonclick ;
      private String edtVacantes_Nombre_Jsonclick ;
      private String edtVacantes_Descripcion_Jsonclick ;
      private String GXCCtl ;
      private String cmbVacantes_Status_Jsonclick ;
      private String edtVacantes_FechaInicio_Jsonclick ;
      private String edtVacantes_Sueldo_Jsonclick ;
      private String cmbVacantes_Tipo_Jsonclick ;
      private String edtVacantes_Duracion_Jsonclick ;
      private String cmbVacantes_Duracion_Nom_Jsonclick ;
      private String edtVacantes_Plazas_Jsonclick ;
      private String edtavUpdate_Jsonclick ;
      private String edtavDelete_Jsonclick ;
      private DateTime A266Vacantes_FechaInicio ;
      private bool entryPointCalled ;
      private bool bGXsfl_20_Refreshing=false ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private String A264Vacantes_Nombre ;
      private String A274Vacantes_Descripcion ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbVacantes_Status ;
      private GXCombobox cmbVacantes_Tipo ;
      private GXCombobox cmbVacantes_Duracion_Nom ;
      private IDataStoreProvider pr_default ;
      private int[] H00292_A11UsuariosId ;
      private short[] H00292_A277Vacantes_Plazas ;
      private short[] H00292_A270Vacantes_Duracion_Nom ;
      private short[] H00292_A269Vacantes_Duracion ;
      private short[] H00292_A268Vacantes_Tipo ;
      private decimal[] H00292_A267Vacantes_Sueldo ;
      private DateTime[] H00292_A266Vacantes_FechaInicio ;
      private short[] H00292_A265Vacantes_Status ;
      private String[] H00292_A274Vacantes_Descripcion ;
      private String[] H00292_A264Vacantes_Nombre ;
      private int[] H00292_A263Vacantes_Id ;
      private long[] H00293_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private IGxSession AV7Session ;
      private SdtTransactionContext AV9TrnContext ;
      private SdtTransactionContext_Attribute AV10TrnContextAtt ;
   }

   public class usuariosusuariosvacantewc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00292 ;
          prmH00292 = new Object[] {
          new Object[] {"AV6UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"GXPagingFrom2",System.Data.DbType.Int32,9,0} ,
          new Object[] {"GXPagingTo2",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmH00293 ;
          prmH00293 = new Object[] {
          new Object[] {"AV6UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H00292", "SELECT T1.`UsuariosId`, T2.`Vacantes_Plazas`, T2.`Vacantes_Duracion_Nom`, T2.`Vacantes_Duracion`, T2.`Vacantes_Tipo`, T2.`Vacantes_Sueldo`, T2.`Vacantes_FechaInicio`, T2.`Vacantes_Status`, T2.`Vacantes_Descripcion`, T2.`Vacantes_Nombre`, T1.`Vacantes_Id` FROM (`VacantesUsuariosVacante` T1 INNER JOIN `Vacantes` T2 ON T2.`Vacantes_Id` = T1.`Vacantes_Id`) WHERE T1.`UsuariosId` = ? ORDER BY T1.`UsuariosId`  LIMIT ?, ?",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00292,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00293", "SELECT COUNT(*) FROM (`VacantesUsuariosVacante` T1 INNER JOIN `Vacantes` T2 ON T2.`Vacantes_Id` = T1.`Vacantes_Id`) WHERE T1.`UsuariosId` = ? ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00293,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                ((short[]) buf[3])[0] = rslt.getShort(4) ;
                ((short[]) buf[4])[0] = rslt.getShort(5) ;
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6) ;
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7) ;
                ((short[]) buf[7])[0] = rslt.getShort(8) ;
                ((String[]) buf[8])[0] = rslt.getVarchar(9) ;
                ((String[]) buf[9])[0] = rslt.getVarchar(10) ;
                ((int[]) buf[10])[0] = rslt.getInt(11) ;
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
