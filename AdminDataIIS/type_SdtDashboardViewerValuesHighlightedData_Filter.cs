/*
				   File: type_SdtDashboardViewerValuesHighlightedData_Filter
			Description: AllFilters
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
	[XmlRoot(ElementName="DashboardViewerValuesHighlightedData.Filter")]
	[XmlType(TypeName="DashboardViewerValuesHighlightedData.Filter" , Namespace="ADMINDATA1" )]
	[Serializable]
	public class SdtDashboardViewerValuesHighlightedData_Filter : GxUserType
	{
		public SdtDashboardViewerValuesHighlightedData_Filter( )
		{
			/* Constructor for serialization */
			gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Name = "";

		}

		public SdtDashboardViewerValuesHighlightedData_Filter(IGxContext context)
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
			AddObjectProperty("Name", gxTpr_Name, false);

			if (gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values != null)
			{
				AddObjectProperty("Values", gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values, false);  
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public String gxTpr_Name
		{
			get { 
				return gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Name; 
			}
			set { 
				gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Values" )]
		[XmlArray(ElementName="Values"  )]
		[XmlArrayItemAttribute(ElementName="Value" , IsNullable=false )]
		public GxSimpleCollection<String> gxTpr_Values_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values == null )
				{
					gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values = new GxSimpleCollection<String>( );
				}
				return gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values;
			}
			set {
				if ( gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values == null )
				{
					gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values = new GxSimpleCollection<String>( );
				}
				gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values_N = 0;

				gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GxSimpleCollection<String> gxTpr_Values
		{
			get {
				if ( gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values == null )
				{
					gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values = new GxSimpleCollection<String>();
				}
				gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values_N = 0;

				return gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values ;
			}
			set {
				gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values_N = 0;

				gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values = value;
				SetDirty("Values");
			}
		}

		public void gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values_SetNull()
		{
			gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values_N = 1;

			gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values = null;
			return  ;
		}

		public bool gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values_IsNull()
		{
			if (gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Values_GxSimpleCollection_Json()
		{
				return gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values != null && gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values.Count > 0;

		}


		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Name = "";

			gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected String gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Name;
		 
		protected short gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values_N;
		protected GxSimpleCollection<String> gxTv_SdtDashboardViewerValuesHighlightedData_Filter_Values = null;  


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"DashboardViewerValuesHighlightedData.Filter", Namespace="ADMINDATA1")]
	public class SdtDashboardViewerValuesHighlightedData_Filter_RESTInterface : GxGenericCollectionItem<SdtDashboardViewerValuesHighlightedData_Filter>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtDashboardViewerValuesHighlightedData_Filter_RESTInterface( ) : base()
		{
		}

		public SdtDashboardViewerValuesHighlightedData_Filter_RESTInterface( SdtDashboardViewerValuesHighlightedData_Filter psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Name", Order=0)]
		public  String gxTpr_Name
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Name);

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="Values", Order=1, EmitDefaultValue=false)]
		public  GxSimpleCollection<String> gxTpr_Values
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Values_GxSimpleCollection_Json())
					return sdt.gxTpr_Values;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Values = value ;
			}
		}


		#endregion

		public SdtDashboardViewerValuesHighlightedData_Filter sdt
		{
			get { 
				return (SdtDashboardViewerValuesHighlightedData_Filter)Sdt;
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
				sdt = new SdtDashboardViewerValuesHighlightedData_Filter() ;
			}
		}
	}
	#endregion
}