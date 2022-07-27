/*
				   File: type_SdtGridState
			Description: GridState
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
	[XmlRoot(ElementName="GridState")]
	[XmlType(TypeName="GridState" , Namespace="ADMINDATA1" )]
	[Serializable]
	public class SdtGridState : GxUserType
	{
		public SdtGridState( )
		{
			/* Constructor for serialization */
		}

		public SdtGridState(IGxContext context)
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
			AddObjectProperty("CurrentPage", gxTpr_Currentpage, false);


			AddObjectProperty("OrderedBy", gxTpr_Orderedby, false);


			AddObjectProperty("HidingSearch", gxTpr_Hidingsearch, false);

			if (gxTv_SdtGridState_Filtervalues != null)
			{
				AddObjectProperty("FilterValues", gxTv_SdtGridState_Filtervalues, false);  
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CurrentPage")]
		[XmlElement(ElementName="CurrentPage")]
		public short gxTpr_Currentpage
		{
			get { 
				return gxTv_SdtGridState_Currentpage; 
			}
			set { 
				gxTv_SdtGridState_Currentpage = value;
				SetDirty("Currentpage");
			}
		}




		[SoapElement(ElementName="OrderedBy")]
		[XmlElement(ElementName="OrderedBy")]
		public short gxTpr_Orderedby
		{
			get { 
				return gxTv_SdtGridState_Orderedby; 
			}
			set { 
				gxTv_SdtGridState_Orderedby = value;
				SetDirty("Orderedby");
			}
		}




		[SoapElement(ElementName="HidingSearch")]
		[XmlElement(ElementName="HidingSearch")]
		public short gxTpr_Hidingsearch
		{
			get { 
				return gxTv_SdtGridState_Hidingsearch; 
			}
			set { 
				gxTv_SdtGridState_Hidingsearch = value;
				SetDirty("Hidingsearch");
			}
		}




		[SoapElement(ElementName="FilterValues" )]
		[XmlArray(ElementName="FilterValues"  )]
		[XmlArrayItemAttribute(ElementName="FilterValue" , IsNullable=false )]
		public GXBaseCollection<SdtGridState_FilterValue> gxTpr_Filtervalues
		{
			get {
				if ( gxTv_SdtGridState_Filtervalues == null )
				{
					gxTv_SdtGridState_Filtervalues = new GXBaseCollection<SdtGridState_FilterValue>( context, "GridState.FilterValue", "");
				}
				return gxTv_SdtGridState_Filtervalues;
			}
			set {
				if ( gxTv_SdtGridState_Filtervalues == null )
				{
					gxTv_SdtGridState_Filtervalues = new GXBaseCollection<SdtGridState_FilterValue>( context, "GridState.FilterValue", "");
				}
				gxTv_SdtGridState_Filtervalues_N = 0;

				gxTv_SdtGridState_Filtervalues = value;
				SetDirty("Filtervalues");
			}
		}

		public void gxTv_SdtGridState_Filtervalues_SetNull()
		{
			gxTv_SdtGridState_Filtervalues_N = 1;

			gxTv_SdtGridState_Filtervalues = null;
			return  ;
		}

		public bool gxTv_SdtGridState_Filtervalues_IsNull()
		{
			if (gxTv_SdtGridState_Filtervalues == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Filtervalues_GxSimpleCollection_Json()
		{
				return gxTv_SdtGridState_Filtervalues != null && gxTv_SdtGridState_Filtervalues.Count > 0;

		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtGridState_Filtervalues_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtGridState_Currentpage;
		 

		protected short gxTv_SdtGridState_Orderedby;
		 

		protected short gxTv_SdtGridState_Hidingsearch;
		 
		protected short gxTv_SdtGridState_Filtervalues_N;
		protected GXBaseCollection<SdtGridState_FilterValue> gxTv_SdtGridState_Filtervalues = null; 



		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"GridState", Namespace="ADMINDATA1")]
	public class SdtGridState_RESTInterface : GxGenericCollectionItem<SdtGridState>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtGridState_RESTInterface( ) : base()
		{
		}

		public SdtGridState_RESTInterface( SdtGridState psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="CurrentPage", Order=0)]
		public short gxTpr_Currentpage
		{
			get { 
				return sdt.gxTpr_Currentpage;

			}
			set { 
				sdt.gxTpr_Currentpage = value;
			}
		}

		[DataMember(Name="OrderedBy", Order=1)]
		public short gxTpr_Orderedby
		{
			get { 
				return sdt.gxTpr_Orderedby;

			}
			set { 
				sdt.gxTpr_Orderedby = value;
			}
		}

		[DataMember(Name="HidingSearch", Order=2)]
		public short gxTpr_Hidingsearch
		{
			get { 
				return sdt.gxTpr_Hidingsearch;

			}
			set { 
				sdt.gxTpr_Hidingsearch = value;
			}
		}

		[DataMember(Name="FilterValues", Order=3, EmitDefaultValue=false)]
		public GxGenericCollection<SdtGridState_FilterValue_RESTInterface> gxTpr_Filtervalues
		{
			get {
				if (sdt.ShouldSerializegxTpr_Filtervalues_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtGridState_FilterValue_RESTInterface>(sdt.gxTpr_Filtervalues);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Filtervalues);
			}
		}


		#endregion

		public SdtGridState sdt
		{
			get { 
				return (SdtGridState)Sdt;
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
				sdt = new SdtGridState() ;
			}
		}
	}
	#endregion
}