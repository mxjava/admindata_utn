gx.evt.autoSkip = false;
gx.define('tabbedview', true, function (CmpContext) {
   this.ServerClass =  "tabbedview" ;
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
      this.AV5FirstTab=gx.fn.getIntegerValue("vFIRSTTAB",'.') ;
      this.AV11LastTab=gx.fn.getIntegerValue("vLASTTAB",'.') ;
      this.AV18Tabs=gx.fn.getControlValue("vTABS") ;
      this.AV15TabCode=gx.fn.getControlValue("vTABCODE") ;
      this.AV8Index=gx.fn.getIntegerValue("vINDEX",'.') ;
      this.AV13SelectedTab=gx.fn.getIntegerValue("vSELECTEDTAB",'.') ;
      this.AV14Tab=gx.fn.getControlValue("vTAB") ;
      this.AV19TabsMarkup=gx.fn.getControlValue("vTABSMARKUP") ;
      this.AV20TabTemplate=gx.fn.getControlValue("vTABTEMPLATE") ;
      this.AV23URLChangedEvent=gx.fn.getControlValue("vURLCHANGEDEVENT") ;
   };
   this.s112_client=function()
   {
      this.AV20TabTemplate =  "<li class=\"%1\">"  ;
      this.AV20TabTemplate =  this.AV20TabTemplate + "<a id=\"%2Tab\" %3%7 class=\"%4\">"  ;
      this.AV20TabTemplate =  this.AV20TabTemplate + "<span class=\"%5\">"  ;
      this.AV20TabTemplate =  this.AV20TabTemplate + "<span class=\"TabBackground\">"  ;
      this.AV20TabTemplate =  this.AV20TabTemplate + "<span class=\"TabText\">%6</span>"  ;
      this.AV20TabTemplate =  this.AV20TabTemplate + "</span>"  ;
      this.AV20TabTemplate =  this.AV20TabTemplate + "</span>"  ;
      this.AV20TabTemplate =  this.AV20TabTemplate + "</a>"  ;
      this.AV20TabTemplate =  this.AV20TabTemplate + "</li>"  ;
   };
   this.s132_client=function()
   {
      this.AV6Found =  false  ;
      this.AV8Index = gx.num.trunc( 1 ,0) ;
      while ( this.AV8Index <= this.AV18Tabs.length )
      {
         if ( ( ( this.HISTORYMANAGERContainer.Hash == "" ) && ( ( this.AV18Tabs[this.AV8Index - 1].Code == this.AV15TabCode ) ) ) || ( ( this.AV18Tabs[this.AV8Index - 1].Code == this.HISTORYMANAGERContainer.Hash ) ) )
         {
            this.AV13SelectedTab = gx.num.trunc( this.AV8Index ,0) ;
            this.AV6Found =  true  ;
            break;
         }
         this.AV8Index = gx.num.trunc( this.AV8Index + 1 ,0) ;
      }
      if ( ! this.AV6Found && ( this.AV18Tabs.length > 0 ) )
      {
         this.AV13SelectedTab = gx.num.trunc( 1 ,0) ;
      }
   };
   this.s142_client=function()
   {
      this.AV5FirstTab = gx.num.trunc( 1 ,0) ;
      this.AV11LastTab = gx.num.trunc( this.AV18Tabs.length ,0) ;
      gx.fn.setCtrlProperty("TABPREVIOUS","Visible", 0 );
      gx.fn.setCtrlProperty("TABNEXT","Visible", 0 );
   };
   this.e110a2_client=function()
   {
      return this.executeServerEvent("HISTORYMANAGER.URLCHANGED", false, null, true, true);
   };
   this.e150a2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e160a2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,5,6,7,8,11];
   this.GXLastCtrlId =11;
   this.HISTORYMANAGERContainer = gx.uc.getNew(this, 15, 0, "HistoryManager", this.CmpContext + "HISTORYMANAGERContainer", "Historymanager", "HISTORYMANAGER");
   var HISTORYMANAGERContainer = this.HISTORYMANAGERContainer;
   HISTORYMANAGERContainer.setProp("Class", "Class", "", "char");
   HISTORYMANAGERContainer.setProp("Enabled", "Enabled", true, "boolean");
   HISTORYMANAGERContainer.setProp("Hash", "Hash", "", "char");
   HISTORYMANAGERContainer.setProp("URL", "Url", "", "char");
   HISTORYMANAGERContainer.setProp("QueryString", "Querystring", "", "char");
   HISTORYMANAGERContainer.setProp("Visible", "Visible", true, "bool");
   HISTORYMANAGERContainer.setC2ShowFunction(function(UC) { UC.start(); });
   HISTORYMANAGERContainer.addEventHandler("URLChanged", this.e110a2_client);
   this.setUserControl(HISTORYMANAGERContainer);
   GXValidFnc[2]={ id: 2, fld:"TABLE1",grid:0};
   GXValidFnc[5]={ id: 5, fld:"TABCONTAINER",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABS", format:1,grid:0};
   GXValidFnc[7]={ id: 7, fld:"TABPREVIOUS",grid:0};
   GXValidFnc[8]={ id: 8, fld:"TABNEXT",grid:0};
   GXValidFnc[11]={ id: 11, fld:"TABLE2",grid:0};
   this.AV18Tabs = [ ] ;
   this.AV15TabCode = "" ;
   this.AV5FirstTab = 0 ;
   this.AV11LastTab = 0 ;
   this.AV8Index = 0 ;
   this.AV13SelectedTab = 0 ;
   this.AV14Tab = {Code:"",Description:"",Link:"",WebComponent:""} ;
   this.AV19TabsMarkup = "" ;
   this.AV20TabTemplate = "" ;
   this.AV23URLChangedEvent = false ;
   this.AV6Found = false ;
   this.Events = {"e110a2_client": ["HISTORYMANAGER.URLCHANGED", true] ,"e150a2_client": ["ENTER", true] ,"e160a2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[{av:'AV23URLChangedEvent',fld:'vURLCHANGEDEVENT',pic:''},{av:'AV5FirstTab',fld:'vFIRSTTAB',pic:'ZZZ9'},{av:'AV11LastTab',fld:'vLASTTAB',pic:'ZZZ9'},{av:'AV18Tabs',fld:'vTABS',pic:''},{av:'AV15TabCode',fld:'vTABCODE',pic:''},{av:'this.HISTORYMANAGERContainer.Hash',ctrl:'HISTORYMANAGER',prop:'Hash'},{av:'AV8Index',fld:'vINDEX',pic:'ZZZ9'},{av:'AV13SelectedTab',fld:'vSELECTEDTAB',pic:'ZZZ9'},{av:'AV14Tab',fld:'vTAB',pic:''},{av:'AV19TabsMarkup',fld:'vTABSMARKUP',pic:''},{av:'AV20TabTemplate',fld:'vTABTEMPLATE',pic:'',hsh:true}],[{av:'AV19TabsMarkup',fld:'vTABSMARKUP',pic:''},{av:'AV8Index',fld:'vINDEX',pic:'ZZZ9'},{av:'AV14Tab',fld:'vTAB',pic:''},{av:'gx.fn.getCtrlProperty("TABS","Caption")',ctrl:'TABS',prop:'Caption'},{av:'AV13SelectedTab',fld:'vSELECTEDTAB',pic:'ZZZ9'},{av:'AV5FirstTab',fld:'vFIRSTTAB',pic:'ZZZ9'},{av:'AV11LastTab',fld:'vLASTTAB',pic:'ZZZ9'},{av:'gx.fn.getCtrlProperty("TABPREVIOUS","Visible")',ctrl:'TABPREVIOUS',prop:'Visible'},{av:'gx.fn.getCtrlProperty("TABNEXT","Visible")',ctrl:'TABNEXT',prop:'Visible'},{ctrl:'COMPONENT'}]];
   this.EvtParms["START"] = [[],[{av:'AV20TabTemplate',fld:'vTABTEMPLATE',pic:'',hsh:true}]];
   this.EvtParms["HISTORYMANAGER.URLCHANGED"] = [[{av:'AV5FirstTab',fld:'vFIRSTTAB',pic:'ZZZ9'},{av:'AV11LastTab',fld:'vLASTTAB',pic:'ZZZ9'},{av:'AV18Tabs',fld:'vTABS',pic:''},{av:'AV15TabCode',fld:'vTABCODE',pic:''},{av:'this.HISTORYMANAGERContainer.Hash',ctrl:'HISTORYMANAGER',prop:'Hash'},{av:'AV8Index',fld:'vINDEX',pic:'ZZZ9'},{av:'AV13SelectedTab',fld:'vSELECTEDTAB',pic:'ZZZ9'},{av:'AV14Tab',fld:'vTAB',pic:''},{av:'AV19TabsMarkup',fld:'vTABSMARKUP',pic:''},{av:'AV20TabTemplate',fld:'vTABTEMPLATE',pic:'',hsh:true}],[{av:'AV23URLChangedEvent',fld:'vURLCHANGEDEVENT',pic:''},{av:'AV19TabsMarkup',fld:'vTABSMARKUP',pic:''},{av:'AV8Index',fld:'vINDEX',pic:'ZZZ9'},{av:'AV14Tab',fld:'vTAB',pic:''},{av:'gx.fn.getCtrlProperty("TABS","Caption")',ctrl:'TABS',prop:'Caption'},{av:'AV13SelectedTab',fld:'vSELECTEDTAB',pic:'ZZZ9'},{av:'AV5FirstTab',fld:'vFIRSTTAB',pic:'ZZZ9'},{av:'AV11LastTab',fld:'vLASTTAB',pic:'ZZZ9'},{av:'gx.fn.getCtrlProperty("TABPREVIOUS","Visible")',ctrl:'TABPREVIOUS',prop:'Visible'},{av:'gx.fn.getCtrlProperty("TABNEXT","Visible")',ctrl:'TABNEXT',prop:'Visible'},{ctrl:'COMPONENT'}]];
   this.setVCMap("AV5FirstTab", "vFIRSTTAB", 0, "int", 4, 0);
   this.setVCMap("AV11LastTab", "vLASTTAB", 0, "int", 4, 0);
   this.setVCMap("AV18Tabs", "TABS", 0, "CollTabOptions.TabOptionsItem", 0, 0);
   this.setVCMap("AV15TabCode", "vTABCODE", 0, "char", 50, 0);
   this.setVCMap("AV8Index", "vINDEX", 0, "int", 4, 0);
   this.setVCMap("AV13SelectedTab", "vSELECTEDTAB", 0, "int", 4, 0);
   this.setVCMap("AV14Tab", "vTAB", 0, "TabOptions.TabOptionsItem", 0, 0);
   this.setVCMap("AV19TabsMarkup", "vTABSMARKUP", 0, "char", 20, 0);
   this.setVCMap("AV20TabTemplate", "vTABTEMPLATE", 0, "char", 20, 0);
   this.setVCMap("AV23URLChangedEvent", "vURLCHANGEDEVENT", 0, "boolean", 4, 0);
   this.Initialize( );
   this.setComponent({id: "COMPONENT" ,GXClass: null , Prefix: "W0014" , lvl: 1 });
});
