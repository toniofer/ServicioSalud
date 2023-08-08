/*
               File: DPEstadisticas
        Description: DPEstadisticas
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/24/2010 5:52:5.75
       Program type: Callable routine
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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Data.SqlTypes;
namespace GeneXus.Programs {
   public class dpestadisticas : GXProcedure
   {
      public dpestadisticas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
      }

      public dpestadisticas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default") ;
      }

      public void release( )
      {
      }

      public void execute( DateTime aP0_FechaDesde ,
                           DateTime aP1_FechaHasta ,
                           out SdtEstadisticasSDT aP2_Gxm1estadisticassdt )
      {
         this.AV5FechaDesde = aP0_FechaDesde;
         this.AV6FechaHasta = aP1_FechaHasta;
         this.Gxm1estadisticassdt = new SdtEstadisticasSDT(context) ;
         initialize();
         executePrivate();
         aP2_Gxm1estadisticassdt=this.Gxm1estadisticassdt;
      }

      public SdtEstadisticasSDT executeUdp( DateTime aP0_FechaDesde ,
                                            DateTime aP1_FechaHasta )
      {
         this.AV5FechaDesde = aP0_FechaDesde;
         this.AV6FechaHasta = aP1_FechaHasta;
         this.Gxm1estadisticassdt = new SdtEstadisticasSDT(context) ;
         initialize();
         executePrivate();
         aP2_Gxm1estadisticassdt=this.Gxm1estadisticassdt;
         return Gxm1estadisticassdt ;
      }

      public void executeSubmit( DateTime aP0_FechaDesde ,
                                 DateTime aP1_FechaHasta ,
                                 out SdtEstadisticasSDT aP2_Gxm1estadisticassdt )
      {
         dpestadisticas objdpestadisticas;
         objdpestadisticas = new dpestadisticas();
         objdpestadisticas.AV5FechaDesde = aP0_FechaDesde;
         objdpestadisticas.AV6FechaHasta = aP1_FechaHasta;
         objdpestadisticas.Gxm1estadisticassdt = new SdtEstadisticasSDT(context) ;
         objdpestadisticas.initialize();
         ThreadPool.QueueUserWorkItem( new WaitCallback( objdpestadisticas.executePrivateCatch ));
         aP2_Gxm1estadisticassdt=this.Gxm1estadisticassdt;
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
         Gxm1estadisticassdt.gxTpr_Fechadesde = AV5FechaDesde ;
         Gxm1estadisticassdt.gxTpr_Fechahasta = AV6FechaHasta ;
         /* Using cursor P00042 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A9EspecialidadId = P00042_A9EspecialidadId[0] ;
            A10EspecialidadDescripcion = P00042_A10EspecialidadDescripcion[0] ;
            Gxm2estadisticassdt_especialidad = new SdtEstadisticasSDT_EspecialidadItem(context) ;
            Gxm1estadisticassdt.gxTpr_Especialidad.Add(Gxm2estadisticassdt_especialidad, 0);
            Gxm2estadisticassdt_especialidad.gxTpr_Especialidad = A10EspecialidadDescripcion ;
            /* Using cursor P00045 */
            pr_default.execute(1, new Object[] {A9EspecialidadId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A12MedicoId = P00045_A12MedicoId[0] ;
               A14MedicoApellido = P00045_A14MedicoApellido[0] ;
               A13MedicoNombre = P00045_A13MedicoNombre[0] ;
               A40000GXC1 = P00045_A40000GXC1[0] ;
               A40001GXC2 = P00045_A40001GXC2[0] ;
               A40000GXC1 = P00045_A40000GXC1[0] ;
               A40001GXC2 = P00045_A40001GXC2[0] ;
               Gxm3estadisticassdt_especialidad_medico = new SdtEstadisticasSDT_EspecialidadItem_MedicoItem(context) ;
               Gxm2estadisticassdt_especialidad.gxTpr_Medico.Add(Gxm3estadisticassdt_especialidad_medico, 0);
               Gxm3estadisticassdt_especialidad_medico.gxTpr_Medicoapellido = A14MedicoApellido ;
               Gxm3estadisticassdt_especialidad_medico.gxTpr_Mediconombre = A13MedicoNombre ;
               Gxm3estadisticassdt_especialidad_medico.gxTpr_Cantconsultas = (short)(A40000GXC1) ;
               Gxm3estadisticassdt_especialidad_medico.gxTpr_Cantpacatendidos = A40001GXC2 ;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         this.cleanup();
      }

      protected void cleanup( )
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
         scmdbuf = "" ;
         P00042_A9EspecialidadId = new int[1] ;
         P00042_A10EspecialidadDescripcion = new String[] {""} ;
         A10EspecialidadDescripcion = "" ;
         Gxm2estadisticassdt_especialidad = new SdtEstadisticasSDT_EspecialidadItem(context);
         P00045_A12MedicoId = new int[1] ;
         P00045_A9EspecialidadId = new int[1] ;
         P00045_A14MedicoApellido = new String[] {""} ;
         P00045_A13MedicoNombre = new String[] {""} ;
         P00045_A40000GXC1 = new int[1] ;
         P00045_A40001GXC2 = new short[1] ;
         A14MedicoApellido = "" ;
         A13MedicoNombre = "" ;
         Gxm3estadisticassdt_especialidad_medico = new SdtEstadisticasSDT_EspecialidadItem_MedicoItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpestadisticas__default(),
            new Object[][] {
                new Object[] {
               P00042_A9EspecialidadId, P00042_A10EspecialidadDescripcion
               }
               , new Object[] {
               P00045_A12MedicoId, P00045_A9EspecialidadId, P00045_A14MedicoApellido, P00045_A13MedicoNombre, P00045_A40000GXC1, P00045_A40001GXC2
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0 ;
      }

      private short A40001GXC2 ;
      private int A9EspecialidadId ;
      private int A12MedicoId ;
      private int A40000GXC1 ;
      private String scmdbuf ;
      private String A10EspecialidadDescripcion ;
      private String A14MedicoApellido ;
      private String A13MedicoNombre ;
      private DateTime AV5FechaDesde ;
      private DateTime AV6FechaHasta ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00042_A9EspecialidadId ;
      private String[] P00042_A10EspecialidadDescripcion ;
      private int[] P00045_A12MedicoId ;
      private int[] P00045_A9EspecialidadId ;
      private String[] P00045_A14MedicoApellido ;
      private String[] P00045_A13MedicoNombre ;
      private int[] P00045_A40000GXC1 ;
      private short[] P00045_A40001GXC2 ;
      private SdtEstadisticasSDT aP2_Gxm1estadisticassdt ;
      private SdtEstadisticasSDT Gxm1estadisticassdt ;
      private SdtEstadisticasSDT_EspecialidadItem Gxm2estadisticassdt_especialidad ;
      private SdtEstadisticasSDT_EspecialidadItem_MedicoItem Gxm3estadisticassdt_especialidad_medico ;
   }

   public class dpestadisticas__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00042 ;
          prmP00042 = new Object[] {
          } ;
          Object[] prmP00045 ;
          prmP00045 = new Object[] {
          new Object[] {"@EspecialidadId",SqlDbType.Int,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P00042", "SELECT [EspecialidadId], [EspecialidadDescripcion] FROM [Especialidad] WITH (NOLOCK) ORDER BY [EspecialidadId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00042,100,0,true,false )
             ,new CursorDef("P00045", "SELECT T1.[MedicoId], T1.[EspecialidadId], T1.[MedicoApellido], T1.[MedicoNombre], COALESCE( T2.[GXC1], 0) AS GXC1, COALESCE( T2.[GXC2], 0) AS GXC2 FROM ([Medico] T1 WITH (NOLOCK) LEFT JOIN (SELECT COUNT(*) AS GXC1, T3.[MedicoId], SUM(COALESCE( T4.[CantPacConf], 0)) AS GXC2 FROM ([Consulta] T3 WITH (NOLOCK) LEFT JOIN (SELECT COUNT(*) AS CantPacConf, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) WHERE [Confirmado] = 1 GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T4 ON T4.[ConsultaFecha] = T3.[ConsultaFecha] AND T4.[MedicoId] = T3.[MedicoId] AND T4.[TurnoId] = T3.[TurnoId]) GROUP BY T3.[MedicoId] ) T2 ON T2.[MedicoId] = T1.[MedicoId]) WHERE T1.[EspecialidadId] = @EspecialidadId ORDER BY T1.[EspecialidadId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00045,100,0,false,false )
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
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                break;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                ((String[]) buf[3])[0] = rslt.getString(4, 20) ;
                ((int[]) buf[4])[0] = rslt.getInt(5) ;
                ((short[]) buf[5])[0] = rslt.getShort(6) ;
                break;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
             case 1 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
       }
    }

 }

}
