gx.evt.autoSkip=!1;gx.define("meniniciogeneral",!0,function(n){this.ServerClass="meniniciogeneral";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Meninicioid=function(){return this.validCliEvt("Valid_Meninicioid",0,function(){try{var n=gx.util.balloon.getNew("MENINICIOID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e110v1_client=function(){return this.clearMessages(),this.call("meninicio.aspx",["UPD",this.A58menInicioId]),this.refreshOutputs([]),gx.$.Deferred().resolve()};this.e120v1_client=function(){return this.clearMessages(),this.call("meninicio.aspx",["DLT",this.A58menInicioId]),this.refreshOutputs([]),gx.$.Deferred().resolve()};this.e150v2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e160v2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53];this.GXLastCtrlId=53;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"BTNUPDATE",grid:0,evt:"e110v1_client"};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"BTNDELETE",grid:0,evt:"e120v1_client"};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"ATTRIBUTESTABLE",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Meninicioid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENINICIOID",gxz:"Z58menInicioId",gxold:"O58menInicioId",gxvar:"A58menInicioId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A58menInicioId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z58menInicioId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("MENINICIOID",gx.O.A58menInicioId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A58menInicioId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("MENINICIOID",".")},nac:gx.falseFn};this.declareDomainHdlr(18,function(){});t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,lvl:0,type:"svchar",len:255,dec:0,sign:!1,ro:1,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENINICIODES",gxz:"Z150menInicioDes",gxold:"O150menInicioDes",gxvar:"A150menInicioDes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A150menInicioDes=n)},v2z:function(n){n!==undefined&&(gx.O.Z150menInicioDes=n)},v2c:function(){gx.fn.setControlValue("MENINICIODES",gx.O.A150menInicioDes,0)},c2v:function(){this.val()!==undefined&&(gx.O.A150menInicioDes=this.val())},val:function(){return gx.fn.getControlValue("MENINICIODES")},nac:gx.falseFn};t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENINICIOFECINI",gxz:"Z186menInicioFecIni",gxold:"O186menInicioFecIni",gxvar:"A186menInicioFecIni",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A186menInicioFecIni=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z186menInicioFecIni=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("MENINICIOFECINI",gx.O.A186menInicioFecIni,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A186menInicioFecIni=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("MENINICIOFECINI")},nac:gx.falseFn};this.declareDomainHdlr(28,function(){});t[29]={id:29,fld:"",grid:0};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENINICIOFECFIN",gxz:"Z76menInicioFecFin",gxold:"O76menInicioFecFin",gxvar:"A76menInicioFecFin",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A76menInicioFecFin=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z76menInicioFecFin=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("MENINICIOFECFIN",gx.O.A76menInicioFecFin,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A76menInicioFecFin=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("MENINICIOFECFIN")},nac:gx.falseFn};this.declareDomainHdlr(33,function(){});t[34]={id:34,fld:"",grid:0};t[35]={id:35,fld:"",grid:0};t[36]={id:36,fld:"",grid:0};t[37]={id:37,fld:"",grid:0};t[38]={id:38,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENINICIOSTAT",gxz:"Z77menInicioStat",gxold:"O77menInicioStat",gxvar:"A77menInicioStat",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A77menInicioStat=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z77menInicioStat=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("MENINICIOSTAT",gx.O.A77menInicioStat)},c2v:function(){this.val()!==undefined&&(gx.O.A77menInicioStat=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("MENINICIOSTAT",".")},nac:gx.falseFn};t[39]={id:39,fld:"",grid:0};t[40]={id:40,fld:"",grid:0};t[41]={id:41,fld:"",grid:0};t[42]={id:42,fld:"",grid:0};t[43]={id:43,lvl:0,type:"dtime",len:10,dec:8,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENINICIOFECCAP",gxz:"Z185menInicioFecCap",gxold:"O185menInicioFecCap",gxvar:"A185menInicioFecCap",dp:{f:0,st:!0,wn:!1,mf:!1,pic:"99/99/9999 99:99:99",dec:8},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A185menInicioFecCap=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z185menInicioFecCap=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("MENINICIOFECCAP",gx.O.A185menInicioFecCap,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A185menInicioFecCap=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getDateTimeValue("MENINICIOFECCAP")},nac:gx.falseFn};this.declareDomainHdlr(43,function(){});t[44]={id:44,fld:"",grid:0};t[45]={id:45,fld:"",grid:0};t[46]={id:46,fld:"",grid:0};t[47]={id:47,fld:"",grid:0};t[48]={id:48,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SGUSRMENID",gxz:"Z59sgUsrMenId",gxold:"O59sgUsrMenId",gxvar:"A59sgUsrMenId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A59sgUsrMenId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z59sgUsrMenId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("SGUSRMENID",gx.O.A59sgUsrMenId,0)},c2v:function(){this.val()!==undefined&&(gx.O.A59sgUsrMenId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("SGUSRMENID",".")},nac:gx.falseFn};t[49]={id:49,fld:"",grid:0};t[50]={id:50,fld:"",grid:0};t[51]={id:51,fld:"",grid:0};t[52]={id:52,fld:"",grid:0};t[53]={id:53,lvl:0,type:"svchar",len:20,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SGUSRMENNOM",gxz:"Z187sgUsrMenNom",gxold:"O187sgUsrMenNom",gxvar:"A187sgUsrMenNom",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A187sgUsrMenNom=n)},v2z:function(n){n!==undefined&&(gx.O.Z187sgUsrMenNom=n)},v2c:function(){gx.fn.setControlValue("SGUSRMENNOM",gx.O.A187sgUsrMenNom,0)},c2v:function(){this.val()!==undefined&&(gx.O.A187sgUsrMenNom=this.val())},val:function(){return gx.fn.getControlValue("SGUSRMENNOM")},nac:gx.falseFn};this.A58menInicioId=0;this.Z58menInicioId=0;this.O58menInicioId=0;this.A150menInicioDes="";this.Z150menInicioDes="";this.O150menInicioDes="";this.A186menInicioFecIni=gx.date.nullDate();this.Z186menInicioFecIni=gx.date.nullDate();this.O186menInicioFecIni=gx.date.nullDate();this.A76menInicioFecFin=gx.date.nullDate();this.Z76menInicioFecFin=gx.date.nullDate();this.O76menInicioFecFin=gx.date.nullDate();this.A77menInicioStat=0;this.Z77menInicioStat=0;this.O77menInicioStat=0;this.A185menInicioFecCap=gx.date.nullDate();this.Z185menInicioFecCap=gx.date.nullDate();this.O185menInicioFecCap=gx.date.nullDate();this.A59sgUsrMenId=0;this.Z59sgUsrMenId=0;this.O59sgUsrMenId=0;this.A187sgUsrMenNom="";this.Z187sgUsrMenNom="";this.O187sgUsrMenNom="";this.A58menInicioId=0;this.A150menInicioDes="";this.A186menInicioFecIni=gx.date.nullDate();this.A76menInicioFecFin=gx.date.nullDate();this.A77menInicioStat=0;this.A185menInicioFecCap=gx.date.nullDate();this.A59sgUsrMenId=0;this.A187sgUsrMenNom="";this.Events={e150v2_client:["ENTER",!0],e160v2_client:["CANCEL",!0],e110v1_client:["'DOUPDATE'",!1],e120v1_client:["'DODELETE'",!1]};this.EvtParms.REFRESH=[[{av:"A58menInicioId",fld:"MENINICIOID",pic:"ZZZZZ9"}],[]];this.EvtParms.START=[[{av:"AV13Pgmname",fld:"vPGMNAME",pic:""},{av:"AV6menInicioId",fld:"vMENINICIOID",pic:"ZZZZZ9"}],[]];this.EvtParms.LOAD=[[],[]];this.EvtParms["'DOUPDATE'"]=[[{av:"A58menInicioId",fld:"MENINICIOID",pic:"ZZZZZ9"}],[]];this.EvtParms["'DODELETE'"]=[[{av:"A58menInicioId",fld:"MENINICIOID",pic:"ZZZZZ9"}],[]];this.EvtParms.VALID_MENINICIOID=[[],[]];this.Initialize()})