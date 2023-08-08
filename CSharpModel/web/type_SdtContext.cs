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
   public class SdtContext : GxUserType
   {
      public SdtContext( )
      {
         constructorCallingAssembly = Assembly.GetCallingAssembly() ;
         initialize();
      }

      public SdtContext( IGxContext context )
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
               if ( StringUtil.StrCmp(oReader.LocalName, "User") == 0 )
               {
                  gxTv_SdtContext_User = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "CompanyCode") == 0 )
               {
                  gxTv_SdtContext_Companycode = (short)(NumberUtil.Val( oReader.Value, ".")) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "Profile") == 0 )
               {
                  gxTv_SdtContext_Profile = oReader.Value ;
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
            sName = "Context" ;
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
         oWriter.WriteElement("User", StringUtil.RTrim( gxTv_SdtContext_User));
         oWriter.WriteElement("CompanyCode", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtContext_Companycode), 4, 0)));
         oWriter.WriteElement("Profile", StringUtil.RTrim( gxTv_SdtContext_Profile));
         oWriter.WriteEndElement();
         return  ;
      }

      public override void ToJSON( )
      {
         AddObjectProperty("User", (Object)(gxTv_SdtContext_User));
         AddObjectProperty("CompanyCode", (Object)(gxTv_SdtContext_Companycode));
         AddObjectProperty("Profile", (Object)(gxTv_SdtContext_Profile));
         return  ;
      }

      public String gxTpr_User
      {
         get {
            return gxTv_SdtContext_User ;
         }

         set {
            gxTv_SdtContext_User = (String)(value) ;
         }

      }

      public void gxTv_SdtContext_User_SetNull( )
      {
         gxTv_SdtContext_User = "" ;
         return  ;
      }

      public bool gxTv_SdtContext_User_IsNull( )
      {
         return false ;
      }

      public short gxTpr_Companycode
      {
         get {
            return gxTv_SdtContext_Companycode ;
         }

         set {
            gxTv_SdtContext_Companycode = (short)(value) ;
         }

      }

      public void gxTv_SdtContext_Companycode_SetNull( )
      {
         gxTv_SdtContext_Companycode = 0 ;
         return  ;
      }

      public bool gxTv_SdtContext_Companycode_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Profile
      {
         get {
            return gxTv_SdtContext_Profile ;
         }

         set {
            gxTv_SdtContext_Profile = (String)(value) ;
         }

      }

      public void gxTv_SdtContext_Profile_SetNull( )
      {
         gxTv_SdtContext_Profile = "" ;
         return  ;
      }

      public bool gxTv_SdtContext_Profile_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtContext_User = "" ;
         gxTv_SdtContext_Profile = "" ;
         sTagName = "" ;
         return  ;
      }

      protected short gxTv_SdtContext_Companycode ;
      protected short readOk ;
      protected short nOutParmCount ;
      protected String gxTv_SdtContext_User ;
      protected String gxTv_SdtContext_Profile ;
      protected String sTagName ;
      protected Assembly constructorCallingAssembly ;
      protected IGxContext context ;
   }

}
