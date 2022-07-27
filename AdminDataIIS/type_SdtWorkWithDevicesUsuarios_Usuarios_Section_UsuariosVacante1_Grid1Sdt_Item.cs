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
   public class SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item : GxUserType
   {
      public SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item( )
      {
         /* Constructor for serialization */
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item_Vacantes_nombre = "";
      }

      public SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item( IGxContext context )
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
         AddObjectProperty("Vacantes_Id", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item_Vacantes_id, false, false);
         AddObjectProperty("UsuariosId", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item_Usuariosid, false, false);
         AddObjectProperty("Vacantes_Nombre", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item_Vacantes_nombre, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "Vacantes_Id" )]
      [  XmlElement( ElementName = "Vacantes_Id"   )]
      public int gxTpr_Vacantes_id
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item_Vacantes_id ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item_Vacantes_id = value;
            SetDirty("Vacantes_id");
         }

      }

      [  SoapElement( ElementName = "UsuariosId" )]
      [  XmlElement( ElementName = "UsuariosId"   )]
      public int gxTpr_Usuariosid
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item_Usuariosid ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item_Usuariosid = value;
            SetDirty("Usuariosid");
         }

      }

      [  SoapElement( ElementName = "Vacantes_Nombre" )]
      [  XmlElement( ElementName = "Vacantes_Nombre"   )]
      public String gxTpr_Vacantes_nombre
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item_Vacantes_nombre ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item_Vacantes_nombre = value;
            SetDirty("Vacantes_nombre");
         }

      }

      public void initialize( )
      {
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item_Vacantes_nombre = "";
         return  ;
      }

      protected int gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item_Vacantes_id ;
      protected int gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item_Usuariosid ;
      protected String gxTv_SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item_Vacantes_nombre ;
   }

   [DataContract(Name = @"WorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt.Item", Namespace = "http://tempuri.org/")]
   public class SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item_RESTInterface : GxGenericCollectionItem<SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item_RESTInterface( ) : base()
      {
      }

      public SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item_RESTInterface( SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Vacantes_Id" , Order = 0 )]
      public String gxTpr_Vacantes_id
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Vacantes_id), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Vacantes_id = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "UsuariosId" , Order = 1 )]
      public Nullable<int> gxTpr_Usuariosid
      {
         get {
            return sdt.gxTpr_Usuariosid ;
         }

         set {
            sdt.gxTpr_Usuariosid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "Vacantes_Nombre" , Order = 2 )]
      public String gxTpr_Vacantes_nombre
      {
         get {
            return sdt.gxTpr_Vacantes_nombre ;
         }

         set {
            sdt.gxTpr_Vacantes_nombre = value;
         }

      }

      public SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item sdt
      {
         get {
            return (SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item)Sdt ;
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
            sdt = new SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item() ;
         }
      }

   }

}
