gx.evt.autoSkip=!1;gx.define("bitacces",!1,function(){this.ServerClass="bitacces";this.PackageName="GeneXus.Programs";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Bitaccesfec=function(){return this.validCliEvt("Valid_Bitaccesfec",0,function(){try{var n=gx.util.balloon.getNew("BITACCESFEC");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A61bitAccesFec)==0||new gx.date.gxdate(this.A61bitAccesFec).compare(gx.date.ymdhmstot(1e3,1,1,0,0,0))>=0))try{n.setError("Campo Fecha fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Bitaccesip=function(){return this.validSrvEvt("Valid_Bitaccesip",0).then(function(n){return n}.closure(this))};this.Valid_Usuariosid=function(){return this.validSrvEvt("Valid_Usuariosid",0).then(function(n){return n}.closure(this))};this.e110811_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e120811_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53];this.GXLastCtrlId=53;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e130811_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e140811_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e150811_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e160811_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e170811_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"dtime",len:8,dec:8,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Bitaccesfec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"BITACCESFEC",gxz:"Z61bitAccesFec",gxold:"O61bitAccesFec",gxvar:"A61bitAccesFec",dp:{f:0,st:!0,wn:!1,mf:!1,pic:"99/99/99 99:99:99",dec:8},ucs:[],op:[34],ip:[34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A61bitAccesFec=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z61bitAccesFec=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("BITACCESFEC",gx.O.A61bitAccesFec,0)},c2v:function(){this.val()!==undefined&&(gx.O.A61bitAccesFec=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getDateTimeValue("BITACCESFEC")},nac:gx.falseFn};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"svchar",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Bitaccesip,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"BITACCESIP",gxz:"Z75bitAccesIp",gxold:"O75bitAccesIp",gxvar:"A75bitAccesIp",ucs:[],op:[44],ip:[44,39,34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A75bitAccesIp=n)},v2z:function(n){n!==undefined&&(gx.O.Z75bitAccesIp=n)},v2c:function(){gx.fn.setControlValue("BITACCESIP",gx.O.A75bitAccesIp,0)},c2v:function(){this.val()!==undefined&&(gx.O.A75bitAccesIp=this.val())},val:function(){return gx.fn.getControlValue("BITACCESIP")},nac:gx.falseFn};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Usuariosid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSID",gxz:"Z11UsuariosId",gxold:"O11UsuariosId",gxvar:"A11UsuariosId",ucs:[],op:[],ip:[44],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A11UsuariosId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z11UsuariosId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("USUARIOSID",gx.O.A11UsuariosId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A11UsuariosId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("USUARIOSID",".")},nac:gx.falseFn};this.declareDomainHdlr(44,function(){});n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"BTN_ENTER",grid:0,evt:"e110811_client",std:"ENTER"};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"BTN_CANCEL",grid:0,evt:"e120811_client"};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"BTN_DELETE",grid:0,evt:"e180811_client",std:"DELETE"};this.A61bitAccesFec=gx.date.nullDate();this.Z61bitAccesFec=gx.date.nullDate();this.O61bitAccesFec=gx.date.nullDate();this.A75bitAccesIp="";this.Z75bitAccesIp="";this.O75bitAccesIp="";this.A11UsuariosId=0;this.Z11UsuariosId=0;this.O11UsuariosId=0;this.A61bitAccesFec=gx.date.nullDate();this.A75bitAccesIp="";this.A11UsuariosId=0;this.Events={e110811_client:["ENTER",!0],e120811_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_BITACCESFEC=[[{av:"A61bitAccesFec",fld:"BITACCESFEC",pic:"99/99/99 99:99:99"}],[{av:"A61bitAccesFec",fld:"BITACCESFEC",pic:"99/99/99 99:99:99"}]];this.EvtParms.VALID_BITACCESIP=[[{av:"A61bitAccesFec",fld:"BITACCESFEC",pic:"99/99/99 99:99:99"},{av:"A75bitAccesIp",fld:"BITACCESIP",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A11UsuariosId",fld:"USUARIOSID",pic:"ZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z61bitAccesFec"},{av:"Z75bitAccesIp"},{av:"Z11UsuariosId"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"}]];this.EvtParms.VALID_USUARIOSID=[[{av:"A11UsuariosId",fld:"USUARIOSID",pic:"ZZZZZ9"}],[]];this.EnterCtrl=["BTN_ENTER"];this.Initialize()});gx.wi(function(){gx.createParentObj(bitacces)})