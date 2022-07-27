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
   public class getauth : GXProcedure
   {
      public getauth( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public getauth( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( String aP0_ObjMnu ,
                           int aP1_RolId ,
                           out bool aP2_Acceso )
      {
         this.AV8ObjMnu = aP0_ObjMnu;
         this.AV11RolId = aP1_RolId;
         this.AV10Acceso = false ;
         initialize();
         executePrivate();
         aP2_Acceso=this.AV10Acceso;
      }

      public bool executeUdp( String aP0_ObjMnu ,
                              int aP1_RolId )
      {
         execute(aP0_ObjMnu, aP1_RolId, out aP2_Acceso);
         return AV10Acceso ;
      }

      public void executeSubmit( String aP0_ObjMnu ,
                                 int aP1_RolId ,
                                 out bool aP2_Acceso )
      {
         getauth objgetauth;
         objgetauth = new getauth();
         objgetauth.AV8ObjMnu = aP0_ObjMnu;
         objgetauth.AV11RolId = aP1_RolId;
         objgetauth.AV10Acceso = false ;
         objgetauth.context.SetSubmitInitialConfig(context);
         objgetauth.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgetauth);
         aP2_Acceso=this.AV10Acceso;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getauth)stateInfo).executePrivate();
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
         AV10Acceso = false;
         AV14GXLvl4 = 0;
         /* Using cursor P001J2 */
         pr_default.execute(0, new Object[] {AV11RolId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1MenuXid = P001J2_A1MenuXid[0];
            A24RolId = P001J2_A24RolId[0];
            A5MenXEst = P001J2_A5MenXEst[0];
            n5MenXEst = P001J2_n5MenXEst[0];
            A262Descripcion = P001J2_A262Descripcion[0];
            A3MenuXPosi = P001J2_A3MenuXPosi[0];
            n3MenuXPosi = P001J2_n3MenuXPosi[0];
            A5MenXEst = P001J2_A5MenXEst[0];
            n5MenXEst = P001J2_n5MenXEst[0];
            A262Descripcion = P001J2_A262Descripcion[0];
            A3MenuXPosi = P001J2_A3MenuXPosi[0];
            n3MenuXPosi = P001J2_n3MenuXPosi[0];
            AV14GXLvl4 = 1;
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.Upper( A262Descripcion)), StringUtil.Trim( StringUtil.Upper( AV8ObjMnu))) == 0 )
            {
               AV10Acceso = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV14GXLvl4 == 0 )
         {
            AV10Acceso = false;
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
         P001J2_A1MenuXid = new short[1] ;
         P001J2_A24RolId = new int[1] ;
         P001J2_A5MenXEst = new String[] {""} ;
         P001J2_n5MenXEst = new bool[] {false} ;
         P001J2_A262Descripcion = new String[] {""} ;
         P001J2_A3MenuXPosi = new short[1] ;
         P001J2_n3MenuXPosi = new bool[] {false} ;
         A5MenXEst = "";
         A262Descripcion = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getauth__default(),
            new Object[][] {
                new Object[] {
               P001J2_A1MenuXid, P001J2_A24RolId, P001J2_A5MenXEst, P001J2_n5MenXEst, P001J2_A262Descripcion, P001J2_A3MenuXPosi, P001J2_n3MenuXPosi
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV14GXLvl4 ;
      private short A1MenuXid ;
      private short A3MenuXPosi ;
      private int AV11RolId ;
      private int A24RolId ;
      private String scmdbuf ;
      private String A5MenXEst ;
      private bool AV10Acceso ;
      private bool n5MenXEst ;
      private bool n3MenuXPosi ;
      private String AV8ObjMnu ;
      private String A262Descripcion ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P001J2_A1MenuXid ;
      private int[] P001J2_A24RolId ;
      private String[] P001J2_A5MenXEst ;
      private bool[] P001J2_n5MenXEst ;
      private String[] P001J2_A262Descripcion ;
      private short[] P001J2_A3MenuXPosi ;
      private bool[] P001J2_n3MenuXPosi ;
      private bool aP2_Acceso ;
   }

   public class getauth__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001J2 ;
          prmP001J2 = new Object[] {
          new Object[] {"AV11RolId",System.Data.DbType.Int32,9,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P001J2", "SELECT T1.`MenuXid`, T1.`RolId`, T2.`MenXEst`, T2.`Descripcion`, T2.`MenuXPosi` FROM (`MenuRol` T1 INNER JOIN `Menu` T2 ON T2.`MenuXid` = T1.`MenuXid`) WHERE (T1.`RolId` = ?) AND (T2.`MenXEst` = 'A') ORDER BY T2.`MenuXPosi` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001J2,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 1) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((String[]) buf[4])[0] = rslt.getVarchar(4) ;
                ((short[]) buf[5])[0] = rslt.getShort(5) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
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
