gx.evt.autoSkip=false;function viewgestionconsulta(){this.ServerClass="ViewGestionConsulta";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.hasEnterEvent=false;this.autoRefresh=true;this.SetStandaloneVars=function(){this.AV11ConsultaFecha=gx.fn.getDateValue("_CONSULTAFECHA");this.AV12MedicoId=gx.fn.getIntegerValue("_MEDICOID",".");this.AV13TurnoId=gx.fn.getIntegerValue("_TURNOID",".");this.AV7TabCode=gx.fn.getControlValue("_TABCODE")};this.s112_client=function(){this.AV8Tabs=[];
this.AV9Tab={Code:"",Description:"",Link:"",WebComponent:""};this.AV9Tab.Code="General";this.AV9Tab.Description="General";this.AV9Tab.WebComponent=gx.http.formatLink("gestionconsultageneral.aspx",[this.AV11ConsultaFecha,this.AV12MedicoId,this.AV13TurnoId]);this.AV9Tab.Link=gx.http.formatLink("viewgestionconsulta.aspx",[this.AV11ConsultaFecha,this.AV12MedicoId,this.AV13TurnoId,this.AV9Tab.Code]);this.AV8Tabs.push(this.AV9Tab);this.AV9Tab={Code:"",Description:"",Link:"",WebComponent:""};this.AV9Tab.Code="ConsultaPaciente";
this.AV9Tab.Description="Consulta Paciente";this.AV9Tab.WebComponent=gx.http.formatLink("gestionconsultaconsultapacientewc.aspx",[this.AV11ConsultaFecha,this.AV12MedicoId,this.AV13TurnoId]);this.AV9Tab.Link=gx.http.formatLink("viewgestionconsulta.aspx",[this.AV11ConsultaFecha,this.AV12MedicoId,this.AV13TurnoId,this.AV9Tab.Code]);this.AV8Tabs.push(this.AV9Tab)};this.e130j2_client=function(){this.executeServerEvent("ENTER",true)};this.e140j2_client=function(){this.executeServerEvent("CANCEL",true)};
this.GXValidFnc=[];this.GXLastCtrlId=0;this.AV11ConsultaFecha=gx.date.nullDate();this.AV12MedicoId=0;this.AV13TurnoId=0;this.AV7TabCode="";this.A60TurnoId=0;this.A12MedicoId=0;this.A43ConsultaFecha=gx.date.nullDate();this.A57ConsultorioId=0;this.AV9Tab={};this.AV8Tabs=[];this.ServerEvents=["e130j2_client","e140j2_client"];this.VarControlMap.AV11ConsultaFecha={id:"_CONSULTAFECHA",grid:0,type:"date"};this.VarControlMap.AV12MedicoId={id:"_MEDICOID",grid:0,type:"int"};this.VarControlMap.AV13TurnoId={id:"_TURNOID",grid:0,type:"int"};
this.VarControlMap.AV7TabCode={id:"_TABCODE",grid:0,type:"char"};this.SetStandaloneVars();this.setComponent({id:"TABBEDVIEW",GXClass:null,Prefix:"W0017",lvl:1})}viewgestionconsulta.prototype=new gx.GxObject;gx.setParentObj(new viewgestionconsulta());