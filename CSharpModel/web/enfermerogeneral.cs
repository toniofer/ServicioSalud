/*
               File: EnfermeroGeneral
        Description: Enfermero General
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/22/2010 4:0:35.75
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
   public class enfermerogeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public enfermerogeneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public enfermerogeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default") ;
      }

      public void release( )
      {
      }

      public void execute( int aP0_EnfermeroId )
      {
         this.A20EnfermeroId = aP0_EnfermeroId;
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
         cmbEnfermeroEstadoCivil = new GXCombobox();
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
                  A20EnfermeroId = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A20EnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(A20EnfermeroId), 6, 0)));
                  componentprepare(new Object[] {(String)sCompPrefix,(String)sSFPrefix,(int)A20EnfermeroId});
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
            PA092( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV14Pgmname = "EnfermeroGeneral" ;
               context.Gx_err = 0 ;
               WS092( ) ;
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
            context.WriteHtmlText( "Enfermero General") ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" onsubmit=\"try{return gx.csv.validForm()}catch(e){return true;}\" name=\"MAINFORM\" method=\"post\" action=\""+formatLink("enfermerogeneral.aspx") + "?" + UrlEncode("" +A20EnfermeroId)+"\" class=\""+"Form"+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         }
      }

      protected void RenderHtmlCloseForm092( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA20EnfermeroId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA20EnfermeroId), 6, 0, ",", "")));
         if ( ( StringUtil.Len( sPrefix) != 0 ) && context.isAjaxRequest( ) )
         {
            context.AddJavascriptSource("enfermerogeneral.js", "?403582");
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

      protected void WB090( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "enfermerogeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            wb_table1_2_092( true) ;
         }
         else
         {
            wb_table1_2_092( false) ;
         }
         return  ;
      }

      protected void wb_table1_2_092e( bool wbgen )
      {
         if ( wbgen )
         {
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'',0)\"" ;
            ClassString = "ActionButtons" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtnupdate_Internalname, "Modifica", "Modifica", "", StyleString, ClassString, 1, 1, "rounded", 5, bttBtnupdate_Jsonclick, sPrefix+"E\\'DOUPDATE\\'.", TempTags, "", "", "HLP_EnfermeroGeneral.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"" ;
            ClassString = "ActionButtons" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtndelete_Internalname, "Eliminar", "Eliminar", "", StyleString, ClassString, 1, 1, "rounded", 5, bttBtndelete_Jsonclick, sPrefix+"E\\'DODELETE\\'.", TempTags, "", "", "HLP_EnfermeroGeneral.htm");
         }
         wbLoad = true ;
      }

      protected void START092( )
      {
         wbLoad = false ;
         wbEnd = 0 ;
         wbStart = 0 ;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            Form.Meta.addItem("Generator", "GeneXus C#", 0) ;
            Form.Meta.addItem("Version", "10_1_3-34981", 0) ;
            Form.Meta.addItem("Description", "Enfermero General", 0) ;
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
               STRUP090( ) ;
            }
         }
      }

      protected void WS092( )
      {
         START092( ) ;
         EVT092( ) ;
      }

      protected void EVT092( )
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
                                 STRUP090( ) ;
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
                                 STRUP090( ) ;
                              }
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1 ;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: E11092 */
                                    E11092 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP090( ) ;
                              }
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1 ;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: E12092 */
                                    E12092 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP090( ) ;
                              }
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1 ;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: E13092 */
                                    E13092 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP090( ) ;
                              }
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1 ;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: E14092 */
                                    E14092 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP090( ) ;
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
                                 STRUP090( ) ;
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

      protected void WE092( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true ;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm092( ) ;
            }
         }
      }

      protected void PA092( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
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
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A24EnfermeroEstadoCivil", A24EnfermeroEstadoCivil);
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
         RF092( ) ;
         /* End function Refresh */
      }

      protected void RF092( )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00092 */
            pr_default.execute(0, new Object[] {A20EnfermeroId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A25EnfermeroFechaIngreso = H00092_A25EnfermeroFechaIngreso[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A25EnfermeroFechaIngreso", context.localUtil.Format(A25EnfermeroFechaIngreso, "99/99/99"));
               A24EnfermeroEstadoCivil = H00092_A24EnfermeroEstadoCivil[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A24EnfermeroEstadoCivil", A24EnfermeroEstadoCivil);
               A23EnfermeroDomicilio = H00092_A23EnfermeroDomicilio[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A23EnfermeroDomicilio", A23EnfermeroDomicilio);
               A22EnfermeroApellido = H00092_A22EnfermeroApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A22EnfermeroApellido", A22EnfermeroApellido);
               A21EnfermeroNombre = H00092_A21EnfermeroNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A21EnfermeroNombre", A21EnfermeroNombre);
               /* Execute user event: E12092 */
               E12092 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB090( ) ;
         }
      }

      protected void STRUP090( )
      {
         /* Before Start, stand alone formulas. */
         AV14Pgmname = "EnfermeroGeneral" ;
         context.Gx_err = 0 ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0 ;
         /* Execute user event: E11092 */
         E11092 ();
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
               A20EnfermeroId = (int)(context.localUtil.CToN( cgiGet( edtEnfermeroId_Internalname), ",", ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A20EnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(A20EnfermeroId), 6, 0)));
            }
            A21EnfermeroNombre = cgiGet( edtEnfermeroNombre_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A21EnfermeroNombre", A21EnfermeroNombre);
            A22EnfermeroApellido = cgiGet( edtEnfermeroApellido_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A22EnfermeroApellido", A22EnfermeroApellido);
            A23EnfermeroDomicilio = cgiGet( edtEnfermeroDomicilio_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A23EnfermeroDomicilio", A23EnfermeroDomicilio);
            cmbEnfermeroEstadoCivil.CurrentValue = cgiGet( cmbEnfermeroEstadoCivil_Internalname) ;
            A24EnfermeroEstadoCivil = cgiGet( cmbEnfermeroEstadoCivil_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A24EnfermeroEstadoCivil", A24EnfermeroEstadoCivil);
            A25EnfermeroFechaIngreso = context.localUtil.CToD( cgiGet( edtEnfermeroFechaIngreso_Internalname), 2) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A25EnfermeroFechaIngreso", context.localUtil.Format(A25EnfermeroFechaIngreso, "99/99/99"));
            /* Read saved values. */
            wcpOA20EnfermeroId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA20EnfermeroId"), ",", ".")) ;
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
         /* Execute user event: E11092 */
         E11092 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11092( )
      {
         /* Start Routine */
         new isauthorized(context ).execute(  AV14Pgmname, out  AV5IsAuthorized) ;
         if ( ! AV5IsAuthorized )
         {
            context.wjLoc = formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV14Pgmname)) ;
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

      protected void E12092( )
      {
         /* Load Routine */
      }

      protected void E13092( )
      {
         /* 'DoUpdate' Routine */
         context.wjLoc = formatLink("enfermero.aspx") + "?" + UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode("" +A20EnfermeroId) ;
      }

      protected void E14092( )
      {
         /* 'DoDelete' Routine */
         context.wjLoc = formatLink("enfermero.aspx") + "?" + UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode("" +A20EnfermeroId) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         AV8TrnContext = new SdtTransactionContext(context) ;
         AV8TrnContext.gxTpr_Callerobject = AV14Pgmname ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV8TrnContext", (Object)(AV8TrnContext));
         AV8TrnContext.gxTpr_Callerondelete = false ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV8TrnContext", (Object)(AV8TrnContext));
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV8TrnContext", (Object)(AV8TrnContext));
         AV8TrnContext.gxTpr_Transactionname = "Enfermero" ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV8TrnContext", (Object)(AV8TrnContext));
         AV9TrnContextAtt = new SdtTransactionContext_Attribute(context) ;
         AV9TrnContextAtt.gxTpr_Attributename = "EnfermeroId" ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV9TrnContextAtt", (Object)(AV9TrnContextAtt));
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV7EnfermeroId), 6, 0) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV9TrnContextAtt", (Object)(AV9TrnContextAtt));
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, "TransactionContext", "taller041"));
      }

      protected void wb_table1_2_092( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblTextblockenfermeroid_Internalname, 1, 1, 0, "Id", "", "", "", 0, lblTextblockenfermeroid_Jsonclick, "", StyleString, ClassString, "HLP_EnfermeroGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtEnfermeroId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A20EnfermeroId), 6, 0, ",", "")), "", 6, "chr", 1, "row", 6, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(A20EnfermeroId), "ZZZZZ9"), "", 0, edtEnfermeroId_Jsonclick, "", 0, 1, 1, true, "right", "HLP_EnfermeroGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockenfermeronombre_Internalname, 1, 1, 0, "Nombre", "", "", "", 0, lblTextblockenfermeronombre_Jsonclick, "", StyleString, ClassString, "HLP_EnfermeroGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtEnfermeroNombre_Internalname, StringUtil.RTrim( A21EnfermeroNombre), "", 20, "chr", 1, "row", 20, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A21EnfermeroNombre, "XXXXXXXXXXXXXXXXXXXX")), "", 0, edtEnfermeroNombre_Jsonclick, "", 0, 1, 1, true, "left", "HLP_EnfermeroGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockenfermeroapellido_Internalname, 1, 1, 0, "Apellido", "", "", "", 0, lblTextblockenfermeroapellido_Jsonclick, "", StyleString, ClassString, "HLP_EnfermeroGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtEnfermeroApellido_Internalname, StringUtil.RTrim( A22EnfermeroApellido), "", 20, "chr", 1, "row", 20, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A22EnfermeroApellido, "XXXXXXXXXXXXXXXXXXXX")), "", 0, edtEnfermeroApellido_Jsonclick, "", 0, 1, 1, true, "left", "HLP_EnfermeroGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockenfermerodomicilio_Internalname, 1, 1, 0, "Domicilio", "", "", "", 0, lblTextblockenfermerodomicilio_Jsonclick, "", StyleString, ClassString, "HLP_EnfermeroGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtEnfermeroDomicilio_Internalname, StringUtil.RTrim( A23EnfermeroDomicilio), "", 40, "chr", 1, "row", 40, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( A23EnfermeroDomicilio, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")), "", 0, edtEnfermeroDomicilio_Jsonclick, "", 0, 1, 1, true, "left", "HLP_EnfermeroGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockenfermeroestadocivil_Internalname, 1, 1, 0, "Estado Civil", "", "", "", 0, lblTextblockenfermeroestadocivil_Jsonclick, "", StyleString, ClassString, "HLP_EnfermeroGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbEnfermeroEstadoCivil, cmbEnfermeroEstadoCivil_Internalname, A24EnfermeroEstadoCivil, "", "char", 1, 0, 0, 1, 0, 1, "chr", 0, "", StyleString, ClassString, "", 0, cmbEnfermeroEstadoCivil_Jsonclick, "", "", true, "HLP_EnfermeroGeneral.htm");
            cmbEnfermeroEstadoCivil.CurrentValue = A24EnfermeroEstadoCivil ;
            context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, cmbEnfermeroEstadoCivil_Internalname, "Values", (String)(cmbEnfermeroEstadoCivil.ToJavascriptSource()));
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockenfermerofechaingreso_Internalname, 1, 1, 0, "Fecha Ingreso", "", "", "", 0, lblTextblockenfermerofechaingreso_Jsonclick, "", StyleString, ClassString, "HLP_EnfermeroGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            ClassString = "ReadonlyAttribute" ;
            StyleString = "" ;
            if ( ( 0 == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
            {
               context.WriteHtmlText( "<table id=\""+edtEnfermeroFechaIngreso_Internalname+"_dp_container\" cellpadding=\"0\" cellspacing=\"0\"><tr><td>") ;
            }
            GxWebStd.gx_single_line_edit( context, edtEnfermeroFechaIngreso_Internalname, context.localUtil.Format(A25EnfermeroFechaIngreso, "99/99/99"), "", 8, "chr", 1, "row", 8, 1, 0, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( A25EnfermeroFechaIngreso, "99/99/99"), "", 0, edtEnfermeroFechaIngreso_Jsonclick, "", 0, 1, 1, true, "right", "HLP_EnfermeroGeneral.htm");
            if ( ( 0 == 1 ) && ( 1 == 1 ) || ( 0 == 1 ) )
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
            wb_table1_2_092e( true) ;
         }
         else
         {
            wb_table1_2_092e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A20EnfermeroId = Convert.ToInt32(getParm(obj,0)) ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A20EnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(A20EnfermeroId), 6, 0)));
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
         PA092( ) ;
         WS092( ) ;
         WE092( ) ;
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
         sCtrlA20EnfermeroId = (String)((String)getParm(obj,0)) ;
      }

      public override void componentrestorestate( String sPPrefix ,
                                                  String sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix ;
         PA092( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false ;
         sCompPrefix = (String)getParm(obj,0) ;
         sSFPrefix = (String)getParm(obj,1) ;
         sPrefix = sCompPrefix + sSFPrefix ;
         AddComponentObject(sPrefix, "enfermerogeneral");
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         PA092( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A20EnfermeroId = Convert.ToInt32(getParm(obj,2)) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A20EnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(A20EnfermeroId), 6, 0)));
         }
         wcpOA20EnfermeroId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA20EnfermeroId"), ",", ".")) ;
         if ( ! GetJustCreated( ) && ( ( A20EnfermeroId != wcpOA20EnfermeroId ) ) )
         {
            setjustcreated();
         }
         wcpOA20EnfermeroId = A20EnfermeroId ;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA20EnfermeroId = cgiGet( sPrefix+"A20EnfermeroId_CTRL") ;
         if ( StringUtil.Len( sCtrlA20EnfermeroId) > 0 )
         {
            A20EnfermeroId = (int)(context.localUtil.CToN( cgiGet( sCtrlA20EnfermeroId), ",", ".")) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "A20EnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(A20EnfermeroId), 6, 0)));
         }
         else
         {
            A20EnfermeroId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"A20EnfermeroId_PARM"), ",", ".")) ;
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
         PA092( ) ;
         sEvt = sCompEvt ;
         WCParametersGet( ) ;
         WS092( ) ;
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
         WS092( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst ;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A20EnfermeroId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A20EnfermeroId), 6, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA20EnfermeroId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A20EnfermeroId_CTRL", StringUtil.RTrim( sCtrlA20EnfermeroId));
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
         WE092( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( Form.Jscriptsrc.Item(idxLst)), "?403643");
            idxLst = (int)(idxLst+1) ;
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("enfermerogeneral.js", "?403643");
         /* End function include_jscripts */
      }

      protected void initialize_properties( )
      {
         lblTextblockenfermeroid_Internalname = sPrefix+"TEXTBLOCKENFERMEROID" ;
         edtEnfermeroId_Internalname = sPrefix+"ENFERMEROID" ;
         lblTextblockenfermeronombre_Internalname = sPrefix+"TEXTBLOCKENFERMERONOMBRE" ;
         edtEnfermeroNombre_Internalname = sPrefix+"ENFERMERONOMBRE" ;
         lblTextblockenfermeroapellido_Internalname = sPrefix+"TEXTBLOCKENFERMEROAPELLIDO" ;
         edtEnfermeroApellido_Internalname = sPrefix+"ENFERMEROAPELLIDO" ;
         lblTextblockenfermerodomicilio_Internalname = sPrefix+"TEXTBLOCKENFERMERODOMICILIO" ;
         edtEnfermeroDomicilio_Internalname = sPrefix+"ENFERMERODOMICILIO" ;
         lblTextblockenfermeroestadocivil_Internalname = sPrefix+"TEXTBLOCKENFERMEROESTADOCIVIL" ;
         cmbEnfermeroEstadoCivil_Internalname = sPrefix+"ENFERMEROESTADOCIVIL" ;
         lblTextblockenfermerofechaingreso_Internalname = sPrefix+"TEXTBLOCKENFERMEROFECHAINGRESO" ;
         edtEnfermeroFechaIngreso_Internalname = sPrefix+"ENFERMEROFECHAINGRESO" ;
         tblTbl2_Internalname = sPrefix+"TBL2" ;
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE" ;
         bttBtndelete_Internalname = sPrefix+"BTNDELETE" ;
         Form.Internalname = sPrefix+"FORM" ;
         edtEnfermeroFechaIngreso_Jsonclick = "" ;
         cmbEnfermeroEstadoCivil_Jsonclick = "" ;
         edtEnfermeroDomicilio_Jsonclick = "" ;
         edtEnfermeroApellido_Jsonclick = "" ;
         edtEnfermeroNombre_Jsonclick = "" ;
         edtEnfermeroId_Jsonclick = "" ;
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
         AV14Pgmname = "" ;
         sDynURL = "" ;
         FormProcess = "" ;
         GXt_char1 = "" ;
         GXt_char2 = "" ;
         GX_FocusControl = "" ;
         TempTags = "" ;
         ClassString = "" ;
         StyleString = "" ;
         bttBtnupdate_Jsonclick = "" ;
         bttBtndelete_Jsonclick = "" ;
         Form = new GXWebForm();
         sXEvt = "" ;
         sEvt = "" ;
         EvtGridId = "" ;
         EvtRowId = "" ;
         sEvtType = "" ;
         A24EnfermeroEstadoCivil = "" ;
         scmdbuf = "" ;
         H00092_A20EnfermeroId = new int[1] ;
         H00092_A25EnfermeroFechaIngreso = new DateTime[] {DateTime.MinValue} ;
         H00092_A24EnfermeroEstadoCivil = new String[] {""} ;
         H00092_A23EnfermeroDomicilio = new String[] {""} ;
         H00092_A22EnfermeroApellido = new String[] {""} ;
         H00092_A21EnfermeroNombre = new String[] {""} ;
         A25EnfermeroFechaIngreso = DateTime.MinValue ;
         A23EnfermeroDomicilio = "" ;
         A22EnfermeroApellido = "" ;
         A21EnfermeroNombre = "" ;
         AV8TrnContext = new SdtTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV9TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV10Session = new GxWebSession( context);
         sStyleString = "" ;
         lblTextblockenfermeroid_Jsonclick = "" ;
         lblTextblockenfermeronombre_Jsonclick = "" ;
         lblTextblockenfermeroapellido_Jsonclick = "" ;
         lblTextblockenfermerodomicilio_Jsonclick = "" ;
         lblTextblockenfermeroestadocivil_Jsonclick = "" ;
         lblTextblockenfermerofechaingreso_Jsonclick = "" ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA20EnfermeroId = "" ;
         GXt_char3 = "" ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.enfermerogeneral__default(),
            new Object[][] {
                new Object[] {
               H00092_A20EnfermeroId, H00092_A25EnfermeroFechaIngreso, H00092_A24EnfermeroEstadoCivil, H00092_A23EnfermeroDomicilio, H00092_A22EnfermeroApellido, H00092_A21EnfermeroNombre
               }
            }
         );
         AV14Pgmname = "EnfermeroGeneral" ;
         /* GeneXus formulas. */
         AV14Pgmname = "EnfermeroGeneral" ;
         context.Gx_err = 0 ;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int A20EnfermeroId ;
      private int wcpOA20EnfermeroId ;
      private int AV7EnfermeroId ;
      private int idxLst ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sPrefix ;
      private String sCompPrefix ;
      private String sSFPrefix ;
      private String AV14Pgmname ;
      private String sDynURL ;
      private String FormProcess ;
      private String GXt_char1 ;
      private String GXt_char2 ;
      private String GX_FocusControl ;
      private String TempTags ;
      private String ClassString ;
      private String StyleString ;
      private String bttBtnupdate_Internalname ;
      private String bttBtnupdate_Jsonclick ;
      private String bttBtndelete_Internalname ;
      private String bttBtndelete_Jsonclick ;
      private String sXEvt ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String A24EnfermeroEstadoCivil ;
      private String scmdbuf ;
      private String A23EnfermeroDomicilio ;
      private String A22EnfermeroApellido ;
      private String A21EnfermeroNombre ;
      private String edtEnfermeroId_Internalname ;
      private String edtEnfermeroNombre_Internalname ;
      private String edtEnfermeroApellido_Internalname ;
      private String edtEnfermeroDomicilio_Internalname ;
      private String cmbEnfermeroEstadoCivil_Internalname ;
      private String edtEnfermeroFechaIngreso_Internalname ;
      private String sStyleString ;
      private String tblTbl2_Internalname ;
      private String lblTextblockenfermeroid_Internalname ;
      private String lblTextblockenfermeroid_Jsonclick ;
      private String edtEnfermeroId_Jsonclick ;
      private String lblTextblockenfermeronombre_Internalname ;
      private String lblTextblockenfermeronombre_Jsonclick ;
      private String edtEnfermeroNombre_Jsonclick ;
      private String lblTextblockenfermeroapellido_Internalname ;
      private String lblTextblockenfermeroapellido_Jsonclick ;
      private String edtEnfermeroApellido_Jsonclick ;
      private String lblTextblockenfermerodomicilio_Internalname ;
      private String lblTextblockenfermerodomicilio_Jsonclick ;
      private String edtEnfermeroDomicilio_Jsonclick ;
      private String lblTextblockenfermeroestadocivil_Internalname ;
      private String lblTextblockenfermeroestadocivil_Jsonclick ;
      private String cmbEnfermeroEstadoCivil_Jsonclick ;
      private String lblTextblockenfermerofechaingreso_Internalname ;
      private String lblTextblockenfermerofechaingreso_Jsonclick ;
      private String edtEnfermeroFechaIngreso_Jsonclick ;
      private String sCtrlA20EnfermeroId ;
      private String GXt_char3 ;
      private DateTime A25EnfermeroFechaIngreso ;
      private bool entryPointCalled ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool returnInSub ;
      private bool AV5IsAuthorized ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbEnfermeroEstadoCivil ;
      private IDataStoreProvider pr_default ;
      private int[] H00092_A20EnfermeroId ;
      private DateTime[] H00092_A25EnfermeroFechaIngreso ;
      private String[] H00092_A24EnfermeroEstadoCivil ;
      private String[] H00092_A23EnfermeroDomicilio ;
      private String[] H00092_A22EnfermeroApellido ;
      private String[] H00092_A21EnfermeroNombre ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV11HTTPRequest ;
      private GxWebSession AV10Session ;
      private SdtTransactionContext AV8TrnContext ;
      private SdtTransactionContext_Attribute AV9TrnContextAtt ;
   }

   public class enfermerogeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00092 ;
          prmH00092 = new Object[] {
          new Object[] {"@EnfermeroId",SqlDbType.Int,6,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H00092", "SELECT [EnfermeroId], [EnfermeroFechaIngreso], [EnfermeroEstadoCivil], [EnfermeroDomicilio], [EnfermeroApellido], [EnfermeroNombre] FROM [Enfermero] WITH (NOLOCK) WHERE [EnfermeroId] = @EnfermeroId ORDER BY [EnfermeroId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00092,1,0,true,true )
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
                ((String[]) buf[2])[0] = rslt.getString(3, 1) ;
                ((String[]) buf[3])[0] = rslt.getString(4, 40) ;
                ((String[]) buf[4])[0] = rslt.getString(5, 20) ;
                ((String[]) buf[5])[0] = rslt.getString(6, 20) ;
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
       }
    }

 }

}
