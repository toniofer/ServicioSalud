using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using System.Runtime.Remoting;
using GeneXus.WebControls;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Data.SqlTypes;
namespace GeneXus.Programs {
   public class GxWebStd
   {
      static public void gx_hidden_field( IGxContext context ,
                                          String sCtrlName ,
                                          String sValue )
      {
         context.httpAjaxContext.ajax_rsp_assign_hidden(sCtrlName, sValue);
      }

      static public void gx_single_line_edit1( IGxContext context ,
                                               String sCtrlName ,
                                               String sValue ,
                                               String sTooltipText ,
                                               int nWidth ,
                                               String nWidthUnit ,
                                               int nHeight ,
                                               String nHeightUnit ,
                                               int nLength ,
                                               int nVisible ,
                                               int nEnabled ,
                                               int nRTEnabled ,
                                               short nIsPassword ,
                                               short nFormat ,
                                               String sLinkURL ,
                                               String sLinkTarget ,
                                               String sStyleString ,
                                               String sClassString ,
                                               String sROClassString ,
                                               String sFormatedValue ,
                                               String sTags ,
                                               int nJScriptCode ,
                                               String sUserOnClickCode ,
                                               String sEventName ,
                                               int nParentId ,
                                               short bHasTheme ,
                                               short nAutoComplete ,
                                               bool bSendHidden ,
                                               String sCallerPgm )
      {
         gx_single_line_edit( context, sCtrlName, sValue, sTooltipText, nWidth, nWidthUnit, nHeight, nHeightUnit, nLength, nVisible, nEnabled, nRTEnabled, nIsPassword, nFormat, sLinkURL, sLinkTarget, sStyleString, sClassString, sROClassString, sFormatedValue, sTags, nJScriptCode, sUserOnClickCode, sEventName, nParentId, bHasTheme, nAutoComplete, bSendHidden, "", sCallerPgm) ;
      }

