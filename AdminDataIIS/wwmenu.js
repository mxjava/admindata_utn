gx.evt.autoSkip=!1;gx.define("wwmenu",!1,function(){var n,t;this.ServerClass="wwmenu";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV19Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV19Pgmname=gx.fn.getControlValue("vPGMNAME")};this.e11212_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e15212_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e16212_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,23,24,26,27,28,29,30,31,32,33,34,35];this.GXLastCtrlId=35;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",25,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"wwmenu",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridContainer;t.addSingleLineEdit(1,26,"MENUXID","Xid","","MenuXid","int",0,"px",4,4,"right",null,[],1,"MenuXid",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(2,27,"MENUXDESC","XDesc","","MenuXDesc","svchar",0,"px",40,40,"left",null,[],2,"MenuXDesc",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");t.addSingleLineEdit(3,28,"MENUXPOSI","Position","","MenuXPosi","int",0,"px",4,4,"right",null,[],3,"MenuXPosi",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(4,29,"MENXURL","Url","","MenXUrl","svchar",490,"px",1e3,80,"left",null,[],4,"MenXUrl",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addComboBox(5,30,"MENXEST","Estado","MenXEst","char",null,0,!0,!1,0,"px","WWColumn WWOptionalColumn");t.addBitmap(259,"MENICONO",31,0,"px",17,"px",null,"","Icono","ImageAttribute","WWColumn WWOptionalColumn");t.addSingleLineEdit(258,32,"MENPADRE","Padre","","MenPadre","int",0,"px",4,4,"right",null,[],258,"MenPadre",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(262,33,"DESCRIPCION","Descripcion","","Descripcion","svchar",0,"px",120,80,"left",null,[],262,"Descripcion",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit("Update",34,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");t.addSingleLineEdit("Delete",35,"vDELETE","","","Delete","char",0,"px",20,20,"left",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLETOP",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLETEXT",format:0,grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"BTNINSERT",grid:0,evt:"e11212_client"};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vMENUXDESC",gxz:"ZV13MenuXDesc",gxold:"OV13MenuXDesc",gxvar:"AV13MenuXDesc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13MenuXDesc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13MenuXDesc=n)},v2c:function(){gx.fn.setControlValue("vMENUXDESC",gx.O.AV13MenuXDesc,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV13MenuXDesc=this.val())},val:function(){return gx.fn.getControlValue("vMENUXDESC")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"GRIDCELL",grid:0};n[19]={id:19,fld:"GRIDTABLE",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[26]={id:26,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENUXID",gxz:"Z1MenuXid",gxold:"O1MenuXid",gxvar:"A1MenuXid",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A1MenuXid=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1MenuXid=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("MENUXID",n||gx.fn.currentGridRowImpl(25),gx.O.A1MenuXid,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1MenuXid=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("MENUXID",n||gx.fn.currentGridRowImpl(25),".")},nac:gx.falseFn};n[27]={id:27,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENUXDESC",gxz:"Z2MenuXDesc",gxold:"O2MenuXDesc",gxvar:"A2MenuXDesc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2MenuXDesc=n)},v2z:function(n){n!==undefined&&(gx.O.Z2MenuXDesc=n)},v2c:function(n){gx.fn.setGridControlValue("MENUXDESC",n||gx.fn.currentGridRowImpl(25),gx.O.A2MenuXDesc,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2MenuXDesc=this.val(n))},val:function(n){return gx.fn.getGridControlValue("MENUXDESC",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[28]={id:28,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENUXPOSI",gxz:"Z3MenuXPosi",gxold:"O3MenuXPosi",gxvar:"A3MenuXPosi",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A3MenuXPosi=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z3MenuXPosi=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("MENUXPOSI",n||gx.fn.currentGridRowImpl(25),gx.O.A3MenuXPosi,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A3MenuXPosi=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("MENUXPOSI",n||gx.fn.currentGridRowImpl(25),".")},nac:gx.falseFn};n[29]={id:29,lvl:2,type:"svchar",len:1e3,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENXURL",gxz:"Z4MenXUrl",gxold:"O4MenXUrl",gxvar:"A4MenXUrl",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"url",v2v:function(n){n!==undefined&&(gx.O.A4MenXUrl=n)},v2z:function(n){n!==undefined&&(gx.O.Z4MenXUrl=n)},v2c:function(n){gx.fn.setGridControlValue("MENXURL",n||gx.fn.currentGridRowImpl(25),gx.O.A4MenXUrl,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A4MenXUrl=this.val(n))},val:function(n){return gx.fn.getGridControlValue("MENXURL",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[30]={id:30,lvl:2,type:"char",len:1,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENXEST",gxz:"Z5MenXEst",gxold:"O5MenXEst",gxvar:"A5MenXEst",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A5MenXEst=n)},v2z:function(n){n!==undefined&&(gx.O.Z5MenXEst=n)},v2c:function(n){gx.fn.setGridComboBoxValue("MENXEST",n||gx.fn.currentGridRowImpl(25),gx.O.A5MenXEst)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A5MenXEst=this.val(n))},val:function(n){return gx.fn.getGridControlValue("MENXEST",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[31]={id:31,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENICONO",gxz:"Z259MenIcono",gxold:"O259MenIcono",gxvar:"A259MenIcono",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A259MenIcono=n)},v2z:function(n){n!==undefined&&(gx.O.Z259MenIcono=n)},v2c:function(n){gx.fn.setGridMultimediaValue("MENICONO",n||gx.fn.currentGridRowImpl(25),gx.O.A259MenIcono,gx.O.A40000MenIcono_GXI)},c2v:function(n){gx.O.A40000MenIcono_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.A259MenIcono=this.val(n))},val:function(n){return gx.fn.getGridControlValue("MENICONO",n||gx.fn.currentGridRowImpl(25))},val_GXI:function(n){return gx.fn.getGridControlValue("MENICONO_GXI",n||gx.fn.currentGridRowImpl(25))},gxvar_GXI:"A40000MenIcono_GXI",nac:gx.falseFn};n[32]={id:32,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENPADRE",gxz:"Z258MenPadre",gxold:"O258MenPadre",gxvar:"A258MenPadre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A258MenPadre=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z258MenPadre=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("MENPADRE",n||gx.fn.currentGridRowImpl(25),gx.O.A258MenPadre,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A258MenPadre=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("MENPADRE",n||gx.fn.currentGridRowImpl(25),".")},nac:gx.falseFn};n[33]={id:33,lvl:2,type:"svchar",len:120,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DESCRIPCION",gxz:"Z262Descripcion",gxold:"O262Descripcion",gxvar:"A262Descripcion",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A262Descripcion=n)},v2z:function(n){n!==undefined&&(gx.O.Z262Descripcion=n)},v2c:function(n){gx.fn.setGridControlValue("DESCRIPCION",n||gx.fn.currentGridRowImpl(25),gx.O.A262Descripcion,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A262Descripcion=this.val(n))},val:function(n){return gx.fn.getGridControlValue("DESCRIPCION",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[34]={id:34,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",gxz:"ZV14Update",gxold:"OV14Update",gxvar:"AV14Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV14Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(25),gx.O.AV14Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV14Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[35]={id:35,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",gxz:"ZV15Delete",gxold:"OV15Delete",gxvar:"AV15Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV15Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(25),gx.O.AV15Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV15Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};this.AV13MenuXDesc="";this.ZV13MenuXDesc="";this.OV13MenuXDesc="";this.Z1MenuXid=0;this.O1MenuXid=0;this.Z2MenuXDesc="";this.O2MenuXDesc="";this.Z3MenuXPosi=0;this.O3MenuXPosi=0;this.Z4MenXUrl="";this.O4MenXUrl="";this.Z5MenXEst="";this.O5MenXEst="";this.Z259MenIcono="";this.O259MenIcono="";this.Z258MenPadre=0;this.O258MenPadre=0;this.Z262Descripcion="";this.O262Descripcion="";this.ZV14Update="";this.OV14Update="";this.ZV15Delete="";this.OV15Delete="";this.AV13MenuXDesc="";this.A40000MenIcono_GXI="";this.A1MenuXid=0;this.A2MenuXDesc="";this.A3MenuXPosi=0;this.A4MenXUrl="";this.A5MenXEst="";this.A259MenIcono="";this.A258MenPadre=0;this.A262Descripcion="";this.AV14Update="";this.AV15Delete="";this.AV19Pgmname="";this.Events={e11212_client:["'DOINSERT'",!0],e15212_client:["ENTER",!0],e16212_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV14Update",fld:"vUPDATE",pic:""},{av:"AV15Delete",fld:"vDELETE",pic:""},{av:"AV13MenuXDesc",fld:"vMENUXDESC",pic:""},{av:"AV19Pgmname",fld:"vPGMNAME",pic:"",hsh:!0}],[]];this.EvtParms.START=[[{av:"AV19Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV13MenuXDesc",fld:"vMENUXDESC",pic:""},{av:"AV14Update",fld:"vUPDATE",pic:""},{av:"AV15Delete",fld:"vDELETE",pic:""}],[{ctrl:"GRID",prop:"Rows"},{av:"AV14Update",fld:"vUPDATE",pic:""},{av:"AV15Delete",fld:"vDELETE",pic:""},{ctrl:"FORM",prop:"Caption"},{av:"AV13MenuXDesc",fld:"vMENUXDESC",pic:""},{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV19Pgmname",fld:"vPGMNAME",pic:"",hsh:!0}]];this.EvtParms["GRID.LOAD"]=[[{av:"A1MenuXid",fld:"MENUXID",pic:"ZZZ9",hsh:!0}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"},{av:'gx.fn.getCtrlProperty("MENUXDESC","Link")',ctrl:"MENUXDESC",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A1MenuXid",fld:"MENUXID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV14Update",fld:"vUPDATE",pic:""},{av:"AV15Delete",fld:"vDELETE",pic:""},{av:"AV19Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV13MenuXDesc",fld:"vMENUXDESC",pic:""}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV14Update",fld:"vUPDATE",pic:""},{av:"AV15Delete",fld:"vDELETE",pic:""},{av:"AV19Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV13MenuXDesc",fld:"vMENUXDESC",pic:""}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV14Update",fld:"vUPDATE",pic:""},{av:"AV15Delete",fld:"vDELETE",pic:""},{av:"AV19Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV13MenuXDesc",fld:"vMENUXDESC",pic:""}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV14Update",fld:"vUPDATE",pic:""},{av:"AV15Delete",fld:"vDELETE",pic:""},{av:"AV19Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV13MenuXDesc",fld:"vMENUXDESC",pic:""}],[]];this.setVCMap("AV19Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV19Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV19Pgmname","vPGMNAME",0,"char",129,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar({rfrVar:"AV19Pgmname"});t.addRefreshingVar({rfrVar:"AV14Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingVar({rfrVar:"AV15Delete",rfrProp:"Value",gxAttId:"Delete"});t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm({rfrVar:"AV19Pgmname"});t.addRefreshingParm({rfrVar:"AV14Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingParm({rfrVar:"AV15Delete",rfrProp:"Value",gxAttId:"Delete"});this.Initialize()});gx.wi(function(){gx.createParentObj(wwmenu)})