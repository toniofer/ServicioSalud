gx.evt.autoSkip=false;function turno(){this.ServerClass="Turno";this.PackageName="GeneXus.Programs";this.setObjectType("trn");this.hasEnterEvent=true;this.SetStandaloneVars=function(){this.Gx_mode=gx.fn.getControlValue("_MODE")};this.Valid_Turnoid=function(){gx.ajax.validSrvEvt("dyncall","Valid_Turnoid",["gx.O.A60TurnoId","gx.O.A61TurnoNombre"],["A61TurnoNombre","Gx_mode","Z60TurnoId","Z61TurnoNombre",["BTN_ENTER2","Enabled"]]);return true};this.e12072_client=function(){this.executeServerEvent("AFTER TRN",true)
};this.e13077_client=function(){this.executeServerEvent("ENTER",true)};this.e14077_client=function(){this.executeServerEvent("CANCEL",true)};this.GXValidFnc=[];this.GXCtrlIds=[38,43];this.GXLastCtrlId=43;this.GXValidFnc[38]={lvl:0,type:"int",len:2,dec:0,sign:false,pic:"Z9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Turnoid,isvalid:null,rgrid:[],fld:"TURNOID",gxz:"Z60TurnoId",gxold:"O60TurnoId",gxvar:"A60TurnoId",ucs:[],op:[43],ip:[43,38],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A60TurnoId=gx.num.intval(a)
},v2z:function(a){gx.O.Z60TurnoId=gx.num.intval(a)},v2c:function(){gx.fn.setControlValue("TURNOID",gx.O.A60TurnoId,0)},c2v:function(){gx.O.A60TurnoId=this.val()},val:function(){return gx.fn.getIntegerValue("TURNOID",".")}};this.GXValidFnc[43]={lvl:0,type:"char",len:20,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,fld:"TURNONOMBRE",gxz:"Z61TurnoNombre",gxold:"O61TurnoNombre",gxvar:"A61TurnoNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.A61TurnoNombre=a},v2z:function(a){gx.O.Z61TurnoNombre=a
},v2c:function(){gx.fn.setControlValue("TURNONOMBRE",gx.O.A61TurnoNombre,0)},c2v:function(){gx.O.A61TurnoNombre=this.val()},val:function(){return gx.fn.getControlValue("TURNONOMBRE")}};this.A60TurnoId=0;this.Z60TurnoId=0;this.O60TurnoId=0;this.A61TurnoNombre="";this.Z61TurnoNombre="";this.O61TurnoNombre="";this.AV7Context={};this.ServerEvents=["e12072_client","e13077_client","e14077_client"];this.EnterCtrl=["BTN_ENTER"];this.VarControlMap.Gx_mode={id:"_MODE",grid:0,type:"char"};this.SetStandaloneVars()
}turno.prototype=new gx.GxObject;gx.setParentObj(new turno());