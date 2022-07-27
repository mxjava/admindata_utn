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
   public class pr_buscacurp : GXProcedure
   {
      public pr_buscacurp( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public pr_buscacurp( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( String aP0_UsuariosCurp ,
                           String aP1_UsuariosCurpAnt ,
                           String aP2_Gx_mode ,
                           out short aP3_Existe )
      {
         this.AV8UsuariosCurp = aP0_UsuariosCurp;
         this.AV10UsuariosCurpAnt = aP1_UsuariosCurpAnt;
         this.Gx_mode = aP2_Gx_mode;
         this.AV9Existe = 0 ;
         initialize();
         executePrivate();
         aP3_Existe=this.AV9Existe;
      }

      public short executeUdp( String aP0_UsuariosCurp ,
                               String aP1_UsuariosCurpAnt ,
                               String aP2_Gx_mode )
      {
         execute(aP0_UsuariosCurp, aP1_UsuariosCurpAnt, aP2_Gx_mode, out aP3_Existe);
         return AV9Existe ;
      }

      public void executeSubmit( String aP0_UsuariosCurp ,
                                 String aP1_UsuariosCurpAnt ,
                                 String aP2_Gx_mode ,
                                 out short aP3_Existe )
      {
         pr_buscacurp objpr_buscacurp;
         objpr_buscacurp = new pr_buscacurp();
         objpr_buscacurp.AV8UsuariosCurp = aP0_UsuariosCurp;
         objpr_buscacurp.AV10UsuariosCurpAnt = aP1_UsuariosCurpAnt;
         objpr_buscacurp.Gx_mode = aP2_Gx_mode;
         objpr_buscacurp.AV9Existe = 0 ;
         objpr_buscacurp.context.SetSubmitInitialConfig(context);
         objpr_buscacurp.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpr_buscacurp);
         aP3_Existe=this.AV9Existe;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pr_buscacurp)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV14GXLvl3 = 0;
            /* Using cursor P001E2 */
            pr_default.execute(0, new Object[] {AV8UsuariosCurp});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A105UsuariosCurp = P001E2_A105UsuariosCurp[0];
               A11UsuariosId = P001E2_A11UsuariosId[0];
               AV14GXLvl3 = 1;
               AV9Existe = 1;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV14GXLvl3 == 0 )
            {
               AV9Existe = 2;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(StringUtil.Trim( AV8UsuariosCurp), StringUtil.Trim( AV10UsuariosCurpAnt)) == 0 )
            {
               AV9Existe = 2;
            }
            else
            {
               AV15GXLvl16 = 0;
               /* Using cursor P001E3 */
               pr_default.execute(1, new Object[] {AV8UsuariosCurp});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A105UsuariosCurp = P001E3_A105UsuariosCurp[0];
                  A11UsuariosId = P001E3_A11UsuariosId[0];
                  AV15GXLvl16 = 1;
                  AV9Existe = 1;
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               if ( AV15GXLvl16 == 0 )
               {
                  AV9Existe = 2;
               }
            }
         }
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
         P001E2_A105UsuariosCurp = new String[] {""} ;
         P001E2_A11UsuariosId = new int[1] ;
         A105UsuariosCurp = "";
         P001E3_A105UsuariosCurp = new String[] {""} ;
         P001E3_A11UsuariosId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pr_buscacurp__default(),
            new Object[][] {
                new Object[] {
               P001E2_A105UsuariosCurp, P001E2_A11UsuariosId
               }
               , new Object[] {
               P001E3_A105UsuariosCurp, P001E3_A11UsuariosId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV9Existe ;
      private short AV14GXLvl3 ;
      private short AV15GXLvl16 ;
      private int A11UsuariosId ;
      private String Gx_mode ;
      private String scmdbuf ;
      private String AV8UsuariosCurp ;
      private String AV10UsuariosCurpAnt ;
      private String A105UsuariosCurp ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private String[] P001E2_A105UsuariosCurp ;
      private int[] P001E2_A11UsuariosId ;
      private String[] P001E3_A105UsuariosCurp ;
      private int[] P001E3_A11UsuariosId ;
      private short aP3_Existe ;
   }

   public class pr_buscacurp__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP001E2 ;
          prmP001E2 = new Object[] {
          new Object[] {"AV8UsuariosCurp",System.Data.DbType.String,18,0}
          } ;
          Object[] prmP001E3 ;
          prmP001E3 = new Object[] {
          new Object[] {"AV8UsuariosCurp",System.Data.DbType.String,18,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P001E2", "SELECT `UsuariosCurp`, `UsuariosId` FROM `Usuarios` WHERE `UsuariosCurp` = ? ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001E2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P001E3", "SELECT `UsuariosCurp`, `UsuariosId` FROM `Usuarios` WHERE `UsuariosCurp` = ? ORDER BY `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001E3,100, GxCacheFrequency.OFF ,false,false )
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
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                return;
             case 1 :
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
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
                stmt.SetParameter(1, (String)parms[0]);
                return;
             case 1 :
                stmt.SetParameter(1, (String)parms[0]);
                return;
       }
    }

 }

}
