/*
               File: Medico
        Description: Médico
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/22/2010 4:1:1.78
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
   public class medico : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A9EspecialidadId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            gxLoad_7( A9EspecialidadId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A46EnfermeroTitularId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A46EnfermeroTitularId", StringUtil.LTrim( StringUtil.Str( (decimal)(A46EnfermeroTitularId), 6, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            gxLoad_8( A46EnfermeroTitularId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A51EnfermeroSuplenteId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A51EnfermeroSuplenteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A51EnfermeroSuplenteId), 6, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1 ;
               return  ;
            }
            gxLoad_9( A51EnfermeroSuplenteId) ;
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
         cmbMedicoEstadoCivil.Name = "MEDICOESTADOCIVIL" ;
         cmbMedicoEstadoCivil.WebTags = "" ;
         cmbMedicoEstadoCivil.addItem("S", "Soltero", 0);
         cmbMedicoEstadoCivil.addItem("C", "Casado", 0);
         cmbMedicoEstadoCivil.addItem("V", "Viudo", 0);
         cmbMedicoEstadoCivil.addItem("D", "Divorciado", 0);
         if ( ( cmbMedicoEstadoCivil.ItemCount > 0 ) && String.IsNullOrEmpty(StringUtil.RTrim( A17MedicoEstadoCivil)) )
         {
            A17MedicoEstadoCivil = cmbMedicoEstadoCivil.getItemValue(1) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A17MedicoEstadoCivil", A17MedicoEstadoCivil);
         }
         Form.Meta.addItem("Generator", "GeneXus C#", 0) ;
         Form.Meta.addItem("Version", "10_1_3-34981", 0) ;
         Form.Meta.addItem("Description", "Médico", 0) ;
         context.wjLoc = "" ;
         context.nUserReturn = 0 ;
         context.wbHandled = 0 ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         GX_FocusControl = edtMedicoNombre_Internalname ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         wbErr = false ;
         context.SetTheme("GeneXusX");
      }

      public medico( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public medico( IGxContext context )
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
         cmbMedicoEstadoCivil = new GXCombobox();
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
            wb_table1_2_011( true) ;
         }
         return  ;
      }

      protected void wb_table1_2_011e( bool wbgen )
      {
         if ( wbgen )
         {
         }
         /* Execute Exit event if defined. */
      }

      protected void wb_table1_2_011( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTablemain_Internalname, tblTablemain_Internalname, "", "TableBorder100x100", 0, "", "", 1, 2, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_5_011( true) ;
         }
         return  ;
      }

      protected void wb_table2_5_011e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Control Group */
            ClassString = "Group" ;
            StyleString = "" ;
            context.WriteHtmlText( "<fieldset id=\""+grpGroupdata_Internalname+"\""+" style=\"-moz-border-radius:3pt;\""+" class=\""+ClassString+"\">") ;
            context.WriteHtmlText( "<legend class=\""+ClassString+"Title"+"\">"+"Médico"+"</legend>") ;
            wb_table3_27_011( true) ;
         }
         return  ;
      }

      protected void wb_table3_27_011e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</fieldset>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_2_011e( true) ;
         }
         else
         {
            wb_table1_2_011e( false) ;
         }
      }

      protected void wb_table3_27_011( bool wbgen )
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
            wb_table4_33_011( true) ;
         }
         return  ;
      }

      protected void wb_table4_33_011e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"" ;
            ClassString = "BtnEnter" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtn_enter_Internalname, "Confirmar", "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, 1, "rounded", 5, bttBtn_enter_Jsonclick, "EENTER.", TempTags, "", "", "HLP_Medico.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"" ;
            ClassString = "BtnCancel" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtn_cancel_Internalname, "Cancelar", "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "rounded", 1, bttBtn_cancel_Jsonclick, "ECANCEL.", TempTags, "", "", "HLP_Medico.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"" ;
            ClassString = "BtnDelete" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtn_delete_Internalname, "Eliminar", "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, 1, "rounded", 5, bttBtn_delete_Jsonclick, "EDELETE.", TempTags, "", "", "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_27_011e( true) ;
         }
         else
         {
            wb_table3_27_011e( false) ;
         }
      }

      protected void wb_table4_33_011( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblTextblockmedicoid_Internalname, 1, 1, 0, "Id", "", "", "", 0, lblTextblockmedicoid_Jsonclick, "", StyleString, ClassString, "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtMedicoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12MedicoId), 6, 0, ",", "")), "", 6, "chr", 1, "row", 6, 1, edtMedicoId_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A12MedicoId), "ZZZZZ9"), "", 0, edtMedicoId_Jsonclick, "", 0, 1, -1, true, "right", "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockmediconombre_Internalname, 1, 1, 0, "Nombre", "", "", "", 0, lblTextblockmediconombre_Jsonclick, "", StyleString, ClassString, "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtMedicoNombre_Internalname, StringUtil.RTrim( A13MedicoNombre), "", 20, "chr", 1, "row", 20, 1, edtMedicoNombre_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A13MedicoNombre, "XXXXXXXXXXXXXXXXXXXX")), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(43);\"", 0, edtMedicoNombre_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockmedicoapellido_Internalname, 1, 1, 0, "Apellido", "", "", "", 0, lblTextblockmedicoapellido_Jsonclick, "", StyleString, ClassString, "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtMedicoApellido_Internalname, StringUtil.RTrim( A14MedicoApellido), "", 20, "chr", 1, "row", 20, 1, edtMedicoApellido_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A14MedicoApellido, "XXXXXXXXXXXXXXXXXXXX")), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(48);\"", 0, edtMedicoApellido_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockmedicodomicilio_Internalname, 1, 1, 0, "Domicilio", "", "", "", 0, lblTextblockmedicodomicilio_Jsonclick, "", StyleString, ClassString, "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtMedicoDomicilio_Internalname, StringUtil.RTrim( A15MedicoDomicilio), "", 40, "chr", 1, "row", 40, 1, edtMedicoDomicilio_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A15MedicoDomicilio, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(53);\"", 0, edtMedicoDomicilio_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockmedicotelefono_Internalname, 1, 1, 0, "Telefono", "", "", "", 0, lblTextblockmedicotelefono_Jsonclick, "", StyleString, ClassString, "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtMedicoTelefono_Internalname, StringUtil.RTrim( A16MedicoTelefono), "", 20, "chr", 1, "row", 20, 1, edtMedicoTelefono_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A16MedicoTelefono, "XXXXXXXXXXXXXXXXXXXX")), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(58);\"", 0, edtMedicoTelefono_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockmedicoestadocivil_Internalname, 1, 1, 0, "Estado Civil", "", "", "", 0, lblTextblockmedicoestadocivil_Jsonclick, "", StyleString, ClassString, "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"" ;
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbMedicoEstadoCivil, cmbMedicoEstadoCivil_Internalname, A17MedicoEstadoCivil, "", "char", 1, cmbMedicoEstadoCivil.Enabled, 0, 1, 0, 1, "chr", 0, "", StyleString, ClassString, "", 0, cmbMedicoEstadoCivil_Jsonclick, "", TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(63);\"", true, "HLP_Medico.htm");
            cmbMedicoEstadoCivil.CurrentValue = A17MedicoEstadoCivil ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, cmbMedicoEstadoCivil_Internalname, "Values", (String)(cmbMedicoEstadoCivil.ToJavascriptSource()));
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockmedicofechaingreso_Internalname, 1, 1, 0, "Fecha Ingreso", "", "", "", 0, lblTextblockmedicofechaingreso_Jsonclick, "", StyleString, ClassString, "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            if ( ( edtMedicoFechaIngreso_Enabled == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlText( "<table id=\""+edtMedicoFechaIngreso_Internalname+"_dp_container\" cellpadding=\"0\" cellspacing=\"0\"><tr><td>") ;
            }
            GxWebStd.gx_single_line_edit( context, edtMedicoFechaIngreso_Internalname, context.localUtil.Format(A18MedicoFechaIngreso, "99/99/99"), "", 8, "chr", 1, "row", 8, 1, edtMedicoFechaIngreso_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( A18MedicoFechaIngreso, "99/99/99"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(68);\"", 0, edtMedicoFechaIngreso_Jsonclick, "", 0, 1, -1, true, "right", "HLP_Medico.htm");
            if ( ( edtMedicoFechaIngreso_Enabled == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlTextNl( "</td><td>") ;
               context.WriteHtmlText( "<img src=\""+context.convertURL( "calendar-img.gif")+"\" id=\""+edtMedicoFechaIngreso_Internalname+"_dp_trigger\" style=\"cursor: pointer;\" title=\"Date selector\" alt=\"Date selector\" >") ;
               context.WriteHtmlTextNl( "</td></tr></table>") ;
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockespecialidadid_Internalname, 1, 1, 0, "Especialidad Id", "", "", "", 0, lblTextblockespecialidadid_Jsonclick, "", StyleString, ClassString, "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtEspecialidadId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9EspecialidadId), 6, 0, ",", "")), "", 6, "chr", 1, "row", 6, 1, edtEspecialidadId_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A9EspecialidadId), "ZZZZZ9"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(73);\"", 0, edtEspecialidadId_Jsonclick, "", 0, 1, -1, true, "right", "HLP_Medico.htm");
            /* Static images/pictures */
            ClassString = "Image" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgprompt_9_Internalname, "", "prompt.gif", "GeneXusX", imgprompt_9_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, imgprompt_9_Link, "", 0, "", "", StyleString, ClassString, "", "", "''", "", "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockespecialidaddescripcion_Internalname, 1, 1, 0, "Especialidad Descripcion", "", "", "", 0, lblTextblockespecialidaddescripcion_Jsonclick, "", StyleString, ClassString, "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtEspecialidadDescripcion_Internalname, StringUtil.RTrim( A10EspecialidadDescripcion), "", 20, "chr", 1, "row", 20, 1, edtEspecialidadDescripcion_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A10EspecialidadDescripcion, "XXXXXXXXXXXXXXXXXXXX")), "", 0, edtEspecialidadDescripcion_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockenfermerotitularid_Internalname, 1, 1, 0, "Titular Id", "", "", "", 0, lblTextblockenfermerotitularid_Jsonclick, "", StyleString, ClassString, "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtEnfermeroTitularId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A46EnfermeroTitularId), 6, 0, ",", "")), "", 6, "chr", 1, "row", 6, 1, edtEnfermeroTitularId_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A46EnfermeroTitularId), "ZZZZZ9"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(83);\"", 0, edtEnfermeroTitularId_Jsonclick, "", 0, 1, -1, true, "right", "HLP_Medico.htm");
            /* Static images/pictures */
            ClassString = "Image" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgprompt_46_Internalname, "", "prompt.gif", "GeneXusX", imgprompt_46_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, imgprompt_46_Link, "", 0, "", "", StyleString, ClassString, "", "", "''", "", "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockenfermerotitularnombre_Internalname, 1, 1, 0, "Titular Nombre", "", "", "", 0, lblTextblockenfermerotitularnombre_Jsonclick, "", StyleString, ClassString, "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtEnfermeroTitularNombre_Internalname, StringUtil.RTrim( A47EnfermeroTitularNombre), "", 20, "chr", 1, "row", 20, 1, edtEnfermeroTitularNombre_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A47EnfermeroTitularNombre, "XXXXXXXXXXXXXXXXXXXX")), "", 0, edtEnfermeroTitularNombre_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockenfermerotitularapellido_Internalname, 1, 1, 0, "Titular Apellido", "", "", "", 0, lblTextblockenfermerotitularapellido_Jsonclick, "", StyleString, ClassString, "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtEnfermeroTitularApellido_Internalname, StringUtil.RTrim( A48EnfermeroTitularApellido), "", 20, "chr", 1, "row", 20, 1, edtEnfermeroTitularApellido_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A48EnfermeroTitularApellido, "XXXXXXXXXXXXXXXXXXXX")), "", 0, edtEnfermeroTitularApellido_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockenfermerosuplenteid_Internalname, 1, 1, 0, "Suplente Id", "", "", "", 0, lblTextblockenfermerosuplenteid_Jsonclick, "", StyleString, ClassString, "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtEnfermeroSuplenteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A51EnfermeroSuplenteId), 6, 0, ",", "")), "", 6, "chr", 1, "row", 6, 1, edtEnfermeroSuplenteId_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A51EnfermeroSuplenteId), "ZZZZZ9"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(98);\"", 0, edtEnfermeroSuplenteId_Jsonclick, "", 0, 1, -1, true, "right", "HLP_Medico.htm");
            /* Static images/pictures */
            ClassString = "Image" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgprompt_51_Internalname, "", "prompt.gif", "GeneXusX", imgprompt_51_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, imgprompt_51_Link, "", 0, "", "", StyleString, ClassString, "", "", "''", "", "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockenfermerosuplentenombre_Internalname, 1, 1, 0, "Suplente Nombre", "", "", "", 0, lblTextblockenfermerosuplentenombre_Jsonclick, "", StyleString, ClassString, "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtEnfermeroSuplenteNombre_Internalname, StringUtil.RTrim( A52EnfermeroSuplenteNombre), "", 20, "chr", 1, "row", 20, 1, edtEnfermeroSuplenteNombre_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A52EnfermeroSuplenteNombre, "XXXXXXXXXXXXXXXXXXXX")), "", 0, edtEnfermeroSuplenteNombre_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockenfermerosuplenteapellido_Internalname, 1, 1, 0, "Suplente Apellido", "", "", "", 0, lblTextblockenfermerosuplenteapellido_Jsonclick, "", StyleString, ClassString, "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtEnfermeroSuplenteApellido_Internalname, StringUtil.RTrim( A56EnfermeroSuplenteApellido), "", 20, "chr", 1, "row", 20, 1, edtEnfermeroSuplenteApellido_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A56EnfermeroSuplenteApellido, "XXXXXXXXXXXXXXXXXXXX")), "", 0, edtEnfermeroSuplenteApellido_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Medico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_33_011e( true) ;
         }
         else
         {
            wb_table4_33_011e( false) ;
         }
      }

      protected void wb_table2_5_011( bool wbgen )
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
            GxWebStd.gx_bitmap( context, imgBtn_first_Internalname, "", context.GetImagePath( "b9e06284-17ac-4c88-8937-5dbd84ad5d80", "", "GeneXusX"), "GeneXusX", imgBtn_first_Visible, 1, "", "Primero", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_first_Jsonclick, "EFIRST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Medico.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_first_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_first_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_first_separator_Jsonclick, "EFIRST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Medico.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_previous_Internalname, "", context.GetImagePath( "7d212604-db7b-4785-9c0d-5faffe71aa33", "", "GeneXusX"), "GeneXusX", imgBtn_previous_Visible, 1, "", "Anterior", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_previous_Jsonclick, "EPREVIOUS.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Medico.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_previous_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_previous_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_previous_separator_Jsonclick, "EPREVIOUS.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Medico.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_next_Internalname, "", context.GetImagePath( "1ae947cf-1354-41a9-8d59-d91daebf554f", "", "GeneXusX"), "GeneXusX", imgBtn_next_Visible, 1, "", "Siguiente", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_next_Jsonclick, "ENEXT.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Medico.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_next_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_next_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_next_separator_Jsonclick, "ENEXT.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Medico.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_last_Internalname, "", context.GetImagePath( "29211874-e613-48e5-9011-8017d984217e", "", "GeneXusX"), "GeneXusX", imgBtn_last_Visible, 1, "", "Ultimo", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_last_Jsonclick, "ELAST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Medico.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_last_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_last_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_last_separator_Jsonclick, "ELAST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Medico.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_select_Internalname, "", context.GetImagePath( "1ca03f75-9947-4d2c-90a4-e8ab9c5cedea", "", "GeneXusX"), "GeneXusX", imgBtn_select_Visible, 1, "", "Seleccionar", 0, 0, 0, "", 0, "", 0, 0, "", "", 4, imgBtn_select_Jsonclick, "ESELECT.", StyleString, ClassString, "", ""+TempTags, "", "gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"MEDICOID"+"'), id:'"+"MEDICOID"+"'"+",isOut:true,isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", "HLP_Medico.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_select_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_select_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 4, imgBtn_select_separator_Jsonclick, "ESELECT.", StyleString, ClassString, "", ""+TempTags, "", "gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"MEDICOID"+"'), id:'"+"MEDICOID"+"'"+",isOut:true,isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", "HLP_Medico.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_enter2_Internalname, "", context.GetImagePath( "2061cf2c-bd33-4433-a13e-34af954142e9", "", "GeneXusX"), "GeneXusX", imgBtn_enter2_Visible, imgBtn_enter2_Enabled, "", "Confirmar", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_enter2_Jsonclick, "EENTER.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Medico.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_enter2_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_enter2_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_enter2_separator_Jsonclick, "EENTER.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Medico.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_cancel2_Internalname, "", context.GetImagePath( "0e94ced8-bc34-47ff-9a53-bc683736a686", "", "GeneXusX"), "GeneXusX", imgBtn_cancel2_Visible, 1, "", "Cancelar", 0, 0, 0, "", 0, "", 0, 0, "", "", 1, imgBtn_cancel2_Jsonclick, "ECANCEL.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Medico.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_cancel2_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_cancel2_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 1, imgBtn_cancel2_separator_Jsonclick, "ECANCEL.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Medico.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_delete2_Internalname, "", context.GetImagePath( "7695fe89-52c9-4b7e-871e-0e11548f823e", "", "GeneXusX"), "GeneXusX", imgBtn_delete2_Visible, imgBtn_delete2_Enabled, "", "Eliminar", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_delete2_Jsonclick, "EDELETE.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Medico.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_delete2_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_delete2_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_delete2_separator_Jsonclick, "EDELETE.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Medico.htm");
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
            wb_table2_5_011e( true) ;
         }
         else
         {
            wb_table2_5_011e( false) ;
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
               A12MedicoId = (int)(context.localUtil.CToN( cgiGet( edtMedicoId_Internalname), ",", ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
               A13MedicoNombre = cgiGet( edtMedicoNombre_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
               A14MedicoApellido = cgiGet( edtMedicoApellido_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
               A15MedicoDomicilio = cgiGet( edtMedicoDomicilio_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A15MedicoDomicilio", A15MedicoDomicilio);
               A16MedicoTelefono = cgiGet( edtMedicoTelefono_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A16MedicoTelefono", A16MedicoTelefono);
               cmbMedicoEstadoCivil.CurrentValue = cgiGet( cmbMedicoEstadoCivil_Internalname) ;
               A17MedicoEstadoCivil = cgiGet( cmbMedicoEstadoCivil_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A17MedicoEstadoCivil", A17MedicoEstadoCivil);
               if ( context.localUtil.VCDate( cgiGet( edtMedicoFechaIngreso_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Medico Fecha Ingreso"}), 1, "MEDICOFECHAINGRESO");
                  AnyError = 1 ;
                  GX_FocusControl = edtMedicoFechaIngreso_Internalname ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true ;
                  A18MedicoFechaIngreso = DateTime.MinValue ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A18MedicoFechaIngreso", context.localUtil.Format(A18MedicoFechaIngreso, "99/99/99"));
               }
               else
               {
                  A18MedicoFechaIngreso = context.localUtil.CToD( cgiGet( edtMedicoFechaIngreso_Internalname), 2) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A18MedicoFechaIngreso", context.localUtil.Format(A18MedicoFechaIngreso, "99/99/99"));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtEspecialidadId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEspecialidadId_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum"), 1, "ESPECIALIDADID");
                  AnyError = 1 ;
                  GX_FocusControl = edtEspecialidadId_Internalname ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true ;
                  A9EspecialidadId = 0 ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
               }
               else
               {
                  A9EspecialidadId = (int)(context.localUtil.CToN( cgiGet( edtEspecialidadId_Internalname), ",", ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
               }
               A10EspecialidadDescripcion = cgiGet( edtEspecialidadDescripcion_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10EspecialidadDescripcion", A10EspecialidadDescripcion);
               if ( ( ( context.localUtil.CToN( cgiGet( edtEnfermeroTitularId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEnfermeroTitularId_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum"), 1, "ENFERMEROTITULARID");
                  AnyError = 1 ;
                  GX_FocusControl = edtEnfermeroTitularId_Internalname ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true ;
                  A46EnfermeroTitularId = 0 ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A46EnfermeroTitularId", StringUtil.LTrim( StringUtil.Str( (decimal)(A46EnfermeroTitularId), 6, 0)));
               }
               else
               {
                  A46EnfermeroTitularId = (int)(context.localUtil.CToN( cgiGet( edtEnfermeroTitularId_Internalname), ",", ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A46EnfermeroTitularId", StringUtil.LTrim( StringUtil.Str( (decimal)(A46EnfermeroTitularId), 6, 0)));
               }
               A47EnfermeroTitularNombre = cgiGet( edtEnfermeroTitularNombre_Internalname) ;
               n47EnfermeroTitularNombre = false ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A47EnfermeroTitularNombre", A47EnfermeroTitularNombre);
               A48EnfermeroTitularApellido = cgiGet( edtEnfermeroTitularApellido_Internalname) ;
               n48EnfermeroTitularApellido = false ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A48EnfermeroTitularApellido", A48EnfermeroTitularApellido);
               if ( ( ( context.localUtil.CToN( cgiGet( edtEnfermeroSuplenteId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEnfermeroSuplenteId_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum"), 1, "ENFERMEROSUPLENTEID");
                  AnyError = 1 ;
                  GX_FocusControl = edtEnfermeroSuplenteId_Internalname ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true ;
                  A51EnfermeroSuplenteId = 0 ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A51EnfermeroSuplenteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A51EnfermeroSuplenteId), 6, 0)));
               }
               else
               {
                  A51EnfermeroSuplenteId = (int)(context.localUtil.CToN( cgiGet( edtEnfermeroSuplenteId_Internalname), ",", ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A51EnfermeroSuplenteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A51EnfermeroSuplenteId), 6, 0)));
               }
               A52EnfermeroSuplenteNombre = cgiGet( edtEnfermeroSuplenteNombre_Internalname) ;
               n52EnfermeroSuplenteNombre = false ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A52EnfermeroSuplenteNombre", A52EnfermeroSuplenteNombre);
               A56EnfermeroSuplenteApellido = cgiGet( edtEnfermeroSuplenteApellido_Internalname) ;
               n56EnfermeroSuplenteApellido = false ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A56EnfermeroSuplenteApellido", A56EnfermeroSuplenteApellido);
               /* Read saved values. */
               Z12MedicoId = (int)(context.localUtil.CToN( cgiGet( "Z12MedicoId"), ",", ".")) ;
               Z13MedicoNombre = cgiGet( "Z13MedicoNombre") ;
               Z14MedicoApellido = cgiGet( "Z14MedicoApellido") ;
               Z15MedicoDomicilio = cgiGet( "Z15MedicoDomicilio") ;
               Z16MedicoTelefono = cgiGet( "Z16MedicoTelefono") ;
               Z17MedicoEstadoCivil = cgiGet( "Z17MedicoEstadoCivil") ;
               Z18MedicoFechaIngreso = context.localUtil.CToD( cgiGet( "Z18MedicoFechaIngreso"), 0) ;
               Z9EspecialidadId = (int)(context.localUtil.CToN( cgiGet( "Z9EspecialidadId"), ",", ".")) ;
               Z46EnfermeroTitularId = (int)(context.localUtil.CToN( cgiGet( "Z46EnfermeroTitularId"), ",", ".")) ;
               Z51EnfermeroSuplenteId = (int)(context.localUtil.CToN( cgiGet( "Z51EnfermeroSuplenteId"), ",", ".")) ;
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", ".")) ;
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", ".")) ;
               Gx_mode = cgiGet( "Mode") ;
               AV7EnfermeroTitularID = (int)(context.localUtil.CToN( cgiGet( "_ENFERMEROTITULARID"), ",", ".")) ;
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
                  A12MedicoId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
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
               InitAll011( ) ;
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
         edtMedicoId_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtMedicoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtMedicoId_Enabled), 5, 0)));
         edtMedicoNombre_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtMedicoNombre_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtMedicoNombre_Enabled), 5, 0)));
         edtMedicoApellido_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtMedicoApellido_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtMedicoApellido_Enabled), 5, 0)));
         edtMedicoDomicilio_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtMedicoDomicilio_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtMedicoDomicilio_Enabled), 5, 0)));
         edtMedicoTelefono_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtMedicoTelefono_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtMedicoTelefono_Enabled), 5, 0)));
         cmbMedicoEstadoCivil.Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, cmbMedicoEstadoCivil_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(cmbMedicoEstadoCivil.Enabled), 5, 0)));
         edtMedicoFechaIngreso_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtMedicoFechaIngreso_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtMedicoFechaIngreso_Enabled), 5, 0)));
         edtEspecialidadId_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtEspecialidadId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtEspecialidadId_Enabled), 5, 0)));
         edtEspecialidadDescripcion_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtEspecialidadDescripcion_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtEspecialidadDescripcion_Enabled), 5, 0)));
         edtEnfermeroTitularId_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtEnfermeroTitularId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtEnfermeroTitularId_Enabled), 5, 0)));
         edtEnfermeroTitularNombre_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtEnfermeroTitularNombre_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtEnfermeroTitularNombre_Enabled), 5, 0)));
         edtEnfermeroTitularApellido_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtEnfermeroTitularApellido_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtEnfermeroTitularApellido_Enabled), 5, 0)));
         edtEnfermeroSuplenteId_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtEnfermeroSuplenteId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtEnfermeroSuplenteId_Enabled), 5, 0)));
         edtEnfermeroSuplenteNombre_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtEnfermeroSuplenteNombre_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtEnfermeroSuplenteNombre_Enabled), 5, 0)));
         edtEnfermeroSuplenteApellido_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtEnfermeroSuplenteApellido_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtEnfermeroSuplenteApellido_Enabled), 5, 0)));
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

      protected void ResetCaption010( )
      {
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               Z13MedicoNombre = T00013_A13MedicoNombre[0] ;
               Z14MedicoApellido = T00013_A14MedicoApellido[0] ;
               Z15MedicoDomicilio = T00013_A15MedicoDomicilio[0] ;
               Z16MedicoTelefono = T00013_A16MedicoTelefono[0] ;
               Z17MedicoEstadoCivil = T00013_A17MedicoEstadoCivil[0] ;
               Z18MedicoFechaIngreso = T00013_A18MedicoFechaIngreso[0] ;
               Z9EspecialidadId = T00013_A9EspecialidadId[0] ;
               Z46EnfermeroTitularId = T00013_A46EnfermeroTitularId[0] ;
               Z51EnfermeroSuplenteId = T00013_A51EnfermeroSuplenteId[0] ;
            }
            else
            {
               Z13MedicoNombre = A13MedicoNombre ;
               Z14MedicoApellido = A14MedicoApellido ;
               Z15MedicoDomicilio = A15MedicoDomicilio ;
               Z16MedicoTelefono = A16MedicoTelefono ;
               Z17MedicoEstadoCivil = A17MedicoEstadoCivil ;
               Z18MedicoFechaIngreso = A18MedicoFechaIngreso ;
               Z9EspecialidadId = A9EspecialidadId ;
               Z46EnfermeroTitularId = A46EnfermeroTitularId ;
               Z51EnfermeroSuplenteId = A51EnfermeroSuplenteId ;
            }
         }
         if ( GX_JID == -6 )
         {
            Z12MedicoId = A12MedicoId ;
            Z13MedicoNombre = A13MedicoNombre ;
            Z14MedicoApellido = A14MedicoApellido ;
            Z15MedicoDomicilio = A15MedicoDomicilio ;
            Z16MedicoTelefono = A16MedicoTelefono ;
            Z17MedicoEstadoCivil = A17MedicoEstadoCivil ;
            Z18MedicoFechaIngreso = A18MedicoFechaIngreso ;
            Z9EspecialidadId = A9EspecialidadId ;
            Z46EnfermeroTitularId = A46EnfermeroTitularId ;
            Z51EnfermeroSuplenteId = A51EnfermeroSuplenteId ;
            Z10EspecialidadDescripcion = A10EspecialidadDescripcion ;
            Z47EnfermeroTitularNombre = A47EnfermeroTitularNombre ;
            Z48EnfermeroTitularApellido = A48EnfermeroTitularApellido ;
            Z52EnfermeroSuplenteNombre = A52EnfermeroSuplenteNombre ;
            Z56EnfermeroSuplenteApellido = A56EnfermeroSuplenteApellido ;
         }
      }

      protected void standaloneNotModal( )
      {
         edtMedicoId_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtMedicoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtMedicoId_Enabled), 5, 0)));
         imgprompt_9_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ESPECIALIDADID"+"'), id:'"+"ESPECIALIDADID"+"'"+",isOut:true,isKey:false,isLastKey:false}"+"],"+"null"+","+"'', false"+","+"false"+");") ;
         imgprompt_46_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ENFERMEROTITULARID"+"'), id:'"+"ENFERMEROTITULARID"+"'"+",isOut:true,isKey:false,isLastKey:false}"+"],"+"null"+","+"'', false"+","+"false"+");") ;
         imgprompt_51_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ENFERMEROSUPLENTEID"+"'), id:'"+"ENFERMEROSUPLENTEID"+"'"+",isOut:true,isKey:false,isLastKey:false}"+"],"+"null"+","+"'', false"+","+"false"+");") ;
         edtMedicoId_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtMedicoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtMedicoId_Enabled), 5, 0)));
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

      protected void Load011( )
      {
         /* Using cursor T00017 */
         pr_default.execute(5, new Object[] {A12MedicoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound1 = 1 ;
            A13MedicoNombre = T00017_A13MedicoNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
            A14MedicoApellido = T00017_A14MedicoApellido[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
            A15MedicoDomicilio = T00017_A15MedicoDomicilio[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A15MedicoDomicilio", A15MedicoDomicilio);
            A16MedicoTelefono = T00017_A16MedicoTelefono[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A16MedicoTelefono", A16MedicoTelefono);
            A17MedicoEstadoCivil = T00017_A17MedicoEstadoCivil[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A17MedicoEstadoCivil", A17MedicoEstadoCivil);
            A18MedicoFechaIngreso = T00017_A18MedicoFechaIngreso[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A18MedicoFechaIngreso", context.localUtil.Format(A18MedicoFechaIngreso, "99/99/99"));
            A10EspecialidadDescripcion = T00017_A10EspecialidadDescripcion[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10EspecialidadDescripcion", A10EspecialidadDescripcion);
            A47EnfermeroTitularNombre = T00017_A47EnfermeroTitularNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A47EnfermeroTitularNombre", A47EnfermeroTitularNombre);
            n47EnfermeroTitularNombre = T00017_n47EnfermeroTitularNombre[0] ;
            A48EnfermeroTitularApellido = T00017_A48EnfermeroTitularApellido[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A48EnfermeroTitularApellido", A48EnfermeroTitularApellido);
            n48EnfermeroTitularApellido = T00017_n48EnfermeroTitularApellido[0] ;
            A52EnfermeroSuplenteNombre = T00017_A52EnfermeroSuplenteNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A52EnfermeroSuplenteNombre", A52EnfermeroSuplenteNombre);
            n52EnfermeroSuplenteNombre = T00017_n52EnfermeroSuplenteNombre[0] ;
            A56EnfermeroSuplenteApellido = T00017_A56EnfermeroSuplenteApellido[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A56EnfermeroSuplenteApellido", A56EnfermeroSuplenteApellido);
            n56EnfermeroSuplenteApellido = T00017_n56EnfermeroSuplenteApellido[0] ;
            A9EspecialidadId = T00017_A9EspecialidadId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
            A46EnfermeroTitularId = T00017_A46EnfermeroTitularId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A46EnfermeroTitularId", StringUtil.LTrim( StringUtil.Str( (decimal)(A46EnfermeroTitularId), 6, 0)));
            A51EnfermeroSuplenteId = T00017_A51EnfermeroSuplenteId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A51EnfermeroSuplenteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A51EnfermeroSuplenteId), 6, 0)));
            ZM011( -6) ;
         }
         pr_default.close(5);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
         AV7EnfermeroTitularID = A46EnfermeroTitularId ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7EnfermeroTitularID", StringUtil.LTrim( StringUtil.Str( (decimal)(AV7EnfermeroTitularID), 6, 0)));
      }

      protected void CheckExtendedTable011( )
      {
         Gx_BScreen = 1 ;
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A17MedicoEstadoCivil, "S") == 0 ) || ( StringUtil.StrCmp(A17MedicoEstadoCivil, "C") == 0 ) || ( StringUtil.StrCmp(A17MedicoEstadoCivil, "V") == 0 ) || ( StringUtil.StrCmp(A17MedicoEstadoCivil, "D") == 0 ) ) )
         {
            GX_msglist.addItem("Campo Medico Estado Civil fuera de rango", "OutOfRange", 1, "");
            AnyError = 1 ;
         }
         if ( ! ( (DateTime.MinValue==A18MedicoFechaIngreso) || ( A18MedicoFechaIngreso >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Medico Fecha Ingreso fuera de rango", "OutOfRange", 1, "");
            AnyError = 1 ;
         }
         /* Using cursor T00014 */
         pr_default.execute(2, new Object[] {A9EspecialidadId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Especialidad'.", "ForeignKeyNotFound", 1, "ESPECIALIDADID");
            AnyError = 1 ;
            GX_FocusControl = edtEspecialidadId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10EspecialidadDescripcion = T00014_A10EspecialidadDescripcion[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10EspecialidadDescripcion", A10EspecialidadDescripcion);
         pr_default.close(2);
         /* Using cursor T00015 */
         pr_default.execute(3, new Object[] {A46EnfermeroTitularId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Enfermero Titular'.", "ForeignKeyNotFound", 1, "ENFERMEROTITULARID");
            AnyError = 1 ;
            GX_FocusControl = edtEnfermeroTitularId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A47EnfermeroTitularNombre = T00015_A47EnfermeroTitularNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A47EnfermeroTitularNombre", A47EnfermeroTitularNombre);
         n47EnfermeroTitularNombre = T00015_n47EnfermeroTitularNombre[0] ;
         A48EnfermeroTitularApellido = T00015_A48EnfermeroTitularApellido[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A48EnfermeroTitularApellido", A48EnfermeroTitularApellido);
         n48EnfermeroTitularApellido = T00015_n48EnfermeroTitularApellido[0] ;
         pr_default.close(3);
         AV7EnfermeroTitularID = A46EnfermeroTitularId ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7EnfermeroTitularID", StringUtil.LTrim( StringUtil.Str( (decimal)(AV7EnfermeroTitularID), 6, 0)));
         if ( A51EnfermeroSuplenteId == AV7EnfermeroTitularID )
         {
            GX_msglist.addItem("El enfermero suplente y el titular no pueden ser el mismo", 1, "");
            AnyError = 1 ;
         }
         /* Using cursor T00016 */
         pr_default.execute(4, new Object[] {A51EnfermeroSuplenteId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Enfermero Suplente'.", "ForeignKeyNotFound", 1, "ENFERMEROSUPLENTEID");
            AnyError = 1 ;
            GX_FocusControl = edtEnfermeroSuplenteId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A52EnfermeroSuplenteNombre = T00016_A52EnfermeroSuplenteNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A52EnfermeroSuplenteNombre", A52EnfermeroSuplenteNombre);
         n52EnfermeroSuplenteNombre = T00016_n52EnfermeroSuplenteNombre[0] ;
         A56EnfermeroSuplenteApellido = T00016_A56EnfermeroSuplenteApellido[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A56EnfermeroSuplenteApellido", A56EnfermeroSuplenteApellido);
         n56EnfermeroSuplenteApellido = T00016_n56EnfermeroSuplenteApellido[0] ;
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors011( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
         if ( IsConfirmed == 0 )
         {
            imgBtn_delete2_Enabled = RcdFound1 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_delete2_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_delete2_Enabled), 5, 0)));
         }
         else
         {
            imgBtn_delete2_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_delete2_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_delete2_Enabled), 5, 0)));
         }
      }

      protected void gxLoad_7( int A9EspecialidadId )
      {
         /* Using cursor T00018 */
         pr_default.execute(6, new Object[] {A9EspecialidadId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Especialidad'.", "ForeignKeyNotFound", 1, "ESPECIALIDADID");
            AnyError = 1 ;
            GX_FocusControl = edtEspecialidadId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10EspecialidadDescripcion = T00018_A10EspecialidadDescripcion[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10EspecialidadDescripcion", A10EspecialidadDescripcion);
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A10EspecialidadDescripcion))+"\"");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(6) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(6);
      }

      protected void gxLoad_8( int A46EnfermeroTitularId )
      {
         /* Using cursor T00019 */
         pr_default.execute(7, new Object[] {A46EnfermeroTitularId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Enfermero Titular'.", "ForeignKeyNotFound", 1, "ENFERMEROTITULARID");
            AnyError = 1 ;
            GX_FocusControl = edtEnfermeroTitularId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A47EnfermeroTitularNombre = T00019_A47EnfermeroTitularNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A47EnfermeroTitularNombre", A47EnfermeroTitularNombre);
         n47EnfermeroTitularNombre = T00019_n47EnfermeroTitularNombre[0] ;
         A48EnfermeroTitularApellido = T00019_A48EnfermeroTitularApellido[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A48EnfermeroTitularApellido", A48EnfermeroTitularApellido);
         n48EnfermeroTitularApellido = T00019_n48EnfermeroTitularApellido[0] ;
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A47EnfermeroTitularNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A48EnfermeroTitularApellido))+"\"");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(7) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(7);
      }

      protected void gxLoad_9( int A51EnfermeroSuplenteId )
      {
         /* Using cursor T000110 */
         pr_default.execute(8, new Object[] {A51EnfermeroSuplenteId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Enfermero Suplente'.", "ForeignKeyNotFound", 1, "ENFERMEROSUPLENTEID");
            AnyError = 1 ;
            GX_FocusControl = edtEnfermeroSuplenteId_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A52EnfermeroSuplenteNombre = T000110_A52EnfermeroSuplenteNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A52EnfermeroSuplenteNombre", A52EnfermeroSuplenteNombre);
         n52EnfermeroSuplenteNombre = T000110_n52EnfermeroSuplenteNombre[0] ;
         A56EnfermeroSuplenteApellido = T000110_A56EnfermeroSuplenteApellido[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A56EnfermeroSuplenteApellido", A56EnfermeroSuplenteApellido);
         n56EnfermeroSuplenteApellido = T000110_n56EnfermeroSuplenteApellido[0] ;
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A52EnfermeroSuplenteNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A56EnfermeroSuplenteApellido))+"\"");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(8) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(8);
      }

      protected void GetKey011( )
      {
         /* Using cursor T000111 */
         pr_default.execute(9, new Object[] {A12MedicoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound1 = 1 ;
         }
         else
         {
            RcdFound1 = 0 ;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {A12MedicoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 6) ;
            RcdFound1 = 1 ;
            A12MedicoId = T00013_A12MedicoId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            A13MedicoNombre = T00013_A13MedicoNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
            A14MedicoApellido = T00013_A14MedicoApellido[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
            A15MedicoDomicilio = T00013_A15MedicoDomicilio[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A15MedicoDomicilio", A15MedicoDomicilio);
            A16MedicoTelefono = T00013_A16MedicoTelefono[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A16MedicoTelefono", A16MedicoTelefono);
            A17MedicoEstadoCivil = T00013_A17MedicoEstadoCivil[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A17MedicoEstadoCivil", A17MedicoEstadoCivil);
            A18MedicoFechaIngreso = T00013_A18MedicoFechaIngreso[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A18MedicoFechaIngreso", context.localUtil.Format(A18MedicoFechaIngreso, "99/99/99"));
            A9EspecialidadId = T00013_A9EspecialidadId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
            A46EnfermeroTitularId = T00013_A46EnfermeroTitularId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A46EnfermeroTitularId", StringUtil.LTrim( StringUtil.Str( (decimal)(A46EnfermeroTitularId), 6, 0)));
            A51EnfermeroSuplenteId = T00013_A51EnfermeroSuplenteId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A51EnfermeroSuplenteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A51EnfermeroSuplenteId), 6, 0)));
            Z12MedicoId = A12MedicoId ;
            sMode1 = Gx_mode ;
            Gx_mode = "DSP" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load011( ) ;
            Gx_mode = sMode1 ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound1 = 0 ;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode ;
            Gx_mode = "DSP" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode1 ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
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
         RcdFound1 = 0 ;
         /* Using cursor T000112 */
         pr_default.execute(10, new Object[] {A12MedicoId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000112_A12MedicoId[0] < A12MedicoId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000112_A12MedicoId[0] > A12MedicoId ) ) )
            {
               A12MedicoId = T000112_A12MedicoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
               RcdFound1 = 1 ;
            }
         }
         pr_default.close(1);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0 ;
         /* Using cursor T000113 */
         pr_default.execute(11, new Object[] {A12MedicoId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000113_A12MedicoId[0] > A12MedicoId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000113_A12MedicoId[0] < A12MedicoId ) ) )
            {
               A12MedicoId = T000113_A12MedicoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
               RcdFound1 = 1 ;
            }
         }
         pr_default.close(0);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1 ;
         GetKey011( ) ;
         if ( RcdFound1 == 1 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate"), "DuplicatePrimaryKey", 1, "MEDICOID");
               AnyError = 1 ;
            }
            else if ( A12MedicoId != Z12MedicoId )
            {
               A12MedicoId = Z12MedicoId ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd"), "CandidateKeyNotFound", 1, "MEDICOID");
               AnyError = 1 ;
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               delete( ) ;
               AfterTrn( ) ;
               GX_FocusControl = edtMedicoNombre_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else
            {
               Gx_mode = "UPD" ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
               /* Update record */
               Update011( ) ;
               GX_FocusControl = edtMedicoNombre_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( A12MedicoId != Z12MedicoId )
            {
               Gx_mode = "INS" ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
               /* Insert record */
               Insert011( ) ;
               GX_FocusControl = edtMedicoNombre_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted"), 1, "MEDICOID");
                  AnyError = 1 ;
               }
               else
               {
                  Gx_mode = "INS" ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  Insert011( ) ;
                  GX_FocusControl = edtMedicoNombre_Internalname ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A12MedicoId != Z12MedicoId )
         {
            A12MedicoId = Z12MedicoId ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt"), 1, "MEDICOID");
            AnyError = 1 ;
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMedicoNombre_Internalname ;
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
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound"), "PrimaryKeyNotFound", 1, "MEDICOID");
            AnyError = 1 ;
         }
         GX_FocusControl = edtMedicoNombre_Internalname ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2 ;
         IsConfirmed = 0 ;
         ScanStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow"), 0, "");
         }
         else
         {
            Gx_mode = "UPD" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMedicoNombre_Internalname ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd011( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2 ;
         IsConfirmed = 0 ;
         move_previous( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow"), 0, "");
         }
         else
         {
            Gx_mode = "UPD" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMedicoNombre_Internalname ;
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
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow"), 0, "");
         }
         else
         {
            Gx_mode = "UPD" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMedicoNombre_Internalname ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2 ;
         IsConfirmed = 0 ;
         ScanStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow"), 0, "");
         }
         else
         {
            while ( RcdFound1 != 0 )
            {
               ScanNext011( ) ;
            }
            Gx_mode = "UPD" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMedicoNombre_Internalname ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd011( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            /* Using cursor T000114 */
            pr_default.execute(12, new Object[] {A12MedicoId});
            if ( (pr_default.getStatus(12) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Medico"}), "RecordIsLocked", 1, "");
               AnyError = 1 ;
               return  ;
            }
            Gx_longc = false ;
            if ( (pr_default.getStatus(12) == 101) || ( StringUtil.StrCmp(Z13MedicoNombre, T000114_A13MedicoNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z14MedicoApellido, T000114_A14MedicoApellido[0]) != 0 ) || ( StringUtil.StrCmp(Z15MedicoDomicilio, T000114_A15MedicoDomicilio[0]) != 0 ) || ( StringUtil.StrCmp(Z16MedicoTelefono, T000114_A16MedicoTelefono[0]) != 0 ) || ( StringUtil.StrCmp(Z17MedicoEstadoCivil, T000114_A17MedicoEstadoCivil[0]) != 0 ) )
            {
               Gx_longc = true ;
            }
            if ( Gx_longc || ( Z18MedicoFechaIngreso != T000114_A18MedicoFechaIngreso[0] ) || ( Z9EspecialidadId != T000114_A9EspecialidadId[0] ) || ( Z46EnfermeroTitularId != T000114_A46EnfermeroTitularId[0] ) || ( Z51EnfermeroSuplenteId != T000114_A51EnfermeroSuplenteId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Medico"}), "RecordWasChanged", 1, "");
               AnyError = 1 ;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000115 */
                     pr_default.execute(13, new Object[] {A13MedicoNombre, A14MedicoApellido, A15MedicoDomicilio, A16MedicoTelefono, A17MedicoEstadoCivil, A18MedicoFechaIngreso, A9EspecialidadId, A46EnfermeroTitularId, A51EnfermeroSuplenteId});
                     pr_default.close(13);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000116 */
                     pr_default.execute(14);
                     A12MedicoId = T000116_A12MedicoId[0] ;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
                     pr_default.close(14);
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           GX_msglist.addItem(context.GetMessage( "GXM_sucadded"), 0, "");
                           ResetCaption010( ) ;
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
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000117 */
                     pr_default.execute(15, new Object[] {A13MedicoNombre, A14MedicoApellido, A15MedicoDomicilio, A16MedicoTelefono, A17MedicoEstadoCivil, A18MedicoFechaIngreso, A9EspecialidadId, A46EnfermeroTitularId, A51EnfermeroSuplenteId, A12MedicoId});
                     pr_default.close(15);
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Medico"}), "RecordIsLocked", 1, "");
                        AnyError = 1 ;
                     }
                     DeferredUpdate011( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           GX_msglist.addItem(context.GetMessage( "GXM_sucupdated"), 0, "");
                           ResetCaption010( ) ;
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
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000118 */
                  pr_default.execute(16, new Object[] {A12MedicoId});
                  pr_default.close(16);
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound1 == 0 )
                        {
                           InitAll011( ) ;
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
                        ResetCaption010( ) ;
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
         sMode1 = Gx_mode ;
         Gx_mode = "DLT" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         EndLevel011( ) ;
         Gx_mode = sMode1 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000119 */
            pr_default.execute(17, new Object[] {A9EspecialidadId});
            A10EspecialidadDescripcion = T000119_A10EspecialidadDescripcion[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10EspecialidadDescripcion", A10EspecialidadDescripcion);
            pr_default.close(17);
            /* Using cursor T000120 */
            pr_default.execute(18, new Object[] {A46EnfermeroTitularId});
            A47EnfermeroTitularNombre = T000120_A47EnfermeroTitularNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A47EnfermeroTitularNombre", A47EnfermeroTitularNombre);
            n47EnfermeroTitularNombre = T000120_n47EnfermeroTitularNombre[0] ;
            A48EnfermeroTitularApellido = T000120_A48EnfermeroTitularApellido[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A48EnfermeroTitularApellido", A48EnfermeroTitularApellido);
            n48EnfermeroTitularApellido = T000120_n48EnfermeroTitularApellido[0] ;
            pr_default.close(18);
            AV7EnfermeroTitularID = A46EnfermeroTitularId ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7EnfermeroTitularID", StringUtil.LTrim( StringUtil.Str( (decimal)(AV7EnfermeroTitularID), 6, 0)));
            /* Using cursor T000121 */
            pr_default.execute(19, new Object[] {A51EnfermeroSuplenteId});
            A52EnfermeroSuplenteNombre = T000121_A52EnfermeroSuplenteNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A52EnfermeroSuplenteNombre", A52EnfermeroSuplenteNombre);
            n52EnfermeroSuplenteNombre = T000121_n52EnfermeroSuplenteNombre[0] ;
            A56EnfermeroSuplenteApellido = T000121_A56EnfermeroSuplenteApellido[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A56EnfermeroSuplenteApellido", A56EnfermeroSuplenteApellido);
            n56EnfermeroSuplenteApellido = T000121_n56EnfermeroSuplenteApellido[0] ;
            pr_default.close(19);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000122 */
            pr_default.execute(20, new Object[] {A12MedicoId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Consulta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1 ;
            }
            pr_default.close(20);
         }
      }

      protected void EndLevel011( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            pr_default.close(12);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(11);
            pr_default.close(10);
            pr_default.close(17);
            pr_default.close(18);
            pr_default.close(19);
            context.CommitDataStores("Medico");
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1 ;
         }
         else
         {
            pr_default.close(11);
            pr_default.close(10);
            pr_default.close(17);
            pr_default.close(18);
            pr_default.close(19);
            context.RollbackDataStores("Medico");
         }
         IsModified = 0 ;
         if ( AnyError != 0 )
         {
            context.wjLoc = "" ;
            context.nUserReturn = 0 ;
         }
      }

      protected void ScanStart011( )
      {
         /* Using cursor T000123 */
         pr_default.execute(21);
         RcdFound1 = 0 ;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound1 = 1 ;
            A12MedicoId = T000123_A12MedicoId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext011( )
      {
         pr_default.readNext(21);
         RcdFound1 = 0 ;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound1 = 1 ;
            A12MedicoId = T000123_A12MedicoId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
         }
      }

      protected void ScanEnd011( )
      {
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues010( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" onsubmit=\"try{return gx.csv.validForm()}catch(e){return true;}\" name=\"MAINFORM\" method=\"post\" action=\""+formatLink("medico.aspx") +"\" class=\""+"Form"+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
      }

      public override void RenderHtmlCloseForm( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         GxWebStd.gx_hidden_field( context, "Z12MedicoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12MedicoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z13MedicoNombre", StringUtil.RTrim( Z13MedicoNombre));
         GxWebStd.gx_hidden_field( context, "Z14MedicoApellido", StringUtil.RTrim( Z14MedicoApellido));
         GxWebStd.gx_hidden_field( context, "Z15MedicoDomicilio", StringUtil.RTrim( Z15MedicoDomicilio));
         GxWebStd.gx_hidden_field( context, "Z16MedicoTelefono", StringUtil.RTrim( Z16MedicoTelefono));
         GxWebStd.gx_hidden_field( context, "Z17MedicoEstadoCivil", StringUtil.RTrim( Z17MedicoEstadoCivil));
         GxWebStd.gx_hidden_field( context, "Z18MedicoFechaIngreso", context.localUtil.DToC( Z18MedicoFechaIngreso, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z9EspecialidadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9EspecialidadId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z46EnfermeroTitularId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z46EnfermeroTitularId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z51EnfermeroSuplenteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z51EnfermeroSuplenteId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "_ENFERMEROTITULARID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EnfermeroTitularID), 6, 0, ",", "")));
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
         return "Medico" ;
      }

      public override String GetPgmdesc( )
      {
         return "Médico" ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("medico.aspx")  ;
      }

      protected void InitializeNonKey011( )
      {
         AV7EnfermeroTitularID = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7EnfermeroTitularID", StringUtil.LTrim( StringUtil.Str( (decimal)(AV7EnfermeroTitularID), 6, 0)));
         A13MedicoNombre = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
         A14MedicoApellido = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
         A15MedicoDomicilio = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A15MedicoDomicilio", A15MedicoDomicilio);
         A16MedicoTelefono = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A16MedicoTelefono", A16MedicoTelefono);
         A17MedicoEstadoCivil = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A17MedicoEstadoCivil", A17MedicoEstadoCivil);
         A18MedicoFechaIngreso = DateTime.MinValue ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A18MedicoFechaIngreso", context.localUtil.Format(A18MedicoFechaIngreso, "99/99/99"));
         A9EspecialidadId = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
         A10EspecialidadDescripcion = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10EspecialidadDescripcion", A10EspecialidadDescripcion);
         A46EnfermeroTitularId = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A46EnfermeroTitularId", StringUtil.LTrim( StringUtil.Str( (decimal)(A46EnfermeroTitularId), 6, 0)));
         A47EnfermeroTitularNombre = "" ;
         n47EnfermeroTitularNombre = false ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A47EnfermeroTitularNombre", A47EnfermeroTitularNombre);
         A48EnfermeroTitularApellido = "" ;
         n48EnfermeroTitularApellido = false ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A48EnfermeroTitularApellido", A48EnfermeroTitularApellido);
         A51EnfermeroSuplenteId = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A51EnfermeroSuplenteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A51EnfermeroSuplenteId), 6, 0)));
         A52EnfermeroSuplenteNombre = "" ;
         n52EnfermeroSuplenteNombre = false ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A52EnfermeroSuplenteNombre", A52EnfermeroSuplenteNombre);
         A56EnfermeroSuplenteApellido = "" ;
         n56EnfermeroSuplenteApellido = false ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A56EnfermeroSuplenteApellido", A56EnfermeroSuplenteApellido);
      }

      protected void InitAll011( )
      {
         A12MedicoId = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
         InitializeNonKey011( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( Form.Jscriptsrc.Item(idxLst)), "?4160");
            idxLst = (int)(idxLst+1) ;
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?34981");
         context.AddJavascriptSource("medico.js", "?4161");
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
         lblTextblockmedicoid_Internalname = "TEXTBLOCKMEDICOID" ;
         edtMedicoId_Internalname = "MEDICOID" ;
         lblTextblockmediconombre_Internalname = "TEXTBLOCKMEDICONOMBRE" ;
         edtMedicoNombre_Internalname = "MEDICONOMBRE" ;
         lblTextblockmedicoapellido_Internalname = "TEXTBLOCKMEDICOAPELLIDO" ;
         edtMedicoApellido_Internalname = "MEDICOAPELLIDO" ;
         lblTextblockmedicodomicilio_Internalname = "TEXTBLOCKMEDICODOMICILIO" ;
         edtMedicoDomicilio_Internalname = "MEDICODOMICILIO" ;
         lblTextblockmedicotelefono_Internalname = "TEXTBLOCKMEDICOTELEFONO" ;
         edtMedicoTelefono_Internalname = "MEDICOTELEFONO" ;
         lblTextblockmedicoestadocivil_Internalname = "TEXTBLOCKMEDICOESTADOCIVIL" ;
         cmbMedicoEstadoCivil_Internalname = "MEDICOESTADOCIVIL" ;
         lblTextblockmedicofechaingreso_Internalname = "TEXTBLOCKMEDICOFECHAINGRESO" ;
         edtMedicoFechaIngreso_Internalname = "MEDICOFECHAINGRESO" ;
         lblTextblockespecialidadid_Internalname = "TEXTBLOCKESPECIALIDADID" ;
         edtEspecialidadId_Internalname = "ESPECIALIDADID" ;
         lblTextblockespecialidaddescripcion_Internalname = "TEXTBLOCKESPECIALIDADDESCRIPCION" ;
         edtEspecialidadDescripcion_Internalname = "ESPECIALIDADDESCRIPCION" ;
         lblTextblockenfermerotitularid_Internalname = "TEXTBLOCKENFERMEROTITULARID" ;
         edtEnfermeroTitularId_Internalname = "ENFERMEROTITULARID" ;
         lblTextblockenfermerotitularnombre_Internalname = "TEXTBLOCKENFERMEROTITULARNOMBRE" ;
         edtEnfermeroTitularNombre_Internalname = "ENFERMEROTITULARNOMBRE" ;
         lblTextblockenfermerotitularapellido_Internalname = "TEXTBLOCKENFERMEROTITULARAPELLIDO" ;
         edtEnfermeroTitularApellido_Internalname = "ENFERMEROTITULARAPELLIDO" ;
         lblTextblockenfermerosuplenteid_Internalname = "TEXTBLOCKENFERMEROSUPLENTEID" ;
         edtEnfermeroSuplenteId_Internalname = "ENFERMEROSUPLENTEID" ;
         lblTextblockenfermerosuplentenombre_Internalname = "TEXTBLOCKENFERMEROSUPLENTENOMBRE" ;
         edtEnfermeroSuplenteNombre_Internalname = "ENFERMEROSUPLENTENOMBRE" ;
         lblTextblockenfermerosuplenteapellido_Internalname = "TEXTBLOCKENFERMEROSUPLENTEAPELLIDO" ;
         edtEnfermeroSuplenteApellido_Internalname = "ENFERMEROSUPLENTEAPELLIDO" ;
         tblTable2_Internalname = "TABLE2" ;
         bttBtn_enter_Internalname = "BTN_ENTER" ;
         bttBtn_cancel_Internalname = "BTN_CANCEL" ;
         bttBtn_delete_Internalname = "BTN_DELETE" ;
         tblTable1_Internalname = "TABLE1" ;
         grpGroupdata_Internalname = "GROUPDATA" ;
         tblTablemain_Internalname = "TABLEMAIN" ;
         Form.Internalname = "FORM" ;
         imgprompt_9_Internalname = "PROMPT_9" ;
         imgprompt_46_Internalname = "PROMPT_46" ;
         imgprompt_51_Internalname = "PROMPT_51" ;
         Form.Headerrawhtml = "" ;
         Form.Background = "" ;
         Form.Backcolor = (int)(0xFFFFFF) ;
         Form.Caption = "Médico" ;
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
         edtEnfermeroSuplenteApellido_Jsonclick = "" ;
         edtEnfermeroSuplenteApellido_Enabled = 0 ;
         edtEnfermeroSuplenteNombre_Jsonclick = "" ;
         edtEnfermeroSuplenteNombre_Enabled = 0 ;
         imgprompt_51_Visible = 1 ;
         imgprompt_51_Link = "" ;
         edtEnfermeroSuplenteId_Jsonclick = "" ;
         edtEnfermeroSuplenteId_Enabled = 1 ;
         edtEnfermeroTitularApellido_Jsonclick = "" ;
         edtEnfermeroTitularApellido_Enabled = 0 ;
         edtEnfermeroTitularNombre_Jsonclick = "" ;
         edtEnfermeroTitularNombre_Enabled = 0 ;
         imgprompt_46_Visible = 1 ;
         imgprompt_46_Link = "" ;
         edtEnfermeroTitularId_Jsonclick = "" ;
         edtEnfermeroTitularId_Enabled = 1 ;
         edtEspecialidadDescripcion_Jsonclick = "" ;
         edtEspecialidadDescripcion_Enabled = 0 ;
         imgprompt_9_Visible = 1 ;
         imgprompt_9_Link = "" ;
         edtEspecialidadId_Jsonclick = "" ;
         edtEspecialidadId_Enabled = 1 ;
         edtMedicoFechaIngreso_Jsonclick = "" ;
         edtMedicoFechaIngreso_Enabled = 1 ;
         cmbMedicoEstadoCivil_Jsonclick = "" ;
         cmbMedicoEstadoCivil.Enabled = 1 ;
         edtMedicoTelefono_Jsonclick = "" ;
         edtMedicoTelefono_Enabled = 1 ;
         edtMedicoDomicilio_Jsonclick = "" ;
         edtMedicoDomicilio_Enabled = 1 ;
         edtMedicoApellido_Jsonclick = "" ;
         edtMedicoApellido_Enabled = 1 ;
         edtMedicoNombre_Jsonclick = "" ;
         edtMedicoNombre_Enabled = 1 ;
         edtMedicoId_Jsonclick = "" ;
         edtMedicoId_Enabled = 0 ;
         bttBtn_delete_Visible = 1 ;
         bttBtn_cancel_Visible = 1 ;
         bttBtn_enter_Visible = 1 ;
         context.GX_msglist.DisplayMode = 1 ;
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0 ;
         getEqualNoModal( ) ;
         GX_FocusControl = edtMedicoNombre_Internalname ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      public void Valid_Medicoid( int GX_Parm1 ,
                                  String GX_Parm2 ,
                                  String GX_Parm3 ,
                                  String GX_Parm4 ,
                                  String GX_Parm5 ,
                                  GXCombobox cmbGX_Parm6 ,
                                  DateTime GX_Parm7 ,
                                  int GX_Parm8 ,
                                  int GX_Parm9 ,
                                  int GX_Parm10 )
      {
         A12MedicoId = GX_Parm1 ;
         A13MedicoNombre = GX_Parm2 ;
         A14MedicoApellido = GX_Parm3 ;
         A15MedicoDomicilio = GX_Parm4 ;
         A16MedicoTelefono = GX_Parm5 ;
         cmbMedicoEstadoCivil = cmbGX_Parm6 ;
         A17MedicoEstadoCivil = cmbMedicoEstadoCivil.CurrentValue ;
         cmbMedicoEstadoCivil.CurrentValue = A17MedicoEstadoCivil ;
         A18MedicoFechaIngreso = GX_Parm7 ;
         A9EspecialidadId = GX_Parm8 ;
         A46EnfermeroTitularId = GX_Parm9 ;
         A51EnfermeroSuplenteId = GX_Parm10 ;
         context.wbHandled = 1 ;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         dynload_actions( ) ;
         if ( AnyError == 1 )
         {
            A10EspecialidadDescripcion = "" ;
            A47EnfermeroTitularNombre = "" ;
            n47EnfermeroTitularNombre = false ;
            A48EnfermeroTitularApellido = "" ;
            n48EnfermeroTitularApellido = false ;
            A52EnfermeroSuplenteNombre = "" ;
            n52EnfermeroSuplenteNombre = false ;
            A56EnfermeroSuplenteApellido = "" ;
            n56EnfermeroSuplenteApellido = false ;
         }
         isValidOutput.Add((Object)(StringUtil.RTrim( A13MedicoNombre)));
         isValidOutput.Add((Object)(StringUtil.RTrim( A14MedicoApellido)));
         isValidOutput.Add((Object)(StringUtil.RTrim( A15MedicoDomicilio)));
         isValidOutput.Add((Object)(StringUtil.RTrim( A16MedicoTelefono)));
         cmbMedicoEstadoCivil.CurrentValue = A17MedicoEstadoCivil ;
         isValidOutput.Add((Object)(cmbMedicoEstadoCivil));
         isValidOutput.Add((Object)(context.localUtil.Format(A18MedicoFechaIngreso, "99/99/99")));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(A9EspecialidadId), 6, 0, ".", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(A46EnfermeroTitularId), 6, 0, ".", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(A51EnfermeroSuplenteId), 6, 0, ".", ""))));
         isValidOutput.Add((Object)(StringUtil.RTrim( A10EspecialidadDescripcion)));
         isValidOutput.Add((Object)(StringUtil.RTrim( A47EnfermeroTitularNombre)));
         isValidOutput.Add((Object)(StringUtil.RTrim( A48EnfermeroTitularApellido)));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EnfermeroTitularID), 6, 0, ".", ""))));
         isValidOutput.Add((Object)(StringUtil.RTrim( A52EnfermeroSuplenteNombre)));
         isValidOutput.Add((Object)(StringUtil.RTrim( A56EnfermeroSuplenteApellido)));
         isValidOutput.Add((Object)(StringUtil.RTrim( Gx_mode)));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12MedicoId), 6, 0, ",", ""))));
         isValidOutput.Add((Object)(StringUtil.RTrim( Z13MedicoNombre)));
         isValidOutput.Add((Object)(StringUtil.RTrim( Z14MedicoApellido)));
         isValidOutput.Add((Object)(StringUtil.RTrim( Z15MedicoDomicilio)));
         isValidOutput.Add((Object)(StringUtil.RTrim( Z16MedicoTelefono)));
         isValidOutput.Add((Object)(StringUtil.RTrim( Z17MedicoEstadoCivil)));
         isValidOutput.Add((Object)(context.localUtil.DToC( Z18MedicoFechaIngreso, 0, "/")));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9EspecialidadId), 6, 0, ",", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(Z46EnfermeroTitularId), 6, 0, ",", ""))));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(Z51EnfermeroSuplenteId), 6, 0, ",", ""))));
         isValidOutput.Add((Object)(StringUtil.RTrim( Z10EspecialidadDescripcion)));
         isValidOutput.Add((Object)(StringUtil.RTrim( Z47EnfermeroTitularNombre)));
         isValidOutput.Add((Object)(StringUtil.RTrim( Z48EnfermeroTitularApellido)));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(ZV7EnfermeroTitularID), 6, 0, ",", ""))));
         isValidOutput.Add((Object)(StringUtil.RTrim( Z52EnfermeroSuplenteNombre)));
         isValidOutput.Add((Object)(StringUtil.RTrim( Z56EnfermeroSuplenteApellido)));
         isValidOutput.Add((Object)(imgBtn_enter2_Enabled));
         isValidOutput.Add((Object)(context.GX_msglist.ToJavascriptSource()));
         context.GX_webresponse.AddString(isValidOutput.ToJSonString());
      }

      public void Valid_Especialidadid( int GX_Parm1 ,
                                        String GX_Parm2 )
      {
         A9EspecialidadId = GX_Parm1 ;
         A10EspecialidadDescripcion = GX_Parm2 ;
         /* Using cursor T000119 */
         pr_default.execute(17, new Object[] {A9EspecialidadId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Especialidad'.", "ForeignKeyNotFound", 1, "ESPECIALIDADID");
            AnyError = 1 ;
            GX_FocusControl = edtEspecialidadId_Internalname ;
         }
         A10EspecialidadDescripcion = T000119_A10EspecialidadDescripcion[0] ;
         pr_default.close(17);
         dynload_actions( ) ;
         if ( AnyError == 1 )
         {
            A10EspecialidadDescripcion = "" ;
         }
         isValidOutput.Add((Object)(StringUtil.RTrim( A10EspecialidadDescripcion)));
         isValidOutput.Add((Object)(context.GX_msglist.ToJavascriptSource()));
         context.GX_webresponse.AddString(isValidOutput.ToJSonString());
      }

      public void Valid_Enfermerotitularid( int GX_Parm1 ,
                                            String GX_Parm2 ,
                                            String GX_Parm3 ,
                                            int GX_Parm4 )
      {
         A46EnfermeroTitularId = GX_Parm1 ;
         A47EnfermeroTitularNombre = GX_Parm2 ;
         n47EnfermeroTitularNombre = false ;
         A48EnfermeroTitularApellido = GX_Parm3 ;
         n48EnfermeroTitularApellido = false ;
         AV7EnfermeroTitularID = GX_Parm4 ;
         /* Using cursor T000120 */
         pr_default.execute(18, new Object[] {A46EnfermeroTitularId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Enfermero Titular'.", "ForeignKeyNotFound", 1, "ENFERMEROTITULARID");
            AnyError = 1 ;
            GX_FocusControl = edtEnfermeroTitularId_Internalname ;
         }
         A47EnfermeroTitularNombre = T000120_A47EnfermeroTitularNombre[0] ;
         n47EnfermeroTitularNombre = T000120_n47EnfermeroTitularNombre[0] ;
         A48EnfermeroTitularApellido = T000120_A48EnfermeroTitularApellido[0] ;
         n48EnfermeroTitularApellido = T000120_n48EnfermeroTitularApellido[0] ;
         pr_default.close(18);
         AV7EnfermeroTitularID = A46EnfermeroTitularId ;
         dynload_actions( ) ;
         if ( AnyError == 1 )
         {
            A47EnfermeroTitularNombre = "" ;
            n47EnfermeroTitularNombre = false ;
            A48EnfermeroTitularApellido = "" ;
            n48EnfermeroTitularApellido = false ;
         }
         isValidOutput.Add((Object)(StringUtil.RTrim( A47EnfermeroTitularNombre)));
         isValidOutput.Add((Object)(StringUtil.RTrim( A48EnfermeroTitularApellido)));
         isValidOutput.Add((Object)(StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EnfermeroTitularID), 6, 0, ".", ""))));
         isValidOutput.Add((Object)(context.GX_msglist.ToJavascriptSource()));
         context.GX_webresponse.AddString(isValidOutput.ToJSonString());
      }

      public void Valid_Enfermerosuplenteid( int GX_Parm1 ,
                                             int GX_Parm2 ,
                                             String GX_Parm3 ,
                                             String GX_Parm4 )
      {
         A51EnfermeroSuplenteId = GX_Parm1 ;
         AV7EnfermeroTitularID = GX_Parm2 ;
         A52EnfermeroSuplenteNombre = GX_Parm3 ;
         n52EnfermeroSuplenteNombre = false ;
         A56EnfermeroSuplenteApellido = GX_Parm4 ;
         n56EnfermeroSuplenteApellido = false ;
         /* Using cursor T000121 */
         pr_default.execute(19, new Object[] {A51EnfermeroSuplenteId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Enfermero Suplente'.", "ForeignKeyNotFound", 1, "ENFERMEROSUPLENTEID");
            AnyError = 1 ;
            GX_FocusControl = edtEnfermeroSuplenteId_Internalname ;
         }
         A52EnfermeroSuplenteNombre = T000121_A52EnfermeroSuplenteNombre[0] ;
         n52EnfermeroSuplenteNombre = T000121_n52EnfermeroSuplenteNombre[0] ;
         A56EnfermeroSuplenteApellido = T000121_A56EnfermeroSuplenteApellido[0] ;
         n56EnfermeroSuplenteApellido = T000121_n56EnfermeroSuplenteApellido[0] ;
         pr_default.close(19);
         if ( A51EnfermeroSuplenteId == AV7EnfermeroTitularID )
         {
            GX_msglist.addItem("El enfermero suplente y el titular no pueden ser el mismo", 1, "ENFERMEROSUPLENTEID");
            AnyError = 1 ;
            GX_FocusControl = edtEnfermeroSuplenteId_Internalname ;
         }
         dynload_actions( ) ;
         if ( AnyError == 1 )
         {
            A52EnfermeroSuplenteNombre = "" ;
            n52EnfermeroSuplenteNombre = false ;
            A56EnfermeroSuplenteApellido = "" ;
            n56EnfermeroSuplenteApellido = false ;
         }
         isValidOutput.Add((Object)(StringUtil.RTrim( A52EnfermeroSuplenteNombre)));
         isValidOutput.Add((Object)(StringUtil.RTrim( A56EnfermeroSuplenteApellido)));
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
         pr_default.close(21);
         pr_default.close(11);
         pr_default.close(10);
         pr_default.close(17);
         pr_default.close(18);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         sPrefix = "" ;
         scmdbuf = "" ;
         gxfirstwebparm = "" ;
         gxfirstwebparm_bkp = "" ;
         A17MedicoEstadoCivil = "" ;
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
         lblTextblockmedicoid_Jsonclick = "" ;
         lblTextblockmediconombre_Jsonclick = "" ;
         A13MedicoNombre = "" ;
         lblTextblockmedicoapellido_Jsonclick = "" ;
         A14MedicoApellido = "" ;
         lblTextblockmedicodomicilio_Jsonclick = "" ;
         A15MedicoDomicilio = "" ;
         lblTextblockmedicotelefono_Jsonclick = "" ;
         A16MedicoTelefono = "" ;
         lblTextblockmedicoestadocivil_Jsonclick = "" ;
         lblTextblockmedicofechaingreso_Jsonclick = "" ;
         A18MedicoFechaIngreso = DateTime.MinValue ;
         lblTextblockespecialidadid_Jsonclick = "" ;
         lblTextblockespecialidaddescripcion_Jsonclick = "" ;
         A10EspecialidadDescripcion = "" ;
         lblTextblockenfermerotitularid_Jsonclick = "" ;
         lblTextblockenfermerotitularnombre_Jsonclick = "" ;
         A47EnfermeroTitularNombre = "" ;
         lblTextblockenfermerotitularapellido_Jsonclick = "" ;
         A48EnfermeroTitularApellido = "" ;
         lblTextblockenfermerosuplenteid_Jsonclick = "" ;
         lblTextblockenfermerosuplentenombre_Jsonclick = "" ;
         A52EnfermeroSuplenteNombre = "" ;
         lblTextblockenfermerosuplenteapellido_Jsonclick = "" ;
         A56EnfermeroSuplenteApellido = "" ;
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
         Z13MedicoNombre = "" ;
         Z14MedicoApellido = "" ;
         Z15MedicoDomicilio = "" ;
         Z16MedicoTelefono = "" ;
         Z17MedicoEstadoCivil = "" ;
         Z18MedicoFechaIngreso = DateTime.MinValue ;
         Gx_mode = "" ;
         sEvt = "" ;
         EvtGridId = "" ;
         EvtRowId = "" ;
         sEvtType = "" ;
         Z10EspecialidadDescripcion = "" ;
         Z47EnfermeroTitularNombre = "" ;
         Z48EnfermeroTitularApellido = "" ;
         Z52EnfermeroSuplenteNombre = "" ;
         Z56EnfermeroSuplenteApellido = "" ;
         T00017_A12MedicoId = new int[1] ;
         T00017_A13MedicoNombre = new String[] {""} ;
         T00017_A14MedicoApellido = new String[] {""} ;
         T00017_A15MedicoDomicilio = new String[] {""} ;
         T00017_A16MedicoTelefono = new String[] {""} ;
         T00017_A17MedicoEstadoCivil = new String[] {""} ;
         T00017_A18MedicoFechaIngreso = new DateTime[] {DateTime.MinValue} ;
         T00017_A10EspecialidadDescripcion = new String[] {""} ;
         T00017_A47EnfermeroTitularNombre = new String[] {""} ;
         T00017_n47EnfermeroTitularNombre = new bool[] {false} ;
         T00017_A48EnfermeroTitularApellido = new String[] {""} ;
         T00017_n48EnfermeroTitularApellido = new bool[] {false} ;
         T00017_A52EnfermeroSuplenteNombre = new String[] {""} ;
         T00017_n52EnfermeroSuplenteNombre = new bool[] {false} ;
         T00017_A56EnfermeroSuplenteApellido = new String[] {""} ;
         T00017_n56EnfermeroSuplenteApellido = new bool[] {false} ;
         T00017_A9EspecialidadId = new int[1] ;
         T00017_A46EnfermeroTitularId = new int[1] ;
         T00017_A51EnfermeroSuplenteId = new int[1] ;
         T00014_A10EspecialidadDescripcion = new String[] {""} ;
         T00015_A47EnfermeroTitularNombre = new String[] {""} ;
         T00015_n47EnfermeroTitularNombre = new bool[] {false} ;
         T00015_A48EnfermeroTitularApellido = new String[] {""} ;
         T00015_n48EnfermeroTitularApellido = new bool[] {false} ;
         T00016_A52EnfermeroSuplenteNombre = new String[] {""} ;
         T00016_n52EnfermeroSuplenteNombre = new bool[] {false} ;
         T00016_A56EnfermeroSuplenteApellido = new String[] {""} ;
         T00016_n56EnfermeroSuplenteApellido = new bool[] {false} ;
         T00018_A10EspecialidadDescripcion = new String[] {""} ;
         T00019_A47EnfermeroTitularNombre = new String[] {""} ;
         T00019_n47EnfermeroTitularNombre = new bool[] {false} ;
         T00019_A48EnfermeroTitularApellido = new String[] {""} ;
         T00019_n48EnfermeroTitularApellido = new bool[] {false} ;
         T000110_A52EnfermeroSuplenteNombre = new String[] {""} ;
         T000110_n52EnfermeroSuplenteNombre = new bool[] {false} ;
         T000110_A56EnfermeroSuplenteApellido = new String[] {""} ;
         T000110_n56EnfermeroSuplenteApellido = new bool[] {false} ;
         T000111_A12MedicoId = new int[1] ;
         T00013_A12MedicoId = new int[1] ;
         T00013_A13MedicoNombre = new String[] {""} ;
         T00013_A14MedicoApellido = new String[] {""} ;
         T00013_A15MedicoDomicilio = new String[] {""} ;
         T00013_A16MedicoTelefono = new String[] {""} ;
         T00013_A17MedicoEstadoCivil = new String[] {""} ;
         T00013_A18MedicoFechaIngreso = new DateTime[] {DateTime.MinValue} ;
         T00013_A9EspecialidadId = new int[1] ;
         T00013_A46EnfermeroTitularId = new int[1] ;
         T00013_A51EnfermeroSuplenteId = new int[1] ;
         sMode1 = "" ;
         T000112_A12MedicoId = new int[1] ;
         T000113_A12MedicoId = new int[1] ;
         T000114_A12MedicoId = new int[1] ;
         T000114_A13MedicoNombre = new String[] {""} ;
         T000114_A14MedicoApellido = new String[] {""} ;
         T000114_A15MedicoDomicilio = new String[] {""} ;
         T000114_A16MedicoTelefono = new String[] {""} ;
         T000114_A17MedicoEstadoCivil = new String[] {""} ;
         T000114_A18MedicoFechaIngreso = new DateTime[] {DateTime.MinValue} ;
         T000114_A9EspecialidadId = new int[1] ;
         T000114_A46EnfermeroTitularId = new int[1] ;
         T000114_A51EnfermeroSuplenteId = new int[1] ;
         T000116_A12MedicoId = new int[1] ;
         T000119_A10EspecialidadDescripcion = new String[] {""} ;
         T000120_A47EnfermeroTitularNombre = new String[] {""} ;
         T000120_n47EnfermeroTitularNombre = new bool[] {false} ;
         T000120_A48EnfermeroTitularApellido = new String[] {""} ;
         T000120_n48EnfermeroTitularApellido = new bool[] {false} ;
         T000121_A52EnfermeroSuplenteNombre = new String[] {""} ;
         T000121_n52EnfermeroSuplenteNombre = new bool[] {false} ;
         T000121_A56EnfermeroSuplenteApellido = new String[] {""} ;
         T000121_n56EnfermeroSuplenteApellido = new bool[] {false} ;
         T000122_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         T000122_A12MedicoId = new int[1] ;
         T000122_A60TurnoId = new short[1] ;
         T000123_A12MedicoId = new int[1] ;
         sDynURL = "" ;
         FormProcess = "" ;
         GXt_char2 = "" ;
         GXt_char1 = "" ;
         GXt_char3 = "" ;
         isValidOutput = new GxUnknownObjectCollection();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.medico__default(),
            new Object[][] {
                new Object[] {
               T00012_A12MedicoId, T00012_A13MedicoNombre, T00012_A14MedicoApellido, T00012_A15MedicoDomicilio, T00012_A16MedicoTelefono, T00012_A17MedicoEstadoCivil, T00012_A18MedicoFechaIngreso, T00012_A9EspecialidadId, T00012_A46EnfermeroTitularId, T00012_A51EnfermeroSuplenteId
               }
               , new Object[] {
               T00013_A12MedicoId, T00013_A13MedicoNombre, T00013_A14MedicoApellido, T00013_A15MedicoDomicilio, T00013_A16MedicoTelefono, T00013_A17MedicoEstadoCivil, T00013_A18MedicoFechaIngreso, T00013_A9EspecialidadId, T00013_A46EnfermeroTitularId, T00013_A51EnfermeroSuplenteId
               }
               , new Object[] {
               T00014_A10EspecialidadDescripcion
               }
               , new Object[] {
               T00015_A47EnfermeroTitularNombre, T00015_n47EnfermeroTitularNombre, T00015_A48EnfermeroTitularApellido, T00015_n48EnfermeroTitularApellido
               }
               , new Object[] {
               T00016_A52EnfermeroSuplenteNombre, T00016_n52EnfermeroSuplenteNombre, T00016_A56EnfermeroSuplenteApellido, T00016_n56EnfermeroSuplenteApellido
               }
               , new Object[] {
               T00017_A12MedicoId, T00017_A13MedicoNombre, T00017_A14MedicoApellido, T00017_A15MedicoDomicilio, T00017_A16MedicoTelefono, T00017_A17MedicoEstadoCivil, T00017_A18MedicoFechaIngreso, T00017_A10EspecialidadDescripcion, T00017_A47EnfermeroTitularNombre, T00017_n47EnfermeroTitularNombre,
               T00017_A48EnfermeroTitularApellido, T00017_n48EnfermeroTitularApellido, T00017_A52EnfermeroSuplenteNombre, T00017_n52EnfermeroSuplenteNombre, T00017_A56EnfermeroSuplenteApellido, T00017_n56EnfermeroSuplenteApellido, T00017_A9EspecialidadId, T00017_A46EnfermeroTitularId, T00017_A51EnfermeroSuplenteId
               }
               , new Object[] {
               T00018_A10EspecialidadDescripcion
               }
               , new Object[] {
               T00019_A47EnfermeroTitularNombre, T00019_n47EnfermeroTitularNombre, T00019_A48EnfermeroTitularApellido, T00019_n48EnfermeroTitularApellido
               }
               , new Object[] {
               T000110_A52EnfermeroSuplenteNombre, T000110_n52EnfermeroSuplenteNombre, T000110_A56EnfermeroSuplenteApellido, T000110_n56EnfermeroSuplenteApellido
               }
               , new Object[] {
               T000111_A12MedicoId
               }
               , new Object[] {
               T000112_A12MedicoId
               }
               , new Object[] {
               T000113_A12MedicoId
               }
               , new Object[] {
               T000114_A12MedicoId, T000114_A13MedicoNombre, T000114_A14MedicoApellido, T000114_A15MedicoDomicilio, T000114_A16MedicoTelefono, T000114_A17MedicoEstadoCivil, T000114_A18MedicoFechaIngreso, T000114_A9EspecialidadId, T000114_A46EnfermeroTitularId, T000114_A51EnfermeroSuplenteId
               }
               , new Object[] {
               }
               , new Object[] {
               T000116_A12MedicoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000119_A10EspecialidadDescripcion
               }
               , new Object[] {
               T000120_A47EnfermeroTitularNombre, T000120_n47EnfermeroTitularNombre, T000120_A48EnfermeroTitularApellido, T000120_n48EnfermeroTitularApellido
               }
               , new Object[] {
               T000121_A52EnfermeroSuplenteNombre, T000121_n52EnfermeroSuplenteNombre, T000121_A56EnfermeroSuplenteApellido, T000121_n56EnfermeroSuplenteApellido
               }
               , new Object[] {
               T000122_A43ConsultaFecha, T000122_A12MedicoId, T000122_A60TurnoId
               }
               , new Object[] {
               T000123_A12MedicoId
               }
            }
         );
      }

      private short RcdFound1 ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int A9EspecialidadId ;
      private int A46EnfermeroTitularId ;
      private int A51EnfermeroSuplenteId ;
      private int trnEnded ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int A12MedicoId ;
      private int edtMedicoId_Enabled ;
      private int edtMedicoNombre_Enabled ;
      private int edtMedicoApellido_Enabled ;
      private int edtMedicoDomicilio_Enabled ;
      private int edtMedicoTelefono_Enabled ;
      private int edtMedicoFechaIngreso_Enabled ;
      private int edtEspecialidadId_Enabled ;
      private int imgprompt_9_Visible ;
      private int edtEspecialidadDescripcion_Enabled ;
      private int edtEnfermeroTitularId_Enabled ;
      private int imgprompt_46_Visible ;
      private int edtEnfermeroTitularNombre_Enabled ;
      private int edtEnfermeroTitularApellido_Enabled ;
      private int edtEnfermeroSuplenteId_Enabled ;
      private int imgprompt_51_Visible ;
      private int edtEnfermeroSuplenteNombre_Enabled ;
      private int edtEnfermeroSuplenteApellido_Enabled ;
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
      private int Z46EnfermeroTitularId ;
      private int Z51EnfermeroSuplenteId ;
      private int AV7EnfermeroTitularID ;
      private int idxLst ;
      private int ZV7EnfermeroTitularID ;
      private String sPrefix ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String A17MedicoEstadoCivil ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String GX_FocusControl ;
      private String edtMedicoNombre_Internalname ;
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
      private String lblTextblockmedicoid_Internalname ;
      private String lblTextblockmedicoid_Jsonclick ;
      private String edtMedicoId_Internalname ;
      private String edtMedicoId_Jsonclick ;
      private String lblTextblockmediconombre_Internalname ;
      private String lblTextblockmediconombre_Jsonclick ;
      private String A13MedicoNombre ;
      private String edtMedicoNombre_Jsonclick ;
      private String lblTextblockmedicoapellido_Internalname ;
      private String lblTextblockmedicoapellido_Jsonclick ;
      private String edtMedicoApellido_Internalname ;
      private String A14MedicoApellido ;
      private String edtMedicoApellido_Jsonclick ;
      private String lblTextblockmedicodomicilio_Internalname ;
      private String lblTextblockmedicodomicilio_Jsonclick ;
      private String edtMedicoDomicilio_Internalname ;
      private String A15MedicoDomicilio ;
      private String edtMedicoDomicilio_Jsonclick ;
      private String lblTextblockmedicotelefono_Internalname ;
      private String lblTextblockmedicotelefono_Jsonclick ;
      private String edtMedicoTelefono_Internalname ;
      private String A16MedicoTelefono ;
      private String edtMedicoTelefono_Jsonclick ;
      private String lblTextblockmedicoestadocivil_Internalname ;
      private String lblTextblockmedicoestadocivil_Jsonclick ;
      private String cmbMedicoEstadoCivil_Internalname ;
      private String cmbMedicoEstadoCivil_Jsonclick ;
      private String lblTextblockmedicofechaingreso_Internalname ;
      private String lblTextblockmedicofechaingreso_Jsonclick ;
      private String edtMedicoFechaIngreso_Internalname ;
      private String edtMedicoFechaIngreso_Jsonclick ;
      private String lblTextblockespecialidadid_Internalname ;
      private String lblTextblockespecialidadid_Jsonclick ;
      private String edtEspecialidadId_Internalname ;
      private String edtEspecialidadId_Jsonclick ;
      private String imgprompt_9_Internalname ;
      private String imgprompt_9_Link ;
      private String lblTextblockespecialidaddescripcion_Internalname ;
      private String lblTextblockespecialidaddescripcion_Jsonclick ;
      private String edtEspecialidadDescripcion_Internalname ;
      private String A10EspecialidadDescripcion ;
      private String edtEspecialidadDescripcion_Jsonclick ;
      private String lblTextblockenfermerotitularid_Internalname ;
      private String lblTextblockenfermerotitularid_Jsonclick ;
      private String edtEnfermeroTitularId_Internalname ;
      private String edtEnfermeroTitularId_Jsonclick ;
      private String imgprompt_46_Internalname ;
      private String imgprompt_46_Link ;
      private String lblTextblockenfermerotitularnombre_Internalname ;
      private String lblTextblockenfermerotitularnombre_Jsonclick ;
      private String edtEnfermeroTitularNombre_Internalname ;
      private String A47EnfermeroTitularNombre ;
      private String edtEnfermeroTitularNombre_Jsonclick ;
      private String lblTextblockenfermerotitularapellido_Internalname ;
      private String lblTextblockenfermerotitularapellido_Jsonclick ;
      private String edtEnfermeroTitularApellido_Internalname ;
      private String A48EnfermeroTitularApellido ;
      private String edtEnfermeroTitularApellido_Jsonclick ;
      private String lblTextblockenfermerosuplenteid_Internalname ;
      private String lblTextblockenfermerosuplenteid_Jsonclick ;
      private String edtEnfermeroSuplenteId_Internalname ;
      private String edtEnfermeroSuplenteId_Jsonclick ;
      private String imgprompt_51_Internalname ;
      private String imgprompt_51_Link ;
      private String lblTextblockenfermerosuplentenombre_Internalname ;
      private String lblTextblockenfermerosuplentenombre_Jsonclick ;
      private String edtEnfermeroSuplenteNombre_Internalname ;
      private String A52EnfermeroSuplenteNombre ;
      private String edtEnfermeroSuplenteNombre_Jsonclick ;
      private String lblTextblockenfermerosuplenteapellido_Internalname ;
      private String lblTextblockenfermerosuplenteapellido_Jsonclick ;
      private String edtEnfermeroSuplenteApellido_Internalname ;
      private String A56EnfermeroSuplenteApellido ;
      private String edtEnfermeroSuplenteApellido_Jsonclick ;
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
      private String Z13MedicoNombre ;
      private String Z14MedicoApellido ;
      private String Z15MedicoDomicilio ;
      private String Z16MedicoTelefono ;
      private String Z17MedicoEstadoCivil ;
      private String Gx_mode ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String Z10EspecialidadDescripcion ;
      private String Z47EnfermeroTitularNombre ;
      private String Z48EnfermeroTitularApellido ;
      private String Z52EnfermeroSuplenteNombre ;
      private String Z56EnfermeroSuplenteApellido ;
      private String sMode1 ;
      private String sDynURL ;
      private String FormProcess ;
      private String GXt_char2 ;
      private String GXt_char1 ;
      private String GXt_char3 ;
      private DateTime A18MedicoFechaIngreso ;
      private DateTime Z18MedicoFechaIngreso ;
      private bool entryPointCalled ;
      private bool wbErr ;
      private bool n47EnfermeroTitularNombre ;
      private bool n48EnfermeroTitularApellido ;
      private bool n52EnfermeroSuplenteNombre ;
      private bool n56EnfermeroSuplenteApellido ;
      private bool Gx_longc ;
      private GxUnknownObjectCollection isValidOutput ;
      private GXMasterPage MasterPageObj ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbMedicoEstadoCivil ;
      private IDataStoreProvider pr_default ;
      private int[] T00017_A12MedicoId ;
      private String[] T00017_A13MedicoNombre ;
      private String[] T00017_A14MedicoApellido ;
      private String[] T00017_A15MedicoDomicilio ;
      private String[] T00017_A16MedicoTelefono ;
      private String[] T00017_A17MedicoEstadoCivil ;
      private DateTime[] T00017_A18MedicoFechaIngreso ;
      private String[] T00017_A10EspecialidadDescripcion ;
      private String[] T00017_A47EnfermeroTitularNombre ;
      private bool[] T00017_n47EnfermeroTitularNombre ;
      private String[] T00017_A48EnfermeroTitularApellido ;
      private bool[] T00017_n48EnfermeroTitularApellido ;
      private String[] T00017_A52EnfermeroSuplenteNombre ;
      private bool[] T00017_n52EnfermeroSuplenteNombre ;
      private String[] T00017_A56EnfermeroSuplenteApellido ;
      private bool[] T00017_n56EnfermeroSuplenteApellido ;
      private int[] T00017_A9EspecialidadId ;
      private int[] T00017_A46EnfermeroTitularId ;
      private int[] T00017_A51EnfermeroSuplenteId ;
      private String[] T00014_A10EspecialidadDescripcion ;
      private String[] T00015_A47EnfermeroTitularNombre ;
      private bool[] T00015_n47EnfermeroTitularNombre ;
      private String[] T00015_A48EnfermeroTitularApellido ;
      private bool[] T00015_n48EnfermeroTitularApellido ;
      private String[] T00016_A52EnfermeroSuplenteNombre ;
      private bool[] T00016_n52EnfermeroSuplenteNombre ;
      private String[] T00016_A56EnfermeroSuplenteApellido ;
      private bool[] T00016_n56EnfermeroSuplenteApellido ;
      private String[] T00018_A10EspecialidadDescripcion ;
      private String[] T00019_A47EnfermeroTitularNombre ;
      private bool[] T00019_n47EnfermeroTitularNombre ;
      private String[] T00019_A48EnfermeroTitularApellido ;
      private bool[] T00019_n48EnfermeroTitularApellido ;
      private String[] T000110_A52EnfermeroSuplenteNombre ;
      private bool[] T000110_n52EnfermeroSuplenteNombre ;
      private String[] T000110_A56EnfermeroSuplenteApellido ;
      private bool[] T000110_n56EnfermeroSuplenteApellido ;
      private int[] T000111_A12MedicoId ;
      private int[] T00013_A12MedicoId ;
      private String[] T00013_A13MedicoNombre ;
      private String[] T00013_A14MedicoApellido ;
      private String[] T00013_A15MedicoDomicilio ;
      private String[] T00013_A16MedicoTelefono ;
      private String[] T00013_A17MedicoEstadoCivil ;
      private DateTime[] T00013_A18MedicoFechaIngreso ;
      private int[] T00013_A9EspecialidadId ;
      private int[] T00013_A46EnfermeroTitularId ;
      private int[] T00013_A51EnfermeroSuplenteId ;
      private int[] T000112_A12MedicoId ;
      private int[] T000113_A12MedicoId ;
      private int[] T000114_A12MedicoId ;
      private String[] T000114_A13MedicoNombre ;
      private String[] T000114_A14MedicoApellido ;
      private String[] T000114_A15MedicoDomicilio ;
      private String[] T000114_A16MedicoTelefono ;
      private String[] T000114_A17MedicoEstadoCivil ;
      private DateTime[] T000114_A18MedicoFechaIngreso ;
      private int[] T000114_A9EspecialidadId ;
      private int[] T000114_A46EnfermeroTitularId ;
      private int[] T000114_A51EnfermeroSuplenteId ;
      private int[] T000116_A12MedicoId ;
      private String[] T000119_A10EspecialidadDescripcion ;
      private String[] T000120_A47EnfermeroTitularNombre ;
      private bool[] T000120_n47EnfermeroTitularNombre ;
      private String[] T000120_A48EnfermeroTitularApellido ;
      private bool[] T000120_n48EnfermeroTitularApellido ;
      private String[] T000121_A52EnfermeroSuplenteNombre ;
      private bool[] T000121_n52EnfermeroSuplenteNombre ;
      private String[] T000121_A56EnfermeroSuplenteApellido ;
      private bool[] T000121_n56EnfermeroSuplenteApellido ;
      private DateTime[] T000122_A43ConsultaFecha ;
      private int[] T000122_A12MedicoId ;
      private short[] T000122_A60TurnoId ;
      private int[] T000123_A12MedicoId ;
      private int[] T00012_A12MedicoId ;
      private String[] T00012_A13MedicoNombre ;
      private String[] T00012_A14MedicoApellido ;
      private String[] T00012_A15MedicoDomicilio ;
      private String[] T00012_A16MedicoTelefono ;
      private String[] T00012_A17MedicoEstadoCivil ;
      private DateTime[] T00012_A18MedicoFechaIngreso ;
      private int[] T00012_A9EspecialidadId ;
      private int[] T00012_A46EnfermeroTitularId ;
      private int[] T00012_A51EnfermeroSuplenteId ;
      private GXWebForm Form ;
   }

   public class medico__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00012 ;
          prmT00012 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00017 ;
          prmT00017 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00014 ;
          prmT00014 = new Object[] {
          new Object[] {"@EspecialidadId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00015 ;
          prmT00015 = new Object[] {
          new Object[] {"@EnfermeroTitularId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00016 ;
          prmT00016 = new Object[] {
          new Object[] {"@EnfermeroSuplenteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00018 ;
          prmT00018 = new Object[] {
          new Object[] {"@EspecialidadId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00019 ;
          prmT00019 = new Object[] {
          new Object[] {"@EnfermeroTitularId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000110 ;
          prmT000110 = new Object[] {
          new Object[] {"@EnfermeroSuplenteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000111 ;
          prmT000111 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00013 ;
          prmT00013 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000112 ;
          prmT000112 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000113 ;
          prmT000113 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000114 ;
          prmT000114 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000115 ;
          prmT000115 = new Object[] {
          new Object[] {"@MedicoNombre",SqlDbType.Char,20,0} ,
          new Object[] {"@MedicoApellido",SqlDbType.Char,20,0} ,
          new Object[] {"@MedicoDomicilio",SqlDbType.Char,40,0} ,
          new Object[] {"@MedicoTelefono",SqlDbType.Char,20,0} ,
          new Object[] {"@MedicoEstadoCivil",SqlDbType.Char,1,0} ,
          new Object[] {"@MedicoFechaIngreso",SqlDbType.DateTime,8,0} ,
          new Object[] {"@EspecialidadId",SqlDbType.Int,6,0} ,
          new Object[] {"@EnfermeroTitularId",SqlDbType.Int,6,0} ,
          new Object[] {"@EnfermeroSuplenteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000116 ;
          prmT000116 = new Object[] {
          } ;
          Object[] prmT000117 ;
          prmT000117 = new Object[] {
          new Object[] {"@MedicoNombre",SqlDbType.Char,20,0} ,
          new Object[] {"@MedicoApellido",SqlDbType.Char,20,0} ,
          new Object[] {"@MedicoDomicilio",SqlDbType.Char,40,0} ,
          new Object[] {"@MedicoTelefono",SqlDbType.Char,20,0} ,
          new Object[] {"@MedicoEstadoCivil",SqlDbType.Char,1,0} ,
          new Object[] {"@MedicoFechaIngreso",SqlDbType.DateTime,8,0} ,
          new Object[] {"@EspecialidadId",SqlDbType.Int,6,0} ,
          new Object[] {"@EnfermeroTitularId",SqlDbType.Int,6,0} ,
          new Object[] {"@EnfermeroSuplenteId",SqlDbType.Int,6,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000118 ;
          prmT000118 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000122 ;
          prmT000122 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000123 ;
          prmT000123 = new Object[] {
          } ;
          Object[] prmT000119 ;
          prmT000119 = new Object[] {
          new Object[] {"@EspecialidadId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000120 ;
          prmT000120 = new Object[] {
          new Object[] {"@EnfermeroTitularId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000121 ;
          prmT000121 = new Object[] {
          new Object[] {"@EnfermeroSuplenteId",SqlDbType.Int,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("T00012", "SELECT [MedicoId], [MedicoNombre], [MedicoApellido], [MedicoDomicilio], [MedicoTelefono], [MedicoEstadoCivil], [MedicoFechaIngreso], [EspecialidadId], [EnfermeroTitularId] AS EnfermeroTitularId, [EnfermeroSuplenteId] AS EnfermeroSuplenteId FROM [Medico] WITH (UPDLOCK) WHERE [MedicoId] = @MedicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1,0,true,false )
             ,new CursorDef("T00013", "SELECT [MedicoId], [MedicoNombre], [MedicoApellido], [MedicoDomicilio], [MedicoTelefono], [MedicoEstadoCivil], [MedicoFechaIngreso], [EspecialidadId], [EnfermeroTitularId] AS EnfermeroTitularId, [EnfermeroSuplenteId] AS EnfermeroSuplenteId FROM [Medico] WITH (NOLOCK) WHERE [MedicoId] = @MedicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1,0,true,false )
             ,new CursorDef("T00014", "SELECT [EspecialidadDescripcion] FROM [Especialidad] WITH (NOLOCK) WHERE [EspecialidadId] = @EspecialidadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,1,0,true,false )
             ,new CursorDef("T00015", "SELECT [EnfermeroNombre] AS EnfermeroTitularNombre, [EnfermeroApellido] AS EnfermeroTitularApellido FROM [Enfermero] WITH (NOLOCK) WHERE [EnfermeroId] = @EnfermeroTitularId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,1,0,true,false )
             ,new CursorDef("T00016", "SELECT [EnfermeroNombre] AS EnfermeroSuplenteNombre, [EnfermeroApellido] AS EnfermeroSuplenteApellido FROM [Enfermero] WITH (NOLOCK) WHERE [EnfermeroId] = @EnfermeroSuplenteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,1,0,true,false )
             ,new CursorDef("T00017", "SELECT TM1.[MedicoId], TM1.[MedicoNombre], TM1.[MedicoApellido], TM1.[MedicoDomicilio], TM1.[MedicoTelefono], TM1.[MedicoEstadoCivil], TM1.[MedicoFechaIngreso], T2.[EspecialidadDescripcion], T3.[EnfermeroNombre] AS EnfermeroTitularNombre, T3.[EnfermeroApellido] AS EnfermeroTitularApellido, T4.[EnfermeroNombre] AS EnfermeroSuplenteNombre, T4.[EnfermeroApellido] AS EnfermeroSuplenteApellido, TM1.[EspecialidadId], TM1.[EnfermeroTitularId] AS EnfermeroTitularId, TM1.[EnfermeroSuplenteId] AS EnfermeroSuplenteId FROM ((([Medico] TM1 WITH (NOLOCK) INNER JOIN [Especialidad] T2 WITH (NOLOCK) ON T2.[EspecialidadId] = TM1.[EspecialidadId]) INNER JOIN [Enfermero] T3 WITH (NOLOCK) ON T3.[EnfermeroId] = TM1.[EnfermeroTitularId]) INNER JOIN [Enfermero] T4 WITH (NOLOCK) ON T4.[EnfermeroId] = TM1.[EnfermeroSuplenteId]) WHERE TM1.[MedicoId] = @MedicoId ORDER BY TM1.[MedicoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,100,0,true,false )
             ,new CursorDef("T00018", "SELECT [EspecialidadDescripcion] FROM [Especialidad] WITH (NOLOCK) WHERE [EspecialidadId] = @EspecialidadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00018,1,0,true,false )
             ,new CursorDef("T00019", "SELECT [EnfermeroNombre] AS EnfermeroTitularNombre, [EnfermeroApellido] AS EnfermeroTitularApellido FROM [Enfermero] WITH (NOLOCK) WHERE [EnfermeroId] = @EnfermeroTitularId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00019,1,0,true,false )
             ,new CursorDef("T000110", "SELECT [EnfermeroNombre] AS EnfermeroSuplenteNombre, [EnfermeroApellido] AS EnfermeroSuplenteApellido FROM [Enfermero] WITH (NOLOCK) WHERE [EnfermeroId] = @EnfermeroSuplenteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000110,1,0,true,false )
             ,new CursorDef("T000111", "SELECT [MedicoId] FROM [Medico] WITH (NOLOCK) WHERE [MedicoId] = @MedicoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000111,1,0,true,false )
             ,new CursorDef("T000112", "SELECT TOP 1 [MedicoId] FROM [Medico] WITH (NOLOCK) WHERE ( [MedicoId] > @MedicoId) ORDER BY [MedicoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000112,1,0,true,true )
             ,new CursorDef("T000113", "SELECT TOP 1 [MedicoId] FROM [Medico] WITH (NOLOCK) WHERE ( [MedicoId] < @MedicoId) ORDER BY [MedicoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000113,1,0,true,true )
             ,new CursorDef("T000114", "SELECT [MedicoId], [MedicoNombre], [MedicoApellido], [MedicoDomicilio], [MedicoTelefono], [MedicoEstadoCivil], [MedicoFechaIngreso], [EspecialidadId], [EnfermeroTitularId] AS EnfermeroTitularId, [EnfermeroSuplenteId] AS EnfermeroSuplenteId FROM [Medico] WITH (UPDLOCK) WHERE [MedicoId] = @MedicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000114,1,0,true,false )
             ,new CursorDef("T000115", "INSERT INTO [Medico] ([MedicoNombre], [MedicoApellido], [MedicoDomicilio], [MedicoTelefono], [MedicoEstadoCivil], [MedicoFechaIngreso], [EspecialidadId], [EnfermeroTitularId], [EnfermeroSuplenteId]) VALUES (@MedicoNombre, @MedicoApellido, @MedicoDomicilio, @MedicoTelefono, @MedicoEstadoCivil, @MedicoFechaIngreso, @EspecialidadId, @EnfermeroTitularId, @EnfermeroSuplenteId)", GxErrorMask.GX_NOMASK,prmT000115)
             ,new CursorDef("T000116", "SELECT Ident_Current('[Medico]') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000116,1,0,true,false )
             ,new CursorDef("T000117", "UPDATE [Medico] SET [MedicoNombre]=@MedicoNombre, [MedicoApellido]=@MedicoApellido, [MedicoDomicilio]=@MedicoDomicilio, [MedicoTelefono]=@MedicoTelefono, [MedicoEstadoCivil]=@MedicoEstadoCivil, [MedicoFechaIngreso]=@MedicoFechaIngreso, [EspecialidadId]=@EspecialidadId, [EnfermeroTitularId]=@EnfermeroTitularId, [EnfermeroSuplenteId]=@EnfermeroSuplenteId  WHERE [MedicoId] = @MedicoId", GxErrorMask.GX_NOMASK,prmT000117)
             ,new CursorDef("T000118", "DELETE FROM [Medico]  WHERE [MedicoId] = @MedicoId", GxErrorMask.GX_NOMASK,prmT000118)
             ,new CursorDef("T000119", "SELECT [EspecialidadDescripcion] FROM [Especialidad] WITH (NOLOCK) WHERE [EspecialidadId] = @EspecialidadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000119,1,0,true,false )
             ,new CursorDef("T000120", "SELECT [EnfermeroNombre] AS EnfermeroTitularNombre, [EnfermeroApellido] AS EnfermeroTitularApellido FROM [Enfermero] WITH (NOLOCK) WHERE [EnfermeroId] = @EnfermeroTitularId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000120,1,0,true,false )
             ,new CursorDef("T000121", "SELECT [EnfermeroNombre] AS EnfermeroSuplenteNombre, [EnfermeroApellido] AS EnfermeroSuplenteApellido FROM [Enfermero] WITH (NOLOCK) WHERE [EnfermeroId] = @EnfermeroSuplenteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000121,1,0,true,false )
             ,new CursorDef("T000122", "SELECT TOP 1 [ConsultaFecha], [MedicoId], [TurnoId] FROM [Consulta] WITH (NOLOCK) WHERE [MedicoId] = @MedicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000122,1,0,true,true )
             ,new CursorDef("T000123", "SELECT [MedicoId] FROM [Medico] WITH (NOLOCK) ORDER BY [MedicoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000123,100,0,true,false )
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
                ((String[]) buf[4])[0] = rslt.getString(5, 20) ;
                ((String[]) buf[5])[0] = rslt.getString(6, 1) ;
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7) ;
                ((int[]) buf[7])[0] = rslt.getInt(8) ;
                ((int[]) buf[8])[0] = rslt.getInt(9) ;
                ((int[]) buf[9])[0] = rslt.getInt(10) ;
                break;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                ((String[]) buf[3])[0] = rslt.getString(4, 40) ;
                ((String[]) buf[4])[0] = rslt.getString(5, 20) ;
                ((String[]) buf[5])[0] = rslt.getString(6, 1) ;
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7) ;
                ((int[]) buf[7])[0] = rslt.getInt(8) ;
                ((int[]) buf[8])[0] = rslt.getInt(9) ;
                ((int[]) buf[9])[0] = rslt.getInt(10) ;
                break;
             case 2 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                break;
             case 3 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((String[]) buf[2])[0] = rslt.getString(2, 20) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                break;
             case 4 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((String[]) buf[2])[0] = rslt.getString(2, 20) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                break;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                ((String[]) buf[3])[0] = rslt.getString(4, 40) ;
                ((String[]) buf[4])[0] = rslt.getString(5, 20) ;
                ((String[]) buf[5])[0] = rslt.getString(6, 1) ;
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7) ;
                ((String[]) buf[7])[0] = rslt.getString(8, 20) ;
                ((String[]) buf[8])[0] = rslt.getString(9, 20) ;
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((String[]) buf[10])[0] = rslt.getString(10, 20) ;
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((String[]) buf[12])[0] = rslt.getString(11, 20) ;
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((String[]) buf[14])[0] = rslt.getString(12, 20) ;
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((int[]) buf[16])[0] = rslt.getInt(13) ;
                ((int[]) buf[17])[0] = rslt.getInt(14) ;
                ((int[]) buf[18])[0] = rslt.getInt(15) ;
                break;
             case 6 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                break;
             case 7 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((String[]) buf[2])[0] = rslt.getString(2, 20) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                break;
             case 8 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((String[]) buf[2])[0] = rslt.getString(2, 20) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                break;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                break;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                break;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                break;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                ((String[]) buf[3])[0] = rslt.getString(4, 40) ;
                ((String[]) buf[4])[0] = rslt.getString(5, 20) ;
                ((String[]) buf[5])[0] = rslt.getString(6, 1) ;
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7) ;
                ((int[]) buf[7])[0] = rslt.getInt(8) ;
                ((int[]) buf[8])[0] = rslt.getInt(9) ;
                ((int[]) buf[9])[0] = rslt.getInt(10) ;
                break;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                break;
             case 17 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                break;
             case 18 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((String[]) buf[2])[0] = rslt.getString(2, 20) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                break;
             case 19 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((String[]) buf[2])[0] = rslt.getString(2, 20) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                break;
             case 20 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                break;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
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
                stmt.SetParameter(1, (int)parms[0]);
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
                stmt.SetParameter(1, (int)parms[0]);
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
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 13 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (String)parms[2]);
                stmt.SetParameter(4, (String)parms[3]);
                stmt.SetParameter(5, (String)parms[4]);
                stmt.SetParameter(6, (DateTime)parms[5]);
                stmt.SetParameter(7, (int)parms[6]);
                stmt.SetParameter(8, (int)parms[7]);
                stmt.SetParameter(9, (int)parms[8]);
                break;
             case 15 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (String)parms[2]);
                stmt.SetParameter(4, (String)parms[3]);
                stmt.SetParameter(5, (String)parms[4]);
                stmt.SetParameter(6, (DateTime)parms[5]);
                stmt.SetParameter(7, (int)parms[6]);
                stmt.SetParameter(8, (int)parms[7]);
                stmt.SetParameter(9, (int)parms[8]);
                stmt.SetParameter(10, (int)parms[9]);
                break;
             case 16 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 17 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 18 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 19 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 20 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
       }
    }

 }

}
