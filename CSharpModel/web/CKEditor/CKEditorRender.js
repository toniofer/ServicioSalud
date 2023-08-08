function CKEditorControl()
{

	if (!gx.util.browser.isIPad)
	{
		gx.util.browser.isIPad = function() {	return navigator.userAgent.indexOf("iPad") != -1;}
	}
	
	if (!gx.util.browser.isIPhone)
	{
		gx.util.browser.isIPhone = function() {	return navigator.userAgent.indexOf("iPhone") != -1;}
	}

	this.Width;
	this.Height;
	this.Attribute;
	this.Style;
	this.Toolbar;
	this.MenuMap = [];
	this.isIphone = gx.util.browser.isIPhone() || gx.util.browser.isIPad();

	

	// Databinding for property Attribute
	this.SetAttribute = function(data) {
	    ///UserCodeRegionStart:[SetAttribute] (do not remove this comment.)
	    this.data = data;
	    ///UserCodeRegionEnd: (do not remove this comment.)
	}

	// Databinding for property Attribute
	this.GetAttribute = function() {
	    ///UserCodeRegionStart:[GetAttribute] (do not remove this comment.)
	    return this.GetData();

	    ///UserCodeRegionEnd: (do not remove this comment.)
	}

	this.show = function(force) {
	    ///UserCodeRegionStart:[show] (do not remove this comment.)
	    if (!this.IsPostBack) {
	        if (this.AttributeReadonly)
	            this.SetData(this.data);
	        else {
	        		if (this.isIphone)
	        		{
	        			var buffer = "<textarea id=\"" + this.ContainerName + "_textArea\" style=\"width:" + this.Width + ";height:" + this.Height + "\">" + this.data + "</textarea>";
	        			this.setHtml(buffer);
	        		}
	        		else
	        		{	
	            	this.Initialize();
	            	this.CreateCkEditor();            
	            }
	        }
	    }
	    else {
	        this.SetData(this.data);
	        this.SetVisible();
	    }
	    ///UserCodeRegionEnd: (do not remove this comment.)
	}
	///UserCodeRegionStart:[User Functions] (do not remove this comment.)

	this.Initialize = function() {

	    this.RunFckEditorMigration();
	    gx.fx.obs.addObserver("popup.close", this, this.HandlePopupClose);
	    this.BasePath = gx.util.resourceUrl(gx.basePath + gx.staticDirectory + "CKEditor/", true);
	    if (!gx.lang.emptyObject(this.CustomToolbar) && !gx.lang.emptyObject(this.Toolbar) && this.Toolbar == 'Custom')
	        this.ToolbarType = this.CustomToolbar;
	    else if (!gx.lang.emptyObject(this.Toolbar) && this.Toolbar != 'Custom')
	        this.ToolbarType = this.Toolbar;

	    if (!gx.lang.emptyObject(this.CustomConfiguration)) {
	    		if (gx.http.callBackend)
	        	gx.http.callBackend(" ", this.BasePath + this.CustomConfiguration, " ", true, gx.http.modes.call, false, 'GET');
	        else
	        {
	        	if (gx.gen.ruby)
	        	{
		        	jQuery.ajax({ 
	         					url:    this.BasePath + this.CustomConfiguration , 
	                	success: function(result) { 
	                    eval(result);
	                  }, 
	         					async:   false 
	    				});      	        	
		        }
	    		}
	    }

	}

	this.RunFckEditorMigration = function() {
	    if (this.Toolbar == "Default") this.Toolbar = "Full";
	}

	this.CreateCkEditor = function() {
	    var oThis = this;
	    var language = this.GetLanguage();
	    var instanceConfig = {
	        toolbar: (this.Toolbar != "None") ? this.ToolbarType : [],
	        language: language,
	        uiColor: oThis.Color.Html,
	        skin: oThis.Skin,
	        toolbarCanCollapse: oThis.ToolbarCanCollapse,
	        toolbarStartupExpanded: oThis.ToolbarExpanded,
	        scayt_autoStartup: false,
	        entities_latin: false,
	        on: { 'pluginsLoaded': this.CreateDelegate(this, this.OnPluginsLoaded) }
	    };
	    if (this.MenuGroups)
	        instanceConfig.menu_groups = this.MenuGroups;


	    this.editor = CKEDITOR.appendTo(this.ContainerName, instanceConfig);
	    if (instanceConfig.on) {
	        for (var eventName in instanceConfig.on) {
	            this.editor.on(eventName, instanceConfig.on[eventName]);
	        }
	    }
	    this.editor.config.menu_groups += ',insertCode';
	    if (!this.MenuGroups)
	        this.MenuGroups = this.editor.config.menu_groups;

	    this.editor.setData(this.data);
	    this.SetVisible();

	}


	this.ButtonClickHandler = function(id) {
	    var itemProperties = this.MenuMap[id];
	    if (itemProperties.ObjectInterface == 0)
	        this.CallHttpProcedure(itemProperties);
	    if (itemProperties.ObjectInterface == 1)
	        this.OpenPrompt(itemProperties);
	}

	this.HandlePopupClose = function() {
	    var content = this.handle.RawReturnedParms[0];
	    this.SendContentToEditor(content);
	}

	this.OpenPrompt = function(itemProperties) {	    
	    this.handle = gx.popup.openUrl(gx.http.formatLink(itemProperties.Link), ["OutPutParm1"]);
	}

	this.CallHttpProcedure = function(itemProperties) {
	    var response;
	    if (gx.http.callBackend)
	    {
	    	gx.http.callBackend("(", itemProperties.Link, ')', true, gx.http.modes.call, false, 'GET');
	    	response = gx.http.lastResponse;
	    }
	    else
	    {
	      	if (gx.gen.ruby)
	        {
		        	jQuery.ajax({ 
	         					url:    itemProperties.Link , 
	                	success: function(result) { 
	                    response = result;
	                  }, 
	         					async:   false 
	    				});      	        	
		        }
	    		}	    	    
	    if (response != "")
	        this.SendContentToEditor(response)
	}
	
	this.SendContentToEditor = function(content)
	{
        this.editor.insertHtml(content);
	}

	this.OnPluginsLoaded = function(ev) {
	    if (this.ToolbarReference) {
	        var contextMenuItems = {};
	        for (var i = 0; this.Menu[i] != undefined; i++) {
	            ev.editor.ui.addButton(this.Menu[i].Id,
		        {
		            label: this.Menu[i].Description,
		            icon: gx.util.resourceUrl(((gx.gen.ruby) ? gx.basePath: "")  + gx.staticDirectory.substring(1, gx.staticDirectory.length) + this.Menu[i].Icon, true),
		            click: this.CreateDelegate(this, this.ButtonClickHandler, [this.Menu[i].Id])
		        });
	        }
	    };
	    if (this.ContextMenu) {
	        for (var i = 0; this.ContextMenu[i] != undefined; i++) {
	            if (ev.editor.addMenuItems) {
	                ev.editor.addMenuItems(this.GetMenuObject(this.ContextMenu[i]));
	                contextMenuItems[this.ContextMenu[i].Id] = CKEDITOR.TRISTATE_OFF;
	            }
	        }
	        if (ev.editor.contextMenu) {
	            ev.editor.contextMenu.addListener(function(element, selection) {
	                return contextMenuItems;
	            });
	        }
	    }
	    ev.editor.config.height = this.Height;
	    ev.editor.config.width = this.Width;
	}


	this.GetMenuObject = function(menuItem) {
	    var obj = new Object();
	    obj[menuItem.Id] = {
	        label: menuItem.Description,
	        
	        icon: gx.util.resourceUrl(((gx.gen.ruby) ? gx.basePath: "")  + gx.staticDirectory.substring(1, gx.staticDirectory.length) + menuItem.Icon, true),
	        onClick: this.CreateDelegate(this, this.ButtonClickHandler, [menuItem.Id]),
	        group: 'insertCode',
	        command: menuItem.Id + "_cmd"
	    }
	    return obj;
	}

	this.SetVisible = function() {
	    if (gx.lang.booleanValue(this.Visible) == true) {
	        this.getContainerControl().style.display = "inline";
	        this.Visible = true;
	    }
	    else {
	        this.getContainerControl().style.display = "none";
	        this.Visible = false;
	    }
	}

	this.SetMode = function(mode, text) {
	    if (!this.isIphone)
	    {
		    if (mode == 0 && this.editor) {
		        var data = (text != undefined) ? text : this.editor.getData();
		        this.editor.destroy();
		        this.editor = null;
		        this.setHtml(data);
		    }
		    if (mode == 1 && this.editor == null) {
		        var data = (text != undefined) ? text : this.getContainerControl().innerHTML;
		        this.setHtml("");
		        this.CreateCkEditor();
		        this.editor.setData(data);
			  }
	    }

	}

    this.SetMenu = function(menu) {
        if (!this.isIphone)
        {
	        this.Menu = menu;
	        if (!this.ToolbarReference) {
	            this.ToolbarReference = eval("CKEDITOR.config.toolbar_" + this.ToolbarType);
	            if (this.ToolbarType != "None")
	            {
	                var newBand = [];
	                for (var i = 0; menu[i] != undefined; i++) {
	                    newBand.push(menu[i].Id);
	                    this.MenuMap[menu[i].Id] = menu[i];
	                }
	                this.ToolbarReference.push(newBand);
	            }
	        }
	  		}
    }

    this.SetContextMenu = function(menu) {
         if (!this.isIphone)
         {
	        if (!this.ContextMenu) {
	            this.ContextMenu = menu;
	
	            for (var i = 0; menu[i] != undefined; i++) {
	                this.MenuMap[menu[i].Id] = menu[i];
	            }
	        }
      }
    }

    this.GetLanguage = function() {
        var language = (gx.languageCode != undefined) ? gx.languageCode : "";
        switch (language) {
            case "eng":
                return "en";
            case "German":
                return "de";
            case "ita":
                return "it";
            case "spa":
                return "es";
            case "por":
                return "pt";
            case "jap":
                return "ja";
            default:
                return "en";
        }
    }
    
    this.GetData = function()
    {
    	if (this.isIphone)
    		return gx.dom.byId(this.ContainerName + "_textArea").value;
    	else
    		return this.editor.getData();
    }
    
   	this.SetInitialData = function(data)
    {
    	if (this.isIphone)
    		gx.dom.byId(this.ContainerName + "_textArea").value = this.data;
    	else
    		document.getElementById(this.ContainerName).innerHTML = this.data;
    }
    
    this.SetData = function(data)
    {
    	if (this.isIphone)
    		gx.dom.byId(this.ContainerName + "_textArea").value = this.data;
    	else
    		this.editor.setData(this.data);
    }
   

    this.CreateDelegate = function(obj, method, args, appendArgs) {
        return function() {
            var callArgs = args || arguments;
            if (appendArgs === true) {
                callArgs = Array.prototype.slice.call(arguments, 0);
                callArgs = callArgs.concat(args);
            } else if (typeof appendArgs == "number") {
                callArgs = Array.prototype.slice.call(arguments, 0);
                var applyArgs = [appendArgs, 0].concat(args);
                Array.prototype.splice.apply(callArgs, applyArgs);
            }
            return method.apply(obj || window, callArgs);
        };
    }

	
	///UserCodeRegionEnd: (do not remove this comment.):
}
