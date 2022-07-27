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
   public class wppostulacionreclu : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wppostulacionreclu( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public wppostulacionreclu( IGxContext context )
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
         radavVacantesusuariosestatus = new GXRadio();
         dynavPerfiles_id = new GXCombobox();
         dynSUBT_ReclutadorId = new GXCombobox();
         dynVacantes_Id = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"SUBT_RECLUTADORID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLASUBT_RECLUTADORID313( ) ;
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
               nRC_GXsfl_24 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_24_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_24_idx = GetNextPar( );
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
               subGrid1_Rows = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV8NomCompleto = GetNextPar( );
               AV23EstatusVacante = (short)(NumberUtil.Val( GetNextPar( ), "."));
               A283PerfilesUsuariosEstatus = (short)(NumberUtil.Val( GetNextPar( ), "."));
               A278Perfiles_Id = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV13usuariosid = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV22VacantesUsuariosEstatus = (short)(NumberUtil.Val( GetNextPar( ), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV8NomCompleto, AV23EstatusVacante, A283PerfilesUsuariosEstatus, A278Perfiles_Id, AV13usuariosid, AV22VacantesUsuariosEstatus) ;
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
         PA312( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START312( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714345515", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 2036420), false, true);
         context.AddJavascriptSource("SweetAlert2/sweetalert2.all.min.js", "", false, true);
         context.AddJavascriptSource("SweetAlert2/SweetAlert2Render.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wppostulacionreclu.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13usuariosid), "ZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vNOMCOMPLETO", AV8NomCompleto);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_24", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_24), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vALERTPROPERTIES", AV18AlertProperties);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vALERTPROPERTIES", AV18AlertProperties);
         }
         GxWebStd.gx_hidden_field( context, "vESTATUSVACANTE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23EstatusVacante), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PERFILESUSUARIOSESTATUS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A283PerfilesUsuariosEstatus), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PERFILES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A278Perfiles_Id), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13usuariosid), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13usuariosid), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSNOMBRE", A66UsuariosNombre);
         GxWebStd.gx_hidden_field( context, "USUARIOSAPPAT", A65UsuariosApPat);
         GxWebStd.gx_hidden_field( context, "USUARIOSAPMAT", A64UsuariosApMat);
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSESTATUS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A290VacantesUsuariosEstatus), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
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
            WE312( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT312( ) ;
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
         return formatLink("wppostulacionreclu.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "wpPostulacionReclu" ;
      }

      public override String GetPgmdesc( )
      {
         return "wp Candidatos" ;
      }

      protected void WB310( )
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
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "TableTopSearch", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2 col-xs-offset-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, lblTitletext_Caption, "", "", lblTitletext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SubTitle", 0, "", 1, 1, 0, "HLP_wpPostulacionReclu.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNomcompleto_Internalname, "Nom Completo", "col-sm-3 FilterSearchAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'" + sGXsfl_24_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNomcompleto_Internalname, AV8NomCompleto, StringUtil.RTrim( context.localUtil.Format( AV8NomCompleto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,15);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Nombre", edtavNomcompleto_Jsonclick, 0, "FilterSearchAttribute", "", "", "", "", 1, edtavNomcompleto_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpPostulacionReclu.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+radavVacantesusuariosestatus_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'" + sGXsfl_24_idx + "',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavVacantesusuariosestatus, radavVacantesusuariosestatus_Internalname, StringUtil.Str( (decimal)(AV22VacantesUsuariosEstatus), 4, 0), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavVacantesusuariosestatus_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,19);\"", "HLP_wpPostulacionReclu.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"24\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid1_Backcolorstyle == 0 )
               {
                  subGrid1_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
               else
               {
                  subGrid1_Titlebackstyle = 1;
                  if ( subGrid1_Backcolorstyle == 1 )
                  {
                     subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "ID") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Teléfono") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Perfil") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Reclutador") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Correo electrónico") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Vacante") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha Postulación") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtVacantesUsuariosFechaD_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Fecha Descarte") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtVacantesUsuariosMotD_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Motivo de Descarte") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Grid1Container.AddObjectProperty("GridName", "Grid1");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Grid1Container = new GXWebGrid( context);
               }
               else
               {
                  Grid1Container.Clear();
               }
               Grid1Container.SetWrapped(nGXWrapped);
               Grid1Container.AddObjectProperty("GridName", "Grid1");
               Grid1Container.AddObjectProperty("Header", subGrid1_Header);
               Grid1Container.AddObjectProperty("Class", "WorkWith");
               Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("CmpContext", "");
               Grid1Container.AddObjectProperty("InMasterPage", "false");
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", A97UsuariosNomCompleto);
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A260UsuariosTelef));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9Perfiles_Id), 9, 0, ".", "")));
               Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynavPerfiles_id.Enabled), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A284SUBT_ReclutadorId), 6, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", A261UsuariosCorreo);
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A263Vacantes_Id), 9, 0, ".", "")));
               Grid1Column.AddObjectProperty("Fontbold", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynVacantes_Id.FontBold), 1, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.TToC( A288VacantesUsuariosFechaP, 10, 8, 0, 3, "/", ":", " "));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.TToC( A289VacantesUsuariosFechaD, 10, 8, 0, 3, "/", ":", " "));
               Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVacantesUsuariosFechaD_Visible), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", A294VacantesUsuariosMotD);
               Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVacantesUsuariosMotD_Visible), 5, 0, ".", "")));
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
         if ( wbEnd == 24 )
         {
            wbEnd = 0;
            nRC_GXsfl_24 = (int)(nGXsfl_24_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucUcalertas.SetProperty("Propiedades", AV18AlertProperties);
            ucUcalertas.Render(context, "sweetalert2", Ucalertas_Internalname, "UCALERTASContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 24 )
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
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
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

      protected void START312( )
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
         STRUP310( ) ;
      }

      protected void WS312( )
      {
         START312( ) ;
         EVT312( ) ;
      }

      protected void EVT312( )
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
                           else if ( StringUtil.StrCmp(sEvt, "VVACANTESUSUARIOSESTATUS.ISVALID") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E11312 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'MUESTRAINFO'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'MuestraInfo' */
                              E12312 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "'MUESTRAINFO'") == 0 ) )
                           {
                              nGXsfl_24_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
                              SubsflControlProps_242( ) ;
                              A11UsuariosId = (int)(context.localUtil.CToN( cgiGet( edtUsuariosId_Internalname), ",", "."));
                              A97UsuariosNomCompleto = cgiGet( edtUsuariosNomCompleto_Internalname);
                              A260UsuariosTelef = cgiGet( edtUsuariosTelef_Internalname);
                              dynavPerfiles_id.Name = dynavPerfiles_id_Internalname;
                              dynavPerfiles_id.CurrentValue = cgiGet( dynavPerfiles_id_Internalname);
                              AV9Perfiles_Id = (int)(NumberUtil.Val( cgiGet( dynavPerfiles_id_Internalname), "."));
                              AssignAttri("", false, dynavPerfiles_id_Internalname, StringUtil.LTrimStr( (decimal)(AV9Perfiles_Id), 9, 0));
                              dynSUBT_ReclutadorId.Name = dynSUBT_ReclutadorId_Internalname;
                              dynSUBT_ReclutadorId.CurrentValue = cgiGet( dynSUBT_ReclutadorId_Internalname);
                              A284SUBT_ReclutadorId = (int)(NumberUtil.Val( cgiGet( dynSUBT_ReclutadorId_Internalname), "."));
                              A261UsuariosCorreo = cgiGet( edtUsuariosCorreo_Internalname);
                              dynVacantes_Id.Name = dynVacantes_Id_Internalname;
                              dynVacantes_Id.CurrentValue = cgiGet( dynVacantes_Id_Internalname);
                              A263Vacantes_Id = (int)(NumberUtil.Val( cgiGet( dynVacantes_Id_Internalname), "."));
                              A288VacantesUsuariosFechaP = context.localUtil.CToT( cgiGet( edtVacantesUsuariosFechaP_Internalname), 0);
                              A289VacantesUsuariosFechaD = context.localUtil.CToT( cgiGet( edtVacantesUsuariosFechaD_Internalname), 0);
                              n289VacantesUsuariosFechaD = false;
                              A294VacantesUsuariosMotD = cgiGet( edtVacantesUsuariosMotD_Internalname);
                              n294VacantesUsuariosMotD = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E13312 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E14312 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Nomcompleto Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vNOMCOMPLETO"), AV8NomCompleto) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'MUESTRAINFO'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'MuestraInfo' */
                                    E12312 ();
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

      protected void WE312( )
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

      protected void PA312( )
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
               GX_FocusControl = edtavNomcompleto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLASUBT_RECLUTADORID313( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLASUBT_RECLUTADORID_data313( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((String)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((String)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXASUBT_RECLUTADORID_html313( )
      {
         int gxdynajaxvalue ;
         GXDLASUBT_RECLUTADORID_data313( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynSUBT_ReclutadorId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((String)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynSUBT_ReclutadorId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((String)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLASUBT_RECLUTADORID_data313( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00312 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00312_A284SUBT_ReclutadorId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00312_A287SUBT_ReclutadorNombre[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_242( ) ;
         while ( nGXsfl_24_idx <= nRC_GXsfl_24 )
         {
            sendrow_242( ) ;
            nGXsfl_24_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_24_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_24_idx+1);
            sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
            SubsflControlProps_242( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        String AV8NomCompleto ,
                                        short AV23EstatusVacante ,
                                        short A283PerfilesUsuariosEstatus ,
                                        int A278Perfiles_Id ,
                                        int AV13usuariosid ,
                                        short AV22VacantesUsuariosEstatus )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF312( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
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
         AV22VacantesUsuariosEstatus = (short)(context.localUtil.CToN( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22VacantesUsuariosEstatus), 4, 0, ".", "")), ",", "."));
         AssignAttri("", false, "AV22VacantesUsuariosEstatus", StringUtil.LTrimStr( (decimal)(AV22VacantesUsuariosEstatus), 4, 0));
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF312( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         dynavPerfiles_id.Enabled = 0;
         AssignProp("", false, dynavPerfiles_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavPerfiles_id.Enabled), 5, 0), !bGXsfl_24_Refreshing);
      }

      protected void RF312( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 24;
         nGXsfl_24_idx = 1;
         sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
         SubsflControlProps_242( ) ;
         bGXsfl_24_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "WorkWith");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_242( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV8NomCompleto ,
                                                 A66UsuariosNombre ,
                                                 A65UsuariosApPat ,
                                                 A64UsuariosApMat } ,
                                                 new int[]{
                                                 TypeConstants.STRING, TypeConstants.STRING, TypeConstants.BOOLEAN, TypeConstants.STRING, TypeConstants.BOOLEAN, TypeConstants.STRING, TypeConstants.BOOLEAN
                                                 }
            } ) ;
            lV8NomCompleto = StringUtil.Concat( StringUtil.RTrim( AV8NomCompleto), "%", "");
            /* Using cursor H00313 */
            pr_default.execute(1, new Object[] {lV8NomCompleto});
            nGXsfl_24_idx = 1;
            sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
            SubsflControlProps_242( ) ;
            GRID1_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid1_Rows == 0 ) || ( GRID1_nCurrentRecord < GRID1_nFirstRecordOnPage + subGrid1_fnc_Recordsperpage( ) ) ) ) )
            {
               BRK312 = false;
               A263Vacantes_Id = H00313_A263Vacantes_Id[0];
               A290VacantesUsuariosEstatus = H00313_A290VacantesUsuariosEstatus[0];
               n290VacantesUsuariosEstatus = H00313_n290VacantesUsuariosEstatus[0];
               A11UsuariosId = H00313_A11UsuariosId[0];
               A294VacantesUsuariosMotD = H00313_A294VacantesUsuariosMotD[0];
               n294VacantesUsuariosMotD = H00313_n294VacantesUsuariosMotD[0];
               A289VacantesUsuariosFechaD = H00313_A289VacantesUsuariosFechaD[0];
               n289VacantesUsuariosFechaD = H00313_n289VacantesUsuariosFechaD[0];
               A288VacantesUsuariosFechaP = H00313_A288VacantesUsuariosFechaP[0];
               A261UsuariosCorreo = H00313_A261UsuariosCorreo[0];
               A284SUBT_ReclutadorId = H00313_A284SUBT_ReclutadorId[0];
               A260UsuariosTelef = H00313_A260UsuariosTelef[0];
               A64UsuariosApMat = H00313_A64UsuariosApMat[0];
               n64UsuariosApMat = H00313_n64UsuariosApMat[0];
               A65UsuariosApPat = H00313_A65UsuariosApPat[0];
               n65UsuariosApPat = H00313_n65UsuariosApPat[0];
               A66UsuariosNombre = H00313_A66UsuariosNombre[0];
               n66UsuariosNombre = H00313_n66UsuariosNombre[0];
               A261UsuariosCorreo = H00313_A261UsuariosCorreo[0];
               A260UsuariosTelef = H00313_A260UsuariosTelef[0];
               A64UsuariosApMat = H00313_A64UsuariosApMat[0];
               n64UsuariosApMat = H00313_n64UsuariosApMat[0];
               A65UsuariosApPat = H00313_A65UsuariosApPat[0];
               n65UsuariosApPat = H00313_n65UsuariosApPat[0];
               A66UsuariosNombre = H00313_A66UsuariosNombre[0];
               n66UsuariosNombre = H00313_n66UsuariosNombre[0];
               A97UsuariosNomCompleto = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + StringUtil.Trim( A64UsuariosApMat);
               E14312 ();
               if ( ! BRK312 )
               {
                  BRK312 = true;
                  pr_default.readNext(1);
               }
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            wbEnd = 24;
            WB310( ) ;
         }
         bGXsfl_24_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes312( )
      {
         GxWebStd.gx_hidden_field( context, "vUSUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13usuariosid), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13usuariosid), "ZZZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         return (int)(GRID1_nFirstRecordOnPage+1) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         if ( subGrid1_Rows > 0 )
         {
            return subGrid1_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV8NomCompleto, AV23EstatusVacante, A283PerfilesUsuariosEstatus, A278Perfiles_Id, AV13usuariosid, AV22VacantesUsuariosEstatus) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         if ( GRID1_nEOF == 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV8NomCompleto, AV23EstatusVacante, A283PerfilesUsuariosEstatus, A278Perfiles_Id, AV13usuariosid, AV22VacantesUsuariosEstatus) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV8NomCompleto, AV23EstatusVacante, A283PerfilesUsuariosEstatus, A278Perfiles_Id, AV13usuariosid, AV22VacantesUsuariosEstatus) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         subGrid1_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV8NomCompleto, AV23EstatusVacante, A283PerfilesUsuariosEstatus, A278Perfiles_Id, AV13usuariosid, AV22VacantesUsuariosEstatus) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV8NomCompleto, AV23EstatusVacante, A283PerfilesUsuariosEstatus, A278Perfiles_Id, AV13usuariosid, AV22VacantesUsuariosEstatus) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         dynavPerfiles_id.Enabled = 0;
         AssignProp("", false, dynavPerfiles_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavPerfiles_id.Enabled), 5, 0), !bGXsfl_24_Refreshing);
      }

      protected void STRUP310( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13312 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vALERTPROPERTIES"), AV18AlertProperties);
            /* Read saved values. */
            nRC_GXsfl_24 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_24"), ",", "."));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ",", "."));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ",", "."));
            subGrid1_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID1_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV8NomCompleto = cgiGet( edtavNomcompleto_Internalname);
            AssignAttri("", false, "AV8NomCompleto", AV8NomCompleto);
            if ( ( ( context.localUtil.CToN( cgiGet( radavVacantesusuariosestatus_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( radavVacantesusuariosestatus_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVACANTESUSUARIOSESTATUS");
               wbErr = true;
               AV22VacantesUsuariosEstatus = 0;
               AssignAttri("", false, "AV22VacantesUsuariosEstatus", StringUtil.LTrimStr( (decimal)(AV22VacantesUsuariosEstatus), 4, 0));
            }
            else
            {
               AV22VacantesUsuariosEstatus = (short)(context.localUtil.CToN( cgiGet( radavVacantesusuariosestatus_Internalname), ",", "."));
               AssignAttri("", false, "AV22VacantesUsuariosEstatus", StringUtil.LTrimStr( (decimal)(AV22VacantesUsuariosEstatus), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vNOMCOMPLETO"), AV8NomCompleto) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E13312 ();
         if ( returnInSub )
         {
            pr_default.close(1);
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E13312( )
      {
         /* Start Routine */
         subGrid1_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         AV23EstatusVacante = 3;
         AssignAttri("", false, "AV23EstatusVacante", StringUtil.LTrimStr( (decimal)(AV23EstatusVacante), 4, 0));
      }

      protected void E11312( )
      {
         /* Vacantesusuariosestatus_Isvalid Routine */
         if ( AV22VacantesUsuariosEstatus == 1 )
         {
            lblTitletext_Caption = "Postulados";
            AssignProp("", false, lblTitletext_Internalname, "Caption", lblTitletext_Caption, true);
            AV23EstatusVacante = 3;
            AssignAttri("", false, "AV23EstatusVacante", StringUtil.LTrimStr( (decimal)(AV23EstatusVacante), 4, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            lblTitletext_Caption = "Descartados";
            AssignProp("", false, lblTitletext_Internalname, "Caption", lblTitletext_Caption, true);
            AV23EstatusVacante = 5;
            AssignAttri("", false, "AV23EstatusVacante", StringUtil.LTrimStr( (decimal)(AV23EstatusVacante), 4, 0));
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
      }

      private void E14312( )
      {
         /* Grid1_Load Routine */
         GRID1_nEOF = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         while ( ( (pr_default.getStatus(1) != 101) && ( H00313_A11UsuariosId[0] == A11UsuariosId ) ) && ( ( ( subGrid1_Rows == 0 ) || ( GRID1_nCurrentRecord < GRID1_nFirstRecordOnPage + subGrid1_fnc_Recordsperpage( ) ) ) ) )
         {
            BRK312 = false;
            A263Vacantes_Id = H00313_A263Vacantes_Id[0];
            A290VacantesUsuariosEstatus = H00313_A290VacantesUsuariosEstatus[0];
            n290VacantesUsuariosEstatus = H00313_n290VacantesUsuariosEstatus[0];
            A294VacantesUsuariosMotD = H00313_A294VacantesUsuariosMotD[0];
            n294VacantesUsuariosMotD = H00313_n294VacantesUsuariosMotD[0];
            A289VacantesUsuariosFechaD = H00313_A289VacantesUsuariosFechaD[0];
            n289VacantesUsuariosFechaD = H00313_n289VacantesUsuariosFechaD[0];
            A288VacantesUsuariosFechaP = H00313_A288VacantesUsuariosFechaP[0];
            A284SUBT_ReclutadorId = H00313_A284SUBT_ReclutadorId[0];
            A64UsuariosApMat = H00313_A64UsuariosApMat[0];
            n64UsuariosApMat = H00313_n64UsuariosApMat[0];
            A65UsuariosApPat = H00313_A65UsuariosApPat[0];
            n65UsuariosApPat = H00313_n65UsuariosApPat[0];
            A66UsuariosNombre = H00313_A66UsuariosNombre[0];
            n66UsuariosNombre = H00313_n66UsuariosNombre[0];
            A64UsuariosApMat = H00313_A64UsuariosApMat[0];
            n64UsuariosApMat = H00313_n64UsuariosApMat[0];
            A65UsuariosApPat = H00313_A65UsuariosApPat[0];
            n65UsuariosApPat = H00313_n65UsuariosApPat[0];
            A66UsuariosNombre = H00313_A66UsuariosNombre[0];
            n66UsuariosNombre = H00313_n66UsuariosNombre[0];
            GXASUBT_RECLUTADORID_html313( ) ;
            if ( A263Vacantes_Id != 17 )
            {
               if ( A290VacantesUsuariosEstatus == AV23EstatusVacante )
               {
                  AV13usuariosid = A11UsuariosId;
                  AssignAttri("", false, "AV13usuariosid", StringUtil.LTrimStr( (decimal)(AV13usuariosid), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13usuariosid), "ZZZZZ9"), context));
                  dynVacantes_Id.FontBold = 1;
                  if ( AV23EstatusVacante == 3 )
                  {
                     edtVacantesUsuariosFechaD_Visible = 0;
                     edtVacantesUsuariosMotD_Visible = 0;
                  }
                  else
                  {
                     edtVacantesUsuariosFechaD_Visible = 1;
                     edtVacantesUsuariosMotD_Visible = 1;
                  }
                  /* Using cursor H00314 */
                  pr_default.execute(2, new Object[] {AV13usuariosid});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A283PerfilesUsuariosEstatus = H00314_A283PerfilesUsuariosEstatus[0];
                     A11UsuariosId = H00314_A11UsuariosId[0];
                     A278Perfiles_Id = H00314_A278Perfiles_Id[0];
                     AV9Perfiles_Id = A278Perfiles_Id;
                     AssignAttri("", false, dynavPerfiles_id_Internalname, StringUtil.LTrimStr( (decimal)(AV9Perfiles_Id), 9, 0));
                     pr_default.readNext(2);
                  }
                  pr_default.close(2);
                  /* Load Method */
                  if ( wbStart != -1 )
                  {
                     wbStart = 24;
                  }
                  if ( ( subGrid1_Islastpage == 1 ) || ( subGrid1_Rows == 0 ) || ( ( GRID1_nCurrentRecord >= GRID1_nFirstRecordOnPage ) && ( GRID1_nCurrentRecord < GRID1_nFirstRecordOnPage + subGrid1_fnc_Recordsperpage( ) ) ) )
                  {
                     sendrow_242( ) ;
                     GRID1_nEOF = 1;
                     GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
                     if ( ( subGrid1_Islastpage == 1 ) && ( ((int)((GRID1_nCurrentRecord) % (subGrid1_fnc_Recordsperpage( )))) == 0 ) )
                     {
                        GRID1_nFirstRecordOnPage = GRID1_nCurrentRecord;
                     }
                  }
                  if ( GRID1_nCurrentRecord >= GRID1_nFirstRecordOnPage + subGrid1_fnc_Recordsperpage( ) )
                  {
                     GRID1_nEOF = 0;
                     GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
                  }
                  GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
                  if ( isFullAjaxMode( ) && ! bGXsfl_24_Refreshing )
                  {
                     context.DoAjaxLoad(24, Grid1Row);
                  }
               }
            }
            BRK312 = true;
            pr_default.readNext(1);
         }
         GRID1_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         /*  Sending Event outputs  */
         dynavPerfiles_id.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9Perfiles_Id), 9, 0));
      }

      protected void E12312( )
      {
         /* 'MuestraInfo' Routine */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpinfgetodlados.aspx"+UrlEncode("" +A11UsuariosId);
         CallWebObject(formatLink("wpinfgetodlados.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         PA312( ) ;
         WS312( ) ;
         WE312( ) ;
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
         AddStyleSheetFile("SweetAlert2/css/font-awesome.min.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714345553", true, true);
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
         context.AddJavascriptSource("wppostulacionreclu.js", "?202262714345554", false, true);
         context.AddJavascriptSource("SweetAlert2/sweetalert2.all.min.js", "", false, true);
         context.AddJavascriptSource("SweetAlert2/SweetAlert2Render.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_242( )
      {
         edtUsuariosId_Internalname = "USUARIOSID_"+sGXsfl_24_idx;
         edtUsuariosNomCompleto_Internalname = "USUARIOSNOMCOMPLETO_"+sGXsfl_24_idx;
         edtUsuariosTelef_Internalname = "USUARIOSTELEF_"+sGXsfl_24_idx;
         dynavPerfiles_id_Internalname = "vPERFILES_ID_"+sGXsfl_24_idx;
         dynSUBT_ReclutadorId_Internalname = "SUBT_RECLUTADORID_"+sGXsfl_24_idx;
         edtUsuariosCorreo_Internalname = "USUARIOSCORREO_"+sGXsfl_24_idx;
         dynVacantes_Id_Internalname = "VACANTES_ID_"+sGXsfl_24_idx;
         edtVacantesUsuariosFechaP_Internalname = "VACANTESUSUARIOSFECHAP_"+sGXsfl_24_idx;
         edtVacantesUsuariosFechaD_Internalname = "VACANTESUSUARIOSFECHAD_"+sGXsfl_24_idx;
         edtVacantesUsuariosMotD_Internalname = "VACANTESUSUARIOSMOTD_"+sGXsfl_24_idx;
      }

      protected void SubsflControlProps_fel_242( )
      {
         edtUsuariosId_Internalname = "USUARIOSID_"+sGXsfl_24_fel_idx;
         edtUsuariosNomCompleto_Internalname = "USUARIOSNOMCOMPLETO_"+sGXsfl_24_fel_idx;
         edtUsuariosTelef_Internalname = "USUARIOSTELEF_"+sGXsfl_24_fel_idx;
         dynavPerfiles_id_Internalname = "vPERFILES_ID_"+sGXsfl_24_fel_idx;
         dynSUBT_ReclutadorId_Internalname = "SUBT_RECLUTADORID_"+sGXsfl_24_fel_idx;
         edtUsuariosCorreo_Internalname = "USUARIOSCORREO_"+sGXsfl_24_fel_idx;
         dynVacantes_Id_Internalname = "VACANTES_ID_"+sGXsfl_24_fel_idx;
         edtVacantesUsuariosFechaP_Internalname = "VACANTESUSUARIOSFECHAP_"+sGXsfl_24_fel_idx;
         edtVacantesUsuariosFechaD_Internalname = "VACANTESUSUARIOSFECHAD_"+sGXsfl_24_fel_idx;
         edtVacantesUsuariosMotD_Internalname = "VACANTESUSUARIOSMOTD_"+sGXsfl_24_fel_idx;
      }

      protected void sendrow_242( )
      {
         SubsflControlProps_242( ) ;
         WB310( ) ;
         if ( ( subGrid1_Rows * 1 == 0 ) || ( nGXsfl_24_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
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
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_24_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_24_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")),context.localUtil.Format( (decimal)(A11UsuariosId), "ZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosId_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)0,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)6,(short)0,(short)0,(short)24,(short)1,(short)-1,(short)0,(bool)true,(String)"NumId",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosNomCompleto_Internalname,(String)A97UsuariosNomCompleto,(String)"",(String)"","'"+""+"'"+",false,"+"'"+"E\\'MUESTRAINFO\\'."+sGXsfl_24_idx+"'",(String)"",(String)"",(String)"",(String)"Ver Información",(String)edtUsuariosNomCompleto_Jsonclick,(short)5,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)90,(short)0,(short)0,(short)24,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosTelef_Internalname,StringUtil.RTrim( A260UsuariosTelef),(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtUsuariosTelef_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)24,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((dynavPerfiles_id.Enabled!=0)&&(dynavPerfiles_id.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 28,'',false,'"+sGXsfl_24_idx+"',24)\"" : " ");
            if ( ( dynavPerfiles_id.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vPERFILES_ID_" + sGXsfl_24_idx;
               dynavPerfiles_id.Name = GXCCtl;
               dynavPerfiles_id.WebTags = "";
               dynavPerfiles_id.removeAllItems();
               /* Using cursor H00315 */
               pr_default.execute(3);
               while ( (pr_default.getStatus(3) != 101) )
               {
                  dynavPerfiles_id.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00315_A278Perfiles_Id[0]), 9, 0)), H00315_A279Perfiles_Nombre[0], 0);
                  pr_default.readNext(3);
               }
               pr_default.close(3);
               if ( dynavPerfiles_id.ItemCount > 0 )
               {
                  AV9Perfiles_Id = (int)(NumberUtil.Val( dynavPerfiles_id.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV9Perfiles_Id), 9, 0))), "."));
                  AssignAttri("", false, dynavPerfiles_id_Internalname, StringUtil.LTrimStr( (decimal)(AV9Perfiles_Id), 9, 0));
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynavPerfiles_id,(String)dynavPerfiles_id_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV9Perfiles_Id), 9, 0)),(short)1,(String)dynavPerfiles_id_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,dynavPerfiles_id.Enabled,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute",(String)"WWColumn WWOptionalColumn",(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((dynavPerfiles_id.Enabled!=0)&&(dynavPerfiles_id.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,28);\"" : " "),(String)"",(bool)true});
            dynavPerfiles_id.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9Perfiles_Id), 9, 0));
            AssignProp("", false, dynavPerfiles_id_Internalname, "Values", (String)(dynavPerfiles_id.ToJavascriptSource()), !bGXsfl_24_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( dynSUBT_ReclutadorId.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SUBT_RECLUTADORID_" + sGXsfl_24_idx;
               dynSUBT_ReclutadorId.Name = GXCCtl;
               dynSUBT_ReclutadorId.WebTags = "";
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynSUBT_ReclutadorId,(String)dynSUBT_ReclutadorId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A284SUBT_ReclutadorId), 6, 0)),(short)1,(String)dynSUBT_ReclutadorId_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute",(String)"WWColumn WWOptionalColumn",(String)"",(String)"",(String)"",(bool)true});
            dynSUBT_ReclutadorId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A284SUBT_ReclutadorId), 6, 0));
            AssignProp("", false, dynSUBT_ReclutadorId_Internalname, "Values", (String)(dynSUBT_ReclutadorId.ToJavascriptSource()), !bGXsfl_24_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUsuariosCorreo_Internalname,(String)A261UsuariosCorreo,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"mailto:"+A261UsuariosCorreo,(String)"",(String)"",(String)"",(String)edtUsuariosCorreo_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"email",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)100,(short)0,(short)0,(short)24,(short)1,(short)-1,(short)0,(bool)true,(String)"GeneXus\\Email",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( dynVacantes_Id.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "VACANTES_ID_" + sGXsfl_24_idx;
               dynVacantes_Id.Name = GXCCtl;
               dynVacantes_Id.WebTags = "";
               dynVacantes_Id.removeAllItems();
               /* Using cursor H00316 */
               pr_default.execute(4);
               while ( (pr_default.getStatus(4) != 101) )
               {
                  dynVacantes_Id.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00316_A263Vacantes_Id[0]), 9, 0)), H00316_A264Vacantes_Nombre[0], 0);
                  pr_default.readNext(4);
               }
               pr_default.close(4);
               if ( dynVacantes_Id.ItemCount > 0 )
               {
                  A263Vacantes_Id = (int)(NumberUtil.Val( dynVacantes_Id.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A263Vacantes_Id), 9, 0))), "."));
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynVacantes_Id,(String)dynVacantes_Id_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A263Vacantes_Id), 9, 0)),(short)1,(String)dynVacantes_Id_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",((dynVacantes_Id.FontBold==1) ? "font-weight:bold;" : "font-weight:normal;"),(String)"Attribute",(String)"WWColumn",(String)"",(String)"",(String)"",(bool)true});
            dynVacantes_Id.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A263Vacantes_Id), 9, 0));
            AssignProp("", false, dynVacantes_Id_Internalname, "Values", (String)(dynVacantes_Id.ToJavascriptSource()), !bGXsfl_24_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtVacantesUsuariosFechaP_Internalname,context.localUtil.TToC( A288VacantesUsuariosFechaP, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A288VacantesUsuariosFechaP, "99/99/9999 99:99"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtVacantesUsuariosFechaP_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)16,(short)0,(short)0,(short)24,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtVacantesUsuariosFechaD_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtVacantesUsuariosFechaD_Internalname,context.localUtil.TToC( A289VacantesUsuariosFechaD, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A289VacantesUsuariosFechaD, "99/99/99 99:99"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtVacantesUsuariosFechaD_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(int)edtVacantesUsuariosFechaD_Visible,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)14,(short)0,(short)0,(short)24,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtVacantesUsuariosMotD_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtVacantesUsuariosMotD_Internalname,(String)A294VacantesUsuariosMotD,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtVacantesUsuariosMotD_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(int)edtVacantesUsuariosMotD_Visible,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)2048,(short)0,(short)0,(short)24,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            send_integrity_lvl_hashes312( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_24_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_24_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_24_idx+1);
            sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
            SubsflControlProps_242( ) ;
         }
         /* End function sendrow_242 */
      }

      protected void init_web_controls( )
      {
         radavVacantesusuariosestatus.Name = "vVACANTESUSUARIOSESTATUS";
         radavVacantesusuariosestatus.WebTags = "";
         radavVacantesusuariosestatus.addItem("1", "Postulados", 0);
         radavVacantesusuariosestatus.addItem("2", "Descartados", 0);
         GXCCtl = "vPERFILES_ID_" + sGXsfl_24_idx;
         dynavPerfiles_id.Name = GXCCtl;
         dynavPerfiles_id.WebTags = "";
         dynavPerfiles_id.removeAllItems();
         /* Using cursor H00317 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            dynavPerfiles_id.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00317_A278Perfiles_Id[0]), 9, 0)), H00317_A279Perfiles_Nombre[0], 0);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         if ( dynavPerfiles_id.ItemCount > 0 )
         {
            AV9Perfiles_Id = (int)(NumberUtil.Val( dynavPerfiles_id.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV9Perfiles_Id), 9, 0))), "."));
            AssignAttri("", false, dynavPerfiles_id_Internalname, StringUtil.LTrimStr( (decimal)(AV9Perfiles_Id), 9, 0));
         }
         GXCCtl = "SUBT_RECLUTADORID_" + sGXsfl_24_idx;
         dynSUBT_ReclutadorId.Name = GXCCtl;
         dynSUBT_ReclutadorId.WebTags = "";
         GXCCtl = "VACANTES_ID_" + sGXsfl_24_idx;
         dynVacantes_Id.Name = GXCCtl;
         dynVacantes_Id.WebTags = "";
         dynVacantes_Id.removeAllItems();
         /* Using cursor H00318 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            dynVacantes_Id.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00318_A263Vacantes_Id[0]), 9, 0)), H00318_A264Vacantes_Nombre[0], 0);
            pr_default.readNext(6);
         }
         pr_default.close(6);
         if ( dynVacantes_Id.ItemCount > 0 )
         {
            A263Vacantes_Id = (int)(NumberUtil.Val( dynVacantes_Id.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A263Vacantes_Id), 9, 0))), "."));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitletext_Internalname = "TITLETEXT";
         edtavNomcompleto_Internalname = "vNOMCOMPLETO";
         radavVacantesusuariosestatus_Internalname = "vVACANTESUSUARIOSESTATUS";
         divTable2_Internalname = "TABLE2";
         edtUsuariosId_Internalname = "USUARIOSID";
         edtUsuariosNomCompleto_Internalname = "USUARIOSNOMCOMPLETO";
         edtUsuariosTelef_Internalname = "USUARIOSTELEF";
         dynavPerfiles_id_Internalname = "vPERFILES_ID";
         dynSUBT_ReclutadorId_Internalname = "SUBT_RECLUTADORID";
         edtUsuariosCorreo_Internalname = "USUARIOSCORREO";
         dynVacantes_Id_Internalname = "VACANTES_ID";
         edtVacantesUsuariosFechaP_Internalname = "VACANTESUSUARIOSFECHAP";
         edtVacantesUsuariosFechaD_Internalname = "VACANTESUSUARIOSFECHAD";
         edtVacantesUsuariosMotD_Internalname = "VACANTESUSUARIOSMOTD";
         divTable1_Internalname = "TABLE1";
         Ucalertas_Internalname = "UCALERTAS";
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
         edtVacantesUsuariosMotD_Jsonclick = "";
         edtVacantesUsuariosFechaD_Jsonclick = "";
         edtVacantesUsuariosFechaP_Jsonclick = "";
         dynVacantes_Id_Jsonclick = "";
         edtUsuariosCorreo_Jsonclick = "";
         dynSUBT_ReclutadorId_Jsonclick = "";
         dynavPerfiles_id_Jsonclick = "";
         dynavPerfiles_id.Visible = -1;
         edtUsuariosTelef_Jsonclick = "";
         edtUsuariosNomCompleto_Jsonclick = "";
         edtUsuariosId_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         dynVacantes_Id.FontBold = 0;
         subGrid1_Header = "";
         edtVacantesUsuariosMotD_Visible = -1;
         edtVacantesUsuariosFechaD_Visible = -1;
         dynavPerfiles_id.Enabled = 1;
         subGrid1_Class = "WorkWith";
         subGrid1_Backcolorstyle = 0;
         radavVacantesusuariosestatus_Jsonclick = "";
         edtavNomcompleto_Jsonclick = "";
         edtavNomcompleto_Enabled = 1;
         lblTitletext_Caption = "Postulados";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "wp Candidatos";
         subGrid1_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV8NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'AV23EstatusVacante',fld:'vESTATUSVACANTE',pic:'ZZZ9'},{av:'A283PerfilesUsuariosEstatus',fld:'PERFILESUSUARIOSESTATUS',pic:'9'},{av:'A278Perfiles_Id',fld:'PERFILES_ID',pic:'ZZZZZZZZ9'},{av:'AV13usuariosid',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true},{av:'radavVacantesusuariosestatus'},{av:'AV22VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'radavVacantesusuariosestatus'},{av:'AV22VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'}]}");
         setEventMetadata("VVACANTESUSUARIOSESTATUS.ISVALID","{handler:'E11312',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV8NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'AV23EstatusVacante',fld:'vESTATUSVACANTE',pic:'ZZZ9'},{av:'A283PerfilesUsuariosEstatus',fld:'PERFILESUSUARIOSESTATUS',pic:'9'},{av:'A278Perfiles_Id',fld:'PERFILES_ID',pic:'ZZZZZZZZ9'},{av:'AV13usuariosid',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true},{av:'radavVacantesusuariosestatus'},{av:'AV22VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'}]");
         setEventMetadata("VVACANTESUSUARIOSESTATUS.ISVALID",",oparms:[{av:'lblTitletext_Caption',ctrl:'TITLETEXT',prop:'Caption'},{av:'AV23EstatusVacante',fld:'vESTATUSVACANTE',pic:'ZZZ9'},{av:'radavVacantesusuariosestatus'},{av:'AV22VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1.LOAD","{handler:'E14312',iparms:[{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A290VacantesUsuariosEstatus',fld:'VACANTESUSUARIOSESTATUS',pic:'ZZZ9'},{av:'AV23EstatusVacante',fld:'vESTATUSVACANTE',pic:'ZZZ9'},{av:'dynVacantes_Id'},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'A283PerfilesUsuariosEstatus',fld:'PERFILESUSUARIOSESTATUS',pic:'9'},{av:'A278Perfiles_Id',fld:'PERFILES_ID',pic:'ZZZZZZZZ9'},{av:'AV13usuariosid',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true},{av:'radavVacantesusuariosestatus'},{av:'AV22VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'}]");
         setEventMetadata("GRID1.LOAD",",oparms:[{av:'AV13usuariosid',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true},{av:'dynVacantes_Id'},{av:'edtVacantesUsuariosFechaD_Visible',ctrl:'VACANTESUSUARIOSFECHAD',prop:'Visible'},{av:'edtVacantesUsuariosMotD_Visible',ctrl:'VACANTESUSUARIOSMOTD',prop:'Visible'},{av:'dynavPerfiles_id'},{av:'AV9Perfiles_Id',fld:'vPERFILES_ID',pic:'ZZZZZZZZ9'},{av:'radavVacantesusuariosestatus'},{av:'AV22VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'}]}");
         setEventMetadata("'MUESTRAINFO'","{handler:'E12312',iparms:[{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'radavVacantesusuariosestatus'},{av:'AV22VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'}]");
         setEventMetadata("'MUESTRAINFO'",",oparms:[{av:'radavVacantesusuariosestatus'},{av:'AV22VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV8NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'AV23EstatusVacante',fld:'vESTATUSVACANTE',pic:'ZZZ9'},{av:'A283PerfilesUsuariosEstatus',fld:'PERFILESUSUARIOSESTATUS',pic:'9'},{av:'A278Perfiles_Id',fld:'PERFILES_ID',pic:'ZZZZZZZZ9'},{av:'AV13usuariosid',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true},{av:'radavVacantesusuariosestatus'},{av:'AV22VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[{av:'radavVacantesusuariosestatus'},{av:'AV22VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV8NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'AV23EstatusVacante',fld:'vESTATUSVACANTE',pic:'ZZZ9'},{av:'A283PerfilesUsuariosEstatus',fld:'PERFILESUSUARIOSESTATUS',pic:'9'},{av:'A278Perfiles_Id',fld:'PERFILES_ID',pic:'ZZZZZZZZ9'},{av:'AV13usuariosid',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true},{av:'radavVacantesusuariosestatus'},{av:'AV22VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[{av:'radavVacantesusuariosestatus'},{av:'AV22VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV8NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'AV23EstatusVacante',fld:'vESTATUSVACANTE',pic:'ZZZ9'},{av:'A283PerfilesUsuariosEstatus',fld:'PERFILESUSUARIOSESTATUS',pic:'9'},{av:'A278Perfiles_Id',fld:'PERFILES_ID',pic:'ZZZZZZZZ9'},{av:'AV13usuariosid',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true},{av:'radavVacantesusuariosestatus'},{av:'AV22VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[{av:'radavVacantesusuariosestatus'},{av:'AV22VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV8NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'AV23EstatusVacante',fld:'vESTATUSVACANTE',pic:'ZZZ9'},{av:'A283PerfilesUsuariosEstatus',fld:'PERFILESUSUARIOSESTATUS',pic:'9'},{av:'A278Perfiles_Id',fld:'PERFILES_ID',pic:'ZZZZZZZZ9'},{av:'AV13usuariosid',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true},{av:'radavVacantesusuariosestatus'},{av:'AV22VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[{av:'radavVacantesusuariosestatus'},{av:'AV22VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_USUARIOSID","{handler:'Valid_Usuariosid',iparms:[{av:'radavVacantesusuariosestatus'},{av:'AV22VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'}]");
         setEventMetadata("VALID_USUARIOSID",",oparms:[{av:'radavVacantesusuariosestatus'},{av:'AV22VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_VACANTES_ID","{handler:'Valid_Vacantes_id',iparms:[{av:'radavVacantesusuariosestatus'},{av:'AV22VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'}]");
         setEventMetadata("VALID_VACANTES_ID",",oparms:[{av:'radavVacantesusuariosestatus'},{av:'AV22VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'}]}");
         setEventMetadata("NULL","{handler:'Valid_Vacantesusuariosmotd',iparms:[{av:'radavVacantesusuariosestatus'},{av:'AV22VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'}]");
         setEventMetadata("NULL",",oparms:[{av:'radavVacantesusuariosestatus'},{av:'AV22VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'}]}");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV8NomCompleto = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV18AlertProperties = new SdtPropiedades(context);
         A66UsuariosNombre = "";
         A65UsuariosApPat = "";
         A64UsuariosApMat = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitletext_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         A97UsuariosNomCompleto = "";
         A260UsuariosTelef = "";
         A261UsuariosCorreo = "";
         A288VacantesUsuariosFechaP = (DateTime)(DateTime.MinValue);
         A289VacantesUsuariosFechaD = (DateTime)(DateTime.MinValue);
         A294VacantesUsuariosMotD = "";
         ucUcalertas = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H00312_A284SUBT_ReclutadorId = new int[1] ;
         H00312_A272UsuariosTipo = new short[1] ;
         H00312_n272UsuariosTipo = new bool[] {false} ;
         H00312_A287SUBT_ReclutadorNombre = new String[] {""} ;
         lV8NomCompleto = "";
         H00313_A263Vacantes_Id = new int[1] ;
         H00313_A290VacantesUsuariosEstatus = new short[1] ;
         H00313_n290VacantesUsuariosEstatus = new bool[] {false} ;
         H00313_A11UsuariosId = new int[1] ;
         H00313_A294VacantesUsuariosMotD = new String[] {""} ;
         H00313_n294VacantesUsuariosMotD = new bool[] {false} ;
         H00313_A289VacantesUsuariosFechaD = new DateTime[] {DateTime.MinValue} ;
         H00313_n289VacantesUsuariosFechaD = new bool[] {false} ;
         H00313_A288VacantesUsuariosFechaP = new DateTime[] {DateTime.MinValue} ;
         H00313_A261UsuariosCorreo = new String[] {""} ;
         H00313_A284SUBT_ReclutadorId = new int[1] ;
         H00313_A260UsuariosTelef = new String[] {""} ;
         H00313_A64UsuariosApMat = new String[] {""} ;
         H00313_n64UsuariosApMat = new bool[] {false} ;
         H00313_A65UsuariosApPat = new String[] {""} ;
         H00313_n65UsuariosApPat = new bool[] {false} ;
         H00313_A66UsuariosNombre = new String[] {""} ;
         H00313_n66UsuariosNombre = new bool[] {false} ;
         H00314_A283PerfilesUsuariosEstatus = new short[1] ;
         H00314_A11UsuariosId = new int[1] ;
         H00314_A278Perfiles_Id = new int[1] ;
         Grid1Row = new GXWebRow();
         GXEncryptionTmp = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         GXCCtl = "";
         H00315_A278Perfiles_Id = new int[1] ;
         H00315_A279Perfiles_Nombre = new String[] {""} ;
         H00316_A263Vacantes_Id = new int[1] ;
         H00316_A264Vacantes_Nombre = new String[] {""} ;
         H00317_A278Perfiles_Id = new int[1] ;
         H00317_A279Perfiles_Nombre = new String[] {""} ;
         H00318_A263Vacantes_Id = new int[1] ;
         H00318_A264Vacantes_Nombre = new String[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wppostulacionreclu__default(),
            new Object[][] {
                new Object[] {
               H00312_A284SUBT_ReclutadorId, H00312_A272UsuariosTipo, H00312_n272UsuariosTipo, H00312_A287SUBT_ReclutadorNombre
               }
               , new Object[] {
               H00313_A263Vacantes_Id, H00313_A290VacantesUsuariosEstatus, H00313_n290VacantesUsuariosEstatus, H00313_A11UsuariosId, H00313_A294VacantesUsuariosMotD, H00313_n294VacantesUsuariosMotD, H00313_A289VacantesUsuariosFechaD, H00313_n289VacantesUsuariosFechaD, H00313_A288VacantesUsuariosFechaP, H00313_A261UsuariosCorreo,
               H00313_A284SUBT_ReclutadorId, H00313_A260UsuariosTelef, H00313_A64UsuariosApMat, H00313_A65UsuariosApPat, H00313_A66UsuariosNombre
               }
               , new Object[] {
               H00314_A283PerfilesUsuariosEstatus, H00314_A11UsuariosId, H00314_A278Perfiles_Id
               }
               , new Object[] {
               H00315_A278Perfiles_Id, H00315_A279Perfiles_Nombre
               }
               , new Object[] {
               H00316_A263Vacantes_Id, H00316_A264Vacantes_Nombre
               }
               , new Object[] {
               H00317_A278Perfiles_Id, H00317_A279Perfiles_Nombre
               }
               , new Object[] {
               H00318_A263Vacantes_Id, H00318_A264Vacantes_Nombre
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         dynavPerfiles_id.Enabled = 0;
      }

      private short GRID1_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV23EstatusVacante ;
      private short A283PerfilesUsuariosEstatus ;
      private short AV22VacantesUsuariosEstatus ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short A290VacantesUsuariosEstatus ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_24 ;
      private int nGXsfl_24_idx=1 ;
      private int subGrid1_Rows ;
      private int A278Perfiles_Id ;
      private int AV13usuariosid ;
      private int edtavNomcompleto_Enabled ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int edtVacantesUsuariosFechaD_Visible ;
      private int edtVacantesUsuariosMotD_Visible ;
      private int A11UsuariosId ;
      private int AV9Perfiles_Id ;
      private int A284SUBT_ReclutadorId ;
      private int A263Vacantes_Id ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int gxdynajaxindex ;
      private int subGrid1_Islastpage ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_24_idx="0001" ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String divTable1_Internalname ;
      private String divTable2_Internalname ;
      private String lblTitletext_Internalname ;
      private String lblTitletext_Caption ;
      private String lblTitletext_Jsonclick ;
      private String edtavNomcompleto_Internalname ;
      private String TempTags ;
      private String edtavNomcompleto_Jsonclick ;
      private String radavVacantesusuariosestatus_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String radavVacantesusuariosestatus_Jsonclick ;
      private String sStyleString ;
      private String subGrid1_Internalname ;
      private String subGrid1_Class ;
      private String subGrid1_Linesclass ;
      private String subGrid1_Header ;
      private String A260UsuariosTelef ;
      private String Ucalertas_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtUsuariosId_Internalname ;
      private String edtUsuariosNomCompleto_Internalname ;
      private String edtUsuariosTelef_Internalname ;
      private String dynavPerfiles_id_Internalname ;
      private String dynSUBT_ReclutadorId_Internalname ;
      private String edtUsuariosCorreo_Internalname ;
      private String dynVacantes_Id_Internalname ;
      private String edtVacantesUsuariosFechaP_Internalname ;
      private String edtVacantesUsuariosFechaD_Internalname ;
      private String edtVacantesUsuariosMotD_Internalname ;
      private String gxwrpcisep ;
      private String scmdbuf ;
      private String GXEncryptionTmp ;
      private String sGXsfl_24_fel_idx="0001" ;
      private String ROClassString ;
      private String edtUsuariosId_Jsonclick ;
      private String edtUsuariosNomCompleto_Jsonclick ;
      private String edtUsuariosTelef_Jsonclick ;
      private String GXCCtl ;
      private String dynavPerfiles_id_Jsonclick ;
      private String dynSUBT_ReclutadorId_Jsonclick ;
      private String edtUsuariosCorreo_Jsonclick ;
      private String dynVacantes_Id_Jsonclick ;
      private String edtVacantesUsuariosFechaP_Jsonclick ;
      private String edtVacantesUsuariosFechaD_Jsonclick ;
      private String edtVacantesUsuariosMotD_Jsonclick ;
      private DateTime A288VacantesUsuariosFechaP ;
      private DateTime A289VacantesUsuariosFechaD ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n289VacantesUsuariosFechaD ;
      private bool n294VacantesUsuariosMotD ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_24_Refreshing=false ;
      private bool BRK312 ;
      private bool n290VacantesUsuariosEstatus ;
      private bool n64UsuariosApMat ;
      private bool n65UsuariosApPat ;
      private bool n66UsuariosNombre ;
      private bool returnInSub ;
      private String AV8NomCompleto ;
      private String A66UsuariosNombre ;
      private String A65UsuariosApPat ;
      private String A64UsuariosApMat ;
      private String A97UsuariosNomCompleto ;
      private String A261UsuariosCorreo ;
      private String A294VacantesUsuariosMotD ;
      private String lV8NomCompleto ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXUserControl ucUcalertas ;
      private IGxDataStore dsDefault ;
      private GXRadio radavVacantesusuariosestatus ;
      private GXCombobox dynavPerfiles_id ;
      private GXCombobox dynSUBT_ReclutadorId ;
      private GXCombobox dynVacantes_Id ;
      private IDataStoreProvider pr_default ;
      private int[] H00312_A284SUBT_ReclutadorId ;
      private short[] H00312_A272UsuariosTipo ;
      private bool[] H00312_n272UsuariosTipo ;
      private String[] H00312_A287SUBT_ReclutadorNombre ;
      private int[] H00313_A263Vacantes_Id ;
      private short[] H00313_A290VacantesUsuariosEstatus ;
      private bool[] H00313_n290VacantesUsuariosEstatus ;
      private int[] H00313_A11UsuariosId ;
      private String[] H00313_A294VacantesUsuariosMotD ;
      private bool[] H00313_n294VacantesUsuariosMotD ;
      private DateTime[] H00313_A289VacantesUsuariosFechaD ;
      private bool[] H00313_n289VacantesUsuariosFechaD ;
      private DateTime[] H00313_A288VacantesUsuariosFechaP ;
      private String[] H00313_A261UsuariosCorreo ;
      private int[] H00313_A284SUBT_ReclutadorId ;
      private String[] H00313_A260UsuariosTelef ;
      private String[] H00313_A64UsuariosApMat ;
      private bool[] H00313_n64UsuariosApMat ;
      private String[] H00313_A65UsuariosApPat ;
      private bool[] H00313_n65UsuariosApPat ;
      private String[] H00313_A66UsuariosNombre ;
      private bool[] H00313_n66UsuariosNombre ;
      private short[] H00314_A283PerfilesUsuariosEstatus ;
      private int[] H00314_A11UsuariosId ;
      private int[] H00314_A278Perfiles_Id ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int[] H00315_A278Perfiles_Id ;
      private String[] H00315_A279Perfiles_Nombre ;
      private int[] H00316_A263Vacantes_Id ;
      private String[] H00316_A264Vacantes_Nombre ;
      private int[] H00317_A278Perfiles_Id ;
      private String[] H00317_A279Perfiles_Nombre ;
      private int[] H00318_A263Vacantes_Id ;
      private String[] H00318_A264Vacantes_Nombre ;
      private GXWebForm Form ;
      private SdtPropiedades AV18AlertProperties ;
   }

   public class wppostulacionreclu__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00313( IGxContext context ,
                                             String AV8NomCompleto ,
                                             String A66UsuariosNombre ,
                                             String A65UsuariosApPat ,
                                             String A64UsuariosApMat )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int1 ;
         GXv_int1 = new short [1] ;
         Object[] GXv_Object2 ;
         GXv_Object2 = new Object [2] ;
         scmdbuf = "SELECT T1.`Vacantes_Id`, T1.`VacantesUsuariosEstatus`, T1.`UsuariosId`, T1.`VacantesUsuariosMotD`, T1.`VacantesUsuariosFechaD`, T1.`VacantesUsuariosFechaP`, T2.`UsuariosCorreo`, T1.`SUBT_ReclutadorId` AS SUBT_ReclutadorId, T2.`UsuariosTelef`, T2.`UsuariosApMat`, T2.`UsuariosApPat`, T2.`UsuariosNombre` FROM (`VacantesUsuariosVacante` T1 INNER JOIN `Usuarios` T2 ON T2.`UsuariosId` = T1.`UsuariosId`)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8NomCompleto)) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (CONCAT(CONCAT(CONCAT(CONCAT(RTRIM(LTRIM(T2.`UsuariosNombre`)), ' '), RTRIM(LTRIM(T2.`UsuariosApPat`))), ' '), RTRIM(LTRIM(T2.`UsuariosApMat`))) like ?)";
            }
            else
            {
               sWhereString = sWhereString + " (CONCAT(CONCAT(CONCAT(CONCAT(RTRIM(LTRIM(T2.`UsuariosNombre`)), ' '), RTRIM(LTRIM(T2.`UsuariosApPat`))), ' '), RTRIM(LTRIM(T2.`UsuariosApMat`))) like ?)";
            }
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( StringUtil.StrCmp("", sWhereString) != 0 )
         {
            scmdbuf = scmdbuf + " WHERE" + sWhereString;
         }
         scmdbuf = scmdbuf + " ORDER BY T1.`UsuariosId`";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_H00313(context, (String)dynConstraints[0] , (String)dynConstraints[1] , (String)dynConstraints[2] , (String)dynConstraints[3] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00312 ;
          prmH00312 = new Object[] {
          } ;
          Object[] prmH00314 ;
          prmH00314 = new Object[] {
          new Object[] {"AV13usuariosid",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmH00315 ;
          prmH00315 = new Object[] {
          } ;
          Object[] prmH00316 ;
          prmH00316 = new Object[] {
          } ;
          Object[] prmH00317 ;
          prmH00317 = new Object[] {
          } ;
          Object[] prmH00318 ;
          prmH00318 = new Object[] {
          } ;
          Object[] prmH00313 ;
          prmH00313 = new Object[] {
          new Object[] {"lV8NomCompleto",System.Data.DbType.String,40,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H00312", "SELECT `UsuariosId` AS SUBT_ReclutadorId, `UsuariosTipo`, CONCAT(CONCAT(CONCAT(CONCAT(RTRIM(LTRIM(`UsuariosNombre`)), ' '), RTRIM(LTRIM(`UsuariosApPat`))), ' '), RTRIM(LTRIM(`UsuariosApMat`))) AS SUBT_ReclutadorNombre FROM `Usuarios` WHERE `UsuariosTipo` = 5 ORDER BY `SUBT_ReclutadorNombre` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00312,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00313", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00313,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00314", "SELECT `PerfilesUsuariosEstatus`, `UsuariosId`, `Perfiles_Id` FROM `PerfilesUsuariosPerfil` WHERE (`UsuariosId` = ?) AND (`PerfilesUsuariosEstatus` = 1) ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00314,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00315", "SELECT `Perfiles_Id`, `Perfiles_Nombre` FROM `Perfiles` ORDER BY `Perfiles_Nombre` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00315,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00316", "SELECT `Vacantes_Id`, `Vacantes_Nombre` FROM `Vacantes` ORDER BY `Vacantes_Nombre` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00316,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00317", "SELECT `Perfiles_Id`, `Perfiles_Nombre` FROM `Perfiles` ORDER BY `Perfiles_Nombre` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00317,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00318", "SELECT `Vacantes_Id`, `Vacantes_Nombre` FROM `Vacantes` ORDER BY `Vacantes_Nombre` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00318,0, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((String[]) buf[3])[0] = rslt.getVarchar(3) ;
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3) ;
                ((String[]) buf[4])[0] = rslt.getVarchar(4) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(5) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(6) ;
                ((String[]) buf[9])[0] = rslt.getVarchar(7) ;
                ((int[]) buf[10])[0] = rslt.getInt(8) ;
                ((String[]) buf[11])[0] = rslt.getString(9, 10) ;
                ((String[]) buf[12])[0] = rslt.getVarchar(10) ;
                ((String[]) buf[13])[0] = rslt.getVarchar(11) ;
                ((String[]) buf[14])[0] = rslt.getVarchar(12) ;
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       short sIdx ;
       switch ( cursor )
       {
             case 1 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[1]);
                }
                return;
             case 2 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

}
