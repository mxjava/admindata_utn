gx.evt.autoSkip = false;
gx.define('usuarioshistpwdwc', true, function (CmpContext) {
   this.ServerClass =  "usuarioshistpwdwc" ;
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
   this.e131g2_client=function()
   {
      return this.executeServerEvent("ENTER", true, arguments[0], false, false);
   };
   this.e141g2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, arguments[0], false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,13,14,15,16,17,18,19,20];
   this.GXLastCtrlId =20;
   this.GridContainer = new gx.grid.grid(this, 2,"WbpLvl2",12,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"usuarioshistpwdwc",[],false,1,false,true,0,true,false,false,"",0,"px",0,"px","Nueva fila",true,false,false,null,null,false,"",false,[1,1,1,1],false,0,true,false);
   var GridContainer = this.GridContainer;
   GridContainer.addSingleLineEdit(62,13,"HISPWDFECHA","Fecha de la Contrasena","","HisPwdFecha","dtime",0,"px",19,19,"right",null,[],62,"HisPwdFecha",true,8,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(110,14,"HISTPWDCONSTRA","Constrasena","","HistPwdConstra","svchar",0,"px",32,32,"left",null,[],110,"HistPwdConstra",true,0,false,false,"DescriptionAttribute",1,"WWColumn");
   GridContainer.addSingleLineEdit(111,15,"HISTPWDLLAVE","Llave de la contrasena","","HistPwdLlave","svchar",0,"px",32,32,"left",null,[],111,"HistPwdLlave",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(73,16,"HISTPWDIND","Indicador de la contraseña","","HistPwdInd","int",0,"px",1,1,"right",null,[],73,"HistPwdInd",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
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
   GXValidFnc[13]={ id:13 ,lvl:2,type:"dtime",len:10,dec:8,sign:false,ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"HISPWDFECHA",gxz:"Z62HisPwdFecha",gxold:"O62HisPwdFecha",gxvar:"A62HisPwdFecha",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/9999 99:99:99",dec:8},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.A62HisPwdFecha=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z62HisPwdFecha=gx.fn.toDatetimeValue(Value)},v2c:function(row){gx.fn.setGridControlValue("HISPWDFECHA",row || gx.fn.currentGridRowImpl(12),gx.O.A62HisPwdFecha,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(row){if(this.val(row)!==undefined)gx.O.A62HisPwdFecha=gx.fn.toDatetimeValue(this.val(row))},val:function(row){return gx.fn.getGridDateTimeValue("HISPWDFECHA",row || gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};
   GXValidFnc[14]={ id:14 ,lvl:2,type:"svchar",len:32,dec:0,sign:false,ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"HISTPWDCONSTRA",gxz:"Z110HistPwdConstra",gxold:"O110HistPwdConstra",gxvar:"A110HistPwdConstra",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A110HistPwdConstra=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z110HistPwdConstra=Value},v2c:function(row){gx.fn.setGridControlValue("HISTPWDCONSTRA",row || gx.fn.currentGridRowImpl(12),gx.O.A110HistPwdConstra,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A110HistPwdConstra=this.val(row)},val:function(row){return gx.fn.getGridControlValue("HISTPWDCONSTRA",row || gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};
   GXValidFnc[15]={ id:15 ,lvl:2,type:"svchar",len:32,dec:0,sign:false,ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"HISTPWDLLAVE",gxz:"Z111HistPwdLlave",gxold:"O111HistPwdLlave",gxvar:"A111HistPwdLlave",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A111HistPwdLlave=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z111HistPwdLlave=Value},v2c:function(row){gx.fn.setGridControlValue("HISTPWDLLAVE",row || gx.fn.currentGridRowImpl(12),gx.O.A111HistPwdLlave,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A111HistPwdLlave=this.val(row)},val:function(row){return gx.fn.getGridControlValue("HISTPWDLLAVE",row || gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};
   GXValidFnc[16]={ id:16 ,lvl:2,type:"int",len:1,dec:0,sign:false,pic:"9",ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"HISTPWDIND",gxz:"Z73HistPwdInd",gxold:"O73HistPwdInd",gxvar:"A73HistPwdInd",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A73HistPwdInd=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z73HistPwdInd=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("HISTPWDIND",row || gx.fn.currentGridRowImpl(12),gx.O.A73HistPwdInd,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A73HistPwdInd=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("HISTPWDIND",row || gx.fn.currentGridRowImpl(12),'.')},nac:gx.falseFn};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"",grid:0};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id:20 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSID",gxz:"Z11UsuariosId",gxold:"O11UsuariosId",gxvar:"A11UsuariosId",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A11UsuariosId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z11UsuariosId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("USUARIOSID",gx.O.A11UsuariosId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A11UsuariosId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("USUARIOSID",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 20 , function() {
   });
   this.Z62HisPwdFecha = gx.date.nullDate() ;
   this.O62HisPwdFecha = gx.date.nullDate() ;
   this.Z110HistPwdConstra = "" ;
   this.O110HistPwdConstra = "" ;
   this.Z111HistPwdLlave = "" ;
   this.O111HistPwdLlave = "" ;
   this.Z73HistPwdInd = 0 ;
   this.O73HistPwdInd = 0 ;
   this.A11UsuariosId = 0 ;
   this.Z11UsuariosId = 0 ;
   this.O11UsuariosId = 0 ;
   this.A11UsuariosId = 0 ;
   this.AV6UsuariosId = 0 ;
   this.A62HisPwdFecha = gx.date.nullDate() ;
   this.A110HistPwdConstra = "" ;
   this.A111HistPwdLlave = "" ;
   this.A73HistPwdInd = 0 ;
   this.Events = {"e131g2_client": ["ENTER", true] ,"e141g2_client": ["CANCEL", true]};
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
