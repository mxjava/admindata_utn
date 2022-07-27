/*
				   File: type_SdtGoogleChart
			Description: GoogleChart
				 Author: Nemo 🐠 for C# version 16.0.11.147071
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Services.Protocols;


namespace GeneXus.Programs
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="GoogleChart")]
	[XmlType(TypeName="GoogleChart" , Namespace="ADMINDATA1" )]
	[Serializable]
	public class SdtGoogleChart : GxUserType
	{
		public SdtGoogleChart( )
		{
			/* Constructor for serialization */
		}

		public SdtGoogleChart(IGxContext context)
		{
			this.context = context;
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override String JsonMap(String value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (String)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			if (gxTv_SdtGoogleChart_Categories != null)
			{
				AddObjectProperty("Categories", gxTv_SdtGoogleChart_Categories, false);  
			}
			if (gxTv_SdtGoogleChart_Series != null)
			{
				AddObjectProperty("Series", gxTv_SdtGoogleChart_Series, false);  
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Categories" )]
		[XmlArray(ElementName="Categories"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<String> gxTpr_Categories_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtGoogleChart_Categories == null )
				{
					gxTv_SdtGoogleChart_Categories = new GxSimpleCollection<String>( );
				}
				return gxTv_SdtGoogleChart_Categories;
			}
			set {
				if ( gxTv_SdtGoogleChart_Categories == null )
				{
					gxTv_SdtGoogleChart_Categories = new GxSimpleCollection<String>( );
				}
				gxTv_SdtGoogleChart_Categories_N = 0;

				gxTv_SdtGoogleChart_Categories = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GxSimpleCollection<String> gxTpr_Categories
		{
			get {
				if ( gxTv_SdtGoogleChart_Categories == null )
				{
					gxTv_SdtGoogleChart_Categories = new GxSimpleCollection<String>();
				}
				gxTv_SdtGoogleChart_Categories_N = 0;

				return gxTv_SdtGoogleChart_Categories ;
			}
			set {
				gxTv_SdtGoogleChart_Categories_N = 0;

				gxTv_SdtGoogleChart_Categories = value;
				SetDirty("Categories");
			}
		}

		public void gxTv_SdtGoogleChart_Categories_SetNull()
		{
			gxTv_SdtGoogleChart_Categories_N = 1;

			gxTv_SdtGoogleChart_Categories = null;
			return  ;
		}

		public bool gxTv_SdtGoogleChart_Categories_IsNull()
		{
			if (gxTv_SdtGoogleChart_Categories == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Categories_GxSimpleCollection_Json()
		{
				return gxTv_SdtGoogleChart_Categories != null && gxTv_SdtGoogleChart_Categories.Count > 0;

		}


		[SoapElement(ElementName="Series" )]
		[XmlArray(ElementName="Series"  )]
		[XmlArrayItemAttribute(ElementName="Series" , IsNullable=false )]
		public GXBaseCollection<SdtGoogleChart_Series> gxTpr_Series
		{
			get {
				if ( gxTv_SdtGoogleChart_Series == null )
				{
					gxTv_SdtGoogleChart_Series = new GXBaseCollection<SdtGoogleChart_Series>( context, "GoogleChart.Series", "");
				}
				return gxTv_SdtGoogleChart_Series;
			}
			set {
				if ( gxTv_SdtGoogleChart_Series == null )
				{
					gxTv_SdtGoogleChart_Series = new GXBaseCollection<SdtGoogleChart_Series>( context, "GoogleChart.Series", "");
				}
				gxTv_SdtGoogleChart_Series_N = 0;

				gxTv_SdtGoogleChart_Series = value;
				SetDirty("Series");
			}
		}

		public void gxTv_SdtGoogleChart_Series_SetNull()
		{
			gxTv_SdtGoogleChart_Series_N = 1;

			gxTv_SdtGoogleChart_Series = null;
			return  ;
		}

		public bool gxTv_SdtGoogleChart_Series_IsNull()
		{
			if (gxTv_SdtGoogleChart_Series == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Series_GxSimpleCollection_Json()
		{
				return gxTv_SdtGoogleChart_Series != null && gxTv_SdtGoogleChart_Series.Count > 0;

		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtGoogleChart_Categories_N = 1;


			gxTv_SdtGoogleChart_Series_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtGoogleChart_Categories_N;
		protected GxSimpleCollection<String> gxTv_SdtGoogleChart_Categories = null;  
		protected short gxTv_SdtGoogleChart_Series_N;
		protected GXBaseCollection<SdtGoogleChart_Series> gxTv_SdtGoogleChart_Series = null; 



		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"GoogleChart", Namespace="ADMINDATA1")]
	public class SdtGoogleChart_RESTInterface : GxGenericCollectionItem<SdtGoogleChart>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtGoogleChart_RESTInterface( ) : base()
		{
		}

		public SdtGoogleChart_RESTInterface( SdtGoogleChart psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Categories", Order=0, EmitDefaultValue=false)]
		public  GxSimpleCollection<String> gxTpr_Categories
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Categories_GxSimpleCollection_Json())
					return sdt.gxTpr_Categories;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Categories = value ;
			}
		}

		[DataMember(Name="Series", Order=1, EmitDefaultValue=false)]
		public GxGenericCollection<SdtGoogleChart_Series_RESTInterface> gxTpr_Series
		{
			get {
				if (sdt.ShouldSerializegxTpr_Series_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtGoogleChart_Series_RESTInterface>(sdt.gxTpr_Series);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Series);
			}
		}


		#endregion

		public SdtGoogleChart sdt
		{
			get { 
				return (SdtGoogleChart)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtGoogleChart() ;
			}
		}
	}
	#endregion
}