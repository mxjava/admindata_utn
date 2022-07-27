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
   public class pr_descartar : GXProcedure
   {
      public pr_descartar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public pr_descartar( IGxContext context )
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
                           String aP2_VacantesUsuariosMotD )
      {
         this.AV10UsuariosId = aP0_UsuariosId;
         this.AV9Vacantes_Id = aP1_Vacantes_Id;
         this.AV8VacantesUsuariosMotD = aP2_VacantesUsuariosMotD;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_UsuariosId ,
                                 int aP1_Vacantes_Id ,
                                 String aP2_VacantesUsuariosMotD )
      {
         pr_descartar objpr_descartar;
         objpr_descartar = new pr_descartar();
         objpr_descartar.AV10UsuariosId = aP0_UsuariosId;
         objpr_descartar.AV9Vacantes_Id = aP1_Vacantes_Id;
         objpr_descartar.AV8VacantesUsuariosMotD = aP2_VacantesUsuariosMotD;
         objpr_descartar.context.SetSubmitInitialConfig(context);
         objpr_descartar.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpr_descartar);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pr_descartar)stateInfo).executePrivate();
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
         /* Optimized UPDATE. */
         /* Using cursor P001R2 */
         pr_default.execute(0, new Object[] {n294VacantesUsuariosMotD, AV8VacantesUsuariosMotD, AV9Vacantes_Id, AV10UsuariosId});
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("VacantesUsuariosVacante") ;
         /* End optimized UPDATE. */
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("pr_descartar",pr_default);
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
         A294VacantesUsuariosMotD = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pr_descartar__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV10UsuariosId ;
      private int AV9Vacantes_Id ;
      private bool n294VacantesUsuariosMotD ;
      private String AV8VacantesUsuariosMotD ;
      private String A294VacantesUsuariosMotD ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class pr_descartar__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001R2 ;
          prmP001R2 = new Object[] {
          new Object[] {"VacantesUsuariosMotD",System.Data.DbType.String,2048,0} ,
          new Object[] {"AV9Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"AV10UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P001R2", "UPDATE `VacantesUsuariosVacante` SET `VacantesUsuariosMotD`=?, `VacantesUsuariosFechaD`=UTC_TIMESTAMP(), `VacantesUsuariosEstatus`=5  WHERE `Vacantes_Id` = ? and `UsuariosId` = ?", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP001R2)
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
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(1, (String)parms[1]);
                }
                stmt.SetParameter(2, (int)parms[2]);
                stmt.SetParameter(3, (int)parms[3]);
                return;
       }
    }

 }

}
