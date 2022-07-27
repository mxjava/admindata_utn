gx.evt.autoSkip = false;
gx.define('menu', false, function () {
   this.ServerClass =  "menu" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("trn");
   this.anyGridBaseTable = true;
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.AV7MenuXid=gx.fn.getIntegerValue("vMENUXID",'.') ;
      this.A40000MenIcono_GXI=gx.fn.getControlValue("MENICONO_GXI") ;
      this.AV11Pgmname=gx.fn.getControlValue("vPGMNAME") ;
      this.Gx_mode=gx.fn.getControlValue("vMODE") ;
      this.AV9TrnContext=gx.fn.getControlValue("vTRNCONTEXT") ;
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
   this.Valid_Menxurl=function()
   {
      return this.validCliEvt("Valid_Menxurl", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("MENXURL");
         this.AnyError  = 0;
         if ( ! ( gx.util.regExp.isMatch(this.A4MenXUrl, "^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") || ((''===this.A4MenXUrl)) ) )
         {
            try {
               gxballoon.setError("El valor de Url no coincide con el patrón especificado");
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
   this.Valid_Rolid=function()
   {
      var currentRow = gx.fn.currentGridRowImpl(78);
      if(  gx.fn.currentGridRowImpl(78) ===0) {
         return true;
      }
      var gxballoon = gx.util.balloon.getNew("ROLID", gx.fn.currentGridRowImpl(78));
      if ( gx.fn.gridDuplicateKey(79) )
      {
         gxballoon.setError(gx.text.format( gx.getMessage( "GXM_1004"), "Rol", "", "", "", "", "", "", "", ""));
         this.AnyError = gx.num.trunc( 1 ,0) ;
         return gxballoon.show();
      }
      return this.validSrvEvt("Valid_Rolid", 78).then((function (ret) {
      try {
         this.sMode23 =  this.Gx_mode  ;
         this.Gx_mode =  gx.fn.getGridRowMode(23,78)  ;
         this.standaloneModal0123( );
         this.standaloneNotModal0123( );
      } finally {
         this.Gx_mode =  this.sMode23  ;
      }
      return ret;
      }).closure(this));
   }
   this.standaloneModal0123=function()
   {
      try {
         if ( this.Gx_mode != "INS" )
         {
            gx.fn.setCtrlProperty("ROLID","Enabled", 0 );
         }
         else
         {
            gx.fn.setCtrlProperty("ROLID","Enabled", 1 );
         }
      }
      catch(e){}
   }
   this.standaloneNotModal0123=function()
   {
   }
   this.e12012_client=function()
   {
      return this.executeServerEvent("AFTER TRN", true, null, false, false);
   };
   this.e13011_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e14011_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,79,80,81,82,83,84,85,86,87,88,89,90];
   this.GXLastCtrlId =90;
   this.Gridmenu_rolContainer = new gx.grid.grid(this, 23,"Rol",78,"Gridmenu_rol","Gridmenu_rol","Gridmenu_rolContainer",this.CmpContext,this.IsMasterPage,"menu",[24],false,1,false,true,5,false,false,false,"",0,"px",0,"px","Nueva fila",true,false,false,null,null,false,"",false,[1,1,1,1],false,0,true,false);
   var Gridmenu_rolContainer = this.Gridmenu_rolContainer;
   Gridmenu_rolContainer.addSingleLineEdit(24,79,"ROLID","Clave del rol","","RolId","int",0,"px",9,9,"right",null,[],24,"RolId",true,0,false,false,"Attribute",1,"");
   Gridmenu_rolContainer.addSingleLineEdit(127,80,"ROLNOMBRE","Rol Nombre","","RolNombre","svchar",0,"px",40,40,"left",null,[],127,"RolNombre",true,0,false,false,"Attribute",1,"");
   Gridmenu_rolContainer.addSingleLineEdit(128,81,"ROLDESCRIPCION","Rol Descripcion","","RolDescripcion","svchar",0,"px",150,80,"left",null,[],128,"RolDescripcion",true,0,false,false,"Attribute",1,"");
   this.Gridmenu_rolContainer.emptyText = "";
   this.setGrid(Gridmenu_rolContainer);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TITLECONTAINER",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[9]={ id: 9, fld:"TITLE", format:0,grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"",grid:0};
   GXValidFnc[15]={ id: 15, fld:"FORMCONTAINER",grid:0};
   GXValidFnc[16]={ id: 16, fld:"",grid:0};
   GXValidFnc[17]={ id: 17, fld:"TOOLBARCELL",grid:0};
   GXValidFnc[18]={ id: 18, fld:"",grid:0};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   GXValidFnc[21]={ id: 21, fld:"BTN_FIRST",grid:0,evt:"e15011_client",std:"FIRST"};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[23]={ id: 23, fld:"BTN_PREVIOUS",grid:0,evt:"e16011_client",std:"PREVIOUS"};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"BTN_NEXT",grid:0,evt:"e17011_client",std:"NEXT"};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"BTN_LAST",grid:0,evt:"e18011_client",std:"LAST"};
   GXValidFnc[28]={ id: 28, fld:"",grid:0};
   GXValidFnc[29]={ id: 29, fld:"BTN_SELECT",grid:0,evt:"e19011_client",std:"SELECT"};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id: 33, fld:"",grid:0};
   GXValidFnc[34]={ id:34 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Menuxid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Gridmenu_rolContainer],fld:"MENUXID",gxz:"Z1MenuXid",gxold:"O1MenuXid",gxvar:"A1MenuXid",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1MenuXid=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1MenuXid=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("MENUXID",gx.O.A1MenuXid,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1MenuXid=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("MENUXID",'.')},nac:gx.falseFn};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id: 38, fld:"",grid:0};
   GXValidFnc[39]={ id:39 ,lvl:0,type:"svchar",len:40,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENUXDESC",gxz:"Z2MenuXDesc",gxold:"O2MenuXDesc",gxvar:"A2MenuXDesc",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2MenuXDesc=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z2MenuXDesc=Value},v2c:function(){gx.fn.setControlValue("MENUXDESC",gx.O.A2MenuXDesc,0)},c2v:function(){if(this.val()!==undefined)gx.O.A2MenuXDesc=this.val()},val:function(){return gx.fn.getControlValue("MENUXDESC")},nac:gx.falseFn};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id: 43, fld:"",grid:0};
   GXValidFnc[44]={ id:44 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENUXPOSI",gxz:"Z3MenuXPosi",gxold:"O3MenuXPosi",gxvar:"A3MenuXPosi",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A3MenuXPosi=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z3MenuXPosi=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("MENUXPOSI",gx.O.A3MenuXPosi,0)},c2v:function(){if(this.val()!==undefined)gx.O.A3MenuXPosi=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("MENUXPOSI",'.')},nac:gx.falseFn};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id: 48, fld:"",grid:0};
   GXValidFnc[49]={ id:49 ,lvl:0,type:"svchar",len:1000,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Menxurl,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENXURL",gxz:"Z4MenXUrl",gxold:"O4MenXUrl",gxvar:"A4MenXUrl",ucs:[],op:[49],ip:[49],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A4MenXUrl=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z4MenXUrl=Value},v2c:function(){gx.fn.setControlValue("MENXURL",gx.O.A4MenXUrl,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A4MenXUrl=this.val()},val:function(){return gx.fn.getControlValue("MENXURL")},nac:gx.falseFn};
   this.declareDomainHdlr( 49 , function() {
   });
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id: 53, fld:"",grid:0};
   GXValidFnc[54]={ id:54 ,lvl:0,type:"char",len:1,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENXEST",gxz:"Z5MenXEst",gxold:"O5MenXEst",gxvar:"A5MenXEst",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"combo",v2v:function(Value){if(Value!==undefined)gx.O.A5MenXEst=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z5MenXEst=Value},v2c:function(){gx.fn.setComboBoxValue("MENXEST",gx.O.A5MenXEst)},c2v:function(){if(this.val()!==undefined)gx.O.A5MenXEst=this.val()},val:function(){return gx.fn.getControlValue("MENXEST")},nac:gx.falseFn};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id: 56, fld:"",grid:0};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id: 58, fld:"",grid:0};
   GXValidFnc[59]={ id:59 ,lvl:0,type:"bits",len:1024,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENICONO",gxz:"Z259MenIcono",gxold:"O259MenIcono",gxvar:"A259MenIcono",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A259MenIcono=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z259MenIcono=Value},v2c:function(){gx.fn.setMultimediaValue("MENICONO",gx.O.A259MenIcono,gx.O.A40000MenIcono_GXI)},c2v:function(){gx.O.A40000MenIcono_GXI=this.val_GXI();if(this.val()!==undefined)gx.O.A259MenIcono=this.val()},val:function(){return gx.fn.getBlobValue("MENICONO")},val_GXI:function(){return gx.fn.getControlValue("MENICONO_GXI")}, gxvar_GXI:'A40000MenIcono_GXI',nac:gx.falseFn};
   GXValidFnc[60]={ id: 60, fld:"",grid:0};
   GXValidFnc[61]={ id: 61, fld:"",grid:0};
   GXValidFnc[62]={ id: 62, fld:"",grid:0};
   GXValidFnc[63]={ id: 63, fld:"",grid:0};
   GXValidFnc[64]={ id:64 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENPADRE",gxz:"Z258MenPadre",gxold:"O258MenPadre",gxvar:"A258MenPadre",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A258MenPadre=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z258MenPadre=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("MENPADRE",gx.O.A258MenPadre,0)},c2v:function(){if(this.val()!==undefined)gx.O.A258MenPadre=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("MENPADRE",'.')},nac:gx.falseFn};
   GXValidFnc[65]={ id: 65, fld:"",grid:0};
   GXValidFnc[66]={ id: 66, fld:"",grid:0};
   GXValidFnc[67]={ id: 67, fld:"",grid:0};
   GXValidFnc[68]={ id: 68, fld:"",grid:0};
   GXValidFnc[69]={ id:69 ,lvl:0,type:"svchar",len:120,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DESCRIPCION",gxz:"Z262Descripcion",gxold:"O262Descripcion",gxvar:"A262Descripcion",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A262Descripcion=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z262Descripcion=Value},v2c:function(){gx.fn.setControlValue("DESCRIPCION",gx.O.A262Descripcion,0)},c2v:function(){if(this.val()!==undefined)gx.O.A262Descripcion=this.val()},val:function(){return gx.fn.getControlValue("DESCRIPCION")},nac:gx.falseFn};
   GXValidFnc[70]={ id: 70, fld:"",grid:0};
   GXValidFnc[71]={ id: 71, fld:"",grid:0};
   GXValidFnc[72]={ id: 72, fld:"ROLTABLE",grid:0};
   GXValidFnc[73]={ id: 73, fld:"",grid:0};
   GXValidFnc[74]={ id: 74, fld:"",grid:0};
   GXValidFnc[75]={ id: 75, fld:"TITLEROL", format:0,grid:0};
   GXValidFnc[76]={ id: 76, fld:"",grid:0};
   GXValidFnc[77]={ id: 77, fld:"",grid:0};
   GXValidFnc[79]={ id:79 ,lvl:23,type:"int",len:9,dec:0,sign:false,pic:"ZZZZZZZZ9",ro:0,isacc:1,grid:78,gxgrid:this.Gridmenu_rolContainer,fnc:this.Valid_Rolid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ROLID",gxz:"Z24RolId",gxold:"O24RolId",gxvar:"A24RolId",ucs:[],op:[81,80],ip:[81,80,79],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A24RolId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z24RolId=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("ROLID",row || gx.fn.currentGridRowImpl(78),gx.O.A24RolId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(row){if(this.val(row)!==undefined)gx.O.A24RolId=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("ROLID",row || gx.fn.currentGridRowImpl(78),'.')},nac:gx.falseFn};
   GXValidFnc[80]={ id:80 ,lvl:23,type:"svchar",len:40,dec:0,sign:false,ro:1,isacc:1,grid:78,gxgrid:this.Gridmenu_rolContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ROLNOMBRE",gxz:"Z127RolNombre",gxold:"O127RolNombre",gxvar:"A127RolNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A127RolNombre=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z127RolNombre=Value},v2c:function(row){gx.fn.setGridControlValue("ROLNOMBRE",row || gx.fn.currentGridRowImpl(78),gx.O.A127RolNombre,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A127RolNombre=this.val(row)},val:function(row){return gx.fn.getGridControlValue("ROLNOMBRE",row || gx.fn.currentGridRowImpl(78))},nac:gx.falseFn};
   GXValidFnc[81]={ id:81 ,lvl:23,type:"svchar",len:150,dec:0,sign:false,ro:1,isacc:1,grid:78,gxgrid:this.Gridmenu_rolContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ROLDESCRIPCION",gxz:"Z128RolDescripcion",gxold:"O128RolDescripcion",gxvar:"A128RolDescripcion",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A128RolDescripcion=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z128RolDescripcion=Value},v2c:function(row){gx.fn.setGridControlValue("ROLDESCRIPCION",row || gx.fn.currentGridRowImpl(78),gx.O.A128RolDescripcion,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A128RolDescripcion=this.val(row)},val:function(row){return gx.fn.getGridControlValue("ROLDESCRIPCION",row || gx.fn.currentGridRowImpl(78))},nac:gx.falseFn};
   GXValidFnc[82]={ id: 82, fld:"",grid:0};
   GXValidFnc[83]={ id: 83, fld:"",grid:0};
   GXValidFnc[84]={ id: 84, fld:"",grid:0};
   GXValidFnc[85]={ id: 85, fld:"",grid:0};
   GXValidFnc[86]={ id: 86, fld:"BTN_ENTER",grid:0,evt:"e13011_client",std:"ENTER"};
   GXValidFnc[87]={ id: 87, fld:"",grid:0};
   GXValidFnc[88]={ id: 88, fld:"BTN_CANCEL",grid:0,evt:"e14011_client"};
   GXValidFnc[89]={ id: 89, fld:"",grid:0};
   GXValidFnc[90]={ id: 90, fld:"BTN_DELETE",grid:0,evt:"e20011_client",std:"DELETE"};
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
   this.A40000MenIcono_GXI = "" ;
   this.A259MenIcono = "" ;
   this.Z259MenIcono = "" ;
   this.O259MenIcono = "" ;
   this.A258MenPadre = 0 ;
   this.Z258MenPadre = 0 ;
   this.O258MenPadre = 0 ;
   this.A262Descripcion = "" ;
   this.Z262Descripcion = "" ;
   this.O262Descripcion = "" ;
   this.Z24RolId = 0 ;
   this.O24RolId = 0 ;
   this.Z127RolNombre = "" ;
   this.O127RolNombre = "" ;
   this.Z128RolDescripcion = "" ;
   this.O128RolDescripcion = "" ;
   this.A24RolId = 0 ;
   this.A127RolNombre = "" ;
   this.A128RolDescripcion = "" ;
   this.A40000MenIcono_GXI = "" ;
   this.AV11Pgmname = "" ;
   this.AV9TrnContext = {CallerObject:"",CallerOnDelete:false,CallerURL:"",TransactionName:"",Attributes:[]} ;
   this.AV7MenuXid = 0 ;
   this.AV10WebSession = {} ;
   this.A1MenuXid = 0 ;
   this.A2MenuXDesc = "" ;
   this.A3MenuXPosi = 0 ;
   this.A4MenXUrl = "" ;
   this.A5MenXEst = "" ;
   this.A259MenIcono = "" ;
   this.A258MenPadre = 0 ;
   this.A262Descripcion = "" ;
   this.Gx_mode = "" ;
   this.Events = {"e12012_client": ["AFTER TRN", true] ,"e13011_client": ["ENTER", true] ,"e14011_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7MenuXid',fld:'vMENUXID',pic:'ZZZ9',hsh:true}],[]];
   this.EvtParms["REFRESH"] = [[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7MenuXid',fld:'vMENUXID',pic:'ZZZ9',hsh:true},{av:'A1MenuXid',fld:'MENUXID',pic:'ZZZ9'}],[]];
   this.EvtParms["START"] = [[{av:'AV11Pgmname',fld:'vPGMNAME',pic:''}],[{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]];
   this.EvtParms["AFTER TRN"] = [[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}],[]];
   this.EvtParms["VALID_MENUXID"] = [[],[]];
   this.EvtParms["VALID_MENXURL"] = [[{av:'A4MenXUrl',fld:'MENXURL',pic:''}],[{av:'A4MenXUrl',fld:'MENXURL',pic:''}]];
   this.EvtParms["VALID_ROLID"] = [[{av:'A24RolId',fld:'ROLID',pic:'ZZZZZZZZ9'},{av:'A127RolNombre',fld:'ROLNOMBRE',pic:''},{av:'A128RolDescripcion',fld:'ROLDESCRIPCION',pic:''}],[{av:'A127RolNombre',fld:'ROLNOMBRE',pic:''},{av:'A128RolDescripcion',fld:'ROLDESCRIPCION',pic:''}]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.setVCMap("AV7MenuXid", "vMENUXID", 0, "int", 4, 0);
   this.setVCMap("A40000MenIcono_GXI", "MENICONO_GXI", 0, "svchar", 2048, 0);
   this.setVCMap("AV11Pgmname", "vPGMNAME", 0, "char", 129, 0);
   this.setVCMap("Gx_mode", "vMODE", 0, "char", 3, 0);
   this.setVCMap("AV9TrnContext", "vTRNCONTEXT", 0, "TransactionContext", 0, 0);
   Gridmenu_rolContainer.addPostingVar({rfrVar:"Gx_mode"});
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(menu);});
