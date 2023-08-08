/*
               File: TurnoOcupado
        Description: Turno Ocupado
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/24/2010 5:13:43.63
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
   public class turnoocupado : GXProcedure
   {
      public turnoocupado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public turnoocupado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default") ;
      }

      public void release( )
      {
      }

      public void execute( DateTime aP0_ConsultaFechaX ,
                           short aP1_TurnoIdX ,
                           int aP2_MedicoIdX ,
                           out bool aP3_TurnoOcupado )
      {
         this.AV8ConsultaFechaX = aP0_ConsultaFechaX;
         this.AV11TurnoIdX = aP1_TurnoIdX;
         this.AV9MedicoIdX = aP2_MedicoIdX;
         this.AV10TurnoOcupado = false ;
         initialize();
         executePrivate();
         aP3_TurnoOcupado=this.AV10TurnoOcupado;
      }

      public bool executeUdp( DateTime aP0_ConsultaFechaX ,
                              short aP1_TurnoIdX ,
                              int aP2_MedicoIdX )
      {
         this.AV8ConsultaFechaX = aP0_ConsultaFechaX;
         this.AV11TurnoIdX = aP1_TurnoIdX;
         this.AV9MedicoIdX = aP2_MedicoIdX;
         this.AV10TurnoOcupado = false ;
         initialize();
         executePrivate();
         aP3_TurnoOcupado=this.AV10TurnoOcupado;
         return AV10TurnoOcupado ;
      }

      public void executeSubmit( DateTime aP0_ConsultaFechaX ,
                                 short aP1_TurnoIdX ,
                                 int aP2_MedicoIdX ,
                                 out bool aP3_TurnoOcupado )
      {
         turnoocupado objturnoocupado;
         objturnoocupado = new turnoocupado();
         objturnoocupado.AV8ConsultaFechaX = aP0_ConsultaFechaX;
         objturnoocupado.AV11TurnoIdX = aP1_TurnoIdX;
         objturnoocupado.AV9MedicoIdX = aP2_MedicoIdX;
         objturnoocupado.AV10TurnoOcupado = false ;
         objturnoocupado.initialize();
         ThreadPool.QueueUserWorkItem( new WaitCallback( objturnoocupado.executePrivateCatch ));
         aP3_TurnoOcupado=this.AV10TurnoOcupado;
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
         AV14GXLvl1 = 0 ;
         /* Using cursor P000B2 */
         pr_default.execute(0, new Object[] {AV8ConsultaFechaX, AV9MedicoIdX, AV11TurnoIdX});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A12MedicoId = P000B2_A12MedicoId[0] ;
            A60TurnoId = P000B2_A60TurnoId[0] ;
            A43ConsultaFecha = P000B2_A43ConsultaFecha[0] ;
            AV14GXLvl1 = 1 ;
            AV10TurnoOcupado = true ;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV14GXLvl1 == 0 )
         {
            AV10TurnoOcupado = false ;
         }
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
         P000B2_A12MedicoId = new int[1] ;
         P000B2_A60TurnoId = new short[1] ;
         P000B2_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         A43ConsultaFecha = DateTime.MinValue ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.turnoocupado__default(),
            new Object[][] {
                new Object[] {
               P000B2_A12MedicoId, P000B2_A60TurnoId, P000B2_A43ConsultaFecha
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0 ;
      }

      private short AV11TurnoIdX ;
      private short AV14GXLvl1 ;
      private short A60TurnoId ;
      private int AV9MedicoIdX ;
      private int A12MedicoId ;
      private String scmdbuf ;
      private DateTime AV8ConsultaFechaX ;
      private DateTime A43ConsultaFecha ;
      private bool AV10TurnoOcupado ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P000B2_A12MedicoId ;
      private short[] P000B2_A60TurnoId ;
      private DateTime[] P000B2_A43ConsultaFecha ;
      private bool aP3_TurnoOcupado ;
   }

   public class turnoocupado__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000B2 ;
          prmP000B2 = new Object[] {
          new Object[] {"@AV8ConsultaFechaX",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV9MedicoIdX",SqlDbType.Int,6,0} ,
          new Object[] {"@AV11TurnoIdX",SqlDbType.SmallInt,2,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P000B2", "SELECT [MedicoId], [TurnoId], [ConsultaFecha] FROM [Consulta] WITH (NOLOCK) WHERE [ConsultaFecha] = @AV8ConsultaFechaX and [MedicoId] = @AV9MedicoIdX and [TurnoId] = @AV11TurnoIdX ORDER BY [ConsultaFecha], [MedicoId], [TurnoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000B2,1,0,false,true )
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
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3) ;
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
                stmt.SetParameter(3, (short)parms[2]);
                break;
       }
    }

 }

}
