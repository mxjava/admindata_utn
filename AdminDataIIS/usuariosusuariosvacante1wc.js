gx.evt.autoSkip=!1;gx.define("usuariosusuariosvacante1wc",!0,function(n){var t,i;this.ServerClass="usuariosusuariosvacante1wc";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV6SUBT_ReclutadorId=gx.fn.getIntegerValue("vSUBT_RECLUTADORID",".");this.AV6SUBT_ReclutadorId=gx.fn.getIntegerValue("vSUBT_RECLUTADORID",".")};this.Valid_Vacantes_id=function(){var n=gx.fn.currentGridRowImpl(20);return this.validCliEvt("Valid_Vacantes_id",20,function(){try{if(gx.fn.currentGridRowImpl(20)===0)return!0;var n=gx.util.balloon.getNew("VACANTES_ID",gx.fn.currentGridRowImpl(20));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e112v2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e142v2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e152v2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,18,19,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36];this.GXLastCtrlId=36;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",20,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"usuariosusuariosvacante1wc",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addSingleLineEdit(263,21,"VACANTES_ID","ID","","Vacantes_Id","int",0,"px",9,9,"right",null,[],263,"Vacantes_Id",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(264,22,"VACANTES_NOMBRE","Nombre","","Vacantes_Nombre","svchar",0,"px",40,40,"left",null,[],264,"Vacantes_Nombre",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");i.addSingleLineEdit(274,23,"VACANTES_DESCRIPCION","Descripción","","Vacantes_Descripcion","svchar",0,"px",1e3,80,"left",null,[],274,"Vacantes_Descripcion",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addComboBox(265,24,"VACANTES_STATUS","Estatus","Vacantes_Status","int",null,0,!0,!1,0,"px","WWColumn WWOptionalColumn");i.addSingleLineEdit(266,25,"VACANTES_FECHAINICIO","Inicio","","Vacantes_FechaInicio","date",0,"px",8,8,"right",null,[],266,"Vacantes_FechaInicio",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(267,26,"VACANTES_SUELDO","Sueldo","","Vacantes_Sueldo","decimal",0,"px",6,6,"right",null,[],267,"Vacantes_Sueldo",!0,3,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addComboBox(268,27,"VACANTES_TIPO","Tipo","Vacantes_Tipo","int",null,0,!0,!1,0,"px","WWColumn WWOptionalColumn");i.addSingleLineEdit(269,28,"VACANTES_DURACION","Duración","","Vacantes_Duracion","int",0,"px",4,4,"right",null,[],269,"Vacantes_Duracion",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addComboBox(270,29,"VACANTES_DURACION_NOM","----","Vacantes_Duracion_Nom","int",null,0,!0,!1,0,"px","WWColumn WWOptionalColumn");i.addSingleLineEdit(277,30,"VACANTES_PLAZAS","Vacantes","","Vacantes_Plazas","int",0,"px",4,4,"right",null,[],277,"Vacantes_Plazas",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit("Update",31,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");i.addSingleLineEdit("Delete",32,"vDELETE","","","Delete","char",0,"px",20,20,"left",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(i);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLETOP",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"BTNINSERT",grid:0,evt:"e112v2_client"};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"GRIDCELL",grid:0};t[14]={id:14,fld:"GRIDTABLE",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[21]={id:21,lvl:2,type:"int",len:9,dec:0,sign:!1,pic:"ZZZZZZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:this.Valid_Vacantes_id,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VACANTES_ID",gxz:"Z263Vacantes_Id",gxold:"O263Vacantes_Id",gxvar:"A263Vacantes_Id",ucs:[],op:[22,23,24,25,26,27,28,29,30],ip:[22,23,24,25,26,27,28,29,30,21],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A263Vacantes_Id=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z263Vacantes_Id=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("VACANTES_ID",n||gx.fn.currentGridRowImpl(20),gx.O.A263Vacantes_Id,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A263Vacantes_Id=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("VACANTES_ID",n||gx.fn.currentGridRowImpl(20),".")},nac:gx.falseFn};t[22]={id:22,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VACANTES_NOMBRE",gxz:"Z264Vacantes_Nombre",gxold:"O264Vacantes_Nombre",gxvar:"A264Vacantes_Nombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A264Vacantes_Nombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z264Vacantes_Nombre=n)},v2c:function(n){gx.fn.setGridControlValue("VACANTES_NOMBRE",n||gx.fn.currentGridRowImpl(20),gx.O.A264Vacantes_Nombre,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A264Vacantes_Nombre=this.val(n))},val:function(n){return gx.fn.getGridControlValue("VACANTES_NOMBRE",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[23]={id:23,lvl:2,type:"svchar",len:1e3,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VACANTES_DESCRIPCION",gxz:"Z274Vacantes_Descripcion",gxold:"O274Vacantes_Descripcion",gxvar:"A274Vacantes_Descripcion",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A274Vacantes_Descripcion=n)},v2z:function(n){n!==undefined&&(gx.O.Z274Vacantes_Descripcion=n)},v2c:function(n){gx.fn.setGridControlValue("VACANTES_DESCRIPCION",n||gx.fn.currentGridRowImpl(20),gx.O.A274Vacantes_Descripcion,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A274Vacantes_Descripcion=this.val(n))},val:function(n){return gx.fn.getGridControlValue("VACANTES_DESCRIPCION",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[24]={id:24,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VACANTES_STATUS",gxz:"Z265Vacantes_Status",gxold:"O265Vacantes_Status",gxvar:"A265Vacantes_Status",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A265Vacantes_Status=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z265Vacantes_Status=gx.num.intval(n))},v2c:function(n){gx.fn.setGridComboBoxValue("VACANTES_STATUS",n||gx.fn.currentGridRowImpl(20),gx.O.A265Vacantes_Status);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A265Vacantes_Status=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("VACANTES_STATUS",n||gx.fn.currentGridRowImpl(20),".")},nac:gx.falseFn};t[25]={id:25,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VACANTES_FECHAINICIO",gxz:"Z266Vacantes_FechaInicio",gxold:"O266Vacantes_FechaInicio",gxvar:"A266Vacantes_FechaInicio",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A266Vacantes_FechaInicio=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z266Vacantes_FechaInicio=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("VACANTES_FECHAINICIO",n||gx.fn.currentGridRowImpl(20),gx.O.A266Vacantes_FechaInicio,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A266Vacantes_FechaInicio=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("VACANTES_FECHAINICIO",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[26]={id:26,lvl:2,type:"decimal",len:6,dec:3,sign:!1,pic:"Z9.999",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VACANTES_SUELDO",gxz:"Z267Vacantes_Sueldo",gxold:"O267Vacantes_Sueldo",gxvar:"A267Vacantes_Sueldo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A267Vacantes_Sueldo=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z267Vacantes_Sueldo=gx.fn.toDecimalValue(n,".",","))},v2c:function(n){gx.fn.setGridDecimalValue("VACANTES_SUELDO",n||gx.fn.currentGridRowImpl(20),gx.O.A267Vacantes_Sueldo,3,",")},c2v:function(n){this.val(n)!==undefined&&(gx.O.A267Vacantes_Sueldo=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("VACANTES_SUELDO",n||gx.fn.currentGridRowImpl(20),".",",")},nac:gx.falseFn};t[27]={id:27,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VACANTES_TIPO",gxz:"Z268Vacantes_Tipo",gxold:"O268Vacantes_Tipo",gxvar:"A268Vacantes_Tipo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A268Vacantes_Tipo=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z268Vacantes_Tipo=gx.num.intval(n))},v2c:function(n){gx.fn.setGridComboBoxValue("VACANTES_TIPO",n||gx.fn.currentGridRowImpl(20),gx.O.A268Vacantes_Tipo);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A268Vacantes_Tipo=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("VACANTES_TIPO",n||gx.fn.currentGridRowImpl(20),".")},nac:gx.falseFn};t[28]={id:28,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VACANTES_DURACION",gxz:"Z269Vacantes_Duracion",gxold:"O269Vacantes_Duracion",gxvar:"A269Vacantes_Duracion",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A269Vacantes_Duracion=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z269Vacantes_Duracion=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("VACANTES_DURACION",n||gx.fn.currentGridRowImpl(20),gx.O.A269Vacantes_Duracion,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A269Vacantes_Duracion=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("VACANTES_DURACION",n||gx.fn.currentGridRowImpl(20),".")},nac:gx.falseFn};t[29]={id:29,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VACANTES_DURACION_NOM",gxz:"Z270Vacantes_Duracion_Nom",gxold:"O270Vacantes_Duracion_Nom",gxvar:"A270Vacantes_Duracion_Nom",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A270Vacantes_Duracion_Nom=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z270Vacantes_Duracion_Nom=gx.num.intval(n))},v2c:function(n){gx.fn.setGridComboBoxValue("VACANTES_DURACION_NOM",n||gx.fn.currentGridRowImpl(20),gx.O.A270Vacantes_Duracion_Nom);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A270Vacantes_Duracion_Nom=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("VACANTES_DURACION_NOM",n||gx.fn.currentGridRowImpl(20),".")},nac:gx.falseFn};t[30]={id:30,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VACANTES_PLAZAS",gxz:"Z277Vacantes_Plazas",gxold:"O277Vacantes_Plazas",gxvar:"A277Vacantes_Plazas",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A277Vacantes_Plazas=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z277Vacantes_Plazas=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("VACANTES_PLAZAS",n||gx.fn.currentGridRowImpl(20),gx.O.A277Vacantes_Plazas,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A277Vacantes_Plazas=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("VACANTES_PLAZAS",n||gx.fn.currentGridRowImpl(20),".")},nac:gx.falseFn};t[31]={id:31,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",gxz:"ZV11Update",gxold:"OV11Update",gxvar:"AV11Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV11Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(20),gx.O.AV11Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV11Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[32]={id:32,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",gxz:"ZV12Delete",gxold:"OV12Delete",gxvar:"AV12Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(20),gx.O.AV12Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[33]={id:33,fld:"",grid:0};t[34]={id:34,fld:"",grid:0};t[35]={id:35,fld:"",grid:0};t[36]={id:36,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUBT_RECLUTADORID",gxz:"Z284SUBT_ReclutadorId",gxold:"O284SUBT_ReclutadorId",gxvar:"A284SUBT_ReclutadorId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A284SUBT_ReclutadorId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z284SUBT_ReclutadorId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("SUBT_RECLUTADORID",gx.O.A284SUBT_ReclutadorId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A284SUBT_ReclutadorId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("SUBT_RECLUTADORID",".")},nac:gx.falseFn};this.declareDomainHdlr(36,function(){});this.Z263Vacantes_Id=0;this.O263Vacantes_Id=0;this.Z264Vacantes_Nombre="";this.O264Vacantes_Nombre="";this.Z274Vacantes_Descripcion="";this.O274Vacantes_Descripcion="";this.Z265Vacantes_Status=0;this.O265Vacantes_Status=0;this.Z266Vacantes_FechaInicio=gx.date.nullDate();this.O266Vacantes_FechaInicio=gx.date.nullDate();this.Z267Vacantes_Sueldo=0;this.O267Vacantes_Sueldo=0;this.Z268Vacantes_Tipo=0;this.O268Vacantes_Tipo=0;this.Z269Vacantes_Duracion=0;this.O269Vacantes_Duracion=0;this.Z270Vacantes_Duracion_Nom=0;this.O270Vacantes_Duracion_Nom=0;this.Z277Vacantes_Plazas=0;this.O277Vacantes_Plazas=0;this.ZV11Update="";this.OV11Update="";this.ZV12Delete="";this.OV12Delete="";this.A284SUBT_ReclutadorId=0;this.Z284SUBT_ReclutadorId=0;this.O284SUBT_ReclutadorId=0;this.A284SUBT_ReclutadorId=0;this.AV6SUBT_ReclutadorId=0;this.A263Vacantes_Id=0;this.A264Vacantes_Nombre="";this.A274Vacantes_Descripcion="";this.A265Vacantes_Status=0;this.A266Vacantes_FechaInicio=gx.date.nullDate();this.A267Vacantes_Sueldo=0;this.A268Vacantes_Tipo=0;this.A269Vacantes_Duracion=0;this.A270Vacantes_Duracion_Nom=0;this.A277Vacantes_Plazas=0;this.AV11Update="";this.AV12Delete="";this.Events={e112v2_client:["'DOINSERT'",!0],e142v2_client:["ENTER",!0],e152v2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6SUBT_ReclutadorId",fld:"vSUBT_RECLUTADORID",pic:"ZZZZZ9"},{av:"AV11Update",fld:"vUPDATE",pic:""},{av:"AV12Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.START=[[{av:"AV16Pgmname",fld:"vPGMNAME",pic:""},{av:"AV6SUBT_ReclutadorId",fld:"vSUBT_RECLUTADORID",pic:"ZZZZZ9"}],[{ctrl:"GRID",prop:"Rows"},{av:"AV11Update",fld:"vUPDATE",pic:""},{av:"AV12Delete",fld:"vDELETE",pic:""},{av:'gx.fn.getCtrlProperty("SUBT_RECLUTADORID","Visible")',ctrl:"SUBT_RECLUTADORID",prop:"Visible"}]];this.EvtParms["GRID.LOAD"]=[[{av:"A263Vacantes_Id",fld:"VACANTES_ID",pic:"ZZZZZZZZ9",hsh:!0}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"},{av:'gx.fn.getCtrlProperty("VACANTES_NOMBRE","Link")',ctrl:"VACANTES_NOMBRE",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A263Vacantes_Id",fld:"VACANTES_ID",pic:"ZZZZZZZZ9",hsh:!0}],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6SUBT_ReclutadorId",fld:"vSUBT_RECLUTADORID",pic:"ZZZZZ9"},{av:"AV11Update",fld:"vUPDATE",pic:""},{av:"AV12Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6SUBT_ReclutadorId",fld:"vSUBT_RECLUTADORID",pic:"ZZZZZ9"},{av:"AV11Update",fld:"vUPDATE",pic:""},{av:"AV12Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6SUBT_ReclutadorId",fld:"vSUBT_RECLUTADORID",pic:"ZZZZZ9"},{av:"AV11Update",fld:"vUPDATE",pic:""},{av:"AV12Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6SUBT_ReclutadorId",fld:"vSUBT_RECLUTADORID",pic:"ZZZZZ9"},{av:"AV11Update",fld:"vUPDATE",pic:""},{av:"AV12Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.VALID_VACANTES_ID=[[{av:"A264Vacantes_Nombre",fld:"VACANTES_NOMBRE",pic:""},{av:"A274Vacantes_Descripcion",fld:"VACANTES_DESCRIPCION",pic:""},{ctrl:"VACANTES_STATUS"},{av:"A265Vacantes_Status",fld:"VACANTES_STATUS",pic:"ZZZ9"},{av:"A266Vacantes_FechaInicio",fld:"VACANTES_FECHAINICIO",pic:""},{av:"A267Vacantes_Sueldo",fld:"VACANTES_SUELDO",pic:"Z9.999"},{ctrl:"VACANTES_TIPO"},{av:"A268Vacantes_Tipo",fld:"VACANTES_TIPO",pic:"ZZZ9"},{av:"A269Vacantes_Duracion",fld:"VACANTES_DURACION",pic:"ZZZ9"},{ctrl:"VACANTES_DURACION_NOM"},{av:"A270Vacantes_Duracion_Nom",fld:"VACANTES_DURACION_NOM",pic:"ZZZ9"},{av:"A277Vacantes_Plazas",fld:"VACANTES_PLAZAS",pic:"ZZZ9"},{av:"A263Vacantes_Id",fld:"VACANTES_ID",pic:"ZZZZZZZZ9",hsh:!0}],[{av:"A264Vacantes_Nombre",fld:"VACANTES_NOMBRE",pic:""},{av:"A274Vacantes_Descripcion",fld:"VACANTES_DESCRIPCION",pic:""},{ctrl:"VACANTES_STATUS"},{av:"A265Vacantes_Status",fld:"VACANTES_STATUS",pic:"ZZZ9"},{av:"A266Vacantes_FechaInicio",fld:"VACANTES_FECHAINICIO",pic:""},{av:"A267Vacantes_Sueldo",fld:"VACANTES_SUELDO",pic:"Z9.999"},{ctrl:"VACANTES_TIPO"},{av:"A268Vacantes_Tipo",fld:"VACANTES_TIPO",pic:"ZZZ9"},{av:"A269Vacantes_Duracion",fld:"VACANTES_DURACION",pic:"ZZZ9"},{ctrl:"VACANTES_DURACION_NOM"},{av:"A270Vacantes_Duracion_Nom",fld:"VACANTES_DURACION_NOM",pic:"ZZZ9"},{av:"A277Vacantes_Plazas",fld:"VACANTES_PLAZAS",pic:"ZZZ9"}]];this.setVCMap("AV6SUBT_ReclutadorId","vSUBT_RECLUTADORID",0,"int",6,0);this.setVCMap("AV6SUBT_ReclutadorId","vSUBT_RECLUTADORID",0,"int",6,0);this.setVCMap("AV6SUBT_ReclutadorId","vSUBT_RECLUTADORID",0,"int",6,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV6SUBT_ReclutadorId"});i.addRefreshingVar({rfrVar:"AV11Update",rfrProp:"Value",gxAttId:"Update"});i.addRefreshingVar({rfrVar:"AV12Delete",rfrProp:"Value",gxAttId:"Delete"});i.addRefreshingParm({rfrVar:"AV6SUBT_ReclutadorId"});i.addRefreshingParm({rfrVar:"AV11Update",rfrProp:"Value",gxAttId:"Update"});i.addRefreshingParm({rfrVar:"AV12Delete",rfrProp:"Value",gxAttId:"Delete"});this.Initialize()})