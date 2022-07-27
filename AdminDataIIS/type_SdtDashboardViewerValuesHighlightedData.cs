/*
				   File: type_SdtDashboardViewerValuesHighlightedData
			Description: DashboardViewerValuesHighlightedData
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
	[XmlRoot(ElementName="DashboardViewerValuesHighlightedData")]
	[XmlType(TypeName="DashboardViewerValuesHighlightedData" , Namespace="ADMINDATA1" )]
	[Serializable]
	public class SdtDashboardViewerValuesHighlightedData : GxUserType
	{
		public SdtDashboardViewerValuesHighlightedData( )
		{
			/* Constructor for serialization */
		}

		public SdtDashboardViewerValuesHighlightedData(IGxContext context)
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
			if (gxTv_SdtDashboardViewerValuesHighlightedData_Elements != null)
			{
				AddObjectProperty("Elements", gxTv_SdtDashboardViewerValuesHighlightedData_Elements, false);  
			}
			if (gxTv_SdtDashboardViewerValuesHighlightedData_Allfilters != null)
			{
				AddObjectProperty("AllFilters", gxTv_SdtDashboardViewerValuesHighlightedData_Allfilters, false);  
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Elements" )]
		[XmlArray(ElementName="Elements"  )]
		[XmlArrayItemAttribute(ElementName="Element" , IsNullable=false )]
		public GXBaseCollection<SdtDashboardViewerValuesHighlightedData_Element> gxTpr_Elements
		{
			get {
				if ( gxTv_SdtDashboardViewerValuesHighlightedData_Elements == null )
				{
					gxTv_SdtDashboardViewerValuesHighlightedData_Elements = new GXBaseCollection<SdtDashboardViewerValuesHighlightedData_Element>( context, "DashboardViewerValuesHighlightedData.Element", "");
				}
				return gxTv_SdtDashboardViewerValuesHighlightedData_Elements;
			}
			set {
				if ( gxTv_SdtDashboardViewerValuesHighlightedData_Elements == null )
				{
					gxTv_SdtDashboardViewerValuesHighlightedData_Elements = new GXBaseCollection<SdtDashboardViewerValuesHighlightedData_Element>( context, "DashboardViewerValuesHighlightedData.Element", "");
				}
				gxTv_SdtDashboardViewerValuesHighlightedData_Elements_N = 0;

				gxTv_SdtDashboardViewerValuesHighlightedData_Elements = value;
				SetDirty("Elements");
			}
		}

		public void gxTv_SdtDashboardViewerValuesHighlightedData_Elements_SetNull()
		{
			gxTv_SdtDashboardViewerValuesHighlightedData_Elements_N = 1;

			gxTv_SdtDashboardViewerValuesHighlightedData_Elements = null;
			return  ;
		}

		public bool gxTv_SdtDashboardViewerValuesHighlightedData_Elements_IsNull()
		{
			if (gxTv_SdtDashboardViewerValuesHighlightedData_Elements == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Elements_GxSimpleCollection_Json()
		{
				return gxTv_SdtDashboardViewerValuesHighlightedData_Elements != null && gxTv_SdtDashboardViewerValuesHighlightedData_Elements.Count > 0;

		}



		[SoapElement(ElementName="AllFilters" )]
		[XmlArray(ElementName="AllFilters"  )]
		[XmlArrayItemAttribute(ElementName="Filter" , IsNullable=false )]
		public GXBaseCollection<SdtDashboardViewerValuesHighlightedData_Filter> gxTpr_Allfilters
		{
			get {
				if ( gxTv_SdtDashboardViewerValuesHighlightedData_Allfilters == null )
				{
					gxTv_SdtDashboardViewerValuesHighlightedData_Allfilters = new GXBaseCollection<SdtDashboardViewerValuesHighlightedData_Filter>( context, "DashboardViewerValuesHighlightedData.Filter", "");
				}
				return gxTv_SdtDashboardViewerValuesHighlightedData_Allfilters;
			}
			set {
				if ( gxTv_SdtDashboardViewerValuesHighlightedData_Allfilters == null )
				{
					gxTv_SdtDashboardViewerValuesHighlightedData_Allfilters = new GXBaseCollection<SdtDashboardViewerValuesHighlightedData_Filter>( context, "DashboardViewerValuesHighlightedData.Filter", "");
				}
				gxTv_SdtDashboardViewerValuesHighlightedData_Allfilters_N = 0;

				gxTv_SdtDashboardViewerValuesHighlightedData_Allfilters = value;
				SetDirty("Allfilters");
			}
		}

		public void gxTv_SdtDashboardViewerValuesHighlightedData_Allfilters_SetNull()
		{
			gxTv_SdtDashboardViewerValuesHighlightedData_Allfilters_N = 1;

			gxTv_SdtDashboardViewerValuesHighlightedData_Allfilters = null;
			return  ;
		}

		public bool gxTv_SdtDashboardViewerValuesHighlightedData_Allfilters_IsNull()
		{
			if (gxTv_SdtDashboardViewerValuesHighlightedData_Allfilters == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Allfilters_GxSimpleCollection_Json()
		{
				return gxTv_SdtDashboardViewerValuesHighlightedData_Allfilters != null && gxTv_SdtDashboardViewerValuesHighlightedData_Allfilters.Count > 0;

		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtDashboardViewerValuesHighlightedData_Elements_N = 1;


			gxTv_SdtDashboardViewerValuesHighlightedData_Allfilters_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtDashboardViewerValuesHighlightedData_Elements_N;
		protected GXBaseCollection<SdtDashboardViewerValuesHighlightedData_Element> gxTv_SdtDashboardViewerValuesHighlightedData_Elements = null; 

		protected short gxTv_SdtDashboardViewerValuesHighlightedData_Allfilters_N;
		protected GXBaseCollection<SdtDashboardViewerValuesHighlightedData_Filter> gxTv_SdtDashboardViewerValuesHighlightedData_Allfilters = null; 



		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"DashboardViewerValuesHighlightedData", Namespace="ADMINDATA1")]
	public class SdtDashboardViewerValuesHighlightedData_RESTInterface : GxGenericCollectionItem<SdtDashboardViewerValuesHighlightedData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtDashboardViewerValuesHighlightedData_RESTInterface( ) : base()
		{
		}

		public SdtDashboardViewerValuesHighlightedData_RESTInterface( SdtDashboardViewerValuesHighlightedData psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Elements", Order=0, EmitDefaultValue=false)]
		public GxGenericCollection<SdtDashboardViewerValuesHighlightedData_Element_RESTInterface> gxTpr_Elements
		{
			get {
				if (sdt.ShouldSerializegxTpr_Elements_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtDashboardViewerValuesHighlightedData_Element_RESTInterface>(sdt.gxTpr_Elements);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Elements);
			}
		}

		[DataMember(Name="AllFilters", Order=1, EmitDefaultValue=false)]
		public GxGenericCollection<SdtDashboardViewerValuesHighlightedData_Filter_RESTInterface> gxTpr_Allfilters
		{
			get {
				if (sdt.ShouldSerializegxTpr_Allfilters_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtDashboardViewerValuesHighlightedData_Filter_RESTInterface>(sdt.gxTpr_Allfilters);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Allfilters);
			}
		}


		#endregion

		public SdtDashboardViewerValuesHighlightedData sdt
		{
			get { 
				return (SdtDashboardViewerValuesHighlightedData)Sdt;
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
				sdt = new SdtDashboardViewerValuesHighlightedData() ;
			}
		}
	}
	#endregion
}