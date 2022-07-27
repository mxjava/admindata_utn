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
   public class desencrippwd : GXProcedure
   {
      public desencrippwd( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public desencrippwd( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_UsuariosId ,
                           out String aP1_PwdTexto )
      {
         this.AV8UsuariosId = aP0_UsuariosId;
         this.AV9PwdTexto = "" ;
         initialize();
         executePrivate();
         aP1_PwdTexto=this.AV9PwdTexto;
      }

      public String executeUdp( int aP0_UsuariosId )
      {
         execute(aP0_UsuariosId, out aP1_PwdTexto);
         return AV9PwdTexto ;
      }

      public void executeSubmit( int aP0_UsuariosId ,
                                 out String aP1_PwdTexto )
      {
         desencrippwd objdesencrippwd;
         objdesencrippwd = new desencrippwd();
         objdesencrippwd.AV8UsuariosId = aP0_UsuariosId;
         objdesencrippwd.AV9PwdTexto = "" ;
         objdesencrippwd.context.SetSubmitInitialConfig(context);
         objdesencrippwd.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objdesencrippwd);
         aP1_PwdTexto=this.AV9PwdTexto;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((desencrippwd)stateInfo).executePrivate();
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
         /* Using cursor P00182 */
         pr_default.execute(0, new Object[] {AV8UsuariosId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11UsuariosId = P00182_A11UsuariosId[0];
            A67UsuariosKey = P00182_A67UsuariosKey[0];
            A68UsuariosPwd = P00182_A68UsuariosPwd[0];
            AV9PwdTexto = Decrypt64( StringUtil.Trim( A68UsuariosPwd), StringUtil.Trim( A67UsuariosKey));
            /* Exiting from a For First loop. */
            if (true) break;
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
         P00182_A11UsuariosId = new int[1] ;
         P00182_A67UsuariosKey = new String[] {""} ;
         P00182_A68UsuariosPwd = new String[] {""} ;
         A67UsuariosKey = "";
         A68UsuariosPwd = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.desencrippwd__default(),
            new Object[][] {
                new Object[] {
               P00182_A11UsuariosId, P00182_A67UsuariosKey, P00182_A68UsuariosPwd
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8UsuariosId ;
      private int A11UsuariosId ;
      private String scmdbuf ;
      private String AV9PwdTexto ;
      private String A67UsuariosKey ;
      private String A68UsuariosPwd ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00182_A11UsuariosId ;
      private String[] P00182_A67UsuariosKey ;
      private String[] P00182_A68UsuariosPwd ;
      private String aP1_PwdTexto ;
   }

   public class desencrippwd__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00182 ;
          prmP00182 = new Object[] {
          new Object[] {"AV8UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P00182", "SELECT `UsuariosId`, `UsuariosKey`, `UsuariosPwd` FROM `Usuarios` WHERE `UsuariosId` = ? ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00182,1, GxCacheFrequency.OFF ,false,true )
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
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.desencrippwd_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class desencrippwd_services : GxRestService
 {
    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( int UsuariosId ,
                         out String PwdTexto )
    {
       PwdTexto = "" ;
       try
       {
          if ( ! ProcessHeaders("desencrippwd") )
          {
             return  ;
          }
          desencrippwd worker = new desencrippwd(context) ;
          worker.IsMain = RunAsMain ;
          worker.execute(UsuariosId,out PwdTexto );
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
