gx.evt.autoSkip=false;function enfermerogeneral(a){this.ServerClass="EnfermeroGeneral";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.setCmpContext(a);this.ReadonlyForm=true;this.hasEnterEvent=false;this.autoRefresh=true;this.SetStandaloneVars=function(){};this.Valid_Enfermeroid=function(){try{var b=gx.util.balloon.getNew("ENFERMEROID");this.AnyError=0}catch(c){}try{if(b==null){return true}return b.show()}catch(c){}return true};this.e13092_client=function(){this.executeServerEvent("'DOUPDATE'",false)
};this.e14092_client=function(){this.executeServerEvent("'DODELETE'",false)};this.e15092_client=function(){this.executeServerEvent("ENTER",true)};this.e16092_client=function(){this.executeServerEvent("CANCEL",true)};this.GXValidFnc=[];this.GXCtrlIds=[7,12,17,22,27,32];this.GXLastCtrlId=32;this.GXValidFnc[7]={lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Enfermeroid,isvalid:null,rgrid:[],fld:"ENFERMEROID",gxz:"Z20EnfermeroId",gxold:"O20EnfermeroId",gxvar:"A20EnfermeroId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(b){gx.O.A20EnfermeroId=gx.num.intval(b)
},v2z:function(b){gx.O.Z20EnfermeroId=gx.num.intval(b)},v2c:function(){gx.fn.setControlValue("ENFERMEROID",gx.O.A20EnfermeroId,0)},c2v:function(){gx.O.A20EnfermeroId=this.val()},val:function(){return gx.fn.getIntegerValue("ENFERMEROID",".")}};this.GXValidFnc[12]={lvl:0,type:"char",len:20,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,fld:"ENFERMERONOMBRE",gxz:"Z21EnfermeroNombre",gxold:"O21EnfermeroNombre",gxvar:"A21EnfermeroNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(b){gx.O.A21EnfermeroNombre=b
},v2z:function(b){gx.O.Z21EnfermeroNombre=b},v2c:function(){gx.fn.setControlValue("ENFERMERONOMBRE",gx.O.A21EnfermeroNombre,0)},c2v:function(){gx.O.A21EnfermeroNombre=this.val()},val:function(){return gx.fn.getControlValue("ENFERMERONOMBRE")}};this.GXValidFnc[17]={lvl:0,type:"char",len:20,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,fld:"ENFERMEROAPELLIDO",gxz:"Z22EnfermeroApellido",gxold:"O22EnfermeroApellido",gxvar:"A22EnfermeroApellido",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(b){gx.O.A22EnfermeroApellido=b
},v2z:function(b){gx.O.Z22EnfermeroApellido=b},v2c:function(){gx.fn.setControlValue("ENFERMEROAPELLIDO",gx.O.A22EnfermeroApellido,0)},c2v:function(){gx.O.A22EnfermeroApellido=this.val()},val:function(){return gx.fn.getControlValue("ENFERMEROAPELLIDO")}};this.GXValidFnc[22]={lvl:0,type:"char",len:40,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,fld:"ENFERMERODOMICILIO",gxz:"Z23EnfermeroDomicilio",gxold:"O23EnfermeroDomicilio",gxvar:"A23EnfermeroDomicilio",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(b){gx.O.A23EnfermeroDomicilio=b
},v2z:function(b){gx.O.Z23EnfermeroDomicilio=b},v2c:function(){gx.fn.setControlValue("ENFERMERODOMICILIO",gx.O.A23EnfermeroDomicilio,0)},c2v:function(){gx.O.A23EnfermeroDomicilio=this.val()},val:function(){return gx.fn.getControlValue("ENFERMERODOMICILIO")}};this.GXValidFnc[27]={lvl:0,type:"char",len:1,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,fld:"ENFERMEROESTADOCIVIL",gxz:"Z24EnfermeroEstadoCivil",gxold:"O24EnfermeroEstadoCivil",gxvar:"A24EnfermeroEstadoCivil",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(b){gx.O.A24EnfermeroEstadoCivil=b
},v2z:function(b){gx.O.Z24EnfermeroEstadoCivil=b},v2c:function(){gx.fn.setComboBoxValue("ENFERMEROESTADOCIVIL",gx.O.A24EnfermeroEstadoCivil)},c2v:function(){gx.O.A24EnfermeroEstadoCivil=this.val()},val:function(){return gx.fn.getControlValue("ENFERMEROESTADOCIVIL")}};this.GXValidFnc[32]={lvl:0,type:"date",len:8,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,fld:"ENFERMEROFECHAINGRESO",gxz:"Z25EnfermeroFechaIngreso",gxold:"O25EnfermeroFechaIngreso",gxvar:"A25EnfermeroFechaIngreso",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(b){gx.O.A25EnfermeroFechaIngreso=gx.fn.toDatetimeValue(b)
},v2z:function(b){gx.O.Z25EnfermeroFechaIngreso=gx.fn.toDatetimeValue(b)},v2c:function(){gx.fn.setControlValue("ENFERMEROFECHAINGRESO",gx.O.A25EnfermeroFechaIngreso,0)},c2v:function(){gx.O.A25EnfermeroFechaIngreso=this.val()},val:function(){return gx.fn.getControlValue("ENFERMEROFECHAINGRESO")}};this.A20EnfermeroId=0;this.Z20EnfermeroId=0;this.O20EnfermeroId=0;this.A21EnfermeroNombre="";this.Z21EnfermeroNombre="";this.O21EnfermeroNombre="";this.A22EnfermeroApellido="";this.Z22EnfermeroApellido="";
this.O22EnfermeroApellido="";this.A23EnfermeroDomicilio="";this.Z23EnfermeroDomicilio="";this.O23EnfermeroDomicilio="";this.A24EnfermeroEstadoCivil="";this.Z24EnfermeroEstadoCivil="";this.O24EnfermeroEstadoCivil="";this.A25EnfermeroFechaIngreso=gx.date.nullDate();this.Z25EnfermeroFechaIngreso=gx.date.nullDate();this.O25EnfermeroFechaIngreso=gx.date.nullDate();this.ServerEvents=["e13092_client","e14092_client","e15092_client","e16092_client"];this.SetStandaloneVars()};