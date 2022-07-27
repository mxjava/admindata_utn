/*
				   File: type_SdtSDTUsuArea_SDTUsuAreaItem
			Description: SDTUsuArea
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
	[XmlRoot(ElementName="SDTUsuAreaItem")]
	[XmlType(TypeName="SDTUsuAreaItem" , Namespace="ADMINDATA1" )]
	[Serializable]
	public class SdtSDTUsuArea_SDTUsuAreaItem : GxUserType
	{
		public SdtSDTUsuArea_SDTUsuAreaItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTUsuArea_SDTUsuAreaItem_Areadesc = "";

		}

		public SdtSDTUsuArea_SDTUsuAreaItem(IGxContext context)
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
			AddObjectProperty("UsuariosId", gxTpr_Usuariosid, false);


			AddObjectProperty("AreaId", gxTpr_Areaid, false);


			AddObjectProperty("AreaDesc", gxTpr_Areadesc, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="UsuariosId")]
		[XmlElement(ElementName="UsuariosId")]
		public int gxTpr_Usuariosid
		{
			get { 
				return gxTv_SdtSDTUsuArea_SDTUsuAreaItem_Usuariosid; 
			}
			set { 
				gxTv_SdtSDTUsuArea_SDTUsuAreaItem_Usuariosid = value;
				SetDirty("Usuariosid");
			}
		}




		[SoapElement(ElementName="AreaId")]
		[XmlElement(ElementName="AreaId")]
		public int gxTpr_Areaid
		{
			get { 
				return gxTv_SdtSDTUsuArea_SDTUsuAreaItem_Areaid; 
			}
			set { 
				gxTv_SdtSDTUsuArea_SDTUsuAreaItem_Areaid = value;
				SetDirty("Areaid");
			}
		}




		[SoapElement(ElementName="AreaDesc")]
		[XmlElement(ElementName="AreaDesc")]
		public String gxTpr_Areadesc
		{
			get { 
				return gxTv_SdtSDTUsuArea_SDTUsuAreaItem_Areadesc; 
			}
			set { 
				gxTv_SdtSDTUsuArea_SDTUsuAreaItem_Areadesc = value;
				SetDirty("Areadesc");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDTUsuArea_SDTUsuAreaItem_Areadesc = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSDTUsuArea_SDTUsuAreaItem_Usuariosid;
		 

		protected int gxTv_SdtSDTUsuArea_SDTUsuAreaItem_Areaid;
		 

		protected String gxTv_SdtSDTUsuArea_SDTUsuAreaItem_Areadesc;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTUsuAreaItem", Namespace="ADMINDATA1")]
	public class SdtSDTUsuArea_SDTUsuAreaItem_RESTInterface : GxGenericCollectionItem<SdtSDTUsuArea_SDTUsuAreaItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTUsuArea_SDTUsuAreaItem_RESTInterface( ) : base()
		{
		}

		public SdtSDTUsuArea_SDTUsuAreaItem_RESTInterface( SdtSDTUsuArea_SDTUsuAreaItem psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="UsuariosId", Order=0)]
		public int gxTpr_Usuariosid
		{
			get { 
				return sdt.gxTpr_Usuariosid;

			}
			set { 
				sdt.gxTpr_Usuariosid = value;
			}
		}

		[DataMember(Name="AreaId", Order=1)]
		public  String gxTpr_Areaid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Areaid, 9, 0));

			}
			set { 
				sdt.gxTpr_Areaid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="AreaDesc", Order=2)]
		public  String gxTpr_Areadesc
		{
			get { 
				return sdt.gxTpr_Areadesc;

			}
			set { 
				 sdt.gxTpr_Areadesc = value;
			}
		}


		#endregion

		public SdtSDTUsuArea_SDTUsuAreaItem sdt
		{
			get { 
				return (SdtSDTUsuArea_SDTUsuAreaItem)Sdt;
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
				sdt = new SdtSDTUsuArea_SDTUsuAreaItem() ;
			}
		}
	}
	#endregion
}