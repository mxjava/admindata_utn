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
   public class numerarusur : GXProcedure
   {
      public numerarusur( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public numerarusur( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( String aP0_NumCod ,
                           long aP1_NumUltNum )
      {
         this.AV8NumCod = aP0_NumCod;
         this.AV9NumUltNum = aP1_NumUltNum;
         initialize();
         executePrivate();
      }

      public void executeSubmit( String aP0_NumCod ,
                                 long aP1_NumUltNum )
      {
         numerarusur objnumerarusur;
         objnumerarusur = new numerarusur();
         objnumerarusur.AV8NumCod = aP0_NumCod;
         objnumerarusur.AV9NumUltNum = aP1_NumUltNum;
         objnumerarusur.context.SetSubmitInitialConfig(context);
         objnumerarusur.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objnumerarusur);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((numerarusur)stateInfo).executePrivate();
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
         AV12GXLvl2 = 0;
         /* Optimized UPDATE. */
         /* Using cursor P000W2 */
         pr_default.execute(0, new Object[] {AV9NumUltNum, AV8NumCod});
         if ( (pr_default.getStatus(0) != 101) )
         {
            AV12GXLvl2 = 1;
         }
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("Numerador") ;
         /* End optimized UPDATE. */
         if ( AV12GXLvl2 == 0 )
         {
            /*
               INSERT RECORD ON TABLE Numerador

            */
            A108NumeradorCve = AV8NumCod;
            A109NumeradorNo = AV9NumUltNum;
            /* Using cursor P000W3 */
            pr_default.execute(1, new Object[] {A108NumeradorCve, A109NumeradorNo});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("Numerador") ;
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
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("numerarusur",pr_default);
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
         A108NumeradorCve = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.numerarusur__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV12GXLvl2 ;
      private int GX_INS14 ;
      private long AV9NumUltNum ;
      private long A109NumeradorNo ;
      private String Gx_emsg ;
      private String AV8NumCod ;
      private String A108NumeradorCve ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class numerarusur__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000W2 ;
          prmP000W2 = new Object[] {
          new Object[] {"NumeradorNo",System.Data.DbType.Int64,18,0} ,
          new Object[] {"AV8NumCod",System.Data.DbType.String,10,0}
          } ;
          Object[] prmP000W3 ;
          prmP000W3 = new Object[] {
          new Object[] {"NumeradorCve",System.Data.DbType.String,10,0} ,
          new Object[] {"NumeradorNo",System.Data.DbType.Int64,18,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P000W2", "UPDATE `Numerador` SET `NumeradorNo`=?  WHERE `NumeradorCve` = ?", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000W2)
             ,new CursorDef("P000W3", "INSERT INTO `Numerador`(`NumeradorCve`, `NumeradorNo`) VALUES(?, ?)", GxErrorMask.GX_NOMASK,prmP000W3)
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
                stmt.SetParameter(1, (long)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                return;
             case 1 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (long)parms[1]);
                return;
       }
    }

 }

}
