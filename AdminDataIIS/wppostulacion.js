gx.evt.autoSkip=!1;gx.define("wppostulacion",!1,function(){var t,n,i;this.ServerClass="wppostulacion";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A66UsuariosNombre=gx.fn.getControlValue("USUARIOSNOMBRE");this.A65UsuariosApPat=gx.fn.getControlValue("USUARIOSAPPAT");this.A64UsuariosApMat=gx.fn.getControlValue("USUARIOSAPMAT");this.A97UsuariosNomCompleto=gx.fn.getControlValue("USUARIOSNOMCOMPLETO");this.A272UsuariosTipo=gx.fn.getIntegerValue("USUARIOSTIPO",".");this.A286UsuariosStatus=gx.fn.getIntegerValue("USUARIOSSTATUS",".");this.A260UsuariosTelef=gx.fn.getControlValue("USUARIOSTELEF");this.A261UsuariosCorreo=gx.fn.getControlValue("USUARIOSCORREO");this.A11UsuariosId=gx.fn.getIntegerValue("USUARIOSID",".");this.A283PerfilesUsuariosEstatus=gx.fn.getIntegerValue("PERFILESUSUARIOSESTATUS",".");this.A278Perfiles_Id=gx.fn.getIntegerValue("PERFILES_ID",".");this.A286UsuariosStatus=gx.fn.getIntegerValue("USUARIOSSTATUS",".");this.A272UsuariosTipo=gx.fn.getIntegerValue("USUARIOSTIPO",".");this.A11UsuariosId=gx.fn.getIntegerValue("USUARIOSID",".");this.A260UsuariosTelef=gx.fn.getControlValue("USUARIOSTELEF");this.A261UsuariosCorreo=gx.fn.getControlValue("USUARIOSCORREO");this.A283PerfilesUsuariosEstatus=gx.fn.getIntegerValue("PERFILESUSUARIOSESTATUS",".");this.A278Perfiles_Id=gx.fn.getIntegerValue("PERFILES_ID",".")};this.Validv_Usuariosid=function(){var n=gx.fn.currentGridRowImpl(19);return this.validCliEvt("Validv_Usuariosid",19,function(){try{var n=gx.util.balloon.getNew("vUSUARIOSID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Usuarioscorreo=function(){var n=gx.fn.currentGridRowImpl(19);return this.validCliEvt("Validv_Usuarioscorreo",19,function(){try{var n=gx.util.balloon.getNew("vUSUARIOSCORREO");if(this.AnyError=0,n.setAsFormatError(),!gx.util.regExp.isMatch(this.AV11UsuariosCorreo,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$"))try{n.setError("El valor de Correo electrónico no coincide con el patrón especificado");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e132a2_client=function(){return this.executeServerEvent("'ASIGNAR'",!0,arguments[0],!1,!1)};this.e152a2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e162a2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,17,18,20,21,22,23,24,25,26,27,28,29];this.GXLastCtrlId=29;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",19,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"wppostulacion",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);n=this.Grid1Container;n.addBitmap("&Vacantes_nombre","vVACANTES_NOMBRE",20,0,"px",17,"px",null,"","","Image","WWColumn");n.addSingleLineEdit("Usuariosid",21,"vUSUARIOSID","ID","","usuariosid","int",0,"px",6,6,"right",null,[],"Usuariosid","usuariosid",!1,0,!1,!1,"Attribute",1,"");n.addSingleLineEdit("Nombrecompleto",22,"vNOMBRECOMPLETO","Nombre Completo","","NombreCompleto","svchar",0,"px",40,40,"left",null,[],"Nombrecompleto","NombreCompleto",!0,0,!1,!1,"Attribute",1,"WWColumn");n.addSingleLineEdit("Usuariostelef",23,"vUSUARIOSTELEF","Teléfono","","UsuariosTelef","char",0,"px",10,10,"left",null,[],"Usuariostelef","UsuariosTelef",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");n.addSingleLineEdit("Usuarioscorreo",24,"vUSUARIOSCORREO","Correo electrónico","","UsuariosCorreo","svchar",0,"px",100,80,"left",null,[],"Usuarioscorreo","UsuariosCorreo",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");n.addComboBox("Perfiles_id",25,"vPERFILES_ID","Perfil","Perfiles_Id","int",null,1,!0,!1,0,"px","WWColumn WWOptionalColumn");n.addComboBox("Usuarioidrec",26,"vUSUARIOIDREC","Reclutador","usuarioidRec","int",null,1,!0,!1,0,"px","WWColumn");n.addSingleLineEdit("Asignar",27,"vASIGNAR","","","Asignar","char",0,"px",20,20,"left","e132a2_client",[],"Asignar","Asignar",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");this.Grid1Container.emptyText="";this.setGrid(n);this.UCALERTASContainer=gx.uc.getNew(this,30,13,"SweetAlert2","UCALERTASContainer","Ucalertas","UCALERTAS");i=this.UCALERTASContainer;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Width","Width","100","str");i.setProp("Height","Height","100","str");i.addV2CFunction("AV24AlertProperties","vALERTPROPERTIES","SetPropiedades");i.addC2VFunction(function(n){n.ParentObject.AV24AlertProperties=n.GetPropiedades();gx.fn.setControlValue("vALERTPROPERTIES",n.ParentObject.AV24AlertProperties)});i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLE1",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TITLETEXT",format:0,grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,lvl:0,gxsgprm:["vNOMCOMPLETO",[],[],!1,[]],type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNOMCOMPLETO",gxz:"ZV15NomCompleto",gxold:"OV15NomCompleto",gxvar:"AV15NomCompleto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV15NomCompleto=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15NomCompleto=n)},v2c:function(){gx.fn.setControlValue("vNOMCOMPLETO",gx.O.AV15NomCompleto,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV15NomCompleto=this.val())},val:function(){return gx.fn.getControlValue("vNOMCOMPLETO")},nac:gx.falseFn};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[20]={id:20,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:19,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vVACANTES_NOMBRE",gxz:"ZV13vacantes_nombre",gxold:"OV13vacantes_nombre",gxvar:"AV13vacantes_nombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV13vacantes_nombre=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13vacantes_nombre=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vVACANTES_NOMBRE",n||gx.fn.currentGridRowImpl(19),gx.O.AV13vacantes_nombre,gx.O.AV30Vacantes_nombre_GXI)},c2v:function(n){gx.O.AV30Vacantes_nombre_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV13vacantes_nombre=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vVACANTES_NOMBRE",n||gx.fn.currentGridRowImpl(19))},val_GXI:function(n){return gx.fn.getGridControlValue("vVACANTES_NOMBRE_GXI",n||gx.fn.currentGridRowImpl(19))},gxvar_GXI:"AV30Vacantes_nombre_GXI",nac:gx.falseFn};t[21]={id:21,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,isacc:0,grid:19,gxgrid:this.Grid1Container,fnc:this.Validv_Usuariosid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSUARIOSID",gxz:"ZV14usuariosid",gxold:"OV14usuariosid",gxvar:"AV14usuariosid",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.AV14usuariosid=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV14usuariosid=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vUSUARIOSID",n||gx.fn.currentGridRowImpl(19),gx.O.AV14usuariosid,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV14usuariosid=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vUSUARIOSID",n||gx.fn.currentGridRowImpl(19),".")},nac:gx.falseFn};t[22]={id:22,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:19,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNOMBRECOMPLETO",gxz:"ZV5NombreCompleto",gxold:"OV5NombreCompleto",gxvar:"AV5NombreCompleto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV5NombreCompleto=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5NombreCompleto=n)},v2c:function(n){gx.fn.setGridControlValue("vNOMBRECOMPLETO",n||gx.fn.currentGridRowImpl(19),gx.O.AV5NombreCompleto,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV5NombreCompleto=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNOMBRECOMPLETO",n||gx.fn.currentGridRowImpl(19))},nac:gx.falseFn};t[23]={id:23,lvl:2,type:"char",len:10,dec:0,sign:!1,ro:0,isacc:0,grid:19,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSUARIOSTELEF",gxz:"ZV10UsuariosTelef",gxold:"OV10UsuariosTelef",gxvar:"AV10UsuariosTelef",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV10UsuariosTelef=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10UsuariosTelef=n)},v2c:function(n){gx.fn.setGridControlValue("vUSUARIOSTELEF",n||gx.fn.currentGridRowImpl(19),gx.O.AV10UsuariosTelef,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV10UsuariosTelef=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUSUARIOSTELEF",n||gx.fn.currentGridRowImpl(19))},nac:gx.falseFn};t[24]={id:24,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:0,isacc:0,grid:19,gxgrid:this.Grid1Container,fnc:this.Validv_Usuarioscorreo,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSUARIOSCORREO",gxz:"ZV11UsuariosCorreo",gxold:"OV11UsuariosCorreo",gxvar:"AV11UsuariosCorreo",ucs:[],op:[],ip:[24],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV11UsuariosCorreo=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11UsuariosCorreo=n)},v2c:function(n){gx.fn.setGridControlValue("vUSUARIOSCORREO",n||gx.fn.currentGridRowImpl(19),gx.O.AV11UsuariosCorreo,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV11UsuariosCorreo=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUSUARIOSCORREO",n||gx.fn.currentGridRowImpl(19))},nac:gx.falseFn};t[25]={id:25,lvl:2,type:"int",len:9,dec:0,sign:!1,pic:"ZZZZZZZZ9",ro:0,isacc:0,grid:19,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPERFILES_ID",gxz:"ZV20Perfiles_Id",gxold:"OV20Perfiles_Id",gxvar:"AV20Perfiles_Id",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"dyncombo",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.AV20Perfiles_Id=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV20Perfiles_Id=gx.num.intval(n))},v2c:function(n){gx.fn.setGridComboBoxValue("vPERFILES_ID",n||gx.fn.currentGridRowImpl(19),gx.O.AV20Perfiles_Id)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV20Perfiles_Id=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vPERFILES_ID",n||gx.fn.currentGridRowImpl(19),".")},nac:gx.falseFn};t[26]={id:26,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,isacc:0,grid:19,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSUARIOIDREC",gxz:"ZV21usuarioidRec",gxold:"OV21usuarioidRec",gxvar:"AV21usuarioidRec",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.AV21usuarioidRec=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV21usuarioidRec=gx.num.intval(n))},v2c:function(n){gx.fn.setGridComboBoxValue("vUSUARIOIDREC",n||gx.fn.currentGridRowImpl(19),gx.O.AV21usuarioidRec)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV21usuarioidRec=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vUSUARIOIDREC",n||gx.fn.currentGridRowImpl(19),".")},nac:gx.falseFn};t[27]={id:27,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:19,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vASIGNAR",gxz:"ZV23Asignar",gxold:"OV23Asignar",gxvar:"AV23Asignar",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV23Asignar=n)},v2z:function(n){n!==undefined&&(gx.O.ZV23Asignar=n)},v2c:function(n){gx.fn.setGridControlValue("vASIGNAR",n||gx.fn.currentGridRowImpl(19),gx.O.AV23Asignar,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV23Asignar=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vASIGNAR",n||gx.fn.currentGridRowImpl(19))},nac:gx.falseFn,evt:"e132a2_client"};t[28]={id:28,fld:"",grid:0};t[29]={id:29,fld:"",grid:0};this.AV15NomCompleto="";this.ZV15NomCompleto="";this.OV15NomCompleto="";this.ZV13vacantes_nombre="";this.OV13vacantes_nombre="";this.ZV14usuariosid=0;this.OV14usuariosid=0;this.ZV5NombreCompleto="";this.OV5NombreCompleto="";this.ZV10UsuariosTelef="";this.OV10UsuariosTelef="";this.ZV11UsuariosCorreo="";this.OV11UsuariosCorreo="";this.ZV20Perfiles_Id=0;this.OV20Perfiles_Id=0;this.ZV21usuarioidRec=0;this.OV21usuarioidRec=0;this.ZV23Asignar="";this.OV23Asignar="";this.AV15NomCompleto="";this.AV24AlertProperties={title:"",titleText:"",html:"",text:"",icon:"",showCancelButton:!1,showConfirmButton:!1,confirmButtonColor:"",focusConfirm:!1,cancelButtonColor:"",confirmButtonText:"",confirmButtonUrl:"",cancelButtonText:"",showCloseButton:!1,allowOutsideClick:!1,footer:""};this.AV13vacantes_nombre="";this.AV14usuariosid=0;this.AV5NombreCompleto="";this.AV10UsuariosTelef="";this.AV11UsuariosCorreo="";this.AV20Perfiles_Id=0;this.AV21usuarioidRec=0;this.AV23Asignar="";this.A272UsuariosTipo=0;this.A286UsuariosStatus=0;this.A11UsuariosId=0;this.A64UsuariosApMat="";this.A65UsuariosApPat="";this.A66UsuariosNombre="";this.A97UsuariosNomCompleto="";this.A260UsuariosTelef="";this.A261UsuariosCorreo="";this.A283PerfilesUsuariosEstatus=0;this.A278Perfiles_Id=0;this.Events={e132a2_client:["'ASIGNAR'",!0],e152a2_client:["ENTER",!0],e162a2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{ctrl:"vUSUARIOIDREC"},{av:"AV23Asignar",fld:"vASIGNAR",pic:""},{av:"AV15NomCompleto",fld:"vNOMCOMPLETO",pic:""},{av:"A260UsuariosTelef",fld:"USUARIOSTELEF",pic:""},{av:"A261UsuariosCorreo",fld:"USUARIOSCORREO",pic:""},{av:"A283PerfilesUsuariosEstatus",fld:"PERFILESUSUARIOSESTATUS",pic:"9"},{av:"A278Perfiles_Id",fld:"PERFILES_ID",pic:"ZZZZZZZZ9"},{av:"A286UsuariosStatus",fld:"USUARIOSSTATUS",pic:"9"},{av:"A272UsuariosTipo",fld:"USUARIOSTIPO",pic:"ZZZ9"},{av:"A11UsuariosId",fld:"USUARIOSID",pic:"ZZZZZ9"},{av:"A97UsuariosNomCompleto",fld:"USUARIOSNOMCOMPLETO",pic:""},{av:"AV21usuarioidRec",fld:"vUSUARIOIDREC",pic:"ZZZZZ9"}],[{ctrl:"vUSUARIOIDREC"},{av:"AV21usuarioidRec",fld:"vUSUARIOIDREC",pic:"ZZZZZ9"}]];this.EvtParms.START=[[{av:"A286UsuariosStatus",fld:"USUARIOSSTATUS",pic:"9"},{av:"A272UsuariosTipo",fld:"USUARIOSTIPO",pic:"ZZZ9"},{av:"A11UsuariosId",fld:"USUARIOSID",pic:"ZZZZZ9"},{av:"A97UsuariosNomCompleto",fld:"USUARIOSNOMCOMPLETO",pic:""},{ctrl:"vUSUARIOIDREC"},{av:"AV21usuarioidRec",fld:"vUSUARIOIDREC",pic:"ZZZZZ9"}],[{ctrl:"vUSUARIOIDREC"},{ctrl:"GRID1",prop:"Rows"},{av:"AV23Asignar",fld:"vASIGNAR",pic:""},{av:"AV21usuarioidRec",fld:"vUSUARIOIDREC",pic:"ZZZZZ9"}]];this.EvtParms["GRID1.LOAD"]=[[{av:"A272UsuariosTipo",fld:"USUARIOSTIPO",pic:"ZZZ9"},{av:"A286UsuariosStatus",fld:"USUARIOSSTATUS",pic:"9"},{av:"A97UsuariosNomCompleto",fld:"USUARIOSNOMCOMPLETO",pic:""},{av:"AV15NomCompleto",fld:"vNOMCOMPLETO",pic:""},{av:"A260UsuariosTelef",fld:"USUARIOSTELEF",pic:""},{av:"A261UsuariosCorreo",fld:"USUARIOSCORREO",pic:""},{av:"A11UsuariosId",fld:"USUARIOSID",pic:"ZZZZZ9"},{av:"A283PerfilesUsuariosEstatus",fld:"PERFILESUSUARIOSESTATUS",pic:"9"},{av:"A278Perfiles_Id",fld:"PERFILES_ID",pic:"ZZZZZZZZ9"}],[{av:"AV5NombreCompleto",fld:"vNOMBRECOMPLETO",pic:""},{av:"AV10UsuariosTelef",fld:"vUSUARIOSTELEF",pic:""},{av:"AV11UsuariosCorreo",fld:"vUSUARIOSCORREO",pic:""},{av:"AV14usuariosid",fld:"vUSUARIOSID",pic:"ZZZZZ9",hsh:!0},{ctrl:"vPERFILES_ID"},{av:"AV20Perfiles_Id",fld:"vPERFILES_ID",pic:"ZZZZZZZZ9"},{av:"AV13vacantes_nombre",fld:"vVACANTES_NOMBRE",pic:""}]];this.EvtParms["'ASIGNAR'"]=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"A286UsuariosStatus",fld:"USUARIOSSTATUS",pic:"9"},{av:"A272UsuariosTipo",fld:"USUARIOSTIPO",pic:"ZZZ9"},{av:"A11UsuariosId",fld:"USUARIOSID",pic:"ZZZZZ9"},{av:"A97UsuariosNomCompleto",fld:"USUARIOSNOMCOMPLETO",pic:""},{ctrl:"vUSUARIOIDREC"},{av:"AV23Asignar",fld:"vASIGNAR",pic:""},{av:"AV21usuarioidRec",fld:"vUSUARIOIDREC",pic:"ZZZZZ9"},{av:"AV15NomCompleto",fld:"vNOMCOMPLETO",pic:""},{av:"A260UsuariosTelef",fld:"USUARIOSTELEF",pic:""},{av:"A261UsuariosCorreo",fld:"USUARIOSCORREO",pic:""},{av:"A283PerfilesUsuariosEstatus",fld:"PERFILESUSUARIOSESTATUS",pic:"9"},{av:"A278Perfiles_Id",fld:"PERFILES_ID",pic:"ZZZZZZZZ9"},{av:"AV14usuariosid",fld:"vUSUARIOSID",pic:"ZZZZZ9",hsh:!0}],[{ctrl:"vUSUARIOIDREC"},{av:"AV21usuarioidRec",fld:"vUSUARIOIDREC",pic:"ZZZZZ9"},{av:"AV24AlertProperties",fld:"vALERTPROPERTIES",pic:""}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{ctrl:"vUSUARIOIDREC"},{av:"AV23Asignar",fld:"vASIGNAR",pic:""},{av:"AV15NomCompleto",fld:"vNOMCOMPLETO",pic:""},{av:"A260UsuariosTelef",fld:"USUARIOSTELEF",pic:""},{av:"A261UsuariosCorreo",fld:"USUARIOSCORREO",pic:""},{av:"A283PerfilesUsuariosEstatus",fld:"PERFILESUSUARIOSESTATUS",pic:"9"},{av:"A278Perfiles_Id",fld:"PERFILES_ID",pic:"ZZZZZZZZ9"},{av:"A286UsuariosStatus",fld:"USUARIOSSTATUS",pic:"9"},{av:"A272UsuariosTipo",fld:"USUARIOSTIPO",pic:"ZZZ9"},{av:"A11UsuariosId",fld:"USUARIOSID",pic:"ZZZZZ9"},{av:"A97UsuariosNomCompleto",fld:"USUARIOSNOMCOMPLETO",pic:""},{av:"AV21usuarioidRec",fld:"vUSUARIOIDREC",pic:"ZZZZZ9"}],[{ctrl:"vUSUARIOIDREC"},{av:"AV21usuarioidRec",fld:"vUSUARIOIDREC",pic:"ZZZZZ9"}]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{ctrl:"vUSUARIOIDREC"},{av:"AV23Asignar",fld:"vASIGNAR",pic:""},{av:"AV15NomCompleto",fld:"vNOMCOMPLETO",pic:""},{av:"A260UsuariosTelef",fld:"USUARIOSTELEF",pic:""},{av:"A261UsuariosCorreo",fld:"USUARIOSCORREO",pic:""},{av:"A283PerfilesUsuariosEstatus",fld:"PERFILESUSUARIOSESTATUS",pic:"9"},{av:"A278Perfiles_Id",fld:"PERFILES_ID",pic:"ZZZZZZZZ9"},{av:"A286UsuariosStatus",fld:"USUARIOSSTATUS",pic:"9"},{av:"A272UsuariosTipo",fld:"USUARIOSTIPO",pic:"ZZZ9"},{av:"A11UsuariosId",fld:"USUARIOSID",pic:"ZZZZZ9"},{av:"A97UsuariosNomCompleto",fld:"USUARIOSNOMCOMPLETO",pic:""},{av:"AV21usuarioidRec",fld:"vUSUARIOIDREC",pic:"ZZZZZ9"}],[{ctrl:"vUSUARIOIDREC"},{av:"AV21usuarioidRec",fld:"vUSUARIOIDREC",pic:"ZZZZZ9"}]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{ctrl:"vUSUARIOIDREC"},{av:"AV23Asignar",fld:"vASIGNAR",pic:""},{av:"AV15NomCompleto",fld:"vNOMCOMPLETO",pic:""},{av:"A260UsuariosTelef",fld:"USUARIOSTELEF",pic:""},{av:"A261UsuariosCorreo",fld:"USUARIOSCORREO",pic:""},{av:"A283PerfilesUsuariosEstatus",fld:"PERFILESUSUARIOSESTATUS",pic:"9"},{av:"A278Perfiles_Id",fld:"PERFILES_ID",pic:"ZZZZZZZZ9"},{av:"A286UsuariosStatus",fld:"USUARIOSSTATUS",pic:"9"},{av:"A272UsuariosTipo",fld:"USUARIOSTIPO",pic:"ZZZ9"},{av:"A11UsuariosId",fld:"USUARIOSID",pic:"ZZZZZ9"},{av:"A97UsuariosNomCompleto",fld:"USUARIOSNOMCOMPLETO",pic:""},{av:"AV21usuarioidRec",fld:"vUSUARIOIDREC",pic:"ZZZZZ9"}],[{ctrl:"vUSUARIOIDREC"},{av:"AV21usuarioidRec",fld:"vUSUARIOIDREC",pic:"ZZZZZ9"}]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{ctrl:"vUSUARIOIDREC"},{av:"AV23Asignar",fld:"vASIGNAR",pic:""},{av:"AV15NomCompleto",fld:"vNOMCOMPLETO",pic:""},{av:"A260UsuariosTelef",fld:"USUARIOSTELEF",pic:""},{av:"A261UsuariosCorreo",fld:"USUARIOSCORREO",pic:""},{av:"A283PerfilesUsuariosEstatus",fld:"PERFILESUSUARIOSESTATUS",pic:"9"},{av:"A278Perfiles_Id",fld:"PERFILES_ID",pic:"ZZZZZZZZ9"},{av:"A286UsuariosStatus",fld:"USUARIOSSTATUS",pic:"9"},{av:"A272UsuariosTipo",fld:"USUARIOSTIPO",pic:"ZZZ9"},{av:"A11UsuariosId",fld:"USUARIOSID",pic:"ZZZZZ9"},{av:"A97UsuariosNomCompleto",fld:"USUARIOSNOMCOMPLETO",pic:""},{av:"AV21usuarioidRec",fld:"vUSUARIOIDREC",pic:"ZZZZZ9"}],[{ctrl:"vUSUARIOIDREC"},{av:"AV21usuarioidRec",fld:"vUSUARIOIDREC",pic:"ZZZZZ9"}]];this.EvtParms.VALIDV_USUARIOSID=[[],[]];this.EvtParms.VALIDV_USUARIOSCORREO=[[{av:"AV11UsuariosCorreo",fld:"vUSUARIOSCORREO",pic:""}],[]];this.setVCMap("A66UsuariosNombre","USUARIOSNOMBRE",0,"svchar",40,0);this.setVCMap("A65UsuariosApPat","USUARIOSAPPAT",0,"svchar",40,0);this.setVCMap("A64UsuariosApMat","USUARIOSAPMAT",0,"svchar",40,0);this.setVCMap("A97UsuariosNomCompleto","USUARIOSNOMCOMPLETO",0,"svchar",90,0);this.setVCMap("A272UsuariosTipo","USUARIOSTIPO",0,"int",4,0);this.setVCMap("A286UsuariosStatus","USUARIOSSTATUS",0,"int",1,0);this.setVCMap("A260UsuariosTelef","USUARIOSTELEF",0,"char",10,0);this.setVCMap("A261UsuariosCorreo","USUARIOSCORREO",0,"svchar",100,0);this.setVCMap("A11UsuariosId","USUARIOSID",0,"int",6,0);this.setVCMap("A283PerfilesUsuariosEstatus","PERFILESUSUARIOSESTATUS",0,"int",1,0);this.setVCMap("A278Perfiles_Id","PERFILES_ID",0,"int",9,0);this.setVCMap("A286UsuariosStatus","USUARIOSSTATUS",0,"int",1,0);this.setVCMap("A272UsuariosTipo","USUARIOSTIPO",0,"int",4,0);this.setVCMap("A11UsuariosId","USUARIOSID",0,"int",6,0);this.setVCMap("A260UsuariosTelef","USUARIOSTELEF",0,"char",10,0);this.setVCMap("A261UsuariosCorreo","USUARIOSCORREO",0,"svchar",100,0);this.setVCMap("A283PerfilesUsuariosEstatus","PERFILESUSUARIOSESTATUS",0,"int",1,0);this.setVCMap("A278Perfiles_Id","PERFILES_ID",0,"int",9,0);this.setVCMap("A286UsuariosStatus","USUARIOSSTATUS",0,"int",1,0);this.setVCMap("A272UsuariosTipo","USUARIOSTIPO",0,"int",4,0);this.setVCMap("A11UsuariosId","USUARIOSID",0,"int",6,0);this.setVCMap("A260UsuariosTelef","USUARIOSTELEF",0,"char",10,0);this.setVCMap("A261UsuariosCorreo","USUARIOSCORREO",0,"svchar",100,0);this.setVCMap("A283PerfilesUsuariosEstatus","PERFILESUSUARIOSESTATUS",0,"int",1,0);this.setVCMap("A278Perfiles_Id","PERFILES_ID",0,"int",9,0);n.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});n.addRefreshingVar({rfrVar:"A286UsuariosStatus"});n.addRefreshingVar({rfrVar:"A272UsuariosTipo"});n.addRefreshingVar({rfrVar:"A11UsuariosId"});n.addRefreshingVar({rfrVar:"A97UsuariosNomCompleto"});n.addRefreshingVar({rfrVar:"AV21usuarioidRec",rfrProp:"Enabled",gxAttId:"Usuarioidrec"});n.addRefreshingVar({rfrVar:"AV23Asignar",rfrProp:"Value",gxAttId:"Asignar"});n.addRefreshingVar({rfrVar:"AV21usuarioidRec",rfrProp:"Value",gxAttId:"Usuarioidrec"});n.addRefreshingVar(this.GXValidFnc[13]);n.addRefreshingVar({rfrVar:"A260UsuariosTelef"});n.addRefreshingVar({rfrVar:"A261UsuariosCorreo"});n.addRefreshingVar({rfrVar:"A283PerfilesUsuariosEstatus"});n.addRefreshingVar({rfrVar:"A278Perfiles_Id"});n.addRefreshingParm({rfrVar:"A286UsuariosStatus"});n.addRefreshingParm({rfrVar:"A272UsuariosTipo"});n.addRefreshingParm({rfrVar:"A11UsuariosId"});n.addRefreshingParm({rfrVar:"A97UsuariosNomCompleto"});n.addRefreshingParm({rfrVar:"AV21usuarioidRec",rfrProp:"Enabled",gxAttId:"Usuarioidrec"});n.addRefreshingParm({rfrVar:"AV23Asignar",rfrProp:"Value",gxAttId:"Asignar"});n.addRefreshingParm({rfrVar:"AV21usuarioidRec",rfrProp:"Value",gxAttId:"Usuarioidrec"});n.addRefreshingParm(this.GXValidFnc[13]);n.addRefreshingParm({rfrVar:"A260UsuariosTelef"});n.addRefreshingParm({rfrVar:"A261UsuariosCorreo"});n.addRefreshingParm({rfrVar:"A283PerfilesUsuariosEstatus"});n.addRefreshingParm({rfrVar:"A278Perfiles_Id"});this.Initialize()});gx.wi(function(){gx.createParentObj(wppostulacion)})