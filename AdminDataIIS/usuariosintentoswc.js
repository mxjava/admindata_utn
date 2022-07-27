gx.evt.autoSkip = false;
gx.define('usuariosintentoswc', true, function (CmpContext) {
   this.ServerClass =  "usuariosintentoswc" ;
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
   this.e13112_client=function()
   {
      return this.executeServerEvent("ENTER", true, arguments[0], false, false);
   };
   this.e14112_client=function()
   {
      return this.executeServerEvent("CANCEL", true, arguments[0], false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,13,14,15,16,17,18,19];
   this.GXLastCtrlId =19;
   this.GridContainer = new gx.grid.grid(this, 2,"WbpLvl2",12,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"usuariosintentoswc",[],false,1,false,true,0,true,false,false,"",0,"px",0,"px","Nueva fila",true,false,false,null,null,false,"",false,[1,1,1,1],false,0,true,false);
   var GridContainer = this.GridContainer;
   GridContainer.addSingleLineEdit(30,13,"FECHAINTENTO","del Intento","","FechaIntento","date",0,"px",8,8,"right",null,[],30,"FechaIntento",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(72,14,"CONTADOR","los Intentos","","Contador","int",0,"px",1,1,"right",null,[],72,"Contador",true,0,false,false,"DescriptionAttribute",1,"WWColumn");
   GridContainer.addSingleLineEdit(74,15,"INTENTOSHORABLOQUEO","Hora Bloqueo","","IntentosHoraBloqueo","dtime",0,"px",14,14,"right",null,[],74,"IntentosHoraBloqueo",true,5,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
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
   GXValidFnc[13]={ id:13 ,lvl:2,type:"date",len:8,dec:0,sign:false,ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FECHAINTENTO",gxz:"Z30FechaIntento",gxold:"O30FechaIntento",gxvar:"A30FechaIntento",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.A30FechaIntento=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z30FechaIntento=gx.fn.toDatetimeValue(Value)},v2c:function(row){gx.fn.setGridControlValue("FECHAINTENTO",row || gx.fn.currentGridRowImpl(12),gx.O.A30FechaIntento,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A30FechaIntento=gx.fn.toDatetimeValue(this.val(row))},val:function(row){return gx.fn.getGridDateTimeValue("FECHAINTENTO",row || gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};
   GXValidFnc[14]={ id:14 ,lvl:2,type:"int",len:1,dec:0,sign:false,pic:"9",ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CONTADOR",gxz:"Z72Contador",gxold:"O72Contador",gxvar:"A72Contador",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A72Contador=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z72Contador=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("CONTADOR",row || gx.fn.currentGridRowImpl(12),gx.O.A72Contador,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A72Contador=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("CONTADOR",row || gx.fn.currentGridRowImpl(12),'.')},nac:gx.falseFn};
   GXValidFnc[15]={ id:15 ,lvl:2,type:"dtime",len:8,dec:5,sign:false,ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INTENTOSHORABLOQUEO",gxz:"Z74IntentosHoraBloqueo",gxold:"O74IntentosHoraBloqueo",gxvar:"A74IntentosHoraBloqueo",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/99 99:99",dec:5},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.A74IntentosHoraBloqueo=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z74IntentosHoraBloqueo=gx.fn.toDatetimeValue(Value)},v2c:function(row){gx.fn.setGridControlValue("INTENTOSHORABLOQUEO",row || gx.fn.currentGridRowImpl(12),gx.O.A74IntentosHoraBloqueo,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A74IntentosHoraBloqueo=gx.fn.toDatetimeValue(this.val(row))},val:function(row){return gx.fn.getGridDateTimeValue("INTENTOSHORABLOQUEO",row || gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};
   GXValidFnc[16]={ id: 16, fld:"",grid:0};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"",grid:0};
   GXValidFnc[19]={ id:19 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSID",gxz:"Z11UsuariosId",gxold:"O11UsuariosId",gxvar:"A11UsuariosId",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A11UsuariosId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z11UsuariosId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("USUARIOSID",gx.O.A11UsuariosId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A11UsuariosId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("USUARIOSID",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 19 , function() {
   });
   this.Z30FechaIntento = gx.date.nullDate() ;
   this.O30FechaIntento = gx.date.nullDate() ;
   this.Z72Contador = 0 ;
   this.O72Contador = 0 ;
   this.Z74IntentosHoraBloqueo = gx.date.nullDate() ;
   this.O74IntentosHoraBloqueo = gx.date.nullDate() ;
   this.A11UsuariosId = 0 ;
   this.Z11UsuariosId = 0 ;
   this.O11UsuariosId = 0 ;
   this.A11UsuariosId = 0 ;
   this.AV6UsuariosId = 0 ;
   this.A30FechaIntento = gx.date.nullDate() ;
   this.A72Contador = 0 ;
   this.A74IntentosHoraBloqueo = gx.date.nullDate() ;
   this.Events = {"e13112_client": ["ENTER", true] ,"e14112_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV6UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'sPrefix'}],[]];
   this.EvtParms["START"] = [[{av:'AV15Pgmname',fld:'vPGMNAME',pic:''}],[{ctrl:'GRID',prop:'Rows'},{av:'gx.fn.getCtrlProperty("USUARIOSID","Visible")',ctrl:'USUARIOSID',prop:'Visible'}]];
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
