/*
               File: ConsultaCatalog
        Description: Consulta Catalog
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/22/2010 4:0:29.68
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
   public class consultacatalog : GXProcedure
   {
      public consultacatalog( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public consultacatalog( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out IGxCollection aP0_Gxm1rootcol )
      {
         this.Gxm1rootcol = new GxObjectCollection( context, "TreeNodeCollection.TreeNode", "taller041", "SdtTreeNodeCollection_TreeNode", "GeneXus.Programs") ;
         initialize();
         executePrivate();
         aP0_Gxm1rootcol=this.Gxm1rootcol;
      }

      public IGxCollection executeUdp( )
      {
         this.Gxm1rootcol = new GxObjectCollection( context, "TreeNodeCollection.TreeNode", "taller041", "SdtTreeNodeCollection_TreeNode", "GeneXus.Programs") ;
         initialize();
         executePrivate();
         aP0_Gxm1rootcol=this.Gxm1rootcol;
         return Gxm1rootcol ;
      }

      public void executeSubmit( out IGxCollection aP0_Gxm1rootcol )
      {
         consultacatalog objconsultacatalog;
         objconsultacatalog = new consultacatalog();
         objconsultacatalog.Gxm1rootcol = new GxObjectCollection( context, "TreeNodeCollection.TreeNode", "taller041", "SdtTreeNodeCollection_TreeNode", "GeneXus.Programs") ;
         objconsultacatalog.initialize();
         ThreadPool.QueueUserWorkItem( new WaitCallback( objconsultacatalog.executePrivateCatch ));
         aP0_Gxm1rootcol=this.Gxm1rootcol;
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

      private IGxCollection aP0_Gxm1rootcol ;
      private IGxCollection Gxm1rootcol ;
   }

}
