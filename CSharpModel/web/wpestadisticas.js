gx.evt.autoSkip=false;function wpestadisticas(){this.ServerClass="WPEstadisticas";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.hasEnterEvent=true;this.autoRefresh=true;this.SetStandaloneVars=function(){};this.e110q2_client=function(){this.executeServerEvent("ENTER",true)};this.e130q2_client=function(){this.executeServerEvent("CANCEL",true)};this.GXValidFnc=[];this.GXCtrlIds=[10,15,23];this.GXLastCtrlId=23;this.GXValidFnc[10]={lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,fld:"_FECHADESDE",gxz:"ZV5FechaDesde",gxold:"OV5FechaDesde",gxvar:"AV5FechaDesde",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.AV5FechaDesde=gx.fn.toDatetimeValue(a)
},v2z:function(a){gx.O.ZV5FechaDesde=gx.fn.toDatetimeValue(a)},v2c:function(){gx.fn.setControlValue("_FECHADESDE",gx.O.AV5FechaDesde,0)},c2v:function(){gx.O.AV5FechaDesde=this.val()},val:function(){return gx.fn.getControlValue("_FECHADESDE")}};this.GXValidFnc[15]={lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,fld:"_FECHAHASTA",gxz:"ZV6FechaHasta",gxold:"OV6FechaHasta",gxvar:"AV6FechaHasta",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.AV6FechaHasta=gx.fn.toDatetimeValue(a)
},v2z:function(a){gx.O.ZV6FechaHasta=gx.fn.toDatetimeValue(a)},v2c:function(){gx.fn.setControlValue("_FECHAHASTA",gx.O.AV6FechaHasta,0)},c2v:function(){gx.O.AV6FechaHasta=this.val()},val:function(){return gx.fn.getControlValue("_FECHAHASTA")}};this.GXValidFnc[23]={lvl:0,type:"vchar",len:2097152,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,fld:"_CODIGOXML",gxz:"ZV8codigoXML",gxold:"OV8codigoXML",gxvar:"AV8codigoXML",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.AV8codigoXML=a
},v2z:function(a){gx.O.ZV8codigoXML=a},v2c:function(){gx.fn.setControlValue("_CODIGOXML",gx.O.AV8codigoXML,0)},c2v:function(){gx.O.AV8codigoXML=this.val()},val:function(){return gx.fn.getControlValue("_CODIGOXML")}};this.AV5FechaDesde=gx.date.nullDate();this.ZV5FechaDesde=gx.date.nullDate();this.OV5FechaDesde=gx.date.nullDate();this.AV6FechaHasta=gx.date.nullDate();this.ZV6FechaHasta=gx.date.nullDate();this.OV6FechaHasta=gx.date.nullDate();this.AV8codigoXML="";this.ZV8codigoXML="";this.OV8codigoXML="";
this.ServerEvents=["e110q2_client","e130q2_client"];this.EnterCtrl=["BUTTON1"];this.SetStandaloneVars()}wpestadisticas.prototype=new gx.GxObject;gx.setParentObj(new wpestadisticas());