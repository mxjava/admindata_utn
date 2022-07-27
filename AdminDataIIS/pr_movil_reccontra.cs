using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
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
   public class pr_movil_reccontra : GXProcedure
   {
      public pr_movil_reccontra( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public pr_movil_reccontra( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_UsrLog ,
                           String aP1_PwdNuevo ,
                           out short aP2_Existe )
      {
         this.AV22UsrLog = aP0_UsrLog;
         this.AV19PwdNuevo = aP1_PwdNuevo;
         this.AV13Existe = 0 ;
         initialize();
         executePrivate();
         aP2_Existe=this.AV13Existe;
      }

      public short executeUdp( int aP0_UsrLog ,
                               String aP1_PwdNuevo )
      {
         execute(aP0_UsrLog, aP1_PwdNuevo, out aP2_Existe);
         return AV13Existe ;
      }

      public void executeSubmit( int aP0_UsrLog ,
                                 String aP1_PwdNuevo ,
                                 out short aP2_Existe )
      {
         pr_movil_reccontra objpr_movil_reccontra;
         objpr_movil_reccontra = new pr_movil_reccontra();
         objpr_movil_reccontra.AV22UsrLog = aP0_UsrLog;
         objpr_movil_reccontra.AV19PwdNuevo = aP1_PwdNuevo;
         objpr_movil_reccontra.AV13Existe = 0 ;
         objpr_movil_reccontra.context.SetSubmitInitialConfig(context);
         objpr_movil_reccontra.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpr_movil_reccontra);
         aP2_Existe=this.AV13Existe;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pr_movil_reccontra)stateInfo).executePrivate();
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
         AV13Existe = 0;
         /* Using cursor P00222 */
         pr_default.execute(0, new Object[] {AV22UsrLog});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11UsuariosId = P00222_A11UsuariosId[0];
            A111HistPwdLlave = P00222_A111HistPwdLlave[0];
            A110HistPwdConstra = P00222_A110HistPwdConstra[0];
            A62HisPwdFecha = P00222_A62HisPwdFecha[0];
            AV16pwd = Decrypt64( StringUtil.Trim( A110HistPwdConstra), StringUtil.Trim( A111HistPwdLlave));
            if ( StringUtil.StrCmp(AV16pwd, AV19PwdNuevo) == 0 )
            {
               AV13Existe = 1;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         scmdbuf = "";
         P00222_A11UsuariosId = new int[1] ;
         P00222_A111HistPwdLlave = new String[] {""} ;
         P00222_A110HistPwdConstra = new String[] {""} ;
         P00222_A62HisPwdFecha = new DateTime[] {DateTime.MinValue} ;
         A111HistPwdLlave = "";
         A110HistPwdConstra = "";
         A62HisPwdFecha = (DateTime)(DateTime.MinValue);
         AV16pwd = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pr_movil_reccontra__default(),
            new Object[][] {
                new Object[] {
               P00222_A11UsuariosId, P00222_A111HistPwdLlave, P00222_A110HistPwdConstra, P00222_A62HisPwdFecha
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV13Existe ;
      private int AV22UsrLog ;
      private int A11UsuariosId ;
      private String scmdbuf ;
      private DateTime A62HisPwdFecha ;
      private String AV19PwdNuevo ;
      private String A111HistPwdLlave ;
      private String A110HistPwdConstra ;
      private String AV16pwd ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00222_A11UsuariosId ;
      private String[] P00222_A111HistPwdLlave ;
      private String[] P00222_A110HistPwdConstra ;
      private DateTime[] P00222_A62HisPwdFecha ;
      private short aP2_Existe ;
   }

   public class pr_movil_reccontra__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00222 ;
          prmP00222 = new Object[] {
          new Object[] {"AV22UsrLog",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P00222", "SELECT `UsuariosId`, `HistPwdLlave`, `HistPwdConstra`, `HisPwdFecha` FROM `HistPwd` WHERE `UsuariosId` = ? ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00222,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4) ;
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
             case 0 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.pr_movil_reccontra_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class pr_movil_reccontra_services : GxRestService
 {
    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( int UsrLog ,
                         String PwdNuevo ,
                         out short Existe )
    {
       Existe = 0 ;
       try
       {
          if ( ! ProcessHeaders("pr_movil_reccontra") )
          {
             return  ;
          }
          pr_movil_reccontra worker = new pr_movil_reccontra(context) ;
          worker.IsMain = RunAsMain ;
          worker.execute(UsrLog,PwdNuevo,out Existe );
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
