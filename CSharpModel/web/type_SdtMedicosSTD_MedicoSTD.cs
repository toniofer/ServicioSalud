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
   public class SdtMedicosSTD_MedicoSTD : GxUserType
   {
      public SdtMedicosSTD_MedicoSTD( )
      {
         constructorCallingAssembly = Assembly.GetCallingAssembly() ;
         initialize();
      }

      public SdtMedicosSTD_MedicoSTD( IGxContext context )
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
               if ( StringUtil.StrCmp(oReader.LocalName, "MedicoId") == 0 )
               {
                  gxTv_SdtMedicosSTD_MedicoSTD_Medicoid = (int)(NumberUtil.Val( oReader.Value, ".")) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "MedicoApellido") == 0 )
               {
                  gxTv_SdtMedicosSTD_MedicoSTD_Medicoapellido = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "MedicoNombre") == 0 )
               {
                  gxTv_SdtMedicosSTD_MedicoSTD_Mediconombre = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "EspecialidadId") == 0 )
               {
                  gxTv_SdtMedicosSTD_MedicoSTD_Especialidadid = (int)(NumberUtil.Val( oReader.Value, ".")) ;
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
            sName = "MedicosSTD.MedicoSTD" ;
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
         oWriter.WriteElement("MedicoId", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtMedicosSTD_MedicoSTD_Medicoid), 6, 0)));
         oWriter.WriteElement("MedicoApellido", StringUtil.RTrim( gxTv_SdtMedicosSTD_MedicoSTD_Medicoapellido));
         oWriter.WriteElement("MedicoNombre", StringUtil.RTrim( gxTv_SdtMedicosSTD_MedicoSTD_Mediconombre));
         oWriter.WriteElement("EspecialidadId", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtMedicosSTD_MedicoSTD_Especialidadid), 6, 0)));
         oWriter.WriteEndElement();
         return  ;
      }

      public override void ToJSON( )
      {
         AddObjectProperty("MedicoId", (Object)(gxTv_SdtMedicosSTD_MedicoSTD_Medicoid));
         AddObjectProperty("MedicoApellido", (Object)(gxTv_SdtMedicosSTD_MedicoSTD_Medicoapellido));
         AddObjectProperty("MedicoNombre", (Object)(gxTv_SdtMedicosSTD_MedicoSTD_Mediconombre));
         AddObjectProperty("EspecialidadId", (Object)(gxTv_SdtMedicosSTD_MedicoSTD_Especialidadid));
         return  ;
      }

      public int gxTpr_Medicoid
      {
         get {
            return gxTv_SdtMedicosSTD_MedicoSTD_Medicoid ;
         }

         set {
            gxTv_SdtMedicosSTD_MedicoSTD_Medicoid = (int)(value) ;
         }

      }

      public void gxTv_SdtMedicosSTD_MedicoSTD_Medicoid_SetNull( )
      {
         gxTv_SdtMedicosSTD_MedicoSTD_Medicoid = 0 ;
         return  ;
      }

      public bool gxTv_SdtMedicosSTD_MedicoSTD_Medicoid_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Medicoapellido
      {
         get {
            return gxTv_SdtMedicosSTD_MedicoSTD_Medicoapellido ;
         }

         set {
            gxTv_SdtMedicosSTD_MedicoSTD_Medicoapellido = (String)(value) ;
         }

      }

      public void gxTv_SdtMedicosSTD_MedicoSTD_Medicoapellido_SetNull( )
      {
         gxTv_SdtMedicosSTD_MedicoSTD_Medicoapellido = "" ;
         return  ;
      }

      public bool gxTv_SdtMedicosSTD_MedicoSTD_Medicoapellido_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Mediconombre
      {
         get {
            return gxTv_SdtMedicosSTD_MedicoSTD_Mediconombre ;
         }

         set {
            gxTv_SdtMedicosSTD_MedicoSTD_Mediconombre = (String)(value) ;
         }

      }

      public void gxTv_SdtMedicosSTD_MedicoSTD_Mediconombre_SetNull( )
      {
         gxTv_SdtMedicosSTD_MedicoSTD_Mediconombre = "" ;
         return  ;
      }

      public bool gxTv_SdtMedicosSTD_MedicoSTD_Mediconombre_IsNull( )
      {
         return false ;
      }

      public int gxTpr_Especialidadid
      {
         get {
            return gxTv_SdtMedicosSTD_MedicoSTD_Especialidadid ;
         }

         set {
            gxTv_SdtMedicosSTD_MedicoSTD_Especialidadid = (int)(value) ;
         }

      }

      public void gxTv_SdtMedicosSTD_MedicoSTD_Especialidadid_SetNull( )
      {
         gxTv_SdtMedicosSTD_MedicoSTD_Especialidadid = 0 ;
         return  ;
      }

      public bool gxTv_SdtMedicosSTD_MedicoSTD_Especialidadid_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtMedicosSTD_MedicoSTD_Medicoapellido = "" ;
         gxTv_SdtMedicosSTD_MedicoSTD_Mediconombre = "" ;
         sTagName = "" ;
         return  ;
      }

      protected short readOk ;
      protected short nOutParmCount ;
      protected int gxTv_SdtMedicosSTD_MedicoSTD_Medicoid ;
      protected int gxTv_SdtMedicosSTD_MedicoSTD_Especialidadid ;
      protected String gxTv_SdtMedicosSTD_MedicoSTD_Medicoapellido ;
      protected String gxTv_SdtMedicosSTD_MedicoSTD_Mediconombre ;
      protected String sTagName ;
      protected Assembly constructorCallingAssembly ;
      protected IGxContext context ;
   }

}
