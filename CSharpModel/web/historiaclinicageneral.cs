/*
               File: HistoriaClinicaGeneral
        Description: Historia Clinica General
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/24/2010 5:13:35.81
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
   public class historiaclinicageneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public historiaclinicageneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public historiaclinicageneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default") ;
      }

      public void release( )
      {
      }

      public void execute( DateTime aP0_ConsultaFecha ,
                           int aP1_PacienteId ,
                           int aP2_MedicoId ,
                           short aP3_TurnoId )
      {
         this.A43ConsultaFecha = aP0_ConsultaFecha;
         this.A34PacienteId = aP1_PacienteId;
         this.A12MedicoId = aP2_MedicoId;
         this.A60TurnoId = aP3_TurnoId;
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
                  A43ConsultaFecha = context.localUtil.ParseDateParm( GetNextPar( )) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
                  A34PacienteId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
                  A12MedicoId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
                  A60TurnoId = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
                  componentprepare(new Object[] {(String)sCompPrefix,(String)sSFPrefix,(DateTime)A43ConsultaFecha,(int)A34PacienteId,(int)A12MedicoId,(short)A60TurnoId});
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
            PA122( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV17Pgmname = "HistoriaClinicaGeneral" ;
               context.Gx_err = 0 ;
               /* Using cursor H00122 */
               pr_default.execute(0, new Object[] {A34PacienteId});
               A41PacienteCI = H00122_A41PacienteCI[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A41PacienteCI", A41PacienteCI);
               A35PacienteNombre = H00122_A35PacienteNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A35PacienteNombre", A35PacienteNombre);
               A36PacienteApellido = H00122_A36PacienteApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A36PacienteApellido", A36PacienteApellido);
               pr_default.close(0);
               /* Using cursor H00123 */
               pr_default.execute(1, new Object[] {A12MedicoId});
               A9EspecialidadId = H00123_A9EspecialidadId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
               A13MedicoNombre = H00123_A13MedicoNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A13MedicoNombre", A13MedicoNombre);
               A14MedicoApellido = H00123_A14MedicoApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A14MedicoApellido", A14MedicoApellido);
               pr_default.close(1);
               /* Using cursor H00124 */
               pr_default.execute(2, new Object[] {A9EspecialidadId});
               A11EspecialidadMaxPacientes = H00124_A11EspecialidadMaxPacientes[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
               pr_default.close(2);
               /* Using cursor H00125 */
               pr_default.execute(3, new Object[] {A60TurnoId});
               A61TurnoNombre = H00125_A61TurnoNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A61TurnoNombre", A61TurnoNombre);
               pr_default.close(3);
               WS122( ) ;
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
            context.WriteHtmlText( "Historia Clinica General") ;
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
            FormProcess = " onkeyup=\"gx.evt.onkeyup(event)\" onkeypress=\"gx.evt.onkeypress(event,false,false)\" onkeydown=\"gx.evt.onkeypress(null,false,false)\"" ;
            context.WriteHtmlText( "<body") ;
            context.WriteHtmlText( " "+"class=\"Form\""+" "+" style=\"-moz-opacity:0;opacity:0;"+"\""+" bgcolor=\""+context.BuildHTMLColor( (int)(0xFFFFFF))+"\""+FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" onsubmit=\"try{return gx.csv.validForm()}catch(e){return true;}\" name=\"MAINFORM\" method=\"post\" action=\""+formatLink("historiaclinicageneral.aspx") + "?" + UrlEncode(DateTimeUtil.FormatDateParm(A43ConsultaFecha)) + "," + UrlEncode("" +A34PacienteId) + "," + UrlEncode("" +A12MedicoId) + "," + UrlEncode("" +A60TurnoId)+"\" class=\""+"Form"+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         }
      }

      protected void RenderHtmlCloseForm122( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA43ConsultaFecha", context.localUtil.DToC( wcpOA43ConsultaFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA34PacienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA34PacienteId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA12MedicoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA12MedicoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA60TurnoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA60TurnoId), 2, 0, ",", "")));
         if ( ( StringUtil.Len( sPrefix) != 0 ) && context.isAjaxRequest( ) )
         {
            context.AddJavascriptSource("historiaclinicageneral.js", "?513363");
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
            SendComponentObjects();
            SendServerCommands();
            SendState();
            context.WriteHtmlTextNl( "</form>") ;
            include_jscripts( ) ;
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
         }
      }

      protected void WB120( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "historiaclinicageneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            wb_table1_2_122( true) ;
         }
         else
         {
            wb_table1_2_122( false) ;
         }
         return  ;
      }

      protected void wb_table1_2_122e( bool wbgen )
      {
         if ( wbgen )
         {
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'',0)\"" ;
            ClassString = "ActionButtons" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtnupdate_Internalname, "Modifica", "Modifica", "", StyleString, ClassString, 1, 1, "rounded", 5, bttBtnupdate_Jsonclick, sPrefix+"E\\'DOUPDATE\\'.", TempTags, "", "", "HLP_HistoriaClinicaGeneral.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'',0)\"" ;
            ClassString = "ActionButtons" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtndelete_Internalname, "Eliminar", "Eliminar", "", StyleString, ClassString, 1, 1, "rounded", 5, bttBtndelete_Jsonclick, sPrefix+"E\\'DODELETE\\'.", TempTags, "", "", "HLP_HistoriaClinicaGeneral.htm");
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtTurnoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A60TurnoId), 2, 0, ",", "")), "", 2, "chr", 1, "row", 2, edtTurnoId_Visible, 0, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A60TurnoId), "Z9"), "", 0, edtTurnoId_Jsonclick, "", 0, 1, 1, true, "right", "HLP_HistoriaClinicaGeneral.htm");
            /* Multiple line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_html_textarea( context, edtMotivoConsulta_Internalname, A68MotivoConsulta, edtMotivoConsulta_Visible, 0, 0, 80, "chr", 10, "row", StyleString, ClassString, "2097152", "", -1, 2, "", "", true, "HLP_HistoriaClinicaGeneral.htm");
            /* Multiple line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_html_textarea( context, edtAnotacionesConsulta_Internalname, A69AnotacionesConsulta, edtAnotacionesConsulta_Visible, 0, 0, 80, "chr", 10, "row", StyleString, ClassString, "2097152", "", -1, 1, "", "", true, "HLP_HistoriaClinicaGeneral.htm");
         }
         wbLoad = true ;
      }

      protected void START122( )
      {
         wbLoad = false ;
         wbEnd = 0 ;
         wbStart = 0 ;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            Form.Meta.addItem("Generator", "GeneXus C#", 0) ;
            Form.Meta.addItem("Version", "10_1_3-34981", 0) ;
            Form.Meta.addItem("Description", "Historia Clinica General", 0) ;
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
               STRUP120( ) ;
            }
         }
      }

      protected void WS122( )
      {
         START122( ) ;
         EVT122( ) ;
      }

      protected void EVT122( )
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
                                 STRUP120( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP120( ) ;
                              }
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1 ;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: E11122 */
                                    E11122 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP120( ) ;
                              }
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1 ;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: E12122 */
                                    E12122 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP120( ) ;
                              }
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1 ;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: E13122 */
                                    E13122 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP120( ) ;
                              }
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1 ;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: E14122 */
                                    E14122 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP120( ) ;
                              }
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
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP120( ) ;
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
                     context.wbHandled = 1 ;
                  }
               }
            }
         }
      }

      protected void WE122( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true ;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm122( ) ;
            }
         }
      }

      protected void PA122( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            nDonePA = 1 ;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void Refresh( )
      {
         RF122( ) ;
         /* End function Refresh */
      }

      protected void RF122( )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00126 */
            pr_default.execute(4, new Object[] {A43ConsultaFecha, A34PacienteId, A12MedicoId, A60TurnoId});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A69AnotacionesConsulta = H00126_A69AnotacionesConsulta[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A69AnotacionesConsulta", A69AnotacionesConsulta);
               n69AnotacionesConsulta = H00126_n69AnotacionesConsulta[0] ;
               A68MotivoConsulta = H00126_A68MotivoConsulta[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A68MotivoConsulta", A68MotivoConsulta);
               n68MotivoConsulta = H00126_n68MotivoConsulta[0] ;
               A63ConsultaNro = H00126_A63ConsultaNro[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A63ConsultaNro", StringUtil.LTrim( StringUtil.Str( (decimal)(A63ConsultaNro), 2, 0)));
               n63ConsultaNro = H00126_n63ConsultaNro[0] ;
               /* Execute user event: E12122 */
               E12122 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(4);
            WB120( ) ;
         }
      }

      protected void STRUP120( )
      {
         /* Before Start, stand alone formulas. */
         AV17Pgmname = "HistoriaClinicaGeneral" ;
         context.Gx_err = 0 ;
         /* Using cursor H00127 */
         pr_default.execute(5, new Object[] {A34PacienteId});
         A41PacienteCI = H00127_A41PacienteCI[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A41PacienteCI", A41PacienteCI);
         A35PacienteNombre = H00127_A35PacienteNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A35PacienteNombre", A35PacienteNombre);
         A36PacienteApellido = H00127_A36PacienteApellido[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A36PacienteApellido", A36PacienteApellido);
         pr_default.close(5);
         /* Using cursor H00128 */
         pr_default.execute(6, new Object[] {A12MedicoId});
         A9EspecialidadId = H00128_A9EspecialidadId[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A9EspecialidadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9EspecialidadId), 6, 0)));
         A13MedicoNombre = H00128_A13MedicoNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A13MedicoNombre", A13MedicoNombre);
         A14MedicoApellido = H00128_A14MedicoApellido[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A14MedicoApellido", A14MedicoApellido);
         pr_default.close(6);
         /* Using cursor H00129 */
         pr_default.execute(7, new Object[] {A9EspecialidadId});
         A11EspecialidadMaxPacientes = H00129_A11EspecialidadMaxPacientes[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
         pr_default.close(7);
         /* Using cursor H001210 */
         pr_default.execute(8, new Object[] {A60TurnoId});
         A61TurnoNombre = H001210_A61TurnoNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A61TurnoNombre", A61TurnoNombre);
         pr_default.close(8);
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0 ;
         /* Execute user event: E11122 */
         E11122 ();
         context.wbGlbDoneStart = 1 ;
         nDoneStart = 1 ;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName") ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read variables values. */
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               A43ConsultaFecha = context.localUtil.CToD( cgiGet( edtConsultaFecha_Internalname), 2) ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               A34PacienteId = (int)(context.localUtil.CToN( cgiGet( edtPacienteId_Internalname), ",", ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
            }
            A36PacienteApellido = cgiGet( edtPacienteApellido_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A36PacienteApellido", A36PacienteApellido);
            A35PacienteNombre = cgiGet( edtPacienteNombre_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A35PacienteNombre", A35PacienteNombre);
            A41PacienteCI = cgiGet( edtPacienteCI_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A41PacienteCI", A41PacienteCI);
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               A12MedicoId = (int)(context.localUtil.CToN( cgiGet( edtMedicoId_Internalname), ",", ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            }
            A14MedicoApellido = cgiGet( edtMedicoApellido_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A14MedicoApellido", A14MedicoApellido);
            A13MedicoNombre = cgiGet( edtMedicoNombre_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A13MedicoNombre", A13MedicoNombre);
            A11EspecialidadMaxPacientes = (short)(context.localUtil.CToN( cgiGet( edtEspecialidadMaxPacientes_Internalname), ",", ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A11EspecialidadMaxPacientes", StringUtil.LTrim( StringUtil.Str( (decimal)(A11EspecialidadMaxPacientes), 3, 0)));
            A61TurnoNombre = cgiGet( edtTurnoNombre_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A61TurnoNombre", A61TurnoNombre);
            A63ConsultaNro = (short)(context.localUtil.CToN( cgiGet( edtConsultaNro_Internalname), ",", ".")) ;
            n63ConsultaNro = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A63ConsultaNro", StringUtil.LTrim( StringUtil.Str( (decimal)(A63ConsultaNro), 2, 0)));
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               A60TurnoId = (short)(context.localUtil.CToN( cgiGet( edtTurnoId_Internalname), ",", ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
            }
            A68MotivoConsulta = cgiGet( edtMotivoConsulta_Internalname) ;
            n68MotivoConsulta = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A68MotivoConsulta", A68MotivoConsulta);
            A69AnotacionesConsulta = cgiGet( edtAnotacionesConsulta_Internalname) ;
            n69AnotacionesConsulta = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A69AnotacionesConsulta", A69AnotacionesConsulta);
            /* Read saved values. */
            wcpOA43ConsultaFecha = context.localUtil.CToD( cgiGet( sPrefix+"wcpOA43ConsultaFecha"), 0) ;
            wcpOA34PacienteId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA34PacienteId"), ",", ".")) ;
            wcpOA12MedicoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA12MedicoId"), ",", ".")) ;
            wcpOA60TurnoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA60TurnoId"), ",", ".")) ;
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
         /* Execute user event: E11122 */
         E11122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11122( )
      {
         /* Start Routine */
         new isauthorized(context ).execute(  AV17Pgmname, out  AV5IsAuthorized) ;
         if ( ! AV5IsAuthorized )
         {
            context.wjLoc = formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV17Pgmname)) ;
         }
         /* Execute user subroutine: S112 */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E12122( )
      {
         /* Load Routine */
         edtPacienteCI_Link = formatLink("viewconsultapaciente.aspx") + "?" + UrlEncode(DateTimeUtil.FormatDateParm(A43ConsultaFecha)) + "," + UrlEncode("" +A34PacienteId) + "," + UrlEncode("" +A12MedicoId) + "," + UrlEncode("" +A60TurnoId) + "," + UrlEncode(StringUtil.RTrim("")) ;
         context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtPacienteCI_Internalname, "Link", edtPacienteCI_Link);
         edtTurnoId_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtTurnoId_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(edtTurnoId_Visible), 5, 0)));
         edtMotivoConsulta_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtMotivoConsulta_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(edtMotivoConsulta_Visible), 5, 0)));
         edtAnotacionesConsulta_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtAnotacionesConsulta_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(edtAnotacionesConsulta_Visible), 5, 0)));
      }

      protected void E13122( )
      {
         /* 'DoUpdate' Routine */
         context.wjLoc = formatLink("historiaclinica.aspx") + "?" + UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(DateTimeUtil.FormatDateParm(A43ConsultaFecha)) + "," + UrlEncode("" +A34PacienteId) + "," + UrlEncode("" +A12MedicoId) + "," + UrlEncode("" +A60TurnoId) ;
      }

      protected void E14122( )
      {
         /* 'DoDelete' Routine */
         context.wjLoc = formatLink("historiaclinica.aspx") + "?" + UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(DateTimeUtil.FormatDateParm(A43ConsultaFecha)) + "," + UrlEncode("" +A34PacienteId) + "," + UrlEncode("" +A12MedicoId) + "," + UrlEncode("" +A60TurnoId) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         AV11TrnContext = new SdtTransactionContext(context) ;
         AV11TrnContext.gxTpr_Callerobject = AV17Pgmname ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11TrnContext", (Object)(AV11TrnContext));
         AV11TrnContext.gxTpr_Callerondelete = false ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11TrnContext", (Object)(AV11TrnContext));
         AV11TrnContext.gxTpr_Callerurl = AV14HTTPRequest.ScriptName+"?"+AV14HTTPRequest.QueryString ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11TrnContext", (Object)(AV11TrnContext));
         AV11TrnContext.gxTpr_Transactionname = "HistoriaClinica" ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11TrnContext", (Object)(AV11TrnContext));
         AV12TrnContextAtt = new SdtTransactionContext_Attribute(context) ;
         AV12TrnContextAtt.gxTpr_Attributename = "ConsultaFecha" ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12TrnContextAtt", (Object)(AV12TrnContextAtt));
         AV12TrnContextAtt.gxTpr_Attributevalue = context.localUtil.DToC( AV7ConsultaFecha, 2, "/") ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12TrnContextAtt", (Object)(AV12TrnContextAtt));
         AV11TrnContext.gxTpr_Attributes.Add(AV12TrnContextAtt, 0);
         AV12TrnContextAtt = new SdtTransactionContext_Attribute(context) ;
         AV12TrnContextAtt.gxTpr_Attributename = "PacienteId" ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12TrnContextAtt", (Object)(AV12TrnContextAtt));
         AV12TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV8PacienteId), 6, 0) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12TrnContextAtt", (Object)(AV12TrnContextAtt));
         AV11TrnContext.gxTpr_Attributes.Add(AV12TrnContextAtt, 0);
         AV12TrnContextAtt = new SdtTransactionContext_Attribute(context) ;
         AV12TrnContextAtt.gxTpr_Attributename = "MedicoId" ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12TrnContextAtt", (Object)(AV12TrnContextAtt));
         AV12TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV9MedicoId), 6, 0) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12TrnContextAtt", (Object)(AV12TrnContextAtt));
         AV11TrnContext.gxTpr_Attributes.Add(AV12TrnContextAtt, 0);
         AV12TrnContextAtt = new SdtTransactionContext_Attribute(context) ;
         AV12TrnContextAtt.gxTpr_Attributename = "TurnoId" ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12TrnContextAtt", (Object)(AV12TrnContextAtt));
         AV12TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV10TurnoId), 2, 0) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12TrnContextAtt", (Object)(AV12TrnContextAtt));
         AV11TrnContext.gxTpr_Attributes.Add(AV12TrnContextAtt, 0);
         AV13Session.Set("TrnContext", AV11TrnContext.ToXml(false, "TransactionContext", "taller041"));
      }

      protected void wb_table1_2_122( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTbl2_Internalname, tblTbl2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockconsultafecha_Internalname, 1, 1, 0, "Consulta Fecha", "", "", "", 0, lblTextblockconsultafecha_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinicaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            if ( ( 0 == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlText( "<table id=\""+edtConsultaFecha_Internalname+"_dp_container\" cellpadding=\"0\" cellspacing=\"0\"><tr><td>") ;
            }
            GxWebStd.gx_single_line_edit( context, edtConsultaFecha_Internalname, context.localUtil.Format(A43ConsultaFecha, "99/99/99"), "", 8, "chr", 1, "row", 8, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( A43ConsultaFecha, "99/99/99"), "", 0, edtConsultaFecha_Jsonclick, "", 0, 1, 1, true, "right", "HLP_HistoriaClinicaGeneral.htm");
            if ( ( 0 == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlTextNl( "</td><td>") ;
               context.WriteHtmlText( "<img src=\""+context.convertURL( "calendar-img.gif")+"\" id=\""+edtConsultaFecha_Internalname+"_dp_trigger\" style=\"cursor: pointer;\" title=\"Date selector\" alt=\"Date selector\" >") ;
               context.WriteHtmlTextNl( "</td></tr></table>") ;
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockpacienteid_Internalname, 1, 1, 0, "Paciente Id", "", "", "", 0, lblTextblockpacienteid_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinicaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtPacienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A34PacienteId), 6, 0, ",", "")), "", 6, "chr", 1, "row", 6, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A34PacienteId), "ZZZZZ9"), "", 0, edtPacienteId_Jsonclick, "", 0, 1, 1, true, "right", "HLP_HistoriaClinicaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockpacienteapellido_Internalname, 1, 1, 0, "Paciente Apellido", "", "", "", 0, lblTextblockpacienteapellido_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinicaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtPacienteApellido_Internalname, StringUtil.RTrim( A36PacienteApellido), "", 20, "chr", 1, "row", 20, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A36PacienteApellido, "XXXXXXXXXXXXXXXXXXXX")), "", 0, edtPacienteApellido_Jsonclick, "", 0, 1, 1, true, "left", "HLP_HistoriaClinicaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockpacientenombre_Internalname, 1, 1, 0, "Paciente Nombre", "", "", "", 0, lblTextblockpacientenombre_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinicaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtPacienteNombre_Internalname, StringUtil.RTrim( A35PacienteNombre), "", 20, "chr", 1, "row", 20, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A35PacienteNombre, "XXXXXXXXXXXXXXXXXXXX")), "", 0, edtPacienteNombre_Jsonclick, "", 0, 1, 1, true, "left", "HLP_HistoriaClinicaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockpacienteci_Internalname, 1, 1, 0, "Paciente CI", "", "", "", 0, lblTextblockpacienteci_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinicaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtPacienteCI_Internalname, StringUtil.RTrim( A41PacienteCI), "", 8, "chr", 1, "row", 8, 1, 0, 0, 0, 0, edtPacienteCI_Link, "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A41PacienteCI, "XXXXXXXX")), "", 0, edtPacienteCI_Jsonclick, "", 0, 1, 1, true, "left", "HLP_HistoriaClinicaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockmedicoid_Internalname, 1, 1, 0, "Medico Id", "", "", "", 0, lblTextblockmedicoid_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinicaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtMedicoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12MedicoId), 6, 0, ",", "")), "", 6, "chr", 1, "row", 6, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A12MedicoId), "ZZZZZ9"), "", 0, edtMedicoId_Jsonclick, "", 0, 1, 1, true, "right", "HLP_HistoriaClinicaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockmedicoapellido_Internalname, 1, 1, 0, "Medico Apellido", "", "", "", 0, lblTextblockmedicoapellido_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinicaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtMedicoApellido_Internalname, StringUtil.RTrim( A14MedicoApellido), "", 20, "chr", 1, "row", 20, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A14MedicoApellido, "XXXXXXXXXXXXXXXXXXXX")), "", 0, edtMedicoApellido_Jsonclick, "", 0, 1, 1, true, "left", "HLP_HistoriaClinicaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockmediconombre_Internalname, 1, 1, 0, "Medico Nombre", "", "", "", 0, lblTextblockmediconombre_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinicaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtMedicoNombre_Internalname, StringUtil.RTrim( A13MedicoNombre), "", 20, "chr", 1, "row", 20, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A13MedicoNombre, "XXXXXXXXXXXXXXXXXXXX")), "", 0, edtMedicoNombre_Jsonclick, "", 0, 1, 1, true, "left", "HLP_HistoriaClinicaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockespecialidadmaxpacientes_Internalname, 1, 1, 0, "Especialidad Max Pacientes", "", "", "", 0, lblTextblockespecialidadmaxpacientes_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinicaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtEspecialidadMaxPacientes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11EspecialidadMaxPacientes), 3, 0, ",", "")), "", 3, "chr", 1, "row", 3, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A11EspecialidadMaxPacientes), "ZZ9"), "", 0, edtEspecialidadMaxPacientes_Jsonclick, "", 0, 1, 1, true, "right", "HLP_HistoriaClinicaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockturnonombre_Internalname, 1, 1, 0, "Turno Nombre", "", "", "", 0, lblTextblockturnonombre_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinicaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtTurnoNombre_Internalname, StringUtil.RTrim( A61TurnoNombre), "", 20, "chr", 1, "row", 20, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A61TurnoNombre, "XXXXXXXXXXXXXXXXXXXX")), "", 0, edtTurnoNombre_Jsonclick, "", 0, 1, 1, true, "left", "HLP_HistoriaClinicaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockconsultanro_Internalname, 1, 1, 0, "Nro", "", "", "", 0, lblTextblockconsultanro_Jsonclick, "", StyleString, ClassString, "HLP_HistoriaClinicaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtConsultaNro_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A63ConsultaNro), 2, 0, ",", "")), "", 2, "chr", 1, "row", 2, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A63ConsultaNro), "Z9"), "", 0, edtConsultaNro_Jsonclick, "", 0, 1, 1, true, "right", "HLP_HistoriaClinicaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_2_122e( true) ;
         }
         else
         {
            wb_table1_2_122e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A43ConsultaFecha = (DateTime)getParm(obj,0) ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         A34PacienteId = Convert.ToInt32(getParm(obj,1)) ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
         A12MedicoId = Convert.ToInt32(getParm(obj,2)) ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
         A60TurnoId = Convert.ToInt16(getParm(obj,3)) ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
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
         PA122( ) ;
         WS122( ) ;
         WE122( ) ;
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
         sCtrlA43ConsultaFecha = (String)((String)getParm(obj,0)) ;
         sCtrlA34PacienteId = (String)((String)getParm(obj,1)) ;
         sCtrlA12MedicoId = (String)((String)getParm(obj,2)) ;
         sCtrlA60TurnoId = (String)((String)getParm(obj,3)) ;
      }

      public override void componentrestorestate( String sPPrefix ,
                                                  String sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix ;
         PA122( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false ;
         sCompPrefix = (String)getParm(obj,0) ;
         sSFPrefix = (String)getParm(obj,1) ;
         sPrefix = sCompPrefix + sSFPrefix ;
         AddComponentObject(sPrefix, "historiaclinicageneral");
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         PA122( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A43ConsultaFecha = (DateTime)getParm(obj,2) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            A34PacienteId = Convert.ToInt32(getParm(obj,3)) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
            A12MedicoId = Convert.ToInt32(getParm(obj,4)) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            A60TurnoId = Convert.ToInt16(getParm(obj,5)) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
         }
         wcpOA43ConsultaFecha = context.localUtil.CToD( cgiGet( sPrefix+"wcpOA43ConsultaFecha"), 0) ;
         wcpOA34PacienteId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA34PacienteId"), ",", ".")) ;
         wcpOA12MedicoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA12MedicoId"), ",", ".")) ;
         wcpOA60TurnoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA60TurnoId"), ",", ".")) ;
         if ( ! GetJustCreated( ) && ( ( A43ConsultaFecha != wcpOA43ConsultaFecha ) || ( A34PacienteId != wcpOA34PacienteId ) || ( A12MedicoId != wcpOA12MedicoId ) || ( A60TurnoId != wcpOA60TurnoId ) ) )
         {
            setjustcreated();
         }
         wcpOA43ConsultaFecha = A43ConsultaFecha ;
         wcpOA34PacienteId = A34PacienteId ;
         wcpOA12MedicoId = A12MedicoId ;
         wcpOA60TurnoId = A60TurnoId ;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA43ConsultaFecha = cgiGet( sPrefix+"A43ConsultaFecha_CTRL") ;
         if ( StringUtil.Len( sCtrlA43ConsultaFecha) > 0 )
         {
            A43ConsultaFecha = context.localUtil.CToD( cgiGet( sCtrlA43ConsultaFecha), 2) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         }
         else
         {
            A43ConsultaFecha = context.localUtil.CToD( cgiGet( sPrefix+"A43ConsultaFecha_PARM"), 0) ;
         }
         sCtrlA34PacienteId = cgiGet( sPrefix+"A34PacienteId_CTRL") ;
         if ( StringUtil.Len( sCtrlA34PacienteId) > 0 )
         {
            A34PacienteId = (int)(context.localUtil.CToN( cgiGet( sCtrlA34PacienteId), ",", ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A34PacienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A34PacienteId), 6, 0)));
         }
         else
         {
            A34PacienteId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"A34PacienteId_PARM"), ",", ".")) ;
         }
         sCtrlA12MedicoId = cgiGet( sPrefix+"A12MedicoId_CTRL") ;
         if ( StringUtil.Len( sCtrlA12MedicoId) > 0 )
         {
            A12MedicoId = (int)(context.localUtil.CToN( cgiGet( sCtrlA12MedicoId), ",", ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
         }
         else
         {
            A12MedicoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"A12MedicoId_PARM"), ",", ".")) ;
         }
         sCtrlA60TurnoId = cgiGet( sPrefix+"A60TurnoId_CTRL") ;
         if ( StringUtil.Len( sCtrlA60TurnoId) > 0 )
         {
            A60TurnoId = (short)(context.localUtil.CToN( cgiGet( sCtrlA60TurnoId), ",", ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
         }
         else
         {
            A60TurnoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"A60TurnoId_PARM"), ",", ".")) ;
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
         PA122( ) ;
         sEvt = sCompEvt ;
         WCParametersGet( ) ;
         WS122( ) ;
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
         WS122( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst ;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A43ConsultaFecha_PARM", context.localUtil.DToC( A43ConsultaFecha, 0, "/"));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA43ConsultaFecha)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A43ConsultaFecha_CTRL", StringUtil.RTrim( sCtrlA43ConsultaFecha));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"A34PacienteId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A34PacienteId), 6, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA34PacienteId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A34PacienteId_CTRL", StringUtil.RTrim( sCtrlA34PacienteId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"A12MedicoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12MedicoId), 6, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA12MedicoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A12MedicoId_CTRL", StringUtil.RTrim( sCtrlA12MedicoId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"A60TurnoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A60TurnoId), 2, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA60TurnoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A60TurnoId_CTRL", StringUtil.RTrim( sCtrlA60TurnoId));
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
         WE122( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( Form.Jscriptsrc.Item(idxLst)), "?5133720");
            idxLst = (int)(idxLst+1) ;
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("historiaclinicageneral.js", "?5133720");
         /* End function include_jscripts */
      }

      protected void initialize_properties( )
      {
         lblTextblockconsultafecha_Internalname = sPrefix+"TEXTBLOCKCONSULTAFECHA" ;
         edtConsultaFecha_Internalname = sPrefix+"CONSULTAFECHA" ;
         lblTextblockpacienteid_Internalname = sPrefix+"TEXTBLOCKPACIENTEID" ;
         edtPacienteId_Internalname = sPrefix+"PACIENTEID" ;
         lblTextblockpacienteapellido_Internalname = sPrefix+"TEXTBLOCKPACIENTEAPELLIDO" ;
         edtPacienteApellido_Internalname = sPrefix+"PACIENTEAPELLIDO" ;
         lblTextblockpacientenombre_Internalname = sPrefix+"TEXTBLOCKPACIENTENOMBRE" ;
         edtPacienteNombre_Internalname = sPrefix+"PACIENTENOMBRE" ;
         lblTextblockpacienteci_Internalname = sPrefix+"TEXTBLOCKPACIENTECI" ;
         edtPacienteCI_Internalname = sPrefix+"PACIENTECI" ;
         lblTextblockmedicoid_Internalname = sPrefix+"TEXTBLOCKMEDICOID" ;
         edtMedicoId_Internalname = sPrefix+"MEDICOID" ;
         lblTextblockmedicoapellido_Internalname = sPrefix+"TEXTBLOCKMEDICOAPELLIDO" ;
         edtMedicoApellido_Internalname = sPrefix+"MEDICOAPELLIDO" ;
         lblTextblockmediconombre_Internalname = sPrefix+"TEXTBLOCKMEDICONOMBRE" ;
         edtMedicoNombre_Internalname = sPrefix+"MEDICONOMBRE" ;
         lblTextblockespecialidadmaxpacientes_Internalname = sPrefix+"TEXTBLOCKESPECIALIDADMAXPACIENTES" ;
         edtEspecialidadMaxPacientes_Internalname = sPrefix+"ESPECIALIDADMAXPACIENTES" ;
         lblTextblockturnonombre_Internalname = sPrefix+"TEXTBLOCKTURNONOMBRE" ;
         edtTurnoNombre_Internalname = sPrefix+"TURNONOMBRE" ;
         lblTextblockconsultanro_Internalname = sPrefix+"TEXTBLOCKCONSULTANRO" ;
         edtConsultaNro_Internalname = sPrefix+"CONSULTANRO" ;
         tblTbl2_Internalname = sPrefix+"TBL2" ;
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE" ;
         bttBtndelete_Internalname = sPrefix+"BTNDELETE" ;
         edtTurnoId_Internalname = sPrefix+"TURNOID" ;
         edtMotivoConsulta_Internalname = sPrefix+"MOTIVOCONSULTA" ;
         edtAnotacionesConsulta_Internalname = sPrefix+"ANOTACIONESCONSULTA" ;
         Form.Internalname = sPrefix+"FORM" ;
         edtConsultaNro_Jsonclick = "" ;
         edtTurnoNombre_Jsonclick = "" ;
         edtEspecialidadMaxPacientes_Jsonclick = "" ;
         edtMedicoNombre_Jsonclick = "" ;
         edtMedicoApellido_Jsonclick = "" ;
         edtMedicoId_Jsonclick = "" ;
         edtPacienteCI_Jsonclick = "" ;
         edtPacienteNombre_Jsonclick = "" ;
         edtPacienteApellido_Jsonclick = "" ;
         edtPacienteId_Jsonclick = "" ;
         edtConsultaFecha_Jsonclick = "" ;
         edtPacienteCI_Link = "" ;
         edtAnotacionesConsulta_Visible = 1 ;
         edtMotivoConsulta_Visible = 1 ;
         edtTurnoId_Jsonclick = "" ;
         edtTurnoId_Visible = 1 ;
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
         wcpOA43ConsultaFecha = DateTime.MinValue ;
         gxfirstwebparm = "" ;
         gxfirstwebparm_bkp = "" ;
         sPrefix = "" ;
         AV17Pgmname = "" ;
         scmdbuf = "" ;
         H00122_A41PacienteCI = new String[] {""} ;
         H00122_A35PacienteNombre = new String[] {""} ;
         H00122_A36PacienteApellido = new String[] {""} ;
         A41PacienteCI = "" ;
         A35PacienteNombre = "" ;
         A36PacienteApellido = "" ;
         H00123_A9EspecialidadId = new int[1] ;
         H00123_A13MedicoNombre = new String[] {""} ;
         H00123_A14MedicoApellido = new String[] {""} ;
         A13MedicoNombre = "" ;
         A14MedicoApellido = "" ;
         H00124_A11EspecialidadMaxPacientes = new short[1] ;
         H00125_A61TurnoNombre = new String[] {""} ;
         A61TurnoNombre = "" ;
         sDynURL = "" ;
         FormProcess = "" ;
         GXt_char1 = "" ;
         GXt_char2 = "" ;
         GXt_char3 = "" ;
         GXt_char4 = "" ;
         GX_FocusControl = "" ;
         TempTags = "" ;
         ClassString = "" ;
         StyleString = "" ;
         bttBtnupdate_Jsonclick = "" ;
         bttBtndelete_Jsonclick = "" ;
         A68MotivoConsulta = "" ;
         A69AnotacionesConsulta = "" ;
         Form = new GXWebForm();
         sXEvt = "" ;
         sEvt = "" ;
         EvtGridId = "" ;
         EvtRowId = "" ;
         sEvtType = "" ;
         H00126_A9EspecialidadId = new int[1] ;
         H00126_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         H00126_A34PacienteId = new int[1] ;
         H00126_A12MedicoId = new int[1] ;
         H00126_A60TurnoId = new short[1] ;
         H00126_A69AnotacionesConsulta = new String[] {""} ;
         H00126_n69AnotacionesConsulta = new bool[] {false} ;
         H00126_A68MotivoConsulta = new String[] {""} ;
         H00126_n68MotivoConsulta = new bool[] {false} ;
         H00126_A63ConsultaNro = new short[1] ;
         H00126_n63ConsultaNro = new bool[] {false} ;
         H00126_A61TurnoNombre = new String[] {""} ;
         H00126_A11EspecialidadMaxPacientes = new short[1] ;
         H00126_A13MedicoNombre = new String[] {""} ;
         H00126_A14MedicoApellido = new String[] {""} ;
         H00126_A41PacienteCI = new String[] {""} ;
         H00126_A35PacienteNombre = new String[] {""} ;
         H00126_A36PacienteApellido = new String[] {""} ;
         H00127_A41PacienteCI = new String[] {""} ;
         H00127_A35PacienteNombre = new String[] {""} ;
         H00127_A36PacienteApellido = new String[] {""} ;
         H00128_A9EspecialidadId = new int[1] ;
         H00128_A13MedicoNombre = new String[] {""} ;
         H00128_A14MedicoApellido = new String[] {""} ;
         H00129_A11EspecialidadMaxPacientes = new short[1] ;
         H001210_A61TurnoNombre = new String[] {""} ;
         AV11TrnContext = new SdtTransactionContext(context);
         AV14HTTPRequest = new GxHttpRequest( context);
         AV12TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV7ConsultaFecha = DateTime.MinValue ;
         AV13Session = new GxWebSession( context);
         sStyleString = "" ;
         lblTextblockconsultafecha_Jsonclick = "" ;
         lblTextblockpacienteid_Jsonclick = "" ;
         lblTextblockpacienteapellido_Jsonclick = "" ;
         lblTextblockpacientenombre_Jsonclick = "" ;
         lblTextblockpacienteci_Jsonclick = "" ;
         lblTextblockmedicoid_Jsonclick = "" ;
         lblTextblockmedicoapellido_Jsonclick = "" ;
         lblTextblockmediconombre_Jsonclick = "" ;
         lblTextblockespecialidadmaxpacientes_Jsonclick = "" ;
         lblTextblockturnonombre_Jsonclick = "" ;
         lblTextblockconsultanro_Jsonclick = "" ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA43ConsultaFecha = "" ;
         sCtrlA34PacienteId = "" ;
         sCtrlA12MedicoId = "" ;
         sCtrlA60TurnoId = "" ;
         GXt_char5 = "" ;
         GXt_char6 = "" ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.historiaclinicageneral__default(),
            new Object[][] {
                new Object[] {
               H00122_A41PacienteCI, H00122_A35PacienteNombre, H00122_A36PacienteApellido
               }
               , new Object[] {
               H00123_A9EspecialidadId, H00123_A13MedicoNombre, H00123_A14MedicoApellido
               }
               , new Object[] {
               H00124_A11EspecialidadMaxPacientes
               }
               , new Object[] {
               H00125_A61TurnoNombre
               }
               , new Object[] {
               H00126_A9EspecialidadId, H00126_A43ConsultaFecha, H00126_A34PacienteId, H00126_A12MedicoId, H00126_A60TurnoId, H00126_A69AnotacionesConsulta, H00126_n69AnotacionesConsulta, H00126_A68MotivoConsulta, H00126_n68MotivoConsulta, H00126_A63ConsultaNro,
               H00126_n63ConsultaNro, H00126_A61TurnoNombre, H00126_A11EspecialidadMaxPacientes, H00126_A13MedicoNombre, H00126_A14MedicoApellido, H00126_A41PacienteCI, H00126_A35PacienteNombre, H00126_A36PacienteApellido
               }
               , new Object[] {
               H00127_A41PacienteCI, H00127_A35PacienteNombre, H00127_A36PacienteApellido
               }
               , new Object[] {
               H00128_A9EspecialidadId, H00128_A13MedicoNombre, H00128_A14MedicoApellido
               }
               , new Object[] {
               H00129_A11EspecialidadMaxPacientes
               }
               , new Object[] {
               H001210_A61TurnoNombre
               }
            }
         );
         AV17Pgmname = "HistoriaClinicaGeneral" ;
         /* GeneXus formulas. */
         AV17Pgmname = "HistoriaClinicaGeneral" ;
         context.Gx_err = 0 ;
      }

      private short A60TurnoId ;
      private short wcpOA60TurnoId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short A11EspecialidadMaxPacientes ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short A63ConsultaNro ;
      private short AV10TurnoId ;
      private short nGXWrapped ;
      private int A34PacienteId ;
      private int A12MedicoId ;
      private int wcpOA34PacienteId ;
      private int wcpOA12MedicoId ;
      private int A9EspecialidadId ;
      private int edtTurnoId_Visible ;
      private int edtMotivoConsulta_Visible ;
      private int edtAnotacionesConsulta_Visible ;
      private int AV8PacienteId ;
      private int AV9MedicoId ;
      private int idxLst ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sPrefix ;
      private String sCompPrefix ;
      private String sSFPrefix ;
      private String AV17Pgmname ;
      private String scmdbuf ;
      private String A41PacienteCI ;
      private String A35PacienteNombre ;
      private String A36PacienteApellido ;
      private String A13MedicoNombre ;
      private String A14MedicoApellido ;
      private String A61TurnoNombre ;
      private String sDynURL ;
      private String FormProcess ;
      private String GXt_char1 ;
      private String GXt_char2 ;
      private String GXt_char3 ;
      private String GXt_char4 ;
      private String GX_FocusControl ;
      private String TempTags ;
      private String ClassString ;
      private String StyleString ;
      private String bttBtnupdate_Internalname ;
      private String bttBtnupdate_Jsonclick ;
      private String bttBtndelete_Internalname ;
      private String bttBtndelete_Jsonclick ;
      private String edtTurnoId_Internalname ;
      private String edtTurnoId_Jsonclick ;
      private String edtMotivoConsulta_Internalname ;
      private String edtAnotacionesConsulta_Internalname ;
      private String sXEvt ;
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
      private String edtTurnoNombre_Internalname ;
      private String edtConsultaNro_Internalname ;
      private String edtPacienteCI_Link ;
      private String sStyleString ;
      private String tblTbl2_Internalname ;
      private String lblTextblockconsultafecha_Internalname ;
      private String lblTextblockconsultafecha_Jsonclick ;
      private String edtConsultaFecha_Jsonclick ;
      private String lblTextblockpacienteid_Internalname ;
      private String lblTextblockpacienteid_Jsonclick ;
      private String edtPacienteId_Jsonclick ;
      private String lblTextblockpacienteapellido_Internalname ;
      private String lblTextblockpacienteapellido_Jsonclick ;
      private String edtPacienteApellido_Jsonclick ;
      private String lblTextblockpacientenombre_Internalname ;
      private String lblTextblockpacientenombre_Jsonclick ;
      private String edtPacienteNombre_Jsonclick ;
      private String lblTextblockpacienteci_Internalname ;
      private String lblTextblockpacienteci_Jsonclick ;
      private String edtPacienteCI_Jsonclick ;
      private String lblTextblockmedicoid_Internalname ;
      private String lblTextblockmedicoid_Jsonclick ;
      private String edtMedicoId_Jsonclick ;
      private String lblTextblockmedicoapellido_Internalname ;
      private String lblTextblockmedicoapellido_Jsonclick ;
      private String edtMedicoApellido_Jsonclick ;
      private String lblTextblockmediconombre_Internalname ;
      private String lblTextblockmediconombre_Jsonclick ;
      private String edtMedicoNombre_Jsonclick ;
      private String lblTextblockespecialidadmaxpacientes_Internalname ;
      private String lblTextblockespecialidadmaxpacientes_Jsonclick ;
      private String edtEspecialidadMaxPacientes_Jsonclick ;
      private String lblTextblockturnonombre_Internalname ;
      private String lblTextblockturnonombre_Jsonclick ;
      private String edtTurnoNombre_Jsonclick ;
      private String lblTextblockconsultanro_Internalname ;
      private String lblTextblockconsultanro_Jsonclick ;
      private String edtConsultaNro_Jsonclick ;
      private String sCtrlA43ConsultaFecha ;
      private String sCtrlA34PacienteId ;
      private String sCtrlA12MedicoId ;
      private String sCtrlA60TurnoId ;
      private String GXt_char5 ;
      private String GXt_char6 ;
      private DateTime A43ConsultaFecha ;
      private DateTime wcpOA43ConsultaFecha ;
      private DateTime AV7ConsultaFecha ;
      private bool entryPointCalled ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n69AnotacionesConsulta ;
      private bool n68MotivoConsulta ;
      private bool n63ConsultaNro ;
      private bool returnInSub ;
      private bool AV5IsAuthorized ;
      private String A68MotivoConsulta ;
      private String A69AnotacionesConsulta ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private String[] H00122_A41PacienteCI ;
      private String[] H00122_A35PacienteNombre ;
      private String[] H00122_A36PacienteApellido ;
      private int[] H00123_A9EspecialidadId ;
      private String[] H00123_A13MedicoNombre ;
      private String[] H00123_A14MedicoApellido ;
      private short[] H00124_A11EspecialidadMaxPacientes ;
      private String[] H00125_A61TurnoNombre ;
      private int[] H00126_A9EspecialidadId ;
      private DateTime[] H00126_A43ConsultaFecha ;
      private int[] H00126_A34PacienteId ;
      private int[] H00126_A12MedicoId ;
      private short[] H00126_A60TurnoId ;
      private String[] H00126_A69AnotacionesConsulta ;
      private bool[] H00126_n69AnotacionesConsulta ;
      private String[] H00126_A68MotivoConsulta ;
      private bool[] H00126_n68MotivoConsulta ;
      private short[] H00126_A63ConsultaNro ;
      private bool[] H00126_n63ConsultaNro ;
      private String[] H00126_A61TurnoNombre ;
      private short[] H00126_A11EspecialidadMaxPacientes ;
      private String[] H00126_A13MedicoNombre ;
      private String[] H00126_A14MedicoApellido ;
      private String[] H00126_A41PacienteCI ;
      private String[] H00126_A35PacienteNombre ;
      private String[] H00126_A36PacienteApellido ;
      private String[] H00127_A41PacienteCI ;
      private String[] H00127_A35PacienteNombre ;
      private String[] H00127_A36PacienteApellido ;
      private int[] H00128_A9EspecialidadId ;
      private String[] H00128_A13MedicoNombre ;
      private String[] H00128_A14MedicoApellido ;
      private short[] H00129_A11EspecialidadMaxPacientes ;
      private String[] H001210_A61TurnoNombre ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV14HTTPRequest ;
      private GxWebSession AV13Session ;
      private SdtTransactionContext AV11TrnContext ;
      private SdtTransactionContext_Attribute AV12TrnContextAtt ;
   }

   public class historiaclinicageneral__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00122 ;
          prmH00122 = new Object[] {
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmH00123 ;
          prmH00123 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmH00124 ;
          prmH00124 = new Object[] {
          new Object[] {"@EspecialidadId",SqlDbType.Int,6,0}
          } ;
          Object[] prmH00125 ;
          prmH00125 = new Object[] {
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmH00126 ;
          prmH00126 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@PacienteId",SqlDbType.Int,6,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmH00127 ;
          prmH00127 = new Object[] {
          new Object[] {"@PacienteId",SqlDbType.Int,6,0}
          } ;
          Object[] prmH00128 ;
          prmH00128 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmH00129 ;
          prmH00129 = new Object[] {
          new Object[] {"@EspecialidadId",SqlDbType.Int,6,0}
          } ;
          Object[] prmH001210 ;
          prmH001210 = new Object[] {
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H00122", "SELECT [PacienteCI], [PacienteNombre], [PacienteApellido] FROM [Paciente] WITH (NOLOCK) WHERE [PacienteId] = @PacienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00122,1,0,true,true )
             ,new CursorDef("H00123", "SELECT [EspecialidadId], [MedicoNombre], [MedicoApellido] FROM [Medico] WITH (NOLOCK) WHERE [MedicoId] = @MedicoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00123,1,0,true,true )
             ,new CursorDef("H00124", "SELECT [EspecialidadMaxPacientes] FROM [Especialidad] WITH (NOLOCK) WHERE [EspecialidadId] = @EspecialidadId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00124,1,0,true,true )
             ,new CursorDef("H00125", "SELECT [TurnoNombre] FROM [Turno] WITH (NOLOCK) WHERE [TurnoId] = @TurnoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00125,1,0,true,true )
             ,new CursorDef("H00126", "SELECT T3.[EspecialidadId], T1.[ConsultaFecha], T1.[PacienteId], T1.[MedicoId], T1.[TurnoId], T1.[AnotacionesConsulta], T1.[MotivoConsulta], T1.[ConsultaNro], T5.[TurnoNombre], T4.[EspecialidadMaxPacientes], T3.[MedicoNombre], T3.[MedicoApellido], T2.[PacienteCI], T2.[PacienteNombre], T2.[PacienteApellido] FROM (((([ConsultaPaciente] T1 WITH (NOLOCK) INNER JOIN [Paciente] T2 WITH (NOLOCK) ON T2.[PacienteId] = T1.[PacienteId]) INNER JOIN [Medico] T3 WITH (NOLOCK) ON T3.[MedicoId] = T1.[MedicoId]) INNER JOIN [Especialidad] T4 WITH (NOLOCK) ON T4.[EspecialidadId] = T3.[EspecialidadId]) INNER JOIN [Turno] T5 WITH (NOLOCK) ON T5.[TurnoId] = T1.[TurnoId]) WHERE T1.[ConsultaFecha] = @ConsultaFecha and T1.[PacienteId] = @PacienteId and T1.[MedicoId] = @MedicoId and T1.[TurnoId] = @TurnoId ORDER BY T1.[ConsultaFecha], T1.[PacienteId], T1.[MedicoId], T1.[TurnoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00126,1,0,true,true )
             ,new CursorDef("H00127", "SELECT [PacienteCI], [PacienteNombre], [PacienteApellido] FROM [Paciente] WITH (NOLOCK) WHERE [PacienteId] = @PacienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00127,1,0,true,true )
             ,new CursorDef("H00128", "SELECT [EspecialidadId], [MedicoNombre], [MedicoApellido] FROM [Medico] WITH (NOLOCK) WHERE [MedicoId] = @MedicoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00128,1,0,true,true )
             ,new CursorDef("H00129", "SELECT [EspecialidadMaxPacientes] FROM [Especialidad] WITH (NOLOCK) WHERE [EspecialidadId] = @EspecialidadId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00129,1,0,true,true )
             ,new CursorDef("H001210", "SELECT [TurnoNombre] FROM [Turno] WITH (NOLOCK) WHERE [TurnoId] = @TurnoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001210,1,0,true,true )
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
                ((String[]) buf[0])[0] = rslt.getString(1, 8) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                break;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                break;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                break;
             case 3 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                break;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                ((int[]) buf[3])[0] = rslt.getInt(4) ;
                ((short[]) buf[4])[0] = rslt.getShort(5) ;
                ((String[]) buf[5])[0] = rslt.getLongVarchar(6) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((String[]) buf[7])[0] = rslt.getLongVarchar(7) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((short[]) buf[9])[0] = rslt.getShort(8) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((String[]) buf[11])[0] = rslt.getString(9, 20) ;
                ((short[]) buf[12])[0] = rslt.getShort(10) ;
                ((String[]) buf[13])[0] = rslt.getString(11, 20) ;
                ((String[]) buf[14])[0] = rslt.getString(12, 20) ;
                ((String[]) buf[15])[0] = rslt.getString(13, 8) ;
                ((String[]) buf[16])[0] = rslt.getString(14, 20) ;
                ((String[]) buf[17])[0] = rslt.getString(15, 20) ;
                break;
             case 5 :
                ((String[]) buf[0])[0] = rslt.getString(1, 8) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                break;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                break;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                break;
             case 8 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
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
                stmt.SetParameter(1, (short)parms[0]);
                break;
             case 4 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                stmt.SetParameter(4, (short)parms[3]);
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
                stmt.SetParameter(1, (short)parms[0]);
                break;
       }
    }

 }

}
