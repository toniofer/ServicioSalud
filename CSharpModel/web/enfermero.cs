/*
               File: Enfermero
        Description: Enfermero
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/22/2010 4:0:32.60
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
   public class enfermero : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
               AV7EnfermeroId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7EnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV7EnfermeroId), 6, 0)));
            }
         }
         cmbEnfermeroEstadoCivil.Name = "ENFERMEROESTADOCIVIL" ;
         cmbEnfermeroEstadoCivil.WebTags = "" ;
         cmbEnfermeroEstadoCivil.addItem("S", "Soltero", 0);
         cmbEnfermeroEstadoCivil.addItem("C", "Casado", 0);
         cmbEnfermeroEstadoCivil.addItem("V", "Viudo", 0);
         cmbEnfermeroEstadoCivil.addItem("D", "Divorciado", 0);
         if ( ( cmbEnfermeroEstadoCivil.ItemCount > 0 ) && String.IsNullOrEmpty(StringUtil.RTrim( A24EnfermeroEstadoCivil)) )
         {
            A24EnfermeroEstadoCivil = cmbEnfermeroEstadoCivil.getItemValue(1) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A24EnfermeroEstadoCivil", A24EnfermeroEstadoCivil);
         }
         Form.Meta.addItem("Generator", "GeneXus C#", 0) ;
         Form.Meta.addItem("Version", "10_1_3-34981", 0) ;
         Form.Meta.addItem("Description", "Enfermero", 0) ;
         context.wjLoc = "" ;
         context.nUserReturn = 0 ;
         context.wbHandled = 0 ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         GX_FocusControl = edtEnfermeroNombre_Internalname ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         wbErr = false ;
         context.SetTheme("GeneXusX");
      }

      public enfermero( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public enfermero( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default") ;
      }

      public void release( )
      {
      }

      public void execute( String aP0_Gx_mode ,
                           int aP1_EnfermeroId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EnfermeroId = aP1_EnfermeroId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbEnfermeroEstadoCivil = new GXCombobox();
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
            wb_table1_2_033( true) ;
         }
         return  ;
      }

      protected void wb_table1_2_033e( bool wbgen )
      {
         if ( wbgen )
         {
         }
         /* Execute Exit event if defined. */
      }

      protected void wb_table1_2_033( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTablemain_Internalname, tblTablemain_Internalname, "", "TableBorder100x100", 0, "", "", 1, 2, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_5_033( true) ;
         }
         return  ;
      }

      protected void wb_table2_5_033e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Control Group */
            ClassString = "Group" ;
            StyleString = "" ;
            context.WriteHtmlText( "<fieldset id=\""+grpGroupdata_Internalname+"\""+" style=\"-moz-border-radius:3pt;\""+" class=\""+ClassString+"\">") ;
            context.WriteHtmlText( "<legend class=\""+ClassString+"Title"+"\">"+"Enfermero"+"</legend>") ;
            wb_table3_27_033( true) ;
         }
         return  ;
      }

      protected void wb_table3_27_033e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</fieldset>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_2_033e( true) ;
         }
         else
         {
            wb_table1_2_033e( false) ;
         }
      }

      protected void wb_table3_27_033( bool wbgen )
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
            wb_table4_33_033( true) ;
         }
         return  ;
      }

      protected void wb_table4_33_033e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"" ;
            ClassString = "BtnEnter" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtn_enter_Internalname, "Confirmar", "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, 1, "rounded", 5, bttBtn_enter_Jsonclick, "EENTER.", TempTags, "", "", "HLP_Enfermero.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"" ;
            ClassString = "BtnCancel" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtn_cancel_Internalname, "Cancelar", "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "rounded", 1, bttBtn_cancel_Jsonclick, "ECANCEL.", TempTags, "", "", "HLP_Enfermero.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"" ;
            ClassString = "BtnDelete" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtn_delete_Internalname, "Eliminar", "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, 0, "rounded", 5, bttBtn_delete_Jsonclick, "EDELETE.", TempTags, "", "", "HLP_Enfermero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_27_033e( true) ;
         }
         else
         {
            wb_table3_27_033e( false) ;
         }
      }

      protected void wb_table4_33_033( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblTextblockenfermeroid_Internalname, 1, 1, 0, "Id", "", "", "", 0, lblTextblockenfermeroid_Jsonclick, "", StyleString, ClassString, "HLP_Enfermero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtEnfermeroId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A20EnfermeroId), 6, 0, ",", "")), "", 6, "chr", 1, "row", 6, 1, edtEnfermeroId_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A20EnfermeroId), "ZZZZZ9"), "", 0, edtEnfermeroId_Jsonclick, "", 0, 1, -1, true, "right", "HLP_Enfermero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockenfermeronombre_Internalname, 1, 1, 0, "Nombre", "", "", "", 0, lblTextblockenfermeronombre_Jsonclick, "", StyleString, ClassString, "HLP_Enfermero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtEnfermeroNombre_Internalname, StringUtil.RTrim( A21EnfermeroNombre), "", 20, "chr", 1, "row", 20, 1, edtEnfermeroNombre_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A21EnfermeroNombre, "XXXXXXXXXXXXXXXXXXXX")), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(43);\"", 0, edtEnfermeroNombre_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Enfermero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockenfermeroapellido_Internalname, 1, 1, 0, "Apellido", "", "", "", 0, lblTextblockenfermeroapellido_Jsonclick, "", StyleString, ClassString, "HLP_Enfermero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtEnfermeroApellido_Internalname, StringUtil.RTrim( A22EnfermeroApellido), "", 20, "chr", 1, "row", 20, 1, edtEnfermeroApellido_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A22EnfermeroApellido, "XXXXXXXXXXXXXXXXXXXX")), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(48);\"", 0, edtEnfermeroApellido_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Enfermero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockenfermerodomicilio_Internalname, 1, 1, 0, "Domicilio", "", "", "", 0, lblTextblockenfermerodomicilio_Jsonclick, "", StyleString, ClassString, "HLP_Enfermero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtEnfermeroDomicilio_Internalname, StringUtil.RTrim( A23EnfermeroDomicilio), "", 40, "chr", 1, "row", 40, 1, edtEnfermeroDomicilio_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A23EnfermeroDomicilio, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(53);\"", 0, edtEnfermeroDomicilio_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Enfermero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockenfermeroestadocivil_Internalname, 1, 1, 0, "Estado Civil", "", "", "", 0, lblTextblockenfermeroestadocivil_Jsonclick, "", StyleString, ClassString, "HLP_Enfermero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"" ;
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbEnfermeroEstadoCivil, cmbEnfermeroEstadoCivil_Internalname, A24EnfermeroEstadoCivil, "", "char", 1, cmbEnfermeroEstadoCivil.Enabled, 0, 1, 0, 1, "chr", 0, "", StyleString, ClassString, "", 0, cmbEnfermeroEstadoCivil_Jsonclick, "", TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(58);\"", true, "HLP_Enfermero.htm");
            cmbEnfermeroEstadoCivil.CurrentValue = A24EnfermeroEstadoCivil ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, cmbEnfermeroEstadoCivil_Internalname, "Values", (String)(cmbEnfermeroEstadoCivil.ToJavascriptSource()));
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" class=\"td5\" >") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockenfermerofechaingreso_Internalname, 1, 1, 0, "Fecha Ingreso", "", "", "", 0, lblTextblockenfermerofechaingreso_Jsonclick, "", StyleString, ClassString, "HLP_Enfermero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            if ( ( edtEnfermeroFechaIngreso_Enabled == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlText( "<table id=\""+edtEnfermeroFechaIngreso_Internalname+"_dp_container\" cellpadding=\"0\" cellspacing=\"0\"><tr><td>") ;
            }
            GxWebStd.gx_single_line_edit( context, edtEnfermeroFechaIngreso_Internalname, context.localUtil.Format(A25EnfermeroFechaIngreso, "99/99/99"), "", 8, "chr", 1, "row", 8, 1, edtEnfermeroFechaIngreso_Enabled, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( A25EnfermeroFechaIngreso, "99/99/99"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(63);\"", 0, edtEnfermeroFechaIngreso_Jsonclick, "", 0, 1, -1, true, "right", "HLP_Enfermero.htm");
            if ( ( edtEnfermeroFechaIngreso_Enabled == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlTextNl( "</td><td>") ;
               context.WriteHtmlText( "<img src=\""+context.convertURL( "calendar-img.gif")+"\" id=\""+edtEnfermeroFechaIngreso_Internalname+"_dp_trigger\" style=\"cursor: pointer;\" title=\"Date selector\" alt=\"Date selector\" >") ;
               context.WriteHtmlTextNl( "</td></tr></table>") ;
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_33_033e( true) ;
         }
         else
         {
            wb_table4_33_033e( false) ;
         }
      }

      protected void wb_table2_5_033( bool wbgen )
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
            GxWebStd.gx_bitmap( context, imgBtn_first_Internalname, "", context.GetImagePath( "b9e06284-17ac-4c88-8937-5dbd84ad5d80", "", "GeneXusX"), "GeneXusX", imgBtn_first_Visible, 1, "", "Primero", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_first_Jsonclick, "EFIRST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Enfermero.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_first_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_first_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_first_separator_Jsonclick, "EFIRST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Enfermero.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_previous_Internalname, "", context.GetImagePath( "7d212604-db7b-4785-9c0d-5faffe71aa33", "", "GeneXusX"), "GeneXusX", imgBtn_previous_Visible, 1, "", "Anterior", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_previous_Jsonclick, "EPREVIOUS.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Enfermero.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_previous_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_previous_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_previous_separator_Jsonclick, "EPREVIOUS.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Enfermero.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_next_Internalname, "", context.GetImagePath( "1ae947cf-1354-41a9-8d59-d91daebf554f", "", "GeneXusX"), "GeneXusX", imgBtn_next_Visible, 1, "", "Siguiente", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_next_Jsonclick, "ENEXT.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Enfermero.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_next_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_next_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_next_separator_Jsonclick, "ENEXT.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Enfermero.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_last_Internalname, "", context.GetImagePath( "29211874-e613-48e5-9011-8017d984217e", "", "GeneXusX"), "GeneXusX", imgBtn_last_Visible, 1, "", "Ultimo", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_last_Jsonclick, "ELAST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Enfermero.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_last_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_last_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_last_separator_Jsonclick, "ELAST.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Enfermero.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_select_Internalname, "", context.GetImagePath( "1ca03f75-9947-4d2c-90a4-e8ab9c5cedea", "", "GeneXusX"), "GeneXusX", imgBtn_select_Visible, 1, "", "Seleccionar", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_select_Jsonclick, "ESELECT.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Enfermero.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_select_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_select_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_select_separator_Jsonclick, "ESELECT.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Enfermero.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_enter2_Internalname, "", context.GetImagePath( "2061cf2c-bd33-4433-a13e-34af954142e9", "", "GeneXusX"), "GeneXusX", imgBtn_enter2_Visible, imgBtn_enter2_Enabled, "", "Confirmar", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_enter2_Jsonclick, "EENTER.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Enfermero.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_enter2_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_enter2_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_enter2_separator_Jsonclick, "EENTER.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Enfermero.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_cancel2_Internalname, "", context.GetImagePath( "0e94ced8-bc34-47ff-9a53-bc683736a686", "", "GeneXusX"), "GeneXusX", imgBtn_cancel2_Visible, 1, "", "Cancelar", 0, 0, 0, "", 0, "", 0, 0, "", "", 1, imgBtn_cancel2_Jsonclick, "ECANCEL.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Enfermero.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_cancel2_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_cancel2_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 1, imgBtn_cancel2_separator_Jsonclick, "ECANCEL.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Enfermero.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"" ;
            ClassString = "ImageHandCenter" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_delete2_Internalname, "", context.GetImagePath( "7695fe89-52c9-4b7e-871e-0e11548f823e", "", "GeneXusX"), "GeneXusX", imgBtn_delete2_Visible, imgBtn_delete2_Enabled, "", "Eliminar", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_delete2_Jsonclick, "EDELETE.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Enfermero.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"" ;
            ClassString = "ImageTop" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_delete2_separator_Internalname, "", context.GetImagePath( "ea7811ba-4fa2-42da-8591-e6cb10669f1f", "", "GeneXusX"), "GeneXusX", imgBtn_delete2_separator_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgBtn_delete2_separator_Jsonclick, "EDELETE.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_Enfermero.htm");
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
            wb_table2_5_033e( true) ;
         }
         else
         {
            wb_table2_5_033e( false) ;
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
         /* Execute user event: E11032 */
         E11032 ();
         context.wbGlbDoneStart = 1 ;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read variables values. */
               A20EnfermeroId = (int)(context.localUtil.CToN( cgiGet( edtEnfermeroId_Internalname), ",", ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A20EnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(A20EnfermeroId), 6, 0)));
               A21EnfermeroNombre = cgiGet( edtEnfermeroNombre_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A21EnfermeroNombre", A21EnfermeroNombre);
               A22EnfermeroApellido = cgiGet( edtEnfermeroApellido_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A22EnfermeroApellido", A22EnfermeroApellido);
               A23EnfermeroDomicilio = cgiGet( edtEnfermeroDomicilio_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A23EnfermeroDomicilio", A23EnfermeroDomicilio);
               cmbEnfermeroEstadoCivil.CurrentValue = cgiGet( cmbEnfermeroEstadoCivil_Internalname) ;
               A24EnfermeroEstadoCivil = cgiGet( cmbEnfermeroEstadoCivil_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A24EnfermeroEstadoCivil", A24EnfermeroEstadoCivil);
               if ( context.localUtil.VCDate( cgiGet( edtEnfermeroFechaIngreso_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Enfermero Fecha Ingreso"}), 1, "ENFERMEROFECHAINGRESO");
                  AnyError = 1 ;
                  GX_FocusControl = edtEnfermeroFechaIngreso_Internalname ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true ;
                  A25EnfermeroFechaIngreso = DateTime.MinValue ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A25EnfermeroFechaIngreso", context.localUtil.Format(A25EnfermeroFechaIngreso, "99/99/99"));
               }
               else
               {
                  A25EnfermeroFechaIngreso = context.localUtil.CToD( cgiGet( edtEnfermeroFechaIngreso_Internalname), 2) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A25EnfermeroFechaIngreso", context.localUtil.Format(A25EnfermeroFechaIngreso, "99/99/99"));
               }
               /* Read saved values. */
               Z20EnfermeroId = (int)(context.localUtil.CToN( cgiGet( "Z20EnfermeroId"), ",", ".")) ;
               Z21EnfermeroNombre = cgiGet( "Z21EnfermeroNombre") ;
               Z22EnfermeroApellido = cgiGet( "Z22EnfermeroApellido") ;
               Z23EnfermeroDomicilio = cgiGet( "Z23EnfermeroDomicilio") ;
               Z24EnfermeroEstadoCivil = cgiGet( "Z24EnfermeroEstadoCivil") ;
               Z25EnfermeroFechaIngreso = context.localUtil.CToD( cgiGet( "Z25EnfermeroFechaIngreso"), 0) ;
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", ".")) ;
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", ".")) ;
               Gx_mode = cgiGet( "Mode") ;
               AV7EnfermeroId = (int)(context.localUtil.CToN( cgiGet( "_ENFERMEROID"), ",", ".")) ;
               AV12Pgmname = cgiGet( "_PGMNAME") ;
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
                  A20EnfermeroId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A20EnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(A20EnfermeroId), 6, 0)));
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
                     sMode3 = Gx_mode ;
                     Gx_mode = "UPD" ;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode3 ;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound3 == 1 )
                     {
                        if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
                        {
                           /* Confirm record */
                           CONFIRM_030( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert"), 1, "ENFERMEROID");
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
                           /* Execute user event: E11032 */
                           E11032 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1 ;
                           dynload_actions( ) ;
                           /* Execute user event: E12032 */
                           E12032 ();
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
            /* Execute user event: E12032 */
            E12032 ();
            trnEnded = 0 ;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  )
            {
               /* Clear variables for new insertion. */
               InitAll033( ) ;
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
            edtEnfermeroId_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtEnfermeroId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtEnfermeroId_Enabled), 5, 0)));
            edtEnfermeroNombre_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtEnfermeroNombre_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtEnfermeroNombre_Enabled), 5, 0)));
            edtEnfermeroApellido_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtEnfermeroApellido_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtEnfermeroApellido_Enabled), 5, 0)));
            edtEnfermeroDomicilio_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtEnfermeroDomicilio_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtEnfermeroDomicilio_Enabled), 5, 0)));
            cmbEnfermeroEstadoCivil.Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, cmbEnfermeroEstadoCivil_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(cmbEnfermeroEstadoCivil.Enabled), 5, 0)));
            edtEnfermeroFechaIngreso_Enabled = 0 ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtEnfermeroFechaIngreso_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtEnfermeroFechaIngreso_Enabled), 5, 0)));
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

      protected void CONFIRM_030( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               OnDeleteControls033( ) ;
            }
            else
            {
               CheckExtendedTable033( ) ;
               CloseExtendedTableCursors033( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1 ;
         }
      }

      protected void ResetCaption030( )
      {
      }

      protected void E11032( )
      {
         /* Start Routine */
         new isauthorized(context ).execute(  AV12Pgmname, out  AV9IsAuthorized) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV12Pgmname", AV12Pgmname);
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV9IsAuthorized", StringUtil.BoolToStr( AV9IsAuthorized));
         if ( ! AV9IsAuthorized )
         {
            context.wjLoc = formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV12Pgmname)) ;
         }
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), "");
      }

      protected void E12032( )
      {
         /* After Trn Routine */
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            context.wjLoc = formatLink("wwenfermero.aspx")  ;
         }
         context.setWebReturnParms(new Object[] {});
         context.nUserReturn = 1 ;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               Z21EnfermeroNombre = T00033_A21EnfermeroNombre[0] ;
               Z22EnfermeroApellido = T00033_A22EnfermeroApellido[0] ;
               Z23EnfermeroDomicilio = T00033_A23EnfermeroDomicilio[0] ;
               Z24EnfermeroEstadoCivil = T00033_A24EnfermeroEstadoCivil[0] ;
               Z25EnfermeroFechaIngreso = T00033_A25EnfermeroFechaIngreso[0] ;
            }
            else
            {
               Z21EnfermeroNombre = A21EnfermeroNombre ;
               Z22EnfermeroApellido = A22EnfermeroApellido ;
               Z23EnfermeroDomicilio = A23EnfermeroDomicilio ;
               Z24EnfermeroEstadoCivil = A24EnfermeroEstadoCivil ;
               Z25EnfermeroFechaIngreso = A25EnfermeroFechaIngreso ;
            }
         }
         if ( GX_JID == -5 )
         {
            Z20EnfermeroId = A20EnfermeroId ;
            Z21EnfermeroNombre = A21EnfermeroNombre ;
            Z22EnfermeroApellido = A22EnfermeroApellido ;
            Z23EnfermeroDomicilio = A23EnfermeroDomicilio ;
            Z24EnfermeroEstadoCivil = A24EnfermeroEstadoCivil ;
            Z25EnfermeroFechaIngreso = A25EnfermeroFechaIngreso ;
         }
      }

      protected void standaloneNotModal( )
      {
         edtEnfermeroId_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtEnfermeroId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtEnfermeroId_Enabled), 5, 0)));
         edtEnfermeroId_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtEnfermeroId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtEnfermeroId_Enabled), 5, 0)));
         imgBtn_delete2_Enabled = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgBtn_delete2_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(imgBtn_delete2_Enabled), 5, 0)));
         if ( ! (0==AV7EnfermeroId) )
         {
            A20EnfermeroId = AV7EnfermeroId ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A20EnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(A20EnfermeroId), 6, 0)));
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
      }

      protected void Load033( )
      {
         /* Using cursor T00034 */
         pr_default.execute(2, new Object[] {A20EnfermeroId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound3 = 1 ;
            A21EnfermeroNombre = T00034_A21EnfermeroNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A21EnfermeroNombre", A21EnfermeroNombre);
            A22EnfermeroApellido = T00034_A22EnfermeroApellido[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A22EnfermeroApellido", A22EnfermeroApellido);
            A23EnfermeroDomicilio = T00034_A23EnfermeroDomicilio[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A23EnfermeroDomicilio", A23EnfermeroDomicilio);
            A24EnfermeroEstadoCivil = T00034_A24EnfermeroEstadoCivil[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A24EnfermeroEstadoCivil", A24EnfermeroEstadoCivil);
            A25EnfermeroFechaIngreso = T00034_A25EnfermeroFechaIngreso[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A25EnfermeroFechaIngreso", context.localUtil.Format(A25EnfermeroFechaIngreso, "99/99/99"));
            ZM033( -5) ;
         }
         pr_default.close(2);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
         AV12Pgmname = "Enfermero" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV12Pgmname", AV12Pgmname);
      }

      protected void CheckExtendedTable033( )
      {
         Gx_BScreen = 1 ;
         standaloneModal( ) ;
         AV12Pgmname = "Enfermero" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV12Pgmname", AV12Pgmname);
         if ( ! ( ( StringUtil.StrCmp(A24EnfermeroEstadoCivil, "S") == 0 ) || ( StringUtil.StrCmp(A24EnfermeroEstadoCivil, "C") == 0 ) || ( StringUtil.StrCmp(A24EnfermeroEstadoCivil, "V") == 0 ) || ( StringUtil.StrCmp(A24EnfermeroEstadoCivil, "D") == 0 ) ) )
         {
            GX_msglist.addItem("Campo Enfermero Estado Civil fuera de rango", "OutOfRange", 1, "");
            AnyError = 1 ;
         }
         if ( ! ( (DateTime.MinValue==A25EnfermeroFechaIngreso) || ( A25EnfermeroFechaIngreso >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Enfermero Fecha Ingreso fuera de rango", "OutOfRange", 1, "");
            AnyError = 1 ;
         }
      }

      protected void CloseExtendedTableCursors033( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey033( )
      {
         /* Using cursor T00035 */
         pr_default.execute(3, new Object[] {A20EnfermeroId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound3 = 1 ;
         }
         else
         {
            RcdFound3 = 0 ;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00033 */
         pr_default.execute(1, new Object[] {A20EnfermeroId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM033( 5) ;
            RcdFound3 = 1 ;
            A20EnfermeroId = T00033_A20EnfermeroId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A20EnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(A20EnfermeroId), 6, 0)));
            A21EnfermeroNombre = T00033_A21EnfermeroNombre[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A21EnfermeroNombre", A21EnfermeroNombre);
            A22EnfermeroApellido = T00033_A22EnfermeroApellido[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A22EnfermeroApellido", A22EnfermeroApellido);
            A23EnfermeroDomicilio = T00033_A23EnfermeroDomicilio[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A23EnfermeroDomicilio", A23EnfermeroDomicilio);
            A24EnfermeroEstadoCivil = T00033_A24EnfermeroEstadoCivil[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A24EnfermeroEstadoCivil", A24EnfermeroEstadoCivil);
            A25EnfermeroFechaIngreso = T00033_A25EnfermeroFechaIngreso[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A25EnfermeroFechaIngreso", context.localUtil.Format(A25EnfermeroFechaIngreso, "99/99/99"));
            Z20EnfermeroId = A20EnfermeroId ;
            sMode3 = Gx_mode ;
            Gx_mode = "DSP" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
            Load033( ) ;
            Gx_mode = sMode3 ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound3 = 0 ;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode ;
            Gx_mode = "DSP" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode3 ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound3 = 0 ;
         /* Using cursor T00036 */
         pr_default.execute(4, new Object[] {A20EnfermeroId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00036_A20EnfermeroId[0] < A20EnfermeroId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00036_A20EnfermeroId[0] > A20EnfermeroId ) ) )
            {
               A20EnfermeroId = T00036_A20EnfermeroId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A20EnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(A20EnfermeroId), 6, 0)));
               RcdFound3 = 1 ;
            }
         }
         pr_default.close(1);
      }

      protected void move_previous( )
      {
         RcdFound3 = 0 ;
         /* Using cursor T00037 */
         pr_default.execute(5, new Object[] {A20EnfermeroId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00037_A20EnfermeroId[0] > A20EnfermeroId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00037_A20EnfermeroId[0] < A20EnfermeroId ) ) )
            {
               A20EnfermeroId = T00037_A20EnfermeroId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A20EnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(A20EnfermeroId), 6, 0)));
               RcdFound3 = 1 ;
            }
         }
         pr_default.close(0);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1 ;
         GetKey033( ) ;
         if ( RcdFound3 == 1 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate"), "DuplicatePrimaryKey", 1, "ENFERMEROID");
               AnyError = 1 ;
            }
            else if ( A20EnfermeroId != Z20EnfermeroId )
            {
               A20EnfermeroId = Z20EnfermeroId ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A20EnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(A20EnfermeroId), 6, 0)));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd"), "CandidateKeyNotFound", 1, "ENFERMEROID");
               AnyError = 1 ;
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               delete( ) ;
               AfterTrn( ) ;
               GX_FocusControl = edtEnfermeroNombre_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else
            {
               /* Update record */
               Update033( ) ;
               GX_FocusControl = edtEnfermeroNombre_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( A20EnfermeroId != Z20EnfermeroId )
            {
               /* Insert record */
               Insert033( ) ;
               GX_FocusControl = edtEnfermeroNombre_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted"), 1, "ENFERMEROID");
                  AnyError = 1 ;
               }
               else
               {
                  /* Insert record */
                  Insert033( ) ;
                  GX_FocusControl = edtEnfermeroNombre_Internalname ;
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
         if ( A20EnfermeroId != Z20EnfermeroId )
         {
            A20EnfermeroId = Z20EnfermeroId ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A20EnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(A20EnfermeroId), 6, 0)));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt"), 1, "ENFERMEROID");
            AnyError = 1 ;
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEnfermeroNombre_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency033( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            /* Using cursor T00038 */
            pr_default.execute(6, new Object[] {A20EnfermeroId});
            if ( (pr_default.getStatus(6) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Enfermero"}), "RecordIsLocked", 1, "");
               AnyError = 1 ;
               return  ;
            }
            if ( (pr_default.getStatus(6) == 101) || ( StringUtil.StrCmp(Z21EnfermeroNombre, T00038_A21EnfermeroNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z22EnfermeroApellido, T00038_A22EnfermeroApellido[0]) != 0 ) || ( StringUtil.StrCmp(Z23EnfermeroDomicilio, T00038_A23EnfermeroDomicilio[0]) != 0 ) || ( StringUtil.StrCmp(Z24EnfermeroEstadoCivil, T00038_A24EnfermeroEstadoCivil[0]) != 0 ) || ( Z25EnfermeroFechaIngreso != T00038_A25EnfermeroFechaIngreso[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Enfermero"}), "RecordWasChanged", 1, "");
               AnyError = 1 ;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00039 */
                     pr_default.execute(7, new Object[] {A21EnfermeroNombre, A22EnfermeroApellido, A23EnfermeroDomicilio, A24EnfermeroEstadoCivil, A25EnfermeroFechaIngreso});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000310 */
                     pr_default.execute(8);
                     A20EnfermeroId = T000310_A20EnfermeroId[0] ;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A20EnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(A20EnfermeroId), 6, 0)));
                     pr_default.close(8);
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           GX_msglist.addItem(context.GetMessage( "GXM_sucadded"), 0, "");
                           ResetCaption030( ) ;
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
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000311 */
                     pr_default.execute(9, new Object[] {A21EnfermeroNombre, A22EnfermeroApellido, A23EnfermeroDomicilio, A24EnfermeroEstadoCivil, A25EnfermeroFechaIngreso, A20EnfermeroId});
                     pr_default.close(9);
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Enfermero"}), "RecordIsLocked", 1, "");
                        AnyError = 1 ;
                     }
                     DeferredUpdate033( ) ;
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
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
      }

      protected void delete( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000312 */
                  pr_default.execute(10, new Object[] {A20EnfermeroId});
                  pr_default.close(10);
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
         sMode3 = Gx_mode ;
         Gx_mode = "DLT" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         EndLevel033( ) ;
         Gx_mode = sMode3 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV12Pgmname = "Enfermero" ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV12Pgmname", AV12Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000313 */
            pr_default.execute(11, new Object[] {A20EnfermeroId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Médico"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1 ;
            }
            pr_default.close(11);
            /* Using cursor T000314 */
            pr_default.execute(12, new Object[] {A20EnfermeroId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Médico"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1 ;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel033( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            pr_default.close(6);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(5);
            pr_default.close(4);
            context.CommitDataStores("Enfermero");
            if ( AnyError == 0 )
            {
               ConfirmValues030( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1 ;
         }
         else
         {
            pr_default.close(5);
            pr_default.close(4);
            context.RollbackDataStores("Enfermero");
         }
         IsModified = 0 ;
         if ( AnyError != 0 )
         {
            context.wjLoc = "" ;
            context.nUserReturn = 0 ;
         }
      }

      protected void ScanStart033( )
      {
         /* Using cursor T000315 */
         pr_default.execute(13);
         RcdFound3 = 0 ;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound3 = 1 ;
            A20EnfermeroId = T000315_A20EnfermeroId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A20EnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(A20EnfermeroId), 6, 0)));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext033( )
      {
         pr_default.readNext(13);
         RcdFound3 = 0 ;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound3 = 1 ;
            A20EnfermeroId = T000315_A20EnfermeroId[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A20EnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(A20EnfermeroId), 6, 0)));
         }
      }

      protected void ScanEnd033( )
      {
      }

      protected void AfterConfirm033( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues030( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" onsubmit=\"try{return gx.csv.validForm()}catch(e){return true;}\" name=\"MAINFORM\" method=\"post\" action=\""+formatLink("enfermero.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode("" +AV7EnfermeroId)+"\" class=\""+"Form"+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
      }

      public override void RenderHtmlCloseForm( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         GxWebStd.gx_hidden_field( context, "Z20EnfermeroId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z20EnfermeroId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z21EnfermeroNombre", StringUtil.RTrim( Z21EnfermeroNombre));
         GxWebStd.gx_hidden_field( context, "Z22EnfermeroApellido", StringUtil.RTrim( Z22EnfermeroApellido));
         GxWebStd.gx_hidden_field( context, "Z23EnfermeroDomicilio", StringUtil.RTrim( Z23EnfermeroDomicilio));
         GxWebStd.gx_hidden_field( context, "Z24EnfermeroEstadoCivil", StringUtil.RTrim( Z24EnfermeroEstadoCivil));
         GxWebStd.gx_hidden_field( context, "Z25EnfermeroFechaIngreso", context.localUtil.DToC( Z25EnfermeroFechaIngreso, 0, "/"));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "_ENFERMEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EnfermeroId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "_PGMNAME", StringUtil.RTrim( AV12Pgmname));
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
         return "Enfermero" ;
      }

      public override String GetPgmdesc( )
      {
         return "Enfermero" ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("enfermero.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode("" +AV7EnfermeroId) ;
      }

      protected void InitializeNonKey033( )
      {
         A21EnfermeroNombre = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A21EnfermeroNombre", A21EnfermeroNombre);
         A22EnfermeroApellido = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A22EnfermeroApellido", A22EnfermeroApellido);
         A23EnfermeroDomicilio = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A23EnfermeroDomicilio", A23EnfermeroDomicilio);
         A24EnfermeroEstadoCivil = "" ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A24EnfermeroEstadoCivil", A24EnfermeroEstadoCivil);
         A25EnfermeroFechaIngreso = DateTime.MinValue ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A25EnfermeroFechaIngreso", context.localUtil.Format(A25EnfermeroFechaIngreso, "99/99/99"));
      }

      protected void InitAll033( )
      {
         A20EnfermeroId = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A20EnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(A20EnfermeroId), 6, 0)));
         InitializeNonKey033( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( Form.Jscriptsrc.Item(idxLst)), "?40350");
            idxLst = (int)(idxLst+1) ;
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?34981");
         context.AddJavascriptSource("enfermero.js", "?40350");
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
         lblTextblockenfermeroid_Internalname = "TEXTBLOCKENFERMEROID" ;
         edtEnfermeroId_Internalname = "ENFERMEROID" ;
         lblTextblockenfermeronombre_Internalname = "TEXTBLOCKENFERMERONOMBRE" ;
         edtEnfermeroNombre_Internalname = "ENFERMERONOMBRE" ;
         lblTextblockenfermeroapellido_Internalname = "TEXTBLOCKENFERMEROAPELLIDO" ;
         edtEnfermeroApellido_Internalname = "ENFERMEROAPELLIDO" ;
         lblTextblockenfermerodomicilio_Internalname = "TEXTBLOCKENFERMERODOMICILIO" ;
         edtEnfermeroDomicilio_Internalname = "ENFERMERODOMICILIO" ;
         lblTextblockenfermeroestadocivil_Internalname = "TEXTBLOCKENFERMEROESTADOCIVIL" ;
         cmbEnfermeroEstadoCivil_Internalname = "ENFERMEROESTADOCIVIL" ;
         lblTextblockenfermerofechaingreso_Internalname = "TEXTBLOCKENFERMEROFECHAINGRESO" ;
         edtEnfermeroFechaIngreso_Internalname = "ENFERMEROFECHAINGRESO" ;
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
         Form.Caption = "Enfermero" ;
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
         edtEnfermeroFechaIngreso_Jsonclick = "" ;
         edtEnfermeroFechaIngreso_Enabled = 1 ;
         cmbEnfermeroEstadoCivil_Jsonclick = "" ;
         cmbEnfermeroEstadoCivil.Enabled = 1 ;
         edtEnfermeroDomicilio_Jsonclick = "" ;
         edtEnfermeroDomicilio_Enabled = 1 ;
         edtEnfermeroApellido_Jsonclick = "" ;
         edtEnfermeroApellido_Enabled = 1 ;
         edtEnfermeroNombre_Jsonclick = "" ;
         edtEnfermeroNombre_Enabled = 1 ;
         edtEnfermeroId_Jsonclick = "" ;
         edtEnfermeroId_Enabled = 0 ;
         bttBtn_delete_Visible = 1 ;
         bttBtn_cancel_Visible = 1 ;
         bttBtn_enter_Visible = 1 ;
         context.GX_msglist.DisplayMode = 1 ;
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
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
         pr_default.close(5);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         sPrefix = "" ;
         wcpOGx_mode = "" ;
         scmdbuf = "" ;
         gxfirstwebparm = "" ;
         gxfirstwebparm_bkp = "" ;
         A24EnfermeroEstadoCivil = "" ;
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
         lblTextblockenfermeroid_Jsonclick = "" ;
         lblTextblockenfermeronombre_Jsonclick = "" ;
         A21EnfermeroNombre = "" ;
         lblTextblockenfermeroapellido_Jsonclick = "" ;
         A22EnfermeroApellido = "" ;
         lblTextblockenfermerodomicilio_Jsonclick = "" ;
         A23EnfermeroDomicilio = "" ;
         lblTextblockenfermeroestadocivil_Jsonclick = "" ;
         lblTextblockenfermerofechaingreso_Jsonclick = "" ;
         A25EnfermeroFechaIngreso = DateTime.MinValue ;
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
         Z21EnfermeroNombre = "" ;
         Z22EnfermeroApellido = "" ;
         Z23EnfermeroDomicilio = "" ;
         Z24EnfermeroEstadoCivil = "" ;
         Z25EnfermeroFechaIngreso = DateTime.MinValue ;
         AV12Pgmname = "" ;
         sMode3 = "" ;
         sEvt = "" ;
         EvtGridId = "" ;
         EvtRowId = "" ;
         sEvtType = "" ;
         AV10TrnContext = new SdtTransactionContext(context);
         AV11WebSession = new GxWebSession( context);
         T00034_A20EnfermeroId = new int[1] ;
         T00034_A21EnfermeroNombre = new String[] {""} ;
         T00034_A22EnfermeroApellido = new String[] {""} ;
         T00034_A23EnfermeroDomicilio = new String[] {""} ;
         T00034_A24EnfermeroEstadoCivil = new String[] {""} ;
         T00034_A25EnfermeroFechaIngreso = new DateTime[] {DateTime.MinValue} ;
         T00035_A20EnfermeroId = new int[1] ;
         T00033_A20EnfermeroId = new int[1] ;
         T00033_A21EnfermeroNombre = new String[] {""} ;
         T00033_A22EnfermeroApellido = new String[] {""} ;
         T00033_A23EnfermeroDomicilio = new String[] {""} ;
         T00033_A24EnfermeroEstadoCivil = new String[] {""} ;
         T00033_A25EnfermeroFechaIngreso = new DateTime[] {DateTime.MinValue} ;
         T00036_A20EnfermeroId = new int[1] ;
         T00037_A20EnfermeroId = new int[1] ;
         T00038_A20EnfermeroId = new int[1] ;
         T00038_A21EnfermeroNombre = new String[] {""} ;
         T00038_A22EnfermeroApellido = new String[] {""} ;
         T00038_A23EnfermeroDomicilio = new String[] {""} ;
         T00038_A24EnfermeroEstadoCivil = new String[] {""} ;
         T00038_A25EnfermeroFechaIngreso = new DateTime[] {DateTime.MinValue} ;
         T000310_A20EnfermeroId = new int[1] ;
         T000313_A12MedicoId = new int[1] ;
         T000314_A12MedicoId = new int[1] ;
         T000315_A20EnfermeroId = new int[1] ;
         sDynURL = "" ;
         FormProcess = "" ;
         GXt_char2 = "" ;
         GXt_char1 = "" ;
         GXt_char3 = "" ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.enfermero__default(),
            new Object[][] {
                new Object[] {
               T00032_A20EnfermeroId, T00032_A21EnfermeroNombre, T00032_A22EnfermeroApellido, T00032_A23EnfermeroDomicilio, T00032_A24EnfermeroEstadoCivil, T00032_A25EnfermeroFechaIngreso
               }
               , new Object[] {
               T00033_A20EnfermeroId, T00033_A21EnfermeroNombre, T00033_A22EnfermeroApellido, T00033_A23EnfermeroDomicilio, T00033_A24EnfermeroEstadoCivil, T00033_A25EnfermeroFechaIngreso
               }
               , new Object[] {
               T00034_A20EnfermeroId, T00034_A21EnfermeroNombre, T00034_A22EnfermeroApellido, T00034_A23EnfermeroDomicilio, T00034_A24EnfermeroEstadoCivil, T00034_A25EnfermeroFechaIngreso
               }
               , new Object[] {
               T00035_A20EnfermeroId
               }
               , new Object[] {
               T00036_A20EnfermeroId
               }
               , new Object[] {
               T00037_A20EnfermeroId
               }
               , new Object[] {
               T00038_A20EnfermeroId, T00038_A21EnfermeroNombre, T00038_A22EnfermeroApellido, T00038_A23EnfermeroDomicilio, T00038_A24EnfermeroEstadoCivil, T00038_A25EnfermeroFechaIngreso
               }
               , new Object[] {
               }
               , new Object[] {
               T000310_A20EnfermeroId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000313_A12MedicoId
               }
               , new Object[] {
               T000314_A12MedicoId
               }
               , new Object[] {
               T000315_A20EnfermeroId
               }
            }
         );
         AV12Pgmname = "Enfermero" ;
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound3 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7EnfermeroId ;
      private int AV7EnfermeroId ;
      private int trnEnded ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int A20EnfermeroId ;
      private int edtEnfermeroId_Enabled ;
      private int edtEnfermeroNombre_Enabled ;
      private int edtEnfermeroApellido_Enabled ;
      private int edtEnfermeroDomicilio_Enabled ;
      private int edtEnfermeroFechaIngreso_Enabled ;
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
      private int Z20EnfermeroId ;
      private int idxLst ;
      private String sPrefix ;
      private String wcpOGx_mode ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String Gx_mode ;
      private String A24EnfermeroEstadoCivil ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String GX_FocusControl ;
      private String edtEnfermeroNombre_Internalname ;
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
      private String lblTextblockenfermeroid_Internalname ;
      private String lblTextblockenfermeroid_Jsonclick ;
      private String edtEnfermeroId_Internalname ;
      private String edtEnfermeroId_Jsonclick ;
      private String lblTextblockenfermeronombre_Internalname ;
      private String lblTextblockenfermeronombre_Jsonclick ;
      private String A21EnfermeroNombre ;
      private String edtEnfermeroNombre_Jsonclick ;
      private String lblTextblockenfermeroapellido_Internalname ;
      private String lblTextblockenfermeroapellido_Jsonclick ;
      private String edtEnfermeroApellido_Internalname ;
      private String A22EnfermeroApellido ;
      private String edtEnfermeroApellido_Jsonclick ;
      private String lblTextblockenfermerodomicilio_Internalname ;
      private String lblTextblockenfermerodomicilio_Jsonclick ;
      private String edtEnfermeroDomicilio_Internalname ;
      private String A23EnfermeroDomicilio ;
      private String edtEnfermeroDomicilio_Jsonclick ;
      private String lblTextblockenfermeroestadocivil_Internalname ;
      private String lblTextblockenfermeroestadocivil_Jsonclick ;
      private String cmbEnfermeroEstadoCivil_Internalname ;
      private String cmbEnfermeroEstadoCivil_Jsonclick ;
      private String lblTextblockenfermerofechaingreso_Internalname ;
      private String lblTextblockenfermerofechaingreso_Jsonclick ;
      private String edtEnfermeroFechaIngreso_Internalname ;
      private String edtEnfermeroFechaIngreso_Jsonclick ;
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
      private String Z21EnfermeroNombre ;
      private String Z22EnfermeroApellido ;
      private String Z23EnfermeroDomicilio ;
      private String Z24EnfermeroEstadoCivil ;
      private String AV12Pgmname ;
      private String sMode3 ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String sDynURL ;
      private String FormProcess ;
      private String GXt_char2 ;
      private String GXt_char1 ;
      private String GXt_char3 ;
      private DateTime A25EnfermeroFechaIngreso ;
      private DateTime Z25EnfermeroFechaIngreso ;
      private bool entryPointCalled ;
      private bool wbErr ;
      private bool AV9IsAuthorized ;
      private bool returnInSub ;
      private GxWebSession AV11WebSession ;
      private GXMasterPage MasterPageObj ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbEnfermeroEstadoCivil ;
      private IDataStoreProvider pr_default ;
      private int[] T00034_A20EnfermeroId ;
      private String[] T00034_A21EnfermeroNombre ;
      private String[] T00034_A22EnfermeroApellido ;
      private String[] T00034_A23EnfermeroDomicilio ;
      private String[] T00034_A24EnfermeroEstadoCivil ;
      private DateTime[] T00034_A25EnfermeroFechaIngreso ;
      private int[] T00035_A20EnfermeroId ;
      private int[] T00033_A20EnfermeroId ;
      private String[] T00033_A21EnfermeroNombre ;
      private String[] T00033_A22EnfermeroApellido ;
      private String[] T00033_A23EnfermeroDomicilio ;
      private String[] T00033_A24EnfermeroEstadoCivil ;
      private DateTime[] T00033_A25EnfermeroFechaIngreso ;
      private int[] T00036_A20EnfermeroId ;
      private int[] T00037_A20EnfermeroId ;
      private int[] T00038_A20EnfermeroId ;
      private String[] T00038_A21EnfermeroNombre ;
      private String[] T00038_A22EnfermeroApellido ;
      private String[] T00038_A23EnfermeroDomicilio ;
      private String[] T00038_A24EnfermeroEstadoCivil ;
      private DateTime[] T00038_A25EnfermeroFechaIngreso ;
      private int[] T000310_A20EnfermeroId ;
      private int[] T000313_A12MedicoId ;
      private int[] T000314_A12MedicoId ;
      private int[] T000315_A20EnfermeroId ;
      private int[] T00032_A20EnfermeroId ;
      private String[] T00032_A21EnfermeroNombre ;
      private String[] T00032_A22EnfermeroApellido ;
      private String[] T00032_A23EnfermeroDomicilio ;
      private String[] T00032_A24EnfermeroEstadoCivil ;
      private DateTime[] T00032_A25EnfermeroFechaIngreso ;
      private GXWebForm Form ;
      private SdtTransactionContext AV10TrnContext ;
   }

   public class enfermero__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00032 ;
          prmT00032 = new Object[] {
          new Object[] {"@EnfermeroId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00034 ;
          prmT00034 = new Object[] {
          new Object[] {"@EnfermeroId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00035 ;
          prmT00035 = new Object[] {
          new Object[] {"@EnfermeroId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00033 ;
          prmT00033 = new Object[] {
          new Object[] {"@EnfermeroId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00036 ;
          prmT00036 = new Object[] {
          new Object[] {"@EnfermeroId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00037 ;
          prmT00037 = new Object[] {
          new Object[] {"@EnfermeroId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00038 ;
          prmT00038 = new Object[] {
          new Object[] {"@EnfermeroId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT00039 ;
          prmT00039 = new Object[] {
          new Object[] {"@EnfermeroNombre",SqlDbType.Char,20,0} ,
          new Object[] {"@EnfermeroApellido",SqlDbType.Char,20,0} ,
          new Object[] {"@EnfermeroDomicilio",SqlDbType.Char,40,0} ,
          new Object[] {"@EnfermeroEstadoCivil",SqlDbType.Char,1,0} ,
          new Object[] {"@EnfermeroFechaIngreso",SqlDbType.DateTime,8,0}
          } ;
          Object[] prmT000310 ;
          prmT000310 = new Object[] {
          } ;
          Object[] prmT000311 ;
          prmT000311 = new Object[] {
          new Object[] {"@EnfermeroNombre",SqlDbType.Char,20,0} ,
          new Object[] {"@EnfermeroApellido",SqlDbType.Char,20,0} ,
          new Object[] {"@EnfermeroDomicilio",SqlDbType.Char,40,0} ,
          new Object[] {"@EnfermeroEstadoCivil",SqlDbType.Char,1,0} ,
          new Object[] {"@EnfermeroFechaIngreso",SqlDbType.DateTime,8,0} ,
          new Object[] {"@EnfermeroId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000312 ;
          prmT000312 = new Object[] {
          new Object[] {"@EnfermeroId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000313 ;
          prmT000313 = new Object[] {
          new Object[] {"@EnfermeroId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000314 ;
          prmT000314 = new Object[] {
          new Object[] {"@EnfermeroId",SqlDbType.Int,6,0}
          } ;
          Object[] prmT000315 ;
          prmT000315 = new Object[] {
          } ;
          def= new CursorDef[] {
              new CursorDef("T00032", "SELECT [EnfermeroId], [EnfermeroNombre], [EnfermeroApellido], [EnfermeroDomicilio], [EnfermeroEstadoCivil], [EnfermeroFechaIngreso] FROM [Enfermero] WITH (UPDLOCK) WHERE [EnfermeroId] = @EnfermeroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00032,1,0,true,false )
             ,new CursorDef("T00033", "SELECT [EnfermeroId], [EnfermeroNombre], [EnfermeroApellido], [EnfermeroDomicilio], [EnfermeroEstadoCivil], [EnfermeroFechaIngreso] FROM [Enfermero] WITH (NOLOCK) WHERE [EnfermeroId] = @EnfermeroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00033,1,0,true,false )
             ,new CursorDef("T00034", "SELECT TM1.[EnfermeroId], TM1.[EnfermeroNombre], TM1.[EnfermeroApellido], TM1.[EnfermeroDomicilio], TM1.[EnfermeroEstadoCivil], TM1.[EnfermeroFechaIngreso] FROM [Enfermero] TM1 WITH (NOLOCK) WHERE TM1.[EnfermeroId] = @EnfermeroId ORDER BY TM1.[EnfermeroId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00034,100,0,true,false )
             ,new CursorDef("T00035", "SELECT [EnfermeroId] FROM [Enfermero] WITH (NOLOCK) WHERE [EnfermeroId] = @EnfermeroId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00035,1,0,true,false )
             ,new CursorDef("T00036", "SELECT TOP 1 [EnfermeroId] FROM [Enfermero] WITH (NOLOCK) WHERE ( [EnfermeroId] > @EnfermeroId) ORDER BY [EnfermeroId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00036,1,0,true,true )
             ,new CursorDef("T00037", "SELECT TOP 1 [EnfermeroId] FROM [Enfermero] WITH (NOLOCK) WHERE ( [EnfermeroId] < @EnfermeroId) ORDER BY [EnfermeroId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00037,1,0,true,true )
             ,new CursorDef("T00038", "SELECT [EnfermeroId], [EnfermeroNombre], [EnfermeroApellido], [EnfermeroDomicilio], [EnfermeroEstadoCivil], [EnfermeroFechaIngreso] FROM [Enfermero] WITH (UPDLOCK) WHERE [EnfermeroId] = @EnfermeroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00038,1,0,true,false )
             ,new CursorDef("T00039", "INSERT INTO [Enfermero] ([EnfermeroNombre], [EnfermeroApellido], [EnfermeroDomicilio], [EnfermeroEstadoCivil], [EnfermeroFechaIngreso]) VALUES (@EnfermeroNombre, @EnfermeroApellido, @EnfermeroDomicilio, @EnfermeroEstadoCivil, @EnfermeroFechaIngreso)", GxErrorMask.GX_NOMASK,prmT00039)
             ,new CursorDef("T000310", "SELECT Ident_Current('[Enfermero]') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000310,1,0,true,false )
             ,new CursorDef("T000311", "UPDATE [Enfermero] SET [EnfermeroNombre]=@EnfermeroNombre, [EnfermeroApellido]=@EnfermeroApellido, [EnfermeroDomicilio]=@EnfermeroDomicilio, [EnfermeroEstadoCivil]=@EnfermeroEstadoCivil, [EnfermeroFechaIngreso]=@EnfermeroFechaIngreso  WHERE [EnfermeroId] = @EnfermeroId", GxErrorMask.GX_NOMASK,prmT000311)
             ,new CursorDef("T000312", "DELETE FROM [Enfermero]  WHERE [EnfermeroId] = @EnfermeroId", GxErrorMask.GX_NOMASK,prmT000312)
             ,new CursorDef("T000313", "SELECT TOP 1 [MedicoId] FROM [Medico] WITH (NOLOCK) WHERE [EnfermeroSuplenteId] = @EnfermeroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000313,1,0,true,true )
             ,new CursorDef("T000314", "SELECT TOP 1 [MedicoId] FROM [Medico] WITH (NOLOCK) WHERE [EnfermeroTitularId] = @EnfermeroId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000314,1,0,true,true )
             ,new CursorDef("T000315", "SELECT [EnfermeroId] FROM [Enfermero] WITH (NOLOCK) ORDER BY [EnfermeroId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000315,100,0,true,false )
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
                break;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                ((String[]) buf[3])[0] = rslt.getString(4, 40) ;
                ((String[]) buf[4])[0] = rslt.getString(5, 1) ;
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6) ;
                break;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                ((String[]) buf[3])[0] = rslt.getString(4, 40) ;
                ((String[]) buf[4])[0] = rslt.getString(5, 1) ;
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6) ;
                break;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                break;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                break;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                break;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                ((String[]) buf[3])[0] = rslt.getString(4, 40) ;
                ((String[]) buf[4])[0] = rslt.getString(5, 1) ;
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6) ;
                break;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                break;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                break;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                break;
             case 13 :
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
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (String)parms[2]);
                stmt.SetParameter(4, (String)parms[3]);
                stmt.SetParameter(5, (DateTime)parms[4]);
                break;
             case 9 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (String)parms[2]);
                stmt.SetParameter(4, (String)parms[3]);
                stmt.SetParameter(5, (DateTime)parms[4]);
                stmt.SetParameter(6, (int)parms[5]);
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
       }
    }

 }

}
