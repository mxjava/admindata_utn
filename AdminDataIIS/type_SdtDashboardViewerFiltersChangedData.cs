/*
				   File: type_SdtDashboardViewerFiltersChangedData
			Description: DashboardViewerFiltersChangedData
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
	[XmlRoot(ElementName="DashboardViewerFiltersChangedData")]
	[XmlType(TypeName="DashboardViewerFiltersChangedData" , Namespace="ADMINDATA1" )]
	[Serializable]
	public class SdtDashboardViewerFiltersChangedData : GxUserType
	{
		public SdtDashboardViewerFiltersChangedData( )
		{
			/* Constructor for serialization */
		}

		public SdtDashboardViewerFiltersChangedData(IGxContext context)
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
			if (gxTv_SdtDashboardViewerFiltersChangedData_Changedfilters != null)
			{
				AddObjectProperty("ChangedFilters", gxTv_SdtDashboardViewerFiltersChangedData_Changedfilters, false);  
			}
			if (gxTv_SdtDashboardViewerFiltersChangedData_Allfilters != null)
			{
				AddObjectProperty("AllFilters", gxTv_SdtDashboardViewerFiltersChangedData_Allfilters, false);  
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ChangedFilters" )]
		[XmlArray(ElementName="ChangedFilters"  )]
		[XmlArrayItemAttribute(ElementName="ChangedFilter" , IsNullable=false )]
		public GXBaseCollection<SdtDashboardViewerFiltersChangedData_ChangedFilter> gxTpr_Changedfilters
		{
			get {
				if ( gxTv_SdtDashboardViewerFiltersChangedData_Changedfilters == null )
				{
					gxTv_SdtDashboardViewerFiltersChangedData_Changedfilters = new GXBaseCollection<SdtDashboardViewerFiltersChangedData_ChangedFilter>( context, "DashboardViewerFiltersChangedData.ChangedFilter", "");
				}
				return gxTv_SdtDashboardViewerFiltersChangedData_Changedfilters;
			}
			set {
				if ( gxTv_SdtDashboardViewerFiltersChangedData_Changedfilters == null )
				{
					gxTv_SdtDashboardViewerFiltersChangedData_Changedfilters = new GXBaseCollection<SdtDashboardViewerFiltersChangedData_ChangedFilter>( context, "DashboardViewerFiltersChangedData.ChangedFilter", "");
				}
				gxTv_SdtDashboardViewerFiltersChangedData_Changedfilters_N = 0;

				gxTv_SdtDashboardViewerFiltersChangedData_Changedfilters = value;
				SetDirty("Changedfilters");
			}
		}

		public void gxTv_SdtDashboardViewerFiltersChangedData_Changedfilters_SetNull()
		{
			gxTv_SdtDashboardViewerFiltersChangedData_Changedfilters_N = 1;

			gxTv_SdtDashboardViewerFiltersChangedData_Changedfilters = null;
			return  ;
		}

		public bool gxTv_SdtDashboardViewerFiltersChangedData_Changedfilters_IsNull()
		{
			if (gxTv_SdtDashboardViewerFiltersChangedData_Changedfilters == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Changedfilters_GxSimpleCollection_Json()
		{
				return gxTv_SdtDashboardViewerFiltersChangedData_Changedfilters != null && gxTv_SdtDashboardViewerFiltersChangedData_Changedfilters.Count > 0;

		}



		[SoapElement(ElementName="AllFilters" )]
		[XmlArray(ElementName="AllFilters"  )]
		[XmlArrayItemAttribute(ElementName="Filter" , IsNullable=false )]
		public GXBaseCollection<SdtDashboardViewerFiltersChangedData_Filter> gxTpr_Allfilters
		{
			get {
				if ( gxTv_SdtDashboardViewerFiltersChangedData_Allfilters == null )
				{
					gxTv_SdtDashboardViewerFiltersChangedData_Allfilters = new GXBaseCollection<SdtDashboardViewerFiltersChangedData_Filter>( context, "DashboardViewerFiltersChangedData.Filter", "");
				}
				return gxTv_SdtDashboardViewerFiltersChangedData_Allfilters;
			}
			set {
				if ( gxTv_SdtDashboardViewerFiltersChangedData_Allfilters == null )
				{
					gxTv_SdtDashboardViewerFiltersChangedData_Allfilters = new GXBaseCollection<SdtDashboardViewerFiltersChangedData_Filter>( context, "DashboardViewerFiltersChangedData.Filter", "");
				}
				gxTv_SdtDashboardViewerFiltersChangedData_Allfilters_N = 0;

				gxTv_SdtDashboardViewerFiltersChangedData_Allfilters = value;
				SetDirty("Allfilters");
			}
		}

		public void gxTv_SdtDashboardViewerFiltersChangedData_Allfilters_SetNull()
		{
			gxTv_SdtDashboardViewerFiltersChangedData_Allfilters_N = 1;

			gxTv_SdtDashboardViewerFiltersChangedData_Allfilters = null;
			return  ;
		}

		public bool gxTv_SdtDashboardViewerFiltersChangedData_Allfilters_IsNull()
		{
			if (gxTv_SdtDashboardViewerFiltersChangedData_Allfilters == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Allfilters_GxSimpleCollection_Json()
		{
				return gxTv_SdtDashboardViewerFiltersChangedData_Allfilters != null && gxTv_SdtDashboardViewerFiltersChangedData_Allfilters.Count > 0;

		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtDashboardViewerFiltersChangedData_Changedfilters_N = 1;


			gxTv_SdtDashboardViewerFiltersChangedData_Allfilters_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtDashboardViewerFiltersChangedData_Changedfilters_N;
		protected GXBaseCollection<SdtDashboardViewerFiltersChangedData_ChangedFilter> gxTv_SdtDashboardViewerFiltersChangedData_Changedfilters = null; 

		protected short gxTv_SdtDashboardViewerFiltersChangedData_Allfilters_N;
		protected GXBaseCollection<SdtDashboardViewerFiltersChangedData_Filter> gxTv_SdtDashboardViewerFiltersChangedData_Allfilters = null; 



		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"DashboardViewerFiltersChangedData", Namespace="ADMINDATA1")]
	public class SdtDashboardViewerFiltersChangedData_RESTInterface : GxGenericCollectionItem<SdtDashboardViewerFiltersChangedData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtDashboardViewerFiltersChangedData_RESTInterface( ) : base()
		{
		}

		public SdtDashboardViewerFiltersChangedData_RESTInterface( SdtDashboardViewerFiltersChangedData psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="ChangedFilters", Order=0, EmitDefaultValue=false)]
		public GxGenericCollection<SdtDashboardViewerFiltersChangedData_ChangedFilter_RESTInterface> gxTpr_Changedfilters
		{
			get {
				if (sdt.ShouldSerializegxTpr_Changedfilters_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtDashboardViewerFiltersChangedData_ChangedFilter_RESTInterface>(sdt.gxTpr_Changedfilters);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Changedfilters);
			}
		}

		[DataMember(Name="AllFilters", Order=1, EmitDefaultValue=false)]
		public GxGenericCollection<SdtDashboardViewerFiltersChangedData_Filter_RESTInterface> gxTpr_Allfilters
		{
			get {
				if (sdt.ShouldSerializegxTpr_Allfilters_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtDashboardViewerFiltersChangedData_Filter_RESTInterface>(sdt.gxTpr_Allfilters);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Allfilters);
			}
		}


		#endregion

		public SdtDashboardViewerFiltersChangedData sdt
		{
			get { 
				return (SdtDashboardViewerFiltersChangedData)Sdt;
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
				sdt = new SdtDashboardViewerFiltersChangedData() ;
			}
		}
	}
	#endregion
}