using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "Usuarios" )]
   [XmlType(TypeName =  "Usuarios" , Namespace = "ADMINDATA1" )]
   [Serializable]
   public class SdtUsuarios : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtUsuarios( )
      {
      }

      public SdtUsuarios( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetCallingAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override String JsonMap( String value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (String)mapper[value]; ;
      }

      public void Load( int AV11UsuariosId )
      {
         IGxSilentTrn obj ;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV11UsuariosId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"UsuariosId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties() ;
         metadata.Set("Name", "Usuarios");
         metadata.Set("BT", "Usuarios");
         metadata.Set("PK", "[ \"UsuariosId\" ]");
         metadata.Set("PKAssigned", "[ \"UsuariosId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"RolId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection() ;
         state.Add("gxTpr_Usuariosicono_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Usuariosid_Z");
         state.Add("gxTpr_Usuarioscurp_Z");
         state.Add("gxTpr_Usuariosnombre_Z");
         state.Add("gxTpr_Usuariosappat_Z");
         state.Add("gxTpr_Usuariosapmat_Z");
         state.Add("gxTpr_Usuariosusr_Z");
         state.Add("gxTpr_Usuariostipo_Z");
         state.Add("gxTpr_Usuariosfecnacimiento_Z_Nullable");
         state.Add("gxTpr_Usuariosedad_Z");
         state.Add("gxTpr_Usuariossexo_Z");
         state.Add("gxTpr_Usuariospwd_Z");
         state.Add("gxTpr_Usuarioskey_Z");
         state.Add("gxTpr_Usuariosvigini_Z_Nullable");
         state.Add("gxTpr_Usuariosvigfin_Z_Nullable");
         state.Add("gxTpr_Usuariosfeccap_Z_Nullable");
         state.Add("gxTpr_Usuariosip_Z");
         state.Add("gxTpr_Usuariostelef_Z");
         state.Add("gxTpr_Usuarioscorreo_Z");
         state.Add("gxTpr_Usuariosnomcompleto_Z");
         state.Add("gxTpr_Rolid_Z");
         state.Add("gxTpr_Rolnombre_Z");
         state.Add("gxTpr_Usuariossexofor_Z");
         state.Add("gxTpr_Usuariosstatus_Z");
         state.Add("gxTpr_Usuariosicono_gxi_Z");
         state.Add("gxTpr_Usuariosid_N");
         state.Add("gxTpr_Usuariosvigfin_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtUsuarios sdt ;
         sdt = (SdtUsuarios)(source);
         gxTv_SdtUsuarios_Usuariosid = sdt.gxTv_SdtUsuarios_Usuariosid ;
         gxTv_SdtUsuarios_Usuarioscurp = sdt.gxTv_SdtUsuarios_Usuarioscurp ;
         gxTv_SdtUsuarios_Usuariosnombre = sdt.gxTv_SdtUsuarios_Usuariosnombre ;
         gxTv_SdtUsuarios_Usuariosappat = sdt.gxTv_SdtUsuarios_Usuariosappat ;
         gxTv_SdtUsuarios_Usuariosapmat = sdt.gxTv_SdtUsuarios_Usuariosapmat ;
         gxTv_SdtUsuarios_Usuariosusr = sdt.gxTv_SdtUsuarios_Usuariosusr ;
         gxTv_SdtUsuarios_Usuariostipo = sdt.gxTv_SdtUsuarios_Usuariostipo ;
         gxTv_SdtUsuarios_Usuariosicono = sdt.gxTv_SdtUsuarios_Usuariosicono ;
         gxTv_SdtUsuarios_Usuariosicono_gxi = sdt.gxTv_SdtUsuarios_Usuariosicono_gxi ;
         gxTv_SdtUsuarios_Usuariosfecnacimiento = sdt.gxTv_SdtUsuarios_Usuariosfecnacimiento ;
         gxTv_SdtUsuarios_Usuariosedad = sdt.gxTv_SdtUsuarios_Usuariosedad ;
         gxTv_SdtUsuarios_Usuariossexo = sdt.gxTv_SdtUsuarios_Usuariossexo ;
         gxTv_SdtUsuarios_Usuariospwd = sdt.gxTv_SdtUsuarios_Usuariospwd ;
         gxTv_SdtUsuarios_Usuarioskey = sdt.gxTv_SdtUsuarios_Usuarioskey ;
         gxTv_SdtUsuarios_Usuariosvigini = sdt.gxTv_SdtUsuarios_Usuariosvigini ;
         gxTv_SdtUsuarios_Usuariosvigfin = sdt.gxTv_SdtUsuarios_Usuariosvigfin ;
         gxTv_SdtUsuarios_Usuariosfeccap = sdt.gxTv_SdtUsuarios_Usuariosfeccap ;
         gxTv_SdtUsuarios_Usuariosip = sdt.gxTv_SdtUsuarios_Usuariosip ;
         gxTv_SdtUsuarios_Usuariostelef = sdt.gxTv_SdtUsuarios_Usuariostelef ;
         gxTv_SdtUsuarios_Usuarioscorreo = sdt.gxTv_SdtUsuarios_Usuarioscorreo ;
         gxTv_SdtUsuarios_Usuariosnomcompleto = sdt.gxTv_SdtUsuarios_Usuariosnomcompleto ;
         gxTv_SdtUsuarios_Rolid = sdt.gxTv_SdtUsuarios_Rolid ;
         gxTv_SdtUsuarios_Rolnombre = sdt.gxTv_SdtUsuarios_Rolnombre ;
         gxTv_SdtUsuarios_Usuariossexofor = sdt.gxTv_SdtUsuarios_Usuariossexofor ;
         gxTv_SdtUsuarios_Usuariosstatus = sdt.gxTv_SdtUsuarios_Usuariosstatus ;
         gxTv_SdtUsuarios_Mode = sdt.gxTv_SdtUsuarios_Mode ;
         gxTv_SdtUsuarios_Initialized = sdt.gxTv_SdtUsuarios_Initialized ;
         gxTv_SdtUsuarios_Usuariosid_Z = sdt.gxTv_SdtUsuarios_Usuariosid_Z ;
         gxTv_SdtUsuarios_Usuarioscurp_Z = sdt.gxTv_SdtUsuarios_Usuarioscurp_Z ;
         gxTv_SdtUsuarios_Usuariosnombre_Z = sdt.gxTv_SdtUsuarios_Usuariosnombre_Z ;
         gxTv_SdtUsuarios_Usuariosappat_Z = sdt.gxTv_SdtUsuarios_Usuariosappat_Z ;
         gxTv_SdtUsuarios_Usuariosapmat_Z = sdt.gxTv_SdtUsuarios_Usuariosapmat_Z ;
         gxTv_SdtUsuarios_Usuariosusr_Z = sdt.gxTv_SdtUsuarios_Usuariosusr_Z ;
         gxTv_SdtUsuarios_Usuariostipo_Z = sdt.gxTv_SdtUsuarios_Usuariostipo_Z ;
         gxTv_SdtUsuarios_Usuariosfecnacimiento_Z = sdt.gxTv_SdtUsuarios_Usuariosfecnacimiento_Z ;
         gxTv_SdtUsuarios_Usuariosedad_Z = sdt.gxTv_SdtUsuarios_Usuariosedad_Z ;
         gxTv_SdtUsuarios_Usuariossexo_Z = sdt.gxTv_SdtUsuarios_Usuariossexo_Z ;
         gxTv_SdtUsuarios_Usuariospwd_Z = sdt.gxTv_SdtUsuarios_Usuariospwd_Z ;
         gxTv_SdtUsuarios_Usuarioskey_Z = sdt.gxTv_SdtUsuarios_Usuarioskey_Z ;
         gxTv_SdtUsuarios_Usuariosvigini_Z = sdt.gxTv_SdtUsuarios_Usuariosvigini_Z ;
         gxTv_SdtUsuarios_Usuariosvigfin_Z = sdt.gxTv_SdtUsuarios_Usuariosvigfin_Z ;
         gxTv_SdtUsuarios_Usuariosfeccap_Z = sdt.gxTv_SdtUsuarios_Usuariosfeccap_Z ;
         gxTv_SdtUsuarios_Usuariosip_Z = sdt.gxTv_SdtUsuarios_Usuariosip_Z ;
         gxTv_SdtUsuarios_Usuariostelef_Z = sdt.gxTv_SdtUsuarios_Usuariostelef_Z ;
         gxTv_SdtUsuarios_Usuarioscorreo_Z = sdt.gxTv_SdtUsuarios_Usuarioscorreo_Z ;
         gxTv_SdtUsuarios_Usuariosnomcompleto_Z = sdt.gxTv_SdtUsuarios_Usuariosnomcompleto_Z ;
         gxTv_SdtUsuarios_Rolid_Z = sdt.gxTv_SdtUsuarios_Rolid_Z ;
         gxTv_SdtUsuarios_Rolnombre_Z = sdt.gxTv_SdtUsuarios_Rolnombre_Z ;
         gxTv_SdtUsuarios_Usuariossexofor_Z = sdt.gxTv_SdtUsuarios_Usuariossexofor_Z ;
         gxTv_SdtUsuarios_Usuariosstatus_Z = sdt.gxTv_SdtUsuarios_Usuariosstatus_Z ;
         gxTv_SdtUsuarios_Usuariosicono_gxi_Z = sdt.gxTv_SdtUsuarios_Usuariosicono_gxi_Z ;
         gxTv_SdtUsuarios_Usuariosid_N = sdt.gxTv_SdtUsuarios_Usuariosid_N ;
         gxTv_SdtUsuarios_Usuariosvigfin_N = sdt.gxTv_SdtUsuarios_Usuariosvigfin_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("UsuariosId", gxTv_SdtUsuarios_Usuariosid, false, includeNonInitialized);
         AddObjectProperty("UsuariosId_N", gxTv_SdtUsuarios_Usuariosid_N, false, includeNonInitialized);
         AddObjectProperty("UsuariosCurp", gxTv_SdtUsuarios_Usuarioscurp, false, includeNonInitialized);
         AddObjectProperty("UsuariosNombre", gxTv_SdtUsuarios_Usuariosnombre, false, includeNonInitialized);
         AddObjectProperty("UsuariosApPat", gxTv_SdtUsuarios_Usuariosappat, false, includeNonInitialized);
         AddObjectProperty("UsuariosApMat", gxTv_SdtUsuarios_Usuariosapmat, false, includeNonInitialized);
         AddObjectProperty("UsuariosUsr", gxTv_SdtUsuarios_Usuariosusr, false, includeNonInitialized);
         AddObjectProperty("UsuariosTipo", gxTv_SdtUsuarios_Usuariostipo, false, includeNonInitialized);
         AddObjectProperty("UsuariosIcono", gxTv_SdtUsuarios_Usuariosicono, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtUsuarios_Usuariosfecnacimiento)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtUsuarios_Usuariosfecnacimiento)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtUsuarios_Usuariosfecnacimiento)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("UsuariosFecNacimiento", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("UsuariosEdad", gxTv_SdtUsuarios_Usuariosedad, false, includeNonInitialized);
         AddObjectProperty("UsuariosSexo", gxTv_SdtUsuarios_Usuariossexo, false, includeNonInitialized);
         AddObjectProperty("UsuariosPwd", gxTv_SdtUsuarios_Usuariospwd, false, includeNonInitialized);
         AddObjectProperty("UsuariosKey", gxTv_SdtUsuarios_Usuarioskey, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtUsuarios_Usuariosvigini)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtUsuarios_Usuariosvigini)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtUsuarios_Usuariosvigini)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("UsuariosVigIni", sDateCnv, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtUsuarios_Usuariosvigfin)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtUsuarios_Usuariosvigfin)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtUsuarios_Usuariosvigfin)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("UsuariosVigFin", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("UsuariosVigFin_N", gxTv_SdtUsuarios_Usuariosvigfin_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtUsuarios_Usuariosfeccap;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("UsuariosFecCap", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("UsuariosIP", gxTv_SdtUsuarios_Usuariosip, false, includeNonInitialized);
         AddObjectProperty("UsuariosTelef", gxTv_SdtUsuarios_Usuariostelef, false, includeNonInitialized);
         AddObjectProperty("UsuariosCorreo", gxTv_SdtUsuarios_Usuarioscorreo, false, includeNonInitialized);
         AddObjectProperty("UsuariosNomCompleto", gxTv_SdtUsuarios_Usuariosnomcompleto, false, includeNonInitialized);
         AddObjectProperty("RolId", gxTv_SdtUsuarios_Rolid, false, includeNonInitialized);
         AddObjectProperty("RolNombre", gxTv_SdtUsuarios_Rolnombre, false, includeNonInitialized);
         AddObjectProperty("UsuariosSexoFor", gxTv_SdtUsuarios_Usuariossexofor, false, includeNonInitialized);
         AddObjectProperty("UsuariosStatus", gxTv_SdtUsuarios_Usuariosstatus, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("UsuariosIcono_GXI", gxTv_SdtUsuarios_Usuariosicono_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtUsuarios_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtUsuarios_Initialized, false, includeNonInitialized);
            AddObjectProperty("UsuariosId_Z", gxTv_SdtUsuarios_Usuariosid_Z, false, includeNonInitialized);
            AddObjectProperty("UsuariosCurp_Z", gxTv_SdtUsuarios_Usuarioscurp_Z, false, includeNonInitialized);
            AddObjectProperty("UsuariosNombre_Z", gxTv_SdtUsuarios_Usuariosnombre_Z, false, includeNonInitialized);
            AddObjectProperty("UsuariosApPat_Z", gxTv_SdtUsuarios_Usuariosappat_Z, false, includeNonInitialized);
            AddObjectProperty("UsuariosApMat_Z", gxTv_SdtUsuarios_Usuariosapmat_Z, false, includeNonInitialized);
            AddObjectProperty("UsuariosUsr_Z", gxTv_SdtUsuarios_Usuariosusr_Z, false, includeNonInitialized);
            AddObjectProperty("UsuariosTipo_Z", gxTv_SdtUsuarios_Usuariostipo_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtUsuarios_Usuariosfecnacimiento_Z)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv = sDateCnv + "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtUsuarios_Usuariosfecnacimiento_Z)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv = sDateCnv + "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtUsuarios_Usuariosfecnacimiento_Z)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("UsuariosFecNacimiento_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("UsuariosEdad_Z", gxTv_SdtUsuarios_Usuariosedad_Z, false, includeNonInitialized);
            AddObjectProperty("UsuariosSexo_Z", gxTv_SdtUsuarios_Usuariossexo_Z, false, includeNonInitialized);
            AddObjectProperty("UsuariosPwd_Z", gxTv_SdtUsuarios_Usuariospwd_Z, false, includeNonInitialized);
            AddObjectProperty("UsuariosKey_Z", gxTv_SdtUsuarios_Usuarioskey_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtUsuarios_Usuariosvigini_Z)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv = sDateCnv + "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtUsuarios_Usuariosvigini_Z)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv = sDateCnv + "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtUsuarios_Usuariosvigini_Z)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("UsuariosVigIni_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtUsuarios_Usuariosvigfin_Z)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv = sDateCnv + "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtUsuarios_Usuariosvigfin_Z)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv = sDateCnv + "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtUsuarios_Usuariosvigfin_Z)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("UsuariosVigFin_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtUsuarios_Usuariosfeccap_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv = sDateCnv + "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv = sDateCnv + "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv = sDateCnv + "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv = sDateCnv + ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv = sDateCnv + ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("UsuariosFecCap_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("UsuariosIP_Z", gxTv_SdtUsuarios_Usuariosip_Z, false, includeNonInitialized);
            AddObjectProperty("UsuariosTelef_Z", gxTv_SdtUsuarios_Usuariostelef_Z, false, includeNonInitialized);
            AddObjectProperty("UsuariosCorreo_Z", gxTv_SdtUsuarios_Usuarioscorreo_Z, false, includeNonInitialized);
            AddObjectProperty("UsuariosNomCompleto_Z", gxTv_SdtUsuarios_Usuariosnomcompleto_Z, false, includeNonInitialized);
            AddObjectProperty("RolId_Z", gxTv_SdtUsuarios_Rolid_Z, false, includeNonInitialized);
            AddObjectProperty("RolNombre_Z", gxTv_SdtUsuarios_Rolnombre_Z, false, includeNonInitialized);
            AddObjectProperty("UsuariosSexoFor_Z", gxTv_SdtUsuarios_Usuariossexofor_Z, false, includeNonInitialized);
            AddObjectProperty("UsuariosStatus_Z", gxTv_SdtUsuarios_Usuariosstatus_Z, false, includeNonInitialized);
            AddObjectProperty("UsuariosIcono_GXI_Z", gxTv_SdtUsuarios_Usuariosicono_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("UsuariosId_N", gxTv_SdtUsuarios_Usuariosid_N, false, includeNonInitialized);
            AddObjectProperty("UsuariosVigFin_N", gxTv_SdtUsuarios_Usuariosvigfin_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtUsuarios sdt )
      {
         if ( sdt.IsDirty("UsuariosId") )
         {
            gxTv_SdtUsuarios_Usuariosid = sdt.gxTv_SdtUsuarios_Usuariosid ;
         }
         if ( sdt.IsDirty("UsuariosCurp") )
         {
            gxTv_SdtUsuarios_Usuarioscurp = sdt.gxTv_SdtUsuarios_Usuarioscurp ;
         }
         if ( sdt.IsDirty("UsuariosNombre") )
         {
            gxTv_SdtUsuarios_Usuariosnombre = sdt.gxTv_SdtUsuarios_Usuariosnombre ;
         }
         if ( sdt.IsDirty("UsuariosApPat") )
         {
            gxTv_SdtUsuarios_Usuariosappat = sdt.gxTv_SdtUsuarios_Usuariosappat ;
         }
         if ( sdt.IsDirty("UsuariosApMat") )
         {
            gxTv_SdtUsuarios_Usuariosapmat = sdt.gxTv_SdtUsuarios_Usuariosapmat ;
         }
         if ( sdt.IsDirty("UsuariosUsr") )
         {
            gxTv_SdtUsuarios_Usuariosusr = sdt.gxTv_SdtUsuarios_Usuariosusr ;
         }
         if ( sdt.IsDirty("UsuariosTipo") )
         {
            gxTv_SdtUsuarios_Usuariostipo = sdt.gxTv_SdtUsuarios_Usuariostipo ;
         }
         if ( sdt.IsDirty("UsuariosIcono") )
         {
            gxTv_SdtUsuarios_Usuariosicono = sdt.gxTv_SdtUsuarios_Usuariosicono ;
         }
         if ( sdt.IsDirty("UsuariosIcono") )
         {
            gxTv_SdtUsuarios_Usuariosicono_gxi = sdt.gxTv_SdtUsuarios_Usuariosicono_gxi ;
         }
         if ( sdt.IsDirty("UsuariosFecNacimiento") )
         {
            gxTv_SdtUsuarios_Usuariosfecnacimiento = sdt.gxTv_SdtUsuarios_Usuariosfecnacimiento ;
         }
         if ( sdt.IsDirty("UsuariosEdad") )
         {
            gxTv_SdtUsuarios_Usuariosedad = sdt.gxTv_SdtUsuarios_Usuariosedad ;
         }
         if ( sdt.IsDirty("UsuariosSexo") )
         {
            gxTv_SdtUsuarios_Usuariossexo = sdt.gxTv_SdtUsuarios_Usuariossexo ;
         }
         if ( sdt.IsDirty("UsuariosPwd") )
         {
            gxTv_SdtUsuarios_Usuariospwd = sdt.gxTv_SdtUsuarios_Usuariospwd ;
         }
         if ( sdt.IsDirty("UsuariosKey") )
         {
            gxTv_SdtUsuarios_Usuarioskey = sdt.gxTv_SdtUsuarios_Usuarioskey ;
         }
         if ( sdt.IsDirty("UsuariosVigIni") )
         {
            gxTv_SdtUsuarios_Usuariosvigini = sdt.gxTv_SdtUsuarios_Usuariosvigini ;
         }
         if ( sdt.IsDirty("UsuariosVigFin") )
         {
            gxTv_SdtUsuarios_Usuariosvigfin_N = 0;
            gxTv_SdtUsuarios_Usuariosvigfin = sdt.gxTv_SdtUsuarios_Usuariosvigfin ;
         }
         if ( sdt.IsDirty("UsuariosFecCap") )
         {
            gxTv_SdtUsuarios_Usuariosfeccap = sdt.gxTv_SdtUsuarios_Usuariosfeccap ;
         }
         if ( sdt.IsDirty("UsuariosIP") )
         {
            gxTv_SdtUsuarios_Usuariosip = sdt.gxTv_SdtUsuarios_Usuariosip ;
         }
         if ( sdt.IsDirty("UsuariosTelef") )
         {
            gxTv_SdtUsuarios_Usuariostelef = sdt.gxTv_SdtUsuarios_Usuariostelef ;
         }
         if ( sdt.IsDirty("UsuariosCorreo") )
         {
            gxTv_SdtUsuarios_Usuarioscorreo = sdt.gxTv_SdtUsuarios_Usuarioscorreo ;
         }
         if ( sdt.IsDirty("UsuariosNomCompleto") )
         {
            gxTv_SdtUsuarios_Usuariosnomcompleto = sdt.gxTv_SdtUsuarios_Usuariosnomcompleto ;
         }
         if ( sdt.IsDirty("RolId") )
         {
            gxTv_SdtUsuarios_Rolid = sdt.gxTv_SdtUsuarios_Rolid ;
         }
         if ( sdt.IsDirty("RolNombre") )
         {
            gxTv_SdtUsuarios_Rolnombre = sdt.gxTv_SdtUsuarios_Rolnombre ;
         }
         if ( sdt.IsDirty("UsuariosSexoFor") )
         {
            gxTv_SdtUsuarios_Usuariossexofor = sdt.gxTv_SdtUsuarios_Usuariossexofor ;
         }
         if ( sdt.IsDirty("UsuariosStatus") )
         {
            gxTv_SdtUsuarios_Usuariosstatus = sdt.gxTv_SdtUsuarios_Usuariosstatus ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "UsuariosId" )]
      [  XmlElement( ElementName = "UsuariosId"   )]
      public int gxTpr_Usuariosid
      {
         get {
            return gxTv_SdtUsuarios_Usuariosid ;
         }

         set {
            if ( gxTv_SdtUsuarios_Usuariosid != value )
            {
               gxTv_SdtUsuarios_Mode = "INS";
               this.gxTv_SdtUsuarios_Usuariosid_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuarioscurp_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuariosnombre_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuariosappat_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuariosapmat_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuariosusr_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuariostipo_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuariosfecnacimiento_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuariosedad_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuariossexo_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuariospwd_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuarioskey_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuariosvigini_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuariosvigfin_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuariosfeccap_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuariosip_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuariostelef_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuarioscorreo_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuariosnomcompleto_Z_SetNull( );
               this.gxTv_SdtUsuarios_Rolid_Z_SetNull( );
               this.gxTv_SdtUsuarios_Rolnombre_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuariossexofor_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuariosstatus_Z_SetNull( );
               this.gxTv_SdtUsuarios_Usuariosicono_gxi_Z_SetNull( );
            }
            gxTv_SdtUsuarios_Usuariosid = value;
            SetDirty("Usuariosid");
         }

      }

      [  SoapElement( ElementName = "UsuariosCurp" )]
      [  XmlElement( ElementName = "UsuariosCurp"   )]
      public String gxTpr_Usuarioscurp
      {
         get {
            return gxTv_SdtUsuarios_Usuarioscurp ;
         }

         set {
            gxTv_SdtUsuarios_Usuarioscurp = value;
            SetDirty("Usuarioscurp");
         }

      }

      [  SoapElement( ElementName = "UsuariosNombre" )]
      [  XmlElement( ElementName = "UsuariosNombre"   )]
      public String gxTpr_Usuariosnombre
      {
         get {
            return gxTv_SdtUsuarios_Usuariosnombre ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosnombre = value;
            SetDirty("Usuariosnombre");
         }

      }

      [  SoapElement( ElementName = "UsuariosApPat" )]
      [  XmlElement( ElementName = "UsuariosApPat"   )]
      public String gxTpr_Usuariosappat
      {
         get {
            return gxTv_SdtUsuarios_Usuariosappat ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosappat = value;
            SetDirty("Usuariosappat");
         }

      }

      [  SoapElement( ElementName = "UsuariosApMat" )]
      [  XmlElement( ElementName = "UsuariosApMat"   )]
      public String gxTpr_Usuariosapmat
      {
         get {
            return gxTv_SdtUsuarios_Usuariosapmat ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosapmat = value;
            SetDirty("Usuariosapmat");
         }

      }

      [  SoapElement( ElementName = "UsuariosUsr" )]
      [  XmlElement( ElementName = "UsuariosUsr"   )]
      public String gxTpr_Usuariosusr
      {
         get {
            return gxTv_SdtUsuarios_Usuariosusr ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosusr = value;
            SetDirty("Usuariosusr");
         }

      }

      [  SoapElement( ElementName = "UsuariosTipo" )]
      [  XmlElement( ElementName = "UsuariosTipo"   )]
      public short gxTpr_Usuariostipo
      {
         get {
            return gxTv_SdtUsuarios_Usuariostipo ;
         }

         set {
            gxTv_SdtUsuarios_Usuariostipo = value;
            SetDirty("Usuariostipo");
         }

      }

      [  SoapElement( ElementName = "UsuariosIcono" )]
      [  XmlElement( ElementName = "UsuariosIcono"   )]
      [GxUpload()]
      public String gxTpr_Usuariosicono
      {
         get {
            return gxTv_SdtUsuarios_Usuariosicono ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosicono = value;
            SetDirty("Usuariosicono");
         }

      }

      [  SoapElement( ElementName = "UsuariosIcono_GXI" )]
      [  XmlElement( ElementName = "UsuariosIcono_GXI"   )]
      public String gxTpr_Usuariosicono_gxi
      {
         get {
            return gxTv_SdtUsuarios_Usuariosicono_gxi ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosicono_gxi = value;
            SetDirty("Usuariosicono_gxi");
         }

      }

      [  SoapElement( ElementName = "UsuariosFecNacimiento" )]
      [  XmlElement( ElementName = "UsuariosFecNacimiento"  , IsNullable=true )]
      public string gxTpr_Usuariosfecnacimiento_Nullable
      {
         get {
            if ( gxTv_SdtUsuarios_Usuariosfecnacimiento == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtUsuarios_Usuariosfecnacimiento).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtUsuarios_Usuariosfecnacimiento = DateTime.MinValue;
            else
               gxTv_SdtUsuarios_Usuariosfecnacimiento = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Usuariosfecnacimiento
      {
         get {
            return gxTv_SdtUsuarios_Usuariosfecnacimiento ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosfecnacimiento = value;
            SetDirty("Usuariosfecnacimiento");
         }

      }

      [  SoapElement( ElementName = "UsuariosEdad" )]
      [  XmlElement( ElementName = "UsuariosEdad"   )]
      public short gxTpr_Usuariosedad
      {
         get {
            return gxTv_SdtUsuarios_Usuariosedad ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosedad = value;
            SetDirty("Usuariosedad");
         }

      }

      [  SoapElement( ElementName = "UsuariosSexo" )]
      [  XmlElement( ElementName = "UsuariosSexo"   )]
      public String gxTpr_Usuariossexo
      {
         get {
            return gxTv_SdtUsuarios_Usuariossexo ;
         }

         set {
            gxTv_SdtUsuarios_Usuariossexo = value;
            SetDirty("Usuariossexo");
         }

      }

      [  SoapElement( ElementName = "UsuariosPwd" )]
      [  XmlElement( ElementName = "UsuariosPwd"   )]
      public String gxTpr_Usuariospwd
      {
         get {
            return gxTv_SdtUsuarios_Usuariospwd ;
         }

         set {
            gxTv_SdtUsuarios_Usuariospwd = value;
            SetDirty("Usuariospwd");
         }

      }

      [  SoapElement( ElementName = "UsuariosKey" )]
      [  XmlElement( ElementName = "UsuariosKey"   )]
      public String gxTpr_Usuarioskey
      {
         get {
            return gxTv_SdtUsuarios_Usuarioskey ;
         }

         set {
            gxTv_SdtUsuarios_Usuarioskey = value;
            SetDirty("Usuarioskey");
         }

      }

      [  SoapElement( ElementName = "UsuariosVigIni" )]
      [  XmlElement( ElementName = "UsuariosVigIni"  , IsNullable=true )]
      public string gxTpr_Usuariosvigini_Nullable
      {
         get {
            if ( gxTv_SdtUsuarios_Usuariosvigini == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtUsuarios_Usuariosvigini).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtUsuarios_Usuariosvigini = DateTime.MinValue;
            else
               gxTv_SdtUsuarios_Usuariosvigini = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Usuariosvigini
      {
         get {
            return gxTv_SdtUsuarios_Usuariosvigini ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosvigini = value;
            SetDirty("Usuariosvigini");
         }

      }

      [  SoapElement( ElementName = "UsuariosVigFin" )]
      [  XmlElement( ElementName = "UsuariosVigFin"  , IsNullable=true )]
      public string gxTpr_Usuariosvigfin_Nullable
      {
         get {
            if ( gxTv_SdtUsuarios_Usuariosvigfin == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtUsuarios_Usuariosvigfin).value ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosvigfin_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtUsuarios_Usuariosvigfin = DateTime.MinValue;
            else
               gxTv_SdtUsuarios_Usuariosvigfin = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Usuariosvigfin
      {
         get {
            return gxTv_SdtUsuarios_Usuariosvigfin ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosvigfin_N = 0;
            gxTv_SdtUsuarios_Usuariosvigfin = value;
            SetDirty("Usuariosvigfin");
         }

      }

      public void gxTv_SdtUsuarios_Usuariosvigfin_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariosvigfin_N = 1;
         gxTv_SdtUsuarios_Usuariosvigfin = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariosvigfin_IsNull( )
      {
         return (gxTv_SdtUsuarios_Usuariosvigfin_N==1) ;
      }

      [  SoapElement( ElementName = "UsuariosFecCap" )]
      [  XmlElement( ElementName = "UsuariosFecCap"  , IsNullable=true )]
      public string gxTpr_Usuariosfeccap_Nullable
      {
         get {
            if ( gxTv_SdtUsuarios_Usuariosfeccap == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtUsuarios_Usuariosfeccap).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtUsuarios_Usuariosfeccap = DateTime.MinValue;
            else
               gxTv_SdtUsuarios_Usuariosfeccap = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Usuariosfeccap
      {
         get {
            return gxTv_SdtUsuarios_Usuariosfeccap ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosfeccap = value;
            SetDirty("Usuariosfeccap");
         }

      }

      [  SoapElement( ElementName = "UsuariosIP" )]
      [  XmlElement( ElementName = "UsuariosIP"   )]
      public String gxTpr_Usuariosip
      {
         get {
            return gxTv_SdtUsuarios_Usuariosip ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosip = value;
            SetDirty("Usuariosip");
         }

      }

      [  SoapElement( ElementName = "UsuariosTelef" )]
      [  XmlElement( ElementName = "UsuariosTelef"   )]
      public String gxTpr_Usuariostelef
      {
         get {
            return gxTv_SdtUsuarios_Usuariostelef ;
         }

         set {
            gxTv_SdtUsuarios_Usuariostelef = value;
            SetDirty("Usuariostelef");
         }

      }

      [  SoapElement( ElementName = "UsuariosCorreo" )]
      [  XmlElement( ElementName = "UsuariosCorreo"   )]
      public String gxTpr_Usuarioscorreo
      {
         get {
            return gxTv_SdtUsuarios_Usuarioscorreo ;
         }

         set {
            gxTv_SdtUsuarios_Usuarioscorreo = value;
            SetDirty("Usuarioscorreo");
         }

      }

      [  SoapElement( ElementName = "UsuariosNomCompleto" )]
      [  XmlElement( ElementName = "UsuariosNomCompleto"   )]
      public String gxTpr_Usuariosnomcompleto
      {
         get {
            return gxTv_SdtUsuarios_Usuariosnomcompleto ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosnomcompleto = value;
            SetDirty("Usuariosnomcompleto");
         }

      }

      public void gxTv_SdtUsuarios_Usuariosnomcompleto_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariosnomcompleto = "";
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariosnomcompleto_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RolId" )]
      [  XmlElement( ElementName = "RolId"   )]
      public int gxTpr_Rolid
      {
         get {
            return gxTv_SdtUsuarios_Rolid ;
         }

         set {
            gxTv_SdtUsuarios_Rolid = value;
            SetDirty("Rolid");
         }

      }

      [  SoapElement( ElementName = "RolNombre" )]
      [  XmlElement( ElementName = "RolNombre"   )]
      public String gxTpr_Rolnombre
      {
         get {
            return gxTv_SdtUsuarios_Rolnombre ;
         }

         set {
            gxTv_SdtUsuarios_Rolnombre = value;
            SetDirty("Rolnombre");
         }

      }

      [  SoapElement( ElementName = "UsuariosSexoFor" )]
      [  XmlElement( ElementName = "UsuariosSexoFor"   )]
      public String gxTpr_Usuariossexofor
      {
         get {
            return gxTv_SdtUsuarios_Usuariossexofor ;
         }

         set {
            gxTv_SdtUsuarios_Usuariossexofor = value;
            SetDirty("Usuariossexofor");
         }

      }

      public void gxTv_SdtUsuarios_Usuariossexofor_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariossexofor = "";
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariossexofor_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosStatus" )]
      [  XmlElement( ElementName = "UsuariosStatus"   )]
      public short gxTpr_Usuariosstatus
      {
         get {
            return gxTv_SdtUsuarios_Usuariosstatus ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosstatus = value;
            SetDirty("Usuariosstatus");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public String gxTpr_Mode
      {
         get {
            return gxTv_SdtUsuarios_Mode ;
         }

         set {
            gxTv_SdtUsuarios_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtUsuarios_Mode_SetNull( )
      {
         gxTv_SdtUsuarios_Mode = "";
         return  ;
      }

      public bool gxTv_SdtUsuarios_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtUsuarios_Initialized ;
         }

         set {
            gxTv_SdtUsuarios_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtUsuarios_Initialized_SetNull( )
      {
         gxTv_SdtUsuarios_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtUsuarios_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosId_Z" )]
      [  XmlElement( ElementName = "UsuariosId_Z"   )]
      public int gxTpr_Usuariosid_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuariosid_Z ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosid_Z = value;
            SetDirty("Usuariosid_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuariosid_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariosid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosCurp_Z" )]
      [  XmlElement( ElementName = "UsuariosCurp_Z"   )]
      public String gxTpr_Usuarioscurp_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuarioscurp_Z ;
         }

         set {
            gxTv_SdtUsuarios_Usuarioscurp_Z = value;
            SetDirty("Usuarioscurp_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuarioscurp_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuarioscurp_Z = "";
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuarioscurp_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosNombre_Z" )]
      [  XmlElement( ElementName = "UsuariosNombre_Z"   )]
      public String gxTpr_Usuariosnombre_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuariosnombre_Z ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosnombre_Z = value;
            SetDirty("Usuariosnombre_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuariosnombre_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariosnombre_Z = "";
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariosnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosApPat_Z" )]
      [  XmlElement( ElementName = "UsuariosApPat_Z"   )]
      public String gxTpr_Usuariosappat_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuariosappat_Z ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosappat_Z = value;
            SetDirty("Usuariosappat_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuariosappat_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariosappat_Z = "";
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariosappat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosApMat_Z" )]
      [  XmlElement( ElementName = "UsuariosApMat_Z"   )]
      public String gxTpr_Usuariosapmat_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuariosapmat_Z ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosapmat_Z = value;
            SetDirty("Usuariosapmat_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuariosapmat_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariosapmat_Z = "";
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariosapmat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosUsr_Z" )]
      [  XmlElement( ElementName = "UsuariosUsr_Z"   )]
      public String gxTpr_Usuariosusr_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuariosusr_Z ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosusr_Z = value;
            SetDirty("Usuariosusr_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuariosusr_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariosusr_Z = "";
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariosusr_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosTipo_Z" )]
      [  XmlElement( ElementName = "UsuariosTipo_Z"   )]
      public short gxTpr_Usuariostipo_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuariostipo_Z ;
         }

         set {
            gxTv_SdtUsuarios_Usuariostipo_Z = value;
            SetDirty("Usuariostipo_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuariostipo_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariostipo_Z = 0;
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariostipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosFecNacimiento_Z" )]
      [  XmlElement( ElementName = "UsuariosFecNacimiento_Z"  , IsNullable=true )]
      public string gxTpr_Usuariosfecnacimiento_Z_Nullable
      {
         get {
            if ( gxTv_SdtUsuarios_Usuariosfecnacimiento_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtUsuarios_Usuariosfecnacimiento_Z).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtUsuarios_Usuariosfecnacimiento_Z = DateTime.MinValue;
            else
               gxTv_SdtUsuarios_Usuariosfecnacimiento_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Usuariosfecnacimiento_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuariosfecnacimiento_Z ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosfecnacimiento_Z = value;
            SetDirty("Usuariosfecnacimiento_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuariosfecnacimiento_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariosfecnacimiento_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariosfecnacimiento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosEdad_Z" )]
      [  XmlElement( ElementName = "UsuariosEdad_Z"   )]
      public short gxTpr_Usuariosedad_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuariosedad_Z ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosedad_Z = value;
            SetDirty("Usuariosedad_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuariosedad_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariosedad_Z = 0;
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariosedad_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosSexo_Z" )]
      [  XmlElement( ElementName = "UsuariosSexo_Z"   )]
      public String gxTpr_Usuariossexo_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuariossexo_Z ;
         }

         set {
            gxTv_SdtUsuarios_Usuariossexo_Z = value;
            SetDirty("Usuariossexo_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuariossexo_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariossexo_Z = "";
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariossexo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosPwd_Z" )]
      [  XmlElement( ElementName = "UsuariosPwd_Z"   )]
      public String gxTpr_Usuariospwd_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuariospwd_Z ;
         }

         set {
            gxTv_SdtUsuarios_Usuariospwd_Z = value;
            SetDirty("Usuariospwd_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuariospwd_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariospwd_Z = "";
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariospwd_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosKey_Z" )]
      [  XmlElement( ElementName = "UsuariosKey_Z"   )]
      public String gxTpr_Usuarioskey_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuarioskey_Z ;
         }

         set {
            gxTv_SdtUsuarios_Usuarioskey_Z = value;
            SetDirty("Usuarioskey_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuarioskey_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuarioskey_Z = "";
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuarioskey_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosVigIni_Z" )]
      [  XmlElement( ElementName = "UsuariosVigIni_Z"  , IsNullable=true )]
      public string gxTpr_Usuariosvigini_Z_Nullable
      {
         get {
            if ( gxTv_SdtUsuarios_Usuariosvigini_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtUsuarios_Usuariosvigini_Z).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtUsuarios_Usuariosvigini_Z = DateTime.MinValue;
            else
               gxTv_SdtUsuarios_Usuariosvigini_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Usuariosvigini_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuariosvigini_Z ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosvigini_Z = value;
            SetDirty("Usuariosvigini_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuariosvigini_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariosvigini_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariosvigini_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosVigFin_Z" )]
      [  XmlElement( ElementName = "UsuariosVigFin_Z"  , IsNullable=true )]
      public string gxTpr_Usuariosvigfin_Z_Nullable
      {
         get {
            if ( gxTv_SdtUsuarios_Usuariosvigfin_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtUsuarios_Usuariosvigfin_Z).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtUsuarios_Usuariosvigfin_Z = DateTime.MinValue;
            else
               gxTv_SdtUsuarios_Usuariosvigfin_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Usuariosvigfin_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuariosvigfin_Z ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosvigfin_Z = value;
            SetDirty("Usuariosvigfin_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuariosvigfin_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariosvigfin_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariosvigfin_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosFecCap_Z" )]
      [  XmlElement( ElementName = "UsuariosFecCap_Z"  , IsNullable=true )]
      public string gxTpr_Usuariosfeccap_Z_Nullable
      {
         get {
            if ( gxTv_SdtUsuarios_Usuariosfeccap_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtUsuarios_Usuariosfeccap_Z).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtUsuarios_Usuariosfeccap_Z = DateTime.MinValue;
            else
               gxTv_SdtUsuarios_Usuariosfeccap_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Usuariosfeccap_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuariosfeccap_Z ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosfeccap_Z = value;
            SetDirty("Usuariosfeccap_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuariosfeccap_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariosfeccap_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariosfeccap_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosIP_Z" )]
      [  XmlElement( ElementName = "UsuariosIP_Z"   )]
      public String gxTpr_Usuariosip_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuariosip_Z ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosip_Z = value;
            SetDirty("Usuariosip_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuariosip_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariosip_Z = "";
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariosip_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosTelef_Z" )]
      [  XmlElement( ElementName = "UsuariosTelef_Z"   )]
      public String gxTpr_Usuariostelef_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuariostelef_Z ;
         }

         set {
            gxTv_SdtUsuarios_Usuariostelef_Z = value;
            SetDirty("Usuariostelef_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuariostelef_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariostelef_Z = "";
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariostelef_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosCorreo_Z" )]
      [  XmlElement( ElementName = "UsuariosCorreo_Z"   )]
      public String gxTpr_Usuarioscorreo_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuarioscorreo_Z ;
         }

         set {
            gxTv_SdtUsuarios_Usuarioscorreo_Z = value;
            SetDirty("Usuarioscorreo_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuarioscorreo_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuarioscorreo_Z = "";
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuarioscorreo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosNomCompleto_Z" )]
      [  XmlElement( ElementName = "UsuariosNomCompleto_Z"   )]
      public String gxTpr_Usuariosnomcompleto_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuariosnomcompleto_Z ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosnomcompleto_Z = value;
            SetDirty("Usuariosnomcompleto_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuariosnomcompleto_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariosnomcompleto_Z = "";
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariosnomcompleto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RolId_Z" )]
      [  XmlElement( ElementName = "RolId_Z"   )]
      public int gxTpr_Rolid_Z
      {
         get {
            return gxTv_SdtUsuarios_Rolid_Z ;
         }

         set {
            gxTv_SdtUsuarios_Rolid_Z = value;
            SetDirty("Rolid_Z");
         }

      }

      public void gxTv_SdtUsuarios_Rolid_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Rolid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtUsuarios_Rolid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RolNombre_Z" )]
      [  XmlElement( ElementName = "RolNombre_Z"   )]
      public String gxTpr_Rolnombre_Z
      {
         get {
            return gxTv_SdtUsuarios_Rolnombre_Z ;
         }

         set {
            gxTv_SdtUsuarios_Rolnombre_Z = value;
            SetDirty("Rolnombre_Z");
         }

      }

      public void gxTv_SdtUsuarios_Rolnombre_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Rolnombre_Z = "";
         return  ;
      }

      public bool gxTv_SdtUsuarios_Rolnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosSexoFor_Z" )]
      [  XmlElement( ElementName = "UsuariosSexoFor_Z"   )]
      public String gxTpr_Usuariossexofor_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuariossexofor_Z ;
         }

         set {
            gxTv_SdtUsuarios_Usuariossexofor_Z = value;
            SetDirty("Usuariossexofor_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuariossexofor_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariossexofor_Z = "";
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariossexofor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosStatus_Z" )]
      [  XmlElement( ElementName = "UsuariosStatus_Z"   )]
      public short gxTpr_Usuariosstatus_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuariosstatus_Z ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosstatus_Z = value;
            SetDirty("Usuariosstatus_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuariosstatus_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariosstatus_Z = 0;
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariosstatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosIcono_GXI_Z" )]
      [  XmlElement( ElementName = "UsuariosIcono_GXI_Z"   )]
      public String gxTpr_Usuariosicono_gxi_Z
      {
         get {
            return gxTv_SdtUsuarios_Usuariosicono_gxi_Z ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosicono_gxi_Z = value;
            SetDirty("Usuariosicono_gxi_Z");
         }

      }

      public void gxTv_SdtUsuarios_Usuariosicono_gxi_Z_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariosicono_gxi_Z = "";
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariosicono_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosId_N" )]
      [  XmlElement( ElementName = "UsuariosId_N"   )]
      public short gxTpr_Usuariosid_N
      {
         get {
            return gxTv_SdtUsuarios_Usuariosid_N ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosid_N = value;
            SetDirty("Usuariosid_N");
         }

      }

      public void gxTv_SdtUsuarios_Usuariosid_N_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariosid_N = 0;
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariosid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuariosVigFin_N" )]
      [  XmlElement( ElementName = "UsuariosVigFin_N"   )]
      public short gxTpr_Usuariosvigfin_N
      {
         get {
            return gxTv_SdtUsuarios_Usuariosvigfin_N ;
         }

         set {
            gxTv_SdtUsuarios_Usuariosvigfin_N = value;
            SetDirty("Usuariosvigfin_N");
         }

      }

      public void gxTv_SdtUsuarios_Usuariosvigfin_N_SetNull( )
      {
         gxTv_SdtUsuarios_Usuariosvigfin_N = 0;
         return  ;
      }

      public bool gxTv_SdtUsuarios_Usuariosvigfin_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtUsuarios_Usuarioscurp = "";
         gxTv_SdtUsuarios_Usuariosnombre = "";
         gxTv_SdtUsuarios_Usuariosappat = "";
         gxTv_SdtUsuarios_Usuariosapmat = "";
         gxTv_SdtUsuarios_Usuariosusr = "";
         gxTv_SdtUsuarios_Usuariosicono = "";
         gxTv_SdtUsuarios_Usuariosicono_gxi = "";
         gxTv_SdtUsuarios_Usuariosfecnacimiento = DateTime.MinValue;
         gxTv_SdtUsuarios_Usuariossexo = "";
         gxTv_SdtUsuarios_Usuariospwd = "";
         gxTv_SdtUsuarios_Usuarioskey = "";
         gxTv_SdtUsuarios_Usuariosvigini = DateTime.MinValue;
         gxTv_SdtUsuarios_Usuariosvigfin = DateTime.MinValue;
         gxTv_SdtUsuarios_Usuariosfeccap = (DateTime)(DateTime.MinValue);
         gxTv_SdtUsuarios_Usuariosip = "";
         gxTv_SdtUsuarios_Usuariostelef = "";
         gxTv_SdtUsuarios_Usuarioscorreo = "";
         gxTv_SdtUsuarios_Usuariosnomcompleto = "";
         gxTv_SdtUsuarios_Rolnombre = "";
         gxTv_SdtUsuarios_Usuariossexofor = "";
         gxTv_SdtUsuarios_Mode = "";
         gxTv_SdtUsuarios_Usuarioscurp_Z = "";
         gxTv_SdtUsuarios_Usuariosnombre_Z = "";
         gxTv_SdtUsuarios_Usuariosappat_Z = "";
         gxTv_SdtUsuarios_Usuariosapmat_Z = "";
         gxTv_SdtUsuarios_Usuariosusr_Z = "";
         gxTv_SdtUsuarios_Usuariosfecnacimiento_Z = DateTime.MinValue;
         gxTv_SdtUsuarios_Usuariossexo_Z = "";
         gxTv_SdtUsuarios_Usuariospwd_Z = "";
         gxTv_SdtUsuarios_Usuarioskey_Z = "";
         gxTv_SdtUsuarios_Usuariosvigini_Z = DateTime.MinValue;
         gxTv_SdtUsuarios_Usuariosvigfin_Z = DateTime.MinValue;
         gxTv_SdtUsuarios_Usuariosfeccap_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtUsuarios_Usuariosip_Z = "";
         gxTv_SdtUsuarios_Usuariostelef_Z = "";
         gxTv_SdtUsuarios_Usuarioscorreo_Z = "";
         gxTv_SdtUsuarios_Usuariosnomcompleto_Z = "";
         gxTv_SdtUsuarios_Rolnombre_Z = "";
         gxTv_SdtUsuarios_Usuariossexofor_Z = "";
         gxTv_SdtUsuarios_Usuariosicono_gxi_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj ;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "usuarios", "GeneXus.Programs.usuarios_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      private short gxTv_SdtUsuarios_Usuariostipo ;
      private short gxTv_SdtUsuarios_Usuariosedad ;
      private short gxTv_SdtUsuarios_Usuariosstatus ;
      private short gxTv_SdtUsuarios_Initialized ;
      private short gxTv_SdtUsuarios_Usuariostipo_Z ;
      private short gxTv_SdtUsuarios_Usuariosedad_Z ;
      private short gxTv_SdtUsuarios_Usuariosstatus_Z ;
      private short gxTv_SdtUsuarios_Usuariosid_N ;
      private short gxTv_SdtUsuarios_Usuariosvigfin_N ;
      private int gxTv_SdtUsuarios_Usuariosid ;
      private int gxTv_SdtUsuarios_Rolid ;
      private int gxTv_SdtUsuarios_Usuariosid_Z ;
      private int gxTv_SdtUsuarios_Rolid_Z ;
      private String gxTv_SdtUsuarios_Usuariossexo ;
      private String gxTv_SdtUsuarios_Usuariostelef ;
      private String gxTv_SdtUsuarios_Usuariossexofor ;
      private String gxTv_SdtUsuarios_Mode ;
      private String gxTv_SdtUsuarios_Usuariossexo_Z ;
      private String gxTv_SdtUsuarios_Usuariostelef_Z ;
      private String gxTv_SdtUsuarios_Usuariossexofor_Z ;
      private String sDateCnv ;
      private String sNumToPad ;
      private DateTime gxTv_SdtUsuarios_Usuariosfeccap ;
      private DateTime gxTv_SdtUsuarios_Usuariosfeccap_Z ;
      private DateTime datetime_STZ ;
      private DateTime gxTv_SdtUsuarios_Usuariosfecnacimiento ;
      private DateTime gxTv_SdtUsuarios_Usuariosvigini ;
      private DateTime gxTv_SdtUsuarios_Usuariosvigfin ;
      private DateTime gxTv_SdtUsuarios_Usuariosfecnacimiento_Z ;
      private DateTime gxTv_SdtUsuarios_Usuariosvigini_Z ;
      private DateTime gxTv_SdtUsuarios_Usuariosvigfin_Z ;
      private String gxTv_SdtUsuarios_Usuarioscurp ;
      private String gxTv_SdtUsuarios_Usuariosnombre ;
      private String gxTv_SdtUsuarios_Usuariosappat ;
      private String gxTv_SdtUsuarios_Usuariosapmat ;
      private String gxTv_SdtUsuarios_Usuariosusr ;
      private String gxTv_SdtUsuarios_Usuariosicono_gxi ;
      private String gxTv_SdtUsuarios_Usuariospwd ;
      private String gxTv_SdtUsuarios_Usuarioskey ;
      private String gxTv_SdtUsuarios_Usuariosip ;
      private String gxTv_SdtUsuarios_Usuarioscorreo ;
      private String gxTv_SdtUsuarios_Usuariosnomcompleto ;
      private String gxTv_SdtUsuarios_Rolnombre ;
      private String gxTv_SdtUsuarios_Usuarioscurp_Z ;
      private String gxTv_SdtUsuarios_Usuariosnombre_Z ;
      private String gxTv_SdtUsuarios_Usuariosappat_Z ;
      private String gxTv_SdtUsuarios_Usuariosapmat_Z ;
      private String gxTv_SdtUsuarios_Usuariosusr_Z ;
      private String gxTv_SdtUsuarios_Usuariospwd_Z ;
      private String gxTv_SdtUsuarios_Usuarioskey_Z ;
      private String gxTv_SdtUsuarios_Usuariosip_Z ;
      private String gxTv_SdtUsuarios_Usuarioscorreo_Z ;
      private String gxTv_SdtUsuarios_Usuariosnomcompleto_Z ;
      private String gxTv_SdtUsuarios_Rolnombre_Z ;
      private String gxTv_SdtUsuarios_Usuariosicono_gxi_Z ;
      private String gxTv_SdtUsuarios_Usuariosicono ;
   }

   [DataContract(Name = @"Usuarios", Namespace = "ADMINDATA1")]
   public class SdtUsuarios_RESTInterface : GxGenericCollectionItem<SdtUsuarios>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtUsuarios_RESTInterface( ) : base()
      {
      }

      public SdtUsuarios_RESTInterface( SdtUsuarios psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "UsuariosId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Usuariosid
      {
         get {
            return sdt.gxTpr_Usuariosid ;
         }

         set {
            sdt.gxTpr_Usuariosid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "UsuariosCurp" , Order = 1 )]
      [GxSeudo()]
      public String gxTpr_Usuarioscurp
      {
         get {
            return sdt.gxTpr_Usuarioscurp ;
         }

         set {
            sdt.gxTpr_Usuarioscurp = value;
         }

      }

      [DataMember( Name = "UsuariosNombre" , Order = 2 )]
      [GxSeudo()]
      public String gxTpr_Usuariosnombre
      {
         get {
            return sdt.gxTpr_Usuariosnombre ;
         }

         set {
            sdt.gxTpr_Usuariosnombre = value;
         }

      }

      [DataMember( Name = "UsuariosApPat" , Order = 3 )]
      [GxSeudo()]
      public String gxTpr_Usuariosappat
      {
         get {
            return sdt.gxTpr_Usuariosappat ;
         }

         set {
            sdt.gxTpr_Usuariosappat = value;
         }

      }

      [DataMember( Name = "UsuariosApMat" , Order = 4 )]
      [GxSeudo()]
      public String gxTpr_Usuariosapmat
      {
         get {
            return sdt.gxTpr_Usuariosapmat ;
         }

         set {
            sdt.gxTpr_Usuariosapmat = value;
         }

      }

      [DataMember( Name = "UsuariosUsr" , Order = 5 )]
      [GxSeudo()]
      public String gxTpr_Usuariosusr
      {
         get {
            return sdt.gxTpr_Usuariosusr ;
         }

         set {
            sdt.gxTpr_Usuariosusr = value;
         }

      }

      [DataMember( Name = "UsuariosTipo" , Order = 6 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Usuariostipo
      {
         get {
            return sdt.gxTpr_Usuariostipo ;
         }

         set {
            sdt.gxTpr_Usuariostipo = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "UsuariosIcono" , Order = 7 )]
      [GxUpload()]
      public String gxTpr_Usuariosicono
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Usuariosicono)) ? PathUtil.RelativeURL( sdt.gxTpr_Usuariosicono) : StringUtil.RTrim( sdt.gxTpr_Usuariosicono_gxi)) ;
         }

         set {
            sdt.gxTpr_Usuariosicono = value;
         }

      }

      [DataMember( Name = "UsuariosFecNacimiento" , Order = 8 )]
      [GxSeudo()]
      public String gxTpr_Usuariosfecnacimiento
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Usuariosfecnacimiento) ;
         }

         set {
            sdt.gxTpr_Usuariosfecnacimiento = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "UsuariosEdad" , Order = 9 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Usuariosedad
      {
         get {
            return sdt.gxTpr_Usuariosedad ;
         }

         set {
            sdt.gxTpr_Usuariosedad = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "UsuariosSexo" , Order = 10 )]
      [GxSeudo()]
      public String gxTpr_Usuariossexo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariossexo) ;
         }

         set {
            sdt.gxTpr_Usuariossexo = value;
         }

      }

      [DataMember( Name = "UsuariosPwd" , Order = 11 )]
      [GxSeudo()]
      public String gxTpr_Usuariospwd
      {
         get {
            return sdt.gxTpr_Usuariospwd ;
         }

         set {
            sdt.gxTpr_Usuariospwd = value;
         }

      }

      [DataMember( Name = "UsuariosKey" , Order = 12 )]
      [GxSeudo()]
      public String gxTpr_Usuarioskey
      {
         get {
            return sdt.gxTpr_Usuarioskey ;
         }

         set {
            sdt.gxTpr_Usuarioskey = value;
         }

      }

      [DataMember( Name = "UsuariosVigIni" , Order = 13 )]
      [GxSeudo()]
      public String gxTpr_Usuariosvigini
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Usuariosvigini) ;
         }

         set {
            sdt.gxTpr_Usuariosvigini = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "UsuariosVigFin" , Order = 14 )]
      [GxSeudo()]
      public String gxTpr_Usuariosvigfin
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Usuariosvigfin) ;
         }

         set {
            sdt.gxTpr_Usuariosvigfin = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "UsuariosFecCap" , Order = 15 )]
      [GxSeudo()]
      public String gxTpr_Usuariosfeccap
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Usuariosfeccap) ;
         }

         set {
            sdt.gxTpr_Usuariosfeccap = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "UsuariosIP" , Order = 16 )]
      [GxSeudo()]
      public String gxTpr_Usuariosip
      {
         get {
            return sdt.gxTpr_Usuariosip ;
         }

         set {
            sdt.gxTpr_Usuariosip = value;
         }

      }

      [DataMember( Name = "UsuariosTelef" , Order = 17 )]
      [GxSeudo()]
      public String gxTpr_Usuariostelef
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariostelef) ;
         }

         set {
            sdt.gxTpr_Usuariostelef = value;
         }

      }

      [DataMember( Name = "UsuariosCorreo" , Order = 18 )]
      [GxSeudo()]
      public String gxTpr_Usuarioscorreo
      {
         get {
            return sdt.gxTpr_Usuarioscorreo ;
         }

         set {
            sdt.gxTpr_Usuarioscorreo = value;
         }

      }

      [DataMember( Name = "UsuariosNomCompleto" , Order = 19 )]
      [GxSeudo()]
      public String gxTpr_Usuariosnomcompleto
      {
         get {
            return sdt.gxTpr_Usuariosnomcompleto ;
         }

         set {
            sdt.gxTpr_Usuariosnomcompleto = value;
         }

      }

      [DataMember( Name = "RolId" , Order = 20 )]
      [GxSeudo()]
      public String gxTpr_Rolid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Rolid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Rolid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "RolNombre" , Order = 21 )]
      [GxSeudo()]
      public String gxTpr_Rolnombre
      {
         get {
            return sdt.gxTpr_Rolnombre ;
         }

         set {
            sdt.gxTpr_Rolnombre = value;
         }

      }

      [DataMember( Name = "UsuariosSexoFor" , Order = 22 )]
      [GxSeudo()]
      public String gxTpr_Usuariossexofor
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariossexofor) ;
         }

         set {
            sdt.gxTpr_Usuariossexofor = value;
         }

      }

      [DataMember( Name = "UsuariosStatus" , Order = 23 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Usuariosstatus
      {
         get {
            return sdt.gxTpr_Usuariosstatus ;
         }

         set {
            sdt.gxTpr_Usuariosstatus = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtUsuarios sdt
      {
         get {
            return (SdtUsuarios)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtUsuarios() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 24 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (String)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private String md5Hash ;
   }

   [DataContract(Name = @"Usuarios", Namespace = "ADMINDATA1")]
   public class SdtUsuarios_RESTLInterface : GxGenericCollectionItem<SdtUsuarios>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtUsuarios_RESTLInterface( ) : base()
      {
      }

      public SdtUsuarios_RESTLInterface( SdtUsuarios psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "UsuariosCurp" , Order = 0 )]
      [GxSeudo()]
      public String gxTpr_Usuarioscurp
      {
         get {
            return sdt.gxTpr_Usuarioscurp ;
         }

         set {
            sdt.gxTpr_Usuarioscurp = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtUsuarios sdt
      {
         get {
            return (SdtUsuarios)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtUsuarios() ;
         }
      }

   }

}
