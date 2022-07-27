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
   public class workwithdevicesusuarios_usuarios_section_usuariosvacante1_grid1 : GXProcedure
   {
      public workwithdevicesusuarios_usuarios_section_usuariosvacante1_grid1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public workwithdevicesusuarios_usuarios_section_usuariosvacante1_grid1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_SUBT_ReclutadorId ,
                           long aP1_start ,
                           long aP2_count ,
                           int aP3_gxid ,
                           out GXBaseCollection<SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item> aP4_GXM2RootCol )
      {
         this.A284SUBT_ReclutadorId = aP0_SUBT_ReclutadorId;
         this.AV7start = aP1_start;
         this.AV8count = aP2_count;
         this.AV6gxid = aP3_gxid;
         this.AV9GXM2RootCol = new GXBaseCollection<SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item>( context, "WorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt.Item", "") ;
         initialize();
         executePrivate();
         aP4_GXM2RootCol=this.AV9GXM2RootCol;
      }

      public GXBaseCollection<SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item> executeUdp( int aP0_SUBT_ReclutadorId ,
                                                                                                                      long aP1_start ,
                                                                                                                      long aP2_count ,
                                                                                                                      int aP3_gxid )
      {
         execute(aP0_SUBT_ReclutadorId, aP1_start, aP2_count, aP3_gxid, out aP4_GXM2RootCol);
         return AV9GXM2RootCol ;
      }

      public void executeSubmit( int aP0_SUBT_ReclutadorId ,
                                 long aP1_start ,
                                 long aP2_count ,
                                 int aP3_gxid ,
                                 out GXBaseCollection<SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item> aP4_GXM2RootCol )
      {
         workwithdevicesusuarios_usuarios_section_usuariosvacante1_grid1 objworkwithdevicesusuarios_usuarios_section_usuariosvacante1_grid1;
         objworkwithdevicesusuarios_usuarios_section_usuariosvacante1_grid1 = new workwithdevicesusuarios_usuarios_section_usuariosvacante1_grid1();
         objworkwithdevicesusuarios_usuarios_section_usuariosvacante1_grid1.A284SUBT_ReclutadorId = aP0_SUBT_ReclutadorId;
         objworkwithdevicesusuarios_usuarios_section_usuariosvacante1_grid1.AV7start = aP1_start;
         objworkwithdevicesusuarios_usuarios_section_usuariosvacante1_grid1.AV8count = aP2_count;
         objworkwithdevicesusuarios_usuarios_section_usuariosvacante1_grid1.AV6gxid = aP3_gxid;
         objworkwithdevicesusuarios_usuarios_section_usuariosvacante1_grid1.AV9GXM2RootCol = new GXBaseCollection<SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item>( context, "WorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt.Item", "") ;
         objworkwithdevicesusuarios_usuarios_section_usuariosvacante1_grid1.context.SetSubmitInitialConfig(context);
         objworkwithdevicesusuarios_usuarios_section_usuariosvacante1_grid1.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objworkwithdevicesusuarios_usuarios_section_usuariosvacante1_grid1);
         aP4_GXM2RootCol=this.AV9GXM2RootCol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((workwithdevicesusuarios_usuarios_section_usuariosvacante1_grid1)stateInfo).executePrivate();
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
         GXPagingFrom2 = (int)(AV7start);
         GXPagingTo2 = (int)(((AV8count>0) ? AV8count : 100000000));
         /* Using cursor P00002 */
         pr_default.execute(0, new Object[] {A284SUBT_ReclutadorId, GXPagingFrom2, GXPagingTo2});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A263Vacantes_Id = P00002_A263Vacantes_Id[0];
            A11UsuariosId = P00002_A11UsuariosId[0];
            A264Vacantes_Nombre = P00002_A264Vacantes_Nombre[0];
            A264Vacantes_Nombre = P00002_A264Vacantes_Nombre[0];
            AV10GXM1WorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt = new SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item(context);
            AV9GXM2RootCol.Add(AV10GXM1WorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt, 0);
            AV10GXM1WorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt.gxTpr_Vacantes_id = A263Vacantes_Id;
            AV10GXM1WorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt.gxTpr_Usuariosid = A11UsuariosId;
            AV10GXM1WorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt.gxTpr_Vacantes_nombre = A264Vacantes_Nombre;
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
         P00002_A284SUBT_ReclutadorId = new int[1] ;
         P00002_A263Vacantes_Id = new int[1] ;
         P00002_A11UsuariosId = new int[1] ;
         P00002_A264Vacantes_Nombre = new String[] {""} ;
         A264Vacantes_Nombre = "";
         AV10GXM1WorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt = new SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithdevicesusuarios_usuarios_section_usuariosvacante1_grid1__default(),
            new Object[][] {
                new Object[] {
               P00002_A284SUBT_ReclutadorId, P00002_A263Vacantes_Id, P00002_A11UsuariosId, P00002_A264Vacantes_Nombre
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A284SUBT_ReclutadorId ;
      private int AV6gxid ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A263Vacantes_Id ;
      private int A11UsuariosId ;
      private long AV7start ;
      private long AV8count ;
      private String scmdbuf ;
      private String A264Vacantes_Nombre ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00002_A284SUBT_ReclutadorId ;
      private int[] P00002_A263Vacantes_Id ;
      private int[] P00002_A11UsuariosId ;
      private String[] P00002_A264Vacantes_Nombre ;
      private GXBaseCollection<SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item> aP4_GXM2RootCol ;
      private GXBaseCollection<SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item> AV9GXM2RootCol ;
      private SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item AV10GXM1WorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt ;
   }

   public class workwithdevicesusuarios_usuarios_section_usuariosvacante1_grid1__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00002 ;
          prmP00002 = new Object[] {
          new Object[] {"SUBT_ReclutadorId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"GXPagingFrom2",System.Data.DbType.Int32,9,0} ,
          new Object[] {"GXPagingTo2",System.Data.DbType.Int32,9,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P00002", "SELECT T1.`SUBT_ReclutadorId`, T1.`Vacantes_Id`, T1.`UsuariosId`, T2.`Vacantes_Nombre` FROM (`VacantesUsuariosVacante` T1 INNER JOIN `Vacantes` T2 ON T2.`Vacantes_Id` = T1.`Vacantes_Id`) WHERE T1.`SUBT_ReclutadorId` = ? ORDER BY T1.`SUBT_ReclutadorId`  LIMIT ?, ?",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00002,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                ((String[]) buf[3])[0] = rslt.getVarchar(4) ;
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
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.workwithdevicesusuarios_usuarios_section_usuariosvacante1_grid1_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class workwithdevicesusuarios_usuarios_section_usuariosvacante1_grid1_services : GxRestService
 {
    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Bare  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/?SUBT_ReclutadorId={SUBT_ReclutadorId}&start={start}&count={count}&gxid={gxid}")]
    public GxGenericCollection<SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item_RESTInterface> execute( int SUBT_ReclutadorId ,
                                                                                                                                  String start ,
                                                                                                                                  String count ,
                                                                                                                                  String gxid )
    {
       GxGenericCollection<SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item_RESTInterface> GXM2RootCol = new GxGenericCollection<SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item_RESTInterface>() ;
       try
       {
          if ( ! ProcessHeaders("workwithdevicesusuarios_usuarios_section_usuariosvacante1_grid1") )
          {
             return null ;
          }
          workwithdevicesusuarios_usuarios_section_usuariosvacante1_grid1 worker = new workwithdevicesusuarios_usuarios_section_usuariosvacante1_grid1(context) ;
          worker.IsMain = RunAsMain ;
          long gxrstart = 0 ;
          gxrstart = (long)(NumberUtil.Val( (String)(start), "."));
          long gxrcount = 0 ;
          gxrcount = (long)(NumberUtil.Val( (String)(count), "."));
          int gxrgxid = 0 ;
          gxrgxid = (int)(NumberUtil.Val( (String)(gxid), "."));
          GXBaseCollection<SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item> gxrGXM2RootCol = new GXBaseCollection<SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item>() ;
          worker.execute(SUBT_ReclutadorId,gxrstart,gxrcount,gxrgxid,out gxrGXM2RootCol );
          worker.cleanup( );
          GXM2RootCol = new GxGenericCollection<SdtWorkWithDevicesUsuarios_Usuarios_Section_UsuariosVacante1_Grid1Sdt_Item_RESTInterface>(gxrGXM2RootCol) ;
          return GXM2RootCol ;
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
