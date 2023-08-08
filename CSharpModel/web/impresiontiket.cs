/*
               File: ImpresionTiket
        Description: Stub for ImpresionTiket
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/24/2010 5:13:37.73
       Program type: Callable routine
          Main DBMS: sqlserver
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using System.Web.Services.Protocols;
using System.Web.Services;
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
   public class impresiontiket : GXProcedure
   {
      public impresiontiket( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
      }

      public impresiontiket( IGxContext context )
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
         this.AV2ConsultaFecha = aP0_ConsultaFecha;
         this.AV3PacienteId = aP1_PacienteId;
         this.AV4MedicoId = aP2_MedicoId;
         this.AV5TurnoId = aP3_TurnoId;
         initialize();
         executePrivate();
         aP0_ConsultaFecha=this.AV2ConsultaFecha;
         aP1_PacienteId=this.AV3PacienteId;
         aP2_MedicoId=this.AV4MedicoId;
         aP3_TurnoId=this.AV5TurnoId;
      }

      public short executeUdp( ref DateTime aP0_ConsultaFecha ,
                               ref int aP1_PacienteId ,
                               ref int aP2_MedicoId )
      {
         this.AV2ConsultaFecha = aP0_ConsultaFecha;
         this.AV3PacienteId = aP1_PacienteId;
         this.AV4MedicoId = aP2_MedicoId;
         this.AV5TurnoId = aP3_TurnoId;
         initialize();
         executePrivate();
         aP0_ConsultaFecha=this.AV2ConsultaFecha;
         aP1_PacienteId=this.AV3PacienteId;
         aP2_MedicoId=this.AV4MedicoId;
         aP3_TurnoId=this.AV5TurnoId;
         return AV5TurnoId ;
      }

      public void executeSubmit( ref DateTime aP0_ConsultaFecha ,
                                 ref int aP1_PacienteId ,
                                 ref int aP2_MedicoId ,
                                 ref short aP3_TurnoId )
      {
         impresiontiket objimpresiontiket;
         objimpresiontiket = new impresiontiket();
         objimpresiontiket.AV2ConsultaFecha = aP0_ConsultaFecha;
         objimpresiontiket.AV3PacienteId = aP1_PacienteId;
         objimpresiontiket.AV4MedicoId = aP2_MedicoId;
         objimpresiontiket.AV5TurnoId = aP3_TurnoId;
         objimpresiontiket.initialize();
         ThreadPool.QueueUserWorkItem( new WaitCallback( objimpresiontiket.executePrivateCatch ));
         aP0_ConsultaFecha=this.AV2ConsultaFecha;
         aP1_PacienteId=this.AV3PacienteId;
         aP2_MedicoId=this.AV4MedicoId;
         aP3_TurnoId=this.AV5TurnoId;
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
         args = new Object[] {(DateTime)AV2ConsultaFecha,(int)AV3PacienteId,(int)AV4MedicoId,(short)AV5TurnoId} ;
         ClassLoader.Execute("aimpresiontiket","GeneXus.Programs.aimpresiontiket", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 4 ) )
         {
            AV2ConsultaFecha = (DateTime)(args[0]) ;
            AV3PacienteId = (int)(args[1]) ;
            AV4MedicoId = (int)(args[2]) ;
            AV5TurnoId = (short)(args[3]) ;
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
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0 ;
      }

      private short AV5TurnoId ;
      private int AV3PacienteId ;
      private int AV4MedicoId ;
      private DateTime AV2ConsultaFecha ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_ConsultaFecha ;
      private int aP1_PacienteId ;
      private int aP2_MedicoId ;
      private short aP3_TurnoId ;
      private Object[] args ;
   }

}
