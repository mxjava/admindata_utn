gx.evt.autoSkip=!1;gx.define("usuarios",!1,function(){this.ServerClass="usuarios";this.PackageName="GeneXus.Programs";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV40UsuariosId=gx.fn.getIntegerValue("vUSUARIOSID",".");this.AV54Insert_RolId=gx.fn.getIntegerValue("vINSERT_ROLID",".");this.AV56UsuariosCurpAnt=gx.fn.getControlValue("vUSUARIOSCURPANT");this.Gx_date=gx.fn.getDateValue("vTODAY");this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",".");this.AV53error1=gx.fn.getIntegerValue("vERROR1",".");this.A40000UsuariosIcono_GXI=gx.fn.getControlValue("USUARIOSICONO_GXI");this.AV60Pgmname=gx.fn.getControlValue("vPGMNAME");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV34UsrLog=gx.fn.getIntegerValue("vUSRLOG",".");this.AV7adscId=gx.fn.getIntegerValue("vADSCID",".");this.AV10comision=gx.fn.getIntegerValue("vCOMISION",".");this.AV32TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Usuariosid=function(){return this.validSrvEvt("Valid_Usuariosid",0).then(function(n){return n}.closure(this))};this.Valid_Usuarioscurp=function(){return this.validSrvEvt("Valid_Usuarioscurp",0).then(function(n){return n}.closure(this))};this.Valid_Usuariosnombre=function(){return this.validCliEvt("Valid_Usuariosnombre",0,function(){try{var n=gx.util.balloon.getNew("USUARIOSNOMBRE");if(this.AnyError=0,""==this.A66UsuariosNombre)try{n.setError("El nombre no puede ir vacio, Favor de verificar!");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Usuariosappat=function(){return this.validCliEvt("Valid_Usuariosappat",0,function(){try{var n=gx.util.balloon.getNew("USUARIOSAPPAT");if(this.AnyError=0,""==this.A65UsuariosApPat)try{n.setError("El primer apellido no puede ir vacio,  Favor de verificar!");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Usuariosapmat=function(){return this.validCliEvt("Valid_Usuariosapmat",0,function(){try{var n=gx.util.balloon.getNew("USUARIOSAPMAT");this.AnyError=0;try{this.A97UsuariosNomCompleto=gx.text.trim(this.A66UsuariosNombre)+" "+gx.text.trim(this.A65UsuariosApPat)+" "+gx.text.trim(this.A64UsuariosApMat)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Usuariostipo=function(){return this.validCliEvt("Valid_Usuariostipo",0,function(){try{var n=gx.util.balloon.getNew("USUARIOSTIPO");if(this.AnyError=0,0==this.A272UsuariosTipo)try{n.setError("El tipo de usuario no puede ir vacio,  Favor de verificar!");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Usuariosfecnacimiento=function(){return this.validCliEvt("Valid_Usuariosfecnacimiento",0,function(){try{var n=gx.util.balloon.getNew("USUARIOSFECNACIMIENTO");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A255UsuariosFecNacimiento)==0||new gx.date.gxdate(this.A255UsuariosFecNacimiento).compare(gx.date.ymdtod(1e3,1,1))>=0))try{n.setError("Campo Fecha Nacimiento fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Usuariossexo=function(){return this.validCliEvt("Valid_Usuariossexo",0,function(){try{var n=gx.util.balloon.getNew("USUARIOSSEXO");this.AnyError=0;try{this.A275UsuariosSexoFor=this.A257UsuariosSexo=="H"?"Hombres":this.A257UsuariosSexo=="M"?"Mujeres":""}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Usuariosvigini=function(){return this.validCliEvt("Valid_Usuariosvigini",0,function(){try{var n=gx.util.balloon.getNew("USUARIOSVIGINI");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A96UsuariosVigIni)==0||new gx.date.gxdate(this.A96UsuariosVigIni).compare(gx.date.ymdtod(1e3,1,1))>=0))try{n.setError("Campo Fecha de inicio de acceso fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Usuariosvigfin=function(){return this.validCliEvt("Valid_Usuariosvigfin",0,function(){try{var n=gx.util.balloon.getNew("USUARIOSVIGFIN");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A70UsuariosVigFin)===0||new gx.date.gxdate(this.A70UsuariosVigFin).compare(gx.date.ymdtod(1e3,1,1))>=0))try{n.setError("Campo Fecha de cierre del permiso del usuario fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Usuariosfeccap=function(){return this.validCliEvt("Valid_Usuariosfeccap",0,function(){try{var n=gx.util.balloon.getNew("USUARIOSFECCAP");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A92UsuariosFecCap)==0||new gx.date.gxdate(this.A92UsuariosFecCap).compare(gx.date.ymdhmstot(1e3,1,1,0,0,0))>=0))try{n.setError("Campo Fecha de Captura fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Usuariostelef=function(){return this.validCliEvt("Valid_Usuariostelef",0,function(){try{var n=gx.util.balloon.getNew("USUARIOSTELEF");if(this.AnyError=0,gx.util.regExp.isMatch(this.A260UsuariosTelef,"\\b[0-9]{10}\\b")==!1)try{n.setError("Telefono incorrecto, Favor de verificar!");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Usuarioscorreo=function(){return this.validCliEvt("Valid_Usuarioscorreo",0,function(){try{var n=gx.util.balloon.getNew("USUARIOSCORREO");if(this.AnyError=0,!gx.util.regExp.isMatch(this.A261UsuariosCorreo,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$"))try{n.setError("El valor de Correo electrónico no coincide con el patrón especificado");this.AnyError=gx.num.trunc(1,0)}catch(t){}if(""==this.A261UsuariosCorreo)try{n.setError("El correo no puede ir vacio,  Favor de verificar!");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Rolid=function(){return this.validSrvEvt("Valid_Rolid",0).then(function(n){return n}.closure(this))};this.Valid_Usuariosstatus=function(){return this.validCliEvt("Valid_Usuariosstatus",0,function(){try{var n=gx.util.balloon.getNew("USUARIOSSTATUS");if(this.AnyError=0,!(this.A286UsuariosStatus==1||this.A286UsuariosStatus==0))try{n.setError("Campo Usuarios Status fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e13029_client=function(){return this.clearMessages(),this.call("acceso.aspx",[]),this.refreshOutputs([]),gx.$.Deferred().resolve()};this.e12022_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e14029_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e15029_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,117,118,119,120,121,122,123,124,125,126,127,128,129,130,131,132,133,134,135,136,137,138,139,140,141,142,143,144,145,146,147,148,149,150,151,152,153,154,155,156,157,158];this.GXLastCtrlId=158;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e16029_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e17029_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e18029_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e19029_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e20029_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Usuariosid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSID",gxz:"Z11UsuariosId",gxold:"O11UsuariosId",gxvar:"A11UsuariosId",ucs:[],op:[],ip:[34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A11UsuariosId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z11UsuariosId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("USUARIOSID",gx.O.A11UsuariosId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A11UsuariosId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("USUARIOSID",".")},nac:function(){return!(0==this.AV40UsuariosId)}};this.declareDomainHdlr(34,function(){});n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"svchar",len:18,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Usuarioscurp,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSCURP",gxz:"Z105UsuariosCurp",gxold:"O105UsuariosCurp",gxvar:"A105UsuariosCurp",ucs:[],op:[84,79,74,59],ip:[84,79,74,59,39],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A105UsuariosCurp=n)},v2z:function(n){n!==undefined&&(gx.O.Z105UsuariosCurp=n)},v2c:function(){gx.fn.setControlValue("USUARIOSCURP",gx.O.A105UsuariosCurp,0)},c2v:function(){this.val()!==undefined&&(gx.O.A105UsuariosCurp=this.val())},val:function(){return gx.fn.getControlValue("USUARIOSCURP")},nac:gx.falseFn};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"svchar",len:40,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Usuariosnombre,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSNOMBRE",gxz:"Z66UsuariosNombre",gxold:"O66UsuariosNombre",gxvar:"A66UsuariosNombre",ucs:[],op:[44],ip:[44],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A66UsuariosNombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z66UsuariosNombre=n)},v2c:function(){gx.fn.setControlValue("USUARIOSNOMBRE",gx.O.A66UsuariosNombre,0)},c2v:function(){this.val()!==undefined&&(gx.O.A66UsuariosNombre=this.val())},val:function(){return gx.fn.getControlValue("USUARIOSNOMBRE")},nac:gx.falseFn};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"svchar",len:40,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Usuariosappat,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSAPPAT",gxz:"Z65UsuariosApPat",gxold:"O65UsuariosApPat",gxvar:"A65UsuariosApPat",ucs:[],op:[49],ip:[49],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A65UsuariosApPat=n)},v2z:function(n){n!==undefined&&(gx.O.Z65UsuariosApPat=n)},v2c:function(){gx.fn.setControlValue("USUARIOSAPPAT",gx.O.A65UsuariosApPat,0)},c2v:function(){this.val()!==undefined&&(gx.O.A65UsuariosApPat=this.val())},val:function(){return gx.fn.getControlValue("USUARIOSAPPAT")},nac:gx.falseFn};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"svchar",len:40,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Usuariosapmat,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSAPMAT",gxz:"Z64UsuariosApMat",gxold:"O64UsuariosApMat",gxvar:"A64UsuariosApMat",ucs:[],op:[129],ip:[129,54,49,44],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A64UsuariosApMat=n)},v2z:function(n){n!==undefined&&(gx.O.Z64UsuariosApMat=n)},v2c:function(){gx.fn.setControlValue("USUARIOSAPMAT",gx.O.A64UsuariosApMat,0)},c2v:function(){this.val()!==undefined&&(gx.O.A64UsuariosApMat=this.val())},val:function(){return gx.fn.getControlValue("USUARIOSAPMAT")},nac:gx.falseFn};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"svchar",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSUSR",gxz:"Z244UsuariosUsr",gxold:"O244UsuariosUsr",gxvar:"A244UsuariosUsr",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A244UsuariosUsr=n)},v2z:function(n){n!==undefined&&(gx.O.Z244UsuariosUsr=n)},v2c:function(){gx.fn.setControlValue("USUARIOSUSR",gx.O.A244UsuariosUsr,0)},c2v:function(){this.val()!==undefined&&(gx.O.A244UsuariosUsr=this.val())},val:function(){return gx.fn.getControlValue("USUARIOSUSR")},nac:gx.falseFn};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Usuariostipo,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSTIPO",gxz:"Z272UsuariosTipo",gxold:"O272UsuariosTipo",gxvar:"A272UsuariosTipo",ucs:[],op:[64],ip:[64],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A272UsuariosTipo=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z272UsuariosTipo=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("USUARIOSTIPO",gx.O.A272UsuariosTipo);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A272UsuariosTipo=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("USUARIOSTIPO",".")},nac:gx.falseFn};this.declareDomainHdlr(64,function(){});n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,lvl:0,type:"bits",len:1024,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSICONO",gxz:"Z245UsuariosIcono",gxold:"O245UsuariosIcono",gxvar:"A245UsuariosIcono",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A245UsuariosIcono=n)},v2z:function(n){n!==undefined&&(gx.O.Z245UsuariosIcono=n)},v2c:function(){gx.fn.setMultimediaValue("USUARIOSICONO",gx.O.A245UsuariosIcono,gx.O.A40000UsuariosIcono_GXI)},c2v:function(){gx.O.A40000UsuariosIcono_GXI=this.val_GXI();this.val()!==undefined&&(gx.O.A245UsuariosIcono=this.val())},val:function(){return gx.fn.getBlobValue("USUARIOSICONO")},val_GXI:function(){return gx.fn.getControlValue("USUARIOSICONO_GXI")},gxvar_GXI:"A40000UsuariosIcono_GXI",nac:gx.falseFn};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"",grid:0};n[74]={id:74,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Usuariosfecnacimiento,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSFECNACIMIENTO",gxz:"Z255UsuariosFecNacimiento",gxold:"O255UsuariosFecNacimiento",gxvar:"A255UsuariosFecNacimiento",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[74],ip:[74],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A255UsuariosFecNacimiento=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z255UsuariosFecNacimiento=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("USUARIOSFECNACIMIENTO",gx.O.A255UsuariosFecNacimiento,0)},c2v:function(){this.val()!==undefined&&(gx.O.A255UsuariosFecNacimiento=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("USUARIOSFECNACIMIENTO")},nac:gx.falseFn};n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSEDAD",gxz:"Z256UsuariosEdad",gxold:"O256UsuariosEdad",gxvar:"A256UsuariosEdad",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A256UsuariosEdad=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z256UsuariosEdad=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("USUARIOSEDAD",gx.O.A256UsuariosEdad,0)},c2v:function(){this.val()!==undefined&&(gx.O.A256UsuariosEdad=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("USUARIOSEDAD",".")},nac:gx.falseFn};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[84]={id:84,lvl:0,type:"char",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Usuariossexo,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSSEXO",gxz:"Z257UsuariosSexo",gxold:"O257UsuariosSexo",gxvar:"A257UsuariosSexo",ucs:[],op:[144],ip:[144,84],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A257UsuariosSexo=n)},v2z:function(n){n!==undefined&&(gx.O.Z257UsuariosSexo=n)},v2c:function(){gx.fn.setControlValue("USUARIOSSEXO",gx.O.A257UsuariosSexo,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A257UsuariosSexo=this.val())},val:function(){return gx.fn.getControlValue("USUARIOSSEXO")},nac:gx.falseFn};this.declareDomainHdlr(84,function(){});n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"",grid:0};n[88]={id:88,fld:"",grid:0};n[89]={id:89,lvl:0,type:"svchar",len:32,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSPWD",gxz:"Z68UsuariosPwd",gxold:"O68UsuariosPwd",gxvar:"A68UsuariosPwd",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A68UsuariosPwd=n)},v2z:function(n){n!==undefined&&(gx.O.Z68UsuariosPwd=n)},v2c:function(){gx.fn.setControlValue("USUARIOSPWD",gx.O.A68UsuariosPwd,0)},c2v:function(){this.val()!==undefined&&(gx.O.A68UsuariosPwd=this.val())},val:function(){return gx.fn.getControlValue("USUARIOSPWD")},nac:gx.falseFn};n[90]={id:90,fld:"",grid:0};n[91]={id:91,fld:"",grid:0};n[92]={id:92,fld:"",grid:0};n[93]={id:93,fld:"",grid:0};n[94]={id:94,lvl:0,type:"svchar",len:32,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSKEY",gxz:"Z67UsuariosKey",gxold:"O67UsuariosKey",gxvar:"A67UsuariosKey",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A67UsuariosKey=n)},v2z:function(n){n!==undefined&&(gx.O.Z67UsuariosKey=n)},v2c:function(){gx.fn.setControlValue("USUARIOSKEY",gx.O.A67UsuariosKey,0)},c2v:function(){this.val()!==undefined&&(gx.O.A67UsuariosKey=this.val())},val:function(){return gx.fn.getControlValue("USUARIOSKEY")},nac:gx.falseFn};n[95]={id:95,fld:"",grid:0};n[96]={id:96,fld:"",grid:0};n[97]={id:97,fld:"",grid:0};n[98]={id:98,fld:"",grid:0};n[99]={id:99,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Usuariosvigini,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSVIGINI",gxz:"Z96UsuariosVigIni",gxold:"O96UsuariosVigIni",gxvar:"A96UsuariosVigIni",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[99],ip:[99],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A96UsuariosVigIni=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z96UsuariosVigIni=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("USUARIOSVIGINI",gx.O.A96UsuariosVigIni,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A96UsuariosVigIni=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("USUARIOSVIGINI")},nac:gx.falseFn};this.declareDomainHdlr(99,function(){});n[100]={id:100,fld:"",grid:0};n[101]={id:101,fld:"",grid:0};n[102]={id:102,fld:"",grid:0};n[103]={id:103,fld:"",grid:0};n[104]={id:104,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Usuariosvigfin,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSVIGFIN",gxz:"Z70UsuariosVigFin",gxold:"O70UsuariosVigFin",gxvar:"A70UsuariosVigFin",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[104],ip:[104],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A70UsuariosVigFin=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z70UsuariosVigFin=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("USUARIOSVIGFIN",gx.O.A70UsuariosVigFin,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A70UsuariosVigFin=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("USUARIOSVIGFIN")},nac:gx.falseFn};this.declareDomainHdlr(104,function(){});n[105]={id:105,fld:"",grid:0};n[106]={id:106,fld:"",grid:0};n[107]={id:107,fld:"",grid:0};n[108]={id:108,fld:"",grid:0};n[109]={id:109,lvl:0,type:"dtime",len:10,dec:8,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Usuariosfeccap,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSFECCAP",gxz:"Z92UsuariosFecCap",gxold:"O92UsuariosFecCap",gxvar:"A92UsuariosFecCap",dp:{f:0,st:!0,wn:!1,mf:!1,pic:"99/99/9999 99:99:99",dec:8},ucs:[],op:[109],ip:[109],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A92UsuariosFecCap=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z92UsuariosFecCap=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("USUARIOSFECCAP",gx.O.A92UsuariosFecCap,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A92UsuariosFecCap=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getDateTimeValue("USUARIOSFECCAP")},nac:gx.falseFn};this.declareDomainHdlr(109,function(){});n[110]={id:110,fld:"",grid:0};n[111]={id:111,fld:"",grid:0};n[112]={id:112,fld:"",grid:0};n[113]={id:113,fld:"",grid:0};n[114]={id:114,lvl:0,type:"svchar",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSIP",gxz:"Z93UsuariosIP",gxold:"O93UsuariosIP",gxvar:"A93UsuariosIP",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A93UsuariosIP=n)},v2z:function(n){n!==undefined&&(gx.O.Z93UsuariosIP=n)},v2c:function(){gx.fn.setControlValue("USUARIOSIP",gx.O.A93UsuariosIP,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A93UsuariosIP=this.val())},val:function(){return gx.fn.getControlValue("USUARIOSIP")},nac:gx.falseFn};this.declareDomainHdlr(114,function(){});n[115]={id:115,fld:"",grid:0};n[116]={id:116,fld:"",grid:0};n[117]={id:117,fld:"",grid:0};n[118]={id:118,fld:"",grid:0};n[119]={id:119,lvl:0,type:"char",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Usuariostelef,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSTELEF",gxz:"Z260UsuariosTelef",gxold:"O260UsuariosTelef",gxvar:"A260UsuariosTelef",ucs:[],op:[],ip:[119],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A260UsuariosTelef=n)},v2z:function(n){n!==undefined&&(gx.O.Z260UsuariosTelef=n)},v2c:function(){gx.fn.setControlValue("USUARIOSTELEF",gx.O.A260UsuariosTelef,0)},c2v:function(){this.val()!==undefined&&(gx.O.A260UsuariosTelef=this.val())},val:function(){return gx.fn.getControlValue("USUARIOSTELEF")},nac:gx.falseFn};n[120]={id:120,fld:"",grid:0};n[121]={id:121,fld:"",grid:0};n[122]={id:122,fld:"",grid:0};n[123]={id:123,fld:"",grid:0};n[124]={id:124,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Usuarioscorreo,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSCORREO",gxz:"Z261UsuariosCorreo",gxold:"O261UsuariosCorreo",gxvar:"A261UsuariosCorreo",ucs:[],op:[124],ip:[124],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A261UsuariosCorreo=n)},v2z:function(n){n!==undefined&&(gx.O.Z261UsuariosCorreo=n)},v2c:function(){gx.fn.setControlValue("USUARIOSCORREO",gx.O.A261UsuariosCorreo,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A261UsuariosCorreo=this.val())},val:function(){return gx.fn.getControlValue("USUARIOSCORREO")},nac:gx.falseFn};this.declareDomainHdlr(124,function(){gx.fn.setCtrlProperty("USUARIOSCORREO","Link",gx.fn.getCtrlProperty("USUARIOSCORREO","Enabled")?"":"mailto:"+this.A261UsuariosCorreo)});n[125]={id:125,fld:"",grid:0};n[126]={id:126,fld:"",grid:0};n[127]={id:127,fld:"",grid:0};n[128]={id:128,fld:"",grid:0};n[129]={id:129,lvl:0,type:"svchar",len:90,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSNOMCOMPLETO",gxz:"Z97UsuariosNomCompleto",gxold:"O97UsuariosNomCompleto",gxvar:"A97UsuariosNomCompleto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A97UsuariosNomCompleto=n)},v2z:function(n){n!==undefined&&(gx.O.Z97UsuariosNomCompleto=n)},v2c:function(){gx.fn.setControlValue("USUARIOSNOMCOMPLETO",gx.O.A97UsuariosNomCompleto,0)},c2v:function(){this.val()!==undefined&&(gx.O.A97UsuariosNomCompleto=this.val())},val:function(){return gx.fn.getControlValue("USUARIOSNOMCOMPLETO")},nac:gx.falseFn};n[130]={id:130,fld:"",grid:0};n[131]={id:131,fld:"",grid:0};n[132]={id:132,fld:"",grid:0};n[133]={id:133,fld:"",grid:0};n[134]={id:134,lvl:0,type:"int",len:9,dec:0,sign:!1,pic:"ZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Rolid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ROLID",gxz:"Z24RolId",gxold:"O24RolId",gxvar:"A24RolId",ucs:[],op:[139],ip:[139,134],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A24RolId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z24RolId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ROLID",gx.O.A24RolId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A24RolId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ROLID",".")},nac:function(){return this.Gx_mode=="INS"&&!(0==this.AV54Insert_RolId)}};this.declareDomainHdlr(134,function(){});n[135]={id:135,fld:"",grid:0};n[136]={id:136,fld:"",grid:0};n[137]={id:137,fld:"",grid:0};n[138]={id:138,fld:"",grid:0};n[139]={id:139,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ROLNOMBRE",gxz:"Z127RolNombre",gxold:"O127RolNombre",gxvar:"A127RolNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A127RolNombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z127RolNombre=n)},v2c:function(){gx.fn.setControlValue("ROLNOMBRE",gx.O.A127RolNombre,0)},c2v:function(){this.val()!==undefined&&(gx.O.A127RolNombre=this.val())},val:function(){return gx.fn.getControlValue("ROLNOMBRE")},nac:gx.falseFn};n[140]={id:140,fld:"",grid:0};n[141]={id:141,fld:"",grid:0};n[142]={id:142,fld:"",grid:0};n[143]={id:143,fld:"",grid:0};n[144]={id:144,lvl:0,type:"char",len:1,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSSEXOFOR",gxz:"Z275UsuariosSexoFor",gxold:"O275UsuariosSexoFor",gxvar:"A275UsuariosSexoFor",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A275UsuariosSexoFor=n)},v2z:function(n){n!==undefined&&(gx.O.Z275UsuariosSexoFor=n)},v2c:function(){gx.fn.setControlValue("USUARIOSSEXOFOR",gx.O.A275UsuariosSexoFor,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A275UsuariosSexoFor=this.val())},val:function(){return gx.fn.getControlValue("USUARIOSSEXOFOR")},nac:gx.falseFn};this.declareDomainHdlr(144,function(){});n[145]={id:145,fld:"",grid:0};n[146]={id:146,fld:"",grid:0};n[147]={id:147,fld:"",grid:0};n[148]={id:148,fld:"",grid:0};n[149]={id:149,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Usuariosstatus,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSSTATUS",gxz:"Z286UsuariosStatus",gxold:"O286UsuariosStatus",gxvar:"A286UsuariosStatus",ucs:[],op:[149],ip:[149],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A286UsuariosStatus=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z286UsuariosStatus=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("USUARIOSSTATUS",gx.O.A286UsuariosStatus);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A286UsuariosStatus=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("USUARIOSSTATUS",".")},nac:gx.falseFn};this.declareDomainHdlr(149,function(){});n[150]={id:150,fld:"",grid:0};n[151]={id:151,fld:"",grid:0};n[152]={id:152,fld:"",grid:0};n[153]={id:153,fld:"",grid:0};n[154]={id:154,fld:"BTN_ENTER",grid:0,evt:"e14029_client",std:"ENTER"};n[155]={id:155,fld:"",grid:0};n[156]={id:156,fld:"BTN_CANCEL",grid:0,evt:"e15029_client"};n[157]={id:157,fld:"",grid:0};n[158]={id:158,fld:"BTN_DELETE",grid:0,evt:"e21029_client",std:"DELETE"};this.A11UsuariosId=0;this.Z11UsuariosId=0;this.O11UsuariosId=0;this.A105UsuariosCurp="";this.Z105UsuariosCurp="";this.O105UsuariosCurp="";this.A66UsuariosNombre="";this.Z66UsuariosNombre="";this.O66UsuariosNombre="";this.A65UsuariosApPat="";this.Z65UsuariosApPat="";this.O65UsuariosApPat="";this.A64UsuariosApMat="";this.Z64UsuariosApMat="";this.O64UsuariosApMat="";this.A244UsuariosUsr="";this.Z244UsuariosUsr="";this.O244UsuariosUsr="";this.A272UsuariosTipo=0;this.Z272UsuariosTipo=0;this.O272UsuariosTipo=0;this.A40000UsuariosIcono_GXI="";this.A245UsuariosIcono="";this.Z245UsuariosIcono="";this.O245UsuariosIcono="";this.A255UsuariosFecNacimiento=gx.date.nullDate();this.Z255UsuariosFecNacimiento=gx.date.nullDate();this.O255UsuariosFecNacimiento=gx.date.nullDate();this.A256UsuariosEdad=0;this.Z256UsuariosEdad=0;this.O256UsuariosEdad=0;this.A257UsuariosSexo="";this.Z257UsuariosSexo="";this.O257UsuariosSexo="";this.A68UsuariosPwd="";this.Z68UsuariosPwd="";this.O68UsuariosPwd="";this.A67UsuariosKey="";this.Z67UsuariosKey="";this.O67UsuariosKey="";this.A96UsuariosVigIni=gx.date.nullDate();this.Z96UsuariosVigIni=gx.date.nullDate();this.O96UsuariosVigIni=gx.date.nullDate();this.A70UsuariosVigFin=gx.date.nullDate();this.Z70UsuariosVigFin=gx.date.nullDate();this.O70UsuariosVigFin=gx.date.nullDate();this.A92UsuariosFecCap=gx.date.nullDate();this.Z92UsuariosFecCap=gx.date.nullDate();this.O92UsuariosFecCap=gx.date.nullDate();this.A93UsuariosIP="";this.Z93UsuariosIP="";this.O93UsuariosIP="";this.A260UsuariosTelef="";this.Z260UsuariosTelef="";this.O260UsuariosTelef="";this.A261UsuariosCorreo="";this.Z261UsuariosCorreo="";this.O261UsuariosCorreo="";this.A97UsuariosNomCompleto="";this.Z97UsuariosNomCompleto="";this.O97UsuariosNomCompleto="";this.A24RolId=0;this.Z24RolId=0;this.O24RolId=0;this.A127RolNombre="";this.Z127RolNombre="";this.O127RolNombre="";this.A275UsuariosSexoFor="";this.Z275UsuariosSexoFor="";this.O275UsuariosSexoFor="";this.A286UsuariosStatus=0;this.Z286UsuariosStatus=0;this.O286UsuariosStatus=0;this.A40000UsuariosIcono_GXI="";this.AV35usuario="";this.AV34UsrLog=0;this.AV60Pgmname="";this.AV32TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV54Insert_RolId=0;this.AV61GXV1=0;this.AV62GXV2=0;this.AV33TrnContextAtt={AttributeName:"",AttributeValue:""};this.AV11Context={User:"",CompanyCode:0,Profile:""};this.AV40UsuariosId=0;this.AV46WebSession={};this.AV30Sesion={};this.A11UsuariosId=0;this.A24RolId=0;this.AV56UsuariosCurpAnt="";this.A244UsuariosUsr="";this.A93UsuariosIP="";this.A255UsuariosFecNacimiento=gx.date.nullDate();this.A256UsuariosEdad=0;this.Gx_BScreen=0;this.Gx_date=gx.date.nullDate();this.A275UsuariosSexoFor="";this.A97UsuariosNomCompleto="";this.A105UsuariosCurp="";this.A66UsuariosNombre="";this.A65UsuariosApPat="";this.A64UsuariosApMat="";this.A272UsuariosTipo=0;this.A245UsuariosIcono="";this.A257UsuariosSexo="";this.A68UsuariosPwd="";this.A67UsuariosKey="";this.A96UsuariosVigIni=gx.date.nullDate();this.A70UsuariosVigFin=gx.date.nullDate();this.A92UsuariosFecCap=gx.date.nullDate();this.A260UsuariosTelef="";this.A261UsuariosCorreo="";this.A127RolNombre="";this.A286UsuariosStatus=0;this.AV53error1=0;this.Gx_mode="";this.AV7adscId=0;this.AV10comision=0;this.Events={e12022_client:["AFTER TRN",!0],e14029_client:["ENTER",!0],e15029_client:["CANCEL",!0],e13029_client:["'RETORNO'",!1]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV40UsuariosId",fld:"vUSUARIOSID",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV34UsrLog",fld:"vUSRLOG",pic:"ZZZZZ9",hsh:!0},{av:"AV7adscId",fld:"vADSCID",pic:"ZZZZZ9",hsh:!0},{av:"AV10comision",fld:"vCOMISION",pic:"ZZZZZ9",hsh:!0},{av:"AV32TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV40UsuariosId",fld:"vUSUARIOSID",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms.START=[[{av:"AV60Pgmname",fld:"vPGMNAME",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0}],[{av:"AV35usuario",fld:"vUSUARIO",pic:""},{av:"AV34UsrLog",fld:"vUSRLOG",pic:"ZZZZZ9",hsh:!0},{av:"AV32TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV54Insert_RolId",fld:"vINSERT_ROLID",pic:"ZZZZZZZZ9"},{av:"AV61GXV1",fld:"vGXV1",pic:"99999999"},{av:"AV33TrnContextAtt",fld:"vTRNCONTEXTATT",pic:""},{av:"AV62GXV2",fld:"vGXV2",pic:"99999999"}]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"A11UsuariosId",fld:"USUARIOSID",pic:"ZZZZZ9"},{av:"A68UsuariosPwd",fld:"USUARIOSPWD",pic:""},{av:"A244UsuariosUsr",fld:"USUARIOSUSR",pic:""},{av:"AV34UsrLog",fld:"vUSRLOG",pic:"ZZZZZ9",hsh:!0},{av:"AV7adscId",fld:"vADSCID",pic:"ZZZZZ9",hsh:!0},{av:"AV10comision",fld:"vCOMISION",pic:"ZZZZZ9",hsh:!0},{av:"AV32TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[]];this.EvtParms["'RETORNO'"]=[[],[]];this.EvtParms.VALID_USUARIOSID=[[{av:"A11UsuariosId",fld:"USUARIOSID",pic:"ZZZZZ9"},{av:"AV56UsuariosCurpAnt",fld:"vUSUARIOSCURPANT",pic:"@!"}],[{av:"AV56UsuariosCurpAnt",fld:"vUSUARIOSCURPANT",pic:"@!"}]];this.EvtParms.VALID_USUARIOSCURP=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"A105UsuariosCurp",fld:"USUARIOSCURP",pic:"@!"},{av:"Gx_BScreen",fld:"vGXBSCREEN",pic:"9"},{av:"AV56UsuariosCurpAnt",fld:"vUSUARIOSCURPANT",pic:"@!"},{av:"AV53error1",fld:"vERROR1",pic:"ZZZ9"},{av:"A244UsuariosUsr",fld:"USUARIOSUSR",pic:""},{av:"A255UsuariosFecNacimiento",fld:"USUARIOSFECNACIMIENTO",pic:""},{av:"A256UsuariosEdad",fld:"USUARIOSEDAD",pic:"ZZZ9"},{av:"A257UsuariosSexo",fld:"USUARIOSSEXO",pic:""}],[{av:"A244UsuariosUsr",fld:"USUARIOSUSR",pic:""},{av:"A255UsuariosFecNacimiento",fld:"USUARIOSFECNACIMIENTO",pic:""},{av:"A256UsuariosEdad",fld:"USUARIOSEDAD",pic:"ZZZ9"},{av:"A257UsuariosSexo",fld:"USUARIOSSEXO",pic:""},{av:"AV53error1",fld:"vERROR1",pic:"ZZZ9"}]];this.EvtParms.VALID_USUARIOSNOMBRE=[[{av:"A66UsuariosNombre",fld:"USUARIOSNOMBRE",pic:"@!"}],[{av:"A66UsuariosNombre",fld:"USUARIOSNOMBRE",pic:"@!"}]];this.EvtParms.VALID_USUARIOSAPPAT=[[{av:"A65UsuariosApPat",fld:"USUARIOSAPPAT",pic:"@!"}],[{av:"A65UsuariosApPat",fld:"USUARIOSAPPAT",pic:"@!"}]];this.EvtParms.VALID_USUARIOSAPMAT=[[{av:"A97UsuariosNomCompleto",fld:"USUARIOSNOMCOMPLETO",pic:""},{av:"A64UsuariosApMat",fld:"USUARIOSAPMAT",pic:"@!"},{av:"A65UsuariosApPat",fld:"USUARIOSAPPAT",pic:"@!"},{av:"A66UsuariosNombre",fld:"USUARIOSNOMBRE",pic:"@!"}],[{av:"A97UsuariosNomCompleto",fld:"USUARIOSNOMCOMPLETO",pic:""}]];this.EvtParms.VALID_USUARIOSTIPO=[[{ctrl:"USUARIOSTIPO"},{av:"A272UsuariosTipo",fld:"USUARIOSTIPO",pic:"ZZZ9"}],[{ctrl:"USUARIOSTIPO"},{av:"A272UsuariosTipo",fld:"USUARIOSTIPO",pic:"ZZZ9"}]];this.EvtParms.VALID_USUARIOSFECNACIMIENTO=[[{av:"A255UsuariosFecNacimiento",fld:"USUARIOSFECNACIMIENTO",pic:""}],[{av:"A255UsuariosFecNacimiento",fld:"USUARIOSFECNACIMIENTO",pic:""}]];this.EvtParms.VALID_USUARIOSSEXO=[[{av:"A275UsuariosSexoFor",fld:"USUARIOSSEXOFOR",pic:""},{av:"A257UsuariosSexo",fld:"USUARIOSSEXO",pic:""}],[{av:"A275UsuariosSexoFor",fld:"USUARIOSSEXOFOR",pic:""}]];this.EvtParms.VALID_USUARIOSVIGINI=[[{av:"A96UsuariosVigIni",fld:"USUARIOSVIGINI",pic:""}],[{av:"A96UsuariosVigIni",fld:"USUARIOSVIGINI",pic:""}]];this.EvtParms.VALID_USUARIOSVIGFIN=[[{av:"A70UsuariosVigFin",fld:"USUARIOSVIGFIN",pic:""}],[{av:"A70UsuariosVigFin",fld:"USUARIOSVIGFIN",pic:""}]];this.EvtParms.VALID_USUARIOSFECCAP=[[{av:"A92UsuariosFecCap",fld:"USUARIOSFECCAP",pic:"99/99/9999 99:99:99"}],[{av:"A92UsuariosFecCap",fld:"USUARIOSFECCAP",pic:"99/99/9999 99:99:99"}]];this.EvtParms.VALID_USUARIOSTELEF=[[{av:"A260UsuariosTelef",fld:"USUARIOSTELEF",pic:""}],[]];this.EvtParms.VALID_USUARIOSCORREO=[[{av:"A261UsuariosCorreo",fld:"USUARIOSCORREO",pic:""}],[{av:"A261UsuariosCorreo",fld:"USUARIOSCORREO",pic:""}]];this.EvtParms.VALID_ROLID=[[{av:"A24RolId",fld:"ROLID",pic:"ZZZZZZZZ9"},{av:"A127RolNombre",fld:"ROLNOMBRE",pic:""}],[{av:"A127RolNombre",fld:"ROLNOMBRE",pic:""}]];this.EvtParms.VALID_USUARIOSSTATUS=[[{ctrl:"USUARIOSSTATUS"},{av:"A286UsuariosStatus",fld:"USUARIOSSTATUS",pic:"9"}],[{ctrl:"USUARIOSSTATUS"},{av:"A286UsuariosStatus",fld:"USUARIOSSTATUS",pic:"9"}]];this.EnterCtrl=["BTN_ENTER"];this.setVCMap("AV40UsuariosId","vUSUARIOSID",0,"int",6,0);this.setVCMap("AV54Insert_RolId","vINSERT_ROLID",0,"int",9,0);this.setVCMap("AV56UsuariosCurpAnt","vUSUARIOSCURPANT",0,"svchar",18,0);this.setVCMap("Gx_date","vTODAY",0,"date",8,0);this.setVCMap("Gx_BScreen","vGXBSCREEN",0,"int",1,0);this.setVCMap("AV53error1","vERROR1",0,"int",4,0);this.setVCMap("A40000UsuariosIcono_GXI","USUARIOSICONO_GXI",0,"svchar",2048,0);this.setVCMap("AV60Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV34UsrLog","vUSRLOG",0,"int",6,0);this.setVCMap("AV7adscId","vADSCID",0,"int",6,0);this.setVCMap("AV10comision","vCOMISION",0,"int",6,0);this.setVCMap("AV32TrnContext","vTRNCONTEXT",0,"TransactionContext",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(usuarios)})