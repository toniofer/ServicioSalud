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
   public class SdtTransactionContext_Attribute : GxUserType
   {
      public SdtTransactionContext_Attribute( )
      {
         constructorCallingAssembly = Assembly.GetCallingAssembly() ;
         initialize();
      }

      public SdtTransactionContext_Attribute( IGxContext context )
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
               if ( StringUtil.StrCmp(oReader.LocalName, "AttributeName") == 0 )
               {
                  gxTv_SdtTransactionContext_Attribute_Attributename = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "AttributeValue") == 0 )
               {
                  gxTv_SdtTransactionContext_Attribute_Attributevalue = oReader.Value ;
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
            sName = "TransactionContext.Attribute" ;
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
         oWriter.WriteElement("AttributeName", StringUtil.RTrim( gxTv_SdtTransactionContext_Attribute_Attributename));
         oWriter.WriteElement("AttributeValue", StringUtil.RTrim( gxTv_SdtTransactionContext_Attribute_Attributevalue));
         oWriter.WriteEndElement();
         return  ;
      }

      public override void ToJSON( )
      {
         AddObjectProperty("AttributeName", (Object)(gxTv_SdtTransactionContext_Attribute_Attributename));
         AddObjectProperty("AttributeValue", (Object)(gxTv_SdtTransactionContext_Attribute_Attributevalue));
         return  ;
      }

      public String gxTpr_Attributename
      {
         get {
            return gxTv_SdtTransactionContext_Attribute_Attributename ;
         }

         set {
            gxTv_SdtTransactionContext_Attribute_Attributename = (String)(value) ;
         }

      }

      public void gxTv_SdtTransactionContext_Attribute_Attributename_SetNull( )
      {
         gxTv_SdtTransactionContext_Attribute_Attributename = "" ;
         return  ;
      }

      public bool gxTv_SdtTransactionContext_Attribute_Attributename_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Attributevalue
      {
         get {
            return gxTv_SdtTransactionContext_Attribute_Attributevalue ;
         }

         set {
            gxTv_SdtTransactionContext_Attribute_Attributevalue = (String)(value) ;
         }

      }

      public void gxTv_SdtTransactionContext_Attribute_Attributevalue_SetNull( )
      {
         gxTv_SdtTransactionContext_Attribute_Attributevalue = "" ;
         return  ;
      }

      public bool gxTv_SdtTransactionContext_Attribute_Attributevalue_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtTransactionContext_Attribute_Attributename = "" ;
         gxTv_SdtTransactionContext_Attribute_Attributevalue = "" ;
         sTagName = "" ;
         return  ;
      }

      protected short readOk ;
      protected short nOutParmCount ;
      protected String sTagName ;
      protected String gxTv_SdtTransactionContext_Attribute_Attributename ;
      protected String gxTv_SdtTransactionContext_Attribute_Attributevalue ;
      protected Assembly constructorCallingAssembly ;
      protected IGxContext context ;
   }

}
