/*
				   File: type_SdtContext
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
	[XmlRoot(ElementName="Context")]
	[XmlType(TypeName="Context" , Namespace="ADMINDATA1" )]
	[Serializable]
	public class SdtContext : GxUserType
	{
		public SdtContext( )
		{
			/* Constructor for serialization */
			gxTv_SdtContext_User = "";

			gxTv_SdtContext_Profile = "";

		}

		public SdtContext(IGxContext context)
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
			AddObjectProperty("User", gxTpr_User, false);


			AddObjectProperty("CompanyCode", gxTpr_Companycode, false);


			AddObjectProperty("Profile", gxTpr_Profile, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="User")]
		[XmlElement(ElementName="User")]
		public String gxTpr_User
		{
			get { 
				return gxTv_SdtContext_User; 
			}
			set { 
				gxTv_SdtContext_User = value;
				SetDirty("User");
			}
		}




		[SoapElement(ElementName="CompanyCode")]
		[XmlElement(ElementName="CompanyCode")]
		public short gxTpr_Companycode
		{
			get { 
				return gxTv_SdtContext_Companycode; 
			}
			set { 
				gxTv_SdtContext_Companycode = value;
				SetDirty("Companycode");
			}
		}




		[SoapElement(ElementName="Profile")]
		[XmlElement(ElementName="Profile")]
		public String gxTpr_Profile
		{
			get { 
				return gxTv_SdtContext_Profile; 
			}
			set { 
				gxTv_SdtContext_Profile = value;
				SetDirty("Profile");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtContext_User = "";

			gxTv_SdtContext_Profile = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected String gxTv_SdtContext_User;
		 

		protected short gxTv_SdtContext_Companycode;
		 

		protected String gxTv_SdtContext_Profile;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"Context", Namespace="ADMINDATA1")]
	public class SdtContext_RESTInterface : GxGenericCollectionItem<SdtContext>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtContext_RESTInterface( ) : base()
		{
		}

		public SdtContext_RESTInterface( SdtContext psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="User", Order=0)]
		public  String gxTpr_User
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_User);

			}
			set { 
				 sdt.gxTpr_User = value;
			}
		}

		[DataMember(Name="CompanyCode", Order=1)]
		public short gxTpr_Companycode
		{
			get { 
				return sdt.gxTpr_Companycode;

			}
			set { 
				sdt.gxTpr_Companycode = value;
			}
		}

		[DataMember(Name="Profile", Order=2)]
		public  String gxTpr_Profile
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Profile);

			}
			set { 
				 sdt.gxTpr_Profile = value;
			}
		}


		#endregion

		public SdtContext sdt
		{
			get { 
				return (SdtContext)Sdt;
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
				sdt = new SdtContext() ;
			}
		}
	}
	#endregion
}