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
   public class inacusr : GXProcedure
   {
      public inacusr( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public inacusr( IGxContext context )
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
         inacusr objinacusr;
         objinacusr = new inacusr();
         objinacusr.AV8UsuariosId = aP0_UsuariosId;
         objinacusr.context.SetSubmitInitialConfig(context);
         objinacusr.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objinacusr);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((inacusr)stateInfo).executePrivate();
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
         /* Using cursor P000R2 */
         pr_default.execute(0, new Object[] {AV8UsuariosId});
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("Usuarios") ;
         /* End optimized UPDATE. */
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("inacusr",pr_default);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.inacusr__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8UsuariosId ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class inacusr__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000R2 ;
          prmP000R2 = new Object[] {
          new Object[] {"AV8UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P000R2", "UPDATE `Usuarios` SET `UsuariosStatus`=0  WHERE `UsuariosId` = ?", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000R2)
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
                return;
       }
    }

 }

}
