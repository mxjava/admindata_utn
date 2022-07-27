/*
				   File: type_SdtSdtSecurity
			Description: SdtSecurity
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
	[XmlRoot(ElementName="SdtSecurity")]
	[XmlType(TypeName="SdtSecurity" , Namespace="ADMINDATA1" )]
	[Serializable]
	public class SdtSdtSecurity : GxUserType
	{
		public SdtSdtSecurity( )
		{
			/* Constructor for serialization */
		}

		public SdtSdtSecurity(IGxContext context)
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
			AddObjectProperty("UserIdentifier", gxTpr_Useridentifier, false);


			AddObjectProperty("SecurityRandom", gxTpr_Securityrandom, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="UserIdentifier")]
		[XmlElement(ElementName="UserIdentifier")]
		public int gxTpr_Useridentifier
		{
			get { 
				return gxTv_SdtSdtSecurity_Useridentifier; 
			}
			set { 
				gxTv_SdtSdtSecurity_Useridentifier = value;
				SetDirty("Useridentifier");
			}
		}




		[SoapElement(ElementName="SecurityRandom")]
		[XmlElement(ElementName="SecurityRandom")]
		public int gxTpr_Securityrandom
		{
			get { 
				return gxTv_SdtSdtSecurity_Securityrandom; 
			}
			set { 
				gxTv_SdtSdtSecurity_Securityrandom = value;
				SetDirty("Securityrandom");
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

		protected int gxTv_SdtSdtSecurity_Useridentifier;
		 

		protected int gxTv_SdtSdtSecurity_Securityrandom;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SdtSecurity", Namespace="ADMINDATA1")]
	public class SdtSdtSecurity_RESTInterface : GxGenericCollectionItem<SdtSdtSecurity>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdtSecurity_RESTInterface( ) : base()
		{
		}

		public SdtSdtSecurity_RESTInterface( SdtSdtSecurity psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="UserIdentifier", Order=0)]
		public int gxTpr_Useridentifier
		{
			get { 
				return sdt.gxTpr_Useridentifier;

			}
			set { 
				sdt.gxTpr_Useridentifier = value;
			}
		}

		[DataMember(Name="SecurityRandom", Order=1)]
		public int gxTpr_Securityrandom
		{
			get { 
				return sdt.gxTpr_Securityrandom;

			}
			set { 
				sdt.gxTpr_Securityrandom = value;
			}
		}


		#endregion

		public SdtSdtSecurity sdt
		{
			get { 
				return (SdtSdtSecurity)Sdt;
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
				sdt = new SdtSdtSecurity() ;
			}
		}
	}
	#endregion
}