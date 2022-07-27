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
   public class pr_guardaperfilusuario : GXProcedure
   {
      public pr_guardaperfilusuario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public pr_guardaperfilusuario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_UsuariosId ,
                           int aP1_Perfiles_Id ,
                           String aP2_Procedencia )
      {
         this.AV8UsuariosId = aP0_UsuariosId;
         this.AV12Perfiles_Id = aP1_Perfiles_Id;
         this.AV11Procedencia = aP2_Procedencia;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_UsuariosId ,
                                 int aP1_Perfiles_Id ,
                                 String aP2_Procedencia )
      {
         pr_guardaperfilusuario objpr_guardaperfilusuario;
         objpr_guardaperfilusuario = new pr_guardaperfilusuario();
         objpr_guardaperfilusuario.AV8UsuariosId = aP0_UsuariosId;
         objpr_guardaperfilusuario.AV12Perfiles_Id = aP1_Perfiles_Id;
         objpr_guardaperfilusuario.AV11Procedencia = aP2_Procedencia;
         objpr_guardaperfilusuario.context.SetSubmitInitialConfig(context);
         objpr_guardaperfilusuario.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpr_guardaperfilusuario);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pr_guardaperfilusuario)stateInfo).executePrivate();
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
            INSERT RECORD ON TABLE PerfilesUsuariosPerfil

         */
         A278Perfiles_Id = AV12Perfiles_Id;
         A11UsuariosId = AV8UsuariosId;
         A283PerfilesUsuariosEstatus = 1;
         /* Using cursor P001K2 */
         pr_default.execute(0, new Object[] {A278Perfiles_Id, A11UsuariosId, A283PerfilesUsuariosEstatus});
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("PerfilesUsuariosPerfil") ;
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
         context.CommitDataStores("pr_guardaperfilusuario",pr_default);
         /* Optimized UPDATE. */
         /* Using cursor P001K3 */
         pr_default.execute(1, new Object[] {AV8UsuariosId, AV12Perfiles_Id});
         pr_default.close(1);
         dsDefault.SmartCacheProvider.SetUpdated("PerfilesUsuariosPerfil") ;
         /* End optimized UPDATE. */
         /* Optimized UPDATE. */
         /* Using cursor P001K4 */
         pr_default.execute(2, new Object[] {AV12Perfiles_Id, AV8UsuariosId});
         pr_default.close(2);
         dsDefault.SmartCacheProvider.SetUpdated("PerfilesUsuariosPerfil") ;
         /* End optimized UPDATE. */
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("pr_guardaperfilusuario",pr_default);
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
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pr_guardaperfilusuario__default(),
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

      private short A283PerfilesUsuariosEstatus ;
      private int AV8UsuariosId ;
      private int AV12Perfiles_Id ;
      private int GX_INS27 ;
      private int A278Perfiles_Id ;
      private int A11UsuariosId ;
      private String Gx_emsg ;
      private String AV11Procedencia ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class pr_guardaperfilusuario__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001K2 ;
          prmP001K2 = new Object[] {
          new Object[] {"Perfiles_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"PerfilesUsuariosEstatus",System.Data.DbType.Byte,1,0}
          } ;
          Object[] prmP001K3 ;
          prmP001K3 = new Object[] {
          new Object[] {"AV8UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"AV12Perfiles_Id",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmP001K4 ;
          prmP001K4 = new Object[] {
          new Object[] {"AV12Perfiles_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"AV8UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P001K2", "INSERT INTO `PerfilesUsuariosPerfil`(`Perfiles_Id`, `UsuariosId`, `PerfilesUsuariosEstatus`) VALUES(?, ?, ?)", GxErrorMask.GX_NOMASK,prmP001K2)
             ,new CursorDef("P001K3", "UPDATE `PerfilesUsuariosPerfil` SET `PerfilesUsuariosEstatus`=0  WHERE (`UsuariosId` = ?) AND (`Perfiles_Id` <> ?)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP001K3)
             ,new CursorDef("P001K4", "UPDATE `PerfilesUsuariosPerfil` SET `PerfilesUsuariosEstatus`=1  WHERE `Perfiles_Id` = ? and `UsuariosId` = ?", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP001K4)
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
                stmt.SetParameter(3, (short)parms[2]);
                return;
             case 1 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
             case 2 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
       }
    }

 }

}
