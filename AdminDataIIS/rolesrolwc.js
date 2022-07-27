gx.evt.autoSkip = false;
gx.define('rolesrolwc', true, function (CmpContext) {
   this.ServerClass =  "rolesrolwc" ;
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
      this.AV6RolId=gx.fn.getIntegerValue("vROLID",'.') ;
      this.AV6RolId=gx.fn.getIntegerValue("vROLID",'.') ;
   };
   this.Valid_Menuxid=function()
   {
      var currentRow = gx.fn.currentGridRowImpl(20);
      return this.validCliEvt("Valid_Menuxid", 20, function () {
      try {
         if(  gx.fn.currentGridRowImpl(20) ===0) {
            return true;
         }
         var gxballoon = gx.util.balloon.getNew("MENUXID", gx.fn.currentGridRowImpl(20));
         this.AnyError  = 0;

      }
      catch(e){}
      try {
          if (gxballoon == null) return true; return gxballoon.show();
      }
      catch(e){}
      return true ;
      });
   }
   this.e112h2_client=function()
   {
      return this.executeServerEvent("'DOINSERT'", false, null, false, false);
   };
   this.e142h2_client=function()
   {
      return this.executeServerEvent("ENTER", true, arguments[0], false, false);
   };
   this.e152h2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, arguments[0], false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,18,19,21,22,23,24,25,26,27,28,29,30,31,32,33,34];
   this.GXLastCtrlId =34;
   this.GridContainer = new gx.grid.grid(this, 2,"WbpLvl2",20,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"rolesrolwc",[],false,1,false,true,0,true,false,false,"",0,"px",0,"px","Nueva fila",true,false,false,null,null,false,"",false,[1,1,1,1],false,0,true,false);
   var GridContainer = this.GridContainer;
   GridContainer.addSingleLineEdit(1,21,"MENUXID","Xid","","MenuXid","int",0,"px",4,4,"right",null,[],1,"MenuXid",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(2,22,"MENUXDESC","XDesc","","MenuXDesc","svchar",0,"px",40,40,"left",null,[],2,"MenuXDesc",true,0,false,false,"DescriptionAttribute",1,"WWColumn");
   GridContainer.addSingleLineEdit(3,23,"MENUXPOSI","Position","","MenuXPosi","int",0,"px",4,4,"right",null,[],3,"MenuXPosi",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(4,24,"MENXURL","Url","","MenXUrl","svchar",490,"px",1000,80,"left",null,[],4,"MenXUrl",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addComboBox(5,25,"MENXEST","Estado","MenXEst","char",null,0,true,false,0,"px","WWColumn WWOptionalColumn");
   GridContainer.addBitmap(259,"MENICONO",26,0,"px",17,"px",null,"","Icono","ImageAttribute","WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(258,27,"MENPADRE","Padre","","MenPadre","int",0,"px",4,4,"right",null,[],258,"MenPadre",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(262,28,"DESCRIPCION","Descripcion","","Descripcion","svchar",0,"px",120,80,"left",null,[],262,"Descripcion",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit("Update",29,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",true,0,false,false,"TextActionAttribute",1,"WWTextActionColumn");
   GridContainer.addSingleLineEdit("Delete",30,"vDELETE","","","Delete","char",0,"px",20,20,"left",null,[],"Delete","Delete",true,0,false,false,"TextActionAttribute",1,"WWTextActionColumn");
   this.GridContainer.emptyText = "";
   this.setGrid(GridContainer);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLETOP",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[9]={ id: 9, fld:"",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"BTNINSERT",grid:0,evt:"e112h2_client"};
   GXValidFnc[12]={ id: 12, fld:"",grid:0};
   GXValidFnc[13]={ id: 13, fld:"GRIDCELL",grid:0};
   GXValidFnc[14]={ id: 14, fld:"GRIDTABLE",grid:0};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"",grid:0};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[21]={ id:21 ,lvl:2,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:this.Valid_Menuxid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENUXID",gxz:"Z1MenuXid",gxold:"O1MenuXid",gxvar:"A1MenuXid",ucs:[],op:[22,23,24,25,26,27,28],ip:[22,23,24,25,26,27,28,21],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A1MenuXid=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1MenuXid=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("MENUXID",row || gx.fn.currentGridRowImpl(20),gx.O.A1MenuXid,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A1MenuXid=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("MENUXID",row || gx.fn.currentGridRowImpl(20),'.')},nac:gx.falseFn};
   GXValidFnc[22]={ id:22 ,lvl:2,type:"svchar",len:40,dec:0,sign:false,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENUXDESC",gxz:"Z2MenuXDesc",gxold:"O2MenuXDesc",gxvar:"A2MenuXDesc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A2MenuXDesc=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z2MenuXDesc=Value},v2c:function(row){gx.fn.setGridControlValue("MENUXDESC",row || gx.fn.currentGridRowImpl(20),gx.O.A2MenuXDesc,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A2MenuXDesc=this.val(row)},val:function(row){return gx.fn.getGridControlValue("MENUXDESC",row || gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};
   GXValidFnc[23]={ id:23 ,lvl:2,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENUXPOSI",gxz:"Z3MenuXPosi",gxold:"O3MenuXPosi",gxvar:"A3MenuXPosi",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A3MenuXPosi=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z3MenuXPosi=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("MENUXPOSI",row || gx.fn.currentGridRowImpl(20),gx.O.A3MenuXPosi,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A3MenuXPosi=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("MENUXPOSI",row || gx.fn.currentGridRowImpl(20),'.')},nac:gx.falseFn};
   GXValidFnc[24]={ id:24 ,lvl:2,type:"svchar",len:1000,dec:0,sign:false,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENXURL",gxz:"Z4MenXUrl",gxold:"O4MenXUrl",gxvar:"A4MenXUrl",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'url',v2v:function(Value){if(Value!==undefined)gx.O.A4MenXUrl=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z4MenXUrl=Value},v2c:function(row){gx.fn.setGridControlValue("MENXURL",row || gx.fn.currentGridRowImpl(20),gx.O.A4MenXUrl,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(row){if(this.val(row)!==undefined)gx.O.A4MenXUrl=this.val(row)},val:function(row){return gx.fn.getGridControlValue("MENXURL",row || gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};
   GXValidFnc[25]={ id:25 ,lvl:2,type:"char",len:1,dec:0,sign:false,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENXEST",gxz:"Z5MenXEst",gxold:"O5MenXEst",gxvar:"A5MenXEst",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.A5MenXEst=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z5MenXEst=Value},v2c:function(row){gx.fn.setGridComboBoxValue("MENXEST",row || gx.fn.currentGridRowImpl(20),gx.O.A5MenXEst)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A5MenXEst=this.val(row)},val:function(row){return gx.fn.getGridControlValue("MENXEST",row || gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};
   GXValidFnc[26]={ id:26 ,lvl:2,type:"bits",len:1024,dec:0,sign:false,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENICONO",gxz:"Z259MenIcono",gxold:"O259MenIcono",gxvar:"A259MenIcono",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.A259MenIcono=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z259MenIcono=Value},v2c:function(row){gx.fn.setGridMultimediaValue("MENICONO",row || gx.fn.currentGridRowImpl(20),gx.O.A259MenIcono,gx.O.A40000MenIcono_GXI)},c2v:function(row){gx.O.A40000MenIcono_GXI=this.val_GXI();if(this.val(row)!==undefined)gx.O.A259MenIcono=this.val(row)},val:function(row){return gx.fn.getGridControlValue("MENICONO",row || gx.fn.currentGridRowImpl(20))},val_GXI:function(row){return gx.fn.getGridControlValue("MENICONO_GXI",row || gx.fn.currentGridRowImpl(20))}, gxvar_GXI:'A40000MenIcono_GXI',nac:gx.falseFn};
   GXValidFnc[27]={ id:27 ,lvl:2,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENPADRE",gxz:"Z258MenPadre",gxold:"O258MenPadre",gxvar:"A258MenPadre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A258MenPadre=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z258MenPadre=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("MENPADRE",row || gx.fn.currentGridRowImpl(20),gx.O.A258MenPadre,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A258MenPadre=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("MENPADRE",row || gx.fn.currentGridRowImpl(20),'.')},nac:gx.falseFn};
   GXValidFnc[28]={ id:28 ,lvl:2,type:"svchar",len:120,dec:0,sign:false,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DESCRIPCION",gxz:"Z262Descripcion",gxold:"O262Descripcion",gxvar:"A262Descripcion",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A262Descripcion=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z262Descripcion=Value},v2c:function(row){gx.fn.setGridControlValue("DESCRIPCION",row || gx.fn.currentGridRowImpl(20),gx.O.A262Descripcion,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A262Descripcion=this.val(row)},val:function(row){return gx.fn.getGridControlValue("DESCRIPCION",row || gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};
   GXValidFnc[29]={ id:29 ,lvl:2,type:"char",len:20,dec:0,sign:false,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",gxz:"ZV11Update",gxold:"OV11Update",gxvar:"AV11Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.AV11Update=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV11Update=Value},v2c:function(row){gx.fn.setGridControlValue("vUPDATE",row || gx.fn.currentGridRowImpl(20),gx.O.AV11Update,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.AV11Update=this.val(row)},val:function(row){return gx.fn.getGridControlValue("vUPDATE",row || gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};
   GXValidFnc[30]={ id:30 ,lvl:2,type:"char",len:20,dec:0,sign:false,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",gxz:"ZV12Delete",gxold:"OV12Delete",gxvar:"AV12Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.AV12Delete=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV12Delete=Value},v2c:function(row){gx.fn.setGridControlValue("vDELETE",row || gx.fn.currentGridRowImpl(20),gx.O.AV12Delete,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.AV12Delete=this.val(row)},val:function(row){return gx.fn.getGridControlValue("vDELETE",row || gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id: 33, fld:"",grid:0};
   GXValidFnc[34]={ id:34 ,lvl:0,type:"int",len:9,dec:0,sign:false,pic:"ZZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ROLID",gxz:"Z24RolId",gxold:"O24RolId",gxvar:"A24RolId",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A24RolId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z24RolId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("ROLID",gx.O.A24RolId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A24RolId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("ROLID",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 34 , function() {
   });
   this.Z1MenuXid = 0 ;
   this.O1MenuXid = 0 ;
   this.Z2MenuXDesc = "" ;
   this.O2MenuXDesc = "" ;
   this.Z3MenuXPosi = 0 ;
   this.O3MenuXPosi = 0 ;
   this.Z4MenXUrl = "" ;
   this.O4MenXUrl = "" ;
   this.Z5MenXEst = "" ;
   this.O5MenXEst = "" ;
   this.Z259MenIcono = "" ;
   this.O259MenIcono = "" ;
   this.Z258MenPadre = 0 ;
   this.O258MenPadre = 0 ;
   this.Z262Descripcion = "" ;
   this.O262Descripcion = "" ;
   this.ZV11Update = "" ;
   this.OV11Update = "" ;
   this.ZV12Delete = "" ;
   this.OV12Delete = "" ;
   this.A24RolId = 0 ;
   this.Z24RolId = 0 ;
   this.O24RolId = 0 ;
   this.A24RolId = 0 ;
   this.A40000MenIcono_GXI = "" ;
   this.AV6RolId = 0 ;
   this.A1MenuXid = 0 ;
   this.A2MenuXDesc = "" ;
   this.A3MenuXPosi = 0 ;
   this.A4MenXUrl = "" ;
   this.A5MenXEst = "" ;
   this.A259MenIcono = "" ;
   this.A258MenPadre = 0 ;
   this.A262Descripcion = "" ;
   this.AV11Update = "" ;
   this.AV12Delete = "" ;
   this.Events = {"e112h2_client": ["'DOINSERT'", true] ,"e142h2_client": ["ENTER", true] ,"e152h2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV6RolId',fld:'vROLID',pic:'ZZZZZZZZ9'},{av:'AV11Update',fld:'vUPDATE',pic:''},{av:'AV12Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}],[]];
   this.EvtParms["START"] = [[{av:'AV16Pgmname',fld:'vPGMNAME',pic:''},{av:'AV6RolId',fld:'vROLID',pic:'ZZZZZZZZ9'}],[{ctrl:'GRID',prop:'Rows'},{av:'AV11Update',fld:'vUPDATE',pic:''},{av:'AV12Delete',fld:'vDELETE',pic:''},{av:'gx.fn.getCtrlProperty("ROLID","Visible")',ctrl:'ROLID',prop:'Visible'}]];
   this.EvtParms["GRID.LOAD"] = [[{av:'A1MenuXid',fld:'MENUXID',pic:'ZZZ9',hsh:true}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:'vUPDATE',prop:'Link'},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:'vDELETE',prop:'Link'},{av:'gx.fn.getCtrlProperty("MENUXDESC","Link")',ctrl:'MENUXDESC',prop:'Link'}]];
   this.EvtParms["'DOINSERT'"] = [[{av:'A1MenuXid',fld:'MENUXID',pic:'ZZZ9',hsh:true}],[]];
   this.EvtParms["GRID_FIRSTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV6RolId',fld:'vROLID',pic:'ZZZZZZZZ9'},{av:'AV11Update',fld:'vUPDATE',pic:''},{av:'AV12Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}],[]];
   this.EvtParms["GRID_PREVPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV6RolId',fld:'vROLID',pic:'ZZZZZZZZ9'},{av:'AV11Update',fld:'vUPDATE',pic:''},{av:'AV12Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}],[]];
   this.EvtParms["GRID_NEXTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV6RolId',fld:'vROLID',pic:'ZZZZZZZZ9'},{av:'AV11Update',fld:'vUPDATE',pic:''},{av:'AV12Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}],[]];
   this.EvtParms["GRID_LASTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV6RolId',fld:'vROLID',pic:'ZZZZZZZZ9'},{av:'AV11Update',fld:'vUPDATE',pic:''},{av:'AV12Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}],[]];
   this.EvtParms["VALID_MENUXID"] = [[{av:'A2MenuXDesc',fld:'MENUXDESC',pic:''},{av:'A3MenuXPosi',fld:'MENUXPOSI',pic:'ZZZ9'},{av:'A4MenXUrl',fld:'MENXURL',pic:''},{ctrl:'MENXEST'},{av:'A5MenXEst',fld:'MENXEST',pic:''},{av:'A259MenIcono',fld:'MENICONO',pic:''},{av:'A258MenPadre',fld:'MENPADRE',pic:'ZZZ9'},{av:'A262Descripcion',fld:'DESCRIPCION',pic:''},{av:'A1MenuXid',fld:'MENUXID',pic:'ZZZ9',hsh:true}],[{av:'A2MenuXDesc',fld:'MENUXDESC',pic:''},{av:'A3MenuXPosi',fld:'MENUXPOSI',pic:'ZZZ9'},{av:'A4MenXUrl',fld:'MENXURL',pic:''},{ctrl:'MENXEST'},{av:'A5MenXEst',fld:'MENXEST',pic:''},{av:'A259MenIcono',fld:'MENICONO',pic:''},{av:'A258MenPadre',fld:'MENPADRE',pic:'ZZZ9'},{av:'A262Descripcion',fld:'DESCRIPCION',pic:''}]];
   this.setVCMap("AV6RolId", "vROLID", 0, "int", 9, 0);
   this.setVCMap("AV6RolId", "vROLID", 0, "int", 9, 0);
   this.setVCMap("AV6RolId", "vROLID", 0, "int", 9, 0);
   GridContainer.addRefreshingParm({rfrProp:"Rows", gxGrid:"Grid"});
   GridContainer.addRefreshingVar({rfrVar:"AV6RolId"});
   GridContainer.addRefreshingVar({rfrVar:"AV11Update", rfrProp:"Value", gxAttId:"Update"});
   GridContainer.addRefreshingVar({rfrVar:"AV12Delete", rfrProp:"Value", gxAttId:"Delete"});
   GridContainer.addRefreshingParm({rfrVar:"AV6RolId"});
   GridContainer.addRefreshingParm({rfrVar:"AV11Update", rfrProp:"Value", gxAttId:"Update"});
   GridContainer.addRefreshingParm({rfrVar:"AV12Delete", rfrProp:"Value", gxAttId:"Delete"});
   this.Initialize( );
});
