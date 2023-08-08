/*
               File: CantidadConsultas
        Description: Cantidad Consultas
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/22/2010 4:0:22.34
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
   public class cantidadconsultas : GXProcedure
   {
      public cantidadconsultas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public cantidadconsultas( IGxContext context )
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
                           out short aP2_CantidadX )
      {
         this.A43ConsultaFecha = aP0_ConsultaFecha;
         this.A12MedicoId = aP1_MedicoId;
         this.AV8CantidadX = 0 ;
         initialize();
         executePrivate();
         aP2_CantidadX=this.AV8CantidadX;
      }

      public short executeUdp( DateTime aP0_ConsultaFecha ,
                               int aP1_MedicoId )
      {
         this.A43ConsultaFecha = aP0_ConsultaFecha;
         this.A12MedicoId = aP1_MedicoId;
         this.AV8CantidadX = 0 ;
         initialize();
         executePrivate();
         aP2_CantidadX=this.AV8CantidadX;
         return AV8CantidadX ;
      }

      public void executeSubmit( DateTime aP0_ConsultaFecha ,
                                 int aP1_MedicoId ,
                                 out short aP2_CantidadX )
      {
         cantidadconsultas objcantidadconsultas;
         objcantidadconsultas = new cantidadconsultas();
         objcantidadconsultas.A43ConsultaFecha = aP0_ConsultaFecha;
         objcantidadconsultas.A12MedicoId = aP1_MedicoId;
         objcantidadconsultas.AV8CantidadX = 0 ;
         objcantidadconsultas.initialize();
         ThreadPool.QueueUserWorkItem( new WaitCallback( objcantidadconsultas.executePrivateCatch ));
         aP2_CantidadX=this.AV8CantidadX;
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
         /* Optimized group. */
         /* Using cursor P00092 */
         pr_default.execute(0, new Object[] {A43ConsultaFecha, A12MedicoId});
         cV8CantidadX = P00092_AV8CantidadX[0] ;
         pr_default.close(0);
         AV8CantidadX = (short)(AV8CantidadX+cV8CantidadX*1) ;
         /* End optimized group. */
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
         P00092_AV8CantidadX = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cantidadconsultas__default(),
            new Object[][] {
                new Object[] {
               P00092_AV8CantidadX
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0 ;
      }

      private short AV8CantidadX ;
      private short cV8CantidadX ;
      private int A12MedicoId ;
      private String scmdbuf ;
      private DateTime A43ConsultaFecha ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00092_AV8CantidadX ;
      private short aP2_CantidadX ;
   }

   public class cantidadconsultas__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00092 ;
          prmP00092 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P00092", "SELECT COUNT(*) FROM [Consulta] WITH (NOLOCK) WHERE [ConsultaFecha] = @ConsultaFecha and [MedicoId] = @MedicoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00092,1,0,true,false )
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
