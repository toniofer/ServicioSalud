/*
               File: SetContext
        Description: Set Context
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/22/2010 4:1:11.70
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
   public class setcontext : GXProcedure
   {
      public setcontext( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public setcontext( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( SdtContext aP0_Context )
      {
         this.AV8Context = aP0_Context;
         initialize();
         executePrivate();
      }

      public void executeSubmit( SdtContext aP0_Context )
      {
         setcontext objsetcontext;
         objsetcontext = new setcontext();
         objsetcontext.AV8Context = aP0_Context;
         objsetcontext.initialize();
         ThreadPool.QueueUserWorkItem( new WaitCallback( objsetcontext.executePrivateCatch ));
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
         AV9Session.Set("context", AV8Context.ToXml(false, "Context", "taller041"));
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
         AV9Session = new GxWebSession( context);
         /* GeneXus formulas. */
         context.Gx_err = 0 ;
      }

      private GxWebSession AV9Session ;
      private SdtContext AV8Context ;
   }

}
