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
   public class pr_recdocvacante : GXProcedure
   {
      public pr_recdocvacante( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public pr_recdocvacante( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_UsuarioId ,
                           int aP1_Vacantes_Id ,
                           short aP2_opDoc ,
                           out String aP3_Ruta_Completa )
      {
         this.AV8UsuarioId = aP0_UsuarioId;
         this.AV9Vacantes_Id = aP1_Vacantes_Id;
         this.AV11opDoc = aP2_opDoc;
         this.AV12Ruta_Completa = "" ;
         initialize();
         executePrivate();
         aP3_Ruta_Completa=this.AV12Ruta_Completa;
      }

      public String executeUdp( int aP0_UsuarioId ,
                                int aP1_Vacantes_Id ,
                                short aP2_opDoc )
      {
         execute(aP0_UsuarioId, aP1_Vacantes_Id, aP2_opDoc, out aP3_Ruta_Completa);
         return AV12Ruta_Completa ;
      }

      public void executeSubmit( int aP0_UsuarioId ,
                                 int aP1_Vacantes_Id ,
                                 short aP2_opDoc ,
                                 out String aP3_Ruta_Completa )
      {
         pr_recdocvacante objpr_recdocvacante;
         objpr_recdocvacante = new pr_recdocvacante();
         objpr_recdocvacante.AV8UsuarioId = aP0_UsuarioId;
         objpr_recdocvacante.AV9Vacantes_Id = aP1_Vacantes_Id;
         objpr_recdocvacante.AV11opDoc = aP2_opDoc;
         objpr_recdocvacante.AV12Ruta_Completa = "" ;
         objpr_recdocvacante.context.SetSubmitInitialConfig(context);
         objpr_recdocvacante.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpr_recdocvacante);
         aP3_Ruta_Completa=this.AV12Ruta_Completa;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pr_recdocvacante)stateInfo).executePrivate();
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
         /* Using cursor P001S2 */
         pr_default.execute(0, new Object[] {AV9Vacantes_Id, AV8UsuarioId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A263Vacantes_Id = P001S2_A263Vacantes_Id[0];
            A11UsuariosId = P001S2_A11UsuariosId[0];
            A291VacantesUsuariosPrefiltro = P001S2_A291VacantesUsuariosPrefiltro[0];
            n291VacantesUsuariosPrefiltro = P001S2_n291VacantesUsuariosPrefiltro[0];
            A296VacantesUsuariosDocP = P001S2_A296VacantesUsuariosDocP[0];
            n296VacantesUsuariosDocP = P001S2_n296VacantesUsuariosDocP[0];
            A292VacantesUsuariosCV = P001S2_A292VacantesUsuariosCV[0];
            n292VacantesUsuariosCV = P001S2_n292VacantesUsuariosCV[0];
            A297VacantesUsuariosDocCV = P001S2_A297VacantesUsuariosDocCV[0];
            n297VacantesUsuariosDocCV = P001S2_n297VacantesUsuariosDocCV[0];
            A293VacantesUsuariosExTec = P001S2_A293VacantesUsuariosExTec[0];
            n293VacantesUsuariosExTec = P001S2_n293VacantesUsuariosExTec[0];
            A298VacantesUsuariosDocTec = P001S2_A298VacantesUsuariosDocTec[0];
            n298VacantesUsuariosDocTec = P001S2_n298VacantesUsuariosDocTec[0];
            A304VacantesUsuariosAvConf = P001S2_A304VacantesUsuariosAvConf[0];
            n304VacantesUsuariosAvConf = P001S2_n304VacantesUsuariosAvConf[0];
            A310VacantesUsuariosDocAvConf = P001S2_A310VacantesUsuariosDocAvConf[0];
            n310VacantesUsuariosDocAvConf = P001S2_n310VacantesUsuariosDocAvConf[0];
            A303VacantesUsuariosAvPriv = P001S2_A303VacantesUsuariosAvPriv[0];
            n303VacantesUsuariosAvPriv = P001S2_n303VacantesUsuariosAvPriv[0];
            A309VacantesUsuariosDocAvPriv = P001S2_A309VacantesUsuariosDocAvPriv[0];
            n309VacantesUsuariosDocAvPriv = P001S2_n309VacantesUsuariosDocAvPriv[0];
            A302VacantesUsuariosBusWeb = P001S2_A302VacantesUsuariosBusWeb[0];
            n302VacantesUsuariosBusWeb = P001S2_n302VacantesUsuariosBusWeb[0];
            A308VacantesUsuariosDocBusWeb = P001S2_A308VacantesUsuariosDocBusWeb[0];
            n308VacantesUsuariosDocBusWeb = P001S2_n308VacantesUsuariosDocBusWeb[0];
            A300VacantesUsuariosRefLab = P001S2_A300VacantesUsuariosRefLab[0];
            n300VacantesUsuariosRefLab = P001S2_n300VacantesUsuariosRefLab[0];
            A306VacantesUsuariosDocRefLab = P001S2_A306VacantesUsuariosDocRefLab[0];
            n306VacantesUsuariosDocRefLab = P001S2_n306VacantesUsuariosDocRefLab[0];
            A301VacantesUsuariosExPsi = P001S2_A301VacantesUsuariosExPsi[0];
            n301VacantesUsuariosExPsi = P001S2_n301VacantesUsuariosExPsi[0];
            A307VacantesUsuariosDocExPsi = P001S2_A307VacantesUsuariosDocExPsi[0];
            n307VacantesUsuariosDocExPsi = P001S2_n307VacantesUsuariosDocExPsi[0];
            A299VacantesUsuariosCVRec = P001S2_A299VacantesUsuariosCVRec[0];
            n299VacantesUsuariosCVRec = P001S2_n299VacantesUsuariosCVRec[0];
            A305VacantesUsuariosDocCVRec = P001S2_A305VacantesUsuariosDocCVRec[0];
            n305VacantesUsuariosDocCVRec = P001S2_n305VacantesUsuariosDocCVRec[0];
            if ( ( AV11opDoc == 1 ) && ( A291VacantesUsuariosPrefiltro == 1 ) )
            {
               AV12Ruta_Completa = A296VacantesUsuariosDocP;
            }
            else if ( ( AV11opDoc == 2 ) && ( A292VacantesUsuariosCV == 1 ) )
            {
               AV12Ruta_Completa = A297VacantesUsuariosDocCV;
            }
            else if ( ( AV11opDoc == 3 ) && ( A293VacantesUsuariosExTec == 1 ) )
            {
               AV12Ruta_Completa = A298VacantesUsuariosDocTec;
            }
            else if ( ( AV11opDoc == 4 ) && ( A304VacantesUsuariosAvConf == 1 ) )
            {
               AV12Ruta_Completa = A310VacantesUsuariosDocAvConf;
            }
            else if ( ( AV11opDoc == 5 ) && ( A303VacantesUsuariosAvPriv == 1 ) )
            {
               AV12Ruta_Completa = A309VacantesUsuariosDocAvPriv;
            }
            else if ( ( AV11opDoc == 6 ) && ( A302VacantesUsuariosBusWeb == 1 ) )
            {
               AV12Ruta_Completa = A308VacantesUsuariosDocBusWeb;
            }
            else if ( ( AV11opDoc == 7 ) && ( A300VacantesUsuariosRefLab == 1 ) )
            {
               AV12Ruta_Completa = A306VacantesUsuariosDocRefLab;
            }
            else if ( ( AV11opDoc == 8 ) && ( A301VacantesUsuariosExPsi == 1 ) )
            {
               AV12Ruta_Completa = A307VacantesUsuariosDocExPsi;
            }
            else if ( ( AV11opDoc == 9 ) && ( A299VacantesUsuariosCVRec == 1 ) )
            {
               AV12Ruta_Completa = A305VacantesUsuariosDocCVRec;
            }
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
         P001S2_A263Vacantes_Id = new int[1] ;
         P001S2_A11UsuariosId = new int[1] ;
         P001S2_A291VacantesUsuariosPrefiltro = new short[1] ;
         P001S2_n291VacantesUsuariosPrefiltro = new bool[] {false} ;
         P001S2_A296VacantesUsuariosDocP = new String[] {""} ;
         P001S2_n296VacantesUsuariosDocP = new bool[] {false} ;
         P001S2_A292VacantesUsuariosCV = new short[1] ;
         P001S2_n292VacantesUsuariosCV = new bool[] {false} ;
         P001S2_A297VacantesUsuariosDocCV = new String[] {""} ;
         P001S2_n297VacantesUsuariosDocCV = new bool[] {false} ;
         P001S2_A293VacantesUsuariosExTec = new short[1] ;
         P001S2_n293VacantesUsuariosExTec = new bool[] {false} ;
         P001S2_A298VacantesUsuariosDocTec = new String[] {""} ;
         P001S2_n298VacantesUsuariosDocTec = new bool[] {false} ;
         P001S2_A304VacantesUsuariosAvConf = new short[1] ;
         P001S2_n304VacantesUsuariosAvConf = new bool[] {false} ;
         P001S2_A310VacantesUsuariosDocAvConf = new String[] {""} ;
         P001S2_n310VacantesUsuariosDocAvConf = new bool[] {false} ;
         P001S2_A303VacantesUsuariosAvPriv = new short[1] ;
         P001S2_n303VacantesUsuariosAvPriv = new bool[] {false} ;
         P001S2_A309VacantesUsuariosDocAvPriv = new String[] {""} ;
         P001S2_n309VacantesUsuariosDocAvPriv = new bool[] {false} ;
         P001S2_A302VacantesUsuariosBusWeb = new short[1] ;
         P001S2_n302VacantesUsuariosBusWeb = new bool[] {false} ;
         P001S2_A308VacantesUsuariosDocBusWeb = new String[] {""} ;
         P001S2_n308VacantesUsuariosDocBusWeb = new bool[] {false} ;
         P001S2_A300VacantesUsuariosRefLab = new short[1] ;
         P001S2_n300VacantesUsuariosRefLab = new bool[] {false} ;
         P001S2_A306VacantesUsuariosDocRefLab = new String[] {""} ;
         P001S2_n306VacantesUsuariosDocRefLab = new bool[] {false} ;
         P001S2_A301VacantesUsuariosExPsi = new short[1] ;
         P001S2_n301VacantesUsuariosExPsi = new bool[] {false} ;
         P001S2_A307VacantesUsuariosDocExPsi = new String[] {""} ;
         P001S2_n307VacantesUsuariosDocExPsi = new bool[] {false} ;
         P001S2_A299VacantesUsuariosCVRec = new short[1] ;
         P001S2_n299VacantesUsuariosCVRec = new bool[] {false} ;
         P001S2_A305VacantesUsuariosDocCVRec = new String[] {""} ;
         P001S2_n305VacantesUsuariosDocCVRec = new bool[] {false} ;
         A296VacantesUsuariosDocP = "";
         A297VacantesUsuariosDocCV = "";
         A298VacantesUsuariosDocTec = "";
         A310VacantesUsuariosDocAvConf = "";
         A309VacantesUsuariosDocAvPriv = "";
         A308VacantesUsuariosDocBusWeb = "";
         A306VacantesUsuariosDocRefLab = "";
         A307VacantesUsuariosDocExPsi = "";
         A305VacantesUsuariosDocCVRec = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pr_recdocvacante__default(),
            new Object[][] {
                new Object[] {
               P001S2_A263Vacantes_Id, P001S2_A11UsuariosId, P001S2_A291VacantesUsuariosPrefiltro, P001S2_n291VacantesUsuariosPrefiltro, P001S2_A296VacantesUsuariosDocP, P001S2_n296VacantesUsuariosDocP, P001S2_A292VacantesUsuariosCV, P001S2_n292VacantesUsuariosCV, P001S2_A297VacantesUsuariosDocCV, P001S2_n297VacantesUsuariosDocCV,
               P001S2_A293VacantesUsuariosExTec, P001S2_n293VacantesUsuariosExTec, P001S2_A298VacantesUsuariosDocTec, P001S2_n298VacantesUsuariosDocTec, P001S2_A304VacantesUsuariosAvConf, P001S2_n304VacantesUsuariosAvConf, P001S2_A310VacantesUsuariosDocAvConf, P001S2_n310VacantesUsuariosDocAvConf, P001S2_A303VacantesUsuariosAvPriv, P001S2_n303VacantesUsuariosAvPriv,
               P001S2_A309VacantesUsuariosDocAvPriv, P001S2_n309VacantesUsuariosDocAvPriv, P001S2_A302VacantesUsuariosBusWeb, P001S2_n302VacantesUsuariosBusWeb, P001S2_A308VacantesUsuariosDocBusWeb, P001S2_n308VacantesUsuariosDocBusWeb, P001S2_A300VacantesUsuariosRefLab, P001S2_n300VacantesUsuariosRefLab, P001S2_A306VacantesUsuariosDocRefLab, P001S2_n306VacantesUsuariosDocRefLab,
               P001S2_A301VacantesUsuariosExPsi, P001S2_n301VacantesUsuariosExPsi, P001S2_A307VacantesUsuariosDocExPsi, P001S2_n307VacantesUsuariosDocExPsi, P001S2_A299VacantesUsuariosCVRec, P001S2_n299VacantesUsuariosCVRec, P001S2_A305VacantesUsuariosDocCVRec, P001S2_n305VacantesUsuariosDocCVRec
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV11opDoc ;
      private short A291VacantesUsuariosPrefiltro ;
      private short A292VacantesUsuariosCV ;
      private short A293VacantesUsuariosExTec ;
      private short A304VacantesUsuariosAvConf ;
      private short A303VacantesUsuariosAvPriv ;
      private short A302VacantesUsuariosBusWeb ;
      private short A300VacantesUsuariosRefLab ;
      private short A301VacantesUsuariosExPsi ;
      private short A299VacantesUsuariosCVRec ;
      private int AV8UsuarioId ;
      private int AV9Vacantes_Id ;
      private int A263Vacantes_Id ;
      private int A11UsuariosId ;
      private String scmdbuf ;
      private bool n291VacantesUsuariosPrefiltro ;
      private bool n296VacantesUsuariosDocP ;
      private bool n292VacantesUsuariosCV ;
      private bool n297VacantesUsuariosDocCV ;
      private bool n293VacantesUsuariosExTec ;
      private bool n298VacantesUsuariosDocTec ;
      private bool n304VacantesUsuariosAvConf ;
      private bool n310VacantesUsuariosDocAvConf ;
      private bool n303VacantesUsuariosAvPriv ;
      private bool n309VacantesUsuariosDocAvPriv ;
      private bool n302VacantesUsuariosBusWeb ;
      private bool n308VacantesUsuariosDocBusWeb ;
      private bool n300VacantesUsuariosRefLab ;
      private bool n306VacantesUsuariosDocRefLab ;
      private bool n301VacantesUsuariosExPsi ;
      private bool n307VacantesUsuariosDocExPsi ;
      private bool n299VacantesUsuariosCVRec ;
      private bool n305VacantesUsuariosDocCVRec ;
      private String AV12Ruta_Completa ;
      private String A296VacantesUsuariosDocP ;
      private String A297VacantesUsuariosDocCV ;
      private String A298VacantesUsuariosDocTec ;
      private String A310VacantesUsuariosDocAvConf ;
      private String A309VacantesUsuariosDocAvPriv ;
      private String A308VacantesUsuariosDocBusWeb ;
      private String A306VacantesUsuariosDocRefLab ;
      private String A307VacantesUsuariosDocExPsi ;
      private String A305VacantesUsuariosDocCVRec ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P001S2_A263Vacantes_Id ;
      private int[] P001S2_A11UsuariosId ;
      private short[] P001S2_A291VacantesUsuariosPrefiltro ;
      private bool[] P001S2_n291VacantesUsuariosPrefiltro ;
      private String[] P001S2_A296VacantesUsuariosDocP ;
      private bool[] P001S2_n296VacantesUsuariosDocP ;
      private short[] P001S2_A292VacantesUsuariosCV ;
      private bool[] P001S2_n292VacantesUsuariosCV ;
      private String[] P001S2_A297VacantesUsuariosDocCV ;
      private bool[] P001S2_n297VacantesUsuariosDocCV ;
      private short[] P001S2_A293VacantesUsuariosExTec ;
      private bool[] P001S2_n293VacantesUsuariosExTec ;
      private String[] P001S2_A298VacantesUsuariosDocTec ;
      private bool[] P001S2_n298VacantesUsuariosDocTec ;
      private short[] P001S2_A304VacantesUsuariosAvConf ;
      private bool[] P001S2_n304VacantesUsuariosAvConf ;
      private String[] P001S2_A310VacantesUsuariosDocAvConf ;
      private bool[] P001S2_n310VacantesUsuariosDocAvConf ;
      private short[] P001S2_A303VacantesUsuariosAvPriv ;
      private bool[] P001S2_n303VacantesUsuariosAvPriv ;
      private String[] P001S2_A309VacantesUsuariosDocAvPriv ;
      private bool[] P001S2_n309VacantesUsuariosDocAvPriv ;
      private short[] P001S2_A302VacantesUsuariosBusWeb ;
      private bool[] P001S2_n302VacantesUsuariosBusWeb ;
      private String[] P001S2_A308VacantesUsuariosDocBusWeb ;
      private bool[] P001S2_n308VacantesUsuariosDocBusWeb ;
      private short[] P001S2_A300VacantesUsuariosRefLab ;
      private bool[] P001S2_n300VacantesUsuariosRefLab ;
      private String[] P001S2_A306VacantesUsuariosDocRefLab ;
      private bool[] P001S2_n306VacantesUsuariosDocRefLab ;
      private short[] P001S2_A301VacantesUsuariosExPsi ;
      private bool[] P001S2_n301VacantesUsuariosExPsi ;
      private String[] P001S2_A307VacantesUsuariosDocExPsi ;
      private bool[] P001S2_n307VacantesUsuariosDocExPsi ;
      private short[] P001S2_A299VacantesUsuariosCVRec ;
      private bool[] P001S2_n299VacantesUsuariosCVRec ;
      private String[] P001S2_A305VacantesUsuariosDocCVRec ;
      private bool[] P001S2_n305VacantesUsuariosDocCVRec ;
      private String aP3_Ruta_Completa ;
   }

   public class pr_recdocvacante__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001S2 ;
          prmP001S2 = new Object[] {
          new Object[] {"AV9Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"AV8UsuarioId",System.Data.DbType.Int32,9,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P001S2", "SELECT `Vacantes_Id`, `UsuariosId`, `VacantesUsuariosPrefiltro`, `VacantesUsuariosDocP`, `VacantesUsuariosCV`, `VacantesUsuariosDocCV`, `VacantesUsuariosExTec`, `VacantesUsuariosDocTec`, `VacantesUsuariosAvConf`, `VacantesUsuariosDocAvConf`, `VacantesUsuariosAvPriv`, `VacantesUsuariosDocAvPriv`, `VacantesUsuariosBusWeb`, `VacantesUsuariosDocBusWeb`, `VacantesUsuariosRefLab`, `VacantesUsuariosDocRefLab`, `VacantesUsuariosExPsi`, `VacantesUsuariosDocExPsi`, `VacantesUsuariosCVRec`, `VacantesUsuariosDocCVRec` FROM `VacantesUsuariosVacante` WHERE `Vacantes_Id` = ? and `UsuariosId` = ? ORDER BY `Vacantes_Id`, `UsuariosId` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001S2,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((String[]) buf[4])[0] = rslt.getVarchar(4) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((short[]) buf[6])[0] = rslt.getShort(5) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((String[]) buf[8])[0] = rslt.getVarchar(6) ;
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((short[]) buf[10])[0] = rslt.getShort(7) ;
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((String[]) buf[12])[0] = rslt.getVarchar(8) ;
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((short[]) buf[14])[0] = rslt.getShort(9) ;
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((String[]) buf[16])[0] = rslt.getVarchar(10) ;
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((short[]) buf[18])[0] = rslt.getShort(11) ;
                ((bool[]) buf[19])[0] = rslt.wasNull(11);
                ((String[]) buf[20])[0] = rslt.getVarchar(12) ;
                ((bool[]) buf[21])[0] = rslt.wasNull(12);
                ((short[]) buf[22])[0] = rslt.getShort(13) ;
                ((bool[]) buf[23])[0] = rslt.wasNull(13);
                ((String[]) buf[24])[0] = rslt.getVarchar(14) ;
                ((bool[]) buf[25])[0] = rslt.wasNull(14);
                ((short[]) buf[26])[0] = rslt.getShort(15) ;
                ((bool[]) buf[27])[0] = rslt.wasNull(15);
                ((String[]) buf[28])[0] = rslt.getVarchar(16) ;
                ((bool[]) buf[29])[0] = rslt.wasNull(16);
                ((short[]) buf[30])[0] = rslt.getShort(17) ;
                ((bool[]) buf[31])[0] = rslt.wasNull(17);
                ((String[]) buf[32])[0] = rslt.getVarchar(18) ;
                ((bool[]) buf[33])[0] = rslt.wasNull(18);
                ((short[]) buf[34])[0] = rslt.getShort(19) ;
                ((bool[]) buf[35])[0] = rslt.wasNull(19);
                ((String[]) buf[36])[0] = rslt.getVarchar(20) ;
                ((bool[]) buf[37])[0] = rslt.wasNull(20);
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
                stmt.SetParameter(2, (int)parms[1]);
                return;
       }
    }

 }

}
