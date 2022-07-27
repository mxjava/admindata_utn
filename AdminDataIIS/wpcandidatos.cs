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
   public class wpcandidatos : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpcandidatos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public wpcandidatos( IGxContext context )
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
         dynavUsuarioidrec = new GXCombobox();
         dynavPerfiles_id = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxSuggest"+"_"+"vNOMCOMPLETO") == 0 )
            {
               A97UsuariosNomCompleto = GetNextPar( );
               AssignAttri("", false, "A97UsuariosNomCompleto", A97UsuariosNomCompleto);
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXSGVvNOMCOMPLETO2T0( A97UsuariosNomCompleto) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vUSUARIOIDREC") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvUSUARIOIDREC2T2( ) ;
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
               nRC_GXsfl_23 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_23_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_23_idx = GetNextPar( );
               dynavUsuarioidrec.Enabled = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignProp("", false, dynavUsuarioidrec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavUsuarioidrec.Enabled), 5, 0), !bGXsfl_23_Refreshing);
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
               dynavUsuarioidrec.Enabled = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignProp("", false, dynavUsuarioidrec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavUsuarioidrec.Enabled), 5, 0), !bGXsfl_23_Refreshing);
               AV29Entra = (short)(NumberUtil.Val( GetNextPar( ), "."));
               A263Vacantes_Id = (int)(NumberUtil.Val( GetNextPar( ), "."));
               A284SUBT_ReclutadorId = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV26SessionId = (int)(NumberUtil.Val( GetNextPar( ), "."));
               A286UsuariosStatus = (short)(NumberUtil.Val( GetNextPar( ), "."));
               A97UsuariosNomCompleto = GetNextPar( );
               AV8NomCompleto = GetNextPar( );
               A260UsuariosTelef = GetNextPar( );
               A261UsuariosCorreo = GetNextPar( );
               A105UsuariosCurp = GetNextPar( );
               A11UsuariosId = (int)(NumberUtil.Val( GetNextPar( ), "."));
               A283PerfilesUsuariosEstatus = (short)(NumberUtil.Val( GetNextPar( ), "."));
               A278Perfiles_Id = (int)(NumberUtil.Val( GetNextPar( ), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV29Entra, A263Vacantes_Id, A284SUBT_ReclutadorId, AV26SessionId, A286UsuariosStatus, A97UsuariosNomCompleto, AV8NomCompleto, A260UsuariosTelef, A261UsuariosCorreo, A105UsuariosCurp, A11UsuariosId, A283PerfilesUsuariosEstatus, A278Perfiles_Id) ;
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
         PA2T2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2T2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714345334", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("SweetAlert2/sweetalert2.all.min.js", "", false, true);
         context.AddJavascriptSource("SweetAlert2/SweetAlert2Render.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpcandidatos.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vENTRA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV29Entra), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vSESSIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26SessionId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_23", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_23), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vALERTPROPERTIES", AV18AlertProperties);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vALERTPROPERTIES", AV18AlertProperties);
         }
         GxWebStd.gx_hidden_field( context, "vENTRA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29Entra), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vENTRA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV29Entra), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "VACANTES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A263Vacantes_Id), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SUBT_RECLUTADORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A284SUBT_ReclutadorId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26SessionId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSESSIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26SessionId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "USUARIOSSTATUS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A286UsuariosStatus), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSTELEF", StringUtil.RTrim( A260UsuariosTelef));
         GxWebStd.gx_hidden_field( context, "USUARIOSCORREO", A261UsuariosCorreo);
         GxWebStd.gx_hidden_field( context, "USUARIOSCURP", A105UsuariosCurp);
         GxWebStd.gx_hidden_field( context, "USUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PERFILESUSUARIOSESTATUS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A283PerfilesUsuariosEstatus), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PERFILES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A278Perfiles_Id), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSNOMBRE", A66UsuariosNombre);
         GxWebStd.gx_hidden_field( context, "USUARIOSAPPAT", A65UsuariosApPat);
         GxWebStd.gx_hidden_field( context, "USUARIOSAPMAT", A64UsuariosApMat);
         GxWebStd.gx_hidden_field( context, "USUARIOSNOMCOMPLETO", A97UsuariosNomCompleto);
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vUSUARIOIDREC_Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynavUsuarioidrec.Enabled), 5, 0, ".", "")));
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
            WE2T2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2T2( ) ;
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
         return formatLink("wpcandidatos.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "wpCandidatos" ;
      }

      public override String GetPgmdesc( )
      {
         return "wp Candidatos" ;
      }

      protected void WB2T0( )
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
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, "Activos", "", "", lblTitletext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SubTitle", 0, "", 1, 1, 0, "HLP_wpCandidatos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNomcompleto_Internalname, "Nom Completo", "col-sm-3 FilterSearchAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'" + sGXsfl_23_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNomcompleto_Internalname, AV8NomCompleto, StringUtil.RTrim( context.localUtil.Format( AV8NomCompleto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,15);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Nombre", edtavNomcompleto_Jsonclick, 0, "FilterSearchAttribute", "", "", "", "", 1, edtavNomcompleto_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, 0, 0, true, "", "left", true, "", "HLP_wpCandidatos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-3", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "BtnAdd";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttAgregar_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(23), 2, 0)+","+"null"+");", "Agregar", bttAgregar_Jsonclick, 5, "Agregar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'AGREGAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_wpCandidatos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"23\">") ;
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
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "CURP") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((dynavUsuarioidrec.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Reclutador") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Nombre Candidato") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Teléfono") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Correo electrónico") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Perfil") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Image"+"\" "+" style=\""+((edtavVacantes_nombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Cargar Vacante") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Grid1Container.AddObjectProperty("GridName", "Grid1");
            }
            else
            {
               Grid1Container.AddObjectProperty("GridName", "Grid1");
               Grid1Container.AddObjectProperty("Header", subGrid1_Header);
               Grid1Container.AddObjectProperty("Class", "WorkWith");
               Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("CmpContext", "");
               Grid1Container.AddObjectProperty("InMasterPage", "false");
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13usuariosid), 6, 0, ".", "")));
               Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsuariosid_Enabled), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", AV12usuarioscurp);
               Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsuarioscurp_Enabled), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10usuarioidRec), 6, 0, ".", "")));
               Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynavUsuarioidrec.Visible), 5, 0, ".", "")));
               Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynavUsuarioidrec.Enabled), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", AV7NombreCompleto);
               Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNombrecompleto_Enabled), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( AV14UsuariosTelef));
               Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsuariostelef_Enabled), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", AV11UsuariosCorreo);
               Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsuarioscorreo_Enabled), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9Perfiles_Id), 9, 0, ".", "")));
               Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynavPerfiles_id.Enabled), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( AV28vacantes_nombre));
               Grid1Column.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavVacantes_nombre_Tooltiptext));
               Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantes_nombre_Visible), 5, 0, ".", "")));
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
         if ( wbEnd == 23 )
         {
            wbEnd = 0;
            nRC_GXsfl_23 = (int)(nGXsfl_23_idx-1);
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
         if ( wbEnd == 23 )
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

      protected void START2T2( )
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
         STRUP2T0( ) ;
      }

      protected void WS2T2( )
      {
         START2T2( ) ;
         EVT2T2( ) ;
      }

      protected void EVT2T2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'AGREGAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Agregar' */
                              E112T2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "VVACANTES_NOMBRE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "VVACANTES_NOMBRE.CLICK") == 0 ) )
                           {
                              nGXsfl_23_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
                              SubsflControlProps_232( ) ;
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavUsuariosid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsuariosid_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vUSUARIOSID");
                                 GX_FocusControl = edtavUsuariosid_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV13usuariosid = 0;
                                 AssignAttri("", false, edtavUsuariosid_Internalname, StringUtil.LTrimStr( (decimal)(AV13usuariosid), 6, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID"+"_"+sGXsfl_23_idx, GetSecureSignedToken( sGXsfl_23_idx, context.localUtil.Format( (decimal)(AV13usuariosid), "ZZZZZ9"), context));
                              }
                              else
                              {
                                 AV13usuariosid = (int)(context.localUtil.CToN( cgiGet( edtavUsuariosid_Internalname), ",", "."));
                                 AssignAttri("", false, edtavUsuariosid_Internalname, StringUtil.LTrimStr( (decimal)(AV13usuariosid), 6, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID"+"_"+sGXsfl_23_idx, GetSecureSignedToken( sGXsfl_23_idx, context.localUtil.Format( (decimal)(AV13usuariosid), "ZZZZZ9"), context));
                              }
                              AV12usuarioscurp = StringUtil.Upper( cgiGet( edtavUsuarioscurp_Internalname));
                              AssignAttri("", false, edtavUsuarioscurp_Internalname, AV12usuarioscurp);
                              GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSCURP"+"_"+sGXsfl_23_idx, GetSecureSignedToken( sGXsfl_23_idx, StringUtil.RTrim( context.localUtil.Format( AV12usuarioscurp, "@!")), context));
                              dynavUsuarioidrec.Name = dynavUsuarioidrec_Internalname;
                              dynavUsuarioidrec.CurrentValue = cgiGet( dynavUsuarioidrec_Internalname);
                              AV10usuarioidRec = (int)(NumberUtil.Val( cgiGet( dynavUsuarioidrec_Internalname), "."));
                              AssignAttri("", false, dynavUsuarioidrec_Internalname, StringUtil.LTrimStr( (decimal)(AV10usuarioidRec), 6, 0));
                              AV7NombreCompleto = cgiGet( edtavNombrecompleto_Internalname);
                              AssignAttri("", false, edtavNombrecompleto_Internalname, AV7NombreCompleto);
                              AV14UsuariosTelef = cgiGet( edtavUsuariostelef_Internalname);
                              AssignAttri("", false, edtavUsuariostelef_Internalname, AV14UsuariosTelef);
                              AV11UsuariosCorreo = cgiGet( edtavUsuarioscorreo_Internalname);
                              AssignAttri("", false, edtavUsuarioscorreo_Internalname, AV11UsuariosCorreo);
                              dynavPerfiles_id.Name = dynavPerfiles_id_Internalname;
                              dynavPerfiles_id.CurrentValue = cgiGet( dynavPerfiles_id_Internalname);
                              AV9Perfiles_Id = (int)(NumberUtil.Val( cgiGet( dynavPerfiles_id_Internalname), "."));
                              AssignAttri("", false, dynavPerfiles_id_Internalname, StringUtil.LTrimStr( (decimal)(AV9Perfiles_Id), 9, 0));
                              AV28vacantes_nombre = cgiGet( edtavVacantes_nombre_Internalname);
                              AssignProp("", false, edtavVacantes_nombre_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV28vacantes_nombre)) ? AV36Vacantes_nombre_GXI : context.convertURL( context.PathToRelativeUrl( AV28vacantes_nombre))), !bGXsfl_23_Refreshing);
                              AssignProp("", false, edtavVacantes_nombre_Internalname, "SrcSet", context.GetImageSrcSet( AV28vacantes_nombre), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E122T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E132T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VVACANTES_NOMBRE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E142T2 ();
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

      protected void WE2T2( )
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

      protected void PA2T2( )
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

      protected void GXSGVvNOMCOMPLETO2T0( String A97UsuariosNomCompleto )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXSGVvNOMCOMPLETO_data2T0( A97UsuariosNomCompleto) ;
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

      protected void GXSGVvNOMCOMPLETO_data2T0( String A97UsuariosNomCompleto )
      {
         l97UsuariosNomCompleto = StringUtil.Concat( StringUtil.RTrim( A97UsuariosNomCompleto), "%", "");
         /* Using cursor H002T2 */
         pr_default.execute(0, new Object[] {l97UsuariosNomCompleto});
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(H002T2_A97UsuariosNomCompleto[0]);
            gxdynajaxctrldescr.Add(H002T2_A97UsuariosNomCompleto[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvUSUARIOIDREC2T2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvUSUARIOIDREC_data2T2( ) ;
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

      protected void GXVvUSUARIOIDREC_html2T2( )
      {
         int gxdynajaxvalue ;
         GXDLVvUSUARIOIDREC_data2T2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavUsuarioidrec.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((String)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavUsuarioidrec.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((String)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvUSUARIOIDREC_data2T2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("Seleccione");
         /* Using cursor H002T3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002T3_A11UsuariosId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002T3_A97UsuariosNomCompleto[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_232( ) ;
         while ( nGXsfl_23_idx <= nRC_GXsfl_23 )
         {
            sendrow_232( ) ;
            nGXsfl_23_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_23_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_23_idx+1);
            sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
            SubsflControlProps_232( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        short AV29Entra ,
                                        int A263Vacantes_Id ,
                                        int A284SUBT_ReclutadorId ,
                                        int AV26SessionId ,
                                        short A286UsuariosStatus ,
                                        String A97UsuariosNomCompleto ,
                                        String AV8NomCompleto ,
                                        String A260UsuariosTelef ,
                                        String A261UsuariosCorreo ,
                                        String A105UsuariosCurp ,
                                        int A11UsuariosId ,
                                        short A283PerfilesUsuariosEstatus ,
                                        int A278Perfiles_Id )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF2T2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13usuariosid), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13usuariosid), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSCURP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12usuarioscurp, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSCURP", AV12usuarioscurp);
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
         RF2T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavUsuariosid_Enabled = 0;
         AssignProp("", false, edtavUsuariosid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuariosid_Enabled), 5, 0), !bGXsfl_23_Refreshing);
         edtavUsuarioscurp_Enabled = 0;
         AssignProp("", false, edtavUsuarioscurp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuarioscurp_Enabled), 5, 0), !bGXsfl_23_Refreshing);
         dynavUsuarioidrec.Enabled = 0;
         AssignProp("", false, dynavUsuarioidrec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavUsuarioidrec.Enabled), 5, 0), !bGXsfl_23_Refreshing);
         edtavNombrecompleto_Enabled = 0;
         AssignProp("", false, edtavNombrecompleto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNombrecompleto_Enabled), 5, 0), !bGXsfl_23_Refreshing);
         edtavUsuariostelef_Enabled = 0;
         AssignProp("", false, edtavUsuariostelef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuariostelef_Enabled), 5, 0), !bGXsfl_23_Refreshing);
         edtavUsuarioscorreo_Enabled = 0;
         AssignProp("", false, edtavUsuarioscorreo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuarioscorreo_Enabled), 5, 0), !bGXsfl_23_Refreshing);
      }

      protected void RF2T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 23;
         nGXsfl_23_idx = 1;
         sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
         SubsflControlProps_232( ) ;
         bGXsfl_23_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "WorkWith");
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
            SubsflControlProps_232( ) ;
            E132T2 ();
            if ( ( GRID1_nCurrentRecord > 0 ) && ( GRID1_nGridOutOfScope == 0 ) && ( nGXsfl_23_idx == 1 ) )
            {
               GRID1_nCurrentRecord = 0;
               GRID1_nGridOutOfScope = 1;
               subgrid1_firstpage( ) ;
               E132T2 ();
            }
            wbEnd = 23;
            WB2T0( ) ;
         }
         bGXsfl_23_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2T2( )
      {
         GxWebStd.gx_hidden_field( context, "vENTRA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29Entra), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vENTRA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV29Entra), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26SessionId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSESSIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26SessionId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID"+"_"+sGXsfl_23_idx, GetSecureSignedToken( sGXsfl_23_idx, context.localUtil.Format( (decimal)(AV13usuariosid), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSCURP"+"_"+sGXsfl_23_idx, GetSecureSignedToken( sGXsfl_23_idx, StringUtil.RTrim( context.localUtil.Format( AV12usuarioscurp, "@!")), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         return (int)(((subGrid1_Recordcount==0) ? GRID1_nFirstRecordOnPage+1 : subGrid1_Recordcount)) ;
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
         return (int)(((subGrid1_Islastpage==1) ? subGrid1_fnc_Recordcount( )/ (decimal)(subGrid1_fnc_Recordsperpage( ))+((((int)((subGrid1_fnc_Recordcount( )) % (subGrid1_fnc_Recordsperpage( ))))==0) ? 0 : 1) : (decimal)(NumberUtil.Int( (long)(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1))) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV29Entra, A263Vacantes_Id, A284SUBT_ReclutadorId, AV26SessionId, A286UsuariosStatus, A97UsuariosNomCompleto, AV8NomCompleto, A260UsuariosTelef, A261UsuariosCorreo, A105UsuariosCurp, A11UsuariosId, A283PerfilesUsuariosEstatus, A278Perfiles_Id) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV29Entra, A263Vacantes_Id, A284SUBT_ReclutadorId, AV26SessionId, A286UsuariosStatus, A97UsuariosNomCompleto, AV8NomCompleto, A260UsuariosTelef, A261UsuariosCorreo, A105UsuariosCurp, A11UsuariosId, A283PerfilesUsuariosEstatus, A278Perfiles_Id) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV29Entra, A263Vacantes_Id, A284SUBT_ReclutadorId, AV26SessionId, A286UsuariosStatus, A97UsuariosNomCompleto, AV8NomCompleto, A260UsuariosTelef, A261UsuariosCorreo, A105UsuariosCurp, A11UsuariosId, A283PerfilesUsuariosEstatus, A278Perfiles_Id) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         subGrid1_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV29Entra, A263Vacantes_Id, A284SUBT_ReclutadorId, AV26SessionId, A286UsuariosStatus, A97UsuariosNomCompleto, AV8NomCompleto, A260UsuariosTelef, A261UsuariosCorreo, A105UsuariosCurp, A11UsuariosId, A283PerfilesUsuariosEstatus, A278Perfiles_Id) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV29Entra, A263Vacantes_Id, A284SUBT_ReclutadorId, AV26SessionId, A286UsuariosStatus, A97UsuariosNomCompleto, AV8NomCompleto, A260UsuariosTelef, A261UsuariosCorreo, A105UsuariosCurp, A11UsuariosId, A283PerfilesUsuariosEstatus, A278Perfiles_Id) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavUsuariosid_Enabled = 0;
         AssignProp("", false, edtavUsuariosid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuariosid_Enabled), 5, 0), !bGXsfl_23_Refreshing);
         edtavUsuarioscurp_Enabled = 0;
         AssignProp("", false, edtavUsuarioscurp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuarioscurp_Enabled), 5, 0), !bGXsfl_23_Refreshing);
         dynavUsuarioidrec.Enabled = 0;
         AssignProp("", false, dynavUsuarioidrec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavUsuarioidrec.Enabled), 5, 0), !bGXsfl_23_Refreshing);
         edtavNombrecompleto_Enabled = 0;
         AssignProp("", false, edtavNombrecompleto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNombrecompleto_Enabled), 5, 0), !bGXsfl_23_Refreshing);
         edtavUsuariostelef_Enabled = 0;
         AssignProp("", false, edtavUsuariostelef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuariostelef_Enabled), 5, 0), !bGXsfl_23_Refreshing);
         edtavUsuarioscorreo_Enabled = 0;
         AssignProp("", false, edtavUsuarioscorreo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuarioscorreo_Enabled), 5, 0), !bGXsfl_23_Refreshing);
         GXVvUSUARIOIDREC_html2T2( ) ;
      }

      protected void STRUP2T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E122T2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vALERTPROPERTIES"), AV18AlertProperties);
            /* Read saved values. */
            nRC_GXsfl_23 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_23"), ",", "."));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ",", "."));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ",", "."));
            subGrid1_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID1_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV8NomCompleto = cgiGet( edtavNomcompleto_Internalname);
            AssignAttri("", false, "AV8NomCompleto", AV8NomCompleto);
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
         E122T2 ();
         if (returnInSub) return;
      }

      protected void E122T2( )
      {
         /* Start Routine */
         dynavUsuarioidrec.Enabled = 1;
         AssignProp("", false, dynavUsuarioidrec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavUsuarioidrec.Enabled), 5, 0), !bGXsfl_23_Refreshing);
         AV26SessionId = (int)(NumberUtil.Val( AV25Websession.Get("UsuarioId"), "."));
         AssignAttri("", false, "AV26SessionId", StringUtil.LTrimStr( (decimal)(AV26SessionId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vSESSIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26SessionId), "ZZZZZZZZ9"), context));
         AV32GXLvl8 = 0;
         /* Using cursor H002T4 */
         pr_default.execute(2, new Object[] {AV26SessionId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A272UsuariosTipo = H002T4_A272UsuariosTipo[0];
            A11UsuariosId = H002T4_A11UsuariosId[0];
            AV32GXLvl8 = 1;
            AV29Entra = 1;
            AssignAttri("", false, "AV29Entra", StringUtil.LTrimStr( (decimal)(AV29Entra), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vENTRA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV29Entra), "ZZZ9"), context));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         if ( AV32GXLvl8 == 0 )
         {
            AV29Entra = 0;
            AssignAttri("", false, "AV29Entra", StringUtil.LTrimStr( (decimal)(AV29Entra), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vENTRA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV29Entra), "ZZZ9"), context));
         }
         subGrid1_Rows = 20;
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         AV17Asignar = "Asignar";
      }

      private void E132T2( )
      {
         /* Grid1_Load Routine */
         if ( AV29Entra == 1 )
         {
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV8NomCompleto ,
                                                 A66UsuariosNombre ,
                                                 A65UsuariosApPat ,
                                                 A64UsuariosApMat ,
                                                 A286UsuariosStatus ,
                                                 AV26SessionId ,
                                                 A263Vacantes_Id ,
                                                 A284SUBT_ReclutadorId } ,
                                                 new int[]{
                                                 TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                                 }
            } ) ;
            lV8NomCompleto = StringUtil.Concat( StringUtil.RTrim( AV8NomCompleto), "%", "");
            /* Using cursor H002T5 */
            pr_default.execute(3, new Object[] {AV26SessionId, lV8NomCompleto});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A272UsuariosTipo = H002T5_A272UsuariosTipo[0];
               A286UsuariosStatus = H002T5_A286UsuariosStatus[0];
               A284SUBT_ReclutadorId = H002T5_A284SUBT_ReclutadorId[0];
               A263Vacantes_Id = H002T5_A263Vacantes_Id[0];
               A260UsuariosTelef = H002T5_A260UsuariosTelef[0];
               A261UsuariosCorreo = H002T5_A261UsuariosCorreo[0];
               A105UsuariosCurp = H002T5_A105UsuariosCurp[0];
               A11UsuariosId = H002T5_A11UsuariosId[0];
               A64UsuariosApMat = H002T5_A64UsuariosApMat[0];
               A65UsuariosApPat = H002T5_A65UsuariosApPat[0];
               A66UsuariosNombre = H002T5_A66UsuariosNombre[0];
               A272UsuariosTipo = H002T5_A272UsuariosTipo[0];
               A286UsuariosStatus = H002T5_A286UsuariosStatus[0];
               A260UsuariosTelef = H002T5_A260UsuariosTelef[0];
               A261UsuariosCorreo = H002T5_A261UsuariosCorreo[0];
               A105UsuariosCurp = H002T5_A105UsuariosCurp[0];
               A64UsuariosApMat = H002T5_A64UsuariosApMat[0];
               A65UsuariosApPat = H002T5_A65UsuariosApPat[0];
               A66UsuariosNombre = H002T5_A66UsuariosNombre[0];
               A97UsuariosNomCompleto = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + StringUtil.Trim( A64UsuariosApMat);
               AssignAttri("", false, "A97UsuariosNomCompleto", A97UsuariosNomCompleto);
               AV7NombreCompleto = A97UsuariosNomCompleto;
               AssignAttri("", false, edtavNombrecompleto_Internalname, AV7NombreCompleto);
               AV14UsuariosTelef = A260UsuariosTelef;
               AssignAttri("", false, edtavUsuariostelef_Internalname, AV14UsuariosTelef);
               AV11UsuariosCorreo = A261UsuariosCorreo;
               AssignAttri("", false, edtavUsuarioscorreo_Internalname, AV11UsuariosCorreo);
               AV12usuarioscurp = A105UsuariosCurp;
               AssignAttri("", false, edtavUsuarioscurp_Internalname, AV12usuarioscurp);
               GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSCURP"+"_"+sGXsfl_23_idx, GetSecureSignedToken( sGXsfl_23_idx, StringUtil.RTrim( context.localUtil.Format( AV12usuarioscurp, "@!")), context));
               AV13usuariosid = A11UsuariosId;
               AssignAttri("", false, edtavUsuariosid_Internalname, StringUtil.LTrimStr( (decimal)(AV13usuariosid), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID"+"_"+sGXsfl_23_idx, GetSecureSignedToken( sGXsfl_23_idx, context.localUtil.Format( (decimal)(AV13usuariosid), "ZZZZZ9"), context));
               AV10usuarioidRec = A284SUBT_ReclutadorId;
               AssignAttri("", false, dynavUsuarioidrec_Internalname, StringUtil.LTrimStr( (decimal)(AV10usuarioidRec), 6, 0));
               AV13usuariosid = A11UsuariosId;
               AssignAttri("", false, edtavUsuariosid_Internalname, StringUtil.LTrimStr( (decimal)(AV13usuariosid), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID"+"_"+sGXsfl_23_idx, GetSecureSignedToken( sGXsfl_23_idx, context.localUtil.Format( (decimal)(AV13usuariosid), "ZZZZZ9"), context));
               dynavUsuarioidrec.Visible = 0;
               AV23candidato = context.GetImagePath( "f0c58b9a-8eac-4404-af1d-7510bfaa3bb6", "", context.GetTheme( ));
               AV34Candidato_GXI = GXDbFile.PathToUrl( context.GetImagePath( "f0c58b9a-8eac-4404-af1d-7510bfaa3bb6", "", context.GetTheme( )));
               AV35GXLvl42 = 0;
               /* Using cursor H002T6 */
               pr_default.execute(4, new Object[] {AV13usuariosid});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A283PerfilesUsuariosEstatus = H002T6_A283PerfilesUsuariosEstatus[0];
                  A11UsuariosId = H002T6_A11UsuariosId[0];
                  A278Perfiles_Id = H002T6_A278Perfiles_Id[0];
                  AV35GXLvl42 = 1;
                  AV9Perfiles_Id = A278Perfiles_Id;
                  AssignAttri("", false, dynavPerfiles_id_Internalname, StringUtil.LTrimStr( (decimal)(AV9Perfiles_Id), 9, 0));
                  dynavPerfiles_id.Enabled = 0;
                  pr_default.readNext(4);
               }
               pr_default.close(4);
               if ( AV35GXLvl42 == 0 )
               {
                  AV9Perfiles_Id = 99999999;
                  AssignAttri("", false, dynavPerfiles_id_Internalname, StringUtil.LTrimStr( (decimal)(AV9Perfiles_Id), 9, 0));
                  dynavPerfiles_id.Enabled = 1;
               }
               AV28vacantes_nombre = context.GetImagePath( "0dfc0695-4303-49b8-9574-47012efbd14a", "", context.GetTheme( ));
               AssignAttri("", false, edtavVacantes_nombre_Internalname, AV28vacantes_nombre);
               AV36Vacantes_nombre_GXI = GXDbFile.PathToUrl( context.GetImagePath( "0dfc0695-4303-49b8-9574-47012efbd14a", "", context.GetTheme( )));
               edtavVacantes_nombre_Tooltiptext = "Registrar vacante";
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 23;
               }
               if ( ( subGrid1_Islastpage == 1 ) || ( subGrid1_Rows == 0 ) || ( ( GRID1_nCurrentRecord >= GRID1_nFirstRecordOnPage ) && ( GRID1_nCurrentRecord < GRID1_nFirstRecordOnPage + subGrid1_fnc_Recordsperpage( ) ) ) )
               {
                  sendrow_232( ) ;
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
               if ( isFullAjaxMode( ) && ! bGXsfl_23_Refreshing )
               {
                  context.DoAjaxLoad(23, Grid1Row);
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
         }
         else
         {
            pr_default.dynParam(5, new Object[]{ new Object[]{
                                                 AV8NomCompleto ,
                                                 A66UsuariosNombre ,
                                                 A65UsuariosApPat ,
                                                 A64UsuariosApMat ,
                                                 A286UsuariosStatus ,
                                                 A263Vacantes_Id } ,
                                                 new int[]{
                                                 TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.SHORT, TypeConstants.INT
                                                 }
            } ) ;
            lV8NomCompleto = StringUtil.Concat( StringUtil.RTrim( AV8NomCompleto), "%", "");
            /* Using cursor H002T7 */
            pr_default.execute(5, new Object[] {lV8NomCompleto});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A272UsuariosTipo = H002T7_A272UsuariosTipo[0];
               A286UsuariosStatus = H002T7_A286UsuariosStatus[0];
               A263Vacantes_Id = H002T7_A263Vacantes_Id[0];
               A260UsuariosTelef = H002T7_A260UsuariosTelef[0];
               A261UsuariosCorreo = H002T7_A261UsuariosCorreo[0];
               A105UsuariosCurp = H002T7_A105UsuariosCurp[0];
               A11UsuariosId = H002T7_A11UsuariosId[0];
               A284SUBT_ReclutadorId = H002T7_A284SUBT_ReclutadorId[0];
               A64UsuariosApMat = H002T7_A64UsuariosApMat[0];
               A65UsuariosApPat = H002T7_A65UsuariosApPat[0];
               A66UsuariosNombre = H002T7_A66UsuariosNombre[0];
               A272UsuariosTipo = H002T7_A272UsuariosTipo[0];
               A286UsuariosStatus = H002T7_A286UsuariosStatus[0];
               A260UsuariosTelef = H002T7_A260UsuariosTelef[0];
               A261UsuariosCorreo = H002T7_A261UsuariosCorreo[0];
               A105UsuariosCurp = H002T7_A105UsuariosCurp[0];
               A64UsuariosApMat = H002T7_A64UsuariosApMat[0];
               A65UsuariosApPat = H002T7_A65UsuariosApPat[0];
               A66UsuariosNombre = H002T7_A66UsuariosNombre[0];
               A97UsuariosNomCompleto = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + StringUtil.Trim( A64UsuariosApMat);
               AssignAttri("", false, "A97UsuariosNomCompleto", A97UsuariosNomCompleto);
               AV7NombreCompleto = A97UsuariosNomCompleto;
               AssignAttri("", false, edtavNombrecompleto_Internalname, AV7NombreCompleto);
               AV14UsuariosTelef = A260UsuariosTelef;
               AssignAttri("", false, edtavUsuariostelef_Internalname, AV14UsuariosTelef);
               AV11UsuariosCorreo = A261UsuariosCorreo;
               AssignAttri("", false, edtavUsuarioscorreo_Internalname, AV11UsuariosCorreo);
               AV12usuarioscurp = A105UsuariosCurp;
               AssignAttri("", false, edtavUsuarioscurp_Internalname, AV12usuarioscurp);
               GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSCURP"+"_"+sGXsfl_23_idx, GetSecureSignedToken( sGXsfl_23_idx, StringUtil.RTrim( context.localUtil.Format( AV12usuarioscurp, "@!")), context));
               AV13usuariosid = A11UsuariosId;
               AssignAttri("", false, edtavUsuariosid_Internalname, StringUtil.LTrimStr( (decimal)(AV13usuariosid), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID"+"_"+sGXsfl_23_idx, GetSecureSignedToken( sGXsfl_23_idx, context.localUtil.Format( (decimal)(AV13usuariosid), "ZZZZZ9"), context));
               AV10usuarioidRec = A284SUBT_ReclutadorId;
               AssignAttri("", false, dynavUsuarioidrec_Internalname, StringUtil.LTrimStr( (decimal)(AV10usuarioidRec), 6, 0));
               AV13usuariosid = A11UsuariosId;
               AssignAttri("", false, edtavUsuariosid_Internalname, StringUtil.LTrimStr( (decimal)(AV13usuariosid), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID"+"_"+sGXsfl_23_idx, GetSecureSignedToken( sGXsfl_23_idx, context.localUtil.Format( (decimal)(AV13usuariosid), "ZZZZZ9"), context));
               AV23candidato = context.GetImagePath( "f0c58b9a-8eac-4404-af1d-7510bfaa3bb6", "", context.GetTheme( ));
               AV34Candidato_GXI = GXDbFile.PathToUrl( context.GetImagePath( "f0c58b9a-8eac-4404-af1d-7510bfaa3bb6", "", context.GetTheme( )));
               AV38GXLvl76 = 0;
               /* Using cursor H002T8 */
               pr_default.execute(6, new Object[] {AV13usuariosid});
               while ( (pr_default.getStatus(6) != 101) )
               {
                  A283PerfilesUsuariosEstatus = H002T8_A283PerfilesUsuariosEstatus[0];
                  A11UsuariosId = H002T8_A11UsuariosId[0];
                  A278Perfiles_Id = H002T8_A278Perfiles_Id[0];
                  AV38GXLvl76 = 1;
                  AV9Perfiles_Id = A278Perfiles_Id;
                  AssignAttri("", false, dynavPerfiles_id_Internalname, StringUtil.LTrimStr( (decimal)(AV9Perfiles_Id), 9, 0));
                  dynavPerfiles_id.Enabled = 0;
                  pr_default.readNext(6);
               }
               pr_default.close(6);
               if ( AV38GXLvl76 == 0 )
               {
                  AV9Perfiles_Id = 99999999;
                  AssignAttri("", false, dynavPerfiles_id_Internalname, StringUtil.LTrimStr( (decimal)(AV9Perfiles_Id), 9, 0));
                  dynavPerfiles_id.Enabled = 0;
               }
               edtavVacantes_nombre_Visible = 0;
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 23;
               }
               if ( ( subGrid1_Islastpage == 1 ) || ( subGrid1_Rows == 0 ) || ( ( GRID1_nCurrentRecord >= GRID1_nFirstRecordOnPage ) && ( GRID1_nCurrentRecord < GRID1_nFirstRecordOnPage + subGrid1_fnc_Recordsperpage( ) ) ) )
               {
                  sendrow_232( ) ;
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
               if ( isFullAjaxMode( ) && ! bGXsfl_23_Refreshing )
               {
                  context.DoAjaxLoad(23, Grid1Row);
               }
               pr_default.readNext(5);
            }
            pr_default.close(5);
         }
         /*  Sending Event outputs  */
         dynavUsuarioidrec.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10usuarioidRec), 6, 0));
         dynavPerfiles_id.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9Perfiles_Id), 9, 0));
      }

      protected void E142T2( )
      {
         /* Vacantes_nombre_Click Routine */
         if ( AV9Perfiles_Id == 99999999 )
         {
            GXt_SdtPropiedades1 = AV18AlertProperties;
            new getsweetmessage(context ).execute(  "error",  "Seleccione un Perfil",  "",  true,  false, out  GXt_SdtPropiedades1) ;
            AV18AlertProperties = GXt_SdtPropiedades1;
            this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
         }
         else
         {
            new pr_guardaperfilusuario(context ).execute(  AV13usuariosid,  AV9Perfiles_Id,  "Personal") ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wpselvacante.aspx"+UrlEncode("" +AV13usuariosid) + "," + UrlEncode(StringUtil.RTrim(AV12usuarioscurp)) + "," + UrlEncode("" +AV26SessionId);
            CallWebObject(formatLink("wpselvacante.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18AlertProperties", AV18AlertProperties);
      }

      protected void E112T2( )
      {
         /* 'Agregar' Routine */
         if ( AV29Entra == 1 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wpaltausuariosadm.aspx"+UrlEncode(StringUtil.RTrim("Candidato")) + "," + UrlEncode("" +0);
            CallWebObject(formatLink("wpaltausuariosadm.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wpaltausuariosadm.aspx"+UrlEncode(StringUtil.RTrim("Postulante")) + "," + UrlEncode("" +0);
            CallWebObject(formatLink("wpaltausuariosadm.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
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
         PA2T2( ) ;
         WS2T2( ) ;
         WE2T2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714345390", true, true);
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
            context.AddJavascriptSource("wpcandidatos.js", "?202262714345390", false, true);
            context.AddJavascriptSource("SweetAlert2/sweetalert2.all.min.js", "", false, true);
            context.AddJavascriptSource("SweetAlert2/SweetAlert2Render.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_232( )
      {
         edtavUsuariosid_Internalname = "vUSUARIOSID_"+sGXsfl_23_idx;
         edtavUsuarioscurp_Internalname = "vUSUARIOSCURP_"+sGXsfl_23_idx;
         dynavUsuarioidrec_Internalname = "vUSUARIOIDREC_"+sGXsfl_23_idx;
         edtavNombrecompleto_Internalname = "vNOMBRECOMPLETO_"+sGXsfl_23_idx;
         edtavUsuariostelef_Internalname = "vUSUARIOSTELEF_"+sGXsfl_23_idx;
         edtavUsuarioscorreo_Internalname = "vUSUARIOSCORREO_"+sGXsfl_23_idx;
         dynavPerfiles_id_Internalname = "vPERFILES_ID_"+sGXsfl_23_idx;
         edtavVacantes_nombre_Internalname = "vVACANTES_NOMBRE_"+sGXsfl_23_idx;
      }

      protected void SubsflControlProps_fel_232( )
      {
         edtavUsuariosid_Internalname = "vUSUARIOSID_"+sGXsfl_23_fel_idx;
         edtavUsuarioscurp_Internalname = "vUSUARIOSCURP_"+sGXsfl_23_fel_idx;
         dynavUsuarioidrec_Internalname = "vUSUARIOIDREC_"+sGXsfl_23_fel_idx;
         edtavNombrecompleto_Internalname = "vNOMBRECOMPLETO_"+sGXsfl_23_fel_idx;
         edtavUsuariostelef_Internalname = "vUSUARIOSTELEF_"+sGXsfl_23_fel_idx;
         edtavUsuarioscorreo_Internalname = "vUSUARIOSCORREO_"+sGXsfl_23_fel_idx;
         dynavPerfiles_id_Internalname = "vPERFILES_ID_"+sGXsfl_23_fel_idx;
         edtavVacantes_nombre_Internalname = "vVACANTES_NOMBRE_"+sGXsfl_23_fel_idx;
      }

      protected void sendrow_232( )
      {
         SubsflControlProps_232( ) ;
         WB2T0( ) ;
         if ( ( subGrid1_Rows * 1 == 0 ) || ( nGXsfl_23_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_23_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_23_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavUsuariosid_Enabled!=0)&&(edtavUsuariosid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 24,'',false,'"+sGXsfl_23_idx+"',23)\"" : " ");
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavUsuariosid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13usuariosid), 6, 0, ",", "")),((edtavUsuariosid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV13usuariosid), "ZZZZZ9")) : context.localUtil.Format( (decimal)(AV13usuariosid), "ZZZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+((edtavUsuariosid_Enabled!=0)&&(edtavUsuariosid_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,24);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavUsuariosid_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)0,(int)edtavUsuariosid_Enabled,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)6,(short)0,(short)0,(short)23,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavUsuarioscurp_Enabled!=0)&&(edtavUsuarioscurp_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 25,'',false,'"+sGXsfl_23_idx+"',23)\"" : " ");
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavUsuarioscurp_Internalname,(String)AV12usuarioscurp,StringUtil.RTrim( context.localUtil.Format( AV12usuarioscurp, "@!")),TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+((edtavUsuarioscurp_Enabled!=0)&&(edtavUsuarioscurp_Visible!=0) ? " onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,25);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavUsuarioscurp_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)0,(int)edtavUsuarioscurp_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)18,(short)0,(short)0,(short)23,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            GXVvUSUARIOIDREC_html2T2( ) ;
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((dynavUsuarioidrec.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            TempTags = " " + ((dynavUsuarioidrec.Enabled!=0)&&(dynavUsuarioidrec.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 26,'',false,'"+sGXsfl_23_idx+"',23)\"" : " ");
            GXCCtl = "vUSUARIOIDREC_" + sGXsfl_23_idx;
            dynavUsuarioidrec.Name = GXCCtl;
            dynavUsuarioidrec.WebTags = "";
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynavUsuarioidrec,(String)dynavUsuarioidrec_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV10usuarioidRec), 6, 0)),(short)1,(String)dynavUsuarioidrec_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",dynavUsuarioidrec.Visible,dynavUsuarioidrec.Enabled,(short)1,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute",(String)"WWColumn",(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((dynavUsuarioidrec.Enabled!=0)&&(dynavUsuarioidrec.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,26);\"" : " "),(String)"",(bool)true});
            dynavUsuarioidrec.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10usuarioidRec), 6, 0));
            AssignProp("", false, dynavUsuarioidrec_Internalname, "Values", (String)(dynavUsuarioidrec.ToJavascriptSource()), !bGXsfl_23_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavNombrecompleto_Enabled!=0)&&(edtavNombrecompleto_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 27,'',false,'"+sGXsfl_23_idx+"',23)\"" : " ");
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavNombrecompleto_Internalname,(String)AV7NombreCompleto,(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavNombrecompleto_Enabled!=0)&&(edtavNombrecompleto_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,27);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavNombrecompleto_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(short)-1,(int)edtavNombrecompleto_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)40,(short)0,(short)0,(short)23,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavUsuariostelef_Enabled!=0)&&(edtavUsuariostelef_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 28,'',false,'"+sGXsfl_23_idx+"',23)\"" : " ");
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavUsuariostelef_Internalname,StringUtil.RTrim( AV14UsuariosTelef),(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavUsuariostelef_Enabled!=0)&&(edtavUsuariostelef_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,28);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavUsuariostelef_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(int)edtavUsuariostelef_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)23,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavUsuarioscorreo_Enabled!=0)&&(edtavUsuarioscorreo_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 29,'',false,'"+sGXsfl_23_idx+"',23)\"" : " ");
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavUsuarioscorreo_Internalname,(String)AV11UsuariosCorreo,(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavUsuarioscorreo_Enabled!=0)&&(edtavUsuarioscorreo_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,29);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavUsuarioscorreo_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(int)edtavUsuarioscorreo_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)100,(short)0,(short)0,(short)23,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((dynavPerfiles_id.Enabled!=0)&&(dynavPerfiles_id.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 30,'',false,'"+sGXsfl_23_idx+"',23)\"" : " ");
            GXCCtl = "vPERFILES_ID_" + sGXsfl_23_idx;
            dynavPerfiles_id.Name = GXCCtl;
            dynavPerfiles_id.WebTags = "";
            dynavPerfiles_id.removeAllItems();
            /* Using cursor H002T9 */
            pr_default.execute(7);
            while ( (pr_default.getStatus(7) != 101) )
            {
               dynavPerfiles_id.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H002T9_A278Perfiles_Id[0]), 9, 0)), H002T9_A279Perfiles_Nombre[0], 0);
               pr_default.readNext(7);
            }
            pr_default.close(7);
            if ( dynavPerfiles_id.ItemCount > 0 )
            {
               AV9Perfiles_Id = (int)(NumberUtil.Val( dynavPerfiles_id.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV9Perfiles_Id), 9, 0))), "."));
               AssignAttri("", false, dynavPerfiles_id_Internalname, StringUtil.LTrimStr( (decimal)(AV9Perfiles_Id), 9, 0));
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynavPerfiles_id,(String)dynavPerfiles_id_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV9Perfiles_Id), 9, 0)),(short)1,(String)dynavPerfiles_id_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,dynavPerfiles_id.Enabled,(short)1,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute",(String)"WWColumn",(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((dynavPerfiles_id.Enabled!=0)&&(dynavPerfiles_id.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,30);\"" : " "),(String)"",(bool)true});
            dynavPerfiles_id.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9Perfiles_Id), 9, 0));
            AssignProp("", false, dynavPerfiles_id_Internalname, "Values", (String)(dynavPerfiles_id.ToJavascriptSource()), !bGXsfl_23_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavVacantes_nombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavVacantes_nombre_Enabled!=0)&&(edtavVacantes_nombre_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 31,'',false,'',23)\"" : " ");
            ClassString = "Image";
            StyleString = "";
            AV28vacantes_nombre_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV28vacantes_nombre))&&String.IsNullOrEmpty(StringUtil.RTrim( AV36Vacantes_nombre_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV28vacantes_nombre)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV28vacantes_nombre)) ? AV36Vacantes_nombre_GXI : context.PathToRelativeUrl( AV28vacantes_nombre));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavVacantes_nombre_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(int)edtavVacantes_nombre_Visible,(short)1,(String)"",(String)edtavVacantes_nombre_Tooltiptext,(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)5,(String)edtavVacantes_nombre_Jsonclick,"'"+""+"'"+",false,"+"'"+"EVVACANTES_NOMBRE.CLICK."+sGXsfl_23_idx+"'",(String)StyleString,(String)ClassString,(String)"WWColumn",(String)"",(String)"",(String)"",(String)""+TempTags,(String)"",(String)"",(short)1,(bool)AV28vacantes_nombre_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes2T2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_23_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_23_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_23_idx+1);
            sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
            SubsflControlProps_232( ) ;
         }
         /* End function sendrow_232 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vUSUARIOIDREC_" + sGXsfl_23_idx;
         dynavUsuarioidrec.Name = GXCCtl;
         dynavUsuarioidrec.WebTags = "";
         GXCCtl = "vPERFILES_ID_" + sGXsfl_23_idx;
         dynavPerfiles_id.Name = GXCCtl;
         dynavPerfiles_id.WebTags = "";
         dynavPerfiles_id.removeAllItems();
         /* Using cursor H002T10 */
         pr_default.execute(8);
         while ( (pr_default.getStatus(8) != 101) )
         {
            dynavPerfiles_id.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H002T10_A278Perfiles_Id[0]), 9, 0)), H002T10_A279Perfiles_Nombre[0], 0);
            pr_default.readNext(8);
         }
         pr_default.close(8);
         if ( dynavPerfiles_id.ItemCount > 0 )
         {
            AV9Perfiles_Id = (int)(NumberUtil.Val( dynavPerfiles_id.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV9Perfiles_Id), 9, 0))), "."));
            AssignAttri("", false, dynavPerfiles_id_Internalname, StringUtil.LTrimStr( (decimal)(AV9Perfiles_Id), 9, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitletext_Internalname = "TITLETEXT";
         edtavNomcompleto_Internalname = "vNOMCOMPLETO";
         bttAgregar_Internalname = "AGREGAR";
         divTable2_Internalname = "TABLE2";
         edtavUsuariosid_Internalname = "vUSUARIOSID";
         edtavUsuarioscurp_Internalname = "vUSUARIOSCURP";
         dynavUsuarioidrec_Internalname = "vUSUARIOIDREC";
         edtavNombrecompleto_Internalname = "vNOMBRECOMPLETO";
         edtavUsuariostelef_Internalname = "vUSUARIOSTELEF";
         edtavUsuarioscorreo_Internalname = "vUSUARIOSCORREO";
         dynavPerfiles_id_Internalname = "vPERFILES_ID";
         edtavVacantes_nombre_Internalname = "vVACANTES_NOMBRE";
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
         edtavVacantes_nombre_Jsonclick = "";
         edtavVacantes_nombre_Enabled = 1;
         dynavPerfiles_id_Jsonclick = "";
         dynavPerfiles_id.Visible = -1;
         edtavUsuarioscorreo_Jsonclick = "";
         edtavUsuarioscorreo_Visible = -1;
         edtavUsuariostelef_Jsonclick = "";
         edtavUsuariostelef_Visible = -1;
         edtavNombrecompleto_Jsonclick = "";
         edtavNombrecompleto_Visible = -1;
         dynavUsuarioidrec_Jsonclick = "";
         edtavUsuarioscurp_Jsonclick = "";
         edtavUsuarioscurp_Visible = 0;
         edtavUsuariosid_Jsonclick = "";
         edtavUsuariosid_Visible = 0;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtavVacantes_nombre_Tooltiptext = "";
         subGrid1_Header = "";
         edtavVacantes_nombre_Visible = -1;
         dynavPerfiles_id.Enabled = 1;
         edtavUsuarioscorreo_Enabled = 1;
         edtavUsuariostelef_Enabled = 1;
         edtavNombrecompleto_Enabled = 1;
         dynavUsuarioidrec.Visible = -1;
         edtavUsuarioscurp_Enabled = 1;
         edtavUsuariosid_Enabled = 1;
         subGrid1_Class = "WorkWith";
         subGrid1_Backcolorstyle = 0;
         edtavNomcompleto_Jsonclick = "";
         edtavNomcompleto_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "wp Candidatos";
         subGrid1_Rows = 10;
         dynavUsuarioidrec.Enabled = 1;
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'dynavUsuarioidrec'},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'A284SUBT_ReclutadorId',fld:'SUBT_RECLUTADORID',pic:'ZZZZZ9'},{av:'A286UsuariosStatus',fld:'USUARIOSSTATUS',pic:'9'},{av:'A97UsuariosNomCompleto',fld:'USUARIOSNOMCOMPLETO',pic:''},{av:'AV8NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'A260UsuariosTelef',fld:'USUARIOSTELEF',pic:''},{av:'A261UsuariosCorreo',fld:'USUARIOSCORREO',pic:''},{av:'A105UsuariosCurp',fld:'USUARIOSCURP',pic:'@!'},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A283PerfilesUsuariosEstatus',fld:'PERFILESUSUARIOSESTATUS',pic:'9'},{av:'A278Perfiles_Id',fld:'PERFILES_ID',pic:'ZZZZZZZZ9'},{av:'AV29Entra',fld:'vENTRA',pic:'ZZZ9',hsh:true},{av:'AV26SessionId',fld:'vSESSIONID',pic:'ZZZZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID1.LOAD","{handler:'E132T2',iparms:[{av:'AV29Entra',fld:'vENTRA',pic:'ZZZ9',hsh:true},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'A284SUBT_ReclutadorId',fld:'SUBT_RECLUTADORID',pic:'ZZZZZ9'},{av:'AV26SessionId',fld:'vSESSIONID',pic:'ZZZZZZZZ9',hsh:true},{av:'A286UsuariosStatus',fld:'USUARIOSSTATUS',pic:'9'},{av:'A97UsuariosNomCompleto',fld:'USUARIOSNOMCOMPLETO',pic:''},{av:'AV8NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'A260UsuariosTelef',fld:'USUARIOSTELEF',pic:''},{av:'A261UsuariosCorreo',fld:'USUARIOSCORREO',pic:''},{av:'A105UsuariosCurp',fld:'USUARIOSCURP',pic:'@!'},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A283PerfilesUsuariosEstatus',fld:'PERFILESUSUARIOSESTATUS',pic:'9'},{av:'A278Perfiles_Id',fld:'PERFILES_ID',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("GRID1.LOAD",",oparms:[{av:'dynavUsuarioidrec'},{av:'AV28vacantes_nombre',fld:'vVACANTES_NOMBRE',pic:''},{av:'edtavVacantes_nombre_Tooltiptext',ctrl:'vVACANTES_NOMBRE',prop:'Tooltiptext'},{av:'edtavVacantes_nombre_Visible',ctrl:'vVACANTES_NOMBRE',prop:'Visible'},{av:'AV7NombreCompleto',fld:'vNOMBRECOMPLETO',pic:''},{av:'AV14UsuariosTelef',fld:'vUSUARIOSTELEF',pic:''},{av:'AV11UsuariosCorreo',fld:'vUSUARIOSCORREO',pic:''},{av:'AV12usuarioscurp',fld:'vUSUARIOSCURP',pic:'@!',hsh:true},{av:'AV13usuariosid',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true},{av:'AV10usuarioidRec',fld:'vUSUARIOIDREC',pic:'ZZZZZ9'},{av:'dynavPerfiles_id'},{av:'AV9Perfiles_Id',fld:'vPERFILES_ID',pic:'ZZZZZZZZ9'}]}");
         setEventMetadata("VVACANTES_NOMBRE.CLICK","{handler:'E142T2',iparms:[{av:'dynavPerfiles_id'},{av:'AV9Perfiles_Id',fld:'vPERFILES_ID',pic:'ZZZZZZZZ9'},{av:'AV13usuariosid',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true},{av:'AV12usuarioscurp',fld:'vUSUARIOSCURP',pic:'@!',hsh:true},{av:'AV26SessionId',fld:'vSESSIONID',pic:'ZZZZZZZZ9',hsh:true}]");
         setEventMetadata("VVACANTES_NOMBRE.CLICK",",oparms:[{av:'AV18AlertProperties',fld:'vALERTPROPERTIES',pic:''}]}");
         setEventMetadata("'AGREGAR'","{handler:'E112T2',iparms:[{av:'AV29Entra',fld:'vENTRA',pic:'ZZZ9',hsh:true},{av:'AV13usuariosid',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("'AGREGAR'",",oparms:[]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'dynavUsuarioidrec'},{av:'AV29Entra',fld:'vENTRA',pic:'ZZZ9',hsh:true},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'A284SUBT_ReclutadorId',fld:'SUBT_RECLUTADORID',pic:'ZZZZZ9'},{av:'AV26SessionId',fld:'vSESSIONID',pic:'ZZZZZZZZ9',hsh:true},{av:'A286UsuariosStatus',fld:'USUARIOSSTATUS',pic:'9'},{av:'A97UsuariosNomCompleto',fld:'USUARIOSNOMCOMPLETO',pic:''},{av:'AV8NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'A260UsuariosTelef',fld:'USUARIOSTELEF',pic:''},{av:'A261UsuariosCorreo',fld:'USUARIOSCORREO',pic:''},{av:'A105UsuariosCurp',fld:'USUARIOSCURP',pic:'@!'},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A283PerfilesUsuariosEstatus',fld:'PERFILESUSUARIOSESTATUS',pic:'9'},{av:'A278Perfiles_Id',fld:'PERFILES_ID',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'dynavUsuarioidrec'},{av:'AV29Entra',fld:'vENTRA',pic:'ZZZ9',hsh:true},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'A284SUBT_ReclutadorId',fld:'SUBT_RECLUTADORID',pic:'ZZZZZ9'},{av:'AV26SessionId',fld:'vSESSIONID',pic:'ZZZZZZZZ9',hsh:true},{av:'A286UsuariosStatus',fld:'USUARIOSSTATUS',pic:'9'},{av:'A97UsuariosNomCompleto',fld:'USUARIOSNOMCOMPLETO',pic:''},{av:'AV8NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'A260UsuariosTelef',fld:'USUARIOSTELEF',pic:''},{av:'A261UsuariosCorreo',fld:'USUARIOSCORREO',pic:''},{av:'A105UsuariosCurp',fld:'USUARIOSCURP',pic:'@!'},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A283PerfilesUsuariosEstatus',fld:'PERFILESUSUARIOSESTATUS',pic:'9'},{av:'A278Perfiles_Id',fld:'PERFILES_ID',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'dynavUsuarioidrec'},{av:'AV29Entra',fld:'vENTRA',pic:'ZZZ9',hsh:true},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'A284SUBT_ReclutadorId',fld:'SUBT_RECLUTADORID',pic:'ZZZZZ9'},{av:'AV26SessionId',fld:'vSESSIONID',pic:'ZZZZZZZZ9',hsh:true},{av:'A286UsuariosStatus',fld:'USUARIOSSTATUS',pic:'9'},{av:'A97UsuariosNomCompleto',fld:'USUARIOSNOMCOMPLETO',pic:''},{av:'AV8NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'A260UsuariosTelef',fld:'USUARIOSTELEF',pic:''},{av:'A261UsuariosCorreo',fld:'USUARIOSCORREO',pic:''},{av:'A105UsuariosCurp',fld:'USUARIOSCURP',pic:'@!'},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A283PerfilesUsuariosEstatus',fld:'PERFILESUSUARIOSESTATUS',pic:'9'},{av:'A278Perfiles_Id',fld:'PERFILES_ID',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'dynavUsuarioidrec'},{av:'AV29Entra',fld:'vENTRA',pic:'ZZZ9',hsh:true},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'A284SUBT_ReclutadorId',fld:'SUBT_RECLUTADORID',pic:'ZZZZZ9'},{av:'AV26SessionId',fld:'vSESSIONID',pic:'ZZZZZZZZ9',hsh:true},{av:'A286UsuariosStatus',fld:'USUARIOSSTATUS',pic:'9'},{av:'A97UsuariosNomCompleto',fld:'USUARIOSNOMCOMPLETO',pic:''},{av:'AV8NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'A260UsuariosTelef',fld:'USUARIOSTELEF',pic:''},{av:'A261UsuariosCorreo',fld:'USUARIOSCORREO',pic:''},{av:'A105UsuariosCurp',fld:'USUARIOSCURP',pic:'@!'},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A283PerfilesUsuariosEstatus',fld:'PERFILESUSUARIOSESTATUS',pic:'9'},{av:'A278Perfiles_Id',fld:'PERFILES_ID',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_USUARIOSID","{handler:'Validv_Usuariosid',iparms:[]");
         setEventMetadata("VALIDV_USUARIOSID",",oparms:[]}");
         setEventMetadata("VALIDV_USUARIOSCORREO","{handler:'Validv_Usuarioscorreo',iparms:[]");
         setEventMetadata("VALIDV_USUARIOSCORREO",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Vacantes_nombre',iparms:[]");
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
         A97UsuariosNomCompleto = "";
         AV8NomCompleto = "";
         A260UsuariosTelef = "";
         A261UsuariosCorreo = "";
         A105UsuariosCurp = "";
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
         bttAgregar_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV12usuarioscurp = "";
         AV7NombreCompleto = "";
         AV14UsuariosTelef = "";
         AV11UsuariosCorreo = "";
         AV28vacantes_nombre = "";
         ucUcalertas = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV36Vacantes_nombre_GXI = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         l97UsuariosNomCompleto = "";
         H002T2_A97UsuariosNomCompleto = new String[] {""} ;
         H002T3_A11UsuariosId = new int[1] ;
         H002T3_A97UsuariosNomCompleto = new String[] {""} ;
         AV25Websession = context.GetSession();
         H002T4_A272UsuariosTipo = new short[1] ;
         H002T4_A11UsuariosId = new int[1] ;
         AV17Asignar = "";
         lV8NomCompleto = "";
         H002T5_A272UsuariosTipo = new short[1] ;
         H002T5_A286UsuariosStatus = new short[1] ;
         H002T5_A284SUBT_ReclutadorId = new int[1] ;
         H002T5_A263Vacantes_Id = new int[1] ;
         H002T5_A260UsuariosTelef = new String[] {""} ;
         H002T5_A261UsuariosCorreo = new String[] {""} ;
         H002T5_A105UsuariosCurp = new String[] {""} ;
         H002T5_A11UsuariosId = new int[1] ;
         H002T5_A64UsuariosApMat = new String[] {""} ;
         H002T5_A65UsuariosApPat = new String[] {""} ;
         H002T5_A66UsuariosNombre = new String[] {""} ;
         AV23candidato = "";
         AV34Candidato_GXI = "";
         H002T6_A283PerfilesUsuariosEstatus = new short[1] ;
         H002T6_A11UsuariosId = new int[1] ;
         H002T6_A278Perfiles_Id = new int[1] ;
         Grid1Row = new GXWebRow();
         H002T7_A272UsuariosTipo = new short[1] ;
         H002T7_A286UsuariosStatus = new short[1] ;
         H002T7_A263Vacantes_Id = new int[1] ;
         H002T7_A260UsuariosTelef = new String[] {""} ;
         H002T7_A261UsuariosCorreo = new String[] {""} ;
         H002T7_A105UsuariosCurp = new String[] {""} ;
         H002T7_A11UsuariosId = new int[1] ;
         H002T7_A284SUBT_ReclutadorId = new int[1] ;
         H002T7_A64UsuariosApMat = new String[] {""} ;
         H002T7_A65UsuariosApPat = new String[] {""} ;
         H002T7_A66UsuariosNombre = new String[] {""} ;
         H002T8_A283PerfilesUsuariosEstatus = new short[1] ;
         H002T8_A11UsuariosId = new int[1] ;
         H002T8_A278Perfiles_Id = new int[1] ;
         GXt_SdtPropiedades1 = new SdtPropiedades(context);
         GXEncryptionTmp = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         GXCCtl = "";
         H002T9_A278Perfiles_Id = new int[1] ;
         H002T9_A279Perfiles_Nombre = new String[] {""} ;
         sImgUrl = "";
         H002T10_A278Perfiles_Id = new int[1] ;
         H002T10_A279Perfiles_Nombre = new String[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpcandidatos__default(),
            new Object[][] {
                new Object[] {
               H002T2_A97UsuariosNomCompleto
               }
               , new Object[] {
               H002T3_A11UsuariosId, H002T3_A97UsuariosNomCompleto
               }
               , new Object[] {
               H002T4_A272UsuariosTipo, H002T4_A11UsuariosId
               }
               , new Object[] {
               H002T5_A272UsuariosTipo, H002T5_A286UsuariosStatus, H002T5_A284SUBT_ReclutadorId, H002T5_A263Vacantes_Id, H002T5_A260UsuariosTelef, H002T5_A261UsuariosCorreo, H002T5_A105UsuariosCurp, H002T5_A11UsuariosId, H002T5_A64UsuariosApMat, H002T5_A65UsuariosApPat,
               H002T5_A66UsuariosNombre
               }
               , new Object[] {
               H002T6_A283PerfilesUsuariosEstatus, H002T6_A11UsuariosId, H002T6_A278Perfiles_Id
               }
               , new Object[] {
               H002T7_A272UsuariosTipo, H002T7_A286UsuariosStatus, H002T7_A263Vacantes_Id, H002T7_A260UsuariosTelef, H002T7_A261UsuariosCorreo, H002T7_A105UsuariosCurp, H002T7_A11UsuariosId, H002T7_A284SUBT_ReclutadorId, H002T7_A64UsuariosApMat, H002T7_A65UsuariosApPat,
               H002T7_A66UsuariosNombre
               }
               , new Object[] {
               H002T8_A283PerfilesUsuariosEstatus, H002T8_A11UsuariosId, H002T8_A278Perfiles_Id
               }
               , new Object[] {
               H002T9_A278Perfiles_Id, H002T9_A279Perfiles_Nombre
               }
               , new Object[] {
               H002T10_A278Perfiles_Id, H002T10_A279Perfiles_Nombre
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavUsuariosid_Enabled = 0;
         edtavUsuarioscurp_Enabled = 0;
         dynavUsuarioidrec.Enabled = 0;
         edtavNombrecompleto_Enabled = 0;
         edtavUsuariostelef_Enabled = 0;
         edtavUsuarioscorreo_Enabled = 0;
      }

      private short GRID1_nEOF ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV29Entra ;
      private short A286UsuariosStatus ;
      private short A283PerfilesUsuariosEstatus ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
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
      private short AV32GXLvl8 ;
      private short A272UsuariosTipo ;
      private short AV35GXLvl42 ;
      private short AV38GXLvl76 ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_23 ;
      private int nGXsfl_23_idx=1 ;
      private int subGrid1_Rows ;
      private int A263Vacantes_Id ;
      private int A284SUBT_ReclutadorId ;
      private int AV26SessionId ;
      private int A11UsuariosId ;
      private int A278Perfiles_Id ;
      private int edtavNomcompleto_Enabled ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int edtavVacantes_nombre_Visible ;
      private int AV13usuariosid ;
      private int edtavUsuariosid_Enabled ;
      private int edtavUsuarioscurp_Enabled ;
      private int AV10usuarioidRec ;
      private int edtavNombrecompleto_Enabled ;
      private int edtavUsuariostelef_Enabled ;
      private int edtavUsuarioscorreo_Enabled ;
      private int AV9Perfiles_Id ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int gxdynajaxindex ;
      private int subGrid1_Islastpage ;
      private int GRID1_nGridOutOfScope ;
      private int subGrid1_Recordcount ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int edtavUsuariosid_Visible ;
      private int edtavUsuarioscurp_Visible ;
      private int edtavNombrecompleto_Visible ;
      private int edtavUsuariostelef_Visible ;
      private int edtavUsuarioscorreo_Visible ;
      private int edtavVacantes_nombre_Enabled ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_23_idx="0001" ;
      private String dynavUsuarioidrec_Internalname ;
      private String A260UsuariosTelef ;
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
      private String lblTitletext_Jsonclick ;
      private String edtavNomcompleto_Internalname ;
      private String TempTags ;
      private String edtavNomcompleto_Jsonclick ;
      private String ClassString ;
      private String StyleString ;
      private String bttAgregar_Internalname ;
      private String bttAgregar_Jsonclick ;
      private String sStyleString ;
      private String subGrid1_Internalname ;
      private String subGrid1_Class ;
      private String subGrid1_Linesclass ;
      private String subGrid1_Header ;
      private String AV14UsuariosTelef ;
      private String edtavVacantes_nombre_Tooltiptext ;
      private String Ucalertas_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavUsuariosid_Internalname ;
      private String edtavUsuarioscurp_Internalname ;
      private String edtavNombrecompleto_Internalname ;
      private String edtavUsuariostelef_Internalname ;
      private String edtavUsuarioscorreo_Internalname ;
      private String dynavPerfiles_id_Internalname ;
      private String edtavVacantes_nombre_Internalname ;
      private String gxwrpcisep ;
      private String scmdbuf ;
      private String AV17Asignar ;
      private String GXEncryptionTmp ;
      private String sGXsfl_23_fel_idx="0001" ;
      private String ROClassString ;
      private String edtavUsuariosid_Jsonclick ;
      private String edtavUsuarioscurp_Jsonclick ;
      private String GXCCtl ;
      private String dynavUsuarioidrec_Jsonclick ;
      private String edtavNombrecompleto_Jsonclick ;
      private String edtavUsuariostelef_Jsonclick ;
      private String edtavUsuarioscorreo_Jsonclick ;
      private String dynavPerfiles_id_Jsonclick ;
      private String sImgUrl ;
      private String edtavVacantes_nombre_Jsonclick ;
      private bool entryPointCalled ;
      private bool bGXsfl_23_Refreshing=false ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV28vacantes_nombre_IsBlob ;
      private String A97UsuariosNomCompleto ;
      private String AV8NomCompleto ;
      private String A261UsuariosCorreo ;
      private String A105UsuariosCurp ;
      private String A66UsuariosNombre ;
      private String A65UsuariosApPat ;
      private String A64UsuariosApMat ;
      private String AV12usuarioscurp ;
      private String AV7NombreCompleto ;
      private String AV11UsuariosCorreo ;
      private String AV36Vacantes_nombre_GXI ;
      private String l97UsuariosNomCompleto ;
      private String lV8NomCompleto ;
      private String AV34Candidato_GXI ;
      private String AV28vacantes_nombre ;
      private String AV23candidato ;
      private IGxSession AV25Websession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXUserControl ucUcalertas ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavUsuarioidrec ;
      private GXCombobox dynavPerfiles_id ;
      private IDataStoreProvider pr_default ;
      private String[] H002T2_A97UsuariosNomCompleto ;
      private int[] H002T3_A11UsuariosId ;
      private String[] H002T3_A97UsuariosNomCompleto ;
      private short[] H002T4_A272UsuariosTipo ;
      private int[] H002T4_A11UsuariosId ;
      private short[] H002T5_A272UsuariosTipo ;
      private short[] H002T5_A286UsuariosStatus ;
      private int[] H002T5_A284SUBT_ReclutadorId ;
      private int[] H002T5_A263Vacantes_Id ;
      private String[] H002T5_A260UsuariosTelef ;
      private String[] H002T5_A261UsuariosCorreo ;
      private String[] H002T5_A105UsuariosCurp ;
      private int[] H002T5_A11UsuariosId ;
      private String[] H002T5_A64UsuariosApMat ;
      private String[] H002T5_A65UsuariosApPat ;
      private String[] H002T5_A66UsuariosNombre ;
      private short[] H002T6_A283PerfilesUsuariosEstatus ;
      private int[] H002T6_A11UsuariosId ;
      private int[] H002T6_A278Perfiles_Id ;
      private short[] H002T7_A272UsuariosTipo ;
      private short[] H002T7_A286UsuariosStatus ;
      private int[] H002T7_A263Vacantes_Id ;
      private String[] H002T7_A260UsuariosTelef ;
      private String[] H002T7_A261UsuariosCorreo ;
      private String[] H002T7_A105UsuariosCurp ;
      private int[] H002T7_A11UsuariosId ;
      private int[] H002T7_A284SUBT_ReclutadorId ;
      private String[] H002T7_A64UsuariosApMat ;
      private String[] H002T7_A65UsuariosApPat ;
      private String[] H002T7_A66UsuariosNombre ;
      private short[] H002T8_A283PerfilesUsuariosEstatus ;
      private int[] H002T8_A11UsuariosId ;
      private int[] H002T8_A278Perfiles_Id ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int[] H002T9_A278Perfiles_Id ;
      private String[] H002T9_A279Perfiles_Nombre ;
      private int[] H002T10_A278Perfiles_Id ;
      private String[] H002T10_A279Perfiles_Nombre ;
      private GXWebForm Form ;
      private SdtPropiedades AV18AlertProperties ;
      private SdtPropiedades GXt_SdtPropiedades1 ;
   }

   public class wpcandidatos__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002T5( IGxContext context ,
                                             String AV8NomCompleto ,
                                             String A66UsuariosNombre ,
                                             String A65UsuariosApPat ,
                                             String A64UsuariosApMat ,
                                             short A286UsuariosStatus ,
                                             int AV26SessionId ,
                                             int A263Vacantes_Id ,
                                             int A284SUBT_ReclutadorId )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int2 ;
         GXv_int2 = new short [2] ;
         Object[] GXv_Object3 ;
         GXv_Object3 = new Object [2] ;
         scmdbuf = "SELECT T2.`UsuariosTipo`, T2.`UsuariosStatus`, T1.`SUBT_ReclutadorId`, T1.`Vacantes_Id`, T2.`UsuariosTelef`, T2.`UsuariosCorreo`, T2.`UsuariosCurp`, T1.`UsuariosId`, T2.`UsuariosApMat`, T2.`UsuariosApPat`, T2.`UsuariosNombre` FROM (`VacantesUsuariosVacante` T1 INNER JOIN `Usuarios` T2 ON T2.`UsuariosId` = T1.`UsuariosId`)";
         scmdbuf = scmdbuf + " WHERE (T1.`Vacantes_Id` = 17 and T1.`SUBT_ReclutadorId` = ?)";
         scmdbuf = scmdbuf + " and (T2.`UsuariosStatus` = 1)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8NomCompleto)) )
         {
            sWhereString = sWhereString + " and (CONCAT(CONCAT(CONCAT(CONCAT(RTRIM(LTRIM(T2.`UsuariosNombre`)), ' '), RTRIM(LTRIM(T2.`UsuariosApPat`))), ' '), RTRIM(LTRIM(T2.`UsuariosApMat`))) like CONCAT(CONCAT('%', ?), '%'))";
         }
         else
         {
            GXv_int2[1] = 1;
         }
         scmdbuf = scmdbuf + sWhereString;
         scmdbuf = scmdbuf + " ORDER BY T1.`Vacantes_Id`, T1.`SUBT_ReclutadorId`";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_H002T7( IGxContext context ,
                                             String AV8NomCompleto ,
                                             String A66UsuariosNombre ,
                                             String A65UsuariosApPat ,
                                             String A64UsuariosApMat ,
                                             short A286UsuariosStatus ,
                                             int A263Vacantes_Id )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int4 ;
         GXv_int4 = new short [1] ;
         Object[] GXv_Object5 ;
         GXv_Object5 = new Object [2] ;
         scmdbuf = "SELECT T2.`UsuariosTipo`, T2.`UsuariosStatus`, T1.`Vacantes_Id`, T2.`UsuariosTelef`, T2.`UsuariosCorreo`, T2.`UsuariosCurp`, T1.`UsuariosId`, T1.`SUBT_ReclutadorId`, T2.`UsuariosApMat`, T2.`UsuariosApPat`, T2.`UsuariosNombre` FROM (`VacantesUsuariosVacante` T1 INNER JOIN `Usuarios` T2 ON T2.`UsuariosId` = T1.`UsuariosId`)";
         scmdbuf = scmdbuf + " WHERE (T1.`Vacantes_Id` = 17)";
         scmdbuf = scmdbuf + " and (T2.`UsuariosStatus` = 1)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8NomCompleto)) )
         {
            sWhereString = sWhereString + " and (CONCAT(CONCAT(CONCAT(CONCAT(RTRIM(LTRIM(T2.`UsuariosNombre`)), ' '), RTRIM(LTRIM(T2.`UsuariosApPat`))), ' '), RTRIM(LTRIM(T2.`UsuariosApMat`))) like CONCAT(CONCAT('%', ?), '%'))";
         }
         else
         {
            GXv_int4[0] = 1;
         }
         scmdbuf = scmdbuf + sWhereString;
         scmdbuf = scmdbuf + " ORDER BY T1.`Vacantes_Id`";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 3 :
                     return conditional_H002T5(context, (String)dynConstraints[0] , (String)dynConstraints[1] , (String)dynConstraints[2] , (String)dynConstraints[3] , (short)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] );
               case 5 :
                     return conditional_H002T7(context, (String)dynConstraints[0] , (String)dynConstraints[1] , (String)dynConstraints[2] , (String)dynConstraints[3] , (short)dynConstraints[4] , (int)dynConstraints[5] );
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
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002T2 ;
          prmH002T2 = new Object[] {
          new Object[] {"l97UsuariosNomCompleto",System.Data.DbType.String,90,0}
          } ;
          Object[] prmH002T3 ;
          prmH002T3 = new Object[] {
          } ;
          Object[] prmH002T4 ;
          prmH002T4 = new Object[] {
          new Object[] {"AV26SessionId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmH002T6 ;
          prmH002T6 = new Object[] {
          new Object[] {"AV13usuariosid",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmH002T8 ;
          prmH002T8 = new Object[] {
          new Object[] {"AV13usuariosid",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmH002T9 ;
          prmH002T9 = new Object[] {
          } ;
          Object[] prmH002T10 ;
          prmH002T10 = new Object[] {
          } ;
          Object[] prmH002T5 ;
          prmH002T5 = new Object[] {
          new Object[] {"AV26SessionId",System.Data.DbType.Int32,9,0} ,
          new Object[] {"lV8NomCompleto",System.Data.DbType.String,40,0}
          } ;
          Object[] prmH002T7 ;
          prmH002T7 = new Object[] {
          new Object[] {"lV8NomCompleto",System.Data.DbType.String,40,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H002T2", "SELECT DISTINCT CONCAT(CONCAT(CONCAT(CONCAT(RTRIM(LTRIM(`UsuariosNombre`)), ' '), RTRIM(LTRIM(`UsuariosApPat`))), ' '), RTRIM(LTRIM(`UsuariosApMat`))) AS UsuariosNomCompleto FROM `Usuarios` WHERE (UPPER(CONCAT(CONCAT(CONCAT(CONCAT(RTRIM(LTRIM(`UsuariosNombre`)), ' '), RTRIM(LTRIM(`UsuariosApPat`))), ' '), RTRIM(LTRIM(`UsuariosApMat`)))) like UPPER(?)) AND (`UsuariosTipo` = 3) AND (`UsuariosStatus` = 1) ORDER BY `UsuariosNomCompleto`  LIMIT 5",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002T2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002T3", "SELECT `UsuariosId`, CONCAT(CONCAT(CONCAT(CONCAT(RTRIM(LTRIM(`UsuariosNombre`)), ' '), RTRIM(LTRIM(`UsuariosApPat`))), ' '), RTRIM(LTRIM(`UsuariosApMat`))) AS UsuariosNomCompleto FROM `Usuarios` ORDER BY `UsuariosNomCompleto` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002T3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002T4", "SELECT `UsuariosTipo`, `UsuariosId` FROM `Usuarios` WHERE (`UsuariosId` = ?) AND (`UsuariosTipo` = 5) ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002T4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H002T5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002T5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002T6", "SELECT `PerfilesUsuariosEstatus`, `UsuariosId`, `Perfiles_Id` FROM `PerfilesUsuariosPerfil` WHERE (`UsuariosId` = ?) AND (`PerfilesUsuariosEstatus` = 1) ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002T6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002T7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002T7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002T8", "SELECT `PerfilesUsuariosEstatus`, `UsuariosId`, `Perfiles_Id` FROM `PerfilesUsuariosPerfil` WHERE (`UsuariosId` = ?) AND (`PerfilesUsuariosEstatus` = 1) ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002T8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002T9", "SELECT `Perfiles_Id`, `Perfiles_Nombre` FROM `Perfiles` ORDER BY `Perfiles_Nombre` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002T9,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002T10", "SELECT `Perfiles_Id`, `Perfiles_Nombre` FROM `Perfiles` ORDER BY `Perfiles_Nombre` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002T10,0, GxCacheFrequency.OFF ,true,false )
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
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                ((int[]) buf[3])[0] = rslt.getInt(4) ;
                ((String[]) buf[4])[0] = rslt.getString(5, 10) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
                ((String[]) buf[6])[0] = rslt.getVarchar(7) ;
                ((int[]) buf[7])[0] = rslt.getInt(8) ;
                ((String[]) buf[8])[0] = rslt.getVarchar(9) ;
                ((String[]) buf[9])[0] = rslt.getVarchar(10) ;
                ((String[]) buf[10])[0] = rslt.getVarchar(11) ;
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                ((String[]) buf[3])[0] = rslt.getString(4, 10) ;
                ((String[]) buf[4])[0] = rslt.getVarchar(5) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
                ((int[]) buf[6])[0] = rslt.getInt(7) ;
                ((int[]) buf[7])[0] = rslt.getInt(8) ;
                ((String[]) buf[8])[0] = rslt.getVarchar(9) ;
                ((String[]) buf[9])[0] = rslt.getVarchar(10) ;
                ((String[]) buf[10])[0] = rslt.getVarchar(11) ;
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                return;
             case 8 :
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
             case 0 :
                stmt.SetParameter(1, (String)parms[0]);
                return;
             case 2 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 3 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[2]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[3]);
                }
                return;
             case 4 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 5 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[1]);
                }
                return;
             case 6 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

}
