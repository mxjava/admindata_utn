gx.evt.autoSkip = false;
gx.define('menugeneral', true, function (CmpContext) {
   this.ServerClass =  "menugeneral" ;
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
   };
   this.Valid_Menuxid=function()
   {
      return this.validCliEvt("Valid_Menuxid", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("MENUXID");
         this.AnyError  = 0;

      }
      catch(e){}
      try {
          if (gxballoon == null) return true; return gxballoon.show();
      }
      catch(e){}
      return true ;
      });
   }
   this.e13232_client=function()
   {
      return this.executeServerEvent("'DOUPDATE'", false, null, false, false);
   };
   this.e14232_client=function()
   {
      return this.executeServerEvent("'DODELETE'", false, null, false, false);
   };
   this.e15232_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e16232_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54];
   this.GXLastCtrlId =54;
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"BTNUPDATE",grid:0,evt:"e13232_client"};
   GXValidFnc[9]={ id: 9, fld:"",grid:0};
   GXValidFnc[10]={ id: 10, fld:"BTNDELETE",grid:0,evt:"e14232_client"};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[12]={ id: 12, fld:"",grid:0};
   GXValidFnc[13]={ id: 13, fld:"ATTRIBUTESTABLE",grid:0};
   GXValidFnc[14]={ id: 14, fld:"",grid:0};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"",grid:0};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id:18 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Menuxid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENUXID",gxz:"Z1MenuXid",gxold:"O1MenuXid",gxvar:"A1MenuXid",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1MenuXid=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1MenuXid=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("MENUXID",gx.O.A1MenuXid,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1MenuXid=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("MENUXID",'.')},nac:gx.falseFn};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[23]={ id:23 ,lvl:0,type:"svchar",len:40,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENUXDESC",gxz:"Z2MenuXDesc",gxold:"O2MenuXDesc",gxvar:"A2MenuXDesc",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2MenuXDesc=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z2MenuXDesc=Value},v2c:function(){gx.fn.setControlValue("MENUXDESC",gx.O.A2MenuXDesc,0)},c2v:function(){if(this.val()!==undefined)gx.O.A2MenuXDesc=this.val()},val:function(){return gx.fn.getControlValue("MENUXDESC")},nac:gx.falseFn};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id:28 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENUXPOSI",gxz:"Z3MenuXPosi",gxold:"O3MenuXPosi",gxvar:"A3MenuXPosi",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A3MenuXPosi=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z3MenuXPosi=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("MENUXPOSI",gx.O.A3MenuXPosi,0)},c2v:function(){if(this.val()!==undefined)gx.O.A3MenuXPosi=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("MENUXPOSI",'.')},nac:gx.falseFn};
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id:33 ,lvl:0,type:"svchar",len:1000,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENXURL",gxz:"Z4MenXUrl",gxold:"O4MenXUrl",gxvar:"A4MenXUrl",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A4MenXUrl=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z4MenXUrl=Value},v2c:function(){gx.fn.setControlValue("MENXURL",gx.O.A4MenXUrl,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A4MenXUrl=this.val()},val:function(){return gx.fn.getControlValue("MENXURL")},nac:gx.falseFn};
   this.declareDomainHdlr( 33 , function() {
   });
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id:38 ,lvl:0,type:"char",len:1,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENXEST",gxz:"Z5MenXEst",gxold:"O5MenXEst",gxvar:"A5MenXEst",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"combo",v2v:function(Value){if(Value!==undefined)gx.O.A5MenXEst=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z5MenXEst=Value},v2c:function(){gx.fn.setComboBoxValue("MENXEST",gx.O.A5MenXEst)},c2v:function(){if(this.val()!==undefined)gx.O.A5MenXEst=this.val()},val:function(){return gx.fn.getControlValue("MENXEST")},nac:gx.falseFn};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id:43 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENPADRE",gxz:"Z258MenPadre",gxold:"O258MenPadre",gxvar:"A258MenPadre",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A258MenPadre=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z258MenPadre=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("MENPADRE",gx.O.A258MenPadre,0)},c2v:function(){if(this.val()!==undefined)gx.O.A258MenPadre=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("MENPADRE",'.')},nac:gx.falseFn};
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id:48 ,lvl:0,type:"svchar",len:120,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DESCRIPCION",gxz:"Z262Descripcion",gxold:"O262Descripcion",gxvar:"A262Descripcion",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A262Descripcion=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z262Descripcion=Value},v2c:function(){gx.fn.setControlValue("DESCRIPCION",gx.O.A262Descripcion,0)},c2v:function(){if(this.val()!==undefined)gx.O.A262Descripcion=this.val()},val:function(){return gx.fn.getControlValue("DESCRIPCION")},nac:gx.falseFn};
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"IMAGESTABLE",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id: 53, fld:"",grid:0};
   GXValidFnc[54]={ id:54 ,lvl:0,type:"bits",len:1024,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENICONO",gxz:"Z259MenIcono",gxold:"O259MenIcono",gxvar:"A259MenIcono",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A259MenIcono=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z259MenIcono=Value},v2c:function(){gx.fn.setMultimediaValue("MENICONO",gx.O.A259MenIcono,gx.O.A40000MenIcono_GXI)},c2v:function(){gx.O.A40000MenIcono_GXI=this.val_GXI();if(this.val()!==undefined)gx.O.A259MenIcono=this.val()},val:function(){return gx.fn.getBlobValue("MENICONO")},val_GXI:function(){return gx.fn.getControlValue("MENICONO_GXI")}, gxvar_GXI:'A40000MenIcono_GXI',nac:gx.falseFn};
   this.A1MenuXid = 0 ;
   this.Z1MenuXid = 0 ;
   this.O1MenuXid = 0 ;
   this.A2MenuXDesc = "" ;
   this.Z2MenuXDesc = "" ;
   this.O2MenuXDesc = "" ;
   this.A3MenuXPosi = 0 ;
   this.Z3MenuXPosi = 0 ;
   this.O3MenuXPosi = 0 ;
   this.A4MenXUrl = "" ;
   this.Z4MenXUrl = "" ;
   this.O4MenXUrl = "" ;
   this.A5MenXEst = "" ;
   this.Z5MenXEst = "" ;
   this.O5MenXEst = "" ;
   this.A258MenPadre = 0 ;
   this.Z258MenPadre = 0 ;
   this.O258MenPadre = 0 ;
   this.A262Descripcion = "" ;
   this.Z262Descripcion = "" ;
   this.O262Descripcion = "" ;
   this.A40000MenIcono_GXI = "" ;
   this.A259MenIcono = "" ;
   this.Z259MenIcono = "" ;
   this.O259MenIcono = "" ;
   this.A1MenuXid = 0 ;
   this.A2MenuXDesc = "" ;
   this.A3MenuXPosi = 0 ;
   this.A4MenXUrl = "" ;
   this.A5MenXEst = "" ;
   this.A258MenPadre = 0 ;
   this.A262Descripcion = "" ;
   this.A259MenIcono = "" ;
   this.A40000MenIcono_GXI = "" ;
   this.Events = {"e13232_client": ["'DOUPDATE'", true] ,"e14232_client": ["'DODELETE'", true] ,"e15232_client": ["ENTER", true] ,"e16232_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[{av:'A1MenuXid',fld:'MENUXID',pic:'ZZZ9'}],[]];
   this.EvtParms["START"] = [[{av:'AV13Pgmname',fld:'vPGMNAME',pic:''},{av:'AV6MenuXid',fld:'vMENUXID',pic:'ZZZ9'}],[]];
   this.EvtParms["LOAD"] = [[],[]];
   this.EvtParms["'DOUPDATE'"] = [[{av:'A1MenuXid',fld:'MENUXID',pic:'ZZZ9'}],[]];
   this.EvtParms["'DODELETE'"] = [[{av:'A1MenuXid',fld:'MENUXID',pic:'ZZZ9'}],[]];
   this.EvtParms["VALID_MENUXID"] = [[],[]];
   this.Initialize( );
});
