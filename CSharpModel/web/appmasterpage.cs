/*
               File: AppMasterPage
        Description: Application Master Page
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/22/2010 3:59:18.46
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
   public class appmasterpage : GXMasterPage, System.Web.SessionState.IRequiresSessionState
   {
      public appmasterpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public appmasterpage( IGxContext context )
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
            PA012( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0 ;
               WS012( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE012( ) ;
               }
            }
         }
         this.cleanup();
      }

      protected void RenderHtmlHeaders( )
      {
         getDataAreaObject().RenderHtmlHeaders();
      }

      protected void RenderHtmlOpenForm( )
      {
         getDataAreaObject().RenderHtmlOpenForm();
      }

      protected void RenderHtmlCloseForm012( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         getDataAreaObject().RenderHtmlCloseForm();
         if ( ! ( WebComp_Wcrecentlinks == null ) )
         {
            WebComp_Wcrecentlinks.componentjscripts();
         }
         context.AddJavascriptSource("appmasterpage.js", "?3591850");
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
      }

      protected void WB010( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            if ( ! ShowMPWhenPopUp( ) && context.isPopUpObject( ) )
            {
               getDataAreaObject().RenderHtmlContent();
               return  ;
            }
            wb_table1_2_012( true) ;
         }
         else
         {
            wb_table1_2_012( false) ;
         }
         return  ;
      }

      protected void wb_table1_2_012e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "<p/>") ;
         }
         wbLoad = true ;
      }

      protected void START012( )
      {
         wbLoad = false ;
         wbEnd = 0 ;
         wbStart = 0 ;
         context.wjLoc = "" ;
         context.nUserReturn = 0 ;
         context.wbHandled = 0 ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            OldWcrecentlinks = cgiGet( "MPW0034") ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( WebComp_Wcrecentlinks_Component)) && ! String.IsNullOrEmpty(StringUtil.RTrim( OldWcrecentlinks)) )
            {
               WebComp_Wcrecentlinks = getWebComponent(GetType(), "GeneXus.Programs", OldWcrecentlinks, new Object[] {context} );
               WebComp_Wcrecentlinks.ComponentInit();
               WebComp_Wcrecentlinks.Name = "OldWcrecentlinks";
               WebComp_Wcrecentlinks_Component = OldWcrecentlinks ;
               WebComp_Wcrecentlinks.componentrestorestate("MPW0034", "");
            }
         }
         wbErr = false ;
         STRUP010( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
         {
            if ( getDataAreaObject().ExecuteStartEvent() != 0 )
            {
               setAjaxCallMode();
            }
         }
      }

      protected void WS012( )
      {
         START012( ) ;
         EVT012( ) ;
      }

      protected void EVT012( )
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
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1) ;
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1)) ;
                        if ( StringUtil.StrCmp(sEvt, "RFR_MPAGE") == 0 )
                        {
                           context.wbHandled = 1 ;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START_MPAGE") == 0 )
                        {
                           context.wbHandled = 1 ;
                           dynload_actions( ) ;
                           /* Execute user event: E11012 */
                           E11012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "REFRESH_MPAGE") == 0 )
                        {
                           context.wbHandled = 1 ;
                           dynload_actions( ) ;
                           /* Execute user event: E12012 */
                           E12012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD_MPAGE") == 0 )
                        {
                           context.wbHandled = 1 ;
                           dynload_actions( ) ;
                           /* Execute user event: E13012 */
                           E13012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER_MPAGE") == 0 )
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
                  else if ( StringUtil.StrCmp(sEvtType, "M") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-2)) ;
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-6)) ;
                     nCmpId = (short)(NumberUtil.Val( sEvtType, ".")) ;
                     if ( nCmpId == 34 )
                     {
                        OldWcrecentlinks = cgiGet( "MPW0034") ;
                        if ( ( StringUtil.Len( OldWcrecentlinks) == 0 ) || ( StringUtil.StrCmp(OldWcrecentlinks, WebComp_Wcrecentlinks_Component) != 0 ) )
                        {
                           WebComp_Wcrecentlinks = getWebComponent(GetType(), "GeneXus.Programs", OldWcrecentlinks, new Object[] {context} );
                           WebComp_Wcrecentlinks.ComponentInit();
                           WebComp_Wcrecentlinks.Name = "OldWcrecentlinks";
                           WebComp_Wcrecentlinks_Component = OldWcrecentlinks ;
                        }
                        if ( StringUtil.Len( WebComp_Wcrecentlinks_Component) != 0 )
                        {
                           WebComp_Wcrecentlinks.componentprocess("MPW0034", "", sEvt);
                        }
                        WebComp_Wcrecentlinks_Component = OldWcrecentlinks ;
                     }
                  }
                  if ( context.wbHandled == 0 )
                  {
                     getDataAreaObject().DispatchEvents();
                  }
                  context.wbHandled = 1 ;
               }
            }
         }
      }

      protected void WE012( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true ;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm012( ) ;
            }
         }
      }

      protected void PA012( )
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
         RF012( ) ;
         /* End function Refresh */
      }

      protected void RF012( )
      {
         /* Execute user event: E12012 */
         E12012 ();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcrecentlinks_Component) != 0 )
               {
                  WebComp_Wcrecentlinks.componentstart();
               }
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: E13012 */
            E13012 ();
            WB010( ) ;
         }
      }

      protected void STRUP010( )
      {
         /* Before Start, stand alone formulas. */
         context.Gx_err = 0 ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0 ;
         /* Execute user event: E11012 */
         E11012 ();
         context.wbGlbDoneStart = 1 ;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read variables values. */
            /* Read saved values. */
            OldWcrecentlinks = cgiGet( "MPW0034") ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( WebComp_Wcrecentlinks_Component)) && ! String.IsNullOrEmpty(StringUtil.RTrim( OldWcrecentlinks)) )
            {
               WebComp_Wcrecentlinks = getWebComponent(GetType(), "GeneXus.Programs", OldWcrecentlinks, new Object[] {context} );
               WebComp_Wcrecentlinks.ComponentInit();
               WebComp_Wcrecentlinks.Name = "OldWcrecentlinks";
               WebComp_Wcrecentlinks_Component = OldWcrecentlinks ;
               WebComp_Wcrecentlinks.componentrestorestate("MPW0034", "");
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
         /* Execute user event: E11012 */
         E11012 ();
         if (returnInSub) return;
      }

      protected void E11012( )
      {
         /* Start Routine */
         tblTable2_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", true, tblTable2_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(tblTable2_Visible), 5, 0)));
         lblHome_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", true, lblHome_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(lblHome_Visible), 5, 0)));
         lblFirsttext_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", true, lblFirsttext_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(lblFirsttext_Visible), 5, 0)));
         lblSecondtext_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", true, lblSecondtext_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(lblSecondtext_Visible), 5, 0)));
         lblThirdtext_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", true, lblThirdtext_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(lblThirdtext_Visible), 5, 0)));
         lblFourthtext_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", true, lblFourthtext_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(lblFourthtext_Visible), 5, 0)));
         lblFifthtext_Visible = 0 ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", true, lblFifthtext_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(lblFifthtext_Visible), 5, 0)));
      }

      protected void E12012( )
      {
         /* Refresh Routine */
         /* Object Property */
         if ( StringUtil.StrCmp(WebComp_Wcrecentlinks_Component, "RecentLinks") != 0 )
         {
            WebComp_Wcrecentlinks = getWebComponent(GetType(), "GeneXus.Programs", "recentlinks", new Object[] {context} );
            WebComp_Wcrecentlinks.ComponentInit();
            WebComp_Wcrecentlinks.Name = "RecentLinks";
            WebComp_Wcrecentlinks_Component = "RecentLinks" ;
         }
         if ( StringUtil.StrCmp(OldWcrecentlinks, WebComp_Wcrecentlinks_Component) != 0 )
         {
            WebComp_Wcrecentlinks.setjustcreated();
         }
         if ( StringUtil.Len( WebComp_Wcrecentlinks_Component) != 0 )
         {
            WebComp_Wcrecentlinks.componentprepare(new Object[] {(String)"MPW0034",(String)"",getDataAreaObject().GetForm().Caption,Contentholder.Pgmname});
            WebComp_Wcrecentlinks.componentbind(new Object[] {(String)"",(String)""});
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E13012( )
      {
         /* Load Routine */
      }

      protected void wb_table1_2_012( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTable4_Internalname, tblTable4_Internalname, "", "Table95", 0, "", "", 0, 0, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td colspan=\"3\" >") ;
            wb_table2_5_012( true) ;
         }
         else
         {
            wb_table2_5_012( false) ;
         }
         return  ;
      }

      protected void wb_table2_5_012e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table3_18_012( true) ;
         }
         else
         {
            wb_table3_18_012( false) ;
         }
         return  ;
      }

      protected void wb_table3_18_012e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td colspan=\"3\" >") ;
            /* WebComponent */
            GxWebStd.gx_hidden_field( context, "MPW0034"+"", StringUtil.RTrim( WebComp_Wcrecentlinks_Component));
            context.WriteHtmlText( "<div") ;
            context.WriteHtmlText( " id=\""+"gxHTMLWrpMPW0034"+""+"\""+"") ;
            context.WriteHtmlText( ">") ;
            if ( StringUtil.Len( WebComp_Wcrecentlinks_Component) != 0 )
            {
               if ( StringUtil.StrCmp(OldWcrecentlinks, WebComp_Wcrecentlinks_Component) != 0 )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0034"+"");
               }
               WebComp_Wcrecentlinks.componentdraw();
               if ( StringUtil.StrCmp(OldWcrecentlinks, WebComp_Wcrecentlinks_Component) != 0 )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td style=\"width:0px\">") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td style=\"width:100%\">") ;
            wb_table4_38_012( true) ;
         }
         else
         {
            wb_table4_38_012( false) ;
         }
         return  ;
      }

      protected void wb_table4_38_012e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td style=\"width:0px\">") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td colspan=\"3\" >") ;
            wb_table5_45_012( true) ;
         }
         else
         {
            wb_table5_45_012( false) ;
         }
         return  ;
      }

      protected void wb_table5_45_012e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table6_48_012( true) ;
         }
         else
         {
            wb_table6_48_012( false) ;
         }
         return  ;
      }

      protected void wb_table6_48_012e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table7_51_012( true) ;
         }
         else
         {
            wb_table7_51_012( false) ;
         }
         return  ;
      }

      protected void wb_table7_51_012e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table8_54_012( true) ;
         }
         else
         {
            wb_table8_54_012( false) ;
         }
         return  ;
      }

      protected void wb_table8_54_012e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table9_58_012( true) ;
         }
         else
         {
            wb_table9_58_012( false) ;
         }
         return  ;
      }

      protected void wb_table9_58_012e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table10_61_012( true) ;
         }
         else
         {
            wb_table10_61_012( false) ;
         }
         return  ;
      }

      protected void wb_table10_61_012e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_2_012e( true) ;
         }
         else
         {
            wb_table1_2_012e( false) ;
         }
      }

      protected void wb_table10_61_012( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTable10_Internalname, tblTable10_Internalname, "", "HorizontalLine", 0, "", "", 0, 0, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table10_61_012e( true) ;
         }
         else
         {
            wb_table10_61_012e( false) ;
         }
      }

      protected void wb_table9_58_012( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTable9_Internalname, tblTable9_Internalname, "", "HorizontalSpace", 0, "", "", 0, 0, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table9_58_012e( true) ;
         }
         else
         {
            wb_table9_58_012e( false) ;
         }
      }

      protected void wb_table8_54_012( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTable3_Internalname, tblTable3_Internalname, "", "TableBottom", 0, "", "", 1, 2, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr align=\"left\" >") ;
            context.WriteHtmlText( "<td style=\"text-align:"+context.GetCssProperty( "Align", "center")+"\">") ;
            /* Text block */
            ClassString = "SmallText" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, 1, 1, 0, "Footer Info", "", "", "", 0, lblTextblock1_Jsonclick, "E_MPAGE.", StyleString, ClassString, "HLP_AppMasterPage.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table8_54_012e( true) ;
         }
         else
         {
            wb_table8_54_012e( false) ;
         }
      }

      protected void wb_table7_51_012( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTable8_Internalname, tblTable8_Internalname, "", "HorizontalSpace", 0, "", "", 0, 0, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table7_51_012e( true) ;
         }
         else
         {
            wb_table7_51_012e( false) ;
         }
      }

      protected void wb_table6_48_012( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTable7_Internalname, tblTable7_Internalname, "", "HorizontalLine", 0, "", "", 0, 0, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_48_012e( true) ;
         }
         else
         {
            wb_table6_48_012e( false) ;
         }
      }

      protected void wb_table5_45_012( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTable6_Internalname, tblTable6_Internalname, "", "HorizontalSpace", 0, "", "", 1, 2, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_45_012e( true) ;
         }
         else
         {
            wb_table5_45_012e( false) ;
         }
      }

      protected void wb_table4_38_012( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTable5_Internalname, tblTable5_Internalname, "", "ViewTable", 0, "", "", 1, 2, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            getDataAreaObject().RenderHtmlContent();
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_38_012e( true) ;
         }
         else
         {
            wb_table4_38_012e( false) ;
         }
      }

      protected void wb_table3_18_012( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            if ( tblTable2_Visible == 0 )
            {
               sStyleString = sStyleString + "display:none;" ;
            }
            sStyleString = sStyleString + " width: " + StringUtil.LTrim( StringUtil.Str( (decimal)(100), 10, 0)) + "%" + ";" ;
            GxWebStd.gx_table_start( context, tblTable2_Internalname, tblTable2_Internalname, "", "TableTopMenu", 0, "", "", 1, 2, sStyleString, "none", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblHome_Internalname, lblHome_Visible, 1, 0, "Home", "", "", "", 0, lblHome_Jsonclick, "E_MPAGE.", StyleString, ClassString, "HLP_AppMasterPage.htm");
            context.WriteHtmlText( "&nbsp; ") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblFirsttext_Internalname, lblFirsttext_Visible, 1, 0, "First Option", "", "", "", 0, lblFirsttext_Jsonclick, "E_MPAGE.", StyleString, ClassString, "HLP_AppMasterPage.htm");
            context.WriteHtmlText( "&nbsp; ") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblSecondtext_Internalname, lblSecondtext_Visible, 1, 0, "Second Option", "", "", "", 0, lblSecondtext_Jsonclick, "E_MPAGE.", StyleString, ClassString, "HLP_AppMasterPage.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblThirdtext_Internalname, lblThirdtext_Visible, 1, 0, "Third Option", "", "", "", 0, lblThirdtext_Jsonclick, "E_MPAGE.", StyleString, ClassString, "HLP_AppMasterPage.htm");
            context.WriteHtmlText( "&nbsp; ") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblFourthtext_Internalname, lblFourthtext_Visible, 1, 0, "Fourth Option", "", "", "", 0, lblFourthtext_Jsonclick, "E_MPAGE.", StyleString, ClassString, "HLP_AppMasterPage.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            ClassString = "TextBlock" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblFifthtext_Internalname, lblFifthtext_Visible, 1, 0, "Last One", "", "", "", 0, lblFifthtext_Jsonclick, "E_MPAGE.", StyleString, ClassString, "HLP_AppMasterPage.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_18_012e( true) ;
         }
         else
         {
            wb_table3_18_012e( false) ;
         }
      }

      protected void wb_table2_5_012( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "" ;
            GxWebStd.gx_table_start( context, tblTable1_Internalname, tblTable1_Internalname, "", "TableTop", 0, "", "", 0, 0, sStyleString, "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class=\"td10px\" >") ;
            /* Static images/pictures */
            ClassString = "ImageTopHeader" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_topl_Internalname, "", context.GetImagePath( "caf107ad-650e-4e3c-a4ba-1196d220603b", "", "GeneXusX"), "GeneXusX", 1, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 0, "", "", StyleString, ClassString, "", "", "", "", "HLP_AppMasterPage.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class=\"td10px\" >") ;
            /* Static images/pictures */
            ClassString = "ImageTopHeader" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgBtn_topr_Internalname, "", context.GetImagePath( "c7e6c81f-bebf-4d28-b5cd-decdcb627b0a", "", "GeneXusX"), "GeneXusX", 1, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 0, "", "", StyleString, ClassString, "", "", "", "", "HLP_AppMasterPage.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "&nbsp; ") ;
            /* Text block */
            ClassString = "TextBlockHeader" ;
            StyleString = "" ;
            GxWebStd.gx_label_ctrl( context, lblTextblockheader1_Internalname, 1, 1, 0, "Application Header", "", "", "", 0, lblTextblockheader1_Jsonclick, "E_MPAGE.", StyleString, ClassString, "HLP_AppMasterPage.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td style=\"text-align:"+context.GetCssProperty( "Align", "right")+"\">") ;
            /* Static images/pictures */
            ClassString = "HeaderImage1" ;
            StyleString = "" ;
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, "", context.GetImagePath( "7326b96a-20b7-4973-8d71-35094049767d", "", "GeneXusX"), "GeneXusX", 1, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, "", "", 0, "", "", StyleString, ClassString, "", "", "", "", "HLP_AppMasterPage.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_5_012e( true) ;
         }
         else
         {
            wb_table2_5_012e( false) ;
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
         PA012( ) ;
         WS012( ) ;
         WE012( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst ;
         return "";
      }

      public void responsestatic( String sGXDynURL )
      {
      }

      public override void master_styles( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", "GeneXusX.css", "?2313925");
         if ( ! ( WebComp_Wcrecentlinks == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcrecentlinks_Component) != 0 )
            {
               WebComp_Wcrecentlinks.componentthemes();
            }
         }
         idxLst = 1 ;
         while ( idxLst <= getDataAreaObject().GetForm().Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( getDataAreaObject().GetForm().Jscriptsrc.Item(idxLst)), "?3591920");
            idxLst = (int)(idxLst+1) ;
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("appmasterpage.js", "?3591920");
         /* End function include_jscripts */
      }

      protected void initialize_properties( )
      {
         imgBtn_topl_Internalname = "BTN_TOPL_MPAGE" ;
         imgBtn_topr_Internalname = "BTN_TOPR_MPAGE" ;
         lblTextblockheader1_Internalname = "TEXTBLOCKHEADER1_MPAGE" ;
         imgImage1_Internalname = "IMAGE1_MPAGE" ;
         tblTable1_Internalname = "TABLE1_MPAGE" ;
         lblHome_Internalname = "HOME_MPAGE" ;
         lblFirsttext_Internalname = "FIRSTTEXT_MPAGE" ;
         lblSecondtext_Internalname = "SECONDTEXT_MPAGE" ;
         lblThirdtext_Internalname = "THIRDTEXT_MPAGE" ;
         lblFourthtext_Internalname = "FOURTHTEXT_MPAGE" ;
         lblFifthtext_Internalname = "FIFTHTEXT_MPAGE" ;
         tblTable2_Internalname = "TABLE2_MPAGE" ;
         tblTable5_Internalname = "TABLE5_MPAGE" ;
         tblTable6_Internalname = "TABLE6_MPAGE" ;
         tblTable7_Internalname = "TABLE7_MPAGE" ;
         tblTable8_Internalname = "TABLE8_MPAGE" ;
         lblTextblock1_Internalname = "TEXTBLOCK1_MPAGE" ;
         tblTable3_Internalname = "TABLE3_MPAGE" ;
         tblTable9_Internalname = "TABLE9_MPAGE" ;
         tblTable10_Internalname = "TABLE10_MPAGE" ;
         tblTable4_Internalname = "TABLE4_MPAGE" ;
         getDataAreaObject().GetForm().Internalname = "FORM_MPAGE" ;
         lblFifthtext_Visible = 1 ;
         lblFourthtext_Visible = 1 ;
         lblThirdtext_Visible = 1 ;
         lblSecondtext_Visible = 1 ;
         lblFirsttext_Visible = 1 ;
         lblHome_Jsonclick = "" ;
         lblHome_Visible = 1 ;
         tblTable2_Visible = 1 ;
         Contentholder.setDataArea(getDataAreaObject());
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
         Contentholder = new GXDataAreaControl();
         sPrefix = "" ;
         OldWcrecentlinks = "" ;
         WebComp_Wcrecentlinks_Component = "" ;
         sEvt = "" ;
         EvtGridId = "" ;
         EvtRowId = "" ;
         sEvtType = "" ;
         sStyleString = "" ;
         GXt_char1 = "" ;
         ClassString = "" ;
         StyleString = "" ;
         lblTextblock1_Jsonclick = "" ;
         lblFirsttext_Jsonclick = "" ;
         lblSecondtext_Jsonclick = "" ;
         lblThirdtext_Jsonclick = "" ;
         lblFourthtext_Jsonclick = "" ;
         lblFifthtext_Jsonclick = "" ;
         lblTextblockheader1_Jsonclick = "" ;
         GXt_char2 = "" ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sDynURL = "" ;
         Form = new GXWebForm();
         WebComp_Wcrecentlinks = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         context.Gx_err = 0 ;
      }

      private short initialized ;
      private short GxWebError ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short nGotPars ;
      private short nGXWrapped ;
      private int tblTable2_Visible ;
      private int lblHome_Visible ;
      private int lblFirsttext_Visible ;
      private int lblSecondtext_Visible ;
      private int lblThirdtext_Visible ;
      private int lblFourthtext_Visible ;
      private int lblFifthtext_Visible ;
      private int idxLst ;
      private String sPrefix ;
      private String OldWcrecentlinks ;
      private String WebComp_Wcrecentlinks_Component ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String tblTable2_Internalname ;
      private String lblHome_Internalname ;
      private String lblFirsttext_Internalname ;
      private String lblSecondtext_Internalname ;
      private String lblThirdtext_Internalname ;
      private String lblFourthtext_Internalname ;
      private String lblFifthtext_Internalname ;
      private String sStyleString ;
      private String tblTable4_Internalname ;
      private String GXt_char1 ;
      private String tblTable10_Internalname ;
      private String tblTable9_Internalname ;
      private String tblTable3_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String lblTextblock1_Internalname ;
      private String lblTextblock1_Jsonclick ;
      private String tblTable8_Internalname ;
      private String tblTable7_Internalname ;
      private String tblTable6_Internalname ;
      private String tblTable5_Internalname ;
      private String lblHome_Jsonclick ;
      private String lblFirsttext_Jsonclick ;
      private String lblSecondtext_Jsonclick ;
      private String lblThirdtext_Jsonclick ;
      private String lblFourthtext_Jsonclick ;
      private String lblFifthtext_Jsonclick ;
      private String tblTable1_Internalname ;
      private String imgBtn_topl_Internalname ;
      private String imgBtn_topr_Internalname ;
      private String lblTextblockheader1_Internalname ;
      private String lblTextblockheader1_Jsonclick ;
      private String GXt_char2 ;
      private String imgImage1_Internalname ;
      private String sDynURL ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool returnInSub ;
      private GXWebComponent WebComp_Wcrecentlinks ;
      private IGxDataStore dsDefault ;
      private GXDataAreaControl Contentholder ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

}
