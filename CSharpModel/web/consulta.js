gx.evt.autoSkip=false;function consulta(){this.ServerClass="Consulta";this.PackageName="GeneXus.Programs";this.setObjectType("trn");this.hasEnterEvent=true;this.SetStandaloneVars=function(){this.A11EspecialidadMaxPacientes=gx.fn.getIntegerValue("ESPECIALIDADMAXPACIENTES",".");this.AV13TurnosConsecutivos=gx.fn.getControlValue("_TURNOSCONSECUTIVOS");this.AV9ConsultorioAsignadoX=gx.fn.getIntegerValue("_CONSULTORIOASIGNADOX",".");this.AV7CantidadConsultas=gx.fn.getIntegerValue("_CANTIDADCONSULTAS",".");
this.AV11Ocupado=gx.fn.getControlValue("_OCUPADO");this.AV12TurnoOcupado=gx.fn.getControlValue("_TURNOOCUPADO");this.Gx_BScreen=gx.fn.getIntegerValue("_GXBSCREEN",".");this.Gx_date=gx.fn.getDateValue("_TODAY");this.AV10ConsultorioYaAsignado=gx.fn.getIntegerValue("_CONSULTORIOYAASIGNADO",".");this.A9EspecialidadId=gx.fn.getIntegerValue("ESPECIALIDADID",".");this.A61TurnoNombre=gx.fn.getControlValue("TURNONOMBRE");this.Gx_mode=gx.fn.getControlValue("_MODE")};this.Valid_Consultafecha=function(){try{var a=gx.util.balloon.getNew("CONSULTAFECHA");
this.AnyError=0;if(!((new gx.date.gxdate("").compare(this.A43ConsultaFecha)==0)||new gx.date.gxdate(this.A43ConsultaFecha).compare(gx.date.ymdtod(1753,1,1))>=0)){try{a.setError("Campo Consulta Fecha fuera de rango");this.AnyError=1}catch(b){}}}catch(b){}try{if(a==null){return true}return a.show()}catch(b){}return true};this.Valid_Medicoid=function(){gx.ajax.validSrvEvt("dyncall","Valid_Medicoid",["gx.O.A12MedicoId","gx.O.A9EspecialidadId",'gx.date.urlDate(gx.O.A43ConsultaFecha,"DMY")',"gx.O.AV9ConsultorioAsignadoX","gx.O.AV7CantidadConsultas","gx.O.A13MedicoNombre","gx.O.A14MedicoApellido","gx.O.A11EspecialidadMaxPacientes","gx.O.AV10ConsultorioYaAsignado"],["A9EspecialidadId","A13MedicoNombre","A14MedicoApellido","A11EspecialidadMaxPacientes","AV9ConsultorioAsignadoX","AV10ConsultorioYaAsignado","AV7CantidadConsultas"]);
return true};this.Valid_Turnoid=function(){gx.ajax.validSrvEvt("dyncall","Valid_Turnoid",['gx.date.urlDate(gx.O.A43ConsultaFecha,"DMY")',"gx.O.A12MedicoId","gx.O.A60TurnoId","gx.O.A11EspecialidadMaxPacientes","gx.O.A66CantNrosAsig","gx.O.AV13TurnosConsecutivos","gx.O.AV7CantidadConsultas","gx.O.AV12TurnoOcupado","gx.O.A67UltimoNroAsig","gx.O.A57ConsultorioId","gx.O.A61TurnoNombre","gx.O.A65NrosDisponibles"],["A57ConsultorioId","A67UltimoNroAsig","A9EspecialidadId","A13MedicoNombre","A14MedicoApellido","A11EspecialidadMaxPacientes","AV9ConsultorioAsignadoX","AV10ConsultorioYaAsignado","AV7CantidadConsultas","A61TurnoNombre","A66CantNrosAsig","A65NrosDisponibles","AV13TurnosConsecutivos","AV11Ocupado","AV12TurnoOcupado","A58ConsultorioDescripcion","Gx_mode","Z43ConsultaFecha","Z12MedicoId","Z60TurnoId","Z57ConsultorioId","Z67UltimoNroAsig","Z9EspecialidadId","Z13MedicoNombre","Z14MedicoApellido","Z11EspecialidadMaxPacientes","ZV9ConsultorioAsignadoX","ZV10ConsultorioYaAsignado","ZV7CantidadConsultas","Z61TurnoNombre","Z66CantNrosAsig","Z65NrosDisponibles","ZV13TurnosConsecutivos","ZV11Ocupado","ZV12TurnoOcupado","Z58ConsultorioDescripcion",["BTN_ENTER2","Enabled"]]);
return true};this.Valid_Consultorioid=function(){gx.ajax.validSrvEvt("dyncall","Valid_Consultorioid",["gx.O.A57ConsultorioId",'gx.date.urlDate(gx.O.A43ConsultaFecha,"DMY")',"gx.O.A60TurnoId","gx.O.AV7CantidadConsultas","gx.O.AV11Ocupado","gx.O.AV13TurnosConsecutivos","gx.O.AV9ConsultorioAsignadoX","gx.O.A58ConsultorioDescripcion"],["A58ConsultorioDescripcion","AV11Ocupado"]);return true};this.Valid_Cantnrosasig=function(){try{var a=gx.util.balloon.getNew("CANTNROSASIG");this.AnyError=0}catch(b){}try{if(a==null){return true
}return a.show()}catch(b){}return true};this.e11055_client=function(){this.executeServerEvent("ENTER",true)};this.e12055_client=function(){this.executeServerEvent("CANCEL",true)};this.GXValidFnc=[];this.GXCtrlIds=[38,43,48,53,58,63,68,73,78,83];this.GXLastCtrlId=83;this.GXValidFnc[38]={lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Consultafecha,isvalid:null,fld:"CONSULTAFECHA",gxz:"Z43ConsultaFecha",gxold:"O43ConsultaFecha",gxvar:"A43ConsultaFecha",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[38],ip:[38],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A43ConsultaFecha=gx.fn.toDatetimeValue(a)
},v2z:function(a){gx.O.Z43ConsultaFecha=gx.fn.toDatetimeValue(a)},v2c:function(){gx.fn.setControlValue("CONSULTAFECHA",gx.O.A43ConsultaFecha,0)},c2v:function(){gx.O.A43ConsultaFecha=this.val()},val:function(){return gx.fn.getControlValue("CONSULTAFECHA")}};this.GXValidFnc[43]={lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Medicoid,isvalid:null,rgrid:[],fld:"MEDICOID",gxz:"Z12MedicoId",gxold:"O12MedicoId",gxvar:"A12MedicoId",ucs:[],op:[53,48],ip:[53,48,38,43],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A12MedicoId=gx.num.intval(a)
},v2z:function(a){gx.O.Z12MedicoId=gx.num.intval(a)},v2c:function(){gx.fn.setControlValue("MEDICOID",gx.O.A12MedicoId,0)},c2v:function(){gx.O.A12MedicoId=this.val()},val:function(){return gx.fn.getIntegerValue("MEDICOID",".")}};this.GXValidFnc[48]={lvl:0,type:"char",len:20,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,fld:"MEDICONOMBRE",gxz:"Z13MedicoNombre",gxold:"O13MedicoNombre",gxvar:"A13MedicoNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A13MedicoNombre=a
},v2z:function(a){gx.O.Z13MedicoNombre=a},v2c:function(){gx.fn.setControlValue("MEDICONOMBRE",gx.O.A13MedicoNombre,0)},c2v:function(){gx.O.A13MedicoNombre=this.val()},val:function(){return gx.fn.getControlValue("MEDICONOMBRE")}};this.GXValidFnc[53]={lvl:0,type:"char",len:20,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,fld:"MEDICOAPELLIDO",gxz:"Z14MedicoApellido",gxold:"O14MedicoApellido",gxvar:"A14MedicoApellido",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A14MedicoApellido=a
},v2z:function(a){gx.O.Z14MedicoApellido=a},v2c:function(){gx.fn.setControlValue("MEDICOAPELLIDO",gx.O.A14MedicoApellido,0)},c2v:function(){gx.O.A14MedicoApellido=this.val()},val:function(){return gx.fn.getControlValue("MEDICOAPELLIDO")}};this.GXValidFnc[58]={lvl:0,type:"int",len:2,dec:0,sign:false,pic:"Z9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Turnoid,isvalid:null,rgrid:[],fld:"TURNOID",gxz:"Z60TurnoId",gxold:"O60TurnoId",gxvar:"A60TurnoId",ucs:[],op:[78,73,63,83],ip:[78,63,83,73,58,43,38],nacdep:[],ctrltype:"dyncombo",v2v:function(a){gx.O.A60TurnoId=gx.num.intval(a)
},v2z:function(a){gx.O.Z60TurnoId=gx.num.intval(a)},v2c:function(){gx.fn.setComboBoxValue("TURNOID",gx.O.A60TurnoId)},c2v:function(){gx.O.A60TurnoId=this.val()},val:function(){return gx.fn.getIntegerValue("TURNOID",".")}};this.GXValidFnc[63]={lvl:0,type:"int",len:3,dec:0,sign:false,pic:"ZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Consultorioid,isvalid:null,rgrid:[],fld:"CONSULTORIOID",gxz:"Z57ConsultorioId",gxold:"O57ConsultorioId",gxvar:"A57ConsultorioId",ucs:[],op:[63,68],ip:[68,58,38,63],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A57ConsultorioId=gx.num.intval(a)
},v2z:function(a){gx.O.Z57ConsultorioId=gx.num.intval(a)},v2c:function(){gx.fn.setControlValue("CONSULTORIOID",gx.O.A57ConsultorioId,0)},c2v:function(){gx.O.A57ConsultorioId=this.val()},val:function(){return gx.fn.getIntegerValue("CONSULTORIOID",".")}};this.GXValidFnc[68]={lvl:0,type:"char",len:30,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,fld:"CONSULTORIODESCRIPCION",gxz:"Z58ConsultorioDescripcion",gxold:"O58ConsultorioDescripcion",gxvar:"A58ConsultorioDescripcion",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A58ConsultorioDescripcion=a
},v2z:function(a){gx.O.Z58ConsultorioDescripcion=a},v2c:function(){gx.fn.setControlValue("CONSULTORIODESCRIPCION",gx.O.A58ConsultorioDescripcion,0)},c2v:function(){gx.O.A58ConsultorioDescripcion=this.val()},val:function(){return gx.fn.getControlValue("CONSULTORIODESCRIPCION")}};this.GXValidFnc[73]={lvl:0,type:"int",len:2,dec:0,sign:false,pic:"Z9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Cantnrosasig,isvalid:null,rgrid:[],fld:"CANTNROSASIG",gxz:"Z66CantNrosAsig",gxold:"O66CantNrosAsig",gxvar:"A66CantNrosAsig",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A66CantNrosAsig=gx.num.intval(a)
},v2z:function(a){gx.O.Z66CantNrosAsig=gx.num.intval(a)},v2c:function(){gx.fn.setControlValue("CANTNROSASIG",gx.O.A66CantNrosAsig,0)},c2v:function(){gx.O.A66CantNrosAsig=this.val()},val:function(){return gx.fn.getIntegerValue("CANTNROSASIG",".")}};this.GXValidFnc[78]={lvl:0,type:"int",len:2,dec:0,sign:false,pic:"Z9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,rgrid:[],fld:"NROSDISPONIBLES",gxz:"Z65NrosDisponibles",gxold:"O65NrosDisponibles",gxvar:"A65NrosDisponibles",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A65NrosDisponibles=gx.num.intval(a)
},v2z:function(a){gx.O.Z65NrosDisponibles=gx.num.intval(a)},v2c:function(){gx.fn.setControlValue("NROSDISPONIBLES",gx.O.A65NrosDisponibles,0)},c2v:function(){gx.O.A65NrosDisponibles=this.val()},val:function(){return gx.fn.getIntegerValue("NROSDISPONIBLES",".")}};this.GXValidFnc[83]={lvl:0,type:"int",len:2,dec:0,sign:false,pic:"Z9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,rgrid:[],fld:"ULTIMONROASIG",gxz:"Z67UltimoNroAsig",gxold:"O67UltimoNroAsig",gxvar:"A67UltimoNroAsig",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A67UltimoNroAsig=gx.num.intval(a)
},v2z:function(a){gx.O.Z67UltimoNroAsig=gx.num.intval(a)},v2c:function(){gx.fn.setControlValue("ULTIMONROASIG",gx.O.A67UltimoNroAsig,0)},c2v:function(){gx.O.A67UltimoNroAsig=this.val()},val:function(){return gx.fn.getIntegerValue("ULTIMONROASIG",".")}};this.A43ConsultaFecha=gx.date.nullDate();this.Z43ConsultaFecha=gx.date.nullDate();this.O43ConsultaFecha=gx.date.nullDate();this.A12MedicoId=0;this.Z12MedicoId=0;this.O12MedicoId=0;this.A13MedicoNombre="";this.Z13MedicoNombre="";this.O13MedicoNombre="";
this.A14MedicoApellido="";this.Z14MedicoApellido="";this.O14MedicoApellido="";this.A60TurnoId=0;this.Z60TurnoId=0;this.O60TurnoId=0;this.A57ConsultorioId=0;this.Z57ConsultorioId=0;this.O57ConsultorioId=0;this.A58ConsultorioDescripcion="";this.Z58ConsultorioDescripcion="";this.O58ConsultorioDescripcion="";this.A66CantNrosAsig=0;this.Z66CantNrosAsig=0;this.O66CantNrosAsig=0;this.A65NrosDisponibles=0;this.Z65NrosDisponibles=0;this.O65NrosDisponibles=0;this.A67UltimoNroAsig=0;this.Z67UltimoNroAsig=0;
this.O67UltimoNroAsig=0;this.A9EspecialidadId=0;this.AV13TurnosConsecutivos=false;this.AV9ConsultorioAsignadoX=0;this.AV7CantidadConsultas=0;this.AV11Ocupado=false;this.AV12TurnoOcupado=false;this.Gx_BScreen=0;this.Gx_date=gx.date.nullDate();this.A61TurnoNombre="";this.AV10ConsultorioYaAsignado=0;this.A11EspecialidadMaxPacientes=0;this.ServerEvents=["e11055_client","e12055_client"];this.setPrompt("PROMPT_12",[43]);this.setPrompt("PROMPT_57",[63]);this.EnterCtrl=["BTN_ENTER"];this.VarControlMap.A11EspecialidadMaxPacientes={id:"ESPECIALIDADMAXPACIENTES",grid:0,type:"int"};
this.VarControlMap.AV13TurnosConsecutivos={id:"_TURNOSCONSECUTIVOS",grid:0,type:"boolean"};this.VarControlMap.AV9ConsultorioAsignadoX={id:"_CONSULTORIOASIGNADOX",grid:0,type:"int"};this.VarControlMap.AV7CantidadConsultas={id:"_CANTIDADCONSULTAS",grid:0,type:"int"};this.VarControlMap.AV11Ocupado={id:"_OCUPADO",grid:0,type:"boolean"};this.VarControlMap.AV12TurnoOcupado={id:"_TURNOOCUPADO",grid:0,type:"boolean"};this.VarControlMap.Gx_BScreen={id:"_GXBSCREEN",grid:0,type:"int"};this.VarControlMap.Gx_date={id:"_TODAY",grid:0,type:"date"};
this.VarControlMap.AV10ConsultorioYaAsignado={id:"_CONSULTORIOYAASIGNADO",grid:0,type:"int"};this.VarControlMap.A9EspecialidadId={id:"ESPECIALIDADID",grid:0,type:"int"};this.VarControlMap.A61TurnoNombre={id:"TURNONOMBRE",grid:0,type:"char"};this.VarControlMap.Gx_mode={id:"_MODE",grid:0,type:"char"};this.SetStandaloneVars()}consulta.prototype=new gx.GxObject;gx.setParentObj(new consulta());