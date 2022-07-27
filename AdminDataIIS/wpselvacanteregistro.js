gx.evt.autoSkip = false;
gx.define('wpselvacanteregistro', true, function (CmpContext) {
   this.ServerClass =  "wpselvacanteregistro" ;
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
      this.A11UsuariosId=gx.fn.getIntegerValue("USUARIOSID",'.') ;
      this.AV12UsuariosId=gx.fn.getIntegerValue("vUSUARIOSID",'.') ;
      this.A273UsuariosVacanteEstatus=gx.fn.getIntegerValue("USUARIOSVACANTEESTATUS",'.') ;
      this.AV10UsuarioReclutador=gx.fn.getIntegerValue("vUSUARIORECLUTADOR",'.') ;
      this.A284SUBT_ReclutadorId=gx.fn.getIntegerValue("SUBT_RECLUTADORID",'.') ;
      this.AV13vacantes_Id=gx.fn.getIntegerValue("vVACANTES_ID",'.') ;
      this.A11UsuariosId=gx.fn.getIntegerValue("USUARIOSID",'.') ;
      this.AV12UsuariosId=gx.fn.getIntegerValue("vUSUARIOSID",'.') ;
      this.A273UsuariosVacanteEstatus=gx.fn.getIntegerValue("USUARIOSVACANTEESTATUS",'.') ;
   };
   this.Valid_Vacantes_id=function()
   {
      var currentRow = gx.fn.currentGridRowImpl(25);
      return this.validCliEvt("Valid_Vacantes_id", 25, function () {
      try {
         if(  gx.fn.currentGridRowImpl(25) ===0) {
            return true;
         }
         var gxballoon = gx.util.balloon.getNew("VACANTES_ID", gx.fn.currentGridRowImpl(25));
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
   this.e182y2_client=function()
   {
      this.clearMessages();
      this.call("wpcandidatos.aspx", []);
      this.refreshOutputs([]);
      return gx.$.Deferred().resolve();
   };
   this.e142y2_client=function()
   {
      return this.executeServerEvent("'POSTULARSE'", true, arguments[0], false, false);
   };
   this.e152y2_client=function()
   {
      return this.executeServerEvent("'DECLINAR'", true, arguments[0], false, false);
   };
   this.e112y2_client=function()
   {
      return this.executeServerEvent("UCALERTAS.ACCEPT", false, null, true, true);
   };
   this.e122y2_client=function()
   {
      return this.executeServerEvent("'SIGUIENTE'", true, null, false, false);
   };
   this.e132y2_client=function()
   {
      return this.executeServerEvent("'RETROCEDER'", true, null, false, false);
   };
   this.e192y2_client=function()
   {
      return this.executeServerEvent("ENTER", true, arguments[0], false, false);
   };
   this.e202y2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, arguments[0], false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,20,21,22,23,24,26,27,28,29,32,33,34,37,38,39,41,42,43,46,47,48,51,54,55,56,57,58,59];
   this.GXLastCtrlId =59;
   this.Stselecvacante_grid2Container = new gx.grid.grid(this, 2,"WbpLvl2",25,"Stselecvacante_grid2","Stselecvacante_grid2","Stselecvacante_grid2Container",this.CmpContext,this.IsMasterPage,"wpselvacanteregistro",[],true,3,false,true,0,false,false,false,"",0,"px",0,"px","Nueva fila",true,false,false,null,null,false,"",true,[1,2,3,3],false,0,false,false);
   var Stselecvacante_grid2Container = this.Stselecvacante_grid2Container;
   Stselecvacante_grid2Container.startDiv(26,"Stselecvacante_grid2table1","0px","0px");
   Stselecvacante_grid2Container.startDiv(27,"","0px","0px");
   Stselecvacante_grid2Container.startDiv(28,"","0px","0px");
   Stselecvacante_grid2Container.startTable("Stselecvacante_table3",29,"0px");
   Stselecvacante_grid2Container.startRow("","","","","","");
   Stselecvacante_grid2Container.startCell("","","","","","","","","","");
   Stselecvacante_grid2Container.startDiv(32,"","0px","0px");
   Stselecvacante_grid2Container.addLabel();
   Stselecvacante_grid2Container.startDiv(33,"","0px","75%");
   Stselecvacante_grid2Container.addSingleLineEdit(264,34,"VACANTES_NOMBRE","","","Vacantes_Nombre","svchar",40,"chr",40,40,"left",null,[],264,"Vacantes_Nombre",true,0,false,false,"AttributeTitle",1,"");
   Stselecvacante_grid2Container.endDiv();
   Stselecvacante_grid2Container.endDiv();
   Stselecvacante_grid2Container.endCell();
   Stselecvacante_grid2Container.endRow();
   Stselecvacante_grid2Container.startRow("","","","","","");
   Stselecvacante_grid2Container.startCell("","","","","","","","","","");
   Stselecvacante_grid2Container.startDiv(37,"","0px","0px");
   Stselecvacante_grid2Container.addLabel();
   Stselecvacante_grid2Container.startDiv(38,"","0px","75%");
   Stselecvacante_grid2Container.addSingleLineEdit(267,39,"VACANTES_SUELDO","","","Vacantes_Sueldo","decimal",6,"chr",6,6,"right",null,[],267,"Vacantes_Sueldo",true,3,false,false,"AttributeTitle",1,"");
   Stselecvacante_grid2Container.endDiv();
   Stselecvacante_grid2Container.endDiv();
   Stselecvacante_grid2Container.endCell();
   Stselecvacante_grid2Container.startCell("","","","","","","","","","");
   Stselecvacante_grid2Container.startDiv(41,"","0px","0px");
   Stselecvacante_grid2Container.addLabel();
   Stselecvacante_grid2Container.startDiv(42,"","0px","75%");
   Stselecvacante_grid2Container.addSingleLineEdit(263,43,"VACANTES_ID","","","Vacantes_Id","int",9,"chr",9,9,"right",null,[],263,"Vacantes_Id",true,0,false,false,"AttBlanco",1,"");
   Stselecvacante_grid2Container.endDiv();
   Stselecvacante_grid2Container.endDiv();
   Stselecvacante_grid2Container.endCell();
   Stselecvacante_grid2Container.endRow();
   Stselecvacante_grid2Container.startRow("","","","","","");
   Stselecvacante_grid2Container.startCell("","","","","","","","","","");
   Stselecvacante_grid2Container.startDiv(46,"","0px","0px");
   Stselecvacante_grid2Container.addLabel();
   Stselecvacante_grid2Container.startDiv(47,"","0px","75%");
   Stselecvacante_grid2Container.addMultipleLineEdit(274,48,"VACANTES_DESCRIPCION","","Vacantes_Descripcion","svchar",80,"chr",10,"row","1000",1000,"left",null,true,false,0,"");
   Stselecvacante_grid2Container.endDiv();
   Stselecvacante_grid2Container.endDiv();
   Stselecvacante_grid2Container.endCell();
   Stselecvacante_grid2Container.endRow();
   Stselecvacante_grid2Container.startRow("","","","","","");
   Stselecvacante_grid2Container.startCell("","Right","Middle","","","","","","","");
   Stselecvacante_grid2Container.addButton(51,"STSELECVACANTE_POSTULARSE","standard","'","e142y2_client");
   Stselecvacante_grid2Container.endCell();
   Stselecvacante_grid2Container.endRow();
   Stselecvacante_grid2Container.startRow("","","","","","");
   Stselecvacante_grid2Container.startCell("","Right","Middle","","","","","","","");
   Stselecvacante_grid2Container.addButton(54,"STSELECVACANTE_DECLINAR","standard","'","e152y2_client");
   Stselecvacante_grid2Container.endCell();
   Stselecvacante_grid2Container.endRow();
   Stselecvacante_grid2Container.endTable();
   Stselecvacante_grid2Container.endDiv();
   Stselecvacante_grid2Container.endDiv();
   Stselecvacante_grid2Container.startDiv(55,"","0px","0px");
   Stselecvacante_grid2Container.startDiv(56,"","0px","0px");
   Stselecvacante_grid2Container.addTextBlock('STSELECVACANTE_TEXTBLOCK1',null,57);
   Stselecvacante_grid2Container.endDiv();
   Stselecvacante_grid2Container.endDiv();
   Stselecvacante_grid2Container.endDiv();
   this.Stselecvacante_grid2Container.emptyText = "";
   this.setGrid(Stselecvacante_grid2Container);
   this.UCALERTASContainer = gx.uc.getNew(this, 60, 9, "SweetAlert2", this.CmpContext + "UCALERTASContainer", "Ucalertas", "UCALERTAS");
   var UCALERTASContainer = this.UCALERTASContainer;
   UCALERTASContainer.setProp("Class", "Class", "", "char");
   UCALERTASContainer.setProp("Enabled", "Enabled", true, "boolean");
   UCALERTASContainer.setProp("Width", "Width", "100", "str");
   UCALERTASContainer.setProp("Height", "Height", "100", "str");
   UCALERTASContainer.addV2CFunction('AV5AlertProperties', "vALERTPROPERTIES", 'SetPropiedades');
   UCALERTASContainer.addC2VFunction(function(UC) { UC.ParentObject.AV5AlertProperties=UC.GetPropiedades();gx.fn.setControlValue("vALERTPROPERTIES",UC.ParentObject.AV5AlertProperties); });
   UCALERTASContainer.setProp("Visible", "Visible", true, "bool");
   UCALERTASContainer.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   UCALERTASContainer.setC2ShowFunction(function(UC) { UC.show(); });
   UCALERTASContainer.addEventHandler("Accept", this.e112y2_client);
   this.setUserControl(UCALERTASContainer);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TITLETEXT", format:0,grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[9]={ id:9 ,lvl:0,gxsgprm:['vVACANTES_NOMBRE',[],[],false,[]],type:"svchar",len:40,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Stselecvacante_grid2Container],fld:"vVACANTES_NOMBRE",gxz:"ZV15Vacantes_Nombre",gxold:"OV15Vacantes_Nombre",gxvar:"AV15Vacantes_Nombre",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV15Vacantes_Nombre=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV15Vacantes_Nombre=Value},v2c:function(){gx.fn.setControlValue("vVACANTES_NOMBRE",gx.O.AV15Vacantes_Nombre,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV15Vacantes_Nombre=this.val()},val:function(){return gx.fn.getControlValue("vVACANTES_NOMBRE")},nac:gx.falseFn};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[12]={ id: 12, fld:"",grid:0};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"IMAGE2",grid:0,evt:"e132y2_client"};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"IMAGE1",grid:0,evt:"e122y2_client"};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"STSELECVACANTE",grid:0};
   GXValidFnc[23]={ id: 23, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"STSELECVACANTE_GRID2TABLE1",grid:25};
   GXValidFnc[27]={ id: 27, fld:"",grid:25};
   GXValidFnc[28]={ id: 28, fld:"",grid:25};
   GXValidFnc[29]={ id: 29, fld:"STSELECVACANTE_TABLE3",grid:25};
   GXValidFnc[32]={ id: 32, fld:"",grid:25};
   GXValidFnc[33]={ id: 33, fld:"",grid:25};
   GXValidFnc[34]={ id:34 ,lvl:2,type:"svchar",len:40,dec:0,sign:false,ro:1,isacc:0,grid:25,gxgrid:this.Stselecvacante_grid2Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VACANTES_NOMBRE",gxz:"Z264Vacantes_Nombre",gxold:"O264Vacantes_Nombre",gxvar:"A264Vacantes_Nombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A264Vacantes_Nombre=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z264Vacantes_Nombre=Value},v2c:function(row){gx.fn.setGridControlValue("VACANTES_NOMBRE",row || gx.fn.currentGridRowImpl(25),gx.O.A264Vacantes_Nombre,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A264Vacantes_Nombre=this.val(row)},val:function(row){return gx.fn.getGridControlValue("VACANTES_NOMBRE",row || gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};
   GXValidFnc[37]={ id: 37, fld:"",grid:25};
   GXValidFnc[38]={ id: 38, fld:"",grid:25};
   GXValidFnc[39]={ id:39 ,lvl:2,type:"decimal",len:6,dec:3,sign:false,pic:"Z9.999",ro:1,isacc:0,grid:25,gxgrid:this.Stselecvacante_grid2Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VACANTES_SUELDO",gxz:"Z267Vacantes_Sueldo",gxold:"O267Vacantes_Sueldo",gxvar:"A267Vacantes_Sueldo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.A267Vacantes_Sueldo=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z267Vacantes_Sueldo=gx.fn.toDecimalValue(Value,'.',',')},v2c:function(row){gx.fn.setGridDecimalValue("VACANTES_SUELDO",row || gx.fn.currentGridRowImpl(25),gx.O.A267Vacantes_Sueldo,3,',')},c2v:function(row){if(this.val(row)!==undefined)gx.O.A267Vacantes_Sueldo=this.val(row)},val:function(row){return gx.fn.getGridDecimalValue("VACANTES_SUELDO",row || gx.fn.currentGridRowImpl(25),'.',',')},nac:gx.falseFn};
   GXValidFnc[41]={ id: 41, fld:"",grid:25};
   GXValidFnc[42]={ id: 42, fld:"",grid:25};
   GXValidFnc[43]={ id:43 ,lvl:2,type:"int",len:9,dec:0,sign:false,pic:"ZZZZZZZZ9",ro:1,isacc:0,grid:25,gxgrid:this.Stselecvacante_grid2Container,fnc:this.Valid_Vacantes_id,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VACANTES_ID",gxz:"Z263Vacantes_Id",gxold:"O263Vacantes_Id",gxvar:"A263Vacantes_Id",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A263Vacantes_Id=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z263Vacantes_Id=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("VACANTES_ID",row || gx.fn.currentGridRowImpl(25),gx.O.A263Vacantes_Id,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(row){if(this.val(row)!==undefined)gx.O.A263Vacantes_Id=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("VACANTES_ID",row || gx.fn.currentGridRowImpl(25),'.')},nac:gx.falseFn};
   GXValidFnc[46]={ id: 46, fld:"",grid:25};
   GXValidFnc[47]={ id: 47, fld:"",grid:25};
   GXValidFnc[48]={ id:48 ,lvl:2,type:"svchar",len:1000,dec:0,sign:false,ro:1,isacc:0, multiline:true,grid:25,gxgrid:this.Stselecvacante_grid2Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VACANTES_DESCRIPCION",gxz:"Z274Vacantes_Descripcion",gxold:"O274Vacantes_Descripcion",gxvar:"A274Vacantes_Descripcion",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A274Vacantes_Descripcion=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z274Vacantes_Descripcion=Value},v2c:function(row){gx.fn.setGridControlValue("VACANTES_DESCRIPCION",row || gx.fn.currentGridRowImpl(25),gx.O.A274Vacantes_Descripcion,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A274Vacantes_Descripcion=this.val(row)},val:function(row){return gx.fn.getGridControlValue("VACANTES_DESCRIPCION",row || gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};
   GXValidFnc[51]={ id: 51, fld:"STSELECVACANTE_POSTULARSE",grid:25,evt:"e142y2_client"};
   GXValidFnc[54]={ id: 54, fld:"STSELECVACANTE_DECLINAR",grid:25,evt:"e152y2_client"};
   GXValidFnc[55]={ id: 55, fld:"",grid:25};
   GXValidFnc[56]={ id: 56, fld:"",grid:25};
   GXValidFnc[57]={ id: 57, fld:"STSELECVACANTE_TEXTBLOCK1", format:0,grid:25};
   GXValidFnc[58]={ id: 58, fld:"",grid:0};
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   this.AV15Vacantes_Nombre = "" ;
   this.ZV15Vacantes_Nombre = "" ;
   this.OV15Vacantes_Nombre = "" ;
   this.Z264Vacantes_Nombre = "" ;
   this.O264Vacantes_Nombre = "" ;
   this.Z267Vacantes_Sueldo = 0 ;
   this.O267Vacantes_Sueldo = 0 ;
   this.Z263Vacantes_Id = 0 ;
   this.O263Vacantes_Id = 0 ;
   this.Z274Vacantes_Descripcion = "" ;
   this.O274Vacantes_Descripcion = "" ;
   this.AV15Vacantes_Nombre = "" ;
   this.AV5AlertProperties = {title:"",titleText:"",html:"",text:"",icon:"",showCancelButton:false,showConfirmButton:false,confirmButtonColor:"",focusConfirm:false,cancelButtonColor:"",confirmButtonText:"",confirmButtonUrl:"",cancelButtonText:"",showCloseButton:false,allowOutsideClick:false,footer:""} ;
   this.AV12UsuariosId = 0 ;
   this.A265Vacantes_Status = 0 ;
   this.A264Vacantes_Nombre = "" ;
   this.A267Vacantes_Sueldo = 0 ;
   this.A263Vacantes_Id = 0 ;
   this.A274Vacantes_Descripcion = "" ;
   this.A273UsuariosVacanteEstatus = 0 ;
   this.A11UsuariosId = 0 ;
   this.A284SUBT_ReclutadorId = 0 ;
   this.AV10UsuarioReclutador = 0 ;
   this.AV13vacantes_Id = 0 ;
   this.Events = {"e142y2_client": ["'POSTULARSE'", true] ,"e152y2_client": ["'DECLINAR'", true] ,"e112y2_client": ["UCALERTAS.ACCEPT", true] ,"e122y2_client": ["'SIGUIENTE'", true] ,"e132y2_client": ["'RETROCEDER'", true] ,"e192y2_client": ["ENTER", true] ,"e202y2_client": ["CANCEL", true] ,"e182y2_client": ["'PROSPECTOS'", false]};
   this.EvtParms["REFRESH"] = [[{av:'STSELECVACANTE_GRID2_nFirstRecordOnPage'},{av:'STSELECVACANTE_GRID2_nEOF'},{ctrl:'STSELECVACANTE_GRID2',prop:'Rows'},{av:'AV15Vacantes_Nombre',fld:'vVACANTES_NOMBRE',pic:''},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV12UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'A273UsuariosVacanteEstatus',fld:'USUARIOSVACANTEESTATUS',pic:'9'},{av:'sPrefix'}],[]];
   this.EvtParms["START"] = [[],[{ctrl:'STSELECVACANTE_GRID2',prop:'Rows'}]];
   this.EvtParms["STSELECVACANTE_GRID2.LOAD"] = [[{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV12UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'A273UsuariosVacanteEstatus',fld:'USUARIOSVACANTEESTATUS',pic:'9'},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'}],[{av:'gx.fn.getCtrlProperty("VACANTES_ID","Visible")',ctrl:'VACANTES_ID',prop:'Visible'},{ctrl:'STSELECVACANTE_POSTULARSE',prop:'Visible'},{ctrl:'STSELECVACANTE_DECLINAR',prop:'Visible'},{ctrl:'STSELECVACANTE_TABLE3',prop:'Bordercolor'},{av:'gx.fn.getCtrlProperty("STSELECVACANTE_TABLE3","Backcolor")',ctrl:'STSELECVACANTE_TABLE3',prop:'Backcolor'}]];
   this.EvtParms["'POSTULARSE'"] = [[{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV12UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'A273UsuariosVacanteEstatus',fld:'USUARIOSVACANTEESTATUS',pic:'9'}],[{av:'AV13vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV5AlertProperties',fld:'vALERTPROPERTIES',pic:''}]];
   this.EvtParms["'DECLINAR'"] = [[{av:'STSELECVACANTE_GRID2_nFirstRecordOnPage'},{av:'STSELECVACANTE_GRID2_nEOF'},{ctrl:'STSELECVACANTE_GRID2',prop:'Rows'},{av:'AV15Vacantes_Nombre',fld:'vVACANTES_NOMBRE',pic:''},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV12UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'A273UsuariosVacanteEstatus',fld:'USUARIOSVACANTEESTATUS',pic:'9'},{av:'sPrefix'},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV10UsuarioReclutador',fld:'vUSUARIORECLUTADOR',pic:'ZZZZZZZZ9'}],[{av:'AV13vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV5AlertProperties',fld:'vALERTPROPERTIES',pic:''}]];
   this.EvtParms["UCALERTAS.ACCEPT"] = [[{av:'STSELECVACANTE_GRID2_nFirstRecordOnPage'},{av:'STSELECVACANTE_GRID2_nEOF'},{ctrl:'STSELECVACANTE_GRID2',prop:'Rows'},{av:'AV15Vacantes_Nombre',fld:'vVACANTES_NOMBRE',pic:''},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV12UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'A273UsuariosVacanteEstatus',fld:'USUARIOSVACANTEESTATUS',pic:'9'},{av:'sPrefix'},{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'A284SUBT_ReclutadorId',fld:'SUBT_RECLUTADORID',pic:'ZZZZZ9'},{av:'AV13vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'}],[{av:'AV10UsuarioReclutador',fld:'vUSUARIORECLUTADOR',pic:'ZZZZZZZZ9'},{av:'AV5AlertProperties',fld:'vALERTPROPERTIES',pic:''}]];
   this.EvtParms["'PROSPECTOS'"] = [[],[]];
   this.EvtParms["'SIGUIENTE'"] = [[{av:'STSELECVACANTE_GRID2_nFirstRecordOnPage'},{av:'STSELECVACANTE_GRID2_nEOF'},{ctrl:'STSELECVACANTE_GRID2',prop:'Rows'},{av:'AV15Vacantes_Nombre',fld:'vVACANTES_NOMBRE',pic:''},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV12UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'A273UsuariosVacanteEstatus',fld:'USUARIOSVACANTEESTATUS',pic:'9'},{av:'sPrefix'}],[]];
   this.EvtParms["'RETROCEDER'"] = [[{av:'STSELECVACANTE_GRID2_nFirstRecordOnPage'},{av:'STSELECVACANTE_GRID2_nEOF'},{ctrl:'STSELECVACANTE_GRID2',prop:'Rows'},{av:'AV15Vacantes_Nombre',fld:'vVACANTES_NOMBRE',pic:''},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV12UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'A273UsuariosVacanteEstatus',fld:'USUARIOSVACANTEESTATUS',pic:'9'},{av:'sPrefix'}],[]];
   this.EvtParms["VALID_VACANTES_ID"] = [[],[]];
   this.setVCMap("A11UsuariosId", "USUARIOSID", 0, "int", 6, 0);
   this.setVCMap("AV12UsuariosId", "vUSUARIOSID", 0, "int", 6, 0);
   this.setVCMap("A273UsuariosVacanteEstatus", "USUARIOSVACANTEESTATUS", 0, "int", 1, 0);
   this.setVCMap("AV10UsuarioReclutador", "vUSUARIORECLUTADOR", 0, "int", 9, 0);
   this.setVCMap("A284SUBT_ReclutadorId", "SUBT_RECLUTADORID", 0, "int", 6, 0);
   this.setVCMap("AV13vacantes_Id", "vVACANTES_ID", 0, "int", 9, 0);
   this.setVCMap("A11UsuariosId", "USUARIOSID", 0, "int", 6, 0);
   this.setVCMap("AV12UsuariosId", "vUSUARIOSID", 0, "int", 6, 0);
   this.setVCMap("A273UsuariosVacanteEstatus", "USUARIOSVACANTEESTATUS", 0, "int", 1, 0);
   this.setVCMap("A11UsuariosId", "USUARIOSID", 0, "int", 6, 0);
   this.setVCMap("AV12UsuariosId", "vUSUARIOSID", 0, "int", 6, 0);
   this.setVCMap("A273UsuariosVacanteEstatus", "USUARIOSVACANTEESTATUS", 0, "int", 1, 0);
   Stselecvacante_grid2Container.addRefreshingParm({rfrProp:"Rows", gxGrid:"Stselecvacante_grid2"});
   Stselecvacante_grid2Container.addRefreshingVar(this.GXValidFnc[9]);
   Stselecvacante_grid2Container.addRefreshingVar({rfrVar:"A11UsuariosId"});
   Stselecvacante_grid2Container.addRefreshingVar({rfrVar:"AV12UsuariosId"});
   Stselecvacante_grid2Container.addRefreshingVar({rfrVar:"A273UsuariosVacanteEstatus"});
   Stselecvacante_grid2Container.addRefreshingParm(this.GXValidFnc[9]);
   Stselecvacante_grid2Container.addRefreshingParm({rfrVar:"A11UsuariosId"});
   Stselecvacante_grid2Container.addRefreshingParm({rfrVar:"AV12UsuariosId"});
   Stselecvacante_grid2Container.addRefreshingParm({rfrVar:"A273UsuariosVacanteEstatus"});
   this.Initialize( );
});
