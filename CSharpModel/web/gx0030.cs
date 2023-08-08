/*
               File: Gx0030
        Description: Selection List Enfermero
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/22/2010 4:0:17.79
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
   public class gx0030 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0030( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public gx0030( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default") ;
      }

      public void release( )
      {
      }

      public void execute( ref int aP0_pEnfermeroId )
      {
         this.AV12pEnfermeroId = aP0_pEnfermeroId;
         executePrivate();
         aP0_pEnfermeroId=this.AV12pEnfermeroId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCenfermeroestadocivil = new GXCombobox();
         cmbEnfermeroEstadoCivil = new GXCombobox();
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
               nGXsfl_41_idx = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
               sGXsfl_41_idx = GetNextPar( ) ;
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1 ;
                  return  ;
               }
               gxnrGrid1_newrow( nRC_Grid1, nGXsfl_41_idx, sGXsfl_41_idx) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0 ;
               cmbavCenfermeroestadocivil.Name = "_CENFERMEROESTADOCIVIL" ;
               cmbavCenfermeroestadocivil.WebTags = "" ;
               cmbavCenfermeroestadocivil.addItem("S", "Soltero", 0);
               cmbavCenfermeroestadocivil.addItem("C", "Casado", 0);
               cmbavCenfermeroestadocivil.addItem("V", "Viudo", 0);
               cmbavCenfermeroestadocivil.addItem("D", "Divorciado", 0);
               if ( ( cmbavCenfermeroestadocivil.ItemCount > 0 ) && String.IsNullOrEmpty(StringUtil.RTrim( AV10cEnfermeroEstadoCivil)) )
               {
                  AV10cEnfermeroEstadoCivil = cmbavCenfermeroestadocivil.getItemValue(1) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV10cEnfermeroEstadoCivil", AV10cEnfermeroEstadoCivil);
               }
               GXCCtl = "ENFERMEROESTADOCIVIL_" + sGXsfl_41_idx ;
               cmbEnfermeroEstadoCivil.Name = GXCCtl ;
               cmbEnfermeroEstadoCivil.WebTags = "" ;
               cmbEnfermeroEstadoCivil.addItem("S", "Soltero", 0);
               cmbEnfermeroEstadoCivil.addItem("C", "Casado", 0);
               cmbEnfermeroEstadoCivil.addItem("V", "Viudo", 0);
               cmbEnfermeroEstadoCivil.addItem("D", "Divorciado", 0);
               if ( ( cmbEnfermeroEstadoCivil.ItemCount > 0 ) && String.IsNullOrEmpty(StringUtil.RTrim( A24EnfermeroEstadoCivil)) )
               {
                  A24EnfermeroEstadoCivil = cmbEnfermeroEstadoCivil.getItemValue(1) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A24EnfermeroEstadoCivil", A24EnfermeroEstadoCivil);
               }
               Grid1_PageSize41 = (int)(NumberUtil.Val( GetNextPar( ), ".")) ;
               AV7cEnfermeroNombre = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7cEnfermeroNombre", AV7cEnfermeroNombre);
               AV8cEnfermeroApellido = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV8cEnfermeroApellido", AV8cEnfermeroApellido);
               AV9cEnfermeroDomicilio = GetNextPar( ) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV9cEnfermeroDomicilio", AV9cEnfermeroDomicilio);
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1 ;
                  return  ;
               }
               gxgrGrid1_refresh( Grid1_PageSize41, AV7cEnfermeroNombre, AV8cEnfermeroApellido, AV9cEnfermeroDomicilio) ;
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
               AV12pEnfermeroId = (int)(NumberUtil.Val( gxfirstwebparm, ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV12pEnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV12pEnfermeroId), 6, 0)));
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
         PA0K2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0)) ;
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0K2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" onsubmit=\"try{return gx.csv.validForm()}catch(e){return true;}\" name=\"MAINFORM\" method=\"post\" action=\""+formatLink("gx0030.aspx") + "?" + UrlEncode("" +AV12pEnfermeroId)+"\" class=\""+"Form"+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
      }

      public override void RenderHtmlCloseForm( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH__CENFERMERONOMBRE", StringUtil.RTrim( AV7cEnfermeroNombre));
         GxWebStd.gx_hidden_field( context, "GXH__CENFERMEROAPELLIDO", StringUtil.RTrim( AV8cEnfermeroApellido));
         GxWebStd.gx_hidden_field( context, "GXH__CENFERMERODOMICILIO", StringUtil.RTrim( AV9cEnfermeroDomicilio));
         /* Send saved values. */
         GxWebStd.gx_hidden_field( context, "nRC_Grid1", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_Grid1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "_PENFERMEROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pEnfermeroId), 6, 0, ",", "")));
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
            WE0K2( ) ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0K2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override String GetPgmname( )
      {
         return "Gx0030" ;
      }

      public override String GetPgmdesc( )
      {
         return "Selection List Enfermero" ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("gx0030.aspx") + "?" + UrlEncode("" +AV12pEnfermeroId) ;
      }

      protected void WB0K0( )
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
            wb_table1_2_0K2( true) ;
         }
         else
         {
            wb_table1_2_0K2( false) ;
         }
         return  ;
      }

      protected void wb_table1_2_0K2e( bool wbgen )
      {
         if ( wbgen )
         {
         }
         wbLoad = true ;
      }

      protected void START0K2( )
      {
         wbLoad = false ;
         wbEnd = 0 ;
         wbStart = 0 ;
         Form.Meta.addItem("Generator", "GeneXus C#", 0) ;
         Form.Meta.addItem("Version", "10_1_3-34981", 0) ;
         Form.Meta.addItem("Description", "Selection List Enfermero", 0) ;
         context.wjLoc = "" ;
         context.nUserReturn = 0 ;
         context.wbHandled = 0 ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false ;
         STRUP0K0( ) ;
      }

      protected void WS0K2( )
      {
         START0K2( ) ;
         EVT0K2( ) ;
      }

      protected void EVT0K2( )
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
                  if ( StringUtil.StrCmp(cgiGet( "GXH__CENFERMERONOMBRE"), AV7cEnfermeroNombre) != 0 )
                  {
                     GRID1_nFirstRecordOnPage = 0 ;
                  }
                  if ( StringUtil.StrCmp(cgiGet( "GXH__CENFERMEROAPELLIDO"), AV8cEnfermeroApellido) != 0 )
                  {
                     GRID1_nFirstRecordOnPage = 0 ;
                  }
                  if ( StringUtil.StrCmp(cgiGet( "GXH__CENFERMERODOMICILIO"), AV9cEnfermeroDomicilio) != 0 )
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
                              nGXsfl_41_idx = (short)(NumberUtil.Val( sEvtType, ".")) ;
                              sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_41_idx), 4, 0)), 4, "0") ;
                              edtavLinkselection_Internalname = "_LINKSELECTION_"+sGXsfl_41_idx ;
                              edtEnfermeroId_Internalname = "ENFERMEROID_"+sGXsfl_41_idx ;
                              edtEnfermeroNombre_Internalname = "ENFERMERONOMBRE_"+sGXsfl_41_idx ;
                              edtEnfermeroApellido_Internalname = "ENFERMEROAPELLIDO_"+sGXsfl_41_idx ;
                              edtEnfermeroDomicilio_Internalname = "ENFERMERODOMICILIO_"+sGXsfl_41_idx ;
                              cmbEnfermeroEstadoCivil_Internalname = "ENFERMEROESTADOCIVIL_"+sGXsfl_41_idx ;
                              AV5LinkSelection = cgiGet( "GXimg"+edtavLinkselection_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavLinkselection_Internalname, "Bitmap", context.convertURL( AV5LinkSelection));
                              A20EnfermeroId = (int)(context.localUtil.CToN( cgiGet( edtEnfermeroId_Internalname), ",", ".")) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A20EnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(A20EnfermeroId), 6, 0)));
                              A21EnfermeroNombre = cgiGet( edtEnfermeroNombre_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A21EnfermeroNombre", A21EnfermeroNombre);
                              A22EnfermeroApellido = cgiGet( edtEnfermeroApellido_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A22EnfermeroApellido", A22EnfermeroApellido);
                              A23EnfermeroDomicilio = cgiGet( edtEnfermeroDomicilio_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A23EnfermeroDomicilio", A23EnfermeroDomicilio);
                              cmbEnfermeroEstadoCivil.Name = cmbEnfermeroEstadoCivil_Internalname ;
                              cmbEnfermeroEstadoCivil.CurrentValue = cgiGet( cmbEnfermeroEstadoCivil_Internalname) ;
                              A24EnfermeroEstadoCivil = cgiGet( cmbEnfermeroEstadoCivil_Internalname) ;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A24EnfermeroEstadoCivil", A24EnfermeroEstadoCivil);
                              sEvtType = StringUtil.Right( sEvt, 1) ;
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1)) ;
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    dynload_actions( ) ;
                                    /* Execute user event: E110K2 */
                                    E110K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    dynload_actions( ) ;
                                    /* Execute user event: E120K2 */
                                    E120K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1 ;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false ;
                                       /* Set Refresh If Cenfermeronombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH__CENFERMERONOMBRE"), AV7cEnfermeroNombre) != 0 )
                                       {
                                          Rfr0gs = true ;
                                       }
                                       /* Set Refresh If Cenfermeroapellido Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH__CENFERMEROAPELLIDO"), AV8cEnfermeroApellido) != 0 )
                                       {
                                          Rfr0gs = true ;
                                       }
                                       /* Set Refresh If Cenfermerodomicilio Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH__CENFERMERODOMICILIO"), AV9cEnfermeroDomicilio) != 0 )
                                       {
                                          Rfr0gs = true ;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: E130K2 */
                                          E130K2 ();
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

      protected void WE0K2( )
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

      protected void PA0K2( )
      {
         if ( nDonePA == 0 )
         {
            cmbavCenfermeroestadocivil.Name = "_CENFERMEROESTADOCIVIL" ;
            cmbavCenfermeroestadocivil.WebTags = "" ;
            cmbavCenfermeroestadocivil.addItem("S", "Soltero", 0);
            cmbavCenfermeroestadocivil.addItem("C", "Casado", 0);
            cmbavCenfermeroestadocivil.addItem("V", "Viudo", 0);
            cmbavCenfermeroestadocivil.addItem("D", "Divorciado", 0);
            if ( ( cmbavCenfermeroestadocivil.ItemCount > 0 ) && String.IsNullOrEmpty(StringUtil.RTrim( AV10cEnfermeroEstadoCivil)) )
            {
               AV10cEnfermeroEstadoCivil = cmbavCenfermeroestadocivil.getItemValue(1) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV10cEnfermeroEstadoCivil", AV10cEnfermeroEstadoCivil);
            }
            GXCCtl = "ENFERMEROESTADOCIVIL_" + sGXsfl_41_idx ;
            cmbEnfermeroEstadoCivil.Name = GXCCtl ;
            cmbEnfermeroEstadoCivil.WebTags = "" ;
            cmbEnfermeroEstadoCivil.addItem("S", "Soltero", 0);
            cmbEnfermeroEstadoCivil.addItem("C", "Casado", 0);
            cmbEnfermeroEstadoCivil.addItem("V", "Viudo", 0);
            cmbEnfermeroEstadoCivil.addItem("D", "Divorciado", 0);
            if ( ( cmbEnfermeroEstadoCivil.ItemCount > 0 ) && String.IsNullOrEmpty(StringUtil.RTrim( A24EnfermeroEstadoCivil)) )
            {
               A24EnfermeroEstadoCivil = cmbEnfermeroEstadoCivil.getItemValue(1) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A24EnfermeroEstadoCivil", A24EnfermeroEstadoCivil);
            }
            GX_FocusControl = edtavCenfermeroid_Internalname ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            nDonePA = 1 ;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( short nRC_Grid1 ,
                                       short nGXsfl_41_idx ,
                                       String sGXsfl_41_idx )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         edtavLinkselection_Internalname = "_LINKSELECTION_"+sGXsfl_41_idx ;
         edtEnfermeroId_Internalname = "ENFERMEROID_"+sGXsfl_41_idx ;
         edtEnfermeroNombre_Internalname = "ENFERMERONOMBRE_"+sGXsfl_41_idx ;
         edtEnfermeroApellido_Internalname = "ENFERMEROAPELLIDO_"+sGXsfl_41_idx ;
         edtEnfermeroDomicilio_Internalname = "ENFERMERODOMICILIO_"+sGXsfl_41_idx ;
         cmbEnfermeroEstadoCivil_Internalname = "ENFERMEROESTADOCIVIL_"+sGXsfl_41_idx ;
         while ( nGXsfl_41_idx <= nRC_Grid1 )
         {
            sendrow_412( ) ;
            nGXsfl_41_idx = (short)(((subGrid1_Islastpage==1)&&(nGXsfl_41_idx+1>subGrid1_Recordsperpage( )) ? 1 : nGXsfl_41_idx+1)) ;
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_41_idx), 4, 0)), 4, "0") ;
            edtavLinkselection_Internalname = "_LINKSELECTION_"+sGXsfl_41_idx ;
            edtEnfermeroId_Internalname = "ENFERMEROID_"+sGXsfl_41_idx ;
            edtEnfermeroNombre_Internalname = "ENFERMERONOMBRE_"+sGXsfl_41_idx ;
            edtEnfermeroApellido_Internalname = "ENFERMEROAPELLIDO_"+sGXsfl_41_idx ;
            edtEnfermeroDomicilio_Internalname = "ENFERMERODOMICILIO_"+sGXsfl_41_idx ;
            cmbEnfermeroEstadoCivil_Internalname = "ENFERMEROESTADOCIVIL_"+sGXsfl_41_idx ;
         }
         context.GX_webresponse.AddString(Grid1Container.ToJavascriptSource());
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int Grid1_PageSize41 ,
                                        String AV7cEnfermeroNombre ,
                                        String AV8cEnfermeroApellido ,
                                        String AV9cEnfermeroDomicilio )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         disableOutput();
         subGrid1_Rows = (short)(Grid1_PageSize41) ;
         RF0K2( ) ;
         enableOutput();
         context.GX_webresponse.AddString(Grid1Container.ToJavascriptSource());
         /* End function gxgrGrid1_refresh */
      }

      protected void Refresh( )
      {
         RF0K2( ) ;
         /* End function Refresh */
      }

      protected void RF0K2( )
      {
         Grid1Container.PageSize = subGrid1_Recordsperpage( ) ;
         wbStart = 41 ;
         nGXsfl_41_idx = 1 ;
         sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_41_idx), 4, 0)), 4, "0") ;
         edtavLinkselection_Internalname = "_LINKSELECTION_"+sGXsfl_41_idx ;
         edtEnfermeroId_Internalname = "ENFERMEROID_"+sGXsfl_41_idx ;
         edtEnfermeroNombre_Internalname = "ENFERMERONOMBRE_"+sGXsfl_41_idx ;
         edtEnfermeroApellido_Internalname = "ENFERMEROAPELLIDO_"+sGXsfl_41_idx ;
         edtEnfermeroDomicilio_Internalname = "ENFERMERODOMICILIO_"+sGXsfl_41_idx ;
         cmbEnfermeroEstadoCivil_Internalname = "ENFERMEROESTADOCIVIL_"+sGXsfl_41_idx ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
         {
            lV7cEnfermeroNombre = StringUtil.PadR( StringUtil.RTrim( AV7cEnfermeroNombre), 20, "%") ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7cEnfermeroNombre", AV7cEnfermeroNombre);
            lV8cEnfermeroApellido = StringUtil.PadR( StringUtil.RTrim( AV8cEnfermeroApellido), 20, "%") ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV8cEnfermeroApellido", AV8cEnfermeroApellido);
            lV9cEnfermeroDomicilio = StringUtil.PadR( StringUtil.RTrim( AV9cEnfermeroDomicilio), 40, "%") ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV9cEnfermeroDomicilio", AV9cEnfermeroDomicilio);
            /* Using cursor H000K2 */
            pr_default.execute(0, new Object[] {lV7cEnfermeroNombre, lV8cEnfermeroApellido, lV9cEnfermeroDomicilio});
            nGXsfl_41_idx = 1 ;
            GRID1_nEOF = 0 ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( 10 == 0 ) || ( GRID1_nCurrentRecord < GRID1_nFirstRecordOnPage + subGrid1_Recordsperpage( ) ) ) ) )
            {
               A24EnfermeroEstadoCivil = H000K2_A24EnfermeroEstadoCivil[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A24EnfermeroEstadoCivil", A24EnfermeroEstadoCivil);
               A23EnfermeroDomicilio = H000K2_A23EnfermeroDomicilio[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A23EnfermeroDomicilio", A23EnfermeroDomicilio);
               A22EnfermeroApellido = H000K2_A22EnfermeroApellido[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A22EnfermeroApellido", A22EnfermeroApellido);
               A21EnfermeroNombre = H000K2_A21EnfermeroNombre[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A21EnfermeroNombre", A21EnfermeroNombre);
               A20EnfermeroId = H000K2_A20EnfermeroId[0] ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A20EnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(A20EnfermeroId), 6, 0)));
               /* Execute user event: E120K2 */
               E120K2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0)) ;
            pr_default.close(0);
            wbEnd = 41 ;
            WB0K0( ) ;
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
         lV7cEnfermeroNombre = StringUtil.PadR( StringUtil.RTrim( AV7cEnfermeroNombre), 20, "%") ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7cEnfermeroNombre", AV7cEnfermeroNombre);
         lV8cEnfermeroApellido = StringUtil.PadR( StringUtil.RTrim( AV8cEnfermeroApellido), 20, "%") ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV8cEnfermeroApellido", AV8cEnfermeroApellido);
         lV9cEnfermeroDomicilio = StringUtil.PadR( StringUtil.RTrim( AV9cEnfermeroDomicilio), 40, "%") ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV9cEnfermeroDomicilio", AV9cEnfermeroDomicilio);
         /* Using cursor H000K3 */
         pr_default.execute(1, new Object[] {lV7cEnfermeroNombre, lV8cEnfermeroApellido, lV9cEnfermeroDomicilio});
         GRID1_nRecordCount = H000K3_AGRID1_nRecordCount[0] ;
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

      protected void STRUP0K0( )
      {
         /* Before Start, stand alone formulas. */
         context.Gx_err = 0 ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0 ;
         /* Execute user event: E110K2 */
         E110K2 ();
         context.wbGlbDoneStart = 1 ;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCenfermeroid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCenfermeroid_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum"), 1, "_CENFERMEROID");
               GX_FocusControl = edtavCenfermeroid_Internalname ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true ;
               AV6cEnfermeroId = 0 ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV6cEnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV6cEnfermeroId), 6, 0)));
            }
            else
            {
               AV6cEnfermeroId = (int)(context.localUtil.CToN( cgiGet( edtavCenfermeroid_Internalname), ",", ".")) ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV6cEnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV6cEnfermeroId), 6, 0)));
            }
            AV7cEnfermeroNombre = cgiGet( edtavCenfermeronombre_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV7cEnfermeroNombre", AV7cEnfermeroNombre);
            AV8cEnfermeroApellido = cgiGet( edtavCenfermeroapellido_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV8cEnfermeroApellido", AV8cEnfermeroApellido);
            AV9cEnfermeroDomicilio = cgiGet( edtavCenfermerodomicilio_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV9cEnfermeroDomicilio", AV9cEnfermeroDomicilio);
            cmbavCenfermeroestadocivil.Name = cmbavCenfermeroestadocivil_Internalname ;
            cmbavCenfermeroestadocivil.CurrentValue = cgiGet( cmbavCenfermeroestadocivil_Internalname) ;
            AV10cEnfermeroEstadoCivil = cgiGet( cmbavCenfermeroestadocivil_Internalname) ;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV10cEnfermeroEstadoCivil", AV10cEnfermeroEstadoCivil);
            /* Read saved values. */
            nRC_Grid1 = (short)(context.localUtil.CToN( cgiGet( "nRC_Grid1"), ",", ".")) ;
            AV12pEnfermeroId = (int)(context.localUtil.CToN( cgiGet( "_PENFERMEROID"), ",", ".")) ;
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
         /* Execute user event: E110K2 */
         E110K2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E110K2( )
      {
         /* Start Routine */
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "Enfermero", "", "", "", "", "", "", "", "") ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, "FORM", "Caption", Form.Caption);
      }

      private void E120K2( )
      {
         /* Load Routine */
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", "GeneXusX") ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtavLinkselection_Internalname, "Bitmap", context.convertURL( AV5LinkSelection));
         if ( ( subGrid1_Islastpage == 1 ) || ( 10 == 0 ) || ( ( GRID1_nCurrentRecord >= GRID1_nFirstRecordOnPage ) && ( GRID1_nCurrentRecord < GRID1_nFirstRecordOnPage + subGrid1_Recordsperpage( ) ) ) )
         {
            sendrow_412( ) ;
         }
         GRID1_nCurrentRecord = (int)(GRID1_nCurrentRecord+1) ;
      }

      public void GXEnter( )
      {
         /* Execute user event: E130K2 */
         E130K2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E130K2( )
      {
         /* Enter Routine */
         AV12pEnfermeroId = A20EnfermeroId ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV12pEnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV12pEnfermeroId), 6, 0)));
         context.setWebReturnParms(new Object[] {(int)AV12pEnfermeroId});
         context.nUserReturn = 1 ;
         returnInSub = true;
         if (true) return;
      }

      protected void wb_table1_2_0K2( bool wbgen )
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
            wb_table2_9_0K2( true) ;
         }
         else
         {
            wb_table2_9_0K2( false) ;
         }
         return  ;
      }

      protected void wb_table2_9_0K2e( bool wbgen )
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
            wb_table3_38_0K2( true) ;
         }
         else
         {
            wb_table3_38_0K2( false) ;
         }
         return  ;
      }

      protected void wb_table3_38_0K2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</fieldset>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_2_0K2e( true) ;
         }
         else
         {
            wb_table1_2_0K2e( false) ;
         }
      }

      protected void wb_table3_38_0K2( bool wbgen )
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
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A20EnfermeroId), 6, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A21EnfermeroNombre));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtEnfermeroNombre_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A22EnfermeroApellido));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A23EnfermeroDomicilio));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A24EnfermeroEstadoCivil));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Container.AddObjectProperty("Allowselection", "false");
               Grid1Container.AddObjectProperty("Allowcollapsing", "false");
               Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 9, 0, ".", "")));
            }
         }
         if ( wbEnd == 41 )
         {
            wbEnd = 0 ;
            nRC_Grid1 = (short)(nGXsfl_41_idx-1) ;
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
            wb_table4_50_0K2( true) ;
         }
         else
         {
            wb_table4_50_0K2( false) ;
         }
         return  ;
      }

      protected void wb_table4_50_0K2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_38_0K2e( true) ;
         }
         else
         {
            wb_table3_38_0K2e( false) ;
         }
      }

      protected void wb_table4_50_0K2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTable4_Internalname, tblTable4_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"" ;
            ClassString = "BtnCancel" ;
            StyleString = "" ;
            GxWebStd.gx_button_ctrl( context, context.GetButtonType( ), bttBtn_cancel_Internalname, "Cancelar", "Cancelar", "", StyleString, ClassString, 1, 1, "rounded", 1, bttBtn_cancel_Jsonclick, "ECANCEL.", TempTags, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 3, 0)+","+"null"+");", "", "HLP_Gx0030.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_50_0K2e( true) ;
         }
         else
         {
            wb_table4_50_0K2e( false) ;
         }
      }

      protected void wb_table2_9_0K2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblTextblockenfermeroid_Internalname, 1, 1, 0, "Enfermero Id", "", "", "", 0, lblTextblockenfermeroid_Jsonclick, "", StyleString, ClassString, "HLP_Gx0030.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'" + sGXsfl_41_idx + "',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtavCenfermeroid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cEnfermeroId), 6, 0, ",", "")), "", 6, "chr", 1, "row", 6, 1, 1, 0, 0, 0, "", "", StyleString, ClassString, "", context.localUtil.Format( (decimal)(AV6cEnfermeroId), "ZZZZZ9"), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(14);\"", 0, edtavCenfermeroid_Jsonclick, "", 0, 1, -1, true, "right", "HLP_Gx0030.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockenfermeronombre_Internalname, 1, 1, 0, "Enfermero Nombre", "", "", "", 0, lblTextblockenfermeronombre_Jsonclick, "", StyleString, ClassString, "HLP_Gx0030.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'" + sGXsfl_41_idx + "',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtavCenfermeronombre_Internalname, StringUtil.RTrim( AV7cEnfermeroNombre), "", 20, "chr", 1, "row", 20, 1, 1, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( AV7cEnfermeroNombre, "XXXXXXXXXXXXXXXXXXXX")), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(19);\"", 0, edtavCenfermeronombre_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Gx0030.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockenfermeroapellido_Internalname, 1, 1, 0, "Enfermero Apellido", "", "", "", 0, lblTextblockenfermeroapellido_Jsonclick, "", StyleString, ClassString, "HLP_Gx0030.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'" + sGXsfl_41_idx + "',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtavCenfermeroapellido_Internalname, StringUtil.RTrim( AV8cEnfermeroApellido), "", 20, "chr", 1, "row", 20, 1, 1, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( AV8cEnfermeroApellido, "XXXXXXXXXXXXXXXXXXXX")), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(24);\"", 0, edtavCenfermeroapellido_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Gx0030.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockenfermerodomicilio_Internalname, 1, 1, 0, "Enfermero Domicilio", "", "", "", 0, lblTextblockenfermerodomicilio_Jsonclick, "", StyleString, ClassString, "HLP_Gx0030.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_41_idx + "',0)\"" ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            GxWebStd.gx_single_line_edit( context, edtavCenfermerodomicilio_Internalname, StringUtil.RTrim( AV9cEnfermeroDomicilio), "", 40, "chr", 1, "row", 40, 1, 1, 0, 0, 0, "", "", StyleString, ClassString, "", StringUtil.RTrim( context.localUtil.Format( AV9cEnfermeroDomicilio, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")), TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(29);\"", 0, edtavCenfermerodomicilio_Jsonclick, "", 0, 1, -1, true, "left", "HLP_Gx0030.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockenfermeroestadocivil_Internalname, 1, 1, 0, "Enfermero Estado Civil", "", "", "", 0, lblTextblockenfermeroestadocivil_Jsonclick, "", StyleString, ClassString, "HLP_Gx0030.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            ClassString = "Attribute" ;
            StyleString = "" ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_41_idx + "',0)\"" ;
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCenfermeroestadocivil, cmbavCenfermeroestadocivil_Internalname, AV10cEnfermeroEstadoCivil, "", "char", 1, 1, 0, 1, 0, 1, "chr", 0, "", StyleString, ClassString, "", 0, cmbavCenfermeroestadocivil_Jsonclick, "", TempTags+" onchange=\"gx.evt.onchange(this)\" "+" onblur=\""+""+";gx.evt.onblur(34);\"", true, "HLP_Gx0030.htm");
            cmbavCenfermeroestadocivil.CurrentValue = AV10cEnfermeroEstadoCivil ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, cmbavCenfermeroestadocivil_Internalname, "Values", (String)(cmbavCenfermeroestadocivil.ToJavascriptSource()));
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_9_0K2e( true) ;
         }
         else
         {
            wb_table2_9_0K2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV12pEnfermeroId = Convert.ToInt32(getParm(obj,0)) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "AV12pEnfermeroId", StringUtil.LTrim( StringUtil.Str( (decimal)(AV12pEnfermeroId), 6, 0)));
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
         PA0K2( ) ;
         WS0K2( ) ;
         WE0K2( ) ;
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
         AddThemeStyleSheetFile("", "GeneXusX.css", "?2313925");
         idxLst = 1 ;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( Form.Jscriptsrc.Item(idxLst)), "?401895");
            idxLst = (int)(idxLst+1) ;
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?34981");
         context.AddJavascriptSource("gx0030.js", "?401895");
         /* End function include_jscripts */
      }

      protected void sendrow_412( )
      {
         WB0K0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_41_idx <= subGrid1_Recordsperpage( ) * 1 ) )
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
               if ( ((int)(nGXsfl_41_idx) % (2)) == 0 )
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A20EnfermeroId), 6, 0, ",", "")))+"'"+"]);" ;
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtEnfermeroId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A20EnfermeroId), 6, 0, ",", "")),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)6,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,context.localUtil.Format( (decimal)(A20EnfermeroId), "ZZZZZ9"),(String)"",(short)0,(String)edtEnfermeroId_Jsonclick,(String)"",(short)41,(short)1,(short)1,(bool)true,(String)"right"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            edtEnfermeroNombre_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A20EnfermeroId), 6, 0, ",", "")))+"'"+"]);" ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtEnfermeroNombre_Internalname, "Link", edtEnfermeroNombre_Link);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtEnfermeroNombre_Internalname,StringUtil.RTrim( A21EnfermeroNombre),(String)"Seleccionar",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)edtEnfermeroNombre_Link,(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A21EnfermeroNombre, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtEnfermeroNombre_Jsonclick,(String)"",(short)41,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtEnfermeroApellido_Internalname,StringUtil.RTrim( A22EnfermeroApellido),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)20,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A22EnfermeroApellido, "XXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtEnfermeroApellido_Jsonclick,(String)"",(short)41,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ClassString = "Attribute" ;
            StyleString = "" ;
            ROClassString = ClassString ;
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtEnfermeroDomicilio_Internalname,StringUtil.RTrim( A23EnfermeroDomicilio),(String)"",(short)0,(String)"px",(short)17,(String)"",(short)40,(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)ROClassString,StringUtil.RTrim( context.localUtil.Format( A23EnfermeroDomicilio, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")),(String)"",(short)0,(String)edtEnfermeroDomicilio_Jsonclick,(String)"",(short)41,(short)1,(short)1,(bool)true,(String)"left"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((-1==0) ? "display:none;" : "")+"\">") ;
            }
            ClassString = "Attribute" ;
            StyleString = "" ;
            if ( ( nGXsfl_41_idx == 1 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "ENFERMEROESTADOCIVIL_" + sGXsfl_41_idx ;
               cmbEnfermeroEstadoCivil.Name = GXCCtl ;
               cmbEnfermeroEstadoCivil.WebTags = "" ;
               cmbEnfermeroEstadoCivil.addItem("S", "Soltero", 0);
               cmbEnfermeroEstadoCivil.addItem("C", "Casado", 0);
               cmbEnfermeroEstadoCivil.addItem("V", "Viudo", 0);
               cmbEnfermeroEstadoCivil.addItem("D", "Divorciado", 0);
               if ( ( cmbEnfermeroEstadoCivil.ItemCount > 0 ) && String.IsNullOrEmpty(StringUtil.RTrim( A24EnfermeroEstadoCivil)) )
               {
                  A24EnfermeroEstadoCivil = cmbEnfermeroEstadoCivil.getItemValue(1) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A24EnfermeroEstadoCivil", A24EnfermeroEstadoCivil);
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbEnfermeroEstadoCivil,(String)cmbEnfermeroEstadoCivil_Internalname,(String)A24EnfermeroEstadoCivil,(String)"",(String)"char",(short)-1,(short)0,(short)0,(short)1,(short)0,(short)0,(String)"px",(short)0,(String)"",(String)StyleString,(String)ClassString,(String)"",(short)0,(String)cmbEnfermeroEstadoCivil_Jsonclick,(String)"",(String)"",(bool)true});
            cmbEnfermeroEstadoCivil.CurrentValue = A24EnfermeroEstadoCivil ;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, cmbEnfermeroEstadoCivil_Internalname, "Values", (String)(cmbEnfermeroEstadoCivil.ToJavascriptSource()));
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_41_idx = (short)(((subGrid1_Islastpage==1)&&(nGXsfl_41_idx+1>subGrid1_Recordsperpage( )) ? 1 : nGXsfl_41_idx+1)) ;
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_41_idx), 4, 0)), 4, "0") ;
            edtavLinkselection_Internalname = "_LINKSELECTION_"+sGXsfl_41_idx ;
            edtEnfermeroId_Internalname = "ENFERMEROID_"+sGXsfl_41_idx ;
            edtEnfermeroNombre_Internalname = "ENFERMERONOMBRE_"+sGXsfl_41_idx ;
            edtEnfermeroApellido_Internalname = "ENFERMEROAPELLIDO_"+sGXsfl_41_idx ;
            edtEnfermeroDomicilio_Internalname = "ENFERMERODOMICILIO_"+sGXsfl_41_idx ;
            cmbEnfermeroEstadoCivil_Internalname = "ENFERMEROESTADOCIVIL_"+sGXsfl_41_idx ;
         }
         /* End function sendrow_412 */
      }

      public override void initialize_properties( )
      {
         lblTextblockenfermeroid_Internalname = "TEXTBLOCKENFERMEROID" ;
         edtavCenfermeroid_Internalname = "_CENFERMEROID" ;
         lblTextblockenfermeronombre_Internalname = "TEXTBLOCKENFERMERONOMBRE" ;
         edtavCenfermeronombre_Internalname = "_CENFERMERONOMBRE" ;
         lblTextblockenfermeroapellido_Internalname = "TEXTBLOCKENFERMEROAPELLIDO" ;
         edtavCenfermeroapellido_Internalname = "_CENFERMEROAPELLIDO" ;
         lblTextblockenfermerodomicilio_Internalname = "TEXTBLOCKENFERMERODOMICILIO" ;
         edtavCenfermerodomicilio_Internalname = "_CENFERMERODOMICILIO" ;
         lblTextblockenfermeroestadocivil_Internalname = "TEXTBLOCKENFERMEROESTADOCIVIL" ;
         cmbavCenfermeroestadocivil_Internalname = "_CENFERMEROESTADOCIVIL" ;
         tblTable2_Internalname = "TABLE2" ;
         grpGroup1_Internalname = "GROUP1" ;
         bttBtn_cancel_Internalname = "BTN_CANCEL" ;
         tblTable4_Internalname = "TABLE4" ;
         tblTable3_Internalname = "TABLE3" ;
         grpGroup2_Internalname = "GROUP2" ;
         tblTable1_Internalname = "TABLE1" ;
         Form.Internalname = "FORM" ;
         subGrid1_Internalname = "GRID1" ;
         cmbEnfermeroEstadoCivil_Jsonclick = "" ;
         edtEnfermeroDomicilio_Jsonclick = "" ;
         edtEnfermeroApellido_Jsonclick = "" ;
         edtEnfermeroNombre_Jsonclick = "" ;
         edtEnfermeroId_Jsonclick = "" ;
         cmbavCenfermeroestadocivil_Jsonclick = "" ;
         edtavCenfermerodomicilio_Jsonclick = "" ;
         edtavCenfermeroapellido_Jsonclick = "" ;
         edtavCenfermeronombre_Jsonclick = "" ;
         edtavCenfermeroid_Jsonclick = "" ;
         edtEnfermeroNombre_Link = "" ;
         edtavLinkselection_Link = "" ;
         subGrid1_Class = "Grid" ;
         subGrid1_Backcolorstyle = 2 ;
         Form.Headerrawhtml = "" ;
         Form.Background = "" ;
         Form.Backcolor = (int)(0xFFFFFF) ;
         Form.Caption = "Selection List Enfermero" ;
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
         AV10cEnfermeroEstadoCivil = "" ;
         GXCCtl = "" ;
         A24EnfermeroEstadoCivil = "" ;
         AV7cEnfermeroNombre = "" ;
         AV8cEnfermeroApellido = "" ;
         AV9cEnfermeroDomicilio = "" ;
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
         edtEnfermeroId_Internalname = "" ;
         edtEnfermeroNombre_Internalname = "" ;
         edtEnfermeroApellido_Internalname = "" ;
         edtEnfermeroDomicilio_Internalname = "" ;
         cmbEnfermeroEstadoCivil_Internalname = "" ;
         AV5LinkSelection = "" ;
         A21EnfermeroNombre = "" ;
         A22EnfermeroApellido = "" ;
         A23EnfermeroDomicilio = "" ;
         Grid1Container = new GXWebGrid( context);
         scmdbuf = "" ;
         lV7cEnfermeroNombre = "" ;
         lV8cEnfermeroApellido = "" ;
         lV9cEnfermeroDomicilio = "" ;
         H000K2_A24EnfermeroEstadoCivil = new String[] {""} ;
         H000K2_A23EnfermeroDomicilio = new String[] {""} ;
         H000K2_A22EnfermeroApellido = new String[] {""} ;
         H000K2_A21EnfermeroNombre = new String[] {""} ;
         H000K2_A20EnfermeroId = new int[1] ;
         H000K3_AGRID1_nRecordCount = new int[1] ;
         sStyleString = "" ;
         ClassString = "" ;
         StyleString = "" ;
         subGrid1_Linesclass = "" ;
         GXt_char3 = "" ;
         GXt_char2 = "" ;
         GXt_char1 = "" ;
         GXt_char4 = "" ;
         Grid1Column = new GXWebColumn();
         GXt_char6 = "" ;
         GXt_char5 = "" ;
         TempTags = "" ;
         bttBtn_cancel_Jsonclick = "" ;
         lblTextblockenfermeroid_Jsonclick = "" ;
         lblTextblockenfermeronombre_Jsonclick = "" ;
         lblTextblockenfermeroapellido_Jsonclick = "" ;
         lblTextblockenfermerodomicilio_Jsonclick = "" ;
         lblTextblockenfermeroestadocivil_Jsonclick = "" ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         Grid1Row = new GXWebRow();
         ROClassString = "" ;
         GXt_char7 = "" ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0030__default(),
            new Object[][] {
                new Object[] {
               H000K2_A24EnfermeroEstadoCivil, H000K2_A23EnfermeroDomicilio, H000K2_A22EnfermeroApellido, H000K2_A21EnfermeroNombre, H000K2_A20EnfermeroId
               }
               , new Object[] {
               H000K3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0 ;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nRC_Grid1 ;
      private short nGXsfl_41_idx=1 ;
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
      private int AV12pEnfermeroId ;
      private int wcpOAV12pEnfermeroId ;
      private int Grid1_PageSize41 ;
      private int GRID1_nFirstRecordOnPage ;
      private int A20EnfermeroId ;
      private int subGrid1_Islastpage ;
      private int GRID1_nCurrentRecord ;
      private int GRID1_nRecordCount ;
      private int AV6cEnfermeroId ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_41_idx="0001" ;
      private String AV10cEnfermeroEstadoCivil ;
      private String GXCCtl ;
      private String A24EnfermeroEstadoCivil ;
      private String AV7cEnfermeroNombre ;
      private String AV8cEnfermeroApellido ;
      private String AV9cEnfermeroDomicilio ;
      private String sDynURL ;
      private String FormProcess ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavLinkselection_Internalname ;
      private String edtEnfermeroId_Internalname ;
      private String edtEnfermeroNombre_Internalname ;
      private String edtEnfermeroApellido_Internalname ;
      private String edtEnfermeroDomicilio_Internalname ;
      private String cmbEnfermeroEstadoCivil_Internalname ;
      private String A21EnfermeroNombre ;
      private String A22EnfermeroApellido ;
      private String A23EnfermeroDomicilio ;
      private String edtavCenfermeroid_Internalname ;
      private String scmdbuf ;
      private String lV7cEnfermeroNombre ;
      private String lV8cEnfermeroApellido ;
      private String lV9cEnfermeroDomicilio ;
      private String edtavCenfermeronombre_Internalname ;
      private String edtavCenfermeroapellido_Internalname ;
      private String edtavCenfermerodomicilio_Internalname ;
      private String cmbavCenfermeroestadocivil_Internalname ;
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
      private String edtavLinkselection_Link ;
      private String edtEnfermeroNombre_Link ;
      private String GXt_char6 ;
      private String GXt_char5 ;
      private String tblTable4_Internalname ;
      private String TempTags ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String tblTable2_Internalname ;
      private String lblTextblockenfermeroid_Internalname ;
      private String lblTextblockenfermeroid_Jsonclick ;
      private String edtavCenfermeroid_Jsonclick ;
      private String lblTextblockenfermeronombre_Internalname ;
      private String lblTextblockenfermeronombre_Jsonclick ;
      private String edtavCenfermeronombre_Jsonclick ;
      private String lblTextblockenfermeroapellido_Internalname ;
      private String lblTextblockenfermeroapellido_Jsonclick ;
      private String edtavCenfermeroapellido_Jsonclick ;
      private String lblTextblockenfermerodomicilio_Internalname ;
      private String lblTextblockenfermerodomicilio_Jsonclick ;
      private String edtavCenfermerodomicilio_Jsonclick ;
      private String lblTextblockenfermeroestadocivil_Internalname ;
      private String lblTextblockenfermeroestadocivil_Jsonclick ;
      private String cmbavCenfermeroestadocivil_Jsonclick ;
      private String ROClassString ;
      private String edtEnfermeroId_Jsonclick ;
      private String edtEnfermeroNombre_Jsonclick ;
      private String edtEnfermeroApellido_Jsonclick ;
      private String edtEnfermeroDomicilio_Jsonclick ;
      private String cmbEnfermeroEstadoCivil_Jsonclick ;
      private String GXt_char7 ;
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
      private int aP0_pEnfermeroId ;
      private GXCombobox cmbavCenfermeroestadocivil ;
      private GXCombobox cmbEnfermeroEstadoCivil ;
      private IDataStoreProvider pr_default ;
      private String[] H000K2_A24EnfermeroEstadoCivil ;
      private String[] H000K2_A23EnfermeroDomicilio ;
      private String[] H000K2_A22EnfermeroApellido ;
      private String[] H000K2_A21EnfermeroNombre ;
      private int[] H000K2_A20EnfermeroId ;
      private int[] H000K3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

   public class gx0030__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH000K2 ;
          prmH000K2 = new Object[] {
          new Object[] {"@AV7cEnfermeroNombre",SqlDbType.Char,20,0} ,
          new Object[] {"@AV8cEnfermeroApellido",SqlDbType.Char,20,0} ,
          new Object[] {"@AV9cEnfermeroDomicilio",SqlDbType.Char,40,0}
          } ;
          Object[] prmH000K3 ;
          prmH000K3 = new Object[] {
          new Object[] {"@AV7cEnfermeroNombre",SqlDbType.Char,20,0} ,
          new Object[] {"@AV8cEnfermeroApellido",SqlDbType.Char,20,0} ,
          new Object[] {"@AV9cEnfermeroDomicilio",SqlDbType.Char,40,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H000K2", "SELECT [EnfermeroEstadoCivil], [EnfermeroDomicilio], [EnfermeroApellido], [EnfermeroNombre], [EnfermeroId] FROM [Enfermero] WITH (NOLOCK) WHERE ([EnfermeroNombre] like @AV7cEnfermeroNombre) AND ([EnfermeroApellido] like @AV8cEnfermeroApellido) AND ([EnfermeroDomicilio] like @AV9cEnfermeroDomicilio) ORDER BY [EnfermeroId]  OPTION (FAST 11)",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000K2,11,0,false,false )
             ,new CursorDef("H000K3", "SELECT COUNT(*) FROM [Enfermero] WITH (NOLOCK) WHERE ([EnfermeroNombre] like @AV7cEnfermeroNombre) AND ([EnfermeroApellido] like @AV8cEnfermeroApellido) AND ([EnfermeroDomicilio] like @AV9cEnfermeroDomicilio) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000K3,1,0,false,false )
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
                ((String[]) buf[0])[0] = rslt.getString(1, 1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 40) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                ((String[]) buf[3])[0] = rslt.getString(4, 20) ;
                ((int[]) buf[4])[0] = rslt.getInt(5) ;
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
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (String)parms[2]);
                break;
             case 1 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (String)parms[2]);
                break;
       }
    }

 }

}
