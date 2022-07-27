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
   public class pr_guardavacanteusuario : GXProcedure
   {
      public pr_guardavacanteusuario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public pr_guardavacanteusuario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_UsuariosId ,
                           int aP1_Vacantes_Id ,
                           String aP2_Procedencia ,
                           int aP3_UsuarioReclutador )
      {
         this.AV8UsuariosId = aP0_UsuariosId;
         this.AV9Vacantes_Id = aP1_Vacantes_Id;
         this.AV12Procedencia = aP2_Procedencia;
         this.AV13UsuarioReclutador = aP3_UsuarioReclutador;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_UsuariosId ,
                                 int aP1_Vacantes_Id ,
                                 String aP2_Procedencia ,
                                 int aP3_UsuarioReclutador )
      {
         pr_guardavacanteusuario objpr_guardavacanteusuario;
         objpr_guardavacanteusuario = new pr_guardavacanteusuario();
         objpr_guardavacanteusuario.AV8UsuariosId = aP0_UsuariosId;
         objpr_guardavacanteusuario.AV9Vacantes_Id = aP1_Vacantes_Id;
         objpr_guardavacanteusuario.AV12Procedencia = aP2_Procedencia;
         objpr_guardavacanteusuario.AV13UsuarioReclutador = aP3_UsuarioReclutador;
         objpr_guardavacanteusuario.context.SetSubmitInitialConfig(context);
         objpr_guardavacanteusuario.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpr_guardavacanteusuario);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pr_guardavacanteusuario)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV12Procedencia, "Postularse") == 0 )
         {
            AV16GXLvl4 = 0;
            /* Optimized UPDATE. */
            /* Using cursor P001I2 */
            pr_default.execute(0, new Object[] {AV9Vacantes_Id, AV8UsuariosId});
            if ( (pr_default.getStatus(0) != 101) )
            {
               AV16GXLvl4 = 1;
            }
            pr_default.close(0);
            dsDefault.SmartCacheProvider.SetUpdated("VacantesUsuariosVacante") ;
            /* End optimized UPDATE. */
            if ( AV16GXLvl4 == 0 )
            {
               /*
                  INSERT RECORD ON TABLE VacantesUsuariosVacante

               */
               A263Vacantes_Id = AV9Vacantes_Id;
               A11UsuariosId = AV8UsuariosId;
               A273UsuariosVacanteEstatus = 1;
               A284SUBT_ReclutadorId = AV13UsuarioReclutador;
               A288VacantesUsuariosFechaP = DateTimeUtil.ServerNow( context, pr_default);
               /* Using cursor P001I3 */
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
               context.CommitDataStores("pr_guardavacanteusuario",pr_default);
            }
         }
         else
         {
            /* Execute user subroutine: 'RECUPERAVACANTE' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'RECUPERAVACANTE' Routine */
         /* Optimized UPDATE. */
         /* Using cursor P001I4 */
         pr_default.execute(2, new Object[] {AV9Vacantes_Id, AV8UsuariosId});
         pr_default.close(2);
         dsDefault.SmartCacheProvider.SetUpdated("VacantesUsuariosVacante") ;
         /* End optimized UPDATE. */
      }

      public override void cleanup( )
      {
         context.CommitDataStores("pr_guardavacanteusuario",pr_default);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pr_guardavacanteusuario__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV16GXLvl4 ;
      private short A273UsuariosVacanteEstatus ;
      private int AV8UsuariosId ;
      private int AV9Vacantes_Id ;
      private int AV13UsuarioReclutador ;
      private int GX_INS28 ;
      private int A263Vacantes_Id ;
      private int A11UsuariosId ;
      private int A284SUBT_ReclutadorId ;
      private String Gx_emsg ;
      private DateTime A288VacantesUsuariosFechaP ;
      private bool returnInSub ;
      private String AV12Procedencia ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class pr_guardavacanteusuario__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP001I2 ;
          prmP001I2 = new Object[] {
          new Object[] {"AV9Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"AV8UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmP001I3 ;
          prmP001I3 = new Object[] {
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"UsuariosVacanteEstatus",System.Data.DbType.Byte,1,0} ,
          new Object[] {"SUBT_ReclutadorId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"VacantesUsuariosFechaP",System.Data.DbType.DateTime,10,5}
          } ;
          Object[] prmP001I4 ;
          prmP001I4 = new Object[] {
          new Object[] {"AV9Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"AV8UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P001I2", "UPDATE `VacantesUsuariosVacante` SET `VacantesUsuariosFechaP`=UTC_TIMESTAMP(), `UsuariosVacanteEstatus`=1  WHERE `Vacantes_Id` = ? and `UsuariosId` = ?", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP001I2)
             ,new CursorDef("P001I3", "INSERT INTO `VacantesUsuariosVacante`(`Vacantes_Id`, `UsuariosId`, `UsuariosVacanteEstatus`, `SUBT_ReclutadorId`, `VacantesUsuariosFechaP`, `VacantesUsuariosFechaD`, `VacantesUsuariosEstatus`, `VacantesUsuariosPrefiltro`, `VacantesUsuariosCV`, `VacantesUsuariosExTec`, `VacantesUsuariosMotD`, `VacantesUsuariosFechaE`, `VacantesUsuariosDocP`, `VacantesUsuariosDocCV`, `VacantesUsuariosDocTec`, `VacantesUsuariosCVRec`, `VacantesUsuariosRefLab`, `VacantesUsuariosExPsi`, `VacantesUsuariosBusWeb`, `VacantesUsuariosAvPriv`, `VacantesUsuariosAvConf`, `VacantesUsuariosDocCVRec`, `VacantesUsuariosDocRefLab`, `VacantesUsuariosDocExPsi`, `VacantesUsuariosDocBusWeb`, `VacantesUsuariosDocAvPriv`, `VacantesUsuariosDocAvConf`, `VacantesUsuariosFechaEnvOp`, `VacantesUsuariosFechaEnvCli`, `VacantesUsuariosFechaA`, `VacantesUsuariosFecha3`) VALUES(?, ?, ?, ?, ?, '1000-01-01', 0, 0, 0, 0, '', '1000-01-01', '', '', '', 0, 0, 0, 0, 0, 0, '', '', '', '', '', '', '1000-01-01', '1000-01-01', '1000-01-01', '1000-01-01')", GxErrorMask.GX_NOMASK,prmP001I3)
             ,new CursorDef("P001I4", "UPDATE `VacantesUsuariosVacante` SET `UsuariosVacanteEstatus`=0  WHERE `Vacantes_Id` = ? and `UsuariosId` = ?", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP001I4)
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
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
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
                return;
       }
    }

 }

}
