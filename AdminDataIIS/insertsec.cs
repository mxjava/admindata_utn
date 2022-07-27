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
   public class insertsec : GXProcedure
   {
      public insertsec( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public insertsec( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( ref int aP0_SecID ,
                           ref long aP1_SecRnd )
      {
         this.AV10SecID = aP0_SecID;
         this.AV11SecRnd = aP1_SecRnd;
         initialize();
         executePrivate();
         aP0_SecID=this.AV10SecID;
         aP1_SecRnd=this.AV11SecRnd;
      }

      public long executeUdp( ref int aP0_SecID )
      {
         execute(ref aP0_SecID, ref aP1_SecRnd);
         return AV11SecRnd ;
      }

      public void executeSubmit( ref int aP0_SecID ,
                                 ref long aP1_SecRnd )
      {
         insertsec objinsertsec;
         objinsertsec = new insertsec();
         objinsertsec.AV10SecID = aP0_SecID;
         objinsertsec.AV11SecRnd = aP1_SecRnd;
         objinsertsec.context.SetSubmitInitialConfig(context);
         objinsertsec.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objinsertsec);
         aP0_SecID=this.AV10SecID;
         aP1_SecRnd=this.AV11SecRnd;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((insertsec)stateInfo).executePrivate();
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
         AV11SecRnd = (long)((NumberUtil.Random( ))*1000000);
         /*
            INSERT RECORD ON TABLE Security

         */
         A78SecurityIdentifier = AV10SecID;
         A79SecurityDate = DateTimeUtil.Now( context);
         A80SecurityRandom = AV11SecRnd;
         /* Using cursor P000M2 */
         pr_default.execute(0, new Object[] {A78SecurityIdentifier, A80SecurityRandom, A79SecurityDate});
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("Security") ;
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
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("insertsec",pr_default);
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
         A79SecurityDate = (DateTime)(DateTime.MinValue);
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.insertsec__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV10SecID ;
      private int GX_INS18 ;
      private int A78SecurityIdentifier ;
      private long AV11SecRnd ;
      private long A80SecurityRandom ;
      private String Gx_emsg ;
      private DateTime A79SecurityDate ;
      private IGxDataStore dsDefault ;
      private int aP0_SecID ;
      private long aP1_SecRnd ;
      private IDataStoreProvider pr_default ;
   }

   public class insertsec__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000M2 ;
          prmP000M2 = new Object[] {
          new Object[] {"SecurityIdentifier",System.Data.DbType.Int32,6,0} ,
          new Object[] {"SecurityRandom",System.Data.DbType.Int64,10,0} ,
          new Object[] {"SecurityDate",System.Data.DbType.DateTime,8,8}
          } ;
          def= new CursorDef[] {
              new CursorDef("P000M2", "INSERT INTO `Security`(`SecurityIdentifier`, `SecurityRandom`, `SecurityDate`) VALUES(?, ?, ?)", GxErrorMask.GX_NOMASK,prmP000M2)
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
                stmt.SetParameter(2, (long)parms[1]);
                stmt.SetParameterDatetime(3, (DateTime)parms[2]);
                return;
       }
    }

 }

}
