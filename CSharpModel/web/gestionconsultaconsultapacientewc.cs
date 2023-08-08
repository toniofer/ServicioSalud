/*
               File: GestionConsultaConsultaPacienteWC
        Description: Gestion Consulta Consulta Paciente WC
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/24/2010 6:11:43.48
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
   public class gestionconsultaconsultapacientewc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public gestionconsultaconsultapacientewc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public gestionconsultaconsultapacientewc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default") ;
      }

      public void release( )
      {
      }

      public void execute( DateTime aP0_ConsultaFecha ,
                           int aP1_MedicoId ,
                           short aP2_TurnoId )
      {
         this.AV7ConsultaFecha = aP0_ConsultaFecha;
         this.AV8MedicoId = aP1_MedicoId;
         this.AV9TurnoId = aP2_TurnoId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( String sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         chkConfirmado = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (String)(sPrefix)) == 0 )
         {
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1 ;
                     return  ;
                  }
                  nDynComponent = 1 ;
                  sCompPrefix = GetNextPar( ) ;
                  sSFPrefix = GetNextPar( ) ;
                  AV7ConsultaFecha = context.localUtil.ParseDateParm( GetNextPar( )) ;
                  AV8MedicoId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  AV9TurnoId = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  componentprepare(new Object[] {(String)sCompPrefix,(String)sSFPrefix,(DateTime)AV7ConsultaFecha,(int)AV8MedicoId,(short)AV9TurnoId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  nGXsfl_12_idx = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  sGXsfl_12_idx = GetNextPar( ) ;
                  edtavDisplay_Tooltiptext = GetNextPar( ) ;
                  context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDisplay_Internalname, "Tooltiptext", edtavDisplay_Tooltiptext);
                  AV16Display = GetNextPar( ) ;
                  context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDisplay_Internalname, "Bitmap", context.convertURL( AV16Display));
                  edtavDelete_Tooltiptext = GetNextPar( ) ;
                  context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext);
                  AV15Delete = GetNextPar( ) ;
                  context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDelete_Internalname, "Bitmap", context.convertURL( AV15Delete));
                  sPrefix = GetNextPar( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1 ;
                     return  ;
                  }
                  gxnrGrid_newrow( nRC_Grid, nGXsfl_12_idx, sGXsfl_12_idx, AV16Display, AV15Delete, sPrefix) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
               {
                  /* GeneXus formulas. */
                  AV19Pgmname = "GestionConsultaConsultaPacienteWC" ;
                  context.Gx_err = 0 ;
                  GXCCtl = "CONFIRMADO_" + sGXsfl_12_idx ;
                  chkConfirmado.Name = GXCCtl ;
                  chkConfirmado.WebTags = "" ;
                  chkConfirmado.Caption = "" ;
                  context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, chkConfirmado_Internalname, "Caption", chkConfirmado.Caption);
                  chkConfirmado.CheckedValue = "false" ;
                  Grid_PageSize12 = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  AV7ConsultaFecha = context.localUtil.ParseDateParm( GetNextPar( )) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "AV7ConsultaFecha", context.localUtil.Format(AV7ConsultaFecha, "99/99/99"));
                  AV8MedicoId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "AV8MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV8MedicoId), 6, 0)));
                  AV9TurnoId = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "AV9TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV9TurnoId), 2, 0)));
                  edtavDisplay_Tooltiptext = GetNextPar( ) ;
                  context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDisplay_Internalname, "Tooltiptext", edtavDisplay_Tooltiptext);
                  AV16Display = GetNextPar( ) ;
                  context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDisplay_Internalname, "Bitmap", context.convertURL( AV16Display));
                  edtavDelete_Tooltiptext = GetNextPar( ) ;
                  context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext);
                  AV15Delete = GetNextPar( ) ;
                  context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDelete_Internalname, "Bitmap", context.convertURL( AV15Delete));
                  A60TurnoId = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
                  A12MedicoId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
                  A43ConsultaFecha = context.localUtil.ParseDateParm( GetNextPar( )) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
                  sPrefix = GetNextPar( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1 ;
                     return  ;
                  }
                  gxgrGrid_refresh( Grid_PageSize12, AV7ConsultaFecha, AV8MedicoId, AV9TurnoId, AV16Display, AV15Delete, A60TurnoId, A12MedicoId, A43ConsultaFecha, sPrefix) ;
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
            PA0I2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV19Pgmname = "GestionConsultaConsultaPacienteWC" ;
               context.Gx_err = 0 ;
               WS0I2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, "IE=EmulateIE7");
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.WriteHtmlText( "<title>") ;
            context.WriteHtmlText( "Gestion Consulta Consulta Paciente WC") ;
            context.WriteHtmlTextNl( "</title>") ;
            if ( StringUtil.Len( sDynURL) > 0 )
            {
               context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
            }
            define_styles( ) ;
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
         }
         context.AddJavascriptSource("calendar.js", "?34981");
         context.AddJavascriptSource("calendar-setup.js", "?34981");
         context.AddJavascriptSource("calendar-es.js", "?34981");
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            FormProcess = ((nGXWrapped==0) ? " onkeyup=\"gx.evt.onkeyup(event)\" onkeypress=\"gx.evt.onkeypress(event,false,false)\" onkeydown=\"gx.evt.onkeypress(null,false,false)\"" : "") ;
            context.WriteHtmlText( "<body") ;
            context.WriteHtmlText( " "+"class=\"Form\""+" "+" style=\"-moz-opacity:0;opacity:0;"+"\""+" bgcolor=\""+context.BuildHTMLColor( (int)(0xFFFFFF))+"\""+FormProcess+">") ;
            context.skipLines(1);
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" onsubmit=\"try{return gx.csv.validForm()}catch(e){return true;}\" name=\"MAINFORM\" method=\"post\" action=\""+formatLink("gestionconsultaconsultapacientewc.aspx") + "?" + UrlEncode(DateTimeUtil.FormatDateParm(AV7ConsultaFecha)) + "," + UrlEncode("" +AV8MedicoId) + "," + UrlEncode("" +AV9TurnoId)+"\" class=\""+"Form"+"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            }
         }
      }

      protected void RenderHtmlCloseForm0I2( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_Grid", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_Grid), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7ConsultaFecha", context.localUtil.DToC( wcpOAV7ConsultaFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8MedicoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8MedicoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV9TurnoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV9TurnoId), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"_CONSULTAFECHA", context.localUtil.DToC( AV7ConsultaFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"_MEDICOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8MedicoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"_TURNOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9TurnoId), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 3, 0, ".", "")));
         if ( ( StringUtil.Len( sPrefix) != 0 ) && context.isAjaxRequest( ) )
         {
            context.AddJavascriptSource("gestionconsultaconsultapacientewc.js", "?6114369");
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
            SendComponentObjects();
            SendServerCommands();
            SendState();
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
            include_jscripts( ) ;
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
         }
      }

      protected void WB0I0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "gestionconsultaconsultapacientewc.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            wb_table1_2_0I2( true) ;
         }
         else
         {
            wb_table1_2_0I2( false) ;
         }
         return  ;
      }

      protected void wb_table1_2_0I2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            if ( ( 0 == 1 ) && ( edtConsultaFecha_Visible == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlText( "<table id=\""+edtConsultaFecha_Internalname+"_dp_container\" cellpadding=\"0\" cellspacing=\"0\"><tr><td>") ;
            }
            GxWebStd.gx_single_line_edit( context, edtConsultaFecha_Internalname, context.localUtil.Format(A43ConsultaFecha, "99/99/99"), "", 8, "chr", 1, "row", 8, edtConsultaFecha_Visible, 0, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( A43ConsultaFecha, "99/99/99"), "", 0, edtConsultaFecha_Jsonclick, "", 0, 1, 1, true, "right", "HLP_GestionConsultaConsultaPacienteWC.htm");
            if ( ( 0 == 1 ) && ( edtConsultaFecha_Visible == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlTextNl( "</td><td>") ;
               context.WriteHtmlText( "<img src=\""+context.convertURL( "calendar-img.gif")+"\" id=\""+edtConsultaFecha_Internalname+"_dp_trigger\" style=\"cursor: pointer;\" title=\"Date selector\" alt=\"Date selector\" >") ;
               context.WriteHtmlTextNl( "</td></tr></table>") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtMedicoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12MedicoId), 6, 0, ",", "")), "", 6, "chr", 1, "row", 6, edtMedicoId_Visible, 0, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A12MedicoId), "ZZZZZ9"), "", 0, edtMedicoId_Jsonclick, "", 0, 1, 1, true, "right", "HLP_GestionConsultaConsultaPacienteWC.htm");
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtTurnoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A60TurnoId), 2, 0, ",", "")), "", 2, "chr", 1, "row", 2, edtTurnoId_Visible, 0, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A60TurnoId), "Z9"), "", 0, edtTurnoId_Jsonclick, "", 0, 1, 1, true, "right", "HLP_GestionConsultaConsultaPacienteWC.htm");
         }
         wbLoad = true ;
      }

      protected void START0I2( )
      {
         wbLoad = false ;
         wbEnd = 0 ;
         wbStart = 0 ;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            Form.Meta.addItem("Generator", "GeneXus C#", 0) ;
            Form.Meta.addItem("Version", "10_1_3-34981", 0) ;
            Form.Meta.addItem("Description", "Gestion Consulta Consulta Paciente WC", 0) ;
            context.wjLoc = "" ;
            context.nUserReturn = 0 ;
            context.wbHandled = 0 ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName") ;
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false ;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP0I0( ) ;
            }
         }
      }

      protected void WS0I2( )
      {
         START0I2( ) ;
         EVT0I2( ) ;
      }

      protected void EVT0I2( )
      {
         sXEvt = cgiGet( "_EventName") ;
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName") ;
                     EvtGridId = cgiGet( "_EventGridId") ;
                     EvtRowId = cgiGet( "_EventRowId") ;
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1) ;
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1)) ;
                     /* Check if conditions changed and reset current page numbers */
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1) ;
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1)) ;
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0I0( ) ;
                              }
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1 ;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0I0( ) ;
                              }
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1 ;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: E110I2 */
                                    E110I2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0I0( ) ;
                              }
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1 ;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1 ;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0I0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDPAGING") ;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'DOINSERT'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0I0( ) ;
                              }
                              nGXsfl_12_idx = (short)(NumberUtil.Val( sEvtType, ".")) ;
                              sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_12_idx), 4, 0)), 4, "0") ;
                              edtavDelete_Internalname = sPrefix+"_DELETE_"+sGXsfl_12_idx ;
                              edtavDisplay_Internalname = sPrefix+"_DISPLAY_"+sGXsfl_12_idx ;
                              edtPacienteId_Internalname = sPrefix+"PACIENTEID_"+sGXsfl_12_idx ;
                              edtPacienteApellido_Internalname = sPrefix+"PACIENTEAPELLIDO_"+sGXsfl_12_idx ;
                              edtPacienteNombre_Internalname = sPrefix+"PACIENTENOMBRE_"+sGXsfl_12_idx ;
                              edtPacienteCI_Internalname = sPrefix+"PACIENTECI_"+sGXsfl_12_idx ;
                              edtEspecialidadMaxPacientes_Internalname = sPrefix+"ESPECIALIDADMAXPACIENTES_"+sGXsfl_12_idx ;
                              edtConsultaNro_Internalname = sPrefix+"CONSULTANRO_"+sGXsfl_12_idx ;
                              chkConfirmado_Internalname = sPrefix+"CONFIRMADO_"+sGXsfl_12_idx ;
                              AV15Delete = cgiGet( "GXimg"+edtavDelete_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDelete_Internalname, "Bitmap", context.convertURL( AV15Delete));
                              AV16Display = cgiGet( "GXimg"+edtavDisplay_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDisplay_Internalname, "Bitmap", context.convertURL( AV16Display));
                              A34PacienteId = (int)(context.localUtil.CToN( cgiGet( edtPacienteId_Internalname), ",", ".")) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
                              A36PacienteApellido = cgiGet( edtPacienteApellido_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A36PacienteApellido", A36PacienteApellido);
                              A35PacienteNombre = cgiGet( edtPacienteNombre_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A35PacienteNombre", A35PacienteNombre);
                              A41PacienteCI = cgiGet( edtPacienteCI_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A41PacienteCI", A41PacienteCI);
                              A11EspecialidadMaxPacientes = (short)(context.localUtil.CToN( cgiGet( edtEspecialidadMaxPacientes_Internalname), ",", ".")) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
                              A63ConsultaNro = (short)(context.localUtil.CToN( cgiGet( edtConsultaNro_Internalname), ",", ".")) ;
                              n63ConsultaNro = false ;
                              context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A63ConsultaNro", StringUtil.LTrim( StringUtil.Str( (decimal)(A63ConsultaNro), 2, 0)));
                              A75Confirmado = StringUtil.StrToBool( cgiGet( chkConfirmado_Internalname)) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A75Confirmado", StringUtil.BoolToStr( A75Confirmado));
                              sEvtType = StringUtil.Right( sEvt, 1) ;
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1)) ;
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1 ;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: E120I2 */
                                          E120I2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1 ;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: E130I2 */
                                          E130I2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                                 {
                                    if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1 ;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: E110I2 */
                                          E110I2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1 ;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false ;
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                          }
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CANCEL") == 0 )
                                 {
                                    if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1 ;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP0I0( ) ;
                                    }
                                    if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1 ;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                       }
                                    }
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

      protected void WE0I2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true ;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0I2( ) ;
            }
         }
      }

      protected void PA0I2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXCCtl = "CONFIRMADO_" + sGXsfl_12_idx ;
            chkConfirmado.Name = GXCCtl ;
            chkConfirmado.WebTags = "" ;
            chkConfirmado.Caption = "" ;
            context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, chkConfirmado_Internalname, "Caption", chkConfirmado.Caption);
            chkConfirmado.CheckedValue = "false" ;
            nDonePA = 1 ;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( short nRC_Grid ,
                                      short nGXsfl_12_idx ,
                                      String sGXsfl_12_idx ,
                                      String AV16Display ,
                                      String AV15Delete ,
                                      String sPrefix )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         edtavDelete_Internalname = sPrefix+"_DELETE_"+sGXsfl_12_idx ;
         edtavDisplay_Internalname = sPrefix+"_DISPLAY_"+sGXsfl_12_idx ;
         edtPacienteId_Internalname = sPrefix+"PACIENTEID_"+sGXsfl_12_idx ;
         edtPacienteApellido_Internalname = sPrefix+"PACIENTEAPELLIDO_"+sGXsfl_12_idx ;
         edtPacienteNombre_Internalname = sPrefix+"PACIENTENOMBRE_"+sGXsfl_12_idx ;
         edtPacienteCI_Internalname = sPrefix+"PACIENTECI_"+sGXsfl_12_idx ;
         edtEspecialidadMaxPacientes_Internalname = sPrefix+"ESPECIALIDADMAXPACIENTES_"+sGXsfl_12_idx ;
         edtConsultaNro_Internalname = sPrefix+"CONSULTANRO_"+sGXsfl_12_idx ;
         chkConfirmado_Internalname = sPrefix+"CONFIRMADO_"+sGXsfl_12_idx ;
         while ( nGXsfl_12_idx <= nRC_Grid )
         {
            sendrow_122( ) ;
            nGXsfl_12_idx = (short)(((subGrid_Islastpage==1)&&(nGXsfl_12_idx+1>subGrid_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1)) ;
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_12_idx), 4, 0)), 4, "0") ;
            edtavDelete_Internalname = sPrefix+"_DELETE_"+sGXsfl_12_idx ;
            edtavDisplay_Internalname = sPrefix+"_DISPLAY_"+sGXsfl_12_idx ;
            edtPacienteId_Internalname = sPrefix+"PACIENTEID_"+sGXsfl_12_idx ;
            edtPacienteApellido_Internalname = sPrefix+"PACIENTEAPELLIDO_"+sGXsfl_12_idx ;
            edtPacienteNombre_Internalname = sPrefix+"PACIENTENOMBRE_"+sGXsfl_12_idx ;
            edtPacienteCI_Internalname = sPrefix+"PACIENTECI_"+sGXsfl_12_idx ;
            edtEspecialidadMaxPacientes_Internalname = sPrefix+"ESPECIALIDADMAXPACIENTES_"+sGXsfl_12_idx ;
            edtConsultaNro_Internalname = sPrefix+"CONSULTANRO_"+sGXsfl_12_idx ;
            chkConfirmado_Internalname = sPrefix+"CONFIRMADO_"+sGXsfl_12_idx ;
         }
         context.GX_webresponse.AddString(GridContainer.ToJavascriptSource());
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int Grid_PageSize12 ,
                                       DateTime AV7ConsultaFecha ,
                                       int AV8MedicoId ,
                                       short AV9TurnoId ,
                                       String AV16Display ,
                                       String AV15Delete ,
                                       short A60TurnoId ,
                                       int A12MedicoId ,
                                       DateTime A43ConsultaFecha ,
                                       String sPrefix )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         disableOutput();
         subGrid_Rows = (short)(Grid_PageSize12) ;
         RF0I2( ) ;
         enableOutput();
         context.GX_webresponse.AddString(GridContainer.ToJavascriptSource());
         /* End function gxgrGrid_refresh */
      }

      protected void Refresh( )
      {
         RF0I2( ) ;
         /* End function Refresh */
      }

      protected void RF0I2( )
      {
         GridContainer.PageSize = subGrid_Recordsperpage( ) ;
         wbStart = 12 ;
         nGXsfl_12_idx = 1 ;
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_12_idx), 4, 0)), 4, "0") ;
         edtavDelete_Internalname = sPrefix+"_DELETE_"+sGXsfl_12_idx ;
         edtavDisplay_Internalname = sPrefix+"_DISPLAY_"+sGXsfl_12_idx ;
         edtPacienteId_Internalname = sPrefix+"PACIENTEID_"+sGXsfl_12_idx ;
         edtPacienteApellido_Internalname = sPrefix+"PACIENTEAPELLIDO_"+sGXsfl_12_idx ;
         edtPacienteNombre_Internalname = sPrefix+"PACIENTENOMBRE_"+sGXsfl_12_idx ;
         edtPacienteCI_Internalname = sPrefix+"PACIENTECI_"+sGXsfl_12_idx ;
         edtEspecialidadMaxPacientes_Internalname = sPrefix+"ESPECIALIDADMAXPACIENTES_"+sGXsfl_12_idx ;
         edtConsultaNro_Internalname = sPrefix+"CONSULTANRO_"+sGXsfl_12_idx ;
         chkConfirmado_Internalname = sPrefix+"CONFIRMADO_"+sGXsfl_12_idx ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H000I2 */
            pr_default.execute(0, new Object[] {AV7ConsultaFecha, AV8MedicoId, AV9TurnoId});
            nGXsfl_12_idx = 1 ;
            GRID_nEOF = 0 ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_Recordsperpage( ) ) ) ) )
            {
               A9EspecialidadId = H000I2_A9EspecialidadId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
               A43ConsultaFecha = H000I2_A43ConsultaFecha[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
               A12MedicoId = H000I2_A12MedicoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
               A60TurnoId = H000I2_A60TurnoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
               A75Confirmado = H000I2_A75Confirmado[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A75Confirmado", StringUtil.BoolToStr( A75Confirmado));
               A63ConsultaNro = H000I2_A63ConsultaNro[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A63ConsultaNro", StringUtil.LTrim( StringUtil.Str( (decimal)(A63ConsultaNro), 2, 0)));
               n63ConsultaNro = H000I2_n63ConsultaNro[0] ;
               A11EspecialidadMaxPacientes = H000I2_A11EspecialidadMaxPacientes[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
               A41PacienteCI = H000I2_A41PacienteCI[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A41PacienteCI", A41PacienteCI);
               A35PacienteNombre = H000I2_A35PacienteNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A35PacienteNombre", A35PacienteNombre);
               A36PacienteApellido = H000I2_A36PacienteApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A36PacienteApellido", A36PacienteApellido);
               A34PacienteId = H000I2_A34PacienteId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
               A9EspecialidadId = H000I2_A9EspecialidadId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
               A11EspecialidadMaxPacientes = H000I2_A11EspecialidadMaxPacientes[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
               A41PacienteCI = H000I2_A41PacienteCI[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A41PacienteCI", A41PacienteCI);
               A35PacienteNombre = H000I2_A35PacienteNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A35PacienteNombre", A35PacienteNombre);
               A36PacienteApellido = H000I2_A36PacienteApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A36PacienteApellido", A36PacienteApellido);
               /* Execute user event: E130I2 */
               E130I2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0)) ;
            pr_default.close(0);
            wbEnd = 12 ;
            WB0I0( ) ;
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
         /* Using cursor H000I3 */
         pr_default.execute(1, new Object[] {AV7ConsultaFecha, AV8MedicoId, AV9TurnoId});
         GRID_nRecordCount = H000I3_AGRID_nRecordCount[0] ;
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

      protected void STRUP0I0( )
      {
         /* Before Start, stand alone formulas. */
         AV19Pgmname = "GestionConsultaConsultaPacienteWC" ;
         context.Gx_err = 0 ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0 ;
         /* Execute user event: E120I2 */
         E120I2 ();
         context.wbGlbDoneStart = 1 ;
         nDoneStart = 1 ;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName") ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read variables values. */
            A43ConsultaFecha = context.localUtil.CToD( cgiGet( edtConsultaFecha_Internalname), 2) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            A12MedicoId = (int)(context.localUtil.CToN( cgiGet( edtMedicoId_Internalname), ",", ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            A60TurnoId = (short)(context.localUtil.CToN( cgiGet( edtTurnoId_Internalname), ",", ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
            /* Read saved values. */
            nRC_Grid = (short)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_Grid"), ",", ".")) ;
            wcpOAV7ConsultaFecha = context.localUtil.CToD( cgiGet( sPrefix+"wcpOAV7ConsultaFecha"), 0) ;
            wcpOAV8MedicoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8MedicoId"), ",", ".")) ;
            wcpOAV9TurnoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV9TurnoId"), ",", ".")) ;
            GRID_nFirstRecordOnPage = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", ".")) ;
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", ".")) ;
            subGrid_Rows = (short)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", ".")) ;
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
         /* Execute user event: E120I2 */
         E120I2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E120I2( )
      {
         /* Start Routine */
         new isauthorized(context ).execute(  AV19Pgmname, out  AV5IsAuthorized) ;
         if ( ! AV5IsAuthorized )
         {
            context.wjLoc = formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV19Pgmname)) ;
         }
         subGrid_Rows = 10 ;
         AV15Delete = context.GetImagePath( "7695fe89-52c9-4b7e-871e-0e11548f823e", "", "GeneXusX") ;
         context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDelete_Internalname, "Bitmap", context.convertURL( AV15Delete));
         edtavDelete_Tooltiptext = "Eliminar" ;
         context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext);
         AV16Display = context.GetImagePath( "f11923b6-6acd-4a79-bfc0-0cfc6f3bced5", "", "GeneXusX") ;
         context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDisplay_Internalname, "Bitmap", context.convertURL( AV16Display));
         edtavDisplay_Tooltiptext = "Visualizar" ;
         context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDisplay_Internalname, "Tooltiptext", edtavDisplay_Tooltiptext);
         edtConsultaFecha_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtConsultaFecha_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(edtConsultaFecha_Visible), 5, 0)));
         edtMedicoId_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtMedicoId_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(edtMedicoId_Visible), 5, 0)));
         edtTurnoId_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtTurnoId_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(edtTurnoId_Visible), 5, 0)));
         /* Execute user subroutine: S112 */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      private void E130I2( )
      {
         /* Grid_Load Routine */
         edtavDelete_Link = formatLink("consultapaciente.aspx") + "?" + UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(DateTimeUtil.FormatDateParm(A43ConsultaFecha)) + "," + UrlEncode("" +A34PacienteId) + "," + UrlEncode("" +A12MedicoId) + "," + UrlEncode("" +A60TurnoId) ;
         context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDelete_Internalname, "Link", edtavDelete_Link);
         edtavDisplay_Link = formatLink("consultapaciente.aspx") + "?" + UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(DateTimeUtil.FormatDateParm(A43ConsultaFecha)) + "," + UrlEncode("" +A34PacienteId) + "," + UrlEncode("" +A12MedicoId) + "," + UrlEncode("" +A60TurnoId) ;
         context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDisplay_Internalname, "Link", edtavDisplay_Link);
         edtPacienteCI_Link = formatLink("viewconsultapaciente.aspx") + "?" + UrlEncode(DateTimeUtil.FormatDateParm(A43ConsultaFecha)) + "," + UrlEncode("" +A34PacienteId) + "," + UrlEncode("" +A12MedicoId) + "," + UrlEncode("" +A60TurnoId) + "," + UrlEncode(StringUtil.RTrim("")) ;
         context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtPacienteCI_Internalname, "Link", edtPacienteCI_Link);
         edtConsultaNro_Link = formatLink("viewhistoriaclinica.aspx") + "?" + UrlEncode(DateTimeUtil.FormatDateParm(A43ConsultaFecha)) + "," + UrlEncode("" +A34PacienteId) + "," + UrlEncode("" +A12MedicoId) + "," + UrlEncode("" +A60TurnoId) + "," + UrlEncode(StringUtil.RTrim("")) ;
         context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtConsultaNro_Internalname, "Link", edtConsultaNro_Link);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12 ;
         }
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_Recordsperpage( ) ) ) )
         {
            sendrow_122( ) ;
         }
         GRID_nCurrentRecord = (int)(GRID_nCurrentRecord+1) ;
      }

      protected void E110I2( )
      {
         /* 'DoInsert' Routine */
         context.wjLoc = formatLink("consultapaciente.aspx") + "?" + UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV7ConsultaFecha)) + "," + UrlEncode("" +0) + "," + UrlEncode("" +AV8MedicoId) + "," + UrlEncode("" +AV9TurnoId) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         AV12TrnContext = new SdtTransactionContext(context) ;
         AV12TrnContext.gxTpr_Callerobject = AV19Pgmname ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12TrnContext", (Object)(AV12TrnContext));
         AV12TrnContext.gxTpr_Callerondelete = true ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12TrnContext", (Object)(AV12TrnContext));
         AV12TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12TrnContext", (Object)(AV12TrnContext));
         AV12TrnContext.gxTpr_Transactionname = "ConsultaPaciente" ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12TrnContext", (Object)(AV12TrnContext));
         AV13TrnContextAtt = new SdtTransactionContext_Attribute(context) ;
         AV13TrnContextAtt.gxTpr_Attributename = "ConsultaFecha" ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13TrnContextAtt", (Object)(AV13TrnContextAtt));
         AV13TrnContextAtt.gxTpr_Attributevalue = context.localUtil.DToC( AV7ConsultaFecha, 2, "/") ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13TrnContextAtt", (Object)(AV13TrnContextAtt));
         AV12TrnContext.gxTpr_Attributes.Add(AV13TrnContextAtt, 0);
         AV13TrnContextAtt = new SdtTransactionContext_Attribute(context) ;
         AV13TrnContextAtt.gxTpr_Attributename = "MedicoId" ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13TrnContextAtt", (Object)(AV13TrnContextAtt));
         AV13TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV8MedicoId), 6, 0) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13TrnContextAtt", (Object)(AV13TrnContextAtt));
         AV12TrnContext.gxTpr_Attributes.Add(AV13TrnContextAtt, 0);
         AV13TrnContextAtt = new SdtTransactionContext_Attribute(context) ;
         AV13TrnContextAtt.gxTpr_Attributename = "TurnoId" ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13TrnContextAtt", (Object)(AV13TrnContextAtt));
         AV13TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV9TurnoId), 2, 0) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13TrnContextAtt", (Object)(AV13TrnContextAtt));
         AV12TrnContext.gxTpr_Attributes.Add(AV13TrnContextAtt, 0);
         AV10Session.Set("TrnContext", AV12TrnContext.ToXml(false, "TransactionContext", "taller041"));
      }

      protected void wb_table1_2_0I2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTable_Internalname, tblTable_Internalname, "", "ViewTable", 0, "", "", 0, 0, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_5_0I2( true) ;
         }
         else
         {
            wb_table2_5_0I2( false) ;
         }
         return  ;
      }

      protected void wb_table2_5_0I2e( bool wbgen )
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
            wb_table1_2_0I2e( true) ;
         }
         else
         {
            wb_table1_2_0I2e( false) ;
         }
      }

      protected void wb_table2_5_0I2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'" + sPrefix + "',false,'',0)\"" ;
            ClassString = "PagingButtons" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgInsert_Internalname, "", context.GetImagePath( "5649fbb8-8ce0-4810-a5ce-bd649ea83c3a", "", "GeneXusX"), "GeneXusX", 1, 1, "", "Agrega", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgInsert_Jsonclick, sPrefix+"E\\'DOINSERT\\'.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_GestionConsultaConsultaPacienteWC.htm");
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
               context.SendWebValue( "Especialidad Max Pacientes") ;
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
               GridContainer.AddObjectProperty("CmpContext", sPrefix);
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", context.convertURL( AV15Delete));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavDelete_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", context.convertURL( AV16Display));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavDisplay_Tooltiptext));
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11EspecialidadMaxPacientes), 3, 0, ".", "")));
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
         if ( wbEnd == 12 )
         {
            wbEnd = 0 ;
            nRC_Grid = (short)(nGXsfl_12_idx-1) ;
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
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", (Object)(GridContainer));
               GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               if ( context.isAjaxRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'>") ;
               }
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_5_0I2e( true) ;
         }
         else
         {
            wb_table2_5_0I2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7ConsultaFecha = (DateTime)getParm(obj,0) ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "AV7ConsultaFecha", context.localUtil.Format(AV7ConsultaFecha, "99/99/99"));
         AV8MedicoId = Convert.ToInt32(getParm(obj,1)) ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "AV8MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV8MedicoId), 6, 0)));
         AV9TurnoId = Convert.ToInt16(getParm(obj,2)) ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "AV9TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV9TurnoId), 2, 0)));
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
         PA0I2( ) ;
         WS0I2( ) ;
         WE0I2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst ;
         return "";
      }

      public void responsestatic( String sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV7ConsultaFecha = (String)((String)getParm(obj,0)) ;
         sCtrlAV8MedicoId = (String)((String)getParm(obj,1)) ;
         sCtrlAV9TurnoId = (String)((String)getParm(obj,2)) ;
      }

      public override void componentrestorestate( String sPPrefix ,
                                                  String sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix ;
         PA0I2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false ;
         sCompPrefix = (String)getParm(obj,0) ;
         sSFPrefix = (String)getParm(obj,1) ;
         sPrefix = sCompPrefix + sSFPrefix ;
         AddComponentObject(sPrefix, "gestionconsultaconsultapacientewc");
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         PA0I2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV7ConsultaFecha = (DateTime)getParm(obj,2) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "AV7ConsultaFecha", context.localUtil.Format(AV7ConsultaFecha, "99/99/99"));
            AV8MedicoId = Convert.ToInt32(getParm(obj,3)) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "AV8MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV8MedicoId), 6, 0)));
            AV9TurnoId = Convert.ToInt16(getParm(obj,4)) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "AV9TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV9TurnoId), 2, 0)));
         }
         wcpOAV7ConsultaFecha = context.localUtil.CToD( cgiGet( sPrefix+"wcpOAV7ConsultaFecha"), 0) ;
         wcpOAV8MedicoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8MedicoId"), ",", ".")) ;
         wcpOAV9TurnoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV9TurnoId"), ",", ".")) ;
         if ( ! GetJustCreated( ) && ( ( AV7ConsultaFecha != wcpOAV7ConsultaFecha ) || ( AV8MedicoId != wcpOAV8MedicoId ) || ( AV9TurnoId != wcpOAV9TurnoId ) ) )
         {
            setjustcreated();
         }
         wcpOAV7ConsultaFecha = AV7ConsultaFecha ;
         wcpOAV8MedicoId = AV8MedicoId ;
         wcpOAV9TurnoId = AV9TurnoId ;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV7ConsultaFecha = cgiGet( sPrefix+"AV7ConsultaFecha_CTRL") ;
         if ( StringUtil.Len( sCtrlAV7ConsultaFecha) > 0 )
         {
            AV7ConsultaFecha = context.localUtil.CToD( cgiGet( sCtrlAV7ConsultaFecha), 2) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "AV7ConsultaFecha", context.localUtil.Format(AV7ConsultaFecha, "99/99/99"));
         }
         else
         {
            AV7ConsultaFecha = context.localUtil.CToD( cgiGet( sPrefix+"AV7ConsultaFecha_PARM"), 0) ;
         }
         sCtrlAV8MedicoId = cgiGet( sPrefix+"AV8MedicoId_CTRL") ;
         if ( StringUtil.Len( sCtrlAV8MedicoId) > 0 )
         {
            AV8MedicoId = (int)(context.localUtil.CToN( cgiGet( sCtrlAV8MedicoId), ",", ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "AV8MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV8MedicoId), 6, 0)));
         }
         else
         {
            AV8MedicoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV8MedicoId_PARM"), ",", ".")) ;
         }
         sCtrlAV9TurnoId = cgiGet( sPrefix+"AV9TurnoId_CTRL") ;
         if ( StringUtil.Len( sCtrlAV9TurnoId) > 0 )
         {
            AV9TurnoId = (short)(context.localUtil.CToN( cgiGet( sCtrlAV9TurnoId), ",", ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "AV9TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV9TurnoId), 2, 0)));
         }
         else
         {
            AV9TurnoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"AV9TurnoId_PARM"), ",", ".")) ;
         }
      }

      public override void componentprocess( String sPPrefix ,
                                             String sPSFPrefix ,
                                             String sCompEvt )
      {
         sCompPrefix = sPPrefix ;
         sSFPrefix = sPSFPrefix ;
         sPrefix = sCompPrefix + sSFPrefix ;
         BackMsgLst = context.GX_msglist ;
         context.GX_msglist = LclMsgLst ;
         INITWEB( ) ;
         nDraw = 0 ;
         PA0I2( ) ;
         sEvt = sCompEvt ;
         WCParametersGet( ) ;
         WS0I2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst ;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1 ;
         BackMsgLst = context.GX_msglist ;
         context.GX_msglist = LclMsgLst ;
         WS0I2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst ;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7ConsultaFecha_PARM", context.localUtil.DToC( AV7ConsultaFecha, 0, "/"));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7ConsultaFecha)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7ConsultaFecha_CTRL", StringUtil.RTrim( sCtrlAV7ConsultaFecha));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8MedicoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8MedicoId), 6, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8MedicoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8MedicoId_CTRL", StringUtil.RTrim( sCtrlAV8MedicoId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV9TurnoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9TurnoId), 2, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV9TurnoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV9TurnoId_CTRL", StringUtil.RTrim( sCtrlAV9TurnoId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist ;
         context.GX_msglist = LclMsgLst ;
         WCParametersSet( ) ;
         WE0I2( ) ;
         this.cleanup();
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst ;
      }

      public override String getstring( String sGXControl )
      {
         String sCtrlName ;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1) ;
         }
         else
         {
            sCtrlName = sGXControl ;
         }
         return cgiGet( sPrefix+"_"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "?165260");
         AddThemeStyleSheetFile("", "GeneXusX.css", "?2313925");
         idxLst = 1 ;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( Form.Jscriptsrc.Item(idxLst)), "?6114498");
            idxLst = (int)(idxLst+1) ;
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("gestionconsultaconsultapacientewc.js", "?6114498");
         }
         /* End function include_jscripts */
      }

      protected void sendrow_122( )
      {
         WB0I0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_12_idx <= subGrid_Recordsperpage( ) * 1 ) )
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
               context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, sPrefix+"GridContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subGrid_Backcolor), 9, 0)));
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
               context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, sPrefix+"GridContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subGrid_Backcolor), 9, 0)));
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1 ;
               if ( ((int)(nGXsfl_12_idx) % (2)) == 0 )
               {
                  subGrid_Backcolor = (int)(0xE5E5E5) ;
                  context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, sPrefix+"GridContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subGrid_Backcolor), 9, 0)));
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even" ;
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0xF0F0F0) ;
                  context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, sPrefix+"GridContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subGrid_Backcolor), 9, 0)));
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
            GridRow.AddColumnProperties("bitmap", 2, isAjaxCallMode( ), new Object[] {(String)edtavDelete_Internalname,(String)"",(String)AV15Delete,(String)"GeneXusX",(short)-1,(short)1,(String)"",(String)edtavDelete_Tooltiptext,(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"",(short)0,(short)0,(String)edtavDelete_Link,(String)"",(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"",(String)"",(String)"''",(String)""});
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPacienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A34PacienteId), 6, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)6,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A34PacienteId), "ZZZZZ9"),(String)"",(short)0,(String)edtPacienteId_Jsonclick,(String)"",(short)12,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPacienteApellido_Internalname,StringUtil.RTrim( A36PacienteApellido),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A36PacienteApellido, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtPacienteApellido_Jsonclick,(String)"",(short)12,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPacienteNombre_Internalname,StringUtil.RTrim( A35PacienteNombre),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A35PacienteNombre, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtPacienteNombre_Jsonclick,(String)"",(short)12,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPacienteCI_Internalname,StringUtil.RTrim( A41PacienteCI),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)8,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)edtPacienteCI_Link,(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A41PacienteCI, "XXXXXXXX")),(String)"",(short)0,(String)edtPacienteCI_Jsonclick,(String)"",(short)12,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtEspecialidadMaxPacientes_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A11EspecialidadMaxPacientes), 3, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)3,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A11EspecialidadMaxPacientes), "ZZ9"),(String)"",(short)0,(String)edtEspecialidadMaxPacientes_Jsonclick,(String)"",(short)12,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtConsultaNro_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A63ConsultaNro), 2, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)2,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)edtConsultaNro_Link,(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A63ConsultaNro), "Z9"),(String)"",(short)0,(String)edtConsultaNro_Jsonclick,(String)"",(short)12,(short)1,(short)1,(bool)true,(String)"right"});
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
            nGXsfl_12_idx = (short)(((subGrid_Islastpage==1)&&(nGXsfl_12_idx+1>subGrid_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1)) ;
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_12_idx), 4, 0)), 4, "0") ;
            edtavDelete_Internalname = sPrefix+"_DELETE_"+sGXsfl_12_idx ;
            edtavDisplay_Internalname = sPrefix+"_DISPLAY_"+sGXsfl_12_idx ;
            edtPacienteId_Internalname = sPrefix+"PACIENTEID_"+sGXsfl_12_idx ;
            edtPacienteApellido_Internalname = sPrefix+"PACIENTEAPELLIDO_"+sGXsfl_12_idx ;
            edtPacienteNombre_Internalname = sPrefix+"PACIENTENOMBRE_"+sGXsfl_12_idx ;
            edtPacienteCI_Internalname = sPrefix+"PACIENTECI_"+sGXsfl_12_idx ;
            edtEspecialidadMaxPacientes_Internalname = sPrefix+"ESPECIALIDADMAXPACIENTES_"+sGXsfl_12_idx ;
            edtConsultaNro_Internalname = sPrefix+"CONSULTANRO_"+sGXsfl_12_idx ;
            chkConfirmado_Internalname = sPrefix+"CONFIRMADO_"+sGXsfl_12_idx ;
         }
         /* End function sendrow_122 */
      }

      protected void initialize_properties( )
      {
         imgInsert_Internalname = sPrefix+"INSERT" ;
         tblTablegridcontainer_Internalname = sPrefix+"TABLEGRIDCONTAINER" ;
         tblTable_Internalname = sPrefix+"TABLE" ;
         edtConsultaFecha_Internalname = sPrefix+"CONSULTAFECHA" ;
         edtMedicoId_Internalname = sPrefix+"MEDICOID" ;
         edtTurnoId_Internalname = sPrefix+"TURNOID" ;
         Form.Internalname = sPrefix+"FORM" ;
         subGrid_Internalname = sPrefix+"GRID" ;
         edtConsultaNro_Jsonclick = "" ;
         edtEspecialidadMaxPacientes_Jsonclick = "" ;
         edtPacienteCI_Jsonclick = "" ;
         edtPacienteNombre_Jsonclick = "" ;
         edtPacienteApellido_Jsonclick = "" ;
         edtPacienteId_Jsonclick = "" ;
         subGrid_Class = "WorkWith" ;
         subGrid_Backcolorstyle = 3 ;
         edtConsultaNro_Link = "" ;
         edtPacienteCI_Link = "" ;
         edtavDisplay_Link = "" ;
         edtavDelete_Link = "" ;
         edtTurnoId_Jsonclick = "" ;
         edtTurnoId_Visible = 1 ;
         edtMedicoId_Jsonclick = "" ;
         edtMedicoId_Visible = 1 ;
         edtConsultaFecha_Jsonclick = "" ;
         edtConsultaFecha_Visible = 1 ;
         subGrid_Rows = 0 ;
         chkConfirmado.Caption = "" ;
         edtavDelete_Tooltiptext = "Eliminar" ;
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
         wcpOAV7ConsultaFecha = DateTime.MinValue ;
         gxfirstwebparm = "" ;
         gxfirstwebparm_bkp = "" ;
         sPrefix = "" ;
         edtavDisplay_Internalname = "" ;
         AV16Display = "" ;
         edtavDelete_Internalname = "" ;
         AV15Delete = "" ;
         AV19Pgmname = "" ;
         GXCCtl = "" ;
         chkConfirmado_Internalname = "" ;
         A43ConsultaFecha = DateTime.MinValue ;
         sDynURL = "" ;
         FormProcess = "" ;
         GXt_char1 = "" ;
         GX_FocusControl = "" ;
         ClassString = "" ;
         StyleString = "" ;
         Form = new GXWebForm();
         sXEvt = "" ;
         sEvt = "" ;
         EvtGridId = "" ;
         EvtRowId = "" ;
         sEvtType = "" ;
         edtPacienteId_Internalname = "" ;
         edtPacienteApellido_Internalname = "" ;
         edtPacienteNombre_Internalname = "" ;
         edtPacienteCI_Internalname = "" ;
         edtEspecialidadMaxPacientes_Internalname = "" ;
         edtConsultaNro_Internalname = "" ;
         A36PacienteApellido = "" ;
         A35PacienteNombre = "" ;
         A41PacienteCI = "" ;
         GridContainer = new GXWebGrid( context);
         scmdbuf = "" ;
         H000I2_A9EspecialidadId = new int[1] ;
         H000I2_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         H000I2_A12MedicoId = new int[1] ;
         H000I2_A60TurnoId = new short[1] ;
         H000I2_A75Confirmado = new bool[] {false} ;
         H000I2_A63ConsultaNro = new short[1] ;
         H000I2_n63ConsultaNro = new bool[] {false} ;
         H000I2_A11EspecialidadMaxPacientes = new short[1] ;
         H000I2_A41PacienteCI = new String[] {""} ;
         H000I2_A35PacienteNombre = new String[] {""} ;
         H000I2_A36PacienteApellido = new String[] {""} ;
         H000I2_A34PacienteId = new int[1] ;
         H000I3_AGRID_nRecordCount = new int[1] ;
         AV12TrnContext = new SdtTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV13TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV10Session = new GxWebSession( context);
         sStyleString = "" ;
         TempTags = "" ;
         imgInsert_Jsonclick = "" ;
         subGrid_Linesclass = "" ;
         GXt_char8 = "" ;
         GXt_char7 = "" ;
         GXt_char6 = "" ;
         GXt_char5 = "" ;
         GXt_char4 = "" ;
         GXt_char3 = "" ;
         GXt_char2 = "" ;
         GridColumn = new GXWebColumn();
         GXt_char9 = "" ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV7ConsultaFecha = "" ;
         sCtrlAV8MedicoId = "" ;
         sCtrlAV9TurnoId = "" ;
         GXt_char10 = "" ;
         GridRow = new GXWebRow();
         ROClassString = "" ;
         GXt_char11 = "" ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gestionconsultaconsultapacientewc__default(),
            new Object[][] {
                new Object[] {
               H000I2_A9EspecialidadId, H000I2_A43ConsultaFecha, H000I2_A12MedicoId, H000I2_A60TurnoId, H000I2_A75Confirmado, H000I2_A63ConsultaNro, H000I2_n63ConsultaNro, H000I2_A11EspecialidadMaxPacientes, H000I2_A41PacienteCI, H000I2_A35PacienteNombre,
               H000I2_A36PacienteApellido, H000I2_A34PacienteId
               }
               , new Object[] {
               H000I3_AGRID_nRecordCount
               }
            }
         );
         AV19Pgmname = "GestionConsultaConsultaPacienteWC" ;
         /* GeneXus formulas. */
         AV19Pgmname = "GestionConsultaConsultaPacienteWC" ;
         context.Gx_err = 0 ;
      }

      private short AV9TurnoId ;
      private short wcpOAV9TurnoId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short nRC_Grid ;
      private short nGXsfl_12_idx=1 ;
      private short A60TurnoId ;
      private short initialized ;
      private short nGXWrapped ;
      private short GRID_nEOF ;
      private short subGrid_Rows ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short A11EspecialidadMaxPacientes ;
      private short A63ConsultaNro ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Collapsed ;
      private short subGrid_Backstyle ;
      private int AV8MedicoId ;
      private int wcpOAV8MedicoId ;
      private int Grid_PageSize12 ;
      private int A12MedicoId ;
      private int GRID_nFirstRecordOnPage ;
      private int edtConsultaFecha_Visible ;
      private int edtMedicoId_Visible ;
      private int edtTurnoId_Visible ;
      private int A34PacienteId ;
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
      private String sPrefix ;
      private String sCompPrefix ;
      private String sSFPrefix ;
      private String sGXsfl_12_idx="0001" ;
      private String edtavDisplay_Tooltiptext ;
      private String edtavDisplay_Internalname ;
      private String edtavDelete_Tooltiptext ;
      private String edtavDelete_Internalname ;
      private String AV19Pgmname ;
      private String GXCCtl ;
      private String chkConfirmado_Internalname ;
      private String sDynURL ;
      private String FormProcess ;
      private String GXt_char1 ;
      private String GX_FocusControl ;
      private String ClassString ;
      private String StyleString ;
      private String edtConsultaFecha_Internalname ;
      private String edtConsultaFecha_Jsonclick ;
      private String edtMedicoId_Internalname ;
      private String edtMedicoId_Jsonclick ;
      private String edtTurnoId_Internalname ;
      private String edtTurnoId_Jsonclick ;
      private String sXEvt ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtPacienteId_Internalname ;
      private String edtPacienteApellido_Internalname ;
      private String edtPacienteNombre_Internalname ;
      private String edtPacienteCI_Internalname ;
      private String edtEspecialidadMaxPacientes_Internalname ;
      private String edtConsultaNro_Internalname ;
      private String A36PacienteApellido ;
      private String A35PacienteNombre ;
      private String A41PacienteCI ;
      private String scmdbuf ;
      private String edtavDelete_Link ;
      private String edtavDisplay_Link ;
      private String edtPacienteCI_Link ;
      private String edtConsultaNro_Link ;
      private String sStyleString ;
      private String tblTable_Internalname ;
      private String tblTablegridcontainer_Internalname ;
      private String TempTags ;
      private String imgInsert_Internalname ;
      private String imgInsert_Jsonclick ;
      private String subGrid_Internalname ;
      private String subGrid_Class ;
      private String subGrid_Linesclass ;
      private String GXt_char8 ;
      private String GXt_char7 ;
      private String GXt_char6 ;
      private String GXt_char5 ;
      private String GXt_char4 ;
      private String GXt_char3 ;
      private String GXt_char2 ;
      private String GXt_char9 ;
      private String sCtrlAV7ConsultaFecha ;
      private String sCtrlAV8MedicoId ;
      private String sCtrlAV9TurnoId ;
      private String GXt_char10 ;
      private String ROClassString ;
      private String edtPacienteId_Jsonclick ;
      private String edtPacienteApellido_Jsonclick ;
      private String edtPacienteNombre_Jsonclick ;
      private String edtPacienteCI_Jsonclick ;
      private String edtEspecialidadMaxPacientes_Jsonclick ;
      private String edtConsultaNro_Jsonclick ;
      private String GXt_char11 ;
      private DateTime AV7ConsultaFecha ;
      private DateTime wcpOAV7ConsultaFecha ;
      private DateTime A43ConsultaFecha ;
      private bool entryPointCalled ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n63ConsultaNro ;
      private bool A75Confirmado ;
      private bool returnInSub ;
      private bool AV5IsAuthorized ;
      private String AV16Display ;
      private String AV15Delete ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkConfirmado ;
      private IDataStoreProvider pr_default ;
      private int[] H000I2_A9EspecialidadId ;
      private DateTime[] H000I2_A43ConsultaFecha ;
      private int[] H000I2_A12MedicoId ;
      private short[] H000I2_A60TurnoId ;
      private bool[] H000I2_A75Confirmado ;
      private short[] H000I2_A63ConsultaNro ;
      private bool[] H000I2_n63ConsultaNro ;
      private short[] H000I2_A11EspecialidadMaxPacientes ;
      private String[] H000I2_A41PacienteCI ;
      private String[] H000I2_A35PacienteNombre ;
      private String[] H000I2_A36PacienteApellido ;
      private int[] H000I2_A34PacienteId ;
      private int[] H000I3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV11HTTPRequest ;
      private GxWebSession AV10Session ;
      private SdtTransactionContext AV12TrnContext ;
      private SdtTransactionContext_Attribute AV13TrnContextAtt ;
   }

   public class gestionconsultaconsultapacientewc__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH000I2 ;
          prmH000I2 = new Object[] {
          new Object[] {"@AV7ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV8MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@AV9TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmH000I3 ;
          prmH000I3 = new Object[] {
          new Object[] {"@AV7ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV8MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@AV9TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H000I2", "SELECT T2.[EspecialidadId], T1.[ConsultaFecha], T1.[MedicoId], T1.[TurnoId], T1.[Confirmado], T1.[ConsultaNro], T3.[EspecialidadMaxPacientes], T4.[PacienteCI], T4.[PacienteNombre], T4.[PacienteApellido], T1.[PacienteId] FROM ((([ConsultaPaciente] T1 WITH (NOLOCK) INNER JOIN [Medico] T2 WITH (NOLOCK) ON T2.[MedicoId] = T1.[MedicoId]) INNER JOIN [Especialidad] T3 WITH (NOLOCK) ON T3.[EspecialidadId] = T2.[EspecialidadId]) INNER JOIN [Paciente] T4 WITH (NOLOCK) ON T4.[PacienteId] = T1.[PacienteId]) WHERE (T1.[ConsultaFecha] = @AV7ConsultaFecha) AND (T1.[MedicoId] = @AV8MedicoId) AND (T1.[TurnoId] = @AV9TurnoId) ORDER BY T1.[ConsultaNro] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000I2,11,0,true,false )
             ,new CursorDef("H000I3", "SELECT COUNT(*) FROM ((([ConsultaPaciente] T1 WITH (NOLOCK) INNER JOIN [Medico] T3 WITH (NOLOCK) ON T3.[MedicoId] = T1.[MedicoId]) INNER JOIN [Especialidad] T4 WITH (NOLOCK) ON T4.[EspecialidadId] = T3.[EspecialidadId]) INNER JOIN [Paciente] T2 WITH (NOLOCK) ON T2.[PacienteId] = T1.[PacienteId]) WHERE (T1.[ConsultaFecha] = @AV7ConsultaFecha) AND (T1.[MedicoId] = @AV8MedicoId) AND (T1.[TurnoId] = @AV9TurnoId) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000I3,1,0,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                ((short[]) buf[3])[0] = rslt.getShort(4) ;
                ((bool[]) buf[4])[0] = rslt.getBool(5) ;
                ((short[]) buf[5])[0] = rslt.getShort(6) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((short[]) buf[7])[0] = rslt.getShort(7) ;
                ((String[]) buf[8])[0] = rslt.getString(8, 8) ;
                ((String[]) buf[9])[0] = rslt.getString(9, 20) ;
                ((String[]) buf[10])[0] = rslt.getString(10, 20) ;
                ((int[]) buf[11])[0] = rslt.getInt(11) ;
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
       }
    }

 }

}
