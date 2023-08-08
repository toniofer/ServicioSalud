/*
               File: ConsultorioAsignado
        Description: Consultorio Asignado
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/22/2010 4:0:32.18
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
   public class consultorioasignado : GXProcedure
   {
      public consultorioasignado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public consultorioasignado( IGxContext context )
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
                           out short aP2_ConsultorioIdX )
      {
         this.A43ConsultaFecha = aP0_ConsultaFecha;
         this.A12MedicoId = aP1_MedicoId;
         this.AV8ConsultorioIdX = 0 ;
         initialize();
         executePrivate();
         aP2_ConsultorioIdX=this.AV8ConsultorioIdX;
      }

      public short executeUdp( DateTime aP0_ConsultaFecha ,
                               int aP1_MedicoId )
      {
         this.A43ConsultaFecha = aP0_ConsultaFecha;
         this.A12MedicoId = aP1_MedicoId;
         this.AV8ConsultorioIdX = 0 ;
         initialize();
         executePrivate();
         aP2_ConsultorioIdX=this.AV8ConsultorioIdX;
         return AV8ConsultorioIdX ;
      }

      public void executeSubmit( DateTime aP0_ConsultaFecha ,
                                 int aP1_MedicoId ,
                                 out short aP2_ConsultorioIdX )
      {
         consultorioasignado objconsultorioasignado;
         objconsultorioasignado = new consultorioasignado();
         objconsultorioasignado.A43ConsultaFecha = aP0_ConsultaFecha;
         objconsultorioasignado.A12MedicoId = aP1_MedicoId;
         objconsultorioasignado.AV8ConsultorioIdX = 0 ;
         objconsultorioasignado.initialize();
         ThreadPool.QueueUserWorkItem( new WaitCallback( objconsultorioasignado.executePrivateCatch ));
         aP2_ConsultorioIdX=this.AV8ConsultorioIdX;
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
         /* Using cursor P00082 */
         pr_default.execute(0, new Object[] {A43ConsultaFecha, A12MedicoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A57ConsultorioId = P00082_A57ConsultorioId[0] ;
            A60TurnoId = P00082_A60TurnoId[0] ;
            AV8ConsultorioIdX = A57ConsultorioId ;
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
         P00082_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         P00082_A12MedicoId = new int[1] ;
         P00082_A57ConsultorioId = new short[1] ;
         P00082_A60TurnoId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.consultorioasignado__default(),
            new Object[][] {
                new Object[] {
               P00082_A43ConsultaFecha, P00082_A12MedicoId, P00082_A57ConsultorioId, P00082_A60TurnoId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0 ;
      }

      private short AV8ConsultorioIdX ;
      private short A57ConsultorioId ;
      private short A60TurnoId ;
      private int A12MedicoId ;
      private String scmdbuf ;
      private DateTime A43ConsultaFecha ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P00082_A43ConsultaFecha ;
      private int[] P00082_A12MedicoId ;
      private short[] P00082_A57ConsultorioId ;
      private short[] P00082_A60TurnoId ;
      private short aP2_ConsultorioIdX ;
   }

   public class consultorioasignado__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00082 ;
          prmP00082 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P00082", "SELECT [ConsultaFecha], [MedicoId], [ConsultorioId], [TurnoId] FROM [Consulta] WITH (NOLOCK) WHERE [ConsultaFecha] = @ConsultaFecha and [MedicoId] = @MedicoId ORDER BY [ConsultaFecha], [MedicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00082,100,0,false,false )
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
                ((short[]) buf[3])[0] = rslt.getShort(4) ;
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
