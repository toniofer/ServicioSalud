/*
               File: HistoriaClinica
        Description: Historia Clinica
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/24/2010 5:34:31.55
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
   public class historiaclinica : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false ;
         gxfirstwebparm = GetNextPar( ) ;
         gxfirstwebparm_bkp = gxfirstwebparm ;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm, "High") ;
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"TURNOID") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            GXDLATURNOID0A8( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A34PacienteId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            gxLoad_21( A34PacienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A12MedicoId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            gxLoad_18( A12MedicoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
         {
            A9EspecialidadId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            gxLoad_22( A9EspecialidadId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A60TurnoId = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            gxLoad_19( A60TurnoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A43ConsultaFecha = context.localUtil.ParseDateParm( GetNextPar( )) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            A12MedicoId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            A60TurnoId = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            gxLoad_20( A43ConsultaFecha, A12MedicoId, A60TurnoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            gxfirstwebparm = GetNextPar( ) ;
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1 ;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp ;
         }
         if ( ! entryPointCalled )
         {
            Gx_mode = gxfirstwebparm ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV15ConsultaFecha = context.localUtil.ParseDateParm( GetNextPar( )) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV15ConsultaFecha", context.localUtil.Format(AV15ConsultaFecha, "99/99/99"));
               AV16PacienteId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV16PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV16PacienteId), 6, 0)));
               AV17MedicoId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV17MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV17MedicoId), 6, 0)));
               AV18TurnoId = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV18TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV18TurnoId), 2, 0)));
            }
         }
         dynTurnoId.Name = "TURNOID" ;
         dynTurnoId.WebTags = "" ;
         Form.Meta.addItem("Generator", "GeneXus C#", 0) ;
         Form.Meta.addItem("Version", "10_1_3-34981", 0) ;
         Form.Meta.addItem("Description", "Historia Clinica", 0) ;
         context.wjLoc = "" ;
         context.nUserReturn = 0 ;
         context.wbHandled = 0 ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         GX_FocusControl = edtConsultaFecha_Internalname ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         wbErr = false ;
         context.SetTheme("GeneXusX");
      }

      public historiaclinica( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public historiaclinica( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default") ;
      }

      public void release( )
      {
      }

      public void execute( String aP0_Gx_mode ,
                           DateTime aP1_ConsultaFecha ,
                           int aP2_PacienteId ,
                           int aP3_MedicoId ,
                           short aP4_TurnoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV15ConsultaFecha = aP1_ConsultaFecha;
         this.AV16PacienteId = aP2_PacienteId;
         this.AV17MedicoId = aP3_MedicoId;
         this.AV18TurnoId = aP4_TurnoId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynTurnoId = new GXCombobox();
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("appmasterpage", "GeneXus.Programs.appmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            MasterPageObj.webExecute();
            if ( context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "max-age=0");
               }
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) )
               {
                  context.GX_webresponse.AddString((String)(context.getJSONResponse( )));
               }
               else
               {
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            wb_table1_2_0A8( true) ;
         }
         return  ;
      }

      protected void wb_table1_2_0A8e( bool wbgen )
      {
         if ( wbgen )
         {
         }
         /* Execute Exit event if defined. */
      }

      protected void wb_table1_2_0A8( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTablemain_Internalname, tblTablemain_Internalname, "", "TableBorder100x100", 0, "", "", 1, 2, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_5_0A8( true) ;
         }
         return  ;
      }

      protected void wb_table2_5_0A8e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Control Group */
            ClassString = "Group" ;
            StyleString = "" ;
            context.WriteHtmlText( "<fieldset id=\""+grpGroupdata_Internalname+"\""+" style=\"-moz-border-radius:3pt;\""+" class=\""+ClassString+"\">") ;
            context.WriteHtmlText( "<legend class=\""+ClassString+"Title"+"\">"+"Historia Clinica"+"</legend>") ;
            wb_table3_27_0A8( true) ;
         }
         return  ;
      }

      protected void wb_table3_27_0A8e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</fieldset>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_2_0A8e( true) ;
         }
         else
         {
            wb_table1_2_0A8e( false) ;
         }
      }

      protected void wb_table3_27_0A8( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTable1_Internalname, tblTable1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            ClassString = "ErrorViewer" ;
            StyleString = "" ;
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table4_33_0A8( true) ;
         }
         return  ;
      }

      protected void wb_table4_33_0A8e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"" ;
            ClassString = "BtnEnter" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtn_enter_Internalname, "Confirmar", "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, 1, "rounded", 5, bttBtn_enter_Jsonclick, "EENTER.", TempTags, "", "", "HLP_HistoriaClinica.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"" ;
            ClassString = "BtnCancel" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtn_cancel_Internalname, "Cancelar", "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "rounded", 1, bttBtn_cancel_Jsonclick, "ECANCEL.", TempTags, "", "", "HLP_HistoriaClinica.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"" ;
            ClassString = "BtnDelete" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtn_delete_Internalname, "Eliminar", "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, 0, "rounded", 5, bttBtn_delete_Jsonclick, "EDELETE.", TempTags, "", "", "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_27_0A8e( true) ;
         }
         else
         {
            wb_table3_27_0A8e( false) ;
         }
      }

      protected void wb_table4_33_0A8( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTable2_Internalname, tblTable2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockconsultafecha_Internalname, 1, 1, 0, "Consulta Fecha", "", "", "", 0, lblTextblockconsultafecha_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            if ( ( edtConsultaFecha_Enabled == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlText( "<table id=\""+edtConsultaFecha_Internalname+"_dp_container\" cellpadding=\"0\" cellspacing=\"0\"><tr><td>") ;
            }
            GxWebStd.gx_single_line_edit( context, edtConsultaFecha_Internalname, context.localUtil.Format(A43ConsultaFecha, "99/99/99"), "", 8, "chr", 1, "row", 8, 1, edtConsultaFecha_Enabled, 1, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( A43ConsultaFecha, "99/99/99"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(38);\"", 0, edtConsultaFecha_Jsonclick, "", 0, 1, -1, true, "right", "HLP_HistoriaClinica.htm");
            if ( ( edtConsultaFecha_Enabled == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlTextNl( "</td><td>") ;
               context.WriteHtmlText( "<img src=\""+context.convertURL( "calendar-img.gif")+"\" id=\""+edtConsultaFecha_Internalname+"_dp_trigger\" style=\"cursor: pointer;\" title=\"Date selector\" alt=\"Date selector\" >") ;
               context.WriteHtmlTextNl( "</td></tr></table>") ;
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockpacienteid_Internalname, 1, 1, 0, "Paciente Id", "", "", "", 0, lblTextblockpacienteid_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtPacienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A34PacienteId), 6, 0, ",", "")), "", 6, "chr", 1, "row", 6, 1, edtPacienteId_Enabled, 1, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A34PacienteId), "ZZZZZ9"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(43);\"", 0, edtPacienteId_Jsonclick, "", 0, 1, -1, true, "right", "HLP_HistoriaClinica.htm");
            /* Static images/pictures */
            ClassString = "Image" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgprompt_34_Internalname, "", "prompt.gif", "GeneXusX", imgprompt_34_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, imgprompt_34_Link, "", 0, "", "", StyleString, ClassString, "", "", "''", "", "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockpacienteapellido_Internalname, 1, 1, 0, "Paciente Apellido", "", "", "", 0, lblTextblockpacienteapellido_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtPacienteApellido_Internalname, StringUtil.RTrim( A36PacienteApellido), "", 20, "chr", 1, "row", 20, 1, edtPacienteApellido_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A36PacienteApellido, "XXXXXXXXXXXXXXXXXXXX")), "", 0, edtPacienteApellido_Jsonclick, "", 0, 1, -1, true, "left", "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockpacientenombre_Internalname, 1, 1, 0, "Paciente Nombre", "", "", "", 0, lblTextblockpacientenombre_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtPacienteNombre_Internalname, StringUtil.RTrim( A35PacienteNombre), "", 20, "chr", 1, "row", 20, 1, edtPacienteNombre_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A35PacienteNombre, "XXXXXXXXXXXXXXXXXXXX")), "", 0, edtPacienteNombre_Jsonclick, "", 0, 1, -1, true, "left", "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockpacienteci_Internalname, 1, 1, 0, "Paciente CI", "", "", "", 0, lblTextblockpacienteci_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtPacienteCI_Internalname, StringUtil.RTrim( A41PacienteCI), "", 8, "chr", 1, "row", 8, 1, edtPacienteCI_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A41PacienteCI, "XXXXXXXX")), "", 0, edtPacienteCI_Jsonclick, "", 0, 1, -1, true, "left", "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockmedicoid_Internalname, 1, 1, 0, "Medico Id", "", "", "", 0, lblTextblockmedicoid_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtMedicoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12MedicoId), 6, 0, ",", "")), "", 6, "chr", 1, "row", 6, 1, edtMedicoId_Enabled, 1, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A12MedicoId), "ZZZZZ9"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(63);\"", 0, edtMedicoId_Jsonclick, "", 0, 1, -1, true, "right", "HLP_HistoriaClinica.htm");
            /* Static images/pictures */
            ClassString = "Image" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgprompt_12_Internalname, "", "prompt.gif", "GeneXusX", imgprompt_12_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, imgprompt_12_Link, "", 0, "", "", StyleString, ClassString, "", "", "''", "", "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockmedicoapellido_Internalname, 1, 1, 0, "Medico Apellido", "", "", "", 0, lblTextblockmedicoapellido_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtMedicoApellido_Internalname, StringUtil.RTrim( A14MedicoApellido), "", 20, "chr", 1, "row", 20, 1, edtMedicoApellido_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A14MedicoApellido, "XXXXXXXXXXXXXXXXXXXX")), "", 0, edtMedicoApellido_Jsonclick, "", 0, 1, -1, true, "left", "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockmediconombre_Internalname, 1, 1, 0, "Medico Nombre", "", "", "", 0, lblTextblockmediconombre_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtMedicoNombre_Internalname, StringUtil.RTrim( A13MedicoNombre), "", 20, "chr", 1, "row", 20, 1, edtMedicoNombre_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A13MedicoNombre, "XXXXXXXXXXXXXXXXXXXX")), "", 0, edtMedicoNombre_Jsonclick, "", 0, 1, -1, true, "left", "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockespecialidadmaxpacientes_Internalname, 1, 1, 0, "Especialidad Max Pacientes", "", "", "", 0, lblTextblockespecialidadmaxpacientes_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtEspecialidadMaxPacientes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11EspecialidadMaxPacientes), 3, 0, ",", "")), "", 3, "chr", 1, "row", 3, 1, edtEspecialidadMaxPacientes_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A11EspecialidadMaxPacientes), "ZZ9"), "", 0, edtEspecialidadMaxPacientes_Jsonclick, "", 0, 1, -1, true, "right", "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockturnoid_Internalname, 1, 1, 0, "Turno Nombre", "", "", "", 0, lblTextblockturnoid_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"" ;
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynTurnoId, dynTurnoId_Internalname, StringUtil.Str( (decimal)(A60TurnoId), 2, 0), "", "int", 1, dynTurnoId.Enabled, 1, 1, 0, 20, "chr", 0, "", StyleString, ClassString, "", 0, dynTurnoId_Jsonclick, "", TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(83);\"", true, "HLP_HistoriaClinica.htm");
            dynTurnoId.CurrentValue = StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)) ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, dynTurnoId_Internalname, "Values", (String)(dynTurnoId.ToJavascriptSource()));
            /* Static images/pictures */
            ClassString = "Image" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgprompt_43_60_Internalname, "", "prompt.gif", "GeneXusX", imgprompt_43_60_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, imgprompt_43_60_Link, "", 0, "", "", StyleString, ClassString, "", "", "''", "", "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockconsultanro_Internalname, 1, 1, 0, "Nro", "", "", "", 0, lblTextblockconsultanro_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtConsultaNro_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A63ConsultaNro), 2, 0, ",", "")), "", 2, "chr", 1, "row", 2, 1, edtConsultaNro_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A63ConsultaNro), "Z9"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(88);\"", 0, edtConsultaNro_Jsonclick, "", 0, 1, -1, true, "right", "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockmotivoconsulta_Internalname, 1, 1, 0, "Motivo Consulta", "", "", "", 0, lblTextblockmotivoconsulta_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_html_textarea( context, edtMotivoConsulta_Internalname, A68MotivoConsulta, 1, edtMotivoConsulta_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "2097152", TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(93);\"", -1, 2, "", "", true, "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockanotacionesconsulta_Internalname, 1, 1, 0, "Anotaciones Consulta", "", "", "", 0, lblTextblockanotacionesconsulta_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_html_textarea( context, edtAnotacionesConsulta_Internalname, A69AnotacionesConsulta, 1, edtAnotacionesConsulta_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "2097152", TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(98);\"", -1, 1, "", "", true, "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_33_0A8e( true) ;
         }
         else
         {
            wb_table4_33_0A8e( false) ;
         }
      }

      protected void wb_table2_5_0A8( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTabletoolbar_Internalname, tblTabletoolbar_Internalname, "", "ViewTable", 0, "", "", 1, 2, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "<div style=\"WHITE-SPACE: nowrap\" class=\"ToolbarMain\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_first_Internalname, "", context.GetImagePath( "b9e06284-17ac-4c88-8937-5dbd84ad5d80", "", "GeneXusX"), "GeneXusX", imgBtn_first_Visible, 1, "", "Primero", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_first_Jsonclick, "EFIRST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_HistoriaClinica.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_first_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_first_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_first_separator_Jsonclick, "EFIRST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_HistoriaClinica.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_previous_Internalname, "", context.GetImagePath( "7d212604-db7b-4785-9c0d-5faffe71aa33", "", "GeneXusX"), "GeneXusX", imgBtn_previous_Visible, 1, "", "Anterior", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_previous_Jsonclick, "EPREVIOUS.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_HistoriaClinica.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_previous_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_previous_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_previous_separator_Jsonclick, "EPREVIOUS.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_HistoriaClinica.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_next_Internalname, "", context.GetImagePath( "1ae947cf-1354-41a9-8d59-d91daebf554f", "", "GeneXusX"), "GeneXusX", imgBtn_next_Visible, 1, "", "Siguiente", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_next_Jsonclick, "ENEXT.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_HistoriaClinica.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_next_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_next_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_next_separator_Jsonclick, "ENEXT.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_HistoriaClinica.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_last_Internalname, "", context.GetImagePath( "29211874-e613-48e5-9011-8017d984217e", "", "GeneXusX"), "GeneXusX", imgBtn_last_Visible, 1, "", "Ultimo", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_last_Jsonclick, "ELAST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_HistoriaClinica.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_last_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_last_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_last_separator_Jsonclick, "ELAST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_HistoriaClinica.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_select_Internalname, "", context.GetImagePath( "1ca03f75-9947-4d2c-90a4-e8ab9c5cedea", "", "GeneXusX"), "GeneXusX", imgBtn_select_Visible, 1, "", "Seleccionar", 0, 0, 0, "", 0, "", 0, 0, "", "", 4, imgBtn_select_Jsonclick, "ESELECT.", StyleString, ClassString, "", ""+TempTags, "", "gx.popup.openPrompt('"+"gx0080.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CONSULTAFECHA"+"'), id:'"+"CONSULTAFECHA"+"'"+",isOut:true,isKey:false,isLastKey:false}"+","+"{Ctrl:gx.dom.el('"+"PACIENTEID"+"'), id:'"+"PACIENTEID"+"'"+",isOut:true,isKey:false,isLastKey:false}"+","+"{Ctrl:gx.dom.el('"+"MEDICOID"+"'), id:'"+"MEDICOID"+"'"+",isOut:true,isKey:false,isLastKey:false}"+","+"{Ctrl:gx.dom.el('"+"TURNOID"+"'), id:'"+"TURNOID"+"'"+",isOut:true,isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", "HLP_HistoriaClinica.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_select_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_select_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 4, imgBtn_select_separator_Jsonclick, "ESELECT.", StyleString, ClassString, "", ""+TempTags, "", "gx.popup.openPrompt('"+"gx0080.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CONSULTAFECHA"+"'), id:'"+"CONSULTAFECHA"+"'"+",isOut:true,isKey:false,isLastKey:false}"+","+"{Ctrl:gx.dom.el('"+"PACIENTEID"+"'), id:'"+"PACIENTEID"+"'"+",isOut:true,isKey:false,isLastKey:false}"+","+"{Ctrl:gx.dom.el('"+"MEDICOID"+"'), id:'"+"MEDICOID"+"'"+",isOut:true,isKey:false,isLastKey:false}"+","+"{Ctrl:gx.dom.el('"+"TURNOID"+"'), id:'"+"TURNOID"+"'"+",isOut:true,isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", "HLP_HistoriaClinica.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_enter2_Internalname, "", context.GetImagePath( "2061cf2c-bd33-4433-a13e-34af954142e9", "", "GeneXusX"), "GeneXusX", imgBtn_enter2_Visible, imgBtn_enter2_Enabled, "", "Confirmar", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_enter2_Jsonclick, "EENTER.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_HistoriaClinica.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_enter2_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_enter2_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_enter2_separator_Jsonclick, "EENTER.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_HistoriaClinica.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_cancel2_Internalname, "", context.GetImagePath( "0e94ced8-bc34-47ff-9a53-bc683736a686", "", "GeneXusX"), "GeneXusX", imgBtn_cancel2_Visible, 1, "", "Cancelar", 0, 0, 0, "", 0, "", 0, 0, "", "", 1, imgBtn_cancel2_Jsonclick, "ECANCEL.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_HistoriaClinica.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_cancel2_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_cancel2_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 1, imgBtn_cancel2_separator_Jsonclick, "ECANCEL.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_HistoriaClinica.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_delete2_Internalname, "", context.GetImagePath( "7695fe89-52c9-4b7e-871e-0e11548f823e", "", "GeneXusX"), "GeneXusX", imgBtn_delete2_Visible, imgBtn_delete2_Enabled, "", "Eliminar", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_delete2_Jsonclick, "EDELETE.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_HistoriaClinica.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_delete2_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_delete2_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_delete2_separator_Jsonclick, "EDELETE.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_HistoriaClinica.htm");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_5_0A8e( true) ;
         }
         else
         {
            wb_table2_5_0A8e( false) ;
         }
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0 ;
         /* Execute user event: E110A2 */
         E110A2 ();
         context.wbGlbDoneStart = 1 ;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read variables values. */
               if ( context.localUtil.VCDate( cgiGet( edtConsultaFecha_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Consulta Fecha"}), 1, "CONSULTAFECHA");
                  AnyError = 1 ;
                  GX_FocusControl = edtConsultaFecha_Internalname ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true ;
                  A43ConsultaFecha = DateTime.MinValue ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
               }
               else
               {
                  A43ConsultaFecha = context.localUtil.CToD( cgiGet( edtConsultaFecha_Internalname), 2) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtPacienteId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPacienteId_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum"), 1, "PACIENTEID");
                  AnyError = 1 ;
                  GX_FocusControl = edtPacienteId_Internalname ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true ;
                  A34PacienteId = 0 ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
               }
               else
               {
                  A34PacienteId = (int)(context.localUtil.CToN( cgiGet( edtPacienteId_Internalname), ",", ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
               }
               A36PacienteApellido = cgiGet( edtPacienteApellido_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A36PacienteApellido", A36PacienteApellido);
               A35PacienteNombre = cgiGet( edtPacienteNombre_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A35PacienteNombre", A35PacienteNombre);
               A41PacienteCI = cgiGet( edtPacienteCI_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
               if ( ( ( context.localUtil.CToN( cgiGet( edtMedicoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMedicoId_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum"), 1, "MEDICOID");
                  AnyError = 1 ;
                  GX_FocusControl = edtMedicoId_Internalname ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true ;
                  A12MedicoId = 0 ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
               }
               else
               {
                  A12MedicoId = (int)(context.localUtil.CToN( cgiGet( edtMedicoId_Internalname), ",", ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
               }
               A14MedicoApellido = cgiGet( edtMedicoApellido_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
               A13MedicoNombre = cgiGet( edtMedicoNombre_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
               A11EspecialidadMaxPacientes = (short)(context.localUtil.CToN( cgiGet( edtEspecialidadMaxPacientes_Internalname), ",", ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
               dynTurnoId.CurrentValue = cgiGet( dynTurnoId_Internalname) ;
               A60TurnoId = (short)(NumberUtil.Val( cgiGet( dynTurnoId_Internalname), ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
               if ( ( ( context.localUtil.CToN( cgiGet( edtConsultaNro_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConsultaNro_Internalname), ",", ".") > Convert.ToDecimal( 99 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum"), 1, "CONSULTANRO");
                  AnyError = 1 ;
                  GX_FocusControl = edtConsultaNro_Internalname ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true ;
                  A63ConsultaNro = 0 ;
                  n63ConsultaNro = false ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A63ConsultaNro", StringUtil.LTrim( StringUtil.Str( (decimal)(A63ConsultaNro), 2, 0)));
               }
               else
               {
                  A63ConsultaNro = (short)(context.localUtil.CToN( cgiGet( edtConsultaNro_Internalname), ",", ".")) ;
                  n63ConsultaNro = false ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A63ConsultaNro", StringUtil.LTrim( StringUtil.Str( (decimal)(A63ConsultaNro), 2, 0)));
               }
               n63ConsultaNro = ((0==A63ConsultaNro) ? true : false) ;
               A68MotivoConsulta = cgiGet( edtMotivoConsulta_Internalname) ;
               n68MotivoConsulta = false ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A68MotivoConsulta", A68MotivoConsulta);
               n68MotivoConsulta = (String.IsNullOrEmpty(StringUtil.RTrim( A68MotivoConsulta)) ? true : false) ;
               A69AnotacionesConsulta = cgiGet( edtAnotacionesConsulta_Internalname) ;
               n69AnotacionesConsulta = false ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A69AnotacionesConsulta", A69AnotacionesConsulta);
               n69AnotacionesConsulta = (String.IsNullOrEmpty(StringUtil.RTrim( A69AnotacionesConsulta)) ? true : false) ;
               /* Read saved values. */
               Z43ConsultaFecha = context.localUtil.CToD( cgiGet( "Z43ConsultaFecha"), 0) ;
               Z34PacienteId = (int)(context.localUtil.CToN( cgiGet( "Z34PacienteId"), ",", ".")) ;
               Z12MedicoId = (int)(context.localUtil.CToN( cgiGet( "Z12MedicoId"), ",", ".")) ;
               Z60TurnoId = (short)(context.localUtil.CToN( cgiGet( "Z60TurnoId"), ",", ".")) ;
               Z63ConsultaNro = (short)(context.localUtil.CToN( cgiGet( "Z63ConsultaNro"), ",", ".")) ;
               O67UltimoNroAsig = (short)(context.localUtil.CToN( cgiGet( "O67UltimoNroAsig"), ",", ".")) ;
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", ".")) ;
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", ".")) ;
               Gx_mode = cgiGet( "Mode") ;
               AV15ConsultaFecha = context.localUtil.CToD( cgiGet( "_CONSULTAFECHA"), 0) ;
               Gx_date = context.localUtil.CToD( cgiGet( "_TODAY"), 0) ;
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "_GXBSCREEN"), ",", ".")) ;
               AV16PacienteId = (int)(context.localUtil.CToN( cgiGet( "_PACIENTEID"), ",", ".")) ;
               AV17MedicoId = (int)(context.localUtil.CToN( cgiGet( "_MEDICOID"), ",", ".")) ;
               AV18TurnoId = (short)(context.localUtil.CToN( cgiGet( "_TURNOID"), ",", ".")) ;
               A67UltimoNroAsig = (short)(context.localUtil.CToN( cgiGet( "ULTIMONROASIG"), ",", ".")) ;
               n67UltimoNroAsig = false ;
               A9EspecialidadId = (int)(context.localUtil.CToN( cgiGet( "ESPECIALIDADID"), ",", ".")) ;
               A61TurnoNombre = cgiGet( "TURNONOMBRE") ;
               AV21Pgmname = cgiGet( "_PGMNAME") ;
               Gx_mode = cgiGet( "_MODE") ;
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP" ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  A43ConsultaFecha = context.localUtil.ParseDateParm( GetNextPar( )) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
                  A34PacienteId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
                  A12MedicoId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
                  A60TurnoId = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
                  getEqualNoModal( ) ;
                  if ( ! (DateTime.MinValue==AV15ConsultaFecha) )
                  {
                     A43ConsultaFecha = AV15ConsultaFecha ;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  && (DateTime.MinValue==A43ConsultaFecha) && ( Gx_BScreen == 0 ) )
                     {
                        A43ConsultaFecha = Gx_date ;
                        context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
                     }
                  }
                  Gx_mode = "DSP" ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
                  {
                     sMode8 = Gx_mode ;
                     Gx_mode = "UPD" ;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                     if ( ! (DateTime.MinValue==AV15ConsultaFecha) )
                     {
                        A43ConsultaFecha = AV15ConsultaFecha ;
                        context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  && (DateTime.MinValue==A43ConsultaFecha) && ( Gx_BScreen == 0 ) )
                        {
                           A43ConsultaFecha = Gx_date ;
                           context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
                        }
                     }
                     Gx_mode = sMode8 ;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound8 == 1 )
                     {
                        if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
                        {
                           /* Confirm record */
                           CONFIRM_0A0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert"), 1, "CONSULTAFECHA");
                        AnyError = 1 ;
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName") ;
            EvtGridId = cgiGet( "_EventGridId") ;
            EvtRowId = cgiGet( "_EventRowId") ;
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1) ;
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1)) ;
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1) ;
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1)) ;
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1 ;
                           dynload_actions( ) ;
                           /* Execute user event: E110A2 */
                           E110A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1 ;
                           dynload_actions( ) ;
                           /* Execute user event: E120A2 */
                           E120A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1 ;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1 ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1 ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1 ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1 ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1 ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1 ;
                           btn_delete( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1 ;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            /* Execute user event: E120A2 */
            E120A2 ();
            trnEnded = 0 ;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  )
            {
               /* Clear variables for new insertion. */
               InitAll0A8( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
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

      protected void disable_std_buttons( )
      {
         imgBtn_delete2_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_delete2_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_delete2_Visible), 5, 0)));
         imgBtn_delete2_separator_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_delete2_separator_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_delete2_separator_Visible), 5, 0)));
         bttBtn_delete_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(bttBtn_delete_Visible), 5, 0)));
         imgBtn_first_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_first_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_first_Visible), 5, 0)));
         imgBtn_first_separator_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_first_separator_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_first_separator_Visible), 5, 0)));
         imgBtn_previous_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_previous_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_previous_Visible), 5, 0)));
         imgBtn_previous_separator_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_previous_separator_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_previous_separator_Visible), 5, 0)));
         imgBtn_next_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_next_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_next_Visible), 5, 0)));
         imgBtn_next_separator_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_next_separator_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_next_separator_Visible), 5, 0)));
         imgBtn_last_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_last_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_last_Visible), 5, 0)));
         imgBtn_last_separator_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_last_separator_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_last_separator_Visible), 5, 0)));
         imgBtn_select_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_select_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_select_Visible), 5, 0)));
         imgBtn_select_separator_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_select_separator_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_select_separator_Visible), 5, 0)));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            imgBtn_delete2_Visible = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_delete2_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_delete2_Visible), 5, 0)));
            imgBtn_delete2_separator_Visible = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_delete2_separator_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_delete2_separator_Visible), 5, 0)));
            bttBtn_delete_Visible = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(bttBtn_delete_Visible), 5, 0)));
            if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
            {
               imgBtn_enter2_Visible = 0 ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_enter2_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_enter2_Visible), 5, 0)));
               imgBtn_enter2_separator_Visible = 0 ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_enter2_separator_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_enter2_separator_Visible), 5, 0)));
               bttBtn_enter_Visible = 0 ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(bttBtn_enter_Visible), 5, 0)));
            }
            edtConsultaFecha_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtConsultaFecha_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtConsultaFecha_Enabled), 5, 0)));
            edtPacienteId_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPacienteId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPacienteId_Enabled), 5, 0)));
            edtPacienteApellido_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPacienteApellido_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPacienteApellido_Enabled), 5, 0)));
            edtPacienteNombre_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPacienteNombre_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPacienteNombre_Enabled), 5, 0)));
            edtPacienteCI_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPacienteCI_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPacienteCI_Enabled), 5, 0)));
            edtMedicoId_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtMedicoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtMedicoId_Enabled), 5, 0)));
            edtMedicoApellido_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtMedicoApellido_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtMedicoApellido_Enabled), 5, 0)));
            edtMedicoNombre_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtMedicoNombre_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtMedicoNombre_Enabled), 5, 0)));
            edtEspecialidadMaxPacientes_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtEspecialidadMaxPacientes_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtEspecialidadMaxPacientes_Enabled), 5, 0)));
            dynTurnoId.Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, dynTurnoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(dynTurnoId.Enabled), 5, 0)));
            edtConsultaNro_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtConsultaNro_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtConsultaNro_Enabled), 5, 0)));
            edtMotivoConsulta_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtMotivoConsulta_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtMotivoConsulta_Enabled), 5, 0)));
            edtAnotacionesConsulta_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtAnotacionesConsulta_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtAnotacionesConsulta_Enabled), 5, 0)));
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete"), 0, "");
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm"), 0, "");
            }
         }
      }

      protected void CONFIRM_0A0( )
      {
         BeforeValidate0A8( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               OnDeleteControls0A8( ) ;
            }
            else
            {
               CheckExtendedTable0A8( ) ;
               CloseExtendedTableCursors0A8( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1 ;
         }
      }

      protected void ResetCaption0A0( )
      {
      }

      protected void E110A2( )
      {
         /* Start Routine */
         new isauthorized(context ).execute(  AV21Pgmname, out  AV12IsAuthorized) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV21Pgmname", AV21Pgmname);
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV12IsAuthorized", StringUtil.BoolToStr( AV12IsAuthorized));
         if ( ! AV12IsAuthorized )
         {
            context.wjLoc = formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV21Pgmname)) ;
         }
         AV13TrnContext.FromXml(AV14WebSession.Get("TrnContext"), "");
      }

      protected void E120A2( )
      {
         /* After Trn Routine */
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV13TrnContext.gxTpr_Callerondelete )
         {
            context.wjLoc = formatLink("wwhistoriaclinica.aspx")  ;
         }
         context.setWebReturnParms(new Object[] {});
         context.nUserReturn = 1 ;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0A8( short GX_JID )
      {
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               Z63ConsultaNro = T000A3_A63ConsultaNro[0] ;
            }
            else
            {
               Z63ConsultaNro = A63ConsultaNro ;
            }
         }
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -17 )
         {
            Z63ConsultaNro = A63ConsultaNro ;
            Z68MotivoConsulta = A68MotivoConsulta ;
            Z69AnotacionesConsulta = A69AnotacionesConsulta ;
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
         GXATURNOID_html0A8( ) ;
         Gx_BScreen = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( ) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         imgprompt_34_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PACIENTEID"+"'), id:'"+"PACIENTEID"+"'"+",isOut:true,isKey:false,isLastKey:false}"+"],"+"null"+","+"'', false"+","+"true"+");") ;
         imgprompt_12_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"MEDICOID"+"'), id:'"+"MEDICOID"+"'"+",isOut:true,isKey:false,isLastKey:false}"+"],"+"null"+","+"'', false"+","+"true"+");") ;
         imgprompt_43_60_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CONSULTAFECHA"+"'), id:'"+"CONSULTAFECHA"+"'"+",isOut:true,isKey:false,isLastKey:false}"+","+"{Ctrl:gx.dom.el('"+"MEDICOID"+"'), id:'"+"MEDICOID"+"'"+",isOut:true,isKey:false,isLastKey:false}"+","+"{Ctrl:gx.dom.el('"+"TURNOID"+"'), id:'"+"TURNOID"+"'"+",isOut:true,isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");") ;
         imgBtn_delete2_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_delete2_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_delete2_Enabled), 5, 0)));
         if ( ! (DateTime.MinValue==AV15ConsultaFecha) )
         {
            edtConsultaFecha_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtConsultaFecha_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtConsultaFecha_Enabled), 5, 0)));
         }
         else
         {
            edtConsultaFecha_Enabled = 1 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtConsultaFecha_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtConsultaFecha_Enabled), 5, 0)));
         }
         if ( ! (DateTime.MinValue==AV15ConsultaFecha) )
         {
            edtConsultaFecha_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtConsultaFecha_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtConsultaFecha_Enabled), 5, 0)));
         }
         if ( ! (0==AV16PacienteId) )
         {
            A34PacienteId = AV16PacienteId ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
         }
         if ( ! (0==AV16PacienteId) )
         {
            edtPacienteId_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPacienteId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPacienteId_Enabled), 5, 0)));
         }
         else
         {
            edtPacienteId_Enabled = 1 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPacienteId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPacienteId_Enabled), 5, 0)));
         }
         if ( ! (0==AV16PacienteId) )
         {
            edtPacienteId_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPacienteId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPacienteId_Enabled), 5, 0)));
         }
         if ( ! (0==AV17MedicoId) )
         {
            A12MedicoId = AV17MedicoId ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
         }
         if ( ! (0==AV17MedicoId) )
         {
            edtMedicoId_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtMedicoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtMedicoId_Enabled), 5, 0)));
         }
         else
         {
            edtMedicoId_Enabled = 1 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtMedicoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtMedicoId_Enabled), 5, 0)));
         }
         if ( ! (0==AV17MedicoId) )
         {
            edtMedicoId_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtMedicoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtMedicoId_Enabled), 5, 0)));
         }
         if ( ! (0==AV18TurnoId) )
         {
            A60TurnoId = AV18TurnoId ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
         }
         if ( ! (0==AV18TurnoId) )
         {
            dynTurnoId.Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, dynTurnoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(dynTurnoId.Enabled), 5, 0)));
         }
         else
         {
            dynTurnoId.Enabled = 1 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, dynTurnoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(dynTurnoId.Enabled), 5, 0)));
         }
         if ( ! (0==AV18TurnoId) )
         {
            dynTurnoId.Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, dynTurnoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(dynTurnoId.Enabled), 5, 0)));
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            imgBtn_enter2_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_enter2_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_enter2_Enabled), 5, 0)));
         }
         else
         {
            imgBtn_enter2_Enabled = 1 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_enter2_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_enter2_Enabled), 5, 0)));
         }
         if ( ! (DateTime.MinValue==AV15ConsultaFecha) )
         {
            A43ConsultaFecha = AV15ConsultaFecha ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  && (DateTime.MinValue==A43ConsultaFecha) && ( Gx_BScreen == 0 ) )
            {
               A43ConsultaFecha = Gx_date ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000A5 */
            pr_default.execute(3, new Object[] {A60TurnoId});
            A61TurnoNombre = T000A5_A61TurnoNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
            pr_default.close(3);
            AV21Pgmname = "HistoriaClinica" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV21Pgmname", AV21Pgmname);
            /* Using cursor T000A8 */
            pr_default.execute(6, new Object[] {A34PacienteId});
            A36PacienteApellido = T000A8_A36PacienteApellido[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A36PacienteApellido", A36PacienteApellido);
            A35PacienteNombre = T000A8_A35PacienteNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A35PacienteNombre", A35PacienteNombre);
            A41PacienteCI = T000A8_A41PacienteCI[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
            pr_default.close(6);
            /* Using cursor T000A4 */
            pr_default.execute(2, new Object[] {A12MedicoId});
            A9EspecialidadId = T000A4_A9EspecialidadId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
            A14MedicoApellido = T000A4_A14MedicoApellido[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
            A13MedicoNombre = T000A4_A13MedicoNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
            pr_default.close(2);
            /* Using cursor T000A9 */
            pr_default.execute(7, new Object[] {A9EspecialidadId});
            A11EspecialidadMaxPacientes = T000A9_A11EspecialidadMaxPacientes[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
            pr_default.close(7);
            /* Using cursor T000A7 */
            pr_default.execute(5, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
            ZM0A8( 20) ;
            A67UltimoNroAsig = T000A7_A67UltimoNroAsig[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
            n67UltimoNroAsig = T000A7_n67UltimoNroAsig[0] ;
            O67UltimoNroAsig = A67UltimoNroAsig ;
            n67UltimoNroAsig = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
            pr_default.close(5);
         }
      }

      protected void Load0A8( )
      {
         /* Using cursor T000A10 */
         pr_default.execute(8, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId, A34PacienteId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound8 = 1 ;
            A9EspecialidadId = T000A10_A9EspecialidadId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
            A67UltimoNroAsig = T000A10_A67UltimoNroAsig[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
            n67UltimoNroAsig = T000A10_n67UltimoNroAsig[0] ;
            A36PacienteApellido = T000A10_A36PacienteApellido[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A36PacienteApellido", A36PacienteApellido);
            A35PacienteNombre = T000A10_A35PacienteNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A35PacienteNombre", A35PacienteNombre);
            A41PacienteCI = T000A10_A41PacienteCI[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
            A14MedicoApellido = T000A10_A14MedicoApellido[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
            A13MedicoNombre = T000A10_A13MedicoNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
            A11EspecialidadMaxPacientes = T000A10_A11EspecialidadMaxPacientes[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
            A61TurnoNombre = T000A10_A61TurnoNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
            A63ConsultaNro = T000A10_A63ConsultaNro[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A63ConsultaNro", StringUtil.LTrim( StringUtil.Str( (decimal)(A63ConsultaNro), 2, 0)));
            n63ConsultaNro = T000A10_n63ConsultaNro[0] ;
            A68MotivoConsulta = T000A10_A68MotivoConsulta[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A68MotivoConsulta", A68MotivoConsulta);
            n68MotivoConsulta = T000A10_n68MotivoConsulta[0] ;
            A69AnotacionesConsulta = T000A10_A69AnotacionesConsulta[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A69AnotacionesConsulta", A69AnotacionesConsulta);
            n69AnotacionesConsulta = T000A10_n69AnotacionesConsulta[0] ;
            ZM0A8( -17) ;
         }
         pr_default.close(8);
         OnLoadActions0A8( ) ;
      }

      protected void OnLoadActions0A8( )
      {
         AV21Pgmname = "HistoriaClinica" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV21Pgmname", AV21Pgmname);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  )
         {
            A67UltimoNroAsig = (short)(O67UltimoNroAsig+1) ;
            n67UltimoNroAsig = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  && ( Gx_BScreen == 1 ) )
         {
            A63ConsultaNro = A67UltimoNroAsig ;
            n63ConsultaNro = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A63ConsultaNro", StringUtil.LTrim( StringUtil.Str( (decimal)(A63ConsultaNro), 2, 0)));
         }
      }

      protected void CheckExtendedTable0A8( )
      {
         Gx_BScreen = 1 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV21Pgmname = "HistoriaClinica" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV21Pgmname", AV21Pgmname);
         if ( ! ( (DateTime.MinValue==A43ConsultaFecha) || ( A43ConsultaFecha >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Consulta Fecha fuera de rango", "OutOfRange", 1, "");
            AnyError = 1 ;
         }
         /* Using cursor T000A8 */
         pr_default.execute(6, new Object[] {A34PacienteId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Paciente'.", "ForeignKeyNotFound", 1, "PACIENTEID");
            AnyError = 1 ;
            GX_FocusControl = edtPacienteId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A36PacienteApellido = T000A8_A36PacienteApellido[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A36PacienteApellido", A36PacienteApellido);
         A35PacienteNombre = T000A8_A35PacienteNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A35PacienteNombre", A35PacienteNombre);
         A41PacienteCI = T000A8_A41PacienteCI[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
         pr_default.close(6);
         /* Using cursor T000A4 */
         pr_default.execute(2, new Object[] {A12MedicoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'M�dico'.", "ForeignKeyNotFound", 1, "MEDICOID");
            AnyError = 1 ;
            GX_FocusControl = edtMedicoId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A9EspecialidadId = T000A4_A9EspecialidadId[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
         A14MedicoApellido = T000A4_A14MedicoApellido[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
         A13MedicoNombre = T000A4_A13MedicoNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
         pr_default.close(2);
         /* Using cursor T000A9 */
         pr_default.execute(7, new Object[] {A9EspecialidadId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Especialidad'.", "ForeignKeyNotFound", 1, "");
            AnyError = 1 ;
         }
         A11EspecialidadMaxPacientes = T000A9_A11EspecialidadMaxPacientes[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
         pr_default.close(7);
         /* Using cursor T000A5 */
         pr_default.execute(3, new Object[] {A60TurnoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Turno'.", "ForeignKeyNotFound", 1, "TURNOID");
            AnyError = 1 ;
            GX_FocusControl = dynTurnoId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A61TurnoNombre = T000A5_A61TurnoNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
         pr_default.close(3);
         /* Using cursor T000A7 */
         pr_default.execute(5, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Consulta'.", "ForeignKeyNotFound", 1, "CONSULTAFECHA");
            AnyError = 1 ;
            GX_FocusControl = edtConsultaFecha_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A67UltimoNroAsig = T000A7_A67UltimoNroAsig[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
         n67UltimoNroAsig = T000A7_n67UltimoNroAsig[0] ;
         O67UltimoNroAsig = A67UltimoNroAsig ;
         n67UltimoNroAsig = false ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
         pr_default.close(5);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  )
         {
            A67UltimoNroAsig = (short)(O67UltimoNroAsig+1) ;
            n67UltimoNroAsig = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  && ( Gx_BScreen == 1 ) )
         {
            A63ConsultaNro = A67UltimoNroAsig ;
            n63ConsultaNro = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A63ConsultaNro", StringUtil.LTrim( StringUtil.Str( (decimal)(A63ConsultaNro), 2, 0)));
         }
      }

      protected void CloseExtendedTableCursors0A8( )
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

      protected void gxLoad_21( int A34PacienteId )
      {
         /* Using cursor T000A11 */
         pr_default.execute(9, new Object[] {A34PacienteId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Paciente'.", "ForeignKeyNotFound", 1, "PACIENTEID");
            AnyError = 1 ;
            GX_FocusControl = edtPacienteId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A36PacienteApellido = T000A11_A36PacienteApellido[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A36PacienteApellido", A36PacienteApellido);
         A35PacienteNombre = T000A11_A35PacienteNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A35PacienteNombre", A35PacienteNombre);
         A41PacienteCI = T000A11_A41PacienteCI[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A36PacienteApellido))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A35PacienteNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A41PacienteCI))+"\"");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(9) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(9);
      }

      protected void gxLoad_18( int A12MedicoId )
      {
         /* Using cursor T000A12 */
         pr_default.execute(10, new Object[] {A12MedicoId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'M�dico'.", "ForeignKeyNotFound", 1, "MEDICOID");
            AnyError = 1 ;
            GX_FocusControl = edtMedicoId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A9EspecialidadId = T000A12_A9EspecialidadId[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
         A14MedicoApellido = T000A12_A14MedicoApellido[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
         A13MedicoNombre = T000A12_A13MedicoNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A9EspecialidadId), 6, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A14MedicoApellido))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A13MedicoNombre))+"\"");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(10) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(10);
      }

      protected void gxLoad_22( int A9EspecialidadId )
      {
         /* Using cursor T000A13 */
         pr_default.execute(11, new Object[] {A9EspecialidadId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Especialidad'.", "ForeignKeyNotFound", 1, "");
            AnyError = 1 ;
         }
         A11EspecialidadMaxPacientes = T000A13_A11EspecialidadMaxPacientes[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A11EspecialidadMaxPacientes), 3, 0, ".", "")))+"\"");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(11) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(11);
      }

      protected void gxLoad_19( short A60TurnoId )
      {
         /* Using cursor T000A14 */
         pr_default.execute(12, new Object[] {A60TurnoId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Turno'.", "ForeignKeyNotFound", 1, "TURNOID");
            AnyError = 1 ;
            GX_FocusControl = dynTurnoId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A61TurnoNombre = T000A14_A61TurnoNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A61TurnoNombre))+"\"");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(12) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(12);
      }

      protected void gxLoad_20( DateTime A43ConsultaFecha ,
                                int A12MedicoId ,
                                short A60TurnoId )
      {
         /* Using cursor T000A15 */
         pr_default.execute(13, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Consulta'.", "ForeignKeyNotFound", 1, "CONSULTAFECHA");
            AnyError = 1 ;
            GX_FocusControl = edtConsultaFecha_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A67UltimoNroAsig = T000A15_A67UltimoNroAsig[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
         n67UltimoNroAsig = T000A15_n67UltimoNroAsig[0] ;
         O67UltimoNroAsig = A67UltimoNroAsig ;
         n67UltimoNroAsig = false ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A67UltimoNroAsig), 2, 0, ".", "")))+"\"");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(13) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(13);
      }

      protected void GetKey0A8( )
      {
         /* Using cursor T000A16 */
         pr_default.execute(14, new Object[] {A43ConsultaFecha, A34PacienteId, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound8 = 1 ;
         }
         else
         {
            RcdFound8 = 0 ;
         }
         pr_default.close(14);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000A3 */
         pr_default.execute(1, new Object[] {A43ConsultaFecha, A34PacienteId, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A8( 17) ;
            RcdFound8 = 1 ;
            A63ConsultaNro = T000A3_A63ConsultaNro[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A63ConsultaNro", StringUtil.LTrim( StringUtil.Str( (decimal)(A63ConsultaNro), 2, 0)));
            n63ConsultaNro = T000A3_n63ConsultaNro[0] ;
            A68MotivoConsulta = T000A3_A68MotivoConsulta[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A68MotivoConsulta", A68MotivoConsulta);
            n68MotivoConsulta = T000A3_n68MotivoConsulta[0] ;
            A69AnotacionesConsulta = T000A3_A69AnotacionesConsulta[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A69AnotacionesConsulta", A69AnotacionesConsulta);
            n69AnotacionesConsulta = T000A3_n69AnotacionesConsulta[0] ;
            A43ConsultaFecha = T000A3_A43ConsultaFecha[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            A12MedicoId = T000A3_A12MedicoId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            A60TurnoId = T000A3_A60TurnoId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
            A34PacienteId = T000A3_A34PacienteId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
            Z43ConsultaFecha = A43ConsultaFecha ;
            Z34PacienteId = A34PacienteId ;
            Z12MedicoId = A12MedicoId ;
            Z60TurnoId = A60TurnoId ;
            sMode8 = Gx_mode ;
            Gx_mode = "DSP" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
            Load0A8( ) ;
            Gx_mode = sMode8 ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound8 = 0 ;
            InitializeNonKey0A8( ) ;
            sMode8 = Gx_mode ;
            Gx_mode = "DSP" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode8 ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A8( ) ;
         if ( RcdFound8 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound8 = 0 ;
         /* Using cursor T000A17 */
         pr_default.execute(15, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId, A34PacienteId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( T000A17_A43ConsultaFecha[0] < A43ConsultaFecha ) || ( T000A17_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000A17_A12MedicoId[0] < A12MedicoId ) || ( T000A17_A12MedicoId[0] == A12MedicoId ) && ( T000A17_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000A17_A60TurnoId[0] < A60TurnoId ) || ( T000A17_A60TurnoId[0] == A60TurnoId ) && ( T000A17_A12MedicoId[0] == A12MedicoId ) && ( T000A17_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000A17_A34PacienteId[0] < A34PacienteId ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( T000A17_A43ConsultaFecha[0] > A43ConsultaFecha ) || ( T000A17_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000A17_A12MedicoId[0] > A12MedicoId ) || ( T000A17_A12MedicoId[0] == A12MedicoId ) && ( T000A17_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000A17_A60TurnoId[0] > A60TurnoId ) || ( T000A17_A60TurnoId[0] == A60TurnoId ) && ( T000A17_A12MedicoId[0] == A12MedicoId ) && ( T000A17_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000A17_A34PacienteId[0] > A34PacienteId ) ) )
            {
               A43ConsultaFecha = T000A17_A43ConsultaFecha[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
               A12MedicoId = T000A17_A12MedicoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
               A60TurnoId = T000A17_A60TurnoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
               A34PacienteId = T000A17_A34PacienteId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
               RcdFound8 = 1 ;
            }
         }
         pr_default.close(1);
      }

      protected void move_previous( )
      {
         RcdFound8 = 0 ;
         /* Using cursor T000A18 */
         pr_default.execute(16, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId, A34PacienteId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            while ( (pr_default.getStatus(16) != 101) && ( ( T000A18_A43ConsultaFecha[0] > A43ConsultaFecha ) || ( T000A18_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000A18_A12MedicoId[0] > A12MedicoId ) || ( T000A18_A12MedicoId[0] == A12MedicoId ) && ( T000A18_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000A18_A60TurnoId[0] > A60TurnoId ) || ( T000A18_A60TurnoId[0] == A60TurnoId ) && ( T000A18_A12MedicoId[0] == A12MedicoId ) && ( T000A18_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000A18_A34PacienteId[0] > A34PacienteId ) ) )
            {
               pr_default.readNext(16);
            }
            if ( (pr_default.getStatus(16) != 101) && ( ( T000A18_A43ConsultaFecha[0] < A43ConsultaFecha ) || ( T000A18_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000A18_A12MedicoId[0] < A12MedicoId ) || ( T000A18_A12MedicoId[0] == A12MedicoId ) && ( T000A18_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000A18_A60TurnoId[0] < A60TurnoId ) || ( T000A18_A60TurnoId[0] == A60TurnoId ) && ( T000A18_A12MedicoId[0] == A12MedicoId ) && ( T000A18_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000A18_A34PacienteId[0] < A34PacienteId ) ) )
            {
               A43ConsultaFecha = T000A18_A43ConsultaFecha[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
               A12MedicoId = T000A18_A12MedicoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
               A60TurnoId = T000A18_A60TurnoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
               A34PacienteId = T000A18_A34PacienteId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
               RcdFound8 = 1 ;
            }
         }
         pr_default.close(0);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1 ;
         GetKey0A8( ) ;
         if ( RcdFound8 == 1 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate"), "DuplicatePrimaryKey", 1, "CONSULTAFECHA");
               AnyError = 1 ;
               GX_FocusControl = edtConsultaFecha_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( A43ConsultaFecha != Z43ConsultaFecha ) || ( A34PacienteId != Z34PacienteId ) || ( A12MedicoId != Z12MedicoId ) || ( A60TurnoId != Z60TurnoId ) )
            {
               A43ConsultaFecha = Z43ConsultaFecha ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
               A34PacienteId = Z34PacienteId ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
               A12MedicoId = Z12MedicoId ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
               A60TurnoId = Z60TurnoId ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd"), "CandidateKeyNotFound", 1, "CONSULTAFECHA");
               AnyError = 1 ;
               GX_FocusControl = edtConsultaFecha_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               delete( ) ;
               AfterTrn( ) ;
               GX_FocusControl = edtConsultaFecha_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else
            {
               /* Update record */
               Update0A8( ) ;
               GX_FocusControl = edtConsultaFecha_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( ( A43ConsultaFecha != Z43ConsultaFecha ) || ( A34PacienteId != Z34PacienteId ) || ( A12MedicoId != Z12MedicoId ) || ( A60TurnoId != Z60TurnoId ) )
            {
               /* Insert record */
               Insert0A8( ) ;
               GX_FocusControl = edtConsultaFecha_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted"), 1, "CONSULTAFECHA");
                  AnyError = 1 ;
                  GX_FocusControl = edtConsultaFecha_Internalname ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Insert record */
                  Insert0A8( ) ;
                  GX_FocusControl = edtConsultaFecha_Internalname ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
         }
         AfterTrn( ) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1 ;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( ( A43ConsultaFecha != Z43ConsultaFecha ) || ( A34PacienteId != Z34PacienteId ) || ( A12MedicoId != Z12MedicoId ) || ( A60TurnoId != Z60TurnoId ) )
         {
            A43ConsultaFecha = Z43ConsultaFecha ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            A34PacienteId = Z34PacienteId ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
            A12MedicoId = Z12MedicoId ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            A60TurnoId = Z60TurnoId ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt"), 1, "CONSULTAFECHA");
            AnyError = 1 ;
            GX_FocusControl = edtConsultaFecha_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtConsultaFecha_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0A8( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            /* Using cursor T000A19 */
            pr_default.execute(17, new Object[] {A43ConsultaFecha, A34PacienteId, A12MedicoId, A60TurnoId});
            if ( (pr_default.getStatus(17) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ConsultaPaciente"}), "RecordIsLocked", 1, "");
               AnyError = 1 ;
               return  ;
            }
            if ( (pr_default.getStatus(17) == 101) || ( Z63ConsultaNro != T000A19_A63ConsultaNro[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ConsultaPaciente"}), "RecordWasChanged", 1, "");
               AnyError = 1 ;
               return  ;
            }
         }
         /* Using cursor T000A6 */
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

      protected void Insert0A8( )
      {
         BeforeValidate0A8( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A8( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A8( 0) ;
            CheckOptimisticConcurrency0A8( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A8( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A8( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A20 */
                     pr_default.execute(18, new Object[] {n63ConsultaNro, A63ConsultaNro, n68MotivoConsulta, A68MotivoConsulta, n69AnotacionesConsulta, A69AnotacionesConsulta, A43ConsultaFecha, A12MedicoId, A60TurnoId, A34PacienteId});
                     pr_default.close(18);
                     if ( (pr_default.getStatus(18) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate"), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1 ;
                     }
                     if ( AnyError == 0 )
                     {
                        UpdateTablesN10A8( ) ;
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           GX_msglist.addItem(context.GetMessage( "GXM_sucadded"), 0, "");
                           ResetCaption0A0( ) ;
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
               Load0A8( ) ;
            }
            EndLevel0A8( ) ;
         }
         CloseExtendedTableCursors0A8( ) ;
      }

      protected void Update0A8( )
      {
         BeforeValidate0A8( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A8( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A8( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A8( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A8( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A21 */
                     pr_default.execute(19, new Object[] {n63ConsultaNro, A63ConsultaNro, n68MotivoConsulta, A68MotivoConsulta, n69AnotacionesConsulta, A69AnotacionesConsulta, A43ConsultaFecha, A34PacienteId, A12MedicoId, A60TurnoId});
                     pr_default.close(19);
                     if ( (pr_default.getStatus(19) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ConsultaPaciente"}), "RecordIsLocked", 1, "");
                        AnyError = 1 ;
                     }
                     DeferredUpdate0A8( ) ;
                     if ( AnyError == 0 )
                     {
                        UpdateTablesN10A8( ) ;
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1 ;
                              }
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
            }
            EndLevel0A8( ) ;
         }
         CloseExtendedTableCursors0A8( ) ;
      }

      protected void DeferredUpdate0A8( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0A8( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A8( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A8( ) ;
            AfterConfirm0A8( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A8( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000A22 */
                  pr_default.execute(20, new Object[] {A43ConsultaFecha, A34PacienteId, A12MedicoId, A60TurnoId});
                  pr_default.close(20);
                  if ( AnyError == 0 )
                  {
                     UpdateTablesN10A8( ) ;
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1 ;
                           }
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
         }
         sMode8 = Gx_mode ;
         Gx_mode = "DLT" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         EndLevel0A8( ) ;
         Gx_mode = sMode8 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0A8( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV21Pgmname = "HistoriaClinica" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV21Pgmname", AV21Pgmname);
            /* Using cursor T000A23 */
            pr_default.execute(21, new Object[] {A34PacienteId});
            A36PacienteApellido = T000A23_A36PacienteApellido[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A36PacienteApellido", A36PacienteApellido);
            A35PacienteNombre = T000A23_A35PacienteNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A35PacienteNombre", A35PacienteNombre);
            A41PacienteCI = T000A23_A41PacienteCI[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
            pr_default.close(21);
            /* Using cursor T000A24 */
            pr_default.execute(22, new Object[] {A12MedicoId});
            A9EspecialidadId = T000A24_A9EspecialidadId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
            A14MedicoApellido = T000A24_A14MedicoApellido[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
            A13MedicoNombre = T000A24_A13MedicoNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
            pr_default.close(22);
            /* Using cursor T000A25 */
            pr_default.execute(23, new Object[] {A9EspecialidadId});
            A11EspecialidadMaxPacientes = T000A25_A11EspecialidadMaxPacientes[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
            pr_default.close(23);
            /* Using cursor T000A26 */
            pr_default.execute(24, new Object[] {A60TurnoId});
            A61TurnoNombre = T000A26_A61TurnoNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
            pr_default.close(24);
            /* Using cursor T000A27 */
            pr_default.execute(25, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
            A67UltimoNroAsig = T000A27_A67UltimoNroAsig[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
            n67UltimoNroAsig = T000A27_n67UltimoNroAsig[0] ;
            O67UltimoNroAsig = A67UltimoNroAsig ;
            n67UltimoNroAsig = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
            pr_default.close(25);
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  )
            {
               A67UltimoNroAsig = (short)(O67UltimoNroAsig+1) ;
               n67UltimoNroAsig = false ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
            }
         }
      }

      protected void UpdateTablesN10A8( )
      {
         /* Using cursor T000A28 */
         pr_default.execute(26, new Object[] {n67UltimoNroAsig, A67UltimoNroAsig, A43ConsultaFecha, A12MedicoId, A60TurnoId});
         pr_default.close(26);
      }

      protected void EndLevel0A8( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            pr_default.close(17);
         }
         pr_default.close(4);
         if ( AnyError == 0 )
         {
            BeforeComplete0A8( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(16);
            pr_default.close(15);
            pr_default.close(22);
            pr_default.close(24);
            pr_default.close(25);
            pr_default.close(21);
            pr_default.close(23);
            context.CommitDataStores("HistoriaClinica");
            if ( AnyError == 0 )
            {
               ConfirmValues0A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1 ;
         }
         else
         {
            pr_default.close(16);
            pr_default.close(15);
            pr_default.close(22);
            pr_default.close(24);
            pr_default.close(25);
            pr_default.close(21);
            pr_default.close(23);
            context.RollbackDataStores("HistoriaClinica");
         }
         IsModified = 0 ;
         if ( AnyError != 0 )
         {
            context.wjLoc = "" ;
            context.nUserReturn = 0 ;
         }
      }

      protected void ScanStart0A8( )
      {
         /* Using cursor T000A29 */
         pr_default.execute(27);
         RcdFound8 = 0 ;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound8 = 1 ;
            A43ConsultaFecha = T000A29_A43ConsultaFecha[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            A34PacienteId = T000A29_A34PacienteId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
            A12MedicoId = T000A29_A12MedicoId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            A60TurnoId = T000A29_A60TurnoId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0A8( )
      {
         pr_default.readNext(27);
         RcdFound8 = 0 ;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound8 = 1 ;
            A43ConsultaFecha = T000A29_A43ConsultaFecha[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            A34PacienteId = T000A29_A34PacienteId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
            A12MedicoId = T000A29_A12MedicoId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            A60TurnoId = T000A29_A60TurnoId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
         }
      }

      protected void ScanEnd0A8( )
      {
      }

      protected void AfterConfirm0A8( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A8( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A8( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A8( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A8( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A8( )
      {
         /* Before Validate Rules */
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0A0( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, "IE=EmulateIE7");
      }

      public override void RenderHtmlOpenForm( )
      {
         context.WriteHtmlText( "<title>") ;
         context.WriteHtmlText( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         if ( ! context.isSmartDevice( ) )
         {
            context.AddJavascriptSource("gxgral.js", "?34981");
            context.AddJavascriptSource("gxcfg.js", "?34981");
         }
         else
         {
            context.AddJavascriptSource("gxapiSD.js", "?34981");
            context.AddJavascriptSource("gxfxSD.js", "?34981");
            context.AddJavascriptSource("gxtypesSD.js", "?34981");
            context.AddJavascriptSource("gxpopupSD.js", "?34981");
            context.AddJavascriptSource("gxfrmutlSD.js", "?34981");
            context.AddJavascriptSource("gxgridSD.js", "?34981");
            context.AddJavascriptSource("JavaScripTableSD.js", "?34981");
            context.AddJavascriptSource("rijndaelSD.js", "?34981");
            context.AddJavascriptSource("gxgralSD.js", "?34981");
            context.AddJavascriptSource("gxcfg.js", "?34981");
         }
         context.AddJavascriptSource("calendar.js", "?34981");
         context.AddJavascriptSource("calendar-setup.js", "?34981");
         context.AddJavascriptSource("calendar-es.js", "?34981");
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         FormProcess = " onkeyup=\"gx.evt.onkeyup(event)\" onkeypress=\"gx.evt.onkeypress(event,true,false)\" onkeydown=\"gx.evt.onkeypress(null,true,false)\"" ;
         context.WriteHtmlText( "<body") ;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            context.WriteHtmlText( " background=\""+context.convertURL( Form.Background)+"\"") ;
         }
         context.WriteHtmlText( " "+"class=\"Form\""+" "+" style=\"-moz-opacity:0;opacity:0;"+"\""+" bgcolor=\""+context.BuildHTMLColor( Form.Backcolor)+"\""+FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" onsubmit=\"try{return gx.csv.validForm()}catch(e){return true;}\" name=\"MAINFORM\" method=\"post\" action=\""+formatLink("historiaclinica.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV15ConsultaFecha)) + "," + UrlEncode("" +AV16PacienteId) + "," + UrlEncode("" +AV17MedicoId) + "," + UrlEncode("" +AV18TurnoId)+"\" class=\""+"Form"+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
      }

      public override void RenderHtmlCloseForm( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         GxWebStd.gx_hidden_field( context, "Z43ConsultaFecha", context.localUtil.DToC( Z43ConsultaFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z34PacienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z34PacienteId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z12MedicoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12MedicoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z60TurnoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z60TurnoId), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z63ConsultaNro", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z63ConsultaNro), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "O67UltimoNroAsig", StringUtil.LTrim( StringUtil.NToC( (decimal)(O67UltimoNroAsig), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "_CONSULTAFECHA", context.localUtil.DToC( AV15ConsultaFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "_TODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "_GXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "_PACIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16PacienteId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "_MEDICOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17MedicoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "_TURNOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18TurnoId), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ULTIMONROASIG", StringUtil.LTrim( StringUtil.NToC( (decimal)(A67UltimoNroAsig), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ESPECIALIDADID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9EspecialidadId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "TURNONOMBRE", StringUtil.RTrim( A61TurnoNombre));
         GxWebStd.gx_hidden_field( context, "_PGMNAME", StringUtil.RTrim( AV21Pgmname));
         GxWebStd.gx_hidden_field( context, "_MODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendComponentObjects();
         SendServerCommands();
         SendState();
         context.WriteHtmlTextNl( "</form>") ;
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0)) ;
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         Draw( ) ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override String GetPgmname( )
      {
         return "HistoriaClinica" ;
      }

      public override String GetPgmdesc( )
      {
         return "Historia Clinica" ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("historiaclinica.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV15ConsultaFecha)) + "," + UrlEncode("" +AV16PacienteId) + "," + UrlEncode("" +AV17MedicoId) + "," + UrlEncode("" +AV18TurnoId) ;
      }

      protected void InitializeNonKey0A8( )
      {
         A9EspecialidadId = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
         A67UltimoNroAsig = 0 ;
         n67UltimoNroAsig = false ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
         A36PacienteApellido = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A36PacienteApellido", A36PacienteApellido);
         A35PacienteNombre = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A35PacienteNombre", A35PacienteNombre);
         A41PacienteCI = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
         A14MedicoApellido = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
         A13MedicoNombre = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
         A11EspecialidadMaxPacientes = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
         A61TurnoNombre = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
         A63ConsultaNro = 0 ;
         n63ConsultaNro = false ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A63ConsultaNro", StringUtil.LTrim( StringUtil.Str( (decimal)(A63ConsultaNro), 2, 0)));
         n63ConsultaNro = ((0==A63ConsultaNro) ? true : false) ;
         A68MotivoConsulta = "" ;
         n68MotivoConsulta = false ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A68MotivoConsulta", A68MotivoConsulta);
         n68MotivoConsulta = (String.IsNullOrEmpty(StringUtil.RTrim( A68MotivoConsulta)) ? true : false) ;
         A69AnotacionesConsulta = "" ;
         n69AnotacionesConsulta = false ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A69AnotacionesConsulta", A69AnotacionesConsulta);
         n69AnotacionesConsulta = (String.IsNullOrEmpty(StringUtil.RTrim( A69AnotacionesConsulta)) ? true : false) ;
         O67UltimoNroAsig = A67UltimoNroAsig ;
         n67UltimoNroAsig = false ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
      }

      protected void InitAll0A8( )
      {
         A43ConsultaFecha = Gx_date ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         A34PacienteId = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
         A12MedicoId = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
         A60TurnoId = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
         InitializeNonKey0A8( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "?165260");
         AddThemeStyleSheetFile("", "GeneXusX.css", "?2313925");
         idxLst = 1 ;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( Form.Jscriptsrc.Item(idxLst)), "?5343813");
            idxLst = (int)(idxLst+1) ;
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?34981");
         context.AddJavascriptSource("historiaclinica.js", "?5343813");
         /* End function include_jscripts */
      }

      public override void initialize_properties( )
      {
         imgBtn_first_Internalname = "BTN_FIRST" ;
         imgBtn_first_separator_Internalname = "BTN_FIRST_SEPARATOR" ;
         imgBtn_previous_Internalname = "BTN_PREVIOUS" ;
         imgBtn_previous_separator_Internalname = "BTN_PREVIOUS_SEPARATOR" ;
         imgBtn_next_Internalname = "BTN_NEXT" ;
         imgBtn_next_separator_Internalname = "BTN_NEXT_SEPARATOR" ;
         imgBtn_last_Internalname = "BTN_LAST" ;
         imgBtn_last_separator_Internalname = "BTN_LAST_SEPARATOR" ;
         imgBtn_select_Internalname = "BTN_SELECT" ;
         imgBtn_select_separator_Internalname = "BTN_SELECT_SEPARATOR" ;
         imgBtn_enter2_Internalname = "BTN_ENTER2" ;
         imgBtn_enter2_separator_Internalname = "BTN_ENTER2_SEPARATOR" ;
         imgBtn_cancel2_Internalname = "BTN_CANCEL2" ;
         imgBtn_cancel2_separator_Internalname = "BTN_CANCEL2_SEPARATOR" ;
         imgBtn_delete2_Internalname = "BTN_DELETE2" ;
         imgBtn_delete2_separator_Internalname = "BTN_DELETE2_SEPARATOR" ;
         tblTabletoolbar_Internalname = "TABLETOOLBAR" ;
         lblTextblockconsultafecha_Internalname = "TEXTBLOCKCONSULTAFECHA" ;
         edtConsultaFecha_Internalname = "CONSULTAFECHA" ;
         lblTextblockpacienteid_Internalname = "TEXTBLOCKPACIENTEID" ;
         edtPacienteId_Internalname = "PACIENTEID" ;
         lblTextblockpacienteapellido_Internalname = "TEXTBLOCKPACIENTEAPELLIDO" ;
         edtPacienteApellido_Internalname = "PACIENTEAPELLIDO" ;
         lblTextblockpacientenombre_Internalname = "TEXTBLOCKPACIENTENOMBRE" ;
         edtPacienteNombre_Internalname = "PACIENTENOMBRE" ;
         lblTextblockpacienteci_Internalname = "TEXTBLOCKPACIENTECI" ;
         edtPacienteCI_Internalname = "PACIENTECI" ;
         lblTextblockmedicoid_Internalname = "TEXTBLOCKMEDICOID" ;
         edtMedicoId_Internalname = "MEDICOID" ;
         lblTextblockmedicoapellido_Internalname = "TEXTBLOCKMEDICOAPELLIDO" ;
         edtMedicoApellido_Internalname = "MEDICOAPELLIDO" ;
         lblTextblockmediconombre_Internalname = "TEXTBLOCKMEDICONOMBRE" ;
         edtMedicoNombre_Internalname = "MEDICONOMBRE" ;
         lblTextblockespecialidadmaxpacientes_Internalname = "TEXTBLOCKESPECIALIDADMAXPACIENTES" ;
         edtEspecialidadMaxPacientes_Internalname = "ESPECIALIDADMAXPACIENTES" ;
         lblTextblockturnoid_Internalname = "TEXTBLOCKTURNOID" ;
         dynTurnoId_Internalname = "TURNOID" ;
         lblTextblockconsultanro_Internalname = "TEXTBLOCKCONSULTANRO" ;
         edtConsultaNro_Internalname = "CONSULTANRO" ;
         lblTextblockmotivoconsulta_Internalname = "TEXTBLOCKMOTIVOCONSULTA" ;
         edtMotivoConsulta_Internalname = "MOTIVOCONSULTA" ;
         lblTextblockanotacionesconsulta_Internalname = "TEXTBLOCKANOTACIONESCONSULTA" ;
         edtAnotacionesConsulta_Internalname = "ANOTACIONESCONSULTA" ;
         tblTable2_Internalname = "TABLE2" ;
         bttBtn_enter_Internalname = "BTN_ENTER" ;
         bttBtn_cancel_Internalname = "BTN_CANCEL" ;
         bttBtn_delete_Internalname = "BTN_DELETE" ;
         tblTable1_Internalname = "TABLE1" ;
         grpGroupdata_Internalname = "GROUPDATA" ;
         tblTablemain_Internalname = "TABLEMAIN" ;
         Form.Internalname = "FORM" ;
         imgprompt_34_Internalname = "PROMPT_34" ;
         imgprompt_12_Internalname = "PROMPT_12" ;
         imgprompt_43_60_Internalname = "PROMPT_43_60" ;
         Form.Headerrawhtml = "" ;
         Form.Background = "" ;
         Form.Backcolor = (int)(0xFFFFFF) ;
         Form.Caption = "Historia Clinica" ;
         imgBtn_delete2_separator_Visible = 1 ;
         imgBtn_delete2_Enabled = 1 ;
         imgBtn_delete2_Visible = 1 ;
         imgBtn_cancel2_separator_Visible = 1 ;
         imgBtn_cancel2_Visible = 1 ;
         imgBtn_enter2_separator_Visible = 1 ;
         imgBtn_enter2_Enabled = 1 ;
         imgBtn_enter2_Visible = 1 ;
         imgBtn_select_separator_Visible = 1 ;
         imgBtn_select_Visible = 1 ;
         imgBtn_last_separator_Visible = 1 ;
         imgBtn_last_Visible = 1 ;
         imgBtn_next_separator_Visible = 1 ;
         imgBtn_next_Visible = 1 ;
         imgBtn_previous_separator_Visible = 1 ;
         imgBtn_previous_Visible = 1 ;
         imgBtn_first_separator_Visible = 1 ;
         imgBtn_first_Visible = 1 ;
         edtAnotacionesConsulta_Enabled = 1 ;
         edtMotivoConsulta_Enabled = 1 ;
         edtConsultaNro_Jsonclick = "" ;
         edtConsultaNro_Enabled = 1 ;
         imgprompt_43_60_Visible = 1 ;
         imgprompt_43_60_Link = "" ;
         dynTurnoId_Jsonclick = "" ;
         dynTurnoId.Enabled = 1 ;
         edtEspecialidadMaxPacientes_Jsonclick = "" ;
         edtEspecialidadMaxPacientes_Enabled = 0 ;
         edtMedicoNombre_Jsonclick = "" ;
         edtMedicoNombre_Enabled = 0 ;
         edtMedicoApellido_Jsonclick = "" ;
         edtMedicoApellido_Enabled = 0 ;
         imgprompt_12_Visible = 1 ;
         imgprompt_12_Link = "" ;
         edtMedicoId_Jsonclick = "" ;
         edtMedicoId_Enabled = 1 ;
         edtPacienteCI_Jsonclick = "" ;
         edtPacienteCI_Enabled = 0 ;
         edtPacienteNombre_Jsonclick = "" ;
         edtPacienteNombre_Enabled = 0 ;
         edtPacienteApellido_Jsonclick = "" ;
         edtPacienteApellido_Enabled = 0 ;
         imgprompt_34_Visible = 1 ;
         imgprompt_34_Link = "" ;
         edtPacienteId_Jsonclick = "" ;
         edtPacienteId_Enabled = 1 ;
         edtConsultaFecha_Jsonclick = "" ;
         edtConsultaFecha_Enabled = 1 ;
         bttBtn_delete_Visible = 1 ;
         bttBtn_cancel_Visible = 1 ;
         bttBtn_enter_Visible = 1 ;
         context.GX_msglist.DisplayMode = 1 ;
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLATURNOID0A8( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "max-age=0");
         }
         context.GX_webresponse.AddString("(new Array( new Array(");
         GXDLATURNOID_data0A8( ) ;
         gxdynajaxindex = 1 ;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            context.GX_webresponse.AddString(gxwrpcisep+"{c:\""+GXUtil.EncodeJSConstant( gxdynajaxctrlcodr.Item(gxdynajaxindex))+"\",d:\""+GXUtil.EncodeJSConstant( gxdynajaxctrldescr.Item(gxdynajaxindex))+"\"}");
            gxdynajaxindex = (int)(gxdynajaxindex+1) ;
            gxwrpcisep = "," ;
         }
         context.GX_webresponse.AddString(")");
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            context.GX_webresponse.AddString(",101");
         }
         context.GX_webresponse.AddString("))");
      }

      protected void GXATURNOID_html0A8( )
      {
         short gxdynajaxvalue ;
         GXDLATURNOID_data0A8( ) ;
         gxdynajaxindex = 1 ;
         dynTurnoId.removeAllItems();
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( gxdynajaxctrlcodr.Item(gxdynajaxindex), ".")) ;
            dynTurnoId.addItem(StringUtil.Str( (decimal)(gxdynajaxvalue), 2, 0), gxdynajaxctrldescr.Item(gxdynajaxindex), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1) ;
         }
      }

      protected void GXDLATURNOID_data0A8( )
      {
         /* Using cursor T000A30 */
         pr_default.execute(28);
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("Todos");
         while ( (pr_default.getStatus(28) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000A30_A60TurnoId[0]), 2, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000A30_A61TurnoNombre[0]));
            pr_default.readNext(28);
         }
         pr_default.close(28);
      }

      public void Valid_Pacienteid( int GX_Parm1 ,
                                    String GX_Parm2 ,
                                    String GX_Parm3 ,
                                    String GX_Parm4 )
      {
         A34PacienteId = GX_Parm1 ;
         A36PacienteApellido = GX_Parm2 ;
         A35PacienteNombre = GX_Parm3 ;
         A41PacienteCI = GX_Parm4 ;
         /* Using cursor T000A31 */
         pr_default.execute(29, new Object[] {A34PacienteId});
         if ( (pr_default.getStatus(29) == 101) )
         {
            GX_msglist.addItem("No existe 'Paciente'.", "ForeignKeyNotFound", 1, "PACIENTEID");
            AnyError = 1 ;
            GX_FocusControl = edtPacienteId_Internalname ;
         }
         A36PacienteApellido = T000A31_A36PacienteApellido[0] ;
         A35PacienteNombre = T000A31_A35PacienteNombre[0] ;
         A41PacienteCI = T000A31_A41PacienteCI[0] ;
         pr_default.close(29);
         dynload_actions( ) ;
         if ( AnyError == 1 )
         {
            A36PacienteApellido = "" ;
            A35PacienteNombre = "" ;
            A41PacienteCI = "" ;
         }
         isValidOutput.Add((Object)(StringUtil.RTrim( A36PacienteApellido)));
         isValidOutput.Add((Object)(StringUtil.RTrim( A35PacienteNombre)));
         isValidOutput.Add((Object)(StringUtil.RTrim( A41PacienteCI)));
         isValidOutput.Add((Object)(context.GX_msglist.ToJavascriptSource()));
         context.GX_webresponse.AddString(isValidOutput.ToJSonString());
      }

      public void Valid_Medicoid( int GX_Parm1 ,
                                  int GX_Parm2 ,
                                  String GX_Parm3 ,
                                  String GX_Parm4 ,
                                  short GX_Parm5 )
      {
         A12MedicoId = GX_Parm1 ;
         A9EspecialidadId = GX_Parm2 ;
         A14MedicoApellido = GX_Parm3 ;
         A13MedicoNombre = GX_Parm4 ;
         A11EspecialidadMaxPacientes = GX_Parm5 ;
         /* Using cursor T000A32 */
         pr_default.execute(30, new Object[] {A12MedicoId});
         if ( (pr_default.getStatus(30) == 101) )
         {
            GX_msglist.addItem("No existe 'M�dico'.", "ForeignKeyNotFound", 1, "MEDICOID");
            AnyError = 1 ;
            GX_FocusControl = edtMedicoId_Internalname ;
         }
         A9EspecialidadId = T000A32_A9EspecialidadId[0] ;
         A14MedicoApellido = T000A32_A14MedicoApellido[0] ;
         A13MedicoNombre = T000A32_A13MedicoNombre[0] ;
         pr_default.close(30);
         /* Using cursor T000A33 */
         pr_default.execute(31, new Object[] {A9EspecialidadId});
         if ( (pr_default.getStatus(31) == 101) )
         {
            GX_msglist.addItem("No existe 'Especialidad'.", "ForeignKeyNotFound", 1, "");
            AnyError = 1 ;
         }
         A11EspecialidadMaxPacientes = T000A33_A11EspecialidadMaxPacientes[0] ;
         pr_default.close(31);
         dynload_actions( ) ;
         if ( AnyError == 1 )
         {
            A9EspecialidadId = 0 ;
            A14MedicoApellido = "" ;
            A13MedicoNombre = "" ;
            A11EspecialidadMaxPacientes = 0 ;
         }
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(A9EspecialidadId), 6, 0, ".", ""))));
         isValidOutput.Add((Object)(StringUtil.RTrim( A14MedicoApellido)));
         isValidOutput.Add((Object)(StringUtil.RTrim( A13MedicoNombre)));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(A11EspecialidadMaxPacientes), 3, 0, ".", ""))));
         isValidOutput.Add((Object)(context.GX_msglist.ToJavascriptSource()));
         context.GX_webresponse.AddString(isValidOutput.ToJSonString());
      }

      public void Valid_Turnoid( String GX_Parm1 ,
                                 short GX_Parm2 ,
                                 GXCombobox dynGX_Parm3 ,
                                 DateTime GX_Parm4 ,
                                 int GX_Parm5 ,
                                 short GX_Parm6 ,
                                 short GX_Parm7 ,
                                 String GX_Parm8 ,
                                 short GX_Parm9 )
      {
         Gx_mode = GX_Parm1 ;
         O67UltimoNroAsig = GX_Parm2 ;
         dynTurnoId = dynGX_Parm3 ;
         A60TurnoId = (short)(NumberUtil.Val( dynTurnoId.CurrentValue, ".")) ;
         A43ConsultaFecha = GX_Parm4 ;
         A12MedicoId = GX_Parm5 ;
         A67UltimoNroAsig = GX_Parm6 ;
         n67UltimoNroAsig = false ;
         Gx_BScreen = GX_Parm7 ;
         A61TurnoNombre = GX_Parm8 ;
         A63ConsultaNro = GX_Parm9 ;
         n63ConsultaNro = false ;
         /* Using cursor T000A34 */
         pr_default.execute(32, new Object[] {A60TurnoId});
         if ( (pr_default.getStatus(32) == 101) )
         {
            GX_msglist.addItem("No existe 'Turno'.", "ForeignKeyNotFound", 1, "TURNOID");
            AnyError = 1 ;
            GX_FocusControl = dynTurnoId_Internalname ;
         }
         A61TurnoNombre = T000A34_A61TurnoNombre[0] ;
         pr_default.close(32);
         /* Using cursor T000A35 */
         pr_default.execute(33, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(33) == 101) )
         {
            GX_msglist.addItem("No existe 'Consulta'.", "ForeignKeyNotFound", 1, "CONSULTAFECHA");
            AnyError = 1 ;
            GX_FocusControl = edtConsultaFecha_Internalname ;
         }
         A67UltimoNroAsig = T000A35_A67UltimoNroAsig[0] ;
         n67UltimoNroAsig = T000A35_n67UltimoNroAsig[0] ;
         O67UltimoNroAsig = A67UltimoNroAsig ;
         n67UltimoNroAsig = false ;
         pr_default.close(33);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  )
         {
            A67UltimoNroAsig = (short)(O67UltimoNroAsig+1) ;
            n67UltimoNroAsig = false ;
         }
         dynload_actions( ) ;
         if ( AnyError == 1 )
         {
            A61TurnoNombre = "" ;
            A67UltimoNroAsig = 0 ;
            n67UltimoNroAsig = false ;
         }
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(O67UltimoNroAsig), 2, 0, ",", ""))));
         isValidOutput.Add((Object)(StringUtil.RTrim( A61TurnoNombre)));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(A67UltimoNroAsig), 2, 0, ".", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(A63ConsultaNro), 2, 0, ".", ""))));
         isValidOutput.Add((Object)(context.GX_msglist.ToJavascriptSource()));
         context.GX_webresponse.AddString(isValidOutput.ToJSonString());
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
         pr_default.close(27);
         pr_default.close(16);
         pr_default.close(15);
         pr_default.close(33);
         pr_default.close(25);
         pr_default.close(29);
         pr_default.close(21);
         pr_default.close(30);
         pr_default.close(22);
         pr_default.close(31);
         pr_default.close(23);
         pr_default.close(32);
         pr_default.close(24);
      }

      public override void initialize( )
      {
         sPrefix = "" ;
         wcpOGx_mode = "" ;
         wcpOAV15ConsultaFecha = DateTime.MinValue ;
         scmdbuf = "" ;
         gxfirstwebparm = "" ;
         gxfirstwebparm_bkp = "" ;
         A43ConsultaFecha = DateTime.MinValue ;
         PreviousTooltip = "" ;
         PreviousCaption = "" ;
         Form = new GXWebForm();
         GX_FocusControl = "" ;
         sStyleString = "" ;
         ClassString = "" ;
         StyleString = "" ;
         TempTags = "" ;
         bttBtn_enter_Jsonclick = "" ;
         bttBtn_cancel_Jsonclick = "" ;
         bttBtn_delete_Jsonclick = "" ;
         lblTextblockconsultafecha_Jsonclick = "" ;
         lblTextblockpacienteid_Jsonclick = "" ;
         lblTextblockpacienteapellido_Jsonclick = "" ;
         A36PacienteApellido = "" ;
         lblTextblockpacientenombre_Jsonclick = "" ;
         A35PacienteNombre = "" ;
         lblTextblockpacienteci_Jsonclick = "" ;
         A41PacienteCI = "" ;
         lblTextblockmedicoid_Jsonclick = "" ;
         lblTextblockmedicoapellido_Jsonclick = "" ;
         A14MedicoApellido = "" ;
         lblTextblockmediconombre_Jsonclick = "" ;
         A13MedicoNombre = "" ;
         lblTextblockespecialidadmaxpacientes_Jsonclick = "" ;
         lblTextblockturnoid_Jsonclick = "" ;
         lblTextblockconsultanro_Jsonclick = "" ;
         lblTextblockmotivoconsulta_Jsonclick = "" ;
         A68MotivoConsulta = "" ;
         lblTextblockanotacionesconsulta_Jsonclick = "" ;
         A69AnotacionesConsulta = "" ;
         imgBtn_first_Jsonclick = "" ;
         imgBtn_first_separator_Jsonclick = "" ;
         imgBtn_previous_Jsonclick = "" ;
         imgBtn_previous_separator_Jsonclick = "" ;
         imgBtn_next_Jsonclick = "" ;
         imgBtn_next_separator_Jsonclick = "" ;
         imgBtn_last_Jsonclick = "" ;
         imgBtn_last_separator_Jsonclick = "" ;
         imgBtn_select_Jsonclick = "" ;
         imgBtn_select_separator_Jsonclick = "" ;
         imgBtn_enter2_Jsonclick = "" ;
         imgBtn_enter2_separator_Jsonclick = "" ;
         imgBtn_cancel2_Jsonclick = "" ;
         imgBtn_cancel2_separator_Jsonclick = "" ;
         imgBtn_delete2_Jsonclick = "" ;
         imgBtn_delete2_separator_Jsonclick = "" ;
         Z43ConsultaFecha = DateTime.MinValue ;
         Gx_date = DateTime.MinValue ;
         A61TurnoNombre = "" ;
         AV21Pgmname = "" ;
         sMode8 = "" ;
         sEvt = "" ;
         EvtGridId = "" ;
         EvtRowId = "" ;
         sEvtType = "" ;
         AV13TrnContext = new SdtTransactionContext(context);
         AV14WebSession = new GxWebSession( context);
         Z68MotivoConsulta = "" ;
         Z69AnotacionesConsulta = "" ;
         Z36PacienteApellido = "" ;
         Z35PacienteNombre = "" ;
         Z41PacienteCI = "" ;
         Z14MedicoApellido = "" ;
         Z13MedicoNombre = "" ;
         Z61TurnoNombre = "" ;
         T000A5_A61TurnoNombre = new String[] {""} ;
         T000A8_A36PacienteApellido = new String[] {""} ;
         T000A8_A35PacienteNombre = new String[] {""} ;
         T000A8_A41PacienteCI = new String[] {""} ;
         T000A4_A9EspecialidadId = new int[1] ;
         T000A4_A14MedicoApellido = new String[] {""} ;
         T000A4_A13MedicoNombre = new String[] {""} ;
         T000A9_A11EspecialidadMaxPacientes = new short[1] ;
         T000A7_A67UltimoNroAsig = new short[1] ;
         T000A7_n67UltimoNroAsig = new bool[] {false} ;
         T000A10_A9EspecialidadId = new int[1] ;
         T000A10_A67UltimoNroAsig = new short[1] ;
         T000A10_n67UltimoNroAsig = new bool[] {false} ;
         T000A10_A36PacienteApellido = new String[] {""} ;
         T000A10_A35PacienteNombre = new String[] {""} ;
         T000A10_A41PacienteCI = new String[] {""} ;
         T000A10_A14MedicoApellido = new String[] {""} ;
         T000A10_A13MedicoNombre = new String[] {""} ;
         T000A10_A11EspecialidadMaxPacientes = new short[1] ;
         T000A10_A61TurnoNombre = new String[] {""} ;
         T000A10_A63ConsultaNro = new short[1] ;
         T000A10_n63ConsultaNro = new bool[] {false} ;
         T000A10_A68MotivoConsulta = new String[] {""} ;
         T000A10_n68MotivoConsulta = new bool[] {false} ;
         T000A10_A69AnotacionesConsulta = new String[] {""} ;
         T000A10_n69AnotacionesConsulta = new bool[] {false} ;
         T000A10_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T000A10_A12MedicoId = new int[1] ;
         T000A10_A60TurnoId = new short[1] ;
         T000A10_A34PacienteId = new int[1] ;
         T000A11_A36PacienteApellido = new String[] {""} ;
         T000A11_A35PacienteNombre = new String[] {""} ;
         T000A11_A41PacienteCI = new String[] {""} ;
         T000A12_A9EspecialidadId = new int[1] ;
         T000A12_A14MedicoApellido = new String[] {""} ;
         T000A12_A13MedicoNombre = new String[] {""} ;
         T000A13_A11EspecialidadMaxPacientes = new short[1] ;
         T000A14_A61TurnoNombre = new String[] {""} ;
         T000A15_A67UltimoNroAsig = new short[1] ;
         T000A15_n67UltimoNroAsig = new bool[] {false} ;
         T000A16_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T000A16_A34PacienteId = new int[1] ;
         T000A16_A12MedicoId = new int[1] ;
         T000A16_A60TurnoId = new short[1] ;
         T000A3_A63ConsultaNro = new short[1] ;
         T000A3_n63ConsultaNro = new bool[] {false} ;
         T000A3_A68MotivoConsulta = new String[] {""} ;
         T000A3_n68MotivoConsulta = new bool[] {false} ;
         T000A3_A69AnotacionesConsulta = new String[] {""} ;
         T000A3_n69AnotacionesConsulta = new bool[] {false} ;
         T000A3_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T000A3_A12MedicoId = new int[1] ;
         T000A3_A60TurnoId = new short[1] ;
         T000A3_A34PacienteId = new int[1] ;
         T000A17_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T000A17_A12MedicoId = new int[1] ;
         T000A17_A60TurnoId = new short[1] ;
         T000A17_A34PacienteId = new int[1] ;
         T000A18_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T000A18_A12MedicoId = new int[1] ;
         T000A18_A60TurnoId = new short[1] ;
         T000A18_A34PacienteId = new int[1] ;
         T000A19_A63ConsultaNro = new short[1] ;
         T000A19_n63ConsultaNro = new bool[] {false} ;
         T000A19_A68MotivoConsulta = new String[] {""} ;
         T000A19_n68MotivoConsulta = new bool[] {false} ;
         T000A19_A69AnotacionesConsulta = new String[] {""} ;
         T000A19_n69AnotacionesConsulta = new bool[] {false} ;
         T000A19_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T000A19_A12MedicoId = new int[1] ;
         T000A19_A60TurnoId = new short[1] ;
         T000A19_A34PacienteId = new int[1] ;
         T000A6_A67UltimoNroAsig = new short[1] ;
         T000A6_n67UltimoNroAsig = new bool[] {false} ;
         T000A23_A36PacienteApellido = new String[] {""} ;
         T000A23_A35PacienteNombre = new String[] {""} ;
         T000A23_A41PacienteCI = new String[] {""} ;
         T000A24_A9EspecialidadId = new int[1] ;
         T000A24_A14MedicoApellido = new String[] {""} ;
         T000A24_A13MedicoNombre = new String[] {""} ;
         T000A25_A11EspecialidadMaxPacientes = new short[1] ;
         T000A26_A61TurnoNombre = new String[] {""} ;
         T000A27_A67UltimoNroAsig = new short[1] ;
         T000A27_n67UltimoNroAsig = new bool[] {false} ;
         T000A29_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T000A29_A34PacienteId = new int[1] ;
         T000A29_A12MedicoId = new int[1] ;
         T000A29_A60TurnoId = new short[1] ;
         sDynURL = "" ;
         FormProcess = "" ;
         GXt_char2 = "" ;
         GXt_char1 = "" ;
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "" ;
         GXt_char3 = "" ;
         T000A30_A60TurnoId = new short[1] ;
         T000A30_A61TurnoNombre = new String[] {""} ;
         T000A31_A36PacienteApellido = new String[] {""} ;
         T000A31_A35PacienteNombre = new String[] {""} ;
         T000A31_A41PacienteCI = new String[] {""} ;
         isValidOutput = new GxUnknownObjectCollection();
         T000A32_A9EspecialidadId = new int[1] ;
         T000A32_A14MedicoApellido = new String[] {""} ;
         T000A32_A13MedicoNombre = new String[] {""} ;
         T000A33_A11EspecialidadMaxPacientes = new short[1] ;
         T000A34_A61TurnoNombre = new String[] {""} ;
         T000A35_A67UltimoNroAsig = new short[1] ;
         T000A35_n67UltimoNroAsig = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.historiaclinica__default(),
            new Object[][] {
                new Object[] {
               T000A2_A63ConsultaNro, T000A2_n63ConsultaNro, T000A2_A68MotivoConsulta, T000A2_n68MotivoConsulta, T000A2_A69AnotacionesConsulta, T000A2_n69AnotacionesConsulta, T000A2_A43ConsultaFecha, T000A2_A12MedicoId, T000A2_A60TurnoId, T000A2_A34PacienteId
               }
               , new Object[] {
               T000A3_A63ConsultaNro, T000A3_n63ConsultaNro, T000A3_A68MotivoConsulta, T000A3_n68MotivoConsulta, T000A3_A69AnotacionesConsulta, T000A3_n69AnotacionesConsulta, T000A3_A43ConsultaFecha, T000A3_A12MedicoId, T000A3_A60TurnoId, T000A3_A34PacienteId
               }
               , new Object[] {
               T000A4_A9EspecialidadId, T000A4_A14MedicoApellido, T000A4_A13MedicoNombre
               }
               , new Object[] {
               T000A5_A61TurnoNombre
               }
               , new Object[] {
               T000A6_A67UltimoNroAsig, T000A6_n67UltimoNroAsig
               }
               , new Object[] {
               T000A7_A67UltimoNroAsig, T000A7_n67UltimoNroAsig
               }
               , new Object[] {
               T000A8_A36PacienteApellido, T000A8_A35PacienteNombre, T000A8_A41PacienteCI
               }
               , new Object[] {
               T000A9_A11EspecialidadMaxPacientes
               }
               , new Object[] {
               T000A10_A9EspecialidadId, T000A10_A67UltimoNroAsig, T000A10_n67UltimoNroAsig, T000A10_A36PacienteApellido, T000A10_A35PacienteNombre, T000A10_A41PacienteCI, T000A10_A14MedicoApellido, T000A10_A13MedicoNombre, T000A10_A11EspecialidadMaxPacientes, T000A10_A61TurnoNombre,
               T000A10_A63ConsultaNro, T000A10_n63ConsultaNro, T000A10_A68MotivoConsulta, T000A10_n68MotivoConsulta, T000A10_A69AnotacionesConsulta, T000A10_n69AnotacionesConsulta, T000A10_A43ConsultaFecha, T000A10_A12MedicoId, T000A10_A60TurnoId, T000A10_A34PacienteId
               }
               , new Object[] {
               T000A11_A36PacienteApellido, T000A11_A35PacienteNombre, T000A11_A41PacienteCI
               }
               , new Object[] {
               T000A12_A9EspecialidadId, T000A12_A14MedicoApellido, T000A12_A13MedicoNombre
               }
               , new Object[] {
               T000A13_A11EspecialidadMaxPacientes
               }
               , new Object[] {
               T000A14_A61TurnoNombre
               }
               , new Object[] {
               T000A15_A67UltimoNroAsig, T000A15_n67UltimoNroAsig
               }
               , new Object[] {
               T000A16_A43ConsultaFecha, T000A16_A34PacienteId, T000A16_A12MedicoId, T000A16_A60TurnoId
               }
               , new Object[] {
               T000A17_A43ConsultaFecha, T000A17_A12MedicoId, T000A17_A60TurnoId, T000A17_A34PacienteId
               }
               , new Object[] {
               T000A18_A43ConsultaFecha, T000A18_A12MedicoId, T000A18_A60TurnoId, T000A18_A34PacienteId
               }
               , new Object[] {
               T000A19_A63ConsultaNro, T000A19_n63ConsultaNro, T000A19_A68MotivoConsulta, T000A19_n68MotivoConsulta, T000A19_A69AnotacionesConsulta, T000A19_n69AnotacionesConsulta, T000A19_A43ConsultaFecha, T000A19_A12MedicoId, T000A19_A60TurnoId, T000A19_A34PacienteId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000A23_A36PacienteApellido, T000A23_A35PacienteNombre, T000A23_A41PacienteCI
               }
               , new Object[] {
               T000A24_A9EspecialidadId, T000A24_A14MedicoApellido, T000A24_A13MedicoNombre
               }
               , new Object[] {
               T000A25_A11EspecialidadMaxPacientes
               }
               , new Object[] {
               T000A26_A61TurnoNombre
               }
               , new Object[] {
               T000A27_A67UltimoNroAsig, T000A27_n67UltimoNroAsig
               }
               , new Object[] {
               }
               , new Object[] {
               T000A29_A43ConsultaFecha, T000A29_A34PacienteId, T000A29_A12MedicoId, T000A29_A60TurnoId
               }
               , new Object[] {
               T000A30_A60TurnoId, T000A30_A61TurnoNombre
               }
               , new Object[] {
               T000A31_A36PacienteApellido, T000A31_A35PacienteNombre, T000A31_A41PacienteCI
               }
               , new Object[] {
               T000A32_A9EspecialidadId, T000A32_A14MedicoApellido, T000A32_A13MedicoNombre
               }
               , new Object[] {
               T000A33_A11EspecialidadMaxPacientes
               }
               , new Object[] {
               T000A34_A61TurnoNombre
               }
               , new Object[] {
               T000A35_A67UltimoNroAsig, T000A35_n67UltimoNroAsig
               }
            }
         );
         AV21Pgmname = "HistoriaClinica" ;
         Z43ConsultaFecha = Gx_date ;
         Gx_date = DateTimeUtil.Today( ) ;
      }

      private short wcpOAV18TurnoId ;
      private short GxWebError ;
      private short A60TurnoId ;
      private short AV18TurnoId ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A11EspecialidadMaxPacientes ;
      private short A63ConsultaNro ;
      private short Z60TurnoId ;
      private short Z63ConsultaNro ;
      private short O67UltimoNroAsig ;
      private short Gx_BScreen ;
      private short A67UltimoNroAsig ;
      private short RcdFound8 ;
      private short GX_JID ;
      private short Z11EspecialidadMaxPacientes ;
      private short Z67UltimoNroAsig ;
      private short gxajaxcallmode ;
      private int wcpOAV16PacienteId ;
      private int wcpOAV17MedicoId ;
      private int A34PacienteId ;
      private int A12MedicoId ;
      private int A9EspecialidadId ;
      private int AV16PacienteId ;
      private int AV17MedicoId ;
      private int trnEnded ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int edtConsultaFecha_Enabled ;
      private int edtPacienteId_Enabled ;
      private int imgprompt_34_Visible ;
      private int edtPacienteApellido_Enabled ;
      private int edtPacienteNombre_Enabled ;
      private int edtPacienteCI_Enabled ;
      private int edtMedicoId_Enabled ;
      private int imgprompt_12_Visible ;
      private int edtMedicoApellido_Enabled ;
      private int edtMedicoNombre_Enabled ;
      private int edtEspecialidadMaxPacientes_Enabled ;
      private int imgprompt_43_60_Visible ;
      private int edtConsultaNro_Enabled ;
      private int edtMotivoConsulta_Enabled ;
      private int edtAnotacionesConsulta_Enabled ;
      private int imgBtn_first_Visible ;
      private int imgBtn_first_separator_Visible ;
      private int imgBtn_previous_Visible ;
      private int imgBtn_previous_separator_Visible ;
      private int imgBtn_next_Visible ;
      private int imgBtn_next_separator_Visible ;
      private int imgBtn_last_Visible ;
      private int imgBtn_last_separator_Visible ;
      private int imgBtn_select_Visible ;
      private int imgBtn_select_separator_Visible ;
      private int imgBtn_enter2_Visible ;
      private int imgBtn_enter2_Enabled ;
      private int imgBtn_enter2_separator_Visible ;
      private int imgBtn_cancel2_Visible ;
      private int imgBtn_cancel2_separator_Visible ;
      private int imgBtn_delete2_Visible ;
      private int imgBtn_delete2_Enabled ;
      private int imgBtn_delete2_separator_Visible ;
      private int Z34PacienteId ;
      private int Z12MedicoId ;
      private int Z9EspecialidadId ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private String sPrefix ;
      private String wcpOGx_mode ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String Gx_mode ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String GX_FocusControl ;
      private String edtConsultaFecha_Internalname ;
      private String sStyleString ;
      private String tblTablemain_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String grpGroupdata_Internalname ;
      private String tblTable1_Internalname ;
      private String TempTags ;
      private String bttBtn_enter_Internalname ;
      private String bttBtn_enter_Jsonclick ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String bttBtn_delete_Internalname ;
      private String bttBtn_delete_Jsonclick ;
      private String tblTable2_Internalname ;
      private String lblTextblockconsultafecha_Internalname ;
      private String lblTextblockconsultafecha_Jsonclick ;
      private String edtConsultaFecha_Jsonclick ;
      private String lblTextblockpacienteid_Internalname ;
      private String lblTextblockpacienteid_Jsonclick ;
      private String edtPacienteId_Internalname ;
      private String edtPacienteId_Jsonclick ;
      private String imgprompt_34_Internalname ;
      private String imgprompt_34_Link ;
      private String lblTextblockpacienteapellido_Internalname ;
      private String lblTextblockpacienteapellido_Jsonclick ;
      private String edtPacienteApellido_Internalname ;
      private String A36PacienteApellido ;
      private String edtPacienteApellido_Jsonclick ;
      private String lblTextblockpacientenombre_Internalname ;
      private String lblTextblockpacientenombre_Jsonclick ;
      private String edtPacienteNombre_Internalname ;
      private String A35PacienteNombre ;
      private String edtPacienteNombre_Jsonclick ;
      private String lblTextblockpacienteci_Internalname ;
      private String lblTextblockpacienteci_Jsonclick ;
      private String edtPacienteCI_Internalname ;
      private String A41PacienteCI ;
      private String edtPacienteCI_Jsonclick ;
      private String lblTextblockmedicoid_Internalname ;
      private String lblTextblockmedicoid_Jsonclick ;
      private String edtMedicoId_Internalname ;
      private String edtMedicoId_Jsonclick ;
      private String imgprompt_12_Internalname ;
      private String imgprompt_12_Link ;
      private String lblTextblockmedicoapellido_Internalname ;
      private String lblTextblockmedicoapellido_Jsonclick ;
      private String edtMedicoApellido_Internalname ;
      private String A14MedicoApellido ;
      private String edtMedicoApellido_Jsonclick ;
      private String lblTextblockmediconombre_Internalname ;
      private String lblTextblockmediconombre_Jsonclick ;
      private String edtMedicoNombre_Internalname ;
      private String A13MedicoNombre ;
      private String edtMedicoNombre_Jsonclick ;
      private String lblTextblockespecialidadmaxpacientes_Internalname ;
      private String lblTextblockespecialidadmaxpacientes_Jsonclick ;
      private String edtEspecialidadMaxPacientes_Internalname ;
      private String edtEspecialidadMaxPacientes_Jsonclick ;
      private String lblTextblockturnoid_Internalname ;
      private String lblTextblockturnoid_Jsonclick ;
      private String dynTurnoId_Internalname ;
      private String dynTurnoId_Jsonclick ;
      private String imgprompt_43_60_Internalname ;
      private String imgprompt_43_60_Link ;
      private String lblTextblockconsultanro_Internalname ;
      private String lblTextblockconsultanro_Jsonclick ;
      private String edtConsultaNro_Internalname ;
      private String edtConsultaNro_Jsonclick ;
      private String lblTextblockmotivoconsulta_Internalname ;
      private String lblTextblockmotivoconsulta_Jsonclick ;
      private String edtMotivoConsulta_Internalname ;
      private String lblTextblockanotacionesconsulta_Internalname ;
      private String lblTextblockanotacionesconsulta_Jsonclick ;
      private String edtAnotacionesConsulta_Internalname ;
      private String tblTabletoolbar_Internalname ;
      private String imgBtn_first_Internalname ;
      private String imgBtn_first_Jsonclick ;
      private String imgBtn_first_separator_Internalname ;
      private String imgBtn_first_separator_Jsonclick ;
      private String imgBtn_previous_Internalname ;
      private String imgBtn_previous_Jsonclick ;
      private String imgBtn_previous_separator_Internalname ;
      private String imgBtn_previous_separator_Jsonclick ;
      private String imgBtn_next_Internalname ;
      private String imgBtn_next_Jsonclick ;
      private String imgBtn_next_separator_Internalname ;
      private String imgBtn_next_separator_Jsonclick ;
      private String imgBtn_last_Internalname ;
      private String imgBtn_last_Jsonclick ;
      private String imgBtn_last_separator_Internalname ;
      private String imgBtn_last_separator_Jsonclick ;
      private String imgBtn_select_Internalname ;
      private String imgBtn_select_Jsonclick ;
      private String imgBtn_select_separator_Internalname ;
      private String imgBtn_select_separator_Jsonclick ;
      private String imgBtn_enter2_Internalname ;
      private String imgBtn_enter2_Jsonclick ;
      private String imgBtn_enter2_separator_Internalname ;
      private String imgBtn_enter2_separator_Jsonclick ;
      private String imgBtn_cancel2_Internalname ;
      private String imgBtn_cancel2_Jsonclick ;
      private String imgBtn_cancel2_separator_Internalname ;
      private String imgBtn_cancel2_separator_Jsonclick ;
      private String imgBtn_delete2_Internalname ;
      private String imgBtn_delete2_Jsonclick ;
      private String imgBtn_delete2_separator_Internalname ;
      private String imgBtn_delete2_separator_Jsonclick ;
      private String A61TurnoNombre ;
      private String AV21Pgmname ;
      private String sMode8 ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String Z36PacienteApellido ;
      private String Z35PacienteNombre ;
      private String Z41PacienteCI ;
      private String Z14MedicoApellido ;
      private String Z13MedicoNombre ;
      private String Z61TurnoNombre ;
      private String sDynURL ;
      private String FormProcess ;
      private String GXt_char2 ;
      private String GXt_char1 ;
      private String gxwrpcisep ;
      private String GXt_char3 ;
      private DateTime wcpOAV15ConsultaFecha ;
      private DateTime A43ConsultaFecha ;
      private DateTime AV15ConsultaFecha ;
      private DateTime Z43ConsultaFecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool wbErr ;
      private bool n63ConsultaNro ;
      private bool n68MotivoConsulta ;
      private bool n69AnotacionesConsulta ;
      private bool n67UltimoNroAsig ;
      private bool AV12IsAuthorized ;
      private bool returnInSub ;
      private String A68MotivoConsulta ;
      private String A69AnotacionesConsulta ;
      private String Z68MotivoConsulta ;
      private String Z69AnotacionesConsulta ;
      private GxWebSession AV14WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GxUnknownObjectCollection isValidOutput ;
      private GXMasterPage MasterPageObj ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynTurnoId ;
      private IDataStoreProvider pr_default ;
      private String[] T000A5_A61TurnoNombre ;
      private String[] T000A8_A36PacienteApellido ;
      private String[] T000A8_A35PacienteNombre ;
      private String[] T000A8_A41PacienteCI ;
      private int[] T000A4_A9EspecialidadId ;
      private String[] T000A4_A14MedicoApellido ;
      private String[] T000A4_A13MedicoNombre ;
      private short[] T000A9_A11EspecialidadMaxPacientes ;
      private short[] T000A7_A67UltimoNroAsig ;
      private bool[] T000A7_n67UltimoNroAsig ;
      private int[] T000A10_A9EspecialidadId ;
      private short[] T000A10_A67UltimoNroAsig ;
      private bool[] T000A10_n67UltimoNroAsig ;
      private String[] T000A10_A36PacienteApellido ;
      private String[] T000A10_A35PacienteNombre ;
      private String[] T000A10_A41PacienteCI ;
      private String[] T000A10_A14MedicoApellido ;
      private String[] T000A10_A13MedicoNombre ;
      private short[] T000A10_A11EspecialidadMaxPacientes ;
      private String[] T000A10_A61TurnoNombre ;
      private short[] T000A10_A63ConsultaNro ;
      private bool[] T000A10_n63ConsultaNro ;
      private String[] T000A10_A68MotivoConsulta ;
      private bool[] T000A10_n68MotivoConsulta ;
      private String[] T000A10_A69AnotacionesConsulta ;
      private bool[] T000A10_n69AnotacionesConsulta ;
      private DateTime[] T000A10_A43ConsultaFecha ;
      private int[] T000A10_A12MedicoId ;
      private short[] T000A10_A60TurnoId ;
      private int[] T000A10_A34PacienteId ;
      private String[] T000A11_A36PacienteApellido ;
      private String[] T000A11_A35PacienteNombre ;
      private String[] T000A11_A41PacienteCI ;
      private int[] T000A12_A9EspecialidadId ;
      private String[] T000A12_A14MedicoApellido ;
      private String[] T000A12_A13MedicoNombre ;
      private short[] T000A13_A11EspecialidadMaxPacientes ;
      private String[] T000A14_A61TurnoNombre ;
      private short[] T000A15_A67UltimoNroAsig ;
      private bool[] T000A15_n67UltimoNroAsig ;
      private DateTime[] T000A16_A43ConsultaFecha ;
      private int[] T000A16_A34PacienteId ;
      private int[] T000A16_A12MedicoId ;
      private short[] T000A16_A60TurnoId ;
      private short[] T000A3_A63ConsultaNro ;
      private bool[] T000A3_n63ConsultaNro ;
      private String[] T000A3_A68MotivoConsulta ;
      private bool[] T000A3_n68MotivoConsulta ;
      private String[] T000A3_A69AnotacionesConsulta ;
      private bool[] T000A3_n69AnotacionesConsulta ;
      private DateTime[] T000A3_A43ConsultaFecha ;
      private int[] T000A3_A12MedicoId ;
      private short[] T000A3_A60TurnoId ;
      private int[] T000A3_A34PacienteId ;
      private DateTime[] T000A17_A43ConsultaFecha ;
      private int[] T000A17_A12MedicoId ;
      private short[] T000A17_A60TurnoId ;
      private int[] T000A17_A34PacienteId ;
      private DateTime[] T000A18_A43ConsultaFecha ;
      private int[] T000A18_A12MedicoId ;
      private short[] T000A18_A60TurnoId ;
      private int[] T000A18_A34PacienteId ;
      private short[] T000A19_A63ConsultaNro ;
      private bool[] T000A19_n63ConsultaNro ;
      private String[] T000A19_A68MotivoConsulta ;
      private bool[] T000A19_n68MotivoConsulta ;
      private String[] T000A19_A69AnotacionesConsulta ;
      private bool[] T000A19_n69AnotacionesConsulta ;
      private DateTime[] T000A19_A43ConsultaFecha ;
      private int[] T000A19_A12MedicoId ;
      private short[] T000A19_A60TurnoId ;
      private int[] T000A19_A34PacienteId ;
      private short[] T000A6_A67UltimoNroAsig ;
      private bool[] T000A6_n67UltimoNroAsig ;
      private String[] T000A23_A36PacienteApellido ;
      private String[] T000A23_A35PacienteNombre ;
      private String[] T000A23_A41PacienteCI ;
      private int[] T000A24_A9EspecialidadId ;
      private String[] T000A24_A14MedicoApellido ;
      private String[] T000A24_A13MedicoNombre ;
      private short[] T000A25_A11EspecialidadMaxPacientes ;
      private String[] T000A26_A61TurnoNombre ;
      private short[] T000A27_A67UltimoNroAsig ;
      private bool[] T000A27_n67UltimoNroAsig ;
      private DateTime[] T000A29_A43ConsultaFecha ;
      private int[] T000A29_A34PacienteId ;
      private int[] T000A29_A12MedicoId ;
      private short[] T000A29_A60TurnoId ;
      private short[] T000A30_A60TurnoId ;
      private String[] T000A30_A61TurnoNombre ;
      private String[] T000A31_A36PacienteApellido ;
      private String[] T000A31_A35PacienteNombre ;
      private String[] T000A31_A41PacienteCI ;
      private int[] T000A32_A9EspecialidadId ;
      private String[] T000A32_A14MedicoApellido ;
      private String[] T000A32_A13MedicoNombre ;
      private short[] T000A33_A11EspecialidadMaxPacientes ;
      private String[] T000A34_A61TurnoNombre ;
      private short[] T000A35_A67UltimoNroAsig ;
      private bool[] T000A35_n67UltimoNroAsig ;
      private short[] T000A2_A63ConsultaNro ;
      private String[] T000A2_A68MotivoConsulta ;
      private String[] T000A2_A69AnotacionesConsulta ;
      private DateTime[] T000A2_A43ConsultaFecha ;
      private int[] T000A2_A12MedicoId ;
      private short[] T000A2_A60TurnoId ;
      private int[] T000A2_A34PacienteId ;
      private bool[] T000A2_n63ConsultaNro ;
      private bool[] T000A2_n68MotivoConsulta ;
      private bool[] T000A2_n69AnotacionesConsulta ;
      private GXWebForm Form ;
      private SdtTransactionContext AV13TrnContext ;
   }

   public class historiaclinica__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new UpdateCursor(def[19])
         ,new UpdateCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new UpdateCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new ForEachCursor(def[32])
         ,new ForEachCursor(def[33])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000A2 ;
          prmT000A2 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@PacienteId",SqlDbType.Int,6,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000A10 ;
          prmT000A10 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0} ,
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000A8 ;
          prmT000A8 = new Object[] {
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000A4 ;
          prmT000A4 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000A9 ;
          prmT000A9 = new Object[] {
          new Object[] {"@EspecialidadId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000A5 ;
          prmT000A5 = new Object[] {
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000A7 ;
          prmT000A7 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000A11 ;
          prmT000A11 = new Object[] {
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000A12 ;
          prmT000A12 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000A13 ;
          prmT000A13 = new Object[] {
          new Object[] {"@EspecialidadId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000A14 ;
          prmT000A14 = new Object[] {
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000A15 ;
          prmT000A15 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000A16 ;
          prmT000A16 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@PacienteId",SqlDbType.Int,6,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000A3 ;
          prmT000A3 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@PacienteId",SqlDbType.Int,6,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000A17 ;
          prmT000A17 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0} ,
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000A18 ;
          prmT000A18 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0} ,
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000A19 ;
          prmT000A19 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@PacienteId",SqlDbType.Int,6,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000A6 ;
          prmT000A6 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000A20 ;
          prmT000A20 = new Object[] {
          new Object[] {"@ConsultaNro",SqlDbType.SmallInt,2,0} ,
          new Object[] {"@MotivoConsulta",SqlDbType.VarChar,2097152,0} ,
          new Object[] {"@AnotacionesConsulta",SqlDbType.VarChar,2097152,0} ,
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0} ,
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000A21 ;
          prmT000A21 = new Object[] {
          new Object[] {"@ConsultaNro",SqlDbType.SmallInt,2,0} ,
          new Object[] {"@MotivoConsulta",SqlDbType.VarChar,2097152,0} ,
          new Object[] {"@AnotacionesConsulta",SqlDbType.VarChar,2097152,0} ,
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@PacienteId",SqlDbType.Int,6,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000A22 ;
          prmT000A22 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@PacienteId",SqlDbType.Int,6,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000A23 ;
          prmT000A23 = new Object[] {
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000A24 ;
          prmT000A24 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000A25 ;
          prmT000A25 = new Object[] {
          new Object[] {"@EspecialidadId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000A26 ;
          prmT000A26 = new Object[] {
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000A27 ;
          prmT000A27 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000A28 ;
          prmT000A28 = new Object[] {
          new Object[] {"@UltimoNroAsig",SqlDbType.SmallInt,2,0} ,
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000A29 ;
          prmT000A29 = new Object[] {
          } ;
          Object[] prmT000A30 ;
          prmT000A30 = new Object[] {
          } ;
          Object[] prmT000A31 ;
          prmT000A31 = new Object[] {
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000A32 ;
          prmT000A32 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000A33 ;
          prmT000A33 = new Object[] {
          new Object[] {"@EspecialidadId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000A34 ;
          prmT000A34 = new Object[] {
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000A35 ;
          prmT000A35 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("T000A2", "SELECT [ConsultaNro], [MotivoConsulta], [AnotacionesConsulta], [ConsultaFecha], [MedicoId], [TurnoId], [PacienteId] FROM [ConsultaPaciente] WITH (UPDLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [PacienteId] = @PacienteId AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A2,1,0,true,false )
             ,new CursorDef("T000A3", "SELECT [ConsultaNro], [MotivoConsulta], [AnotacionesConsulta], [ConsultaFecha], [MedicoId], [TurnoId], [PacienteId] FROM [ConsultaPaciente] WITH (NOLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [PacienteId] = @PacienteId AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A3,1,0,true,false )
             ,new CursorDef("T000A4", "SELECT [EspecialidadId], [MedicoApellido], [MedicoNombre] FROM [Medico] WITH (NOLOCK) WHERE [MedicoId] = @MedicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A4,1,0,true,false )
             ,new CursorDef("T000A5", "SELECT [TurnoNombre] FROM [Turno] WITH (NOLOCK) WHERE [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A5,1,0,true,false )
             ,new CursorDef("T000A6", "SELECT [UltimoNroAsig] FROM [Consulta] WITH (UPDLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A6,1,0,true,false )
             ,new CursorDef("T000A7", "SELECT [UltimoNroAsig] FROM [Consulta] WITH (NOLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A7,1,0,true,false )
             ,new CursorDef("T000A8", "SELECT [PacienteApellido], [PacienteNombre], [PacienteCI] FROM [Paciente] WITH (NOLOCK) WHERE [PacienteId] = @PacienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A8,1,0,true,false )
             ,new CursorDef("T000A9", "SELECT [EspecialidadMaxPacientes] FROM [Especialidad] WITH (NOLOCK) WHERE [EspecialidadId] = @EspecialidadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A9,1,0,true,false )
             ,new CursorDef("T000A10", "SELECT T3.[EspecialidadId], T6.[UltimoNroAsig], T2.[PacienteApellido], T2.[PacienteNombre], T2.[PacienteCI], T3.[MedicoApellido], T3.[MedicoNombre], T4.[EspecialidadMaxPacientes], T5.[TurnoNombre], TM1.[ConsultaNro], TM1.[MotivoConsulta], TM1.[AnotacionesConsulta], TM1.[ConsultaFecha], TM1.[MedicoId], TM1.[TurnoId], TM1.[PacienteId] FROM ((((([ConsultaPaciente] TM1 WITH (NOLOCK) INNER JOIN [Paciente] T2 WITH (NOLOCK) ON T2.[PacienteId] = TM1.[PacienteId]) INNER JOIN [Medico] T3 WITH (NOLOCK) ON T3.[MedicoId] = TM1.[MedicoId]) INNER JOIN [Especialidad] T4 WITH (NOLOCK) ON T4.[EspecialidadId] = T3.[EspecialidadId]) INNER JOIN [Turno] T5 WITH (NOLOCK) ON T5.[TurnoId] = TM1.[TurnoId]) INNER JOIN [Consulta] T6 WITH (NOLOCK) ON T6.[ConsultaFecha] = TM1.[ConsultaFecha] AND T6.[MedicoId] = TM1.[MedicoId] AND T6.[TurnoId] = TM1.[TurnoId]) WHERE TM1.[ConsultaFecha] = @ConsultaFecha and TM1.[MedicoId] = @MedicoId and TM1.[TurnoId] = @TurnoId and TM1.[PacienteId] = @PacienteId ORDER BY TM1.[ConsultaFecha], TM1.[PacienteId], TM1.[MedicoId], TM1.[TurnoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A10,100,0,true,false )
             ,new CursorDef("T000A11", "SELECT [PacienteApellido], [PacienteNombre], [PacienteCI] FROM [Paciente] WITH (NOLOCK) WHERE [PacienteId] = @PacienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A11,1,0,true,false )
             ,new CursorDef("T000A12", "SELECT [EspecialidadId], [MedicoApellido], [MedicoNombre] FROM [Medico] WITH (NOLOCK) WHERE [MedicoId] = @MedicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A12,1,0,true,false )
             ,new CursorDef("T000A13", "SELECT [EspecialidadMaxPacientes] FROM [Especialidad] WITH (NOLOCK) WHERE [EspecialidadId] = @EspecialidadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A13,1,0,true,false )
             ,new CursorDef("T000A14", "SELECT [TurnoNombre] FROM [Turno] WITH (NOLOCK) WHERE [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A14,1,0,true,false )
             ,new CursorDef("T000A15", "SELECT [UltimoNroAsig] FROM [Consulta] WITH (NOLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A15,1,0,true,false )
             ,new CursorDef("T000A16", "SELECT [ConsultaFecha], [PacienteId], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [PacienteId] = @PacienteId AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A16,1,0,true,false )
             ,new CursorDef("T000A17", "SELECT TOP 1 [ConsultaFecha], [MedicoId], [TurnoId], [PacienteId] FROM [ConsultaPaciente] WITH (NOLOCK) WHERE ( [ConsultaFecha] > @ConsultaFecha or [ConsultaFecha] = @ConsultaFecha and [MedicoId] > @MedicoId or [MedicoId] = @MedicoId and [ConsultaFecha] = @ConsultaFecha and [TurnoId] > @TurnoId or [TurnoId] = @TurnoId and [MedicoId] = @MedicoId and [ConsultaFecha] = @ConsultaFecha and [PacienteId] > @PacienteId) ORDER BY [ConsultaFecha], [PacienteId], [MedicoId], [TurnoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A17,1,0,true,true )
             ,new CursorDef("T000A18", "SELECT TOP 1 [ConsultaFecha], [MedicoId], [TurnoId], [PacienteId] FROM [ConsultaPaciente] WITH (NOLOCK) WHERE ( [ConsultaFecha] < @ConsultaFecha or [ConsultaFecha] = @ConsultaFecha and [MedicoId] < @MedicoId or [MedicoId] = @MedicoId and [ConsultaFecha] = @ConsultaFecha and [TurnoId] < @TurnoId or [TurnoId] = @TurnoId and [MedicoId] = @MedicoId and [ConsultaFecha] = @ConsultaFecha and [PacienteId] < @PacienteId) ORDER BY [ConsultaFecha] DESC, [PacienteId] DESC, [MedicoId] DESC, [TurnoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A18,1,0,true,true )
             ,new CursorDef("T000A19", "SELECT [ConsultaNro], [MotivoConsulta], [AnotacionesConsulta], [ConsultaFecha], [MedicoId], [TurnoId], [PacienteId] FROM [ConsultaPaciente] WITH (UPDLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [PacienteId] = @PacienteId AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A19,1,0,true,false )
             ,new CursorDef("T000A20", "INSERT INTO [ConsultaPaciente] ([ConsultaNro], [MotivoConsulta], [AnotacionesConsulta], [ConsultaFecha], [MedicoId], [TurnoId], [PacienteId], [Confirmado]) VALUES (@ConsultaNro, @MotivoConsulta, @AnotacionesConsulta, @ConsultaFecha, @MedicoId, @TurnoId, @PacienteId, convert(bit, 0))", GxErrorMask.GX_NOMASK,prmT000A20)
             ,new CursorDef("T000A21", "UPDATE [ConsultaPaciente] SET [ConsultaNro]=@ConsultaNro, [MotivoConsulta]=@MotivoConsulta, [AnotacionesConsulta]=@AnotacionesConsulta  WHERE [ConsultaFecha] = @ConsultaFecha AND [PacienteId] = @PacienteId AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId", GxErrorMask.GX_NOMASK,prmT000A21)
             ,new CursorDef("T000A22", "DELETE FROM [ConsultaPaciente]  WHERE [ConsultaFecha] = @ConsultaFecha AND [PacienteId] = @PacienteId AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId", GxErrorMask.GX_NOMASK,prmT000A22)
             ,new CursorDef("T000A23", "SELECT [PacienteApellido], [PacienteNombre], [PacienteCI] FROM [Paciente] WITH (NOLOCK) WHERE [PacienteId] = @PacienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A23,1,0,true,false )
             ,new CursorDef("T000A24", "SELECT [EspecialidadId], [MedicoApellido], [MedicoNombre] FROM [Medico] WITH (NOLOCK) WHERE [MedicoId] = @MedicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A24,1,0,true,false )
             ,new CursorDef("T000A25", "SELECT [EspecialidadMaxPacientes] FROM [Especialidad] WITH (NOLOCK) WHERE [EspecialidadId] = @EspecialidadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A25,1,0,true,false )
             ,new CursorDef("T000A26", "SELECT [TurnoNombre] FROM [Turno] WITH (NOLOCK) WHERE [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A26,1,0,true,false )
             ,new CursorDef("T000A27", "SELECT [UltimoNroAsig] FROM [Consulta] WITH (NOLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A27,1,0,true,false )
             ,new CursorDef("T000A28", "UPDATE [Consulta] SET [UltimoNroAsig]=@UltimoNroAsig  WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId", GxErrorMask.GX_NOMASK,prmT000A28)
             ,new CursorDef("T000A29", "SELECT [ConsultaFecha], [PacienteId], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) ORDER BY [ConsultaFecha], [PacienteId], [MedicoId], [TurnoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A29,100,0,true,false )
             ,new CursorDef("T000A30", "SELECT [TurnoId], [TurnoNombre] FROM [Turno] WITH (NOLOCK) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A30,0,0,true,false )
             ,new CursorDef("T000A31", "SELECT [PacienteApellido], [PacienteNombre], [PacienteCI] FROM [Paciente] WITH (NOLOCK) WHERE [PacienteId] = @PacienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A31,1,0,true,false )
             ,new CursorDef("T000A32", "SELECT [EspecialidadId], [MedicoApellido], [MedicoNombre] FROM [Medico] WITH (NOLOCK) WHERE [MedicoId] = @MedicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A32,1,0,true,false )
             ,new CursorDef("T000A33", "SELECT [EspecialidadMaxPacientes] FROM [Especialidad] WITH (NOLOCK) WHERE [EspecialidadId] = @EspecialidadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A33,1,0,true,false )
             ,new CursorDef("T000A34", "SELECT [TurnoNombre] FROM [Turno] WITH (NOLOCK) WHERE [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A34,1,0,true,false )
             ,new CursorDef("T000A35", "SELECT [UltimoNroAsig] FROM [Consulta] WITH (NOLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A35,1,0,true,false )
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
                ((String[]) buf[2])[0] = rslt.getLongVarchar(2) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((String[]) buf[4])[0] = rslt.getLongVarchar(3) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4) ;
                ((int[]) buf[7])[0] = rslt.getInt(5) ;
                ((short[]) buf[8])[0] = rslt.getShort(6) ;
                ((int[]) buf[9])[0] = rslt.getInt(7) ;
                break;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((String[]) buf[2])[0] = rslt.getLongVarchar(2) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((String[]) buf[4])[0] = rslt.getLongVarchar(3) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4) ;
                ((int[]) buf[7])[0] = rslt.getInt(5) ;
                ((short[]) buf[8])[0] = rslt.getShort(6) ;
                ((int[]) buf[9])[0] = rslt.getInt(7) ;
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
                ((String[]) buf[3])[0] = rslt.getString(3, 20) ;
                ((String[]) buf[4])[0] = rslt.getString(4, 20) ;
                ((String[]) buf[5])[0] = rslt.getString(5, 8) ;
                ((String[]) buf[6])[0] = rslt.getString(6, 20) ;
                ((String[]) buf[7])[0] = rslt.getString(7, 20) ;
                ((short[]) buf[8])[0] = rslt.getShort(8) ;
                ((String[]) buf[9])[0] = rslt.getString(9, 20) ;
                ((short[]) buf[10])[0] = rslt.getShort(10) ;
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((String[]) buf[12])[0] = rslt.getLongVarchar(11) ;
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((String[]) buf[14])[0] = rslt.getLongVarchar(12) ;
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(13) ;
                ((int[]) buf[17])[0] = rslt.getInt(14) ;
                ((short[]) buf[18])[0] = rslt.getShort(15) ;
                ((int[]) buf[19])[0] = rslt.getInt(16) ;
                break;
             case 9 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 8) ;
                break;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                break;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                break;
             case 12 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                break;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                break;
             case 14 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                ((short[]) buf[3])[0] = rslt.getShort(4) ;
                break;
             case 15 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                ((int[]) buf[3])[0] = rslt.getInt(4) ;
                break;
             case 16 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                ((int[]) buf[3])[0] = rslt.getInt(4) ;
                break;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((String[]) buf[2])[0] = rslt.getLongVarchar(2) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((String[]) buf[4])[0] = rslt.getLongVarchar(3) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4) ;
                ((int[]) buf[7])[0] = rslt.getInt(5) ;
                ((short[]) buf[8])[0] = rslt.getShort(6) ;
                ((int[]) buf[9])[0] = rslt.getInt(7) ;
                break;
             case 21 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 8) ;
                break;
             case 22 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                break;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                break;
             case 24 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                break;
             case 25 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                break;
             case 27 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                ((short[]) buf[3])[0] = rslt.getShort(4) ;
                break;
             case 28 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                break;
             case 29 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 8) ;
                break;
             case 30 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                break;
             case 31 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                break;
             case 32 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                break;
             case 33 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 10 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 11 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 12 :
                stmt.SetParameter(1, (short)parms[0]);
                break;
             case 13 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 14 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                stmt.SetParameter(4, (short)parms[3]);
                break;
             case 15 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                stmt.SetParameter(4, (int)parms[3]);
                break;
             case 16 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                stmt.SetParameter(4, (int)parms[3]);
                break;
             case 17 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                stmt.SetParameter(4, (short)parms[3]);
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
                if ( (bool)parms[2] )
                {
                   stmt.setNull( 2 , SqlDbType.VarChar );
                }
                else
                {
                   stmt.SetParameter(2, (String)parms[3]);
                }
                if ( (bool)parms[4] )
                {
                   stmt.setNull( 3 , SqlDbType.VarChar );
                }
                else
                {
                   stmt.SetParameter(3, (String)parms[5]);
                }
                stmt.SetParameter(4, (DateTime)parms[6]);
                stmt.SetParameter(5, (int)parms[7]);
                stmt.SetParameter(6, (short)parms[8]);
                stmt.SetParameter(7, (int)parms[9]);
                break;
             case 19 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(1, (short)parms[1]);
                }
                if ( (bool)parms[2] )
                {
                   stmt.setNull( 2 , SqlDbType.VarChar );
                }
                else
                {
                   stmt.SetParameter(2, (String)parms[3]);
                }
                if ( (bool)parms[4] )
                {
                   stmt.setNull( 3 , SqlDbType.VarChar );
                }
                else
                {
                   stmt.SetParameter(3, (String)parms[5]);
                }
                stmt.SetParameter(4, (DateTime)parms[6]);
                stmt.SetParameter(5, (int)parms[7]);
                stmt.SetParameter(6, (int)parms[8]);
                stmt.SetParameter(7, (short)parms[9]);
                break;
             case 20 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                stmt.SetParameter(4, (short)parms[3]);
                break;
             case 21 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 22 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 23 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 24 :
                stmt.SetParameter(1, (short)parms[0]);
                break;
             case 25 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 26 :
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
             case 29 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 30 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 31 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 32 :
                stmt.SetParameter(1, (short)parms[0]);
                break;
             case 33 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
       }
    }

 }

}
