/*
               File: WWGestionConsulta
        Description: Work With Gestion Consulta
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/24/2010 5:52:8.39
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
   public class wwgestionconsulta : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwgestionconsulta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public wwgestionconsulta( IGxContext context )
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
               nGXsfl_24_idx = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
               sGXsfl_24_idx = GetNextPar( ) ;
               edtavDisplay_Tooltiptext = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDisplay_Internalname, "Tooltiptext", edtavDisplay_Tooltiptext);
               AV16Display = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDisplay_Internalname, "Bitmap", context.convertURL( AV16Display));
               edtavUpdate_Tooltiptext = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext);
               AV15Update = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Bitmap", context.convertURL( AV15Update));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1 ;
                  return  ;
               }
               gxnrGrid_newrow( nRC_Grid, nGXsfl_24_idx, sGXsfl_24_idx, AV16Display, AV15Update) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               /* GeneXus formulas. */
               AV19Pgmname = "WWGestionConsulta" ;
               context.Gx_err = 0 ;
               Grid_PageSize24 = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
               AV13ConsultorioId = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV13ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV13ConsultorioId), 3, 0)));
               AV14ConsultaFecha = context.localUtil.ParseDateParm( GetNextPar( )) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV14ConsultaFecha", context.localUtil.Format(AV14ConsultaFecha, "99/99/99"));
               edtavDisplay_Tooltiptext = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDisplay_Internalname, "Tooltiptext", edtavDisplay_Tooltiptext);
               AV16Display = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDisplay_Internalname, "Bitmap", context.convertURL( AV16Display));
               edtavUpdate_Tooltiptext = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext);
               AV15Update = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Bitmap", context.convertURL( AV15Update));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1 ;
                  return  ;
               }
               gxgrGrid_refresh( Grid_PageSize24, AV13ConsultorioId, AV14ConsultaFecha, AV16Display, AV15Update) ;
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
         PA0G2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0)) ;
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0G2( ) ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" onsubmit=\"try{return gx.csv.validForm()}catch(e){return true;}\" name=\"MAINFORM\" method=\"post\" action=\""+formatLink("wwgestionconsulta.aspx") +"\" class=\""+"Form"+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         }
      }

      public override void RenderHtmlCloseForm( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH__CONSULTORIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13ConsultorioId), 3, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH__CONSULTAFECHA", context.localUtil.Format(AV14ConsultaFecha, "99/99/99"));
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
            WE0G2( ) ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0G2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override String GetPgmname( )
      {
         return "WWGestionConsulta" ;
      }

      public override String GetPgmdesc( )
      {
         return "Work With Gestion Consulta" ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("wwgestionconsulta.aspx")  ;
      }

      protected void WB0G0( )
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
            wb_table1_2_0G2( true) ;
         }
         else
         {
            wb_table1_2_0G2( false) ;
         }
         return  ;
      }

      protected void wb_table1_2_0G2e( bool wbgen )
      {
         if ( wbgen )
         {
         }
         wbLoad = true ;
      }

      protected void START0G2( )
      {
         wbLoad = false ;
         wbEnd = 0 ;
         wbStart = 0 ;
         Form.Meta.addItem("Generator", "GeneXus C#", 0) ;
         Form.Meta.addItem("Version", "10_1_3-34981", 0) ;
         Form.Meta.addItem("Description", "Work With Gestion Consulta", 0) ;
         context.wjLoc = "" ;
         context.nUserReturn = 0 ;
         context.wbHandled = 0 ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false ;
         STRUP0G0( ) ;
      }

      protected void WS0G2( )
      {
         START0G2( ) ;
         EVT0G2( ) ;
      }

      protected void EVT0G2( )
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
                  if ( ( context.localUtil.CToN( cgiGet( "GXH__CONSULTORIOID"), ",", ".") != Convert.ToDecimal( AV13ConsultorioId )) )
                  {
                     GRID_nFirstRecordOnPage = 0 ;
                  }
                  if ( context.localUtil.CToD( cgiGet( "GXH__CONSULTAFECHA"), 2) != AV14ConsultaFecha )
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
                              nGXsfl_24_idx = (short)(NumberUtil.Val( sEvtType, ".")) ;
                              sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_24_idx), 4, 0)), 4, "0") ;
                              edtavUpdate_Internalname = "_UPDATE_"+sGXsfl_24_idx ;
                              edtavDisplay_Internalname = "_DISPLAY_"+sGXsfl_24_idx ;
                              edtConsultaFecha_Internalname = "CONSULTAFECHA_"+sGXsfl_24_idx ;
                              edtMedicoId_Internalname = "MEDICOID_"+sGXsfl_24_idx ;
                              edtMedicoNombre_Internalname = "MEDICONOMBRE_"+sGXsfl_24_idx ;
                              edtMedicoApellido_Internalname = "MEDICOAPELLIDO_"+sGXsfl_24_idx ;
                              edtTurnoId_Internalname = "TURNOID_"+sGXsfl_24_idx ;
                              edtTurnoNombre_Internalname = "TURNONOMBRE_"+sGXsfl_24_idx ;
                              edtConsultorioId_Internalname = "CONSULTORIOID_"+sGXsfl_24_idx ;
                              edtCantNrosAsig_Internalname = "CANTNROSASIG_"+sGXsfl_24_idx ;
                              edtNrosDisponibles_Internalname = "NROSDISPONIBLES_"+sGXsfl_24_idx ;
                              edtUltimoNroAsig_Internalname = "ULTIMONROASIG_"+sGXsfl_24_idx ;
                              edtCantPacConf_Internalname = "CANTPACCONF_"+sGXsfl_24_idx ;
                              AV15Update = cgiGet( "GXimg"+edtavUpdate_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Bitmap", context.convertURL( AV15Update));
                              AV16Display = cgiGet( "GXimg"+edtavDisplay_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDisplay_Internalname, "Bitmap", context.convertURL( AV16Display));
                              A43ConsultaFecha = context.localUtil.CToD( cgiGet( edtConsultaFecha_Internalname), 2) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
                              A12MedicoId = (int)(context.localUtil.CToN( cgiGet( edtMedicoId_Internalname), ",", ".")) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
                              A13MedicoNombre = cgiGet( edtMedicoNombre_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
                              A14MedicoApellido = cgiGet( edtMedicoApellido_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
                              A60TurnoId = (short)(context.localUtil.CToN( cgiGet( edtTurnoId_Internalname), ",", ".")) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
                              A61TurnoNombre = cgiGet( edtTurnoNombre_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
                              A57ConsultorioId = (short)(context.localUtil.CToN( cgiGet( edtConsultorioId_Internalname), ",", ".")) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A57ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A57ConsultorioId), 3, 0)));
                              A66CantNrosAsig = (short)(context.localUtil.CToN( cgiGet( edtCantNrosAsig_Internalname), ",", ".")) ;
                              n66CantNrosAsig = false ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
                              A65NrosDisponibles = (short)(context.localUtil.CToN( cgiGet( edtNrosDisponibles_Internalname), ",", ".")) ;
                              n65NrosDisponibles = false ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A65NrosDisponibles", StringUtil.LTrim( StringUtil.Str( (decimal)(A65NrosDisponibles), 2, 0)));
                              A67UltimoNroAsig = (short)(context.localUtil.CToN( cgiGet( edtUltimoNroAsig_Internalname), ",", ".")) ;
                              n67UltimoNroAsig = false ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
                              A70CantPacConf = (short)(context.localUtil.CToN( cgiGet( edtCantPacConf_Internalname), ",", ".")) ;
                              n70CantPacConf = false ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A70CantPacConf", StringUtil.LTrim( StringUtil.Str( (decimal)(A70CantPacConf), 2, 0)));
                              sEvtType = StringUtil.Right( sEvt, 1) ;
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1)) ;
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    dynload_actions( ) ;
                                    /* Execute user event: E110G2 */
                                    E110G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    dynload_actions( ) ;
                                    /* Execute user event: E120G2 */
                                    E120G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    dynload_actions( ) ;
                                    /* Execute user event: E130G2 */
                                    E130G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false ;
                                       /* Set Refresh If Consultorioid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH__CONSULTORIOID"), ",", ".") != Convert.ToDecimal( AV13ConsultorioId )) )
                                       {
                                          Rfr0gs = true ;
                                       }
                                       /* Set Refresh If Consultafecha Changed */
                                       if ( context.localUtil.CToD( cgiGet( "GXH__CONSULTAFECHA"), 2) != AV14ConsultaFecha )
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

      protected void WE0G2( )
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

      protected void PA0G2( )
      {
         if ( nDonePA == 0 )
         {
            GX_FocusControl = edtavConsultorioid_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            nDonePA = 1 ;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( short nRC_Grid ,
                                      short nGXsfl_24_idx ,
                                      String sGXsfl_24_idx ,
                                      String AV16Display ,
                                      String AV15Update )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         edtavUpdate_Internalname = "_UPDATE_"+sGXsfl_24_idx ;
         edtavDisplay_Internalname = "_DISPLAY_"+sGXsfl_24_idx ;
         edtConsultaFecha_Internalname = "CONSULTAFECHA_"+sGXsfl_24_idx ;
         edtMedicoId_Internalname = "MEDICOID_"+sGXsfl_24_idx ;
         edtMedicoNombre_Internalname = "MEDICONOMBRE_"+sGXsfl_24_idx ;
         edtMedicoApellido_Internalname = "MEDICOAPELLIDO_"+sGXsfl_24_idx ;
         edtTurnoId_Internalname = "TURNOID_"+sGXsfl_24_idx ;
         edtTurnoNombre_Internalname = "TURNONOMBRE_"+sGXsfl_24_idx ;
         edtConsultorioId_Internalname = "CONSULTORIOID_"+sGXsfl_24_idx ;
         edtCantNrosAsig_Internalname = "CANTNROSASIG_"+sGXsfl_24_idx ;
         edtNrosDisponibles_Internalname = "NROSDISPONIBLES_"+sGXsfl_24_idx ;
         edtUltimoNroAsig_Internalname = "ULTIMONROASIG_"+sGXsfl_24_idx ;
         edtCantPacConf_Internalname = "CANTPACCONF_"+sGXsfl_24_idx ;
         while ( nGXsfl_24_idx <= nRC_Grid )
         {
            sendrow_242( ) ;
            nGXsfl_24_idx = (short)(((subGrid_Islastpage==1)&&(nGXsfl_24_idx+1>subGrid_Recordsperpage( )) ? 1 : nGXsfl_24_idx+1)) ;
            sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_24_idx), 4, 0)), 4, "0") ;
            edtavUpdate_Internalname = "_UPDATE_"+sGXsfl_24_idx ;
            edtavDisplay_Internalname = "_DISPLAY_"+sGXsfl_24_idx ;
            edtConsultaFecha_Internalname = "CONSULTAFECHA_"+sGXsfl_24_idx ;
            edtMedicoId_Internalname = "MEDICOID_"+sGXsfl_24_idx ;
            edtMedicoNombre_Internalname = "MEDICONOMBRE_"+sGXsfl_24_idx ;
            edtMedicoApellido_Internalname = "MEDICOAPELLIDO_"+sGXsfl_24_idx ;
            edtTurnoId_Internalname = "TURNOID_"+sGXsfl_24_idx ;
            edtTurnoNombre_Internalname = "TURNONOMBRE_"+sGXsfl_24_idx ;
            edtConsultorioId_Internalname = "CONSULTORIOID_"+sGXsfl_24_idx ;
            edtCantNrosAsig_Internalname = "CANTNROSASIG_"+sGXsfl_24_idx ;
            edtNrosDisponibles_Internalname = "NROSDISPONIBLES_"+sGXsfl_24_idx ;
            edtUltimoNroAsig_Internalname = "ULTIMONROASIG_"+sGXsfl_24_idx ;
            edtCantPacConf_Internalname = "CANTPACCONF_"+sGXsfl_24_idx ;
         }
         context.GX_webresponse.AddString(GridContainer.ToJavascriptSource());
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int Grid_PageSize24 ,
                                       short AV13ConsultorioId ,
                                       DateTime AV14ConsultaFecha ,
                                       String AV16Display ,
                                       String AV15Update )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         disableOutput();
         subGrid_Rows = (short)(Grid_PageSize24) ;
         RF0G2( ) ;
         enableOutput();
         context.GX_webresponse.AddString(GridContainer.ToJavascriptSource());
         /* End function gxgrGrid_refresh */
      }

      protected void Refresh( )
      {
         RF0G2( ) ;
         /* End function Refresh */
      }

      protected void RF0G2( )
      {
         GridContainer.PageSize = subGrid_Recordsperpage( ) ;
         wbStart = 24 ;
         /* Execute user event: E120G2 */
         E120G2 ();
         nGXsfl_24_idx = 1 ;
         sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_24_idx), 4, 0)), 4, "0") ;
         edtavUpdate_Internalname = "_UPDATE_"+sGXsfl_24_idx ;
         edtavDisplay_Internalname = "_DISPLAY_"+sGXsfl_24_idx ;
         edtConsultaFecha_Internalname = "CONSULTAFECHA_"+sGXsfl_24_idx ;
         edtMedicoId_Internalname = "MEDICOID_"+sGXsfl_24_idx ;
         edtMedicoNombre_Internalname = "MEDICONOMBRE_"+sGXsfl_24_idx ;
         edtMedicoApellido_Internalname = "MEDICOAPELLIDO_"+sGXsfl_24_idx ;
         edtTurnoId_Internalname = "TURNOID_"+sGXsfl_24_idx ;
         edtTurnoNombre_Internalname = "TURNONOMBRE_"+sGXsfl_24_idx ;
         edtConsultorioId_Internalname = "CONSULTORIOID_"+sGXsfl_24_idx ;
         edtCantNrosAsig_Internalname = "CANTNROSASIG_"+sGXsfl_24_idx ;
         edtNrosDisponibles_Internalname = "NROSDISPONIBLES_"+sGXsfl_24_idx ;
         edtUltimoNroAsig_Internalname = "ULTIMONROASIG_"+sGXsfl_24_idx ;
         edtCantPacConf_Internalname = "CANTPACCONF_"+sGXsfl_24_idx ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
         {
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV13ConsultorioId ,
                                                 AV14ConsultaFecha ,
                                                 A57ConsultorioId ,
                                                 A43ConsultaFecha },
                                                 new int[] {
                                                 TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE
                                                 }
            });
            /* Using cursor H000G6 */
            pr_default.execute(0, new Object[] {AV13ConsultorioId, AV14ConsultaFecha});
            nGXsfl_24_idx = 1 ;
            GRID_nEOF = 0 ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_Recordsperpage( ) ) ) ) )
            {
               A67UltimoNroAsig = H000G6_A67UltimoNroAsig[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
               n67UltimoNroAsig = H000G6_n67UltimoNroAsig[0] ;
               A57ConsultorioId = H000G6_A57ConsultorioId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A57ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A57ConsultorioId), 3, 0)));
               A61TurnoNombre = H000G6_A61TurnoNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
               A60TurnoId = H000G6_A60TurnoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
               A14MedicoApellido = H000G6_A14MedicoApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
               A13MedicoNombre = H000G6_A13MedicoNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
               A12MedicoId = H000G6_A12MedicoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
               A43ConsultaFecha = H000G6_A43ConsultaFecha[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
               A70CantPacConf = H000G6_A70CantPacConf[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A70CantPacConf", StringUtil.LTrim( StringUtil.Str( (decimal)(A70CantPacConf), 2, 0)));
               n70CantPacConf = H000G6_n70CantPacConf[0] ;
               A65NrosDisponibles = H000G6_A65NrosDisponibles[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A65NrosDisponibles", StringUtil.LTrim( StringUtil.Str( (decimal)(A65NrosDisponibles), 2, 0)));
               n65NrosDisponibles = H000G6_n65NrosDisponibles[0] ;
               A66CantNrosAsig = H000G6_A66CantNrosAsig[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
               n66CantNrosAsig = H000G6_n66CantNrosAsig[0] ;
               A61TurnoNombre = H000G6_A61TurnoNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A61TurnoNombre", A61TurnoNombre);
               A14MedicoApellido = H000G6_A14MedicoApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A14MedicoApellido", A14MedicoApellido);
               A13MedicoNombre = H000G6_A13MedicoNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A13MedicoNombre", A13MedicoNombre);
               A70CantPacConf = H000G6_A70CantPacConf[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A70CantPacConf", StringUtil.LTrim( StringUtil.Str( (decimal)(A70CantPacConf), 2, 0)));
               n70CantPacConf = H000G6_n70CantPacConf[0] ;
               A65NrosDisponibles = H000G6_A65NrosDisponibles[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A65NrosDisponibles", StringUtil.LTrim( StringUtil.Str( (decimal)(A65NrosDisponibles), 2, 0)));
               n65NrosDisponibles = H000G6_n65NrosDisponibles[0] ;
               A66CantNrosAsig = H000G6_A66CantNrosAsig[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
               n66CantNrosAsig = H000G6_n66CantNrosAsig[0] ;
               /* Execute user event: E130G2 */
               E130G2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0)) ;
            pr_default.close(0);
            wbEnd = 24 ;
            WB0G0( ) ;
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
                                              AV13ConsultorioId ,
                                              AV14ConsultaFecha ,
                                              A57ConsultorioId ,
                                              A43ConsultaFecha },
                                              new int[] {
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE
                                              }
         });
         /* Using cursor H000G11 */
         pr_default.execute(1, new Object[] {AV13ConsultorioId, AV14ConsultaFecha});
         GRID_nRecordCount = H000G11_AGRID_nRecordCount[0] ;
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

      protected void STRUP0G0( )
      {
         /* Before Start, stand alone formulas. */
         AV19Pgmname = "WWGestionConsulta" ;
         context.Gx_err = 0 ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0 ;
         /* Execute user event: E110G2 */
         E110G2 ();
         context.wbGlbDoneStart = 1 ;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavConsultorioid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavConsultorioid_Internalname), ",", ".") > Convert.ToDecimal( 999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum"), 1, "_CONSULTORIOID");
               GX_FocusControl = edtavConsultorioid_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true ;
               AV13ConsultorioId = 0 ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV13ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV13ConsultorioId), 3, 0)));
            }
            else
            {
               AV13ConsultorioId = (short)(context.localUtil.CToN( cgiGet( edtavConsultorioid_Internalname), ",", ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV13ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV13ConsultorioId), 3, 0)));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavConsultafecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Consulta Fecha"}), 1, "_CONSULTAFECHA");
               GX_FocusControl = edtavConsultafecha_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true ;
               AV14ConsultaFecha = DateTime.MinValue ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV14ConsultaFecha", context.localUtil.Format(AV14ConsultaFecha, "99/99/99"));
            }
            else
            {
               AV14ConsultaFecha = context.localUtil.CToD( cgiGet( edtavConsultafecha_Internalname), 2) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV14ConsultaFecha", context.localUtil.Format(AV14ConsultaFecha, "99/99/99"));
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
         /* Execute user event: E110G2 */
         E110G2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E110G2( )
      {
         /* Start Routine */
         new isauthorized(context ).execute(  AV19Pgmname, out  AV5IsAuthorized) ;
         if ( ! AV5IsAuthorized )
         {
            context.wjLoc = formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV19Pgmname)) ;
         }
         subGrid_Rows = 10 ;
         AV15Update = context.GetImagePath( "7c63c2b9-483e-4035-b512-febf9186a274", "", "GeneXusX") ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Bitmap", context.convertURL( AV15Update));
         edtavUpdate_Tooltiptext = "Modifica" ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext);
         AV16Display = context.GetImagePath( "f11923b6-6acd-4a79-bfc0-0cfc6f3bced5", "", "GeneXusX") ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDisplay_Internalname, "Bitmap", context.convertURL( AV16Display));
         edtavDisplay_Tooltiptext = "Visualizar" ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDisplay_Internalname, "Tooltiptext", edtavDisplay_Tooltiptext);
         Form.Caption = "Work With Gestion Consultas" ;
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

      protected void E120G2( )
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

      private void E130G2( )
      {
         /* Grid_Load Routine */
         edtavUpdate_Link = formatLink("gestionconsulta.aspx") + "?" + UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(DateTimeUtil.FormatDateParm(A43ConsultaFecha)) + "," + UrlEncode("" +A12MedicoId) + "," + UrlEncode("" +A60TurnoId) ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavUpdate_Internalname, "Link", edtavUpdate_Link);
         edtavDisplay_Link = formatLink("gestionconsulta.aspx") + "?" + UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(DateTimeUtil.FormatDateParm(A43ConsultaFecha)) + "," + UrlEncode("" +A12MedicoId) + "," + UrlEncode("" +A60TurnoId) ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavDisplay_Internalname, "Link", edtavDisplay_Link);
         edtConsultorioId_Link = formatLink("viewgestionconsulta.aspx") + "?" + UrlEncode(DateTimeUtil.FormatDateParm(A43ConsultaFecha)) + "," + UrlEncode("" +A12MedicoId) + "," + UrlEncode("" +A60TurnoId) + "," + UrlEncode(StringUtil.RTrim("")) ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtConsultorioId_Internalname, "Link", edtConsultorioId_Link);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 24 ;
         }
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_Recordsperpage( ) ) ) )
         {
            sendrow_242( ) ;
         }
         GRID_nCurrentRecord = (int)(GRID_nCurrentRecord+1) ;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            AV9GridState.FromXml(AV7Session.Get(AV19Pgmname+"GridState"), "");
            if ( AV9GridState.gxTpr_Filtervalues.Count >= 2 )
            {
               AV13ConsultorioId = (short)(NumberUtil.Val( ((SdtGridState_FilterValue)AV9GridState.gxTpr_Filtervalues.Item(1)).gxTpr_Value, ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV13ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV13ConsultorioId), 3, 0)));
               AV14ConsultaFecha = context.localUtil.CToD( ((SdtGridState_FilterValue)AV9GridState.gxTpr_Filtervalues.Item(2)).gxTpr_Value, 2) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV14ConsultaFecha", context.localUtil.Format(AV14ConsultaFecha, "99/99/99"));
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
         AV9GridState.FromXml(AV7Session.Get(AV19Pgmname+"GridState"), "");
         AV9GridState.gxTpr_Currentpage = (short)(subGrid_Currentpage( )) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9GridState", (Object)(AV9GridState));
         AV9GridState.gxTpr_Filtervalues.Clear();
         AV10GridStateFilterValue = new SdtGridState_FilterValue(context) ;
         AV10GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV13ConsultorioId), 3, 0) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridStateFilterValue", (Object)(AV10GridStateFilterValue));
         AV9GridState.gxTpr_Filtervalues.Add(AV10GridStateFilterValue, 0);
         AV10GridStateFilterValue = new SdtGridState_FilterValue(context) ;
         AV10GridStateFilterValue.gxTpr_Value = context.localUtil.DToC( AV14ConsultaFecha, 2, "/") ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridStateFilterValue", (Object)(AV10GridStateFilterValue));
         AV9GridState.gxTpr_Filtervalues.Add(AV10GridStateFilterValue, 0);
         AV7Session.Set(AV19Pgmname+"GridState", AV9GridState.ToXml(false, "GridState", "taller041"));
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         AV11TrnContext = new SdtTransactionContext(context) ;
         AV11TrnContext.gxTpr_Callerobject = AV19Pgmname ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11TrnContext", (Object)(AV11TrnContext));
         AV11TrnContext.gxTpr_Callerondelete = true ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11TrnContext", (Object)(AV11TrnContext));
         AV11TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11TrnContext", (Object)(AV11TrnContext));
         AV11TrnContext.gxTpr_Transactionname = "GestionConsulta" ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11TrnContext", (Object)(AV11TrnContext));
         AV7Session.Set("TrnContext", AV11TrnContext.ToXml(false, "TransactionContext", "taller041"));
      }

      protected void wb_table1_2_0G2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, 1, 1, 0, "Work With Gestion Consultas", "", "", "", 0, lblTitletext_Jsonclick, "", StyleString, ClassString, "HLP_WWGestionConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_8_0G2( true) ;
         }
         else
         {
            wb_table2_8_0G2( false) ;
         }
         return  ;
      }

      protected void wb_table2_8_0G2e( bool wbgen )
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
               context.SendWebValue( "Medico Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Apellido") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Turno Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Turno Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Consultorio Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Nros.Asig.") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Nros.Disp.") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Ult.Nro.Asig.") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Pac Conf") ;
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
               GridColumn.AddObjectProperty("Value", context.convertURL( AV15Update));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", context.convertURL( AV16Display));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavDisplay_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12MedicoId), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A13MedicoNombre));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A14MedicoApellido));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A60TurnoId), 2, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A61TurnoNombre));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A57ConsultorioId), 3, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtConsultorioId_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A66CantNrosAsig), 2, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A65NrosDisponibles), 2, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A67UltimoNroAsig), 2, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A70CantPacConf), 2, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridContainer.AddObjectProperty("Allowselection", "false");
               GridContainer.AddObjectProperty("Allowcollapsing", "false");
               GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 9, 0, ".", "")));
            }
         }
         if ( wbEnd == 24 )
         {
            wbEnd = 0 ;
            nRC_Grid = (short)(nGXsfl_24_idx-1) ;
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
            wb_table1_2_0G2e( true) ;
         }
         else
         {
            wb_table1_2_0G2e( false) ;
         }
      }

      protected void wb_table2_8_0G2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblFiltertextconsultorioid_Internalname, 1, 1, 0, "Id", "", "", "", 0, lblFiltertextconsultorioid_Jsonclick, "", StyleString, ClassString, "HLP_WWGestionConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'',false,'" + sGXsfl_24_idx + "',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtavConsultorioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13ConsultorioId), 3, 0, ",", "")), "", 3, "chr", 1, "row", 3, 1, 1, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(AV13ConsultorioId), "ZZ9"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(13);\"", 0, edtavConsultorioid_Jsonclick, "", 0, 1, -1, true, "right", "HLP_WWGestionConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblFiltertextconsultafecha_Internalname, 1, 1, 0, "consulta fecha", "", "", "", 0, lblFiltertextconsultafecha_Jsonclick, "", StyleString, ClassString, "HLP_WWGestionConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'" + sGXsfl_24_idx + "',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            if ( ( 1 == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlText( "<table id=\""+edtavConsultafecha_Internalname+"_dp_container\" cellpadding=\"0\" cellspacing=\"0\"><tr><td>") ;
            }
            GxWebStd.gx_single_line_edit( context, edtavConsultafecha_Internalname, context.localUtil.Format(AV14ConsultaFecha, "99/99/99"), "", 8, "chr", 1, "row", 8, 1, 1, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( AV14ConsultaFecha, "99/99/99"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(18);\"", 0, edtavConsultafecha_Jsonclick, "", 0, 1, -1, true, "right", "HLP_WWGestionConsulta.htm");
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
            ClassString = "Separator" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTableseparator_Internalname, 1, 1, 0, " ", "", "", "", 0, lblTableseparator_Jsonclick, "", StyleString, ClassString, "HLP_WWGestionConsulta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_8_0G2e( true) ;
         }
         else
         {
            wb_table2_8_0G2e( false) ;
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
         PA0G2( ) ;
         WS0G2( ) ;
         WE0G2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( Form.Jscriptsrc.Item(idxLst)), "?5521030");
            idxLst = (int)(idxLst+1) ;
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.spa.js", "?34981");
            context.AddJavascriptSource("wwgestionconsulta.js", "?5521031");
         }
         /* End function include_jscripts */
      }

      protected void sendrow_242( )
      {
         WB0G0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_24_idx <= subGrid_Recordsperpage( ) * 1 ) )
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
               if ( ((int)(nGXsfl_24_idx) % (2)) == 0 )
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
            GridRow.AddColumnProperties("bitmap", 2, isAjaxCallMode( ), new Object[] {(String)edtavUpdate_Internalname,(String)"",(String)AV15Update,(String)"GeneXusX",(short)-1,(short)1,(String)"",(String)edtavUpdate_Tooltiptext,(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"",(short)0,(short)0,(String)edtavUpdate_Link,(String)"",(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"",(String)"",(String)"''",(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image" ;
            StyleString = "" ;
            GridRow.AddColumnProperties("bitmap", 2, isAjaxCallMode( ), new Object[] {(String)edtavDisplay_Internalname,(String)"",(String)AV16Display,(String)"GeneXusX",(short)-1,(short)1,(String)"",(String)edtavDisplay_Tooltiptext,(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"",(short)0,(short)0,(String)edtavDisplay_Link,(String)"",(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"",(String)"",(String)"''",(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtConsultaFecha_Internalname,context.localUtil.Format(A43ConsultaFecha, "99/99/99"),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)8,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( A43ConsultaFecha, "99/99/99"),(String)"",(short)0,(String)edtConsultaFecha_Jsonclick,(String)"",(short)24,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMedicoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12MedicoId), 6, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)6,(short)0,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A12MedicoId), "ZZZZZ9"),(String)"",(short)0,(String)edtMedicoId_Jsonclick,(String)"",(short)24,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMedicoNombre_Internalname,StringUtil.RTrim( A13MedicoNombre),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A13MedicoNombre, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtMedicoNombre_Jsonclick,(String)"",(short)24,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMedicoApellido_Internalname,StringUtil.RTrim( A14MedicoApellido),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A14MedicoApellido, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtMedicoApellido_Jsonclick,(String)"",(short)24,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTurnoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A60TurnoId), 2, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)2,(short)0,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A60TurnoId), "Z9"),(String)"",(short)0,(String)edtTurnoId_Jsonclick,(String)"",(short)24,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTurnoNombre_Internalname,StringUtil.RTrim( A61TurnoNombre),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A61TurnoNombre, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtTurnoNombre_Jsonclick,(String)"",(short)24,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtConsultorioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A57ConsultorioId), 3, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)3,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)edtConsultorioId_Link,(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A57ConsultorioId), "ZZ9"),(String)"",(short)0,(String)edtConsultorioId_Jsonclick,(String)"",(short)24,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtCantNrosAsig_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A66CantNrosAsig), 2, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)2,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A66CantNrosAsig), "Z9"),(String)"",(short)0,(String)edtCantNrosAsig_Jsonclick,(String)"",(short)24,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtNrosDisponibles_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A65NrosDisponibles), 2, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)2,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A65NrosDisponibles), "Z9"),(String)"",(short)0,(String)edtNrosDisponibles_Jsonclick,(String)"",(short)24,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtUltimoNroAsig_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A67UltimoNroAsig), 2, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)2,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A67UltimoNroAsig), "Z9"),(String)"",(short)0,(String)edtUltimoNroAsig_Jsonclick,(String)"",(short)24,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtCantPacConf_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A70CantPacConf), 2, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)2,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A70CantPacConf), "Z9"),(String)"",(short)0,(String)edtCantPacConf_Jsonclick,(String)"",(short)24,(short)1,(short)1,(bool)true,(String)"right"});
            GridContainer.AddRow(GridRow);
            nGXsfl_24_idx = (short)(((subGrid_Islastpage==1)&&(nGXsfl_24_idx+1>subGrid_Recordsperpage( )) ? 1 : nGXsfl_24_idx+1)) ;
            sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_24_idx), 4, 0)), 4, "0") ;
            edtavUpdate_Internalname = "_UPDATE_"+sGXsfl_24_idx ;
            edtavDisplay_Internalname = "_DISPLAY_"+sGXsfl_24_idx ;
            edtConsultaFecha_Internalname = "CONSULTAFECHA_"+sGXsfl_24_idx ;
            edtMedicoId_Internalname = "MEDICOID_"+sGXsfl_24_idx ;
            edtMedicoNombre_Internalname = "MEDICONOMBRE_"+sGXsfl_24_idx ;
            edtMedicoApellido_Internalname = "MEDICOAPELLIDO_"+sGXsfl_24_idx ;
            edtTurnoId_Internalname = "TURNOID_"+sGXsfl_24_idx ;
            edtTurnoNombre_Internalname = "TURNONOMBRE_"+sGXsfl_24_idx ;
            edtConsultorioId_Internalname = "CONSULTORIOID_"+sGXsfl_24_idx ;
            edtCantNrosAsig_Internalname = "CANTNROSASIG_"+sGXsfl_24_idx ;
            edtNrosDisponibles_Internalname = "NROSDISPONIBLES_"+sGXsfl_24_idx ;
            edtUltimoNroAsig_Internalname = "ULTIMONROASIG_"+sGXsfl_24_idx ;
            edtCantPacConf_Internalname = "CANTPACCONF_"+sGXsfl_24_idx ;
         }
         /* End function sendrow_242 */
      }

      public override void initialize_properties( )
      {
         lblTitletext_Internalname = "TITLETEXT" ;
         lblFiltertextconsultorioid_Internalname = "FILTERTEXTCONSULTORIOID" ;
         edtavConsultorioid_Internalname = "_CONSULTORIOID" ;
         lblFiltertextconsultafecha_Internalname = "FILTERTEXTCONSULTAFECHA" ;
         edtavConsultafecha_Internalname = "_CONSULTAFECHA" ;
         lblTableseparator_Internalname = "TABLESEPARATOR" ;
         tblTablesearch_Internalname = "TABLESEARCH" ;
         tblTable_Internalname = "TABLE" ;
         Form.Internalname = "FORM" ;
         subGrid_Internalname = "GRID" ;
         edtCantPacConf_Jsonclick = "" ;
         edtUltimoNroAsig_Jsonclick = "" ;
         edtNrosDisponibles_Jsonclick = "" ;
         edtCantNrosAsig_Jsonclick = "" ;
         edtConsultorioId_Jsonclick = "" ;
         edtTurnoNombre_Jsonclick = "" ;
         edtTurnoId_Jsonclick = "" ;
         edtMedicoApellido_Jsonclick = "" ;
         edtMedicoNombre_Jsonclick = "" ;
         edtMedicoId_Jsonclick = "" ;
         edtConsultaFecha_Jsonclick = "" ;
         edtavConsultafecha_Jsonclick = "" ;
         edtavConsultorioid_Jsonclick = "" ;
         subGrid_Class = "WorkWith" ;
         subGrid_Backcolorstyle = 3 ;
         edtConsultorioId_Link = "" ;
         edtavDisplay_Link = "" ;
         edtavUpdate_Link = "" ;
         subGrid_Rows = 0 ;
         Form.Headerrawhtml = "" ;
         Form.Background = "" ;
         Form.Backcolor = (int)(0xFFFFFF) ;
         Form.Caption = "Work With Gestion Consulta" ;
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
         AV16Display = "" ;
         edtavUpdate_Internalname = "" ;
         AV15Update = "" ;
         AV19Pgmname = "" ;
         AV14ConsultaFecha = DateTime.MinValue ;
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
         edtMedicoId_Internalname = "" ;
         edtMedicoNombre_Internalname = "" ;
         edtMedicoApellido_Internalname = "" ;
         edtTurnoId_Internalname = "" ;
         edtTurnoNombre_Internalname = "" ;
         edtConsultorioId_Internalname = "" ;
         edtCantNrosAsig_Internalname = "" ;
         edtNrosDisponibles_Internalname = "" ;
         edtUltimoNroAsig_Internalname = "" ;
         edtCantPacConf_Internalname = "" ;
         A43ConsultaFecha = DateTime.MinValue ;
         A13MedicoNombre = "" ;
         A14MedicoApellido = "" ;
         A61TurnoNombre = "" ;
         GridContainer = new GXWebGrid( context);
         scmdbuf = "" ;
         H000G6_A67UltimoNroAsig = new short[1] ;
         H000G6_n67UltimoNroAsig = new bool[] {false} ;
         H000G6_A57ConsultorioId = new short[1] ;
         H000G6_A61TurnoNombre = new String[] {""} ;
         H000G6_A60TurnoId = new short[1] ;
         H000G6_A14MedicoApellido = new String[] {""} ;
         H000G6_A13MedicoNombre = new String[] {""} ;
         H000G6_A12MedicoId = new int[1] ;
         H000G6_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         H000G6_A70CantPacConf = new short[1] ;
         H000G6_n70CantPacConf = new bool[] {false} ;
         H000G6_A65NrosDisponibles = new short[1] ;
         H000G6_n65NrosDisponibles = new bool[] {false} ;
         H000G6_A66CantNrosAsig = new short[1] ;
         H000G6_n66CantNrosAsig = new bool[] {false} ;
         H000G11_AGRID_nRecordCount = new int[1] ;
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
         GridColumn = new GXWebColumn();
         lblFiltertextconsultorioid_Jsonclick = "" ;
         TempTags = "" ;
         lblFiltertextconsultafecha_Jsonclick = "" ;
         GXt_char13 = "" ;
         lblTableseparator_Jsonclick = "" ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         GridRow = new GXWebRow();
         ROClassString = "" ;
         GXt_char14 = "" ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwgestionconsulta__default(),
            new Object[][] {
                new Object[] {
               H000G6_A67UltimoNroAsig, H000G6_n67UltimoNroAsig, H000G6_A57ConsultorioId, H000G6_A61TurnoNombre, H000G6_A60TurnoId, H000G6_A14MedicoApellido, H000G6_A13MedicoNombre, H000G6_A12MedicoId, H000G6_A43ConsultaFecha, H000G6_A70CantPacConf,
               H000G6_n70CantPacConf, H000G6_A65NrosDisponibles, H000G6_n65NrosDisponibles, H000G6_A66CantNrosAsig, H000G6_n66CantNrosAsig
               }
               , new Object[] {
               H000G11_AGRID_nRecordCount
               }
            }
         );
         AV19Pgmname = "WWGestionConsulta" ;
         /* GeneXus formulas. */
         AV19Pgmname = "WWGestionConsulta" ;
         context.Gx_err = 0 ;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nRC_Grid ;
      private short nGXsfl_24_idx=1 ;
      private short AV13ConsultorioId ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short GRID_nEOF ;
      private short subGrid_Rows ;
      private short wbEnd ;
      private short wbStart ;
      private short A60TurnoId ;
      private short A57ConsultorioId ;
      private short A66CantNrosAsig ;
      private short A65NrosDisponibles ;
      private short A67UltimoNroAsig ;
      private short A70CantPacConf ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Collapsed ;
      private short subGrid_Backstyle ;
      private int Grid_PageSize24 ;
      private int GRID_nFirstRecordOnPage ;
      private int A12MedicoId ;
      private int subGrid_Islastpage ;
      private int GRID_nCurrentRecord ;
      private int GRID_nRecordCount ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_24_idx="0001" ;
      private String edtavDisplay_Tooltiptext ;
      private String edtavDisplay_Internalname ;
      private String edtavUpdate_Tooltiptext ;
      private String edtavUpdate_Internalname ;
      private String AV19Pgmname ;
      private String sDynURL ;
      private String FormProcess ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtConsultaFecha_Internalname ;
      private String edtMedicoId_Internalname ;
      private String edtMedicoNombre_Internalname ;
      private String edtMedicoApellido_Internalname ;
      private String edtTurnoId_Internalname ;
      private String edtTurnoNombre_Internalname ;
      private String edtConsultorioId_Internalname ;
      private String edtCantNrosAsig_Internalname ;
      private String edtNrosDisponibles_Internalname ;
      private String edtUltimoNroAsig_Internalname ;
      private String edtCantPacConf_Internalname ;
      private String A13MedicoNombre ;
      private String A14MedicoApellido ;
      private String A61TurnoNombre ;
      private String edtavConsultorioid_Internalname ;
      private String scmdbuf ;
      private String edtavConsultafecha_Internalname ;
      private String edtavUpdate_Link ;
      private String edtavDisplay_Link ;
      private String edtConsultorioId_Link ;
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
      private String tblTablesearch_Internalname ;
      private String lblFiltertextconsultorioid_Internalname ;
      private String lblFiltertextconsultorioid_Jsonclick ;
      private String TempTags ;
      private String edtavConsultorioid_Jsonclick ;
      private String lblFiltertextconsultafecha_Internalname ;
      private String lblFiltertextconsultafecha_Jsonclick ;
      private String GXt_char13 ;
      private String edtavConsultafecha_Jsonclick ;
      private String lblTableseparator_Internalname ;
      private String lblTableseparator_Jsonclick ;
      private String ROClassString ;
      private String edtConsultaFecha_Jsonclick ;
      private String edtMedicoId_Jsonclick ;
      private String edtMedicoNombre_Jsonclick ;
      private String edtMedicoApellido_Jsonclick ;
      private String edtTurnoId_Jsonclick ;
      private String edtTurnoNombre_Jsonclick ;
      private String edtConsultorioId_Jsonclick ;
      private String edtCantNrosAsig_Jsonclick ;
      private String edtNrosDisponibles_Jsonclick ;
      private String edtUltimoNroAsig_Jsonclick ;
      private String edtCantPacConf_Jsonclick ;
      private String GXt_char14 ;
      private DateTime AV14ConsultaFecha ;
      private DateTime A43ConsultaFecha ;
      private bool entryPointCalled ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n66CantNrosAsig ;
      private bool n65NrosDisponibles ;
      private bool n67UltimoNroAsig ;
      private bool n70CantPacConf ;
      private bool returnInSub ;
      private bool AV5IsAuthorized ;
      private String AV16Display ;
      private String AV15Update ;
      private GxWebSession AV7Session ;
      private GXMasterPage MasterPageObj ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H000G6_A67UltimoNroAsig ;
      private bool[] H000G6_n67UltimoNroAsig ;
      private short[] H000G6_A57ConsultorioId ;
      private String[] H000G6_A61TurnoNombre ;
      private short[] H000G6_A60TurnoId ;
      private String[] H000G6_A14MedicoApellido ;
      private String[] H000G6_A13MedicoNombre ;
      private int[] H000G6_A12MedicoId ;
      private DateTime[] H000G6_A43ConsultaFecha ;
      private short[] H000G6_A70CantPacConf ;
      private bool[] H000G6_n70CantPacConf ;
      private short[] H000G6_A65NrosDisponibles ;
      private bool[] H000G6_n65NrosDisponibles ;
      private short[] H000G6_A66CantNrosAsig ;
      private bool[] H000G6_n66CantNrosAsig ;
      private int[] H000G11_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private SdtGridState AV9GridState ;
      private SdtGridState_FilterValue AV10GridStateFilterValue ;
      private SdtTransactionContext AV11TrnContext ;
   }

   public class wwgestionconsulta__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000G6( short AV13ConsultorioId ,
                                             DateTime AV14ConsultaFecha ,
                                             short A57ConsultorioId ,
                                             DateTime A43ConsultaFecha )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int15 ;
         GXv_int15 = new short [2] ;
         Object[] GXv_Object16 ;
         GXv_Object16 = new Object [2] ;
         scmdbuf = "SELECT T1.[UltimoNroAsig], T1.[ConsultorioId], T2.[TurnoNombre], T1.[TurnoId], T3.[MedicoApellido], T3.[MedicoNombre], T1.[MedicoId], T1.[ConsultaFecha], COALESCE( T4.[CantPacConf], 0) AS CantPacConf, COALESCE( T5.[NrosDisponibles], 0) AS NrosDisponibles, COALESCE( T6.[CantNrosAsig], 0) AS CantNrosAsig FROM ((((([Consulta] T1 WITH (NOLOCK) INNER JOIN [Turno] T2 WITH (NOLOCK) ON T2.[TurnoId] = T1.[TurnoId]) INNER JOIN [Medico] T3 WITH (NOLOCK) ON T3.[MedicoId] = T1.[MedicoId]) LEFT JOIN (SELECT COUNT(*) AS CantPacConf, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) WHERE [Confirmado] = 1 GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T4 ON T4.[ConsultaFecha] = T1.[ConsultaFecha] AND T4.[MedicoId] = T1.[MedicoId] AND T4.[TurnoId] = T1.[TurnoId]) INNER JOIN (SELECT T9.[EspecialidadMaxPacientes] - COALESCE( T10.[CantNrosAsig], 0) AS NrosDisponibles, T7.[ConsultaFecha], T7.[MedicoId], T7.[TurnoId] FROM ((([Consulta] T7 WITH (NOLOCK) INNER JOIN [Medico] T8 WITH (NOLOCK) ON T8.[MedicoId] = T7.[MedicoId]) INNER JOIN [Especialidad] T9 WITH (NOLOCK) ON T9.[EspecialidadId] = T8.[EspecialidadId]) LEFT JOIN (SELECT COUNT(*) AS CantNrosAsig, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T10 ON T10.[ConsultaFecha] = T7.[ConsultaFecha] AND T10.[MedicoId] = T7.[MedicoId] AND T10.[TurnoId] = T7.[TurnoId]) ) T5 ON T5.[ConsultaFecha] = T1.[ConsultaFecha] AND T5.[MedicoId] = T1.[MedicoId] AND T5.[TurnoId] = T1.[TurnoId]) LEFT JOIN (SELECT COUNT(*) AS CantNrosAsig, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T6 ON T6.[ConsultaFecha] = T1.[ConsultaFecha] AND T6.[MedicoId] = T1.[MedicoId] AND T6.[TurnoId]" ;
         scmdbuf = scmdbuf + " = T1.[TurnoId])" ;
         if ( ! (0==AV13ConsultorioId) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (T1.[ConsultorioId] = @AV13ConsultorioId)" ;
            }
            else
            {
               sWhereString = sWhereString + " (T1.[ConsultorioId] = @AV13ConsultorioId)" ;
            }
         }
         else
         {
            GXv_int15[0] = 1 ;
         }
         if ( ! (DateTime.MinValue==AV14ConsultaFecha) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (T1.[ConsultaFecha] = @AV14ConsultaFecha)" ;
            }
            else
            {
               sWhereString = sWhereString + " (T1.[ConsultaFecha] = @AV14ConsultaFecha)" ;
            }
         }
         else
         {
            GXv_int15[1] = 1 ;
         }
         if ( StringUtil.StrCmp("", sWhereString) != 0 )
         {
            scmdbuf = scmdbuf + " WHERE " + sWhereString ;
         }
         scmdbuf = scmdbuf + " ORDER BY T1.[ConsultorioId]" ;
         GXv_Object16[0] = scmdbuf ;
         GXv_Object16[1] = (Object)(GXv_int15) ;
         return GXv_Object16 ;
      }

      protected Object[] conditional_H000G11( short AV13ConsultorioId ,
                                              DateTime AV14ConsultaFecha ,
                                              short A57ConsultorioId ,
                                              DateTime A43ConsultaFecha )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int17 ;
         GXv_int17 = new short [2] ;
         Object[] GXv_Object18 ;
         GXv_Object18 = new Object [2] ;
         scmdbuf = "SELECT COUNT(*) FROM ((((([Consulta] T1 WITH (NOLOCK) INNER JOIN [Turno] T3 WITH (NOLOCK) ON T3.[TurnoId] = T1.[TurnoId]) INNER JOIN [Medico] T2 WITH (NOLOCK) ON T2.[MedicoId] = T1.[MedicoId]) LEFT JOIN (SELECT COUNT(*) AS CantPacConf, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) WHERE [Confirmado] = 1 GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T4 ON T4.[ConsultaFecha] = T1.[ConsultaFecha] AND T4.[MedicoId] = T1.[MedicoId] AND T4.[TurnoId] = T1.[TurnoId]) INNER JOIN (SELECT T9.[EspecialidadMaxPacientes] - COALESCE( T10.[CantNrosAsig], 0) AS NrosDisponibles, T7.[ConsultaFecha], T7.[MedicoId], T7.[TurnoId] FROM ((([Consulta] T7 WITH (NOLOCK) INNER JOIN [Medico] T8 WITH (NOLOCK) ON T8.[MedicoId] = T7.[MedicoId]) INNER JOIN [Especialidad] T9 WITH (NOLOCK) ON T9.[EspecialidadId] = T8.[EspecialidadId]) LEFT JOIN (SELECT COUNT(*) AS CantNrosAsig, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T10 ON T10.[ConsultaFecha] = T7.[ConsultaFecha] AND T10.[MedicoId] = T7.[MedicoId] AND T10.[TurnoId] = T7.[TurnoId]) ) T5 ON T5.[ConsultaFecha] = T1.[ConsultaFecha] AND T5.[MedicoId] = T1.[MedicoId] AND T5.[TurnoId] = T1.[TurnoId]) LEFT JOIN (SELECT COUNT(*) AS CantNrosAsig, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T6 ON T6.[ConsultaFecha] = T1.[ConsultaFecha] AND T6.[MedicoId] = T1.[MedicoId] AND T6.[TurnoId] = T1.[TurnoId])" ;
         if ( ! (0==AV13ConsultorioId) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (T1.[ConsultorioId] = @AV13ConsultorioId)" ;
            }
            else
            {
               sWhereString = sWhereString + " (T1.[ConsultorioId] = @AV13ConsultorioId)" ;
            }
         }
         else
         {
            GXv_int17[0] = 1 ;
         }
         if ( ! (DateTime.MinValue==AV14ConsultaFecha) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and (T1.[ConsultaFecha] = @AV14ConsultaFecha)" ;
            }
            else
            {
               sWhereString = sWhereString + " (T1.[ConsultaFecha] = @AV14ConsultaFecha)" ;
            }
         }
         else
         {
            GXv_int17[1] = 1 ;
         }
         if ( StringUtil.StrCmp("", sWhereString) != 0 )
         {
            scmdbuf = scmdbuf + " WHERE " + sWhereString ;
         }
         scmdbuf = scmdbuf + "" ;
         GXv_Object18[0] = scmdbuf ;
         GXv_Object18[1] = (Object)(GXv_int17) ;
         return GXv_Object18 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H000G6( (short)dynConstraints[0] , (DateTime)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] );
               case 1 :
                     return conditional_H000G11( (short)dynConstraints[0] , (DateTime)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] );
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
          Object[] prmH000G6 ;
          prmH000G6 = new Object[] {
          new Object[] {"@AV13ConsultorioId",SqlDbType.SmallInt,3,0} ,
          new Object[] {"@AV14ConsultaFecha",SqlDbType.DateTime,8,0}
          } ;
          Object[] prmH000G11 ;
          prmH000G11 = new Object[] {
          new Object[] {"@AV13ConsultorioId",SqlDbType.SmallInt,3,0} ,
          new Object[] {"@AV14ConsultaFecha",SqlDbType.DateTime,8,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H000G6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G6,11,0,true,false )
             ,new CursorDef("H000G11", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G11,1,0,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(2) ;
                ((String[]) buf[3])[0] = rslt.getString(3, 20) ;
                ((short[]) buf[4])[0] = rslt.getShort(4) ;
                ((String[]) buf[5])[0] = rslt.getString(5, 20) ;
                ((String[]) buf[6])[0] = rslt.getString(6, 20) ;
                ((int[]) buf[7])[0] = rslt.getInt(7) ;
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8) ;
                ((short[]) buf[9])[0] = rslt.getShort(9) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((short[]) buf[11])[0] = rslt.getShort(10) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((short[]) buf[13])[0] = rslt.getShort(11) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
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
                   stmt.SetParameter(sIdx, (short)parms[2]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1) ;
                   stmt.SetParameter(sIdx, (DateTime)parms[3]);
                }
                break;
             case 1 :
                sIdx = 0 ;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1) ;
                   stmt.SetParameter(sIdx, (short)parms[2]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1) ;
                   stmt.SetParameter(sIdx, (DateTime)parms[3]);
                }
                break;
       }
    }

 }

}
