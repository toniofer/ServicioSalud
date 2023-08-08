/*
               File: Gx0040
        Description: Selection List Paciente
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/22/2010 3:59:23.71
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
   public class gx0040 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0040( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public gx0040( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default") ;
      }

      public void release( )
      {
      }

      public void execute( ref int aP0_pPacienteId )
      {
         this.AV13pPacienteId = aP0_pPacienteId;
         executePrivate();
         aP0_pPacienteId=this.AV13pPacienteId;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               nRC_Grid1 = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
               nGXsfl_49_idx = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
               sGXsfl_49_idx = GetNextPar( ) ;
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1 ;
                  return  ;
               }
               gxnrGrid1_newrow( nRC_Grid1, nGXsfl_49_idx, sGXsfl_49_idx) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0 ;
               GXCCtl = "PACIENTEESTADOCIVIL_" + sGXsfl_49_idx ;
               cmbPacienteEstadoCivil.Name = GXCCtl ;
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
               Grid1_PageSize49 = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
               AV6cPacienteId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV6cPacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV6cPacienteId), 6, 0)));
               AV7cPacienteNombre = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7cPacienteNombre", AV7cPacienteNombre);
               AV8cPacienteApellido = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV8cPacienteApellido", AV8cPacienteApellido);
               AV9cPacienteDomicilio = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV9cPacienteDomicilio", AV9cPacienteDomicilio);
               AV11cPacienteFechaNacimiento = context.localUtil.ParseDateParm( GetNextPar( )) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV11cPacienteFechaNacimiento", context.localUtil.Format(AV11cPacienteFechaNacimiento, "99/99/99"));
               AV12cPacienteFechaIngreso = context.localUtil.ParseDateParm( GetNextPar( )) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV12cPacienteFechaIngreso", context.localUtil.Format(AV12cPacienteFechaIngreso, "99/99/99"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1 ;
                  return  ;
               }
               gxgrGrid1_refresh( Grid1_PageSize49, AV6cPacienteId, AV7cPacienteNombre, AV8cPacienteApellido, AV9cPacienteDomicilio, AV11cPacienteFechaNacimiento, AV12cPacienteFechaIngreso) ;
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
            if ( ! entryPointCalled )
            {
               AV13pPacienteId = (int)(NumberUtil.Val( gxfirstwebparm, ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV13pPacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV13pPacienteId), 6, 0)));
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("promptmasterpage", "GeneXus.Programs.promptmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,true);
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
         PA0L2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0)) ;
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0L2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" onsubmit=\"try{return gx.csv.validForm()}catch(e){return true;}\" name=\"MAINFORM\" method=\"post\" action=\""+formatLink("gx0040.aspx") + "?" + UrlEncode("" +AV13pPacienteId)+"\" class=\""+"Form"+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
      }

      public override void RenderHtmlCloseForm( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH__CPACIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cPacienteId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH__CPACIENTENOMBRE", StringUtil.RTrim( AV7cPacienteNombre));
         GxWebStd.gx_hidden_field( context, "GXH__CPACIENTEAPELLIDO", StringUtil.RTrim( AV8cPacienteApellido));
         GxWebStd.gx_hidden_field( context, "GXH__CPACIENTEDOMICILIO", StringUtil.RTrim( AV9cPacienteDomicilio));
         GxWebStd.gx_hidden_field( context, "GXH__CPACIENTEFECHANACIMIENTO", context.localUtil.Format(AV11cPacienteFechaNacimiento, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH__CPACIENTEFECHAINGRESO", context.localUtil.Format(AV12cPacienteFechaIngreso, "99/99/99"));
         /* Send saved values. */
         GxWebStd.gx_hidden_field( context, "nRC_Grid1", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_Grid1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "_PPACIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pPacienteId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
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
            WE0L2( ) ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0L2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override String GetPgmname( )
      {
         return "Gx0040" ;
      }

      public override String GetPgmdesc( )
      {
         return "Selection List Paciente" ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("gx0040.aspx") + "?" + UrlEncode("" +AV13pPacienteId) ;
      }

      protected void WB0L0( )
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
            wb_table1_2_0L2( true) ;
         }
         else
         {
            wb_table1_2_0L2( false) ;
         }
         return  ;
      }

      protected void wb_table1_2_0L2e( bool wbgen )
      {
         if ( wbgen )
         {
         }
         wbLoad = true ;
      }

      protected void START0L2( )
      {
         wbLoad = false ;
         wbEnd = 0 ;
         wbStart = 0 ;
         Form.Meta.addItem("Generator", "GeneXus C#", 0) ;
         Form.Meta.addItem("Version", "10_1_3-34981", 0) ;
         Form.Meta.addItem("Description", "Selection List Paciente", 0) ;
         context.wjLoc = "" ;
         context.nUserReturn = 0 ;
         context.wbHandled = 0 ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false ;
         STRUP0L0( ) ;
      }

      protected void WS0L2( )
      {
         START0L2( ) ;
         EVT0L2( ) ;
      }

      protected void EVT0L2( )
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
                  if ( ( context.localUtil.CToN( cgiGet( "GXH__CPACIENTEID"), ",", ".") != Convert.ToDecimal( AV6cPacienteId )) )
                  {
                     GRID1_nFirstRecordOnPage = 0 ;
                  }
                  if ( StringUtil.StrCmp(cgiGet( "GXH__CPACIENTENOMBRE"), AV7cPacienteNombre) != 0 )
                  {
                     GRID1_nFirstRecordOnPage = 0 ;
                  }
                  if ( StringUtil.StrCmp(cgiGet( "GXH__CPACIENTEAPELLIDO"), AV8cPacienteApellido) != 0 )
                  {
                     GRID1_nFirstRecordOnPage = 0 ;
                  }
                  if ( StringUtil.StrCmp(cgiGet( "GXH__CPACIENTEDOMICILIO"), AV9cPacienteDomicilio) != 0 )
                  {
                     GRID1_nFirstRecordOnPage = 0 ;
                  }
                  if ( context.localUtil.CToD( cgiGet( "GXH__CPACIENTEFECHANACIMIENTO"), 2) != AV11cPacienteFechaNacimiento )
                  {
                     GRID1_nFirstRecordOnPage = 0 ;
                  }
                  if ( context.localUtil.CToD( cgiGet( "GXH__CPACIENTEFECHAINGRESO"), 2) != AV12cPacienteFechaIngreso )
                  {
                     GRID1_nFirstRecordOnPage = 0 ;
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
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1 ;
                              sEvt = cgiGet( "GRID1PAGING") ;
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4) ;
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4)) ;
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_49_idx = (short)(NumberUtil.Val( sEvtType, ".")) ;
                              sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_49_idx), 4, 0)), 4, "0") ;
                              edtavLinkselection_Internalname = "_LINKSELECTION_"+sGXsfl_49_idx ;
                              edtPacienteId_Internalname = "PACIENTEID_"+sGXsfl_49_idx ;
                              edtPacienteCI_Internalname = "PACIENTECI_"+sGXsfl_49_idx ;
                              edtPacienteNombre_Internalname = "PACIENTENOMBRE_"+sGXsfl_49_idx ;
                              edtPacienteApellido_Internalname = "PACIENTEAPELLIDO_"+sGXsfl_49_idx ;
                              edtPacienteDomicilio_Internalname = "PACIENTEDOMICILIO_"+sGXsfl_49_idx ;
                              cmbPacienteEstadoCivil_Internalname = "PACIENTEESTADOCIVIL_"+sGXsfl_49_idx ;
                              edtPacienteFechaNacimiento_Internalname = "PACIENTEFECHANACIMIENTO_"+sGXsfl_49_idx ;
                              edtPacienteFechaIngreso_Internalname = "PACIENTEFECHAINGRESO_"+sGXsfl_49_idx ;
                              AV5LinkSelection = cgiGet( "GXimg"+edtavLinkselection_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavLinkselection_Internalname, "Bitmap", context.convertURL( AV5LinkSelection));
                              A34PacienteId = (int)(context.localUtil.CToN( cgiGet( edtPacienteId_Internalname), ",", ".")) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
                              A41PacienteCI = cgiGet( edtPacienteCI_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
                              A35PacienteNombre = cgiGet( edtPacienteNombre_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A35PacienteNombre", A35PacienteNombre);
                              A36PacienteApellido = cgiGet( edtPacienteApellido_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A36PacienteApellido", A36PacienteApellido);
                              A37PacienteDomicilio = cgiGet( edtPacienteDomicilio_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A37PacienteDomicilio", A37PacienteDomicilio);
                              cmbPacienteEstadoCivil.Name = cmbPacienteEstadoCivil_Internalname ;
                              cmbPacienteEstadoCivil.CurrentValue = cgiGet( cmbPacienteEstadoCivil_Internalname) ;
                              A38PacienteEstadoCivil = cgiGet( cmbPacienteEstadoCivil_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A38PacienteEstadoCivil", A38PacienteEstadoCivil);
                              A39PacienteFechaNacimiento = context.localUtil.CToD( cgiGet( edtPacienteFechaNacimiento_Internalname), 2) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A39PacienteFechaNacimiento", context.localUtil.Format(A39PacienteFechaNacimiento, "99/99/99"));
                              A40PacienteFechaIngreso = context.localUtil.CToD( cgiGet( edtPacienteFechaIngreso_Internalname), 2) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A40PacienteFechaIngreso", context.localUtil.Format(A40PacienteFechaIngreso, "99/99/99"));
                              sEvtType = StringUtil.Right( sEvt, 1) ;
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1)) ;
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    dynload_actions( ) ;
                                    /* Execute user event: E110L2 */
                                    E110L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    dynload_actions( ) ;
                                    /* Execute user event: E120L2 */
                                    E120L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false ;
                                       /* Set Refresh If Cpacienteid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH__CPACIENTEID"), ",", ".") != Convert.ToDecimal( AV6cPacienteId )) )
                                       {
                                          Rfr0gs = true ;
                                       }
                                       /* Set Refresh If Cpacientenombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH__CPACIENTENOMBRE"), AV7cPacienteNombre) != 0 )
                                       {
                                          Rfr0gs = true ;
                                       }
                                       /* Set Refresh If Cpacienteapellido Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH__CPACIENTEAPELLIDO"), AV8cPacienteApellido) != 0 )
                                       {
                                          Rfr0gs = true ;
                                       }
                                       /* Set Refresh If Cpacientedomicilio Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH__CPACIENTEDOMICILIO"), AV9cPacienteDomicilio) != 0 )
                                       {
                                          Rfr0gs = true ;
                                       }
                                       /* Set Refresh If Cpacientefechanacimiento Changed */
                                       if ( context.localUtil.CToD( cgiGet( "GXH__CPACIENTEFECHANACIMIENTO"), 2) != AV11cPacienteFechaNacimiento )
                                       {
                                          Rfr0gs = true ;
                                       }
                                       /* Set Refresh If Cpacientefechaingreso Changed */
                                       if ( context.localUtil.CToD( cgiGet( "GXH__CPACIENTEFECHAINGRESO"), 2) != AV12cPacienteFechaIngreso )
                                       {
                                          Rfr0gs = true ;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: E130L2 */
                                          E130L2 ();
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

      protected void WE0L2( )
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

      protected void PA0L2( )
      {
         if ( nDonePA == 0 )
         {
            GXCCtl = "PACIENTEESTADOCIVIL_" + sGXsfl_49_idx ;
            cmbPacienteEstadoCivil.Name = GXCCtl ;
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
            GX_FocusControl = edtavCpacienteid_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            nDonePA = 1 ;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( short nRC_Grid1 ,
                                       short nGXsfl_49_idx ,
                                       String sGXsfl_49_idx )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         edtavLinkselection_Internalname = "_LINKSELECTION_"+sGXsfl_49_idx ;
         edtPacienteId_Internalname = "PACIENTEID_"+sGXsfl_49_idx ;
         edtPacienteCI_Internalname = "PACIENTECI_"+sGXsfl_49_idx ;
         edtPacienteNombre_Internalname = "PACIENTENOMBRE_"+sGXsfl_49_idx ;
         edtPacienteApellido_Internalname = "PACIENTEAPELLIDO_"+sGXsfl_49_idx ;
         edtPacienteDomicilio_Internalname = "PACIENTEDOMICILIO_"+sGXsfl_49_idx ;
         cmbPacienteEstadoCivil_Internalname = "PACIENTEESTADOCIVIL_"+sGXsfl_49_idx ;
         edtPacienteFechaNacimiento_Internalname = "PACIENTEFECHANACIMIENTO_"+sGXsfl_49_idx ;
         edtPacienteFechaIngreso_Internalname = "PACIENTEFECHAINGRESO_"+sGXsfl_49_idx ;
         while ( nGXsfl_49_idx <= nRC_Grid1 )
         {
            sendrow_492( ) ;
            nGXsfl_49_idx = (short)(((subGrid1_Islastpage==1)&&(nGXsfl_49_idx+1>subGrid1_Recordsperpage( )) ? 1 : nGXsfl_49_idx+1)) ;
            sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_49_idx), 4, 0)), 4, "0") ;
            edtavLinkselection_Internalname = "_LINKSELECTION_"+sGXsfl_49_idx ;
            edtPacienteId_Internalname = "PACIENTEID_"+sGXsfl_49_idx ;
            edtPacienteCI_Internalname = "PACIENTECI_"+sGXsfl_49_idx ;
            edtPacienteNombre_Internalname = "PACIENTENOMBRE_"+sGXsfl_49_idx ;
            edtPacienteApellido_Internalname = "PACIENTEAPELLIDO_"+sGXsfl_49_idx ;
            edtPacienteDomicilio_Internalname = "PACIENTEDOMICILIO_"+sGXsfl_49_idx ;
            cmbPacienteEstadoCivil_Internalname = "PACIENTEESTADOCIVIL_"+sGXsfl_49_idx ;
            edtPacienteFechaNacimiento_Internalname = "PACIENTEFECHANACIMIENTO_"+sGXsfl_49_idx ;
            edtPacienteFechaIngreso_Internalname = "PACIENTEFECHAINGRESO_"+sGXsfl_49_idx ;
         }
         context.GX_webresponse.AddString(Grid1Container.ToJavascriptSource());
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int Grid1_PageSize49 ,
                                        int AV6cPacienteId ,
                                        String AV7cPacienteNombre ,
                                        String AV8cPacienteApellido ,
                                        String AV9cPacienteDomicilio ,
                                        DateTime AV11cPacienteFechaNacimiento ,
                                        DateTime AV12cPacienteFechaIngreso )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         disableOutput();
         subGrid1_Rows = (short)(Grid1_PageSize49) ;
         RF0L2( ) ;
         enableOutput();
         context.GX_webresponse.AddString(Grid1Container.ToJavascriptSource());
         /* End function gxgrGrid1_refresh */
      }

      protected void Refresh( )
      {
         RF0L2( ) ;
         /* End function Refresh */
      }

      protected void RF0L2( )
      {
         Grid1Container.PageSize = subGrid1_Recordsperpage( ) ;
         wbStart = 49 ;
         nGXsfl_49_idx = 1 ;
         sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_49_idx), 4, 0)), 4, "0") ;
         edtavLinkselection_Internalname = "_LINKSELECTION_"+sGXsfl_49_idx ;
         edtPacienteId_Internalname = "PACIENTEID_"+sGXsfl_49_idx ;
         edtPacienteCI_Internalname = "PACIENTECI_"+sGXsfl_49_idx ;
         edtPacienteNombre_Internalname = "PACIENTENOMBRE_"+sGXsfl_49_idx ;
         edtPacienteApellido_Internalname = "PACIENTEAPELLIDO_"+sGXsfl_49_idx ;
         edtPacienteDomicilio_Internalname = "PACIENTEDOMICILIO_"+sGXsfl_49_idx ;
         cmbPacienteEstadoCivil_Internalname = "PACIENTEESTADOCIVIL_"+sGXsfl_49_idx ;
         edtPacienteFechaNacimiento_Internalname = "PACIENTEFECHANACIMIENTO_"+sGXsfl_49_idx ;
         edtPacienteFechaIngreso_Internalname = "PACIENTEFECHAINGRESO_"+sGXsfl_49_idx ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
         {
            lV7cPacienteNombre = StringUtil.PadR( StringUtil.RTrim( AV7cPacienteNombre), 20, "%") ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7cPacienteNombre", AV7cPacienteNombre);
            lV8cPacienteApellido = StringUtil.PadR( StringUtil.RTrim( AV8cPacienteApellido), 20, "%") ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV8cPacienteApellido", AV8cPacienteApellido);
            lV9cPacienteDomicilio = StringUtil.PadR( StringUtil.RTrim( AV9cPacienteDomicilio), 40, "%") ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV9cPacienteDomicilio", AV9cPacienteDomicilio);
            /* Using cursor H000L2 */
            pr_default.execute(0, new Object[] {AV6cPacienteId, lV7cPacienteNombre, lV8cPacienteApellido, lV9cPacienteDomicilio, AV11cPacienteFechaNacimiento, AV12cPacienteFechaIngreso});
            nGXsfl_49_idx = 1 ;
            GRID1_nEOF = 0 ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( 10 == 0 ) || ( GRID1_nCurrentRecord < GRID1_nFirstRecordOnPage + subGrid1_Recordsperpage( ) ) ) ) )
            {
               A40PacienteFechaIngreso = H000L2_A40PacienteFechaIngreso[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A40PacienteFechaIngreso", context.localUtil.Format(A40PacienteFechaIngreso, "99/99/99"));
               A39PacienteFechaNacimiento = H000L2_A39PacienteFechaNacimiento[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A39PacienteFechaNacimiento", context.localUtil.Format(A39PacienteFechaNacimiento, "99/99/99"));
               A38PacienteEstadoCivil = H000L2_A38PacienteEstadoCivil[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A38PacienteEstadoCivil", A38PacienteEstadoCivil);
               A37PacienteDomicilio = H000L2_A37PacienteDomicilio[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A37PacienteDomicilio", A37PacienteDomicilio);
               A36PacienteApellido = H000L2_A36PacienteApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A36PacienteApellido", A36PacienteApellido);
               A35PacienteNombre = H000L2_A35PacienteNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A35PacienteNombre", A35PacienteNombre);
               A41PacienteCI = H000L2_A41PacienteCI[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A41PacienteCI", A41PacienteCI);
               A34PacienteId = H000L2_A34PacienteId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
               /* Execute user event: E120L2 */
               E120L2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0)) ;
            pr_default.close(0);
            wbEnd = 49 ;
            WB0L0( ) ;
         }
      }

      protected int subGrid1_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_Recordcount( ) ;
         if ( ((int)(GRID1_nRecordCount) % (subGrid1_Recordsperpage( ))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_Recordsperpage( ))))+1) ;
      }

      protected int subGrid1_Recordcount( )
      {
         lV7cPacienteNombre = StringUtil.PadR( StringUtil.RTrim( AV7cPacienteNombre), 20, "%") ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7cPacienteNombre", AV7cPacienteNombre);
         lV8cPacienteApellido = StringUtil.PadR( StringUtil.RTrim( AV8cPacienteApellido), 20, "%") ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV8cPacienteApellido", AV8cPacienteApellido);
         lV9cPacienteDomicilio = StringUtil.PadR( StringUtil.RTrim( AV9cPacienteDomicilio), 40, "%") ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV9cPacienteDomicilio", AV9cPacienteDomicilio);
         /* Using cursor H000L3 */
         pr_default.execute(1, new Object[] {AV6cPacienteId, lV7cPacienteNombre, lV8cPacienteApellido, lV9cPacienteDomicilio, AV11cPacienteFechaNacimiento, AV12cPacienteFechaIngreso});
         GRID1_nRecordCount = H000L3_AGRID1_nRecordCount[0] ;
         pr_default.close(1);
         return GRID1_nRecordCount ;
      }

      protected int subGrid1_Recordsperpage( )
      {
         if ( 10 > 0 )
         {
            if ( 1 > 0 )
            {
               return (int)(10*1) ;
            }
            else
            {
               return (int)(10) ;
            }
         }
         return (int)(-1) ;
      }

      protected int subGrid1_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_Recordsperpage( ))))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0 ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_Recordcount( ) ;
         if ( ( GRID1_nRecordCount >= subGrid1_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (int)(GRID1_nFirstRecordOnPage+subGrid1_Recordsperpage( )) ;
         }
         else
         {
            return 2 ;
         }
         return 0 ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (int)(GRID1_nFirstRecordOnPage-subGrid1_Recordsperpage( )) ;
         }
         else
         {
            return 2 ;
         }
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_Recordcount( ) ;
         if ( GRID1_nRecordCount > subGrid1_Recordsperpage( ) )
         {
            if ( ((int)(GRID1_nRecordCount) % (subGrid1_Recordsperpage( ))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (int)(GRID1_nRecordCount-subGrid1_Recordsperpage( )) ;
            }
            else
            {
               GRID1_nFirstRecordOnPage = (int)(GRID1_nRecordCount-((int)(GRID1_nRecordCount) % (subGrid1_Recordsperpage( )))) ;
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0 ;
         }
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (int)(subGrid1_Recordsperpage( )*(nPageNo-1)) ;
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0 ;
         }
         return (int)(0) ;
      }

      protected void STRUP0L0( )
      {
         /* Before Start, stand alone formulas. */
         context.Gx_err = 0 ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0 ;
         /* Execute user event: E110L2 */
         E110L2 ();
         context.wbGlbDoneStart = 1 ;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCpacienteid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCpacienteid_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum"), 1, "_CPACIENTEID");
               GX_FocusControl = edtavCpacienteid_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true ;
               AV6cPacienteId = 0 ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV6cPacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV6cPacienteId), 6, 0)));
            }
            else
            {
               AV6cPacienteId = (int)(context.localUtil.CToN( cgiGet( edtavCpacienteid_Internalname), ",", ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV6cPacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV6cPacienteId), 6, 0)));
            }
            AV7cPacienteNombre = cgiGet( edtavCpacientenombre_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7cPacienteNombre", AV7cPacienteNombre);
            AV8cPacienteApellido = cgiGet( edtavCpacienteapellido_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV8cPacienteApellido", AV8cPacienteApellido);
            AV9cPacienteDomicilio = cgiGet( edtavCpacientedomicilio_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV9cPacienteDomicilio", AV9cPacienteDomicilio);
            if ( context.localUtil.VCDate( cgiGet( edtavCpacientefechanacimiento_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Paciente Fecha Nacimiento"}), 1, "_CPACIENTEFECHANACIMIENTO");
               GX_FocusControl = edtavCpacientefechanacimiento_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true ;
               AV11cPacienteFechaNacimiento = DateTime.MinValue ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV11cPacienteFechaNacimiento", context.localUtil.Format(AV11cPacienteFechaNacimiento, "99/99/99"));
            }
            else
            {
               AV11cPacienteFechaNacimiento = context.localUtil.CToD( cgiGet( edtavCpacientefechanacimiento_Internalname), 2) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV11cPacienteFechaNacimiento", context.localUtil.Format(AV11cPacienteFechaNacimiento, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCpacientefechaingreso_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Paciente Fecha Ingreso"}), 1, "_CPACIENTEFECHAINGRESO");
               GX_FocusControl = edtavCpacientefechaingreso_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true ;
               AV12cPacienteFechaIngreso = DateTime.MinValue ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV12cPacienteFechaIngreso", context.localUtil.Format(AV12cPacienteFechaIngreso, "99/99/99"));
            }
            else
            {
               AV12cPacienteFechaIngreso = context.localUtil.CToD( cgiGet( edtavCpacientefechaingreso_Internalname), 2) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV12cPacienteFechaIngreso", context.localUtil.Format(AV12cPacienteFechaIngreso, "99/99/99"));
            }
            /* Read saved values. */
            nRC_Grid1 = (short)(context.localUtil.CToN( cgiGet( "nRC_Grid1"), ",", ".")) ;
            AV13pPacienteId = (int)(context.localUtil.CToN( cgiGet( "_PPACIENTEID"), ",", ".")) ;
            GRID1_nFirstRecordOnPage = (int)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ",", ".")) ;
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ",", ".")) ;
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
         /* Execute user event: E110L2 */
         E110L2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E110L2( )
      {
         /* Start Routine */
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "Paciente", "", "", "", "", "", "", "", "") ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, "FORM", "Caption", Form.Caption);
      }

      private void E120L2( )
      {
         /* Load Routine */
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", "GeneXusX") ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavLinkselection_Internalname, "Bitmap", context.convertURL( AV5LinkSelection));
         if ( ( subGrid1_Islastpage == 1 ) || ( 10 == 0 ) || ( ( GRID1_nCurrentRecord >= GRID1_nFirstRecordOnPage ) && ( GRID1_nCurrentRecord < GRID1_nFirstRecordOnPage + subGrid1_Recordsperpage( ) ) ) )
         {
            sendrow_492( ) ;
         }
         GRID1_nCurrentRecord = (int)(GRID1_nCurrentRecord+1) ;
      }

      public void GXEnter( )
      {
         /* Execute user event: E130L2 */
         E130L2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E130L2( )
      {
         /* Enter Routine */
         AV13pPacienteId = A34PacienteId ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV13pPacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV13pPacienteId), 6, 0)));
         context.setWebReturnParms(new Object[] {(int)AV13pPacienteId});
         context.nUserReturn = 1 ;
         returnInSub = true;
         if (true) return;
      }

      protected void wb_table1_2_0L2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTable1_Internalname, tblTable1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td style=\"text-align:"+context.GetCssProperty( "Align", "center")+"\">") ;
            ClassString = "ErrorViewer" ;
            StyleString = "" ;
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Control Group */
            ClassString = "FieldSet" ;
            StyleString = "" ;
            context.WriteHtmlText( "<fieldset id=\""+grpGroup1_Internalname+"\""+" style=\"-moz-border-radius:3pt;\""+" class=\""+ClassString+"\">") ;
            context.WriteHtmlText( "<legend class=\""+ClassString+"Title"+"\">"+"Filters"+"</legend>") ;
            wb_table2_9_0L2( true) ;
         }
         else
         {
            wb_table2_9_0L2( false) ;
         }
         return  ;
      }

      protected void wb_table2_9_0L2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</fieldset>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Control Group */
            ClassString = "FieldSet" ;
            StyleString = "" ;
            context.WriteHtmlText( "<fieldset id=\""+grpGroup2_Internalname+"\""+" style=\"-moz-border-radius:3pt;\""+" class=\""+ClassString+"\">") ;
            context.WriteHtmlText( "<legend class=\""+ClassString+"Title"+"\">"+"Lista de Selección"+"</legend>") ;
            wb_table3_46_0L2( true) ;
         }
         else
         {
            wb_table3_46_0L2( false) ;
         }
         return  ;
      }

      protected void wb_table3_46_0L2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</fieldset>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_2_0L2e( true) ;
         }
         else
         {
            wb_table1_2_0L2e( false) ;
         }
      }

      protected void wb_table3_46_0L2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTable3_Internalname, tblTable3_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td colspan=\"3\" >") ;
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               sStyleString = "" ;
               GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "Grid", 0, "", "", 1, 0, sStyleString, "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid1_Backcolorstyle == 0 )
               {
                  subGrid1_Titlebackstyle = 0 ;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title" ;
                  }
               }
               else
               {
                  subGrid1_Titlebackstyle = 1 ;
                  if ( subGrid1_Backcolorstyle == 1 )
                  {
                     subGrid1_Titlebackcolor = subGrid1_Allbackcolor ;
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"UniformTitle" ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"Title" ;
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid1_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid1_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid1_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "CI") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid1_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid1_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Apellido") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid1_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Domicilio") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid1_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Estado Civil") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid1_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "F. Nac.") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+subGrid1_Linesclass+"\" "+" style=\""+((-1==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "F. Ingr.") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
            }
            else
            {
               Grid1Container.Clear();
               Grid1Container.SetWrapped(nGXWrapped);
               Grid1Container.AddObjectProperty("GridName", "Grid1");
               Grid1Container.AddObjectProperty("Class", "Grid");
               Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(0), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("CmpContext", "");
               Grid1Container.AddObjectProperty("InMasterPage", "false");
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A34PacienteId), 6, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A41PacienteCI));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A35PacienteNombre));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtPacienteNombre_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A36PacienteApellido));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A37PacienteDomicilio));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A38PacienteEstadoCivil));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A39PacienteFechaNacimiento, "99/99/99"));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A40PacienteFechaIngreso, "99/99/99"));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Container.AddObjectProperty("Allowselection", "false");
               Grid1Container.AddObjectProperty("Allowcollapsing", "false");
               Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 9, 0, ".", "")));
            }
         }
         if ( wbEnd == 49 )
         {
            wbEnd = 0 ;
            nRC_Grid1 = (short)(nGXsfl_49_idx-1) ;
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = " style=\"display:none;\"" ;
               sStyleString = "" ;
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", (Object)(Grid1Container));
               GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               if ( context.isAjaxRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'>") ;
               }
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td style=\"text-align:"+context.GetCssProperty( "Align", "right")+"\">") ;
            wb_table4_61_0L2( true) ;
         }
         else
         {
            wb_table4_61_0L2( false) ;
         }
         return  ;
      }

      protected void wb_table4_61_0L2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_46_0L2e( true) ;
         }
         else
         {
            wb_table3_46_0L2e( false) ;
         }
      }

      protected void wb_table4_61_0L2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTable4_Internalname, tblTable4_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"" ;
            ClassString = "BtnCancel" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtn_cancel_Internalname, "Cancelar", "Cancelar", "", StyleString, ClassString, 1, 1, "rounded", 1, bttBtn_cancel_Jsonclick, "ECANCEL.", TempTags, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(49), 3, 0)+","+"null"+");", "", "HLP_Gx0040.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_61_0L2e( true) ;
         }
         else
         {
            wb_table4_61_0L2e( false) ;
         }
      }

      protected void wb_table2_9_0L2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTable2_Internalname, tblTable2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockpacienteid_Internalname, 1, 1, 0, "Paciente Id", "", "", "", 0, lblTextblockpacienteid_Jsonclick, "", StyleString, ClassString, "HLP_Gx0040.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'" + sGXsfl_49_idx + "',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtavCpacienteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cPacienteId), 6, 0, ",", "")), "", 6, "chr", 1, "row", 6, 1, 1, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(AV6cPacienteId), "ZZZZZ9"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(14);\"", 0, edtavCpacienteid_Jsonclick, "", 0, 1, -1, true, "right", "HLP_Gx0040.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockpacientenombre_Internalname, 1, 1, 0, "Paciente Nombre", "", "", "", 0, lblTextblockpacientenombre_Jsonclick, "", StyleString, ClassString, "HLP_Gx0040.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'" + sGXsfl_49_idx + "',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtavCpacientenombre_Internalname, StringUtil.RTrim( AV7cPacienteNombre), "", 20, "chr", 1, "row", 20, 1, 1, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( AV7cPacienteNombre, "XXXXXXXXXXXXXXXXXXXX")), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(19);\"", 0, edtavCpacientenombre_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Gx0040.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockpacienteapellido_Internalname, 1, 1, 0, "Paciente Apellido", "", "", "", 0, lblTextblockpacienteapellido_Jsonclick, "", StyleString, ClassString, "HLP_Gx0040.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'" + sGXsfl_49_idx + "',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtavCpacienteapellido_Internalname, StringUtil.RTrim( AV8cPacienteApellido), "", 20, "chr", 1, "row", 20, 1, 1, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( AV8cPacienteApellido, "XXXXXXXXXXXXXXXXXXXX")), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(24);\"", 0, edtavCpacienteapellido_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Gx0040.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockpacientedomicilio_Internalname, 1, 1, 0, "Paciente Domicilio", "", "", "", 0, lblTextblockpacientedomicilio_Jsonclick, "", StyleString, ClassString, "HLP_Gx0040.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_49_idx + "',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtavCpacientedomicilio_Internalname, StringUtil.RTrim( AV9cPacienteDomicilio), "", 40, "chr", 1, "row", 40, 1, 1, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( AV9cPacienteDomicilio, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(29);\"", 0, edtavCpacientedomicilio_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Gx0040.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockpacientefechanacimiento_Internalname, 1, 1, 0, "Paciente Fecha Nacimiento", "", "", "", 0, lblTextblockpacientefechanacimiento_Jsonclick, "", StyleString, ClassString, "HLP_Gx0040.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'" + sGXsfl_49_idx + "',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            if ( ( 1 == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlText( "<table id=\""+edtavCpacientefechanacimiento_Internalname+"_dp_container\" cellpadding=\"0\" cellspacing=\"0\"><tr><td>") ;
            }
            GxWebStd.gx_single_line_edit( context, edtavCpacientefechanacimiento_Internalname, context.localUtil.Format(AV11cPacienteFechaNacimiento, "99/99/99"), "", 8, "chr", 1, "row", 8, 1, 1, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( AV11cPacienteFechaNacimiento, "99/99/99"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(37);\"", 0, edtavCpacientefechanacimiento_Jsonclick, "", 0, 1, -1, true, "right", "HLP_Gx0040.htm");
            if ( ( 1 == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlTextNl( "</td><td>") ;
               context.WriteHtmlText( "<img src=\""+context.convertURL( "calendar-img.gif")+"\" id=\""+edtavCpacientefechanacimiento_Internalname+"_dp_trigger\" style=\"cursor: pointer;\" title=\"Date selector\" alt=\"Date selector\" >") ;
               context.WriteHtmlTextNl( "</td></tr></table>") ;
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockpacientefechaingreso_Internalname, 1, 1, 0, "Paciente Fecha Ingreso", "", "", "", 0, lblTextblockpacientefechaingreso_Jsonclick, "", StyleString, ClassString, "HLP_Gx0040.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_49_idx + "',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            if ( ( 1 == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlText( "<table id=\""+edtavCpacientefechaingreso_Internalname+"_dp_container\" cellpadding=\"0\" cellspacing=\"0\"><tr><td>") ;
            }
            GxWebStd.gx_single_line_edit( context, edtavCpacientefechaingreso_Internalname, context.localUtil.Format(AV12cPacienteFechaIngreso, "99/99/99"), "", 8, "chr", 1, "row", 8, 1, 1, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( AV12cPacienteFechaIngreso, "99/99/99"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(42);\"", 0, edtavCpacientefechaingreso_Jsonclick, "", 0, 1, -1, true, "right", "HLP_Gx0040.htm");
            if ( ( 1 == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlTextNl( "</td><td>") ;
               context.WriteHtmlText( "<img src=\""+context.convertURL( "calendar-img.gif")+"\" id=\""+edtavCpacientefechaingreso_Internalname+"_dp_trigger\" style=\"cursor: pointer;\" title=\"Date selector\" alt=\"Date selector\" >") ;
               context.WriteHtmlTextNl( "</td></tr></table>") ;
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_9_0L2e( true) ;
         }
         else
         {
            wb_table2_9_0L2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13pPacienteId = Convert.ToInt32(getParm(obj,0)) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV13pPacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV13pPacienteId), 6, 0)));
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
         PA0L2( ) ;
         WS0L2( ) ;
         WE0L2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( Form.Jscriptsrc.Item(idxLst)), "?3592540");
            idxLst = (int)(idxLst+1) ;
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?34981");
         context.AddJavascriptSource("gx0040.js", "?3592540");
         /* End function include_jscripts */
      }

      protected void sendrow_492( )
      {
         WB0L0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_49_idx <= subGrid1_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container) ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0 ;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd" ;
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0 ;
               subGrid1_Backcolor = subGrid1_Allbackcolor ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, "Grid1ContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subGrid1_Backcolor), 9, 0)));
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform" ;
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1 ;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd" ;
               }
               subGrid1_Backcolor = (int)(0xF0F0F0) ;
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, "Grid1ContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subGrid1_Backcolor), 9, 0)));
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1 ;
               if ( ((int)(nGXsfl_49_idx) % (2)) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0) ;
                  context.httpAjaxContext.ajax_rsp_assign_prop("", false, "Grid1ContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subGrid1_Backcolor), 9, 0)));
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even" ;
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0xF0F0F0) ;
                  context.httpAjaxContext.ajax_rsp_assign_prop("", false, "Grid1ContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subGrid1_Backcolor), 9, 0)));
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd" ;
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+subGrid1_Linesclass+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( ">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A34PacienteId), 6, 0, ",", "")))+"'"+"]);" ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link);
            ClassString = "Image" ;
            StyleString = "" ;
            Grid1Row.AddColumnProperties("bitmap", 2, isAjaxCallMode( ), new Object[] {(String)edtavLinkselection_Internalname,(String)"",(String)AV5LinkSelection,(String)"GeneXusX",(short)-1,(short)1,(String)"",(String)"Seleccionar",(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"",(short)0,(short)0,(String)edtavLinkselection_Link,(String)"",(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"",(String)"",(String)"''",(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPacienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A34PacienteId), 6, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)6,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A34PacienteId), "ZZZZZ9"),(String)"",(short)0,(String)edtPacienteId_Jsonclick,(String)"",(short)49,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPacienteCI_Internalname,StringUtil.RTrim( A41PacienteCI),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)8,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A41PacienteCI, "XXXXXXXX")),(String)"",(short)0,(String)edtPacienteCI_Jsonclick,(String)"",(short)49,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            edtPacienteNombre_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A34PacienteId), 6, 0, ",", "")))+"'"+"]);" ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPacienteNombre_Internalname, "Link", edtPacienteNombre_Link);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPacienteNombre_Internalname,StringUtil.RTrim( A35PacienteNombre),(String)"Seleccionar",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)edtPacienteNombre_Link,(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A35PacienteNombre, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtPacienteNombre_Jsonclick,(String)"",(short)49,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPacienteApellido_Internalname,StringUtil.RTrim( A36PacienteApellido),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A36PacienteApellido, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtPacienteApellido_Jsonclick,(String)"",(short)49,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPacienteDomicilio_Internalname,StringUtil.RTrim( A37PacienteDomicilio),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)40,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A37PacienteDomicilio, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtPacienteDomicilio_Jsonclick,(String)"",(short)49,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            ClassString = "Attribute" ;
            StyleString = "" ;
            if ( ( nGXsfl_49_idx == 1 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PACIENTEESTADOCIVIL_" + sGXsfl_49_idx ;
               cmbPacienteEstadoCivil.Name = GXCCtl ;
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
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbPacienteEstadoCivil,(String)cmbPacienteEstadoCivil_Internalname,(String)A38PacienteEstadoCivil,(String)"",(String)"char",(short)-1,(short)0,(short)0,(short)1,(short)0,(short)0,(String)"px",(short)0,(String)"",(String)StyleString,(String)ClassString,(String)"",(short)0,(String)cmbPacienteEstadoCivil_Jsonclick,(String)"",(String)"",(bool)true});
            cmbPacienteEstadoCivil.CurrentValue = A38PacienteEstadoCivil ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, cmbPacienteEstadoCivil_Internalname, "Values", (String)(cmbPacienteEstadoCivil.ToJavascriptSource()));
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPacienteFechaNacimiento_Internalname,context.localUtil.Format(A39PacienteFechaNacimiento, "99/99/99"),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)8,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( A39PacienteFechaNacimiento, "99/99/99"),(String)"",(short)0,(String)edtPacienteFechaNacimiento_Jsonclick,(String)"",(short)49,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPacienteFechaIngreso_Internalname,context.localUtil.Format(A40PacienteFechaIngreso, "99/99/99"),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)8,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( A40PacienteFechaIngreso, "99/99/99"),(String)"",(short)0,(String)edtPacienteFechaIngreso_Jsonclick,(String)"",(short)49,(short)1,(short)1,(bool)true,(String)"right"});
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_49_idx = (short)(((subGrid1_Islastpage==1)&&(nGXsfl_49_idx+1>subGrid1_Recordsperpage( )) ? 1 : nGXsfl_49_idx+1)) ;
            sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_49_idx), 4, 0)), 4, "0") ;
            edtavLinkselection_Internalname = "_LINKSELECTION_"+sGXsfl_49_idx ;
            edtPacienteId_Internalname = "PACIENTEID_"+sGXsfl_49_idx ;
            edtPacienteCI_Internalname = "PACIENTECI_"+sGXsfl_49_idx ;
            edtPacienteNombre_Internalname = "PACIENTENOMBRE_"+sGXsfl_49_idx ;
            edtPacienteApellido_Internalname = "PACIENTEAPELLIDO_"+sGXsfl_49_idx ;
            edtPacienteDomicilio_Internalname = "PACIENTEDOMICILIO_"+sGXsfl_49_idx ;
            cmbPacienteEstadoCivil_Internalname = "PACIENTEESTADOCIVIL_"+sGXsfl_49_idx ;
            edtPacienteFechaNacimiento_Internalname = "PACIENTEFECHANACIMIENTO_"+sGXsfl_49_idx ;
            edtPacienteFechaIngreso_Internalname = "PACIENTEFECHAINGRESO_"+sGXsfl_49_idx ;
         }
         /* End function sendrow_492 */
      }

      public override void initialize_properties( )
      {
         lblTextblockpacienteid_Internalname = "TEXTBLOCKPACIENTEID" ;
         edtavCpacienteid_Internalname = "_CPACIENTEID" ;
         lblTextblockpacientenombre_Internalname = "TEXTBLOCKPACIENTENOMBRE" ;
         edtavCpacientenombre_Internalname = "_CPACIENTENOMBRE" ;
         lblTextblockpacienteapellido_Internalname = "TEXTBLOCKPACIENTEAPELLIDO" ;
         edtavCpacienteapellido_Internalname = "_CPACIENTEAPELLIDO" ;
         lblTextblockpacientedomicilio_Internalname = "TEXTBLOCKPACIENTEDOMICILIO" ;
         edtavCpacientedomicilio_Internalname = "_CPACIENTEDOMICILIO" ;
         lblTextblockpacientefechanacimiento_Internalname = "TEXTBLOCKPACIENTEFECHANACIMIENTO" ;
         edtavCpacientefechanacimiento_Internalname = "_CPACIENTEFECHANACIMIENTO" ;
         lblTextblockpacientefechaingreso_Internalname = "TEXTBLOCKPACIENTEFECHAINGRESO" ;
         edtavCpacientefechaingreso_Internalname = "_CPACIENTEFECHAINGRESO" ;
         tblTable2_Internalname = "TABLE2" ;
         grpGroup1_Internalname = "GROUP1" ;
         bttBtn_cancel_Internalname = "BTN_CANCEL" ;
         tblTable4_Internalname = "TABLE4" ;
         tblTable3_Internalname = "TABLE3" ;
         grpGroup2_Internalname = "GROUP2" ;
         tblTable1_Internalname = "TABLE1" ;
         Form.Internalname = "FORM" ;
         subGrid1_Internalname = "GRID1" ;
         edtPacienteFechaIngreso_Jsonclick = "" ;
         edtPacienteFechaNacimiento_Jsonclick = "" ;
         cmbPacienteEstadoCivil_Jsonclick = "" ;
         edtPacienteDomicilio_Jsonclick = "" ;
         edtPacienteApellido_Jsonclick = "" ;
         edtPacienteNombre_Jsonclick = "" ;
         edtPacienteCI_Jsonclick = "" ;
         edtPacienteId_Jsonclick = "" ;
         edtavCpacientefechaingreso_Jsonclick = "" ;
         edtavCpacientefechanacimiento_Jsonclick = "" ;
         edtavCpacientedomicilio_Jsonclick = "" ;
         edtavCpacienteapellido_Jsonclick = "" ;
         edtavCpacientenombre_Jsonclick = "" ;
         edtavCpacienteid_Jsonclick = "" ;
         edtPacienteNombre_Link = "" ;
         edtavLinkselection_Link = "" ;
         subGrid1_Class = "Grid" ;
         subGrid1_Backcolorstyle = 2 ;
         Form.Headerrawhtml = "" ;
         Form.Background = "" ;
         Form.Backcolor = (int)(0xFFFFFF) ;
         Form.Caption = "Selection List Paciente" ;
         context.GX_msglist.DisplayMode = 1 ;
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
         A38PacienteEstadoCivil = "" ;
         AV7cPacienteNombre = "" ;
         AV8cPacienteApellido = "" ;
         AV9cPacienteDomicilio = "" ;
         AV11cPacienteFechaNacimiento = DateTime.MinValue ;
         AV12cPacienteFechaIngreso = DateTime.MinValue ;
         sDynURL = "" ;
         FormProcess = "" ;
         GX_FocusControl = "" ;
         Form = new GXWebForm();
         sPrefix = "" ;
         sEvt = "" ;
         EvtGridId = "" ;
         EvtRowId = "" ;
         sEvtType = "" ;
         edtavLinkselection_Internalname = "" ;
         edtPacienteId_Internalname = "" ;
         edtPacienteCI_Internalname = "" ;
         edtPacienteNombre_Internalname = "" ;
         edtPacienteApellido_Internalname = "" ;
         edtPacienteDomicilio_Internalname = "" ;
         cmbPacienteEstadoCivil_Internalname = "" ;
         edtPacienteFechaNacimiento_Internalname = "" ;
         edtPacienteFechaIngreso_Internalname = "" ;
         AV5LinkSelection = "" ;
         A41PacienteCI = "" ;
         A35PacienteNombre = "" ;
         A36PacienteApellido = "" ;
         A37PacienteDomicilio = "" ;
         A39PacienteFechaNacimiento = DateTime.MinValue ;
         A40PacienteFechaIngreso = DateTime.MinValue ;
         Grid1Container = new GXWebGrid( context);
         scmdbuf = "" ;
         lV7cPacienteNombre = "" ;
         lV8cPacienteApellido = "" ;
         lV9cPacienteDomicilio = "" ;
         H000L2_A40PacienteFechaIngreso = new DateTime[] {DateTime.MinValue} ;
         H000L2_A39PacienteFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         H000L2_A38PacienteEstadoCivil = new String[] {""} ;
         H000L2_A37PacienteDomicilio = new String[] {""} ;
         H000L2_A36PacienteApellido = new String[] {""} ;
         H000L2_A35PacienteNombre = new String[] {""} ;
         H000L2_A41PacienteCI = new String[] {""} ;
         H000L2_A34PacienteId = new int[1] ;
         H000L3_AGRID1_nRecordCount = new int[1] ;
         sStyleString = "" ;
         ClassString = "" ;
         StyleString = "" ;
         subGrid1_Linesclass = "" ;
         GXt_char3 = "" ;
         GXt_char2 = "" ;
         GXt_char1 = "" ;
         GXt_char4 = "" ;
         GXt_char5 = "" ;
         GXt_char6 = "" ;
         GXt_char7 = "" ;
         Grid1Column = new GXWebColumn();
         GXt_char8 = "" ;
         TempTags = "" ;
         bttBtn_cancel_Jsonclick = "" ;
         lblTextblockpacienteid_Jsonclick = "" ;
         lblTextblockpacientenombre_Jsonclick = "" ;
         lblTextblockpacienteapellido_Jsonclick = "" ;
         lblTextblockpacientedomicilio_Jsonclick = "" ;
         lblTextblockpacientefechanacimiento_Jsonclick = "" ;
         lblTextblockpacientefechaingreso_Jsonclick = "" ;
         GXt_char9 = "" ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         Grid1Row = new GXWebRow();
         ROClassString = "" ;
         GXt_char10 = "" ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0040__default(),
            new Object[][] {
                new Object[] {
               H000L2_A40PacienteFechaIngreso, H000L2_A39PacienteFechaNacimiento, H000L2_A38PacienteEstadoCivil, H000L2_A37PacienteDomicilio, H000L2_A36PacienteApellido, H000L2_A35PacienteNombre, H000L2_A41PacienteCI, H000L2_A34PacienteId
               }
               , new Object[] {
               H000L3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0 ;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nRC_Grid1 ;
      private short nGXsfl_49_idx=1 ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short GRID1_nEOF ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short subGrid1_Rows ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Collapsed ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int AV13pPacienteId ;
      private int wcpOAV13pPacienteId ;
      private int Grid1_PageSize49 ;
      private int AV6cPacienteId ;
      private int GRID1_nFirstRecordOnPage ;
      private int A34PacienteId ;
      private int subGrid1_Islastpage ;
      private int GRID1_nCurrentRecord ;
      private int GRID1_nRecordCount ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_49_idx="0001" ;
      private String GXCCtl ;
      private String A38PacienteEstadoCivil ;
      private String AV7cPacienteNombre ;
      private String AV8cPacienteApellido ;
      private String AV9cPacienteDomicilio ;
      private String sDynURL ;
      private String FormProcess ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavLinkselection_Internalname ;
      private String edtPacienteId_Internalname ;
      private String edtPacienteCI_Internalname ;
      private String edtPacienteNombre_Internalname ;
      private String edtPacienteApellido_Internalname ;
      private String edtPacienteDomicilio_Internalname ;
      private String cmbPacienteEstadoCivil_Internalname ;
      private String edtPacienteFechaNacimiento_Internalname ;
      private String edtPacienteFechaIngreso_Internalname ;
      private String A41PacienteCI ;
      private String A35PacienteNombre ;
      private String A36PacienteApellido ;
      private String A37PacienteDomicilio ;
      private String edtavCpacienteid_Internalname ;
      private String scmdbuf ;
      private String lV7cPacienteNombre ;
      private String lV8cPacienteApellido ;
      private String lV9cPacienteDomicilio ;
      private String edtavCpacientenombre_Internalname ;
      private String edtavCpacienteapellido_Internalname ;
      private String edtavCpacientedomicilio_Internalname ;
      private String edtavCpacientefechanacimiento_Internalname ;
      private String edtavCpacientefechaingreso_Internalname ;
      private String sStyleString ;
      private String tblTable1_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String grpGroup1_Internalname ;
      private String grpGroup2_Internalname ;
      private String tblTable3_Internalname ;
      private String subGrid1_Internalname ;
      private String subGrid1_Class ;
      private String subGrid1_Linesclass ;
      private String GXt_char3 ;
      private String GXt_char2 ;
      private String GXt_char1 ;
      private String GXt_char4 ;
      private String GXt_char5 ;
      private String GXt_char6 ;
      private String GXt_char7 ;
      private String edtavLinkselection_Link ;
      private String edtPacienteNombre_Link ;
      private String GXt_char8 ;
      private String tblTable4_Internalname ;
      private String TempTags ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String tblTable2_Internalname ;
      private String lblTextblockpacienteid_Internalname ;
      private String lblTextblockpacienteid_Jsonclick ;
      private String edtavCpacienteid_Jsonclick ;
      private String lblTextblockpacientenombre_Internalname ;
      private String lblTextblockpacientenombre_Jsonclick ;
      private String edtavCpacientenombre_Jsonclick ;
      private String lblTextblockpacienteapellido_Internalname ;
      private String lblTextblockpacienteapellido_Jsonclick ;
      private String edtavCpacienteapellido_Jsonclick ;
      private String lblTextblockpacientedomicilio_Internalname ;
      private String lblTextblockpacientedomicilio_Jsonclick ;
      private String edtavCpacientedomicilio_Jsonclick ;
      private String lblTextblockpacientefechanacimiento_Internalname ;
      private String lblTextblockpacientefechanacimiento_Jsonclick ;
      private String edtavCpacientefechanacimiento_Jsonclick ;
      private String lblTextblockpacientefechaingreso_Internalname ;
      private String lblTextblockpacientefechaingreso_Jsonclick ;
      private String GXt_char9 ;
      private String edtavCpacientefechaingreso_Jsonclick ;
      private String ROClassString ;
      private String edtPacienteId_Jsonclick ;
      private String edtPacienteCI_Jsonclick ;
      private String edtPacienteNombre_Jsonclick ;
      private String edtPacienteApellido_Jsonclick ;
      private String edtPacienteDomicilio_Jsonclick ;
      private String cmbPacienteEstadoCivil_Jsonclick ;
      private String edtPacienteFechaNacimiento_Jsonclick ;
      private String edtPacienteFechaIngreso_Jsonclick ;
      private String GXt_char10 ;
      private DateTime AV11cPacienteFechaNacimiento ;
      private DateTime AV12cPacienteFechaIngreso ;
      private DateTime A39PacienteFechaNacimiento ;
      private DateTime A40PacienteFechaIngreso ;
      private bool entryPointCalled ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool returnInSub ;
      private String AV5LinkSelection ;
      private GXMasterPage MasterPageObj ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private int aP0_pPacienteId ;
      private GXCombobox cmbPacienteEstadoCivil ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H000L2_A40PacienteFechaIngreso ;
      private DateTime[] H000L2_A39PacienteFechaNacimiento ;
      private String[] H000L2_A38PacienteEstadoCivil ;
      private String[] H000L2_A37PacienteDomicilio ;
      private String[] H000L2_A36PacienteApellido ;
      private String[] H000L2_A35PacienteNombre ;
      private String[] H000L2_A41PacienteCI ;
      private int[] H000L2_A34PacienteId ;
      private int[] H000L3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

   public class gx0040__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH000L2 ;
          prmH000L2 = new Object[] {
          new Object[] {"@AV6cPacienteId",SqlDbType.Int,6,0} ,
          new Object[] {"@AV7cPacienteNombre",SqlDbType.Char,20,0} ,
          new Object[] {"@AV8cPacienteApellido",SqlDbType.Char,20,0} ,
          new Object[] {"@AV9cPacienteDomicilio",SqlDbType.Char,40,0} ,
          new Object[] {"@AV11cPacienteFechaNacimiento",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV12cPacienteFechaIngreso",SqlDbType.DateTime,8,0}
          } ;
          Object[] prmH000L3 ;
          prmH000L3 = new Object[] {
          new Object[] {"@AV6cPacienteId",SqlDbType.Int,6,0} ,
          new Object[] {"@AV7cPacienteNombre",SqlDbType.Char,20,0} ,
          new Object[] {"@AV8cPacienteApellido",SqlDbType.Char,20,0} ,
          new Object[] {"@AV9cPacienteDomicilio",SqlDbType.Char,40,0} ,
          new Object[] {"@AV11cPacienteFechaNacimiento",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV12cPacienteFechaIngreso",SqlDbType.DateTime,8,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H000L2", "SELECT [PacienteFechaIngreso], [PacienteFechaNacimiento], [PacienteEstadoCivil], [PacienteDomicilio], [PacienteApellido], [PacienteNombre], [PacienteCI], [PacienteId] FROM [Paciente] WITH (NOLOCK) WHERE ([PacienteId] >= @AV6cPacienteId) AND ([PacienteNombre] like @AV7cPacienteNombre) AND ([PacienteApellido] like @AV8cPacienteApellido) AND ([PacienteDomicilio] like @AV9cPacienteDomicilio) AND ([PacienteFechaNacimiento] >= @AV11cPacienteFechaNacimiento) AND ([PacienteFechaIngreso] >= @AV12cPacienteFechaIngreso) ORDER BY [PacienteId]  OPTION (FAST 11)",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000L2,11,0,false,false )
             ,new CursorDef("H000L3", "SELECT COUNT(*) FROM [Paciente] WITH (NOLOCK) WHERE ([PacienteId] >= @AV6cPacienteId) AND ([PacienteNombre] like @AV7cPacienteNombre) AND ([PacienteApellido] like @AV8cPacienteApellido) AND ([PacienteDomicilio] like @AV9cPacienteDomicilio) AND ([PacienteFechaNacimiento] >= @AV11cPacienteFechaNacimiento) AND ([PacienteFechaIngreso] >= @AV12cPacienteFechaIngreso) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000L3,1,0,false,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 1) ;
                ((String[]) buf[3])[0] = rslt.getString(4, 40) ;
                ((String[]) buf[4])[0] = rslt.getString(5, 20) ;
                ((String[]) buf[5])[0] = rslt.getString(6, 20) ;
                ((String[]) buf[6])[0] = rslt.getString(7, 8) ;
                ((int[]) buf[7])[0] = rslt.getInt(8) ;
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
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (String)parms[2]);
                stmt.SetParameter(4, (String)parms[3]);
                stmt.SetParameter(5, (DateTime)parms[4]);
                stmt.SetParameter(6, (DateTime)parms[5]);
                break;
             case 1 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (String)parms[2]);
                stmt.SetParameter(4, (String)parms[3]);
                stmt.SetParameter(5, (DateTime)parms[4]);
                stmt.SetParameter(6, (DateTime)parms[5]);
                break;
       }
    }

 }

}
