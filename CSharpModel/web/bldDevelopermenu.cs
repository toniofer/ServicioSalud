using System;
using GeneXus.Builder;
using System.IO;
public class bldDevelopermenu : GxBaseBuilder
{
   string cs_path = "." ;
   public bldDevelopermenu( ) : base()
   {
   }

   public override int BeforeCompile( )
   {
      return 0 ;
   }

   public override int AfterCompile( )
   {
      int ErrCode ;
      ErrCode = 0 ;
      if ( ! File.Exists(@"bin\client.exe.config") || checkTime(@"bin\client.exe.config",cs_path + @"\client.exe.config") )
      {
         File.Copy( cs_path + @"\client.exe.config", @"bin\client.exe.config", true);
      }
      return ErrCode ;
   }

   static public int Main( string[] args )
   {
      bldDevelopermenu x = new bldDevelopermenu() ;
      x.SetMainSourceFile( "bldDevelopermenu.cs");
      x.LoadVariables( args);
      return x.CompileAll( );
   }

   public override ItemCollection GetSortedBuildList( )
   {
      ItemCollection sc = new ItemCollection() ;
      sc.Add( @"bin\GeneXus.Programs.Common.dll", cs_path + @"\GeneXus.Programs.Common.rsp");
      return sc ;
   }

   public override ItemCollection GetRuntimeBuildList( )
   {
      ItemCollection sc = new ItemCollection() ;
      sc.Add( @"bin\alistarmedicos.dll", cs_path + @"\alistarmedicos.rsp");
      sc.Add( @"bin\aimpresiontiket.dll", cs_path + @"\aimpresiontiket.rsp");
      sc.Add( @"bin\historiaclinicageneral.dll", cs_path + @"\historiaclinicageneral.rsp");
      sc.Add( @"bin\wwhistoriaclinica.dll", cs_path + @"\wwhistoriaclinica.rsp");
      sc.Add( @"bin\viewhistoriaclinica.dll", cs_path + @"\viewhistoriaclinica.rsp");
      sc.Add( @"bin\gx0020.dll", cs_path + @"\gx0020.rsp");
      sc.Add( @"bin\gx0060.dll", cs_path + @"\gx0060.rsp");
      sc.Add( @"bin\gx0080.dll", cs_path + @"\gx0080.rsp");
      sc.Add( @"bin\gx0070.dll", cs_path + @"\gx0070.rsp");
      sc.Add( @"bin\gx0050.dll", cs_path + @"\gx0050.rsp");
      sc.Add( @"bin\wplistarmedicos.dll", cs_path + @"\wplistarmedicos.rsp");
      sc.Add( @"bin\wpestadisticas.dll", cs_path + @"\wpestadisticas.rsp");
      sc.Add( @"bin\categoryconsultarelationwc.dll", cs_path + @"\categoryconsultarelationwc.rsp");
      sc.Add( @"bin\categorygestionconsultarelationwc.dll", cs_path + @"\categorygestionconsultarelationwc.rsp");
      sc.Add( @"bin\gx0010.dll", cs_path + @"\gx0010.rsp");
      sc.Add( @"bin\solicitudconsulta.dll", cs_path + @"\solicitudconsulta.rsp");
      sc.Add( @"bin\gx0040.dll", cs_path + @"\gx0040.rsp");
      sc.Add( @"bin\gx0030.dll", cs_path + @"\gx0030.rsp");
      sc.Add( @"bin\viewgestionconsulta.dll", cs_path + @"\viewgestionconsulta.rsp");
      sc.Add( @"bin\gestionconsultaconsultapacientewc.dll", cs_path + @"\gestionconsultaconsultapacientewc.rsp");
      sc.Add( @"bin\gestionconsultageneral.dll", cs_path + @"\gestionconsultageneral.rsp");
      sc.Add( @"bin\wwgestionconsulta.dll", cs_path + @"\wwgestionconsulta.rsp");
      sc.Add( @"bin\consultapacientegeneral.dll", cs_path + @"\consultapacientegeneral.rsp");
      sc.Add( @"bin\wwconsultapaciente.dll", cs_path + @"\wwconsultapaciente.rsp");
      sc.Add( @"bin\viewconsultapaciente.dll", cs_path + @"\viewconsultapaciente.rsp");
      sc.Add( @"bin\viewenfermero.dll", cs_path + @"\viewenfermero.rsp");
      sc.Add( @"bin\enfermeromedico1wc.dll", cs_path + @"\enfermeromedico1wc.rsp");
      sc.Add( @"bin\enfermeromedicowc.dll", cs_path + @"\enfermeromedicowc.rsp");
      sc.Add( @"bin\enfermerogeneral.dll", cs_path + @"\enfermerogeneral.rsp");
      sc.Add( @"bin\wwenfermero.dll", cs_path + @"\wwenfermero.rsp");
      sc.Add( @"bin\appmastersd.dll", cs_path + @"\appmastersd.rsp");
      sc.Add( @"bin\tabbedview.dll", cs_path + @"\tabbedview.rsp");
      sc.Add( @"bin\home.dll", cs_path + @"\home.rsp");
      sc.Add( @"bin\notauthorized.dll", cs_path + @"\notauthorized.rsp");
      sc.Add( @"bin\promptmasterpage.dll", cs_path + @"\promptmasterpage.rsp");
      sc.Add( @"bin\recentlinks.dll", cs_path + @"\recentlinks.rsp");
      sc.Add( @"bin\appmasterpage.dll", cs_path + @"\appmasterpage.rsp");
      sc.Add( @"bin\gestionconsultapaciente.dll", cs_path + @"\gestionconsultapaciente.rsp");
      sc.Add( @"bin\historiaclinica.dll", cs_path + @"\historiaclinica.rsp");
      sc.Add( @"bin\gestionconsulta.dll", cs_path + @"\gestionconsulta.rsp");
      sc.Add( @"bin\consultapaciente.dll", cs_path + @"\consultapaciente.rsp");
      sc.Add( @"bin\turno.dll", cs_path + @"\turno.rsp");
      sc.Add( @"bin\consultorio.dll", cs_path + @"\consultorio.rsp");
      sc.Add( @"bin\consulta.dll", cs_path + @"\consulta.rsp");
      sc.Add( @"bin\paciente.dll", cs_path + @"\paciente.rsp");
      sc.Add( @"bin\enfermero.dll", cs_path + @"\enfermero.rsp");
      sc.Add( @"bin\especialidad.dll", cs_path + @"\especialidad.rsp");
      sc.Add( @"bin\medico.dll", cs_path + @"\medico.rsp");
      return sc ;
   }

