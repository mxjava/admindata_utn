gx.evt.autoSkip=!1;gx.define("wpinfge",!1,function(){var n,i,t;this.ServerClass="wpinfge";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV36UploadedFiles=gx.fn.getControlValue("vUPLOADEDFILES");this.AV28UsuarioAlta=gx.fn.getControlValue("vUSUARIOALTA");this.AV55Image_GXI=gx.fn.getControlValue("vIMAGE_GXI");this.AV27UsuarioId=gx.fn.getIntegerValue("vUSUARIOID",".")};this.e122j2_client=function(){return this.executeServerEvent("'ACTUALIZAR'",!0,null,!1,!1)};this.e142j2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e152j2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,18,19,20,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,87,88];this.GXLastCtrlId=88;this.UCALERTASContainer=gx.uc.getNew(this,89,20,"SweetAlert2","UCALERTASContainer","Ucalertas","UCALERTAS");i=this.UCALERTASContainer;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Width","Width","100","str");i.setProp("Height","Height","100","str");i.addV2CFunction("AV39AlertProperties","vALERTPROPERTIES","SetPropiedades");i.addC2VFunction(function(n){n.ParentObject.AV39AlertProperties=n.GetPropiedades();gx.fn.setControlValue("vALERTPROPERTIES",n.ParentObject.AV39AlertProperties)});i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);this.FILEUPLOAD1Container=gx.uc.getNew(this,23,20,"gx.uc.FileUpload","FILEUPLOAD1Container","Fileupload1","FILEUPLOAD1");t=this.FILEUPLOAD1Container;t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Class","Class","FileUpload","str");t.setProp("AutoUpload","Autoupload",!1,"bool");t.setProp("TooltipText","Tooltiptext","","str");t.setProp("EnableUploadedFileCanceling","Enableuploadedfilecanceling",!1,"bool");t.setProp("MaxFileSize","Maxfilesize",134217728,"num");t.setProp("MaxNumberOfFiles","Maxnumberoffiles",1,"num");t.setProp("AutoDisableAddingFiles","Autodisableaddingfiles",!1,"bool");t.setProp("AcceptedFileTypes","Acceptedfiletypes","image","str");t.setProp("CustomFileTypes","Customfiletypes","","char");t.addC2VFunction(function(n){n.ParentObject.AV36UploadedFiles=n.getFiles();gx.fn.setControlValue("vUPLOADEDFILES",n.ParentObject.AV36UploadedFiles)});t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLE1",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TEXTBLOCK1",format:0,grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"TABLE3",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,lvl:0,type:"bits",len:1024,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vVARIMAGEN",gxz:"ZV30VarImagen",gxold:"OV30VarImagen",gxvar:"AV30VarImagen",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV30VarImagen=n)},v2z:function(n){n!==undefined&&(gx.O.ZV30VarImagen=n)},v2c:function(){gx.fn.setMultimediaValue("vVARIMAGEN",gx.O.AV30VarImagen,gx.O.AV52Varimagen_GXI)},c2v:function(){gx.O.AV52Varimagen_GXI=this.val_GXI();this.val()!==undefined&&(gx.O.AV30VarImagen=this.val())},val:function(){return gx.fn.getBlobValue("vVARIMAGEN")},val_GXI:function(){return gx.fn.getControlValue("vVARIMAGEN_GXI")},gxvar_GXI:"AV52Varimagen_GXI",nac:gx.falseFn};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"TABLE2",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,lvl:0,type:"svchar",len:40,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLUSUARIOSNOMBRE",gxz:"ZV43GXV1",gxold:"OV43GXV1",gxvar:"GXV1",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.GXV1=n)},v2z:function(n){n!==undefined&&(gx.O.ZV43GXV1=n)},v2c:function(){gx.fn.setControlValue("CTLUSUARIOSNOMBRE",gx.O.GXV1,0)},c2v:function(){this.val()!==undefined&&(gx.O.GXV1=this.val())},val:function(){return gx.fn.getControlValue("CTLUSUARIOSNOMBRE")},nac:gx.falseFn};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"svchar",len:40,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLUSUARIOSAPPAT",gxz:"ZV44GXV2",gxold:"OV44GXV2",gxvar:"GXV2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.GXV2=n)},v2z:function(n){n!==undefined&&(gx.O.ZV44GXV2=n)},v2c:function(){gx.fn.setControlValue("CTLUSUARIOSAPPAT",gx.O.GXV2,0)},c2v:function(){this.val()!==undefined&&(gx.O.GXV2=this.val())},val:function(){return gx.fn.getControlValue("CTLUSUARIOSAPPAT")},nac:gx.falseFn};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,lvl:0,type:"svchar",len:40,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLUSUARIOSAPMAT",gxz:"ZV45GXV3",gxold:"OV45GXV3",gxvar:"GXV3",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.GXV3=n)},v2z:function(n){n!==undefined&&(gx.O.ZV45GXV3=n)},v2c:function(){gx.fn.setControlValue("CTLUSUARIOSAPMAT",gx.O.GXV3,0)},c2v:function(){this.val()!==undefined&&(gx.O.GXV3=this.val())},val:function(){return gx.fn.getControlValue("CTLUSUARIOSAPMAT")},nac:gx.falseFn};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLUSUARIOSFECNACIMIENTO",gxz:"ZV46GXV4",gxold:"OV46GXV4",gxvar:"GXV4",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.GXV4=gx.fn.toDatetimeValue(n,"Y4MD"))},v2z:function(n){n!==undefined&&(gx.O.ZV46GXV4=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("CTLUSUARIOSFECNACIMIENTO",gx.O.GXV4,0)},c2v:function(){this.val()!==undefined&&(gx.O.GXV4=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("CTLUSUARIOSFECNACIMIENTO")},nac:gx.falseFn};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLUSUARIOSEDAD",gxz:"ZV47GXV5",gxold:"OV47GXV5",gxvar:"GXV5",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.GXV5=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV47GXV5=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CTLUSUARIOSEDAD",gx.O.GXV5,0)},c2v:function(){this.val()!==undefined&&(gx.O.GXV5=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CTLUSUARIOSEDAD",".")},nac:gx.falseFn};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,lvl:0,type:"char",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLUSUARIOSSEXOFOR",gxz:"ZV48GXV6",gxold:"OV48GXV6",gxvar:"GXV6",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.GXV6=n)},v2z:function(n){n!==undefined&&(gx.O.ZV48GXV6=n)},v2c:function(){gx.fn.setControlValue("CTLUSUARIOSSEXOFOR",gx.O.GXV6,0)},c2v:function(){this.val()!==undefined&&(gx.O.GXV6=this.val())},val:function(){return gx.fn.getControlValue("CTLUSUARIOSSEXOFOR")},nac:gx.falseFn};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,lvl:0,type:"char",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLUSUARIOSTELEF",gxz:"ZV49GXV7",gxold:"OV49GXV7",gxvar:"GXV7",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.GXV7=n)},v2z:function(n){n!==undefined&&(gx.O.ZV49GXV7=n)},v2c:function(){gx.fn.setControlValue("CTLUSUARIOSTELEF",gx.O.GXV7,0)},c2v:function(){this.val()!==undefined&&(gx.O.GXV7=this.val())},val:function(){return gx.fn.getControlValue("CTLUSUARIOSTELEF")},nac:gx.falseFn};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"",grid:0};n[60]={id:60,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLUSUARIOSCORREO",gxz:"ZV50GXV8",gxold:"OV50GXV8",gxvar:"GXV8",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.GXV8=n)},v2z:function(n){n!==undefined&&(gx.O.ZV50GXV8=n)},v2c:function(){gx.fn.setControlValue("CTLUSUARIOSCORREO",gx.O.GXV8,0)},c2v:function(){this.val()!==undefined&&(gx.O.GXV8=this.val())},val:function(){return gx.fn.getControlValue("CTLUSUARIOSCORREO")},nac:gx.falseFn};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,lvl:0,type:"svchar",len:18,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLUSUARIOSCURP",gxz:"ZV51GXV9",gxold:"OV51GXV9",gxvar:"GXV9",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.GXV9=n)},v2z:function(n){n!==undefined&&(gx.O.ZV51GXV9=n)},v2c:function(){gx.fn.setControlValue("CTLUSUARIOSCURP",gx.O.GXV9,0)},c2v:function(){this.val()!==undefined&&(gx.O.GXV9=this.val())},val:function(){return gx.fn.getControlValue("CTLUSUARIOSCURP")},nac:gx.falseFn};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,lvl:0,type:"int",len:9,dec:0,sign:!1,pic:"ZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSELECPERFIL",gxz:"ZV38SelecPerfil",gxold:"OV38SelecPerfil",gxvar:"AV38SelecPerfil",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"dyncombo",v2v:function(n){n!==undefined&&(gx.O.AV38SelecPerfil=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV38SelecPerfil=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("vSELECPERFIL",gx.O.AV38SelecPerfil)},c2v:function(){this.val()!==undefined&&(gx.O.AV38SelecPerfil=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vSELECPERFIL",".")},nac:gx.falseFn};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"",grid:0};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"TEXTBLOCK4",format:0,grid:0};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,fld:"IMAGE3",grid:0,evt:"e122j2_client"};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[84]={id:84,fld:"",grid:0};n[85]={id:85,fld:"",grid:0};n[87]={id:87,fld:"",grid:0};n[88]={id:88,fld:"",grid:0};this.AV52Varimagen_GXI="";this.AV30VarImagen="";this.ZV30VarImagen="";this.OV30VarImagen="";this.GXV1="";this.ZV43GXV1="";this.OV43GXV1="";this.GXV2="";this.ZV44GXV2="";this.OV44GXV2="";this.GXV3="";this.ZV45GXV3="";this.OV45GXV3="";this.GXV4=gx.date.nullDate();this.ZV46GXV4=gx.date.nullDate();this.OV46GXV4=gx.date.nullDate();this.GXV5=0;this.ZV47GXV5=0;this.OV47GXV5=0;this.GXV6="";this.ZV48GXV6="";this.OV48GXV6="";this.GXV7="";this.ZV49GXV7="";this.OV49GXV7="";this.GXV8="";this.ZV50GXV8="";this.OV50GXV8="";this.GXV9="";this.ZV51GXV9="";this.OV51GXV9="";this.AV38SelecPerfil=0;this.ZV38SelecPerfil=0;this.OV38SelecPerfil=0;this.AV30VarImagen="";this.AV36UploadedFiles=[];this.GXV1="";this.GXV2="";this.GXV3="";this.GXV4=gx.date.nullDate();this.GXV5=0;this.GXV6="";this.GXV7="";this.GXV8="";this.GXV9="";this.AV38SelecPerfil=0;this.AV39AlertProperties={title:"",titleText:"",html:"",text:"",icon:"",showCancelButton:!1,showConfirmButton:!1,confirmButtonColor:"",focusConfirm:!1,cancelButtonColor:"",confirmButtonText:"",confirmButtonUrl:"",cancelButtonText:"",showCloseButton:!1,allowOutsideClick:!1,footer:""};this.A283PerfilesUsuariosEstatus=0;this.A11UsuariosId=0;this.A278Perfiles_Id=0;this.AV28UsuarioAlta={UsuariosId:0,UsuariosCurp:"",UsuariosNombre:"",UsuariosApPat:"",UsuariosApMat:"",UsuariosUsr:"",UsuariosTipo:0,UsuariosIcono:"",UsuariosIcono_GXI:"",UsuariosFecNacimiento:gx.date.nullDate(),UsuariosEdad:0,UsuariosSexo:"",UsuariosPwd:"",UsuariosKey:"",UsuariosVigIni:gx.date.nullDate(),UsuariosVigFin:gx.date.nullDate(),UsuariosFecCap:gx.date.nullDate(),UsuariosIP:"",UsuariosTelef:"",UsuariosCorreo:"",UsuariosNomCompleto:"",RolId:0,RolNombre:"",UsuariosSexoFor:"",UsuariosStatus:0,Mode:"",Initialized:0,UsuariosId_Z:0,UsuariosCurp_Z:"",UsuariosNombre_Z:"",UsuariosApPat_Z:"",UsuariosApMat_Z:"",UsuariosUsr_Z:"",UsuariosTipo_Z:0,UsuariosIcono_Z:"",UsuariosFecNacimiento_Z:gx.date.nullDate(),UsuariosEdad_Z:0,UsuariosSexo_Z:"",UsuariosPwd_Z:"",UsuariosKey_Z:"",UsuariosVigIni_Z:gx.date.nullDate(),UsuariosVigFin_Z:gx.date.nullDate(),UsuariosFecCap_Z:gx.date.nullDate(),UsuariosIP_Z:"",UsuariosTelef_Z:"",UsuariosCorreo_Z:"",UsuariosNomCompleto_Z:"",RolId_Z:0,RolNombre_Z:"",UsuariosSexoFor_Z:"",UsuariosStatus_Z:0,UsuariosIcono_GXI_Z:""};this.AV55Image_GXI="";this.AV27UsuarioId=0;this.Events={e122j2_client:["'ACTUALIZAR'",!0],e142j2_client:["ENTER",!0],e152j2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV27UsuarioId",fld:"vUSUARIOID",pic:"ZZZZZZZZ9",hsh:!0},{ctrl:"vSELECPERFIL"},{av:"AV38SelecPerfil",fld:"vSELECPERFIL",pic:"ZZZZZZZZ9"}],[{ctrl:"vSELECPERFIL"},{av:"AV38SelecPerfil",fld:"vSELECPERFIL",pic:"ZZZZZZZZ9"}]];this.EvtParms.START=[[{av:"A11UsuariosId",fld:"USUARIOSID",pic:"ZZZZZ9"},{av:"A283PerfilesUsuariosEstatus",fld:"PERFILESUSUARIOSESTATUS",pic:"9"},{av:"A278Perfiles_Id",fld:"PERFILES_ID",pic:"ZZZZZZZZ9"},{ctrl:"vSELECPERFIL"},{av:"AV38SelecPerfil",fld:"vSELECPERFIL",pic:"ZZZZZZZZ9"}],[{av:"AV27UsuarioId",fld:"vUSUARIOID",pic:"ZZZZZZZZ9",hsh:!0},{av:"AV28UsuarioAlta",fld:"vUSUARIOALTA",pic:""},{av:"AV30VarImagen",fld:"vVARIMAGEN",pic:""},{ctrl:"COMPONENT1",prop:"Visible"},{ctrl:"COMPONENT1"},{ctrl:"vSELECPERFIL"},{av:"AV38SelecPerfil",fld:"vSELECPERFIL",pic:"ZZZZZZZZ9"}]];this.EvtParms["'ACTUALIZAR'"]=[[{av:"AV36UploadedFiles",fld:"vUPLOADEDFILES",pic:""},{av:"AV28UsuarioAlta",fld:"vUSUARIOALTA",pic:""},{av:"AV55Image_GXI",fld:"vIMAGE_GXI",pic:""},{av:"AV27UsuarioId",fld:"vUSUARIOID",pic:"ZZZZZZZZ9",hsh:!0},{ctrl:"vSELECPERFIL"},{av:"AV38SelecPerfil",fld:"vSELECPERFIL",pic:"ZZZZZZZZ9"}],[{av:"AV28UsuarioAlta",fld:"vUSUARIOALTA",pic:""},{av:"AV39AlertProperties",fld:"vALERTPROPERTIES",pic:""},{ctrl:"vSELECPERFIL"},{av:"AV38SelecPerfil",fld:"vSELECPERFIL",pic:"ZZZZZZZZ9"}]];this.setVCMap("AV36UploadedFiles","vUPLOADEDFILES",0,"CollFileUploadData",0,0);this.setVCMap("AV28UsuarioAlta","vUSUARIOALTA",0,"Usuarios",0,0);this.setVCMap("AV55Image_GXI","vIMAGE_GXI",0,"svchar",2048,0);this.setVCMap("AV27UsuarioId","vUSUARIOID",0,"int",9,0);this.addBCProperty("Usuarioalta",["UsuariosNombre"],this.GXValidFnc[30],"AV28UsuarioAlta");this.addBCProperty("Usuarioalta",["UsuariosApPat"],this.GXValidFnc[34],"AV28UsuarioAlta");this.addBCProperty("Usuarioalta",["UsuariosApMat"],this.GXValidFnc[38],"AV28UsuarioAlta");this.addBCProperty("Usuarioalta",["UsuariosFecNacimiento"],this.GXValidFnc[43],"AV28UsuarioAlta");this.addBCProperty("Usuarioalta",["UsuariosEdad"],this.GXValidFnc[47],"AV28UsuarioAlta");this.addBCProperty("Usuarioalta",["UsuariosSexoFor"],this.GXValidFnc[51],"AV28UsuarioAlta");this.addBCProperty("Usuarioalta",["UsuariosTelef"],this.GXValidFnc[56],"AV28UsuarioAlta");this.addBCProperty("Usuarioalta",["UsuariosCorreo"],this.GXValidFnc[60],"AV28UsuarioAlta");this.addBCProperty("Usuarioalta",["UsuariosCurp"],this.GXValidFnc[64],"AV28UsuarioAlta");this.Initialize();this.setComponent({id:"COMPONENT1",GXClass:null,Prefix:"W0086",lvl:1})});gx.wi(function(){gx.createParentObj(wpinfge)})