/*
               File: ConsultorioOcupado
        Description: Consultorio Ocupado
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/24/2010 5:13:6.78
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
   public class consultorioocupado : GXProcedure
   {
      public consultorioocupado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public consultorioocupado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default") ;
      }

      public void release( )
      {
      }

      public void execute( ref DateTime aP0_ConsultaFechaX ,
                           short aP1_TurnoIdX ,
                           short aP2_ConsultorioIdX ,
                           out bool aP3_Ocupado )
      {
         this.AV8ConsultaFechaX = aP0_ConsultaFechaX;
         this.AV11TurnoIdX = aP1_TurnoIdX;
         this.AV9ConsultorioIdX = aP2_ConsultorioIdX;
         this.AV10Ocupado = false ;
         initialize();
         executePrivate();
         aP0_ConsultaFechaX=this.AV8ConsultaFechaX;
         aP3_Ocupado=this.AV10Ocupado;
      }

      public bool executeUdp( ref DateTime aP0_ConsultaFechaX ,
                              short aP1_TurnoIdX ,
                              short aP2_ConsultorioIdX )
      {
         this.AV8ConsultaFechaX = aP0_ConsultaFechaX;
         this.AV11TurnoIdX = aP1_TurnoIdX;
         this.AV9ConsultorioIdX = aP2_ConsultorioIdX;
         this.AV10Ocupado = false ;
         initialize();
         executePrivate();
         aP0_ConsultaFechaX=this.AV8ConsultaFechaX;
         aP3_Ocupado=this.AV10Ocupado;
         return AV10Ocupado ;
      }

      public void executeSubmit( ref DateTime aP0_ConsultaFechaX ,
                                 short aP1_TurnoIdX ,
                                 short aP2_ConsultorioIdX ,
                                 out bool aP3_Ocupado )
      {
         consultorioocupado objconsultorioocupado;
         objconsultorioocupado = new consultorioocupado();
         objconsultorioocupado.AV8ConsultaFechaX = aP0_ConsultaFechaX;
         objconsultorioocupado.AV11TurnoIdX = aP1_TurnoIdX;
         objconsultorioocupado.AV9ConsultorioIdX = aP2_ConsultorioIdX;
         objconsultorioocupado.AV10Ocupado = false ;
         objconsultorioocupado.initialize();
         ThreadPool.QueueUserWorkItem( new WaitCallback( objconsultorioocupado.executePrivateCatch ));
         aP0_ConsultaFechaX=this.AV8ConsultaFechaX;
         aP3_Ocupado=this.AV10Ocupado;
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
         /* Using cursor P000A2 */
         pr_default.execute(0, new Object[] {AV8ConsultaFechaX, AV11TurnoIdX, AV9ConsultorioIdX});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A57ConsultorioId = P000A2_A57ConsultorioId[0] ;
            A60TurnoId = P000A2_A60TurnoId[0] ;
            A43ConsultaFecha = P000A2_A43ConsultaFecha[0] ;
            A12MedicoId = P000A2_A12MedicoId[0] ;
            AV14GXLvl1 = 1 ;
            AV10Ocupado = true ;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV14GXLvl1 == 0 )
         {
            AV10Ocupado = false ;
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
         P000A2_A57ConsultorioId = new short[1] ;
         P000A2_A60TurnoId = new short[1] ;
         P000A2_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         P000A2_A12MedicoId = new int[1] ;
         A43ConsultaFecha = DateTime.MinValue ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.consultorioocupado__default(),
            new Object[][] {
                new Object[] {
               P000A2_A57ConsultorioId, P000A2_A60TurnoId, P000A2_A43ConsultaFecha, P000A2_A12MedicoId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0 ;
      }

      private short AV11TurnoIdX ;
      private short AV9ConsultorioIdX ;
      private short AV14GXLvl1 ;
      private short A57ConsultorioId ;
      private short A60TurnoId ;
      private int A12MedicoId ;
      private String scmdbuf ;
      private DateTime AV8ConsultaFechaX ;
      private DateTime A43ConsultaFecha ;
      private bool AV10Ocupado ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_ConsultaFechaX ;
      private IDataStoreProvider pr_default ;
      private short[] P000A2_A57ConsultorioId ;
      private short[] P000A2_A60TurnoId ;
      private DateTime[] P000A2_A43ConsultaFecha ;
      private int[] P000A2_A12MedicoId ;
      private bool aP3_Ocupado ;
   }

   public class consultorioocupado__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000A2 ;
          prmP000A2 = new Object[] {
          new Object[] {"@AV8ConsultaFechaX",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV11TurnoIdX",SqlDbType.SmallInt,2,0} ,
          new Object[] {"@AV9ConsultorioIdX",SqlDbType.SmallInt,3,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P000A2", "SELECT [ConsultorioId], [TurnoId], [ConsultaFecha], [MedicoId] FROM [Consulta] WITH (NOLOCK) WHERE ([ConsultaFecha] = @AV8ConsultaFechaX) AND ([TurnoId] = @AV11TurnoIdX) AND ([ConsultorioId] = @AV9ConsultorioIdX) ORDER BY [ConsultaFecha] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000A2,100,0,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3) ;
                ((int[]) buf[3])[0] = rslt.getInt(4) ;
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
                stmt.SetParameter(2, (short)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
       }
    }

 }

}
