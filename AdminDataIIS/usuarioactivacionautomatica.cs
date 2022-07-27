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
   public class usuarioactivacionautomatica : GXProcedure
   {
      public usuarioactivacionautomatica( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public usuarioactivacionautomatica( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_Parm_Usuarioid ,
                           DateTime aP1_fechaBloqueo ,
                           out bool aP2_auxbanderaRegreso )
      {
         this.AV8Parm_Usuarioid = aP0_Parm_Usuarioid;
         this.AV9fechaBloqueo = aP1_fechaBloqueo;
         this.AV10auxbanderaRegreso = false ;
         initialize();
         executePrivate();
         aP2_auxbanderaRegreso=this.AV10auxbanderaRegreso;
      }

      public bool executeUdp( int aP0_Parm_Usuarioid ,
                              DateTime aP1_fechaBloqueo )
      {
         execute(aP0_Parm_Usuarioid, aP1_fechaBloqueo, out aP2_auxbanderaRegreso);
         return AV10auxbanderaRegreso ;
      }

      public void executeSubmit( int aP0_Parm_Usuarioid ,
                                 DateTime aP1_fechaBloqueo ,
                                 out bool aP2_auxbanderaRegreso )
      {
         usuarioactivacionautomatica objusuarioactivacionautomatica;
         objusuarioactivacionautomatica = new usuarioactivacionautomatica();
         objusuarioactivacionautomatica.AV8Parm_Usuarioid = aP0_Parm_Usuarioid;
         objusuarioactivacionautomatica.AV9fechaBloqueo = aP1_fechaBloqueo;
         objusuarioactivacionautomatica.AV10auxbanderaRegreso = false ;
         objusuarioactivacionautomatica.context.SetSubmitInitialConfig(context);
         objusuarioactivacionautomatica.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objusuarioactivacionautomatica);
         aP2_auxbanderaRegreso=this.AV10auxbanderaRegreso;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((usuarioactivacionautomatica)stateInfo).executePrivate();
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
         /* Using cursor P00112 */
         pr_default.execute(0, new Object[] {AV8Parm_Usuarioid, AV9fechaBloqueo});
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("Intentos") ;
         /* End optimized UPDATE. */
         /* Using cursor P00113 */
         pr_default.execute(1, new Object[] {AV8Parm_Usuarioid});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A11UsuariosId = P00113_A11UsuariosId[0];
            A286UsuariosStatus = P00113_A286UsuariosStatus[0];
            A286UsuariosStatus = 1;
            AV10auxbanderaRegreso = true;
            /* Using cursor P00114 */
            pr_default.execute(2, new Object[] {A286UsuariosStatus, A11UsuariosId});
            pr_default.close(2);
            dsDefault.SmartCacheProvider.SetUpdated("Usuarios") ;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("usuarioactivacionautomatica",pr_default);
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
         P00113_A11UsuariosId = new int[1] ;
         P00113_A286UsuariosStatus = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usuarioactivacionautomatica__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               P00113_A11UsuariosId, P00113_A286UsuariosStatus
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A286UsuariosStatus ;
      private int AV8Parm_Usuarioid ;
      private int A11UsuariosId ;
      private String scmdbuf ;
      private DateTime AV9fechaBloqueo ;
      private bool AV10auxbanderaRegreso ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00113_A11UsuariosId ;
      private short[] P00113_A286UsuariosStatus ;
      private bool aP2_auxbanderaRegreso ;
   }

   public class usuarioactivacionautomatica__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00112 ;
          prmP00112 = new Object[] {
          new Object[] {"AV8Parm_Usuarioid",System.Data.DbType.Int32,6,0} ,
          new Object[] {"AV9fechaBloqueo",System.Data.DbType.Date,8,0}
          } ;
          Object[] prmP00113 ;
          prmP00113 = new Object[] {
          new Object[] {"AV8Parm_Usuarioid",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmP00114 ;
          prmP00114 = new Object[] {
          new Object[] {"UsuariosStatus",System.Data.DbType.Byte,1,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P00112", "UPDATE `Intentos` SET `IntentosHoraBloqueo`='1000-01-01', `Contador`=0  WHERE `UsuariosId` = ? and `FechaIntento` = ?", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00112)
             ,new CursorDef("P00113", "SELECT `UsuariosId`, `UsuariosStatus` FROM `Usuarios` WHERE `UsuariosId` = ? ORDER BY `UsuariosId`  FOR UPDATE ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00113,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00114", "UPDATE `Usuarios` SET `UsuariosStatus`=?  WHERE `UsuariosId` = ?", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00114)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
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
                stmt.SetParameter(2, (DateTime)parms[1]);
                return;
             case 1 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
             case 2 :
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
       }
    }

 }

}
