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
   public class SdtTabOptions_TabOptionsItem : GxUserType
   {
      public SdtTabOptions_TabOptionsItem( )
      {
         constructorCallingAssembly = Assembly.GetCallingAssembly() ;
         initialize();
      }

      public SdtTabOptions_TabOptionsItem( IGxContext context )
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
               if ( StringUtil.StrCmp(oReader.LocalName, "Code") == 0 )
               {
                  gxTv_SdtTabOptions_TabOptionsItem_Code = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "Description") == 0 )
               {
                  gxTv_SdtTabOptions_TabOptionsItem_Description = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "Link") == 0 )
               {
                  gxTv_SdtTabOptions_TabOptionsItem_Link = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "WebComponent") == 0 )
               {
                  gxTv_SdtTabOptions_TabOptionsItem_Webcomponent = oReader.Value ;
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
            sName = "TabOptions.TabOptionsItem" ;
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
         oWriter.WriteElement("Code", StringUtil.RTrim( gxTv_SdtTabOptions_TabOptionsItem_Code));
         oWriter.WriteElement("Description", StringUtil.RTrim( gxTv_SdtTabOptions_TabOptionsItem_Description));
         oWriter.WriteElement("Link", StringUtil.RTrim( gxTv_SdtTabOptions_TabOptionsItem_Link));
         oWriter.WriteElement("WebComponent", StringUtil.RTrim( gxTv_SdtTabOptions_TabOptionsItem_Webcomponent));
         oWriter.WriteEndElement();
         return  ;
      }

      public override void ToJSON( )
      {
         AddObjectProperty("Code", (Object)(gxTv_SdtTabOptions_TabOptionsItem_Code));
         AddObjectProperty("Description", (Object)(gxTv_SdtTabOptions_TabOptionsItem_Description));
         AddObjectProperty("Link", (Object)(gxTv_SdtTabOptions_TabOptionsItem_Link));
         AddObjectProperty("WebComponent", (Object)(gxTv_SdtTabOptions_TabOptionsItem_Webcomponent));
         return  ;
      }

      public String gxTpr_Code
      {
         get {
            return gxTv_SdtTabOptions_TabOptionsItem_Code ;
         }

         set {
            gxTv_SdtTabOptions_TabOptionsItem_Code = (String)(value) ;
         }

      }

      public void gxTv_SdtTabOptions_TabOptionsItem_Code_SetNull( )
      {
         gxTv_SdtTabOptions_TabOptionsItem_Code = "" ;
         return  ;
      }

      public bool gxTv_SdtTabOptions_TabOptionsItem_Code_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Description
      {
         get {
            return gxTv_SdtTabOptions_TabOptionsItem_Description ;
         }

         set {
            gxTv_SdtTabOptions_TabOptionsItem_Description = (String)(value) ;
         }

      }

      public void gxTv_SdtTabOptions_TabOptionsItem_Description_SetNull( )
      {
         gxTv_SdtTabOptions_TabOptionsItem_Description = "" ;
         return  ;
      }

      public bool gxTv_SdtTabOptions_TabOptionsItem_Description_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Link
      {
         get {
            return gxTv_SdtTabOptions_TabOptionsItem_Link ;
         }

         set {
            gxTv_SdtTabOptions_TabOptionsItem_Link = (String)(value) ;
         }

      }

      public void gxTv_SdtTabOptions_TabOptionsItem_Link_SetNull( )
      {
         gxTv_SdtTabOptions_TabOptionsItem_Link = "" ;
         return  ;
      }

      public bool gxTv_SdtTabOptions_TabOptionsItem_Link_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Webcomponent
      {
         get {
            return gxTv_SdtTabOptions_TabOptionsItem_Webcomponent ;
         }

         set {
            gxTv_SdtTabOptions_TabOptionsItem_Webcomponent = (String)(value) ;
         }

      }

      public void gxTv_SdtTabOptions_TabOptionsItem_Webcomponent_SetNull( )
      {
         gxTv_SdtTabOptions_TabOptionsItem_Webcomponent = "" ;
         return  ;
      }

      public bool gxTv_SdtTabOptions_TabOptionsItem_Webcomponent_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtTabOptions_TabOptionsItem_Code = "" ;
         gxTv_SdtTabOptions_TabOptionsItem_Description = "" ;
         gxTv_SdtTabOptions_TabOptionsItem_Link = "" ;
         gxTv_SdtTabOptions_TabOptionsItem_Webcomponent = "" ;
         sTagName = "" ;
         return  ;
      }

      protected short readOk ;
      protected short nOutParmCount ;
      protected String gxTv_SdtTabOptions_TabOptionsItem_Code ;
      protected String sTagName ;
      protected String gxTv_SdtTabOptions_TabOptionsItem_Description ;
      protected String gxTv_SdtTabOptions_TabOptionsItem_Link ;
      protected String gxTv_SdtTabOptions_TabOptionsItem_Webcomponent ;
      protected Assembly constructorCallingAssembly ;
      protected IGxContext context ;
   }

}
