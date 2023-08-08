/*
               File: NotAuthorized
        Description: Not Authorized web panel
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/22/2010 3:59:19.39
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
   public class notauthorized : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public notauthorized( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public notauthorized( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default") ;
      }

      public void release( )
      {
      }

      public void execute( String aP0_GxObject )
      {
         this.GxObject = aP0_GxObject;
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
               GxObject = gxfirstwebparm ;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GxObject", GxObject);
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
         PA042( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0)) ;
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START042( ) ;
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
         FormProcess = " onkeyup=\"gx.evt.onkeyup(event)\" onkeypress=\"gx.evt.onkeypress(event,false,false)\" onkeydown=\"gx.evt.onkeypress(null,false,false)\"" ;
         context.WriteHtmlText( "<body") ;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            context.WriteHtmlText( " background=\""+context.convertURL( Form.Background)+"\"") ;
         }
         context.WriteHtmlText( " "+"class=\"Form\""+" "+" style=\"-moz-opacity:0;opacity:0;"+"\""+" bgcolor=\""+context.BuildHTMLColor( Form.Backcolor)+"\""+FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" onsubmit=\"try{return gx.csv.validForm()}catch(e){return true;}\" name=\"MAINFORM\" method=\"post\" action=\""+formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(GxObject))+"\" class=\""+"Form"+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
      }

      public override void RenderHtmlCloseForm( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         GxWebStd.gx_hidden_field( context, "_GXOBJECT", StringUtil.RTrim( GxObject));
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendComponentObjects();
         SendServerCommands();
         SendState();
         context.WriteHtmlTextNl( "</form>") ;
         include_jscripts( ) ;
         if ( ! ( WebComp_Headerbc == null ) )
         {
            WebComp_Headerbc.componentjscripts();
         }
         if ( ! ( WebComp_Recentlinks == null ) )
         {
            WebComp_Recentlinks.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0)) ;
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            WE042( ) ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT042( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override String GetPgmname( )
      {
         return "NotAuthorized" ;
      }

      public override String GetPgmdesc( )
      {
         return "Not Authorized web panel" ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(GxObject)) ;
      }

      protected void WB040( )
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
            /* WebComponent */
            GxWebStd.gx_hidden_field( context, "W0002"+"", StringUtil.RTrim( WebComp_Headerbc_Component));
            context.WriteHtmlText( "<div") ;
            context.WriteHtmlText( " id=\""+"gxHTMLWrpW0002"+""+"\""+"") ;
            context.WriteHtmlText( ">") ;
            if ( StringUtil.StrCmp(OldHeaderbc, WebComp_Headerbc_Component) != 0 )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0002"+"");
            }
            WebComp_Headerbc.componentdraw();
            if ( StringUtil.StrCmp(OldHeaderbc, WebComp_Headerbc_Component) != 0 )
            {
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            context.WriteHtmlText( "</div>") ;
            /* WebComponent */
            GxWebStd.gx_hidden_field( context, "W0003"+"", StringUtil.RTrim( WebComp_Recentlinks_Component));
            context.WriteHtmlText( "<div") ;
            context.WriteHtmlText( " id=\""+"gxHTMLWrpW0003"+""+"\""+"") ;
            context.WriteHtmlText( ">") ;
            if ( StringUtil.Len( WebComp_Recentlinks_Component) != 0 )
            {
               if ( StringUtil.StrCmp(OldRecentlinks, WebComp_Recentlinks_Component) != 0 )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0003"+"");
               }
               WebComp_Recentlinks.componentdraw();
               if ( StringUtil.StrCmp(OldRecentlinks, WebComp_Recentlinks_Component) != 0 )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
            context.WriteHtmlText( "</div>") ;
            wb_table1_4_042( true) ;
         }
         else
         {
            wb_table1_4_042( false) ;
         }
         return  ;
      }

      protected void wb_table1_4_042e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table2_13_042( true) ;
         }
         else
         {
            wb_table2_13_042( false) ;
         }
         return  ;
      }

      protected void wb_table2_13_042e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table3_16_042( true) ;
         }
         else
         {
            wb_table3_16_042( false) ;
         }
         return  ;
      }

      protected void wb_table3_16_042e( bool wbgen )
      {
         if ( wbgen )
         {
         }
         wbLoad = true ;
      }

      protected void START042( )
      {
         wbLoad = false ;
         wbEnd = 0 ;
         wbStart = 0 ;
         Form.Meta.addItem("Generator", "GeneXus C#", 0) ;
         Form.Meta.addItem("Version", "10_1_3-34981", 0) ;
         Form.Meta.addItem("Description", "Not Authorized web panel", 0) ;
         context.wjLoc = "" ;
         context.nUserReturn = 0 ;
         context.wbHandled = 0 ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            OldHeaderbc = cgiGet( "W0002") ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( WebComp_Headerbc_Component)) && ! String.IsNullOrEmpty(StringUtil.RTrim( OldHeaderbc)) )
            {
               WebComp_Headerbc = getWebComponent(GetType(), "GeneXus.Programs", OldHeaderbc, new Object[] {context} );
               WebComp_Headerbc.ComponentInit();
               WebComp_Headerbc.Name = "OldHeaderbc";
               WebComp_Headerbc_Component = OldHeaderbc ;
               WebComp_Headerbc.componentrestorestate("W0002", "");
            }
            OldRecentlinks = cgiGet( "W0003") ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( WebComp_Recentlinks_Component)) && ! String.IsNullOrEmpty(StringUtil.RTrim( OldRecentlinks)) )
            {
               WebComp_Recentlinks = getWebComponent(GetType(), "GeneXus.Programs", OldRecentlinks, new Object[] {context} );
               WebComp_Recentlinks.ComponentInit();
               WebComp_Recentlinks.Name = "OldRecentlinks";
               WebComp_Recentlinks_Component = OldRecentlinks ;
               WebComp_Recentlinks.componentrestorestate("W0003", "");
            }
         }
         wbErr = false ;
         STRUP040( ) ;
      }

      protected void WS042( )
      {
         START042( ) ;
         EVT042( ) ;
      }

      protected void EVT042( )
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1 ;
                              dynload_actions( ) ;
                              /* Execute user event: E11042 */
                              E11042 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1 ;
                              dynload_actions( ) ;
                              /* Execute user event: E12042 */
                              E12042 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1 ;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false ;
                                 if ( ! Rfr0gs )
                                 {
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4) ;
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4)) ;
                        nCmpId = (short)(NumberUtil.Val( sEvtType, ".")) ;
                        if ( nCmpId == 2 )
                        {
                           OldHeaderbc = cgiGet( "W0002") ;
                           if ( ( StringUtil.Len( OldHeaderbc) == 0 ) || ( StringUtil.StrCmp(OldHeaderbc, WebComp_Headerbc_Component) != 0 ) )
                           {
                              WebComp_Headerbc = getWebComponent(GetType(), "GeneXus.Programs", OldHeaderbc, new Object[] {context} );
                              WebComp_Headerbc.ComponentInit();
                              WebComp_Headerbc.Name = "OldHeaderbc";
                              WebComp_Headerbc_Component = OldHeaderbc ;
                           }
                           WebComp_Headerbc.componentprocess("W0002", "", sEvt);
                           WebComp_Headerbc_Component = OldHeaderbc ;
                        }
                        else if ( nCmpId == 3 )
                        {
                           OldRecentlinks = cgiGet( "W0003") ;
                           if ( ( StringUtil.Len( OldRecentlinks) == 0 ) || ( StringUtil.StrCmp(OldRecentlinks, WebComp_Recentlinks_Component) != 0 ) )
                           {
                              WebComp_Recentlinks = getWebComponent(GetType(), "GeneXus.Programs", OldRecentlinks, new Object[] {context} );
                              WebComp_Recentlinks.ComponentInit();
                              WebComp_Recentlinks.Name = "OldRecentlinks";
                              WebComp_Recentlinks_Component = OldRecentlinks ;
                           }
                           if ( StringUtil.Len( WebComp_Recentlinks_Component) != 0 )
                           {
                              WebComp_Recentlinks.componentprocess("W0003", "", sEvt);
                           }
                           WebComp_Recentlinks_Component = OldRecentlinks ;
                        }
                     }
                     context.wbHandled = 1 ;
                  }
               }
            }
         }
      }

      protected void WE042( )
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

      protected void PA042( )
      {
         if ( nDonePA == 0 )
         {
            nDonePA = 1 ;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void Refresh( )
      {
         RF042( ) ;
         /* End function Refresh */
      }

      protected void RF042( )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               WebComp_Headerbc.componentstart();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Recentlinks_Component) != 0 )
               {
                  WebComp_Recentlinks.componentstart();
               }
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: E12042 */
            E12042 ();
            WB040( ) ;
         }
      }

      protected void STRUP040( )
      {
         /* Before Start, stand alone formulas. */
         AV8Pgmname = "NotAuthorized" ;
         context.Gx_err = 0 ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0 ;
         /* Execute user event: E11042 */
         E11042 ();
         context.wbGlbDoneStart = 1 ;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read variables values. */
            /* Read saved values. */
            GxObject = cgiGet( "_GXOBJECT") ;
            OldHeaderbc = cgiGet( "W0002") ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( WebComp_Headerbc_Component)) && ! String.IsNullOrEmpty(StringUtil.RTrim( OldHeaderbc)) )
            {
               WebComp_Headerbc = getWebComponent(GetType(), "GeneXus.Programs", OldHeaderbc, new Object[] {context} );
               WebComp_Headerbc.ComponentInit();
               WebComp_Headerbc.Name = "OldHeaderbc";
               WebComp_Headerbc_Component = OldHeaderbc ;
               WebComp_Headerbc.componentrestorestate("W0002", "");
            }
            OldRecentlinks = cgiGet( "W0003") ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( WebComp_Recentlinks_Component)) && ! String.IsNullOrEmpty(StringUtil.RTrim( OldRecentlinks)) )
            {
               WebComp_Recentlinks = getWebComponent(GetType(), "GeneXus.Programs", OldRecentlinks, new Object[] {context} );
               WebComp_Recentlinks.ComponentInit();
               WebComp_Recentlinks.Name = "OldRecentlinks";
               WebComp_Recentlinks_Component = OldRecentlinks ;
               WebComp_Recentlinks.componentrestorestate("W0003", "");
            }
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
         /* Execute user event: E11042 */
         E11042 ();
         if (returnInSub) return;
      }

      protected void E11042( )
      {
         /* Start Routine */
         /* Object Property */
         if ( StringUtil.StrCmp(WebComp_Recentlinks_Component, "RecentLinks") != 0 )
         {
            WebComp_Recentlinks = getWebComponent(GetType(), "GeneXus.Programs", "recentlinks", new Object[] {context} );
            WebComp_Recentlinks.ComponentInit();
            WebComp_Recentlinks.Name = "RecentLinks";
            WebComp_Recentlinks_Component = "RecentLinks" ;
         }
         if ( StringUtil.StrCmp(OldRecentlinks, WebComp_Recentlinks_Component) != 0 )
         {
            WebComp_Recentlinks.setjustcreated();
         }
         if ( StringUtil.Len( WebComp_Recentlinks_Component) != 0 )
         {
            WebComp_Recentlinks.componentprepare(new Object[] {(String)"W0003",(String)"",(String)"Not Authorized",(String)AV8Pgmname});
            WebComp_Recentlinks.componentbind(new Object[] {(String)"",(String)""});
         }
         GX_msglist.addItem("You are not authorized to do this action");
      }

      protected void nextLoad( )
      {
      }

      protected void E12042( )
      {
         /* Load Routine */
      }

      protected void wb_table3_16_042( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTable3_Internalname, tblTable3_Internalname, "", "HorizontalLine", 0, "", "", 1, 2, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_16_042e( true) ;
         }
         else
         {
            wb_table3_16_042e( false) ;
         }
      }

      protected void wb_table2_13_042( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTable2_Internalname, tblTable2_Internalname, "", "HorizantalSpace", 0, "", "", 1, 2, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_13_042e( true) ;
         }
         else
         {
            wb_table2_13_042e( false) ;
         }
      }

      protected void wb_table1_4_042( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTable1_Internalname, tblTable1_Internalname, "", "ViewTable", 0, "", "", 1, 2, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td colspan=\"2\" >") ;
            /* Text block */
            ClassString = "SubTitle" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, 1, 1, 0, "Not Authorized", "", "", "", 0, lblTitletext_Jsonclick, "", StyleString, ClassString, "HLP_NotAuthorized.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td colspan=\"2\" >") ;
            ClassString = "ErrorViewer" ;
            StyleString = "" ;
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td colspan=\"2\" >") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_4_042e( true) ;
         }
         else
         {
            wb_table1_4_042e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         GxObject = (String)getParm(obj,0) ;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GxObject", GxObject);
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
         PA042( ) ;
         WS042( ) ;
         WE042( ) ;
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
         if ( ! ( WebComp_Headerbc == null ) )
         {
            WebComp_Headerbc.componentthemes();
         }
         if ( ! ( WebComp_Recentlinks == null ) )
         {
            if ( StringUtil.Len( WebComp_Recentlinks_Component) != 0 )
            {
               WebComp_Recentlinks.componentthemes();
            }
         }
         idxLst = 1 ;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( Form.Jscriptsrc.Item(idxLst)), "?3591973");
            idxLst = (int)(idxLst+1) ;
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?34981");
         context.AddJavascriptSource("notauthorized.js", "?3591973");
         /* End function include_jscripts */
      }

      public override void initialize_properties( )
      {
         lblTitletext_Internalname = "TITLETEXT" ;
         tblTable1_Internalname = "TABLE1" ;
         tblTable2_Internalname = "TABLE2" ;
         tblTable3_Internalname = "TABLE3" ;
         Form.Internalname = "FORM" ;
         Form.Headerrawhtml = "" ;
         Form.Background = "" ;
         Form.Backcolor = (int)(0xFFFFFF) ;
         Form.Caption = "Not Authorized web panel" ;
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
         wcpOGxObject = "" ;
         gxfirstwebparm = "" ;
         gxfirstwebparm_bkp = "" ;
         sDynURL = "" ;
         FormProcess = "" ;
         GXt_char1 = "" ;
         GX_FocusControl = "" ;
         Form = new GXWebForm();
         sPrefix = "" ;
         WebComp_Headerbc_Component = "" ;
         OldHeaderbc = "" ;
         WebComp_Recentlinks_Component = "" ;
         GXt_char2 = "" ;
         OldRecentlinks = "" ;
         GXt_char3 = "" ;
         sEvt = "" ;
         EvtGridId = "" ;
         EvtRowId = "" ;
         sEvtType = "" ;
         AV8Pgmname = "" ;
         sStyleString = "" ;
         ClassString = "" ;
         StyleString = "" ;
         lblTitletext_Jsonclick = "" ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         WebComp_Headerbc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Recentlinks = new GeneXus.Http.GXNullWebComponent();
         AV8Pgmname = "NotAuthorized" ;
         /* GeneXus formulas. */
         AV8Pgmname = "NotAuthorized" ;
         context.Gx_err = 0 ;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int idxLst ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String GXt_char1 ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String WebComp_Headerbc_Component ;
      private String OldHeaderbc ;
      private String WebComp_Recentlinks_Component ;
      private String GXt_char2 ;
      private String OldRecentlinks ;
      private String GXt_char3 ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String AV8Pgmname ;
      private String sStyleString ;
      private String tblTable3_Internalname ;
      private String tblTable2_Internalname ;
      private String tblTable1_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String lblTitletext_Internalname ;
      private String lblTitletext_Jsonclick ;
      private bool entryPointCalled ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool returnInSub ;
      private String GxObject ;
      private String wcpOGxObject ;
      private GXWebComponent WebComp_Headerbc ;
      private GXWebComponent WebComp_Recentlinks ;
      private GXMasterPage MasterPageObj ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

}
