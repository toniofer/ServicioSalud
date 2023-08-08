/*
               File: ListPrograms
        Description: List Programs
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/24/2010 4:15:11.61
       Program type: Callable routine
          Main DBMS: sqlserver
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
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
   public class listprograms : GXProcedure
   {
      public listprograms( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public listprograms( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out IGxCollection aP0_ProgramNames )
      {
         this.AV10ProgramNames = new GxObjectCollection( context, "ProgramNames.ProgramName", "taller041", "SdtProgramNames_ProgramName", "GeneXus.Programs") ;
         initialize();
         executePrivate();
         aP0_ProgramNames=this.AV10ProgramNames;
      }

      public IGxCollection executeUdp( )
      {
         this.AV10ProgramNames = new GxObjectCollection( context, "ProgramNames.ProgramName", "taller041", "SdtProgramNames_ProgramName", "GeneXus.Programs") ;
         initialize();
         executePrivate();
         aP0_ProgramNames=this.AV10ProgramNames;
         return AV10ProgramNames ;
      }

      public void executeSubmit( out IGxCollection aP0_ProgramNames )
      {
         listprograms objlistprograms;
         objlistprograms = new listprograms();
         objlistprograms.AV10ProgramNames = new GxObjectCollection( context, "ProgramNames.ProgramName", "taller041", "SdtProgramNames_ProgramName", "GeneXus.Programs") ;
         objlistprograms.initialize();
         ThreadPool.QueueUserWorkItem( new WaitCallback( objlistprograms.executePrivateCatch ));
         aP0_ProgramNames=this.AV10ProgramNames;
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
         /* GeneXus formulas. */
         context.Gx_err = 0 ;
      }

      private IGxCollection aP0_ProgramNames ;
      private IGxCollection AV10ProgramNames ;
   }

}
