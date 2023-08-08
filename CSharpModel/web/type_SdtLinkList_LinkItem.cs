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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Data.SqlTypes;
namespace GeneXus.Programs {
   [Serializable]
   public class SdtLinkList_LinkItem : GxUserType
   {
      public SdtLinkList_LinkItem( )
      {
         constructorCallingAssembly = Assembly.GetCallingAssembly() ;
         initialize();
      }

      public SdtLinkList_LinkItem( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetCallingAssembly() ;
         initialize();
      }

      public override short readxml( GXXMLReader oReader ,
                                     String sName )
      {
         short GXSoapError = 1 ;
         sTagName = oReader.Name ;
         if ( oReader.IsSimple == 0 )
         {
            GXSoapError = oReader.Read() ;
            nOutParmCount = 0 ;
            while ( ( ( StringUtil.StrCmp(oReader.Name, sTagName) != 0 ) || ( oReader.NodeType == 1 ) ) && ( GXSoapError > 0 ) )
            {
               readOk = 0 ;
               if ( StringUtil.StrCmp(oReader.LocalName, "Caption") == 0 )
               {
                  gxTv_SdtLinkList_LinkItem_Caption = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "URL") == 0 )
               {
                  gxTv_SdtLinkList_LinkItem_Url = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               nOutParmCount = (short)(nOutParmCount+1) ;
               if ( readOk == 0 )
               {
                  context.sSOAPErrMsg = context.sSOAPErrMsg + "Error reading " + sTagName + StringUtil.NewLine( ) ;
                  GXSoapError = (short)(nOutParmCount*-1) ;
               }
            }
         }
         return GXSoapError ;
      }

      public override void writexml( GXXMLWriter oWriter ,
                                     String sName ,
                                     String sNameSpace )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( sName)) )
         {
            sName = "LinkList.LinkItem" ;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( sNameSpace)) )
         {
            sNameSpace = "taller041" ;
         }
         oWriter.WriteStartElement(sName);
         if ( StringUtil.StrCmp(StringUtil.Left( sNameSpace, 10), "[*:nosend]") != 0 )
         {
            oWriter.WriteAttribute("xmlns", sNameSpace);
         }
         else
         {
            sNameSpace = StringUtil.Right( sNameSpace, (short)(StringUtil.Len( sNameSpace)-10)) ;
         }
         oWriter.WriteElement("Caption", StringUtil.RTrim( gxTv_SdtLinkList_LinkItem_Caption));
         oWriter.WriteElement("URL", StringUtil.RTrim( gxTv_SdtLinkList_LinkItem_Url));
         oWriter.WriteEndElement();
         return  ;
      }

      public override void ToJSON( )
      {
         AddObjectProperty("Caption", (Object)(gxTv_SdtLinkList_LinkItem_Caption));
         AddObjectProperty("URL", (Object)(gxTv_SdtLinkList_LinkItem_Url));
         return  ;
      }

      public String gxTpr_Caption
      {
         get {
            return gxTv_SdtLinkList_LinkItem_Caption ;
         }

         set {
            gxTv_SdtLinkList_LinkItem_Caption = (String)(value) ;
         }

      }

      public void gxTv_SdtLinkList_LinkItem_Caption_SetNull( )
      {
         gxTv_SdtLinkList_LinkItem_Caption = "" ;
         return  ;
      }

      public bool gxTv_SdtLinkList_LinkItem_Caption_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Url
      {
         get {
            return gxTv_SdtLinkList_LinkItem_Url ;
         }

         set {
            gxTv_SdtLinkList_LinkItem_Url = (String)(value) ;
         }

      }

      public void gxTv_SdtLinkList_LinkItem_Url_SetNull( )
      {
         gxTv_SdtLinkList_LinkItem_Url = "" ;
         return  ;
      }

      public bool gxTv_SdtLinkList_LinkItem_Url_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtLinkList_LinkItem_Caption = "" ;
         gxTv_SdtLinkList_LinkItem_Url = "" ;
         sTagName = "" ;
         return  ;
      }

      protected short readOk ;
      protected short nOutParmCount ;
      protected String sTagName ;
      protected String gxTv_SdtLinkList_LinkItem_Caption ;
      protected String gxTv_SdtLinkList_LinkItem_Url ;
      protected Assembly constructorCallingAssembly ;
      protected IGxContext context ;
   }

}
