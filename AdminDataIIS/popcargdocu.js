gx.evt.autoSkip=!1;gx.define("popcargdocu",!1,function(){var n,i,t;this.ServerClass="popcargdocu";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV9archivo=gx.fn.getControlValue("vARCHIVO");this.AV22Vacantes_Id=gx.fn.getIntegerValue("vVACANTES_ID",".");this.AV17UsuariosId=gx.fn.getIntegerValue("vUSUARIOSID",".");this.AV25Estatus_Filtro=gx.fn.getIntegerValue("vESTATUS_FILTRO",".");this.AV6UploadedFiles=gx.fn.getControlValue("vUPLOADEDFILES");this.AV11ruta=gx.fn.getControlValue("vRUTA");this.AV21VarDoc=gx.fn.getControlValue("vVARDOC");this.AV19UsuariosCurp=gx.fn.getControlValue("vUSUARIOSCURP");this.AV20RutaGuardada=gx.fn.getControlValue("vRUTAGUARDADA")};this.e16341_client=function(){return this.clearMessages(),gx.fn.setCtrlProperty("TABLE6","Visible",!0),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TABLE6","Visible")',ctrl:"TABLE6",prop:"Visible"},{ctrl:"vOPDOC"},{av:"AV7opDoc",fld:"vOPDOC",pic:"9"}]),gx.$.Deferred().resolve()};this.e12342_client=function(){return this.executeServerEvent("'REGRESAR'",!0,null,!1,!1)};this.e13342_client=function(){return this.executeServerEvent("'GUARDAR'",!0,null,!1,!1)};this.e14342_client=function(){return this.executeServerEvent("'VISUALIZAR'",!0,null,!1,!1)};this.e17342_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e18342_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,21,23,26,29,30,31,33,36,39,42,45,48,51,54,57,60,62,66,67,68,69,70,71,72];this.GXLastCtrlId=72;this.UCALERTASContainer=gx.uc.getNew(this,73,31,"SweetAlert2","UCALERTASContainer","Ucalertas","UCALERTAS");i=this.UCALERTASContainer;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Width","Width","100","str");i.setProp("Height","Height","100","str");i.addV2CFunction("AV23AlertProperties","vALERTPROPERTIES","SetPropiedades");i.addC2VFunction(function(n){n.ParentObject.AV23AlertProperties=n.GetPropiedades();gx.fn.setControlValue("vALERTPROPERTIES",n.ParentObject.AV23AlertProperties)});i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);this.FILEUPLOAD1Container=gx.uc.getNew(this,65,31,"gx.uc.FileUpload","FILEUPLOAD1Container","Fileupload1","FILEUPLOAD1");t=this.FILEUPLOAD1Container;t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Class","Class","FileUpload","str");t.setProp("AutoUpload","Autoupload",!1,"bool");t.setProp("TooltipText","Tooltiptext","","str");t.setProp("EnableUploadedFileCanceling","Enableuploadedfilecanceling",!1,"bool");t.setProp("MaxFileSize","Maxfilesize",134217728,"num");t.setProp("MaxNumberOfFiles","Maxnumberoffiles",9,"num");t.setProp("AutoDisableAddingFiles","Autodisableaddingfiles",!1,"bool");t.setProp("AcceptedFileTypes","Acceptedfiletypes","custom","str");t.setProp("CustomFileTypes","Customfiletypes","PDF","str");t.addC2VFunction(function(n){n.ParentObject.AV6UploadedFiles=n.getFiles();gx.fn.setControlValue("vUPLOADEDFILES",n.ParentObject.AV6UploadedFiles)});t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLE3",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TEXTBLOCK2",format:0,grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TEXTBLOCK3",format:0,grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"TABLE1",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"TABLE2",grid:0};n[21]={id:21,fld:"TEXTBLOCK1",format:0,grid:0};n[23]={id:23,fld:"TEXTBLOCK4",format:0,grid:0};n[26]={id:26,fld:"TABLE5",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:"e16341_client",evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vOPDOC",gxz:"ZV7opDoc",gxold:"OV7opDoc",gxvar:"AV7opDoc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"radio",v2v:function(n){n!==undefined&&(gx.O.AV7opDoc=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV7opDoc=gx.num.intval(n))},v2c:function(){gx.fn.setRadioValue("vOPDOC",gx.O.AV7opDoc)},c2v:function(){this.val()!==undefined&&(gx.O.AV7opDoc=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vOPDOC",".")},nac:gx.falseFn};n[33]={id:33,fld:"TABLE4",grid:0};n[36]={id:36,fld:"IMAGE3",grid:0,evt:"e14342_client"};n[39]={id:39,fld:"IMAGE4",grid:0,evt:"e14342_client"};n[42]={id:42,fld:"IMAGE5",grid:0,evt:"e14342_client"};n[45]={id:45,fld:"IMAGE6",grid:0,evt:"e14342_client"};n[48]={id:48,fld:"IMAGE7",grid:0,evt:"e14342_client"};n[51]={id:51,fld:"IMAGE8",grid:0,evt:"e14342_client"};n[54]={id:54,fld:"IMAGE9",grid:0,evt:"e14342_client"};n[57]={id:57,fld:"IMAGE10",grid:0,evt:"e14342_client"};n[60]={id:60,fld:"IMAGE11",grid:0,evt:"e14342_client"};n[62]={id:62,fld:"TABLE6",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"IMAGE1",grid:0,evt:"e13342_client"};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"IMAGE2",grid:0,evt:"e12342_client"};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};this.AV7opDoc=0;this.ZV7opDoc=0;this.OV7opDoc=0;this.AV7opDoc=0;this.AV6UploadedFiles=[];this.AV23AlertProperties={title:"",titleText:"",html:"",text:"",icon:"",showCancelButton:!1,showConfirmButton:!1,confirmButtonColor:"",focusConfirm:!1,cancelButtonColor:"",confirmButtonText:"",confirmButtonUrl:"",cancelButtonText:"",showCloseButton:!1,allowOutsideClick:!1,footer:""};this.AV17UsuariosId=0;this.AV22Vacantes_Id=0;this.AV25Estatus_Filtro=0;this.A11UsuariosId=0;this.A263Vacantes_Id=0;this.A290VacantesUsuariosEstatus=0;this.A291VacantesUsuariosPrefiltro=0;this.A292VacantesUsuariosCV=0;this.A293VacantesUsuariosExTec=0;this.A304VacantesUsuariosAvConf=0;this.A303VacantesUsuariosAvPriv=0;this.A302VacantesUsuariosBusWeb=0;this.A300VacantesUsuariosRefLab=0;this.A301VacantesUsuariosExPsi=0;this.A299VacantesUsuariosCVRec=0;this.A105UsuariosCurp="";this.A29ParametroId=0;this.A129ParametroValor="";this.AV9archivo="";this.AV11ruta="";this.AV21VarDoc="";this.AV19UsuariosCurp="";this.AV20RutaGuardada="";this.Events={e12342_client:["'REGRESAR'",!0],e13342_client:["'GUARDAR'",!0],e14342_client:["'VISUALIZAR'",!0],e17342_client:["ENTER",!0],e18342_client:["CANCEL",!0],e16341_client:["VOPDOC.ISVALID",!1]};this.EvtParms.REFRESH=[[{av:"AV22Vacantes_Id",fld:"vVACANTES_ID",pic:"ZZZZZZZZ9",hsh:!0},{av:"AV17UsuariosId",fld:"vUSUARIOSID",pic:"ZZZZZ9",hsh:!0},{av:"AV25Estatus_Filtro",fld:"vESTATUS_FILTRO",pic:"ZZZ9",hsh:!0},{av:"AV11ruta",fld:"vRUTA",pic:"",hsh:!0},{av:"AV19UsuariosCurp",fld:"vUSUARIOSCURP",pic:"@!",hsh:!0},{ctrl:"vOPDOC"},{av:"AV7opDoc",fld:"vOPDOC",pic:"9"}],[{ctrl:"vOPDOC"},{av:"AV7opDoc",fld:"vOPDOC",pic:"9"}]];this.EvtParms.START=[[{av:"A29ParametroId",fld:"PARAMETROID",pic:"ZZZZZZZZ9"},{av:"A129ParametroValor",fld:"PARAMETROVALOR",pic:""},{av:"A11UsuariosId",fld:"USUARIOSID",pic:"ZZZZZ9"},{av:"AV17UsuariosId",fld:"vUSUARIOSID",pic:"ZZZZZ9",hsh:!0},{av:"A105UsuariosCurp",fld:"USUARIOSCURP",pic:"@!"},{av:"AV25Estatus_Filtro",fld:"vESTATUS_FILTRO",pic:"ZZZ9",hsh:!0},{av:"AV22Vacantes_Id",fld:"vVACANTES_ID",pic:"ZZZZZZZZ9",hsh:!0},{av:"A263Vacantes_Id",fld:"VACANTES_ID",pic:"ZZZZZZZZ9"},{av:"A290VacantesUsuariosEstatus",fld:"VACANTESUSUARIOSESTATUS",pic:"ZZZ9"},{av:"A291VacantesUsuariosPrefiltro",fld:"VACANTESUSUARIOSPREFILTRO",pic:"ZZZ9"},{av:"A292VacantesUsuariosCV",fld:"VACANTESUSUARIOSCV",pic:"ZZZ9"},{av:"A293VacantesUsuariosExTec",fld:"VACANTESUSUARIOSEXTEC",pic:"ZZZ9"},{av:"A304VacantesUsuariosAvConf",fld:"VACANTESUSUARIOSAVCONF",pic:"ZZZ9"},{av:"A303VacantesUsuariosAvPriv",fld:"VACANTESUSUARIOSAVPRIV",pic:"ZZZ9"},{av:"A302VacantesUsuariosBusWeb",fld:"VACANTESUSUARIOSBUSWEB",pic:"ZZZ9"},{av:"A300VacantesUsuariosRefLab",fld:"VACANTESUSUARIOSREFLAB",pic:"ZZZ9"},{av:"A301VacantesUsuariosExPsi",fld:"VACANTESUSUARIOSEXPSI",pic:"ZZZ9"},{av:"A299VacantesUsuariosCVRec",fld:"VACANTESUSUARIOSCVREC",pic:"ZZZ9"},{ctrl:"vOPDOC"},{av:"AV7opDoc",fld:"vOPDOC",pic:"9"}],[{av:'gx.fn.getCtrlProperty("TABLE6","Visible")',ctrl:"TABLE6",prop:"Visible"},{av:'gx.fn.getCtrlProperty("TEXTBLOCK1","Visible")',ctrl:"TEXTBLOCK1",prop:"Visible"},{av:"AV11ruta",fld:"vRUTA",pic:"",hsh:!0},{av:"AV19UsuariosCurp",fld:"vUSUARIOSCURP",pic:"@!",hsh:!0},{av:'gx.fn.getCtrlProperty("IMAGE3","Visible")',ctrl:"IMAGE3",prop:"Visible"},{av:'gx.fn.getCtrlProperty("IMAGE4","Visible")',ctrl:"IMAGE4",prop:"Visible"},{av:'gx.fn.getCtrlProperty("IMAGE5","Visible")',ctrl:"IMAGE5",prop:"Visible"},{av:'gx.fn.getCtrlProperty("IMAGE6","Visible")',ctrl:"IMAGE6",prop:"Visible"},{av:'gx.fn.getCtrlProperty("IMAGE7","Visible")',ctrl:"IMAGE7",prop:"Visible"},{av:'gx.fn.getCtrlProperty("IMAGE8","Visible")',ctrl:"IMAGE8",prop:"Visible"},{av:'gx.fn.getCtrlProperty("IMAGE9","Visible")',ctrl:"IMAGE9",prop:"Visible"},{av:'gx.fn.getCtrlProperty("IMAGE10","Visible")',ctrl:"IMAGE10",prop:"Visible"},{av:'gx.fn.getCtrlProperty("IMAGE11","Visible")',ctrl:"IMAGE11",prop:"Visible"},{ctrl:"vOPDOC"},{av:"AV7opDoc",fld:"vOPDOC",pic:"9"}]];this.EvtParms["'REGRESAR'"]=[[{ctrl:"vOPDOC"},{av:"AV7opDoc",fld:"vOPDOC",pic:"9"}],[{ctrl:"vOPDOC"},{av:"AV7opDoc",fld:"vOPDOC",pic:"9"}]];this.EvtParms["'GUARDAR'"]=[[{av:"AV9archivo",fld:"vARCHIVO",pic:""},{av:"AV22Vacantes_Id",fld:"vVACANTES_ID",pic:"ZZZZZZZZ9",hsh:!0},{av:"AV17UsuariosId",fld:"vUSUARIOSID",pic:"ZZZZZ9",hsh:!0},{av:"AV25Estatus_Filtro",fld:"vESTATUS_FILTRO",pic:"ZZZ9",hsh:!0},{av:"AV6UploadedFiles",fld:"vUPLOADEDFILES",pic:""},{av:"AV11ruta",fld:"vRUTA",pic:"",hsh:!0},{av:"AV21VarDoc",fld:"vVARDOC",pic:""},{av:"AV19UsuariosCurp",fld:"vUSUARIOSCURP",pic:"@!",hsh:!0},{ctrl:"vOPDOC"},{av:"AV7opDoc",fld:"vOPDOC",pic:"9"}],[{av:"AV23AlertProperties",fld:"vALERTPROPERTIES",pic:""},{av:"AV21VarDoc",fld:"vVARDOC",pic:""},{av:"AV9archivo",fld:"vARCHIVO",pic:""},{ctrl:"vOPDOC"},{av:"AV7opDoc",fld:"vOPDOC",pic:"9"}]];this.EvtParms["'VISUALIZAR'"]=[[{av:"AV22Vacantes_Id",fld:"vVACANTES_ID",pic:"ZZZZZZZZ9",hsh:!0},{av:"AV17UsuariosId",fld:"vUSUARIOSID",pic:"ZZZZZ9",hsh:!0},{av:"AV20RutaGuardada",fld:"vRUTAGUARDADA",pic:""},{ctrl:"vOPDOC"},{av:"AV7opDoc",fld:"vOPDOC",pic:"9"}],[{av:"AV23AlertProperties",fld:"vALERTPROPERTIES",pic:""},{av:"AV20RutaGuardada",fld:"vRUTAGUARDADA",pic:""},{ctrl:"vOPDOC"},{av:"AV7opDoc",fld:"vOPDOC",pic:"9"}]];this.EvtParms["VOPDOC.ISVALID"]=[[{ctrl:"vOPDOC"},{av:"AV7opDoc",fld:"vOPDOC",pic:"9"}],[{av:'gx.fn.getCtrlProperty("TABLE6","Visible")',ctrl:"TABLE6",prop:"Visible"},{ctrl:"vOPDOC"},{av:"AV7opDoc",fld:"vOPDOC",pic:"9"}]];this.setVCMap("AV9archivo","vARCHIVO",0,"svchar",250,0);this.setVCMap("AV22Vacantes_Id","vVACANTES_ID",0,"int",9,0);this.setVCMap("AV17UsuariosId","vUSUARIOSID",0,"int",6,0);this.setVCMap("AV25Estatus_Filtro","vESTATUS_FILTRO",0,"int",4,0);this.setVCMap("AV6UploadedFiles","vUPLOADEDFILES",0,"CollFileUploadData",0,0);this.setVCMap("AV11ruta","vRUTA",0,"svchar",250,0);this.setVCMap("AV21VarDoc","vVARDOC",0,"char",15,0);this.setVCMap("AV19UsuariosCurp","vUSUARIOSCURP",0,"svchar",18,0);this.setVCMap("AV20RutaGuardada","vRUTAGUARDADA",0,"svchar",40,0);this.Initialize()});gx.wi(function(){gx.createParentObj(popcargdocu)})