gx.evt.autoSkip=false;function gx0080(){this.ServerClass="Gx0080";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.hasEnterEvent=true;this.autoRefresh=true;this.SetStandaloneVars=function(){this.AV12pConsultaFecha=gx.fn.getDateValue("_PCONSULTAFECHA");this.AV13pPacienteId=gx.fn.getIntegerValue("_PPACIENTEID",".");this.AV14pMedicoId=gx.fn.getIntegerValue("_PMEDICOID",".");this.AV15pTurnoId=gx.fn.getIntegerValue("_PTURNOID",".")};this.Valid_Turnoid=function(){try{if(gx.fn.currentGridRowImpl(46)===0){return true
}var a=gx.util.balloon.getNew("TURNOID",gx.fn.currentGridRowImpl(46));this.AnyError=0}catch(b){}try{if(a==null){return true}return a.show()}catch(b){}return true};this.e130u2_client=function(){this.executeServerEvent("ENTER",true,arguments[0])};this.e140u2_client=function(){this.executeServerEvent("CANCEL",true,arguments[0])};this.GXValidFnc=[];this.GXCtrlIds=[14,19,24,29,34,39,47,48,49,50,51,52,53,54];this.GXLastCtrlId=54;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",46,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx0080",[],false,1,false,true,10,true,false,false,"",0,"px","Nueva fila",true,false,false,null,null,false,"");
this.Grid1Container.addBitmap("&Linkselection","_LINKSELECTION",47,0,"px",17,"px",null,"","");this.Grid1Container.addSingleLineEdit(43,48,"CONSULTAFECHA","Consul. Fecha","","ConsultaFecha","date",0,"px",8,8,"right",null,[],43,"ConsultaFecha",true,0,false,false);this.Grid1Container.addSingleLineEdit(34,49,"PACIENTEID","Id","","PacienteId","int",0,"px",6,6,"right",null,[],34,"PacienteId",true,0,false,false);this.Grid1Container.addSingleLineEdit(12,50,"MEDICOID","Medico Id","","MedicoId","int",0,"px",6,6,"right",null,[],12,"MedicoId",true,0,false,false);
this.Grid1Container.addSingleLineEdit(61,51,"TURNONOMBRE","Turno Nombre","","TurnoNombre","char",0,"px",20,20,"left",null,[],61,"TurnoNombre",true,0,false,false);this.Grid1Container.addSingleLineEdit(63,52,"CONSULTANRO","Nro","Seleccionar","ConsultaNro","int",0,"px",2,2,"right",null,[],63,"ConsultaNro",true,0,false,false);this.Grid1Container.addCheckBox(75,53,"CONFIRMADO","Confirmado","","Confirmado","boolean","true","false",null,true,false,0,"px");this.Grid1Container.addComboBox(60,54,"TURNOID","Turno Id","TurnoId","int",null,0,false,false,0,"px");
this.setGrid(this.Grid1Container);this.GXValidFnc[14]={lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,fld:"_CCONSULTAFECHA",gxz:"ZV6cConsultaFecha",gxold:"OV6cConsultaFecha",gxvar:"AV6cConsultaFecha",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.AV6cConsultaFecha=gx.fn.toDatetimeValue(a)},v2z:function(a){gx.O.ZV6cConsultaFecha=gx.fn.toDatetimeValue(a)},v2c:function(){gx.fn.setControlValue("_CCONSULTAFECHA",gx.O.AV6cConsultaFecha,0)
},c2v:function(){gx.O.AV6cConsultaFecha=this.val()},val:function(){return gx.fn.getControlValue("_CCONSULTAFECHA")}};this.GXValidFnc[19]={lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,rgrid:[this.Grid1Container],fld:"_CPACIENTEID",gxz:"ZV7cPacienteId",gxold:"OV7cPacienteId",gxvar:"AV7cPacienteId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.AV7cPacienteId=gx.num.intval(a)},v2z:function(a){gx.O.ZV7cPacienteId=gx.num.intval(a)
},v2c:function(){gx.fn.setControlValue("_CPACIENTEID",gx.O.AV7cPacienteId,0)},c2v:function(){gx.O.AV7cPacienteId=this.val()},val:function(){return gx.fn.getIntegerValue("_CPACIENTEID",".")}};this.GXValidFnc[24]={lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,rgrid:[this.Grid1Container],fld:"_CMEDICOID",gxz:"ZV8cMedicoId",gxold:"OV8cMedicoId",gxvar:"AV8cMedicoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.AV8cMedicoId=gx.num.intval(a)
},v2z:function(a){gx.O.ZV8cMedicoId=gx.num.intval(a)},v2c:function(){gx.fn.setControlValue("_CMEDICOID",gx.O.AV8cMedicoId,0)},c2v:function(){gx.O.AV8cMedicoId=this.val()},val:function(){return gx.fn.getIntegerValue("_CMEDICOID",".")}};this.GXValidFnc[29]={lvl:0,type:"char",len:20,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,fld:"_CTURNONOMBRE",gxz:"ZV9cTurnoNombre",gxold:"OV9cTurnoNombre",gxvar:"AV9cTurnoNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.AV9cTurnoNombre=a
},v2z:function(a){gx.O.ZV9cTurnoNombre=a},v2c:function(){gx.fn.setControlValue("_CTURNONOMBRE",gx.O.AV9cTurnoNombre,0)},c2v:function(){gx.O.AV9cTurnoNombre=this.val()},val:function(){return gx.fn.getControlValue("_CTURNONOMBRE")}};this.GXValidFnc[34]={lvl:0,type:"int",len:2,dec:0,sign:false,pic:"Z9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,rgrid:[this.Grid1Container],fld:"_CCONSULTANRO",gxz:"ZV10cConsultaNro",gxold:"OV10cConsultaNro",gxvar:"AV10cConsultaNro",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.AV10cConsultaNro=gx.num.intval(a)
},v2z:function(a){gx.O.ZV10cConsultaNro=gx.num.intval(a)},v2c:function(){gx.fn.setControlValue("_CCONSULTANRO",gx.O.AV10cConsultaNro,0)},c2v:function(){gx.O.AV10cConsultaNro=this.val()},val:function(){return gx.fn.getIntegerValue("_CCONSULTANRO",".")}};this.GXValidFnc[39]={lvl:0,type:"boolean",len:4,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,fld:"_CCONFIRMADO",gxz:"ZV11cConfirmado",gxold:"OV11cConfirmado",gxvar:"AV11cConfirmado",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(a){gx.O.AV11cConfirmado=gx.lang.booleanValue(a)
},v2z:function(a){gx.O.ZV11cConfirmado=gx.lang.booleanValue(a)},v2c:function(){gx.fn.setCheckBoxValue("_CCONFIRMADO",gx.O.AV11cConfirmado,true)},c2v:function(){gx.O.AV11cConfirmado=this.val()},val:function(){return gx.fn.getCheckBoxValue("_CCONFIRMADO",true,false)}};this.GXValidFnc[47]={lvl:2,type:"bits",len:4,dec:0,sign:false,ro:1,grid:46,gxgrid:this.Grid1Container,fnc:null,isvalid:null,fld:"_LINKSELECTION",gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.AV5LinkSelection=a
},v2z:function(a){gx.O.ZV5LinkSelection=a},v2c:function(){},c2v:function(){gx.O.AV5LinkSelection=this.val()},val:function(){return gx.fn.getGridControlValue("_LINKSELECTION",gx.fn.currentGridRowImpl(46))},nac:function(){return false}};this.GXValidFnc[48]={lvl:2,type:"date",len:8,dec:0,sign:false,ro:1,grid:46,gxgrid:this.Grid1Container,fnc:null,isvalid:null,fld:"CONSULTAFECHA",gxz:"Z43ConsultaFecha",gxold:"O43ConsultaFecha",gxvar:"A43ConsultaFecha",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A43ConsultaFecha=gx.fn.toDatetimeValue(a)
},v2z:function(a){gx.O.Z43ConsultaFecha=gx.fn.toDatetimeValue(a)},v2c:function(){gx.fn.setGridControlValue("CONSULTAFECHA",gx.fn.currentGridRowImpl(46),gx.O.A43ConsultaFecha,0)},c2v:function(){gx.O.A43ConsultaFecha=this.val()},val:function(){return gx.fn.getGridControlValue("CONSULTAFECHA",gx.fn.currentGridRowImpl(46))},nac:function(){return false}};this.GXValidFnc[49]={lvl:2,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:1,grid:46,gxgrid:this.Grid1Container,fnc:null,isvalid:null,rgrid:[],fld:"PACIENTEID",gxz:"Z34PacienteId",gxold:"O34PacienteId",gxvar:"A34PacienteId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A34PacienteId=gx.num.intval(a)
},v2z:function(a){gx.O.Z34PacienteId=gx.num.intval(a)},v2c:function(){gx.fn.setGridControlValue("PACIENTEID",gx.fn.currentGridRowImpl(46),gx.O.A34PacienteId,0)},c2v:function(){gx.O.A34PacienteId=this.val()},val:function(){return gx.fn.getGridIntegerValue("PACIENTEID",gx.fn.currentGridRowImpl(46),".")},nac:function(){return false}};this.GXValidFnc[50]={lvl:2,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:1,grid:46,gxgrid:this.Grid1Container,fnc:null,isvalid:null,rgrid:[],fld:"MEDICOID",gxz:"Z12MedicoId",gxold:"O12MedicoId",gxvar:"A12MedicoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A12MedicoId=gx.num.intval(a)
},v2z:function(a){gx.O.Z12MedicoId=gx.num.intval(a)},v2c:function(){gx.fn.setGridControlValue("MEDICOID",gx.fn.currentGridRowImpl(46),gx.O.A12MedicoId,0)},c2v:function(){gx.O.A12MedicoId=this.val()},val:function(){return gx.fn.getGridIntegerValue("MEDICOID",gx.fn.currentGridRowImpl(46),".")},nac:function(){return false}};this.GXValidFnc[51]={lvl:2,type:"char",len:20,dec:0,sign:false,ro:1,grid:46,gxgrid:this.Grid1Container,fnc:null,isvalid:null,fld:"TURNONOMBRE",gxz:"Z61TurnoNombre",gxold:"O61TurnoNombre",gxvar:"A61TurnoNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A61TurnoNombre=a
},v2z:function(a){gx.O.Z61TurnoNombre=a},v2c:function(){gx.fn.setGridControlValue("TURNONOMBRE",gx.fn.currentGridRowImpl(46),gx.O.A61TurnoNombre,0)},c2v:function(){gx.O.A61TurnoNombre=this.val()},val:function(){return gx.fn.getGridControlValue("TURNONOMBRE",gx.fn.currentGridRowImpl(46))},nac:function(){return false}};this.GXValidFnc[52]={lvl:2,type:"int",len:2,dec:0,sign:false,pic:"Z9",ro:1,grid:46,gxgrid:this.Grid1Container,fnc:null,isvalid:null,rgrid:[],fld:"CONSULTANRO",gxz:"Z63ConsultaNro",gxold:"O63ConsultaNro",gxvar:"A63ConsultaNro",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A63ConsultaNro=gx.num.intval(a)
},v2z:function(a){gx.O.Z63ConsultaNro=gx.num.intval(a)},v2c:function(){gx.fn.setGridControlValue("CONSULTANRO",gx.fn.currentGridRowImpl(46),gx.O.A63ConsultaNro,0)},c2v:function(){gx.O.A63ConsultaNro=this.val()},val:function(){return gx.fn.getGridIntegerValue("CONSULTANRO",gx.fn.currentGridRowImpl(46),".")},nac:function(){return false}};this.GXValidFnc[53]={lvl:2,type:"boolean",len:4,dec:0,sign:false,ro:1,grid:46,gxgrid:this.Grid1Container,fnc:null,isvalid:null,fld:"CONFIRMADO",gxz:"Z75Confirmado",gxold:"O75Confirmado",gxvar:"A75Confirmado",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(a){gx.O.A75Confirmado=gx.lang.booleanValue(a)
},v2z:function(a){gx.O.Z75Confirmado=gx.lang.booleanValue(a)},v2c:function(){gx.fn.setGridCheckBoxValue("CONFIRMADO",gx.fn.currentGridRowImpl(46),gx.O.A75Confirmado,true)},c2v:function(){gx.O.A75Confirmado=this.val()},val:function(){return gx.fn.getGridCheckBoxValue("CONFIRMADO",gx.fn.currentGridRowImpl(46),true,false)},nac:function(){return false}};this.GXValidFnc[54]={lvl:2,type:"int",len:2,dec:0,sign:false,pic:"Z9",ro:1,grid:46,gxgrid:this.Grid1Container,fnc:this.Valid_Turnoid,isvalid:null,rgrid:[],fld:"TURNOID",gxz:"Z60TurnoId",gxold:"O60TurnoId",gxvar:"A60TurnoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"dyncombo",v2v:function(a){gx.O.A60TurnoId=gx.num.intval(a)
},v2z:function(a){gx.O.Z60TurnoId=gx.num.intval(a)},v2c:function(){gx.fn.setGridComboBoxValue("TURNOID",gx.fn.currentGridRowImpl(46),gx.O.A60TurnoId)},c2v:function(){gx.O.A60TurnoId=this.val()},val:function(){return gx.fn.getGridIntegerValue("TURNOID",gx.fn.currentGridRowImpl(46),".")},nac:function(){return false}};this.AV6cConsultaFecha=gx.date.nullDate();this.ZV6cConsultaFecha=gx.date.nullDate();this.OV6cConsultaFecha=gx.date.nullDate();this.AV7cPacienteId=0;this.ZV7cPacienteId=0;this.OV7cPacienteId=0;
this.AV8cMedicoId=0;this.ZV8cMedicoId=0;this.OV8cMedicoId=0;this.AV9cTurnoNombre="";this.ZV9cTurnoNombre="";this.OV9cTurnoNombre="";this.AV10cConsultaNro=0;this.ZV10cConsultaNro=0;this.OV10cConsultaNro=0;this.AV11cConfirmado=false;this.ZV11cConfirmado=false;this.OV11cConfirmado=false;this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z43ConsultaFecha=gx.date.nullDate();this.O43ConsultaFecha=gx.date.nullDate();this.Z34PacienteId=0;this.O34PacienteId=0;this.Z12MedicoId=0;this.O12MedicoId=0;this.Z61TurnoNombre="";
this.O61TurnoNombre="";this.Z63ConsultaNro=0;this.O63ConsultaNro=0;this.Z75Confirmado=false;this.O75Confirmado=false;this.Z60TurnoId=0;this.O60TurnoId=0;this.AV12pConsultaFecha=gx.date.nullDate();this.AV13pPacienteId=0;this.AV14pMedicoId=0;this.AV15pTurnoId=0;this.AV5LinkSelection="";this.A43ConsultaFecha=gx.date.nullDate();this.A34PacienteId=0;this.A12MedicoId=0;this.A61TurnoNombre="";this.A63ConsultaNro=0;this.A75Confirmado=false;this.A60TurnoId=0;this.ServerEvents=["e130u2_client","e140u2_client"];
this.VarControlMap.AV12pConsultaFecha={id:"_PCONSULTAFECHA",grid:0,type:"date"};this.VarControlMap.AV13pPacienteId={id:"_PPACIENTEID",grid:0,type:"int"};this.VarControlMap.AV14pMedicoId={id:"_PMEDICOID",grid:0,type:"int"};this.VarControlMap.AV15pTurnoId={id:"_PTURNOID",grid:0,type:"int"};this.Grid1Container.addRefreshingVar(this.GXValidFnc[14]);this.Grid1Container.addRefreshingVar(this.GXValidFnc[19]);this.Grid1Container.addRefreshingVar(this.GXValidFnc[24]);this.Grid1Container.addRefreshingVar(this.GXValidFnc[29]);
this.Grid1Container.addRefreshingVar(this.GXValidFnc[34]);this.Grid1Container.addRefreshingVar(this.GXValidFnc[39]);this.SetStandaloneVars()}gx0080.prototype=new gx.GxObject;gx.setParentObj(new gx0080());