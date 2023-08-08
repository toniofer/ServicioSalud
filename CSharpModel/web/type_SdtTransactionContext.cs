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
   public class SdtTransactionContext : GxUserType
   {
      public SdtTransactionContext( )
      {
         constructorCallingAssembly = Assembly.GetCallingAssembly() ;
         initialize();
      }

      public SdtTransactionContext( IGxContext context )
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
               if ( StringUtil.StrCmp(oReader.LocalName, "CallerObject") == 0 )
               {
                  gxTv_SdtTransactionContext_Callerobject = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "CallerOnDelete") == 0 )
               {
                  gxTv_SdtTransactionContext_Callerondelete = (bool)(Convert.ToBoolean(((StringUtil.StrCmp(oReader.Value, "true")==0)||(StringUtil.StrCmp(oReader.Value, "1")==0) ? 1 : 0))) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "CallerURL") == 0 )
               {
                  gxTv_SdtTransactionContext_Callerurl = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "TransactionName") == 0 )
               {
                  gxTv_SdtTransactionContext_Transactionname = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "Attributes") == 0 )
               {
                  if ( gxTv_SdtTransactionContext_Attributes == null )
                  {
                     gxTv_SdtTransactionContext_Attributes = new GxObjectCollection( context, "TransactionContext.Attribute", "taller041", "SdtTransactionContext_Attribute", "GeneXus.Programs");
                  }
                  if ( oReader.IsSimple == 0 )
                  {
                     GXSoapError = gxTv_SdtTransactionContext_Attributes.readxmlcollection(oReader, "Attributes", "Attribute") ;
                  }
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
            sName = "TransactionContext" ;
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
         oWriter.WriteElement("CallerObject", StringUtil.RTrim( gxTv_SdtTransactionContext_Callerobject));
         oWriter.WriteElement("CallerOnDelete", StringUtil.RTrim( StringUtil.BoolToStr( gxTv_SdtTransactionContext_Callerondelete)));
         oWriter.WriteElement("CallerURL", StringUtil.RTrim( gxTv_SdtTransactionContext_Callerurl));
         oWriter.WriteElement("TransactionName", StringUtil.RTrim( gxTv_SdtTransactionContext_Transactionname));
         if ( gxTv_SdtTransactionContext_Attributes != null )
         {
            String sNameSpace1 ;
            if ( StringUtil.StrCmp(sNameSpace, "taller041") == 0 )
            {
               sNameSpace1 = "[*:nosend]" + "taller041" ;
            }
            else
            {
               sNameSpace1 = "taller041" ;
            }
            gxTv_SdtTransactionContext_Attributes.writexmlcollection(oWriter, "Attributes", sNameSpace1, "Attribute", sNameSpace1);
         }
         oWriter.WriteEndElement();
         return  ;
      }

      public override void ToJSON( )
      {
         AddObjectProperty("CallerObject", (Object)(gxTv_SdtTransactionContext_Callerobject));
         AddObjectProperty("CallerOnDelete", (Object)(gxTv_SdtTransactionContext_Callerondelete));
         AddObjectProperty("CallerURL", (Object)(gxTv_SdtTransactionContext_Callerurl));
         AddObjectProperty("TransactionName", (Object)(gxTv_SdtTransactionContext_Transactionname));
         if ( gxTv_SdtTransactionContext_Attributes != null )
         {
            AddObjectProperty("Attributes", (Object)(gxTv_SdtTransactionContext_Attributes));
         }
         return  ;
      }

      public String gxTpr_Callerobject
      {
         get {
            return gxTv_SdtTransactionContext_Callerobject ;
         }

         set {
            gxTv_SdtTransactionContext_Callerobject = (String)(value) ;
         }

      }

      public void gxTv_SdtTransactionContext_Callerobject_SetNull( )
      {
         gxTv_SdtTransactionContext_Callerobject = "" ;
         return  ;
      }

      public bool gxTv_SdtTransactionContext_Callerobject_IsNull( )
      {
         return false ;
      }

      public bool gxTpr_Callerondelete
      {
         get {
            return gxTv_SdtTransactionContext_Callerondelete ;
         }

         set {
            gxTv_SdtTransactionContext_Callerondelete = value ;
         }

      }

      public void gxTv_SdtTransactionContext_Callerondelete_SetNull( )
      {
         gxTv_SdtTransactionContext_Callerondelete = false ;
         return  ;
      }

      public bool gxTv_SdtTransactionContext_Callerondelete_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Callerurl
      {
         get {
            return gxTv_SdtTransactionContext_Callerurl ;
         }

         set {
            gxTv_SdtTransactionContext_Callerurl = (String)(value) ;
         }

      }

      public void gxTv_SdtTransactionContext_Callerurl_SetNull( )
      {
         gxTv_SdtTransactionContext_Callerurl = "" ;
         return  ;
      }

      public bool gxTv_SdtTransactionContext_Callerurl_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Transactionname
      {
         get {
            return gxTv_SdtTransactionContext_Transactionname ;
         }

         set {
            gxTv_SdtTransactionContext_Transactionname = (String)(value) ;
         }

      }

      public void gxTv_SdtTransactionContext_Transactionname_SetNull( )
      {
         gxTv_SdtTransactionContext_Transactionname = "" ;
         return  ;
      }

      public bool gxTv_SdtTransactionContext_Transactionname_IsNull( )
      {
         return false ;
      }

      public IGxCollection gxTpr_Attributes
      {
         get {
            if ( gxTv_SdtTransactionContext_Attributes == null )
            {
               gxTv_SdtTransactionContext_Attributes = new GxObjectCollection( context, "TransactionContext.Attribute", "taller041", "SdtTransactionContext_Attribute", "GeneXus.Programs");
            }
            return gxTv_SdtTransactionContext_Attributes ;
         }

         set {
            gxTv_SdtTransactionContext_Attributes = value ;
         }

      }

      public void gxTv_SdtTransactionContext_Attributes_SetNull( )
      {
         gxTv_SdtTransactionContext_Attributes = null ;
         return  ;
      }

      public bool gxTv_SdtTransactionContext_Attributes_IsNull( )
      {
         if ( gxTv_SdtTransactionContext_Attributes == null )
         {
            return true ;
         }
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtTransactionContext_Callerobject = "" ;
         gxTv_SdtTransactionContext_Callerurl = "" ;
         gxTv_SdtTransactionContext_Transactionname = "" ;
         sTagName = "" ;
         return  ;
      }

      protected short readOk ;
      protected short nOutParmCount ;
      protected String sTagName ;
      protected bool gxTv_SdtTransactionContext_Callerondelete ;
      protected String gxTv_SdtTransactionContext_Callerobject ;
      protected String gxTv_SdtTransactionContext_Callerurl ;
      protected String gxTv_SdtTransactionContext_Transactionname ;
      protected Assembly constructorCallingAssembly ;
      protected IGxContext context ;
      protected IGxCollection gxTv_SdtTransactionContext_Attributes=null ;
   }

}
