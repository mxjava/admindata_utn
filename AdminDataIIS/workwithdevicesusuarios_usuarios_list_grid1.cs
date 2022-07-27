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
   public class workwithdevicesusuarios_usuarios_list_grid1 : GXProcedure
   {
      public workwithdevicesusuarios_usuarios_list_grid1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public workwithdevicesusuarios_usuarios_list_grid1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( String aP0_SearchText ,
                           DateTime aP1_cUsuariosFecNacimientoFrom ,
                           DateTime aP2_cUsuariosFecNacimientoTo ,
                           DateTime aP3_cUsuariosVigIniFrom ,
                           DateTime aP4_cUsuariosVigIniTo ,
                           DateTime aP5_cUsuariosVigFinFrom ,
                           DateTime aP6_cUsuariosVigFinTo ,
                           int aP7_cRolId ,
                           short aP8_cUsuariosStatus ,
                           long aP9_start ,
                           long aP10_count ,
                           int aP11_gxid ,
                           out GXBaseCollection<SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item> aP12_GXM2RootCol )
      {
         this.AV16SearchText = aP0_SearchText;
         this.AV5cUsuariosFecNacimientoFrom = aP1_cUsuariosFecNacimientoFrom;
         this.AV6cUsuariosFecNacimientoTo = aP2_cUsuariosFecNacimientoTo;
         this.AV7cUsuariosVigIniFrom = aP3_cUsuariosVigIniFrom;
         this.AV8cUsuariosVigIniTo = aP4_cUsuariosVigIniTo;
         this.AV9cUsuariosVigFinFrom = aP5_cUsuariosVigFinFrom;
         this.AV10cUsuariosVigFinTo = aP6_cUsuariosVigFinTo;
         this.AV11cRolId = aP7_cRolId;
         this.AV12cUsuariosStatus = aP8_cUsuariosStatus;
         this.AV14start = aP9_start;
         this.AV15count = aP10_count;
         this.AV13gxid = aP11_gxid;
         this.AV17GXM2RootCol = new GXBaseCollection<SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item>( context, "WorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt.Item", "") ;
         initialize();
         executePrivate();
         aP12_GXM2RootCol=this.AV17GXM2RootCol;
      }

      public GXBaseCollection<SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item> executeUdp( String aP0_SearchText ,
                                                                                                  DateTime aP1_cUsuariosFecNacimientoFrom ,
                                                                                                  DateTime aP2_cUsuariosFecNacimientoTo ,
                                                                                                  DateTime aP3_cUsuariosVigIniFrom ,
                                                                                                  DateTime aP4_cUsuariosVigIniTo ,
                                                                                                  DateTime aP5_cUsuariosVigFinFrom ,
                                                                                                  DateTime aP6_cUsuariosVigFinTo ,
                                                                                                  int aP7_cRolId ,
                                                                                                  short aP8_cUsuariosStatus ,
                                                                                                  long aP9_start ,
                                                                                                  long aP10_count ,
                                                                                                  int aP11_gxid )
      {
         execute(aP0_SearchText, aP1_cUsuariosFecNacimientoFrom, aP2_cUsuariosFecNacimientoTo, aP3_cUsuariosVigIniFrom, aP4_cUsuariosVigIniTo, aP5_cUsuariosVigFinFrom, aP6_cUsuariosVigFinTo, aP7_cRolId, aP8_cUsuariosStatus, aP9_start, aP10_count, aP11_gxid, out aP12_GXM2RootCol);
         return AV17GXM2RootCol ;
      }

      public void executeSubmit( String aP0_SearchText ,
                                 DateTime aP1_cUsuariosFecNacimientoFrom ,
                                 DateTime aP2_cUsuariosFecNacimientoTo ,
                                 DateTime aP3_cUsuariosVigIniFrom ,
                                 DateTime aP4_cUsuariosVigIniTo ,
                                 DateTime aP5_cUsuariosVigFinFrom ,
                                 DateTime aP6_cUsuariosVigFinTo ,
                                 int aP7_cRolId ,
                                 short aP8_cUsuariosStatus ,
                                 long aP9_start ,
                                 long aP10_count ,
                                 int aP11_gxid ,
                                 out GXBaseCollection<SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item> aP12_GXM2RootCol )
      {
         workwithdevicesusuarios_usuarios_list_grid1 objworkwithdevicesusuarios_usuarios_list_grid1;
         objworkwithdevicesusuarios_usuarios_list_grid1 = new workwithdevicesusuarios_usuarios_list_grid1();
         objworkwithdevicesusuarios_usuarios_list_grid1.AV16SearchText = aP0_SearchText;
         objworkwithdevicesusuarios_usuarios_list_grid1.AV5cUsuariosFecNacimientoFrom = aP1_cUsuariosFecNacimientoFrom;
         objworkwithdevicesusuarios_usuarios_list_grid1.AV6cUsuariosFecNacimientoTo = aP2_cUsuariosFecNacimientoTo;
         objworkwithdevicesusuarios_usuarios_list_grid1.AV7cUsuariosVigIniFrom = aP3_cUsuariosVigIniFrom;
         objworkwithdevicesusuarios_usuarios_list_grid1.AV8cUsuariosVigIniTo = aP4_cUsuariosVigIniTo;
         objworkwithdevicesusuarios_usuarios_list_grid1.AV9cUsuariosVigFinFrom = aP5_cUsuariosVigFinFrom;
         objworkwithdevicesusuarios_usuarios_list_grid1.AV10cUsuariosVigFinTo = aP6_cUsuariosVigFinTo;
         objworkwithdevicesusuarios_usuarios_list_grid1.AV11cRolId = aP7_cRolId;
         objworkwithdevicesusuarios_usuarios_list_grid1.AV12cUsuariosStatus = aP8_cUsuariosStatus;
         objworkwithdevicesusuarios_usuarios_list_grid1.AV14start = aP9_start;
         objworkwithdevicesusuarios_usuarios_list_grid1.AV15count = aP10_count;
         objworkwithdevicesusuarios_usuarios_list_grid1.AV13gxid = aP11_gxid;
         objworkwithdevicesusuarios_usuarios_list_grid1.AV17GXM2RootCol = new GXBaseCollection<SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item>( context, "WorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt.Item", "") ;
         objworkwithdevicesusuarios_usuarios_list_grid1.context.SetSubmitInitialConfig(context);
         objworkwithdevicesusuarios_usuarios_list_grid1.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objworkwithdevicesusuarios_usuarios_list_grid1);
         aP12_GXM2RootCol=this.AV17GXM2RootCol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((workwithdevicesusuarios_usuarios_list_grid1)stateInfo).executePrivate();
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
         GXPagingFrom2 = (int)(AV14start);
         GXPagingTo2 = (int)(((AV15count>0) ? AV15count : 100000000));
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV16SearchText ,
                                              AV5cUsuariosFecNacimientoFrom ,
                                              AV6cUsuariosFecNacimientoTo ,
                                              AV7cUsuariosVigIniFrom ,
                                              AV8cUsuariosVigIniTo ,
                                              AV9cUsuariosVigFinFrom ,
                                              AV10cUsuariosVigFinTo ,
                                              AV11cRolId ,
                                              AV12cUsuariosStatus ,
                                              A105UsuariosCurp ,
                                              A66UsuariosNombre ,
                                              A65UsuariosApPat ,
                                              A64UsuariosApMat ,
                                              A244UsuariosUsr ,
                                              A257UsuariosSexo ,
                                              A68UsuariosPwd ,
                                              A67UsuariosKey ,
                                              A93UsuariosIP ,
                                              A260UsuariosTelef ,
                                              A261UsuariosCorreo ,
                                              A255UsuariosFecNacimiento ,
                                              A96UsuariosVigIni ,
                                              A70UsuariosVigFin ,
                                              A24RolId ,
                                              A286UsuariosStatus } ,
                                              new int[]{
                                              TypeConstants.STRING, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.STRING,
                                              TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.STRING,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.SHORT
                                              }
         } ) ;
         lV16SearchText = StringUtil.Concat( StringUtil.RTrim( AV16SearchText), "%", "");
         lV16SearchText = StringUtil.Concat( StringUtil.RTrim( AV16SearchText), "%", "");
         lV16SearchText = StringUtil.Concat( StringUtil.RTrim( AV16SearchText), "%", "");
         lV16SearchText = StringUtil.Concat( StringUtil.RTrim( AV16SearchText), "%", "");
         lV16SearchText = StringUtil.Concat( StringUtil.RTrim( AV16SearchText), "%", "");
         lV16SearchText = StringUtil.Concat( StringUtil.RTrim( AV16SearchText), "%", "");
         lV16SearchText = StringUtil.Concat( StringUtil.RTrim( AV16SearchText), "%", "");
         lV16SearchText = StringUtil.Concat( StringUtil.RTrim( AV16SearchText), "%", "");
         lV16SearchText = StringUtil.Concat( StringUtil.RTrim( AV16SearchText), "%", "");
         lV16SearchText = StringUtil.Concat( StringUtil.RTrim( AV16SearchText), "%", "");
         lV16SearchText = StringUtil.Concat( StringUtil.RTrim( AV16SearchText), "%", "");
         lV16SearchText = StringUtil.Concat( StringUtil.RTrim( AV16SearchText), "%", "");
         /* Using cursor P00002 */
         pr_default.execute(0, new Object[] {lV16SearchText, lV16SearchText, lV16SearchText, lV16SearchText, lV16SearchText, lV16SearchText, lV16SearchText, lV16SearchText, lV16SearchText, lV16SearchText, lV16SearchText, lV16SearchText, AV5cUsuariosFecNacimientoFrom, AV6cUsuariosFecNacimientoTo, AV7cUsuariosVigIniFrom, AV8cUsuariosVigIniTo, AV9cUsuariosVigFinFrom, AV10cUsuariosVigFinTo, AV11cRolId, AV12cUsuariosStatus, GXPagingFrom2, GXPagingTo2});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A286UsuariosStatus = P00002_A286UsuariosStatus[0];
            A24RolId = P00002_A24RolId[0];
            A70UsuariosVigFin = P00002_A70UsuariosVigFin[0];
            n70UsuariosVigFin = P00002_n70UsuariosVigFin[0];
            A96UsuariosVigIni = P00002_A96UsuariosVigIni[0];
            A255UsuariosFecNacimiento = P00002_A255UsuariosFecNacimiento[0];
            A105UsuariosCurp = P00002_A105UsuariosCurp[0];
            A66UsuariosNombre = P00002_A66UsuariosNombre[0];
            A65UsuariosApPat = P00002_A65UsuariosApPat[0];
            A64UsuariosApMat = P00002_A64UsuariosApMat[0];
            A244UsuariosUsr = P00002_A244UsuariosUsr[0];
            A68UsuariosPwd = P00002_A68UsuariosPwd[0];
            A67UsuariosKey = P00002_A67UsuariosKey[0];
            A93UsuariosIP = P00002_A93UsuariosIP[0];
            A260UsuariosTelef = P00002_A260UsuariosTelef[0];
            A261UsuariosCorreo = P00002_A261UsuariosCorreo[0];
            A40000UsuariosIcono_GXI = P00002_A40000UsuariosIcono_GXI[0];
            A11UsuariosId = P00002_A11UsuariosId[0];
            A272UsuariosTipo = P00002_A272UsuariosTipo[0];
            A257UsuariosSexo = P00002_A257UsuariosSexo[0];
            A245UsuariosIcono = P00002_A245UsuariosIcono[0];
            if ( StringUtil.StrCmp(A257UsuariosSexo, "H") == 0 )
            {
               A275UsuariosSexoFor = "Hombres";
            }
            else
            {
               if ( StringUtil.StrCmp(A257UsuariosSexo, "M") == 0 )
               {
                  A275UsuariosSexoFor = "Mujeres";
               }
               else
               {
                  A275UsuariosSexoFor = "";
               }
            }
            AV18GXM1WorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt = new SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item(context);
            AV17GXM2RootCol.Add(AV18GXM1WorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt, 0);
            AV18GXM1WorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt.gxTpr_Usuariosid = A11UsuariosId;
            AV18GXM1WorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt.gxTpr_Usuariosicono = A245UsuariosIcono;
            AV18GXM1WorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt.gxTpr_Usuariosicono_gxi = A40000UsuariosIcono_GXI;
            AV18GXM1WorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt.gxTpr_Usuarioscurp = A105UsuariosCurp;
            AV18GXM1WorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt.gxTpr_Usuariostipo = A272UsuariosTipo;
            AV18GXM1WorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt.gxTpr_Usuariosstatus = A286UsuariosStatus;
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
         lV16SearchText = "";
         A105UsuariosCurp = "";
         A66UsuariosNombre = "";
         A65UsuariosApPat = "";
         A64UsuariosApMat = "";
         A244UsuariosUsr = "";
         A257UsuariosSexo = "";
         A68UsuariosPwd = "";
         A67UsuariosKey = "";
         A93UsuariosIP = "";
         A260UsuariosTelef = "";
         A261UsuariosCorreo = "";
         A255UsuariosFecNacimiento = DateTime.MinValue;
         A96UsuariosVigIni = DateTime.MinValue;
         A70UsuariosVigFin = DateTime.MinValue;
         P00002_A286UsuariosStatus = new short[1] ;
         P00002_A24RolId = new int[1] ;
         P00002_A70UsuariosVigFin = new DateTime[] {DateTime.MinValue} ;
         P00002_n70UsuariosVigFin = new bool[] {false} ;
         P00002_A96UsuariosVigIni = new DateTime[] {DateTime.MinValue} ;
         P00002_A255UsuariosFecNacimiento = new DateTime[] {DateTime.MinValue} ;
         P00002_A105UsuariosCurp = new String[] {""} ;
         P00002_A66UsuariosNombre = new String[] {""} ;
         P00002_A65UsuariosApPat = new String[] {""} ;
         P00002_A64UsuariosApMat = new String[] {""} ;
         P00002_A244UsuariosUsr = new String[] {""} ;
         P00002_A68UsuariosPwd = new String[] {""} ;
         P00002_A67UsuariosKey = new String[] {""} ;
         P00002_A93UsuariosIP = new String[] {""} ;
         P00002_A260UsuariosTelef = new String[] {""} ;
         P00002_A261UsuariosCorreo = new String[] {""} ;
         P00002_A40000UsuariosIcono_GXI = new String[] {""} ;
         P00002_A11UsuariosId = new int[1] ;
         P00002_A272UsuariosTipo = new short[1] ;
         P00002_A257UsuariosSexo = new String[] {""} ;
         P00002_A245UsuariosIcono = new String[] {""} ;
         A40000UsuariosIcono_GXI = "";
         A245UsuariosIcono = "";
         A275UsuariosSexoFor = "";
         AV18GXM1WorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt = new SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithdevicesusuarios_usuarios_list_grid1__default(),
            new Object[][] {
                new Object[] {
               P00002_A286UsuariosStatus, P00002_A24RolId, P00002_A70UsuariosVigFin, P00002_n70UsuariosVigFin, P00002_A96UsuariosVigIni, P00002_A255UsuariosFecNacimiento, P00002_A105UsuariosCurp, P00002_A66UsuariosNombre, P00002_A65UsuariosApPat, P00002_A64UsuariosApMat,
               P00002_A244UsuariosUsr, P00002_A68UsuariosPwd, P00002_A67UsuariosKey, P00002_A93UsuariosIP, P00002_A260UsuariosTelef, P00002_A261UsuariosCorreo, P00002_A40000UsuariosIcono_GXI, P00002_A11UsuariosId, P00002_A272UsuariosTipo, P00002_A257UsuariosSexo,
               P00002_A245UsuariosIcono
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV12cUsuariosStatus ;
      private short A286UsuariosStatus ;
      private short A272UsuariosTipo ;
      private int AV11cRolId ;
      private int AV13gxid ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A24RolId ;
      private int A11UsuariosId ;
      private long AV14start ;
      private long AV15count ;
      private String scmdbuf ;
      private String A257UsuariosSexo ;
      private String A260UsuariosTelef ;
      private String A275UsuariosSexoFor ;
      private DateTime AV5cUsuariosFecNacimientoFrom ;
      private DateTime AV6cUsuariosFecNacimientoTo ;
      private DateTime AV7cUsuariosVigIniFrom ;
      private DateTime AV8cUsuariosVigIniTo ;
      private DateTime AV9cUsuariosVigFinFrom ;
      private DateTime AV10cUsuariosVigFinTo ;
      private DateTime A255UsuariosFecNacimiento ;
      private DateTime A96UsuariosVigIni ;
      private DateTime A70UsuariosVigFin ;
      private bool n70UsuariosVigFin ;
      private String AV16SearchText ;
      private String lV16SearchText ;
      private String A105UsuariosCurp ;
      private String A66UsuariosNombre ;
      private String A65UsuariosApPat ;
      private String A64UsuariosApMat ;
      private String A244UsuariosUsr ;
      private String A68UsuariosPwd ;
      private String A67UsuariosKey ;
      private String A93UsuariosIP ;
      private String A261UsuariosCorreo ;
      private String A40000UsuariosIcono_GXI ;
      private String A245UsuariosIcono ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00002_A286UsuariosStatus ;
      private int[] P00002_A24RolId ;
      private DateTime[] P00002_A70UsuariosVigFin ;
      private bool[] P00002_n70UsuariosVigFin ;
      private DateTime[] P00002_A96UsuariosVigIni ;
      private DateTime[] P00002_A255UsuariosFecNacimiento ;
      private String[] P00002_A105UsuariosCurp ;
      private String[] P00002_A66UsuariosNombre ;
      private String[] P00002_A65UsuariosApPat ;
      private String[] P00002_A64UsuariosApMat ;
      private String[] P00002_A244UsuariosUsr ;
      private String[] P00002_A68UsuariosPwd ;
      private String[] P00002_A67UsuariosKey ;
      private String[] P00002_A93UsuariosIP ;
      private String[] P00002_A260UsuariosTelef ;
      private String[] P00002_A261UsuariosCorreo ;
      private String[] P00002_A40000UsuariosIcono_GXI ;
      private int[] P00002_A11UsuariosId ;
      private short[] P00002_A272UsuariosTipo ;
      private String[] P00002_A257UsuariosSexo ;
      private String[] P00002_A245UsuariosIcono ;
      private GXBaseCollection<SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item> aP12_GXM2RootCol ;
      private GXBaseCollection<SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item> AV17GXM2RootCol ;
      private SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item AV18GXM1WorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt ;
   }

   public class workwithdevicesusuarios_usuarios_list_grid1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00002( IGxContext context ,
                                             String AV16SearchText ,
                                             DateTime AV5cUsuariosFecNacimientoFrom ,
                                             DateTime AV6cUsuariosFecNacimientoTo ,
                                             DateTime AV7cUsuariosVigIniFrom ,
                                             DateTime AV8cUsuariosVigIniTo ,
                                             DateTime AV9cUsuariosVigFinFrom ,
                                             DateTime AV10cUsuariosVigFinTo ,
                                             int AV11cRolId ,
                                             short AV12cUsuariosStatus ,
                                             String A105UsuariosCurp ,
                                             String A66UsuariosNombre ,
                                             String A65UsuariosApPat ,
                                             String A64UsuariosApMat ,
                                             String A244UsuariosUsr ,
                                             String A257UsuariosSexo ,
                                             String A68UsuariosPwd ,
                                             String A67UsuariosKey ,
                                             String A93UsuariosIP ,
                                             String A260UsuariosTelef ,
                                             String A261UsuariosCorreo ,
                                             DateTime A255UsuariosFecNacimiento ,
                                             DateTime A96UsuariosVigIni ,
                                             DateTime A70UsuariosVigFin ,
                                             int A24RolId ,
                                             short A286UsuariosStatus )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int1 ;
         GXv_int1 = new short [22] ;
         Object[] GXv_Object2 ;
         GXv_Object2 = new Object [2] ;
         String sSelectString ;
         String sFromString ;
         String sOrderString ;
         sSelectString = " `UsuariosStatus`, `RolId`, `UsuariosVigFin`, `UsuariosVigIni`, `UsuariosFecNacimiento`, `UsuariosCurp`, `UsuariosNombre`, `UsuariosApPat`, `UsuariosApMat`, `UsuariosUsr`, `UsuariosPwd`, `UsuariosKey`, `UsuariosIP`, `UsuariosTelef`, `UsuariosCorreo`, `UsuariosIcono_GXI`, `UsuariosId`, `UsuariosTipo`, `UsuariosSexo`, `UsuariosIcono`";
         sFromString = " FROM `Usuarios`";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16SearchText)) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (UPPER(`UsuariosCurp`) like CONCAT('%', UPPER(?)) or UPPER(`UsuariosNombre`) like CONCAT('%', UPPER(?)) or UPPER(`UsuariosApPat`) like CONCAT('%', UPPER(?)) or UPPER(`UsuariosApMat`) like CONCAT('%', UPPER(?)) or UPPER(`UsuariosUsr`) like CONCAT('%', UPPER(?)) or UPPER(`UsuariosSexo`) like CONCAT('%', UPPER(?)) or UPPER(`UsuariosPwd`) like CONCAT('%', UPPER(?)) or UPPER(`UsuariosKey`) like CONCAT('%', UPPER(?)) or UPPER(`UsuariosIP`) like CONCAT('%', UPPER(?)) or UPPER(`UsuariosTelef`) like CONCAT('%', UPPER(?)) or UPPER(`UsuariosCorreo`) like CONCAT('%', UPPER(?)) or UPPER(( CASE  WHEN `UsuariosSexo` = 'H' THEN 'Hombres' WHEN `UsuariosSexo` = 'M' THEN 'Mujeres' END)) like CONCAT('%', UPPER(?)))";
            }
            else
            {
               sWhereString = sWhereString + " (UPPER(`UsuariosCurp`) like CONCAT('%', UPPER(?)) or UPPER(`UsuariosNombre`) like CONCAT('%', UPPER(?)) or UPPER(`UsuariosApPat`) like CONCAT('%', UPPER(?)) or UPPER(`UsuariosApMat`) like CONCAT('%', UPPER(?)) or UPPER(`UsuariosUsr`) like CONCAT('%', UPPER(?)) or UPPER(`UsuariosSexo`) like CONCAT('%', UPPER(?)) or UPPER(`UsuariosPwd`) like CONCAT('%', UPPER(?)) or UPPER(`UsuariosKey`) like CONCAT('%', UPPER(?)) or UPPER(`UsuariosIP`) like CONCAT('%', UPPER(?)) or UPPER(`UsuariosTelef`) like CONCAT('%', UPPER(?)) or UPPER(`UsuariosCorreo`) like CONCAT('%', UPPER(?)) or UPPER(( CASE  WHEN `UsuariosSexo` = 'H' THEN 'Hombres' WHEN `UsuariosSexo` = 'M' THEN 'Mujeres' END)) like CONCAT('%', UPPER(?)))";
            }
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
            GXv_int1[8] = 1;
            GXv_int1[9] = 1;
            GXv_int1[10] = 1;
            GXv_int1[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV5cUsuariosFecNacimientoFrom) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (`UsuariosFecNacimiento` >= ?)";
            }
            else
            {
               sWhereString = sWhereString + " (`UsuariosFecNacimiento` >= ?)";
            }
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV6cUsuariosFecNacimientoTo) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (`UsuariosFecNacimiento` <= ?)";
            }
            else
            {
               sWhereString = sWhereString + " (`UsuariosFecNacimiento` <= ?)";
            }
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV7cUsuariosVigIniFrom) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (`UsuariosVigIni` >= ?)";
            }
            else
            {
               sWhereString = sWhereString + " (`UsuariosVigIni` >= ?)";
            }
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cUsuariosVigIniTo) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (`UsuariosVigIni` <= ?)";
            }
            else
            {
               sWhereString = sWhereString + " (`UsuariosVigIni` <= ?)";
            }
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cUsuariosVigFinFrom) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (`UsuariosVigFin` >= ?)";
            }
            else
            {
               sWhereString = sWhereString + " (`UsuariosVigFin` >= ?)";
            }
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV10cUsuariosVigFinTo) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (`UsuariosVigFin` <= ?)";
            }
            else
            {
               sWhereString = sWhereString + " (`UsuariosVigFin` <= ?)";
            }
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! (0==AV11cRolId) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (`RolId` = ?)";
            }
            else
            {
               sWhereString = sWhereString + " (`RolId` = ?)";
            }
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! (0==AV12cUsuariosStatus) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (`UsuariosStatus` >= ?)";
            }
            else
            {
               sWhereString = sWhereString + " (`UsuariosStatus` >= ?)";
            }
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( StringUtil.StrCmp("", sWhereString) != 0 )
         {
            sWhereString = " WHERE" + sWhereString;
         }
         sOrderString = sOrderString + " ORDER BY `UsuariosCurp`";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " LIMIT " + "?" + ", " + "?";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00002(context, (String)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (int)dynConstraints[7] , (short)dynConstraints[8] , (String)dynConstraints[9] , (String)dynConstraints[10] , (String)dynConstraints[11] , (String)dynConstraints[12] , (String)dynConstraints[13] , (String)dynConstraints[14] , (String)dynConstraints[15] , (String)dynConstraints[16] , (String)dynConstraints[17] , (String)dynConstraints[18] , (String)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (int)dynConstraints[23] , (short)dynConstraints[24] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          new Object[] {"lV16SearchText",System.Data.DbType.String,1000,0} ,
          new Object[] {"lV16SearchText",System.Data.DbType.String,1000,0} ,
          new Object[] {"lV16SearchText",System.Data.DbType.String,1000,0} ,
          new Object[] {"lV16SearchText",System.Data.DbType.String,1000,0} ,
          new Object[] {"lV16SearchText",System.Data.DbType.String,1000,0} ,
          new Object[] {"lV16SearchText",System.Data.DbType.String,1000,0} ,
          new Object[] {"lV16SearchText",System.Data.DbType.String,1000,0} ,
          new Object[] {"lV16SearchText",System.Data.DbType.String,1000,0} ,
          new Object[] {"lV16SearchText",System.Data.DbType.String,1000,0} ,
          new Object[] {"lV16SearchText",System.Data.DbType.String,1000,0} ,
          new Object[] {"lV16SearchText",System.Data.DbType.String,1000,0} ,
          new Object[] {"lV16SearchText",System.Data.DbType.String,1000,0} ,
          new Object[] {"AV5cUsuariosFecNacimientoFrom",System.Data.DbType.Date,8,0} ,
          new Object[] {"AV6cUsuariosFecNacimientoTo",System.Data.DbType.Date,8,0} ,
          new Object[] {"AV7cUsuariosVigIniFrom",System.Data.DbType.Date,8,0} ,
          new Object[] {"AV8cUsuariosVigIniTo",System.Data.DbType.Date,8,0} ,
          new Object[] {"AV9cUsuariosVigFinFrom",System.Data.DbType.Date,8,0} ,
          new Object[] {"AV10cUsuariosVigFinTo",System.Data.DbType.Date,8,0} ,
          new Object[] {"AV11cRolId",System.Data.DbType.Int32,9,0} ,
          new Object[] {"AV12cUsuariosStatus",System.Data.DbType.Byte,1,0} ,
          new Object[] {"GXPagingFrom2",System.Data.DbType.Int32,9,0} ,
          new Object[] {"GXPagingTo2",System.Data.DbType.Int32,9,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P00002", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00002,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4) ;
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5) ;
                ((String[]) buf[6])[0] = rslt.getVarchar(6) ;
                ((String[]) buf[7])[0] = rslt.getVarchar(7) ;
                ((String[]) buf[8])[0] = rslt.getVarchar(8) ;
                ((String[]) buf[9])[0] = rslt.getVarchar(9) ;
                ((String[]) buf[10])[0] = rslt.getVarchar(10) ;
                ((String[]) buf[11])[0] = rslt.getVarchar(11) ;
                ((String[]) buf[12])[0] = rslt.getVarchar(12) ;
                ((String[]) buf[13])[0] = rslt.getVarchar(13) ;
                ((String[]) buf[14])[0] = rslt.getString(14, 10) ;
                ((String[]) buf[15])[0] = rslt.getVarchar(15) ;
                ((String[]) buf[16])[0] = rslt.getMultimediaUri(16) ;
                ((int[]) buf[17])[0] = rslt.getInt(17) ;
                ((short[]) buf[18])[0] = rslt.getShort(18) ;
                ((String[]) buf[19])[0] = rslt.getString(19, 1) ;
                ((String[]) buf[20])[0] = rslt.getMultimediaFile(20, rslt.getVarchar(16)) ;
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       short sIdx ;
       switch ( cursor )
       {
             case 0 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[22]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[23]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[24]);
                }
                if ( (short)parms[3] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[25]);
                }
                if ( (short)parms[4] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[26]);
                }
                if ( (short)parms[5] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[27]);
                }
                if ( (short)parms[6] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[28]);
                }
                if ( (short)parms[7] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[29]);
                }
                if ( (short)parms[8] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[30]);
                }
                if ( (short)parms[9] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[31]);
                }
                if ( (short)parms[10] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[32]);
                }
                if ( (short)parms[11] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[33]);
                }
                if ( (short)parms[12] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[34]);
                }
                if ( (short)parms[13] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[35]);
                }
                if ( (short)parms[14] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[36]);
                }
                if ( (short)parms[15] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[37]);
                }
                if ( (short)parms[16] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[38]);
                }
                if ( (short)parms[17] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[39]);
                }
                if ( (short)parms[18] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[40]);
                }
                if ( (short)parms[19] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (short)parms[41]);
                }
                if ( (short)parms[20] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[42]);
                }
                if ( (short)parms[21] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[43]);
                }
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.workwithdevicesusuarios_usuarios_list_grid1_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class workwithdevicesusuarios_usuarios_list_grid1_services : GxRestService
 {
    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Bare  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/?SearchText={SearchText}&cUsuariosFecNacimientoFrom={cUsuariosFecNacimientoFrom}&cUsuariosFecNacimientoTo={cUsuariosFecNacimientoTo}&cUsuariosVigIniFrom={cUsuariosVigIniFrom}&cUsuariosVigIniTo={cUsuariosVigIniTo}&cUsuariosVigFinFrom={cUsuariosVigFinFrom}&cUsuariosVigFinTo={cUsuariosVigFinTo}&cRolId={cRolId}&cUsuariosStatus={cUsuariosStatus}&start={start}&count={count}&gxid={gxid}")]
    public GxGenericCollection<SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_RESTInterface> execute( String SearchText ,
                                                                                                              String cUsuariosFecNacimientoFrom ,
                                                                                                              String cUsuariosFecNacimientoTo ,
                                                                                                              String cUsuariosVigIniFrom ,
                                                                                                              String cUsuariosVigIniTo ,
                                                                                                              String cUsuariosVigFinFrom ,
                                                                                                              String cUsuariosVigFinTo ,
                                                                                                              String cRolId ,
                                                                                                              short cUsuariosStatus ,
                                                                                                              String start ,
                                                                                                              String count ,
                                                                                                              String gxid )
    {
       GxGenericCollection<SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_RESTInterface> GXM2RootCol = new GxGenericCollection<SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_RESTInterface>() ;
       try
       {
          if ( ! ProcessHeaders("workwithdevicesusuarios_usuarios_list_grid1") )
          {
             return null ;
          }
          workwithdevicesusuarios_usuarios_list_grid1 worker = new workwithdevicesusuarios_usuarios_list_grid1(context) ;
          worker.IsMain = RunAsMain ;
          DateTime gxrcUsuariosFecNacimientoFrom = DateTime.MinValue ;
          gxrcUsuariosFecNacimientoFrom = DateTimeUtil.CToD2( (String)(cUsuariosFecNacimientoFrom));
          DateTime gxrcUsuariosFecNacimientoTo = DateTime.MinValue ;
          gxrcUsuariosFecNacimientoTo = DateTimeUtil.CToD2( (String)(cUsuariosFecNacimientoTo));
          DateTime gxrcUsuariosVigIniFrom = DateTime.MinValue ;
          gxrcUsuariosVigIniFrom = DateTimeUtil.CToD2( (String)(cUsuariosVigIniFrom));
          DateTime gxrcUsuariosVigIniTo = DateTime.MinValue ;
          gxrcUsuariosVigIniTo = DateTimeUtil.CToD2( (String)(cUsuariosVigIniTo));
          DateTime gxrcUsuariosVigFinFrom = DateTime.MinValue ;
          gxrcUsuariosVigFinFrom = DateTimeUtil.CToD2( (String)(cUsuariosVigFinFrom));
          DateTime gxrcUsuariosVigFinTo = DateTime.MinValue ;
          gxrcUsuariosVigFinTo = DateTimeUtil.CToD2( (String)(cUsuariosVigFinTo));
          int gxrcRolId = 0 ;
          gxrcRolId = (int)(NumberUtil.Val( (String)(cRolId), "."));
          long gxrstart = 0 ;
          gxrstart = (long)(NumberUtil.Val( (String)(start), "."));
          long gxrcount = 0 ;
          gxrcount = (long)(NumberUtil.Val( (String)(count), "."));
          int gxrgxid = 0 ;
          gxrgxid = (int)(NumberUtil.Val( (String)(gxid), "."));
          GXBaseCollection<SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item> gxrGXM2RootCol = new GXBaseCollection<SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item>() ;
          worker.execute(SearchText,gxrcUsuariosFecNacimientoFrom,gxrcUsuariosFecNacimientoTo,gxrcUsuariosVigIniFrom,gxrcUsuariosVigIniTo,gxrcUsuariosVigFinFrom,gxrcUsuariosVigFinTo,gxrcRolId,cUsuariosStatus,gxrstart,gxrcount,gxrgxid,out gxrGXM2RootCol );
          worker.cleanup( );
          GXM2RootCol = new GxGenericCollection<SdtWorkWithDevicesUsuarios_Usuarios_List_Grid1Sdt_Item_RESTInterface>(gxrGXM2RootCol) ;
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
