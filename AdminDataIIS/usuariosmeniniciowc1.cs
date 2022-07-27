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
   public class usuariosmeniniciowc1 : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public usuariosmeniniciowc1( )
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

      public usuariosmeniniciowc1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_sgUsrMenId )
      {
         this.AV7sgUsrMenId = aP0_sgUsrMenId;
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
         cmbmenInicioStat = new GXCombobox();
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
                  AV7sgUsrMenId = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri(sPrefix, false, "AV7sgUsrMenId", StringUtil.LTrimStr( (decimal)(AV7sgUsrMenId), 6, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(String)sCompPrefix,(String)sSFPrefix,(int)AV7sgUsrMenId});
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
                  nRC_GXsfl_12 = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  nGXsfl_12_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  sGXsfl_12_idx = GetNextPar( );
                  sPrefix = GetNextPar( );
                  AV12Update = GetNextPar( );
                  edtavUpdate_Tooltiptext = GetNextPar( );
                  AssignProp(sPrefix, false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_12_Refreshing);
                  AV13Delete = GetNextPar( );
                  edtavDelete_Tooltiptext = GetNextPar( );
                  AssignProp(sPrefix, false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_12_Refreshing);
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
                  AV7sgUsrMenId = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AV12Update = GetNextPar( );
                  edtavUpdate_Tooltiptext = GetNextPar( );
                  AssignProp(sPrefix, false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_12_Refreshing);
                  AV13Delete = GetNextPar( );
                  edtavDelete_Tooltiptext = GetNextPar( );
                  AssignProp(sPrefix, false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_12_Refreshing);
                  sPrefix = GetNextPar( );
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrGrid_refresh( subGrid_Rows, AV7sgUsrMenId, AV12Update, AV13Delete, sPrefix) ;
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
            PA0U2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV17Pgmname = "UsuariosmenInicioWC1";
               context.Gx_err = 0;
               WS0U2( ) ;
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
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, false);
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
            context.SendWebValue( "Usuariosmen Inicio WC1") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714343878", false, true);
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
            context.WriteHtmlText( " "+"class=\"Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("usuariosmeniniciowc1.aspx") + "?" + UrlEncode("" +AV7sgUsrMenId)+"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "Form", true);
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
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "Form" : Form.Class)+"-fx");
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
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_12", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_12), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7sgUsrMenId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7sgUsrMenId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSGUSRMENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7sgUsrMenId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUPDATE_Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDELETE_Tooltiptext", StringUtil.RTrim( edtavDelete_Tooltiptext));
      }

      protected void RenderHtmlCloseForm0U2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            context.AddJavascriptSource("usuariosmeniniciowc1.js", "?202262714343879", false, true);
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
         return "UsuariosmenInicioWC1" ;
      }

      public override String GetPgmdesc( )
      {
         return "Usuariosmen Inicio WC1" ;
      }

      protected void WB0U0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "usuariosmeniniciowc1.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            wb_table1_2_0U2( true) ;
         }
         else
         {
            wb_table1_2_0U2( false) ;
         }
         return  ;
      }

      protected void wb_table1_2_0U2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtsgUsrMenId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A59sgUsrMenId), 6, 0, ",", "")), context.localUtil.Format( (decimal)(A59sgUsrMenId), "ZZZZZ9"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsgUsrMenId_Jsonclick, 0, "Attribute", "", "", "", "", edtsgUsrMenId_Visible, 0, 0, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_UsuariosmenInicioWC1.htm");
         }
         if ( wbEnd == 12 )
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

      protected void START0U2( )
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
               Form.Meta.addItem("description", "Usuariosmen Inicio WC1", 0) ;
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
               STRUP0U0( ) ;
            }
         }
      }

      protected void WS0U2( )
      {
         START0U2( ) ;
         EVT0U2( ) ;
      }

      protected void EVT0U2( )
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
                                 STRUP0U0( ) ;
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
                                 STRUP0U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E110U2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0U0( ) ;
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
                                 STRUP0U0( ) ;
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
                                 STRUP0U0( ) ;
                              }
                              nGXsfl_12_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
                              SubsflControlProps_122( ) ;
                              AV12Update = cgiGet( edtavUpdate_Internalname);
                              AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV12Update)) ? AV18Update_GXI : context.convertURL( context.PathToRelativeUrl( AV12Update))), !bGXsfl_12_Refreshing);
                              AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV12Update), true);
                              AV13Delete = cgiGet( edtavDelete_Internalname);
                              AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV13Delete)) ? AV19Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV13Delete))), !bGXsfl_12_Refreshing);
                              AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV13Delete), true);
                              A58menInicioId = (int)(context.localUtil.CToN( cgiGet( edtmenInicioId_Internalname), ",", "."));
                              A150menInicioDes = cgiGet( edtmenInicioDes_Internalname);
                              A186menInicioFecIni = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtmenInicioFecIni_Internalname), 0));
                              A76menInicioFecFin = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtmenInicioFecFin_Internalname), 0));
                              cmbmenInicioStat.Name = cmbmenInicioStat_Internalname;
                              cmbmenInicioStat.CurrentValue = cgiGet( cmbmenInicioStat_Internalname);
                              A77menInicioStat = (short)(NumberUtil.Val( cgiGet( cmbmenInicioStat_Internalname), "."));
                              A185menInicioFecCap = context.localUtil.CToT( cgiGet( edtmenInicioFecCap_Internalname), 0);
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
                                          E120U2 ();
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
                                          E130U2 ();
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
                                       STRUP0U0( ) ;
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

      protected void WE0U2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0U2( ) ;
            }
         }
      }

      protected void PA0U2( )
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
         SubsflControlProps_122( ) ;
         while ( nGXsfl_12_idx <= nRC_GXsfl_12 )
         {
            sendrow_122( ) ;
            nGXsfl_12_idx = ((subGrid_Islastpage==1)&&(nGXsfl_12_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       int AV7sgUsrMenId ,
                                       String AV12Update ,
                                       String AV13Delete ,
                                       String sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF0U2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_MENINICIOID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A58menInicioId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"MENINICIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A58menInicioId), 6, 0, ".", "")));
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
         RF0U2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV17Pgmname = "UsuariosmenInicioWC1";
         context.Gx_err = 0;
      }

      protected void RF0U2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 12;
         nGXsfl_12_idx = 1;
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         bGXsfl_12_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(4), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_122( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            /* Using cursor H000U2 */
            pr_default.execute(0, new Object[] {AV7sgUsrMenId, GXPagingFrom2, GXPagingTo2});
            nGXsfl_12_idx = 1;
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A59sgUsrMenId = H000U2_A59sgUsrMenId[0];
               AssignAttri(sPrefix, false, "A59sgUsrMenId", StringUtil.LTrimStr( (decimal)(A59sgUsrMenId), 6, 0));
               A185menInicioFecCap = H000U2_A185menInicioFecCap[0];
               A77menInicioStat = H000U2_A77menInicioStat[0];
               A76menInicioFecFin = H000U2_A76menInicioFecFin[0];
               A186menInicioFecIni = H000U2_A186menInicioFecIni[0];
               A150menInicioDes = H000U2_A150menInicioDes[0];
               A58menInicioId = H000U2_A58menInicioId[0];
               E130U2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 12;
            WB0U0( ) ;
         }
         bGXsfl_12_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0U2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_MENINICIOID"+"_"+sGXsfl_12_idx, GetSecureSignedToken( sPrefix+sGXsfl_12_idx, context.localUtil.Format( (decimal)(A58menInicioId), "ZZZZZ9"), context));
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
         /* Using cursor H000U3 */
         pr_default.execute(1, new Object[] {AV7sgUsrMenId});
         GRID_nRecordCount = H000U3_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV7sgUsrMenId, AV12Update, AV13Delete, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV7sgUsrMenId, AV12Update, AV13Delete, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV7sgUsrMenId, AV12Update, AV13Delete, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV7sgUsrMenId, AV12Update, AV13Delete, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV7sgUsrMenId, AV12Update, AV13Delete, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV17Pgmname = "UsuariosmenInicioWC1";
         context.Gx_err = 0;
      }

      protected void STRUP0U0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E120U2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_12 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_12"), ",", "."));
            wcpOAV7sgUsrMenId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7sgUsrMenId"), ",", "."));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            A59sgUsrMenId = (int)(context.localUtil.CToN( cgiGet( edtsgUsrMenId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A59sgUsrMenId", StringUtil.LTrimStr( (decimal)(A59sgUsrMenId), 6, 0));
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
         E120U2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E120U2( )
      {
         /* Start Routine */
         if ( ! new isauthorized(context).executeUdp(  AV17Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV17Pgmname)));
            context.wjLocDisableFrm = 1;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         AV12Update = context.GetImagePath( "7c63c2b9-483e-4035-b512-febf9186a274", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV12Update)) ? AV18Update_GXI : context.convertURL( context.PathToRelativeUrl( AV12Update))), !bGXsfl_12_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV12Update), true);
         AV18Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "7c63c2b9-483e-4035-b512-febf9186a274", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV12Update)) ? AV18Update_GXI : context.convertURL( context.PathToRelativeUrl( AV12Update))), !bGXsfl_12_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV12Update), true);
         edtavUpdate_Tooltiptext = "Modificar";
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_12_Refreshing);
         AV13Delete = context.GetImagePath( "7695fe89-52c9-4b7e-871e-0e11548f823e", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV13Delete)) ? AV19Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV13Delete))), !bGXsfl_12_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV13Delete), true);
         AV19Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "7695fe89-52c9-4b7e-871e-0e11548f823e", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV13Delete)) ? AV19Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV13Delete))), !bGXsfl_12_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV13Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_12_Refreshing);
         edtsgUsrMenId_Visible = 0;
         AssignProp(sPrefix, false, edtsgUsrMenId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtsgUsrMenId_Visible), 5, 0), true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      private void E130U2( )
      {
         /* Grid_Load Routine */
         edtavUpdate_Link = formatLink("meninicio.aspx") + "?" + UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode("" +A58menInicioId);
         edtavDelete_Link = formatLink("meninicio.aspx") + "?" + UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode("" +A58menInicioId);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            context.DoAjaxLoad(12, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E110U2( )
      {
         /* 'DoInsert' Routine */
         CallWebObject(formatLink("meninicio.aspx") + "?" + UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode("" +0) + "," + UrlEncode("" +AV7sgUsrMenId));
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         AV10TrnContext = new SdtTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV17Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV9HTTPRequest.ScriptName+"?"+AV9HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "menInicio";
         AV11TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV11TrnContextAtt.gxTpr_Attributename = "sgUsrMenId";
         AV11TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV7sgUsrMenId), 6, 0);
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV8Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "TransactionContext", "ADMINDATA1"));
      }

      protected void wb_table1_2_0U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable_Internalname, tblTable_Internalname, "", "ViewTable", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_5_0U2( true) ;
         }
         else
         {
            wb_table2_5_0U2( false) ;
         }
         return  ;
      }

      protected void wb_table2_5_0U2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_2_0U2e( true) ;
         }
         else
         {
            wb_table1_2_0U2e( false) ;
         }
      }

      protected void wb_table2_5_0U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablegridcontainer_Internalname, tblTablegridcontainer_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"right\" colspan=\"1\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-right;text-align:-moz-right;text-align:-webkit-right")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'" + sPrefix + "',false,'',0)\"";
            ClassString = "PagingButtons";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "5649fbb8-8ce0-4810-a5ce-bd649ea83c3a", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgInsert_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Agregar", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgInsert_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", StyleString, ClassString, "", "", "", "", ""+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_UsuariosmenInicioWC1.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td colspan=\"2\"  style=\""+CSSHelper.Prettify( "vertical-align:top")+"\">") ;
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"12\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "WorkWith", 0, "", "", 4, 2, sStyleString, "", "", 0);
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
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Clave del mensaje") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Mensaje") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha Inicio") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha Fin") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Status") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha/Hora Captura") ;
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
               GridContainer.AddObjectProperty("Class", "WorkWith");
               GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(4), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("CmpContext", sPrefix);
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV12Update));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV13Delete));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavDelete_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A58menInicioId), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A150menInicioDes);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A186menInicioFecIni, "99/99/9999"));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A76menInicioFecFin, "99/99/9999"));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A77menInicioStat), 1, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.TToC( A185menInicioFecCap, 10, 8, 0, 3, "/", ":", " "));
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
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            nRC_GXsfl_12 = (int)(nGXsfl_12_idx-1);
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
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_5_0U2e( true) ;
         }
         else
         {
            wb_table2_5_0U2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7sgUsrMenId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV7sgUsrMenId", StringUtil.LTrimStr( (decimal)(AV7sgUsrMenId), 6, 0));
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
         PA0U2( ) ;
         WS0U2( ) ;
         WE0U2( ) ;
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
         sCtrlAV7sgUsrMenId = (String)((String)getParm(obj,0));
      }

      public override void componentrestorestate( String sPPrefix ,
                                                  String sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0U2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (String)getParm(obj,0);
         sSFPrefix = (String)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "usuariosmeniniciowc1", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0U2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV7sgUsrMenId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV7sgUsrMenId", StringUtil.LTrimStr( (decimal)(AV7sgUsrMenId), 6, 0));
         }
         wcpOAV7sgUsrMenId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7sgUsrMenId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( AV7sgUsrMenId != wcpOAV7sgUsrMenId ) ) )
         {
            setjustcreated();
         }
         wcpOAV7sgUsrMenId = AV7sgUsrMenId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV7sgUsrMenId = cgiGet( sPrefix+"AV7sgUsrMenId_CTRL");
         if ( StringUtil.Len( sCtrlAV7sgUsrMenId) > 0 )
         {
            AV7sgUsrMenId = (int)(context.localUtil.CToN( cgiGet( sCtrlAV7sgUsrMenId), ",", "."));
            AssignAttri(sPrefix, false, "AV7sgUsrMenId", StringUtil.LTrimStr( (decimal)(AV7sgUsrMenId), 6, 0));
         }
         else
         {
            AV7sgUsrMenId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV7sgUsrMenId_PARM"), ",", "."));
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
         PA0U2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0U2( ) ;
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
         WS0U2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7sgUsrMenId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7sgUsrMenId), 6, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7sgUsrMenId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7sgUsrMenId_CTRL", StringUtil.RTrim( sCtrlAV7sgUsrMenId));
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
         WE0U2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?20226271434392", true, true);
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
            context.AddJavascriptSource("usuariosmeniniciowc1.js", "?20226271434392", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_122( )
      {
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_12_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_12_idx;
         edtmenInicioId_Internalname = sPrefix+"MENINICIOID_"+sGXsfl_12_idx;
         edtmenInicioDes_Internalname = sPrefix+"MENINICIODES_"+sGXsfl_12_idx;
         edtmenInicioFecIni_Internalname = sPrefix+"MENINICIOFECINI_"+sGXsfl_12_idx;
         edtmenInicioFecFin_Internalname = sPrefix+"MENINICIOFECFIN_"+sGXsfl_12_idx;
         cmbmenInicioStat_Internalname = sPrefix+"MENINICIOSTAT_"+sGXsfl_12_idx;
         edtmenInicioFecCap_Internalname = sPrefix+"MENINICIOFECCAP_"+sGXsfl_12_idx;
      }

      protected void SubsflControlProps_fel_122( )
      {
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_12_fel_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_12_fel_idx;
         edtmenInicioId_Internalname = sPrefix+"MENINICIOID_"+sGXsfl_12_fel_idx;
         edtmenInicioDes_Internalname = sPrefix+"MENINICIODES_"+sGXsfl_12_fel_idx;
         edtmenInicioFecIni_Internalname = sPrefix+"MENINICIOFECINI_"+sGXsfl_12_fel_idx;
         edtmenInicioFecFin_Internalname = sPrefix+"MENINICIOFECFIN_"+sGXsfl_12_fel_idx;
         cmbmenInicioStat_Internalname = sPrefix+"MENINICIOSTAT_"+sGXsfl_12_fel_idx;
         edtmenInicioFecCap_Internalname = sPrefix+"MENINICIOFECCAP_"+sGXsfl_12_fel_idx;
      }

      protected void sendrow_122( )
      {
         SubsflControlProps_122( ) ;
         WB0U0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_12_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               subGrid_Backcolor = (int)(0xFFFFFF);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_12_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0xFFFFFF);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0xFFFFFF);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+subGrid_Linesclass+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_12_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV12Update_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV12Update))&&String.IsNullOrEmpty(StringUtil.RTrim( AV18Update_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV12Update)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV12Update)) ? AV18Update_GXI : context.PathToRelativeUrl( AV12Update));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavUpdate_Internalname,(String)sImgUrl,(String)edtavUpdate_Link,(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"",(String)edtavUpdate_Tooltiptext,(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV12Update_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV13Delete_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV13Delete))&&String.IsNullOrEmpty(StringUtil.RTrim( AV19Delete_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV13Delete)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV13Delete)) ? AV19Delete_GXI : context.PathToRelativeUrl( AV13Delete));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavDelete_Internalname,(String)sImgUrl,(String)edtavDelete_Link,(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"",(String)edtavDelete_Tooltiptext,(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV13Delete_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtmenInicioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A58menInicioId), 6, 0, ",", "")),context.localUtil.Format( (decimal)(A58menInicioId), "ZZZZZ9"),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtmenInicioId_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)6,(short)0,(short)0,(short)12,(short)1,(short)-1,(short)0,(bool)true,(String)"NumId",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtmenInicioDes_Internalname,(String)A150menInicioDes,(String)"",(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtmenInicioDes_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)255,(short)0,(short)0,(short)12,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtmenInicioFecIni_Internalname,context.localUtil.Format(A186menInicioFecIni, "99/99/9999"),context.localUtil.Format( A186menInicioFecIni, "99/99/9999"),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtmenInicioFecIni_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)12,(short)1,(short)-1,(short)0,(bool)true,(String)"Fecha",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtmenInicioFecFin_Internalname,context.localUtil.Format(A76menInicioFecFin, "99/99/9999"),context.localUtil.Format( A76menInicioFecFin, "99/99/9999"),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtmenInicioFecFin_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)12,(short)1,(short)-1,(short)0,(bool)true,(String)"Fecha",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbmenInicioStat.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "MENINICIOSTAT_" + sGXsfl_12_idx;
               cmbmenInicioStat.Name = GXCCtl;
               cmbmenInicioStat.WebTags = "";
               cmbmenInicioStat.addItem("1", "Vigente", 0);
               cmbmenInicioStat.addItem("0", "No Vigente", 0);
               if ( cmbmenInicioStat.ItemCount > 0 )
               {
                  A77menInicioStat = (short)(NumberUtil.Val( cmbmenInicioStat.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A77menInicioStat), 1, 0))), "."));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbmenInicioStat,(String)cmbmenInicioStat_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A77menInicioStat), 1, 0)),(short)1,(String)cmbmenInicioStat_Jsonclick,(short)0,(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute",(String)"",(String)"",(String)"",(String)"",(bool)true});
            cmbmenInicioStat.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A77menInicioStat), 1, 0));
            AssignProp(sPrefix, false, cmbmenInicioStat_Internalname, "Values", (String)(cmbmenInicioStat.ToJavascriptSource()), !bGXsfl_12_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtmenInicioFecCap_Internalname,context.localUtil.TToC( A185menInicioFecCap, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A185menInicioFecCap, "99/99/9999 99:99:99"),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtmenInicioFecCap_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)19,(short)0,(short)0,(short)12,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaTiempo",(String)"right",(bool)false,(String)""});
            send_integrity_lvl_hashes0U2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_12_idx = ((subGrid_Islastpage==1)&&(nGXsfl_12_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
         /* End function sendrow_122 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "MENINICIOSTAT_" + sGXsfl_12_idx;
         cmbmenInicioStat.Name = GXCCtl;
         cmbmenInicioStat.WebTags = "";
         cmbmenInicioStat.addItem("1", "Vigente", 0);
         cmbmenInicioStat.addItem("0", "No Vigente", 0);
         if ( cmbmenInicioStat.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgInsert_Internalname = sPrefix+"INSERT";
         edtavUpdate_Internalname = sPrefix+"vUPDATE";
         edtavDelete_Internalname = sPrefix+"vDELETE";
         edtmenInicioId_Internalname = sPrefix+"MENINICIOID";
         edtmenInicioDes_Internalname = sPrefix+"MENINICIODES";
         edtmenInicioFecIni_Internalname = sPrefix+"MENINICIOFECINI";
         edtmenInicioFecFin_Internalname = sPrefix+"MENINICIOFECFIN";
         cmbmenInicioStat_Internalname = sPrefix+"MENINICIOSTAT";
         edtmenInicioFecCap_Internalname = sPrefix+"MENINICIOFECCAP";
         tblTablegridcontainer_Internalname = sPrefix+"TABLEGRIDCONTAINER";
         tblTable_Internalname = sPrefix+"TABLE";
         edtsgUsrMenId_Internalname = sPrefix+"SGUSRMENID";
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
         edtmenInicioFecCap_Jsonclick = "";
         cmbmenInicioStat_Jsonclick = "";
         edtmenInicioFecFin_Jsonclick = "";
         edtmenInicioFecIni_Jsonclick = "";
         edtmenInicioDes_Jsonclick = "";
         edtmenInicioId_Jsonclick = "";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtavDelete_Link = "";
         edtavUpdate_Link = "";
         subGrid_Header = "";
         subGrid_Class = "WorkWith";
         subGrid_Backcolorstyle = 3;
         edtsgUsrMenId_Jsonclick = "";
         edtsgUsrMenId_Visible = 1;
         subGrid_Rows = 0;
         edtavDelete_Tooltiptext = "Eliminar";
         edtavUpdate_Tooltiptext = "Modificar";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV7sgUsrMenId',fld:'vSGUSRMENID',pic:'ZZZZZ9'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'sPrefix'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID.LOAD","{handler:'E130U2',iparms:[{av:'A58menInicioId',fld:'MENINICIOID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E110U2',iparms:[{av:'A58menInicioId',fld:'MENINICIOID',pic:'ZZZZZ9',hsh:true},{av:'AV7sgUsrMenId',fld:'vSGUSRMENID',pic:'ZZZZZ9'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV7sgUsrMenId',fld:'vSGUSRMENID',pic:'ZZZZZ9'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'sPrefix'}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV7sgUsrMenId',fld:'vSGUSRMENID',pic:'ZZZZZ9'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'sPrefix'}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV7sgUsrMenId',fld:'vSGUSRMENID',pic:'ZZZZZ9'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'sPrefix'}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV7sgUsrMenId',fld:'vSGUSRMENID',pic:'ZZZZZ9'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'sPrefix'}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Meniniciofeccap',iparms:[]");
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
         AV12Update = "";
         AV13Delete = "";
         AV17Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV18Update_GXI = "";
         AV19Delete_GXI = "";
         A150menInicioDes = "";
         A186menInicioFecIni = DateTime.MinValue;
         A76menInicioFecFin = DateTime.MinValue;
         A185menInicioFecCap = (DateTime)(DateTime.MinValue);
         scmdbuf = "";
         H000U2_A59sgUsrMenId = new int[1] ;
         H000U2_A185menInicioFecCap = new DateTime[] {DateTime.MinValue} ;
         H000U2_A77menInicioStat = new short[1] ;
         H000U2_A76menInicioFecFin = new DateTime[] {DateTime.MinValue} ;
         H000U2_A186menInicioFecIni = new DateTime[] {DateTime.MinValue} ;
         H000U2_A150menInicioDes = new String[] {""} ;
         H000U2_A58menInicioId = new int[1] ;
         H000U3_AGRID_nRecordCount = new long[1] ;
         GridRow = new GXWebRow();
         AV10TrnContext = new SdtTransactionContext(context);
         AV9HTTPRequest = new GxHttpRequest( context);
         AV11TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV8Session = context.GetSession();
         TempTags = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         imgInsert_Jsonclick = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV7sgUsrMenId = "";
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usuariosmeniniciowc1__default(),
            new Object[][] {
                new Object[] {
               H000U2_A59sgUsrMenId, H000U2_A185menInicioFecCap, H000U2_A77menInicioStat, H000U2_A76menInicioFecFin, H000U2_A186menInicioFecIni, H000U2_A150menInicioDes, H000U2_A58menInicioId
               }
               , new Object[] {
               H000U3_AGRID_nRecordCount
               }
            }
         );
         AV17Pgmname = "UsuariosmenInicioWC1";
         /* GeneXus formulas. */
         AV17Pgmname = "UsuariosmenInicioWC1";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short A77menInicioStat ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short subGrid_Backstyle ;
      private int AV7sgUsrMenId ;
      private int wcpOAV7sgUsrMenId ;
      private int nRC_GXsfl_12 ;
      private int nGXsfl_12_idx=1 ;
      private int subGrid_Rows ;
      private int A59sgUsrMenId ;
      private int edtsgUsrMenId_Visible ;
      private int A58menInicioId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private String edtavUpdate_Tooltiptext ;
      private String edtavDelete_Tooltiptext ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sPrefix ;
      private String sCompPrefix ;
      private String sSFPrefix ;
      private String sGXsfl_12_idx="0001" ;
      private String edtavUpdate_Internalname ;
      private String edtavDelete_Internalname ;
      private String AV17Pgmname ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String edtsgUsrMenId_Internalname ;
      private String edtsgUsrMenId_Jsonclick ;
      private String sStyleString ;
      private String sXEvt ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtmenInicioId_Internalname ;
      private String edtmenInicioDes_Internalname ;
      private String edtmenInicioFecIni_Internalname ;
      private String edtmenInicioFecFin_Internalname ;
      private String cmbmenInicioStat_Internalname ;
      private String edtmenInicioFecCap_Internalname ;
      private String scmdbuf ;
      private String edtavUpdate_Link ;
      private String edtavDelete_Link ;
      private String tblTable_Internalname ;
      private String tblTablegridcontainer_Internalname ;
      private String TempTags ;
      private String ClassString ;
      private String StyleString ;
      private String sImgUrl ;
      private String imgInsert_Internalname ;
      private String imgInsert_Jsonclick ;
      private String subGrid_Internalname ;
      private String subGrid_Class ;
      private String subGrid_Linesclass ;
      private String subGrid_Header ;
      private String sCtrlAV7sgUsrMenId ;
      private String sGXsfl_12_fel_idx="0001" ;
      private String ROClassString ;
      private String edtmenInicioId_Jsonclick ;
      private String edtmenInicioDes_Jsonclick ;
      private String edtmenInicioFecIni_Jsonclick ;
      private String edtmenInicioFecFin_Jsonclick ;
      private String GXCCtl ;
      private String cmbmenInicioStat_Jsonclick ;
      private String edtmenInicioFecCap_Jsonclick ;
      private DateTime A185menInicioFecCap ;
      private DateTime A186menInicioFecIni ;
      private DateTime A76menInicioFecFin ;
      private bool entryPointCalled ;
      private bool bGXsfl_12_Refreshing=false ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV12Update_IsBlob ;
      private bool AV13Delete_IsBlob ;
      private String AV18Update_GXI ;
      private String AV19Delete_GXI ;
      private String A150menInicioDes ;
      private String AV12Update ;
      private String AV13Delete ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbmenInicioStat ;
      private IDataStoreProvider pr_default ;
      private int[] H000U2_A59sgUsrMenId ;
      private DateTime[] H000U2_A185menInicioFecCap ;
      private short[] H000U2_A77menInicioStat ;
      private DateTime[] H000U2_A76menInicioFecFin ;
      private DateTime[] H000U2_A186menInicioFecIni ;
      private String[] H000U2_A150menInicioDes ;
      private int[] H000U2_A58menInicioId ;
      private long[] H000U3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV9HTTPRequest ;
      private IGxSession AV8Session ;
      private SdtTransactionContext AV10TrnContext ;
      private SdtTransactionContext_Attribute AV11TrnContextAtt ;
   }

   public class usuariosmeniniciowc1__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH000U2 ;
          prmH000U2 = new Object[] {
          new Object[] {"AV7sgUsrMenId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"GXPagingFrom2",System.Data.DbType.Int32,9,0} ,
          new Object[] {"GXPagingTo2",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmH000U3 ;
          prmH000U3 = new Object[] {
          new Object[] {"AV7sgUsrMenId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H000U2", "SELECT `sgUsrMenId`, `menInicioFecCap`, `menInicioStat`, `menInicioFecFin`, `menInicioFecIni`, `menInicioDes`, `menInicioId` FROM `menInicio` WHERE `sgUsrMenId` = ? ORDER BY `menInicioId`  LIMIT ?, ?",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000U2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000U3", "SELECT COUNT(*) FROM `menInicio` WHERE `sgUsrMenId` = ? ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000U3,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4) ;
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
                ((int[]) buf[6])[0] = rslt.getInt(7) ;
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
