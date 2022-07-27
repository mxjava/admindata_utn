gx.evt.autoSkip = false;
gx.define('wcinfovacante', true, function (CmpContext) {
   this.ServerClass =  "wcinfovacante" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("web");
   this.setCmpContext(CmpContext);
   this.ReadonlyForm = true;
   this.hasEnterEvent = false;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.AV5UsuariosId=gx.fn.getIntegerValue("vUSUARIOSID",'.') ;
      this.AV6Vacantes_Id=gx.fn.getIntegerValue("vVACANTES_ID",'.') ;
      this.AV18RutaGuardada=gx.fn.getControlValue("vRUTAGUARDADA") ;
   };
   this.Validv_Vacantesusuariosfechad=function()
   {
      return this.validCliEvt("Validv_Vacantesusuariosfechad", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("vVACANTESUSUARIOSFECHAD");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.AV20VacantesUsuariosFechaD)===0) || new gx.date.gxdate( this.AV20VacantesUsuariosFechaD ).compare( gx.date.ymdhmstot( 1000, 1, 1, 0, 0, 0) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Fecha Descarte fuera de rango");
               this.AnyError = gx.num.trunc( 1 ,0) ;
            }
            catch(e){}
         }

      }
      catch(e){}
      try {
          if (gxballoon == null) return true; return gxballoon.show();
      }
      catch(e){}
      return true ;
      });
   }
   this.s112_client=function()
   {
      this.AV17FullPathFile =  this.AV18RutaGuardada  ;
      this.AV19NombreArchivo =  "------------" + ".pdf"  ;
      this.popupOpenUrl(gx.http.formatLink("aviewpdf.aspx",[this.AV19NombreArchivo, this.AV17FullPathFile]), []);
   };
   this.e123b2_client=function()
   {
      return this.executeServerEvent("IMAGE3.CLICK", true, null, false, true);
   };
   this.e133b2_client=function()
   {
      return this.executeServerEvent("IMAGE4.CLICK", true, null, false, true);
   };
   this.e143b2_client=function()
   {
      return this.executeServerEvent("IMAGE5.CLICK", true, null, false, true);
   };
   this.e153b2_client=function()
   {
      return this.executeServerEvent("IMAGE6.CLICK", true, null, false, true);
   };
   this.e163b2_client=function()
   {
      return this.executeServerEvent("IMAGE7.CLICK", true, null, false, true);
   };
   this.e173b2_client=function()
   {
      return this.executeServerEvent("IMAGE8.CLICK", true, null, false, true);
   };
   this.e183b2_client=function()
   {
      return this.executeServerEvent("IMAGE9.CLICK", true, null, false, true);
   };
   this.e193b2_client=function()
   {
      return this.executeServerEvent("IMAGE10.CLICK", true, null, false, true);
   };
   this.e203b2_client=function()
   {
      return this.executeServerEvent("IMAGE11.CLICK", true, null, false, true);
   };
   this.e223b2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e233b2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,9,12,14,16,19,21,22,23,25,28,30,31,32,34,37,39,40,41,43,46,48,49,50,52,55,57,58,59,61,64,66,67,68,70,73,75,76,77,79,82,84,85,86,88,91,93,94,95,97,100,103,105,106,107,109,110,111,112,113];
   this.GXLastCtrlId =113;
   this.UCALERTASContainer = gx.uc.getNew(this, 114, 23, "SweetAlert2", this.CmpContext + "UCALERTASContainer", "Ucalertas", "UCALERTAS");
   var UCALERTASContainer = this.UCALERTASContainer;
   UCALERTASContainer.setProp("Class", "Class", "", "char");
   UCALERTASContainer.setProp("Enabled", "Enabled", true, "boolean");
   UCALERTASContainer.setProp("Width", "Width", "100", "str");
   UCALERTASContainer.setProp("Height", "Height", "100", "str");
   UCALERTASContainer.addV2CFunction('AV16AlertProperties', "vALERTPROPERTIES", 'SetPropiedades');
   UCALERTASContainer.addC2VFunction(function(UC) { UC.ParentObject.AV16AlertProperties=UC.GetPropiedades();gx.fn.setControlValue("vALERTPROPERTIES",UC.ParentObject.AV16AlertProperties); });
   UCALERTASContainer.setProp("Visible", "Visible", true, "bool");
   UCALERTASContainer.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   UCALERTASContainer.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(UCALERTASContainer);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLE1",grid:0};
   GXValidFnc[9]={ id: 9, fld:"TABLE4",grid:0};
   GXValidFnc[12]={ id: 12, fld:"TEXTBLOCK10", format:0,grid:0};
   GXValidFnc[14]={ id: 14, fld:"TEXTBLOCK11", format:0,grid:0};
   GXValidFnc[16]={ id: 16, fld:"TEXTBLOCK12", format:0,grid:0};
   GXValidFnc[19]={ id: 19, fld:"TEXTBLOCK1", format:0,grid:0};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[23]={ id:23 ,lvl:0,type:"bits",len:1024,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPREFILTROSI",gxz:"ZV7PrefiltroSi",gxold:"OV7PrefiltroSi",gxvar:"AV7PrefiltroSi",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV7PrefiltroSi=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV7PrefiltroSi=Value},v2c:function(){gx.fn.setMultimediaValue("vPREFILTROSI",gx.O.AV7PrefiltroSi,gx.O.AV25Prefiltrosi_GXI)},c2v:function(){gx.O.AV25Prefiltrosi_GXI=this.val_GXI();if(this.val()!==undefined)gx.O.AV7PrefiltroSi=this.val()},val:function(){return gx.fn.getBlobValue("vPREFILTROSI")},val_GXI:function(){return gx.fn.getControlValue("vPREFILTROSI_GXI")}, gxvar_GXI:'AV25Prefiltrosi_GXI',nac:gx.falseFn};
   GXValidFnc[25]={ id: 25, fld:"IMAGE3",grid:0,evt:"e123b2_client"};
   GXValidFnc[28]={ id: 28, fld:"TEXTBLOCK2", format:0,grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id:32 ,lvl:0,type:"bits",len:1024,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCURRICULUMVITAESI",gxz:"ZV8CurriculumVitaeSi",gxold:"OV8CurriculumVitaeSi",gxvar:"AV8CurriculumVitaeSi",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV8CurriculumVitaeSi=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV8CurriculumVitaeSi=Value},v2c:function(){gx.fn.setMultimediaValue("vCURRICULUMVITAESI",gx.O.AV8CurriculumVitaeSi,gx.O.AV26Curriculumvitaesi_GXI)},c2v:function(){gx.O.AV26Curriculumvitaesi_GXI=this.val_GXI();if(this.val()!==undefined)gx.O.AV8CurriculumVitaeSi=this.val()},val:function(){return gx.fn.getBlobValue("vCURRICULUMVITAESI")},val_GXI:function(){return gx.fn.getControlValue("vCURRICULUMVITAESI_GXI")}, gxvar_GXI:'AV26Curriculumvitaesi_GXI',nac:gx.falseFn};
   GXValidFnc[34]={ id: 34, fld:"IMAGE4",grid:0,evt:"e133b2_client"};
   GXValidFnc[37]={ id: 37, fld:"TEXTBLOCK3", format:0,grid:0};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id:41 ,lvl:0,type:"bits",len:1024,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vEXAMENTECNINOSI",gxz:"ZV9ExamenTecninoSi",gxold:"OV9ExamenTecninoSi",gxvar:"AV9ExamenTecninoSi",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV9ExamenTecninoSi=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV9ExamenTecninoSi=Value},v2c:function(){gx.fn.setMultimediaValue("vEXAMENTECNINOSI",gx.O.AV9ExamenTecninoSi,gx.O.AV27Examentecninosi_GXI)},c2v:function(){gx.O.AV27Examentecninosi_GXI=this.val_GXI();if(this.val()!==undefined)gx.O.AV9ExamenTecninoSi=this.val()},val:function(){return gx.fn.getBlobValue("vEXAMENTECNINOSI")},val_GXI:function(){return gx.fn.getControlValue("vEXAMENTECNINOSI_GXI")}, gxvar_GXI:'AV27Examentecninosi_GXI',nac:gx.falseFn};
   GXValidFnc[43]={ id: 43, fld:"IMAGE5",grid:0,evt:"e143b2_client"};
   GXValidFnc[46]={ id: 46, fld:"TEXTBLOCK4", format:0,grid:0};
   GXValidFnc[48]={ id: 48, fld:"",grid:0};
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id:50 ,lvl:0,type:"bits",len:1024,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vAVCONFSI",gxz:"ZV10AvConfSi",gxold:"OV10AvConfSi",gxvar:"AV10AvConfSi",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV10AvConfSi=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV10AvConfSi=Value},v2c:function(){gx.fn.setMultimediaValue("vAVCONFSI",gx.O.AV10AvConfSi,gx.O.AV28Avconfsi_GXI)},c2v:function(){gx.O.AV28Avconfsi_GXI=this.val_GXI();if(this.val()!==undefined)gx.O.AV10AvConfSi=this.val()},val:function(){return gx.fn.getBlobValue("vAVCONFSI")},val_GXI:function(){return gx.fn.getControlValue("vAVCONFSI_GXI")}, gxvar_GXI:'AV28Avconfsi_GXI',nac:gx.falseFn};
   GXValidFnc[52]={ id: 52, fld:"IMAGE6",grid:0,evt:"e153b2_client"};
   GXValidFnc[55]={ id: 55, fld:"TEXTBLOCK5", format:0,grid:0};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id: 58, fld:"",grid:0};
   GXValidFnc[59]={ id:59 ,lvl:0,type:"bits",len:1024,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vAVPRIVSI",gxz:"ZV11AvPrivSi",gxold:"OV11AvPrivSi",gxvar:"AV11AvPrivSi",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV11AvPrivSi=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV11AvPrivSi=Value},v2c:function(){gx.fn.setMultimediaValue("vAVPRIVSI",gx.O.AV11AvPrivSi,gx.O.AV29Avprivsi_GXI)},c2v:function(){gx.O.AV29Avprivsi_GXI=this.val_GXI();if(this.val()!==undefined)gx.O.AV11AvPrivSi=this.val()},val:function(){return gx.fn.getBlobValue("vAVPRIVSI")},val_GXI:function(){return gx.fn.getControlValue("vAVPRIVSI_GXI")}, gxvar_GXI:'AV29Avprivsi_GXI',nac:gx.falseFn};
   GXValidFnc[61]={ id: 61, fld:"IMAGE7",grid:0,evt:"e163b2_client"};
   GXValidFnc[64]={ id: 64, fld:"TEXTBLOCK6", format:0,grid:0};
   GXValidFnc[66]={ id: 66, fld:"",grid:0};
   GXValidFnc[67]={ id: 67, fld:"",grid:0};
   GXValidFnc[68]={ id:68 ,lvl:0,type:"bits",len:1024,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBUSWEBSI",gxz:"ZV12BusWebSi",gxold:"OV12BusWebSi",gxvar:"AV12BusWebSi",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV12BusWebSi=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV12BusWebSi=Value},v2c:function(){gx.fn.setMultimediaValue("vBUSWEBSI",gx.O.AV12BusWebSi,gx.O.AV30Buswebsi_GXI)},c2v:function(){gx.O.AV30Buswebsi_GXI=this.val_GXI();if(this.val()!==undefined)gx.O.AV12BusWebSi=this.val()},val:function(){return gx.fn.getBlobValue("vBUSWEBSI")},val_GXI:function(){return gx.fn.getControlValue("vBUSWEBSI_GXI")}, gxvar_GXI:'AV30Buswebsi_GXI',nac:gx.falseFn};
   GXValidFnc[70]={ id: 70, fld:"IMAGE8",grid:0,evt:"e173b2_client"};
   GXValidFnc[73]={ id: 73, fld:"TEXTBLOCK7", format:0,grid:0};
   GXValidFnc[75]={ id: 75, fld:"",grid:0};
   GXValidFnc[76]={ id: 76, fld:"",grid:0};
   GXValidFnc[77]={ id:77 ,lvl:0,type:"bits",len:1024,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vREFERENCIASI",gxz:"ZV13ReferenciaSi",gxold:"OV13ReferenciaSi",gxvar:"AV13ReferenciaSi",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV13ReferenciaSi=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV13ReferenciaSi=Value},v2c:function(){gx.fn.setMultimediaValue("vREFERENCIASI",gx.O.AV13ReferenciaSi,gx.O.AV31Referenciasi_GXI)},c2v:function(){gx.O.AV31Referenciasi_GXI=this.val_GXI();if(this.val()!==undefined)gx.O.AV13ReferenciaSi=this.val()},val:function(){return gx.fn.getBlobValue("vREFERENCIASI")},val_GXI:function(){return gx.fn.getControlValue("vREFERENCIASI_GXI")}, gxvar_GXI:'AV31Referenciasi_GXI',nac:gx.falseFn};
   GXValidFnc[79]={ id: 79, fld:"IMAGE9",grid:0,evt:"e183b2_client"};
   GXValidFnc[82]={ id: 82, fld:"TEXTBLOCK8", format:0,grid:0};
   GXValidFnc[84]={ id: 84, fld:"",grid:0};
   GXValidFnc[85]={ id: 85, fld:"",grid:0};
   GXValidFnc[86]={ id:86 ,lvl:0,type:"bits",len:1024,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vEXMPSISI",gxz:"ZV14ExmPsiSi",gxold:"OV14ExmPsiSi",gxvar:"AV14ExmPsiSi",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV14ExmPsiSi=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV14ExmPsiSi=Value},v2c:function(){gx.fn.setMultimediaValue("vEXMPSISI",gx.O.AV14ExmPsiSi,gx.O.AV32Exmpsisi_GXI)},c2v:function(){gx.O.AV32Exmpsisi_GXI=this.val_GXI();if(this.val()!==undefined)gx.O.AV14ExmPsiSi=this.val()},val:function(){return gx.fn.getBlobValue("vEXMPSISI")},val_GXI:function(){return gx.fn.getControlValue("vEXMPSISI_GXI")}, gxvar_GXI:'AV32Exmpsisi_GXI',nac:gx.falseFn};
   GXValidFnc[88]={ id: 88, fld:"IMAGE10",grid:0,evt:"e193b2_client"};
   GXValidFnc[91]={ id: 91, fld:"TEXTBLOCK9", format:0,grid:0};
   GXValidFnc[93]={ id: 93, fld:"",grid:0};
   GXValidFnc[94]={ id: 94, fld:"",grid:0};
   GXValidFnc[95]={ id:95 ,lvl:0,type:"bits",len:1024,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCVRECSI",gxz:"ZV15CVRecSi",gxold:"OV15CVRecSi",gxvar:"AV15CVRecSi",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV15CVRecSi=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV15CVRecSi=Value},v2c:function(){gx.fn.setMultimediaValue("vCVRECSI",gx.O.AV15CVRecSi,gx.O.AV33Cvrecsi_GXI)},c2v:function(){gx.O.AV33Cvrecsi_GXI=this.val_GXI();if(this.val()!==undefined)gx.O.AV15CVRecSi=this.val()},val:function(){return gx.fn.getBlobValue("vCVRECSI")},val_GXI:function(){return gx.fn.getControlValue("vCVRECSI_GXI")}, gxvar_GXI:'AV33Cvrecsi_GXI',nac:gx.falseFn};
   GXValidFnc[97]={ id: 97, fld:"IMAGE11",grid:0,evt:"e203b2_client"};
   GXValidFnc[100]={ id: 100, fld:"DESCARTADO", format:0,grid:0};
   GXValidFnc[103]={ id: 103, fld:"MOTIVO_DESCARTE", format:0,grid:0};
   GXValidFnc[105]={ id: 105, fld:"",grid:0};
   GXValidFnc[106]={ id: 106, fld:"",grid:0};
   GXValidFnc[107]={ id:107 ,lvl:0,type:"dtime",len:8,dec:5,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Vacantesusuariosfechad,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vVACANTESUSUARIOSFECHAD",gxz:"ZV20VacantesUsuariosFechaD",gxold:"OV20VacantesUsuariosFechaD",gxvar:"AV20VacantesUsuariosFechaD",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/99 99:99",dec:5},ucs:[],op:[107],ip:[107],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV20VacantesUsuariosFechaD=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV20VacantesUsuariosFechaD=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("vVACANTESUSUARIOSFECHAD",gx.O.AV20VacantesUsuariosFechaD,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV20VacantesUsuariosFechaD=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("vVACANTESUSUARIOSFECHAD")},nac:gx.falseFn};
   GXValidFnc[109]={ id: 109, fld:"",grid:0};
   GXValidFnc[110]={ id: 110, fld:"",grid:0};
   GXValidFnc[111]={ id:111 ,lvl:0,type:"svchar",len:2048,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vVACANTESUSUARIOSMOTD",gxz:"ZV21VacantesUsuariosMotD",gxold:"OV21VacantesUsuariosMotD",gxvar:"AV21VacantesUsuariosMotD",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV21VacantesUsuariosMotD=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV21VacantesUsuariosMotD=Value},v2c:function(){gx.fn.setControlValue("vVACANTESUSUARIOSMOTD",gx.O.AV21VacantesUsuariosMotD,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV21VacantesUsuariosMotD=this.val()},val:function(){return gx.fn.getControlValue("vVACANTESUSUARIOSMOTD")},nac:gx.falseFn};
   GXValidFnc[112]={ id: 112, fld:"",grid:0};
   GXValidFnc[113]={ id: 113, fld:"",grid:0};
   this.AV25Prefiltrosi_GXI = "" ;
   this.AV7PrefiltroSi = "" ;
   this.ZV7PrefiltroSi = "" ;
   this.OV7PrefiltroSi = "" ;
   this.AV26Curriculumvitaesi_GXI = "" ;
   this.AV8CurriculumVitaeSi = "" ;
   this.ZV8CurriculumVitaeSi = "" ;
   this.OV8CurriculumVitaeSi = "" ;
   this.AV27Examentecninosi_GXI = "" ;
   this.AV9ExamenTecninoSi = "" ;
   this.ZV9ExamenTecninoSi = "" ;
   this.OV9ExamenTecninoSi = "" ;
   this.AV28Avconfsi_GXI = "" ;
   this.AV10AvConfSi = "" ;
   this.ZV10AvConfSi = "" ;
   this.OV10AvConfSi = "" ;
   this.AV29Avprivsi_GXI = "" ;
   this.AV11AvPrivSi = "" ;
   this.ZV11AvPrivSi = "" ;
   this.OV11AvPrivSi = "" ;
   this.AV30Buswebsi_GXI = "" ;
   this.AV12BusWebSi = "" ;
   this.ZV12BusWebSi = "" ;
   this.OV12BusWebSi = "" ;
   this.AV31Referenciasi_GXI = "" ;
   this.AV13ReferenciaSi = "" ;
   this.ZV13ReferenciaSi = "" ;
   this.OV13ReferenciaSi = "" ;
   this.AV32Exmpsisi_GXI = "" ;
   this.AV14ExmPsiSi = "" ;
   this.ZV14ExmPsiSi = "" ;
   this.OV14ExmPsiSi = "" ;
   this.AV33Cvrecsi_GXI = "" ;
   this.AV15CVRecSi = "" ;
   this.ZV15CVRecSi = "" ;
   this.OV15CVRecSi = "" ;
   this.AV20VacantesUsuariosFechaD = gx.date.nullDate() ;
   this.ZV20VacantesUsuariosFechaD = gx.date.nullDate() ;
   this.OV20VacantesUsuariosFechaD = gx.date.nullDate() ;
   this.AV21VacantesUsuariosMotD = "" ;
   this.ZV21VacantesUsuariosMotD = "" ;
   this.OV21VacantesUsuariosMotD = "" ;
   this.AV7PrefiltroSi = "" ;
   this.AV8CurriculumVitaeSi = "" ;
   this.AV9ExamenTecninoSi = "" ;
   this.AV10AvConfSi = "" ;
   this.AV11AvPrivSi = "" ;
   this.AV12BusWebSi = "" ;
   this.AV13ReferenciaSi = "" ;
   this.AV14ExmPsiSi = "" ;
   this.AV15CVRecSi = "" ;
   this.AV20VacantesUsuariosFechaD = gx.date.nullDate() ;
   this.AV21VacantesUsuariosMotD = "" ;
   this.AV16AlertProperties = {title:"",titleText:"",html:"",text:"",icon:"",showCancelButton:false,showConfirmButton:false,confirmButtonColor:"",focusConfirm:false,cancelButtonColor:"",confirmButtonText:"",confirmButtonUrl:"",cancelButtonText:"",showCloseButton:false,allowOutsideClick:false,footer:""} ;
   this.AV5UsuariosId = 0 ;
   this.AV6Vacantes_Id = 0 ;
   this.A11UsuariosId = 0 ;
   this.A263Vacantes_Id = 0 ;
   this.A292VacantesUsuariosCV = 0 ;
   this.A291VacantesUsuariosPrefiltro = 0 ;
   this.A290VacantesUsuariosEstatus = 0 ;
   this.A289VacantesUsuariosFechaD = gx.date.nullDate() ;
   this.A294VacantesUsuariosMotD = "" ;
   this.A293VacantesUsuariosExTec = 0 ;
   this.A304VacantesUsuariosAvConf = 0 ;
   this.A303VacantesUsuariosAvPriv = 0 ;
   this.A302VacantesUsuariosBusWeb = 0 ;
   this.A300VacantesUsuariosRefLab = 0 ;
   this.A301VacantesUsuariosExPsi = 0 ;
   this.A299VacantesUsuariosCVRec = 0 ;
   this.AV18RutaGuardada = "" ;
   this.AV19NombreArchivo = "" ;
   this.AV17FullPathFile = "" ;
   this.Events = {"e123b2_client": ["IMAGE3.CLICK", true] ,"e133b2_client": ["IMAGE4.CLICK", true] ,"e143b2_client": ["IMAGE5.CLICK", true] ,"e153b2_client": ["IMAGE6.CLICK", true] ,"e163b2_client": ["IMAGE7.CLICK", true] ,"e173b2_client": ["IMAGE8.CLICK", true] ,"e183b2_client": ["IMAGE9.CLICK", true] ,"e193b2_client": ["IMAGE10.CLICK", true] ,"e203b2_client": ["IMAGE11.CLICK", true] ,"e223b2_client": ["ENTER", true] ,"e233b2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["START"] = [[{av:'A263Vacantes_Id',fld:'VACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'A11UsuariosId',fld:'USUARIOSID',pic:'ZZZZZ9'},{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'A291VacantesUsuariosPrefiltro',fld:'VACANTESUSUARIOSPREFILTRO',pic:'ZZZ9'},{av:'A292VacantesUsuariosCV',fld:'VACANTESUSUARIOSCV',pic:'ZZZ9'},{av:'A290VacantesUsuariosEstatus',fld:'VACANTESUSUARIOSESTATUS',pic:'ZZZ9'},{av:'A289VacantesUsuariosFechaD',fld:'VACANTESUSUARIOSFECHAD',pic:'99/99/99 99:99'},{av:'A294VacantesUsuariosMotD',fld:'VACANTESUSUARIOSMOTD',pic:''},{av:'A293VacantesUsuariosExTec',fld:'VACANTESUSUARIOSEXTEC',pic:'ZZZ9'},{av:'A304VacantesUsuariosAvConf',fld:'VACANTESUSUARIOSAVCONF',pic:'ZZZ9'},{av:'A303VacantesUsuariosAvPriv',fld:'VACANTESUSUARIOSAVPRIV',pic:'ZZZ9'},{av:'A302VacantesUsuariosBusWeb',fld:'VACANTESUSUARIOSBUSWEB',pic:'ZZZ9'},{av:'A300VacantesUsuariosRefLab',fld:'VACANTESUSUARIOSREFLAB',pic:'ZZZ9'},{av:'A301VacantesUsuariosExPsi',fld:'VACANTESUSUARIOSEXPSI',pic:'ZZZ9'},{av:'A299VacantesUsuariosCVRec',fld:'VACANTESUSUARIOSCVREC',pic:'ZZZ9'}],[{av:'AV16AlertProperties',fld:'vALERTPROPERTIES',pic:''},{av:'AV20VacantesUsuariosFechaD',fld:'vVACANTESUSUARIOSFECHAD',pic:'99/99/99 99:99'},{av:'AV21VacantesUsuariosMotD',fld:'vVACANTESUSUARIOSMOTD',pic:''},{av:'gx.fn.getCtrlProperty("MOTIVO_DESCARTE","Visible")',ctrl:'MOTIVO_DESCARTE',prop:'Visible'},{av:'gx.fn.getCtrlProperty("DESCARTADO","Visible")',ctrl:'DESCARTADO',prop:'Visible'},{av:'gx.fn.getCtrlProperty("vVACANTESUSUARIOSFECHAD","Visible")',ctrl:'vVACANTESUSUARIOSFECHAD',prop:'Visible'},{av:'gx.fn.getCtrlProperty("vVACANTESUSUARIOSMOTD","Visible")',ctrl:'vVACANTESUSUARIOSMOTD',prop:'Visible'},{av:'AV7PrefiltroSi',fld:'vPREFILTROSI',pic:''},{av:'gx.fn.getCtrlProperty("IMAGE3","Visible")',ctrl:'IMAGE3',prop:'Visible'},{av:'AV8CurriculumVitaeSi',fld:'vCURRICULUMVITAESI',pic:''},{av:'gx.fn.getCtrlProperty("IMAGE4","Visible")',ctrl:'IMAGE4',prop:'Visible'},{av:'AV9ExamenTecninoSi',fld:'vEXAMENTECNINOSI',pic:''},{av:'gx.fn.getCtrlProperty("IMAGE5","Visible")',ctrl:'IMAGE5',prop:'Visible'},{av:'AV10AvConfSi',fld:'vAVCONFSI',pic:''},{av:'gx.fn.getCtrlProperty("IMAGE6","Visible")',ctrl:'IMAGE6',prop:'Visible'},{av:'AV11AvPrivSi',fld:'vAVPRIVSI',pic:''},{av:'gx.fn.getCtrlProperty("IMAGE7","Visible")',ctrl:'IMAGE7',prop:'Visible'},{av:'AV12BusWebSi',fld:'vBUSWEBSI',pic:''},{av:'gx.fn.getCtrlProperty("IMAGE8","Visible")',ctrl:'IMAGE8',prop:'Visible'},{av:'AV13ReferenciaSi',fld:'vREFERENCIASI',pic:''},{av:'gx.fn.getCtrlProperty("IMAGE9","Visible")',ctrl:'IMAGE9',prop:'Visible'},{av:'AV14ExmPsiSi',fld:'vEXMPSISI',pic:''},{av:'gx.fn.getCtrlProperty("IMAGE10","Visible")',ctrl:'IMAGE10',prop:'Visible'},{av:'AV15CVRecSi',fld:'vCVRECSI',pic:''},{av:'gx.fn.getCtrlProperty("IMAGE11","Visible")',ctrl:'IMAGE11',prop:'Visible'}]];
   this.EvtParms["IMAGE3.CLICK"] = [[{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}],[{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]];
   this.EvtParms["IMAGE4.CLICK"] = [[{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}],[{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]];
   this.EvtParms["IMAGE5.CLICK"] = [[{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}],[{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]];
   this.EvtParms["IMAGE6.CLICK"] = [[{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}],[{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]];
   this.EvtParms["IMAGE7.CLICK"] = [[{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}],[{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]];
   this.EvtParms["IMAGE8.CLICK"] = [[{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}],[{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]];
   this.EvtParms["IMAGE9.CLICK"] = [[{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}],[{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]];
   this.EvtParms["IMAGE10.CLICK"] = [[{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}],[{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]];
   this.EvtParms["IMAGE11.CLICK"] = [[{av:'AV5UsuariosId',fld:'vUSUARIOSID',pic:'ZZZZZ9'},{av:'AV6Vacantes_Id',fld:'vVACANTES_ID',pic:'ZZZZZZZZ9'},{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}],[{av:'AV18RutaGuardada',fld:'vRUTAGUARDADA',pic:''}]];
   this.EvtParms["VALIDV_VACANTESUSUARIOSFECHAD"] = [[],[]];
   this.setVCMap("AV5UsuariosId", "vUSUARIOSID", 0, "int", 6, 0);
   this.setVCMap("AV6Vacantes_Id", "vVACANTES_ID", 0, "int", 9, 0);
   this.setVCMap("AV18RutaGuardada", "vRUTAGUARDADA", 0, "svchar", 40, 0);
   this.Initialize( );
});
