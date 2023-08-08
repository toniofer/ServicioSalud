/*
               File: LoadContext
        Description: Load Context
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/22/2010 3:59:17.40
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
   public class loadcontext : GXProcedure
   {
      public loadcontext( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public loadcontext( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out SdtContext aP0_Context )
      {
         this.AV8Context = new SdtContext(context) ;
         initialize();
         executePrivate();
         aP0_Context=this.AV8Context;
      }

      public SdtContext executeUdp( )
      {
         this.AV8Context = new SdtContext(context) ;
         initialize();
         executePrivate();
         aP0_Context=this.AV8Context;
         return AV8Context ;
      }

      public void executeSubmit( out SdtContext aP0_Context )
      {
         loadcontext objloadcontext;
         objloadcontext = new loadcontext();
         objloadcontext.AV8Context = new SdtContext(context) ;
         objloadcontext.initialize();
         ThreadPool.QueueUserWorkItem( new WaitCallback( objloadcontext.executePrivateCatch ));
         aP0_Context=this.AV8Context;
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
         AV8Context.FromXml(AV9Session.Get("context"), "");
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
      private SdtContext aP0_Context ;
      private SdtContext AV8Context ;
   }

}
