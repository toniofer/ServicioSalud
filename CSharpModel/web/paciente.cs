/*
               File: Paciente
        Description: Paciente
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/22/2010 4:1:7.81
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
   public class paciente : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel5"+"_"+"_VALIDACION") == 0 )
         {
            A41PacienteCI = GetNextPar( ) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            GX5ASAVALIDACION044( A41PacienteCI) ;
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
         cmbPacienteEstadoCivil.Name = "PACIENTEESTADOCIVIL" ;
         cmbPacienteEstadoCivil.WebTags = "" ;
         cmbPacienteEstadoCivil.addItem("S", "Soltero", 0);
         cmbPacienteEstadoCivil.addItem("C", "Casado", 0);
         cmbPacienteEstadoCivil.addItem("V", "Viudo", 0);
         cmbPacienteEstadoCivil.addItem("D", "Divorciado", 0);
         if ( ( cmbPacienteEstadoCivil.ItemCount > 0 ) && String.IsNullOrEmpty(StringUtil.RTrim( A38PacienteEstadoCivil)) )
         {
            A38PacienteEstadoCivil = cmbPacienteEstadoCivil.getItemValue(1) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A38PacienteEstadoCivil", A38PacienteEstadoCivil);
         }
         Form.Meta.addItem("Generator", "GeneXus C#", 0) ;
         Form.Meta.addItem("Version", "10_1_3-34981", 0) ;
         Form.Meta.addItem("Description", "Paciente", 0) ;
         context.wjLoc = "" ;
         context.nUserReturn = 0 ;
         context.wbHandled = 0 ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         GX_FocusControl = edtPacienteApellido_Internalname ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         wbErr = false ;
         context.SetTheme("GeneXusX");
      }

      public paciente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public paciente( IGxContext context )
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
         cmbPacienteEstadoCivil = new GXCombobox();
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
            wb_table1_2_044( true) ;
         }
         return  ;
      }

      protected void wb_table1_2_044e( bool wbgen )
      {
         if ( wbgen )
         {
         }
         /* Execute Exit event if defined. */
      }

      protected void wb_table1_2_044( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTablemain_Internalname, tblTablemain_Internalname, "", "TableBorder100x100", 0, "", "", 1, 2, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_5_044( true) ;
         }
         return  ;
      }

      protected void wb_table2_5_044e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Control Group */
            ClassString = "Group" ;
            StyleString = "" ;
            context.WriteHtmlText( "<fieldset id=\""+grpGroupdata_Internalname+"\""+" style=\"-moz-border-radius:3pt;\""+" class=\""+ClassString+"\">") ;
            context.WriteHtmlText( "<legend class=\""+ClassString+"Title"+"\">"+"Paciente"+"</legend>") ;
            wb_table3_27_044( true) ;
         }
         return  ;
      }

      protected void wb_table3_27_044e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</fieldset>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_2_044e( true) ;
         }
         else
         {
            wb_table1_2_044e( false) ;
         }
      }

      protected void wb_table3_27_044( bool wbgen )
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
            wb_table4_33_044( true) ;
         }
         return  ;
      }

      protected void wb_table4_33_044e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"" ;
            ClassString = "BtnEnter" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtn_enter_Internalname, "Confirmar", "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, 1, "rounded", 5, bttBtn_enter_Jsonclick, "EENTER.", TempTags, "", "", "HLP_Paciente.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"" ;
            ClassString = "BtnCancel" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtn_cancel_Internalname, "Cancelar", "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "rounded", 1, bttBtn_cancel_Jsonclick, "ECANCEL.", TempTags, "", "", "HLP_Paciente.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"" ;
            ClassString = "BtnDelete" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtn_delete_Internalname, "Eliminar", "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, 1, "rounded", 5, bttBtn_delete_Jsonclick, "EDELETE.", TempTags, "", "", "HLP_Paciente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_27_044e( true) ;
         }
         else
         {
            wb_table3_27_044e( false) ;
         }
      }

      protected void wb_table4_33_044( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblTextblockpacienteid_Internalname, 1, 1, 0, "Id", "", "", "", 0, lblTextblockpacienteid_Jsonclick, "", StyleString, ClassString, "HLP_Paciente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtPacienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A34PacienteId), 6, 0, ",", "")), "", 6, "chr", 1, "row", 6, 1, edtPacienteId_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A34PacienteId), "ZZZZZ9"), "", 0, edtPacienteId_Jsonclick, "", 0, 1, -1, true, "right", "HLP_Paciente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockpacienteapellido_Internalname, 1, 1, 0, "Apellido", "", "", "", 0, lblTextblockpacienteapellido_Jsonclick, "", StyleString, ClassString, "HLP_Paciente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtPacienteApellido_Internalname, StringUtil.RTrim( A36PacienteApellido), "", 20, "chr", 1, "row", 20, 1, edtPacienteApellido_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A36PacienteApellido, "XXXXXXXXXXXXXXXXXXXX")), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(43);\"", 0, edtPacienteApellido_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Paciente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockpacientenombre_Internalname, 1, 1, 0, "Nombre", "", "", "", 0, lblTextblockpacientenombre_Jsonclick, "", StyleString, ClassString, "HLP_Paciente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtPacienteNombre_Internalname, StringUtil.RTrim( A35PacienteNombre), "", 20, "chr", 1, "row", 20, 1, edtPacienteNombre_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A35PacienteNombre, "XXXXXXXXXXXXXXXXXXXX")), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(48);\"", 0, edtPacienteNombre_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Paciente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockpacientedomicilio_Internalname, 1, 1, 0, "Domicilio", "", "", "", 0, lblTextblockpacientedomicilio_Jsonclick, "", StyleString, ClassString, "HLP_Paciente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtPacienteDomicilio_Internalname, StringUtil.RTrim( A37PacienteDomicilio), "", 40, "chr", 1, "row", 40, 1, edtPacienteDomicilio_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A37PacienteDomicilio, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(53);\"", 0, edtPacienteDomicilio_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Paciente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockpacienteestadocivil_Internalname, 1, 1, 0, "Estado Civil", "", "", "", 0, lblTextblockpacienteestadocivil_Jsonclick, "", StyleString, ClassString, "HLP_Paciente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"" ;
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbPacienteEstadoCivil, cmbPacienteEstadoCivil_Internalname, A38PacienteEstadoCivil, "", "char", 1, cmbPacienteEstadoCivil.Enabled, 0, 1, 0, 1, "chr", 0, "", StyleString, ClassString, "", 0, cmbPacienteEstadoCivil_Jsonclick, "", TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(58);\"", true, "HLP_Paciente.htm");
            cmbPacienteEstadoCivil.CurrentValue = A38PacienteEstadoCivil ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, cmbPacienteEstadoCivil_Internalname, "Values", (String)(cmbPacienteEstadoCivil.ToJavascriptSource()));
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockpacientefechanacimiento_Internalname, 1, 1, 0, "Fecha Nacimiento", "", "", "", 0, lblTextblockpacientefechanacimiento_Jsonclick, "", StyleString, ClassString, "HLP_Paciente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            if ( ( edtPacienteFechaNacimiento_Enabled == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlText( "<table id=\""+edtPacienteFechaNacimiento_Internalname+"_dp_container\" cellpadding=\"0\" cellspacing=\"0\"><tr><td>") ;
            }
            GxWebStd.gx_single_line_edit( context, edtPacienteFechaNacimiento_Internalname, context.localUtil.Format(A39PacienteFechaNacimiento, "99/99/99"), "", 8, "chr", 1, "row", 8, 1, edtPacienteFechaNacimiento_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( A39PacienteFechaNacimiento, "99/99/99"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(63);\"", 0, edtPacienteFechaNacimiento_Jsonclick, "", 0, 1, -1, true, "right", "HLP_Paciente.htm");
            if ( ( edtPacienteFechaNacimiento_Enabled == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlTextNl( "</td><td>") ;
               context.WriteHtmlText( "<img src=\""+context.convertURL( "calendar-img.gif")+"\" id=\""+edtPacienteFechaNacimiento_Internalname+"_dp_trigger\" style=\"cursor: pointer;\" title=\"Date selector\" alt=\"Date selector\" >") ;
               context.WriteHtmlTextNl( "</td></tr></table>") ;
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockpacientefechaingreso_Internalname, 1, 1, 0, "Fecha Ingreso", "", "", "", 0, lblTextblockpacientefechaingreso_Jsonclick, "", StyleString, ClassString, "HLP_Paciente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            if ( ( edtPacienteFechaIngreso_Enabled == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlText( "<table id=\""+edtPacienteFechaIngreso_Internalname+"_dp_container\" cellpadding=\"0\" cellspacing=\"0\"><tr><td>") ;
            }
            GxWebStd.gx_single_line_edit( context, edtPacienteFechaIngreso_Internalname, context.localUtil.Format(A40PacienteFechaIngreso, "99/99/99"), "", 8, "chr", 1, "row", 8, 1, edtPacienteFechaIngreso_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( A40PacienteFechaIngreso, "99/99/99"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(68);\"", 0, edtPacienteFechaIngreso_Jsonclick, "", 0, 1, -1, true, "right", "HLP_Paciente.htm");
            if ( ( edtPacienteFechaIngreso_Enabled == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlTextNl( "</td><td>") ;
               context.WriteHtmlText( "<img src=\""+context.convertURL( "calendar-img.gif")+"\" id=\""+edtPacienteFechaIngreso_Internalname+"_dp_trigger\" style=\"cursor: pointer;\" title=\"Date selector\" alt=\"Date selector\" >") ;
               context.WriteHtmlTextNl( "</td></tr></table>") ;
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockpacienteci_Internalname, 1, 1, 0, "CI", "", "", "", 0, lblTextblockpacienteci_Jsonclick, "", StyleString, ClassString, "HLP_Paciente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtPacienteCI_Internalname, StringUtil.RTrim( A41PacienteCI), "", 8, "chr", 1, "row", 8, 1, edtPacienteCI_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A41PacienteCI, "XXXXXXXX")), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(73);\"", 0, edtPacienteCI_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Paciente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_33_044e( true) ;
         }
         else
         {
            wb_table4_33_044e( false) ;
         }
      }

      protected void wb_table2_5_044( bool wbgen )
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
            GxWebStd.gx_bitmap( context, imgBtn_first_Internalname, "", context.GetImagePath( "b9e06284-17ac-4c88-8937-5dbd84ad5d80", "", "GeneXusX"), "GeneXusX", imgBtn_first_Visible, 1, "", "Primero", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_first_Jsonclick, "EFIRST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Paciente.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_first_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_first_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_first_separator_Jsonclick, "EFIRST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Paciente.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_previous_Internalname, "", context.GetImagePath( "7d212604-db7b-4785-9c0d-5faffe71aa33", "", "GeneXusX"), "GeneXusX", imgBtn_previous_Visible, 1, "", "Anterior", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_previous_Jsonclick, "EPREVIOUS.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Paciente.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_previous_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_previous_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_previous_separator_Jsonclick, "EPREVIOUS.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Paciente.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_next_Internalname, "", context.GetImagePath( "1ae947cf-1354-41a9-8d59-d91daebf554f", "", "GeneXusX"), "GeneXusX", imgBtn_next_Visible, 1, "", "Siguiente", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_next_Jsonclick, "ENEXT.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Paciente.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_next_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_next_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_next_separator_Jsonclick, "ENEXT.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Paciente.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_last_Internalname, "", context.GetImagePath( "29211874-e613-48e5-9011-8017d984217e", "", "GeneXusX"), "GeneXusX", imgBtn_last_Visible, 1, "", "Ultimo", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_last_Jsonclick, "ELAST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Paciente.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_last_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_last_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_last_separator_Jsonclick, "ELAST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Paciente.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_select_Internalname, "", context.GetImagePath( "1ca03f75-9947-4d2c-90a4-e8ab9c5cedea", "", "GeneXusX"), "GeneXusX", imgBtn_select_Visible, 1, "", "Seleccionar", 0, 0, 0, "", 0, "", 0, 0, "", "", 4, imgBtn_select_Jsonclick, "ESELECT.", StyleString, ClassString, "", ""+TempTags, "", "gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PACIENTEID"+"'), id:'"+"PACIENTEID"+"'"+",isOut:true,isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", "HLP_Paciente.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_select_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_select_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 4, imgBtn_select_separator_Jsonclick, "ESELECT.", StyleString, ClassString, "", ""+TempTags, "", "gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PACIENTEID"+"'), id:'"+"PACIENTEID"+"'"+",isOut:true,isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", "HLP_Paciente.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_enter2_Internalname, "", context.GetImagePath( "2061cf2c-bd33-4433-a13e-34af954142e9", "", "GeneXusX"), "GeneXusX", imgBtn_enter2_Visible, imgBtn_enter2_Enabled, "", "Confirmar", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_enter2_Jsonclick, "EENTER.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Paciente.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_enter2_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_enter2_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_enter2_separator_Jsonclick, "EENTER.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Paciente.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_cancel2_Internalname, "", context.GetImagePath( "0e94ced8-bc34-47ff-9a53-bc683736a686", "", "GeneXusX"), "GeneXusX", imgBtn_cancel2_Visible, 1, "", "Cancelar", 0, 0, 0, "", 0, "", 0, 0, "", "", 1, imgBtn_cancel2_Jsonclick, "ECANCEL.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Paciente.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_cancel2_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_cancel2_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 1, imgBtn_cancel2_separator_Jsonclick, "ECANCEL.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Paciente.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_delete2_Internalname, "", context.GetImagePath( "7695fe89-52c9-4b7e-871e-0e11548f823e", "", "GeneXusX"), "GeneXusX", imgBtn_delete2_Visible, imgBtn_delete2_Enabled, "", "Eliminar", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_delete2_Jsonclick, "EDELETE.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Paciente.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_delete2_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_delete2_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_delete2_separator_Jsonclick, "EDELETE.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Paciente.htm");
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
            wb_table2_5_044e( true) ;
         }
         else
         {
            wb_table2_5_044e( false) ;
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
         /* Execute user event: E11042 */
         E11042 ();
         context.wbGlbDoneStart = 1 ;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read variables values. */
               A34PacienteId = (int)(context.localUtil.CToN( cgiGet( edtPacienteId_Internalname), ",", ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
               A36PacienteApellido = cgiGet( edtPacienteApellido_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A36PacienteApellido", A36PacienteApellido);
               A35PacienteNombre = cgiGet( edtPacienteNombre_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A35PacienteNombre", A35PacienteNombre);
               A37PacienteDomicilio = cgiGet( edtPacienteDomicilio_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A37PacienteDomicilio", A37PacienteDomicilio);
               cmbPacienteEstadoCivil.CurrentValue = cgiGet( cmbPacienteEstadoCivil_Internalname) ;
               A38PacienteEstadoCivil = cgiGet( cmbPacienteEstadoCivil_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A38PacienteEstadoCivil", A38PacienteEstadoCivil);
               if ( context.localUtil.VCDate( cgiGet( edtPacienteFechaNacimiento_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Paciente Fecha Nacimiento"}), 1, "PACIENTEFECHANACIMIENTO");
                  AnyError = 1 ;
                  GX_FocusControl = edtPacienteFechaNacimiento_Internalname ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true ;
                  A39PacienteFechaNacimiento = DateTime.MinValue ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A39PacienteFechaNacimiento", context.localUtil.Format(A39PacienteFechaNacimiento, "99/99/99"));
               }
               else
               {
                  A39PacienteFechaNacimiento = context.localUtil.CToD( cgiGet( edtPacienteFechaNacimiento_Internalname), 2) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A39PacienteFechaNacimiento", context.localUtil.Format(A39PacienteFechaNacimiento, "99/99/99"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtPacienteFechaIngreso_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Paciente Fecha Ingreso"}), 1, "PACIENTEFECHAINGRESO");
                  AnyError = 1 ;
                  GX_FocusControl = edtPacienteFechaIngreso_Internalname ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true ;
                  A40PacienteFechaIngreso = DateTime.MinValue ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A40PacienteFechaIngreso", context.localUtil.Format(A40PacienteFechaIngreso, "99/99/99"));
               }
               else
               {
                  A40PacienteFechaIngreso = context.localUtil.CToD( cgiGet( edtPacienteFechaIngreso_Internalname), 2) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A40PacienteFechaIngreso", context.localUtil.Format(A40PacienteFechaIngreso, "99/99/99"));
               }
               A41PacienteCI = cgiGet( edtPacienteCI_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
               /* Read saved values. */
               Z34PacienteId = (int)(context.localUtil.CToN( cgiGet( "Z34PacienteId"), ",", ".")) ;
               Z36PacienteApellido = cgiGet( "Z36PacienteApellido") ;
               Z35PacienteNombre = cgiGet( "Z35PacienteNombre") ;
               Z37PacienteDomicilio = cgiGet( "Z37PacienteDomicilio") ;
               Z38PacienteEstadoCivil = cgiGet( "Z38PacienteEstadoCivil") ;
               Z39PacienteFechaNacimiento = context.localUtil.CToD( cgiGet( "Z39PacienteFechaNacimiento"), 0) ;
               Z40PacienteFechaIngreso = context.localUtil.CToD( cgiGet( "Z40PacienteFechaIngreso"), 0) ;
               Z41PacienteCI = cgiGet( "Z41PacienteCI") ;
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", ".")) ;
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", ".")) ;
               Gx_mode = cgiGet( "Mode") ;
               AV7Validacion = cgiGet( "_VALIDACION") ;
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
                  A34PacienteId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
                  getEqualNoModal( ) ;
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1 ;
                           dynload_actions( ) ;
                           /* Execute user event: E11042 */
                           E11042 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1 ;
                           dynload_actions( ) ;
                           /* Execute user event: E12042 */
                           E12042 ();
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
            /* Execute user event: E12042 */
            E12042 ();
            trnEnded = 0 ;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  )
            {
               /* Clear variables for new insertion. */
               InitAll044( ) ;
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
         edtPacienteId_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPacienteId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPacienteId_Enabled), 5, 0)));
         edtPacienteApellido_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPacienteApellido_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPacienteApellido_Enabled), 5, 0)));
         edtPacienteNombre_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPacienteNombre_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPacienteNombre_Enabled), 5, 0)));
         edtPacienteDomicilio_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPacienteDomicilio_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPacienteDomicilio_Enabled), 5, 0)));
         cmbPacienteEstadoCivil.Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, cmbPacienteEstadoCivil_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(cmbPacienteEstadoCivil.Enabled), 5, 0)));
         edtPacienteFechaNacimiento_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPacienteFechaNacimiento_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPacienteFechaNacimiento_Enabled), 5, 0)));
         edtPacienteFechaIngreso_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPacienteFechaIngreso_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPacienteFechaIngreso_Enabled), 5, 0)));
         edtPacienteCI_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPacienteCI_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPacienteCI_Enabled), 5, 0)));
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

      protected void ResetCaption040( )
      {
      }

      protected void E11042( )
      {
         /* Start Routine */
      }

      protected void E12042( )
      {
         /* After Trn Routine */
      }

      protected void ZM044( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               Z36PacienteApellido = T00043_A36PacienteApellido[0] ;
               Z35PacienteNombre = T00043_A35PacienteNombre[0] ;
               Z37PacienteDomicilio = T00043_A37PacienteDomicilio[0] ;
               Z38PacienteEstadoCivil = T00043_A38PacienteEstadoCivil[0] ;
               Z39PacienteFechaNacimiento = T00043_A39PacienteFechaNacimiento[0] ;
               Z40PacienteFechaIngreso = T00043_A40PacienteFechaIngreso[0] ;
               Z41PacienteCI = T00043_A41PacienteCI[0] ;
            }
            else
            {
               Z36PacienteApellido = A36PacienteApellido ;
               Z35PacienteNombre = A35PacienteNombre ;
               Z37PacienteDomicilio = A37PacienteDomicilio ;
               Z38PacienteEstadoCivil = A38PacienteEstadoCivil ;
               Z39PacienteFechaNacimiento = A39PacienteFechaNacimiento ;
               Z40PacienteFechaIngreso = A40PacienteFechaIngreso ;
               Z41PacienteCI = A41PacienteCI ;
            }
         }
         if ( GX_JID == -8 )
         {
            Z34PacienteId = A34PacienteId ;
            Z36PacienteApellido = A36PacienteApellido ;
            Z35PacienteNombre = A35PacienteNombre ;
            Z37PacienteDomicilio = A37PacienteDomicilio ;
            Z38PacienteEstadoCivil = A38PacienteEstadoCivil ;
            Z39PacienteFechaNacimiento = A39PacienteFechaNacimiento ;
            Z40PacienteFechaIngreso = A40PacienteFechaIngreso ;
            Z41PacienteCI = A41PacienteCI ;
         }
      }

      protected void standaloneNotModal( )
      {
         edtPacienteId_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPacienteId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPacienteId_Enabled), 5, 0)));
         edtPacienteId_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPacienteId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPacienteId_Enabled), 5, 0)));
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
      }

      protected void Load044( )
      {
         /* Using cursor T00044 */
         pr_default.execute(2, new Object[] {A34PacienteId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound4 = 1 ;
            A36PacienteApellido = T00044_A36PacienteApellido[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A36PacienteApellido", A36PacienteApellido);
            A35PacienteNombre = T00044_A35PacienteNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A35PacienteNombre", A35PacienteNombre);
            A37PacienteDomicilio = T00044_A37PacienteDomicilio[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A37PacienteDomicilio", A37PacienteDomicilio);
            A38PacienteEstadoCivil = T00044_A38PacienteEstadoCivil[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A38PacienteEstadoCivil", A38PacienteEstadoCivil);
            A39PacienteFechaNacimiento = T00044_A39PacienteFechaNacimiento[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A39PacienteFechaNacimiento", context.localUtil.Format(A39PacienteFechaNacimiento, "99/99/99"));
            A40PacienteFechaIngreso = T00044_A40PacienteFechaIngreso[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A40PacienteFechaIngreso", context.localUtil.Format(A40PacienteFechaIngreso, "99/99/99"));
            A41PacienteCI = T00044_A41PacienteCI[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
            ZM044( -8) ;
         }
         pr_default.close(2);
         OnLoadActions044( ) ;
      }

      protected void OnLoadActions044( )
      {
         GXt_char2 = AV7Validacion ;
         new pchkci(context ).execute( ref  A41PacienteCI, ref  GXt_char2) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
         AV7Validacion = GXt_char2 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7Validacion", AV7Validacion);
      }

      protected void CheckExtendedTable044( )
      {
         Gx_BScreen = 1 ;
         standaloneModal( ) ;
         /* Using cursor T00045 */
         pr_default.execute(3, new Object[] {A41PacienteCI, A34PacienteId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Paciente CI"}), 1, "PACIENTECI");
            AnyError = 1 ;
            GX_FocusControl = edtPacienteCI_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A38PacienteEstadoCivil, "S") == 0 ) || ( StringUtil.StrCmp(A38PacienteEstadoCivil, "C") == 0 ) || ( StringUtil.StrCmp(A38PacienteEstadoCivil, "V") == 0 ) || ( StringUtil.StrCmp(A38PacienteEstadoCivil, "D") == 0 ) ) )
         {
            GX_msglist.addItem("Campo Paciente Estado Civil fuera de rango", "OutOfRange", 1, "");
            AnyError = 1 ;
         }
         if ( ! ( (DateTime.MinValue==A39PacienteFechaNacimiento) || ( A39PacienteFechaNacimiento >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Paciente Fecha Nacimiento fuera de rango", "OutOfRange", 1, "");
            AnyError = 1 ;
         }
         if ( A40PacienteFechaIngreso < A39PacienteFechaNacimiento )
         {
            GX_msglist.addItem("La fecha de ingreso no puede ser anterior a la fecha de nacimiento", 1, "");
            AnyError = 1 ;
         }
         if ( ! ( (DateTime.MinValue==A40PacienteFechaIngreso) || ( A40PacienteFechaIngreso >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Paciente Fecha Ingreso fuera de rango", "OutOfRange", 1, "");
            AnyError = 1 ;
         }
         GXt_char2 = AV7Validacion ;
         new pchkci(context ).execute( ref  A41PacienteCI, ref  GXt_char2) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
         AV7Validacion = GXt_char2 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7Validacion", AV7Validacion);
         if ( StringUtil.StrCmp(AV7Validacion, "N") == 0 )
         {
            GX_msglist.addItem("Número de C.I. incorrecto", 1, "");
            AnyError = 1 ;
         }
      }

      protected void CloseExtendedTableCursors044( )
      {
      }

      protected void enableDisable( )
      {
         if ( IsConfirmed == 0 )
         {
            imgBtn_delete2_Enabled = RcdFound4 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_delete2_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_delete2_Enabled), 5, 0)));
         }
         else
         {
            imgBtn_delete2_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_delete2_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_delete2_Enabled), 5, 0)));
         }
      }

      protected void GetKey044( )
      {
         /* Using cursor T00046 */
         pr_default.execute(4, new Object[] {A34PacienteId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound4 = 1 ;
         }
         else
         {
            RcdFound4 = 0 ;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00043 */
         pr_default.execute(1, new Object[] {A34PacienteId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM044( 8) ;
            RcdFound4 = 1 ;
            A34PacienteId = T00043_A34PacienteId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
            A36PacienteApellido = T00043_A36PacienteApellido[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A36PacienteApellido", A36PacienteApellido);
            A35PacienteNombre = T00043_A35PacienteNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A35PacienteNombre", A35PacienteNombre);
            A37PacienteDomicilio = T00043_A37PacienteDomicilio[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A37PacienteDomicilio", A37PacienteDomicilio);
            A38PacienteEstadoCivil = T00043_A38PacienteEstadoCivil[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A38PacienteEstadoCivil", A38PacienteEstadoCivil);
            A39PacienteFechaNacimiento = T00043_A39PacienteFechaNacimiento[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A39PacienteFechaNacimiento", context.localUtil.Format(A39PacienteFechaNacimiento, "99/99/99"));
            A40PacienteFechaIngreso = T00043_A40PacienteFechaIngreso[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A40PacienteFechaIngreso", context.localUtil.Format(A40PacienteFechaIngreso, "99/99/99"));
            A41PacienteCI = T00043_A41PacienteCI[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
            Z34PacienteId = A34PacienteId ;
            sMode4 = Gx_mode ;
            Gx_mode = "DSP" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load044( ) ;
            Gx_mode = sMode4 ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound4 = 0 ;
            InitializeNonKey044( ) ;
            sMode4 = Gx_mode ;
            Gx_mode = "DSP" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode4 ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey044( ) ;
         if ( RcdFound4 == 0 )
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
         RcdFound4 = 0 ;
         /* Using cursor T00047 */
         pr_default.execute(5, new Object[] {A34PacienteId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00047_A34PacienteId[0] < A34PacienteId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00047_A34PacienteId[0] > A34PacienteId ) ) )
            {
               A34PacienteId = T00047_A34PacienteId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
               RcdFound4 = 1 ;
            }
         }
         pr_default.close(1);
      }

      protected void move_previous( )
      {
         RcdFound4 = 0 ;
         /* Using cursor T00048 */
         pr_default.execute(6, new Object[] {A34PacienteId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00048_A34PacienteId[0] > A34PacienteId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00048_A34PacienteId[0] < A34PacienteId ) ) )
            {
               A34PacienteId = T00048_A34PacienteId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
               RcdFound4 = 1 ;
            }
         }
         pr_default.close(0);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1 ;
         GetKey044( ) ;
         if ( RcdFound4 == 1 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate"), "DuplicatePrimaryKey", 1, "PACIENTEID");
               AnyError = 1 ;
            }
            else if ( A34PacienteId != Z34PacienteId )
            {
               A34PacienteId = Z34PacienteId ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd"), "CandidateKeyNotFound", 1, "PACIENTEID");
               AnyError = 1 ;
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               delete( ) ;
               AfterTrn( ) ;
               GX_FocusControl = edtPacienteApellido_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else
            {
               Gx_mode = "UPD" ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
               /* Update record */
               Update044( ) ;
               GX_FocusControl = edtPacienteApellido_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( A34PacienteId != Z34PacienteId )
            {
               Gx_mode = "INS" ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
               /* Insert record */
               Insert044( ) ;
               GX_FocusControl = edtPacienteApellido_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted"), 1, "PACIENTEID");
                  AnyError = 1 ;
               }
               else
               {
                  Gx_mode = "INS" ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  Insert044( ) ;
                  GX_FocusControl = edtPacienteApellido_Internalname ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A34PacienteId != Z34PacienteId )
         {
            A34PacienteId = Z34PacienteId ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt"), 1, "PACIENTEID");
            AnyError = 1 ;
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPacienteApellido_Internalname ;
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
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound"), "PrimaryKeyNotFound", 1, "PACIENTEID");
            AnyError = 1 ;
         }
         GX_FocusControl = edtPacienteApellido_Internalname ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2 ;
         IsConfirmed = 0 ;
         ScanStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow"), 0, "");
         }
         else
         {
            Gx_mode = "UPD" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPacienteApellido_Internalname ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd044( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2 ;
         IsConfirmed = 0 ;
         move_previous( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow"), 0, "");
         }
         else
         {
            Gx_mode = "UPD" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPacienteApellido_Internalname ;
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
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow"), 0, "");
         }
         else
         {
            Gx_mode = "UPD" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPacienteApellido_Internalname ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2 ;
         IsConfirmed = 0 ;
         ScanStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow"), 0, "");
         }
         else
         {
            while ( RcdFound4 != 0 )
            {
               ScanNext044( ) ;
            }
            Gx_mode = "UPD" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPacienteApellido_Internalname ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd044( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency044( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            /* Using cursor T00049 */
            pr_default.execute(7, new Object[] {A34PacienteId});
            if ( (pr_default.getStatus(7) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Paciente"}), "RecordIsLocked", 1, "");
               AnyError = 1 ;
               return  ;
            }
            Gx_longc = false ;
            if ( (pr_default.getStatus(7) == 101) || ( StringUtil.StrCmp(Z36PacienteApellido, T00049_A36PacienteApellido[0]) != 0 ) || ( StringUtil.StrCmp(Z35PacienteNombre, T00049_A35PacienteNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z37PacienteDomicilio, T00049_A37PacienteDomicilio[0]) != 0 ) || ( StringUtil.StrCmp(Z38PacienteEstadoCivil, T00049_A38PacienteEstadoCivil[0]) != 0 ) || ( Z39PacienteFechaNacimiento != T00049_A39PacienteFechaNacimiento[0] ) )
            {
               Gx_longc = true ;
            }
            if ( Gx_longc || ( Z40PacienteFechaIngreso != T00049_A40PacienteFechaIngreso[0] ) || ( StringUtil.StrCmp(Z41PacienteCI, T00049_A41PacienteCI[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Paciente"}), "RecordWasChanged", 1, "");
               AnyError = 1 ;
               return  ;
            }
         }
      }

      protected void Insert044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM044( 0) ;
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000410 */
                     pr_default.execute(8, new Object[] {A36PacienteApellido, A35PacienteNombre, A37PacienteDomicilio, A38PacienteEstadoCivil, A39PacienteFechaNacimiento, A40PacienteFechaIngreso, A41PacienteCI});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000411 */
                     pr_default.execute(9);
                     A34PacienteId = T000411_A34PacienteId[0] ;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
                     pr_default.close(9);
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           GX_msglist.addItem(context.GetMessage( "GXM_sucadded"), 0, "");
                           ResetCaption040( ) ;
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
               Load044( ) ;
            }
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void Update044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000412 */
                     pr_default.execute(10, new Object[] {A36PacienteApellido, A35PacienteNombre, A37PacienteDomicilio, A38PacienteEstadoCivil, A39PacienteFechaNacimiento, A40PacienteFechaIngreso, A41PacienteCI, A34PacienteId});
                     pr_default.close(10);
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Paciente"}), "RecordIsLocked", 1, "");
                        AnyError = 1 ;
                     }
                     DeferredUpdate044( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           GX_msglist.addItem(context.GetMessage( "GXM_sucupdated"), 0, "");
                           ResetCaption040( ) ;
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
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void DeferredUpdate044( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls044( ) ;
            AfterConfirm044( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete044( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000413 */
                  pr_default.execute(11, new Object[] {A34PacienteId});
                  pr_default.close(11);
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound4 == 0 )
                        {
                           InitAll044( ) ;
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
                        ResetCaption040( ) ;
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
         sMode4 = Gx_mode ;
         Gx_mode = "DLT" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         EndLevel044( ) ;
         Gx_mode = sMode4 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls044( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_char2 = AV7Validacion ;
            new pchkci(context ).execute( ref  A41PacienteCI, ref  GXt_char2) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
            AV7Validacion = GXt_char2 ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7Validacion", AV7Validacion);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000414 */
            pr_default.execute(12, new Object[] {A34PacienteId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Consulta Paciente"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1 ;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel044( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            pr_default.close(7);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete044( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(6);
            pr_default.close(5);
            context.CommitDataStores("Paciente");
            if ( AnyError == 0 )
            {
               ConfirmValues040( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1 ;
         }
         else
         {
            pr_default.close(6);
            pr_default.close(5);
            context.RollbackDataStores("Paciente");
         }
         IsModified = 0 ;
         if ( AnyError != 0 )
         {
            context.wjLoc = "" ;
            context.nUserReturn = 0 ;
         }
      }

      protected void ScanStart044( )
      {
         /* Using cursor T000415 */
         pr_default.execute(13);
         RcdFound4 = 0 ;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound4 = 1 ;
            A34PacienteId = T000415_A34PacienteId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext044( )
      {
         pr_default.readNext(13);
         RcdFound4 = 0 ;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound4 = 1 ;
            A34PacienteId = T000415_A34PacienteId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
         }
      }

      protected void ScanEnd044( )
      {
      }

      protected void AfterConfirm044( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert044( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate044( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete044( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete044( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate044( )
      {
         /* Before Validate Rules */
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues040( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" onsubmit=\"try{return gx.csv.validForm()}catch(e){return true;}\" name=\"MAINFORM\" method=\"post\" action=\""+formatLink("paciente.aspx") +"\" class=\""+"Form"+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
      }

      public override void RenderHtmlCloseForm( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         GxWebStd.gx_hidden_field( context, "Z34PacienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z34PacienteId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z36PacienteApellido", StringUtil.RTrim( Z36PacienteApellido));
         GxWebStd.gx_hidden_field( context, "Z35PacienteNombre", StringUtil.RTrim( Z35PacienteNombre));
         GxWebStd.gx_hidden_field( context, "Z37PacienteDomicilio", StringUtil.RTrim( Z37PacienteDomicilio));
         GxWebStd.gx_hidden_field( context, "Z38PacienteEstadoCivil", StringUtil.RTrim( Z38PacienteEstadoCivil));
         GxWebStd.gx_hidden_field( context, "Z39PacienteFechaNacimiento", context.localUtil.DToC( Z39PacienteFechaNacimiento, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z40PacienteFechaIngreso", context.localUtil.DToC( Z40PacienteFechaIngreso, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z41PacienteCI", StringUtil.RTrim( Z41PacienteCI));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "_VALIDACION", StringUtil.RTrim( AV7Validacion));
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
         return "Paciente" ;
      }

      public override String GetPgmdesc( )
      {
         return "Paciente" ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("paciente.aspx")  ;
      }

      protected void InitializeNonKey044( )
      {
         AV7Validacion = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7Validacion", AV7Validacion);
         A36PacienteApellido = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A36PacienteApellido", A36PacienteApellido);
         A35PacienteNombre = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A35PacienteNombre", A35PacienteNombre);
         A37PacienteDomicilio = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A37PacienteDomicilio", A37PacienteDomicilio);
         A38PacienteEstadoCivil = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A38PacienteEstadoCivil", A38PacienteEstadoCivil);
         A39PacienteFechaNacimiento = DateTime.MinValue ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A39PacienteFechaNacimiento", context.localUtil.Format(A39PacienteFechaNacimiento, "99/99/99"));
         A40PacienteFechaIngreso = DateTime.MinValue ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A40PacienteFechaIngreso", context.localUtil.Format(A40PacienteFechaIngreso, "99/99/99"));
         A41PacienteCI = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
      }

      protected void InitAll044( )
      {
         A34PacienteId = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
         InitializeNonKey044( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( Form.Jscriptsrc.Item(idxLst)), "?411054");
            idxLst = (int)(idxLst+1) ;
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?34981");
         context.AddJavascriptSource("paciente.js", "?411054");
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
         lblTextblockpacienteid_Internalname = "TEXTBLOCKPACIENTEID" ;
         edtPacienteId_Internalname = "PACIENTEID" ;
         lblTextblockpacienteapellido_Internalname = "TEXTBLOCKPACIENTEAPELLIDO" ;
         edtPacienteApellido_Internalname = "PACIENTEAPELLIDO" ;
         lblTextblockpacientenombre_Internalname = "TEXTBLOCKPACIENTENOMBRE" ;
         edtPacienteNombre_Internalname = "PACIENTENOMBRE" ;
         lblTextblockpacientedomicilio_Internalname = "TEXTBLOCKPACIENTEDOMICILIO" ;
         edtPacienteDomicilio_Internalname = "PACIENTEDOMICILIO" ;
         lblTextblockpacienteestadocivil_Internalname = "TEXTBLOCKPACIENTEESTADOCIVIL" ;
         cmbPacienteEstadoCivil_Internalname = "PACIENTEESTADOCIVIL" ;
         lblTextblockpacientefechanacimiento_Internalname = "TEXTBLOCKPACIENTEFECHANACIMIENTO" ;
         edtPacienteFechaNacimiento_Internalname = "PACIENTEFECHANACIMIENTO" ;
         lblTextblockpacientefechaingreso_Internalname = "TEXTBLOCKPACIENTEFECHAINGRESO" ;
         edtPacienteFechaIngreso_Internalname = "PACIENTEFECHAINGRESO" ;
         lblTextblockpacienteci_Internalname = "TEXTBLOCKPACIENTECI" ;
         edtPacienteCI_Internalname = "PACIENTECI" ;
         tblTable2_Internalname = "TABLE2" ;
         bttBtn_enter_Internalname = "BTN_ENTER" ;
         bttBtn_cancel_Internalname = "BTN_CANCEL" ;
         bttBtn_delete_Internalname = "BTN_DELETE" ;
         tblTable1_Internalname = "TABLE1" ;
         grpGroupdata_Internalname = "GROUPDATA" ;
         tblTablemain_Internalname = "TABLEMAIN" ;
         Form.Internalname = "FORM" ;
         Form.Headerrawhtml = "" ;
         Form.Background = "" ;
         Form.Backcolor = (int)(0xFFFFFF) ;
         Form.Caption = "Paciente" ;
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
         edtPacienteCI_Jsonclick = "" ;
         edtPacienteCI_Enabled = 1 ;
         edtPacienteFechaIngreso_Jsonclick = "" ;
         edtPacienteFechaIngreso_Enabled = 1 ;
         edtPacienteFechaNacimiento_Jsonclick = "" ;
         edtPacienteFechaNacimiento_Enabled = 1 ;
         cmbPacienteEstadoCivil_Jsonclick = "" ;
         cmbPacienteEstadoCivil.Enabled = 1 ;
         edtPacienteDomicilio_Jsonclick = "" ;
         edtPacienteDomicilio_Enabled = 1 ;
         edtPacienteNombre_Jsonclick = "" ;
         edtPacienteNombre_Enabled = 1 ;
         edtPacienteApellido_Jsonclick = "" ;
         edtPacienteApellido_Enabled = 1 ;
         edtPacienteId_Jsonclick = "" ;
         edtPacienteId_Enabled = 0 ;
         bttBtn_delete_Visible = 1 ;
         bttBtn_cancel_Visible = 1 ;
         bttBtn_enter_Visible = 1 ;
         context.GX_msglist.DisplayMode = 1 ;
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GX5ASAVALIDACION044( String A41PacienteCI )
      {
         GXt_char3 = AV7Validacion ;
         new pchkci(context ).execute( ref  A41PacienteCI, ref  GXt_char3) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
         AV7Validacion = GXt_char3 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7Validacion", AV7Validacion);
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( AV7Validacion))+"\"");
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
         GX_FocusControl = edtPacienteApellido_Internalname ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      public void Valid_Pacienteid( int GX_Parm1 ,
                                    String GX_Parm2 ,
                                    String GX_Parm3 ,
                                    String GX_Parm4 ,
                                    GXCombobox cmbGX_Parm5 ,
                                    DateTime GX_Parm6 ,
                                    DateTime GX_Parm7 ,
                                    String GX_Parm8 )
      {
         A34PacienteId = GX_Parm1 ;
         A36PacienteApellido = GX_Parm2 ;
         A35PacienteNombre = GX_Parm3 ;
         A37PacienteDomicilio = GX_Parm4 ;
         cmbPacienteEstadoCivil = cmbGX_Parm5 ;
         A38PacienteEstadoCivil = cmbPacienteEstadoCivil.CurrentValue ;
         cmbPacienteEstadoCivil.CurrentValue = A38PacienteEstadoCivil ;
         A39PacienteFechaNacimiento = GX_Parm6 ;
         A40PacienteFechaIngreso = GX_Parm7 ;
         A41PacienteCI = GX_Parm8 ;
         context.wbHandled = 1 ;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         dynload_actions( ) ;
         if ( AnyError == 1 )
         {
         }
         isValidOutput.Add((Object)(StringUtil.RTrim( A36PacienteApellido)));
         isValidOutput.Add((Object)(StringUtil.RTrim( A35PacienteNombre)));
         isValidOutput.Add((Object)(StringUtil.RTrim( A37PacienteDomicilio)));
         cmbPacienteEstadoCivil.CurrentValue = A38PacienteEstadoCivil ;
         isValidOutput.Add((Object)(cmbPacienteEstadoCivil));
         isValidOutput.Add((Object)(context.localUtil.Format(A39PacienteFechaNacimiento, "99/99/99")));
         isValidOutput.Add((Object)(context.localUtil.Format(A40PacienteFechaIngreso, "99/99/99")));
         isValidOutput.Add((Object)(StringUtil.RTrim( A41PacienteCI)));
         isValidOutput.Add((Object)(StringUtil.RTrim( AV7Validacion)));
         isValidOutput.Add((Object)(StringUtil.RTrim( Gx_mode)));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(Z34PacienteId), 6, 0, ",", ""))));
         isValidOutput.Add((Object)(StringUtil.RTrim( Z36PacienteApellido)));
         isValidOutput.Add((Object)(StringUtil.RTrim( Z35PacienteNombre)));
         isValidOutput.Add((Object)(StringUtil.RTrim( Z37PacienteDomicilio)));
         isValidOutput.Add((Object)(StringUtil.RTrim( Z38PacienteEstadoCivil)));
         isValidOutput.Add((Object)(context.localUtil.DToC( Z39PacienteFechaNacimiento, 0, "/")));
         isValidOutput.Add((Object)(context.localUtil.DToC( Z40PacienteFechaIngreso, 0, "/")));
         isValidOutput.Add((Object)(StringUtil.RTrim( Z41PacienteCI)));
         isValidOutput.Add((Object)(StringUtil.RTrim( ZV7Validacion)));
         isValidOutput.Add((Object)(imgBtn_enter2_Enabled));
         isValidOutput.Add((Object)(context.GX_msglist.ToJavascriptSource()));
         context.GX_webresponse.AddString(isValidOutput.ToJSonString());
      }

      public void Valid_Pacienteci( String GX_Parm1 ,
                                    int GX_Parm2 ,
                                    String GX_Parm3 )
      {
         A41PacienteCI = GX_Parm1 ;
         A34PacienteId = GX_Parm2 ;
         AV7Validacion = GX_Parm3 ;
         /* Using cursor T000416 */
         pr_default.execute(14, new Object[] {A41PacienteCI, A34PacienteId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Paciente CI"}), 1, "PACIENTECI");
            AnyError = 1 ;
            GX_FocusControl = edtPacienteCI_Internalname ;
         }
         pr_default.close(14);
         GXt_char3 = AV7Validacion ;
         new pchkci(context ).execute( ref  A41PacienteCI, ref  GXt_char3) ;
         AV7Validacion = GXt_char3 ;
         if ( StringUtil.StrCmp(AV7Validacion, "N") == 0 )
         {
            GX_msglist.addItem("Número de C.I. incorrecto", 1, "PACIENTECI");
            AnyError = 1 ;
            GX_FocusControl = edtPacienteCI_Internalname ;
         }
         dynload_actions( ) ;
         if ( AnyError == 1 )
         {
         }
         isValidOutput.Add((Object)(StringUtil.RTrim( AV7Validacion)));
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
         pr_default.close(13);
         pr_default.close(6);
         pr_default.close(5);
      }

      public override void initialize( )
      {
         sPrefix = "" ;
         scmdbuf = "" ;
         gxfirstwebparm = "" ;
         gxfirstwebparm_bkp = "" ;
         A41PacienteCI = "" ;
         A38PacienteEstadoCivil = "" ;
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
         lblTextblockpacienteid_Jsonclick = "" ;
         lblTextblockpacienteapellido_Jsonclick = "" ;
         A36PacienteApellido = "" ;
         lblTextblockpacientenombre_Jsonclick = "" ;
         A35PacienteNombre = "" ;
         lblTextblockpacientedomicilio_Jsonclick = "" ;
         A37PacienteDomicilio = "" ;
         lblTextblockpacienteestadocivil_Jsonclick = "" ;
         lblTextblockpacientefechanacimiento_Jsonclick = "" ;
         A39PacienteFechaNacimiento = DateTime.MinValue ;
         lblTextblockpacientefechaingreso_Jsonclick = "" ;
         A40PacienteFechaIngreso = DateTime.MinValue ;
         lblTextblockpacienteci_Jsonclick = "" ;
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
         Z36PacienteApellido = "" ;
         Z35PacienteNombre = "" ;
         Z37PacienteDomicilio = "" ;
         Z38PacienteEstadoCivil = "" ;
         Z39PacienteFechaNacimiento = DateTime.MinValue ;
         Z40PacienteFechaIngreso = DateTime.MinValue ;
         Z41PacienteCI = "" ;
         Gx_mode = "" ;
         AV7Validacion = "" ;
         sEvt = "" ;
         EvtGridId = "" ;
         EvtRowId = "" ;
         sEvtType = "" ;
         T00044_A34PacienteId = new int[1] ;
         T00044_A36PacienteApellido = new String[] {""} ;
         T00044_A35PacienteNombre = new String[] {""} ;
         T00044_A37PacienteDomicilio = new String[] {""} ;
         T00044_A38PacienteEstadoCivil = new String[] {""} ;
         T00044_A39PacienteFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         T00044_A40PacienteFechaIngreso = new DateTime[] {DateTime.MinValue} ;
         T00044_A41PacienteCI = new String[] {""} ;
         T00045_A41PacienteCI = new String[] {""} ;
         T00046_A34PacienteId = new int[1] ;
         T00043_A34PacienteId = new int[1] ;
         T00043_A36PacienteApellido = new String[] {""} ;
         T00043_A35PacienteNombre = new String[] {""} ;
         T00043_A37PacienteDomicilio = new String[] {""} ;
         T00043_A38PacienteEstadoCivil = new String[] {""} ;
         T00043_A39PacienteFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         T00043_A40PacienteFechaIngreso = new DateTime[] {DateTime.MinValue} ;
         T00043_A41PacienteCI = new String[] {""} ;
         sMode4 = "" ;
         T00047_A34PacienteId = new int[1] ;
         T00048_A34PacienteId = new int[1] ;
         T00049_A34PacienteId = new int[1] ;
         T00049_A36PacienteApellido = new String[] {""} ;
         T00049_A35PacienteNombre = new String[] {""} ;
         T00049_A37PacienteDomicilio = new String[] {""} ;
         T00049_A38PacienteEstadoCivil = new String[] {""} ;
         T00049_A39PacienteFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         T00049_A40PacienteFechaIngreso = new DateTime[] {DateTime.MinValue} ;
         T00049_A41PacienteCI = new String[] {""} ;
         T000411_A34PacienteId = new int[1] ;
         T000414_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T000414_A34PacienteId = new int[1] ;
         T000414_A12MedicoId = new int[1] ;
         T000414_A60TurnoId = new short[1] ;
         T000415_A34PacienteId = new int[1] ;
         sDynURL = "" ;
         FormProcess = "" ;
         GXt_char2 = "" ;
         GXt_char1 = "" ;
         ZV7Validacion = "" ;
         isValidOutput = new GxUnknownObjectCollection();
         T000416_A41PacienteCI = new String[] {""} ;
         GXt_char3 = "" ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.paciente__default(),
            new Object[][] {
                new Object[] {
               T00042_A34PacienteId, T00042_A36PacienteApellido, T00042_A35PacienteNombre, T00042_A37PacienteDomicilio, T00042_A38PacienteEstadoCivil, T00042_A39PacienteFechaNacimiento, T00042_A40PacienteFechaIngreso, T00042_A41PacienteCI
               }
               , new Object[] {
               T00043_A34PacienteId, T00043_A36PacienteApellido, T00043_A35PacienteNombre, T00043_A37PacienteDomicilio, T00043_A38PacienteEstadoCivil, T00043_A39PacienteFechaNacimiento, T00043_A40PacienteFechaIngreso, T00043_A41PacienteCI
               }
               , new Object[] {
               T00044_A34PacienteId, T00044_A36PacienteApellido, T00044_A35PacienteNombre, T00044_A37PacienteDomicilio, T00044_A38PacienteEstadoCivil, T00044_A39PacienteFechaNacimiento, T00044_A40PacienteFechaIngreso, T00044_A41PacienteCI
               }
               , new Object[] {
               T00045_A41PacienteCI
               }
               , new Object[] {
               T00046_A34PacienteId
               }
               , new Object[] {
               T00047_A34PacienteId
               }
               , new Object[] {
               T00048_A34PacienteId
               }
               , new Object[] {
               T00049_A34PacienteId, T00049_A36PacienteApellido, T00049_A35PacienteNombre, T00049_A37PacienteDomicilio, T00049_A38PacienteEstadoCivil, T00049_A39PacienteFechaNacimiento, T00049_A40PacienteFechaIngreso, T00049_A41PacienteCI
               }
               , new Object[] {
               }
               , new Object[] {
               T000411_A34PacienteId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000414_A43ConsultaFecha, T000414_A34PacienteId, T000414_A12MedicoId, T000414_A60TurnoId
               }
               , new Object[] {
               T000415_A34PacienteId
               }
               , new Object[] {
               T000416_A41PacienteCI
               }
            }
         );
      }

      private short RcdFound4 ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int A34PacienteId ;
      private int edtPacienteId_Enabled ;
      private int edtPacienteApellido_Enabled ;
      private int edtPacienteNombre_Enabled ;
      private int edtPacienteDomicilio_Enabled ;
      private int edtPacienteFechaNacimiento_Enabled ;
      private int edtPacienteFechaIngreso_Enabled ;
      private int edtPacienteCI_Enabled ;
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
      private int idxLst ;
      private String sPrefix ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String A41PacienteCI ;
      private String A38PacienteEstadoCivil ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String GX_FocusControl ;
      private String edtPacienteApellido_Internalname ;
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
      private String lblTextblockpacienteid_Internalname ;
      private String lblTextblockpacienteid_Jsonclick ;
      private String edtPacienteId_Internalname ;
      private String edtPacienteId_Jsonclick ;
      private String lblTextblockpacienteapellido_Internalname ;
      private String lblTextblockpacienteapellido_Jsonclick ;
      private String A36PacienteApellido ;
      private String edtPacienteApellido_Jsonclick ;
      private String lblTextblockpacientenombre_Internalname ;
      private String lblTextblockpacientenombre_Jsonclick ;
      private String edtPacienteNombre_Internalname ;
      private String A35PacienteNombre ;
      private String edtPacienteNombre_Jsonclick ;
      private String lblTextblockpacientedomicilio_Internalname ;
      private String lblTextblockpacientedomicilio_Jsonclick ;
      private String edtPacienteDomicilio_Internalname ;
      private String A37PacienteDomicilio ;
      private String edtPacienteDomicilio_Jsonclick ;
      private String lblTextblockpacienteestadocivil_Internalname ;
      private String lblTextblockpacienteestadocivil_Jsonclick ;
      private String cmbPacienteEstadoCivil_Internalname ;
      private String cmbPacienteEstadoCivil_Jsonclick ;
      private String lblTextblockpacientefechanacimiento_Internalname ;
      private String lblTextblockpacientefechanacimiento_Jsonclick ;
      private String edtPacienteFechaNacimiento_Internalname ;
      private String edtPacienteFechaNacimiento_Jsonclick ;
      private String lblTextblockpacientefechaingreso_Internalname ;
      private String lblTextblockpacientefechaingreso_Jsonclick ;
      private String edtPacienteFechaIngreso_Internalname ;
      private String edtPacienteFechaIngreso_Jsonclick ;
      private String lblTextblockpacienteci_Internalname ;
      private String lblTextblockpacienteci_Jsonclick ;
      private String edtPacienteCI_Internalname ;
      private String edtPacienteCI_Jsonclick ;
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
      private String Z36PacienteApellido ;
      private String Z35PacienteNombre ;
      private String Z37PacienteDomicilio ;
      private String Z38PacienteEstadoCivil ;
      private String Z41PacienteCI ;
      private String Gx_mode ;
      private String AV7Validacion ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String sMode4 ;
      private String sDynURL ;
      private String FormProcess ;
      private String GXt_char2 ;
      private String GXt_char1 ;
      private String ZV7Validacion ;
      private String GXt_char3 ;
      private DateTime A39PacienteFechaNacimiento ;
      private DateTime A40PacienteFechaIngreso ;
      private DateTime Z39PacienteFechaNacimiento ;
      private DateTime Z40PacienteFechaIngreso ;
      private bool entryPointCalled ;
      private bool wbErr ;
      private bool Gx_longc ;
      private GxUnknownObjectCollection isValidOutput ;
      private GXMasterPage MasterPageObj ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbPacienteEstadoCivil ;
      private IDataStoreProvider pr_default ;
      private int[] T00044_A34PacienteId ;
      private String[] T00044_A36PacienteApellido ;
      private String[] T00044_A35PacienteNombre ;
      private String[] T00044_A37PacienteDomicilio ;
      private String[] T00044_A38PacienteEstadoCivil ;
      private DateTime[] T00044_A39PacienteFechaNacimiento ;
      private DateTime[] T00044_A40PacienteFechaIngreso ;
      private String[] T00044_A41PacienteCI ;
      private String[] T00045_A41PacienteCI ;
      private int[] T00046_A34PacienteId ;
      private int[] T00043_A34PacienteId ;
      private String[] T00043_A36PacienteApellido ;
      private String[] T00043_A35PacienteNombre ;
      private String[] T00043_A37PacienteDomicilio ;
      private String[] T00043_A38PacienteEstadoCivil ;
      private DateTime[] T00043_A39PacienteFechaNacimiento ;
      private DateTime[] T00043_A40PacienteFechaIngreso ;
      private String[] T00043_A41PacienteCI ;
      private int[] T00047_A34PacienteId ;
      private int[] T00048_A34PacienteId ;
      private int[] T00049_A34PacienteId ;
      private String[] T00049_A36PacienteApellido ;
      private String[] T00049_A35PacienteNombre ;
      private String[] T00049_A37PacienteDomicilio ;
      private String[] T00049_A38PacienteEstadoCivil ;
      private DateTime[] T00049_A39PacienteFechaNacimiento ;
      private DateTime[] T00049_A40PacienteFechaIngreso ;
      private String[] T00049_A41PacienteCI ;
      private int[] T000411_A34PacienteId ;
      private DateTime[] T000414_A43ConsultaFecha ;
      private int[] T000414_A34PacienteId ;
      private int[] T000414_A12MedicoId ;
      private short[] T000414_A60TurnoId ;
      private int[] T000415_A34PacienteId ;
      private String[] T000416_A41PacienteCI ;
      private int[] T00042_A34PacienteId ;
      private String[] T00042_A36PacienteApellido ;
      private String[] T00042_A35PacienteNombre ;
      private String[] T00042_A37PacienteDomicilio ;
      private String[] T00042_A38PacienteEstadoCivil ;
      private DateTime[] T00042_A39PacienteFechaNacimiento ;
      private DateTime[] T00042_A40PacienteFechaIngreso ;
      private String[] T00042_A41PacienteCI ;
      private GXWebForm Form ;
   }

   public class paciente__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00042 ;
          prmT00042 = new Object[] {
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00044 ;
          prmT00044 = new Object[] {
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00045 ;
          prmT00045 = new Object[] {
          new Object[] {"@PacienteCI",SqlDbType.Char,8,0} ,
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00046 ;
          prmT00046 = new Object[] {
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00043 ;
          prmT00043 = new Object[] {
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00047 ;
          prmT00047 = new Object[] {
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00048 ;
          prmT00048 = new Object[] {
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00049 ;
          prmT00049 = new Object[] {
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000410 ;
          prmT000410 = new Object[] {
          new Object[] {"@PacienteApellido",SqlDbType.Char,20,0} ,
          new Object[] {"@PacienteNombre",SqlDbType.Char,20,0} ,
          new Object[] {"@PacienteDomicilio",SqlDbType.Char,40,0} ,
          new Object[] {"@PacienteEstadoCivil",SqlDbType.Char,1,0} ,
          new Object[] {"@PacienteFechaNacimiento",SqlDbType.DateTime,8,0} ,
          new Object[] {"@PacienteFechaIngreso",SqlDbType.DateTime,8,0} ,
          new Object[] {"@PacienteCI",SqlDbType.Char,8,0}
          } ;
          Object[] prmT000411 ;
          prmT000411 = new Object[] {
          } ;
          Object[] prmT000412 ;
          prmT000412 = new Object[] {
          new Object[] {"@PacienteApellido",SqlDbType.Char,20,0} ,
          new Object[] {"@PacienteNombre",SqlDbType.Char,20,0} ,
          new Object[] {"@PacienteDomicilio",SqlDbType.Char,40,0} ,
          new Object[] {"@PacienteEstadoCivil",SqlDbType.Char,1,0} ,
          new Object[] {"@PacienteFechaNacimiento",SqlDbType.DateTime,8,0} ,
          new Object[] {"@PacienteFechaIngreso",SqlDbType.DateTime,8,0} ,
          new Object[] {"@PacienteCI",SqlDbType.Char,8,0} ,
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000413 ;
          prmT000413 = new Object[] {
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000414 ;
          prmT000414 = new Object[] {
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000415 ;
          prmT000415 = new Object[] {
          } ;
          Object[] prmT000416 ;
          prmT000416 = new Object[] {
          new Object[] {"@PacienteCI",SqlDbType.Char,8,0} ,
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("T00042", "SELECT [PacienteId], [PacienteApellido], [PacienteNombre], [PacienteDomicilio], [PacienteEstadoCivil], [PacienteFechaNacimiento], [PacienteFechaIngreso], [PacienteCI] FROM [Paciente] WITH (UPDLOCK) WHERE [PacienteId] = @PacienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00042,1,0,true,false )
             ,new CursorDef("T00043", "SELECT [PacienteId], [PacienteApellido], [PacienteNombre], [PacienteDomicilio], [PacienteEstadoCivil], [PacienteFechaNacimiento], [PacienteFechaIngreso], [PacienteCI] FROM [Paciente] WITH (NOLOCK) WHERE [PacienteId] = @PacienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00043,1,0,true,false )
             ,new CursorDef("T00044", "SELECT TM1.[PacienteId], TM1.[PacienteApellido], TM1.[PacienteNombre], TM1.[PacienteDomicilio], TM1.[PacienteEstadoCivil], TM1.[PacienteFechaNacimiento], TM1.[PacienteFechaIngreso], TM1.[PacienteCI] FROM [Paciente] TM1 WITH (NOLOCK) WHERE TM1.[PacienteId] = @PacienteId ORDER BY TM1.[PacienteId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00044,100,0,true,false )
             ,new CursorDef("T00045", "SELECT [PacienteCI] FROM [Paciente] WITH (NOLOCK) WHERE ([PacienteCI] = @PacienteCI) AND (Not ( [PacienteId] = @PacienteId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT00045,1,0,true,false )
             ,new CursorDef("T00046", "SELECT [PacienteId] FROM [Paciente] WITH (NOLOCK) WHERE [PacienteId] = @PacienteId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00046,1,0,true,false )
             ,new CursorDef("T00047", "SELECT TOP 1 [PacienteId] FROM [Paciente] WITH (NOLOCK) WHERE ( [PacienteId] > @PacienteId) ORDER BY [PacienteId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00047,1,0,true,true )
             ,new CursorDef("T00048", "SELECT TOP 1 [PacienteId] FROM [Paciente] WITH (NOLOCK) WHERE ( [PacienteId] < @PacienteId) ORDER BY [PacienteId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00048,1,0,true,true )
             ,new CursorDef("T00049", "SELECT [PacienteId], [PacienteApellido], [PacienteNombre], [PacienteDomicilio], [PacienteEstadoCivil], [PacienteFechaNacimiento], [PacienteFechaIngreso], [PacienteCI] FROM [Paciente] WITH (UPDLOCK) WHERE [PacienteId] = @PacienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00049,1,0,true,false )
             ,new CursorDef("T000410", "INSERT INTO [Paciente] ([PacienteApellido], [PacienteNombre], [PacienteDomicilio], [PacienteEstadoCivil], [PacienteFechaNacimiento], [PacienteFechaIngreso], [PacienteCI]) VALUES (@PacienteApellido, @PacienteNombre, @PacienteDomicilio, @PacienteEstadoCivil, @PacienteFechaNacimiento, @PacienteFechaIngreso, @PacienteCI)", GxErrorMask.GX_NOMASK,prmT000410)
             ,new CursorDef("T000411", "SELECT Ident_Current('[Paciente]') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000411,1,0,true,false )
             ,new CursorDef("T000412", "UPDATE [Paciente] SET [PacienteApellido]=@PacienteApellido, [PacienteNombre]=@PacienteNombre, [PacienteDomicilio]=@PacienteDomicilio, [PacienteEstadoCivil]=@PacienteEstadoCivil, [PacienteFechaNacimiento]=@PacienteFechaNacimiento, [PacienteFechaIngreso]=@PacienteFechaIngreso, [PacienteCI]=@PacienteCI  WHERE [PacienteId] = @PacienteId", GxErrorMask.GX_NOMASK,prmT000412)
             ,new CursorDef("T000413", "DELETE FROM [Paciente]  WHERE [PacienteId] = @PacienteId", GxErrorMask.GX_NOMASK,prmT000413)
             ,new CursorDef("T000414", "SELECT TOP 1 [ConsultaFecha], [PacienteId], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) WHERE [PacienteId] = @PacienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000414,1,0,true,true )
             ,new CursorDef("T000415", "SELECT [PacienteId] FROM [Paciente] WITH (NOLOCK) ORDER BY [PacienteId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000415,100,0,true,false )
             ,new CursorDef("T000416", "SELECT [PacienteCI] FROM [Paciente] WITH (NOLOCK) WHERE ([PacienteCI] = @PacienteCI) AND (Not ( [PacienteId] = @PacienteId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000416,1,0,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                ((String[]) buf[3])[0] = rslt.getString(4, 40) ;
                ((String[]) buf[4])[0] = rslt.getString(5, 1) ;
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6) ;
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7) ;
                ((String[]) buf[7])[0] = rslt.getString(8, 8) ;
                break;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                ((String[]) buf[3])[0] = rslt.getString(4, 40) ;
                ((String[]) buf[4])[0] = rslt.getString(5, 1) ;
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6) ;
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7) ;
                ((String[]) buf[7])[0] = rslt.getString(8, 8) ;
                break;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                ((String[]) buf[3])[0] = rslt.getString(4, 40) ;
                ((String[]) buf[4])[0] = rslt.getString(5, 1) ;
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6) ;
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7) ;
                ((String[]) buf[7])[0] = rslt.getString(8, 8) ;
                break;
             case 3 :
                ((String[]) buf[0])[0] = rslt.getString(1, 8) ;
                break;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                break;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                break;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                break;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                ((String[]) buf[3])[0] = rslt.getString(4, 40) ;
                ((String[]) buf[4])[0] = rslt.getString(5, 1) ;
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6) ;
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7) ;
                ((String[]) buf[7])[0] = rslt.getString(8, 8) ;
                break;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                break;
             case 12 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                ((short[]) buf[3])[0] = rslt.getShort(4) ;
                break;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                break;
             case 14 :
                ((String[]) buf[0])[0] = rslt.getString(1, 8) ;
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
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 1 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 2 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 3 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                break;
             case 4 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 5 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 6 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 7 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 8 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (String)parms[2]);
                stmt.SetParameter(4, (String)parms[3]);
                stmt.SetParameter(5, (DateTime)parms[4]);
                stmt.SetParameter(6, (DateTime)parms[5]);
                stmt.SetParameter(7, (String)parms[6]);
                break;
             case 10 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (String)parms[2]);
                stmt.SetParameter(4, (String)parms[3]);
                stmt.SetParameter(5, (DateTime)parms[4]);
                stmt.SetParameter(6, (DateTime)parms[5]);
                stmt.SetParameter(7, (String)parms[6]);
                stmt.SetParameter(8, (int)parms[7]);
                break;
             case 11 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 12 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 14 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                break;
       }
    }

 }

}
