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
   public class grababitacceso : GXProcedure
   {
      public grababitacceso( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public grababitacceso( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_UsuariosId )
      {
         this.AV8UsuariosId = aP0_UsuariosId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_UsuariosId )
      {
         grababitacceso objgrababitacceso;
         objgrababitacceso = new grababitacceso();
         objgrababitacceso.AV8UsuariosId = aP0_UsuariosId;
         objgrababitacceso.context.SetSubmitInitialConfig(context);
         objgrababitacceso.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgrababitacceso);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((grababitacceso)stateInfo).executePrivate();
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
         /*
            INSERT RECORD ON TABLE bitAcces

         */
         A61bitAccesFec = DateTimeUtil.ServerNow( context, pr_default);
         A75bitAccesIp = context.GetRemoteAddress( );
         A11UsuariosId = AV8UsuariosId;
         n11UsuariosId = false;
         /* Using cursor P000X2 */
         pr_default.execute(0, new Object[] {A61bitAccesFec, A75bitAccesIp, n11UsuariosId, A11UsuariosId});
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("bitAcces") ;
         if ( (pr_default.getStatus(0) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (String)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("grababitacceso",pr_default);
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
         A61bitAccesFec = (DateTime)(DateTime.MinValue);
         A75bitAccesIp = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.grababitacceso__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8UsuariosId ;
      private int GX_INS11 ;
      private int A11UsuariosId ;
      private String Gx_emsg ;
      private DateTime A61bitAccesFec ;
      private bool n11UsuariosId ;
      private String A75bitAccesIp ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class grababitacceso__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000X2 ;
          prmP000X2 = new Object[] {
          new Object[] {"bitAccesFec",System.Data.DbType.DateTime,8,8} ,
          new Object[] {"bitAccesIp",System.Data.DbType.String,15,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P000X2", "INSERT INTO `bitAcces`(`bitAccesFec`, `bitAccesIp`, `UsuariosId`) VALUES(?, ?, ?)", GxErrorMask.GX_NOMASK,prmP000X2)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
             case 0 :
                stmt.SetParameterDatetime(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                if ( (bool)parms[2] )
                {
                   stmt.setNull( 3 , SqlDbType.Int );
                }
                else
                {
                   stmt.SetParameter(3, (int)parms[3]);
                }
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.grababitacceso_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class grababitacceso_services : GxRestService
 {
    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( int UsuariosId )
    {
       try
       {
          if ( ! ProcessHeaders("grababitacceso") )
          {
             return  ;
          }
          grababitacceso worker = new grababitacceso(context) ;
          worker.IsMain = RunAsMain ;
          worker.execute(UsuariosId );
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
