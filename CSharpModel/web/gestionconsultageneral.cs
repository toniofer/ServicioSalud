/*
               File: GestionConsultaGeneral
        Description: Gestion Consulta General
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/24/2010 5:52:6.0
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
   public class gestionconsultageneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public gestionconsultageneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public gestionconsultageneral( IGxContext context )
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
         this.A43ConsultaFecha = aP0_ConsultaFecha;
         this.A12MedicoId = aP1_MedicoId;
         this.A60TurnoId = aP2_TurnoId;
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
                  A12MedicoId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
                  A60TurnoId = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
                  componentprepare(new Object[] {(String)sCompPrefix,(String)sSFPrefix,(DateTime)A43ConsultaFecha,(int)A12MedicoId,(short)A60TurnoId});
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
            PA0H2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV16Pgmname = "GestionConsultaGeneral" ;
               context.Gx_err = 0 ;
               /* Using cursor H000H2 */
               pr_default.execute(0, new Object[] {A12MedicoId});
               A13MedicoNombre = H000H2_A13MedicoNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A13MedicoNombre", A13MedicoNombre);
               A14MedicoApellido = H000H2_A14MedicoApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A14MedicoApellido", A14MedicoApellido);
               pr_default.close(0);
               /* Using cursor H000H3 */
               pr_default.execute(1, new Object[] {A60TurnoId});
               A61TurnoNombre = H000H3_A61TurnoNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A61TurnoNombre", A61TurnoNombre);
               pr_default.close(1);
               /* Using cursor H000H5 */
               pr_default.execute(2, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
               if ( (pr_default.getStatus(2) != 101) )
               {
                  A70CantPacConf = H000H5_A70CantPacConf[0] ;
                  context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A70CantPacConf", StringUtil.LTrim( StringUtil.Str( (decimal)(A70CantPacConf), 2, 0)));
                  n70CantPacConf = H000H5_n70CantPacConf[0] ;
               }
               else
               {
                  A70CantPacConf = 0 ;
                  n70CantPacConf = false ;
                  context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A70CantPacConf", StringUtil.LTrim( StringUtil.Str( (decimal)(A70CantPacConf), 2, 0)));
               }
               pr_default.close(2);
               /* Using cursor H000H8 */
               pr_default.execute(3, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
               A65NrosDisponibles = H000H8_A65NrosDisponibles[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A65NrosDisponibles", StringUtil.LTrim( StringUtil.Str( (decimal)(A65NrosDisponibles), 2, 0)));
               n65NrosDisponibles = H000H8_n65NrosDisponibles[0] ;
               pr_default.close(3);
               /* Using cursor H000H10 */
               pr_default.execute(4, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
               if ( (pr_default.getStatus(4) != 101) )
               {
                  A66CantNrosAsig = H000H10_A66CantNrosAsig[0] ;
                  context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
                  n66CantNrosAsig = H000H10_n66CantNrosAsig[0] ;
               }
               else
               {
                  A66CantNrosAsig = 0 ;
                  n66CantNrosAsig = false ;
                  context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
               }
               pr_default.close(4);
               WS0H2( ) ;
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
            context.WriteHtmlText( "Gestion Consulta General") ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" onsubmit=\"try{return gx.csv.validForm()}catch(e){return true;}\" name=\"MAINFORM\" method=\"post\" action=\""+formatLink("gestionconsultageneral.aspx") + "?" + UrlEncode(DateTimeUtil.FormatDateParm(A43ConsultaFecha)) + "," + UrlEncode("" +A12MedicoId) + "," + UrlEncode("" +A60TurnoId)+"\" class=\""+"Form"+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         }
      }

      protected void RenderHtmlCloseForm0H2( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA43ConsultaFecha", context.localUtil.DToC( wcpOA43ConsultaFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA12MedicoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA12MedicoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA60TurnoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA60TurnoId), 2, 0, ",", "")));
         if ( ( StringUtil.Len( sPrefix) != 0 ) && context.isAjaxRequest( ) )
         {
            context.AddJavascriptSource("gestionconsultageneral.js", "?552644");
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

      protected void WB0H0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "gestionconsultageneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            wb_table1_2_0H2( true) ;
         }
         else
         {
            wb_table1_2_0H2( false) ;
         }
         return  ;
      }

      protected void wb_table1_2_0H2e( bool wbgen )
      {
         if ( wbgen )
         {
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'',0)\"" ;
            ClassString = "ActionButtons" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtnupdate_Internalname, "Modifica", "Modifica", "", StyleString, ClassString, 1, 1, "rounded", 5, bttBtnupdate_Jsonclick, sPrefix+"E\\'DOUPDATE\\'.", TempTags, "", "", "HLP_GestionConsultaGeneral.htm");
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtTurnoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A60TurnoId), 2, 0, ",", "")), "", 2, "chr", 1, "row", 2, edtTurnoId_Visible, 0, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A60TurnoId), "Z9"), "", 0, edtTurnoId_Jsonclick, "", 0, 1, 1, true, "right", "HLP_GestionConsultaGeneral.htm");
         }
         wbLoad = true ;
      }

      protected void START0H2( )
      {
         wbLoad = false ;
         wbEnd = 0 ;
         wbStart = 0 ;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            Form.Meta.addItem("Generator", "GeneXus C#", 0) ;
            Form.Meta.addItem("Version", "10_1_3-34981", 0) ;
            Form.Meta.addItem("Description", "Gestion Consulta General", 0) ;
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
               STRUP0H0( ) ;
            }
         }
      }

      protected void WS0H2( )
      {
         START0H2( ) ;
         EVT0H2( ) ;
      }

      protected void EVT0H2( )
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
                                 STRUP0H0( ) ;
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
                                 STRUP0H0( ) ;
                              }
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1 ;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: E110H2 */
                                    E110H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0H0( ) ;
                              }
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1 ;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: E120H2 */
                                    E120H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0H0( ) ;
                              }
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1 ;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: E130H2 */
                                    E130H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0H0( ) ;
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
                                 STRUP0H0( ) ;
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

      protected void WE0H2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true ;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0H2( ) ;
            }
         }
      }

      protected void PA0H2( )
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
         RF0H2( ) ;
         /* End function Refresh */
      }

      protected void RF0H2( )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H000H15 */
            pr_default.execute(5, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A67UltimoNroAsig = H000H15_A67UltimoNroAsig[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
               n67UltimoNroAsig = H000H15_n67UltimoNroAsig[0] ;
               A57ConsultorioId = H000H15_A57ConsultorioId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A57ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A57ConsultorioId), 3, 0)));
               A70CantPacConf = H000H15_A70CantPacConf[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A70CantPacConf", StringUtil.LTrim( StringUtil.Str( (decimal)(A70CantPacConf), 2, 0)));
               n70CantPacConf = H000H15_n70CantPacConf[0] ;
               A65NrosDisponibles = H000H15_A65NrosDisponibles[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A65NrosDisponibles", StringUtil.LTrim( StringUtil.Str( (decimal)(A65NrosDisponibles), 2, 0)));
               n65NrosDisponibles = H000H15_n65NrosDisponibles[0] ;
               A66CantNrosAsig = H000H15_A66CantNrosAsig[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
               n66CantNrosAsig = H000H15_n66CantNrosAsig[0] ;
               A70CantPacConf = H000H15_A70CantPacConf[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A70CantPacConf", StringUtil.LTrim( StringUtil.Str( (decimal)(A70CantPacConf), 2, 0)));
               n70CantPacConf = H000H15_n70CantPacConf[0] ;
               A65NrosDisponibles = H000H15_A65NrosDisponibles[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A65NrosDisponibles", StringUtil.LTrim( StringUtil.Str( (decimal)(A65NrosDisponibles), 2, 0)));
               n65NrosDisponibles = H000H15_n65NrosDisponibles[0] ;
               A66CantNrosAsig = H000H15_A66CantNrosAsig[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
               n66CantNrosAsig = H000H15_n66CantNrosAsig[0] ;
               /* Execute user event: E120H2 */
               E120H2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(5);
            WB0H0( ) ;
         }
      }

      protected void STRUP0H0( )
      {
         /* Before Start, stand alone formulas. */
         AV16Pgmname = "GestionConsultaGeneral" ;
         context.Gx_err = 0 ;
         /* Using cursor H000H16 */
         pr_default.execute(6, new Object[] {A12MedicoId});
         A13MedicoNombre = H000H16_A13MedicoNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A13MedicoNombre", A13MedicoNombre);
         A14MedicoApellido = H000H16_A14MedicoApellido[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A14MedicoApellido", A14MedicoApellido);
         pr_default.close(6);
         /* Using cursor H000H17 */
         pr_default.execute(7, new Object[] {A60TurnoId});
         A61TurnoNombre = H000H17_A61TurnoNombre[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A61TurnoNombre", A61TurnoNombre);
         pr_default.close(7);
         /* Using cursor H000H19 */
         pr_default.execute(8, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A70CantPacConf = H000H19_A70CantPacConf[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A70CantPacConf", StringUtil.LTrim( StringUtil.Str( (decimal)(A70CantPacConf), 2, 0)));
            n70CantPacConf = H000H19_n70CantPacConf[0] ;
         }
         else
         {
            A70CantPacConf = 0 ;
            n70CantPacConf = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A70CantPacConf", StringUtil.LTrim( StringUtil.Str( (decimal)(A70CantPacConf), 2, 0)));
         }
         pr_default.close(8);
         /* Using cursor H000H22 */
         pr_default.execute(9, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         A65NrosDisponibles = H000H22_A65NrosDisponibles[0] ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A65NrosDisponibles", StringUtil.LTrim( StringUtil.Str( (decimal)(A65NrosDisponibles), 2, 0)));
         n65NrosDisponibles = H000H22_n65NrosDisponibles[0] ;
         pr_default.close(9);
         /* Using cursor H000H24 */
         pr_default.execute(10, new Object[] {A43ConsultaFecha, A12MedicoId, A60TurnoId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A66CantNrosAsig = H000H24_A66CantNrosAsig[0] ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
            n66CantNrosAsig = H000H24_n66CantNrosAsig[0] ;
         }
         else
         {
            A66CantNrosAsig = 0 ;
            n66CantNrosAsig = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
         }
         pr_default.close(10);
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0 ;
         /* Execute user event: E110H2 */
         E110H2 ();
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
               A12MedicoId = (int)(context.localUtil.CToN( cgiGet( edtMedicoId_Internalname), ",", ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            }
            A14MedicoApellido = cgiGet( edtMedicoApellido_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A14MedicoApellido", A14MedicoApellido);
            A13MedicoNombre = cgiGet( edtMedicoNombre_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A13MedicoNombre", A13MedicoNombre);
            A61TurnoNombre = cgiGet( edtTurnoNombre_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A61TurnoNombre", A61TurnoNombre);
            A57ConsultorioId = (short)(context.localUtil.CToN( cgiGet( edtConsultorioId_Internalname), ",", ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A57ConsultorioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A57ConsultorioId), 3, 0)));
            A66CantNrosAsig = (short)(context.localUtil.CToN( cgiGet( edtCantNrosAsig_Internalname), ",", ".")) ;
            n66CantNrosAsig = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A66CantNrosAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A66CantNrosAsig), 2, 0)));
            A65NrosDisponibles = (short)(context.localUtil.CToN( cgiGet( edtNrosDisponibles_Internalname), ",", ".")) ;
            n65NrosDisponibles = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A65NrosDisponibles", StringUtil.LTrim( StringUtil.Str( (decimal)(A65NrosDisponibles), 2, 0)));
            A67UltimoNroAsig = (short)(context.localUtil.CToN( cgiGet( edtUltimoNroAsig_Internalname), ",", ".")) ;
            n67UltimoNroAsig = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A67UltimoNroAsig", StringUtil.LTrim( StringUtil.Str( (decimal)(A67UltimoNroAsig), 2, 0)));
            A70CantPacConf = (short)(context.localUtil.CToN( cgiGet( edtCantPacConf_Internalname), ",", ".")) ;
            n70CantPacConf = false ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A70CantPacConf", StringUtil.LTrim( StringUtil.Str( (decimal)(A70CantPacConf), 2, 0)));
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               A60TurnoId = (short)(context.localUtil.CToN( cgiGet( edtTurnoId_Internalname), ",", ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
            }
            /* Read saved values. */
            wcpOA43ConsultaFecha = context.localUtil.CToD( cgiGet( sPrefix+"wcpOA43ConsultaFecha"), 0) ;
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
         /* Execute user event: E110H2 */
         E110H2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E110H2( )
      {
         /* Start Routine */
         new isauthorized(context ).execute(  AV16Pgmname, out  AV5IsAuthorized) ;
         if ( ! AV5IsAuthorized )
         {
            context.wjLoc = formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV16Pgmname)) ;
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

      protected void E120H2( )
      {
         /* Load Routine */
         edtTurnoId_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, edtTurnoId_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(edtTurnoId_Visible), 5, 0)));
      }

      protected void E130H2( )
      {
         /* 'DoUpdate' Routine */
         context.wjLoc = formatLink("gestionconsulta.aspx") + "?" + UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(DateTimeUtil.FormatDateParm(A43ConsultaFecha)) + "," + UrlEncode("" +A12MedicoId) + "," + UrlEncode("" +A60TurnoId) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         AV10TrnContext = new SdtTransactionContext(context) ;
         AV10TrnContext.gxTpr_Callerobject = AV16Pgmname ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10TrnContext", (Object)(AV10TrnContext));
         AV10TrnContext.gxTpr_Callerondelete = false ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10TrnContext", (Object)(AV10TrnContext));
         AV10TrnContext.gxTpr_Callerurl = AV13HTTPRequest.ScriptName+"?"+AV13HTTPRequest.QueryString ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10TrnContext", (Object)(AV10TrnContext));
         AV10TrnContext.gxTpr_Transactionname = "GestionConsulta" ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10TrnContext", (Object)(AV10TrnContext));
         AV11TrnContextAtt = new SdtTransactionContext_Attribute(context) ;
         AV11TrnContextAtt.gxTpr_Attributename = "ConsultaFecha" ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11TrnContextAtt", (Object)(AV11TrnContextAtt));
         AV11TrnContextAtt.gxTpr_Attributevalue = context.localUtil.DToC( AV7ConsultaFecha, 2, "/") ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11TrnContextAtt", (Object)(AV11TrnContextAtt));
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV11TrnContextAtt = new SdtTransactionContext_Attribute(context) ;
         AV11TrnContextAtt.gxTpr_Attributename = "MedicoId" ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11TrnContextAtt", (Object)(AV11TrnContextAtt));
         AV11TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV8MedicoId), 6, 0) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11TrnContextAtt", (Object)(AV11TrnContextAtt));
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV11TrnContextAtt = new SdtTransactionContext_Attribute(context) ;
         AV11TrnContextAtt.gxTpr_Attributename = "TurnoId" ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11TrnContextAtt", (Object)(AV11TrnContextAtt));
         AV11TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV9TurnoId), 2, 0) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11TrnContextAtt", (Object)(AV11TrnContextAtt));
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV12Session.Set("TrnContext", AV10TrnContext.ToXml(false, "TransactionContext", "taller041"));
      }

      protected void wb_table1_2_0H2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblTextblockconsultafecha_Internalname, 1, 1, 0, "Fecha", "", "", "", 0, lblTextblockconsultafecha_Jsonclick, "", StyleString, ClassString, "HLP_GestionConsultaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            if ( ( 0 == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlText( "<table id=\""+edtConsultaFecha_Internalname+"_dp_container\" cellpadding=\"0\" cellspacing=\"0\"><tr><td>") ;
            }
            GxWebStd.gx_single_line_edit( context, edtConsultaFecha_Internalname, context.localUtil.Format(A43ConsultaFecha, "99/99/99"), "", 8, "chr", 1, "row", 8, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( A43ConsultaFecha, "99/99/99"), "", 0, edtConsultaFecha_Jsonclick, "", 0, 1, 1, true, "right", "HLP_GestionConsultaGeneral.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockmedicoid_Internalname, 1, 1, 0, "Medico Id", "", "", "", 0, lblTextblockmedicoid_Jsonclick, "", StyleString, ClassString, "HLP_GestionConsultaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtMedicoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12MedicoId), 6, 0, ",", "")), "", 6, "chr", 1, "row", 6, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A12MedicoId), "ZZZZZ9"), "", 0, edtMedicoId_Jsonclick, "", 0, 1, 1, true, "right", "HLP_GestionConsultaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockmedicoapellido_Internalname, 1, 1, 0, "Medico Apellido", "", "", "", 0, lblTextblockmedicoapellido_Jsonclick, "", StyleString, ClassString, "HLP_GestionConsultaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtMedicoApellido_Internalname, StringUtil.RTrim( A14MedicoApellido), "", 20, "chr", 1, "row", 20, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A14MedicoApellido, "XXXXXXXXXXXXXXXXXXXX")), "", 0, edtMedicoApellido_Jsonclick, "", 0, 1, 1, true, "left", "HLP_GestionConsultaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockmediconombre_Internalname, 1, 1, 0, "Medico Nombre", "", "", "", 0, lblTextblockmediconombre_Jsonclick, "", StyleString, ClassString, "HLP_GestionConsultaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtMedicoNombre_Internalname, StringUtil.RTrim( A13MedicoNombre), "", 20, "chr", 1, "row", 20, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A13MedicoNombre, "XXXXXXXXXXXXXXXXXXXX")), "", 0, edtMedicoNombre_Jsonclick, "", 0, 1, 1, true, "left", "HLP_GestionConsultaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockturnonombre_Internalname, 1, 1, 0, "Turno Nombre", "", "", "", 0, lblTextblockturnonombre_Jsonclick, "", StyleString, ClassString, "HLP_GestionConsultaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtTurnoNombre_Internalname, StringUtil.RTrim( A61TurnoNombre), "", 20, "chr", 1, "row", 20, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A61TurnoNombre, "XXXXXXXXXXXXXXXXXXXX")), "", 0, edtTurnoNombre_Jsonclick, "", 0, 1, 1, true, "left", "HLP_GestionConsultaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockconsultorioid_Internalname, 1, 1, 0, "Consultorio Id", "", "", "", 0, lblTextblockconsultorioid_Jsonclick, "", StyleString, ClassString, "HLP_GestionConsultaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtConsultorioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A57ConsultorioId), 3, 0, ",", "")), "", 3, "chr", 1, "row", 3, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A57ConsultorioId), "ZZ9"), "", 0, edtConsultorioId_Jsonclick, "", 0, 1, 1, true, "right", "HLP_GestionConsultaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockcantnrosasig_Internalname, 1, 1, 0, "Nros.Asig.", "", "", "", 0, lblTextblockcantnrosasig_Jsonclick, "", StyleString, ClassString, "HLP_GestionConsultaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtCantNrosAsig_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A66CantNrosAsig), 2, 0, ",", "")), "", 2, "chr", 1, "row", 2, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A66CantNrosAsig), "Z9"), "", 0, edtCantNrosAsig_Jsonclick, "", 0, 1, 1, true, "right", "HLP_GestionConsultaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblocknrosdisponibles_Internalname, 1, 1, 0, "Nros.Disp.", "", "", "", 0, lblTextblocknrosdisponibles_Jsonclick, "", StyleString, ClassString, "HLP_GestionConsultaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtNrosDisponibles_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A65NrosDisponibles), 2, 0, ",", "")), "", 2, "chr", 1, "row", 2, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A65NrosDisponibles), "Z9"), "", 0, edtNrosDisponibles_Jsonclick, "", 0, 1, 1, true, "right", "HLP_GestionConsultaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockultimonroasig_Internalname, 1, 1, 0, "Ult.Nro.Asig.", "", "", "", 0, lblTextblockultimonroasig_Jsonclick, "", StyleString, ClassString, "HLP_GestionConsultaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtUltimoNroAsig_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A67UltimoNroAsig), 2, 0, ",", "")), "", 2, "chr", 1, "row", 2, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A67UltimoNroAsig), "Z9"), "", 0, edtUltimoNroAsig_Jsonclick, "", 0, 1, 1, true, "right", "HLP_GestionConsultaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockcantpacconf_Internalname, 1, 1, 0, "Pac Conf", "", "", "", 0, lblTextblockcantpacconf_Jsonclick, "", StyleString, ClassString, "HLP_GestionConsultaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtCantPacConf_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A70CantPacConf), 2, 0, ",", "")), "", 2, "chr", 1, "row", 2, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A70CantPacConf), "Z9"), "", 0, edtCantPacConf_Jsonclick, "", 0, 1, 1, true, "right", "HLP_GestionConsultaGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_2_0H2e( true) ;
         }
         else
         {
            wb_table1_2_0H2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A43ConsultaFecha = (DateTime)getParm(obj,0) ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
         A12MedicoId = Convert.ToInt32(getParm(obj,1)) ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
         A60TurnoId = Convert.ToInt16(getParm(obj,2)) ;
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
         PA0H2( ) ;
         WS0H2( ) ;
         WE0H2( ) ;
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
         sCtrlA12MedicoId = (String)((String)getParm(obj,1)) ;
         sCtrlA60TurnoId = (String)((String)getParm(obj,2)) ;
      }

      public override void componentrestorestate( String sPPrefix ,
                                                  String sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix ;
         PA0H2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false ;
         sCompPrefix = (String)getParm(obj,0) ;
         sSFPrefix = (String)getParm(obj,1) ;
         sPrefix = sCompPrefix + sSFPrefix ;
         AddComponentObject(sPrefix, "gestionconsultageneral");
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         PA0H2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A43ConsultaFecha = (DateTime)getParm(obj,2) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A43ConsultaFecha", context.localUtil.Format(A43ConsultaFecha, "99/99/99"));
            A12MedicoId = Convert.ToInt32(getParm(obj,3)) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A12MedicoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A12MedicoId), 6, 0)));
            A60TurnoId = Convert.ToInt16(getParm(obj,4)) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A60TurnoId", StringUtil.LTrim( StringUtil.Str( (decimal)(A60TurnoId), 2, 0)));
         }
         wcpOA43ConsultaFecha = context.localUtil.CToD( cgiGet( sPrefix+"wcpOA43ConsultaFecha"), 0) ;
         wcpOA12MedicoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA12MedicoId"), ",", ".")) ;
         wcpOA60TurnoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA60TurnoId"), ",", ".")) ;
         if ( ! GetJustCreated( ) && ( ( A43ConsultaFecha != wcpOA43ConsultaFecha ) || ( A12MedicoId != wcpOA12MedicoId ) || ( A60TurnoId != wcpOA60TurnoId ) ) )
         {
            setjustcreated();
         }
         wcpOA43ConsultaFecha = A43ConsultaFecha ;
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
         PA0H2( ) ;
         sEvt = sCompEvt ;
         WCParametersGet( ) ;
         WS0H2( ) ;
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
         WS0H2( ) ;
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
         WE0H2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( Form.Jscriptsrc.Item(idxLst)), "?552788");
            idxLst = (int)(idxLst+1) ;
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("gestionconsultageneral.js", "?552788");
         /* End function include_jscripts */
      }

      protected void initialize_properties( )
      {
         lblTextblockconsultafecha_Internalname = sPrefix+"TEXTBLOCKCONSULTAFECHA" ;
         edtConsultaFecha_Internalname = sPrefix+"CONSULTAFECHA" ;
         lblTextblockmedicoid_Internalname = sPrefix+"TEXTBLOCKMEDICOID" ;
         edtMedicoId_Internalname = sPrefix+"MEDICOID" ;
         lblTextblockmedicoapellido_Internalname = sPrefix+"TEXTBLOCKMEDICOAPELLIDO" ;
         edtMedicoApellido_Internalname = sPrefix+"MEDICOAPELLIDO" ;
         lblTextblockmediconombre_Internalname = sPrefix+"TEXTBLOCKMEDICONOMBRE" ;
         edtMedicoNombre_Internalname = sPrefix+"MEDICONOMBRE" ;
         lblTextblockturnonombre_Internalname = sPrefix+"TEXTBLOCKTURNONOMBRE" ;
         edtTurnoNombre_Internalname = sPrefix+"TURNONOMBRE" ;
         lblTextblockconsultorioid_Internalname = sPrefix+"TEXTBLOCKCONSULTORIOID" ;
         edtConsultorioId_Internalname = sPrefix+"CONSULTORIOID" ;
         lblTextblockcantnrosasig_Internalname = sPrefix+"TEXTBLOCKCANTNROSASIG" ;
         edtCantNrosAsig_Internalname = sPrefix+"CANTNROSASIG" ;
         lblTextblocknrosdisponibles_Internalname = sPrefix+"TEXTBLOCKNROSDISPONIBLES" ;
         edtNrosDisponibles_Internalname = sPrefix+"NROSDISPONIBLES" ;
         lblTextblockultimonroasig_Internalname = sPrefix+"TEXTBLOCKULTIMONROASIG" ;
         edtUltimoNroAsig_Internalname = sPrefix+"ULTIMONROASIG" ;
         lblTextblockcantpacconf_Internalname = sPrefix+"TEXTBLOCKCANTPACCONF" ;
         edtCantPacConf_Internalname = sPrefix+"CANTPACCONF" ;
         tblTbl2_Internalname = sPrefix+"TBL2" ;
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE" ;
         edtTurnoId_Internalname = sPrefix+"TURNOID" ;
         Form.Internalname = sPrefix+"FORM" ;
         edtCantPacConf_Jsonclick = "" ;
         edtUltimoNroAsig_Jsonclick = "" ;
         edtNrosDisponibles_Jsonclick = "" ;
         edtCantNrosAsig_Jsonclick = "" ;
         edtConsultorioId_Jsonclick = "" ;
         edtTurnoNombre_Jsonclick = "" ;
         edtMedicoNombre_Jsonclick = "" ;
         edtMedicoApellido_Jsonclick = "" ;
         edtMedicoId_Jsonclick = "" ;
         edtConsultaFecha_Jsonclick = "" ;
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
         AV16Pgmname = "" ;
         scmdbuf = "" ;
         H000H2_A13MedicoNombre = new String[] {""} ;
         H000H2_A14MedicoApellido = new String[] {""} ;
         A13MedicoNombre = "" ;
         A14MedicoApellido = "" ;
         H000H3_A61TurnoNombre = new String[] {""} ;
         A61TurnoNombre = "" ;
         H000H5_A70CantPacConf = new short[1] ;
         H000H5_n70CantPacConf = new bool[] {false} ;
         H000H8_A65NrosDisponibles = new short[1] ;
         H000H8_n65NrosDisponibles = new bool[] {false} ;
         H000H10_A66CantNrosAsig = new short[1] ;
         H000H10_n66CantNrosAsig = new bool[] {false} ;
         sDynURL = "" ;
         FormProcess = "" ;
         GXt_char1 = "" ;
         GXt_char2 = "" ;
         GXt_char3 = "" ;
         GX_FocusControl = "" ;
         TempTags = "" ;
         ClassString = "" ;
         StyleString = "" ;
         bttBtnupdate_Jsonclick = "" ;
         Form = new GXWebForm();
         sXEvt = "" ;
         sEvt = "" ;
         EvtGridId = "" ;
         EvtRowId = "" ;
         sEvtType = "" ;
         H000H15_A43ConsultaFecha = new DateTime[] {DateTime.MinValue} ;
         H000H15_A12MedicoId = new int[1] ;
         H000H15_A60TurnoId = new short[1] ;
         H000H15_A67UltimoNroAsig = new short[1] ;
         H000H15_n67UltimoNroAsig = new bool[] {false} ;
         H000H15_A57ConsultorioId = new short[1] ;
         H000H15_A61TurnoNombre = new String[] {""} ;
         H000H15_A13MedicoNombre = new String[] {""} ;
         H000H15_A14MedicoApellido = new String[] {""} ;
         H000H15_A70CantPacConf = new short[1] ;
         H000H15_n70CantPacConf = new bool[] {false} ;
         H000H15_A65NrosDisponibles = new short[1] ;
         H000H15_n65NrosDisponibles = new bool[] {false} ;
         H000H15_A66CantNrosAsig = new short[1] ;
         H000H15_n66CantNrosAsig = new bool[] {false} ;
         H000H16_A13MedicoNombre = new String[] {""} ;
         H000H16_A14MedicoApellido = new String[] {""} ;
         H000H17_A61TurnoNombre = new String[] {""} ;
         H000H19_A70CantPacConf = new short[1] ;
         H000H19_n70CantPacConf = new bool[] {false} ;
         H000H22_A65NrosDisponibles = new short[1] ;
         H000H22_n65NrosDisponibles = new bool[] {false} ;
         H000H24_A66CantNrosAsig = new short[1] ;
         H000H24_n66CantNrosAsig = new bool[] {false} ;
         AV10TrnContext = new SdtTransactionContext(context);
         AV13HTTPRequest = new GxHttpRequest( context);
         AV11TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV7ConsultaFecha = DateTime.MinValue ;
         AV12Session = new GxWebSession( context);
         sStyleString = "" ;
         lblTextblockconsultafecha_Jsonclick = "" ;
         lblTextblockmedicoid_Jsonclick = "" ;
         lblTextblockmedicoapellido_Jsonclick = "" ;
         lblTextblockmediconombre_Jsonclick = "" ;
         lblTextblockturnonombre_Jsonclick = "" ;
         lblTextblockconsultorioid_Jsonclick = "" ;
         lblTextblockcantnrosasig_Jsonclick = "" ;
         lblTextblocknrosdisponibles_Jsonclick = "" ;
         lblTextblockultimonroasig_Jsonclick = "" ;
         lblTextblockcantpacconf_Jsonclick = "" ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA43ConsultaFecha = "" ;
         sCtrlA12MedicoId = "" ;
         sCtrlA60TurnoId = "" ;
         GXt_char4 = "" ;
         GXt_char5 = "" ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gestionconsultageneral__default(),
            new Object[][] {
                new Object[] {
               H000H2_A13MedicoNombre, H000H2_A14MedicoApellido
               }
               , new Object[] {
               H000H3_A61TurnoNombre
               }
               , new Object[] {
               H000H5_A70CantPacConf, H000H5_n70CantPacConf
               }
               , new Object[] {
               H000H8_A65NrosDisponibles, H000H8_n65NrosDisponibles
               }
               , new Object[] {
               H000H10_A66CantNrosAsig, H000H10_n66CantNrosAsig
               }
               , new Object[] {
               H000H15_A43ConsultaFecha, H000H15_A12MedicoId, H000H15_A60TurnoId, H000H15_A67UltimoNroAsig, H000H15_n67UltimoNroAsig, H000H15_A57ConsultorioId, H000H15_A61TurnoNombre, H000H15_A13MedicoNombre, H000H15_A14MedicoApellido, H000H15_A70CantPacConf,
               H000H15_n70CantPacConf, H000H15_A65NrosDisponibles, H000H15_n65NrosDisponibles, H000H15_A66CantNrosAsig, H000H15_n66CantNrosAsig
               }
               , new Object[] {
               H000H16_A13MedicoNombre, H000H16_A14MedicoApellido
               }
               , new Object[] {
               H000H17_A61TurnoNombre
               }
               , new Object[] {
               H000H19_A70CantPacConf, H000H19_n70CantPacConf
               }
               , new Object[] {
               H000H22_A65NrosDisponibles, H000H22_n65NrosDisponibles
               }
               , new Object[] {
               H000H24_A66CantNrosAsig, H000H24_n66CantNrosAsig
               }
            }
         );
         AV16Pgmname = "GestionConsultaGeneral" ;
         /* GeneXus formulas. */
         AV16Pgmname = "GestionConsultaGeneral" ;
         context.Gx_err = 0 ;
      }

      private short A60TurnoId ;
      private short wcpOA60TurnoId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short A70CantPacConf ;
      private short A65NrosDisponibles ;
      private short A66CantNrosAsig ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short A67UltimoNroAsig ;
      private short A57ConsultorioId ;
      private short AV9TurnoId ;
      private short nGXWrapped ;
      private int A12MedicoId ;
      private int wcpOA12MedicoId ;
      private int edtTurnoId_Visible ;
      private int AV8MedicoId ;
      private int idxLst ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sPrefix ;
      private String sCompPrefix ;
      private String sSFPrefix ;
      private String AV16Pgmname ;
      private String scmdbuf ;
      private String A13MedicoNombre ;
      private String A14MedicoApellido ;
      private String A61TurnoNombre ;
      private String sDynURL ;
      private String FormProcess ;
      private String GXt_char1 ;
      private String GXt_char2 ;
      private String GXt_char3 ;
      private String GX_FocusControl ;
      private String TempTags ;
      private String ClassString ;
      private String StyleString ;
      private String bttBtnupdate_Internalname ;
      private String bttBtnupdate_Jsonclick ;
      private String edtTurnoId_Internalname ;
      private String edtTurnoId_Jsonclick ;
      private String sXEvt ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtConsultaFecha_Internalname ;
      private String edtMedicoId_Internalname ;
      private String edtMedicoApellido_Internalname ;
      private String edtMedicoNombre_Internalname ;
      private String edtTurnoNombre_Internalname ;
      private String edtConsultorioId_Internalname ;
      private String edtCantNrosAsig_Internalname ;
      private String edtNrosDisponibles_Internalname ;
      private String edtUltimoNroAsig_Internalname ;
      private String edtCantPacConf_Internalname ;
      private String sStyleString ;
      private String tblTbl2_Internalname ;
      private String lblTextblockconsultafecha_Internalname ;
      private String lblTextblockconsultafecha_Jsonclick ;
      private String edtConsultaFecha_Jsonclick ;
      private String lblTextblockmedicoid_Internalname ;
      private String lblTextblockmedicoid_Jsonclick ;
      private String edtMedicoId_Jsonclick ;
      private String lblTextblockmedicoapellido_Internalname ;
      private String lblTextblockmedicoapellido_Jsonclick ;
      private String edtMedicoApellido_Jsonclick ;
      private String lblTextblockmediconombre_Internalname ;
      private String lblTextblockmediconombre_Jsonclick ;
      private String edtMedicoNombre_Jsonclick ;
      private String lblTextblockturnonombre_Internalname ;
      private String lblTextblockturnonombre_Jsonclick ;
      private String edtTurnoNombre_Jsonclick ;
      private String lblTextblockconsultorioid_Internalname ;
      private String lblTextblockconsultorioid_Jsonclick ;
      private String edtConsultorioId_Jsonclick ;
      private String lblTextblockcantnrosasig_Internalname ;
      private String lblTextblockcantnrosasig_Jsonclick ;
      private String edtCantNrosAsig_Jsonclick ;
      private String lblTextblocknrosdisponibles_Internalname ;
      private String lblTextblocknrosdisponibles_Jsonclick ;
      private String edtNrosDisponibles_Jsonclick ;
      private String lblTextblockultimonroasig_Internalname ;
      private String lblTextblockultimonroasig_Jsonclick ;
      private String edtUltimoNroAsig_Jsonclick ;
      private String lblTextblockcantpacconf_Internalname ;
      private String lblTextblockcantpacconf_Jsonclick ;
      private String edtCantPacConf_Jsonclick ;
      private String sCtrlA43ConsultaFecha ;
      private String sCtrlA12MedicoId ;
      private String sCtrlA60TurnoId ;
      private String GXt_char4 ;
      private String GXt_char5 ;
      private DateTime A43ConsultaFecha ;
      private DateTime wcpOA43ConsultaFecha ;
      private DateTime AV7ConsultaFecha ;
      private bool entryPointCalled ;
      private bool n70CantPacConf ;
      private bool n65NrosDisponibles ;
      private bool n66CantNrosAsig ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n67UltimoNroAsig ;
      private bool returnInSub ;
      private bool AV5IsAuthorized ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private String[] H000H2_A13MedicoNombre ;
      private String[] H000H2_A14MedicoApellido ;
      private String[] H000H3_A61TurnoNombre ;
      private short[] H000H5_A70CantPacConf ;
      private bool[] H000H5_n70CantPacConf ;
      private short[] H000H8_A65NrosDisponibles ;
      private bool[] H000H8_n65NrosDisponibles ;
      private short[] H000H10_A66CantNrosAsig ;
      private bool[] H000H10_n66CantNrosAsig ;
      private DateTime[] H000H15_A43ConsultaFecha ;
      private int[] H000H15_A12MedicoId ;
      private short[] H000H15_A60TurnoId ;
      private short[] H000H15_A67UltimoNroAsig ;
      private bool[] H000H15_n67UltimoNroAsig ;
      private short[] H000H15_A57ConsultorioId ;
      private String[] H000H15_A61TurnoNombre ;
      private String[] H000H15_A13MedicoNombre ;
      private String[] H000H15_A14MedicoApellido ;
      private short[] H000H15_A70CantPacConf ;
      private bool[] H000H15_n70CantPacConf ;
      private short[] H000H15_A65NrosDisponibles ;
      private bool[] H000H15_n65NrosDisponibles ;
      private short[] H000H15_A66CantNrosAsig ;
      private bool[] H000H15_n66CantNrosAsig ;
      private String[] H000H16_A13MedicoNombre ;
      private String[] H000H16_A14MedicoApellido ;
      private String[] H000H17_A61TurnoNombre ;
      private short[] H000H19_A70CantPacConf ;
      private bool[] H000H19_n70CantPacConf ;
      private short[] H000H22_A65NrosDisponibles ;
      private bool[] H000H22_n65NrosDisponibles ;
      private short[] H000H24_A66CantNrosAsig ;
      private bool[] H000H24_n66CantNrosAsig ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV13HTTPRequest ;
      private GxWebSession AV12Session ;
      private SdtTransactionContext AV10TrnContext ;
      private SdtTransactionContext_Attribute AV11TrnContextAtt ;
   }

   public class gestionconsultageneral__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000H2 ;
          prmH000H2 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmH000H3 ;
          prmH000H3 = new Object[] {
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmH000H5 ;
          prmH000H5 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmH000H8 ;
          prmH000H8 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmH000H10 ;
          prmH000H10 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmH000H15 ;
          prmH000H15 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          String cmdBufferH000H15 ;
          cmdBufferH000H15=" SELECT T1.[ConsultaFecha], T1.[MedicoId], T1.[TurnoId], T1.[UltimoNroAsig], T1.[ConsultorioId], T3.[TurnoNombre], T2.[MedicoNombre], T2.[MedicoApellido], COALESCE( T4.[CantPacConf], 0) AS CantPacConf, COALESCE( T5.[NrosDisponibles], 0) AS NrosDisponibles, COALESCE( T6.[CantNrosAsig], 0) AS CantNrosAsig FROM ((((([Consulta] T1 WITH (NOLOCK) INNER JOIN [Medico] T2 WITH (NOLOCK) ON T2.[MedicoId] = T1.[MedicoId]) INNER JOIN [Turno] T3 WITH (NOLOCK) ON T3.[TurnoId] = T1.[TurnoId]) LEFT JOIN (SELECT COUNT(*) AS CantPacConf, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) WHERE [Confirmado] = 1 GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T4 ON T4.[ConsultaFecha] = T1.[ConsultaFecha] AND T4.[MedicoId] = T1.[MedicoId] AND T4.[TurnoId] = T1.[TurnoId]) INNER JOIN (SELECT T9.[EspecialidadMaxPacientes] - COALESCE( T10.[CantNrosAsig], 0) AS NrosDisponibles, T7.[ConsultaFecha], T7.[MedicoId], T7.[TurnoId] FROM ((([Consulta] T7 WITH (NOLOCK) INNER JOIN [Medico] T8 WITH (NOLOCK) ON T8.[MedicoId] = T7.[MedicoId]) INNER JOIN [Especialidad] T9 WITH (NOLOCK) ON T9.[EspecialidadId] = T8.[EspecialidadId]) LEFT JOIN (SELECT COUNT(*) AS CantNrosAsig, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T10 ON T10.[ConsultaFecha] = T7.[ConsultaFecha] AND T10.[MedicoId] = T7.[MedicoId] AND T10.[TurnoId] = T7.[TurnoId]) ) T5 ON T5.[ConsultaFecha] = T1.[ConsultaFecha] AND T5.[MedicoId] = T1.[MedicoId] AND T5.[TurnoId] = T1.[TurnoId]) LEFT JOIN (SELECT COUNT(*) AS CantNrosAsig, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T6 ON T6.[ConsultaFecha] = T1.[ConsultaFecha] AND T6.[MedicoId] = T1.[MedicoId] AND T6.[TurnoId] "
          + " = T1.[TurnoId]) WHERE T1.[ConsultaFecha] = @ConsultaFecha and T1.[MedicoId] = @MedicoId and T1.[TurnoId] = @TurnoId ORDER BY T1.[ConsultaFecha], T1.[MedicoId], T1.[TurnoId]" ;
          Object[] prmH000H16 ;
          prmH000H16 = new Object[] {
          new Object[] {"@MedicoId",SqlDbType.Int,6,0}
          } ;
          Object[] prmH000H17 ;
          prmH000H17 = new Object[] {
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmH000H19 ;
          prmH000H19 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmH000H22 ;
          prmH000H22 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          Object[] prmH000H24 ;
          prmH000H24 = new Object[] {
          new Object[] {"@ConsultaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@MedicoId",SqlDbType.Int,6,0} ,
          new Object[] {"@TurnoId",SqlDbType.SmallInt,2,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H000H2", "SELECT [MedicoNombre], [MedicoApellido] FROM [Medico] WITH (NOLOCK) WHERE [MedicoId] = @MedicoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000H2,1,0,true,true )
             ,new CursorDef("H000H3", "SELECT [TurnoNombre] FROM [Turno] WITH (NOLOCK) WHERE [TurnoId] = @TurnoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000H3,1,0,true,true )
             ,new CursorDef("H000H5", "SELECT COALESCE( T1.[CantPacConf], 0) AS CantPacConf FROM (SELECT COUNT(*) AS CantPacConf, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) WHERE [Confirmado] = 1 GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T1 WHERE T1.[ConsultaFecha] = @ConsultaFecha AND T1.[MedicoId] = @MedicoId AND T1.[TurnoId] = @TurnoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000H5,1,0,true,true )
             ,new CursorDef("H000H8", "SELECT COALESCE( T1.[NrosDisponibles], 0) AS NrosDisponibles FROM (SELECT T4.[EspecialidadMaxPacientes] - COALESCE( T5.[CantNrosAsig], 0) AS NrosDisponibles, T2.[ConsultaFecha], T2.[MedicoId], T2.[TurnoId] FROM ((([Consulta] T2 WITH (NOLOCK) INNER JOIN [Medico] T3 WITH (NOLOCK) ON T3.[MedicoId] = T2.[MedicoId]) INNER JOIN [Especialidad] T4 WITH (NOLOCK) ON T4.[EspecialidadId] = T3.[EspecialidadId]) LEFT JOIN (SELECT COUNT(*) AS CantNrosAsig, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T5 ON T5.[ConsultaFecha] = T2.[ConsultaFecha] AND T5.[MedicoId] = T2.[MedicoId] AND T5.[TurnoId] = T2.[TurnoId]) ) T1 WHERE T1.[ConsultaFecha] = @ConsultaFecha AND T1.[MedicoId] = @MedicoId AND T1.[TurnoId] = @TurnoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000H8,1,0,true,true )
             ,new CursorDef("H000H10", "SELECT COALESCE( T1.[CantNrosAsig], 0) AS CantNrosAsig FROM (SELECT COUNT(*) AS CantNrosAsig, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T1 WHERE T1.[ConsultaFecha] = @ConsultaFecha AND T1.[MedicoId] = @MedicoId AND T1.[TurnoId] = @TurnoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000H10,1,0,true,true )
             ,new CursorDef("H000H15", cmdBufferH000H15,false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000H15,1,0,true,true )
             ,new CursorDef("H000H16", "SELECT [MedicoNombre], [MedicoApellido] FROM [Medico] WITH (NOLOCK) WHERE [MedicoId] = @MedicoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000H16,1,0,true,true )
             ,new CursorDef("H000H17", "SELECT [TurnoNombre] FROM [Turno] WITH (NOLOCK) WHERE [TurnoId] = @TurnoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000H17,1,0,true,true )
             ,new CursorDef("H000H19", "SELECT COALESCE( T1.[CantPacConf], 0) AS CantPacConf FROM (SELECT COUNT(*) AS CantPacConf, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) WHERE [Confirmado] = 1 GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T1 WHERE T1.[ConsultaFecha] = @ConsultaFecha AND T1.[MedicoId] = @MedicoId AND T1.[TurnoId] = @TurnoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000H19,1,0,true,true )
             ,new CursorDef("H000H22", "SELECT COALESCE( T1.[NrosDisponibles], 0) AS NrosDisponibles FROM (SELECT T4.[EspecialidadMaxPacientes] - COALESCE( T5.[CantNrosAsig], 0) AS NrosDisponibles, T2.[ConsultaFecha], T2.[MedicoId], T2.[TurnoId] FROM ((([Consulta] T2 WITH (NOLOCK) INNER JOIN [Medico] T3 WITH (NOLOCK) ON T3.[MedicoId] = T2.[MedicoId]) INNER JOIN [Especialidad] T4 WITH (NOLOCK) ON T4.[EspecialidadId] = T3.[EspecialidadId]) LEFT JOIN (SELECT COUNT(*) AS CantNrosAsig, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T5 ON T5.[ConsultaFecha] = T2.[ConsultaFecha] AND T5.[MedicoId] = T2.[MedicoId] AND T5.[TurnoId] = T2.[TurnoId]) ) T1 WHERE T1.[ConsultaFecha] = @ConsultaFecha AND T1.[MedicoId] = @MedicoId AND T1.[TurnoId] = @TurnoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000H22,1,0,true,true )
             ,new CursorDef("H000H24", "SELECT COALESCE( T1.[CantNrosAsig], 0) AS CantNrosAsig FROM (SELECT COUNT(*) AS CantNrosAsig, [ConsultaFecha], [MedicoId], [TurnoId] FROM [ConsultaPaciente] WITH (NOLOCK) GROUP BY [ConsultaFecha], [MedicoId], [TurnoId] ) T1 WHERE T1.[ConsultaFecha] = @ConsultaFecha AND T1.[MedicoId] = @MedicoId AND T1.[TurnoId] = @TurnoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000H24,1,0,true,true )
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
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                break;
             case 1 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                break;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                break;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                break;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                break;
             case 5 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((int[]) buf[1])[0] = rslt.getInt(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                ((short[]) buf[3])[0] = rslt.getShort(4) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((short[]) buf[5])[0] = rslt.getShort(5) ;
                ((String[]) buf[6])[0] = rslt.getString(6, 20) ;
                ((String[]) buf[7])[0] = rslt.getString(7, 20) ;
                ((String[]) buf[8])[0] = rslt.getString(8, 20) ;
                ((short[]) buf[9])[0] = rslt.getShort(9) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((short[]) buf[11])[0] = rslt.getShort(10) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((short[]) buf[13])[0] = rslt.getShort(11) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                break;
             case 6 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                break;
             case 7 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                break;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                break;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                break;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
                stmt.SetParameter(1, (short)parms[0]);
                break;
             case 2 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 3 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 4 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 5 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 6 :
                stmt.SetParameter(1, (int)parms[0]);
                break;
             case 7 :
                stmt.SetParameter(1, (short)parms[0]);
                break;
             case 8 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 9 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
             case 10 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                break;
       }
    }

 }

}
