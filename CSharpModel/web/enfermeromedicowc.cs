/*
               File: EnfermeroMedicoWC
        Description: Enfermero Medico WC
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/22/2010 4:0:36.60
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
   public class enfermeromedicowc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public enfermeromedicowc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public enfermeromedicowc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default") ;
      }

      public void release( )
      {
      }

      public void execute( int aP0_EnfermeroTitularId )
      {
         this.AV7EnfermeroTitularId = aP0_EnfermeroTitularId;
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
         cmbMedicoEstadoCivil = new GXCombobox();
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
                  AV7EnfermeroTitularId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  componentprepare(new Object[] {(String)sCompPrefix,(String)sSFPrefix,(int)AV7EnfermeroTitularId});
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
                  edtavDelete_Tooltiptext = GetNextPar( ) ;
                  context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext);
                  AV13Delete = GetNextPar( ) ;
                  context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDelete_Internalname, "Bitmap", context.convertURL( AV13Delete));
                  edtavUpdate_Tooltiptext = GetNextPar( ) ;
                  context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext);
                  AV12Update = GetNextPar( ) ;
                  context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavUpdate_Internalname, "Bitmap", context.convertURL( AV12Update));
                  sPrefix = GetNextPar( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1 ;
                     return  ;
                  }
                  gxnrGrid_newrow( nRC_Grid, nGXsfl_12_idx, sGXsfl_12_idx, AV13Delete, AV12Update, sPrefix) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
               {
                  /* GeneXus formulas. */
                  AV16Pgmname = "EnfermeroMedicoWC" ;
                  context.Gx_err = 0 ;
                  GXCCtl = "MEDICOESTADOCIVIL_" + sGXsfl_12_idx ;
                  cmbMedicoEstadoCivil.Name = GXCCtl ;
                  cmbMedicoEstadoCivil.WebTags = "" ;
                  cmbMedicoEstadoCivil.addItem("S", "Soltero", 0);
                  cmbMedicoEstadoCivil.addItem("C", "Casado", 0);
                  cmbMedicoEstadoCivil.addItem("V", "Viudo", 0);
                  cmbMedicoEstadoCivil.addItem("D", "Divorciado", 0);
                  if ( ( cmbMedicoEstadoCivil.ItemCount > 0 ) && String.IsNullOrEmpty(StringUtil.RTrim( A17MedicoEstadoCivil)) )
                  {
                     A17MedicoEstadoCivil = cmbMedicoEstadoCivil.getItemValue(1) ;
                     context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A17MedicoEstadoCivil", A17MedicoEstadoCivil);
                  }
                  Grid_PageSize12 = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  AV7EnfermeroTitularId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "AV7EnfermeroTitularId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV7EnfermeroTitularId), 6, 0)));
                  edtavDelete_Tooltiptext = GetNextPar( ) ;
                  context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext);
                  AV13Delete = GetNextPar( ) ;
                  context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDelete_Internalname, "Bitmap", context.convertURL( AV13Delete));
                  edtavUpdate_Tooltiptext = GetNextPar( ) ;
                  context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext);
                  AV12Update = GetNextPar( ) ;
                  context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavUpdate_Internalname, "Bitmap", context.convertURL( AV12Update));
                  sPrefix = GetNextPar( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1 ;
                     return  ;
                  }
                  gxgrGrid_refresh( Grid_PageSize12, AV7EnfermeroTitularId, AV13Delete, AV12Update, sPrefix) ;
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
            PA0A2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV16Pgmname = "EnfermeroMedicoWC" ;
               context.Gx_err = 0 ;
               WS0A2( ) ;
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
            context.WriteHtmlText( "Enfermero Medico WC") ;
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
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" onsubmit=\"try{return gx.csv.validForm()}catch(e){return true;}\" name=\"MAINFORM\" method=\"post\" action=\""+formatLink("enfermeromedicowc.aspx") + "?" + UrlEncode("" +AV7EnfermeroTitularId)+"\" class=\""+"Form"+"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            }
         }
      }

      protected void RenderHtmlCloseForm0A2( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_Grid", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_Grid), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7EnfermeroTitularId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7EnfermeroTitularId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"_ENFERMEROTITULARID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EnfermeroTitularId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 3, 0, ".", "")));
         if ( ( StringUtil.Len( sPrefix) != 0 ) && context.isAjaxRequest( ) )
         {
            context.AddJavascriptSource("enfermeromedicowc.js", "?403673");
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

      protected void WB0A0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "enfermeromedicowc.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            wb_table1_2_0A2( true) ;
         }
         else
         {
            wb_table1_2_0A2( false) ;
         }
         return  ;
      }

      protected void wb_table1_2_0A2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtEnfermeroTitularId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A46EnfermeroTitularId), 6, 0, ",", "")), "", 6, "chr", 1, "row", 6, edtEnfermeroTitularId_Visible, 0, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A46EnfermeroTitularId), "ZZZZZ9"), "", 0, edtEnfermeroTitularId_Jsonclick, "", 0, 1, 1, true, "right", "HLP_EnfermeroMedicoWC.htm");
         }
         wbLoad = true ;
      }

      protected void START0A2( )
      {
         wbLoad = false ;
         wbEnd = 0 ;
         wbStart = 0 ;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            Form.Meta.addItem("Generator", "GeneXus C#", 0) ;
            Form.Meta.addItem("Version", "10_1_3-34981", 0) ;
            Form.Meta.addItem("Description", "Enfermero Medico WC", 0) ;
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
               STRUP0A0( ) ;
            }
         }
      }

      protected void WS0A2( )
      {
         START0A2( ) ;
         EVT0A2( ) ;
      }

      protected void EVT0A2( )
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
                                 STRUP0A0( ) ;
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
                                 STRUP0A0( ) ;
                              }
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1 ;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: E110A2 */
                                    E110A2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0A0( ) ;
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
                                 STRUP0A0( ) ;
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
                                 STRUP0A0( ) ;
                              }
                              nGXsfl_12_idx = (short)(NumberUtil.Val( sEvtType, ".")) ;
                              sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_12_idx), 4, 0)), 4, "0") ;
                              edtavUpdate_Internalname = sPrefix+"_UPDATE_"+sGXsfl_12_idx ;
                              edtavDelete_Internalname = sPrefix+"_DELETE_"+sGXsfl_12_idx ;
                              edtMedicoId_Internalname = sPrefix+"MEDICOID_"+sGXsfl_12_idx ;
                              edtMedicoNombre_Internalname = sPrefix+"MEDICONOMBRE_"+sGXsfl_12_idx ;
                              edtMedicoApellido_Internalname = sPrefix+"MEDICOAPELLIDO_"+sGXsfl_12_idx ;
                              edtMedicoDomicilio_Internalname = sPrefix+"MEDICODOMICILIO_"+sGXsfl_12_idx ;
                              edtMedicoTelefono_Internalname = sPrefix+"MEDICOTELEFONO_"+sGXsfl_12_idx ;
                              cmbMedicoEstadoCivil_Internalname = sPrefix+"MEDICOESTADOCIVIL_"+sGXsfl_12_idx ;
                              edtMedicoFechaIngreso_Internalname = sPrefix+"MEDICOFECHAINGRESO_"+sGXsfl_12_idx ;
                              edtEspecialidadId_Internalname = sPrefix+"ESPECIALIDADID_"+sGXsfl_12_idx ;
                              edtEspecialidadDescripcion_Internalname = sPrefix+"ESPECIALIDADDESCRIPCION_"+sGXsfl_12_idx ;
                              edtEnfermeroSuplenteId_Internalname = sPrefix+"ENFERMEROSUPLENTEID_"+sGXsfl_12_idx ;
                              edtEnfermeroSuplenteNombre_Internalname = sPrefix+"ENFERMEROSUPLENTENOMBRE_"+sGXsfl_12_idx ;
                              edtEnfermeroSuplenteApellido_Internalname = sPrefix+"ENFERMEROSUPLENTEAPELLIDO_"+sGXsfl_12_idx ;
                              AV12Update = cgiGet( "GXimg"+edtavUpdate_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavUpdate_Internalname, "Bitmap", context.convertURL( AV12Update));
                              AV13Delete = cgiGet( "GXimg"+edtavDelete_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDelete_Internalname, "Bitmap", context.convertURL( AV13Delete));
                              A12MedicoId = (int)(context.localUtil.CToN( cgiGet( edtMedicoId_Internalname), ",", ".")) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
                              A13MedicoNombre = cgiGet( edtMedicoNombre_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A13MedicoNombre", A13MedicoNombre);
                              A14MedicoApellido = cgiGet( edtMedicoApellido_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A14MedicoApellido", A14MedicoApellido);
                              A15MedicoDomicilio = cgiGet( edtMedicoDomicilio_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A15MedicoDomicilio", A15MedicoDomicilio);
                              A16MedicoTelefono = cgiGet( edtMedicoTelefono_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A16MedicoTelefono", A16MedicoTelefono);
                              cmbMedicoEstadoCivil.Name = cmbMedicoEstadoCivil_Internalname ;
                              cmbMedicoEstadoCivil.CurrentValue = cgiGet( cmbMedicoEstadoCivil_Internalname) ;
                              A17MedicoEstadoCivil = cgiGet( cmbMedicoEstadoCivil_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A17MedicoEstadoCivil", A17MedicoEstadoCivil);
                              A18MedicoFechaIngreso = context.localUtil.CToD( cgiGet( edtMedicoFechaIngreso_Internalname), 2) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A18MedicoFechaIngreso", context.localUtil.Format(A18MedicoFechaIngreso, "99/99/99"));
                              A9EspecialidadId = (int)(context.localUtil.CToN( cgiGet( edtEspecialidadId_Internalname), ",", ".")) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
                              A10EspecialidadDescripcion = cgiGet( edtEspecialidadDescripcion_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A10EspecialidadDescripcion", A10EspecialidadDescripcion);
                              A51EnfermeroSuplenteId = (int)(context.localUtil.CToN( cgiGet( edtEnfermeroSuplenteId_Internalname), ",", ".")) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A51EnfermeroSuplenteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A51EnfermeroSuplenteId), 6, 0)));
                              A52EnfermeroSuplenteNombre = cgiGet( edtEnfermeroSuplenteNombre_Internalname) ;
                              n52EnfermeroSuplenteNombre = false ;
                              context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A52EnfermeroSuplenteNombre", A52EnfermeroSuplenteNombre);
                              A56EnfermeroSuplenteApellido = cgiGet( edtEnfermeroSuplenteApellido_Internalname) ;
                              n56EnfermeroSuplenteApellido = false ;
                              context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A56EnfermeroSuplenteApellido", A56EnfermeroSuplenteApellido);
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
                                          /* Execute user event: E120A2 */
                                          E120A2 ();
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
                                          /* Execute user event: E130A2 */
                                          E130A2 ();
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
                                          /* Execute user event: E110A2 */
                                          E110A2 ();
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
                                       STRUP0A0( ) ;
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

      protected void WE0A2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true ;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0A2( ) ;
            }
         }
      }

      protected void PA0A2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXCCtl = "MEDICOESTADOCIVIL_" + sGXsfl_12_idx ;
            cmbMedicoEstadoCivil.Name = GXCCtl ;
            cmbMedicoEstadoCivil.WebTags = "" ;
            cmbMedicoEstadoCivil.addItem("S", "Soltero", 0);
            cmbMedicoEstadoCivil.addItem("C", "Casado", 0);
            cmbMedicoEstadoCivil.addItem("V", "Viudo", 0);
            cmbMedicoEstadoCivil.addItem("D", "Divorciado", 0);
            if ( ( cmbMedicoEstadoCivil.ItemCount > 0 ) && String.IsNullOrEmpty(StringUtil.RTrim( A17MedicoEstadoCivil)) )
            {
               A17MedicoEstadoCivil = cmbMedicoEstadoCivil.getItemValue(1) ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A17MedicoEstadoCivil", A17MedicoEstadoCivil);
            }
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
                                      String AV13Delete ,
                                      String AV12Update ,
                                      String sPrefix )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         edtavUpdate_Internalname = sPrefix+"_UPDATE_"+sGXsfl_12_idx ;
         edtavDelete_Internalname = sPrefix+"_DELETE_"+sGXsfl_12_idx ;
         edtMedicoId_Internalname = sPrefix+"MEDICOID_"+sGXsfl_12_idx ;
         edtMedicoNombre_Internalname = sPrefix+"MEDICONOMBRE_"+sGXsfl_12_idx ;
         edtMedicoApellido_Internalname = sPrefix+"MEDICOAPELLIDO_"+sGXsfl_12_idx ;
         edtMedicoDomicilio_Internalname = sPrefix+"MEDICODOMICILIO_"+sGXsfl_12_idx ;
         edtMedicoTelefono_Internalname = sPrefix+"MEDICOTELEFONO_"+sGXsfl_12_idx ;
         cmbMedicoEstadoCivil_Internalname = sPrefix+"MEDICOESTADOCIVIL_"+sGXsfl_12_idx ;
         edtMedicoFechaIngreso_Internalname = sPrefix+"MEDICOFECHAINGRESO_"+sGXsfl_12_idx ;
         edtEspecialidadId_Internalname = sPrefix+"ESPECIALIDADID_"+sGXsfl_12_idx ;
         edtEspecialidadDescripcion_Internalname = sPrefix+"ESPECIALIDADDESCRIPCION_"+sGXsfl_12_idx ;
         edtEnfermeroSuplenteId_Internalname = sPrefix+"ENFERMEROSUPLENTEID_"+sGXsfl_12_idx ;
         edtEnfermeroSuplenteNombre_Internalname = sPrefix+"ENFERMEROSUPLENTENOMBRE_"+sGXsfl_12_idx ;
         edtEnfermeroSuplenteApellido_Internalname = sPrefix+"ENFERMEROSUPLENTEAPELLIDO_"+sGXsfl_12_idx ;
         while ( nGXsfl_12_idx <= nRC_Grid )
         {
            sendrow_122( ) ;
            nGXsfl_12_idx = (short)(((subGrid_Islastpage==1)&&(nGXsfl_12_idx+1>subGrid_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1)) ;
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_12_idx), 4, 0)), 4, "0") ;
            edtavUpdate_Internalname = sPrefix+"_UPDATE_"+sGXsfl_12_idx ;
            edtavDelete_Internalname = sPrefix+"_DELETE_"+sGXsfl_12_idx ;
            edtMedicoId_Internalname = sPrefix+"MEDICOID_"+sGXsfl_12_idx ;
            edtMedicoNombre_Internalname = sPrefix+"MEDICONOMBRE_"+sGXsfl_12_idx ;
            edtMedicoApellido_Internalname = sPrefix+"MEDICOAPELLIDO_"+sGXsfl_12_idx ;
            edtMedicoDomicilio_Internalname = sPrefix+"MEDICODOMICILIO_"+sGXsfl_12_idx ;
            edtMedicoTelefono_Internalname = sPrefix+"MEDICOTELEFONO_"+sGXsfl_12_idx ;
            cmbMedicoEstadoCivil_Internalname = sPrefix+"MEDICOESTADOCIVIL_"+sGXsfl_12_idx ;
            edtMedicoFechaIngreso_Internalname = sPrefix+"MEDICOFECHAINGRESO_"+sGXsfl_12_idx ;
            edtEspecialidadId_Internalname = sPrefix+"ESPECIALIDADID_"+sGXsfl_12_idx ;
            edtEspecialidadDescripcion_Internalname = sPrefix+"ESPECIALIDADDESCRIPCION_"+sGXsfl_12_idx ;
            edtEnfermeroSuplenteId_Internalname = sPrefix+"ENFERMEROSUPLENTEID_"+sGXsfl_12_idx ;
            edtEnfermeroSuplenteNombre_Internalname = sPrefix+"ENFERMEROSUPLENTENOMBRE_"+sGXsfl_12_idx ;
            edtEnfermeroSuplenteApellido_Internalname = sPrefix+"ENFERMEROSUPLENTEAPELLIDO_"+sGXsfl_12_idx ;
         }
         context.GX_webresponse.AddString(GridContainer.ToJavascriptSource());
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int Grid_PageSize12 ,
                                       int AV7EnfermeroTitularId ,
                                       String AV13Delete ,
                                       String AV12Update ,
                                       String sPrefix )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         disableOutput();
         subGrid_Rows = (short)(Grid_PageSize12) ;
         RF0A2( ) ;
         enableOutput();
         context.GX_webresponse.AddString(GridContainer.ToJavascriptSource());
         /* End function gxgrGrid_refresh */
      }

      protected void Refresh( )
      {
         RF0A2( ) ;
         /* End function Refresh */
      }

      protected void RF0A2( )
      {
         GridContainer.PageSize = subGrid_Recordsperpage( ) ;
         wbStart = 12 ;
         nGXsfl_12_idx = 1 ;
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_12_idx), 4, 0)), 4, "0") ;
         edtavUpdate_Internalname = sPrefix+"_UPDATE_"+sGXsfl_12_idx ;
         edtavDelete_Internalname = sPrefix+"_DELETE_"+sGXsfl_12_idx ;
         edtMedicoId_Internalname = sPrefix+"MEDICOID_"+sGXsfl_12_idx ;
         edtMedicoNombre_Internalname = sPrefix+"MEDICONOMBRE_"+sGXsfl_12_idx ;
         edtMedicoApellido_Internalname = sPrefix+"MEDICOAPELLIDO_"+sGXsfl_12_idx ;
         edtMedicoDomicilio_Internalname = sPrefix+"MEDICODOMICILIO_"+sGXsfl_12_idx ;
         edtMedicoTelefono_Internalname = sPrefix+"MEDICOTELEFONO_"+sGXsfl_12_idx ;
         cmbMedicoEstadoCivil_Internalname = sPrefix+"MEDICOESTADOCIVIL_"+sGXsfl_12_idx ;
         edtMedicoFechaIngreso_Internalname = sPrefix+"MEDICOFECHAINGRESO_"+sGXsfl_12_idx ;
         edtEspecialidadId_Internalname = sPrefix+"ESPECIALIDADID_"+sGXsfl_12_idx ;
         edtEspecialidadDescripcion_Internalname = sPrefix+"ESPECIALIDADDESCRIPCION_"+sGXsfl_12_idx ;
         edtEnfermeroSuplenteId_Internalname = sPrefix+"ENFERMEROSUPLENTEID_"+sGXsfl_12_idx ;
         edtEnfermeroSuplenteNombre_Internalname = sPrefix+"ENFERMEROSUPLENTENOMBRE_"+sGXsfl_12_idx ;
         edtEnfermeroSuplenteApellido_Internalname = sPrefix+"ENFERMEROSUPLENTEAPELLIDO_"+sGXsfl_12_idx ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H000A2 */
            pr_default.execute(0, new Object[] {AV7EnfermeroTitularId});
            nGXsfl_12_idx = 1 ;
            GRID_nEOF = 0 ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_Recordsperpage( ) ) ) ) )
            {
               A46EnfermeroTitularId = H000A2_A46EnfermeroTitularId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A46EnfermeroTitularId", StringUtil.LTrim( StringUtil.Str( (decimal)(A46EnfermeroTitularId), 6, 0)));
               A56EnfermeroSuplenteApellido = H000A2_A56EnfermeroSuplenteApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A56EnfermeroSuplenteApellido", A56EnfermeroSuplenteApellido);
               n56EnfermeroSuplenteApellido = H000A2_n56EnfermeroSuplenteApellido[0] ;
               A52EnfermeroSuplenteNombre = H000A2_A52EnfermeroSuplenteNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A52EnfermeroSuplenteNombre", A52EnfermeroSuplenteNombre);
               n52EnfermeroSuplenteNombre = H000A2_n52EnfermeroSuplenteNombre[0] ;
               A51EnfermeroSuplenteId = H000A2_A51EnfermeroSuplenteId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A51EnfermeroSuplenteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A51EnfermeroSuplenteId), 6, 0)));
               A10EspecialidadDescripcion = H000A2_A10EspecialidadDescripcion[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A10EspecialidadDescripcion", A10EspecialidadDescripcion);
               A9EspecialidadId = H000A2_A9EspecialidadId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
               A18MedicoFechaIngreso = H000A2_A18MedicoFechaIngreso[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A18MedicoFechaIngreso", context.localUtil.Format(A18MedicoFechaIngreso, "99/99/99"));
               A17MedicoEstadoCivil = H000A2_A17MedicoEstadoCivil[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A17MedicoEstadoCivil", A17MedicoEstadoCivil);
               A16MedicoTelefono = H000A2_A16MedicoTelefono[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A16MedicoTelefono", A16MedicoTelefono);
               A15MedicoDomicilio = H000A2_A15MedicoDomicilio[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A15MedicoDomicilio", A15MedicoDomicilio);
               A14MedicoApellido = H000A2_A14MedicoApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A14MedicoApellido", A14MedicoApellido);
               A13MedicoNombre = H000A2_A13MedicoNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A13MedicoNombre", A13MedicoNombre);
               A12MedicoId = H000A2_A12MedicoId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
               A56EnfermeroSuplenteApellido = H000A2_A56EnfermeroSuplenteApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A56EnfermeroSuplenteApellido", A56EnfermeroSuplenteApellido);
               n56EnfermeroSuplenteApellido = H000A2_n56EnfermeroSuplenteApellido[0] ;
               A52EnfermeroSuplenteNombre = H000A2_A52EnfermeroSuplenteNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A52EnfermeroSuplenteNombre", A52EnfermeroSuplenteNombre);
               n52EnfermeroSuplenteNombre = H000A2_n52EnfermeroSuplenteNombre[0] ;
               A10EspecialidadDescripcion = H000A2_A10EspecialidadDescripcion[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A10EspecialidadDescripcion", A10EspecialidadDescripcion);
               /* Execute user event: E130A2 */
               E130A2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0)) ;
            pr_default.close(0);
            wbEnd = 12 ;
            WB0A0( ) ;
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
         /* Using cursor H000A3 */
         pr_default.execute(1, new Object[] {AV7EnfermeroTitularId});
         GRID_nRecordCount = H000A3_AGRID_nRecordCount[0] ;
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

      protected void STRUP0A0( )
      {
         /* Before Start, stand alone formulas. */
         AV16Pgmname = "EnfermeroMedicoWC" ;
         context.Gx_err = 0 ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0 ;
         /* Execute user event: E120A2 */
         E120A2 ();
         context.wbGlbDoneStart = 1 ;
         nDoneStart = 1 ;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName") ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read variables values. */
            A46EnfermeroTitularId = (int)(context.localUtil.CToN( cgiGet( edtEnfermeroTitularId_Internalname), ",", ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A46EnfermeroTitularId", StringUtil.LTrim( StringUtil.Str( (decimal)(A46EnfermeroTitularId), 6, 0)));
            /* Read saved values. */
            nRC_Grid = (short)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_Grid"), ",", ".")) ;
            wcpOAV7EnfermeroTitularId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7EnfermeroTitularId"), ",", ".")) ;
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
         /* Execute user event: E120A2 */
         E120A2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E120A2( )
      {
         /* Start Routine */
         new isauthorized(context ).execute(  AV16Pgmname, out  AV5IsAuthorized) ;
         if ( ! AV5IsAuthorized )
         {
            context.wjLoc = formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV16Pgmname)) ;
         }
         subGrid_Rows = 10 ;
         AV12Update = context.GetImagePath( "7c63c2b9-483e-4035-b512-febf9186a274", "", "GeneXusX") ;
         context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavUpdate_Internalname, "Bitmap", context.convertURL( AV12Update));
         edtavUpdate_Tooltiptext = "Modifica" ;
         context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext);
         AV13Delete = context.GetImagePath( "7695fe89-52c9-4b7e-871e-0e11548f823e", "", "GeneXusX") ;
         context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDelete_Internalname, "Bitmap", context.convertURL( AV13Delete));
         edtavDelete_Tooltiptext = "Eliminar" ;
         context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext);
         edtEnfermeroTitularId_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtEnfermeroTitularId_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(edtEnfermeroTitularId_Visible), 5, 0)));
         /* Execute user subroutine: S112 */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      private void E130A2( )
      {
         /* Grid_Load Routine */
         edtavUpdate_Link = formatLink("medico.aspx") + "?" + UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode("" +A12MedicoId) ;
         context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavUpdate_Internalname, "Link", edtavUpdate_Link);
         edtavDelete_Link = formatLink("medico.aspx") + "?" + UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode("" +A12MedicoId) ;
         context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtavDelete_Internalname, "Link", edtavDelete_Link);
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

      protected void E110A2( )
      {
         /* 'DoInsert' Routine */
         context.wjLoc = formatLink("medico.aspx") + "?" + UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode("" +0) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         AV10TrnContext = new SdtTransactionContext(context) ;
         AV10TrnContext.gxTpr_Callerobject = AV16Pgmname ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10TrnContext", (Object)(AV10TrnContext));
         AV10TrnContext.gxTpr_Callerondelete = true ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10TrnContext", (Object)(AV10TrnContext));
         AV10TrnContext.gxTpr_Callerurl = AV9HTTPRequest.ScriptName+"?"+AV9HTTPRequest.QueryString ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10TrnContext", (Object)(AV10TrnContext));
         AV10TrnContext.gxTpr_Transactionname = "Medico" ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10TrnContext", (Object)(AV10TrnContext));
         AV11TrnContextAtt = new SdtTransactionContext_Attribute(context) ;
         AV11TrnContextAtt.gxTpr_Attributename = "EnfermeroTitularId" ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11TrnContextAtt", (Object)(AV11TrnContextAtt));
         AV11TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV7EnfermeroTitularId), 6, 0) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11TrnContextAtt", (Object)(AV11TrnContextAtt));
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV8Session.Set("TrnContext", AV10TrnContext.ToXml(false, "TransactionContext", "taller041"));
      }

      protected void wb_table1_2_0A2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTable_Internalname, tblTable_Internalname, "", "ViewTable", 0, "", "", 0, 0, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_5_0A2( true) ;
         }
         else
         {
            wb_table2_5_0A2( false) ;
         }
         return  ;
      }

      protected void wb_table2_5_0A2e( bool wbgen )
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
            wb_table1_2_0A2e( true) ;
         }
         else
         {
            wb_table1_2_0A2e( false) ;
         }
      }

      protected void wb_table2_5_0A2( bool wbgen )
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
            GxWebStd.gx_bitmap( context, imgInsert_Internalname, "", context.GetImagePath( "5649fbb8-8ce0-4810-a5ce-bd649ea83c3a", "", "GeneXusX"), "GeneXusX", 1, 1, "", "Agrega", 0, 0, 0, "", 0, "", 0, 0, "", "", 5, imgInsert_Jsonclick, sPrefix+"E\\'DOINSERT\\'.", StyleString, ClassString, "", ""+TempTags, "", "", "HLP_EnfermeroMedicoWC.htm");
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
               context.SendWebValue( "Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Apellido") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Domicilio") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Telefono") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Estado Civil") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Fecha Ingreso") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Espec. Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Especialidad Descrip.") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Suplente Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Suplente Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Suplente Apellido") ;
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
               GridColumn.AddObjectProperty("Value", context.convertURL( AV12Update));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", context.convertURL( AV13Delete));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavDelete_Tooltiptext));
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
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A15MedicoDomicilio));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A16MedicoTelefono));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A17MedicoEstadoCivil));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A18MedicoFechaIngreso, "99/99/99"));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9EspecialidadId), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A10EspecialidadDescripcion));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A51EnfermeroSuplenteId), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A52EnfermeroSuplenteNombre));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A56EnfermeroSuplenteApellido));
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
            wb_table2_5_0A2e( true) ;
         }
         else
         {
            wb_table2_5_0A2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7EnfermeroTitularId = Convert.ToInt32(getParm(obj,0)) ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "AV7EnfermeroTitularId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV7EnfermeroTitularId), 6, 0)));
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
         PA0A2( ) ;
         WS0A2( ) ;
         WE0A2( ) ;
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
         sCtrlAV7EnfermeroTitularId = (String)((String)getParm(obj,0)) ;
      }

      public override void componentrestorestate( String sPPrefix ,
                                                  String sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix ;
         PA0A2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false ;
         sCompPrefix = (String)getParm(obj,0) ;
         sSFPrefix = (String)getParm(obj,1) ;
         sPrefix = sCompPrefix + sSFPrefix ;
         AddComponentObject(sPrefix, "enfermeromedicowc");
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         PA0A2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV7EnfermeroTitularId = Convert.ToInt32(getParm(obj,2)) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "AV7EnfermeroTitularId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV7EnfermeroTitularId), 6, 0)));
         }
         wcpOAV7EnfermeroTitularId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7EnfermeroTitularId"), ",", ".")) ;
         if ( ! GetJustCreated( ) && ( ( AV7EnfermeroTitularId != wcpOAV7EnfermeroTitularId ) ) )
         {
            setjustcreated();
         }
         wcpOAV7EnfermeroTitularId = AV7EnfermeroTitularId ;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV7EnfermeroTitularId = cgiGet( sPrefix+"AV7EnfermeroTitularId_CTRL") ;
         if ( StringUtil.Len( sCtrlAV7EnfermeroTitularId) > 0 )
         {
            AV7EnfermeroTitularId = (int)(context.localUtil.CToN( cgiGet( sCtrlAV7EnfermeroTitularId), ",", ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "AV7EnfermeroTitularId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV7EnfermeroTitularId), 6, 0)));
         }
         else
         {
            AV7EnfermeroTitularId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV7EnfermeroTitularId_PARM"), ",", ".")) ;
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
         PA0A2( ) ;
         sEvt = sCompEvt ;
         WCParametersGet( ) ;
         WS0A2( ) ;
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
         WS0A2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst ;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7EnfermeroTitularId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EnfermeroTitularId), 6, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7EnfermeroTitularId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7EnfermeroTitularId_CTRL", StringUtil.RTrim( sCtrlAV7EnfermeroTitularId));
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
         WE0A2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( Form.Jscriptsrc.Item(idxLst)), "?403776");
            idxLst = (int)(idxLst+1) ;
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("enfermeromedicowc.js", "?403776");
         }
         /* End function include_jscripts */
      }

      protected void sendrow_122( )
      {
         WB0A0( ) ;
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
            GridRow.AddColumnProperties("bitmap", 2, isAjaxCallMode( ), new Object[] {(String)edtavUpdate_Internalname,(String)"",(String)AV12Update,(String)"GeneXusX",(short)-1,(short)1,(String)"",(String)edtavUpdate_Tooltiptext,(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"",(short)0,(short)0,(String)edtavUpdate_Link,(String)"",(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"",(String)"",(String)"''",(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image" ;
            StyleString = "" ;
            GridRow.AddColumnProperties("bitmap", 2, isAjaxCallMode( ), new Object[] {(String)edtavDelete_Internalname,(String)"",(String)AV13Delete,(String)"GeneXusX",(short)-1,(short)1,(String)"",(String)edtavDelete_Tooltiptext,(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"",(short)0,(short)0,(String)edtavDelete_Link,(String)"",(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"",(String)"",(String)"''",(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMedicoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12MedicoId), 6, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)6,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A12MedicoId), "ZZZZZ9"),(String)"",(short)0,(String)edtMedicoId_Jsonclick,(String)"",(short)12,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMedicoNombre_Internalname,StringUtil.RTrim( A13MedicoNombre),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A13MedicoNombre, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtMedicoNombre_Jsonclick,(String)"",(short)12,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMedicoApellido_Internalname,StringUtil.RTrim( A14MedicoApellido),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A14MedicoApellido, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtMedicoApellido_Jsonclick,(String)"",(short)12,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMedicoDomicilio_Internalname,StringUtil.RTrim( A15MedicoDomicilio),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)40,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A15MedicoDomicilio, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtMedicoDomicilio_Jsonclick,(String)"",(short)12,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMedicoTelefono_Internalname,StringUtil.RTrim( A16MedicoTelefono),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A16MedicoTelefono, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtMedicoTelefono_Jsonclick,(String)"",(short)12,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            ClassString = "Attribute" ;
            StyleString = "" ;
            if ( ( nGXsfl_12_idx == 1 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "MEDICOESTADOCIVIL_" + sGXsfl_12_idx ;
               cmbMedicoEstadoCivil.Name = GXCCtl ;
               cmbMedicoEstadoCivil.WebTags = "" ;
               cmbMedicoEstadoCivil.addItem("S", "Soltero", 0);
               cmbMedicoEstadoCivil.addItem("C", "Casado", 0);
               cmbMedicoEstadoCivil.addItem("V", "Viudo", 0);
               cmbMedicoEstadoCivil.addItem("D", "Divorciado", 0);
               if ( ( cmbMedicoEstadoCivil.ItemCount > 0 ) && String.IsNullOrEmpty(StringUtil.RTrim( A17MedicoEstadoCivil)) )
               {
                  A17MedicoEstadoCivil = cmbMedicoEstadoCivil.getItemValue(1) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A17MedicoEstadoCivil", A17MedicoEstadoCivil);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbMedicoEstadoCivil,(String)cmbMedicoEstadoCivil_Internalname,(String)A17MedicoEstadoCivil,(String)"",(String)"char",(short)-1,(short)0,(short)0,(short)1,(short)0,(short)0,(String)"px",(short)0,(String)"",(String)StyleString,(String)ClassString,(String)"",(short)0,(String)cmbMedicoEstadoCivil_Jsonclick,(String)"",(String)"",(bool)true});
            cmbMedicoEstadoCivil.CurrentValue = A17MedicoEstadoCivil ;
            context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, cmbMedicoEstadoCivil_Internalname, "Values", (String)(cmbMedicoEstadoCivil.ToJavascriptSource()));
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMedicoFechaIngreso_Internalname,context.localUtil.Format(A18MedicoFechaIngreso, "99/99/99"),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)8,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( A18MedicoFechaIngreso, "99/99/99"),(String)"",(short)0,(String)edtMedicoFechaIngreso_Jsonclick,(String)"",(short)12,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtEspecialidadId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A9EspecialidadId), 6, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)6,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A9EspecialidadId), "ZZZZZ9"),(String)"",(short)0,(String)edtEspecialidadId_Jsonclick,(String)"",(short)12,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtEspecialidadDescripcion_Internalname,StringUtil.RTrim( A10EspecialidadDescripcion),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A10EspecialidadDescripcion, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtEspecialidadDescripcion_Jsonclick,(String)"",(short)12,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtEnfermeroSuplenteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A51EnfermeroSuplenteId), 6, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)6,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A51EnfermeroSuplenteId), "ZZZZZ9"),(String)"",(short)0,(String)edtEnfermeroSuplenteId_Jsonclick,(String)"",(short)12,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtEnfermeroSuplenteNombre_Internalname,StringUtil.RTrim( A52EnfermeroSuplenteNombre),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A52EnfermeroSuplenteNombre, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtEnfermeroSuplenteNombre_Jsonclick,(String)"",(short)12,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtEnfermeroSuplenteApellido_Internalname,StringUtil.RTrim( A56EnfermeroSuplenteApellido),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A56EnfermeroSuplenteApellido, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtEnfermeroSuplenteApellido_Jsonclick,(String)"",(short)12,(short)1,(short)1,(bool)true,(String)"left"});
            GridContainer.AddRow(GridRow);
            nGXsfl_12_idx = (short)(((subGrid_Islastpage==1)&&(nGXsfl_12_idx+1>subGrid_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1)) ;
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_12_idx), 4, 0)), 4, "0") ;
            edtavUpdate_Internalname = sPrefix+"_UPDATE_"+sGXsfl_12_idx ;
            edtavDelete_Internalname = sPrefix+"_DELETE_"+sGXsfl_12_idx ;
            edtMedicoId_Internalname = sPrefix+"MEDICOID_"+sGXsfl_12_idx ;
            edtMedicoNombre_Internalname = sPrefix+"MEDICONOMBRE_"+sGXsfl_12_idx ;
            edtMedicoApellido_Internalname = sPrefix+"MEDICOAPELLIDO_"+sGXsfl_12_idx ;
            edtMedicoDomicilio_Internalname = sPrefix+"MEDICODOMICILIO_"+sGXsfl_12_idx ;
            edtMedicoTelefono_Internalname = sPrefix+"MEDICOTELEFONO_"+sGXsfl_12_idx ;
            cmbMedicoEstadoCivil_Internalname = sPrefix+"MEDICOESTADOCIVIL_"+sGXsfl_12_idx ;
            edtMedicoFechaIngreso_Internalname = sPrefix+"MEDICOFECHAINGRESO_"+sGXsfl_12_idx ;
            edtEspecialidadId_Internalname = sPrefix+"ESPECIALIDADID_"+sGXsfl_12_idx ;
            edtEspecialidadDescripcion_Internalname = sPrefix+"ESPECIALIDADDESCRIPCION_"+sGXsfl_12_idx ;
            edtEnfermeroSuplenteId_Internalname = sPrefix+"ENFERMEROSUPLENTEID_"+sGXsfl_12_idx ;
            edtEnfermeroSuplenteNombre_Internalname = sPrefix+"ENFERMEROSUPLENTENOMBRE_"+sGXsfl_12_idx ;
            edtEnfermeroSuplenteApellido_Internalname = sPrefix+"ENFERMEROSUPLENTEAPELLIDO_"+sGXsfl_12_idx ;
         }
         /* End function sendrow_122 */
      }

      protected void initialize_properties( )
      {
         imgInsert_Internalname = sPrefix+"INSERT" ;
         tblTablegridcontainer_Internalname = sPrefix+"TABLEGRIDCONTAINER" ;
         tblTable_Internalname = sPrefix+"TABLE" ;
         edtEnfermeroTitularId_Internalname = sPrefix+"ENFERMEROTITULARID" ;
         Form.Internalname = sPrefix+"FORM" ;
         subGrid_Internalname = sPrefix+"GRID" ;
         edtEnfermeroSuplenteApellido_Jsonclick = "" ;
         edtEnfermeroSuplenteNombre_Jsonclick = "" ;
         edtEnfermeroSuplenteId_Jsonclick = "" ;
         edtEspecialidadDescripcion_Jsonclick = "" ;
         edtEspecialidadId_Jsonclick = "" ;
         edtMedicoFechaIngreso_Jsonclick = "" ;
         cmbMedicoEstadoCivil_Jsonclick = "" ;
         edtMedicoTelefono_Jsonclick = "" ;
         edtMedicoDomicilio_Jsonclick = "" ;
         edtMedicoApellido_Jsonclick = "" ;
         edtMedicoNombre_Jsonclick = "" ;
         edtMedicoId_Jsonclick = "" ;
         subGrid_Class = "WorkWith" ;
         subGrid_Backcolorstyle = 3 ;
         edtavDelete_Link = "" ;
         edtavUpdate_Link = "" ;
         edtEnfermeroTitularId_Jsonclick = "" ;
         edtEnfermeroTitularId_Visible = 1 ;
         subGrid_Rows = 0 ;
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
         sPrefix = "" ;
         edtavDelete_Internalname = "" ;
         AV13Delete = "" ;
         edtavUpdate_Internalname = "" ;
         AV12Update = "" ;
         AV16Pgmname = "" ;
         GXCCtl = "" ;
         A17MedicoEstadoCivil = "" ;
         sDynURL = "" ;
         FormProcess = "" ;
         GX_FocusControl = "" ;
         ClassString = "" ;
         StyleString = "" ;
         Form = new GXWebForm();
         sXEvt = "" ;
         sEvt = "" ;
         EvtGridId = "" ;
         EvtRowId = "" ;
         sEvtType = "" ;
         edtMedicoId_Internalname = "" ;
         edtMedicoNombre_Internalname = "" ;
         edtMedicoApellido_Internalname = "" ;
         edtMedicoDomicilio_Internalname = "" ;
         edtMedicoTelefono_Internalname = "" ;
         cmbMedicoEstadoCivil_Internalname = "" ;
         edtMedicoFechaIngreso_Internalname = "" ;
         edtEspecialidadId_Internalname = "" ;
         edtEspecialidadDescripcion_Internalname = "" ;
         edtEnfermeroSuplenteId_Internalname = "" ;
         edtEnfermeroSuplenteNombre_Internalname = "" ;
         edtEnfermeroSuplenteApellido_Internalname = "" ;
         A13MedicoNombre = "" ;
         A14MedicoApellido = "" ;
         A15MedicoDomicilio = "" ;
         A16MedicoTelefono = "" ;
         A18MedicoFechaIngreso = DateTime.MinValue ;
         A10EspecialidadDescripcion = "" ;
         A52EnfermeroSuplenteNombre = "" ;
         A56EnfermeroSuplenteApellido = "" ;
         GridContainer = new GXWebGrid( context);
         scmdbuf = "" ;
         H000A2_A46EnfermeroTitularId = new int[1] ;
         H000A2_A56EnfermeroSuplenteApellido = new String[] {""} ;
         H000A2_n56EnfermeroSuplenteApellido = new bool[] {false} ;
         H000A2_A52EnfermeroSuplenteNombre = new String[] {""} ;
         H000A2_n52EnfermeroSuplenteNombre = new bool[] {false} ;
         H000A2_A51EnfermeroSuplenteId = new int[1] ;
         H000A2_A10EspecialidadDescripcion = new String[] {""} ;
         H000A2_A9EspecialidadId = new int[1] ;
         H000A2_A18MedicoFechaIngreso = new DateTime[] {DateTime.MinValue} ;
         H000A2_A17MedicoEstadoCivil = new String[] {""} ;
         H000A2_A16MedicoTelefono = new String[] {""} ;
         H000A2_A15MedicoDomicilio = new String[] {""} ;
         H000A2_A14MedicoApellido = new String[] {""} ;
         H000A2_A13MedicoNombre = new String[] {""} ;
         H000A2_A12MedicoId = new int[1] ;
         H000A3_AGRID_nRecordCount = new int[1] ;
         AV10TrnContext = new SdtTransactionContext(context);
         AV9HTTPRequest = new GxHttpRequest( context);
         AV11TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV8Session = new GxWebSession( context);
         sStyleString = "" ;
         TempTags = "" ;
         imgInsert_Jsonclick = "" ;
         subGrid_Linesclass = "" ;
         GXt_char7 = "" ;
         GXt_char6 = "" ;
         GXt_char5 = "" ;
         GXt_char4 = "" ;
         GXt_char3 = "" ;
         GXt_char2 = "" ;
         GXt_char1 = "" ;
         GXt_char8 = "" ;
         GXt_char9 = "" ;
         GXt_char10 = "" ;
         GXt_char11 = "" ;
         GXt_char12 = "" ;
         GridColumn = new GXWebColumn();
         GXt_char13 = "" ;
         GXt_char14 = "" ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV7EnfermeroTitularId = "" ;
         GridRow = new GXWebRow();
         ROClassString = "" ;
         GXt_char15 = "" ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.enfermeromedicowc__default(),
            new Object[][] {
                new Object[] {
               H000A2_A46EnfermeroTitularId, H000A2_A56EnfermeroSuplenteApellido, H000A2_n56EnfermeroSuplenteApellido, H000A2_A52EnfermeroSuplenteNombre, H000A2_n52EnfermeroSuplenteNombre, H000A2_A51EnfermeroSuplenteId, H000A2_A10EspecialidadDescripcion, H000A2_A9EspecialidadId, H000A2_A18MedicoFechaIngreso, H000A2_A17MedicoEstadoCivil,
               H000A2_A16MedicoTelefono, H000A2_A15MedicoDomicilio, H000A2_A14MedicoApellido, H000A2_A13MedicoNombre, H000A2_A12MedicoId
               }
               , new Object[] {
               H000A3_AGRID_nRecordCount
               }
            }
         );
         AV16Pgmname = "EnfermeroMedicoWC" ;
         /* GeneXus formulas. */
         AV16Pgmname = "EnfermeroMedicoWC" ;
         context.Gx_err = 0 ;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short nRC_Grid ;
      private short nGXsfl_12_idx=1 ;
      private short initialized ;
      private short nGXWrapped ;
      private short GRID_nEOF ;
      private short subGrid_Rows ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Collapsed ;
      private short subGrid_Backstyle ;
      private int AV7EnfermeroTitularId ;
      private int wcpOAV7EnfermeroTitularId ;
      private int Grid_PageSize12 ;
      private int GRID_nFirstRecordOnPage ;
      private int A46EnfermeroTitularId ;
      private int edtEnfermeroTitularId_Visible ;
      private int A12MedicoId ;
      private int A9EspecialidadId ;
      private int A51EnfermeroSuplenteId ;
      private int subGrid_Islastpage ;
      private int GRID_nCurrentRecord ;
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
      private String edtavDelete_Tooltiptext ;
      private String edtavDelete_Internalname ;
      private String edtavUpdate_Tooltiptext ;
      private String edtavUpdate_Internalname ;
      private String AV16Pgmname ;
      private String GXCCtl ;
      private String A17MedicoEstadoCivil ;
      private String sDynURL ;
      private String FormProcess ;
      private String GX_FocusControl ;
      private String ClassString ;
      private String StyleString ;
      private String edtEnfermeroTitularId_Internalname ;
      private String edtEnfermeroTitularId_Jsonclick ;
      private String sXEvt ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtMedicoId_Internalname ;
      private String edtMedicoNombre_Internalname ;
      private String edtMedicoApellido_Internalname ;
      private String edtMedicoDomicilio_Internalname ;
      private String edtMedicoTelefono_Internalname ;
      private String cmbMedicoEstadoCivil_Internalname ;
      private String edtMedicoFechaIngreso_Internalname ;
      private String edtEspecialidadId_Internalname ;
      private String edtEspecialidadDescripcion_Internalname ;
      private String edtEnfermeroSuplenteId_Internalname ;
      private String edtEnfermeroSuplenteNombre_Internalname ;
      private String edtEnfermeroSuplenteApellido_Internalname ;
      private String A13MedicoNombre ;
      private String A14MedicoApellido ;
      private String A15MedicoDomicilio ;
      private String A16MedicoTelefono ;
      private String A10EspecialidadDescripcion ;
      private String A52EnfermeroSuplenteNombre ;
      private String A56EnfermeroSuplenteApellido ;
      private String scmdbuf ;
      private String edtavUpdate_Link ;
      private String edtavDelete_Link ;
      private String sStyleString ;
      private String tblTable_Internalname ;
      private String tblTablegridcontainer_Internalname ;
      private String TempTags ;
      private String imgInsert_Internalname ;
      private String imgInsert_Jsonclick ;
      private String subGrid_Internalname ;
      private String subGrid_Class ;
      private String subGrid_Linesclass ;
      private String GXt_char7 ;
      private String GXt_char6 ;
      private String GXt_char5 ;
      private String GXt_char4 ;
      private String GXt_char3 ;
      private String GXt_char2 ;
      private String GXt_char1 ;
      private String GXt_char8 ;
      private String GXt_char9 ;
      private String GXt_char10 ;
      private String GXt_char11 ;
      private String GXt_char12 ;
      private String GXt_char13 ;
      private String GXt_char14 ;
      private String sCtrlAV7EnfermeroTitularId ;
      private String ROClassString ;
      private String edtMedicoId_Jsonclick ;
      private String edtMedicoNombre_Jsonclick ;
      private String edtMedicoApellido_Jsonclick ;
      private String edtMedicoDomicilio_Jsonclick ;
      private String edtMedicoTelefono_Jsonclick ;
      private String cmbMedicoEstadoCivil_Jsonclick ;
      private String edtMedicoFechaIngreso_Jsonclick ;
      private String edtEspecialidadId_Jsonclick ;
      private String edtEspecialidadDescripcion_Jsonclick ;
      private String edtEnfermeroSuplenteId_Jsonclick ;
      private String edtEnfermeroSuplenteNombre_Jsonclick ;
      private String edtEnfermeroSuplenteApellido_Jsonclick ;
      private String GXt_char15 ;
      private DateTime A18MedicoFechaIngreso ;
      private bool entryPointCalled ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n52EnfermeroSuplenteNombre ;
      private bool n56EnfermeroSuplenteApellido ;
      private bool returnInSub ;
      private bool AV5IsAuthorized ;
      private String AV13Delete ;
      private String AV12Update ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbMedicoEstadoCivil ;
      private IDataStoreProvider pr_default ;
      private int[] H000A2_A46EnfermeroTitularId ;
      private String[] H000A2_A56EnfermeroSuplenteApellido ;
      private bool[] H000A2_n56EnfermeroSuplenteApellido ;
      private String[] H000A2_A52EnfermeroSuplenteNombre ;
      private bool[] H000A2_n52EnfermeroSuplenteNombre ;
      private int[] H000A2_A51EnfermeroSuplenteId ;
      private String[] H000A2_A10EspecialidadDescripcion ;
      private int[] H000A2_A9EspecialidadId ;
      private DateTime[] H000A2_A18MedicoFechaIngreso ;
      private String[] H000A2_A17MedicoEstadoCivil ;
      private String[] H000A2_A16MedicoTelefono ;
      private String[] H000A2_A15MedicoDomicilio ;
      private String[] H000A2_A14MedicoApellido ;
      private String[] H000A2_A13MedicoNombre ;
      private int[] H000A2_A12MedicoId ;
      private int[] H000A3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV9HTTPRequest ;
      private GxWebSession AV8Session ;
      private SdtTransactionContext AV10TrnContext ;
      private SdtTransactionContext_Attribute AV11TrnContextAtt ;
   }

   public class enfermeromedicowc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH000A2 ;
          prmH000A2 = new Object[] {
          new Object[] {"@AV7EnfermeroTitularId",SqlDbType.Int,6,0}
          } ;
          Object[] prmH000A3 ;
          prmH000A3 = new Object[] {
          new Object[] {"@AV7EnfermeroTitularId",SqlDbType.Int,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H000A2", "SELECT T1.[EnfermeroTitularId], T2.[EnfermeroApellido] AS EnfermeroSuplenteApellido, T2.[EnfermeroNombre] AS EnfermeroSuplenteNombre, T1.[EnfermeroSuplenteId] AS EnfermeroSuplenteId, T3.[EspecialidadDescripcion], T1.[EspecialidadId], T1.[MedicoFechaIngreso], T1.[MedicoEstadoCivil], T1.[MedicoTelefono], T1.[MedicoDomicilio], T1.[MedicoApellido], T1.[MedicoNombre], T1.[MedicoId] FROM (([Medico] T1 WITH (NOLOCK) INNER JOIN [Enfermero] T2 WITH (NOLOCK) ON T2.[EnfermeroId] = T1.[EnfermeroSuplenteId]) INNER JOIN [Especialidad] T3 WITH (NOLOCK) ON T3.[EspecialidadId] = T1.[EspecialidadId]) WHERE T1.[EnfermeroTitularId] = @AV7EnfermeroTitularId ORDER BY T1.[MedicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000A2,11,0,true,false )
             ,new CursorDef("H000A3", "SELECT COUNT(*) FROM (([Medico] T1 WITH (NOLOCK) INNER JOIN [Enfermero] T3 WITH (NOLOCK) ON T3.[EnfermeroId] = T1.[EnfermeroSuplenteId]) INNER JOIN [Especialidad] T2 WITH (NOLOCK) ON T2.[EspecialidadId] = T1.[EspecialidadId]) WHERE T1.[EnfermeroTitularId] = @AV7EnfermeroTitularId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000A3,1,0,true,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((String[]) buf[3])[0] = rslt.getString(3, 20) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4) ;
                ((String[]) buf[6])[0] = rslt.getString(5, 20) ;
                ((int[]) buf[7])[0] = rslt.getInt(6) ;
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(7) ;
                ((String[]) buf[9])[0] = rslt.getString(8, 1) ;
                ((String[]) buf[10])[0] = rslt.getString(9, 20) ;
                ((String[]) buf[11])[0] = rslt.getString(10, 40) ;
                ((String[]) buf[12])[0] = rslt.getString(11, 20) ;
                ((String[]) buf[13])[0] = rslt.getString(12, 20) ;
                ((int[]) buf[14])[0] = rslt.getInt(13) ;
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
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 1 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
       }
    }

 }

}
