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
   public class pr_recuperacurp : GXProcedure
   {
      public pr_recuperacurp( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public pr_recuperacurp( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_UsuariosId ,
                           out String aP1_UsuariosCurp )
      {
         this.AV11UsuariosId = aP0_UsuariosId;
         this.AV8UsuariosCurp = "" ;
         initialize();
         executePrivate();
         aP1_UsuariosCurp=this.AV8UsuariosCurp;
      }

      public String executeUdp( int aP0_UsuariosId )
      {
         execute(aP0_UsuariosId, out aP1_UsuariosCurp);
         return AV8UsuariosCurp ;
      }

      public void executeSubmit( int aP0_UsuariosId ,
                                 out String aP1_UsuariosCurp )
      {
         pr_recuperacurp objpr_recuperacurp;
         objpr_recuperacurp = new pr_recuperacurp();
         objpr_recuperacurp.AV11UsuariosId = aP0_UsuariosId;
         objpr_recuperacurp.AV8UsuariosCurp = "" ;
         objpr_recuperacurp.context.SetSubmitInitialConfig(context);
         objpr_recuperacurp.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpr_recuperacurp);
         aP1_UsuariosCurp=this.AV8UsuariosCurp;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pr_recuperacurp)stateInfo).executePrivate();
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
         AV8UsuariosCurp = "";
         /* Using cursor P001L2 */
         pr_default.execute(0, new Object[] {AV11UsuariosId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11UsuariosId = P001L2_A11UsuariosId[0];
            A105UsuariosCurp = P001L2_A105UsuariosCurp[0];
            AV8UsuariosCurp = A105UsuariosCurp;
            /* Exiting from a For First loop. */
            if (true) break;
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
         P001L2_A11UsuariosId = new int[1] ;
         P001L2_A105UsuariosCurp = new String[] {""} ;
         A105UsuariosCurp = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pr_recuperacurp__default(),
            new Object[][] {
                new Object[] {
               P001L2_A11UsuariosId, P001L2_A105UsuariosCurp
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV11UsuariosId ;
      private int A11UsuariosId ;
      private String scmdbuf ;
      private String AV8UsuariosCurp ;
      private String A105UsuariosCurp ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P001L2_A11UsuariosId ;
      private String[] P001L2_A105UsuariosCurp ;
      private String aP1_UsuariosCurp ;
   }

   public class pr_recuperacurp__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001L2 ;
          prmP001L2 = new Object[] {
          new Object[] {"AV11UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P001L2", "SELECT `UsuariosId`, `UsuariosCurp` FROM `Usuarios` WHERE `UsuariosId` = ? ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001L2,1, GxCacheFrequency.OFF ,false,true )
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

}
