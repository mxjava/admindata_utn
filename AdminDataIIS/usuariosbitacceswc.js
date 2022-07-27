gx.evt.autoSkip = false;
gx.define('usuariosbitacceswc', true, function (CmpContext) {
   this.ServerClass =  "usuariosbitacceswc" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("web");
   this.setCmpContext(CmpContext);
   this.ReadonlyForm = true;
   this.anyGridBaseTable = true;
   this.hasEnterEvent = false;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.AV6UsuariosId=gx.fn.getIntegerValue("vUSUARIOSID",'.') ;
      this.AV6UsuariosId=gx.fn.getIntegerValue("vUSUARIOSID",'.') ;
   };
   this.e131h2_client=function()
   {
      return this.executeServerEvent("ENTER", true, arguments[0], false, false);
   };
   this.e141h2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, arguments[0], false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,13,14,15,16,17,18];
   this.GXLastCtrlId =18;
   this.GridContainer = new gx.grid.grid(this, 2,"WbpLvl2",12,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"usuariosbitacceswc",[],false,1,false,true,0,true,false,false,"",0,"px",0,"px","Nueva fila",true,false,false,null,null,false,"",false,[1,1,1,1],false,0,true,false);
   var GridContainer = this.GridContainer;
   GridContainer.addSingleLineEdit(61,13,"BITACCESFEC","Fecha","","bitAccesFec","dtime",0,"px",17,17,"right",null,[],61,"bitAccesFec",true,8,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(75,14,"BITACCESIP","Ip","","bitAccesIp","svchar",0,"px",15,15,"left",null,[],75,"bitAccesIp",true,0,false,false,"DescriptionAttribute",1,"WWColumn");
   this.GridContainer.emptyText = "";
   this.setGrid(GridContainer);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"GRIDCELL",grid:0};
   GXValidFnc[6]={ id: 6, fld:"GRIDTABLE",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[13]={ id:13 ,lvl:2,type:"dtime",len:8,dec:8,sign:false,ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"BITACCESFEC",gxz:"Z61bitAccesFec",gxold:"O61bitAccesFec",gxvar:"A61bitAccesFec",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/99 99:99:99",dec:8},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.A61bitAccesFec=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z61bitAccesFec=gx.fn.toDatetimeValue(Value)},v2c:function(row){gx.fn.setGridControlValue("BITACCESFEC",row || gx.fn.currentGridRowImpl(12),gx.O.A61bitAccesFec,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A61bitAccesFec=gx.fn.toDatetimeValue(this.val(row))},val:function(row){return gx.fn.getGridDateTimeValue("BITACCESFEC",row || gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};
   GXValidFnc[14]={ id:14 ,lvl:2,type:"svchar",len:15,dec:0,sign:false,ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"BITACCESIP",gxz:"Z75bitAccesIp",gxold:"O75bitAccesIp",gxvar:"A75bitAccesIp",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A75bitAccesIp=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z75bitAccesIp=Value},v2c:function(row){gx.fn.setGridControlValue("BITACCESIP",row || gx.fn.currentGridRowImpl(12),gx.O.A75bitAccesIp,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A75bitAccesIp=this.val(row)},val:function(row){return gx.fn.getGridControlValue("BITACCESIP",row || gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"",grid:0};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id:18 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSID",gxz:"Z11UsuariosId",gxold:"O11UsuariosId",gxvar:"A11UsuariosId",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A11UsuariosId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z11UsuariosId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("USUARIOSID",gx.O.A11UsuariosId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A11UsuariosId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("USUARIOSID",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 18 , function() {
   });
   this.Z61bitAccesFec = gx.date.nullDate() ;
   this.O61bitAccesFec = gx.date.nullDate() ;
   this.Z75bitAccesIp = "" ;
   this.O75bitAccesIp = "" ;
   this.A11UsuariosId = 0 ;
   this.Z11UsuariosId = 0 ;
   this.O11UsuariosId = 0 ;
   this.A11UsuariosId = 0 ;
   this.AV6UsuariosId = 0 ;
   this.A61bitAccesFec = gx.date.nullDate() ;
   this.A75bitAccesIp = "" ;
   this.Events = {"e131h2_client": ["ENTER", true] ,"e141h2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV6UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'sPrefix'}],[]];
   this.EvtParms["START"] = [[{av:'AV14Pgmname',fld:'vPGMNAME',pic:''}],[{ctrl:'GRID',prop:'Rows'},{av:'gx.fn.getCtrlProperty("USUARIOSID","Visible")',ctrl:'USUARIOSID',prop:'Visible'}]];
   this.EvtParms["GRID.LOAD"] = [[],[]];
   this.EvtParms["GRID_FIRSTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV6UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'sPrefix'}],[]];
   this.EvtParms["GRID_PREVPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV6UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'sPrefix'}],[]];
   this.EvtParms["GRID_NEXTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV6UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'sPrefix'}],[]];
   this.EvtParms["GRID_LASTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV6UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'sPrefix'}],[]];
   this.setVCMap("AV6UsuariosId", "vUSUARIOSID", 0, "int", 6, 0);
   this.setVCMap("AV6UsuariosId", "vUSUARIOSID", 0, "int", 6, 0);
   this.setVCMap("AV6UsuariosId", "vUSUARIOSID", 0, "int", 6, 0);
   GridContainer.addRefreshingParm({rfrProp:"Rows", gxGrid:"Grid"});
   GridContainer.addRefreshingVar({rfrVar:"AV6UsuariosId"});
   GridContainer.addRefreshingParm({rfrVar:"AV6UsuariosId"});
   this.Initialize( );
});
