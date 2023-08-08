/*
               File: GXRTCtls
        Description: Run time reorganization controls
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/22/2010 3:15:18.87
       Program type: Callable routine
          Main DBMS: sqlserver
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
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
using System.Xml.Serialization;
using System.Data.SqlTypes;
namespace GeneXus.Programs {
   public class gxrtctls : GXProcedure
   {
      public gxrtctls( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
      }

      public gxrtctls( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default") ;
      }

      public void release( )
      {
      }

      public void execute( out short aP0_Status )
      {
         this.AV2Status = 0 ;
         initialize();
         executePrivate();
         aP0_Status=this.AV2Status;
      }

      public short executeUdp( )
      {
         this.AV2Status = 0 ;
         initialize();
         executePrivate();
         aP0_Status=this.AV2Status;
         return AV2Status ;
      }

      public void executeSubmit( out short aP0_Status )
      {
         gxrtctls objgxrtctls;
         objgxrtctls = new gxrtctls();
         objgxrtctls.AV2Status = 0 ;
         objgxrtctls.initialize();
         ThreadPool.QueueUserWorkItem( new WaitCallback( objgxrtctls.executePrivateCatch ));
         aP0_Status=this.AV2Status;
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
         AV2Status = 0 ;
         Console.WriteLine( "=== Starting run time controls" );
         Console.WriteLine( "Searching Paciente for duplicate values on new unique index on PacienteCI" );
         /* Using cursor LTCTLS2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKR012 = false ;
            A41PacienteCI = LTCTLS2_A41PacienteCI[0] ;
            A34PacienteId = LTCTLS2_A34PacienteId[0] ;
            AV3Count = 0 ;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(LTCTLS2_A41PacienteCI[0], A41PacienteCI) == 0 ) )
            {
               BRKR012 = false ;
               A34PacienteId = LTCTLS2_A34PacienteId[0] ;
               if ( AV3Count != 0 )
               {
                  AV2Status = 1 ;
                  Console.WriteLine( "Fail: Duplicates found. The first non unique value found follows." );
                  Console.WriteLine( "PacienteCI: "+StringUtil.RTrim( A41PacienteCI) );
                  Console.WriteLine( "Recovery: See recovery information for reorganization message rgz0020." );
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               AV3Count = (int)(AV3Count+1) ;
               BRKR012 = true ;
               pr_default.readNext(0);
            }
            if ( AV2Status != 0 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKR012 )
            {
               BRKR012 = true ;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         if ( AV2Status == 0 )
         {
            Console.WriteLine( "Success: No duplicates found for PacienteCI" );
         }
         Console.WriteLine( "====================" );
         Console.WriteLine( "=== End of run time controls" );
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
         LTCTLS2_A41PacienteCI = new String[] {""} ;
         LTCTLS2_A34PacienteId = new int[1] ;
         A41PacienteCI = "" ;
         GXt_char1 = "" ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gxrtctls__default(),
            new Object[][] {
                new Object[] {
               LTCTLS2_A41PacienteCI, LTCTLS2_A34PacienteId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0 ;
      }

      private short AV2Status ;
      private int A34PacienteId ;
      private int AV3Count ;
      private String scmdbuf ;
      private String A41PacienteCI ;
      private String GXt_char1 ;
      private bool BRKR012 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private String[] LTCTLS2_A41PacienteCI ;
      private int[] LTCTLS2_A34PacienteId ;
      private short aP0_Status ;
   }

   public class gxrtctls__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmLTCTLS2 ;
          prmLTCTLS2 = new Object[] {
          } ;
          def= new CursorDef[] {
              new CursorDef("LTCTLS2", "SELECT [PacienteCI], [PacienteId] FROM [Paciente] ORDER BY [PacienteCI] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLTCTLS2,100,0,true,false )
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
                ((String[]) buf[0])[0] = rslt.getString(1, 8) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                break;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
       }
    }

 }

}
