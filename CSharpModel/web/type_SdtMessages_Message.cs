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
using System.Reflection;
using System.Xml.Serialization;
using System.Data.SqlTypes;
namespace GeneXus.Programs {
   [Serializable]
   public class SdtMessages_Message : GxUserType, System.Web.SessionState.IRequiresSessionState
   {
      public SdtMessages_Message( )
      {
         constructorCallingAssembly = Assembly.GetCallingAssembly() ;
         initialize();
      }

      public SdtMessages_Message( IGxContext context )
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
               if ( StringUtil.StrCmp(oReader.LocalName, "Id") == 0 )
               {
                  gxTv_SdtMessages_Message_Id = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "Type") == 0 )
               {
                  gxTv_SdtMessages_Message_Type = (short)(NumberUtil.Val( oReader.Value, ".")) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "Description") == 0 )
               {
                  gxTv_SdtMessages_Message_Description = oReader.Value ;
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
            sName = "Messages.Message" ;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( sNameSpace)) )
         {
            sNameSpace = "Genexus" ;
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
         oWriter.WriteElement("Id", StringUtil.RTrim( gxTv_SdtMessages_Message_Id));
         oWriter.WriteElement("Type", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtMessages_Message_Type), 2, 0)));
         oWriter.WriteElement("Description", StringUtil.RTrim( gxTv_SdtMessages_Message_Description));
         oWriter.WriteEndElement();
         return  ;
      }

      public override void ToJSON( )
      {
         AddObjectProperty("Id", (Object)(gxTv_SdtMessages_Message_Id));
         AddObjectProperty("Type", (Object)(gxTv_SdtMessages_Message_Type));
         AddObjectProperty("Description", (Object)(gxTv_SdtMessages_Message_Description));
         return  ;
      }

      public String gxTpr_Id
      {
         get {
            return gxTv_SdtMessages_Message_Id ;
         }

         set {
            gxTv_SdtMessages_Message_Id = (String)(value) ;
         }

      }

      public void gxTv_SdtMessages_Message_Id_SetNull( )
      {
         gxTv_SdtMessages_Message_Id = "" ;
         return  ;
      }

      public bool gxTv_SdtMessages_Message_Id_IsNull( )
      {
         return false ;
      }

      public short gxTpr_Type
      {
         get {
            return gxTv_SdtMessages_Message_Type ;
         }

         set {
            gxTv_SdtMessages_Message_Type = (short)(value) ;
         }

      }

      public void gxTv_SdtMessages_Message_Type_SetNull( )
      {
         gxTv_SdtMessages_Message_Type = 0 ;
         return  ;
      }

      public bool gxTv_SdtMessages_Message_Type_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Description
      {
         get {
            return gxTv_SdtMessages_Message_Description ;
         }

         set {
            gxTv_SdtMessages_Message_Description = (String)(value) ;
         }

      }

      public void gxTv_SdtMessages_Message_Description_SetNull( )
      {
         gxTv_SdtMessages_Message_Description = "" ;
         return  ;
      }

      public bool gxTv_SdtMessages_Message_Description_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtMessages_Message_Id = "" ;
         gxTv_SdtMessages_Message_Description = "" ;
         sTagName = "" ;
         return  ;
      }

      private short gxTv_SdtMessages_Message_Type ;
      private short readOk ;
      private short nOutParmCount ;
      private String sTagName ;
      private String gxTv_SdtMessages_Message_Id ;
      private String gxTv_SdtMessages_Message_Description ;
      private Assembly constructorCallingAssembly ;
      private IGxContext context ;
   }

}
