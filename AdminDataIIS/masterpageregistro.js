gx.evt.autoSkip=!1;gx.define("masterpageregistro",!1,function(){this.ServerClass="masterpageregistro";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.IsMasterPage=!0;this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.e130x2_client=function(){return this.executeServerEvent("ENTER_MPAGE",!0,null,!1,!1)};this.e140x2_client=function(){return this.executeServerEvent("CANCEL_MPAGE",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,5,9,11,12,13,14,15,18,22,28];this.GXLastCtrlId=28;n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"SECTION1",grid:0};n[9]={id:9,fld:"SECTION2",grid:0};n[11]={id:11,fld:"SECTION3",grid:0};n[12]={id:12,fld:"IMAGE1",grid:0};n[13]={id:13,fld:"TEXTOHTML",format:1,grid:0};n[14]={id:14,fld:"SECTION5",grid:0};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0};n[22]={id:22,lvl:0,type:"bits",len:1024,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCHROME_MPAGE",gxz:"ZV7chrome",gxold:"OV7chrome",gxvar:"AV7chrome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7chrome=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7chrome=n)},v2c:function(){gx.fn.setMultimediaValue("vCHROME_MPAGE",gx.O.AV7chrome,gx.O.AV10Chrome_GXI)},c2v:function(){gx.O.AV10Chrome_GXI=this.val_GXI();this.val()!==undefined&&(gx.O.AV7chrome=this.val())},val:function(){return gx.fn.getBlobValue("vCHROME_MPAGE")},val_GXI:function(){return gx.fn.getControlValue("vCHROME_GXI_MPAGE")},gxvar_GXI:"AV10Chrome_GXI",nac:gx.falseFn};n[28]={id:28,fld:"BLOQUEO",format:1,grid:0};this.AV10Chrome_GXI="";this.AV7chrome="";this.ZV7chrome="";this.OV7chrome="";this.AV7chrome="";this.Events={e130x2_client:["ENTER_MPAGE",!0],e140x2_client:["CANCEL_MPAGE",!0]};this.EvtParms.REFRESH_MPAGE=[[],[]];this.EvtParms.START_MPAGE=[[],[{ctrl:"FORM_MPAGE",prop:"Headerrawhtml"},{ctrl:"FORM_MPAGE",prop:"Caption"},{av:'gx.fn.getCtrlProperty("TEXTOHTML_MPAGE","Caption")',ctrl:"TEXTOHTML_MPAGE",prop:"Caption"},{av:"AV7chrome",fld:"vCHROME_MPAGE",pic:""},{av:'gx.fn.getCtrlProperty("vCHROME_MPAGE","Link")',ctrl:"vCHROME_MPAGE",prop:"Link"}]];this.Initialize();this.setComponent({id:"ENCABEZADO",GXClass:null,Prefix:"MPW0006",lvl:1})});gx.wi(function(){gx.createMasterPage(masterpageregistro)})