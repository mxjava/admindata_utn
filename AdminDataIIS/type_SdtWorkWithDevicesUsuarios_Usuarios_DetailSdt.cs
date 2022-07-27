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
   [XmlRoot(ElementName = "WorkWithDevicesUsuarios_Usuarios_DetailSdt" )]
   [XmlType(TypeName =  "WorkWithDevicesUsuarios_Usuarios_DetailSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt : GxUserType
   {
      public SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt( )
      {
         /* Constructor for serialization */
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt_Gxdynprop = "";
      }

      public SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt( IGxContext context )
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
         AddObjectProperty("Gxdynprop", gxTv_SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt_Gxdynprop, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "Gxdynprop" )]
      [  XmlElement( ElementName = "Gxdynprop"   )]
      public String gxTpr_Gxdynprop
      {
         get {
            return gxTv_SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt_Gxdynprop ;
         }

         set {
            gxTv_SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt_Gxdynprop = value;
            SetDirty("Gxdynprop");
         }

      }

      public void initialize( )
      {
         gxTv_SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt_Gxdynprop = "";
         return  ;
      }

      protected String gxTv_SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt_Gxdynprop ;
   }

   [DataContract(Name = @"WorkWithDevicesUsuarios_Usuarios_DetailSdt", Namespace = "http://tempuri.org/")]
   public class SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt_RESTInterface : GxGenericCollectionItem<SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt_RESTInterface( ) : base()
      {
      }

      public SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt_RESTInterface( SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Gxdynprop" , Order = 0 )]
      public String gxTpr_Gxdynprop
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Gxdynprop) ;
         }

         set {
            sdt.gxTpr_Gxdynprop = value;
         }

      }

      public SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt sdt
      {
         get {
            return (SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt)Sdt ;
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
            sdt = new SdtWorkWithDevicesUsuarios_Usuarios_DetailSdt() ;
         }
      }

   }

}
