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
   public class wpcandidatosvac : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpcandidatosvac( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public wpcandidatosvac( IGxContext context )
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
         radavVacantes_status = new GXRadio();
         cmbVacantes_Tipo = new GXCombobox();
         cmbVacantes_Status = new GXCombobox();
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
               nRC_GXsfl_22 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_22_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_22_idx = GetNextPar( );
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
               AV5NomCompleto = GetNextPar( );
               AV9Vacantes_Status = (short)(NumberUtil.Val( GetNextPar( ), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV5NomCompleto, AV9Vacantes_Status) ;
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
         PA2Z2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2Z2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202262714345385", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpcandidatosvac.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vNOMCOMPLETO", AV5NomCompleto);
         GxWebStd.gx_hidden_field( context, "GXH_vVACANTES_STATUS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9Vacantes_Status), 4, 0, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_22", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_22), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VACANTES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A263Vacantes_Id), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
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
            WE2Z2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2Z2( ) ;
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
         return formatLink("wpcandidatosvac.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "wpCandidatosVac" ;
      }

      public override String GetPgmdesc( )
      {
         return "wp Candidatos" ;
      }

      protected void WB2Z0( )
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
            wb_table1_6_2Z2( true) ;
         }
         else
         {
            wb_table1_6_2Z2( false) ;
         }
         return  ;
      }

      protected void wb_table1_6_2Z2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 22 )
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

      protected void START2Z2( )
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
         STRUP2Z0( ) ;
      }

      protected void WS2Z2( )
      {
         START2Z2( ) ;
         EVT2Z2( ) ;
      }

      protected void EVT2Z2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "VVACANTES_STATUS.ISVALID") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E112Z2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_22_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0");
                              SubsflControlProps_222( ) ;
                              A264Vacantes_Nombre = cgiGet( edtVacantes_Nombre_Internalname);
                              cmbVacantes_Tipo.Name = cmbVacantes_Tipo_Internalname;
                              cmbVacantes_Tipo.CurrentValue = cgiGet( cmbVacantes_Tipo_Internalname);
                              A268Vacantes_Tipo = (short)(NumberUtil.Val( cgiGet( cmbVacantes_Tipo_Internalname), "."));
                              A266Vacantes_FechaInicio = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtVacantes_FechaInicio_Internalname), 0));
                              A267Vacantes_Sueldo = context.localUtil.CToN( cgiGet( edtVacantes_Sueldo_Internalname), ",", ".");
                              cmbVacantes_Status.Name = cmbVacantes_Status_Internalname;
                              cmbVacantes_Status.CurrentValue = cgiGet( cmbVacantes_Status_Internalname);
                              A265Vacantes_Status = (short)(NumberUtil.Val( cgiGet( cmbVacantes_Status_Internalname), "."));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E122Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E132Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Nomcompleto Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vNOMCOMPLETO"), AV5NomCompleto) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Vacantes_status Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vVACANTES_STATUS"), ",", ".") != Convert.ToDecimal( AV9Vacantes_Status )) )
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

      protected void WE2Z2( )
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

      protected void PA2Z2( )
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

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_222( ) ;
         while ( nGXsfl_22_idx <= nRC_GXsfl_22 )
         {
            sendrow_222( ) ;
            nGXsfl_22_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_22_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_22_idx+1);
            sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0");
            SubsflControlProps_222( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        String AV5NomCompleto ,
                                        short AV9Vacantes_Status )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF2Z2( ) ;
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
         AV9Vacantes_Status = (short)(context.localUtil.CToN( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9Vacantes_Status), 4, 0, ".", "")), ",", "."));
         AssignAttri("", false, "AV9Vacantes_Status", StringUtil.LTrimStr( (decimal)(AV9Vacantes_Status), 4, 0));
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2Z2( ) ;
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

      protected void RF2Z2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 22;
         nGXsfl_22_idx = 1;
         sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0");
         SubsflControlProps_222( ) ;
         bGXsfl_22_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "WorkWithVacantes");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_222( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV5NomCompleto ,
                                                 AV9Vacantes_Status ,
                                                 A264Vacantes_Nombre ,
                                                 A265Vacantes_Status } ,
                                                 new int[]{
                                                 TypeConstants.STRING, TypeConstants.SHORT, TypeConstants.STRING, TypeConstants.SHORT
                                                 }
            } ) ;
            lV5NomCompleto = StringUtil.Concat( StringUtil.RTrim( AV5NomCompleto), "%", "");
            /* Using cursor H002Z2 */
            pr_default.execute(0, new Object[] {lV5NomCompleto, AV9Vacantes_Status, GXPagingFrom2, GXPagingTo2});
            nGXsfl_22_idx = 1;
            sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0");
            SubsflControlProps_222( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A263Vacantes_Id = H002Z2_A263Vacantes_Id[0];
               A265Vacantes_Status = H002Z2_A265Vacantes_Status[0];
               A267Vacantes_Sueldo = H002Z2_A267Vacantes_Sueldo[0];
               A266Vacantes_FechaInicio = H002Z2_A266Vacantes_FechaInicio[0];
               A268Vacantes_Tipo = H002Z2_A268Vacantes_Tipo[0];
               A264Vacantes_Nombre = H002Z2_A264Vacantes_Nombre[0];
               E122Z2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 22;
            WB2Z0( ) ;
         }
         bGXsfl_22_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2Z2( )
      {
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV5NomCompleto ,
                                              AV9Vacantes_Status ,
                                              A264Vacantes_Nombre ,
                                              A265Vacantes_Status } ,
                                              new int[]{
                                              TypeConstants.STRING, TypeConstants.SHORT, TypeConstants.STRING, TypeConstants.SHORT
                                              }
         } ) ;
         lV5NomCompleto = StringUtil.Concat( StringUtil.RTrim( AV5NomCompleto), "%", "");
         /* Using cursor H002Z3 */
         pr_default.execute(1, new Object[] {lV5NomCompleto, AV9Vacantes_Status});
         GRID1_nRecordCount = H002Z3_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(15*1) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV5NomCompleto, AV9Vacantes_Status) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV5NomCompleto, AV9Vacantes_Status) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV5NomCompleto, AV9Vacantes_Status) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV5NomCompleto, AV9Vacantes_Status) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV5NomCompleto, AV9Vacantes_Status) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP2Z0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E132Z2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_22 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_22"), ",", "."));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ",", "."));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ",", "."));
            /* Read variables values. */
            AV5NomCompleto = cgiGet( edtavNomcompleto_Internalname);
            AssignAttri("", false, "AV5NomCompleto", AV5NomCompleto);
            if ( ( ( context.localUtil.CToN( cgiGet( radavVacantes_status_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( radavVacantes_status_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVACANTES_STATUS");
               wbErr = true;
               AV9Vacantes_Status = 0;
               AssignAttri("", false, "AV9Vacantes_Status", StringUtil.LTrimStr( (decimal)(AV9Vacantes_Status), 4, 0));
            }
            else
            {
               AV9Vacantes_Status = (short)(context.localUtil.CToN( cgiGet( radavVacantes_status_Internalname), ",", "."));
               AssignAttri("", false, "AV9Vacantes_Status", StringUtil.LTrimStr( (decimal)(AV9Vacantes_Status), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vNOMCOMPLETO"), AV5NomCompleto) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vVACANTES_STATUS"), ",", ".") != Convert.ToDecimal( AV9Vacantes_Status )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E112Z2( )
      {
         /* Vacantes_status_Isvalid Routine */
         if ( AV9Vacantes_Status == 1 )
         {
            lblTitletext_Caption = "Activas";
            AssignProp("", false, lblTitletext_Internalname, "Caption", lblTitletext_Caption, true);
            context.DoAjaxRefresh();
         }
         else if ( AV9Vacantes_Status == 2 )
         {
            lblTitletext_Caption = "Inactivas";
            AssignProp("", false, lblTitletext_Internalname, "Caption", lblTitletext_Caption, true);
            context.DoAjaxRefresh();
         }
         else if ( AV9Vacantes_Status == 3 )
         {
            lblTitletext_Caption = "Espera";
            AssignProp("", false, lblTitletext_Internalname, "Caption", lblTitletext_Caption, true);
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
      }

      private void E122Z2( )
      {
         /* Grid1_Load Routine */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpvacanteinf.aspx"+UrlEncode("" +A263Vacantes_Id);
         edtVacantes_Nombre_Link = formatLink("wpvacanteinf.aspx") + "?" + Encrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 22;
         }
         sendrow_222( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_22_Refreshing )
         {
            context.DoAjaxLoad(22, Grid1Row);
         }
         /*  Sending Event outputs  */
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E132Z2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E132Z2( )
      {
         /* Start Routine */
         AV9Vacantes_Status = 1;
         AssignAttri("", false, "AV9Vacantes_Status", StringUtil.LTrimStr( (decimal)(AV9Vacantes_Status), 4, 0));
      }

      protected void wb_table1_6_2Z2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable1_Internalname, tblTable1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "TableTopSearch", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2 col-xs-offset-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, lblTitletext_Caption, "", "", lblTitletext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SubTitle", 0, "", 1, 1, 0, "HLP_wpCandidatosVac.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNomcompleto_Internalname, "Nom Completo", "col-sm-3 FilterSearchAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'" + sGXsfl_22_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNomcompleto_Internalname, AV5NomCompleto, StringUtil.RTrim( context.localUtil.Format( AV5NomCompleto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,15);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Nombre", edtavNomcompleto_Jsonclick, 0, "FilterSearchAttribute", "", "", "", "", 1, edtavNomcompleto_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_wpCandidatosVac.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+radavVacantes_status_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Estatús", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'" + sGXsfl_22_idx + "',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavVacantes_status, radavVacantes_status_Internalname, StringUtil.Str( (decimal)(AV9Vacantes_Status), 4, 0), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavVacantes_status_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,19);\"", "HLP_wpCandidatosVac.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"22\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "WorkWithVacantes", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tipo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha Inicio") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Sueldo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Estatus") ;
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
               Grid1Container.AddObjectProperty("Class", "WorkWithVacantes");
               Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("CmpContext", "");
               Grid1Container.AddObjectProperty("InMasterPage", "false");
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", A264Vacantes_Nombre);
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtVacantes_Nombre_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A268Vacantes_Tipo), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A266Vacantes_FechaInicio, "99/99/99"));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A267Vacantes_Sueldo, 6, 3, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A265Vacantes_Status), 4, 0, ".", "")));
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
         if ( wbEnd == 22 )
         {
            wbEnd = 0;
            nRC_GXsfl_22 = (int)(nGXsfl_22_idx-1);
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
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_6_2Z2e( true) ;
         }
         else
         {
            wb_table1_6_2Z2e( false) ;
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
         PA2Z2( ) ;
         WS2Z2( ) ;
         WE2Z2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714345410", true, true);
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
         context.AddJavascriptSource("wpcandidatosvac.js", "?202262714345410", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_222( )
      {
         edtVacantes_Nombre_Internalname = "VACANTES_NOMBRE_"+sGXsfl_22_idx;
         cmbVacantes_Tipo_Internalname = "VACANTES_TIPO_"+sGXsfl_22_idx;
         edtVacantes_FechaInicio_Internalname = "VACANTES_FECHAINICIO_"+sGXsfl_22_idx;
         edtVacantes_Sueldo_Internalname = "VACANTES_SUELDO_"+sGXsfl_22_idx;
         cmbVacantes_Status_Internalname = "VACANTES_STATUS_"+sGXsfl_22_idx;
      }

      protected void SubsflControlProps_fel_222( )
      {
         edtVacantes_Nombre_Internalname = "VACANTES_NOMBRE_"+sGXsfl_22_fel_idx;
         cmbVacantes_Tipo_Internalname = "VACANTES_TIPO_"+sGXsfl_22_fel_idx;
         edtVacantes_FechaInicio_Internalname = "VACANTES_FECHAINICIO_"+sGXsfl_22_fel_idx;
         edtVacantes_Sueldo_Internalname = "VACANTES_SUELDO_"+sGXsfl_22_fel_idx;
         cmbVacantes_Status_Internalname = "VACANTES_STATUS_"+sGXsfl_22_fel_idx;
      }

      protected void sendrow_222( )
      {
         SubsflControlProps_222( ) ;
         WB2Z0( ) ;
         if ( ( 15 * 1 == 0 ) || ( nGXsfl_22_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_22_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"WorkWithVacantes"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_22_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtVacantes_Nombre_Internalname,(String)A264Vacantes_Nombre,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)edtVacantes_Nombre_Link,(String)"",(String)"",(String)"",(String)edtVacantes_Nombre_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)40,(short)0,(short)0,(short)22,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbVacantes_Tipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "VACANTES_TIPO_" + sGXsfl_22_idx;
               cmbVacantes_Tipo.Name = GXCCtl;
               cmbVacantes_Tipo.WebTags = "";
               cmbVacantes_Tipo.addItem("1", "Home Office", 0);
               cmbVacantes_Tipo.addItem("2", "Presencial", 0);
               cmbVacantes_Tipo.addItem("3", "Mixto", 0);
               if ( cmbVacantes_Tipo.ItemCount > 0 )
               {
                  A268Vacantes_Tipo = (short)(NumberUtil.Val( cmbVacantes_Tipo.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A268Vacantes_Tipo), 4, 0))), "."));
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbVacantes_Tipo,(String)cmbVacantes_Tipo_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A268Vacantes_Tipo), 4, 0)),(short)1,(String)cmbVacantes_Tipo_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute",(String)"",(String)"",(String)"",(String)"",(bool)true});
            cmbVacantes_Tipo.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A268Vacantes_Tipo), 4, 0));
            AssignProp("", false, cmbVacantes_Tipo_Internalname, "Values", (String)(cmbVacantes_Tipo.ToJavascriptSource()), !bGXsfl_22_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtVacantes_FechaInicio_Internalname,context.localUtil.Format(A266Vacantes_FechaInicio, "99/99/99"),context.localUtil.Format( A266Vacantes_FechaInicio, "99/99/99"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtVacantes_FechaInicio_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)8,(short)0,(short)0,(short)22,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtVacantes_Sueldo_Internalname,StringUtil.LTrim( StringUtil.NToC( A267Vacantes_Sueldo, 6, 3, ",", "")),context.localUtil.Format( A267Vacantes_Sueldo, "Z9.999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtVacantes_Sueldo_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)6,(short)0,(short)0,(short)22,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbVacantes_Status.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "VACANTES_STATUS_" + sGXsfl_22_idx;
               cmbVacantes_Status.Name = GXCCtl;
               cmbVacantes_Status.WebTags = "";
               cmbVacantes_Status.addItem("1", "Activo", 0);
               cmbVacantes_Status.addItem("2", "Inactivo", 0);
               cmbVacantes_Status.addItem("3", "Espera", 0);
               if ( cmbVacantes_Status.ItemCount > 0 )
               {
                  A265Vacantes_Status = (short)(NumberUtil.Val( cmbVacantes_Status.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A265Vacantes_Status), 4, 0))), "."));
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbVacantes_Status,(String)cmbVacantes_Status_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A265Vacantes_Status), 4, 0)),(short)1,(String)cmbVacantes_Status_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)0,(short)0,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute",(String)"",(String)"",(String)"",(String)"",(bool)true});
            cmbVacantes_Status.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A265Vacantes_Status), 4, 0));
            AssignProp("", false, cmbVacantes_Status_Internalname, "Values", (String)(cmbVacantes_Status.ToJavascriptSource()), !bGXsfl_22_Refreshing);
            send_integrity_lvl_hashes2Z2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_22_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_22_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_22_idx+1);
            sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0");
            SubsflControlProps_222( ) ;
         }
         /* End function sendrow_222 */
      }

      protected void init_web_controls( )
      {
         radavVacantes_status.Name = "vVACANTES_STATUS";
         radavVacantes_status.WebTags = "";
         radavVacantes_status.addItem("1", "Activo", 0);
         radavVacantes_status.addItem("2", "Inactivo", 0);
         radavVacantes_status.addItem("3", "Espera", 0);
         GXCCtl = "VACANTES_TIPO_" + sGXsfl_22_idx;
         cmbVacantes_Tipo.Name = GXCCtl;
         cmbVacantes_Tipo.WebTags = "";
         cmbVacantes_Tipo.addItem("1", "Home Office", 0);
         cmbVacantes_Tipo.addItem("2", "Presencial", 0);
         cmbVacantes_Tipo.addItem("3", "Mixto", 0);
         if ( cmbVacantes_Tipo.ItemCount > 0 )
         {
            A268Vacantes_Tipo = (short)(NumberUtil.Val( cmbVacantes_Tipo.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A268Vacantes_Tipo), 4, 0))), "."));
         }
         GXCCtl = "VACANTES_STATUS_" + sGXsfl_22_idx;
         cmbVacantes_Status.Name = GXCCtl;
         cmbVacantes_Status.WebTags = "";
         cmbVacantes_Status.addItem("1", "Activo", 0);
         cmbVacantes_Status.addItem("2", "Inactivo", 0);
         cmbVacantes_Status.addItem("3", "Espera", 0);
         if ( cmbVacantes_Status.ItemCount > 0 )
         {
            A265Vacantes_Status = (short)(NumberUtil.Val( cmbVacantes_Status.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A265Vacantes_Status), 4, 0))), "."));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitletext_Internalname = "TITLETEXT";
         edtavNomcompleto_Internalname = "vNOMCOMPLETO";
         radavVacantes_status_Internalname = "vVACANTES_STATUS";
         divTable2_Internalname = "TABLE2";
         edtVacantes_Nombre_Internalname = "VACANTES_NOMBRE";
         cmbVacantes_Tipo_Internalname = "VACANTES_TIPO";
         edtVacantes_FechaInicio_Internalname = "VACANTES_FECHAINICIO";
         edtVacantes_Sueldo_Internalname = "VACANTES_SUELDO";
         cmbVacantes_Status_Internalname = "VACANTES_STATUS";
         tblTable1_Internalname = "TABLE1";
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
         cmbVacantes_Status_Jsonclick = "";
         edtVacantes_Sueldo_Jsonclick = "";
         edtVacantes_FechaInicio_Jsonclick = "";
         cmbVacantes_Tipo_Jsonclick = "";
         edtVacantes_Nombre_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtVacantes_Nombre_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "WorkWithVacantes";
         subGrid1_Backcolorstyle = 0;
         radavVacantes_status_Jsonclick = "";
         edtavNomcompleto_Jsonclick = "";
         edtavNomcompleto_Enabled = 1;
         lblTitletext_Caption = "Activas";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "wp Candidatos";
         subGrid1_Rows = 15;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV5NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'radavVacantes_status'},{av:'AV9Vacantes_Status',fld:'vVACANTES_STATUS',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'radavVacantes_status'},{av:'AV9Vacantes_Status',fld:'vVACANTES_STATUS',pic:'ZZZ9'}]}");
         setEventMetadata("VVACANTES_STATUS.ISVALID","{handler:'E112Z2',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV5NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'radavVacantes_status'},{av:'AV9Vacantes_Status',fld:'vVACANTES_STATUS',pic:'ZZZ9'}]");
         setEventMetadata("VVACANTES_STATUS.ISVALID",",oparms:[{av:'lblTitletext_Caption',ctrl:'TITLETEXT',prop:'Caption'},{av:'radavVacantes_status'},{av:'AV9Vacantes_Status',fld:'vVACANTES_STATUS',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1.LOAD","{handler:'E122Z2',iparms:[{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'radavVacantes_status'},{av:'AV9Vacantes_Status',fld:'vVACANTES_STATUS',pic:'ZZZ9'}]");
         setEventMetadata("GRID1.LOAD",",oparms:[{av:'edtVacantes_Nombre_Link',ctrl:'VACANTES_NOMBRE',prop:'Link'},{av:'radavVacantes_status'},{av:'AV9Vacantes_Status',fld:'vVACANTES_STATUS',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV5NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'radavVacantes_status'},{av:'AV9Vacantes_Status',fld:'vVACANTES_STATUS',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[{av:'radavVacantes_status'},{av:'AV9Vacantes_Status',fld:'vVACANTES_STATUS',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV5NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'radavVacantes_status'},{av:'AV9Vacantes_Status',fld:'vVACANTES_STATUS',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[{av:'radavVacantes_status'},{av:'AV9Vacantes_Status',fld:'vVACANTES_STATUS',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV5NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'radavVacantes_status'},{av:'AV9Vacantes_Status',fld:'vVACANTES_STATUS',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[{av:'radavVacantes_status'},{av:'AV9Vacantes_Status',fld:'vVACANTES_STATUS',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV5NomCompleto',fld:'vNOMCOMPLETO',pic:''},{av:'radavVacantes_status'},{av:'AV9Vacantes_Status',fld:'vVACANTES_STATUS',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[{av:'radavVacantes_status'},{av:'AV9Vacantes_Status',fld:'vVACANTES_STATUS',pic:'ZZZ9'}]}");
         setEventMetadata("NULL","{handler:'Valid_Vacantes_status',iparms:[{av:'radavVacantes_status'},{av:'AV9Vacantes_Status',fld:'vVACANTES_STATUS',pic:'ZZZ9'}]");
         setEventMetadata("NULL",",oparms:[{av:'radavVacantes_status'},{av:'AV9Vacantes_Status',fld:'vVACANTES_STATUS',pic:'ZZZ9'}]}");
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
         AV5NomCompleto = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A264Vacantes_Nombre = "";
         A266Vacantes_FechaInicio = DateTime.MinValue;
         scmdbuf = "";
         lV5NomCompleto = "";
         H002Z2_A263Vacantes_Id = new int[1] ;
         H002Z2_A265Vacantes_Status = new short[1] ;
         H002Z2_A267Vacantes_Sueldo = new decimal[1] ;
         H002Z2_A266Vacantes_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         H002Z2_A268Vacantes_Tipo = new short[1] ;
         H002Z2_A264Vacantes_Nombre = new String[] {""} ;
         H002Z3_AGRID1_nRecordCount = new long[1] ;
         GXEncryptionTmp = "";
         Grid1Row = new GXWebRow();
         lblTitletext_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpcandidatosvac__default(),
            new Object[][] {
                new Object[] {
               H002Z2_A263Vacantes_Id, H002Z2_A265Vacantes_Status, H002Z2_A267Vacantes_Sueldo, H002Z2_A266Vacantes_FechaInicio, H002Z2_A268Vacantes_Tipo, H002Z2_A264Vacantes_Nombre
               }
               , new Object[] {
               H002Z3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV9Vacantes_Status ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A268Vacantes_Tipo ;
      private short A265Vacantes_Status ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_22 ;
      private int nGXsfl_22_idx=1 ;
      private int subGrid1_Rows ;
      private int A263Vacantes_Id ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtavNomcompleto_Enabled ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private decimal A267Vacantes_Sueldo ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_22_idx="0001" ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String sStyleString ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtVacantes_Nombre_Internalname ;
      private String cmbVacantes_Tipo_Internalname ;
      private String edtVacantes_FechaInicio_Internalname ;
      private String edtVacantes_Sueldo_Internalname ;
      private String cmbVacantes_Status_Internalname ;
      private String edtavNomcompleto_Internalname ;
      private String scmdbuf ;
      private String radavVacantes_status_Internalname ;
      private String lblTitletext_Caption ;
      private String lblTitletext_Internalname ;
      private String edtVacantes_Nombre_Link ;
      private String GXEncryptionTmp ;
      private String tblTable1_Internalname ;
      private String divTable2_Internalname ;
      private String lblTitletext_Jsonclick ;
      private String TempTags ;
      private String edtavNomcompleto_Jsonclick ;
      private String ClassString ;
      private String StyleString ;
      private String radavVacantes_status_Jsonclick ;
      private String subGrid1_Internalname ;
      private String subGrid1_Class ;
      private String subGrid1_Linesclass ;
      private String subGrid1_Header ;
      private String sGXsfl_22_fel_idx="0001" ;
      private String ROClassString ;
      private String edtVacantes_Nombre_Jsonclick ;
      private String GXCCtl ;
      private String cmbVacantes_Tipo_Jsonclick ;
      private String edtVacantes_FechaInicio_Jsonclick ;
      private String edtVacantes_Sueldo_Jsonclick ;
      private String cmbVacantes_Status_Jsonclick ;
      private DateTime A266Vacantes_FechaInicio ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_22_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private String AV5NomCompleto ;
      private String A264Vacantes_Nombre ;
      private String lV5NomCompleto ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private GXRadio radavVacantes_status ;
      private GXCombobox cmbVacantes_Tipo ;
      private GXCombobox cmbVacantes_Status ;
      private IDataStoreProvider pr_default ;
      private int[] H002Z2_A263Vacantes_Id ;
      private short[] H002Z2_A265Vacantes_Status ;
      private decimal[] H002Z2_A267Vacantes_Sueldo ;
      private DateTime[] H002Z2_A266Vacantes_FechaInicio ;
      private short[] H002Z2_A268Vacantes_Tipo ;
      private String[] H002Z2_A264Vacantes_Nombre ;
      private long[] H002Z3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

   public class wpcandidatosvac__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002Z2( IGxContext context ,
                                             String AV5NomCompleto ,
                                             short AV9Vacantes_Status ,
                                             String A264Vacantes_Nombre ,
                                             short A265Vacantes_Status )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int1 ;
         GXv_int1 = new short [4] ;
         Object[] GXv_Object2 ;
         GXv_Object2 = new Object [2] ;
         String sSelectString ;
         String sFromString ;
         String sOrderString ;
         sSelectString = " `Vacantes_Id`, `Vacantes_Status`, `Vacantes_Sueldo`, `Vacantes_FechaInicio`, `Vacantes_Tipo`, `Vacantes_Nombre`";
         sFromString = " FROM `Vacantes`";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV5NomCompleto)) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (`Vacantes_Nombre` like ?)";
            }
            else
            {
               sWhereString = sWhereString + " (`Vacantes_Nombre` like ?)";
            }
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV9Vacantes_Status) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (`Vacantes_Status` = ?)";
            }
            else
            {
               sWhereString = sWhereString + " (`Vacantes_Status` = ?)";
            }
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( StringUtil.StrCmp("", sWhereString) != 0 )
         {
            sWhereString = " WHERE" + sWhereString;
         }
         sOrderString = sOrderString + " ORDER BY `Vacantes_Id`";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " LIMIT " + "?" + ", " + "?";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H002Z3( IGxContext context ,
                                             String AV5NomCompleto ,
                                             short AV9Vacantes_Status ,
                                             String A264Vacantes_Nombre ,
                                             short A265Vacantes_Status )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int3 ;
         GXv_int3 = new short [2] ;
         Object[] GXv_Object4 ;
         GXv_Object4 = new Object [2] ;
         scmdbuf = "SELECT COUNT(*) FROM `Vacantes`";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV5NomCompleto)) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (`Vacantes_Nombre` like ?)";
            }
            else
            {
               sWhereString = sWhereString + " (`Vacantes_Nombre` like ?)";
            }
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! (0==AV9Vacantes_Status) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (`Vacantes_Status` = ?)";
            }
            else
            {
               sWhereString = sWhereString + " (`Vacantes_Status` = ?)";
            }
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( StringUtil.StrCmp("", sWhereString) != 0 )
         {
            scmdbuf = scmdbuf + " WHERE" + sWhereString;
         }
         scmdbuf = scmdbuf + "";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H002Z2(context, (String)dynConstraints[0] , (short)dynConstraints[1] , (String)dynConstraints[2] , (short)dynConstraints[3] );
               case 1 :
                     return conditional_H002Z3(context, (String)dynConstraints[0] , (short)dynConstraints[1] , (String)dynConstraints[2] , (short)dynConstraints[3] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH002Z2 ;
          prmH002Z2 = new Object[] {
          new Object[] {"lV5NomCompleto",System.Data.DbType.String,40,0} ,
          new Object[] {"AV9Vacantes_Status",System.Data.DbType.Int16,4,0} ,
          new Object[] {"GXPagingFrom2",System.Data.DbType.Int32,9,0} ,
          new Object[] {"GXPagingTo2",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmH002Z3 ;
          prmH002Z3 = new Object[] {
          new Object[] {"lV5NomCompleto",System.Data.DbType.String,40,0} ,
          new Object[] {"AV9Vacantes_Status",System.Data.DbType.Int16,4,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H002Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Z2,16, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H002Z3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Z3,1, GxCacheFrequency.OFF ,false,false )
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
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3) ;
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4) ;
                ((short[]) buf[4])[0] = rslt.getShort(5) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
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
       short sIdx ;
       switch ( cursor )
       {
             case 0 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[4]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (short)parms[5]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[6]);
                }
                if ( (short)parms[3] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[7]);
                }
                return;
             case 1 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[2]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (short)parms[3]);
                }
                return;
       }
    }

 }

}
