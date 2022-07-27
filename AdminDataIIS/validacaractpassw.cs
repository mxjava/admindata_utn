using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class validacaractpassw : GXProcedure
   {
      public validacaractpassw( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public validacaractpassw( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( String aP0_cadenaEntrada ,
                           ref short aP1_error )
      {
         this.AV9cadenaEntrada = aP0_cadenaEntrada;
         this.AV10error = aP1_error;
         initialize();
         executePrivate();
         aP1_error=this.AV10error;
      }

      public short executeUdp( String aP0_cadenaEntrada )
      {
         execute(aP0_cadenaEntrada, ref aP1_error);
         return AV10error ;
      }

      public void executeSubmit( String aP0_cadenaEntrada ,
                                 ref short aP1_error )
      {
         validacaractpassw objvalidacaractpassw;
         objvalidacaractpassw = new validacaractpassw();
         objvalidacaractpassw.AV9cadenaEntrada = aP0_cadenaEntrada;
         objvalidacaractpassw.AV10error = aP1_error;
         objvalidacaractpassw.context.SetSubmitInitialConfig(context);
         objvalidacaractpassw.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objvalidacaractpassw);
         aP1_error=this.AV10error;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((validacaractpassw)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw e ;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8cadenaAux = StringUtil.Trim( AV9cadenaEntrada);
         AV10error = 0;
         AV11errorLongitud = 0;
         AV13exMayuscula = 0;
         AV14exMinuscula = 0;
         AV12exCaracterEspecial = 0;
         AV15exNumero = 0;
         AV18leyendaError = "";
         AV19leyendaFalta = "";
         AV20long = (short)(StringUtil.Len( StringUtil.Trim( AV8cadenaAux)));
         if ( AV20long < 9 )
         {
            GX_msglist.addItem("LONGITUD INVALIDA.... REQUIERO MINIMO 9 CARACTERES");
            AV11errorLongitud = 1;
         }
         AV16i = 1;
         while ( AV16i <= AV20long )
         {
            AV17letra = StringUtil.Substring( AV8cadenaAux, AV16i, 1);
            AV21valorAscii = (short)(StringUtil.Asc( AV17letra));
            if ( ( AV21valorAscii < 33 ) || ( AV21valorAscii > 126 ) )
            {
               if ( ! ( ((StringUtil.StrCmp(AV17letra, "&")==0)||(StringUtil.StrCmp(AV17letra, "¿")==0)||(StringUtil.StrCmp(AV17letra, "¡")==0)) ) )
               {
                  AV10error = 1;
                  AV18leyendaError = StringUtil.Trim( AV18leyendaError) + AV17letra;
               }
               else
               {
                  AV12exCaracterEspecial = 1;
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(AV17letra, "A") >= 0 ) && ( StringUtil.StrCmp(AV17letra, "Z") <= 0 ) || ( StringUtil.StrCmp(AV17letra, "Ñ") == 0 ) )
               {
                  AV13exMayuscula = 1;
               }
               else if ( ( StringUtil.StrCmp(AV17letra, "a") >= 0 ) && ( StringUtil.StrCmp(AV17letra, "z") <= 0 ) || ( StringUtil.StrCmp(AV17letra, "ñ") == 0 ) )
               {
                  AV14exMinuscula = 1;
               }
               else if ( ( StringUtil.StrCmp(AV17letra, "0") >= 0 ) && ( StringUtil.StrCmp(AV17letra, "9") <= 0 ) )
               {
                  AV15exNumero = 1;
               }
               else
               {
                  AV12exCaracterEspecial = 1;
               }
            }
            AV16i = (short)(AV16i+1);
         }
         if ( AV10error == 1 )
         {
            GX_msglist.addItem("CARACTERES NO PERMITIDOS:"+StringUtil.Trim( AV18leyendaError));
         }
         if ( AV11errorLongitud == 1 )
         {
            AV10error = 1;
         }
         if ( AV13exMayuscula == 0 )
         {
            AV19leyendaFalta = StringUtil.Trim( AV19leyendaFalta) + "MAYUSCULA";
         }
         if ( AV14exMinuscula == 0 )
         {
            AV19leyendaFalta = StringUtil.Trim( AV19leyendaFalta) + " minúscula ";
         }
         if ( AV15exNumero == 0 )
         {
            AV19leyendaFalta = StringUtil.Trim( AV19leyendaFalta) + " número ";
         }
         if ( AV12exCaracterEspecial == 0 )
         {
            AV19leyendaFalta = StringUtil.Trim( AV19leyendaFalta) + " CaracterEspecial ";
         }
         if ( AV13exMayuscula + AV14exMinuscula + AV15exNumero + AV12exCaracterEspecial < 4 )
         {
            GX_msglist.addItem("Requiero MAYUSCULAS, minusculas, Numeros y CaracterEspecial(sinEspacios)");
            GX_msglist.addItem("Falta "+StringUtil.Trim( AV19leyendaFalta));
            AV10error = 1;
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections() ;
         }
         exitApplication();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV8cadenaAux = "";
         AV18leyendaError = "";
         AV19leyendaFalta = "";
         AV17letra = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV10error ;
      private short AV11errorLongitud ;
      private short AV13exMayuscula ;
      private short AV14exMinuscula ;
      private short AV12exCaracterEspecial ;
      private short AV15exNumero ;
      private short AV20long ;
      private short AV16i ;
      private short AV21valorAscii ;
      private String AV9cadenaEntrada ;
      private String AV8cadenaAux ;
      private String AV18leyendaError ;
      private String AV19leyendaFalta ;
      private String AV17letra ;
      private short aP1_error ;
   }

   [ServiceContract(Namespace = "GeneXus.Programs.validacaractpassw_services")]
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class validacaractpassw_services : GxRestService
   {
      [OperationContract]
      [WebInvoke(Method =  "POST" ,
      	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/")]
      public void execute( String cadenaEntrada ,
                           ref short error )
      {
         try
         {
            if ( ! ProcessHeaders("validacaractpassw") )
            {
               return  ;
            }
            validacaractpassw worker = new validacaractpassw(context) ;
            worker.IsMain = RunAsMain ;
            worker.execute(cadenaEntrada,ref error );
            worker.cleanup( );
         }
         catch ( Exception e )
         {
            WebException(e);
         }
         finally
         {
            Cleanup();
         }
      }

   }

}
