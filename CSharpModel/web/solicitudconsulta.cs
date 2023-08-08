/*
               File: SolicitudConsulta
        Description: Solicitud Consulta
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/24/2010 5:35:24.9
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
   public class solicitudconsulta : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public solicitudconsulta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public solicitudconsulta( IGxContext context )
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
         dynavTurnoidx = new GXCombobox();
         dynTurnoId = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"_TURNOIDX") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1 ;
                  return  ;
               }
               GXDLV_TURNOIDX0M2( ) ;
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
               GXDLATURNOID0M3( ) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridpacientes") == 0 )
            {
               nRC_Gridpacientes = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
               nGXsfl_18_idx = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
               sGXsfl_18_idx = GetNextPar( ) ;
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1 ;
                  return  ;
               }
               gxnrGridpacientes_newrow( nRC_Gridpacientes, nGXsfl_18_idx, sGXsfl_18_idx) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridpacientes") == 0 )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0 ;
               dynavTurnoidx.Name = "_TURNOIDX" ;
               dynavTurnoidx.WebTags = "" ;
               GXCCtl = "TURNOID_" + sGXsfl_45_idx ;
               dynTurnoId.Name = GXCCtl ;
               dynTurnoId.WebTags = "" ;
               AV11PacienteIdX = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV11PacienteIdX", StringUtil.LTrim( StringUtil.Str( (decimal)(AV11PacienteIdX), 6, 0)));
               AV10PacienteCIX = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV10PacienteCIX", AV10PacienteCIX);
               AV8MedicoX = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV8MedicoX", AV8MedicoX);
               AV6EspecialidadX = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV6EspecialidadX", AV6EspecialidadX);
               AV7FechaConsultaX = context.localUtil.ParseDateParm( GetNextPar( )) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7FechaConsultaX", context.localUtil.Format(AV7FechaConsultaX, "99/99/99"));
               AV12TurnoIdX = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV12TurnoIdX", StringUtil.LTrim( StringUtil.Str( (decimal)(AV12TurnoIdX), 2, 0)));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1 ;
                  return  ;
               }
               gxgrGridpacientes_refresh( AV11PacienteIdX, AV10PacienteCIX, AV8MedicoX, AV6EspecialidadX, AV7FechaConsultaX, AV12TurnoIdX) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridmedicos") == 0 )
            {
               nRC_Gridmedicos = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
               nGXsfl_45_idx = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
               sGXsfl_45_idx = GetNextPar( ) ;
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1 ;
                  return  ;
               }
               gxnrGridmedicos_newrow( nRC_Gridmedicos, nGXsfl_45_idx, sGXsfl_45_idx) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridmedicos") == 0 )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0 ;
               dynavTurnoidx.Name = "_TURNOIDX" ;
               dynavTurnoidx.WebTags = "" ;
               GXCCtl = "TURNOID_" + sGXsfl_45_idx ;
               dynTurnoId.Name = GXCCtl ;
               dynTurnoId.WebTags = "" ;
               AV11PacienteIdX = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV11PacienteIdX", StringUtil.LTrim( StringUtil.Str( (decimal)(AV11PacienteIdX), 6, 0)));
               AV10PacienteCIX = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV10PacienteCIX", AV10PacienteCIX);
               AV8MedicoX = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV8MedicoX", AV8MedicoX);
               AV6EspecialidadX = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV6EspecialidadX", AV6EspecialidadX);
               AV7FechaConsultaX = context.localUtil.ParseDateParm( GetNextPar( )) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7FechaConsultaX", context.localUtil.Format(AV7FechaConsultaX, "99/99/99"));
               AV12TurnoIdX = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV12TurnoIdX", StringUtil.LTrim( StringUtil.Str( (decimal)(AV12TurnoIdX), 2, 0)));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1 ;
                  return  ;
               }
               gxgrGridmedicos_refresh( AV11PacienteIdX, AV10PacienteCIX, AV8MedicoX, AV6EspecialidadX, AV7FechaConsultaX, AV12TurnoIdX) ;
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
         PA0M2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0)) ;
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0M2( ) ;
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
         FormProcess = " onkeyup=\"gx.evt.onkeyup(event)\" onkeypress=\"gx.evt.onkeypress(event,true,false)\" onkeydown=\"gx.evt.onkeypress(null,true,false)\"" ;
         context.WriteHtmlText( "<body") ;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            context.WriteHtmlText( " background=\""+context.convertURL( Form.Background)+"\"") ;
         }
         context.WriteHtmlText( " "+"class=\"Form\""+" "+" style=\"-moz-opacity:0;opacity:0;"+"\""+" bgcolor=\""+context.BuildHTMLColor( Form.Backcolor)+"\""+FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" onsubmit=\"try{return gx.csv.validForm()}catch(e){return true;}\" name=\"MAINFORM\" method=\"post\" action=\""+formatLink("solicitudconsulta.aspx") +"\" class=\""+"Form"+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
      }

      public override void RenderHtmlCloseForm( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH__PACIENTEIDX", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11PacienteIdX), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH__PACIENTECIX", StringUtil.RTrim( AV10PacienteCIX));
         GxWebStd.gx_hidden_field( context, "GXH__MEDICOX", StringUtil.RTrim( AV8MedicoX));
         GxWebStd.gx_hidden_field( context, "GXH__ESPECIALIDADX", StringUtil.RTrim( AV6EspecialidadX));
         GxWebStd.gx_hidden_field( context, "GXH__FECHACONSULTAX", context.localUtil.Format(AV7FechaConsultaX, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH__TURNOIDX", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12TurnoIdX), 2, 0, ",", "")));
         /* Send saved values. */
         GxWebStd.gx_hidden_field( context, "nRC_Gridpacientes", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_Gridpacientes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "nRC_Gridmedicos", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_Gridmedicos), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendComponentObjects();
         SendServerCommands();
         SendState();
         context.WriteHtmlTextNl( "</form>") ;
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0)) ;
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            WE0M2( ) ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0M2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override String GetPgmname( )
      {
         return "SolicitudConsulta" ;
      }

      public override String GetPgmdesc( )
      {
         return "Solicitud Consulta" ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("solicitudconsulta.aspx")  ;
      }

      protected void WB0M0( )
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
            wb_table1_2_0M2( true) ;
         }
         else
         {
            wb_table1_2_0M2( false) ;
         }
         return  ;
      }

      protected void wb_table1_2_0M2e( bool wbgen )
      {
         if ( wbgen )
         {
         }
         wbLoad = true ;
      }

      protected void START0M2( )
      {
         wbLoad = false ;
         wbEnd = 0 ;
         wbStart = 0 ;
         Form.Meta.addItem("Generator", "GeneXus C#", 0) ;
         Form.Meta.addItem("Version", "10_1_3-34981", 0) ;
         Form.Meta.addItem("Description", "Solicitud Consulta", 0) ;
         context.wjLoc = "" ;
         context.nUserReturn = 0 ;
         context.wbHandled = 0 ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false ;
         STRUP0M0( ) ;
      }

      protected void WS0M2( )
      {
         START0M2( ) ;
         EVT0M2( ) ;
      }

      protected void EVT0M2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1 ;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false ;
                                 /* Set Refresh If Pacienteidx Changed */
                                 if ( ( context.localUtil.CToN( cgiGet( "GXH__PACIENTEIDX"), ",", ".") != Convert.ToDecimal( AV11PacienteIdX )) )
                                 {
                                    Rfr0gs = true ;
                                 }
                                 /* Set Refresh If Pacientecix Changed */
                                 if ( StringUtil.StrCmp(cgiGet( "GXH__PACIENTECIX"), AV10PacienteCIX) != 0 )
                                 {
                                    Rfr0gs = true ;
                                 }
                                 /* Set Refresh If Medicox Changed */
                                 if ( StringUtil.StrCmp(cgiGet( "GXH__MEDICOX"), AV8MedicoX) != 0 )
                                 {
                                    Rfr0gs = true ;
                                 }
                                 /* Set Refresh If Especialidadx Changed */
                                 if ( StringUtil.StrCmp(cgiGet( "GXH__ESPECIALIDADX"), AV6EspecialidadX) != 0 )
                                 {
                                    Rfr0gs = true ;
                                 }
                                 /* Set Refresh If Fechaconsultax Changed */
                                 if ( context.localUtil.CToD( cgiGet( "GXH__FECHACONSULTAX"), 2) != AV7FechaConsultaX )
                                 {
                                    Rfr0gs = true ;
                                 }
                                 /* Set Refresh If Turnoidx Changed */
                                 if ( ( context.localUtil.CToN( cgiGet( "GXH__TURNOIDX"), ",", ".") != Convert.ToDecimal( AV12TurnoIdX )) )
                                 {
                                    Rfr0gs = true ;
                                 }
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: E110M2 */
                                    E110M2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1 ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4) ;
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4)) ;
                           if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "GRIDMEDICOS.LOAD") == 0 )
                           {
                              nGXsfl_45_idx = (short)(NumberUtil.Val( sEvtType, ".")) ;
                              sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_45_idx), 4, 0)), 4, "0") ;
                              edtMedicoId_Internalname = "MEDICOID_"+sGXsfl_45_idx ;
                              edtMedicoApellido_Internalname = "MEDICOAPELLIDO_"+sGXsfl_45_idx ;
                              edtMedicoNombre_Internalname = "MEDICONOMBRE_"+sGXsfl_45_idx ;
                              edtEspecialidadId_Internalname = "ESPECIALIDADID_"+sGXsfl_45_idx ;
                              edtEspecialidadDescripcion_Internalname = "ESPECIALIDADDESCRIPCION_"+sGXsfl_45_idx ;
                              edtConsultaFecha_Internalname = "CONSULTAFECHA_"+sGXsfl_45_idx ;
                              dynTurnoId_Internalname = "TURNOID_"+sGXsfl_45_idx ;
                              edtTurnoNombre_Internalname = "TURNONOMBRE_"+sGXsfl_45_idx ;
                              edtNrosDisponibles_Internalname = "NROSDISPONIBLES_"+sGXsfl_45_idx ;
                              edtCantNrosAsig_Internalname = "CANTNROSASIG_"+sGXsfl_45_idx ;
                              A12MedicoId = (int)(context.localUtil.CToN( cgiGet( edtMedicoId_Internalname), ",", ".")) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
                              A14MedicoApellido = cgiGet( edtMedicoApellido_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
                              A13MedicoNombre = cgiGet( edtMedicoNombre_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
                              A9EspecialidadId = (int)(context.localUtil.CToN( cgiGet( edtEspecialidadId_Internalname), ",", ".")) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
                              A10EspecialidadDescripcion = cgiGet( edtEspecialidadDescripcion_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10EspecialidadDescripcion", A10EspecialidadDescripcion);
                              A43ConsultaFecha = context.localUtil.CToD( cgiGet( edtConsultaFecha_Internalname), 2) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
                              dynTurnoId.Name = dynTurnoId_Internalname ;
                              dynTurnoId.CurrentValue = cgiGet( dynTurnoId_Internalname) ;
                              A60TurnoId = (short)(NumberUtil.Val( cgiGet( dynTurnoId_Internalname), ".")) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
                              A61TurnoNombre = cgiGet( edtTurnoNombre_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
                              A65NrosDisponibles = (short)(context.localUtil.CToN( cgiGet( edtNrosDisponibles_Internalname), ",", ".")) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A65NrosDisponibles", StringUtil.LTrim( StringUtil.Str( (decimal)(A65NrosDisponibles), 2, 0)));
                              A66CantNrosAsig = (short)(context.localUtil.CToN( cgiGet( edtCantNrosAsig_Internalname), ",", ".")) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
                              sEvtType = StringUtil.Right( sEvt, 1) ;
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1)) ;
                                 if ( StringUtil.StrCmp(sEvt, "GRIDMEDICOS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    dynload_actions( ) ;
                                    /* Execute user event: E120M3 */
                                    E120M3 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "GRIDPACIENTES.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_18_idx = (short)(NumberUtil.Val( sEvtType, ".")) ;
                              sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_18_idx), 4, 0)), 4, "0") ;
                              edtPacienteId_Internalname = "PACIENTEID_"+sGXsfl_18_idx ;
                              edtPacienteCI_Internalname = "PACIENTECI_"+sGXsfl_18_idx ;
                              edtPacienteApellido_Internalname = "PACIENTEAPELLIDO_"+sGXsfl_18_idx ;
                              edtPacienteNombre_Internalname = "PACIENTENOMBRE_"+sGXsfl_18_idx ;
                              A34PacienteId = (int)(context.localUtil.CToN( cgiGet( edtPacienteId_Internalname), ",", ".")) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
                              A41PacienteCI = cgiGet( edtPacienteCI_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
                              A36PacienteApellido = cgiGet( edtPacienteApellido_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A36PacienteApellido", A36PacienteApellido);
                              A35PacienteNombre = cgiGet( edtPacienteNombre_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A35PacienteNombre", A35PacienteNombre);
                              sEvtType = StringUtil.Right( sEvt, 1) ;
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1)) ;
                                 if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false ;
                                       /* Set Refresh If Pacienteidx Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH__PACIENTEIDX"), ",", ".") != Convert.ToDecimal( AV11PacienteIdX )) )
                                       {
                                          Rfr0gs = true ;
                                       }
                                       /* Set Refresh If Pacientecix Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH__PACIENTECIX"), AV10PacienteCIX) != 0 )
                                       {
                                          Rfr0gs = true ;
                                       }
                                       /* Set Refresh If Medicox Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH__MEDICOX"), AV8MedicoX) != 0 )
                                       {
                                          Rfr0gs = true ;
                                       }
                                       /* Set Refresh If Especialidadx Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH__ESPECIALIDADX"), AV6EspecialidadX) != 0 )
                                       {
                                          Rfr0gs = true ;
                                       }
                                       /* Set Refresh If Fechaconsultax Changed */
                                       if ( context.localUtil.CToD( cgiGet( "GXH__FECHACONSULTAX"), 2) != AV7FechaConsultaX )
                                       {
                                          Rfr0gs = true ;
                                       }
                                       /* Set Refresh If Turnoidx Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH__TURNOIDX"), ",", ".") != Convert.ToDecimal( AV12TurnoIdX )) )
                                       {
                                          Rfr0gs = true ;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: E110M2 */
                                          E110M2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDPACIENTES.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    dynload_actions( ) ;
                                    /* Execute user event: E130M2 */
                                    E130M2 ();
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

      protected void WE0M2( )
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

      protected void PA0M2( )
      {
         if ( nDonePA == 0 )
         {
            dynavTurnoidx.Name = "_TURNOIDX" ;
            dynavTurnoidx.WebTags = "" ;
            GXCCtl = "TURNOID_" + sGXsfl_45_idx ;
            dynTurnoId.Name = GXCCtl ;
            dynTurnoId.WebTags = "" ;
            GX_FocusControl = edtavPacienteidx_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            nDonePA = 1 ;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLV_TURNOIDX0M2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "max-age=0");
         }
         context.GX_webresponse.AddString("(new Array( new Array(");
         GXDLV_TURNOIDX_data0M2( ) ;
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

      protected void GXV_TURNOIDX_html0M2( )
      {
         short gxdynajaxvalue ;
         GXDLV_TURNOIDX_data0M2( ) ;
         gxdynajaxindex = 1 ;
         dynavTurnoidx.removeAllItems();
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( gxdynajaxctrlcodr.Item(gxdynajaxindex), ".")) ;
            dynavTurnoidx.addItem(StringUtil.Str( (decimal)(gxdynajaxvalue), 2, 0), gxdynajaxctrldescr.Item(gxdynajaxindex), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1) ;
         }
         if ( ! context.isAjaxRequest( ) )
         {
            if ( ( dynavTurnoidx.ItemCount > 0 ) && (0==AV12TurnoIdX) )
            {
               AV12TurnoIdX = (short)(NumberUtil.Val( dynavTurnoidx.getItemValue(1), ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV12TurnoIdX", StringUtil.LTrim( StringUtil.Str( (decimal)(AV12TurnoIdX), 2, 0)));
            }
         }
      }

      protected void GXDLV_TURNOIDX_data0M2( )
      {
         /* Using cursor H000M2 */
         pr_default.execute(0);
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("Todos");
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H000M2_A60TurnoId[0]), 2, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H000M2_A61TurnoNombre[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLATURNOID0M3( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "max-age=0");
         }
         context.GX_webresponse.AddString("(new Array( new Array(");
         GXDLATURNOID_data0M3( ) ;
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

      protected void GXATURNOID_html0M3( )
      {
         short gxdynajaxvalue ;
         GXDLATURNOID_data0M3( ) ;
         gxdynajaxindex = 1 ;
         dynTurnoId.removeAllItems();
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( gxdynajaxctrlcodr.Item(gxdynajaxindex), ".")) ;
            dynTurnoId.addItem(StringUtil.Str( (decimal)(gxdynajaxvalue), 2, 0), gxdynajaxctrldescr.Item(gxdynajaxindex), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1) ;
         }
      }

      protected void GXDLATURNOID_data0M3( )
      {
         /* Using cursor H000M3 */
         pr_default.execute(1);
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("Todos");
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H000M3_A60TurnoId[0]), 2, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H000M3_A61TurnoNombre[0]));
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void gxnrGridpacientes_newrow( short nRC_Gridpacientes ,
                                               short nGXsfl_18_idx ,
                                               String sGXsfl_18_idx )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         edtPacienteId_Internalname = "PACIENTEID_"+sGXsfl_18_idx ;
         edtPacienteCI_Internalname = "PACIENTECI_"+sGXsfl_18_idx ;
         edtPacienteApellido_Internalname = "PACIENTEAPELLIDO_"+sGXsfl_18_idx ;
         edtPacienteNombre_Internalname = "PACIENTENOMBRE_"+sGXsfl_18_idx ;
         while ( nGXsfl_18_idx <= nRC_Gridpacientes )
         {
            sendrow_182( ) ;
            nGXsfl_18_idx = (short)(((subGridpacientes_Islastpage==1)&&(nGXsfl_18_idx+1>subGridpacientes_Recordsperpage( )) ? 1 : nGXsfl_18_idx+1)) ;
            sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_18_idx), 4, 0)), 4, "0") ;
            edtPacienteId_Internalname = "PACIENTEID_"+sGXsfl_18_idx ;
            edtPacienteCI_Internalname = "PACIENTECI_"+sGXsfl_18_idx ;
            edtPacienteApellido_Internalname = "PACIENTEAPELLIDO_"+sGXsfl_18_idx ;
            edtPacienteNombre_Internalname = "PACIENTENOMBRE_"+sGXsfl_18_idx ;
         }
         context.GX_webresponse.AddString(GridpacientesContainer.ToJavascriptSource());
         /* End function gxnrGridpacientes_newrow */
      }

      protected void gxnrGridmedicos_newrow( short nRC_Gridmedicos ,
                                             short nGXsfl_45_idx ,
                                             String sGXsfl_45_idx )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         edtMedicoId_Internalname = "MEDICOID_"+sGXsfl_45_idx ;
         edtMedicoApellido_Internalname = "MEDICOAPELLIDO_"+sGXsfl_45_idx ;
         edtMedicoNombre_Internalname = "MEDICONOMBRE_"+sGXsfl_45_idx ;
         edtEspecialidadId_Internalname = "ESPECIALIDADID_"+sGXsfl_45_idx ;
         edtEspecialidadDescripcion_Internalname = "ESPECIALIDADDESCRIPCION_"+sGXsfl_45_idx ;
         edtConsultaFecha_Internalname = "CONSULTAFECHA_"+sGXsfl_45_idx ;
         dynTurnoId_Internalname = "TURNOID_"+sGXsfl_45_idx ;
         edtTurnoNombre_Internalname = "TURNONOMBRE_"+sGXsfl_45_idx ;
         edtNrosDisponibles_Internalname = "NROSDISPONIBLES_"+sGXsfl_45_idx ;
         edtCantNrosAsig_Internalname = "CANTNROSASIG_"+sGXsfl_45_idx ;
         while ( nGXsfl_45_idx <= nRC_Gridmedicos )
         {
            sendrow_453( ) ;
            nGXsfl_45_idx = (short)(((subGridmedicos_Islastpage==1)&&(nGXsfl_45_idx+1>subGridmedicos_Recordsperpage( )) ? 1 : nGXsfl_45_idx+1)) ;
            sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_45_idx), 4, 0)), 4, "0") ;
            edtMedicoId_Internalname = "MEDICOID_"+sGXsfl_45_idx ;
            edtMedicoApellido_Internalname = "MEDICOAPELLIDO_"+sGXsfl_45_idx ;
            edtMedicoNombre_Internalname = "MEDICONOMBRE_"+sGXsfl_45_idx ;
            edtEspecialidadId_Internalname = "ESPECIALIDADID_"+sGXsfl_45_idx ;
            edtEspecialidadDescripcion_Internalname = "ESPECIALIDADDESCRIPCION_"+sGXsfl_45_idx ;
            edtConsultaFecha_Internalname = "CONSULTAFECHA_"+sGXsfl_45_idx ;
            dynTurnoId_Internalname = "TURNOID_"+sGXsfl_45_idx ;
            edtTurnoNombre_Internalname = "TURNONOMBRE_"+sGXsfl_45_idx ;
            edtNrosDisponibles_Internalname = "NROSDISPONIBLES_"+sGXsfl_45_idx ;
            edtCantNrosAsig_Internalname = "CANTNROSASIG_"+sGXsfl_45_idx ;
         }
         context.GX_webresponse.AddString(GridmedicosContainer.ToJavascriptSource());
         /* End function gxnrGridmedicos_newrow */
      }

      protected void gxgrGridpacientes_refresh( int AV11PacienteIdX ,
                                                String AV10PacienteCIX ,
                                                String AV8MedicoX ,
                                                String AV6EspecialidadX ,
                                                DateTime AV7FechaConsultaX ,
                                                short AV12TurnoIdX )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         disableOutput();
         RF0M2( ) ;
         enableOutput();
         context.GX_webresponse.AddString(GridpacientesContainer.ToJavascriptSource());
         /* End function gxgrGridpacientes_refresh */
      }

      protected void gxgrGridmedicos_refresh( int AV11PacienteIdX ,
                                              String AV10PacienteCIX ,
                                              String AV8MedicoX ,
                                              String AV6EspecialidadX ,
                                              DateTime AV7FechaConsultaX ,
                                              short AV12TurnoIdX )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         disableOutput();
         RF0M3( ) ;
         enableOutput();
         context.GX_webresponse.AddString(GridmedicosContainer.ToJavascriptSource());
         /* End function gxgrGridmedicos_refresh */
      }

      protected void Refresh( )
      {
         RF0M2( ) ;
         RF0M3( ) ;
         /* End function Refresh */
      }

      protected void RF0M2( )
      {
         GridpacientesContainer.PageSize = subGridpacientes_Recordsperpage( ) ;
         wbStart = 18 ;
         nGXsfl_18_idx = 1 ;
         sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_18_idx), 4, 0)), 4, "0") ;
         edtPacienteId_Internalname = "PACIENTEID_"+sGXsfl_18_idx ;
         edtPacienteCI_Internalname = "PACIENTECI_"+sGXsfl_18_idx ;
         edtPacienteApellido_Internalname = "PACIENTEAPELLIDO_"+sGXsfl_18_idx ;
         edtPacienteNombre_Internalname = "PACIENTENOMBRE_"+sGXsfl_18_idx ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
         {
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV11PacienteIdX ,
                                                 AV10PacienteCIX ,
                                                 A34PacienteId ,
                                                 A41PacienteCI },
                                                 new int[] {
                                                 TypeConstants.INT, TypeConstants.STRING, TypeConstants.INT, TypeConstants.STRING
                                                 }
            });
            lV10PacienteCIX = StringUtil.PadR( StringUtil.RTrim( AV10PacienteCIX), 8, "%") ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV10PacienteCIX", AV10PacienteCIX);
            /* Using cursor H000M4 */
            pr_default.execute(2, new Object[] {AV11PacienteIdX, lV10PacienteCIX});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A35PacienteNombre = H000M4_A35PacienteNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A35PacienteNombre", A35PacienteNombre);
               A36PacienteApellido = H000M4_A36PacienteApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A36PacienteApellido", A36PacienteApellido);
               A41PacienteCI = H000M4_A41PacienteCI[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
               A34PacienteId = H000M4_A34PacienteId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
               /* Execute user event: E130M2 */
               E130M2 ();
               pr_default.readNext(2);
            }
            pr_default.close(2);
            wbEnd = 18 ;
            WB0M0( ) ;
         }
      }

      protected int subGridpacientes_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridpacientes_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridpacientes_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridpacientes_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void RF0M3( )
      {
         GridmedicosContainer.PageSize = subGridmedicos_Recordsperpage( ) ;
         wbStart = 45 ;
         nGXsfl_45_idx = 1 ;
         sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_45_idx), 4, 0)), 4, "0") ;
         edtMedicoId_Internalname = "MEDICOID_"+sGXsfl_45_idx ;
         edtMedicoApellido_Internalname = "MEDICOAPELLIDO_"+sGXsfl_45_idx ;
         edtMedicoNombre_Internalname = "MEDICONOMBRE_"+sGXsfl_45_idx ;
         edtEspecialidadId_Internalname = "ESPECIALIDADID_"+sGXsfl_45_idx ;
         edtEspecialidadDescripcion_Internalname = "ESPECIALIDADDESCRIPCION_"+sGXsfl_45_idx ;
         edtConsultaFecha_Internalname = "CONSULTAFECHA_"+sGXsfl_45_idx ;
         dynTurnoId_Internalname = "TURNOID_"+sGXsfl_45_idx ;
         edtTurnoNombre_Internalname = "TURNONOMBRE_"+sGXsfl_45_idx ;
         edtNrosDisponibles_Internalname = "NROSDISPONIBLES_"+sGXsfl_45_idx ;
         edtCantNrosAsig_Internalname = "CANTNROSASIG_"+sGXsfl_45_idx ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
         {
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV8MedicoX ,
                                                 AV6EspecialidadX ,
                                                 AV7FechaConsultaX ,
                                                 AV12TurnoIdX ,
                                                 A14MedicoApellido ,
                                                 A10EspecialidadDescripcion ,
                                                 A43ConsultaFecha ,
                                                 A60TurnoId },
                                                 new int[] {
                                                 TypeConstants.STRING, TypeConstants.STRING, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.DATE, TypeConstants.SHORT
                                                 }
            });
            lV8MedicoX = StringUtil.PadR( StringUtil.RTrim( AV8MedicoX), 20, "%") ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV8MedicoX", AV8MedicoX);
            lV6EspecialidadX = StringUtil.PadR( StringUtil.RTrim( AV6EspecialidadX), 20, "%") ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV6EspecialidadX", AV6EspecialidadX);
            /* Using cursor H000M6 */
            pr_default.execute(3, new Object[] {lV8MedicoX, lV6EspecialidadX, AV7FechaConsultaX, AV12TurnoIdX});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A43ConsultaFecha = H000M6_A43ConsultaFecha[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
               A10EspecialidadDescripcion = H000M6_A10EspecialidadDescripcion[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10EspecialidadDescripcion", A10EspecialidadDescripcion);
               A9EspecialidadId = H000M6_A9EspecialidadId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
               A13MedicoNombre = H000M6_A13MedicoNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
               A14MedicoApellido = H000M6_A14MedicoApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
               A12MedicoId = H000M6_A12MedicoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
               A11EspecialidadMaxPacientes = H000M6_A11EspecialidadMaxPacientes[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
               A66CantNrosAsig = H000M6_A66CantNrosAsig[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
               A9EspecialidadId = H000M6_A9EspecialidadId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
               A13MedicoNombre = H000M6_A13MedicoNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
               A14MedicoApellido = H000M6_A14MedicoApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
               A10EspecialidadDescripcion = H000M6_A10EspecialidadDescripcion[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10EspecialidadDescripcion", A10EspecialidadDescripcion);
               A11EspecialidadMaxPacientes = H000M6_A11EspecialidadMaxPacientes[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
               A66CantNrosAsig = H000M6_A66CantNrosAsig[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
               A65NrosDisponibles = (short)(A11EspecialidadMaxPacientes-A66CantNrosAsig) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A65NrosDisponibles", StringUtil.LTrim( StringUtil.Str( (decimal)(A65NrosDisponibles), 2, 0)));
               /* Execute user event: E120M3 */
               E120M3 ();
               pr_default.readNext(3);
            }
            pr_default.close(3);
            wbEnd = 45 ;
            WB0M0( ) ;
         }
      }

      protected int subGridmedicos_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridmedicos_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridmedicos_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridmedicos_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void STRUP0M0( )
      {
         /* Before Start, stand alone formulas. */
         context.Gx_err = 0 ;
         GXV_TURNOIDX_html0M2( ) ;
         GXATURNOID_html0M3( ) ;
         /* Using cursor H000M7 */
         pr_default.execute(4, new Object[] {A60TurnoId});
         A61TurnoNombre = H000M7_A61TurnoNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
         pr_default.close(4);
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0 ;
         context.wbGlbDoneStart = 1 ;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPacienteidx_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPacienteidx_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum"), 1, "_PACIENTEIDX");
               GX_FocusControl = edtavPacienteidx_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true ;
               AV11PacienteIdX = 0 ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV11PacienteIdX", StringUtil.LTrim( StringUtil.Str( (decimal)(AV11PacienteIdX), 6, 0)));
            }
            else
            {
               AV11PacienteIdX = (int)(context.localUtil.CToN( cgiGet( edtavPacienteidx_Internalname), ",", ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV11PacienteIdX", StringUtil.LTrim( StringUtil.Str( (decimal)(AV11PacienteIdX), 6, 0)));
            }
            AV10PacienteCIX = cgiGet( edtavPacientecix_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV10PacienteCIX", AV10PacienteCIX);
            AV8MedicoX = cgiGet( edtavMedicox_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV8MedicoX", AV8MedicoX);
            AV6EspecialidadX = cgiGet( edtavEspecialidadx_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV6EspecialidadX", AV6EspecialidadX);
            if ( context.localUtil.VCDate( cgiGet( edtavFechaconsultax_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Consulta X"}), 1, "_FECHACONSULTAX");
               GX_FocusControl = edtavFechaconsultax_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true ;
               AV7FechaConsultaX = DateTime.MinValue ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7FechaConsultaX", context.localUtil.Format(AV7FechaConsultaX, "99/99/99"));
            }
            else
            {
               AV7FechaConsultaX = context.localUtil.CToD( cgiGet( edtavFechaconsultax_Internalname), 2) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7FechaConsultaX", context.localUtil.Format(AV7FechaConsultaX, "99/99/99"));
            }
            dynavTurnoidx.Name = dynavTurnoidx_Internalname ;
            dynavTurnoidx.CurrentValue = cgiGet( dynavTurnoidx_Internalname) ;
            AV12TurnoIdX = (short)(NumberUtil.Val( cgiGet( dynavTurnoidx_Internalname), ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV12TurnoIdX", StringUtil.LTrim( StringUtil.Str( (decimal)(AV12TurnoIdX), 2, 0)));
            /* Read saved values. */
            nRC_Gridpacientes = (short)(context.localUtil.CToN( cgiGet( "nRC_Gridpacientes"), ",", ".")) ;
            nRC_Gridmedicos = (short)(context.localUtil.CToN( cgiGet( "nRC_Gridmedicos"), ",", ".")) ;
            /* Read subfile selected row values. */
            nGXsfl_18_idx = (short)(context.localUtil.CToN( cgiGet( subGridpacientes_Internalname+"_ROW"), ",", ".")) ;
            sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_18_idx), 4, 0)), 4, "0") ;
            edtPacienteId_Internalname = "PACIENTEID_"+sGXsfl_18_idx ;
            edtPacienteCI_Internalname = "PACIENTECI_"+sGXsfl_18_idx ;
            edtPacienteApellido_Internalname = "PACIENTEAPELLIDO_"+sGXsfl_18_idx ;
            edtPacienteNombre_Internalname = "PACIENTENOMBRE_"+sGXsfl_18_idx ;
            if ( nGXsfl_18_idx > 0 )
            {
               A34PacienteId = (int)(context.localUtil.CToN( cgiGet( edtPacienteId_Internalname), ",", ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
               A41PacienteCI = cgiGet( edtPacienteCI_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
               A36PacienteApellido = cgiGet( edtPacienteApellido_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A36PacienteApellido", A36PacienteApellido);
               A35PacienteNombre = cgiGet( edtPacienteNombre_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A35PacienteNombre", A35PacienteNombre);
            }
            nGXsfl_45_idx = (short)(context.localUtil.CToN( cgiGet( subGridmedicos_Internalname+"_ROW"), ",", ".")) ;
            sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_45_idx), 4, 0)), 4, "0") ;
            edtMedicoId_Internalname = "MEDICOID_"+sGXsfl_45_idx ;
            edtMedicoApellido_Internalname = "MEDICOAPELLIDO_"+sGXsfl_45_idx ;
            edtMedicoNombre_Internalname = "MEDICONOMBRE_"+sGXsfl_45_idx ;
            edtEspecialidadId_Internalname = "ESPECIALIDADID_"+sGXsfl_45_idx ;
            edtEspecialidadDescripcion_Internalname = "ESPECIALIDADDESCRIPCION_"+sGXsfl_45_idx ;
            edtConsultaFecha_Internalname = "CONSULTAFECHA_"+sGXsfl_45_idx ;
            dynTurnoId_Internalname = "TURNOID_"+sGXsfl_45_idx ;
            edtTurnoNombre_Internalname = "TURNONOMBRE_"+sGXsfl_45_idx ;
            edtNrosDisponibles_Internalname = "NROSDISPONIBLES_"+sGXsfl_45_idx ;
            edtCantNrosAsig_Internalname = "CANTNROSASIG_"+sGXsfl_45_idx ;
            if ( nGXsfl_45_idx > 0 )
            {
               A12MedicoId = (int)(context.localUtil.CToN( cgiGet( edtMedicoId_Internalname), ",", ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
               A14MedicoApellido = cgiGet( edtMedicoApellido_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
               A13MedicoNombre = cgiGet( edtMedicoNombre_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
               A9EspecialidadId = (int)(context.localUtil.CToN( cgiGet( edtEspecialidadId_Internalname), ",", ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
               A10EspecialidadDescripcion = cgiGet( edtEspecialidadDescripcion_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10EspecialidadDescripcion", A10EspecialidadDescripcion);
               A43ConsultaFecha = context.localUtil.CToD( cgiGet( edtConsultaFecha_Internalname), 2) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
               dynTurnoId.Name = dynTurnoId_Internalname ;
               dynTurnoId.CurrentValue = cgiGet( dynTurnoId_Internalname) ;
               A60TurnoId = (short)(NumberUtil.Val( cgiGet( dynTurnoId_Internalname), ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
               A61TurnoNombre = cgiGet( edtTurnoNombre_Internalname) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
               A65NrosDisponibles = (short)(context.localUtil.CToN( cgiGet( edtNrosDisponibles_Internalname), ",", ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A65NrosDisponibles", StringUtil.LTrim( StringUtil.Str( (decimal)(A65NrosDisponibles), 2, 0)));
               A66CantNrosAsig = (short)(context.localUtil.CToN( cgiGet( edtCantNrosAsig_Internalname), ",", ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
            }
            /* Read hidden variables. */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: E110M2 */
         E110M2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E110M2( )
      {
         /* Enter Routine */
         if ( A65NrosDisponibles > 0 )
         {
            AV5ConsultaPacienteX.gxTpr_Pacienteid = A34PacienteId ;
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5ConsultaPacienteX", (Object)(AV5ConsultaPacienteX));
            AV5ConsultaPacienteX.gxTpr_Medicoid = A12MedicoId ;
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5ConsultaPacienteX", (Object)(AV5ConsultaPacienteX));
            AV5ConsultaPacienteX.gxTpr_Consultafecha = A43ConsultaFecha ;
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5ConsultaPacienteX", (Object)(AV5ConsultaPacienteX));
            AV5ConsultaPacienteX.gxTpr_Turnoid = A60TurnoId ;
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5ConsultaPacienteX", (Object)(AV5ConsultaPacienteX));
            AV5ConsultaPacienteX.Save();
            context.CommitDataStores("SolicitudConsulta");
            context.wjLoc = formatLink("aimpresiontiket.aspx") + "?" + UrlEncode(DateTimeUtil.FormatDateParm(A43ConsultaFecha)) + "," + UrlEncode("" +A34PacienteId) + "," + UrlEncode("" +A12MedicoId) + "," + UrlEncode("" +A60TurnoId) ;
         }
         else
         {
            GX_msglist.addItem("No hay números disponibles para esa consulta");
         }
      }

      private void E130M2( )
      {
         /* Gridpacientes_Load Routine */
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 18 ;
         }
         sendrow_182( ) ;
      }

      private void E120M3( )
      {
         /* Gridmedicos_Load Routine */
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 45 ;
         }
         sendrow_453( ) ;
      }

      protected void wb_table1_2_0M2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            sStyleString = sStyleString + " height: " + StringUtil.LTrim( StringUtil.Str( (decimal)(263), 10, 0)) + "px" + ";" ;
            sStyleString = sStyleString + " width: " + StringUtil.LTrim( StringUtil.Str( (decimal)(570), 10, 0)) + "px" + ";" ;
            GxWebStd.gx_table_start( context, tblTable1_Internalname, tblTable1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td style=\"height:18px;width:1px\">") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td style=\"width:23px\">") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td style=\"height:16px\">") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, 1, 1, 0, "Nro. Socio", "", "", "", 0, lblTextblock1_Jsonclick, "", StyleString, ClassString, "HLP_SolicitudConsulta.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'" + sGXsfl_18_idx + "',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtavPacienteidx_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11PacienteIdX), 6, 0, ",", "")), "", 6, "chr", 1, "row", 6, 1, 1, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(AV11PacienteIdX), "ZZZZZ9"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(9);\"", 0, edtavPacienteidx_Jsonclick, "", 0, 1, -1, true, "right", "HLP_SolicitudConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, 1, 1, 0, "C.I. Socio", "", "", "", 0, lblTextblock2_Jsonclick, "", StyleString, ClassString, "HLP_SolicitudConsulta.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'" + sGXsfl_18_idx + "',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtavPacientecix_Internalname, StringUtil.RTrim( AV10PacienteCIX), "", 8, "chr", 1, "row", 8, 1, 1, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( AV10PacienteCIX, "XXXXXXXX")), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(14);\"", 0, edtavPacientecix_Jsonclick, "", 0, 1, -1, true, "left", "HLP_SolicitudConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td colspan=\"2\" >") ;
            /*  Grid Control  */
            GridpacientesContainer.SetWrapped(nGXWrapped);
            if ( GridpacientesContainer.GetWrapped() == 1 )
            {
               sStyleString = "" ;
               GxWebStd.gx_table_start( context, subGridpacientes_Internalname, subGridpacientes_Internalname, "", "Grid", 0, "", "", 1, 2, sStyleString, "none", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGridpacientes_Backcolorstyle == 0 )
               {
                  subGridpacientes_Titlebackstyle = 0 ;
                  if ( StringUtil.Len( subGridpacientes_Class) > 0 )
                  {
                     subGridpacientes_Linesclass = subGridpacientes_Class+"Title" ;
                  }
               }
               else
               {
                  subGridpacientes_Titlebackstyle = 1 ;
                  if ( subGridpacientes_Backcolorstyle == 1 )
                  {
                     subGridpacientes_Titlebackcolor = subGridpacientes_Allbackcolor ;
                     if ( StringUtil.Len( subGridpacientes_Class) > 0 )
                     {
                        subGridpacientes_Linesclass = subGridpacientes_Class+"UniformTitle" ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGridpacientes_Class) > 0 )
                     {
                        subGridpacientes_Linesclass = subGridpacientes_Class+"Title" ;
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGridpacientes_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGridpacientes_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "CI") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGridpacientes_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Apellido") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGridpacientes_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
            }
            else
            {
               GridpacientesContainer.Clear();
               GridpacientesContainer.SetWrapped(nGXWrapped);
               GridpacientesContainer.AddObjectProperty("GridName", "Gridpacientes");
               GridpacientesContainer.AddObjectProperty("Class", "Grid");
               GridpacientesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridpacientesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridpacientesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpacientes_Backcolorstyle), 1, 0, ".", "")));
               GridpacientesContainer.AddObjectProperty("CmpContext", "");
               GridpacientesContainer.AddObjectProperty("InMasterPage", "false");
               GridpacientesColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridpacientesColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A34PacienteId), 6, 0, ".", "")));
               GridpacientesContainer.AddColumnProperties(GridpacientesColumn);
               GridpacientesColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridpacientesColumn.AddObjectProperty("Value", StringUtil.RTrim( A41PacienteCI));
               GridpacientesContainer.AddColumnProperties(GridpacientesColumn);
               GridpacientesColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridpacientesColumn.AddObjectProperty("Value", StringUtil.RTrim( A36PacienteApellido));
               GridpacientesContainer.AddColumnProperties(GridpacientesColumn);
               GridpacientesColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridpacientesColumn.AddObjectProperty("Value", StringUtil.RTrim( A35PacienteNombre));
               GridpacientesContainer.AddColumnProperties(GridpacientesColumn);
               GridpacientesContainer.AddObjectProperty("Allowselection", "true");
               GridpacientesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpacientes_Selectioncolor), 9, 0, ".", "")));
               GridpacientesContainer.AddObjectProperty("Allowhover", "true");
               GridpacientesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpacientes_Hoveringcolor), 9, 0, ".", "")));
               GridpacientesContainer.AddObjectProperty("Allowcollapsing", "false");
               GridpacientesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpacientes_Collapsed), 9, 0, ".", "")));
            }
         }
         if ( wbEnd == 18 )
         {
            wbEnd = 0 ;
            nRC_Gridpacientes = (short)(nGXsfl_18_idx-1) ;
            if ( GridpacientesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
            }
            else
            {
               sStyleString = " style=\"display:none;\"" ;
               sStyleString = "" ;
               context.WriteHtmlText( "<div id=\""+"GridpacientesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridpacientes", (Object)(GridpacientesContainer));
               GxWebStd.gx_hidden_field( context, "GridpacientesContainerData", GridpacientesContainer.ToJavascriptSource());
               if ( context.isAjaxRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridpacientesContainerData"+"V", GridpacientesContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridpacientesContainerData"+"V"+"\" value='"+GridpacientesContainer.GridValuesHidden()+"'>") ;
               }
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, 1, 1, 0, "Médico", "", "", "", 0, lblTextblock3_Jsonclick, "", StyleString, ClassString, "HLP_SolicitudConsulta.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_18_idx + "',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtavMedicox_Internalname, StringUtil.RTrim( AV8MedicoX), "", 20, "chr", 1, "row", 20, 1, 1, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( AV8MedicoX, "XXXXXXXXXXXXXXXXXXXX")), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(26);\"", 0, edtavMedicox_Jsonclick, "", 0, 1, -1, true, "left", "HLP_SolicitudConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, 1, 1, 0, "Especialidad", "", "", "", 0, lblTextblock4_Jsonclick, "", StyleString, ClassString, "HLP_SolicitudConsulta.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'" + sGXsfl_18_idx + "',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtavEspecialidadx_Internalname, StringUtil.RTrim( AV6EspecialidadX), "", 20, "chr", 1, "row", 20, 1, 1, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( AV6EspecialidadX, "XXXXXXXXXXXXXXXXXXXX")), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(31);\"", 0, edtavEspecialidadx_Jsonclick, "", 0, 1, -1, true, "left", "HLP_SolicitudConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, 1, 1, 0, "Fecha ", "", "", "", 0, lblTextblock5_Jsonclick, "", StyleString, ClassString, "HLP_SolicitudConsulta.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_18_idx + "',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            if ( ( 1 == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlText( "<table id=\""+edtavFechaconsultax_Internalname+"_dp_container\" cellpadding=\"0\" cellspacing=\"0\"><tr><td>") ;
            }
            GxWebStd.gx_single_line_edit( context, edtavFechaconsultax_Internalname, context.localUtil.Format(AV7FechaConsultaX, "99/99/99"), "", 8, "chr", 1, "row", 8, 1, 1, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( AV7FechaConsultaX, "99/99/99"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(36);\"", 0, edtavFechaconsultax_Jsonclick, "", 0, 1, -1, true, "right", "HLP_SolicitudConsulta.htm");
            if ( ( 1 == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlTextNl( "</td><td>") ;
               context.WriteHtmlText( "<img src=\""+context.convertURL( "calendar-img.gif")+"\" id=\""+edtavFechaconsultax_Internalname+"_dp_trigger\" style=\"cursor: pointer;\" title=\"Date selector\" alt=\"Date selector\" >") ;
               context.WriteHtmlTextNl( "</td></tr></table>") ;
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, 1, 1, 0, "Turno", "", "", "", 0, lblTextblock6_Jsonclick, "", StyleString, ClassString, "HLP_SolicitudConsulta.htm");
            ClassString = "Attribute" ;
            StyleString = "" ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_18_idx + "',0)\"" ;
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavTurnoidx, dynavTurnoidx_Internalname, StringUtil.Str( (decimal)(AV12TurnoIdX), 2, 0), "", "int", 1, 1, 0, 1, 0, 20, "chr", 0, "", StyleString, ClassString, "", 0, dynavTurnoidx_Jsonclick, "", TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(41);\"", true, "HLP_SolicitudConsulta.htm");
            dynavTurnoidx.CurrentValue = StringUtil.LTrim( StringUtil.Str( (decimal)(AV12TurnoIdX), 2, 0)) ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, dynavTurnoidx_Internalname, "Values", (String)(dynavTurnoidx.ToJavascriptSource()));
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td style=\"height:128px\">") ;
            /*  Grid Control  */
            GridmedicosContainer.SetWrapped(nGXWrapped);
            if ( GridmedicosContainer.GetWrapped() == 1 )
            {
               sStyleString = "" ;
               GxWebStd.gx_table_start( context, subGridmedicos_Internalname, subGridmedicos_Internalname, "", "Grid", 0, "", "", 1, 2, sStyleString, "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGridmedicos_Backcolorstyle == 0 )
               {
                  subGridmedicos_Titlebackstyle = 0 ;
                  if ( StringUtil.Len( subGridmedicos_Class) > 0 )
                  {
                     subGridmedicos_Linesclass = subGridmedicos_Class+"Title" ;
                  }
               }
               else
               {
                  subGridmedicos_Titlebackstyle = 1 ;
                  if ( subGridmedicos_Backcolorstyle == 1 )
                  {
                     subGridmedicos_Titlebackcolor = subGridmedicos_Allbackcolor ;
                     if ( StringUtil.Len( subGridmedicos_Class) > 0 )
                     {
                        subGridmedicos_Linesclass = subGridmedicos_Class+"UniformTitle" ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGridmedicos_Class) > 0 )
                     {
                        subGridmedicos_Linesclass = subGridmedicos_Class+"Title" ;
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGridmedicos_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Medico Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGridmedicos_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Apellido") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGridmedicos_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGridmedicos_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Espec. Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGridmedicos_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Especialidad Descrip.") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGridmedicos_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Consul. Fecha") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGridmedicos_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Turno Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGridmedicos_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Turno Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGridmedicos_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Nros Disp.") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGridmedicos_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( " Nros. Asig.") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
            }
            else
            {
               GridmedicosContainer.Clear();
               GridmedicosContainer.SetWrapped(nGXWrapped);
               GridmedicosContainer.AddObjectProperty("GridName", "Gridmedicos");
               GridmedicosContainer.AddObjectProperty("Class", "Grid");
               GridmedicosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridmedicosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridmedicosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridmedicos_Backcolorstyle), 1, 0, ".", "")));
               GridmedicosContainer.AddObjectProperty("CmpContext", "");
               GridmedicosContainer.AddObjectProperty("InMasterPage", "false");
               GridmedicosColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridmedicosColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12MedicoId), 6, 0, ".", "")));
               GridmedicosContainer.AddColumnProperties(GridmedicosColumn);
               GridmedicosColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridmedicosColumn.AddObjectProperty("Value", StringUtil.RTrim( A14MedicoApellido));
               GridmedicosContainer.AddColumnProperties(GridmedicosColumn);
               GridmedicosColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridmedicosColumn.AddObjectProperty("Value", StringUtil.RTrim( A13MedicoNombre));
               GridmedicosContainer.AddColumnProperties(GridmedicosColumn);
               GridmedicosColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridmedicosColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9EspecialidadId), 6, 0, ".", "")));
               GridmedicosContainer.AddColumnProperties(GridmedicosColumn);
               GridmedicosColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridmedicosColumn.AddObjectProperty("Value", StringUtil.RTrim( A10EspecialidadDescripcion));
               GridmedicosContainer.AddColumnProperties(GridmedicosColumn);
               GridmedicosColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridmedicosColumn.AddObjectProperty("Value", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
               GridmedicosContainer.AddColumnProperties(GridmedicosColumn);
               GridmedicosColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridmedicosColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A60TurnoId), 2, 0, ".", "")));
               GridmedicosContainer.AddColumnProperties(GridmedicosColumn);
               GridmedicosColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridmedicosColumn.AddObjectProperty("Value", StringUtil.RTrim( A61TurnoNombre));
               GridmedicosContainer.AddColumnProperties(GridmedicosColumn);
               GridmedicosColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridmedicosColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A65NrosDisponibles), 2, 0, ".", "")));
               GridmedicosContainer.AddColumnProperties(GridmedicosColumn);
               GridmedicosColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridmedicosColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A66CantNrosAsig), 2, 0, ".", "")));
               GridmedicosContainer.AddColumnProperties(GridmedicosColumn);
               GridmedicosContainer.AddObjectProperty("Allowselection", "true");
               GridmedicosContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridmedicos_Selectioncolor), 9, 0, ".", "")));
               GridmedicosContainer.AddObjectProperty("Allowhover", "true");
               GridmedicosContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridmedicos_Hoveringcolor), 9, 0, ".", "")));
               GridmedicosContainer.AddObjectProperty("Allowcollapsing", "false");
               GridmedicosContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridmedicos_Collapsed), 9, 0, ".", "")));
            }
         }
         if ( wbEnd == 45 )
         {
            wbEnd = 0 ;
            nRC_Gridmedicos = (short)(nGXsfl_45_idx-1) ;
            if ( GridmedicosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
            }
            else
            {
               sStyleString = " style=\"display:none;\"" ;
               sStyleString = "" ;
               context.WriteHtmlText( "<div id=\""+"GridmedicosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridmedicos", (Object)(GridmedicosContainer));
               GxWebStd.gx_hidden_field( context, "GridmedicosContainerData", GridmedicosContainer.ToJavascriptSource());
               if ( context.isAjaxRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridmedicosContainerData"+"V", GridmedicosContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridmedicosContainerData"+"V"+"\" value='"+GridmedicosContainer.GridValuesHidden()+"'>") ;
               }
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td style=\"height:17px\">") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"" ;
            ClassString = "SpecialButtons" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttButton1_Internalname, "Confirmar", "Confirmar", "", StyleString, ClassString, 1, 1, "rounded", 5, bttButton1_Jsonclick, "EENTER.", TempTags, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(18), 3, 0)+","+"null"+");", "", "HLP_SolicitudConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_2_0M2e( true) ;
         }
         else
         {
            wb_table1_2_0M2e( false) ;
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
         PA0M2( ) ;
         WS0M2( ) ;
         WE0M2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( Form.Jscriptsrc.Item(idxLst)), "?535265");
            idxLst = (int)(idxLst+1) ;
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?34981");
         context.AddJavascriptSource("solicitudconsulta.js", "?535265");
         /* End function include_jscripts */
      }

      protected void sendrow_182( )
      {
         WB0M0( ) ;
         GridpacientesRow = GXWebRow.GetNew(context,GridpacientesContainer) ;
         if ( subGridpacientes_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridpacientes_Backstyle = 0 ;
            if ( StringUtil.StrCmp(subGridpacientes_Class, "") != 0 )
            {
               subGridpacientes_Linesclass = subGridpacientes_Class+"Odd" ;
            }
         }
         else if ( subGridpacientes_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridpacientes_Backstyle = 0 ;
            subGridpacientes_Backcolor = subGridpacientes_Allbackcolor ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, "GridpacientesContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subGridpacientes_Backcolor), 9, 0)));
            if ( StringUtil.StrCmp(subGridpacientes_Class, "") != 0 )
            {
               subGridpacientes_Linesclass = subGridpacientes_Class+"Uniform" ;
            }
         }
         else if ( subGridpacientes_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridpacientes_Backstyle = 1 ;
            if ( StringUtil.StrCmp(subGridpacientes_Class, "") != 0 )
            {
               subGridpacientes_Linesclass = subGridpacientes_Class+"Odd" ;
            }
            subGridpacientes_Backcolor = (int)(0x0) ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, "GridpacientesContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subGridpacientes_Backcolor), 9, 0)));
         }
         else if ( subGridpacientes_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridpacientes_Backstyle = 1 ;
            if ( ((int)(nGXsfl_18_idx) % (2)) == 0 )
            {
               subGridpacientes_Backcolor = (int)(0x0) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, "GridpacientesContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subGridpacientes_Backcolor), 9, 0)));
               if ( StringUtil.StrCmp(subGridpacientes_Class, "") != 0 )
               {
                  subGridpacientes_Linesclass = subGridpacientes_Class+"Even" ;
               }
            }
            else
            {
               subGridpacientes_Backcolor = (int)(0x0) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, "GridpacientesContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subGridpacientes_Backcolor), 9, 0)));
               if ( StringUtil.StrCmp(subGridpacientes_Class, "") != 0 )
               {
                  subGridpacientes_Linesclass = subGridpacientes_Class+"Odd" ;
               }
            }
         }
         if ( GridpacientesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+subGridpacientes_Linesclass+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( ">") ;
         }
         /* Subfile cell */
         if ( GridpacientesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         ClassString = "Attribute" ;
         StyleString = "" ;
         ROClassString = ClassString ;
         GridpacientesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPacienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A34PacienteId), 6, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)6,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A34PacienteId), "ZZZZZ9"),(String)"",(short)0,(String)edtPacienteId_Jsonclick,(String)"",(short)18,(short)1,(short)1,(bool)true,(String)"right"});
         /* Subfile cell */
         if ( GridpacientesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         ClassString = "Attribute" ;
         StyleString = "" ;
         ROClassString = ClassString ;
         GridpacientesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPacienteCI_Internalname,StringUtil.RTrim( A41PacienteCI),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)8,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A41PacienteCI, "XXXXXXXX")),(String)"",(short)0,(String)edtPacienteCI_Jsonclick,(String)"",(short)18,(short)1,(short)1,(bool)true,(String)"left"});
         /* Subfile cell */
         if ( GridpacientesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         ClassString = "Attribute" ;
         StyleString = "" ;
         ROClassString = ClassString ;
         GridpacientesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPacienteApellido_Internalname,StringUtil.RTrim( A36PacienteApellido),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A36PacienteApellido, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtPacienteApellido_Jsonclick,(String)"",(short)18,(short)1,(short)1,(bool)true,(String)"left"});
         /* Subfile cell */
         if ( GridpacientesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         ClassString = "Attribute" ;
         StyleString = "" ;
         ROClassString = ClassString ;
         GridpacientesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPacienteNombre_Internalname,StringUtil.RTrim( A35PacienteNombre),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A35PacienteNombre, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtPacienteNombre_Jsonclick,(String)"",(short)18,(short)1,(short)1,(bool)true,(String)"left"});
         GridpacientesContainer.AddRow(GridpacientesRow);
         nGXsfl_18_idx = (short)(((subGridpacientes_Islastpage==1)&&(nGXsfl_18_idx+1>subGridpacientes_Recordsperpage( )) ? 1 : nGXsfl_18_idx+1)) ;
         sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_18_idx), 4, 0)), 4, "0") ;
         edtPacienteId_Internalname = "PACIENTEID_"+sGXsfl_18_idx ;
         edtPacienteCI_Internalname = "PACIENTECI_"+sGXsfl_18_idx ;
         edtPacienteApellido_Internalname = "PACIENTEAPELLIDO_"+sGXsfl_18_idx ;
         edtPacienteNombre_Internalname = "PACIENTENOMBRE_"+sGXsfl_18_idx ;
         /* End function sendrow_182 */
      }

      protected void sendrow_453( )
      {
         WB0M0( ) ;
         GridmedicosRow = GXWebRow.GetNew(context,GridmedicosContainer) ;
         if ( subGridmedicos_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridmedicos_Backstyle = 0 ;
            if ( StringUtil.StrCmp(subGridmedicos_Class, "") != 0 )
            {
               subGridmedicos_Linesclass = subGridmedicos_Class+"Odd" ;
            }
         }
         else if ( subGridmedicos_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridmedicos_Backstyle = 0 ;
            subGridmedicos_Backcolor = subGridmedicos_Allbackcolor ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, "GridmedicosContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subGridmedicos_Backcolor), 9, 0)));
            if ( StringUtil.StrCmp(subGridmedicos_Class, "") != 0 )
            {
               subGridmedicos_Linesclass = subGridmedicos_Class+"Uniform" ;
            }
         }
         else if ( subGridmedicos_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridmedicos_Backstyle = 1 ;
            if ( StringUtil.StrCmp(subGridmedicos_Class, "") != 0 )
            {
               subGridmedicos_Linesclass = subGridmedicos_Class+"Odd" ;
            }
            subGridmedicos_Backcolor = (int)(0x0) ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, "GridmedicosContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subGridmedicos_Backcolor), 9, 0)));
         }
         else if ( subGridmedicos_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridmedicos_Backstyle = 1 ;
            if ( ((int)(nGXsfl_45_idx) % (2)) == 0 )
            {
               subGridmedicos_Backcolor = (int)(0x0) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, "GridmedicosContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subGridmedicos_Backcolor), 9, 0)));
               if ( StringUtil.StrCmp(subGridmedicos_Class, "") != 0 )
               {
                  subGridmedicos_Linesclass = subGridmedicos_Class+"Even" ;
               }
            }
            else
            {
               subGridmedicos_Backcolor = (int)(0x0) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, "GridmedicosContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subGridmedicos_Backcolor), 9, 0)));
               if ( StringUtil.StrCmp(subGridmedicos_Class, "") != 0 )
               {
                  subGridmedicos_Linesclass = subGridmedicos_Class+"Odd" ;
               }
            }
         }
         if ( GridmedicosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+subGridmedicos_Linesclass+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( ">") ;
         }
         /* Subfile cell */
         if ( GridmedicosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         ClassString = "Attribute" ;
         StyleString = "" ;
         ROClassString = ClassString ;
         GridmedicosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMedicoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12MedicoId), 6, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)6,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A12MedicoId), "ZZZZZ9"),(String)"",(short)0,(String)edtMedicoId_Jsonclick,(String)"",(short)45,(short)1,(short)1,(bool)true,(String)"right"});
         /* Subfile cell */
         if ( GridmedicosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         ClassString = "Attribute" ;
         StyleString = "" ;
         ROClassString = ClassString ;
         GridmedicosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMedicoApellido_Internalname,StringUtil.RTrim( A14MedicoApellido),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A14MedicoApellido, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtMedicoApellido_Jsonclick,(String)"",(short)45,(short)1,(short)1,(bool)true,(String)"left"});
         /* Subfile cell */
         if ( GridmedicosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         ClassString = "Attribute" ;
         StyleString = "" ;
         ROClassString = ClassString ;
         GridmedicosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMedicoNombre_Internalname,StringUtil.RTrim( A13MedicoNombre),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A13MedicoNombre, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtMedicoNombre_Jsonclick,(String)"",(short)45,(short)1,(short)1,(bool)true,(String)"left"});
         /* Subfile cell */
         if ( GridmedicosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         ClassString = "Attribute" ;
         StyleString = "" ;
         ROClassString = ClassString ;
         GridmedicosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtEspecialidadId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A9EspecialidadId), 6, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)6,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A9EspecialidadId), "ZZZZZ9"),(String)"",(short)0,(String)edtEspecialidadId_Jsonclick,(String)"",(short)45,(short)1,(short)1,(bool)true,(String)"right"});
         /* Subfile cell */
         if ( GridmedicosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         ClassString = "Attribute" ;
         StyleString = "" ;
         ROClassString = ClassString ;
         GridmedicosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtEspecialidadDescripcion_Internalname,StringUtil.RTrim( A10EspecialidadDescripcion),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A10EspecialidadDescripcion, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtEspecialidadDescripcion_Jsonclick,(String)"",(short)45,(short)1,(short)1,(bool)true,(String)"left"});
         /* Subfile cell */
         if ( GridmedicosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         ClassString = "Attribute" ;
         StyleString = "" ;
         ROClassString = ClassString ;
         GridmedicosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtConsultaFecha_Internalname,context.localUtil.Format(A43ConsultaFecha, "99/99/99"),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)8,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( A43ConsultaFecha, "99/99/99"),(String)"",(short)0,(String)edtConsultaFecha_Jsonclick,(String)"",(short)45,(short)1,(short)1,(bool)true,(String)"right"});
         GXATURNOID_html0M3( ) ;
         /* Subfile cell */
         if ( GridmedicosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
         }
         ClassString = "Attribute" ;
         StyleString = "" ;
         if ( ( nGXsfl_45_idx == 1 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "TURNOID_" + sGXsfl_45_idx ;
            dynTurnoId.Name = GXCCtl ;
            dynTurnoId.WebTags = "" ;
         }
         /* ComboBox */
         GridmedicosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynTurnoId,(String)dynTurnoId_Internalname,StringUtil.Str( (decimal)(A60TurnoId), 2, 0),(String)"",(String)"int",(short)-1,(short)0,(short)0,(short)1,(short)0,(short)0,(String)"px",(short)0,(String)"",(String)StyleString,(String)ClassString,(String)"",(short)0,(String)dynTurnoId_Jsonclick,(String)"",(String)"",(bool)true});
         dynTurnoId.CurrentValue = StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)) ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, dynTurnoId_Internalname, "Values", (String)(dynTurnoId.ToJavascriptSource()));
         /* Subfile cell */
         if ( GridmedicosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         ClassString = "Attribute" ;
         StyleString = "" ;
         ROClassString = ClassString ;
         GridmedicosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTurnoNombre_Internalname,StringUtil.RTrim( A61TurnoNombre),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A61TurnoNombre, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtTurnoNombre_Jsonclick,(String)"",(short)45,(short)1,(short)1,(bool)true,(String)"left"});
         /* Subfile cell */
         if ( GridmedicosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         ClassString = "Attribute" ;
         StyleString = "" ;
         ROClassString = ClassString ;
         GridmedicosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtNrosDisponibles_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A65NrosDisponibles), 2, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)2,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A65NrosDisponibles), "Z9"),(String)"",(short)0,(String)edtNrosDisponibles_Jsonclick,(String)"",(short)45,(short)1,(short)1,(bool)true,(String)"right"});
         /* Subfile cell */
         if ( GridmedicosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         ClassString = "Attribute" ;
         StyleString = "" ;
         ROClassString = ClassString ;
         GridmedicosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtCantNrosAsig_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A66CantNrosAsig), 2, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)2,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A66CantNrosAsig), "Z9"),(String)"",(short)0,(String)edtCantNrosAsig_Jsonclick,(String)"",(short)45,(short)1,(short)1,(bool)true,(String)"right"});
         GridmedicosContainer.AddRow(GridmedicosRow);
         nGXsfl_45_idx = (short)(((subGridmedicos_Islastpage==1)&&(nGXsfl_45_idx+1>subGridmedicos_Recordsperpage( )) ? 1 : nGXsfl_45_idx+1)) ;
         sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_45_idx), 4, 0)), 4, "0") ;
         edtMedicoId_Internalname = "MEDICOID_"+sGXsfl_45_idx ;
         edtMedicoApellido_Internalname = "MEDICOAPELLIDO_"+sGXsfl_45_idx ;
         edtMedicoNombre_Internalname = "MEDICONOMBRE_"+sGXsfl_45_idx ;
         edtEspecialidadId_Internalname = "ESPECIALIDADID_"+sGXsfl_45_idx ;
         edtEspecialidadDescripcion_Internalname = "ESPECIALIDADDESCRIPCION_"+sGXsfl_45_idx ;
         edtConsultaFecha_Internalname = "CONSULTAFECHA_"+sGXsfl_45_idx ;
         dynTurnoId_Internalname = "TURNOID_"+sGXsfl_45_idx ;
         edtTurnoNombre_Internalname = "TURNONOMBRE_"+sGXsfl_45_idx ;
         edtNrosDisponibles_Internalname = "NROSDISPONIBLES_"+sGXsfl_45_idx ;
         edtCantNrosAsig_Internalname = "CANTNROSASIG_"+sGXsfl_45_idx ;
         /* End function sendrow_453 */
      }

      public override void initialize_properties( )
      {
         lblTextblock1_Internalname = "TEXTBLOCK1" ;
         edtavPacienteidx_Internalname = "_PACIENTEIDX" ;
         lblTextblock2_Internalname = "TEXTBLOCK2" ;
         edtavPacientecix_Internalname = "_PACIENTECIX" ;
         lblTextblock3_Internalname = "TEXTBLOCK3" ;
         edtavMedicox_Internalname = "_MEDICOX" ;
         lblTextblock4_Internalname = "TEXTBLOCK4" ;
         edtavEspecialidadx_Internalname = "_ESPECIALIDADX" ;
         lblTextblock5_Internalname = "TEXTBLOCK5" ;
         edtavFechaconsultax_Internalname = "_FECHACONSULTAX" ;
         lblTextblock6_Internalname = "TEXTBLOCK6" ;
         dynavTurnoidx_Internalname = "_TURNOIDX" ;
         bttButton1_Internalname = "BUTTON1" ;
         tblTable1_Internalname = "TABLE1" ;
         Form.Internalname = "FORM" ;
         subGridpacientes_Internalname = "GRIDPACIENTES" ;
         subGridmedicos_Internalname = "GRIDMEDICOS" ;
         edtCantNrosAsig_Jsonclick = "" ;
         edtNrosDisponibles_Jsonclick = "" ;
         edtTurnoNombre_Jsonclick = "" ;
         dynTurnoId_Jsonclick = "" ;
         edtConsultaFecha_Jsonclick = "" ;
         edtEspecialidadDescripcion_Jsonclick = "" ;
         edtEspecialidadId_Jsonclick = "" ;
         edtMedicoNombre_Jsonclick = "" ;
         edtMedicoApellido_Jsonclick = "" ;
         edtMedicoId_Jsonclick = "" ;
         edtPacienteNombre_Jsonclick = "" ;
         edtPacienteApellido_Jsonclick = "" ;
         edtPacienteCI_Jsonclick = "" ;
         edtPacienteId_Jsonclick = "" ;
         subGridmedicos_Hoveringcolor = (int)(0x00C0C0) ;
         subGridmedicos_Selectioncolor = (int)(0x0000FF) ;
         subGridmedicos_Class = "Grid" ;
         subGridmedicos_Backcolorstyle = 0 ;
         dynavTurnoidx_Jsonclick = "" ;
         edtavFechaconsultax_Jsonclick = "" ;
         edtavEspecialidadx_Jsonclick = "" ;
         edtavMedicox_Jsonclick = "" ;
         subGridpacientes_Hoveringcolor = (int)(0x00C0C0) ;
         subGridpacientes_Selectioncolor = (int)(0x008000) ;
         subGridpacientes_Class = "Grid" ;
         subGridpacientes_Backcolorstyle = 0 ;
         edtavPacientecix_Jsonclick = "" ;
         edtavPacienteidx_Jsonclick = "" ;
         Form.Headerrawhtml = "" ;
         Form.Background = "" ;
         Form.Backcolor = (int)(0xFFFFFF) ;
         Form.Caption = "Solicitud Consulta" ;
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
         GXCCtl = "" ;
         AV10PacienteCIX = "" ;
         AV8MedicoX = "" ;
         AV6EspecialidadX = "" ;
         AV7FechaConsultaX = DateTime.MinValue ;
         sDynURL = "" ;
         FormProcess = "" ;
         GX_FocusControl = "" ;
         Form = new GXWebForm();
         sPrefix = "" ;
         sEvt = "" ;
         EvtGridId = "" ;
         EvtRowId = "" ;
         sEvtType = "" ;
         edtMedicoId_Internalname = "" ;
         edtMedicoApellido_Internalname = "" ;
         edtMedicoNombre_Internalname = "" ;
         edtEspecialidadId_Internalname = "" ;
         edtEspecialidadDescripcion_Internalname = "" ;
         edtConsultaFecha_Internalname = "" ;
         dynTurnoId_Internalname = "" ;
         edtTurnoNombre_Internalname = "" ;
         edtNrosDisponibles_Internalname = "" ;
         edtCantNrosAsig_Internalname = "" ;
         A14MedicoApellido = "" ;
         A13MedicoNombre = "" ;
         A10EspecialidadDescripcion = "" ;
         A43ConsultaFecha = DateTime.MinValue ;
         A61TurnoNombre = "" ;
         edtPacienteId_Internalname = "" ;
         edtPacienteCI_Internalname = "" ;
         edtPacienteApellido_Internalname = "" ;
         edtPacienteNombre_Internalname = "" ;
         A41PacienteCI = "" ;
         A36PacienteApellido = "" ;
         A35PacienteNombre = "" ;
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "" ;
         scmdbuf = "" ;
         H000M2_A60TurnoId = new short[1] ;
         H000M2_A61TurnoNombre = new String[] {""} ;
         H000M3_A60TurnoId = new short[1] ;
         H000M3_A61TurnoNombre = new String[] {""} ;
         GridpacientesContainer = new GXWebGrid( context);
         GridmedicosContainer = new GXWebGrid( context);
         lV10PacienteCIX = "" ;
         H000M4_A35PacienteNombre = new String[] {""} ;
         H000M4_A36PacienteApellido = new String[] {""} ;
         H000M4_A41PacienteCI = new String[] {""} ;
         H000M4_A34PacienteId = new int[1] ;
         lV8MedicoX = "" ;
         lV6EspecialidadX = "" ;
         H000M6_A61TurnoNombre = new String[] {""} ;
         H000M6_A60TurnoId = new short[1] ;
         H000M6_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         H000M6_A10EspecialidadDescripcion = new String[] {""} ;
         H000M6_A9EspecialidadId = new int[1] ;
         H000M6_A13MedicoNombre = new String[] {""} ;
         H000M6_A14MedicoApellido = new String[] {""} ;
         H000M6_A12MedicoId = new int[1] ;
         H000M6_A11EspecialidadMaxPacientes = new short[1] ;
         H000M6_A66CantNrosAsig = new short[1] ;
         H000M7_A61TurnoNombre = new String[] {""} ;
         AV5ConsultaPacienteX = new SdtConsultaPaciente(context);
         sStyleString = "" ;
         ClassString = "" ;
         StyleString = "" ;
         lblTextblock1_Jsonclick = "" ;
         TempTags = "" ;
         lblTextblock2_Jsonclick = "" ;
         subGridpacientes_Linesclass = "" ;
         GridpacientesColumn = new GXWebColumn();
         lblTextblock3_Jsonclick = "" ;
         lblTextblock4_Jsonclick = "" ;
         lblTextblock5_Jsonclick = "" ;
         lblTextblock6_Jsonclick = "" ;
         subGridmedicos_Linesclass = "" ;
         GXt_char5 = "" ;
         GXt_char4 = "" ;
         GXt_char3 = "" ;
         GXt_char2 = "" ;
         GXt_char1 = "" ;
         GXt_char6 = "" ;
         GXt_char7 = "" ;
         GXt_char8 = "" ;
         GXt_char9 = "" ;
         GridmedicosColumn = new GXWebColumn();
         GXt_char10 = "" ;
         bttButton1_Jsonclick = "" ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         GridpacientesRow = new GXWebRow();
         ROClassString = "" ;
         GridmedicosRow = new GXWebRow();
         GXt_char11 = "" ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.solicitudconsulta__default(),
            new Object[][] {
                new Object[] {
               H000M2_A60TurnoId, H000M2_A61TurnoNombre
               }
               , new Object[] {
               H000M3_A60TurnoId, H000M3_A61TurnoNombre
               }
               , new Object[] {
               H000M4_A35PacienteNombre, H000M4_A36PacienteApellido, H000M4_A41PacienteCI, H000M4_A34PacienteId
               }
               , new Object[] {
               H000M6_A61TurnoNombre, H000M6_A60TurnoId, H000M6_A43ConsultaFecha, H000M6_A10EspecialidadDescripcion, H000M6_A9EspecialidadId, H000M6_A13MedicoNombre, H000M6_A14MedicoApellido, H000M6_A12MedicoId, H000M6_A11EspecialidadMaxPacientes, H000M6_A66CantNrosAsig
               }
               , new Object[] {
               H000M7_A61TurnoNombre
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0 ;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nRC_Gridpacientes ;
      private short nGXsfl_18_idx=1 ;
      private short AV12TurnoIdX ;
      private short nRC_Gridmedicos ;
      private short nGXsfl_45_idx=1 ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A60TurnoId ;
      private short A65NrosDisponibles ;
      private short A66CantNrosAsig ;
      private short nDonePA ;
      private short A11EspecialidadMaxPacientes ;
      private short subGridpacientes_Backcolorstyle ;
      private short subGridpacientes_Titlebackstyle ;
      private short subGridpacientes_Collapsed ;
      private short subGridmedicos_Backcolorstyle ;
      private short subGridmedicos_Titlebackstyle ;
      private short subGridmedicos_Collapsed ;
      private short nGXWrapped ;
      private short subGridpacientes_Backstyle ;
      private short subGridmedicos_Backstyle ;
      private int AV11PacienteIdX ;
      private int A12MedicoId ;
      private int A9EspecialidadId ;
      private int A34PacienteId ;
      private int gxdynajaxindex ;
      private int subGridpacientes_Islastpage ;
      private int subGridmedicos_Islastpage ;
      private int GRIDPACIENTES_nFirstRecordOnPage ;
      private int GRIDPACIENTES_nCurrentRecord ;
      private int GRIDMEDICOS_nFirstRecordOnPage ;
      private int GRIDMEDICOS_nCurrentRecord ;
      private int subGridpacientes_Titlebackcolor ;
      private int subGridpacientes_Allbackcolor ;
      private int subGridpacientes_Selectioncolor ;
      private int subGridpacientes_Hoveringcolor ;
      private int subGridmedicos_Titlebackcolor ;
      private int subGridmedicos_Allbackcolor ;
      private int subGridmedicos_Selectioncolor ;
      private int subGridmedicos_Hoveringcolor ;
      private int idxLst ;
      private int subGridpacientes_Backcolor ;
      private int subGridmedicos_Backcolor ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_18_idx="0001" ;
      private String sGXsfl_45_idx="0001" ;
      private String GXCCtl ;
      private String AV10PacienteCIX ;
      private String AV8MedicoX ;
      private String AV6EspecialidadX ;
      private String sDynURL ;
      private String FormProcess ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtMedicoId_Internalname ;
      private String edtMedicoApellido_Internalname ;
      private String edtMedicoNombre_Internalname ;
      private String edtEspecialidadId_Internalname ;
      private String edtEspecialidadDescripcion_Internalname ;
      private String edtConsultaFecha_Internalname ;
      private String dynTurnoId_Internalname ;
      private String edtTurnoNombre_Internalname ;
      private String edtNrosDisponibles_Internalname ;
      private String edtCantNrosAsig_Internalname ;
      private String A14MedicoApellido ;
      private String A13MedicoNombre ;
      private String A10EspecialidadDescripcion ;
      private String A61TurnoNombre ;
      private String edtPacienteId_Internalname ;
      private String edtPacienteCI_Internalname ;
      private String edtPacienteApellido_Internalname ;
      private String edtPacienteNombre_Internalname ;
      private String A41PacienteCI ;
      private String A36PacienteApellido ;
      private String A35PacienteNombre ;
      private String edtavPacienteidx_Internalname ;
      private String gxwrpcisep ;
      private String scmdbuf ;
      private String lV10PacienteCIX ;
      private String lV8MedicoX ;
      private String lV6EspecialidadX ;
      private String edtavPacientecix_Internalname ;
      private String edtavMedicox_Internalname ;
      private String edtavEspecialidadx_Internalname ;
      private String edtavFechaconsultax_Internalname ;
      private String dynavTurnoidx_Internalname ;
      private String subGridpacientes_Internalname ;
      private String subGridmedicos_Internalname ;
      private String sStyleString ;
      private String tblTable1_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String lblTextblock1_Internalname ;
      private String lblTextblock1_Jsonclick ;
      private String TempTags ;
      private String edtavPacienteidx_Jsonclick ;
      private String lblTextblock2_Internalname ;
      private String lblTextblock2_Jsonclick ;
      private String edtavPacientecix_Jsonclick ;
      private String subGridpacientes_Class ;
      private String subGridpacientes_Linesclass ;
      private String lblTextblock3_Internalname ;
      private String lblTextblock3_Jsonclick ;
      private String edtavMedicox_Jsonclick ;
      private String lblTextblock4_Internalname ;
      private String lblTextblock4_Jsonclick ;
      private String edtavEspecialidadx_Jsonclick ;
      private String lblTextblock5_Internalname ;
      private String lblTextblock5_Jsonclick ;
      private String edtavFechaconsultax_Jsonclick ;
      private String lblTextblock6_Internalname ;
      private String lblTextblock6_Jsonclick ;
      private String dynavTurnoidx_Jsonclick ;
      private String subGridmedicos_Class ;
      private String subGridmedicos_Linesclass ;
      private String GXt_char5 ;
      private String GXt_char4 ;
      private String GXt_char3 ;
      private String GXt_char2 ;
      private String GXt_char1 ;
      private String GXt_char6 ;
      private String GXt_char7 ;
      private String GXt_char8 ;
      private String GXt_char9 ;
      private String GXt_char10 ;
      private String bttButton1_Internalname ;
      private String bttButton1_Jsonclick ;
      private String ROClassString ;
      private String edtPacienteId_Jsonclick ;
      private String edtPacienteCI_Jsonclick ;
      private String edtPacienteApellido_Jsonclick ;
      private String edtPacienteNombre_Jsonclick ;
      private String edtMedicoId_Jsonclick ;
      private String edtMedicoApellido_Jsonclick ;
      private String edtMedicoNombre_Jsonclick ;
      private String edtEspecialidadId_Jsonclick ;
      private String edtEspecialidadDescripcion_Jsonclick ;
      private String edtConsultaFecha_Jsonclick ;
      private String dynTurnoId_Jsonclick ;
      private String edtTurnoNombre_Jsonclick ;
      private String edtNrosDisponibles_Jsonclick ;
      private String edtCantNrosAsig_Jsonclick ;
      private String GXt_char11 ;
      private DateTime AV7FechaConsultaX ;
      private DateTime A43ConsultaFecha ;
      private bool entryPointCalled ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool returnInSub ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXMasterPage MasterPageObj ;
      private GXWebGrid GridpacientesContainer ;
      private GXWebGrid GridmedicosContainer ;
      private GXWebRow GridpacientesRow ;
      private GXWebRow GridmedicosRow ;
      private GXWebColumn GridpacientesColumn ;
      private GXWebColumn GridmedicosColumn ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavTurnoidx ;
      private GXCombobox dynTurnoId ;
      private IDataStoreProvider pr_default ;
      private short[] H000M2_A60TurnoId ;
      private String[] H000M2_A61TurnoNombre ;
      private short[] H000M3_A60TurnoId ;
      private String[] H000M3_A61TurnoNombre ;
      private String[] H000M4_A35PacienteNombre ;
      private String[] H000M4_A36PacienteApellido ;
      private String[] H000M4_A41PacienteCI ;
      private int[] H000M4_A34PacienteId ;
      private String[] H000M6_A61TurnoNombre ;
      private short[] H000M6_A60TurnoId ;
      private DateTime[] H000M6_A43ConsultaFecha ;
      private String[] H000M6_A10EspecialidadDescripcion ;
      private int[] H000M6_A9EspecialidadId ;
      private String[] H000M6_A13MedicoNombre ;
      private String[] H000M6_A14MedicoApellido ;
      private int[] H000M6_A12MedicoId ;
      private short[] H000M6_A11EspecialidadMaxPacientes ;
      private short[] H000M6_A66CantNrosAsig ;
      private String[] H000M7_A61TurnoNombre ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private SdtConsultaPaciente AV5ConsultaPacienteX ;
   }

   public class solicitudconsulta__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000M4( int AV11PacienteIdX ,
                                             String AV10PacienteCIX ,
                                             int A34PacienteId ,
                                             String A41PacienteCI )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int12 ;
         GXv_int12 = new short [2] ;
         Object[] GXv_Object13 ;
         GXv_Object13 = new Object [2] ;
         scmdbuf = "SELECT [PacienteNombre], [PacienteApellido], [PacienteCI], [PacienteId] FROM [Paciente] WITH (NOLOCK)" ;
         if ( ! (0==AV11PacienteIdX) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([PacienteId] = @AV11PacienteIdX)" ;
            }
            else
            {
               sWhereString = sWhereString + " ([PacienteId] = @AV11PacienteIdX)" ;
            }
         }
         else
         {
            GXv_int12[0] = 1 ;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10PacienteCIX)) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([PacienteCI] like @AV10PacienteCIX)" ;
            }
            else
            {
               sWhereString = sWhereString + " ([PacienteCI] like @AV10PacienteCIX)" ;
            }
         }
         else
         {
            GXv_int12[1] = 1 ;
         }
         if ( StringUtil.StrCmp("", sWhereString) != 0 )
         {
            scmdbuf = scmdbuf + " WHERE " + sWhereString ;
         }
         scmdbuf = scmdbuf + " ORDER BY [PacienteId]" ;
         GXv_Object13[0] = scmdbuf ;
         GXv_Object13[1] = (Object)(GXv_int12) ;
         return GXv_Object13 ;
      }

      protected Object[] conditional_H000M6( String AV8MedicoX ,
                                             String AV6EspecialidadX ,
                                             DateTime AV7FechaConsultaX ,
                                             short AV12TurnoIdX ,
                                             String A14MedicoApellido ,
                                             String A10EspecialidadDescripcion ,
                                             DateTime A43ConsultaFecha ,
                                             short A60TurnoId )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int14 ;
         GXv_int14 = new short [4] ;
         Object[] GXv_Object15 ;
         GXv_Object15 = new Object [2] ;
         scmdbuf = "SELECT T2.[TurnoNombre], T1.[TurnoId], T1.[ConsultaFecha], T4.[EspecialidadDescripcion], T3.[EspecialidadId], T3.[MedicoNombre], T3.[MedicoApellido], T1.[MedicoId], T4.[EspecialidadMaxPacientes], COALESCE( T5.[CantNrosAsig], 0) AS CantNrosAsig FROM (((([Consulta] T1 WITH (NOLOCK) INNER JOIN [Turno] T2 WITH (NOLOCK) ON T2.[TurnoId] = T1.[TurnoId]) INNER JOIN [Medico] T3 WITH (NOLOCK) ON T3.[MedicoId] = T1.[MedicoId]) INNER JOIN [Especialidad] T4 WITH (NOLOCK) ON T4.[EspecialidadId] = T3.[EspecialidadId]) LEFT JOIN (SELECT [ConsultaFecha], [MedicoId], [TurnoId], COUNT(*) AS CantNrosAsig FROM [ConsultaPaciente] WITH (NOLOCK) GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T5 ON T5.[ConsultaFecha] = T1.[ConsultaFecha] AND T5.[MedicoId] = T1.[MedicoId] AND T5.[TurnoId] = T1.[TurnoId])" ;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8MedicoX)) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (T3.[MedicoApellido] like @AV8MedicoX)" ;
            }
            else
            {
               sWhereString = sWhereString + " (T3.[MedicoApellido] like @AV8MedicoX)" ;
            }
         }
         else
         {
            GXv_int14[0] = 1 ;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV6EspecialidadX)) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (T4.[EspecialidadDescripcion] like @AV6EspecialidadX)" ;
            }
            else
            {
               sWhereString = sWhereString + " (T4.[EspecialidadDescripcion] like @AV6EspecialidadX)" ;
            }
         }
         else
         {
            GXv_int14[1] = 1 ;
         }
         if ( ! (DateTime.MinValue==AV7FechaConsultaX) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (T1.[ConsultaFecha] = @AV7FechaConsultaX)" ;
            }
            else
            {
               sWhereString = sWhereString + " (T1.[ConsultaFecha] = @AV7FechaConsultaX)" ;
            }
         }
         else
         {
            GXv_int14[2] = 1 ;
         }
         if ( ! (0==AV12TurnoIdX) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (T1.[TurnoId] = @AV12TurnoIdX)" ;
            }
            else
            {
               sWhereString = sWhereString + " (T1.[TurnoId] = @AV12TurnoIdX)" ;
            }
         }
         else
         {
            GXv_int14[3] = 1 ;
         }
         if ( StringUtil.StrCmp("", sWhereString) != 0 )
         {
            scmdbuf = scmdbuf + " WHERE " + sWhereString ;
         }
         scmdbuf = scmdbuf + " ORDER BY T1.[ConsultaFecha], T1.[MedicoId], T1.[TurnoId]" ;
         GXv_Object15[0] = scmdbuf ;
         GXv_Object15[1] = (Object)(GXv_int14) ;
         return GXv_Object15 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_H000M4( (int)dynConstraints[0] , (String)dynConstraints[1] , (int)dynConstraints[2] , (String)dynConstraints[3] );
               case 3 :
                     return conditional_H000M6( (String)dynConstraints[0] , (String)dynConstraints[1] , (DateTime)dynConstraints[2] , (short)dynConstraints[3] , (String)dynConstraints[4] , (String)dynConstraints[5] , (DateTime)dynConstraints[6] , (short)dynConstraints[7] );
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
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000M2 ;
          prmH000M2 = new Object[] {
          } ;
          Object[] prmH000M3 ;
          prmH000M3 = new Object[] {
          } ;
          Object[] prmH000M7 ;
          prmH000M7 = new Object[] {
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmH000M4 ;
          prmH000M4 = new Object[] {
          new Object[] {"@AV11PacienteIdX",SqlDbType.Int,6,0} ,
          new Object[] {"@AV10PacienteCIX",SqlDbType.Char,8,0}
          } ;
          Object[] prmH000M6 ;
          prmH000M6 = new Object[] {
          new Object[] {"@AV8MedicoX",SqlDbType.Char,20,0} ,
          new Object[] {"@AV6EspecialidadX",SqlDbType.Char,20,0} ,
          new Object[] {"@AV7FechaConsultaX",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV12TurnoIdX",SqlDbType.SmallInt,2,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H000M2", "SELECT [TurnoId], [TurnoNombre] FROM [Turno] WITH (NOLOCK) ORDER BY [TurnoNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000M2,0,0,true,false )
             ,new CursorDef("H000M3", "SELECT [TurnoId], [TurnoNombre] FROM [Turno] WITH (NOLOCK) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000M3,0,0,true,false )
             ,new CursorDef("H000M4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000M4,11,0,true,false )
             ,new CursorDef("H000M6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000M6,11,0,true,false )
             ,new CursorDef("H000M7", "SELECT [TurnoNombre] FROM [Turno] WITH (NOLOCK) WHERE [TurnoId] = @TurnoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000M7,1,0,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                break;
             case 2 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 8) ;
                ((int[]) buf[3])[0] = rslt.getInt(4) ;
                break;
             case 3 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3) ;
                ((String[]) buf[3])[0] = rslt.getString(4, 20) ;
                ((int[]) buf[4])[0] = rslt.getInt(5) ;
                ((String[]) buf[5])[0] = rslt.getString(6, 20) ;
                ((String[]) buf[6])[0] = rslt.getString(7, 20) ;
                ((int[]) buf[7])[0] = rslt.getInt(8) ;
                ((short[]) buf[8])[0] = rslt.getShort(9) ;
                ((short[]) buf[9])[0] = rslt.getShort(10) ;
                break;
             case 4 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
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
             case 2 :
                sIdx = 0 ;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1) ;
                   stmt.SetParameter(sIdx, (int)parms[2]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1) ;
                   stmt.SetParameter(sIdx, (String)parms[3]);
                }
                break;
             case 3 :
                sIdx = 0 ;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1) ;
                   stmt.SetParameter(sIdx, (String)parms[4]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1) ;
                   stmt.SetParameter(sIdx, (String)parms[5]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1) ;
                   stmt.SetParameter(sIdx, (DateTime)parms[6]);
                }
                if ( (short)parms[3] == 0 )
                {
                   sIdx = (short)(sIdx+1) ;
                   stmt.SetParameter(sIdx, (short)parms[7]);
                }
                break;
             case 4 :
                stmt.SetParameter(1, (short)parms[0]);
                break;
       }
    }

 }

}
