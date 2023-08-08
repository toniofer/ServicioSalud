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
   public class SdtEstadisticasSDT : GxUserType
   {
      public SdtEstadisticasSDT( )
      {
         constructorCallingAssembly = Assembly.GetCallingAssembly() ;
         initialize();
      }

      public SdtEstadisticasSDT( IGxContext context )
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
               if ( StringUtil.StrCmp(oReader.LocalName, "FechaDesde") == 0 )
               {
                  if ( StringUtil.StrCmp(oReader.Value, "0000-00-00") == 0 )
                  {
                     gxTv_SdtEstadisticasSDT_Fechadesde = DateTime.MinValue ;
                  }
                  else
                  {
                     gxTv_SdtEstadisticasSDT_Fechadesde = context.localUtil.YMDToD( (int)(NumberUtil.Val( StringUtil.Substring( oReader.Value, 1, 4), ".")), (int)(NumberUtil.Val( StringUtil.Substring( oReader.Value, 6, 2), ".")), (int)(NumberUtil.Val( StringUtil.Substring( oReader.Value, 9, 2), "."))) ;
                  }
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "FechaHasta") == 0 )
               {
                  if ( StringUtil.StrCmp(oReader.Value, "0000-00-00") == 0 )
                  {
                     gxTv_SdtEstadisticasSDT_Fechahasta = DateTime.MinValue ;
                  }
                  else
                  {
                     gxTv_SdtEstadisticasSDT_Fechahasta = context.localUtil.YMDToD( (int)(NumberUtil.Val( StringUtil.Substring( oReader.Value, 1, 4), ".")), (int)(NumberUtil.Val( StringUtil.Substring( oReader.Value, 6, 2), ".")), (int)(NumberUtil.Val( StringUtil.Substring( oReader.Value, 9, 2), "."))) ;
                  }
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "Especialidad") == 0 )
               {
                  if ( gxTv_SdtEstadisticasSDT_Especialidad == null )
                  {
                     gxTv_SdtEstadisticasSDT_Especialidad = new GxObjectCollection( context, "EstadisticasSDT.EspecialidadItem", "taller041", "SdtEstadisticasSDT_EspecialidadItem", "GeneXus.Programs");
                  }
                  if ( oReader.IsSimple == 0 )
                  {
                     GXSoapError = gxTv_SdtEstadisticasSDT_Especialidad.readxmlcollection(oReader, "Especialidad", "EspecialidadItem") ;
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
            sName = "EstadisticasSDT" ;
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
         if ( (DateTime.MinValue==gxTv_SdtEstadisticasSDT_Fechadesde) )
         {
            oWriter.WriteElement("FechaDesde", "0000-00-00");
         }
         else
         {
            sDateCnv = "" ;
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtEstadisticasSDT_Fechadesde)), 10, 0)) ;
            sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad ;
            sDateCnv = sDateCnv + "-" ;
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtEstadisticasSDT_Fechadesde)), 10, 0)) ;
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad ;
            sDateCnv = sDateCnv + "-" ;
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtEstadisticasSDT_Fechadesde)), 10, 0)) ;
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad ;
            oWriter.WriteElement("FechaDesde", sDateCnv);
         }
         if ( (DateTime.MinValue==gxTv_SdtEstadisticasSDT_Fechahasta) )
         {
            oWriter.WriteElement("FechaHasta", "0000-00-00");
         }
         else
         {
            sDateCnv = "" ;
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtEstadisticasSDT_Fechahasta)), 10, 0)) ;
            sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad ;
            sDateCnv = sDateCnv + "-" ;
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtEstadisticasSDT_Fechahasta)), 10, 0)) ;
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad ;
            sDateCnv = sDateCnv + "-" ;
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtEstadisticasSDT_Fechahasta)), 10, 0)) ;
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad ;
            oWriter.WriteElement("FechaHasta", sDateCnv);
         }
         if ( gxTv_SdtEstadisticasSDT_Especialidad != null )
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
            gxTv_SdtEstadisticasSDT_Especialidad.writexmlcollection(oWriter, "Especialidad", sNameSpace1, "EspecialidadItem", sNameSpace1);
         }
         oWriter.WriteEndElement();
         return  ;
      }

      public override void ToJSON( )
      {
         sDateCnv = "" ;
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtEstadisticasSDT_Fechadesde)), 10, 0)) ;
         sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad ;
         sDateCnv = sDateCnv + "-" ;
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtEstadisticasSDT_Fechadesde)), 10, 0)) ;
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad ;
         sDateCnv = sDateCnv + "-" ;
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtEstadisticasSDT_Fechadesde)), 10, 0)) ;
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad ;
         AddObjectProperty("FechaDesde", (Object)(sDateCnv));
         sDateCnv = "" ;
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtEstadisticasSDT_Fechahasta)), 10, 0)) ;
         sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad ;
         sDateCnv = sDateCnv + "-" ;
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtEstadisticasSDT_Fechahasta)), 10, 0)) ;
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad ;
         sDateCnv = sDateCnv + "-" ;
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtEstadisticasSDT_Fechahasta)), 10, 0)) ;
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad ;
         AddObjectProperty("FechaHasta", (Object)(sDateCnv));
         if ( gxTv_SdtEstadisticasSDT_Especialidad != null )
         {
            AddObjectProperty("Especialidad", (Object)(gxTv_SdtEstadisticasSDT_Especialidad));
         }
         return  ;
      }

      public DateTime gxTpr_Fechadesde
      {
         get {
            return gxTv_SdtEstadisticasSDT_Fechadesde ;
         }

         set {
            gxTv_SdtEstadisticasSDT_Fechadesde = (DateTime)(value) ;
         }

      }

      public void gxTv_SdtEstadisticasSDT_Fechadesde_SetNull( )
      {
         gxTv_SdtEstadisticasSDT_Fechadesde = (DateTime)(DateTime.MinValue) ;
         return  ;
      }

      public bool gxTv_SdtEstadisticasSDT_Fechadesde_IsNull( )
      {
         return false ;
      }

      public DateTime gxTpr_Fechahasta
      {
         get {
            return gxTv_SdtEstadisticasSDT_Fechahasta ;
         }

         set {
            gxTv_SdtEstadisticasSDT_Fechahasta = (DateTime)(value) ;
         }

      }

      public void gxTv_SdtEstadisticasSDT_Fechahasta_SetNull( )
      {
         gxTv_SdtEstadisticasSDT_Fechahasta = (DateTime)(DateTime.MinValue) ;
         return  ;
      }

      public bool gxTv_SdtEstadisticasSDT_Fechahasta_IsNull( )
      {
         return false ;
      }

      public IGxCollection gxTpr_Especialidad
      {
         get {
            if ( gxTv_SdtEstadisticasSDT_Especialidad == null )
            {
               gxTv_SdtEstadisticasSDT_Especialidad = new GxObjectCollection( context, "EstadisticasSDT.EspecialidadItem", "taller041", "SdtEstadisticasSDT_EspecialidadItem", "GeneXus.Programs");
            }
            return gxTv_SdtEstadisticasSDT_Especialidad ;
         }

         set {
            gxTv_SdtEstadisticasSDT_Especialidad = value ;
         }

      }

      public void gxTv_SdtEstadisticasSDT_Especialidad_SetNull( )
      {
         gxTv_SdtEstadisticasSDT_Especialidad = null ;
         return  ;
      }

      public bool gxTv_SdtEstadisticasSDT_Especialidad_IsNull( )
      {
         if ( gxTv_SdtEstadisticasSDT_Especialidad == null )
         {
            return true ;
         }
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtEstadisticasSDT_Fechadesde = DateTime.MinValue ;
         gxTv_SdtEstadisticasSDT_Fechahasta = DateTime.MinValue ;
         sTagName = "" ;
         sDateCnv = "" ;
         sNumToPad = "" ;
         return  ;
      }

      protected short readOk ;
      protected short nOutParmCount ;
      protected String sTagName ;
      protected String sDateCnv ;
      protected String sNumToPad ;
      protected DateTime gxTv_SdtEstadisticasSDT_Fechadesde ;
      protected DateTime gxTv_SdtEstadisticasSDT_Fechahasta ;
      protected Assembly constructorCallingAssembly ;
      protected IGxContext context ;
      protected IGxCollection gxTv_SdtEstadisticasSDT_Especialidad=null ;
   }

}
