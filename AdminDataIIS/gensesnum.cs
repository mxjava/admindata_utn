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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gensesnum : GXProcedure
   {
      public gensesnum( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public gensesnum( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( ref int aP0_SecurityIdentifier ,
                           ref long aP1_SecRnd )
      {
         this.A78SecurityIdentifier = aP0_SecurityIdentifier;
         this.AV8SecRnd = aP1_SecRnd;
         initialize();
         executePrivate();
         aP0_SecurityIdentifier=this.A78SecurityIdentifier;
         aP1_SecRnd=this.AV8SecRnd;
      }

      public long executeUdp( ref int aP0_SecurityIdentifier )
      {
         execute(ref aP0_SecurityIdentifier, ref aP1_SecRnd);
         return AV8SecRnd ;
      }

      public void executeSubmit( ref int aP0_SecurityIdentifier ,
                                 ref long aP1_SecRnd )
      {
         gensesnum objgensesnum;
         objgensesnum = new gensesnum();
         objgensesnum.A78SecurityIdentifier = aP0_SecurityIdentifier;
         objgensesnum.AV8SecRnd = aP1_SecRnd;
         objgensesnum.context.SetSubmitInitialConfig(context);
         objgensesnum.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgensesnum);
         aP0_SecurityIdentifier=this.A78SecurityIdentifier;
         aP1_SecRnd=this.AV8SecRnd;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gensesnum)stateInfo).executePrivate();
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
         AV14GXLvl3 = 0;
         /* Using cursor P00102 */
         pr_default.execute(0, new Object[] {A78SecurityIdentifier});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A80SecurityRandom = P00102_A80SecurityRandom[0];
            A79SecurityDate = P00102_A79SecurityDate[0];
            AV14GXLvl3 = 1;
            AV11otro = (decimal)(NumberUtil.Random( ));
            AV8SecRnd = (long)(AV11otro*1000000);
            A80SecurityRandom = AV8SecRnd;
            A79SecurityDate = DateTimeUtil.Now( context);
            /* Using cursor P00103 */
            pr_default.execute(1, new Object[] {A80SecurityRandom, A79SecurityDate, A78SecurityIdentifier});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("Security") ;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV14GXLvl3 == 0 )
         {
            GXt_int1 = AV8SecRnd;
            new insertsec(context ).execute( ref  A78SecurityIdentifier, ref  GXt_int1) ;
            AV8SecRnd = GXt_int1;
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("gensesnum",pr_default);
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
         P00102_A78SecurityIdentifier = new int[1] ;
         P00102_A80SecurityRandom = new long[1] ;
         P00102_A79SecurityDate = new DateTime[] {DateTime.MinValue} ;
         A79SecurityDate = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gensesnum__default(),
            new Object[][] {
                new Object[] {
               P00102_A78SecurityIdentifier, P00102_A80SecurityRandom, P00102_A79SecurityDate
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV14GXLvl3 ;
      private int A78SecurityIdentifier ;
      private long AV8SecRnd ;
      private long A80SecurityRandom ;
      private long GXt_int1 ;
      private decimal AV11otro ;
      private String scmdbuf ;
      private DateTime A79SecurityDate ;
      private IGxDataStore dsDefault ;
      private int aP0_SecurityIdentifier ;
      private long aP1_SecRnd ;
      private IDataStoreProvider pr_default ;
      private int[] P00102_A78SecurityIdentifier ;
      private long[] P00102_A80SecurityRandom ;
      private DateTime[] P00102_A79SecurityDate ;
   }

   public class gensesnum__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00102 ;
          prmP00102 = new Object[] {
          new Object[] {"SecurityIdentifier",System.Data.DbType.Int32,6,0}
          } ;
          Object[] prmP00103 ;
          prmP00103 = new Object[] {
          new Object[] {"SecurityRandom",System.Data.DbType.Int64,10,0} ,
          new Object[] {"SecurityDate",System.Data.DbType.DateTime,8,8} ,
          new Object[] {"SecurityIdentifier",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P00102", "SELECT `SecurityIdentifier`, `SecurityRandom`, `SecurityDate` FROM `Security` WHERE `SecurityIdentifier` = ? ORDER BY `SecurityIdentifier`  FOR UPDATE ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00102,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00103", "UPDATE `Security` SET `SecurityRandom`=?, `SecurityDate`=?  WHERE `SecurityIdentifier` = ?", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00103)
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
                ((long[]) buf[1])[0] = rslt.getLong(2) ;
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3) ;
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
             case 1 :
                stmt.SetParameter(1, (long)parms[0]);
                stmt.SetParameterDatetime(2, (DateTime)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                return;
       }
    }

 }

}
