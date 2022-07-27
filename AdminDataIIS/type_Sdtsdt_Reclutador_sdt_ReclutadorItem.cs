/*
				   File: type_Sdtsdt_Reclutador_sdt_ReclutadorItem
			Description: sdt_Reclutador
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
	[XmlRoot(ElementName="sdt_ReclutadorItem")]
	[XmlType(TypeName="sdt_ReclutadorItem" , Namespace="ADMINDATA1" )]
	[Serializable]
	public class Sdtsdt_Reclutador_sdt_ReclutadorItem : GxUserType
	{
		public Sdtsdt_Reclutador_sdt_ReclutadorItem( )
		{
			/* Constructor for serialization */
		}

		public Sdtsdt_Reclutador_sdt_ReclutadorItem(IGxContext context)
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
			AddObjectProperty("SubT_ReclutadorId", gxTpr_Subt_reclutadorid, false);


			AddObjectProperty("Conteo", gxTpr_Conteo, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SubT_ReclutadorId")]
		[XmlElement(ElementName="SubT_ReclutadorId")]
		public int gxTpr_Subt_reclutadorid
		{
			get { 
				return gxTv_Sdtsdt_Reclutador_sdt_ReclutadorItem_Subt_reclutadorid; 
			}
			set { 
				gxTv_Sdtsdt_Reclutador_sdt_ReclutadorItem_Subt_reclutadorid = value;
				SetDirty("Subt_reclutadorid");
			}
		}




		[SoapElement(ElementName="Conteo")]
		[XmlElement(ElementName="Conteo")]
		public short gxTpr_Conteo
		{
			get { 
				return gxTv_Sdtsdt_Reclutador_sdt_ReclutadorItem_Conteo; 
			}
			set { 
				gxTv_Sdtsdt_Reclutador_sdt_ReclutadorItem_Conteo = value;
				SetDirty("Conteo");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_Sdtsdt_Reclutador_sdt_ReclutadorItem_Subt_reclutadorid;
		 

		protected short gxTv_Sdtsdt_Reclutador_sdt_ReclutadorItem_Conteo;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"sdt_ReclutadorItem", Namespace="ADMINDATA1")]
	public class Sdtsdt_Reclutador_sdt_ReclutadorItem_RESTInterface : GxGenericCollectionItem<Sdtsdt_Reclutador_sdt_ReclutadorItem>, System.Web.SessionState.IRequiresSessionState
	{
		public Sdtsdt_Reclutador_sdt_ReclutadorItem_RESTInterface( ) : base()
		{
		}

		public Sdtsdt_Reclutador_sdt_ReclutadorItem_RESTInterface( Sdtsdt_Reclutador_sdt_ReclutadorItem psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="SubT_ReclutadorId", Order=0)]
		public int gxTpr_Subt_reclutadorid
		{
			get { 
				return sdt.gxTpr_Subt_reclutadorid;

			}
			set { 
				sdt.gxTpr_Subt_reclutadorid = value;
			}
		}

		[DataMember(Name="Conteo", Order=1)]
		public short gxTpr_Conteo
		{
			get { 
				return sdt.gxTpr_Conteo;

			}
			set { 
				sdt.gxTpr_Conteo = value;
			}
		}


		#endregion

		public Sdtsdt_Reclutador_sdt_ReclutadorItem sdt
		{
			get { 
				return (Sdtsdt_Reclutador_sdt_ReclutadorItem)Sdt;
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
				sdt = new Sdtsdt_Reclutador_sdt_ReclutadorItem() ;
			}
		}
	}
	#endregion
}