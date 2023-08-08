/*
               File: DP1
        Description: DP1
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/22/2010 6:7:0.4
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
   public class dp1 : GXProcedure
   {
      public dp1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public dp1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( DateTime aP0_desde ,
                           DateTime aP1_hasta ,
                           out IGxCollection aP2_Gxm1rootcol )
      {
         this.AV5desde = aP0_desde;
         this.AV6hasta = aP1_hasta;
         this.Gxm1rootcol = new GxObjectCollection( context, "MedicosSTD.MedicoSTD", "taller041", "SdtMedicosSTD_MedicoSTD", "GeneXus.Programs") ;
         initialize();
         executePrivate();
         aP2_Gxm1rootcol=this.Gxm1rootcol;
      }

      public IGxCollection executeUdp( DateTime aP0_desde ,
                                       DateTime aP1_hasta )
      {
         this.AV5desde = aP0_desde;
         this.AV6hasta = aP1_hasta;
         this.Gxm1rootcol = new GxObjectCollection( context, "MedicosSTD.MedicoSTD", "taller041", "SdtMedicosSTD_MedicoSTD", "GeneXus.Programs") ;
         initialize();
         executePrivate();
         aP2_Gxm1rootcol=this.Gxm1rootcol;
         return Gxm1rootcol ;
      }

      public void executeSubmit( DateTime aP0_desde ,
                                 DateTime aP1_hasta ,
                                 out IGxCollection aP2_Gxm1rootcol )
      {
         dp1 objdp1;
         objdp1 = new dp1();
         objdp1.AV5desde = aP0_desde;
         objdp1.AV6hasta = aP1_hasta;
         objdp1.Gxm1rootcol = new GxObjectCollection( context, "MedicosSTD.MedicoSTD", "taller041", "SdtMedicosSTD_MedicoSTD", "GeneXus.Programs") ;
         objdp1.initialize();
         ThreadPool.QueueUserWorkItem( new WaitCallback( objdp1.executePrivateCatch ));
         aP2_Gxm1rootcol=this.Gxm1rootcol;
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

      private DateTime AV5desde ;
      private DateTime AV6hasta ;
      private IGxCollection aP2_Gxm1rootcol ;
      private IGxCollection Gxm1rootcol ;
   }

}
