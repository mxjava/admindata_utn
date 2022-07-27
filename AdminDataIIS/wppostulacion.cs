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
   public class wppostulacion : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wppostulacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public wppostulacion( IGxContext context )
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
         dynavPerfiles_id = new GXCombobox();
         cmbavUsuarioidrec = new GXCombobox();
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
               GXSGVvNOMCOMPLETO2A0( A97UsuariosNomCompleto) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vPERFILES_ID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvPERFILES_ID2A2( ) ;
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
               nRC_GXsfl_19 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_19_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_19_idx = GetNextPar( );
               cmbavUsuarioidrec.Enabled = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignProp("", false, cmbavUsuarioidrec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuarioidrec.Enabled), 5, 0), !bGXsfl_19_Refreshing);
               AV23Asignar = GetNextPar( );
               AV21usuarioidRec = (int)(NumberUtil.Val( GetNextPar( ), "."));
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
               A286UsuariosStatus = (short)(NumberUtil.Val( GetNextPar( ), "."));
               A272UsuariosTipo = (short)(NumberUtil.Val( GetNextPar( ), "."));
               A11UsuariosId = (int)(NumberUtil.Val( GetNextPar( ), "."));
               A97UsuariosNomCompleto = GetNextPar( );
               cmbavUsuarioidrec.Enabled = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignProp("", false, cmbavUsuarioidrec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuarioidrec.Enabled), 5, 0), !bGXsfl_19_Refreshing);
               AV23Asignar = GetNextPar( );
               AV21usuarioidRec = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV15NomCompleto = GetNextPar( );
               A260UsuariosTelef = GetNextPar( );
               A261UsuariosCorreo = GetNextPar( );
               A283PerfilesUsuariosEstatus = (short)(NumberUtil.Val( GetNextPar( ), "."));
               A278Perfiles_Id = (int)(NumberUtil.Val( GetNextPar( ), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, A286UsuariosStatus, A272UsuariosTipo, A11UsuariosId, A97UsuariosNomCompleto, AV23Asignar, AV21usuarioidRec, AV15NomCompleto, A260UsuariosTelef, A261UsuariosCorreo, A283PerfilesUsuariosEstatus, A278Perfiles_Id) ;
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
         PA2A2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2A2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20226271434513", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wppostulacion.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_19", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_19), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vALERTPROPERTIES", AV24AlertProperties);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vALERTPROPERTIES", AV24AlertProperties);
         }
         GxWebStd.gx_hidden_field( context, "USUARIOSTIPO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A272UsuariosTipo), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSSTATUS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A286UsuariosStatus), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSTELEF", StringUtil.RTrim( A260UsuariosTelef));
         GxWebStd.gx_hidden_field( context, "USUARIOSCORREO", A261UsuariosCorreo);
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
         GxWebStd.gx_hidden_field( context, "vUSUARIOIDREC_Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavUsuarioidrec.Enabled), 5, 0, ".", "")));
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
            WE2A2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2A2( ) ;
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
         return formatLink("wppostulacion.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "wpPostulacion" ;
      }

      public override String GetPgmdesc( )
      {
         return "Postulaciones de Usuarios" ;
      }

      protected void WB2A0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, "Nuevos Prospectos", "", "", lblTitletext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SubTitle", 0, "", 1, 1, 0, "HLP_wpPostulacion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNomcompleto_Internalname, "Nom Completo", "col-sm-3 FilterSearchAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'',false,'" + sGXsfl_19_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNomcompleto_Internalname, AV15NomCompleto, StringUtil.RTrim( context.localUtil.Format( AV15NomCompleto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,13);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Nombre", edtavNomcompleto_Jsonclick, 0, "FilterSearchAttribute", "", "", "", "", 1, edtavNomcompleto_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, 0, 0, true, "", "left", true, "", "HLP_wpPostulacion.htm");
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
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"19\">") ;
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
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Image"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "ID") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Nombre Completo") ;
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Reclutador") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
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
               Grid1Column.AddObjectProperty("Value", context.convertURL( AV13vacantes_nombre));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14usuariosid), 6, 0, ".", "")));
               Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsuariosid_Enabled), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", AV5NombreCompleto);
               Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNombrecompleto_Enabled), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( AV10UsuariosTelef));
               Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsuariostelef_Enabled), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", AV11UsuariosCorreo);
               Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsuarioscorreo_Enabled), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20Perfiles_Id), 9, 0, ".", "")));
               Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynavPerfiles_id.Enabled), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21usuarioidRec), 6, 0, ".", "")));
               Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavUsuarioidrec.Enabled), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( AV23Asignar));
               Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAsignar_Enabled), 5, 0, ".", "")));
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
         if ( wbEnd == 19 )
         {
            wbEnd = 0;
            nRC_GXsfl_19 = (int)(nGXsfl_19_idx-1);
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
            ucUcalertas.SetProperty("Propiedades", AV24AlertProperties);
            ucUcalertas.Render(context, "sweetalert2", Ucalertas_Internalname, "UCALERTASContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 19 )
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

      protected void START2A2( )
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
            Form.Meta.addItem("description", "Postulaciones de Usuarios", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2A0( ) ;
      }

      protected void WS2A2( )
      {
         START2A2( ) ;
         EVT2A2( ) ;
      }

      protected void EVT2A2( )
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "'ASIGNAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "'ASIGNAR'") == 0 ) )
                           {
                              nGXsfl_19_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_19_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_19_idx), 4, 0), 4, "0");
                              SubsflControlProps_192( ) ;
                              AV13vacantes_nombre = cgiGet( edtavVacantes_nombre_Internalname);
                              AssignProp("", false, edtavVacantes_nombre_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV13vacantes_nombre)) ? AV30Vacantes_nombre_GXI : context.convertURL( context.PathToRelativeUrl( AV13vacantes_nombre))), !bGXsfl_19_Refreshing);
                              AssignProp("", false, edtavVacantes_nombre_Internalname, "SrcSet", context.GetImageSrcSet( AV13vacantes_nombre), true);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavUsuariosid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsuariosid_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vUSUARIOSID");
                                 GX_FocusControl = edtavUsuariosid_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV14usuariosid = 0;
                                 AssignAttri("", false, edtavUsuariosid_Internalname, StringUtil.LTrimStr( (decimal)(AV14usuariosid), 6, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID"+"_"+sGXsfl_19_idx, GetSecureSignedToken( sGXsfl_19_idx, context.localUtil.Format( (decimal)(AV14usuariosid), "ZZZZZ9"), context));
                              }
                              else
                              {
                                 AV14usuariosid = (int)(context.localUtil.CToN( cgiGet( edtavUsuariosid_Internalname), ",", "."));
                                 AssignAttri("", false, edtavUsuariosid_Internalname, StringUtil.LTrimStr( (decimal)(AV14usuariosid), 6, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID"+"_"+sGXsfl_19_idx, GetSecureSignedToken( sGXsfl_19_idx, context.localUtil.Format( (decimal)(AV14usuariosid), "ZZZZZ9"), context));
                              }
                              AV5NombreCompleto = cgiGet( edtavNombrecompleto_Internalname);
                              AssignAttri("", false, edtavNombrecompleto_Internalname, AV5NombreCompleto);
                              AV10UsuariosTelef = cgiGet( edtavUsuariostelef_Internalname);
                              AssignAttri("", false, edtavUsuariostelef_Internalname, AV10UsuariosTelef);
                              AV11UsuariosCorreo = cgiGet( edtavUsuarioscorreo_Internalname);
                              AssignAttri("", false, edtavUsuarioscorreo_Internalname, AV11UsuariosCorreo);
                              dynavPerfiles_id.Name = dynavPerfiles_id_Internalname;
                              dynavPerfiles_id.CurrentValue = cgiGet( dynavPerfiles_id_Internalname);
                              AV20Perfiles_Id = (int)(NumberUtil.Val( cgiGet( dynavPerfiles_id_Internalname), "."));
                              AssignAttri("", false, dynavPerfiles_id_Internalname, StringUtil.LTrimStr( (decimal)(AV20Perfiles_Id), 9, 0));
                              cmbavUsuarioidrec.Name = cmbavUsuarioidrec_Internalname;
                              cmbavUsuarioidrec.CurrentValue = cgiGet( cmbavUsuarioidrec_Internalname);
                              AV21usuarioidRec = (int)(NumberUtil.Val( cgiGet( cmbavUsuarioidrec_Internalname), "."));
                              AssignAttri("", false, cmbavUsuarioidrec_Internalname, StringUtil.LTrimStr( (decimal)(AV21usuarioidRec), 6, 0));
                              AV23Asignar = cgiGet( edtavAsignar_Internalname);
                              AssignAttri("", false, edtavAsignar_Internalname, AV23Asignar);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E112A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E122A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'ASIGNAR'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Asignar' */
                                    E132A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E142A2 ();
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

      protected void WE2A2( )
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

      protected void PA2A2( )
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

      protected void GXSGVvNOMCOMPLETO2A0( String A97UsuariosNomCompleto )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXSGVvNOMCOMPLETO_data2A0( A97UsuariosNomCompleto) ;
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

      protected void GXSGVvNOMCOMPLETO_data2A0( String A97UsuariosNomCompleto )
      {
         l97UsuariosNomCompleto = StringUtil.Concat( StringUtil.RTrim( A97UsuariosNomCompleto), "%", "");
         /* Using cursor H002A2 */
         pr_default.execute(0, new Object[] {l97UsuariosNomCompleto});
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(H002A2_A97UsuariosNomCompleto[0]);
            gxdynajaxctrldescr.Add(H002A2_A97UsuariosNomCompleto[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvPERFILES_ID2A2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvPERFILES_ID_data2A2( ) ;
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

      protected void GXVvPERFILES_ID_html2A2( )
      {
         int gxdynajaxvalue ;
         GXDLVvPERFILES_ID_data2A2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavPerfiles_id.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((String)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavPerfiles_id.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 9, 0)), ((String)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvPERFILES_ID_data2A2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H002A3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002A3_A278Perfiles_Id[0]), 9, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002A3_A279Perfiles_Nombre[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_192( ) ;
         while ( nGXsfl_19_idx <= nRC_GXsfl_19 )
         {
            sendrow_192( ) ;
            nGXsfl_19_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_19_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_19_idx+1);
            sGXsfl_19_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_19_idx), 4, 0), 4, "0");
            SubsflControlProps_192( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        short A286UsuariosStatus ,
                                        short A272UsuariosTipo ,
                                        int A11UsuariosId ,
                                        String A97UsuariosNomCompleto ,
                                        String AV23Asignar ,
                                        int AV21usuarioidRec ,
                                        String AV15NomCompleto ,
                                        String A260UsuariosTelef ,
                                        String A261UsuariosCorreo ,
                                        short A283PerfilesUsuariosEstatus ,
                                        int A278Perfiles_Id )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E142A2 ();
         GRID1_nCurrentRecord = 0;
         RF2A2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14usuariosid), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14usuariosid), 6, 0, ".", "")));
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
         RF2A2( ) ;
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
         AssignProp("", false, edtavUsuariosid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuariosid_Enabled), 5, 0), !bGXsfl_19_Refreshing);
         edtavNombrecompleto_Enabled = 0;
         AssignProp("", false, edtavNombrecompleto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNombrecompleto_Enabled), 5, 0), !bGXsfl_19_Refreshing);
         edtavUsuariostelef_Enabled = 0;
         AssignProp("", false, edtavUsuariostelef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuariostelef_Enabled), 5, 0), !bGXsfl_19_Refreshing);
         edtavUsuarioscorreo_Enabled = 0;
         AssignProp("", false, edtavUsuarioscorreo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuarioscorreo_Enabled), 5, 0), !bGXsfl_19_Refreshing);
         dynavPerfiles_id.Enabled = 0;
         AssignProp("", false, dynavPerfiles_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavPerfiles_id.Enabled), 5, 0), !bGXsfl_19_Refreshing);
         edtavAsignar_Enabled = 0;
         AssignProp("", false, edtavAsignar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAsignar_Enabled), 5, 0), !bGXsfl_19_Refreshing);
      }

      protected void RF2A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 19;
         /* Execute user event: Refresh */
         E142A2 ();
         nGXsfl_19_idx = 1;
         sGXsfl_19_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_19_idx), 4, 0), 4, "0");
         SubsflControlProps_192( ) ;
         bGXsfl_19_Refreshing = true;
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
            SubsflControlProps_192( ) ;
            E122A2 ();
            if ( ( GRID1_nCurrentRecord > 0 ) && ( GRID1_nGridOutOfScope == 0 ) && ( nGXsfl_19_idx == 1 ) )
            {
               GRID1_nCurrentRecord = 0;
               GRID1_nGridOutOfScope = 1;
               subgrid1_firstpage( ) ;
               E122A2 ();
            }
            wbEnd = 19;
            WB2A0( ) ;
         }
         bGXsfl_19_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2A2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID"+"_"+sGXsfl_19_idx, GetSecureSignedToken( sGXsfl_19_idx, context.localUtil.Format( (decimal)(AV14usuariosid), "ZZZZZ9"), context));
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
            gxgrGrid1_refresh( subGrid1_Rows, A286UsuariosStatus, A272UsuariosTipo, A11UsuariosId, A97UsuariosNomCompleto, AV23Asignar, AV21usuarioidRec, AV15NomCompleto, A260UsuariosTelef, A261UsuariosCorreo, A283PerfilesUsuariosEstatus, A278Perfiles_Id) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, A286UsuariosStatus, A272UsuariosTipo, A11UsuariosId, A97UsuariosNomCompleto, AV23Asignar, AV21usuarioidRec, AV15NomCompleto, A260UsuariosTelef, A261UsuariosCorreo, A283PerfilesUsuariosEstatus, A278Perfiles_Id) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, A286UsuariosStatus, A272UsuariosTipo, A11UsuariosId, A97UsuariosNomCompleto, AV23Asignar, AV21usuarioidRec, AV15NomCompleto, A260UsuariosTelef, A261UsuariosCorreo, A283PerfilesUsuariosEstatus, A278Perfiles_Id) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         subGrid1_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, A286UsuariosStatus, A272UsuariosTipo, A11UsuariosId, A97UsuariosNomCompleto, AV23Asignar, AV21usuarioidRec, AV15NomCompleto, A260UsuariosTelef, A261UsuariosCorreo, A283PerfilesUsuariosEstatus, A278Perfiles_Id) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, A286UsuariosStatus, A272UsuariosTipo, A11UsuariosId, A97UsuariosNomCompleto, AV23Asignar, AV21usuarioidRec, AV15NomCompleto, A260UsuariosTelef, A261UsuariosCorreo, A283PerfilesUsuariosEstatus, A278Perfiles_Id) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavUsuariosid_Enabled = 0;
         AssignProp("", false, edtavUsuariosid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuariosid_Enabled), 5, 0), !bGXsfl_19_Refreshing);
         edtavNombrecompleto_Enabled = 0;
         AssignProp("", false, edtavNombrecompleto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNombrecompleto_Enabled), 5, 0), !bGXsfl_19_Refreshing);
         edtavUsuariostelef_Enabled = 0;
         AssignProp("", false, edtavUsuariostelef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuariostelef_Enabled), 5, 0), !bGXsfl_19_Refreshing);
         edtavUsuarioscorreo_Enabled = 0;
         AssignProp("", false, edtavUsuarioscorreo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuarioscorreo_Enabled), 5, 0), !bGXsfl_19_Refreshing);
         dynavPerfiles_id.Enabled = 0;
         AssignProp("", false, dynavPerfiles_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavPerfiles_id.Enabled), 5, 0), !bGXsfl_19_Refreshing);
         edtavAsignar_Enabled = 0;
         AssignProp("", false, edtavAsignar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAsignar_Enabled), 5, 0), !bGXsfl_19_Refreshing);
         GXVvPERFILES_ID_html2A2( ) ;
      }

      protected void STRUP2A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112A2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vALERTPROPERTIES"), AV24AlertProperties);
            /* Read saved values. */
            nRC_GXsfl_19 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_19"), ",", "."));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ",", "."));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ",", "."));
            subGrid1_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID1_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV15NomCompleto = cgiGet( edtavNomcompleto_Internalname);
            AssignAttri("", false, "AV15NomCompleto", AV15NomCompleto);
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
         E112A2 ();
         if (returnInSub) return;
      }

      protected void E112A2( )
      {
         /* Start Routine */
         cmbavUsuarioidrec.Enabled = 1;
         AssignProp("", false, cmbavUsuarioidrec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuarioidrec.Enabled), 5, 0), !bGXsfl_19_Refreshing);
         subGrid1_Rows = 20;
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         AV23Asignar = "Asignar";
         AssignAttri("", false, edtavAsignar_Internalname, AV23Asignar);
         /* Using cursor H002A4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A272UsuariosTipo = H002A4_A272UsuariosTipo[0];
            A286UsuariosStatus = H002A4_A286UsuariosStatus[0];
            A11UsuariosId = H002A4_A11UsuariosId[0];
            A64UsuariosApMat = H002A4_A64UsuariosApMat[0];
            A65UsuariosApPat = H002A4_A65UsuariosApPat[0];
            A66UsuariosNombre = H002A4_A66UsuariosNombre[0];
            A97UsuariosNomCompleto = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + StringUtil.Trim( A64UsuariosApMat);
            AssignAttri("", false, "A97UsuariosNomCompleto", A97UsuariosNomCompleto);
            cmbavUsuarioidrec.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A11UsuariosId), 6, 0)), A97UsuariosNomCompleto, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      private void E122A2( )
      {
         /* Grid1_Load Routine */
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV15NomCompleto ,
                                              A66UsuariosNombre ,
                                              A65UsuariosApPat ,
                                              A64UsuariosApMat ,
                                              A272UsuariosTipo ,
                                              A286UsuariosStatus } ,
                                              new int[]{
                                              TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         } ) ;
         lV15NomCompleto = StringUtil.Concat( StringUtil.RTrim( AV15NomCompleto), "%", "");
         /* Using cursor H002A5 */
         pr_default.execute(3, new Object[] {lV15NomCompleto});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A272UsuariosTipo = H002A5_A272UsuariosTipo[0];
            A286UsuariosStatus = H002A5_A286UsuariosStatus[0];
            A260UsuariosTelef = H002A5_A260UsuariosTelef[0];
            A261UsuariosCorreo = H002A5_A261UsuariosCorreo[0];
            A11UsuariosId = H002A5_A11UsuariosId[0];
            A64UsuariosApMat = H002A5_A64UsuariosApMat[0];
            A65UsuariosApPat = H002A5_A65UsuariosApPat[0];
            A66UsuariosNombre = H002A5_A66UsuariosNombre[0];
            A97UsuariosNomCompleto = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + StringUtil.Trim( A64UsuariosApMat);
            AssignAttri("", false, "A97UsuariosNomCompleto", A97UsuariosNomCompleto);
            AV5NombreCompleto = A97UsuariosNomCompleto;
            AssignAttri("", false, edtavNombrecompleto_Internalname, AV5NombreCompleto);
            AV10UsuariosTelef = A260UsuariosTelef;
            AssignAttri("", false, edtavUsuariostelef_Internalname, AV10UsuariosTelef);
            AV11UsuariosCorreo = A261UsuariosCorreo;
            AssignAttri("", false, edtavUsuarioscorreo_Internalname, AV11UsuariosCorreo);
            AV14usuariosid = A11UsuariosId;
            AssignAttri("", false, edtavUsuariosid_Internalname, StringUtil.LTrimStr( (decimal)(AV14usuariosid), 6, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID"+"_"+sGXsfl_19_idx, GetSecureSignedToken( sGXsfl_19_idx, context.localUtil.Format( (decimal)(AV14usuariosid), "ZZZZZ9"), context));
            AV29GXLvl27 = 0;
            /* Using cursor H002A6 */
            pr_default.execute(4, new Object[] {AV14usuariosid});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A283PerfilesUsuariosEstatus = H002A6_A283PerfilesUsuariosEstatus[0];
               A11UsuariosId = H002A6_A11UsuariosId[0];
               A278Perfiles_Id = H002A6_A278Perfiles_Id[0];
               AV29GXLvl27 = 1;
               AV20Perfiles_Id = A278Perfiles_Id;
               AssignAttri("", false, dynavPerfiles_id_Internalname, StringUtil.LTrimStr( (decimal)(AV20Perfiles_Id), 9, 0));
               dynavPerfiles_id.Enabled = 0;
               pr_default.readNext(4);
            }
            pr_default.close(4);
            if ( AV29GXLvl27 == 0 )
            {
               AV20Perfiles_Id = 99999999;
               AssignAttri("", false, dynavPerfiles_id_Internalname, StringUtil.LTrimStr( (decimal)(AV20Perfiles_Id), 9, 0));
            }
            AV13vacantes_nombre = context.GetImagePath( "098e55ac-16ee-4aaf-9d49-dc22f82408fb", "", context.GetTheme( ));
            AssignAttri("", false, edtavVacantes_nombre_Internalname, AV13vacantes_nombre);
            AV30Vacantes_nombre_GXI = GXDbFile.PathToUrl( context.GetImagePath( "098e55ac-16ee-4aaf-9d49-dc22f82408fb", "", context.GetTheme( )));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 19;
            }
            if ( ( subGrid1_Islastpage == 1 ) || ( subGrid1_Rows == 0 ) || ( ( GRID1_nCurrentRecord >= GRID1_nFirstRecordOnPage ) && ( GRID1_nCurrentRecord < GRID1_nFirstRecordOnPage + subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_192( ) ;
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
            if ( isFullAjaxMode( ) && ! bGXsfl_19_Refreshing )
            {
               context.DoAjaxLoad(19, Grid1Row);
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
         /*  Sending Event outputs  */
         dynavPerfiles_id.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20Perfiles_Id), 9, 0));
      }

      protected void E132A2( )
      {
         /* 'Asignar' Routine */
         if ( (0==AV21usuarioidRec) )
         {
            GXt_SdtPropiedades1 = AV24AlertProperties;
            new getsweetmessage(context ).execute(  "error",  "Seleccione un reclutador",  "",  true,  false, out  GXt_SdtPropiedades1) ;
            AV24AlertProperties = GXt_SdtPropiedades1;
            this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
         }
         else
         {
            new pr_cambtipo(context ).execute(  AV14usuariosid,  AV21usuarioidRec,  "Postulacion") ;
            GXt_SdtPropiedades1 = AV24AlertProperties;
            new getsweetmessage(context ).execute(  "success",  "Prospecto enviado al reclutador",  "",  true,  false, out  GXt_SdtPropiedades1) ;
            AV24AlertProperties = GXt_SdtPropiedades1;
            this.executeUsercontrolMethod("", false, "UCALERTASContainer", "showAlert", "", new Object[] {});
            AV21usuarioidRec = 0;
            AssignAttri("", false, cmbavUsuarioidrec_Internalname, StringUtil.LTrimStr( (decimal)(AV21usuarioidRec), 6, 0));
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         cmbavUsuarioidrec.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21usuarioidRec), 6, 0));
         AssignProp("", false, cmbavUsuarioidrec_Internalname, "Values", cmbavUsuarioidrec.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24AlertProperties", AV24AlertProperties);
      }

      protected void E142A2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         /* Using cursor H002A7 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            A272UsuariosTipo = H002A7_A272UsuariosTipo[0];
            A286UsuariosStatus = H002A7_A286UsuariosStatus[0];
            A11UsuariosId = H002A7_A11UsuariosId[0];
            A64UsuariosApMat = H002A7_A64UsuariosApMat[0];
            A65UsuariosApPat = H002A7_A65UsuariosApPat[0];
            A66UsuariosNombre = H002A7_A66UsuariosNombre[0];
            A97UsuariosNomCompleto = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + StringUtil.Trim( A64UsuariosApMat);
            AssignAttri("", false, "A97UsuariosNomCompleto", A97UsuariosNomCompleto);
            cmbavUsuarioidrec.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A11UsuariosId), 6, 0)), A97UsuariosNomCompleto, 0);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         /*  Sending Event outputs  */
         cmbavUsuarioidrec.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21usuarioidRec), 6, 0));
         AssignProp("", false, cmbavUsuarioidrec_Internalname, "Values", cmbavUsuarioidrec.ToJavascriptSource(), true);
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
         PA2A2( ) ;
         WS2A2( ) ;
         WE2A2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714345148", true, true);
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
            context.AddJavascriptSource("wppostulacion.js", "?202262714345148", false, true);
            context.AddJavascriptSource("SweetAlert2/sweetalert2.all.min.js", "", false, true);
            context.AddJavascriptSource("SweetAlert2/SweetAlert2Render.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_192( )
      {
         edtavVacantes_nombre_Internalname = "vVACANTES_NOMBRE_"+sGXsfl_19_idx;
         edtavUsuariosid_Internalname = "vUSUARIOSID_"+sGXsfl_19_idx;
         edtavNombrecompleto_Internalname = "vNOMBRECOMPLETO_"+sGXsfl_19_idx;
         edtavUsuariostelef_Internalname = "vUSUARIOSTELEF_"+sGXsfl_19_idx;
         edtavUsuarioscorreo_Internalname = "vUSUARIOSCORREO_"+sGXsfl_19_idx;
         dynavPerfiles_id_Internalname = "vPERFILES_ID_"+sGXsfl_19_idx;
         cmbavUsuarioidrec_Internalname = "vUSUARIOIDREC_"+sGXsfl_19_idx;
         edtavAsignar_Internalname = "vASIGNAR_"+sGXsfl_19_idx;
      }

      protected void SubsflControlProps_fel_192( )
      {
         edtavVacantes_nombre_Internalname = "vVACANTES_NOMBRE_"+sGXsfl_19_fel_idx;
         edtavUsuariosid_Internalname = "vUSUARIOSID_"+sGXsfl_19_fel_idx;
         edtavNombrecompleto_Internalname = "vNOMBRECOMPLETO_"+sGXsfl_19_fel_idx;
         edtavUsuariostelef_Internalname = "vUSUARIOSTELEF_"+sGXsfl_19_fel_idx;
         edtavUsuarioscorreo_Internalname = "vUSUARIOSCORREO_"+sGXsfl_19_fel_idx;
         dynavPerfiles_id_Internalname = "vPERFILES_ID_"+sGXsfl_19_fel_idx;
         cmbavUsuarioidrec_Internalname = "vUSUARIOIDREC_"+sGXsfl_19_fel_idx;
         edtavAsignar_Internalname = "vASIGNAR_"+sGXsfl_19_fel_idx;
      }

      protected void sendrow_192( )
      {
         SubsflControlProps_192( ) ;
         WB2A0( ) ;
         if ( ( subGrid1_Rows * 1 == 0 ) || ( nGXsfl_19_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_19_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_19_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV13vacantes_nombre_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV13vacantes_nombre))&&String.IsNullOrEmpty(StringUtil.RTrim( AV30Vacantes_nombre_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV13vacantes_nombre)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV13vacantes_nombre)) ? AV30Vacantes_nombre_GXI : context.PathToRelativeUrl( AV13vacantes_nombre));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavVacantes_nombre_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)-1,(short)0,(String)"",(String)"",(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"WWColumn",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV13vacantes_nombre_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavUsuariosid_Enabled!=0)&&(edtavUsuariosid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 21,'',false,'"+sGXsfl_19_idx+"',19)\"" : " ");
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavUsuariosid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14usuariosid), 6, 0, ",", "")),((edtavUsuariosid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV14usuariosid), "ZZZZZ9")) : context.localUtil.Format( (decimal)(AV14usuariosid), "ZZZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+((edtavUsuariosid_Enabled!=0)&&(edtavUsuariosid_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,21);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavUsuariosid_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)0,(int)edtavUsuariosid_Enabled,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)6,(short)0,(short)0,(short)19,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavNombrecompleto_Enabled!=0)&&(edtavNombrecompleto_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 22,'',false,'"+sGXsfl_19_idx+"',19)\"" : " ");
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavNombrecompleto_Internalname,(String)AV5NombreCompleto,(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavNombrecompleto_Enabled!=0)&&(edtavNombrecompleto_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,22);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavNombrecompleto_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(short)-1,(int)edtavNombrecompleto_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)40,(short)0,(short)0,(short)19,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavUsuariostelef_Enabled!=0)&&(edtavUsuariostelef_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 23,'',false,'"+sGXsfl_19_idx+"',19)\"" : " ");
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavUsuariostelef_Internalname,StringUtil.RTrim( AV10UsuariosTelef),(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavUsuariostelef_Enabled!=0)&&(edtavUsuariostelef_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,23);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavUsuariostelef_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(int)edtavUsuariostelef_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)19,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavUsuarioscorreo_Enabled!=0)&&(edtavUsuarioscorreo_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 24,'',false,'"+sGXsfl_19_idx+"',19)\"" : " ");
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavUsuarioscorreo_Internalname,(String)AV11UsuariosCorreo,(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavUsuarioscorreo_Enabled!=0)&&(edtavUsuarioscorreo_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,24);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavUsuarioscorreo_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(int)edtavUsuarioscorreo_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)100,(short)0,(short)0,(short)19,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            GXVvPERFILES_ID_html2A2( ) ;
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((dynavPerfiles_id.Enabled!=0)&&(dynavPerfiles_id.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 25,'',false,'"+sGXsfl_19_idx+"',19)\"" : " ");
            GXCCtl = "vPERFILES_ID_" + sGXsfl_19_idx;
            dynavPerfiles_id.Name = GXCCtl;
            dynavPerfiles_id.WebTags = "";
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynavPerfiles_id,(String)dynavPerfiles_id_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV20Perfiles_Id), 9, 0)),(short)1,(String)dynavPerfiles_id_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,dynavPerfiles_id.Enabled,(short)1,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute",(String)"WWColumn WWOptionalColumn",(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((dynavPerfiles_id.Enabled!=0)&&(dynavPerfiles_id.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,25);\"" : " "),(String)"",(bool)true});
            dynavPerfiles_id.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20Perfiles_Id), 9, 0));
            AssignProp("", false, dynavPerfiles_id_Internalname, "Values", (String)(dynavPerfiles_id.ToJavascriptSource()), !bGXsfl_19_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((cmbavUsuarioidrec.Enabled!=0)&&(cmbavUsuarioidrec.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 26,'',false,'"+sGXsfl_19_idx+"',19)\"" : " ");
            GXCCtl = "vUSUARIOIDREC_" + sGXsfl_19_idx;
            cmbavUsuarioidrec.Name = GXCCtl;
            cmbavUsuarioidrec.WebTags = "";
            cmbavUsuarioidrec.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 6, 0)), "Seleccione", 0);
            if ( cmbavUsuarioidrec.ItemCount > 0 )
            {
               AV21usuarioidRec = (int)(NumberUtil.Val( cmbavUsuarioidrec.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21usuarioidRec), 6, 0))), "."));
               AssignAttri("", false, cmbavUsuarioidrec_Internalname, StringUtil.LTrimStr( (decimal)(AV21usuarioidRec), 6, 0));
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavUsuarioidrec,(String)cmbavUsuarioidrec_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV21usuarioidRec), 6, 0)),(short)1,(String)cmbavUsuarioidrec_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,cmbavUsuarioidrec.Enabled,(short)1,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute",(String)"WWColumn",(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavUsuarioidrec.Enabled!=0)&&(cmbavUsuarioidrec.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,26);\"" : " "),(String)"",(bool)true});
            cmbavUsuarioidrec.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21usuarioidRec), 6, 0));
            AssignProp("", false, cmbavUsuarioidrec_Internalname, "Values", (String)(cmbavUsuarioidrec.ToJavascriptSource()), !bGXsfl_19_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavAsignar_Enabled!=0)&&(edtavAsignar_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 27,'',false,'"+sGXsfl_19_idx+"',19)\"" : " ");
            ROClassString = "TextActionAttribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavAsignar_Internalname,StringUtil.RTrim( AV23Asignar),(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavAsignar_Enabled!=0)&&(edtavAsignar_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,27);\"" : " "),"'"+""+"'"+",false,"+"'"+"E\\'ASIGNAR\\'."+sGXsfl_19_idx+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavAsignar_Jsonclick,(short)5,(String)"TextActionAttribute",(String)"",(String)ROClassString,(String)"WWTextActionColumn",(String)"",(short)-1,(int)edtavAsignar_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)20,(short)0,(short)0,(short)19,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            send_integrity_lvl_hashes2A2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_19_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_19_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_19_idx+1);
            sGXsfl_19_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_19_idx), 4, 0), 4, "0");
            SubsflControlProps_192( ) ;
         }
         /* End function sendrow_192 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vPERFILES_ID_" + sGXsfl_19_idx;
         dynavPerfiles_id.Name = GXCCtl;
         dynavPerfiles_id.WebTags = "";
         GXCCtl = "vUSUARIOIDREC_" + sGXsfl_19_idx;
         cmbavUsuarioidrec.Name = GXCCtl;
         cmbavUsuarioidrec.WebTags = "";
         cmbavUsuarioidrec.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 6, 0)), "Seleccione", 0);
         if ( cmbavUsuarioidrec.ItemCount > 0 )
         {
            AV21usuarioidRec = (int)(NumberUtil.Val( cmbavUsuarioidrec.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21usuarioidRec), 6, 0))), "."));
            AssignAttri("", false, cmbavUsuarioidrec_Internalname, StringUtil.LTrimStr( (decimal)(AV21usuarioidRec), 6, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitletext_Internalname = "TITLETEXT";
         edtavNomcompleto_Internalname = "vNOMCOMPLETO";
         edtavVacantes_nombre_Internalname = "vVACANTES_NOMBRE";
         edtavUsuariosid_Internalname = "vUSUARIOSID";
         edtavNombrecompleto_Internalname = "vNOMBRECOMPLETO";
         edtavUsuariostelef_Internalname = "vUSUARIOSTELEF";
         edtavUsuarioscorreo_Internalname = "vUSUARIOSCORREO";
         dynavPerfiles_id_Internalname = "vPERFILES_ID";
         cmbavUsuarioidrec_Internalname = "vUSUARIOIDREC";
         edtavAsignar_Internalname = "vASIGNAR";
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
         edtavAsignar_Jsonclick = "";
         edtavAsignar_Visible = -1;
         cmbavUsuarioidrec_Jsonclick = "";
         cmbavUsuarioidrec.Visible = -1;
         dynavPerfiles_id_Jsonclick = "";
         dynavPerfiles_id.Visible = -1;
         edtavUsuarioscorreo_Jsonclick = "";
         edtavUsuarioscorreo_Visible = -1;
         edtavUsuariostelef_Jsonclick = "";
         edtavUsuariostelef_Visible = -1;
         edtavNombrecompleto_Jsonclick = "";
         edtavNombrecompleto_Visible = -1;
         edtavUsuariosid_Jsonclick = "";
         edtavUsuariosid_Visible = 0;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtavAsignar_Enabled = 1;
         dynavPerfiles_id.Enabled = 1;
         edtavUsuarioscorreo_Enabled = 1;
         edtavUsuariostelef_Enabled = 1;
         edtavNombrecompleto_Enabled = 1;
         edtavUsuariosid_Enabled = 1;
         subGrid1_Class = "WorkWith";
         subGrid1_Backcolorstyle = 0;
         edtavNomcompleto_Jsonclick = "";
         edtavNomcompleto_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Postulaciones de Usuarios";
         subGrid1_Rows = 10;
         cmbavUsuarioidrec.Enabled = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'cmbavUsuarioidrec'},{av:'AV23Asignar',fld:'vASIGNAR',pic:''},{av:'AV15NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'A260UsuariosTelef',fld:'USUARIOSTELEF',pic:''},{av:'A261UsuariosCorreo',fld:'USUARIOSCORREO',pic:''},{av:'A283PerfilesUsuariosEstatus',fld:'PERFILESUSUARIOSESTATUS',pic:'9'},{av:'A278Perfiles_Id',fld:'PERFILES_ID',pic:'ZZZZZZZZ9'},{av:'A286UsuariosStatus',fld:'USUARIOSSTATUS',pic:'9'},{av:'A272UsuariosTipo',fld:'USUARIOSTIPO',pic:'ZZZ9'},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A97UsuariosNomCompleto',fld:'USUARIOSNOMCOMPLETO',pic:''},{av:'AV21usuarioidRec',fld:'vUSUARIOIDREC',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'cmbavUsuarioidrec'},{av:'AV21usuarioidRec',fld:'vUSUARIOIDREC',pic:'ZZZZZ9'}]}");
         setEventMetadata("GRID1.LOAD","{handler:'E122A2',iparms:[{av:'A272UsuariosTipo',fld:'USUARIOSTIPO',pic:'ZZZ9'},{av:'A286UsuariosStatus',fld:'USUARIOSSTATUS',pic:'9'},{av:'A97UsuariosNomCompleto',fld:'USUARIOSNOMCOMPLETO',pic:''},{av:'AV15NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'A260UsuariosTelef',fld:'USUARIOSTELEF',pic:''},{av:'A261UsuariosCorreo',fld:'USUARIOSCORREO',pic:''},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A283PerfilesUsuariosEstatus',fld:'PERFILESUSUARIOSESTATUS',pic:'9'},{av:'A278Perfiles_Id',fld:'PERFILES_ID',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("GRID1.LOAD",",oparms:[{av:'AV5NombreCompleto',fld:'vNOMBRECOMPLETO',pic:''},{av:'AV10UsuariosTelef',fld:'vUSUARIOSTELEF',pic:''},{av:'AV11UsuariosCorreo',fld:'vUSUARIOSCORREO',pic:''},{av:'AV14usuariosid',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true},{av:'dynavPerfiles_id'},{av:'AV20Perfiles_Id',fld:'vPERFILES_ID',pic:'ZZZZZZZZ9'},{av:'AV13vacantes_nombre',fld:'vVACANTES_NOMBRE',pic:''}]}");
         setEventMetadata("'ASIGNAR'","{handler:'E132A2',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'A286UsuariosStatus',fld:'USUARIOSSTATUS',pic:'9'},{av:'A272UsuariosTipo',fld:'USUARIOSTIPO',pic:'ZZZ9'},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A97UsuariosNomCompleto',fld:'USUARIOSNOMCOMPLETO',pic:''},{av:'cmbavUsuarioidrec'},{av:'AV23Asignar',fld:'vASIGNAR',pic:''},{av:'AV21usuarioidRec',fld:'vUSUARIOIDREC',pic:'ZZZZZ9'},{av:'AV15NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'A260UsuariosTelef',fld:'USUARIOSTELEF',pic:''},{av:'A261UsuariosCorreo',fld:'USUARIOSCORREO',pic:''},{av:'A283PerfilesUsuariosEstatus',fld:'PERFILESUSUARIOSESTATUS',pic:'9'},{av:'A278Perfiles_Id',fld:'PERFILES_ID',pic:'ZZZZZZZZ9'},{av:'AV14usuariosid',fld:'vUSUARIOSID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("'ASIGNAR'",",oparms:[{av:'cmbavUsuarioidrec'},{av:'AV21usuarioidRec',fld:'vUSUARIOIDREC',pic:'ZZZZZ9'},{av:'AV24AlertProperties',fld:'vALERTPROPERTIES',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'cmbavUsuarioidrec'},{av:'AV23Asignar',fld:'vASIGNAR',pic:''},{av:'AV15NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'A260UsuariosTelef',fld:'USUARIOSTELEF',pic:''},{av:'A261UsuariosCorreo',fld:'USUARIOSCORREO',pic:''},{av:'A283PerfilesUsuariosEstatus',fld:'PERFILESUSUARIOSESTATUS',pic:'9'},{av:'A278Perfiles_Id',fld:'PERFILES_ID',pic:'ZZZZZZZZ9'},{av:'A286UsuariosStatus',fld:'USUARIOSSTATUS',pic:'9'},{av:'A272UsuariosTipo',fld:'USUARIOSTIPO',pic:'ZZZ9'},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A97UsuariosNomCompleto',fld:'USUARIOSNOMCOMPLETO',pic:''},{av:'AV21usuarioidRec',fld:'vUSUARIOIDREC',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[{av:'cmbavUsuarioidrec'},{av:'AV21usuarioidRec',fld:'vUSUARIOIDREC',pic:'ZZZZZ9'}]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'cmbavUsuarioidrec'},{av:'AV23Asignar',fld:'vASIGNAR',pic:''},{av:'AV15NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'A260UsuariosTelef',fld:'USUARIOSTELEF',pic:''},{av:'A261UsuariosCorreo',fld:'USUARIOSCORREO',pic:''},{av:'A283PerfilesUsuariosEstatus',fld:'PERFILESUSUARIOSESTATUS',pic:'9'},{av:'A278Perfiles_Id',fld:'PERFILES_ID',pic:'ZZZZZZZZ9'},{av:'A286UsuariosStatus',fld:'USUARIOSSTATUS',pic:'9'},{av:'A272UsuariosTipo',fld:'USUARIOSTIPO',pic:'ZZZ9'},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A97UsuariosNomCompleto',fld:'USUARIOSNOMCOMPLETO',pic:''},{av:'AV21usuarioidRec',fld:'vUSUARIOIDREC',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[{av:'cmbavUsuarioidrec'},{av:'AV21usuarioidRec',fld:'vUSUARIOIDREC',pic:'ZZZZZ9'}]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'cmbavUsuarioidrec'},{av:'AV23Asignar',fld:'vASIGNAR',pic:''},{av:'AV15NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'A260UsuariosTelef',fld:'USUARIOSTELEF',pic:''},{av:'A261UsuariosCorreo',fld:'USUARIOSCORREO',pic:''},{av:'A283PerfilesUsuariosEstatus',fld:'PERFILESUSUARIOSESTATUS',pic:'9'},{av:'A278Perfiles_Id',fld:'PERFILES_ID',pic:'ZZZZZZZZ9'},{av:'A286UsuariosStatus',fld:'USUARIOSSTATUS',pic:'9'},{av:'A272UsuariosTipo',fld:'USUARIOSTIPO',pic:'ZZZ9'},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A97UsuariosNomCompleto',fld:'USUARIOSNOMCOMPLETO',pic:''},{av:'AV21usuarioidRec',fld:'vUSUARIOIDREC',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[{av:'cmbavUsuarioidrec'},{av:'AV21usuarioidRec',fld:'vUSUARIOIDREC',pic:'ZZZZZ9'}]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'cmbavUsuarioidrec'},{av:'AV23Asignar',fld:'vASIGNAR',pic:''},{av:'AV15NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'A260UsuariosTelef',fld:'USUARIOSTELEF',pic:''},{av:'A261UsuariosCorreo',fld:'USUARIOSCORREO',pic:''},{av:'A283PerfilesUsuariosEstatus',fld:'PERFILESUSUARIOSESTATUS',pic:'9'},{av:'A278Perfiles_Id',fld:'PERFILES_ID',pic:'ZZZZZZZZ9'},{av:'A286UsuariosStatus',fld:'USUARIOSSTATUS',pic:'9'},{av:'A272UsuariosTipo',fld:'USUARIOSTIPO',pic:'ZZZ9'},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A97UsuariosNomCompleto',fld:'USUARIOSNOMCOMPLETO',pic:''},{av:'AV21usuarioidRec',fld:'vUSUARIOIDREC',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[{av:'cmbavUsuarioidrec'},{av:'AV21usuarioidRec',fld:'vUSUARIOIDREC',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALIDV_USUARIOSID","{handler:'Validv_Usuariosid',iparms:[]");
         setEventMetadata("VALIDV_USUARIOSID",",oparms:[]}");
         setEventMetadata("VALIDV_USUARIOSCORREO","{handler:'Validv_Usuarioscorreo',iparms:[]");
         setEventMetadata("VALIDV_USUARIOSCORREO",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Asignar',iparms:[]");
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
         AV23Asignar = "";
         AV15NomCompleto = "";
         A260UsuariosTelef = "";
         A261UsuariosCorreo = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV24AlertProperties = new SdtPropiedades(context);
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
         AV13vacantes_nombre = "";
         AV5NombreCompleto = "";
         AV10UsuariosTelef = "";
         AV11UsuariosCorreo = "";
         ucUcalertas = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV30Vacantes_nombre_GXI = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         l97UsuariosNomCompleto = "";
         H002A2_A97UsuariosNomCompleto = new String[] {""} ;
         H002A3_A278Perfiles_Id = new int[1] ;
         H002A3_A279Perfiles_Nombre = new String[] {""} ;
         H002A3_A280Perfiles_Estatus = new short[1] ;
         H002A4_A272UsuariosTipo = new short[1] ;
         H002A4_A286UsuariosStatus = new short[1] ;
         H002A4_A11UsuariosId = new int[1] ;
         H002A4_A64UsuariosApMat = new String[] {""} ;
         H002A4_A65UsuariosApPat = new String[] {""} ;
         H002A4_A66UsuariosNombre = new String[] {""} ;
         lV15NomCompleto = "";
         H002A5_A272UsuariosTipo = new short[1] ;
         H002A5_A286UsuariosStatus = new short[1] ;
         H002A5_A260UsuariosTelef = new String[] {""} ;
         H002A5_A261UsuariosCorreo = new String[] {""} ;
         H002A5_A11UsuariosId = new int[1] ;
         H002A5_A64UsuariosApMat = new String[] {""} ;
         H002A5_A65UsuariosApPat = new String[] {""} ;
         H002A5_A66UsuariosNombre = new String[] {""} ;
         H002A6_A283PerfilesUsuariosEstatus = new short[1] ;
         H002A6_A11UsuariosId = new int[1] ;
         H002A6_A278Perfiles_Id = new int[1] ;
         Grid1Row = new GXWebRow();
         GXt_SdtPropiedades1 = new SdtPropiedades(context);
         H002A7_A272UsuariosTipo = new short[1] ;
         H002A7_A286UsuariosStatus = new short[1] ;
         H002A7_A11UsuariosId = new int[1] ;
         H002A7_A64UsuariosApMat = new String[] {""} ;
         H002A7_A65UsuariosApPat = new String[] {""} ;
         H002A7_A66UsuariosNombre = new String[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wppostulacion__default(),
            new Object[][] {
                new Object[] {
               H002A2_A97UsuariosNomCompleto
               }
               , new Object[] {
               H002A3_A278Perfiles_Id, H002A3_A279Perfiles_Nombre, H002A3_A280Perfiles_Estatus
               }
               , new Object[] {
               H002A4_A272UsuariosTipo, H002A4_A286UsuariosStatus, H002A4_A11UsuariosId, H002A4_A64UsuariosApMat, H002A4_A65UsuariosApPat, H002A4_A66UsuariosNombre
               }
               , new Object[] {
               H002A5_A272UsuariosTipo, H002A5_A286UsuariosStatus, H002A5_A260UsuariosTelef, H002A5_A261UsuariosCorreo, H002A5_A11UsuariosId, H002A5_A64UsuariosApMat, H002A5_A65UsuariosApPat, H002A5_A66UsuariosNombre
               }
               , new Object[] {
               H002A6_A283PerfilesUsuariosEstatus, H002A6_A11UsuariosId, H002A6_A278Perfiles_Id
               }
               , new Object[] {
               H002A7_A272UsuariosTipo, H002A7_A286UsuariosStatus, H002A7_A11UsuariosId, H002A7_A64UsuariosApMat, H002A7_A65UsuariosApPat, H002A7_A66UsuariosNombre
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavUsuariosid_Enabled = 0;
         edtavNombrecompleto_Enabled = 0;
         edtavUsuariostelef_Enabled = 0;
         edtavUsuarioscorreo_Enabled = 0;
         dynavPerfiles_id.Enabled = 0;
         edtavAsignar_Enabled = 0;
      }

      private short GRID1_nEOF ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short A286UsuariosStatus ;
      private short A272UsuariosTipo ;
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
      private short AV29GXLvl27 ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_19 ;
      private int nGXsfl_19_idx=1 ;
      private int AV21usuarioidRec ;
      private int subGrid1_Rows ;
      private int A11UsuariosId ;
      private int A278Perfiles_Id ;
      private int edtavNomcompleto_Enabled ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int AV14usuariosid ;
      private int edtavUsuariosid_Enabled ;
      private int edtavNombrecompleto_Enabled ;
      private int edtavUsuariostelef_Enabled ;
      private int edtavUsuarioscorreo_Enabled ;
      private int AV20Perfiles_Id ;
      private int edtavAsignar_Enabled ;
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
      private int edtavNombrecompleto_Visible ;
      private int edtavUsuariostelef_Visible ;
      private int edtavUsuarioscorreo_Visible ;
      private int edtavAsignar_Visible ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_19_idx="0001" ;
      private String cmbavUsuarioidrec_Internalname ;
      private String AV23Asignar ;
      private String A260UsuariosTelef ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String divTable1_Internalname ;
      private String lblTitletext_Internalname ;
      private String lblTitletext_Jsonclick ;
      private String edtavNomcompleto_Internalname ;
      private String TempTags ;
      private String edtavNomcompleto_Jsonclick ;
      private String ClassString ;
      private String StyleString ;
      private String sStyleString ;
      private String subGrid1_Internalname ;
      private String subGrid1_Class ;
      private String subGrid1_Linesclass ;
      private String subGrid1_Header ;
      private String AV10UsuariosTelef ;
      private String Ucalertas_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavVacantes_nombre_Internalname ;
      private String edtavUsuariosid_Internalname ;
      private String edtavNombrecompleto_Internalname ;
      private String edtavUsuariostelef_Internalname ;
      private String edtavUsuarioscorreo_Internalname ;
      private String dynavPerfiles_id_Internalname ;
      private String edtavAsignar_Internalname ;
      private String gxwrpcisep ;
      private String scmdbuf ;
      private String sGXsfl_19_fel_idx="0001" ;
      private String sImgUrl ;
      private String ROClassString ;
      private String edtavUsuariosid_Jsonclick ;
      private String edtavNombrecompleto_Jsonclick ;
      private String edtavUsuariostelef_Jsonclick ;
      private String edtavUsuarioscorreo_Jsonclick ;
      private String GXCCtl ;
      private String dynavPerfiles_id_Jsonclick ;
      private String cmbavUsuarioidrec_Jsonclick ;
      private String edtavAsignar_Jsonclick ;
      private bool entryPointCalled ;
      private bool bGXsfl_19_Refreshing=false ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV13vacantes_nombre_IsBlob ;
      private String A97UsuariosNomCompleto ;
      private String AV15NomCompleto ;
      private String A261UsuariosCorreo ;
      private String A66UsuariosNombre ;
      private String A65UsuariosApPat ;
      private String A64UsuariosApMat ;
      private String AV5NombreCompleto ;
      private String AV11UsuariosCorreo ;
      private String AV30Vacantes_nombre_GXI ;
      private String l97UsuariosNomCompleto ;
      private String lV15NomCompleto ;
      private String AV13vacantes_nombre ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXUserControl ucUcalertas ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavPerfiles_id ;
      private GXCombobox cmbavUsuarioidrec ;
      private IDataStoreProvider pr_default ;
      private String[] H002A2_A97UsuariosNomCompleto ;
      private int[] H002A3_A278Perfiles_Id ;
      private String[] H002A3_A279Perfiles_Nombre ;
      private short[] H002A3_A280Perfiles_Estatus ;
      private short[] H002A4_A272UsuariosTipo ;
      private short[] H002A4_A286UsuariosStatus ;
      private int[] H002A4_A11UsuariosId ;
      private String[] H002A4_A64UsuariosApMat ;
      private String[] H002A4_A65UsuariosApPat ;
      private String[] H002A4_A66UsuariosNombre ;
      private short[] H002A5_A272UsuariosTipo ;
      private short[] H002A5_A286UsuariosStatus ;
      private String[] H002A5_A260UsuariosTelef ;
      private String[] H002A5_A261UsuariosCorreo ;
      private int[] H002A5_A11UsuariosId ;
      private String[] H002A5_A64UsuariosApMat ;
      private String[] H002A5_A65UsuariosApPat ;
      private String[] H002A5_A66UsuariosNombre ;
      private short[] H002A6_A283PerfilesUsuariosEstatus ;
      private int[] H002A6_A11UsuariosId ;
      private int[] H002A6_A278Perfiles_Id ;
      private short[] H002A7_A272UsuariosTipo ;
      private short[] H002A7_A286UsuariosStatus ;
      private int[] H002A7_A11UsuariosId ;
      private String[] H002A7_A64UsuariosApMat ;
      private String[] H002A7_A65UsuariosApPat ;
      private String[] H002A7_A66UsuariosNombre ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private SdtPropiedades AV24AlertProperties ;
      private SdtPropiedades GXt_SdtPropiedades1 ;
   }

   public class wppostulacion__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002A5( IGxContext context ,
                                             String AV15NomCompleto ,
                                             String A66UsuariosNombre ,
                                             String A65UsuariosApPat ,
                                             String A64UsuariosApMat ,
                                             short A272UsuariosTipo ,
                                             short A286UsuariosStatus )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int2 ;
         GXv_int2 = new short [1] ;
         Object[] GXv_Object3 ;
         GXv_Object3 = new Object [2] ;
         scmdbuf = "SELECT `UsuariosTipo`, `UsuariosStatus`, `UsuariosTelef`, `UsuariosCorreo`, `UsuariosId`, `UsuariosApMat`, `UsuariosApPat`, `UsuariosNombre` FROM `Usuarios`";
         scmdbuf = scmdbuf + " WHERE (`UsuariosTipo` = 6)";
         scmdbuf = scmdbuf + " and (`UsuariosStatus` = 1)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15NomCompleto)) )
         {
            sWhereString = sWhereString + " and (CONCAT(CONCAT(CONCAT(CONCAT(RTRIM(LTRIM(`UsuariosNombre`)), ' '), RTRIM(LTRIM(`UsuariosApPat`))), ' '), RTRIM(LTRIM(`UsuariosApMat`))) like CONCAT(CONCAT('%', ?), '%'))";
         }
         else
         {
            GXv_int2[0] = 1;
         }
         scmdbuf = scmdbuf + sWhereString;
         scmdbuf = scmdbuf + " ORDER BY `UsuariosId`";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 3 :
                     return conditional_H002A5(context, (String)dynConstraints[0] , (String)dynConstraints[1] , (String)dynConstraints[2] , (String)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002A2 ;
          prmH002A2 = new Object[] {
          new Object[] {"l97UsuariosNomCompleto",System.Data.DbType.String,90,0}
          } ;
          Object[] prmH002A3 ;
          prmH002A3 = new Object[] {
          } ;
          Object[] prmH002A4 ;
          prmH002A4 = new Object[] {
          } ;
          Object[] prmH002A6 ;
          prmH002A6 = new Object[] {
          new Object[] {"AV14usuariosid",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmH002A7 ;
          prmH002A7 = new Object[] {
          } ;
          Object[] prmH002A5 ;
          prmH002A5 = new Object[] {
          new Object[] {"lV15NomCompleto",System.Data.DbType.String,40,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H002A2", "SELECT DISTINCT CONCAT(CONCAT(CONCAT(CONCAT(RTRIM(LTRIM(`UsuariosNombre`)), ' '), RTRIM(LTRIM(`UsuariosApPat`))), ' '), RTRIM(LTRIM(`UsuariosApMat`))) AS UsuariosNomCompleto FROM `Usuarios` WHERE (UPPER(CONCAT(CONCAT(CONCAT(CONCAT(RTRIM(LTRIM(`UsuariosNombre`)), ' '), RTRIM(LTRIM(`UsuariosApPat`))), ' '), RTRIM(LTRIM(`UsuariosApMat`)))) like UPPER(?)) AND (`UsuariosTipo` = 6) AND (`UsuariosStatus` = 1) ORDER BY `UsuariosNomCompleto`  LIMIT 5",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002A2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002A3", "SELECT `Perfiles_Id`, `Perfiles_Nombre`, `Perfiles_Estatus` FROM `Perfiles` WHERE `Perfiles_Estatus` = 1 ORDER BY `Perfiles_Nombre` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002A3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002A4", "SELECT `UsuariosTipo`, `UsuariosStatus`, `UsuariosId`, `UsuariosApMat`, `UsuariosApPat`, `UsuariosNombre` FROM `Usuarios` WHERE (`UsuariosStatus` = 1) AND (`UsuariosTipo` = 5) ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002A4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H002A5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002A5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002A6", "SELECT `PerfilesUsuariosEstatus`, `UsuariosId`, `Perfiles_Id` FROM `PerfilesUsuariosPerfil` WHERE (`UsuariosId` = ?) AND (`PerfilesUsuariosEstatus` = 1) ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002A6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002A7", "SELECT `UsuariosTipo`, `UsuariosStatus`, `UsuariosId`, `UsuariosApMat`, `UsuariosApPat`, `UsuariosNombre` FROM `Usuarios` WHERE (`UsuariosStatus` = 1) AND (`UsuariosTipo` = 5) ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002A7,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                ((String[]) buf[3])[0] = rslt.getVarchar(4) ;
                ((String[]) buf[4])[0] = rslt.getVarchar(5) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 10) ;
                ((String[]) buf[3])[0] = rslt.getVarchar(4) ;
                ((int[]) buf[4])[0] = rslt.getInt(5) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
                ((String[]) buf[6])[0] = rslt.getVarchar(7) ;
                ((String[]) buf[7])[0] = rslt.getVarchar(8) ;
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
                ((String[]) buf[3])[0] = rslt.getVarchar(4) ;
                ((String[]) buf[4])[0] = rslt.getVarchar(5) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
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
             case 3 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[1]);
                }
                return;
             case 4 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

}
