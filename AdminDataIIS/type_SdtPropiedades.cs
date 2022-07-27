/*
				   File: type_SdtPropiedades
			Description: Propiedades
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
	[XmlRoot(ElementName="Propiedades")]
	[XmlType(TypeName="Propiedades" , Namespace="ADMINDATA1" )]
	[Serializable]
	public class SdtPropiedades : GxUserType
	{
		public SdtPropiedades( )
		{
			/* Constructor for serialization */
			gxTv_SdtPropiedades_Title = "";

			gxTv_SdtPropiedades_Titletext = "";

			gxTv_SdtPropiedades_Html = "";

			gxTv_SdtPropiedades_Text = "";

			gxTv_SdtPropiedades_Icon = "";

			gxTv_SdtPropiedades_Confirmbuttoncolor = "";

			gxTv_SdtPropiedades_Cancelbuttoncolor = "";

			gxTv_SdtPropiedades_Confirmbuttontext = "";

			gxTv_SdtPropiedades_Confirmbuttonurl = "";

			gxTv_SdtPropiedades_Cancelbuttontext = "";

			gxTv_SdtPropiedades_Footer = "";

		}

		public SdtPropiedades(IGxContext context)
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
			AddObjectProperty("title", gxTpr_Title, false);


			AddObjectProperty("titleText", gxTpr_Titletext, false);


			AddObjectProperty("html", gxTpr_Html, false);


			AddObjectProperty("text", gxTpr_Text, false);


			AddObjectProperty("icon", gxTpr_Icon, false);


			AddObjectProperty("showCancelButton", gxTpr_Showcancelbutton, false);


			AddObjectProperty("showConfirmButton", gxTpr_Showconfirmbutton, false);


			AddObjectProperty("confirmButtonColor", gxTpr_Confirmbuttoncolor, false);


			AddObjectProperty("focusConfirm", gxTpr_Focusconfirm, false);


			AddObjectProperty("cancelButtonColor", gxTpr_Cancelbuttoncolor, false);


			AddObjectProperty("confirmButtonText", gxTpr_Confirmbuttontext, false);


			AddObjectProperty("confirmButtonUrl", gxTpr_Confirmbuttonurl, false);


			AddObjectProperty("cancelButtonText", gxTpr_Cancelbuttontext, false);


			AddObjectProperty("showCloseButton", gxTpr_Showclosebutton, false);


			AddObjectProperty("allowOutsideClick", gxTpr_Allowoutsideclick, false);


			AddObjectProperty("footer", gxTpr_Footer, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="title")]
		[XmlElement(ElementName="title")]
		public String gxTpr_Title
		{
			get { 
				return gxTv_SdtPropiedades_Title; 
			}
			set { 
				gxTv_SdtPropiedades_Title = value;
				SetDirty("Title");
			}
		}




		[SoapElement(ElementName="titleText")]
		[XmlElement(ElementName="titleText")]
		public String gxTpr_Titletext
		{
			get { 
				return gxTv_SdtPropiedades_Titletext; 
			}
			set { 
				gxTv_SdtPropiedades_Titletext = value;
				SetDirty("Titletext");
			}
		}




		[SoapElement(ElementName="html")]
		[XmlElement(ElementName="html")]
		public String gxTpr_Html
		{
			get { 
				return gxTv_SdtPropiedades_Html; 
			}
			set { 
				gxTv_SdtPropiedades_Html = value;
				SetDirty("Html");
			}
		}




		[SoapElement(ElementName="text")]
		[XmlElement(ElementName="text")]
		public String gxTpr_Text
		{
			get { 
				return gxTv_SdtPropiedades_Text; 
			}
			set { 
				gxTv_SdtPropiedades_Text = value;
				SetDirty("Text");
			}
		}




		[SoapElement(ElementName="icon")]
		[XmlElement(ElementName="icon")]
		public String gxTpr_Icon
		{
			get { 
				return gxTv_SdtPropiedades_Icon; 
			}
			set { 
				gxTv_SdtPropiedades_Icon = value;
				SetDirty("Icon");
			}
		}




		[SoapElement(ElementName="showCancelButton")]
		[XmlElement(ElementName="showCancelButton")]
		public bool gxTpr_Showcancelbutton
		{
			get { 
				return gxTv_SdtPropiedades_Showcancelbutton; 
			}
			set { 
				gxTv_SdtPropiedades_Showcancelbutton = value;
				SetDirty("Showcancelbutton");
			}
		}




		[SoapElement(ElementName="showConfirmButton")]
		[XmlElement(ElementName="showConfirmButton")]
		public bool gxTpr_Showconfirmbutton
		{
			get { 
				return gxTv_SdtPropiedades_Showconfirmbutton; 
			}
			set { 
				gxTv_SdtPropiedades_Showconfirmbutton = value;
				SetDirty("Showconfirmbutton");
			}
		}




		[SoapElement(ElementName="confirmButtonColor")]
		[XmlElement(ElementName="confirmButtonColor")]
		public String gxTpr_Confirmbuttoncolor
		{
			get { 
				return gxTv_SdtPropiedades_Confirmbuttoncolor; 
			}
			set { 
				gxTv_SdtPropiedades_Confirmbuttoncolor = value;
				SetDirty("Confirmbuttoncolor");
			}
		}




		[SoapElement(ElementName="focusConfirm")]
		[XmlElement(ElementName="focusConfirm")]
		public bool gxTpr_Focusconfirm
		{
			get { 
				return gxTv_SdtPropiedades_Focusconfirm; 
			}
			set { 
				gxTv_SdtPropiedades_Focusconfirm = value;
				SetDirty("Focusconfirm");
			}
		}




		[SoapElement(ElementName="cancelButtonColor")]
		[XmlElement(ElementName="cancelButtonColor")]
		public String gxTpr_Cancelbuttoncolor
		{
			get { 
				return gxTv_SdtPropiedades_Cancelbuttoncolor; 
			}
			set { 
				gxTv_SdtPropiedades_Cancelbuttoncolor = value;
				SetDirty("Cancelbuttoncolor");
			}
		}




		[SoapElement(ElementName="confirmButtonText")]
		[XmlElement(ElementName="confirmButtonText")]
		public String gxTpr_Confirmbuttontext
		{
			get { 
				return gxTv_SdtPropiedades_Confirmbuttontext; 
			}
			set { 
				gxTv_SdtPropiedades_Confirmbuttontext = value;
				SetDirty("Confirmbuttontext");
			}
		}




		[SoapElement(ElementName="confirmButtonUrl")]
		[XmlElement(ElementName="confirmButtonUrl")]
		public String gxTpr_Confirmbuttonurl
		{
			get { 
				return gxTv_SdtPropiedades_Confirmbuttonurl; 
			}
			set { 
				gxTv_SdtPropiedades_Confirmbuttonurl = value;
				SetDirty("Confirmbuttonurl");
			}
		}




		[SoapElement(ElementName="cancelButtonText")]
		[XmlElement(ElementName="cancelButtonText")]
		public String gxTpr_Cancelbuttontext
		{
			get { 
				return gxTv_SdtPropiedades_Cancelbuttontext; 
			}
			set { 
				gxTv_SdtPropiedades_Cancelbuttontext = value;
				SetDirty("Cancelbuttontext");
			}
		}




		[SoapElement(ElementName="showCloseButton")]
		[XmlElement(ElementName="showCloseButton")]
		public bool gxTpr_Showclosebutton
		{
			get { 
				return gxTv_SdtPropiedades_Showclosebutton; 
			}
			set { 
				gxTv_SdtPropiedades_Showclosebutton = value;
				SetDirty("Showclosebutton");
			}
		}




		[SoapElement(ElementName="allowOutsideClick")]
		[XmlElement(ElementName="allowOutsideClick")]
		public bool gxTpr_Allowoutsideclick
		{
			get { 
				return gxTv_SdtPropiedades_Allowoutsideclick; 
			}
			set { 
				gxTv_SdtPropiedades_Allowoutsideclick = value;
				SetDirty("Allowoutsideclick");
			}
		}




		[SoapElement(ElementName="footer")]
		[XmlElement(ElementName="footer")]
		public String gxTpr_Footer
		{
			get { 
				return gxTv_SdtPropiedades_Footer; 
			}
			set { 
				gxTv_SdtPropiedades_Footer = value;
				SetDirty("Footer");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtPropiedades_Title = "";
			gxTv_SdtPropiedades_Titletext = "";
			gxTv_SdtPropiedades_Html = "";
			gxTv_SdtPropiedades_Text = "";
			gxTv_SdtPropiedades_Icon = "";


			gxTv_SdtPropiedades_Confirmbuttoncolor = "";

			gxTv_SdtPropiedades_Cancelbuttoncolor = "";
			gxTv_SdtPropiedades_Confirmbuttontext = "";
			gxTv_SdtPropiedades_Confirmbuttonurl = "";
			gxTv_SdtPropiedades_Cancelbuttontext = "";


			gxTv_SdtPropiedades_Footer = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected String gxTv_SdtPropiedades_Title;
		 

		protected String gxTv_SdtPropiedades_Titletext;
		 

		protected String gxTv_SdtPropiedades_Html;
		 

		protected String gxTv_SdtPropiedades_Text;
		 

		protected String gxTv_SdtPropiedades_Icon;
		 

		protected bool gxTv_SdtPropiedades_Showcancelbutton;
		 

		protected bool gxTv_SdtPropiedades_Showconfirmbutton;
		 

		protected String gxTv_SdtPropiedades_Confirmbuttoncolor;
		 

		protected bool gxTv_SdtPropiedades_Focusconfirm;
		 

		protected String gxTv_SdtPropiedades_Cancelbuttoncolor;
		 

		protected String gxTv_SdtPropiedades_Confirmbuttontext;
		 

		protected String gxTv_SdtPropiedades_Confirmbuttonurl;
		 

		protected String gxTv_SdtPropiedades_Cancelbuttontext;
		 

		protected bool gxTv_SdtPropiedades_Showclosebutton;
		 

		protected bool gxTv_SdtPropiedades_Allowoutsideclick;
		 

		protected String gxTv_SdtPropiedades_Footer;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"Propiedades", Namespace="ADMINDATA1")]
	public class SdtPropiedades_RESTInterface : GxGenericCollectionItem<SdtPropiedades>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtPropiedades_RESTInterface( ) : base()
		{
		}

		public SdtPropiedades_RESTInterface( SdtPropiedades psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="title", Order=0)]
		public  String gxTpr_Title
		{
			get { 
				return sdt.gxTpr_Title;

			}
			set { 
				 sdt.gxTpr_Title = value;
			}
		}

		[DataMember(Name="titleText", Order=1)]
		public  String gxTpr_Titletext
		{
			get { 
				return sdt.gxTpr_Titletext;

			}
			set { 
				 sdt.gxTpr_Titletext = value;
			}
		}

		[DataMember(Name="html", Order=2)]
		public  String gxTpr_Html
		{
			get { 
				return sdt.gxTpr_Html;

			}
			set { 
				 sdt.gxTpr_Html = value;
			}
		}

		[DataMember(Name="text", Order=3)]
		public  String gxTpr_Text
		{
			get { 
				return sdt.gxTpr_Text;

			}
			set { 
				 sdt.gxTpr_Text = value;
			}
		}

		[DataMember(Name="icon", Order=4)]
		public  String gxTpr_Icon
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Icon);

			}
			set { 
				 sdt.gxTpr_Icon = value;
			}
		}

		[DataMember(Name="showCancelButton", Order=5)]
		public bool gxTpr_Showcancelbutton
		{
			get { 
				return sdt.gxTpr_Showcancelbutton;

			}
			set { 
				sdt.gxTpr_Showcancelbutton = value;
			}
		}

		[DataMember(Name="showConfirmButton", Order=6)]
		public bool gxTpr_Showconfirmbutton
		{
			get { 
				return sdt.gxTpr_Showconfirmbutton;

			}
			set { 
				sdt.gxTpr_Showconfirmbutton = value;
			}
		}

		[DataMember(Name="confirmButtonColor", Order=7)]
		public  String gxTpr_Confirmbuttoncolor
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Confirmbuttoncolor);

			}
			set { 
				 sdt.gxTpr_Confirmbuttoncolor = value;
			}
		}

		[DataMember(Name="focusConfirm", Order=8)]
		public bool gxTpr_Focusconfirm
		{
			get { 
				return sdt.gxTpr_Focusconfirm;

			}
			set { 
				sdt.gxTpr_Focusconfirm = value;
			}
		}

		[DataMember(Name="cancelButtonColor", Order=9)]
		public  String gxTpr_Cancelbuttoncolor
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Cancelbuttoncolor);

			}
			set { 
				 sdt.gxTpr_Cancelbuttoncolor = value;
			}
		}

		[DataMember(Name="confirmButtonText", Order=10)]
		public  String gxTpr_Confirmbuttontext
		{
			get { 
				return sdt.gxTpr_Confirmbuttontext;

			}
			set { 
				 sdt.gxTpr_Confirmbuttontext = value;
			}
		}

		[DataMember(Name="confirmButtonUrl", Order=11)]
		public  String gxTpr_Confirmbuttonurl
		{
			get { 
				return sdt.gxTpr_Confirmbuttonurl;

			}
			set { 
				 sdt.gxTpr_Confirmbuttonurl = value;
			}
		}

		[DataMember(Name="cancelButtonText", Order=12)]
		public  String gxTpr_Cancelbuttontext
		{
			get { 
				return sdt.gxTpr_Cancelbuttontext;

			}
			set { 
				 sdt.gxTpr_Cancelbuttontext = value;
			}
		}

		[DataMember(Name="showCloseButton", Order=13)]
		public bool gxTpr_Showclosebutton
		{
			get { 
				return sdt.gxTpr_Showclosebutton;

			}
			set { 
				sdt.gxTpr_Showclosebutton = value;
			}
		}

		[DataMember(Name="allowOutsideClick", Order=14)]
		public bool gxTpr_Allowoutsideclick
		{
			get { 
				return sdt.gxTpr_Allowoutsideclick;

			}
			set { 
				sdt.gxTpr_Allowoutsideclick = value;
			}
		}

		[DataMember(Name="footer", Order=15)]
		public  String gxTpr_Footer
		{
			get { 
				return sdt.gxTpr_Footer;

			}
			set { 
				 sdt.gxTpr_Footer = value;
			}
		}


		#endregion

		public SdtPropiedades sdt
		{
			get { 
				return (SdtPropiedades)Sdt;
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
				sdt = new SdtPropiedades() ;
			}
		}
	}
	#endregion
}