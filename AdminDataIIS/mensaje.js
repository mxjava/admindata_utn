gx.evt.autoSkip = false;
gx.define('mensaje', true, function (CmpContext) {
   this.ServerClass =  "mensaje" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("web");
   this.setCmpContext(CmpContext);
   this.ReadonlyForm = true;
   this.hasEnterEvent = false;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.AV6Mensaje=gx.fn.getControlValue("vMENSAJE") ;
      this.AV5Clase=gx.fn.getControlValue("vCLASE") ;
      this.AV7Titulo=gx.fn.getControlValue("vTITULO") ;
   };
   this.e130l2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e140l2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2];
   this.GXLastCtrlId =2;
   GXValidFnc[2]={ id: 2, fld:"TXTNOTIFICACION", format:1,grid:0};
   this.AV6Mensaje = "" ;
   this.AV5Clase = "" ;
   this.AV7Titulo = "" ;
   this.Events = {"e130l2_client": ["ENTER", true] ,"e140l2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["START"] = [[{av:'AV6Mensaje',fld:'vMENSAJE',pic:''},{av:'AV7Titulo',fld:'vTITULO',pic:''},{av:'AV5Clase',fld:'vCLASE',pic:''}],[{av:'gx.fn.getCtrlProperty("TXTNOTIFICACION","Caption")',ctrl:'TXTNOTIFICACION',prop:'Caption'}]];
   this.setVCMap("AV6Mensaje", "vMENSAJE", 0, "svchar", 200, 0);
   this.setVCMap("AV5Clase", "vCLASE", 0, "svchar", 40, 0);
   this.setVCMap("AV7Titulo", "vTITULO", 0, "svchar", 40, 0);
   this.Initialize( );
});
gx.setExecutableComponent("mensaje");
