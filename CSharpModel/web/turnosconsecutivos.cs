/*
               File: TurnosConsecutivos
        Description: Turnos Consecutivos
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/24/2010 5:13:43.80
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
   public class turnosconsecutivos : GXProcedure
   {
      public turnosconsecutivos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public turnosconsecutivos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default") ;
      }

      public void release( )
      {
      }

      public void execute( DateTime aP0_ConsultaFecha ,
                           int aP1_MedicoId ,
                           short aP2_TurnoIdX ,
                           out bool aP3_Consecutivo )
      {
         this.A43ConsultaFecha = aP0_ConsultaFecha;
         this.A12MedicoId = aP1_MedicoId;
         this.AV9TurnoIdX = aP2_TurnoIdX;
         this.AV8Consecutivo = false ;
         initialize();
         executePrivate();
         aP3_Consecutivo=this.AV8Consecutivo;
      }

      public bool executeUdp( DateTime aP0_ConsultaFecha ,
                              int aP1_MedicoId ,
                              short aP2_TurnoIdX )
      {
         this.A43ConsultaFecha = aP0_ConsultaFecha;
         this.A12MedicoId = aP1_MedicoId;
         this.AV9TurnoIdX = aP2_TurnoIdX;
         this.AV8Consecutivo = false ;
         initialize();
         executePrivate();
         aP3_Consecutivo=this.AV8Consecutivo;
         return AV8Consecutivo ;
      }

      public void executeSubmit( DateTime aP0_ConsultaFecha ,
                                 int aP1_MedicoId ,
                                 short aP2_TurnoIdX ,
                                 out bool aP3_Consecutivo )
      {
         turnosconsecutivos objturnosconsecutivos;
         objturnosconsecutivos = new turnosconsecutivos();
         objturnosconsecutivos.A43ConsultaFecha = aP0_ConsultaFecha;
         objturnosconsecutivos.A12MedicoId = aP1_MedicoId;
         objturnosconsecutivos.AV9TurnoIdX = aP2_TurnoIdX;
         objturnosconsecutivos.AV8Consecutivo = false ;
         objturnosconsecutivos.initialize();
         ThreadPool.QueueUserWorkItem( new WaitCallback( objturnosconsecutivos.executePrivateCatch ));
         aP3_Consecutivo=this.AV8Consecutivo;
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
         /* Using cursor P00072 */
         pr_default.execute(0, new Object[] {A43ConsultaFecha, A12MedicoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A60TurnoId = P00072_A60TurnoId[0] ;
            if ( ( AV9TurnoIdX - A60TurnoId == 1 ) || ( AV9TurnoIdX - A60TurnoId == -1 ) )
            {
               AV8Consecutivo = true ;
            }
            else
            {
               AV8Consecutivo = false ;
            }
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
         P00072_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         P00072_A12MedicoId = new int[1] ;
         P00072_A60TurnoId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.turnosconsecutivos__default(),
            new Object[][] {
                new Object[] {
               P00072_A43ConsultaFecha, P00072_A12MedicoId, P00072_A60TurnoId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0 ;
      }

      private short AV9TurnoIdX ;
      private short A60TurnoId ;
      private int A12MedicoId ;
      private String scmdbuf ;
      private DateTime A43ConsultaFecha ;
      private bool AV8Consecutivo ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P00072_A43ConsultaFecha ;
      private int[] P00072_A12MedicoId ;
      private short[] P00072_A60TurnoId ;
      private bool aP3_Consecutivo ;
   }

   public class turnosconsecutivos__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00072 ;
          prmP00072 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P00072", "SELECT [ConsultaFecha], [MedicoId], [TurnoId] FROM [Consulta] WITH (NOLOCK) WHERE [ConsultaFecha] = @ConsultaFecha and [MedicoId] = @MedicoId ORDER BY [ConsultaFecha], [MedicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00072,100,0,false,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
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
                break;
       }
    }

 }

}
