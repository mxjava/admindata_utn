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
   public class wpreclutamientocord : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpreclutamientocord( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public wpreclutamientocord( IGxContext context )
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
         dynavVacantes_nombre = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               nRC_GXsfl_15 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_15_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_15_idx = GetNextPar( );
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid1_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               A263Vacantes_Id = (int)(NumberUtil.Val( GetNextPar( ), "."));
               A290VacantesUsuariosEstatus = (short)(NumberUtil.Val( GetNextPar( ), "."));
               n290VacantesUsuariosEstatus = false;
               A277Vacantes_Plazas = (short)(NumberUtil.Val( GetNextPar( ), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( A263Vacantes_Id, A290VacantesUsuariosEstatus, A277Vacantes_Plazas) ;
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
         PA372( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START372( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714345667", false, true);
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
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpreclutamientocord.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
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
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_15", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_15), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A263Vacantes_Id), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSESTATUS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A290VacantesUsuariosEstatus), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTES_PLAZAS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A277Vacantes_Plazas), 4, 0, ",", "")));
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
            WE372( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT372( ) ;
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
         return formatLink("wpreclutamientocord.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "wpReclutamientoCord" ;
      }

      public override String GetPgmdesc( )
      {
         return "wp Coordinador" ;
      }

      protected void WB370( )
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable6_Internalname, 1, 0, "px", 0, "px", "TableTopSearch", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-xs-offset-5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Seguimiento por Vacante", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SubTitle", 0, "", 1, 1, 0, "HLP_wpReclutamientoCord.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 50, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Text Block", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockTitle", 0, "", lblTextblock5_Visible, 1, 0, "HLP_wpReclutamientoCord.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetIsFreestyle(true);
            Grid1Container.SetWrapped(nGXWrapped);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"15\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               Grid1Container.AddObjectProperty("GridName", "Grid1");
            }
            else
            {
               Grid1Container.AddObjectProperty("GridName", "Grid1");
               Grid1Container.AddObjectProperty("Header", subGrid1_Header);
               Grid1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
               Grid1Container.AddObjectProperty("Class", "FreeStyleGrid");
               Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("CmpContext", "");
               Grid1Container.AddObjectProperty("InMasterPage", "false");
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Vacantes_Nombre), 4, 0, ".", "")));
               Grid1Column.AddObjectProperty("Fontbold", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynavVacantes_nombre.FontBold), 1, 0, ".", "")));
               Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynavVacantes_nombre.Enabled), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Vacantes_Id), 9, 0, ".", "")));
               Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantes_id_Visible), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6Proceso_Completo), 4, 0, ".", "")));
               Grid1Column.AddObjectProperty("Fontitalic", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavProceso_completo_Fontitalic), 1, 0, ".", "")));
               Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavProceso_completo_Enabled), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Enviado_Cliente), 4, 0, ".", "")));
               Grid1Column.AddObjectProperty("Fontitalic", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEnviado_cliente_Fontitalic), 1, 0, ".", "")));
               Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEnviado_cliente_Enabled), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8Descartados), 4, 0, ".", "")));
               Grid1Column.AddObjectProperty("Fontitalic", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDescartados_Fontitalic), 1, 0, ".", "")));
               Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDescartados_Enabled), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", lblTextblock3_Caption);
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", lblTextblock5_Caption);
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( context.GetImagePath( "e12a2252-2cc2-4d15-9bb1-3da86e4285e6", "", context.GetTheme( ))));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", lblTextblock2_Caption);
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 15 )
         {
            wbEnd = 0;
            nRC_GXsfl_15 = (int)(nGXsfl_15_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 15 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START372( )
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
            Form.Meta.addItem("description", "wp Coordinador", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP370( ) ;
      }

      protected void WS372( )
      {
         START372( ) ;
         EVT372( ) ;
      }

      protected void EVT372( )
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
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "'REVISAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "'REVISAR'") == 0 ) )
                           {
                              nGXsfl_15_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
                              SubsflControlProps_152( ) ;
                              dynavVacantes_nombre.Name = dynavVacantes_nombre_Internalname;
                              dynavVacantes_nombre.CurrentValue = cgiGet( dynavVacantes_nombre_Internalname);
                              AV5Vacantes_Nombre = (short)(NumberUtil.Val( cgiGet( dynavVacantes_nombre_Internalname), "."));
                              AssignAttri("", false, dynavVacantes_nombre_Internalname, StringUtil.LTrimStr( (decimal)(AV5Vacantes_Nombre), 4, 0));
                              GxWebStd.gx_hidden_field( context, "gxhash_vVACANTES_NOMBRE"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sGXsfl_15_idx, context.localUtil.Format( (decimal)(AV5Vacantes_Nombre), "ZZZ9"), context));
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavVacantes_id_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavVacantes_id_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVACANTES_ID");
                                 GX_FocusControl = edtavVacantes_id_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV11Vacantes_Id = 0;
                                 AssignAttri("", false, edtavVacantes_id_Internalname, StringUtil.LTrimStr( (decimal)(AV11Vacantes_Id), 9, 0));
                              }
                              else
                              {
                                 AV11Vacantes_Id = (int)(context.localUtil.CToN( cgiGet( edtavVacantes_id_Internalname), ",", "."));
                                 AssignAttri("", false, edtavVacantes_id_Internalname, StringUtil.LTrimStr( (decimal)(AV11Vacantes_Id), 9, 0));
                              }
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavProceso_completo_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavProceso_completo_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROCESO_COMPLETO");
                                 GX_FocusControl = edtavProceso_completo_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV6Proceso_Completo = 0;
                                 AssignAttri("", false, edtavProceso_completo_Internalname, StringUtil.LTrimStr( (decimal)(AV6Proceso_Completo), 4, 0));
                              }
                              else
                              {
                                 AV6Proceso_Completo = (short)(context.localUtil.CToN( cgiGet( edtavProceso_completo_Internalname), ",", "."));
                                 AssignAttri("", false, edtavProceso_completo_Internalname, StringUtil.LTrimStr( (decimal)(AV6Proceso_Completo), 4, 0));
                              }
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavEnviado_cliente_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEnviado_cliente_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vENVIADO_CLIENTE");
                                 GX_FocusControl = edtavEnviado_cliente_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV7Enviado_Cliente = 0;
                                 AssignAttri("", false, edtavEnviado_cliente_Internalname, StringUtil.LTrimStr( (decimal)(AV7Enviado_Cliente), 4, 0));
                              }
                              else
                              {
                                 AV7Enviado_Cliente = (short)(context.localUtil.CToN( cgiGet( edtavEnviado_cliente_Internalname), ",", "."));
                                 AssignAttri("", false, edtavEnviado_cliente_Internalname, StringUtil.LTrimStr( (decimal)(AV7Enviado_Cliente), 4, 0));
                              }
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavDescartados_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavDescartados_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vDESCARTADOS");
                                 GX_FocusControl = edtavDescartados_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV8Descartados = 0;
                                 AssignAttri("", false, edtavDescartados_Internalname, StringUtil.LTrimStr( (decimal)(AV8Descartados), 4, 0));
                              }
                              else
                              {
                                 AV8Descartados = (short)(context.localUtil.CToN( cgiGet( edtavDescartados_Internalname), ",", "."));
                                 AssignAttri("", false, edtavDescartados_Internalname, StringUtil.LTrimStr( (decimal)(AV8Descartados), 4, 0));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E11372 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'REVISAR'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Revisar' */
                                    E12372 ();
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

      protected void WE372( )
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

      protected void PA372( )
      {
         if ( nDonePA == 0 )
         {
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

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_152( ) ;
         while ( nGXsfl_15_idx <= nRC_GXsfl_15 )
         {
            sendrow_152( ) ;
            nGXsfl_15_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_15_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int A263Vacantes_Id ,
                                        short A290VacantesUsuariosEstatus ,
                                        short A277Vacantes_Plazas )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF372( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vVACANTES_NOMBRE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5Vacantes_Nombre), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vVACANTES_NOMBRE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Vacantes_Nombre), 4, 0, ".", "")));
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
         RF372( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         dynavVacantes_nombre.Enabled = 0;
         AssignProp("", false, dynavVacantes_nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavVacantes_nombre.Enabled), 5, 0), !bGXsfl_15_Refreshing);
         edtavProceso_completo_Enabled = 0;
         AssignProp("", false, edtavProceso_completo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProceso_completo_Enabled), 5, 0), !bGXsfl_15_Refreshing);
         edtavEnviado_cliente_Enabled = 0;
         AssignProp("", false, edtavEnviado_cliente_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnviado_cliente_Enabled), 5, 0), !bGXsfl_15_Refreshing);
         edtavDescartados_Enabled = 0;
         AssignProp("", false, edtavDescartados_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDescartados_Enabled), 5, 0), !bGXsfl_15_Refreshing);
      }

      protected void RF372( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 15;
         nGXsfl_15_idx = 1;
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         bGXsfl_15_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         Grid1Container.AddObjectProperty("Class", "FreeStyleGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         if ( subGrid1_Islastpage != 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordcount( )-subGrid1_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
            Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_152( ) ;
            E11372 ();
            wbEnd = 15;
            WB370( ) ;
         }
         bGXsfl_15_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes372( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vVACANTES_NOMBRE"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sGXsfl_15_idx, context.localUtil.Format( (decimal)(AV5Vacantes_Nombre), "ZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         dynavVacantes_nombre.Enabled = 0;
         AssignProp("", false, dynavVacantes_nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavVacantes_nombre.Enabled), 5, 0), !bGXsfl_15_Refreshing);
         edtavProceso_completo_Enabled = 0;
         AssignProp("", false, edtavProceso_completo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProceso_completo_Enabled), 5, 0), !bGXsfl_15_Refreshing);
         edtavEnviado_cliente_Enabled = 0;
         AssignProp("", false, edtavEnviado_cliente_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnviado_cliente_Enabled), 5, 0), !bGXsfl_15_Refreshing);
         edtavDescartados_Enabled = 0;
         AssignProp("", false, edtavDescartados_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDescartados_Enabled), 5, 0), !bGXsfl_15_Refreshing);
      }

      protected void STRUP370( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_15 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_15"), ",", "."));
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      private void E11372( )
      {
         /* Grid1_Load Routine */
         lblTextblock1_Fontbold = 1;
         lblTextblock1_Forecolor = GXUtil.RGB( 255, 0, 0);
         lblTextblock1_Fontsize = 30;
         lblTextblock5_Visible = 0;
         AssignProp("", false, lblTextblock5_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTextblock5_Visible), 5, 0), true);
         edtavProceso_completo_Fontitalic = 1;
         edtavEnviado_cliente_Fontitalic = 1;
         edtavDescartados_Fontitalic = 1;
         edtavVacantes_id_Visible = 0;
         /* Using cursor H00372 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK373 = false;
            A263Vacantes_Id = H00372_A263Vacantes_Id[0];
            A290VacantesUsuariosEstatus = H00372_A290VacantesUsuariosEstatus[0];
            n290VacantesUsuariosEstatus = H00372_n290VacantesUsuariosEstatus[0];
            A277Vacantes_Plazas = H00372_A277Vacantes_Plazas[0];
            A277Vacantes_Plazas = H00372_A277Vacantes_Plazas[0];
            AV11Vacantes_Id = A263Vacantes_Id;
            AssignAttri("", false, edtavVacantes_id_Internalname, StringUtil.LTrimStr( (decimal)(AV11Vacantes_Id), 9, 0));
            AV13ConteoProcComp = 0;
            AV14ConteoEnvClie = 0;
            AV15ContDescar = 0;
            AV6Proceso_Completo = 0;
            AssignAttri("", false, edtavProceso_completo_Internalname, StringUtil.LTrimStr( (decimal)(AV6Proceso_Completo), 4, 0));
            AV8Descartados = 0;
            AssignAttri("", false, edtavDescartados_Internalname, StringUtil.LTrimStr( (decimal)(AV8Descartados), 4, 0));
            AV7Enviado_Cliente = 0;
            AssignAttri("", false, edtavEnviado_cliente_Internalname, StringUtil.LTrimStr( (decimal)(AV7Enviado_Cliente), 4, 0));
            while ( (pr_default.getStatus(0) != 101) && ( H00372_A263Vacantes_Id[0] == A263Vacantes_Id ) )
            {
               BRK373 = false;
               A290VacantesUsuariosEstatus = H00372_A290VacantesUsuariosEstatus[0];
               n290VacantesUsuariosEstatus = H00372_n290VacantesUsuariosEstatus[0];
               if ( A263Vacantes_Id == AV11Vacantes_Id )
               {
                  if ( A290VacantesUsuariosEstatus == 3 )
                  {
                     AV13ConteoProcComp = (short)(AV13ConteoProcComp+1);
                     AV6Proceso_Completo = AV13ConteoProcComp;
                     AssignAttri("", false, edtavProceso_completo_Internalname, StringUtil.LTrimStr( (decimal)(AV6Proceso_Completo), 4, 0));
                  }
                  else if ( A290VacantesUsuariosEstatus == 5 )
                  {
                     AV15ContDescar = (short)(AV15ContDescar+1);
                     AV8Descartados = AV15ContDescar;
                     AssignAttri("", false, edtavDescartados_Internalname, StringUtil.LTrimStr( (decimal)(AV8Descartados), 4, 0));
                  }
                  else if ( A290VacantesUsuariosEstatus == 4 )
                  {
                     AV14ConteoEnvClie = (short)(AV14ConteoEnvClie+1);
                     AV7Enviado_Cliente = AV14ConteoEnvClie;
                     AssignAttri("", false, edtavEnviado_cliente_Internalname, StringUtil.LTrimStr( (decimal)(AV7Enviado_Cliente), 4, 0));
                  }
                  else
                  {
                  }
               }
               BRK373 = true;
               pr_default.readNext(0);
            }
            AV10NumPlazas = StringUtil.Str( (decimal)(A277Vacantes_Plazas), 4, 0);
            AV5Vacantes_Nombre = (short)(A263Vacantes_Id);
            AssignAttri("", false, dynavVacantes_nombre_Internalname, StringUtil.LTrimStr( (decimal)(AV5Vacantes_Nombre), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vVACANTES_NOMBRE"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sGXsfl_15_idx, context.localUtil.Format( (decimal)(AV5Vacantes_Nombre), "ZZZ9"), context));
            dynavVacantes_nombre.FontBold = 1;
            lblTextblock1_Caption = AV10NumPlazas;
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 15;
            }
            sendrow_152( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
            {
               context.DoAjaxLoad(15, Grid1Row);
            }
            if ( ! BRK373 )
            {
               BRK373 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         /*  Sending Event outputs  */
         dynavVacantes_nombre.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5Vacantes_Nombre), 4, 0));
      }

      protected void E12372( )
      {
         /* 'Revisar' Routine */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpreclusegcord.aspx"+UrlEncode("" +AV5Vacantes_Nombre);
         CallWebObject(formatLink("wpreclusegcord.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA372( ) ;
         WS372( ) ;
         WE372( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714345688", true, true);
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
            context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("wpreclutamientocord.js", "?202262714345688", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_152( )
      {
         dynavVacantes_nombre_Internalname = "vVACANTES_NOMBRE_"+sGXsfl_15_idx;
         edtavVacantes_id_Internalname = "vVACANTES_ID_"+sGXsfl_15_idx;
         edtavProceso_completo_Internalname = "vPROCESO_COMPLETO_"+sGXsfl_15_idx;
         edtavEnviado_cliente_Internalname = "vENVIADO_CLIENTE_"+sGXsfl_15_idx;
         edtavDescartados_Internalname = "vDESCARTADOS_"+sGXsfl_15_idx;
         lblTextblock3_Internalname = "TEXTBLOCK3_"+sGXsfl_15_idx;
         lblTextblock1_Internalname = "TEXTBLOCK1_"+sGXsfl_15_idx;
         imgImage3_Internalname = "IMAGE3_"+sGXsfl_15_idx;
         lblTextblock2_Internalname = "TEXTBLOCK2_"+sGXsfl_15_idx;
      }

      protected void SubsflControlProps_fel_152( )
      {
         dynavVacantes_nombre_Internalname = "vVACANTES_NOMBRE_"+sGXsfl_15_fel_idx;
         edtavVacantes_id_Internalname = "vVACANTES_ID_"+sGXsfl_15_fel_idx;
         edtavProceso_completo_Internalname = "vPROCESO_COMPLETO_"+sGXsfl_15_fel_idx;
         edtavEnviado_cliente_Internalname = "vENVIADO_CLIENTE_"+sGXsfl_15_fel_idx;
         edtavDescartados_Internalname = "vDESCARTADOS_"+sGXsfl_15_fel_idx;
         lblTextblock3_Internalname = "TEXTBLOCK3_"+sGXsfl_15_fel_idx;
         lblTextblock1_Internalname = "TEXTBLOCK1_"+sGXsfl_15_fel_idx;
         imgImage3_Internalname = "IMAGE3_"+sGXsfl_15_fel_idx;
         lblTextblock2_Internalname = "TEXTBLOCK2_"+sGXsfl_15_fel_idx;
      }

      protected void sendrow_152( )
      {
         SubsflControlProps_152( ) ;
         WB370( ) ;
         Grid1Row = GXWebRow.GetNew(context,Grid1Container);
         if ( subGrid1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid1_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
         }
         else if ( subGrid1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid1_Backstyle = 0;
            subGrid1_Backcolor = subGrid1_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Uniform";
            }
         }
         else if ( subGrid1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
            subGrid1_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGrid1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( ((int)((nGXsfl_15_idx) % (2))) == 0 )
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Even";
               }
            }
            else
            {
               subGrid1_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGrid1_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_15_idx+"\">") ;
         }
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)divGrid1table_Internalname+"_"+sGXsfl_15_idx,(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"Table",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"row",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"col-xs-12",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Table start */
         Grid1Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(String)tblTable2_Internalname+"_"+sGXsfl_15_idx,(short)1,(String)"TablaRedondeada",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(short)2,(String)"",(String)"",(String)"",(String)"px",(String)"px",(String)""});
         Grid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         Grid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         /* Table start */
         Grid1Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(String)tblTable1_Internalname+"_"+sGXsfl_15_idx,(short)1,(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(short)2,(String)"",(String)"",(String)"",(String)"px",(String)"px",(String)""});
         Grid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         Grid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"form-group gx-form-group gx-default-form-group gx-label-top",(String)"left",(String)"top",(String)""+" data-gx-for=\""+dynavVacantes_nombre_Internalname+"\"",(String)"",(String)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)100,(String)"%",(short)0,(String)"px",(String)"gx-form-item gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         TempTags = " " + ((dynavVacantes_nombre.Enabled!=0)&&(dynavVacantes_nombre.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 27,'',false,'"+sGXsfl_15_idx+"',15)\"" : " ");
         if ( ( dynavVacantes_nombre.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "vVACANTES_NOMBRE_" + sGXsfl_15_idx;
            dynavVacantes_nombre.Name = GXCCtl;
            dynavVacantes_nombre.WebTags = "";
            dynavVacantes_nombre.removeAllItems();
            /* Using cursor H00373 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               dynavVacantes_nombre.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00373_A263Vacantes_Id[0]), 4, 0)), H00373_A264Vacantes_Nombre[0], 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( dynavVacantes_nombre.ItemCount > 0 )
            {
               AV5Vacantes_Nombre = (short)(NumberUtil.Val( dynavVacantes_nombre.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5Vacantes_Nombre), 4, 0))), "."));
               AssignAttri("", false, dynavVacantes_nombre_Internalname, StringUtil.LTrimStr( (decimal)(AV5Vacantes_Nombre), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vVACANTES_NOMBRE"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sGXsfl_15_idx, context.localUtil.Format( (decimal)(AV5Vacantes_Nombre), "ZZZ9"), context));
            }
         }
         /* ComboBox */
         Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynavVacantes_nombre,(String)dynavVacantes_nombre_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV5Vacantes_Nombre), 4, 0)),(short)1,(String)dynavVacantes_nombre_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)1,dynavVacantes_nombre.Enabled,(short)0,(short)0,(short)0,(String)"em",(short)0,(String)"",((dynavVacantes_nombre.FontBold==1) ? "font-weight:bold;" : "font-weight:normal;"),(String)"AttributeLittle",(String)"",(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((dynavVacantes_nombre.Enabled!=0)&&(dynavVacantes_nombre.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,27);\"" : " "),(String)"",(bool)true});
         dynavVacantes_nombre.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5Vacantes_Nombre), 4, 0));
         AssignProp("", false, dynavVacantes_nombre_Internalname, "Values", (String)(dynavVacantes_nombre.ToJavascriptSource()), !bGXsfl_15_Refreshing);
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("cell");
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("row");
         }
         Grid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         Grid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         /* Table start */
         Grid1Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(String)tblTable5_Internalname+"_"+sGXsfl_15_idx,(short)1,(String)"Table",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(short)2,(String)"",(String)"",(String)"",(String)"px",(String)"px",(String)""});
         Grid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         Grid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         /* Table start */
         Grid1Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(String)tblTable4_Internalname+"_"+sGXsfl_15_idx,(short)1,(String)"TablaRedondeada",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(short)2,(String)"",(String)"",(String)"",(String)"px",(String)"px",(String)""});
         Grid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         Grid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(int)edtavVacantes_id_Visible,(short)0,(String)"px",(short)0,(String)"px",(String)"form-group gx-form-group gx-default-form-group",(String)"left",(String)"top",(String)""+" data-gx-for=\""+edtavVacantes_id_Internalname+"\"",(String)"",(String)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(String)edtavVacantes_id_Internalname,(String)"ID",(String)"gx-form-item AttributeLabel",(short)1,(bool)true,(String)"width: 25%;"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)75,(String)"%",(short)0,(String)"px",(String)"gx-form-item gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Single line edit */
         TempTags = " " + ((edtavVacantes_id_Enabled!=0)&&(edtavVacantes_id_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 38,'',false,'"+sGXsfl_15_idx+"',15)\"" : " ");
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavVacantes_id_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Vacantes_Id), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(AV11Vacantes_Id), "ZZZZZZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+((edtavVacantes_id_Enabled!=0)&&(edtavVacantes_id_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,38);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavVacantes_id_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(int)edtavVacantes_id_Visible,(short)1,(short)0,(String)"number",(String)"1",(short)9,(String)"chr",(short)1,(String)"row",(short)9,(short)0,(short)0,(short)15,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("cell");
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("row");
         }
         Grid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         Grid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"form-group gx-form-group gx-default-form-group",(String)"left",(String)"top",(String)""+" data-gx-for=\""+edtavProceso_completo_Internalname+"\"",(String)"",(String)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(String)edtavProceso_completo_Internalname,(String)"Proceso_Completo:",(String)"gx-form-item AttributeLittleLabel",(short)1,(bool)true,(String)"width: 80%;"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)20,(String)"%",(short)0,(String)"px",(String)"gx-form-item gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Single line edit */
         TempTags = " " + ((edtavProceso_completo_Enabled!=0)&&(edtavProceso_completo_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 43,'',false,'"+sGXsfl_15_idx+"',15)\"" : " ");
         ROClassString = "AttributeLittle";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavProceso_completo_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6Proceso_Completo), 4, 0, ",", "")),((edtavProceso_completo_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV6Proceso_Completo), "ZZZ9")) : context.localUtil.Format( (decimal)(AV6Proceso_Completo), "ZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+((edtavProceso_completo_Enabled!=0)&&(edtavProceso_completo_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,43);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavProceso_completo_Jsonclick,(short)0,(String)"AttributeLittle",(String)((edtavProceso_completo_Fontitalic==1) ? "font-style:italic;" : "font-style:normal;"),(String)ROClassString,(String)"",(String)"",(short)1,(int)edtavProceso_completo_Enabled,(short)0,(String)"number",(String)"1",(short)4,(String)"chr",(short)1,(String)"row",(short)4,(short)0,(short)0,(short)15,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("cell");
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("row");
         }
         Grid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         Grid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"form-group gx-form-group gx-default-form-group",(String)"left",(String)"top",(String)""+" data-gx-for=\""+edtavEnviado_cliente_Internalname+"\"",(String)"",(String)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(String)edtavEnviado_cliente_Internalname,(String)"Enviado_Cliente:",(String)"gx-form-item AttributeLittleLabel",(short)1,(bool)true,(String)"width: 80%;"});
         sendrow_15230( ) ;
      }

      protected void sendrow_15230( )
      {
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)20,(String)"%",(short)0,(String)"px",(String)"gx-form-item gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Single line edit */
         TempTags = " " + ((edtavEnviado_cliente_Enabled!=0)&&(edtavEnviado_cliente_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 48,'',false,'"+sGXsfl_15_idx+"',15)\"" : " ");
         ROClassString = "AttributeLittle";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavEnviado_cliente_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Enviado_Cliente), 4, 0, ",", "")),((edtavEnviado_cliente_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV7Enviado_Cliente), "ZZZ9")) : context.localUtil.Format( (decimal)(AV7Enviado_Cliente), "ZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+((edtavEnviado_cliente_Enabled!=0)&&(edtavEnviado_cliente_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,48);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavEnviado_cliente_Jsonclick,(short)0,(String)"AttributeLittle",(String)((edtavEnviado_cliente_Fontitalic==1) ? "font-style:italic;" : "font-style:normal;"),(String)ROClassString,(String)"",(String)"",(short)1,(int)edtavEnviado_cliente_Enabled,(short)0,(String)"number",(String)"1",(short)4,(String)"chr",(short)1,(String)"row",(short)4,(short)0,(short)0,(short)15,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("cell");
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("row");
         }
         Grid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         Grid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"form-group gx-form-group gx-default-form-group",(String)"left",(String)"top",(String)""+" data-gx-for=\""+edtavDescartados_Internalname+"\"",(String)"",(String)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(String)edtavDescartados_Internalname,(String)"Descartados:",(String)"gx-form-item AttributeLittleLabel",(short)1,(bool)true,(String)"width: 80%;"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)20,(String)"%",(short)0,(String)"px",(String)"gx-form-item gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Single line edit */
         TempTags = " " + ((edtavDescartados_Enabled!=0)&&(edtavDescartados_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 53,'',false,'"+sGXsfl_15_idx+"',15)\"" : " ");
         ROClassString = "AttributeLittle";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavDescartados_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8Descartados), 4, 0, ",", "")),((edtavDescartados_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8Descartados), "ZZZ9")) : context.localUtil.Format( (decimal)(AV8Descartados), "ZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+((edtavDescartados_Enabled!=0)&&(edtavDescartados_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,53);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavDescartados_Jsonclick,(short)0,(String)"AttributeLittle",(String)((edtavDescartados_Fontitalic==1) ? "font-style:italic;" : "font-style:normal;"),(String)ROClassString,(String)"",(String)"",(short)1,(int)edtavDescartados_Enabled,(short)0,(String)"number",(String)"1",(short)4,(String)"chr",(short)1,(String)"row",(short)4,(short)0,(short)0,(short)15,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("cell");
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("row");
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("table");
         }
         /* End of table */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("cell");
         }
         Grid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         /* Table start */
         Grid1Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(String)tblTable3_Internalname+"_"+sGXsfl_15_idx,(short)1,(String)"Table",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(short)2,(String)"",(String)"",(String)"",(String)"px",(String)"px",(String)""});
         Grid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         Grid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         /* Text block */
         Grid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(String)lblTextblock3_Internalname,(String)"Total de Candidatos",(String)"",(String)"",(String)lblTextblock3_Jsonclick,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"TextBlockLittle",(short)0,(String)"",(short)1,(short)1,(short)0});
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("cell");
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("row");
         }
         Grid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         Grid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         /* Text block */
         Grid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(String)lblTextblock1_Internalname,(String)lblTextblock1_Caption,(String)"",(String)"",(String)lblTextblock1_Jsonclick,(String)"'"+""+"'"+",false,"+"'"+""+"'","font-size:"+StringUtil.Str( (decimal)(lblTextblock1_Fontsize), 3, 0)+"pt;"+((lblTextblock1_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;")+"color:"+context.BuildHTMLColor( lblTextblock1_Forecolor)+";",(String)"BigGlobalTitle",(short)0,(String)"",(short)1,(short)1,(short)0});
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("cell");
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("row");
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("table");
         }
         /* End of table */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("cell");
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("row");
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("table");
         }
         /* End of table */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("cell");
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("row");
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("table");
         }
         /* End of table */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("cell");
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("row");
         }
         Grid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         Grid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         /* Active images/pictures */
         TempTags = " " + ((imgImage3_Enabled!=0)&&(imgImage3_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         sImgUrl = (String)(context.GetImagePath( "e12a2252-2cc2-4d15-9bb1-3da86e4285e6", "", context.GetTheme( )));
         Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)imgImage3_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)1,(short)1,(String)"",(String)"Revisar",(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)5,(String)imgImage3_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'REVISAR\\'."+"'",(String)StyleString,(String)ClassString,(String)"",(String)"",(String)"",(String)"",(String)" "+"data-gx-image"+" "+TempTags,(String)"",(String)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("cell");
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("row");
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("table");
         }
         /* End of table */
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"row",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"col-xs-12",(String)"Center",(String)"top",(String)"",(String)"",(String)"div"});
         /* Text block */
         Grid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(String)lblTextblock2_Internalname,".",(String)"",(String)"",(String)lblTextblock2_Jsonclick,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"TextBlock",(short)0,(String)"",(short)1,(short)1,(short)0});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"Center",(String)"top",(String)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         send_integrity_lvl_hashes372( ) ;
         /* End of Columns property logic. */
         Grid1Container.AddRow(Grid1Row);
         nGXsfl_15_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_15_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         /* End function sendrow_152 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vVACANTES_NOMBRE_" + sGXsfl_15_idx;
         dynavVacantes_nombre.Name = GXCCtl;
         dynavVacantes_nombre.WebTags = "";
         dynavVacantes_nombre.removeAllItems();
         /* Using cursor H00374 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            dynavVacantes_nombre.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00374_A263Vacantes_Id[0]), 4, 0)), H00374_A264Vacantes_Nombre[0], 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( dynavVacantes_nombre.ItemCount > 0 )
         {
            AV5Vacantes_Nombre = (short)(NumberUtil.Val( dynavVacantes_nombre.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5Vacantes_Nombre), 4, 0))), "."));
            AssignAttri("", false, dynavVacantes_nombre_Internalname, StringUtil.LTrimStr( (decimal)(AV5Vacantes_Nombre), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vVACANTES_NOMBRE"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sGXsfl_15_idx, context.localUtil.Format( (decimal)(AV5Vacantes_Nombre), "ZZZ9"), context));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock4_Internalname = "TEXTBLOCK4";
         divTable6_Internalname = "TABLE6";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         dynavVacantes_nombre_Internalname = "vVACANTES_NOMBRE";
         edtavVacantes_id_Internalname = "vVACANTES_ID";
         edtavProceso_completo_Internalname = "vPROCESO_COMPLETO";
         edtavEnviado_cliente_Internalname = "vENVIADO_CLIENTE";
         edtavDescartados_Internalname = "vDESCARTADOS";
         tblTable4_Internalname = "TABLE4";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         tblTable3_Internalname = "TABLE3";
         tblTable5_Internalname = "TABLE5";
         tblTable1_Internalname = "TABLE1";
         imgImage3_Internalname = "IMAGE3";
         tblTable2_Internalname = "TABLE2";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         divGrid1table_Internalname = "GRID1TABLE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         lblTextblock1_Forecolor = (int)(0x000000);
         lblTextblock1_Fontbold = 0;
         lblTextblock1_Fontsize = (int)(15.0m);
         lblTextblock1_Caption = "Text Block";
         edtavDescartados_Jsonclick = "";
         edtavDescartados_Visible = 1;
         edtavEnviado_cliente_Jsonclick = "";
         edtavEnviado_cliente_Visible = 1;
         edtavProceso_completo_Jsonclick = "";
         edtavProceso_completo_Visible = 1;
         edtavVacantes_id_Jsonclick = "";
         edtavVacantes_id_Enabled = 1;
         dynavVacantes_nombre_Jsonclick = "";
         dynavVacantes_nombre.Visible = 1;
         subGrid1_Class = "FreeStyleGrid";
         subGrid1_Allowcollapsing = 0;
         lblTextblock2_Caption = ".";
         lblTextblock5_Caption = "Text Block";
         lblTextblock3_Caption = "Total de Candidatos";
         edtavDescartados_Enabled = 1;
         edtavDescartados_Fontitalic = 0;
         edtavEnviado_cliente_Enabled = 1;
         edtavEnviado_cliente_Fontitalic = 0;
         edtavProceso_completo_Enabled = 1;
         edtavProceso_completo_Fontitalic = 0;
         edtavVacantes_id_Visible = 1;
         dynavVacantes_nombre.Enabled = 1;
         dynavVacantes_nombre.FontBold = 0;
         subGrid1_Backcolorstyle = 0;
         lblTextblock5_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "wp Coordinador";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'A290VacantesUsuariosEstatus',fld:'VACANTESUSUARIOSESTATUS',pic:'ZZZ9'},{av:'A277Vacantes_Plazas',fld:'VACANTES_PLAZAS',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID1.LOAD","{handler:'E11372',iparms:[{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'A290VacantesUsuariosEstatus',fld:'VACANTESUSUARIOSESTATUS',pic:'ZZZ9'},{av:'A277Vacantes_Plazas',fld:'VACANTES_PLAZAS',pic:'ZZZ9'}]");
         setEventMetadata("GRID1.LOAD",",oparms:[{av:'lblTextblock1_Fontbold',ctrl:'TEXTBLOCK1',prop:'Fontbold'},{av:'lblTextblock1_Forecolor',ctrl:'TEXTBLOCK1',prop:'Forecolor'},{av:'lblTextblock1_Fontsize',ctrl:'TEXTBLOCK1',prop:'Fontsize'},{av:'lblTextblock5_Visible',ctrl:'TEXTBLOCK5',prop:'Visible'},{av:'edtavProceso_completo_Fontitalic',ctrl:'vPROCESO_COMPLETO',prop:'Fontitalic'},{av:'edtavEnviado_cliente_Fontitalic',ctrl:'vENVIADO_CLIENTE',prop:'Fontitalic'},{av:'edtavDescartados_Fontitalic',ctrl:'vDESCARTADOS',prop:'Fontitalic'},{av:'edtavVacantes_id_Visible',ctrl:'vVACANTES_ID',prop:'Visible'},{av:'AV11Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV6Proceso_Completo',fld:'vPROCESO_COMPLETO',pic:'ZZZ9'},{av:'AV8Descartados',fld:'vDESCARTADOS',pic:'ZZZ9'},{av:'AV7Enviado_Cliente',fld:'vENVIADO_CLIENTE',pic:'ZZZ9'},{av:'dynavVacantes_nombre'},{av:'AV5Vacantes_Nombre',fld:'vVACANTES_NOMBRE',pic:'ZZZ9',hsh:true},{av:'lblTextblock1_Caption',ctrl:'TEXTBLOCK1',prop:'Caption'}]}");
         setEventMetadata("'REVISAR'","{handler:'E12372',iparms:[{av:'dynavVacantes_nombre'},{av:'AV5Vacantes_Nombre',fld:'vVACANTES_NOMBRE',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("'REVISAR'",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Descartados',iparms:[]");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Header = "";
         Grid1Column = new GXWebColumn();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H00372_A11UsuariosId = new int[1] ;
         H00372_A263Vacantes_Id = new int[1] ;
         H00372_A290VacantesUsuariosEstatus = new short[1] ;
         H00372_n290VacantesUsuariosEstatus = new bool[] {false} ;
         H00372_A277Vacantes_Plazas = new short[1] ;
         AV10NumPlazas = "";
         Grid1Row = new GXWebRow();
         GXEncryptionTmp = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         TempTags = "";
         GXCCtl = "";
         H00373_A263Vacantes_Id = new int[1] ;
         H00373_A264Vacantes_Nombre = new String[] {""} ;
         ROClassString = "";
         lblTextblock3_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         imgImage3_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         H00374_A263Vacantes_Id = new int[1] ;
         H00374_A264Vacantes_Nombre = new String[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpreclutamientocord__default(),
            new Object[][] {
                new Object[] {
               H00372_A11UsuariosId, H00372_A263Vacantes_Id, H00372_A290VacantesUsuariosEstatus, H00372_n290VacantesUsuariosEstatus, H00372_A277Vacantes_Plazas
               }
               , new Object[] {
               H00373_A263Vacantes_Id, H00373_A264Vacantes_Nombre
               }
               , new Object[] {
               H00374_A263Vacantes_Id, H00374_A264Vacantes_Nombre
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         dynavVacantes_nombre.Enabled = 0;
         edtavProceso_completo_Enabled = 0;
         edtavEnviado_cliente_Enabled = 0;
         edtavDescartados_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nGotPars ;
      private short GxWebError ;
      private short A290VacantesUsuariosEstatus ;
      private short A277Vacantes_Plazas ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short AV5Vacantes_Nombre ;
      private short AV6Proceso_Completo ;
      private short edtavProceso_completo_Fontitalic ;
      private short AV7Enviado_Cliente ;
      private short edtavEnviado_cliente_Fontitalic ;
      private short AV8Descartados ;
      private short edtavDescartados_Fontitalic ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short lblTextblock1_Fontbold ;
      private short AV13ConteoProcComp ;
      private short AV14ConteoEnvClie ;
      private short AV15ContDescar ;
      private short subGrid1_Backstyle ;
      private short GRID1_nEOF ;
      private int nRC_GXsfl_15 ;
      private int nGXsfl_15_idx=1 ;
      private int A263Vacantes_Id ;
      private int lblTextblock5_Visible ;
      private int AV11Vacantes_Id ;
      private int edtavVacantes_id_Visible ;
      private int edtavProceso_completo_Enabled ;
      private int edtavEnviado_cliente_Enabled ;
      private int edtavDescartados_Enabled ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subGrid1_Islastpage ;
      private int lblTextblock1_Forecolor ;
      private int lblTextblock1_Fontsize ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int edtavVacantes_id_Enabled ;
      private int edtavProceso_completo_Visible ;
      private int edtavEnviado_cliente_Visible ;
      private int edtavDescartados_Visible ;
      private int imgImage3_Enabled ;
      private int imgImage3_Visible ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nFirstRecordOnPage ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_15_idx="0001" ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String divTable6_Internalname ;
      private String lblTextblock4_Internalname ;
      private String lblTextblock4_Jsonclick ;
      private String lblTextblock5_Internalname ;
      private String lblTextblock5_Jsonclick ;
      private String sStyleString ;
      private String subGrid1_Internalname ;
      private String subGrid1_Header ;
      private String lblTextblock3_Caption ;
      private String lblTextblock5_Caption ;
      private String lblTextblock2_Caption ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String dynavVacantes_nombre_Internalname ;
      private String edtavVacantes_id_Internalname ;
      private String edtavProceso_completo_Internalname ;
      private String edtavEnviado_cliente_Internalname ;
      private String edtavDescartados_Internalname ;
      private String scmdbuf ;
      private String AV10NumPlazas ;
      private String lblTextblock1_Caption ;
      private String GXEncryptionTmp ;
      private String lblTextblock3_Internalname ;
      private String lblTextblock1_Internalname ;
      private String imgImage3_Internalname ;
      private String lblTextblock2_Internalname ;
      private String sGXsfl_15_fel_idx="0001" ;
      private String subGrid1_Class ;
      private String subGrid1_Linesclass ;
      private String divGrid1table_Internalname ;
      private String tblTable2_Internalname ;
      private String tblTable1_Internalname ;
      private String TempTags ;
      private String GXCCtl ;
      private String dynavVacantes_nombre_Jsonclick ;
      private String tblTable5_Internalname ;
      private String tblTable4_Internalname ;
      private String ROClassString ;
      private String edtavVacantes_id_Jsonclick ;
      private String edtavProceso_completo_Jsonclick ;
      private String edtavEnviado_cliente_Jsonclick ;
      private String edtavDescartados_Jsonclick ;
      private String tblTable3_Internalname ;
      private String lblTextblock3_Jsonclick ;
      private String lblTextblock1_Jsonclick ;
      private String ClassString ;
      private String StyleString ;
      private String sImgUrl ;
      private String imgImage3_Jsonclick ;
      private String lblTextblock2_Jsonclick ;
      private bool entryPointCalled ;
      private bool n290VacantesUsuariosEstatus ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_15_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool BRK373 ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavVacantes_nombre ;
      private IDataStoreProvider pr_default ;
      private int[] H00372_A11UsuariosId ;
      private int[] H00372_A263Vacantes_Id ;
      private short[] H00372_A290VacantesUsuariosEstatus ;
      private bool[] H00372_n290VacantesUsuariosEstatus ;
      private short[] H00372_A277Vacantes_Plazas ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int[] H00373_A263Vacantes_Id ;
      private String[] H00373_A264Vacantes_Nombre ;
      private int[] H00374_A263Vacantes_Id ;
      private String[] H00374_A264Vacantes_Nombre ;
      private GXWebForm Form ;
   }

   public class wpreclutamientocord__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00372 ;
          prmH00372 = new Object[] {
          } ;
          Object[] prmH00373 ;
          prmH00373 = new Object[] {
          } ;
          Object[] prmH00374 ;
          prmH00374 = new Object[] {
          } ;
          def= new CursorDef[] {
              new CursorDef("H00372", "SELECT T1.`UsuariosId`, T1.`Vacantes_Id`, T1.`VacantesUsuariosEstatus`, T2.`Vacantes_Plazas` FROM (`VacantesUsuariosVacante` T1 INNER JOIN `Vacantes` T2 ON T2.`Vacantes_Id` = T1.`Vacantes_Id`) WHERE T1.`Vacantes_Id` <> 17 ORDER BY T1.`Vacantes_Id` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00372,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00373", "SELECT `Vacantes_Id`, `Vacantes_Nombre` FROM `Vacantes` ORDER BY `Vacantes_Nombre` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00373,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00374", "SELECT `Vacantes_Id`, `Vacantes_Nombre` FROM `Vacantes` ORDER BY `Vacantes_Nombre` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00374,0, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4) ;
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
       }
    }

 }

}
