gx.evt.autoSkip=false;function home(){this.ServerClass="Home";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.hasEnterEvent=false;this.autoRefresh=true;this.SetStandaloneVars=function(){};this.e12052_client=function(){this.executeServerEvent("ENTER",true,arguments[0])};this.e13052_client=function(){this.executeServerEvent("CANCEL",true,arguments[0])};this.GXValidFnc=[];this.GXCtrlIds=[8];this.GXLastCtrlId=8;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",5,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"home",[],true,1,true,true,0,false,false,false,"",100,"%","Nueva fila",false,false,false,null,null,false,"");
this.Grid1Container.startRow("","","","","","");this.Grid1Container.startCell("","","","","","","","","","");this.Grid1Container.addSingleLineEdit("Menuitem",8,"_MENUITEM","","","MenuItem","char",80,"chr",100,100,"left",null,[],"Menuitem","MenuItem",true,0,false,false);this.Grid1Container.endCell();this.Grid1Container.endRow();this.setGrid(this.Grid1Container);this.GXValidFnc[8]={lvl:2,type:"char",len:100,dec:0,sign:false,ro:1,grid:5,gxgrid:this.Grid1Container,fnc:null,isvalid:null,fld:"_MENUITEM",gxz:"ZV5MenuItem",gxold:"OV5MenuItem",gxvar:"AV5MenuItem",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(a){gx.O.AV5MenuItem=a
},v2z:function(a){gx.O.ZV5MenuItem=a},v2c:function(){gx.fn.setGridControlValue("_MENUITEM",gx.fn.currentGridRowImpl(5),gx.O.AV5MenuItem,0)},c2v:function(){gx.O.AV5MenuItem=this.val()},val:function(){return gx.fn.getGridControlValue("_MENUITEM",gx.fn.currentGridRowImpl(5))},nac:function(){return false}};this.AV5MenuItem="";this.ServerEvents=["e12052_client","e13052_client"];this.VarControlMap.AV6ProgramNames={id:"_PROGRAMNAMES",grid:0,type:"CollProgramNames.ProgramName"};this.Grid1Container.addRefreshingVar({rfrVar:"AV6ProgramNames"});
this.SetStandaloneVars()}home.prototype=new gx.GxObject;gx.setParentObj(new home());