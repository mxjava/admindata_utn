gx.evt.autoSkip=!1;gx.define("meninicio",!1,function(){this.ServerClass="meninicio";this.PackageName="GeneXus.Programs";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV7menInicioId=gx.fn.getIntegerValue("vMENINICIOID",".");this.AV19numero=gx.fn.getIntegerValue("vNUMERO",".");this.AV20sgUsrMenId=gx.fn.getIntegerValue("vSGUSRMENID",".");this.AV21Pgmname=gx.fn.getControlValue("vPGMNAME");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV16UserLog=gx.fn.getIntegerValue("vUSERLOG",".");this.AV10TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Meninicioid=function(){return this.validCliEvt("Valid_Meninicioid",0,function(){try{var n=gx.util.balloon.getNew("MENINICIOID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Meniniciofecini=function(){return this.validCliEvt("Valid_Meniniciofecini",0,function(){try{var n=gx.util.balloon.getNew("MENINICIOFECINI");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A186menInicioFecIni)==0||new gx.date.gxdate(this.A186menInicioFecIni).compare(gx.date.ymdtod(1e3,1,1))>=0))try{n.setError("Campo Fecha de inicio de vigencia fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Meniniciofecfin=function(){return this.validCliEvt("Valid_Meniniciofecfin",0,function(){try{var n=gx.util.balloon.getNew("MENINICIOFECFIN");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A76menInicioFecFin)==0||new gx.date.gxdate(this.A76menInicioFecFin).compare(gx.date.ymdtod(1e3,1,1))>=0))try{n.setError("Campo Fecha de fin de vigencia fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Meniniciofeccap=function(){return this.validCliEvt("Valid_Meniniciofeccap",0,function(){try{var n=gx.util.balloon.getNew("MENINICIOFECCAP");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A185menInicioFecCap)==0||new gx.date.gxdate(this.A185menInicioFecCap).compare(gx.date.ymdhmstot(1e3,1,1,0,0,0))>=0))try{n.setError("Campo Fecha de captura fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e12072_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e130713_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e140713_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78];this.GXLastCtrlId=78;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e150713_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e160713_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e170713_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e180713_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e190713_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Meninicioid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENINICIOID",gxz:"Z58menInicioId",gxold:"O58menInicioId",gxvar:"A58menInicioId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A58menInicioId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z58menInicioId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("MENINICIOID",gx.O.A58menInicioId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A58menInicioId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("MENINICIOID",".")},nac:function(){return!(0==this.AV7menInicioId)}};this.declareDomainHdlr(34,function(){});n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"svchar",len:255,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENINICIODES",gxz:"Z150menInicioDes",gxold:"O150menInicioDes",gxvar:"A150menInicioDes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A150menInicioDes=n)},v2z:function(n){n!==undefined&&(gx.O.Z150menInicioDes=n)},v2c:function(){gx.fn.setControlValue("MENINICIODES",gx.O.A150menInicioDes,0)},c2v:function(){this.val()!==undefined&&(gx.O.A150menInicioDes=this.val())},val:function(){return gx.fn.getControlValue("MENINICIODES")},nac:gx.falseFn};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Meniniciofecini,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENINICIOFECINI",gxz:"Z186menInicioFecIni",gxold:"O186menInicioFecIni",gxvar:"A186menInicioFecIni",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[44],ip:[44],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A186menInicioFecIni=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z186menInicioFecIni=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("MENINICIOFECINI",gx.O.A186menInicioFecIni,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A186menInicioFecIni=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("MENINICIOFECINI")},nac:function(){return this.Gx_mode=="UPD"}};this.declareDomainHdlr(44,function(){});n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Meniniciofecfin,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENINICIOFECFIN",gxz:"Z76menInicioFecFin",gxold:"O76menInicioFecFin",gxvar:"A76menInicioFecFin",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[49],ip:[49],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A76menInicioFecFin=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z76menInicioFecFin=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("MENINICIOFECFIN",gx.O.A76menInicioFecFin,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A76menInicioFecFin=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("MENINICIOFECFIN")},nac:gx.falseFn};this.declareDomainHdlr(49,function(){});n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENINICIOSTAT",gxz:"Z77menInicioStat",gxold:"O77menInicioStat",gxvar:"A77menInicioStat",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A77menInicioStat=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z77menInicioStat=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("MENINICIOSTAT",gx.O.A77menInicioStat)},c2v:function(){this.val()!==undefined&&(gx.O.A77menInicioStat=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("MENINICIOSTAT",".")},nac:gx.falseFn};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"dtime",len:10,dec:8,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Meniniciofeccap,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENINICIOFECCAP",gxz:"Z185menInicioFecCap",gxold:"O185menInicioFecCap",gxvar:"A185menInicioFecCap",dp:{f:0,st:!0,wn:!1,mf:!1,pic:"99/99/9999 99:99:99",dec:8},ucs:[],op:[59],ip:[59],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A185menInicioFecCap=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z185menInicioFecCap=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("MENINICIOFECCAP",gx.O.A185menInicioFecCap,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A185menInicioFecCap=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getDateTimeValue("MENINICIOFECCAP")},nac:gx.falseFn};this.declareDomainHdlr(59,function(){});n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SGUSRMENID",gxz:"Z59sgUsrMenId",gxold:"O59sgUsrMenId",gxvar:"A59sgUsrMenId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A59sgUsrMenId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z59sgUsrMenId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("SGUSRMENID",gx.O.A59sgUsrMenId,0)},c2v:function(){this.val()!==undefined&&(gx.O.A59sgUsrMenId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("SGUSRMENID",".")},nac:gx.falseFn};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,lvl:0,type:"svchar",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SGUSRMENNOM",gxz:"Z187sgUsrMenNom",gxold:"O187sgUsrMenNom",gxvar:"A187sgUsrMenNom",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A187sgUsrMenNom=n)},v2z:function(n){n!==undefined&&(gx.O.Z187sgUsrMenNom=n)},v2c:function(){gx.fn.setControlValue("SGUSRMENNOM",gx.O.A187sgUsrMenNom,0)},c2v:function(){this.val()!==undefined&&(gx.O.A187sgUsrMenNom=this.val())},val:function(){return gx.fn.getControlValue("SGUSRMENNOM")},nac:gx.falseFn};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"",grid:0};n[74]={id:74,fld:"BTN_ENTER",grid:0,evt:"e130713_client",std:"ENTER"};n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"BTN_CANCEL",grid:0,evt:"e140713_client"};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"BTN_DELETE",grid:0,evt:"e200713_client",std:"DELETE"};this.A58menInicioId=0;this.Z58menInicioId=0;this.O58menInicioId=0;this.A150menInicioDes="";this.Z150menInicioDes="";this.O150menInicioDes="";this.A186menInicioFecIni=gx.date.nullDate();this.Z186menInicioFecIni=gx.date.nullDate();this.O186menInicioFecIni=gx.date.nullDate();this.A76menInicioFecFin=gx.date.nullDate();this.Z76menInicioFecFin=gx.date.nullDate();this.O76menInicioFecFin=gx.date.nullDate();this.A77menInicioStat=0;this.Z77menInicioStat=0;this.O77menInicioStat=0;this.A185menInicioFecCap=gx.date.nullDate();this.Z185menInicioFecCap=gx.date.nullDate();this.O185menInicioFecCap=gx.date.nullDate();this.A59sgUsrMenId=0;this.Z59sgUsrMenId=0;this.O59sgUsrMenId=0;this.A187sgUsrMenNom="";this.Z187sgUsrMenNom="";this.O187sgUsrMenNom="";this.AV14usuario="";this.AV16UserLog=0;this.AV19numero=0;this.AV21Pgmname="";this.AV10TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV8Context={User:"",CompanyCode:0,Profile:""};this.AV7menInicioId=0;this.AV20sgUsrMenId=0;this.AV15sesion={};this.AV11WebSession={};this.A58menInicioId=0;this.A59sgUsrMenId=0;this.A185menInicioFecCap=gx.date.nullDate();this.A150menInicioDes="";this.A186menInicioFecIni=gx.date.nullDate();this.A76menInicioFecFin=gx.date.nullDate();this.A77menInicioStat=0;this.A187sgUsrMenNom="";this.Gx_mode="";this.Events={e12072_client:["AFTER TRN",!0],e130713_client:["ENTER",!0],e140713_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7menInicioId",fld:"vMENINICIOID",pic:"ZZZZZ9",hsh:!0},{av:"AV20sgUsrMenId",fld:"vSGUSRMENID",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV16UserLog",fld:"vUSERLOG",pic:"ZZZZZ9",hsh:!0},{av:"AV10TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7menInicioId",fld:"vMENINICIOID",pic:"ZZZZZ9",hsh:!0},{av:"AV19numero",fld:"vNUMERO",pic:"ZZZZZ9",hsh:!0},{av:"AV20sgUsrMenId",fld:"vSGUSRMENID",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms.START=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV21Pgmname",fld:"vPGMNAME",pic:""}],[{av:"AV14usuario",fld:"vUSUARIO",pic:""},{av:"AV16UserLog",fld:"vUSERLOG",pic:"ZZZZZ9",hsh:!0},{av:'gx.fn.getCtrlProperty("MENINICIOFECCAP","Visible")',ctrl:"MENINICIOFECCAP",prop:"Visible"},{av:"AV19numero",fld:"vNUMERO",pic:"ZZZZZ9",hsh:!0},{av:"AV10TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV19numero",fld:"vNUMERO",pic:"ZZZZZ9",hsh:!0},{av:"AV16UserLog",fld:"vUSERLOG",pic:"ZZZZZ9",hsh:!0},{av:"AV10TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[]];this.EvtParms.VALID_MENINICIOID=[[],[]];this.EvtParms.VALID_MENINICIOFECINI=[[{av:"A186menInicioFecIni",fld:"MENINICIOFECINI",pic:""}],[{av:"A186menInicioFecIni",fld:"MENINICIOFECINI",pic:""}]];this.EvtParms.VALID_MENINICIOFECFIN=[[{av:"A76menInicioFecFin",fld:"MENINICIOFECFIN",pic:""}],[{av:"A76menInicioFecFin",fld:"MENINICIOFECFIN",pic:""}]];this.EvtParms.VALID_MENINICIOFECCAP=[[{av:"A185menInicioFecCap",fld:"MENINICIOFECCAP",pic:"99/99/9999 99:99:99"}],[{av:"A185menInicioFecCap",fld:"MENINICIOFECCAP",pic:"99/99/9999 99:99:99"}]];this.EnterCtrl=["BTN_ENTER"];this.setVCMap("AV7menInicioId","vMENINICIOID",0,"int",6,0);this.setVCMap("AV19numero","vNUMERO",0,"int",6,0);this.setVCMap("AV20sgUsrMenId","vSGUSRMENID",0,"int",6,0);this.setVCMap("AV21Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV16UserLog","vUSERLOG",0,"int",6,0);this.setVCMap("AV10TrnContext","vTRNCONTEXT",0,"TransactionContext",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(meninicio)})