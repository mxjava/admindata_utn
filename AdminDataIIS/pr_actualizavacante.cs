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
   public class pr_actualizavacante : GXProcedure
   {
      public pr_actualizavacante( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public pr_actualizavacante( IGxContext context )
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
                           ref String aP3_Ruta_Completa )
      {
         this.AV8UsuarioId = aP0_UsuarioId;
         this.AV9Vacantes_Id = aP1_Vacantes_Id;
         this.AV11opDoc = aP2_opDoc;
         this.AV12Ruta_Completa = aP3_Ruta_Completa;
         initialize();
         executePrivate();
         aP3_Ruta_Completa=this.AV12Ruta_Completa;
      }

      public String executeUdp( int aP0_UsuarioId ,
                                int aP1_Vacantes_Id ,
                                short aP2_opDoc )
      {
         execute(aP0_UsuarioId, aP1_Vacantes_Id, aP2_opDoc, ref aP3_Ruta_Completa);
         return AV12Ruta_Completa ;
      }

      public void executeSubmit( int aP0_UsuarioId ,
                                 int aP1_Vacantes_Id ,
                                 short aP2_opDoc ,
                                 ref String aP3_Ruta_Completa )
      {
         pr_actualizavacante objpr_actualizavacante;
         objpr_actualizavacante = new pr_actualizavacante();
         objpr_actualizavacante.AV8UsuarioId = aP0_UsuarioId;
         objpr_actualizavacante.AV9Vacantes_Id = aP1_Vacantes_Id;
         objpr_actualizavacante.AV11opDoc = aP2_opDoc;
         objpr_actualizavacante.AV12Ruta_Completa = aP3_Ruta_Completa;
         objpr_actualizavacante.context.SetSubmitInitialConfig(context);
         objpr_actualizavacante.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpr_actualizavacante);
         aP3_Ruta_Completa=this.AV12Ruta_Completa;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pr_actualizavacante)stateInfo).executePrivate();
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
         /* Using cursor P001P2 */
         pr_default.execute(0, new Object[] {AV9Vacantes_Id, AV8UsuarioId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A263Vacantes_Id = P001P2_A263Vacantes_Id[0];
            A11UsuariosId = P001P2_A11UsuariosId[0];
            A291VacantesUsuariosPrefiltro = P001P2_A291VacantesUsuariosPrefiltro[0];
            n291VacantesUsuariosPrefiltro = P001P2_n291VacantesUsuariosPrefiltro[0];
            A296VacantesUsuariosDocP = P001P2_A296VacantesUsuariosDocP[0];
            n296VacantesUsuariosDocP = P001P2_n296VacantesUsuariosDocP[0];
            A292VacantesUsuariosCV = P001P2_A292VacantesUsuariosCV[0];
            n292VacantesUsuariosCV = P001P2_n292VacantesUsuariosCV[0];
            A297VacantesUsuariosDocCV = P001P2_A297VacantesUsuariosDocCV[0];
            n297VacantesUsuariosDocCV = P001P2_n297VacantesUsuariosDocCV[0];
            A293VacantesUsuariosExTec = P001P2_A293VacantesUsuariosExTec[0];
            n293VacantesUsuariosExTec = P001P2_n293VacantesUsuariosExTec[0];
            A295VacantesUsuariosFechaE = P001P2_A295VacantesUsuariosFechaE[0];
            n295VacantesUsuariosFechaE = P001P2_n295VacantesUsuariosFechaE[0];
            A298VacantesUsuariosDocTec = P001P2_A298VacantesUsuariosDocTec[0];
            n298VacantesUsuariosDocTec = P001P2_n298VacantesUsuariosDocTec[0];
            A304VacantesUsuariosAvConf = P001P2_A304VacantesUsuariosAvConf[0];
            n304VacantesUsuariosAvConf = P001P2_n304VacantesUsuariosAvConf[0];
            A310VacantesUsuariosDocAvConf = P001P2_A310VacantesUsuariosDocAvConf[0];
            n310VacantesUsuariosDocAvConf = P001P2_n310VacantesUsuariosDocAvConf[0];
            A303VacantesUsuariosAvPriv = P001P2_A303VacantesUsuariosAvPriv[0];
            n303VacantesUsuariosAvPriv = P001P2_n303VacantesUsuariosAvPriv[0];
            A309VacantesUsuariosDocAvPriv = P001P2_A309VacantesUsuariosDocAvPriv[0];
            n309VacantesUsuariosDocAvPriv = P001P2_n309VacantesUsuariosDocAvPriv[0];
            A302VacantesUsuariosBusWeb = P001P2_A302VacantesUsuariosBusWeb[0];
            n302VacantesUsuariosBusWeb = P001P2_n302VacantesUsuariosBusWeb[0];
            A308VacantesUsuariosDocBusWeb = P001P2_A308VacantesUsuariosDocBusWeb[0];
            n308VacantesUsuariosDocBusWeb = P001P2_n308VacantesUsuariosDocBusWeb[0];
            A300VacantesUsuariosRefLab = P001P2_A300VacantesUsuariosRefLab[0];
            n300VacantesUsuariosRefLab = P001P2_n300VacantesUsuariosRefLab[0];
            A306VacantesUsuariosDocRefLab = P001P2_A306VacantesUsuariosDocRefLab[0];
            n306VacantesUsuariosDocRefLab = P001P2_n306VacantesUsuariosDocRefLab[0];
            A301VacantesUsuariosExPsi = P001P2_A301VacantesUsuariosExPsi[0];
            n301VacantesUsuariosExPsi = P001P2_n301VacantesUsuariosExPsi[0];
            A307VacantesUsuariosDocExPsi = P001P2_A307VacantesUsuariosDocExPsi[0];
            n307VacantesUsuariosDocExPsi = P001P2_n307VacantesUsuariosDocExPsi[0];
            A299VacantesUsuariosCVRec = P001P2_A299VacantesUsuariosCVRec[0];
            n299VacantesUsuariosCVRec = P001P2_n299VacantesUsuariosCVRec[0];
            A305VacantesUsuariosDocCVRec = P001P2_A305VacantesUsuariosDocCVRec[0];
            n305VacantesUsuariosDocCVRec = P001P2_n305VacantesUsuariosDocCVRec[0];
            if ( AV11opDoc == 1 )
            {
               A291VacantesUsuariosPrefiltro = 1;
               n291VacantesUsuariosPrefiltro = false;
               A296VacantesUsuariosDocP = AV12Ruta_Completa;
               n296VacantesUsuariosDocP = false;
            }
            else if ( AV11opDoc == 2 )
            {
               A292VacantesUsuariosCV = 1;
               n292VacantesUsuariosCV = false;
               A297VacantesUsuariosDocCV = AV12Ruta_Completa;
               n297VacantesUsuariosDocCV = false;
            }
            else if ( AV11opDoc == 3 )
            {
               A293VacantesUsuariosExTec = 1;
               n293VacantesUsuariosExTec = false;
               A295VacantesUsuariosFechaE = DateTimeUtil.ServerNow( context, pr_default);
               n295VacantesUsuariosFechaE = false;
               A298VacantesUsuariosDocTec = AV12Ruta_Completa;
               n298VacantesUsuariosDocTec = false;
            }
            else if ( AV11opDoc == 4 )
            {
               A304VacantesUsuariosAvConf = 1;
               n304VacantesUsuariosAvConf = false;
               A310VacantesUsuariosDocAvConf = AV12Ruta_Completa;
               n310VacantesUsuariosDocAvConf = false;
            }
            else if ( AV11opDoc == 5 )
            {
               A303VacantesUsuariosAvPriv = 1;
               n303VacantesUsuariosAvPriv = false;
               A309VacantesUsuariosDocAvPriv = AV12Ruta_Completa;
               n309VacantesUsuariosDocAvPriv = false;
            }
            else if ( AV11opDoc == 6 )
            {
               A302VacantesUsuariosBusWeb = 1;
               n302VacantesUsuariosBusWeb = false;
               A308VacantesUsuariosDocBusWeb = AV12Ruta_Completa;
               n308VacantesUsuariosDocBusWeb = false;
            }
            else if ( AV11opDoc == 7 )
            {
               A300VacantesUsuariosRefLab = 1;
               n300VacantesUsuariosRefLab = false;
               A306VacantesUsuariosDocRefLab = AV12Ruta_Completa;
               n306VacantesUsuariosDocRefLab = false;
            }
            else if ( AV11opDoc == 8 )
            {
               A301VacantesUsuariosExPsi = 1;
               n301VacantesUsuariosExPsi = false;
               A307VacantesUsuariosDocExPsi = AV12Ruta_Completa;
               n307VacantesUsuariosDocExPsi = false;
            }
            else if ( AV11opDoc == 9 )
            {
               A299VacantesUsuariosCVRec = 1;
               n299VacantesUsuariosCVRec = false;
               A305VacantesUsuariosDocCVRec = AV12Ruta_Completa;
               n305VacantesUsuariosDocCVRec = false;
            }
            /* Using cursor P001P3 */
            pr_default.execute(1, new Object[] {n291VacantesUsuariosPrefiltro, A291VacantesUsuariosPrefiltro, n296VacantesUsuariosDocP, A296VacantesUsuariosDocP, n292VacantesUsuariosCV, A292VacantesUsuariosCV, n297VacantesUsuariosDocCV, A297VacantesUsuariosDocCV, n293VacantesUsuariosExTec, A293VacantesUsuariosExTec, n295VacantesUsuariosFechaE, A295VacantesUsuariosFechaE, n298VacantesUsuariosDocTec, A298VacantesUsuariosDocTec, n304VacantesUsuariosAvConf, A304VacantesUsuariosAvConf, n310VacantesUsuariosDocAvConf, A310VacantesUsuariosDocAvConf, n303VacantesUsuariosAvPriv, A303VacantesUsuariosAvPriv, n309VacantesUsuariosDocAvPriv, A309VacantesUsuariosDocAvPriv, n302VacantesUsuariosBusWeb, A302VacantesUsuariosBusWeb, n308VacantesUsuariosDocBusWeb, A308VacantesUsuariosDocBusWeb, n300VacantesUsuariosRefLab, A300VacantesUsuariosRefLab, n306VacantesUsuariosDocRefLab, A306VacantesUsuariosDocRefLab, n301VacantesUsuariosExPsi, A301VacantesUsuariosExPsi, n307VacantesUsuariosDocExPsi, A307VacantesUsuariosDocExPsi, n299VacantesUsuariosCVRec, A299VacantesUsuariosCVRec, n305VacantesUsuariosDocCVRec, A305VacantesUsuariosDocCVRec, A263Vacantes_Id, A11UsuariosId});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("VacantesUsuariosVacante") ;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("pr_actualizavacante",pr_default);
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
         P001P2_A263Vacantes_Id = new int[1] ;
         P001P2_A11UsuariosId = new int[1] ;
         P001P2_A291VacantesUsuariosPrefiltro = new short[1] ;
         P001P2_n291VacantesUsuariosPrefiltro = new bool[] {false} ;
         P001P2_A296VacantesUsuariosDocP = new String[] {""} ;
         P001P2_n296VacantesUsuariosDocP = new bool[] {false} ;
         P001P2_A292VacantesUsuariosCV = new short[1] ;
         P001P2_n292VacantesUsuariosCV = new bool[] {false} ;
         P001P2_A297VacantesUsuariosDocCV = new String[] {""} ;
         P001P2_n297VacantesUsuariosDocCV = new bool[] {false} ;
         P001P2_A293VacantesUsuariosExTec = new short[1] ;
         P001P2_n293VacantesUsuariosExTec = new bool[] {false} ;
         P001P2_A295VacantesUsuariosFechaE = new DateTime[] {DateTime.MinValue} ;
         P001P2_n295VacantesUsuariosFechaE = new bool[] {false} ;
         P001P2_A298VacantesUsuariosDocTec = new String[] {""} ;
         P001P2_n298VacantesUsuariosDocTec = new bool[] {false} ;
         P001P2_A304VacantesUsuariosAvConf = new short[1] ;
         P001P2_n304VacantesUsuariosAvConf = new bool[] {false} ;
         P001P2_A310VacantesUsuariosDocAvConf = new String[] {""} ;
         P001P2_n310VacantesUsuariosDocAvConf = new bool[] {false} ;
         P001P2_A303VacantesUsuariosAvPriv = new short[1] ;
         P001P2_n303VacantesUsuariosAvPriv = new bool[] {false} ;
         P001P2_A309VacantesUsuariosDocAvPriv = new String[] {""} ;
         P001P2_n309VacantesUsuariosDocAvPriv = new bool[] {false} ;
         P001P2_A302VacantesUsuariosBusWeb = new short[1] ;
         P001P2_n302VacantesUsuariosBusWeb = new bool[] {false} ;
         P001P2_A308VacantesUsuariosDocBusWeb = new String[] {""} ;
         P001P2_n308VacantesUsuariosDocBusWeb = new bool[] {false} ;
         P001P2_A300VacantesUsuariosRefLab = new short[1] ;
         P001P2_n300VacantesUsuariosRefLab = new bool[] {false} ;
         P001P2_A306VacantesUsuariosDocRefLab = new String[] {""} ;
         P001P2_n306VacantesUsuariosDocRefLab = new bool[] {false} ;
         P001P2_A301VacantesUsuariosExPsi = new short[1] ;
         P001P2_n301VacantesUsuariosExPsi = new bool[] {false} ;
         P001P2_A307VacantesUsuariosDocExPsi = new String[] {""} ;
         P001P2_n307VacantesUsuariosDocExPsi = new bool[] {false} ;
         P001P2_A299VacantesUsuariosCVRec = new short[1] ;
         P001P2_n299VacantesUsuariosCVRec = new bool[] {false} ;
         P001P2_A305VacantesUsuariosDocCVRec = new String[] {""} ;
         P001P2_n305VacantesUsuariosDocCVRec = new bool[] {false} ;
         A296VacantesUsuariosDocP = "";
         A297VacantesUsuariosDocCV = "";
         A295VacantesUsuariosFechaE = (DateTime)(DateTime.MinValue);
         A298VacantesUsuariosDocTec = "";
         A310VacantesUsuariosDocAvConf = "";
         A309VacantesUsuariosDocAvPriv = "";
         A308VacantesUsuariosDocBusWeb = "";
         A306VacantesUsuariosDocRefLab = "";
         A307VacantesUsuariosDocExPsi = "";
         A305VacantesUsuariosDocCVRec = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pr_actualizavacante__default(),
            new Object[][] {
                new Object[] {
               P001P2_A263Vacantes_Id, P001P2_A11UsuariosId, P001P2_A291VacantesUsuariosPrefiltro, P001P2_n291VacantesUsuariosPrefiltro, P001P2_A296VacantesUsuariosDocP, P001P2_n296VacantesUsuariosDocP, P001P2_A292VacantesUsuariosCV, P001P2_n292VacantesUsuariosCV, P001P2_A297VacantesUsuariosDocCV, P001P2_n297VacantesUsuariosDocCV,
               P001P2_A293VacantesUsuariosExTec, P001P2_n293VacantesUsuariosExTec, P001P2_A295VacantesUsuariosFechaE, P001P2_n295VacantesUsuariosFechaE, P001P2_A298VacantesUsuariosDocTec, P001P2_n298VacantesUsuariosDocTec, P001P2_A304VacantesUsuariosAvConf, P001P2_n304VacantesUsuariosAvConf, P001P2_A310VacantesUsuariosDocAvConf, P001P2_n310VacantesUsuariosDocAvConf,
               P001P2_A303VacantesUsuariosAvPriv, P001P2_n303VacantesUsuariosAvPriv, P001P2_A309VacantesUsuariosDocAvPriv, P001P2_n309VacantesUsuariosDocAvPriv, P001P2_A302VacantesUsuariosBusWeb, P001P2_n302VacantesUsuariosBusWeb, P001P2_A308VacantesUsuariosDocBusWeb, P001P2_n308VacantesUsuariosDocBusWeb, P001P2_A300VacantesUsuariosRefLab, P001P2_n300VacantesUsuariosRefLab,
               P001P2_A306VacantesUsuariosDocRefLab, P001P2_n306VacantesUsuariosDocRefLab, P001P2_A301VacantesUsuariosExPsi, P001P2_n301VacantesUsuariosExPsi, P001P2_A307VacantesUsuariosDocExPsi, P001P2_n307VacantesUsuariosDocExPsi, P001P2_A299VacantesUsuariosCVRec, P001P2_n299VacantesUsuariosCVRec, P001P2_A305VacantesUsuariosDocCVRec, P001P2_n305VacantesUsuariosDocCVRec
               }
               , new Object[] {
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
      private DateTime A295VacantesUsuariosFechaE ;
      private bool n291VacantesUsuariosPrefiltro ;
      private bool n296VacantesUsuariosDocP ;
      private bool n292VacantesUsuariosCV ;
      private bool n297VacantesUsuariosDocCV ;
      private bool n293VacantesUsuariosExTec ;
      private bool n295VacantesUsuariosFechaE ;
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
      private String aP3_Ruta_Completa ;
      private IDataStoreProvider pr_default ;
      private int[] P001P2_A263Vacantes_Id ;
      private int[] P001P2_A11UsuariosId ;
      private short[] P001P2_A291VacantesUsuariosPrefiltro ;
      private bool[] P001P2_n291VacantesUsuariosPrefiltro ;
      private String[] P001P2_A296VacantesUsuariosDocP ;
      private bool[] P001P2_n296VacantesUsuariosDocP ;
      private short[] P001P2_A292VacantesUsuariosCV ;
      private bool[] P001P2_n292VacantesUsuariosCV ;
      private String[] P001P2_A297VacantesUsuariosDocCV ;
      private bool[] P001P2_n297VacantesUsuariosDocCV ;
      private short[] P001P2_A293VacantesUsuariosExTec ;
      private bool[] P001P2_n293VacantesUsuariosExTec ;
      private DateTime[] P001P2_A295VacantesUsuariosFechaE ;
      private bool[] P001P2_n295VacantesUsuariosFechaE ;
      private String[] P001P2_A298VacantesUsuariosDocTec ;
      private bool[] P001P2_n298VacantesUsuariosDocTec ;
      private short[] P001P2_A304VacantesUsuariosAvConf ;
      private bool[] P001P2_n304VacantesUsuariosAvConf ;
      private String[] P001P2_A310VacantesUsuariosDocAvConf ;
      private bool[] P001P2_n310VacantesUsuariosDocAvConf ;
      private short[] P001P2_A303VacantesUsuariosAvPriv ;
      private bool[] P001P2_n303VacantesUsuariosAvPriv ;
      private String[] P001P2_A309VacantesUsuariosDocAvPriv ;
      private bool[] P001P2_n309VacantesUsuariosDocAvPriv ;
      private short[] P001P2_A302VacantesUsuariosBusWeb ;
      private bool[] P001P2_n302VacantesUsuariosBusWeb ;
      private String[] P001P2_A308VacantesUsuariosDocBusWeb ;
      private bool[] P001P2_n308VacantesUsuariosDocBusWeb ;
      private short[] P001P2_A300VacantesUsuariosRefLab ;
      private bool[] P001P2_n300VacantesUsuariosRefLab ;
      private String[] P001P2_A306VacantesUsuariosDocRefLab ;
      private bool[] P001P2_n306VacantesUsuariosDocRefLab ;
      private short[] P001P2_A301VacantesUsuariosExPsi ;
      private bool[] P001P2_n301VacantesUsuariosExPsi ;
      private String[] P001P2_A307VacantesUsuariosDocExPsi ;
      private bool[] P001P2_n307VacantesUsuariosDocExPsi ;
      private short[] P001P2_A299VacantesUsuariosCVRec ;
      private bool[] P001P2_n299VacantesUsuariosCVRec ;
      private String[] P001P2_A305VacantesUsuariosDocCVRec ;
      private bool[] P001P2_n305VacantesUsuariosDocCVRec ;
   }

   public class pr_actualizavacante__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001P2 ;
          prmP001P2 = new Object[] {
          new Object[] {"AV9Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"AV8UsuarioId",System.Data.DbType.Int32,9,0}
          } ;
          Object[] prmP001P3 ;
          prmP001P3 = new Object[] {
          new Object[] {"VacantesUsuariosPrefiltro",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosDocP",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosCV",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosDocCV",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosExTec",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosFechaE",System.Data.DbType.DateTime,8,5} ,
          new Object[] {"VacantesUsuariosDocTec",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosAvConf",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosDocAvConf",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosAvPriv",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosDocAvPriv",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosBusWeb",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosDocBusWeb",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosRefLab",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosDocRefLab",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosExPsi",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosDocExPsi",System.Data.DbType.String,1000,0} ,
          new Object[] {"VacantesUsuariosCVRec",System.Data.DbType.Int16,4,0} ,
          new Object[] {"VacantesUsuariosDocCVRec",System.Data.DbType.String,1000,0} ,
          new Object[] {"Vacantes_Id",System.Data.DbType.Int32,9,0} ,
          new Object[] {"UsuariosId",System.Data.DbType.Int32,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P001P2", "SELECT `Vacantes_Id`, `UsuariosId`, `VacantesUsuariosPrefiltro`, `VacantesUsuariosDocP`, `VacantesUsuariosCV`, `VacantesUsuariosDocCV`, `VacantesUsuariosExTec`, `VacantesUsuariosFechaE`, `VacantesUsuariosDocTec`, `VacantesUsuariosAvConf`, `VacantesUsuariosDocAvConf`, `VacantesUsuariosAvPriv`, `VacantesUsuariosDocAvPriv`, `VacantesUsuariosBusWeb`, `VacantesUsuariosDocBusWeb`, `VacantesUsuariosRefLab`, `VacantesUsuariosDocRefLab`, `VacantesUsuariosExPsi`, `VacantesUsuariosDocExPsi`, `VacantesUsuariosCVRec`, `VacantesUsuariosDocCVRec` FROM `VacantesUsuariosVacante` WHERE `Vacantes_Id` = ? and `UsuariosId` = ? ORDER BY `Vacantes_Id`, `UsuariosId`  FOR UPDATE ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001P2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P001P3", "UPDATE `VacantesUsuariosVacante` SET `VacantesUsuariosPrefiltro`=?, `VacantesUsuariosDocP`=?, `VacantesUsuariosCV`=?, `VacantesUsuariosDocCV`=?, `VacantesUsuariosExTec`=?, `VacantesUsuariosFechaE`=?, `VacantesUsuariosDocTec`=?, `VacantesUsuariosAvConf`=?, `VacantesUsuariosDocAvConf`=?, `VacantesUsuariosAvPriv`=?, `VacantesUsuariosDocAvPriv`=?, `VacantesUsuariosBusWeb`=?, `VacantesUsuariosDocBusWeb`=?, `VacantesUsuariosRefLab`=?, `VacantesUsuariosDocRefLab`=?, `VacantesUsuariosExPsi`=?, `VacantesUsuariosDocExPsi`=?, `VacantesUsuariosCVRec`=?, `VacantesUsuariosDocCVRec`=?  WHERE `Vacantes_Id` = ? AND `UsuariosId` = ?", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP001P3)
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
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(8) ;
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((String[]) buf[14])[0] = rslt.getVarchar(9) ;
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((short[]) buf[16])[0] = rslt.getShort(10) ;
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((String[]) buf[18])[0] = rslt.getVarchar(11) ;
                ((bool[]) buf[19])[0] = rslt.wasNull(11);
                ((short[]) buf[20])[0] = rslt.getShort(12) ;
                ((bool[]) buf[21])[0] = rslt.wasNull(12);
                ((String[]) buf[22])[0] = rslt.getVarchar(13) ;
                ((bool[]) buf[23])[0] = rslt.wasNull(13);
                ((short[]) buf[24])[0] = rslt.getShort(14) ;
                ((bool[]) buf[25])[0] = rslt.wasNull(14);
                ((String[]) buf[26])[0] = rslt.getVarchar(15) ;
                ((bool[]) buf[27])[0] = rslt.wasNull(15);
                ((short[]) buf[28])[0] = rslt.getShort(16) ;
                ((bool[]) buf[29])[0] = rslt.wasNull(16);
                ((String[]) buf[30])[0] = rslt.getVarchar(17) ;
                ((bool[]) buf[31])[0] = rslt.wasNull(17);
                ((short[]) buf[32])[0] = rslt.getShort(18) ;
                ((bool[]) buf[33])[0] = rslt.wasNull(18);
                ((String[]) buf[34])[0] = rslt.getVarchar(19) ;
                ((bool[]) buf[35])[0] = rslt.wasNull(19);
                ((short[]) buf[36])[0] = rslt.getShort(20) ;
                ((bool[]) buf[37])[0] = rslt.wasNull(20);
                ((String[]) buf[38])[0] = rslt.getVarchar(21) ;
                ((bool[]) buf[39])[0] = rslt.wasNull(21);
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
             case 1 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(1, (short)parms[1]);
                }
                if ( (bool)parms[2] )
                {
                   stmt.setNull( 2 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(2, (String)parms[3]);
                }
                if ( (bool)parms[4] )
                {
                   stmt.setNull( 3 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(3, (short)parms[5]);
                }
                if ( (bool)parms[6] )
                {
                   stmt.setNull( 4 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(4, (String)parms[7]);
                }
                if ( (bool)parms[8] )
                {
                   stmt.setNull( 5 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(5, (short)parms[9]);
                }
                if ( (bool)parms[10] )
                {
                   stmt.setNull( 6 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameterDatetime(6, (DateTime)parms[11]);
                }
                if ( (bool)parms[12] )
                {
                   stmt.setNull( 7 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(7, (String)parms[13]);
                }
                if ( (bool)parms[14] )
                {
                   stmt.setNull( 8 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(8, (short)parms[15]);
                }
                if ( (bool)parms[16] )
                {
                   stmt.setNull( 9 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(9, (String)parms[17]);
                }
                if ( (bool)parms[18] )
                {
                   stmt.setNull( 10 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(10, (short)parms[19]);
                }
                if ( (bool)parms[20] )
                {
                   stmt.setNull( 11 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(11, (String)parms[21]);
                }
                if ( (bool)parms[22] )
                {
                   stmt.setNull( 12 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(12, (short)parms[23]);
                }
                if ( (bool)parms[24] )
                {
                   stmt.setNull( 13 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(13, (String)parms[25]);
                }
                if ( (bool)parms[26] )
                {
                   stmt.setNull( 14 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(14, (short)parms[27]);
                }
                if ( (bool)parms[28] )
                {
                   stmt.setNull( 15 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(15, (String)parms[29]);
                }
                if ( (bool)parms[30] )
                {
                   stmt.setNull( 16 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(16, (short)parms[31]);
                }
                if ( (bool)parms[32] )
                {
                   stmt.setNull( 17 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(17, (String)parms[33]);
                }
                if ( (bool)parms[34] )
                {
                   stmt.setNull( 18 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(18, (short)parms[35]);
                }
                if ( (bool)parms[36] )
                {
                   stmt.setNull( 19 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(19, (String)parms[37]);
                }
                stmt.SetParameter(20, (int)parms[38]);
                stmt.SetParameter(21, (int)parms[39]);
                return;
       }
    }

 }

}
