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
   public class SdtEstadisticasSDT_EspecialidadesItem_MedicosItem : GxUserType
   {
      public SdtEstadisticasSDT_EspecialidadesItem_MedicosItem( )
      {
         constructorCallingAssembly = Assembly.GetCallingAssembly() ;
         initialize();
      }

      public SdtEstadisticasSDT_EspecialidadesItem_MedicosItem( IGxContext context )
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
               if ( StringUtil.StrCmp(oReader.LocalName, "MedicoApellido") == 0 )
               {
                  gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Medicoapellido = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "MedicoNombre") == 0 )
               {
                  gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Mediconombre = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "CantConsultas") == 0 )
               {
                  gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Cantconsultas = (short)(NumberUtil.Val( oReader.Value, ".")) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "CantPacAtendidos") == 0 )
               {
                  gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Cantpacatendidos = (short)(NumberUtil.Val( oReader.Value, ".")) ;
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
            sName = "EstadisticasSDT.EspecialidadesItem.MedicosItem" ;
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
         oWriter.WriteElement("MedicoApellido", StringUtil.RTrim( gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Medicoapellido));
         oWriter.WriteElement("MedicoNombre", StringUtil.RTrim( gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Mediconombre));
         oWriter.WriteElement("CantConsultas", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Cantconsultas), 2, 0)));
         oWriter.WriteElement("CantPacAtendidos", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Cantpacatendidos), 2, 0)));
         oWriter.WriteEndElement();
         return  ;
      }

      public override void ToJSON( )
      {
         AddObjectProperty("MedicoApellido", (Object)(gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Medicoapellido));
         AddObjectProperty("MedicoNombre", (Object)(gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Mediconombre));
         AddObjectProperty("CantConsultas", (Object)(gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Cantconsultas));
         AddObjectProperty("CantPacAtendidos", (Object)(gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Cantpacatendidos));
         return  ;
      }

      public String gxTpr_Medicoapellido
      {
         get {
            return gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Medicoapellido ;
         }

         set {
            gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Medicoapellido = (String)(value) ;
         }

      }

      public void gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Medicoapellido_SetNull( )
      {
         gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Medicoapellido = "" ;
         return  ;
      }

      public bool gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Medicoapellido_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Mediconombre
      {
         get {
            return gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Mediconombre ;
         }

         set {
            gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Mediconombre = (String)(value) ;
         }

      }

      public void gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Mediconombre_SetNull( )
      {
         gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Mediconombre = "" ;
         return  ;
      }

      public bool gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Mediconombre_IsNull( )
      {
         return false ;
      }

      public short gxTpr_Cantconsultas
      {
         get {
            return gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Cantconsultas ;
         }

         set {
            gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Cantconsultas = (short)(value) ;
         }

      }

      public void gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Cantconsultas_SetNull( )
      {
         gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Cantconsultas = 0 ;
         return  ;
      }

      public bool gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Cantconsultas_IsNull( )
      {
         return false ;
      }

      public short gxTpr_Cantpacatendidos
      {
         get {
            return gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Cantpacatendidos ;
         }

         set {
            gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Cantpacatendidos = (short)(value) ;
         }

      }

      public void gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Cantpacatendidos_SetNull( )
      {
         gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Cantpacatendidos = 0 ;
         return  ;
      }

      public bool gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Cantpacatendidos_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Medicoapellido = "" ;
         gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Mediconombre = "" ;
         sTagName = "" ;
         return  ;
      }

      protected short gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Cantconsultas ;
      protected short gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Cantpacatendidos ;
      protected short readOk ;
      protected short nOutParmCount ;
      protected String gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Medicoapellido ;
      protected String gxTv_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem_Mediconombre ;
      protected String sTagName ;
      protected Assembly constructorCallingAssembly ;
      protected IGxContext context ;
   }

}
