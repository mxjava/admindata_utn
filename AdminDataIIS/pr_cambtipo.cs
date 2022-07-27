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
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class pr_cambtipo : GXProcedure
   {
      public pr_cambtipo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public pr_cambtipo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_UsuariosId ,
                           int aP1_Reclutador_Id ,
                           String aP2_PerfilId )
      {
         this.AV8UsuariosId = aP0_UsuariosId;
         this.AV9Reclutador_Id = aP1_Reclutador_Id;
         this.AV10PerfilId = aP2_PerfilId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_UsuariosId ,
                                 int aP1_Reclutador_Id ,
                                 String aP2_PerfilId )
      {
         pr_cambtipo objpr_cambtipo;
         objpr_cambtipo = new pr_cambtipo();
         objpr_cambtipo.AV8UsuariosId = aP0_UsuariosId;
         objpr_cambtipo.AV9Reclutador_Id = aP1_Reclutador_Id;
         objpr_cambtipo.AV10PerfilId = aP2_PerfilId;
         objpr_cambtipo.context.SetSubmitInitialConfig(context);
         objpr_cambtipo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpr_cambtipo);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pr_cambtipo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV10PerfilId, "Postulacion") == 0 )
         {
            /* Optimized UPDATE. */
            /* Using cursor P001N2 */
            pr_default.execute(0, new Object[] {AV8UsuariosId});
            pr_default.close(0);
            dsDefault.SmartCacheProvider.SetUpdated("Usuarios") ;
            /* End optimized UPDATE. */
            /*
               INSERT RECORD ON TABLE VacantesUsuariosVacante

            */
            A263Vacantes_Id = 17;
            A11UsuariosId = AV8UsuariosId;
            A273UsuariosVacanteEstatus = 0;
            A284SUBT_ReclutadorId = AV9Reclutador_Id;
            A288VacantesUsuariosFechaP = DateTimeUtil.ServerNow( context, pr_default);
            /* Using cursor P001N3 */
            pr_default.execute(1, new Object[] {A263Vacantes_Id, A11UsuariosId, A273UsuariosVacanteEstatus, A284SUBT_ReclutadorId, A288VacantesUsuariosFechaP});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("VacantesUsuariosVacante") ;
            if ( (pr_default.getStatus(1) == 1) )
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
            context.CommitDataStores("pr_cambtipo",pr_default);
         }
         else if ( StringUtil.StrCmp(AV10PerfilId, "Candidato") == 0 )
         {
            /*
               INSERT RECORD ON TABLE VacantesUsuariosVacante

            */
            A263Vacantes_Id = 17;
            A11UsuariosId = AV8UsuariosId;
            A273UsuariosVacanteEstatus = 0;
            A284SUBT_ReclutadorId = AV9Reclutador_Id;
            A288VacantesUsuariosFechaP = DateTimeUtil.ServerNow( context, pr_default);
            /* Using cursor P001N4 */
            pr_default.execute(2, new Object[] {A263Vacantes_Id, A11UsuariosId, A273UsuariosVacanteEstatus, A284SUBT_ReclutadorId, A288VacantesUsuariosFechaP});
            pr_default.close(2);
            dsDefault.SmartCacheProvider.SetUpdated("VacantesUsuariosVacante") ;
            if ( (pr_default.getStatus(2) == 1) )
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
            context.CommitDataStores("pr_cambtipo",pr_default);
         }
         else if ( StringUtil.StrCmp(AV10PerfilId, "Prospecto") == 0 )
         {
            /* Optimized UPDATE. */
            /* Using cursor P001N5 */
            pr_default.execute(3, new Object[] {AV8UsuariosId});
            pr_default.close(3);
            dsDefault.SmartCacheProvider.SetUpdated("Usuarios") ;
            /* End optimized UPDATE. */
            AV11sdt_Reclutador.Clear();
            /* Using cursor P001N6 */
            pr_default.execute(4);
            while ( (pr_default.getStatus(4) != 101) )
            {
               BRK1N6 = false;
               A284SUBT_ReclutadorId = P001N6_A284SUBT_ReclutadorId[0];
               A263Vacantes_Id = P001N6_A263Vacantes_Id[0];
               A11UsuariosId = P001N6_A11UsuariosId[0];
               AV12SubT_ReclutadorId = A284SUBT_ReclutadorId;
               AV13Conteo = 0;
               while ( (pr_default.getStatus(4) != 101) && ( P001N6_A284SUBT_ReclutadorId[0] == A284SUBT_ReclutadorId ) )
               {
                  BRK1N6 = false;
                  A263Vacantes_Id = P001N6_A263Vacantes_Id[0];
                  A11UsuariosId = P001N6_A11UsuariosId[0];
                  if ( A284SUBT_ReclutadorId == AV12SubT_ReclutadorId )
                  {
                     AV13Conteo = (short)(AV13Conteo+1);
                  }
                  BRK1N6 = true;
                  pr_default.readNext(4);
               }
               AV14sdt_ReclutadorItem = new Sdtsdt_Reclutador_sdt_ReclutadorItem(context);
               AV14sdt_ReclutadorItem.gxTpr_Subt_reclutadorid = A284SUBT_ReclutadorId;
               AV14sdt_ReclutadorItem.gxTpr_Conteo = AV13Conteo;
               AV11sdt_Reclutador.Add(AV14sdt_ReclutadorItem, 0);
               if ( ! BRK1N6 )
               {
                  BRK1N6 = true;
                  pr_default.readNext(4);
               }
            }
            pr_default.close(4);
            AV11sdt_Reclutador.Sort("conteo");
            AV23GXV1 = 1;
            while ( AV23GXV1 <= AV11sdt_Reclutador.Count )
            {
               AV14sdt_ReclutadorItem = ((Sdtsdt_Reclutador_sdt_ReclutadorItem)AV11sdt_Reclutador.Item(AV23GXV1));
               AV16ValorReclutador = (short)(AV14sdt_ReclutadorItem.gxTpr_Subt_reclutadorid);
               if (true) break;
               AV23GXV1 = (int)(AV23GXV1+1);
            }
            if ( (0==AV16ValorReclutador) )
            {
               /* Using cursor P001N7 */
               pr_default.execute(5);
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A272UsuariosTipo = P001N7_A272UsuariosTipo[0];
                  A11UsuariosId = P001N7_A11UsuariosId[0];
                  AV16ValorReclutador = (short)(A11UsuariosId);
                  pr_default.readNext(5);
               }
               pr_default.close(5);
            }
            /*
               INSERT RECORD ON TABLE VacantesUsuariosVacante

            */
            A263Vacantes_Id = 17;
            A11UsuariosId = AV8UsuariosId;
            A273UsuariosVacanteEstatus = 0;
            A284SUBT_ReclutadorId = AV16ValorReclutador;
            A288VacantesUsuariosFechaP = DateTimeUtil.ServerNow( context, pr_default);
            /* Using cursor P001N8 */
            pr_default.execute(6, new Object[] {A263Vacantes_Id, A11UsuariosId, A273UsuariosVacanteEstatus, A284SUBT_ReclutadorId, A288VacantesUsuariosFechaP});
            pr_default.close(6);
            dsDefault.SmartCacheProvider.SetUpdated("VacantesUsuariosVacante") ;
            if ( (pr_default.getStatus(6) == 1) )
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
            context.CommitDataStores("pr_cambtipo",pr_default);
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("pr_cambtipo",pr_default);
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
         A288VacantesUsuariosFechaP = (DateTime)(DateTime.MinValue);
         Gx_emsg = "";
         AV11sdt_Reclutador = new GXBaseCollection<Sdtsdt_Reclutador_sdt_ReclutadorItem>( context, "sdt_ReclutadorItem", "ADMINDATA1");
         scmdbuf = "";
         P001N6_A284SUBT_ReclutadorId = new int[1] ;
         P001N6_A263Vacantes_Id = new int[1] ;
         P001N6_A11UsuariosId = new int[1] ;
         AV14sdt_ReclutadorItem = new Sdtsdt_Reclutador_sdt_ReclutadorItem(context);
         P001N7_A272UsuariosTipo = new short[1] ;
         P001N7_A11UsuariosId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pr_cambtipo__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P001N6_A284SUBT_ReclutadorId, P001N6_A263Vacantes_Id, P001N6_A11UsuariosId
               }
               , new Object[] {
               P001N7_A272UsuariosTipo, P001N7_A11UsuariosId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A273UsuariosVacanteEstatus ;
      private short AV13Conteo ;
      private short AV16ValorReclutador ;
      private short A272UsuariosTipo ;
      private int AV8UsuariosId ;
      private int AV9Reclutador_Id ;
      private int GX_INS28 ;
      private int A263Vacantes_Id ;
      private int A11UsuariosId ;
      private int A284SUBT_ReclutadorId ;
      private int AV12SubT_ReclutadorId ;
      private int AV23GXV1 ;
      private String AV10PerfilId ;
      private String Gx_emsg ;
      private String scmdbuf ;
      private DateTime A288VacantesUsuariosFechaP ;
      private bool BRK1N6 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P001N6_A284SUBT_ReclutadorId ;
      private int[] P001N6_A263Vacantes_Id ;
      private int[] P001N6_A11UsuariosId ;
      private short[] P001N7_A272UsuariosTipo ;
      private int[] P001N7_A11UsuariosId ;
      private GXBaseCollection<Sdtsdt_Reclutador_sdt_ReclutadorItem> AV11sdt_Reclutador ;
      private Sdtsdt_Reclutador_sdt_ReclutadorItem AV14sdt_ReclutadorItem ;
   }

   public class pr_cambtipo__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new UpdateCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP001N2 ;
          prmP001N2 = new Object[] {
          new Object[] {"AV8UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmP001N3 ;
          prmP001N3 = new Object[] {
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"UsuariosVacanteEstatus",System.Data.DbType.Byte,1,0} ,
          new Object[] {"SUBT_ReclutadorId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"VacantesUsuariosFechaP",System.Data.DbType.DateTime,10,5}
          } ;
          Object[] prmP001N4 ;
          prmP001N4 = new Object[] {
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"UsuariosVacanteEstatus",System.Data.DbType.Byte,1,0} ,
          new Object[] {"SUBT_ReclutadorId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"VacantesUsuariosFechaP",System.Data.DbType.DateTime,10,5}
          } ;
          Object[] prmP001N5 ;
          prmP001N5 = new Object[] {
          new Object[] {"AV8UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmP001N6 ;
          prmP001N6 = new Object[] {
          } ;
          Object[] prmP001N7 ;
          prmP001N7 = new Object[] {
          } ;
          Object[] prmP001N8 ;
          prmP001N8 = new Object[] {
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"UsuariosVacanteEstatus",System.Data.DbType.Byte,1,0} ,
          new Object[] {"SUBT_ReclutadorId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"VacantesUsuariosFechaP",System.Data.DbType.DateTime,10,5}
          } ;
          def= new CursorDef[] {
              new CursorDef("P001N2", "UPDATE `Usuarios` SET `UsuariosTipo`=3  WHERE `UsuariosId` = ?", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP001N2)
             ,new CursorDef("P001N3", "INSERT INTO `VacantesUsuariosVacante`(`Vacantes_Id`, `UsuariosId`, `UsuariosVacanteEstatus`, `SUBT_ReclutadorId`, `VacantesUsuariosFechaP`, `VacantesUsuariosFechaD`, `VacantesUsuariosEstatus`, `VacantesUsuariosPrefiltro`, `VacantesUsuariosCV`, `VacantesUsuariosExTec`, `VacantesUsuariosMotD`, `VacantesUsuariosFechaE`, `VacantesUsuariosDocP`, `VacantesUsuariosDocCV`, `VacantesUsuariosDocTec`, `VacantesUsuariosCVRec`, `VacantesUsuariosRefLab`, `VacantesUsuariosExPsi`, `VacantesUsuariosBusWeb`, `VacantesUsuariosAvPriv`, `VacantesUsuariosAvConf`, `VacantesUsuariosDocCVRec`, `VacantesUsuariosDocRefLab`, `VacantesUsuariosDocExPsi`, `VacantesUsuariosDocBusWeb`, `VacantesUsuariosDocAvPriv`, `VacantesUsuariosDocAvConf`, `VacantesUsuariosFechaEnvOp`, `VacantesUsuariosFechaEnvCli`, `VacantesUsuariosFechaA`, `VacantesUsuariosFecha3`) VALUES(?, ?, ?, ?, ?, '1000-01-01', 0, 0, 0, 0, '', '1000-01-01', '', '', '', 0, 0, 0, 0, 0, 0, '', '', '', '', '', '', '1000-01-01', '1000-01-01', '1000-01-01', '1000-01-01')", GxErrorMask.GX_NOMASK,prmP001N3)
             ,new CursorDef("P001N4", "INSERT INTO `VacantesUsuariosVacante`(`Vacantes_Id`, `UsuariosId`, `UsuariosVacanteEstatus`, `SUBT_ReclutadorId`, `VacantesUsuariosFechaP`, `VacantesUsuariosFechaD`, `VacantesUsuariosEstatus`, `VacantesUsuariosPrefiltro`, `VacantesUsuariosCV`, `VacantesUsuariosExTec`, `VacantesUsuariosMotD`, `VacantesUsuariosFechaE`, `VacantesUsuariosDocP`, `VacantesUsuariosDocCV`, `VacantesUsuariosDocTec`, `VacantesUsuariosCVRec`, `VacantesUsuariosRefLab`, `VacantesUsuariosExPsi`, `VacantesUsuariosBusWeb`, `VacantesUsuariosAvPriv`, `VacantesUsuariosAvConf`, `VacantesUsuariosDocCVRec`, `VacantesUsuariosDocRefLab`, `VacantesUsuariosDocExPsi`, `VacantesUsuariosDocBusWeb`, `VacantesUsuariosDocAvPriv`, `VacantesUsuariosDocAvConf`, `VacantesUsuariosFechaEnvOp`, `VacantesUsuariosFechaEnvCli`, `VacantesUsuariosFechaA`, `VacantesUsuariosFecha3`) VALUES(?, ?, ?, ?, ?, '1000-01-01', 0, 0, 0, 0, '', '1000-01-01', '', '', '', 0, 0, 0, 0, 0, 0, '', '', '', '', '', '', '1000-01-01', '1000-01-01', '1000-01-01', '1000-01-01')", GxErrorMask.GX_NOMASK,prmP001N4)
             ,new CursorDef("P001N5", "UPDATE `Usuarios` SET `UsuariosTipo`=3  WHERE `UsuariosId` = ?", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP001N5)
             ,new CursorDef("P001N6", "SELECT `SUBT_ReclutadorId`, `Vacantes_Id`, `UsuariosId` FROM `VacantesUsuariosVacante` ORDER BY `SUBT_ReclutadorId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001N6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P001N7", "SELECT `UsuariosTipo`, `UsuariosId` FROM `Usuarios` WHERE `UsuariosTipo` = 5 ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001N7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P001N8", "INSERT INTO `VacantesUsuariosVacante`(`Vacantes_Id`, `UsuariosId`, `UsuariosVacanteEstatus`, `SUBT_ReclutadorId`, `VacantesUsuariosFechaP`, `VacantesUsuariosFechaD`, `VacantesUsuariosEstatus`, `VacantesUsuariosPrefiltro`, `VacantesUsuariosCV`, `VacantesUsuariosExTec`, `VacantesUsuariosMotD`, `VacantesUsuariosFechaE`, `VacantesUsuariosDocP`, `VacantesUsuariosDocCV`, `VacantesUsuariosDocTec`, `VacantesUsuariosCVRec`, `VacantesUsuariosRefLab`, `VacantesUsuariosExPsi`, `VacantesUsuariosBusWeb`, `VacantesUsuariosAvPriv`, `VacantesUsuariosAvConf`, `VacantesUsuariosDocCVRec`, `VacantesUsuariosDocRefLab`, `VacantesUsuariosDocExPsi`, `VacantesUsuariosDocBusWeb`, `VacantesUsuariosDocAvPriv`, `VacantesUsuariosDocAvConf`, `VacantesUsuariosFechaEnvOp`, `VacantesUsuariosFechaEnvCli`, `VacantesUsuariosFechaA`, `VacantesUsuariosFecha3`) VALUES(?, ?, ?, ?, ?, '1000-01-01', 0, 0, 0, 0, '', '1000-01-01', '', '', '', 0, 0, 0, 0, 0, 0, '', '', '', '', '', '', '1000-01-01', '1000-01-01', '1000-01-01', '1000-01-01')", GxErrorMask.GX_NOMASK,prmP001N8)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
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
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                stmt.SetParameter(4, (int)parms[3]);
                stmt.SetParameterDatetime(5, (DateTime)parms[4]);
                return;
             case 2 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                stmt.SetParameter(4, (int)parms[3]);
                stmt.SetParameterDatetime(5, (DateTime)parms[4]);
                return;
             case 3 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 6 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                stmt.SetParameter(4, (int)parms[3]);
                stmt.SetParameterDatetime(5, (DateTime)parms[4]);
                return;
       }
    }

 }

}
