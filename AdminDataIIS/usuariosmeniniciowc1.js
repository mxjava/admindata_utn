gx.evt.autoSkip=!1;gx.define("usuariosmeniniciowc1",!0,function(n){var i,t;this.ServerClass="usuariosmeniniciowc1";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV7sgUsrMenId=gx.fn.getIntegerValue("vSGUSRMENID",".");this.AV7sgUsrMenId=gx.fn.getIntegerValue("vSGUSRMENID",".")};this.e110u2_client=function(){return this.executeServerEvent("'DOINSERT'",!0,null,!1,!1)};this.e140u2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e150u2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];i=this.GXValidFnc;this.GXCtrlIds=[2,5,9,13,14,15,16,17,18,19,20,23];this.GXLastCtrlId=23;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",12,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"usuariosmeniniciowc1",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!1,!1);t=this.GridContainer;t.addBitmap("&Update","vUPDATE",13,0,"px",17,"px",null,"","","Image","");t.addBitmap("&Delete","vDELETE",14,0,"px",17,"px",null,"","","Image","");t.addSingleLineEdit(58,15,"MENINICIOID","Clave del mensaje","","menInicioId","int",0,"px",6,6,"right",null,[],58,"menInicioId",!0,0,!1,!1,"Attribute",1,"");t.addSingleLineEdit(150,16,"MENINICIODES","Mensaje","","menInicioDes","svchar",0,"px",255,80,"left",null,[],150,"menInicioDes",!0,0,!1,!1,"Attribute",1,"");t.addSingleLineEdit(186,17,"MENINICIOFECINI","Fecha Inicio","","menInicioFecIni","date",0,"px",10,10,"right",null,[],186,"menInicioFecIni",!0,0,!1,!1,"Attribute",1,"");t.addSingleLineEdit(76,18,"MENINICIOFECFIN","Fecha Fin","","menInicioFecFin","date",0,"px",10,10,"right",null,[],76,"menInicioFecFin",!0,0,!1,!1,"Attribute",1,"");t.addComboBox(77,19,"MENINICIOSTAT","Status","menInicioStat","int",null,0,!0,!1,0,"px","");t.addSingleLineEdit(185,20,"MENINICIOFECCAP","Fecha/Hora Captura","","menInicioFecCap","dtime",0,"px",19,19,"right",null,[],185,"menInicioFecCap",!0,8,!1,!1,"Attribute",1,"");this.GridContainer.emptyText="";this.setGrid(t);i[2]={id:2,fld:"TABLE",grid:0};i[5]={id:5,fld:"TABLEGRIDCONTAINER",grid:0};i[9]={id:9,fld:"INSERT",grid:0,evt:"e110u2_client"};i[13]={id:13,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",gxz:"ZV12Update",gxold:"OV12Update",gxvar:"AV12Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV12Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Update=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vUPDATE",n||gx.fn.currentGridRowImpl(12),gx.O.AV12Update,gx.O.AV18Update_GXI)},c2v:function(n){gx.O.AV18Update_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV12Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(12))},val_GXI:function(n){return gx.fn.getGridControlValue("vUPDATE_GXI",n||gx.fn.currentGridRowImpl(12))},gxvar_GXI:"AV18Update_GXI",nac:gx.falseFn};i[14]={id:14,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",gxz:"ZV13Delete",gxold:"OV13Delete",gxvar:"AV13Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV13Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Delete=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vDELETE",n||gx.fn.currentGridRowImpl(12),gx.O.AV13Delete,gx.O.AV19Delete_GXI)},c2v:function(n){gx.O.AV19Delete_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV13Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(12))},val_GXI:function(n){return gx.fn.getGridControlValue("vDELETE_GXI",n||gx.fn.currentGridRowImpl(12))},gxvar_GXI:"AV19Delete_GXI",nac:gx.falseFn};i[15]={id:15,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENINICIOID",gxz:"Z58menInicioId",gxold:"O58menInicioId",gxvar:"A58menInicioId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A58menInicioId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z58menInicioId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("MENINICIOID",n||gx.fn.currentGridRowImpl(12),gx.O.A58menInicioId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A58menInicioId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("MENINICIOID",n||gx.fn.currentGridRowImpl(12),".")},nac:gx.falseFn};i[16]={id:16,lvl:2,type:"svchar",len:255,dec:0,sign:!1,ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENINICIODES",gxz:"Z150menInicioDes",gxold:"O150menInicioDes",gxvar:"A150menInicioDes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A150menInicioDes=n)},v2z:function(n){n!==undefined&&(gx.O.Z150menInicioDes=n)},v2c:function(n){gx.fn.setGridControlValue("MENINICIODES",n||gx.fn.currentGridRowImpl(12),gx.O.A150menInicioDes,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A150menInicioDes=this.val(n))},val:function(n){return gx.fn.getGridControlValue("MENINICIODES",n||gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};i[17]={id:17,lvl:2,type:"date",len:10,dec:0,sign:!1,ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENINICIOFECINI",gxz:"Z186menInicioFecIni",gxold:"O186menInicioFecIni",gxvar:"A186menInicioFecIni",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A186menInicioFecIni=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z186menInicioFecIni=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("MENINICIOFECINI",n||gx.fn.currentGridRowImpl(12),gx.O.A186menInicioFecIni,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A186menInicioFecIni=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("MENINICIOFECINI",n||gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};i[18]={id:18,lvl:2,type:"date",len:10,dec:0,sign:!1,ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENINICIOFECFIN",gxz:"Z76menInicioFecFin",gxold:"O76menInicioFecFin",gxvar:"A76menInicioFecFin",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A76menInicioFecFin=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z76menInicioFecFin=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("MENINICIOFECFIN",n||gx.fn.currentGridRowImpl(12),gx.O.A76menInicioFecFin,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A76menInicioFecFin=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("MENINICIOFECFIN",n||gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};i[19]={id:19,lvl:2,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENINICIOSTAT",gxz:"Z77menInicioStat",gxold:"O77menInicioStat",gxvar:"A77menInicioStat",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A77menInicioStat=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z77menInicioStat=gx.num.intval(n))},v2c:function(n){gx.fn.setGridComboBoxValue("MENINICIOSTAT",n||gx.fn.currentGridRowImpl(12),gx.O.A77menInicioStat)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A77menInicioStat=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("MENINICIOSTAT",n||gx.fn.currentGridRowImpl(12),".")},nac:gx.falseFn};i[20]={id:20,lvl:2,type:"dtime",len:10,dec:8,sign:!1,ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENINICIOFECCAP",gxz:"Z185menInicioFecCap",gxold:"O185menInicioFecCap",gxvar:"A185menInicioFecCap",dp:{f:0,st:!0,wn:!1,mf:!1,pic:"99/99/9999 99:99:99",dec:8},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A185menInicioFecCap=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z185menInicioFecCap=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("MENINICIOFECCAP",n||gx.fn.currentGridRowImpl(12),gx.O.A185menInicioFecCap,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A185menInicioFecCap=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("MENINICIOFECCAP",n||gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};i[23]={id:23,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SGUSRMENID",gxz:"Z59sgUsrMenId",gxold:"O59sgUsrMenId",gxvar:"A59sgUsrMenId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A59sgUsrMenId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z59sgUsrMenId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("SGUSRMENID",gx.O.A59sgUsrMenId,0)},c2v:function(){this.val()!==undefined&&(gx.O.A59sgUsrMenId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("SGUSRMENID",".")},nac:gx.falseFn};this.ZV12Update="";this.OV12Update="";this.ZV13Delete="";this.OV13Delete="";this.Z58menInicioId=0;this.O58menInicioId=0;this.Z150menInicioDes="";this.O150menInicioDes="";this.Z186menInicioFecIni=gx.date.nullDate();this.O186menInicioFecIni=gx.date.nullDate();this.Z76menInicioFecFin=gx.date.nullDate();this.O76menInicioFecFin=gx.date.nullDate();this.Z77menInicioStat=0;this.O77menInicioStat=0;this.Z185menInicioFecCap=gx.date.nullDate();this.O185menInicioFecCap=gx.date.nullDate();this.A59sgUsrMenId=0;this.Z59sgUsrMenId=0;this.O59sgUsrMenId=0;this.A59sgUsrMenId=0;this.AV7sgUsrMenId=0;this.AV12Update="";this.AV13Delete="";this.A58menInicioId=0;this.A150menInicioDes="";this.A186menInicioFecIni=gx.date.nullDate();this.A76menInicioFecFin=gx.date.nullDate();this.A77menInicioStat=0;this.A185menInicioFecCap=gx.date.nullDate();this.Events={e110u2_client:["'DOINSERT'",!0],e140u2_client:["ENTER",!0],e150u2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV7sgUsrMenId",fld:"vSGUSRMENID",pic:"ZZZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:'gx.fn.getCtrlProperty("vUPDATE","Tooltiptext")',ctrl:"vUPDATE",prop:"Tooltiptext"},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:'gx.fn.getCtrlProperty("vDELETE","Tooltiptext")',ctrl:"vDELETE",prop:"Tooltiptext"},{av:"sPrefix"}],[]];this.EvtParms.START=[[{av:"AV17Pgmname",fld:"vPGMNAME",pic:""},{av:"AV7sgUsrMenId",fld:"vSGUSRMENID",pic:"ZZZZZ9"}],[{ctrl:"GRID",prop:"Rows"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:'gx.fn.getCtrlProperty("vUPDATE","Tooltiptext")',ctrl:"vUPDATE",prop:"Tooltiptext"},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:'gx.fn.getCtrlProperty("vDELETE","Tooltiptext")',ctrl:"vDELETE",prop:"Tooltiptext"},{av:'gx.fn.getCtrlProperty("SGUSRMENID","Visible")',ctrl:"SGUSRMENID",prop:"Visible"}]];this.EvtParms["GRID.LOAD"]=[[{av:"A58menInicioId",fld:"MENINICIOID",pic:"ZZZZZ9",hsh:!0}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A58menInicioId",fld:"MENINICIOID",pic:"ZZZZZ9",hsh:!0},{av:"AV7sgUsrMenId",fld:"vSGUSRMENID",pic:"ZZZZZ9"}],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV7sgUsrMenId",fld:"vSGUSRMENID",pic:"ZZZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:'gx.fn.getCtrlProperty("vUPDATE","Tooltiptext")',ctrl:"vUPDATE",prop:"Tooltiptext"},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:'gx.fn.getCtrlProperty("vDELETE","Tooltiptext")',ctrl:"vDELETE",prop:"Tooltiptext"},{av:"sPrefix"}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV7sgUsrMenId",fld:"vSGUSRMENID",pic:"ZZZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:'gx.fn.getCtrlProperty("vUPDATE","Tooltiptext")',ctrl:"vUPDATE",prop:"Tooltiptext"},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:'gx.fn.getCtrlProperty("vDELETE","Tooltiptext")',ctrl:"vDELETE",prop:"Tooltiptext"},{av:"sPrefix"}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV7sgUsrMenId",fld:"vSGUSRMENID",pic:"ZZZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:'gx.fn.getCtrlProperty("vUPDATE","Tooltiptext")',ctrl:"vUPDATE",prop:"Tooltiptext"},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:'gx.fn.getCtrlProperty("vDELETE","Tooltiptext")',ctrl:"vDELETE",prop:"Tooltiptext"},{av:"sPrefix"}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV7sgUsrMenId",fld:"vSGUSRMENID",pic:"ZZZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:'gx.fn.getCtrlProperty("vUPDATE","Tooltiptext")',ctrl:"vUPDATE",prop:"Tooltiptext"},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:'gx.fn.getCtrlProperty("vDELETE","Tooltiptext")',ctrl:"vDELETE",prop:"Tooltiptext"},{av:"sPrefix"}],[]];this.setVCMap("AV7sgUsrMenId","vSGUSRMENID",0,"int",6,0);this.setVCMap("AV7sgUsrMenId","vSGUSRMENID",0,"int",6,0);this.setVCMap("AV7sgUsrMenId","vSGUSRMENID",0,"int",6,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});t.addRefreshingVar({rfrVar:"AV7sgUsrMenId"});t.addRefreshingVar({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingVar({rfrVar:"AV12Update",rfrProp:"Tooltiptext",gxAttId:"Update"});t.addRefreshingVar({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});t.addRefreshingVar({rfrVar:"AV13Delete",rfrProp:"Tooltiptext",gxAttId:"Delete"});t.addRefreshingParm({rfrVar:"AV7sgUsrMenId"});t.addRefreshingParm({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingParm({rfrVar:"AV12Update",rfrProp:"Tooltiptext",gxAttId:"Update"});t.addRefreshingParm({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});t.addRefreshingParm({rfrVar:"AV13Delete",rfrProp:"Tooltiptext",gxAttId:"Delete"});this.Initialize()})