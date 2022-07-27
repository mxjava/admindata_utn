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
   public class wpreclusegusu : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpreclusegusu( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public wpreclusegusu( IGxContext context )
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
         dynavVacantes_id_envio = new GXCombobox();
         dynavUsuariosid = new GXCombobox();
         dynavSubt_reclutadorid = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vUSUARIOSID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvUSUARIOSID364( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vSUBT_RECLUTADORID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvSUBT_RECLUTADORID364( ) ;
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
               nRC_GXsfl_43 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_43_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_43_idx = GetNextPar( );
               edtavVacantesusuariosestatus_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignProp("", false, edtavVacantesusuariosestatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosestatus_Visible), 5, 0), !bGXsfl_21_Refreshing);
               dynavVacantes_id_envio.Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignProp("", false, dynavVacantes_id_envio_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavVacantes_id_envio.Visible), 5, 0), !bGXsfl_43_Refreshing);
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
               edtavVacantesusuariosestatus_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignProp("", false, edtavVacantesusuariosestatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosestatus_Visible), 5, 0), !bGXsfl_21_Refreshing);
               dynavVacantes_id_envio.Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignProp("", false, dynavVacantes_id_envio_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavVacantes_id_envio.Visible), 5, 0), !bGXsfl_43_Refreshing);
               A263Vacantes_Id = (int)(NumberUtil.Val( GetNextPar( ), "."));
               A290VacantesUsuariosEstatus = (short)(NumberUtil.Val( GetNextPar( ), "."));
               n290VacantesUsuariosEstatus = false;
               AV24VacantesUsuariosEstatus = (short)(NumberUtil.Val( GetNextPar( ), "."));
               A11UsuariosId = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV38UsuarioId = (int)(NumberUtil.Val( GetNextPar( ), "."));
               A260UsuariosTelef = GetNextPar( );
               A261UsuariosCorreo = GetNextPar( );
               A284SUBT_ReclutadorId = (int)(NumberUtil.Val( GetNextPar( ), "."));
               A288VacantesUsuariosFechaP = context.localUtil.ParseDTimeParm( GetNextPar( ));
               A292VacantesUsuariosCV = (short)(NumberUtil.Val( GetNextPar( ), "."));
               n292VacantesUsuariosCV = false;
               A291VacantesUsuariosPrefiltro = (short)(NumberUtil.Val( GetNextPar( ), "."));
               n291VacantesUsuariosPrefiltro = false;
               A295VacantesUsuariosFechaE = context.localUtil.ParseDTimeParm( GetNextPar( ));
               n295VacantesUsuariosFechaE = false;
               A293VacantesUsuariosExTec = (short)(NumberUtil.Val( GetNextPar( ), "."));
               n293VacantesUsuariosExTec = false;
               A314VacantesUsuariosFecha3 = context.localUtil.ParseDTimeParm( GetNextPar( ));
               n314VacantesUsuariosFecha3 = false;
               A304VacantesUsuariosAvConf = (short)(NumberUtil.Val( GetNextPar( ), "."));
               n304VacantesUsuariosAvConf = false;
               A303VacantesUsuariosAvPriv = (short)(NumberUtil.Val( GetNextPar( ), "."));
               n303VacantesUsuariosAvPriv = false;
               A302VacantesUsuariosBusWeb = (short)(NumberUtil.Val( GetNextPar( ), "."));
               n302VacantesUsuariosBusWeb = false;
               A301VacantesUsuariosExPsi = (short)(NumberUtil.Val( GetNextPar( ), "."));
               n301VacantesUsuariosExPsi = false;
               A300VacantesUsuariosRefLab = (short)(NumberUtil.Val( GetNextPar( ), "."));
               n300VacantesUsuariosRefLab = false;
               A299VacantesUsuariosCVRec = (short)(NumberUtil.Val( GetNextPar( ), "."));
               n299VacantesUsuariosCVRec = false;
               A313VacantesUsuariosFechaA = context.localUtil.ParseDTimeParm( GetNextPar( ));
               n313VacantesUsuariosFechaA = false;
               A289VacantesUsuariosFechaD = context.localUtil.ParseDTimeParm( GetNextPar( ));
               n289VacantesUsuariosFechaD = false;
               A294VacantesUsuariosMotD = GetNextPar( );
               n294VacantesUsuariosMotD = false;
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, A263Vacantes_Id, A290VacantesUsuariosEstatus, AV24VacantesUsuariosEstatus, A11UsuariosId, AV38UsuarioId, A260UsuariosTelef, A261UsuariosCorreo, A284SUBT_ReclutadorId, A288VacantesUsuariosFechaP, A292VacantesUsuariosCV, A291VacantesUsuariosPrefiltro, A295VacantesUsuariosFechaE, A293VacantesUsuariosExTec, A314VacantesUsuariosFecha3, A304VacantesUsuariosAvConf, A303VacantesUsuariosAvPriv, A302VacantesUsuariosBusWeb, A301VacantesUsuariosExPsi, A300VacantesUsuariosRefLab, A299VacantesUsuariosCVRec, A313VacantesUsuariosFechaA, A289VacantesUsuariosFechaD, A294VacantesUsuariosMotD) ;
               AddString( context.getJSONResponse( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid2") == 0 )
            {
               nRC_GXsfl_21 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_21_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_21_idx = GetNextPar( );
               edtavVacantesusuariosestatus_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignProp("", false, edtavVacantesusuariosestatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosestatus_Visible), 5, 0), !bGXsfl_21_Refreshing);
               edtVacantesUsuariosEstatus_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignProp("", false, edtVacantesUsuariosEstatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVacantesUsuariosEstatus_Visible), 5, 0), !bGXsfl_21_Refreshing);
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid2_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid2") == 0 )
            {
               subGrid1_Rows = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV38UsuarioId = (int)(NumberUtil.Val( GetNextPar( ), "."));
               edtavVacantesusuariosestatus_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignProp("", false, edtavVacantesusuariosestatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosestatus_Visible), 5, 0), !bGXsfl_21_Refreshing);
               edtVacantesUsuariosEstatus_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignProp("", false, edtVacantesUsuariosEstatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVacantesUsuariosEstatus_Visible), 5, 0), !bGXsfl_21_Refreshing);
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid2_refresh( subGrid1_Rows, AV38UsuarioId) ;
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
         PA362( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START362( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714345767", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpreclusegusu.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV38UsuarioId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_21", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_21), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A263Vacantes_Id), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38UsuarioId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV38UsuarioId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "USUARIOSTELEF", StringUtil.RTrim( A260UsuariosTelef));
         GxWebStd.gx_hidden_field( context, "USUARIOSCORREO", A261UsuariosCorreo);
         GxWebStd.gx_hidden_field( context, "SUBT_RECLUTADORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A284SUBT_ReclutadorId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSFECHAP", context.localUtil.TToC( A288VacantesUsuariosFechaP, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSCV", StringUtil.LTrim( StringUtil.NToC( (decimal)(A292VacantesUsuariosCV), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSPREFILTRO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A291VacantesUsuariosPrefiltro), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSFECHAE", context.localUtil.TToC( A295VacantesUsuariosFechaE, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSEXTEC", StringUtil.LTrim( StringUtil.NToC( (decimal)(A293VacantesUsuariosExTec), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSFECHA3", context.localUtil.TToC( A314VacantesUsuariosFecha3, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSAVCONF", StringUtil.LTrim( StringUtil.NToC( (decimal)(A304VacantesUsuariosAvConf), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSAVPRIV", StringUtil.LTrim( StringUtil.NToC( (decimal)(A303VacantesUsuariosAvPriv), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSBUSWEB", StringUtil.LTrim( StringUtil.NToC( (decimal)(A302VacantesUsuariosBusWeb), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSEXPSI", StringUtil.LTrim( StringUtil.NToC( (decimal)(A301VacantesUsuariosExPsi), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSREFLAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(A300VacantesUsuariosRefLab), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSCVREC", StringUtil.LTrim( StringUtil.NToC( (decimal)(A299VacantesUsuariosCVRec), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSFECHAA", context.localUtil.TToC( A313VacantesUsuariosFechaA, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSFECHAD", context.localUtil.TToC( A289VacantesUsuariosFechaD, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSMOTD", A294VacantesUsuariosMotD);
         GxWebStd.gx_hidden_field( context, "vVACANTESUSUARIOSESTATUS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantesusuariosestatus_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "VACANTESUSUARIOSESTATUS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVacantesUsuariosEstatus_Visible), 5, 0, ".", "")));
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
            WE362( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT362( ) ;
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
         return formatLink("wpreclusegusu.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "wpRecluSegUsu" ;
      }

      public override String GetPgmdesc( )
      {
         return "wp Reclu Usuario" ;
      }

      protected void WB360( )
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
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 50, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Text Block", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", lblTextblock4_Visible, 1, 0, "HLP_wpRecluSegUsu.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 50, "px", "col-xs-10", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, lblTextblock2_Caption, "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", ((lblTextblock2_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;"), "Title", 0, "", 1, 1, 0, "HLP_wpRecluSegUsu.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 50, "px", "col-xs-2", "Right", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "cc1dc399-4dae-4e21-b230-ae2d35523d5d", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Refrescar pantalla", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REFRESCAR\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_wpRecluSegUsu.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Text Block", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", lblTextblock1_Visible, 1, 0, "HLP_wpRecluSegUsu.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "Right", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid2Container.SetIsFreestyle(true);
            Grid2Container.SetWrapped(nGXWrapped);
            if ( Grid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid2Container"+"DivS\" data-gxgridid=\"21\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid2_Internalname, subGrid2_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               Grid2Container.AddObjectProperty("GridName", "Grid2");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Grid2Container = new GXWebGrid( context);
               }
               else
               {
                  Grid2Container.Clear();
               }
               Grid2Container.SetIsFreestyle(true);
               Grid2Container.SetWrapped(nGXWrapped);
               Grid2Container.AddObjectProperty("GridName", "Grid2");
               Grid2Container.AddObjectProperty("Header", subGrid2_Header);
               Grid2Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
               Grid2Container.AddObjectProperty("Class", "FreeStyleGrid");
               Grid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Backcolorstyle), 1, 0, ".", "")));
               Grid2Container.AddObjectProperty("CmpContext", "");
               Grid2Container.AddObjectProperty("InMasterPage", "false");
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Column.AddObjectProperty("Value", lblTextblock2_Caption);
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A290VacantesUsuariosEstatus), 4, 0, ".", "")));
               Grid2Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVacantesUsuariosEstatus_Visible), 5, 0, ".", "")));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24VacantesUsuariosEstatus), 4, 0, ".", "")));
               Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantesusuariosestatus_Enabled), 5, 0, ".", "")));
               Grid2Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantesusuariosestatus_Visible), 5, 0, ".", "")));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Selectedindex), 4, 0, ".", "")));
               Grid2Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowselection), 1, 0, ".", "")));
               Grid2Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Selectioncolor), 9, 0, ".", "")));
               Grid2Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowhovering), 1, 0, ".", "")));
               Grid2Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Hoveringcolor), 9, 0, ".", "")));
               Grid2Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowcollapsing), 1, 0, ".", "")));
               Grid2Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 21 )
         {
            wbEnd = 0;
            nRC_GXsfl_21 = (int)(nGXsfl_21_idx-1);
            if ( Grid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid2Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid2", Grid2Container);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid2ContainerData", Grid2Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid2ContainerData"+"V", Grid2Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid2ContainerData"+"V"+"\" value='"+Grid2Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 21 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid2Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid2Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid2", Grid2Container);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid2ContainerData", Grid2Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid2ContainerData"+"V", Grid2Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid2ContainerData"+"V"+"\" value='"+Grid2Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 43 )
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
                  if ( ! isAjaxCallMode( ) )
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

      protected void START362( )
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
            Form.Meta.addItem("description", "wp Reclu Usuario", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP360( ) ;
      }

      protected void WS362( )
      {
         START362( ) ;
         EVT362( ) ;
      }

      protected void EVT362( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'REFRESCAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'refrescar' */
                              E11362 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID2.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) )
                           {
                              nGXsfl_21_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
                              SubsflControlProps_212( ) ;
                              A290VacantesUsuariosEstatus = (short)(context.localUtil.CToN( cgiGet( edtVacantesUsuariosEstatus_Internalname), ",", "."));
                              n290VacantesUsuariosEstatus = false;
                              AV24VacantesUsuariosEstatus = (short)(context.localUtil.CToN( cgiGet( edtavVacantesusuariosestatus_Internalname), ",", "."));
                              AssignAttri("", false, edtavVacantesusuariosestatus_Internalname, StringUtil.LTrimStr( (decimal)(AV24VacantesUsuariosEstatus), 4, 0));
                              GXCCtl = "GRID1_nFirstRecordOnPage_" + sGXsfl_21_idx;
                              GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
                              GXCCtl = "GRID1_nEOF_" + sGXsfl_21_idx;
                              GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
                              GXCCtl = "nRC_GXsfl_43_" + sGXsfl_21_idx;
                              nRC_GXsfl_43 = (int)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E12362 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID2.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E13362 ();
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
                                 sEvtType = StringUtil.Right( sEvt, 4);
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                                 if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 )
                                 {
                                    nGXsfl_43_idx = (int)(NumberUtil.Val( sEvtType, "."));
                                    sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0") + sGXsfl_21_idx;
                                    SubsflControlProps_434( ) ;
                                    dynavVacantes_id_envio.Name = dynavVacantes_id_envio_Internalname;
                                    dynavVacantes_id_envio.CurrentValue = cgiGet( dynavVacantes_id_envio_Internalname);
                                    AV18vacantes_id_Envio = (short)(NumberUtil.Val( cgiGet( dynavVacantes_id_envio_Internalname), "."));
                                    AssignAttri("", false, dynavVacantes_id_envio_Internalname, StringUtil.LTrimStr( (decimal)(AV18vacantes_id_Envio), 4, 0));
                                    AV24VacantesUsuariosEstatus = (short)(context.localUtil.CToN( cgiGet( edtavVacantesusuariosestatus_Internalname), ",", "."));
                                    AssignAttri("", false, edtavVacantesusuariosestatus_Internalname, StringUtil.LTrimStr( (decimal)(AV24VacantesUsuariosEstatus), 4, 0));
                                    AV29VacantesUsuariosFechaP = cgiGet( edtavVacantesusuariosfechap_Internalname);
                                    AssignAttri("", false, edtavVacantesusuariosfechap_Internalname, AV29VacantesUsuariosFechaP);
                                    dynavUsuariosid.Name = dynavUsuariosid_Internalname;
                                    dynavUsuariosid.CurrentValue = cgiGet( dynavUsuariosid_Internalname);
                                    AV13UsuariosId = (int)(NumberUtil.Val( cgiGet( dynavUsuariosid_Internalname), "."));
                                    AssignAttri("", false, dynavUsuariosid_Internalname, StringUtil.LTrimStr( (decimal)(AV13UsuariosId), 6, 0));
                                    AV15UsuariosTelef = cgiGet( edtavUsuariostelef_Internalname);
                                    AssignAttri("", false, edtavUsuariostelef_Internalname, AV15UsuariosTelef);
                                    AV12UsuariosCorreo = cgiGet( edtavUsuarioscorreo_Internalname);
                                    AssignAttri("", false, edtavUsuarioscorreo_Internalname, AV12UsuariosCorreo);
                                    dynavSubt_reclutadorid.Name = dynavSubt_reclutadorid_Internalname;
                                    dynavSubt_reclutadorid.CurrentValue = cgiGet( dynavSubt_reclutadorid_Internalname);
                                    AV8SUBT_ReclutadorId = (int)(NumberUtil.Val( cgiGet( dynavSubt_reclutadorid_Internalname), "."));
                                    AssignAttri("", false, dynavSubt_reclutadorid_Internalname, StringUtil.LTrimStr( (decimal)(AV8SUBT_ReclutadorId), 6, 0));
                                    AV35VacantesUsuariosFecha3 = context.localUtil.CToT( cgiGet( edtavVacantesusuariosfecha3_Internalname), 0);
                                    AssignAttri("", false, edtavVacantesusuariosfecha3_Internalname, context.localUtil.TToC( AV35VacantesUsuariosFecha3, 8, 5, 0, 3, "/", ":", " "));
                                    AV28VacantesUsuariosFechaE = cgiGet( edtavVacantesusuariosfechae_Internalname);
                                    AssignAttri("", false, edtavVacantesusuariosfechae_Internalname, AV28VacantesUsuariosFechaE);
                                    AV27VacantesUsuariosFechaD = cgiGet( edtavVacantesusuariosfechad_Internalname);
                                    AssignAttri("", false, edtavVacantesusuariosfechad_Internalname, AV27VacantesUsuariosFechaD);
                                    AV30VacantesUsuariosMotD = cgiGet( edtavVacantesusuariosmotd_Internalname);
                                    AssignAttri("", false, edtavVacantesusuariosmotd_Internalname, AV30VacantesUsuariosMotD);
                                    AV31VacantesUsuariosPrefiltro = cgiGet( edtavVacantesusuariosprefiltro_Internalname);
                                    AssignProp("", false, edtavVacantesusuariosprefiltro_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV31VacantesUsuariosPrefiltro)) ? AV45Vacantesusuariosprefiltro_GXI : context.convertURL( context.PathToRelativeUrl( AV31VacantesUsuariosPrefiltro))), !bGXsfl_43_Refreshing);
                                    AssignProp("", false, edtavVacantesusuariosprefiltro_Internalname, "SrcSet", context.GetImageSrcSet( AV31VacantesUsuariosPrefiltro), true);
                                    AV22VacantesUsuariosCV = cgiGet( edtavVacantesusuarioscv_Internalname);
                                    AssignProp("", false, edtavVacantesusuarioscv_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV22VacantesUsuariosCV)) ? AV46Vacantesusuarioscv_GXI : context.convertURL( context.PathToRelativeUrl( AV22VacantesUsuariosCV))), !bGXsfl_43_Refreshing);
                                    AssignProp("", false, edtavVacantesusuarioscv_Internalname, "SrcSet", context.GetImageSrcSet( AV22VacantesUsuariosCV), true);
                                    AV26VacantesUsuariosExTec = cgiGet( edtavVacantesusuariosextec_Internalname);
                                    AssignProp("", false, edtavVacantesusuariosextec_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV26VacantesUsuariosExTec)) ? AV47Vacantesusuariosextec_GXI : context.convertURL( context.PathToRelativeUrl( AV26VacantesUsuariosExTec))), !bGXsfl_43_Refreshing);
                                    AssignProp("", false, edtavVacantesusuariosextec_Internalname, "SrcSet", context.GetImageSrcSet( AV26VacantesUsuariosExTec), true);
                                    AV19VacantesUsuariosAvConf = cgiGet( edtavVacantesusuariosavconf_Internalname);
                                    AssignProp("", false, edtavVacantesusuariosavconf_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV19VacantesUsuariosAvConf)) ? AV53Vacantesusuariosavconf_GXI : context.convertURL( context.PathToRelativeUrl( AV19VacantesUsuariosAvConf))), !bGXsfl_43_Refreshing);
                                    AssignProp("", false, edtavVacantesusuariosavconf_Internalname, "SrcSet", context.GetImageSrcSet( AV19VacantesUsuariosAvConf), true);
                                    AV20VacantesUsuariosAvPriv = cgiGet( edtavVacantesusuariosavpriv_Internalname);
                                    AssignProp("", false, edtavVacantesusuariosavpriv_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV20VacantesUsuariosAvPriv)) ? AV52Vacantesusuariosavpriv_GXI : context.convertURL( context.PathToRelativeUrl( AV20VacantesUsuariosAvPriv))), !bGXsfl_43_Refreshing);
                                    AssignProp("", false, edtavVacantesusuariosavpriv_Internalname, "SrcSet", context.GetImageSrcSet( AV20VacantesUsuariosAvPriv), true);
                                    AV21VacantesUsuariosBusWeb = cgiGet( edtavVacantesusuariosbusweb_Internalname);
                                    AssignProp("", false, edtavVacantesusuariosbusweb_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV21VacantesUsuariosBusWeb)) ? AV51Vacantesusuariosbusweb_GXI : context.convertURL( context.PathToRelativeUrl( AV21VacantesUsuariosBusWeb))), !bGXsfl_43_Refreshing);
                                    AssignProp("", false, edtavVacantesusuariosbusweb_Internalname, "SrcSet", context.GetImageSrcSet( AV21VacantesUsuariosBusWeb), true);
                                    AV32VacantesUsuariosRefLab = cgiGet( edtavVacantesusuariosreflab_Internalname);
                                    AssignProp("", false, edtavVacantesusuariosreflab_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV32VacantesUsuariosRefLab)) ? AV49Vacantesusuariosreflab_GXI : context.convertURL( context.PathToRelativeUrl( AV32VacantesUsuariosRefLab))), !bGXsfl_43_Refreshing);
                                    AssignProp("", false, edtavVacantesusuariosreflab_Internalname, "SrcSet", context.GetImageSrcSet( AV32VacantesUsuariosRefLab), true);
                                    AV25VacantesUsuariosExPsi = cgiGet( edtavVacantesusuariosexpsi_Internalname);
                                    AssignProp("", false, edtavVacantesusuariosexpsi_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV25VacantesUsuariosExPsi)) ? AV50Vacantesusuariosexpsi_GXI : context.convertURL( context.PathToRelativeUrl( AV25VacantesUsuariosExPsi))), !bGXsfl_43_Refreshing);
                                    AssignProp("", false, edtavVacantesusuariosexpsi_Internalname, "SrcSet", context.GetImageSrcSet( AV25VacantesUsuariosExPsi), true);
                                    AV23VacantesUsuariosCVRec = cgiGet( edtavVacantesusuarioscvrec_Internalname);
                                    AssignProp("", false, edtavVacantesusuarioscvrec_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV23VacantesUsuariosCVRec)) ? AV48Vacantesusuarioscvrec_GXI : context.convertURL( context.PathToRelativeUrl( AV23VacantesUsuariosCVRec))), !bGXsfl_43_Refreshing);
                                    AssignProp("", false, edtavVacantesusuarioscvrec_Internalname, "SrcSet", context.GetImageSrcSet( AV23VacantesUsuariosCVRec), true);
                                    sEvtType = StringUtil.Right( sEvt, 1);
                                    if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                                    {
                                       sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                       if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                       {
                                          context.wbHandled = 1;
                                          dynload_actions( ) ;
                                          E14364 ();
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
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE362( )
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

      protected void PA362( )
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

      protected void GXDLVvUSUARIOSID364( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvUSUARIOSID_data364( ) ;
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

      protected void GXVvUSUARIOSID_html364( )
      {
         int gxdynajaxvalue ;
         GXDLVvUSUARIOSID_data364( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavUsuariosid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((String)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavUsuariosid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((String)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvUSUARIOSID_data364( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00362 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00362_A11UsuariosId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00362_A97UsuariosNomCompleto[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvSUBT_RECLUTADORID364( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSUBT_RECLUTADORID_data364( ) ;
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

      protected void GXVvSUBT_RECLUTADORID_html364( )
      {
         int gxdynajaxvalue ;
         GXDLVvSUBT_RECLUTADORID_data364( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavSubt_reclutadorid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((String)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavSubt_reclutadorid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((String)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvSUBT_RECLUTADORID_data364( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00363 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00363_A11UsuariosId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00363_A97UsuariosNomCompleto[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void gxnrGrid2_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_212( ) ;
         while ( nGXsfl_21_idx <= nRC_GXsfl_21 )
         {
            sendrow_212( ) ;
            nGXsfl_21_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_21_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_21_idx+1);
            sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
            SubsflControlProps_212( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid2Container)) ;
         /* End function gxnrGrid2_newrow */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_434( ) ;
         while ( nGXsfl_43_idx <= nRC_GXsfl_43 )
         {
            sendrow_434( ) ;
            nGXsfl_43_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_43_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0") + sGXsfl_21_idx;
            SubsflControlProps_434( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        int A263Vacantes_Id ,
                                        short A290VacantesUsuariosEstatus ,
                                        short AV24VacantesUsuariosEstatus ,
                                        int A11UsuariosId ,
                                        int AV38UsuarioId ,
                                        String A260UsuariosTelef ,
                                        String A261UsuariosCorreo ,
                                        int A284SUBT_ReclutadorId ,
                                        DateTime A288VacantesUsuariosFechaP ,
                                        short A292VacantesUsuariosCV ,
                                        short A291VacantesUsuariosPrefiltro ,
                                        DateTime A295VacantesUsuariosFechaE ,
                                        short A293VacantesUsuariosExTec ,
                                        DateTime A314VacantesUsuariosFecha3 ,
                                        short A304VacantesUsuariosAvConf ,
                                        short A303VacantesUsuariosAvPriv ,
                                        short A302VacantesUsuariosBusWeb ,
                                        short A301VacantesUsuariosExPsi ,
                                        short A300VacantesUsuariosRefLab ,
                                        short A299VacantesUsuariosCVRec ,
                                        DateTime A313VacantesUsuariosFechaA ,
                                        DateTime A289VacantesUsuariosFechaD ,
                                        String A294VacantesUsuariosMotD )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF364( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void gxgrGrid2_refresh( int subGrid1_Rows ,
                                        int AV38UsuarioId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID2_nCurrentRecord = 0;
         RF362( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid2_refresh */
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF362( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         dynavVacantes_id_envio.Enabled = 0;
         AssignProp("", false, dynavVacantes_id_envio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavVacantes_id_envio.Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavVacantesusuariosestatus_Enabled = 0;
         AssignProp("", false, edtavVacantesusuariosestatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosestatus_Enabled), 5, 0), !bGXsfl_21_Refreshing);
         edtavVacantesusuariosfechap_Enabled = 0;
         AssignProp("", false, edtavVacantesusuariosfechap_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosfechap_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         dynavUsuariosid.Enabled = 0;
         AssignProp("", false, dynavUsuariosid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavUsuariosid.Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavUsuariostelef_Enabled = 0;
         AssignProp("", false, edtavUsuariostelef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuariostelef_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavUsuarioscorreo_Enabled = 0;
         AssignProp("", false, edtavUsuarioscorreo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuarioscorreo_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         dynavSubt_reclutadorid.Enabled = 0;
         AssignProp("", false, dynavSubt_reclutadorid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavSubt_reclutadorid.Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavVacantesusuariosfecha3_Enabled = 0;
         AssignProp("", false, edtavVacantesusuariosfecha3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosfecha3_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavVacantesusuariosfechae_Enabled = 0;
         AssignProp("", false, edtavVacantesusuariosfechae_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosfechae_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavVacantesusuariosfechad_Enabled = 0;
         AssignProp("", false, edtavVacantesusuariosfechad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosfechad_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavVacantesusuariosmotd_Enabled = 0;
         AssignProp("", false, edtavVacantesusuariosmotd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosmotd_Enabled), 5, 0), !bGXsfl_43_Refreshing);
      }

      protected void RF362( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid2Container.ClearRows();
         }
         wbStart = 21;
         nGXsfl_21_idx = 1;
         sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
         SubsflControlProps_212( ) ;
         bGXsfl_21_Refreshing = true;
         Grid2Container.AddObjectProperty("GridName", "Grid2");
         Grid2Container.AddObjectProperty("CmpContext", "");
         Grid2Container.AddObjectProperty("InMasterPage", "false");
         Grid2Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         Grid2Container.AddObjectProperty("Class", "FreeStyleGrid");
         Grid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Backcolorstyle), 1, 0, ".", "")));
         Grid2Container.PageSize = subGrid2_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_212( ) ;
            /* Using cursor H00364 */
            pr_default.execute(2, new Object[] {AV38UsuarioId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A11UsuariosId = H00364_A11UsuariosId[0];
               A290VacantesUsuariosEstatus = H00364_A290VacantesUsuariosEstatus[0];
               n290VacantesUsuariosEstatus = H00364_n290VacantesUsuariosEstatus[0];
               A263Vacantes_Id = H00364_A263Vacantes_Id[0];
               A260UsuariosTelef = H00364_A260UsuariosTelef[0];
               A261UsuariosCorreo = H00364_A261UsuariosCorreo[0];
               A284SUBT_ReclutadorId = H00364_A284SUBT_ReclutadorId[0];
               A288VacantesUsuariosFechaP = H00364_A288VacantesUsuariosFechaP[0];
               A291VacantesUsuariosPrefiltro = H00364_A291VacantesUsuariosPrefiltro[0];
               n291VacantesUsuariosPrefiltro = H00364_n291VacantesUsuariosPrefiltro[0];
               A292VacantesUsuariosCV = H00364_A292VacantesUsuariosCV[0];
               n292VacantesUsuariosCV = H00364_n292VacantesUsuariosCV[0];
               A293VacantesUsuariosExTec = H00364_A293VacantesUsuariosExTec[0];
               n293VacantesUsuariosExTec = H00364_n293VacantesUsuariosExTec[0];
               A295VacantesUsuariosFechaE = H00364_A295VacantesUsuariosFechaE[0];
               n295VacantesUsuariosFechaE = H00364_n295VacantesUsuariosFechaE[0];
               A299VacantesUsuariosCVRec = H00364_A299VacantesUsuariosCVRec[0];
               n299VacantesUsuariosCVRec = H00364_n299VacantesUsuariosCVRec[0];
               A300VacantesUsuariosRefLab = H00364_A300VacantesUsuariosRefLab[0];
               n300VacantesUsuariosRefLab = H00364_n300VacantesUsuariosRefLab[0];
               A301VacantesUsuariosExPsi = H00364_A301VacantesUsuariosExPsi[0];
               n301VacantesUsuariosExPsi = H00364_n301VacantesUsuariosExPsi[0];
               A302VacantesUsuariosBusWeb = H00364_A302VacantesUsuariosBusWeb[0];
               n302VacantesUsuariosBusWeb = H00364_n302VacantesUsuariosBusWeb[0];
               A303VacantesUsuariosAvPriv = H00364_A303VacantesUsuariosAvPriv[0];
               n303VacantesUsuariosAvPriv = H00364_n303VacantesUsuariosAvPriv[0];
               A304VacantesUsuariosAvConf = H00364_A304VacantesUsuariosAvConf[0];
               n304VacantesUsuariosAvConf = H00364_n304VacantesUsuariosAvConf[0];
               A314VacantesUsuariosFecha3 = H00364_A314VacantesUsuariosFecha3[0];
               n314VacantesUsuariosFecha3 = H00364_n314VacantesUsuariosFecha3[0];
               A313VacantesUsuariosFechaA = H00364_A313VacantesUsuariosFechaA[0];
               n313VacantesUsuariosFechaA = H00364_n313VacantesUsuariosFechaA[0];
               A294VacantesUsuariosMotD = H00364_A294VacantesUsuariosMotD[0];
               n294VacantesUsuariosMotD = H00364_n294VacantesUsuariosMotD[0];
               A289VacantesUsuariosFechaD = H00364_A289VacantesUsuariosFechaD[0];
               n289VacantesUsuariosFechaD = H00364_n289VacantesUsuariosFechaD[0];
               A260UsuariosTelef = H00364_A260UsuariosTelef[0];
               A261UsuariosCorreo = H00364_A261UsuariosCorreo[0];
               E13362 ();
               pr_default.readNext(2);
            }
            pr_default.close(2);
            wbEnd = 21;
            WB360( ) ;
         }
         bGXsfl_21_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes362( )
      {
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38UsuarioId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV38UsuarioId), "ZZZZZZZZ9"), context));
      }

      protected void RF364( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 43;
         nGXsfl_43_idx = 1;
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0") + sGXsfl_21_idx;
         SubsflControlProps_434( ) ;
         bGXsfl_43_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "WorkWith");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         GXCCtl = "GRID1_nFirstRecordOnPage_" + sGXsfl_21_idx;
         if ( subGrid1_Islastpage != 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordcount( )-subGrid1_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
            Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_434( ) ;
            E14364 ();
            if ( ( GRID1_nCurrentRecord > 0 ) && ( GRID1_nGridOutOfScope == 0 ) && ( nGXsfl_43_idx == 1 ) )
            {
               GRID1_nCurrentRecord = 0;
               GRID1_nGridOutOfScope = 1;
               subgrid1_firstpage( ) ;
               E14364 ();
            }
            wbEnd = 43;
            WB360( ) ;
         }
         bGXsfl_43_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes364( )
      {
      }

      protected int subGrid2_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Currentpage( )
      {
         return (int)(-1) ;
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
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(((subGrid1_Islastpage==1) ? subGrid1_fnc_Recordcount( )/ (decimal)(subGrid1_fnc_Recordsperpage( ))+((((int)((subGrid1_fnc_Recordcount( )) % (subGrid1_fnc_Recordsperpage( ))))==0) ? 0 : 1) : (decimal)(NumberUtil.Int( (long)(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1))) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GXCCtl = "GRID1_nFirstRecordOnPage_" + sGXsfl_21_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, A263Vacantes_Id, A290VacantesUsuariosEstatus, AV24VacantesUsuariosEstatus, A11UsuariosId, AV38UsuarioId, A260UsuariosTelef, A261UsuariosCorreo, A284SUBT_ReclutadorId, A288VacantesUsuariosFechaP, A292VacantesUsuariosCV, A291VacantesUsuariosPrefiltro, A295VacantesUsuariosFechaE, A293VacantesUsuariosExTec, A314VacantesUsuariosFecha3, A304VacantesUsuariosAvConf, A303VacantesUsuariosAvPriv, A302VacantesUsuariosBusWeb, A301VacantesUsuariosExPsi, A300VacantesUsuariosRefLab, A299VacantesUsuariosCVRec, A313VacantesUsuariosFechaA, A289VacantesUsuariosFechaD, A294VacantesUsuariosMotD) ;
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
         GXCCtl = "GRID1_nFirstRecordOnPage_" + sGXsfl_21_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, A263Vacantes_Id, A290VacantesUsuariosEstatus, AV24VacantesUsuariosEstatus, A11UsuariosId, AV38UsuarioId, A260UsuariosTelef, A261UsuariosCorreo, A284SUBT_ReclutadorId, A288VacantesUsuariosFechaP, A292VacantesUsuariosCV, A291VacantesUsuariosPrefiltro, A295VacantesUsuariosFechaE, A293VacantesUsuariosExTec, A314VacantesUsuariosFecha3, A304VacantesUsuariosAvConf, A303VacantesUsuariosAvPriv, A302VacantesUsuariosBusWeb, A301VacantesUsuariosExPsi, A300VacantesUsuariosRefLab, A299VacantesUsuariosCVRec, A313VacantesUsuariosFechaA, A289VacantesUsuariosFechaD, A294VacantesUsuariosMotD) ;
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
         GXCCtl = "GRID1_nFirstRecordOnPage_" + sGXsfl_21_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, A263Vacantes_Id, A290VacantesUsuariosEstatus, AV24VacantesUsuariosEstatus, A11UsuariosId, AV38UsuarioId, A260UsuariosTelef, A261UsuariosCorreo, A284SUBT_ReclutadorId, A288VacantesUsuariosFechaP, A292VacantesUsuariosCV, A291VacantesUsuariosPrefiltro, A295VacantesUsuariosFechaE, A293VacantesUsuariosExTec, A314VacantesUsuariosFecha3, A304VacantesUsuariosAvConf, A303VacantesUsuariosAvPriv, A302VacantesUsuariosBusWeb, A301VacantesUsuariosExPsi, A300VacantesUsuariosRefLab, A299VacantesUsuariosCVRec, A313VacantesUsuariosFechaA, A289VacantesUsuariosFechaD, A294VacantesUsuariosMotD) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         subGrid1_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, A263Vacantes_Id, A290VacantesUsuariosEstatus, AV24VacantesUsuariosEstatus, A11UsuariosId, AV38UsuarioId, A260UsuariosTelef, A261UsuariosCorreo, A284SUBT_ReclutadorId, A288VacantesUsuariosFechaP, A292VacantesUsuariosCV, A291VacantesUsuariosPrefiltro, A295VacantesUsuariosFechaE, A293VacantesUsuariosExTec, A314VacantesUsuariosFecha3, A304VacantesUsuariosAvConf, A303VacantesUsuariosAvPriv, A302VacantesUsuariosBusWeb, A301VacantesUsuariosExPsi, A300VacantesUsuariosRefLab, A299VacantesUsuariosCVRec, A313VacantesUsuariosFechaA, A289VacantesUsuariosFechaD, A294VacantesUsuariosMotD) ;
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
         GXCCtl = "GRID1_nFirstRecordOnPage_" + sGXsfl_21_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, A263Vacantes_Id, A290VacantesUsuariosEstatus, AV24VacantesUsuariosEstatus, A11UsuariosId, AV38UsuarioId, A260UsuariosTelef, A261UsuariosCorreo, A284SUBT_ReclutadorId, A288VacantesUsuariosFechaP, A292VacantesUsuariosCV, A291VacantesUsuariosPrefiltro, A295VacantesUsuariosFechaE, A293VacantesUsuariosExTec, A314VacantesUsuariosFecha3, A304VacantesUsuariosAvConf, A303VacantesUsuariosAvPriv, A302VacantesUsuariosBusWeb, A301VacantesUsuariosExPsi, A300VacantesUsuariosRefLab, A299VacantesUsuariosCVRec, A313VacantesUsuariosFechaA, A289VacantesUsuariosFechaD, A294VacantesUsuariosMotD) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         dynavVacantes_id_envio.Enabled = 0;
         AssignProp("", false, dynavVacantes_id_envio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavVacantes_id_envio.Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavVacantesusuariosestatus_Enabled = 0;
         AssignProp("", false, edtavVacantesusuariosestatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosestatus_Enabled), 5, 0), !bGXsfl_21_Refreshing);
         edtavVacantesusuariosfechap_Enabled = 0;
         AssignProp("", false, edtavVacantesusuariosfechap_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosfechap_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         dynavUsuariosid.Enabled = 0;
         AssignProp("", false, dynavUsuariosid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavUsuariosid.Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavUsuariostelef_Enabled = 0;
         AssignProp("", false, edtavUsuariostelef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuariostelef_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavUsuarioscorreo_Enabled = 0;
         AssignProp("", false, edtavUsuarioscorreo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuarioscorreo_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         dynavSubt_reclutadorid.Enabled = 0;
         AssignProp("", false, dynavSubt_reclutadorid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavSubt_reclutadorid.Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavVacantesusuariosfecha3_Enabled = 0;
         AssignProp("", false, edtavVacantesusuariosfecha3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosfecha3_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavVacantesusuariosfechae_Enabled = 0;
         AssignProp("", false, edtavVacantesusuariosfechae_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosfechae_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavVacantesusuariosfechad_Enabled = 0;
         AssignProp("", false, edtavVacantesusuariosfechad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosfechad_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavVacantesusuariosmotd_Enabled = 0;
         AssignProp("", false, edtavVacantesusuariosmotd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosmotd_Enabled), 5, 0), !bGXsfl_43_Refreshing);
      }

      protected void STRUP360( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12362 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_21 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_21"), ",", "."));
            /* Read variables values. */
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
         E12362 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E12362( )
      {
         /* Start Routine */
         edtavVacantesusuariosestatus_Visible = 0;
         AssignProp("", false, edtavVacantesusuariosestatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVacantesusuariosestatus_Visible), 5, 0), !bGXsfl_21_Refreshing);
         edtVacantesUsuariosEstatus_Visible = 0;
         AssignProp("", false, edtVacantesUsuariosEstatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVacantesUsuariosEstatus_Visible), 5, 0), !bGXsfl_21_Refreshing);
         dynavVacantes_id_envio.Visible = 1;
         AssignProp("", false, dynavVacantes_id_envio_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavVacantes_id_envio.Visible), 5, 0), !bGXsfl_43_Refreshing);
         AV5adjuntar = context.GetImagePath( "5046a98d-ab11-4d0f-b902-e472abde2a26", "", context.GetTheme( ));
         AV42Adjuntar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "5046a98d-ab11-4d0f-b902-e472abde2a26", "", context.GetTheme( )));
         AV38UsuarioId = (int)(NumberUtil.Val( AV37websession.Get("UsuarioId"), "."));
         AssignAttri("", false, "AV38UsuarioId", StringUtil.LTrimStr( (decimal)(AV38UsuarioId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV38UsuarioId), "ZZZZZZZZ9"), context));
         /* Using cursor H00365 */
         pr_default.execute(3, new Object[] {AV38UsuarioId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A11UsuariosId = H00365_A11UsuariosId[0];
            A64UsuariosApMat = H00365_A64UsuariosApMat[0];
            A65UsuariosApPat = H00365_A65UsuariosApPat[0];
            A66UsuariosNombre = H00365_A66UsuariosNombre[0];
            A97UsuariosNomCompleto = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + StringUtil.Trim( A64UsuariosApMat);
            AssignAttri("", false, "A97UsuariosNomCompleto", A97UsuariosNomCompleto);
            AV39Nombre_Comp_Usuario = A97UsuariosNomCompleto;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
         lblTextblock2_Caption = "SEGUIMIENTO DE LAS VACANTES DEL USUARIO:   "+"  -  "+AV39Nombre_Comp_Usuario;
         AssignProp("", false, lblTextblock2_Internalname, "Caption", lblTextblock2_Caption, true);
         lblTextblock2_Fontbold = 1;
         AssignProp("", false, lblTextblock2_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTextblock2_Fontbold), 1, 0), true);
         lblTextblock1_Visible = 0;
         AssignProp("", false, lblTextblock1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTextblock1_Visible), 5, 0), true);
         lblTextblock4_Visible = 0;
         AssignProp("", false, lblTextblock4_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTextblock4_Visible), 5, 0), true);
      }

      private void E13362( )
      {
         /* Grid2_Load Routine */
         AV24VacantesUsuariosEstatus = A290VacantesUsuariosEstatus;
         AssignAttri("", false, edtavVacantesusuariosestatus_Internalname, StringUtil.LTrimStr( (decimal)(AV24VacantesUsuariosEstatus), 4, 0));
         if ( AV24VacantesUsuariosEstatus == 0 )
         {
            lblTitletext_Caption = "1er. Filtro";
            divTabletop_Class = "TableTopSearch1Filtro";
            AssignProp("", false, divTabletop_Internalname, "Class", divTabletop_Class, !bGXsfl_21_Refreshing);
         }
         else if ( AV24VacantesUsuariosEstatus == 1 )
         {
            lblTitletext_Caption = "2do. Filtro";
            divTabletop_Class = "TableTopSearch2Filtro";
            AssignProp("", false, divTabletop_Internalname, "Class", divTabletop_Class, !bGXsfl_21_Refreshing);
         }
         else if ( AV24VacantesUsuariosEstatus == 2 )
         {
            lblTitletext_Caption = "3er. Filtro";
            divTabletop_Class = "TableTopSearch3Filtro";
            AssignProp("", false, divTabletop_Internalname, "Class", divTabletop_Class, !bGXsfl_21_Refreshing);
         }
         else if ( AV24VacantesUsuariosEstatus == 3 )
         {
            lblTitletext_Caption = "Proceso Completo";
            divTabletop_Class = "TableTopSearchCompletado";
            AssignProp("", false, divTabletop_Internalname, "Class", divTabletop_Class, !bGXsfl_21_Refreshing);
         }
         else if ( AV24VacantesUsuariosEstatus == 4 )
         {
            lblTitletext_Caption = "Enviado a Cliente";
         }
         else if ( AV24VacantesUsuariosEstatus == 5 )
         {
            lblTitletext_Caption = "Descartado";
            divTabletop_Class = "TableTopSearchDescartados";
            AssignProp("", false, divTabletop_Internalname, "Class", divTabletop_Class, !bGXsfl_21_Refreshing);
         }
         else
         {
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 21;
         }
         sendrow_212( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_21_Refreshing )
         {
            context.DoAjaxLoad(21, Grid2Row);
         }
         /*  Sending Event outputs  */
      }

      protected void E11362( )
      {
         /* 'refrescar' Routine */
         context.DoAjaxRefresh();
      }

      private void E14364( )
      {
         /* Grid1_Load Routine */
         /* Using cursor H00366 */
         pr_default.execute(4, new Object[] {AV38UsuarioId, AV24VacantesUsuariosEstatus});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A11UsuariosId = H00366_A11UsuariosId[0];
            A290VacantesUsuariosEstatus = H00366_A290VacantesUsuariosEstatus[0];
            n290VacantesUsuariosEstatus = H00366_n290VacantesUsuariosEstatus[0];
            A263Vacantes_Id = H00366_A263Vacantes_Id[0];
            A260UsuariosTelef = H00366_A260UsuariosTelef[0];
            A261UsuariosCorreo = H00366_A261UsuariosCorreo[0];
            A284SUBT_ReclutadorId = H00366_A284SUBT_ReclutadorId[0];
            A288VacantesUsuariosFechaP = H00366_A288VacantesUsuariosFechaP[0];
            A291VacantesUsuariosPrefiltro = H00366_A291VacantesUsuariosPrefiltro[0];
            n291VacantesUsuariosPrefiltro = H00366_n291VacantesUsuariosPrefiltro[0];
            A292VacantesUsuariosCV = H00366_A292VacantesUsuariosCV[0];
            n292VacantesUsuariosCV = H00366_n292VacantesUsuariosCV[0];
            A293VacantesUsuariosExTec = H00366_A293VacantesUsuariosExTec[0];
            n293VacantesUsuariosExTec = H00366_n293VacantesUsuariosExTec[0];
            A295VacantesUsuariosFechaE = H00366_A295VacantesUsuariosFechaE[0];
            n295VacantesUsuariosFechaE = H00366_n295VacantesUsuariosFechaE[0];
            A299VacantesUsuariosCVRec = H00366_A299VacantesUsuariosCVRec[0];
            n299VacantesUsuariosCVRec = H00366_n299VacantesUsuariosCVRec[0];
            A300VacantesUsuariosRefLab = H00366_A300VacantesUsuariosRefLab[0];
            n300VacantesUsuariosRefLab = H00366_n300VacantesUsuariosRefLab[0];
            A301VacantesUsuariosExPsi = H00366_A301VacantesUsuariosExPsi[0];
            n301VacantesUsuariosExPsi = H00366_n301VacantesUsuariosExPsi[0];
            A302VacantesUsuariosBusWeb = H00366_A302VacantesUsuariosBusWeb[0];
            n302VacantesUsuariosBusWeb = H00366_n302VacantesUsuariosBusWeb[0];
            A303VacantesUsuariosAvPriv = H00366_A303VacantesUsuariosAvPriv[0];
            n303VacantesUsuariosAvPriv = H00366_n303VacantesUsuariosAvPriv[0];
            A304VacantesUsuariosAvConf = H00366_A304VacantesUsuariosAvConf[0];
            n304VacantesUsuariosAvConf = H00366_n304VacantesUsuariosAvConf[0];
            A314VacantesUsuariosFecha3 = H00366_A314VacantesUsuariosFecha3[0];
            n314VacantesUsuariosFecha3 = H00366_n314VacantesUsuariosFecha3[0];
            A313VacantesUsuariosFechaA = H00366_A313VacantesUsuariosFechaA[0];
            n313VacantesUsuariosFechaA = H00366_n313VacantesUsuariosFechaA[0];
            A294VacantesUsuariosMotD = H00366_A294VacantesUsuariosMotD[0];
            n294VacantesUsuariosMotD = H00366_n294VacantesUsuariosMotD[0];
            A289VacantesUsuariosFechaD = H00366_A289VacantesUsuariosFechaD[0];
            n289VacantesUsuariosFechaD = H00366_n289VacantesUsuariosFechaD[0];
            A260UsuariosTelef = H00366_A260UsuariosTelef[0];
            A261UsuariosCorreo = H00366_A261UsuariosCorreo[0];
            AV13UsuariosId = A11UsuariosId;
            AssignAttri("", false, dynavUsuariosid_Internalname, StringUtil.LTrimStr( (decimal)(AV13UsuariosId), 6, 0));
            AV15UsuariosTelef = A260UsuariosTelef;
            AssignAttri("", false, edtavUsuariostelef_Internalname, AV15UsuariosTelef);
            AV12UsuariosCorreo = A261UsuariosCorreo;
            AssignAttri("", false, edtavUsuarioscorreo_Internalname, AV12UsuariosCorreo);
            AV8SUBT_ReclutadorId = A284SUBT_ReclutadorId;
            AssignAttri("", false, dynavSubt_reclutadorid_Internalname, StringUtil.LTrimStr( (decimal)(AV8SUBT_ReclutadorId), 6, 0));
            AV29VacantesUsuariosFechaP = context.localUtil.Format( A288VacantesUsuariosFechaP, "99/99/9999 99:99");
            AssignAttri("", false, edtavVacantesusuariosfechap_Internalname, AV29VacantesUsuariosFechaP);
            AV18vacantes_id_Envio = (short)(A263Vacantes_Id);
            AssignAttri("", false, dynavVacantes_id_envio_Internalname, StringUtil.LTrimStr( (decimal)(AV18vacantes_id_Envio), 4, 0));
            if ( AV24VacantesUsuariosEstatus == 0 )
            {
               edtavVacantesusuariosprefiltro_Visible = 1;
               edtavVacantesusuarioscv_Visible = 1;
               edtavVacantesusuariosextec_Visible = 0;
               edtavVacantesusuariosfechae_Visible = 0;
               edtavVacantesusuarioscvrec_Visible = 0;
               edtavVacantesusuariosreflab_Visible = 0;
               edtavVacantesusuariosexpsi_Visible = 0;
               edtavVacantesusuariosbusweb_Visible = 0;
               edtavVacantesusuariosavpriv_Visible = 0;
               edtavVacantesusuariosavconf_Visible = 0;
               edtavVacantesusuariosfecha3_Visible = 0;
               edtavVacantesusuariosmotd_Visible = 0;
               edtavVacantesusuariosfechad_Visible = 0;
               if ( A291VacantesUsuariosPrefiltro == 1 )
               {
                  AV31VacantesUsuariosPrefiltro = context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( ));
                  AssignAttri("", false, edtavVacantesusuariosprefiltro_Internalname, AV31VacantesUsuariosPrefiltro);
                  AV45Vacantesusuariosprefiltro_GXI = GXDbFile.PathToUrl( context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( )));
               }
               else
               {
                  AV31VacantesUsuariosPrefiltro = context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( ));
                  AssignAttri("", false, edtavVacantesusuariosprefiltro_Internalname, AV31VacantesUsuariosPrefiltro);
                  AV45Vacantesusuariosprefiltro_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( )));
               }
               if ( A292VacantesUsuariosCV == 1 )
               {
                  AV22VacantesUsuariosCV = context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( ));
                  AssignAttri("", false, edtavVacantesusuarioscv_Internalname, AV22VacantesUsuariosCV);
                  AV46Vacantesusuarioscv_GXI = GXDbFile.PathToUrl( context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( )));
               }
               else
               {
                  AV22VacantesUsuariosCV = context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( ));
                  AssignAttri("", false, edtavVacantesusuarioscv_Internalname, AV22VacantesUsuariosCV);
                  AV46Vacantesusuarioscv_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( )));
               }
            }
            else if ( AV24VacantesUsuariosEstatus == 1 )
            {
               edtavVacantesusuariosprefiltro_Visible = 0;
               edtavVacantesusuarioscv_Visible = 0;
               edtavVacantesusuariosextec_Visible = 1;
               edtavVacantesusuariosfechae_Visible = 1;
               edtavVacantesusuarioscvrec_Visible = 0;
               edtavVacantesusuariosreflab_Visible = 0;
               edtavVacantesusuariosexpsi_Visible = 0;
               edtavVacantesusuariosbusweb_Visible = 0;
               edtavVacantesusuariosavpriv_Visible = 0;
               edtavVacantesusuariosavconf_Visible = 0;
               edtavVacantesusuariosfecha3_Visible = 0;
               edtavVacantesusuariosmotd_Visible = 0;
               edtavVacantesusuariosfechad_Visible = 0;
               if ( A293VacantesUsuariosExTec == 1 )
               {
                  AV26VacantesUsuariosExTec = context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( ));
                  AssignAttri("", false, edtavVacantesusuariosextec_Internalname, AV26VacantesUsuariosExTec);
                  AV47Vacantesusuariosextec_GXI = GXDbFile.PathToUrl( context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( )));
               }
               else
               {
                  AV26VacantesUsuariosExTec = context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( ));
                  AssignAttri("", false, edtavVacantesusuariosextec_Internalname, AV26VacantesUsuariosExTec);
                  AV47Vacantesusuariosextec_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( )));
               }
               AV28VacantesUsuariosFechaE = context.localUtil.Format( A295VacantesUsuariosFechaE, "99/99/99 99:99");
               AssignAttri("", false, edtavVacantesusuariosfechae_Internalname, AV28VacantesUsuariosFechaE);
            }
            else if ( AV24VacantesUsuariosEstatus == 2 )
            {
               edtavVacantesusuariosprefiltro_Visible = 0;
               edtavVacantesusuarioscv_Visible = 0;
               edtavVacantesusuariosextec_Visible = 0;
               edtavVacantesusuariosfechae_Visible = 0;
               edtavVacantesusuarioscvrec_Visible = 1;
               edtavVacantesusuariosreflab_Visible = 1;
               edtavVacantesusuariosexpsi_Visible = 1;
               edtavVacantesusuariosbusweb_Visible = 1;
               edtavVacantesusuariosavpriv_Visible = 1;
               edtavVacantesusuariosavconf_Visible = 1;
               edtavVacantesusuariosfecha3_Visible = 1;
               edtavVacantesusuariosmotd_Visible = 0;
               edtavVacantesusuariosfechad_Visible = 0;
               if ( A299VacantesUsuariosCVRec == 1 )
               {
                  AV23VacantesUsuariosCVRec = context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( ));
                  AssignAttri("", false, edtavVacantesusuarioscvrec_Internalname, AV23VacantesUsuariosCVRec);
                  AV48Vacantesusuarioscvrec_GXI = GXDbFile.PathToUrl( context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( )));
               }
               else
               {
                  AV23VacantesUsuariosCVRec = context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( ));
                  AssignAttri("", false, edtavVacantesusuarioscvrec_Internalname, AV23VacantesUsuariosCVRec);
                  AV48Vacantesusuarioscvrec_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( )));
               }
               if ( A300VacantesUsuariosRefLab == 1 )
               {
                  AV32VacantesUsuariosRefLab = context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( ));
                  AssignAttri("", false, edtavVacantesusuariosreflab_Internalname, AV32VacantesUsuariosRefLab);
                  AV49Vacantesusuariosreflab_GXI = GXDbFile.PathToUrl( context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( )));
               }
               else
               {
                  AV32VacantesUsuariosRefLab = context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( ));
                  AssignAttri("", false, edtavVacantesusuariosreflab_Internalname, AV32VacantesUsuariosRefLab);
                  AV49Vacantesusuariosreflab_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( )));
               }
               if ( A301VacantesUsuariosExPsi == 1 )
               {
                  AV25VacantesUsuariosExPsi = context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( ));
                  AssignAttri("", false, edtavVacantesusuariosexpsi_Internalname, AV25VacantesUsuariosExPsi);
                  AV50Vacantesusuariosexpsi_GXI = GXDbFile.PathToUrl( context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( )));
               }
               else
               {
                  AV25VacantesUsuariosExPsi = context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( ));
                  AssignAttri("", false, edtavVacantesusuariosexpsi_Internalname, AV25VacantesUsuariosExPsi);
                  AV50Vacantesusuariosexpsi_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( )));
               }
               if ( A302VacantesUsuariosBusWeb == 1 )
               {
                  AV21VacantesUsuariosBusWeb = context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( ));
                  AssignAttri("", false, edtavVacantesusuariosbusweb_Internalname, AV21VacantesUsuariosBusWeb);
                  AV51Vacantesusuariosbusweb_GXI = GXDbFile.PathToUrl( context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( )));
               }
               else
               {
                  AV21VacantesUsuariosBusWeb = context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( ));
                  AssignAttri("", false, edtavVacantesusuariosbusweb_Internalname, AV21VacantesUsuariosBusWeb);
                  AV51Vacantesusuariosbusweb_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( )));
               }
               if ( A303VacantesUsuariosAvPriv == 1 )
               {
                  AV20VacantesUsuariosAvPriv = context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( ));
                  AssignAttri("", false, edtavVacantesusuariosavpriv_Internalname, AV20VacantesUsuariosAvPriv);
                  AV52Vacantesusuariosavpriv_GXI = GXDbFile.PathToUrl( context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( )));
               }
               else
               {
                  AV20VacantesUsuariosAvPriv = context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( ));
                  AssignAttri("", false, edtavVacantesusuariosavpriv_Internalname, AV20VacantesUsuariosAvPriv);
                  AV52Vacantesusuariosavpriv_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( )));
               }
               if ( A304VacantesUsuariosAvConf == 1 )
               {
                  AV19VacantesUsuariosAvConf = context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( ));
                  AssignAttri("", false, edtavVacantesusuariosavconf_Internalname, AV19VacantesUsuariosAvConf);
                  AV53Vacantesusuariosavconf_GXI = GXDbFile.PathToUrl( context.GetImagePath( "8a22deb1-46d0-4a5c-903d-de3f04cfc60e", "", context.GetTheme( )));
               }
               else
               {
                  AV19VacantesUsuariosAvConf = context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( ));
                  AssignAttri("", false, edtavVacantesusuariosavconf_Internalname, AV19VacantesUsuariosAvConf);
                  AV53Vacantesusuariosavconf_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6f43abfa-1cbe-43d0-ab83-cca376c19820", "", context.GetTheme( )));
               }
               AV35VacantesUsuariosFecha3 = A314VacantesUsuariosFecha3;
               AssignAttri("", false, edtavVacantesusuariosfecha3_Internalname, context.localUtil.TToC( AV35VacantesUsuariosFecha3, 8, 5, 0, 3, "/", ":", " "));
            }
            else if ( AV24VacantesUsuariosEstatus == 3 )
            {
               edtavVacantesusuariosprefiltro_Visible = 0;
               edtavVacantesusuarioscv_Visible = 0;
               edtavVacantesusuariosextec_Visible = 0;
               edtavVacantesusuariosfechae_Visible = 0;
               edtavVacantesusuarioscvrec_Visible = 0;
               edtavVacantesusuariosreflab_Visible = 0;
               edtavVacantesusuariosexpsi_Visible = 0;
               edtavVacantesusuariosbusweb_Visible = 0;
               edtavVacantesusuariosavpriv_Visible = 0;
               edtavVacantesusuariosavconf_Visible = 0;
               edtavVacantesusuariosfecha3_Visible = 1;
               edtavVacantesusuariosfecha3_Titlefontname = "Fecha de envió a operaciones";
               AV35VacantesUsuariosFecha3 = A313VacantesUsuariosFechaA;
               AssignAttri("", false, edtavVacantesusuariosfecha3_Internalname, context.localUtil.TToC( AV35VacantesUsuariosFecha3, 8, 5, 0, 3, "/", ":", " "));
               edtavVacantesusuariosmotd_Visible = 0;
               edtavVacantesusuariosfechad_Visible = 0;
            }
            else if ( AV24VacantesUsuariosEstatus == 4 )
            {
               edtavVacantesusuariosprefiltro_Visible = 0;
               edtavVacantesusuarioscv_Visible = 0;
               edtavVacantesusuariosextec_Visible = 0;
               edtavVacantesusuariosfechae_Visible = 0;
               edtavVacantesusuarioscvrec_Visible = 0;
               edtavVacantesusuariosreflab_Visible = 0;
               edtavVacantesusuariosexpsi_Visible = 0;
               edtavVacantesusuariosbusweb_Visible = 0;
               edtavVacantesusuariosavpriv_Visible = 0;
               edtavVacantesusuariosavconf_Visible = 0;
               edtavVacantesusuariosmotd_Visible = 0;
               edtavVacantesusuariosfechad_Visible = 0;
            }
            else if ( AV24VacantesUsuariosEstatus == 5 )
            {
               edtavVacantesusuariosprefiltro_Visible = 0;
               edtavVacantesusuarioscv_Visible = 0;
               edtavVacantesusuariosextec_Visible = 0;
               edtavVacantesusuariosfechae_Visible = 0;
               edtavVacantesusuarioscvrec_Visible = 0;
               edtavVacantesusuariosreflab_Visible = 0;
               edtavVacantesusuariosexpsi_Visible = 0;
               edtavVacantesusuariosbusweb_Visible = 0;
               edtavVacantesusuariosavpriv_Visible = 0;
               edtavVacantesusuariosavconf_Visible = 0;
               edtavVacantesusuariosfecha3_Visible = 0;
               edtavVacantesusuariosmotd_Visible = 1;
               edtavVacantesusuariosfechad_Visible = 1;
               AV30VacantesUsuariosMotD = A294VacantesUsuariosMotD;
               AssignAttri("", false, edtavVacantesusuariosmotd_Internalname, AV30VacantesUsuariosMotD);
               AV27VacantesUsuariosFechaD = context.localUtil.Format( A289VacantesUsuariosFechaD, "99/99/99 99:99");
               AssignAttri("", false, edtavVacantesusuariosfechad_Internalname, AV27VacantesUsuariosFechaD);
            }
            else
            {
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 43;
            }
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               GXCCtl = "GRID1_nFirstRecordOnPage_" + sGXsfl_21_idx;
               GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
            }
            else
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( subGrid1_Islastpage == 1 ) || ( 10 == 0 ) || ( ( GRID1_nCurrentRecord >= GRID1_nFirstRecordOnPage ) && ( GRID1_nCurrentRecord < GRID1_nFirstRecordOnPage + subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_434( ) ;
               GRID1_nEOF = 1;
               GXCCtl = "GRID1_nEOF_" + sGXsfl_21_idx;
               GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
               if ( ( subGrid1_Islastpage == 1 ) && ( ((int)((GRID1_nCurrentRecord) % (subGrid1_fnc_Recordsperpage( )))) == 0 ) )
               {
                  GRID1_nFirstRecordOnPage = GRID1_nCurrentRecord;
               }
            }
            if ( GRID1_nCurrentRecord >= GRID1_nFirstRecordOnPage + subGrid1_fnc_Recordsperpage( ) )
            {
               GRID1_nEOF = 0;
               GXCCtl = "GRID1_nEOF_" + sGXsfl_21_idx;
               GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            }
            GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_43_Refreshing )
            {
               context.DoAjaxLoad(43, Grid1Row);
            }
            pr_default.readNext(4);
         }
         pr_default.close(4);
         /*  Sending Event outputs  */
         dynavUsuariosid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV13UsuariosId), 6, 0));
         dynavSubt_reclutadorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8SUBT_ReclutadorId), 6, 0));
         dynavVacantes_id_envio.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18vacantes_id_Envio), 4, 0));
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
         PA362( ) ;
         WS362( ) ;
         WE362( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714345840", true, true);
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
            context.AddJavascriptSource("wpreclusegusu.js", "?202262714345840", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_434( )
      {
         dynavVacantes_id_envio_Internalname = "vVACANTES_ID_ENVIO_"+sGXsfl_43_idx;
         edtavVacantesusuariosestatus_Internalname = "vVACANTESUSUARIOSESTATUS_"+sGXsfl_21_idx;
         edtavVacantesusuariosfechap_Internalname = "vVACANTESUSUARIOSFECHAP_"+sGXsfl_43_idx;
         dynavUsuariosid_Internalname = "vUSUARIOSID_"+sGXsfl_43_idx;
         edtavUsuariostelef_Internalname = "vUSUARIOSTELEF_"+sGXsfl_43_idx;
         edtavUsuarioscorreo_Internalname = "vUSUARIOSCORREO_"+sGXsfl_43_idx;
         dynavSubt_reclutadorid_Internalname = "vSUBT_RECLUTADORID_"+sGXsfl_43_idx;
         edtavVacantesusuariosfecha3_Internalname = "vVACANTESUSUARIOSFECHA3_"+sGXsfl_43_idx;
         edtavVacantesusuariosfechae_Internalname = "vVACANTESUSUARIOSFECHAE_"+sGXsfl_43_idx;
         edtavVacantesusuariosfechad_Internalname = "vVACANTESUSUARIOSFECHAD_"+sGXsfl_43_idx;
         edtavVacantesusuariosmotd_Internalname = "vVACANTESUSUARIOSMOTD_"+sGXsfl_43_idx;
         edtavVacantesusuariosprefiltro_Internalname = "vVACANTESUSUARIOSPREFILTRO_"+sGXsfl_43_idx;
         edtavVacantesusuarioscv_Internalname = "vVACANTESUSUARIOSCV_"+sGXsfl_43_idx;
         edtavVacantesusuariosextec_Internalname = "vVACANTESUSUARIOSEXTEC_"+sGXsfl_43_idx;
         edtavVacantesusuariosavconf_Internalname = "vVACANTESUSUARIOSAVCONF_"+sGXsfl_43_idx;
         edtavVacantesusuariosavpriv_Internalname = "vVACANTESUSUARIOSAVPRIV_"+sGXsfl_43_idx;
         edtavVacantesusuariosbusweb_Internalname = "vVACANTESUSUARIOSBUSWEB_"+sGXsfl_43_idx;
         edtavVacantesusuariosreflab_Internalname = "vVACANTESUSUARIOSREFLAB_"+sGXsfl_43_idx;
         edtavVacantesusuariosexpsi_Internalname = "vVACANTESUSUARIOSEXPSI_"+sGXsfl_43_idx;
         edtavVacantesusuarioscvrec_Internalname = "vVACANTESUSUARIOSCVREC_"+sGXsfl_43_idx;
      }

      protected void SubsflControlProps_fel_434( )
      {
         dynavVacantes_id_envio_Internalname = "vVACANTES_ID_ENVIO_"+sGXsfl_43_fel_idx;
         edtavVacantesusuariosestatus_Internalname = "vVACANTESUSUARIOSESTATUS_"+sGXsfl_21_idx;
         edtavVacantesusuariosfechap_Internalname = "vVACANTESUSUARIOSFECHAP_"+sGXsfl_43_fel_idx;
         dynavUsuariosid_Internalname = "vUSUARIOSID_"+sGXsfl_43_fel_idx;
         edtavUsuariostelef_Internalname = "vUSUARIOSTELEF_"+sGXsfl_43_fel_idx;
         edtavUsuarioscorreo_Internalname = "vUSUARIOSCORREO_"+sGXsfl_43_fel_idx;
         dynavSubt_reclutadorid_Internalname = "vSUBT_RECLUTADORID_"+sGXsfl_43_fel_idx;
         edtavVacantesusuariosfecha3_Internalname = "vVACANTESUSUARIOSFECHA3_"+sGXsfl_43_fel_idx;
         edtavVacantesusuariosfechae_Internalname = "vVACANTESUSUARIOSFECHAE_"+sGXsfl_43_fel_idx;
         edtavVacantesusuariosfechad_Internalname = "vVACANTESUSUARIOSFECHAD_"+sGXsfl_43_fel_idx;
         edtavVacantesusuariosmotd_Internalname = "vVACANTESUSUARIOSMOTD_"+sGXsfl_43_fel_idx;
         edtavVacantesusuariosprefiltro_Internalname = "vVACANTESUSUARIOSPREFILTRO_"+sGXsfl_43_fel_idx;
         edtavVacantesusuarioscv_Internalname = "vVACANTESUSUARIOSCV_"+sGXsfl_43_fel_idx;
         edtavVacantesusuariosextec_Internalname = "vVACANTESUSUARIOSEXTEC_"+sGXsfl_43_fel_idx;
         edtavVacantesusuariosavconf_Internalname = "vVACANTESUSUARIOSAVCONF_"+sGXsfl_43_fel_idx;
         edtavVacantesusuariosavpriv_Internalname = "vVACANTESUSUARIOSAVPRIV_"+sGXsfl_43_fel_idx;
         edtavVacantesusuariosbusweb_Internalname = "vVACANTESUSUARIOSBUSWEB_"+sGXsfl_43_fel_idx;
         edtavVacantesusuariosreflab_Internalname = "vVACANTESUSUARIOSREFLAB_"+sGXsfl_43_fel_idx;
         edtavVacantesusuariosexpsi_Internalname = "vVACANTESUSUARIOSEXPSI_"+sGXsfl_43_fel_idx;
         edtavVacantesusuarioscvrec_Internalname = "vVACANTESUSUARIOSCVREC_"+sGXsfl_43_fel_idx;
      }

      protected void sendrow_434( )
      {
         SubsflControlProps_434( ) ;
         WB360( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_43_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_43_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_43_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((dynavVacantes_id_envio.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( dynavVacantes_id_envio.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vVACANTES_ID_ENVIO_" + sGXsfl_43_idx;
               dynavVacantes_id_envio.Name = GXCCtl;
               dynavVacantes_id_envio.WebTags = "";
               dynavVacantes_id_envio.removeAllItems();
               /* Using cursor H00367 */
               pr_default.execute(5);
               while ( (pr_default.getStatus(5) != 101) )
               {
                  dynavVacantes_id_envio.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00367_A263Vacantes_Id[0]), 4, 0)), H00367_A264Vacantes_Nombre[0], 0);
                  pr_default.readNext(5);
               }
               pr_default.close(5);
               if ( dynavVacantes_id_envio.ItemCount > 0 )
               {
                  AV18vacantes_id_Envio = (short)(NumberUtil.Val( dynavVacantes_id_envio.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18vacantes_id_Envio), 4, 0))), "."));
                  AssignAttri("", false, dynavVacantes_id_envio_Internalname, StringUtil.LTrimStr( (decimal)(AV18vacantes_id_Envio), 4, 0));
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynavVacantes_id_envio,(String)dynavVacantes_id_envio_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV18vacantes_id_Envio), 4, 0)),(short)1,(String)dynavVacantes_id_envio_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",dynavVacantes_id_envio.Visible,dynavVacantes_id_envio.Enabled,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute",(String)"WWColumn",(String)"",(String)"",(String)"",(bool)false});
            dynavVacantes_id_envio.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18vacantes_id_Envio), 4, 0));
            AssignProp("", false, dynavVacantes_id_envio_Internalname, "Values", (String)(dynavVacantes_id_envio.ToJavascriptSource()), !bGXsfl_43_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtavVacantesusuariosestatus_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavVacantesusuariosestatus_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24VacantesUsuariosEstatus), 4, 0, ",", "")),((edtavVacantesusuariosestatus_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV24VacantesUsuariosEstatus), "ZZZ9")) : context.localUtil.Format( (decimal)(AV24VacantesUsuariosEstatus), "ZZZ9")),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavVacantesusuariosestatus_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(int)edtavVacantesusuariosestatus_Visible,(int)edtavVacantesusuariosestatus_Enabled,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)4,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)0,(bool)false,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "AttributeLeft";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavVacantesusuariosfechap_Internalname,(String)AV29VacantesUsuariosFechaP,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavVacantesusuariosfechap_Jsonclick,(short)0,(String)"AttributeLeft",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(int)edtavVacantesusuariosfechap_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)20,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)-1,(bool)false,(String)"",(String)"left",(bool)true,(String)""});
            GXVvUSUARIOSID_html364( ) ;
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( dynavUsuariosid.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vUSUARIOSID_" + sGXsfl_43_idx;
               dynavUsuariosid.Name = GXCCtl;
               dynavUsuariosid.WebTags = "";
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynavUsuariosid,(String)dynavUsuariosid_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV13UsuariosId), 6, 0)),(short)1,(String)dynavUsuariosid_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,dynavUsuariosid.Enabled,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute",(String)"WWColumn",(String)"",(String)"",(String)"",(bool)false});
            dynavUsuariosid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV13UsuariosId), 6, 0));
            AssignProp("", false, dynavUsuariosid_Internalname, "Values", (String)(dynavUsuariosid.ToJavascriptSource()), !bGXsfl_43_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavUsuariostelef_Internalname,StringUtil.RTrim( AV15UsuariosTelef),(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavUsuariostelef_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(int)edtavUsuariostelef_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)-1,(bool)false,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavUsuarioscorreo_Internalname,(String)AV12UsuariosCorreo,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavUsuarioscorreo_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(int)edtavUsuarioscorreo_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)100,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)0,(bool)false,(String)"",(String)"left",(bool)true,(String)""});
            GXVvSUBT_RECLUTADORID_html364( ) ;
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( dynavSubt_reclutadorid.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vSUBT_RECLUTADORID_" + sGXsfl_43_idx;
               dynavSubt_reclutadorid.Name = GXCCtl;
               dynavSubt_reclutadorid.WebTags = "";
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynavSubt_reclutadorid,(String)dynavSubt_reclutadorid_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV8SUBT_ReclutadorId), 6, 0)),(short)1,(String)dynavSubt_reclutadorid_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,dynavSubt_reclutadorid.Enabled,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute",(String)"WWColumn WWOptionalColumn",(String)"",(String)"",(String)"",(bool)false});
            dynavSubt_reclutadorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8SUBT_ReclutadorId), 6, 0));
            AssignProp("", false, dynavSubt_reclutadorid_Internalname, "Values", (String)(dynavSubt_reclutadorid.ToJavascriptSource()), !bGXsfl_43_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtavVacantesusuariosfecha3_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavVacantesusuariosfecha3_Internalname,context.localUtil.TToC( AV35VacantesUsuariosFecha3, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( AV35VacantesUsuariosFecha3, "99/99/99 99:99"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavVacantesusuariosfecha3_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(int)edtavVacantesusuariosfecha3_Visible,(int)edtavVacantesusuariosfecha3_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)14,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)0,(bool)false,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavVacantesusuariosfechae_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavVacantesusuariosfechae_Internalname,(String)AV28VacantesUsuariosFechaE,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavVacantesusuariosfechae_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(int)edtavVacantesusuariosfechae_Visible,(int)edtavVacantesusuariosfechae_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)20,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)-1,(bool)false,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavVacantesusuariosfechad_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavVacantesusuariosfechad_Internalname,(String)AV27VacantesUsuariosFechaD,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavVacantesusuariosfechad_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(int)edtavVacantesusuariosfechad_Visible,(int)edtavVacantesusuariosfechad_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)20,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)-1,(bool)false,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavVacantesusuariosmotd_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavVacantesusuariosmotd_Internalname,(String)AV30VacantesUsuariosMotD,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavVacantesusuariosmotd_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(int)edtavVacantesusuariosmotd_Visible,(int)edtavVacantesusuariosmotd_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)2048,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)-1,(bool)false,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavVacantesusuariosprefiltro_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV31VacantesUsuariosPrefiltro_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV31VacantesUsuariosPrefiltro))&&String.IsNullOrEmpty(StringUtil.RTrim( AV45Vacantesusuariosprefiltro_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV31VacantesUsuariosPrefiltro)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV31VacantesUsuariosPrefiltro)) ? AV45Vacantesusuariosprefiltro_GXI : context.PathToRelativeUrl( AV31VacantesUsuariosPrefiltro));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavVacantesusuariosprefiltro_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(int)edtavVacantesusuariosprefiltro_Visible,(short)0,(String)"",(String)"",(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"WWColumn",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV31VacantesUsuariosPrefiltro_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavVacantesusuarioscv_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV22VacantesUsuariosCV_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV22VacantesUsuariosCV))&&String.IsNullOrEmpty(StringUtil.RTrim( AV46Vacantesusuarioscv_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV22VacantesUsuariosCV)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV22VacantesUsuariosCV)) ? AV46Vacantesusuarioscv_GXI : context.PathToRelativeUrl( AV22VacantesUsuariosCV));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavVacantesusuarioscv_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(int)edtavVacantesusuarioscv_Visible,(short)0,(String)"",(String)"",(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"WWColumn",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV22VacantesUsuariosCV_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavVacantesusuariosextec_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV26VacantesUsuariosExTec_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV26VacantesUsuariosExTec))&&String.IsNullOrEmpty(StringUtil.RTrim( AV47Vacantesusuariosextec_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV26VacantesUsuariosExTec)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV26VacantesUsuariosExTec)) ? AV47Vacantesusuariosextec_GXI : context.PathToRelativeUrl( AV26VacantesUsuariosExTec));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavVacantesusuariosextec_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(int)edtavVacantesusuariosextec_Visible,(short)0,(String)"",(String)"",(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"WWColumn",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV26VacantesUsuariosExTec_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavVacantesusuariosavconf_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV19VacantesUsuariosAvConf_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV19VacantesUsuariosAvConf))&&String.IsNullOrEmpty(StringUtil.RTrim( AV53Vacantesusuariosavconf_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV19VacantesUsuariosAvConf)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV19VacantesUsuariosAvConf)) ? AV53Vacantesusuariosavconf_GXI : context.PathToRelativeUrl( AV19VacantesUsuariosAvConf));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavVacantesusuariosavconf_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(int)edtavVacantesusuariosavconf_Visible,(short)0,(String)"",(String)"",(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"WWColumn",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV19VacantesUsuariosAvConf_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavVacantesusuariosavpriv_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV20VacantesUsuariosAvPriv_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV20VacantesUsuariosAvPriv))&&String.IsNullOrEmpty(StringUtil.RTrim( AV52Vacantesusuariosavpriv_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV20VacantesUsuariosAvPriv)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV20VacantesUsuariosAvPriv)) ? AV52Vacantesusuariosavpriv_GXI : context.PathToRelativeUrl( AV20VacantesUsuariosAvPriv));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavVacantesusuariosavpriv_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(int)edtavVacantesusuariosavpriv_Visible,(short)0,(String)"",(String)"",(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"WWColumn",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV20VacantesUsuariosAvPriv_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavVacantesusuariosbusweb_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV21VacantesUsuariosBusWeb_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV21VacantesUsuariosBusWeb))&&String.IsNullOrEmpty(StringUtil.RTrim( AV51Vacantesusuariosbusweb_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV21VacantesUsuariosBusWeb)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV21VacantesUsuariosBusWeb)) ? AV51Vacantesusuariosbusweb_GXI : context.PathToRelativeUrl( AV21VacantesUsuariosBusWeb));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavVacantesusuariosbusweb_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(int)edtavVacantesusuariosbusweb_Visible,(short)0,(String)"",(String)"",(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"WWColumn",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV21VacantesUsuariosBusWeb_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavVacantesusuariosreflab_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV32VacantesUsuariosRefLab_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV32VacantesUsuariosRefLab))&&String.IsNullOrEmpty(StringUtil.RTrim( AV49Vacantesusuariosreflab_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV32VacantesUsuariosRefLab)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV32VacantesUsuariosRefLab)) ? AV49Vacantesusuariosreflab_GXI : context.PathToRelativeUrl( AV32VacantesUsuariosRefLab));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavVacantesusuariosreflab_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(int)edtavVacantesusuariosreflab_Visible,(short)0,(String)"",(String)"",(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"WWColumn",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV32VacantesUsuariosRefLab_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavVacantesusuariosexpsi_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV25VacantesUsuariosExPsi_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV25VacantesUsuariosExPsi))&&String.IsNullOrEmpty(StringUtil.RTrim( AV50Vacantesusuariosexpsi_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV25VacantesUsuariosExPsi)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV25VacantesUsuariosExPsi)) ? AV50Vacantesusuariosexpsi_GXI : context.PathToRelativeUrl( AV25VacantesUsuariosExPsi));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavVacantesusuariosexpsi_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(int)edtavVacantesusuariosexpsi_Visible,(short)0,(String)"",(String)"",(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"WWColumn",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV25VacantesUsuariosExPsi_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavVacantesusuarioscvrec_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV23VacantesUsuariosCVRec_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV23VacantesUsuariosCVRec))&&String.IsNullOrEmpty(StringUtil.RTrim( AV48Vacantesusuarioscvrec_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV23VacantesUsuariosCVRec)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV23VacantesUsuariosCVRec)) ? AV48Vacantesusuarioscvrec_GXI : context.PathToRelativeUrl( AV23VacantesUsuariosCVRec));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavVacantesusuarioscvrec_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(int)edtavVacantesusuarioscvrec_Visible,(short)0,(String)"",(String)"",(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"WWColumn",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV23VacantesUsuariosCVRec_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes364( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_43_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_43_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0") + sGXsfl_21_idx;
            SubsflControlProps_434( ) ;
         }
         /* End function sendrow_434 */
      }

      protected void SubsflControlProps_212( )
      {
         lblTitletext_Internalname = "TITLETEXT_"+sGXsfl_21_idx;
         edtVacantesUsuariosEstatus_Internalname = "VACANTESUSUARIOSESTATUS_"+sGXsfl_21_idx;
         edtavVacantesusuariosestatus_Internalname = "vVACANTESUSUARIOSESTATUS_"+sGXsfl_21_idx;
         subGrid1_Internalname = "GRID1_"+sGXsfl_21_idx;
      }

      protected void SubsflControlProps_fel_212( )
      {
         lblTitletext_Internalname = "TITLETEXT_"+sGXsfl_21_fel_idx;
         edtVacantesUsuariosEstatus_Internalname = "VACANTESUSUARIOSESTATUS_"+sGXsfl_21_fel_idx;
         edtavVacantesusuariosestatus_Internalname = "vVACANTESUSUARIOSESTATUS_"+sGXsfl_21_fel_idx;
         subGrid1_Internalname = "GRID1_"+sGXsfl_21_fel_idx;
      }

      protected void sendrow_212( )
      {
         SubsflControlProps_212( ) ;
         WB360( ) ;
         Grid2Row = GXWebRow.GetNew(context,Grid2Container);
         if ( subGrid2_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid2_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Odd";
            }
         }
         else if ( subGrid2_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid2_Backstyle = 0;
            subGrid2_Backcolor = subGrid2_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Uniform";
            }
         }
         else if ( subGrid2_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid2_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Odd";
            }
            subGrid2_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGrid2_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid2_Backstyle = 1;
            if ( ((int)((nGXsfl_21_idx) % (2))) == 0 )
            {
               subGrid2_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Even";
               }
            }
            else
            {
               subGrid2_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGrid2_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_21_idx+"\">") ;
         }
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)divGrid2table_Internalname+"_"+sGXsfl_21_idx,(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"Table",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"row",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"col-xs-12",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)divTabletop_Internalname+"_"+sGXsfl_21_idx,(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)divTabletop_Class,(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"row",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"col-xs-7 col-sm-2 col-sm-offset-1",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Text block */
         Grid2Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(String)lblTitletext_Internalname,(String)lblTitletext_Caption,(String)"",(String)"",(String)lblTitletext_Jsonclick,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"SubTitle",(short)0,(String)"",(short)1,(short)1,(short)0});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"row",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"col-xs-12 col-sm-6",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(int)edtVacantesUsuariosEstatus_Visible,(short)0,(String)"px",(short)0,(String)"px",(String)"form-group gx-form-group",(String)"left",(String)"top",(String)""+" data-gx-for=\""+edtVacantesUsuariosEstatus_Internalname+"\"",(String)"",(String)"div"});
         /* Attribute/Variable Label */
         Grid2Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(String)edtVacantesUsuariosEstatus_Internalname,(String)"Estatús Vacante",(String)"col-sm-3 AttributeLabel",(short)1,(bool)true,(String)""});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"col-sm-9 gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtVacantesUsuariosEstatus_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A290VacantesUsuariosEstatus), 4, 0, ",", "")),context.localUtil.Format( (decimal)(A290VacantesUsuariosEstatus), "ZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtVacantesUsuariosEstatus_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(int)edtVacantesUsuariosEstatus_Visible,(short)0,(short)0,(String)"number",(String)"1",(short)4,(String)"chr",(short)1,(String)"row",(short)4,(short)0,(short)0,(short)21,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"col-xs-12 col-sm-6",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(int)edtavVacantesusuariosestatus_Visible,(short)0,(String)"px",(short)0,(String)"px",(String)"form-group gx-form-group",(String)"left",(String)"top",(String)""+" data-gx-for=\""+edtavVacantesusuariosestatus_Internalname+"\"",(String)"",(String)"div"});
         /* Attribute/Variable Label */
         Grid2Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(String)edtavVacantesusuariosestatus_Internalname,(String)"Estatús Vacante",(String)"col-sm-3 AttributeLabel",(short)1,(bool)true,(String)""});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"col-sm-9 gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavVacantesusuariosestatus_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24VacantesUsuariosEstatus), 4, 0, ",", "")),((edtavVacantesusuariosestatus_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV24VacantesUsuariosEstatus), "ZZZ9")) : context.localUtil.Format( (decimal)(AV24VacantesUsuariosEstatus), "ZZZ9")),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavVacantesusuariosestatus_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(int)edtavVacantesusuariosestatus_Visible,(int)edtavVacantesusuariosestatus_Enabled,(short)0,(String)"number",(String)"1",(short)4,(String)"chr",(short)1,(String)"row",(short)4,(short)0,(short)0,(short)21,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"row",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"col-xs-12",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Table start */
         Grid2Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(String)tblTable1_Internalname+"_"+sGXsfl_21_idx,(short)1,(String)"Table",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(short)2,(String)"",(String)"",(String)"",(String)"px",(String)"px",(String)""});
         Grid2Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         Grid2Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"",(String)""});
         /*  Child Grid Control  */
         Grid2Row.AddColumnProperties("subfile", -1, isAjaxCallMode( ), new Object[] {(String)"Grid1Container"});
         if ( isAjaxCallMode( ) )
         {
            Grid1Container = new GXWebGrid( context);
         }
         else
         {
            Grid1Container.Clear();
         }
         Grid1Container.SetWrapped(nGXWrapped);
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"43\">") ;
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
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((dynavVacantes_id_envio.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Nombre Vacante") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavVacantesusuariosestatus_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Estatús Vacante") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeLeft"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Fecha Postulación") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nombre") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Teléfono") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Correo electrónico") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Reclutador") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavVacantesusuariosfecha3_Visible==0) ? "display:none;" : "")+"font-family:'"+edtavVacantesusuariosfecha3_Titlefontname+"';"+"\" "+">") ;
            context.SendWebValue( "Fecha llegada") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavVacantesusuariosfechae_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Fecha Examen Técnico") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavVacantesusuariosfechad_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Fecha Descarte") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavVacantesusuariosmotd_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Motivo de Descarte") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Image"+"\" "+" style=\""+((edtavVacantesusuariosprefiltro_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Cargo Prefiltro") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Image"+"\" "+" style=\""+((edtavVacantesusuarioscv_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Cargo CV") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Image"+"\" "+" style=\""+((edtavVacantesusuariosextec_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Examen Técnico") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Image"+"\" "+" style=\""+((edtavVacantesusuariosavconf_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Cargo Aviso Confidencialidad") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Image"+"\" "+" style=\""+((edtavVacantesusuariosavpriv_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Cargo Aviso Privacidad") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Image"+"\" "+" style=\""+((edtavVacantesusuariosbusweb_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Cargo Busqueda Web") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Image"+"\" "+" style=\""+((edtavVacantesusuariosreflab_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Cargo Referencias Laborales") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Image"+"\" "+" style=\""+((edtavVacantesusuariosexpsi_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Cargo Examén Psicometrico") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Image"+"\" "+" style=\""+((edtavVacantesusuarioscvrec_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Cargo CV Recortado") ;
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
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18vacantes_id_Envio), 4, 0, ".", "")));
            Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynavVacantes_id_envio.Visible), 5, 0, ".", "")));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynavVacantes_id_envio.Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24VacantesUsuariosEstatus), 4, 0, ".", "")));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantesusuariosestatus_Enabled), 5, 0, ".", "")));
            Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantesusuariosestatus_Visible), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", AV29VacantesUsuariosFechaP);
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantesusuariosfechap_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13UsuariosId), 6, 0, ".", "")));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynavUsuariosid.Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( AV15UsuariosTelef));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsuariostelef_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", AV12UsuariosCorreo);
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsuarioscorreo_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8SUBT_ReclutadorId), 6, 0, ".", "")));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynavSubt_reclutadorid.Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.localUtil.TToC( AV35VacantesUsuariosFecha3, 10, 8, 0, 3, "/", ":", " "));
            Grid1Column.AddObjectProperty("Titlefontname", StringUtil.RTrim( edtavVacantesusuariosfecha3_Titlefontname));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantesusuariosfecha3_Enabled), 5, 0, ".", "")));
            Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantesusuariosfecha3_Visible), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", AV28VacantesUsuariosFechaE);
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantesusuariosfechae_Enabled), 5, 0, ".", "")));
            Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantesusuariosfechae_Visible), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", AV27VacantesUsuariosFechaD);
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantesusuariosfechad_Enabled), 5, 0, ".", "")));
            Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantesusuariosfechad_Visible), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", AV30VacantesUsuariosMotD);
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantesusuariosmotd_Enabled), 5, 0, ".", "")));
            Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantesusuariosmotd_Visible), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV31VacantesUsuariosPrefiltro));
            Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantesusuariosprefiltro_Visible), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV22VacantesUsuariosCV));
            Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantesusuarioscv_Visible), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV26VacantesUsuariosExTec));
            Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantesusuariosextec_Visible), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV19VacantesUsuariosAvConf));
            Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantesusuariosavconf_Visible), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV20VacantesUsuariosAvPriv));
            Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantesusuariosavpriv_Visible), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV21VacantesUsuariosBusWeb));
            Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantesusuariosbusweb_Visible), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV32VacantesUsuariosRefLab));
            Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantesusuariosreflab_Visible), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV25VacantesUsuariosExPsi));
            Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantesusuariosexpsi_Visible), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV23VacantesUsuariosCVRec));
            Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVacantesusuarioscvrec_Visible), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
         RF364( ) ;
         nRC_GXsfl_43 = (int)(nGXsfl_43_idx-1);
         send_integrity_footer_hashes( ) ;
         GXCCtl = "nRC_GXsfl_43_" + sGXsfl_21_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_43), 8, 0, ",", "")));
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "</table>") ;
         }
         else
         {
            Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
            Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
            if ( ! isAjaxCallMode( ) )
            {
               GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"_"+sGXsfl_21_idx, Grid1Container.ToJavascriptSource());
            }
            if ( isAjaxCallMode( ) )
            {
               Grid2Row.AddGrid("Grid1", Grid1Container);
            }
            if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
            {
               GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V_"+sGXsfl_21_idx, Grid1Container.GridValuesHidden());
            }
            else
            {
               context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V_"+sGXsfl_21_idx+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
            }
         }
         if ( Grid2Container.GetWrapped() == 1 )
         {
            Grid2Container.CloseTag("cell");
         }
         if ( Grid2Container.GetWrapped() == 1 )
         {
            Grid2Container.CloseTag("row");
         }
         if ( Grid2Container.GetWrapped() == 1 )
         {
            Grid2Container.CloseTag("table");
         }
         /* End of table */
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         send_integrity_lvl_hashes362( ) ;
         GXCCtl = "GRID1_nFirstRecordOnPage_" + sGXsfl_21_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GXCCtl = "GRID1_nEOF_" + sGXsfl_21_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GRID1_nFirstRecordOnPage = 0;
         GRID1_nCurrentRecord = 0;
         /* End of Columns property logic. */
         Grid2Container.AddRow(Grid2Row);
         nGXsfl_21_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_21_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_21_idx+1);
         sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
         SubsflControlProps_212( ) ;
         /* End function sendrow_212 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vVACANTES_ID_ENVIO_" + sGXsfl_43_idx;
         dynavVacantes_id_envio.Name = GXCCtl;
         dynavVacantes_id_envio.WebTags = "";
         dynavVacantes_id_envio.removeAllItems();
         /* Using cursor H00368 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            dynavVacantes_id_envio.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00368_A263Vacantes_Id[0]), 4, 0)), H00368_A264Vacantes_Nombre[0], 0);
            pr_default.readNext(6);
         }
         pr_default.close(6);
         if ( dynavVacantes_id_envio.ItemCount > 0 )
         {
            AV18vacantes_id_Envio = (short)(NumberUtil.Val( dynavVacantes_id_envio.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18vacantes_id_Envio), 4, 0))), "."));
            AssignAttri("", false, dynavVacantes_id_envio_Internalname, StringUtil.LTrimStr( (decimal)(AV18vacantes_id_Envio), 4, 0));
         }
         GXCCtl = "vUSUARIOSID_" + sGXsfl_43_idx;
         dynavUsuariosid.Name = GXCCtl;
         dynavUsuariosid.WebTags = "";
         GXCCtl = "vSUBT_RECLUTADORID_" + sGXsfl_43_idx;
         dynavSubt_reclutadorid.Name = GXCCtl;
         dynavSubt_reclutadorid.WebTags = "";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock4_Internalname = "TEXTBLOCK4";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         imgImage1_Internalname = "IMAGE1";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         divTable3_Internalname = "TABLE3";
         lblTitletext_Internalname = "TITLETEXT";
         divTabletop_Internalname = "TABLETOP";
         edtVacantesUsuariosEstatus_Internalname = "VACANTESUSUARIOSESTATUS";
         edtavVacantesusuariosestatus_Internalname = "vVACANTESUSUARIOSESTATUS";
         dynavVacantes_id_envio_Internalname = "vVACANTES_ID_ENVIO";
         edtavVacantesusuariosestatus_Internalname = "vVACANTESUSUARIOSESTATUS";
         edtavVacantesusuariosfechap_Internalname = "vVACANTESUSUARIOSFECHAP";
         dynavUsuariosid_Internalname = "vUSUARIOSID";
         edtavUsuariostelef_Internalname = "vUSUARIOSTELEF";
         edtavUsuarioscorreo_Internalname = "vUSUARIOSCORREO";
         dynavSubt_reclutadorid_Internalname = "vSUBT_RECLUTADORID";
         edtavVacantesusuariosfecha3_Internalname = "vVACANTESUSUARIOSFECHA3";
         edtavVacantesusuariosfechae_Internalname = "vVACANTESUSUARIOSFECHAE";
         edtavVacantesusuariosfechad_Internalname = "vVACANTESUSUARIOSFECHAD";
         edtavVacantesusuariosmotd_Internalname = "vVACANTESUSUARIOSMOTD";
         edtavVacantesusuariosprefiltro_Internalname = "vVACANTESUSUARIOSPREFILTRO";
         edtavVacantesusuarioscv_Internalname = "vVACANTESUSUARIOSCV";
         edtavVacantesusuariosextec_Internalname = "vVACANTESUSUARIOSEXTEC";
         edtavVacantesusuariosavconf_Internalname = "vVACANTESUSUARIOSAVCONF";
         edtavVacantesusuariosavpriv_Internalname = "vVACANTESUSUARIOSAVPRIV";
         edtavVacantesusuariosbusweb_Internalname = "vVACANTESUSUARIOSBUSWEB";
         edtavVacantesusuariosreflab_Internalname = "vVACANTESUSUARIOSREFLAB";
         edtavVacantesusuariosexpsi_Internalname = "vVACANTESUSUARIOSEXPSI";
         edtavVacantesusuarioscvrec_Internalname = "vVACANTESUSUARIOSCVREC";
         tblTable1_Internalname = "TABLE1";
         divGrid2table_Internalname = "GRID2TABLE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
         subGrid2_Internalname = "GRID2";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtavVacantesusuariosfecha3_Titlefontname = "Arial";
         edtVacantesUsuariosEstatus_Jsonclick = "";
         lblTitletext_Caption = "";
         subGrid2_Class = "FreeStyleGrid";
         edtavVacantesusuarioscvrec_Visible = -1;
         edtavVacantesusuariosexpsi_Visible = -1;
         edtavVacantesusuariosreflab_Visible = -1;
         edtavVacantesusuariosbusweb_Visible = -1;
         edtavVacantesusuariosavpriv_Visible = -1;
         edtavVacantesusuariosavconf_Visible = -1;
         edtavVacantesusuariosextec_Visible = -1;
         edtavVacantesusuarioscv_Visible = -1;
         edtavVacantesusuariosprefiltro_Visible = -1;
         edtavVacantesusuariosmotd_Jsonclick = "";
         edtavVacantesusuariosmotd_Enabled = 0;
         edtavVacantesusuariosmotd_Visible = -1;
         edtavVacantesusuariosfechad_Jsonclick = "";
         edtavVacantesusuariosfechad_Enabled = 0;
         edtavVacantesusuariosfechad_Visible = -1;
         edtavVacantesusuariosfechae_Jsonclick = "";
         edtavVacantesusuariosfechae_Enabled = 0;
         edtavVacantesusuariosfechae_Visible = -1;
         edtavVacantesusuariosfecha3_Jsonclick = "";
         edtavVacantesusuariosfecha3_Enabled = 0;
         edtavVacantesusuariosfecha3_Visible = -1;
         dynavSubt_reclutadorid_Jsonclick = "";
         dynavSubt_reclutadorid.Enabled = 0;
         edtavUsuarioscorreo_Jsonclick = "";
         edtavUsuarioscorreo_Enabled = 0;
         edtavUsuariostelef_Jsonclick = "";
         edtavUsuariostelef_Enabled = 0;
         dynavUsuariosid_Jsonclick = "";
         dynavUsuariosid.Enabled = 0;
         edtavVacantesusuariosfechap_Jsonclick = "";
         edtavVacantesusuariosfechap_Enabled = 0;
         edtavVacantesusuariosestatus_Jsonclick = "";
         dynavVacantes_id_envio_Jsonclick = "";
         dynavVacantes_id_envio.Enabled = 0;
         subGrid1_Class = "WorkWith";
         subGrid1_Backcolorstyle = 0;
         divTabletop_Class = "TableTopSearch";
         subGrid2_Allowcollapsing = 0;
         edtavVacantesusuariosestatus_Enabled = 0;
         lblTextblock2_Caption = "";
         subGrid2_Backcolorstyle = 0;
         lblTextblock1_Visible = 1;
         lblTextblock2_Fontbold = 0;
         lblTextblock2_Caption = "";
         lblTextblock4_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "wp Reclu Usuario";
         edtVacantesUsuariosEstatus_Visible = 1;
         subGrid1_Rows = 10;
         dynavVacantes_id_envio.Visible = -1;
         edtavVacantesusuariosestatus_Visible = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'edtVacantesUsuariosEstatus_Visible',ctrl:'VACANTESUSUARIOSESTATUS',prop:'Visible'},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'edtavVacantesusuariosestatus_Visible',ctrl:'vVACANTESUSUARIOSESTATUS',prop:'Visible'},{av:'dynavVacantes_id_envio'},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'A290VacantesUsuariosEstatus',fld:'VACANTESUSUARIOSESTATUS',pic:'ZZZ9'},{av:'AV24VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A260UsuariosTelef',fld:'USUARIOSTELEF',pic:''},{av:'A261UsuariosCorreo',fld:'USUARIOSCORREO',pic:''},{av:'A284SUBT_ReclutadorId',fld:'SUBT_RECLUTADORID',pic:'ZZZZZ9'},{av:'A288VacantesUsuariosFechaP',fld:'VACANTESUSUARIOSFECHAP',pic:'99/99/9999 99:99'},{av:'A292VacantesUsuariosCV',fld:'VACANTESUSUARIOSCV',pic:'ZZZ9'},{av:'A291VacantesUsuariosPrefiltro',fld:'VACANTESUSUARIOSPREFILTRO',pic:'ZZZ9'},{av:'A295VacantesUsuariosFechaE',fld:'VACANTESUSUARIOSFECHAE',pic:'99/99/99 99:99'},{av:'A293VacantesUsuariosExTec',fld:'VACANTESUSUARIOSEXTEC',pic:'ZZZ9'},{av:'A314VacantesUsuariosFecha3',fld:'VACANTESUSUARIOSFECHA3',pic:'99/99/99 99:99'},{av:'A304VacantesUsuariosAvConf',fld:'VACANTESUSUARIOSAVCONF',pic:'ZZZ9'},{av:'A303VacantesUsuariosAvPriv',fld:'VACANTESUSUARIOSAVPRIV',pic:'ZZZ9'},{av:'A302VacantesUsuariosBusWeb',fld:'VACANTESUSUARIOSBUSWEB',pic:'ZZZ9'},{av:'A301VacantesUsuariosExPsi',fld:'VACANTESUSUARIOSEXPSI',pic:'ZZZ9'},{av:'A300VacantesUsuariosRefLab',fld:'VACANTESUSUARIOSREFLAB',pic:'ZZZ9'},{av:'A299VacantesUsuariosCVRec',fld:'VACANTESUSUARIOSCVREC',pic:'ZZZ9'},{av:'A313VacantesUsuariosFechaA',fld:'VACANTESUSUARIOSFECHAA',pic:'99/99/99 99:99'},{av:'A289VacantesUsuariosFechaD',fld:'VACANTESUSUARIOSFECHAD',pic:'99/99/99 99:99'},{av:'A294VacantesUsuariosMotD',fld:'VACANTESUSUARIOSMOTD',pic:''},{av:'AV38UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID1.LOAD","{handler:'E14364',iparms:[{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'A290VacantesUsuariosEstatus',fld:'VACANTESUSUARIOSESTATUS',pic:'ZZZ9'},{av:'AV24VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV38UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZ9',hsh:true},{av:'A260UsuariosTelef',fld:'USUARIOSTELEF',pic:''},{av:'A261UsuariosCorreo',fld:'USUARIOSCORREO',pic:''},{av:'A284SUBT_ReclutadorId',fld:'SUBT_RECLUTADORID',pic:'ZZZZZ9'},{av:'A288VacantesUsuariosFechaP',fld:'VACANTESUSUARIOSFECHAP',pic:'99/99/9999 99:99'},{av:'A292VacantesUsuariosCV',fld:'VACANTESUSUARIOSCV',pic:'ZZZ9'},{av:'A291VacantesUsuariosPrefiltro',fld:'VACANTESUSUARIOSPREFILTRO',pic:'ZZZ9'},{av:'A295VacantesUsuariosFechaE',fld:'VACANTESUSUARIOSFECHAE',pic:'99/99/99 99:99'},{av:'A293VacantesUsuariosExTec',fld:'VACANTESUSUARIOSEXTEC',pic:'ZZZ9'},{av:'A314VacantesUsuariosFecha3',fld:'VACANTESUSUARIOSFECHA3',pic:'99/99/99 99:99'},{av:'A304VacantesUsuariosAvConf',fld:'VACANTESUSUARIOSAVCONF',pic:'ZZZ9'},{av:'A303VacantesUsuariosAvPriv',fld:'VACANTESUSUARIOSAVPRIV',pic:'ZZZ9'},{av:'A302VacantesUsuariosBusWeb',fld:'VACANTESUSUARIOSBUSWEB',pic:'ZZZ9'},{av:'A301VacantesUsuariosExPsi',fld:'VACANTESUSUARIOSEXPSI',pic:'ZZZ9'},{av:'A300VacantesUsuariosRefLab',fld:'VACANTESUSUARIOSREFLAB',pic:'ZZZ9'},{av:'A299VacantesUsuariosCVRec',fld:'VACANTESUSUARIOSCVREC',pic:'ZZZ9'},{av:'A313VacantesUsuariosFechaA',fld:'VACANTESUSUARIOSFECHAA',pic:'99/99/99 99:99'},{av:'A289VacantesUsuariosFechaD',fld:'VACANTESUSUARIOSFECHAD',pic:'99/99/99 99:99'},{av:'A294VacantesUsuariosMotD',fld:'VACANTESUSUARIOSMOTD',pic:''}]");
         setEventMetadata("GRID1.LOAD",",oparms:[{av:'dynavUsuariosid'},{av:'AV13UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV15UsuariosTelef',fld:'vUSUARIOSTELEF',pic:''},{av:'AV12UsuariosCorreo',fld:'vUSUARIOSCORREO',pic:''},{av:'dynavSubt_reclutadorid'},{av:'AV8SUBT_ReclutadorId',fld:'vSUBT_RECLUTADORID',pic:'ZZZZZ9'},{av:'AV29VacantesUsuariosFechaP',fld:'vVACANTESUSUARIOSFECHAP',pic:''},{av:'dynavVacantes_id_envio'},{av:'AV18vacantes_id_Envio',fld:'vVACANTES_ID_ENVIO',pic:'ZZZ9'},{av:'edtavVacantesusuariosprefiltro_Visible',ctrl:'vVACANTESUSUARIOSPREFILTRO',prop:'Visible'},{av:'edtavVacantesusuarioscv_Visible',ctrl:'vVACANTESUSUARIOSCV',prop:'Visible'},{av:'edtavVacantesusuariosextec_Visible',ctrl:'vVACANTESUSUARIOSEXTEC',prop:'Visible'},{av:'edtavVacantesusuariosfechae_Visible',ctrl:'vVACANTESUSUARIOSFECHAE',prop:'Visible'},{av:'edtavVacantesusuarioscvrec_Visible',ctrl:'vVACANTESUSUARIOSCVREC',prop:'Visible'},{av:'edtavVacantesusuariosreflab_Visible',ctrl:'vVACANTESUSUARIOSREFLAB',prop:'Visible'},{av:'edtavVacantesusuariosexpsi_Visible',ctrl:'vVACANTESUSUARIOSEXPSI',prop:'Visible'},{av:'edtavVacantesusuariosbusweb_Visible',ctrl:'vVACANTESUSUARIOSBUSWEB',prop:'Visible'},{av:'edtavVacantesusuariosavpriv_Visible',ctrl:'vVACANTESUSUARIOSAVPRIV',prop:'Visible'},{av:'edtavVacantesusuariosavconf_Visible',ctrl:'vVACANTESUSUARIOSAVCONF',prop:'Visible'},{av:'edtavVacantesusuariosfecha3_Visible',ctrl:'vVACANTESUSUARIOSFECHA3',prop:'Visible'},{av:'edtavVacantesusuariosmotd_Visible',ctrl:'vVACANTESUSUARIOSMOTD',prop:'Visible'},{av:'edtavVacantesusuariosfechad_Visible',ctrl:'vVACANTESUSUARIOSFECHAD',prop:'Visible'},{av:'AV30VacantesUsuariosMotD',fld:'vVACANTESUSUARIOSMOTD',pic:''},{av:'AV27VacantesUsuariosFechaD',fld:'vVACANTESUSUARIOSFECHAD',pic:''},{av:'edtavVacantesusuariosfecha3_Titlefontname',ctrl:'vVACANTESUSUARIOSFECHA3',prop:'Titlefontname'},{av:'AV35VacantesUsuariosFecha3',fld:'vVACANTESUSUARIOSFECHA3',pic:'99/99/99 99:99'},{av:'AV23VacantesUsuariosCVRec',fld:'vVACANTESUSUARIOSCVREC',pic:''},{av:'AV32VacantesUsuariosRefLab',fld:'vVACANTESUSUARIOSREFLAB',pic:''},{av:'AV25VacantesUsuariosExPsi',fld:'vVACANTESUSUARIOSEXPSI',pic:''},{av:'AV21VacantesUsuariosBusWeb',fld:'vVACANTESUSUARIOSBUSWEB',pic:''},{av:'AV20VacantesUsuariosAvPriv',fld:'vVACANTESUSUARIOSAVPRIV',pic:''},{av:'AV19VacantesUsuariosAvConf',fld:'vVACANTESUSUARIOSAVCONF',pic:''},{av:'AV26VacantesUsuariosExTec',fld:'vVACANTESUSUARIOSEXTEC',pic:''},{av:'AV28VacantesUsuariosFechaE',fld:'vVACANTESUSUARIOSFECHAE',pic:''},{av:'AV31VacantesUsuariosPrefiltro',fld:'vVACANTESUSUARIOSPREFILTRO',pic:''},{av:'AV22VacantesUsuariosCV',fld:'vVACANTESUSUARIOSCV',pic:''}]}");
         setEventMetadata("GRID2.LOAD","{handler:'E13362',iparms:[{av:'A290VacantesUsuariosEstatus',fld:'VACANTESUSUARIOSESTATUS',pic:'ZZZ9'}]");
         setEventMetadata("GRID2.LOAD",",oparms:[{av:'AV24VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'},{av:'lblTitletext_Caption',ctrl:'TITLETEXT',prop:'Caption'},{av:'divTabletop_Class',ctrl:'TABLETOP',prop:'Class'}]}");
         setEventMetadata("'REFRESCAR'","{handler:'E11362',iparms:[{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV38UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZ9',hsh:true},{av:'edtavVacantesusuariosestatus_Visible',ctrl:'vVACANTESUSUARIOSESTATUS',prop:'Visible'},{av:'edtVacantesUsuariosEstatus_Visible',ctrl:'VACANTESUSUARIOSESTATUS',prop:'Visible'},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'dynavVacantes_id_envio'},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'A290VacantesUsuariosEstatus',fld:'VACANTESUSUARIOSESTATUS',pic:'ZZZ9'},{av:'AV24VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A260UsuariosTelef',fld:'USUARIOSTELEF',pic:''},{av:'A261UsuariosCorreo',fld:'USUARIOSCORREO',pic:''},{av:'A284SUBT_ReclutadorId',fld:'SUBT_RECLUTADORID',pic:'ZZZZZ9'},{av:'A288VacantesUsuariosFechaP',fld:'VACANTESUSUARIOSFECHAP',pic:'99/99/9999 99:99'},{av:'A292VacantesUsuariosCV',fld:'VACANTESUSUARIOSCV',pic:'ZZZ9'},{av:'A291VacantesUsuariosPrefiltro',fld:'VACANTESUSUARIOSPREFILTRO',pic:'ZZZ9'},{av:'A295VacantesUsuariosFechaE',fld:'VACANTESUSUARIOSFECHAE',pic:'99/99/99 99:99'},{av:'A293VacantesUsuariosExTec',fld:'VACANTESUSUARIOSEXTEC',pic:'ZZZ9'},{av:'A314VacantesUsuariosFecha3',fld:'VACANTESUSUARIOSFECHA3',pic:'99/99/99 99:99'},{av:'A304VacantesUsuariosAvConf',fld:'VACANTESUSUARIOSAVCONF',pic:'ZZZ9'},{av:'A303VacantesUsuariosAvPriv',fld:'VACANTESUSUARIOSAVPRIV',pic:'ZZZ9'},{av:'A302VacantesUsuariosBusWeb',fld:'VACANTESUSUARIOSBUSWEB',pic:'ZZZ9'},{av:'A301VacantesUsuariosExPsi',fld:'VACANTESUSUARIOSEXPSI',pic:'ZZZ9'},{av:'A300VacantesUsuariosRefLab',fld:'VACANTESUSUARIOSREFLAB',pic:'ZZZ9'},{av:'A299VacantesUsuariosCVRec',fld:'VACANTESUSUARIOSCVREC',pic:'ZZZ9'},{av:'A313VacantesUsuariosFechaA',fld:'VACANTESUSUARIOSFECHAA',pic:'99/99/99 99:99'},{av:'A289VacantesUsuariosFechaD',fld:'VACANTESUSUARIOSFECHAD',pic:'99/99/99 99:99'},{av:'A294VacantesUsuariosMotD',fld:'VACANTESUSUARIOSMOTD',pic:''}]");
         setEventMetadata("'REFRESCAR'",",oparms:[]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'edtavVacantesusuariosestatus_Visible',ctrl:'vVACANTESUSUARIOSESTATUS',prop:'Visible'},{av:'dynavVacantes_id_envio'},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'A290VacantesUsuariosEstatus',fld:'VACANTESUSUARIOSESTATUS',pic:'ZZZ9'},{av:'AV24VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV38UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZ9',hsh:true},{av:'A260UsuariosTelef',fld:'USUARIOSTELEF',pic:''},{av:'A261UsuariosCorreo',fld:'USUARIOSCORREO',pic:''},{av:'A284SUBT_ReclutadorId',fld:'SUBT_RECLUTADORID',pic:'ZZZZZ9'},{av:'A288VacantesUsuariosFechaP',fld:'VACANTESUSUARIOSFECHAP',pic:'99/99/9999 99:99'},{av:'A292VacantesUsuariosCV',fld:'VACANTESUSUARIOSCV',pic:'ZZZ9'},{av:'A291VacantesUsuariosPrefiltro',fld:'VACANTESUSUARIOSPREFILTRO',pic:'ZZZ9'},{av:'A295VacantesUsuariosFechaE',fld:'VACANTESUSUARIOSFECHAE',pic:'99/99/99 99:99'},{av:'A293VacantesUsuariosExTec',fld:'VACANTESUSUARIOSEXTEC',pic:'ZZZ9'},{av:'A314VacantesUsuariosFecha3',fld:'VACANTESUSUARIOSFECHA3',pic:'99/99/99 99:99'},{av:'A304VacantesUsuariosAvConf',fld:'VACANTESUSUARIOSAVCONF',pic:'ZZZ9'},{av:'A303VacantesUsuariosAvPriv',fld:'VACANTESUSUARIOSAVPRIV',pic:'ZZZ9'},{av:'A302VacantesUsuariosBusWeb',fld:'VACANTESUSUARIOSBUSWEB',pic:'ZZZ9'},{av:'A301VacantesUsuariosExPsi',fld:'VACANTESUSUARIOSEXPSI',pic:'ZZZ9'},{av:'A300VacantesUsuariosRefLab',fld:'VACANTESUSUARIOSREFLAB',pic:'ZZZ9'},{av:'A299VacantesUsuariosCVRec',fld:'VACANTESUSUARIOSCVREC',pic:'ZZZ9'},{av:'A313VacantesUsuariosFechaA',fld:'VACANTESUSUARIOSFECHAA',pic:'99/99/99 99:99'},{av:'A289VacantesUsuariosFechaD',fld:'VACANTESUSUARIOSFECHAD',pic:'99/99/99 99:99'},{av:'A294VacantesUsuariosMotD',fld:'VACANTESUSUARIOSMOTD',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'edtavVacantesusuariosestatus_Visible',ctrl:'vVACANTESUSUARIOSESTATUS',prop:'Visible'},{av:'dynavVacantes_id_envio'},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'A290VacantesUsuariosEstatus',fld:'VACANTESUSUARIOSESTATUS',pic:'ZZZ9'},{av:'AV24VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV38UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZ9',hsh:true},{av:'A260UsuariosTelef',fld:'USUARIOSTELEF',pic:''},{av:'A261UsuariosCorreo',fld:'USUARIOSCORREO',pic:''},{av:'A284SUBT_ReclutadorId',fld:'SUBT_RECLUTADORID',pic:'ZZZZZ9'},{av:'A288VacantesUsuariosFechaP',fld:'VACANTESUSUARIOSFECHAP',pic:'99/99/9999 99:99'},{av:'A292VacantesUsuariosCV',fld:'VACANTESUSUARIOSCV',pic:'ZZZ9'},{av:'A291VacantesUsuariosPrefiltro',fld:'VACANTESUSUARIOSPREFILTRO',pic:'ZZZ9'},{av:'A295VacantesUsuariosFechaE',fld:'VACANTESUSUARIOSFECHAE',pic:'99/99/99 99:99'},{av:'A293VacantesUsuariosExTec',fld:'VACANTESUSUARIOSEXTEC',pic:'ZZZ9'},{av:'A314VacantesUsuariosFecha3',fld:'VACANTESUSUARIOSFECHA3',pic:'99/99/99 99:99'},{av:'A304VacantesUsuariosAvConf',fld:'VACANTESUSUARIOSAVCONF',pic:'ZZZ9'},{av:'A303VacantesUsuariosAvPriv',fld:'VACANTESUSUARIOSAVPRIV',pic:'ZZZ9'},{av:'A302VacantesUsuariosBusWeb',fld:'VACANTESUSUARIOSBUSWEB',pic:'ZZZ9'},{av:'A301VacantesUsuariosExPsi',fld:'VACANTESUSUARIOSEXPSI',pic:'ZZZ9'},{av:'A300VacantesUsuariosRefLab',fld:'VACANTESUSUARIOSREFLAB',pic:'ZZZ9'},{av:'A299VacantesUsuariosCVRec',fld:'VACANTESUSUARIOSCVREC',pic:'ZZZ9'},{av:'A313VacantesUsuariosFechaA',fld:'VACANTESUSUARIOSFECHAA',pic:'99/99/99 99:99'},{av:'A289VacantesUsuariosFechaD',fld:'VACANTESUSUARIOSFECHAD',pic:'99/99/99 99:99'},{av:'A294VacantesUsuariosMotD',fld:'VACANTESUSUARIOSMOTD',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'edtavVacantesusuariosestatus_Visible',ctrl:'vVACANTESUSUARIOSESTATUS',prop:'Visible'},{av:'dynavVacantes_id_envio'},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'A290VacantesUsuariosEstatus',fld:'VACANTESUSUARIOSESTATUS',pic:'ZZZ9'},{av:'AV24VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV38UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZ9',hsh:true},{av:'A260UsuariosTelef',fld:'USUARIOSTELEF',pic:''},{av:'A261UsuariosCorreo',fld:'USUARIOSCORREO',pic:''},{av:'A284SUBT_ReclutadorId',fld:'SUBT_RECLUTADORID',pic:'ZZZZZ9'},{av:'A288VacantesUsuariosFechaP',fld:'VACANTESUSUARIOSFECHAP',pic:'99/99/9999 99:99'},{av:'A292VacantesUsuariosCV',fld:'VACANTESUSUARIOSCV',pic:'ZZZ9'},{av:'A291VacantesUsuariosPrefiltro',fld:'VACANTESUSUARIOSPREFILTRO',pic:'ZZZ9'},{av:'A295VacantesUsuariosFechaE',fld:'VACANTESUSUARIOSFECHAE',pic:'99/99/99 99:99'},{av:'A293VacantesUsuariosExTec',fld:'VACANTESUSUARIOSEXTEC',pic:'ZZZ9'},{av:'A314VacantesUsuariosFecha3',fld:'VACANTESUSUARIOSFECHA3',pic:'99/99/99 99:99'},{av:'A304VacantesUsuariosAvConf',fld:'VACANTESUSUARIOSAVCONF',pic:'ZZZ9'},{av:'A303VacantesUsuariosAvPriv',fld:'VACANTESUSUARIOSAVPRIV',pic:'ZZZ9'},{av:'A302VacantesUsuariosBusWeb',fld:'VACANTESUSUARIOSBUSWEB',pic:'ZZZ9'},{av:'A301VacantesUsuariosExPsi',fld:'VACANTESUSUARIOSEXPSI',pic:'ZZZ9'},{av:'A300VacantesUsuariosRefLab',fld:'VACANTESUSUARIOSREFLAB',pic:'ZZZ9'},{av:'A299VacantesUsuariosCVRec',fld:'VACANTESUSUARIOSCVREC',pic:'ZZZ9'},{av:'A313VacantesUsuariosFechaA',fld:'VACANTESUSUARIOSFECHAA',pic:'99/99/99 99:99'},{av:'A289VacantesUsuariosFechaD',fld:'VACANTESUSUARIOSFECHAD',pic:'99/99/99 99:99'},{av:'A294VacantesUsuariosMotD',fld:'VACANTESUSUARIOSMOTD',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'edtavVacantesusuariosestatus_Visible',ctrl:'vVACANTESUSUARIOSESTATUS',prop:'Visible'},{av:'dynavVacantes_id_envio'},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'A290VacantesUsuariosEstatus',fld:'VACANTESUSUARIOSESTATUS',pic:'ZZZ9'},{av:'AV24VacantesUsuariosEstatus',fld:'vVACANTESUSUARIOSESTATUS',pic:'ZZZ9'},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV38UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZ9',hsh:true},{av:'A260UsuariosTelef',fld:'USUARIOSTELEF',pic:''},{av:'A261UsuariosCorreo',fld:'USUARIOSCORREO',pic:''},{av:'A284SUBT_ReclutadorId',fld:'SUBT_RECLUTADORID',pic:'ZZZZZ9'},{av:'A288VacantesUsuariosFechaP',fld:'VACANTESUSUARIOSFECHAP',pic:'99/99/9999 99:99'},{av:'A292VacantesUsuariosCV',fld:'VACANTESUSUARIOSCV',pic:'ZZZ9'},{av:'A291VacantesUsuariosPrefiltro',fld:'VACANTESUSUARIOSPREFILTRO',pic:'ZZZ9'},{av:'A295VacantesUsuariosFechaE',fld:'VACANTESUSUARIOSFECHAE',pic:'99/99/99 99:99'},{av:'A293VacantesUsuariosExTec',fld:'VACANTESUSUARIOSEXTEC',pic:'ZZZ9'},{av:'A314VacantesUsuariosFecha3',fld:'VACANTESUSUARIOSFECHA3',pic:'99/99/99 99:99'},{av:'A304VacantesUsuariosAvConf',fld:'VACANTESUSUARIOSAVCONF',pic:'ZZZ9'},{av:'A303VacantesUsuariosAvPriv',fld:'VACANTESUSUARIOSAVPRIV',pic:'ZZZ9'},{av:'A302VacantesUsuariosBusWeb',fld:'VACANTESUSUARIOSBUSWEB',pic:'ZZZ9'},{av:'A301VacantesUsuariosExPsi',fld:'VACANTESUSUARIOSEXPSI',pic:'ZZZ9'},{av:'A300VacantesUsuariosRefLab',fld:'VACANTESUSUARIOSREFLAB',pic:'ZZZ9'},{av:'A299VacantesUsuariosCVRec',fld:'VACANTESUSUARIOSCVREC',pic:'ZZZ9'},{av:'A313VacantesUsuariosFechaA',fld:'VACANTESUSUARIOSFECHAA',pic:'99/99/99 99:99'},{av:'A289VacantesUsuariosFechaD',fld:'VACANTESUSUARIOSFECHAD',pic:'99/99/99 99:99'},{av:'A294VacantesUsuariosMotD',fld:'VACANTESUSUARIOSMOTD',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Vacantesusuariosestatus',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Vacantesusuariosestatus',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALIDV_USUARIOSCORREO","{handler:'Validv_Usuarioscorreo',iparms:[]");
         setEventMetadata("VALIDV_USUARIOSCORREO",",oparms:[]}");
         setEventMetadata("VALIDV_VACANTESUSUARIOSFECHA3","{handler:'Validv_Vacantesusuariosfecha3',iparms:[]");
         setEventMetadata("VALIDV_VACANTESUSUARIOSFECHA3",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Vacantesusuarioscvrec',iparms:[]");
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
         A260UsuariosTelef = "";
         A261UsuariosCorreo = "";
         A288VacantesUsuariosFechaP = (DateTime)(DateTime.MinValue);
         A295VacantesUsuariosFechaE = (DateTime)(DateTime.MinValue);
         A314VacantesUsuariosFecha3 = (DateTime)(DateTime.MinValue);
         A313VacantesUsuariosFechaA = (DateTime)(DateTime.MinValue);
         A289VacantesUsuariosFechaD = (DateTime)(DateTime.MinValue);
         A294VacantesUsuariosMotD = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         imgImage1_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         Grid2Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid2_Header = "";
         Grid2Column = new GXWebColumn();
         Grid1Container = new GXWebGrid( context);
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXCCtl = "";
         AV29VacantesUsuariosFechaP = "";
         AV15UsuariosTelef = "";
         AV12UsuariosCorreo = "";
         AV35VacantesUsuariosFecha3 = (DateTime)(DateTime.MinValue);
         AV28VacantesUsuariosFechaE = "";
         AV27VacantesUsuariosFechaD = "";
         AV30VacantesUsuariosMotD = "";
         AV31VacantesUsuariosPrefiltro = "";
         AV45Vacantesusuariosprefiltro_GXI = "";
         AV22VacantesUsuariosCV = "";
         AV46Vacantesusuarioscv_GXI = "";
         AV26VacantesUsuariosExTec = "";
         AV47Vacantesusuariosextec_GXI = "";
         AV19VacantesUsuariosAvConf = "";
         AV53Vacantesusuariosavconf_GXI = "";
         AV20VacantesUsuariosAvPriv = "";
         AV52Vacantesusuariosavpriv_GXI = "";
         AV21VacantesUsuariosBusWeb = "";
         AV51Vacantesusuariosbusweb_GXI = "";
         AV32VacantesUsuariosRefLab = "";
         AV49Vacantesusuariosreflab_GXI = "";
         AV25VacantesUsuariosExPsi = "";
         AV50Vacantesusuariosexpsi_GXI = "";
         AV23VacantesUsuariosCVRec = "";
         AV48Vacantesusuarioscvrec_GXI = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H00362_A11UsuariosId = new int[1] ;
         H00362_A97UsuariosNomCompleto = new String[] {""} ;
         H00363_A11UsuariosId = new int[1] ;
         H00363_A97UsuariosNomCompleto = new String[] {""} ;
         H00364_A11UsuariosId = new int[1] ;
         H00364_A290VacantesUsuariosEstatus = new short[1] ;
         H00364_n290VacantesUsuariosEstatus = new bool[] {false} ;
         H00364_A263Vacantes_Id = new int[1] ;
         H00364_A260UsuariosTelef = new String[] {""} ;
         H00364_A261UsuariosCorreo = new String[] {""} ;
         H00364_A284SUBT_ReclutadorId = new int[1] ;
         H00364_A288VacantesUsuariosFechaP = new DateTime[] {DateTime.MinValue} ;
         H00364_A291VacantesUsuariosPrefiltro = new short[1] ;
         H00364_n291VacantesUsuariosPrefiltro = new bool[] {false} ;
         H00364_A292VacantesUsuariosCV = new short[1] ;
         H00364_n292VacantesUsuariosCV = new bool[] {false} ;
         H00364_A293VacantesUsuariosExTec = new short[1] ;
         H00364_n293VacantesUsuariosExTec = new bool[] {false} ;
         H00364_A295VacantesUsuariosFechaE = new DateTime[] {DateTime.MinValue} ;
         H00364_n295VacantesUsuariosFechaE = new bool[] {false} ;
         H00364_A299VacantesUsuariosCVRec = new short[1] ;
         H00364_n299VacantesUsuariosCVRec = new bool[] {false} ;
         H00364_A300VacantesUsuariosRefLab = new short[1] ;
         H00364_n300VacantesUsuariosRefLab = new bool[] {false} ;
         H00364_A301VacantesUsuariosExPsi = new short[1] ;
         H00364_n301VacantesUsuariosExPsi = new bool[] {false} ;
         H00364_A302VacantesUsuariosBusWeb = new short[1] ;
         H00364_n302VacantesUsuariosBusWeb = new bool[] {false} ;
         H00364_A303VacantesUsuariosAvPriv = new short[1] ;
         H00364_n303VacantesUsuariosAvPriv = new bool[] {false} ;
         H00364_A304VacantesUsuariosAvConf = new short[1] ;
         H00364_n304VacantesUsuariosAvConf = new bool[] {false} ;
         H00364_A314VacantesUsuariosFecha3 = new DateTime[] {DateTime.MinValue} ;
         H00364_n314VacantesUsuariosFecha3 = new bool[] {false} ;
         H00364_A313VacantesUsuariosFechaA = new DateTime[] {DateTime.MinValue} ;
         H00364_n313VacantesUsuariosFechaA = new bool[] {false} ;
         H00364_A294VacantesUsuariosMotD = new String[] {""} ;
         H00364_n294VacantesUsuariosMotD = new bool[] {false} ;
         H00364_A289VacantesUsuariosFechaD = new DateTime[] {DateTime.MinValue} ;
         H00364_n289VacantesUsuariosFechaD = new bool[] {false} ;
         AV5adjuntar = "";
         AV42Adjuntar_GXI = "";
         AV37websession = context.GetSession();
         H00365_A11UsuariosId = new int[1] ;
         H00365_A64UsuariosApMat = new String[] {""} ;
         H00365_A65UsuariosApPat = new String[] {""} ;
         H00365_A66UsuariosNombre = new String[] {""} ;
         A64UsuariosApMat = "";
         A65UsuariosApPat = "";
         A66UsuariosNombre = "";
         A97UsuariosNomCompleto = "";
         AV39Nombre_Comp_Usuario = "";
         Grid2Row = new GXWebRow();
         H00366_A11UsuariosId = new int[1] ;
         H00366_A290VacantesUsuariosEstatus = new short[1] ;
         H00366_n290VacantesUsuariosEstatus = new bool[] {false} ;
         H00366_A263Vacantes_Id = new int[1] ;
         H00366_A260UsuariosTelef = new String[] {""} ;
         H00366_A261UsuariosCorreo = new String[] {""} ;
         H00366_A284SUBT_ReclutadorId = new int[1] ;
         H00366_A288VacantesUsuariosFechaP = new DateTime[] {DateTime.MinValue} ;
         H00366_A291VacantesUsuariosPrefiltro = new short[1] ;
         H00366_n291VacantesUsuariosPrefiltro = new bool[] {false} ;
         H00366_A292VacantesUsuariosCV = new short[1] ;
         H00366_n292VacantesUsuariosCV = new bool[] {false} ;
         H00366_A293VacantesUsuariosExTec = new short[1] ;
         H00366_n293VacantesUsuariosExTec = new bool[] {false} ;
         H00366_A295VacantesUsuariosFechaE = new DateTime[] {DateTime.MinValue} ;
         H00366_n295VacantesUsuariosFechaE = new bool[] {false} ;
         H00366_A299VacantesUsuariosCVRec = new short[1] ;
         H00366_n299VacantesUsuariosCVRec = new bool[] {false} ;
         H00366_A300VacantesUsuariosRefLab = new short[1] ;
         H00366_n300VacantesUsuariosRefLab = new bool[] {false} ;
         H00366_A301VacantesUsuariosExPsi = new short[1] ;
         H00366_n301VacantesUsuariosExPsi = new bool[] {false} ;
         H00366_A302VacantesUsuariosBusWeb = new short[1] ;
         H00366_n302VacantesUsuariosBusWeb = new bool[] {false} ;
         H00366_A303VacantesUsuariosAvPriv = new short[1] ;
         H00366_n303VacantesUsuariosAvPriv = new bool[] {false} ;
         H00366_A304VacantesUsuariosAvConf = new short[1] ;
         H00366_n304VacantesUsuariosAvConf = new bool[] {false} ;
         H00366_A314VacantesUsuariosFecha3 = new DateTime[] {DateTime.MinValue} ;
         H00366_n314VacantesUsuariosFecha3 = new bool[] {false} ;
         H00366_A313VacantesUsuariosFechaA = new DateTime[] {DateTime.MinValue} ;
         H00366_n313VacantesUsuariosFechaA = new bool[] {false} ;
         H00366_A294VacantesUsuariosMotD = new String[] {""} ;
         H00366_n294VacantesUsuariosMotD = new bool[] {false} ;
         H00366_A289VacantesUsuariosFechaD = new DateTime[] {DateTime.MinValue} ;
         H00366_n289VacantesUsuariosFechaD = new bool[] {false} ;
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         H00367_A263Vacantes_Id = new int[1] ;
         H00367_A264Vacantes_Nombre = new String[] {""} ;
         ROClassString = "";
         subGrid2_Linesclass = "";
         lblTitletext_Jsonclick = "";
         Grid1Column = new GXWebColumn();
         H00368_A263Vacantes_Id = new int[1] ;
         H00368_A264Vacantes_Nombre = new String[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpreclusegusu__default(),
            new Object[][] {
                new Object[] {
               H00362_A11UsuariosId, H00362_A97UsuariosNomCompleto
               }
               , new Object[] {
               H00363_A11UsuariosId, H00363_A97UsuariosNomCompleto
               }
               , new Object[] {
               H00364_A11UsuariosId, H00364_A290VacantesUsuariosEstatus, H00364_n290VacantesUsuariosEstatus, H00364_A263Vacantes_Id, H00364_A260UsuariosTelef, H00364_A261UsuariosCorreo, H00364_A284SUBT_ReclutadorId, H00364_A288VacantesUsuariosFechaP, H00364_A291VacantesUsuariosPrefiltro, H00364_n291VacantesUsuariosPrefiltro,
               H00364_A292VacantesUsuariosCV, H00364_n292VacantesUsuariosCV, H00364_A293VacantesUsuariosExTec, H00364_n293VacantesUsuariosExTec, H00364_A295VacantesUsuariosFechaE, H00364_n295VacantesUsuariosFechaE, H00364_A299VacantesUsuariosCVRec, H00364_n299VacantesUsuariosCVRec, H00364_A300VacantesUsuariosRefLab, H00364_n300VacantesUsuariosRefLab,
               H00364_A301VacantesUsuariosExPsi, H00364_n301VacantesUsuariosExPsi, H00364_A302VacantesUsuariosBusWeb, H00364_n302VacantesUsuariosBusWeb, H00364_A303VacantesUsuariosAvPriv, H00364_n303VacantesUsuariosAvPriv, H00364_A304VacantesUsuariosAvConf, H00364_n304VacantesUsuariosAvConf, H00364_A314VacantesUsuariosFecha3, H00364_n314VacantesUsuariosFecha3,
               H00364_A313VacantesUsuariosFechaA, H00364_n313VacantesUsuariosFechaA, H00364_A294VacantesUsuariosMotD, H00364_n294VacantesUsuariosMotD, H00364_A289VacantesUsuariosFechaD, H00364_n289VacantesUsuariosFechaD
               }
               , new Object[] {
               H00365_A11UsuariosId, H00365_A64UsuariosApMat, H00365_A65UsuariosApPat, H00365_A66UsuariosNombre
               }
               , new Object[] {
               H00366_A11UsuariosId, H00366_A290VacantesUsuariosEstatus, H00366_n290VacantesUsuariosEstatus, H00366_A263Vacantes_Id, H00366_A260UsuariosTelef, H00366_A261UsuariosCorreo, H00366_A284SUBT_ReclutadorId, H00366_A288VacantesUsuariosFechaP, H00366_A291VacantesUsuariosPrefiltro, H00366_n291VacantesUsuariosPrefiltro,
               H00366_A292VacantesUsuariosCV, H00366_n292VacantesUsuariosCV, H00366_A293VacantesUsuariosExTec, H00366_n293VacantesUsuariosExTec, H00366_A295VacantesUsuariosFechaE, H00366_n295VacantesUsuariosFechaE, H00366_A299VacantesUsuariosCVRec, H00366_n299VacantesUsuariosCVRec, H00366_A300VacantesUsuariosRefLab, H00366_n300VacantesUsuariosRefLab,
               H00366_A301VacantesUsuariosExPsi, H00366_n301VacantesUsuariosExPsi, H00366_A302VacantesUsuariosBusWeb, H00366_n302VacantesUsuariosBusWeb, H00366_A303VacantesUsuariosAvPriv, H00366_n303VacantesUsuariosAvPriv, H00366_A304VacantesUsuariosAvConf, H00366_n304VacantesUsuariosAvConf, H00366_A314VacantesUsuariosFecha3, H00366_n314VacantesUsuariosFecha3,
               H00366_A313VacantesUsuariosFechaA, H00366_n313VacantesUsuariosFechaA, H00366_A294VacantesUsuariosMotD, H00366_n294VacantesUsuariosMotD, H00366_A289VacantesUsuariosFechaD, H00366_n289VacantesUsuariosFechaD
               }
               , new Object[] {
               H00367_A263Vacantes_Id, H00367_A264Vacantes_Nombre
               }
               , new Object[] {
               H00368_A263Vacantes_Id, H00368_A264Vacantes_Nombre
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         dynavVacantes_id_envio.Enabled = 0;
         edtavVacantesusuariosestatus_Enabled = 0;
         edtavVacantesusuariosfechap_Enabled = 0;
         dynavUsuariosid.Enabled = 0;
         edtavUsuariostelef_Enabled = 0;
         edtavUsuarioscorreo_Enabled = 0;
         dynavSubt_reclutadorid.Enabled = 0;
         edtavVacantesusuariosfecha3_Enabled = 0;
         edtavVacantesusuariosfechae_Enabled = 0;
         edtavVacantesusuariosfechad_Enabled = 0;
         edtavVacantesusuariosmotd_Enabled = 0;
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short A290VacantesUsuariosEstatus ;
      private short AV24VacantesUsuariosEstatus ;
      private short A292VacantesUsuariosCV ;
      private short A291VacantesUsuariosPrefiltro ;
      private short A293VacantesUsuariosExTec ;
      private short A304VacantesUsuariosAvConf ;
      private short A303VacantesUsuariosAvPriv ;
      private short A302VacantesUsuariosBusWeb ;
      private short A301VacantesUsuariosExPsi ;
      private short A300VacantesUsuariosRefLab ;
      private short A299VacantesUsuariosCVRec ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short lblTextblock2_Fontbold ;
      private short subGrid2_Backcolorstyle ;
      private short subGrid2_Allowselection ;
      private short subGrid2_Allowhovering ;
      private short subGrid2_Allowcollapsing ;
      private short subGrid2_Collapsed ;
      private short GRID1_nEOF ;
      private short AV18vacantes_id_Envio ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short GRID2_nEOF ;
      private short subGrid1_Backstyle ;
      private short subGrid2_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int nRC_GXsfl_43 ;
      private int nGXsfl_43_idx=1 ;
      private int edtavVacantesusuariosestatus_Visible ;
      private int edtVacantesUsuariosEstatus_Visible ;
      private int nRC_GXsfl_21 ;
      private int subGrid1_Rows ;
      private int A263Vacantes_Id ;
      private int A11UsuariosId ;
      private int AV38UsuarioId ;
      private int A284SUBT_ReclutadorId ;
      private int nGXsfl_21_idx=1 ;
      private int lblTextblock4_Visible ;
      private int lblTextblock1_Visible ;
      private int edtavVacantesusuariosestatus_Enabled ;
      private int subGrid2_Selectedindex ;
      private int subGrid2_Selectioncolor ;
      private int subGrid2_Hoveringcolor ;
      private int AV13UsuariosId ;
      private int AV8SUBT_ReclutadorId ;
      private int gxdynajaxindex ;
      private int subGrid2_Islastpage ;
      private int subGrid1_Islastpage ;
      private int edtavVacantesusuariosfechap_Enabled ;
      private int edtavUsuariostelef_Enabled ;
      private int edtavUsuarioscorreo_Enabled ;
      private int edtavVacantesusuariosfecha3_Enabled ;
      private int edtavVacantesusuariosfechae_Enabled ;
      private int edtavVacantesusuariosfechad_Enabled ;
      private int edtavVacantesusuariosmotd_Enabled ;
      private int GRID1_nGridOutOfScope ;
      private int subGrid1_Recordcount ;
      private int edtavVacantesusuariosprefiltro_Visible ;
      private int edtavVacantesusuarioscv_Visible ;
      private int edtavVacantesusuariosextec_Visible ;
      private int edtavVacantesusuariosfechae_Visible ;
      private int edtavVacantesusuarioscvrec_Visible ;
      private int edtavVacantesusuariosreflab_Visible ;
      private int edtavVacantesusuariosexpsi_Visible ;
      private int edtavVacantesusuariosbusweb_Visible ;
      private int edtavVacantesusuariosavpriv_Visible ;
      private int edtavVacantesusuariosavconf_Visible ;
      private int edtavVacantesusuariosfecha3_Visible ;
      private int edtavVacantesusuariosmotd_Visible ;
      private int edtavVacantesusuariosfechad_Visible ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid2_Backcolor ;
      private int subGrid2_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID2_nCurrentRecord ;
      private long GRID2_nFirstRecordOnPage ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_43_idx="0001" ;
      private String edtavVacantesusuariosestatus_Internalname ;
      private String dynavVacantes_id_envio_Internalname ;
      private String A260UsuariosTelef ;
      private String sGXsfl_21_idx="0001" ;
      private String edtVacantesUsuariosEstatus_Internalname ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String divTable3_Internalname ;
      private String lblTextblock4_Internalname ;
      private String lblTextblock4_Jsonclick ;
      private String lblTextblock2_Internalname ;
      private String lblTextblock2_Caption ;
      private String lblTextblock2_Jsonclick ;
      private String TempTags ;
      private String ClassString ;
      private String StyleString ;
      private String sImgUrl ;
      private String imgImage1_Internalname ;
      private String imgImage1_Jsonclick ;
      private String lblTextblock1_Internalname ;
      private String lblTextblock1_Jsonclick ;
      private String sStyleString ;
      private String subGrid2_Internalname ;
      private String subGrid2_Header ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String GXCCtl ;
      private String edtavVacantesusuariosfechap_Internalname ;
      private String dynavUsuariosid_Internalname ;
      private String AV15UsuariosTelef ;
      private String edtavUsuariostelef_Internalname ;
      private String edtavUsuarioscorreo_Internalname ;
      private String dynavSubt_reclutadorid_Internalname ;
      private String edtavVacantesusuariosfecha3_Internalname ;
      private String edtavVacantesusuariosfechae_Internalname ;
      private String edtavVacantesusuariosfechad_Internalname ;
      private String edtavVacantesusuariosmotd_Internalname ;
      private String edtavVacantesusuariosprefiltro_Internalname ;
      private String edtavVacantesusuarioscv_Internalname ;
      private String edtavVacantesusuariosextec_Internalname ;
      private String edtavVacantesusuariosavconf_Internalname ;
      private String edtavVacantesusuariosavpriv_Internalname ;
      private String edtavVacantesusuariosbusweb_Internalname ;
      private String edtavVacantesusuariosreflab_Internalname ;
      private String edtavVacantesusuariosexpsi_Internalname ;
      private String edtavVacantesusuarioscvrec_Internalname ;
      private String gxwrpcisep ;
      private String scmdbuf ;
      private String lblTitletext_Caption ;
      private String divTabletop_Class ;
      private String divTabletop_Internalname ;
      private String edtavVacantesusuariosfecha3_Titlefontname ;
      private String sGXsfl_43_fel_idx="0001" ;
      private String subGrid1_Class ;
      private String subGrid1_Linesclass ;
      private String dynavVacantes_id_envio_Jsonclick ;
      private String ROClassString ;
      private String edtavVacantesusuariosestatus_Jsonclick ;
      private String edtavVacantesusuariosfechap_Jsonclick ;
      private String dynavUsuariosid_Jsonclick ;
      private String edtavUsuariostelef_Jsonclick ;
      private String edtavUsuarioscorreo_Jsonclick ;
      private String dynavSubt_reclutadorid_Jsonclick ;
      private String edtavVacantesusuariosfecha3_Jsonclick ;
      private String edtavVacantesusuariosfechae_Jsonclick ;
      private String edtavVacantesusuariosfechad_Jsonclick ;
      private String edtavVacantesusuariosmotd_Jsonclick ;
      private String lblTitletext_Internalname ;
      private String subGrid1_Internalname ;
      private String sGXsfl_21_fel_idx="0001" ;
      private String subGrid2_Class ;
      private String subGrid2_Linesclass ;
      private String divGrid2table_Internalname ;
      private String lblTitletext_Jsonclick ;
      private String edtVacantesUsuariosEstatus_Jsonclick ;
      private String tblTable1_Internalname ;
      private String subGrid1_Header ;
      private DateTime A288VacantesUsuariosFechaP ;
      private DateTime A295VacantesUsuariosFechaE ;
      private DateTime A314VacantesUsuariosFecha3 ;
      private DateTime A313VacantesUsuariosFechaA ;
      private DateTime A289VacantesUsuariosFechaD ;
      private DateTime AV35VacantesUsuariosFecha3 ;
      private bool entryPointCalled ;
      private bool bGXsfl_21_Refreshing=false ;
      private bool bGXsfl_43_Refreshing=false ;
      private bool n290VacantesUsuariosEstatus ;
      private bool n292VacantesUsuariosCV ;
      private bool n291VacantesUsuariosPrefiltro ;
      private bool n295VacantesUsuariosFechaE ;
      private bool n293VacantesUsuariosExTec ;
      private bool n314VacantesUsuariosFecha3 ;
      private bool n304VacantesUsuariosAvConf ;
      private bool n303VacantesUsuariosAvPriv ;
      private bool n302VacantesUsuariosBusWeb ;
      private bool n301VacantesUsuariosExPsi ;
      private bool n300VacantesUsuariosRefLab ;
      private bool n299VacantesUsuariosCVRec ;
      private bool n313VacantesUsuariosFechaA ;
      private bool n289VacantesUsuariosFechaD ;
      private bool n294VacantesUsuariosMotD ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV31VacantesUsuariosPrefiltro_IsBlob ;
      private bool AV22VacantesUsuariosCV_IsBlob ;
      private bool AV26VacantesUsuariosExTec_IsBlob ;
      private bool AV19VacantesUsuariosAvConf_IsBlob ;
      private bool AV20VacantesUsuariosAvPriv_IsBlob ;
      private bool AV21VacantesUsuariosBusWeb_IsBlob ;
      private bool AV32VacantesUsuariosRefLab_IsBlob ;
      private bool AV25VacantesUsuariosExPsi_IsBlob ;
      private bool AV23VacantesUsuariosCVRec_IsBlob ;
      private String A261UsuariosCorreo ;
      private String A294VacantesUsuariosMotD ;
      private String AV29VacantesUsuariosFechaP ;
      private String AV12UsuariosCorreo ;
      private String AV28VacantesUsuariosFechaE ;
      private String AV27VacantesUsuariosFechaD ;
      private String AV30VacantesUsuariosMotD ;
      private String AV45Vacantesusuariosprefiltro_GXI ;
      private String AV46Vacantesusuarioscv_GXI ;
      private String AV47Vacantesusuariosextec_GXI ;
      private String AV53Vacantesusuariosavconf_GXI ;
      private String AV52Vacantesusuariosavpriv_GXI ;
      private String AV51Vacantesusuariosbusweb_GXI ;
      private String AV49Vacantesusuariosreflab_GXI ;
      private String AV50Vacantesusuariosexpsi_GXI ;
      private String AV48Vacantesusuarioscvrec_GXI ;
      private String AV42Adjuntar_GXI ;
      private String A64UsuariosApMat ;
      private String A65UsuariosApPat ;
      private String A66UsuariosNombre ;
      private String A97UsuariosNomCompleto ;
      private String AV39Nombre_Comp_Usuario ;
      private String AV31VacantesUsuariosPrefiltro ;
      private String AV22VacantesUsuariosCV ;
      private String AV26VacantesUsuariosExTec ;
      private String AV19VacantesUsuariosAvConf ;
      private String AV20VacantesUsuariosAvPriv ;
      private String AV21VacantesUsuariosBusWeb ;
      private String AV32VacantesUsuariosRefLab ;
      private String AV25VacantesUsuariosExPsi ;
      private String AV23VacantesUsuariosCVRec ;
      private String AV5adjuntar ;
      private IGxSession AV37websession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Grid2Container ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid2Row ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid2Column ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavVacantes_id_envio ;
      private GXCombobox dynavUsuariosid ;
      private GXCombobox dynavSubt_reclutadorid ;
      private IDataStoreProvider pr_default ;
      private int[] H00362_A11UsuariosId ;
      private String[] H00362_A97UsuariosNomCompleto ;
      private int[] H00363_A11UsuariosId ;
      private String[] H00363_A97UsuariosNomCompleto ;
      private int[] H00364_A11UsuariosId ;
      private short[] H00364_A290VacantesUsuariosEstatus ;
      private bool[] H00364_n290VacantesUsuariosEstatus ;
      private int[] H00364_A263Vacantes_Id ;
      private String[] H00364_A260UsuariosTelef ;
      private String[] H00364_A261UsuariosCorreo ;
      private int[] H00364_A284SUBT_ReclutadorId ;
      private DateTime[] H00364_A288VacantesUsuariosFechaP ;
      private short[] H00364_A291VacantesUsuariosPrefiltro ;
      private bool[] H00364_n291VacantesUsuariosPrefiltro ;
      private short[] H00364_A292VacantesUsuariosCV ;
      private bool[] H00364_n292VacantesUsuariosCV ;
      private short[] H00364_A293VacantesUsuariosExTec ;
      private bool[] H00364_n293VacantesUsuariosExTec ;
      private DateTime[] H00364_A295VacantesUsuariosFechaE ;
      private bool[] H00364_n295VacantesUsuariosFechaE ;
      private short[] H00364_A299VacantesUsuariosCVRec ;
      private bool[] H00364_n299VacantesUsuariosCVRec ;
      private short[] H00364_A300VacantesUsuariosRefLab ;
      private bool[] H00364_n300VacantesUsuariosRefLab ;
      private short[] H00364_A301VacantesUsuariosExPsi ;
      private bool[] H00364_n301VacantesUsuariosExPsi ;
      private short[] H00364_A302VacantesUsuariosBusWeb ;
      private bool[] H00364_n302VacantesUsuariosBusWeb ;
      private short[] H00364_A303VacantesUsuariosAvPriv ;
      private bool[] H00364_n303VacantesUsuariosAvPriv ;
      private short[] H00364_A304VacantesUsuariosAvConf ;
      private bool[] H00364_n304VacantesUsuariosAvConf ;
      private DateTime[] H00364_A314VacantesUsuariosFecha3 ;
      private bool[] H00364_n314VacantesUsuariosFecha3 ;
      private DateTime[] H00364_A313VacantesUsuariosFechaA ;
      private bool[] H00364_n313VacantesUsuariosFechaA ;
      private String[] H00364_A294VacantesUsuariosMotD ;
      private bool[] H00364_n294VacantesUsuariosMotD ;
      private DateTime[] H00364_A289VacantesUsuariosFechaD ;
      private bool[] H00364_n289VacantesUsuariosFechaD ;
      private int[] H00365_A11UsuariosId ;
      private String[] H00365_A64UsuariosApMat ;
      private String[] H00365_A65UsuariosApPat ;
      private String[] H00365_A66UsuariosNombre ;
      private int[] H00366_A11UsuariosId ;
      private short[] H00366_A290VacantesUsuariosEstatus ;
      private bool[] H00366_n290VacantesUsuariosEstatus ;
      private int[] H00366_A263Vacantes_Id ;
      private String[] H00366_A260UsuariosTelef ;
      private String[] H00366_A261UsuariosCorreo ;
      private int[] H00366_A284SUBT_ReclutadorId ;
      private DateTime[] H00366_A288VacantesUsuariosFechaP ;
      private short[] H00366_A291VacantesUsuariosPrefiltro ;
      private bool[] H00366_n291VacantesUsuariosPrefiltro ;
      private short[] H00366_A292VacantesUsuariosCV ;
      private bool[] H00366_n292VacantesUsuariosCV ;
      private short[] H00366_A293VacantesUsuariosExTec ;
      private bool[] H00366_n293VacantesUsuariosExTec ;
      private DateTime[] H00366_A295VacantesUsuariosFechaE ;
      private bool[] H00366_n295VacantesUsuariosFechaE ;
      private short[] H00366_A299VacantesUsuariosCVRec ;
      private bool[] H00366_n299VacantesUsuariosCVRec ;
      private short[] H00366_A300VacantesUsuariosRefLab ;
      private bool[] H00366_n300VacantesUsuariosRefLab ;
      private short[] H00366_A301VacantesUsuariosExPsi ;
      private bool[] H00366_n301VacantesUsuariosExPsi ;
      private short[] H00366_A302VacantesUsuariosBusWeb ;
      private bool[] H00366_n302VacantesUsuariosBusWeb ;
      private short[] H00366_A303VacantesUsuariosAvPriv ;
      private bool[] H00366_n303VacantesUsuariosAvPriv ;
      private short[] H00366_A304VacantesUsuariosAvConf ;
      private bool[] H00366_n304VacantesUsuariosAvConf ;
      private DateTime[] H00366_A314VacantesUsuariosFecha3 ;
      private bool[] H00366_n314VacantesUsuariosFecha3 ;
      private DateTime[] H00366_A313VacantesUsuariosFechaA ;
      private bool[] H00366_n313VacantesUsuariosFechaA ;
      private String[] H00366_A294VacantesUsuariosMotD ;
      private bool[] H00366_n294VacantesUsuariosMotD ;
      private DateTime[] H00366_A289VacantesUsuariosFechaD ;
      private bool[] H00366_n289VacantesUsuariosFechaD ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int[] H00367_A263Vacantes_Id ;
      private String[] H00367_A264Vacantes_Nombre ;
      private int[] H00368_A263Vacantes_Id ;
      private String[] H00368_A264Vacantes_Nombre ;
      private GXWebForm Form ;
   }

   public class wpreclusegusu__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00362 ;
          prmH00362 = new Object[] {
          } ;
          Object[] prmH00363 ;
          prmH00363 = new Object[] {
          } ;
          Object[] prmH00364 ;
          prmH00364 = new Object[] {
          new Object[] {"AV38UsuarioId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmH00365 ;
          prmH00365 = new Object[] {
          new Object[] {"AV38UsuarioId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmH00366 ;
          prmH00366 = new Object[] {
          new Object[] {"AV38UsuarioId",System.Data.DbType.Int32,9,0} ,
          new Object[] {"AV24VacantesUsuariosEstatus",System.Data.DbType.Int16,4,0}
          } ;
          Object[] prmH00367 ;
          prmH00367 = new Object[] {
          } ;
          Object[] prmH00368 ;
          prmH00368 = new Object[] {
          } ;
          def= new CursorDef[] {
              new CursorDef("H00362", "SELECT `UsuariosId`, CONCAT(CONCAT(CONCAT(CONCAT(RTRIM(LTRIM(`UsuariosNombre`)), ' '), RTRIM(LTRIM(`UsuariosApPat`))), ' '), RTRIM(LTRIM(`UsuariosApMat`))) AS UsuariosNomCompleto FROM `Usuarios` ORDER BY `UsuariosNomCompleto` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00362,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00363", "SELECT `UsuariosId`, CONCAT(CONCAT(CONCAT(CONCAT(RTRIM(LTRIM(`UsuariosNombre`)), ' '), RTRIM(LTRIM(`UsuariosApPat`))), ' '), RTRIM(LTRIM(`UsuariosApMat`))) AS UsuariosNomCompleto FROM `Usuarios` ORDER BY `UsuariosNomCompleto` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00363,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00364", "SELECT DISTINCT NULL AS `UsuariosId`, `VacantesUsuariosEstatus`, NULL AS `Vacantes_Id`, NULL AS `UsuariosTelef`, NULL AS `UsuariosCorreo`, NULL AS `SUBT_ReclutadorId`, NULL AS `VacantesUsuariosFechaP`, NULL AS `VacantesUsuariosPrefiltro`, NULL AS `VacantesUsuariosCV`, NULL AS `VacantesUsuariosExTec`, NULL AS `VacantesUsuariosFechaE`, NULL AS `VacantesUsuariosCVRec`, NULL AS `VacantesUsuariosRefLab`, NULL AS `VacantesUsuariosExPsi`, NULL AS `VacantesUsuariosBusWeb`, NULL AS `VacantesUsuariosAvPriv`, NULL AS `VacantesUsuariosAvConf`, NULL AS `VacantesUsuariosFecha3`, NULL AS `VacantesUsuariosFechaA`, NULL AS `VacantesUsuariosMotD`, NULL AS `VacantesUsuariosFechaD` FROM ( SELECT T1.`UsuariosId`, T1.`VacantesUsuariosEstatus`, T1.`Vacantes_Id`, T2.`UsuariosTelef`, T2.`UsuariosCorreo`, T1.`SUBT_ReclutadorId`, T1.`VacantesUsuariosFechaP`, T1.`VacantesUsuariosPrefiltro`, T1.`VacantesUsuariosCV`, T1.`VacantesUsuariosExTec`, T1.`VacantesUsuariosFechaE`, T1.`VacantesUsuariosCVRec`, T1.`VacantesUsuariosRefLab`, T1.`VacantesUsuariosExPsi`, T1.`VacantesUsuariosBusWeb`, T1.`VacantesUsuariosAvPriv`, T1.`VacantesUsuariosAvConf`, T1.`VacantesUsuariosFecha3`, T1.`VacantesUsuariosFechaA`, T1.`VacantesUsuariosMotD`, T1.`VacantesUsuariosFechaD` FROM (`VacantesUsuariosVacante` T1 INNER JOIN `Usuarios` T2 ON T2.`UsuariosId` = T1.`UsuariosId`) WHERE (T1.`UsuariosId` = ?) AND (T1.`Vacantes_Id` <> 17) ORDER BY T1.`VacantesUsuariosEstatus`) DistinctT ORDER BY `VacantesUsuariosEstatus` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00364,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00365", "SELECT `UsuariosId`, `UsuariosApMat`, `UsuariosApPat`, `UsuariosNombre` FROM `Usuarios` WHERE `UsuariosId` = ? ORDER BY `UsuariosId`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00365,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00366", "SELECT T1.`UsuariosId`, T1.`VacantesUsuariosEstatus`, T1.`Vacantes_Id`, T2.`UsuariosTelef`, T2.`UsuariosCorreo`, T1.`SUBT_ReclutadorId`, T1.`VacantesUsuariosFechaP`, T1.`VacantesUsuariosPrefiltro`, T1.`VacantesUsuariosCV`, T1.`VacantesUsuariosExTec`, T1.`VacantesUsuariosFechaE`, T1.`VacantesUsuariosCVRec`, T1.`VacantesUsuariosRefLab`, T1.`VacantesUsuariosExPsi`, T1.`VacantesUsuariosBusWeb`, T1.`VacantesUsuariosAvPriv`, T1.`VacantesUsuariosAvConf`, T1.`VacantesUsuariosFecha3`, T1.`VacantesUsuariosFechaA`, T1.`VacantesUsuariosMotD`, T1.`VacantesUsuariosFechaD` FROM (`VacantesUsuariosVacante` T1 INNER JOIN `Usuarios` T2 ON T2.`UsuariosId` = T1.`UsuariosId`) WHERE (T1.`UsuariosId` = ?) AND (T1.`VacantesUsuariosEstatus` = ?) AND (T1.`Vacantes_Id` <> 17) ORDER BY T1.`UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00366,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00367", "SELECT `Vacantes_Id`, `Vacantes_Nombre` FROM `Vacantes` ORDER BY `Vacantes_Nombre` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00367,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00368", "SELECT `Vacantes_Id`, `Vacantes_Nombre` FROM `Vacantes` ORDER BY `Vacantes_Nombre` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00368,0, GxCacheFrequency.OFF ,true,false )
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
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3) ;
                ((String[]) buf[4])[0] = rslt.getString(4, 10) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(5) ;
                ((int[]) buf[6])[0] = rslt.getInt(6) ;
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(7) ;
                ((short[]) buf[8])[0] = rslt.getShort(8) ;
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((short[]) buf[10])[0] = rslt.getShort(9) ;
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((short[]) buf[12])[0] = rslt.getShort(10) ;
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(11) ;
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((short[]) buf[16])[0] = rslt.getShort(12) ;
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((short[]) buf[18])[0] = rslt.getShort(13) ;
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((short[]) buf[20])[0] = rslt.getShort(14) ;
                ((bool[]) buf[21])[0] = rslt.wasNull(14);
                ((short[]) buf[22])[0] = rslt.getShort(15) ;
                ((bool[]) buf[23])[0] = rslt.wasNull(15);
                ((short[]) buf[24])[0] = rslt.getShort(16) ;
                ((bool[]) buf[25])[0] = rslt.wasNull(16);
                ((short[]) buf[26])[0] = rslt.getShort(17) ;
                ((bool[]) buf[27])[0] = rslt.wasNull(17);
                ((DateTime[]) buf[28])[0] = rslt.getGXDateTime(18) ;
                ((bool[]) buf[29])[0] = rslt.wasNull(18);
                ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(19) ;
                ((bool[]) buf[31])[0] = rslt.wasNull(19);
                ((String[]) buf[32])[0] = rslt.getVarchar(20) ;
                ((bool[]) buf[33])[0] = rslt.wasNull(20);
                ((DateTime[]) buf[34])[0] = rslt.getGXDateTime(21) ;
                ((bool[]) buf[35])[0] = rslt.wasNull(21);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((String[]) buf[3])[0] = rslt.getVarchar(4) ;
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3) ;
                ((String[]) buf[4])[0] = rslt.getString(4, 10) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(5) ;
                ((int[]) buf[6])[0] = rslt.getInt(6) ;
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(7) ;
                ((short[]) buf[8])[0] = rslt.getShort(8) ;
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((short[]) buf[10])[0] = rslt.getShort(9) ;
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((short[]) buf[12])[0] = rslt.getShort(10) ;
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(11) ;
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((short[]) buf[16])[0] = rslt.getShort(12) ;
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((short[]) buf[18])[0] = rslt.getShort(13) ;
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((short[]) buf[20])[0] = rslt.getShort(14) ;
                ((bool[]) buf[21])[0] = rslt.wasNull(14);
                ((short[]) buf[22])[0] = rslt.getShort(15) ;
                ((bool[]) buf[23])[0] = rslt.wasNull(15);
                ((short[]) buf[24])[0] = rslt.getShort(16) ;
                ((bool[]) buf[25])[0] = rslt.wasNull(16);
                ((short[]) buf[26])[0] = rslt.getShort(17) ;
                ((bool[]) buf[27])[0] = rslt.wasNull(17);
                ((DateTime[]) buf[28])[0] = rslt.getGXDateTime(18) ;
                ((bool[]) buf[29])[0] = rslt.wasNull(18);
                ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(19) ;
                ((bool[]) buf[31])[0] = rslt.wasNull(19);
                ((String[]) buf[32])[0] = rslt.getVarchar(20) ;
                ((bool[]) buf[33])[0] = rslt.wasNull(20);
                ((DateTime[]) buf[34])[0] = rslt.getGXDateTime(21) ;
                ((bool[]) buf[35])[0] = rslt.wasNull(21);
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
       switch ( cursor )
       {
             case 2 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 3 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 4 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                return;
       }
    }

 }

}
