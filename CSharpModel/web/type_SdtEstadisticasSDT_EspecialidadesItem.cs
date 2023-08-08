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
   public class SdtEstadisticasSDT_EspecialidadesItem : GxUserType
   {
      public SdtEstadisticasSDT_EspecialidadesItem( )
      {
         constructorCallingAssembly = Assembly.GetCallingAssembly() ;
         initialize();
      }

      public SdtEstadisticasSDT_EspecialidadesItem( IGxContext context )
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
               if ( StringUtil.StrCmp(oReader.LocalName, "Especialidad") == 0 )
               {
                  gxTv_SdtEstadisticasSDT_EspecialidadesItem_Especialidad = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "Medico") == 0 )
               {
                  if ( gxTv_SdtEstadisticasSDT_EspecialidadesItem_Medico == null )
                  {
                     gxTv_SdtEstadisticasSDT_EspecialidadesItem_Medico = new GxObjectCollection( context, "EstadisticasSDT.EspecialidadesItem.MedicoItem", "", "SdtEstadisticasSDT_EspecialidadesItem_MedicoItem", "GeneXus.Programs");
                  }
                  if ( oReader.IsSimple == 0 )
                  {
                     GXSoapError = gxTv_SdtEstadisticasSDT_EspecialidadesItem_Medico.readxmlcollection(oReader, "Medico", "MedicoItem") ;
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
            sName = "EstadisticasSDT.EspecialidadesItem" ;
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
         oWriter.WriteElement("Especialidad", StringUtil.RTrim( gxTv_SdtEstadisticasSDT_EspecialidadesItem_Especialidad));
         if ( gxTv_SdtEstadisticasSDT_EspecialidadesItem_Medico != null )
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
            gxTv_SdtEstadisticasSDT_EspecialidadesItem_Medico.writexmlcollection(oWriter, "Medico", sNameSpace1, "MedicoItem", sNameSpace1);
         }
         oWriter.WriteEndElement();
         return  ;
      }

      public override void ToJSON( )
      {
         AddObjectProperty("Especialidad", (Object)(gxTv_SdtEstadisticasSDT_EspecialidadesItem_Especialidad));
         if ( gxTv_SdtEstadisticasSDT_EspecialidadesItem_Medico != null )
         {
            AddObjectProperty("Medico", (Object)(gxTv_SdtEstadisticasSDT_EspecialidadesItem_Medico));
         }
         return  ;
      }

      public String gxTpr_Especialidad
      {
         get {
            return gxTv_SdtEstadisticasSDT_EspecialidadesItem_Especialidad ;
         }

         set {
            gxTv_SdtEstadisticasSDT_EspecialidadesItem_Especialidad = (String)(value) ;
         }

      }

      public void gxTv_SdtEstadisticasSDT_EspecialidadesItem_Especialidad_SetNull( )
      {
         gxTv_SdtEstadisticasSDT_EspecialidadesItem_Especialidad = "" ;
         return  ;
      }

      public bool gxTv_SdtEstadisticasSDT_EspecialidadesItem_Especialidad_IsNull( )
      {
         return false ;
      }

      public IGxCollection gxTpr_Medico
      {
         get {
            if ( gxTv_SdtEstadisticasSDT_EspecialidadesItem_Medico == null )
            {
               gxTv_SdtEstadisticasSDT_EspecialidadesItem_Medico = new GxObjectCollection( context, "EstadisticasSDT.EspecialidadesItem.MedicoItem", "", "SdtEstadisticasSDT_EspecialidadesItem_MedicoItem", "GeneXus.Programs");
            }
            return gxTv_SdtEstadisticasSDT_EspecialidadesItem_Medico ;
         }

         set {
            gxTv_SdtEstadisticasSDT_EspecialidadesItem_Medico = value ;
         }

      }

      public void gxTv_SdtEstadisticasSDT_EspecialidadesItem_Medico_SetNull( )
      {
         gxTv_SdtEstadisticasSDT_EspecialidadesItem_Medico = null ;
         return  ;
      }

      public bool gxTv_SdtEstadisticasSDT_EspecialidadesItem_Medico_IsNull( )
      {
         if ( gxTv_SdtEstadisticasSDT_EspecialidadesItem_Medico == null )
         {
            return true ;
         }
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtEstadisticasSDT_EspecialidadesItem_Especialidad = "" ;
         sTagName = "" ;
         return  ;
      }

      protected short readOk ;
      protected short nOutParmCount ;
      protected String gxTv_SdtEstadisticasSDT_EspecialidadesItem_Especialidad ;
      protected String sTagName ;
      protected Assembly constructorCallingAssembly ;
      protected IGxContext context ;
      protected IGxCollection gxTv_SdtEstadisticasSDT_EspecialidadesItem_Medico=null ;
   }

}
