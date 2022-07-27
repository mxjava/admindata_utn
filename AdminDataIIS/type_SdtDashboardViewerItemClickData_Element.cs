/*
				   File: type_SdtDashboardViewerItemClickData_Element
			Description: Context
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
	[XmlRoot(ElementName="DashboardViewerItemClickData.Element")]
	[XmlType(TypeName="DashboardViewerItemClickData.Element" , Namespace="ADMINDATA1" )]
	[Serializable]
	public class SdtDashboardViewerItemClickData_Element : GxUserType
	{
		public SdtDashboardViewerItemClickData_Element( )
		{
			/* Constructor for serialization */
			gxTv_SdtDashboardViewerItemClickData_Element_Name = "";

		}

		public SdtDashboardViewerItemClickData_Element(IGxContext context)
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

			if (gxTv_SdtDashboardViewerItemClickData_Element_Values != null)
			{
				AddObjectProperty("Values", gxTv_SdtDashboardViewerItemClickData_Element_Values, false);  
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
				return gxTv_SdtDashboardViewerItemClickData_Element_Name; 
			}
			set { 
				gxTv_SdtDashboardViewerItemClickData_Element_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Values" )]
		[XmlArray(ElementName="Values"  )]
		[XmlArrayItemAttribute(ElementName="Value" , IsNullable=false )]
		public GxSimpleCollection<String> gxTpr_Values_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtDashboardViewerItemClickData_Element_Values == null )
				{
					gxTv_SdtDashboardViewerItemClickData_Element_Values = new GxSimpleCollection<String>( );
				}
				return gxTv_SdtDashboardViewerItemClickData_Element_Values;
			}
			set {
				if ( gxTv_SdtDashboardViewerItemClickData_Element_Values == null )
				{
					gxTv_SdtDashboardViewerItemClickData_Element_Values = new GxSimpleCollection<String>( );
				}
				gxTv_SdtDashboardViewerItemClickData_Element_Values_N = 0;

				gxTv_SdtDashboardViewerItemClickData_Element_Values = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GxSimpleCollection<String> gxTpr_Values
		{
			get {
				if ( gxTv_SdtDashboardViewerItemClickData_Element_Values == null )
				{
					gxTv_SdtDashboardViewerItemClickData_Element_Values = new GxSimpleCollection<String>();
				}
				gxTv_SdtDashboardViewerItemClickData_Element_Values_N = 0;

				return gxTv_SdtDashboardViewerItemClickData_Element_Values ;
			}
			set {
				gxTv_SdtDashboardViewerItemClickData_Element_Values_N = 0;

				gxTv_SdtDashboardViewerItemClickData_Element_Values = value;
				SetDirty("Values");
			}
		}

		public void gxTv_SdtDashboardViewerItemClickData_Element_Values_SetNull()
		{
			gxTv_SdtDashboardViewerItemClickData_Element_Values_N = 1;

			gxTv_SdtDashboardViewerItemClickData_Element_Values = null;
			return  ;
		}

		public bool gxTv_SdtDashboardViewerItemClickData_Element_Values_IsNull()
		{
			if (gxTv_SdtDashboardViewerItemClickData_Element_Values == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Values_GxSimpleCollection_Json()
		{
				return gxTv_SdtDashboardViewerItemClickData_Element_Values != null && gxTv_SdtDashboardViewerItemClickData_Element_Values.Count > 0;

		}


		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtDashboardViewerItemClickData_Element_Name = "";

			gxTv_SdtDashboardViewerItemClickData_Element_Values_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected String gxTv_SdtDashboardViewerItemClickData_Element_Name;
		 
		protected short gxTv_SdtDashboardViewerItemClickData_Element_Values_N;
		protected GxSimpleCollection<String> gxTv_SdtDashboardViewerItemClickData_Element_Values = null;  


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"DashboardViewerItemClickData.Element", Namespace="ADMINDATA1")]
	public class SdtDashboardViewerItemClickData_Element_RESTInterface : GxGenericCollectionItem<SdtDashboardViewerItemClickData_Element>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtDashboardViewerItemClickData_Element_RESTInterface( ) : base()
		{
		}

		public SdtDashboardViewerItemClickData_Element_RESTInterface( SdtDashboardViewerItemClickData_Element psdt ) : base(psdt)
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

		public SdtDashboardViewerItemClickData_Element sdt
		{
			get { 
				return (SdtDashboardViewerItemClickData_Element)Sdt;
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
				sdt = new SdtDashboardViewerItemClickData_Element() ;
			}
		}
	}
	#endregion
}