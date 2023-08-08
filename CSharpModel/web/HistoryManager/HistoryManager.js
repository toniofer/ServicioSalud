function HistoryManager()
{
	this.Hash;
	this.URL;
	this.QueryString;
	
	this.start = function(){
		if (gx.grid.drawAtServer)
			return;
		if (window.dhtmlHistory.isSupported){
			if (!HistoryManager.m_initialized){
				HistoryManager.m_initialized = true;
				window.dhtmlHistory.initialize();
				window.dhtmlHistory.addListener(HistoryManager.listenerFn);
			}
		
			if (!this.IsPostBack){
				HistoryManager.AddListener(this);
				if (document.location.hash != ""){
					var that = this;
					gx.evt.on_ready(this, function(){
						that.urlListener();
					});
				}
			}
		}
		this.UpdateProperties();
	};
	
	this.destroy = function(){
		if (gx.grid.drawAtServer)
			return;
		HistoryManager.RemoveListener(this);
	};
	
	this.urlListener = function(){
		if (gx.grid.drawAtServer)
			return;
		if (this.URLChanged){
			this.UpdateProperties();
			if (gx.ajax && typeof(gx.ajax.pushReferer) == 'function')
			{
				gx.ajax.pushReferer();
			}
			this.URLChanged();
		}
	};
	
	this.getId = function(){
		return (this.ParentObject ? this.ParentObject.CmpContext || "" + "-" + this.ParentObject.ServerClass || "" : "") + "-" + this.ControlName;
	}
	
	this.AddHistoryPoint = function(pointId, fireUrlChangedEvent){
		if (gx.grid.drawAtServer)
			return;
		if (fireUrlChangedEvent === true){
			HistoryManager.AddHistoryPoint(pointId, false);
		}
		HistoryManager.AddHistoryPoint(pointId, true);
	};
	
	this.UpdateProperties = function(){
		if (gx.grid.drawAtServer)
			return;
		this.Hash = (document.location.hash.length > 0) ? document.location.hash.substr(1) : "";
		this.URL = document.location.href;
		this.QueryString = (document.location.search.length > 0) ? document.location.search.substr(1) : "";
	};
}

HistoryManager.listeners = {};

HistoryManager.listenerFn = function(){
	if (gx.grid.drawAtServer)
		return;
	for (var listener in HistoryManager.listeners){
		var fn = HistoryManager.listeners[listener];
		if (fn){
			fn();
		}
	}
}

HistoryManager.AddListener = function(inst){
	if (gx.grid.drawAtServer)
		return;
	HistoryManager.listeners[inst.getId()] = function(){
		inst.urlListener();
	};
};

HistoryManager.RemoveListener = function(inst){
	if (gx.grid.drawAtServer)
		return;
	delete HistoryManager.listeners[inst.getId()];
};

HistoryManager.AddHistoryPoint = function(anchor, avoidURLChangedEvent){
	if (gx.grid.drawAtServer)
		return;
	// anchor: History point identifier
	// avoidURLChangedEvent: Set to true if you want to avoid fireing the URLChanged event with the hash change. Set to false if you want to fire the URLChanged event.
	if (window.dhtmlHistory.isSupported){
		if (avoidURLChangedEvent)
			window.dhtmlHistory.add(anchor);
		else{
			if (window.dhtmlHistory.isIE){
				window.dhtmlHistory.ignoreLocationChange = true; // Set to true to avoid fireing the URLChanged event twice in IE.
			}
			document.location.hash = "#" + anchor;
		}

		return false;
	}
	else
		return true;
};