/*
               File: GestionConsulta
        Description: Gestion Consulta
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/24/2010 5:51:55.91
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
   public class gestionconsulta : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            GXDLATURNOID095( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_23") == 0 )
         {
            A12MedicoId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            gxLoad_23( A12MedicoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_24") == 0 )
         {
            A9EspecialidadId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            gxLoad_24( A9EspecialidadId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_25") == 0 )
         {
            A60TurnoId = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            gxLoad_25( A60TurnoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_27") == 0 )
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
            gxLoad_27( A43ConsultaFecha, A12MedicoId, A60TurnoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_28") == 0 )
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
            gxLoad_28( A43ConsultaFecha, A12MedicoId, A60TurnoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_26") == 0 )
         {
            A57ConsultorioId = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A57ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A57ConsultorioId), 3, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            gxLoad_26( A57ConsultorioId) ;
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
               AV21ConsultaFecha = context.localUtil.ParseDateParm( GetNextPar( )) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV21ConsultaFecha", context.localUtil.Format(AV21ConsultaFecha, "99/99/99"));
               AV22MedicoId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV22MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV22MedicoId), 6, 0)));
               AV23TurnoId = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV23TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV23TurnoId), 2, 0)));
            }
         }
         dynTurnoId.Name = "TURNOID" ;
         dynTurnoId.WebTags = "" ;
         Form.Meta.addItem("Generator", "GeneXus C#", 0) ;
         Form.Meta.addItem("Version", "10_1_3-34981", 0) ;
         Form.Meta.addItem("Description", "Gestion Consulta", 0) ;
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

      public gestionconsulta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public gestionconsulta( IGxContext context )
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
                           int aP2_MedicoId ,
                           short aP3_TurnoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV21ConsultaFecha = aP1_ConsultaFecha;
         this.AV22MedicoId = aP2_MedicoId;
         this.AV23TurnoId = aP3_TurnoId;
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
            wb_table1_2_095( true) ;
         }
         return  ;
      }

      protected void wb_table1_2_095e( bool wbgen )
      {
         if ( wbgen )
         {
         }
         /* Execute Exit event if defined. */
      }

      protected void wb_table1_2_095( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTablemain_Internalname, tblTablemain_Internalname, "", "TableBorder100x100", 0, "", "", 1, 2, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_5_095( true) ;
         }
         return  ;
      }

      protected void wb_table2_5_095e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Control Group */
            ClassString = "Group" ;
            StyleString = "" ;
            context.WriteHtmlText( "<fieldset id=\""+grpGroupdata_Internalname+"\""+" style=\"-moz-border-radius:3pt;\""+" class=\""+ClassString+"\">") ;
            context.WriteHtmlText( "<legend class=\""+ClassString+"Title"+"\">"+"Gestion Consulta"+"</legend>") ;
            wb_table3_27_095( true) ;
         }
         return  ;
      }

      protected void wb_table3_27_095e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</fieldset>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_2_095e( true) ;
         }
         else
         {
            wb_table1_2_095e( false) ;
         }
      }

      protected void wb_table3_27_095( bool wbgen )
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
            wb_table4_33_095( true) ;
         }
         return  ;
      }

      protected void wb_table4_33_095e( bool wbgen )
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
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtn_enter_Internalname, "Confirmar", "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, 1, "rounded", 5, bttBtn_enter_Jsonclick, "EENTER.", TempTags, "", "", "HLP_GestionConsulta.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"" ;
            ClassString = "BtnCancel" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtn_cancel_Internalname, "Cancelar", "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "rounded", 1, bttBtn_cancel_Jsonclick, "ECANCEL.", TempTags, "", "", "HLP_GestionConsulta.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"" ;
            ClassString = "BtnDelete" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtn_delete_Internalname, "Eliminar", "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, 0, "rounded", 5, bttBtn_delete_Jsonclick, "EDELETE.", TempTags, "", "", "HLP_GestionConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_27_095e( true) ;
         }
         else
         {
            wb_table3_27_095e( false) ;
         }
      }

      protected void wb_table4_33_095( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblTextblockconsultafecha_Internalname, 1, 1, 0, "Fecha", "", "", "", 0, lblTextblockconsultafecha_Jsonclick, "", StyleString, ClassString, "HLP_GestionConsulta.htm");
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
            GxWebStd.gx_single_line_edit( context, edtConsultaFecha_Internalname, context.localUtil.Format(A43ConsultaFecha, "99/99/99"), "", 8, "chr", 1, "row", 8, 1, edtConsultaFecha_Enabled, 1, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( A43ConsultaFecha, "99/99/99"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(38);\"", 0, edtConsultaFecha_Jsonclick, "", 0, 1, -1, true, "right", "HLP_GestionConsulta.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockmedicoid_Internalname, 1, 1, 0, "Medico Id", "", "", "", 0, lblTextblockmedicoid_Jsonclick, "", StyleString, ClassString, "HLP_GestionConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtMedicoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12MedicoId), 6, 0, ",", "")), "", 6, "chr", 1, "row", 6, 1, edtMedicoId_Enabled, 1, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A12MedicoId), "ZZZZZ9"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(43);\"", 0, edtMedicoId_Jsonclick, "", 0, 1, -1, true, "right", "HLP_GestionConsulta.htm");
            /* Static images/pictures */
            ClassString = "Image" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgprompt_12_Internalname, "", "prompt.gif", "GeneXusX", imgprompt_12_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, imgprompt_12_Link, "", 0, "", "", StyleString, ClassString, "", "", "''", "", "HLP_GestionConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockmediconombre_Internalname, 1, 1, 0, "Medico Nombre", "", "", "", 0, lblTextblockmediconombre_Jsonclick, "", StyleString, ClassString, "HLP_GestionConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtMedicoNombre_Internalname, StringUtil.RTrim( A13MedicoNombre), "", 20, "chr", 1, "row", 20, 1, edtMedicoNombre_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A13MedicoNombre, "XXXXXXXXXXXXXXXXXXXX")), "", 0, edtMedicoNombre_Jsonclick, "", 0, 1, -1, true, "left", "HLP_GestionConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockmedicoapellido_Internalname, 1, 1, 0, "Medico Apellido", "", "", "", 0, lblTextblockmedicoapellido_Jsonclick, "", StyleString, ClassString, "HLP_GestionConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtMedicoApellido_Internalname, StringUtil.RTrim( A14MedicoApellido), "", 20, "chr", 1, "row", 20, 1, edtMedicoApellido_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A14MedicoApellido, "XXXXXXXXXXXXXXXXXXXX")), "", 0, edtMedicoApellido_Jsonclick, "", 0, 1, -1, true, "left", "HLP_GestionConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockturnoid_Internalname, 1, 1, 0, "Turno Nombre", "", "", "", 0, lblTextblockturnoid_Jsonclick, "", StyleString, ClassString, "HLP_GestionConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"" ;
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynTurnoId, dynTurnoId_Internalname, StringUtil.Str( (decimal)(A60TurnoId), 2, 0), "", "int", 1, dynTurnoId.Enabled, 1, 1, 0, 20, "chr", 0, "", StyleString, ClassString, "", 0, dynTurnoId_Jsonclick, "", TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(58);\"", true, "HLP_GestionConsulta.htm");
            dynTurnoId.CurrentValue = StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)) ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, dynTurnoId_Internalname, "Values", (String)(dynTurnoId.ToJavascriptSource()));
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockconsultorioid_Internalname, 1, 1, 0, "Consultorio Id", "", "", "", 0, lblTextblockconsultorioid_Jsonclick, "", StyleString, ClassString, "HLP_GestionConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtConsultorioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A57ConsultorioId), 3, 0, ",", "")), "", 3, "chr", 1, "row", 3, 1, edtConsultorioId_Enabled, 1, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A57ConsultorioId), "ZZ9"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(63);\"", 0, edtConsultorioId_Jsonclick, "", 0, 1, -1, true, "right", "HLP_GestionConsulta.htm");
            /* Static images/pictures */
            ClassString = "Image" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgprompt_57_Internalname, "", "prompt.gif", "GeneXusX", imgprompt_57_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, imgprompt_57_Link, "", 0, "", "", StyleString, ClassString, "", "", "''", "", "HLP_GestionConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockcantnrosasig_Internalname, 1, 1, 0, "Nros.Asig.", "", "", "", 0, lblTextblockcantnrosasig_Jsonclick, "", StyleString, ClassString, "HLP_GestionConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtCantNrosAsig_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A66CantNrosAsig), 2, 0, ",", "")), "", 2, "chr", 1, "row", 2, 1, edtCantNrosAsig_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A66CantNrosAsig), "Z9"), "", 0, edtCantNrosAsig_Jsonclick, "", 0, 1, -1, true, "right", "HLP_GestionConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblocknrosdisponibles_Internalname, 1, 1, 0, "Nros.Disp.", "", "", "", 0, lblTextblocknrosdisponibles_Jsonclick, "", StyleString, ClassString, "HLP_GestionConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtNrosDisponibles_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A65NrosDisponibles), 2, 0, ",", "")), "", 2, "chr", 1, "row", 2, 1, edtNrosDisponibles_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A65NrosDisponibles), "Z9"), "", 0, edtNrosDisponibles_Jsonclick, "", 0, 1, -1, true, "right", "HLP_GestionConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockultimonroasig_Internalname, 1, 1, 0, "Ult.Nro.Asig.", "", "", "", 0, lblTextblockultimonroasig_Jsonclick, "", StyleString, ClassString, "HLP_GestionConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtUltimoNroAsig_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A67UltimoNroAsig), 2, 0, ",", "")), "", 2, "chr", 1, "row", 2, 1, edtUltimoNroAsig_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A67UltimoNroAsig), "Z9"), "", 0, edtUltimoNroAsig_Jsonclick, "", 0, 1, -1, true, "right", "HLP_GestionConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockcantpacconf_Internalname, 1, 1, 0, "Pac Conf", "", "", "", 0, lblTextblockcantpacconf_Jsonclick, "", StyleString, ClassString, "HLP_GestionConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtCantPacConf_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A70CantPacConf), 2, 0, ",", "")), "", 2, "chr", 1, "row", 2, 1, edtCantPacConf_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A70CantPacConf), "Z9"), "", 0, edtCantPacConf_Jsonclick, "", 0, 1, -1, true, "right", "HLP_GestionConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_33_095e( true) ;
         }
         else
         {
            wb_table4_33_095e( false) ;
         }
      }

      protected void wb_table2_5_095( bool wbgen )
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
            GxWebStd.gx_bitmap( context, imgBtn_first_Internalname, "", context.GetImagePath( "b9e06284-17ac-4c88-8937-5dbd84ad5d80", "", "GeneXusX"), "GeneXusX", imgBtn_first_Visible, 1, "", "Primero", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_first_Jsonclick, "EFIRST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_GestionConsulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_first_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_first_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_first_separator_Jsonclick, "EFIRST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_GestionConsulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_previous_Internalname, "", context.GetImagePath( "7d212604-db7b-4785-9c0d-5faffe71aa33", "", "GeneXusX"), "GeneXusX", imgBtn_previous_Visible, 1, "", "Anterior", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_previous_Jsonclick, "EPREVIOUS.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_GestionConsulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_previous_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_previous_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_previous_separator_Jsonclick, "EPREVIOUS.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_GestionConsulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_next_Internalname, "", context.GetImagePath( "1ae947cf-1354-41a9-8d59-d91daebf554f", "", "GeneXusX"), "GeneXusX", imgBtn_next_Visible, 1, "", "Siguiente", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_next_Jsonclick, "ENEXT.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_GestionConsulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_next_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_next_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_next_separator_Jsonclick, "ENEXT.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_GestionConsulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_last_Internalname, "", context.GetImagePath( "29211874-e613-48e5-9011-8017d984217e", "", "GeneXusX"), "GeneXusX", imgBtn_last_Visible, 1, "", "Ultimo", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_last_Jsonclick, "ELAST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_GestionConsulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_last_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_last_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_last_separator_Jsonclick, "ELAST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_GestionConsulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_select_Internalname, "", context.GetImagePath( "1ca03f75-9947-4d2c-90a4-e8ab9c5cedea", "", "GeneXusX"), "GeneXusX", imgBtn_select_Visible, 1, "", "Seleccionar", 0, 0, 0, "", 0, "", 0, 0, "", "", 4, imgBtn_select_Jsonclick, "ESELECT.", StyleString, ClassString, "", ""+TempTags, "", "gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CONSULTAFECHA"+"'), id:'"+"CONSULTAFECHA"+"'"+",isOut:true,isKey:false,isLastKey:false}"+","+"{Ctrl:gx.dom.el('"+"MEDICOID"+"'), id:'"+"MEDICOID"+"'"+",isOut:true,isKey:false,isLastKey:false}"+","+"{Ctrl:gx.dom.el('"+"TURNOID"+"'), id:'"+"TURNOID"+"'"+",isOut:true,isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", "HLP_GestionConsulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_select_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_select_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 4, imgBtn_select_separator_Jsonclick, "ESELECT.", StyleString, ClassString, "", ""+TempTags, "", "gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CONSULTAFECHA"+"'), id:'"+"CONSULTAFECHA"+"'"+",isOut:true,isKey:false,isLastKey:false}"+","+"{Ctrl:gx.dom.el('"+"MEDICOID"+"'), id:'"+"MEDICOID"+"'"+",isOut:true,isKey:false,isLastKey:false}"+","+"{Ctrl:gx.dom.el('"+"TURNOID"+"'), id:'"+"TURNOID"+"'"+",isOut:true,isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", "HLP_GestionConsulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_enter2_Internalname, "", context.GetImagePath( "2061cf2c-bd33-4433-a13e-34af954142e9", "", "GeneXusX"), "GeneXusX", imgBtn_enter2_Visible, imgBtn_enter2_Enabled, "", "Confirmar", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_enter2_Jsonclick, "EENTER.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_GestionConsulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_enter2_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_enter2_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_enter2_separator_Jsonclick, "EENTER.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_GestionConsulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_cancel2_Internalname, "", context.GetImagePath( "0e94ced8-bc34-47ff-9a53-bc683736a686", "", "GeneXusX"), "GeneXusX", imgBtn_cancel2_Visible, 1, "", "Cancelar", 0, 0, 0, "", 0, "", 0, 0, "", "", 1, imgBtn_cancel2_Jsonclick, "ECANCEL.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_GestionConsulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_cancel2_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_cancel2_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 1, imgBtn_cancel2_separator_Jsonclick, "ECANCEL.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_GestionConsulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_delete2_Internalname, "", context.GetImagePath( "7695fe89-52c9-4b7e-871e-0e11548f823e", "", "GeneXusX"), "GeneXusX", imgBtn_delete2_Visible, imgBtn_delete2_Enabled, "", "Eliminar", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_delete2_Jsonclick, "EDELETE.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_GestionConsulta.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_delete2_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_delete2_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_delete2_separator_Jsonclick, "EDELETE.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_GestionConsulta.htm");
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
            wb_table2_5_095e( true) ;
         }
         else
         {
            wb_table2_5_095e( false) ;
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
         /* Execute user event: E11092 */
         E11092 ();
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
               A66CantNrosAsig = (short)(context.localUtil.CToN( cgiGet( edtCantNrosAsig_Internalname), ",", ".")) ;
               n66CantNrosAsig = false ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
               A65NrosDisponibles = (short)(context.localUtil.CToN( cgiGet( edtNrosDisponibles_Internalname), ",", ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A65NrosDisponibles", StringUtil.LTrim( StringUtil.Str( (decimal)(A65NrosDisponibles), 2, 0)));
               A67UltimoNroAsig = (short)(context.localUtil.CToN( cgiGet( edtUltimoNroAsig_Internalname), ",", ".")) ;
               n67UltimoNroAsig = false ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
               A70CantPacConf = (short)(context.localUtil.CToN( cgiGet( edtCantPacConf_Internalname), ",", ".")) ;
               n70CantPacConf = false ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A70CantPacConf", StringUtil.LTrim( StringUtil.Str( (decimal)(A70CantPacConf), 2, 0)));
               /* Read saved values. */
               Z43ConsultaFecha = context.localUtil.CToD( cgiGet( "Z43ConsultaFecha"), 0) ;
               Z12MedicoId = (int)(context.localUtil.CToN( cgiGet( "Z12MedicoId"), ",", ".")) ;
               Z60TurnoId = (short)(context.localUtil.CToN( cgiGet( "Z60TurnoId"), ",", ".")) ;
               Z67UltimoNroAsig = (short)(context.localUtil.CToN( cgiGet( "Z67UltimoNroAsig"), ",", ".")) ;
               Z57ConsultorioId = (short)(context.localUtil.CToN( cgiGet( "Z57ConsultorioId"), ",", ".")) ;
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", ".")) ;
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", ".")) ;
               Gx_mode = cgiGet( "Mode") ;
               N57ConsultorioId = (short)(context.localUtil.CToN( cgiGet( "N57ConsultorioId"), ",", ".")) ;
               A11EspecialidadMaxPacientes = (short)(context.localUtil.CToN( cgiGet( "ESPECIALIDADMAXPACIENTES"), ",", ".")) ;
               AV21ConsultaFecha = context.localUtil.CToD( cgiGet( "_CONSULTAFECHA"), 0) ;
               AV22MedicoId = (int)(context.localUtil.CToN( cgiGet( "_MEDICOID"), ",", ".")) ;
               AV23TurnoId = (short)(context.localUtil.CToN( cgiGet( "_TURNOID"), ",", ".")) ;
               AV19Insert_ConsultorioId = (short)(context.localUtil.CToN( cgiGet( "_INSERT_CONSULTORIOID"), ",", ".")) ;
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "_GXBSCREEN"), ",", ".")) ;
               A9EspecialidadId = (int)(context.localUtil.CToN( cgiGet( "ESPECIALIDADID"), ",", ".")) ;
               A61TurnoNombre = cgiGet( "TURNONOMBRE") ;
               AV24Pgmname = cgiGet( "_PGMNAME") ;
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
                  Gx_mode = "DSP" ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
                  {
                     sMode5 = Gx_mode ;
                     Gx_mode = "UPD" ;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode5 ;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound5 == 1 )
                     {
                        if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
                        {
                           /* Confirm record */
                           CONFIRM_090( ) ;
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
                           /* Execute user event: E11092 */
                           E11092 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1 ;
                           dynload_actions( ) ;
                           /* Execute user event: E12092 */
                           E12092 ();
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
            /* Execute user event: E12092 */
            E12092 ();
            trnEnded = 0 ;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  )
            {
               /* Clear variables for new insertion. */
               InitAll095( ) ;
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
            edtCantNrosAsig_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtCantNrosAsig_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtCantNrosAsig_Enabled), 5, 0)));
            edtNrosDisponibles_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtNrosDisponibles_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtNrosDisponibles_Enabled), 5, 0)));
            edtUltimoNroAsig_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtUltimoNroAsig_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtUltimoNroAsig_Enabled), 5, 0)));
            edtCantPacConf_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtCantPacConf_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtCantPacConf_Enabled), 5, 0)));
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

      protected void CONFIRM_090( )
      {
         BeforeValidate095( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               OnDeleteControls095( ) ;
            }
            else
            {
               CheckExtendedTable095( ) ;
               CloseExtendedTableCursors095( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1 ;
         }
      }

      protected void ResetCaption090( )
      {
      }

      protected void E11092( )
      {
         /* Start Routine */
         new isauthorized(context ).execute(  AV24Pgmname, out  AV16IsAuthorized) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV24Pgmname", AV24Pgmname);
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV16IsAuthorized", StringUtil.BoolToStr( AV16IsAuthorized));
         if ( ! AV16IsAuthorized )
         {
            context.wjLoc = formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV24Pgmname)) ;
         }
         AV17TrnContext.FromXml(AV18WebSession.Get("TrnContext"), "");
         AV19Insert_ConsultorioId = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV19Insert_ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV19Insert_ConsultorioId), 3, 0)));
         if ( ( StringUtil.StrCmp(AV17TrnContext.gxTpr_Transactionname, AV24Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV25GXV1 = 1 ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV25GXV1", StringUtil.LTrim( StringUtil.Str( (decimal)(AV25GXV1), 8, 0)));
            while ( AV25GXV1 <= AV17TrnContext.gxTpr_Attributes.Count )
            {
               AV20TrnContextAtt = ((SdtTransactionContext_Attribute)AV17TrnContext.gxTpr_Attributes.Item(AV25GXV1)) ;
               if ( StringUtil.StrCmp(AV20TrnContextAtt.gxTpr_Attributename, "ConsultorioId") == 0 )
               {
                  AV19Insert_ConsultorioId = (short)(NumberUtil.Val( AV20TrnContextAtt.gxTpr_Attributevalue, ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV19Insert_ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV19Insert_ConsultorioId), 3, 0)));
               }
               AV25GXV1 = (int)(AV25GXV1+1) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV25GXV1", StringUtil.LTrim( StringUtil.Str( (decimal)(AV25GXV1), 8, 0)));
            }
         }
      }

      protected void E12092( )
      {
         /* After Trn Routine */
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV17TrnContext.gxTpr_Callerondelete )
         {
            context.wjLoc = formatLink("wwgestionconsulta.aspx")  ;
         }
         context.setWebReturnParms(new Object[] {});
         context.nUserReturn = 1 ;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM095( short GX_JID )
      {
         if ( ( GX_JID == 22 ) || ( GX_JID == 0 ) )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               Z67UltimoNroAsig = T00093_A67UltimoNroAsig[0] ;
               Z57ConsultorioId = T00093_A57ConsultorioId[0] ;
            }
            else
            {
               Z67UltimoNroAsig = A67UltimoNroAsig ;
               Z57ConsultorioId = A57ConsultorioId ;
            }
         }
         if ( GX_JID == -22 )
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
            Z70CantPacConf = A70CantPacConf ;
         }
      }

      protected void standaloneNotModal( )
      {
         GXATURNOID_html095( ) ;
         edtCantNrosAsig_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtCantNrosAsig_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtCantNrosAsig_Enabled), 5, 0)));
         edtCantPacConf_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtCantPacConf_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtCantPacConf_Enabled), 5, 0)));
         edtUltimoNroAsig_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtUltimoNroAsig_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtUltimoNroAsig_Enabled), 5, 0)));
         Gx_BScreen = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_12_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"MEDICOID"+"'), id:'"+"MEDICOID"+"'"+",isOut:true,isKey:false,isLastKey:false}"+"],"+"null"+","+"'', false"+","+"true"+");") ;
         imgprompt_57_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0060.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CONSULTORIOID"+"'), id:'"+"CONSULTORIOID"+"'"+",isOut:true,isKey:false,isLastKey:false}"+"],"+"null"+","+"'', false"+","+"false"+");") ;
         edtCantNrosAsig_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtCantNrosAsig_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtCantNrosAsig_Enabled), 5, 0)));
         edtCantPacConf_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtCantPacConf_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtCantPacConf_Enabled), 5, 0)));
         edtUltimoNroAsig_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtUltimoNroAsig_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtUltimoNroAsig_Enabled), 5, 0)));
         imgBtn_delete2_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_delete2_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_delete2_Enabled), 5, 0)));
         if ( ! (DateTime.MinValue==AV21ConsultaFecha) )
         {
            A43ConsultaFecha = AV21ConsultaFecha ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         }
         if ( ! (DateTime.MinValue==AV21ConsultaFecha) )
         {
            edtConsultaFecha_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtConsultaFecha_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtConsultaFecha_Enabled), 5, 0)));
         }
         else
         {
            edtConsultaFecha_Enabled = 1 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtConsultaFecha_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtConsultaFecha_Enabled), 5, 0)));
         }
         if ( ! (DateTime.MinValue==AV21ConsultaFecha) )
         {
            edtConsultaFecha_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtConsultaFecha_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtConsultaFecha_Enabled), 5, 0)));
         }
         if ( ! (0==AV22MedicoId) )
         {
            A12MedicoId = AV22MedicoId ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
         }
         if ( ! (0==AV22MedicoId) )
         {
            edtMedicoId_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtMedicoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtMedicoId_Enabled), 5, 0)));
         }
         else
         {
            edtMedicoId_Enabled = 1 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtMedicoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtMedicoId_Enabled), 5, 0)));
         }
         if ( ! (0==AV22MedicoId) )
         {
            edtMedicoId_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtMedicoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtMedicoId_Enabled), 5, 0)));
         }
         if ( ! (0==AV23TurnoId) )
         {
            A60TurnoId = AV23TurnoId ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
         }
         if ( ! (0==AV23TurnoId) )
         {
            dynTurnoId.Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, dynTurnoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(dynTurnoId.Enabled), 5, 0)));
         }
         else
         {
            dynTurnoId.Enabled = 1 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, dynTurnoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(dynTurnoId.Enabled), 5, 0)));
         }
         if ( ! (0==AV23TurnoId) )
         {
            dynTurnoId.Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, dynTurnoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(dynTurnoId.Enabled), 5, 0)));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV19Insert_ConsultorioId) )
         {
            edtConsultorioId_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtConsultorioId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtConsultorioId_Enabled), 5, 0)));
         }
         else
         {
            edtConsultorioId_Enabled = 1 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtConsultorioId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtConsultorioId_Enabled), 5, 0)));
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV19Insert_ConsultorioId) )
         {
            A57ConsultorioId = AV19Insert_ConsultorioId ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A57ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A57ConsultorioId), 3, 0)));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  && (0==A67UltimoNroAsig) && ( Gx_BScreen == 0 ) )
         {
            A67UltimoNroAsig = 0 ;
            n67UltimoNroAsig = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00096 */
            pr_default.execute(4, new Object[] {A60TurnoId});
            A61TurnoNombre = T00096_A61TurnoNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
            pr_default.close(4);
            AV24Pgmname = "GestionConsulta" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV24Pgmname", AV24Pgmname);
            /* Using cursor T00094 */
            pr_default.execute(2, new Object[] {A12MedicoId});
            A9EspecialidadId = T00094_A9EspecialidadId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
            A13MedicoNombre = T00094_A13MedicoNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
            A14MedicoApellido = T00094_A14MedicoApellido[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
            pr_default.close(2);
            /* Using cursor T00095 */
            pr_default.execute(3, new Object[] {A9EspecialidadId});
            A11EspecialidadMaxPacientes = T00095_A11EspecialidadMaxPacientes[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
            pr_default.close(3);
            /* Using cursor T00099 */
            pr_default.execute(6, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
            if ( (pr_default.getStatus(6) != 101) )
            {
               A66CantNrosAsig = T00099_A66CantNrosAsig[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
               n66CantNrosAsig = T00099_n66CantNrosAsig[0] ;
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
            /* Using cursor T000911 */
            pr_default.execute(7, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               A70CantPacConf = T000911_A70CantPacConf[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A70CantPacConf", StringUtil.LTrim( StringUtil.Str( (decimal)(A70CantPacConf), 2, 0)));
               n70CantPacConf = T000911_n70CantPacConf[0] ;
            }
            else
            {
               A70CantPacConf = 0 ;
               n70CantPacConf = false ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A70CantPacConf", StringUtil.LTrim( StringUtil.Str( (decimal)(A70CantPacConf), 2, 0)));
            }
            pr_default.close(7);
         }
      }

      protected void Load095( )
      {
         /* Using cursor T000914 */
         pr_default.execute(8, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound5 = 1 ;
            A9EspecialidadId = T000914_A9EspecialidadId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
            A13MedicoNombre = T000914_A13MedicoNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
            A14MedicoApellido = T000914_A14MedicoApellido[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
            A61TurnoNombre = T000914_A61TurnoNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
            A67UltimoNroAsig = T000914_A67UltimoNroAsig[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
            n67UltimoNroAsig = T000914_n67UltimoNroAsig[0] ;
            A11EspecialidadMaxPacientes = T000914_A11EspecialidadMaxPacientes[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
            A57ConsultorioId = T000914_A57ConsultorioId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A57ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A57ConsultorioId), 3, 0)));
            A66CantNrosAsig = T000914_A66CantNrosAsig[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
            n66CantNrosAsig = T000914_n66CantNrosAsig[0] ;
            A70CantPacConf = T000914_A70CantPacConf[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A70CantPacConf", StringUtil.LTrim( StringUtil.Str( (decimal)(A70CantPacConf), 2, 0)));
            n70CantPacConf = T000914_n70CantPacConf[0] ;
            ZM095( -22) ;
         }
         pr_default.close(8);
         OnLoadActions095( ) ;
      }

      protected void OnLoadActions095( )
      {
         AV24Pgmname = "GestionConsulta" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV24Pgmname", AV24Pgmname);
         /* Using cursor T00099 */
         pr_default.execute(6, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A66CantNrosAsig = T00099_A66CantNrosAsig[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
            n66CantNrosAsig = T00099_n66CantNrosAsig[0] ;
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
         /* Using cursor T000911 */
         pr_default.execute(7, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A70CantPacConf = T000911_A70CantPacConf[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A70CantPacConf", StringUtil.LTrim( StringUtil.Str( (decimal)(A70CantPacConf), 2, 0)));
            n70CantPacConf = T000911_n70CantPacConf[0] ;
         }
         else
         {
            A70CantPacConf = 0 ;
            n70CantPacConf = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A70CantPacConf", StringUtil.LTrim( StringUtil.Str( (decimal)(A70CantPacConf), 2, 0)));
         }
         pr_default.close(7);
      }

      protected void CheckExtendedTable095( )
      {
         Gx_BScreen = 1 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV24Pgmname = "GestionConsulta" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV24Pgmname", AV24Pgmname);
         if ( ! ( (DateTime.MinValue==A43ConsultaFecha) || ( A43ConsultaFecha >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Consulta Fecha fuera de rango", "OutOfRange", 1, "");
            AnyError = 1 ;
         }
         /* Using cursor T00094 */
         pr_default.execute(2, new Object[] {A12MedicoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Médico'.", "ForeignKeyNotFound", 1, "MEDICOID");
            AnyError = 1 ;
            GX_FocusControl = edtMedicoId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A9EspecialidadId = T00094_A9EspecialidadId[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
         A13MedicoNombre = T00094_A13MedicoNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
         A14MedicoApellido = T00094_A14MedicoApellido[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
         pr_default.close(2);
         /* Using cursor T00095 */
         pr_default.execute(3, new Object[] {A9EspecialidadId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Especialidad'.", "ForeignKeyNotFound", 1, "");
            AnyError = 1 ;
         }
         A11EspecialidadMaxPacientes = T00095_A11EspecialidadMaxPacientes[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
         pr_default.close(3);
         /* Using cursor T00096 */
         pr_default.execute(4, new Object[] {A60TurnoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Turno'.", "ForeignKeyNotFound", 1, "TURNOID");
            AnyError = 1 ;
            GX_FocusControl = dynTurnoId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A61TurnoNombre = T00096_A61TurnoNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
         pr_default.close(4);
         /* Using cursor T00099 */
         pr_default.execute(6, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A66CantNrosAsig = T00099_A66CantNrosAsig[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
            n66CantNrosAsig = T00099_n66CantNrosAsig[0] ;
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
         /* Using cursor T000911 */
         pr_default.execute(7, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A70CantPacConf = T000911_A70CantPacConf[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A70CantPacConf", StringUtil.LTrim( StringUtil.Str( (decimal)(A70CantPacConf), 2, 0)));
            n70CantPacConf = T000911_n70CantPacConf[0] ;
         }
         else
         {
            A70CantPacConf = 0 ;
            n70CantPacConf = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A70CantPacConf", StringUtil.LTrim( StringUtil.Str( (decimal)(A70CantPacConf), 2, 0)));
         }
         pr_default.close(7);
         /* Using cursor T00097 */
         pr_default.execute(5, new Object[] {A57ConsultorioId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Consultorio'.", "ForeignKeyNotFound", 1, "CONSULTORIOID");
            AnyError = 1 ;
            GX_FocusControl = edtConsultorioId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors095( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_23( int A12MedicoId )
      {
         /* Using cursor T000915 */
         pr_default.execute(9, new Object[] {A12MedicoId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Médico'.", "ForeignKeyNotFound", 1, "MEDICOID");
            AnyError = 1 ;
            GX_FocusControl = edtMedicoId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A9EspecialidadId = T000915_A9EspecialidadId[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
         A13MedicoNombre = T000915_A13MedicoNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
         A14MedicoApellido = T000915_A14MedicoApellido[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A9EspecialidadId), 6, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A13MedicoNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A14MedicoApellido))+"\"");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(9) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(9);
      }

      protected void gxLoad_24( int A9EspecialidadId )
      {
         /* Using cursor T000916 */
         pr_default.execute(10, new Object[] {A9EspecialidadId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Especialidad'.", "ForeignKeyNotFound", 1, "");
            AnyError = 1 ;
         }
         A11EspecialidadMaxPacientes = T000916_A11EspecialidadMaxPacientes[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A11EspecialidadMaxPacientes), 3, 0, ".", "")))+"\"");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(10) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(10);
      }

      protected void gxLoad_25( short A60TurnoId )
      {
         /* Using cursor T000917 */
         pr_default.execute(11, new Object[] {A60TurnoId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Turno'.", "ForeignKeyNotFound", 1, "TURNOID");
            AnyError = 1 ;
            GX_FocusControl = dynTurnoId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A61TurnoNombre = T000917_A61TurnoNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A61TurnoNombre))+"\"");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(11) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(11);
      }

      protected void gxLoad_27( DateTime A43ConsultaFecha ,
                                int A12MedicoId ,
                                short A60TurnoId )
      {
         /* Using cursor T000919 */
         pr_default.execute(12, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            A66CantNrosAsig = T000919_A66CantNrosAsig[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
            n66CantNrosAsig = T000919_n66CantNrosAsig[0] ;
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
         if ( (pr_default.getStatus(12) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(12);
      }

      protected void gxLoad_28( DateTime A43ConsultaFecha ,
                                int A12MedicoId ,
                                short A60TurnoId )
      {
         /* Using cursor T000921 */
         pr_default.execute(13, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            A70CantPacConf = T000921_A70CantPacConf[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A70CantPacConf", StringUtil.LTrim( StringUtil.Str( (decimal)(A70CantPacConf), 2, 0)));
            n70CantPacConf = T000921_n70CantPacConf[0] ;
         }
         else
         {
            A70CantPacConf = 0 ;
            n70CantPacConf = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A70CantPacConf", StringUtil.LTrim( StringUtil.Str( (decimal)(A70CantPacConf), 2, 0)));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A70CantPacConf), 2, 0, ".", "")))+"\"");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(13) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(13);
      }

      protected void gxLoad_26( short A57ConsultorioId )
      {
         /* Using cursor T000922 */
         pr_default.execute(14, new Object[] {A57ConsultorioId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Consultorio'.", "ForeignKeyNotFound", 1, "CONSULTORIOID");
            AnyError = 1 ;
            GX_FocusControl = edtConsultorioId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(14) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(14);
      }

      protected void GetKey095( )
      {
         /* Using cursor T000923 */
         pr_default.execute(15, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound5 = 1 ;
         }
         else
         {
            RcdFound5 = 0 ;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00093 */
         pr_default.execute(1, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM095( 22) ;
            RcdFound5 = 1 ;
            A43ConsultaFecha = T00093_A43ConsultaFecha[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            A67UltimoNroAsig = T00093_A67UltimoNroAsig[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
            n67UltimoNroAsig = T00093_n67UltimoNroAsig[0] ;
            A12MedicoId = T00093_A12MedicoId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            A60TurnoId = T00093_A60TurnoId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
            A57ConsultorioId = T00093_A57ConsultorioId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A57ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A57ConsultorioId), 3, 0)));
            Z43ConsultaFecha = A43ConsultaFecha ;
            Z12MedicoId = A12MedicoId ;
            Z60TurnoId = A60TurnoId ;
            sMode5 = Gx_mode ;
            Gx_mode = "DSP" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
            Load095( ) ;
            Gx_mode = sMode5 ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0 ;
            InitializeNonKey095( ) ;
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
         GetKey095( ) ;
         if ( RcdFound5 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound5 = 0 ;
         /* Using cursor T000924 */
         pr_default.execute(16, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            while ( (pr_default.getStatus(16) != 101) && ( ( T000924_A43ConsultaFecha[0] < A43ConsultaFecha ) || ( T000924_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000924_A12MedicoId[0] < A12MedicoId ) || ( T000924_A12MedicoId[0] == A12MedicoId ) && ( T000924_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000924_A60TurnoId[0] < A60TurnoId ) ) )
            {
               pr_default.readNext(16);
            }
            if ( (pr_default.getStatus(16) != 101) && ( ( T000924_A43ConsultaFecha[0] > A43ConsultaFecha ) || ( T000924_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000924_A12MedicoId[0] > A12MedicoId ) || ( T000924_A12MedicoId[0] == A12MedicoId ) && ( T000924_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000924_A60TurnoId[0] > A60TurnoId ) ) )
            {
               A43ConsultaFecha = T000924_A43ConsultaFecha[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
               A12MedicoId = T000924_A12MedicoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
               A60TurnoId = T000924_A60TurnoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
               RcdFound5 = 1 ;
            }
         }
         pr_default.close(1);
      }

      protected void move_previous( )
      {
         RcdFound5 = 0 ;
         /* Using cursor T000925 */
         pr_default.execute(17, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            while ( (pr_default.getStatus(17) != 101) && ( ( T000925_A43ConsultaFecha[0] > A43ConsultaFecha ) || ( T000925_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000925_A12MedicoId[0] > A12MedicoId ) || ( T000925_A12MedicoId[0] == A12MedicoId ) && ( T000925_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000925_A60TurnoId[0] > A60TurnoId ) ) )
            {
               pr_default.readNext(17);
            }
            if ( (pr_default.getStatus(17) != 101) && ( ( T000925_A43ConsultaFecha[0] < A43ConsultaFecha ) || ( T000925_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000925_A12MedicoId[0] < A12MedicoId ) || ( T000925_A12MedicoId[0] == A12MedicoId ) && ( T000925_A43ConsultaFecha[0] == A43ConsultaFecha ) && ( T000925_A60TurnoId[0] < A60TurnoId ) ) )
            {
               A43ConsultaFecha = T000925_A43ConsultaFecha[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
               A12MedicoId = T000925_A12MedicoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
               A60TurnoId = T000925_A60TurnoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
               RcdFound5 = 1 ;
            }
         }
         pr_default.close(0);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1 ;
         GetKey095( ) ;
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
               /* Update record */
               Update095( ) ;
               GX_FocusControl = edtConsultaFecha_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( ( A43ConsultaFecha != Z43ConsultaFecha ) || ( A12MedicoId != Z12MedicoId ) || ( A60TurnoId != Z60TurnoId ) )
            {
               /* Insert record */
               Insert095( ) ;
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
                  Insert095( ) ;
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
         }
      }

      protected void CheckOptimisticConcurrency095( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            /* Using cursor T000926 */
            pr_default.execute(18, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
            if ( (pr_default.getStatus(18) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Consulta"}), "RecordIsLocked", 1, "");
               AnyError = 1 ;
               return  ;
            }
            if ( (pr_default.getStatus(18) == 101) || ( Z67UltimoNroAsig != T000926_A67UltimoNroAsig[0] ) || ( Z57ConsultorioId != T000926_A57ConsultorioId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Consulta"}), "RecordWasChanged", 1, "");
               AnyError = 1 ;
               return  ;
            }
         }
      }

      protected void Insert095( )
      {
         BeforeValidate095( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable095( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM095( 0) ;
            CheckOptimisticConcurrency095( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm095( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert095( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000927 */
                     pr_default.execute(19, new Object[] {A43ConsultaFecha, n67UltimoNroAsig, A67UltimoNroAsig, A12MedicoId, A60TurnoId, A57ConsultorioId});
                     pr_default.close(19);
                     if ( (pr_default.getStatus(19) == 1) )
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
                           ResetCaption090( ) ;
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
               Load095( ) ;
            }
            EndLevel095( ) ;
         }
         CloseExtendedTableCursors095( ) ;
      }

      protected void Update095( )
      {
         BeforeValidate095( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable095( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency095( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm095( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate095( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000928 */
                     pr_default.execute(20, new Object[] {n67UltimoNroAsig, A67UltimoNroAsig, A57ConsultorioId, A43ConsultaFecha, A12MedicoId, A60TurnoId});
                     pr_default.close(20);
                     if ( (pr_default.getStatus(20) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Consulta"}), "RecordIsLocked", 1, "");
                        AnyError = 1 ;
                     }
                     DeferredUpdate095( ) ;
                     if ( AnyError == 0 )
                     {
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
            EndLevel095( ) ;
         }
         CloseExtendedTableCursors095( ) ;
      }

      protected void DeferredUpdate095( )
      {
      }

      protected void delete( )
      {
         BeforeValidate095( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency095( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls095( ) ;
            AfterConfirm095( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete095( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000929 */
                  pr_default.execute(21, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
                  pr_default.close(21);
                  if ( AnyError == 0 )
                  {
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
         sMode5 = Gx_mode ;
         Gx_mode = "DLT" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         EndLevel095( ) ;
         Gx_mode = sMode5 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls095( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV24Pgmname = "GestionConsulta" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV24Pgmname", AV24Pgmname);
            /* Using cursor T000930 */
            pr_default.execute(22, new Object[] {A12MedicoId});
            A9EspecialidadId = T000930_A9EspecialidadId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
            A13MedicoNombre = T000930_A13MedicoNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
            A14MedicoApellido = T000930_A14MedicoApellido[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
            pr_default.close(22);
            /* Using cursor T000931 */
            pr_default.execute(23, new Object[] {A9EspecialidadId});
            A11EspecialidadMaxPacientes = T000931_A11EspecialidadMaxPacientes[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
            pr_default.close(23);
            /* Using cursor T000932 */
            pr_default.execute(24, new Object[] {A60TurnoId});
            A61TurnoNombre = T000932_A61TurnoNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
            pr_default.close(24);
            /* Using cursor T000934 */
            pr_default.execute(25, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               A66CantNrosAsig = T000934_A66CantNrosAsig[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
               n66CantNrosAsig = T000934_n66CantNrosAsig[0] ;
            }
            else
            {
               A66CantNrosAsig = 0 ;
               n66CantNrosAsig = false ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
            }
            pr_default.close(25);
            A65NrosDisponibles = (short)(A11EspecialidadMaxPacientes-A66CantNrosAsig) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A65NrosDisponibles", StringUtil.LTrim( StringUtil.Str( (decimal)(A65NrosDisponibles), 2, 0)));
            /* Using cursor T000936 */
            pr_default.execute(26, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
            if ( (pr_default.getStatus(26) != 101) )
            {
               A70CantPacConf = T000936_A70CantPacConf[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A70CantPacConf", StringUtil.LTrim( StringUtil.Str( (decimal)(A70CantPacConf), 2, 0)));
               n70CantPacConf = T000936_n70CantPacConf[0] ;
            }
            else
            {
               A70CantPacConf = 0 ;
               n70CantPacConf = false ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A70CantPacConf", StringUtil.LTrim( StringUtil.Str( (decimal)(A70CantPacConf), 2, 0)));
            }
            pr_default.close(26);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000937 */
            pr_default.execute(27, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Consulta Paciente"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1 ;
            }
            pr_default.close(27);
         }
      }

      protected void EndLevel095( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            pr_default.close(18);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete095( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(17);
            pr_default.close(16);
            pr_default.close(22);
            pr_default.close(23);
            pr_default.close(24);
            pr_default.close(25);
            pr_default.close(26);
            context.CommitDataStores("GestionConsulta");
            if ( AnyError == 0 )
            {
               ConfirmValues090( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1 ;
         }
         else
         {
            pr_default.close(17);
            pr_default.close(16);
            pr_default.close(22);
            pr_default.close(23);
            pr_default.close(24);
            pr_default.close(25);
            pr_default.close(26);
            context.RollbackDataStores("GestionConsulta");
         }
         IsModified = 0 ;
         if ( AnyError != 0 )
         {
            context.wjLoc = "" ;
            context.nUserReturn = 0 ;
         }
      }

      protected void ScanStart095( )
      {
         /* Using cursor T000938 */
         pr_default.execute(28);
         RcdFound5 = 0 ;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound5 = 1 ;
            A43ConsultaFecha = T000938_A43ConsultaFecha[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            A12MedicoId = T000938_A12MedicoId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            A60TurnoId = T000938_A60TurnoId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext095( )
      {
         pr_default.readNext(28);
         RcdFound5 = 0 ;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound5 = 1 ;
            A43ConsultaFecha = T000938_A43ConsultaFecha[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            A12MedicoId = T000938_A12MedicoId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            A60TurnoId = T000938_A60TurnoId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
         }
      }

      protected void ScanEnd095( )
      {
      }

      protected void AfterConfirm095( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert095( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate095( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete095( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete095( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate095( )
      {
         /* Before Validate Rules */
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues090( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" onsubmit=\"try{return gx.csv.validForm()}catch(e){return true;}\" name=\"MAINFORM\" method=\"post\" action=\""+formatLink("gestionconsulta.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV21ConsultaFecha)) + "," + UrlEncode("" +AV22MedicoId) + "," + UrlEncode("" +AV23TurnoId)+"\" class=\""+"Form"+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "N57ConsultorioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A57ConsultorioId), 3, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ESPECIALIDADMAXPACIENTES", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11EspecialidadMaxPacientes), 3, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "_CONSULTAFECHA", context.localUtil.DToC( AV21ConsultaFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "_MEDICOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22MedicoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "_TURNOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23TurnoId), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "_INSERT_CONSULTORIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19Insert_ConsultorioId), 3, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "_GXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ESPECIALIDADID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9EspecialidadId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "TURNONOMBRE", StringUtil.RTrim( A61TurnoNombre));
         GxWebStd.gx_hidden_field( context, "_PGMNAME", StringUtil.RTrim( AV24Pgmname));
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
         return "GestionConsulta" ;
      }

      public override String GetPgmdesc( )
      {
         return "Gestion Consulta" ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("gestionconsulta.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV21ConsultaFecha)) + "," + UrlEncode("" +AV22MedicoId) + "," + UrlEncode("" +AV23TurnoId) ;
      }

      protected void InitializeNonKey095( )
      {
         A9EspecialidadId = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
         A57ConsultorioId = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A57ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A57ConsultorioId), 3, 0)));
         A65NrosDisponibles = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A65NrosDisponibles", StringUtil.LTrim( StringUtil.Str( (decimal)(A65NrosDisponibles), 2, 0)));
         A13MedicoNombre = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
         A14MedicoApellido = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
         A61TurnoNombre = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
         A66CantNrosAsig = 0 ;
         n66CantNrosAsig = false ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
         A70CantPacConf = 0 ;
         n70CantPacConf = false ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A70CantPacConf", StringUtil.LTrim( StringUtil.Str( (decimal)(A70CantPacConf), 2, 0)));
         A11EspecialidadMaxPacientes = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
         A67UltimoNroAsig = 0 ;
         n67UltimoNroAsig = false ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
      }

      protected void InitAll095( )
      {
         A43ConsultaFecha = DateTime.MinValue ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         A12MedicoId = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
         A60TurnoId = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
         InitializeNonKey095( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( Form.Jscriptsrc.Item(idxLst)), "?552256");
            idxLst = (int)(idxLst+1) ;
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?34981");
         context.AddJavascriptSource("gestionconsulta.js", "?552258");
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
         lblTextblockcantnrosasig_Internalname = "TEXTBLOCKCANTNROSASIG" ;
         edtCantNrosAsig_Internalname = "CANTNROSASIG" ;
         lblTextblocknrosdisponibles_Internalname = "TEXTBLOCKNROSDISPONIBLES" ;
         edtNrosDisponibles_Internalname = "NROSDISPONIBLES" ;
         lblTextblockultimonroasig_Internalname = "TEXTBLOCKULTIMONROASIG" ;
         edtUltimoNroAsig_Internalname = "ULTIMONROASIG" ;
         lblTextblockcantpacconf_Internalname = "TEXTBLOCKCANTPACCONF" ;
         edtCantPacConf_Internalname = "CANTPACCONF" ;
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
         Form.Caption = "Gestion Consulta" ;
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
         edtCantPacConf_Jsonclick = "" ;
         edtCantPacConf_Enabled = 0 ;
         edtUltimoNroAsig_Jsonclick = "" ;
         edtUltimoNroAsig_Enabled = 0 ;
         edtNrosDisponibles_Jsonclick = "" ;
         edtNrosDisponibles_Enabled = 0 ;
         edtCantNrosAsig_Jsonclick = "" ;
         edtCantNrosAsig_Enabled = 0 ;
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

      protected void GXDLATURNOID095( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "max-age=0");
         }
         context.GX_webresponse.AddString("(new Array( new Array(");
         GXDLATURNOID_data095( ) ;
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

      protected void GXATURNOID_html095( )
      {
         short gxdynajaxvalue ;
         GXDLATURNOID_data095( ) ;
         gxdynajaxindex = 1 ;
         dynTurnoId.removeAllItems();
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( gxdynajaxctrlcodr.Item(gxdynajaxindex), ".")) ;
            dynTurnoId.addItem(StringUtil.Str( (decimal)(gxdynajaxvalue), 2, 0), gxdynajaxctrldescr.Item(gxdynajaxindex), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1) ;
         }
      }

      protected void GXDLATURNOID_data095( )
      {
         /* Using cursor T000939 */
         pr_default.execute(29);
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("Todos");
         while ( (pr_default.getStatus(29) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000939_A60TurnoId[0]), 2, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000939_A61TurnoNombre[0]));
            pr_default.readNext(29);
         }
         pr_default.close(29);
      }

      public void Valid_Medicoid( int GX_Parm1 ,
                                  int GX_Parm2 ,
                                  String GX_Parm3 ,
                                  String GX_Parm4 ,
                                  short GX_Parm5 )
      {
         A12MedicoId = GX_Parm1 ;
         A9EspecialidadId = GX_Parm2 ;
         A13MedicoNombre = GX_Parm3 ;
         A14MedicoApellido = GX_Parm4 ;
         A11EspecialidadMaxPacientes = GX_Parm5 ;
         /* Using cursor T000940 */
         pr_default.execute(30, new Object[] {A12MedicoId});
         if ( (pr_default.getStatus(30) == 101) )
         {
            GX_msglist.addItem("No existe 'Médico'.", "ForeignKeyNotFound", 1, "MEDICOID");
            AnyError = 1 ;
            GX_FocusControl = edtMedicoId_Internalname ;
         }
         A9EspecialidadId = T000940_A9EspecialidadId[0] ;
         A13MedicoNombre = T000940_A13MedicoNombre[0] ;
         A14MedicoApellido = T000940_A14MedicoApellido[0] ;
         pr_default.close(30);
         /* Using cursor T000941 */
         pr_default.execute(31, new Object[] {A9EspecialidadId});
         if ( (pr_default.getStatus(31) == 101) )
         {
            GX_msglist.addItem("No existe 'Especialidad'.", "ForeignKeyNotFound", 1, "");
            AnyError = 1 ;
         }
         A11EspecialidadMaxPacientes = T000941_A11EspecialidadMaxPacientes[0] ;
         pr_default.close(31);
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
         isValidOutput.Add((Object)(context.GX_msglist.ToJavascriptSource()));
         context.GX_webresponse.AddString(isValidOutput.ToJSonString());
      }

      public void Valid_Turnoid( GXCombobox dynGX_Parm1 ,
                                 DateTime GX_Parm2 ,
                                 int GX_Parm3 ,
                                 short GX_Parm4 ,
                                 short GX_Parm5 ,
                                 String GX_Parm6 ,
                                 short GX_Parm7 ,
                                 short GX_Parm8 )
      {
         dynTurnoId = dynGX_Parm1 ;
         A60TurnoId = (short)(NumberUtil.Val( dynTurnoId.CurrentValue, ".")) ;
         A43ConsultaFecha = GX_Parm2 ;
         A12MedicoId = GX_Parm3 ;
         A11EspecialidadMaxPacientes = GX_Parm4 ;
         A66CantNrosAsig = GX_Parm5 ;
         n66CantNrosAsig = false ;
         A61TurnoNombre = GX_Parm6 ;
         A65NrosDisponibles = GX_Parm7 ;
         A70CantPacConf = GX_Parm8 ;
         n70CantPacConf = false ;
         /* Using cursor T000942 */
         pr_default.execute(32, new Object[] {A60TurnoId});
         if ( (pr_default.getStatus(32) == 101) )
         {
            GX_msglist.addItem("No existe 'Turno'.", "ForeignKeyNotFound", 1, "TURNOID");
            AnyError = 1 ;
            GX_FocusControl = dynTurnoId_Internalname ;
         }
         A61TurnoNombre = T000942_A61TurnoNombre[0] ;
         pr_default.close(32);
         /* Using cursor T000944 */
         pr_default.execute(33, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(33) != 101) )
         {
            A66CantNrosAsig = T000944_A66CantNrosAsig[0] ;
            n66CantNrosAsig = T000944_n66CantNrosAsig[0] ;
         }
         else
         {
            A66CantNrosAsig = 0 ;
            n66CantNrosAsig = false ;
         }
         pr_default.close(33);
         A65NrosDisponibles = (short)(A11EspecialidadMaxPacientes-A66CantNrosAsig) ;
         /* Using cursor T000946 */
         pr_default.execute(34, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(34) != 101) )
         {
            A70CantPacConf = T000946_A70CantPacConf[0] ;
            n70CantPacConf = T000946_n70CantPacConf[0] ;
         }
         else
         {
            A70CantPacConf = 0 ;
            n70CantPacConf = false ;
         }
         pr_default.close(34);
         dynload_actions( ) ;
         if ( AnyError == 1 )
         {
            A61TurnoNombre = "" ;
            A66CantNrosAsig = 0 ;
            n66CantNrosAsig = false ;
            A70CantPacConf = 0 ;
            n70CantPacConf = false ;
         }
         isValidOutput.Add((Object)(StringUtil.RTrim( A61TurnoNombre)));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(A66CantNrosAsig), 2, 0, ".", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(A65NrosDisponibles), 2, 0, ".", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(A70CantPacConf), 2, 0, ".", ""))));
         isValidOutput.Add((Object)(context.GX_msglist.ToJavascriptSource()));
         context.GX_webresponse.AddString(isValidOutput.ToJSonString());
      }

      public void Valid_Consultorioid( short GX_Parm1 )
      {
         A57ConsultorioId = GX_Parm1 ;
         /* Using cursor T000947 */
         pr_default.execute(35, new Object[] {A57ConsultorioId});
         if ( (pr_default.getStatus(35) == 101) )
         {
            GX_msglist.addItem("No existe 'Consultorio'.", "ForeignKeyNotFound", 1, "CONSULTORIOID");
            AnyError = 1 ;
            GX_FocusControl = edtConsultorioId_Internalname ;
         }
         pr_default.close(35);
         dynload_actions( ) ;
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
         pr_default.close(28);
         pr_default.close(17);
         pr_default.close(16);
         pr_default.close(30);
         pr_default.close(22);
         pr_default.close(31);
         pr_default.close(23);
         pr_default.close(32);
         pr_default.close(24);
         pr_default.close(35);
         pr_default.close(33);
         pr_default.close(25);
         pr_default.close(34);
         pr_default.close(26);
      }

      public override void initialize( )
      {
         sPrefix = "" ;
         wcpOGx_mode = "" ;
         wcpOAV21ConsultaFecha = DateTime.MinValue ;
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
         lblTextblockcantnrosasig_Jsonclick = "" ;
         lblTextblocknrosdisponibles_Jsonclick = "" ;
         lblTextblockultimonroasig_Jsonclick = "" ;
         lblTextblockcantpacconf_Jsonclick = "" ;
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
         A61TurnoNombre = "" ;
         AV24Pgmname = "" ;
         sMode5 = "" ;
         sEvt = "" ;
         EvtGridId = "" ;
         EvtRowId = "" ;
         sEvtType = "" ;
         AV17TrnContext = new SdtTransactionContext(context);
         AV18WebSession = new GxWebSession( context);
         AV20TrnContextAtt = new SdtTransactionContext_Attribute(context);
         Z13MedicoNombre = "" ;
         Z14MedicoApellido = "" ;
         Z61TurnoNombre = "" ;
         T00096_A61TurnoNombre = new String[] {""} ;
         T00094_A9EspecialidadId = new int[1] ;
         T00094_A13MedicoNombre = new String[] {""} ;
         T00094_A14MedicoApellido = new String[] {""} ;
         T00095_A11EspecialidadMaxPacientes = new short[1] ;
         T00099_A66CantNrosAsig = new short[1] ;
         T00099_n66CantNrosAsig = new bool[] {false} ;
         T000911_A70CantPacConf = new short[1] ;
         T000911_n70CantPacConf = new bool[] {false} ;
         T000914_A9EspecialidadId = new int[1] ;
         T000914_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T000914_A13MedicoNombre = new String[] {""} ;
         T000914_A14MedicoApellido = new String[] {""} ;
         T000914_A61TurnoNombre = new String[] {""} ;
         T000914_A67UltimoNroAsig = new short[1] ;
         T000914_n67UltimoNroAsig = new bool[] {false} ;
         T000914_A11EspecialidadMaxPacientes = new short[1] ;
         T000914_A12MedicoId = new int[1] ;
         T000914_A60TurnoId = new short[1] ;
         T000914_A57ConsultorioId = new short[1] ;
         T000914_A66CantNrosAsig = new short[1] ;
         T000914_n66CantNrosAsig = new bool[] {false} ;
         T000914_A70CantPacConf = new short[1] ;
         T000914_n70CantPacConf = new bool[] {false} ;
         T00097_A57ConsultorioId = new short[1] ;
         T000915_A9EspecialidadId = new int[1] ;
         T000915_A13MedicoNombre = new String[] {""} ;
         T000915_A14MedicoApellido = new String[] {""} ;
         T000916_A11EspecialidadMaxPacientes = new short[1] ;
         T000917_A61TurnoNombre = new String[] {""} ;
         T000919_A66CantNrosAsig = new short[1] ;
         T000919_n66CantNrosAsig = new bool[] {false} ;
         T000921_A70CantPacConf = new short[1] ;
         T000921_n70CantPacConf = new bool[] {false} ;
         T000922_A57ConsultorioId = new short[1] ;
         T000923_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T000923_A12MedicoId = new int[1] ;
         T000923_A60TurnoId = new short[1] ;
         T00093_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T00093_A67UltimoNroAsig = new short[1] ;
         T00093_n67UltimoNroAsig = new bool[] {false} ;
         T00093_A12MedicoId = new int[1] ;
         T00093_A60TurnoId = new short[1] ;
         T00093_A57ConsultorioId = new short[1] ;
         T000924_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T000924_A12MedicoId = new int[1] ;
         T000924_A60TurnoId = new short[1] ;
         T000925_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T000925_A12MedicoId = new int[1] ;
         T000925_A60TurnoId = new short[1] ;
         T000926_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T000926_A67UltimoNroAsig = new short[1] ;
         T000926_n67UltimoNroAsig = new bool[] {false} ;
         T000926_A12MedicoId = new int[1] ;
         T000926_A60TurnoId = new short[1] ;
         T000926_A57ConsultorioId = new short[1] ;
         T000930_A9EspecialidadId = new int[1] ;
         T000930_A13MedicoNombre = new String[] {""} ;
         T000930_A14MedicoApellido = new String[] {""} ;
         T000931_A11EspecialidadMaxPacientes = new short[1] ;
         T000932_A61TurnoNombre = new String[] {""} ;
         T000934_A66CantNrosAsig = new short[1] ;
         T000934_n66CantNrosAsig = new bool[] {false} ;
         T000936_A70CantPacConf = new short[1] ;
         T000936_n70CantPacConf = new bool[] {false} ;
         T000937_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T000937_A34PacienteId = new int[1] ;
         T000937_A12MedicoId = new int[1] ;
         T000937_A60TurnoId = new short[1] ;
         T000938_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T000938_A12MedicoId = new int[1] ;
         T000938_A60TurnoId = new short[1] ;
         sDynURL = "" ;
         FormProcess = "" ;
         GXt_char2 = "" ;
         GXt_char1 = "" ;
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "" ;
         GXt_char3 = "" ;
         T000939_A60TurnoId = new short[1] ;
         T000939_A61TurnoNombre = new String[] {""} ;
         T000940_A9EspecialidadId = new int[1] ;
         T000940_A13MedicoNombre = new String[] {""} ;
         T000940_A14MedicoApellido = new String[] {""} ;
         T000941_A11EspecialidadMaxPacientes = new short[1] ;
         isValidOutput = new GxUnknownObjectCollection();
         T000942_A61TurnoNombre = new String[] {""} ;
         T000944_A66CantNrosAsig = new short[1] ;
         T000944_n66CantNrosAsig = new bool[] {false} ;
         T000946_A70CantPacConf = new short[1] ;
         T000946_n70CantPacConf = new bool[] {false} ;
         T000947_A57ConsultorioId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gestionconsulta__default(),
            new Object[][] {
                new Object[] {
               T00092_A43ConsultaFecha, T00092_A67UltimoNroAsig, T00092_n67UltimoNroAsig, T00092_A12MedicoId, T00092_A60TurnoId, T00092_A57ConsultorioId
               }
               , new Object[] {
               T00093_A43ConsultaFecha, T00093_A67UltimoNroAsig, T00093_n67UltimoNroAsig, T00093_A12MedicoId, T00093_A60TurnoId, T00093_A57ConsultorioId
               }
               , new Object[] {
               T00094_A9EspecialidadId, T00094_A13MedicoNombre, T00094_A14MedicoApellido
               }
               , new Object[] {
               T00095_A11EspecialidadMaxPacientes
               }
               , new Object[] {
               T00096_A61TurnoNombre
               }
               , new Object[] {
               T00097_A57ConsultorioId
               }
               , new Object[] {
               T00099_A66CantNrosAsig, T00099_n66CantNrosAsig
               }
               , new Object[] {
               T000911_A70CantPacConf, T000911_n70CantPacConf
               }
               , new Object[] {
               T000914_A9EspecialidadId, T000914_A43ConsultaFecha, T000914_A13MedicoNombre, T000914_A14MedicoApellido, T000914_A61TurnoNombre, T000914_A67UltimoNroAsig, T000914_n67UltimoNroAsig, T000914_A11EspecialidadMaxPacientes, T000914_A12MedicoId, T000914_A60TurnoId,
               T000914_A57ConsultorioId, T000914_A66CantNrosAsig, T000914_n66CantNrosAsig, T000914_A70CantPacConf, T000914_n70CantPacConf
               }
               , new Object[] {
               T000915_A9EspecialidadId, T000915_A13MedicoNombre, T000915_A14MedicoApellido
               }
               , new Object[] {
               T000916_A11EspecialidadMaxPacientes
               }
               , new Object[] {
               T000917_A61TurnoNombre
               }
               , new Object[] {
               T000919_A66CantNrosAsig, T000919_n66CantNrosAsig
               }
               , new Object[] {
               T000921_A70CantPacConf, T000921_n70CantPacConf
               }
               , new Object[] {
               T000922_A57ConsultorioId
               }
               , new Object[] {
               T000923_A43ConsultaFecha, T000923_A12MedicoId, T000923_A60TurnoId
               }
               , new Object[] {
               T000924_A43ConsultaFecha, T000924_A12MedicoId, T000924_A60TurnoId
               }
               , new Object[] {
               T000925_A43ConsultaFecha, T000925_A12MedicoId, T000925_A60TurnoId
               }
               , new Object[] {
               T000926_A43ConsultaFecha, T000926_A67UltimoNroAsig, T000926_n67UltimoNroAsig, T000926_A12MedicoId, T000926_A60TurnoId, T000926_A57ConsultorioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000930_A9EspecialidadId, T000930_A13MedicoNombre, T000930_A14MedicoApellido
               }
               , new Object[] {
               T000931_A11EspecialidadMaxPacientes
               }
               , new Object[] {
               T000932_A61TurnoNombre
               }
               , new Object[] {
               T000934_A66CantNrosAsig, T000934_n66CantNrosAsig
               }
               , new Object[] {
               T000936_A70CantPacConf, T000936_n70CantPacConf
               }
               , new Object[] {
               T000937_A43ConsultaFecha, T000937_A34PacienteId, T000937_A12MedicoId, T000937_A60TurnoId
               }
               , new Object[] {
               T000938_A43ConsultaFecha, T000938_A12MedicoId, T000938_A60TurnoId
               }
               , new Object[] {
               T000939_A60TurnoId, T000939_A61TurnoNombre
               }
               , new Object[] {
               T000940_A9EspecialidadId, T000940_A13MedicoNombre, T000940_A14MedicoApellido
               }
               , new Object[] {
               T000941_A11EspecialidadMaxPacientes
               }
               , new Object[] {
               T000942_A61TurnoNombre
               }
               , new Object[] {
               T000944_A66CantNrosAsig, T000944_n66CantNrosAsig
               }
               , new Object[] {
               T000946_A70CantPacConf, T000946_n70CantPacConf
               }
               , new Object[] {
               T000947_A57ConsultorioId
               }
            }
         );
         A67UltimoNroAsig = 0 ;
         n67UltimoNroAsig = false ;
         AV24Pgmname = "GestionConsulta" ;
      }

      private short wcpOAV23TurnoId ;
      private short GxWebError ;
      private short A60TurnoId ;
      private short A57ConsultorioId ;
      private short AV23TurnoId ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A66CantNrosAsig ;
      private short A65NrosDisponibles ;
      private short A67UltimoNroAsig ;
      private short A70CantPacConf ;
      private short Z60TurnoId ;
      private short Z67UltimoNroAsig ;
      private short Z57ConsultorioId ;
      private short N57ConsultorioId ;
      private short A11EspecialidadMaxPacientes ;
      private short AV19Insert_ConsultorioId ;
      private short Gx_BScreen ;
      private short RcdFound5 ;
      private short GX_JID ;
      private short Z11EspecialidadMaxPacientes ;
      private short Z66CantNrosAsig ;
      private short Z70CantPacConf ;
      private short gxajaxcallmode ;
      private short i67UltimoNroAsig ;
      private int wcpOAV22MedicoId ;
      private int A12MedicoId ;
      private int A9EspecialidadId ;
      private int AV22MedicoId ;
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
      private int edtCantNrosAsig_Enabled ;
      private int edtNrosDisponibles_Enabled ;
      private int edtUltimoNroAsig_Enabled ;
      private int edtCantPacConf_Enabled ;
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
      private int AV25GXV1 ;
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
      private String lblTextblockcantpacconf_Internalname ;
      private String lblTextblockcantpacconf_Jsonclick ;
      private String edtCantPacConf_Internalname ;
      private String edtCantPacConf_Jsonclick ;
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
      private String AV24Pgmname ;
      private String sMode5 ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String Z13MedicoNombre ;
      private String Z14MedicoApellido ;
      private String Z61TurnoNombre ;
      private String sDynURL ;
      private String FormProcess ;
      private String GXt_char2 ;
      private String GXt_char1 ;
      private String gxwrpcisep ;
      private String GXt_char3 ;
      private DateTime wcpOAV21ConsultaFecha ;
      private DateTime A43ConsultaFecha ;
      private DateTime AV21ConsultaFecha ;
      private DateTime Z43ConsultaFecha ;
      private bool entryPointCalled ;
      private bool wbErr ;
      private bool n66CantNrosAsig ;
      private bool n67UltimoNroAsig ;
      private bool n70CantPacConf ;
      private bool AV16IsAuthorized ;
      private bool returnInSub ;
      private GxWebSession AV18WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GxUnknownObjectCollection isValidOutput ;
      private GXMasterPage MasterPageObj ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynTurnoId ;
      private IDataStoreProvider pr_default ;
      private String[] T00096_A61TurnoNombre ;
      private int[] T00094_A9EspecialidadId ;
      private String[] T00094_A13MedicoNombre ;
      private String[] T00094_A14MedicoApellido ;
      private short[] T00095_A11EspecialidadMaxPacientes ;
      private short[] T00099_A66CantNrosAsig ;
      private bool[] T00099_n66CantNrosAsig ;
      private short[] T000911_A70CantPacConf ;
      private bool[] T000911_n70CantPacConf ;
      private int[] T000914_A9EspecialidadId ;
      private DateTime[] T000914_A43ConsultaFecha ;
      private String[] T000914_A13MedicoNombre ;
      private String[] T000914_A14MedicoApellido ;
      private String[] T000914_A61TurnoNombre ;
      private short[] T000914_A67UltimoNroAsig ;
      private bool[] T000914_n67UltimoNroAsig ;
      private short[] T000914_A11EspecialidadMaxPacientes ;
      private int[] T000914_A12MedicoId ;
      private short[] T000914_A60TurnoId ;
      private short[] T000914_A57ConsultorioId ;
      private short[] T000914_A66CantNrosAsig ;
      private bool[] T000914_n66CantNrosAsig ;
      private short[] T000914_A70CantPacConf ;
      private bool[] T000914_n70CantPacConf ;
      private short[] T00097_A57ConsultorioId ;
      private int[] T000915_A9EspecialidadId ;
      private String[] T000915_A13MedicoNombre ;
      private String[] T000915_A14MedicoApellido ;
      private short[] T000916_A11EspecialidadMaxPacientes ;
      private String[] T000917_A61TurnoNombre ;
      private short[] T000919_A66CantNrosAsig ;
      private bool[] T000919_n66CantNrosAsig ;
      private short[] T000921_A70CantPacConf ;
      private bool[] T000921_n70CantPacConf ;
      private short[] T000922_A57ConsultorioId ;
      private DateTime[] T000923_A43ConsultaFecha ;
      private int[] T000923_A12MedicoId ;
      private short[] T000923_A60TurnoId ;
      private DateTime[] T00093_A43ConsultaFecha ;
      private short[] T00093_A67UltimoNroAsig ;
      private bool[] T00093_n67UltimoNroAsig ;
      private int[] T00093_A12MedicoId ;
      private short[] T00093_A60TurnoId ;
      private short[] T00093_A57ConsultorioId ;
      private DateTime[] T000924_A43ConsultaFecha ;
      private int[] T000924_A12MedicoId ;
      private short[] T000924_A60TurnoId ;
      private DateTime[] T000925_A43ConsultaFecha ;
      private int[] T000925_A12MedicoId ;
      private short[] T000925_A60TurnoId ;
      private DateTime[] T000926_A43ConsultaFecha ;
      private short[] T000926_A67UltimoNroAsig ;
      private bool[] T000926_n67UltimoNroAsig ;
      private int[] T000926_A12MedicoId ;
      private short[] T000926_A60TurnoId ;
      private short[] T000926_A57ConsultorioId ;
      private int[] T000930_A9EspecialidadId ;
      private String[] T000930_A13MedicoNombre ;
      private String[] T000930_A14MedicoApellido ;
      private short[] T000931_A11EspecialidadMaxPacientes ;
      private String[] T000932_A61TurnoNombre ;
      private short[] T000934_A66CantNrosAsig ;
      private bool[] T000934_n66CantNrosAsig ;
      private short[] T000936_A70CantPacConf ;
      private bool[] T000936_n70CantPacConf ;
      private DateTime[] T000937_A43ConsultaFecha ;
      private int[] T000937_A34PacienteId ;
      private int[] T000937_A12MedicoId ;
      private short[] T000937_A60TurnoId ;
      private DateTime[] T000938_A43ConsultaFecha ;
      private int[] T000938_A12MedicoId ;
      private short[] T000938_A60TurnoId ;
      private short[] T000939_A60TurnoId ;
      private String[] T000939_A61TurnoNombre ;
      private int[] T000940_A9EspecialidadId ;
      private String[] T000940_A13MedicoNombre ;
      private String[] T000940_A14MedicoApellido ;
      private short[] T000941_A11EspecialidadMaxPacientes ;
      private String[] T000942_A61TurnoNombre ;
      private short[] T000944_A66CantNrosAsig ;
      private bool[] T000944_n66CantNrosAsig ;
      private short[] T000946_A70CantPacConf ;
      private bool[] T000946_n70CantPacConf ;
      private short[] T000947_A57ConsultorioId ;
      private DateTime[] T00092_A43ConsultaFecha ;
      private short[] T00092_A67UltimoNroAsig ;
      private int[] T00092_A12MedicoId ;
      private short[] T00092_A60TurnoId ;
      private short[] T00092_A57ConsultorioId ;
      private bool[] T00092_n67UltimoNroAsig ;
      private GXWebForm Form ;
      private SdtTransactionContext AV17TrnContext ;
      private SdtTransactionContext_Attribute AV20TrnContextAtt ;
   }

   public class gestionconsulta__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[18])
         ,new UpdateCursor(def[19])
         ,new UpdateCursor(def[20])
         ,new UpdateCursor(def[21])
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00092 ;
          prmT00092 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000914 ;
          prmT000914 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT00094 ;
          prmT00094 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00095 ;
          prmT00095 = new Object[] {
          new Object[] {"@EspecialidadId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00096 ;
          prmT00096 = new Object[] {
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT00099 ;
          prmT00099 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000911 ;
          prmT000911 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT00097 ;
          prmT00097 = new Object[] {
          new Object[] {"@ConsultorioId",SqlDbType.SmallInt,3,0}
          } ;
          Object[] prmT000915 ;
          prmT000915 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000916 ;
          prmT000916 = new Object[] {
          new Object[] {"@EspecialidadId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000917 ;
          prmT000917 = new Object[] {
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000919 ;
          prmT000919 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000921 ;
          prmT000921 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000922 ;
          prmT000922 = new Object[] {
          new Object[] {"@ConsultorioId",SqlDbType.SmallInt,3,0}
          } ;
          Object[] prmT000923 ;
          prmT000923 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT00093 ;
          prmT00093 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000924 ;
          prmT000924 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000925 ;
          prmT000925 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000926 ;
          prmT000926 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000927 ;
          prmT000927 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@UltimoNroAsig",SqlDbType.SmallInt,2,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0} ,
          new Object[] {"@ConsultorioId",SqlDbType.SmallInt,3,0}
          } ;
          Object[] prmT000928 ;
          prmT000928 = new Object[] {
          new Object[] {"@UltimoNroAsig",SqlDbType.SmallInt,2,0} ,
          new Object[] {"@ConsultorioId",SqlDbType.SmallInt,3,0} ,
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000929 ;
          prmT000929 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000930 ;
          prmT000930 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000931 ;
          prmT000931 = new Object[] {
          new Object[] {"@EspecialidadId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000932 ;
          prmT000932 = new Object[] {
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000934 ;
          prmT000934 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000936 ;
          prmT000936 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000937 ;
          prmT000937 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000938 ;
          prmT000938 = new Object[] {
          } ;
          Object[] prmT000939 ;
          prmT000939 = new Object[] {
          } ;
          Object[] prmT000940 ;
          prmT000940 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000941 ;
          prmT000941 = new Object[] {
          new Object[] {"@EspecialidadId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000942 ;
          prmT000942 = new Object[] {
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000944 ;
          prmT000944 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000946 ;
          prmT000946 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmT000947 ;
          prmT000947 = new Object[] {
          new Object[] {"@ConsultorioId",SqlDbType.SmallInt,3,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("T00092", "SELECT [ConsultaFecha], [UltimoNroAsig], [MedicoId], [TurnoId], [ConsultorioId] FROM [Consulta] WITH (UPDLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00092,1,0,true,false )
             ,new CursorDef("T00093", "SELECT [ConsultaFecha], [UltimoNroAsig], [MedicoId], [TurnoId], [ConsultorioId] FROM [Consulta] WITH (NOLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00093,1,0,true,false )
             ,new CursorDef("T00094", "SELECT [EspecialidadId], [MedicoNombre], [MedicoApellido] FROM [Medico] WITH (NOLOCK) WHERE [MedicoId] = @MedicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00094,1,0,true,false )
             ,new CursorDef("T00095", "SELECT [EspecialidadMaxPacientes] FROM [Especialidad] WITH (NOLOCK) WHERE [EspecialidadId] = @EspecialidadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00095,1,0,true,false )
             ,new CursorDef("T00096", "SELECT [TurnoNombre] FROM [Turno] WITH (NOLOCK) WHERE [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00096,1,0,true,false )
             ,new CursorDef("T00097", "SELECT [ConsultorioId] FROM [Consultorio] WITH (NOLOCK) WHERE [ConsultorioId] = @ConsultorioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00097,1,0,true,false )
             ,new CursorDef("T00099", "SELECT COALESCE( T1.[CantNrosAsig], 0) AS CantNrosAsig FROM (SELECT COUNT(*) AS CantNrosAsig, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T1 WHERE T1.[ConsultaFecha] = @ConsultaFecha AND T1.[MedicoId] = @MedicoId AND T1.[TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00099,1,0,true,false )
             ,new CursorDef("T000911", "SELECT COALESCE( T1.[CantPacConf], 0) AS CantPacConf FROM (SELECT COUNT(*) AS CantPacConf, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) WHERE [Confirmado] = 1 GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T1 WHERE T1.[ConsultaFecha] = @ConsultaFecha AND T1.[MedicoId] = @MedicoId AND T1.[TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000911,1,0,true,false )
             ,new CursorDef("T000914", "SELECT T2.[EspecialidadId], TM1.[ConsultaFecha], T2.[MedicoNombre], T2.[MedicoApellido], T4.[TurnoNombre], TM1.[UltimoNroAsig], T3.[EspecialidadMaxPacientes], TM1.[MedicoId], TM1.[TurnoId], TM1.[ConsultorioId], COALESCE( T5.[CantNrosAsig], 0) AS CantNrosAsig, COALESCE( T6.[CantPacConf], 0) AS CantPacConf FROM ((((([Consulta] TM1 WITH (NOLOCK) INNER JOIN [Medico] T2 WITH (NOLOCK) ON T2.[MedicoId] = TM1.[MedicoId]) INNER JOIN [Especialidad] T3 WITH (NOLOCK) ON T3.[EspecialidadId] = T2.[EspecialidadId]) INNER JOIN [Turno] T4 WITH (NOLOCK) ON T4.[TurnoId] = TM1.[TurnoId]) LEFT JOIN (SELECT COUNT(*) AS CantNrosAsig, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T5 ON T5.[ConsultaFecha] = TM1.[ConsultaFecha] AND T5.[MedicoId] = TM1.[MedicoId] AND T5.[TurnoId] = TM1.[TurnoId]) LEFT JOIN (SELECT COUNT(*) AS CantPacConf, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) WHERE [Confirmado] = 1 GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T6 ON T6.[ConsultaFecha] = TM1.[ConsultaFecha] AND T6.[MedicoId] = TM1.[MedicoId] AND T6.[TurnoId] = TM1.[TurnoId]) WHERE TM1.[ConsultaFecha] = @ConsultaFecha and TM1.[MedicoId] = @MedicoId and TM1.[TurnoId] = @TurnoId ORDER BY TM1.[ConsultaFecha], TM1.[MedicoId], TM1.[TurnoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000914,100,0,true,false )
             ,new CursorDef("T000915", "SELECT [EspecialidadId], [MedicoNombre], [MedicoApellido] FROM [Medico] WITH (NOLOCK) WHERE [MedicoId] = @MedicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000915,1,0,true,false )
             ,new CursorDef("T000916", "SELECT [EspecialidadMaxPacientes] FROM [Especialidad] WITH (NOLOCK) WHERE [EspecialidadId] = @EspecialidadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000916,1,0,true,false )
             ,new CursorDef("T000917", "SELECT [TurnoNombre] FROM [Turno] WITH (NOLOCK) WHERE [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000917,1,0,true,false )
             ,new CursorDef("T000919", "SELECT COALESCE( T1.[CantNrosAsig], 0) AS CantNrosAsig FROM (SELECT COUNT(*) AS CantNrosAsig, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T1 WHERE T1.[ConsultaFecha] = @ConsultaFecha AND T1.[MedicoId] = @MedicoId AND T1.[TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000919,1,0,true,false )
             ,new CursorDef("T000921", "SELECT COALESCE( T1.[CantPacConf], 0) AS CantPacConf FROM (SELECT COUNT(*) AS CantPacConf, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) WHERE [Confirmado] = 1 GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T1 WHERE T1.[ConsultaFecha] = @ConsultaFecha AND T1.[MedicoId] = @MedicoId AND T1.[TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000921,1,0,true,false )
             ,new CursorDef("T000922", "SELECT [ConsultorioId] FROM [Consultorio] WITH (NOLOCK) WHERE [ConsultorioId] = @ConsultorioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000922,1,0,true,false )
             ,new CursorDef("T000923", "SELECT [ConsultaFecha], [MedicoId], [TurnoId] FROM [Consulta] WITH (NOLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000923,1,0,true,false )
             ,new CursorDef("T000924", "SELECT TOP 1 [ConsultaFecha], [MedicoId], [TurnoId] FROM [Consulta] WITH (NOLOCK) WHERE ( [ConsultaFecha] > @ConsultaFecha or [ConsultaFecha] = @ConsultaFecha and [MedicoId] > @MedicoId or [MedicoId] = @MedicoId and [ConsultaFecha] = @ConsultaFecha and [TurnoId] > @TurnoId) ORDER BY [ConsultaFecha], [MedicoId], [TurnoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000924,1,0,true,true )
             ,new CursorDef("T000925", "SELECT TOP 1 [ConsultaFecha], [MedicoId], [TurnoId] FROM [Consulta] WITH (NOLOCK) WHERE ( [ConsultaFecha] < @ConsultaFecha or [ConsultaFecha] = @ConsultaFecha and [MedicoId] < @MedicoId or [MedicoId] = @MedicoId and [ConsultaFecha] = @ConsultaFecha and [TurnoId] < @TurnoId) ORDER BY [ConsultaFecha] DESC, [MedicoId] DESC, [TurnoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000925,1,0,true,true )
             ,new CursorDef("T000926", "SELECT [ConsultaFecha], [UltimoNroAsig], [MedicoId], [TurnoId], [ConsultorioId] FROM [Consulta] WITH (UPDLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000926,1,0,true,false )
             ,new CursorDef("T000927", "INSERT INTO [Consulta] ([ConsultaFecha], [UltimoNroAsig], [MedicoId], [TurnoId], [ConsultorioId]) VALUES (@ConsultaFecha, @UltimoNroAsig, @MedicoId, @TurnoId, @ConsultorioId)", GxErrorMask.GX_NOMASK,prmT000927)
             ,new CursorDef("T000928", "UPDATE [Consulta] SET [UltimoNroAsig]=@UltimoNroAsig, [ConsultorioId]=@ConsultorioId  WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId", GxErrorMask.GX_NOMASK,prmT000928)
             ,new CursorDef("T000929", "DELETE FROM [Consulta]  WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId", GxErrorMask.GX_NOMASK,prmT000929)
             ,new CursorDef("T000930", "SELECT [EspecialidadId], [MedicoNombre], [MedicoApellido] FROM [Medico] WITH (NOLOCK) WHERE [MedicoId] = @MedicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000930,1,0,true,false )
             ,new CursorDef("T000931", "SELECT [EspecialidadMaxPacientes] FROM [Especialidad] WITH (NOLOCK) WHERE [EspecialidadId] = @EspecialidadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000931,1,0,true,false )
             ,new CursorDef("T000932", "SELECT [TurnoNombre] FROM [Turno] WITH (NOLOCK) WHERE [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000932,1,0,true,false )
             ,new CursorDef("T000934", "SELECT COALESCE( T1.[CantNrosAsig], 0) AS CantNrosAsig FROM (SELECT COUNT(*) AS CantNrosAsig, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T1 WHERE T1.[ConsultaFecha] = @ConsultaFecha AND T1.[MedicoId] = @MedicoId AND T1.[TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000934,1,0,true,false )
             ,new CursorDef("T000936", "SELECT COALESCE( T1.[CantPacConf], 0) AS CantPacConf FROM (SELECT COUNT(*) AS CantPacConf, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) WHERE [Confirmado] = 1 GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T1 WHERE T1.[ConsultaFecha] = @ConsultaFecha AND T1.[MedicoId] = @MedicoId AND T1.[TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000936,1,0,true,false )
             ,new CursorDef("T000937", "SELECT TOP 1 [ConsultaFecha], [PacienteId], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) WHERE [ConsultaFecha] = @ConsultaFecha AND [MedicoId] = @MedicoId AND [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000937,1,0,true,true )
             ,new CursorDef("T000938", "SELECT [ConsultaFecha], [MedicoId], [TurnoId] FROM [Consulta] WITH (NOLOCK) ORDER BY [ConsultaFecha], [MedicoId], [TurnoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000938,100,0,true,false )
             ,new CursorDef("T000939", "SELECT [TurnoId], [TurnoNombre] FROM [Turno] WITH (NOLOCK) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000939,0,0,true,false )
             ,new CursorDef("T000940", "SELECT [EspecialidadId], [MedicoNombre], [MedicoApellido] FROM [Medico] WITH (NOLOCK) WHERE [MedicoId] = @MedicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000940,1,0,true,false )
             ,new CursorDef("T000941", "SELECT [EspecialidadMaxPacientes] FROM [Especialidad] WITH (NOLOCK) WHERE [EspecialidadId] = @EspecialidadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000941,1,0,true,false )
             ,new CursorDef("T000942", "SELECT [TurnoNombre] FROM [Turno] WITH (NOLOCK) WHERE [TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000942,1,0,true,false )
             ,new CursorDef("T000944", "SELECT COALESCE( T1.[CantNrosAsig], 0) AS CantNrosAsig FROM (SELECT COUNT(*) AS CantNrosAsig, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T1 WHERE T1.[ConsultaFecha] = @ConsultaFecha AND T1.[MedicoId] = @MedicoId AND T1.[TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000944,1,0,true,false )
             ,new CursorDef("T000946", "SELECT COALESCE( T1.[CantPacConf], 0) AS CantPacConf FROM (SELECT COUNT(*) AS CantPacConf, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) WHERE [Confirmado] = 1 GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T1 WHERE T1.[ConsultaFecha] = @ConsultaFecha AND T1.[MedicoId] = @MedicoId AND T1.[TurnoId] = @TurnoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000946,1,0,true,false )
             ,new CursorDef("T000947", "SELECT [ConsultorioId] FROM [Consultorio] WITH (NOLOCK) WHERE [ConsultorioId] = @ConsultorioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000947,1,0,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                break;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                break;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                break;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                ((String[]) buf[3])[0] = rslt.getString(4, 20) ;
                ((String[]) buf[4])[0] = rslt.getString(5, 20) ;
                ((short[]) buf[5])[0] = rslt.getShort(6) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((short[]) buf[7])[0] = rslt.getShort(7) ;
                ((int[]) buf[8])[0] = rslt.getInt(8) ;
                ((short[]) buf[9])[0] = rslt.getShort(9) ;
                ((short[]) buf[10])[0] = rslt.getShort(10) ;
                ((short[]) buf[11])[0] = rslt.getShort(11) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((short[]) buf[13])[0] = rslt.getShort(12) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(12);
                break;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                break;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                break;
             case 11 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                break;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                break;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                break;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                break;
             case 15 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                break;
             case 16 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                break;
             case 17 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                break;
             case 18 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3) ;
                ((short[]) buf[4])[0] = rslt.getShort(4) ;
                ((short[]) buf[5])[0] = rslt.getShort(5) ;
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
             case 26 :
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                break;
             case 29 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
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
             case 34 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                break;
             case 35 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
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
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 9 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 10 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 11 :
                stmt.SetParameter(1, (short)parms[0]);
                break;
             case 12 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 13 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 14 :
                stmt.SetParameter(1, (short)parms[0]);
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
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 18 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 19 :
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
             case 20 :
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
             case 21 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
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
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 27 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
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
             case 34 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 35 :
                stmt.SetParameter(1, (short)parms[0]);
                break;
       }
    }

 }

}
