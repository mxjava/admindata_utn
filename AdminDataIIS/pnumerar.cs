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
   public class pnumerar : GXProcedure
   {
      public pnumerar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public pnumerar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( String aP0_NumCod ,
                           out long aP1_NumUltNum )
      {
         this.AV8NumCod = aP0_NumCod;
         this.AV9NumUltNum = 0 ;
         initialize();
         executePrivate();
         aP1_NumUltNum=this.AV9NumUltNum;
      }

      public long executeUdp( String aP0_NumCod )
      {
         execute(aP0_NumCod, out aP1_NumUltNum);
         return AV9NumUltNum ;
      }

      public void executeSubmit( String aP0_NumCod ,
                                 out long aP1_NumUltNum )
      {
         pnumerar objpnumerar;
         objpnumerar = new pnumerar();
         objpnumerar.AV8NumCod = aP0_NumCod;
         objpnumerar.AV9NumUltNum = 0 ;
         objpnumerar.context.SetSubmitInitialConfig(context);
         objpnumerar.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpnumerar);
         aP1_NumUltNum=this.AV9NumUltNum;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pnumerar)stateInfo).executePrivate();
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
         AV14GXLvl2 = 0;
         /* Using cursor P000G2 */
         pr_default.execute(0, new Object[] {AV8NumCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A108NumeradorCve = P000G2_A108NumeradorCve[0];
            A109NumeradorNo = P000G2_A109NumeradorNo[0];
            AV14GXLvl2 = 1;
            AV9NumUltNum = A109NumeradorNo;
            AV9NumUltNum = (long)(AV9NumUltNum+1);
            A109NumeradorNo = AV9NumUltNum;
            /* Using cursor P000G3 */
            pr_default.execute(1, new Object[] {A109NumeradorNo, A108NumeradorCve});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("Numerador") ;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV14GXLvl2 == 0 )
         {
            /*
               INSERT RECORD ON TABLE Numerador

            */
            A108NumeradorCve = AV8NumCod;
            AV9NumUltNum = 1;
            A109NumeradorNo = AV9NumUltNum;
            /* Using cursor P000G4 */
            pr_default.execute(2, new Object[] {A108NumeradorCve, A109NumeradorNo});
            pr_default.close(2);
            dsDefault.SmartCacheProvider.SetUpdated("Numerador") ;
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
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("pnumerar",pr_default);
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
         P000G2_A108NumeradorCve = new String[] {""} ;
         P000G2_A109NumeradorNo = new long[1] ;
         A108NumeradorCve = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pnumerar__default(),
            new Object[][] {
                new Object[] {
               P000G2_A108NumeradorCve, P000G2_A109NumeradorNo
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

      private short AV14GXLvl2 ;
      private int GX_INS14 ;
      private long AV9NumUltNum ;
      private long A109NumeradorNo ;
      private String scmdbuf ;
      private String Gx_emsg ;
      private String AV8NumCod ;
      private String A108NumeradorCve ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private String[] P000G2_A108NumeradorCve ;
      private long[] P000G2_A109NumeradorNo ;
      private long aP1_NumUltNum ;
   }

   public class pnumerar__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000G2 ;
          prmP000G2 = new Object[] {
          new Object[] {"AV8NumCod",System.Data.DbType.String,10,0}
          } ;
          Object[] prmP000G3 ;
          prmP000G3 = new Object[] {
          new Object[] {"NumeradorNo",System.Data.DbType.Int64,18,0} ,
          new Object[] {"NumeradorCve",System.Data.DbType.String,10,0}
          } ;
          Object[] prmP000G4 ;
          prmP000G4 = new Object[] {
          new Object[] {"NumeradorCve",System.Data.DbType.String,10,0} ,
          new Object[] {"NumeradorNo",System.Data.DbType.Int64,18,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P000G2", "SELECT `NumeradorCve`, `NumeradorNo` FROM `Numerador` WHERE `NumeradorCve` = ? ORDER BY `NumeradorCve`  FOR UPDATE ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000G2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000G3", "UPDATE `Numerador` SET `NumeradorNo`=?  WHERE `NumeradorCve` = ?", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000G3)
             ,new CursorDef("P000G4", "INSERT INTO `Numerador`(`NumeradorCve`, `NumeradorNo`) VALUES(?, ?)", GxErrorMask.GX_NOMASK,prmP000G4)
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
                ((long[]) buf[1])[0] = rslt.getLong(2) ;
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
                stmt.SetParameter(1, (long)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                return;
             case 2 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (long)parms[1]);
                return;
       }
    }

 }

}
