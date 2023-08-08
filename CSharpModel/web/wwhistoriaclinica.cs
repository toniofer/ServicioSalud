/*
               File: WWHistoriaClinica
        Description: Work With Historia Clinica
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/24/2010 5:39:34.16
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
   public class wwhistoriaclinica : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwhistoriaclinica( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public wwhistoriaclinica( IGxContext context )
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
         dynavTurnoid = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"_TURNOID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1 ;
                  return  ;
               }
               GXDLV_TURNOID112( ) ;
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
               nGXsfl_34_idx = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
               sGXsfl_34_idx = GetNextPar( ) ;
               edtavDisplay_Tooltiptext = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDisplay_Internalname, "Tooltiptext", edtavDisplay_Tooltiptext);
               AV18Display = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDisplay_Internalname, "Bitmap", context.convertURL( AV18Display));
               edtavUpdate_Tooltiptext = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext);
               AV17Update = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Bitmap", context.convertURL( AV17Update));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1 ;
                  return  ;
               }
               gxnrGrid_newrow( nRC_Grid, nGXsfl_34_idx, sGXsfl_34_idx, AV18Display, AV17Update) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               /* GeneXus formulas. */
               Gx_date = DateTimeUtil.Today( ) ;
               AV21Pgmname = "WWHistoriaClinica" ;
               context.Gx_err = 0 ;
               dynavTurnoid.Name = "_TURNOID" ;
               dynavTurnoid.WebTags = "" ;
               Grid_PageSize34 = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
               AV13ConsultaFecha = context.localUtil.ParseDateParm( GetNextPar( )) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV13ConsultaFecha", context.localUtil.Format(AV13ConsultaFecha, "99/99/99"));
               AV14MedicoId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV14MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV14MedicoId), 6, 0)));
               AV15TurnoId = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV15TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV15TurnoId), 2, 0)));
               AV16ConsultaNro = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV16ConsultaNro", StringUtil.LTrim( StringUtil.Str( (decimal)(AV16ConsultaNro), 2, 0)));
               edtavDisplay_Tooltiptext = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDisplay_Internalname, "Tooltiptext", edtavDisplay_Tooltiptext);
               AV18Display = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDisplay_Internalname, "Bitmap", context.convertURL( AV18Display));
               edtavUpdate_Tooltiptext = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext);
               AV17Update = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Bitmap", context.convertURL( AV17Update));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1 ;
                  return  ;
               }
               gxgrGrid_refresh( Grid_PageSize34, AV13ConsultaFecha, AV14MedicoId, AV15TurnoId, AV16ConsultaNro, AV18Display, AV17Update) ;
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
         PA112( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0)) ;
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START112( ) ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" onsubmit=\"try{return gx.csv.validForm()}catch(e){return true;}\" name=\"MAINFORM\" method=\"post\" action=\""+formatLink("wwhistoriaclinica.aspx") +"\" class=\""+"Form"+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         }
      }

      public override void RenderHtmlCloseForm( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH__CONSULTAFECHA", context.localUtil.Format(AV13ConsultaFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH__MEDICOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14MedicoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH__TURNOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15TurnoId), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH__CONSULTANRO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16ConsultaNro), 2, 0, ",", "")));
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
            WE112( ) ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT112( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override String GetPgmname( )
      {
         return "WWHistoriaClinica" ;
      }

      public override String GetPgmdesc( )
      {
         return "Work With Historia Clinica" ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("wwhistoriaclinica.aspx")  ;
      }

      protected void WB110( )
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
            wb_table1_2_112( true) ;
         }
         else
         {
            wb_table1_2_112( false) ;
         }
         return  ;
      }

      protected void wb_table1_2_112e( bool wbgen )
      {
         if ( wbgen )
         {
         }
         wbLoad = true ;
      }

      protected void START112( )
      {
         wbLoad = false ;
         wbEnd = 0 ;
         wbStart = 0 ;
         Form.Meta.addItem("Generator", "GeneXus C#", 0) ;
         Form.Meta.addItem("Version", "10_1_3-34981", 0) ;
         Form.Meta.addItem("Description", "Work With Historia Clinica", 0) ;
         context.wjLoc = "" ;
         context.nUserReturn = 0 ;
         context.wbHandled = 0 ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false ;
         STRUP110( ) ;
      }

      protected void WS112( )
      {
         START112( ) ;
         EVT112( ) ;
      }

      protected void EVT112( )
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
                  if ( context.localUtil.CToD( cgiGet( "GXH__CONSULTAFECHA"), 2) != AV13ConsultaFecha )
                  {
                     GRID_nFirstRecordOnPage = 0 ;
                  }
                  if ( ( context.localUtil.CToN( cgiGet( "GXH__MEDICOID"), ",", ".") != Convert.ToDecimal( AV14MedicoId )) )
                  {
                     GRID_nFirstRecordOnPage = 0 ;
                  }
                  if ( ( context.localUtil.CToN( cgiGet( "GXH__TURNOID"), ",", ".") != Convert.ToDecimal( AV15TurnoId )) )
                  {
                     GRID_nFirstRecordOnPage = 0 ;
                  }
                  if ( ( context.localUtil.CToN( cgiGet( "GXH__CONSULTANRO"), ",", ".") != Convert.ToDecimal( AV16ConsultaNro )) )
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_34_idx = (short)(NumberUtil.Val( sEvtType, ".")) ;
                              sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_34_idx), 4, 0)), 4, "0") ;
                              edtavUpdate_Internalname = "_UPDATE_"+sGXsfl_34_idx ;
                              edtavDisplay_Internalname = "_DISPLAY_"+sGXsfl_34_idx ;
                              edtConsultaFecha_Internalname = "CONSULTAFECHA_"+sGXsfl_34_idx ;
                              edtTurnoId_Internalname = "TURNOID_"+sGXsfl_34_idx ;
                              edtTurnoNombre_Internalname = "TURNONOMBRE_"+sGXsfl_34_idx ;
                              edtConsultaNro_Internalname = "CONSULTANRO_"+sGXsfl_34_idx ;
                              edtPacienteId_Internalname = "PACIENTEID_"+sGXsfl_34_idx ;
                              edtPacienteApellido_Internalname = "PACIENTEAPELLIDO_"+sGXsfl_34_idx ;
                              edtPacienteNombre_Internalname = "PACIENTENOMBRE_"+sGXsfl_34_idx ;
                              edtPacienteCI_Internalname = "PACIENTECI_"+sGXsfl_34_idx ;
                              edtMedicoId_Internalname = "MEDICOID_"+sGXsfl_34_idx ;
                              edtMedicoApellido_Internalname = "MEDICOAPELLIDO_"+sGXsfl_34_idx ;
                              edtMedicoNombre_Internalname = "MEDICONOMBRE_"+sGXsfl_34_idx ;
                              edtMotivoConsulta_Internalname = "MOTIVOCONSULTA_"+sGXsfl_34_idx ;
                              edtAnotacionesConsulta_Internalname = "ANOTACIONESCONSULTA_"+sGXsfl_34_idx ;
                              AV17Update = cgiGet( "GXimg"+edtavUpdate_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Bitmap", context.convertURL( AV17Update));
                              AV18Display = cgiGet( "GXimg"+edtavDisplay_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDisplay_Internalname, "Bitmap", context.convertURL( AV18Display));
                              A43ConsultaFecha = context.localUtil.CToD( cgiGet( edtConsultaFecha_Internalname), 2) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
                              A60TurnoId = (short)(context.localUtil.CToN( cgiGet( edtTurnoId_Internalname), ",", ".")) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
                              A61TurnoNombre = cgiGet( edtTurnoNombre_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
                              A63ConsultaNro = (short)(context.localUtil.CToN( cgiGet( edtConsultaNro_Internalname), ",", ".")) ;
                              n63ConsultaNro = false ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A63ConsultaNro", StringUtil.LTrim( StringUtil.Str( (decimal)(A63ConsultaNro), 2, 0)));
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
                              A68MotivoConsulta = cgiGet( edtMotivoConsulta_Internalname) ;
                              n68MotivoConsulta = false ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A68MotivoConsulta", A68MotivoConsulta);
                              A69AnotacionesConsulta = cgiGet( edtAnotacionesConsulta_Internalname) ;
                              n69AnotacionesConsulta = false ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A69AnotacionesConsulta", A69AnotacionesConsulta);
                              sEvtType = StringUtil.Right( sEvt, 1) ;
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1)) ;
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    dynload_actions( ) ;
                                    /* Execute user event: E11112 */
                                    E11112 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    dynload_actions( ) ;
                                    /* Execute user event: E12112 */
                                    E12112 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    dynload_actions( ) ;
                                    /* Execute user event: E13112 */
                                    E13112 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false ;
                                       /* Set Refresh If Consultafecha Changed */
                                       if ( context.localUtil.CToD( cgiGet( "GXH__CONSULTAFECHA"), 2) != AV13ConsultaFecha )
                                       {
                                          Rfr0gs = true ;
                                       }
                                       /* Set Refresh If Medicoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH__MEDICOID"), ",", ".") != Convert.ToDecimal( AV14MedicoId )) )
                                       {
                                          Rfr0gs = true ;
                                       }
                                       /* Set Refresh If Turnoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH__TURNOID"), ",", ".") != Convert.ToDecimal( AV15TurnoId )) )
                                       {
                                          Rfr0gs = true ;
                                       }
                                       /* Set Refresh If Consultanro Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH__CONSULTANRO"), ",", ".") != Convert.ToDecimal( AV16ConsultaNro )) )
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

      protected void WE112( )
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

      protected void PA112( )
      {
         if ( nDonePA == 0 )
         {
            dynavTurnoid.Name = "_TURNOID" ;
            dynavTurnoid.WebTags = "" ;
            GX_FocusControl = edtavConsultafecha_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            nDonePA = 1 ;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLV_TURNOID112( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "max-age=0");
         }
         context.GX_webresponse.AddString("(new Array( new Array(");
         GXDLV_TURNOID_data112( ) ;
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

      protected void GXV_TURNOID_html112( )
      {
         short gxdynajaxvalue ;
         GXDLV_TURNOID_data112( ) ;
         gxdynajaxindex = 1 ;
         dynavTurnoid.removeAllItems();
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( gxdynajaxctrlcodr.Item(gxdynajaxindex), ".")) ;
            dynavTurnoid.addItem(StringUtil.Str( (decimal)(gxdynajaxvalue), 2, 0), gxdynajaxctrldescr.Item(gxdynajaxindex), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1) ;
         }
         if ( ! context.isAjaxRequest( ) )
         {
            if ( ( dynavTurnoid.ItemCount > 0 ) && (0==AV15TurnoId) )
            {
               AV15TurnoId = (short)(NumberUtil.Val( dynavTurnoid.getItemValue(1), ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV15TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV15TurnoId), 2, 0)));
            }
         }
      }

      protected void GXDLV_TURNOID_data112( )
      {
         /* Using cursor H00112 */
         pr_default.execute(0);
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("Todos");
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00112_A60TurnoId[0]), 2, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00112_A61TurnoNombre[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGrid_newrow( short nRC_Grid ,
                                      short nGXsfl_34_idx ,
                                      String sGXsfl_34_idx ,
                                      String AV18Display ,
                                      String AV17Update )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         edtavUpdate_Internalname = "_UPDATE_"+sGXsfl_34_idx ;
         edtavDisplay_Internalname = "_DISPLAY_"+sGXsfl_34_idx ;
         edtConsultaFecha_Internalname = "CONSULTAFECHA_"+sGXsfl_34_idx ;
         edtTurnoId_Internalname = "TURNOID_"+sGXsfl_34_idx ;
         edtTurnoNombre_Internalname = "TURNONOMBRE_"+sGXsfl_34_idx ;
         edtConsultaNro_Internalname = "CONSULTANRO_"+sGXsfl_34_idx ;
         edtPacienteId_Internalname = "PACIENTEID_"+sGXsfl_34_idx ;
         edtPacienteApellido_Internalname = "PACIENTEAPELLIDO_"+sGXsfl_34_idx ;
         edtPacienteNombre_Internalname = "PACIENTENOMBRE_"+sGXsfl_34_idx ;
         edtPacienteCI_Internalname = "PACIENTECI_"+sGXsfl_34_idx ;
         edtMedicoId_Internalname = "MEDICOID_"+sGXsfl_34_idx ;
         edtMedicoApellido_Internalname = "MEDICOAPELLIDO_"+sGXsfl_34_idx ;
         edtMedicoNombre_Internalname = "MEDICONOMBRE_"+sGXsfl_34_idx ;
         edtMotivoConsulta_Internalname = "MOTIVOCONSULTA_"+sGXsfl_34_idx ;
         edtAnotacionesConsulta_Internalname = "ANOTACIONESCONSULTA_"+sGXsfl_34_idx ;
         while ( nGXsfl_34_idx <= nRC_Grid )
         {
            sendrow_342( ) ;
            nGXsfl_34_idx = (short)(((subGrid_Islastpage==1)&&(nGXsfl_34_idx+1>subGrid_Recordsperpage( )) ? 1 : nGXsfl_34_idx+1)) ;
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_34_idx), 4, 0)), 4, "0") ;
            edtavUpdate_Internalname = "_UPDATE_"+sGXsfl_34_idx ;
            edtavDisplay_Internalname = "_DISPLAY_"+sGXsfl_34_idx ;
            edtConsultaFecha_Internalname = "CONSULTAFECHA_"+sGXsfl_34_idx ;
            edtTurnoId_Internalname = "TURNOID_"+sGXsfl_34_idx ;
            edtTurnoNombre_Internalname = "TURNONOMBRE_"+sGXsfl_34_idx ;
            edtConsultaNro_Internalname = "CONSULTANRO_"+sGXsfl_34_idx ;
            edtPacienteId_Internalname = "PACIENTEID_"+sGXsfl_34_idx ;
            edtPacienteApellido_Internalname = "PACIENTEAPELLIDO_"+sGXsfl_34_idx ;
            edtPacienteNombre_Internalname = "PACIENTENOMBRE_"+sGXsfl_34_idx ;
            edtPacienteCI_Internalname = "PACIENTECI_"+sGXsfl_34_idx ;
            edtMedicoId_Internalname = "MEDICOID_"+sGXsfl_34_idx ;
            edtMedicoApellido_Internalname = "MEDICOAPELLIDO_"+sGXsfl_34_idx ;
            edtMedicoNombre_Internalname = "MEDICONOMBRE_"+sGXsfl_34_idx ;
            edtMotivoConsulta_Internalname = "MOTIVOCONSULTA_"+sGXsfl_34_idx ;
            edtAnotacionesConsulta_Internalname = "ANOTACIONESCONSULTA_"+sGXsfl_34_idx ;
         }
         context.GX_webresponse.AddString(GridContainer.ToJavascriptSource());
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int Grid_PageSize34 ,
                                       DateTime AV13ConsultaFecha ,
                                       int AV14MedicoId ,
                                       short AV15TurnoId ,
                                       short AV16ConsultaNro ,
                                       String AV18Display ,
                                       String AV17Update )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         disableOutput();
         subGrid_Rows = (short)(Grid_PageSize34) ;
         RF112( ) ;
         enableOutput();
         context.GX_webresponse.AddString(GridContainer.ToJavascriptSource());
         /* End function gxgrGrid_refresh */
      }

      protected void Refresh( )
      {
         RF112( ) ;
         /* End function Refresh */
      }

      protected void RF112( )
      {
         GridContainer.PageSize = subGrid_Recordsperpage( ) ;
         wbStart = 34 ;
         /* Execute user event: E12112 */
         E12112 ();
         nGXsfl_34_idx = 1 ;
         sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_34_idx), 4, 0)), 4, "0") ;
         edtavUpdate_Internalname = "_UPDATE_"+sGXsfl_34_idx ;
         edtavDisplay_Internalname = "_DISPLAY_"+sGXsfl_34_idx ;
         edtConsultaFecha_Internalname = "CONSULTAFECHA_"+sGXsfl_34_idx ;
         edtTurnoId_Internalname = "TURNOID_"+sGXsfl_34_idx ;
         edtTurnoNombre_Internalname = "TURNONOMBRE_"+sGXsfl_34_idx ;
         edtConsultaNro_Internalname = "CONSULTANRO_"+sGXsfl_34_idx ;
         edtPacienteId_Internalname = "PACIENTEID_"+sGXsfl_34_idx ;
         edtPacienteApellido_Internalname = "PACIENTEAPELLIDO_"+sGXsfl_34_idx ;
         edtPacienteNombre_Internalname = "PACIENTENOMBRE_"+sGXsfl_34_idx ;
         edtPacienteCI_Internalname = "PACIENTECI_"+sGXsfl_34_idx ;
         edtMedicoId_Internalname = "MEDICOID_"+sGXsfl_34_idx ;
         edtMedicoApellido_Internalname = "MEDICOAPELLIDO_"+sGXsfl_34_idx ;
         edtMedicoNombre_Internalname = "MEDICONOMBRE_"+sGXsfl_34_idx ;
         edtMotivoConsulta_Internalname = "MOTIVOCONSULTA_"+sGXsfl_34_idx ;
         edtAnotacionesConsulta_Internalname = "ANOTACIONESCONSULTA_"+sGXsfl_34_idx ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
         {
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV16ConsultaNro ,
                                                 AV13ConsultaFecha ,
                                                 AV14MedicoId ,
                                                 AV15TurnoId ,
                                                 A63ConsultaNro ,
                                                 A43ConsultaFecha ,
                                                 A12MedicoId ,
                                                 A60TurnoId },
                                                 new int[] {
                                                 TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.INT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor H00113 */
            pr_default.execute(1, new Object[] {AV16ConsultaNro, AV13ConsultaFecha, AV14MedicoId, AV15TurnoId});
            nGXsfl_34_idx = 1 ;
            GRID_nEOF = 0 ;
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_Recordsperpage( ) ) ) ) )
            {
               A69AnotacionesConsulta = H00113_A69AnotacionesConsulta[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A69AnotacionesConsulta", A69AnotacionesConsulta);
               n69AnotacionesConsulta = H00113_n69AnotacionesConsulta[0] ;
               A68MotivoConsulta = H00113_A68MotivoConsulta[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A68MotivoConsulta", A68MotivoConsulta);
               n68MotivoConsulta = H00113_n68MotivoConsulta[0] ;
               A13MedicoNombre = H00113_A13MedicoNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
               A14MedicoApellido = H00113_A14MedicoApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
               A12MedicoId = H00113_A12MedicoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
               A41PacienteCI = H00113_A41PacienteCI[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
               A35PacienteNombre = H00113_A35PacienteNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A35PacienteNombre", A35PacienteNombre);
               A36PacienteApellido = H00113_A36PacienteApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A36PacienteApellido", A36PacienteApellido);
               A34PacienteId = H00113_A34PacienteId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
               A63ConsultaNro = H00113_A63ConsultaNro[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A63ConsultaNro", StringUtil.LTrim( StringUtil.Str( (decimal)(A63ConsultaNro), 2, 0)));
               n63ConsultaNro = H00113_n63ConsultaNro[0] ;
               A61TurnoNombre = H00113_A61TurnoNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
               A60TurnoId = H00113_A60TurnoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
               A43ConsultaFecha = H00113_A43ConsultaFecha[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
               A13MedicoNombre = H00113_A13MedicoNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
               A14MedicoApellido = H00113_A14MedicoApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
               A41PacienteCI = H00113_A41PacienteCI[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
               A35PacienteNombre = H00113_A35PacienteNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A35PacienteNombre", A35PacienteNombre);
               A36PacienteApellido = H00113_A36PacienteApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A36PacienteApellido", A36PacienteApellido);
               A61TurnoNombre = H00113_A61TurnoNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
               /* Execute user event: E13112 */
               E13112 ();
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0)) ;
            pr_default.close(1);
            wbEnd = 34 ;
            WB110( ) ;
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
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV16ConsultaNro ,
                                              AV13ConsultaFecha ,
                                              AV14MedicoId ,
                                              AV15TurnoId ,
                                              A63ConsultaNro ,
                                              A43ConsultaFecha ,
                                              A12MedicoId ,
                                              A60TurnoId },
                                              new int[] {
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor H00114 */
         pr_default.execute(2, new Object[] {AV16ConsultaNro, AV13ConsultaFecha, AV14MedicoId, AV15TurnoId});
         GRID_nRecordCount = H00114_AGRID_nRecordCount[0] ;
         pr_default.close(2);
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

      protected void STRUP110( )
      {
         /* Before Start, stand alone formulas. */
         Gx_date = DateTimeUtil.Today( ) ;
         AV21Pgmname = "WWHistoriaClinica" ;
         context.Gx_err = 0 ;
         GXV_TURNOID_html112( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0 ;
         /* Execute user event: E11112 */
         E11112 ();
         context.wbGlbDoneStart = 1 ;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtavConsultafecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Consulta Fecha"}), 1, "_CONSULTAFECHA");
               GX_FocusControl = edtavConsultafecha_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true ;
               AV13ConsultaFecha = DateTime.MinValue ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV13ConsultaFecha", context.localUtil.Format(AV13ConsultaFecha, "99/99/99"));
            }
            else
            {
               AV13ConsultaFecha = context.localUtil.CToD( cgiGet( edtavConsultafecha_Internalname), 2) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV13ConsultaFecha", context.localUtil.Format(AV13ConsultaFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMedicoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMedicoid_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum"), 1, "_MEDICOID");
               GX_FocusControl = edtavMedicoid_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true ;
               AV14MedicoId = 0 ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV14MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV14MedicoId), 6, 0)));
            }
            else
            {
               AV14MedicoId = (int)(context.localUtil.CToN( cgiGet( edtavMedicoid_Internalname), ",", ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV14MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV14MedicoId), 6, 0)));
            }
            dynavTurnoid.Name = dynavTurnoid_Internalname ;
            dynavTurnoid.CurrentValue = cgiGet( dynavTurnoid_Internalname) ;
            AV15TurnoId = (short)(NumberUtil.Val( cgiGet( dynavTurnoid_Internalname), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV15TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV15TurnoId), 2, 0)));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavConsultanro_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavConsultanro_Internalname), ",", ".") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum"), 1, "_CONSULTANRO");
               GX_FocusControl = edtavConsultanro_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true ;
               AV16ConsultaNro = 0 ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV16ConsultaNro", StringUtil.LTrim( StringUtil.Str( (decimal)(AV16ConsultaNro), 2, 0)));
            }
            else
            {
               AV16ConsultaNro = (short)(context.localUtil.CToN( cgiGet( edtavConsultanro_Internalname), ",", ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV16ConsultaNro", StringUtil.LTrim( StringUtil.Str( (decimal)(AV16ConsultaNro), 2, 0)));
            }
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
         /* Execute user event: E11112 */
         E11112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11112( )
      {
         /* Start Routine */
         new isauthorized(context ).execute(  AV21Pgmname, out  AV5IsAuthorized) ;
         if ( ! AV5IsAuthorized )
         {
            context.wjLoc = formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV21Pgmname)) ;
         }
         subGrid_Rows = 10 ;
         AV17Update = context.GetImagePath( "7c63c2b9-483e-4035-b512-febf9186a274", "", "GeneXusX") ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Bitmap", context.convertURL( AV17Update));
         edtavUpdate_Tooltiptext = "Modifica" ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext);
         AV18Display = context.GetImagePath( "f11923b6-6acd-4a79-bfc0-0cfc6f3bced5", "", "GeneXusX") ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDisplay_Internalname, "Bitmap", context.convertURL( AV18Display));
         edtavDisplay_Tooltiptext = "Visualizar" ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDisplay_Internalname, "Tooltiptext", edtavDisplay_Tooltiptext);
         AV13ConsultaFecha = Gx_date ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV13ConsultaFecha", context.localUtil.Format(AV13ConsultaFecha, "99/99/99"));
         Form.Caption = "Work With Historia Clinicas" ;
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

      protected void E12112( )
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

      private void E13112( )
      {
         /* Grid_Load Routine */
         edtavUpdate_Link = formatLink("historiaclinica.aspx") + "?" + UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(DateTimeUtil.FormatDateParm(A43ConsultaFecha)) + "," + UrlEncode("" +A34PacienteId) + "," + UrlEncode("" +A12MedicoId) + "," + UrlEncode("" +A60TurnoId) ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Link", edtavUpdate_Link);
         edtavDisplay_Link = formatLink("historiaclinica.aspx") + "?" + UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(DateTimeUtil.FormatDateParm(A43ConsultaFecha)) + "," + UrlEncode("" +A34PacienteId) + "," + UrlEncode("" +A12MedicoId) + "," + UrlEncode("" +A60TurnoId) ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDisplay_Internalname, "Link", edtavDisplay_Link);
         edtConsultaNro_Link = formatLink("viewhistoriaclinica.aspx") + "?" + UrlEncode(DateTimeUtil.FormatDateParm(A43ConsultaFecha)) + "," + UrlEncode("" +A34PacienteId) + "," + UrlEncode("" +A12MedicoId) + "," + UrlEncode("" +A60TurnoId) + "," + UrlEncode(StringUtil.RTrim("")) ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtConsultaNro_Internalname, "Link", edtConsultaNro_Link);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 34 ;
         }
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_Recordsperpage( ) ) ) )
         {
            sendrow_342( ) ;
         }
         GRID_nCurrentRecord = (int)(GRID_nCurrentRecord+1) ;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            AV9GridState.FromXml(AV7Session.Get(AV21Pgmname+"GridState"), "");
            if ( AV9GridState.gxTpr_Filtervalues.Count >= 4 )
            {
               AV13ConsultaFecha = context.localUtil.CToD( ((SdtGridState_FilterValue)AV9GridState.gxTpr_Filtervalues.Item(1)).gxTpr_Value, 2) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV13ConsultaFecha", context.localUtil.Format(AV13ConsultaFecha, "99/99/99"));
               AV14MedicoId = (int)(NumberUtil.Val( ((SdtGridState_FilterValue)AV9GridState.gxTpr_Filtervalues.Item(2)).gxTpr_Value, ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV14MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV14MedicoId), 6, 0)));
               AV15TurnoId = (short)(NumberUtil.Val( ((SdtGridState_FilterValue)AV9GridState.gxTpr_Filtervalues.Item(3)).gxTpr_Value, ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV15TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV15TurnoId), 2, 0)));
               AV16ConsultaNro = (short)(NumberUtil.Val( ((SdtGridState_FilterValue)AV9GridState.gxTpr_Filtervalues.Item(4)).gxTpr_Value, ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV16ConsultaNro", StringUtil.LTrim( StringUtil.Str( (decimal)(AV16ConsultaNro), 2, 0)));
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
         AV9GridState.FromXml(AV7Session.Get(AV21Pgmname+"GridState"), "");
         AV9GridState.gxTpr_Currentpage = (short)(subGrid_Currentpage( )) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9GridState", (Object)(AV9GridState));
         AV9GridState.gxTpr_Filtervalues.Clear();
         AV10GridStateFilterValue = new SdtGridState_FilterValue(context) ;
         AV10GridStateFilterValue.gxTpr_Value = context.localUtil.DToC( AV13ConsultaFecha, 2, "/") ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridStateFilterValue", (Object)(AV10GridStateFilterValue));
         AV9GridState.gxTpr_Filtervalues.Add(AV10GridStateFilterValue, 0);
         AV10GridStateFilterValue = new SdtGridState_FilterValue(context) ;
         AV10GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV14MedicoId), 6, 0) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridStateFilterValue", (Object)(AV10GridStateFilterValue));
         AV9GridState.gxTpr_Filtervalues.Add(AV10GridStateFilterValue, 0);
         AV10GridStateFilterValue = new SdtGridState_FilterValue(context) ;
         AV10GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV15TurnoId), 2, 0) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridStateFilterValue", (Object)(AV10GridStateFilterValue));
         AV9GridState.gxTpr_Filtervalues.Add(AV10GridStateFilterValue, 0);
         AV10GridStateFilterValue = new SdtGridState_FilterValue(context) ;
         AV10GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV16ConsultaNro), 2, 0) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridStateFilterValue", (Object)(AV10GridStateFilterValue));
         AV9GridState.gxTpr_Filtervalues.Add(AV10GridStateFilterValue, 0);
         AV7Session.Set(AV21Pgmname+"GridState", AV9GridState.ToXml(false, "GridState", "taller041"));
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         AV11TrnContext = new SdtTransactionContext(context) ;
         AV11TrnContext.gxTpr_Callerobject = AV21Pgmname ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11TrnContext", (Object)(AV11TrnContext));
         AV11TrnContext.gxTpr_Callerondelete = true ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11TrnContext", (Object)(AV11TrnContext));
         AV11TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11TrnContext", (Object)(AV11TrnContext));
         AV11TrnContext.gxTpr_Transactionname = "HistoriaClinica" ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11TrnContext", (Object)(AV11TrnContext));
         AV7Session.Set("TrnContext", AV11TrnContext.ToXml(false, "TransactionContext", "taller041"));
      }

      protected void wb_table1_2_112( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, 1, 1, 0, "Work With Historia Clinicas", "", "", "", 0, lblTitletext_Jsonclick, "", StyleString, ClassString, "HLP_WWHistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_8_112( true) ;
         }
         else
         {
            wb_table2_8_112( false) ;
         }
         return  ;
      }

      protected void wb_table2_8_112e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
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
               context.SendWebValue( "Fecha") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Turno") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Turno") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Nro") ;
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
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Motivo Consulta") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Anotaciones Consulta") ;
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
               GridColumn.AddObjectProperty("Value", context.convertURL( AV17Update));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", context.convertURL( AV18Display));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavDisplay_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
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
               GridColumn.AddObjectProperty("Value", A68MotivoConsulta);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", A69AnotacionesConsulta);
               GridContainer.AddColumnProperties(GridColumn);
               GridContainer.AddObjectProperty("Allowselection", "false");
               GridContainer.AddObjectProperty("Allowcollapsing", "false");
               GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 9, 0, ".", "")));
            }
         }
         if ( wbEnd == 34 )
         {
            wbEnd = 0 ;
            nRC_Grid = (short)(nGXsfl_34_idx-1) ;
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
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_2_112e( true) ;
         }
         else
         {
            wb_table1_2_112e( false) ;
         }
      }

      protected void wb_table2_8_112( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblFiltertextconsultafecha_Internalname, 1, 1, 0, "Fecha Consulta", "", "", "", 0, lblFiltertextconsultafecha_Jsonclick, "", StyleString, ClassString, "HLP_WWHistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'',false,'" + sGXsfl_34_idx + "',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            if ( ( 1 == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlText( "<table id=\""+edtavConsultafecha_Internalname+"_dp_container\" cellpadding=\"0\" cellspacing=\"0\"><tr><td>") ;
            }
            GxWebStd.gx_single_line_edit( context, edtavConsultafecha_Internalname, context.localUtil.Format(AV13ConsultaFecha, "99/99/99"), "", 8, "chr", 1, "row", 8, 1, 1, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( AV13ConsultaFecha, "99/99/99"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(13);\"", 0, edtavConsultafecha_Jsonclick, "", 0, 1, -1, true, "right", "HLP_WWHistoriaClinica.htm");
            if ( ( 1 == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlTextNl( "</td><td>") ;
               context.WriteHtmlText( "<img src=\""+context.convertURL( "calendar-img.gif")+"\" id=\""+edtavConsultafecha_Internalname+"_dp_trigger\" style=\"cursor: pointer;\" title=\"Date selector\" alt=\"Date selector\" >") ;
               context.WriteHtmlTextNl( "</td></tr></table>") ;
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblFiltertextmedicoid_Internalname, 1, 1, 0, "Médico Id", "", "", "", 0, lblFiltertextmedicoid_Jsonclick, "", StyleString, ClassString, "HLP_WWHistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'" + sGXsfl_34_idx + "',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtavMedicoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14MedicoId), 6, 0, ",", "")), "", 6, "chr", 1, "row", 6, 1, 1, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(AV14MedicoId), "ZZZZZ9"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(18);\"", 0, edtavMedicoid_Jsonclick, "", 0, 1, -1, true, "right", "HLP_WWHistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblFiltertextturnoid_Internalname, 1, 1, 0, "Turno Id", "", "", "", 0, lblFiltertextturnoid_Jsonclick, "", StyleString, ClassString, "HLP_WWHistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'" + sGXsfl_34_idx + "',0)\"" ;
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavTurnoid, dynavTurnoid_Internalname, StringUtil.Str( (decimal)(AV15TurnoId), 2, 0), "", "int", 1, 1, 0, 1, 0, 20, "chr", 0, "", StyleString, ClassString, "", 0, dynavTurnoid_Jsonclick, "", TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(23);\"", true, "HLP_WWHistoriaClinica.htm");
            dynavTurnoid.CurrentValue = StringUtil.LTrim( StringUtil.Str( (decimal)(AV15TurnoId), 2, 0)) ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, dynavTurnoid_Internalname, "Values", (String)(dynavTurnoid.ToJavascriptSource()));
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblFiltertextconsultanro_Internalname, 1, 1, 0, "Nro", "", "", "", 0, lblFiltertextconsultanro_Jsonclick, "", StyleString, ClassString, "HLP_WWHistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_34_idx + "',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtavConsultanro_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16ConsultaNro), 2, 0, ",", "")), "", 2, "chr", 1, "row", 2, 1, 1, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(AV16ConsultaNro), "Z9"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(28);\"", 0, edtavConsultanro_Jsonclick, "", 0, 1, -1, true, "right", "HLP_WWHistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "Separator" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTableseparator_Internalname, 1, 1, 0, " ", "", "", "", 0, lblTableseparator_Jsonclick, "", StyleString, ClassString, "HLP_WWHistoriaClinica.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_8_112e( true) ;
         }
         else
         {
            wb_table2_8_112e( false) ;
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
         PA112( ) ;
         WS112( ) ;
         WE112( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( Form.Jscriptsrc.Item(idxLst)), "?5393631");
            idxLst = (int)(idxLst+1) ;
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.spa.js", "?34981");
            context.AddJavascriptSource("wwhistoriaclinica.js", "?5393633");
         }
         /* End function include_jscripts */
      }

      protected void sendrow_342( )
      {
         WB110( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_34_idx <= subGrid_Recordsperpage( ) * 1 ) )
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
               if ( ((int)(nGXsfl_34_idx) % (2)) == 0 )
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
            GridRow.AddColumnProperties("bitmap", 2, isAjaxCallMode( ), new Object[] {(String)edtavUpdate_Internalname,(String)"",(String)AV17Update,(String)"GeneXusX",(short)-1,(short)1,(String)"",(String)edtavUpdate_Tooltiptext,(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"",(short)0,(short)0,(String)edtavUpdate_Link,(String)"",(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"",(String)"",(String)"''",(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image" ;
            StyleString = "" ;
            GridRow.AddColumnProperties("bitmap", 2, isAjaxCallMode( ), new Object[] {(String)edtavDisplay_Internalname,(String)"",(String)AV18Display,(String)"GeneXusX",(short)-1,(short)1,(String)"",(String)edtavDisplay_Tooltiptext,(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"",(short)0,(short)0,(String)edtavDisplay_Link,(String)"",(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"",(String)"",(String)"''",(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtConsultaFecha_Internalname,context.localUtil.Format(A43ConsultaFecha, "99/99/99"),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)8,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( A43ConsultaFecha, "99/99/99"),(String)"",(short)0,(String)edtConsultaFecha_Jsonclick,(String)"",(short)34,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTurnoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A60TurnoId), 2, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)2,(short)0,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A60TurnoId), "Z9"),(String)"",(short)0,(String)edtTurnoId_Jsonclick,(String)"",(short)34,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTurnoNombre_Internalname,StringUtil.RTrim( A61TurnoNombre),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A61TurnoNombre, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtTurnoNombre_Jsonclick,(String)"",(short)34,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtConsultaNro_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A63ConsultaNro), 2, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)2,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)edtConsultaNro_Link,(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A63ConsultaNro), "Z9"),(String)"",(short)0,(String)edtConsultaNro_Jsonclick,(String)"",(short)34,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPacienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A34PacienteId), 6, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)6,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A34PacienteId), "ZZZZZ9"),(String)"",(short)0,(String)edtPacienteId_Jsonclick,(String)"",(short)34,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPacienteApellido_Internalname,StringUtil.RTrim( A36PacienteApellido),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A36PacienteApellido, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtPacienteApellido_Jsonclick,(String)"",(short)34,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPacienteNombre_Internalname,StringUtil.RTrim( A35PacienteNombre),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A35PacienteNombre, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtPacienteNombre_Jsonclick,(String)"",(short)34,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPacienteCI_Internalname,StringUtil.RTrim( A41PacienteCI),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)8,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A41PacienteCI, "XXXXXXXX")),(String)"",(short)0,(String)edtPacienteCI_Jsonclick,(String)"",(short)34,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMedicoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12MedicoId), 6, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)6,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A12MedicoId), "ZZZZZ9"),(String)"",(short)0,(String)edtMedicoId_Jsonclick,(String)"",(short)34,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMedicoApellido_Internalname,StringUtil.RTrim( A14MedicoApellido),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A14MedicoApellido, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtMedicoApellido_Jsonclick,(String)"",(short)34,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMedicoNombre_Internalname,StringUtil.RTrim( A13MedicoNombre),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A13MedicoNombre, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtMedicoNombre_Jsonclick,(String)"",(short)34,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMotivoConsulta_Internalname,(String)A68MotivoConsulta,(String)"",(short)0,(String)"px",(short)17,(String)"",(int)2097152,(short)-1,(short)0,(short)0,(short)0,(short)2,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,(String)A68MotivoConsulta,(String)"",(short)0,(String)edtMotivoConsulta_Jsonclick,(String)"",(short)34,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtAnotacionesConsulta_Internalname,(String)A69AnotacionesConsulta,(String)"",(short)0,(String)"px",(short)17,(String)"",(int)2097152,(short)-1,(short)0,(short)0,(short)0,(short)1,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,(String)A69AnotacionesConsulta,(String)"",(short)0,(String)edtAnotacionesConsulta_Jsonclick,(String)"",(short)34,(short)1,(short)1,(bool)true,(String)"left"});
            GridContainer.AddRow(GridRow);
            nGXsfl_34_idx = (short)(((subGrid_Islastpage==1)&&(nGXsfl_34_idx+1>subGrid_Recordsperpage( )) ? 1 : nGXsfl_34_idx+1)) ;
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_34_idx), 4, 0)), 4, "0") ;
            edtavUpdate_Internalname = "_UPDATE_"+sGXsfl_34_idx ;
            edtavDisplay_Internalname = "_DISPLAY_"+sGXsfl_34_idx ;
            edtConsultaFecha_Internalname = "CONSULTAFECHA_"+sGXsfl_34_idx ;
            edtTurnoId_Internalname = "TURNOID_"+sGXsfl_34_idx ;
            edtTurnoNombre_Internalname = "TURNONOMBRE_"+sGXsfl_34_idx ;
            edtConsultaNro_Internalname = "CONSULTANRO_"+sGXsfl_34_idx ;
            edtPacienteId_Internalname = "PACIENTEID_"+sGXsfl_34_idx ;
            edtPacienteApellido_Internalname = "PACIENTEAPELLIDO_"+sGXsfl_34_idx ;
            edtPacienteNombre_Internalname = "PACIENTENOMBRE_"+sGXsfl_34_idx ;
            edtPacienteCI_Internalname = "PACIENTECI_"+sGXsfl_34_idx ;
            edtMedicoId_Internalname = "MEDICOID_"+sGXsfl_34_idx ;
            edtMedicoApellido_Internalname = "MEDICOAPELLIDO_"+sGXsfl_34_idx ;
            edtMedicoNombre_Internalname = "MEDICONOMBRE_"+sGXsfl_34_idx ;
            edtMotivoConsulta_Internalname = "MOTIVOCONSULTA_"+sGXsfl_34_idx ;
            edtAnotacionesConsulta_Internalname = "ANOTACIONESCONSULTA_"+sGXsfl_34_idx ;
         }
         /* End function sendrow_342 */
      }

      public override void initialize_properties( )
      {
         lblTitletext_Internalname = "TITLETEXT" ;
         lblFiltertextconsultafecha_Internalname = "FILTERTEXTCONSULTAFECHA" ;
         edtavConsultafecha_Internalname = "_CONSULTAFECHA" ;
         lblFiltertextmedicoid_Internalname = "FILTERTEXTMEDICOID" ;
         edtavMedicoid_Internalname = "_MEDICOID" ;
         lblFiltertextturnoid_Internalname = "FILTERTEXTTURNOID" ;
         dynavTurnoid_Internalname = "_TURNOID" ;
         lblFiltertextconsultanro_Internalname = "FILTERTEXTCONSULTANRO" ;
         edtavConsultanro_Internalname = "_CONSULTANRO" ;
         lblTableseparator_Internalname = "TABLESEPARATOR" ;
         tblTablesearch_Internalname = "TABLESEARCH" ;
         tblTable_Internalname = "TABLE" ;
         Form.Internalname = "FORM" ;
         subGrid_Internalname = "GRID" ;
         edtAnotacionesConsulta_Jsonclick = "" ;
         edtMotivoConsulta_Jsonclick = "" ;
         edtMedicoNombre_Jsonclick = "" ;
         edtMedicoApellido_Jsonclick = "" ;
         edtMedicoId_Jsonclick = "" ;
         edtPacienteCI_Jsonclick = "" ;
         edtPacienteNombre_Jsonclick = "" ;
         edtPacienteApellido_Jsonclick = "" ;
         edtPacienteId_Jsonclick = "" ;
         edtConsultaNro_Jsonclick = "" ;
         edtTurnoNombre_Jsonclick = "" ;
         edtTurnoId_Jsonclick = "" ;
         edtConsultaFecha_Jsonclick = "" ;
         edtavConsultanro_Jsonclick = "" ;
         dynavTurnoid_Jsonclick = "" ;
         edtavMedicoid_Jsonclick = "" ;
         edtavConsultafecha_Jsonclick = "" ;
         subGrid_Class = "WorkWith" ;
         subGrid_Backcolorstyle = 3 ;
         edtConsultaNro_Link = "" ;
         edtavDisplay_Link = "" ;
         edtavUpdate_Link = "" ;
         subGrid_Rows = 0 ;
         Form.Headerrawhtml = "" ;
         Form.Background = "" ;
         Form.Backcolor = (int)(0xFFFFFF) ;
         Form.Caption = "Work With Historia Clinica" ;
         edtavUpdate_Tooltiptext = "Modifica" ;
         edtavDisplay_Tooltiptext = "Visualizar" ;
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
         edtavDisplay_Internalname = "" ;
         AV18Display = "" ;
         edtavUpdate_Internalname = "" ;
         AV17Update = "" ;
         Gx_date = DateTime.MinValue ;
         AV21Pgmname = "" ;
         AV13ConsultaFecha = DateTime.MinValue ;
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
         edtTurnoId_Internalname = "" ;
         edtTurnoNombre_Internalname = "" ;
         edtConsultaNro_Internalname = "" ;
         edtPacienteId_Internalname = "" ;
         edtPacienteApellido_Internalname = "" ;
         edtPacienteNombre_Internalname = "" ;
         edtPacienteCI_Internalname = "" ;
         edtMedicoId_Internalname = "" ;
         edtMedicoApellido_Internalname = "" ;
         edtMedicoNombre_Internalname = "" ;
         edtMotivoConsulta_Internalname = "" ;
         edtAnotacionesConsulta_Internalname = "" ;
         A43ConsultaFecha = DateTime.MinValue ;
         A61TurnoNombre = "" ;
         A36PacienteApellido = "" ;
         A35PacienteNombre = "" ;
         A41PacienteCI = "" ;
         A14MedicoApellido = "" ;
         A13MedicoNombre = "" ;
         A68MotivoConsulta = "" ;
         A69AnotacionesConsulta = "" ;
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "" ;
         scmdbuf = "" ;
         H00112_A60TurnoId = new short[1] ;
         H00112_A61TurnoNombre = new String[] {""} ;
         GridContainer = new GXWebGrid( context);
         H00113_A69AnotacionesConsulta = new String[] {""} ;
         H00113_n69AnotacionesConsulta = new bool[] {false} ;
         H00113_A68MotivoConsulta = new String[] {""} ;
         H00113_n68MotivoConsulta = new bool[] {false} ;
         H00113_A13MedicoNombre = new String[] {""} ;
         H00113_A14MedicoApellido = new String[] {""} ;
         H00113_A12MedicoId = new int[1] ;
         H00113_A41PacienteCI = new String[] {""} ;
         H00113_A35PacienteNombre = new String[] {""} ;
         H00113_A36PacienteApellido = new String[] {""} ;
         H00113_A34PacienteId = new int[1] ;
         H00113_A63ConsultaNro = new short[1] ;
         H00113_n63ConsultaNro = new bool[] {false} ;
         H00113_A61TurnoNombre = new String[] {""} ;
         H00113_A60TurnoId = new short[1] ;
         H00113_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         H00114_AGRID_nRecordCount = new int[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV9GridState = new SdtGridState(context);
         AV7Session = new GxWebSession( context);
         AV10GridStateFilterValue = new SdtGridState_FilterValue(context);
         AV11TrnContext = new SdtTransactionContext(context);
         sStyleString = "" ;
         ClassString = "" ;
         StyleString = "" ;
         lblTitletext_Jsonclick = "" ;
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
         lblFiltertextconsultafecha_Jsonclick = "" ;
         TempTags = "" ;
         GXt_char15 = "" ;
         lblFiltertextmedicoid_Jsonclick = "" ;
         lblFiltertextturnoid_Jsonclick = "" ;
         lblFiltertextconsultanro_Jsonclick = "" ;
         lblTableseparator_Jsonclick = "" ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         GridRow = new GXWebRow();
         ROClassString = "" ;
         GXt_char16 = "" ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwhistoriaclinica__default(),
            new Object[][] {
                new Object[] {
               H00112_A60TurnoId, H00112_A61TurnoNombre
               }
               , new Object[] {
               H00113_A69AnotacionesConsulta, H00113_n69AnotacionesConsulta, H00113_A68MotivoConsulta, H00113_n68MotivoConsulta, H00113_A13MedicoNombre, H00113_A14MedicoApellido, H00113_A12MedicoId, H00113_A41PacienteCI, H00113_A35PacienteNombre, H00113_A36PacienteApellido,
               H00113_A34PacienteId, H00113_A63ConsultaNro, H00113_n63ConsultaNro, H00113_A61TurnoNombre, H00113_A60TurnoId, H00113_A43ConsultaFecha
               }
               , new Object[] {
               H00114_AGRID_nRecordCount
               }
            }
         );
         Gx_date = DateTimeUtil.Today( ) ;
         AV21Pgmname = "WWHistoriaClinica" ;
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( ) ;
         AV21Pgmname = "WWHistoriaClinica" ;
         context.Gx_err = 0 ;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nRC_Grid ;
      private short nGXsfl_34_idx=1 ;
      private short AV15TurnoId ;
      private short AV16ConsultaNro ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short GRID_nEOF ;
      private short subGrid_Rows ;
      private short wbEnd ;
      private short wbStart ;
      private short A60TurnoId ;
      private short A63ConsultaNro ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Collapsed ;
      private short subGrid_Backstyle ;
      private int Grid_PageSize34 ;
      private int AV14MedicoId ;
      private int GRID_nFirstRecordOnPage ;
      private int A34PacienteId ;
      private int A12MedicoId ;
      private int gxdynajaxindex ;
      private int subGrid_Islastpage ;
      private int GRID_nCurrentRecord ;
      private int GRID_nRecordCount ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_34_idx="0001" ;
      private String edtavDisplay_Tooltiptext ;
      private String edtavDisplay_Internalname ;
      private String edtavUpdate_Tooltiptext ;
      private String edtavUpdate_Internalname ;
      private String AV21Pgmname ;
      private String sDynURL ;
      private String FormProcess ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtConsultaFecha_Internalname ;
      private String edtTurnoId_Internalname ;
      private String edtTurnoNombre_Internalname ;
      private String edtConsultaNro_Internalname ;
      private String edtPacienteId_Internalname ;
      private String edtPacienteApellido_Internalname ;
      private String edtPacienteNombre_Internalname ;
      private String edtPacienteCI_Internalname ;
      private String edtMedicoId_Internalname ;
      private String edtMedicoApellido_Internalname ;
      private String edtMedicoNombre_Internalname ;
      private String edtMotivoConsulta_Internalname ;
      private String edtAnotacionesConsulta_Internalname ;
      private String A61TurnoNombre ;
      private String A36PacienteApellido ;
      private String A35PacienteNombre ;
      private String A41PacienteCI ;
      private String A14MedicoApellido ;
      private String A13MedicoNombre ;
      private String edtavConsultafecha_Internalname ;
      private String gxwrpcisep ;
      private String scmdbuf ;
      private String edtavMedicoid_Internalname ;
      private String dynavTurnoid_Internalname ;
      private String edtavConsultanro_Internalname ;
      private String edtavUpdate_Link ;
      private String edtavDisplay_Link ;
      private String edtConsultaNro_Link ;
      private String sStyleString ;
      private String tblTable_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String lblTitletext_Internalname ;
      private String lblTitletext_Jsonclick ;
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
      private String tblTablesearch_Internalname ;
      private String lblFiltertextconsultafecha_Internalname ;
      private String lblFiltertextconsultafecha_Jsonclick ;
      private String TempTags ;
      private String GXt_char15 ;
      private String edtavConsultafecha_Jsonclick ;
      private String lblFiltertextmedicoid_Internalname ;
      private String lblFiltertextmedicoid_Jsonclick ;
      private String edtavMedicoid_Jsonclick ;
      private String lblFiltertextturnoid_Internalname ;
      private String lblFiltertextturnoid_Jsonclick ;
      private String dynavTurnoid_Jsonclick ;
      private String lblFiltertextconsultanro_Internalname ;
      private String lblFiltertextconsultanro_Jsonclick ;
      private String edtavConsultanro_Jsonclick ;
      private String lblTableseparator_Internalname ;
      private String lblTableseparator_Jsonclick ;
      private String ROClassString ;
      private String edtConsultaFecha_Jsonclick ;
      private String edtTurnoId_Jsonclick ;
      private String edtTurnoNombre_Jsonclick ;
      private String edtConsultaNro_Jsonclick ;
      private String edtPacienteId_Jsonclick ;
      private String edtPacienteApellido_Jsonclick ;
      private String edtPacienteNombre_Jsonclick ;
      private String edtPacienteCI_Jsonclick ;
      private String edtMedicoId_Jsonclick ;
      private String edtMedicoApellido_Jsonclick ;
      private String edtMedicoNombre_Jsonclick ;
      private String edtMotivoConsulta_Jsonclick ;
      private String edtAnotacionesConsulta_Jsonclick ;
      private String GXt_char16 ;
      private DateTime Gx_date ;
      private DateTime AV13ConsultaFecha ;
      private DateTime A43ConsultaFecha ;
      private bool entryPointCalled ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n63ConsultaNro ;
      private bool n68MotivoConsulta ;
      private bool n69AnotacionesConsulta ;
      private bool returnInSub ;
      private bool AV5IsAuthorized ;
      private String A68MotivoConsulta ;
      private String A69AnotacionesConsulta ;
      private String AV18Display ;
      private String AV17Update ;
      private GxWebSession AV7Session ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXMasterPage MasterPageObj ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavTurnoid ;
      private IDataStoreProvider pr_default ;
      private short[] H00112_A60TurnoId ;
      private String[] H00112_A61TurnoNombre ;
      private String[] H00113_A69AnotacionesConsulta ;
      private bool[] H00113_n69AnotacionesConsulta ;
      private String[] H00113_A68MotivoConsulta ;
      private bool[] H00113_n68MotivoConsulta ;
      private String[] H00113_A13MedicoNombre ;
      private String[] H00113_A14MedicoApellido ;
      private int[] H00113_A12MedicoId ;
      private String[] H00113_A41PacienteCI ;
      private String[] H00113_A35PacienteNombre ;
      private String[] H00113_A36PacienteApellido ;
      private int[] H00113_A34PacienteId ;
      private short[] H00113_A63ConsultaNro ;
      private bool[] H00113_n63ConsultaNro ;
      private String[] H00113_A61TurnoNombre ;
      private short[] H00113_A60TurnoId ;
      private DateTime[] H00113_A43ConsultaFecha ;
      private int[] H00114_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private SdtGridState AV9GridState ;
      private SdtGridState_FilterValue AV10GridStateFilterValue ;
      private SdtTransactionContext AV11TrnContext ;
   }

   public class wwhistoriaclinica__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00113( short AV16ConsultaNro ,
                                             DateTime AV13ConsultaFecha ,
                                             int AV14MedicoId ,
                                             short AV15TurnoId ,
                                             short A63ConsultaNro ,
                                             DateTime A43ConsultaFecha ,
                                             int A12MedicoId ,
                                             short A60TurnoId )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int17 ;
         GXv_int17 = new short [4] ;
         Object[] GXv_Object18 ;
         GXv_Object18 = new Object [2] ;
         scmdbuf = "SELECT T1.[AnotacionesConsulta], T1.[MotivoConsulta], T2.[MedicoNombre], T2.[MedicoApellido], T1.[MedicoId], T3.[PacienteCI], T3.[PacienteNombre], T3.[PacienteApellido], T1.[PacienteId], T1.[ConsultaNro], T4.[TurnoNombre], T1.[TurnoId], T1.[ConsultaFecha] FROM ((([ConsultaPaciente] T1 WITH (NOLOCK) INNER JOIN [Medico] T2 WITH (NOLOCK) ON T2.[MedicoId] = T1.[MedicoId]) INNER JOIN [Paciente] T3 WITH (NOLOCK) ON T3.[PacienteId] = T1.[PacienteId]) INNER JOIN [Turno] T4 WITH (NOLOCK) ON T4.[TurnoId] = T1.[TurnoId])" ;
         if ( ! (0==AV16ConsultaNro) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (T1.[ConsultaNro] = @AV16ConsultaNro)" ;
            }
            else
            {
               sWhereString = sWhereString + " (T1.[ConsultaNro] = @AV16ConsultaNro)" ;
            }
         }
         else
         {
            GXv_int17[0] = 1 ;
         }
         if ( ! (DateTime.MinValue==AV13ConsultaFecha) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (T1.[ConsultaFecha] = @AV13ConsultaFecha)" ;
            }
            else
            {
               sWhereString = sWhereString + " (T1.[ConsultaFecha] = @AV13ConsultaFecha)" ;
            }
         }
         else
         {
            GXv_int17[1] = 1 ;
         }
         if ( ! (0==AV14MedicoId) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (T1.[MedicoId] = @AV14MedicoId)" ;
            }
            else
            {
               sWhereString = sWhereString + " (T1.[MedicoId] = @AV14MedicoId)" ;
            }
         }
         else
         {
            GXv_int17[2] = 1 ;
         }
         if ( ! (0==AV15TurnoId) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (T1.[TurnoId] = @AV15TurnoId)" ;
            }
            else
            {
               sWhereString = sWhereString + " (T1.[TurnoId] = @AV15TurnoId)" ;
            }
         }
         else
         {
            GXv_int17[3] = 1 ;
         }
         if ( StringUtil.StrCmp("", sWhereString) != 0 )
         {
            scmdbuf = scmdbuf + " WHERE " + sWhereString ;
         }
         scmdbuf = scmdbuf + " ORDER BY T1.[ConsultaFecha], T1.[MedicoId], T1.[TurnoId], T1.[ConsultaNro]" ;
         GXv_Object18[0] = scmdbuf ;
         GXv_Object18[1] = (Object)(GXv_int17) ;
         return GXv_Object18 ;
      }

      protected Object[] conditional_H00114( short AV16ConsultaNro ,
                                             DateTime AV13ConsultaFecha ,
                                             int AV14MedicoId ,
                                             short AV15TurnoId ,
                                             short A63ConsultaNro ,
                                             DateTime A43ConsultaFecha ,
                                             int A12MedicoId ,
                                             short A60TurnoId )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int19 ;
         GXv_int19 = new short [4] ;
         Object[] GXv_Object20 ;
         GXv_Object20 = new Object [2] ;
         scmdbuf = "SELECT COUNT(*) FROM ((([ConsultaPaciente] T1 WITH (NOLOCK) INNER JOIN [Medico] T3 WITH (NOLOCK) ON T3.[MedicoId] = T1.[MedicoId]) INNER JOIN [Paciente] T2 WITH (NOLOCK) ON T2.[PacienteId] = T1.[PacienteId]) INNER JOIN [Turno] T4 WITH (NOLOCK) ON T4.[TurnoId] = T1.[TurnoId])" ;
         if ( ! (0==AV16ConsultaNro) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (T1.[ConsultaNro] = @AV16ConsultaNro)" ;
            }
            else
            {
               sWhereString = sWhereString + " (T1.[ConsultaNro] = @AV16ConsultaNro)" ;
            }
         }
         else
         {
            GXv_int19[0] = 1 ;
         }
         if ( ! (DateTime.MinValue==AV13ConsultaFecha) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (T1.[ConsultaFecha] = @AV13ConsultaFecha)" ;
            }
            else
            {
               sWhereString = sWhereString + " (T1.[ConsultaFecha] = @AV13ConsultaFecha)" ;
            }
         }
         else
         {
            GXv_int19[1] = 1 ;
         }
         if ( ! (0==AV14MedicoId) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (T1.[MedicoId] = @AV14MedicoId)" ;
            }
            else
            {
               sWhereString = sWhereString + " (T1.[MedicoId] = @AV14MedicoId)" ;
            }
         }
         else
         {
            GXv_int19[2] = 1 ;
         }
         if ( ! (0==AV15TurnoId) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (T1.[TurnoId] = @AV15TurnoId)" ;
            }
            else
            {
               sWhereString = sWhereString + " (T1.[TurnoId] = @AV15TurnoId)" ;
            }
         }
         else
         {
            GXv_int19[3] = 1 ;
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
               case 1 :
                     return conditional_H00113( (short)dynConstraints[0] , (DateTime)dynConstraints[1] , (int)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (DateTime)dynConstraints[5] , (int)dynConstraints[6] , (short)dynConstraints[7] );
               case 2 :
                     return conditional_H00114( (short)dynConstraints[0] , (DateTime)dynConstraints[1] , (int)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (DateTime)dynConstraints[5] , (int)dynConstraints[6] , (short)dynConstraints[7] );
         }
         return base.getDynamicStatement(cursor, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00112 ;
          prmH00112 = new Object[] {
          } ;
          Object[] prmH00113 ;
          prmH00113 = new Object[] {
          new Object[] {"@AV16ConsultaNro",SqlDbType.SmallInt,2,0} ,
          new Object[] {"@AV13ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV14MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@AV15TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmH00114 ;
          prmH00114 = new Object[] {
          new Object[] {"@AV16ConsultaNro",SqlDbType.SmallInt,2,0} ,
          new Object[] {"@AV13ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV14MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@AV15TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H00112", "SELECT [TurnoId], [TurnoNombre] FROM [Turno] WITH (NOLOCK) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00112,0,0,true,false )
             ,new CursorDef("H00113", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00113,11,0,true,false )
             ,new CursorDef("H00114", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00114,1,0,true,false )
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
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                break;
             case 1 :
                ((String[]) buf[0])[0] = rslt.getLongVarchar(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((String[]) buf[2])[0] = rslt.getLongVarchar(2) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((String[]) buf[4])[0] = rslt.getString(3, 20) ;
                ((String[]) buf[5])[0] = rslt.getString(4, 20) ;
                ((int[]) buf[6])[0] = rslt.getInt(5) ;
                ((String[]) buf[7])[0] = rslt.getString(6, 8) ;
                ((String[]) buf[8])[0] = rslt.getString(7, 20) ;
                ((String[]) buf[9])[0] = rslt.getString(8, 20) ;
                ((int[]) buf[10])[0] = rslt.getInt(9) ;
                ((short[]) buf[11])[0] = rslt.getShort(10) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((String[]) buf[13])[0] = rslt.getString(11, 20) ;
                ((short[]) buf[14])[0] = rslt.getShort(12) ;
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(13) ;
                break;
             case 2 :
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
             case 1 :
                sIdx = 0 ;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1) ;
                   stmt.SetParameter(sIdx, (short)parms[4]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1) ;
                   stmt.SetParameter(sIdx, (DateTime)parms[5]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1) ;
                   stmt.SetParameter(sIdx, (int)parms[6]);
                }
                if ( (short)parms[3] == 0 )
                {
                   sIdx = (short)(sIdx+1) ;
                   stmt.SetParameter(sIdx, (short)parms[7]);
                }
                break;
             case 2 :
                sIdx = 0 ;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1) ;
                   stmt.SetParameter(sIdx, (short)parms[4]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1) ;
                   stmt.SetParameter(sIdx, (DateTime)parms[5]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1) ;
                   stmt.SetParameter(sIdx, (int)parms[6]);
                }
                if ( (short)parms[3] == 0 )
                {
                   sIdx = (short)(sIdx+1) ;
                   stmt.SetParameter(sIdx, (short)parms[7]);
                }
                break;
       }
    }

 }

}
