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
   public class SdtGridState : GxUserType
   {
      public SdtGridState( )
      {
         constructorCallingAssembly = Assembly.GetCallingAssembly() ;
         initialize();
      }

      public SdtGridState( IGxContext context )
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
               if ( StringUtil.StrCmp(oReader.LocalName, "CurrentPage") == 0 )
               {
                  gxTv_SdtGridState_Currentpage = (short)(NumberUtil.Val( oReader.Value, ".")) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "OrderedBy") == 0 )
               {
                  gxTv_SdtGridState_Orderedby = (short)(NumberUtil.Val( oReader.Value, ".")) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "HidingSearch") == 0 )
               {
                  gxTv_SdtGridState_Hidingsearch = (short)(NumberUtil.Val( oReader.Value, ".")) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "FilterValues") == 0 )
               {
                  if ( gxTv_SdtGridState_Filtervalues == null )
                  {
                     gxTv_SdtGridState_Filtervalues = new GxObjectCollection( context, "GridState.FilterValue", "taller041", "SdtGridState_FilterValue", "GeneXus.Programs");
                  }
                  if ( oReader.IsSimple == 0 )
                  {
                     GXSoapError = gxTv_SdtGridState_Filtervalues.readxmlcollection(oReader, "FilterValues", "FilterValue") ;
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
            sName = "GridState" ;
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
         oWriter.WriteElement("CurrentPage", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtGridState_Currentpage), 4, 0)));
         oWriter.WriteElement("OrderedBy", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtGridState_Orderedby), 4, 0)));
         oWriter.WriteElement("HidingSearch", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtGridState_Hidingsearch), 1, 0)));
         if ( gxTv_SdtGridState_Filtervalues != null )
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
            gxTv_SdtGridState_Filtervalues.writexmlcollection(oWriter, "FilterValues", sNameSpace1, "FilterValue", sNameSpace1);
         }
         oWriter.WriteEndElement();
         return  ;
      }

      public override void ToJSON( )
      {
         AddObjectProperty("CurrentPage", (Object)(gxTv_SdtGridState_Currentpage));
         AddObjectProperty("OrderedBy", (Object)(gxTv_SdtGridState_Orderedby));
         AddObjectProperty("HidingSearch", (Object)(gxTv_SdtGridState_Hidingsearch));
         if ( gxTv_SdtGridState_Filtervalues != null )
         {
            AddObjectProperty("FilterValues", (Object)(gxTv_SdtGridState_Filtervalues));
         }
         return  ;
      }

      public short gxTpr_Currentpage
      {
         get {
            return gxTv_SdtGridState_Currentpage ;
         }

         set {
            gxTv_SdtGridState_Currentpage = (short)(value) ;
         }

      }

      public void gxTv_SdtGridState_Currentpage_SetNull( )
      {
         gxTv_SdtGridState_Currentpage = 0 ;
         return  ;
      }

      public bool gxTv_SdtGridState_Currentpage_IsNull( )
      {
         return false ;
      }

      public short gxTpr_Orderedby
      {
         get {
            return gxTv_SdtGridState_Orderedby ;
         }

         set {
            gxTv_SdtGridState_Orderedby = (short)(value) ;
         }

      }

      public void gxTv_SdtGridState_Orderedby_SetNull( )
      {
         gxTv_SdtGridState_Orderedby = 0 ;
         return  ;
      }

      public bool gxTv_SdtGridState_Orderedby_IsNull( )
      {
         return false ;
      }

      public short gxTpr_Hidingsearch
      {
         get {
            return gxTv_SdtGridState_Hidingsearch ;
         }

         set {
            gxTv_SdtGridState_Hidingsearch = (short)(value) ;
         }

      }

      public void gxTv_SdtGridState_Hidingsearch_SetNull( )
      {
         gxTv_SdtGridState_Hidingsearch = 0 ;
         return  ;
      }

      public bool gxTv_SdtGridState_Hidingsearch_IsNull( )
      {
         return false ;
      }

      public IGxCollection gxTpr_Filtervalues
      {
         get {
            if ( gxTv_SdtGridState_Filtervalues == null )
            {
               gxTv_SdtGridState_Filtervalues = new GxObjectCollection( context, "GridState.FilterValue", "taller041", "SdtGridState_FilterValue", "GeneXus.Programs");
            }
            return gxTv_SdtGridState_Filtervalues ;
         }

         set {
            gxTv_SdtGridState_Filtervalues = value ;
         }

      }

      public void gxTv_SdtGridState_Filtervalues_SetNull( )
      {
         gxTv_SdtGridState_Filtervalues = null ;
         return  ;
      }

      public bool gxTv_SdtGridState_Filtervalues_IsNull( )
      {
         if ( gxTv_SdtGridState_Filtervalues == null )
         {
            return true ;
         }
         return false ;
      }

      public void initialize( )
      {
         sTagName = "" ;
         return  ;
      }

      protected short gxTv_SdtGridState_Currentpage ;
      protected short gxTv_SdtGridState_Orderedby ;
      protected short gxTv_SdtGridState_Hidingsearch ;
      protected short readOk ;
      protected short nOutParmCount ;
      protected String sTagName ;
      protected Assembly constructorCallingAssembly ;
      protected IGxContext context ;
      protected IGxCollection gxTv_SdtGridState_Filtervalues=null ;
   }

}
