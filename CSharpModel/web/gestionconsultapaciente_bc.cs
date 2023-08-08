/*
               File: GestionConsultaPaciente_BC
        Description: Gestion Consulta Paciente
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/24/2010 5:13:26.75
       Program type: Callable routine
          Main DBMS: sqlserver
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Data.SqlTypes;
namespace GeneXus.Programs {
   public class gestionconsultapaciente_bc : GXHttpHandler, IGxSilentTrn
   {
      public gestionconsultapaciente_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public gestionconsultapaciente_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default") ;
      }

      protected void INITTRN( )
      {
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            /* Execute user event: E110B2 */
            E110B2 ();
            trnEnded = 0 ;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  )
            {
               Z43ConsultaFecha = A43ConsultaFecha ;
               Z34PacienteId = A34PacienteId ;
               Z12MedicoId = A12MedicoId ;
               Z60TurnoId = A60TurnoId ;
               SetMode( "UPD") ;
            }
         }
      }

      public override String ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_0B0( )
      {
         BeforeValidate0B8( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               OnDeleteControls0B8( ) ;
            }
            else
            {
               CheckExtendedTable0B8( ) ;
               if ( AnyError == 0 )
               {
                  ZM0B8( 6) ;
                  ZM0B8( 7) ;
                  ZM0B8( 8) ;
                  ZM0B8( 9) ;
                  ZM0B8( 10) ;
               }
               CloseExtendedTableCursors0B8( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1 ;
         }
      }

      protected void E120B2( )
      {
         /* Start Routine */
      }

      protected void E110B2( )
      {
         /* After Trn Routine */
      }

      protected void ZM0B8( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z63ConsultaNro = A63ConsultaNro ;
            Z75Confirmado = A75Confirmado ;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z9EspecialidadId = A9EspecialidadId ;
            Z14MedicoApellido = A14MedicoApellido ;
            Z13MedicoNombre = A13MedicoNombre ;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z61TurnoNombre = A61TurnoNombre ;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z36PacienteApellido = A36PacienteApellido ;
            Z35PacienteNombre = A35PacienteNombre ;
            Z41PacienteCI = A41PacienteCI ;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z11EspecialidadMaxPacientes = A11EspecialidadMaxPacientes ;
         }
         if ( GX_JID == -5 )
         {
            Z63ConsultaNro = A63ConsultaNro ;
            Z75Confirmado = A75Confirmado ;
            Z43ConsultaFecha = A43ConsultaFecha ;
            Z12MedicoId = A12MedicoId ;
            Z60TurnoId = A60TurnoId ;
            Z34PacienteId = A34PacienteId ;
            Z36PacienteApellido = A36PacienteApellido ;
            Z35PacienteNombre = A35PacienteNombre ;
            Z41PacienteCI = A41PacienteCI ;
            Z9EspecialidadId = A9EspecialidadId ;
            Z14MedicoApellido = A14MedicoApellido ;
            Z13MedicoNombre = A13MedicoNombre ;
            Z11EspecialidadMaxPacientes = A11EspecialidadMaxPacientes ;
            Z61TurnoNombre = A61TurnoNombre ;
            Z67UltimoNroAsig = A67UltimoNroAsig ;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0 ;
         Gx_date = DateTimeUtil.Today( ) ;
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  && (DateTime.MinValue==A43ConsultaFecha) && ( Gx_BScreen == 0 ) )
         {
            A43ConsultaFecha = Gx_date ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0B8( )
      {
         /* Using cursor BC000B10 */
         pr_default.execute(8, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId, A34PacienteId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound8 = 1 ;
            A9EspecialidadId = BC000B10_A9EspecialidadId[0] ;
            A67UltimoNroAsig = BC000B10_A67UltimoNroAsig[0] ;
            n67UltimoNroAsig = BC000B10_n67UltimoNroAsig[0] ;
            A63ConsultaNro = BC000B10_A63ConsultaNro[0] ;
            n63ConsultaNro = BC000B10_n63ConsultaNro[0] ;
            A36PacienteApellido = BC000B10_A36PacienteApellido[0] ;
            A35PacienteNombre = BC000B10_A35PacienteNombre[0] ;
            A41PacienteCI = BC000B10_A41PacienteCI[0] ;
            A14MedicoApellido = BC000B10_A14MedicoApellido[0] ;
            A13MedicoNombre = BC000B10_A13MedicoNombre[0] ;
            A11EspecialidadMaxPacientes = BC000B10_A11EspecialidadMaxPacientes[0] ;
            A61TurnoNombre = BC000B10_A61TurnoNombre[0] ;
            A75Confirmado = BC000B10_A75Confirmado[0] ;
            ZM0B8( -5) ;
         }
         pr_default.close(8);
         OnLoadActions0B8( ) ;
      }

      protected void OnLoadActions0B8( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  )
         {
            A67UltimoNroAsig = (short)(O67UltimoNroAsig+1) ;
            n67UltimoNroAsig = false ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  )
         {
            A63ConsultaNro = A67UltimoNroAsig ;
            n63ConsultaNro = false ;
         }
      }

      protected void CheckExtendedTable0B8( )
      {
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A43ConsultaFecha) || ( A43ConsultaFecha >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Consulta Fecha fuera de rango", "OutOfRange", 1, "");
            AnyError = 1 ;
         }
         /* Using cursor BC000B8 */
         pr_default.execute(6, new Object[] {A34PacienteId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Paciente'.", "ForeignKeyNotFound", 1, "PACIENTEID");
            AnyError = 1 ;
         }
         A36PacienteApellido = BC000B8_A36PacienteApellido[0] ;
         A35PacienteNombre = BC000B8_A35PacienteNombre[0] ;
         A41PacienteCI = BC000B8_A41PacienteCI[0] ;
         pr_default.close(6);
         /* Using cursor BC000B4 */
         pr_default.execute(2, new Object[] {A12MedicoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Médico'.", "ForeignKeyNotFound", 1, "MEDICOID");
            AnyError = 1 ;
         }
         A9EspecialidadId = BC000B4_A9EspecialidadId[0] ;
         A14MedicoApellido = BC000B4_A14MedicoApellido[0] ;
         A13MedicoNombre = BC000B4_A13MedicoNombre[0] ;
         pr_default.close(2);
         /* Using cursor BC000B9 */
         pr_default.execute(7, new Object[] {A9EspecialidadId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Especialidad'.", "ForeignKeyNotFound", 1, "");
            AnyError = 1 ;
         }
         A11EspecialidadMaxPacientes = BC000B9_A11EspecialidadMaxPacientes[0] ;
         pr_default.close(7);
         /* Using cursor BC000B5 */
         pr_default.execute(3, new Object[] {A60TurnoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Turno'.", "ForeignKeyNotFound", 1, "TURNOID");
            AnyError = 1 ;
         }
         A61TurnoNombre = BC000B5_A61TurnoNombre[0] ;
         pr_default.close(3);
         /* Using cursor BC000B7 */
         pr_default.execute(5, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Consulta'.", "ForeignKeyNotFound", 1, "CONSULTAFECHA");
            AnyError = 1 ;
         }
         A67UltimoNroAsig = BC000B7_A67UltimoNroAsig[0] ;
         n67UltimoNroAsig = BC000B7_n67UltimoNroAsig[0] ;
         O67UltimoNroAsig = A67UltimoNroAsig ;
         n67UltimoNroAsig = false ;
         pr_default.close(5);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  )
         {
            A67UltimoNroAsig = (short)(O67UltimoNroAsig+1) ;
            n67UltimoNroAsig = false ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  )
         {
            A63ConsultaNro = A67UltimoNroAsig ;
            n63ConsultaNro = false ;
         }
      }

      protected void CloseExtendedTableCursors0B8( )
      {
         pr_default.close(6);
         pr_default.close(2);
         pr_default.close(7);
         pr_default.close(3);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0B8( )
      {
         /* Using cursor BC000B11 */
         pr_default.execute(9, new Object[] {A43ConsultaFecha, A34PacienteId, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound8 = 1 ;
         }
         else
         {
            RcdFound8 = 0 ;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000B3 */
         pr_default.execute(1, new Object[] {A43ConsultaFecha, A34PacienteId, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0B8( 5) ;
            RcdFound8 = 1 ;
            A63ConsultaNro = BC000B3_A63ConsultaNro[0] ;
            n63ConsultaNro = BC000B3_n63ConsultaNro[0] ;
            A75Confirmado = BC000B3_A75Confirmado[0] ;
            A43ConsultaFecha = BC000B3_A43ConsultaFecha[0] ;
            A12MedicoId = BC000B3_A12MedicoId[0] ;
            A60TurnoId = BC000B3_A60TurnoId[0] ;
            A34PacienteId = BC000B3_A34PacienteId[0] ;
            Z43ConsultaFecha = A43ConsultaFecha ;
            Z34PacienteId = A34PacienteId ;
            Z12MedicoId = A12MedicoId ;
            Z60TurnoId = A60TurnoId ;
            sMode8 = Gx_mode ;
            Gx_mode = "DSP" ;
            standaloneModal( ) ;
            Load0B8( ) ;
            Gx_mode = sMode8 ;
         }
         else
         {
            RcdFound8 = 0 ;
            InitializeNonKey0B8( ) ;
            sMode8 = Gx_mode ;
            Gx_mode = "DSP" ;
            standaloneModal( ) ;
            Gx_mode = sMode8 ;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0B8( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS" ;
         }
         else
         {
            Gx_mode = "UPD" ;
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_0B0( ) ;
         IsConfirmed = 0 ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0B8( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            /* Using cursor BC000B2 */
            pr_default.execute(0, new Object[] {A43ConsultaFecha, A34PacienteId, A12MedicoId, A60TurnoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ConsultaPaciente"}), "RecordIsLocked", 1, "");
               AnyError = 1 ;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z63ConsultaNro != BC000B2_A63ConsultaNro[0] ) || ( Z75Confirmado != BC000B2_A75Confirmado[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ConsultaPaciente"}), "RecordWasChanged", 1, "");
               AnyError = 1 ;
               return  ;
            }
         }
         /* Using cursor BC000B6 */
         pr_default.execute(4, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(4) == 103) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Consulta"}), "RecordIsLocked", 1, "");
            AnyError = 1 ;
            return  ;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            if ( false )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Consulta"}), "RecordWasChanged", 1, "");
               AnyError = 1 ;
               return  ;
            }
         }
      }

      protected void Insert0B8( )
      {
         BeforeValidate0B8( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B8( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B8( 0) ;
            CheckOptimisticConcurrency0B8( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B8( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B8( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B12 */
                     pr_default.execute(10, new Object[] {n63ConsultaNro, A63ConsultaNro, A75Confirmado, A43ConsultaFecha, A12MedicoId, A60TurnoId, A34PacienteId});
                     pr_default.close(10);
                     if ( (pr_default.getStatus(10) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate"), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1 ;
                     }
                     if ( AnyError == 0 )
                     {
                        UpdateTablesN10B8( ) ;
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           GX_msglist.addItem(context.GetMessage( "GXM_sucadded"), 0, "");
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp"), 1, "");
                     AnyError = 1 ;
                  }
               }
            }
            else
            {
               Load0B8( ) ;
            }
            EndLevel0B8( ) ;
         }
         CloseExtendedTableCursors0B8( ) ;
      }

      protected void Update0B8( )
      {
         BeforeValidate0B8( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B8( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B8( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B8( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0B8( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B13 */
                     pr_default.execute(11, new Object[] {n63ConsultaNro, A63ConsultaNro, A75Confirmado, A43ConsultaFecha, A34PacienteId, A12MedicoId, A60TurnoId});
                     pr_default.close(11);
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ConsultaPaciente"}), "RecordIsLocked", 1, "");
                        AnyError = 1 ;
                     }
                     DeferredUpdate0B8( ) ;
                     if ( AnyError == 0 )
                     {
                        UpdateTablesN10B8( ) ;
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           GX_msglist.addItem(context.GetMessage( "GXM_sucupdated"), 0, "");
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp"), 1, "");
                        AnyError = 1 ;
                     }
                  }
               }
            }
            EndLevel0B8( ) ;
         }
         CloseExtendedTableCursors0B8( ) ;
      }

      protected void DeferredUpdate0B8( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT" ;
         BeforeValidate0B8( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B8( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B8( ) ;
            AfterConfirm0B8( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B8( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000B14 */
                  pr_default.execute(12, new Object[] {A43ConsultaFecha, A34PacienteId, A12MedicoId, A60TurnoId});
                  pr_default.close(12);
                  if ( AnyError == 0 )
                  {
                     UpdateTablesN10B8( ) ;
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_sucdeleted"), 0, "");
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp"), 1, "");
                     AnyError = 1 ;
                  }
               }
            }
         }
         sMode8 = Gx_mode ;
         Gx_mode = "DLT" ;
         EndLevel0B8( ) ;
         Gx_mode = sMode8 ;
      }

      protected void OnDeleteControls0B8( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000B15 */
            pr_default.execute(13, new Object[] {A34PacienteId});
            A36PacienteApellido = BC000B15_A36PacienteApellido[0] ;
            A35PacienteNombre = BC000B15_A35PacienteNombre[0] ;
            A41PacienteCI = BC000B15_A41PacienteCI[0] ;
            pr_default.close(13);
            /* Using cursor BC000B16 */
            pr_default.execute(14, new Object[] {A12MedicoId});
            A9EspecialidadId = BC000B16_A9EspecialidadId[0] ;
            A14MedicoApellido = BC000B16_A14MedicoApellido[0] ;
            A13MedicoNombre = BC000B16_A13MedicoNombre[0] ;
            pr_default.close(14);
            /* Using cursor BC000B17 */
            pr_default.execute(15, new Object[] {A9EspecialidadId});
            A11EspecialidadMaxPacientes = BC000B17_A11EspecialidadMaxPacientes[0] ;
            pr_default.close(15);
            /* Using cursor BC000B18 */
            pr_default.execute(16, new Object[] {A60TurnoId});
            A61TurnoNombre = BC000B18_A61TurnoNombre[0] ;
            pr_default.close(16);
            /* Using cursor BC000B19 */
            pr_default.execute(17, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
            ZM0B8( 8) ;
            A67UltimoNroAsig = BC000B19_A67UltimoNroAsig[0] ;
            n67UltimoNroAsig = BC000B19_n67UltimoNroAsig[0] ;
            O67UltimoNroAsig = A67UltimoNroAsig ;
            n67UltimoNroAsig = false ;
            pr_default.close(17);
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  )
            {
               A67UltimoNroAsig = (short)(O67UltimoNroAsig+1) ;
               n67UltimoNroAsig = false ;
            }
         }
      }

      protected void UpdateTablesN10B8( )
      {
         /* Using cursor BC000B20 */
         pr_default.execute(18, new Object[] {n67UltimoNroAsig, A67UltimoNroAsig, A43ConsultaFecha, A12MedicoId, A60TurnoId});
         pr_default.close(18);
      }

      protected void EndLevel0B8( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            pr_default.close(0);
         }
         pr_default.close(4);
         if ( AnyError == 0 )
         {
            BeforeComplete0B8( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1 ;
         }
         else
         {
         }
         IsModified = 0 ;
         if ( AnyError != 0 )
         {
            context.wjLoc = "" ;
            context.nUserReturn = 0 ;
         }
      }

      protected void ScanKeyStart0B8( )
      {
         /* Using cursor BC000B21 */
         pr_default.execute(19, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId, A34PacienteId});
         RcdFound8 = 0 ;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound8 = 1 ;
            A9EspecialidadId = BC000B21_A9EspecialidadId[0] ;
            A67UltimoNroAsig = BC000B21_A67UltimoNroAsig[0] ;
            n67UltimoNroAsig = BC000B21_n67UltimoNroAsig[0] ;
            A63ConsultaNro = BC000B21_A63ConsultaNro[0] ;
            n63ConsultaNro = BC000B21_n63ConsultaNro[0] ;
            A36PacienteApellido = BC000B21_A36PacienteApellido[0] ;
            A35PacienteNombre = BC000B21_A35PacienteNombre[0] ;
            A41PacienteCI = BC000B21_A41PacienteCI[0] ;
            A14MedicoApellido = BC000B21_A14MedicoApellido[0] ;
            A13MedicoNombre = BC000B21_A13MedicoNombre[0] ;
            A11EspecialidadMaxPacientes = BC000B21_A11EspecialidadMaxPacientes[0] ;
            A61TurnoNombre = BC000B21_A61TurnoNombre[0] ;
            A75Confirmado = BC000B21_A75Confirmado[0] ;
            A43ConsultaFecha = BC000B21_A43ConsultaFecha[0] ;
            A12MedicoId = BC000B21_A12MedicoId[0] ;
            A60TurnoId = BC000B21_A60TurnoId[0] ;
            A34PacienteId = BC000B21_A34PacienteId[0] ;
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0B8( )
      {
         pr_default.readNext(19);
         RcdFound8 = 0 ;
         ScanKeyLoad0B8( ) ;
      }

      protected void ScanKeyLoad0B8( )
      {
         sMode8 = Gx_mode ;
         Gx_mode = "DSP" ;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound8 = 1 ;
            A9EspecialidadId = BC000B21_A9EspecialidadId[0] ;
            A67UltimoNroAsig = BC000B21_A67UltimoNroAsig[0] ;
            n67UltimoNroAsig = BC000B21_n67UltimoNroAsig[0] ;
            A63ConsultaNro = BC000B21_A63ConsultaNro[0] ;
            n63ConsultaNro = BC000B21_n63ConsultaNro[0] ;
            A36PacienteApellido = BC000B21_A36PacienteApellido[0] ;
            A35PacienteNombre = BC000B21_A35PacienteNombre[0] ;
            A41PacienteCI = BC000B21_A41PacienteCI[0] ;
            A14MedicoApellido = BC000B21_A14MedicoApellido[0] ;
            A13MedicoNombre = BC000B21_A13MedicoNombre[0] ;
            A11EspecialidadMaxPacientes = BC000B21_A11EspecialidadMaxPacientes[0] ;
            A61TurnoNombre = BC000B21_A61TurnoNombre[0] ;
            A75Confirmado = BC000B21_A75Confirmado[0] ;
            A43ConsultaFecha = BC000B21_A43ConsultaFecha[0] ;
            A12MedicoId = BC000B21_A12MedicoId[0] ;
            A60TurnoId = BC000B21_A60TurnoId[0] ;
            A34PacienteId = BC000B21_A34PacienteId[0] ;
         }
         Gx_mode = sMode8 ;
      }

      protected void ScanKeyEnd0B8( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm0B8( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B8( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B8( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B8( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B8( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B8( )
      {
         /* Before Validate Rules */
      }

      protected void AddRow0B8( )
      {
         VarsToRow8( bcGestionConsultaPaciente) ;
      }

      protected void ReadRow0B8( )
      {
         RowToVars8( bcGestionConsultaPaciente, 1) ;
      }

      protected void InitializeNonKey0B8( )
      {
         A9EspecialidadId = 0 ;
         A67UltimoNroAsig = 0 ;
         n67UltimoNroAsig = false ;
         A63ConsultaNro = 0 ;
         n63ConsultaNro = false ;
         A36PacienteApellido = "" ;
         A35PacienteNombre = "" ;
         A41PacienteCI = "" ;
         A14MedicoApellido = "" ;
         A13MedicoNombre = "" ;
         A11EspecialidadMaxPacientes = 0 ;
         A61TurnoNombre = "" ;
         A75Confirmado = false ;
         O67UltimoNroAsig = A67UltimoNroAsig ;
         n67UltimoNroAsig = false ;
      }

      protected void InitAll0B8( )
      {
         A43ConsultaFecha = Gx_date ;
         A34PacienteId = 0 ;
         A12MedicoId = 0 ;
         A60TurnoId = 0 ;
         InitializeNonKey0B8( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      public void VarsToRow8( SdtGestionConsultaPaciente obj8 )
      {
         obj8.gxTpr_Mode = Gx_mode ;
         obj8.gxTpr_Ultimonroasig = A67UltimoNroAsig ;
         obj8.gxTpr_Consultanro = A63ConsultaNro ;
         obj8.gxTpr_Pacienteapellido = A36PacienteApellido ;
         obj8.gxTpr_Pacientenombre = A35PacienteNombre ;
         obj8.gxTpr_Pacienteci = A41PacienteCI ;
         obj8.gxTpr_Medicoapellido = A14MedicoApellido ;
         obj8.gxTpr_Mediconombre = A13MedicoNombre ;
         obj8.gxTpr_Especialidadmaxpacientes = A11EspecialidadMaxPacientes ;
         obj8.gxTpr_Turnonombre = A61TurnoNombre ;
         obj8.gxTpr_Confirmado = A75Confirmado ;
         obj8.gxTpr_Consultafecha = A43ConsultaFecha ;
         obj8.gxTpr_Pacienteid = A34PacienteId ;
         obj8.gxTpr_Medicoid = A12MedicoId ;
         obj8.gxTpr_Turnoid = A60TurnoId ;
         obj8.gxTpr_Consultafecha_Z = Z43ConsultaFecha ;
         obj8.gxTpr_Pacienteid_Z = Z34PacienteId ;
         obj8.gxTpr_Pacienteapellido_Z = Z36PacienteApellido ;
         obj8.gxTpr_Pacientenombre_Z = Z35PacienteNombre ;
         obj8.gxTpr_Pacienteci_Z = Z41PacienteCI ;
         obj8.gxTpr_Medicoid_Z = Z12MedicoId ;
         obj8.gxTpr_Medicoapellido_Z = Z14MedicoApellido ;
         obj8.gxTpr_Mediconombre_Z = Z13MedicoNombre ;
         obj8.gxTpr_Especialidadmaxpacientes_Z = Z11EspecialidadMaxPacientes ;
         obj8.gxTpr_Turnoid_Z = Z60TurnoId ;
         obj8.gxTpr_Turnonombre_Z = Z61TurnoNombre ;
         obj8.gxTpr_Consultanro_Z = Z63ConsultaNro ;
         obj8.gxTpr_Confirmado_Z = Z75Confirmado ;
         obj8.gxTpr_Ultimonroasig_Z = Z67UltimoNroAsig ;
         obj8.gxTpr_Consultanro_N = (short)(Convert.ToInt16(n63ConsultaNro)) ;
         obj8.gxTpr_Ultimonroasig_N = (short)(Convert.ToInt16(n67UltimoNroAsig)) ;
         obj8.gxTpr_Mode = Gx_mode ;
         return  ;
      }

      public void RowToVars8( SdtGestionConsultaPaciente obj8 ,
                              int forceLoad )
      {
         Gx_mode = obj8.gxTpr_Mode ;
         A67UltimoNroAsig = obj8.gxTpr_Ultimonroasig ;
         n67UltimoNroAsig = false ;
         if ( forceLoad == 1 )
         {
            A63ConsultaNro = obj8.gxTpr_Consultanro ;
            n63ConsultaNro = false ;
         }
         A36PacienteApellido = obj8.gxTpr_Pacienteapellido ;
         A35PacienteNombre = obj8.gxTpr_Pacientenombre ;
         A41PacienteCI = obj8.gxTpr_Pacienteci ;
         A14MedicoApellido = obj8.gxTpr_Medicoapellido ;
         A13MedicoNombre = obj8.gxTpr_Mediconombre ;
         A11EspecialidadMaxPacientes = obj8.gxTpr_Especialidadmaxpacientes ;
         A61TurnoNombre = obj8.gxTpr_Turnonombre ;
         A75Confirmado = obj8.gxTpr_Confirmado ;
         A43ConsultaFecha = obj8.gxTpr_Consultafecha ;
         A34PacienteId = obj8.gxTpr_Pacienteid ;
         A12MedicoId = obj8.gxTpr_Medicoid ;
         A60TurnoId = obj8.gxTpr_Turnoid ;
         Z43ConsultaFecha = obj8.gxTpr_Consultafecha_Z ;
         Z34PacienteId = obj8.gxTpr_Pacienteid_Z ;
         Z36PacienteApellido = obj8.gxTpr_Pacienteapellido_Z ;
         Z35PacienteNombre = obj8.gxTpr_Pacientenombre_Z ;
         Z41PacienteCI = obj8.gxTpr_Pacienteci_Z ;
         Z12MedicoId = obj8.gxTpr_Medicoid_Z ;
         Z14MedicoApellido = obj8.gxTpr_Medicoapellido_Z ;
         Z13MedicoNombre = obj8.gxTpr_Mediconombre_Z ;
         Z11EspecialidadMaxPacientes = obj8.gxTpr_Especialidadmaxpacientes_Z ;
         Z60TurnoId = obj8.gxTpr_Turnoid_Z ;
         Z61TurnoNombre = obj8.gxTpr_Turnonombre_Z ;
         Z63ConsultaNro = obj8.gxTpr_Consultanro_Z ;
         Z75Confirmado = obj8.gxTpr_Confirmado_Z ;
         Z67UltimoNroAsig = obj8.gxTpr_Ultimonroasig_Z ;
         O67UltimoNroAsig = obj8.gxTpr_Ultimonroasig_Z ;
         n63ConsultaNro = (bool)(Convert.ToBoolean(obj8.gxTpr_Consultanro_N)) ;
         n67UltimoNroAsig = (bool)(Convert.ToBoolean(obj8.gxTpr_Ultimonroasig_N)) ;
         Gx_mode = obj8.gxTpr_Mode ;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist ;
         context.GX_msglist = LclMsgLst ;
         A43ConsultaFecha = (DateTime)getParm(obj,0) ;
         A34PacienteId = (int)getParm(obj,1) ;
         A12MedicoId = (int)getParm(obj,2) ;
         A60TurnoId = (short)getParm(obj,3) ;
         AnyError = 0 ;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0B8( ) ;
         ScanKeyStart0B8( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS" ;
            /* Using cursor BC000B15 */
            pr_default.execute(13, new Object[] {A34PacienteId});
            if ( (pr_default.getStatus(13) == 101) )
            {
               GX_msglist.addItem("No existe 'Paciente'.", "ForeignKeyNotFound", 1, "PACIENTEID");
               AnyError = 1 ;
            }
            A36PacienteApellido = BC000B15_A36PacienteApellido[0] ;
            A35PacienteNombre = BC000B15_A35PacienteNombre[0] ;
            A41PacienteCI = BC000B15_A41PacienteCI[0] ;
            pr_default.close(13);
            /* Using cursor BC000B16 */
            pr_default.execute(14, new Object[] {A12MedicoId});
            if ( (pr_default.getStatus(14) == 101) )
            {
               GX_msglist.addItem("No existe 'Médico'.", "ForeignKeyNotFound", 1, "MEDICOID");
               AnyError = 1 ;
            }
            A9EspecialidadId = BC000B16_A9EspecialidadId[0] ;
            A14MedicoApellido = BC000B16_A14MedicoApellido[0] ;
            A13MedicoNombre = BC000B16_A13MedicoNombre[0] ;
            pr_default.close(14);
            /* Using cursor BC000B17 */
            pr_default.execute(15, new Object[] {A9EspecialidadId});
            if ( (pr_default.getStatus(15) == 101) )
            {
               GX_msglist.addItem("No existe 'Especialidad'.", "ForeignKeyNotFound", 1, "");
               AnyError = 1 ;
            }
            A11EspecialidadMaxPacientes = BC000B17_A11EspecialidadMaxPacientes[0] ;
            pr_default.close(15);
            /* Using cursor BC000B18 */
            pr_default.execute(16, new Object[] {A60TurnoId});
            if ( (pr_default.getStatus(16) == 101) )
            {
               GX_msglist.addItem("No existe 'Turno'.", "ForeignKeyNotFound", 1, "TURNOID");
               AnyError = 1 ;
            }
            A61TurnoNombre = BC000B18_A61TurnoNombre[0] ;
            pr_default.close(16);
            /* Using cursor BC000B19 */
            pr_default.execute(17, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
            if ( (pr_default.getStatus(17) == 101) )
            {
               GX_msglist.addItem("No existe 'Consulta'.", "ForeignKeyNotFound", 1, "CONSULTAFECHA");
               AnyError = 1 ;
            }
            A67UltimoNroAsig = BC000B19_A67UltimoNroAsig[0] ;
            n67UltimoNroAsig = BC000B19_n67UltimoNroAsig[0] ;
            pr_default.close(17);
         }
         else
         {
            Gx_mode = "UPD" ;
            Z43ConsultaFecha = A43ConsultaFecha ;
            Z34PacienteId = A34PacienteId ;
            Z12MedicoId = A12MedicoId ;
            Z60TurnoId = A60TurnoId ;
            O67UltimoNroAsig = A67UltimoNroAsig ;
            n67UltimoNroAsig = false ;
         }
         ZM0B8( -5) ;
         sMode8 = Gx_mode ;
         Gx_mode = "DSP" ;
         OnLoadActions0B8( ) ;
         Gx_mode = sMode8 ;
         AddRow0B8( ) ;
         ScanKeyEnd0B8( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound"), "PrimaryKeyNotFound", 1, "");
            AnyError = 1 ;
         }
         context.GX_msglist = BackMsgLst ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist ;
         context.GX_msglist = LclMsgLst ;
         AnyError = 0 ;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1 ;
         RowToVars8( bcGestionConsultaPaciente, 0) ;
         nKeyPressed = 1 ;
         GetKey0B8( ) ;
         if ( RcdFound8 == 1 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate"), "DuplicatePrimaryKey", 1, "");
               AnyError = 1 ;
            }
            else if ( ( A43ConsultaFecha != Z43ConsultaFecha ) || ( A34PacienteId != Z34PacienteId ) || ( A12MedicoId != Z12MedicoId ) || ( A60TurnoId != Z60TurnoId ) )
            {
               A43ConsultaFecha = Z43ConsultaFecha ;
               A34PacienteId = Z34PacienteId ;
               A12MedicoId = Z12MedicoId ;
               A60TurnoId = Z60TurnoId ;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd"), "CandidateKeyNotFound", 1, "");
               AnyError = 1 ;
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               delete( ) ;
               AfterTrn( ) ;
            }
            else
            {
               Gx_mode = "UPD" ;
               /* Update record */
               Update0B8( ) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd"), "CandidateKeyNotFound", 1, "");
               AnyError = 1 ;
            }
            else
            {
               if ( ( A43ConsultaFecha != Z43ConsultaFecha ) || ( A34PacienteId != Z34PacienteId ) || ( A12MedicoId != Z12MedicoId ) || ( A60TurnoId != Z60TurnoId ) )
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd"), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1 ;
                  }
                  else
                  {
                     Gx_mode = "INS" ;
                     /* Insert record */
                     Insert0B8( ) ;
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted"), 1, "");
                     AnyError = 1 ;
                  }
                  else
                  {
                     Gx_mode = "INS" ;
                     /* Insert record */
                     Insert0B8( ) ;
                  }
               }
            }
         }
         AfterTrn( ) ;
         VarsToRow8( bcGestionConsultaPaciente) ;
         context.GX_msglist = BackMsgLst ;
         return  ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist ;
         context.GX_msglist = LclMsgLst ;
         AnyError = 0 ;
         context.GX_msglist.removeAllItems();
         RowToVars8( bcGestionConsultaPaciente, 0) ;
         nKeyPressed = 3 ;
         IsConfirmed = 0 ;
         GetKey0B8( ) ;
         if ( RcdFound8 == 1 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate"), "DuplicatePrimaryKey", 1, "");
               AnyError = 1 ;
            }
            else if ( ( A43ConsultaFecha != Z43ConsultaFecha ) || ( A34PacienteId != Z34PacienteId ) || ( A12MedicoId != Z12MedicoId ) || ( A60TurnoId != Z60TurnoId ) )
            {
               A43ConsultaFecha = Z43ConsultaFecha ;
               A34PacienteId = Z34PacienteId ;
               A12MedicoId = Z12MedicoId ;
               A60TurnoId = Z60TurnoId ;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd"), "DuplicatePrimaryKey", 1, "");
               AnyError = 1 ;
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD" ;
               update_Check( ) ;
            }
         }
         else
         {
            if ( ( A43ConsultaFecha != Z43ConsultaFecha ) || ( A34PacienteId != Z34PacienteId ) || ( A12MedicoId != Z12MedicoId ) || ( A60TurnoId != Z60TurnoId ) )
            {
               Gx_mode = "INS" ;
               insert_Check( ) ;
            }
            else
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted"), 1, "");
                  AnyError = 1 ;
               }
               else
               {
                  Gx_mode = "INS" ;
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         pr_default.close(14);
         pr_default.close(16);
         pr_default.close(17);
         pr_default.close(13);
         pr_default.close(15);
         context.RollbackDataStores("GestionConsultaPaciente_BC");
         VarsToRow8( bcGestionConsultaPaciente) ;
         context.GX_msglist = BackMsgLst ;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public String GetMode( )
      {
         Gx_mode = bcGestionConsultaPaciente.gxTpr_Mode ;
         return Gx_mode ;
      }

      public void SetMode( String lMode )
      {
         Gx_mode = lMode ;
         bcGestionConsultaPaciente.gxTpr_Mode = Gx_mode ;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcGestionConsultaPaciente )
         {
            bcGestionConsultaPaciente = (SdtGestionConsultaPaciente)(sdt) ;
            if ( StringUtil.StrCmp(bcGestionConsultaPaciente.gxTpr_Mode, "") == 0 )
            {
               bcGestionConsultaPaciente.gxTpr_Mode = "INS" ;
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow8( bcGestionConsultaPaciente) ;
            }
            else
            {
               RowToVars8( bcGestionConsultaPaciente, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcGestionConsultaPaciente.gxTpr_Mode, "") == 0 )
            {
               bcGestionConsultaPaciente.gxTpr_Mode = "INS" ;
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars8( bcGestionConsultaPaciente, 1) ;
         return  ;
      }

      public SdtGestionConsultaPaciente GestionConsultaPaciente_BC
      {
         get {
            return bcGestionConsultaPaciente ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
      }

      protected override void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      protected void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections() ;
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(17);
         pr_default.close(13);
         pr_default.close(14);
         pr_default.close(15);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         scmdbuf = "" ;
         PreviousTooltip = "" ;
         PreviousCaption = "" ;
         Gx_mode = "" ;
         Z43ConsultaFecha = DateTime.MinValue ;
         A43ConsultaFecha = DateTime.MinValue ;
         Z14MedicoApellido = "" ;
         A14MedicoApellido = "" ;
         Z13MedicoNombre = "" ;
         A13MedicoNombre = "" ;
         Z61TurnoNombre = "" ;
         A61TurnoNombre = "" ;
         Z36PacienteApellido = "" ;
         A36PacienteApellido = "" ;
         Z35PacienteNombre = "" ;
         A35PacienteNombre = "" ;
         Z41PacienteCI = "" ;
         A41PacienteCI = "" ;
         Gx_date = DateTime.MinValue ;
         BC000B10_A9EspecialidadId = new int[1] ;
         BC000B10_A67UltimoNroAsig = new short[1] ;
         BC000B10_n67UltimoNroAsig = new bool[] {false} ;
         BC000B10_A63ConsultaNro = new short[1] ;
         BC000B10_n63ConsultaNro = new bool[] {false} ;
         BC000B10_A36PacienteApellido = new String[] {""} ;
         BC000B10_A35PacienteNombre = new String[] {""} ;
         BC000B10_A41PacienteCI = new String[] {""} ;
         BC000B10_A14MedicoApellido = new String[] {""} ;
         BC000B10_A13MedicoNombre = new String[] {""} ;
         BC000B10_A11EspecialidadMaxPacientes = new short[1] ;
         BC000B10_A61TurnoNombre = new String[] {""} ;
         BC000B10_A75Confirmado = new bool[] {false} ;
         BC000B10_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         BC000B10_A12MedicoId = new int[1] ;
         BC000B10_A60TurnoId = new short[1] ;
         BC000B10_A34PacienteId = new int[1] ;
         BC000B8_A36PacienteApellido = new String[] {""} ;
         BC000B8_A35PacienteNombre = new String[] {""} ;
         BC000B8_A41PacienteCI = new String[] {""} ;
         BC000B4_A9EspecialidadId = new int[1] ;
         BC000B4_A14MedicoApellido = new String[] {""} ;
         BC000B4_A13MedicoNombre = new String[] {""} ;
         BC000B9_A11EspecialidadMaxPacientes = new short[1] ;
         BC000B5_A61TurnoNombre = new String[] {""} ;
         BC000B7_A67UltimoNroAsig = new short[1] ;
         BC000B7_n67UltimoNroAsig = new bool[] {false} ;
         BC000B11_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         BC000B11_A34PacienteId = new int[1] ;
         BC000B11_A12MedicoId = new int[1] ;
         BC000B11_A60TurnoId = new short[1] ;
         BC000B3_A63ConsultaNro = new short[1] ;
         BC000B3_n63ConsultaNro = new bool[] {false} ;
         BC000B3_A75Confirmado = new bool[] {false} ;
         BC000B3_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         BC000B3_A12MedicoId = new int[1] ;
         BC000B3_A60TurnoId = new short[1] ;
         BC000B3_A34PacienteId = new int[1] ;
         sMode8 = "" ;
         BC000B2_A63ConsultaNro = new short[1] ;
         BC000B2_n63ConsultaNro = new bool[] {false} ;
         BC000B2_A75Confirmado = new bool[] {false} ;
         BC000B2_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         BC000B2_A12MedicoId = new int[1] ;
         BC000B2_A60TurnoId = new short[1] ;
         BC000B2_A34PacienteId = new int[1] ;
         BC000B6_A67UltimoNroAsig = new short[1] ;
         BC000B6_n67UltimoNroAsig = new bool[] {false} ;
         BC000B15_A36PacienteApellido = new String[] {""} ;
         BC000B15_A35PacienteNombre = new String[] {""} ;
         BC000B15_A41PacienteCI = new String[] {""} ;
         BC000B16_A9EspecialidadId = new int[1] ;
         BC000B16_A14MedicoApellido = new String[] {""} ;
         BC000B16_A13MedicoNombre = new String[] {""} ;
         BC000B17_A11EspecialidadMaxPacientes = new short[1] ;
         BC000B18_A61TurnoNombre = new String[] {""} ;
         BC000B19_A67UltimoNroAsig = new short[1] ;
         BC000B19_n67UltimoNroAsig = new bool[] {false} ;
         BC000B21_A9EspecialidadId = new int[1] ;
         BC000B21_A67UltimoNroAsig = new short[1] ;
         BC000B21_n67UltimoNroAsig = new bool[] {false} ;
         BC000B21_A63ConsultaNro = new short[1] ;
         BC000B21_n63ConsultaNro = new bool[] {false} ;
         BC000B21_A36PacienteApellido = new String[] {""} ;
         BC000B21_A35PacienteNombre = new String[] {""} ;
         BC000B21_A41PacienteCI = new String[] {""} ;
         BC000B21_A14MedicoApellido = new String[] {""} ;
         BC000B21_A13MedicoNombre = new String[] {""} ;
         BC000B21_A11EspecialidadMaxPacientes = new short[1] ;
         BC000B21_A61TurnoNombre = new String[] {""} ;
         BC000B21_A75Confirmado = new bool[] {false} ;
         BC000B21_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         BC000B21_A12MedicoId = new int[1] ;
         BC000B21_A60TurnoId = new short[1] ;
         BC000B21_A34PacienteId = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gestionconsultapaciente_bc__default(),
            new Object[][] {
                new Object[] {
               BC000B2_A63ConsultaNro, BC000B2_n63ConsultaNro, BC000B2_A75Confirmado, BC000B2_A43ConsultaFecha, BC000B2_A12MedicoId, BC000B2_A60TurnoId, BC000B2_A34PacienteId
               }
               , new Object[] {
               BC000B3_A63ConsultaNro, BC000B3_n63ConsultaNro, BC000B3_A75Confirmado, BC000B3_A43ConsultaFecha, BC000B3_A12MedicoId, BC000B3_A60TurnoId, BC000B3_A34PacienteId
               }
               , new Object[] {
               BC000B4_A9EspecialidadId, BC000B4_A14MedicoApellido, BC000B4_A13MedicoNombre
               }
               , new Object[] {
               BC000B5_A61TurnoNombre
               }
               , new Object[] {
               BC000B6_A67UltimoNroAsig, BC000B6_n67UltimoNroAsig
               }
               , new Object[] {
               BC000B7_A67UltimoNroAsig, BC000B7_n67UltimoNroAsig
               }
               , new Object[] {
               BC000B8_A36PacienteApellido, BC000B8_A35PacienteNombre, BC000B8_A41PacienteCI
               }
               , new Object[] {
               BC000B9_A11EspecialidadMaxPacientes
               }
               , new Object[] {
               BC000B10_A9EspecialidadId, BC000B10_A67UltimoNroAsig, BC000B10_n67UltimoNroAsig, BC000B10_A63ConsultaNro, BC000B10_n63ConsultaNro, BC000B10_A36PacienteApellido, BC000B10_A35PacienteNombre, BC000B10_A41PacienteCI, BC000B10_A14MedicoApellido, BC000B10_A13MedicoNombre,
               BC000B10_A11EspecialidadMaxPacientes, BC000B10_A61TurnoNombre, BC000B10_A75Confirmado, BC000B10_A43ConsultaFecha, BC000B10_A12MedicoId, BC000B10_A60TurnoId, BC000B10_A34PacienteId
               }
               , new Object[] {
               BC000B11_A43ConsultaFecha, BC000B11_A34PacienteId, BC000B11_A12MedicoId, BC000B11_A60TurnoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000B15_A36PacienteApellido, BC000B15_A35PacienteNombre, BC000B15_A41PacienteCI
               }
               , new Object[] {
               BC000B16_A9EspecialidadId, BC000B16_A14MedicoApellido, BC000B16_A13MedicoNombre
               }
               , new Object[] {
               BC000B17_A11EspecialidadMaxPacientes
               }
               , new Object[] {
               BC000B18_A61TurnoNombre
               }
               , new Object[] {
               BC000B19_A67UltimoNroAsig, BC000B19_n67UltimoNroAsig
               }
               , new Object[] {
               }
               , new Object[] {
               BC000B21_A9EspecialidadId, BC000B21_A67UltimoNroAsig, BC000B21_n67UltimoNroAsig, BC000B21_A63ConsultaNro, BC000B21_n63ConsultaNro, BC000B21_A36PacienteApellido, BC000B21_A35PacienteNombre, BC000B21_A41PacienteCI, BC000B21_A14MedicoApellido, BC000B21_A13MedicoNombre,
               BC000B21_A11EspecialidadMaxPacientes, BC000B21_A61TurnoNombre, BC000B21_A75Confirmado, BC000B21_A43ConsultaFecha, BC000B21_A12MedicoId, BC000B21_A60TurnoId, BC000B21_A34PacienteId
               }
            }
         );
         Z43ConsultaFecha = Gx_date ;
         Gx_date = DateTimeUtil.Today( ) ;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: E120B2 */
         E120B2 ();
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z60TurnoId ;
      private short A60TurnoId ;
      private short GX_JID ;
      private short Z63ConsultaNro ;
      private short A63ConsultaNro ;
      private short Z11EspecialidadMaxPacientes ;
      private short A11EspecialidadMaxPacientes ;
      private short Z67UltimoNroAsig ;
      private short A67UltimoNroAsig ;
      private short Gx_BScreen ;
      private short RcdFound8 ;
      private short O67UltimoNroAsig ;
      private int trnEnded ;
      private int Z34PacienteId ;
      private int A34PacienteId ;
      private int Z12MedicoId ;
      private int A12MedicoId ;
      private int Z9EspecialidadId ;
      private int A9EspecialidadId ;
      private String scmdbuf ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String Gx_mode ;
      private String Z14MedicoApellido ;
      private String A14MedicoApellido ;
      private String Z13MedicoNombre ;
      private String A13MedicoNombre ;
      private String Z61TurnoNombre ;
      private String A61TurnoNombre ;
      private String Z36PacienteApellido ;
      private String A36PacienteApellido ;
      private String Z35PacienteNombre ;
      private String A35PacienteNombre ;
      private String Z41PacienteCI ;
      private String A41PacienteCI ;
      private String sMode8 ;
      private DateTime Z43ConsultaFecha ;
      private DateTime A43ConsultaFecha ;
      private DateTime Gx_date ;
      private bool Z75Confirmado ;
      private bool A75Confirmado ;
      private bool n67UltimoNroAsig ;
      private bool n63ConsultaNro ;
      private SdtGestionConsultaPaciente bcGestionConsultaPaciente ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000B10_A9EspecialidadId ;
      private short[] BC000B10_A67UltimoNroAsig ;
      private bool[] BC000B10_n67UltimoNroAsig ;
      private short[] BC000B10_A63ConsultaNro ;
      private bool[] BC000B10_n63ConsultaNro ;
      private String[] BC000B10_A36PacienteApellido ;
      private String[] BC000B10_A35PacienteNombre ;
      private String[] BC000B10_A41PacienteCI ;
      private String[] BC000B10_A14MedicoApellido ;
      private String[] BC000B10_A13MedicoNombre ;
      private short[] BC000B10_A11EspecialidadMaxPacientes ;
      private String[] BC000B10_A61TurnoNombre ;
      private bool[] BC000B10_A75Confirmado ;
      private DateTime[] BC000B10_A43ConsultaFecha ;
      private int[] BC000B10_A12MedicoId ;
      private short[] BC000B10_A60TurnoId ;
      private int[] BC000B10_A34PacienteId ;
      private String[] BC000B8_A36PacienteApellido ;
      private String[] BC000B8_A35PacienteNombre ;
      private String[] BC000B8_A41PacienteCI ;
      private int[] BC000B4_A9EspecialidadId ;
      private String[] BC000B4_A14MedicoApellido ;
      private String[] BC000B4_A13MedicoNombre ;
      private short[] BC000B9_A11EspecialidadMaxPacientes ;
      private String[] BC000B5_A61TurnoNombre ;
      private short[] BC000B7_A67UltimoNroAsig ;
      private bool[] BC000B7_n67UltimoNroAsig ;
      private DateTime[] BC000B11_A43ConsultaFecha ;
      private int[] BC000B11_A34PacienteId ;
      private int[] BC000B11_A12MedicoId ;
      private short[] BC000B11_A60TurnoId ;
      private short[] BC000B3_A63ConsultaNro ;
      private bool[] BC000B3_n63ConsultaNro ;
      private bool[] BC000B3_A75Confirmado ;
      private DateTime[] BC000B3_A43ConsultaFecha ;
      private int[] BC000B3_A12MedicoId ;
      private short[] BC000B3_A60TurnoId ;
      private int[] BC000B3_A34PacienteId ;
      private short[] BC000B2_A63ConsultaNro ;
      private bool[] BC000B2_n63ConsultaNro ;
      private bool[] BC000B2_A75Confirmado ;
      private DateTime[] BC000B2_A43ConsultaFecha ;
      private int[] BC000B2_A12MedicoId ;
      private short[] BC000B2_A60TurnoId ;
      private int[] BC000B2_A34PacienteId ;
      private short[] BC000B6_A67UltimoNroAsig ;
      private bool[] BC000B6_n67UltimoNroAsig ;
      private String[] BC000B15_A36PacienteApellido ;
      private String[] BC000B15_A35PacienteNombre ;
      private String[] BC000B15_A41PacienteCI ;
      private int[] BC000B16_A9EspecialidadId ;
      private String[] BC000B16_A14MedicoApellido ;
      private String[] BC000B16_A13MedicoNombre ;
      private short[] BC000B17_A11EspecialidadMaxPacientes ;
      private String[] BC000B18_A61TurnoNombre ;
      private short[] BC000B19_A67UltimoNroAsig ;
      private bool[] BC000B19_n67UltimoNroAsig ;
      private int[] BC000B21_A9EspecialidadId ;
      private short[] BC000B21_A67UltimoNroAsig ;
      private bool[] BC000B21_n67UltimoNroAsig ;
      private short[] BC000B21_A63ConsultaNro ;
      private bool[] BC000B21_n63ConsultaNro ;
      private String[] BC000B21_A36PacienteApellido ;
      private String[] BC000B21_A35PacienteNombre ;
      private String[] BC000B21_A41PacienteCI ;
      private String[] BC000B21_A14MedicoApellido ;
      private String[] BC000B21_A13MedicoNombre ;
      private short[] BC000B21_A11EspecialidadMaxPacientes ;
      private String[] BC000B21_A61TurnoNombre ;
      private bool[] BC000B21_A75Confirmado ;
      private DateTime[] BC000B21_A43ConsultaFecha ;
      private int[] BC000B21_A12MedicoId ;
      private short[] BC000B21_A60TurnoId ;
      private int[] BC000B21_A34PacienteId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class gestionconsultapaciente_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000B10 ;
          prmBC000B10 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0} ,
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmBC000B8 ;
          prmBC000B8 = new Object[] {
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmBC000B4 ;
          prmBC000B4 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmBC000B9 ;
          prmBC000B9 = new Object[] {
          new Object[] {"@EspecialidadId",SqlDbType.Int,6,0}
          } ;
          Object[] prmBC000B5 ;
          prmBC000B5 = new Object[] {
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmBC000B7 ;
          prmBC000B7 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmBC000B11 ;
          prmBC000B11 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@PacienteId",SqlDbType.Int,6,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmBC000B3 ;
          prmBC000B3 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@PacienteId",SqlDbType.Int,6,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmBC000B2 ;
          prmBC000B2 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@PacienteId",SqlDbType.Int,6,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmBC000B6 ;
          prmBC000B6 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmBC000B12 ;
          prmBC000B12 = new Object[] {
          new Object[] {"@ConsultaNro",SqlDbType.SmallInt,2,0} ,
          new Object[] {"@Confirmado",SqlDbType.Bit,4,0} ,
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0} ,
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmBC000B13 ;
          prmBC000B13 = new Object[] {
          new Object[] {"@ConsultaNro",SqlDbType.SmallInt,2,0} ,
          new Object[] {"@Confirmado",SqlDbType.Bit,4,0} ,
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@PacienteId",SqlDbType.Int,6,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmBC000B14 ;
          prmBC000B14 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@PacienteId",SqlDbType.Int,6,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmBC000B20 ;
          prmBC000B20 = new Object[] {
          new Object[] {"@UltimoNroAsig",SqlDbType.SmallInt,2,0} ,
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmBC000B21 ;
          prmBC000B21 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0} ,
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmBC000B15 ;
          prmBC000B15 = new Object[] {
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmBC000B16 ;
          prmBC000B16 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmBC000B17 ;
          prmBC000B17 = new Object[] {
          new Object[] {"@EspecialidadId",SqlDbType.Int,6,0}
          } ;
          Object[] prmBC000B18 ;
          prmBC000B18 = new Object[] {
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmBC000B19 ;
          prmBC000B19 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("BC000B2", "SELECT [ConsultaNro], [Confirmado], [ConsultaFecha], [MedicoId], [TurnoId], [PacienteId] FROM [ConsultaPaciente] WITH (UPDLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [PacienteId] = @PacienteId AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B2,1,0,true,false )
             ,new CursorDef("BC000B3", "SELECT [ConsultaNro], [Confirmado], [ConsultaFecha], [MedicoId], [TurnoId], [PacienteId] FROM [ConsultaPaciente] WITH (NOLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [PacienteId] = @PacienteId AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B3,1,0,true,false )
             ,new CursorDef("BC000B4", "SELECT [EspecialidadId], [MedicoApellido], [MedicoNombre] FROM [Medico] WITH (NOLOCK) WHERE [MedicoId] = @MedicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B4,1,0,true,false )
             ,new CursorDef("BC000B5", "SELECT [TurnoNombre] FROM [Turno] WITH (NOLOCK) WHERE [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B5,1,0,true,false )
             ,new CursorDef("BC000B6", "SELECT [UltimoNroAsig] FROM [Consulta] WITH (UPDLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B6,1,0,true,false )
             ,new CursorDef("BC000B7", "SELECT [UltimoNroAsig] FROM [Consulta] WITH (NOLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B7,1,0,true,false )
             ,new CursorDef("BC000B8", "SELECT [PacienteApellido], [PacienteNombre], [PacienteCI] FROM [Paciente] WITH (NOLOCK) WHERE [PacienteId] = @PacienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B8,1,0,true,false )
             ,new CursorDef("BC000B9", "SELECT [EspecialidadMaxPacientes] FROM [Especialidad] WITH (NOLOCK) WHERE [EspecialidadId] = @EspecialidadId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B9,1,0,true,false )
             ,new CursorDef("BC000B10", "SELECT T3.[EspecialidadId], T6.[UltimoNroAsig], TM1.[ConsultaNro], T2.[PacienteApellido], T2.[PacienteNombre], T2.[PacienteCI], T3.[MedicoApellido], T3.[MedicoNombre], T4.[EspecialidadMaxPacientes], T5.[TurnoNombre], TM1.[Confirmado], TM1.[ConsultaFecha], TM1.[MedicoId], TM1.[TurnoId], TM1.[PacienteId] FROM ((((([ConsultaPaciente] TM1 WITH (NOLOCK) INNER JOIN [Paciente] T2 WITH (NOLOCK) ON T2.[PacienteId] = TM1.[PacienteId]) INNER JOIN [Medico] T3 WITH (NOLOCK) ON T3.[MedicoId] = TM1.[MedicoId]) INNER JOIN [Especialidad] T4 WITH (NOLOCK) ON T4.[EspecialidadId] = T3.[EspecialidadId]) INNER JOIN [Turno] T5 WITH (NOLOCK) ON T5.[TurnoId] = TM1.[TurnoId]) INNER JOIN [Consulta] T6 WITH (NOLOCK) ON T6.[ConsultaFecha] = TM1.[ConsultaFecha] AND T6.[MedicoId] = TM1.[MedicoId] AND T6.[TurnoId] = TM1.[TurnoId]) WHERE TM1.[ConsultaFecha] = @ConsultaFecha and TM1.[MedicoId] = @MedicoId and TM1.[TurnoId] = @TurnoId and TM1.[PacienteId] = @PacienteId ORDER BY TM1.[ConsultaFecha], TM1.[PacienteId], TM1.[MedicoId], TM1.[TurnoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B10,100,0,true,false )
             ,new CursorDef("BC000B11", "SELECT [ConsultaFecha], [PacienteId], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [PacienteId] = @PacienteId AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B11,1,0,true,false )
             ,new CursorDef("BC000B12", "INSERT INTO [ConsultaPaciente] ([ConsultaNro], [Confirmado], [ConsultaFecha], [MedicoId], [TurnoId], [PacienteId], [MotivoConsulta], [AnotacionesConsulta]) VALUES (@ConsultaNro, @Confirmado, @ConsultaFecha, @MedicoId, @TurnoId, @PacienteId, '', '')", GxErrorMask.GX_NOMASK,prmBC000B12)
             ,new CursorDef("BC000B13", "UPDATE [ConsultaPaciente] SET [ConsultaNro]=@ConsultaNro, [Confirmado]=@Confirmado  WHERE [ConsultaFecha] = @ConsultaFecha AND [PacienteId] = @PacienteId AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId", GxErrorMask.GX_NOMASK,prmBC000B13)
             ,new CursorDef("BC000B14", "DELETE FROM [ConsultaPaciente]  WHERE [ConsultaFecha] = @ConsultaFecha AND [PacienteId] = @PacienteId AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId", GxErrorMask.GX_NOMASK,prmBC000B14)
             ,new CursorDef("BC000B15", "SELECT [PacienteApellido], [PacienteNombre], [PacienteCI] FROM [Paciente] WITH (NOLOCK) WHERE [PacienteId] = @PacienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B15,1,0,true,false )
             ,new CursorDef("BC000B16", "SELECT [EspecialidadId], [MedicoApellido], [MedicoNombre] FROM [Medico] WITH (NOLOCK) WHERE [MedicoId] = @MedicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B16,1,0,true,false )
             ,new CursorDef("BC000B17", "SELECT [EspecialidadMaxPacientes] FROM [Especialidad] WITH (NOLOCK) WHERE [EspecialidadId] = @EspecialidadId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B17,1,0,true,false )
             ,new CursorDef("BC000B18", "SELECT [TurnoNombre] FROM [Turno] WITH (NOLOCK) WHERE [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B18,1,0,true,false )
             ,new CursorDef("BC000B19", "SELECT [UltimoNroAsig] FROM [Consulta] WITH (NOLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B19,1,0,true,false )
             ,new CursorDef("BC000B20", "UPDATE [Consulta] SET [UltimoNroAsig]=@UltimoNroAsig  WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId", GxErrorMask.GX_NOMASK,prmBC000B20)
             ,new CursorDef("BC000B21", "SELECT T3.[EspecialidadId], T6.[UltimoNroAsig], TM1.[ConsultaNro], T2.[PacienteApellido], T2.[PacienteNombre], T2.[PacienteCI], T3.[MedicoApellido], T3.[MedicoNombre], T4.[EspecialidadMaxPacientes], T5.[TurnoNombre], TM1.[Confirmado], TM1.[ConsultaFecha], TM1.[MedicoId], TM1.[TurnoId], TM1.[PacienteId] FROM ((((([ConsultaPaciente] TM1 WITH (NOLOCK) INNER JOIN [Paciente] T2 WITH (NOLOCK) ON T2.[PacienteId] = TM1.[PacienteId]) INNER JOIN [Medico] T3 WITH (NOLOCK) ON T3.[MedicoId] = TM1.[MedicoId]) INNER JOIN [Especialidad] T4 WITH (NOLOCK) ON T4.[EspecialidadId] = T3.[EspecialidadId]) INNER JOIN [Turno] T5 WITH (NOLOCK) ON T5.[TurnoId] = TM1.[TurnoId]) INNER JOIN [Consulta] T6 WITH (NOLOCK) ON T6.[ConsultaFecha] = TM1.[ConsultaFecha] AND T6.[MedicoId] = TM1.[MedicoId] AND T6.[TurnoId] = TM1.[TurnoId]) WHERE TM1.[ConsultaFecha] = @ConsultaFecha and TM1.[MedicoId] = @MedicoId and TM1.[TurnoId] = @TurnoId and TM1.[PacienteId] = @PacienteId ORDER BY TM1.[ConsultaFecha], TM1.[PacienteId], TM1.[MedicoId], TM1.[TurnoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B21,100,0,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2) ;
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3) ;
                ((int[]) buf[4])[0] = rslt.getInt(4) ;
                ((short[]) buf[5])[0] = rslt.getShort(5) ;
                ((int[]) buf[6])[0] = rslt.getInt(6) ;
                break;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2) ;
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3) ;
                ((int[]) buf[4])[0] = rslt.getInt(4) ;
                ((short[]) buf[5])[0] = rslt.getShort(5) ;
                ((int[]) buf[6])[0] = rslt.getInt(6) ;
                break;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                break;
             case 3 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                break;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                break;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                break;
             case 6 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 8) ;
                break;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                break;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((String[]) buf[5])[0] = rslt.getString(4, 20) ;
                ((String[]) buf[6])[0] = rslt.getString(5, 20) ;
                ((String[]) buf[7])[0] = rslt.getString(6, 8) ;
                ((String[]) buf[8])[0] = rslt.getString(7, 20) ;
                ((String[]) buf[9])[0] = rslt.getString(8, 20) ;
                ((short[]) buf[10])[0] = rslt.getShort(9) ;
                ((String[]) buf[11])[0] = rslt.getString(10, 20) ;
                ((bool[]) buf[12])[0] = rslt.getBool(11) ;
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(12) ;
                ((int[]) buf[14])[0] = rslt.getInt(13) ;
                ((short[]) buf[15])[0] = rslt.getShort(14) ;
                ((int[]) buf[16])[0] = rslt.getInt(15) ;
                break;
             case 9 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                ((short[]) buf[3])[0] = rslt.getShort(4) ;
                break;
             case 13 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 8) ;
                break;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                break;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                break;
             case 16 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                break;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                break;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((String[]) buf[5])[0] = rslt.getString(4, 20) ;
                ((String[]) buf[6])[0] = rslt.getString(5, 20) ;
                ((String[]) buf[7])[0] = rslt.getString(6, 8) ;
                ((String[]) buf[8])[0] = rslt.getString(7, 20) ;
                ((String[]) buf[9])[0] = rslt.getString(8, 20) ;
                ((short[]) buf[10])[0] = rslt.getShort(9) ;
                ((String[]) buf[11])[0] = rslt.getString(10, 20) ;
                ((bool[]) buf[12])[0] = rslt.getBool(11) ;
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(12) ;
                ((int[]) buf[14])[0] = rslt.getInt(13) ;
                ((short[]) buf[15])[0] = rslt.getShort(14) ;
                ((int[]) buf[16])[0] = rslt.getInt(15) ;
                break;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
             case 0 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                stmt.SetParameter(4, (short)parms[3]);
                break;
             case 1 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                stmt.SetParameter(4, (short)parms[3]);
                break;
             case 2 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 3 :
                stmt.SetParameter(1, (short)parms[0]);
                break;
             case 4 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 5 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 6 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 7 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 8 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                stmt.SetParameter(4, (int)parms[3]);
                break;
             case 9 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                stmt.SetParameter(4, (short)parms[3]);
                break;
             case 10 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(1, (short)parms[1]);
                }
                stmt.SetParameter(2, (bool)parms[2]);
                stmt.SetParameter(3, (DateTime)parms[3]);
                stmt.SetParameter(4, (int)parms[4]);
                stmt.SetParameter(5, (short)parms[5]);
                stmt.SetParameter(6, (int)parms[6]);
                break;
             case 11 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(1, (short)parms[1]);
                }
                stmt.SetParameter(2, (bool)parms[2]);
                stmt.SetParameter(3, (DateTime)parms[3]);
                stmt.SetParameter(4, (int)parms[4]);
                stmt.SetParameter(5, (int)parms[5]);
                stmt.SetParameter(6, (short)parms[6]);
                break;
             case 12 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                stmt.SetParameter(4, (short)parms[3]);
                break;
             case 13 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 14 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 15 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 16 :
                stmt.SetParameter(1, (short)parms[0]);
                break;
             case 17 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 18 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(1, (short)parms[1]);
                }
                stmt.SetParameter(2, (DateTime)parms[2]);
                stmt.SetParameter(3, (int)parms[3]);
                stmt.SetParameter(4, (short)parms[4]);
                break;
             case 19 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                stmt.SetParameter(4, (int)parms[3]);
                break;
       }
    }

 }

}
