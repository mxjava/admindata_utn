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
   public class pr_cambiastausvacante : GXProcedure
   {
      public pr_cambiastausvacante( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public pr_cambiastausvacante( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_UsuariosId ,
                           int aP1_Vacantes_Id )
      {
         this.AV8UsuariosId = aP0_UsuariosId;
         this.AV9Vacantes_Id = aP1_Vacantes_Id;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_UsuariosId ,
                                 int aP1_Vacantes_Id )
      {
         pr_cambiastausvacante objpr_cambiastausvacante;
         objpr_cambiastausvacante = new pr_cambiastausvacante();
         objpr_cambiastausvacante.AV8UsuariosId = aP0_UsuariosId;
         objpr_cambiastausvacante.AV9Vacantes_Id = aP1_Vacantes_Id;
         objpr_cambiastausvacante.context.SetSubmitInitialConfig(context);
         objpr_cambiastausvacante.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpr_cambiastausvacante);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pr_cambiastausvacante)stateInfo).executePrivate();
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
         /* Using cursor P001Q2 */
         pr_default.execute(0, new Object[] {AV9Vacantes_Id, AV8UsuariosId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A263Vacantes_Id = P001Q2_A263Vacantes_Id[0];
            A11UsuariosId = P001Q2_A11UsuariosId[0];
            A290VacantesUsuariosEstatus = P001Q2_A290VacantesUsuariosEstatus[0];
            n290VacantesUsuariosEstatus = P001Q2_n290VacantesUsuariosEstatus[0];
            A314VacantesUsuariosFecha3 = P001Q2_A314VacantesUsuariosFecha3[0];
            n314VacantesUsuariosFecha3 = P001Q2_n314VacantesUsuariosFecha3[0];
            A313VacantesUsuariosFechaA = P001Q2_A313VacantesUsuariosFechaA[0];
            n313VacantesUsuariosFechaA = P001Q2_n313VacantesUsuariosFechaA[0];
            AV10VacantesUsuariosEstatus = A290VacantesUsuariosEstatus;
            if ( AV10VacantesUsuariosEstatus == 0 )
            {
               A290VacantesUsuariosEstatus = 1;
               n290VacantesUsuariosEstatus = false;
            }
            else if ( AV10VacantesUsuariosEstatus == 1 )
            {
               A290VacantesUsuariosEstatus = 2;
               n290VacantesUsuariosEstatus = false;
               A314VacantesUsuariosFecha3 = DateTimeUtil.ServerNow( context, pr_default);
               n314VacantesUsuariosFecha3 = false;
            }
            else if ( AV10VacantesUsuariosEstatus == 2 )
            {
               A290VacantesUsuariosEstatus = 3;
               n290VacantesUsuariosEstatus = false;
               A313VacantesUsuariosFechaA = DateTimeUtil.ServerNow( context, pr_default);
               n313VacantesUsuariosFechaA = false;
            }
            else if ( AV10VacantesUsuariosEstatus == 3 )
            {
               A290VacantesUsuariosEstatus = 4;
               n290VacantesUsuariosEstatus = false;
            }
            /* Using cursor P001Q3 */
            pr_default.execute(1, new Object[] {n290VacantesUsuariosEstatus, A290VacantesUsuariosEstatus, n314VacantesUsuariosFecha3, A314VacantesUsuariosFecha3, n313VacantesUsuariosFechaA, A313VacantesUsuariosFechaA, A263Vacantes_Id, A11UsuariosId});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("VacantesUsuariosVacante") ;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("pr_cambiastausvacante",pr_default);
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
         P001Q2_A263Vacantes_Id = new int[1] ;
         P001Q2_A11UsuariosId = new int[1] ;
         P001Q2_A290VacantesUsuariosEstatus = new short[1] ;
         P001Q2_n290VacantesUsuariosEstatus = new bool[] {false} ;
         P001Q2_A314VacantesUsuariosFecha3 = new DateTime[] {DateTime.MinValue} ;
         P001Q2_n314VacantesUsuariosFecha3 = new bool[] {false} ;
         P001Q2_A313VacantesUsuariosFechaA = new DateTime[] {DateTime.MinValue} ;
         P001Q2_n313VacantesUsuariosFechaA = new bool[] {false} ;
         A314VacantesUsuariosFecha3 = (DateTime)(DateTime.MinValue);
         A313VacantesUsuariosFechaA = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pr_cambiastausvacante__default(),
            new Object[][] {
                new Object[] {
               P001Q2_A263Vacantes_Id, P001Q2_A11UsuariosId, P001Q2_A290VacantesUsuariosEstatus, P001Q2_n290VacantesUsuariosEstatus, P001Q2_A314VacantesUsuariosFecha3, P001Q2_n314VacantesUsuariosFecha3, P001Q2_A313VacantesUsuariosFechaA, P001Q2_n313VacantesUsuariosFechaA
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A290VacantesUsuariosEstatus ;
      private short AV10VacantesUsuariosEstatus ;
      private int AV8UsuariosId ;
      private int AV9Vacantes_Id ;
      private int A263Vacantes_Id ;
      private int A11UsuariosId ;
      private String scmdbuf ;
      private DateTime A314VacantesUsuariosFecha3 ;
      private DateTime A313VacantesUsuariosFechaA ;
      private bool n290VacantesUsuariosEstatus ;
      private bool n314VacantesUsuariosFecha3 ;
      private bool n313VacantesUsuariosFechaA ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P001Q2_A263Vacantes_Id ;
      private int[] P001Q2_A11UsuariosId ;
      private short[] P001Q2_A290VacantesUsuariosEstatus ;
      private bool[] P001Q2_n290VacantesUsuariosEstatus ;
      private DateTime[] P001Q2_A314VacantesUsuariosFecha3 ;
      private bool[] P001Q2_n314VacantesUsuariosFecha3 ;
      private DateTime[] P001Q2_A313VacantesUsuariosFechaA ;
      private bool[] P001Q2_n313VacantesUsuariosFechaA ;
   }

   public class pr_cambiastausvacante__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001Q2 ;
          prmP001Q2 = new Object[] {
          new Object[] {"AV9Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"AV8UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmP001Q3 ;
          prmP001Q3 = new Object[] {
          new Object[] {"VacantesUsuariosEstatus",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosFecha3",System.Data.DbType.DateTime,8,5} ,
          new Object[] {"VacantesUsuariosFechaA",System.Data.DbType.DateTime,8,5} ,
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P001Q2", "SELECT `Vacantes_Id`, `UsuariosId`, `VacantesUsuariosEstatus`, `VacantesUsuariosFecha3`, `VacantesUsuariosFechaA` FROM `VacantesUsuariosVacante` WHERE `Vacantes_Id` = ? and `UsuariosId` = ? ORDER BY `Vacantes_Id`, `UsuariosId`  FOR UPDATE ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001Q2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P001Q3", "UPDATE `VacantesUsuariosVacante` SET `VacantesUsuariosEstatus`=?, `VacantesUsuariosFecha3`=?, `VacantesUsuariosFechaA`=?  WHERE `Vacantes_Id` = ? AND `UsuariosId` = ?", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP001Q3)
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
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(4) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(5) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
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
                return;
             case 1 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(1, (short)parms[1]);
                }
                if ( (bool)parms[2] )
                {
                   stmt.setNull( 2 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameterDatetime(2, (DateTime)parms[3]);
                }
                if ( (bool)parms[4] )
                {
                   stmt.setNull( 3 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameterDatetime(3, (DateTime)parms[5]);
                }
                stmt.SetParameter(4, (int)parms[6]);
                stmt.SetParameter(5, (int)parms[7]);
                return;
       }
    }

 }

}
