gx.evt.autoSkip=false;function gestionconsultapaciente(){this.ServerClass="GestionConsultaPaciente";this.PackageName="GeneXus.Programs";this.setObjectType("trn");this.hasEnterEvent=true;this.SetStandaloneVars=function(){this.A67UltimoNroAsig=gx.fn.getIntegerValue("ULTIMONROASIG",".");this.Gx_date=gx.fn.getDateValue("_TODAY");this.Gx_BScreen=gx.fn.getIntegerValue("_GXBSCREEN",".");this.A9EspecialidadId=gx.fn.getIntegerValue("ESPECIALIDADID",".");this.A61TurnoNombre=gx.fn.getControlValue("TURNONOMBRE");
this.Gx_mode=gx.fn.getControlValue("_MODE")};this.Valid_Consultafecha=function(){try{var a=gx.util.balloon.getNew("CONSULTAFECHA");this.AnyError=0;if(!((new gx.date.gxdate("").compare(this.A43ConsultaFecha)==0)||new gx.date.gxdate(this.A43ConsultaFecha).compare(gx.date.ymdtod(1753,1,1))>=0)){try{a.setError("Campo Consulta Fecha fuera de rango");this.AnyError=1}catch(b){}}}catch(b){}try{if(a==null){return true}return a.show()}catch(b){}return true};this.Valid_Pacienteid=function(){gx.ajax.validSrvEvt("dyncall","Valid_Pacienteid",["gx.O.A34PacienteId","gx.O.A36PacienteApellido","gx.O.A35PacienteNombre","gx.O.A41PacienteCI"],["A36PacienteApellido","A35PacienteNombre","A41PacienteCI"]);
return true};this.Valid_Medicoid=function(){gx.ajax.validSrvEvt("dyncall","Valid_Medicoid",["gx.O.A12MedicoId","gx.O.A9EspecialidadId","gx.O.A14MedicoApellido","gx.O.A13MedicoNombre","gx.O.A11EspecialidadMaxPacientes"],["A9EspecialidadId","A14MedicoApellido","A13MedicoNombre","A11EspecialidadMaxPacientes"]);return true};this.Valid_Turnoid=function(){gx.ajax.validSrvEvt("dyncall","Valid_Turnoid",["gx.O.Gx_mode","gx.O.O67UltimoNroAsig",'gx.date.urlDate(gx.O.A43ConsultaFecha,"DMY")',"gx.O.A34PacienteId","gx.O.A12MedicoId","gx.O.A60TurnoId","gx.O.A67UltimoNroAsig","gx.O.Gx_BScreen","gx.O.A63ConsultaNro","gx.O.A75Confirmado","gx.O.A61TurnoNombre"],["O67UltimoNroAsig","A75Confirmado","A36PacienteApellido","A35PacienteNombre","A41PacienteCI","A9EspecialidadId","A14MedicoApellido","A13MedicoNombre","A11EspecialidadMaxPacientes","A61TurnoNombre","A67UltimoNroAsig","A63ConsultaNro","Gx_mode","Z43ConsultaFecha","Z34PacienteId","Z12MedicoId","Z60TurnoId","Z75Confirmado","Z36PacienteApellido","Z35PacienteNombre","Z41PacienteCI","Z9EspecialidadId","Z14MedicoApellido","Z13MedicoNombre","Z11EspecialidadMaxPacientes","Z61TurnoNombre","Z67UltimoNroAsig","Z63ConsultaNro","O67UltimoNroAsig",["BTN_ENTER2","Enabled"]]);
return true};this.e120b2_client=function(){this.executeServerEvent("AFTER TRN",true)};this.e130b8_client=function(){this.executeServerEvent("ENTER",true)};this.e140b8_client=function(){this.executeServerEvent("CANCEL",true)};this.GXValidFnc=[];this.GXCtrlIds=[38,43,48,53,58,63,68,73,78,83,88,93];this.GXLastCtrlId=93;this.GXValidFnc[38]={lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Consultafecha,isvalid:null,fld:"CONSULTAFECHA",gxz:"Z43ConsultaFecha",gxold:"O43ConsultaFecha",gxvar:"A43ConsultaFecha",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[38],ip:[38],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A43ConsultaFecha=gx.fn.toDatetimeValue(a)
},v2z:function(a){gx.O.Z43ConsultaFecha=gx.fn.toDatetimeValue(a)},v2c:function(){gx.fn.setControlValue("CONSULTAFECHA",gx.O.A43ConsultaFecha,0)},c2v:function(){gx.O.A43ConsultaFecha=this.val()},val:function(){return gx.fn.getControlValue("CONSULTAFECHA")}};this.GXValidFnc[43]={lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Pacienteid,isvalid:null,rgrid:[],fld:"PACIENTEID",gxz:"Z34PacienteId",gxold:"O34PacienteId",gxvar:"A34PacienteId",ucs:[],op:[58,53,48],ip:[58,53,48,43],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A34PacienteId=gx.num.intval(a)
},v2z:function(a){gx.O.Z34PacienteId=gx.num.intval(a)},v2c:function(){gx.fn.setControlValue("PACIENTEID",gx.O.A34PacienteId,0)},c2v:function(){gx.O.A34PacienteId=this.val()},val:function(){return gx.fn.getIntegerValue("PACIENTEID",".")}};this.GXValidFnc[48]={lvl:0,type:"char",len:20,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,fld:"PACIENTEAPELLIDO",gxz:"Z36PacienteApellido",gxold:"O36PacienteApellido",gxvar:"A36PacienteApellido",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A36PacienteApellido=a
},v2z:function(a){gx.O.Z36PacienteApellido=a},v2c:function(){gx.fn.setControlValue("PACIENTEAPELLIDO",gx.O.A36PacienteApellido,0)},c2v:function(){gx.O.A36PacienteApellido=this.val()},val:function(){return gx.fn.getControlValue("PACIENTEAPELLIDO")}};this.GXValidFnc[53]={lvl:0,type:"char",len:20,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,fld:"PACIENTENOMBRE",gxz:"Z35PacienteNombre",gxold:"O35PacienteNombre",gxvar:"A35PacienteNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A35PacienteNombre=a
},v2z:function(a){gx.O.Z35PacienteNombre=a},v2c:function(){gx.fn.setControlValue("PACIENTENOMBRE",gx.O.A35PacienteNombre,0)},c2v:function(){gx.O.A35PacienteNombre=this.val()},val:function(){return gx.fn.getControlValue("PACIENTENOMBRE")}};this.GXValidFnc[58]={lvl:0,type:"char",len:8,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,fld:"PACIENTECI",gxz:"Z41PacienteCI",gxold:"O41PacienteCI",gxvar:"A41PacienteCI",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A41PacienteCI=a
},v2z:function(a){gx.O.Z41PacienteCI=a},v2c:function(){gx.fn.setControlValue("PACIENTECI",gx.O.A41PacienteCI,0)},c2v:function(){gx.O.A41PacienteCI=this.val()},val:function(){return gx.fn.getControlValue("PACIENTECI")}};this.GXValidFnc[63]={lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Medicoid,isvalid:null,rgrid:[],fld:"MEDICOID",gxz:"Z12MedicoId",gxold:"O12MedicoId",gxvar:"A12MedicoId",ucs:[],op:[78,73,68],ip:[78,73,68,63],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A12MedicoId=gx.num.intval(a)
},v2z:function(a){gx.O.Z12MedicoId=gx.num.intval(a)},v2c:function(){gx.fn.setControlValue("MEDICOID",gx.O.A12MedicoId,0)},c2v:function(){gx.O.A12MedicoId=this.val()},val:function(){return gx.fn.getIntegerValue("MEDICOID",".")}};this.GXValidFnc[68]={lvl:0,type:"char",len:20,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,fld:"MEDICOAPELLIDO",gxz:"Z14MedicoApellido",gxold:"O14MedicoApellido",gxvar:"A14MedicoApellido",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A14MedicoApellido=a
},v2z:function(a){gx.O.Z14MedicoApellido=a},v2c:function(){gx.fn.setControlValue("MEDICOAPELLIDO",gx.O.A14MedicoApellido,0)},c2v:function(){gx.O.A14MedicoApellido=this.val()},val:function(){return gx.fn.getControlValue("MEDICOAPELLIDO")}};this.GXValidFnc[73]={lvl:0,type:"char",len:20,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,fld:"MEDICONOMBRE",gxz:"Z13MedicoNombre",gxold:"O13MedicoNombre",gxvar:"A13MedicoNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A13MedicoNombre=a
},v2z:function(a){gx.O.Z13MedicoNombre=a},v2c:function(){gx.fn.setControlValue("MEDICONOMBRE",gx.O.A13MedicoNombre,0)},c2v:function(){gx.O.A13MedicoNombre=this.val()},val:function(){return gx.fn.getControlValue("MEDICONOMBRE")}};this.GXValidFnc[78]={lvl:0,type:"int",len:3,dec:0,sign:false,pic:"ZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,rgrid:[],fld:"ESPECIALIDADMAXPACIENTES",gxz:"Z11EspecialidadMaxPacientes",gxold:"O11EspecialidadMaxPacientes",gxvar:"A11EspecialidadMaxPacientes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A11EspecialidadMaxPacientes=gx.num.intval(a)
},v2z:function(a){gx.O.Z11EspecialidadMaxPacientes=gx.num.intval(a)},v2c:function(){gx.fn.setControlValue("ESPECIALIDADMAXPACIENTES",gx.O.A11EspecialidadMaxPacientes,0)},c2v:function(){gx.O.A11EspecialidadMaxPacientes=this.val()},val:function(){return gx.fn.getIntegerValue("ESPECIALIDADMAXPACIENTES",".")}};this.GXValidFnc[83]={lvl:0,type:"int",len:2,dec:0,sign:false,pic:"Z9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Turnoid,isvalid:null,rgrid:[],fld:"TURNOID",gxz:"Z60TurnoId",gxold:"O60TurnoId",gxvar:"A60TurnoId",ucs:[],op:[93,88],ip:[93,88,83,63,43,38],nacdep:[],ctrltype:"dyncombo",v2v:function(a){gx.O.A60TurnoId=gx.num.intval(a)
},v2z:function(a){gx.O.Z60TurnoId=gx.num.intval(a)},v2c:function(){gx.fn.setComboBoxValue("TURNOID",gx.O.A60TurnoId)},c2v:function(){gx.O.A60TurnoId=this.val()},val:function(){return gx.fn.getIntegerValue("TURNOID",".")}};this.GXValidFnc[88]={lvl:0,type:"int",len:2,dec:0,sign:false,pic:"Z9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,rgrid:[],fld:"CONSULTANRO",gxz:"Z63ConsultaNro",gxold:"O63ConsultaNro",gxvar:"A63ConsultaNro",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A63ConsultaNro=gx.num.intval(a)
},v2z:function(a){gx.O.Z63ConsultaNro=gx.num.intval(a)},v2c:function(){gx.fn.setControlValue("CONSULTANRO",gx.O.A63ConsultaNro,0)},c2v:function(){gx.O.A63ConsultaNro=this.val()},val:function(){return gx.fn.getIntegerValue("CONSULTANRO",".")}};this.GXValidFnc[93]={lvl:0,type:"boolean",len:4,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,fld:"CONFIRMADO",gxz:"Z75Confirmado",gxold:"O75Confirmado",gxvar:"A75Confirmado",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(a){gx.O.A75Confirmado=gx.lang.booleanValue(a)
},v2z:function(a){gx.O.Z75Confirmado=gx.lang.booleanValue(a)},v2c:function(){gx.fn.setCheckBoxValue("CONFIRMADO",gx.O.A75Confirmado,true)},c2v:function(){gx.O.A75Confirmado=this.val()},val:function(){return gx.fn.getCheckBoxValue("CONFIRMADO",true,false)}};this.A43ConsultaFecha=gx.date.nullDate();this.Z43ConsultaFecha=gx.date.nullDate();this.O43ConsultaFecha=gx.date.nullDate();this.A34PacienteId=0;this.Z34PacienteId=0;this.O34PacienteId=0;this.A36PacienteApellido="";this.Z36PacienteApellido="";this.O36PacienteApellido="";
this.A35PacienteNombre="";this.Z35PacienteNombre="";this.O35PacienteNombre="";this.A41PacienteCI="";this.Z41PacienteCI="";this.O41PacienteCI="";this.A12MedicoId=0;this.Z12MedicoId=0;this.O12MedicoId=0;this.A14MedicoApellido="";this.Z14MedicoApellido="";this.O14MedicoApellido="";this.A13MedicoNombre="";this.Z13MedicoNombre="";this.O13MedicoNombre="";this.A11EspecialidadMaxPacientes=0;this.Z11EspecialidadMaxPacientes=0;this.O11EspecialidadMaxPacientes=0;this.A60TurnoId=0;this.Z60TurnoId=0;this.O60TurnoId=0;
this.A63ConsultaNro=0;this.Z63ConsultaNro=0;this.O63ConsultaNro=0;this.A75Confirmado=false;this.Z75Confirmado=false;this.O75Confirmado=false;this.A9EspecialidadId=0;this.AV7Context={};this.A67UltimoNroAsig=0;this.Gx_BScreen=0;this.Gx_date=gx.date.nullDate();this.A61TurnoNombre="";this.ServerEvents=["e120b2_client","e130b8_client","e140b8_client"];this.setPrompt("PROMPT_34",[43]);this.setPrompt("PROMPT_12",[63]);this.setPrompt("PROMPT_43_60",[38,83]);this.EnterCtrl=["BTN_ENTER"];this.VarControlMap.A67UltimoNroAsig={id:"ULTIMONROASIG",grid:0,type:"int"};
this.VarControlMap.Gx_date={id:"_TODAY",grid:0,type:"date"};this.VarControlMap.Gx_BScreen={id:"_GXBSCREEN",grid:0,type:"int"};this.VarControlMap.A9EspecialidadId={id:"ESPECIALIDADID",grid:0,type:"int"};this.VarControlMap.A61TurnoNombre={id:"TURNONOMBRE",grid:0,type:"char"};this.VarControlMap.Gx_mode={id:"_MODE",grid:0,type:"char"};this.SetStandaloneVars();this.LvlOlds[8]=["O67UltimoNroAsig"]}gestionconsultapaciente.prototype=new gx.GxObject;gx.setParentObj(new gestionconsultapaciente());