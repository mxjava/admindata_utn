gx.evt.autoSkip=!1;gx.define("wwusuarios",!1,function(){var n,t;this.ServerClass="wwusuarios";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV19Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV19Pgmname=gx.fn.getControlValue("vPGMNAME")};this.e110f2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e150f2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e160f2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,27,28,29,30,31,32,33,34,35,36,37,38,39];this.GXLastCtrlId=39;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",26,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"wwusuarios",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridContainer;t.addSingleLineEdit(11,27,"USUARIOSID","ID","","UsuariosId","int",0,"px",6,6,"right",null,[],11,"UsuariosId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(105,28,"USUARIOSCURP","Curp","","UsuariosCurp","svchar",0,"px",18,18,"left",null,[],105,"UsuariosCurp",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(66,29,"USUARIOSNOMBRE","Nombre","","UsuariosNombre","svchar",0,"px",40,40,"left",null,[],66,"UsuariosNombre",!0,0,!1,!1,"Attribute",1,"WWColumn");t.addSingleLineEdit(65,30,"USUARIOSAPPAT","P. Apellido","Primer Apellido","UsuariosApPat","svchar",0,"px",40,40,"left",null,[],65,"UsuariosApPat",!0,0,!1,!1,"Attribute",1,"WWColumn");t.addSingleLineEdit(64,31,"USUARIOSAPMAT","S. Apellido","Segundo Apellido","UsuariosApMat","svchar",0,"px",40,40,"left",null,[],64,"UsuariosApMat",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(255,32,"USUARIOSFECNACIMIENTO","F. Nacimiento","Fecha de Nacimiento","UsuariosFecNacimiento","date",0,"px",8,8,"right",null,[],255,"UsuariosFecNacimiento",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(256,33,"USUARIOSEDAD","Edad","","UsuariosEdad","int",0,"px",4,4,"right",null,[],256,"UsuariosEdad",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(257,34,"USUARIOSSEXO","Sexo","","UsuariosSexo","char",0,"px",1,1,"left",null,[],257,"UsuariosSexo",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(260,35,"USUARIOSTELEF","Teléfono","","UsuariosTelef","char",0,"px",10,10,"left",null,[],260,"UsuariosTelef",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(261,36,"USUARIOSCORREO","Correo","Correo electrónico","UsuariosCorreo","svchar",0,"px",100,80,"left",null,[],261,"UsuariosCorreo",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addComboBox(272,37,"USUARIOSTIPO","Tipo","UsuariosTipo","int",null,0,!0,!1,0,"px","WWColumn WWOptionalColumn");t.addComboBox(286,38,"USUARIOSSTATUS","Estatús","UsuariosStatus","int",null,0,!0,!1,0,"px","WWColumn");t.addSingleLineEdit("Update",39,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLETOP",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLETEXT",format:0,grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"BTNINSERT",grid:0,evt:"e110f2_client"};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"svchar",len:40,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vUSUARIOSNOMBRE",gxz:"ZV16UsuariosNombre",gxold:"OV16UsuariosNombre",gxvar:"AV16UsuariosNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV16UsuariosNombre=n)},v2z:function(n){n!==undefined&&(gx.O.ZV16UsuariosNombre=n)},v2c:function(){gx.fn.setControlValue("vUSUARIOSNOMBRE",gx.O.AV16UsuariosNombre,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV16UsuariosNombre=this.val())},val:function(){return gx.fn.getControlValue("vUSUARIOSNOMBRE")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"GRIDCELL",grid:0};n[20]={id:20,fld:"GRIDTABLE",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[27]={id:27,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSID",gxz:"Z11UsuariosId",gxold:"O11UsuariosId",gxvar:"A11UsuariosId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A11UsuariosId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z11UsuariosId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("USUARIOSID",n||gx.fn.currentGridRowImpl(26),gx.O.A11UsuariosId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A11UsuariosId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("USUARIOSID",n||gx.fn.currentGridRowImpl(26),".")},nac:gx.falseFn};n[28]={id:28,lvl:2,type:"svchar",len:18,dec:0,sign:!1,pic:"@!",ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSCURP",gxz:"Z105UsuariosCurp",gxold:"O105UsuariosCurp",gxvar:"A105UsuariosCurp",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A105UsuariosCurp=n)},v2z:function(n){n!==undefined&&(gx.O.Z105UsuariosCurp=n)},v2c:function(n){gx.fn.setGridControlValue("USUARIOSCURP",n||gx.fn.currentGridRowImpl(26),gx.O.A105UsuariosCurp,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A105UsuariosCurp=this.val(n))},val:function(n){return gx.fn.getGridControlValue("USUARIOSCURP",n||gx.fn.currentGridRowImpl(26))},nac:gx.falseFn};n[29]={id:29,lvl:2,type:"svchar",len:40,dec:0,sign:!1,pic:"@!",ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSNOMBRE",gxz:"Z66UsuariosNombre",gxold:"O66UsuariosNombre",gxvar:"A66UsuariosNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A66UsuariosNombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z66UsuariosNombre=n)},v2c:function(n){gx.fn.setGridControlValue("USUARIOSNOMBRE",n||gx.fn.currentGridRowImpl(26),gx.O.A66UsuariosNombre,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A66UsuariosNombre=this.val(n))},val:function(n){return gx.fn.getGridControlValue("USUARIOSNOMBRE",n||gx.fn.currentGridRowImpl(26))},nac:gx.falseFn};n[30]={id:30,lvl:2,type:"svchar",len:40,dec:0,sign:!1,pic:"@!",ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSAPPAT",gxz:"Z65UsuariosApPat",gxold:"O65UsuariosApPat",gxvar:"A65UsuariosApPat",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A65UsuariosApPat=n)},v2z:function(n){n!==undefined&&(gx.O.Z65UsuariosApPat=n)},v2c:function(n){gx.fn.setGridControlValue("USUARIOSAPPAT",n||gx.fn.currentGridRowImpl(26),gx.O.A65UsuariosApPat,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A65UsuariosApPat=this.val(n))},val:function(n){return gx.fn.getGridControlValue("USUARIOSAPPAT",n||gx.fn.currentGridRowImpl(26))},nac:gx.falseFn};n[31]={id:31,lvl:2,type:"svchar",len:40,dec:0,sign:!1,pic:"@!",ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSAPMAT",gxz:"Z64UsuariosApMat",gxold:"O64UsuariosApMat",gxvar:"A64UsuariosApMat",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A64UsuariosApMat=n)},v2z:function(n){n!==undefined&&(gx.O.Z64UsuariosApMat=n)},v2c:function(n){gx.fn.setGridControlValue("USUARIOSAPMAT",n||gx.fn.currentGridRowImpl(26),gx.O.A64UsuariosApMat,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A64UsuariosApMat=this.val(n))},val:function(n){return gx.fn.getGridControlValue("USUARIOSAPMAT",n||gx.fn.currentGridRowImpl(26))},nac:gx.falseFn};n[32]={id:32,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSFECNACIMIENTO",gxz:"Z255UsuariosFecNacimiento",gxold:"O255UsuariosFecNacimiento",gxvar:"A255UsuariosFecNacimiento",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A255UsuariosFecNacimiento=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z255UsuariosFecNacimiento=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("USUARIOSFECNACIMIENTO",n||gx.fn.currentGridRowImpl(26),gx.O.A255UsuariosFecNacimiento,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A255UsuariosFecNacimiento=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("USUARIOSFECNACIMIENTO",n||gx.fn.currentGridRowImpl(26))},nac:gx.falseFn};n[33]={id:33,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSEDAD",gxz:"Z256UsuariosEdad",gxold:"O256UsuariosEdad",gxvar:"A256UsuariosEdad",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A256UsuariosEdad=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z256UsuariosEdad=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("USUARIOSEDAD",n||gx.fn.currentGridRowImpl(26),gx.O.A256UsuariosEdad,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A256UsuariosEdad=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("USUARIOSEDAD",n||gx.fn.currentGridRowImpl(26),".")},nac:gx.falseFn};n[34]={id:34,lvl:2,type:"char",len:1,dec:0,sign:!1,ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSSEXO",gxz:"Z257UsuariosSexo",gxold:"O257UsuariosSexo",gxvar:"A257UsuariosSexo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A257UsuariosSexo=n)},v2z:function(n){n!==undefined&&(gx.O.Z257UsuariosSexo=n)},v2c:function(n){gx.fn.setGridControlValue("USUARIOSSEXO",n||gx.fn.currentGridRowImpl(26),gx.O.A257UsuariosSexo,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A257UsuariosSexo=this.val(n))},val:function(n){return gx.fn.getGridControlValue("USUARIOSSEXO",n||gx.fn.currentGridRowImpl(26))},nac:gx.falseFn};n[35]={id:35,lvl:2,type:"char",len:10,dec:0,sign:!1,ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSTELEF",gxz:"Z260UsuariosTelef",gxold:"O260UsuariosTelef",gxvar:"A260UsuariosTelef",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A260UsuariosTelef=n)},v2z:function(n){n!==undefined&&(gx.O.Z260UsuariosTelef=n)},v2c:function(n){gx.fn.setGridControlValue("USUARIOSTELEF",n||gx.fn.currentGridRowImpl(26),gx.O.A260UsuariosTelef,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A260UsuariosTelef=this.val(n))},val:function(n){return gx.fn.getGridControlValue("USUARIOSTELEF",n||gx.fn.currentGridRowImpl(26))},nac:gx.falseFn};n[36]={id:36,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSCORREO",gxz:"Z261UsuariosCorreo",gxold:"O261UsuariosCorreo",gxvar:"A261UsuariosCorreo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"email",v2v:function(n){n!==undefined&&(gx.O.A261UsuariosCorreo=n)},v2z:function(n){n!==undefined&&(gx.O.Z261UsuariosCorreo=n)},v2c:function(n){gx.fn.setGridControlValue("USUARIOSCORREO",n||gx.fn.currentGridRowImpl(26),gx.O.A261UsuariosCorreo,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A261UsuariosCorreo=this.val(n))},val:function(n){return gx.fn.getGridControlValue("USUARIOSCORREO",n||gx.fn.currentGridRowImpl(26))},nac:gx.falseFn};n[37]={id:37,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSTIPO",gxz:"Z272UsuariosTipo",gxold:"O272UsuariosTipo",gxvar:"A272UsuariosTipo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A272UsuariosTipo=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z272UsuariosTipo=gx.num.intval(n))},v2c:function(n){gx.fn.setGridComboBoxValue("USUARIOSTIPO",n||gx.fn.currentGridRowImpl(26),gx.O.A272UsuariosTipo);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A272UsuariosTipo=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("USUARIOSTIPO",n||gx.fn.currentGridRowImpl(26),".")},nac:gx.falseFn};n[38]={id:38,lvl:2,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSSTATUS",gxz:"Z286UsuariosStatus",gxold:"O286UsuariosStatus",gxvar:"A286UsuariosStatus",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A286UsuariosStatus=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z286UsuariosStatus=gx.num.intval(n))},v2c:function(n){gx.fn.setGridComboBoxValue("USUARIOSSTATUS",n||gx.fn.currentGridRowImpl(26),gx.O.A286UsuariosStatus);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A286UsuariosStatus=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("USUARIOSSTATUS",n||gx.fn.currentGridRowImpl(26),".")},nac:gx.falseFn};n[39]={id:39,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",gxz:"ZV13Update",gxold:"OV13Update",gxvar:"AV13Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(26),gx.O.AV13Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(26))},nac:gx.falseFn};this.AV16UsuariosNombre="";this.ZV16UsuariosNombre="";this.OV16UsuariosNombre="";this.Z11UsuariosId=0;this.O11UsuariosId=0;this.Z105UsuariosCurp="";this.O105UsuariosCurp="";this.Z66UsuariosNombre="";this.O66UsuariosNombre="";this.Z65UsuariosApPat="";this.O65UsuariosApPat="";this.Z64UsuariosApMat="";this.O64UsuariosApMat="";this.Z255UsuariosFecNacimiento=gx.date.nullDate();this.O255UsuariosFecNacimiento=gx.date.nullDate();this.Z256UsuariosEdad=0;this.O256UsuariosEdad=0;this.Z257UsuariosSexo="";this.O257UsuariosSexo="";this.Z260UsuariosTelef="";this.O260UsuariosTelef="";this.Z261UsuariosCorreo="";this.O261UsuariosCorreo="";this.Z272UsuariosTipo=0;this.O272UsuariosTipo=0;this.Z286UsuariosStatus=0;this.O286UsuariosStatus=0;this.ZV13Update="";this.OV13Update="";this.AV16UsuariosNombre="";this.A11UsuariosId=0;this.A105UsuariosCurp="";this.A66UsuariosNombre="";this.A65UsuariosApPat="";this.A64UsuariosApMat="";this.A255UsuariosFecNacimiento=gx.date.nullDate();this.A256UsuariosEdad=0;this.A257UsuariosSexo="";this.A260UsuariosTelef="";this.A261UsuariosCorreo="";this.A272UsuariosTipo=0;this.A286UsuariosStatus=0;this.AV13Update="";this.AV19Pgmname="";this.Events={e110f2_client:["'DOINSERT'",!0],e150f2_client:["ENTER",!0],e160f2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV16UsuariosNombre",fld:"vUSUARIOSNOMBRE",pic:"@!"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV19Pgmname",fld:"vPGMNAME",pic:"",hsh:!0}],[]];this.EvtParms.START=[[{av:"AV19Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV16UsuariosNombre",fld:"vUSUARIOSNOMBRE",pic:"@!"},{av:"AV13Update",fld:"vUPDATE",pic:""}],[{ctrl:"GRID",prop:"Rows"},{av:"AV13Update",fld:"vUPDATE",pic:""},{ctrl:"FORM",prop:"Caption"},{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV16UsuariosNombre",fld:"vUSUARIOSNOMBRE",pic:"@!"},{av:"AV19Pgmname",fld:"vPGMNAME",pic:"",hsh:!0}]];this.EvtParms["GRID.LOAD"]=[[{ctrl:"USUARIOSSTATUS"},{av:"A286UsuariosStatus",fld:"USUARIOSSTATUS",pic:"9"},{av:"A11UsuariosId",fld:"USUARIOSID",pic:"ZZZZZ9",hsh:!0}],[{ctrl:"USUARIOSSTATUS"},{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A11UsuariosId",fld:"USUARIOSID",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV16UsuariosNombre",fld:"vUSUARIOSNOMBRE",pic:"@!"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV19Pgmname",fld:"vPGMNAME",pic:"",hsh:!0}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV16UsuariosNombre",fld:"vUSUARIOSNOMBRE",pic:"@!"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV19Pgmname",fld:"vPGMNAME",pic:"",hsh:!0}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV16UsuariosNombre",fld:"vUSUARIOSNOMBRE",pic:"@!"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV19Pgmname",fld:"vPGMNAME",pic:"",hsh:!0}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV16UsuariosNombre",fld:"vUSUARIOSNOMBRE",pic:"@!"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV19Pgmname",fld:"vPGMNAME",pic:"",hsh:!0}],[]];this.setVCMap("AV19Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV19Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV19Pgmname","vPGMNAME",0,"char",129,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar({rfrVar:"AV19Pgmname"});t.addRefreshingVar({rfrVar:"AV13Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm({rfrVar:"AV19Pgmname"});t.addRefreshingParm({rfrVar:"AV13Update",rfrProp:"Value",gxAttId:"Update"});this.Initialize()});gx.wi(function(){gx.createParentObj(wwusuarios)})