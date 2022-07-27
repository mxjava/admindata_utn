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
   [XmlRoot(ElementName = "Item" )]
   [XmlType(TypeName =  "Item" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item : GxUserType
   {
      public SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item( )
      {
         /* Constructor for serialization */
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariosicono = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariosicono_gxi = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuarioscurp = "";
      }

      public SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item( IGxContext context )
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
         AddObjectProperty("UsuariosId", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariosid, false, false);
         AddObjectProperty("UsuariosIcono", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariosicono, false, false);
         AddObjectProperty("UsuariosIcono_GXI", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariosicono_gxi, false, false);
         AddObjectProperty("UsuariosCurp", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuarioscurp, false, false);
         AddObjectProperty("UsuariosTipo", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariostipo, false, false);
         AddObjectProperty("UsuariosStatus", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariosstatus, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "UsuariosId" )]
      [  XmlElement( ElementName = "UsuariosId"   )]
      public int gxTpr_Usuariosid
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariosid ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariosid = value;
            SetDirty("Usuariosid");
         }

      }

      [  SoapElement( ElementName = "UsuariosIcono" )]
      [  XmlElement( ElementName = "UsuariosIcono"   )]
      [GxUpload()]
      public String gxTpr_Usuariosicono
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariosicono ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariosicono = value;
            SetDirty("Usuariosicono");
         }

      }

      [  SoapElement( ElementName = "UsuariosIcono_GXI" )]
      [  XmlElement( ElementName = "UsuariosIcono_GXI"   )]
      public String gxTpr_Usuariosicono_gxi
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariosicono_gxi ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariosicono_gxi = value;
            SetDirty("Usuariosicono_gxi");
         }

      }

      [  SoapElement( ElementName = "UsuariosCurp" )]
      [  XmlElement( ElementName = "UsuariosCurp"   )]
      public String gxTpr_Usuarioscurp
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuarioscurp ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuarioscurp = value;
            SetDirty("Usuarioscurp");
         }

      }

      [  SoapElement( ElementName = "UsuariosTipo" )]
      [  XmlElement( ElementName = "UsuariosTipo"   )]
      public short gxTpr_Usuariostipo
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariostipo ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariostipo = value;
            SetDirty("Usuariostipo");
         }

      }

      [  SoapElement( ElementName = "UsuariosStatus" )]
      [  XmlElement( ElementName = "UsuariosStatus"   )]
      public short gxTpr_Usuariosstatus
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariosstatus ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariosstatus = value;
            SetDirty("Usuariosstatus");
         }

      }

      public void initialize( )
      {
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariosicono = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariosicono_gxi = "";
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuarioscurp = "";
         return  ;
      }

      protected short gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariostipo ;
      protected short gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariosstatus ;
      protected int gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariosid ;
      protected String gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariosicono_gxi ;
      protected String gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuarioscurp ;
      protected String gxTv_SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_Usuariosicono ;
   }

   [DataContract(Name = @"WorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt.Item", Namespace = "http://tempuri.org/")]
   public class SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_RESTInterface : GxGenericCollectionItem<SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_RESTInterface( ) : base()
      {
      }

      public SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_RESTInterface( SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item psdt ) : base(psdt)
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

      [DataMember( Name = "UsuariosTipo" , Order = 3 )]
      public Nullable<short> gxTpr_Usuariostipo
      {
         get {
            return sdt.gxTpr_Usuariostipo ;
         }

         set {
            sdt.gxTpr_Usuariostipo = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "UsuariosStatus" , Order = 4 )]
      public Nullable<short> gxTpr_Usuariosstatus
      {
         get {
            return sdt.gxTpr_Usuariosstatus ;
         }

         set {
            sdt.gxTpr_Usuariosstatus = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item sdt
      {
         get {
            return (SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item)Sdt ;
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
            sdt = new SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item() ;
         }
      }

   }

}
