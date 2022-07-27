gx.evt.autoSkip = false;
gx.define('menurolwc', true, function (CmpContext) {
   this.ServerClass =  "menurolwc" ;
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
      this.AV6MenuXid=gx.fn.getIntegerValue("vMENUXID",'.') ;
      this.AV6MenuXid=gx.fn.getIntegerValue("vMENUXID",'.') ;
   };
   this.Valid_Rolid=function()
   {
      var currentRow = gx.fn.currentGridRowImpl(12);
      return this.validCliEvt("Valid_Rolid", 12, function () {
      try {
         if(  gx.fn.currentGridRowImpl(12) ===0) {
            return true;
         }
         var gxballoon = gx.util.balloon.getNew("ROLID", gx.fn.currentGridRowImpl(12));
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
   this.e132g2_client=function()
   {
      return this.executeServerEvent("ENTER", true, arguments[0], false, false);
   };
   this.e142g2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, arguments[0], false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,13,14,15,16,17,18,19];
   this.GXLastCtrlId =19;
   this.GridContainer = new gx.grid.grid(this, 2,"WbpLvl2",12,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"menurolwc",[],false,1,false,true,0,true,false,false,"",0,"px",0,"px","Nueva fila",true,false,false,null,null,false,"",false,[1,1,1,1],false,0,true,false);
   var GridContainer = this.GridContainer;
   GridContainer.addSingleLineEdit(24,13,"ROLID","Clave del rol","","RolId","int",0,"px",9,9,"right",null,[],24,"RolId",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(127,14,"ROLNOMBRE","Rol Nombre","","RolNombre","svchar",0,"px",40,40,"left",null,[],127,"RolNombre",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(128,15,"ROLDESCRIPCION","Rol Descripcion","","RolDescripcion","svchar",0,"px",150,80,"left",null,[],128,"RolDescripcion",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
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
   GXValidFnc[13]={ id:13 ,lvl:2,type:"int",len:9,dec:0,sign:false,pic:"ZZZZZZZZ9",ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:this.Valid_Rolid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ROLID",gxz:"Z24RolId",gxold:"O24RolId",gxvar:"A24RolId",ucs:[],op:[14,15],ip:[14,15,13],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A24RolId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z24RolId=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("ROLID",row || gx.fn.currentGridRowImpl(12),gx.O.A24RolId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(row){if(this.val(row)!==undefined)gx.O.A24RolId=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("ROLID",row || gx.fn.currentGridRowImpl(12),'.')},nac:gx.falseFn};
   GXValidFnc[14]={ id:14 ,lvl:2,type:"svchar",len:40,dec:0,sign:false,ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ROLNOMBRE",gxz:"Z127RolNombre",gxold:"O127RolNombre",gxvar:"A127RolNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A127RolNombre=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z127RolNombre=Value},v2c:function(row){gx.fn.setGridControlValue("ROLNOMBRE",row || gx.fn.currentGridRowImpl(12),gx.O.A127RolNombre,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A127RolNombre=this.val(row)},val:function(row){return gx.fn.getGridControlValue("ROLNOMBRE",row || gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};
   GXValidFnc[15]={ id:15 ,lvl:2,type:"svchar",len:150,dec:0,sign:false,ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ROLDESCRIPCION",gxz:"Z128RolDescripcion",gxold:"O128RolDescripcion",gxvar:"A128RolDescripcion",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A128RolDescripcion=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z128RolDescripcion=Value},v2c:function(row){gx.fn.setGridControlValue("ROLDESCRIPCION",row || gx.fn.currentGridRowImpl(12),gx.O.A128RolDescripcion,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A128RolDescripcion=this.val(row)},val:function(row){return gx.fn.getGridControlValue("ROLDESCRIPCION",row || gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};
   GXValidFnc[16]={ id: 16, fld:"",grid:0};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"",grid:0};
   GXValidFnc[19]={ id:19 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENUXID",gxz:"Z1MenuXid",gxold:"O1MenuXid",gxvar:"A1MenuXid",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1MenuXid=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1MenuXid=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("MENUXID",gx.O.A1MenuXid,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1MenuXid=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("MENUXID",'.')},nac:gx.falseFn};
   this.Z24RolId = 0 ;
   this.O24RolId = 0 ;
   this.Z127RolNombre = "" ;
   this.O127RolNombre = "" ;
   this.Z128RolDescripcion = "" ;
   this.O128RolDescripcion = "" ;
   this.A1MenuXid = 0 ;
   this.Z1MenuXid = 0 ;
   this.O1MenuXid = 0 ;
   this.A1MenuXid = 0 ;
   this.AV6MenuXid = 0 ;
   this.A24RolId = 0 ;
   this.A127RolNombre = "" ;
   this.A128RolDescripcion = "" ;
   this.Events = {"e132g2_client": ["ENTER", true] ,"e142g2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV6MenuXid',fld:'vMENUXID',pic:'ZZZ9'},{av:'sPrefix'}],[]];
   this.EvtParms["START"] = [[{av:'AV14Pgmname',fld:'vPGMNAME',pic:''},{av:'AV6MenuXid',fld:'vMENUXID',pic:'ZZZ9'}],[{ctrl:'GRID',prop:'Rows'},{av:'gx.fn.getCtrlProperty("MENUXID","Visible")',ctrl:'MENUXID',prop:'Visible'}]];
   this.EvtParms["GRID.LOAD"] = [[{av:'A24RolId',fld:'ROLID',pic:'ZZZZZZZZ9'}],[{av:'gx.fn.getCtrlProperty("ROLNOMBRE","Link")',ctrl:'ROLNOMBRE',prop:'Link'}]];
   this.EvtParms["GRID_FIRSTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV6MenuXid',fld:'vMENUXID',pic:'ZZZ9'},{av:'sPrefix'}],[]];
   this.EvtParms["GRID_PREVPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV6MenuXid',fld:'vMENUXID',pic:'ZZZ9'},{av:'sPrefix'}],[]];
   this.EvtParms["GRID_NEXTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV6MenuXid',fld:'vMENUXID',pic:'ZZZ9'},{av:'sPrefix'}],[]];
   this.EvtParms["GRID_LASTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV6MenuXid',fld:'vMENUXID',pic:'ZZZ9'},{av:'sPrefix'}],[]];
   this.EvtParms["VALID_ROLID"] = [[{av:'A127RolNombre',fld:'ROLNOMBRE',pic:''},{av:'A128RolDescripcion',fld:'ROLDESCRIPCION',pic:''},{av:'A24RolId',fld:'ROLID',pic:'ZZZZZZZZ9'}],[{av:'A127RolNombre',fld:'ROLNOMBRE',pic:''},{av:'A128RolDescripcion',fld:'ROLDESCRIPCION',pic:''}]];
   this.setVCMap("AV6MenuXid", "vMENUXID", 0, "int", 4, 0);
   this.setVCMap("AV6MenuXid", "vMENUXID", 0, "int", 4, 0);
   this.setVCMap("AV6MenuXid", "vMENUXID", 0, "int", 4, 0);
   GridContainer.addRefreshingParm({rfrProp:"Rows", gxGrid:"Grid"});
   GridContainer.addRefreshingVar({rfrVar:"AV6MenuXid"});
   GridContainer.addRefreshingParm({rfrVar:"AV6MenuXid"});
   this.Initialize( );
});
