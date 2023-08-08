/*
               File: Consulta
        Description: Consulta
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/24/2010 5:35:3.3
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
   public class consulta : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            GXDLATURNOID055( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"_TURNOSCONSECUTIVOS") == 0 )
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
            GX4ASATURNOSCONSECUTIVOS055( A43ConsultaFecha, A12MedicoId, A60TurnoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel5"+"_"+"_CONSULTORIOASIGNADOX") == 0 )
         {
            A43ConsultaFecha = context.localUtil.ParseDateParm( GetNextPar( )) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            A12MedicoId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            GX5ASACONSULTORIOASIGNADOX055( A43ConsultaFecha, A12MedicoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel6"+"_"+"_CANTIDADCONSULTAS") == 0 )
         {
            A43ConsultaFecha = context.localUtil.ParseDateParm( GetNextPar( )) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            A12MedicoId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            GX6ASACANTIDADCONSULTAS055( A43ConsultaFecha, A12MedicoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel7"+"_"+"_OCUPADO") == 0 )
         {
            A43ConsultaFecha = context.localUtil.ParseDateParm( GetNextPar( )) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            A60TurnoId = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
            A57ConsultorioId = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A57ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A57ConsultorioId), 3, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            GX7ASAOCUPADO055( A43ConsultaFecha, A60TurnoId, A57ConsultorioId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel8"+"_"+"_TURNOOCUPADO") == 0 )
         {
            A43ConsultaFecha = context.localUtil.ParseDateParm( GetNextPar( )) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            A60TurnoId = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
            A12MedicoId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            GX8ASATURNOOCUPADO055( A43ConsultaFecha, A60TurnoId, A12MedicoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A12MedicoId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            gxLoad_19( A12MedicoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A9EspecialidadId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            gxLoad_20( A9EspecialidadId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A60TurnoId = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            gxLoad_21( A60TurnoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_23") == 0 )
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
            gxLoad_23( A43ConsultaFecha, A12MedicoId, A60TurnoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
         {
            A57ConsultorioId = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A57ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A57ConsultorioId), 3, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            gxLoad_22( A57ConsultorioId) ;
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
         dynTurnoId.Name = "TURNOID" ;
         dynTurnoId.WebTags = "" ;
         Form.Meta.addItem("Generator", "GeneXus C#", 0) ;
         Form.Meta.addItem("Version", "10_1_3-34981", 0) ;
         Form.Meta.addItem("Description", "Consulta", 0) ;
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

      public consulta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public consulta( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default") ;
      }

      public void release( )
      {
      }

      public void execute( )
      {
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
            wb_table1_2_055( true) ;
         }
         return  ;
      }

      protected void wb_table1_2_055e( bool wbgen )
      {
         if ( wbgen )
         {
         }
         /* Execute Exit event if defined. */
      }

      protected void wb_table1_2_055( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTablemain_Internalname, tblTablemain_Internalname, "", "TableBorder100x100", 0, "", "", 1, 2, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_5_055( true) ;
         }
         return  ;
      }

      protected void wb_table2_5_055e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Control Group */
            ClassString = "Group" ;
            StyleString = "" ;
            context.WriteHtmlText( "<fieldset id=\""+grpGroupdata_Internalname+"\""+" style=\"-moz-border-radius:3pt;\""+" class=\""+ClassString+"\">") ;
            context.WriteHtmlText( "<legend class=\""+ClassString+"Title"+"\">"+"Consulta"+"</legend>") ;
            wb_table3_27_055( true) ;
         }
         return  ;
      }

      protected void wb_table3_27_055e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</fieldset>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_2_055e( true) ;
         }
         else
         {
            wb_table1_2_055e( false) ;
         }
      }

      protected void wb_table3_27_055( bool wbgen )
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
            wb_table4_33_055( true) ;
         }
         return  ;
      }

      protected void wb_table4_33_055e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"" ;
            ClassString = "BtnEnter" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtn_enter_Internalname, "Confirmar", "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, 1, "rounded", 5, bttBtn_enter_Jsonclick, "EENTER.", TempTags, "", "", "HLP_Consulta.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"" ;
            ClassString = "BtnCancel" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtn_cancel_Internalname, "Cancelar", "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "rounded", 1, bttBtn_cancel_Jsonclick, "ECANCEL.", TempTags, "", "", "HLP_Consulta.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"" ;
            ClassString = "BtnDelete" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtn_delete_Internalname, "Eliminar", "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, 1, "rounded", 5, bttBtn_delete_Jsonclick, "EDELETE.", TempTags, "", "", "HLP_Consulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_27_055e( true) ;
         }
         else
         {
            wb_table3_27_055e( false) ;
         }
      }

      protected void wb_table4_33_055( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblTextblockconsultafecha_Internalname, 1, 1, 0, "Fecha", "", "", "", 0, lblTextblockconsultafecha_Jsonclick, "", StyleString, ClassString, "HLP_Consulta.htm");
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
            GxWebStd.gx_single_line_edit( context, edtConsultaFecha_Internalname, context.localUtil.Format(A43ConsultaFecha, "99/99/99"), "", 8, "chr", 1, "row", 8, 1, edtConsultaFecha_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( A43ConsultaFecha, "99/99/99"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(38);\"", 0, edtConsultaFecha_Jsonclick, "", 0, 1, -1, true, "right", "HLP_Consulta.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockmedicoid_Internalname, 1, 1, 0, "Medico Id", "", "", "", 0, lblTextblockmedicoid_Jsonclick, "", StyleString, ClassString, "HLP_Consulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtMedicoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12MedicoId), 6, 0, ",", "")), "", 6, "chr", 1, "row", 6, 1, edtMedicoId_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A12MedicoId), "ZZZZZ9"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(43);\"", 0, edtMedicoId_Jsonclick, "", 0, 1, -1, true, "right", "HLP_Consulta.htm");
            /* Static images/pictures */
            ClassString = "Image" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgprompt_12_Internalname, "", "prompt.gif", "GeneXusX", imgprompt_12_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, imgprompt_12_Link, "", 0, "", "", StyleString, ClassString, "", "", "''", "", "HLP_Consulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockmediconombre_Internalname, 1, 1, 0, "Medico Nombre", "", "", "", 0, lblTextblockmediconombre_Jsonclick, "", StyleString, ClassString, "HLP_Consulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtMedicoNombre_Internalname, StringUtil.RTrim( A13MedicoNombre), "", 20, "chr", 1, "row", 20, 1, edtMedicoNombre_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A13MedicoNombre, "XXXXXXXXXXXXXXXXXXXX")), "", 0, edtMedicoNombre_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Consulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockmedicoapellido_Internalname, 1, 1, 0, "Medico Apellido", "", "", "", 0, lblTextblockmedicoapellido_Jsonclick, "", StyleString, ClassString, "HLP_Consulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtMedicoApellido_Internalname, StringUtil.RTrim( A14MedicoApellido), "", 20, "chr", 1, "row", 20, 1, edtMedicoApellido_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A14MedicoApellido, "XXXXXXXXXXXXXXXXXXXX")), "", 0, edtMedicoApellido_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Consulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockturnoid_Internalname, 1, 1, 0, "Turno Nombre", "", "", "", 0, lblTextblockturnoid_Jsonclick, "", StyleString, ClassString, "HLP_Consulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"" ;
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynTurnoId, dynTurnoId_Internalname, StringUtil.Str( (decimal)(A60TurnoId), 2, 0), "", "int", 1, dynTurnoId.Enabled, 0, 1, 0, 20, "chr", 0, "", StyleString, ClassString, "", 0, dynTurnoId_Jsonclick, "", TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(58);\"", true, "HLP_Consulta.htm");
            dynTurnoId.CurrentValue = StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)) ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, dynTurnoId_Internalname, "Values", (String)(dynTurnoId.ToJavascriptSource()));
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockconsultorioid_Internalname, 1, 1, 0, "Consultorio Id", "", "", "", 0, lblTextblockconsultorioid_Jsonclick, "", StyleString, ClassString, "HLP_Consulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtConsultorioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A57ConsultorioId), 3, 0, ",", "")), "", 3, "chr", 1, "row", 3, 1, edtConsultorioId_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A57ConsultorioId), "ZZ9"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(63);\"", 0, edtConsultorioId_Jsonclick, "", 0, 1, -1, true, "right", "HLP_Consulta.htm");
            /* Static images/pictures */
            ClassString = "Image" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgprompt_57_Internalname, "", "prompt.gif", "GeneXusX", imgprompt_57_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, imgprompt_57_Link, "", 0, "", "", StyleString, ClassString, "", "", "''", "", "HLP_Consulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockconsultoriodescripcion_Internalname, 1, 1, 0, "Cons. Nombre", "", "", "", 0, lblTextblockconsultoriodescripcion_Jsonclick, "", StyleString, ClassString, "HLP_Consulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtConsultorioDescripcion_Internalname, StringUtil.RTrim( A58ConsultorioDescripcion), "", 30, "chr", 1, "row", 30, 1, edtConsultorioDescripcion_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A58ConsultorioDescripcion, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")), "", 0, edtConsultorioDescripcion_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Consulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockcantnrosasig_Internalname, 1, 1, 0, "Nros.Asig.", "", "", "", 0, lblTextblockcantnrosasig_Jsonclick, "", StyleString, ClassString, "HLP_Consulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtCantNrosAsig_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A66CantNrosAsig), 2, 0, ",", "")), "", 2, "chr", 1, "row", 2, 1, edtCantNrosAsig_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A66CantNrosAsig), "Z9"), "", 0, edtCantNrosAsig_Jsonclick, "", 0, 1, -1, true, "right", "HLP_Consulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblocknrosdisponibles_Internalname, 1, 1, 0, "Nros.Disp.", "", "", "", 0, lblTextblocknrosdisponibles_Jsonclick, "", StyleString, ClassString, "HLP_Consulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtNrosDisponibles_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A65NrosDisponibles), 2, 0, ",", "")), "", 2, "chr", 1, "row", 2, 1, edtNrosDisponibles_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A65NrosDisponibles), "Z9"), "", 0, edtNrosDisponibles_Jsonclick, "", 0, 1, -1, true, "right", "HLP_Consulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockultimonroasig_Internalname, 1, 1, 0, "Ult.Nro.Asig.", "", "", "", 0, lblTextblockultimonroasig_Jsonclick, "", StyleString, ClassString, "HLP_Consulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtUltimoNroAsig_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A67UltimoNroAsig), 2, 0, ",", "")), "", 2, "chr", 1, "row", 2, 1, edtUltimoNroAsig_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A67UltimoNroAsig), "Z9"), "", 0, edtUltimoNroAsig_Jsonclick, "", 0, 1, -1, true, "right", "HLP_Consulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_33_055e( true) ;
         }
         else
         {
            wb_table4_33_055e( false) ;
         }
      }

      protected void wb_table2_5_055( bool wbgen )
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
            GxWebStd.gx_bitmap( context, imgBtn_first_Internalname, "", context.GetImagePath( "b9e06284-17ac-4c88-8937-5dbd84ad5d80", "", "GeneXusX"), "GeneXusX", imgBtn_first_Visible, 1, "", "Primero", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_first_Jsonclick, "EFIRST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Consulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_first_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_first_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_first_separator_Jsonclick, "EFIRST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Consulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_previous_Internalname, "", context.GetImagePath( "7d212604-db7b-4785-9c0d-5faffe71aa33", "", "GeneXusX"), "GeneXusX", imgBtn_previous_Visible, 1, "", "Anterior", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_previous_Jsonclick, "EPREVIOUS.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Consulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_previous_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_previous_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_previous_separator_Jsonclick, "EPREVIOUS.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Consulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_next_Internalname, "", context.GetImagePath( "1ae947cf-1354-41a9-8d59-d91daebf554f", "", "GeneXusX"), "GeneXusX", imgBtn_next_Visible, 1, "", "Siguiente", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_next_Jsonclick, "ENEXT.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Consulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_next_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_next_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_next_separator_Jsonclick, "ENEXT.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Consulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_last_Internalname, "", context.GetImagePath( "29211874-e613-48e5-9011-8017d984217e", "", "GeneXusX"), "GeneXusX", imgBtn_last_Visible, 1, "", "Ultimo", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_last_Jsonclick, "ELAST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Consulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_last_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_last_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_last_separator_Jsonclick, "ELAST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Consulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_select_Internalname, "", context.GetImagePath( "1ca03f75-9947-4d2c-90a4-e8ab9c5cedea", "", "GeneXusX"), "GeneXusX", imgBtn_select_Visible, 1, "", "Seleccionar", 0, 0, 0, "", 0, "", 0, 0, "", "", 4, imgBtn_select_Jsonclick, "ESELECT.", StyleString, ClassString, "", ""+TempTags, "", "gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CONSULTAFECHA"+"'), id:'"+"CONSULTAFECHA"+"'"+",isOut:true,isKey:false,isLastKey:false}"+","+"{Ctrl:gx.dom.el('"+"MEDICOID"+"'), id:'"+"MEDICOID"+"'"+",isOut:true,isKey:false,isLastKey:false}"+","+"{Ctrl:gx.dom.el('"+"TURNOID"+"'), id:'"+"TURNOID"+"'"+",isOut:true,isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", "HLP_Consulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_select_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_select_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 4, imgBtn_select_separator_Jsonclick, "ESELECT.", StyleString, ClassString, "", ""+TempTags, "", "gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CONSULTAFECHA"+"'), id:'"+"CONSULTAFECHA"+"'"+",isOut:true,isKey:false,isLastKey:false}"+","+"{Ctrl:gx.dom.el('"+"MEDICOID"+"'), id:'"+"MEDICOID"+"'"+",isOut:true,isKey:false,isLastKey:false}"+","+"{Ctrl:gx.dom.el('"+"TURNOID"+"'), id:'"+"TURNOID"+"'"+",isOut:true,isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", "HLP_Consulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_enter2_Internalname, "", context.GetImagePath( "2061cf2c-bd33-4433-a13e-34af954142e9", "", "GeneXusX"), "GeneXusX", imgBtn_enter2_Visible, imgBtn_enter2_Enabled, "", "Confirmar", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_enter2_Jsonclick, "EENTER.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Consulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_enter2_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_enter2_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_enter2_separator_Jsonclick, "EENTER.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Consulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_cancel2_Internalname, "", context.GetImagePath( "0e94ced8-bc34-47ff-9a53-bc683736a686", "", "GeneXusX"), "GeneXusX", imgBtn_cancel2_Visible, 1, "", "Cancelar", 0, 0, 0, "", 0, "", 0, 0, "", "", 1, imgBtn_cancel2_Jsonclick, "ECANCEL.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Consulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_cancel2_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_cancel2_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 1, imgBtn_cancel2_separator_Jsonclick, "ECANCEL.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Consulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_delete2_Internalname, "", context.GetImagePath( "7695fe89-52c9-4b7e-871e-0e11548f823e", "", "GeneXusX"), "GeneXusX", imgBtn_delete2_Visible, imgBtn_delete2_Enabled, "", "Eliminar", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_delete2_Jsonclick, "EDELETE.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Consulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_delete2_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_delete2_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_delete2_separator_Jsonclick, "EDELETE.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Consulta.htm");
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
            wb_table2_5_055e( true) ;
         }
         else
         {
            wb_table2_5_055e( false) ;
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
               A13MedicoNombre = cgiGet( edtMedicoNombre_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
               A14MedicoApellido = cgiGet( edtMedicoApellido_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
               dynTurnoId.CurrentValue = cgiGet( dynTurnoId_Internalname) ;
               A60TurnoId = (short)(NumberUtil.Val( cgiGet( dynTurnoId_Internalname), ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
               if ( ( ( context.localUtil.CToN( cgiGet( edtConsultorioId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConsultorioId_Internalname), ",", ".") > Convert.ToDecimal( 999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum"), 1, "CONSULTORIOID");
                  AnyError = 1 ;
                  GX_FocusControl = edtConsultorioId_Internalname ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true ;
                  A57ConsultorioId = 0 ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A57ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A57ConsultorioId), 3, 0)));
               }
               else
               {
                  A57ConsultorioId = (short)(context.localUtil.CToN( cgiGet( edtConsultorioId_Internalname), ",", ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A57ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A57ConsultorioId), 3, 0)));
               }
               A58ConsultorioDescripcion = cgiGet( edtConsultorioDescripcion_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A58ConsultorioDescripcion", A58ConsultorioDescripcion);
               A66CantNrosAsig = (short)(context.localUtil.CToN( cgiGet( edtCantNrosAsig_Internalname), ",", ".")) ;
               n66CantNrosAsig = false ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
               A65NrosDisponibles = (short)(context.localUtil.CToN( cgiGet( edtNrosDisponibles_Internalname), ",", ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A65NrosDisponibles", StringUtil.LTrim( StringUtil.Str( (decimal)(A65NrosDisponibles), 2, 0)));
               A67UltimoNroAsig = (short)(context.localUtil.CToN( cgiGet( edtUltimoNroAsig_Internalname), ",", ".")) ;
               n67UltimoNroAsig = false ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
               /* Read saved values. */
               Z43ConsultaFecha = context.localUtil.CToD( cgiGet( "Z43ConsultaFecha"), 0) ;
               Z12MedicoId = (int)(context.localUtil.CToN( cgiGet( "Z12MedicoId"), ",", ".")) ;
               Z60TurnoId = (short)(context.localUtil.CToN( cgiGet( "Z60TurnoId"), ",", ".")) ;
               Z67UltimoNroAsig = (short)(context.localUtil.CToN( cgiGet( "Z67UltimoNroAsig"), ",", ".")) ;
               Z57ConsultorioId = (short)(context.localUtil.CToN( cgiGet( "Z57ConsultorioId"), ",", ".")) ;
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", ".")) ;
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", ".")) ;
               Gx_mode = cgiGet( "Mode") ;
               A11EspecialidadMaxPacientes = (short)(context.localUtil.CToN( cgiGet( "ESPECIALIDADMAXPACIENTES"), ",", ".")) ;
               AV13TurnosConsecutivos = StringUtil.StrToBool( cgiGet( "_TURNOSCONSECUTIVOS")) ;
               AV9ConsultorioAsignadoX = (short)(context.localUtil.CToN( cgiGet( "_CONSULTORIOASIGNADOX"), ",", ".")) ;
               AV7CantidadConsultas = (short)(context.localUtil.CToN( cgiGet( "_CANTIDADCONSULTAS"), ",", ".")) ;
               AV11Ocupado = StringUtil.StrToBool( cgiGet( "_OCUPADO")) ;
               AV12TurnoOcupado = StringUtil.StrToBool( cgiGet( "_TURNOOCUPADO")) ;
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "_GXBSCREEN"), ",", ".")) ;
               Gx_date = context.localUtil.CToD( cgiGet( "_TODAY"), 0) ;
               AV10ConsultorioYaAsignado = (short)(context.localUtil.CToN( cgiGet( "_CONSULTORIOYAASIGNADO"), ",", ".")) ;
               A9EspecialidadId = (int)(context.localUtil.CToN( cgiGet( "ESPECIALIDADID"), ",", ".")) ;
               A61TurnoNombre = cgiGet( "TURNONOMBRE") ;
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
                  A12MedicoId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
                  A60TurnoId = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
                  getEqualNoModal( ) ;
                  if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  && (DateTime.MinValue==A43ConsultaFecha) && ( Gx_BScreen == 0 ) )
                  {
                     A43ConsultaFecha = Gx_date ;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
                  }
                  Gx_mode = "DSP" ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons_dsp( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  Gx_mode = "INS" ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  standaloneModal( ) ;
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1 ;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1 ;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1 ;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1 ;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1 ;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1 ;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1 ;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1 ;
                           AfterKeyLoadScreen( ) ;
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
            trnEnded = 0 ;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  )
            {
               /* Clear variables for new insertion. */
               InitAll055( ) ;
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
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            imgBtn_delete2_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_delete2_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_delete2_Enabled), 5, 0)));
         }
      }

      protected void disable_std_buttons_dsp( )
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
         edtMedicoId_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtMedicoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtMedicoId_Enabled), 5, 0)));
         edtMedicoNombre_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtMedicoNombre_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtMedicoNombre_Enabled), 5, 0)));
         edtMedicoApellido_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtMedicoApellido_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtMedicoApellido_Enabled), 5, 0)));
         dynTurnoId.Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, dynTurnoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(dynTurnoId.Enabled), 5, 0)));
         edtConsultorioId_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtConsultorioId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtConsultorioId_Enabled), 5, 0)));
         edtConsultorioDescripcion_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtConsultorioDescripcion_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtConsultorioDescripcion_Enabled), 5, 0)));
         edtCantNrosAsig_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtCantNrosAsig_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtCantNrosAsig_Enabled), 5, 0)));
         edtNrosDisponibles_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtNrosDisponibles_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtNrosDisponibles_Enabled), 5, 0)));
         edtUltimoNroAsig_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtUltimoNroAsig_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtUltimoNroAsig_Enabled), 5, 0)));
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

      protected void ResetCaption050( )
      {
      }

      protected void ZM055( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               Z67UltimoNroAsig = T00053_A67UltimoNroAsig[0] ;
               Z57ConsultorioId = T00053_A57ConsultorioId[0] ;
            }
            else
            {
               Z67UltimoNroAsig = A67UltimoNroAsig ;
               Z57ConsultorioId = A57ConsultorioId ;
            }
         }
         if ( GX_JID == -18 )
         {
            Z43ConsultaFecha = A43ConsultaFecha ;
            Z67UltimoNroAsig = A67UltimoNroAsig ;
            Z12MedicoId = A12MedicoId ;
            Z60TurnoId = A60TurnoId ;
            Z57ConsultorioId = A57ConsultorioId ;
            Z9EspecialidadId = A9EspecialidadId ;
            Z13MedicoNombre = A13MedicoNombre ;
            Z14MedicoApellido = A14MedicoApellido ;
            Z11EspecialidadMaxPacientes = A11EspecialidadMaxPacientes ;
            Z61TurnoNombre = A61TurnoNombre ;
            Z66CantNrosAsig = A66CantNrosAsig ;
            Z58ConsultorioDescripcion = A58ConsultorioDescripcion ;
         }
      }

      protected void standaloneNotModal( )
      {
         GXATURNOID_html055( ) ;
         edtUltimoNroAsig_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtUltimoNroAsig_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtUltimoNroAsig_Enabled), 5, 0)));
         Gx_BScreen = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( ) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         imgprompt_12_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"MEDICOID"+"'), id:'"+"MEDICOID"+"'"+",isOut:true,isKey:false,isLastKey:false}"+"],"+"null"+","+"'', false"+","+"true"+");") ;
         imgprompt_57_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0060.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CONSULTORIOID"+"'), id:'"+"CONSULTORIOID"+"'"+",isOut:true,isKey:false,isLastKey:false}"+"],"+"null"+","+"'', false"+","+"false"+");") ;
         edtUltimoNroAsig_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtUltimoNroAsig_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtUltimoNroAsig_Enabled), 5, 0)));
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  && (0==A67UltimoNroAsig) && ( Gx_BScreen == 0 ) )
         {
            A67UltimoNroAsig = 0 ;
            n67UltimoNroAsig = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  && (DateTime.MinValue==A43ConsultaFecha) && ( Gx_BScreen == 0 ) )
         {
            A43ConsultaFecha = Gx_date ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         }
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00056 */
            pr_default.execute(4, new Object[] {A60TurnoId});
            A61TurnoNombre = T00056_A61TurnoNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
            pr_default.close(4);
         }
      }

      protected void Load055( )
      {
         /* Using cursor T000511 */
         pr_default.execute(7, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound5 = 1 ;
            A9EspecialidadId = T000511_A9EspecialidadId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
            A13MedicoNombre = T000511_A13MedicoNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
            A14MedicoApellido = T000511_A14MedicoApellido[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
            A61TurnoNombre = T000511_A61TurnoNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
            A58ConsultorioDescripcion = T000511_A58ConsultorioDescripcion[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A58ConsultorioDescripcion", A58ConsultorioDescripcion);
            A67UltimoNroAsig = T000511_A67UltimoNroAsig[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
            n67UltimoNroAsig = T000511_n67UltimoNroAsig[0] ;
            A11EspecialidadMaxPacientes = T000511_A11EspecialidadMaxPacientes[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
            A57ConsultorioId = T000511_A57ConsultorioId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A57ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A57ConsultorioId), 3, 0)));
            A66CantNrosAsig = T000511_A66CantNrosAsig[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
            n66CantNrosAsig = T000511_n66CantNrosAsig[0] ;
            ZM055( -18) ;
         }
         pr_default.close(7);
         OnLoadActions055( ) ;
      }

      protected void OnLoadActions055( )
      {
         GXt_int3 = AV9ConsultorioAsignadoX ;
         new consultorioasignado(context ).execute(  A43ConsultaFecha,  A12MedicoId, out  GXt_int3) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
         AV9ConsultorioAsignadoX = GXt_int3 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV9ConsultorioAsignadoX", StringUtil.LTrim( StringUtil.Str( (decimal)(AV9ConsultorioAsignadoX), 3, 0)));
         AV10ConsultorioYaAsignado = AV9ConsultorioAsignadoX ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV10ConsultorioYaAsignado", StringUtil.LTrim( StringUtil.Str( (decimal)(AV10ConsultorioYaAsignado), 3, 0)));
         GXt_int3 = AV7CantidadConsultas ;
         new cantidadconsultas(context ).execute(  A43ConsultaFecha,  A12MedicoId, out  GXt_int3) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
         AV7CantidadConsultas = GXt_int3 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7CantidadConsultas", StringUtil.LTrim( StringUtil.Str( (decimal)(AV7CantidadConsultas), 4, 0)));
         /* Using cursor T00059 */
         pr_default.execute(6, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A66CantNrosAsig = T00059_A66CantNrosAsig[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
            n66CantNrosAsig = T00059_n66CantNrosAsig[0] ;
         }
         else
         {
            A66CantNrosAsig = 0 ;
            n66CantNrosAsig = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
         }
         pr_default.close(6);
         A65NrosDisponibles = (short)(A11EspecialidadMaxPacientes-A66CantNrosAsig) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A65NrosDisponibles", StringUtil.LTrim( StringUtil.Str( (decimal)(A65NrosDisponibles), 2, 0)));
         GXt_boolean4 = AV13TurnosConsecutivos ;
         new turnosconsecutivos(context ).execute(  A43ConsultaFecha,  A12MedicoId,  A60TurnoId, out  GXt_boolean4) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
         AV13TurnosConsecutivos = GXt_boolean4 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV13TurnosConsecutivos", StringUtil.BoolToStr( AV13TurnosConsecutivos));
         GXt_boolean4 = AV11Ocupado ;
         new consultorioocupado(context ).execute( ref  A43ConsultaFecha,  A60TurnoId,  A57ConsultorioId, out  GXt_boolean4) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A57ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A57ConsultorioId), 3, 0)));
         AV11Ocupado = GXt_boolean4 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV11Ocupado", StringUtil.BoolToStr( AV11Ocupado));
         GXt_boolean4 = AV12TurnoOcupado ;
         new turnoocupado(context ).execute(  A43ConsultaFecha,  A60TurnoId,  A12MedicoId, out  GXt_boolean4) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
         AV12TurnoOcupado = GXt_boolean4 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV12TurnoOcupado", StringUtil.BoolToStr( AV12TurnoOcupado));
      }

      protected void CheckExtendedTable055( )
      {
         Gx_BScreen = 1 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A43ConsultaFecha) || ( A43ConsultaFecha >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Consulta Fecha fuera de rango", "OutOfRange", 1, "");
            AnyError = 1 ;
         }
         /* Using cursor T00054 */
         pr_default.execute(2, new Object[] {A12MedicoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Médico'.", "ForeignKeyNotFound", 1, "MEDICOID");
            AnyError = 1 ;
            GX_FocusControl = edtMedicoId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A9EspecialidadId = T00054_A9EspecialidadId[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
         A13MedicoNombre = T00054_A13MedicoNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
         A14MedicoApellido = T00054_A14MedicoApellido[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
         pr_default.close(2);
         /* Using cursor T00055 */
         pr_default.execute(3, new Object[] {A9EspecialidadId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Especialidad'.", "ForeignKeyNotFound", 1, "");
            AnyError = 1 ;
         }
         A11EspecialidadMaxPacientes = T00055_A11EspecialidadMaxPacientes[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
         pr_default.close(3);
         GXt_int3 = AV9ConsultorioAsignadoX ;
         new consultorioasignado(context ).execute(  A43ConsultaFecha,  A12MedicoId, out  GXt_int3) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
         AV9ConsultorioAsignadoX = GXt_int3 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV9ConsultorioAsignadoX", StringUtil.LTrim( StringUtil.Str( (decimal)(AV9ConsultorioAsignadoX), 3, 0)));
         AV10ConsultorioYaAsignado = AV9ConsultorioAsignadoX ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV10ConsultorioYaAsignado", StringUtil.LTrim( StringUtil.Str( (decimal)(AV10ConsultorioYaAsignado), 3, 0)));
         GXt_int3 = AV7CantidadConsultas ;
         new cantidadconsultas(context ).execute(  A43ConsultaFecha,  A12MedicoId, out  GXt_int3) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
         AV7CantidadConsultas = GXt_int3 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7CantidadConsultas", StringUtil.LTrim( StringUtil.Str( (decimal)(AV7CantidadConsultas), 4, 0)));
         if ( AV7CantidadConsultas > 1 )
         {
            GX_msglist.addItem("Este médico ya tiene 2 turnos asignados para esta fecha", 1, "");
            AnyError = 1 ;
         }
         /* Using cursor T00056 */
         pr_default.execute(4, new Object[] {A60TurnoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Turno'.", "ForeignKeyNotFound", 1, "TURNOID");
            AnyError = 1 ;
            GX_FocusControl = dynTurnoId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A61TurnoNombre = T00056_A61TurnoNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
         pr_default.close(4);
         /* Using cursor T00059 */
         pr_default.execute(6, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A66CantNrosAsig = T00059_A66CantNrosAsig[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
            n66CantNrosAsig = T00059_n66CantNrosAsig[0] ;
         }
         else
         {
            A66CantNrosAsig = 0 ;
            n66CantNrosAsig = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
         }
         pr_default.close(6);
         A65NrosDisponibles = (short)(A11EspecialidadMaxPacientes-A66CantNrosAsig) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A65NrosDisponibles", StringUtil.LTrim( StringUtil.Str( (decimal)(A65NrosDisponibles), 2, 0)));
         GXt_boolean4 = AV13TurnosConsecutivos ;
         new turnosconsecutivos(context ).execute(  A43ConsultaFecha,  A12MedicoId,  A60TurnoId, out  GXt_boolean4) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
         AV13TurnosConsecutivos = GXt_boolean4 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV13TurnosConsecutivos", StringUtil.BoolToStr( AV13TurnosConsecutivos));
         if ( AV13TurnosConsecutivos )
         {
            GX_msglist.addItem("Este médico tiene turno consecutivo", 0, "");
         }
         if ( ( AV7CantidadConsultas == 1 ) && AV13TurnosConsecutivos && ( AV9ConsultorioAsignadoX != A57ConsultorioId ) )
         {
            GX_msglist.addItem("Turnos consecutivos. El consultorio debe ser el: "+StringUtil.Str( (decimal)(AV9ConsultorioAsignadoX), 3, 0), 1, "");
            AnyError = 1 ;
         }
         GXt_boolean4 = AV11Ocupado ;
         new consultorioocupado(context ).execute( ref  A43ConsultaFecha,  A60TurnoId,  A57ConsultorioId, out  GXt_boolean4) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A57ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A57ConsultorioId), 3, 0)));
         AV11Ocupado = GXt_boolean4 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV11Ocupado", StringUtil.BoolToStr( AV11Ocupado));
         if ( ( AV7CantidadConsultas < 2 ) && AV11Ocupado )
         {
            GX_msglist.addItem("Este consultorio ya está asignado", 1, "");
            AnyError = 1 ;
         }
         GXt_boolean4 = AV12TurnoOcupado ;
         new turnoocupado(context ).execute(  A43ConsultaFecha,  A60TurnoId,  A12MedicoId, out  GXt_boolean4) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
         AV12TurnoOcupado = GXt_boolean4 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV12TurnoOcupado", StringUtil.BoolToStr( AV12TurnoOcupado));
         if ( ( AV7CantidadConsultas < 2 ) && AV12TurnoOcupado )
         {
            GX_msglist.addItem("Este médico ya tiene este turno asignado", 1, "");
            AnyError = 1 ;
         }
         /* Using cursor T00057 */
         pr_default.execute(5, new Object[] {A57ConsultorioId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Consultorio'.", "ForeignKeyNotFound", 1, "CONSULTORIOID");
            AnyError = 1 ;
            GX_FocusControl = edtConsultorioId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A58ConsultorioDescripcion = T00057_A58ConsultorioDescripcion[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A58ConsultorioDescripcion", A58ConsultorioDescripcion);
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors055( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(6);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
         if ( IsConfirmed == 0 )
         {
            imgBtn_delete2_Enabled = RcdFound5 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_delete2_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_delete2_Enabled), 5, 0)));
         }
         else
         {
            imgBtn_delete2_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_delete2_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_delete2_Enabled), 5, 0)));
         }
      }

      protected void gxLoad_19( int A12MedicoId )
      {
         /* Using cursor T000512 */
         pr_default.execute(8, new Object[] {A12MedicoId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Médico'.", "ForeignKeyNotFound", 1, "MEDICOID");
            AnyError = 1 ;
            GX_FocusControl = edtMedicoId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A9EspecialidadId = T000512_A9EspecialidadId[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
         A13MedicoNombre = T000512_A13MedicoNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
         A14MedicoApellido = T000512_A14MedicoApellido[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A9EspecialidadId), 6, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A13MedicoNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A14MedicoApellido))+"\"");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(8) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(8);
      }

      protected void gxLoad_20( int A9EspecialidadId )
      {
         /* Using cursor T000513 */
         pr_default.execute(9, new Object[] {A9EspecialidadId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Especialidad'.", "ForeignKeyNotFound", 1, "");
            AnyError = 1 ;
         }
         A11EspecialidadMaxPacientes = T000513_A11EspecialidadMaxPacientes[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A11EspecialidadMaxPacientes), 3, 0, ".", "")))+"\"");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(9) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(9);
      }

      protected void gxLoad_21( short A60TurnoId )
      {
         /* Using cursor T000514 */
         pr_default.execute(10, new Object[] {A60TurnoId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Turno'.", "ForeignKeyNotFound", 1, "TURNOID");
            AnyError = 1 ;
            GX_FocusControl = dynTurnoId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A61TurnoNombre = T000514_A61TurnoNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A61TurnoNombre))+"\"");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(10) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(10);
      }

      protected void gxLoad_23( DateTime A43ConsultaFecha ,
                                int A12MedicoId ,
                                short A60TurnoId )
      {
         /* Using cursor T000516 */
         pr_default.execute(11, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            A66CantNrosAsig = T000516_A66CantNrosAsig[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
            n66CantNrosAsig = T000516_n66CantNrosAsig[0] ;
         }
         else
         {
            A66CantNrosAsig = 0 ;
            n66CantNrosAsig = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A66CantNrosAsig), 2, 0, ".", "")))+"\"");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(11) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(11);
      }

      protected void gxLoad_22( short A57ConsultorioId )
      {
         /* Using cursor T000517 */
         pr_default.execute(12, new Object[] {A57ConsultorioId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Consultorio'.", "ForeignKeyNotFound", 1, "CONSULTORIOID");
            AnyError = 1 ;
            GX_FocusControl = edtConsultorioId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A58ConsultorioDescripcion = T000517_A58ConsultorioDescripcion[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A58ConsultorioDescripcion", A58ConsultorioDescripcion);
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A58ConsultorioDescripcion))+"\"");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(12) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(12);
      }

      protected void GetKey055( )
      {
         /* Using cursor T000518 */
         pr_default.execute(13, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound5 = 1 ;
         }
         else
         {
            RcdFound5 = 0 ;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00053 */
         pr_default.execute(1, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM055( 18) ;
            RcdFound5 = 1 ;
            A43ConsultaFecha = T00053_A43ConsultaFecha[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            A67UltimoNroAsig = T00053_A67UltimoNroAsig[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
            n67UltimoNroAsig = T00053_n67UltimoNroAsig[0] ;
            A12MedicoId = T00053_A12MedicoId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            A60TurnoId = T00053_A60TurnoId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
            A57ConsultorioId = T00053_A57ConsultorioId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A57ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A57ConsultorioId), 3, 0)));
            Z43ConsultaFecha = A43ConsultaFecha ;
            Z12MedicoId = A12MedicoId ;
            Z60TurnoId = A60TurnoId ;
            sMode5 = Gx_mode ;
            Gx_mode = "DSP" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load055( ) ;
            Gx_mode = sMode5 ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0 ;
            InitializeNonKey055( ) ;
            sMode5 = Gx_mode ;
            Gx_mode = "DSP" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode5 ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey055( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound5 = 0 ;
         /* Using cursor T000519 */
         pr_default.execute(14, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T000519_A43ConsultaFecha[0] < A43ConsultaFecha ) || ( T000519_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000519_A12MedicoId[0] < A12MedicoId ) || ( T000519_A12MedicoId[0] == A12MedicoId ) && ( T000519_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000519_A60TurnoId[0] < A60TurnoId ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T000519_A43ConsultaFecha[0] > A43ConsultaFecha ) || ( T000519_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000519_A12MedicoId[0] > A12MedicoId ) || ( T000519_A12MedicoId[0] == A12MedicoId ) && ( T000519_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000519_A60TurnoId[0] > A60TurnoId ) ) )
            {
               A43ConsultaFecha = T000519_A43ConsultaFecha[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
               A12MedicoId = T000519_A12MedicoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
               A60TurnoId = T000519_A60TurnoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
               RcdFound5 = 1 ;
            }
         }
         pr_default.close(1);
      }

      protected void move_previous( )
      {
         RcdFound5 = 0 ;
         /* Using cursor T000520 */
         pr_default.execute(15, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( T000520_A43ConsultaFecha[0] > A43ConsultaFecha ) || ( T000520_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000520_A12MedicoId[0] > A12MedicoId ) || ( T000520_A12MedicoId[0] == A12MedicoId ) && ( T000520_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000520_A60TurnoId[0] > A60TurnoId ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( T000520_A43ConsultaFecha[0] < A43ConsultaFecha ) || ( T000520_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000520_A12MedicoId[0] < A12MedicoId ) || ( T000520_A12MedicoId[0] == A12MedicoId ) && ( T000520_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000520_A60TurnoId[0] < A60TurnoId ) ) )
            {
               A43ConsultaFecha = T000520_A43ConsultaFecha[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
               A12MedicoId = T000520_A12MedicoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
               A60TurnoId = T000520_A60TurnoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
               RcdFound5 = 1 ;
            }
         }
         pr_default.close(0);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1 ;
         GetKey055( ) ;
         if ( RcdFound5 == 1 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate"), "DuplicatePrimaryKey", 1, "CONSULTAFECHA");
               AnyError = 1 ;
               GX_FocusControl = edtConsultaFecha_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( A43ConsultaFecha != Z43ConsultaFecha ) || ( A12MedicoId != Z12MedicoId ) || ( A60TurnoId != Z60TurnoId ) )
            {
               A43ConsultaFecha = Z43ConsultaFecha ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
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
               Gx_mode = "UPD" ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
               /* Update record */
               Update055( ) ;
               GX_FocusControl = edtConsultaFecha_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( ( A43ConsultaFecha != Z43ConsultaFecha ) || ( A12MedicoId != Z12MedicoId ) || ( A60TurnoId != Z60TurnoId ) )
            {
               Gx_mode = "INS" ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
               /* Insert record */
               Insert055( ) ;
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
                  Gx_mode = "INS" ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  Insert055( ) ;
                  GX_FocusControl = edtConsultaFecha_Internalname ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( ( A43ConsultaFecha != Z43ConsultaFecha ) || ( A12MedicoId != Z12MedicoId ) || ( A60TurnoId != Z60TurnoId ) )
         {
            A43ConsultaFecha = Z43ConsultaFecha ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
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
            Gx_mode = "UPD" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
         CloseOpenCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2 ;
         IsConfirmed = 0 ;
         getEqualNoModal( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound"), "PrimaryKeyNotFound", 1, "CONSULTAFECHA");
            AnyError = 1 ;
         }
         GX_FocusControl = edtConsultorioId_Internalname ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2 ;
         IsConfirmed = 0 ;
         ScanStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow"), 0, "");
         }
         else
         {
            Gx_mode = "UPD" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConsultorioId_Internalname ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd055( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2 ;
         IsConfirmed = 0 ;
         move_previous( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow"), 0, "");
         }
         else
         {
            Gx_mode = "UPD" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConsultorioId_Internalname ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2 ;
         IsConfirmed = 0 ;
         move_next( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow"), 0, "");
         }
         else
         {
            Gx_mode = "UPD" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConsultorioId_Internalname ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2 ;
         IsConfirmed = 0 ;
         ScanStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow"), 0, "");
         }
         else
         {
            while ( RcdFound5 != 0 )
            {
               ScanNext055( ) ;
            }
            Gx_mode = "UPD" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConsultorioId_Internalname ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd055( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency055( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            /* Using cursor T000521 */
            pr_default.execute(16, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
            if ( (pr_default.getStatus(16) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Consulta"}), "RecordIsLocked", 1, "");
               AnyError = 1 ;
               return  ;
            }
            if ( (pr_default.getStatus(16) == 101) || ( Z67UltimoNroAsig != T000521_A67UltimoNroAsig[0] ) || ( Z57ConsultorioId != T000521_A57ConsultorioId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Consulta"}), "RecordWasChanged", 1, "");
               AnyError = 1 ;
               return  ;
            }
         }
      }

      protected void Insert055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM055( 0) ;
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000522 */
                     pr_default.execute(17, new Object[] {A43ConsultaFecha, n67UltimoNroAsig, A67UltimoNroAsig, A12MedicoId, A60TurnoId, A57ConsultorioId});
                     pr_default.close(17);
                     if ( (pr_default.getStatus(17) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate"), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1 ;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           GX_msglist.addItem(context.GetMessage( "GXM_sucadded"), 0, "");
                           ResetCaption050( ) ;
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
               Load055( ) ;
            }
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void Update055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000523 */
                     pr_default.execute(18, new Object[] {n67UltimoNroAsig, A67UltimoNroAsig, A57ConsultorioId, A43ConsultaFecha, A12MedicoId, A60TurnoId});
                     pr_default.close(18);
                     if ( (pr_default.getStatus(18) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Consulta"}), "RecordIsLocked", 1, "");
                        AnyError = 1 ;
                     }
                     DeferredUpdate055( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           GX_msglist.addItem(context.GetMessage( "GXM_sucupdated"), 0, "");
                           ResetCaption050( ) ;
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
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void DeferredUpdate055( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls055( ) ;
            AfterConfirm055( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete055( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000524 */
                  pr_default.execute(19, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
                  pr_default.close(19);
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound5 == 0 )
                        {
                           InitAll055( ) ;
                           Gx_mode = "INS" ;
                           context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD" ;
                           context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                        }
                        GX_msglist.addItem(context.GetMessage( "GXM_sucdeleted"), 0, "");
                        ResetCaption050( ) ;
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
         sMode5 = Gx_mode ;
         Gx_mode = "DLT" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         EndLevel055( ) ;
         Gx_mode = sMode5 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls055( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000525 */
            pr_default.execute(20, new Object[] {A12MedicoId});
            A9EspecialidadId = T000525_A9EspecialidadId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
            A13MedicoNombre = T000525_A13MedicoNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
            A14MedicoApellido = T000525_A14MedicoApellido[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
            pr_default.close(20);
            /* Using cursor T000526 */
            pr_default.execute(21, new Object[] {A9EspecialidadId});
            A11EspecialidadMaxPacientes = T000526_A11EspecialidadMaxPacientes[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
            pr_default.close(21);
            GXt_int3 = AV9ConsultorioAsignadoX ;
            new consultorioasignado(context ).execute(  A43ConsultaFecha,  A12MedicoId, out  GXt_int3) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            AV9ConsultorioAsignadoX = GXt_int3 ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV9ConsultorioAsignadoX", StringUtil.LTrim( StringUtil.Str( (decimal)(AV9ConsultorioAsignadoX), 3, 0)));
            AV10ConsultorioYaAsignado = AV9ConsultorioAsignadoX ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV10ConsultorioYaAsignado", StringUtil.LTrim( StringUtil.Str( (decimal)(AV10ConsultorioYaAsignado), 3, 0)));
            GXt_int3 = AV7CantidadConsultas ;
            new cantidadconsultas(context ).execute(  A43ConsultaFecha,  A12MedicoId, out  GXt_int3) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            AV7CantidadConsultas = GXt_int3 ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7CantidadConsultas", StringUtil.LTrim( StringUtil.Str( (decimal)(AV7CantidadConsultas), 4, 0)));
            /* Using cursor T000527 */
            pr_default.execute(22, new Object[] {A60TurnoId});
            A61TurnoNombre = T000527_A61TurnoNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
            pr_default.close(22);
            /* Using cursor T000529 */
            pr_default.execute(23, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               A66CantNrosAsig = T000529_A66CantNrosAsig[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
               n66CantNrosAsig = T000529_n66CantNrosAsig[0] ;
            }
            else
            {
               A66CantNrosAsig = 0 ;
               n66CantNrosAsig = false ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
            }
            pr_default.close(23);
            A65NrosDisponibles = (short)(A11EspecialidadMaxPacientes-A66CantNrosAsig) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A65NrosDisponibles", StringUtil.LTrim( StringUtil.Str( (decimal)(A65NrosDisponibles), 2, 0)));
            GXt_boolean4 = AV13TurnosConsecutivos ;
            new turnosconsecutivos(context ).execute(  A43ConsultaFecha,  A12MedicoId,  A60TurnoId, out  GXt_boolean4) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
            AV13TurnosConsecutivos = GXt_boolean4 ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV13TurnosConsecutivos", StringUtil.BoolToStr( AV13TurnosConsecutivos));
            GXt_boolean4 = AV12TurnoOcupado ;
            new turnoocupado(context ).execute(  A43ConsultaFecha,  A60TurnoId,  A12MedicoId, out  GXt_boolean4) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            AV12TurnoOcupado = GXt_boolean4 ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV12TurnoOcupado", StringUtil.BoolToStr( AV12TurnoOcupado));
            /* Using cursor T000530 */
            pr_default.execute(24, new Object[] {A57ConsultorioId});
            A58ConsultorioDescripcion = T000530_A58ConsultorioDescripcion[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A58ConsultorioDescripcion", A58ConsultorioDescripcion);
            pr_default.close(24);
            GXt_boolean4 = AV11Ocupado ;
            new consultorioocupado(context ).execute( ref  A43ConsultaFecha,  A60TurnoId,  A57ConsultorioId, out  GXt_boolean4) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A57ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A57ConsultorioId), 3, 0)));
            AV11Ocupado = GXt_boolean4 ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV11Ocupado", StringUtil.BoolToStr( AV11Ocupado));
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000531 */
            pr_default.execute(25, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Consulta Paciente"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1 ;
            }
            pr_default.close(25);
         }
      }

      protected void EndLevel055( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            pr_default.close(16);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete055( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(15);
            pr_default.close(14);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(22);
            pr_default.close(24);
            pr_default.close(23);
            context.CommitDataStores("Consulta");
            if ( AnyError == 0 )
            {
               ConfirmValues050( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1 ;
         }
         else
         {
            pr_default.close(15);
            pr_default.close(14);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(22);
            pr_default.close(24);
            pr_default.close(23);
            context.RollbackDataStores("Consulta");
         }
         IsModified = 0 ;
         if ( AnyError != 0 )
         {
            context.wjLoc = "" ;
            context.nUserReturn = 0 ;
         }
      }

      protected void ScanStart055( )
      {
         /* Using cursor T000532 */
         pr_default.execute(26);
         RcdFound5 = 0 ;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound5 = 1 ;
            A43ConsultaFecha = T000532_A43ConsultaFecha[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            A12MedicoId = T000532_A12MedicoId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            A60TurnoId = T000532_A60TurnoId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext055( )
      {
         pr_default.readNext(26);
         RcdFound5 = 0 ;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound5 = 1 ;
            A43ConsultaFecha = T000532_A43ConsultaFecha[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            A12MedicoId = T000532_A12MedicoId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            A60TurnoId = T000532_A60TurnoId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
         }
      }

      protected void ScanEnd055( )
      {
      }

      protected void AfterConfirm055( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert055( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate055( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete055( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete055( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate055( )
      {
         /* Before Validate Rules */
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues050( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" onsubmit=\"try{return gx.csv.validForm()}catch(e){return true;}\" name=\"MAINFORM\" method=\"post\" action=\""+formatLink("consulta.aspx") +"\" class=\""+"Form"+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
      }

      public override void RenderHtmlCloseForm( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         GxWebStd.gx_hidden_field( context, "Z43ConsultaFecha", context.localUtil.DToC( Z43ConsultaFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z12MedicoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12MedicoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z60TurnoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z60TurnoId), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z67UltimoNroAsig", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z67UltimoNroAsig), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z57ConsultorioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z57ConsultorioId), 3, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "ESPECIALIDADMAXPACIENTES", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11EspecialidadMaxPacientes), 3, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "_TURNOSCONSECUTIVOS", StringUtil.BoolToStr( AV13TurnosConsecutivos));
         GxWebStd.gx_hidden_field( context, "_CONSULTORIOASIGNADOX", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9ConsultorioAsignadoX), 3, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "_CANTIDADCONSULTAS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CantidadConsultas), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "_OCUPADO", StringUtil.BoolToStr( AV11Ocupado));
         GxWebStd.gx_hidden_field( context, "_TURNOOCUPADO", StringUtil.BoolToStr( AV12TurnoOcupado));
         GxWebStd.gx_hidden_field( context, "_GXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "_TODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "_CONSULTORIOYAASIGNADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10ConsultorioYaAsignado), 3, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ESPECIALIDADID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9EspecialidadId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "TURNONOMBRE", StringUtil.RTrim( A61TurnoNombre));
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
         return "Consulta" ;
      }

      public override String GetPgmdesc( )
      {
         return "Consulta" ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("consulta.aspx")  ;
      }

      protected void InitializeNonKey055( )
      {
         A9EspecialidadId = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
         AV13TurnosConsecutivos = false ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV13TurnosConsecutivos", StringUtil.BoolToStr( AV13TurnosConsecutivos));
         AV9ConsultorioAsignadoX = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV9ConsultorioAsignadoX", StringUtil.LTrim( StringUtil.Str( (decimal)(AV9ConsultorioAsignadoX), 3, 0)));
         AV7CantidadConsultas = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7CantidadConsultas", StringUtil.LTrim( StringUtil.Str( (decimal)(AV7CantidadConsultas), 4, 0)));
         AV11Ocupado = false ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV11Ocupado", StringUtil.BoolToStr( AV11Ocupado));
         AV12TurnoOcupado = false ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV12TurnoOcupado", StringUtil.BoolToStr( AV12TurnoOcupado));
         A65NrosDisponibles = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A65NrosDisponibles", StringUtil.LTrim( StringUtil.Str( (decimal)(A65NrosDisponibles), 2, 0)));
         A13MedicoNombre = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
         A14MedicoApellido = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
         A61TurnoNombre = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
         A57ConsultorioId = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A57ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A57ConsultorioId), 3, 0)));
         A58ConsultorioDescripcion = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A58ConsultorioDescripcion", A58ConsultorioDescripcion);
         A66CantNrosAsig = 0 ;
         n66CantNrosAsig = false ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
         AV10ConsultorioYaAsignado = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV10ConsultorioYaAsignado", StringUtil.LTrim( StringUtil.Str( (decimal)(AV10ConsultorioYaAsignado), 3, 0)));
         A11EspecialidadMaxPacientes = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
         A67UltimoNroAsig = 0 ;
         n67UltimoNroAsig = false ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
      }

      protected void InitAll055( )
      {
         A43ConsultaFecha = Gx_date ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         A12MedicoId = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
         A60TurnoId = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
         InitializeNonKey055( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A67UltimoNroAsig = i67UltimoNroAsig ;
         n67UltimoNroAsig = false ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "?165260");
         AddThemeStyleSheetFile("", "GeneXusX.css", "?2313925");
         idxLst = 1 ;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( Form.Jscriptsrc.Item(idxLst)), "?535788");
            idxLst = (int)(idxLst+1) ;
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?34981");
         context.AddJavascriptSource("consulta.js", "?535788");
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
         lblTextblockmedicoid_Internalname = "TEXTBLOCKMEDICOID" ;
         edtMedicoId_Internalname = "MEDICOID" ;
         lblTextblockmediconombre_Internalname = "TEXTBLOCKMEDICONOMBRE" ;
         edtMedicoNombre_Internalname = "MEDICONOMBRE" ;
         lblTextblockmedicoapellido_Internalname = "TEXTBLOCKMEDICOAPELLIDO" ;
         edtMedicoApellido_Internalname = "MEDICOAPELLIDO" ;
         lblTextblockturnoid_Internalname = "TEXTBLOCKTURNOID" ;
         dynTurnoId_Internalname = "TURNOID" ;
         lblTextblockconsultorioid_Internalname = "TEXTBLOCKCONSULTORIOID" ;
         edtConsultorioId_Internalname = "CONSULTORIOID" ;
         lblTextblockconsultoriodescripcion_Internalname = "TEXTBLOCKCONSULTORIODESCRIPCION" ;
         edtConsultorioDescripcion_Internalname = "CONSULTORIODESCRIPCION" ;
         lblTextblockcantnrosasig_Internalname = "TEXTBLOCKCANTNROSASIG" ;
         edtCantNrosAsig_Internalname = "CANTNROSASIG" ;
         lblTextblocknrosdisponibles_Internalname = "TEXTBLOCKNROSDISPONIBLES" ;
         edtNrosDisponibles_Internalname = "NROSDISPONIBLES" ;
         lblTextblockultimonroasig_Internalname = "TEXTBLOCKULTIMONROASIG" ;
         edtUltimoNroAsig_Internalname = "ULTIMONROASIG" ;
         tblTable2_Internalname = "TABLE2" ;
         bttBtn_enter_Internalname = "BTN_ENTER" ;
         bttBtn_cancel_Internalname = "BTN_CANCEL" ;
         bttBtn_delete_Internalname = "BTN_DELETE" ;
         tblTable1_Internalname = "TABLE1" ;
         grpGroupdata_Internalname = "GROUPDATA" ;
         tblTablemain_Internalname = "TABLEMAIN" ;
         Form.Internalname = "FORM" ;
         imgprompt_12_Internalname = "PROMPT_12" ;
         imgprompt_57_Internalname = "PROMPT_57" ;
         Form.Headerrawhtml = "" ;
         Form.Background = "" ;
         Form.Backcolor = (int)(0xFFFFFF) ;
         Form.Caption = "Consulta" ;
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
         edtUltimoNroAsig_Jsonclick = "" ;
         edtUltimoNroAsig_Enabled = 0 ;
         edtNrosDisponibles_Jsonclick = "" ;
         edtNrosDisponibles_Enabled = 0 ;
         edtCantNrosAsig_Jsonclick = "" ;
         edtCantNrosAsig_Enabled = 0 ;
         edtConsultorioDescripcion_Jsonclick = "" ;
         edtConsultorioDescripcion_Enabled = 0 ;
         imgprompt_57_Visible = 1 ;
         imgprompt_57_Link = "" ;
         edtConsultorioId_Jsonclick = "" ;
         edtConsultorioId_Enabled = 1 ;
         dynTurnoId_Jsonclick = "" ;
         dynTurnoId.Enabled = 1 ;
         edtMedicoApellido_Jsonclick = "" ;
         edtMedicoApellido_Enabled = 0 ;
         edtMedicoNombre_Jsonclick = "" ;
         edtMedicoNombre_Enabled = 0 ;
         imgprompt_12_Visible = 1 ;
         imgprompt_12_Link = "" ;
         edtMedicoId_Jsonclick = "" ;
         edtMedicoId_Enabled = 1 ;
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

      protected void GXDLATURNOID055( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "max-age=0");
         }
         context.GX_webresponse.AddString("(new Array( new Array(");
         GXDLATURNOID_data055( ) ;
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

      protected void GXATURNOID_html055( )
      {
         short gxdynajaxvalue ;
         GXDLATURNOID_data055( ) ;
         gxdynajaxindex = 1 ;
         dynTurnoId.removeAllItems();
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( gxdynajaxctrlcodr.Item(gxdynajaxindex), ".")) ;
            dynTurnoId.addItem(StringUtil.Str( (decimal)(gxdynajaxvalue), 2, 0), gxdynajaxctrldescr.Item(gxdynajaxindex), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1) ;
         }
      }

      protected void GXDLATURNOID_data055( )
      {
         /* Using cursor T000533 */
         pr_default.execute(27);
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("Todos");
         while ( (pr_default.getStatus(27) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000533_A60TurnoId[0]), 2, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000533_A61TurnoNombre[0]));
            pr_default.readNext(27);
         }
         pr_default.close(27);
      }

      protected void GX4ASATURNOSCONSECUTIVOS055( DateTime A43ConsultaFecha ,
                                                  int A12MedicoId ,
                                                  short A60TurnoId )
      {
         GXt_boolean4 = AV13TurnosConsecutivos ;
         new turnosconsecutivos(context ).execute(  A43ConsultaFecha,  A12MedicoId,  A60TurnoId, out  GXt_boolean4) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
         AV13TurnosConsecutivos = GXt_boolean4 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV13TurnosConsecutivos", StringUtil.BoolToStr( AV13TurnosConsecutivos));
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( AV13TurnosConsecutivos))+"\"");
         context.GX_webresponse.AddString(")");
         if ( true )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
      }

      protected void GX5ASACONSULTORIOASIGNADOX055( DateTime A43ConsultaFecha ,
                                                    int A12MedicoId )
      {
         GXt_int3 = AV9ConsultorioAsignadoX ;
         new consultorioasignado(context ).execute(  A43ConsultaFecha,  A12MedicoId, out  GXt_int3) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
         AV9ConsultorioAsignadoX = GXt_int3 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV9ConsultorioAsignadoX", StringUtil.LTrim( StringUtil.Str( (decimal)(AV9ConsultorioAsignadoX), 3, 0)));
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9ConsultorioAsignadoX), 3, 0, ".", "")))+"\"");
         context.GX_webresponse.AddString(")");
         if ( true )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
      }

      protected void GX6ASACANTIDADCONSULTAS055( DateTime A43ConsultaFecha ,
                                                 int A12MedicoId )
      {
         GXt_int3 = AV7CantidadConsultas ;
         new cantidadconsultas(context ).execute(  A43ConsultaFecha,  A12MedicoId, out  GXt_int3) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
         AV7CantidadConsultas = GXt_int3 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7CantidadConsultas", StringUtil.LTrim( StringUtil.Str( (decimal)(AV7CantidadConsultas), 4, 0)));
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CantidadConsultas), 4, 0, ".", "")))+"\"");
         context.GX_webresponse.AddString(")");
         if ( true )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
      }

      protected void GX7ASAOCUPADO055( DateTime A43ConsultaFecha ,
                                       short A60TurnoId ,
                                       short A57ConsultorioId )
      {
         GXt_boolean4 = AV11Ocupado ;
         new consultorioocupado(context ).execute( ref  A43ConsultaFecha,  A60TurnoId,  A57ConsultorioId, out  GXt_boolean4) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A57ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A57ConsultorioId), 3, 0)));
         AV11Ocupado = GXt_boolean4 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV11Ocupado", StringUtil.BoolToStr( AV11Ocupado));
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( AV11Ocupado))+"\"");
         context.GX_webresponse.AddString(")");
         if ( true )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
      }

      protected void GX8ASATURNOOCUPADO055( DateTime A43ConsultaFecha ,
                                            short A60TurnoId ,
                                            int A12MedicoId )
      {
         GXt_boolean4 = AV12TurnoOcupado ;
         new turnoocupado(context ).execute(  A43ConsultaFecha,  A60TurnoId,  A12MedicoId, out  GXt_boolean4) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
         AV12TurnoOcupado = GXt_boolean4 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV12TurnoOcupado", StringUtil.BoolToStr( AV12TurnoOcupado));
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( AV12TurnoOcupado))+"\"");
         context.GX_webresponse.AddString(")");
         if ( true )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0 ;
         getEqualNoModal( ) ;
         /* Using cursor T000534 */
         pr_default.execute(28, new Object[] {A12MedicoId});
         if ( (pr_default.getStatus(28) == 101) )
         {
            GX_msglist.addItem("No existe 'Médico'.", "ForeignKeyNotFound", 1, "MEDICOID");
            AnyError = 1 ;
            GX_FocusControl = edtMedicoId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A9EspecialidadId = T000534_A9EspecialidadId[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
         A13MedicoNombre = T000534_A13MedicoNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
         A14MedicoApellido = T000534_A14MedicoApellido[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
         pr_default.close(28);
         /* Using cursor T000535 */
         pr_default.execute(29, new Object[] {A9EspecialidadId});
         if ( (pr_default.getStatus(29) == 101) )
         {
            GX_msglist.addItem("No existe 'Especialidad'.", "ForeignKeyNotFound", 1, "");
            AnyError = 1 ;
         }
         A11EspecialidadMaxPacientes = T000535_A11EspecialidadMaxPacientes[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
         pr_default.close(29);
         /* Using cursor T000536 */
         pr_default.execute(30, new Object[] {A60TurnoId});
         if ( (pr_default.getStatus(30) == 101) )
         {
            GX_msglist.addItem("No existe 'Turno'.", "ForeignKeyNotFound", 1, "TURNOID");
            AnyError = 1 ;
            GX_FocusControl = dynTurnoId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A61TurnoNombre = T000536_A61TurnoNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
         pr_default.close(30);
         /* Using cursor T000538 */
         pr_default.execute(31, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(31) != 101) )
         {
            A66CantNrosAsig = T000538_A66CantNrosAsig[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
            n66CantNrosAsig = T000538_n66CantNrosAsig[0] ;
         }
         else
         {
            A66CantNrosAsig = 0 ;
            n66CantNrosAsig = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
         }
         pr_default.close(31);
         GX_FocusControl = edtConsultorioId_Internalname ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      public void Valid_Medicoid( int GX_Parm1 ,
                                  int GX_Parm2 ,
                                  DateTime GX_Parm3 ,
                                  short GX_Parm4 ,
                                  short GX_Parm5 ,
                                  String GX_Parm6 ,
                                  String GX_Parm7 ,
                                  short GX_Parm8 ,
                                  short GX_Parm9 )
      {
         A12MedicoId = GX_Parm1 ;
         A9EspecialidadId = GX_Parm2 ;
         A43ConsultaFecha = GX_Parm3 ;
         AV9ConsultorioAsignadoX = GX_Parm4 ;
         AV7CantidadConsultas = GX_Parm5 ;
         A13MedicoNombre = GX_Parm6 ;
         A14MedicoApellido = GX_Parm7 ;
         A11EspecialidadMaxPacientes = GX_Parm8 ;
         AV10ConsultorioYaAsignado = GX_Parm9 ;
         /* Using cursor T000539 */
         pr_default.execute(32, new Object[] {A12MedicoId});
         if ( (pr_default.getStatus(32) == 101) )
         {
            GX_msglist.addItem("No existe 'Médico'.", "ForeignKeyNotFound", 1, "MEDICOID");
            AnyError = 1 ;
            GX_FocusControl = edtMedicoId_Internalname ;
         }
         A9EspecialidadId = T000539_A9EspecialidadId[0] ;
         A13MedicoNombre = T000539_A13MedicoNombre[0] ;
         A14MedicoApellido = T000539_A14MedicoApellido[0] ;
         pr_default.close(32);
         /* Using cursor T000540 */
         pr_default.execute(33, new Object[] {A9EspecialidadId});
         if ( (pr_default.getStatus(33) == 101) )
         {
            GX_msglist.addItem("No existe 'Especialidad'.", "ForeignKeyNotFound", 1, "");
            AnyError = 1 ;
         }
         A11EspecialidadMaxPacientes = T000540_A11EspecialidadMaxPacientes[0] ;
         pr_default.close(33);
         GXt_int3 = AV9ConsultorioAsignadoX ;
         new consultorioasignado(context ).execute(  A43ConsultaFecha,  A12MedicoId, out  GXt_int3) ;
         AV9ConsultorioAsignadoX = GXt_int3 ;
         AV10ConsultorioYaAsignado = AV9ConsultorioAsignadoX ;
         GXt_int3 = AV7CantidadConsultas ;
         new cantidadconsultas(context ).execute(  A43ConsultaFecha,  A12MedicoId, out  GXt_int3) ;
         AV7CantidadConsultas = GXt_int3 ;
         if ( AV7CantidadConsultas > 1 )
         {
            GX_msglist.addItem("Este médico ya tiene 2 turnos asignados para esta fecha", 1, "MEDICOID");
            AnyError = 1 ;
            GX_FocusControl = edtMedicoId_Internalname ;
         }
         dynload_actions( ) ;
         if ( AnyError == 1 )
         {
            A9EspecialidadId = 0 ;
            A13MedicoNombre = "" ;
            A14MedicoApellido = "" ;
            A11EspecialidadMaxPacientes = 0 ;
         }
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(A9EspecialidadId), 6, 0, ".", ""))));
         isValidOutput.Add((Object)(StringUtil.RTrim( A13MedicoNombre)));
         isValidOutput.Add((Object)(StringUtil.RTrim( A14MedicoApellido)));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(A11EspecialidadMaxPacientes), 3, 0, ".", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9ConsultorioAsignadoX), 3, 0, ".", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10ConsultorioYaAsignado), 3, 0, ".", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CantidadConsultas), 4, 0, ".", ""))));
         isValidOutput.Add((Object)(context.GX_msglist.ToJavascriptSource()));
         context.GX_webresponse.AddString(isValidOutput.ToJSonString());
      }

      public void Valid_Turnoid( DateTime GX_Parm1 ,
                                 int GX_Parm2 ,
                                 GXCombobox dynGX_Parm3 ,
                                 short GX_Parm4 ,
                                 short GX_Parm5 ,
                                 bool GX_Parm6 ,
                                 short GX_Parm7 ,
                                 bool GX_Parm8 ,
                                 short GX_Parm9 ,
                                 short GX_Parm10 ,
                                 String GX_Parm11 ,
                                 short GX_Parm12 )
      {
         A43ConsultaFecha = GX_Parm1 ;
         A12MedicoId = GX_Parm2 ;
         dynTurnoId = dynGX_Parm3 ;
         A60TurnoId = (short)(NumberUtil.Val( dynTurnoId.CurrentValue, ".")) ;
         A11EspecialidadMaxPacientes = GX_Parm4 ;
         A66CantNrosAsig = GX_Parm5 ;
         n66CantNrosAsig = false ;
         AV13TurnosConsecutivos = GX_Parm6 ;
         AV7CantidadConsultas = GX_Parm7 ;
         AV12TurnoOcupado = GX_Parm8 ;
         A67UltimoNroAsig = GX_Parm9 ;
         n67UltimoNroAsig = false ;
         A57ConsultorioId = GX_Parm10 ;
         A61TurnoNombre = GX_Parm11 ;
         A65NrosDisponibles = GX_Parm12 ;
         context.wbHandled = 1 ;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         /* Using cursor T000541 */
         pr_default.execute(34, new Object[] {A60TurnoId});
         if ( (pr_default.getStatus(34) == 101) )
         {
            GX_msglist.addItem("No existe 'Turno'.", "ForeignKeyNotFound", 1, "TURNOID");
            AnyError = 1 ;
            GX_FocusControl = dynTurnoId_Internalname ;
         }
         A61TurnoNombre = T000541_A61TurnoNombre[0] ;
         pr_default.close(34);
         /* Using cursor T000543 */
         pr_default.execute(35, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(35) != 101) )
         {
            A66CantNrosAsig = T000543_A66CantNrosAsig[0] ;
            n66CantNrosAsig = T000543_n66CantNrosAsig[0] ;
         }
         else
         {
            A66CantNrosAsig = 0 ;
            n66CantNrosAsig = false ;
         }
         pr_default.close(35);
         A65NrosDisponibles = (short)(A11EspecialidadMaxPacientes-A66CantNrosAsig) ;
         GXt_boolean4 = AV13TurnosConsecutivos ;
         new turnosconsecutivos(context ).execute(  A43ConsultaFecha,  A12MedicoId,  A60TurnoId, out  GXt_boolean4) ;
         AV13TurnosConsecutivos = GXt_boolean4 ;
         if ( AV13TurnosConsecutivos )
         {
            GX_msglist.addItem("Este médico tiene turno consecutivo", 0, "");
         }
         GXt_boolean4 = AV12TurnoOcupado ;
         new turnoocupado(context ).execute(  A43ConsultaFecha,  A60TurnoId,  A12MedicoId, out  GXt_boolean4) ;
         AV12TurnoOcupado = GXt_boolean4 ;
         if ( ( AV7CantidadConsultas < 2 ) && AV12TurnoOcupado )
         {
            GX_msglist.addItem("Este médico ya tiene este turno asignado", 1, "TURNOID");
            AnyError = 1 ;
            GX_FocusControl = dynTurnoId_Internalname ;
         }
         dynload_actions( ) ;
         if ( AnyError == 1 )
         {
            A9EspecialidadId = 0 ;
            A13MedicoNombre = "" ;
            A14MedicoApellido = "" ;
            A11EspecialidadMaxPacientes = 0 ;
            A61TurnoNombre = "" ;
            A66CantNrosAsig = 0 ;
            n66CantNrosAsig = false ;
            A58ConsultorioDescripcion = "" ;
         }
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(A57ConsultorioId), 3, 0, ".", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(A67UltimoNroAsig), 2, 0, ".", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(A9EspecialidadId), 6, 0, ".", ""))));
         isValidOutput.Add((Object)(StringUtil.RTrim( A13MedicoNombre)));
         isValidOutput.Add((Object)(StringUtil.RTrim( A14MedicoApellido)));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(A11EspecialidadMaxPacientes), 3, 0, ".", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9ConsultorioAsignadoX), 3, 0, ".", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10ConsultorioYaAsignado), 3, 0, ".", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CantidadConsultas), 4, 0, ".", ""))));
         isValidOutput.Add((Object)(StringUtil.RTrim( A61TurnoNombre)));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(A66CantNrosAsig), 2, 0, ".", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(A65NrosDisponibles), 2, 0, ".", ""))));
         isValidOutput.Add((Object)(StringUtil.BoolToStr( AV13TurnosConsecutivos)));
         isValidOutput.Add((Object)(StringUtil.BoolToStr( AV11Ocupado)));
         isValidOutput.Add((Object)(StringUtil.BoolToStr( AV12TurnoOcupado)));
         isValidOutput.Add((Object)(StringUtil.RTrim( A58ConsultorioDescripcion)));
         isValidOutput.Add((Object)(StringUtil.RTrim( Gx_mode)));
         isValidOutput.Add((Object)(context.localUtil.DToC( Z43ConsultaFecha, 0, "/")));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12MedicoId), 6, 0, ",", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(Z60TurnoId), 2, 0, ",", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(Z57ConsultorioId), 3, 0, ",", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(Z67UltimoNroAsig), 2, 0, ",", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9EspecialidadId), 6, 0, ",", ""))));
         isValidOutput.Add((Object)(StringUtil.RTrim( Z13MedicoNombre)));
         isValidOutput.Add((Object)(StringUtil.RTrim( Z14MedicoApellido)));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11EspecialidadMaxPacientes), 3, 0, ",", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(ZV9ConsultorioAsignadoX), 3, 0, ",", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(ZV10ConsultorioYaAsignado), 3, 0, ",", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(ZV7CantidadConsultas), 4, 0, ",", ""))));
         isValidOutput.Add((Object)(StringUtil.RTrim( Z61TurnoNombre)));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(Z66CantNrosAsig), 2, 0, ",", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(Z65NrosDisponibles), 2, 0, ",", ""))));
         isValidOutput.Add((Object)(StringUtil.BoolToStr( ZV13TurnosConsecutivos)));
         isValidOutput.Add((Object)(StringUtil.BoolToStr( ZV11Ocupado)));
         isValidOutput.Add((Object)(StringUtil.BoolToStr( ZV12TurnoOcupado)));
         isValidOutput.Add((Object)(StringUtil.RTrim( Z58ConsultorioDescripcion)));
         isValidOutput.Add((Object)(imgBtn_enter2_Enabled));
         isValidOutput.Add((Object)(context.GX_msglist.ToJavascriptSource()));
         context.GX_webresponse.AddString(isValidOutput.ToJSonString());
      }

      public void Valid_Consultorioid( short GX_Parm1 ,
                                       DateTime GX_Parm2 ,
                                       GXCombobox dynGX_Parm3 ,
                                       short GX_Parm4 ,
                                       bool GX_Parm5 ,
                                       bool GX_Parm6 ,
                                       short GX_Parm7 ,
                                       String GX_Parm8 )
      {
         A57ConsultorioId = GX_Parm1 ;
         A43ConsultaFecha = GX_Parm2 ;
         dynTurnoId = dynGX_Parm3 ;
         A60TurnoId = (short)(NumberUtil.Val( dynTurnoId.CurrentValue, ".")) ;
         AV7CantidadConsultas = GX_Parm4 ;
         AV11Ocupado = GX_Parm5 ;
         AV13TurnosConsecutivos = GX_Parm6 ;
         AV9ConsultorioAsignadoX = GX_Parm7 ;
         A58ConsultorioDescripcion = GX_Parm8 ;
         /* Using cursor T000544 */
         pr_default.execute(36, new Object[] {A57ConsultorioId});
         if ( (pr_default.getStatus(36) == 101) )
         {
            GX_msglist.addItem("No existe 'Consultorio'.", "ForeignKeyNotFound", 1, "CONSULTORIOID");
            AnyError = 1 ;
            GX_FocusControl = edtConsultorioId_Internalname ;
         }
         A58ConsultorioDescripcion = T000544_A58ConsultorioDescripcion[0] ;
         pr_default.close(36);
         GXt_boolean4 = AV11Ocupado ;
         new consultorioocupado(context ).execute( ref  A43ConsultaFecha,  A60TurnoId,  A57ConsultorioId, out  GXt_boolean4) ;
         AV11Ocupado = GXt_boolean4 ;
         if ( ( AV7CantidadConsultas < 2 ) && AV11Ocupado )
         {
            GX_msglist.addItem("Este consultorio ya está asignado", 1, "CONSULTORIOID");
            AnyError = 1 ;
            GX_FocusControl = edtConsultorioId_Internalname ;
         }
         if ( ( AV7CantidadConsultas == 1 ) && AV13TurnosConsecutivos && ( AV9ConsultorioAsignadoX != A57ConsultorioId ) )
         {
            GX_msglist.addItem("Turnos consecutivos. El consultorio debe ser el: "+StringUtil.Str( (decimal)(AV9ConsultorioAsignadoX), 3, 0), 1, "CONSULTORIOID");
            AnyError = 1 ;
            GX_FocusControl = edtConsultorioId_Internalname ;
         }
         dynload_actions( ) ;
         if ( AnyError == 1 )
         {
            A58ConsultorioDescripcion = "" ;
         }
         isValidOutput.Add((Object)(StringUtil.RTrim( A58ConsultorioDescripcion)));
         isValidOutput.Add((Object)(StringUtil.BoolToStr( AV11Ocupado)));
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
         pr_default.close(26);
         pr_default.close(15);
         pr_default.close(14);
         pr_default.close(32);
         pr_default.close(28);
         pr_default.close(20);
         pr_default.close(33);
         pr_default.close(29);
         pr_default.close(21);
         pr_default.close(34);
         pr_default.close(30);
         pr_default.close(22);
         pr_default.close(36);
         pr_default.close(24);
         pr_default.close(35);
         pr_default.close(31);
         pr_default.close(23);
      }

      public override void initialize( )
      {
         sPrefix = "" ;
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
         lblTextblockmedicoid_Jsonclick = "" ;
         lblTextblockmediconombre_Jsonclick = "" ;
         A13MedicoNombre = "" ;
         lblTextblockmedicoapellido_Jsonclick = "" ;
         A14MedicoApellido = "" ;
         lblTextblockturnoid_Jsonclick = "" ;
         lblTextblockconsultorioid_Jsonclick = "" ;
         lblTextblockconsultoriodescripcion_Jsonclick = "" ;
         A58ConsultorioDescripcion = "" ;
         lblTextblockcantnrosasig_Jsonclick = "" ;
         lblTextblocknrosdisponibles_Jsonclick = "" ;
         lblTextblockultimonroasig_Jsonclick = "" ;
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
         Gx_mode = "" ;
         Gx_date = DateTime.MinValue ;
         A61TurnoNombre = "" ;
         sEvt = "" ;
         EvtGridId = "" ;
         EvtRowId = "" ;
         sEvtType = "" ;
         Z13MedicoNombre = "" ;
         Z14MedicoApellido = "" ;
         Z61TurnoNombre = "" ;
         Z58ConsultorioDescripcion = "" ;
         T00056_A61TurnoNombre = new String[] {""} ;
         T000511_A9EspecialidadId = new int[1] ;
         T000511_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T000511_A13MedicoNombre = new String[] {""} ;
         T000511_A14MedicoApellido = new String[] {""} ;
         T000511_A61TurnoNombre = new String[] {""} ;
         T000511_A58ConsultorioDescripcion = new String[] {""} ;
         T000511_A67UltimoNroAsig = new short[1] ;
         T000511_n67UltimoNroAsig = new bool[] {false} ;
         T000511_A11EspecialidadMaxPacientes = new short[1] ;
         T000511_A12MedicoId = new int[1] ;
         T000511_A60TurnoId = new short[1] ;
         T000511_A57ConsultorioId = new short[1] ;
         T000511_A66CantNrosAsig = new short[1] ;
         T000511_n66CantNrosAsig = new bool[] {false} ;
         T00059_A66CantNrosAsig = new short[1] ;
         T00059_n66CantNrosAsig = new bool[] {false} ;
         T00054_A9EspecialidadId = new int[1] ;
         T00054_A13MedicoNombre = new String[] {""} ;
         T00054_A14MedicoApellido = new String[] {""} ;
         T00055_A11EspecialidadMaxPacientes = new short[1] ;
         T00057_A58ConsultorioDescripcion = new String[] {""} ;
         T000512_A9EspecialidadId = new int[1] ;
         T000512_A13MedicoNombre = new String[] {""} ;
         T000512_A14MedicoApellido = new String[] {""} ;
         T000513_A11EspecialidadMaxPacientes = new short[1] ;
         T000514_A61TurnoNombre = new String[] {""} ;
         T000516_A66CantNrosAsig = new short[1] ;
         T000516_n66CantNrosAsig = new bool[] {false} ;
         T000517_A58ConsultorioDescripcion = new String[] {""} ;
         T000518_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T000518_A12MedicoId = new int[1] ;
         T000518_A60TurnoId = new short[1] ;
         T00053_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T00053_A67UltimoNroAsig = new short[1] ;
         T00053_n67UltimoNroAsig = new bool[] {false} ;
         T00053_A12MedicoId = new int[1] ;
         T00053_A60TurnoId = new short[1] ;
         T00053_A57ConsultorioId = new short[1] ;
         sMode5 = "" ;
         T000519_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T000519_A12MedicoId = new int[1] ;
         T000519_A60TurnoId = new short[1] ;
         T000520_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T000520_A12MedicoId = new int[1] ;
         T000520_A60TurnoId = new short[1] ;
         T000521_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T000521_A67UltimoNroAsig = new short[1] ;
         T000521_n67UltimoNroAsig = new bool[] {false} ;
         T000521_A12MedicoId = new int[1] ;
         T000521_A60TurnoId = new short[1] ;
         T000521_A57ConsultorioId = new short[1] ;
         T000525_A9EspecialidadId = new int[1] ;
         T000525_A13MedicoNombre = new String[] {""} ;
         T000525_A14MedicoApellido = new String[] {""} ;
         T000526_A11EspecialidadMaxPacientes = new short[1] ;
         T000527_A61TurnoNombre = new String[] {""} ;
         T000529_A66CantNrosAsig = new short[1] ;
         T000529_n66CantNrosAsig = new bool[] {false} ;
         T000530_A58ConsultorioDescripcion = new String[] {""} ;
         T000531_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T000531_A34PacienteId = new int[1] ;
         T000531_A12MedicoId = new int[1] ;
         T000531_A60TurnoId = new short[1] ;
         T000532_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T000532_A12MedicoId = new int[1] ;
         T000532_A60TurnoId = new short[1] ;
         sDynURL = "" ;
         FormProcess = "" ;
         GXt_char2 = "" ;
         GXt_char1 = "" ;
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "" ;
         T000533_A60TurnoId = new short[1] ;
         T000533_A61TurnoNombre = new String[] {""} ;
         T000534_A9EspecialidadId = new int[1] ;
         T000534_A13MedicoNombre = new String[] {""} ;
         T000534_A14MedicoApellido = new String[] {""} ;
         T000535_A11EspecialidadMaxPacientes = new short[1] ;
         T000536_A61TurnoNombre = new String[] {""} ;
         T000538_A66CantNrosAsig = new short[1] ;
         T000538_n66CantNrosAsig = new bool[] {false} ;
         T000539_A9EspecialidadId = new int[1] ;
         T000539_A13MedicoNombre = new String[] {""} ;
         T000539_A14MedicoApellido = new String[] {""} ;
         T000540_A11EspecialidadMaxPacientes = new short[1] ;
         isValidOutput = new GxUnknownObjectCollection();
         T000541_A61TurnoNombre = new String[] {""} ;
         T000543_A66CantNrosAsig = new short[1] ;
         T000543_n66CantNrosAsig = new bool[] {false} ;
         T000544_A58ConsultorioDescripcion = new String[] {""} ;
         GXt_char5 = "" ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.consulta__default(),
            new Object[][] {
                new Object[] {
               T00052_A43ConsultaFecha, T00052_A67UltimoNroAsig, T00052_n67UltimoNroAsig, T00052_A12MedicoId, T00052_A60TurnoId, T00052_A57ConsultorioId
               }
               , new Object[] {
               T00053_A43ConsultaFecha, T00053_A67UltimoNroAsig, T00053_n67UltimoNroAsig, T00053_A12MedicoId, T00053_A60TurnoId, T00053_A57ConsultorioId
               }
               , new Object[] {
               T00054_A9EspecialidadId, T00054_A13MedicoNombre, T00054_A14MedicoApellido
               }
               , new Object[] {
               T00055_A11EspecialidadMaxPacientes
               }
               , new Object[] {
               T00056_A61TurnoNombre
               }
               , new Object[] {
               T00057_A58ConsultorioDescripcion
               }
               , new Object[] {
               T00059_A66CantNrosAsig, T00059_n66CantNrosAsig
               }
               , new Object[] {
               T000511_A9EspecialidadId, T000511_A43ConsultaFecha, T000511_A13MedicoNombre, T000511_A14MedicoApellido, T000511_A61TurnoNombre, T000511_A58ConsultorioDescripcion, T000511_A67UltimoNroAsig, T000511_n67UltimoNroAsig, T000511_A11EspecialidadMaxPacientes, T000511_A12MedicoId,
               T000511_A60TurnoId, T000511_A57ConsultorioId, T000511_A66CantNrosAsig, T000511_n66CantNrosAsig
               }
               , new Object[] {
               T000512_A9EspecialidadId, T000512_A13MedicoNombre, T000512_A14MedicoApellido
               }
               , new Object[] {
               T000513_A11EspecialidadMaxPacientes
               }
               , new Object[] {
               T000514_A61TurnoNombre
               }
               , new Object[] {
               T000516_A66CantNrosAsig, T000516_n66CantNrosAsig
               }
               , new Object[] {
               T000517_A58ConsultorioDescripcion
               }
               , new Object[] {
               T000518_A43ConsultaFecha, T000518_A12MedicoId, T000518_A60TurnoId
               }
               , new Object[] {
               T000519_A43ConsultaFecha, T000519_A12MedicoId, T000519_A60TurnoId
               }
               , new Object[] {
               T000520_A43ConsultaFecha, T000520_A12MedicoId, T000520_A60TurnoId
               }
               , new Object[] {
               T000521_A43ConsultaFecha, T000521_A67UltimoNroAsig, T000521_n67UltimoNroAsig, T000521_A12MedicoId, T000521_A60TurnoId, T000521_A57ConsultorioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000525_A9EspecialidadId, T000525_A13MedicoNombre, T000525_A14MedicoApellido
               }
               , new Object[] {
               T000526_A11EspecialidadMaxPacientes
               }
               , new Object[] {
               T000527_A61TurnoNombre
               }
               , new Object[] {
               T000529_A66CantNrosAsig, T000529_n66CantNrosAsig
               }
               , new Object[] {
               T000530_A58ConsultorioDescripcion
               }
               , new Object[] {
               T000531_A43ConsultaFecha, T000531_A34PacienteId, T000531_A12MedicoId, T000531_A60TurnoId
               }
               , new Object[] {
               T000532_A43ConsultaFecha, T000532_A12MedicoId, T000532_A60TurnoId
               }
               , new Object[] {
               T000533_A60TurnoId, T000533_A61TurnoNombre
               }
               , new Object[] {
               T000534_A9EspecialidadId, T000534_A13MedicoNombre, T000534_A14MedicoApellido
               }
               , new Object[] {
               T000535_A11EspecialidadMaxPacientes
               }
               , new Object[] {
               T000536_A61TurnoNombre
               }
               , new Object[] {
               T000538_A66CantNrosAsig, T000538_n66CantNrosAsig
               }
               , new Object[] {
               T000539_A9EspecialidadId, T000539_A13MedicoNombre, T000539_A14MedicoApellido
               }
               , new Object[] {
               T000540_A11EspecialidadMaxPacientes
               }
               , new Object[] {
               T000541_A61TurnoNombre
               }
               , new Object[] {
               T000543_A66CantNrosAsig, T000543_n66CantNrosAsig
               }
               , new Object[] {
               T000544_A58ConsultorioDescripcion
               }
            }
         );
         A67UltimoNroAsig = 0 ;
         n67UltimoNroAsig = false ;
         Z43ConsultaFecha = Gx_date ;
         Gx_date = DateTimeUtil.Today( ) ;
      }

      private short RcdFound5 ;
      private short GxWebError ;
      private short A60TurnoId ;
      private short A57ConsultorioId ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A66CantNrosAsig ;
      private short A65NrosDisponibles ;
      private short A67UltimoNroAsig ;
      private short Z60TurnoId ;
      private short Z67UltimoNroAsig ;
      private short Z57ConsultorioId ;
      private short A11EspecialidadMaxPacientes ;
      private short AV9ConsultorioAsignadoX ;
      private short AV7CantidadConsultas ;
      private short Gx_BScreen ;
      private short AV10ConsultorioYaAsignado ;
      private short GX_JID ;
      private short Z11EspecialidadMaxPacientes ;
      private short Z66CantNrosAsig ;
      private short gxajaxcallmode ;
      private short i67UltimoNroAsig ;
      private short ZV9ConsultorioAsignadoX ;
      private short ZV10ConsultorioYaAsignado ;
      private short ZV7CantidadConsultas ;
      private short Z65NrosDisponibles ;
      private short GXt_int3 ;
      private int A12MedicoId ;
      private int A9EspecialidadId ;
      private int trnEnded ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int edtConsultaFecha_Enabled ;
      private int edtMedicoId_Enabled ;
      private int imgprompt_12_Visible ;
      private int edtMedicoNombre_Enabled ;
      private int edtMedicoApellido_Enabled ;
      private int edtConsultorioId_Enabled ;
      private int imgprompt_57_Visible ;
      private int edtConsultorioDescripcion_Enabled ;
      private int edtCantNrosAsig_Enabled ;
      private int edtNrosDisponibles_Enabled ;
      private int edtUltimoNroAsig_Enabled ;
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
      private int Z12MedicoId ;
      private int Z9EspecialidadId ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private String sPrefix ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
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
      private String lblTextblockmedicoid_Internalname ;
      private String lblTextblockmedicoid_Jsonclick ;
      private String edtMedicoId_Internalname ;
      private String edtMedicoId_Jsonclick ;
      private String imgprompt_12_Internalname ;
      private String imgprompt_12_Link ;
      private String lblTextblockmediconombre_Internalname ;
      private String lblTextblockmediconombre_Jsonclick ;
      private String edtMedicoNombre_Internalname ;
      private String A13MedicoNombre ;
      private String edtMedicoNombre_Jsonclick ;
      private String lblTextblockmedicoapellido_Internalname ;
      private String lblTextblockmedicoapellido_Jsonclick ;
      private String edtMedicoApellido_Internalname ;
      private String A14MedicoApellido ;
      private String edtMedicoApellido_Jsonclick ;
      private String lblTextblockturnoid_Internalname ;
      private String lblTextblockturnoid_Jsonclick ;
      private String dynTurnoId_Internalname ;
      private String dynTurnoId_Jsonclick ;
      private String lblTextblockconsultorioid_Internalname ;
      private String lblTextblockconsultorioid_Jsonclick ;
      private String edtConsultorioId_Internalname ;
      private String edtConsultorioId_Jsonclick ;
      private String imgprompt_57_Internalname ;
      private String imgprompt_57_Link ;
      private String lblTextblockconsultoriodescripcion_Internalname ;
      private String lblTextblockconsultoriodescripcion_Jsonclick ;
      private String edtConsultorioDescripcion_Internalname ;
      private String A58ConsultorioDescripcion ;
      private String edtConsultorioDescripcion_Jsonclick ;
      private String lblTextblockcantnrosasig_Internalname ;
      private String lblTextblockcantnrosasig_Jsonclick ;
      private String edtCantNrosAsig_Internalname ;
      private String edtCantNrosAsig_Jsonclick ;
      private String lblTextblocknrosdisponibles_Internalname ;
      private String lblTextblocknrosdisponibles_Jsonclick ;
      private String edtNrosDisponibles_Internalname ;
      private String edtNrosDisponibles_Jsonclick ;
      private String lblTextblockultimonroasig_Internalname ;
      private String lblTextblockultimonroasig_Jsonclick ;
      private String edtUltimoNroAsig_Internalname ;
      private String edtUltimoNroAsig_Jsonclick ;
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
      private String Gx_mode ;
      private String A61TurnoNombre ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String Z13MedicoNombre ;
      private String Z14MedicoApellido ;
      private String Z61TurnoNombre ;
      private String Z58ConsultorioDescripcion ;
      private String sMode5 ;
      private String sDynURL ;
      private String FormProcess ;
      private String GXt_char2 ;
      private String GXt_char1 ;
      private String gxwrpcisep ;
      private String GXt_char5 ;
      private DateTime A43ConsultaFecha ;
      private DateTime Z43ConsultaFecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool wbErr ;
      private bool n66CantNrosAsig ;
      private bool n67UltimoNroAsig ;
      private bool AV13TurnosConsecutivos ;
      private bool AV11Ocupado ;
      private bool AV12TurnoOcupado ;
      private bool ZV13TurnosConsecutivos ;
      private bool ZV11Ocupado ;
      private bool ZV12TurnoOcupado ;
      private bool GXt_boolean4 ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GxUnknownObjectCollection isValidOutput ;
      private GXMasterPage MasterPageObj ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynTurnoId ;
      private IDataStoreProvider pr_default ;
      private String[] T00056_A61TurnoNombre ;
      private int[] T000511_A9EspecialidadId ;
      private DateTime[] T000511_A43ConsultaFecha ;
      private String[] T000511_A13MedicoNombre ;
      private String[] T000511_A14MedicoApellido ;
      private String[] T000511_A61TurnoNombre ;
      private String[] T000511_A58ConsultorioDescripcion ;
      private short[] T000511_A67UltimoNroAsig ;
      private bool[] T000511_n67UltimoNroAsig ;
      private short[] T000511_A11EspecialidadMaxPacientes ;
      private int[] T000511_A12MedicoId ;
      private short[] T000511_A60TurnoId ;
      private short[] T000511_A57ConsultorioId ;
      private short[] T000511_A66CantNrosAsig ;
      private bool[] T000511_n66CantNrosAsig ;
      private short[] T00059_A66CantNrosAsig ;
      private bool[] T00059_n66CantNrosAsig ;
      private int[] T00054_A9EspecialidadId ;
      private String[] T00054_A13MedicoNombre ;
      private String[] T00054_A14MedicoApellido ;
      private short[] T00055_A11EspecialidadMaxPacientes ;
      private String[] T00057_A58ConsultorioDescripcion ;
      private int[] T000512_A9EspecialidadId ;
      private String[] T000512_A13MedicoNombre ;
      private String[] T000512_A14MedicoApellido ;
      private short[] T000513_A11EspecialidadMaxPacientes ;
      private String[] T000514_A61TurnoNombre ;
      private short[] T000516_A66CantNrosAsig ;
      private bool[] T000516_n66CantNrosAsig ;
      private String[] T000517_A58ConsultorioDescripcion ;
      private DateTime[] T000518_A43ConsultaFecha ;
      private int[] T000518_A12MedicoId ;
      private short[] T000518_A60TurnoId ;
      private DateTime[] T00053_A43ConsultaFecha ;
      private short[] T00053_A67UltimoNroAsig ;
      private bool[] T00053_n67UltimoNroAsig ;
      private int[] T00053_A12MedicoId ;
      private short[] T00053_A60TurnoId ;
      private short[] T00053_A57ConsultorioId ;
      private DateTime[] T000519_A43ConsultaFecha ;
      private int[] T000519_A12MedicoId ;
      private short[] T000519_A60TurnoId ;
      private DateTime[] T000520_A43ConsultaFecha ;
      private int[] T000520_A12MedicoId ;
      private short[] T000520_A60TurnoId ;
      private DateTime[] T000521_A43ConsultaFecha ;
      private short[] T000521_A67UltimoNroAsig ;
      private bool[] T000521_n67UltimoNroAsig ;
      private int[] T000521_A12MedicoId ;
      private short[] T000521_A60TurnoId ;
      private short[] T000521_A57ConsultorioId ;
      private int[] T000525_A9EspecialidadId ;
      private String[] T000525_A13MedicoNombre ;
      private String[] T000525_A14MedicoApellido ;
      private short[] T000526_A11EspecialidadMaxPacientes ;
      private String[] T000527_A61TurnoNombre ;
      private short[] T000529_A66CantNrosAsig ;
      private bool[] T000529_n66CantNrosAsig ;
      private String[] T000530_A58ConsultorioDescripcion ;
      private DateTime[] T000531_A43ConsultaFecha ;
      private int[] T000531_A34PacienteId ;
      private int[] T000531_A12MedicoId ;
      private short[] T000531_A60TurnoId ;
      private DateTime[] T000532_A43ConsultaFecha ;
      private int[] T000532_A12MedicoId ;
      private short[] T000532_A60TurnoId ;
      private short[] T000533_A60TurnoId ;
      private String[] T000533_A61TurnoNombre ;
      private int[] T000534_A9EspecialidadId ;
      private String[] T000534_A13MedicoNombre ;
      private String[] T000534_A14MedicoApellido ;
      private short[] T000535_A11EspecialidadMaxPacientes ;
      private String[] T000536_A61TurnoNombre ;
      private short[] T000538_A66CantNrosAsig ;
      private bool[] T000538_n66CantNrosAsig ;
      private int[] T000539_A9EspecialidadId ;
      private String[] T000539_A13MedicoNombre ;
      private String[] T000539_A14MedicoApellido ;
      private short[] T000540_A11EspecialidadMaxPacientes ;
      private String[] T000541_A61TurnoNombre ;
      private short[] T000543_A66CantNrosAsig ;
      private bool[] T000543_n66CantNrosAsig ;
      private String[] T000544_A58ConsultorioDescripcion ;
      private DateTime[] T00052_A43ConsultaFecha ;
      private short[] T00052_A67UltimoNroAsig ;
      private int[] T00052_A12MedicoId ;
      private short[] T00052_A60TurnoId ;
      private short[] T00052_A57ConsultorioId ;
      private bool[] T00052_n67UltimoNroAsig ;
      private GXWebForm Form ;
   }

   public class consulta__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new UpdateCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new ForEachCursor(def[32])
         ,new ForEachCursor(def[33])
         ,new ForEachCursor(def[34])
         ,new ForEachCursor(def[35])
         ,new ForEachCursor(def[36])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00052 ;
          prmT00052 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000511 ;
          prmT000511 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT00054 ;
          prmT00054 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00055 ;
          prmT00055 = new Object[] {
          new Object[] {"@EspecialidadId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00056 ;
          prmT00056 = new Object[] {
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT00059 ;
          prmT00059 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT00057 ;
          prmT00057 = new Object[] {
          new Object[] {"@ConsultorioId",SqlDbType.SmallInt,3,0}
          } ;
          Object[] prmT000512 ;
          prmT000512 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000513 ;
          prmT000513 = new Object[] {
          new Object[] {"@EspecialidadId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000514 ;
          prmT000514 = new Object[] {
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000516 ;
          prmT000516 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000517 ;
          prmT000517 = new Object[] {
          new Object[] {"@ConsultorioId",SqlDbType.SmallInt,3,0}
          } ;
          Object[] prmT000518 ;
          prmT000518 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT00053 ;
          prmT00053 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000519 ;
          prmT000519 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000520 ;
          prmT000520 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000521 ;
          prmT000521 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000522 ;
          prmT000522 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@UltimoNroAsig",SqlDbType.SmallInt,2,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0} ,
          new Object[] {"@ConsultorioId",SqlDbType.SmallInt,3,0}
          } ;
          Object[] prmT000523 ;
          prmT000523 = new Object[] {
          new Object[] {"@UltimoNroAsig",SqlDbType.SmallInt,2,0} ,
          new Object[] {"@ConsultorioId",SqlDbType.SmallInt,3,0} ,
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000524 ;
          prmT000524 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000525 ;
          prmT000525 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000526 ;
          prmT000526 = new Object[] {
          new Object[] {"@EspecialidadId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000527 ;
          prmT000527 = new Object[] {
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000529 ;
          prmT000529 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000530 ;
          prmT000530 = new Object[] {
          new Object[] {"@ConsultorioId",SqlDbType.SmallInt,3,0}
          } ;
          Object[] prmT000531 ;
          prmT000531 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000532 ;
          prmT000532 = new Object[] {
          } ;
          Object[] prmT000533 ;
          prmT000533 = new Object[] {
          } ;
          Object[] prmT000534 ;
          prmT000534 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000535 ;
          prmT000535 = new Object[] {
          new Object[] {"@EspecialidadId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000536 ;
          prmT000536 = new Object[] {
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000538 ;
          prmT000538 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000539 ;
          prmT000539 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000540 ;
          prmT000540 = new Object[] {
          new Object[] {"@EspecialidadId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000541 ;
          prmT000541 = new Object[] {
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000543 ;
          prmT000543 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000544 ;
          prmT000544 = new Object[] {
          new Object[] {"@ConsultorioId",SqlDbType.SmallInt,3,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("T00052", "SELECT [ConsultaFecha], [UltimoNroAsig], [MedicoId], [TurnoId], [ConsultorioId] FROM [Consulta] WITH (UPDLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00052,1,0,true,false )
             ,new CursorDef("T00053", "SELECT [ConsultaFecha], [UltimoNroAsig], [MedicoId], [TurnoId], [ConsultorioId] FROM [Consulta] WITH (NOLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00053,1,0,true,false )
             ,new CursorDef("T00054", "SELECT [EspecialidadId], [MedicoNombre], [MedicoApellido] FROM [Medico] WITH (NOLOCK) WHERE [MedicoId] = @MedicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00054,1,0,true,false )
             ,new CursorDef("T00055", "SELECT [EspecialidadMaxPacientes] FROM [Especialidad] WITH (NOLOCK) WHERE [EspecialidadId] = @EspecialidadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00055,1,0,true,false )
             ,new CursorDef("T00056", "SELECT [TurnoNombre] FROM [Turno] WITH (NOLOCK) WHERE [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00056,1,0,true,false )
             ,new CursorDef("T00057", "SELECT [ConsultorioDescripcion] FROM [Consultorio] WITH (NOLOCK) WHERE [ConsultorioId] = @ConsultorioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00057,1,0,true,false )
             ,new CursorDef("T00059", "SELECT COALESCE( T1.[CantNrosAsig], 0) AS CantNrosAsig FROM (SELECT COUNT(*) AS CantNrosAsig, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T1 WHERE T1.[ConsultaFecha] = @ConsultaFecha AND T1.[MedicoId] = @MedicoId AND T1.[TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00059,1,0,true,false )
             ,new CursorDef("T000511", "SELECT T2.[EspecialidadId], TM1.[ConsultaFecha], T2.[MedicoNombre], T2.[MedicoApellido], T4.[TurnoNombre], T6.[ConsultorioDescripcion], TM1.[UltimoNroAsig], T3.[EspecialidadMaxPacientes], TM1.[MedicoId], TM1.[TurnoId], TM1.[ConsultorioId], COALESCE( T5.[CantNrosAsig], 0) AS CantNrosAsig FROM ((((([Consulta] TM1 WITH (NOLOCK) INNER JOIN [Medico] T2 WITH (NOLOCK) ON T2.[MedicoId] = TM1.[MedicoId]) INNER JOIN [Especialidad] T3 WITH (NOLOCK) ON T3.[EspecialidadId] = T2.[EspecialidadId]) INNER JOIN [Turno] T4 WITH (NOLOCK) ON T4.[TurnoId] = TM1.[TurnoId]) LEFT JOIN (SELECT COUNT(*) AS CantNrosAsig, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T5 ON T5.[ConsultaFecha] = TM1.[ConsultaFecha] AND T5.[MedicoId] = TM1.[MedicoId] AND T5.[TurnoId] = TM1.[TurnoId]) INNER JOIN [Consultorio] T6 WITH (NOLOCK) ON T6.[ConsultorioId] = TM1.[ConsultorioId]) WHERE TM1.[ConsultaFecha] = @ConsultaFecha and TM1.[MedicoId] = @MedicoId and TM1.[TurnoId] = @TurnoId ORDER BY TM1.[ConsultaFecha], TM1.[MedicoId], TM1.[TurnoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000511,100,0,true,false )
             ,new CursorDef("T000512", "SELECT [EspecialidadId], [MedicoNombre], [MedicoApellido] FROM [Medico] WITH (NOLOCK) WHERE [MedicoId] = @MedicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000512,1,0,true,false )
             ,new CursorDef("T000513", "SELECT [EspecialidadMaxPacientes] FROM [Especialidad] WITH (NOLOCK) WHERE [EspecialidadId] = @EspecialidadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000513,1,0,true,false )
             ,new CursorDef("T000514", "SELECT [TurnoNombre] FROM [Turno] WITH (NOLOCK) WHERE [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000514,1,0,true,false )
             ,new CursorDef("T000516", "SELECT COALESCE( T1.[CantNrosAsig], 0) AS CantNrosAsig FROM (SELECT COUNT(*) AS CantNrosAsig, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T1 WHERE T1.[ConsultaFecha] = @ConsultaFecha AND T1.[MedicoId] = @MedicoId AND T1.[TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000516,1,0,true,false )
             ,new CursorDef("T000517", "SELECT [ConsultorioDescripcion] FROM [Consultorio] WITH (NOLOCK) WHERE [ConsultorioId] = @ConsultorioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000517,1,0,true,false )
             ,new CursorDef("T000518", "SELECT [ConsultaFecha], [MedicoId], [TurnoId] FROM [Consulta] WITH (NOLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000518,1,0,true,false )
             ,new CursorDef("T000519", "SELECT TOP 1 [ConsultaFecha], [MedicoId], [TurnoId] FROM [Consulta] WITH (NOLOCK) WHERE ( [ConsultaFecha] > @ConsultaFecha or [ConsultaFecha] = @ConsultaFecha and [MedicoId] > @MedicoId or [MedicoId] = @MedicoId and [ConsultaFecha] = @ConsultaFecha and [TurnoId] > @TurnoId) ORDER BY [ConsultaFecha], [MedicoId], [TurnoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000519,1,0,true,true )
             ,new CursorDef("T000520", "SELECT TOP 1 [ConsultaFecha], [MedicoId], [TurnoId] FROM [Consulta] WITH (NOLOCK) WHERE ( [ConsultaFecha] < @ConsultaFecha or [ConsultaFecha] = @ConsultaFecha and [MedicoId] < @MedicoId or [MedicoId] = @MedicoId and [ConsultaFecha] = @ConsultaFecha and [TurnoId] < @TurnoId) ORDER BY [ConsultaFecha] DESC, [MedicoId] DESC, [TurnoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000520,1,0,true,true )
             ,new CursorDef("T000521", "SELECT [ConsultaFecha], [UltimoNroAsig], [MedicoId], [TurnoId], [ConsultorioId] FROM [Consulta] WITH (UPDLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000521,1,0,true,false )
             ,new CursorDef("T000522", "INSERT INTO [Consulta] ([ConsultaFecha], [UltimoNroAsig], [MedicoId], [TurnoId], [ConsultorioId]) VALUES (@ConsultaFecha, @UltimoNroAsig, @MedicoId, @TurnoId, @ConsultorioId)", GxErrorMask.GX_NOMASK,prmT000522)
             ,new CursorDef("T000523", "UPDATE [Consulta] SET [UltimoNroAsig]=@UltimoNroAsig, [ConsultorioId]=@ConsultorioId  WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId", GxErrorMask.GX_NOMASK,prmT000523)
             ,new CursorDef("T000524", "DELETE FROM [Consulta]  WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId", GxErrorMask.GX_NOMASK,prmT000524)
             ,new CursorDef("T000525", "SELECT [EspecialidadId], [MedicoNombre], [MedicoApellido] FROM [Medico] WITH (NOLOCK) WHERE [MedicoId] = @MedicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000525,1,0,true,false )
             ,new CursorDef("T000526", "SELECT [EspecialidadMaxPacientes] FROM [Especialidad] WITH (NOLOCK) WHERE [EspecialidadId] = @EspecialidadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000526,1,0,true,false )
             ,new CursorDef("T000527", "SELECT [TurnoNombre] FROM [Turno] WITH (NOLOCK) WHERE [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000527,1,0,true,false )
             ,new CursorDef("T000529", "SELECT COALESCE( T1.[CantNrosAsig], 0) AS CantNrosAsig FROM (SELECT COUNT(*) AS CantNrosAsig, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T1 WHERE T1.[ConsultaFecha] = @ConsultaFecha AND T1.[MedicoId] = @MedicoId AND T1.[TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000529,1,0,true,false )
             ,new CursorDef("T000530", "SELECT [ConsultorioDescripcion] FROM [Consultorio] WITH (NOLOCK) WHERE [ConsultorioId] = @ConsultorioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000530,1,0,true,false )
             ,new CursorDef("T000531", "SELECT TOP 1 [ConsultaFecha], [PacienteId], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000531,1,0,true,true )
             ,new CursorDef("T000532", "SELECT [ConsultaFecha], [MedicoId], [TurnoId] FROM [Consulta] WITH (NOLOCK) ORDER BY [ConsultaFecha], [MedicoId], [TurnoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000532,100,0,true,false )
             ,new CursorDef("T000533", "SELECT [TurnoId], [TurnoNombre] FROM [Turno] WITH (NOLOCK) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000533,0,0,true,false )
             ,new CursorDef("T000534", "SELECT [EspecialidadId], [MedicoNombre], [MedicoApellido] FROM [Medico] WITH (NOLOCK) WHERE [MedicoId] = @MedicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000534,1,0,true,false )
             ,new CursorDef("T000535", "SELECT [EspecialidadMaxPacientes] FROM [Especialidad] WITH (NOLOCK) WHERE [EspecialidadId] = @EspecialidadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000535,1,0,true,false )
             ,new CursorDef("T000536", "SELECT [TurnoNombre] FROM [Turno] WITH (NOLOCK) WHERE [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000536,1,0,true,false )
             ,new CursorDef("T000538", "SELECT COALESCE( T1.[CantNrosAsig], 0) AS CantNrosAsig FROM (SELECT COUNT(*) AS CantNrosAsig, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T1 WHERE T1.[ConsultaFecha] = @ConsultaFecha AND T1.[MedicoId] = @MedicoId AND T1.[TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000538,1,0,true,false )
             ,new CursorDef("T000539", "SELECT [EspecialidadId], [MedicoNombre], [MedicoApellido] FROM [Medico] WITH (NOLOCK) WHERE [MedicoId] = @MedicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000539,1,0,true,false )
             ,new CursorDef("T000540", "SELECT [EspecialidadMaxPacientes] FROM [Especialidad] WITH (NOLOCK) WHERE [EspecialidadId] = @EspecialidadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000540,1,0,true,false )
             ,new CursorDef("T000541", "SELECT [TurnoNombre] FROM [Turno] WITH (NOLOCK) WHERE [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000541,1,0,true,false )
             ,new CursorDef("T000543", "SELECT COALESCE( T1.[CantNrosAsig], 0) AS CantNrosAsig FROM (SELECT COUNT(*) AS CantNrosAsig, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T1 WHERE T1.[ConsultaFecha] = @ConsultaFecha AND T1.[MedicoId] = @MedicoId AND T1.[TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000543,1,0,true,false )
             ,new CursorDef("T000544", "SELECT [ConsultorioDescripcion] FROM [Consultorio] WITH (NOLOCK) WHERE [ConsultorioId] = @ConsultorioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000544,1,0,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3) ;
                ((short[]) buf[4])[0] = rslt.getShort(4) ;
                ((short[]) buf[5])[0] = rslt.getShort(5) ;
                break;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3) ;
                ((short[]) buf[4])[0] = rslt.getShort(4) ;
                ((short[]) buf[5])[0] = rslt.getShort(5) ;
                break;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                break;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                break;
             case 4 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                break;
             case 5 :
                ((String[]) buf[0])[0] = rslt.getString(1, 30) ;
                break;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                break;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                ((String[]) buf[3])[0] = rslt.getString(4, 20) ;
                ((String[]) buf[4])[0] = rslt.getString(5, 20) ;
                ((String[]) buf[5])[0] = rslt.getString(6, 30) ;
                ((short[]) buf[6])[0] = rslt.getShort(7) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((short[]) buf[8])[0] = rslt.getShort(8) ;
                ((int[]) buf[9])[0] = rslt.getInt(9) ;
                ((short[]) buf[10])[0] = rslt.getShort(10) ;
                ((short[]) buf[11])[0] = rslt.getShort(11) ;
                ((short[]) buf[12])[0] = rslt.getShort(12) ;
                ((bool[]) buf[13])[0] = rslt.wasNull(12);
                break;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                break;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                break;
             case 10 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                break;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                break;
             case 12 :
                ((String[]) buf[0])[0] = rslt.getString(1, 30) ;
                break;
             case 13 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                break;
             case 14 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                break;
             case 15 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                break;
             case 16 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3) ;
                ((short[]) buf[4])[0] = rslt.getShort(4) ;
                ((short[]) buf[5])[0] = rslt.getShort(5) ;
                break;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                break;
             case 21 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                break;
             case 22 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                break;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                break;
             case 24 :
                ((String[]) buf[0])[0] = rslt.getString(1, 30) ;
                break;
             case 25 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                ((short[]) buf[3])[0] = rslt.getShort(4) ;
                break;
             case 26 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                break;
             case 27 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                break;
             case 28 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                break;
             case 29 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                break;
             case 30 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                break;
             case 31 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                break;
             case 32 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                break;
             case 33 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                break;
             case 34 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                break;
             case 35 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                break;
             case 36 :
                ((String[]) buf[0])[0] = rslt.getString(1, 30) ;
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
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 1 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 2 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 3 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 4 :
                stmt.SetParameter(1, (short)parms[0]);
                break;
             case 5 :
                stmt.SetParameter(1, (short)parms[0]);
                break;
             case 6 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 7 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 8 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 9 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 10 :
                stmt.SetParameter(1, (short)parms[0]);
                break;
             case 11 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
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
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 15 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 16 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 17 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                if ( (bool)parms[1] )
                {
                   stmt.setNull( 2 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(2, (short)parms[2]);
                }
                stmt.SetParameter(3, (int)parms[3]);
                stmt.SetParameter(4, (short)parms[4]);
                stmt.SetParameter(5, (short)parms[5]);
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
                stmt.SetParameter(2, (short)parms[2]);
                stmt.SetParameter(3, (DateTime)parms[3]);
                stmt.SetParameter(4, (int)parms[4]);
                stmt.SetParameter(5, (short)parms[5]);
                break;
             case 19 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 20 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 21 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 22 :
                stmt.SetParameter(1, (short)parms[0]);
                break;
             case 23 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 24 :
                stmt.SetParameter(1, (short)parms[0]);
                break;
             case 25 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 28 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 29 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 30 :
                stmt.SetParameter(1, (short)parms[0]);
                break;
             case 31 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 32 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 33 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 34 :
                stmt.SetParameter(1, (short)parms[0]);
                break;
             case 35 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 36 :
                stmt.SetParameter(1, (short)parms[0]);
                break;
       }
    }

 }

}
