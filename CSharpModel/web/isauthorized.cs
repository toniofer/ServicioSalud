/*
               File: IsAuthorized
        Description: Is Authorized
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/22/2010 3:59:17.28
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
   public class isauthorized : GXProcedure
   {
      public isauthorized( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public isauthorized( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( String aP0_GxObject ,
                           out bool aP1_Authorized )
      {
         this.GxObject = aP0_GxObject;
         this.AV9Authorized = false ;
         initialize();
         executePrivate();
         aP1_Authorized=this.AV9Authorized;
      }

      public bool executeUdp( String aP0_GxObject )
      {
         this.GxObject = aP0_GxObject;
         this.AV9Authorized = false ;
         initialize();
         executePrivate();
         aP1_Authorized=this.AV9Authorized;
         return AV9Authorized ;
      }

      public void executeSubmit( String aP0_GxObject ,
                                 out bool aP1_Authorized )
      {
         isauthorized objisauthorized;
         objisauthorized = new isauthorized();
         objisauthorized.GxObject = aP0_GxObject;
         objisauthorized.AV9Authorized = false ;
         objisauthorized.initialize();
         ThreadPool.QueueUserWorkItem( new WaitCallback( objisauthorized.executePrivateCatch ));
         aP1_Authorized=this.AV9Authorized;
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
         AV9Authorized = true ;
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

      private bool AV9Authorized ;
      private String GxObject ;
      private bool aP1_Authorized ;
   }

}
