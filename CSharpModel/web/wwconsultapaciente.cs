/*
               File: WWConsultaPaciente
        Description: Work With Consulta Paciente
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/24/2010 5:12:53.5
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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Data.SqlTypes;
namespace GeneXus.Programs {
   public class wwconsultapaciente : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwconsultapaciente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public wwconsultapaciente( IGxContext context )
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
         chkConfirmado = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               nRC_Grid = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
               nGXsfl_26_idx = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
               sGXsfl_26_idx = GetNextPar( ) ;
               edtavDelete_Tooltiptext = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext);
               AV15Delete = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDelete_Internalname, "Bitmap", context.convertURL( AV15Delete));
               edtavUpdate_Tooltiptext = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext);
               AV14Update = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Bitmap", context.convertURL( AV14Update));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1 ;
                  return  ;
               }
               gxnrGrid_newrow( nRC_Grid, nGXsfl_26_idx, sGXsfl_26_idx, AV15Delete, AV14Update) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               /* GeneXus formulas. */
               AV18Pgmname = "WWConsultaPaciente" ;
               context.Gx_err = 0 ;
               GXCCtl = "CONFIRMADO_" + sGXsfl_26_idx ;
               chkConfirmado.Name = GXCCtl ;
               chkConfirmado.WebTags = "" ;
               chkConfirmado.Caption = "" ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, chkConfirmado_Internalname, "Caption", chkConfirmado.Caption);
               chkConfirmado.CheckedValue = "false" ;
               Grid_PageSize26 = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
               AV13PacienteCI = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV13PacienteCI", AV13PacienteCI);
               edtavDelete_Tooltiptext = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext);
               AV15Delete = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDelete_Internalname, "Bitmap", context.convertURL( AV15Delete));
               edtavUpdate_Tooltiptext = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext);
               AV14Update = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Bitmap", context.convertURL( AV14Update));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1 ;
                  return  ;
               }
               gxgrGrid_refresh( Grid_PageSize26, AV13PacienteCI, AV15Delete, AV14Update) ;
               return  ;
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
         }
         context.SetTheme("GeneXusX");
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
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

      public override short ExecuteStartEvent( )
      {
         PA0E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0)) ;
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0E2( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         FormProcess = ((nGXWrapped==0) ? " onkeyup=\"gx.evt.onkeyup(event)\" onkeypress=\"gx.evt.onkeypress(event,false,false)\" onkeydown=\"gx.evt.onkeypress(null,false,false)\"" : "") ;
         context.WriteHtmlText( "<body") ;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            context.WriteHtmlText( " background=\""+context.convertURL( Form.Background)+"\"") ;
         }
         context.WriteHtmlText( " "+"class=\"Form\""+" "+" style=\"-moz-opacity:0;opacity:0;"+"\""+" bgcolor=\""+context.BuildHTMLColor( Form.Backcolor)+"\""+FormProcess+">") ;
         context.skipLines(1);
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" onsubmit=\"try{return gx.csv.validForm()}catch(e){return true;}\" name=\"MAINFORM\" method=\"post\" action=\""+formatLink("wwconsultapaciente.aspx") +"\" class=\""+"Form"+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         }
      }

      public override void RenderHtmlCloseForm( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH__PACIENTECI", StringUtil.RTrim( AV13PacienteCI));
         /* Send saved values. */
         GxWebStd.gx_hidden_field( context, "nRC_Grid", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_Grid), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 3, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0)) ;
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            WE0E2( ) ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0E2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override String GetPgmname( )
      {
         return "WWConsultaPaciente" ;
      }

      public override String GetPgmdesc( )
      {
         return "Work With Consulta Paciente" ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("wwconsultapaciente.aspx")  ;
      }

      protected void WB0E0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            wb_table1_2_0E2( true) ;
         }
         else
         {
            wb_table1_2_0E2( false) ;
         }
         return  ;
      }

      protected void wb_table1_2_0E2e( bool wbgen )
      {
         if ( wbgen )
         {
         }
         wbLoad = true ;
      }

      protected void START0E2( )
      {
         wbLoad = false ;
         wbEnd = 0 ;
         wbStart = 0 ;
         Form.Meta.addItem("Generator", "GeneXus C#", 0) ;
         Form.Meta.addItem("Version", "10_1_3-34981", 0) ;
         Form.Meta.addItem("Description", "Work With Consulta Paciente", 0) ;
         context.wjLoc = "" ;
         context.nUserReturn = 0 ;
         context.wbHandled = 0 ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false ;
         STRUP0E0( ) ;
      }

      protected void WS0E2( )
      {
         START0E2( ) ;
         EVT0E2( ) ;
      }

      protected void EVT0E2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName") ;
               EvtGridId = cgiGet( "_EventGridId") ;
               EvtRowId = cgiGet( "_EventRowId") ;
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1) ;
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1)) ;
                  /* Check if conditions changed and reset current page numbers */
                  if ( StringUtil.StrCmp(cgiGet( "GXH__PACIENTECI"), AV13PacienteCI) != 0 )
                  {
                     GRID_nFirstRecordOnPage = 0 ;
                  }
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1) ;
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1)) ;
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1 ;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1 ;
                              dynload_actions( ) ;
                              /* Execute user event: E110E2 */
                              E110E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1 ;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1 ;
                              sEvt = cgiGet( "GRIDPAGING") ;
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4) ;
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4)) ;
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'DOINSERT'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_26_idx = (short)(NumberUtil.Val( sEvtType, ".")) ;
                              sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_26_idx), 4, 0)), 4, "0") ;
                              edtavUpdate_Internalname = "_UPDATE_"+sGXsfl_26_idx ;
                              edtavDelete_Internalname = "_DELETE_"+sGXsfl_26_idx ;
                              edtConsultaFecha_Internalname = "CONSULTAFECHA_"+sGXsfl_26_idx ;
                              edtPacienteId_Internalname = "PACIENTEID_"+sGXsfl_26_idx ;
                              edtPacienteApellido_Internalname = "PACIENTEAPELLIDO_"+sGXsfl_26_idx ;
                              edtPacienteNombre_Internalname = "PACIENTENOMBRE_"+sGXsfl_26_idx ;
                              edtPacienteCI_Internalname = "PACIENTECI_"+sGXsfl_26_idx ;
                              edtMedicoId_Internalname = "MEDICOID_"+sGXsfl_26_idx ;
                              edtMedicoApellido_Internalname = "MEDICOAPELLIDO_"+sGXsfl_26_idx ;
                              edtMedicoNombre_Internalname = "MEDICONOMBRE_"+sGXsfl_26_idx ;
                              edtEspecialidadMaxPacientes_Internalname = "ESPECIALIDADMAXPACIENTES_"+sGXsfl_26_idx ;
                              edtTurnoId_Internalname = "TURNOID_"+sGXsfl_26_idx ;
                              edtTurnoNombre_Internalname = "TURNONOMBRE_"+sGXsfl_26_idx ;
                              edtConsultaNro_Internalname = "CONSULTANRO_"+sGXsfl_26_idx ;
                              chkConfirmado_Internalname = "CONFIRMADO_"+sGXsfl_26_idx ;
                              AV14Update = cgiGet( "GXimg"+edtavUpdate_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Bitmap", context.convertURL( AV14Update));
                              AV15Delete = cgiGet( "GXimg"+edtavDelete_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDelete_Internalname, "Bitmap", context.convertURL( AV15Delete));
                              A43ConsultaFecha = context.localUtil.CToD( cgiGet( edtConsultaFecha_Internalname), 2) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
                              A34PacienteId = (int)(context.localUtil.CToN( cgiGet( edtPacienteId_Internalname), ",", ".")) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
                              A36PacienteApellido = cgiGet( edtPacienteApellido_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A36PacienteApellido", A36PacienteApellido);
                              A35PacienteNombre = cgiGet( edtPacienteNombre_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A35PacienteNombre", A35PacienteNombre);
                              A41PacienteCI = cgiGet( edtPacienteCI_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
                              A12MedicoId = (int)(context.localUtil.CToN( cgiGet( edtMedicoId_Internalname), ",", ".")) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
                              A14MedicoApellido = cgiGet( edtMedicoApellido_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
                              A13MedicoNombre = cgiGet( edtMedicoNombre_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
                              A11EspecialidadMaxPacientes = (short)(context.localUtil.CToN( cgiGet( edtEspecialidadMaxPacientes_Internalname), ",", ".")) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
                              A60TurnoId = (short)(context.localUtil.CToN( cgiGet( edtTurnoId_Internalname), ",", ".")) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
                              A61TurnoNombre = cgiGet( edtTurnoNombre_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
                              A63ConsultaNro = (short)(context.localUtil.CToN( cgiGet( edtConsultaNro_Internalname), ",", ".")) ;
                              n63ConsultaNro = false ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A63ConsultaNro", StringUtil.LTrim( StringUtil.Str( (decimal)(A63ConsultaNro), 2, 0)));
                              A75Confirmado = StringUtil.StrToBool( cgiGet( chkConfirmado_Internalname)) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A75Confirmado", StringUtil.BoolToStr( A75Confirmado));
                              sEvtType = StringUtil.Right( sEvt, 1) ;
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1)) ;
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    dynload_actions( ) ;
                                    /* Execute user event: E120E2 */
                                    E120E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    dynload_actions( ) ;
                                    /* Execute user event: E130E2 */
                                    E130E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    dynload_actions( ) ;
                                    /* Execute user event: E140E2 */
                                    E140E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    dynload_actions( ) ;
                                    /* Execute user event: E110E2 */
                                    E110E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false ;
                                       /* Set Refresh If Pacienteci Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH__PACIENTECI"), AV13PacienteCI) != 0 )
                                       {
                                          Rfr0gs = true ;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CANCEL") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    dynload_actions( ) ;
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1 ;
                  }
               }
            }
         }
      }

      protected void WE0E2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true ;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0E2( )
      {
         if ( nDonePA == 0 )
         {
            GXCCtl = "CONFIRMADO_" + sGXsfl_26_idx ;
            chkConfirmado.Name = GXCCtl ;
            chkConfirmado.WebTags = "" ;
            chkConfirmado.Caption = "" ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, chkConfirmado_Internalname, "Caption", chkConfirmado.Caption);
            chkConfirmado.CheckedValue = "false" ;
            GX_FocusControl = edtavPacienteci_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            nDonePA = 1 ;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( short nRC_Grid ,
                                      short nGXsfl_26_idx ,
                                      String sGXsfl_26_idx ,
                                      String AV15Delete ,
                                      String AV14Update )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         edtavUpdate_Internalname = "_UPDATE_"+sGXsfl_26_idx ;
         edtavDelete_Internalname = "_DELETE_"+sGXsfl_26_idx ;
         edtConsultaFecha_Internalname = "CONSULTAFECHA_"+sGXsfl_26_idx ;
         edtPacienteId_Internalname = "PACIENTEID_"+sGXsfl_26_idx ;
         edtPacienteApellido_Internalname = "PACIENTEAPELLIDO_"+sGXsfl_26_idx ;
         edtPacienteNombre_Internalname = "PACIENTENOMBRE_"+sGXsfl_26_idx ;
         edtPacienteCI_Internalname = "PACIENTECI_"+sGXsfl_26_idx ;
         edtMedicoId_Internalname = "MEDICOID_"+sGXsfl_26_idx ;
         edtMedicoApellido_Internalname = "MEDICOAPELLIDO_"+sGXsfl_26_idx ;
         edtMedicoNombre_Internalname = "MEDICONOMBRE_"+sGXsfl_26_idx ;
         edtEspecialidadMaxPacientes_Internalname = "ESPECIALIDADMAXPACIENTES_"+sGXsfl_26_idx ;
         edtTurnoId_Internalname = "TURNOID_"+sGXsfl_26_idx ;
         edtTurnoNombre_Internalname = "TURNONOMBRE_"+sGXsfl_26_idx ;
         edtConsultaNro_Internalname = "CONSULTANRO_"+sGXsfl_26_idx ;
         chkConfirmado_Internalname = "CONFIRMADO_"+sGXsfl_26_idx ;
         while ( nGXsfl_26_idx <= nRC_Grid )
         {
            sendrow_262( ) ;
            nGXsfl_26_idx = (short)(((subGrid_Islastpage==1)&&(nGXsfl_26_idx+1>subGrid_Recordsperpage( )) ? 1 : nGXsfl_26_idx+1)) ;
            sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_26_idx), 4, 0)), 4, "0") ;
            edtavUpdate_Internalname = "_UPDATE_"+sGXsfl_26_idx ;
            edtavDelete_Internalname = "_DELETE_"+sGXsfl_26_idx ;
            edtConsultaFecha_Internalname = "CONSULTAFECHA_"+sGXsfl_26_idx ;
            edtPacienteId_Internalname = "PACIENTEID_"+sGXsfl_26_idx ;
            edtPacienteApellido_Internalname = "PACIENTEAPELLIDO_"+sGXsfl_26_idx ;
            edtPacienteNombre_Internalname = "PACIENTENOMBRE_"+sGXsfl_26_idx ;
            edtPacienteCI_Internalname = "PACIENTECI_"+sGXsfl_26_idx ;
            edtMedicoId_Internalname = "MEDICOID_"+sGXsfl_26_idx ;
            edtMedicoApellido_Internalname = "MEDICOAPELLIDO_"+sGXsfl_26_idx ;
            edtMedicoNombre_Internalname = "MEDICONOMBRE_"+sGXsfl_26_idx ;
            edtEspecialidadMaxPacientes_Internalname = "ESPECIALIDADMAXPACIENTES_"+sGXsfl_26_idx ;
            edtTurnoId_Internalname = "TURNOID_"+sGXsfl_26_idx ;
            edtTurnoNombre_Internalname = "TURNONOMBRE_"+sGXsfl_26_idx ;
            edtConsultaNro_Internalname = "CONSULTANRO_"+sGXsfl_26_idx ;
            chkConfirmado_Internalname = "CONFIRMADO_"+sGXsfl_26_idx ;
         }
         context.GX_webresponse.AddString(GridContainer.ToJavascriptSource());
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int Grid_PageSize26 ,
                                       String AV13PacienteCI ,
                                       String AV15Delete ,
                                       String AV14Update )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         disableOutput();
         subGrid_Rows = (short)(Grid_PageSize26) ;
         RF0E2( ) ;
         enableOutput();
         context.GX_webresponse.AddString(GridContainer.ToJavascriptSource());
         /* End function gxgrGrid_refresh */
      }

      protected void Refresh( )
      {
         RF0E2( ) ;
         /* End function Refresh */
      }

      protected void RF0E2( )
      {
         GridContainer.PageSize = subGrid_Recordsperpage( ) ;
         wbStart = 26 ;
         /* Execute user event: E130E2 */
         E130E2 ();
         nGXsfl_26_idx = 1 ;
         sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_26_idx), 4, 0)), 4, "0") ;
         edtavUpdate_Internalname = "_UPDATE_"+sGXsfl_26_idx ;
         edtavDelete_Internalname = "_DELETE_"+sGXsfl_26_idx ;
         edtConsultaFecha_Internalname = "CONSULTAFECHA_"+sGXsfl_26_idx ;
         edtPacienteId_Internalname = "PACIENTEID_"+sGXsfl_26_idx ;
         edtPacienteApellido_Internalname = "PACIENTEAPELLIDO_"+sGXsfl_26_idx ;
         edtPacienteNombre_Internalname = "PACIENTENOMBRE_"+sGXsfl_26_idx ;
         edtPacienteCI_Internalname = "PACIENTECI_"+sGXsfl_26_idx ;
         edtMedicoId_Internalname = "MEDICOID_"+sGXsfl_26_idx ;
         edtMedicoApellido_Internalname = "MEDICOAPELLIDO_"+sGXsfl_26_idx ;
         edtMedicoNombre_Internalname = "MEDICONOMBRE_"+sGXsfl_26_idx ;
         edtEspecialidadMaxPacientes_Internalname = "ESPECIALIDADMAXPACIENTES_"+sGXsfl_26_idx ;
         edtTurnoId_Internalname = "TURNOID_"+sGXsfl_26_idx ;
         edtTurnoNombre_Internalname = "TURNONOMBRE_"+sGXsfl_26_idx ;
         edtConsultaNro_Internalname = "CONSULTANRO_"+sGXsfl_26_idx ;
         chkConfirmado_Internalname = "CONFIRMADO_"+sGXsfl_26_idx ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
         {
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV13PacienteCI ,
                                                 A41PacienteCI },
                                                 new int[] {
                                                 TypeConstants.STRING, TypeConstants.STRING
                                                 }
            });
            lV13PacienteCI = StringUtil.PadR( StringUtil.RTrim( AV13PacienteCI), 8, "%") ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV13PacienteCI", AV13PacienteCI);
            /* Using cursor H000E2 */
            pr_default.execute(0, new Object[] {lV13PacienteCI});
            nGXsfl_26_idx = 1 ;
            GRID_nEOF = 0 ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_Recordsperpage( ) ) ) ) )
            {
               A9EspecialidadId = H000E2_A9EspecialidadId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
               A75Confirmado = H000E2_A75Confirmado[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A75Confirmado", StringUtil.BoolToStr( A75Confirmado));
               A63ConsultaNro = H000E2_A63ConsultaNro[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A63ConsultaNro", StringUtil.LTrim( StringUtil.Str( (decimal)(A63ConsultaNro), 2, 0)));
               n63ConsultaNro = H000E2_n63ConsultaNro[0] ;
               A61TurnoNombre = H000E2_A61TurnoNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
               A60TurnoId = H000E2_A60TurnoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
               A11EspecialidadMaxPacientes = H000E2_A11EspecialidadMaxPacientes[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
               A13MedicoNombre = H000E2_A13MedicoNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
               A14MedicoApellido = H000E2_A14MedicoApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
               A12MedicoId = H000E2_A12MedicoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
               A41PacienteCI = H000E2_A41PacienteCI[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
               A35PacienteNombre = H000E2_A35PacienteNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A35PacienteNombre", A35PacienteNombre);
               A36PacienteApellido = H000E2_A36PacienteApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A36PacienteApellido", A36PacienteApellido);
               A34PacienteId = H000E2_A34PacienteId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
               A43ConsultaFecha = H000E2_A43ConsultaFecha[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
               A61TurnoNombre = H000E2_A61TurnoNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
               A9EspecialidadId = H000E2_A9EspecialidadId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
               A13MedicoNombre = H000E2_A13MedicoNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
               A14MedicoApellido = H000E2_A14MedicoApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
               A11EspecialidadMaxPacientes = H000E2_A11EspecialidadMaxPacientes[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
               A41PacienteCI = H000E2_A41PacienteCI[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
               A35PacienteNombre = H000E2_A35PacienteNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A35PacienteNombre", A35PacienteNombre);
               A36PacienteApellido = H000E2_A36PacienteApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A36PacienteApellido", A36PacienteApellido);
               /* Execute user event: E140E2 */
               E140E2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0)) ;
            pr_default.close(0);
            wbEnd = 26 ;
            WB0E0( ) ;
         }
      }

      protected int subGrid_Pagecount( )
      {
         GRID_nRecordCount = subGrid_Recordcount( ) ;
         if ( ((int)(GRID_nRecordCount) % (subGrid_Recordsperpage( ))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_Recordsperpage( ))))+1) ;
      }

      protected int subGrid_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV13PacienteCI ,
                                              A41PacienteCI },
                                              new int[] {
                                              TypeConstants.STRING, TypeConstants.STRING
                                              }
         });
         lV13PacienteCI = StringUtil.PadR( StringUtil.RTrim( AV13PacienteCI), 8, "%") ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV13PacienteCI", AV13PacienteCI);
         /* Using cursor H000E3 */
         pr_default.execute(1, new Object[] {lV13PacienteCI});
         GRID_nRecordCount = H000E3_AGRID_nRecordCount[0] ;
         pr_default.close(1);
         return GRID_nRecordCount ;
      }

      protected int subGrid_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            if ( 1 > 0 )
            {
               return (int)(subGrid_Rows*1) ;
            }
            else
            {
               return (int)(subGrid_Rows) ;
            }
         }
         return (int)(-1) ;
      }

      protected int subGrid_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID_nFirstRecordOnPage/ (decimal)(subGrid_Recordsperpage( ))))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0 ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_Recordcount( ) ;
         if ( ( GRID_nRecordCount >= subGrid_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (int)(GRID_nFirstRecordOnPage+subGrid_Recordsperpage( )) ;
         }
         else
         {
            return 2 ;
         }
         return 0 ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (int)(GRID_nFirstRecordOnPage-subGrid_Recordsperpage( )) ;
         }
         else
         {
            return 2 ;
         }
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_Recordcount( ) ;
         if ( GRID_nRecordCount > subGrid_Recordsperpage( ) )
         {
            if ( ((int)(GRID_nRecordCount) % (subGrid_Recordsperpage( ))) == 0 )
            {
               GRID_nFirstRecordOnPage = (int)(GRID_nRecordCount-subGrid_Recordsperpage( )) ;
            }
            else
            {
               GRID_nFirstRecordOnPage = (int)(GRID_nRecordCount-((int)(GRID_nRecordCount) % (subGrid_Recordsperpage( )))) ;
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0 ;
         }
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (int)(subGrid_Recordsperpage( )*(nPageNo-1)) ;
         }
         else
         {
            GRID_nFirstRecordOnPage = 0 ;
         }
         return (int)(0) ;
      }

      protected void STRUP0E0( )
      {
         /* Before Start, stand alone formulas. */
         AV18Pgmname = "WWConsultaPaciente" ;
         context.Gx_err = 0 ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0 ;
         /* Execute user event: E120E2 */
         E120E2 ();
         context.wbGlbDoneStart = 1 ;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read variables values. */
            AV13PacienteCI = cgiGet( edtavPacienteci_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV13PacienteCI", AV13PacienteCI);
            /* Read saved values. */
            nRC_Grid = (short)(context.localUtil.CToN( cgiGet( "nRC_Grid"), ",", ".")) ;
            GRID_nFirstRecordOnPage = (int)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", ".")) ;
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", ".")) ;
            subGrid_Rows = (short)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", ".")) ;
            /* Read subfile selected row values. */
            /* Read hidden variables. */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: E120E2 */
         E120E2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E120E2( )
      {
         /* Start Routine */
         new isauthorized(context ).execute(  AV18Pgmname, out  AV5IsAuthorized) ;
         if ( ! AV5IsAuthorized )
         {
            context.wjLoc = formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV18Pgmname)) ;
         }
         subGrid_Rows = 10 ;
         AV14Update = context.GetImagePath( "7c63c2b9-483e-4035-b512-febf9186a274", "", "GeneXusX") ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Bitmap", context.convertURL( AV14Update));
         edtavUpdate_Tooltiptext = "Modifica" ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext);
         AV15Delete = context.GetImagePath( "7695fe89-52c9-4b7e-871e-0e11548f823e", "", "GeneXusX") ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDelete_Internalname, "Bitmap", context.convertURL( AV15Delete));
         edtavDelete_Tooltiptext = "Eliminar" ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext);
         Form.Caption = "Work With Consulta Pacientes" ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, "FORM", "Caption", Form.Caption);
         /* Execute user subroutine: S112 */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: S122 */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E130E2( )
      {
         /* Refresh Routine */
         /* Execute user subroutine: S132 */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      private void E140E2( )
      {
         /* Grid_Load Routine */
         edtavUpdate_Link = formatLink("consultapaciente.aspx") + "?" + UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(DateTimeUtil.FormatDateParm(A43ConsultaFecha)) + "," + UrlEncode("" +A34PacienteId) + "," + UrlEncode("" +A12MedicoId) + "," + UrlEncode("" +A60TurnoId) ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Link", edtavUpdate_Link);
         edtavDelete_Link = formatLink("consultapaciente.aspx") + "?" + UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(DateTimeUtil.FormatDateParm(A43ConsultaFecha)) + "," + UrlEncode("" +A34PacienteId) + "," + UrlEncode("" +A12MedicoId) + "," + UrlEncode("" +A60TurnoId) ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDelete_Internalname, "Link", edtavDelete_Link);
         edtPacienteCI_Link = formatLink("viewconsultapaciente.aspx") + "?" + UrlEncode(DateTimeUtil.FormatDateParm(A43ConsultaFecha)) + "," + UrlEncode("" +A34PacienteId) + "," + UrlEncode("" +A12MedicoId) + "," + UrlEncode("" +A60TurnoId) + "," + UrlEncode(StringUtil.RTrim("")) ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPacienteCI_Internalname, "Link", edtPacienteCI_Link);
         edtConsultaNro_Link = formatLink("viewhistoriaclinica.aspx") + "?" + UrlEncode(DateTimeUtil.FormatDateParm(A43ConsultaFecha)) + "," + UrlEncode("" +A34PacienteId) + "," + UrlEncode("" +A12MedicoId) + "," + UrlEncode("" +A60TurnoId) + "," + UrlEncode(StringUtil.RTrim("")) ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtConsultaNro_Internalname, "Link", edtConsultaNro_Link);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 26 ;
         }
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_Recordsperpage( ) ) ) )
         {
            sendrow_262( ) ;
         }
         GRID_nCurrentRecord = (int)(GRID_nCurrentRecord+1) ;
      }

      protected void E110E2( )
      {
         /* 'DoInsert' Routine */
         context.wjLoc = formatLink("consultapaciente.aspx") + "?" + UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(DateTimeUtil.FormatDateParm(DateTime.MinValue)) + "," + UrlEncode("" +0) + "," + UrlEncode("" +0) + "," + UrlEncode("" +0) ;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            AV9GridState.FromXml(AV7Session.Get(AV18Pgmname+"GridState"), "");
            if ( AV9GridState.gxTpr_Filtervalues.Count >= 1 )
            {
               AV13PacienteCI = ((SdtGridState_FilterValue)AV9GridState.gxTpr_Filtervalues.Item(1)).gxTpr_Value ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV13PacienteCI", AV13PacienteCI);
            }
            if ( AV9GridState.gxTpr_Currentpage > 0 )
            {
               subgrid_gotopage( AV9GridState.gxTpr_Currentpage) ;
            }
         }
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         AV9GridState.FromXml(AV7Session.Get(AV18Pgmname+"GridState"), "");
         AV9GridState.gxTpr_Currentpage = (short)(subGrid_Currentpage( )) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9GridState", (Object)(AV9GridState));
         AV9GridState.gxTpr_Filtervalues.Clear();
         AV10GridStateFilterValue = new SdtGridState_FilterValue(context) ;
         AV10GridStateFilterValue.gxTpr_Value = AV13PacienteCI ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridStateFilterValue", (Object)(AV10GridStateFilterValue));
         AV9GridState.gxTpr_Filtervalues.Add(AV10GridStateFilterValue, 0);
         AV7Session.Set(AV18Pgmname+"GridState", AV9GridState.ToXml(false, "GridState", "taller041"));
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         AV11TrnContext = new SdtTransactionContext(context) ;
         AV11TrnContext.gxTpr_Callerobject = AV18Pgmname ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11TrnContext", (Object)(AV11TrnContext));
         AV11TrnContext.gxTpr_Callerondelete = true ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11TrnContext", (Object)(AV11TrnContext));
         AV11TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11TrnContext", (Object)(AV11TrnContext));
         AV11TrnContext.gxTpr_Transactionname = "ConsultaPaciente" ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11TrnContext", (Object)(AV11TrnContext));
         AV7Session.Set("TrnContext", AV11TrnContext.ToXml(false, "TransactionContext", "taller041"));
      }

      protected void wb_table1_2_0E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTable_Internalname, tblTable_Internalname, "", "ViewTable", 0, "", "", 0, 0, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class=\"SubTitle\" >") ;
            /* Text block */
            ClassString = "" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, 1, 1, 0, "Work With Consulta Pacientes", "", "", "", 0, lblTitletext_Jsonclick, "", StyleString, ClassString, "HLP_WWConsultaPaciente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_8_0E2( true) ;
         }
         else
         {
            wb_table2_8_0E2( false) ;
         }
         return  ;
      }

      protected void wb_table2_8_0E2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table3_19_0E2( true) ;
         }
         else
         {
            wb_table3_19_0E2( false) ;
         }
         return  ;
      }

      protected void wb_table3_19_0E2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_2_0E2e( true) ;
         }
         else
         {
            wb_table1_2_0E2e( false) ;
         }
      }

      protected void wb_table3_19_0E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTablegridcontainer_Internalname, tblTablegridcontainer_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td colspan=\"1\"  style=\"text-align:"+context.GetCssProperty( "Align", "right")+"\">") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"" ;
            ClassString = "PagingButtons" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgInsert_Internalname, "", context.GetImagePath( "5649fbb8-8ce0-4810-a5ce-bd649ea83c3a", "", "GeneXusX"), "GeneXusX", 1, 1, "", "Agrega", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgInsert_Jsonclick, "E\\'DOINSERT\\'.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_WWConsultaPaciente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td valign=\"top\" colspan=\"2\" >") ;
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            if ( GridContainer.GetWrapped() == 1 )
            {
               sStyleString = "" ;
               GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "WorkWith", 0, "", "", 4, 2, sStyleString, "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid_Backcolorstyle == 0 )
               {
                  subGrid_Titlebackstyle = 0 ;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title" ;
                  }
               }
               else
               {
                  subGrid_Titlebackstyle = 1 ;
                  if ( subGrid_Backcolorstyle == 1 )
                  {
                     subGrid_Titlebackcolor = subGrid_Allbackcolor ;
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"UniformTitle" ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"Title" ;
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Consul. Fecha") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Apellido") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "CI") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Medico Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Apellido") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Especialidad Max Pacientes") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Turno Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Turno Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Nro") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Confirmado") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
            }
            else
            {
               GridContainer.Clear();
               GridContainer.SetWrapped(nGXWrapped);
               GridContainer.AddObjectProperty("GridName", "Grid");
               GridContainer.AddObjectProperty("Class", "WorkWith");
               GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(4), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("CmpContext", "");
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", context.convertURL( AV14Update));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", context.convertURL( AV15Delete));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavDelete_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A34PacienteId), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A36PacienteApellido));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A35PacienteNombre));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A41PacienteCI));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtPacienteCI_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12MedicoId), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A14MedicoApellido));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A13MedicoNombre));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11EspecialidadMaxPacientes), 3, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A60TurnoId), 2, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A61TurnoNombre));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A63ConsultaNro), 2, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtConsultaNro_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A75Confirmado));
               GridContainer.AddColumnProperties(GridColumn);
               GridContainer.AddObjectProperty("Allowselection", "false");
               GridContainer.AddObjectProperty("Allowcollapsing", "false");
               GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 9, 0, ".", "")));
            }
         }
         if ( wbEnd == 26 )
         {
            wbEnd = 0 ;
            nRC_Grid = (short)(nGXsfl_26_idx-1) ;
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = " style=\"display:none;\"" ;
               sStyleString = "" ;
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", (Object)(GridContainer));
               GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               if ( context.isAjaxRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'>") ;
               }
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_19_0E2e( true) ;
         }
         else
         {
            wb_table3_19_0E2e( false) ;
         }
      }

      protected void wb_table2_8_0E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTablesearch_Internalname, tblTablesearch_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblFiltertextpacienteci_Internalname, 1, 1, 0, "CI", "", "", "", 0, lblFiltertextpacienteci_Jsonclick, "", StyleString, ClassString, "HLP_WWConsultaPaciente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'',false,'" + sGXsfl_26_idx + "',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtavPacienteci_Internalname, StringUtil.RTrim( AV13PacienteCI), "", 8, "chr", 1, "row", 8, 1, 1, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( AV13PacienteCI, "XXXXXXXX")), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(13);\"", 0, edtavPacienteci_Jsonclick, "", 0, 1, -1, true, "left", "HLP_WWConsultaPaciente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "Separator" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTableseparator_Internalname, 1, 1, 0, " ", "", "", "", 0, lblTableseparator_Jsonclick, "", StyleString, ClassString, "HLP_WWConsultaPaciente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_8_0E2e( true) ;
         }
         else
         {
            wb_table2_8_0E2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override String getresponse( String sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist ;
         context.GX_msglist = LclMsgLst ;
         sDynURL = sGXDynURL ;
         nGotPars = (short)(1) ;
         nGXWrapped = (short)(1) ;
         context.SetWrapped(true);
         PA0E2( ) ;
         WS0E2( ) ;
         WE0E2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst ;
         return "";
      }

      public void responsestatic( String sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "?165260");
         AddThemeStyleSheetFile("", "GeneXusX.css", "?2313925");
         idxLst = 1 ;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( Form.Jscriptsrc.Item(idxLst)), "?5125481");
            idxLst = (int)(idxLst+1) ;
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.spa.js", "?34981");
            context.AddJavascriptSource("wwconsultapaciente.js", "?5125481");
         }
         /* End function include_jscripts */
      }

      protected void sendrow_262( )
      {
         WB0E0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_26_idx <= subGrid_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer) ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0 ;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd" ;
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0 ;
               subGrid_Backcolor = subGrid_Allbackcolor ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, "GridContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subGrid_Backcolor), 9, 0)));
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform" ;
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1 ;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd" ;
               }
               subGrid_Backcolor = (int)(0xF0F0F0) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, "GridContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subGrid_Backcolor), 9, 0)));
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1 ;
               if ( ((int)(nGXsfl_26_idx) % (2)) == 0 )
               {
                  subGrid_Backcolor = (int)(0xE5E5E5) ;
                  context.httpAjaxContext.ajax_rsp_assign_prop("", false, "GridContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subGrid_Backcolor), 9, 0)));
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even" ;
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0xF0F0F0) ;
                  context.httpAjaxContext.ajax_rsp_assign_prop("", false, "GridContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subGrid_Backcolor), 9, 0)));
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd" ;
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+subGrid_Linesclass+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( ">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image" ;
            StyleString = "" ;
            GridRow.AddColumnProperties("bitmap", 2, isAjaxCallMode( ), new Object[] {(String)edtavUpdate_Internalname,(String)"",(String)AV14Update,(String)"GeneXusX",(short)-1,(short)1,(String)"",(String)edtavUpdate_Tooltiptext,(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"",(short)0,(short)0,(String)edtavUpdate_Link,(String)"",(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"",(String)"",(String)"''",(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image" ;
            StyleString = "" ;
            GridRow.AddColumnProperties("bitmap", 2, isAjaxCallMode( ), new Object[] {(String)edtavDelete_Internalname,(String)"",(String)AV15Delete,(String)"GeneXusX",(short)-1,(short)1,(String)"",(String)edtavDelete_Tooltiptext,(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"",(short)0,(short)0,(String)edtavDelete_Link,(String)"",(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"",(String)"",(String)"''",(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtConsultaFecha_Internalname,context.localUtil.Format(A43ConsultaFecha, "99/99/99"),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)8,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( A43ConsultaFecha, "99/99/99"),(String)"",(short)0,(String)edtConsultaFecha_Jsonclick,(String)"",(short)26,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPacienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A34PacienteId), 6, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)6,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A34PacienteId), "ZZZZZ9"),(String)"",(short)0,(String)edtPacienteId_Jsonclick,(String)"",(short)26,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPacienteApellido_Internalname,StringUtil.RTrim( A36PacienteApellido),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A36PacienteApellido, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtPacienteApellido_Jsonclick,(String)"",(short)26,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPacienteNombre_Internalname,StringUtil.RTrim( A35PacienteNombre),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A35PacienteNombre, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtPacienteNombre_Jsonclick,(String)"",(short)26,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPacienteCI_Internalname,StringUtil.RTrim( A41PacienteCI),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)8,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)edtPacienteCI_Link,(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A41PacienteCI, "XXXXXXXX")),(String)"",(short)0,(String)edtPacienteCI_Jsonclick,(String)"",(short)26,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMedicoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12MedicoId), 6, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)6,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A12MedicoId), "ZZZZZ9"),(String)"",(short)0,(String)edtMedicoId_Jsonclick,(String)"",(short)26,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMedicoApellido_Internalname,StringUtil.RTrim( A14MedicoApellido),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A14MedicoApellido, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtMedicoApellido_Jsonclick,(String)"",(short)26,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMedicoNombre_Internalname,StringUtil.RTrim( A13MedicoNombre),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A13MedicoNombre, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtMedicoNombre_Jsonclick,(String)"",(short)26,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtEspecialidadMaxPacientes_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A11EspecialidadMaxPacientes), 3, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)3,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A11EspecialidadMaxPacientes), "ZZ9"),(String)"",(short)0,(String)edtEspecialidadMaxPacientes_Jsonclick,(String)"",(short)26,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTurnoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A60TurnoId), 2, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)2,(short)0,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A60TurnoId), "Z9"),(String)"",(short)0,(String)edtTurnoId_Jsonclick,(String)"",(short)26,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTurnoNombre_Internalname,StringUtil.RTrim( A61TurnoNombre),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A61TurnoNombre, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtTurnoNombre_Jsonclick,(String)"",(short)26,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtConsultaNro_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A63ConsultaNro), 2, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)2,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)edtConsultaNro_Link,(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A63ConsultaNro), "Z9"),(String)"",(short)0,(String)edtConsultaNro_Jsonclick,(String)"",(short)26,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(String)chkConfirmado_Internalname,StringUtil.BoolToStr( A75Confirmado),(String)"",(short)-1,(short)0,(String)"true",(String)"",(String)StyleString,(String)ClassString,(String)""});
            GridContainer.AddRow(GridRow);
            nGXsfl_26_idx = (short)(((subGrid_Islastpage==1)&&(nGXsfl_26_idx+1>subGrid_Recordsperpage( )) ? 1 : nGXsfl_26_idx+1)) ;
            sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_26_idx), 4, 0)), 4, "0") ;
            edtavUpdate_Internalname = "_UPDATE_"+sGXsfl_26_idx ;
            edtavDelete_Internalname = "_DELETE_"+sGXsfl_26_idx ;
            edtConsultaFecha_Internalname = "CONSULTAFECHA_"+sGXsfl_26_idx ;
            edtPacienteId_Internalname = "PACIENTEID_"+sGXsfl_26_idx ;
            edtPacienteApellido_Internalname = "PACIENTEAPELLIDO_"+sGXsfl_26_idx ;
            edtPacienteNombre_Internalname = "PACIENTENOMBRE_"+sGXsfl_26_idx ;
            edtPacienteCI_Internalname = "PACIENTECI_"+sGXsfl_26_idx ;
            edtMedicoId_Internalname = "MEDICOID_"+sGXsfl_26_idx ;
            edtMedicoApellido_Internalname = "MEDICOAPELLIDO_"+sGXsfl_26_idx ;
            edtMedicoNombre_Internalname = "MEDICONOMBRE_"+sGXsfl_26_idx ;
            edtEspecialidadMaxPacientes_Internalname = "ESPECIALIDADMAXPACIENTES_"+sGXsfl_26_idx ;
            edtTurnoId_Internalname = "TURNOID_"+sGXsfl_26_idx ;
            edtTurnoNombre_Internalname = "TURNONOMBRE_"+sGXsfl_26_idx ;
            edtConsultaNro_Internalname = "CONSULTANRO_"+sGXsfl_26_idx ;
            chkConfirmado_Internalname = "CONFIRMADO_"+sGXsfl_26_idx ;
         }
         /* End function sendrow_262 */
      }

      public override void initialize_properties( )
      {
         lblTitletext_Internalname = "TITLETEXT" ;
         lblFiltertextpacienteci_Internalname = "FILTERTEXTPACIENTECI" ;
         edtavPacienteci_Internalname = "_PACIENTECI" ;
         lblTableseparator_Internalname = "TABLESEPARATOR" ;
         tblTablesearch_Internalname = "TABLESEARCH" ;
         imgInsert_Internalname = "INSERT" ;
         tblTablegridcontainer_Internalname = "TABLEGRIDCONTAINER" ;
         tblTable_Internalname = "TABLE" ;
         Form.Internalname = "FORM" ;
         subGrid_Internalname = "GRID" ;
         edtConsultaNro_Jsonclick = "" ;
         edtTurnoNombre_Jsonclick = "" ;
         edtTurnoId_Jsonclick = "" ;
         edtEspecialidadMaxPacientes_Jsonclick = "" ;
         edtMedicoNombre_Jsonclick = "" ;
         edtMedicoApellido_Jsonclick = "" ;
         edtMedicoId_Jsonclick = "" ;
         edtPacienteCI_Jsonclick = "" ;
         edtPacienteNombre_Jsonclick = "" ;
         edtPacienteApellido_Jsonclick = "" ;
         edtPacienteId_Jsonclick = "" ;
         edtConsultaFecha_Jsonclick = "" ;
         edtavPacienteci_Jsonclick = "" ;
         subGrid_Class = "WorkWith" ;
         subGrid_Backcolorstyle = 3 ;
         edtConsultaNro_Link = "" ;
         edtPacienteCI_Link = "" ;
         edtavDelete_Link = "" ;
         edtavUpdate_Link = "" ;
         subGrid_Rows = 0 ;
         Form.Headerrawhtml = "" ;
         Form.Background = "" ;
         Form.Backcolor = (int)(0xFFFFFF) ;
         Form.Caption = "Work With Consulta Paciente" ;
         chkConfirmado.Caption = "" ;
         edtavUpdate_Tooltiptext = "Modifica" ;
         edtavDelete_Tooltiptext = "Eliminar" ;
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
      }

      public override void initialize( )
      {
         gxfirstwebparm = "" ;
         gxfirstwebparm_bkp = "" ;
         edtavDelete_Internalname = "" ;
         AV15Delete = "" ;
         edtavUpdate_Internalname = "" ;
         AV14Update = "" ;
         AV18Pgmname = "" ;
         GXCCtl = "" ;
         chkConfirmado_Internalname = "" ;
         AV13PacienteCI = "" ;
         sDynURL = "" ;
         FormProcess = "" ;
         GX_FocusControl = "" ;
         Form = new GXWebForm();
         sPrefix = "" ;
         sEvt = "" ;
         EvtGridId = "" ;
         EvtRowId = "" ;
         sEvtType = "" ;
         edtConsultaFecha_Internalname = "" ;
         edtPacienteId_Internalname = "" ;
         edtPacienteApellido_Internalname = "" ;
         edtPacienteNombre_Internalname = "" ;
         edtPacienteCI_Internalname = "" ;
         edtMedicoId_Internalname = "" ;
         edtMedicoApellido_Internalname = "" ;
         edtMedicoNombre_Internalname = "" ;
         edtEspecialidadMaxPacientes_Internalname = "" ;
         edtTurnoId_Internalname = "" ;
         edtTurnoNombre_Internalname = "" ;
         edtConsultaNro_Internalname = "" ;
         A43ConsultaFecha = DateTime.MinValue ;
         A36PacienteApellido = "" ;
         A35PacienteNombre = "" ;
         A41PacienteCI = "" ;
         A14MedicoApellido = "" ;
         A13MedicoNombre = "" ;
         A61TurnoNombre = "" ;
         GridContainer = new GXWebGrid( context);
         scmdbuf = "" ;
         lV13PacienteCI = "" ;
         H000E2_A9EspecialidadId = new int[1] ;
         H000E2_A75Confirmado = new bool[] {false} ;
         H000E2_A63ConsultaNro = new short[1] ;
         H000E2_n63ConsultaNro = new bool[] {false} ;
         H000E2_A61TurnoNombre = new String[] {""} ;
         H000E2_A60TurnoId = new short[1] ;
         H000E2_A11EspecialidadMaxPacientes = new short[1] ;
         H000E2_A13MedicoNombre = new String[] {""} ;
         H000E2_A14MedicoApellido = new String[] {""} ;
         H000E2_A12MedicoId = new int[1] ;
         H000E2_A41PacienteCI = new String[] {""} ;
         H000E2_A35PacienteNombre = new String[] {""} ;
         H000E2_A36PacienteApellido = new String[] {""} ;
         H000E2_A34PacienteId = new int[1] ;
         H000E2_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         H000E3_AGRID_nRecordCount = new int[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV9GridState = new SdtGridState(context);
         AV7Session = new GxWebSession( context);
         AV10GridStateFilterValue = new SdtGridState_FilterValue(context);
         AV11TrnContext = new SdtTransactionContext(context);
         sStyleString = "" ;
         ClassString = "" ;
         StyleString = "" ;
         lblTitletext_Jsonclick = "" ;
         TempTags = "" ;
         imgInsert_Jsonclick = "" ;
         subGrid_Linesclass = "" ;
         GXt_char2 = "" ;
         GXt_char1 = "" ;
         GXt_char3 = "" ;
         GXt_char4 = "" ;
         GXt_char5 = "" ;
         GXt_char6 = "" ;
         GXt_char7 = "" ;
         GXt_char8 = "" ;
         GXt_char9 = "" ;
         GXt_char10 = "" ;
         GXt_char11 = "" ;
         GXt_char12 = "" ;
         GXt_char13 = "" ;
         GXt_char14 = "" ;
         GridColumn = new GXWebColumn();
         GXt_char15 = "" ;
         lblFiltertextpacienteci_Jsonclick = "" ;
         lblTableseparator_Jsonclick = "" ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         GridRow = new GXWebRow();
         ROClassString = "" ;
         GXt_char16 = "" ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwconsultapaciente__default(),
            new Object[][] {
                new Object[] {
               H000E2_A9EspecialidadId, H000E2_A75Confirmado, H000E2_A63ConsultaNro, H000E2_n63ConsultaNro, H000E2_A61TurnoNombre, H000E2_A60TurnoId, H000E2_A11EspecialidadMaxPacientes, H000E2_A13MedicoNombre, H000E2_A14MedicoApellido, H000E2_A12MedicoId,
               H000E2_A41PacienteCI, H000E2_A35PacienteNombre, H000E2_A36PacienteApellido, H000E2_A34PacienteId, H000E2_A43ConsultaFecha
               }
               , new Object[] {
               H000E3_AGRID_nRecordCount
               }
            }
         );
         AV18Pgmname = "WWConsultaPaciente" ;
         /* GeneXus formulas. */
         AV18Pgmname = "WWConsultaPaciente" ;
         context.Gx_err = 0 ;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nRC_Grid ;
      private short nGXsfl_26_idx=1 ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short GRID_nEOF ;
      private short subGrid_Rows ;
      private short wbEnd ;
      private short wbStart ;
      private short A11EspecialidadMaxPacientes ;
      private short A60TurnoId ;
      private short A63ConsultaNro ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Collapsed ;
      private short subGrid_Backstyle ;
      private int Grid_PageSize26 ;
      private int GRID_nFirstRecordOnPage ;
      private int A34PacienteId ;
      private int A12MedicoId ;
      private int subGrid_Islastpage ;
      private int GRID_nCurrentRecord ;
      private int A9EspecialidadId ;
      private int GRID_nRecordCount ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_26_idx="0001" ;
      private String edtavDelete_Tooltiptext ;
      private String edtavDelete_Internalname ;
      private String edtavUpdate_Tooltiptext ;
      private String edtavUpdate_Internalname ;
      private String AV18Pgmname ;
      private String GXCCtl ;
      private String chkConfirmado_Internalname ;
      private String AV13PacienteCI ;
      private String sDynURL ;
      private String FormProcess ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtConsultaFecha_Internalname ;
      private String edtPacienteId_Internalname ;
      private String edtPacienteApellido_Internalname ;
      private String edtPacienteNombre_Internalname ;
      private String edtPacienteCI_Internalname ;
      private String edtMedicoId_Internalname ;
      private String edtMedicoApellido_Internalname ;
      private String edtMedicoNombre_Internalname ;
      private String edtEspecialidadMaxPacientes_Internalname ;
      private String edtTurnoId_Internalname ;
      private String edtTurnoNombre_Internalname ;
      private String edtConsultaNro_Internalname ;
      private String A36PacienteApellido ;
      private String A35PacienteNombre ;
      private String A41PacienteCI ;
      private String A14MedicoApellido ;
      private String A13MedicoNombre ;
      private String A61TurnoNombre ;
      private String edtavPacienteci_Internalname ;
      private String scmdbuf ;
      private String lV13PacienteCI ;
      private String edtavUpdate_Link ;
      private String edtavDelete_Link ;
      private String edtPacienteCI_Link ;
      private String edtConsultaNro_Link ;
      private String sStyleString ;
      private String tblTable_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String lblTitletext_Internalname ;
      private String lblTitletext_Jsonclick ;
      private String tblTablegridcontainer_Internalname ;
      private String TempTags ;
      private String imgInsert_Internalname ;
      private String imgInsert_Jsonclick ;
      private String subGrid_Internalname ;
      private String subGrid_Class ;
      private String subGrid_Linesclass ;
      private String GXt_char2 ;
      private String GXt_char1 ;
      private String GXt_char3 ;
      private String GXt_char4 ;
      private String GXt_char5 ;
      private String GXt_char6 ;
      private String GXt_char7 ;
      private String GXt_char8 ;
      private String GXt_char9 ;
      private String GXt_char10 ;
      private String GXt_char11 ;
      private String GXt_char12 ;
      private String GXt_char13 ;
      private String GXt_char14 ;
      private String GXt_char15 ;
      private String tblTablesearch_Internalname ;
      private String lblFiltertextpacienteci_Internalname ;
      private String lblFiltertextpacienteci_Jsonclick ;
      private String edtavPacienteci_Jsonclick ;
      private String lblTableseparator_Internalname ;
      private String lblTableseparator_Jsonclick ;
      private String ROClassString ;
      private String edtConsultaFecha_Jsonclick ;
      private String edtPacienteId_Jsonclick ;
      private String edtPacienteApellido_Jsonclick ;
      private String edtPacienteNombre_Jsonclick ;
      private String edtPacienteCI_Jsonclick ;
      private String edtMedicoId_Jsonclick ;
      private String edtMedicoApellido_Jsonclick ;
      private String edtMedicoNombre_Jsonclick ;
      private String edtEspecialidadMaxPacientes_Jsonclick ;
      private String edtTurnoId_Jsonclick ;
      private String edtTurnoNombre_Jsonclick ;
      private String edtConsultaNro_Jsonclick ;
      private String GXt_char16 ;
      private DateTime A43ConsultaFecha ;
      private bool entryPointCalled ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n63ConsultaNro ;
      private bool A75Confirmado ;
      private bool returnInSub ;
      private bool AV5IsAuthorized ;
      private String AV15Delete ;
      private String AV14Update ;
      private GxWebSession AV7Session ;
      private GXMasterPage MasterPageObj ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkConfirmado ;
      private IDataStoreProvider pr_default ;
      private int[] H000E2_A9EspecialidadId ;
      private bool[] H000E2_A75Confirmado ;
      private short[] H000E2_A63ConsultaNro ;
      private bool[] H000E2_n63ConsultaNro ;
      private String[] H000E2_A61TurnoNombre ;
      private short[] H000E2_A60TurnoId ;
      private short[] H000E2_A11EspecialidadMaxPacientes ;
      private String[] H000E2_A13MedicoNombre ;
      private String[] H000E2_A14MedicoApellido ;
      private int[] H000E2_A12MedicoId ;
      private String[] H000E2_A41PacienteCI ;
      private String[] H000E2_A35PacienteNombre ;
      private String[] H000E2_A36PacienteApellido ;
      private int[] H000E2_A34PacienteId ;
      private DateTime[] H000E2_A43ConsultaFecha ;
      private int[] H000E3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private SdtGridState AV9GridState ;
      private SdtGridState_FilterValue AV10GridStateFilterValue ;
      private SdtTransactionContext AV11TrnContext ;
   }

   public class wwconsultapaciente__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000E2( String AV13PacienteCI ,
                                             String A41PacienteCI )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int17 ;
         GXv_int17 = new short [1] ;
         Object[] GXv_Object18 ;
         GXv_Object18 = new Object [2] ;
         scmdbuf = "SELECT T3.[EspecialidadId], T1.[Confirmado], T1.[ConsultaNro], T2.[TurnoNombre], T1.[TurnoId], T4.[EspecialidadMaxPacientes], T3.[MedicoNombre], T3.[MedicoApellido], T1.[MedicoId], T5.[PacienteCI], T5.[PacienteNombre], T5.[PacienteApellido], T1.[PacienteId], T1.[ConsultaFecha] FROM (((([ConsultaPaciente] T1 WITH (NOLOCK) INNER JOIN [Turno] T2 WITH (NOLOCK) ON T2.[TurnoId] = T1.[TurnoId]) INNER JOIN [Medico] T3 WITH (NOLOCK) ON T3.[MedicoId] = T1.[MedicoId]) INNER JOIN [Especialidad] T4 WITH (NOLOCK) ON T4.[EspecialidadId] = T3.[EspecialidadId]) INNER JOIN [Paciente] T5 WITH (NOLOCK) ON T5.[PacienteId] = T1.[PacienteId])" ;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13PacienteCI)) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (T5.[PacienteCI] like @AV13PacienteCI)" ;
            }
            else
            {
               sWhereString = sWhereString + " (T5.[PacienteCI] like @AV13PacienteCI)" ;
            }
         }
         else
         {
            GXv_int17[0] = 1 ;
         }
         if ( StringUtil.StrCmp("", sWhereString) != 0 )
         {
            scmdbuf = scmdbuf + " WHERE " + sWhereString ;
         }
         scmdbuf = scmdbuf + " ORDER BY T5.[PacienteCI]" ;
         GXv_Object18[0] = scmdbuf ;
         GXv_Object18[1] = (Object)(GXv_int17) ;
         return GXv_Object18 ;
      }

      protected Object[] conditional_H000E3( String AV13PacienteCI ,
                                             String A41PacienteCI )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int19 ;
         GXv_int19 = new short [1] ;
         Object[] GXv_Object20 ;
         GXv_Object20 = new Object [2] ;
         scmdbuf = "SELECT COUNT(*) FROM (((([ConsultaPaciente] T1 WITH (NOLOCK) INNER JOIN [Turno] T5 WITH (NOLOCK) ON T5.[TurnoId] = T1.[TurnoId]) INNER JOIN [Medico] T3 WITH (NOLOCK) ON T3.[MedicoId] = T1.[MedicoId]) INNER JOIN [Especialidad] T4 WITH (NOLOCK) ON T4.[EspecialidadId] = T3.[EspecialidadId]) INNER JOIN [Paciente] T2 WITH (NOLOCK) ON T2.[PacienteId] = T1.[PacienteId])" ;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13PacienteCI)) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (T2.[PacienteCI] like @AV13PacienteCI)" ;
            }
            else
            {
               sWhereString = sWhereString + " (T2.[PacienteCI] like @AV13PacienteCI)" ;
            }
         }
         else
         {
            GXv_int19[0] = 1 ;
         }
         if ( StringUtil.StrCmp("", sWhereString) != 0 )
         {
            scmdbuf = scmdbuf + " WHERE " + sWhereString ;
         }
         scmdbuf = scmdbuf + "" ;
         GXv_Object20[0] = scmdbuf ;
         GXv_Object20[1] = (Object)(GXv_int19) ;
         return GXv_Object20 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H000E2( (String)dynConstraints[0] , (String)dynConstraints[1] );
               case 1 :
                     return conditional_H000E3( (String)dynConstraints[0] , (String)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000E2 ;
          prmH000E2 = new Object[] {
          new Object[] {"@AV13PacienteCI",SqlDbType.Char,8,0}
          } ;
          Object[] prmH000E3 ;
          prmH000E3 = new Object[] {
          new Object[] {"@AV13PacienteCI",SqlDbType.Char,8,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H000E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000E2,11,0,true,false )
             ,new CursorDef("H000E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000E3,1,0,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((String[]) buf[4])[0] = rslt.getString(4, 20) ;
                ((short[]) buf[5])[0] = rslt.getShort(5) ;
                ((short[]) buf[6])[0] = rslt.getShort(6) ;
                ((String[]) buf[7])[0] = rslt.getString(7, 20) ;
                ((String[]) buf[8])[0] = rslt.getString(8, 20) ;
                ((int[]) buf[9])[0] = rslt.getInt(9) ;
                ((String[]) buf[10])[0] = rslt.getString(10, 8) ;
                ((String[]) buf[11])[0] = rslt.getString(11, 20) ;
                ((String[]) buf[12])[0] = rslt.getString(12, 20) ;
                ((int[]) buf[13])[0] = rslt.getInt(13) ;
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(14) ;
                break;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                break;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       short sIdx ;
       switch ( cursor )
       {
             case 0 :
                sIdx = 0 ;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1) ;
                   stmt.SetParameter(sIdx, (String)parms[1]);
                }
                break;
             case 1 :
                sIdx = 0 ;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1) ;
                   stmt.SetParameter(sIdx, (String)parms[1]);
                }
                break;
       }
    }

 }

}
