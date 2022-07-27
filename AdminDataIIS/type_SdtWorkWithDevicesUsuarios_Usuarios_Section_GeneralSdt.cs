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
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt" )]
   [XmlType(TypeName =  "WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt : GxUserType
   {
      public SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt( )
      {
         /* Constructor for serialization */
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosicono = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosicono_gxi = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuarioscurp = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosnombre = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosappat = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosapmat = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariostelef = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuarioscorreo = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosfecnacimiento = DateTime.MinValue;
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariossexofor = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariospwd = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosfeccap = (DateTime)(DateTime.MinValue);
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigini = DateTime.MinValue;
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigfin = DateTime.MinValue;
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosip = "";
      }

      public SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt( IGxContext context )
      {
         this.context = context;
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
         AddObjectProperty("UsuariosId", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosid, false, false);
         AddObjectProperty("UsuariosIcono", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosicono, false, false);
         AddObjectProperty("UsuariosIcono_GXI", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosicono_gxi, false, false);
         AddObjectProperty("UsuariosCurp", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuarioscurp, false, false);
         AddObjectProperty("UsuariosNombre", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosnombre, false, false);
         AddObjectProperty("UsuariosApPat", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosappat, false, false);
         AddObjectProperty("UsuariosApMat", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosapmat, false, false);
         AddObjectProperty("UsuariosTipo", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariostipo, false, false);
         AddObjectProperty("UsuariosTelef", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariostelef, false, false);
         AddObjectProperty("UsuariosCorreo", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuarioscorreo, false, false);
         AddObjectProperty("UsuariosStatus", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosstatus, false, false);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosfecnacimiento)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosfecnacimiento)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosfecnacimiento)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("UsuariosFecNacimiento", sDateCnv, false, false);
         AddObjectProperty("UsuariosEdad", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosedad, false, false);
         AddObjectProperty("UsuariosSexoFor", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariossexofor, false, false);
         AddObjectProperty("UsuariosPwd", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariospwd, false, false);
         datetime_STZ = gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosfeccap;
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
         AddObjectProperty("UsuariosFecCap", sDateCnv, false, false);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigini)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigini)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigini)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("UsuariosVigIni", sDateCnv, false, false);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigfin)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigfin)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigfin)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("UsuariosVigFin", sDateCnv, false, false);
         AddObjectProperty("UsuariosIP", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosip, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "UsuariosId" )]
      [  XmlElement( ElementName = "UsuariosId"   )]
      public int gxTpr_Usuariosid
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosid ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosid = value;
            SetDirty("Usuariosid");
         }

      }

      [  SoapElement( ElementName = "UsuariosIcono" )]
      [  XmlElement( ElementName = "UsuariosIcono"   )]
      [GxUpload()]
      public String gxTpr_Usuariosicono
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosicono ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosicono = value;
            SetDirty("Usuariosicono");
         }

      }

      [  SoapElement( ElementName = "UsuariosIcono_GXI" )]
      [  XmlElement( ElementName = "UsuariosIcono_GXI"   )]
      public String gxTpr_Usuariosicono_gxi
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosicono_gxi ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosicono_gxi = value;
            SetDirty("Usuariosicono_gxi");
         }

      }

      [  SoapElement( ElementName = "UsuariosCurp" )]
      [  XmlElement( ElementName = "UsuariosCurp"   )]
      public String gxTpr_Usuarioscurp
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuarioscurp ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuarioscurp = value;
            SetDirty("Usuarioscurp");
         }

      }

      [  SoapElement( ElementName = "UsuariosNombre" )]
      [  XmlElement( ElementName = "UsuariosNombre"   )]
      public String gxTpr_Usuariosnombre
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosnombre ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosnombre = value;
            SetDirty("Usuariosnombre");
         }

      }

      [  SoapElement( ElementName = "UsuariosApPat" )]
      [  XmlElement( ElementName = "UsuariosApPat"   )]
      public String gxTpr_Usuariosappat
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosappat ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosappat = value;
            SetDirty("Usuariosappat");
         }

      }

      [  SoapElement( ElementName = "UsuariosApMat" )]
      [  XmlElement( ElementName = "UsuariosApMat"   )]
      public String gxTpr_Usuariosapmat
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosapmat ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosapmat = value;
            SetDirty("Usuariosapmat");
         }

      }

      [  SoapElement( ElementName = "UsuariosTipo" )]
      [  XmlElement( ElementName = "UsuariosTipo"   )]
      public short gxTpr_Usuariostipo
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariostipo ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariostipo = value;
            SetDirty("Usuariostipo");
         }

      }

      [  SoapElement( ElementName = "UsuariosTelef" )]
      [  XmlElement( ElementName = "UsuariosTelef"   )]
      public String gxTpr_Usuariostelef
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariostelef ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariostelef = value;
            SetDirty("Usuariostelef");
         }

      }

      [  SoapElement( ElementName = "UsuariosCorreo" )]
      [  XmlElement( ElementName = "UsuariosCorreo"   )]
      public String gxTpr_Usuarioscorreo
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuarioscorreo ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuarioscorreo = value;
            SetDirty("Usuarioscorreo");
         }

      }

      [  SoapElement( ElementName = "UsuariosStatus" )]
      [  XmlElement( ElementName = "UsuariosStatus"   )]
      public short gxTpr_Usuariosstatus
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosstatus ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosstatus = value;
            SetDirty("Usuariosstatus");
         }

      }

      [  SoapElement( ElementName = "UsuariosFecNacimiento" )]
      [  XmlElement( ElementName = "UsuariosFecNacimiento"  , IsNullable=true )]
      public string gxTpr_Usuariosfecnacimiento_Nullable
      {
         get {
            if ( gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosfecnacimiento == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosfecnacimiento).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosfecnacimiento = DateTime.MinValue;
            else
               gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosfecnacimiento = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Usuariosfecnacimiento
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosfecnacimiento ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosfecnacimiento = value;
            SetDirty("Usuariosfecnacimiento");
         }

      }

      [  SoapElement( ElementName = "UsuariosEdad" )]
      [  XmlElement( ElementName = "UsuariosEdad"   )]
      public short gxTpr_Usuariosedad
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosedad ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosedad = value;
            SetDirty("Usuariosedad");
         }

      }

      [  SoapElement( ElementName = "UsuariosSexoFor" )]
      [  XmlElement( ElementName = "UsuariosSexoFor"   )]
      public String gxTpr_Usuariossexofor
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariossexofor ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariossexofor = value;
            SetDirty("Usuariossexofor");
         }

      }

      [  SoapElement( ElementName = "UsuariosPwd" )]
      [  XmlElement( ElementName = "UsuariosPwd"   )]
      public String gxTpr_Usuariospwd
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariospwd ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariospwd = value;
            SetDirty("Usuariospwd");
         }

      }

      [  SoapElement( ElementName = "UsuariosFecCap" )]
      [  XmlElement( ElementName = "UsuariosFecCap"  , IsNullable=true )]
      public string gxTpr_Usuariosfeccap_Nullable
      {
         get {
            if ( gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosfeccap == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosfeccap).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosfeccap = DateTime.MinValue;
            else
               gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosfeccap = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Usuariosfeccap
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosfeccap ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosfeccap = value;
            SetDirty("Usuariosfeccap");
         }

      }

      [  SoapElement( ElementName = "UsuariosVigIni" )]
      [  XmlElement( ElementName = "UsuariosVigIni"  , IsNullable=true )]
      public string gxTpr_Usuariosvigini_Nullable
      {
         get {
            if ( gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigini == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigini).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigini = DateTime.MinValue;
            else
               gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigini = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Usuariosvigini
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigini ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigini = value;
            SetDirty("Usuariosvigini");
         }

      }

      [  SoapElement( ElementName = "UsuariosVigFin" )]
      [  XmlElement( ElementName = "UsuariosVigFin"  , IsNullable=true )]
      public string gxTpr_Usuariosvigfin_Nullable
      {
         get {
            if ( gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigfin == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigfin).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigfin = DateTime.MinValue;
            else
               gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigfin = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Usuariosvigfin
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigfin ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigfin = value;
            SetDirty("Usuariosvigfin");
         }

      }

      [  SoapElement( ElementName = "UsuariosIP" )]
      [  XmlElement( ElementName = "UsuariosIP"   )]
      public String gxTpr_Usuariosip
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosip ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosip = value;
            SetDirty("Usuariosip");
         }

      }

      public void initialize( )
      {
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosicono = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosicono_gxi = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuarioscurp = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosnombre = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosappat = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosapmat = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariostelef = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuarioscorreo = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosfecnacimiento = DateTime.MinValue;
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariossexofor = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariospwd = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosfeccap = (DateTime)(DateTime.MinValue);
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigini = DateTime.MinValue;
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigfin = DateTime.MinValue;
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosip = "";
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         return  ;
      }

      protected short gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariostipo ;
      protected short gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosstatus ;
      protected short gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosedad ;
      protected int gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosid ;
      protected String gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariostelef ;
      protected String gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariossexofor ;
      protected String sDateCnv ;
      protected String sNumToPad ;
      protected DateTime gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosfeccap ;
      protected DateTime datetime_STZ ;
      protected DateTime gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosfecnacimiento ;
      protected DateTime gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigini ;
      protected DateTime gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosvigfin ;
      protected String gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosicono_gxi ;
      protected String gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuarioscurp ;
      protected String gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosnombre ;
      protected String gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosappat ;
      protected String gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosapmat ;
      protected String gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuarioscorreo ;
      protected String gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariospwd ;
      protected String gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosip ;
      protected String gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_Usuariosicono ;
   }

   [DataContract(Name = @"WorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt", Namespace = "http://tempuri.org/")]
   public class SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_RESTInterface : GxGenericCollectionItem<SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_RESTInterface( ) : base()
      {
      }

      public SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt_RESTInterface( SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "UsuariosId" , Order = 0 )]
      public Nullable<int> gxTpr_Usuariosid
      {
         get {
            return sdt.gxTpr_Usuariosid ;
         }

         set {
            sdt.gxTpr_Usuariosid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "UsuariosIcono" , Order = 1 )]
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

      [DataMember( Name = "UsuariosCurp" , Order = 2 )]
      public String gxTpr_Usuarioscurp
      {
         get {
            return sdt.gxTpr_Usuarioscurp ;
         }

         set {
            sdt.gxTpr_Usuarioscurp = value;
         }

      }

      [DataMember( Name = "UsuariosNombre" , Order = 3 )]
      public String gxTpr_Usuariosnombre
      {
         get {
            return sdt.gxTpr_Usuariosnombre ;
         }

         set {
            sdt.gxTpr_Usuariosnombre = value;
         }

      }

      [DataMember( Name = "UsuariosApPat" , Order = 4 )]
      public String gxTpr_Usuariosappat
      {
         get {
            return sdt.gxTpr_Usuariosappat ;
         }

         set {
            sdt.gxTpr_Usuariosappat = value;
         }

      }

      [DataMember( Name = "UsuariosApMat" , Order = 5 )]
      public String gxTpr_Usuariosapmat
      {
         get {
            return sdt.gxTpr_Usuariosapmat ;
         }

         set {
            sdt.gxTpr_Usuariosapmat = value;
         }

      }

      [DataMember( Name = "UsuariosTipo" , Order = 6 )]
      public Nullable<short> gxTpr_Usuariostipo
      {
         get {
            return sdt.gxTpr_Usuariostipo ;
         }

         set {
            sdt.gxTpr_Usuariostipo = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "UsuariosTelef" , Order = 7 )]
      public String gxTpr_Usuariostelef
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariostelef) ;
         }

         set {
            sdt.gxTpr_Usuariostelef = value;
         }

      }

      [DataMember( Name = "UsuariosCorreo" , Order = 8 )]
      public String gxTpr_Usuarioscorreo
      {
         get {
            return sdt.gxTpr_Usuarioscorreo ;
         }

         set {
            sdt.gxTpr_Usuarioscorreo = value;
         }

      }

      [DataMember( Name = "UsuariosStatus" , Order = 9 )]
      public Nullable<short> gxTpr_Usuariosstatus
      {
         get {
            return sdt.gxTpr_Usuariosstatus ;
         }

         set {
            sdt.gxTpr_Usuariosstatus = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "UsuariosFecNacimiento" , Order = 10 )]
      public String gxTpr_Usuariosfecnacimiento
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Usuariosfecnacimiento) ;
         }

         set {
            sdt.gxTpr_Usuariosfecnacimiento = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "UsuariosEdad" , Order = 11 )]
      public Nullable<short> gxTpr_Usuariosedad
      {
         get {
            return sdt.gxTpr_Usuariosedad ;
         }

         set {
            sdt.gxTpr_Usuariosedad = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "UsuariosSexoFor" , Order = 12 )]
      public String gxTpr_Usuariossexofor
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariossexofor) ;
         }

         set {
            sdt.gxTpr_Usuariossexofor = value;
         }

      }

      [DataMember( Name = "UsuariosPwd" , Order = 13 )]
      public String gxTpr_Usuariospwd
      {
         get {
            return sdt.gxTpr_Usuariospwd ;
         }

         set {
            sdt.gxTpr_Usuariospwd = value;
         }

      }

      [DataMember( Name = "UsuariosFecCap" , Order = 14 )]
      public String gxTpr_Usuariosfeccap
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Usuariosfeccap) ;
         }

         set {
            sdt.gxTpr_Usuariosfeccap = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "UsuariosVigIni" , Order = 15 )]
      public String gxTpr_Usuariosvigini
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Usuariosvigini) ;
         }

         set {
            sdt.gxTpr_Usuariosvigini = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "UsuariosVigFin" , Order = 16 )]
      public String gxTpr_Usuariosvigfin
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Usuariosvigfin) ;
         }

         set {
            sdt.gxTpr_Usuariosvigfin = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "UsuariosIP" , Order = 17 )]
      public String gxTpr_Usuariosip
      {
         get {
            return sdt.gxTpr_Usuariosip ;
         }

         set {
            sdt.gxTpr_Usuariosip = value;
         }

      }

      public SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt sdt
      {
         get {
            return (SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt)Sdt ;
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
            sdt = new SdtWorkWithDevicesUsuarios_Usuarios_Section_GeneralSdt() ;
         }
      }

   }

}
