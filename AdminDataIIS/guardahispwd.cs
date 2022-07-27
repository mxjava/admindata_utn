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
   public class guardahispwd : GXProcedure
   {
      public guardahispwd( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public guardahispwd( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_UsuariosId ,
                           String aP1_Password ,
                           String aP2_Llave ,
                           short aP3_HistPwdInd )
      {
         this.AV8UsuariosId = aP0_UsuariosId;
         this.AV9Password = aP1_Password;
         this.AV10Llave = aP2_Llave;
         this.AV11HistPwdInd = aP3_HistPwdInd;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_UsuariosId ,
                                 String aP1_Password ,
                                 String aP2_Llave ,
                                 short aP3_HistPwdInd )
      {
         guardahispwd objguardahispwd;
         objguardahispwd = new guardahispwd();
         objguardahispwd.AV8UsuariosId = aP0_UsuariosId;
         objguardahispwd.AV9Password = aP1_Password;
         objguardahispwd.AV10Llave = aP2_Llave;
         objguardahispwd.AV11HistPwdInd = aP3_HistPwdInd;
         objguardahispwd.context.SetSubmitInitialConfig(context);
         objguardahispwd.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objguardahispwd);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((guardahispwd)stateInfo).executePrivate();
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
            INSERT RECORD ON TABLE HistPwd

         */
         A11UsuariosId = AV8UsuariosId;
         A62HisPwdFecha = DateTimeUtil.ServerNow( context, pr_default);
         A110HistPwdConstra = AV9Password;
         A111HistPwdLlave = AV10Llave;
         A73HistPwdInd = AV11HistPwdInd;
         /* Using cursor P00122 */
         pr_default.execute(0, new Object[] {A11UsuariosId, A62HisPwdFecha, A110HistPwdConstra, A111HistPwdLlave, A73HistPwdInd});
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("HistPwd") ;
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
         context.CommitDataStores("guardahispwd",pr_default);
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
         A62HisPwdFecha = (DateTime)(DateTime.MinValue);
         A110HistPwdConstra = "";
         A111HistPwdLlave = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.guardahispwd__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV11HistPwdInd ;
      private short A73HistPwdInd ;
      private int AV8UsuariosId ;
      private int GX_INS12 ;
      private int A11UsuariosId ;
      private String Gx_emsg ;
      private DateTime A62HisPwdFecha ;
      private String AV9Password ;
      private String AV10Llave ;
      private String A110HistPwdConstra ;
      private String A111HistPwdLlave ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class guardahispwd__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00122 ;
          prmP00122 = new Object[] {
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0} ,
          new Object[] {"HisPwdFecha",System.Data.DbType.DateTime,10,8} ,
          new Object[] {"HistPwdConstra",System.Data.DbType.String,32,0} ,
          new Object[] {"HistPwdLlave",System.Data.DbType.String,32,0} ,
          new Object[] {"HistPwdInd",System.Data.DbType.Byte,1,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P00122", "INSERT INTO `HistPwd`(`UsuariosId`, `HisPwdFecha`, `HistPwdConstra`, `HistPwdLlave`, `HistPwdInd`) VALUES(?, ?, ?, ?, ?)", GxErrorMask.GX_NOMASK,prmP00122)
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
                stmt.SetParameterDatetime(2, (DateTime)parms[1]);
                stmt.SetParameter(3, (String)parms[2]);
                stmt.SetParameter(4, (String)parms[3]);
                stmt.SetParameter(5, (short)parms[4]);
                return;
       }
    }

 }

}
