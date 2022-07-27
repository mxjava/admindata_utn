using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class sdsvc_workwithdevicesusuarios_usuarios_list : GXProcedure
   {
      public sdsvc_workwithdevicesusuarios_usuarios_list( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public sdsvc_workwithdevicesusuarios_usuarios_list( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         this.cleanup();
      }

      protected void S111( )
      {
         /* AfterFilterRolId Routine */
         /* Using cursor SDSVC_WORK2 */
         pr_default.execute(0, new Object[] {AV1Pmpt_rolid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A24RolId = SDSVC_WORK2_A24RolId[0];
            A127RolNombre = SDSVC_WORK2_A127RolNombre[0];
            AV2Pmpt_rolnombre = A127RolNombre;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      public GxUnknownObjectCollection AfterFilterRolId( int A24RolId )
      {
         initialize();
         AV1Pmpt_rolid = A24RolId;
         /* Execute user subroutine: AfterFilterRolId */
         S111 ();
         GxUnknownObjectCollection gxjsonarray = new GxUnknownObjectCollection() ;
         gxjsonarray.Add(AV2Pmpt_rolnombre);
         /* End function AfterFilterRolId */
         return gxjsonarray ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         scmdbuf = "";
         SDSVC_WORK2_A24RolId = new int[1] ;
         SDSVC_WORK2_A127RolNombre = new String[] {""} ;
         A127RolNombre = "";
         AV2Pmpt_rolnombre = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sdsvc_workwithdevicesusuarios_usuarios_list__default(),
            new Object[][] {
                new Object[] {
               SDSVC_WORK2_A24RolId, SDSVC_WORK2_A127RolNombre
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected int AV1Pmpt_rolid ;
      protected int A24RolId ;
      protected String scmdbuf ;
      protected String A127RolNombre ;
      protected String AV2Pmpt_rolnombre ;
      protected IGxDataStore dsDefault ;
      protected IDataStoreProvider pr_default ;
      protected int[] SDSVC_WORK2_A24RolId ;
      protected String[] SDSVC_WORK2_A127RolNombre ;
   }

   public class sdsvc_workwithdevicesusuarios_usuarios_list__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmSDSVC_WORK2 ;
          prmSDSVC_WORK2 = new Object[] {
          new Object[] {"AV1Pmpt_rolid",System.Data.DbType.Int32,9,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("SDSVC_WORK2", "SELECT `RolId`, `RolNombre` FROM `Roles` WHERE `RolId` = ? ORDER BY `RolId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmSDSVC_WORK2,1, GxCacheFrequency.OFF ,false,true )
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

 [ServiceContract(Namespace = "GeneXus.Programs.sdsvc_workwithdevicesusuarios_usuarios_list_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class sdsvc_workwithdevicesusuarios_usuarios_list_services : GxRestService
 {
    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Bare  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/AfterFilterRolId?RolId={RolId}")]
    public GxUnknownObjectCollection AfterFilterRolId( String RolId )
    {
       try
       {
          if ( ! ProcessHeaders("sdsvc_workwithdevicesusuarios_usuarios_list") )
          {
             return null ;
          }
          sdsvc_workwithdevicesusuarios_usuarios_list worker = new sdsvc_workwithdevicesusuarios_usuarios_list(context) ;
          int gxrRolId = 0 ;
          gxrRolId = (int)(NumberUtil.Val( (String)(RolId), "."));
          return  worker.AfterFilterRolId(gxrRolId );
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

 }

}
