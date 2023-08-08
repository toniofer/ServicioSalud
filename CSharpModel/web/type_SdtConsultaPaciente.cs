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
   public class SdtConsultaPaciente : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtConsultaPaciente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default") ;
         constructorCallingAssembly = Assembly.GetCallingAssembly() ;
         initialize();
         context.SetTheme("GeneXusX");
      }

      public SdtConsultaPaciente( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetCallingAssembly() ;
         initialize();
      }

      public void Load( DateTime AV43ConsultaFecha ,
                        int AV34PacienteId ,
                        int AV12MedicoId ,
                        short AV60TurnoId )
      {
         IGxSilentTrn obj ;
         obj = getTransaction() ;
         obj.LoadKey(new Object[] {(DateTime)AV43ConsultaFecha,(int)AV34PacienteId,(int)AV12MedicoId,(short)AV60TurnoId});
         return  ;
      }

      public IGxCollection GetMessages( )
      {
         short item = 1 ;
         IGxCollection msgs = new GxObjectCollection( context, "Messages.Message", "Genexus", "SdtMessages_Message", "GeneXus.Programs") ;
         SdtMessages_Message m1 ;
         IGxSilentTrn trn = getTransaction() ;
         msglist msgList = trn.GetMessages() ;
         while ( item <= msgList.ItemCount )
         {
            m1 = new SdtMessages_Message(context) ;
            m1.gxTpr_Id = msgList.getItemValue(item) ;
            m1.gxTpr_Description = msgList.getItemText(item) ;
            m1.gxTpr_Type = msgList.getItemType(item) ;
            msgs.Add(m1, 0);
            item = (short)(item+1) ;
         }
         return msgs ;
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
               if ( StringUtil.StrCmp(oReader.LocalName, "ConsultaFecha") == 0 )
               {
                  if ( StringUtil.StrCmp(oReader.Value, "0000-00-00") == 0 )
                  {
                     gxTv_SdtConsultaPaciente_Consultafecha = DateTime.MinValue ;
                  }
                  else
                  {
                     gxTv_SdtConsultaPaciente_Consultafecha = context.localUtil.YMDToD( (int)(NumberUtil.Val( StringUtil.Substring( oReader.Value, 1, 4), ".")), (int)(NumberUtil.Val( StringUtil.Substring( oReader.Value, 6, 2), ".")), (int)(NumberUtil.Val( StringUtil.Substring( oReader.Value, 9, 2), "."))) ;
                  }
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "PacienteId") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Pacienteid = (int)(NumberUtil.Val( oReader.Value, ".")) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "PacienteApellido") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Pacienteapellido = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "PacienteNombre") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Pacientenombre = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "PacienteCI") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Pacienteci = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "MedicoId") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Medicoid = (int)(NumberUtil.Val( oReader.Value, ".")) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "MedicoApellido") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Medicoapellido = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "MedicoNombre") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Mediconombre = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "EspecialidadMaxPacientes") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Especialidadmaxpacientes = (short)(NumberUtil.Val( oReader.Value, ".")) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "TurnoId") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Turnoid = (short)(NumberUtil.Val( oReader.Value, ".")) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "TurnoNombre") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Turnonombre = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "ConsultaNro") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Consultanro = (short)(NumberUtil.Val( oReader.Value, ".")) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "Confirmado") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Confirmado = (bool)(Convert.ToBoolean(((StringUtil.StrCmp(oReader.Value, "true")==0)||(StringUtil.StrCmp(oReader.Value, "1")==0) ? 1 : 0))) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "Ultimonroasig") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Ultimonroasig = (short)(NumberUtil.Val( oReader.Value, ".")) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "Mode") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Mode = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "Initialized") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Initialized = (short)(NumberUtil.Val( oReader.Value, ".")) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "ConsultaFecha_Z") == 0 )
               {
                  if ( StringUtil.StrCmp(oReader.Value, "0000-00-00") == 0 )
                  {
                     gxTv_SdtConsultaPaciente_Consultafecha_Z = DateTime.MinValue ;
                  }
                  else
                  {
                     gxTv_SdtConsultaPaciente_Consultafecha_Z = context.localUtil.YMDToD( (int)(NumberUtil.Val( StringUtil.Substring( oReader.Value, 1, 4), ".")), (int)(NumberUtil.Val( StringUtil.Substring( oReader.Value, 6, 2), ".")), (int)(NumberUtil.Val( StringUtil.Substring( oReader.Value, 9, 2), "."))) ;
                  }
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "PacienteId_Z") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Pacienteid_Z = (int)(NumberUtil.Val( oReader.Value, ".")) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "PacienteApellido_Z") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Pacienteapellido_Z = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "PacienteNombre_Z") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Pacientenombre_Z = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "PacienteCI_Z") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Pacienteci_Z = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "MedicoId_Z") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Medicoid_Z = (int)(NumberUtil.Val( oReader.Value, ".")) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "MedicoApellido_Z") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Medicoapellido_Z = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "MedicoNombre_Z") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Mediconombre_Z = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "EspecialidadMaxPacientes_Z") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Especialidadmaxpacientes_Z = (short)(NumberUtil.Val( oReader.Value, ".")) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "TurnoId_Z") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Turnoid_Z = (short)(NumberUtil.Val( oReader.Value, ".")) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "TurnoNombre_Z") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Turnonombre_Z = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "ConsultaNro_Z") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Consultanro_Z = (short)(NumberUtil.Val( oReader.Value, ".")) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "Confirmado_Z") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Confirmado_Z = (bool)(Convert.ToBoolean(((StringUtil.StrCmp(oReader.Value, "true")==0)||(StringUtil.StrCmp(oReader.Value, "1")==0) ? 1 : 0))) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "Ultimonroasig_Z") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Ultimonroasig_Z = (short)(NumberUtil.Val( oReader.Value, ".")) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "ConsultaNro_N") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Consultanro_N = (short)(NumberUtil.Val( oReader.Value, ".")) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "Ultimonroasig_N") == 0 )
               {
                  gxTv_SdtConsultaPaciente_Ultimonroasig_N = (short)(NumberUtil.Val( oReader.Value, ".")) ;
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
            sName = "ConsultaPaciente" ;
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
         if ( (DateTime.MinValue==gxTv_SdtConsultaPaciente_Consultafecha) )
         {
            oWriter.WriteElement("ConsultaFecha", "0000-00-00");
         }
         else
         {
            sDateCnv = "" ;
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtConsultaPaciente_Consultafecha)), 10, 0)) ;
            sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad ;
            sDateCnv = sDateCnv + "-" ;
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtConsultaPaciente_Consultafecha)), 10, 0)) ;
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad ;
            sDateCnv = sDateCnv + "-" ;
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtConsultaPaciente_Consultafecha)), 10, 0)) ;
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad ;
            oWriter.WriteElement("ConsultaFecha", sDateCnv);
         }
         oWriter.WriteElement("PacienteId", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtConsultaPaciente_Pacienteid), 6, 0)));
         oWriter.WriteElement("PacienteApellido", StringUtil.RTrim( gxTv_SdtConsultaPaciente_Pacienteapellido));
         oWriter.WriteElement("PacienteNombre", StringUtil.RTrim( gxTv_SdtConsultaPaciente_Pacientenombre));
         oWriter.WriteElement("PacienteCI", StringUtil.RTrim( gxTv_SdtConsultaPaciente_Pacienteci));
         oWriter.WriteElement("MedicoId", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtConsultaPaciente_Medicoid), 6, 0)));
         oWriter.WriteElement("MedicoApellido", StringUtil.RTrim( gxTv_SdtConsultaPaciente_Medicoapellido));
         oWriter.WriteElement("MedicoNombre", StringUtil.RTrim( gxTv_SdtConsultaPaciente_Mediconombre));
         oWriter.WriteElement("EspecialidadMaxPacientes", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtConsultaPaciente_Especialidadmaxpacientes), 3, 0)));
         oWriter.WriteElement("TurnoId", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtConsultaPaciente_Turnoid), 2, 0)));
         oWriter.WriteElement("TurnoNombre", StringUtil.RTrim( gxTv_SdtConsultaPaciente_Turnonombre));
         oWriter.WriteElement("ConsultaNro", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtConsultaPaciente_Consultanro), 2, 0)));
         oWriter.WriteElement("Confirmado", StringUtil.RTrim( StringUtil.BoolToStr( gxTv_SdtConsultaPaciente_Confirmado)));
         oWriter.WriteElement("Ultimonroasig", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtConsultaPaciente_Ultimonroasig), 2, 0)));
         oWriter.WriteElement("Mode", StringUtil.RTrim( gxTv_SdtConsultaPaciente_Mode));
         oWriter.WriteElement("Initialized", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtConsultaPaciente_Initialized), 4, 0)));
         if ( (DateTime.MinValue==gxTv_SdtConsultaPaciente_Consultafecha_Z) )
         {
            oWriter.WriteElement("ConsultaFecha_Z", "0000-00-00");
         }
         else
         {
            sDateCnv = "" ;
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtConsultaPaciente_Consultafecha_Z)), 10, 0)) ;
            sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad ;
            sDateCnv = sDateCnv + "-" ;
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtConsultaPaciente_Consultafecha_Z)), 10, 0)) ;
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad ;
            sDateCnv = sDateCnv + "-" ;
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtConsultaPaciente_Consultafecha_Z)), 10, 0)) ;
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad ;
            oWriter.WriteElement("ConsultaFecha_Z", sDateCnv);
         }
         oWriter.WriteElement("PacienteId_Z", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtConsultaPaciente_Pacienteid_Z), 6, 0)));
         oWriter.WriteElement("PacienteApellido_Z", StringUtil.RTrim( gxTv_SdtConsultaPaciente_Pacienteapellido_Z));
         oWriter.WriteElement("PacienteNombre_Z", StringUtil.RTrim( gxTv_SdtConsultaPaciente_Pacientenombre_Z));
         oWriter.WriteElement("PacienteCI_Z", StringUtil.RTrim( gxTv_SdtConsultaPaciente_Pacienteci_Z));
         oWriter.WriteElement("MedicoId_Z", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtConsultaPaciente_Medicoid_Z), 6, 0)));
         oWriter.WriteElement("MedicoApellido_Z", StringUtil.RTrim( gxTv_SdtConsultaPaciente_Medicoapellido_Z));
         oWriter.WriteElement("MedicoNombre_Z", StringUtil.RTrim( gxTv_SdtConsultaPaciente_Mediconombre_Z));
         oWriter.WriteElement("EspecialidadMaxPacientes_Z", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtConsultaPaciente_Especialidadmaxpacientes_Z), 3, 0)));
         oWriter.WriteElement("TurnoId_Z", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtConsultaPaciente_Turnoid_Z), 2, 0)));
         oWriter.WriteElement("TurnoNombre_Z", StringUtil.RTrim( gxTv_SdtConsultaPaciente_Turnonombre_Z));
         oWriter.WriteElement("ConsultaNro_Z", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtConsultaPaciente_Consultanro_Z), 2, 0)));
         oWriter.WriteElement("Confirmado_Z", StringUtil.RTrim( StringUtil.BoolToStr( gxTv_SdtConsultaPaciente_Confirmado_Z)));
         oWriter.WriteElement("Ultimonroasig_Z", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtConsultaPaciente_Ultimonroasig_Z), 2, 0)));
         oWriter.WriteElement("ConsultaNro_N", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtConsultaPaciente_Consultanro_N), 1, 0)));
         oWriter.WriteElement("Ultimonroasig_N", StringUtil.Trim( StringUtil.Str( (decimal)(gxTv_SdtConsultaPaciente_Ultimonroasig_N), 1, 0)));
         oWriter.WriteEndElement();
         return  ;
      }

      public override void ToJSON( )
      {
         sDateCnv = "" ;
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtConsultaPaciente_Consultafecha)), 10, 0)) ;
         sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad ;
         sDateCnv = sDateCnv + "-" ;
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtConsultaPaciente_Consultafecha)), 10, 0)) ;
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad ;
         sDateCnv = sDateCnv + "-" ;
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtConsultaPaciente_Consultafecha)), 10, 0)) ;
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad ;
         AddObjectProperty("ConsultaFecha", (Object)(sDateCnv));
         AddObjectProperty("PacienteId", (Object)(gxTv_SdtConsultaPaciente_Pacienteid));
         AddObjectProperty("PacienteApellido", (Object)(gxTv_SdtConsultaPaciente_Pacienteapellido));
         AddObjectProperty("PacienteNombre", (Object)(gxTv_SdtConsultaPaciente_Pacientenombre));
         AddObjectProperty("PacienteCI", (Object)(gxTv_SdtConsultaPaciente_Pacienteci));
         AddObjectProperty("MedicoId", (Object)(gxTv_SdtConsultaPaciente_Medicoid));
         AddObjectProperty("MedicoApellido", (Object)(gxTv_SdtConsultaPaciente_Medicoapellido));
         AddObjectProperty("MedicoNombre", (Object)(gxTv_SdtConsultaPaciente_Mediconombre));
         AddObjectProperty("EspecialidadMaxPacientes", (Object)(gxTv_SdtConsultaPaciente_Especialidadmaxpacientes));
         AddObjectProperty("TurnoId", (Object)(gxTv_SdtConsultaPaciente_Turnoid));
         AddObjectProperty("TurnoNombre", (Object)(gxTv_SdtConsultaPaciente_Turnonombre));
         AddObjectProperty("ConsultaNro", (Object)(gxTv_SdtConsultaPaciente_Consultanro));
         AddObjectProperty("Confirmado", (Object)(gxTv_SdtConsultaPaciente_Confirmado));
         AddObjectProperty("Ultimonroasig", (Object)(gxTv_SdtConsultaPaciente_Ultimonroasig));
         AddObjectProperty("Mode", (Object)(gxTv_SdtConsultaPaciente_Mode));
         AddObjectProperty("Initialized", (Object)(gxTv_SdtConsultaPaciente_Initialized));
         sDateCnv = "" ;
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtConsultaPaciente_Consultafecha_Z)), 10, 0)) ;
         sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad ;
         sDateCnv = sDateCnv + "-" ;
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtConsultaPaciente_Consultafecha_Z)), 10, 0)) ;
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad ;
         sDateCnv = sDateCnv + "-" ;
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtConsultaPaciente_Consultafecha_Z)), 10, 0)) ;
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad ;
         AddObjectProperty("ConsultaFecha_Z", (Object)(sDateCnv));
         AddObjectProperty("PacienteId_Z", (Object)(gxTv_SdtConsultaPaciente_Pacienteid_Z));
         AddObjectProperty("PacienteApellido_Z", (Object)(gxTv_SdtConsultaPaciente_Pacienteapellido_Z));
         AddObjectProperty("PacienteNombre_Z", (Object)(gxTv_SdtConsultaPaciente_Pacientenombre_Z));
         AddObjectProperty("PacienteCI_Z", (Object)(gxTv_SdtConsultaPaciente_Pacienteci_Z));
         AddObjectProperty("MedicoId_Z", (Object)(gxTv_SdtConsultaPaciente_Medicoid_Z));
         AddObjectProperty("MedicoApellido_Z", (Object)(gxTv_SdtConsultaPaciente_Medicoapellido_Z));
         AddObjectProperty("MedicoNombre_Z", (Object)(gxTv_SdtConsultaPaciente_Mediconombre_Z));
         AddObjectProperty("EspecialidadMaxPacientes_Z", (Object)(gxTv_SdtConsultaPaciente_Especialidadmaxpacientes_Z));
         AddObjectProperty("TurnoId_Z", (Object)(gxTv_SdtConsultaPaciente_Turnoid_Z));
         AddObjectProperty("TurnoNombre_Z", (Object)(gxTv_SdtConsultaPaciente_Turnonombre_Z));
         AddObjectProperty("ConsultaNro_Z", (Object)(gxTv_SdtConsultaPaciente_Consultanro_Z));
         AddObjectProperty("Confirmado_Z", (Object)(gxTv_SdtConsultaPaciente_Confirmado_Z));
         AddObjectProperty("Ultimonroasig_Z", (Object)(gxTv_SdtConsultaPaciente_Ultimonroasig_Z));
         AddObjectProperty("ConsultaNro_N", (Object)(gxTv_SdtConsultaPaciente_Consultanro_N));
         AddObjectProperty("Ultimonroasig_N", (Object)(gxTv_SdtConsultaPaciente_Ultimonroasig_N));
         return  ;
      }

      public DateTime gxTpr_Consultafecha
      {
         get {
            return gxTv_SdtConsultaPaciente_Consultafecha ;
         }

         set {
            if ( gxTv_SdtConsultaPaciente_Consultafecha != value )
            {
               gxTv_SdtConsultaPaciente_Mode = "INS" ;
            }
            gxTv_SdtConsultaPaciente_Consultafecha = (DateTime)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Consultafecha_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Consultafecha = (DateTime)(DateTime.MinValue) ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Consultafecha_IsNull( )
      {
         return false ;
      }

      public int gxTpr_Pacienteid
      {
         get {
            return gxTv_SdtConsultaPaciente_Pacienteid ;
         }

         set {
            if ( gxTv_SdtConsultaPaciente_Pacienteid != value )
            {
               gxTv_SdtConsultaPaciente_Mode = "INS" ;
            }
            gxTv_SdtConsultaPaciente_Pacienteid = (int)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Pacienteid_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Pacienteid = 0 ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Pacienteid_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Pacienteapellido
      {
         get {
            return gxTv_SdtConsultaPaciente_Pacienteapellido ;
         }

         set {
            gxTv_SdtConsultaPaciente_Pacienteapellido = (String)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Pacienteapellido_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Pacienteapellido = "" ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Pacienteapellido_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Pacientenombre
      {
         get {
            return gxTv_SdtConsultaPaciente_Pacientenombre ;
         }

         set {
            gxTv_SdtConsultaPaciente_Pacientenombre = (String)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Pacientenombre_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Pacientenombre = "" ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Pacientenombre_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Pacienteci
      {
         get {
            return gxTv_SdtConsultaPaciente_Pacienteci ;
         }

         set {
            gxTv_SdtConsultaPaciente_Pacienteci = (String)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Pacienteci_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Pacienteci = "" ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Pacienteci_IsNull( )
      {
         return false ;
      }

      public int gxTpr_Medicoid
      {
         get {
            return gxTv_SdtConsultaPaciente_Medicoid ;
         }

         set {
            if ( gxTv_SdtConsultaPaciente_Medicoid != value )
            {
               gxTv_SdtConsultaPaciente_Mode = "INS" ;
            }
            gxTv_SdtConsultaPaciente_Medicoid = (int)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Medicoid_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Medicoid = 0 ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Medicoid_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Medicoapellido
      {
         get {
            return gxTv_SdtConsultaPaciente_Medicoapellido ;
         }

         set {
            gxTv_SdtConsultaPaciente_Medicoapellido = (String)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Medicoapellido_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Medicoapellido = "" ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Medicoapellido_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Mediconombre
      {
         get {
            return gxTv_SdtConsultaPaciente_Mediconombre ;
         }

         set {
            gxTv_SdtConsultaPaciente_Mediconombre = (String)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Mediconombre_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Mediconombre = "" ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Mediconombre_IsNull( )
      {
         return false ;
      }

      public short gxTpr_Especialidadmaxpacientes
      {
         get {
            return gxTv_SdtConsultaPaciente_Especialidadmaxpacientes ;
         }

         set {
            gxTv_SdtConsultaPaciente_Especialidadmaxpacientes = (short)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Especialidadmaxpacientes_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Especialidadmaxpacientes = 0 ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Especialidadmaxpacientes_IsNull( )
      {
         return false ;
      }

      public short gxTpr_Turnoid
      {
         get {
            return gxTv_SdtConsultaPaciente_Turnoid ;
         }

         set {
            if ( gxTv_SdtConsultaPaciente_Turnoid != value )
            {
               gxTv_SdtConsultaPaciente_Mode = "INS" ;
            }
            gxTv_SdtConsultaPaciente_Turnoid = (short)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Turnoid_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Turnoid = 0 ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Turnoid_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Turnonombre
      {
         get {
            return gxTv_SdtConsultaPaciente_Turnonombre ;
         }

         set {
            gxTv_SdtConsultaPaciente_Turnonombre = (String)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Turnonombre_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Turnonombre = "" ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Turnonombre_IsNull( )
      {
         return false ;
      }

      public short gxTpr_Consultanro
      {
         get {
            return gxTv_SdtConsultaPaciente_Consultanro ;
         }

         set {
            gxTv_SdtConsultaPaciente_Consultanro_N = 0 ;
            gxTv_SdtConsultaPaciente_Consultanro = (short)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Consultanro_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Consultanro_N = 1 ;
         gxTv_SdtConsultaPaciente_Consultanro = 0 ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Consultanro_IsNull( )
      {
         return false ;
      }

      public bool gxTpr_Confirmado
      {
         get {
            return gxTv_SdtConsultaPaciente_Confirmado ;
         }

         set {
            gxTv_SdtConsultaPaciente_Confirmado = value ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Confirmado_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Confirmado = false ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Confirmado_IsNull( )
      {
         return false ;
      }

      public short gxTpr_Ultimonroasig
      {
         get {
            return gxTv_SdtConsultaPaciente_Ultimonroasig ;
         }

         set {
            gxTv_SdtConsultaPaciente_Ultimonroasig_N = 0 ;
            gxTv_SdtConsultaPaciente_Ultimonroasig = (short)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Ultimonroasig_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Ultimonroasig_N = 1 ;
         gxTv_SdtConsultaPaciente_Ultimonroasig = 0 ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Ultimonroasig_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Mode
      {
         get {
            return gxTv_SdtConsultaPaciente_Mode ;
         }

         set {
            gxTv_SdtConsultaPaciente_Mode = (String)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Mode_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Mode = "" ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Mode_IsNull( )
      {
         return false ;
      }

      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtConsultaPaciente_Initialized ;
         }

         set {
            gxTv_SdtConsultaPaciente_Initialized = (short)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Initialized_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Initialized = 0 ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Initialized_IsNull( )
      {
         return false ;
      }

      public DateTime gxTpr_Consultafecha_Z
      {
         get {
            return gxTv_SdtConsultaPaciente_Consultafecha_Z ;
         }

         set {
            gxTv_SdtConsultaPaciente_Consultafecha_Z = (DateTime)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Consultafecha_Z_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Consultafecha_Z = (DateTime)(DateTime.MinValue) ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Consultafecha_Z_IsNull( )
      {
         return false ;
      }

      public int gxTpr_Pacienteid_Z
      {
         get {
            return gxTv_SdtConsultaPaciente_Pacienteid_Z ;
         }

         set {
            gxTv_SdtConsultaPaciente_Pacienteid_Z = (int)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Pacienteid_Z_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Pacienteid_Z = 0 ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Pacienteid_Z_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Pacienteapellido_Z
      {
         get {
            return gxTv_SdtConsultaPaciente_Pacienteapellido_Z ;
         }

         set {
            gxTv_SdtConsultaPaciente_Pacienteapellido_Z = (String)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Pacienteapellido_Z_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Pacienteapellido_Z = "" ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Pacienteapellido_Z_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Pacientenombre_Z
      {
         get {
            return gxTv_SdtConsultaPaciente_Pacientenombre_Z ;
         }

         set {
            gxTv_SdtConsultaPaciente_Pacientenombre_Z = (String)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Pacientenombre_Z_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Pacientenombre_Z = "" ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Pacientenombre_Z_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Pacienteci_Z
      {
         get {
            return gxTv_SdtConsultaPaciente_Pacienteci_Z ;
         }

         set {
            gxTv_SdtConsultaPaciente_Pacienteci_Z = (String)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Pacienteci_Z_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Pacienteci_Z = "" ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Pacienteci_Z_IsNull( )
      {
         return false ;
      }

      public int gxTpr_Medicoid_Z
      {
         get {
            return gxTv_SdtConsultaPaciente_Medicoid_Z ;
         }

         set {
            gxTv_SdtConsultaPaciente_Medicoid_Z = (int)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Medicoid_Z_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Medicoid_Z = 0 ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Medicoid_Z_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Medicoapellido_Z
      {
         get {
            return gxTv_SdtConsultaPaciente_Medicoapellido_Z ;
         }

         set {
            gxTv_SdtConsultaPaciente_Medicoapellido_Z = (String)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Medicoapellido_Z_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Medicoapellido_Z = "" ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Medicoapellido_Z_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Mediconombre_Z
      {
         get {
            return gxTv_SdtConsultaPaciente_Mediconombre_Z ;
         }

         set {
            gxTv_SdtConsultaPaciente_Mediconombre_Z = (String)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Mediconombre_Z_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Mediconombre_Z = "" ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Mediconombre_Z_IsNull( )
      {
         return false ;
      }

      public short gxTpr_Especialidadmaxpacientes_Z
      {
         get {
            return gxTv_SdtConsultaPaciente_Especialidadmaxpacientes_Z ;
         }

         set {
            gxTv_SdtConsultaPaciente_Especialidadmaxpacientes_Z = (short)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Especialidadmaxpacientes_Z_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Especialidadmaxpacientes_Z = 0 ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Especialidadmaxpacientes_Z_IsNull( )
      {
         return false ;
      }

      public short gxTpr_Turnoid_Z
      {
         get {
            return gxTv_SdtConsultaPaciente_Turnoid_Z ;
         }

         set {
            gxTv_SdtConsultaPaciente_Turnoid_Z = (short)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Turnoid_Z_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Turnoid_Z = 0 ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Turnoid_Z_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Turnonombre_Z
      {
         get {
            return gxTv_SdtConsultaPaciente_Turnonombre_Z ;
         }

         set {
            gxTv_SdtConsultaPaciente_Turnonombre_Z = (String)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Turnonombre_Z_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Turnonombre_Z = "" ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Turnonombre_Z_IsNull( )
      {
         return false ;
      }

      public short gxTpr_Consultanro_Z
      {
         get {
            return gxTv_SdtConsultaPaciente_Consultanro_Z ;
         }

         set {
            gxTv_SdtConsultaPaciente_Consultanro_Z = (short)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Consultanro_Z_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Consultanro_Z = 0 ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Consultanro_Z_IsNull( )
      {
         return false ;
      }

      public bool gxTpr_Confirmado_Z
      {
         get {
            return gxTv_SdtConsultaPaciente_Confirmado_Z ;
         }

         set {
            gxTv_SdtConsultaPaciente_Confirmado_Z = value ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Confirmado_Z_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Confirmado_Z = false ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Confirmado_Z_IsNull( )
      {
         return false ;
      }

      public short gxTpr_Ultimonroasig_Z
      {
         get {
            return gxTv_SdtConsultaPaciente_Ultimonroasig_Z ;
         }

         set {
            gxTv_SdtConsultaPaciente_Ultimonroasig_Z = (short)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Ultimonroasig_Z_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Ultimonroasig_Z = 0 ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Ultimonroasig_Z_IsNull( )
      {
         return false ;
      }

      public short gxTpr_Consultanro_N
      {
         get {
            return gxTv_SdtConsultaPaciente_Consultanro_N ;
         }

         set {
            gxTv_SdtConsultaPaciente_Consultanro_N = (short)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Consultanro_N_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Consultanro_N = 0 ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Consultanro_N_IsNull( )
      {
         return false ;
      }

      public short gxTpr_Ultimonroasig_N
      {
         get {
            return gxTv_SdtConsultaPaciente_Ultimonroasig_N ;
         }

         set {
            gxTv_SdtConsultaPaciente_Ultimonroasig_N = (short)(value) ;
         }

      }

      public void gxTv_SdtConsultaPaciente_Ultimonroasig_N_SetNull( )
      {
         gxTv_SdtConsultaPaciente_Ultimonroasig_N = 0 ;
         return  ;
      }

      public bool gxTv_SdtConsultaPaciente_Ultimonroasig_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtConsultaPaciente_Consultafecha = DateTime.MinValue ;
         gxTv_SdtConsultaPaciente_Pacienteapellido = "" ;
         gxTv_SdtConsultaPaciente_Pacientenombre = "" ;
         gxTv_SdtConsultaPaciente_Pacienteci = "" ;
         gxTv_SdtConsultaPaciente_Medicoapellido = "" ;
         gxTv_SdtConsultaPaciente_Mediconombre = "" ;
         gxTv_SdtConsultaPaciente_Turnonombre = "" ;
         gxTv_SdtConsultaPaciente_Mode = "" ;
         gxTv_SdtConsultaPaciente_Consultafecha_Z = DateTime.MinValue ;
         gxTv_SdtConsultaPaciente_Pacienteapellido_Z = "" ;
         gxTv_SdtConsultaPaciente_Pacientenombre_Z = "" ;
         gxTv_SdtConsultaPaciente_Pacienteci_Z = "" ;
         gxTv_SdtConsultaPaciente_Medicoapellido_Z = "" ;
         gxTv_SdtConsultaPaciente_Mediconombre_Z = "" ;
         gxTv_SdtConsultaPaciente_Turnonombre_Z = "" ;
         sTagName = "" ;
         sDateCnv = "" ;
         sNumToPad = "" ;
         IGxSilentTrn obj ;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "consultapaciente", "GeneXus.Programs.consultapaciente_bc", new Object[] {context}, constructorCallingAssembly) ;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      private short gxTv_SdtConsultaPaciente_Especialidadmaxpacientes ;
      private short gxTv_SdtConsultaPaciente_Turnoid ;
      private short gxTv_SdtConsultaPaciente_Consultanro ;
      private short gxTv_SdtConsultaPaciente_Ultimonroasig ;
      private short gxTv_SdtConsultaPaciente_Initialized ;
      private short gxTv_SdtConsultaPaciente_Especialidadmaxpacientes_Z ;
      private short gxTv_SdtConsultaPaciente_Turnoid_Z ;
      private short gxTv_SdtConsultaPaciente_Consultanro_Z ;
      private short gxTv_SdtConsultaPaciente_Ultimonroasig_Z ;
      private short gxTv_SdtConsultaPaciente_Consultanro_N ;
      private short gxTv_SdtConsultaPaciente_Ultimonroasig_N ;
      private short readOk ;
      private short nOutParmCount ;
      private int gxTv_SdtConsultaPaciente_Pacienteid ;
      private int gxTv_SdtConsultaPaciente_Medicoid ;
      private int gxTv_SdtConsultaPaciente_Pacienteid_Z ;
      private int gxTv_SdtConsultaPaciente_Medicoid_Z ;
      private String gxTv_SdtConsultaPaciente_Pacienteapellido ;
      private String gxTv_SdtConsultaPaciente_Pacientenombre ;
      private String gxTv_SdtConsultaPaciente_Pacienteci ;
      private String gxTv_SdtConsultaPaciente_Medicoapellido ;
      private String gxTv_SdtConsultaPaciente_Mediconombre ;
      private String gxTv_SdtConsultaPaciente_Turnonombre ;
      private String gxTv_SdtConsultaPaciente_Mode ;
      private String gxTv_SdtConsultaPaciente_Pacienteapellido_Z ;
      private String gxTv_SdtConsultaPaciente_Pacientenombre_Z ;
      private String gxTv_SdtConsultaPaciente_Pacienteci_Z ;
      private String gxTv_SdtConsultaPaciente_Medicoapellido_Z ;
      private String gxTv_SdtConsultaPaciente_Mediconombre_Z ;
      private String gxTv_SdtConsultaPaciente_Turnonombre_Z ;
      private String sTagName ;
      private String sDateCnv ;
      private String sNumToPad ;
      private DateTime gxTv_SdtConsultaPaciente_Consultafecha ;
      private DateTime gxTv_SdtConsultaPaciente_Consultafecha_Z ;
      private bool gxTv_SdtConsultaPaciente_Confirmado ;
      private bool gxTv_SdtConsultaPaciente_Confirmado_Z ;
      [NonSerialized()] private IGxDataStore dsDefault ;
      private Assembly constructorCallingAssembly ;
      private IGxContext context ;
   }

}
