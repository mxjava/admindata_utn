gx.evt.autoSkip=!1;gx.define("parametrosgeneral",!0,function(n){this.ServerClass="parametrosgeneral";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Parametroid=function(){return this.validCliEvt("Valid_Parametroid",0,function(){try{var n=gx.util.balloon.getNew("PARAMETROID");this.AnyError=0;this.refreshOutputs([{av:"A134ParametroWebService",fld:"PARAMETROWEBSERVICE",pic:"9"}])}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e11191_client=function(){return this.clearMessages(),this.call("parametros.aspx",["UPD",this.A29ParametroId]),this.refreshOutputs([{av:"A134ParametroWebService",fld:"PARAMETROWEBSERVICE",pic:"9"}]),gx.$.Deferred().resolve()};this.e12191_client=function(){return this.clearMessages(),this.call("parametros.aspx",["DLT",this.A29ParametroId]),this.refreshOutputs([{av:"A134ParametroWebService",fld:"PARAMETROWEBSERVICE",pic:"9"}]),gx.$.Deferred().resolve()};this.e15192_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e16192_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98];this.GXLastCtrlId=98;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"BTNUPDATE",grid:0,evt:"e11191_client"};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"BTNDELETE",grid:0,evt:"e12191_client"};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"ATTRIBUTESTABLE",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,lvl:0,type:"int",len:9,dec:0,sign:!1,pic:"ZZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Parametroid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROID",gxz:"Z29ParametroId",gxold:"O29ParametroId",gxvar:"A29ParametroId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A29ParametroId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z29ParametroId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PARAMETROID",gx.O.A29ParametroId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A29ParametroId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PARAMETROID",".")},nac:gx.falseFn};this.declareDomainHdlr(18,function(){});t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,lvl:0,type:"char",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROHORAINI",gxz:"Z133ParametroHoraIni",gxold:"O133ParametroHoraIni",gxvar:"A133ParametroHoraIni",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A133ParametroHoraIni=n)},v2z:function(n){n!==undefined&&(gx.O.Z133ParametroHoraIni=n)},v2c:function(){gx.fn.setControlValue("PARAMETROHORAINI",gx.O.A133ParametroHoraIni,0)},c2v:function(){this.val()!==undefined&&(gx.O.A133ParametroHoraIni=this.val())},val:function(){return gx.fn.getControlValue("PARAMETROHORAINI")},nac:gx.falseFn};t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,lvl:0,type:"char",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROHORAFIN",gxz:"Z132ParametroHoraFin",gxold:"O132ParametroHoraFin",gxvar:"A132ParametroHoraFin",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A132ParametroHoraFin=n)},v2z:function(n){n!==undefined&&(gx.O.Z132ParametroHoraFin=n)},v2c:function(){gx.fn.setControlValue("PARAMETROHORAFIN",gx.O.A132ParametroHoraFin,0)},c2v:function(){this.val()!==undefined&&(gx.O.A132ParametroHoraFin=this.val())},val:function(){return gx.fn.getControlValue("PARAMETROHORAFIN")},nac:gx.falseFn};t[29]={id:29,fld:"",grid:0};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,lvl:0,type:"svchar",len:1e3,dec:0,sign:!1,ro:1,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROVALOR",gxz:"Z129ParametroValor",gxold:"O129ParametroValor",gxvar:"A129ParametroValor",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A129ParametroValor=n)},v2z:function(n){n!==undefined&&(gx.O.Z129ParametroValor=n)},v2c:function(){gx.fn.setControlValue("PARAMETROVALOR",gx.O.A129ParametroValor,0)},c2v:function(){this.val()!==undefined&&(gx.O.A129ParametroValor=this.val())},val:function(){return gx.fn.getControlValue("PARAMETROVALOR")},nac:gx.falseFn};t[34]={id:34,fld:"",grid:0};t[35]={id:35,fld:"",grid:0};t[36]={id:36,fld:"",grid:0};t[37]={id:37,fld:"",grid:0};t[38]={id:38,lvl:0,type:"svchar",len:35,dec:0,sign:!1,pic:"@!",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETRODESC",gxz:"Z130ParametroDesc",gxold:"O130ParametroDesc",gxvar:"A130ParametroDesc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A130ParametroDesc=n)},v2z:function(n){n!==undefined&&(gx.O.Z130ParametroDesc=n)},v2c:function(){gx.fn.setControlValue("PARAMETRODESC",gx.O.A130ParametroDesc,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A130ParametroDesc=this.val())},val:function(){return gx.fn.getControlValue("PARAMETRODESC")},nac:gx.falseFn};this.declareDomainHdlr(38,function(){});t[39]={id:39,fld:"",grid:0};t[40]={id:40,fld:"",grid:0};t[41]={id:41,fld:"",grid:0};t[42]={id:42,fld:"",grid:0};t[43]={id:43,lvl:0,type:"svchar",len:2048,dec:0,sign:!1,ro:1,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETRODESCLARG",gxz:"Z131ParametroDescLarg",gxold:"O131ParametroDescLarg",gxvar:"A131ParametroDescLarg",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A131ParametroDescLarg=n)},v2z:function(n){n!==undefined&&(gx.O.Z131ParametroDescLarg=n)},v2c:function(){gx.fn.setControlValue("PARAMETRODESCLARG",gx.O.A131ParametroDescLarg,0)},c2v:function(){this.val()!==undefined&&(gx.O.A131ParametroDescLarg=this.val())},val:function(){return gx.fn.getControlValue("PARAMETRODESCLARG")},nac:gx.falseFn};t[44]={id:44,fld:"",grid:0};t[45]={id:45,fld:"",grid:0};t[46]={id:46,fld:"",grid:0};t[47]={id:47,fld:"",grid:0};t[48]={id:48,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROWEBSERVICE",gxz:"Z134ParametroWebService",gxold:"O134ParametroWebService",gxvar:"A134ParametroWebService",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.A134ParametroWebService=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z134ParametroWebService=gx.num.intval(n))},v2c:function(){gx.fn.setCheckBoxValue("PARAMETROWEBSERVICE",gx.O.A134ParametroWebService,"1")},c2v:function(){this.val()!==undefined&&(gx.O.A134ParametroWebService=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PARAMETROWEBSERVICE",".")},nac:gx.falseFn,values:[1,0]};t[49]={id:49,fld:"",grid:0};t[50]={id:50,fld:"",grid:0};t[51]={id:51,fld:"",grid:0};t[52]={id:52,fld:"",grid:0};t[53]={id:53,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROSBLOQUEO",gxz:"Z71ParametrosBloqueo",gxold:"O71ParametrosBloqueo",gxvar:"A71ParametrosBloqueo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A71ParametrosBloqueo=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z71ParametrosBloqueo=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PARAMETROSBLOQUEO",gx.O.A71ParametrosBloqueo,0)},c2v:function(){this.val()!==undefined&&(gx.O.A71ParametrosBloqueo=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PARAMETROSBLOQUEO",".")},nac:gx.falseFn};t[54]={id:54,fld:"",grid:0};t[55]={id:55,fld:"",grid:0};t[56]={id:56,fld:"",grid:0};t[57]={id:57,fld:"",grid:0};t[58]={id:58,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROSUSERNAME",gxz:"Z135Parametrosusername",gxold:"O135Parametrosusername",gxvar:"A135Parametrosusername",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A135Parametrosusername=n)},v2z:function(n){n!==undefined&&(gx.O.Z135Parametrosusername=n)},v2c:function(){gx.fn.setControlValue("PARAMETROSUSERNAME",gx.O.A135Parametrosusername,0)},c2v:function(){this.val()!==undefined&&(gx.O.A135Parametrosusername=this.val())},val:function(){return gx.fn.getControlValue("PARAMETROSUSERNAME")},nac:gx.falseFn};t[59]={id:59,fld:"",grid:0};t[60]={id:60,fld:"",grid:0};t[61]={id:61,fld:"",grid:0};t[62]={id:62,fld:"",grid:0};t[63]={id:63,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROSPASSWORD",gxz:"Z136Parametrospassword",gxold:"O136Parametrospassword",gxvar:"A136Parametrospassword",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A136Parametrospassword=n)},v2z:function(n){n!==undefined&&(gx.O.Z136Parametrospassword=n)},v2c:function(){gx.fn.setControlValue("PARAMETROSPASSWORD",gx.O.A136Parametrospassword,0)},c2v:function(){this.val()!==undefined&&(gx.O.A136Parametrospassword=this.val())},val:function(){return gx.fn.getControlValue("PARAMETROSPASSWORD")},nac:gx.falseFn};t[64]={id:64,fld:"",grid:0};t[65]={id:65,fld:"",grid:0};t[66]={id:66,fld:"",grid:0};t[67]={id:67,fld:"",grid:0};t[68]={id:68,lvl:0,type:"svchar",len:200,dec:0,sign:!1,ro:1,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROSADDHEADER",gxz:"Z137ParametrosAddHeader",gxold:"O137ParametrosAddHeader",gxvar:"A137ParametrosAddHeader",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A137ParametrosAddHeader=n)},v2z:function(n){n!==undefined&&(gx.O.Z137ParametrosAddHeader=n)},v2c:function(){gx.fn.setControlValue("PARAMETROSADDHEADER",gx.O.A137ParametrosAddHeader,0)},c2v:function(){this.val()!==undefined&&(gx.O.A137ParametrosAddHeader=this.val())},val:function(){return gx.fn.getControlValue("PARAMETROSADDHEADER")},nac:gx.falseFn};t[69]={id:69,fld:"",grid:0};t[70]={id:70,fld:"",grid:0};t[71]={id:71,fld:"",grid:0};t[72]={id:72,fld:"",grid:0};t[73]={id:73,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROSHOST",gxz:"Z138ParametrosHost",gxold:"O138ParametrosHost",gxvar:"A138ParametrosHost",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A138ParametrosHost=n)},v2z:function(n){n!==undefined&&(gx.O.Z138ParametrosHost=n)},v2c:function(){gx.fn.setControlValue("PARAMETROSHOST",gx.O.A138ParametrosHost,0)},c2v:function(){this.val()!==undefined&&(gx.O.A138ParametrosHost=this.val())},val:function(){return gx.fn.getControlValue("PARAMETROSHOST")},nac:gx.falseFn};t[74]={id:74,fld:"",grid:0};t[75]={id:75,fld:"",grid:0};t[76]={id:76,fld:"",grid:0};t[77]={id:77,fld:"",grid:0};t[78]={id:78,lvl:0,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROSPORT",gxz:"Z139ParametrosPort",gxold:"O139ParametrosPort",gxvar:"A139ParametrosPort",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A139ParametrosPort=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z139ParametrosPort=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PARAMETROSPORT",gx.O.A139ParametrosPort,0)},c2v:function(){this.val()!==undefined&&(gx.O.A139ParametrosPort=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PARAMETROSPORT",".")},nac:gx.falseFn};t[79]={id:79,fld:"",grid:0};t[80]={id:80,fld:"",grid:0};t[81]={id:81,fld:"",grid:0};t[82]={id:82,fld:"",grid:0};t[83]={id:83,lvl:0,type:"svchar",len:20,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROSBASEURL",gxz:"Z140ParametrosBaseUrl",gxold:"O140ParametrosBaseUrl",gxvar:"A140ParametrosBaseUrl",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A140ParametrosBaseUrl=n)},v2z:function(n){n!==undefined&&(gx.O.Z140ParametrosBaseUrl=n)},v2c:function(){gx.fn.setControlValue("PARAMETROSBASEURL",gx.O.A140ParametrosBaseUrl,0)},c2v:function(){this.val()!==undefined&&(gx.O.A140ParametrosBaseUrl=this.val())},val:function(){return gx.fn.getControlValue("PARAMETROSBASEURL")},nac:gx.falseFn};t[84]={id:84,fld:"",grid:0};t[85]={id:85,fld:"",grid:0};t[86]={id:86,fld:"",grid:0};t[87]={id:87,fld:"",grid:0};t[88]={id:88,lvl:0,type:"char",len:6,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROSEXECUTE",gxz:"Z141ParametrosExecute",gxold:"O141ParametrosExecute",gxvar:"A141ParametrosExecute",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A141ParametrosExecute=n)},v2z:function(n){n!==undefined&&(gx.O.Z141ParametrosExecute=n)},v2c:function(){gx.fn.setControlValue("PARAMETROSEXECUTE",gx.O.A141ParametrosExecute,0)},c2v:function(){this.val()!==undefined&&(gx.O.A141ParametrosExecute=this.val())},val:function(){return gx.fn.getControlValue("PARAMETROSEXECUTE")},nac:gx.falseFn};t[89]={id:89,fld:"",grid:0};t[90]={id:90,fld:"",grid:0};t[91]={id:91,fld:"",grid:0};t[92]={id:92,fld:"",grid:0};t[93]={id:93,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROSRUTA",gxz:"Z142ParametrosRuta",gxold:"O142ParametrosRuta",gxvar:"A142ParametrosRuta",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A142ParametrosRuta=n)},v2z:function(n){n!==undefined&&(gx.O.Z142ParametrosRuta=n)},v2c:function(){gx.fn.setControlValue("PARAMETROSRUTA",gx.O.A142ParametrosRuta,0)},c2v:function(){this.val()!==undefined&&(gx.O.A142ParametrosRuta=this.val())},val:function(){return gx.fn.getControlValue("PARAMETROSRUTA")},nac:gx.falseFn};t[94]={id:94,fld:"",grid:0};t[95]={id:95,fld:"",grid:0};t[96]={id:96,fld:"",grid:0};t[97]={id:97,fld:"",grid:0};t[98]={id:98,lvl:0,type:"svchar",len:600,dec:0,sign:!1,ro:1,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROSRUTAPDF",gxz:"Z143ParametrosRutaPDF",gxold:"O143ParametrosRutaPDF",gxvar:"A143ParametrosRutaPDF",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A143ParametrosRutaPDF=n)},v2z:function(n){n!==undefined&&(gx.O.Z143ParametrosRutaPDF=n)},v2c:function(){gx.fn.setControlValue("PARAMETROSRUTAPDF",gx.O.A143ParametrosRutaPDF,0)},c2v:function(){this.val()!==undefined&&(gx.O.A143ParametrosRutaPDF=this.val())},val:function(){return gx.fn.getControlValue("PARAMETROSRUTAPDF")},nac:gx.falseFn};this.A29ParametroId=0;this.Z29ParametroId=0;this.O29ParametroId=0;this.A133ParametroHoraIni="";this.Z133ParametroHoraIni="";this.O133ParametroHoraIni="";this.A132ParametroHoraFin="";this.Z132ParametroHoraFin="";this.O132ParametroHoraFin="";this.A129ParametroValor="";this.Z129ParametroValor="";this.O129ParametroValor="";this.A130ParametroDesc="";this.Z130ParametroDesc="";this.O130ParametroDesc="";this.A131ParametroDescLarg="";this.Z131ParametroDescLarg="";this.O131ParametroDescLarg="";this.A134ParametroWebService=0;this.Z134ParametroWebService=0;this.O134ParametroWebService=0;this.A71ParametrosBloqueo=0;this.Z71ParametrosBloqueo=0;this.O71ParametrosBloqueo=0;this.A135Parametrosusername="";this.Z135Parametrosusername="";this.O135Parametrosusername="";this.A136Parametrospassword="";this.Z136Parametrospassword="";this.O136Parametrospassword="";this.A137ParametrosAddHeader="";this.Z137ParametrosAddHeader="";this.O137ParametrosAddHeader="";this.A138ParametrosHost="";this.Z138ParametrosHost="";this.O138ParametrosHost="";this.A139ParametrosPort=0;this.Z139ParametrosPort=0;this.O139ParametrosPort=0;this.A140ParametrosBaseUrl="";this.Z140ParametrosBaseUrl="";this.O140ParametrosBaseUrl="";this.A141ParametrosExecute="";this.Z141ParametrosExecute="";this.O141ParametrosExecute="";this.A142ParametrosRuta="";this.Z142ParametrosRuta="";this.O142ParametrosRuta="";this.A143ParametrosRutaPDF="";this.Z143ParametrosRutaPDF="";this.O143ParametrosRutaPDF="";this.A29ParametroId=0;this.A133ParametroHoraIni="";this.A132ParametroHoraFin="";this.A129ParametroValor="";this.A130ParametroDesc="";this.A131ParametroDescLarg="";this.A134ParametroWebService=0;this.A71ParametrosBloqueo=0;this.A135Parametrosusername="";this.A136Parametrospassword="";this.A137ParametrosAddHeader="";this.A138ParametrosHost="";this.A139ParametrosPort=0;this.A140ParametrosBaseUrl="";this.A141ParametrosExecute="";this.A142ParametrosRuta="";this.A143ParametrosRutaPDF="";this.Events={e15192_client:["ENTER",!0],e16192_client:["CANCEL",!0],e11191_client:["'DOUPDATE'",!1],e12191_client:["'DODELETE'",!1]};this.EvtParms.REFRESH=[[{av:"A29ParametroId",fld:"PARAMETROID",pic:"ZZZZZZZZ9"},{av:"A134ParametroWebService",fld:"PARAMETROWEBSERVICE",pic:"9"}],[{av:"A134ParametroWebService",fld:"PARAMETROWEBSERVICE",pic:"9"}]];this.EvtParms.START=[[{av:"AV13Pgmname",fld:"vPGMNAME",pic:""},{av:"AV6ParametroId",fld:"vPARAMETROID",pic:"ZZZZZZZZ9"},{av:"A134ParametroWebService",fld:"PARAMETROWEBSERVICE",pic:"9"}],[{av:"A134ParametroWebService",fld:"PARAMETROWEBSERVICE",pic:"9"}]];this.EvtParms.LOAD=[[{av:"A134ParametroWebService",fld:"PARAMETROWEBSERVICE",pic:"9"}],[{av:"A134ParametroWebService",fld:"PARAMETROWEBSERVICE",pic:"9"}]];this.EvtParms["'DOUPDATE'"]=[[{av:"A29ParametroId",fld:"PARAMETROID",pic:"ZZZZZZZZ9"},{av:"A134ParametroWebService",fld:"PARAMETROWEBSERVICE",pic:"9"}],[{av:"A134ParametroWebService",fld:"PARAMETROWEBSERVICE",pic:"9"}]];this.EvtParms["'DODELETE'"]=[[{av:"A29ParametroId",fld:"PARAMETROID",pic:"ZZZZZZZZ9"},{av:"A134ParametroWebService",fld:"PARAMETROWEBSERVICE",pic:"9"}],[{av:"A134ParametroWebService",fld:"PARAMETROWEBSERVICE",pic:"9"}]];this.EvtParms.VALID_PARAMETROID=[[{av:"A134ParametroWebService",fld:"PARAMETROWEBSERVICE",pic:"9"}],[{av:"A134ParametroWebService",fld:"PARAMETROWEBSERVICE",pic:"9"}]];this.Initialize()})