   public override ItemCollection GetResBuildList( )
   {
      ItemCollection sc = new ItemCollection() ;
      sc.Add( @"bin\messages.spa.dll", cs_path + @"\messages.spa.txt");
      return sc ;
   }

   public override bool ToBuild( String obj )
   {
      if (checkTime(obj, cs_path + @"\bin\GxClasses.dll" ))
         return true;
      if ( obj == @"bin\GeneXus.Programs.Common.dll" )
      {
         if (checkTime(obj, cs_path + @"\type_SdtMessages_Message.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtLinkList_LinkItem.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtContext.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtGridState.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtGridState_FilterValue.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtProgramNames_ProgramName.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtTabOptions_TabOptionsItem.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtTransactionContext.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtTransactionContext_Attribute.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtTreeNodeCollection_TreeNode.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtEstadisticasSDT.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtEstadisticasSDT_EspecialidadesItem.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtEstadisticasSDT_EspecialidadesItem_MedicosItem.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtEstadisticasSDT_EspecialidadItem.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtEstadisticasSDT_EspecialidadItem_MedicoItem.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtEstadisticasSDT_EspecialidadesItem_MedicoItem.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\GxObjectCollection.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\GxSilentTrnGridCollection.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\SoapParm.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\GxWebStd.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\GxFullTextSearchReindexer.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\GxModelInfoProvider.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtGestionConsultaPaciente.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\type_SdtConsultaPaciente.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\GXDOMAINTrnMode.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\GXDOMAINRecentLinksOptions.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\GXDOMAINPage.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\GXDOMAINMessageTypes.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\GXDOMAINIMEMode.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\GXDOMAINHttpMethod.cs" ))
            return true;
         if (checkTime(obj, cs_path + @"\GXDOMAINEstadoCivil.cs" ))
            return true;
      }
      if ( obj == @"bin\messages.spa.dll" )
      {
         if (checkTime(obj, cs_path + @"\messages.spa.txt" ))
            return true;
      }
      return false ;
   }

}

