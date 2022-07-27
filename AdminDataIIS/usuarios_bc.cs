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
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class usuarios_bc : GXHttpHandler, IGxSilentTrn
   {
      public usuarios_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public usuarios_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public GXBCCollection<SdtUsuarios> GetAll( int Start ,
                                                 int Count )
      {
         GXPagingFrom9 = Start;
         GXPagingTo9 = ((Count>0) ? Count : 100000000);
         /* Using cursor BC00025 */
         pr_default.execute(3, new Object[] {GXPagingFrom9, GXPagingTo9});
         RcdFound9 = 0;
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound9 = 1;
            A11UsuariosId = BC00025_A11UsuariosId[0];
            n11UsuariosId = BC00025_n11UsuariosId[0];
            A244UsuariosUsr = BC00025_A244UsuariosUsr[0];
            A93UsuariosIP = BC00025_A93UsuariosIP[0];
            A255UsuariosFecNacimiento = BC00025_A255UsuariosFecNacimiento[0];
            A256UsuariosEdad = BC00025_A256UsuariosEdad[0];
            A105UsuariosCurp = BC00025_A105UsuariosCurp[0];
            A66UsuariosNombre = BC00025_A66UsuariosNombre[0];
            A65UsuariosApPat = BC00025_A65UsuariosApPat[0];
            A64UsuariosApMat = BC00025_A64UsuariosApMat[0];
            A272UsuariosTipo = BC00025_A272UsuariosTipo[0];
            A40000UsuariosIcono_GXI = BC00025_A40000UsuariosIcono_GXI[0];
            A257UsuariosSexo = BC00025_A257UsuariosSexo[0];
            A68UsuariosPwd = BC00025_A68UsuariosPwd[0];
            A67UsuariosKey = BC00025_A67UsuariosKey[0];
            A96UsuariosVigIni = BC00025_A96UsuariosVigIni[0];
            A70UsuariosVigFin = BC00025_A70UsuariosVigFin[0];
            n70UsuariosVigFin = BC00025_n70UsuariosVigFin[0];
            A92UsuariosFecCap = BC00025_A92UsuariosFecCap[0];
            A260UsuariosTelef = BC00025_A260UsuariosTelef[0];
            A261UsuariosCorreo = BC00025_A261UsuariosCorreo[0];
            A127RolNombre = BC00025_A127RolNombre[0];
            A286UsuariosStatus = BC00025_A286UsuariosStatus[0];
            A24RolId = BC00025_A24RolId[0];
            A245UsuariosIcono = BC00025_A245UsuariosIcono[0];
         }
         bcUsuarios = new SdtUsuarios(context);
         gx_restcollection.Clear();
         while ( RcdFound9 != 0 )
         {
            OnLoadActions029( ) ;
            AddRow029( ) ;
            gx_sdt_item = (SdtUsuarios)(bcUsuarios.Clone());
            gx_restcollection.Add(gx_sdt_item, 0);
            pr_default.readNext(3);
            RcdFound9 = 0;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            if ( (pr_default.getStatus(3) != 101) )
            {
               RcdFound9 = 1;
               A11UsuariosId = BC00025_A11UsuariosId[0];
               n11UsuariosId = BC00025_n11UsuariosId[0];
               A244UsuariosUsr = BC00025_A244UsuariosUsr[0];
               A93UsuariosIP = BC00025_A93UsuariosIP[0];
               A255UsuariosFecNacimiento = BC00025_A255UsuariosFecNacimiento[0];
               A256UsuariosEdad = BC00025_A256UsuariosEdad[0];
               A105UsuariosCurp = BC00025_A105UsuariosCurp[0];
               A66UsuariosNombre = BC00025_A66UsuariosNombre[0];
               A65UsuariosApPat = BC00025_A65UsuariosApPat[0];
               A64UsuariosApMat = BC00025_A64UsuariosApMat[0];
               A272UsuariosTipo = BC00025_A272UsuariosTipo[0];
               A40000UsuariosIcono_GXI = BC00025_A40000UsuariosIcono_GXI[0];
               A257UsuariosSexo = BC00025_A257UsuariosSexo[0];
               A68UsuariosPwd = BC00025_A68UsuariosPwd[0];
               A67UsuariosKey = BC00025_A67UsuariosKey[0];
               A96UsuariosVigIni = BC00025_A96UsuariosVigIni[0];
               A70UsuariosVigFin = BC00025_A70UsuariosVigFin[0];
               n70UsuariosVigFin = BC00025_n70UsuariosVigFin[0];
               A92UsuariosFecCap = BC00025_A92UsuariosFecCap[0];
               A260UsuariosTelef = BC00025_A260UsuariosTelef[0];
               A261UsuariosCorreo = BC00025_A261UsuariosCorreo[0];
               A127RolNombre = BC00025_A127RolNombre[0];
               A286UsuariosStatus = BC00025_A286UsuariosStatus[0];
               A24RolId = BC00025_A24RolId[0];
               A245UsuariosIcono = BC00025_A245UsuariosIcono[0];
            }
            Gx_mode = sMode9;
         }
         pr_default.close(3);
         /* Load Subordinate Levels */
         return gx_restcollection ;
      }

      protected void SETSEUDOVARS( )
      {
         ZM029( 0) ;
      }

      public void GetInsDefault( )
      {
         ReadRow029( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey029( ) ;
         standaloneModal( ) ;
         AddRow029( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E11022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z11UsuariosId = A11UsuariosId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override String ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_020( )
      {
         BeforeValidate029( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls029( ) ;
            }
            else
            {
               CheckExtendedTable029( ) ;
               if ( AnyError == 0 )
               {
                  ZM029( 28) ;
               }
               CloseExtendedTableCursors029( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12022( )
      {
         /* Start Routine */
         AV35usuario = AV30Sesion.Get("UsuarioId");
         AV34UsrLog = (int)(NumberUtil.Val( AV35usuario, "."));
      }

      protected void E11022( )
      {
         /* After Trn Routine */
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            new creallavepwd(context ).execute(  A11UsuariosId,  A68UsuariosPwd,  A244UsuariosUsr,  AV34UsrLog,  AV7adscId,  AV10comision) ;
            GXt_int1 = AV29SecRnd;
            new insertsec(context ).execute( ref  A11UsuariosId, ref  GXt_int1) ;
            AV29SecRnd = (int)(GXt_int1);
            if ( (0==AV34UsrLog) )
            {
               GX_msglist.addItem("El usuarioId esta vacio");
            }
            else
            {
            }
         }
      }

      protected void E13022( )
      {
         /* 'Retorno' Routine */
         CallWebObject(formatLink("acceso.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void ZM029( short GX_JID )
      {
         if ( ( GX_JID == 27 ) || ( GX_JID == 0 ) )
         {
            Z244UsuariosUsr = A244UsuariosUsr;
            Z93UsuariosIP = A93UsuariosIP;
            Z255UsuariosFecNacimiento = A255UsuariosFecNacimiento;
            Z256UsuariosEdad = A256UsuariosEdad;
            Z105UsuariosCurp = A105UsuariosCurp;
            Z66UsuariosNombre = A66UsuariosNombre;
            Z65UsuariosApPat = A65UsuariosApPat;
            Z64UsuariosApMat = A64UsuariosApMat;
            Z272UsuariosTipo = A272UsuariosTipo;
            Z257UsuariosSexo = A257UsuariosSexo;
            Z68UsuariosPwd = A68UsuariosPwd;
            Z67UsuariosKey = A67UsuariosKey;
            Z96UsuariosVigIni = A96UsuariosVigIni;
            Z70UsuariosVigFin = A70UsuariosVigFin;
            Z92UsuariosFecCap = A92UsuariosFecCap;
            Z260UsuariosTelef = A260UsuariosTelef;
            Z261UsuariosCorreo = A261UsuariosCorreo;
            Z286UsuariosStatus = A286UsuariosStatus;
            Z24RolId = A24RolId;
            Z97UsuariosNomCompleto = A97UsuariosNomCompleto;
            Z275UsuariosSexoFor = A275UsuariosSexoFor;
         }
         if ( ( GX_JID == 28 ) || ( GX_JID == 0 ) )
         {
            Z127RolNombre = A127RolNombre;
            Z97UsuariosNomCompleto = A97UsuariosNomCompleto;
            Z275UsuariosSexoFor = A275UsuariosSexoFor;
         }
         if ( GX_JID == -27 )
         {
            Z11UsuariosId = A11UsuariosId;
            Z244UsuariosUsr = A244UsuariosUsr;
            Z93UsuariosIP = A93UsuariosIP;
            Z255UsuariosFecNacimiento = A255UsuariosFecNacimiento;
            Z256UsuariosEdad = A256UsuariosEdad;
            Z105UsuariosCurp = A105UsuariosCurp;
            Z66UsuariosNombre = A66UsuariosNombre;
            Z65UsuariosApPat = A65UsuariosApPat;
            Z64UsuariosApMat = A64UsuariosApMat;
            Z272UsuariosTipo = A272UsuariosTipo;
            Z245UsuariosIcono = A245UsuariosIcono;
            Z40000UsuariosIcono_GXI = A40000UsuariosIcono_GXI;
            Z257UsuariosSexo = A257UsuariosSexo;
            Z68UsuariosPwd = A68UsuariosPwd;
            Z67UsuariosKey = A67UsuariosKey;
            Z96UsuariosVigIni = A96UsuariosVigIni;
            Z70UsuariosVigFin = A70UsuariosVigFin;
            Z92UsuariosFecCap = A92UsuariosFecCap;
            Z260UsuariosTelef = A260UsuariosTelef;
            Z261UsuariosCorreo = A261UsuariosCorreo;
            Z286UsuariosStatus = A286UsuariosStatus;
            Z24RolId = A24RolId;
            Z127RolNombre = A127RolNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         Gx_date = DateTimeUtil.Today( context);
      }

      protected void standaloneModal( )
      {
         A93UsuariosIP = context.GetRemoteAddress( );
         if ( IsIns( )  && (DateTime.MinValue==A96UsuariosVigIni) && ( Gx_BScreen == 0 ) )
         {
            A96UsuariosVigIni = Gx_date;
         }
         if ( IsIns( )  && (DateTime.MinValue==A70UsuariosVigFin) && ( Gx_BScreen == 0 ) )
         {
            A70UsuariosVigFin = DateTimeUtil.DAdd(Gx_date,+((int)(365)));
            n70UsuariosVigFin = false;
         }
         if ( IsIns( )  && (DateTime.MinValue==A92UsuariosFecCap) && ( Gx_BScreen == 0 ) )
         {
            A92UsuariosFecCap = DateTimeUtil.ServerNow( context, pr_default);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load029( )
      {
         /* Using cursor BC00026 */
         pr_default.execute(4, new Object[] {n11UsuariosId, A11UsuariosId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound9 = 1;
            A244UsuariosUsr = BC00026_A244UsuariosUsr[0];
            A93UsuariosIP = BC00026_A93UsuariosIP[0];
            A255UsuariosFecNacimiento = BC00026_A255UsuariosFecNacimiento[0];
            A256UsuariosEdad = BC00026_A256UsuariosEdad[0];
            A105UsuariosCurp = BC00026_A105UsuariosCurp[0];
            A66UsuariosNombre = BC00026_A66UsuariosNombre[0];
            A65UsuariosApPat = BC00026_A65UsuariosApPat[0];
            A64UsuariosApMat = BC00026_A64UsuariosApMat[0];
            A272UsuariosTipo = BC00026_A272UsuariosTipo[0];
            A40000UsuariosIcono_GXI = BC00026_A40000UsuariosIcono_GXI[0];
            A257UsuariosSexo = BC00026_A257UsuariosSexo[0];
            A68UsuariosPwd = BC00026_A68UsuariosPwd[0];
            A67UsuariosKey = BC00026_A67UsuariosKey[0];
            A96UsuariosVigIni = BC00026_A96UsuariosVigIni[0];
            A70UsuariosVigFin = BC00026_A70UsuariosVigFin[0];
            n70UsuariosVigFin = BC00026_n70UsuariosVigFin[0];
            A92UsuariosFecCap = BC00026_A92UsuariosFecCap[0];
            A260UsuariosTelef = BC00026_A260UsuariosTelef[0];
            A261UsuariosCorreo = BC00026_A261UsuariosCorreo[0];
            A127RolNombre = BC00026_A127RolNombre[0];
            A286UsuariosStatus = BC00026_A286UsuariosStatus[0];
            A24RolId = BC00026_A24RolId[0];
            A245UsuariosIcono = BC00026_A245UsuariosIcono[0];
            ZM029( -27) ;
         }
         pr_default.close(4);
         OnLoadActions029( ) ;
      }

      protected void OnLoadActions029( )
      {
         GXt_char2 = AV56UsuariosCurpAnt;
         new pr_recuperacurp(context ).execute(  A11UsuariosId, out  GXt_char2) ;
         AV56UsuariosCurpAnt = GXt_char2;
         GXt_int3 = AV53error1;
         new pr_buscacurp(context ).execute(  A105UsuariosCurp,  AV56UsuariosCurpAnt,  Gx_mode, out  GXt_int3) ;
         AV53error1 = GXt_int3;
         A244UsuariosUsr = A105UsuariosCurp;
         GXt_date4 = A255UsuariosFecNacimiento;
         new pr_recfecha(context ).execute(  A105UsuariosCurp, out  GXt_date4) ;
         A255UsuariosFecNacimiento = GXt_date4;
         GXt_int3 = A256UsuariosEdad;
         new pr_recedad(context ).execute(  A105UsuariosCurp, out  GXt_int3) ;
         A256UsuariosEdad = GXt_int3;
         A97UsuariosNomCompleto = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + StringUtil.Trim( A64UsuariosApMat);
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A257UsuariosSexo)) && ( Gx_BScreen == 0 ) )
         {
            A257UsuariosSexo = StringUtil.Substring( A105UsuariosCurp, 11, 1);
         }
         if ( StringUtil.StrCmp(A257UsuariosSexo, "H") == 0 )
         {
            A275UsuariosSexoFor = "Hombres";
         }
         else
         {
            if ( StringUtil.StrCmp(A257UsuariosSexo, "M") == 0 )
            {
               A275UsuariosSexoFor = "Mujeres";
            }
            else
            {
               A275UsuariosSexoFor = "";
            }
         }
      }

      protected void CheckExtendedTable029( )
      {
         nIsDirty_9 = 0;
         standaloneModal( ) ;
         GXt_char2 = AV56UsuariosCurpAnt;
         new pr_recuperacurp(context ).execute(  A11UsuariosId, out  GXt_char2) ;
         AV56UsuariosCurpAnt = GXt_char2;
         GXt_int3 = AV53error1;
         new pr_buscacurp(context ).execute(  A105UsuariosCurp,  AV56UsuariosCurpAnt,  Gx_mode, out  GXt_int3) ;
         AV53error1 = GXt_int3;
         if ( AV53error1 == 1 )
         {
            GX_msglist.addItem("Ya existe la CURP ingresada.  Favor de verificar. !", 1, "");
            AnyError = 1;
         }
         nIsDirty_9 = 1;
         A244UsuariosUsr = A105UsuariosCurp;
         nIsDirty_9 = 1;
         GXt_date4 = A255UsuariosFecNacimiento;
         new pr_recfecha(context ).execute(  A105UsuariosCurp, out  GXt_date4) ;
         A255UsuariosFecNacimiento = GXt_date4;
         nIsDirty_9 = 1;
         GXt_int3 = A256UsuariosEdad;
         new pr_recedad(context ).execute(  A105UsuariosCurp, out  GXt_int3) ;
         A256UsuariosEdad = GXt_int3;
         if ( ! (GxRegex.IsMatch(A105UsuariosCurp,"\\b[A-Z]{4}[0-9]{6}[A-Z]{6}[0-Z]{2}\\b")) )
         {
            GX_msglist.addItem("CURP incorrecta,  Favor de verificar!", 1, "");
            AnyError = 1;
         }
         nIsDirty_9 = 1;
         A97UsuariosNomCompleto = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + StringUtil.Trim( A64UsuariosApMat);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A66UsuariosNombre)) )
         {
            GX_msglist.addItem("El nombre no puede ir vacio, Favor de verificar!", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A65UsuariosApPat)) )
         {
            GX_msglist.addItem("El primer apellido no puede ir vacio,  Favor de verificar!", 1, "");
            AnyError = 1;
         }
         if ( (0==A272UsuariosTipo) )
         {
            GX_msglist.addItem("El tipo de usuario no puede ir vacio,  Favor de verificar!", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A255UsuariosFecNacimiento) || ( A255UsuariosFecNacimiento >= context.localUtil.YMDToD( 1000, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Nacimiento fuera de rango", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A96UsuariosVigIni) || ( A96UsuariosVigIni >= context.localUtil.YMDToD( 1000, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Fecha de inicio de acceso fuera de rango", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A70UsuariosVigFin) || ( A70UsuariosVigFin >= context.localUtil.YMDToD( 1000, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Fecha de cierre del permiso del usuario fuera de rango", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A92UsuariosFecCap) || ( A92UsuariosFecCap >= context.localUtil.YMDHMSToT( 1000, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha de Captura fuera de rango", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! (GxRegex.IsMatch(A260UsuariosTelef,"\\b[0-9]{10}\\b")) )
         {
            GX_msglist.addItem("Telefono incorrecto, Favor de verificar!", 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A261UsuariosCorreo,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("El valor de Correo electrónico no coincide con el patrón especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A261UsuariosCorreo)) )
         {
            GX_msglist.addItem("El correo no puede ir vacio,  Favor de verificar!", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00024 */
         pr_default.execute(2, new Object[] {A24RolId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Roles'.", "ForeignKeyNotFound", 1, "ROLID");
            AnyError = 1;
         }
         A127RolNombre = BC00024_A127RolNombre[0];
         pr_default.close(2);
         if ( ! ( ( A286UsuariosStatus == 1 ) || ( A286UsuariosStatus == 0 ) ) )
         {
            GX_msglist.addItem("Campo Usuarios Status fuera de rango", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A257UsuariosSexo)) && ( Gx_BScreen == 0 ) )
         {
            nIsDirty_9 = 1;
            A257UsuariosSexo = StringUtil.Substring( A105UsuariosCurp, 11, 1);
         }
         if ( StringUtil.StrCmp(A257UsuariosSexo, "H") == 0 )
         {
            nIsDirty_9 = 1;
            A275UsuariosSexoFor = "Hombres";
         }
         else
         {
            if ( StringUtil.StrCmp(A257UsuariosSexo, "M") == 0 )
            {
               nIsDirty_9 = 1;
               A275UsuariosSexoFor = "Mujeres";
            }
            else
            {
               nIsDirty_9 = 1;
               A275UsuariosSexoFor = "";
            }
         }
      }

      protected void CloseExtendedTableCursors029( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey029( )
      {
         /* Using cursor BC00027 */
         pr_default.execute(5, new Object[] {n11UsuariosId, A11UsuariosId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00023 */
         pr_default.execute(1, new Object[] {n11UsuariosId, A11UsuariosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM029( 27) ;
            RcdFound9 = 1;
            A11UsuariosId = BC00023_A11UsuariosId[0];
            n11UsuariosId = BC00023_n11UsuariosId[0];
            A244UsuariosUsr = BC00023_A244UsuariosUsr[0];
            A93UsuariosIP = BC00023_A93UsuariosIP[0];
            A255UsuariosFecNacimiento = BC00023_A255UsuariosFecNacimiento[0];
            A256UsuariosEdad = BC00023_A256UsuariosEdad[0];
            A105UsuariosCurp = BC00023_A105UsuariosCurp[0];
            A66UsuariosNombre = BC00023_A66UsuariosNombre[0];
            A65UsuariosApPat = BC00023_A65UsuariosApPat[0];
            A64UsuariosApMat = BC00023_A64UsuariosApMat[0];
            A272UsuariosTipo = BC00023_A272UsuariosTipo[0];
            A40000UsuariosIcono_GXI = BC00023_A40000UsuariosIcono_GXI[0];
            A257UsuariosSexo = BC00023_A257UsuariosSexo[0];
            A68UsuariosPwd = BC00023_A68UsuariosPwd[0];
            A67UsuariosKey = BC00023_A67UsuariosKey[0];
            A96UsuariosVigIni = BC00023_A96UsuariosVigIni[0];
            A70UsuariosVigFin = BC00023_A70UsuariosVigFin[0];
            n70UsuariosVigFin = BC00023_n70UsuariosVigFin[0];
            A92UsuariosFecCap = BC00023_A92UsuariosFecCap[0];
            A260UsuariosTelef = BC00023_A260UsuariosTelef[0];
            A261UsuariosCorreo = BC00023_A261UsuariosCorreo[0];
            A286UsuariosStatus = BC00023_A286UsuariosStatus[0];
            A24RolId = BC00023_A24RolId[0];
            A245UsuariosIcono = BC00023_A245UsuariosIcono[0];
            Z11UsuariosId = A11UsuariosId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load029( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey029( ) ;
            }
            Gx_mode = sMode9;
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey029( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode9;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey029( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_020( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency029( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00022 */
            pr_default.execute(0, new Object[] {n11UsuariosId, A11UsuariosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Usuarios"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z244UsuariosUsr, BC00022_A244UsuariosUsr[0]) != 0 ) || ( StringUtil.StrCmp(Z93UsuariosIP, BC00022_A93UsuariosIP[0]) != 0 ) || ( Z255UsuariosFecNacimiento != BC00022_A255UsuariosFecNacimiento[0] ) || ( Z256UsuariosEdad != BC00022_A256UsuariosEdad[0] ) || ( StringUtil.StrCmp(Z105UsuariosCurp, BC00022_A105UsuariosCurp[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z66UsuariosNombre, BC00022_A66UsuariosNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z65UsuariosApPat, BC00022_A65UsuariosApPat[0]) != 0 ) || ( StringUtil.StrCmp(Z64UsuariosApMat, BC00022_A64UsuariosApMat[0]) != 0 ) || ( Z272UsuariosTipo != BC00022_A272UsuariosTipo[0] ) || ( StringUtil.StrCmp(Z257UsuariosSexo, BC00022_A257UsuariosSexo[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z68UsuariosPwd, BC00022_A68UsuariosPwd[0]) != 0 ) || ( StringUtil.StrCmp(Z67UsuariosKey, BC00022_A67UsuariosKey[0]) != 0 ) || ( Z96UsuariosVigIni != BC00022_A96UsuariosVigIni[0] ) || ( Z70UsuariosVigFin != BC00022_A70UsuariosVigFin[0] ) || ( Z92UsuariosFecCap != BC00022_A92UsuariosFecCap[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z260UsuariosTelef, BC00022_A260UsuariosTelef[0]) != 0 ) || ( StringUtil.StrCmp(Z261UsuariosCorreo, BC00022_A261UsuariosCorreo[0]) != 0 ) || ( Z286UsuariosStatus != BC00022_A286UsuariosStatus[0] ) || ( Z24RolId != BC00022_A24RolId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Usuarios"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert029( )
      {
         BeforeValidate029( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable029( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM029( 0) ;
            CheckOptimisticConcurrency029( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm029( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert029( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00028 */
                     pr_default.execute(6, new Object[] {n11UsuariosId, A11UsuariosId, A244UsuariosUsr, A93UsuariosIP, A255UsuariosFecNacimiento, A256UsuariosEdad, A105UsuariosCurp, A66UsuariosNombre, A65UsuariosApPat, A64UsuariosApMat, A272UsuariosTipo, A245UsuariosIcono, A40000UsuariosIcono_GXI, A257UsuariosSexo, A68UsuariosPwd, A67UsuariosKey, A96UsuariosVigIni, n70UsuariosVigFin, A70UsuariosVigFin, A92UsuariosFecCap, A260UsuariosTelef, A261UsuariosCorreo, A286UsuariosStatus, A24RolId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Usuarios") ;
                     if ( (pr_default.getStatus(6) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load029( ) ;
            }
            EndLevel029( ) ;
         }
         CloseExtendedTableCursors029( ) ;
      }

      protected void Update029( )
      {
         BeforeValidate029( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable029( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency029( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm029( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate029( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00029 */
                     pr_default.execute(7, new Object[] {A244UsuariosUsr, A93UsuariosIP, A255UsuariosFecNacimiento, A256UsuariosEdad, A105UsuariosCurp, A66UsuariosNombre, A65UsuariosApPat, A64UsuariosApMat, A272UsuariosTipo, A257UsuariosSexo, A68UsuariosPwd, A67UsuariosKey, A96UsuariosVigIni, n70UsuariosVigFin, A70UsuariosVigFin, A92UsuariosFecCap, A260UsuariosTelef, A261UsuariosCorreo, A286UsuariosStatus, A24RolId, n11UsuariosId, A11UsuariosId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("Usuarios") ;
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Usuarios"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate029( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel029( ) ;
         }
         CloseExtendedTableCursors029( ) ;
      }

      protected void DeferredUpdate029( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000210 */
            pr_default.execute(8, new Object[] {A245UsuariosIcono, A40000UsuariosIcono_GXI, n11UsuariosId, A11UsuariosId});
            pr_default.close(8);
            dsDefault.SmartCacheProvider.SetUpdated("Usuarios") ;
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate029( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency029( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls029( ) ;
            AfterConfirm029( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete029( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000211 */
                  pr_default.execute(9, new Object[] {n11UsuariosId, A11UsuariosId});
                  pr_default.close(9);
                  dsDefault.SmartCacheProvider.SetUpdated("Usuarios") ;
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel029( ) ;
         Gx_mode = sMode9;
      }

      protected void OnDeleteControls029( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_char2 = AV56UsuariosCurpAnt;
            new pr_recuperacurp(context ).execute(  A11UsuariosId, out  GXt_char2) ;
            AV56UsuariosCurpAnt = GXt_char2;
            GXt_int3 = AV53error1;
            new pr_buscacurp(context ).execute(  A105UsuariosCurp,  AV56UsuariosCurpAnt,  Gx_mode, out  GXt_int3) ;
            AV53error1 = GXt_int3;
            A97UsuariosNomCompleto = StringUtil.Trim( A66UsuariosNombre) + " " + StringUtil.Trim( A65UsuariosApPat) + " " + StringUtil.Trim( A64UsuariosApMat);
            if ( StringUtil.StrCmp(A257UsuariosSexo, "H") == 0 )
            {
               A275UsuariosSexoFor = "Hombres";
            }
            else
            {
               if ( StringUtil.StrCmp(A257UsuariosSexo, "M") == 0 )
               {
                  A275UsuariosSexoFor = "Mujeres";
               }
               else
               {
                  A275UsuariosSexoFor = "";
               }
            }
            /* Using cursor BC000212 */
            pr_default.execute(10, new Object[] {A24RolId});
            A127RolNombre = BC000212_A127RolNombre[0];
            pr_default.close(10);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000213 */
            pr_default.execute(11, new Object[] {n11UsuariosId, A11UsuariosId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"bitAcces"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC000214 */
            pr_default.execute(12, new Object[] {n11UsuariosId, A11UsuariosId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"VacantesUsuariosVacante"+" ("+"SUBT_Reclutador"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC000215 */
            pr_default.execute(13, new Object[] {n11UsuariosId, A11UsuariosId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"VacantesUsuariosVacante"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor BC000216 */
            pr_default.execute(14, new Object[] {n11UsuariosId, A11UsuariosId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios Perfil"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor BC000217 */
            pr_default.execute(15, new Object[] {n11UsuariosId, A11UsuariosId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Intentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor BC000218 */
            pr_default.execute(16, new Object[] {n11UsuariosId, A11UsuariosId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Historico de Contrasenas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void EndLevel029( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete029( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart029( )
      {
         /* Scan By routine */
         /* Using cursor BC000219 */
         pr_default.execute(17, new Object[] {n11UsuariosId, A11UsuariosId});
         RcdFound9 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound9 = 1;
            A11UsuariosId = BC000219_A11UsuariosId[0];
            n11UsuariosId = BC000219_n11UsuariosId[0];
            A244UsuariosUsr = BC000219_A244UsuariosUsr[0];
            A93UsuariosIP = BC000219_A93UsuariosIP[0];
            A255UsuariosFecNacimiento = BC000219_A255UsuariosFecNacimiento[0];
            A256UsuariosEdad = BC000219_A256UsuariosEdad[0];
            A105UsuariosCurp = BC000219_A105UsuariosCurp[0];
            A66UsuariosNombre = BC000219_A66UsuariosNombre[0];
            A65UsuariosApPat = BC000219_A65UsuariosApPat[0];
            A64UsuariosApMat = BC000219_A64UsuariosApMat[0];
            A272UsuariosTipo = BC000219_A272UsuariosTipo[0];
            A40000UsuariosIcono_GXI = BC000219_A40000UsuariosIcono_GXI[0];
            A257UsuariosSexo = BC000219_A257UsuariosSexo[0];
            A68UsuariosPwd = BC000219_A68UsuariosPwd[0];
            A67UsuariosKey = BC000219_A67UsuariosKey[0];
            A96UsuariosVigIni = BC000219_A96UsuariosVigIni[0];
            A70UsuariosVigFin = BC000219_A70UsuariosVigFin[0];
            n70UsuariosVigFin = BC000219_n70UsuariosVigFin[0];
            A92UsuariosFecCap = BC000219_A92UsuariosFecCap[0];
            A260UsuariosTelef = BC000219_A260UsuariosTelef[0];
            A261UsuariosCorreo = BC000219_A261UsuariosCorreo[0];
            A127RolNombre = BC000219_A127RolNombre[0];
            A286UsuariosStatus = BC000219_A286UsuariosStatus[0];
            A24RolId = BC000219_A24RolId[0];
            A245UsuariosIcono = BC000219_A245UsuariosIcono[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext029( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound9 = 0;
         ScanKeyLoad029( ) ;
      }

      protected void ScanKeyLoad029( )
      {
         sMode9 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound9 = 1;
            A11UsuariosId = BC000219_A11UsuariosId[0];
            n11UsuariosId = BC000219_n11UsuariosId[0];
            A244UsuariosUsr = BC000219_A244UsuariosUsr[0];
            A93UsuariosIP = BC000219_A93UsuariosIP[0];
            A255UsuariosFecNacimiento = BC000219_A255UsuariosFecNacimiento[0];
            A256UsuariosEdad = BC000219_A256UsuariosEdad[0];
            A105UsuariosCurp = BC000219_A105UsuariosCurp[0];
            A66UsuariosNombre = BC000219_A66UsuariosNombre[0];
            A65UsuariosApPat = BC000219_A65UsuariosApPat[0];
            A64UsuariosApMat = BC000219_A64UsuariosApMat[0];
            A272UsuariosTipo = BC000219_A272UsuariosTipo[0];
            A40000UsuariosIcono_GXI = BC000219_A40000UsuariosIcono_GXI[0];
            A257UsuariosSexo = BC000219_A257UsuariosSexo[0];
            A68UsuariosPwd = BC000219_A68UsuariosPwd[0];
            A67UsuariosKey = BC000219_A67UsuariosKey[0];
            A96UsuariosVigIni = BC000219_A96UsuariosVigIni[0];
            A70UsuariosVigFin = BC000219_A70UsuariosVigFin[0];
            n70UsuariosVigFin = BC000219_n70UsuariosVigFin[0];
            A92UsuariosFecCap = BC000219_A92UsuariosFecCap[0];
            A260UsuariosTelef = BC000219_A260UsuariosTelef[0];
            A261UsuariosCorreo = BC000219_A261UsuariosCorreo[0];
            A127RolNombre = BC000219_A127RolNombre[0];
            A286UsuariosStatus = BC000219_A286UsuariosStatus[0];
            A24RolId = BC000219_A24RolId[0];
            A245UsuariosIcono = BC000219_A245UsuariosIcono[0];
         }
         Gx_mode = sMode9;
      }

      protected void ScanKeyEnd029( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm029( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert029( )
      {
         /* Before Insert Rules */
         GXt_int1 = A11UsuariosId;
         new pnumerar(context ).execute(  "Usr", out  GXt_int1) ;
         A11UsuariosId = (int)(GXt_int1);
         n11UsuariosId = false;
      }

      protected void BeforeUpdate029( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete029( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete029( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate029( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes029( )
      {
      }

      protected void send_integrity_lvl_hashes029( )
      {
      }

      protected void AddRow029( )
      {
         VarsToRow9( bcUsuarios) ;
      }

      protected void ReadRow029( )
      {
         RowToVars9( bcUsuarios, 1) ;
      }

      protected void InitializeNonKey029( )
      {
         AV56UsuariosCurpAnt = "";
         A244UsuariosUsr = "";
         A93UsuariosIP = "";
         A255UsuariosFecNacimiento = DateTime.MinValue;
         A256UsuariosEdad = 0;
         A275UsuariosSexoFor = "";
         A97UsuariosNomCompleto = "";
         A105UsuariosCurp = "";
         A66UsuariosNombre = "";
         A65UsuariosApPat = "";
         A64UsuariosApMat = "";
         A272UsuariosTipo = 0;
         A245UsuariosIcono = "";
         A40000UsuariosIcono_GXI = "";
         A68UsuariosPwd = "";
         A67UsuariosKey = "";
         A260UsuariosTelef = "";
         A261UsuariosCorreo = "";
         A24RolId = 0;
         A127RolNombre = "";
         A286UsuariosStatus = 0;
         AV53error1 = 0;
         A257UsuariosSexo = StringUtil.Substring( A105UsuariosCurp, 11, 1);
         A96UsuariosVigIni = Gx_date;
         A70UsuariosVigFin = DateTimeUtil.DAdd(Gx_date,+((int)(365)));
         n70UsuariosVigFin = false;
         A92UsuariosFecCap = DateTimeUtil.ServerNow( context, pr_default);
         Z244UsuariosUsr = "";
         Z93UsuariosIP = "";
         Z255UsuariosFecNacimiento = DateTime.MinValue;
         Z256UsuariosEdad = 0;
         Z105UsuariosCurp = "";
         Z66UsuariosNombre = "";
         Z65UsuariosApPat = "";
         Z64UsuariosApMat = "";
         Z272UsuariosTipo = 0;
         Z257UsuariosSexo = "";
         Z68UsuariosPwd = "";
         Z67UsuariosKey = "";
         Z96UsuariosVigIni = DateTime.MinValue;
         Z70UsuariosVigFin = DateTime.MinValue;
         Z92UsuariosFecCap = (DateTime)(DateTime.MinValue);
         Z260UsuariosTelef = "";
         Z261UsuariosCorreo = "";
         Z286UsuariosStatus = 0;
         Z24RolId = 0;
      }

      protected void InitAll029( )
      {
         A11UsuariosId = 0;
         n11UsuariosId = false;
         InitializeNonKey029( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A93UsuariosIP = i93UsuariosIP;
         A96UsuariosVigIni = i96UsuariosVigIni;
         A70UsuariosVigFin = i70UsuariosVigFin;
         n70UsuariosVigFin = false;
         A92UsuariosFecCap = i92UsuariosFecCap;
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow9( SdtUsuarios obj9 )
      {
         obj9.gxTpr_Mode = Gx_mode;
         obj9.gxTpr_Usuariosusr = A244UsuariosUsr;
         obj9.gxTpr_Usuariosip = A93UsuariosIP;
         obj9.gxTpr_Usuariosfecnacimiento = A255UsuariosFecNacimiento;
         obj9.gxTpr_Usuariosedad = A256UsuariosEdad;
         obj9.gxTpr_Usuariossexofor = A275UsuariosSexoFor;
         obj9.gxTpr_Usuariosnomcompleto = A97UsuariosNomCompleto;
         obj9.gxTpr_Usuarioscurp = A105UsuariosCurp;
         obj9.gxTpr_Usuariosnombre = A66UsuariosNombre;
         obj9.gxTpr_Usuariosappat = A65UsuariosApPat;
         obj9.gxTpr_Usuariosapmat = A64UsuariosApMat;
         obj9.gxTpr_Usuariostipo = A272UsuariosTipo;
         obj9.gxTpr_Usuariosicono = A245UsuariosIcono;
         obj9.gxTpr_Usuariosicono_gxi = A40000UsuariosIcono_GXI;
         obj9.gxTpr_Usuariospwd = A68UsuariosPwd;
         obj9.gxTpr_Usuarioskey = A67UsuariosKey;
         obj9.gxTpr_Usuariostelef = A260UsuariosTelef;
         obj9.gxTpr_Usuarioscorreo = A261UsuariosCorreo;
         obj9.gxTpr_Rolid = A24RolId;
         obj9.gxTpr_Rolnombre = A127RolNombre;
         obj9.gxTpr_Usuariosstatus = A286UsuariosStatus;
         obj9.gxTpr_Usuariossexo = A257UsuariosSexo;
         obj9.gxTpr_Usuariosvigini = A96UsuariosVigIni;
         obj9.gxTpr_Usuariosvigfin = A70UsuariosVigFin;
         obj9.gxTpr_Usuariosfeccap = A92UsuariosFecCap;
         obj9.gxTpr_Usuariosid = A11UsuariosId;
         obj9.gxTpr_Usuariosid_Z = Z11UsuariosId;
         obj9.gxTpr_Usuarioscurp_Z = Z105UsuariosCurp;
         obj9.gxTpr_Usuariosnombre_Z = Z66UsuariosNombre;
         obj9.gxTpr_Usuariosappat_Z = Z65UsuariosApPat;
         obj9.gxTpr_Usuariosapmat_Z = Z64UsuariosApMat;
         obj9.gxTpr_Usuariosusr_Z = Z244UsuariosUsr;
         obj9.gxTpr_Usuariostipo_Z = Z272UsuariosTipo;
         obj9.gxTpr_Usuariosfecnacimiento_Z = Z255UsuariosFecNacimiento;
         obj9.gxTpr_Usuariosedad_Z = Z256UsuariosEdad;
         obj9.gxTpr_Usuariossexo_Z = Z257UsuariosSexo;
         obj9.gxTpr_Usuariospwd_Z = Z68UsuariosPwd;
         obj9.gxTpr_Usuarioskey_Z = Z67UsuariosKey;
         obj9.gxTpr_Usuariosvigini_Z = Z96UsuariosVigIni;
         obj9.gxTpr_Usuariosvigfin_Z = Z70UsuariosVigFin;
         obj9.gxTpr_Usuariosfeccap_Z = Z92UsuariosFecCap;
         obj9.gxTpr_Usuariosip_Z = Z93UsuariosIP;
         obj9.gxTpr_Usuariostelef_Z = Z260UsuariosTelef;
         obj9.gxTpr_Usuarioscorreo_Z = Z261UsuariosCorreo;
         obj9.gxTpr_Usuariosnomcompleto_Z = Z97UsuariosNomCompleto;
         obj9.gxTpr_Rolid_Z = Z24RolId;
         obj9.gxTpr_Rolnombre_Z = Z127RolNombre;
         obj9.gxTpr_Usuariossexofor_Z = Z275UsuariosSexoFor;
         obj9.gxTpr_Usuariosstatus_Z = Z286UsuariosStatus;
         obj9.gxTpr_Usuariosicono_gxi_Z = Z40000UsuariosIcono_GXI;
         obj9.gxTpr_Usuariosid_N = (short)(Convert.ToInt16(n11UsuariosId));
         obj9.gxTpr_Usuariosvigfin_N = (short)(Convert.ToInt16(n70UsuariosVigFin));
         obj9.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow9( SdtUsuarios obj9 )
      {
         obj9.gxTpr_Usuariosid = A11UsuariosId;
         return  ;
      }

      public void RowToVars9( SdtUsuarios obj9 ,
                              int forceLoad )
      {
         Gx_mode = obj9.gxTpr_Mode;
         A244UsuariosUsr = obj9.gxTpr_Usuariosusr;
         A93UsuariosIP = obj9.gxTpr_Usuariosip;
         A255UsuariosFecNacimiento = obj9.gxTpr_Usuariosfecnacimiento;
         A256UsuariosEdad = obj9.gxTpr_Usuariosedad;
         A275UsuariosSexoFor = obj9.gxTpr_Usuariossexofor;
         A97UsuariosNomCompleto = obj9.gxTpr_Usuariosnomcompleto;
         A105UsuariosCurp = obj9.gxTpr_Usuarioscurp;
         A66UsuariosNombre = obj9.gxTpr_Usuariosnombre;
         A65UsuariosApPat = obj9.gxTpr_Usuariosappat;
         A64UsuariosApMat = obj9.gxTpr_Usuariosapmat;
         A272UsuariosTipo = obj9.gxTpr_Usuariostipo;
         A245UsuariosIcono = obj9.gxTpr_Usuariosicono;
         A40000UsuariosIcono_GXI = obj9.gxTpr_Usuariosicono_gxi;
         A68UsuariosPwd = obj9.gxTpr_Usuariospwd;
         A67UsuariosKey = obj9.gxTpr_Usuarioskey;
         A260UsuariosTelef = obj9.gxTpr_Usuariostelef;
         A261UsuariosCorreo = obj9.gxTpr_Usuarioscorreo;
         A24RolId = obj9.gxTpr_Rolid;
         A127RolNombre = obj9.gxTpr_Rolnombre;
         A286UsuariosStatus = obj9.gxTpr_Usuariosstatus;
         A257UsuariosSexo = obj9.gxTpr_Usuariossexo;
         A96UsuariosVigIni = obj9.gxTpr_Usuariosvigini;
         A70UsuariosVigFin = obj9.gxTpr_Usuariosvigfin;
         n70UsuariosVigFin = false;
         A92UsuariosFecCap = obj9.gxTpr_Usuariosfeccap;
         A11UsuariosId = obj9.gxTpr_Usuariosid;
         n11UsuariosId = false;
         Z11UsuariosId = obj9.gxTpr_Usuariosid_Z;
         Z105UsuariosCurp = obj9.gxTpr_Usuarioscurp_Z;
         Z66UsuariosNombre = obj9.gxTpr_Usuariosnombre_Z;
         Z65UsuariosApPat = obj9.gxTpr_Usuariosappat_Z;
         Z64UsuariosApMat = obj9.gxTpr_Usuariosapmat_Z;
         Z244UsuariosUsr = obj9.gxTpr_Usuariosusr_Z;
         Z272UsuariosTipo = obj9.gxTpr_Usuariostipo_Z;
         Z255UsuariosFecNacimiento = obj9.gxTpr_Usuariosfecnacimiento_Z;
         Z256UsuariosEdad = obj9.gxTpr_Usuariosedad_Z;
         Z257UsuariosSexo = obj9.gxTpr_Usuariossexo_Z;
         Z68UsuariosPwd = obj9.gxTpr_Usuariospwd_Z;
         Z67UsuariosKey = obj9.gxTpr_Usuarioskey_Z;
         Z96UsuariosVigIni = obj9.gxTpr_Usuariosvigini_Z;
         Z70UsuariosVigFin = obj9.gxTpr_Usuariosvigfin_Z;
         Z92UsuariosFecCap = obj9.gxTpr_Usuariosfeccap_Z;
         Z93UsuariosIP = obj9.gxTpr_Usuariosip_Z;
         Z260UsuariosTelef = obj9.gxTpr_Usuariostelef_Z;
         Z261UsuariosCorreo = obj9.gxTpr_Usuarioscorreo_Z;
         Z97UsuariosNomCompleto = obj9.gxTpr_Usuariosnomcompleto_Z;
         Z24RolId = obj9.gxTpr_Rolid_Z;
         Z127RolNombre = obj9.gxTpr_Rolnombre_Z;
         Z275UsuariosSexoFor = obj9.gxTpr_Usuariossexofor_Z;
         Z286UsuariosStatus = obj9.gxTpr_Usuariosstatus_Z;
         Z40000UsuariosIcono_GXI = obj9.gxTpr_Usuariosicono_gxi_Z;
         n11UsuariosId = (bool)(Convert.ToBoolean(obj9.gxTpr_Usuariosid_N));
         n70UsuariosVigFin = (bool)(Convert.ToBoolean(obj9.gxTpr_Usuariosvigfin_N));
         Gx_mode = obj9.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A11UsuariosId = (int)getParm(obj,0);
         n11UsuariosId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey029( ) ;
         ScanKeyStart029( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z11UsuariosId = A11UsuariosId;
         }
         ZM029( -27) ;
         OnLoadActions029( ) ;
         AddRow029( ) ;
         ScanKeyEnd029( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars9( bcUsuarios, 0) ;
         ScanKeyStart029( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z11UsuariosId = A11UsuariosId;
         }
         ZM029( -27) ;
         OnLoadActions029( ) ;
         AddRow029( ) ;
         ScanKeyEnd029( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey029( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert029( ) ;
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A11UsuariosId != Z11UsuariosId )
               {
                  A11UsuariosId = Z11UsuariosId;
                  n11UsuariosId = false;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update029( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A11UsuariosId != Z11UsuariosId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert029( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert029( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars9( bcUsuarios, 0) ;
         SaveImpl( ) ;
         VarsToRow9( bcUsuarios) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars9( bcUsuarios, 0) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert029( ) ;
         AfterTrn( ) ;
         VarsToRow9( bcUsuarios) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
         }
         else
         {
            SdtUsuarios auxBC = new SdtUsuarios(context) ;
            IGxSilentTrn auxTrn = auxBC.getTransaction() ;
            auxBC.Load(A11UsuariosId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcUsuarios);
               auxBC.Save();
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars9( bcUsuarios, 0) ;
         UpdateImpl( ) ;
         VarsToRow9( bcUsuarios) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars9( bcUsuarios, 0) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert029( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
         }
         else
         {
            AfterTrn( ) ;
         }
         VarsToRow9( bcUsuarios) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars9( bcUsuarios, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey029( ) ;
         if ( RcdFound9 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A11UsuariosId != Z11UsuariosId )
            {
               A11UsuariosId = Z11UsuariosId;
               n11UsuariosId = false;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A11UsuariosId != Z11UsuariosId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         context.RollbackDataStores("usuarios_bc",pr_default);
         VarsToRow9( bcUsuarios) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public String GetMode( )
      {
         Gx_mode = bcUsuarios.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( String lMode )
      {
         Gx_mode = lMode;
         bcUsuarios.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcUsuarios )
         {
            bcUsuarios = (SdtUsuarios)(sdt);
            if ( StringUtil.StrCmp(bcUsuarios.gxTpr_Mode, "") == 0 )
            {
               bcUsuarios.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow9( bcUsuarios) ;
            }
            else
            {
               RowToVars9( bcUsuarios, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcUsuarios.gxTpr_Mode, "") == 0 )
            {
               bcUsuarios.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars9( bcUsuarios, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtUsuarios Usuarios_BC
      {
         get {
            return bcUsuarios ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
      }

      protected override void createObjects( )
      {
      }

      protected void Process( )
      {
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
         pr_default.close(10);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         BC00025_A11UsuariosId = new int[1] ;
         BC00025_n11UsuariosId = new bool[] {false} ;
         BC00025_A244UsuariosUsr = new String[] {""} ;
         BC00025_A93UsuariosIP = new String[] {""} ;
         BC00025_A255UsuariosFecNacimiento = new DateTime[] {DateTime.MinValue} ;
         BC00025_A256UsuariosEdad = new short[1] ;
         BC00025_A105UsuariosCurp = new String[] {""} ;
         BC00025_A66UsuariosNombre = new String[] {""} ;
         BC00025_A65UsuariosApPat = new String[] {""} ;
         BC00025_A64UsuariosApMat = new String[] {""} ;
         BC00025_A272UsuariosTipo = new short[1] ;
         BC00025_A40000UsuariosIcono_GXI = new String[] {""} ;
         BC00025_A257UsuariosSexo = new String[] {""} ;
         BC00025_A68UsuariosPwd = new String[] {""} ;
         BC00025_A67UsuariosKey = new String[] {""} ;
         BC00025_A96UsuariosVigIni = new DateTime[] {DateTime.MinValue} ;
         BC00025_A70UsuariosVigFin = new DateTime[] {DateTime.MinValue} ;
         BC00025_n70UsuariosVigFin = new bool[] {false} ;
         BC00025_A92UsuariosFecCap = new DateTime[] {DateTime.MinValue} ;
         BC00025_A260UsuariosTelef = new String[] {""} ;
         BC00025_A261UsuariosCorreo = new String[] {""} ;
         BC00025_A127RolNombre = new String[] {""} ;
         BC00025_A286UsuariosStatus = new short[1] ;
         BC00025_A24RolId = new int[1] ;
         BC00025_A245UsuariosIcono = new String[] {""} ;
         A244UsuariosUsr = "";
         A93UsuariosIP = "";
         A255UsuariosFecNacimiento = DateTime.MinValue;
         A105UsuariosCurp = "";
         A66UsuariosNombre = "";
         A65UsuariosApPat = "";
         A64UsuariosApMat = "";
         A40000UsuariosIcono_GXI = "";
         A257UsuariosSexo = "";
         A68UsuariosPwd = "";
         A67UsuariosKey = "";
         A96UsuariosVigIni = DateTime.MinValue;
         A70UsuariosVigFin = DateTime.MinValue;
         A92UsuariosFecCap = (DateTime)(DateTime.MinValue);
         A260UsuariosTelef = "";
         A261UsuariosCorreo = "";
         A127RolNombre = "";
         A245UsuariosIcono = "";
         gx_restcollection = new GXBCCollection<SdtUsuarios>( context, "Usuarios", "ADMINDATA1");
         sMode9 = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV35usuario = "";
         AV30Sesion = context.GetSession();
         Z244UsuariosUsr = "";
         Z93UsuariosIP = "";
         Z255UsuariosFecNacimiento = DateTime.MinValue;
         Z105UsuariosCurp = "";
         Z66UsuariosNombre = "";
         Z65UsuariosApPat = "";
         Z64UsuariosApMat = "";
         Z257UsuariosSexo = "";
         Z68UsuariosPwd = "";
         Z67UsuariosKey = "";
         Z96UsuariosVigIni = DateTime.MinValue;
         Z70UsuariosVigFin = DateTime.MinValue;
         Z92UsuariosFecCap = (DateTime)(DateTime.MinValue);
         Z260UsuariosTelef = "";
         Z261UsuariosCorreo = "";
         Z97UsuariosNomCompleto = "";
         A97UsuariosNomCompleto = "";
         Z275UsuariosSexoFor = "";
         A275UsuariosSexoFor = "";
         Z127RolNombre = "";
         Z245UsuariosIcono = "";
         Z40000UsuariosIcono_GXI = "";
         Gx_date = DateTime.MinValue;
         BC00026_A11UsuariosId = new int[1] ;
         BC00026_n11UsuariosId = new bool[] {false} ;
         BC00026_A244UsuariosUsr = new String[] {""} ;
         BC00026_A93UsuariosIP = new String[] {""} ;
         BC00026_A255UsuariosFecNacimiento = new DateTime[] {DateTime.MinValue} ;
         BC00026_A256UsuariosEdad = new short[1] ;
         BC00026_A105UsuariosCurp = new String[] {""} ;
         BC00026_A66UsuariosNombre = new String[] {""} ;
         BC00026_A65UsuariosApPat = new String[] {""} ;
         BC00026_A64UsuariosApMat = new String[] {""} ;
         BC00026_A272UsuariosTipo = new short[1] ;
         BC00026_A40000UsuariosIcono_GXI = new String[] {""} ;
         BC00026_A257UsuariosSexo = new String[] {""} ;
         BC00026_A68UsuariosPwd = new String[] {""} ;
         BC00026_A67UsuariosKey = new String[] {""} ;
         BC00026_A96UsuariosVigIni = new DateTime[] {DateTime.MinValue} ;
         BC00026_A70UsuariosVigFin = new DateTime[] {DateTime.MinValue} ;
         BC00026_n70UsuariosVigFin = new bool[] {false} ;
         BC00026_A92UsuariosFecCap = new DateTime[] {DateTime.MinValue} ;
         BC00026_A260UsuariosTelef = new String[] {""} ;
         BC00026_A261UsuariosCorreo = new String[] {""} ;
         BC00026_A127RolNombre = new String[] {""} ;
         BC00026_A286UsuariosStatus = new short[1] ;
         BC00026_A24RolId = new int[1] ;
         BC00026_A245UsuariosIcono = new String[] {""} ;
         AV56UsuariosCurpAnt = "";
         GXt_date4 = DateTime.MinValue;
         BC00024_A127RolNombre = new String[] {""} ;
         BC00027_A11UsuariosId = new int[1] ;
         BC00027_n11UsuariosId = new bool[] {false} ;
         BC00023_A11UsuariosId = new int[1] ;
         BC00023_n11UsuariosId = new bool[] {false} ;
         BC00023_A244UsuariosUsr = new String[] {""} ;
         BC00023_A93UsuariosIP = new String[] {""} ;
         BC00023_A255UsuariosFecNacimiento = new DateTime[] {DateTime.MinValue} ;
         BC00023_A256UsuariosEdad = new short[1] ;
         BC00023_A105UsuariosCurp = new String[] {""} ;
         BC00023_A66UsuariosNombre = new String[] {""} ;
         BC00023_A65UsuariosApPat = new String[] {""} ;
         BC00023_A64UsuariosApMat = new String[] {""} ;
         BC00023_A272UsuariosTipo = new short[1] ;
         BC00023_A40000UsuariosIcono_GXI = new String[] {""} ;
         BC00023_A257UsuariosSexo = new String[] {""} ;
         BC00023_A68UsuariosPwd = new String[] {""} ;
         BC00023_A67UsuariosKey = new String[] {""} ;
         BC00023_A96UsuariosVigIni = new DateTime[] {DateTime.MinValue} ;
         BC00023_A70UsuariosVigFin = new DateTime[] {DateTime.MinValue} ;
         BC00023_n70UsuariosVigFin = new bool[] {false} ;
         BC00023_A92UsuariosFecCap = new DateTime[] {DateTime.MinValue} ;
         BC00023_A260UsuariosTelef = new String[] {""} ;
         BC00023_A261UsuariosCorreo = new String[] {""} ;
         BC00023_A286UsuariosStatus = new short[1] ;
         BC00023_A24RolId = new int[1] ;
         BC00023_A245UsuariosIcono = new String[] {""} ;
         BC00022_A11UsuariosId = new int[1] ;
         BC00022_n11UsuariosId = new bool[] {false} ;
         BC00022_A244UsuariosUsr = new String[] {""} ;
         BC00022_A93UsuariosIP = new String[] {""} ;
         BC00022_A255UsuariosFecNacimiento = new DateTime[] {DateTime.MinValue} ;
         BC00022_A256UsuariosEdad = new short[1] ;
         BC00022_A105UsuariosCurp = new String[] {""} ;
         BC00022_A66UsuariosNombre = new String[] {""} ;
         BC00022_A65UsuariosApPat = new String[] {""} ;
         BC00022_A64UsuariosApMat = new String[] {""} ;
         BC00022_A272UsuariosTipo = new short[1] ;
         BC00022_A40000UsuariosIcono_GXI = new String[] {""} ;
         BC00022_A257UsuariosSexo = new String[] {""} ;
         BC00022_A68UsuariosPwd = new String[] {""} ;
         BC00022_A67UsuariosKey = new String[] {""} ;
         BC00022_A96UsuariosVigIni = new DateTime[] {DateTime.MinValue} ;
         BC00022_A70UsuariosVigFin = new DateTime[] {DateTime.MinValue} ;
         BC00022_n70UsuariosVigFin = new bool[] {false} ;
         BC00022_A92UsuariosFecCap = new DateTime[] {DateTime.MinValue} ;
         BC00022_A260UsuariosTelef = new String[] {""} ;
         BC00022_A261UsuariosCorreo = new String[] {""} ;
         BC00022_A286UsuariosStatus = new short[1] ;
         BC00022_A24RolId = new int[1] ;
         BC00022_A245UsuariosIcono = new String[] {""} ;
         GXt_char2 = "";
         BC000212_A127RolNombre = new String[] {""} ;
         BC000213_A61bitAccesFec = new DateTime[] {DateTime.MinValue} ;
         BC000213_A75bitAccesIp = new String[] {""} ;
         BC000214_A263Vacantes_Id = new int[1] ;
         BC000214_A11UsuariosId = new int[1] ;
         BC000214_n11UsuariosId = new bool[] {false} ;
         BC000215_A263Vacantes_Id = new int[1] ;
         BC000215_A11UsuariosId = new int[1] ;
         BC000215_n11UsuariosId = new bool[] {false} ;
         BC000216_A278Perfiles_Id = new int[1] ;
         BC000216_A11UsuariosId = new int[1] ;
         BC000216_n11UsuariosId = new bool[] {false} ;
         BC000217_A11UsuariosId = new int[1] ;
         BC000217_n11UsuariosId = new bool[] {false} ;
         BC000217_A30FechaIntento = new DateTime[] {DateTime.MinValue} ;
         BC000218_A11UsuariosId = new int[1] ;
         BC000218_n11UsuariosId = new bool[] {false} ;
         BC000218_A62HisPwdFecha = new DateTime[] {DateTime.MinValue} ;
         BC000219_A11UsuariosId = new int[1] ;
         BC000219_n11UsuariosId = new bool[] {false} ;
         BC000219_A244UsuariosUsr = new String[] {""} ;
         BC000219_A93UsuariosIP = new String[] {""} ;
         BC000219_A255UsuariosFecNacimiento = new DateTime[] {DateTime.MinValue} ;
         BC000219_A256UsuariosEdad = new short[1] ;
         BC000219_A105UsuariosCurp = new String[] {""} ;
         BC000219_A66UsuariosNombre = new String[] {""} ;
         BC000219_A65UsuariosApPat = new String[] {""} ;
         BC000219_A64UsuariosApMat = new String[] {""} ;
         BC000219_A272UsuariosTipo = new short[1] ;
         BC000219_A40000UsuariosIcono_GXI = new String[] {""} ;
         BC000219_A257UsuariosSexo = new String[] {""} ;
         BC000219_A68UsuariosPwd = new String[] {""} ;
         BC000219_A67UsuariosKey = new String[] {""} ;
         BC000219_A96UsuariosVigIni = new DateTime[] {DateTime.MinValue} ;
         BC000219_A70UsuariosVigFin = new DateTime[] {DateTime.MinValue} ;
         BC000219_n70UsuariosVigFin = new bool[] {false} ;
         BC000219_A92UsuariosFecCap = new DateTime[] {DateTime.MinValue} ;
         BC000219_A260UsuariosTelef = new String[] {""} ;
         BC000219_A261UsuariosCorreo = new String[] {""} ;
         BC000219_A127RolNombre = new String[] {""} ;
         BC000219_A286UsuariosStatus = new short[1] ;
         BC000219_A24RolId = new int[1] ;
         BC000219_A245UsuariosIcono = new String[] {""} ;
         i93UsuariosIP = "";
         i96UsuariosVigIni = DateTime.MinValue;
         i70UsuariosVigFin = DateTime.MinValue;
         i92UsuariosFecCap = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usuarios_bc__default(),
            new Object[][] {
                new Object[] {
               BC00022_A11UsuariosId, BC00022_A244UsuariosUsr, BC00022_A93UsuariosIP, BC00022_A255UsuariosFecNacimiento, BC00022_A256UsuariosEdad, BC00022_A105UsuariosCurp, BC00022_A66UsuariosNombre, BC00022_A65UsuariosApPat, BC00022_A64UsuariosApMat, BC00022_A272UsuariosTipo,
               BC00022_A40000UsuariosIcono_GXI, BC00022_A257UsuariosSexo, BC00022_A68UsuariosPwd, BC00022_A67UsuariosKey, BC00022_A96UsuariosVigIni, BC00022_A70UsuariosVigFin, BC00022_n70UsuariosVigFin, BC00022_A92UsuariosFecCap, BC00022_A260UsuariosTelef, BC00022_A261UsuariosCorreo,
               BC00022_A286UsuariosStatus, BC00022_A24RolId, BC00022_A245UsuariosIcono
               }
               , new Object[] {
               BC00023_A11UsuariosId, BC00023_A244UsuariosUsr, BC00023_A93UsuariosIP, BC00023_A255UsuariosFecNacimiento, BC00023_A256UsuariosEdad, BC00023_A105UsuariosCurp, BC00023_A66UsuariosNombre, BC00023_A65UsuariosApPat, BC00023_A64UsuariosApMat, BC00023_A272UsuariosTipo,
               BC00023_A40000UsuariosIcono_GXI, BC00023_A257UsuariosSexo, BC00023_A68UsuariosPwd, BC00023_A67UsuariosKey, BC00023_A96UsuariosVigIni, BC00023_A70UsuariosVigFin, BC00023_n70UsuariosVigFin, BC00023_A92UsuariosFecCap, BC00023_A260UsuariosTelef, BC00023_A261UsuariosCorreo,
               BC00023_A286UsuariosStatus, BC00023_A24RolId, BC00023_A245UsuariosIcono
               }
               , new Object[] {
               BC00024_A127RolNombre
               }
               , new Object[] {
               BC00025_A11UsuariosId, BC00025_A244UsuariosUsr, BC00025_A93UsuariosIP, BC00025_A255UsuariosFecNacimiento, BC00025_A256UsuariosEdad, BC00025_A105UsuariosCurp, BC00025_A66UsuariosNombre, BC00025_A65UsuariosApPat, BC00025_A64UsuariosApMat, BC00025_A272UsuariosTipo,
               BC00025_A40000UsuariosIcono_GXI, BC00025_A257UsuariosSexo, BC00025_A68UsuariosPwd, BC00025_A67UsuariosKey, BC00025_A96UsuariosVigIni, BC00025_A70UsuariosVigFin, BC00025_n70UsuariosVigFin, BC00025_A92UsuariosFecCap, BC00025_A260UsuariosTelef, BC00025_A261UsuariosCorreo,
               BC00025_A127RolNombre, BC00025_A286UsuariosStatus, BC00025_A24RolId, BC00025_A245UsuariosIcono
               }
               , new Object[] {
               BC00026_A11UsuariosId, BC00026_A244UsuariosUsr, BC00026_A93UsuariosIP, BC00026_A255UsuariosFecNacimiento, BC00026_A256UsuariosEdad, BC00026_A105UsuariosCurp, BC00026_A66UsuariosNombre, BC00026_A65UsuariosApPat, BC00026_A64UsuariosApMat, BC00026_A272UsuariosTipo,
               BC00026_A40000UsuariosIcono_GXI, BC00026_A257UsuariosSexo, BC00026_A68UsuariosPwd, BC00026_A67UsuariosKey, BC00026_A96UsuariosVigIni, BC00026_A70UsuariosVigFin, BC00026_n70UsuariosVigFin, BC00026_A92UsuariosFecCap, BC00026_A260UsuariosTelef, BC00026_A261UsuariosCorreo,
               BC00026_A127RolNombre, BC00026_A286UsuariosStatus, BC00026_A24RolId, BC00026_A245UsuariosIcono
               }
               , new Object[] {
               BC00027_A11UsuariosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000212_A127RolNombre
               }
               , new Object[] {
               BC000213_A61bitAccesFec, BC000213_A75bitAccesIp
               }
               , new Object[] {
               BC000214_A263Vacantes_Id, BC000214_A11UsuariosId
               }
               , new Object[] {
               BC000215_A263Vacantes_Id, BC000215_A11UsuariosId
               }
               , new Object[] {
               BC000216_A278Perfiles_Id, BC000216_A11UsuariosId
               }
               , new Object[] {
               BC000217_A11UsuariosId, BC000217_A30FechaIntento
               }
               , new Object[] {
               BC000218_A11UsuariosId, BC000218_A62HisPwdFecha
               }
               , new Object[] {
               BC000219_A11UsuariosId, BC000219_A244UsuariosUsr, BC000219_A93UsuariosIP, BC000219_A255UsuariosFecNacimiento, BC000219_A256UsuariosEdad, BC000219_A105UsuariosCurp, BC000219_A66UsuariosNombre, BC000219_A65UsuariosApPat, BC000219_A64UsuariosApMat, BC000219_A272UsuariosTipo,
               BC000219_A40000UsuariosIcono_GXI, BC000219_A257UsuariosSexo, BC000219_A68UsuariosPwd, BC000219_A67UsuariosKey, BC000219_A96UsuariosVigIni, BC000219_A70UsuariosVigFin, BC000219_n70UsuariosVigFin, BC000219_A92UsuariosFecCap, BC000219_A260UsuariosTelef, BC000219_A261UsuariosCorreo,
               BC000219_A127RolNombre, BC000219_A286UsuariosStatus, BC000219_A24RolId, BC000219_A245UsuariosIcono
               }
            }
         );
         A257UsuariosSexo = "";
         Z257UsuariosSexo = "";
         A92UsuariosFecCap = DateTimeUtil.ServerNow( context, pr_default);
         Z92UsuariosFecCap = DateTimeUtil.ServerNow( context, pr_default);
         i92UsuariosFecCap = DateTimeUtil.ServerNow( context, pr_default);
         A70UsuariosVigFin = DateTime.MinValue;
         n70UsuariosVigFin = false;
         Z70UsuariosVigFin = DateTime.MinValue;
         n70UsuariosVigFin = false;
         i70UsuariosVigFin = DateTime.MinValue;
         n70UsuariosVigFin = false;
         A96UsuariosVigIni = DateTime.MinValue;
         Z96UsuariosVigIni = DateTime.MinValue;
         i96UsuariosVigIni = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12022 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short RcdFound9 ;
      private short A256UsuariosEdad ;
      private short A272UsuariosTipo ;
      private short A286UsuariosStatus ;
      private short GX_JID ;
      private short Z256UsuariosEdad ;
      private short Z272UsuariosTipo ;
      private short Z286UsuariosStatus ;
      private short Gx_BScreen ;
      private short AV53error1 ;
      private short nIsDirty_9 ;
      private short GXt_int3 ;
      private int trnEnded ;
      private int Start ;
      private int Count ;
      private int GXPagingFrom9 ;
      private int GXPagingTo9 ;
      private int A11UsuariosId ;
      private int A24RolId ;
      private int Z11UsuariosId ;
      private int AV34UsrLog ;
      private int AV7adscId ;
      private int AV10comision ;
      private int AV29SecRnd ;
      private int Z24RolId ;
      private long GXt_int1 ;
      private String scmdbuf ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String A257UsuariosSexo ;
      private String A260UsuariosTelef ;
      private String sMode9 ;
      private String Gx_mode ;
      private String endTrnMsgTxt ;
      private String endTrnMsgCod ;
      private String AV35usuario ;
      private String Z257UsuariosSexo ;
      private String Z260UsuariosTelef ;
      private String Z275UsuariosSexoFor ;
      private String A275UsuariosSexoFor ;
      private String GXt_char2 ;
      private DateTime A92UsuariosFecCap ;
      private DateTime Z92UsuariosFecCap ;
      private DateTime i92UsuariosFecCap ;
      private DateTime A255UsuariosFecNacimiento ;
      private DateTime A96UsuariosVigIni ;
      private DateTime A70UsuariosVigFin ;
      private DateTime Z255UsuariosFecNacimiento ;
      private DateTime Z96UsuariosVigIni ;
      private DateTime Z70UsuariosVigFin ;
      private DateTime Gx_date ;
      private DateTime GXt_date4 ;
      private DateTime i96UsuariosVigIni ;
      private DateTime i70UsuariosVigFin ;
      private bool n11UsuariosId ;
      private bool n70UsuariosVigFin ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private String A244UsuariosUsr ;
      private String A93UsuariosIP ;
      private String A105UsuariosCurp ;
      private String A66UsuariosNombre ;
      private String A65UsuariosApPat ;
      private String A64UsuariosApMat ;
      private String A40000UsuariosIcono_GXI ;
      private String A68UsuariosPwd ;
      private String A67UsuariosKey ;
      private String A261UsuariosCorreo ;
      private String A127RolNombre ;
      private String Z244UsuariosUsr ;
      private String Z93UsuariosIP ;
      private String Z105UsuariosCurp ;
      private String Z66UsuariosNombre ;
      private String Z65UsuariosApPat ;
      private String Z64UsuariosApMat ;
      private String Z68UsuariosPwd ;
      private String Z67UsuariosKey ;
      private String Z261UsuariosCorreo ;
      private String Z97UsuariosNomCompleto ;
      private String A97UsuariosNomCompleto ;
      private String Z127RolNombre ;
      private String Z40000UsuariosIcono_GXI ;
      private String AV56UsuariosCurpAnt ;
      private String i93UsuariosIP ;
      private String A245UsuariosIcono ;
      private String Z245UsuariosIcono ;
      private IGxSession AV30Sesion ;
      private GXBCCollection<SdtUsuarios> gx_restcollection ;
      private SdtUsuarios bcUsuarios ;
      private SdtUsuarios gx_sdt_item ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00025_A11UsuariosId ;
      private bool[] BC00025_n11UsuariosId ;
      private String[] BC00025_A244UsuariosUsr ;
      private String[] BC00025_A93UsuariosIP ;
      private DateTime[] BC00025_A255UsuariosFecNacimiento ;
      private short[] BC00025_A256UsuariosEdad ;
      private String[] BC00025_A105UsuariosCurp ;
      private String[] BC00025_A66UsuariosNombre ;
      private String[] BC00025_A65UsuariosApPat ;
      private String[] BC00025_A64UsuariosApMat ;
      private short[] BC00025_A272UsuariosTipo ;
      private String[] BC00025_A40000UsuariosIcono_GXI ;
      private String[] BC00025_A257UsuariosSexo ;
      private String[] BC00025_A68UsuariosPwd ;
      private String[] BC00025_A67UsuariosKey ;
      private DateTime[] BC00025_A96UsuariosVigIni ;
      private DateTime[] BC00025_A70UsuariosVigFin ;
      private bool[] BC00025_n70UsuariosVigFin ;
      private DateTime[] BC00025_A92UsuariosFecCap ;
      private String[] BC00025_A260UsuariosTelef ;
      private String[] BC00025_A261UsuariosCorreo ;
      private String[] BC00025_A127RolNombre ;
      private short[] BC00025_A286UsuariosStatus ;
      private int[] BC00025_A24RolId ;
      private String[] BC00025_A245UsuariosIcono ;
      private int[] BC00026_A11UsuariosId ;
      private bool[] BC00026_n11UsuariosId ;
      private String[] BC00026_A244UsuariosUsr ;
      private String[] BC00026_A93UsuariosIP ;
      private DateTime[] BC00026_A255UsuariosFecNacimiento ;
      private short[] BC00026_A256UsuariosEdad ;
      private String[] BC00026_A105UsuariosCurp ;
      private String[] BC00026_A66UsuariosNombre ;
      private String[] BC00026_A65UsuariosApPat ;
      private String[] BC00026_A64UsuariosApMat ;
      private short[] BC00026_A272UsuariosTipo ;
      private String[] BC00026_A40000UsuariosIcono_GXI ;
      private String[] BC00026_A257UsuariosSexo ;
      private String[] BC00026_A68UsuariosPwd ;
      private String[] BC00026_A67UsuariosKey ;
      private DateTime[] BC00026_A96UsuariosVigIni ;
      private DateTime[] BC00026_A70UsuariosVigFin ;
      private bool[] BC00026_n70UsuariosVigFin ;
      private DateTime[] BC00026_A92UsuariosFecCap ;
      private String[] BC00026_A260UsuariosTelef ;
      private String[] BC00026_A261UsuariosCorreo ;
      private String[] BC00026_A127RolNombre ;
      private short[] BC00026_A286UsuariosStatus ;
      private int[] BC00026_A24RolId ;
      private String[] BC00026_A245UsuariosIcono ;
      private String[] BC00024_A127RolNombre ;
      private int[] BC00027_A11UsuariosId ;
      private bool[] BC00027_n11UsuariosId ;
      private int[] BC00023_A11UsuariosId ;
      private bool[] BC00023_n11UsuariosId ;
      private String[] BC00023_A244UsuariosUsr ;
      private String[] BC00023_A93UsuariosIP ;
      private DateTime[] BC00023_A255UsuariosFecNacimiento ;
      private short[] BC00023_A256UsuariosEdad ;
      private String[] BC00023_A105UsuariosCurp ;
      private String[] BC00023_A66UsuariosNombre ;
      private String[] BC00023_A65UsuariosApPat ;
      private String[] BC00023_A64UsuariosApMat ;
      private short[] BC00023_A272UsuariosTipo ;
      private String[] BC00023_A40000UsuariosIcono_GXI ;
      private String[] BC00023_A257UsuariosSexo ;
      private String[] BC00023_A68UsuariosPwd ;
      private String[] BC00023_A67UsuariosKey ;
      private DateTime[] BC00023_A96UsuariosVigIni ;
      private DateTime[] BC00023_A70UsuariosVigFin ;
      private bool[] BC00023_n70UsuariosVigFin ;
      private DateTime[] BC00023_A92UsuariosFecCap ;
      private String[] BC00023_A260UsuariosTelef ;
      private String[] BC00023_A261UsuariosCorreo ;
      private short[] BC00023_A286UsuariosStatus ;
      private int[] BC00023_A24RolId ;
      private String[] BC00023_A245UsuariosIcono ;
      private int[] BC00022_A11UsuariosId ;
      private bool[] BC00022_n11UsuariosId ;
      private String[] BC00022_A244UsuariosUsr ;
      private String[] BC00022_A93UsuariosIP ;
      private DateTime[] BC00022_A255UsuariosFecNacimiento ;
      private short[] BC00022_A256UsuariosEdad ;
      private String[] BC00022_A105UsuariosCurp ;
      private String[] BC00022_A66UsuariosNombre ;
      private String[] BC00022_A65UsuariosApPat ;
      private String[] BC00022_A64UsuariosApMat ;
      private short[] BC00022_A272UsuariosTipo ;
      private String[] BC00022_A40000UsuariosIcono_GXI ;
      private String[] BC00022_A257UsuariosSexo ;
      private String[] BC00022_A68UsuariosPwd ;
      private String[] BC00022_A67UsuariosKey ;
      private DateTime[] BC00022_A96UsuariosVigIni ;
      private DateTime[] BC00022_A70UsuariosVigFin ;
      private bool[] BC00022_n70UsuariosVigFin ;
      private DateTime[] BC00022_A92UsuariosFecCap ;
      private String[] BC00022_A260UsuariosTelef ;
      private String[] BC00022_A261UsuariosCorreo ;
      private short[] BC00022_A286UsuariosStatus ;
      private int[] BC00022_A24RolId ;
      private String[] BC00022_A245UsuariosIcono ;
      private String[] BC000212_A127RolNombre ;
      private DateTime[] BC000213_A61bitAccesFec ;
      private String[] BC000213_A75bitAccesIp ;
      private int[] BC000214_A263Vacantes_Id ;
      private int[] BC000214_A11UsuariosId ;
      private bool[] BC000214_n11UsuariosId ;
      private int[] BC000215_A263Vacantes_Id ;
      private int[] BC000215_A11UsuariosId ;
      private bool[] BC000215_n11UsuariosId ;
      private int[] BC000216_A278Perfiles_Id ;
      private int[] BC000216_A11UsuariosId ;
      private bool[] BC000216_n11UsuariosId ;
      private int[] BC000217_A11UsuariosId ;
      private bool[] BC000217_n11UsuariosId ;
      private DateTime[] BC000217_A30FechaIntento ;
      private int[] BC000218_A11UsuariosId ;
      private bool[] BC000218_n11UsuariosId ;
      private DateTime[] BC000218_A62HisPwdFecha ;
      private int[] BC000219_A11UsuariosId ;
      private bool[] BC000219_n11UsuariosId ;
      private String[] BC000219_A244UsuariosUsr ;
      private String[] BC000219_A93UsuariosIP ;
      private DateTime[] BC000219_A255UsuariosFecNacimiento ;
      private short[] BC000219_A256UsuariosEdad ;
      private String[] BC000219_A105UsuariosCurp ;
      private String[] BC000219_A66UsuariosNombre ;
      private String[] BC000219_A65UsuariosApPat ;
      private String[] BC000219_A64UsuariosApMat ;
      private short[] BC000219_A272UsuariosTipo ;
      private String[] BC000219_A40000UsuariosIcono_GXI ;
      private String[] BC000219_A257UsuariosSexo ;
      private String[] BC000219_A68UsuariosPwd ;
      private String[] BC000219_A67UsuariosKey ;
      private DateTime[] BC000219_A96UsuariosVigIni ;
      private DateTime[] BC000219_A70UsuariosVigFin ;
      private bool[] BC000219_n70UsuariosVigFin ;
      private DateTime[] BC000219_A92UsuariosFecCap ;
      private String[] BC000219_A260UsuariosTelef ;
      private String[] BC000219_A261UsuariosCorreo ;
      private String[] BC000219_A127RolNombre ;
      private short[] BC000219_A286UsuariosStatus ;
      private int[] BC000219_A24RolId ;
      private String[] BC000219_A245UsuariosIcono ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class usuarios_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00025 ;
          prmBC00025 = new Object[] {
          new Object[] {"GXPagingFrom9",System.Data.DbType.Int32,9,0} ,
          new Object[] {"GXPagingTo9",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmBC00026 ;
          prmBC00026 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmBC00024 ;
          prmBC00024 = new Object[] {
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmBC00027 ;
          prmBC00027 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmBC00023 ;
          prmBC00023 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmBC00022 ;
          prmBC00022 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmBC00028 ;
          prmBC00028 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"UsuariosUsr",System.Data.DbType.String,20,0} ,
          new Object[] {"UsuariosIP",System.Data.DbType.String,15,0} ,
          new Object[] {"UsuariosFecNacimiento",System.Data.DbType.Date,8,0} ,
          new Object[] {"UsuariosEdad",System.Data.DbType.Int16,4,0} ,
          new Object[] {"UsuariosCurp",System.Data.DbType.String,18,0} ,
          new Object[] {"UsuariosNombre",System.Data.DbType.String,40,0} ,
          new Object[] {"UsuariosApPat",System.Data.DbType.String,40,0} ,
          new Object[] {"UsuariosApMat",System.Data.DbType.String,40,0} ,
          new Object[] {"UsuariosTipo",System.Data.DbType.Int16,4,0} ,
          new Object[] {"UsuariosIcono",System.Data.DbType.Binary,1024,0} ,
          new Object[] {"UsuariosIcono_GXI",System.Data.DbType.String,2048,0} ,
          new Object[] {"UsuariosSexo",System.Data.DbType.String,1,0} ,
          new Object[] {"UsuariosPwd",System.Data.DbType.String,32,0} ,
          new Object[] {"UsuariosKey",System.Data.DbType.String,32,0} ,
          new Object[] {"UsuariosVigIni",System.Data.DbType.Date,8,0} ,
          new Object[] {"UsuariosVigFin",System.Data.DbType.Date,8,0} ,
          new Object[] {"UsuariosFecCap",System.Data.DbType.DateTime,10,8} ,
          new Object[] {"UsuariosTelef",System.Data.DbType.String,10,0} ,
          new Object[] {"UsuariosCorreo",System.Data.DbType.String,100,0} ,
          new Object[] {"UsuariosStatus",System.Data.DbType.Byte,1,0} ,
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmBC00029 ;
          prmBC00029 = new Object[] {
          new Object[] {"UsuariosUsr",System.Data.DbType.String,20,0} ,
          new Object[] {"UsuariosIP",System.Data.DbType.String,15,0} ,
          new Object[] {"UsuariosFecNacimiento",System.Data.DbType.Date,8,0} ,
          new Object[] {"UsuariosEdad",System.Data.DbType.Int16,4,0} ,
          new Object[] {"UsuariosCurp",System.Data.DbType.String,18,0} ,
          new Object[] {"UsuariosNombre",System.Data.DbType.String,40,0} ,
          new Object[] {"UsuariosApPat",System.Data.DbType.String,40,0} ,
          new Object[] {"UsuariosApMat",System.Data.DbType.String,40,0} ,
          new Object[] {"UsuariosTipo",System.Data.DbType.Int16,4,0} ,
          new Object[] {"UsuariosSexo",System.Data.DbType.String,1,0} ,
          new Object[] {"UsuariosPwd",System.Data.DbType.String,32,0} ,
          new Object[] {"UsuariosKey",System.Data.DbType.String,32,0} ,
          new Object[] {"UsuariosVigIni",System.Data.DbType.Date,8,0} ,
          new Object[] {"UsuariosVigFin",System.Data.DbType.Date,8,0} ,
          new Object[] {"UsuariosFecCap",System.Data.DbType.DateTime,10,8} ,
          new Object[] {"UsuariosTelef",System.Data.DbType.String,10,0} ,
          new Object[] {"UsuariosCorreo",System.Data.DbType.String,100,0} ,
          new Object[] {"UsuariosStatus",System.Data.DbType.Byte,1,0} ,
          new Object[] {"RolId",System.Data.DbType.Int32,9,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmBC000210 ;
          prmBC000210 = new Object[] {
          new Object[] {"UsuariosIcono",System.Data.DbType.Binary,1024,0} ,
          new Object[] {"UsuariosIcono_GXI",System.Data.DbType.String,2048,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmBC000211 ;
          prmBC000211 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmBC000212 ;
          prmBC000212 = new Object[] {
          new Object[] {"RolId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmBC000213 ;
          prmBC000213 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmBC000214 ;
          prmBC000214 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmBC000215 ;
          prmBC000215 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmBC000216 ;
          prmBC000216 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmBC000217 ;
          prmBC000217 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmBC000218 ;
          prmBC000218 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmBC000219 ;
          prmBC000219 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("BC00022", "SELECT `UsuariosId`, `UsuariosUsr`, `UsuariosIP`, `UsuariosFecNacimiento`, `UsuariosEdad`, `UsuariosCurp`, `UsuariosNombre`, `UsuariosApPat`, `UsuariosApMat`, `UsuariosTipo`, `UsuariosIcono_GXI`, `UsuariosSexo`, `UsuariosPwd`, `UsuariosKey`, `UsuariosVigIni`, `UsuariosVigFin`, `UsuariosFecCap`, `UsuariosTelef`, `UsuariosCorreo`, `UsuariosStatus`, `RolId`, `UsuariosIcono` FROM `Usuarios` WHERE `UsuariosId` = ?  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00023", "SELECT `UsuariosId`, `UsuariosUsr`, `UsuariosIP`, `UsuariosFecNacimiento`, `UsuariosEdad`, `UsuariosCurp`, `UsuariosNombre`, `UsuariosApPat`, `UsuariosApMat`, `UsuariosTipo`, `UsuariosIcono_GXI`, `UsuariosSexo`, `UsuariosPwd`, `UsuariosKey`, `UsuariosVigIni`, `UsuariosVigFin`, `UsuariosFecCap`, `UsuariosTelef`, `UsuariosCorreo`, `UsuariosStatus`, `RolId`, `UsuariosIcono` FROM `Usuarios` WHERE `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00024", "SELECT `RolNombre` FROM `Roles` WHERE `RolId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00024,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00025", "SELECT TM1.`UsuariosId`, TM1.`UsuariosUsr`, TM1.`UsuariosIP`, TM1.`UsuariosFecNacimiento`, TM1.`UsuariosEdad`, TM1.`UsuariosCurp`, TM1.`UsuariosNombre`, TM1.`UsuariosApPat`, TM1.`UsuariosApMat`, TM1.`UsuariosTipo`, TM1.`UsuariosIcono_GXI`, TM1.`UsuariosSexo`, TM1.`UsuariosPwd`, TM1.`UsuariosKey`, TM1.`UsuariosVigIni`, TM1.`UsuariosVigFin`, TM1.`UsuariosFecCap`, TM1.`UsuariosTelef`, TM1.`UsuariosCorreo`, T2.`RolNombre`, TM1.`UsuariosStatus`, TM1.`RolId`, TM1.`UsuariosIcono` FROM (`Usuarios` TM1 INNER JOIN `Roles` T2 ON T2.`RolId` = TM1.`RolId`) ORDER BY TM1.`UsuariosId`  LIMIT ?, ?",true, GxErrorMask.GX_NOMASK, false, this,prmBC00025,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00026", "SELECT TM1.`UsuariosId`, TM1.`UsuariosUsr`, TM1.`UsuariosIP`, TM1.`UsuariosFecNacimiento`, TM1.`UsuariosEdad`, TM1.`UsuariosCurp`, TM1.`UsuariosNombre`, TM1.`UsuariosApPat`, TM1.`UsuariosApMat`, TM1.`UsuariosTipo`, TM1.`UsuariosIcono_GXI`, TM1.`UsuariosSexo`, TM1.`UsuariosPwd`, TM1.`UsuariosKey`, TM1.`UsuariosVigIni`, TM1.`UsuariosVigFin`, TM1.`UsuariosFecCap`, TM1.`UsuariosTelef`, TM1.`UsuariosCorreo`, T2.`RolNombre`, TM1.`UsuariosStatus`, TM1.`RolId`, TM1.`UsuariosIcono` FROM (`Usuarios` TM1 INNER JOIN `Roles` T2 ON T2.`RolId` = TM1.`RolId`) WHERE TM1.`UsuariosId` = ? ORDER BY TM1.`UsuariosId` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00026,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00027", "SELECT `UsuariosId` FROM `Usuarios` WHERE `UsuariosId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00027,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00028", "INSERT INTO `Usuarios`(`UsuariosId`, `UsuariosUsr`, `UsuariosIP`, `UsuariosFecNacimiento`, `UsuariosEdad`, `UsuariosCurp`, `UsuariosNombre`, `UsuariosApPat`, `UsuariosApMat`, `UsuariosTipo`, `UsuariosIcono`, `UsuariosIcono_GXI`, `UsuariosSexo`, `UsuariosPwd`, `UsuariosKey`, `UsuariosVigIni`, `UsuariosVigFin`, `UsuariosFecCap`, `UsuariosTelef`, `UsuariosCorreo`, `UsuariosStatus`, `RolId`) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", GxErrorMask.GX_NOMASK,prmBC00028)
             ,new CursorDef("BC00029", "UPDATE `Usuarios` SET `UsuariosUsr`=?, `UsuariosIP`=?, `UsuariosFecNacimiento`=?, `UsuariosEdad`=?, `UsuariosCurp`=?, `UsuariosNombre`=?, `UsuariosApPat`=?, `UsuariosApMat`=?, `UsuariosTipo`=?, `UsuariosSexo`=?, `UsuariosPwd`=?, `UsuariosKey`=?, `UsuariosVigIni`=?, `UsuariosVigFin`=?, `UsuariosFecCap`=?, `UsuariosTelef`=?, `UsuariosCorreo`=?, `UsuariosStatus`=?, `RolId`=?  WHERE `UsuariosId` = ?", GxErrorMask.GX_NOMASK,prmBC00029)
             ,new CursorDef("BC000210", "UPDATE `Usuarios` SET `UsuariosIcono`=?, `UsuariosIcono_GXI`=?  WHERE `UsuariosId` = ?", GxErrorMask.GX_NOMASK,prmBC000210)
             ,new CursorDef("BC000211", "DELETE FROM `Usuarios`  WHERE `UsuariosId` = ?", GxErrorMask.GX_NOMASK,prmBC000211)
             ,new CursorDef("BC000212", "SELECT `RolNombre` FROM `Roles` WHERE `RolId` = ? ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000212,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000213", "SELECT `bitAccesFec`, `bitAccesIp` FROM `bitAcces` WHERE `UsuariosId` = ?  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmBC000213,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000214", "SELECT `Vacantes_Id`, `UsuariosId` FROM `VacantesUsuariosVacante` WHERE `SUBT_ReclutadorId` = ?  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmBC000214,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000215", "SELECT `Vacantes_Id`, `UsuariosId` FROM `VacantesUsuariosVacante` WHERE `UsuariosId` = ?  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmBC000215,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000216", "SELECT `Perfiles_Id`, `UsuariosId` FROM `PerfilesUsuariosPerfil` WHERE `UsuariosId` = ?  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmBC000216,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000217", "SELECT `UsuariosId`, `FechaIntento` FROM `Intentos` WHERE `UsuariosId` = ?  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmBC000217,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000218", "SELECT `UsuariosId`, `HisPwdFecha` FROM `HistPwd` WHERE `UsuariosId` = ?  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmBC000218,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000219", "SELECT TM1.`UsuariosId`, TM1.`UsuariosUsr`, TM1.`UsuariosIP`, TM1.`UsuariosFecNacimiento`, TM1.`UsuariosEdad`, TM1.`UsuariosCurp`, TM1.`UsuariosNombre`, TM1.`UsuariosApPat`, TM1.`UsuariosApMat`, TM1.`UsuariosTipo`, TM1.`UsuariosIcono_GXI`, TM1.`UsuariosSexo`, TM1.`UsuariosPwd`, TM1.`UsuariosKey`, TM1.`UsuariosVigIni`, TM1.`UsuariosVigFin`, TM1.`UsuariosFecCap`, TM1.`UsuariosTelef`, TM1.`UsuariosCorreo`, T2.`RolNombre`, TM1.`UsuariosStatus`, TM1.`RolId`, TM1.`UsuariosIcono` FROM (`Usuarios` TM1 INNER JOIN `Roles` T2 ON T2.`RolId` = TM1.`RolId`) WHERE TM1.`UsuariosId` = ? ORDER BY TM1.`UsuariosId` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000219,100, GxCacheFrequency.OFF ,true,false )
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
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4) ;
                ((short[]) buf[4])[0] = rslt.getShort(5) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
                ((String[]) buf[6])[0] = rslt.getVarchar(7) ;
                ((String[]) buf[7])[0] = rslt.getVarchar(8) ;
                ((String[]) buf[8])[0] = rslt.getVarchar(9) ;
                ((short[]) buf[9])[0] = rslt.getShort(10) ;
                ((String[]) buf[10])[0] = rslt.getMultimediaUri(11) ;
                ((String[]) buf[11])[0] = rslt.getString(12, 1) ;
                ((String[]) buf[12])[0] = rslt.getVarchar(13) ;
                ((String[]) buf[13])[0] = rslt.getVarchar(14) ;
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(15) ;
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(16) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(17) ;
                ((String[]) buf[18])[0] = rslt.getString(18, 10) ;
                ((String[]) buf[19])[0] = rslt.getVarchar(19) ;
                ((short[]) buf[20])[0] = rslt.getShort(20) ;
                ((int[]) buf[21])[0] = rslt.getInt(21) ;
                ((String[]) buf[22])[0] = rslt.getMultimediaFile(22, rslt.getVarchar(11)) ;
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4) ;
                ((short[]) buf[4])[0] = rslt.getShort(5) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
                ((String[]) buf[6])[0] = rslt.getVarchar(7) ;
                ((String[]) buf[7])[0] = rslt.getVarchar(8) ;
                ((String[]) buf[8])[0] = rslt.getVarchar(9) ;
                ((short[]) buf[9])[0] = rslt.getShort(10) ;
                ((String[]) buf[10])[0] = rslt.getMultimediaUri(11) ;
                ((String[]) buf[11])[0] = rslt.getString(12, 1) ;
                ((String[]) buf[12])[0] = rslt.getVarchar(13) ;
                ((String[]) buf[13])[0] = rslt.getVarchar(14) ;
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(15) ;
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(16) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(17) ;
                ((String[]) buf[18])[0] = rslt.getString(18, 10) ;
                ((String[]) buf[19])[0] = rslt.getVarchar(19) ;
                ((short[]) buf[20])[0] = rslt.getShort(20) ;
                ((int[]) buf[21])[0] = rslt.getInt(21) ;
                ((String[]) buf[22])[0] = rslt.getMultimediaFile(22, rslt.getVarchar(11)) ;
                return;
             case 2 :
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4) ;
                ((short[]) buf[4])[0] = rslt.getShort(5) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
                ((String[]) buf[6])[0] = rslt.getVarchar(7) ;
                ((String[]) buf[7])[0] = rslt.getVarchar(8) ;
                ((String[]) buf[8])[0] = rslt.getVarchar(9) ;
                ((short[]) buf[9])[0] = rslt.getShort(10) ;
                ((String[]) buf[10])[0] = rslt.getMultimediaUri(11) ;
                ((String[]) buf[11])[0] = rslt.getString(12, 1) ;
                ((String[]) buf[12])[0] = rslt.getVarchar(13) ;
                ((String[]) buf[13])[0] = rslt.getVarchar(14) ;
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(15) ;
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(16) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(17) ;
                ((String[]) buf[18])[0] = rslt.getString(18, 10) ;
                ((String[]) buf[19])[0] = rslt.getVarchar(19) ;
                ((String[]) buf[20])[0] = rslt.getVarchar(20) ;
                ((short[]) buf[21])[0] = rslt.getShort(21) ;
                ((int[]) buf[22])[0] = rslt.getInt(22) ;
                ((String[]) buf[23])[0] = rslt.getMultimediaFile(23, rslt.getVarchar(11)) ;
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4) ;
                ((short[]) buf[4])[0] = rslt.getShort(5) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
                ((String[]) buf[6])[0] = rslt.getVarchar(7) ;
                ((String[]) buf[7])[0] = rslt.getVarchar(8) ;
                ((String[]) buf[8])[0] = rslt.getVarchar(9) ;
                ((short[]) buf[9])[0] = rslt.getShort(10) ;
                ((String[]) buf[10])[0] = rslt.getMultimediaUri(11) ;
                ((String[]) buf[11])[0] = rslt.getString(12, 1) ;
                ((String[]) buf[12])[0] = rslt.getVarchar(13) ;
                ((String[]) buf[13])[0] = rslt.getVarchar(14) ;
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(15) ;
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(16) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(17) ;
                ((String[]) buf[18])[0] = rslt.getString(18, 10) ;
                ((String[]) buf[19])[0] = rslt.getVarchar(19) ;
                ((String[]) buf[20])[0] = rslt.getVarchar(20) ;
                ((short[]) buf[21])[0] = rslt.getShort(21) ;
                ((int[]) buf[22])[0] = rslt.getInt(22) ;
                ((String[]) buf[23])[0] = rslt.getMultimediaFile(23, rslt.getVarchar(11)) ;
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 10 :
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                return;
             case 11 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2) ;
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2) ;
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4) ;
                ((short[]) buf[4])[0] = rslt.getShort(5) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
                ((String[]) buf[6])[0] = rslt.getVarchar(7) ;
                ((String[]) buf[7])[0] = rslt.getVarchar(8) ;
                ((String[]) buf[8])[0] = rslt.getVarchar(9) ;
                ((short[]) buf[9])[0] = rslt.getShort(10) ;
                ((String[]) buf[10])[0] = rslt.getMultimediaUri(11) ;
                ((String[]) buf[11])[0] = rslt.getString(12, 1) ;
                ((String[]) buf[12])[0] = rslt.getVarchar(13) ;
                ((String[]) buf[13])[0] = rslt.getVarchar(14) ;
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(15) ;
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(16) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(17) ;
                ((String[]) buf[18])[0] = rslt.getString(18, 10) ;
                ((String[]) buf[19])[0] = rslt.getVarchar(19) ;
                ((String[]) buf[20])[0] = rslt.getVarchar(20) ;
                ((short[]) buf[21])[0] = rslt.getShort(21) ;
                ((int[]) buf[22])[0] = rslt.getInt(22) ;
                ((String[]) buf[23])[0] = rslt.getMultimediaFile(23, rslt.getVarchar(11)) ;
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
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 1 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 2 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 3 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
             case 4 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 5 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 6 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                stmt.SetParameter(2, (String)parms[2]);
                stmt.SetParameter(3, (String)parms[3]);
                stmt.SetParameter(4, (DateTime)parms[4]);
                stmt.SetParameter(5, (short)parms[5]);
                stmt.SetParameter(6, (String)parms[6]);
                stmt.SetParameter(7, (String)parms[7]);
                stmt.SetParameter(8, (String)parms[8]);
                stmt.SetParameter(9, (String)parms[9]);
                stmt.SetParameter(10, (short)parms[10]);
                stmt.SetParameterBlob(11, (String)parms[11], false);
                stmt.SetParameterMultimedia(12, (String)parms[12], (String)parms[11], "Usuarios", "UsuariosIcono");
                stmt.SetParameter(13, (String)parms[13]);
                stmt.SetParameter(14, (String)parms[14]);
                stmt.SetParameter(15, (String)parms[15]);
                stmt.SetParameter(16, (DateTime)parms[16]);
                if ( (bool)parms[17] )
                {
                   stmt.setNull( 17 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(17, (DateTime)parms[18]);
                }
                stmt.SetParameterDatetime(18, (DateTime)parms[19]);
                stmt.SetParameter(19, (String)parms[20]);
                stmt.SetParameter(20, (String)parms[21]);
                stmt.SetParameter(21, (short)parms[22]);
                stmt.SetParameter(22, (int)parms[23]);
                return;
             case 7 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (DateTime)parms[2]);
                stmt.SetParameter(4, (short)parms[3]);
                stmt.SetParameter(5, (String)parms[4]);
                stmt.SetParameter(6, (String)parms[5]);
                stmt.SetParameter(7, (String)parms[6]);
                stmt.SetParameter(8, (String)parms[7]);
                stmt.SetParameter(9, (short)parms[8]);
                stmt.SetParameter(10, (String)parms[9]);
                stmt.SetParameter(11, (String)parms[10]);
                stmt.SetParameter(12, (String)parms[11]);
                stmt.SetParameter(13, (DateTime)parms[12]);
                if ( (bool)parms[13] )
                {
                   stmt.setNull( 14 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(14, (DateTime)parms[14]);
                }
                stmt.SetParameterDatetime(15, (DateTime)parms[15]);
                stmt.SetParameter(16, (String)parms[16]);
                stmt.SetParameter(17, (String)parms[17]);
                stmt.SetParameter(18, (short)parms[18]);
                stmt.SetParameter(19, (int)parms[19]);
                if ( (bool)parms[20] )
                {
                   stmt.setNull( 20 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(20, (int)parms[21]);
                }
                return;
             case 8 :
                stmt.SetParameterBlob(1, (String)parms[0], false);
                stmt.SetParameterMultimedia(2, (String)parms[1], (String)parms[0], "Usuarios", "UsuariosIcono");
                if ( (bool)parms[2] )
                {
                   stmt.setNull( 3 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(3, (int)parms[3]);
                }
                return;
             case 9 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 10 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 11 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 12 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 13 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 14 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 15 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 16 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
             case 17 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(1, (int)parms[1]);
                }
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.usuarios_bc_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class usuarios_bc_services : GxRestService
 {
    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Bare  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/{sA11UsuariosId}")]
    public SdtUsuarios_RESTInterface Load( string sA11UsuariosId )
    {
       try
       {
          int A11UsuariosId ;
          bool n11UsuariosId ;
          A11UsuariosId = (int)(NumberUtil.Val( (String)(sA11UsuariosId), "."));
          n11UsuariosId = false;
          SdtUsuarios worker = new SdtUsuarios(context) ;
          SdtUsuarios_RESTInterface worker_interface = new SdtUsuarios_RESTInterface (worker);
          if ( StringUtil.StrCmp(sA11UsuariosId, "_default") == 0 )
          {
             IGxSilentTrn workertrn = worker.getTransaction() ;
             workertrn.GetInsDefault();
          }
          else
          {
             worker.Load(A11UsuariosId);
          }
          ((GXHttpHandler)worker.trn).IsMain = true ;
          if ( worker.Success() )
          {
             SetMessages(worker.trn.GetMessages());
             worker.trn.cleanup( );
             return worker_interface ;
          }
          else
          {
             worker.trn.cleanup( );
             ErrorCheck(worker.trn);
             return null ;
          }
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "DELETE" ,
    	BodyStyle =  WebMessageBodyStyle.Bare  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/{sA11UsuariosId}")]
    public SdtUsuarios_RESTInterface Delete( string sA11UsuariosId )
    {
       try
       {
          int A11UsuariosId ;
          bool n11UsuariosId ;
          A11UsuariosId = (int)(NumberUtil.Val( (String)(sA11UsuariosId), "."));
          n11UsuariosId = false;
          SdtUsuarios worker = new SdtUsuarios(context) ;
          SdtUsuarios_RESTInterface worker_interface = new SdtUsuarios_RESTInterface (worker);
          worker.Load(A11UsuariosId);
          worker.Delete();
          ((GXHttpHandler)worker.trn).IsMain = true ;
          if ( worker.Success() )
          {
             (( GXHttpHandler )worker.trn).context.CommitDataStores();
             SetMessages(worker.trn.GetMessages());
             worker.trn.cleanup( );
             return worker_interface ;
          }
          else
          {
             worker.trn.cleanup( );
             ErrorCheck(worker.trn);
             return null ;
          }
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Bare  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/{sA11UsuariosId}")]
    public SdtUsuarios_RESTInterface Insert( string sA11UsuariosId ,
                                             SdtUsuarios_RESTInterface entity )
    {
       try
       {
          int A11UsuariosId ;
          bool n11UsuariosId ;
          A11UsuariosId = (int)(NumberUtil.Val( (String)(sA11UsuariosId), "."));
          n11UsuariosId = false;
          SdtUsuarios worker = new SdtUsuarios(context) ;
          bool gxcheck = RestParameter("check", "true") ;
          bool gxinsertorupdate = RestParameter("insertorupdate", "true") ;
          SdtUsuarios_RESTInterface worker_interface = new SdtUsuarios_RESTInterface (worker);
          worker_interface.CopyFrom(entity);
          worker.gxTpr_Usuariosid = A11UsuariosId;
          if ( gxcheck )
          {
             worker.Check();
          }
          else
          {
             if ( gxinsertorupdate )
             {
                worker.InsertOrUpdate();
             }
             else
             {
                worker.Save();
             }
          }
          ((GXHttpHandler)worker.trn).IsMain = true ;
          if ( worker.Success() )
          {
             if ( ! gxcheck )
             {
                (( GXHttpHandler )worker.trn).context.CommitDataStores();
                SetStatusCode(System.Net.HttpStatusCode.Created);
             }
             SetMessages(worker.trn.GetMessages());
             worker.trn.cleanup( );
             return worker_interface ;
          }
          else
          {
             worker.trn.cleanup( );
             ErrorCheck(worker.trn);
             return null ;
          }
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "PUT" ,
    	BodyStyle =  WebMessageBodyStyle.Bare  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/{sA11UsuariosId}")]
    public SdtUsuarios_RESTInterface Update( string sA11UsuariosId ,
                                             SdtUsuarios_RESTInterface entity )
    {
       try
       {
          int A11UsuariosId ;
          bool n11UsuariosId ;
          A11UsuariosId = (int)(NumberUtil.Val( (String)(sA11UsuariosId), "."));
          n11UsuariosId = false;
          SdtUsuarios worker = new SdtUsuarios(context) ;
          SdtUsuarios_RESTInterface worker_interface = new SdtUsuarios_RESTInterface (worker);
          bool gxcheck = RestParameter("check", "true") ;
          worker.Load(A11UsuariosId);
          if (entity.Hash == worker_interface.Hash) {
             worker_interface.CopyFrom(entity);
             worker.gxTpr_Usuariosid = A11UsuariosId;
             if ( gxcheck )
             {
                worker.Check();
             }
             else
             {
                worker.Save();
             }
             ((GXHttpHandler)worker.trn).IsMain = true ;
             if ( worker.Success() )
             {
                if ( ! gxcheck )
                {
                   (( GXHttpHandler )worker.trn).context.CommitDataStores();
                }
                SetMessages(worker.trn.GetMessages());
                worker.trn.cleanup( );
                worker_interface.Hash = null;
                return worker_interface ;
             }
             else
             {
                worker.trn.cleanup( );
                ErrorCheck(worker.trn);
                return null ;
             }
          }
          else
          {
             SetError( "409", (( GXHttpHandler )worker.trn). context.GetMessage( "GXM_waschg", new   object[]  {"Usuarios"}) );
          }
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

 }

}
