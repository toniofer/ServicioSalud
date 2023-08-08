/*
               File: ListarMedicos
        Description: Listar Medicos
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/24/2010 5:52:5.17
       Program type: Main program
          Main DBMS: sqlserver
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using System.Data;
using System.Data.SqlClient;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using System.Runtime.Remoting;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Data.SqlTypes;
namespace GeneXus.Programs {
   public class alistarmedicos : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetTheme("GeneXusX");
         initialize();
         if ( nGotPars == 0 )
         {
            entryPointCalled = false ;
            gxfirstwebparm = GetNextPar( ) ;
            if ( ! entryPointCalled )
            {
               AV8desde = context.localUtil.ParseDateParm( gxfirstwebparm) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV9hasta = context.localUtil.ParseDateParm( GetNextPar( )) ;
               }
            }
         }
         executePrivate();
         cleanup();
      }

      public alistarmedicos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public alistarmedicos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default") ;
      }

      public void release( )
      {
      }

      public void execute( DateTime aP0_desde ,
                           DateTime aP1_hasta )
      {
         this.AV8desde = aP0_desde;
         this.AV9hasta = aP1_hasta;
         initialize();
         executePrivate();
      }

      public void executeSubmit( DateTime aP0_desde ,
                                 DateTime aP1_hasta )
      {
         alistarmedicos objalistarmedicos;
         objalistarmedicos = new alistarmedicos();
         objalistarmedicos.AV8desde = aP0_desde;
         objalistarmedicos.AV9hasta = aP1_hasta;
         objalistarmedicos.initialize();
         ThreadPool.QueueUserWorkItem( new WaitCallback( objalistarmedicos.executePrivateCatch ));
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            executePrivate();
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
         M_top = 0 ;
         M_bot = 6 ;
         P_lines = (int)(66-M_bot) ;
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15 ;
         PrtOffset = 0 ;
         gxXPage = 100 ;
         gxYPage = 100 ;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6)) ;
            Gx_line = (int)(P_lines+1) ;
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            H0E0( false, 61) ;
            getPrinter().GxDrawLine(17, Gx_line+50, 742, Gx_line+50, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("MEDICOS CON CONSULTAS DESDE:", 17, Gx_line+17, 217, Gx_line+32, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV8desde, "99/99/99"), 242, Gx_line+17, 291, Gx_line+33, 2+256) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV9hasta, "99/99/99"), 442, Gx_line+17, 491, Gx_line+33, 2+256) ;
            getPrinter().GxDrawText("HASTA:", 350, Gx_line+17, 392, Gx_line+32, 0+256) ;
            Gx_OldLine = Gx_line ;
            Gx_line = (int)(Gx_line+61) ;
            /* Using cursor P000E4 */
            pr_default.execute(0, new Object[] {AV8desde, AV9hasta});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRK0E2 = false ;
               A60TurnoId = P000E4_A60TurnoId[0] ;
               A43ConsultaFecha = P000E4_A43ConsultaFecha[0] ;
               A13MedicoNombre = P000E4_A13MedicoNombre[0] ;
               A14MedicoApellido = P000E4_A14MedicoApellido[0] ;
               A9EspecialidadId = P000E4_A9EspecialidadId[0] ;
               A12MedicoId = P000E4_A12MedicoId[0] ;
               A10EspecialidadDescripcion = P000E4_A10EspecialidadDescripcion[0] ;
               A70CantPacConf = P000E4_A70CantPacConf[0] ;
               n70CantPacConf = P000E4_n70CantPacConf[0] ;
               A66CantNrosAsig = P000E4_A66CantNrosAsig[0] ;
               n66CantNrosAsig = P000E4_n66CantNrosAsig[0] ;
               A13MedicoNombre = P000E4_A13MedicoNombre[0] ;
               A14MedicoApellido = P000E4_A14MedicoApellido[0] ;
               A9EspecialidadId = P000E4_A9EspecialidadId[0] ;
               A10EspecialidadDescripcion = P000E4_A10EspecialidadDescripcion[0] ;
               A70CantPacConf = P000E4_A70CantPacConf[0] ;
               n70CantPacConf = P000E4_n70CantPacConf[0] ;
               A66CantNrosAsig = P000E4_A66CantNrosAsig[0] ;
               n66CantNrosAsig = P000E4_n66CantNrosAsig[0] ;
               H0E0( false, 72) ;
               getPrinter().GxDrawLine(17, Gx_line+0, 742, Gx_line+0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(17, Gx_line+50, 750, Gx_line+50, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A10EspecialidadDescripcion, "XXXXXXXXXXXXXXXXXXXX")), 150, Gx_line+17, 255, Gx_line+33, 0+256) ;
               getPrinter().GxDrawText("ESPECIALIDAD:", 50, Gx_line+17, 134, Gx_line+32, 0+256) ;
               Gx_OldLine = Gx_line ;
               Gx_line = (int)(Gx_line+72) ;
               while ( (pr_default.getStatus(0) != 101) && ( P000E4_A9EspecialidadId[0] == A9EspecialidadId ) )
               {
                  BRK0E2 = false ;
                  A60TurnoId = P000E4_A60TurnoId[0] ;
                  A43ConsultaFecha = P000E4_A43ConsultaFecha[0] ;
                  A13MedicoNombre = P000E4_A13MedicoNombre[0] ;
                  A14MedicoApellido = P000E4_A14MedicoApellido[0] ;
                  A12MedicoId = P000E4_A12MedicoId[0] ;
                  A70CantPacConf = P000E4_A70CantPacConf[0] ;
                  n70CantPacConf = P000E4_n70CantPacConf[0] ;
                  A13MedicoNombre = P000E4_A13MedicoNombre[0] ;
                  A14MedicoApellido = P000E4_A14MedicoApellido[0] ;
                  A70CantPacConf = P000E4_A70CantPacConf[0] ;
                  n70CantPacConf = P000E4_n70CantPacConf[0] ;
                  W9EspecialidadId = A9EspecialidadId ;
                  AV10CantConsult = 0 ;
                  AV11CantPac = 0 ;
                  while ( (pr_default.getStatus(0) != 101) && ( P000E4_A9EspecialidadId[0] == A9EspecialidadId ) && ( P000E4_A12MedicoId[0] == A12MedicoId ) )
                  {
                     BRK0E2 = false ;
                     A60TurnoId = P000E4_A60TurnoId[0] ;
                     A43ConsultaFecha = P000E4_A43ConsultaFecha[0] ;
                     A13MedicoNombre = P000E4_A13MedicoNombre[0] ;
                     A14MedicoApellido = P000E4_A14MedicoApellido[0] ;
                     A70CantPacConf = P000E4_A70CantPacConf[0] ;
                     n70CantPacConf = P000E4_n70CantPacConf[0] ;
                     A13MedicoNombre = P000E4_A13MedicoNombre[0] ;
                     A14MedicoApellido = P000E4_A14MedicoApellido[0] ;
                     A70CantPacConf = P000E4_A70CantPacConf[0] ;
                     n70CantPacConf = P000E4_n70CantPacConf[0] ;
                     H0E0( false, 51) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A12MedicoId), "ZZZZZ9")), 108, Gx_line+17, 147, Gx_line+33, 2+256) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A14MedicoApellido, "XXXXXXXXXXXXXXXXXXXX")), 167, Gx_line+17, 259, Gx_line+35, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A13MedicoNombre, "XXXXXXXXXXXXXXXXXXXX")), 267, Gx_line+17, 372, Gx_line+33, 0+256) ;
                     getPrinter().GxDrawText("MÉDICO:", 42, Gx_line+17, 90, Gx_line+32, 0+256) ;
                     getPrinter().GxDrawText(context.localUtil.Format( A43ConsultaFecha, "99/99/99"), 392, Gx_line+17, 450, Gx_line+33, 2) ;
                     Gx_OldLine = Gx_line ;
                     Gx_line = (int)(Gx_line+51) ;
                     AV10CantConsult = (short)(AV10CantConsult+1) ;
                     AV11CantPac = (short)(AV11CantPac+A70CantPacConf) ;
                     BRK0E2 = true ;
                     pr_default.readNext(0);
                  }
                  H0E0( false, 52) ;
                  getPrinter().GxDrawLine(17, Gx_line+50, 742, Gx_line+50, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV10CantConsult), "ZZZ9")), 183, Gx_line+17, 209, Gx_line+33, 2+256) ;
                  getPrinter().GxDrawText("CANTIDAD DE CONSULTAS:", 8, Gx_line+17, 159, Gx_line+32, 0+256) ;
                  getPrinter().GxDrawText("CANTIDAD DE PACIENTES CONFIRMADOS:", 250, Gx_line+17, 481, Gx_line+32, 0+256) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV11CantPac), "ZZZ9")), 517, Gx_line+17, 543, Gx_line+33, 2+256) ;
                  Gx_OldLine = Gx_line ;
                  Gx_line = (int)(Gx_line+52) ;
                  A9EspecialidadId = W9EspecialidadId ;
                  if ( ! BRK0E2 )
                  {
                     BRK0E2 = true ;
                     pr_default.readNext(0);
                  }
               }
               if ( ! BRK0E2 )
               {
                  BRK0E2 = true ;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1) ;
            H0E0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException e )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException e )
            {
            }
            endPrinter();
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "" ;
         }
         this.cleanup();
      }

      protected void H0E0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines ;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0 ;
               Gx_line = 0 ;
               Gx_page = (int)(Gx_page+1) ;
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight)) ;
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0 ;
               context.skipLines( 1 );
               Gx_line = (int)(Gx_line+1) ;
            }
            ToSkip = (int)(ToSkip-1) ;
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 36, 48, 14, 36, 21, 64, 36, 36, 21, 64, 43, 21, 64, 48, 39, 48, 48, 14, 14, 21, 21, 22, 36, 64, 20, 64, 32, 21, 60, 48, 31, 43, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 18, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      protected void cleanup( )
      {
         CloseOpenCursors();
         if (IsMain)	waitPrinterEnd();
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
         gxfirstwebparm = "" ;
         scmdbuf = "" ;
         P000E4_A60TurnoId = new short[1] ;
         P000E4_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         P000E4_A13MedicoNombre = new String[] {""} ;
         P000E4_A14MedicoApellido = new String[] {""} ;
         P000E4_A9EspecialidadId = new int[1] ;
         P000E4_A12MedicoId = new int[1] ;
         P000E4_A10EspecialidadDescripcion = new String[] {""} ;
         P000E4_A70CantPacConf = new short[1] ;
         P000E4_n70CantPacConf = new bool[] {false} ;
         P000E4_A66CantNrosAsig = new short[1] ;
         P000E4_n66CantNrosAsig = new bool[] {false} ;
         A43ConsultaFecha = DateTime.MinValue ;
         A13MedicoNombre = "" ;
         A14MedicoApellido = "" ;
         A10EspecialidadDescripcion = "" ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.alistarmedicos__default(),
            new Object[][] {
                new Object[] {
               P000E4_A60TurnoId, P000E4_A43ConsultaFecha, P000E4_A13MedicoNombre, P000E4_A14MedicoApellido, P000E4_A9EspecialidadId, P000E4_A12MedicoId, P000E4_A10EspecialidadDescripcion, P000E4_A70CantPacConf, P000E4_n70CantPacConf, P000E4_A66CantNrosAsig,
               P000E4_n66CantNrosAsig
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0 ;
         context.Gx_err = 0 ;
      }

      private short nGotPars ;
      private short A60TurnoId ;
      private short A70CantPacConf ;
      private short A66CantNrosAsig ;
      private short AV10CantConsult ;
      private short AV11CantPac ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A9EspecialidadId ;
      private int A12MedicoId ;
      private int W9EspecialidadId ;
      private String gxfirstwebparm ;
      private String scmdbuf ;
      private String A13MedicoNombre ;
      private String A14MedicoApellido ;
      private String A10EspecialidadDescripcion ;
      private DateTime AV8desde ;
      private DateTime AV9hasta ;
      private DateTime A43ConsultaFecha ;
      private bool entryPointCalled ;
      private bool BRK0E2 ;
      private bool n70CantPacConf ;
      private bool n66CantNrosAsig ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000E4_A60TurnoId ;
      private DateTime[] P000E4_A43ConsultaFecha ;
      private String[] P000E4_A13MedicoNombre ;
      private String[] P000E4_A14MedicoApellido ;
      private int[] P000E4_A9EspecialidadId ;
      private int[] P000E4_A12MedicoId ;
      private String[] P000E4_A10EspecialidadDescripcion ;
      private short[] P000E4_A70CantPacConf ;
      private bool[] P000E4_n70CantPacConf ;
      private short[] P000E4_A66CantNrosAsig ;
      private bool[] P000E4_n66CantNrosAsig ;
   }

   public class alistarmedicos__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000E4 ;
          prmP000E4 = new Object[] {
          new Object[] {"@AV8desde",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV9hasta",SqlDbType.DateTime,8,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P000E4", "SELECT T1.[TurnoId], T1.[ConsultaFecha], T2.[MedicoNombre], T2.[MedicoApellido], T2.[EspecialidadId], T1.[MedicoId], T3.[EspecialidadDescripcion], COALESCE( T4.[CantPacConf], 0) AS CantPacConf, COALESCE( T5.[CantNrosAsig], 0) AS CantNrosAsig FROM (((([Consulta] T1 WITH (NOLOCK) INNER JOIN [Medico] T2 WITH (NOLOCK) ON T2.[MedicoId] = T1.[MedicoId]) INNER JOIN [Especialidad] T3 WITH (NOLOCK) ON T3.[EspecialidadId] = T2.[EspecialidadId]) LEFT JOIN (SELECT COUNT(*) AS CantPacConf, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) WHERE [Confirmado] = 1 GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T4 ON T4.[ConsultaFecha] = T1.[ConsultaFecha] AND T4.[MedicoId] = T1.[MedicoId] AND T4.[TurnoId] = T1.[TurnoId]) LEFT JOIN (SELECT COUNT(*) AS CantNrosAsig, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T5 ON T5.[ConsultaFecha] = T1.[ConsultaFecha] AND T5.[MedicoId] = T1.[MedicoId] AND T5.[TurnoId] = T1.[TurnoId]) WHERE (T1.[ConsultaFecha] >= @AV8desde) AND (T1.[ConsultaFecha] <= @AV9hasta) ORDER BY T2.[EspecialidadId], T1.[MedicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000E4,100,0,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                ((String[]) buf[3])[0] = rslt.getString(4, 20) ;
                ((int[]) buf[4])[0] = rslt.getInt(5) ;
                ((int[]) buf[5])[0] = rslt.getInt(6) ;
                ((String[]) buf[6])[0] = rslt.getString(7, 20) ;
                ((short[]) buf[7])[0] = rslt.getShort(8) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((short[]) buf[9])[0] = rslt.getShort(9) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                break;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
             case 0 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (DateTime)parms[1]);
                break;
       }
    }

 }

}
