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
   public class cambiapwd : GXProcedure
   {
      public cambiapwd( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public cambiapwd( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_UsuariosId ,
                           String aP1_pwdNueva ,
                           short aP2_HistPwdInd )
      {
         this.AV8UsuariosId = aP0_UsuariosId;
         this.AV9pwdNueva = aP1_pwdNueva;
         this.AV14HistPwdInd = aP2_HistPwdInd;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_UsuariosId ,
                                 String aP1_pwdNueva ,
                                 short aP2_HistPwdInd )
      {
         cambiapwd objcambiapwd;
         objcambiapwd = new cambiapwd();
         objcambiapwd.AV8UsuariosId = aP0_UsuariosId;
         objcambiapwd.AV9pwdNueva = aP1_pwdNueva;
         objcambiapwd.AV14HistPwdInd = aP2_HistPwdInd;
         objcambiapwd.context.SetSubmitInitialConfig(context);
         objcambiapwd.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcambiapwd);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((cambiapwd)stateInfo).executePrivate();
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
         AV10Llave = Crypto.GetEncryptionKey( );
         /* Using cursor P00172 */
         pr_default.execute(0, new Object[] {AV8UsuariosId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11UsuariosId = P00172_A11UsuariosId[0];
            A68UsuariosPwd = P00172_A68UsuariosPwd[0];
            A67UsuariosKey = P00172_A67UsuariosKey[0];
            A68UsuariosPwd = Encrypt64( AV9pwdNueva, AV10Llave);
            A67UsuariosKey = AV10Llave;
            AV11UsuariosPwd = A68UsuariosPwd;
            /* Using cursor P00173 */
            pr_default.execute(1, new Object[] {A68UsuariosPwd, A67UsuariosKey, A11UsuariosId});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("Usuarios") ;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         new guardahispwd(context ).execute(  AV8UsuariosId,  AV11UsuariosPwd,  AV10Llave,  AV14HistPwdInd) ;
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("cambiapwd",pr_default);
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
         AV10Llave = "";
         scmdbuf = "";
         P00172_A11UsuariosId = new int[1] ;
         P00172_A68UsuariosPwd = new String[] {""} ;
         P00172_A67UsuariosKey = new String[] {""} ;
         A68UsuariosPwd = "";
         A67UsuariosKey = "";
         AV11UsuariosPwd = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cambiapwd__default(),
            new Object[][] {
                new Object[] {
               P00172_A11UsuariosId, P00172_A68UsuariosPwd, P00172_A67UsuariosKey
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV14HistPwdInd ;
      private int AV8UsuariosId ;
      private int A11UsuariosId ;
      private String scmdbuf ;
      private String AV9pwdNueva ;
      private String AV10Llave ;
      private String A68UsuariosPwd ;
      private String A67UsuariosKey ;
      private String AV11UsuariosPwd ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00172_A11UsuariosId ;
      private String[] P00172_A68UsuariosPwd ;
      private String[] P00172_A67UsuariosKey ;
   }

   public class cambiapwd__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00172 ;
          prmP00172 = new Object[] {
          new Object[] {"AV8UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmP00173 ;
          prmP00173 = new Object[] {
          new Object[] {"UsuariosPwd",System.Data.DbType.String,32,0} ,
          new Object[] {"UsuariosKey",System.Data.DbType.String,32,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P00172", "SELECT `UsuariosId`, `UsuariosPwd`, `UsuariosKey` FROM `Usuarios` WHERE `UsuariosId` = ? ORDER BY `UsuariosId`  FOR UPDATE ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00172,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00173", "UPDATE `Usuarios` SET `UsuariosPwd`=?, `UsuariosKey`=?  WHERE `UsuariosId` = ?", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00173)
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
             case 1 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.cambiapwd_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class cambiapwd_services : GxRestService
 {
    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( int UsuariosId ,
                         String pwdNueva ,
                         short HistPwdInd )
    {
       try
       {
          if ( ! ProcessHeaders("cambiapwd") )
          {
             return  ;
          }
          cambiapwd worker = new cambiapwd(context) ;
          worker.IsMain = RunAsMain ;
          worker.execute(UsuariosId,pwdNueva,HistPwdInd );
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
