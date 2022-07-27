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
   public class gxdomaingooglecharttype
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaingooglecharttype ()
      {
         domain["BarChart"] = "Bar Chart";
         domain["ColumnChart"] = "Column Chart";
         domain["LineChart"] = "Line Chart";
         domain["PieChart"] = "Pie Chart";
         domain["ScatterChart"] = "Scatter Chart";
      }

      public static string getDescription( IGxContext context ,
                                           String key )
      {
         string rtkey ;
         String value ;
         rtkey = ((key==null) ? "" : StringUtil.Trim( (String)(key)));
         value = (String)(domain[rtkey]==null?"":domain[rtkey]);
         return value ;
      }

      public static GxSimpleCollection<String> getValues( )
      {
         GxSimpleCollection<String> value = new GxSimpleCollection<String>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (String key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
      public static String getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["BarChart"] = "BarChart";
            domainMap["ColumnChart"] = "ColumnChart";
            domainMap["LineChart"] = "LineChart";
            domainMap["PieChart"] = "PieChart";
            domainMap["ScatterChart"] = "ScatterChart";
         }
         return (String)domainMap[key] ;
      }

   }

}
