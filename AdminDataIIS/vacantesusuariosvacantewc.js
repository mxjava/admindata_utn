gx.evt.autoSkip = false;
gx.define('vacantesusuariosvacantewc', true, function (CmpContext) {
   this.ServerClass =  "vacantesusuariosvacantewc" ;
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
      this.AV6Vacantes_Id=gx.fn.getIntegerValue("vVACANTES_ID",'.') ;
      this.AV6Vacantes_Id=gx.fn.getIntegerValue("vVACANTES_ID",'.') ;
   };
   this.Valid_Usuariosid=function()
   {
      var currentRow = gx.fn.currentGridRowImpl(12);
      return this.validCliEvt("Valid_Usuariosid", 12, function () {
      try {
         if(  gx.fn.currentGridRowImpl(12) ===0) {
            return true;
         }
         var gxballoon = gx.util.balloon.getNew("USUARIOSID", gx.fn.currentGridRowImpl(12));
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
   this.e13282_client=function()
   {
      return this.executeServerEvent("ENTER", true, arguments[0], false, false);
   };
   this.e14282_client=function()
   {
      return this.executeServerEvent("CANCEL", true, arguments[0], false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,13,14,15,16,17,18,19,20,21];
   this.GXLastCtrlId =21;
   this.GridContainer = new gx.grid.grid(this, 2,"WbpLvl2",12,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"vacantesusuariosvacantewc",[],false,1,false,true,0,true,false,false,"",0,"px",0,"px","Nueva fila",true,false,false,null,null,false,"",false,[1,1,1,1],false,0,true,false);
   var GridContainer = this.GridContainer;
   GridContainer.addSingleLineEdit(11,13,"USUARIOSID","ID","","UsuariosId","int",0,"px",6,6,"right",null,[],11,"UsuariosId",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(66,14,"USUARIOSNOMBRE","Nombre","","UsuariosNombre","svchar",0,"px",40,40,"left",null,[],66,"UsuariosNombre",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(65,15,"USUARIOSAPPAT","Primer Apellido","","UsuariosApPat","svchar",0,"px",40,40,"left",null,[],65,"UsuariosApPat",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(64,16,"USUARIOSAPMAT","Segundo Apellido","","UsuariosApMat","svchar",0,"px",40,40,"left",null,[],64,"UsuariosApMat",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addComboBox(273,17,"USUARIOSVACANTEESTATUS","Estatus","UsuariosVacanteEstatus","int",null,0,true,false,0,"px","WWColumn WWOptionalColumn");
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
   GXValidFnc[13]={ id:13 ,lvl:2,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:this.Valid_Usuariosid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSID",gxz:"Z11UsuariosId",gxold:"O11UsuariosId",gxvar:"A11UsuariosId",ucs:[],op:[14,15,16],ip:[14,15,16,13],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A11UsuariosId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z11UsuariosId=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("USUARIOSID",row || gx.fn.currentGridRowImpl(12),gx.O.A11UsuariosId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(row){if(this.val(row)!==undefined)gx.O.A11UsuariosId=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("USUARIOSID",row || gx.fn.currentGridRowImpl(12),'.')},nac:gx.falseFn};
   GXValidFnc[14]={ id:14 ,lvl:2,type:"svchar",len:40,dec:0,sign:false,pic:"@!",ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSNOMBRE",gxz:"Z66UsuariosNombre",gxold:"O66UsuariosNombre",gxvar:"A66UsuariosNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A66UsuariosNombre=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z66UsuariosNombre=Value},v2c:function(row){gx.fn.setGridControlValue("USUARIOSNOMBRE",row || gx.fn.currentGridRowImpl(12),gx.O.A66UsuariosNombre,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A66UsuariosNombre=this.val(row)},val:function(row){return gx.fn.getGridControlValue("USUARIOSNOMBRE",row || gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};
   GXValidFnc[15]={ id:15 ,lvl:2,type:"svchar",len:40,dec:0,sign:false,pic:"@!",ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSAPPAT",gxz:"Z65UsuariosApPat",gxold:"O65UsuariosApPat",gxvar:"A65UsuariosApPat",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A65UsuariosApPat=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z65UsuariosApPat=Value},v2c:function(row){gx.fn.setGridControlValue("USUARIOSAPPAT",row || gx.fn.currentGridRowImpl(12),gx.O.A65UsuariosApPat,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A65UsuariosApPat=this.val(row)},val:function(row){return gx.fn.getGridControlValue("USUARIOSAPPAT",row || gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};
   GXValidFnc[16]={ id:16 ,lvl:2,type:"svchar",len:40,dec:0,sign:false,pic:"@!",ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSAPMAT",gxz:"Z64UsuariosApMat",gxold:"O64UsuariosApMat",gxvar:"A64UsuariosApMat",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A64UsuariosApMat=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z64UsuariosApMat=Value},v2c:function(row){gx.fn.setGridControlValue("USUARIOSAPMAT",row || gx.fn.currentGridRowImpl(12),gx.O.A64UsuariosApMat,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A64UsuariosApMat=this.val(row)},val:function(row){return gx.fn.getGridControlValue("USUARIOSAPMAT",row || gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};
   GXValidFnc[17]={ id:17 ,lvl:2,type:"int",len:1,dec:0,sign:false,pic:"9",ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSVACANTEESTATUS",gxz:"Z273UsuariosVacanteEstatus",gxold:"O273UsuariosVacanteEstatus",gxvar:"A273UsuariosVacanteEstatus",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A273UsuariosVacanteEstatus=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z273UsuariosVacanteEstatus=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridComboBoxValue("USUARIOSVACANTEESTATUS",row || gx.fn.currentGridRowImpl(12),gx.O.A273UsuariosVacanteEstatus)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A273UsuariosVacanteEstatus=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("USUARIOSVACANTEESTATUS",row || gx.fn.currentGridRowImpl(12),'.')},nac:gx.falseFn};
   GXValidFnc[18]={ id: 18, fld:"",grid:0};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   GXValidFnc[21]={ id:21 ,lvl:0,type:"int",len:9,dec:0,sign:false,pic:"ZZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VACANTES_ID",gxz:"Z263Vacantes_Id",gxold:"O263Vacantes_Id",gxvar:"A263Vacantes_Id",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A263Vacantes_Id=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z263Vacantes_Id=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("VACANTES_ID",gx.O.A263Vacantes_Id,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A263Vacantes_Id=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("VACANTES_ID",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 21 , function() {
   });
   this.Z11UsuariosId = 0 ;
   this.O11UsuariosId = 0 ;
   this.Z66UsuariosNombre = "" ;
   this.O66UsuariosNombre = "" ;
   this.Z65UsuariosApPat = "" ;
   this.O65UsuariosApPat = "" ;
   this.Z64UsuariosApMat = "" ;
   this.O64UsuariosApMat = "" ;
   this.Z273UsuariosVacanteEstatus = 0 ;
   this.O273UsuariosVacanteEstatus = 0 ;
   this.A263Vacantes_Id = 0 ;
   this.Z263Vacantes_Id = 0 ;
   this.O263Vacantes_Id = 0 ;
   this.A263Vacantes_Id = 0 ;
   this.AV6Vacantes_Id = 0 ;
   this.A11UsuariosId = 0 ;
   this.A66UsuariosNombre = "" ;
   this.A65UsuariosApPat = "" ;
   this.A64UsuariosApMat = "" ;
   this.A273UsuariosVacanteEstatus = 0 ;
   this.Events = {"e13282_client": ["ENTER", true] ,"e14282_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'sPrefix'}],[]];
   this.EvtParms["START"] = [[{av:'AV14Pgmname',fld:'vPGMNAME',pic:''},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'}],[{ctrl:'GRID',prop:'Rows'},{av:'gx.fn.getCtrlProperty("VACANTES_ID","Visible")',ctrl:'VACANTES_ID',prop:'Visible'}]];
   this.EvtParms["GRID.LOAD"] = [[],[]];
   this.EvtParms["GRID_FIRSTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'sPrefix'}],[]];
   this.EvtParms["GRID_PREVPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'sPrefix'}],[]];
   this.EvtParms["GRID_NEXTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'sPrefix'}],[]];
   this.EvtParms["GRID_LASTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'sPrefix'}],[]];
   this.EvtParms["VALID_USUARIOSID"] = [[{av:'A66UsuariosNombre',fld:'USUARIOSNOMBRE',pic:'@!'},{av:'A65UsuariosApPat',fld:'USUARIOSAPPAT',pic:'@!'},{av:'A64UsuariosApMat',fld:'USUARIOSAPMAT',pic:'@!'},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'}],[{av:'A66UsuariosNombre',fld:'USUARIOSNOMBRE',pic:'@!'},{av:'A65UsuariosApPat',fld:'USUARIOSAPPAT',pic:'@!'},{av:'A64UsuariosApMat',fld:'USUARIOSAPMAT',pic:'@!'}]];
   this.setVCMap("AV6Vacantes_Id", "vVACANTES_ID", 0, "int", 9, 0);
   this.setVCMap("AV6Vacantes_Id", "vVACANTES_ID", 0, "int", 9, 0);
   this.setVCMap("AV6Vacantes_Id", "vVACANTES_ID", 0, "int", 9, 0);
   GridContainer.addRefreshingParm({rfrProp:"Rows", gxGrid:"Grid"});
   GridContainer.addRefreshingVar({rfrVar:"AV6Vacantes_Id"});
   GridContainer.addRefreshingParm({rfrVar:"AV6Vacantes_Id"});
   this.Initialize( );
});
