gx.evt.autoSkip=false;function viewhistoriaclinica(){this.ServerClass="ViewHistoriaClinica";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.hasEnterEvent=false;this.autoRefresh=true;this.SetStandaloneVars=function(){this.AV11ConsultaFecha=gx.fn.getDateValue("_CONSULTAFECHA");this.AV12PacienteId=gx.fn.getIntegerValue("_PACIENTEID",".");this.AV13MedicoId=gx.fn.getIntegerValue("_MEDICOID",".");this.AV14TurnoId=gx.fn.getIntegerValue("_TURNOID",".");this.AV7TabCode=gx.fn.getControlValue("_TABCODE")
};this.s112_client=function(){this.AV8Tabs=[];this.AV9Tab={Code:"",Description:"",Link:"",WebComponent:""};this.AV9Tab.Code="General";this.AV9Tab.Description="General";this.AV9Tab.WebComponent=gx.http.formatLink("historiaclinicageneral.aspx",[this.AV11ConsultaFecha,this.AV12PacienteId,this.AV13MedicoId,this.AV14TurnoId]);this.AV9Tab.Link=gx.http.formatLink("viewhistoriaclinica.aspx",[this.AV11ConsultaFecha,this.AV12PacienteId,this.AV13MedicoId,this.AV14TurnoId,this.AV9Tab.Code]);this.AV8Tabs.push(this.AV9Tab)
};this.e13102_client=function(){this.executeServerEvent("ENTER",true)};this.e14102_client=function(){this.executeServerEvent("CANCEL",true)};this.GXValidFnc=[];this.GXCtrlIds=[18];this.GXLastCtrlId=18;this.GXValidFnc[18]={lvl:0,type:"int",len:2,dec:0,sign:false,pic:"Z9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,rgrid:[],fld:"CONSULTANRO",gxz:"Z63ConsultaNro",gxold:"O63ConsultaNro",gxvar:"A63ConsultaNro",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A63ConsultaNro=gx.num.intval(a)
},v2z:function(a){gx.O.Z63ConsultaNro=gx.num.intval(a)},v2c:function(){gx.fn.setControlValue("CONSULTANRO",gx.O.A63ConsultaNro,0)},c2v:function(){gx.O.A63ConsultaNro=this.val()},val:function(){return gx.fn.getIntegerValue("CONSULTANRO",".")}};this.A63ConsultaNro=0;this.Z63ConsultaNro=0;this.O63ConsultaNro=0;this.AV11ConsultaFecha=gx.date.nullDate();this.AV12PacienteId=0;this.AV13MedicoId=0;this.AV14TurnoId=0;this.AV7TabCode="";this.A60TurnoId=0;this.A12MedicoId=0;this.A34PacienteId=0;this.A43ConsultaFecha=gx.date.nullDate();
this.AV9Tab={};this.AV8Tabs=[];this.ServerEvents=["e13102_client","e14102_client"];this.VarControlMap.AV11ConsultaFecha={id:"_CONSULTAFECHA",grid:0,type:"date"};this.VarControlMap.AV12PacienteId={id:"_PACIENTEID",grid:0,type:"int"};this.VarControlMap.AV13MedicoId={id:"_MEDICOID",grid:0,type:"int"};this.VarControlMap.AV14TurnoId={id:"_TURNOID",grid:0,type:"int"};this.VarControlMap.AV7TabCode={id:"_TABCODE",grid:0,type:"char"};this.SetStandaloneVars();this.setComponent({id:"TABBEDVIEW",GXClass:null,Prefix:"W0022",lvl:1})
}viewhistoriaclinica.prototype=new gx.GxObject;gx.setParentObj(new viewhistoriaclinica());