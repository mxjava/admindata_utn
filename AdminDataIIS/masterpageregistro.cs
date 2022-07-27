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
   public class masterpageregistro : GXMasterPage, System.Web.SessionState.IRequiresSessionState
   {
      public masterpageregistro( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public masterpageregistro( IGxContext context )
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
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
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
            PA0X2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               lblBloqueo_Visible = 0;
               AssignProp("", true, lblBloqueo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblBloqueo_Visible), 5, 0), true);
               WS0X2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE0X2( ) ;
               }
            }
         }
         this.cleanup();
      }

      protected void RenderHtmlHeaders( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlHeaders();
         }
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlOpenForm();
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
      }

      protected void RenderHtmlCloseForm0X2( )
      {
         SendCloseFormHiddens( ) ;
         SendSecurityToken((String)(sPrefix));
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlCloseForm();
         }
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( ! ( WebComp_Encabezado == null ) )
         {
            WebComp_Encabezado.componentjscripts();
         }
         context.AddJavascriptSource("masterpageregistro.js", "?202262714344726", false, true);
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override String GetPgmname( )
      {
         return "MasterPageRegistro" ;
      }

      public override String GetPgmdesc( )
      {
         return "Master Page Registro" ;
      }

      protected void WB0X0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            if ( ! ShowMPWhenPopUp( ) && context.isPopUpObject( ) )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
               /* Content placeholder */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gx-content-placeholder");
               context.WriteHtmlText( ">") ;
               if ( ! isFullAjaxMode( ) )
               {
                  getDataAreaObject().RenderHtmlContent();
               }
               context.WriteHtmlText( "</div>") ;
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
               wbLoad = true;
               return  ;
            }
            wb_table1_2_0X2( true) ;
         }
         else
         {
            wb_table1_2_0X2( false) ;
         }
         return  ;
      }

      protected void wb_table1_2_0X2e( bool wbgen )
      {
         if ( wbgen )
         {
         }
         wbLoad = true;
      }

      protected void START0X2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0X0( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( getDataAreaObject().ExecuteStartEvent() != 0 )
            {
               setAjaxCallMode();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      protected void WS0X2( )
      {
         START0X2( ) ;
         EVT0X2( ) ;
      }

      protected void EVT0X2( )
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
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "RFR_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E110X2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E120X2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER_MPAGE") == 0 )
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
                           dynload_actions( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  else if ( StringUtil.StrCmp(sEvtType, "M") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-2));
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-6));
                     nCmpId = (short)(NumberUtil.Val( sEvtType, "."));
                     if ( nCmpId == 6 )
                     {
                        OldEncabezado = cgiGet( "MPW0006");
                        if ( ( StringUtil.Len( OldEncabezado) == 0 ) || ( StringUtil.StrCmp(OldEncabezado, WebComp_Encabezado_Component) != 0 ) )
                        {
                           WebComp_Encabezado = getWebComponent(GetType(), "GeneXus.Programs", OldEncabezado, new Object[] {context} );
                           WebComp_Encabezado.ComponentInit();
                           WebComp_Encabezado.Name = "OldEncabezado";
                           WebComp_Encabezado_Component = OldEncabezado;
                        }
                        WebComp_Encabezado.componentprocess("MPW0006", "", sEvt);
                        WebComp_Encabezado_Component = OldEncabezado;
                     }
                  }
                  if ( context.wbHandled == 0 )
                  {
                     getDataAreaObject().DispatchEvents();
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void WE0X2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0X2( ) ;
            }
         }
      }

      protected void PA0X2( )
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
         RF0X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         lblBloqueo_Visible = 0;
         AssignProp("", true, lblBloqueo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblBloqueo_Visible), 5, 0), true);
      }

      protected void RF0X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ShowMPWhenPopUp( ) || ! context.isPopUpObject( ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
            {
               if ( 1 != 0 )
               {
                  WebComp_Encabezado.componentstart();
               }
            }
            gxdyncontrolsrefreshing = true;
            fix_multi_value_controls( ) ;
            gxdyncontrolsrefreshing = false;
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E120X2 ();
            WB0X0( ) ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
      }

      protected void send_integrity_lvl_hashes0X2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         lblBloqueo_Visible = 0;
         AssignProp("", true, lblBloqueo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblBloqueo_Visible), 5, 0), true);
      }

      protected void STRUP0X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110X2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV7chrome = cgiGet( imgavChrome_Internalname);
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
         E110X2 ();
         if (returnInSub) return;
      }

      protected void E110X2( )
      {
         /* Start Routine */
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml = "<link href=\""+context.convertURL( (String)(context.GetImagePath( "f423d159-e0c7-4334-9806-22e8b9382978", "", context.GetTheme( ))))+"\" rel=\"shortcut icon\">";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption = "Secretaría de Marina | Gobierno | gob.mx";
         AssignProp("", true, "FORM", "Caption", (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption, true);
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Meta.addItem("charset", "UTF-8", 0) ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml = (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml+"<link rel=\"stylesheet\" href=\"../static/Resources/Spanish/alertas/sweetalert.css\" />";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml = (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml+"<script src=\"../static/Resources/Spanish/alertas/sweetalert.min.js\" type=\"text/javascript\"></script>";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml = (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml+"<link rel=\"stylesheet\" href=\"../static/Resources/Spanish/notificacion/assets/css/jquery.ambiance.css\" />";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml = (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml+"<script src=\"../static/Resources/Spanish/notificacion/assets/js/jquery.ambiance.js\" type=\"text/javascript\"></script>";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Metaequiv.addItem("Expires", "0", 0) ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Metaequiv.addItem("Last-Modified", "0", 0) ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Metaequiv.addItem("Cache-Control", "no-cache,mustrevalidate", 0) ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Metaequiv.addItem("Pragma", "no-cache", 0) ;
         lblTextohtml_Caption = "<br/>Eje 2 Ote. Tramo Heroica Escuela Naval Militar Núm. 861 Col. Los Cipreses, Del. Coyoacán <br/>";
         AssignProp("", true, lblTextohtml_Internalname, "Caption", lblTextohtml_Caption, true);
         lblTextohtml_Caption = lblTextohtml_Caption+"Ciudad de México CP 04830, Tel. (55) 5624-6500 | 01 800 627 4621<br />";
         AssignProp("", true, lblTextohtml_Internalname, "Caption", lblTextohtml_Caption, true);
         AV7chrome = context.GetImagePath( "2d346c27-64d7-49fc-bd7e-777001b061ff", "", context.GetTheme( ));
         AssignProp("", true, imgavChrome_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV7chrome)) ? AV10Chrome_GXI : context.convertURL( context.PathToRelativeUrl( AV7chrome))), true);
         AssignProp("", true, imgavChrome_Internalname, "SrcSet", context.GetImageSrcSet( AV7chrome), true);
         AV10Chrome_GXI = GXDbFile.PathToUrl( context.GetImagePath( "2d346c27-64d7-49fc-bd7e-777001b061ff", "", context.GetTheme( )));
         AssignProp("", true, imgavChrome_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV7chrome)) ? AV10Chrome_GXI : context.convertURL( context.PathToRelativeUrl( AV7chrome))), true);
         AssignProp("", true, imgavChrome_Internalname, "SrcSet", context.GetImageSrcSet( AV7chrome), true);
         imgavChrome_Link = formatLink("../static/Resources/chrome.exe") ;
         AssignProp("", true, imgavChrome_Internalname, "Link", imgavChrome_Link, true);
      }

      protected void nextLoad( )
      {
      }

      protected void E120X2( )
      {
         /* Load Routine */
      }

      protected void wb_table1_2_0X2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable1_Internalname, tblTable1_Internalname, "", "FondoPrincipal", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center;vertical-align:top;height:100px")+"\" class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection1_Internalname, 1, 0, "px", 0, "px", "CuerpoEncab", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "MPW0006"+"", StringUtil.RTrim( WebComp_Encabezado_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpMPW0006"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.StrCmp(StringUtil.Lower( OldEncabezado), StringUtil.Lower( WebComp_Encabezado_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0006"+"");
               }
               WebComp_Encabezado.componentdraw();
               if ( StringUtil.StrCmp(StringUtil.Lower( OldEncabezado), StringUtil.Lower( WebComp_Encabezado_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr style=\""+CSSHelper.Prettify( "vertical-align:top")+"\">") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center;vertical-align:top")+"\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection2_Internalname, 1, 0, "px", 0, "px", "CuerpoPrincipal", "left", "top", "", "", "div");
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            /* Content placeholder */
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-content-placeholder");
            context.WriteHtmlText( ">") ;
            if ( ! isFullAjaxMode( ) )
            {
               getDataAreaObject().RenderHtmlContent();
            }
            context.WriteHtmlText( "</div>") ;
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection3_Internalname, 1, 0, "px", 0, "px", "CuerpoEncab", "left", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "4cefb16f-9978-46c3-addb-265f66a8c385", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 1, 1, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_MasterPageRegistro.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextohtml_Internalname, lblTextohtml_Caption, "", "", lblTextohtml_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "font-family:'Arial'; font-size:8.0pt; font-weight:bold; font-style:normal;", "TextBlock", 0, "", 1, 1, 1, "HLP_MasterPageRegistro.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection5_Internalname, 1, 0, "px", 0, "px", "CuerpoEncab", "left", "top", "", "", "div");
            wb_table2_15_0X2( true) ;
         }
         else
         {
            wb_table2_15_0X2( false) ;
         }
         return  ;
      }

      protected void wb_table2_15_0X2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblBloqueo_Internalname, "Text Block", "", "", lblBloqueo_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "TextBlock", 0, "", lblBloqueo_Visible, 1, 1, "HLP_MasterPageRegistro.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_2_0X2e( true) ;
         }
         else
         {
            wb_table1_2_0X2e( false) ;
         }
      }

      protected void wb_table2_15_0X2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable2_Internalname, tblTable2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\" colspan=\"4\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "HERRAMIENTAS", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "font-family:'Arial'; font-size:10.0pt; font-weight:bold; font-style:normal;", "TextBlock", 0, "", 1, 1, 0, "HLP_MasterPageRegistro.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"center\" colspan=\"2\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV7chrome_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV7chrome))&&String.IsNullOrEmpty(StringUtil.RTrim( AV10Chrome_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV7chrome)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV7chrome)) ? AV10Chrome_GXI : context.PathToRelativeUrl( AV7chrome));
            GxWebStd.gx_bitmap( context, imgavChrome_Internalname, sImgUrl, imgavChrome_Link, "", "", context.GetTheme( ), 1, 1, "", "Da Click Para Desacargar", 0, 1, 50, "px", 50, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV7chrome_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_MasterPageRegistro.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_15_0X2e( true) ;
         }
         else
         {
            wb_table2_15_0X2e( false) ;
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
         PA0X2( ) ;
         WS0X2( ) ;
         WE0X2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( String sGXDynURL )
      {
      }

      public override void master_styles( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Encabezado == null ) )
         {
            WebComp_Encabezado.componentthemes();
         }
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)(getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Item(idxLst))), "?202262714344735", true, true);
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
         context.AddJavascriptSource("masterpageregistro.js", "?202262714344735", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         divSection1_Internalname = "SECTION1_MPAGE";
         divSection2_Internalname = "SECTION2_MPAGE";
         imgImage1_Internalname = "IMAGE1_MPAGE";
         lblTextohtml_Internalname = "TEXTOHTML_MPAGE";
         divSection3_Internalname = "SECTION3_MPAGE";
         lblTextblock1_Internalname = "TEXTBLOCK1_MPAGE";
         imgavChrome_Internalname = "vCHROME_MPAGE";
         tblTable2_Internalname = "TABLE2_MPAGE";
         divSection5_Internalname = "SECTION5_MPAGE";
         lblBloqueo_Internalname = "BLOQUEO_MPAGE";
         tblTable1_Internalname = "TABLE1_MPAGE";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Internalname = "FORM_MPAGE";
      }

      public override void initialize_properties( )
      {
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         lblBloqueo_Visible = 1;
         imgavChrome_Link = "";
         lblTextohtml_Caption = "textohtml";
         Contholder1.setDataArea(getDataAreaObject());
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override String AjaxOnSessionTimeout( )
      {
         return "Warn" ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH_MPAGE","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH_MPAGE",",oparms:[]}");
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
         Contholder1 = new GXDataAreaControl();
         GXKey = "";
         sPrefix = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         OldEncabezado = "";
         WebComp_Encabezado_Component = "";
         AV7chrome = "";
         AV10Chrome_GXI = "";
         sStyleString = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         lblTextohtml_Jsonclick = "";
         lblBloqueo_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sDynURL = "";
         Form = new GXWebForm();
         WebComp_Encabezado = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         context.Gx_err = 0;
         lblBloqueo_Visible = 0;
      }

      private short initialized ;
      private short GxWebError ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGotPars ;
      private short nGXWrapped ;
      private int lblBloqueo_Visible ;
      private int idxLst ;
      private String lblBloqueo_Internalname ;
      private String GXKey ;
      private String sPrefix ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String OldEncabezado ;
      private String WebComp_Encabezado_Component ;
      private String imgavChrome_Internalname ;
      private String lblTextohtml_Caption ;
      private String lblTextohtml_Internalname ;
      private String imgavChrome_Link ;
      private String sStyleString ;
      private String tblTable1_Internalname ;
      private String divSection1_Internalname ;
      private String divSection2_Internalname ;
      private String divSection3_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String sImgUrl ;
      private String imgImage1_Internalname ;
      private String lblTextohtml_Jsonclick ;
      private String divSection5_Internalname ;
      private String lblBloqueo_Jsonclick ;
      private String tblTable2_Internalname ;
      private String lblTextblock1_Internalname ;
      private String lblTextblock1_Jsonclick ;
      private String sDynURL ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool toggleJsOutput ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV7chrome_IsBlob ;
      private String AV10Chrome_GXI ;
      private String AV7chrome ;
      private GXWebComponent WebComp_Encabezado ;
      private IGxDataStore dsDefault ;
      private GXDataAreaControl Contholder1 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

}
