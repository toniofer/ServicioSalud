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
   public class SdtProgramNames_ProgramName : GxUserType
   {
      public SdtProgramNames_ProgramName( )
      {
         constructorCallingAssembly = Assembly.GetCallingAssembly() ;
         initialize();
      }

      public SdtProgramNames_ProgramName( IGxContext context )
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
               if ( StringUtil.StrCmp(oReader.LocalName, "Name") == 0 )
               {
                  gxTv_SdtProgramNames_ProgramName_Name = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "Description") == 0 )
               {
                  gxTv_SdtProgramNames_ProgramName_Description = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "Link") == 0 )
               {
                  gxTv_SdtProgramNames_ProgramName_Link = oReader.Value ;
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
            sName = "ProgramNames.ProgramName" ;
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
         oWriter.WriteElement("Name", StringUtil.RTrim( gxTv_SdtProgramNames_ProgramName_Name));
         oWriter.WriteElement("Description", StringUtil.RTrim( gxTv_SdtProgramNames_ProgramName_Description));
         oWriter.WriteElement("Link", StringUtil.RTrim( gxTv_SdtProgramNames_ProgramName_Link));
         oWriter.WriteEndElement();
         return  ;
      }

      public override void ToJSON( )
      {
         AddObjectProperty("Name", (Object)(gxTv_SdtProgramNames_ProgramName_Name));
         AddObjectProperty("Description", (Object)(gxTv_SdtProgramNames_ProgramName_Description));
         AddObjectProperty("Link", (Object)(gxTv_SdtProgramNames_ProgramName_Link));
         return  ;
      }

      public String gxTpr_Name
      {
         get {
            return gxTv_SdtProgramNames_ProgramName_Name ;
         }

         set {
            gxTv_SdtProgramNames_ProgramName_Name = (String)(value) ;
         }

      }

      public void gxTv_SdtProgramNames_ProgramName_Name_SetNull( )
      {
         gxTv_SdtProgramNames_ProgramName_Name = "" ;
         return  ;
      }

      public bool gxTv_SdtProgramNames_ProgramName_Name_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Description
      {
         get {
            return gxTv_SdtProgramNames_ProgramName_Description ;
         }

         set {
            gxTv_SdtProgramNames_ProgramName_Description = (String)(value) ;
         }

      }

      public void gxTv_SdtProgramNames_ProgramName_Description_SetNull( )
      {
         gxTv_SdtProgramNames_ProgramName_Description = "" ;
         return  ;
      }

      public bool gxTv_SdtProgramNames_ProgramName_Description_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Link
      {
         get {
            return gxTv_SdtProgramNames_ProgramName_Link ;
         }

         set {
            gxTv_SdtProgramNames_ProgramName_Link = (String)(value) ;
         }

      }

      public void gxTv_SdtProgramNames_ProgramName_Link_SetNull( )
      {
         gxTv_SdtProgramNames_ProgramName_Link = "" ;
         return  ;
      }

      public bool gxTv_SdtProgramNames_ProgramName_Link_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtProgramNames_ProgramName_Name = "" ;
         gxTv_SdtProgramNames_ProgramName_Description = "" ;
         gxTv_SdtProgramNames_ProgramName_Link = "" ;
         sTagName = "" ;
         return  ;
      }

      protected short readOk ;
      protected short nOutParmCount ;
      protected String sTagName ;
      protected String gxTv_SdtProgramNames_ProgramName_Name ;
      protected String gxTv_SdtProgramNames_ProgramName_Description ;
      protected String gxTv_SdtProgramNames_ProgramName_Link ;
      protected Assembly constructorCallingAssembly ;
      protected IGxContext context ;
   }

}
