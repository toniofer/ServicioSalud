/*
               File: RecentLinks
        Description: Recent Links web component
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/22/2010 3:59:17.56
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
   public class recentlinks : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public recentlinks( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public recentlinks( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default") ;
      }

      public void release( )
      {
      }

      public void execute( String aP0_FormCaption ,
                           String aP1_FormPgmName )
      {
         this.AV6FormCaption = aP0_FormCaption;
         this.AV7FormPgmName = aP1_FormPgmName;
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
                  AV6FormCaption = GetNextPar( ) ;
                  AV7FormPgmName = GetNextPar( ) ;
                  componentprepare(new Object[] {(String)sCompPrefix,(String)sSFPrefix,(String)AV6FormCaption,(String)AV7FormPgmName});
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Links") == 0 )
               {
                  nRC_Links = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  nGXsfl_7_idx = (short)(NumberUtil.Val( GetNextPar( ), ".")) ;
                  sGXsfl_7_idx = GetNextPar( ) ;
                  sPrefix = GetNextPar( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1 ;
                     return  ;
                  }
                  gxnrLinks_newrow( nRC_Links, nGXsfl_7_idx, sGXsfl_7_idx, sPrefix) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Links") == 0 )
               {
                  /* GeneXus formulas. */
                  context.Gx_err = 0 ;
                  AV6FormCaption = GetNextPar( ) ;
                  context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "AV6FormCaption", AV6FormCaption);
                  ajax_req_read_hidden_sdt(GetNextPar( ), (Object)(AV11RecentLinksItems));
                  sPrefix = GetNextPar( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1 ;
                     return  ;
                  }
                  gxgrLinks_refresh( AV6FormCaption, AV11RecentLinksItems, sPrefix) ;
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
            PA022( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0 ;
               WS022( ) ;
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
            context.WriteHtmlText( "Recent Links web component") ;
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            FormProcess = ((nGXWrapped==0) ? " onkeyup=\"gx.evt.onkeyup(event)\" onkeypress=\"gx.evt.onkeypress(event,false,false)\" onkeydown=\"gx.evt.onkeypress(null,false,false)\"" : "") ;
            context.WriteHtmlText( "<body") ;
            context.WriteHtmlText( " "+"class=\"Form\""+" "+" style=\"-moz-opacity:0;opacity:0;white-space: nowrap;"+"\""+" bgcolor=\""+context.BuildHTMLColor( (int)(0xFFFFFF))+"\""+FormProcess+">") ;
            context.skipLines(1);
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" onsubmit=\"try{return gx.csv.validForm()}catch(e){return true;}\" name=\"MAINFORM\" method=\"post\" action=\""+formatLink("recentlinks.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV6FormCaption)) + "," + UrlEncode(StringUtil.RTrim(AV7FormPgmName))+"\" class=\""+"Form"+"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            }
         }
      }

      protected void RenderHtmlCloseForm022( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_Links", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_Links), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6FormCaption", StringUtil.RTrim( wcpOAV6FormCaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7FormPgmName", StringUtil.RTrim( wcpOAV7FormPgmName));
         GxWebStd.gx_hidden_field( context, sPrefix+"_FORMCAPTION", StringUtil.RTrim( AV6FormCaption));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"_RECENTLINKSITEMS", (Object)(AV11RecentLinksItems));
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"_RECENTLINKSITEMS", (Object)(AV11RecentLinksItems));
         }
         if ( ( StringUtil.Len( sPrefix) != 0 ) && context.isAjaxRequest( ) )
         {
            context.AddJavascriptSource("recentlinks.js", "?3591768");
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

      protected void WB020( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "recentlinks.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            wb_table1_2_022( true) ;
         }
         else
         {
            wb_table1_2_022( false) ;
         }
         return  ;
      }

      protected void wb_table1_2_022e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table2_13_022( true) ;
         }
         else
         {
            wb_table2_13_022( false) ;
         }
         return  ;
      }

      protected void wb_table2_13_022e( bool wbgen )
      {
         if ( wbgen )
         {
         }
         wbLoad = true ;
      }

      protected void START022( )
      {
         wbLoad = false ;
         wbEnd = 0 ;
         wbStart = 0 ;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            Form.Meta.addItem("Generator", "GeneXus C#", 0) ;
            Form.Meta.addItem("Version", "10_1_3-34981", 0) ;
            Form.Meta.addItem("Description", "Recent Links web component", 0) ;
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
               STRUP020( ) ;
            }
         }
      }

      protected void WS022( )
      {
         START022( ) ;
         EVT022( ) ;
      }

      protected void EVT022( )
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
                                 STRUP020( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP020( ) ;
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
                           sEvtType = StringUtil.Right( sEvt, 4) ;
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4)) ;
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "LINKS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP020( ) ;
                              }
                              nGXsfl_7_idx = (short)(NumberUtil.Val( sEvtType, ".")) ;
                              sGXsfl_7_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_7_idx), 4, 0)), 4, "0") ;
                              lblPlace_Internalname = sPrefix+"PLACE_"+sGXsfl_7_idx ;
                              sEvtType = StringUtil.Right( sEvt, 1) ;
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1)) ;
                                 if ( StringUtil.StrCmp(sEvt, "LINKS.LOAD") == 0 )
                                 {
                                    if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1 ;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: E11022 */
                                          E11022 ();
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
                                       STRUP020( ) ;
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

      protected void WE022( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true ;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm022( ) ;
            }
         }
      }

      protected void PA022( )
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

      protected void gxnrLinks_newrow( short nRC_Links ,
                                       short nGXsfl_7_idx ,
                                       String sGXsfl_7_idx ,
                                       String sPrefix )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         lblPlace_Internalname = sPrefix+"PLACE_"+sGXsfl_7_idx ;
         while ( nGXsfl_7_idx <= nRC_Links )
         {
            sendrow_72( ) ;
            nGXsfl_7_idx = (short)(((subLinks_Islastpage==1)&&(nGXsfl_7_idx+1>subLinks_Recordsperpage( )) ? 1 : nGXsfl_7_idx+1)) ;
            sGXsfl_7_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_7_idx), 4, 0)), 4, "0") ;
            lblPlace_Internalname = sPrefix+"PLACE_"+sGXsfl_7_idx ;
         }
         context.GX_webresponse.AddString(LinksContainer.ToJavascriptSource());
         /* End function gxnrLinks_newrow */
      }

      protected void gxgrLinks_refresh( String AV6FormCaption ,
                                        IGxCollection AV11RecentLinksItems ,
                                        String sPrefix )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         disableOutput();
         RF022( ) ;
         enableOutput();
         context.GX_webresponse.AddString(LinksContainer.ToJavascriptSource());
         /* End function gxgrLinks_refresh */
      }

      protected void Refresh( )
      {
         RF022( ) ;
         /* End function Refresh */
      }

      protected void RF022( )
      {
         LinksContainer.PageSize = subLinks_Recordsperpage( ) ;
         wbStart = 7 ;
         nGXsfl_7_idx = 1 ;
         sGXsfl_7_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_7_idx), 4, 0)), 4, "0") ;
         lblPlace_Internalname = sPrefix+"PLACE_"+sGXsfl_7_idx ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: E11022 */
            E11022 ();
            wbEnd = 7 ;
            WB020( ) ;
         }
      }

      protected int subLinks_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subLinks_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subLinks_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subLinks_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void STRUP020( )
      {
         /* Before Start, stand alone formulas. */
         context.Gx_err = 0 ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0 ;
         context.wbGlbDoneStart = 1 ;
         nDoneStart = 1 ;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName") ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read variables values. */
            /* Read saved values. */
            nRC_Links = (short)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_Links"), ",", ".")) ;
            wcpOAV6FormCaption = cgiGet( sPrefix+"wcpOAV6FormCaption") ;
            wcpOAV7FormPgmName = cgiGet( sPrefix+"wcpOAV7FormPgmName") ;
            /* Read subfile selected row values. */
            /* Read hidden variables. */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      private void E11022( )
      {
         /* Links_Load Routine */
         AV11RecentLinksItems.FromXml(AV8Session.Get("RecentLinks"), "");
         AV9i = 1 ;
         while ( AV9i <= AV11RecentLinksItems.Count )
         {
            AV12RecentLinksItem = ((SdtLinkList_LinkItem)AV11RecentLinksItems.Item(AV9i)) ;
            if ( StringUtil.StrCmp(StringUtil.Trim( AV12RecentLinksItem.gxTpr_Caption), StringUtil.Trim( AV6FormCaption)) == 0 )
            {
               AV11RecentLinksItems.RemoveItem(AV9i);
            }
            else
            {
               AV9i = (int)(AV9i+1) ;
            }
         }
         while ( AV11RecentLinksItems.Count > 8 - 1 )
         {
            AV11RecentLinksItems.RemoveItem(1);
         }
         AV12RecentLinksItem = new SdtLinkList_LinkItem(context) ;
         AV12RecentLinksItem.gxTpr_Caption = StringUtil.Trim( AV6FormCaption) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12RecentLinksItem", (Object)(AV12RecentLinksItem));
         AV12RecentLinksItem.gxTpr_Url = AV10Request.ScriptName+"?"+AV10Request.QueryString ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12RecentLinksItem", (Object)(AV12RecentLinksItem));
         AV11RecentLinksItems.Add(AV12RecentLinksItem, 0);
         AV8Session.Set("RecentLinks", AV11RecentLinksItems.ToXml(false, "LinkList", "taller041"));
         AV9i = 1 ;
         while ( AV9i <= AV11RecentLinksItems.Count )
         {
            AV12RecentLinksItem = ((SdtLinkList_LinkItem)AV11RecentLinksItems.Item(AV9i)) ;
            lblPlace_Caption = AV12RecentLinksItem.gxTpr_Caption ;
            context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, lblPlace_Internalname, "Caption", lblPlace_Caption);
            if ( AV9i < AV11RecentLinksItems.Count )
            {
               lblPlace_Link = formatLink(AV12RecentLinksItem.gxTpr_Url)  ;
               context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, lblPlace_Internalname, "Link", lblPlace_Link);
            }
            else
            {
               lblPlace_Link = "" ;
               context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, lblPlace_Internalname, "Link", lblPlace_Link);
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 7 ;
            }
            sendrow_72( ) ;
            AV9i = (int)(AV9i+1) ;
         }
      }

      protected void wb_table2_13_022( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblBottomline_Internalname, tblBottomline_Internalname, "", "HorizontalLine", 0, "", "", 0, 0, sStyleString, "none", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_13_022e( true) ;
         }
         else
         {
            wb_table2_13_022e( false) ;
         }
      }

      protected void wb_table1_2_022( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTable_Internalname, tblTable_Internalname, "", "RecentLinksTable", 0, "", "", 0, 0, sStyleString, "none", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td style=\"width:1%\">") ;
            /* Text block */
            ClassString = "RecentLink" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblRecenttext_Internalname, 1, 1, 0, "Recents: ", "", "", "", 0, lblRecenttext_Jsonclick, "", StyleString, ClassString, "HLP_RecentLinks.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /*  Grid Control  */
            LinksContainer.SetIsFreestyle(true);
            LinksContainer.SetWrapped(nGXWrapped);
            if ( LinksContainer.GetWrapped() == 1 )
            {
               sStyleString = "" ;
               GxWebStd.gx_table_start( context, subLinks_Internalname, subLinks_Internalname, "", "RecentLinksTable", 0, "", "", 1, 2, sStyleString, "", 0);
            }
            else
            {
               LinksContainer.AddObjectProperty("GridName", "Links");
               LinksContainer.AddObjectProperty("Class", StringUtil.RTrim( "RecentLinksTable"));
               LinksContainer.AddObjectProperty("Class", "RecentLinksTable");
               LinksContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               LinksContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               LinksContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subLinks_Backcolorstyle), 1, 0, ".", "")));
               LinksContainer.AddObjectProperty("CmpContext", sPrefix);
               LinksContainer.AddObjectProperty("InMasterPage", "false");
               LinksColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               LinksContainer.AddColumnProperties(LinksColumn);
               LinksColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               LinksContainer.AddColumnProperties(LinksColumn);
               LinksColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               LinksColumn.AddObjectProperty("Value", lblPlace_Caption);
               LinksContainer.AddColumnProperties(LinksColumn);
               LinksColumn = GXWebColumn.GetNew(isAjaxCallMode( )) ;
               LinksContainer.AddColumnProperties(LinksColumn);
               LinksContainer.AddObjectProperty("Allowselection", "true");
               LinksContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subLinks_Selectioncolor), 9, 0, ".", "")));
               LinksContainer.AddObjectProperty("Allowhover", "true");
               LinksContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subLinks_Hoveringcolor), 9, 0, ".", "")));
               LinksContainer.AddObjectProperty("Allowcollapsing", "false");
               LinksContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subLinks_Collapsed), 9, 0, ".", "")));
            }
         }
         if ( wbEnd == 7 )
         {
            wbEnd = 0 ;
            nRC_Links = (short)(nGXsfl_7_idx-1) ;
            if ( LinksContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
            }
            else
            {
               sStyleString = " style=\"display:none;\"" ;
               sStyleString = "" ;
               context.WriteHtmlText( "<div id=\""+sPrefix+"LinksContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Links", (Object)(LinksContainer));
               GxWebStd.gx_hidden_field( context, sPrefix+"LinksContainerData", LinksContainer.ToJavascriptSource());
               if ( context.isAjaxRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"LinksContainerData"+"V", LinksContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"LinksContainerData"+"V"+"\" value='"+LinksContainer.GridValuesHidden()+"'>") ;
               }
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class=\"td100\" >") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_2_022e( true) ;
         }
         else
         {
            wb_table1_2_022e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6FormCaption = (String)getParm(obj,0) ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "AV6FormCaption", AV6FormCaption);
         AV7FormPgmName = (String)getParm(obj,1) ;
         context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "AV7FormPgmName", AV7FormPgmName);
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
         PA022( ) ;
         WS022( ) ;
         WE022( ) ;
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
         sCtrlAV6FormCaption = (String)((String)getParm(obj,0)) ;
         sCtrlAV7FormPgmName = (String)((String)getParm(obj,1)) ;
      }

      public override void componentrestorestate( String sPPrefix ,
                                                  String sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix ;
         PA022( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false ;
         sCompPrefix = (String)getParm(obj,0) ;
         sSFPrefix = (String)getParm(obj,1) ;
         sPrefix = sCompPrefix + sSFPrefix ;
         AddComponentObject(sPrefix, "recentlinks");
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         PA022( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6FormCaption = (String)getParm(obj,2) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "AV6FormCaption", AV6FormCaption);
            AV7FormPgmName = (String)getParm(obj,3) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "AV7FormPgmName", AV7FormPgmName);
         }
         wcpOAV6FormCaption = cgiGet( sPrefix+"wcpOAV6FormCaption") ;
         wcpOAV7FormPgmName = cgiGet( sPrefix+"wcpOAV7FormPgmName") ;
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV6FormCaption, wcpOAV6FormCaption) != 0 ) || ( StringUtil.StrCmp(AV7FormPgmName, wcpOAV7FormPgmName) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV6FormCaption = AV6FormCaption ;
         wcpOAV7FormPgmName = AV7FormPgmName ;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6FormCaption = cgiGet( sPrefix+"AV6FormCaption_CTRL") ;
         if ( StringUtil.Len( sCtrlAV6FormCaption) > 0 )
         {
            AV6FormCaption = cgiGet( sCtrlAV6FormCaption) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "AV6FormCaption", AV6FormCaption);
         }
         else
         {
            AV6FormCaption = cgiGet( sPrefix+"AV6FormCaption_PARM") ;
         }
         sCtrlAV7FormPgmName = cgiGet( sPrefix+"AV7FormPgmName_CTRL") ;
         if ( StringUtil.Len( sCtrlAV7FormPgmName) > 0 )
         {
            AV7FormPgmName = cgiGet( sCtrlAV7FormPgmName) ;
            context.httpAjaxContext.ajax_rsp_assign_attri(sPrefix, false, "AV7FormPgmName", AV7FormPgmName);
         }
         else
         {
            AV7FormPgmName = cgiGet( sPrefix+"AV7FormPgmName_PARM") ;
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
         PA022( ) ;
         sEvt = sCompEvt ;
         WCParametersGet( ) ;
         WS022( ) ;
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
         WS022( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst ;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6FormCaption_PARM", StringUtil.RTrim( AV6FormCaption));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6FormCaption)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6FormCaption_CTRL", StringUtil.RTrim( sCtrlAV6FormCaption));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7FormPgmName_PARM", StringUtil.RTrim( AV7FormPgmName));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7FormPgmName)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7FormPgmName_CTRL", StringUtil.RTrim( sCtrlAV7FormPgmName));
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
         WE022( ) ;
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
         AddThemeStyleSheetFile("", "GeneXusX.css", "?2313925");
         idxLst = 1 ;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( Form.Jscriptsrc.Item(idxLst)), "?359183");
            idxLst = (int)(idxLst+1) ;
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("recentlinks.js", "?359183");
         }
         /* End function include_jscripts */
      }

      protected void sendrow_72( )
      {
         WB020( ) ;
         LinksRow = GXWebRow.GetNew(context,LinksContainer) ;
         if ( subLinks_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subLinks_Backstyle = 0 ;
            if ( StringUtil.StrCmp(subLinks_Class, "") != 0 )
            {
               subLinks_Linesclass = subLinks_Class+"Odd" ;
            }
         }
         else if ( subLinks_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subLinks_Backstyle = 0 ;
            subLinks_Backcolor = subLinks_Allbackcolor ;
            context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, sPrefix+"LinksContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subLinks_Backcolor), 9, 0)));
            if ( StringUtil.StrCmp(subLinks_Class, "") != 0 )
            {
               subLinks_Linesclass = subLinks_Class+"Uniform" ;
            }
         }
         else if ( subLinks_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subLinks_Backstyle = 1 ;
            if ( StringUtil.StrCmp(subLinks_Class, "") != 0 )
            {
               subLinks_Linesclass = subLinks_Class+"Odd" ;
            }
            subLinks_Backcolor = (int)(0xFFFFFF) ;
            context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, sPrefix+"LinksContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subLinks_Backcolor), 9, 0)));
         }
         else if ( subLinks_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subLinks_Backstyle = 1 ;
            if ( ((int)(nGXsfl_7_idx/ (decimal)(0)) % (2)) == 0 )
            {
               subLinks_Backcolor = (int)(0x0) ;
               context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, sPrefix+"LinksContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subLinks_Backcolor), 9, 0)));
               if ( StringUtil.StrCmp(subLinks_Class, "") != 0 )
               {
                  subLinks_Linesclass = subLinks_Class+"Even" ;
               }
            }
            else
            {
               subLinks_Backcolor = (int)(0xFFFFFF) ;
               context.httpAjaxContext.ajax_rsp_assign_prop(sPrefix, false, sPrefix+"LinksContainerDiv", "Backcolor", StringUtil.LTrim( StringUtil.Str( (decimal)(subLinks_Backcolor), 9, 0)));
               if ( StringUtil.StrCmp(subLinks_Class, "") != 0 )
               {
                  subLinks_Linesclass = subLinks_Class+"Odd" ;
               }
            }
         }
         /* Start of Columns property logic. */
         LinksRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)subLinks_Linesclass,(String)""});
         LinksRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)""});
         /* Text block */
         ClassString = "RecentLink" ;
         StyleString = "" ;
         LinksRow.AddColumnProperties("label", 4, isAjaxCallMode( ), new Object[] {(String)lblPlace_Internalname,(short)1,(short)1,(short)0,(String)lblPlace_Caption,(String)"",(String)lblPlace_Link,(String)"",(short)0,(String)lblPlace_Jsonclick,(String)"",(String)StyleString,(String)ClassString});
         if ( LinksContainer.GetWrapped() == 1 )
         {
            LinksContainer.CloseTag("cell");
         }
         LinksRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)""});
         if ( LinksContainer.GetWrapped() == 1 )
         {
            LinksContainer.CloseTag("cell");
         }
         if ( LinksContainer.GetWrapped() == 1 )
         {
            LinksContainer.CloseTag("row");
         }
         /* End of Columns property logic. */
         LinksContainer.AddRow(LinksRow);
         nGXsfl_7_idx = (short)(((subLinks_Islastpage==1)&&(nGXsfl_7_idx+1>subLinks_Recordsperpage( )) ? 1 : nGXsfl_7_idx+1)) ;
         sGXsfl_7_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_7_idx), 4, 0)), 4, "0") ;
         lblPlace_Internalname = sPrefix+"PLACE_"+sGXsfl_7_idx ;
         /* End function sendrow_72 */
      }

      protected void initialize_properties( )
      {
         lblRecenttext_Internalname = sPrefix+"RECENTTEXT" ;
         tblTable_Internalname = sPrefix+"TABLE" ;
         tblBottomline_Internalname = sPrefix+"BOTTOMLINE" ;
         Form.Internalname = sPrefix+"FORM" ;
         subLinks_Internalname = sPrefix+"LINKS" ;
         lblPlace_Jsonclick = "" ;
         subLinks_Class = "RecentLinksTable" ;
         subLinks_Backcolorstyle = 0 ;
         lblPlace_Link = "" ;
         lblPlace_Caption = "Place" ;
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
         wcpOAV6FormCaption = "" ;
         wcpOAV7FormPgmName = "" ;
         gxfirstwebparm = "" ;
         gxfirstwebparm_bkp = "" ;
         sPrefix = "" ;
         AV11RecentLinksItems = new GxObjectCollection( context, "LinkList.LinkItem", "taller041", "SdtLinkList_LinkItem", "GeneXus.Programs");
         sDynURL = "" ;
         FormProcess = "" ;
         GXt_char1 = "" ;
         GXt_char2 = "" ;
         GX_FocusControl = "" ;
         Form = new GXWebForm();
         sXEvt = "" ;
         sEvt = "" ;
         EvtGridId = "" ;
         EvtRowId = "" ;
         sEvtType = "" ;
         lblPlace_Internalname = "" ;
         LinksContainer = new GXWebGrid( context);
         AV8Session = new GxWebSession( context);
         AV12RecentLinksItem = new SdtLinkList_LinkItem(context);
         AV10Request = new GxHttpRequest( context);
         sStyleString = "" ;
         ClassString = "" ;
         StyleString = "" ;
         lblRecenttext_Jsonclick = "" ;
         LinksColumn = new GXWebColumn();
         GXt_char3 = "" ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6FormCaption = "" ;
         sCtrlAV7FormPgmName = "" ;
         GXt_char4 = "" ;
         LinksRow = new GXWebRow();
         subLinks_Linesclass = "" ;
         GXt_char5 = "" ;
         /* GeneXus formulas. */
         context.Gx_err = 0 ;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short nRC_Links ;
      private short nGXsfl_7_idx=1 ;
      private short initialized ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subLinks_Backcolorstyle ;
      private short subLinks_Collapsed ;
      private short subLinks_Backstyle ;
      private int subLinks_Islastpage ;
      private int AV9i ;
      private int subLinks_Selectioncolor ;
      private int subLinks_Hoveringcolor ;
      private int idxLst ;
      private int subLinks_Backcolor ;
      private int subLinks_Allbackcolor ;
      private String AV6FormCaption ;
      private String wcpOAV6FormCaption ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sPrefix ;
      private String sCompPrefix ;
      private String sSFPrefix ;
      private String sGXsfl_7_idx="0001" ;
      private String sDynURL ;
      private String FormProcess ;
      private String GXt_char1 ;
      private String GXt_char2 ;
      private String GX_FocusControl ;
      private String sXEvt ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String lblPlace_Internalname ;
      private String lblPlace_Caption ;
      private String lblPlace_Link ;
      private String sStyleString ;
      private String tblBottomline_Internalname ;
      private String tblTable_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String lblRecenttext_Internalname ;
      private String lblRecenttext_Jsonclick ;
      private String subLinks_Internalname ;
      private String GXt_char3 ;
      private String sCtrlAV6FormCaption ;
      private String sCtrlAV7FormPgmName ;
      private String GXt_char4 ;
      private String subLinks_Class ;
      private String subLinks_Linesclass ;
      private String lblPlace_Jsonclick ;
      private String GXt_char5 ;
      private bool entryPointCalled ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private String AV7FormPgmName ;
      private String wcpOAV7FormPgmName ;
      private GxWebSession AV8Session ;
      private GXWebGrid LinksContainer ;
      private GXWebRow LinksRow ;
      private GXWebColumn LinksColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10Request ;
      private IGxCollection AV11RecentLinksItems ;
      private SdtLinkList_LinkItem AV12RecentLinksItem ;
   }

}