      static public void gx_single_line_edit( IGxContext context ,
                                              String sCtrlName ,
                                              String sValue ,
                                              String sTooltipText ,
                                              int nWidth ,
                                              String nWidthUnit ,
                                              int nHeight ,
                                              String nHeightUnit ,
                                              int nLength ,
                                              int nVisible ,
                                              int nEnabled ,
                                              int nRTEnabled ,
                                              short nIsPassword ,
                                              short nFormat ,
                                              String sLinkURL ,
                                              String sLinkTarget ,
                                              String sStyleString ,
                                              String sClassString ,
                                              String sROClassString ,
                                              String sFormatedValue ,
                                              String sTags ,
                                              int nJScriptCode ,
                                              String sUserOnClickCode ,
                                              String sEventName ,
                                              int nParentId ,
                                              short bHasTheme ,
                                              short nAutoComplete ,
                                              bool bSendHidden ,
                                              String sAlign ,
                                              String sCallerPgm )
      {
         String sOStyle ;
         String sEventJsCode ;
         String ClassHTML ;
         String sSize ;
         sEventJsCode = "" ;
         sSize = "" ;
         if ( nWidth > 0 )
         {
            if ( StringUtil.StrCmp(nWidthUnit, "chr") == 0 )
            {
               sSize = " size=\"" + nWidth + "\"" ;
            }
            else
            {
               sStyleString = sStyleString + ";width: " + StringUtil.LTrim( StringUtil.Str( (decimal)(nWidth), 10, 0)+nWidthUnit) + ";" ;
            }
         }
         if ( ( nHeight > 0 ) && ( StringUtil.StrCmp(nWidthUnit, "row") != 0 ) )
         {
            sStyleString = sStyleString + ";height: " + StringUtil.LTrim( StringUtil.Str( (decimal)(nHeight), 10, 0)+nHeightUnit) + ";" ;
         }
         sOStyle = sStyleString ;
         sStyleString = sStyleString + ((nVisible==0)||((nEnabled==0)&&(nRTEnabled==1)) ? ";display:none;" : "") ;
         if ( ( nRTEnabled != 0 ) || ( nEnabled != 0 ) )
         {
            /* Control allows input */
            context.WriteHtmlText( "<input type=") ;
            if ( nIsPassword != 0 )
            {
               context.WriteHtmlText( "\"password\"") ;
            }
            else
            {
               context.WriteHtmlText( "\"text\"") ;
            }
            context.WriteHtmlText( " id=\"") ;
            context.WriteHtmlText( sCtrlName) ;
            context.WriteHtmlText( "\"") ;
            context.WriteHtmlText( " name=\"") ;
            context.WriteHtmlText( sCtrlName) ;
            context.WriteHtmlText( "\"") ;
            context.WriteHtmlText( " value=\"") ;
            if ( context.DrawingGrid )
            {
               context.SendWebValue( sFormatedValue) ;
            }
            else
            {
               context.SendWebValue( sValue) ;
            }
            context.WriteHtmlText( "\"") ;
            context.WriteHtmlText( sSize) ;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sTooltipText)) )
            {
               context.WriteHtmlText( " title=\"") ;
               context.WriteHtmlText( sTooltipText) ;
               context.WriteHtmlText( "\"") ;
            }
            context.WriteHtmlText( " maxlength=\"") ;
            context.WriteHtmlText( StringUtil.FormatLong( nLength)) ;
            context.WriteHtmlText( "\"") ;
            GxWebStd.ClassAttribute( context, sClassString);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sAlign)) )
            {
               GxWebStd.StyleAttribute( context, sStyleString+"text-align:"+sAlign);
            }
            else
            {
               GxWebStd.StyleAttribute( context, sStyleString);
            }
            context.WriteHtmlText( sTags) ;
            context.WriteHtmlText( GXUtil.HtmlEndTag( HTMLElement.INPUT)) ;
            if ( nAutoComplete == 0 )
            {
               GxWebStd.gx_ctrl_attribute( context, sCtrlName, "autocomplete", "off", false);
            }
         }
         if ( nEnabled == 0 )
         {
            /* Control is read only */
            if ( ( nRTEnabled == 0 ) && bSendHidden )
            {
               GxWebStd.gx_hidden_field( context, sCtrlName, sValue);
            }
            if ( bHasTheme == 0 )
            {
               ClassHTML = sClassString ;
            }
            else
            {
               if ( nParentId == 0 )
               {
                  if ( ( StringUtil.Len( sClassString) != 0 ) && ( StringUtil.StringSearch( sClassString, "Readonly", 1) != 1 ) )
                  {
                     ClassHTML = "Readonly" + sClassString ;
                  }
                  else
                  {
                     ClassHTML = sClassString ;
                  }
               }
               else
               {
                  if ( ( StringUtil.Len( sROClassString) != 0 ) && ( StringUtil.StringSearch( sROClassString, "Readonly", 1) != 1 ) )
                  {
                     ClassHTML = "Readonly" + sROClassString ;
                  }
                  else
                  {
                     ClassHTML = sROClassString ;
                  }
               }
            }
            if ( nFormat != 2 )
            {
               sOStyle = sOStyle + ((nVisible==0) ? ";display:none;" : "") ;
               context.WriteHtmlText( "<span") ;
               GxWebStd.ClassAttribute( context, ClassHTML);
               GxWebStd.StyleAttribute( context, sOStyle);
               context.WriteHtmlText( ((StringUtil.Len( sTooltipText)>0) ? " title=\""+sTooltipText+"\"" : "")+" id=\"span_"+sCtrlName+"\"") ;
               context.WriteHtmlText( ">") ;
               /* Initialize internal JScript code according to EventNo */
               if ( nJScriptCode == 1 )
               {
                  sEventJsCode = "gx.fn.closeWindow();" ;
               }
               else if ( nJScriptCode == 2 )
               {
                  sEventJsCode = "ClearForm( this.form);" ;
               }
               else if ( nJScriptCode == 3 )
               {
                  sEventJsCode = "gx.util.help(" + "'" + context.convertURL( "Help/"+"Spanish/"+StringUtil.Lower( sCallerPgm)) + "');" ;
               }
               else if ( nJScriptCode == 7 )
               {
                  sEventJsCode = "" + "gx.evt.execCliEvt(" + sEventName + ",this);" ;
               }
               else if ( nJScriptCode == 6 )
               {
                  sEventJsCode = "gx.evt.execEvt('" + sEventName + "',this);" ;
               }
               else if ( nJScriptCode == 5 )
               {
                  sEventJsCode = "gx.evt.execEvt('" + sEventName + "',this);" ;
               }
               else if ( nJScriptCode == 0 )
               {
                  sEventJsCode = "" ;
               }
               else
               {
                  sEventJsCode = "" ;
               }
               GxWebStd.gx_start_js_anchor( context, sEventJsCode, sUserOnClickCode, sLinkURL, sLinkTarget);
            }
            if ( nIsPassword == 0 )
            {
               if ( nFormat == 0 )
               {
                  /* Text */
                  context.SendWebValue( sFormatedValue) ;
               }
               else
               {
                  if ( nFormat == 3 )
                  {
                     /* Text with meaningful spaces */
                     context.SendWebValueSpace( sFormatedValue) ;
                  }
                  else
                  {
                     context.WriteHtmlText( sFormatedValue) ;
                  }
               }
            }
            else
            {
               context.SendWebValue( StringUtil.PadR( "", (short)(nLength), "*")) ;
            }
            if ( nFormat != 2 )
            {
               GxWebStd.gx_end_js_anchor( context, sEventJsCode, sUserOnClickCode, sLinkURL);
               context.WriteHtmlText( "</span>") ;
            }
         }
      }

      static public void gx_link_start( IGxContext context ,
                                        String sLinkURL ,
                                        String sTargetWnd )
      {
         if ( StringUtil.StrCmp("", StringUtil.RTrim( sLinkURL)) != 0 )
         {
            context.WriteHtmlText( "<a href=\"") ;
            context.WriteHtmlText( StringUtil.RTrim( sLinkURL)) ;
            context.WriteHtmlText( "\"") ;
            if ( StringUtil.StrCmp("", StringUtil.RTrim( sTargetWnd)) != 0 )
            {
               context.WriteHtmlText( " target=\"") ;
               context.WriteHtmlText( StringUtil.RTrim( sTargetWnd)) ;
               context.WriteHtmlText( "\"") ;
            }
            context.WriteHtmlText( ">") ;
         }
      }

      static public void gx_link_end( IGxContext context ,
                                      String sLinkURL )
      {
         if ( StringUtil.StrCmp("", StringUtil.RTrim( sLinkURL)) != 0 )
         {
            context.WriteHtmlText( "</a>") ;
         }
      }

      static public void gx_blob_field( IGxContext context ,
                                        String sInternalName ,
                                        String sValue ,
                                        String sURL ,
                                        String sContenttype ,
                                        bool bHasFiletypeatt ,
                                        String sLinktarget ,
                                        String sObjecttagparameters ,
                                        int nDisplay ,
                                        int nEnabled ,
                                        int nVisible ,
                                        String sAlternateText ,
                                        String sTooltipText ,
                                        int nBorderWidth ,
                                        int nAutoresize ,
                                        int nWidth ,
                                        String nWidthUnit ,
                                        int nHeight ,
                                        String nHeightUnit ,
                                        int nVerticalSpace ,
                                        int nHorizontalSpace ,
                                        int nJScriptCode ,
                                        String sUserOnClickCode ,
                                        String sEventName ,
                                        String sStyleString ,
                                        String sClassString ,
                                        String sTags ,
                                        String sJsDynCode ,
                                        String sCallerPgm )
      {
         String sEventJsCode ;
         String ClassHTML ;
         sEventJsCode = "" ;
         sStyleString = sStyleString + ((nVisible!=0) ? "" : ";display:none;") ;
         if ( nEnabled != 0 )
         {
            /* Initialize internal JScript code according to EventNo */
            if ( nJScriptCode == 4 )
            {
               sEventJsCode = sJsDynCode ;
            }
            else if ( nJScriptCode == 1 )
            {
               sEventJsCode = "gx.fn.closeWindow();" + "return false;" ;
            }
            else if ( nJScriptCode == 2 )
            {
               sEventJsCode = "ClearForm( this.form);" + "return false;" ;
            }
            else if ( nJScriptCode == 3 )
            {
               sEventJsCode = "gx.util.help(" + "'" + context.convertURL( "Help/"+"Spanish/"+StringUtil.Lower( sCallerPgm)) + "');" + "return false;" ;
            }
            else if ( nJScriptCode == 7 )
            {
               sEventJsCode = "" + "gx.evt.execCliEvt(" + sEventName + ",this);" ;
            }
            else if ( nJScriptCode == 6 )
            {
               sEventJsCode = "gx.evt.execEvt('" + sEventName + "',this);" ;
            }
            else if ( nJScriptCode == 5 )
            {
               sEventJsCode = "gx.evt.execEvt('" + sEventName + "',this);" ;
            }
            else if ( nJScriptCode == 0 )
            {
               sEventJsCode = "" ;
            }
            else
            {
               sEventJsCode = "" ;
            }
         }
         context.WriteHtmlText( "<span ") ;
         if ( ! (0==nVerticalSpace) )
         {
            context.WriteHtmlText( " vspace=\"") ;
            context.WriteHtmlText( StringUtil.LTrim( StringUtil.Str( (decimal)(nVerticalSpace), 10, 0))) ;
            context.WriteHtmlText( "\"") ;
         }
         if ( ! (0==nHorizontalSpace) )
         {
            context.WriteHtmlText( " hspace=\"") ;
            context.WriteHtmlText( StringUtil.LTrim( StringUtil.Str( (decimal)(nHorizontalSpace), 10, 0))) ;
            context.WriteHtmlText( "\"") ;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sAlternateText)) )
         {
            context.WriteHtmlText( " alt=\"") ;
            context.WriteHtmlText( sAlternateText) ;
            context.WriteHtmlText( "\"") ;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sTooltipText)) )
         {
            context.WriteHtmlText( " title=\"") ;
            context.WriteHtmlText( sTooltipText) ;
            context.WriteHtmlText( "\"") ;
         }
         context.WriteHtmlText( GXUtil.HtmlEndTag( HTMLElement.SPAN)) ;
         context.WriteHtmlText( "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr><td>") ;
         if ( nDisplay == 0 )
         {
            if ( context.CheckContentType( "image", sContenttype, sURL) )
            {
               context.WriteHtmlText( "<img alt=\"\" ") ;
               context.WriteHtmlText( "src=\"") ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( sURL)) )
               {
                  sURL = context.convertURL( "blank.jpg") ;
               }
            }
            else
            {
               context.WriteHtmlText( "<object ") ;
               context.WriteHtmlText( "type=\"") ;
               context.WriteHtmlText( context.GetContentType( sContenttype)) ;
               context.WriteHtmlText( "\" data=\"") ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( sURL)) )
               {
                  sURL = "about:blank" ;
               }
            }
            context.WriteHtmlText( sURL) ;
            context.WriteHtmlText( "\" id=\"Object_") ;
            context.WriteHtmlText( sInternalName) ;
            context.WriteHtmlText( "\" style=\"display:block;") ;
            if ( ! (0==nWidth) && ( ( nAutoresize == 0 ) ) )
            {
               context.WriteHtmlText( " width:") ;
               context.WriteHtmlText( StringUtil.LTrim( StringUtil.Str( (decimal)(nWidth), 10, 0))) ;
               context.WriteHtmlText( nWidthUnit+";") ;
            }
            if ( ! (0==nHeight) && ( ( nAutoresize == 0 ) ) )
            {
               context.WriteHtmlText( " height:") ;
               context.WriteHtmlText( StringUtil.LTrim( StringUtil.Str( (decimal)(nHeight), 10, 0))) ;
               context.WriteHtmlText( nHeightUnit+";") ;
            }
            context.WriteHtmlText( sStyleString) ;
            if ( StringUtil.Len( sClassString) != 0 )
            {
               ClassHTML = "BlobContent" + sClassString ;
            }
            else
            {
               ClassHTML = sClassString ;
            }
            if ( ( nEnabled == 0 ) && ( StringUtil.Len( sClassString) != 0 ) && ( StringUtil.StringSearch( sClassString, "Readonly", 1) != 1 ) )
            {
               ClassHTML = "Readonly" + ClassHTML ;
            }
            context.WriteHtmlText( "\" ") ;
            GxWebStd.ClassAttribute( context, ClassHTML);
            context.WriteHtmlText( sTags) ;
            if ( context.CheckContentType( "image", sContenttype, sURL) )
            {
               context.WriteHtmlText( GXUtil.HtmlEndTag( HTMLElement.IMG)) ;
            }
            else
            {
               context.WriteHtmlText( ">") ;
               context.WriteHtmlText( sObjecttagparameters) ;
               context.WriteHtmlText( "</object>") ;
            }
         }
         else
         {
            if ( nDisplay == 1 )
            {
               context.WriteHtmlText( "<a id=\"Link_") ;
               context.WriteHtmlText( sInternalName) ;
               context.WriteHtmlText( "\"") ;
               if ( StringUtil.StrCmp(sURL, "") != 0 )
               {
                  GxWebStd.StyleAttribute( context, "display:block;"+sStyleString);
               }
               else
               {
                  GxWebStd.StyleAttribute( context, "display:none;"+sStyleString);
               }
               context.WriteHtmlText( "href=\"") ;
               context.WriteHtmlText( sURL) ;
               context.WriteHtmlText( "\" type=\"") ;
               context.WriteHtmlText( sContenttype) ;
               context.WriteHtmlText( "\"") ;
               if ( StringUtil.Len( sLinktarget) > 0 )
               {
                  context.WriteHtmlText( " target=\"") ;
                  context.WriteHtmlText( StringUtil.RTrim( sLinktarget)) ;
                  context.WriteHtmlText( "\"") ;
               }
               context.WriteHtmlText( "><img border=\"0\" src=\"") ;
               context.WriteHtmlText( context.convertURL( "download.gif")) ;
               context.WriteHtmlText( "\" alt=\"Download\""+GXUtil.HtmlEndTag( HTMLElement.IMG)) ;
               context.WriteHtmlText( "</a>") ;
            }
         }
         context.WriteHtmlText( "</td></tr><tr><td>") ;
         if ( nEnabled == 1 )
         {
            context.WriteHtmlText( "<script type=\"text/javascript\">document.forms[0].encoding=\"multipart/form-data\"</script>") ;
            context.WriteHtmlText( "<input type=\"file\" ") ;
            context.WriteHtmlText( " id=\"") ;
            context.WriteHtmlText( sInternalName) ;
            context.WriteHtmlText( "\"") ;
            context.WriteHtmlText( " name=\"") ;
            context.WriteHtmlText( sInternalName) ;
            context.WriteHtmlText( "\"") ;
            sStyleString = "" ;
            if ( nVisible == 0 )
            {
               sStyleString = "display:none;" ;
            }
            if ( ! (0==nWidth) )
            {
               sStyleString = sStyleString + " width:" + StringUtil.LTrim( StringUtil.Str( (decimal)(nWidth), 10, 0)) + ";" ;
            }
            GxWebStd.StyleAttribute( context, sStyleString);
            context.WriteHtmlText( " value=\"") ;
            context.SendWebValue( sValue) ;
            context.WriteHtmlText( "\" ") ;
            if ( StringUtil.Len( sClassString) != 0 )
            {
               ClassHTML = "BlobInput" + sClassString ;
            }
            else
            {
               ClassHTML = sClassString ;
            }
            if ( ( nEnabled == 0 ) && ( StringUtil.Len( sClassString) != 0 ) && ( StringUtil.StringSearch( sClassString, "Readonly", 1) != 1 ) )
            {
               ClassHTML = "Readonly" + ClassHTML ;
            }
            GxWebStd.ClassAttribute( context, ClassHTML);
            context.WriteHtmlText( sTags) ;
            context.WriteHtmlText( GXUtil.HtmlEndTag( HTMLElement.INPUT)) ;
         }
         context.WriteHtmlText( "</td></tr></table>") ;
         context.WriteHtmlText( "</span>") ;
      }

      static public void gx_button_ctrl( IGxContext context ,
                                         int nReset ,
                                         String sCtrlName ,
                                         String sCaption ,
                                         String sTooltipText ,
                                         String sAccesskey ,
                                         String sStyleString ,
                                         String sClassString ,
                                         int nVisible ,
                                         int nEnabled ,
                                         String sBorderStyle ,
                                         int nJScriptCode ,
                                         String sUserOnClickCode ,
                                         String sEventName ,
                                         String sTags ,
                                         String sJsCode ,
                                         String sJsDynCode ,
                                         String sCallerPgm )
      {
         String sEventJsCode ;
         String sCapAKey ;
         String sClassRoundedBtn ;
         sStyleString = sStyleString + ((nVisible!=0) ? "" : ";display:none;") ;
         sClassRoundedBtn = "BaseRBtn " + "R" + sClassString ;
         if ( StringUtil.StrCmp(sBorderStyle, "rounded") == 0 )
         {
            sClassString = "BtnText" ;
            context.WriteHtmlText( "<span onclick=\"gx.evt.doClick(") ;
            context.WriteHtmlText( "'") ;
            context.WriteHtmlText( sCtrlName) ;
            context.WriteHtmlText( "', event") ;
            context.WriteHtmlText( ")\" ") ;
            GxWebStd.StyleAttribute( context, sStyleString);
            GxWebStd.ClassAttribute( context, sClassRoundedBtn);
            context.WriteHtmlText( "><span class=\"BtnLeft\"><span class=\"BtnRight\"><span class=\"BtnBackground\">") ;
         }
         context.WriteHtmlText( "<input type=") ;
         if ( nReset == 1 )
         {
            context.WriteHtmlText( "\"submit\"") ;
         }
         else if ( nReset == 0 )
         {
            context.WriteHtmlText( "\"reset\"") ;
         }
         else
         {
            context.WriteHtmlText( "\"button\"") ;
         }
         sCapAKey = GXUtil.AccessKey( sCaption) ;
         sCaption = GXUtil.AccessKeyCaption( sCaption) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( sCapAKey)) )
         {
            sCapAKey = GXUtil.AccessKey( sTooltipText) ;
            sTooltipText = GXUtil.AccessKeyCaption( sTooltipText) ;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sCapAKey)) )
         {
            sAccesskey = sCapAKey ;
         }
         context.WriteHtmlText( " name=\"") ;
         context.WriteHtmlText( sCtrlName) ;
         context.WriteHtmlText( "\"") ;
         context.WriteHtmlText( " value=\"") ;
         context.WriteHtmlText( sCaption) ;
         context.WriteHtmlText( "\"") ;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sTooltipText)) )
         {
            context.WriteHtmlText( " title=\"") ;
            context.WriteHtmlText( sTooltipText) ;
            context.WriteHtmlText( "\"") ;
         }
         if ( StringUtil.Len( sAccesskey) != 0 )
         {
            context.WriteHtmlText( " accesskey=\"") ;
            context.WriteHtmlText( sAccesskey) ;
            context.WriteHtmlText( "\"") ;
         }
         GxWebStd.ClassAttribute( context, sClassString);
         GxWebStd.StyleAttribute( context, sStyleString);
         if ( nEnabled == 0 )
         {
            context.WriteHtmlText( " disabled=\"disabled\"") ;
         }
         /* Initialize internal JScript code according to EventNo */
         if ( nJScriptCode == 4 )
         {
            sEventJsCode = sJsDynCode ;
         }
         else if ( nJScriptCode == 1 )
         {
            sEventJsCode = "gx.fn.closeWindow();" + "return false;" ;
         }
         else if ( nJScriptCode == 2 )
         {
            sEventJsCode = "ClearForm( this.form);" + "return false;" ;
         }
         else if ( nJScriptCode == 3 )
         {
            sEventJsCode = "gx.util.help(" + "'" + context.convertURL( "Help/"+"Spanish/"+StringUtil.Lower( sCallerPgm)) + "');" + "return false;" ;
         }
         else if ( nJScriptCode == 7 )
         {
            sEventJsCode = "gx.evt.checkCtrlFocus(this);" + "gx.evt.execCliEvt(" + sEventName + ",this);" ;
         }
         else if ( nJScriptCode == 6 )
         {
            sEventJsCode = "gx.evt.execEvt('" + sEventName + "',this);" ;
         }
         else if ( nJScriptCode == 5 )
         {
            sEventJsCode = "gx.evt.execEvt('" + sEventName + "',this);" ;
         }
         else if ( nJScriptCode == 0 )
         {
            sEventJsCode = "" ;
         }
         else
         {
            sEventJsCode = "" ;
         }
         sEventJsCode = sJsCode + sEventJsCode ;
         GxWebStd.gx_on_js_event( context, "onclick", sEventJsCode);
         context.WriteHtmlText( " ") ;
         context.WriteHtmlText( sTags) ;
         context.WriteHtmlText( GXUtil.HtmlEndTag( HTMLElement.INPUT)) ;
         GxWebStd.gx_ctrl_attribute( context, sCtrlName, "jsevent", sUserOnClickCode, false);
         if ( StringUtil.StrCmp(sBorderStyle, "rounded") == 0 )
         {
            context.WriteHtmlText( "</span></span></span></span>") ;
         }
      }

      static public void gx_on_js_event( IGxContext context ,
                                         String sEventName ,
                                         String sEventJsCode )
      {
         context.WriteHtmlText( " ") ;
         context.WriteHtmlText( sEventName) ;
         context.WriteHtmlText( "=\"if( ") ;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sEventJsCode)) )
         {
            context.WriteHtmlText( "gx.evt.jsEvent(this)") ;
            context.WriteHtmlText( ") {") ;
            context.WriteHtmlText( sEventJsCode) ;
            context.WriteHtmlText( "} else return false;\"") ;
         }
         else
         {
            context.WriteHtmlText( "!(") ;
            context.WriteHtmlText( "gx.evt.jsEvent(this)") ;
            context.WriteHtmlText( ")) return false;\"") ;
         }
      }

      static public void gx_ctrl_attribute( IGxContext context ,
                                            String sControlName ,
                                            String sAttName ,
                                            String sAttValue ,
                                            bool bCustomEvent )
      {
         if ( bCustomEvent )
         {
            context.WriteHtmlText( "<script type=\"text/javascript\">gx.dom.setAttribute(\"") ;
            context.WriteHtmlText( sControlName) ;
            context.WriteHtmlText( "\",\"") ;
            context.WriteHtmlText( sAttName) ;
            context.WriteHtmlText( "\",\"if(") ;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sAttValue)) )
            {
               context.WriteHtmlText( "gx.evt.jsEvent(this)") ;
               context.WriteHtmlText( ") {") ;
               context.WriteHtmlText( sAttValue) ;
               context.WriteHtmlText( "} else return false;\"") ;
            }
            else
            {
               context.WriteHtmlText( "!(") ;
               context.WriteHtmlText( "gx.evt.jsEvent(this)") ;
               context.WriteHtmlText( ")) return false;\"") ;
            }
            context.WriteHtmlText( ");</script>") ;
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sAttValue)) )
            {
               context.WriteHtmlText( "<script type=\"text/javascript\">gx.dom.setAttribute(\"") ;
               context.WriteHtmlText( sControlName) ;
               context.WriteHtmlText( "\",\"") ;
               context.WriteHtmlText( sAttName) ;
               context.WriteHtmlText( "\",\"") ;
               context.WriteHtmlText( sAttValue) ;
               context.WriteHtmlText( "\");</script>") ;
            }
         }
      }

      static public void gx_msg_list( IGxContext context ,
                                      String sCtrlName ,
                                      int nDisplayMode ,
                                      String sStyleString ,
                                      String sClassString ,
                                      String sCmpCtx ,
                                      String sInMaster )
      {
         int i ;
         context.WriteHtmlText( "<div>") ;
         context.WriteHtmlText( "<span") ;
         GxWebStd.ClassAttribute( context, sClassString);
         GxWebStd.StyleAttribute( context, sStyleString);
         context.WriteHtmlText( " id=\""+sCmpCtx+"gxErrorViewer\"") ;
         context.WriteHtmlText( ">") ;
         i = 1 ;
         while ( i <= context.GX_msglist.ItemCount )
         {
            context.WriteHtmlText( "<div>") ;
            context.WriteHtmlText( context.GX_msglist.getItemText((short)(i))) ;
            context.WriteHtmlText( "</div>") ;
            i = (int)(i+1) ;
         }
         context.WriteHtmlText( "</span>") ;
         context.WriteHtmlText( "</div>") ;
      }

      static public void gx_combobox_ctrl( IGxContext context ,
                                           GXCombobox cmbCObjCtrl ,
                                           String sCtrlName ,
                                           String sValue ,
                                           String sTooltipText ,
                                           String sType ,
                                           int nVisible ,
                                           int nEnabled ,
                                           int nRTEnabled ,
                                           int nRows ,
                                           short nFormat ,
                                           int nWidth ,
                                           String nWidthUnit ,
                                           int nHeight ,
                                           String nHeightUnit ,
                                           String sStyleString ,
                                           String sClassString ,
                                           String sFormatedValue ,
                                           int nJScriptCode ,
                                           String sUserOnClickCode ,
                                           String sEventName ,
                                           String sTags ,
                                           String sCallerPgm )
      {
         gx_combobox_ctrl1( context, cmbCObjCtrl, sCtrlName, sValue, sTooltipText, sType, nVisible, nEnabled, nRTEnabled, nRows, nFormat, nWidth, nWidthUnit, nHeight, nHeightUnit, sStyleString, sClassString, sFormatedValue, nJScriptCode, sUserOnClickCode, sEventName, sTags, true, sCallerPgm) ;
      }

      static public void gx_combobox_ctrl1( IGxContext context ,
                                            GXCombobox cmbCObjCtrl ,
                                            String sCtrlName ,
                                            String sValue ,
                                            String sTooltipText ,
                                            String sType ,
                                            int nVisible ,
                                            int nEnabled ,
                                            int nRTEnabled ,
                                            int nRows ,
                                            short nFormat ,
                                            int nWidth ,
                                            String nWidthUnit ,
                                            int nHeight ,
                                            String nHeightUnit ,
                                            String sStyleString ,
                                            String sClassString ,
                                            String sFormatedValue ,
                                            int nJScriptCode ,
                                            String sUserOnClickCode ,
                                            String sEventName ,
                                            String sTags ,
                                            bool bSendHidden ,
                                            String sCallerPgm )
      {
         String sOStyle ;
         String sEventJsCode ;
         int idxLst ;
         String ClassHTML ;
         idxLst = 1 ;
         if ( nWidth > 0 )
         {
            sStyleString = sStyleString + ";width: " + StringUtil.LTrim( StringUtil.Str( (decimal)(nWidth), 10, 0)+nWidthUnit) ;
         }
         if ( nHeight > 0 )
         {
            sStyleString = sStyleString + ";height: " + StringUtil.LTrim( StringUtil.Str( (decimal)(nHeight), 10, 0)+nHeightUnit) ;
         }
         sOStyle = sStyleString + " ;overflow:hidden;" ;
         sStyleString = sStyleString + ((nVisible==0)||(nEnabled==0)&&(nRTEnabled!=0) ? ";display:none;" : "") ;
         if ( ( nEnabled != 0 ) || ( nRTEnabled != 0 ) )
         {
            /* Initialize internal JScript code according to EventNo */
            if ( nJScriptCode == 1 )
            {
               sEventJsCode = "gx.fn.closeWindow();" + "return false;" ;
            }
            else if ( nJScriptCode == 2 )
            {
               sEventJsCode = "ClearForm( this.form);" + "return false;" ;
            }
            else if ( nJScriptCode == 3 )
            {
               sEventJsCode = "gx.util.help(" + "'" + context.convertURL( "Help/"+"Spanish/"+StringUtil.Lower( sCallerPgm)) + "');" + "return false;" ;
            }
            else if ( nJScriptCode == 7 )
            {
               sEventJsCode = "" + "gx.evt.execCliEvt(" + sEventName + ",this);" ;
            }
            else if ( nJScriptCode == 6 )
            {
               sEventJsCode = "gx.evt.execEvt('" + sEventName + "',this);" ;
            }
            else if ( nJScriptCode == 5 )
            {
               sEventJsCode = "gx.evt.execEvt('" + sEventName + "',this);" ;
            }
            else if ( nJScriptCode == 0 )
            {
               sEventJsCode = "" ;
            }
            else
            {
               sEventJsCode = "" ;
            }
            context.WriteHtmlText( "<select") ;
            if ( nRows > 1 )
            {
               context.WriteHtmlText( " size=") ;
               context.WriteHtmlText( StringUtil.LTrim( StringUtil.FormatLong( nRows))) ;
            }
            context.WriteHtmlText( " id=\"") ;
            context.WriteHtmlText( sCtrlName+"\"") ;
            context.WriteHtmlText( " name=\"") ;
            context.WriteHtmlText( sCtrlName+"\"") ;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sTooltipText)) )
            {
               context.WriteHtmlText( " title=\"") ;
               context.WriteHtmlText( sTooltipText) ;
               context.WriteHtmlText( "\"") ;
            }
            GxWebStd.ClassAttribute( context, sClassString);
            GxWebStd.StyleAttribute( context, sStyleString);
            context.WriteHtmlText( sTags) ;
            context.WriteHtmlTextNl( ">") ;
            if ( nEnabled == 0 )
            {
               context.WriteHtmlText( "<script type=\"text/javascript\">gx.fn.disableCtrl(\""+sCtrlName+"\");</script>") ;
            }
            while ( idxLst <= cmbCObjCtrl.ItemCount )
            {
               if ( StringUtil.StrCmp(sType, "int") == 0 )
               {
                  context.WriteHtmlText( "<option value=\""+StringUtil.Trim( cmbCObjCtrl.getItemValue((short)(idxLst)))) ;
               }
               else
               {
                  context.WriteHtmlText( "<option value=\""+StringUtil.RTrim( cmbCObjCtrl.getItemValue((short)(idxLst)))) ;
               }
               if ( StringUtil.StrCmp(StringUtil.LTrim( cmbCObjCtrl.getItemValue((short)(idxLst))), StringUtil.LTrim( sValue)) == 0 )
               {
                  context.WriteHtmlText( "\" selected=\"selected\" >") ;
               }
               else
               {
                  context.WriteHtmlText( "\">") ;
               }
               if ( nFormat == 0 )
               {
                  context.SendWebValue( cmbCObjCtrl.getItemText((short)(idxLst))) ;
               }
               else
               {
                  if ( nFormat == 3 )
                  {
                     context.SendWebValueSpace( cmbCObjCtrl.getItemText((short)(idxLst))) ;
                  }
                  else
                  {
                     context.WriteHtmlText( cmbCObjCtrl.getItemText((short)(idxLst))) ;
                  }
               }
               context.WriteHtmlTextNl( GXUtil.HtmlEndTag( HTMLElement.OPTION)) ;
               idxLst = (int)(idxLst+1) ;
            }
            context.WriteHtmlTextNl( "</select>") ;
            GxWebStd.gx_ctrl_attribute( context, sCtrlName, "jsevent", sUserOnClickCode, false);
            GxWebStd.gx_ctrl_attribute( context, sCtrlName, "gxoch0", sEventJsCode, true);
         }
         if ( nEnabled == 0 )
         {
            if ( ( nRTEnabled == 0 ) && bSendHidden )
            {
               GxWebStd.gx_hidden_field( context, sCtrlName, sValue);
            }
            if ( ( StringUtil.Len( sClassString) != 0 ) && ( StringUtil.StringSearch( sClassString, "Readonly", 1) != 1 ) )
            {
               ClassHTML = "Readonly" + sClassString ;
            }
            else
            {
               ClassHTML = sClassString ;
            }
            sOStyle = sOStyle + ((nVisible==0) ? ";display:none;" : "") ;
            idxLst = 1 ;
            context.WriteHtmlText( "<span") ;
            GxWebStd.ClassAttribute( context, ClassHTML);
            GxWebStd.StyleAttribute( context, sOStyle);
            context.WriteHtmlText( sTags+((StringUtil.Len( sTooltipText)>0) ? " title=\""+sTooltipText+"\"" : "")+" id=\"span_"+sCtrlName+"\"") ;
            context.WriteHtmlText( ">") ;
            while ( idxLst <= cmbCObjCtrl.ItemCount )
            {
               if ( StringUtil.StrCmp(StringUtil.LTrim( cmbCObjCtrl.getItemValue((short)(idxLst))), StringUtil.LTrim( sValue)) == 0 )
               {
                  if ( nFormat == 0 )
                  {
                     context.SendWebValue( cmbCObjCtrl.getItemText((short)(idxLst))) ;
                  }
                  else
                  {
                     if ( nFormat == 3 )
                     {
                        context.SendWebValueSpace( cmbCObjCtrl.getItemText((short)(idxLst))) ;
                     }
                     else
                     {
                        context.WriteHtmlText( cmbCObjCtrl.getItemText((short)(idxLst))) ;
                     }
                  }
                  if (true) break;
               }
               idxLst = (int)(idxLst+1) ;
            }
            context.WriteHtmlText( "</span>") ;
         }
      }

      static public void gx_listbox_ctrl( IGxContext context ,
                                          GXListbox lstLObjCtrl ,
                                          String sCtrlName ,
                                          String sValue ,
                                          String sTooltipText ,
                                          String sType ,
                                          int nVisible ,
                                          int nEnabled ,
                                          int nRTEnabled ,
                                          int nRows ,
                                          short nFormat ,
                                          int nWidth ,
                                          String nWidthUnit ,
                                          int nHeight ,
                                          String nHeightUnit ,
                                          String sStyleString ,
                                          String sClassString ,
                                          String sFormatedValue ,
                                          int nJScriptCode ,
                                          String sUserOnClickCode ,
                                          String sEventName ,
                                          String sTags ,
                                          String sCallerPgm )
      {
         gx_listbox_ctrl1( context, lstLObjCtrl, sCtrlName, sValue, sTooltipText, sType, nVisible, nEnabled, nRTEnabled, nRows, nFormat, nWidth, nWidthUnit, nHeight, nHeightUnit, sStyleString, sClassString, sFormatedValue, nJScriptCode, sUserOnClickCode, sEventName, sTags, true, sCallerPgm) ;
      }

      static public void gx_listbox_ctrl1( IGxContext context ,
                                           GXListbox lstLObjCtrl ,
                                           String sCtrlName ,
                                           String sValue ,
                                           String sTooltipText ,
                                           String sType ,
                                           int nVisible ,
                                           int nEnabled ,
                                           int nRTEnabled ,
                                           int nRows ,
                                           short nFormat ,
                                           int nWidth ,
                                           String nWidthUnit ,
                                           int nHeight ,
                                           String nHeightUnit ,
                                           String sStyleString ,
                                           String sClassString ,
                                           String sFormatedValue ,
                                           int nJScriptCode ,
                                           String sUserOnClickCode ,
                                           String sEventName ,
                                           String sTags ,
                                           bool bSendHidden ,
                                           String sCallerPgm )
      {
         String sOStyle ;
         String sEventJsCode ;
         int idxLst ;
         String ClassHTML ;
         idxLst = 1 ;
         if ( nWidth > 0 )
         {
            sStyleString = sStyleString + ";width: " + StringUtil.LTrim( StringUtil.Str( (decimal)(nWidth), 10, 0)+nWidthUnit) ;
         }
         if ( nHeight > 0 )
         {
            sStyleString = sStyleString + ";height: " + StringUtil.LTrim( StringUtil.Str( (decimal)(nHeight), 10, 0)+nHeightUnit) ;
         }
         sOStyle = sStyleString + " ;overflow:hidden;" ;
         sStyleString = sStyleString + ((nVisible==0)||(nEnabled==0)&&(nRTEnabled!=0) ? ";display:none;" : "") ;
         if ( ( nEnabled != 0 ) || ( nRTEnabled != 0 ) )
         {
            /* Initialize internal JScript code according to EventNo */
            if ( nJScriptCode == 1 )
            {
               sEventJsCode = "gx.fn.closeWindow();" + "return false;" ;
            }
            else if ( nJScriptCode == 2 )
            {
               sEventJsCode = "ClearForm( this.form);" + "return false;" ;
            }
            else if ( nJScriptCode == 3 )
            {
               sEventJsCode = "gx.util.help(" + "'" + context.convertURL( "Help/"+"Spanish/"+StringUtil.Lower( sCallerPgm)) + "');" + "return false;" ;
            }
            else if ( nJScriptCode == 7 )
            {
               sEventJsCode = "" + "gx.evt.execCliEvt(" + sEventName + ",this);" ;
            }
            else if ( nJScriptCode == 6 )
            {
               sEventJsCode = "gx.evt.execEvt('" + sEventName + "',this);" ;
            }
            else if ( nJScriptCode == 5 )
            {
               sEventJsCode = "gx.evt.execEvt('" + sEventName + "',this);" ;
            }
            else if ( nJScriptCode == 0 )
            {
               sEventJsCode = "" ;
            }
            else
            {
               sEventJsCode = "" ;
            }
            context.WriteHtmlText( "<select") ;
            if ( nRows > 1 )
            {
               context.WriteHtmlText( " size=") ;
               context.WriteHtmlText( StringUtil.LTrim( StringUtil.FormatLong( nRows))) ;
            }
            context.WriteHtmlText( " id=\"") ;
            context.WriteHtmlText( sCtrlName+"\"") ;
            context.WriteHtmlText( " name=\"") ;
            context.WriteHtmlText( sCtrlName+"\"") ;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sTooltipText)) )
            {
               context.WriteHtmlText( " title=\"") ;
               context.WriteHtmlText( sTooltipText) ;
               context.WriteHtmlText( "\"") ;
            }
            GxWebStd.ClassAttribute( context, sClassString);
            GxWebStd.StyleAttribute( context, sStyleString);
            context.WriteHtmlText( sTags) ;
            context.WriteHtmlTextNl( ">") ;
            if ( nEnabled == 0 )
            {
               context.WriteHtmlText( "<script type=\"text/javascript\">gx.fn.disableCtrl(\""+sCtrlName+"\");</script>") ;
            }
            while ( idxLst <= lstLObjCtrl.ItemCount )
            {
               if ( StringUtil.StrCmp(sType, "int") == 0 )
               {
                  context.WriteHtmlText( "<option value=\""+StringUtil.Trim( lstLObjCtrl.getItemValue((short)(idxLst)))) ;
               }
               else
               {
                  context.WriteHtmlText( "<option value=\""+StringUtil.RTrim( lstLObjCtrl.getItemValue((short)(idxLst)))) ;
               }
               if ( StringUtil.StrCmp(StringUtil.LTrim( lstLObjCtrl.getItemValue((short)(idxLst))), StringUtil.LTrim( sValue)) == 0 )
               {
                  context.WriteHtmlText( "\" selected=\"selected\" >") ;
               }
               else
               {
                  context.WriteHtmlText( "\">") ;
               }
               if ( nFormat == 0 )
               {
                  context.SendWebValue( lstLObjCtrl.getItemText((short)(idxLst))) ;
               }
               else
               {
                  if ( nFormat == 3 )
                  {
                     context.SendWebValueSpace( lstLObjCtrl.getItemText((short)(idxLst))) ;
                  }
                  else
                  {
                     context.WriteHtmlText( lstLObjCtrl.getItemText((short)(idxLst))) ;
                  }
               }
               context.WriteHtmlTextNl( GXUtil.HtmlEndTag( HTMLElement.OPTION)) ;
               idxLst = (int)(idxLst+1) ;
            }
            context.WriteHtmlTextNl( "</select>") ;
            GxWebStd.gx_ctrl_attribute( context, sCtrlName, "jsevent", sUserOnClickCode, false);
            GxWebStd.gx_ctrl_attribute( context, sCtrlName, "gxoch0", sEventJsCode, true);
         }
         if ( nEnabled == 0 )
         {
            if ( ( nRTEnabled == 0 ) && bSendHidden )
            {
               GxWebStd.gx_hidden_field( context, sCtrlName, sValue);
            }
            if ( ( StringUtil.Len( sClassString) != 0 ) && ( StringUtil.StringSearch( sClassString, "Readonly", 1) != 1 ) )
            {
               ClassHTML = "Readonly" + sClassString ;
            }
            else
            {
               ClassHTML = sClassString ;
            }
            sOStyle = sOStyle + ((nVisible==0) ? ";display:none;" : "") ;
            idxLst = 1 ;
            context.WriteHtmlText( "<span") ;
            GxWebStd.ClassAttribute( context, ClassHTML);
            GxWebStd.StyleAttribute( context, sOStyle);
            context.WriteHtmlText( sTags+((StringUtil.Len( sTooltipText)>0) ? " title=\""+sTooltipText+"\"" : "")+" id=\"span_"+sCtrlName+"\"") ;
            context.WriteHtmlText( ">") ;
            while ( idxLst <= lstLObjCtrl.ItemCount )
            {
               if ( StringUtil.StrCmp(StringUtil.LTrim( lstLObjCtrl.getItemValue((short)(idxLst))), StringUtil.LTrim( sValue)) == 0 )
               {
                  if ( nFormat == 0 )
                  {
                     context.SendWebValue( lstLObjCtrl.getItemText((short)(idxLst))) ;
                  }
                  else
                  {
                     if ( nFormat == 3 )
                     {
                        context.SendWebValueSpace( lstLObjCtrl.getItemText((short)(idxLst))) ;
                     }
                     else
                     {
                        context.WriteHtmlText( lstLObjCtrl.getItemText((short)(idxLst))) ;
                     }
                  }
                  if (true) break;
               }
               idxLst = (int)(idxLst+1) ;
            }
            context.WriteHtmlText( "</span>") ;
         }
      }

      static public void gx_radio_ctrl( IGxContext context ,
                                        GXRadio radRObjCtrl ,
                                        String sCtrlName ,
                                        String sValue ,
                                        String sTooltipText ,
                                        int nVisible ,
                                        int nEnabled ,
                                        int nRadioColumns ,
                                        int nOrientation ,
                                        String sStyleString ,
                                        String sClassString ,
                                        int nJScriptCode ,
                                        String sUserOnClickCode ,
                                        String sEventName ,
                                        String sTags ,
                                        String sCallerPgm )
      {
         String sEventJsCode ;
         int idxLst ;
         int idxCol ;
         String ClassHTML ;
         if ( ( nEnabled == 0 ) && ( StringUtil.Len( sClassString) != 0 ) && ( StringUtil.StringSearch( sClassString, "Readonly", 1) != 1 ) )
         {
            ClassHTML = "Readonly" + sClassString ;
         }
         else
         {
            ClassHTML = sClassString ;
         }
         /* Initialize internal JScript code according to EventNo */
         if ( nJScriptCode == 1 )
         {
            sEventJsCode = "gx.fn.closeWindow();" + "return false;" ;
         }
         else if ( nJScriptCode == 2 )
         {
            sEventJsCode = "ClearForm( this.form);" + "return false;" ;
         }
         else if ( nJScriptCode == 3 )
         {
            sEventJsCode = "gx.util.help(" + "'" + context.convertURL( "Help/"+"Spanish/"+StringUtil.Lower( sCallerPgm)) + "');" + "return false;" ;
         }
         else if ( nJScriptCode == 7 )
         {
            sEventJsCode = "" + "gx.evt.execCliEvt(" + sEventName + ",this);" ;
         }
         else if ( nJScriptCode == 6 )
         {
            sEventJsCode = "gx.evt.execEvt('" + sEventName + "',this);" ;
         }
         else if ( nJScriptCode == 5 )
         {
            sEventJsCode = "gx.evt.execEvt('" + sEventName + "',this);" ;
         }
         else if ( nJScriptCode == 0 )
         {
            sEventJsCode = "" ;
         }
         else
         {
            sEventJsCode = "" ;
         }
         idxLst = 1 ;
         idxCol = 0 ;
         sStyleString = sStyleString + ((nVisible!=0) ? "" : ";display:none;") ;
         if ( nOrientation == 1 )
         {
            context.WriteHtmlText( "<table") ;
            GxWebStd.ClassAttribute( context, ClassHTML);
            GxWebStd.StyleAttribute( context, sStyleString);
            context.WriteHtmlText( ">") ;
         }
         else
         {
            context.WriteHtmlText( "<span") ;
            GxWebStd.ClassAttribute( context, ClassHTML);
            GxWebStd.StyleAttribute( context, sStyleString);
            context.WriteHtmlText( ">") ;
         }
         while ( idxLst <= radRObjCtrl.ItemCount )
         {
            if ( nOrientation == 1 )
            {
               if ( nRadioColumns > 1 )
               {
                  idxCol = (int)(((int)(idxCol+1) % (nRadioColumns))) ;
               }
               if ( idxCol == 0 )
               {
                  context.WriteHtmlText( "<tr>") ;
               }
               context.WriteHtmlText( "<td>") ;
            }
            context.skipLines(1);
            context.WriteHtmlText( "<input type=radio") ;
            context.WriteHtmlText( " name=\"") ;
            context.WriteHtmlText( sCtrlName+"\"") ;
            context.WriteHtmlText( " value=\"") ;
            context.WriteHtmlText( radRObjCtrl.getItemValue((short)(idxLst))) ;
            context.WriteHtmlText( "\"") ;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sTooltipText)) )
            {
               context.WriteHtmlText( " title=\"") ;
               context.WriteHtmlText( sTooltipText) ;
               context.WriteHtmlText( "\"") ;
            }
            if ( StringUtil.StrCmp(sValue, radRObjCtrl.getItemValue((short)(idxLst))) == 0 )
            {
               context.WriteHtmlText( " checked=\"checked\"") ;
            }
            context.WriteHtmlText( sTags) ;
            context.WriteHtmlText( GXUtil.HtmlEndTag( HTMLElement.INPUT)) ;
            GxWebStd.gx_ctrl_attribute( context, sCtrlName, "gxoch0", sEventJsCode, true);
            GxWebStd.gx_ctrl_attribute( context, sCtrlName, "jsevent", sUserOnClickCode, false);
            if ( nEnabled == 0 )
            {
               context.WriteHtmlText( "<script type=\"text/javascript\">gx.fn.disableCtrl(\""+sCtrlName+"\");</script>") ;
            }
            context.SendWebValue( radRObjCtrl.getItemText((short)(idxLst))) ;
            if ( nOrientation == 1 )
            {
               context.WriteHtmlText( "</td>") ;
               if ( idxCol == 0 )
               {
                  context.WriteHtmlText( "</tr>") ;
               }
            }
            context.skipLines(1);
            idxLst = (int)(idxLst+1) ;
         }
         if ( nOrientation == 1 )
         {
            context.WriteHtmlTextNl( "</table>") ;
         }
         else
         {
            context.WriteHtmlText( "</span>") ;
         }
      }

      static public void gx_checkbox_ctrl( IGxContext context ,
                                           String sCtrlName ,
                                           String sValue ,
                                           String sTooltipText ,
                                           int nVisible ,
                                           int nEnabled ,
                                           String sCheked ,
                                           String sCaption ,
                                           String sStyleString ,
                                           String sClassString ,
                                           String sTags )
      {
         String ClassHTML ;
         ClassHTML = sClassString ;
         sValue = StringUtil.LTrim( sValue) ;
         sCheked = StringUtil.LTrim( sCheked) ;
         if ( nEnabled == 0 )
         {
            if ( ( StringUtil.Len( sClassString) != 0 ) && ( StringUtil.StringSearch( sClassString, "Readonly", 1) != 1 ) )
            {
               ClassHTML = "Readonly" + sClassString ;
            }
         }
         sStyleString = sStyleString + ((nVisible!=0) ? "" : ";display:none;") ;
         context.WriteHtmlText( "<span") ;
         GxWebStd.ClassAttribute( context, ClassHTML);
         GxWebStd.StyleAttribute( context, sStyleString);
         context.WriteHtmlText( ">") ;
         context.WriteHtmlText( "<input type=\"checkbox\" "+((StringUtil.StrCmp(sValue, sCheked)==0) ? "checked=\"checked\"" : "")) ;
         context.WriteHtmlText( " name=\"") ;
         context.WriteHtmlText( sCtrlName) ;
         context.WriteHtmlText( "\" value=\""+((StringUtil.StrCmp(sValue, sCheked)==0) ? sCheked : "")+"\"") ;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sTooltipText)) )
         {
            context.WriteHtmlText( " title=\"") ;
            context.WriteHtmlText( sTooltipText) ;
            context.WriteHtmlText( "\"") ;
         }
         context.WriteHtmlText( sTags+GXUtil.HtmlEndTag( HTMLElement.INPUT)) ;
         context.WriteHtmlText( sCaption) ;
         context.WriteHtmlText( "</span>") ;
         if ( nEnabled == 0 )
         {
            context.WriteHtmlText( "<script type=\"text/javascript\">gx.fn.disableCtrl(\""+sCtrlName+"\");</script>") ;
         }
      }

      static public void gx_bitmap( IGxContext context ,
                                    String sInternalName ,
                                    String sAccesskey ,
                                    String sImageURL ,
                                    String sThemeName ,
                                    int nVisible ,
                                    int nEnabled ,
                                    String sAlternateText ,
                                    String sTooltipText ,
                                    int nBorderWidth ,
                                    int nAutoresize ,
                                    int nWidth ,
                                    String nWidthUnit ,
                                    int nHeight ,
                                    String nHeightUnit ,
                                    int nVerticalSpace ,
                                    int nHorizontalSpace ,
                                    String sLinkURL ,
                                    String sLinkTarget ,
                                    int nJScriptCode ,
                                    String sUserOnClickCode ,
                                    String sEventName ,
                                    String sStyleString ,
                                    String sClassString ,
                                    String sAlign ,
                                    String sTags ,
                                    String sUseMap ,
                                    String sJsDynCode ,
                                    String sCallerPgm )
      {
         String sEventJsCode ;
         String sCapAKey ;
         sEventJsCode = "" ;
         sCapAKey = GXUtil.AccessKey( sTooltipText) ;
         sTooltipText = GXUtil.AccessKeyCaption( sTooltipText) ;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sCapAKey)) )
         {
            sAccesskey = sCapAKey ;
         }
         sStyleString = sStyleString + ((nVisible!=0) ? "" : ";display:none;") ;
         /* Initialize internal JScript code according to EventNo */
         if ( nJScriptCode == 4 )
         {
            sEventJsCode = sJsDynCode ;
         }
         else if ( nJScriptCode == 1 )
         {
            sEventJsCode = "gx.fn.closeWindow();" + "return false;" ;
         }
         else if ( nJScriptCode == 2 )
         {
            sEventJsCode = "ClearForm( this.form);" + "return false;" ;
         }
         else if ( nJScriptCode == 3 )
         {
            sEventJsCode = "gx.util.help(" + "'" + context.convertURL( "Help/"+"Spanish/"+StringUtil.Lower( sCallerPgm)) + "');" + "return false;" ;
         }
         else if ( nJScriptCode == 7 )
         {
            sEventJsCode = "" + "gx.evt.execCliEvt(" + sEventName + ",this);" ;
         }
         else if ( nJScriptCode == 6 )
         {
            sEventJsCode = "gx.evt.execEvt('" + sEventName + "',this);" ;
         }
         else if ( nJScriptCode == 5 )
         {
            sEventJsCode = "gx.evt.execEvt('" + sEventName + "',this);" ;
         }
         else if ( nJScriptCode == 0 )
         {
            sEventJsCode = "" ;
         }
         else
         {
            sEventJsCode = "" ;
         }
         if ( StringUtil.StrCmp(sEventJsCode, "") != 0 )
         {
            context.WriteHtmlText( "<input type=\"image\" src=\"") ;
            context.WriteHtmlText( context.convertURL( sImageURL)) ;
            context.WriteHtmlText( "\" name=\"") ;
            context.WriteHtmlText( sInternalName) ;
            context.WriteHtmlText( "\"") ;
            GxWebStd.gx_on_js_event( context, "onclick", sEventJsCode+"return false;");
            if ( nEnabled == 0 )
            {
               context.WriteHtmlText( " disabled=\"disabled\" ") ;
            }
         }
         else
         {
            if ( ( nEnabled != 0 ) && ( StringUtil.StrCmp(sLinkURL, "") != 0 ) )
            {
               GxWebStd.gx_start_js_anchor( context, sEventJsCode, sUserOnClickCode, sLinkURL, sLinkTarget);
            }
            context.WriteHtmlText( "<img src=\""+context.convertURL( sImageURL)+"\"") ;
         }
         if ( StringUtil.Len( sAccesskey) != 0 )
         {
            context.WriteHtmlText( " accesskey=\"") ;
            context.WriteHtmlText( sAccesskey) ;
            context.WriteHtmlText( "\"") ;
         }
         context.WriteHtmlText( " id=\"") ;
         context.WriteHtmlText( sInternalName) ;
         context.WriteHtmlText( "\"") ;
         if ( ! (0==nVerticalSpace) )
         {
            context.WriteHtmlText( " vspace=\"") ;
            context.WriteHtmlText( StringUtil.LTrim( StringUtil.Str( (decimal)(nVerticalSpace), 10, 0))) ;
            context.WriteHtmlText( "\"") ;
         }
         if ( ! (0==nHorizontalSpace) )
         {
            context.WriteHtmlText( " hspace=\"") ;
            context.WriteHtmlText( StringUtil.LTrim( StringUtil.Str( (decimal)(nHorizontalSpace), 10, 0))) ;
            context.WriteHtmlText( "\"") ;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sAlign)) )
         {
            context.WriteHtmlText( " align=\"") ;
            context.WriteHtmlText( StringUtil.LTrim( sAlign)) ;
            context.WriteHtmlText( "\"") ;
         }
         if ( ( StringUtil.Len( sClassString) == 0 ) || ( nBorderWidth > 0 ) )
         {
            context.WriteHtmlText( " border=\"") ;
            context.WriteHtmlText( StringUtil.Str( (decimal)(nBorderWidth), 3, 0)) ;
            context.WriteHtmlText( "\"") ;
            if ( StringUtil.Len( sClassString) > 0 )
            {
               sStyleString = sStyleString + ";border-width: " + StringUtil.Str( (decimal)(nBorderWidth), 3, 0) ;
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( sEventJsCode)) || ! String.IsNullOrEmpty(StringUtil.RTrim( sAlternateText)) )
         {
            context.WriteHtmlText( " alt=\"") ;
            context.WriteHtmlText( sAlternateText) ;
            context.WriteHtmlText( "\"") ;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sTooltipText)) )
         {
            context.WriteHtmlText( " title=\"") ;
            context.WriteHtmlText( sTooltipText) ;
            context.WriteHtmlText( "\"") ;
         }
         if ( nWidth > 0 )
         {
            sStyleString = sStyleString + ";width: " + StringUtil.LTrim( StringUtil.Str( (decimal)(nWidth), 10, 0)) + nWidthUnit ;
         }
         if ( nHeight > 0 )
         {
            sStyleString = sStyleString + ";height: " + StringUtil.LTrim( StringUtil.Str( (decimal)(nHeight), 10, 0)) + nHeightUnit ;
         }
         GxWebStd.ClassAttribute( context, sClassString);
         GxWebStd.StyleAttribute( context, sStyleString);
         context.WriteHtmlText( sTags) ;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sUseMap)) )
         {
            context.WriteHtmlText( " usemap=\"") ;
            context.WriteHtmlText( sUseMap) ;
            context.WriteHtmlText( "\"") ;
         }
         context.WriteHtmlText( GXUtil.HtmlEndTag( HTMLElement.INPUT)) ;
         if ( StringUtil.StrCmp(sEventJsCode, "") != 0 )
         {
            GxWebStd.gx_ctrl_attribute( context, sInternalName, "jsevent", sUserOnClickCode, false);
         }
         if ( ( nEnabled != 0 ) && ( StringUtil.StrCmp(sLinkURL, "") != 0 ) && ( StringUtil.StrCmp(sEventJsCode, "") == 0 ) )
         {
            GxWebStd.gx_end_js_anchor( context, sEventJsCode, sUserOnClickCode, sLinkURL);
         }
      }

      static public void gx_label_ctrl( IGxContext context ,
                                        String sInternalName ,
                                        int nVisible ,
                                        int nEnabled ,
                                        short nFormat ,
                                        String sCaption ,
                                        String sTooltipText ,
                                        String sLinkURL ,
                                        String sLinkTarget ,
                                        int nJScriptCode ,
                                        String sUserOnClickCode ,
                                        String sEventName ,
                                        String sTags ,
                                        String sClassString ,
                                        String sCallerPgm )
      {
         String sEventJsCode ;
         String sStyle ;
         sTooltipText = ((StringUtil.StrCmp(sTooltipText, "")==0) ? "" : " title=\""+sTooltipText+"\"") ;
         if ( nFormat == 1 )
         {
            /* HTML Format */
            sStyle = ((nVisible!=0) ? ";display:inline" : ";display:none;") + sTags ;
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, sClassString);
            GxWebStd.StyleAttribute( context, sStyle);
            context.WriteHtmlText( " id=\""+sInternalName+"\" "+sTooltipText) ;
            context.WriteHtmlText( ">") ;
         }
         else if ( nFormat != 2 )
         {
            sStyle = ((nVisible!=0) ? "" : ";display:none;") + sTags ;
            context.WriteHtmlText( "<span") ;
            GxWebStd.ClassAttribute( context, sClassString);
            GxWebStd.StyleAttribute( context, sStyle);
            context.WriteHtmlText( " id=\""+sInternalName+"\" "+sTooltipText) ;
            context.WriteHtmlText( ">") ;
         }
         if ( nEnabled != 0 )
         {
            /* Initialize internal JScript code according to EventNo */
            if ( nJScriptCode == 1 )
            {
               sEventJsCode = "gx.fn.closeWindow();" ;
            }
            else if ( nJScriptCode == 2 )
            {
               sEventJsCode = "ClearForm( this.form);" ;
            }
            else if ( nJScriptCode == 3 )
            {
               sEventJsCode = "gx.util.help(" + "'" + context.convertURL( "Help/"+"Spanish/"+StringUtil.Lower( sCallerPgm)) + "');" ;
            }
            else if ( nJScriptCode == 7 )
            {
               sEventJsCode = "" + "gx.evt.execCliEvt(" + sEventName + ",this);" ;
            }
            else if ( nJScriptCode == 6 )
            {
               sEventJsCode = "gx.evt.execEvt('" + sEventName + "',this);" ;
            }
            else if ( nJScriptCode == 5 )
            {
               sEventJsCode = "gx.evt.execEvt('" + sEventName + "',this);" ;
            }
            else if ( nJScriptCode == 0 )
            {
               sEventJsCode = "" ;
            }
            else
            {
               sEventJsCode = "" ;
            }
            GxWebStd.gx_start_js_anchor( context, sEventJsCode, sUserOnClickCode, sLinkURL, sLinkTarget);
         }
         else
         {
            sEventJsCode = "" ;
         }
         if ( nFormat == 0 )
         {
            /* Text Format */
            context.SendWebValue( sCaption) ;
         }
         else
         {
            if ( nFormat == 3 )
            {
               /* Text with meaningful spaces */
               context.SendWebValueSpace( sCaption) ;
            }
            else if ( ( nFormat != 2 ) || ( nVisible != 0 ) )
            {
               context.WriteHtmlText( sCaption) ;
            }
         }
         if ( nEnabled != 0 )
         {
            GxWebStd.gx_end_js_anchor( context, sEventJsCode, sUserOnClickCode, sLinkURL);
         }
         if ( nFormat == 1 )
         {
            context.WriteHtmlText( "</div>") ;
         }
         else if ( nFormat != 2 )
         {
            context.WriteHtmlText( "</span>") ;
         }
         if ( ( nFormat != 0 ) && ( nFormat != 2 ) )
         {
            GxWebStd.gx_ctrl_attribute( context, sInternalName, "gxformat", StringUtil.Str( (decimal)(nFormat), 1, 0), false);
         }
         if ( ( nFormat == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( sEventJsCode)) || ! String.IsNullOrEmpty(StringUtil.RTrim( sUserOnClickCode)) || ! String.IsNullOrEmpty(StringUtil.RTrim( sLinkURL)) ) )
         {
            GxWebStd.gx_ctrl_attribute( context, sInternalName, "gxlink", "1", false);
         }
      }

      static public void gx_start_js_anchor( IGxContext context ,
                                             String sGXOnClickCode ,
                                             String sUserOnClickCode ,
                                             String sLinkURL ,
                                             String sLinkTarget )
      {
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sUserOnClickCode)) )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sGXOnClickCode)) )
            {
               context.WriteHtmlText( "<a href=\"javascript:if( ") ;
               context.WriteHtmlText( sUserOnClickCode) ;
               context.WriteHtmlText( ") {") ;
               context.WriteHtmlText( sGXOnClickCode) ;
               context.WriteHtmlText( "}\">") ;
            }
            else
            {
               context.WriteHtmlText( "<a href=\"javascript:") ;
               context.WriteHtmlText( sUserOnClickCode) ;
               context.WriteHtmlText( "\">") ;
            }
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sGXOnClickCode)) )
            {
               context.WriteHtmlText( "<a href=\"javascript:") ;
               context.WriteHtmlText( sGXOnClickCode) ;
               context.WriteHtmlText( "\">") ;
            }
            else
            {
               GxWebStd.gx_link_start( context, sLinkURL, sLinkTarget);
            }
         }
      }

      static public void gx_end_js_anchor( IGxContext context ,
                                           String sGXOnClickCode ,
                                           String sUserOnClickCode ,
                                           String sLinkURL )
      {
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( sGXOnClickCode)) && String.IsNullOrEmpty(StringUtil.RTrim( sUserOnClickCode)) ) )
         {
            context.WriteHtmlText( "</a>") ;
         }
         else
         {
            GxWebStd.gx_link_end( context, sLinkURL);
         }
      }

      static public bool gx_redirect( IGxContext context )
      {
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( context.wjLoc)) )
         {
            context.Redirect( context.wjLoc );
            context.DispatchAjaxCommands();
            return true ;
         }
         else if ( context.nUserReturn == 1 )
         {
            if ( context.isAjaxRequest( ) )
            {
               context.ajax_rsp_command_close();
               context.DispatchAjaxCommands();
            }
            else
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetReferer( ))) )
               {
                  context.WriteHtmlText( GXUtil.HtmlDocType( )) ;
                  context.WriteHtmlText( "<html><head><title>Close window</title>") ;
                  context.AddJavascriptSource("gxgral.js", "?34981");
                  context.WriteHtmlText( "</head><body><script type=\"text/javascript\">gx.evt.execLoad=false;gx.fn.closeWindow('") ;
                  context.WriteHtmlText( context.getWebReturnParmsJS( )) ;
                  context.WriteHtmlText( "');</script></body></html>") ;
               }
               else
               {
                  context.Redirect( context.GetReferer( ) );
                  context.WindowClosed();
               }
            }
            return true ;
         }
         else
         {
            return false ;
         }
      }

      static public void gx_table_start( IGxContext context ,
                                         String sCtrlName ,
                                         String sHTMLid ,
                                         String sHTMLTags ,
                                         String sClassString ,
                                         int nBorder ,
                                         String sAlign ,
                                         String sTooltiptext ,
                                         int nCellpadding ,
                                         int nCellspacing ,
                                         String sStyleString ,
                                         String sRules ,
                                         int nParentIsFreeStyle )
      {
         context.WriteHtmlText( "<table") ;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sCtrlName)) )
         {
            context.WriteHtmlText( " id=\""+sHTMLid+"\"") ;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sHTMLTags)) )
         {
            context.WriteHtmlText( sHTMLTags) ;
         }
         if ( StringUtil.StrCmp(sAlign, "") != 0 )
         {
            if ( StringUtil.StrCmp(sAlign, "center") != 0 )
            {
               sStyleString = "float:" + sAlign + ";" + sStyleString ;
            }
            else
            {
               context.WriteHtmlText( " align=\"") ;
               context.WriteHtmlText( sAlign) ;
               context.WriteHtmlText( "\"") ;
            }
         }
         GxWebStd.ClassAttribute( context, sClassString);
         if ( ! (0==nBorder) )
         {
            context.WriteHtmlText( " border=\"") ;
            context.WriteHtmlText( StringUtil.Str( (decimal)(nBorder), 3, 0)) ;
            context.WriteHtmlText( "\"") ;
         }
         context.WriteHtmlText( " cellpadding=\"") ;
         context.WriteHtmlText( StringUtil.LTrim( StringUtil.Str( (decimal)(nCellpadding), 10, 0))) ;
         context.WriteHtmlText( "\"") ;
         context.WriteHtmlText( " cellspacing=\"") ;
         context.WriteHtmlText( StringUtil.LTrim( StringUtil.Str( (decimal)(nCellspacing), 10, 0))) ;
         context.WriteHtmlText( "\"") ;
         if ( ( StringUtil.StrCmp(sRules, "") != 0 ) && ( StringUtil.StrCmp(sRules, "none") != 0 ) )
         {
            context.WriteHtmlText( " rules=\"") ;
            context.WriteHtmlText( sRules) ;
            context.WriteHtmlText( "\"") ;
         }
         if ( StringUtil.StrCmp(sTooltiptext, "") != 0 )
         {
            context.WriteHtmlText( " title=\"") ;
            context.WriteHtmlText( sTooltiptext) ;
            context.WriteHtmlText( "\"") ;
         }
         if ( nParentIsFreeStyle == 0 )
         {
            GxWebStd.StyleAttribute( context, sStyleString);
         }
         context.WriteHtmlText( ">") ;
      }

      static public void gx_html_headers( IGxContext context ,
                                          int nContentType ,
                                          String sCacheCtrl ,
                                          String sCacheExp ,
                                          GXRadio radrMeta ,
                                          GXRadio radrMetaequiv ,
                                          String sIEMode )
      {
         short wbTemp ;
         short idxLst ;
         bool addContentType ;
         GxWebStd.set_html_headers( context, nContentType, sCacheCtrl, sCacheExp);
         if ( nContentType == 0 )
         {
            context.WriteHtmlTextNl( GXUtil.HtmlDocType( )) ;
            context.WriteHtmlTextNl( "<html>") ;
            context.WriteHtmlTextNl( "<head>") ;
            idxLst = 1 ;
            while ( idxLst <= radrMeta.ItemCount )
            {
               context.WriteHtmlText( "<meta name=\""+StringUtil.RTrim( radrMeta.getItemValue(idxLst))+"\" content=\"") ;
               context.SendWebValue( StringUtil.RTrim( radrMeta.getItemText(idxLst))) ;
               context.WriteHtmlTextNl( "\""+GXUtil.HtmlEndTag( HTMLElement.META)) ;
               idxLst = (short)(idxLst+1) ;
            }
            context.WriteHtmlTextNl( "<meta http-equiv=\"Page-Enter\" content=\"BlendTrans(Duration=0.1)\""+GXUtil.HtmlEndTag( HTMLElement.META)) ;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sIEMode)) && ( context.GetBrowserType( ) == 1 ) && ( StringUtil.StrCmp(StringUtil.Left( context.GetBrowserVersion( ), 1), "8") == 0 ) )
            {
               context.WriteHtmlTextNl( "<meta http-equiv=\"X-UA-Compatible\" content=\""+sIEMode+"\""+GXUtil.HtmlEndTag( HTMLElement.META)) ;
            }
            idxLst = 1 ;
            addContentType = true ;
            while ( idxLst <= radrMetaequiv.ItemCount )
            {
               if ( StringUtil.StrCmp(StringUtil.Lower( radrMetaequiv.getItemValue(idxLst)), "content-type") == 0 )
               {
                  addContentType = false ;
                  wbTemp = context.ResponseContentType( radrMetaequiv.getItemText(idxLst)) ;
               }
               idxLst = (short)(idxLst+1) ;
            }
            if ( addContentType )
            {
               context.WriteHtmlTextNl( "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\""+GXUtil.HtmlEndTag( HTMLElement.META)) ;
            }
            idxLst = 1 ;
            while ( idxLst <= radrMetaequiv.ItemCount )
            {
               context.WriteHtmlText( "<meta http-equiv=\""+StringUtil.RTrim( radrMetaequiv.getItemValue(idxLst))+"\" content=\"") ;
               context.SendWebValue( StringUtil.RTrim( radrMetaequiv.getItemText(idxLst))) ;
               context.WriteHtmlTextNl( "\""+GXUtil.HtmlEndTag( HTMLElement.META)) ;
               idxLst = (short)(idxLst+1) ;
            }
         }
      }

      static public void set_html_headers( IGxContext context ,
                                           int nContentType ,
                                           String sCacheCtrl ,
                                           String sCacheExp )
      {
         short wbTemp ;
         if ( nContentType == 1 )
         {
            wbTemp = context.ResponseContentType( "text/vnd.wap.wml") ;
            context.HttpContext.Response.ContentEncoding=System.Text.Encoding.GetEncoding( "iso-8859-1");
         }
         else
         {
            wbTemp = context.ResponseContentType( "text/html") ;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( sCacheCtrl)) )
         {
            wbTemp = context.SetHeader( "pragma", "no-cache") ;
            wbTemp = context.SetHeader( "Cache-Control", "no-cache, no-store") ;
         }
         else
         {
            wbTemp = context.SetHeader( "Cache-Control", sCacheCtrl) ;
            wbTemp = context.SetHeader( "Cache-Control", sCacheExp) ;
         }
      }

      static public void gx_html_textarea( IGxContext context ,
                                           String sCtrlName ,
                                           String sValue ,
                                           int nVisible ,
                                           int nEnabled ,
                                           int nRTEnabled ,
                                           int nWidth ,
                                           String sWidthUnit ,
                                           int nHeight ,
                                           String sHeightUnit ,
                                           String sStyleString ,
                                           String sClassString ,
                                           String sLength ,
                                           String sTags ,
                                           int nAutoResize ,
                                           short nFormat ,
                                           String sLinkURL ,
                                           String sLinkTarget ,
                                           bool bSendHidden ,
                                           String sCallerPgm )
      {
         sStyleString = sStyleString + ((nVisible==0)||((nEnabled==0)&&(nRTEnabled==1)) ? ";display:none;" : "") ;
         if ( ( nRTEnabled != 0 ) || ( nEnabled != 0 ) )
         {
            context.WriteHtmlText( "<textarea ") ;
            if ( StringUtil.StrCmp(sWidthUnit, "chr") == 0 )
            {
               context.WriteHtmlText( " cols=\""+nWidth+"\" ") ;
            }
            else
            {
               sStyleString = sStyleString + ";width:" + nWidth + sWidthUnit ;
            }
            if ( StringUtil.StrCmp(sHeightUnit, "row") == 0 )
            {
               context.WriteHtmlText( " rows=\""+nHeight+"\" ") ;
            }
            else
            {
               sStyleString = sStyleString + ";height:" + nHeight + sHeightUnit ;
            }
            context.WriteHtmlText( " name=\""+sCtrlName+"\""+" id=\""+sCtrlName+"\" "+sTags) ;
            GxWebStd.ClassAttribute( context, sClassString);
            GxWebStd.StyleAttribute( context, sStyleString);
            context.WriteHtmlTextNl( ">") ;
            context.WriteHtmlText( sValue+"</textarea>") ;
         }
         if ( nEnabled == 0 )
         {
            sStyleString = ((nVisible==0) ? ";display:none;" : "") ;
            sStyleString = sStyleString + ((nAutoResize==0) ? ";overflow:hidden;" : "") ;
            if ( ( nRTEnabled == 0 ) && bSendHidden )
            {
               GxWebStd.gx_hidden_field( context, sCtrlName, sValue);
            }
            if ( ( StringUtil.Len( sClassString) != 0 ) && ( StringUtil.StringSearch( sClassString, "Readonly", 1) != 1 ) )
            {
               sClassString = "Readonly" + sClassString ;
            }
            context.WriteHtmlText( "<span") ;
            GxWebStd.ClassAttribute( context, sClassString);
            GxWebStd.StyleAttribute( context, sStyleString);
            context.WriteHtmlText( " id=\"span_"+sCtrlName+"\"") ;
            context.WriteHtmlText( ">") ;
            GxWebStd.gx_link_start( context, sLinkURL, sLinkTarget);
            if ( nFormat == 0 )
            {
               context.SendWebValueEnter( sValue) ;
            }
            else
            {
               if ( nFormat == 3 )
               {
                  context.SendWebValueComplete( sValue) ;
               }
               else
               {
                  context.WriteHtmlText( sValue) ;
               }
            }
            GxWebStd.gx_link_end( context, sLinkURL);
            context.WriteHtmlText( "</span>") ;
         }
      }

      static public void StyleAttribute( IGxContext context ,
                                         String sStyle )
      {
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sStyle)) )
         {
            context.WriteHtmlText( " style=\"") ;
            context.WriteHtmlText( sStyle) ;
            context.WriteHtmlText( "\" ") ;
         }
      }

      static public void ClassAttribute( IGxContext context ,
                                         String sClass )
      {
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( sClass)) )
         {
            context.WriteHtmlText( " class=\"") ;
            context.WriteHtmlText( sClass) ;
            context.WriteHtmlText( "\" ") ;
         }
      }

   }

}
