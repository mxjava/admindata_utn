using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gxdomainclasificacionpac
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainclasificacionpac ()
      {
         domain[(short)1] = "Infante";
         domain[(short)2] = "Adulto Responsable";
         domain[(short)3] = "Adulto Discapacitado Para Firmar o Sin Saber Leer o Escribir";
         domain[(short)4] = "Inconciente";
      }

      public static string getDescription( IGxContext context ,
                                           short key )
      {
         String value ;
         value = (String)(domain[key]==null?"":domain[key]);
         return value ;
      }

      public static GxSimpleCollection<short> getValues( )
      {
         GxSimpleCollection<short> value = new GxSimpleCollection<short>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (short key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
      public static short getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["Infante"] = (short)1;
            domainMap["AdultoResponsable"] = (short)2;
            domainMap["AdultoDiscapacitadoParaFirmaroSinSaberLeeroEscribir"] = (short)3;
            domainMap["Inconciente"] = (short)4;
         }
         return (short)domainMap[key] ;
      }

   }

}
