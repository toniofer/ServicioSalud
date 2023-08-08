/*
               File: ListarMedicos
        Description: Stub for ListarMedicos
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/22/2010 4:1:1.68
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
   public class listarmedicos : GXProcedure
   {
      public listarmedicos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
      }

      public listarmedicos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default") ;
      }

      public void release( )
      {
      }

      public void execute( DateTime aP0_desde ,
                           DateTime aP1_hasta )
      {
         this.AV2desde = aP0_desde;
         this.AV3hasta = aP1_hasta;
         initialize();
         executePrivate();
      }

      public void executeSubmit( DateTime aP0_desde ,
                                 DateTime aP1_hasta )
      {
         listarmedicos objlistarmedicos;
         objlistarmedicos = new listarmedicos();
         objlistarmedicos.AV2desde = aP0_desde;
         objlistarmedicos.AV3hasta = aP1_hasta;
         objlistarmedicos.initialize();
         ThreadPool.QueueUserWorkItem( new WaitCallback( objlistarmedicos.executePrivateCatch ));
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
         args = new Object[] {(DateTime)AV2desde,(DateTime)AV3hasta} ;
         ClassLoader.Execute("alistarmedicos","GeneXus.Programs.alistarmedicos", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
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

      private DateTime AV2desde ;
      private DateTime AV3hasta ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
