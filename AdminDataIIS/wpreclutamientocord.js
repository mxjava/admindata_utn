gx.evt.autoSkip=!1;gx.define("wpreclutamientocord",!1,function(){var t,n;this.ServerClass="wpreclutamientocord";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A290VacantesUsuariosEstatus=gx.fn.getIntegerValue("VACANTESUSUARIOSESTATUS",".");this.A277Vacantes_Plazas=gx.fn.getIntegerValue("VACANTES_PLAZAS",".");this.A290VacantesUsuariosEstatus=gx.fn.getIntegerValue("VACANTESUSUARIOSESTATUS",".");this.A277Vacantes_Plazas=gx.fn.getIntegerValue("VACANTES_PLAZAS",".")};this.e12372_client=function(){return this.executeServerEvent("'REVISAR'",!0,arguments[0],!1,!1)};this.e13372_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e14372_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,16,17,18,19,22,25,26,27,30,33,36,37,38,41,42,43,46,47,48,51,52,53,55,58,61,64,65,66,67];this.GXLastCtrlId=67;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",15,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"wpreclutamientocord",[],!0,5,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Nueva fila",!1,!1,!1,null,null,!1,"",!0,[1,2,3,5],!1,0,!1,!1);n=this.Grid1Container;n.startDiv(16,"Grid1table","0px","0px");n.startDiv(17,"","0px","0px");n.startDiv(18,"","0px","0px");n.startTable("Table2",19,"0px");n.startRow("","","","","","");n.startCell("","","","","","","","","","");n.startTable("Table1",22,"0px");n.startRow("","","","","","");n.startCell("","Center","Middle","","","","","","","");n.startDiv(25,"","0px","0px");n.startDiv(26,"","0px","100%");n.addComboBox("Vacantes_nombre",27,"vVACANTES_NOMBRE","","Vacantes_Nombre","int",null,0,!0,!1,40,"chr","");n.endDiv();n.endDiv();n.endCell();n.endRow();n.startRow("","","","","","");n.startCell("","","","","","","","","","");n.startTable("Table5",30,"0px");n.startRow("","","","","","");n.startCell("","","","","","","","","","");n.startTable("Table4",33,"0px");n.startRow("","","","","","");n.startCell("","","","","","","","","","");n.startDiv(36,"","0px","0px");n.addLabel();n.startDiv(37,"","0px","75%");n.addSingleLineEdit("Vacantes_id",38,"vVACANTES_ID","","","Vacantes_Id","int",9,"chr",9,9,"right",null,[],"Vacantes_id","Vacantes_Id",!0,0,!1,!1,"Attribute",1,"");n.endDiv();n.endDiv();n.endCell();n.endRow();n.startRow("","","","","","");n.startCell("","","","","","","","","","");n.startDiv(41,"","0px","0px");n.addLabel();n.startDiv(42,"","0px","20%");n.addSingleLineEdit("Proceso_completo",43,"vPROCESO_COMPLETO","","","Proceso_Completo","int",4,"chr",4,4,"right",null,[],"Proceso_completo","Proceso_Completo",!0,0,!1,!1,"AttributeLittle",1,"");n.endDiv();n.endDiv();n.endCell();n.endRow();n.startRow("","","","","","");n.startCell("","","","","","","","","","");n.startDiv(46,"","0px","0px");n.addLabel();n.startDiv(47,"","0px","20%");n.addSingleLineEdit("Enviado_cliente",48,"vENVIADO_CLIENTE","","","Enviado_Cliente","int",4,"chr",4,4,"right",null,[],"Enviado_cliente","Enviado_Cliente",!0,0,!1,!1,"AttributeLittle",1,"");n.endDiv();n.endDiv();n.endCell();n.endRow();n.startRow("","","","","","");n.startCell("","","","","","","","","","");n.startDiv(51,"","0px","0px");n.addLabel();n.startDiv(52,"","0px","20%");n.addSingleLineEdit("Descartados",53,"vDESCARTADOS","","","Descartados","int",4,"chr",4,4,"right",null,[],"Descartados","Descartados",!0,0,!1,!1,"AttributeLittle",1,"");n.endDiv();n.endDiv();n.endCell();n.endRow();n.endTable();n.endCell();n.startCell("","","","","","","","","","");n.startTable("Table3",55,"0px");n.startRow("","","","","","");n.startCell("","Center","Middle","","","","","","","");n.addTextBlock("TEXTBLOCK3",null,58);n.endCell();n.endRow();n.startRow("","","","","","");n.startCell("","Center","Middle","","","","","","","");n.addTextBlock("TEXTBLOCK1",null,61);n.endCell();n.endRow();n.endTable();n.endCell();n.endRow();n.endTable();n.endCell();n.endRow();n.endTable();n.endCell();n.endRow();n.startRow("","","","","","");n.startCell("","Center","Middle","","","","","","","");n.addBitmap("Image3","IMAGE3",64,0,"px",0,"px","e12372_client","","Revisar","Image","");n.endCell();n.endRow();n.endTable();n.endDiv();n.endDiv();n.startDiv(65,"","0px","0px");n.startDiv(66,"","0px","0px");n.addTextBlock("TEXTBLOCK2",null,67);n.endDiv();n.endDiv();n.endDiv();this.Grid1Container.emptyText="";this.setGrid(n);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLE6",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TEXTBLOCK4",format:0,grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"TEXTBLOCK5",format:0,grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"",grid:0};t[16]={id:16,fld:"GRID1TABLE",grid:15};t[17]={id:17,fld:"",grid:15};t[18]={id:18,fld:"",grid:15};t[19]={id:19,fld:"TABLE2",grid:15};t[22]={id:22,fld:"TABLE1",grid:15};t[25]={id:25,fld:"",grid:15};t[26]={id:26,fld:"",grid:15};t[27]={id:27,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,isacc:0,grid:15,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vVACANTES_NOMBRE",gxz:"ZV5Vacantes_Nombre",gxold:"OV5Vacantes_Nombre",gxvar:"AV5Vacantes_Nombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"dyncombo",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.AV5Vacantes_Nombre=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV5Vacantes_Nombre=gx.num.intval(n))},v2c:function(n){gx.fn.setGridComboBoxValue("vVACANTES_NOMBRE",n||gx.fn.currentGridRowImpl(15),gx.O.AV5Vacantes_Nombre)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV5Vacantes_Nombre=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vVACANTES_NOMBRE",n||gx.fn.currentGridRowImpl(15),".")},nac:gx.falseFn};t[30]={id:30,fld:"TABLE5",grid:15};t[33]={id:33,fld:"TABLE4",grid:15};t[36]={id:36,fld:"",grid:15};t[37]={id:37,fld:"",grid:15};t[38]={id:38,lvl:2,type:"int",len:9,dec:0,sign:!1,pic:"ZZZZZZZZ9",ro:0,isacc:0,grid:15,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vVACANTES_ID",gxz:"ZV11Vacantes_Id",gxold:"OV11Vacantes_Id",gxvar:"AV11Vacantes_Id",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.AV11Vacantes_Id=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV11Vacantes_Id=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vVACANTES_ID",n||gx.fn.currentGridRowImpl(15),gx.O.AV11Vacantes_Id,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV11Vacantes_Id=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vVACANTES_ID",n||gx.fn.currentGridRowImpl(15),".")},nac:gx.falseFn};t[41]={id:41,fld:"",grid:15};t[42]={id:42,fld:"",grid:15};t[43]={id:43,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,isacc:0,grid:15,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPROCESO_COMPLETO",gxz:"ZV6Proceso_Completo",gxold:"OV6Proceso_Completo",gxvar:"AV6Proceso_Completo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.AV6Proceso_Completo=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6Proceso_Completo=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vPROCESO_COMPLETO",n||gx.fn.currentGridRowImpl(15),gx.O.AV6Proceso_Completo,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV6Proceso_Completo=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vPROCESO_COMPLETO",n||gx.fn.currentGridRowImpl(15),".")},nac:gx.falseFn};t[46]={id:46,fld:"",grid:15};t[47]={id:47,fld:"",grid:15};t[48]={id:48,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,isacc:0,grid:15,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vENVIADO_CLIENTE",gxz:"ZV7Enviado_Cliente",gxold:"OV7Enviado_Cliente",gxvar:"AV7Enviado_Cliente",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.AV7Enviado_Cliente=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV7Enviado_Cliente=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vENVIADO_CLIENTE",n||gx.fn.currentGridRowImpl(15),gx.O.AV7Enviado_Cliente,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV7Enviado_Cliente=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vENVIADO_CLIENTE",n||gx.fn.currentGridRowImpl(15),".")},nac:gx.falseFn};t[51]={id:51,fld:"",grid:15};t[52]={id:52,fld:"",grid:15};t[53]={id:53,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,isacc:0,grid:15,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDESCARTADOS",gxz:"ZV8Descartados",gxold:"OV8Descartados",gxvar:"AV8Descartados",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.AV8Descartados=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8Descartados=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vDESCARTADOS",n||gx.fn.currentGridRowImpl(15),gx.O.AV8Descartados,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV8Descartados=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vDESCARTADOS",n||gx.fn.currentGridRowImpl(15),".")},nac:gx.falseFn};t[55]={id:55,fld:"TABLE3",grid:15};t[58]={id:58,fld:"TEXTBLOCK3",format:0,grid:15};t[61]={id:61,fld:"TEXTBLOCK1",format:0,grid:15};t[64]={id:64,fld:"IMAGE3",grid:15,evt:"e12372_client"};t[65]={id:65,fld:"",grid:15};t[66]={id:66,fld:"",grid:15};t[67]={id:67,fld:"TEXTBLOCK2",format:0,grid:15};this.ZV5Vacantes_Nombre=0;this.OV5Vacantes_Nombre=0;this.ZV11Vacantes_Id=0;this.OV11Vacantes_Id=0;this.ZV6Proceso_Completo=0;this.OV6Proceso_Completo=0;this.ZV7Enviado_Cliente=0;this.OV7Enviado_Cliente=0;this.ZV8Descartados=0;this.OV8Descartados=0;this.AV5Vacantes_Nombre=0;this.AV11Vacantes_Id=0;this.AV6Proceso_Completo=0;this.AV7Enviado_Cliente=0;this.AV8Descartados=0;this.A263Vacantes_Id=0;this.A290VacantesUsuariosEstatus=0;this.A277Vacantes_Plazas=0;this.Events={e12372_client:["'REVISAR'",!0],e13372_client:["ENTER",!0],e14372_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"A263Vacantes_Id",fld:"VACANTES_ID",pic:"ZZZZZZZZ9"},{av:"A290VacantesUsuariosEstatus",fld:"VACANTESUSUARIOSESTATUS",pic:"ZZZ9"},{av:"A277Vacantes_Plazas",fld:"VACANTES_PLAZAS",pic:"ZZZ9"}],[]];this.EvtParms["GRID1.LOAD"]=[[{av:"A263Vacantes_Id",fld:"VACANTES_ID",pic:"ZZZZZZZZ9"},{av:"A290VacantesUsuariosEstatus",fld:"VACANTESUSUARIOSESTATUS",pic:"ZZZ9"},{av:"A277Vacantes_Plazas",fld:"VACANTES_PLAZAS",pic:"ZZZ9"}],[{av:'gx.fn.getCtrlProperty("TEXTBLOCK1","Fontbold")',ctrl:"TEXTBLOCK1",prop:"Fontbold"},{av:'gx.fn.getCtrlProperty("TEXTBLOCK1","Forecolor")',ctrl:"TEXTBLOCK1",prop:"Forecolor"},{av:'gx.fn.getCtrlProperty("TEXTBLOCK1","Fontsize")',ctrl:"TEXTBLOCK1",prop:"Fontsize"},{av:'gx.fn.getCtrlProperty("TEXTBLOCK5","Visible")',ctrl:"TEXTBLOCK5",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vPROCESO_COMPLETO","Fontitalic")',ctrl:"vPROCESO_COMPLETO",prop:"Fontitalic"},{av:'gx.fn.getCtrlProperty("vENVIADO_CLIENTE","Fontitalic")',ctrl:"vENVIADO_CLIENTE",prop:"Fontitalic"},{av:'gx.fn.getCtrlProperty("vDESCARTADOS","Fontitalic")',ctrl:"vDESCARTADOS",prop:"Fontitalic"},{av:'gx.fn.getCtrlProperty("vVACANTES_ID","Visible")',ctrl:"vVACANTES_ID",prop:"Visible"},{av:"AV11Vacantes_Id",fld:"vVACANTES_ID",pic:"ZZZZZZZZ9"},{av:"AV6Proceso_Completo",fld:"vPROCESO_COMPLETO",pic:"ZZZ9"},{av:"AV8Descartados",fld:"vDESCARTADOS",pic:"ZZZ9"},{av:"AV7Enviado_Cliente",fld:"vENVIADO_CLIENTE",pic:"ZZZ9"},{ctrl:"vVACANTES_NOMBRE"},{av:"AV5Vacantes_Nombre",fld:"vVACANTES_NOMBRE",pic:"ZZZ9",hsh:!0},{av:'gx.fn.getCtrlProperty("TEXTBLOCK1","Caption")',ctrl:"TEXTBLOCK1",prop:"Caption"}]];this.EvtParms["'REVISAR'"]=[[{ctrl:"vVACANTES_NOMBRE"},{av:"AV5Vacantes_Nombre",fld:"vVACANTES_NOMBRE",pic:"ZZZ9",hsh:!0}],[]];this.setVCMap("A263Vacantes_Id","VACANTES_ID",0,"int",9,0);this.setVCMap("A290VacantesUsuariosEstatus","VACANTESUSUARIOSESTATUS",0,"int",4,0);this.setVCMap("A277Vacantes_Plazas","VACANTES_PLAZAS",0,"int",4,0);this.setVCMap("A263Vacantes_Id","VACANTES_ID",0,"int",9,0);this.setVCMap("A290VacantesUsuariosEstatus","VACANTESUSUARIOSESTATUS",0,"int",4,0);this.setVCMap("A277Vacantes_Plazas","VACANTES_PLAZAS",0,"int",4,0);this.setVCMap("A263Vacantes_Id","VACANTES_ID",0,"int",9,0);this.setVCMap("A290VacantesUsuariosEstatus","VACANTESUSUARIOSESTATUS",0,"int",4,0);this.setVCMap("A277Vacantes_Plazas","VACANTES_PLAZAS",0,"int",4,0);n.addRefreshingVar({rfrVar:"A263Vacantes_Id"});n.addRefreshingVar({rfrVar:"A290VacantesUsuariosEstatus"});n.addRefreshingVar({rfrVar:"A277Vacantes_Plazas"});n.addRefreshingParm({rfrVar:"A263Vacantes_Id"});n.addRefreshingParm({rfrVar:"A290VacantesUsuariosEstatus"});n.addRefreshingParm({rfrVar:"A277Vacantes_Plazas"});this.Initialize()});gx.wi(function(){gx.createParentObj(wpreclutamientocord)})