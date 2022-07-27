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
   public class cambiopwd : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public cambiopwd( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public cambiopwd( IGxContext context )
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("masterpagemikbreg", "GeneXus.Programs.masterpagemikbreg", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
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
         PA0M2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0M2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, false);
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
         context.AddJavascriptSource("gxcfg.js", "?20226271434476", false, true);
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
         context.WriteHtmlText( " "+"class=\"Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cambiopwd.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vUSRLOG", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10UsrLog), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vNOMUSR", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12NomUsr, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vUSRLOG", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10UsrLog), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSRLOG", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10UsrLog), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vNOMUSR", AV12NomUsr);
         GxWebStd.gx_hidden_field( context, "gxhash_vNOMUSR", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12NomUsr, "")), context));
         GxWebStd.gx_hidden_field( context, "vEXISTE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16Existe), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vERROR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13error), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuariosId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "HISTPWDCONSTRA", A110HistPwdConstra);
         GxWebStd.gx_hidden_field( context, "HISTPWDLLAVE", A111HistPwdLlave);
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0M2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0M2( ) ;
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
         return formatLink("cambiopwd.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "CambioPwd" ;
      }

      public override String GetPgmdesc( )
      {
         return "Cambio de Contrseña (Usuario)" ;
      }

      protected void WB0M0( )
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
            wb_table1_2_0M2( true) ;
         }
         else
         {
            wb_table1_2_0M2( false) ;
         }
         return  ;
      }

      protected void wb_table1_2_0M2e( bool wbgen )
      {
         if ( wbgen )
         {
         }
         wbLoad = true;
      }

      protected void START0M2( )
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
            Form.Meta.addItem("description", "Cambio de Contrseña (Usuario)", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0M0( ) ;
      }

      protected void WS0M2( )
      {
         START0M2( ) ;
         EVT0M2( ) ;
      }

      protected void EVT0M2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'ACEPTAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Aceptar' */
                              E110M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E120M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E130M2 ();
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
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0M2( )
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

      protected void PA0M2( )
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
               GX_FocusControl = edtavPwdactual_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         RF0M2( ) ;
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

      protected void RF0M2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E130M2 ();
            WB0M0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0M2( )
      {
         GxWebStd.gx_hidden_field( context, "vUSRLOG", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10UsrLog), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSRLOG", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10UsrLog), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vNOMUSR", AV12NomUsr);
         GxWebStd.gx_hidden_field( context, "gxhash_vNOMUSR", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12NomUsr, "")), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP0M0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E120M2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV5PwdActual = cgiGet( edtavPwdactual_Internalname);
            AssignAttri("", false, "AV5PwdActual", AV5PwdActual);
            AV6PwdNuevo = cgiGet( edtavPwdnuevo_Internalname);
            AssignAttri("", false, "AV6PwdNuevo", AV6PwdNuevo);
            AV7PwdConfirm = cgiGet( edtavPwdconfirm_Internalname);
            AssignAttri("", false, "AV7PwdConfirm", AV7PwdConfirm);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E110M2( )
      {
         /* 'Aceptar' Routine */
         new desencrippwd(context ).execute(  AV10UsrLog, out  AV11PwdTexto) ;
         /* Execute user subroutine: 'PWD' */
         S112 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV5PwdActual, AV11PwdTexto) != 0 )
         {
            GX_msglist.addItem("La contraseña actual no esta correcta, Favor de Verificar.");
         }
         else if ( StringUtil.StrCmp(AV6PwdNuevo, AV12NomUsr) == 0 )
         {
            GX_msglist.addItem("La nueva contraseña no puede ser igual al nombre de usuario");
         }
         else if ( AV16Existe == 1 )
         {
            GX_msglist.addItem("Esta contraseña ya fue utilizada anteriormente, favor de ingresar otra");
         }
         else if ( StringUtil.StrCmp(AV6PwdNuevo, AV7PwdConfirm) != 0 )
         {
            GX_msglist.addItem("La nueva contraseña no coincide con la confirmación. Favor de Verificar");
         }
         else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5PwdActual)) )
         {
            GX_msglist.addItem("El campo de contraseña actual no puede estar vacio");
         }
         else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV6PwdNuevo)) )
         {
            GX_msglist.addItem("El campo de Nueva contraseña no puede estar vacio");
         }
         else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7PwdConfirm)) )
         {
            GX_msglist.addItem("El campo de confirmación de contraseña no puede estar vacio");
         }
         else
         {
            new validacaractpassw(context ).execute(  AV6PwdNuevo, ref  AV13error) ;
            AssignAttri("", false, "AV13error", StringUtil.LTrimStr( (decimal)(AV13error), 2, 0));
            if ( AV13error == 0 )
            {
               new cambiapwd(context ).execute(  AV10UsrLog,  StringUtil.Trim( AV6PwdNuevo),  0) ;
               new grababitacceso(context ).execute(  AV10UsrLog) ;
               CallWebObject(formatLink("inicio.aspx") );
               context.wjLocDisableFrm = 1;
            }
         }
         /*  Sending Event outputs  */
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E120M2 ();
         if (returnInSub) return;
      }

      protected void E120M2( )
      {
         /* Start Routine */
         AV8Usuario = AV9sesion.Get("UsuarioId");
         AV10UsrLog = (int)(NumberUtil.Val( AV8Usuario, "."));
         AssignAttri("", false, "AV10UsrLog", StringUtil.LTrimStr( (decimal)(AV10UsrLog), 6, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSRLOG", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10UsrLog), "ZZZZZ9"), context));
         AV12NomUsr = AV9sesion.Get("Usuario");
         AssignAttri("", false, "AV12NomUsr", AV12NomUsr);
         GxWebStd.gx_hidden_field( context, "gxhash_vNOMUSR", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12NomUsr, "")), context));
         GX_msglist.addItem("Por seguridad, se requiere que cambie su contraseña");
      }

      protected void S112( )
      {
         /* 'PWD' Routine */
         AV16Existe = 0;
         AssignAttri("", false, "AV16Existe", StringUtil.Str( (decimal)(AV16Existe), 1, 0));
         /* Using cursor H000M2 */
         pr_default.execute(0, new Object[] {AV10UsrLog});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11UsuariosId = H000M2_A11UsuariosId[0];
            A111HistPwdLlave = H000M2_A111HistPwdLlave[0];
            A110HistPwdConstra = H000M2_A110HistPwdConstra[0];
            AV15pwd = Decrypt64( StringUtil.Trim( A110HistPwdConstra), StringUtil.Trim( A111HistPwdLlave));
            if ( StringUtil.StrCmp(AV15pwd, AV6PwdNuevo) == 0 )
            {
               AV16Existe = 1;
               AssignAttri("", false, "AV16Existe", StringUtil.Str( (decimal)(AV16Existe), 1, 0));
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void nextLoad( )
      {
      }

      protected void E130M2( )
      {
         /* Load Routine */
      }

      protected void wb_table1_2_0M2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            sStyleString = sStyleString + " height: " + StringUtil.LTrimStr( (decimal)(150), 10, 0) + "px" + ";";
            sStyleString = sStyleString + " width: " + StringUtil.LTrimStr( (decimal)(377), 10, 0) + "px" + ";";
            GxWebStd.gx_table_start( context, tblTable1_Internalname, tblTable1_Internalname, "", "Table", 0, "center", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\" colspan=\"2\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center;height:18px")+"\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "CAMBIO DE CONTRASEÑA.", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "font-family:'Arial'; font-size:14.0pt; font-weight:bold; font-style:normal;", "TextBlock1", 0, "", 1, 1, 0, "HLP_CambioPwd.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\" colspan=\"2\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center;height:16px")+"\">") ;
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td style=\""+CSSHelper.Prettify( "height:23px")+"\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Contraseña Actual:", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "font-family:'Arial'; font-size:9.0pt; font-weight:bold; font-style:normal;", "TextBlock", 0, "", 1, 1, 0, "HLP_CambioPwd.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPwdactual_Internalname, AV5PwdActual, StringUtil.RTrim( context.localUtil.Format( AV5PwdActual, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,13);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPwdactual_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 32, "chr", 1, "row", 32, -1, 0, 0, 1, 0, -1, true, "", "left", true, "", "HLP_CambioPwd.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td style=\""+CSSHelper.Prettify( "height:18px")+"\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Nueva Contraseña:", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "font-family:'Arial'; font-size:9.0pt; font-weight:bold; font-style:normal;", "TextBlock", 0, "", 1, 1, 0, "HLP_CambioPwd.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPwdnuevo_Internalname, AV6PwdNuevo, StringUtil.RTrim( context.localUtil.Format( AV6PwdNuevo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPwdnuevo_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 32, "chr", 1, "row", 32, -1, 0, 0, 1, 0, -1, true, "", "left", true, "", "HLP_CambioPwd.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td style=\""+CSSHelper.Prettify( "height:17px")+"\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Confirmación de la Nueva Contraseña:", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "font-family:'Arial'; font-size:9.0pt; font-weight:bold; font-style:normal;", "TextBlock", 0, "", 1, 1, 0, "HLP_CambioPwd.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPwdconfirm_Internalname, AV7PwdConfirm, StringUtil.RTrim( context.localUtil.Format( AV7PwdConfirm, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPwdconfirm_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 32, "chr", 1, "row", 32, -1, 0, 0, 1, 0, -1, true, "", "left", true, "", "HLP_CambioPwd.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\" colspan=\"2\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttButton1_Internalname, "", "Aceptar", bttButton1_Jsonclick, 5, "Aceptar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'ACEPTAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CambioPwd.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_2_0M2e( true) ;
         }
         else
         {
            wb_table1_2_0M2e( false) ;
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
         PA0M2( ) ;
         WS0M2( ) ;
         WE0M2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202262714344716", true, true);
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
         context.AddJavascriptSource("cambiopwd.js", "?202262714344716", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock9_Internalname = "TEXTBLOCK9";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtavPwdactual_Internalname = "vPWDACTUAL";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtavPwdnuevo_Internalname = "vPWDNUEVO";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtavPwdconfirm_Internalname = "vPWDCONFIRM";
         bttButton1_Internalname = "BUTTON1";
         tblTable1_Internalname = "TABLE1";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavPwdconfirm_Jsonclick = "";
         edtavPwdnuevo_Jsonclick = "";
         edtavPwdactual_Jsonclick = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Cambio de Contrseña (Usuario)";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV10UsrLog',fld:'vUSRLOG',pic:'ZZZZZ9',hsh:true},{av:'AV12NomUsr',fld:'vNOMUSR',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'ACEPTAR'","{handler:'E110M2',iparms:[{av:'AV10UsrLog',fld:'vUSRLOG',pic:'ZZZZZ9',hsh:true},{av:'AV12NomUsr',fld:'vNOMUSR',pic:'',hsh:true},{av:'AV16Existe',fld:'vEXISTE',pic:'9'},{av:'AV5PwdActual',fld:'vPWDACTUAL',pic:''},{av:'AV13error',fld:'vERROR',pic:'Z9'},{av:'AV6PwdNuevo',fld:'vPWDNUEVO',pic:''},{av:'AV7PwdConfirm',fld:'vPWDCONFIRM',pic:''},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'A110HistPwdConstra',fld:'HISTPWDCONSTRA',pic:''},{av:'A111HistPwdLlave',fld:'HISTPWDLLAVE',pic:''}]");
         setEventMetadata("'ACEPTAR'",",oparms:[{av:'AV13error',fld:'vERROR',pic:'Z9'},{av:'AV16Existe',fld:'vEXISTE',pic:'9'}]}");
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
         AV12NomUsr = "";
         GXKey = "";
         A110HistPwdConstra = "";
         A111HistPwdLlave = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5PwdActual = "";
         AV6PwdNuevo = "";
         AV7PwdConfirm = "";
         AV11PwdTexto = "";
         AV8Usuario = "";
         AV9sesion = context.GetSession();
         scmdbuf = "";
         H000M2_A62HisPwdFecha = new DateTime[] {DateTime.MinValue} ;
         H000M2_A11UsuariosId = new int[1] ;
         H000M2_A111HistPwdLlave = new String[] {""} ;
         H000M2_A110HistPwdConstra = new String[] {""} ;
         AV15pwd = "";
         sStyleString = "";
         lblTextblock9_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblTextblock1_Jsonclick = "";
         TempTags = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         bttButton1_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cambiopwd__default(),
            new Object[][] {
                new Object[] {
               H000M2_A62HisPwdFecha, H000M2_A11UsuariosId, H000M2_A111HistPwdLlave, H000M2_A110HistPwdConstra
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV16Existe ;
      private short AV13error ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int AV10UsrLog ;
      private int A11UsuariosId ;
      private int idxLst ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavPwdactual_Internalname ;
      private String edtavPwdnuevo_Internalname ;
      private String edtavPwdconfirm_Internalname ;
      private String AV8Usuario ;
      private String scmdbuf ;
      private String sStyleString ;
      private String tblTable1_Internalname ;
      private String lblTextblock9_Internalname ;
      private String lblTextblock9_Jsonclick ;
      private String ClassString ;
      private String StyleString ;
      private String lblTextblock1_Internalname ;
      private String lblTextblock1_Jsonclick ;
      private String TempTags ;
      private String edtavPwdactual_Jsonclick ;
      private String lblTextblock2_Internalname ;
      private String lblTextblock2_Jsonclick ;
      private String edtavPwdnuevo_Jsonclick ;
      private String lblTextblock3_Internalname ;
      private String lblTextblock3_Jsonclick ;
      private String edtavPwdconfirm_Jsonclick ;
      private String bttButton1_Internalname ;
      private String bttButton1_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private String AV12NomUsr ;
      private String A110HistPwdConstra ;
      private String A111HistPwdLlave ;
      private String AV5PwdActual ;
      private String AV6PwdNuevo ;
      private String AV7PwdConfirm ;
      private String AV11PwdTexto ;
      private String AV15pwd ;
      private IGxSession AV9sesion ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H000M2_A62HisPwdFecha ;
      private int[] H000M2_A11UsuariosId ;
      private String[] H000M2_A111HistPwdLlave ;
      private String[] H000M2_A110HistPwdConstra ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

   public class cambiopwd__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000M2 ;
          prmH000M2 = new Object[] {
          new Object[] {"AV10UsrLog",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H000M2", "SELECT `HisPwdFecha`, `UsuariosId`, `HistPwdLlave`, `HistPwdConstra` FROM `HistPwd` WHERE `UsuariosId` = ? ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000M2,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((String[]) buf[3])[0] = rslt.getVarchar(4) ;
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
                return;
       }
    }

 }

}
