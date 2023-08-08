/*
               File: GetTabImage
        Description: Get Tab Image Name
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/22/2010 4:0:51.98
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
   public class gettabimage : GXProcedure
   {
      public gettabimage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public gettabimage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( bool aP0_IsFirstTab ,
                           bool aP1_IsSelected ,
                           bool aP2_IsBeforeTabSelected ,
                           bool aP3_IsLastTab ,
                           out String aP4_Bitmap )
      {
         this.AV9IsFirstTab = aP0_IsFirstTab;
         this.AV10IsSelected = aP1_IsSelected;
         this.AV11IsBeforeTabSelected = aP2_IsBeforeTabSelected;
         this.AV12IsLastTab = aP3_IsLastTab;
         this.AV8Bitmap = "" ;
         initialize();
         executePrivate();
         aP4_Bitmap=this.AV8Bitmap;
      }

      public String executeUdp( bool aP0_IsFirstTab ,
                                bool aP1_IsSelected ,
                                bool aP2_IsBeforeTabSelected ,
                                bool aP3_IsLastTab )
      {
         this.AV9IsFirstTab = aP0_IsFirstTab;
         this.AV10IsSelected = aP1_IsSelected;
         this.AV11IsBeforeTabSelected = aP2_IsBeforeTabSelected;
         this.AV12IsLastTab = aP3_IsLastTab;
         this.AV8Bitmap = "" ;
         initialize();
         executePrivate();
         aP4_Bitmap=this.AV8Bitmap;
         return AV8Bitmap ;
      }

      public void executeSubmit( bool aP0_IsFirstTab ,
                                 bool aP1_IsSelected ,
                                 bool aP2_IsBeforeTabSelected ,
                                 bool aP3_IsLastTab ,
                                 out String aP4_Bitmap )
      {
         gettabimage objgettabimage;
         objgettabimage = new gettabimage();
         objgettabimage.AV9IsFirstTab = aP0_IsFirstTab;
         objgettabimage.AV10IsSelected = aP1_IsSelected;
         objgettabimage.AV11IsBeforeTabSelected = aP2_IsBeforeTabSelected;
         objgettabimage.AV12IsLastTab = aP3_IsLastTab;
         objgettabimage.AV8Bitmap = "" ;
         objgettabimage.initialize();
         ThreadPool.QueueUserWorkItem( new WaitCallback( objgettabimage.executePrivateCatch ));
         aP4_Bitmap=this.AV8Bitmap;
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
         if ( AV12IsLastTab )
         {
            if ( AV10IsSelected )
            {
               AV8Bitmap = context.GetImagePath( "0424c12e-f1b1-4123-889e-b2966eb27e93", "", "GeneXusX") ;
            }
            else
            {
               AV8Bitmap = context.GetImagePath( "a46a2602-a799-4dab-a329-130bd24fbbb4", "", "GeneXusX") ;
            }
         }
         else
         {
            if ( AV10IsSelected )
            {
               if ( AV9IsFirstTab )
               {
                  AV8Bitmap = context.GetImagePath( "f4a0965f-129d-45fc-bdfe-107944e516c0", "", "GeneXusX") ;
               }
               else
               {
                  AV8Bitmap = context.GetImagePath( "a908a75c-9ebf-4d01-bcda-9711089e0493", "", "GeneXusX") ;
               }
            }
            else
            {
               if ( AV9IsFirstTab )
               {
                  AV8Bitmap = context.GetImagePath( "014ad39b-4d50-4343-92ef-0117c86e1b16", "", "GeneXusX") ;
               }
               else
               {
                  if ( AV11IsBeforeTabSelected )
                  {
                     AV8Bitmap = context.GetImagePath( "3e28b5a8-f17c-43b3-8850-2e932e706b48", "", "GeneXusX") ;
                  }
                  else
                  {
                     AV8Bitmap = context.GetImagePath( "ce463bdd-5a79-4a33-a6e5-8b0b7cb85bcd", "", "GeneXusX") ;
                  }
               }
            }
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
         /* GeneXus formulas. */
         context.Gx_err = 0 ;
      }

      private bool AV9IsFirstTab ;
      private bool AV10IsSelected ;
      private bool AV11IsBeforeTabSelected ;
      private bool AV12IsLastTab ;
      private String AV8Bitmap ;
      private String aP4_Bitmap ;
   }

}
