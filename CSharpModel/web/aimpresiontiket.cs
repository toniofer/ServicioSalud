/*
               File: ImpresionTiket
        Description: Impresion Tiket
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/24/2010 5:12:56.38
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
   public class aimpresiontiket : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
               A43ConsultaFecha = context.localUtil.ParseDateParm( gxfirstwebparm) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  A34PacienteId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  A12MedicoId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  A60TurnoId = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
               }
            }
         }
         executePrivate();
         cleanup();
      }

      public aimpresiontiket( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public aimpresiontiket( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default") ;
      }

      public void release( )
      {
      }

      public void execute( ref DateTime aP0_ConsultaFecha ,
                           ref int aP1_PacienteId ,
                           ref int aP2_MedicoId ,
                           ref short aP3_TurnoId )
      {
         this.A43ConsultaFecha = aP0_ConsultaFecha;
         this.A34PacienteId = aP1_PacienteId;
         this.A12MedicoId = aP2_MedicoId;
         this.A60TurnoId = aP3_TurnoId;
         initialize();
         executePrivate();
         aP0_ConsultaFecha=this.A43ConsultaFecha;
         aP1_PacienteId=this.A34PacienteId;
         aP2_MedicoId=this.A12MedicoId;
         aP3_TurnoId=this.A60TurnoId;
      }

      public short executeUdp( ref DateTime aP0_ConsultaFecha ,
                               ref int aP1_PacienteId ,
                               ref int aP2_MedicoId )
      {
         this.A43ConsultaFecha = aP0_ConsultaFecha;
         this.A34PacienteId = aP1_PacienteId;
         this.A12MedicoId = aP2_MedicoId;
         this.A60TurnoId = aP3_TurnoId;
         initialize();
         executePrivate();
         aP0_ConsultaFecha=this.A43ConsultaFecha;
         aP1_PacienteId=this.A34PacienteId;
         aP2_MedicoId=this.A12MedicoId;
         aP3_TurnoId=this.A60TurnoId;
         return A60TurnoId ;
      }

      public void executeSubmit( ref DateTime aP0_ConsultaFecha ,
                                 ref int aP1_PacienteId ,
                                 ref int aP2_MedicoId ,
                                 ref short aP3_TurnoId )
      {
         aimpresiontiket objaimpresiontiket;
         objaimpresiontiket = new aimpresiontiket();
         objaimpresiontiket.A43ConsultaFecha = aP0_ConsultaFecha;
         objaimpresiontiket.A34PacienteId = aP1_PacienteId;
         objaimpresiontiket.A12MedicoId = aP2_MedicoId;
         objaimpresiontiket.A60TurnoId = aP3_TurnoId;
         objaimpresiontiket.initialize();
         ThreadPool.QueueUserWorkItem( new WaitCallback( objaimpresiontiket.executePrivateCatch ));
         aP0_ConsultaFecha=this.A43ConsultaFecha;
         aP1_PacienteId=this.A34PacienteId;
         aP2_MedicoId=this.A12MedicoId;
         aP3_TurnoId=this.A60TurnoId;
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
            /* Using cursor P000D2 */
            pr_default.execute(0, new Object[] {A43ConsultaFecha, A34PacienteId, A12MedicoId, A60TurnoId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A61TurnoNombre = P000D2_A61TurnoNombre[0] ;
               A63ConsultaNro = P000D2_A63ConsultaNro[0] ;
               n63ConsultaNro = P000D2_n63ConsultaNro[0] ;
               A13MedicoNombre = P000D2_A13MedicoNombre[0] ;
               A14MedicoApellido = P000D2_A14MedicoApellido[0] ;
               A35PacienteNombre = P000D2_A35PacienteNombre[0] ;
               A36PacienteApellido = P000D2_A36PacienteApellido[0] ;
               A35PacienteNombre = P000D2_A35PacienteNombre[0] ;
               A36PacienteApellido = P000D2_A36PacienteApellido[0] ;
               A13MedicoNombre = P000D2_A13MedicoNombre[0] ;
               A14MedicoApellido = P000D2_A14MedicoApellido[0] ;
               A61TurnoNombre = P000D2_A61TurnoNombre[0] ;
               H0D0( false, 101) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A36PacienteApellido, "XXXXXXXXXXXXXXXXXXXX")), 92, Gx_line+17, 197, Gx_line+33, 0+256) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A35PacienteNombre, "XXXXXXXXXXXXXXXXXXXX")), 200, Gx_line+17, 305, Gx_line+33, 0+256) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A14MedicoApellido, "XXXXXXXXXXXXXXXXXXXX")), 500, Gx_line+17, 605, Gx_line+33, 0+256) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A13MedicoNombre, "XXXXXXXXXXXXXXXXXXXX")), 608, Gx_line+17, 713, Gx_line+33, 0+256) ;
               getPrinter().GxDrawText(context.localUtil.Format( A43ConsultaFecha, "99/99/99"), 83, Gx_line+50, 132, Gx_line+66, 2+256) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A63ConsultaNro), "Z9")), 517, Gx_line+50, 531, Gx_line+66, 2+256) ;
               getPrinter().GxDrawText("Paciente:", 25, Gx_line+17, 73, Gx_line+32, 0+256) ;
               getPrinter().GxDrawText("Médico", 375, Gx_line+17, 446, Gx_line+32, 0) ;
               getPrinter().GxDrawText("Fecha:", 17, Gx_line+50, 52, Gx_line+65, 0+256) ;
               getPrinter().GxDrawText("Turno", 233, Gx_line+50, 263, Gx_line+65, 0+256) ;
               getPrinter().GxDrawText("Nro. Consulta:", 433, Gx_line+50, 504, Gx_line+65, 0+256) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A61TurnoNombre, "XXXXXXXXXXXXXXXXXXXX")), 292, Gx_line+50, 397, Gx_line+66, 0+256) ;
               Gx_OldLine = Gx_line ;
               Gx_line = (int)(Gx_line+101) ;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1) ;
            H0D0( true, 0) ;
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

      protected void H0D0( bool bFoot ,
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
         P000D2_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         P000D2_A34PacienteId = new int[1] ;
         P000D2_A12MedicoId = new int[1] ;
         P000D2_A60TurnoId = new short[1] ;
         P000D2_A61TurnoNombre = new String[] {""} ;
         P000D2_A63ConsultaNro = new short[1] ;
         P000D2_n63ConsultaNro = new bool[] {false} ;
         P000D2_A13MedicoNombre = new String[] {""} ;
         P000D2_A14MedicoApellido = new String[] {""} ;
         P000D2_A35PacienteNombre = new String[] {""} ;
         P000D2_A36PacienteApellido = new String[] {""} ;
         A61TurnoNombre = "" ;
         A13MedicoNombre = "" ;
         A14MedicoApellido = "" ;
         A35PacienteNombre = "" ;
         A36PacienteApellido = "" ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aimpresiontiket__default(),
            new Object[][] {
                new Object[] {
               P000D2_A43ConsultaFecha, P000D2_A34PacienteId, P000D2_A12MedicoId, P000D2_A60TurnoId, P000D2_A61TurnoNombre, P000D2_A63ConsultaNro, P000D2_n63ConsultaNro, P000D2_A13MedicoNombre, P000D2_A14MedicoApellido, P000D2_A35PacienteNombre,
               P000D2_A36PacienteApellido
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0 ;
         context.Gx_err = 0 ;
      }

      private short nGotPars ;
      private short A60TurnoId ;
      private short A63ConsultaNro ;
      private int A34PacienteId ;
      private int A12MedicoId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private String gxfirstwebparm ;
      private String scmdbuf ;
      private String A61TurnoNombre ;
      private String A13MedicoNombre ;
      private String A14MedicoApellido ;
      private String A35PacienteNombre ;
      private String A36PacienteApellido ;
      private DateTime A43ConsultaFecha ;
      private bool entryPointCalled ;
      private bool n63ConsultaNro ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_ConsultaFecha ;
      private int aP1_PacienteId ;
      private int aP2_MedicoId ;
      private short aP3_TurnoId ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P000D2_A43ConsultaFecha ;
      private int[] P000D2_A34PacienteId ;
      private int[] P000D2_A12MedicoId ;
      private short[] P000D2_A60TurnoId ;
      private String[] P000D2_A61TurnoNombre ;
      private short[] P000D2_A63ConsultaNro ;
      private bool[] P000D2_n63ConsultaNro ;
      private String[] P000D2_A13MedicoNombre ;
      private String[] P000D2_A14MedicoApellido ;
      private String[] P000D2_A35PacienteNombre ;
      private String[] P000D2_A36PacienteApellido ;
   }

   public class aimpresiontiket__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000D2 ;
          prmP000D2 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@PacienteId",SqlDbType.Int,6,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P000D2", "SELECT T1.[ConsultaFecha], T1.[PacienteId], T1.[MedicoId], T1.[TurnoId], T4.[TurnoNombre], T1.[ConsultaNro], T3.[MedicoNombre], T3.[MedicoApellido], T2.[PacienteNombre], T2.[PacienteApellido] FROM ((([ConsultaPaciente] T1 WITH (NOLOCK) INNER JOIN [Paciente] T2 WITH (NOLOCK) ON T2.[PacienteId] = T1.[PacienteId]) INNER JOIN [Medico] T3 WITH (NOLOCK) ON T3.[MedicoId] = T1.[MedicoId]) INNER JOIN [Turno] T4 WITH (NOLOCK) ON T4.[TurnoId] = T1.[TurnoId]) WHERE T1.[ConsultaFecha] = @ConsultaFecha and T1.[PacienteId] = @PacienteId and T1.[MedicoId] = @MedicoId and T1.[TurnoId] = @TurnoId ORDER BY T1.[ConsultaFecha], T1.[PacienteId], T1.[MedicoId], T1.[TurnoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000D2,1,0,false,true )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                ((short[]) buf[3])[0] = rslt.getShort(4) ;
                ((String[]) buf[4])[0] = rslt.getString(5, 20) ;
                ((short[]) buf[5])[0] = rslt.getShort(6) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((String[]) buf[7])[0] = rslt.getString(7, 20) ;
                ((String[]) buf[8])[0] = rslt.getString(8, 20) ;
                ((String[]) buf[9])[0] = rslt.getString(9, 20) ;
                ((String[]) buf[10])[0] = rslt.getString(10, 20) ;
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
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                stmt.SetParameter(4, (short)parms[3]);
                break;
       }
    }

 }

}
