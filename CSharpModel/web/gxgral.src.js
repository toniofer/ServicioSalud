/* START OF FILE - gxapi.js - */
var gx = {
	O: null,
	pO: null,
	oldValues: [],
	oldKeyValues: [],
	newRows: [],
	suggestControls: [],
	disabledControls: [],
	usrFocusControl: '',
	currentRows: [],
	attachedControls: [],
	languageCode: 'eng',
	dateFormat: 'MDY',
	timeFormat: 12,
	blankWhenEmpty: false,
	centuryFirstYear: 40,
	decimalPoint: '.',
	thousandSeparator: ',',
	staticDirectory: '/',
	basePath: '',
	theme: '',
	msg: {},
	
	setParentObj: function( GxObj) {
		gx.pO = GxObj;
		gx.O = gx.pO;
	},
	
	setExecutableComponent: function( ObjType) {
		if (gx.pO == null)
		{
			gx.setParentObj( gx.createComponent( ObjType, ""));
		}
	},
	
	setMasterPage: function( MPage) {
		if (gx.pO != null)
		{
			gx.pO.MasterPage = MPage;
		}
	},
	
	addComponent: function( gxComp) {
		if (gx.pO != null)
		{
			gx.pO.setWebComponent( gxComp);
		}
	},
	
	createComponent: function( CmpType, CmpCtx) {
		var webComp = null;
		var cmpClass = gx.lang.getType(CmpType);
		if (cmpClass != null)
		{
			cmpClass.prototype = new gx.GxObject;
			var tCmp = gx.csv.cmpCtx;
			gx.csv.cmpCtx = CmpCtx;
			webComp = new cmpClass(CmpCtx);
			gx.csv.cmpCtx = tCmp;
		}
		return webComp;
	},
	
	getObj: function( CmpContext, IsMasterPage) {
		if (CmpContext == '')
		{
			if (IsMasterPage == true)
				return gx.pO.MasterPage;
			else
				return gx.pO;
		}
		else
			return gx.pO.getWebComponent(CmpContext);
	},
	
	setGxO: function( CmpContext, IsMasterPage) {
		gx.csv.cmpCtx = CmpContext;
		if (CmpContext == '')
		{
			if (IsMasterPage == true)
				gx.O = gx.pO.MasterPage;
			else
				gx.O = gx.pO;
		}
		else
			gx.O = gx.pO.getWebComponent(CmpContext);
	},
	
	setVar: function( VarName, Value) {
		gx.O.setVariable(VarName, Value);
	},
	
	getVar: function( VarName) {
		return gx.O.getVariable(VarName);
	},
	
	prefixVar: function(VarName) {
		return 'gx.O.' + VarName;
	},
	
	unprefixVar: function( pVarName) {
        var varRE = new RegExp("^(?:gx\.O\.)(.+)$");
		var isMatch = varRE.exec(pVarName);
		if (isMatch != null && isMatch[1])
		{
			pVarName =  isMatch[1];
		}
		else
		{
			varRE = new RegExp("^(?:.+)?\((?:gx\.O\.)([a-zA-Z0-9_]+)(?:,)?(?:.*)\)$");
			isMatch = varRE.exec(pVarName);
			if (isMatch != null && isMatch[2])
			{
				pVarName =  isMatch[2];
			}
		}
		return pVarName;
	},

	getMessage: function(code){
		if (gx.msg[code]== undefined) 
			return code;
		else 
			return gx.msg[code];
	},

	setLanguageCode: function( value) {
		gx.languageCode = value;
	},
	
	setDateFormat: function( value) {
		gx.dateFormat = value;
	},
	
	setTimeFormat: function( value) {
		gx.timeFormat = value;
	},
	
	setCenturyFirstYear: function( value) {
		gx.centuryFirstYear = value;
	},
	
	setBlankWhenEmptyDate: function(value) {
		gx.blankWhenEmpty = value;
	},

	setDecimalPoint: function( value) {
		gx.decimalPoint = value;
	},
	
	setThousandSeparator: function( value) {
		gx.thousandSeparator = value;
	},
	
	setStaticDirectory: function( value) {
		gx.staticDirectory = value;
		if (gx.staticDirectory == '')
		{
			gx.staticDirectory = '/';
		}
		else
		{
			var len = gx.staticDirectory.length;
			var addFBar = (gx.staticDirectory.charAt(0) != '/');
			var addLBar = (gx.staticDirectory.charAt(len - 1) != '/');
			
			gx.staticDirectory = ((addFBar?'/':'') + gx.staticDirectory + (addLBar?'/':''));
		}
	},
	
	setTheme: function() {
		this.theme = gx.fn.getHidden('GX_THEME');
		if (!this.theme)
		{
			this.theme = '';
		}
	},
	
	SetOld: function( Fld, Ctrl, Var) {
		var ctrlId = Ctrl;
		var GridId = gx.fn.controlGridId( Fld);
		if (GridId > 0)
		{
			ctrlId = Ctrl + '_' + gx.fn.currentGridRow(GridId);
		}
		gx.fn.setHidden( ctrlId, gx.getVar(Var));
	},
	
	Old: function( Fld, Ctrl) {
		try
		{
			var ctrlId = Ctrl;
	        var GridId = gx.fn.controlGridId( Fld);
	        if (GridId > 0)
		    {
			    ctrlId = Ctrl + '_' + gx.fn.currentGridRow(GridId);
			}
			var oldValue = gx.fn.getHidden(ctrlId);
			if (typeof(oldValue) == 'undefined' && (gx.O.CmpContext != ''))
			{
				oldValue = gx.fn.getHidden(gx.O.CmpContext + ctrlId);
			}
			return oldValue;
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxapi.js', 'Old');
		}
		return '';
	},
	
	OldInteger: function( Fld, Var) {
		var nIntVal = parseInt( gx.Old( Fld, Var),10);
		return isNaN( nIntVal) ? 0:nIntVal;
	},
	
	OldDecimal: function( Fld, Var) {
		var nDecVal = gx.num.parseFloat( gx.Old( Fld, Var), gx.thousandSeparator, gx.decimalPoint);
		return isNaN( nDecVal) ? 0:nDecVal;
	},
	
	OldDate: function( Fld, Var) {
		var gxD = new gx.date.gxdate( gx.Old( Fld, Var), 'Y4MD');
		return gxD.getStringWithFmt( gx.dateFormat);
	},
	
	OldDateTime: function( Fld, Var) {
		var gxD = new gx.date.gxdate( gx.Old( Fld, Var), 'Y4MD');
		return gxD.getStringWithFmt( gx.dateFormat) + ' ' + gxD.getTimeString(true, true);
	},
	
	typedOld: function( ctrlName, varName, type) {
		switch( type)
		{
			case 'int':
				return this.OldInteger( ctrlName, varName);
			case 'decimal':
				return this.OldDecimal( ctrlName, varName);
			case 'date':
				return this.OldDate( ctrlName, varName);
			case 'dtime':
				return this.OldDateTime( ctrlName, varName);
			default:
				return this.Old( ctrlName, varName);
		}
	},
	
	types: {
		numeric: 0,
		character: 1,
		date: 2,
		dateTime: 3,
		blob: 4,
		varChar: 5,
		longVarChar: 6,
		bool: 7
	},
	
	gen: {
		isDotNet: function() {
			return (location.pathname.indexOf(".aspx") != -1);
		}
	},
	
	dom: {
		_form: null,
		_avoidLeaksDiv: null,
		
		id: function( Control) {
			return ((Control.id == undefined || Control.id == '')? Control.name : Control.id);
		},
		
		byId: function( id) {
			return document.getElementById(id);
		},
		
		byName: function( name) {
			return document.getElementsByName(name);
		},
		
		byTag: function( name) {
			return document.getElementsByTagName(name);
		},
		
		el: function( id) {
			if ( id == '')
			{
				return null;
			}
			else
			{
				var ctrl = this.byId(id);
				if (ctrl != null)
				{
					return ctrl;
				}
				ctrl = this.byId( "span_"+id);
				if (ctrl != null)
				{
					return ctrl;
				}
				ctrl = this.byName( id);
				if (ctrl != null && ctrl.length > 0)
				{
					return ctrl[0];
				}
				return null;
			}
		},

		form: function() {
			if (this._form == null)
			{
				this._form = document.forms["MAINFORM"];
				if (!this._form)
					this._form = document.forms[0];
			}
			return this._form;
		},
		
		indexElements: function() {
			if (!document.all)
			{
				var els = this.form().elements;
				var len = els.length;
				for(var i=0;i<len;i++)
				{
					els[i].gxIndex = i;
				}
			}
		},
		
		setAttribute: function (Control, AttName, AttValue) {
            try{
                var Ctrls = gx.dom.byName(Control);
			    if (Ctrls != null && Ctrls.length > 0){
                    var rLen = Ctrls.length;
                    for (var i=0; i<rLen; i++)
                    {
                        Ctrls[i].setAttribute( AttName, AttValue);
                    }
                 }else
                 {
                    var Ctrl = gx.dom.byId(Control);
                    if (Ctrl!=null)
                        Ctrl.setAttribute( AttName, AttValue);
                 }
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxapi.js', 'setAttribute');
			}
		},
		
		createInput: function(ControlId, Type) {
			var newH = document.createElement("input");
			newH.type = Type;
			newH.id = ControlId;
			newH.name = ControlId;
			gx.dom.form().appendChild(newH);
		},
		
		hasSubmitControl: function() {
			var inputs = this.byTag("input");
			var len = inputs.length;
			if (!len)
				return false;
			for (var i=0; i<len; i++)
			{
				var iType = inputs[i].getAttribute('type');
				if ((iType == 'submit') || (iType == 'image'))
					return true;
			}
			return false;
		},
		
		scripts: function() {
			var docScripts = document.scripts;
			if (!docScripts)
				docScripts = document.getElementsByTagName("script");
			if (typeof(docScripts) != 'undefined')
			{
				var scripts = [];
				var len = docScripts.length;
				for (var i=0; i<len; i++)
				{
					var docScript = docScripts[i].attributes['src'];
					if (docScript && docScript.value)
					{
						docScript = docScript.value;
						if (docScript != '//:')
							scripts.push( docScript);
					}
				}
				return scripts;
			}
			return [];
		},
		
		styles: function() {
			var sheets = document.styleSheets;
			if (typeof(sheets) != 'undefined')
			{
				var styles = [];
				var len = sheets.length;
				for (var i=0; i<len; i++)
				{
					var sheet = sheets[i].href;
					if (!gx.lang.emptyObject(sheet))
						styles.push( sheet);
				}
				return styles;
			}
			return [];
		},
		
		getStyle: function( ctrl, key) {
			var value = '';
			try
			{
				if (typeof(window['getComputedStyle']) == 'function')
					value = window.getComputedStyle(ctrl, null)[key];
				else if (typeof(ctrl.currentStyle) != 'undefined')
					value = ctrl.currentStyle[key];
				else
					value = ctrl.style[key];
				var nValue = parseInt(value);
				if (!isNaN(nValue))
					value = nValue;
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxapi.js', 'getStyle');
			}
			return value;
		},
		
		isButton: function( Ctrl) {
			if(Ctrl != undefined && Ctrl != null)
				return (Ctrl.type == 'submit') || (Ctrl.type == 'button');
			return false;
		},
		
		forEachChild: function( control, ctx, func) {
			if (control && control.childNodes && typeof(func) == 'function')
			{
				var len = control.childNodes.length;
				for (var i=0; i<len; i++)
				{
					if (func.call( ctx, control.childNodes[i]) === false)
					{
						break;
					}
				}
			}
		},
		
		isTextWithLink: function( Control) {
			if (Control != null)
			{
				if ((Control.tagName == 'A') && Control.childNodes && (Control.childNodes.length > 0))
				{
					var childNode = Control.firstChild;
					if ( this.innerChildIsText( childNode))
						return true;
					
				}
			}
			return false;
		},
		
		isChildNode: function( Child, Parent) {
			if (Child.frameElement)
				Child = Child.frameElement;
			if (Child == Parent)
				return true;
			while (Child.parentNode)
			{
				if (Child == Parent)
					return true;
				if (Child.parentNode == Parent)
					return true;
				Child = Child.parentNode;
			}
			return false;
		},
		
		innerChildIsText: function( childNode) {
			while (childNode != null)
			{
				if (childNode.nodeName && (childNode.nodeName == '#text'))
					return true;
				childNode = childNode.firstChild;
			}
			return false;
		},
		
		position: function(el) {
			var left = 0;
			var top  = 0;
			while (el.offsetParent)
			{
				left += el.offsetLeft + (el.currentStyle?(gx.num.intval(el.currentStyle.borderLeftWidth)):0) - (el.scrollLeft?el.scrollLeft:0);
				top += el.offsetTop + (el.currentStyle?(gx.num.intval(el.currentStyle.borderTopWidth)):0) - (el.scrollTop?el.scrollTop:0);
				el = el.offsetParent;
			}
			left += el.offsetLeft + (el.currentStyle?(gx.num.intval(el.currentStyle.borderLeftWidth)):0) - (el.scrollLeft?el.scrollLeft:0);
			top += el.offsetTop + (el.currentStyle?(gx.num.intval(el.currentStyle.borderTopWidth)):0) - (el.scrollTop?el.scrollTop:0);
			return {x:left, y:top};
		},
		
		dimensions: function(el) {
			var eW = el.offsetWidth;
			var eH = el.offsetHeight;
			var childs = el.childNodes;
			if (!gx.util.browser.isIE() && !gx.lang.emptyObject(childs))
			{
				var len = childs.length;
				for (var i=0; i<len; i++)
				{
					var cW = childs[i].offsetWidth;
					var cH = childs[i].offsetHeight;
					if (cW > eW)
						eW = cW;
					if (cH > eH)
						eH = cH;
				}
			}
			return {w:eW, h:eH};
		},
		
		windowDimensions: function(frameDoc){
	        var doc = frameDoc.documentElement;
	        var body = frameDoc.body;
		    if (doc && doc.scrollHeight)
		    {
		        var sH = Math.max(doc.scrollHeight, body.scrollHeight);
		        var sW = Math.max(doc.scrollWidth, body.scrollWidth);
		        var cH = Math.max(doc.clientHeight, body.clientHeight);
		        var cW = Math.max(doc.clientWidth, body.clientWidth);
		        return {scrollWidth:sW, scrollHeight:sH, clientHeight:cH, clientWidth:cW};
		    }else
		    {
		        return {scrollWidth:body.scrollHeight, scrollHeight:body.scrollWidth,
		                clientHeight:body.clientHeight, clientWidth:body.clientWidth};
		    }
		},

		autofitIFrame: function(evt) {
			var loadEvt = window.event || evt;
			var frameCtrl = gx.evt.source(loadEvt);
			var frameDoc = window.frames[frameCtrl.name].document;
			var dims = gx.dom.windowDimensions(frameDoc);
			var docW = dims.scrollWidth;
			var docH = dims.scrollHeight;
			frameCtrl.style.width = docW + 'px';
			frameCtrl.style.height = docH + 'px';
		},
		
		fitToParent: function( ctrl) {
			if (!gx.util.browser.isIE())
			{
				if (ctrl && ctrl.childNodes)
				{
					var firstTable = null;
					var len  = ctrl.childNodes.length;
					for (var i=0; i<len; i++)
					{
						var elem = ctrl.childNodes[i];
						if (elem.nodeName == 'TABLE')
						{
							firstTable = elem;
							break;
						}
					}
					if (firstTable != null)
					{
						if (firstTable.style.width.indexOf('%') != -1)
							ctrl.style.width = firstTable.style.width;
						if (firstTable.style.height.indexOf('%') != -1)
							ctrl.style.height = firstTable.style.height;
					}
				}
			}
		},
		
		redrawControl: function( Control) {
			if (!gx.util.browser.isIE() || (gx.util.browser.ieVersion() >= 7))
				gx.html.setOuterHtml(Control, Control.outerHTML);
			else
				setTimeout( function() { gx.html.setOuterHtml(Control, Control.outerHTML); }, 100);
		},
		
		setCaretPosition: function(ctrl, pos) {
			if (ctrl != null)
			{
				if (ctrl.createTextRange)
				{
					var range = ctrl.createTextRange();
					range.move('character', pos);
					range.select();
				}
				else
				{
					if (ctrl.selectionStart)
					{
						ctrl.focus();
						ctrl.setSelectionRange(pos, pos);
					}
					else
					{
						ctrl.focus();
					}
				}
			}
		},
		
		spanValue: function(el) {
			var val = el.nodeValue;
			if (gx.lang.emptyObject(val))
				val = el.innerText;
			if (gx.lang.emptyObject(val))
				val = '';
			return val;
		},
		
		removeControlSafe: function( ctrl) {
			if (!this._avoidLeaksDiv)
			{
				this._avoidLeaksDiv = document.createElement('DIV');
				this._avoidLeaksDiv.style.display = 'none';
				document.body.appendChild(this._avoidLeaksDiv);
			}
			this._avoidLeaksDiv.appendChild(ctrl);
			this._avoidLeaksDiv.innerHTML = '';
		},
		
		removeControl: function( ctrl) {
			if (document.createRange == null)
				ctrl.removeNode( true);
			else
			{
				var range = document.createRange();
				if (ctrl)
				{
					range.selectNode( ctrl);
					range.deleteContents();
				}	
			}
		},
		
		controlToObj: function( Ctrl) {
			try
			{
				var obj = {s:'',v:[]}
				if (Ctrl.tagName == 'SELECT')
				{
					obj.s = Ctrl.value;
					var len = Ctrl.options.length;
					for (var i=0; i<len; i++)
					{
						var descText = '';
						if (typeof(Ctrl.options[i].innerText) != 'undefined')
							descText = Ctrl.options[i].innerText;
						else
							descText = Ctrl.options[i].text;
						obj.v.push([Ctrl.options[i].value, descText]);
					}
				}
				return obj;
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxapi.js', 'controlToObj');
			}
			return null;
		},
		
		_init: function() {
			Function.prototype.closure = function(obj, args)
			{
				if (!window.__objs)
				{
					window.__objs = [];
					window.__funs = [];
					window.__args = [];
				}
				var fun = this;
				var objId = obj.__objId;
				if (!objId)
					__objs[objId = obj.__objId = __objs.length] = obj;
				var funId = fun.__funId;
				if (!funId)
					__funs[funId = fun.__funId = __funs.length] = fun;
				if (!args)
					args = [];
				var argsId = fun.__argsId;
				if (!argsId)
					__args[argsId = fun.__argsId = __args.length] = args;
				obj = null;
				fun = null;
				args = null;
				return function () {
					if (!__funs)
						return;
					var funcArgs = __args[argsId];
					if (funcArgs.length == 0 && arguments.length > 0)
						funcArgs = arguments;
					var ret = __funs[funId].apply(__objs[objId], funcArgs);
					delete __objs[objId]['__objId'];
					delete __funs[funId]['__funId'];
					delete __funs[funId]['__argsId'];
					return ret;
				};
			};
		},
		
		_deinit: function() {
			this._form = null;
			if (this._avoidLeaksDiv != null)
			{
				this._avoidLeaksDiv.parentNode.removeChild(this._avoidLeaksDiv);
				this._avoidLeaksDiv = null;
			}
			window.__objs = null;
			window.__funs = null;
			window.__args = null;
		}
	},
	
	util: {
		contentTypes: {	"txt": "text/plain",
									"rtx": "text/richtext",
									"htm": "text/html",
									"html": "text/html",
									"xml": "text/xml",
									"aif": "audio/x-aiff",
									"au": "audio/basic",
									"wav": "audio/wav",
									"bmp": "image/bmp",
									"gif": "image/gif",
									"jpe": "image/jpeg",
									"jpeg": "image/jpeg",
									"jpg": "image/jpeg",
									"jfif": "image/pjpeg",
									"tif": "image/tiff",
									"tiff": "image/tiff",
									"png": "image/x-png",
									"mpg": "video/mpeg",
									"mpeg": "video/mpeg",
									"mov": "video/quicktime",
									"qt": "video/quicktime",
									"avi": "video/x-msvideo",
									"exe": "application/octet-stream",
									"dll": "application/x-msdownload",
									"ps": "application/postscript",
									"pdf": "application/pdf",
									"tgz": "application/x-compressed",
									"zip": "application/x-zip-compressed",
									"gz": "application/x-gzip"
		},
		
		isKnownContentType: function( cType)
		{
			for (var ext in this.contentTypes)
			{
				if (this.contentTypes[ext] == cType)
					return true;
			}
			return false;
		},
        
		getContentTypeFromExt: function( ext)
		{
			var dotIdx = ext.lastIndexOf('.');
			if (dotIdx != -1)
				ext = ext.substring(dotIdx+1);
			return this.getContentType(ext);
		},
        
		getContentType: function( ext)
		{
			if (gx.lang.emptyObject(ext))
				return 'text/html';
			ext = ext.toLowerCase();
			ext = gx.text.trim(ext);
			if (this.isKnownContentType(ext))
				return ext;
			var dotIdx = ext.lastIndexOf('.');
			if (dotIdx != -1)
				ext = ext.substring(dotIdx+1);
			var cType = this.contentTypes[ext];
			if (gx.lang.emptyObject(cType))
				return 'text/html';
			return cType;
		},
	
		browser: {
			w3c: true,
			ns4: false,
			ie5: true,
			ns6: false,
			ie: (navigator.userAgent.indexOf("MSIE") != -1),
			ff: (navigator.userAgent.indexOf("Firefox") != -1),
			winCE: (navigator.userAgent.indexOf("Windows CE") != -1),
			iphone: (navigator.userAgent.indexOf("iPhone") != -1),
			blackBerry: (navigator.userAgent.indexOf("BlackBerry") != -1),
			operaMini: (navigator.userAgent.indexOf("Opera Mini") != -1),
			chrome: (navigator.userAgent.indexOf("Chrome") != -1),
			
			isIE: function() {
				return this.ie;
			},
			
			isFirefox: function() {
				return this.ff;
			},
			
			isChrome: function() {
				return this.chrome;
			},

			isWinCE: function() {
				return this.winCE;
			},
			
			isIPhone: function() {
				return this.iphone;
			},
			
			isBlackBerry: function() {
				return this.blackBerry;
			},
			isOperaMini: function() {
				return this.operaMini;
			},
			
			isSmartDevice: function() {
				return this.isWinCE() || this.isIPhone() || this.isBlackBerry() || this.isOperaMini();
			},
			
			ieVersion: function() {
				if (this.isIE())
				{
					try
					{
						var ieIdx = navigator.userAgent.indexOf('MSIE');
						var cIdx = navigator.userAgent.indexOf(';', ieIdx);
						var version = navigator.userAgent.substring( ieIdx + 5, cIdx);
						return parseFloat( version, 10);
					}
					catch(e)
					{
						gx.dbg.logEx(e, 'gxapi.js', 'ieVersion');
					}
				}
				return -1;
			},
			
			setupFF: function() {
				if (this.isFirefox())
				{
					var _emptyTags = {
					   "IMG":   true,
					   "BR":    true,
					   "INPUT": true,
					   "META":  true,
					   "LINK":  true,
					   "PARAM": true,
					   "HR":    true
					};
					
					HTMLElement.prototype.__defineGetter__("outerHTML", function () {
					   var attrs = this.attributes;
					   var str = "<" + this.tagName;
					   var len = attrs.length;
					   for (var i = 0; i < len; i++)
					      str += " " + attrs[i].name + "=\"" + attrs[i].value + "\"";
					
					   if (_emptyTags[this.tagName])
					      return str + ">";
					
					   return str + ">" + this.innerHTML + "</" + this.tagName + ">";
					});
					
					HTMLElement.prototype.__defineSetter__("outerHTML", function (sHTML) {
					   var r = this.ownerDocument.createRange();
					   r.setStartBefore(this);
					   var df = r.createContextualFragment(sHTML);
					   this.parentNode.replaceChild(df, this);
					});
				}
			},
			
			_init: function() {
				if (!this.isWinCE())
				{
					this.w3c = (document.getElementById)? true: false;
					this.ns4 = (document.layers)?true:false;
					this.ie5 = (this.ie && document.getElementById && document.all)? true : false;
					this.ns6 = (document.getElementById && !document.all)? true: false;
				}
				this.setupFF();
			}
		},
		
		addOnce: function( O, Element, Key) {
			if (O[Key] == undefined)
					O[Key] = Element;
		},
		
		inArray: function( obj, arr) {
			if ((obj == null) || !(arr instanceof Array))
				return false;
			var len = arr.length;
			for (var i=0; i<len; i++)
			{
				if(arr[i] == obj)
					return true;
			}
			return false;
		},
		
		noParmsUrl: function( url) {
			var qIdx = url.indexOf('?');
			if (qIdx != -1)
				url = url.substring(0, qIdx);
			return url;
		},
		
		resourceUrl: function( path, notRelative) {
			if (typeof(path) == 'undefined')
				return '';
			if (path.indexOf('://') != -1 || path.charAt(0) == '.')
				return path;
			var len = gx.basePath.length;
			var addlBar = (gx.basePath.charAt(len - 1) != '/');
			var pathIdx = path.indexOf(gx.basePath);
			if (pathIdx == 0 && !notRelative)
       	     	 	   return ((path.charAt(0) == '/') ? '' : '/') + path;
			if ((pathIdx != -1) || notRelative)
			{
				var urlSuffix = '';
				if (pathIdx != -1)
					urlSuffix = gx.text.replaceAll(path.substring(pathIdx + gx.basePath.length),"\\","/");
				else
					urlSuffix = path;
				
				if (path.charAt(0) == '/')
				{
					return location.protocol+"//"+location.host+path;
				}
				else
				{
					var addfBar = (gx.basePath.charAt(0) != '/');
					addlBar = (addlBar && (urlSuffix.charAt(0) != '/'));
						
					return location.protocol+"//"+location.host+(addfBar?"/":"")+gx.basePath+(addlBar?"/":"")+urlSuffix;
				}
			}
			return path;
		},
		
		sameAppUrl: function( url) {
			url = new this.Url(url);
			if (url.isRelative())
			{
				return true;
			}
			return url.isSameApp(location.href);
		},
		
		removeBaseUrl: function( url) {
			var len = gx.staticDirectory.length;
			var addfBar = (gx.staticDirectory.charAt(0) != '/');
			var addlBar = (gx.staticDirectory.charAt(len - 1) != '/');
			var urlRegex = new RegExp('(?:/)?(?:' + gx.basePath + (addfBar?'/':'') + gx.staticDirectory + (addlBar?'/':'') + ')?((?:[\\S]*))');
			var realUrl = urlRegex.exec(url);
			if (realUrl != null && realUrl[1])
			{
				url = realUrl[1];
			}
			return url;
		},
		
		Url: function( url) {
			this.url = url;
			this.protocol = '';
			this.host = '';
			this.port = '';
			this.path = '';
			this.query = '';
			this.hash = '';
			this.user = '';
			
			function init( obj, url)
			{
				var urlRegex = /^(([^\:\/\?#]+)\:)?(\/\/([^\/\?#]*))?([^\?#]*)(\?([^#]*))?(#(.*))?$/;
				var urlParts = urlRegex.exec(url);
				var isMatch = !gx.lang.emptyObject(urlParts);
				if (isMatch)
				{
					obj.protocol = (urlParts[2]?urlParts[2]:'');
					var auth = (urlParts[4]?urlParts[4]:'');
					obj.path = (urlParts[5]?urlParts[5]:'');
					obj.query = (urlParts[7]?urlParts[7]:'');
					obj.hash = (urlParts[9]?urlParts[9]:'');
					urlRegex = /^(([^@]+)@)?([^\:]+)(:(.+))?$/;
					urlParts = urlRegex.exec(auth);
					isMatch = !gx.lang.emptyObject(urlParts);
					if (isMatch)
					{
						obj.user = (urlParts[2]?urlParts[2]:'');
						obj.host = (urlParts[3]?urlParts[3]:'');
						obj.port = (urlParts[5]?urlParts[5]:'');
					}
				}
			}
			
			this.isRelative = function()
			{
				return gx.lang.emptyObject(this.host);
			}

			this.isSameApp = function( url)
			{
				url = new gx.util.Url(url);
				return ((this.protocol == url.protocol) && (this.host == url.host));
			}
			
			init(this, url);
		},
		
		regExp: {		
			isMatch: function( str, rex) {
				var ret = new RegExp(rex).exec(str);
				return (ret !== null);
			},
			
			replace: function( str, rex, repl) {
				return str.replace(rex, repl);
			},
			
			split: function( str, rex) {
				return str.split(rex);
			},
			
			matches: function( str, rex) {
				var ret = new RegExp(rex).exec(str);
				if (ret !== null)
					return ret;
				else
					return [];
			}
		},
		
		autoRefresh: {
			arTimer: null,
			
			getProps: function() {
				var rfrTimeout = gx.fn.getHidden("_GxRefreshTimeout");
				if (rfrTimeout != null)
				{
					rfrTimeout = gx.json.evalJSON(rfrTimeout);
					rfrTimeout.Time = parseInt(rfrTimeout.Time);
				}
				return rfrTimeout;
			},
			
			install: function() {
				var rfrTimeout = this.getProps();
				if ( rfrTimeout != null)
				{
					this.create();
					if (rfrTimeout.Type == "focus")
						gx.evt.attach( window, "blur", this.destroy);
				}
			},
			
			create: function() {
				if (this.arTimer == null)
				{
					var rfrTimeout = this.getProps();
					if (rfrTimeout != null)
						this.arTimer = setTimeout(function() {gx.http.reload();}, rfrTimeout.Time*1000);
				}
			},
			
			destroy: function() {
				if (gx.util.autoRefresh.arTimer != null)
				{ 
					window.clearTimeout(gx.util.autoRefresh.arTimer); 
					gx.util.autoRefresh.arTimer = null;
				}
			}
		},
		
		accessKey: function( caption) {
			var aKey = '';
			if (caption.indexOf('&') != -1)
			{
				var len = caption.length;
				for (var i=0; i<len-1; i++)
				{
					if (caption[i] == '&' && caption[i+1] != '&')
					{
						aKey = aKey + caption[i+1];
						break;
					}
				}
			}
			return aKey;
		},
		
		accessKeyCaption: function( caption) {
			var dCapt = '';
			if (caption.indexOf('&') == -1)
				return caption;
			var len = caption.length;
			for (var i=0; i<len-1; i++)
			{
				if (caption[i] == '&' && caption[i+1] != '&')
				{
					dCapt += caption.substring(i+1);
					break;
				}
				else
					dCapt += caption[i];
			}
			return dCapt;
		},
		
		invalidFunc: function( strCode) {
			throw "gxInvalidFunc: " + strCode;	
		},
		
		urlValue: function( ctrl) {
			var value = ctrl;
			if (typeof(value) != 'string')
				value = gx.fn.getControlValueInt(ctrl);
			return encodeURIComponent( value);
		},
		
		help: function( urlfile) {
			open( urlfile, 'gxHelpWindow', 'toolbar=no,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no');
		},
		
		_init: function() {
			this.browser._init();
			Array.prototype.removeAt = function( idx) {
				this.splice(idx, 1);
			};
		}
	},

	lang: {
		inherits: function( subclass, superclass) {
			var oldProt = subclass.prototype;
			subclass.prototype = new superclass();
			for (var pName in oldProt)
			{
				if (typeof(subclass.prototype[pName]) == 'undefined')
					subclass.prototype[pName] = oldProt[pName];
			}
			if (typeof(subclass.prototype.base) == 'undefined')
				subclass.prototype.base = superclass;
		},
		
		instanceOf: function( obj, objClass) {
			if((obj == null) || (objClass == null))
				return false;
			if(obj instanceof objClass)
				return true;
			if((objClass == String) && (typeof(obj) == 'string'))
				return true;
			if((objClass == Number) && (typeof(obj) == 'number'))
				return true;
			if((objClass == Array) && (typeof(obj) == 'array'))
				return true;
			if((objClass == Function) && (typeof(obj) == 'function'))
				return true;
			if ((typeof(obj) == 'string') || (typeof(obj) == 'number') || (typeof(obj) == 'array'))
				return false;
			var base = obj.base;
			while(typeof(base) != 'undefined')
			{
				if(base == objClass)
					return true;
				base = base.base;
			}
			return false;
		},
		
		clone: function(obj) {
			var newObj = {};
			for (var prop in obj)
			{
				newObj[prop] = obj[prop];
			}
			return newObj;
		},

		isNumericType: function( type)
		{
			return type == 'int' || type == 'decimal';
		},
		
		isBooleanType: function( type)
		{
			return type == 'boolean' || type == 'bool';
		},
		
		booleanValue: function( obj) {
			if (obj == true || obj == false)
			{
				return obj;
			}
			else if (typeof(obj) == 'string')
			{
				if (obj.toLowerCase() == 'true')
					return true;
				else
					return false;
			}
			return false;
		},
		
		gxBoolean: function( obj) {
			if (typeof(obj) == 'undefined')
			{
				return false;
			}
			else if (typeof(obj) == 'boolean')
			{
				return obj;
			}
			else if (typeof(obj) == 'number')
			{
				if (obj == 0)
					return false;
			}
			else if (typeof(obj) == 'string')
			{
				if (obj.toLowerCase() == 'false')
					return false;
				else if (obj.replace(/^ */, '').replace(/ *$/, '') == '0')
					return false;
			}
			return true;
		},
		
		arrayToSource: function( Arr) {
			if (Arr.toSource != null)
				return Arr.toSource();
			var Result = "[";
			var len = Arr.length;
			var size = len - 1;
			for (var i=0; i<len; i++)
			{
				Result += this.objectToSource(Arr[i]);
				if (i < size)
					Result += ',';
		    }
			Result += ']';
			return Result;
		},
		
		objectToSource: function( Obj) {
			if (typeof( Obj) == "object")
			{
				var Result = '{';
				var Sep = '';
		   		for (var i in Obj)
		   		{
		   			var stri = i;
		   			if (stri=="")
		   			{
		   				stri = "\'\'";
		   			}
		   			else if (typeof(stri) == "string")
		   			{
		   				stri = "\'" + stri + "\'";
		   			}
		      		Result += Sep;
		      		if(typeof( Obj[i]) == "object")
		      			Result += stri + ':' + this.objectToSource(Obj[i]);
		      		else if (typeof( Obj[i]) == "string")
		      			Result += stri + ":\'" + this.encodeValue(Obj[i]) + "\'";
		      		else 
		      		    Result += stri + ':' + Obj[i];
		      		Sep = ',';
		      	}
		      	Result += '}';
		   		return Result;
			}
			return '\'' + this.encodeValue(Obj.toString()) + '\'';
		},
		
		emptyObject: function( obj) {
			if ((typeof(obj) == 'undefined') || (obj == null) || (obj == '') || (typeof(obj) == 'number' && isNaN(obj)))
				return true;
			return false;
		},
		
		supEval: function( obj, arr) {
			var fcn = null;
			if(arr instanceof String || typeof(arr) == 'string')
				fcn = obj[arr];
			else
				fcn = arr;
			return function() {
				return fcn.apply( obj, arguments);
			};
		},
		
		getType: function( typeName) {
			var typeObj = null;
			try { typeObj = eval(typeName); }
			catch(e)
			{
				gx.dbg.logEx(e, 'gxapi.js', 'getType');
			}
			return typeObj;
		},
		
		doEval: function( src, scope) {
			scope = scope || window;
			if (scope.execScript)
				return scope.execScript(src);
			else if (eval.call)
				return eval.call(scope, src);
			else
				return eval(src);
		},
		
		doCall: function() {
			try
			{
				var func = arguments[0];
				var args = [];
				var len = arguments.length;
				for (var i=1; i<len; i++)
				{
					args.push( arguments[i]);
				}
				func.apply( this, args);
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxapi.js', 'doCall');
			}
		},
		
		doCallTimeout: function( func, ctx, args, to) {
			setTimeout( func.closure( ctx, args), to);
		},
		
		encodeValue: function( Value) {
			return gx.text.charReplace( Value, ['"',"'",'\r','\n'], ['\\042','\\047','\\015','\\012']);
		},
		
		decodeValue: function( Value) {
			Value = gx.text.replaceAll(Value, "\\042", "\"");
			return gx.text.replaceAll(Value, "\\015\\012", "\r\n");
		}
	},
	
	cache: {
		remoteFiles: [],
		inlineCode: [],
		
		addRemoteFile: function( file) {
			file = gx.util.noParmsUrl(file);
			var fileUrl = gx.util.resourceUrl(file, true);
			this.remoteFiles[fileUrl] = true;
		},
		
		addLoadedFile: function( file) {
			file = gx.util.noParmsUrl(file);
			var fileUrl = gx.util.resourceUrl(file, true);
			this.remoteFiles[fileUrl] = true;
		},
		
		removeRemoteFile: function( file) {
			file = gx.util.noParmsUrl(file);
			var fileUrl = gx.util.resourceUrl(file, true);
			this.remoteFiles[fileUrl] = false;
		},
		
		fileLoaded: function( file) {
			file = gx.util.noParmsUrl(file);
			var fileUrl = gx.util.resourceUrl(file, true);
			if (this.remoteFiles[fileUrl])
				return true;
			return false;
		},
		
		updateStyles: function( olds, news) {
			var deleted = [];
			var len = olds.length;
			for (var i=0; i<len; i++)
			{
				var sheet = olds[i];
				if (!gx.lang.emptyObject(sheet))
				{
					var found = false;
					var len1 = news.length;
					for (var j=0; j<len1; j++)
					{
						if (sheet == news[j])
						{
							found = true;
							break;
						}
					}
					if (!found)
						deleted.push( sheet);
				}
			}
			var imgsDir = gx.staticDirectory;
			if (imgsDir.charAt(0) == '/')
				imgsDir = imgsDir.substring(1);
			len = deleted.length;
			for (var i=0; i<len; i++)
			{
				var sheet = deleted[i];
				if (sheet.charAt(0) != '/')
					sheet = imgsDir + sheet;
				this.removeRemoteFile( sheet);
			}
		},
		
		addInlineCode: function( obj) {
			this.inlineCode[obj] = true;
		},
		
		codeLoaded: function( obj) {
			if (this.inlineCode[obj])
				return true;
			return false;
		},

		_init: function() {
			var imgsDir = gx.staticDirectory;
			if (imgsDir.charAt(0) == '/')
				imgsDir = imgsDir.substring(1);
			var scripts = gx.dom.scripts();
			var len = scripts.length;
			for (var i=0; i<len; i++)
			{
				var docScript = scripts[i];
				if (!gx.lang.emptyObject(docScript))
				{
					if (docScript.charAt(0) != '/' && !gx.ajax.isabsoluteurl(docScript))
						docScript = imgsDir + docScript;
					this.addRemoteFile(docScript);
				}
			}
			var styles = gx.dom.styles();
			var len = styles.length;
			for (var i=0; i<len; i++)
			{
				var sheet = styles[i];
				if (!gx.lang.emptyObject(sheet))
				{
					if (sheet.charAt(0) != '/' && !gx.ajax.isabsoluteurl(sheet))
						sheet = imgsDir + sheet;
					this.addRemoteFile(sheet);
				}
			}
		}
	},
	
	evt: {
		enter: false,
		lastKey: -1,
		lastControl: null,
		lastEvent: null,
		dummyCtrl: {},
		keyListeners: {},
		shiftPressed: false,
		execLoad: true,
		autoSkip: false,
		hooks: [],
		controlKeys: [0x03, 0x06, 0x08, 0x09, 0x0C, 0x0D, 0x0E, 0x10, 0x11, 0x12, 0x13, 0x14, 0x1B, 0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x2C, 0x2D, 0x2E],
		triggerKeys: [13,32],
		processing: true,
		userReady: false,
		
		addHook: function( obj, evt, handler) {
			this.hooks[this.hooks.length] = {c:obj, e:evt, f:handler};
		},
		
		clearHooks: function() {
			var len = this.hooks.length;
			for (var i =0; i<len; i++)
			{
				var hook = this.hooks[i];
				this.detach( hook.c, hook.e, hook.f);
				hook.c = null;
				hook.f = null;
				this.hooks[i] = null;
				hook = null;
			}
			this.hooks = [];
		},
		
		source: function( evt) {
			return (evt.target || evt.currentTarget || evt.srcElement);
		},
	
		attach: function( obj, evt, handler) {
			if (obj.attachEvent)
				obj.attachEvent('on' + evt, handler);
			else if (obj.addEventListener)
				obj.addEventListener(evt, handler, false);
			else
				obj['on' + evt] = handler;
			this.addHook( obj, evt, handler);
		},
		
		detach: function( obj, evt, handler) {
			if (obj.detachEvent)
				obj.detachEvent('on' + evt, handler);
			else if (obj.removeEventListener)
				obj.removeEventListener(evt, handler, false);
			else
				obj['on' + evt] = null;
		},
		
		cancel: function( evt, cancel) {
			if (cancel && gx.util.browser.isIE() && typeof(evt.keyCode != 'undefined'))
			{
				try { evt.keyCode = 0; } catch(e) {}
			}
			if (typeof(evt.preventDefault) == 'undefined')
			{
				evt.cancelBubble = cancel;
				evt.returnValue = !cancel;
			}
			else
			{				
				if (cancel)
				{
					evt.preventDefault();
					evt.stopPropagation();
				}
			}
		},
		
		checkCtrlFocus: function( Control) {
			try
			{
				if (gx.util.browser.isChrome() && Control.type == 'button')
				{
					if (gx.fn.isAccepted( Control))
					{
						if (Control.onfocus != undefined) {Control.onfocus();}
					}
				}
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxapi.js', 'checkCtrlFocus');
			}
		},
		
		doClick: function(ControlId, Event) {
			var eventSource = gx.evt.source(Event);
			if (eventSource.type != 'button' && eventSource.type != 'submit')
			{
				var Control = gx.dom.el( ControlId);
				if (gx.fn.isAccepted( Control))
				{
					if (Control.onfocus != undefined) {Control.onfocus();}
					if (Control.onclick != undefined) {Control.onclick();}
					if (Control.nodeName == 'INPUT' && Control.type == 'submit')
					{
						gx.dom.form().submit();
					}
				}
			}
		},
		
		executeOnblur: function(gxCurrentFocusControl) {
			var gxLastFocusCtrl = gx.csv.lastId;
			var gxFocusCtrl = gx.csv.focusControl;
			
			gx.csv.focusControl = gxCurrentFocusControl;
			this.onblur(gx.csv.focusControl);
			
			gx.csv.focusControl = gxFocusCtrl;
			gx.csv.lastId = gxLastFocusCtrl;
		},
		
		onblur: function(gxLastFocusCtrl) {
			gx.csv.lastId = gxLastFocusCtrl;
			try
			{
				var vStruct = gx.fn.validStruct(gxLastFocusCtrl);
				if (vStruct && vStruct.gxgrid != null)
					vStruct.gxgrid.updateControlValue( vStruct, false);
				var Elem = gx.csv.lastControl;
				var MaxLength = Elem.getAttribute("maxlength");
				if ( MaxLength > 0 && Elem.value.length >= MaxLength)
					Elem.value = Elem.value.substring( 0, MaxLength)
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxapi.js', 'onblur');
			}
		},
		
		onfocus: function(Ctrl, gxFocusCtrl, gxWCP, gxInMasterPage, gxCurrentRow, gxCurrentGrid, gxAddLines) {
			gx.evt.userReady = false;
			if (!gx.fn.checkPopupFocus( Ctrl))
			{
				gx.evt.userReady = true;
				return false;
			}
		  gx.fn.initOld(Ctrl);
			try
			{
				if(gx.grid.lastFocusCtrl != null)
				{
					gx.csv.lastId = gx.grid.lastFocusCtrl;
					gx.grid.lastFocusCtrl = null;
				}
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxapi.js', 'onfocus');
			}
			gx.csv.rowChanged = false;
			gx.csv.lastControl = Ctrl;
			gx.fx.installSuggest(Ctrl);
			if (gxCurrentGrid == 0 || gxCurrentRow != '')
			{
				gx.fn.setCurrentGridRow(gxCurrentGrid, gxCurrentRow);
			}
			var NewComponentContext = false;
			var gridChange = false;
			if (gx.csv.lastGrid != gxCurrentGrid)
			{
				gx.csv.lastRow[gxCurrentGrid] = null;
				if(!gxAddLines)
				{
					if (gx.csv.lastGrid < gxCurrentGrid)
					{
						var firstGridCtrl = gx.fn.firstGridControl( gxCurrentGrid);
						if(gx.csv.fromValid > firstGridCtrl)
							gx.csv.fromValid = firstGridCtrl;
					}
					gx.csv.lastGrid = gxCurrentGrid;
				}
				gridChange = true;
			}
			gx.setGxO( gxWCP, gxInMasterPage);
			if (gx.csv.cmpCtx != gxWCP)
			{
				NewComponentContext = true;
				gx.csv.fromValid = 0;
			}
			if (NewComponentContext)
				gx.fn.changeCmpContext();
			gx.csv.focusControl = gxFocusCtrl;
			if (!gx.csv.onloadFocus)
			{
				try { gx.fx.ctx.notify( Ctrl);}
				catch(e)
				{
					gx.dbg.logEx(e, 'gxapi.js', 'onfocus');
				}
			}
			if (gx.csv.disableFocus)
			{
				gx.csv.disableFocus = false;
				gx.evt.userReady = true;
				return true;
			}
			try
			{
				var cMode = gx.fn.getControlValue("Mode");
				if (cMode == 'DLT' || cMode == 'DSP')
				{
					gx.evt.userReady = true;
					return true;
				}
				if (gx.O.isTransaction() && gx.dom.isButton( Ctrl) && !gx.evt.isEnterEvtCtrl(Ctrl) && !gx.evt.isCheckEvtCtrl(Ctrl) && !gxAddLines)
				{
					gx.evt.userReady = true;
					return true;	
				}
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxapi.js', 'onfocus');
			}
		
			if ( gx.O.isTransaction())
			{
				if(Ctrl.gxdisabled && gx.csv.lastControl != null)
				{
					cn = gx.fn.getControlIndex(Ctrl) + 1;
					if(cn != -1)
					{
						NextFocus = gx.fn.searchFocusFwd(cn);
						if(NextFocus != null)
						{
							gx.fn.setFocus( NextFocus);
							gx.evt.userReady = true;
							return true;	
						}
					}
					gx.fn.setFocus( gx.csv.lastControl);
					gx.evt.userReady = true;
					return true;	
				}
			}
			
			if (gx.csv.invalidForcedCtrl)
			{
				gx.fn.setFocus( gx.csv.invalidForcedCtrl);
				gx.csv.invalidForcedCtrl = null;
				gx.evt.userReady = true;
				return true;	
			}
			if (gx.csv.invalidControl != null && gx.csv.invalidControl != Ctrl && gx.csv.focusControl >= gx.csv.invalidId)
			{
				if (gx.csv.invalidControl == Ctrl && gx.csv.validate( gx.csv.invalidControl, gx.csv.invalidId, false))
				{
					gx.csv.invalidControl = null;
					gx.evt.userReady = true;
					return true;
				}
			}
			if(gxAddLines)
			{
				gx.csv.fromValid = gx.fn.firstGridControl( gx.csv.lastGrid);
				gx.csv.toValid = gx.fn.firstCtrlAfterGrid( gx.csv.fromValid, gx.csv.lastGrid);
				gx.csv.focusControl = gx.csv.toValid;
			}
			else
			{
				gx.csv.toValid = gx.csv.focusControl;
				if (gx.csv.focusControl < gx.csv.fromValid)
				{
					gx.csv.fromValid = gx.csv.focusControl;
				}
			}
			if ((gx.csv.lastRow[gxCurrentGrid] != undefined) && (gx.csv.lastRow[gxCurrentGrid] != gxCurrentRow) && !gridChange)
			{
				if (gx.csv.fromValid == gx.csv.toValid)
					gx.csv.lastId = gx.csv.fromValid;
			}
			var allIds = gx.fn.controlIds();
			if (allIds.length > 0)
			{
				if (gx.csv.fromValid < allIds[0])
					gx.csv.fromValid = allIds[0];
			}
			if(gx.lang.emptyObject(gx.csv.lastRow[gxCurrentGrid]) && gxCurrentGrid != 0)
			{
				gx.csv.rowChanged = true;
				gx.csv.lastRow[gxCurrentGrid] = gxCurrentRow;
			}
			var rowValidated = gx.csv.checkRowChange( gx.csv.lastId);
			
			 var goForwardInGrids = false;
			 if (!gx.lang.emptyObject(gx.csv.lastRow[gxCurrentGrid]) && !gx.lang.emptyObject(gxCurrentRow) && gx.csv.lastRow[gxCurrentGrid].length > gxCurrentRow.length)
			 {
			    var currRowLen = gxCurrentRow.length;
			    var lastRowParent = gx.csv.lastRow[gxCurrentGrid].substring((gx.csv.lastRow[gxCurrentGrid]).length - currRowLen);
			    goForwardInGrids = parseInt(lastRowParent) < parseInt(gxCurrentRow);
			 }
			  
			if (!rowValidated && ( gx.csv.focusControl >= gx.csv.lastId  || goForwardInGrids))
				gx.csv.validateAll();
			else
				gx.csv.toValid = gx.csv.focusControl;
			if (gx.csv.invalidControl == null)
			{
				if (Ctrl.nodeName == 'SELECT')
				{
					if (!gx.util.browser.isIE() || gx.util.browser.ieVersion() >= 7)
					{
						gx.fn.setSelection( Ctrl);
					}
				}
				else
				{
					gx.fn.setSelection( Ctrl);
				}
			}
            gx.csv.disableFocusCondition();
            gx.evt.userReady = true;
			return false;
		},
		
		userOnload: function() {
			try
			{
				if (typeof(window['GXOnloadUsr']) == 'function')
				{
					GXOnloadUsr();
				}
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxapi.js', 'userOnload');
			}
		},
		
		onload: function() {
			if (!gx.evt.execLoad)
				return;
			gx.fx.obs.notify('gx.onready');				
			gx.sec.loadKey();
			gx.setTheme();
			gx.ajax._init();
			gx.grid._init();
			gx.evt.attach( window, 'unload', gx.evt.onunload);
			gx.csv.lastActiveControl = window.document.activeElement;
			if (!gx.csv.lastActiveControl)
				gx.csv.lastActiveControl = gx.csv.lastControl;
			gx.fx.delayedSuggest();
			gx.http.notification.node();
			gx.cache._init();
			gx.fn.installComponents();
			gx.http.loadStyles();
			gx.fn.objectOnload();
			gx.dom.indexElements();
			gx.fn.doAttachs();
			document.gxReadyState = 'complete';
			gx.util.autoRefresh.install();
			if (!gx.util.browser.isIE())
				gx.fn.setOpacity(100, 'body');
			setTimeout(function() {gx.fn.setFocusOnload();}, 100);
			gx.evt.setProcessing(false);
			gx.fx.obs.notify('gx.onload');
			gx.evt.userOnload();
			gx.http.doCommands();
			gx.evt.userReady = true;
		},
		
		onready: function( event) {
			if (gx.lang.emptyObject(event))
			{
				if (document.readyState == 'complete')
					gx.evt.onload();
				else
					setTimeout(function() { gx.evt.onready(null); }, 250);
			}
			else if (gx.util.browser.isIE())
			{
				if (document.readyState == 'complete')
					gx.evt.onload();
			}
			else if (gx.util.browser.isFirefox())
			{
				gx.evt.onload();
			}
		},
		
		on_ready:function( context, fnc) {
			gx.fx.obs.addObserver( 'gx.onload', context, fnc);
		},

		onunload: function() {
			gx.http.saveState(true);
			gx.evt.clearHooks();
			gx.fx.obs.removeAll();
			gx.http.notification.cleanup();
			gx.fn.objectOnUnload();
			gx._deinit();
		},
		
		onclick: function( evt) {
			gx.evt.userReady = false;
			gx.evt.mouse.update( evt);
			gx.fx.ctx.notify();
			gx.evt.userReady = true;
		},
		 
		onmousedown: function( evt) {
			gx.evt.mouse.update( evt);
			var dnd = gx.fx.dnd;
			var evtObj = window.event || evt;
			dnd.deleteClonControl();
			var dragSource = dnd.getSource(evtObj);
			if ( dragSource != null)
			{
				gx.evt.cancel( evtObj, true);
				gx.setGxO( dragSource.obj.CmpContext, dragSource.obj.IsMasterPage);
				dnd.drag( dragSource.obj, dragSource.types, dragSource.hdl);
			}
		},
		
		onmousemove: function( evt) {
			gx.evt.mouse.update( evt);
			var dnd = gx.fx.dnd;
			var isIE = gx.util.browser.isIE();
			if( gx.popup.ispopup())
			{
				var pExt = gx.popup.ext;
				pExt.movepopup();
				if((pExt.currIDb!=null)||(pExt.currRS!=null))
				{
					return false;
				}
			}
			if (dnd.obj != null)
			{
				var evtObj = window.event || evt;
				gx.evt.cancel( evtObj, true);
				var dropTarget = gx.fx.dnd.getTarget( evtObj, dnd.obj.gxDragTypes);
				if ( dropTarget != null)
					dnd.over();
				dnd.moveControl(dnd.dragCtrl);
			}
		},
		
		onmouseup: function( evt) {
			gx.evt.mouse.update( evt);
			var dnd = gx.fx.dnd;
			if (dnd.dragCtrl != null)
			{
				var evtObj = window.event || evt;
				var dropTarget = dnd.getTarget( evtObj, dnd.obj.gxDragTypes);
				if ( dropTarget != null)
				{
					dnd.deleteClonControl();
					gx.setGxO( dropTarget.obj.CmpContext, dropTarget.obj.IsMasterPage);
					dnd.drop( dnd.dropCtrl, dropTarget.obj, dropTarget.hdl);
				}
				else
				{
					dnd.restoreControl();
				}
				var evtObj = window.event || evt;
				gx.evt.cancel( evtObj, true);
			}
			dnd.out();
			dnd.dragCtrl = null;
			dnd.obj = null;
			if( gx.popup.ispopup())
			{
				gx.popup.ext.currRS=null;
			}
		},
		
		ondblclick: function( evt) {
			gx.evt.mouse.update( evt);
			var evtObj = window.event || evt;
			gx.fx.dom.raiseEvent( 'dblclick', evtObj);
		},
		
		onwindowblur: function( evt) {
			gx.fx.dnd.deleteClonControl();
		},
		
		onkeypress: function(xevent, hasenter, skiponenter) {
			if ((xevent==null) && (!window.event)) { return; }
			if ((xevent!=null) && (window.event)) { return; }
			var event = (xevent==null ? window.event : xevent);
			
			if (event.keyCode == 27) //ESC
			{
				if (gx.popup.ispopup())
				{
					gx.fn.closeWindow();
					return;
				}
			}
			
			if (gx.O.isTransaction() && gx.O.Gx_mode == 'DSP' && this.invalidDSPKey(event))
			{
				this.cancel( event, true);
				return false;
			}

			this.lastKey = event.keyCode;
			this.shiftPressed = event.shiftKey;
			var ctrlPressed = event.ctrlKey;
			
			var Ctrl = gx.evt.source(event) || document.activeElement || gx.csv.lastControl;
			
			gx.csv.invalidateCtrl(Ctrl, event);
			
			if (this.isEnterEvtCtrl( Ctrl) && this.isTriggerKey( event))
			{
				if (this.cancelAndRefresh( event))
					return;
			}
			
			this.checkFuncKey(event);
			
			if (event.keyCode == 13)
			{
				if (Ctrl.value && gx.util.browser.isIE()) 
				{
					var tmpValue = Ctrl.value;
					Ctrl.value = "";
					Ctrl.value = tmpValue;
				}				
				var triggersEvt = this.triggersEvt( Ctrl);
				if (skiponenter)
				{
					if (gx.fn.enterHasFocus())
						gx.O.executeEnterEvent(event, Ctrl);
					else if (ctrlPressed && (Ctrl.nodeName == 'TEXTAREA'))
					{
						Ctrl.value += '\n';
						gx.dom.setCaretPosition( Ctrl, Ctrl.value.length);
						return;
					}
					else
					{
						gx.fn.skipFocus(skiponenter);
						this.cancel(event, true);
						this.enter = false;
					}
				}
				else if (!triggersEvt)
				{
					gx.O.executeEnterEvent(event, Ctrl);
				}
			}
		},
		
		onkeyup: function(domevent) {
			var event = window.event?window.event:domevent;
			var evel = gx.evt.source(event);
			var maxlen = evel.getAttribute("maxlength");
			var value = typeof(evel.value)=="undefined"?"":evel.value;
			if ((evel.type == "" && this.lastKey == 9) || ( this.autoSkip && evel.type != "" && !this.isControlKey(this.lastKey) && value.length >= maxlen))
			{
				if (gx.dom.isTextWithLink( evel))
				{
					return;
				}
				var ctrlFocuseable = evel.getAttribute('gxfocusable');
				if (ctrlFocuseable!= null && ctrlFocuseable == '1')
				{
					return;
				}
				var el = gx.fn.getControlIndex( gx.csv.invalidControl?gx.csv.invalidControl:gx.csv.lastControl);
				if (el == -1)
					return true;
				var Control = gx.fn.searchFocus( this.shiftPressed?el-1:el+1, !this.shiftPressed);
				gx.fn.setFocus( Control);
			}
		},
		
		setEventRow: function( GxObj, Control) {
			var ctrlGrid = gx.fn.rowGridId( Control);
			var ctrlRow = gx.fn.controlRowId( Control) || gx.fn.currentGridRowImpl(ctrlGrid) || '0001';
			if ((ctrlGrid != null) && (ctrlRow != null))
			{
				if (Control.gxGridName != undefined)
				{
					gx.fn.setHidden(GxObj.CmpContext + Control.gxGridName.toUpperCase() + "_ROW", ctrlRow);
				}
				gx.csv.lastEvtRow = ctrlRow;
				gx.fn.setCurrentGridRow( ctrlGrid, ctrlRow);
			}
		},
		
		ctrlOnchange: function( Mode, IsConfirmed, IsKey, Button, sIdiom) {
			gx.csv.pkDirty = IsKey;
			if (Mode.value == "UPD")
			{
				if (IsConfirmed.value == "1")
				{
					if (IsKey)
					{
						if (Button != null)
							Button.value = gx.getMessage("GXM_captionadd");
					}
					else
					{
						if (Button != null)
							Button.value = gx.getMessage("GXM_captionupdate");
					}
					IsConfirmed.value = "0";
				}
				else
				{
					if (IsKey)
					{
						if (Button != null)
							Button.value = gx.getMessage("GXM_captionadd");
					}
				}
			}
			else if (Mode.value == "INS")
			{
				if (IsConfirmed.value == "1")
				{
					if (Button != null)
						Button.value = gx.getMessage("GXM_captionadd");
					IsConfirmed.value = "0";
				}
			}
		},
		
		onchange: function(Ctrl) { 	
			gx.evt.userReady = false;
			gx.evt.lastControl = Ctrl;
			var CtrlValue = gx.fn.getControlValue( gx.dom.id(Ctrl));
			if (Ctrl.getAttribute( "gxoldvalue") != CtrlValue)
			{
			  gx.fn.setControlValue( "IsModified", "1");
				var jsCode = ''; 
				var bRet = true;
				var vStruct = gx.O.getValidStruct(gx.csv.focusControl);
				if (vStruct)
				{
					vStruct.c2v();
					if (typeof(vStruct.v2bc) == 'function')
						vStruct.v2bc.call(gx.O);
				}
				if (Ctrl.type == "select-one" || Ctrl.type == "checkbox" || Ctrl.type == "radio")
				{
					if (gx.csv.validate( Ctrl, gx.csv.focusControl, true))
					{
						if (gx.csv.invalidControl == Ctrl)
							gx.csv.invalidControl = null;
					}
					else
						bRet = false;
				}
				if (Ctrl.type == "radio")
				{
					var radios = gx.dom.byName(gx.dom.id(Ctrl));
					var rLen = radios.length;
					for (var i=0; i<rLen; i++)
					{
						radios[i].setAttribute( "gxoldvalue", CtrlValue);
					}
				}
				else
				{
					Ctrl.setAttribute( "gxoldvalue", CtrlValue);
				}
				if (bRet)
				{
					gx.evt.execOnchange( Ctrl);
				}
			}
			var usrChg = gx.evt.execUsrOnchange( Ctrl);
			gx.evt.userReady = true;
			return usrChg;
		},
		
		execOnchange: function( Ctrl) {
			var jsCode = ''; 
			if (Ctrl.attributes["gxoch1"])
			{
				try{jsCode += Ctrl.attributes["gxoch1"].value + ';';}
				catch(e)
				{
					gx.dbg.logEx(e, 'gxapi.js', 'execOnchange');
				}
			}
			if (gx.fn.isAccepted( Ctrl) && Ctrl.attributes["gxoch2"])
			{
				try{jsCode += Ctrl.attributes["gxoch2"].value + ';';}
				catch(e)
				{
					gx.dbg.logEx(e, 'gxapi.js', 'execOnchange');
				}
			}
			try
			{
				if (jsCode != '')
					eval( jsCode);
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxapi.js', 'execOnchange');
			}
			Ctrl.setAttribute( "gxvalid", "0");
			Ctrl.setAttribute( "gxctrlchanged", '1');
		},
		
		execUsrOnchange: function( Ctrl) {
			var jsCode = '';
			try{jsCode = Ctrl.attributes["gxoch0"].value;} 
			catch(e)
			{
				return true;
			}
			var fnc = new Function(jsCode);
			var ret = fnc.call(Ctrl);
			return ret;
		},
		
		jsEvent: function( ctrl) {
			var evtCode = ctrl.getAttribute?ctrl.getAttribute('jsevent'):ctrl.jsevent;
			if (!gx.lang.emptyObject(evtCode))
			{
				return eval(evtCode);
			}
			return true;
		},
		
		isEnterEvtCtrl: function( ctrl) {
			if (!gx.lang.emptyObject(gx.O.EnterCtrl))
			{
				var ctrlName = gx.dom.id(ctrl);
				for (var c in gx.O.EnterCtrl)
				{
					if (gx.O.EnterCtrl[c] == ctrlName)
						return true;
					if ((gx.O.CmpContext + gx.O.EnterCtrl[c]) == ctrlName)
						return true;
				}
			}
			return false;
		},
		
		isCheckEvtCtrl: function( ctrl) {
			if (!gx.lang.emptyObject(gx.O.CheckCtrl))
			{
				var ctrlName = gx.dom.id(ctrl);
				for (var c in gx.O.CheckCtrl)
				{
					if (gx.O.CheckCtrl[c]== ctrlName)
						return true;
					if ((gx.O.CmpContext + gx.O.CheckCtrl[c]) == ctrlName)
						return true;
				}
			}
			return false;
		},
		
		isTriggerKey: function( event) {
			var len = this.triggerKeys.length;
			for (var i=0; i<len; i++)
			{
				if ((event.keyCode == this.triggerKeys[i]) || (event.charCode == this.triggerKeys[i]))
					return true;
			}
			return false;
		},
		
		isControlKey: function( key) {
			var len = this.controlKeys.length;
			for (var i=0; i<len; i++)
			{
				if (key == this.controlKeys[i])
					return true;
			}
			return false;
		},
		
		invalidDSPKey: function( evt) {
			if (evt.keyCode == 13)
			{
				return true;
			}
			return false;
		},
		
		addKeyListener: function( cmpCtx, key, evt) {
			if (key == 1)
				document.body.onhelp = function() {return false;}
			if (this.keyListeners[key] == undefined)
				this.keyListeners[key] = [];
			this.keyListeners[key][cmpCtx] = evt;
		},
		
		setEvtName: function( evt, ctrl) {
			gx.fn.setHidden("_EventName", evt);
		},
		
		cancelAndRefresh: function( evt) {
			if (gx.O.conditionsChanged)
			{
				this.cancel( evt, true);
				gx.O.executeServerEvent( 'RFR', true);
				return true;
			}
			return false;
		},
		
		setGridEvt: function( gridId, rowId) {
			if (!gx.lang.emptyObject(gridId))
			{
				if (gx.lang.emptyObject(rowId))
				{
					var gridObj = gx.fn.getGridObj(gridId);
					if (gridObj)
					{
						rowId = gx.fn.getHidden(gx.O.CmpContext + gridObj.gridName.toUpperCase() + "_ROW");
					}
				}
				gx.fn.setHidden("_EventGridId", gridId);
				gx.fn.setHidden("_EventRowId", rowId);
				gx.fn.setCurrentGridRow(gridId, rowId);
			}
		},
		
		checkFuncKey: function( evt) {
			var fKey = this.lastKey - 111;
			if (fKey > 0 && fKey <= 12 && (this.keyListeners[fKey] != undefined))
			{
				var gxEvent = this.keyListeners[fKey][gx.O.CmpContext];
				if(typeof(gxEvent) != 'undefined')
				{
					this.execFnKeyEvt( evt, gx.O, gxEvent);
				}
				else
				{
					for (var cmpCtx in this.keyListeners[fKey])
					{
						gxEvent = this.keyListeners[fKey][cmpCtx];
						if(typeof(gxEvent) != 'undefined')
						{
							var gxObj = gx.getObj( cmpCtx, false);
							if (gxObj != null)
							{
								this.execFnKeyEvt( evt, gxObj, gxEvent);
								break;
							}
						}
					}
				}
			}
		},
		
		execFnKeyEvt: function(evt, gxObj, gxEvent) {
			if (gx.evt.processing)
				return;
			this.cancel(evt, true);
			if (typeof(gxObj[gxEvent]) == 'function')
			{
				var isServerEvent = gxObj.isServerEvent(gxEvent);
				gx.evt.setProcessing(true, !isServerEvent);
				gxObj[gxEvent].call(gxObj);
				gx.evt.setProcessing(false, !isServerEvent);
			}
			else
			{
				gx.evt.execEvt( gxObj.CmpContext + 'E' + gxEvent + '.', gx.evt.dummyCtrl);
			}
		},
		
		keyModifiesValue: function( evt) {
			if (evt.keyCode >= 32 && evt.keyCode <= 127)
			{
				return true;
			}
			return false;
		},
		
		triggersEvt: function( ctrl) {
			if (!gx.lang.emptyObject(ctrl))
			{
				if (ctrl == gx.evt.dummyCtrl)
					return true;
				if( ctrl.nodeName == 'A' || ctrl.nodeName == 'TEXTAREA')
					return true;
				else if(ctrl.nodeName == 'INPUT')
				{
					if ( ctrl.type == 'button' || ctrl.type == 'image')
						return true;
				}
			}
			return false;
		},
		
		setProcessing: function( value, cond) {
			if ((typeof(cond) == 'undefined') || cond)
			{
				gx.evt.processing = value;
				gx.evt.userReady = !gx.evt.processing;
			}
		},
		
		execEvt: function( evt, ctrl, sync) {
			if (gx.lang.emptyObject(evt))
				return;
			this.setEvtName( evt, ctrl);
			this.lastEvent = evt;
			if (gx.grid.drawAtServer || (ctrl && ctrl.nodeName == 'INPUT' && ctrl.type == 'submit'))
			{
				this.execEvtSubmit( evt, ctrl);
			}
			else
			{
				gx.ajax.doPost(gx.ajax.encryptParms(gx.pO, 'gxajaxEvt'), sync);
			}
		},
		
		execEvtSubmit: function( evt, ctrl) {
			gx.evt.setProcessing(true);
			gx.ajax.disableForm();
			gx.fx.obs.notify('gx.onbeforeevent', [evt, ctrl]);
			gx.fn.objectOnpost();
			gx.http.saveState();
			gx.fn.forceEnableControls(false);
			if (!(ctrl && ctrl.nodeName == 'INPUT' && ctrl.type == 'submit'))
			{
				var form = gx.dom.form();
				var currentPopup = gx.popup.getPopup();
				if (currentPopup != null)
				{
					var url = form.action;
					var currentLvl = currentPopup.window.gx.popup.lvl;
					if (currentLvl != -1)
					{
						var text = (url.indexOf('?') != -1)?',':'?';
						text += encodeURIComponent( 'gxPopupLevel=' + currentLvl + ';');
						url += text;
						form.action = url;
					}
				}
				form.submit();
			}
		},
		
		execCliEvt: function( cmpCtx, inMaster, evtName, evtGridName, gridRow, parms) {
			if (gx.evt.processing && !gx.csv.validating)
				return;
			parms = (parms != undefined)?parms:[];
			var gxObj = gx.getObj( cmpCtx, inMaster);
			if (gxObj != null)
			{
				gx.setGxO(cmpCtx, inMaster);
				if (typeof(evtGridName) == 'string' && evtGridName != '' && (arguments.length > 4))
					gxObj.getGrid( evtGridName).instanciateRow(gridRow);
				var isServerEvent = gxObj.isServerEvent(evtName);
				gx.evt.setProcessing(true, !isServerEvent);
				gxObj[evtName](parms);
				gx.evt.setProcessing(false, (!gx.csv.validating && !isServerEvent));
				if (gxObj.conditionsChanged)
				{
					gxObj.executeServerEvent( 'RFR', true);
				}
			}
		},
		
		mouse: {
			x: -1,
			y: -1,
			
			update: function( evt) {
			    try{
				    var isIE = gx.util.browser.isIE();
				    this.x = (isIE)?event.clientX+document.body.scrollLeft:evt.pageX;
				    this.y = (isIE)?event.clientY+document.body.scrollTop:evt.pageY;
				}
				catch(e)
    			{
    				gx.dbg.logEx(e, 'gxapi.js', 'mouse update');
	    		}
			}
		},
		
		_init: function() {
			document.gxReadyState = 'loading';
			if (gx.util.browser.isIE() && !gx.util.browser.isWinCE())
				this.attach( document, 'readystatechange', this.onready);
			else if (gx.util.browser.isFirefox())
				this.attach( document, 'DOMContentLoaded', this.onready);
			else if (gx.util.browser.isBlackBerry() || gx.util.browser.isOperaMini() || gx.util.browser.isIPhone())
				this.attach( window, 'load', this.onload);
			else
				this.onready(null);
			this.attach( document, "mousedown", this.onmousedown);
			this.attach( document, "mousemove", this.onmousemove);
			this.attach( document, "mouseup", this.onmouseup);
			this.attach( document, "click", this.onclick);
			this.attach( document, "dblclick", this.ondblclick);
			this.attach( window, "blur", this.onwindowblur);
		},
		
		_deinit: function() {
			this.lastControl = null;
			this.lastEvent = null;
			this.dummyCtrl = {};
			this.keyListeners = {};
			this.hooks = [];
		}
	},
	
	csv: {
		pkDirty: false,
		validating: false,
		lastRow: [],
		rowChanged: false,
		currentId: 0,
		lastId: 0,
		lastControl: null,
		lastActiveControl: null,
		lastGrid: 0,
		cmpCtx: '',
		anyError: false,
		userFocus: null,
		focusControl: null,
		invalidControl: null,
		invalidForcedCtrl: null,
		validActivatedControl: null,
		disableFocus: false,
		validatingUC: null,
		validatingGrid: null,
		lastEvtResponse: null,
		lastEvtRow: null,
		invalidId: 0,
		fromValid: 0,
		toValid: 0,
		
		validForm: function() {
			var bRet = true;
			try
			{
				if (gx.fn.getControlValue( "IsConfirmed") != "1" && gx.fn.getHidden("_EventName") == "EENTER.")
					bRet = this.validControls( this.lastId, gx.fn.lastCtrlId() + 1, false);
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxapi.js', 'validForm');
			}
			if (bRet)
				gx.fn.forceEnableControls(false);
			return bRet;
		},
		
		validateAll: function() {	
			try
			{
				this.validControls( this.fromValid, this.toValid, false);
				if (this.invalidControl == null  && !(this.rowChanged && !this.targetRowIsMod(this.toValid)))
					this.fromValid = this.toValid;			
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxapi.js', 'validateAll');
			}
		},
		
		validControls: function( FromControl, TargetControl, bForceCheck) {
			var bRet = true;
			var bFailedCtrl = -1;
			try
			{
				gx.csv.validActivatedControl = null;
				gx.csv.invalidControl = null;
				gx.csv.invalidId = 0;
				if (TargetControl > FromControl)
				{
					for (var i=FromControl;i<TargetControl;i++)
					{
						var ret = this.validControl( i, bForceCheck);
						var isValid = ret.ret;
						if (bRet && !isValid)
						{
						    bFailedCtrl = ret.ctrl;
						    bRet = false;
						}
					}
				}
				if ( bFailedCtrl != -1)
				{
					var _GXValidStruct = gx.fn.validStruct(bFailedCtrl);
					var Control = gx.fn.getControlGridRef( _GXValidStruct.fld, _GXValidStruct.grid);
					gx.csv.disableFocus = true;
					if (gx.fn.isAccepted(Control))
						gx.fn.setFocus( Control);
					else
						gx.fn.setFocus( gx.evt.lastControl);
				}
				else if (gx.csv.validActivatedControl != null)
				{
					gx.fn.setFocus( gx.csv.validActivatedControl);
				}
			}
			catch (e)
			{
				gx.dbg.logEx(e, 'gxapi.js', 'validControls');
			}
			return bRet;
		},
		
		validControl: function( Id, bForceCheck) {
			var bRet = true;
			var bFailedCtrl = -1;
			var validStruct = gx.fn.validStruct(Id);
			if (validStruct != undefined)
			{
				if (validStruct.grid != 0)
				{
					var GXValidRow = gx.fn.currentGridRow( validStruct.grid);
					if (GXValidRow != undefined)
						gx.fn.setCurrentGridRow(validStruct.grid, GXValidRow);
				}
				if (validStruct.isuc == true)
					validStruct.uc.execC2VFunctions();
				else
					validStruct.c2v();
				if (typeof(validStruct.v2bc) == 'function')
					validStruct.v2bc.call(gx.O);
				try
				{
					if (validStruct.lvl == 0 || ( (validStruct.grid != 0) && gx.fn.gridRowIsMod( validStruct.lvl, gx.fn.currentGridRow( validStruct.grid))) || !gx.O.isTransaction())
					{
						var Control = null;
						if (validStruct.isuc == true)
							Control = validStruct.uc.getRealControl();
						else
							Control = gx.fn.getControlGridRef( validStruct.fld, validStruct.grid);
						if (Control)
						{
							var bValid = this.validate( Control, Id, bForceCheck);
							if (!bValid && bRet)
							{	
								gx.csv.invalidControl = Control;
								gx.csv.invalidId = Id;
								bFailedCtrl = Id;
								bRet = false;
							}
							gx.csv.lastId = Id;
							if (gx.fn.isAccepted( Control) == false)
							{
								gx.evt.executeOnblur(Id);
								
								if (Control.getAttribute( "gxhiddenonchange") != Control.value)
								{
									Control.setAttribute( "gxhiddenonchange", Control.value);
									gx.evt.execOnchange( Control);
								}
							}
						}
					}
				}
				catch(e)
				{
					gx.dbg.logEx(e, 'gxapi.js', 'validControl');
				}
			}
			return {ret:bRet, ctrl:bFailedCtrl};
		},
		
		validate: function( Ctrl, i, bForceCheck) {
			gx.csv.anyError = false;
			var validStruct = gx.fn.validStruct(i);
			if (validStruct == undefined)
				return true;
			gx.csv.refreshVars( validStruct);
			if ((validStruct.fnc == null) && (validStruct.isvalid == null))
			{
				//numeric grid filters refresh on lostfocus
				if (Ctrl.tagName!="SELECT" && Ctrl.type!="checkbox" && gx.lang.isNumericType(validStruct.type) && !gx.lang.emptyObject(validStruct.rgrid))
				{
					var len = validStruct.rgrid.length;
					for( var i=0;i<len;i++)
					{
						validStruct.rgrid[i].filterVarChanged();
					}
				}
				return true;
			}
		
			try
			{
				var jsCode = '';
				if (i != -1 && (bForceCheck || (Ctrl.getAttribute( "gxvalid") != "1")))
				{
					gx.evt.setProcessing(true);
					gx.csv.currentId = i;
					gx.csv.validatingGrid = validStruct.gxgrid;
					gx.csv.validating = true;
					gx.csv.refreshVars( validStruct);
					var validRet = false;
					if (validStruct.isuc == true)
						validRet = validStruct.fnc.call(validStruct.uc);
					else if (validStruct.fnc != null)
						validRet = validStruct.fnc.call(gx.O); 	//call FieldValidation
					else
						validRet = true;
					if (gx.O.AnyError == 1)
					{
						if (gx.lang.emptyObject(gx.csv.invalidControl))
							gx.csv.invalidControl = Ctrl;
						gx.csv.anyError = true;
						gx.O.AnyError = 0;
					}
					if (gx.csv.anyError == true)
						validRet = !gx.csv.anyError;
					if (validRet == false)
					{
						gx.csv.validatingGrid = null;
						gx.csv.validating = false;
						gx.evt.setProcessing(false);
						return false;
					}
					gx.csv.refreshControls( validStruct);
					gx.csv.invalidateDeps(i);
					if(!gx.lang.emptyObject(validStruct.rgrid) && !gx.lang.emptyObject(validStruct.hc)){
						var len = validStruct.rgrid.length;
						for( var i=0;i<len;i++)
						{
							validStruct.rgrid[i].filterVarChanged();
						}
					}
					if(validStruct.isvalid != null)
						validStruct.isvalid.call(gx.O); 	//Call User IsValid
					if (gx.fn.isAccepted( Ctrl))
						Ctrl.setAttribute( "gxvalid", "1");
					else
						Ctrl.setAttribute( "gxvalid", "0");
					gx.csv.validatingGrid = null;
					gx.csv.validating = false;
					gx.evt.setProcessing(false);
				}
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxapi.js', 'validate');
			}
			return true;
		},
		
		invalidateForm: function() {
			if (gx.O.AnyError == 1)
			{
				return;
			}
			var ctrlIds = gx.fn.controlIds();
			var len = ctrlIds.length;
			for (var i=0;i<len;i++)
			{
				var validStruct = gx.fn.validStruct(ctrlIds[i]);
				var ctrl = gx.fn.getControlGridRef( validStruct.fld, validStruct.grid);
				if (ctrl)
				{
					if ((ctrl.getAttribute( "gxvalid") == 1) && (ctrl.getAttribute( "gxoldvalue") != ctrl.value))
					{
						ctrl.setAttribute( "gxvalid", "0");
					}
				}
			}
		},
		
		invalidateCtrl: function( Ctrl, keyEvt) {
			try
			{
				if ((Ctrl.getAttribute( "gxvalid") == 1) && (Ctrl.getAttribute( "gxoldvalue") != Ctrl.value))
				{
					Ctrl.setAttribute( "gxvalid", "0");
				}
				var validStruct = gx.fn.validStruct(gx.csv.focusControl);
				if (validStruct && validStruct.grid != 0 && gx.evt.keyModifiesValue(keyEvt))
				{
					validStruct.gxgrid.setRowModified(gx.fn.currentGridRowImpl(validStruct.grid));
				}
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxapi.js', 'invalidateCtrl');
			}
		},
		
		invalidateDeps: function( id) {
			var ctrlIds = gx.fn.controlIds();
			var len = ctrlIds.length;
			for (var i=0;i<len;i++)
			{
				var cId = ctrlIds[i];
				if (cId > id)
				{
					var validStruct = gx.fn.validStruct(cId);
					var len1 = validStruct.ip.length;
					for (var j=0; j<len1; j++)
					{
						if (validStruct.ip[j] == id)
						{
							if (validStruct.grid == 0)
							{
								var ctrl = gx.fn.getControlGridRef( validStruct.fld, validStruct.grid);
								if (ctrl)
								{
									ctrl.setAttribute('gxvalid', '0');
								}
							}
							else
							{
								var gridObj = gx.fn.getGridObj(validStruct.grid);
								if (gridObj)
								{
									var len2 = gridObj.grid.rows.length;
									for (var k=0; k<len2; k++)
									{
										var row = gridObj.grid.rows[k];
										var rowRemoved = row.gxDeleted();
										var rowExists = row.gxExists();
										if (!rowRemoved && rowExists)
										{
											gridObj.setRowModified(row.gxId);
											var ctrl = gx.fn.getControlRef(validStruct.fld + '_' + row.gxId);
											if (ctrl)
											{
												ctrl.setAttribute('gxvalid', '0');
											}
										}
									}
								}
							}
						}
					}
				}
			}
		},

		disableFocusCondition: function() {
			if (typeof(gx.fn.validStruct(gx.csv.focusControl)) == "undefined")
				return false;
			try
			{
				var sMode = gx.getVar("Gx_mode");
				if (gx.csv.lastGrid > 0)
					gx.setVar("Gx_mode", gx.fn.getGridRowMode( gx.fn.gridLvl( gx.csv.lastGrid), gx.csv.lastGrid));
				var vStruct = gx.fn.validStruct(gx.csv.focusControl);
				if (vStruct && vStruct.nac && vStruct.nac.call(gx.O) == true)
				{
					cn = gx.fn.getControlIndex(gx.csv.lastControl) + 1;
					var NextFocus = gx.fn.searchFocusFwd(cn);
					if(NextFocus != null)
						gx.fn.setFocus( NextFocus);
					gx.setVar("Gx_mode", sMode);
					return true;
				}
				gx.setVar("Gx_mode", sMode);
			}
			catch(e){}
			return false;
		},

		loadScreen: function() {
			try
			{
				if(gx.csv.pkDirty)
				{
					gx.csv.pkDirty = false;
					gx.fn.clearOldKeys();
					gx.evt.execEvt( gx.csv.cmpCtx+'ELSCR.', gx.evt.dummyCtrl);
				}	
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxapi.js', 'loadScreen');
			}
		},
		
		ctxControlId: function( ControlId) {	
			if (ControlId.indexOf(this.cmpCtx) == 0)
				return ControlId;
			return this.cmpCtx + ControlId;
		},
		
		isProperty: function( Target) {
			if (Target instanceof Array && Target.length==2)
				return true;
			if (typeof(Target) == 'object')
			{
				if (typeof(Target[0]) != 'undefined' && typeof(Target[1]) != 'undefined')
					return true;
			}
			return false;
		},
		
		checkRowChange: function( Ctrl) {
			try
			{
				var vStruct = gx.fn.validStruct(Ctrl);
				if (typeof(vStruct) != 'undefined')
				{
					var GridId = vStruct.grid;
					if (GridId != 0)
					{
						var GXValidRow = gx.fn.currentGridRowImpl( GridId);
						if (GXValidRow != 0 && GXValidRow != gx.csv.lastRow[GridId] && GXValidRow.length > 1 && gx.csv.lastRow[GridId] && gx.csv.lastRow[GridId].length > 1)
						{
							gx.csv.rowChanged = true;
							var bkpBScreen = gx.O.Gx_BScreen;
							gx.O.Gx_BScreen = 1;
							if (gx.csv.validGridRowChange( GridId, GXValidRow) == true)
							{
								gx.fn.setCurrentGridRow(GridId, GXValidRow);
							}
							gx.O.Gx_BScreen = bkpBScreen;
							return true;
						}
						if (GXValidRow != undefined)
							gx.fn.setCurrentGridRow(GridId, GXValidRow);
					}
				}
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxfrmutl.js', 'checkRowChange');
			}
			return false;
		},
		
		validGridRow: function( GridId, GXValidRow) {
			if (GXValidRow != undefined)
				gx.fn.setCurrentGridRow(GridId, GXValidRow);
			var firstGridCtrl = gx.fn.firstGridControl( GridId);
			var lastGridCtrl = gx.fn.lastGridControl( GridId);
			return gx.csv.validControls( firstGridCtrl, lastGridCtrl + 1, true);
		},
		
		validGridRowChange: function( GridId, GXValidRow) {
			if (gx.csv.lastRow[GridId] != undefined)
				gx.fn.setCurrentGridRow(GridId, gx.csv.lastRow[GridId]);
			var firstGridCtrl = gx.fn.firstGridControl( GridId);
			var lastGridCtrl = gx.fn.lastGridControl( GridId);
			var bRet = gx.csv.validControls( firstGridCtrl, lastGridCtrl + 1, true);
			if (bRet)
				gx.csv.changeGridRow( GridId, firstGridCtrl, GXValidRow);
			return bRet;
		},
		
		changeGridRow: function( GridId, firstGridCtrl, GXValidRow) {
			var bRowisMod = gx.fn.gridRowIsMod( gx.fn.gridLvl( GridId), gx.csv.lastRow[GridId]);
			if (bRowisMod)
				gx.fn.setNewRow( GridId, gx.csv.lastRow[GridId], false);
			gx.csv.lastId = firstGridCtrl;
			if (gx.csv.fromValid > firstGridCtrl)
				gx.csv.fromValid = firstGridCtrl;
			gx.csv.lastRow[GridId] = GXValidRow;
			Gx_BScreen = 1;
		},
		
		targetRowIsMod: function( vStructId) {
			var vStruct = gx.fn.validStruct( vStructId);
			if (vStruct)
			{
				return gx.fn.gridRowIsMod( vStruct.lvl, gx.fn.currentGridRow( vStruct.grid));
			}
			return false;
		},
		
		refreshVars: function( validStruct) {
			var len = validStruct.ip.length;
			for( var i=0;i<len;i++)
			{
				try	
				{
					gx.fn.validStruct(validStruct.ip[i]).c2v();
				}
				catch(e)
				{
					gx.dbg.logEx(e, 'gxapi.js', 'refreshVars');
				}
			}
		},
		
		refreshControls: function( validStruct) {
			var len = validStruct.op.length;
			for( var i=0;i<len;i++)
			{
				try
				{
					var VStr = gx.fn.validStruct(validStruct.op[i]);
					VStr.v2c();
					var Ctrl = null;
					if (VStr.grid == 0)
						Ctrl = gx.dom.el( gx.csv.ctxControlId(VStr.fld));
					else
						Ctrl = gx.fn.getControlGridRef( VStr.fld, VStr.grid);
					if (Ctrl)
						Ctrl.setAttribute( "gxvalid", "0");
				}
				catch(e)
				{
					gx.dbg.logEx(e, 'gxapi.js', 'refreshControls');
				}
			}
			len = validStruct.ucs.length;
			for( var i=0;i<len;i++)
			{
				try
				{
					gx.fn.validStruct(validStruct.ucs[i]).uc.execV2CFunctions();
				}
				catch(e)
				{
					gx.dbg.logEx(e, 'gxapi.js', 'refreshControls');
				}
			}
		},
		
		setValidValues: function( OutputArr, ValuesArr) {
			var anyGrid = false;
			var len = OutputArr.length;
			for (var i=0;i<len;i++)
			{
				var Target = OutputArr[i];
				var Value = ValuesArr[i];
				
				if (this.isProperty( Target))//Property
				{
					var validStruct = gx.fn.vStructForVar(Target[0]);
					if(validStruct != null)
					{
						gx.fn.setCtrlProperty(validStruct.fld, Target[1], Value);
					}
				}
				else 
				{
					//Hide Code
					var validStruct = gx.fn.validStruct(this.currentId);
					if ( !gx.lang.emptyObject(validStruct) && !gx.lang.emptyObject(validStruct.hc))
					{
						if (validStruct.hc == Target)
						{
							gx.O[validStruct.hc] = Value;
							gx.fn.setHidden(this.cmpCtx + "GXH_" + validStruct.fld, Value);
						}
						else if (validStruct.hd == Target)
						{
							gx.O[validStruct.hd] = Value;
						}
					}
					//Attribute or Grid
					validStruct = gx.fn.vStructForVarWId(Target, this.currentId);
					if(!gx.lang.emptyObject(validStruct))
					{
						var Ctrl = gx.fn.screen_CtrlRef( validStruct.fld);
						if (!gx.lang.emptyObject(Ctrl))
						{
							if (Value instanceof Object)
							{
								if (Ctrl.tagName == "SELECT")
								{
									if (Ctrl.selectedIndex != -1 && gx.fn.invalidEmptyValue(Value))
										Value.s = Ctrl.options[Ctrl.selectedIndex].value;
									var comboId = gx.dom.id( Ctrl);
									gx.fn.loadComboBox( comboId, Value.v);
									gx.fn.setComboBoxValue( comboId, Value.s);
								}
								else if (!gx.lang.emptyObject(Value.s))
								{
									if (validStruct.type == 'int')
										Value.s = gx.text.trim(Value.s);
									else
										Value.s = gx.text.rtrim(Value.s);
								}
								var valueDesc = gx.fn.selectedDescription(Value);
								if (gx.lang.emptyObject(Value.s) && !gx.lang.emptyObject(Ctrl.value))
									Value = Ctrl.value;
								else if(Ctrl.tagName == "SPAN" && !gx.lang.emptyObject(Value.s) &&  !gx.lang.emptyObject(valueDesc))
									Value = valueDesc;
								else
									Value = Value.s;
								gx.fn.setControlValue_span_safe( this.cmpCtx + validStruct.fld, Value, 0);
							}
						}
						validStruct.v2v( Value);
		
						if (validStruct.v2c != null)
							validStruct.v2c();
					}
					else
					{
						//HC en grid
						validStruct = gx.fn.vStructForHC(Target);
						if(validStruct != null)
						{
							var gRow = '';
							if (validStruct.grid != 0)
								gRow = '_' + gx.fn.currentGridRow(validStruct.grid);
							gx.fn.setHidden(this.cmpCtx + "GXHC" + validStruct.fld + gRow, Value);
						}
		
						var Grid = gx.fn.gridObjFromGxO(Target);
						if (Grid != undefined)
						{
							gx.newRows[Grid.gridId] = [];
							anyGrid = true;
							Grid.loadGrid(Value);
						}
						else
						{
							if (!gx.fn.saveLvlOldParm( Target, Value))
							{
								continue;
							}
							gx.setVar(Target, Value);
							gx.fn.setGridHidden(Target, Value);
						}
					}
				}
			}
			var msgs = {};
			msgs["MAIN"] = gx.json.evalJSON(ValuesArr[i]);
			gx.fn.setErrorViewer(msgs);
			gx.O.refreshOlds();
			gx.fn.enableDisableDelete();
			if (anyGrid)
			{
				gx.dom.indexElements();
			}
		},
		
		_deinit: function() {
			this.lastRow = [];
			this.lastControl = null;
			this.lastActiveControl = null;
			this.userFocus = null;
			this.focusControl = null;
			this.invalidControl = null;
			this.invalidForcedCtrl = null;
			this.validActivatedControl = null;
			this.validatingUC = null;
			this.validatingGrid = null;
			this.lastEvtResponse = null;
			this.lastEvtRow = null;
		}
	},
	
	json: {
		_nonSerializables: [],
		
		setNonSerializable: function( ctrlName) {
			if (!this.isNonSerializable(ctrlName))
				this._nonSerializables.push(ctrlName);
		},
		
		isNonSerializable: function( ctrlName) {
			var len = this._nonSerializables.length;
			for (var i=0; i<len; i++)
			{
				if (this._nonSerializables[i] == ctrlName)
					return true;
			}
			return false;
		},
		
		evalJSON: function( value) {
			try
			{
				return eval('(' + value + ')');
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxapi.js', 'evalJSON');
			}
			return value;
		},

		serializeJson: function( obj, allFields) {
			var objJson = this.objToJson( obj);
			if (objJson === null)
				objJson = this.arrayToJson( obj);
			else
				return objJson;
			if (objJson === null)
			{
				if (typeof(obj) == 'function')
					return null;
				var tmp = [];
				for (var prop in obj)
				{
					if (!allFields && this.isNonSerializable(prop))
						continue;
					var key = this.objToJson( prop, true);
					if (key === null)
						continue;
					var value = this.serializeJson(obj[prop]);
					if (typeof(value) != 'string')
						continue;
					tmp.push(key + ':' + value);
				}
				return '{' + tmp.join(',') + '}';
			}
			else
				return objJson;
		},
		
		objToJson: function( obj, isKey) {
			var type = typeof(obj);
			if (isKey)
			{
				if (!gx.lang.emptyObject(obj))
				{
					if (type == 'string')
						return gx.text.escapeString(obj);
					else if (type == 'number')
						return '"' + obj + '"';
				}
			}
			else
			{
				if (type == 'undefined')
					return type;
				else if (type == 'string')
					return gx.text.escapeString(obj);
				else if ((type == 'number') || (type == 'boolean'))
					return obj.toString();
				else if(obj === null)
					return 'null';		
				else if (typeof(obj.json) == 'function')
				{
					var tmp = obj.json();
					if (obj !== tmp)
						return this.serializeJson(tmp);
				}
			}
			return null;
		},

		arrayToJson: function( arr) {
			if(typeof(arr) != 'function' && typeof(arr.length) == 'number')
			{
				var res = [];
				var len = arr.length;
				for (var i = 0; i < len; i++)
				{
					var val = this.serializeJson(arr[i]);
					if(typeof(val) != 'string')
						val = 'undefined';
					res.push(val);
				}
				return '[' + res.join(',') + ']';
			}
			return null;
		},
		
		objFromJson: function( obj, value) {
			var jObj = this.evalJSON(value);
			for (var prop in obj)
			{
				if (typeof(obj[prop]) != 'function')
				{
					delete obj[prop];
				}
			}
			for (var prop in jObj)
			{
				obj[prop] = jObj[prop];
			}
		}
	},
	
	dbg: {
		lastTime: 0,
		enabled: false,
		dbgWin: null,
		
		logMsg: function( msg) {
			if (!this.enabled)
			{
				return;
			}
			this.write(msg);
		},
		
		logEx: function( ex, file, func) {
			if (!this.enabled)
			{
				return;
			}
			var msg = '';
			if(ex && ex instanceof Error)
			{
				msg = '[' + ex.name + ': ' + this.exTxt(ex);
				msg += (file ? ', file: ' + file : '');
				msg += (func ? ', func: ' + func : '') + ']';
				if(ex.fileName)
					msg += ' FileName:' + ex.fileName;
				if(ex.lineNumber)
					msg += ' ln:' + ex.lineNumber;
			}
			else
			{
				try
				{
					msg = String(ex);
				}
				catch(e)
				{
					msg = '[Unknown Error]';
				}
			}
			this.write(msg);
		},
		
		exTxt: function( ex) {
			if (!ex)
				return 'Unknown Error';
			if (ex.message)
				return ex.message;
			else if (ex.description)
				return ex.description;
			else
				return ex.toString();
		},
		
		write: function( txt) {
			try
			{
				if (this.dbgWin == null)
					this.dbgWin = window.open( "", "debug","scrollbars=1,height=900,width=900");
				this.dbgWin.document.write( txt + '<BR>');
			}
			catch (e){}
		},
		
		writeT: function( txt) {
			var now = new Date();
			var nt = now.getTime();
			var st = this.lastTime;
			if (this.lastTime > 0)
			{
				st = (nt - this.lastTime)/1000;
			}
			this.lastTime = nt;
			txt = now.toString() + ' (+' + st + 'seg): ' + txt;
			this.write(txt);
		}
	},
	
	http: {
		STATE_UNSENT: 0,
		STATE_LOADING: 3,
		STATE_DONE: 4,
		STATUS_OK: 200,
		STATUS_SESSION_TO: 440,
		iframeName: 'gxPostIFrame',
		viewState: null,
		oldState: null,
		useBase64State: false,
		lastStatus: 0,
		lastResponse: '',
		
		modes: {
			none: 0,
			full: 1,
			call: 2,
			retval: 3
		},
		
		loadState: function() {
			var gxState = gx.dom.el("GXState");
			if (gxState)
			{
				var hiddenValues = gxState.value;
				var decoded = hiddenValues;
				if (this.useBase64State)
				{
					decoded = gx.base64.decode(hiddenValues);
				}
				this.viewState = gx.json.evalJSON(decoded);
			}
		},
		
		saveState: function(allFields) {
			if (!this.viewState)
			{
				return;
			}
			var hiddenValues = gx.json.serializeJson(this.viewState, allFields);
			var hiddenId = "GXState";
			var hiddenValue = hiddenValues;
			if (this.useBase64State)
			{
				hiddenValue = gx.base64.encode(hiddenValues);
			}
			var Control = gx.dom.el(hiddenId);
			if (Control == null)
			{
				gx.dom.createInput(hiddenId, "hidden");
			}
			else
			{
				this.oldState = Control.value;
			}
			gx.fn.setControlValue_impl(hiddenId, hiddenValue); 
		},
		
		refreshState: function() {
			if (this.oldState != null)
			{
				var stateCtrl = gx.dom.el('GXState');
				stateCtrl.value = this.oldState;
				this.oldState = null;
			}
		},
	
		notification: {
			_node: null,
			_moveInterval: null,
			_closeLink: null,
			
			node: function() {
				if (!this._node)
				{
					this._node = gx.dom.byId("gx_ajax_notification");
					if (!this._node)
					{
						var indicator = gx.util.resourceUrl(gx.basePath + gx.staticDirectory + "indicator.gif", true);
						var nodeHtml = '<div id="gx_ajax_notification" style="display:none;text-align:center;vertical-align:top;background-color:#BEBEBE;filter:alpha(opacity=50);opacity:0.5;position:absolute;top:0px;left:0px">';
						if (gx.grid.drawAtServer)
						{
							nodeHtml += '<div onclick="gx.ajax.enableForm()" style="display:none;cursor:hand;font-size:9;position:absolute;top:0px;left:0px;"><u>Enable Form</u></div>';
						}
						nodeHtml += '<img id="gx_ajax_indicator" src="' + indicator + '" width="16px" height="16px" align="absmiddle"/></div>';
						this._node = gx.html.nodesFromText(nodeHtml)[0];
						document.body.appendChild( this._node);
						gx.popup.setZIndex( this._node);
						if (gx.grid.drawAtServer)
						{
							this._closeLink = this._node.childNodes[0];
						}
					}
				}
				return this._node;
			},
			
			show: function() {
				var node = gx.http.notification.node();
				node.style.width = gx.html.viewportWidth()+'px';
				node.style.height = gx.html.viewportHeight()+'px';
				node.style.display = 'block';
				gx.http.notification._moveInterval = setInterval(gx.http.notification.move, 50);
				gx.evt.attach(window, 'resize', gx.http.notification.resize);
				if (gx.grid.drawAtServer)
				{
					setTimeout(gx.http.notification.showCloseLink, 5000);
				}
			},
			
			hide: function() {
				gx.http.notification.node().style.display = 'none';
				clearInterval(gx.http.notification._moveInterval);
				gx.http.notification._moveInterval = null;
				gx.evt.detach(window, 'resize', gx.http.notification.resize);
				if (gx.grid.drawAtServer)
				{
					gx.http.notification.hideCloseLink();
				}
			},
			
			move: function() {
				var node = gx.http.notification.node();
				var y = parseInt(node.style.top);
				var sy = document.body.scrollTop;
				var newY = ((sy-y-10)/3+3)+y;
				node.style.top = newY+'px';
			},
			
			resize: function() {
				var node = gx.http.notification.node();
				node.style.width = gx.html.viewportWidth()+'px';
				node.style.height = gx.html.viewportHeight()+'px';
			},
			
			showCloseLink: function() {
				if (gx.http.notification._closeLink)
				{
					gx.http.notification._closeLink.style.display = 'block';
				}
			},
			
			hideCloseLink: function() {
				if (gx.http.notification._closeLink)
				{
					gx.http.notification._closeLink.style.display = 'none';
				}
			},
			
			cleanup: function() {
				if (this._node)
				{
					gx.dom.removeControlSafe( this._node);
				}
				this._node = null;
				this._closeLink = null;
				this._moveInterval = null;
			}
		},
		
		getCookie: function( name) {
			name = name + '=';
			var cookies = document.cookie.split(';');
			var len = cookies.length;
			for (var i=0; i<len; i++)
			{
				var cook = cookies[i];
				while (cook.charAt(0) == ' ')
					cook = cook.substring(1, cook.length);
				if (cook.indexOf(name) == 0)
					return cook.substring(name.length, cook.length);
			}
			return null;
		},
		
		isSessionTimeoutError: function( req, exc) {
			if (!gx.gen.isDotNet() && (exc && req) && gx.pO.AjaxSecurity == gx.ajax.securityLevels.high)
			{
				if (req.readyState == this.STATE_DONE)
				{
					if(exc.name == 'NS_ERROR_FAILURE' && exc.result == 2147500037) //FF
					{
						return true;
					}
					else if (exc.name == 'Error' && exc.number == -2146697209) //IE
					{
						return true;
					}
					else if (exc.name == 'NETWORK_ERR' && exc.code == 101) //CHR
					{
						return true;
					}
				}
			}
			return false;
		},
		
		reloadOnTimeout: function() {
			if ( (gx.pO.AjaxSecurity == gx.ajax.securityLevels.high) && confirm(gx.getMessage("GXM_sessionexpired")))
			{
				gx.http.reload();
				return;
			}
			else
			{
				gx.ajax.enableForm();
			}
		},
		
		reload: function() {
			this.redirect( location.href);
		},
		
		redirect: function(url) {
			var currentPopup = gx.popup.getPopup();
			if (currentPopup != null)
			{
				var currentLvl = currentPopup.window.gx.popup.lvl;
				if (currentLvl != -1)
				{
					var text = (url.indexOf('?') != -1)?',':'?';
					text += encodeURIComponent( 'gxPopupLevel=' + currentLvl + ';');
					url += text;
				}
			}
			if (!gx.ajax.isabsoluteurl(url))
			{
				url = gx.ajax.absoluteurl(url);
			}
			location.href = url;
		},
		
		getRequest: function() {
			var req = null;
			try
			{
				req = new ActiveXObject('Msxml2.XMLHTTP');
			}
			catch(e)
			{
				try
				{
					req = new ActiveXObject('Microsoft.XMLHTTP');
				}
				catch(e){}
			}
			if (req == null && typeof(XMLHttpRequest) != 'undefined')
			{
				req = new XMLHttpRequest();
			}
			return req;
		},

		getPostData: function( info) {
			var frm = info.formNode;
			var postData = [];
			var len = frm.elements.length;
			for (var i = 0; i < len; i++)
			{
				var data = gx.http.elementPostData(frm.elements[i]);
				if (data != null)
					postData.push(data);
			}
			return postData.join('&') + '&';
		},

		elementPostData: function( el) {
			if (gx.json.isNonSerializable(el.name))
				return null;
			if (el.tagName == 'FIELDSET')
				return null;
			var value = '';
			if (el.type == 'select-multiple')
			{
				var len = el.options.length;
				for (var j = 0; j < len; j++)
				{
					if (el.options[j].selected)
						value = el.options[j].value;
				}
			}
			else if (el.type == 'radio' || el.type == 'checkbox')
			{
				if(el.checked)
					value = el.value;
				else if (el.type == 'radio')
				    return null;
		    }
			else
				value = el.value;
			return encodeURIComponent(el.name) + '=' +  encodeURIComponent(value);
		},

		// Precondition req != null, we should use some Assert function
		doHandleRequest: function( req, info) {
			if (req.readyState == this.STATE_LOADING) 
			{
				if (typeof (req.abort) == 'function')
				{
					gx.evt.setProcessing(false, !gx.csv.validating);
					req.abort();
				}
			}
			else if (req.readyState == this.STATE_DONE) 
			{
				gx.evt.setProcessing(false, !gx.csv.validating);
				gx.evt.userReady = false;
				if (req.status == this.STATUS_OK)
				{
					this.doCallHandler(req, info);
				}
				else if (req.status == this.STATUS_SESSION_TO)
				{
					gx.http.reloadOnTimeout();
				}
				else
				{
					document.write(req.responseText);
				}
				gx.evt.userReady = true;
			}
		},

		onRequestError: function( req, info) {
			gx.evt.setProcessing(false, !gx.csv.validating);
			if (req.readyState == this.STATE_DONE)
			{
				if (req.status == this.STATUS_SESSION_TO || this.isBadResponse(req))
				{
					gx.http.reloadOnTimeout();
				}
			}
			else if (this.isBadResponse(req))
			{
			    gx.http.reloadOnTimeout();
			}
		},
		
		isBadResponse: function( req) {
			if (req.status == this.STATE_UNSENT && gx.lang.emptyObject(req.responseText) && gx.util.browser.isChrome())
				return true;
			return false;
		},

		doCall: function( info) {
			if (!info.handler && typeof(info.load) == 'function')
				info.handler = info.load;
			if (typeof(info.sync) != 'boolean')
				info.sync = false;
			if (!info.method)
				info.method = 'POST';
			if (info.multipart && info.method == 'POST')
			{
				this.doMultipartPost(info);
			}
			else
			{
				var req = this.getRequest();
				if (req != null)
				{
					if ((typeof (info.handler) == 'function') && !info.sync)
					{
						var onreadyFunc = function() {
							gx.http.doHandleRequest(req, info);
						};
						var onerrorFunc = function() {
							gx.http.onRequestError(req, info);
						};
						if (gx.util.browser.isIE())
						{
							req.onreadystatechange = onreadyFunc;
						}
						else
						{
							req.onload = onreadyFunc;
							req.onerror = onerrorFunc;
						}
					}
					var reqData = null;
					if (info.method == 'POST')
						reqData = gx.http.getPostData(info);
					req.open( info.method, this.uncache(info.url), !info.sync);
					req.setRequestHeader(gx.ajax.reqHeader, '1');
					if (info.method == 'POST')
						req.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
					if (gx.sec.secToken && gx.pO.AjaxSecurity == gx.ajax.securityLevels.medium)
						req.setRequestHeader(gx.sec.secTokenName, gx.sec.secToken);
					try
					{
						req.send(reqData);
					}
					catch(e)
					{
						if (typeof(req.abort) == 'function')
							req.abort();
					}
	
					if ((typeof (info.handler) == 'function') && info.sync) 
					{
						gx.http.doHandleRequest(req, info);
					}
				}
			}
		},
		
		doCallHandler: function(req, info) {
			if (info.obj)
				info.handler.call(info.obj, null, req.responseText, req);
			else
				info.handler(null, req.responseText, req);
		},
		
		doMultipartPost: function( info) {
			var iFrame = this.getPostIFrame();
			iFrame.gxPostInfo = info;
			var frm = info.formNode;
			info.oldAction = frm.getAttribute('action');
			frm.setAttribute( 'action', info.url);
			info.oldTarget = frm.getAttribute('target');
			frm.setAttribute( 'target', this.iframeName);
			frm.submit();
		},
		
		getPostIFrame: function() {
			var name = this.iframeName;
			var iFrame = window[name];
			if (iFrame)
			{
				return iFrame;
			}
			else
			{
				iFrame = window.frames[name];
				if (iFrame)
					return iFrame;
			}
			iFrame = gx.html.nodesFromText("<iframe name='"+name+"' src='"+ gx.util.resourceUrl(gx.basePath + gx.staticDirectory + "gx_iframe.html", true) + "'>")[0];
			document.body.appendChild( iFrame);
			window[name] = iFrame;
			iFrame.name = name;
			iFrame.setAttribute( 'name', name);
			iFrame.id = name;
			iFrame.style.position = 'absolute';
			iFrame.style.left = '0px';
			iFrame.style.top = '0px';
			iFrame.style.height = '1px';
			iFrame.style.width = '1px';
			iFrame.style.visibility = 'hidden';
			var onloadFunc = new Function('gx.http.iframeOnload();');
			if (!gx.util.browser.isIE())
			{
				iFrame.onload = onloadFunc;
			}
			else
			{
				iFrame.onreadystatechange = function() {
					if (iFrame.readyState == 'complete')
					{
						onloadFunc();
					}
				};
			}
			return iFrame;
		},
		
		iframeOnload: function() {
			gx.evt.setProcessing(false, !gx.csv.validating);
			var iFrame = window[this.iframeName];
			if (!iFrame)
				iFrame = window.frames[this.iframeName];
			if (iFrame)
			{
				var info = iFrame.gxPostInfo;
				var frm = info.formNode;
				frm.setAttribute( 'action', info.oldAction);
				frm.setAttribute( 'target', info.oldTarget);
				var frameDoc = iFrame.contentDocument?iFrame.contentDocument:iFrame.contentWindow.document;
				if (frameDoc)
				{
					var response = gx.base64.decode(this.multipartResponse( frameDoc.body));
					info.handler( null, response, info);
				}
			}
		},
		
		multipartResponse: function( body) {
			try
			{
				var node = body.childNodes[0];
				while (node.nodeName != '#text')
				{
					node = node.childNodes[0];
				}
				var txt = node.nodeValue;
				if (!gx.util.browser.isIE())
				{
					node = node.nextSibling;
					while (node)
					{
						txt += node.nodeValue;
						node = node.nextSibling;
					}
				}
				return txt;
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxapi.js', 'multipartResponse');
				return '';
			}
		},
		
		uncache: function( url) {
			var date = new Date();
			var time = date.getTime();
			return url + ((url.indexOf('?') > 0)?',':'?') + 'gx-no-cache=' + time
		},
		
		callBackend: function( backcall, sURL, sufix, ExecAtFail, Mode, AvoidFormDisable, Method, PostData, AvoidUncache, Sync) {
			var _xmlHttp = this.getRequest();
			if(_xmlHttp)
			{
				try
				{
					if (!AvoidFormDisable)
					{
						gx.ajax.disableForm();
					}
					var reqMethod = (typeof(Method) != 'undefined')?Method:'GET';
					var reqData = (typeof(PostData) != 'undefined')?PostData:null;
					var sync = (typeof(Sync) != 'undefined')?Sync:false;
					if (!AvoidUncache)
					{
						sURL = this.uncache(sURL);
					}
					_xmlHttp.open(reqMethod, sURL, sync);
					_xmlHttp.setRequestHeader(gx.ajax.reqHeader, '2');
					if (reqMethod == 'POST')
						_xmlHttp.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
					else if (gx.sec.secToken && gx.O.AjaxSecurity == gx.ajax.securityLevels.medium)
						_xmlHttp.setRequestHeader(gx.sec.secTokenName, gx.sec.secToken);
					_xmlHttp.send(reqData);
					if (!AvoidFormDisable)
					{
						gx.ajax.enableForm();	
					}
				}
				catch(e)
				{
					if (reqMethod!='POST' && gx.http.isSessionTimeoutError(_xmlHttp, e))
					{
						gx.http.reloadOnTimeout();
					}
					else
					{
						gx.ajax.enableForm();
						window.status = 'GXAjax HTTP error: '+ e.message;
					}
					return null;
				}	
				window.status = '';
				if ((_xmlHttp.readyState != this.STATE_DONE) || (_xmlHttp.status != this.STATUS_OK))
				{
					if (_xmlHttp.status == this.STATUS_SESSION_TO)
					{
						gx.http.reloadOnTimeout();
					}
					else
					{
						window.status = 'GXAjax HTTP error: ('+ _xmlHttp.status + ') - ' + _xmlHttp.statusText;
						gx.dbg.logEx(_xmlHttp.responseText);
					}
				}
				else
				{
					this.lastResponse = _xmlHttp.responseText;
					if (Mode != this.modes.none)
					{
						if(this.lastResponse && this.lastResponse.length > 0 && this.lastResponse.charAt(0) != '<')
						{
							this.lastStatus = 0;
						
							try
							{
								if (Mode == this.modes.full)
									this.handleFull( this.lastResponse, backcall, sufix)
								else
									if (Mode == this.modes.call)
										return this.handleCall( this.lastResponse, backcall, sufix)
								return this.handleRetVal( this.lastResponse, backcall, sufix, ExecAtFail)
							}
							catch(e)
							{
								gx.dbg.logEx(e, 'gxapi.js', 'callBackend');
							}
						}
						else
							window.status = 'GXAjax HTTP error: (bad response format)';
					}
				}
			}
		},
		
		handleFull: function( Response, backcall, sufix) {
			var event = {};
			event.status = 200;
			event.responseText = "";
			gx.http.postHandler( null, Response, event);
		},
		
		handleCall: function( ResponseText, backcall, sufix) {
			if (backcall)
			{
				return eval( backcall + ResponseText + sufix);
			}
		},
		
		handleRetVal: function( ResponseText, backcall, sufix, ExecAtFail) {
			var Response = gx.json.evalJSON( ResponseText);
			var result = Response[0];
			this.lastStatus = Response[1];
			if (this.lastStatus == undefined)
				this.lastStatus = 0;
			if (backcall && (ExecAtFail || this.lastStatus == null || this.lastStatus == 0))
			{
				return eval( backcall + gx.lang.arrayToSource(result) + sufix);
			}
		},
		
		postHandler: function( type, data, event) {
			try
			{
				gx.evt.enter = false;
				gx.csv.lastEvtResponse = null;
				
				if (event.status < 200 || event.status > 299)
				{
					document.write(event.responseText);
				}
				else
				{
					var DataObj = gx.json.evalJSON( data);
					if (DataObj == null)
						document.write(data.toString());
					else
					{
						gx.http.refreshState();
						gx.csv.lastEvtResponse = DataObj;
						gx.fn.forceEnableControls(true);
						gx.ajax.setPostResponse(DataObj);
						gx.fx.obs.notify('gx.onafterevent', [DataObj]);
					}
				}
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxapi.js', 'postHandler');
			}
		},
		
		formatLink: function(url, parms) {
			url = gx.ajax.objectUrl(url);
			if (parms && parms.length > 0)
			{
				url += '?';
				var len = parms.length;
				for (var i=0; i<len; i++)
				{
					if (i>0)
					{
						url += ',';
					}
					url += encodeURIComponent(parms[i]);
				}
			}
			return url;
		},
		
		loadScripts: function(scripts, callback, i) {
			if (typeof(i) == 'undefined')
			{
				i = 0;
			}
			if (i >= scripts.length)
			{
				callback();
			}
			else
			{
				gx.http.loadScript( scripts[i], function() {
					gx.http.loadScripts( scripts, callback, i+1);
				});
			}
		},
		
		loadScript: function( url, callback) {
			var head = gx.dom.byTag('head')[0];
			var script = document.createElement('script');
			script.type = 'text/javascript';
			script.src = url;
			if (typeof(callback) == 'function')
			{
				script.onreadystatechange = function() {
					if (script.readyState == 'loaded' || script.readyState == 'complete')
					{
						callback();
					}
				};
				script.onload = callback;
			}
			head.appendChild(script);
		},
		
		loadStyle: function( url, callback) {
			var head = gx.dom.byTag('head')[0];
			var style = document.createElement("link");
			style.rel = 'stylesheet';
			style.type = 'text/css'
			style.href = url;
			if (typeof(callback) == 'function')
			{
				style.onload = callback;
			}
			head.appendChild(style);
		},
		
		loadStyles: function() {
			var styles = gx.fn.getHidden('GX_STYLE_FILES');
			if (!gx.lang.emptyObject(styles))
			{
				var addBar = (gx.basePath.charAt(0) != '/');
				for (var i=0; i<styles.length; i++)
				{
					var style = styles[i];
					var styleUrl = new gx.util.Url(style);
					if (styleUrl.isRelative())
					{
						style = gx.util.resourceUrl((addBar?'/':'') + gx.basePath + gx.staticDirectory + style, false);
					}
					if (!gx.cache.fileLoaded(style))
					{
						gx.cache.addRemoteFile(style);
						this.loadStyle( style);
					}
				}
			}
		},
		
		doCommands: function() {
			var cmds = gx.fn.getHidden('GX_SRV_COMMANDS');
			if (!gx.lang.emptyObject(cmds))
			{
				gx.ajax.dispatchCommands( cmds);
			}
		}
	},

	html: {
	    encodeCaseFormat: function(Value, nFormat) {
            if ( ( nFormat == gx.html.controls.formats.TEXT ) )
                Value = gx.html.encode(Value);
            else if ( ( nFormat == gx.html.controls.formats.TEXT_W_SPACES ) )
                Value = gx.html.encode(Value, true, false);
            return Value;
	    },
	    
		encode: function( Value, encodeWhiteSpace, encodeEnter) {
		    var oldChars = ['<', '>', '&'];
		    var newChars = ['&lt;', '&gt;', '&amp;'];
		    if(encodeWhiteSpace)
		    {
		        oldChars.push(' ');
		        newChars.push('&nbsp;');
		    }
		    if(encodeEnter)
		    {
		        oldChars.push('\n');
		        newChars.push('<br/>');
		    }
			return gx.text.charReplace( Value, oldChars, newChars);
		},
		
		getHidden: function( id, value) {
			return '<input type="hidden" id="' + id + '" name="' + id + '" value="' + value + '">';
		},
		
		viewportWidth: function() 	{
		    var doc = document.documentElement;
		    if (doc && doc.clientHeight)
		        return Math.max(doc.clientWidth, document.body.clientWidth);
		    else
			    return document.body.clientWidth;
		},

		viewportHeight: function() {
		    var doc = document.documentElement;
		    if (doc && doc.clientHeight)
		        return Math.max(doc.clientHeight, document.body.clientHeight)-5;
		    else
			    return document.body.clientHeight-5;
		},
		
		cleanHtmlRefs: function( html) {
			html = html.replace(/<style[^>]*>([\s\S]*?)<\/style>/gi, '');
			html = html.replace(/<link ([^>]*rel=['"]?stylesheet['"]?[^>]*)>/gi, '');
			html = html.replace(/<script([^>]*)>([\s\S]*?)<\/script>/gi, '');
			return html;
		},
		
		setOuterHtml: function( Control, Html) {
			Control.outerHTML = Html;
		},
		
		setInnerHtml: function( control, html, process) {
			var styles = gx.dom.styles();
			control.innerHTML = this.cleanHtmlRefs(html);
			if (gx.util.browser.isIE())
				gx.cache.updateStyles( styles, gx.dom.styles());
			if (process == true)
				this.processCode( html, false);
		},
		
		setInnerText: function( control, text, format) {
			if (control.nodeValue != null)
				control.nodeValue = text;
			else if (control.innerText != null && !gx.util.browser.isChrome())
				control.innerText = text;
			else if (control.tagName == 'TEXT' && control.innerHTML  != null)
				control.innerHTML = text;
			else
			{
				if (gx.util.browser.isFirefox())
					control.innerHTML = gx.html.encodeCaseFormat(text, format);
				else if (gx.util.browser.isChrome())
					control.innerHTML = '<text>' +gx.html.encodeCaseFormat(text, format) + '</text>';
				else 
				    control.innerHTML = '<text>' + text + '</text>';
			}
		},
		
		nodesFromText: function( text) {
			var node = document.createElement('div');
			node.style.visibility= 'hidden';
			node.style.display = 'none';
			document.body.appendChild(node);
			node.innerHTML = text;
			var nodes = [];
			var len = node.childNodes.length;
			for(var i=0; i<len; i++)
			{
				nodes.push(node.childNodes[i].cloneNode(true));
			}
			gx.dom.removeControlSafe( node);
			return nodes;
		},
		
		onTypeAvailable: function( cName, callback, callbackParms) 
		{
			try { 
			    var typeObj = eval(cName); 
                if (callbackParms instanceof Array)
                    callback.apply(this, callbackParms);
                else
                    callback();
			}
			catch(e)
			{
				setTimeout(function() { gx.html.onTypeAvailable(cName, callback, callbackParms); }, 250);
			}
        },

		processCode: function( html, avoidEval, callback, callbackParms, cName) {
			var origHtml = html;
			var remoteScripts = [];
			var checkTypeLoaded = false;
			var scripts = [];
			var remoteStyles = [];
			var styles = [];
			
			if (html == '')
				return;
		
			var match = [];
			while(match) // Parse inline styles
			{
				match = html.match(/<style[^>]*>([\s\S]*?)<\/style>/i);
				if(!match)
					break;
				else
				{
					var lastIndex = match.lastIndex;
					if (!lastIndex)
						lastIndex = match.index + match[0].length;
					html = html.substring(lastIndex);
				}
				styles.push(match[1]);
			}
			html = origHtml;
			match = [];
			while(match) // Parse links to stylesheets
			{
				match = html.match(/<link ([^>]*rel=['"]?stylesheet['"]?[^>]*)>/i);
				if(!match)
					break;
				else
				{
					var lastIndex = match.lastIndex;
					if (!lastIndex)
						lastIndex = match.index + match[0].length;
					html = html.substring(lastIndex);
				}
				attr = match[1].match(/href=(['"]?)([^'">]*)\1/i);
				if(attr && !gx.cache.fileLoaded(attr[2]))
				{
					remoteStyles.push(attr[2]);
					gx.cache.addRemoteFile(attr[2]);
				}
			}
			html = origHtml;
			match = [];
			while(match) // Parse scripts
			{
				match = html.match(/<script([^>]*)>([\s\S]*?)<\/script>/i);
				if(!match)
					break;
				else
				{
					var lastIndex = match.lastIndex;
					if (!lastIndex)
						lastIndex = match.index + match[0].length;
					html = html.substring(lastIndex);
				}
				if ((match[1] != undefined) && (match[1] != '')) // Remote scripts
				{
					var attr = match[1].match(/src=(['"]?)([\s\S]*)\?([^"']*)\1/i);
					if(attr == null)
						attr = match[1].match(/src=(['"]?)([^"']*)\1/i);
					if(attr && !gx.cache.fileLoaded(attr[2]))
					{
						var fullUrl = attr[2];
						if(!gx.lang.emptyObject(attr[3]))
						{
							fullUrl += '?' + attr[3];
						}
						remoteScripts.push(fullUrl);
						gx.cache.addRemoteFile(attr[2]);
					}
					else if (attr && gx.cache.fileLoaded(attr[2]))
					{
						checkTypeLoaded=true;				   
					}
					else if(!attr && match[2]) // Inline scripts
						scripts.push(match[2]);
				}
				else if(match[2]) // Inline scripts
						scripts.push(match[2]);
			}
			if (avoidEval == true)
				return;
            //Eval Embedded script before calling async callback
			var evalStr = '';
			scrQty = scripts.length;
			for(var i=0; i<scrQty; i++)
			{
				evalStr += scripts[i];
			}
			if (evalStr != '')
				gx.lang.doEval( evalStr); // Evaluate scripts code

			var remoteFilesStr = [];
			if (typeof(callback) == 'function')
			{
				gx.http.loadScripts( remoteScripts, function() {
					if (callbackParms instanceof Array)
						callback.apply(this, callbackParms);
					else
						callback();
				});
			}
			else
			{
				var self = this;
				var getInfo = {};
				getInfo.method = 'GET';
				getInfo.useCash = true;
				getInfo.load = function(type, scriptStr){ gx.lang.supEval(self, remoteFilesStr.push(scriptStr)); };
				getInfo.mimetype = "text/plain";
				getInfo.sync = true;
				var scrRemoteQty = remoteScripts.length;
				for(var i=0; i<scrRemoteQty; i++)
				{
					getInfo.url = remoteScripts[i]; // GET remote scripts from server
					gx.http.doCall( getInfo);
				}
			}
			evalStr = '';
			var scrQty = remoteFilesStr.length;
			for(var i=0; i<scrQty; i++)
			{
				evalStr += remoteFilesStr[i];
			}
			if (evalStr != '')
				gx.lang.doEval( evalStr); // Evaluate scripts code
		
			var styleCtrls = document.getElementsByTagName("style");
			scrQty = remoteStyles.length;
			for(var i=0; i<scrQty; i++)
			{
				var exists = false;
				var stQty = styleCtrls.length;
				for(var j=0; j<stQty; j++)
				{
					var cssUrl = (styleCtrls[i].styleSheet && styleCtrls[i].styleSheet.cssText) ? styleCtrls[i].styleSheet.cssText : styleCtrls[i].innerHTML;
					if (remoteStyles[i] == cssUrl)
						exists = true;
				}
				if (!exists)
				{
					gx.http.loadStyle( remoteStyles[i], function() {}); // GET remote stylesheets from server
				}
			}
			var evalStr = '';
			scrQty = styles.length;
			for(var i=0; i<scrQty; i++)
			{
				evalStr += styles[i];
			}
			if (evalStr != '')
			{
				// Put styles into html head
				var styleCtrl = document.createElement("style");
				styleCtrl.setAttribute("type", "text/css");
				var domHead = document.getElementsByTagName("head")[0];
				domHead.appendChild(styleCtrl);
				if (styleCtrl.styleSheet)
					styleCtrl.styleSheet.cssText = evalStr;
				else
				{
					var textNode = document.createTextNode(evalStr);
					styleCtrl.appendChild(textNode);
				}
			}
            if ((scrRemoteQty == 0) && (typeof(callback) == 'function'))
            {
                if (checkTypeLoaded && cName)
                    gx.html.onTypeAvailable(cName, callback, callbackParms);
                else
                    if (callbackParms instanceof Array)
	                    callback.apply(this, callbackParms);
                    else
	                    callback();
            }
		},

		controls: {
			types: {
				singleLineEdit: 1,
				multipleLineEdit: 2,
				blob: 3,
				radio: 4,
				comboBox: 5,
				listBox: 6,
				checkBox: 7,
				image: 8,
				textBlock: 9,
				button: 10,
				grid: 11,
				userControl: 12,
				userControlContainer: 13,
				webComponent: 14,
				embeddedPage: 15,
				table: 16,
				row: 17,
				cell: 18,
				group: 19
			},
			
			formats: {
				TEXT: 0,
				HTML: 1,
				RAW_HTML: 2,
				TEXT_W_SPACES: 3
			},
			
			isMultiSelection: function( ctrlType) {
				if (ctrlType == 'combo' || ctrlType == 'dyncombo'
					|| ctrlType == 'listbx' || ctrlType == 'dynlistbx')
				{
					return true;
				}
				return false;
			},
			
			eventJSCode: function( jsScrCode, eventName, jsDynCode, gridObj, rowObj) {
				var sEventJsCode = '';
				if (jsScrCode == 4 && jsDynCode)
					sEventJsCode = jsDynCode;
				else if (jsScrCode == 1)
					sEventJsCode = 'gx.fn.closeWindow();';
				else if (jsScrCode == 7)
				{
					var gridInfo = '';
					if (gridObj && rowObj)
						gridInfo = ',\'' + gridObj.gridName + '\',\'' + rowObj.gxId + '\''; 
					sEventJsCode = 'gx.evt.execCliEvt(' + eventName + gridInfo + ',this);';
				}
				else if (jsScrCode == 6 || jsScrCode == 5)
					sEventJsCode = "gx.evt.execEvt('" + eventName + "',this);" ;
				return sEventJsCode;
			},
			
			startAnchor: function( parentCtrl, sGXOnClickCode, sUserOnClickCode, sLinkURL, sLinkTarget) {
				if (sUserOnClickCode != '')
				{
					if (sGXOnClickCode != '')
						parentCtrl.append('<a href="javascript:if( ' + sUserOnClickCode + ') {' + sGXOnClickCode + '}">');
					else
						parentCtrl.append('<a href="javascript:' + sUserOnClickCode + '">');
				}
				else
				{
				  if (sGXOnClickCode != '')
				  	parentCtrl.append('<a href="javascript:' + sGXOnClickCode + '">');
				  else
				  {
						if (sLinkURL != '')
						{
							parentCtrl.append('<a href="' + sLinkURL + '"');
							if (sLinkTarget != '')
								parentCtrl.append(' target="' + sLinkTarget + '"');
							parentCtrl.append('>');
						}
				  }
				}
			},
			
			endAnchor: function( parentCtrl, sGXOnClickCode, sUserOnClickCode, sLinkURL) {
				if (sGXOnClickCode != '' || sUserOnClickCode != '' || sLinkURL != '')
					parentCtrl.append('</a>');
			},
			
			onJSEvent: function( parentCtrl, sEventName, sEventJsCode, sUserOnClickCode) {
				parentCtrl.append(' ');
				if (sUserOnClickCode != '')
					parentCtrl.append('jsevent="' + sUserOnClickCode + '" ');
				parentCtrl.append( sEventName + '="if( ');
				if (sEventJsCode != '')
					parentCtrl.append( 'gx.evt.jsEvent(this)) {' + sEventJsCode + '} else return false;"');
				else
					parentCtrl.append( '!gx.evt.jsEvent(this)) return false;"') ;
			},
			
			htmlControl: function( id, width, height, cssClass, title) {
				this.id = id || '';
				this.width = width || 0;
				this.widthUnit = 'px';
				this.height = height || 0;
				this.heightUnit = 'px';
				this.cssClass = cssClass || '';
				this.roClass = '';
				this.ownCssClass = '';
				this.style = '';
				this.title = title || '';
				this.value = '';
				this.type = -1;
				this.dataType = '';
				this.visible = true;
				this.enabled = true;
				this.rtEnabled = false;
				this.link = '';
				this.linkTarget = '';
				this.jsEvent = '';
				this.hasJsLink = false;
				this.extraAttributes = '';
				this.grid = null;
				this.row = null;
				this.column = null;
				this.gridId = '';
				this.gridRow = '';
				this.buffer = new gx.text.stringBuffer();
				
				this.getHtml = function()
				{
					this.buffer.clear();
					this._getHtml();
					return this.buffer.toString();
				}
				
				this.append = function( value)
				{
					return this.buffer.append( value);
				}
				
				this.tagAtt = function( name, value)
				{
					return this.buffer.append(' ' + name + '="' + value + '"');
				}
				
				this.persistValue = function()
				{
					if (!gx.lang.emptyObject(this.column.gxId) && !gx.lang.emptyObject(this.grid.parentObject.GXValidFnc[this.column.gxId]))
					{						
						if (this._persistValue)
							this._persistValue();
						else							
							this.grid.parentObject.GXValidFnc[this.column.gxId].v2v(this.value);
					}
				}
			},
		
			singleLineEdit: function( id, width, height, cssClass, title) {
				this.base(id, width, height, cssClass, title);

				this.type = gx.html.controls.types.singleLineEdit;
				this.maxLength = '';				
				this.isPassword = false;
				
				this.setProperties = function( sCtrlName, sTooltipText, nWidth, nWidthUnit, nHeight, nHeightUnit, nLength, nVisible, nEnabled, nRTEnabled, nIsPassword, nFormat, sLinkURL,
                            					 sLinkTarget, sStyleString, sClassString, sROClassString, sFormatedValue, sTags, nJScriptCode, sUserOnClickCode, sEventName, nParentId, bHasTheme,
                           						 nAutoComplete, bSendHidden, sAlign, sValue)
        {
        	this.id = sCtrlName;
        	this.title = sTooltipText;
        	this.width = nWidth;
        	this.widthUnit = nWidthUnit;
        	this.height = nHeight;
        	this.heightUnit = nHeightUnit;
        	this.maxLength = nLength;
        	this.visible = (nVisible != 0);
        	this.enabled = (nEnabled != 0);
        	this.rtEnabled = (nRTEnabled != 0);
        	this.isPassword = (nIsPassword != 0);
        	this.format = nFormat;
        	this.link = sLinkURL;
        	this.linkTarget = sLinkTarget;
        	this.style = sStyleString;
        	this.cssClass = sClassString;
        	this.roClass = sROClassString;
        	this.formattedValue = gx.html.encodeCaseFormat(sFormatedValue, nFormat);
        	this.extraAttributes = sTags;
        	this.jsScrCode = nJScriptCode;
        	this.usrOnclick = sUserOnClickCode;
        	this.eventName = sEventName;
        	this.parentId = nParentId;
        	this.hasTheme = bHasTheme;
        	this.autoComplete = (nAutoComplete != 0);
					this.value = sValue;
        }
				
				this._getHtml = function()
				{
					var sSize = '';
					var sOStyle = '';
					if (this.width > 0)
					{
						if (this.widthUnit == 'chr')
							sSize = ' size="' + this.width + '"';
						else
							this.style = this.style + ';width: ' + this.width + this.widthUnit + ';';
					}
					if (this.height > 0 && this.heightUnit != 'row')
						this.style = this.style + ';height: ' + this.height + this.heightUnit + ';';
					sOStyle = this.style;
					this.style = this.style + ((!this.visible || (!this.enabled && this.rtEnabled))?';display:none;':'');
         	if (this.rtEnabled || this.enabled)
         	{
         		if((this.dataType == gx.types.date) || (this.dataType == gx.types.dateTime))
						{
							this.append('<table');
							this.tagAtt('id', this.id + '_dp_container');
							this.tagAtt('cellpadding', '0');
							this.tagAtt('cellspacing', '0');
							if (this.style != '')
	    						this.tagAtt('style', this.style);
							this.append('><tr><td>') ;
						}
						this.append('<input');
						if (this.isPassword == true)
							this.tagAtt('type', 'password');
						else
							this.tagAtt('type', 'text');
						this.tagAtt('id', this.id)
						this.tagAtt('name', this.id);
						if (this.formattedValue)
						    this.tagAtt('value', gx.text.ltrim(this.formattedValue));
						    //ltrim for backwards compatibility
						else
						    this.tagAtt('value', this.value);
						this.append(sSize);
						if (this.title != '')
							this.tagAtt('title', this.title);
						if (!this.autoComplete)
							this.tagAtt('autocomplete', 'off');
						this.tagAtt('maxlength', this.maxLength);
						if (this.cssClass != '')
						 	this.tagAtt('class', this.cssClass);
						var rowStyle = this.style;
						if (this.column.align != '')
							rowStyle += ";text-align:" + this.column.align;
						if (rowStyle != '')
							this.tagAtt('style', rowStyle);
						this.append(this.extraAttributes);
						this.append('>');
						if ((this.dataType == gx.types.date) || (this.dataType == gx.types.dateTime))
						{
							this.append('</td><td>') ;
							this.append('<img');
							this.tagAtt('src', gx.util.resourceUrl(gx.basePath + gx.staticDirectory + "calendar-img.gif", true));
							this.tagAtt('id', this.id + '_dp_trigger');
							this.tagAtt('style', 'cursor: pointer;');
							this.tagAtt('title', 'Date selector');
							this.append('></td></tr></table>') ;
							this.grid.addDatepickerToSetup({CtrlId:this.id, Grid:this.gridId, Row:this.gridRow});
						}
					}
					if (!this.enabled)
					{
						var ClassHTML = '';
						if (!this.rtEnabled)
							this.grid.addHiddenControl( this.id, this.value);
						if (!this.hasTheme)
							ClassHTML = this.cssClass;
						else
						{
							if (this.parentId == 0)
							{
								if (this.cssClass != '' && this.cssClass.indexOf('Readonly') != 0)
									ClassHTML = 'Readonly' + this.cssClass;
								else
									ClassHTML = this.cssClass;
							}
							else
							{
								if (this.roClass != '' && this.roClass.indexOf('Readonly') != 0)
									ClassHTML = 'Readonly' + this.roClass;
								else
									ClassHTML = this.roClass;
							}
						}
						var sEventJsCode = '';
						if (this.format != gx.html.controls.formats.RAW_HTML)
						{
							sOStyle = sOStyle + ((!this.visible)?';display:none;':'');
							this.append('<span');
							this.append(this.extraAttributes);
							if (ClassHTML != '')
							 	this.tagAtt('class', ClassHTML);
							if (sOStyle != '')
								this.tagAtt('style', sOStyle);
							if (this.title != '')
								this.tagAtt('title', this.title);
							this.tagAtt('id', 'span_' + this.id);
							this.append('>');
							sEventJsCode = gx.html.controls.eventJSCode( this.jsScrCode, this.eventName, null, this.grid, this.row);
							gx.html.controls.startAnchor( this, sEventJsCode, this.usrOnclick, this.link, this.linkTarget);
						}
						if (!this.isPassword)
						{
							this.append( this.formattedValue);
						}
						else
						{
							var maxLen = gx.lang.emptyObject(this.maxLength)?3:parseInt(this.maxLength);
							for(var i=0; i<maxLen; i++)
								this.append('*');
						}
						if (this.format != gx.html.controls.formats.RAW_HTML)
						{
							gx.html.controls.endAnchor( this, sEventJsCode, this.usrOnclick, this.link);
							this.append('</span>');
						}
						if (this.format == gx.html.controls.formats.RAW_HTML)
							gx.html.processCode( this.buffer.toString(), false);
					}
				}
			},
		
			multipleLineEdit: function( id, width, height, cssClass, title) {
				this.base(id, width, height, cssClass, title);
				
				this.type = gx.html.controls.types.multipleLineEdit;
				
				this.setProperties = function( sCtrlName, nVisible, nEnabled, nRTEnabled, nWidth, nWidthUnit, nHeight, nHeightUnit, sStyleString, sClassString, nLength, sTags,
																				nAutoresize, nFormat, sLinkURL, sLinkTarget, bSendHidden, sValue)
				{
					this.id = sCtrlName;
					this.visible = (nVisible != 0);
					this.enabled = (nEnabled != 0);
					this.rtEnabled = (nRTEnabled != 0);
					this.width = nWidth;
					this.widthUnit = nWidthUnit;
					this.height = nHeight;
					this.heightUnit = nHeightUnit;
					this.style = sStyleString;
					this.cssClass = sClassString;
					this.maxLength = nLength;
					this.extraAttributes = sTags;
					this.autoresize = (nAutoresize != 0);
					this.format = nFormat;
					this.link = sLinkURL;
					this.linkTarget = sLinkTarget;
					this.value = sValue;
				}

				this._getHtml = function()
				{
					this.style = this.style + ((!this.visible || (!this.enabled && this.rtEnabled))?';display:none;':'');
					if (this.rtEnabled || this.enabled)
					{
						this.append('<textarea');
						if (this.widthUnit == 'chr')
							this.tagAtt('cols', this.width);
						else
							this.style = this.style + ';width: ' + this.width + this.widthUnit;
						if (this.heightUnit == 'row')
							this.tagAtt('rows', this.height);
						else
							this.style = this.style + ';height: ' + this.height + this.heightUnit;
						this.tagAtt('id', this.id);
						this.tagAtt('name', this.id);
						this.tagAtt('maxlength', this.maxLength);
						if (this.cssClass != '')
						 	this.tagAtt('class', this.cssClass);
						if (this.style != '')
							this.tagAtt('style', this.style);
						if (this.title != '')
							this.tagAtt('title', this.title);
						this.append(this.extraAttributes);
						this.append('>');
						this.append(this.value);
						this.append('</textarea>');
					}
					if (!this.enabled)
					{
						var sOStyle = (!this.visible?'display:none;':'');
						if (!this.autoresize)
							sOStyle += 'overflow="hidden";';
						if (!this.rtEnabled)
							this.grid.addHiddenControl( this.id, this.value);
						if (this.cssClass != '' && this.cssClass.indexOf('Readonly') != 0)
							this.cssClass = 'Readonly' + this.cssClass;
						this.append('<span ');
						this.append(this.extraAttributes);
						if (this.cssClass != '')
							this.tagAtt('class', this.cssClass);
						if (sOStyle != '')
							this.tagAtt('style', sOStyle);
						if (this.title != '')
							this.tagAtt('title', this.title);
						this.tagAtt('id', 'span_' + this.id);
						this.append('>');
						gx.html.controls.startAnchor( this, '', '', this.link, this.linkTarget);
						this.append(this.value);
						gx.html.controls.endAnchor( this, '', '', this.link);
						this.append('</span>');
					}
				}
			},

			blob: function( id, width, height, cssClass, title, dislplay, contentType) {
				this.base(id, width, height, cssClass, title);
				
				this.type = gx.html.controls.types.blob;
				this.display = dislplay || 0;
				this.contentType = contentType || 'text/html';
				this.url = '';
				this.parameters = '';
				
				this.setProperties = function( sInternalName, sValue, sContenttype, bHasFiletypeatt, sLinkTarget, sObjecttagparameters, nDisplay, nEnabled, nVisible, sAlternateText, sTooltipText, nBorderWidth,
                                       nAutoresize, nWidth, nWidthUnit, nHeight, nHeightUnit, nVerticalSpace, nHorizontalSpace, nJScriptCode, sUserOnClickCode, sEventName, sStyleString, sClassString,
                                       sTags, sJsDynCode, sURL)
				{
			        	this.id = sInternalName;
			        	this.value = sValue;
			        	this.contentType = sContenttype || 'text/html';
			        	this.linkTarget = sLinkTarget;
			        	this.parameters = sObjecttagparameters;
			        	this.display = nDisplay;
			        	this.visible = (nVisible != 0);
			        	this.enabled = (nEnabled != 0);
			        	this.alt = sAlternateText;
			        	this.title = sTooltipText;
			        	this.borderWidth = nBorderWidth;
			        	this.autoresize = (nAutoresize != 0);
			        	this.width = nWidth;
			        	this.widthUnit = nWidthUnit;
			        	this.height = nHeight;
			        	this.heightUnit = nHeightUnit;
			        	this.vSpace = nVerticalSpace;
			        	this.hSpace = nHorizontalSpace;
			        	this.jsScrCode = nJScriptCode;
			        	this.usrOnclick = sUserOnClickCode;
			        	this.eventName = sEventName;
			        	this.style = sStyleString;
			        	this.cssClass = sClassString;
			        	this.extraAttributes = sTags;
			        	this.jsDynCode = sJsDynCode;
					this.url = sURL;
				}
				
				this._getHtml = function()
				{
					var ClassHTML = '';
					this.style = this.style + ((this.visible)?'':';display:none;');
					this.append('<span ');
					if (this.vSpace != 0)
						this.tagAtt('vspace', this.vSpace);
					if (this.hSpace != 0)
						this.tagAtt('hspace', this.hSpace);
					if (this.alt != '')
						this.tagAtt('alt', this.alt);
					if (this.title != '')
						this.tagAtt('title', this.title);
					this.append('>');
					this.append('<table');
					this.tagAtt('border', 0);
					this.tagAtt('cellpadding', 0);
					this.tagAtt('cellspacing', 0);
					this.append('><tr><td>');
					if (this.display == 0)
					{
						var imgType = (this.contentType.toLowerCase().indexOf('image/') != -1);
						if (imgType)
						{
							this.append('<img');
							if (this.url == '')
								this.url = gx.util.resourceUrl(gx.basePath + gx.staticDirectory + "blank.jpg", true);
							this.tagAtt('src', this.url);
						}
						else
						{
							this.append('<object');
							this.tagAtt('type', this.contentType);
							if (this.url == '')
								this.url = 'about:blank';
							this.tagAtt('data', this.url);
						}
						this.tagAtt('id', 'Object_' + this.id);
						this.style = this.style + 'display:block;';
						if(this.width != 0 && !this.autoresize)
							this.style = this.style + 'width:' + this.width + this.widthUnit + ';';
						if(this.height != 0 && !this.autoresize)
							this.style = this.style + 'height:' + this.height + this.heightUnit + ';';
						this.tagAtt('style', this.style);
						if (this.cssClass != '')
							ClassHTML = 'BlobContent' + this.cssClass;
						else
							ClassHTML = this.cssClass;
						if (!this.enabled && this.cssClass != '' && this.cssClass.indexOf('Readonly') != 0)
							ClassHTML = 'Readonly' + ClassHTML;
						this.tagAtt('class', ClassHTML);
						this.append(this.extraAttributes);
						this.append('>');
						if (imgType)
							this.append('</img>');
						else
						{
							this.append(this.parameters);
							this.append('</object>');
						}
					}
					else if (this.display == 1)
					{
						this.append('<a');
						this.tagAtt('id', 'Link_' + this.id);
						if (this.url != '')
							this.style = this.style + 'display:block;';
						else
							this.style = this.style + 'display:none;';
						this.tagAtt('style', this.style);
						this.tagAtt('href', this.url);
						this.tagAtt('type', this.contentType);
						if (this.linkTarget != '')
							this.tagAtt('target', this.linkTarget);
						this.append('><img');
						this.tagAtt('border', '0');
						this.tagAtt('src', gx.util.resourceUrl(gx.basePath + gx.staticDirectory + 'download.gif'));
						this.append('></a>');
					}
					this.append('</td></tr><tr><td>');
					if (this.enabled)
					{
						var inputStyle = '';
						gx.dom.form().encoding = 'multipart/form-data';
						this.append('<input');
						this.tagAtt('type', 'file');
						this.tagAtt('id', this.id);
						this.tagAtt('name', this.id);
						if (!this.visible)
							inputStyle = inputStyle + 'display:none;';
						if (this.width != 0)
							inputStyle = inputStyle + 'width:' + this.width + ';';
						this.tagAtt('style', inputStyle);
						this.tagAtt('value', this.value);
						if (this.cssClass != '')
							ClassHTML = 'BlobInput' + this.cssClass;
						else
							ClassHTML = this.cssClass;
						if (!this.enabled && this.cssClass != '' && this.cssClass.indexOf('Readonly') != 0)
							ClassHTML = 'Readonly' + ClassHTML;
						this.tagAtt('class', ClassHTML);
						this.append(this.extraAttributes);
						this.append('>');
					}
					this.append('</td></tr></table>');
					this.append('</span>');
				}
			},
			
			radio: function( id, width, height, cssClass, title) {
				this.base(id, width, height, cssClass, title);
				
				this.type = gx.html.controls.types.radio;
				this.vertical = true;
				this.possibleValues = [];
				
				this.setProperties = function( radRObjCtrl, sCtrlName, sTooltipText, nVisible, nEnabled, nRadioColumns, nOrientation, sStyleString, sClassString, nJScriptCode, sUserOnClickCode, sEventName, sTags, sValue)
        {
        	this.possibleValues = radRObjCtrl.v || [];
        	this.id = sCtrlName;
					this.title = sTooltipText;
        	this.visible = (nVisible != 0);
        	this.enabled = (nEnabled != 0);
					this.columns = nRadioColumns;
					this.orientation = nOrientation;
					this.style = sStyleString;
        	this.cssClass = sClassString;
        	this.jsScrCode = nJScriptCode;
        	this.usrOnclick = sUserOnClickCode;
        	this.eventName = sEventName;
        	this.extraAttributes = sTags;
					this.value = sValue;
        }
				
				this._getHtml = function()
				{
					if (this.dataType == gx.types.numeric)
						this.value = gx.text.trim(this.value.toString());
					var ClassHTML = '';
					if (!this.enabled && this.cssClass != '' && this.cssClass.indexOf('Readonly') != 0)
						ClassHTML = 'Readonly' + this.cssClass;
					else
						ClassHTML = this.cssClass;
					var sEventJsCode = gx.html.controls.eventJSCode( this.jsScrCode, this.eventName, null, this.grid, this.row);
					this.style = this.style + ((this.visible)?'':';display:none;');
					if (this.orientation == 1)
						this.append('<table');
					else
						this.append('<span ');
					this.tagAtt('class', ClassHTML);
					if (this.style != '')
						this.tagAtt('style', this.style);
					this.append('>');
					var idxCol = 0;
					var len = this.possibleValues.length;
					for (var i=0; i<len; i++)
					{
						var item = this.possibleValues[i];
						var itemValue = item[0];
						var itemDesc = item[1];
						if (this.orientation == 1)
						{
							if (this.columns > 1)
								idxCol = (idxCol+1) % this.columns;
							if (idxCol == 0)
								this.append('<tr>');
							this.append('<td>');
						}
						this.append('<input');
						this.tagAtt('type', 'radio');
						this.tagAtt('name', this.id);
						this.tagAtt('value', itemValue);
						if (this.title != '')
							this.tagAtt('title', this.title);
						var isChecked = (this.value.toString() == itemValue.toString());
						if (isChecked)
							this.append(' checked');
						if (!this.enabled)
							this.append(' disabled');
						this.append(this.extraAttributes);
						gx.html.controls.onJSEvent( this, 'gxoch0', sEventJsCode, this.usrOnclick);
						this.append('>');
						this.append(itemDesc);
						if (this.orientation == 1)
						{
							this.append('</td>');
							if (idxCol == 0)
								this.append('</tr>');
						}
					}
					if (this.orientation == 1)
						this.append('</table>');
					else
						this.append('</span>');
				}
			},
			
			comboBox: function( id, width, height, cssClass, title) {
				this.base(id, width, height, cssClass, title);
				
				this.type = gx.html.controls.types.comboBox;
				this.rows = 1;
				this.possibleValues = [];
				
				this.setProperties = function( cmbCObjCtrl, sCtrlName, sTooltipText, sType, nVisible, nEnabled, nRTEnabled, nRows, nFormat, nWidth, nWidthUnit, nHeight, nHeightUnit, sStyleString, sClassString,
                                       sFormatedValue, nJScriptCode, sUserOnClickCode, sEventName, sTags, bSendHidden, sValue)
				{
					this.possibleValues = cmbCObjCtrl.v || [];
					this.id = sCtrlName;
					this.title = sTooltipText;
					this.visible = (nVisible != 0);
					this.enabled = (nEnabled != 0);
					this.rtEnabled = (nRTEnabled != 0);
					this.rows = nRows;
					this.format = nFormat;
					this.width = nWidth;
					this.widthUnit = nWidthUnit;
					this.height = nHeight;
					this.heightUnit = nHeightUnit;
					this.style = sStyleString;
					this.cssClass = sClassString;
					this.formattedValue = sFormatedValue;
					this.jsScrCode = nJScriptCode;
					this.usrOnclick = sUserOnClickCode;
					this.eventName = sEventName;
					this.extraAttributes = sTags;
					this.value = sValue;
				}
				
				this._getHtml = function()
				{
					if (this.dataType == gx.types.numeric)
						this.value = gx.text.trim(this.value.toString());
					if (this.width > 0)
						this.style = this.style + ';width: ' + this.width + this.widthUnit;
					if (this.height > 0)
						this.style = this.style + ';height: ' + this.height + this.heightUnit;
					var sOStyle = this.style + ' ;overflow:hidden;';
					this.style = this.style + ((!this.visible || !this.enabled && this.rtEnabled)?';display:none;':'');
					if (this.enabled || this.rtEnabled)
					{
						var sEventJsCode = gx.html.controls.eventJSCode( this.jsScrCode, this.eventName, null, this.grid, this.row);
						this.append('<select');
						if (this.rows > 1)
							this.tagAtt('size', this.rows);
						this.tagAtt('id', this.id);
						this.tagAtt('name', this.id);
						if (this.title != '')
							this.tagAtt('title', this.title);
						if (this.cssClass != '')
						 	this.tagAtt('class', this.cssClass);
						if (this.style != '')
							this.tagAtt('style', this.style);
						if (!this.enabled)
							this.append(' disabled');
						this.append(this.extraAttributes);
						gx.html.controls.onJSEvent( this, 'gxoch0', sEventJsCode, this.usrOnclick);
						this.append('>');
						var len = this.possibleValues.length;
						for (var i=0; i<len; i++)
						{
							var item = this.possibleValues[i];
							this.append('<option');
							this.tagAtt('value', item[0]);
							if (gx.text.trim(item[0].toString()) == gx.text.trim(this.value.toString()))
								this.append(' selected');
							this.append('>');
							this.append(item[1]);
							this.append('</option>');
						}
						this.append('</select>');
					}
					if (!this.enabled)
					{
						if (!this.rtEnabled)
							this.grid.addHiddenControl( this.id, this.value);
						var ClassHTML = '';
						if (this.cssClass != '' && this.cssClass.indexOf('Readonly') != 0)
							ClassHTML = 'Readonly' + this.cssClass;
						else
							ClassHTML = this.cssClass;
						sOStyle = sOStyle + ((!this.visible)?';display:none;':'');
						this.append('<span ');
						this.tagAtt('id', 'span_' + this.id);
						if (this.title != '')
							this.tagAtt('title', this.title);
						if (ClassHTML != '')
						 	this.tagAtt('class', ClassHTML);
						if (sOStyle != '')
							this.tagAtt('style', sOStyle);
						this.append(this.extraAttributes);
						this.append('>');
						var len = this.possibleValues.length;
						for (var i=0; i<len; i++)
						{
							var item = this.possibleValues[i];
							if (gx.text.trim(item[0].toString()) == gx.text.trim(this.value.toString()))
							{
								this.append(item[1]);
								break;
							}
						}
						this.append('</span>');
					}
				}
			},
		
			listBox: function( id, width, height, cssClass, title, rows) 	{
				this.base(id, width, height, cssClass, title);
				
				this.type = gx.html.controls.types.listBox;
				this.rows = rows;
			},

			checkBox: function( id, width, height, cssClass, title, caption, checkedValue, uncheckedValue) {
				this.base(id, width, height, cssClass, title);
				
				this.type = gx.html.controls.types.checkBox;
				this.caption = caption || '';
				this.checkedValue = checkedValue;
				this.uncheckedValue = uncheckedValue;
				
				this.setProperties = function( sCtrlName, sTooltipText, nVisible, nEnabled, sCheked, sCaption, sStyleString, sClassString, sTags, sValue)
        {
        	this.id = sCtrlName;
					this.title = sTooltipText;
        	this.visible = (nVisible != 0);
        	this.enabled = (nEnabled != 0);
        	this.checkedValue = sCheked;
					this.caption = sCaption;
					this.style = sStyleString;
        	this.cssClass = sClassString;
        	this.extraAttributes = sTags;
					this.value = sValue;
        }
				
				this._getHtml = function()
				{
					if (this.dataType == gx.types.numeric)
					{
						this.value = gx.text.trim(this.value.toString());
						this.checkedValue = gx.text.trim(this.checkedValue.toString());
					}
					var ClassHTML = this.cssClass;
					if (!this.enabled && this.cssClass != '' && this.cssClass.indexOf('Readonly') != 0)
						ClassHTML = 'Readonly' + this.cssClass;
					this.style = this.style + ((this.visible)?'':';display:none;');
					this.append('<span ');
					if (ClassHTML != '')
					 	this.tagAtt('class', ClassHTML);
					if (this.style != '')
						this.tagAtt('style', this.style);
					this.append('><input');
					this.tagAtt('type', 'checkbox');
					this.tagAtt('name', this.id);
					var isChecked = (this.value.toString() == this.checkedValue.toString());
					if (isChecked)
					{
						this.append(' checked');
						this.tagAtt('value', this.checkedValue);
					}
					else
						this.tagAtt('value', this.uncheckedValue);
					if (this.title != '')
						this.tagAtt('title', this.title);
					if (!this.enabled)
						this.append(' disabled');
					this.append(this.extraAttributes);
					this.append('>');
					this.append(this.caption);
					this.append('</span>');
				}
			},
		
			image: function( id, width, height, cssClass, title) {
				this.base(id, width, height, cssClass, title);
				
				this.type = gx.html.controls.types.image;
				this.alt = '';
				
				this.setProperties = function( sInternalName, sAccesskey, sThemeName, nVisible, nEnabled, sAlternateText, sTooltipText, nBorderWidth, nAutoresize, nWidth, nWidthUnit, nHeight, nHeightUnit, nVerticalSpace,
                                       nHorizontalSpace, sLinkURL, sLinkTarget, nJScriptCode, sUserOnClickCode, sEventName, sStyleString, sClassString, sAlign, sTags, sUseMap, sJsDynCode, sImageURL)
        {
        	this.id = sInternalName;
        	this.accessKey = sAccesskey;
        	this.visible = (nVisible != 0);
        	this.enabled = (nEnabled != 0);
        	this.alt = sAlternateText;
        	this.title = sTooltipText;
        	this.borderWidth = nBorderWidth;
        	this.autoresize = (nAutoresize != 0);
        	this.width = nWidth;
        	this.widthUnit = nWidthUnit;
        	this.height = nHeight;
        	this.heightUnit = nHeightUnit;
        	this.vSpace = nVerticalSpace;
        	this.hSpace = nHorizontalSpace;
        	this.link = sLinkURL;
        	this.linkTarget = sLinkTarget;
        	this.jsScrCode = nJScriptCode;
        	this.usrOnclick = sUserOnClickCode;
        	this.eventName = sEventName;
        	this.style = sStyleString;
        	this.cssClass = sClassString;
        	this.align = sAlign;
        	this.extraAttributes = sTags;
        	this.useMap = sUseMap;
        	this.jsDynCode = sJsDynCode;
        	this.imageUrl = sImageURL;
                    if (gx.ajax.isabsoluteurl(sImageURL))
                        this.value = sImageURL;
                    else
                        this.value = gx.util.resourceUrl(gx.basePath + gx.staticDirectory + sImageURL, false);
        }
				
				this._getHtml = function()
				{
					this.grid.addHiddenControl( 'GXimg' + this.id, this.imageUrl);
					if (this.eventName != '' && gx.text.endsWith(this.eventName, '.'))
						this.eventName += this.gridRow;
					var sCapAKey = gx.util.accessKey( this.title);
					this.title = gx.util.accessKeyCaption( this.title);
					if (sCapAKey != '')
						this.accessKey = sCapAKey;
					this.style = this.style + ((this.visible)?'':';display:none;');
					var sEventJsCode = gx.html.controls.eventJSCode( this.jsScrCode, this.eventName, this.jsDynCode, this.grid, this.row);
					if (sEventJsCode != '')
					{
						this.append('<input');
						this.tagAtt('type', 'image');
						this.tagAtt('src', this.value);
						this.tagAtt('name', this.id);
						gx.html.controls.onJSEvent( this, 'onclick', sEventJsCode + 'return false;', this.usrOnclick);
					}
					else
					{
						if (this.enabled && this.link != '')
							gx.html.controls.startAnchor( this, sEventJsCode, this.usrOnclick, this.link, this.linkTarget);
						this.append('<img');
						this.tagAtt('src', this.value);
					}
					if (!this.enabled)
						this.append(' disabled') ;
					if (this.accessKey != '')
						this.tagAtt('accesskey', this.accessKey);
					this.tagAtt('id', this.id);
					if (this.vSpace != 0)
						this.tagAtt('vspace', this.vSpace);
					if (this.hSpace != 0)
						this.tagAtt('hspace', this.hSpace);
					if (this.align != '')
						this.tagAtt('align', this.align);
					if (this.cssClass == '' || this.borderWidth > 0)
					{
						this.tagAtt('border', this.borderWidth);
					  if (this.cssClass != '')
					     this.style = this.style + ';border-width: ' + this.borderWidth;
					}
					if (this.alt != '')
						this.tagAtt('alt', this.alt);
					if (this.title != '')
						this.tagAtt('title', this.title);
					if (this.width > 0)
						this.style = this.style + ';width: ' + this.width + this.widthUnit;
					if (this.height > 0)
						this.style = this.style + ';height: ' + this.height + this.heightUnit;
					if (this.cssClass != '')
					 	this.tagAtt('class', this.cssClass);
					if (this.style != '')
					 	this.tagAtt('style', this.style);
					if (this.useMap != '')
					 	this.tagAtt('usemap', this.useMap);
					this.append('>');
					if (this.enabled && this.link != '' && sEventJsCode == '')
						gx.html.controls.endAnchor( this, sEventJsCode, this.usrOnclick, this.link);
				},
				
				this._persistValue = function()
				{
					this.grid.parentObject.GXValidFnc[this.column.gxId].v2v(this.imageUrl);
				}
			},
		
			textBlock: function( id, width, height, cssClass, title) 	{
				this.base(id, width, height, cssClass, title);
				
				this.type = gx.html.controls.types.textBlock;
				
				this.setProperties = function( sInternalName, nVisible, nEnabled, nFormat, sTooltipText, sLinkURL, sLinkTarget, nJScriptCode, sUserOnClickCode, sEventName, sTags, sClassString, sCaption)
        {
        	this.id = sInternalName;
        	this.visible = (nVisible != 0);
        	this.enabled = (nEnabled != 0);
        	this.format = nFormat;
        	this.title = sTooltipText;
        	this.link = sLinkURL;
        	this.linkTarget = sLinkTarget;
        	this.jsScrCode = nJScriptCode;
        	this.usrOnclick = sUserOnClickCode;
        	this.eventName = sEventName;
        	this.extraAttributes = sTags;
        	this.cssClass = sClassString;
        	this.value = sCaption;
        }
				
				this._getHtml = function()
				{
					var sStyle;
					if (this.format != gx.html.controls.formats.RAW_HTML)
					{
					    if (this.format == gx.html.controls.formats.HTML)
					    {
						    sStyle = ((this.visible)?';display:inline':';display:none;') + this.extraAttributes;
						    this.append('<div ');
					    }else{
						    sStyle = ((this.visible)?'':';display:none;') + this.extraAttributes;
    						this.append('<span ');
					    }
						this.tagAtt('id', this.id);
						if (this.cssClass != '')
					 		this.tagAtt('class', this.cssClass);
						this.tagAtt('gxformat', this.format);
						if (sStyle != '')
							this.tagAtt('style', sStyle);
						if (this.title != '')
							this.tagAtt('title', this.title);
						this.append('>');
					}
					var sEventJsCode = '';
					if (this.enabled)
					{
						sEventJsCode = gx.html.controls.eventJSCode( this.jsScrCode, this.eventName, null, this.grid, this.row);
						gx.html.controls.startAnchor( this, sEventJsCode, this.usrOnclick, this.link, this.linkTarget);
					}
					else
						sEventJsCode = '';
					this.append(this.value);
					if (this.enabled)
						gx.html.controls.endAnchor( this, sEventJsCode, this.usrOnclick, this.link);
					if (this.format == gx.html.controls.formats.HTML)
					    this.append('</div>');
					else if (this.format != gx.html.controls.formats.RAW_HTML)
						this.append('</span>');
					if (this.format == gx.html.controls.formats.RAW_HTML)
						gx.html.processCode( this.buffer.toString(), false);
				}
			},

			button: function( id, width, height, cssClass, title, buttonStyle) {
				this.base(id, width, height, cssClass, title);
				
				this.type = gx.html.controls.types.button;
				this.caption = '';
				this.buttonStyle = buttonStyle || 'rounded';
				
				this.setProperties = function( nReset, sCtrlName, sTooltipText, sAccesskey, sStyleString, sClassString, nVisible, nEnabled, sBorderStyle, nJScriptCode, sUserOnClickCode, sEventName,
                                       sTags, sJsCode, sJsDynCode, sCaption)
				{
					this.reset = nReset;
					this.id = sCtrlName;
					this.title = sTooltipText;
					this.accessKey = sAccesskey;
					this.style = sStyleString;
					this.cssClass = sClassString;
					this.visible = (nVisible != 0);
					this.enabled = (nEnabled != 0);
					this.buttonStyle = sBorderStyle;
					this.jsScrCode = nJScriptCode;
					this.usrOnclick = sUserOnClickCode;
					this.eventName = sEventName + this.gridRow;
					this.extraAttributes = sTags;
					this.jsCode = sJsCode;
					this.jsDynCode = sJsDynCode;
					this.caption = sCaption;
				}
				
				this._getHtml = function()
				{
					this.style = this.style + ((this.visible)?'':';display:none;');
					var sClassRoundedBtn = 'BaseRBtn ' + 'R' + this.cssClass;
					if (this.buttonStyle == 'rounded')
					{
						this.cssClass = 'BtnText';
						this.append('<span ');
						this.tagAtt('onclick', 'gx.evt.doClick(' + this.id + ', event);');
						if (this.style != '')
							this.tagAtt('style', this.style);
						this.tagAtt('class', sClassRoundedBtn);
						this.append('><span class="BtnLeft"><span class="BtnRight"><span class="BtnBackground">');
					}
					this.append('<input');
					var inputType = 'button';
					if (this.reset == 1)
						inputType = 'submit';
					else if (this.reset == 0)
						inputType = 'reset';
					this.tagAtt('type', inputType);
					var sCapAKey = gx.util.accessKey( this.caption);
					this.caption = gx.util.accessKeyCaption( this.caption);
					if (sCapAKey == '')
					{
						sCapAKey = gx.util.accessKey( this.title);
						this.title = gx.util.accessKeyCaption( this.title);
					}
					if (sCapAKey != '')
						this.accessKey = sCapAKey;
					this.tagAtt('name', this.id);
					this.tagAtt('value', this.caption);
					if (this.title != '')
						this.tagAtt('title', this.title);
					if (this.accessKey != '')
						this.tagAtt('accesskey', this.accessKey);
					this.tagAtt('class', this.cssClass);
					if (this.style != '')
						this.tagAtt('style', this.style);
					this.tagAtt('gxevent', this.eventName);
					if (!this.enabled)
						this.append(' disabled');
					var sEventJsCode = gx.html.controls.eventJSCode( this.jsScrCode, this.eventName, this.jsDynCode, this.grid, this.row);
					sEventJsCode = this.jsCode + sEventJsCode;
					gx.html.controls.onJSEvent( this, 'onclick', sEventJsCode + 'return false;', this.usrOnclick);
					this.append(this.extraAttributes);
					this.append('>');
					if (this.buttonStyle == 'rounded')
						this.append('</span></span></span></span>');
				}
			},

			grid: function( id, width, height, cssClass, title) {
				this.base(id, width, height, cssClass, title);
				
				this.type = gx.html.controls.types.grid;
				this.containerName = '';

				this.setProperties = function( sContainerName)
        {
					this.containerName = sContainerName;
					this.id = this.grid.gxComponentContext + this.containerName + 'Div_' + this.gridRow;
        }
				
				this._getHtml = function()
				{
					this.append('<div');
					this.tagAtt('id', this.id);
					this.append('></div>');
				}
			},

			userControl: function( id, width, height, cssClass, title) {
				this.base(id, width, height, cssClass, title);
				
				this.type = gx.html.controls.types.userControl;
				this.containerName = '';
				
				this.setProperties = function( sContainerName)
        {
					this.containerName = sContainerName;
					this.id = this.containerName;
        }

				this._getHtml = function()
				{
					this.append('<div');
					this.tagAtt('id', this.id);
					this.tagAtt('class', 'gx_usercontrol');
					this.append('></div>');
					this.grid.addUsercontrolToDraw({r:this.gridRow,c:this.column});
				}
			},
			
			userControlContainer: function( id, width, height, cssClass, title) {
				this.base(id, width, height, cssClass, title);
				
				this.type = gx.html.controls.types.userControlContainer;
				this.parentName = '';
				this.containerName = '';
				
				this.setProperties = function( sParentName, sContainerName)
        {
        				this.parentName = sParentName;
					this.containerName = sContainerName;
					this.id = this.parentName + this.containerName + '_' + this.gridRow;
        }

				this._getHtml = function()
				{
					this.append('<div');
					this.tagAtt('id', this.id);
					this.tagAtt('style', 'display:none;');
					this.tagAtt('class', 'gx_usercontrol_child');
					this.append('>');
				}
			},

			webComponent: function( id, width, height, cssClass, title) {
				this.base(id, width, height, cssClass, title);
				
				this.type = gx.html.controls.types.webComponent;
				this.controlName = '';
				this.content = '';
				
				this.setProperties = function( sControlName)
				{
					this.controlName = sControlName;
					var cmpData = this.grid.parentObject.getComponentData( this.controlName);
					var cmpPrefix = cmpData.Prefix
					var cmpCtrlId = this.grid.gxComponentContext + 'gxHTMLWrp' + cmpPrefix + this.gridRow;
					var cmpCtrl = gx.dom.el( cmpCtrlId);
					var cmpHtml = '';
					this.grid.addOldComponent(this.gridRow, this.grid.gxComponentContext + cmpPrefix + this.gridRow);
					if (cmpCtrl != null)
					{
						var hookId = cmpCtrlId + '_hook';
						this.grid.addComponentToDraw({create: false, existingEl: hookId, el: cmpCtrlId});
						cmpCtrlId = hookId;
					}
					else
					{
						if (!gx.lang.emptyObject(gx.csv.lastEvtResponse) && !gx.lang.emptyObject(gx.csv.lastEvtResponse.gxComponents))
						{
							var tmpHtml = gx.csv.lastEvtResponse.gxComponents[cmpCtrlId];
							if (!gx.lang.emptyObject(tmpHtml))
							{
								cmpHtml = gx.html.cleanHtmlRefs(tmpHtml);
								var cmpName = gx.fn.getHidden(this.grid.gxComponentContext + cmpPrefix + this.gridRow);
								if (!cmpName)
									cmpName = cmpData.GXClass;
								if (!gx.lang.emptyObject(cmpName))
									this.grid.addComponentToDraw({load:true, n:cmpName.toLowerCase(), p:this.grid.gxComponentContext + cmpPrefix + this.gridRow, c:tmpHtml});
							}
							else
								cmpHtml = '';
						}
					}
					this.id = cmpCtrlId;
					this.content = cmpHtml;
				}
				
				this._getHtml = function()
				{
					this.append('<div');
					this.tagAtt('id', this.id);
					this.append('>');
					this.append(this.content);
					this.append('</div>');
				}
			},
			
			embeddedPage: function( id, width, height, cssClass, title) {
				this.base(id, width, height, cssClass, title);
				
				this.type = gx.html.controls.types.embeddedPage;
				this.align = 'center';
				this.scrollbars = 'auto';
				this.borderStyle = '1';
				
				this.setProperties = function( sControlName, sSrc, nVisible, nWidth, sWidthUnit, nHeight, sHeightUnit, nBorderStyle, sAlign, sTooltipText, sScroll)
        {
					this.id = sControlName;
					this.value = sSrc;
					this.visible = (nVisible != 0);
					this.width = nWidth;
					this.widthUnit = sWidthUnit;
					this.height = nHeight;
					this.heightUnit = sHeightUnit;
					this.borderStyle = nBorderStyle;
					this.align = sAlign;
					this.title = sTooltipText;
					this.scrollbars = sScroll;
        }
				
				this._getHtml = function()
				{
					this.style = this.style + ((this.visible)?'':';display:none;');
					this.append('<iframe');
					this.tagAtt('frameborder', this.borderStyle);
					this.tagAtt('align', this.align);
					this.tagAtt('scrolling', this.scrollbars);
					if (this.height > 0)
						this.tagAtt('height', this.height + this.heightUnit);
					if (this.width > 0)
						this.tagAtt('width', this.width + this.widthUnit);
					if (this.title != '')
						this.tagAtt('title', this.title);
					if (this.id != '')
					{
						this.tagAtt('id', this.id);
						this.tagAtt('name', this.id);
					}
					if (this.value != '')
						this.tagAtt('src', this.value);
					if (this.cssClass != '')
					 	this.tagAtt('class', this.cssClass);
					if (this.style != '')
						this.tagAtt('style', this.style);
					this.append('</iframe>');
				}
			},
			
			table: function( id, width, height, cssClass, title) {
				this.base(id, width, height, cssClass, title);
				
				this.type = gx.html.controls.types.table;
				this.cellSpacing = '';
				this.cellPadding = '';
				this.backColor = '';
				
				this.setProperties = function( sCtrlName, nVisible, sClassString, sBackground, nBackcolor, nBordercolor, 	sAlign, sTooltiptext, 
				                                                    nBorderwidth, nCellpadding, nCellspacing, nHeight, nWidth, sRules, sHeightUnit, sWidthUnit)
				{
					this.id = sCtrlName;
					this.visible = (nVisible != 0);
					this.cssClass = sClassString;
					this.background = sBackground;
					this.backColor = nBackcolor;
					this.borderColor = nBordercolor;
					this.align = sAlign;
					this.title = sTooltiptext;
					this.borderWidth = nBorderwidth;
					this.cellPadding = nCellpadding;
					this.cellSpacing = nCellspacing;
					this.height = nHeight;
					this.width = nWidth;
					this.rules = sRules;
					this.heightUnit = sHeightUnit;
					this.widthUnit = sWidthUnit;
					this.style = "";
				}
				
				this._getHtml = function()
				{
					this.style = this.style + ((this.visible)?'':';display:none;');
					if (this.background != '')
					{
						this.background = gx.util.resourceUrl(gx.basePath + gx.staticDirectory + this.background, true);
						this.style = this.style + 'background-image: url(' + this.background + ');';
					}
					if (this.backColor != '')
					{
						var col = parseInt( this.backColor);
						if( !isNaN( col))
							col = gx.color.html( col).Html;
						else
							col = this.backColor;
						this.style = this.style + 'background-color: ' + col + ';';
					}
					if (this.borderColor != '')
					{
						var col = parseInt( this.borderColor);
						if( !isNaN( col))
							col = gx.color.html( col).Html;
						else
							col = this.borderColor;
						this.style = this.style + 'border-color: ' + col + ';';
					}
					if (this.borderWidth != '')
						this.style = this.style + 'border-width: ' + this.borderWidth + ';';
					if (this.height != '')
						this.style = this.style + 'height: ' + this.height + this.heightUnit + ';';
					if (this.width != '')
						this.style = this.style + 'width: ' + this.width + this.widthUnit + ';';
					this.append('<table');
					this.tagAtt('id', this.id);
					this.tagAtt('align', this.align);
					if (this.borderWidth != '')
						this.tagAtt('border', this.borderWidth);
					if (this.cellSpacing !== '')
						this.tagAtt('cellspacing', this.cellSpacing);
					if (this.cellPadding !== '')
						this.tagAtt('cellpadding', this.cellPadding);
					if (this.rules != '' && this.rules != 'none')
						this.tagAtt('rules', this.rules);
					if (this.title != '')
						this.tagAtt('title', this.title);
					if (this.cssClass != '')
						this.tagAtt('class', this.cssClass);
					if (this.style != '')
						this.tagAtt('style', this.style);
					this.append('>');
				}
			},

			row: function( id, width, height, cssClass, title) {
				this.base(id, width, height, cssClass, title);
				
				this.type = gx.html.controls.types.row;
				this.backColor = '';
				this.borderColor = '';
				this.align = '';
				this.verticalAlign = '';
				this.isFreestyleRow = false;
				this.oncontextmenu = '';
				
				this.setProperties = function( sCtrlName, sClassString, sStyleString)
				{
					if (sClassString)
					{
						if (this.ownCssClass)
						{
							this.cssClass = sClassString + (this.ownCssClass?(' ' + this.ownCssClass):'');
						}
						else
						{
							this.cssClass = sClassString;
						}
					}
					this.style = sStyleString;
				}
				
				this._getHtml = function()
				{
					this.append('<tr');
					if (this.id != '')
						this.tagAtt('id', this.id);
					if (this.isFreestyleRow)
						this.tagAtt('gxrow', this.gridRow);
					if (this.backColor != '')
						this.style = this.style + 'background-color:' + this.backColor + ';';
					if (this.borderColor != '')
						this.tagAtt('bordercolor', this.borderColor);
					if (this.align != '')
						this.tagAtt('align', this.align);
					if (this.verticalAlign != '')
						this.tagAtt('valign', this.verticalAlign);
					if (this.style != '')
						this.tagAtt('style', this.style);
					if (this.cssClass != '')
						this.tagAtt('class', this.cssClass);
					if (this.oncontextmenu != '')
						this.tagAtt('oncontextmenu', this.oncontextmenu);
					this.append('>');
				}
			},
			
			cell: function( id, width, height, cssClass, title) {
				this.base(id, width, height, cssClass, title);
				
				this.type = gx.html.controls.types.cell;
				this.style = '';
				this.background = '';
				this.backColor = '';
				this.borderColor = '';
				this.align = '';
				this.verticalAlign = '';
				this.colSpan = '';
				this.rowSpan = '';
				
				this.setProperties = function( sBackground, sStyleString)
				{
					this.background = sBackground;
					if (sStyleString && sStyleString != "")
					{
						var idx = sStyleString.indexOf('style=');
						if (idx > 0)
						{
							this.style = sStyleString.substring(8);
							this.style = this.style.substring(0, this.style.length-1) + ';';
						}
					}
				}
				
				this._getHtml = function()
				{
					this.append('<td');
					if ((typeof(this.width) != 'undefined') && (this.width != 0))
						this.tagAtt('width', this.width);
					if ((typeof(this.height) != 'undefined') && (this.height != 0))
						this.tagAtt('height', this.height);
					if (this.background != '')
						this.tagAtt('background', this.background);
					if (this.backColor != '')
					    this.style += 'background-color:' + this.backColor + ';';
					if (this.style != '')
					    this.tagAtt('style', this.style);
					if (this.borderColor != '')
						this.tagAtt('bordercolor', this.borderColor);
					if (this.align != '')
						this.tagAtt('align', this.align);
					if (this.verticalAlign != '')
						this.tagAtt('valign', this.verticalAlign);
					if (this.colSpan != '')
						this.tagAtt('colspan', this.colSpan);
					if (this.rowSpan != '')
						this.tagAtt('rowspan', this.rowSpan);
					if (this.cssClass != '')
						this.tagAtt('class', this.cssClass);
					this.append('>');
				}
			},
			
			group: function( id, width, height, cssClass, title) {
				this.base(id, width, height, cssClass, title);
				
				this.type = gx.html.controls.types.group;
				this.caption = '';
				
				this.setProperties = function() {}
				
				this._getHtml = function()
				{
					this.append('<fieldset');
					this.tagAtt('name', this.id);
					if (this.cssClass != '')
						this.tagAtt('class', this.cssClass);
					var styleStr = '-moz-border-radius:3pt;';
					if (this.width != '0px')
						styleStr += 'width:' + this.width + ';';
					if (this.height != '0px')
						styleStr += 'height:' + this.height + ';';
					this.tagAtt('style', styleStr);
					this.append('>');
					this.append('<legend');
					if (this.cssClass != '')
						this.tagAtt('class', this.cssClass + 'Title');
					this.append('>');
					this.append(gx.getMessage(this.caption));
					this.append('</legend>');
				}
			},
			
			_init: function() {
				gx.lang.inherits( this.singleLineEdit, 		this.htmlControl);
				gx.lang.inherits( this.multipleLineEdit, 	this.singleLineEdit);
				gx.lang.inherits( this.blob, 					this.htmlControl);
				gx.lang.inherits( this.radio,		 			this.htmlControl);
				gx.lang.inherits( this.comboBox, 			this.htmlControl);
				gx.lang.inherits( this.listBox, 					this.comboBox);
				gx.lang.inherits( this.checkBox, 			this.htmlControl);
				gx.lang.inherits( this.image, 					this.htmlControl);
				gx.lang.inherits( this.textBlock, 			this.htmlControl);
				gx.lang.inherits( this.button, 					this.htmlControl);
				gx.lang.inherits( this.grid, 						this.htmlControl);
				gx.lang.inherits( this.userControl, 			this.htmlControl);
				gx.lang.inherits( this.userControlContainer, 			this.htmlControl);
				gx.lang.inherits( this.webComponent, 	this.htmlControl);
				gx.lang.inherits( this.embeddedPage, 	this.htmlControl);
				gx.lang.inherits( this.table, 					this.htmlControl);
				gx.lang.inherits( this.row, 						this.htmlControl);
				gx.lang.inherits( this.cell, 						this.htmlControl);
				gx.lang.inherits( this.group,					this.htmlControl);
			}
		}
	},
	
	_setBasePath: function() {
		var parts = location.pathname.split('/');
		var path = '';
		var len = parts.length;
		for (var i=0; i<len-1; i++)
		{
			if (parts[i] == 'servlet')
				break;
			if (parts[i] != '')
				path = path + ((path == '')?'':'/') + parts[i];
		}
		gx.basePath = path;
	},

	_init: function() {
		gx.dom._init();
		gx.base64._init();
		gx.sec._init();
		gx.util._init();
		gx.evt._init();
		gx._setBasePath();
		gx.date._init();
		gx.html.controls._init();
		gx.popup._init();
	},
	
	_deinit: function() {
		gx.dom._deinit();
		gx.csv._deinit();
		gx.evt._deinit();
		gx.grid._deinit();
		gx.O = null;
		gx.pO = null;
	}
};
/* END OF FILE - gxapi.js - */
/* START OF FILE - gxfx.js - */
gx.fx = {
	delayedSuggest: function() {
		var len = gx.suggestControls.length;
		for ( var C=0;C<len;C++)
			this.installSuggest(gx.suggestControls[C]);
	},
	
	installSuggest: function(Ctrl) {	
		if (document.readyState != undefined && document.readyState != "complete")
		{
			gx.suggestControls.push(Ctrl);
			return;
		}
		try
		{
			var vStruct = gx.O.getValidStructFld(Ctrl.id);
			if (!gx.lang.emptyObject(vStruct.gxsgprm))
			{
				var rowId = (vStruct.grid > 0)?gx.fn.currentGridRowImpl(vStruct.grid):'main';
				var gxsgprm = vStruct.gxsgprm;
				if (!gxsgprm.installed)
				{
					gxsgprm.installed = {};
				}
				if (!gxsgprm.installed[rowId])
				{
					gx.ajax.suggest( gxsgprm[1], Ctrl.id, gxsgprm[0], gxsgprm[3], gxsgprm[2]);
					gxsgprm.installed[rowId] = true;
				}
			}
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfx.js', 'installSuggest');
		}
	},
	
	updateSuggestParms: function( suggestParms) {
		if( suggestParms != undefined)
		{
			var len = suggestParms.length;
			for( var i=0; i<len; i++)
			{
				var validStruct = gx.fn.validStruct(suggestParms[i]);
				if( validStruct != undefined && validStruct != null)
					validStruct.c2v();
			}
		}
	},
	
	firesuggest: function( context, provider, typeahead, suggestParms) {
		this.updateSuggestParms( suggestParms);
		if (context.textbox.value != '')
			provider.requestSuggestions( context, typeahead);
	},
	
	autoSuggestControl: function( oTextbox, oProvider, ControlRefresh, typeahead, suggestParms, sdtparms) {
	    this.cur = -1;
	    this.IFrameControl = null;
	    this.layer = null;
	    this.provider = oProvider;
	    this.textbox = oTextbox;
		if (typeof(this.textbox.GXonblur) == 'undefined') this.textbox.GXonblur = oTextbox.onblur;
	    this.ControlRefresh = ControlRefresh;
	    this.typeahead = typeahead;
	    this.suggestParms = suggestParms || [];
	    this.sdtParms = sdtparms || [];
	    
		this.requestSuggestions = function( context, provider, typeahead)
		{
			var suggestParms = this.suggestParms;
			if (this.timer != undefined)
				window.clearTimeout( this.timer);
			this.timer = window.setTimeout(function(){gx.fx.firesuggest(context, provider, typeahead, suggestParms)}, 400);
		}
		
		this.hideSuggestions = function() 
		{
			if (this.IFrameControl)
				this.IFrameControl.style.visibility = 'hidden';
			this.layer.style.visibility = 'hidden';
		}
		
		this.highlightSuggestion = function(oSuggestionNode)
		{
			var len = this.layer.childNodes.length;
			for (var i=0; i < len; i++)
			{
				var oNode = this.layer.childNodes[i];
				if (oNode == oSuggestionNode)
				{
					oNode.className = 'current';
				}
				else if (oNode.className == 'current')
				{
					oNode.className = '';
				}
			}
		}
		
		this.init = function()
		{
		    var oThis = this;
		    
		    this.textbox.onkeyup = function(oEvent) {
				if (!oEvent)
				{
					oEvent = window.event;
				}       
				oThis.handleKeyUp(oEvent);
		    }
		    
		    this.textbox.onkeydown = function(oEvent) {
				if (!oEvent)
				{
					oEvent = window.event;
				}      
				oThis.handleKeyDown(oEvent);
		    }
		    
		    this.textbox.onblur = function() {
				oThis.hideSuggestions();
				oThis.textbox.GXonblur();
		    }

		    this.createDropDown();
		}
		
		this.nextSuggestion = function()
		{
			var cSuggestionNodes = this.layer.childNodes;
			if (cSuggestionNodes.length > 0) 
			{
				this.cur = (this.cur < cSuggestionNodes.length-1) ? this.cur + 1:0;
				var oNode = cSuggestionNodes[this.cur];
				this.highlightSuggestion(oNode);
				this.pickvalue( oNode.firstChild.nodeValue); 
			}
		}
		
		this.previousSuggestion = function()
		{
		    var cSuggestionNodes = this.layer.childNodes;
		    if (cSuggestionNodes.length > 0) 
		    {
				this.cur = (this.cur > 0) ? this.cur - 1:cSuggestionNodes.length-1;
				var oNode = cSuggestionNodes[this.cur];
				this.highlightSuggestion(oNode);
				this.pickvalue( oNode.firstChild.nodeValue);   
		    }
		}
		
		this.selectRange = function(iStart /*:int*/, iLength /*:int*/)
		{
			if (this.textbox.createTextRange)
			{
				var oRange = this.textbox.createTextRange(); 
				oRange.moveStart('character', iStart); 
				oRange.moveEnd('character', iLength - this.textbox.value.length);      
				oRange.select();
			}
			else if (this.textbox.setSelectionRange)
			{
				this.textbox.setSelectionRange(iStart, iLength);
			}
			this.textbox.focus();
		}
		
		this.showSuggestions = function(aSuggestions)
		{
			this.cur = -1;
			var oDiv = null;
			
			this.setupLayer();
			this.layer.innerHTML = '';
			
			if (!this.IFrameControl)
			{
				var justCreated = false;
				var ifrId = 'gxAutosuggestIFrame';
				this.IFrameControl = gx.dom.byId(ifrId);
				if (!this.IFrameControl)
				{
					justCreated = true;
					this.IFrameControl = document.createElement('IFRAME');
					this.IFrameControl.src = 'about:blank';
					this.IFrameControl.id = ifrId;
				}
				this.IFrameControl.style.zIndex = 1;
				this.IFrameControl.style.visibility = 'hidden';
				this.IFrameControl.style.position = 'absolute';
				this.IFrameControl.frameBorder= '0';
				if (justCreated)
				{
					document.body.appendChild( this.IFrameControl);
				}
			}
			var len = aSuggestions.length;
			for (var i=0; i < len; i++)
			{
				oDiv = document.createElement('div');
				oDiv.appendChild(document.createTextNode(aSuggestions[i].d));
				oDiv.style.width = this.textbox.offsetWidth;
				this.layer.appendChild(oDiv);
			}
			this.layer.style.left = this.getLeft() + 'px';
			this.layer.style.top = (this.getTop()+this.textbox.offsetHeight) + 'px';
			this.layer.style.visibility = 'visible';
			this.layer.style.zIndex = 2;
			this.IFrameControl.style.top = this.layer.style.top;
			this.IFrameControl.style.left = this.layer.style.left;
			this.IFrameControl.style.height = this.layer.offsetHeight;
			this.IFrameControl.style.width = this.layer.offsetWidth;
			this.IFrameControl.style.visibility = 'visible';
		}
		
		this.typeAhead = function(sSuggestion)
		{
			if (this.textbox.createTextRange || this.textbox.setSelectionRange)
			{
				var iLen = this.textbox.value.length; 
				this.pickvalue( sSuggestion); 
				var sLen = sSuggestion.length;
				if (iLen < sLen)
					this.selectRange(iLen, sLen);
			}
		}
		
		this.pickvalue = function(Value)
		{
			var len = this.aSuggestions.length;
			for (var i=0; i < len; i++) 
			{
				if (this.aSuggestions[i].d == Value)
				{
					this.textbox.value = Value;
					gx.evt.execOnchange( this.textbox);
					return;
				}
			}
		}
		
		this.autosuggest = function(aSuggestions, bTypeAhead) 
		{
			this.aSuggestions = aSuggestions;
			var sLen = this.aSuggestions.length;
			if (bTypeAhead & this.aSuggestions != null && sLen == 1)
			{
				this.typeAhead( this.aSuggestions[0].d); 
				this.hideSuggestions();
			}
			else
			{
				if (this.textbox == gx.csv.lastControl && this.aSuggestions != null && sLen > 0)
				{
					if ((sLen == 1) && (this.aSuggestions[0].d != this.textbox) 	|| (sLen > 1)) 
					{
						this.showSuggestions(this.aSuggestions);
						return;
					}
				}
				this.hideSuggestions();
			}
		}
		
		this.createDropDown = function()
		{
			var ddId = 'gxAutosuggestElement';
			var justCreated = false;
			
			this.layer = gx.dom.byId(ddId);
			if (!this.layer)
			{
				justCreated = true;
				this.layer = document.createElement('div');
				this.layer.className = 'suggestions';
				this.layer.id = ddId;
			}
			this.setupLayer();
			if (justCreated)
			{
				document.body.appendChild(this.layer);
			}
		}
		
		this.setupLayer = function()
		{
			var oThis = this;
			
			this.layer.style.visibility = 'hidden';
			this.layer.style.width = this.textbox.offsetWidth;
			
			this.layer.onmousedown = 
			this.layer.onmouseup = 
			this.layer.onmouseover = function (oEvent) {
				oEvent = oEvent || window.event;
				oTarget = gx.evt.source(oEvent);
				
				if (oEvent.type == 'mousedown')
				{
					gx.evt.cancel(oEvent, true);
					oThis.pickvalue(oTarget.firstChild.nodeValue);
					oThis.hideSuggestions();
					window.setTimeout(function(){gx.fn.setFocus( oThis.textbox)}, 100);
				}
				else if (oEvent.type == 'mouseover')
				{
					oThis.highlightSuggestion(oTarget);
				}
				else
				{
					oThis.textbox.focus();
				}
			}
		}
		
		this.getLeft = function()
		{
			var oNode = this.textbox;
			var iLeft = 0;
			
			while(oNode.tagName != 'BODY')
			{
				iLeft += oNode.offsetLeft;
				oNode = oNode.offsetParent;
			}        
			oNode = this.textbox;
			while(oNode.tagName != 'BODY')
			{
				iLeft -= oNode.scrollLeft;
				oNode = oNode.parentNode;
			}
			return iLeft;
		}
		
		this.getTop = function()
		{
		    var oNode = this.textbox;
		    var iTop = 0;
		
		    while(oNode.tagName != 'BODY')
		    {
		        iTop += oNode.offsetTop;
		        oNode = oNode.offsetParent;
		    }
		    oNode = this.textbox;
		    while(oNode.tagName != 'BODY')
		    {
		        iTop -= oNode.scrollTop;
		        oNode = oNode.parentNode;
		    }
		    return iTop;
		}
		
		this.handleKeyDown = function(oEvent)
		{
			switch(oEvent.keyCode) 
			{    	
				case 38: //up arrow
					this.previousSuggestion();
					break;
				case 40: //down arrow 
					this.nextSuggestion();
					break;
				case 13: //enter
					this.hideSuggestions();
					break;
			}
		}
		
		this.handleKeyUp = function(oEvent /*:Event*/)
		{
			var iKeyCode = oEvent.keyCode;
			
			if (iKeyCode == 9) 
			{
				this.hideSuggestions();
			}
			else
			{
				if (iKeyCode == 8 || iKeyCode == 46) 
				{
					this.requestSuggestions(this, this.provider, false);
				} 
				else 
				{
					if (!(iKeyCode < 32 || (iKeyCode >= 33 && iKeyCode < 46) || (iKeyCode >= 112 && iKeyCode <= 123)))
					{
						this.requestSuggestions(this, this.provider, this.typeahead);
					}
				}
			}
		}
		
		 this.init();
	},
	
	suggestProvider: function(ControlId, ControlRefresh, CtrlSvc) {
		this.ControlId = ControlId;
		this.ControlRefresh = ControlRefresh;
		this.CtrlSvc = CtrlSvc;
		
		this.requestSuggestions = function(oAutoSuggestControl, bTypeAhead) 
		{
			var backcall = "gx.fx.returnSuggestValues('" + this.VarRefresh + "',";
			var sURL = gx.ajax.objectUrl() + '?';
			var sParms = 'gxajaxSuggest_' + this.CtrlSvc;
			var len = this.ControlId.length;
			for (var i=0; i<len;i++)
				sParms += ',' + encodeURIComponent( eval(this.ControlId[i]));
			sParms += ',' + encodeURIComponent( gx.fn.getControlValue_impl(this.ControlRefresh));
			len = oAutoSuggestControl.sdtParms.length;
			for (var i=0; i<len;i++)
				sParms += ',' + encodeURIComponent( eval(oAutoSuggestControl.sdtParms[i]));
			sURL += gx.ajax.encryptParms( gx.O, sParms);
			this.values = gx.http.callBackend( backcall, sURL, ')', false, gx.http.modes.retval, true);
			if (this.values)
				oAutoSuggestControl.autosuggest(this.values, bTypeAhead);
			else
				oAutoSuggestControl.hideSuggestions();
		}
	},
	
	returnSuggestValues: function( Var, adata) {
		return adata;
	},
	
	addElement: function( arr, el, mindTypes) {
		if (this.elementExists( arr, el, mindTypes))
			return;
		var hashId = el.id;
		if (mindTypes == true)
			hashId += el.types.sort().join('');
		arr.splice(0,0,el);
		arr[hashId] = el;
	},
	
	elementExists: function( arr, el, mindTypes) {
		var hashId = el.id;
		if (mindTypes == true)
			hashId += el.types.sort().join('');
		if ((arr[hashId] != undefined)  && (arr[hashId] != null))
			return true;
		return false;
	},
	
	deleteElement: function( arr, ctrlId, types) {
		var hashId = ctrlId;
		if (types != undefined)
			hashId += types.sort().join('');
		var element = arr[hashId];
		if ((element != undefined)  && (element != null))
			delete arr[hashId];
		var len = arr.length;
		for (var i=0; i<len; i++)
		{
			var curElem  = arr[i];
			if (curElem.id == ctrlId)
			{
				if (types != undefined)
				{
					if (this.matchingTypes( types, curElem.types))
					{
						arr.removeAt(i);
						break;
					}
				}
				else
				{
					arr.removeAt(i);
					break;
				}
			}
		}
		return arr;
	},
	
	matchingTypes: function( src, tgt) {
		var tLen = tgt.length;
		for( var i=0; i<tLen; i++)
		{
			var found = false;
			var sLen = src.length;
			for( var j=0; j<sLen; j++)
			{
				if (tgt[i].toLowerCase() == src[j].toLowerCase())
					found = true;
			}
			if (!found)
				return false;
		}
		return true;
	},
	
	findControl: function( evtCtrl, gxObj, ctrlId) {
		var ctrl = gx.dom.el( ctrlId);
		if (ctrl != null)
			return ctrl;
		ctrl = gx.dom.el( 'gxHTMLWrp' + ctrlId);
		if (ctrl != null)
			return ctrl;
		var cRegex = new RegExp('^' + ctrlId + '_(?:(?:[0-9]){4})+$');
		if (evtCtrl != null && cRegex.test(evtCtrl.id))
			return evtCtrl;
		return null;
	},
	
	isUnderMouse: function( Control) {
		var mx = gx.evt.mouse.x;
		var my = gx.evt.mouse.y;
		var targPos = gx.dom.position(Control);
		var targDims = gx.dom.dimensions(Control);
		if((mx >= targPos.x) && (mx <= (targPos.x + targDims.w)) && (my >= targPos.y) && (my <= (targPos.y + targDims.h)))
			return true;
		return false;
	},
	
	dom: {
		generics: [],
		dblclicks: [],
		
		getEventHandlers: function( evtType) {
			if (evtType == 'dblclick')
			{
				return this.dblclicks;
			}
			return this.generics;
		},
		
		addEventHandler: function( gxObj, evtType, ctrlId, handler) {
			ctrlId = gx.lang.emptyObject(gxObj)?ctrlId:gxObj.CmpContext + ctrlId;
			var evtHandler = {id:evtType+ctrlId,
												cId:ctrlId,
												type:evtType,
						            obj:gxObj,
						            hdl:handler};
			var handlers = this.getEventHandlers( evtType);
			gx.fx.addElement( handlers, evtHandler, false);
		},
		
		raiseEvent: function( evtType, evtObj) {
			var evtCtrl = gx.evt.source(evtObj);
			var handlers = this.getEventHandlers( evtType);
			var len = handlers.length;
			for (var i=0; i<len; i++)
			{
				var evtHandler  = handlers[i];
				var ctrl = gx.fx.findControl( evtCtrl, evtHandler.obj, evtHandler.cId);
				if (ctrl != null)
				{
					if( gx.fx.isUnderMouse( ctrl))
					{
						evtHandler.hdl.call( evtHandler.obj);
					}
				}
			}
		},
		
		highlight: function( control, color, time) {
			var gxColor = gx.color.fromRGB(color[0], color[1], color[2]);
			var oldColor = gx.dom.getStyle( control, 'backgroundColor');
			var wasTransparent = (oldColor == 'transparent' || oldColor == 'rgba(0, 0, 0, 0)');
			return { play:function() {
							control.style.backgroundColor = gxColor.Html;
							setTimeout( this.end, time);
						},
						
						end: function() {
							var endColor = oldColor;
							if (wasTransparent) {
								endColor = 'transparent';
							}
							control.style.backgroundColor = endColor;
						}
			};
		}
	},
	
	obs: {
		observers: [],
		
		addObserver: function( evtName, obj, func) {
			new gx.thread.Mutex( this, this.addObserverSync, [evtName, obj, func]);
		},
		
		addObserverSync: function( evtName, obj, func) {
			if (this.indexOf( evtName, obj, func) < 0)
			{
				this.observers.push({e:evtName, o:obj, f:func});
			}
		},
		
		deleteObserver: function( evtName, obj, func) {
			new gx.thread.Mutex( this, this.deleteObserverSync, [evtName, obj, func]);
		},
		
		deleteObserverSync: function( evtName, obj, func) {
			var idx = this.indexOf( evtName, obj, func);
			if (idx >= 0)
			{
				this.observers.removeAt(idx);
			}
		},
		
		removeAll: function() {
			this.observers = [];
		},
		
		indexOf: function( evtName, obj, func) {
			var len = this.observers.length;
			for (var i=0; i<len; i++)
			{
				var obs = this.observers[i];
				if (obs.e == evtName && obs.o == obj && obs.f == func)
				{
					return i;
				}
			}
			return -1;
		},
		
		notify: function( evtName, parms) {
			if (!parms)
			{
				parms = [];
			}
			var len = this.observers.length;
			for (var i=0; i<len; i++)
			{
				var obs = this.observers[i];
				if (obs.e == evtName)
				{
					try
					{
						obs.f.apply( obs.o, parms);
					}
					catch(e)
					{
						gx.dbg.logEx(e, 'gxfx.js', 'gx.obs.notify');
					}
				}
			}
		}
	},
	
	dnd: {
		obj: null,
		dragCtrl: null,
		clonCtrl: null,
		sources: [],
		targets: [],
		dropCtrl: null,
		noDropCtrl: null,
		toHdl: null,
		
		drag: function( gxObj, types, handler) {
			if (handler != undefined)
			{
				gx.evt.setEventRow( gxObj, this.dragCtrl);
				this.obj = handler.call( gxObj, this.dragCtrl);
				this.obj.gxDragTypes = types;
			}
		},
		
		drop: function( ctrl, gxObj, handler) {
			if (handler != undefined)
				handler.call( gxObj, ctrl, this.dragCtrl, this.obj);
		},
		
		noDrop: function() {
			var ctrl = this.noDropCtrl;
			if( ctrl != null)
			{
				if (ctrl.gxDndClassName != undefined)
					ctrl.className = ctrl.gxDndClassName + 'NoAcceptDrag';
			}
		},
		
		out: function() {
			var ctrl = this.dropCtrl;
			if( ctrl != null)
			{
				if (ctrl.gxClassName != undefined)
					ctrl.className = ctrl.gxClassName;
			}
			this.dropCtrl = null;
			var ctrl = this.noDropCtrl;
			if( ctrl != null)
			{
				if (ctrl.gxClassName != undefined)
					ctrl.className = ctrl.gxClassName;
			}
			this.noDropCtrl = null;
		},
		
		over: function() {
			var ctrl = this.dropCtrl;
			if( ctrl != null)
			{
				if (ctrl.gxDndClassName != undefined)
					ctrl.className = ctrl.gxDndClassName + 'AcceptDrag';
			}
		},

		deleteClonControl: function() {
			if (this.clonCtrl != null)
				gx.dom.removeControlSafe( this.clonCtrl);
			this.clonCtrl = null;
		},
		
		restoreControl: function() {
			var ctrl = this.clonCtrl;
			if (ctrl != null)
			{
				if (this.toHdl == null)
				{
					ctrl.dropLeft = parseFloat(ctrl.style.left || '0');
		   			ctrl.dropTop = parseFloat(ctrl.style.top || '0');
					this.toHdl = setInterval('gx.fx.dnd.restoreControl()', 2);
				}
				if (this.controlRestored())
				{
					clearInterval(this.toHdl);
					this.toHdl = null;
					this.deleteClonControl();
				}
				else
				{
					var newCoords = this.nextCoords();
					this.moveDragControl(newCoords.X, newCoords.Y);
				}
			}
		},
		
		nextCoords: function() {
			var ctrl = this.clonCtrl;
			var X = parseFloat(ctrl.style.left || '0');
			var Y = parseFloat(ctrl.style.top || '0');
			var diffX = 0;
			var diffY = 0;
			if (X >= Y)
			{
				diffX = X - 1;
				diffY = ctrl.dropTop - (((ctrl.dropTop - ctrl.originalTop)*(ctrl.dropLeft - diffX))/(ctrl.dropLeft - ctrl.originalLeft));
			}
			else
			{
				diffY = Y - 1;
				diffX = ctrl.dropLeft - (((ctrl.dropTop - diffY)*(ctrl.dropLeft - ctrl.originalLeft))/(ctrl.dropTop - ctrl.originalTop));
			}
			if (diffX <= ctrl.originalLeft)
				diffX = ctrl.originalLeft;
			if (diffY <= ctrl.originalTop)
				diffY = ctrl.originalTop;
			return {X:diffX, Y:diffY};
		},
		
		moveControl: function( Control) {
			if (this.clonCtrl == null)
			{
				var offset = 10;
				var ctrl = document.createElement("DIV");
				ctrl.style.position = "absolute";
				if (Control.gxDndClassName != undefined)
					ctrl.className = Control.gxDndClassName + 'Dragging';
				ctrl.innerHTML = this.dragInfo();
				gx.fn.setOpacity( 50, ctrl);
				document.body.appendChild(ctrl);
				ctrl.originalLeft = gx.evt.mouse.x - offset;
			   	ctrl.originalTop = gx.evt.mouse.y - offset;
			   	ctrl.diffLeft = offset;
			   	ctrl.diffTop = offset;
			   	this.clonCtrl = ctrl;
			}
			this.moveDragControl(gx.evt.mouse.x, gx.evt.mouse.y);
		},
		
		controlRestored: function() {
			var ctrl = this.clonCtrl;
			if (ctrl == null)
				return true;
			var X = parseFloat(ctrl.style.left || '0');
			var Y = parseFloat(ctrl.style.top || '0');
			var diffX = X - ctrl.originalLeft;
			var diffY = Y - ctrl.originalTop;
			if ((diffX <= 0) && (diffY <= 0))
				return true;
			return false;
		},
		
		moveDragControl: function(X, Y) {
			try
			{
				var ctrl = this.clonCtrl;
				if (ctrl != null)
				{
					ctrl.style.left=(X - ctrl.diffLeft)+'px';
					ctrl.style.top=(Y - ctrl.diffTop)+'px';
				}
			}
			catch(e)
			{
				this.deleteClonControl();
			}
		},
		
		dragInfo: function() {
			if (this.obj != null)
			{
				var lines = '';
				var dragStr = '';
				for (var prop in this.obj)
				{
					if (prop != "gxDragTypes")
					{
						var Lines = [lines];
						if (typeof(this.obj[prop]) == 'function')
							continue;
						dragStr += prop + ': ' + this.obj[prop] + '</br>';
						lines = Lines[0];
					}
					if (lines >= 5)
					{
						dragStr += '...';
						break;
					}
					lines++;
				}
				return dragStr;
			}
			return '';
		},
		
		deleteHandlers: function( gxObj) {
			new gx.thread.Mutex( this, this.deleteHandlersSync, [gxObj]);
		},
		
		deleteHandlersSync: function( gxObj) {
			var tmp = [];
			var len = this.sources.length;
			for (var i=0; i<len; i++)
			{
				var source  = this.sources[i];
				if (source.obj != gxObj)
					tmp.push(source);
			}
			this.sources = tmp;
			tmp = [];
			len = this.targets.length;
			for (var i=0; i<len; i++)
			{
				var target  = this.targets[i];
				if (target.obj != gxObj)
					tmp.push(target);
			}
			this.targets = tmp;
		},
		
		addSource: function( gxObj, ctrlId, cClass, dTypes, handler) {
			new gx.thread.Mutex( this, this.addSourceSync, [gxObj, ctrlId, cClass, dTypes, handler]);
		},
		
		addSourceSync: function( gxObj, ctrlId, cClass, dTypes, handler) {
			ctrlId = gx.lang.emptyObject(gxObj)?ctrlId:gxObj.CmpContext + ctrlId;
			var dragSource = {id:ctrlId,
			            cssClass:cClass,
			            types:dTypes,
			            obj:gxObj,
			            hdl:handler};
			gx.fx.addElement( this.sources, dragSource, false);
		},
		
		addTarget: function( gxObj, ctrlId, cClass, dTypes, handler) {
			new gx.thread.Mutex( this, this.addTargetSync, [gxObj, ctrlId, cClass, dTypes, handler]);
		},
		
		addTargetSync: function( gxObj, ctrlId, cClass, dTypes, handler) {
			ctrlId = gx.lang.emptyObject(gxObj)?ctrlId:gxObj.CmpContext + ctrlId;
			var dropTarget = {id:ctrlId,
			                    		cssClass:cClass,
					                	types:dTypes,
					                	obj:gxObj,
					                	hdl:handler};
			gx.fx.addElement( this.targets, dropTarget, true);
		},
		
		deleteSource: function( ctrlId) {
			new gx.thread.Mutex( this, this.deleteSourceSync, [ctrlId]);
		},
		
		deleteSourceSync: function( ctrlId) {
			this.sources = gx.fx.deleteElement( this.sources, ctrlId);
		},
		
		getSource: function( evtObj) {
			var evtCtrl = gx.evt.source(evtObj);
			var len = this.sources.length;
			for (var i=0; i<len; i++)
			{
				var curSource  = this.sources[i];
				this.dragCtrl = gx.fx.findControl( evtCtrl, curSource.obj, curSource.id);
				var ctrl = this.dragCtrl;
				if (ctrl != null)
				{
					ctrl.gxClassName = ctrl.className;
					ctrl.gxDndClassName = curSource.cssClass;
					if( gx.fx.isUnderMouse( ctrl))
						return curSource;
				}
			}
			this.dragCtrl = null;
			this.obj = null;
			return null;
		},
		
		getTarget: function( evtObj, types) {
			var evtCtrl = gx.evt.source(evtObj);
			var len = this.targets.length;
			for (var i=0; i<len; i++)
			{
				var curTarget  = this.targets[i];
				var Control = gx.fx.findControl( evtCtrl, curTarget.obj, curTarget.id);
				if (Control != null)
				{
					Control.gxClassName = Control.className;
					Control.gxDndClassName = curTarget.cssClass;
					if( gx.fx.isUnderMouse( Control))
					{
						if (gx.fx.matchingTypes( types, curTarget.types))
						{
							this.noDropCtrl = null;
							this.dropCtrl = Control;
							return curTarget;
						}
						else
						{
							this.out();
							this.noDropCtrl = Control;
							this.noDrop();
							return null;
						}
					}
				}
			}
			this.out();
			return null;
		}
	},
	
	ctx: {
		setters: [],
		trackers: [],
		
		deleteHandlers: function( gxObj) {
			new gx.thread.Mutex( this, this.deleteHandlersSync, [gxObj]);
		},
		
		deleteHandlersSync: function( gxObj) {
			var tmp = [];
			var len = this.setters.length;
			for (var i=0; i<len; i++)
			{
				var setter  = this.setters[i];
				if (setter.obj != gxObj)
					tmp.push(setter);
			}
			this.setters = tmp;
			tmp = [];
			len = this.trackers.length;
			for (var i=0; i<len; i++)
			{
				var tracker  = this.trackers[i];
				if (tracker.obj != gxObj)
					tmp.push(tracker);
			}
			this.trackers = tmp;
		},
		
		addSetter: function( gxObj, ctrlId, cClass, sTypes, handler) {
			new gx.thread.Mutex( this, this.addSetterSync, [gxObj, ctrlId, cClass, sTypes, handler]);
		},
		
		addSetterSync: function( gxObj, ctrlId, cClass, sTypes, handler) {
			ctrlId = gx.lang.emptyObject(gxObj)?ctrlId:gxObj.CmpContext + ctrlId;
			var setter = {id:ctrlId,
		                    		cssClass:cClass,
								types:sTypes,
								obj:gxObj,
								hdl:handler};
			gx.fx.addElement( this.setters, setter, false);
		},
		
		addTracker: function( gxObj, sTypes, handler) {
			new gx.thread.Mutex( this, this.addTrackerSync, [gxObj, sTypes, handler]);
		},
		
		addTrackerSync: function( gxObj, sTypes, handler) {
			ctrlId = gxObj.CmpContext + gxObj.IsMasterPage.toString();
			var tracker = {id:ctrlId,
		                    		cssClass:'',
				                	types:sTypes,
				                	obj:gxObj,
				                	hdl:handler};
			gx.fx.addElement( this.trackers, tracker, true);
		},
		
		deleteSetter: function( ctrlId) {
			new gx.thread.Mutex( this, this.deleteSetterSync, [ctrlId]);
		},
		
		deleteSetterSync: function( ctrlId) {
			this.setters = gx.fx.deleteElement( this.setters, ctrlId);
		},
		
		notify: function( Control, setterTypes, ctxObj) {
			new gx.thread.Mutex( this, this.notifySync, [Control, setterTypes, ctxObj]);
		},
		
		notifySync: function( Control, setterTypes, ctxObj) {
			if (Control && Control.forcedFocus)
			{
				Control.forcedFocus = false;
				return;
			}
			var eo = gx.lang.emptyObject;
			var setterCtrl = null;
			if (eo(setterTypes) || eo(ctxObj))
			{
				var settersQty = this.setters.length;
				for (var i=0; i<settersQty; i++)
				{
					var curSetter  = this.setters[i];
					if (!eo( Control))
					{
						if (Control.id == curSetter.id)
						{
							setterCtrl = Control;
							gx.evt.setEventRow( curSetter.obj, setterCtrl);
							setterTypes = curSetter.types;
							ctxObj = curSetter.hdl.call( curSetter.obj, setterCtrl);
							break;
						}
					}
					else
					{
						setterCtrl = gx.fx.findControl( null, curSetter.obj, curSetter.id);
						if (setterCtrl != null)
						{
							if (eo( setterCtrl.onfocus))
							{
								if( gx.fx.isUnderMouse( setterCtrl))
								{
									gx.evt.setEventRow( curSetter.obj, setterCtrl);
									setterTypes = curSetter.types;
									ctxObj = curSetter.hdl.call( curSetter.obj, setterCtrl);
									break;
								}
							}
						}
					}
				}
			}
			if (!eo(setterTypes) && (ctxObj!=null || ctxObj==''))
			{
				var trackersQty = this.trackers.length;
				for (var i=0; i<trackersQty; i++)
				{
					var curTracker  = this.trackers[i];
					if (gx.fx.matchingTypes( setterTypes, curTracker.types))
					{
						curTracker.hdl.call( curTracker.obj, null, setterCtrl, ctxObj);
					}
				}
			}
		}
	}
};

/* END OF FILE - gxfx.js - */
/* START OF FILE - gxtypes.js - */
gx.date = {
	clone: function() {
	  return new Date(this.getTime());
	},
	
	equalsNoTime: function( d2) {
		if(this.getDay() == d2.getDay()
			&& this.getMonth() == d2.getMonth()
				&& this.getFullYear() == d2.getFullYear())
					return true;
		return false;
	},
	
	toJson: function() {
		var newdate = new gx.date.gxdate("");
		newdate.assign_date( this);
	  	return newdate.json();
	},
	
	gxdate: function( SDate, XSFmt) {
		this.json = function()
		{
			var oldTFmt = TimeFmt;
			TimeFmt = 24;
			var oldHTime = this.HasTimePart;
			this.HasTimePart = true;
				var jsonDate = this.getStringWithFmt("Y4MD") + ' ' + this.getTimeString(true, true);
	  		TimeFmt = oldTFmt;
	  		this.HasTimePart = oldHTime;
	  		return jsonDate;
		}
		
		this.mapCTODFormatToPattern = function(nFormat)
		{
			if (nFormat == "ANSI")
				return "Y4MD";
			else return nFormat;
		}
	
		this.emptyDateString = function(sDateFormat)
		{
		    if (sDateFormat.indexOf("Y4") == -1)
		        if (gx.blankWhenEmpty)
		            return '        ';
		        else
				    return '  /  /  ';
			else
    		    if (gx.blankWhenEmpty)
				    return '          ';
				else 
				    return '  /  /    ';
		}

		this.getStringWithFmt = function( sDateFormat)
		{
			sDateFormat = this.mapCTODFormatToPattern( sDateFormat);
			if (this.Value - new Date( 0, 0, 0, 0, 0, 0, 0) == 0)
			    return this.emptyDateString(sDateFormat);
			var sDate = sDateFormat;
			var sDay = gx.text.padr( this.Value.getDate().toString(), 2, '0');
			var sMonth = gx.text.padr( (this.Value.getMonth() + 1).toString(), 2, '0');
			var sYear = gx.text.padr( this.Value.getFullYear().toString(), 4, '0');
			var Pos = this.FormatPos(sDateFormat);
			sDate = sDate.replace('D', sDay + ((Pos.DPos < 3) ? '/':''));
			sDate = sDate.replace('M', sMonth + ((Pos.MPos < 3) ? '/':''));
			if (sDateFormat.indexOf("Y4") == -1)
			{
				sYear = sYear.slice( 2,4);
				sDate = sDate.replace('Y', sYear + ((Pos.YPos < 3) ? '/':''));
			}
			else
				sDate = sDate.replace('Y4', sYear + ((Pos.YPos < 3) ? '/':''));
			return sDate;		
		}
	
		this.getString = function( dFormat)
		{
			if (gx.lang.emptyObject(dFormat))
			{
				dFormat = gx.dateFormat;
			}
			return this.getStringWithFmt( dFormat);
		}
		
		this.gxdtoc = function( nDateFormat, sSeparator)
		{
			var sDate = this.getStringWithFmt( this.mapCTODFormatToPattern( nDateFormat));
			return sDate.replace( '/', sSeparator);
		}
	
		this.getUrlVal = function()
		{
			var sDate = gx.dateFormat;
			var sDay = gx.text.padr( this.Value.getDate().toString(), 2, '0');
			var sMonth = gx.text.padr( (this.Value.getMonth() + 1).toString(), 2, '0');
			var sYear = gx.text.padr( this.Value.getFullYear().toString(), 4, '0');
			var sHour = this.HasTimePart?gx.text.padr(this.Value.getHours().toString(),2,'0'):'';
			var sMin = 	this.HasTimePart?gx.text.padr(this.Value.getMinutes().toString(),2,'0'):'';
			var sSec = this.HasTimePart?gx.text.padr(this.Value.getSeconds().toString(),2,'0'):'';
			return sYear + sMonth + sDay + sHour + sMin + sSec;
		}
	
		this.getTimeString = function(WithMin, WithSec, WithHour)
		{
			var amPm = "";
			var iHour = this.Value.getHours();
			var WithHour = WithHour || true;
			if ((TimeFmt == 12) && (iHour >= 12))
			{
				if (iHour > 12)
					iHour = iHour - 12;
				amPm = " PM";
			}
			else if (TimeFmt == 12)
				amPm = " AM";
			var sHour = this.HasTimePart?gx.text.padr(iHour.toString(),2,'0'):'';
			var sMin = 	this.HasTimePart?gx.text.padr(this.Value.getMinutes().toString(),2,'0'):'';
			var sSec = this.HasTimePart?gx.text.padr(this.Value.getSeconds().toString(),2,'0'):'';
			if ((this.Value - new Date( 0, 0, 0, 0, 0, 0, 0) == 0) && (amPm!=""))
			{	//Null datetime is / / 12:00 AM, not  / / 00:00 AM
				sHour='12';
			}
			var sHourRet = "";
			if (WithHour)
			    sHourRet = sHour;
			if (WithMin)
				sHourRet = sHourRet + ':'+ sMin;
			if (WithSec)
				sHourRet = sHourRet + ':' + sSec;
			return sHourRet + amPm;
		}
		
		this.FormatPos = function( SFmt)
		{
			if ( SFmt == "ANSI")
			{
				YPos = 1;
				MPos = 2;
				DPos = 3;
			}
			else
			{
				Y4Pos = SFmt.indexOf("Y4");
				YPos = (Y4Pos == -1) ? SFmt.indexOf("Y") + 1 : Y4Pos + 1;
				MPos = SFmt.indexOf("M");
				if (Y4Pos != 0) MPos++;
				DPos = SFmt.indexOf("D");
				if (Y4Pos != 0) DPos++;
			}
			return {YPos:YPos,MPos:MPos,DPos:DPos};
		}		
	
		this.assign_date = function( DateValue)
		{
			if ( DateValue instanceof gx.date.gxdate)
				this.Value = DateValue.Value;
			else
				this.Value = DateValue;
		}
		
		this.assign_string = function( SDate, SFmt, IgnoreTime, ThrowExc)
		{
			ANSIDateExp = /([0-9]{1,4})\/?-?([0-9]{1,2})\/?-?([0-9]{2,4})\s?T?([0-9]{2})?:?([0-9]{2})?:?([0-9]{2})?:?([0-9]{2})?\s?(AM|PM)?/i;
			DateParts = ANSIDateExp.exec(SDate);
                        var datePartsLen = 0;
			if (DateParts == null)
                        {
                            if(SDate.indexOf("  /  /  ") != -1)
				IgnoreTime = true;
                        }
                        else
                        {
                        		var len = DateParts.length;
                            for( var i=1; i<len;i++)
                            {
                                if(!gx.lang.emptyObject(DateParts[i])) datePartsLen ++;
                            }
                        }
			var Pos = this.FormatPos(SFmt);		
			YY = 0;	MM = 0;	DD = 0;	Ho = 0; Mi = 0; Se = 0; Ce = 0;
			try
			{
				if ((Pos.DPos + Pos.MPos + Pos.YPos == 6) && (DateParts != null) && (datePartsLen >= 3))
				{
					if (DateParts[Pos.YPos] != null)
						YY = parseInt( DateParts[Pos.YPos], 10);
					if (isNaN( YY)) throw "InvalidDate";
					if (YY < FYearOfCentury)
						YY += 2000;
					else if (YY < 100)
						YY += 1900;
					else if (YY < 1000)
						YY += 1000;
					if (DateParts[Pos.MPos] != null)
						MM = parseInt( DateParts[Pos.MPos],10) - 1;
					if (isNaN( MM) || (MM < 0) || (MM > 11)) throw "InvalidDate";
					if (DateParts[Pos.DPos] != null)
						DD = parseInt( DateParts[Pos.DPos], 10);
					if (isNaN( DD) || (DD < 0) || (DD > gx.date.maxDays(MM, YY))) throw "InvalidDate";
				}
				this.HasTimePart = false;
				var TimeOffSet = 0;
				if (DateParts == null)
				{
					ANSIDateExp = /([0-9]{2}):?([0-9]{2})?:?([0-9]{2})?:?([0-9]{2})?\s?(AM|PM)?/i;
					DateParts = ANSIDateExp.exec(SDate);
					if ( DateParts != null)
					{
						TimeOffSet = 1;
						//Has time part
						this.HasTimePart = true;
					}
				}
				else
				{
					if (datePartsLen > 3)
					{
						TimeOffSet = 4;
						//Has time part
						this.HasTimePart = true;
					}
				}
				if (this.HasTimePart && !IgnoreTime)
				{
					if (DateParts[TimeOffSet] != null)
						Ho = parseInt( DateParts[TimeOffSet], 10);
					if (gx.lang.emptyObject(DateParts[TimeOffSet]) || isNaN( Ho))
					{
						this.HasTimePart = false;
						throw "InvalidHour";
					}
					if (DateParts[TimeOffSet + 1] != null)
						Mi = parseInt( DateParts[TimeOffSet + 1], 10);
					if (isNaN( Mi)) Mi = 0;
					if (DateParts[TimeOffSet + 2] != null)
						Se = parseInt( DateParts[TimeOffSet + 2], 10);
					if (isNaN( Se)) Se = 0;
					if (DateParts[TimeOffSet + 3] != null)
						Ce = parseInt( DateParts[TimeOffSet + 3], 10);
					if (isNaN( Ce)) Ce = 0;
					
					if (!this.validTime((SDate.toLowerCase().indexOf("m") != -1), Ho, Mi, Se, Ce))
						throw "InvalidHour";
					if ((SDate.indexOf("PM") != -1 || SDate.indexOf("pm") != -1) && ( Ho < 12))
						Ho += 12;
				}
			}
			catch (E)
			{
				if (ThrowExc)
				{
					throw E;
				}
				else
				{
					if (E == "InvalidDate")
					{
						YY = 0;	MM = 0;	DD = 0;	Ho = 0; Mi = 0; Se = 0; Ce = 0;
					}
					if (E == "InvalidHour")
					{
						Ho = 0; Mi = 0; Se = 0; Ce = 0;
					}
				}
			}
			this.Value = new Date(YY, MM, DD, Ho, Mi, Se, Ce);
		}
	
		this.validTime	= function(AMPM, Hour, Min, Sec, Ce)
		{
			if (AMPM && Hour > 12)
				return false;
			if (!AMPM && (Hour > 24 || (Hour==24 && (Min+Sec) > 0)   ))
				return false;
			return ((Min <= 59) || (Sec <= 59) || (Ce <= 59));
		}
		
		this.compare = function( DateValue)
		{
			if ( typeof(DateValue) == "string")
				return this.compare_string( DateValue);
			return this.compare_date( DateValue);
		}
	
		this.compare_string = function( SDate)
		{
			DateValue = new gx.date.gxdate( SDate);
			return this.compare_date( DateValue.Value);
		}
		
		this.compare_date = function( DateValue)
		{
			var Val;
			if ( DateValue instanceof gx.date.gxdate)
				Val = DateValue.Value;
			else
				Val = DateValue;
			if (this.HasTimePart)
				return this.Value - Val;
			else
			{
				if (this.Value.getFullYear() > Val.getFullYear())
					return 1;
				else if (this.Value.getFullYear() < Val.getFullYear())
					return -1;
				else
				{
					if (this.Value.getMonth() > Val.getMonth())
						return 1;
					else if (this.Value.getMonth() < Val.getMonth())
						return -1;
					else
					{
						if (this.Value.getDate() > Val.getDate())
							return 1;
						else if (this.Value.getDate() < Val.getDate())
							return -1;
						else
							return 0;
					}
				}
			}
		}

		var TimeFmt = gx.timeFormat || 12;
		var SFmt = XSFmt || gx.dateFormat;
		var FYearOfCentury = gx.centuryFirstYear || 40;
		if ( typeof(SDate) == "string")
			this.assign_string( SDate, SFmt);
		else
			this.assign_date( SDate);
	},
	
	isANSIDate: function( sdate) {
		if ( typeof(sdate) == "string")
		{
			var ansiRE = new RegExp('^[0-9]{4}[\/-]{1}[0-9]{2}[\/-]{1}[0-9]{2}$');
			if (ansiRE.test(sdate))
			{
				return true;
			}
		}
		return false;
	},
	
	dateObject: function( date) {
		if ( date instanceof this.gxdate)
			return date.Value;
		if ( typeof(date) == "string")
			return new this.gxdate( date, (this.isANSIDate(date)?'Y4MD':undefined)).Value;
		if ( date instanceof Date)
			return date;
		return new Date();
	},
	
	gxdateObject: function( date) {
		if ( date instanceof this.gxdate)
			return date;
		if ( typeof(date) == "string")
			return new this.gxdate( date, (this.isANSIDate(date)?'Y4MD':undefined));
		if ( date instanceof Date)
		{
			var newDate = new this.gxdate( "");
			newDate.assign_date(date);
			return newDate;
		}
		return new this.gxdate("");
	},
	
	clonedDate: function ( gxDateObj, realDateObj) {
		var newdate = new this.gxdate("");
		newdate.assign_date( realDateObj);
		if (gxDateObj instanceof this.gxdate)
		{
			newdate.SFmt = gxDateObj.SFmt;
			newdate.HasTimePart = gxDateObj.HasTimePart;
		}
		return newdate;
	},
	
	nullDate: function() {
		return new this.gxdate("").Value;
	},
	
	now: function() {
		return new Date();
	},
	
	today: function() {
		var day = new this.gxdate('');
		day.assign_date(new Date());
		return day;
	},
	
	ctot: function(date, fmt) {
		return new this.gxdate(date, fmt);
	},
	
	ctod: function(date, fmt) {
		var day = new this.gxdate(date, fmt);
		day.Value.setHours( 0, 0, 0, 0);
		return day;
	},
	
	ymdtod: function( Y, M, D) {
		var day = new this.gxdate(Y + '/' + M + '/' + D, 'ANSI');
		day.Value.setHours( 0, 0, 0, 0);
		return day;
	},
	
	ymdhmstot: function( Y, M, D, H, Mi, S) {
		var day = new this.gxdate(Y + '/' + M + '/' + D + ' ' + H + ':' + Mi + ':' + S, 'ANSI');
		return day;
	},
	
	hour: function(SDate) {
		return (new this.gxdate(SDate)).Value.getHours();
	},
	
	minute: function(SDate) {
		return (new this.gxdate(SDate)).Value.getMinutes();
	},
	
	second: function(SDate) {
		return (new this.gxdate(SDate)).Value.getSeconds();
	},
	
	millisec: function( Days) {
		return Days * 24 * 60 * 60 * 1000;
	},
	
	day: function(SDate) {
		return (new this.gxdate(SDate)).Value.getDate();	
	},
	
	month: function(SDate) {
		return (new this.gxdate(SDate)).Value.getMonth() + 1;	
	},
	
	year: function(SDate) {
		return (new this.gxdate(SDate)).Value.getFullYear();	
	},
	
	addDays: function( sdate, inc) {
		return this.addMill( sdate, this.dayToMillisec( inc));
	},
	
	addSec: function( sdate, inc) {
		return this.addMill( sdate, this.secToMillisec( inc));
	},
	
	addMill: function( sdate, inc) {
		var date = this.dateObject( sdate).clone();
		var xdate = new this.gxdate();
		xdate.assign_date( date);
		var mill = date.getMilliseconds();
		date.setMilliseconds( mill + inc);
		return xdate.getString((this.isANSIDate(sdate)?'Y4MD':undefined));
	},
	
	secDiff: function( date1, date2) {
		var val = this.millisecToSec( this.milliDiff( date1, date2));
		return val;
	},
	
	daysDiff: function( date1, date2) {
		var val = this.millisecToDay( this.milliDiff( date1, date2));
		return val;
	},
	
	milliDiff: function( date1, date2) {
		var xdate1 = this.gxdateObject( date1);
		var xdate2 = this.gxdateObject( date2);
		var date1 = xdate1.Value.valueOf();
		var date2 = xdate2.Value.valueOf();
		return date1 - date2;
	},
	
	dayToMillisec: function( Days) {
		return Days * 24 * 60 * 60 * 1000;
	},

	secToMillisec: function( Sec) {
		return Sec * 1000;
	},
	
	millisecToDay: function( Mill) {
		return Mill / 24 /60 / 60 / 1000;
	},
	
	millisecToSec: function( Mill) {
		return Mill / 1000;
	},
	
	dateParm: function( sdate) {
		if ( typeof(sdate) == "string")
			return new this.gxdate( sdate);
		return sdate;	
	},
	
	urlDate: function( Control, sFmt) {
		var value = (Control.value != undefined) ? Control.value:Control;
		var date = new this.gxdate( value, sFmt);
		if(!this.isNullDate(date))
		{
			return date.Value.getFullYear().toString() 
					+ gx.text.padr((date.Value.getMonth() + 1).toString(),2,'0') 
					+ gx.text.padr(date.Value.getDate().toString(),2,'0');
		}
		return '';
	},
	
	urlDateTime: function( Control, sFmt) {
		var value = (Control.value != undefined) ? Control.value:Control;
		var date = new this.gxdate( value, sFmt);
		if(!this.isNullDate(date))
		{
			return 	date.Value.getFullYear().toString() + 
					gx.text.padr((date.Value.getMonth() + 1).toString(),2,'0') + 
					gx.text.padr(date.Value.getDate().toString(),2,'0') +
					gx.text.padr(date.Value.getHours().toString(),2,'0') +
					gx.text.padr(date.Value.getMinutes().toString(),2,'0') +
					gx.text.padr(date.Value.getSeconds().toString(),2,'0');
		}
		return '';
	},
	
	isNullDate: function( date) {
		if (date instanceof this.gxdate)
			date = date.Value;
		var nullD = this.nullDate();
		if (nullD.getFullYear() != date.getFullYear())
			return false;
		if (nullD.getMonth() != date.getMonth())
			return false;
		if (nullD.getDate() != date.getDate())
			return false;
		if (nullD.getHours() != date.getHours())
			return false;
		if (nullD.getMinutes() != date.getMinutes())
			return false;
		if (nullD.getSeconds() != date.getSeconds())
			return false;
		return true;
	},

	dtoc: function( SDate, nDateFormat, sSeparator) {
		var d = new this.gxdate( SDate);
		return d.gxdtoc( nDateFormat, sSeparator);
	},
	
	dttoc: function(SDate, nLen, nDec) {
		var Date = new this.gxdate(SDate);
		var sFmt = gx.dateFormat;
		if ((nLen > 8) && (sFmt.indexOf("Y4") == -1))
			sFmt = sFmt.replace('Y', 'Y4');
		var DatePart = Date.getStringWithFmt( sFmt);
		if (nDec > 0)
			return DatePart + ' ' + Date.getTimeString(true, nDec==8);	
		return DatePart;	
	},
	
	nulldate_toc: function(nLen, nDec) {
		var Date = new this.gxdate('');
		Date.HasTimePart = true;
		var sFmt = gx.dateFormat;
		var DatePart = "";
		if (nLen > 0)
		{
		    if ((nLen > 8) && (sFmt.indexOf("Y4") == -1))
			    sFmt = sFmt.replace('Y', 'Y4');
		    DatePart = Date.getStringWithFmt( sFmt) + ' ';
		}
		if (nDec > 0 && !gx.blankWhenEmpty)
			return DatePart + Date.getTimeString(nDec>1, nDec==8, nDec>3);	
		return DatePart;	
	},

	
	addyr: function( date, inc) {
		return this.addmth( date, 12 * inc);
	},
	
	addmth: function( date, inc) {
		var origDate = this.gxdateObject(date);
		date = this.dateObject( date);
		inc += date.getMonth();	
		var years = parseInt( inc/12);
		var months = parseInt( inc%12);
		date.setFullYear( date.getFullYear() + years);
		date.setMonth( months);
		return this.clonedDate( origDate, date);
	},
	
	dtadd: function( date, inc) {
		var origDate = this.gxdateObject(date);
		inc = inc * 1000;
		date = this.dateObject( date);
		var millis = date.getMilliseconds();
		date.setMilliseconds( millis + inc);
		return this.clonedDate( origDate, date);
	},
	
	dtdiff: function( date1, date2) {
		date1 = this.dateObject( date1);
		date2 = this.dateObject( date2);
		return (date1 - date2) / 1000;
	},
	
	maxDays: function(month, year) {
		switch ( month)
		{
			case 0: return 31;
			case 1:
				if ((year % 100 != 0) && (year % 4 == 0) || (year % 400 == 0))
					return 29;
				else
					return 28;
			case 2: return 31;
			case 3: return 30;
			case 4: return 31;
			case 5: return 30;
			case 6: return 31;
			case 7: return 31;
			case 8: return 30;
			case 9: return 31;
			case 10: return 30;
			case 11: return 31;
		}
	},
	
	eom: function( date) {
		var origDate = this.gxdateObject(date);
		date = this.dateObject( date);
		var lastDay = this.maxDays( date.getMonth(), date.getFullYear());
		date.setDate( lastDay);
		return this.clonedDate( origDate, date);
	},
	
	dow: function( date) {
		date = this.dateObject( date);
		if( date.equalsNoTime( this.nullDate()))
			return 0;
		return date.getDay() + 1;
	},
	
	age: function( date1, date2) {
		 var dtAsOfDate;
		 var dtBirth;
		 var dtAnniversary;
		 var intSpan;
		 var intYears;
		 var intMonths;
		
		 dtBirth = this.dateObject( date1);
		 dtAsOfDate = this.dateObject( date2);
		 
		 var nullDate = this.nullDate();
		 if( dtBirth.equalsNoTime( nullDate) || dtAsOfDate.equalsNoTime( nullDate) 
		 			|| dtBirth.equalsNoTime( dtAsOfDate))
			return 0;
		
		 // if as of date is on or after born date
		 if ( dtAsOfDate >= dtBirth )
		 {
		    // get time span between as of time and birth time
		    intSpan = ( dtAsOfDate.getUTCHours() * 3600000 +
		                dtAsOfDate.getUTCMinutes() * 60000 +
		                dtAsOfDate.getUTCSeconds() * 1000    ) -
		              ( dtBirth.getUTCHours() * 3600000 +
		                dtBirth.getUTCMinutes() * 60000 +
		                dtBirth.getUTCSeconds() * 1000       )
		    // start at as of date and look backwards for anniversary 
		
		    // if as of day (date) is after birth day (date) or
		    //    as of day (date) is birth day (date) and
		    //    as of time is on or after birth time
		    if ( dtAsOfDate.getUTCDate() > dtBirth.getUTCDate() ||
		         ( dtAsOfDate.getUTCDate() == dtBirth.getUTCDate() && intSpan >= 0 ) )
		    {
		       // most recent day (date) anniversary is in as of month
		       dtAnniversary = 
		          new Date( Date.UTC( dtAsOfDate.getUTCFullYear(),
		                              dtAsOfDate.getUTCMonth(),
		                              dtBirth.getUTCDate(),
		                              dtBirth.getUTCHours(),
		                              dtBirth.getUTCMinutes(),
		                              dtBirth.getUTCSeconds() ) );
		
		    }
		    // if as of day (date) is before birth day (date) or
		    //    as of day (date) is birth day (date) and
		    //    as of time is before birth time
		    else
		    {
		       // most recent day (date) anniversary is in month before as of month
		       dtAnniversary = 
		          new Date( Date.UTC( dtAsOfDate.getUTCFullYear(),
		                              dtAsOfDate.getUTCMonth() - 1,
		                              dtBirth.getUTCDate(),
		                              dtBirth.getUTCHours(),
		                              dtBirth.getUTCMinutes(),
		                              dtBirth.getUTCSeconds() ) );
		
		       // get previous month
		       intMonths = dtAsOfDate.getUTCMonth() - 1;
		       if ( intMonths == -1 )
		          intMonths = 11;
		
		       // while month is not what it is supposed to be (it will be higher)
		       while ( dtAnniversary.getUTCMonth() != intMonths )
		          // move back one day
		          dtAnniversary.setUTCDate( dtAnniversary.getUTCDate() - 1 );
		    }
		    // if anniversary month is on or after birth month
		    if ( dtAnniversary.getUTCMonth() >= dtBirth.getUTCMonth() )
		    {
		       // years elapsed is anniversary year - birth year
		       intYears = dtAnniversary.getUTCFullYear() - dtBirth.getUTCFullYear();
		    }
		    // if birth month is after anniversary month
		    else
		    {
		       // years elapsed is year before anniversary year - birth year
		       intYears = (dtAnniversary.getUTCFullYear() - 1) - dtBirth.getUTCFullYear();
		    }
				return intYears;
		 }
		 return 0;
	},
	
	valid_date: function( Elem, nDateLen, nDateFmt, nTimeLen, nTimeFmt, sIdiom, pMandatoryCentury, nBlankWhenEmpty) {
		var bMandatoryCentury = pMandatoryCentury || false;	
		var reEmpty = /^([ ]*([\/|-][ ]*[\/|-][ ]*((00|12)(:00(:00)?)?[ ]*(a|am)?)?)?)?[ ]*$/i;
		var reVDTime;
	
		var wasEmpty = false;
		var elemValue = '';
		var nDateFmtStr = nDateFmt;
		elemValue = Elem.value;
		
		elemValue = elemValue.split('\n')[0];
	
		if( nDateFmt == "YMD") nDateFmt =1; 
		else nDateFmt=0;
		
		if( nTimeFmt == 12) nTimeFmt =1; 
		else nTimeFmt=0;

		if (reEmpty.test( elemValue))
		{
			wasEmpty = true;
			elemValue ="";
		}
		
		var controlValue = "";
	
		var sVDTime = "^[ ]*(";
		if (nDateLen > 0)
		{
			if (nDateLen == 8)
				sVDTime = sVDTime + "([0-9]{1,2})[\/|-]?([0-9]{1,2})[\/|-]?([0-9]{2})";
			else
			{
				if (nDateFmt == 0)
				{
					if (bMandatoryCentury)
						sVDTime = sVDTime + "([0-9]{1,2})[\/|-]?([0-9]{1,2})[\/|-]?([0-9]{4})";
					else
						sVDTime = sVDTime + "([0-9]{1,2})[\/|-]?([0-9]{1,2})[\/|-]?([0-9]{2,4})";
				}
				else
				{
					if (bMandatoryCentury)
						sVDTime = sVDTime + "([0-9]{4})[\/|-]?([0-9]{1,2})[\/|-]?([0-9]{1,2})";
					else
						sVDTime = sVDTime + "([0-9]{2,4})[\/|-]?([0-9]{1,2})[\/|-]?([0-9]{1,2})";
				}					
			}
		}
		else
			/* Extra parenthesis are added to maintain parameter numbers */
			sVDTime = sVDTime + "( )?( )?( )?";
	
		if (nTimeLen > 0)
		{
			sVDTime = sVDTime + "(";
			if (nDateLen > 0)
				sVDTime = sVDTime + "[ ]*";
			sVDTime = sVDTime + "([0-9]{2})";
	
			if (nTimeLen > 2)
				sVDTime = sVDTime + "(:?([0-9]{2}))?";
			else
				sVDTime = sVDTime + "(( )?)?";
	
			if (nTimeLen > 5)
				sVDTime = sVDTime + "(:?([0-9]{2}))?";
			else
				sVDTime = sVDTime + "(( )?)?";
	
			if ( nTimeFmt == 1)
				sVDTime = sVDTime + "[ ]*(a|am|p|pm)?";
			else
				sVDTime = sVDTime + "(( )?)?";
	
			sVDTime = sVDTime + ")?";
		}
		sVDTime = sVDTime + ")?[ ]*$";
		reVDTime = new RegExp( sVDTime, "i");
	
		if (reVDTime.test( elemValue))
		{
			var sTokArr = elemValue.match( reVDTime);
	
			if (nDateLen > 0)
			{
				if (sTokArr[2] == "" || sTokArr[2] == null)
				{
					if (nBlankWhenEmpty == 1)
						controlValue = "        ";				
					else
						controlValue = "  /  /  ";
					if(nDateLen == 10)
						controlValue += "  ";
				}
				else
				{
					controlValue = sTokArr[2] + "/" + sTokArr[3] + "/" + sTokArr[4];
				}
			}
			else
				controlValue = "";
	
			if (nTimeLen > 0)
			{
				if (nDateLen > 0)
					controlValue = controlValue + " ";
				if (nBlankWhenEmpty == 1 && (sTokArr[6] == "" || sTokArr[6] == null) && (sTokArr[8] == "" || sTokArr[8] == null) && (sTokArr[10] == "" || sTokArr[10] == null))
				{
					controlValue = controlValue + "        ";
				}
				else{
	
					if (sTokArr[6] == "" || sTokArr[6] == null)
					{
							if(wasEmpty)
							{
								var emptTokArr = elemValue.match( reEmpty);
								if (emptTokArr[4] != "" && emptTokArr[4] != null)
									controlValue = controlValue + emptTokArr[4];
								else
									controlValue = controlValue + ((nTimeFmt == 1) ? "12":"00");
							}
							else
								controlValue = controlValue + ((nTimeFmt == 1) ? "12":"00");
					}
					else
						controlValue = controlValue + sTokArr[6];
	
					if (nTimeLen > 2)
					{
						if (sTokArr[8] == "" || sTokArr[8] == null)
							controlValue = controlValue + ":00";
						else
							controlValue = controlValue + ":" + sTokArr[8];
					}
	
					if (nTimeLen > 5)
					{
						if (sTokArr[10] == "" || sTokArr[10] == null)
							controlValue = controlValue + ":00";
						else
							controlValue = controlValue + ":" + sTokArr[10];
					}
	
					if ( nTimeFmt == 1)
					{
						var x;
						if (sTokArr[11] == "" || sTokArr[11] == null)
							x = "a";
						else
							x = sTokArr[11].substr(0,1);
						if (x.toLowerCase() == "p")
						{
							controlValue = controlValue + " PM";
						}
						else
						{
							controlValue = controlValue + " AM";
						}
					}
				}
			}
			
			var testDate = new this.gxdate('', nDateFmtStr);
			try
			{
				testDate.assign_string(controlValue, nDateFmtStr, (nTimeLen <= 0), true);
			}
			catch (E)
			{
				gx.fn.alert( Elem, gx.getMessage("GXM_invaliddate"));
				return false;
			}
			
			if (controlValue != elemValue)
			{
			  Elem.value = controlValue;
			  if (navigator.userAgent.indexOf("Firefox/2") != -1)
			    //WA For FF 2.0 bug (https://bugzilla.mozilla.org/show_bug.cgi?id=357684)
			    Elem.onchange();
			}
			return true;
		}
		gx.fn.alert( Elem, gx.getMessage("GXM_invaliddate"));
		return false;
	},
	
	_init: function() {
		Date.prototype.equalsNoTime = this.equalsNoTime;
		Date.prototype.clone = this.clone;
		Date.prototype.json = this.toJson;
	}
};

gx.text = {
	stringBuffer: function( capacity) {
		this.capacity = capacity || 10;
		this.buffer = [];
		
		this.append = function(value)
		{
			this.buffer.push(value);
			return this;
		}
		
		this.clear = function()
		{
			delete this.buffer;
			this.buffer = [];
		}
		
		this.toString = function()
		{
			if (this.buffer.length == 0)
				return '';
			return this.buffer.join('');
		}
		
		this.length = function()
		{
			return this.toString().length;
		}
	},
	
	format: function() {
		var msg = arguments[0];
		var len = arguments.length;
		for (var i=1;i<len; i++)
			msg = msg.replace( '%'+i, gx.text.trim(arguments[i].toString()));
		return msg;
	},
	
	replaceAll: function( value, toReplace, replaceWith) {
		if (value.toString().indexOf(toReplace) != -1)
		{
			return String(value).split(toReplace).join(replaceWith);
		}
		return value;
	},
	
	charReplace: function( Value, Chars, Repls) {
		var Ret = '';
		var len = Value.length;
		for (var i=0;i<len;i++)
		{
			var bFixed = false;
			var len1 = Chars.length;
			for (var c=0;c<len1;c++)
			{
				if ( Value.charAt(i) == Chars[c])
				{
					if (c < Repls.length)
					{
						Ret += Repls[c];
						bFixed = true;
						break;
					}
				}
			}
			if (bFixed == false)
				Ret += Value.charAt(i);
		}
		return Ret;
	},
	
	endsWith: function(str, chr) {
		return (str.charAt(str.length-1) == chr);
	},
	
	length: function( str) {
		return str.length;	
	},
	
	upper: function( str) {
		return str.toUpperCase();	
	},
	
	lower: function( str) {
		return str.toLowerCase();	
	},
	
	padr: function( val, len, padc) {
		var xlen = val.length;
		var diff = len - xlen;
		if (diff < 1)
			return val;
		var xval='';
		for (var i=0;i<diff;i++)
			xval += padc;
		xval += val;
		return xval;
	},
	
	padl: function( val, len, padc) {
		var xlen = val.length;
		var diff = len - xlen;
		if (diff < 1)
			return val;
		var xval='';
		for (var i=0;i<diff;i++)
			xval += padc;
		xval = xval + val;
		return xval;
	},
	ltrim: function( str) {
		return str.toString().replace(/^ */, '');
	},
	
	rtrim: function( str) {
		return str.toString().replace(/ *$/, '');
	},
	
	trim: function( str) {
		return 	this.rtrim( this.ltrim(str));
	},
	
	chr: function( num) {
		return String.fromCharCode(num);
	},
	
	concat: function( str1, str2, sep) {
		return this.rtrim( str1) + sep + str2;
	},
	
	space: function( n) {
		var buffer = '';
		for (var i = 0; i < n; i++) { buffer += ' '; }
		return buffer;
	},
	
	substring: function( str, from, len) {
		return str.toString().substring( from - 1, from - 1 + len);
	},
	
	tostring: function( str) {
		return str.toString();
	},
	
	toformattedstring: function( str) {
		return str.toString();
	},
	
	newline: function() {
		return '\n';
	},
	
	escapeString: function( str) { 
		return ('"' + str.replace(/(["\\])/g, '\\$1') + '"'
			).replace(/[\f]/g, "\\f"
			).replace(/[\b]/g, "\\b"
			).replace(/[\n]/g, "\\n"
			).replace(/[\t]/g, "\\t"
			).replace(/[\r]/g, "\\r");
	},
	
	indexOf: function( str, value, fromIdx) {
		if (fromIdx > str.length)
			return 0;
		if (fromIdx <= 0)
			fromIdx = 1;
		return str.indexOf( value, fromIdx - 1) + 1;
	},
	
	lastIndexOf: function( str, value, fromIdx) {
		if (fromIdx > str.length)
			return 0;
		if (fromIdx <= 0)
			fromIdx = 1;
		return str.lastIndexOf( value, fromIdx - 1) + 1;
	}
};

gx.num = {
	str: function( num, len, dec) {
		if (typeof(len) == 'undefined')
			len = 10;
		if (typeof(dec) == 'undefined' || (len - 1 <= dec))
			dec = 0;
		num = this.round( num, dec);
		if (dec == 0)
		{
			var sNum = num.toString();
		
			if	(sNum.length > len)
				return gx.text.padr('', len, '*');
			else
				return gx.text.padr(sNum, len, ' ');
		}
		var sNum = num.toString();
		var decimalStr = '';
		var decIdx = sNum.indexOf('.');
		if (dec > 0)
		{
			if (decIdx < 0)
			{
				sNum += '.' + gx.text.padr( '', dec, '0');
			}
			else
			{
				sNum = (decIdx == 0?'0':sNum.substring(0, decIdx)) + gx.text.padr(sNum.substring(decIdx), dec + 1, '0');
			}
		}
		if (sNum.length <= len)
		{
			return gx.text.padr( sNum, len, ' ');
		}
		decIdx = sNum.indexOf('.');
		if (decIdx > 0)
		{
			var intPart = sNum.substring(0, decIdx);
			if (intPart.length <= len)
			{
				return gx.num.str( gx.num.val(sNum), len, 0);
			}
		}
		return gx.text.padr( '', len, '*');
	},

	maxNumericPrecision: function() {
		return 15;
	},
	
	formatNumber: function(number, decimals, picture, digits, sign, errorOnBadNumber) {
		if (gx.lang.emptyObject(number))
			number = '0';
		var thSep = picture.indexOf(',')!=-1 ? gx.thousandSeparator:'';
		var decSep = gx.decimalPoint;
		
		if (typeof(number)=="string" && thSep != '')
			number = gx.text.replaceAll(number, thSep, '');
		if (typeof(number)=="string")
			number = number.replace( decSep, '.');

		if (gx.num.overflowNumber(number))
			return number;
		try{
			number = gx.num.setScale(number, decimals);
		}catch(e){number = number.toString();}


		var f = number.split('.');
		var i, j;
		if(!f[0]) f[0] = '0';
		if(!f[1]) f[1] = '';
		
		if (errorOnBadNumber){
		    if (f[1].length > decimals && f[1].replace(/0*$/, '').length > decimals){
		        throw "InvalidNumber";
		    }
		    else{
		        var totalDigits = (decimals==0) ? digits : (digits - decimals -1);
		        if ((sign && f[0].charAt(0)=='-' && f[0].replace(/0*/, '').length > totalDigits ) ||
		            (!sign && f[0].charAt(0)=='-') ||
		            (f[0].replace(/[+]?0*/, '').length > totalDigits))
		        throw "InvalidNumber";
		    }
		}
		if(f[1].length < decimals){
			var g = f[1];
			for(i = f[1].length + 1; i <= decimals; i++) {
				g += '0';
			}
			f[1] = g;
		}
		var signChar = '';
		if (sign && f[0].charAt(0)=='-'){
		    signChar='-';
		    f[0]=f[0].substring(1);
		}
		if(thSep != '' && f[0].length > 3) {
			var h = f[0];
			f[0] = '';
			for(j = 3; j < h.length; j += 3) {
				i = h.slice(h.length - j, h.length - j + 3);
				f[0] = thSep + i +  f[0] + '';
			}
			j = h.substr(0, (h.length % 3 == 0) ? 3 : (h.length % 3));
			f[0] = j + f[0];
		}
		decSep = (f[1] == '') ? '': decSep;
		if ( picture.replace(/9/g, '')=='' && picture.length > f[0].length)
		{
			f[0] = gx.text.padl(f[0], picture.length, "0");
		}
		return signChar + f[0] + decSep + f[1];
	},

	add: function( a, b) {
		var io=gx.lang.instanceOf;
		if (io(a, Number) && io(b, Number) || typeof(gx.num.dec)=="undefined")
			return a + b;
		var dec=gx.num.dec.bigDecimal;
		if (io(a, dec) && io(b, Number))
			return a.add(new dec(b.toString()));
		else if (io(a, Number) && io(b, dec))
			return new dec(a.toString()).add(b);
		else 
			return a.add(b);
	},
	
	subtract: function( a, b) {
		var io=gx.lang.instanceOf;
		if (io(a, Number) && io(b, Number) || typeof(gx.num.dec)=="undefined")
			return a - b;
		var dec=gx.num.dec.bigDecimal;
		if (io(a, dec) && io(b, Number))
			return a.subtract(new dec(b.toString()));
		else if (io(a, Number) && io(b, dec))
			return new dec(a.toString()).subtract(b);
		else 
			return a.subtract(b);
	},
	
	multiply: function( a, b) {
		var io=gx.lang.instanceOf;
		if (io(a, Number) && io(b, Number)  || typeof(gx.num.dec)=="undefined")
			return a * b;
        var dec = gx.num.dec.bigDecimal;
		if (io(a, dec) && io(b, Number))
			return a.multiply(new dec(b.toString()));
		else if (io(a, Number) && io(b, dec))
			return new dec(a.toString()).multiply(b);
		else 
			return a.multiply(b);
	},
	
	divide: function( a, b) {
		var io=gx.lang.instanceOf;
		if (io(a, Number) && io(b, Number)  || typeof(gx.num.dec)=="undefined")
			return a / b;
        var dec = gx.num.dec.bigDecimal;
        if (io(a, dec) && io(b, Number))
			return a.divide(new dec(b.toString()));
		else if (io(a, Number) && io(b, dec))
			return new dec(a.toString()).divide(b);
		else 
			return a.divide(b);
	},
	
	negate: function( a) {
		if (gx.lang.instanceOf(a, Number)  || typeof(gx.num.dec)=="undefined")
			return -a;
		else 
			return a.negate();
	},
	
	pow: function( a, b) {
		var io=gx.lang.instanceOf;
		if (io(a, Number) && io(b, Number)  || typeof(gx.num.dec)=="undefined")
			return a^b;
		var dec=gx.num.dec.bigDecimal;
		if (io(a, dec) && io(b, Number))
			return a.pow(new dec(b.toString()));
		else if (io(a, Number) && io(b, dec))
			return new dec(a.toString()).pow(b);
		else 
			return a.pow(b);
	},
	
	mod: function( a, b) {
		var io=gx.lang.instanceOf;
		if (io(a, Number) && io(b, Number)  || typeof(gx.num.dec)=="undefined")
			return a % b;
		var dec=gx.num.dec.bigDecimal;
		if (io(a, dec) && io(b, Number))
			return a.remainder(new dec(b.toString()));
		else if (io(a, Number) && io(b, dec))
			return new dec(a.toString()).remainder(b);
		else 
			return a.remainder(b);
	},
	
	setScale: function(SVal, Dec)
	{
		if (gx.lang.instanceOf(SVal, Number))
			return SVal.toFixed(Dec);
			
		if (typeof(SVal)=="string")
			SVal = gx.text.trim(SVal);
		if (SVal.length < this.maxNumericPrecision() || typeof(gx.num.dec)=="undefined")
		{
		    if (SVal.length==0 && Dec ==0)
		    {
		        return '0';
		    }
		    else
		    {
			    var f = SVal.split('.');
			    var i;
			    if(!f[1]) f[1] = '';
    			
			    if(f[1].length < Dec){
				    var g = f[1];
				    for(i = f[1].length + 1; i <= Dec; i++) {
					    g += '0';
				    }
				    f[1] = g;
				    return f[0] + ((f[1] == '') ? '': '.') + f[1];
			    }
			    else
			    {
				    return Number( parseFloat(SVal)).toFixed( Dec);
			    }
			}
		}
		else
			return new gx.num.dec.bigDecimal(SVal).setScale(Dec, gx.num.dec.ROUND_UP).toString();
	},
	
	parseFloat: function( S, ThSep, DecPoint) {
        if (typeof (S) == 'number'||this.overflowNumber(S))
            return S;
        var N = this.toInvariant(S, ThSep, DecPoint);
		if (N.length > this.maxNumericPrecision() && typeof(gx.num.dec)!="undefined")
			return new gx.num.dec.bigDecimal(N);
		else
			return parseFloat( N);
	},

    toInvariant: function(S, ThSep, DecPoint){
        if (typeof (S) == 'number')
            return S;
        else
            return gx.text.replaceAll(S, ThSep, '').replace(DecPoint, '.');
    },

	parseInt: function( S, Radix, ThSep) {
		if ( typeof(S) == 'number')
			return S;
		var N = S;
		N = gx.text.replaceAll(S, ThSep, '');
		return parseInt( N, Radix);
	},
	
	overflowNumber: function(S) {
	    var regExp = /\*(\**)/;
		return regExp.test( S);
	},

	urlDecimal: function( Control, ThSep, DecPoint) {
		var value = (Control.value != undefined) ? Control.value:Control;
		value = this.parseFloat( value, ThSep, DecPoint);
		return value.toString();
	},
	
	random: function() {
		return Math.random();
	},
	
	intval: function( num) {
		var result = 0;
		if (typeof(num) != 'undefined')
		{
			num = num.toString();
		}
		else
		{
			num = '';
		}
		if (num.length < gx.num.maxNumericPrecision() || typeof(gx.num.dec) == 'undefined')
		{
			result = parseInt( num);
		}
		else
		{
			result = new gx.num.dec.bigDecimal(num).setScale(0, gx.num.dec.ROUND_UP).toString();
		}
		if( isNaN( result))
			result = 0;
		return result;
	},
	
	val: function( str) {
		str = gx.text.trim( str).replace( ',', '.');
		var result = this.parseFloat(str);
		if( isNaN( result))
				result = 0;
		return result;
	},
	
	trunc: function( num, dec) {
		var result = num;
		num = num.toString();
		
		var len = num.length;
		
		var decSep = num.indexOf('.');
		
		if(decSep != -1)
		{ 
			var intPart = num.substring(0, decSep);
			
			if( dec == 0)
				return intPart;
				
			var floatPart = "";
			if( decSep + dec <= len)
				floatPart = num.substring(decSep + 1, decSep + 1 + dec);
			
			num = intPart + '.' + floatPart;
			
			result = parseFloat( num);
			if( isNaN( result))
				result = 0;
		}
		return result;
	},
	
	round: function( n, d) {
		n = n.toString();
		var xx = n.indexOf('.');
		var zstr = '0000000000000000000000';
		var theInt = '';
		var theFrac = '';
		var theNo = '';
		var nx = 0;
		var xt = parseInt(d) + 1;
		var rstr = '' + zstr.substring(1,xt);
		var rfac = '.' + rstr + '5';
		var rfacx = parseFloat(rfac);
		if (xx == -1 ) 	{
			theFrac = zstr;
			theInt = "" + n;
		}
		else if (xx == 0) {
			theInt = '0';
			nx = 0 + parseFloat(n) + parseFloat(rfacx);
			n = nx + zstr;
			theFrac = '' + n.substring(1, n.length);
		}
		else {
			if(d == 0)
			{
				theInt = n.substring(0,xx);
				var result = parseInt(theInt);
				var firstFrac = parseInt(n.substring(xx+1, xx+2));
				if( isNaN( result))
					return 0;
				if( !isNaN( firstFrac) && firstFrac >= 5)
					result++;
				return result;
			}
			nx = parseFloat(n) + rfacx;
			theInt = nx.toString().substring(0,xx);
			n = '' + nx + zstr;
			theFrac = '' + n.substring(xx+1,xx + 1 + parseInt(d));
		}
		theFrac = theFrac.substring(0,parseInt(d));
		theNo = theInt + '.' + theFrac;
		var result = parseFloat( theNo);
			if( isNaN( result))
				result = 0;
		return result;
	},
	
	valid_decimal: function( Elem, ThSep, DecPoint, Dec) {
		var ctrlValue = Elem.value;
		var pointIdx = ctrlValue.lastIndexOf(DecPoint);
		var validNumber = true;
		if (DecPoint==',' && pointIdx==-1 && ctrlValue.lastIndexOf('.')==ctrlValue.indexOf('.'))
		{	
			ctrlValue = ctrlValue.replace( '.', DecPoint);
		}
		var gx_DecRegExp = new RegExp("^[ ]*([+-]?[0-9]*(\\" + ThSep + "[0-9]{3})*(\\" + DecPoint + "[0-9]*)?)?[ ]*$");
		if (gx_DecRegExp.test( ctrlValue))
		{
			pointIdx = ctrlValue.lastIndexOf(DecPoint);
			var newvalue = ctrlValue;
			if (pointIdx != -1)
				newvalue = ctrlValue.slice( 0, pointIdx + parseInt(Dec,10) + 1);
			var validStruct = gx.O.getValidStructFld(Elem.id);
			try{
			    if (!gx.lang.emptyObject(validStruct))
				    newvalue = gx.num.formatNumber(newvalue, validStruct.dec, validStruct.pic, validStruct.len, validStruct.sign, true); 
                if (DecPoint != '.' && Elem.tagName == 'SELECT')
			        newvalue = gx.num.toInvariant(newvalue, ThSep, DecPoint);
			}catch(e){validNumber=false;}
			if (validNumber && newvalue!=gx.text.trim(Elem.value))
			{
				Elem.value = newvalue;
				if (navigator.userAgent.indexOf("Firefox/2") != -1)
					//WA For FF 2.0 bug (https://bugzilla.mozilla.org/show_bug.cgi?id=357684)
					Elem.onchange();
			}
		}
		else
		{
		    validNumber=false;
		}
		if (!validNumber)
            gx.fn.alert( Elem, gx.getMessage("GXM_badnum"));

	},
	
	valid_integer: function( Elem, ThSep) {
		var gx_IntRegExp = new RegExp("^[ ]*([+-]?[0-9]*(\\" + ThSep + "[0-9]{3})*)?[ ]*$");
		var validNumber=true;
		if (gx_IntRegExp.test( Elem.value))
		{ 
			var newvalue = Elem.value;
			var vStruct = gx.O.getValidStructFld(Elem.id);
			try{
			    if (!gx.lang.emptyObject(vStruct))
				    newvalue = gx.num.formatNumber(newvalue, vStruct.dec, vStruct.pic, vStruct.len, vStruct.sign, true); 
            }catch(e){validNumber=false;}
			if (newvalue!=gx.text.trim(Elem.value))
			{
				Elem.value = newvalue;
				if (navigator.userAgent.indexOf("Firefox/2") != -1)
					//WA For FF 2.0 bug (https://bugzilla.mozilla.org/show_bug.cgi?id=357684)
					Elem.onchange();
			}
		}
		else
		{
		    validNumber=false;
		}
		if (!validNumber)
    		gx.fn.alert( Elem, gx.getMessage("GXM_badnum"));
	}
};

gx.color = {
	rgb: function( r, g, b) {
		return (r * 256 * 256) + g * 256 + b;
	},
	
	css: function( Color) {
		if (Color.substring(0,3) == 'rgb')
			return eval(Color);
		return (Color.charAt(0) == '#') ? parseInt( Color.substring(1), 16) : 0;
	},
	
	html: function( num) {
		var hexColor = this.toHex(num);
		if (gx.lang.emptyObject(hexColor))
		{
			hexColor = "000000";
		}
		hexColor = gx.text.padr(hexColor,6,"0");
		var htmlColor = {};
		htmlColor.Hexa = hexColor;
		htmlColor.Html = '#'+hexColor;
		htmlColor.R = parseInt( hexColor.substring(0,2), 16 );
		htmlColor.G = parseInt( hexColor.substring(2,4), 16 );
		htmlColor.B = parseInt( hexColor.substring(4,6), 16 );
		return htmlColor;
	},
	
	fromRGB: function( R, G, B) {
		var htmlColor = {};
		if ((R != undefined) && (G != undefined) && (B != undefined))
		{
			htmlColor.Hexa = this.toHex(R) + this.toHex(G) + this.toHex(B);
			htmlColor.Html = '#'+htmlColor.Hexa;
			htmlColor.R = R;
			htmlColor.G = G;
			htmlColor.B = B;
		}
		return htmlColor;
	},
	
	ARGBToHex: function( argb) {
		var A = this.toHex((argb >> 24) & 0xFF);
		var R = this.toHex((argb >> 16) & 0xFF);
		var G= this.toHex((argb >> 8) & 0xFF);
		var B = this.toHex(argb & 0xFF);
		return R + G + B;
	},
	
	toHex: function(num) {
		if (num == undefined)
	    return "000000";
		if (num < 0)
		{
			return gx.color.ARGBToHex(num);
		}
		var hexChars = "0123456789ABCDEF";
		if (num == 0) 
			return num + '0';
		var j = 0;
		var hexStr = "";
		while (num != 0)
		{
			j = num % 16;
			num = (num - j)/16;
			hexStr = hexChars.charAt(j) + hexStr;
		}
		if ((hexStr.length % 2) != 0)
			hexStr = '0' + hexStr;
		return hexStr;
	}
};
/* END OF FILE - gxtypes.js - */
/* START OF FILE - gxpopup.js - */
gx.popup = {
	lvl: -1,
	currentPopup: null,
	currentPrompt: null,
	
	Class: function( popupData, IsPrompt) {
		this.id = '';
		this.url = '';
		this.autoresize = 1;
		this.width = 0;
		this.height = 0;
		this.position = 0;
		this.top = 0;
		this.left = 0;
		this.zindex = 1000;
		this.lvl = -1;
		this.parentPopup = null;
		this.window = null;
		this.document = null;
		this.frameDocument = null;
		this.frameWindow = null;
		this.ReturnParms = [];
		this.RawReturnedParms = [];
		this.ModifCtrl = null;
		this.Opener = null;
		this.IsPrompt = (IsPrompt != undefined)?IsPrompt:false;
		this.PromptIsGet = false;
		this.InternalPopup = null;
		this.OncloseCmds = [];
		this.CustomRenderGrid = null;
		
		this.setPopupData = function()
		{
			if (popupData instanceof Array)
			{
				this.url 	= popupData[0];
				this.autoresize = popupData[1];
				this.width 	= popupData[2];
				this.height 	= popupData[3];
				this.position 	= popupData[4];
				this.top 	= popupData[5];
				this.left 	= popupData[6];
				this.OncloseCmds = popupData[7] || [];
				this.ReturnParms = popupData[8] || [];
			}
			else if (popupData.Url)
			{
				this.url = popupData.Url;
				if (typeof(popupData.Autoresize) != 'undefined')
					this.autoresize = popupData.Autoresize;
				if (typeof(popupData.Width) != 'undefined')
					this.width = popupData.Width;
				if (typeof(popupData.Height) != 'undefined')
					this.height = popupData.Height;
				if (typeof(popupData.Position) != 'undefined')
					this.position = popupData.Position;
				if (typeof(popupData.Top) != 'undefined')
					this.top = popupData.Top;
				if (typeof(popupData.Left) != 'undefined')
					this.left = popupData.Left;
				if (typeof(popupData.OncloseCmds) != 'undefined')
					this.OncloseCmds = popupData.OncloseCmds;
				if (typeof(popupData.ReturnParms) != 'undefined')
					this.ReturnParms = popupData.ReturnParms;
			}
		}
	
		this.open = function()
		{
			var pOpener = gx.popup.gxOpener();
			this.lvl = -1;
			if (pOpener && pOpener.gx && pOpener.gx.popup.ext.win && pOpener.gx.popup.ext.win.gx)
			{
				this.lvl = pOpener.gx.popup.ext.win.gx.popup.lvl;
			}
			else
			{
				this.lvl = gx.popup.lvl;
			}
			if (document.gxPopup != null)
			{
				this.parentPopup = document.gxPopup;
				this.zindex = gx.popup.ext.zdx + document.gxPopup.zindex;
			}
			else
			{
				this.zindex = gx.popup.ext.zdx;
			}
			var sUrl = this.url;
			if (this.IsPrompt == true)
			{
				gx.popup.currentPrompt = this;
				var sParms = "?";
				var len = this.ReturnParms.length;
				for (var i=0;i<len;i++)
				{
					if (!gx.lang.emptyObject(this.ReturnParms[i].Ctrl))
						sParms += gx.util.urlValue(this.ReturnParms[i].Ctrl) + ",";
					else if( typeof this.ReturnParms[i] == "string")
						sParms += gx.util.urlValue(this.ReturnParms[i]) + ",";
					else if (this.CustomRenderGrid)
					{
						var parmValue = this.CustomRenderGrid.grid.getCellValue(this.ReturnParms[i].id);
						if (!gx.lang.emptyObject(parmValue))
							sParms += gx.util.urlValue(parmValue + "") + ",";						
					}
					else if (!gx.lang.emptyObject(this.ReturnParms[i].id))
						sParms += gx.util.urlValue(gx.fn.getHidden(this.ReturnParms[i].id)) + ",";
					else
						continue;
					if ((this.ReturnParms[i].isLastKey == true) && (this.ReturnParms[i].isOut == true) && (this.PromptIsGet == false))
					{
						gx.fn.setControlValue('_EventName', this.Opener.CmpContext);
						this.PromptIsGet = true;
					}
				}
				if (this.ModifCtrl != null) 
					this.ModifCtrl.value = 1;
				sUrl += sParms;
			}
			this.InternalPopup = gx.popup.Impl( this, sUrl, this.autoresize, this.width, this.height, this.position, this.top, this.left);
		}
		
		this.getOutputParms = function()
		{
			var outputParms = [];
			if (this.IsPrompt)
			{
				var len = this.ReturnParms.length;
				for (var i=0;i<len;i++)
				{
					var promptParm = this.ReturnParms[i];
					if (promptParm.isOut == true)
					{
						outputParms.push(promptParm);
					}
				}
			}
			else
			{
				return this.ReturnParms;
			}
			return outputParms;
		}
		
		this.close = function( cParms)
		{
			if (cParms)
			{
				this.RawReturnedParms = cParms;
			}
			gx.ajax.windowClosed(gx.popup.lvl);
			gx.popup.lvl--;
			if (this.frameWindow && this.frameWindow.gx)
			{
				if (this.IsPrompt == true)
				{
				    if (this.parentPopup ==  null)
				        gx.popup.currentPrompt = null;
				    else
					this.parentPopup.frameWindow.gx.popup.currentPrompt = null;
				}
				this.frameWindow.gx.evt.onunload.call(this.frameWindow);
				this.frameDocument.gxPopup = null;
				this.frameDocument = null;
				this.frameWindow = null;
			}
			gx.popup.ext.close(this);
			var returnParms = this.getOutputParms();
			if ((cParms != null) && (this.IsPrompt == true))
			{
				var len = cParms.length;
				var func = gx.popup.assignPromptField;
				var scope = gx.popup;
				if (!gx.lang.emptyObject(this.CustomRenderGrid))		
				{
					func = this.CustomRenderGrid.grid.setCellValue;
					scope = this.CustomRenderGrid.grid;
				}
				for (var i=0;i<len;i++)
				{					
					func.apply(scope,[returnParms[i], cParms[i]]);
				}
				if (this.PromptIsGet) 
				{ 
					gx.csv.loadScreen();
				} 
				else 
				{ 
					try
					{
						var edtCtrl = null;
						len = returnParms.length;
						for (var i=0; i<len; i++)
						{
							var ctrl = returnParms[i].Ctrl;
							if (gx.fn.isAccepted(ctrl))
							{
								edtCtrl = ctrl;
							}
						}
						if (edtCtrl)
							gx.fn.setFocus(edtCtrl);
						gx.evt.ctrlOnchange(gx.fn.getControlValue(this.Opener.CmpContext+'Mode'), 
						gx.fn.getControlValue(this.Opener.CmpContext+'IsConfirmed'), (typeof(window.GXPkIsDirty)=="undefined"?false:window.GXPkIsDirty), null, 'eng');
					} 
					catch(e)
					{
						gx.dbg.logEx(e, 'gxpopup.js', 'close');
					}
				}
			}
			else if (cParms)
			{
				if (returnParms && returnParms instanceof Array && returnParms.length > 0)
				{
					gx.fn.setReturnParms( this.Opener, returnParms, cParms);
				}
			}
			gx.ajax.dispatchCommands(this.OncloseCmds);
			this.cleanup();
		}
		
		this.setFocusFirst = function()
		{
			if (this.frameWindow.gx)
			{
				this.frameWindow.gx.fn.setFocusOnload();
			}
		}
		
		this.cleanup = function()
		{
			try
			{
				this.OncloseCmds = [];
				this.ReturnParms = [];
				this.PromptIsGet = false;
				this.InternalPopup = null;
				this.window = null;
				this.document = null;
				this.Opener = null;
				this.parentPopup = null;
				this.RawReturnedParms = [];
				this.ModifCtrl = null;
				this.InternalPopup = null;
				this.CustomRenderGrid = null;
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxpopup.js', 'popupObj.cleanup');
			}
		}
		
		this.setPopupData();
	},

	gxOpener: function() {
		var pOpener = null;
		try
		{
			parent.gxTestAvailable = 1;
			pOpener = parent;
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxpopup.js', 'gxOpener');
		}
	  	return pOpener;
	},
	
	setFocus: function() {
		var popUp = this.getPopup();
		if (popUp)
		{
			popUp.window.frames[0].focus();
		}
	},

	ispopup: function() {	
	  	return (this.getPopup() != null);
	},

	popupurl: function() {
		return this.getPopup().url;
	},

	getPopup: function() {
		var pOpener = this.gxOpener();
		if (!gx.lang.emptyObject(pOpener) && !gx.lang.emptyObject(pOpener.gx))
			return pOpener.gx.popup.currentPopup;
		return null;
	},
	
	setPopup: function( gxP) {
		this.currentPopup = gxP;
	},

	open: function( popupData) {
		return this.openPopup( popupData);
	},
	
	openUrl: function( url, returnParms, props) {
		var az = 1;
		var w = 0;
		var h = 0;
		var p = 0;
		var t = 0;
		var l = 0;
		if (props)
		{
			az = props[0];
			w = props[1];
			h = props[2];
			p = props[3];
			t = props[4];
			l = props[5];
		}
		return this.openPopup([url,az,w,h,p,t,l,[], returnParms]);
	},

	openPopup: function( popupData) {
		var popup = new this.Class( popupData, false);
		popup.Opener = gx.O;
		popup.open();
		return popup;
	},

	openPrompt: function( PgmName, PgmParms, IsMod, CmpCtx, InMasterPage, IsAuto) {
		if (gx.popup.currentPrompt == null)
		{
			var Ctrl=PgmParms[0].Ctrl;
			var isUserControl = false;
			var rowGridId;
			var rowId;
			var grid;
			if (Ctrl)
			{
			    rowGridId = gx.fn.rowGridId(Ctrl);
			    rowId = gx.fn.controlRowId(Ctrl);
			    if (!gx.lang.emptyObject(rowGridId) && !gx.lang.emptyObject(rowId))
			    {
			          gx.csv.lastGrid = rowGridId;  	            
			        gx.fn.setCurrentGridRow(rowGridId, rowId);
			    }
			}
			else				
			{
			    var vStruct = gx.O.getValidStructFld(PgmParms[0].id);
			    if (!gx.lang.emptyObject(vStruct)){
				    grid = gx.O.getGridById(vStruct.grid);
				    if (grid)
				    {
					    isUserControl = grid.isUsercontrol;	
					    if (isUserControl)
					    {
						    rowGridId= grid.gridId + "";
						    rowId = (!gx.lang.emptyObject(grid.grid.getSelectedRow))? gx.text.padl(grid.grid.getSelectedRow() + "", 4, "0"): undefined;
						    if (!gx.lang.emptyObject(rowGridId) && !gx.lang.emptyObject(rowId))
    				        {
                            gx.csv.lastGrid = rowGridId;  	            
                            gx.fn.setCurrentGridRow(rowGridId, rowId);
	    			        }				
					    }
				    }				
		        }
			}
			if (!IsAuto && !this.outParmsAccepted( PgmParms) && !isUserControl)
				return;
			var popup = new this.Class( [PgmName,1,0,0,0,0,0,[],PgmParms], true);
			popup.IsMod = IsMod;
			popup.Opener = gx.getObj( CmpCtx, InMasterPage);
			popup.CustomRenderGrid = grid;
			popup.open();
		}
	},
	
	outParmsAccepted: function( Parms) {
		var len = Parms.length;
		var anyOut = false;
		for (var i=0; i<len; i++)
		{
			var parm = Parms[i];
			if (parm.isOut)
				anyOut = true;
			if (parm.isOut && parm.Ctrl && gx.fn.isAccepted( parm.Ctrl))
				return true;
		}
		return !anyOut;
	},
	
	gxReturn: function( Parms) {
		gx.fn.closeWindow(Parms);
	},
	
	parmId: function( Ctrl) {
		var id = gx.dom.id( Ctrl);
		if (id.indexOf('span_') == 0)
		{
			id = id.substring(5);
		}
		return id;
	},
	
	assignPromptField: function( Parms, PValue) {
		if (gx.lang.emptyObject(Parms))
			return;
		gx.csv.pkDirty = Parms.isKey;
		if (!Parms.Ctrl)
			return;
		if (Parms.Ctrl.type == "checkbox" && Parms.Ctrl.value != PValue)
			Parms.Ctrl.checked = !Parms.Ctrl.checked;
		if (Parms.Ctrl.value != PValue && Parms.isKey)
			gx.popup.gxOpener().GXPkIsDirty = true;
		var toValid = gx.O.getCtrlIdx( Parms.Ctrl.id);
	        if (toValid) {
	                //Validate previous controls
	                if ( toValid > gx.csv.toValid)
	                    gx.csv.toValid = toValid;
	                gx.csv.validateAll()
	        }
		var ControlId = gx.csv.ctxControlId( this.parmId(Parms.Ctrl));
		var validStruct = gx.O.getValidStructFld(ControlId);
		if (!gx.lang.emptyObject(validStruct) && !gx.lang.emptyObject(validStruct.v2c) && (validStruct.type == 'date' || validStruct.type == 'dtime'))
		{
		    validStruct.v2v(PValue); 
		    validStruct.v2c();
		}
		else
		{
		    gx.fn.setControlValue( this.parmId(Parms.Ctrl), PValue, 0);
		}
		Parms.Ctrl.setAttribute( "gxvalid", "0");
		gx.evt.execOnchange( Parms.Ctrl);
		var spanObj = gx.dom.byId('span_' + Parms.Ctrl.name); 
		if(spanObj != null) 
		{	
			if(spanObj.childNodes.length == 0) 
				spanObj.appendChild( gx.popup.gxOpener().document.createTextNode(""));
			var spanChild = spanObj.childNodes[0]; 
			spanChild.nodeValue = PValue;
		}
	},
	
	autofit: function() {
		var popup = this.getPopup();
		if (!gx.lang.emptyObject(popup))
		{
			this.ext.autofit( popup, popup.frameDocument, false);
		}
	},
	
	Impl: function( popupObj, url, autoresize, width, height, position, top, left) {
		var headerClass = 'PopupHeader';
		var buttonClass = 'PopupHeaderButton';
		var contentClass = 'PopupContent';
		var borderClass = 'PopupBorder';
		var shadowClass = 'PopupShadow';
		return new this.ext.popUp( popupObj, autoresize, position, left, top, width, height, "gxp", url, "white", "#00385c", "16pt serif", "GxPopup", "#00385c", "white", "lightgrey", "#00568c", "black", true, false, true, true, true, true, false,'min.gif','max.gif','close.gif','resize.gif', headerClass, buttonClass, contentClass, borderClass, shadowClass);
	},
	
	setZIndex: function( ctrl) {
		var zIndex = gx.dom.getStyle( ctrl, 'zIndex');
		if (isNaN(zIndex))
			zIndex = 999;
		zIndex++;
		this.zindex = zIndex;
		this.ext.zdx = zIndex;
	},

	ext: {
		w3c: gx.util.browser.w3c,
		ns4: gx.util.browser.ns4,
		ie5: gx.util.browser.ie5,
		ns6: gx.util.browser.ns6,
		isFF: gx.util.browser.isFirefox(),
		currIDb: null,
		xoff: 0,
		yoff: 0,
		currRS: null,
		rsxoff: 0,
		rsyoff: 0,
		zdx: 1000,
		sdiff: 5,
		win: null,
		doc: null,

		hide: function(id) {
			if(this.w3c)
			{
				var byId= gx.dom.byId;
				byId(id+'_t').style.visibility="hidden";
				byId(id+'_c').style.visibility="hidden";
				byId(id+'_rs').style.visibility="hidden";
				byId(id+'_b').style.visibility="hidden";
				byId(id+'_s').style.visibility="hidden";
			}
		},

		show: function(id) {
			var byId= gx.dom.byId;
			byId(id+'_t').style.visibility="visible";
			byId(id+'_c').style.visibility="visible";
			byId(id+'_rs').style.visibility="visible";
			byId(id+'_b').style.visibility="visible";
			byId(id+'_s').style.visibility="visible";
		},
		
		close: function(popupObj) {
			gx.popup.ext.win = null;
			gx.popup.ext.doc = null;
			gx.popup.ext.currIDb = null;
			gx.popup.ext.currIDs = null;
			gx.popup.ext.currRS = null;
			var id = popupObj.id;
			var shadow = document.getElementById(id+ '_s');
			var container = document.getElementById(id+ '_b');
			gx.dom.removeControlSafe( shadow);
			if (gx.util.browser.isIE() && gx.util.browser.ieVersion() == 7) // IE7 bug
			{
				container.parentNode.removeChild(container);
			}
			else
			{
				gx.dom.removeControlSafe( container);
			}
			gx.popup.ext.deinitmodal(popupObj);
			gx.popup.setPopup( popupObj.parentPopup);
			if (popupObj.parentPopup)
			{
				popupObj.parentPopup.frameWindow.gx.fx.obs.notify("popup.close", [popupObj]);
			}
			else
			{
				gx.fx.obs.notify("popup.close", [popupObj]);
			}
		},

		move: function(ids,x,y) {
			if(this.w3c)
			{
				var byId= gx.dom.byId;
				var idb=byId(ids+'_b');
				var idc=byId(ids+'_c');
				var ids=byId(ids+'_s');
				idb.style.left=x+'px';
				ids.style.left=x+this.sdiff+'px';
				idb.style.top=y+'px';
				ids.style.top=y+this.sdiff+'px';
				idc.style.overflow="hidden";
			}
		},

		resize: function(ids,rx,ry) {
			if(this.w3c)
			{
				var byId= gx.dom.byId;
				if(byId(ids+'_rs').rsEnable)
				{
					var waEl = byId(ids+"_extWA");
					var rsEl = byId(ids+"_rs");
					var bEl = byId(ids+"_b");
					var tEl = byId(ids+"_t");
					var sEl = byId(ids+"_s");
					var cEl = byId(ids+"_c");
					
					var ie5 = this.ie5;
					waEl.style.display="block";
					rsEl.style.left=Math.max(rx,((ie5)?88:92))+'px';
					rsEl.style.top=Math.max(ry,((ie5)?68:72))+'px';
					bEl.style.width=Math.max(rx+((ie5)?12:8),100)+'px';
					bEl.style.height=Math.max(ry+((ie5)?12:8),80)+'px';
					tEl.style.width=Math.max(rx+((ie5)?4:3),((this.ns6)?95:92))+'px';
					sEl.style.width=Math.max(rx+12,((ie5)?100:104))+'px';
					sEl.style.height=Math.max(ry+((ie5)?12:13),((ie5)?80:86))+'px';
					cEl.style.width=Math.max(rx-((ie5)?-5:5),((ie5)?92:87))+'px';
					cEl.style.height=Math.max(ry-((ie5)?24:28),44)+'px';
					cEl.style.overflow="hidden";
				}
			}
		},

		ns6bugfix: function() {
			if(navigator.userAgent.indexOf("Netscape/6")>0)
			{
				setTimeout('self.resizeBy(0,1); self.resizeBy(0,-1);', 100);
			}
		},

		movepopup: function() {
			if((this.currIDb!=null)&&this.w3c)
			{
				this.move(this.currIDb.cid,gx.evt.mouse.x+this.xoff,gx.evt.mouse.y+this.yoff);
			}
			if((this.currRS!=null)&&this.w3c)
			{
				this.resize(this.currRS.cid,gx.evt.mouse.x+this.rsxoff,gx.evt.mouse.y+this.rsyoff);
			}
			return false;
		},

		stopRS: function() {
			document.getElementById(this.cid+"_extWA").style.display="none";
			gx.popup.ext.currRS=null;
		},

		startRS: function(evt) {
			var pExt = gx.popup.ext;
			var ex=(pExt.ie5)?event.clientX+document.body.scrollLeft:evt.pageX;
			var ey=(pExt.ie5)?event.clientY+document.body.scrollTop:evt.pageY;
			pExt.rsxoff=parseInt(this.style.left)-ex;
			pExt.rsyoff=parseInt(this.style.top)-ey;
			pExt.currRS=this;
			if(pExt.ns6)
			{
				document.getElementById(this.cid+"_c").style.overflow='hidden';
			}
			return false;
		},

		changez: function(v) {
			var th=(v!=null)?v:this;
			var pExt = gx.popup.ext;
			var byId= gx.dom.byId;
			if(pExt.ns6)
			{
				byId(th.cid+"_c").style.overflow='hidden';
			}
			byId(th.cid+"_s").style.zIndex=++pExt.zdx;
			th.style.zIndex=++pExt.zdx;
			byId(th.cid+"_rs").style.zIndex=++pExt.zdx;
		},

		stopdrag: function() {
			var pExt = gx.popup.ext;
			pExt.currIDb=null;
			document.getElementById(this.cid+"_extWA").style.display="none";
			pExt.ns6bugfix();
		},

		grab_id: function(evt) {
			var pExt = gx.popup.ext;
			var byId= gx.dom.byId;
			var ex=(pExt.ie5)?event.clientX+document.body.scrollLeft:evt.pageX;
			var ey=(pExt.ie5)?event.clientY+document.body.scrollTop:evt.pageY;
			pExt.xoff=parseInt(byId(this.cid+"_b").style.left)-ex;
			pExt.yoff=parseInt(byId(this.cid+"_b").style.top)-ey;
			pExt.currIDb=byId(this.cid+"_b");
			pExt.currIDs=byId(this.cid+"_s");
			byId(this.cid+"_extWA").style.display="block";
			return false;
		},

		subBox: function(x,y,w,h,bgc,id) {
			var v=document.createElement('div');
			v.setAttribute('id',id);
			v.style.position='absolute';
			v.style.left=x+'px';
			v.style.top=y+'px';
			v.style.width=w+'px';
			v.style.height=h+'px';
			v.style.visibility='visible';
			v.style.padding='0px';
			return v;
		},

		popUp: function(popupObj,autoSize,popCentered,x,y,w,h,cid,text,bgcolor,textcolor,fontstyleset,title,titlecolor,titletextcolor,bordercolor,scrollcolor,shadowcolor,ismodal,showonstart,isdrag,isresize,oldOK,isExt,popOnce,minImg,maxImg,clsImg,rsImg, headCls, btnCls, cntCls, brdCls, shdwCls) {		
			var pExt = gx.popup.ext;
			var igmsDir = gx.basePath + gx.staticDirectory;
			
			if (popupObj.parentPopup != null)
			{
				pExt.win = popupObj.parentPopup.window;
				pExt.doc = pExt.win.document;
				pExt = pExt.win.gx.popup.ext;
				gx.popup.ext = pExt;
			}
			else
			{
				pExt.win = window;
				pExt.doc = pExt.win.document;
			}
			
			pExt.win.gx.popup.setPopup(popupObj);
			
			popupObj.window = pExt.win;
			popupObj.document = pExt.doc;
			
			pExt.win.gx.popup.lvl++;
			cid += pExt.win.gx.popup.lvl;
			popupObj.id = cid;
			
			var byId= function(Id) { return pExt.doc.getElementById(Id); };
			
			if (!popupObj.IsPrompt && !gx.util.sameAppUrl(text))
			{
				ismodal = false;
				gx.popup.setPopup( null);
				var ctr=new Date();
				ctr=ctr.getTime();
				var t=(isExt)?text:'';
				var posn='';
				if (popCentered == 1)
				{
					posn= (pExt.ns4)? 'screenX='+x+',screenY='+y: 'left='+x+',top='+y;
				}
				var pdims = '';
				if (autoSize == 0)
				{
					pdims = ",width="+w+",height="+h;
				}
				var win=window.open(t , "gx"+ctr , "status=no,menubar=no"+pdims+",resizable="+((isresize)?"yes":"no")+",scrollbars=yes,"+posn);
			}
			else
			{
				w=Math.max(w,100);
				h=Math.max(h,80);
				var rdiv=new pExt.subBox(w-((pExt.ie5)?12:8),h-((pExt.ie5)?12:8),7,7,'',cid+'_rs');
				if(isresize)
				{
					rdiv.innerHTML='<img src="' + gx.util.resourceUrl(igmsDir + rsImg, true) + '" width="7" height="7">';
					rdiv.style.cursor='se-resize';
				}
				rdiv.rsEnable=isresize;
				var tw=(pExt.ie5)?w:w+4;
				var th=(pExt.ie5)?h:h+6;
				var shadow=new pExt.subBox(x+pExt.sdiff,y+pExt.sdiff,tw,th,shadowcolor,cid+'_s');
				shadow.className = shdwCls;
				if(pExt.ie5)
				{
					shadow.style.filter="alpha(opacity=50)";
				}
				else
				{
					shadow.style.MozOpacity=.5;
				}
				shadow.style.zIndex=++pExt.zdx;
				if(!showonstart)
				{
					shadow.style.visibility = "hidden";
				}
				var outerdiv=new pExt.subBox(x,y,w,h,bordercolor,cid+'_b');
				outerdiv.className = brdCls;
				outerdiv.style.display="block";
				outerdiv.style.zIndex=++pExt.zdx;
				if(!showonstart)
				{
					outerdiv.style.visibility = "hidden";
				}
				tw=(pExt.ie5)?w-8:w-5;
				th=(pExt.ie5)?h+4:h-4;
				var titlebar=new pExt.subBox(2,2,tw,20,titlecolor,cid+'_t');
				titlebar.style.overflow="hidden";
				titlebar.className = headCls;
				if(!showonstart)
				{
					titlebar.style.visibility = "hidden";
				}
				titlebar.innerHTML='<span id="'+cid+'_gxtitle"  style="position:absolute;overflow:hidden;padding: 2px;">'+title+'</span><span class="'+btnCls+'" style="z-index:' +(++pExt.zdx)+  ';" id="'+cid+'_cls"></span>';
				tw=(pExt.ie5)?w-7:w-13;
				var content=new pExt.subBox(2,24,tw,h-36,bgcolor,cid+'_c');
				content.className = cntCls;
				text += (text.indexOf('?') != -1)?',':'?';
				text += encodeURIComponent( 'gxPopupLevel=' + pExt.win.gx.popup.lvl + ';');
				content.innerHTML='<iframe id="'+cid+'_ifrm" src="'+text+'" width="100%" height="100%" frameborder="0" scrolling="off"></iframe>';
				content.style.overflow="hidden";
				if(!showonstart)
				{
					content.style.visibility = "hidden";
				}
				if(!showonstart)
				{
					outerdiv.style.visibility = "hidden";
				}
				var extWA=new pExt.subBox(2,24,0,0,'',cid+'_extWA');
				extWA.style.display="none";
				extWA.style.width='100%';
				extWA.style.height='100%';
				outerdiv.appendChild(titlebar);
				outerdiv.appendChild(content);
				outerdiv.appendChild(extWA);
				outerdiv.appendChild(rdiv);
				pExt.doc.body.appendChild(shadow);
				pExt.doc.body.appendChild(outerdiv);
				if(!showonstart)
				{
					pExt.hide(cid);
				}
				var wB=byId(cid+'_b');
				wB.cid=cid;
				wB.isExt=(isExt)?true:false;
				var wT=byId(cid+'_t');
				wT.cid=cid;
				if(isresize)
				{
					var wRS=byId(cid+'_rs');
					wRS.cid=cid;
					wRS.onmousedown=pExt.startRS;
					wRS.onmouseup=pExt.stopRS;
				}
				var wCLS=byId(cid+'_cls');
				var wEXTWA=byId(cid+'_extWA');
				wB.activecolor=titlecolor;
				wB.inactivecolor=scrollcolor;
				wCLS.onclick=popupObj.close.closure(popupObj);
				if(isdrag)
				{
					wT.onmousedown=pExt.grab_id;
					wT.onmouseup=pExt.stopdrag;
				}
				var iFrame = byId(cid+'_ifrm');
				gx.lang.doCallTimeout( pExt.showIfLoaded, pExt, [popupObj, iFrame, 1], 50);
			}
			if (ismodal)
			{
				pExt.initmodal(popupObj);
			}
		},

		initmodal: function(popupObj) {
			if (popupObj.parentPopup == null)
			{
				gx.ajax.disableForm();
			}
			else
			{
				this.hide(popupObj.parentPopup.id);
			}
		},

		deinitmodal: function(popupObj) {
			if (popupObj.parentPopup == null)
			{
				gx.ajax.enableForm();
			}
			else
			{
				this.show(popupObj.parentPopup.id);
			}
		},

		showIfLoaded: function( popupObj, iFrame, times) {
			try
			{
				var frameDoc = iFrame.contentDocument?iFrame.contentDocument:iFrame.contentWindow.document;
				if (this.docReady(frameDoc, times))
				{
					popupObj.state = 'opened';
					this.autofit(popupObj, frameDoc, true);
					return;
				}
			}
			catch (e)
			{
				gx.dbg.logEx(e, 'gxpopup.js', 'showIfLoaded');
			}
			if (!gx.util.browser.isIE())
			{
				times++;
			}
			gx.lang.doCallTimeout( gx.popup.ext.showIfLoaded, gx.popup.ext, [popupObj, iFrame, times], times*50);
		},

		docReady: function(frameDoc, times) {
			if (frameDoc)
			{
				var readyState = (typeof(frameDoc.gxReadyState) != 'undefined')?frameDoc.gxReadyState:frameDoc.readyState;
				if (readyState == 'complete')
					return true;
			}
			if (!gx.util.browser.isIE() && times >= 10 && frameDoc && frameDoc.body && frameDoc.body.childNodes.length != 0)
			{
				return true;
			}
			return false;
		},

		autofit: function(popupObj, frameDoc, doShow) {		
			if (gx.lang.emptyObject(popupObj))
				return;

			var pDoc = document;
			if (pDoc.gxPopup != null)
				popupObj.zindex = this.zdx + pDoc.gxPopup.zindex;
			else
				popupObj.zindex = this.zdx;
				
			var id = popupObj.id;
			if (!this.doc)
				this.doc = popupObj.document;
			pDoc = this.doc;
			var iFrame = pDoc.getElementById(id + '_ifrm');
			if (!frameDoc && gx.popup.ispopup())
			{				
				frameDoc = iFrame.contentDocument?iFrame.contentDocument:iFrame.contentWindow.document;
			}
			popupObj.frameDocument = frameDoc;
			popupObj.frameWindow = iFrame.contentWindow;
			frameDoc.gxPopup = popupObj;
			
			var rsEl 	= pDoc.getElementById(id + '_rs');
			var sEl 	= pDoc.getElementById(id + '_s');
			var tEl 	= pDoc.getElementById(id + '_t');
			var bEl 	= pDoc.getElementById(id + '_b');
			var cEl 	= pDoc.getElementById(id + '_c');
			var titleEl = pDoc.getElementById(id + '_gxtitle');
			
			var cH = parseInt(cEl.style.height);
			var cW = parseInt(cEl.style.width);
			
			var vWidth;
			var vHeight;
			var scrollTop;
			var scrollLeft;
			var framePositionX = 0;
			var framePositionY = 0;

			// Test wether the frameElement can be accessed
			var accessFrame = true;
			try {
				window.frameElement.id;
			}
			catch(e){
				accessFrame = false;
				gx.dbg.logEx(e, "gxpopup.js", "autofit");
			}
			
			if (!accessFrame || window == window.top || gx.lang.emptyObject(window.top))
			{
				vWidth = pDoc.body.clientWidth;
				vHeight = pDoc.body.clientHeight;
				scrollTop = pDoc.body.scrollTop;
				scrollLeft = pDoc.body.scrollLeft;
			}
			else
			{				
			  var framePosition = gx.dom.position(window.frameElement);
				vWidth = Math.min(window.top.document.body.clientWidth,pDoc.body.clientWidth);
				if (window.top.document.body.clientHeight > pDoc.body.clientHeight){
					vHeight = pDoc.body.clientHeight;
				}
				else
				{
					vHeight = window.top.document.body.clientHeight;
					framePositionY = framePosition.y;
				}
				if (window.top.document.body.clientWidth > pDoc.body.clientWidth){
					vWidth = pDoc.body.clientWidth;
				}
				else
				{
					vWidth = window.top.document.body.clientWidth;
					framePositionX = framePosition.x;
				}
				
				scrollTop = pDoc.body.scrollTop;
				scrollLeft = pDoc.body.scrollLeft;
				
			}			
			
			var dims = gx.dom.dimensions(bEl);
				
			if (popupObj.autoresize == 0)
			{
				cH = popupObj.height - cH + dims.h;
				cW = popupObj.width - cW + dims.w;
			}
			
			var diffW = popupObj.width - cW;
			var diffH = popupObj.height - cH;
			
			if (popupObj.autoresize != 0)
			{
				if (frameDoc.body)
				{
					var dW = frameDoc.body.scrollWidth + 30 - vWidth;
					var dH = frameDoc.body.scrollHeight + 30 - vHeight;
					diffW = frameDoc.body.scrollWidth - cW - ((dW > 0)?dW:0);
					diffH = frameDoc.body.scrollHeight - cH - ((dH > 0)?dH:0);
				}
			}
			
			var top = parseInt(popupObj.top);
			var left = parseInt(popupObj.left);
		
			if (popupObj.position == 0)
			{
				top = (vHeight - diffH)/2 - (dims.h/2) + scrollTop - framePositionY;
				left = (vWidth - diffW)/2 - (dims.w/2) + scrollLeft - framePositionX;
				
				if (top < 0)
				{
					top = 5;
					diffH = diffH - 5;
				}
				if (left < 0)
				{
					left = 5;
					diffW = diffW - 5;
				}
			}
			
			bEl.style.top	= parseInt(top)+"px";
			bEl.style.left	= parseInt(left)+"px";
			sEl.style.top	= parseInt(top)+this.sdiff+"px";
			sEl.style.left	= parseInt(left)+this.sdiff+"px";
			
			if (popupObj.autoresize == 0)
			{
				cH = popupObj.height;
				cW = popupObj.width;
				
				var ie5 = this.ie5;
				
				rsEl.style.left		= Math.max(cW,((ie5)?88:92))+'px';
				rsEl.style.top	= Math.max(cH,((ie5)?68:72))+'px';
				
				bEl.style.width	= Math.max(cW+((ie5)?12:8),100)+'px';
				bEl.style.height	= Math.max(cH+((ie5)?12:8),80)+'px';
				
				tEl.style.width	= Math.max(cW+((ie5)?4:3),((this.ns6)?95:92))+'px';
				
				sEl.style.width	= Math.max(cW+12,((ie5)?100:104))+'px';
				sEl.style.height	= Math.max(cH+((ie5)?12:13),((ie5)?80:86))+'px';
				
				cEl.style.width	= Math.max(cW-((ie5)?-5:5),((ie5)?92:87))+'px';
				cEl.style.height	= Math.max(cH-((ie5)?24:28),44)+'px';
			}
			else
			{
				rsEl.style.top	= parseInt(rsEl.style.top)+diffH+"px"
				rsEl.style.left		= parseInt(rsEl.style.left)+diffW+"px"
			
				sEl.style.height		= parseInt(sEl.style.height)+diffH+"px"
				sEl.style.width		= parseInt(sEl.style.width)+diffW+"px"
				
				tEl.style.width		= parseInt(tEl.style.width)+diffW+"px"
				
				bEl.style.height		= parseInt(bEl.style.height)+diffH+"px"
				bEl.style.width		= parseInt(bEl.style.width)+diffW+"px"
				
				cEl.style.height		= parseInt(cEl.style.height)+diffH+"px"
				cEl.style.width		= parseInt(cEl.style.width)+diffW+"px"
			}
			
			cEl.style.overflow	= "hidden";
		
			titleEl.innerHTML = frameDoc.title;
			
			if (doShow)
				this.show(id);
		},
		
		_init: function() {
			this.w3c = gx.util.browser.w3c;
			this.ns4 = gx.util.browser.ns4;
			this.ie5 = gx.util.browser.ie5;
			this.ns6 = gx.util.browser.ns6;
			if(this.ns6)
			{
				setInterval(gx.popup.ext.movepopup.closure(gx.popup.ext),40);
			}
		}
	},
	
	_init: function() {
		this.ext._init();
		var popup = this.getPopup();
		if (popup)
		{
			try
			{
				if (popup.frameDocument)
				{
					popup.frameDocument.gxPopup = popup;
				}
			}
			catch(e)
			{
				popup.frameDocument = popup.frameWindow.document;
				gx.dbg.logEx(e, 'gxpopup.js', '_init');
			}
			var popupExt = popup.window.gx.popup;
			gx.fx.obs.addObserver( 'gx.onload', popupExt, function() { this.autofit(); }.closure(popupExt));
			gx.fx.obs.addObserver( 'grid.onafterrefresh', popupExt, function(gridObj, rows1, rows2) {
				if (rows1 < rows2)
				{
					this.autofit();
				}
			}.closure(popupExt));
			gx.fx.obs.addObserver( 'gx.onafterevent', popupExt, function(evtData) { this.autofit(); }.closure(popupExt));
		}
	}
}
/* END OF FILE - gxpopup.js - */
/* START OF FILE - gxcallrpc.js - */
gx.ajax = {
	maxGETLength: 1350,
	reqHeader: 'GxAjaxRequest',
	resourceProvider: '',
	dfTimer: null,
	
	securityLevels: {
		low: 0,
		medium: 1,
		high: 2
	},
	
	getImageUrl: function( imgId) {
		try
		{
			if (!gx.lang.emptyObject(this.resourceProvider))
			{
				var sUrl = gx.ajax.objectUrl(this.resourceProvider) + '?image,' + encodeURIComponent(imgId) + ',,' + encodeURIComponent(gx.theme);
				gx.http.callBackend( '', sUrl, ')', true, gx.http.modes.none, true, 'GET', null, true);
				return gx.util.resourceUrl(gx.basePath + gx.staticDirectory + gx.http.lastResponse, true);
			}
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxcallrpc.js', 'getImageUrl');
		}
		return imgId;
	},
	
	encryptParms: function( gxObj, parms) {
		return ((gxObj.AjaxSecurity >= gx.ajax.securityLevels.medium)?gx.sec.encrypt(parms):parms);
	},
	
	doPost: function( ParmString, Synch) {
		if (gx.evt.processing && !gx.csv.validating)
			return;
		gx.evt.setProcessing(true);
		gx.ajax.disableForm();
		gx.fx.obs.notify('gx.onbeforeevent', [ParmString, Synch]);
		gx.fn.objectOnpost();
		gx.http.saveState();
		gx.fn.forceEnableControls(false);
		var postInfo = this.getPostInfo(ParmString, Synch);
		gx.http.doCall( postInfo);
	},
	
	getPostInfo: function( ParmString, Synch) {
		var url = gx.ajax.selfUrl();
		var regExp = /\?(.*)/;
		if (regExp.test(url))
			url = url.replace(regExp,'?'+ParmString+',$1');
		else
			url+= '?'+ParmString;
		var postInfo = {};
		postInfo.url = url;
		postInfo.formNode = gx.dom.form();
		postInfo.method = 'POST';
		postInfo.encoding = 'UTF-8';
		postInfo.useCash = false;
		if (Synch == true)
			postInfo.sync = true;
		postInfo.handler = gx.http.postHandler;
		this.multipartInfo( postInfo);
		return postInfo;
	},
	
	multipartInfo: function( postInfo) {
		var hasFile = false;
		var inputs = postInfo.formNode.getElementsByTagName("input");
		var len = inputs.length;
		if (!len)
			return;
		for (var i=0; i<len; i++)
		{
			if (inputs[i].getAttribute("type")=="file")
			{
				hasFile = true;
				break;
			}
		}
		if (hasFile)
		{
			postInfo.multipart = true;
			postInfo.mimetype = "text/html";
			postInfo.formNode.encoding = "multipart/form-data";
		}
	},

	dispatchCommands: function( Commands) {
		if (Commands && Commands.length > 0)
		{
			var len = Commands.length;
			for (var i=0; i<len; i++)
			{
				var Command = Commands[i];
				if (Command.redirect != undefined)
				{
					Command.redirect = gx.ajax.removeGXParms(Command.redirect);
				}
				if (Command.print)
				{
					gx.printing.print(Command.print);
				}
				if (Command.close)
				{
					var returnParms = [];
					if (Command.close instanceof Array)
					{
						returnParms = Command.close;
					}
					gx.fn.closeWindow(returnParms);
				}
				if (typeof(Command.refresh) != 'undefined')
				{
					if (Command.refresh == 'GET')
					{
						gx.http.reload();
					}
					else
					{
						var rfrName = 'RFR';
						if (gx.O.IsMasterPage)
							rfrName = rfrName + '_MPAGE';
						gx.O.executeServerEvent( rfrName, true);
					}
				}
				if (Command.redirect)
				{
					gx.http.redirect( Command.redirect);
				}
				if (Command.popup)
				{
					if (Commands.length > i+1)
					{
						Command.popup[7] = Commands.slice(i+1);
					}
					gx.popup.open( Command.popup);
					break;
				}
				if (Command.ucmethod)
				{
					var ucgxO = gx.getObj( Command.ucmethod.CmpContext, Command.ucmethod.IsMasterPage);
					if (ucgxO)
					{
						var oldgxO = gx.O;
						gx.setGxO( ucgxO.CmpContext, ucgxO.IsMasterPage);
						var uc = gx.O.getUserControl(Command.ucmethod.Control);
						if (uc)
						{
							if (typeof(uc[Command.ucmethod.Method]) == 'function')
							{
								uc[Command.ucmethod.Method].apply(uc, Command.ucmethod.Parms);
							}
						}
						gx.setGxO( oldgxO.CmpContext, oldgxO.IsMasterPage);
					}
				}
			}
		}
	},
	
	hasRedirectCommand: function( Commands) {
		if (Commands)
		{
			var len = Commands.length;
			for (var i=0; i<len; i++)
			{
				var Command = Commands[i];
				if (Command.redirect)
					return true;
			}
		}
		return false;
	},
	
	setPostResponse: function( response) {
		var fn = gx.fn;
		var doFunc = gx.lang.doCall;
		if (this.hasRedirectCommand(response.gxCommands))
		{
			doFunc( gx.ajax.dispatchCommands, response.gxCommands);
			setTimeout( function() {
				gx.ajax.enableForm();
			}, 200);
		}
		else
		{
			doFunc( fn.setPostHiddens, response.gxHiddens);
			doFunc( fn.setPostComponents, response.gxComponents, response.DynComponentMap, function() {
				gx.http.loadStyles();
				doFunc( fn.setPostValues, response.gxValues);
				doFunc( fn.setPostProperties, response.gxProps);
				doFunc( fn.setErrorViewer, response.gxMessages);
				fn.enableDisableDelete();
				doFunc( fn.loadPostGrids, response.gxGrids);
				fn.objectPostback();
				fn.setFocusAfterLoad();
				gx.ajax.enableForm();
				gx.dom.indexElements();
				doFunc( gx.ajax.dispatchCommands, response.gxCommands);
			});
		}
	},
	
	disableForm: function() {
		if (this.dfTimer)
			clearTimeout(this.dfTimer);
		this.dfTimer = setTimeout( gx.http.notification.show,200);
	},
	
	enableForm: function() {
		if (this.dfTimer)
			clearTimeout(this.dfTimer);
		gx.http.notification.hide();
	},
	
	executeCliEvent: function( EvtName, Ctrl) {
		try
		{
			var ctrlRow = undefined;
			var eo = gx.lang.emptyObject;
			if (!eo(Ctrl))
			{
				var ctrlGrid = gx.fn.rowGridId( Ctrl);
				if (!eo(ctrlGrid))
				{
					var gridObj = gx.fn.getGridObj(ctrlGrid);
					if (!eo(gridObj))
					{
						ctrlRow = gx.fn.controlRowId( Ctrl) || gx.fn.currentGridRowImpl(ctrlGrid) || '0001';
						gridObj.instanciateRow( ctrlRow);
					}
				}
			}
			gx.O[EvtName].call(gx.O, ctrlRow);
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxcallrpc.js', 'executeCliEvent');
		}
	},
	
	suggest: function( ControlId, ControlRefresh, CtrlSvc, bTypeAhead, suggParms, sdtParms) {
		var CtrlId = ControlRefresh;
		var SuggestProvider = new gx.fx.suggestProvider( ControlId, ControlRefresh, CtrlSvc);
		var oTextbox = new gx.fx.autoSuggestControl( gx.fn.screen_CtrlRef( ControlRefresh), SuggestProvider, CtrlId, bTypeAhead, suggParms, sdtParms);
	},
	
	hideCode: function( InputParms, ControlId, ControlRefresh) {
		var backcall = "gx.fn.setVarValues(" + gx.lang.arrayToSource(ControlRefresh) + ",";
		var sURL = this.objectUrl() + '?';
		var sParms = 'gxajaxHideCode_' + ControlId;
		var len = InputParms.length;
		for (var i=0; i<len;i++)
			sParms += ',' + encodeURIComponent( eval(InputParms[i]));
		sURL += gx.ajax.encryptParms( gx.O, sParms);
		gx.http.callBackend( backcall, sURL, ')', true, gx.http.modes.retval);
		return this.lastStatus;
	},
	
	callCrl: function( ActionParameters, ControlRefresh, RefreshGrid) {
		var funcCall = RefreshGrid?"gx.fn.setGridComboValues":"gx.fn.setComboValues";
		var ctrlName = RefreshGrid?ControlRefresh:gx.fn.screen_CtrlRef( ControlRefresh).name;
		var backcall = funcCall + "('" + ctrlName + "',";
		var sURL = this.objectUrl() + '?';
		var sParms = 'gxajaxCallCrl_' + ControlRefresh + ",";
		sParms += this.arrayToUrl( ActionParameters);
		sURL += gx.ajax.encryptParms( gx.O, sParms);
		gx.http.callBackend( backcall, sURL, ')', true, gx.http.modes.retval);
	},
	
	refreshGrid: function( GxGrid, refreshParms) {
		var backcall = "";
		var sURL = this.objectUrl() + '?';
		var sParms = 'gxajaxGridRefresh_' + GxGrid.gridName + ',' + refreshParms;
		sURL += gx.ajax.encryptParms( gx.O, sParms);
		gx.http.callBackend( backcall, sURL, ')', false, gx.http.modes.none);
		var response = gx.http.lastResponse;
		if ((response != undefined) && (response != ""))
		{
			var refreshInfo = gx.json.evalJSON( response);
			GxGrid.loadAfterRefresh(refreshInfo);
			GxGrid.updatePropsHidden(response);
		}
	},
	
	newRows: function( CmpCtx, InMasterPage, GridName, gxRows, gxRowIndex, gxRowId, gxParentRow, gHandler) {
		var backcall = "gx.fn.gridObj('" + CmpCtx + "','" + GridName + "'," + InMasterPage.toString() + "').setNewRows(";
		var sURL = this.objectUrl() + '?';
		var sParms = 'gxajaxNewRow_' + GridName + ',' + gxRows + ',' + gxRowIndex + ',' + gxRowId;
		var GridName = (gxParentRow != '')?(GridName+'_'+gxParentRow):GridName;		
		var gridObj = gx.fn.gridObj(CmpCtx, GridName, InMasterPage);
	  
		for (var i=0;i< gridObj.postingVariables.length; i++)
		{
			sParms+= "," + encodeURIComponent(gridObj.parentObject[gridObj.postingVariables[i]]); 
		}		
		if (gx.O.IsComponent)
			sParms += ',' + gx.O.CmpContext;
		sURL += gx.ajax.encryptParms( gx.O, sParms);
		gx.http.callBackend( backcall, sURL, ')', true, gx.http.modes.none);
		var response = gx.http.lastResponse;
		if (response)
		{
			var newRowsInfo = gx.json.evalJSON( response);
			gHandler.call( gridObj, newRowsInfo);
		}
	},
	
	loadCrl: function( GXAction, ActionParameters, ActionResults) {
		if (gx.fn.getControlValue( "IsConfirmed") == "1")
		{
			this.lastStatus = 0;
			return;
		}
		var backcall = "gx.fn.setVarValues(" + gx.lang.arrayToSource(ActionResults) + ",";
		var sURL = this.objectUrl() + '?';
		var sParms = 'gxajaxExecAct_' + GXAction + ',';
		sParms += this.arrayToUrl( ActionParameters);
		sURL += gx.ajax.encryptParms( gx.O, sParms);
		gx.http.callBackend( backcall, sURL, ')', true, gx.http.modes.retval);
	},
	
	udp: function( GXAction, InputParameters, OutputParameters) {
		var backcall = "gx.fn.setVarValues(" + gx.lang.arrayToSource(OutputParameters) + ",";
		var sURL = this.objectUrl() + '?';
		var sParms = GXAction + ',';
		sParms += this.arrayToUrl( InputParameters);
		sURL += gx.ajax.encryptParms( gx.O, sParms);
		gx.http.callBackend( backcall, sURL, ')', true, gx.http.modes.retval);
	},
	
	srvEvt: function( GXEvent, GXAction, InputParameters, OutputParameters) {
		var backcall = "gx.fn.setVarValues(" + gx.lang.arrayToSource(OutputParameters) + ",";
		var sURL = this.objectUrl() + '?';
		var sParms = GXEvent + ','+ GXAction + ',';
		sParms += this.arrayToUrl( InputParameters);
		sURL += gx.ajax.encryptParms( gx.O, sParms);
		gx.http.callBackend( backcall, sURL, ')', true, gx.http.modes.full);
	},
	
	validSrvEvt: function( GXEvent, GXAction, InputParameters, OutputParameters) {
		var backcall = "gx.csv.setValidValues(" + gx.lang.arrayToSource(OutputParameters) + ",";
		var sURL = this.objectUrl();
		var sParms =  GXEvent + ','+ GXAction + ',' + this.arrayToUrl( InputParameters, true);
		if (sParms.length > this.maxGETLength)
		{
			this.validAsPost( sURL, backcall, GXEvent, GXAction, InputParameters);
		}
		else
		{
			sParms = gx.ajax.encryptParms( gx.O, sParms);
			if (sParms.length > this.maxGETLength)
			{
				this.validAsPost( sURL, backcall, GXEvent, GXAction, InputParameters);
			}
			else
			{
				sURL += '?' + sParms;
				gx.http.callBackend( backcall, sURL, ')', true, gx.http.modes.call);
			}
		}
	},

	validAsPost: function( sURL, backcall, GXEvent, GXAction, InputParameters) {
		var postData = 'GXEvent=' + gx.ajax.encryptParms(gx.O, GXEvent) + '&GXAction=' + GXAction;
		if (InputParameters.length > 0)
		{
			postData += '&' + this.getParmsPostData(InputParameters);
		}
		gx.http.callBackend( backcall, sURL, ')', true, gx.http.modes.call, false, 'POST', postData);
	},
	
	getParmsPostData: function( Parms) {
		var sURL = '';
		for (var i=0; i<Parms.length;i++)
		{
			if (i > 0)
				sURL += '&';
			sURL +=  'GXParm' + i + '=' + this.parmToUrl(Parms[i], true);
		}
		return sURL;
	},
	
	pushReferer: function( PopupLevel) {
		var sURL = this.objectUrl() + '?';
		var sParms = "dyncall,PushReferer," + encodeURIComponent(location.href);
		sURL += gx.ajax.encryptParms( gx.O, sParms);
		gx.http.callBackend( '', sURL, '', true, gx.http.modes.none, true);
	},
	
	windowClosed: function( PopupLevel) {
		var serverFunc = '';
		if (PopupLevel == -1)
			serverFunc = ',PopReferer';
		else
			serverFunc = ',DeleteReferer,' + PopupLevel.toString();
		var sURL = this.objectUrl() + '?';
		var sParms = "dyncall" + serverFunc;
		sURL += gx.ajax.encryptParms( gx.O, sParms);
		gx.http.callBackend( '', sURL, '', true, gx.http.modes.none, true);
	},
	
	aggSel: function( ControlId, Act, ActionParameters) {
		var sURL = this.objectUrl() + '?';
		var sParms = 'gxajaxAggSel'+Act+'_' + ControlId + ",";
		sParms += this.arrayToUrl( ActionParameters);
		sURL += gx.ajax.encryptParms( gx.O, sParms);
		var res = gx.http.callBackend( null, sURL, '', false, gx.http.modes.retval);
		return res[0];
	},
	
	aggSelDecimal: function( ControlId, Act, ThSep, DecPoint, ActionParameters) {
		return gx.num.parseFloat( this.aggSel( ControlId, Act, ActionParameters), ThSep, DecPoint);
	},
	
	aggSelInteger: function( ControlId, Act, ActionParameters) {
		return parseInt( this.aggSel( ControlId, Act, ActionParameters), 10);
	},
	
	dynComponent: function( Name, Parms, Prefix, Row) {
		Name = Name.toLowerCase();
		var fullName = Name;
		if (gx.gen.isDotNet())
			fullName += '.aspx';
		var sURL = gx.ajax.objectUrl(fullName) + '?';
		var sParms = 'dyncomponent' + ',' + encodeURIComponent(Prefix) + ',' + encodeURIComponent(Row);
		var len = Parms.length;
		for (var i=0; i<len;i++)
			sParms += ',' + encodeURIComponent( Parms[i]);
		sURL += gx.ajax.encryptParms( gx.O, sParms);
		gx.http.callBackend( '', sURL, ')', true, gx.http.modes.none, true);
		return gx.json.evalJSON(gx.http.lastResponse);
	},

	selfUrl: function() {
		return location.href.replace( /#[\s\S]*$/,'');
	},

	removeGXParms: function( url) {
		return url.replace(/\?gxajaxEvt,?|\?gxportlet,?/,'?');
	},
	
	arrayToUrl: function( Parameters, serializeControls) {
		var sURL = '';
		var len = Parameters.length;
		for (var i=0; i<len;i++)
		{
			sURL += this.parmToUrl(Parameters[i], serializeControls) + ',';
		}
		return sURL;
	},
	
	parmToUrl: function( Parm, serializeControls) {
		var value = eval( Parm);
		if (value instanceof Array && value.length == 2 && typeof(value[0]) == 'string' && typeof(value[1]) == 'string') // Property
		{
			var validStruct = gx.fn.vStructForVar(value[0]);
			if(validStruct != null)
			{
				value = gx.fn.getGridCtrlProperty( validStruct.grid, validStruct.fld, value[1]);
			}
		}
		if (serializeControls)
		{
			var vStruct = gx.fn.vStructForVar(gx.unprefixVar(Parm));
			if(vStruct != null)
			{
				if (gx.html.controls.isMultiSelection(vStruct.ctrltype))
				{
					var ctrl = gx.fn.getControlGridRef( vStruct.fld, vStruct.grid);
					if (ctrl)
					{
						var ctrlJSON = gx.dom.controlToObj(ctrl);
						if (ctrlJSON)
						{
							value = ctrlJSON;
						}
					}
				}
			}
		}
		if (typeof(value) == 'object')
		{
			value = gx.json.serializeJson(value);
		}
		if (typeof(value) == 'undefined' || value == null)
		{
			var setted = false;
			if (Parm)
			{
				var gxoIdx = Parm.indexOf('gx.O.');
				if (gxoIdx == 0)
				{
					Parm = gx.unprefixVar(Parm);
					var hidVal = gx.fn.getHidden(gx.O.CmpContext + Parm);
					if (hidVal != null && typeof(hidVal) != 'undefined')
					{
						value = hidVal;
						setted = true;
					}
				}
			}
			if (!setted)
			{
				value = '';
			}
		}
		return encodeURIComponent(value);
	},
	
	objectUrl: function( Obj) {
		var pathname = location.pathname;
		var ObjUrl = '';
		if (Obj != undefined)
			ObjUrl = Obj;
		else
		{
			if (gx.csv.cmpCtx != '')
				ObjUrl = gx.fn.getControlValue( gx.csv.cmpCtx + '_CMPPGM');
	    else        
				ObjUrl = gx.ajax.selfUrl();	
			if (ObjUrl != null)
			{
			  ObjUrl = ObjUrl.replace( /\?.*/,'');
			  ObjUrl = ObjUrl.replace( /#[\s\S]*$/,'');
			}
			ObjUrl = this.objnameFromUrl( ObjUrl);
		}
		return this.absoluteurl( this.objToRelativeUrl(ObjUrl));
	},
	
	objToRelativeUrl: function(ObjName){
	    var pathname = location.pathname;
		if (ObjName != null)
		{
			var parts = location.pathname.split('/');
			pathname = '';
			var len = parts.length;
			for (var i=1;i<len-1;i++)
				pathname += '/' + parts[i];
			pathname += '/' + ObjName;
		}
		return pathname;
	},

	isabsoluteurl: function( url) {
	    return (url.search('://') != -1)
	},

	absoluteurl: function( url) {
	    if (!this.isabsoluteurl(url))
	    {
			var query = '';
			var objUrl = url;
			var qIdx = url.indexOf('?');
			if (qIdx > 0)
			{
				objUrl = url.substring(0, qIdx);
				query = url.substring(qIdx);
			}
	        if (objUrl.indexOf('/') == -1)
	        {
			    objUrl = this.objToRelativeUrl(objUrl);
	        }
	        if (!gx.lang.emptyObject(gx.basePath) && objUrl.indexOf(gx.basePath)==-1)
	        {
				var urlPath = objUrl.split('/');
				var basePath = gx.basePath.split('/');    
				var lenBase = basePath.length;
				var lenUrl = urlPath.length;
				var path = '';
				for (var i=0; i<lenBase; i++)
				{
					if (basePath[i]!='')
					{
						if (!gx.util.inArray(basePath[i],urlPath))
							path = path + '/' + basePath[i];
						else
							break;
					}
				}
				if (path.charAt(0) != '/')
				{
					path = '/' + path;
				}
				if (objUrl.charAt(0) != '/' && path.charAt(path.length-1) != '/')
				{
					path = path + '/';
				}
				return location.protocol + '//' + location.host + path + objUrl + query;
			}
			else
			{
				if (objUrl.charAt(0) != '/')
				{
					objUrl = '/' + objUrl;
				}
				return location.protocol + '//' + location.host + objUrl + query;
			}
	    }
	    return url;
	},
	
	objnameFromUrl: function( url) {
		if (url.indexOf('?')>=0)
			url = url.split('?')[0];
	    var parts = url.split('/');
	    var len = parts.length;
	    if (len == 0)
	        return url;
	    return parts[len-1];
	},
	
	_init: function() {
		this.resourceProvider = gx.fn.getHidden('GX_RES_PROVIDER');
	}
};
/* END OF FILE - gxcallrpc.js - */
/* START OF FILE - gxballoon.js - */
gx.util.balloon = {
	balloons: [],
	timerOn: false,
	
	impl: function() {
		this.init = function( id)
		{
			this.hide();
			this.id = id;	
			this.balloonid = id + "_Balloon";
			this.hasMessage = false;
			this.messageErr = '';
			this.messageWar = '';
			this.isError = false;
		}
		
		this.setMessage = function(message)
		{
			this.messageWar += message+'<BR>';
			this.hasMessage = true;
		}
	
		this.setError = function(message)
		{
			this.messageErr += message+'<BR>';
			this.isError = true;
			this.hasMessage = true;
		}
	
		this.show = function()
		{
			if (document.readyState != undefined && document.readyState != 'complete')
				return;
			try
			{
				if (this.hasMessage == false)
					return true;
				var BalloonControl = gx.dom.el( this.balloonid);
				var Control = gx.dom.el( this.id);
				if ((Control == null) && (gx.csv.validatingUC != null))
					Control = gx.csv.validatingUC.getContainerControl();
				if(Control.type == 'hidden')
				{
					var spanControl = gx.dom.el( 'span_' + this.id);
					if(spanControl != null)
						Control = spanControl;
				}
				if (BalloonControl == null)
				{
					BalloonControl = document.createElement("SPAN");
					BalloonControlShadow = document.createElement("SPAN");
					BalloonControlShadow2 = document.createElement("SPAN");
					IFrameControl = document.createElement("IFRAME");
					BalloonControl.id = this.balloonid;
					BalloonControlShadow.id = this.balloonid + "Shadow";
					BalloonControlShadow2.id = this.balloonid + "Shadow2";
					IFrameControl.id= this.balloonid + "GXiFrameIEHack";
					IFrameControl.src = "javascript:undefined";
					IFrameControl.style.zIndex = 1;
					IFrameControl.style.visibility = "hidden";
					IFrameControl.style.position = "absolute";
					IFrameControl.frameBorder= "0";
				
					document.body.appendChild( BalloonControl);
					document.body.appendChild( BalloonControlShadow);
					document.body.appendChild( BalloonControlShadow2);
					document.body.appendChild( IFrameControl);
					
				}
				var Coord = gx.dom.position( Control);
				if (Coord.x == 0 && Coord.y == 0 && Control.parentNode)
					Coord = gx.dom.position( Control.parentNode);
				var CoordLeft = parseInt(Coord.x);
				var CoordTop = parseInt(Coord.y);
				
				if (CoordLeft <= 0)
					CoordLeft = 10;
				if (CoordTop <= 0)
					CoordTop = 20;
				
				var sHTML = "<span style='white-space:nowrap;position: absolute; top:" +  CoordTop + "px; left:" + CoordLeft + "px;z-index:1003' >"
				if (this.messageErr.length > 0)
				{
					sHTML += "<div class='ErrorMessages'>";
					sHTML += this.messageErr;
					sHTML +="</div><span style='height:4px;overflow:hidden'></span>";
				}
				if (this.messageWar.length > 0)
				{
					sHTML += "<div class='WarningMessages'>";
					sHTML += this.messageWar;
					sHTML +="</div>";
				}
				sHTML +="</span>";
	
				BalloonControl.innerHTML = sHTML;
				
				var shadowWidth = 2;
				
				CoordTop -= BalloonControl.lastChild.offsetHeight - shadowWidth;
				
				sHTML = "<span style='white-space:nowrap;position: absolute; top:" +  CoordTop + "px; left:" + CoordLeft + "px;z-index:1003' >"
				if (this.messageErr.length > 0)
				{
					sHTML += "<div class='ErrorMessages'>";
					sHTML += this.messageErr;
					sHTML +="</div><span style='height:4px;overflow:hidden'></span>";
				}
				if (this.messageWar.length > 0)
				{
					sHTML += "<div class='WarningMessages'>";
					sHTML += this.messageWar;
					sHTML +="</div>";
				}
				sHTML +="</span>";
	
				BalloonControl.innerHTML = sHTML;
				
				IFrameControl.style.visibility = "visible";		
				IFrameControl.style.height = BalloonControl.firstChild.firstChild.offsetHeight;
				IFrameControl.style.width = BalloonControl.lastChild.offsetWidth;
				IFrameControl.style.top	= CoordTop;
				IFrameControl.style.left = CoordLeft;
				
				CoordTop += shadowWidth;
				CoordLeft += shadowWidth;
				
				if (this.messageErr.length > 0)
				{
					sHTML ="<span style='position: absolute;border-style:none;";
					sHTML += "top:" +  CoordTop + "px; left:" + CoordLeft + "px;";
					sHTML += "width:" + BalloonControl.lastChild.offsetWidth + "px;" + " height:" + BalloonControl.firstChild.firstChild.offsetHeight + "px;";  
					sHTML += "z-index:1002;background-color:ThreeDDarkShadow;' class='ErrorMessages'></span>";
					BalloonControlShadow.innerHTML = sHTML;
					CoordTop += BalloonControl.firstChild.firstChild.offsetHeight + 4;
				}
	
				if (this.messageWar.length > 0)
				{
					sHTML ="<span style='position: absolute;border-style:none;";
					sHTML += "top:" +  CoordTop + "px; left:" + CoordLeft + "px;";
					sHTML += "width:" + BalloonControl.lastChild.offsetWidth + "px;" + " height:" + BalloonControl.firstChild.lastChild.offsetHeight + "px;";  
					sHTML += "z-index:1002;background-color:ThreeDDarkShadow;' class='ErrorMessages'></span>";
					BalloonControlShadow2.innerHTML = sHTML;
				}
				
				if (gx.util.balloon.timerOn == false)
				{
					gx.util.balloon.timerOn = true;
					this.timerId = setTimeout( function() {gx.util.balloon.hideOnTime();}, 4000);
				}
			}
			catch (E)
			{
				gx.dbg.logEx(E, 'gxballoon.js', 'show');
			}
			return !this.isError;
		}
	
		this.hide = function()
		{
			try
			{
				ctrl = gx.dom.byId( this.balloonid+"Shadow");
				if (ctrl != null)
					gx.dom.removeControl( ctrl);
				ctrl = gx.dom.byId( this.balloonid+"Shadow2");
				if (ctrl != null)
					gx.dom.removeControl( ctrl);
				ctrl = gx.dom.byId( this.balloonid);
				if (ctrl != null)
					gx.dom.removeControl( ctrl);
				ctrl = gx.dom.byId( this.balloonid + "GXiFrameIEHack");
				if (ctrl != null)
					gx.dom.removeControl( ctrl);
			}
			catch (e)
			{
				gx.dbg.logEx(e, 'gxballoon.js', 'hide');
			}
		}
	},
	
	hideOnTime: function() {
		this.timerOn = false;
		while (DelBalloon = this.balloons.pop())
			DelBalloon.hide();
	},

	getNew: function(Id, RowId) {
		if (typeof(RowId) != 'undefined')
			Id = Id + '_' + RowId;
		try
		{
			Id = gx.csv.ctxControlId( gx.fn.screen_CtrlRef( Id).id);
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxballoon.js', 'getNew');
		}
		var b = new this.impl();
		this.balloons.push(b);
		b.init(Id);
		return b;
	}
};
/* END OF FILE - gxballoon.js - */
/* START OF FILE - gxgrid.js - */
gx.grid = {
	drawAtServer: false,
	
	deleteMethods: {
		images: 0,
		menu: 1,
		none: 2
	},
	
	deletePositions: {
		left: 0,
		right: 1,
		bottomR: 2,
		bottomL: 3,
		topR: 4,
		topL: 5
	},
	
	deleteMethod: null,
	deleteImage: null,
	undeleteImage: null,
	deletePosition: null,
	deletePositionFree: null,
	deleteTooltip: null,
	deleteTitle: null,
	lastFocusCtrl: null,

	styles: {
		none: 0,
		uniform: 1,
		header: 2,
		report: 3
	},
	
	getImplClass: function( gridObj, implClass) {
		if (implClass)
		{
			gx.lang.inherits( gx.ui.grid, gx.uc.UserControl);
			gx.lang.inherits( gx.ui.grid, gx.grid.impl);
			gx.lang.inherits( implClass, gx.ui.grid);
			var implObj = new implClass();
			if (gridObj)
			{
				implObj.ParentObject = gridObj.parentObject;
				implObj.ControlName = gridObj.gridName;
				gridObj.parentObject.setUserControl( implObj);
			}
			return implObj;
		}
		return new gx.grid.impl('gx');
	},

	grid: function( parentObj, gLvl, gLvlName, gId, gName, rgName, cName, gCmpCtx, gIsInMaster, pName, gKey, gFreestyle, gCols, aSelect, aHover, gRows, gPaging, gDragable, gSetsCtx, gBondColl, gWidth, gWidthUnit, newRowtext, pageSizeParm, gHasAddlines, gHasFEL, gImplClass, gOnLineActEvt, aCollap, gBondCollName) {
		this.parentObject = parentObj;
		this.gridLvl = gLvl;
		this.gridLvlName = gLvlName;
		this.gridId = gId;
		this.gridName = gName;
		this.realGridName = rgName;
		this.containerName = cName || this.gridName + "Container";
		this.parentName = pName || "";
		this.pagingParms = [];
		this.lvlKey = gKey || [];
		this.isFreestyle = gFreestyle || false;
		this.allowSelection = aSelect || false;
		this.allowHovering = aHover || false;
		this.allowCollapsing = aCollap || false;
		this.collapsed = false;
		this.sortable = true;
		this.selectionColor = null;
		this.hoverColor = null;
		this.visible = true;
		this.refreshTimer = null;
		this.pageSizeParm = pageSizeParm || false;
		this.hasAddlines = gHasAddlines || false;
		this.hasForEachLine = gHasFEL || false;
		this.width = (gWidth != undefined)?gWidth:0;
		this.widthUnit = gWidthUnit || '';
		this.gridCols = (gCols != undefined)?gCols:1;
		this.gridCols = (this.gridCols != 0)?this.gridCols:9999;
		this.gridRows = (gRows != undefined)?gRows:5;
		this.usePaging = gPaging || false;
		this.usePaging = this.usePaging && !this.isFreestyle;
		this.eof = 1;
		this.firstRecordOnPage = 0;
		this.defaultDragable = gDragable || false;
		this.defaultSetsContext = gSetsCtx || false;
		this.boundedCollType = gBondColl || '';
		this.boundedCollName = gBondCollName || '';
		this.contextMenu = null;
		this.gxContainerCtrl = null;
		this.lastRefreshParms = "";
		this.gxComponentContext = gCmpCtx;
		this.isMasterPageGrid = gIsInMaster;
		this.htmlTags = "";
		this.onLineActivate = gOnLineActEvt;
		this.addingRows = false;
		this.deleteMethod = gx.grid.deleteMethod;
		this.DatePickersControls = [];
		this.GridUserControls = [];
		this.GridComponents = [];
		this.implClass = gImplClass;
		this.grid = gx.grid.getImplClass(this, gImplClass);
		this.grid.ownerGrid = this;
		this.grid.parentGxObject = this.parentObject;
		this.grid.gxLvl = this.gridLvl;
		this.grid.gxId = this.gridId;
		this.grid.gxGridName = this.gridName;
		this.grid.gxGridObject = this.containerName;
		this.grid.gxParentName = this.parentName;
		this.grid.gxIsFreestyle = this.isFreestyle;
		this.grid.gxWidth = this.width;
		this.grid.gxWidthUnit = this.widthUnit;
		this.grid.gxHeight = 0;
		this.grid.gxAllowSelection = this.allowSelection;
		this.grid.gxAllowHovering = this.allowHovering;
		this.grid.gxAllowCollapsing = this.allowCollapsing;
		this.grid.gxCollapsed = this.collapsed;
		this.grid.gxSortable = this.sortable;
		this.grid.gxSelectionColor = this.selectionColor;
		this.grid.gxHoverColor = this.hoverColor;
		this.grid.gxVisible = this.visible;
		this.grid.gxGridCols = this.gridCols;
		this.grid.gxCmpContext = this.gxComponentContext;
		this.grid.gxHtmlTags = this.htmlTags;
		this.grid.gxIsMasterPageGrid = this.isMasterPageGrid;
		this.grid.gxDragable = this.defaultDragable;
		this.grid.gxHasAddlines = this.hasAddlines;
		this.grid.gxHasForEachLine = this.hasForEachLine;
		this.grid.gxOnLineActivate = this.onLineActivate;
		this.grid.gxNewRowText = (newRowtext != undefined)?newRowtext:"New Row";
		this.currentBuffer = this.grid.gxBuffer;
		this.parentGrid = null;
		this.childGrids = [];
		this.hiddens = [];
		this.oldCmps = {};
		this.isUsercontrol = gx.lang.instanceOf( this.grid, gx.uc.UserControl);
		var oThis = this;
		this.gxCreateGridCode = function(pRowId) { return new gx.grid.grid(oThis.parentObject, oThis.gridLvl,oThis.gridLvlName,oThis.gridId,oThis.gridName + '_' + pRowId,oThis.gridName,oThis.containerName + '_' + pRowId,oThis.gxComponentContext,oThis.isMasterPageGrid,oThis.parentName,oThis.lvlKey,oThis.isFreestyle,oThis.gridCols,oThis.allowSelection,oThis.allowHovering,oThis.gridRows,oThis.usePaging,oThis.defaulDragable,oThis.defaulSetsContext,oThis.boundedCollType,oThis.width,oThis.widthUnit,oThis.grid.gxNewRowText,oThis.pageSizeParm,oThis.hasAddlines,oThis.hasForEachLine,oThis.implClass,oThis.onLineActivate,oThis.allowCollapsing);};
		this.gxAddColumnsCode = [];
		this.grid.usePaging = this.usePaging;
		this.grid.eof = this.eof;
		this.grid.firstRecordOnPage = this.firstRecordOnPage;
		this.postingVariables = [];
	  
		this.addColumnDinCode = function( func, args)
		{
			this.gxAddColumnsCode.push(function() {func.apply(this, args);});
		}
		
		this.addSingleLineEdit = function( colAttId, colId, colHtmlName, colTitle, colTooltip, colAttName, colType, colWidth, colWidthUnit, colMLength, colSize, colAlign, hasClick, suggestInfo, hcAttId, hcAttName, colVisible, colDecimals, setCtx, isPassword)
		{
			this.addColumnDinCode( this.addSingleLineEdit, arguments);
			var newCol = this.newColumn( colTitle, colType, colAlign, colWidth);
			newCol.visible = colVisible;
			newCol.htmlName = colHtmlName;
			newCol.gxId = colId;
			newCol.gxAttId = colAttId;
			newCol.gxAttName = colAttName;
			newCol.gxTooltip = colTooltip;
			newCol.gxWidthUnit = colWidthUnit;
			newCol.gxSetsContext = setCtx;
			newCol.gxControl = new gx.html.controls.singleLineEdit();
			newCol.gxControl.column = newCol;
			newCol.gxControl.isPassword = isPassword;
			newCol.gxControl.visible = newCol.visible;
			newCol.gxControl.dataType = newCol.type;
			this.grid.addColumn(newCol);
		}
		
		this.addPostingVar = function(varName)
		{
			this.postingVariables.push(varName);
		}
		
		this.addMultipleLineEdit = function( colAttId, colId, colHtmlName, colTitle, colAttName, colType, colWidth, colWidthUnit, colHeight, colHeightUnit, colMLength, colSize, colAlign, hasClick, colVisible, setCtx, colFormat)
		{
			this.addColumnDinCode( this.addMultipleLineEdit, arguments);
			var newCol = this.newColumn( colTitle, colType, colAlign, colWidth);
			newCol.visible = colVisible;
			newCol.htmlName = colHtmlName;
			newCol.gxId = colId;
			newCol.gxAttId = colAttId;
			newCol.gxAttName = colAttName;
			newCol.gxWidthUnit = colWidthUnit;
			newCol.gxSetsContext = setCtx;
			newCol.gxControl = new gx.html.controls.multipleLineEdit();
			newCol.gxControl.column = newCol;
			newCol.gxControl.dataType = newCol.type;
			newCol.gxControl.visible = newCol.visible;
			this.grid.addColumn(newCol);
		}
		
		this.addBlob = function( colAttId, colId, colHtmlName, colTitle, colAttName, colType, bDisplay, cHeight, cWidth, cHUnit, cWUnit, colVisible, setCtx)
		{
			this.addColumnDinCode( this.addBlob, arguments);
			var newCol = this.newColumn( colTitle, colType, "left", cWidth);
			newCol.visible = colVisible;
			newCol.htmlName = colHtmlName;
			newCol.gxId = colId;
			newCol.gxAttId = colAttId;
			newCol.gxAttName = colAttName;
			newCol.gxWidthUnit = cWUnit;
			newCol.gxSetsContext = setCtx;
			newCol.gxControl = new gx.html.controls.blob();
			newCol.gxControl.column = newCol;
			newCol.gxControl.dataType = newCol.type;
			newCol.gxControl.visible = newCol.visible;
			newCol.gxControl.height = cHeight;
			newCol.gxControl.width = cWidth;
			this.grid.addColumn(newCol);
		}
		
		this.addRadioButton = function( colAttId, colId, colHtmlName, colTitle, colAttName, colType, hasClick, colVertical, colVisible, setCtx)
		{
			this.addColumnDinCode( this.addRadioButton, arguments);
			var newCol = this.newColumn( colTitle, colType, "left", '');
			newCol.visible = colVisible;
			newCol.htmlName = colHtmlName;
			newCol.gxId = colId;
			newCol.gxAttId = colAttId;
			newCol.gxAttName = colAttName;
			newCol.gxSetsContext = setCtx;
			newCol.gxControl = new gx.html.controls.radio();
			newCol.gxControl.column = newCol;
			newCol.gxControl.dataType = newCol.type;
			newCol.gxControl.vertical = colVertical;
			newCol.gxControl.visible = newCol.visible;
			this.grid.addColumn(newCol);
		}
		
		this.addComboBox = function( colAttId, colId, colHtmlName, colTitle, colAttName, colType, hasClick, rtEnabled, colVisible, setCtx, colWidth, colWidthUnit)
		{
			this.addColumnDinCode( this.addComboBox, arguments);
			var newCol = this.newColumn( colTitle, colType, "left", colWidth);
			newCol.visible = colVisible;
			newCol.htmlName = colHtmlName;
			newCol.gxId = colId;
			newCol.gxAttId = colAttId;
			newCol.gxAttName = colAttName;
			newCol.gxSetsContext = setCtx;
			newCol.gxWidthUnit = colWidthUnit;
			newCol.gxControl = new gx.html.controls.comboBox();
			newCol.gxControl.column = newCol;
			newCol.gxControl.dataType = newCol.type;
			newCol.gxControl.rtEnabled = (rtEnabled == 1);
			newCol.gxControl.visible = newCol.visible;
			this.grid.addColumn(newCol);
		}
		
		this.addListBox = function( colAttId, colId, colHtmlName, colTitle, colAttName, colType, hasClick, rtEnabled, colVisible, setCtx, colWidth, colWidthUnit, colRows)
		{
			this.addColumnDinCode( this.addListBox, arguments);
			var newCol = this.newColumn( colTitle, colType, "left", colWidth);
			newCol.visible = colVisible;
			newCol.htmlName = colHtmlName;
			newCol.gxId = colId;
			newCol.gxAttId = colAttId;
			newCol.gxAttName = colAttName;
			newCol.gxSetsContext = setCtx;
			newCol.gxWidthUnit = colWidthUnit;
			newCol.gxControl = new gx.html.controls.listBox();
			newCol.gxControl.column = newCol;
			newCol.gxControl.dataType = newCol.type;
			newCol.gxControl.rows = (typeof(colRows) != 'undefined')?colRows:4;
			newCol.gxControl.rtEnabled = (rtEnabled == 1);
			newCol.gxControl.visible = newCol.visible;
			this.grid.addColumn(newCol);
		}
		                         
		this.addCheckBox = function( colAttId, colId, colHtmlName, colTitle, colCaption, colAttName, colType, checkedVal, unCheckedVal, hasClick, colVisible, setCtx, colWidth, colWidthUnit)
		{
			this.addColumnDinCode( this.addCheckBox, arguments);
			var newCol = this.newColumn( colTitle, colType, "left", colWidth);
			newCol.visible = colVisible;
			newCol.htmlName = colHtmlName;
			newCol.gxId = colId;
			newCol.gxAttId = colAttId;
			newCol.gxAttName = colAttName;
			newCol.gxChecked = checkedVal;
			newCol.gxUnChecked = unCheckedVal;
			newCol.gxSetsContext = setCtx;
			newCol.gxWidthUnit = colWidthUnit;
			newCol.gxControl = new gx.html.controls.checkBox();
			newCol.gxControl.column = newCol;
			newCol.gxControl.checkedValue = checkedVal;
	    		newCol.gxControl.uncheckedValue = unCheckedVal;
			newCol.gxControl.dataType = newCol.type;
			newCol.gxControl.visible = newCol.visible;
			this.grid.addColumn(newCol);
		}
		                         
		this.addBitmap = function( colAttId, colHtmlName, colId, colWidth, colWidthUnit, colHeight, colHeightUnit, hasClick, jsCode, colTitle)
		{
			this.addColumnDinCode( this.addBitmap, arguments);
			var newCol = this.newColumn( colTitle, "", "left", colWidth);
			newCol.htmlName = colHtmlName;
			newCol.gxId = colId;
			newCol.gxAttId = colAttId;
			newCol.gxWidthUnit = colWidthUnit;
			newCol.gxControl = new gx.html.controls.image();
			newCol.gxControl.column = newCol;
			newCol.gxControl.dataType = newCol.type;
			newCol.gxControl.width = colWidth;
			newCol.gxControl.widthUnit = colWidthUnit;
			newCol.gxControl.height = colHeight;
			newCol.gxControl.heightUnit = colHeightUnit;
			this.grid.addColumn(newCol);
		}
		
		this.addTextBlock = function( colHtmlName, hasClick)
		{
			this.addColumnDinCode( this.addTextBlock, arguments);
			var newCol = this.newColumn( "", "", "left");
			newCol.htmlName = colHtmlName;
			newCol.gxControl = new gx.html.controls.textBlock();
			newCol.gxControl.column = newCol;
			newCol.gxControl.dataType = newCol.type;
			this.grid.addColumn(newCol);
		}
		
		this.addButton = function( ControlId, HtmlName, BorderStyle, GxEvent, EventName)
		{
			this.addColumnDinCode( this.addButton, arguments);
			var newCol = this.newColumn( "", "", "left");
			newCol.htmlName = HtmlName;
			newCol.gxId = ControlId;
			newCol.gxControl = new gx.html.controls.button();
			newCol.gxControl.column = newCol;
			newCol.gxControl.dataType = newCol.type;
			this.grid.addColumn(newCol);
		}
		
		this.addGrid = function( GridCtrl)
		{
			this.addColumnDinCode( this.addGrid, arguments);
			this.childGrids.push(GridCtrl);
			var newCol = this.newColumn( "", "", "left");
			newCol.gxControl = new gx.html.controls.grid();
			newCol.gxControl.column = newCol;
			this.grid.addColumn(newCol);
		}
		
		this.addUsercontrol = function( ControlId, LastId, ClassName, ContainerName, ControlName, ShowFunc, C2VFuncs, V2CFuncs)
		{
			this.addColumnDinCode( this.addUsercontrol, arguments);
			var newCol = this.newColumn( "", "", "left");
			newCol.gxUCId = ControlId;
			newCol.gxUCLastId = LastId;
			newCol.gxUCClassName = ClassName;
			newCol.gxUCContainerName = ContainerName;
			newCol.gxUCControlName = ControlName;
			newCol.gxShowFunc = ShowFunc;
			newCol.gxC2VFuncs = C2VFuncs;
			newCol.gxV2CFuncs = V2CFuncs;
			newCol.gxControl = new gx.html.controls.userControl();
			newCol.gxControl.column = newCol;
			newCol.gxControl.dataType = newCol.type;
			this.grid.addColumn(newCol);
		}
		
		this.startContainer = function()
		{
			this.addColumnDinCode( this.startContainer, arguments);
			var newCol = this.newColumn( "", "", "left");
			newCol.gxControl = new gx.html.controls.userControlContainer();
			newCol.gxControl.column = newCol;
			newCol.gxControl.dataType = newCol.type;
			this.grid.addColumn(newCol);
		}
		
		this.endContainer = function()
		{
			this.addColumnDinCode( this.endContainer, arguments);
			this.currentBuffer.append("</div>");
		}
		
		this.addWebComponent = function( ControlName)
		{
			this.addColumnDinCode( this.addWebComponent, arguments);
			var newCol = this.newColumn( "", "", "left");
			newCol.gxControl = new gx.html.controls.webComponent();
			newCol.gxControl.column = newCol;
			newCol.gxControl.dataType = newCol.type;
			this.grid.addColumn(newCol);
		}
		
		this.addEmbeddedPage = function( ControlName)
		{
			this.addColumnDinCode( this.addEmbeddedPage, arguments);
			var newCol = this.newColumn( "", "", "left");
			newCol.gxControl = new gx.html.controls.embeddedPage();
			newCol.gxControl.column = newCol;
			newCol.gxControl.dataType = newCol.type;
			this.grid.addColumn(newCol);
		} 
		
		this.addHtmlCode = function(Code)
		{
			this.addColumnDinCode( this.addHtmlCode, arguments);
			this.currentBuffer.append(Code);
		}
		
		this.startTable = function(CtrlName, TId, Width)
		{
			this.addColumnDinCode( this.startTable, arguments);
			var newCol = this.newColumn( "", "", "left");
			newCol.htmlName = CtrlName + '_' + TId;
			newCol.gxControl = new gx.html.controls.table();
			newCol.gxControl.column = newCol;
			newCol.gxControl.width = Width;
			newCol.gxControl.dataType = newCol.type;
			this.grid.addColumn(newCol);
		}
		
		this.endTable = function()
		{
			this.addColumnDinCode( this.endTable, arguments);
			this.currentBuffer.append("</table>");
		}
		
		this.startRow = function(Title,Align,Valign,Bgcolor,Bordercolor, Class)
		{
			this.addColumnDinCode( this.startRow, arguments);
			var newCol = this.newColumn( "", "", "left");
			newCol.gxControl = new gx.html.controls.row();
			newCol.gxControl.column = newCol;
			newCol.gxControl.title = Title;
			newCol.gxControl.align = Align;
			newCol.gxControl.verticalAlign = Valign;
			newCol.gxControl.backColor = Bgcolor;
			newCol.gxControl.borderColor = Bordercolor;
			newCol.gxControl.cssClass = Class;
			newCol.gxControl.ownCssClass = Class;
			newCol.gxControl.dataType = newCol.type;
			this.grid.addColumn(newCol);
		}
		
		this.endRow = function()
		{
			this.addColumnDinCode( this.endRow, arguments);
			this.currentBuffer.append("</tr>");
		}
		
		this.startCell = function(Title,Align,Valign,Bgcolor,Bordercolor,Height,Width,Colspan,Rowspan, Class)
		{
			this.addColumnDinCode( this.startCell, arguments);
			var newCol = this.newColumn( "", "", "left");
			newCol.gxControl = new gx.html.controls.cell();
			newCol.gxControl.column = newCol;
			newCol.gxControl.title = Title;
			newCol.gxControl.align = Align;
			newCol.gxControl.verticalAlign = Valign;
			newCol.gxControl.backColor = Bgcolor;
			newCol.gxControl.borderColor = Bordercolor;
			newCol.gxControl.height = Height;
			newCol.gxControl.width = Width;
			newCol.gxControl.colSpan = Colspan;
			newCol.gxControl.rowSpan = Rowspan;
			newCol.gxControl.cssClass = Class;
			newCol.gxControl.dataType = newCol.type;
			this.grid.addColumn(newCol);
		}
		
		this.endCell = function()
		{
			this.addColumnDinCode( this.endCell, arguments);
			this.currentBuffer.append("</td>");
		}
		
		this.startGroup = function(Id,Caption,Height,Width)
		{
			this.addColumnDinCode( this.startGroup, arguments);
			var newCol = this.newColumn( "", "", "left");
			newCol.htmlName = Id;
			newCol.gxControl = new gx.html.controls.group();
			newCol.gxControl.column = newCol;
			newCol.gxControl.id = Id;
			newCol.gxControl.caption = Caption;
			newCol.gxControl.height = Height;
			newCol.gxControl.width = Width;
			newCol.gxControl.dataType = newCol.type;
			this.grid.addColumn(newCol);
		}
		
		this.endGroup = function()
		{
			this.addColumnDinCode( this.endGroup, arguments);
			this.currentBuffer.append("</fieldset>");
		}
		
		this.newColumn = function( colTitle, colType, colAlign, colWidth)
		{
			var columnType = this.getColumnType( colType);
			var newCol = new gx.grid.column(colTitle, columnType, colWidth, colAlign);
			this.currentBuffer = newCol.buffer;
			newCol.htmlName = '';
			newCol.gxId = '';
			newCol.gxAttId = '';
			newCol.gxAttName = '';
			return newCol;
		}
		
		this.getColumnType = function( colType)
		{
			var columnType;
			switch(colType)
			{
				case 'decimal':
				case 'int':
					columnType = gx.types.numeric;
					break;
				case 'date':
					columnType = gx.types.date;
					break;
				case 'dtime':
					columnType = gx.types.dateTime;
					break;
				case 'boolean':
					columnType = gx.types.bool;
					break;
				default:
					columnType = gx.types.character;
					break;
			}
			return columnType;
		}
		
		this.addOldComponent = function( rowId, ctrlId)
		{
			if (typeof(this.oldCmps[rowId]) == 'undefined')
			{
				this.oldCmps[rowId] = [];
			}
			this.oldCmps[rowId].push( ctrlId);
		}
		
		this.updateOldComponents = function()
		{
			var len = this.grid.rows.length;
			for (var i=0; i<len; i++)
			{
				delete this.oldCmps[this.grid.rows[i].gxId];
			}
			for (var rowId in this.oldCmps)
			{
				var rowCmps = this.oldCmps[rowId];
				while( rowCmps.length > 0)
				{
					var ctrlName = rowCmps.shift();
					gx.fn.deleteHidden( ctrlName);
				}
				delete this.oldCmps[rowId];
			}
		}
		
		this.addHidden = function( CtrlName)
		{
			this.hiddens.push( CtrlName);
		}
		
		this.addHiddenControl = function( CtrlName, CtrlValue, Persistent)
		{
			gx.fn.setHidden( CtrlName, CtrlValue);
			if (Persistent != true)
				this.addHidden( CtrlName);
		}
		
		this.clearHiddens = function()
		{
			while( this.hiddens.length > 0)
			{
				var ctrlName = this.hiddens.shift();
				gx.fn.deleteHidden( ctrlName);
			}
		}
		
		this.setHtmlTags = function(GridProps)
		{
			var HtmlTags="";
			var HtmlTagsStyle = " style=\"";
			HtmlTagsStyle += GridProps.Visible=="0" ? "display:none;" : "";
			HtmlTags += " class=\"" + GridProps.Class + "\"";
			
			var eo = gx.lang.emptyObject;
	
			HtmlTagsStyle += !eo(GridProps.Background) ? ("background:" + GridProps.Background + ";") : "";
			HtmlTagsStyle += !eo(GridProps.Backcolor) && GridProps.Backcolor!="0" ? ("background-color:" + gx.color.html(GridProps.Backcolor).Html + ";") : "";
			HtmlTagsStyle += !eo(GridProps.Bordercolor) && GridProps.Bordercolor!="0" ? ("border-color:" + gx.color.html(GridProps.Bordercolor).Html + ";") : "";
			HtmlTags += !eo(GridProps.Align) ? (" align=\"" + GridProps.Align + "\"") : "";
			HtmlTags += !eo(GridProps.Tooltiptext) ? (" title=\"" + GridProps.Tooltiptext + "\"") : "";
			HtmlTagsStyle += !eo(GridProps.Borderwidth) && GridProps.Borderwidth!="0" ? (" border-width:" + GridProps.Borderwidth + ";") : "";
			HtmlTags += !eo(GridProps.Cellpadding) ? (" cellpadding=\"" + GridProps.Cellpadding + "\"") : "";
			HtmlTags += !eo(GridProps.Cellspacing) ? (" cellspacing=\"" + GridProps.Cellspacing + "\"") : "";
			HtmlTags += !eo(GridProps.Height) && GridProps.Height!="0" ? (" height=\"" + GridProps.Height + "\"") : "";
			HtmlTags += !eo(GridProps.Width) && GridProps.Width!="0" ? (" width=\"" + GridProps.Width + "\"") : "";
	
			HtmlTags += HtmlTagsStyle + "\"";
			
			this.htmlTags = gx.text.trim( HtmlTags);
			this.grid.gxHtmlTags = this.htmlTags;
			
			if (!eo(GridProps.Width))
			{
				this.grid.gxWidth = GridProps.Width;
			}
			if (!eo(GridProps.Height))
			{
				this.grid.gxHeight = GridProps.Height;
			}
		}
		
		this.setGridStyles = function( props)
		{
			this.visible = (props.Visible != undefined)?gx.lang.gxBoolean(props.Visible):true;
			this.setSortable(((props.Sortable != undefined)?gx.lang.gxBoolean(props.Sortable):true));
			this.background = (props.Background != undefined)?props.Background:'';
			this.cssClass = (props.Class != undefined)?props.Class:'';
			this.titleBackstyle = (props.Backcolorstyle != undefined)?props.Backcolorstyle:gx.grid.styles.none;  
			this.titleFont = (props.Titlefont != undefined)?props.Titlefont:'';        
			this.linesFont = (props.Linesfont != undefined)?props.Linesfont:'';
			this.borderWidth = (props.Borderwidth != undefined)?props.Borderwidth:'';
			this.toolTipText = (props.Tooltiptext != undefined)?props.Tooltiptext:'';	
			try 
			{
				this.backcolor = (props.Backcolor != undefined)?gx.color.html(props.Backcolor).Html:'';
				this.titleBackcolor = (props.Titlebackcolor != undefined)?gx.color.html(props.Titlebackcolor).Html:'';
				this.titleForecolor = (props.Titleforecolor != undefined)?gx.color.html(props.Titleforecolor).Html:'';
				this.linesBackcolorOdd = (props.Backcolorodd != undefined)?gx.color.html(props.Backcolorodd).Html:'';
				this.linesBackcolorEven = (props.Backcoloreven != undefined)?gx.color.html(props.Backcoloreven).Html:'';
				this.bordercolor = (props.Bordercolor != undefined)?gx.color.html(props.Bordercolor).Html:'';						
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxgrid.js', 'setGridStyles');
			}
			this.borderWidth = (props.Borderwidth != undefined)?props.Borderwidth:'';
			this.toolTipText = (props.Tooltiptext != undefined)?props.Tooltiptext:'';
			
			this.grid.gxCssClass = "";
			this.grid.gxTitleClass = "";
			this.grid.gxFooterClass = "";
			this.grid.gxOddLlinesClass = "";
			this.grid.gxEvenLinesClass = "";
			
			this.grid.gxBackColor = this.backcolor;
			this.grid.gxTitleBackColor = this.titleBackcolor;
			this.grid.gxTitleForeColor = this.titleForecolor;
			this.grid.gxTitleBackstyle = this.titleBackstyle;
			this.grid.gxTitleFont = this.titleFont;
			this.grid.gxLinesFont = this.linesFont;
			this.grid.gxBackground = this.background;
			this.grid.gxLinesBackcolorOdd = this.linesBackcolorOdd;
			this.grid.gxLinesBackcolorEven = this.linesBackcolorEven;
			this.grid.gxBorderWidth = this.borderWidth;
			this.grid.gxBordercolor = this.bordercolor;
			this.grid.gxToolTipText = this.toolTipText;
			this.grid.gxVisible = this.visible;
			
			if (this.cssClass != "")
			{
				this.grid.gxCssClass = this.cssClass;
				this.grid.gxTitleClass = this.cssClass+"Title";
				this.grid.gxFooterClass = this.cssClass+"Footer";
				if (this.titleBackstyle ==  gx.grid.styles.none)
				{
					this.grid.gxOddLlinesClass = this.cssClass+"Odd";
					this.grid.gxEvenLinesClass = this.grid.gxOddLlinesClass;
				}
				else if (this.titleBackstyle == gx.grid.styles.uniform)
				{
					this.grid.gxOddLlinesClass = this.cssClass+"Uniform";
					this.grid.gxEvenLinesClass = this.grid.gxOddLlinesClass;
				}
				else if (this.titleBackstyle == gx.grid.styles.header)
				{
					this.grid.gxOddLlinesClass = this.cssClass+"Odd";
					this.grid.gxEvenLinesClass = this.grid.gxOddLlinesClass;
				}
				else if (this.titleBackstyle == gx.grid.styles.report)
				{
					if (this.isFreestyle && (this.gridCols <= 0))
					{
						this.grid.gxOddLlinesClass = this.cssClass+"Odd";
						this.grid.gxEvenLinesClass = this.grid.gxOddLlinesClass;
					}
					else
					{
						this.grid.gxOddLlinesClass = this.cssClass+"Odd";
						this.grid.gxEvenLinesClass = this.cssClass+"Even";
					}
				}
			}
		}
		
		this.setSortable = function(sortable)
		{
			if (this.sortable != sortable)
			{
				this.sortable = sortable;
				var len = this.grid.columns.length;
				for(var i=0; i<len; i++)
				{
					this.grid.columns[i].sortable = sortable;
				}
			}
		}
		
		this.lastRowId = 0;
		this.addRow = function( rowProps)
		{
			var rowId = this.lastRowId++;
			var gxRowIdx = gx.grid.rowId(rowId + 1);
			var row = new gx.grid.row(rowId, rowProps, gxRowIdx, this.grid.gxParentRowId);
			row.gxCmpContext = this.gxComponentContext;
			row.Grids = rowProps.Grids;
			row.ownerGrid = this;
			row.gxLvl = this.gridLvl;
			this.setRowHiddens( rowProps.Hiddens);
			var columns = this.grid.columns;
			var len = columns.length;
			for(var i=0; i<len; i++)
			{
				var column = columns[i];
				var colProps = rowProps.Props[i];
				var colValue = colProps[colProps.length -1];
				row.values[i] = colValue;
				if (this.parentObject.isTransaction())
				{
					var idxInKey = this.columnIndexInKey(column.gxAttId);
					if(idxInKey != -1)
					{
						row.gxKeyValues[idxInKey] = colValue;
					}
				}
			}
			if(this.isFreestyle)
			{
				this.installChildGrids(row);
			}
			this.grid.addRow(row);
			return row;
		}
		
		this.installChildGrids = function(row)
		{
			var len = this.childGrids.length;
			for( var i=0; i<len; i++)
			{
				var gxChildGrid = this.childGrids[i];
				var rowGrid = gxChildGrid.gxCreateGridCode(row.gxId);
				rowGrid.grid.parentGxObject = this.parentObject;
				var cntName = this.grid.gxCmpContext + rowGrid.realGridName + 'Container';
				rowGrid.gxContainerDivName = cntName + 'Div_' + row.gxId;
				rowGrid.gxContainerDataName = cntName + 'Data_' + row.gxId;
				rowGrid.gxContainerValuesName = cntName + 'DataV_' + row.gxId;
				row.gxGrids.push(rowGrid);
				rowGrid.parentGrid = this;
				rowGrid.parentRow = row;
				this.parentObject.setGrid(rowGrid);
				gxChildGrid.copyPropertiesTo( rowGrid);
				rowGrid.grid.gxCmpContext = this.grid.gxCmpContext;
				rowGrid.grid.gxParentRowId = row.gxId;
				this.installChildGridColumns(rowGrid, gxChildGrid);
			}
		}
		
		this.installChildGridColumns = function(Grid, gxChildGrid)
		{
			var len = gxChildGrid.gxAddColumnsCode.length;
			for(var i=0; i<len; i++)
			{
				gxChildGrid.gxAddColumnsCode[i].call(Grid);
			}
		}
		
		this.copyPropertiesTo = function( RowGrid)
		{
			RowGrid.cssClass = this.cssClass;
			RowGrid.titleBackstyle = this.titleBackstyle;
			RowGrid.titleBackcolor = this.titleBackcolor;
			RowGrid.linesBackcolorOdd = this.linesBackcolorOdd;
			RowGrid.linesBackcolorEven = this.linesBackcolorEven;
			RowGrid.grid.gxCssClass = this.grid.gxCssClass;
			RowGrid.grid.gxTitleClass = this.grid.gxTitleClass ;
			RowGrid.grid.gxOddLlinesClass = this.grid.gxOddLlinesClass;
			RowGrid.grid.gxEvenLinesClass = this.grid.gxEvenLinesClass;
			RowGrid.grid.gxAllowCollapsing = this.grid.gxAllowCollapsing;
			RowGrid.grid.gxCollapsed = this.grid.gxCollapsed;
		}
		
		this.setRowHiddens = function( hiddens)
		{
			if (hiddens && this.parentObject.isTransaction())
			{
				for (var name in hiddens)
					gx.fn.setHidden( name, hiddens[name]);
			}
		}
		
		this.executeEvent = function( EventName, rowId)
		{
			gx.evt.setGridEvt( this.gridId.toString(), rowId);
			this.instanciateRow( rowId);
			this.parentObject[EventName].call(this.parentObject, rowId);
		}
	
		this.updatePagingVars = function(Eof, FirstRecordOnPage)
		{
			if (this.grid.usePaging)
			{
				if (Eof==undefined && FirstRecordOnPage==undefined){
					this.grid.eof = gx.fn.getHidden(this.grid.gxCmpContext + this.grid.gxGridName.toUpperCase() + "_nEOF");
					this.grid.firstRecordOnPage = gx.fn.getHidden(this.grid.gxCmpContext + this.grid.gxGridName.toUpperCase() + "_nFirstRecordOnPage");
				}
				else
				{
					this.grid.eof = Eof;
					this.grid.firstRecordOnPage = FirstRecordOnPage;
				}
			}
		}
	
		this.clearDefaultEventHandlers = function()
		{
			var len = 0;
			if (this.defaultDragable || this.defaultSetsContext)
			{
				len = this.grid.rows.length;
				for( var i=0; i<len; i++)
				{
					var trId = this.containerName + 'Row_' + this.grid.rows[i].gxId;
					if (this.defaultDragable)
						gx.fx.dnd.deleteSource( trId);
					if (this.defaultSetsContext)
						gx.fx.ctx.deleteSetter( trId);
				}
			}
			len = this.grid.columns.length;
			for(var i=0; i<len; i++)
			{
				var currCol = this.grid.columns[i];
				if (currCol.gxSetsContext == true)
				{
					var len1 = this.grid.rows.length;
					for(var j=0; j<len1; j++)
					{
						gx.fx.ctx.deleteSetter( currCol.htmlName + '_' + this.grid.rows[j].gxId);
					}
				}
			}
		}
		
		this.setDefaultEventHandlers = function()
		{
			var outerThis = this;
			var len = 0;
			if (this.defaultDragable || this.defaultSetsContext)
			{
				if (!gx.lang.emptyObject(this.boundedCollType))
				{
					var divId = this.grid.gxCmpContext + this.containerName+"Div";
					if (this.defaultDragable)
						gx.fx.dnd.addSource( this.parentObject, divId, this.cssClass, [this.boundedCollType], function() {return outerThis.returnGridData();});
					if (this.defaultSetsContext)
						gx.fx.ctx.addSetter( this.parentObject, divId, this.cssClass, [this.boundedCollType], function() {return outerThis.returnGridData();});
				}
				else
				{
					var evtTypes = this.getRowAsTypes();
					len = this.grid.rows.length;
					for( var i=0; i<len; i++)
					{
						var trId = this.gxComponentContext + this.containerName + 'Row_' + this.grid.rows[i].gxId;
						var rowCtrl = gx.dom.el( trId);
						if (rowCtrl != null)
						{
							rowCtrl.gxGrid = this.containerName;
							rowCtrl.gxGridName = this.gridName;
							rowCtrl.gxId = this.grid.rows[i].gxId;
							trId = this.containerName + 'Row_' + this.grid.rows[i].gxId;
							if (this.defaultDragable)
								gx.fx.dnd.addSource( this.parentObject, trId, this.cssClass, evtTypes, function(rCtrl) {return outerThis.returnRowData(rCtrl);});
							if (this.defaultSetsContext)
								gx.fx.ctx.addSetter( this.parentObject, trId, this.cssClass, evtTypes, function(rCtrl) {return outerThis.returnRowData(rCtrl);});
						}
					}
				}
			}
			len = this.grid.columns.length;
			for(var i=0; i<len; i++)
			{
				var currCol = this.grid.columns[i];
				if (currCol.gxSetsContext == true)
				{
					var len1 = this.grid.rows.length;
					for(var j=0; j<len1; j++)
					{
						var cellCtrl = gx.dom.el( this.gxComponentContext + currCol.htmlName + '_' + this.grid.rows[j].gxId);
						if (cellCtrl != null)
						{
							cellCtrl.gxHtmlName = currCol.htmlName;
							gx.fx.ctx.addSetter( this.parentObject, currCol.htmlName + '_' + this.grid.rows[j].gxId, "", [currCol.gxAttName], this.returnColumnContext);
						}
					}
				}
			}
		}
		
		this.returnColumnContext = function( colControl)
		{
			var Value = '';
			if (colControl.nodeName == "SPAN")
				Value = gx.dom.spanValue(colControl);
			else
				Value = gx.fn.getControlValue_impl( colControl.id);
			if (Value != null)
				return Value;
			return "";
		}
		
		this.returnRowData = function( rowCtrl)
		{
			var dragObj = {};
			var row = this.grid.getRowByGxId(rowCtrl.gxId);
			if (row)
			{
				var len = this.grid.columns.length;
				for(var i=0; i<len; i++)
				{
					var colAttName = this.grid.columns[i].gxAttName;
					if (colAttName != "")
						dragObj[colAttName] = row.values[i];
				}
			}
			return dragObj;
		}
		
		this.returnGridData = function()
		{
			var gridData = [];
			var len = this.grid.rows.length;
			for (var i=0; i<len; i++)
			{
				var dragObj = {};
				gridData[i] = dragObj;
				var row = this.grid.rows[i];
				var len1 = this.grid.columns.length;
				for (var j=0; j<len1; j++)
				{
					var colAttName = this.grid.columns[j].gxAttName;
					if (colAttName != "")
						dragObj[colAttName] = row.values[j];
				}
			}
			return gridData;
		}
		
		this.doDrop = function( dropObj)
		{
			var rowsQty = (dropObj.length != undefined)?ropObj.length:1;
			this.getNewRows( rowsQty, null, function(rows){ this.addDropedRows(rows, dropObj); });
		}
		
		this.addDropedRows = function( rowsProps, dropObj)
		{
			var len = dropObj.length;
			if (len != undefined)
			{
				for(var i=0; i<len; i++)
					this.setDroppedRow(rowsProps[i], dropObj[i]);
			}
			else
				this.setDroppedRow(rowsProps[0], dropObj);
			this.setNewRows( rowsProps);
		}
		
		this.setDroppedRow = function( rowProps, dropRow)
		{
			var len = this.grid.columns.length;
			for(var i=0; i<len; i++)
			{
				var colProps = rowProps.Props[i];
				var colAttName = this.grid.columns[i].gxAttName;
				var droppedValue = '';
				if ((colAttName != "") && (dropRow[colAttName] != undefined))
					droppedValue = dropRow[colAttName];
				colProps.Value = droppedValue;
				colProps.FormattedValue = droppedValue;
			}
		}
		
		this.getRowAsTypes = function()
		{
			var types = [];
			var len = this.grid.columns.length;
			for(var i=0; i<len; i++)
			{
				var colAttName = this.grid.columns[i].gxAttName;
				if (colAttName != "")
					types.push( colAttName);
			}
			return types;	
		}
		
		this.addRows = function( rowsProps)
		{
			var len = rowsProps.Count;
			for(var i=0; i<len; i++)
			{
				var rowProps = rowsProps[i];
				this.addRow(rowProps);
			}
		}
		
		this.lastRowIsModified = function()
		{
			if (this.grid.rows.length == 0)
				return false;
			var lastRow = this.grid.rows[this.grid.rows.length-1];
			if (lastRow.gxExists())
				return true;
			if (!lastRow.gxIsMod())
				return false;
			else
				return true;
		}
		
		this.getNewRows = function( rows, event, handler)
		{
			var newRowHdl = (handler != undefined)?handler:this.setNewRows;
			if (event == null || (((event.type=='keydown' && (event.keyCode==32 || event.keyCode==13)) || event.type=='click') && (this.grid.rows.length == 0 || this.lastRowIsModified())))
			{
				gx.csv.pkDirty = false;
				gx.ajax.newRows(this.gxComponentContext, this.isMasterPageGrid, this.realGridName, rows + this.lastRowId, this.lastRowId+1, (gx.grid.rowId(this.lastRowId+1)+this.grid.gxParentRowId), this.grid.gxParentRowId, newRowHdl);
				gx.csv.pkDirty = false;
			}
			else if((event != null) && ((event.keyCode==32)||(event.keyCode==13)))
			{
				gx.evt.cancel(event, true);
			}
		}
		
		this.setNewRows = function( rowProps)
		{
			if (rowProps.Count != undefined)
			{
				var i=0;
				for (i=0; i<rowProps.Count; i++)
				{
					var row = this.addRow(rowProps[i]);
					gx.fn.setCurrentGridRow(this.gridId, row.gxId);					
				}
				if (rowProps.Count > 0)
				{
					this.addingRows = true;
					this.refreshGrid(false);
					this.addingRows = false;
					this.setFocusFirstControl(rowProps[0]);
				}
			}
		}
		
		this.gxNewRowFocused = function(Ctrl)
		{
			Ctrl.style.textDecoration = 'underline';
			var firstGridCtrl = gx.fn.firstGridControl( this.gridId);
			gx.evt.onfocus(Ctrl, firstGridCtrl, this.gxComponentContext, this.isMasterPageGrid, '9999', this.gridId);
		}
		
		this.rowKeyPressed = function(keyEvent)
		{
			var eventSource = gx.evt.source(keyEvent);
			if( eventSource != undefined)
			{
				if( keyEvent.ctrlKey && keyEvent.keyCode == 46/*DEL*/ )
				{
					this.setRowDeleted( eventSource);
					gx.evt.cancel(keyEvent, true);
				}
			}
		}
		
		this.gxHasDuplicateKey = function()
		{
			var keys = [];
			var rows = this.grid.rows;
			var len = rows.length;
			for( var i=0; i<len; i++)
			{
				var row = rows[i];
				if((row.gxExists() || row.gxIsMod()) && !row.gxDeleted())
				{
					var rowKey = "";
					var len1 = row.gxKeyValues.length;
					for( var j=0; j<len1; j++)
					{
						rowKey += row.gxKeyValues[j].toString();
					}
					if(keys[rowKey] != undefined)
						return true;
					keys[rowKey] = 1;
				}
			}
			return false;
		}
		
		this.columnIndexInKey = function(colIdx)
		{
			var len = this.lvlKey.length;
			for( var i=0; i<len; i++)
			{
				if(this.lvlKey[i] == colIdx)
					return i;
			}
			return -1;
		}
		
		this.refreshVars = [];
		this.addRefreshingVar = function( validStruct)
		{
			if (gx.lang.emptyObject(validStruct))
				return;
			var eventThis = this;
			var eventName = "";
			this.refreshVars[this.refreshVars.length] = validStruct;
			if (validStruct.fld)
			{
				var varCtrl = gx.dom.el( this.gxComponentContext + validStruct.fld);
				if (varCtrl != undefined)
				{
					if (gx.lang.emptyObject(validStruct.hc)){
					
						if (varCtrl.tagName == "SELECT") 
							eventName = "change";
						else if (varCtrl.type == "checkbox" || varCtrl.type == "radio")
							eventName = "click";
						else if (!gx.lang.isNumericType(validStruct.type))
							eventName = "keyup";
							
						if (eventName != "")
						{
							if (varCtrl.type == "radio")
							{
								var radioGroup = gx.dom.byName(this.gxComponentContext + validStruct.fld);
								var len = radioGroup.length;
								for (var i=0; i<len; i++)
								{
									gx.evt.attach( radioGroup[i], eventName, function() {eventThis.filterVarChanged();});
								}
							}
							else
							{
								gx.evt.attach( varCtrl, eventName, function() {eventThis.filterVarChanged();});
							}
						}
					}
				}
			}
		}
		
		this.filterVarChanged = function()
		{
			if (this.parentObject.autoRefresh && !gx.grid.drawAtServer)
			{
				var refreshParms = this.getRefreshParmsUrl();
				if (this.lastRefreshParms != refreshParms)
				{
					this.lastRefreshParms = refreshParms;
					this.callAsyncRefresh(refreshParms);
				}
			}
			else
			{
				this.parentObject.conditionsChanged = this.conditionsChanged();
			}
		}
		
		this.conditionsChanged = function()
		{
			var varsLen = this.refreshVars.length;
			for( var i=0; i<varsLen; i++)
			{
				var vStruct = this.refreshVars[i];
				if (typeof(vStruct.rfrVar) == 'undefined')
				{
					var oldValue = gx.fn.getHidden( this.gxComponentContext + 'GXH_' + vStruct.fld);
					var newValue = vStruct.val();
					if (oldValue != newValue)
					{
						return true;
					}
				}
			}
			return false;
		}
		
		this.getRefreshParmsUrl = function()
		{
			var refreshParms = "";
			if (this.pageSizeParm)
				refreshParms = this.grid.pageSize + ",";
			var varsLen = this.refreshVars.length;
			for( var i=0; i<varsLen; i++)
			{
				var vStruct = this.refreshVars[i];
				if (typeof(vStruct.rfrVar) != 'undefined')
				{
					var filterValue = undefined;
					var ctrlName = undefined;
					if (typeof(vStruct.rfrProp) != 'undefined')
					{
						var col = this.grid.getColumnForVar( vStruct.rfrVar);
						if (col)
						{
							var propName = vStruct.rfrProp.toLowerCase();
							filterValue = col[propName];
							if (propName == 'value' && col.gxControl.type == gx.html.controls.types.image)
								filterValue = gx.util.removeBaseUrl( filterValue);
						}
						else
						{
							filterValue = "";
						}
					}
					else
					{
						if (typeof(this.parentObject.VarControlMap[vStruct.rfrVar]) != 'undefined')
						{
							ctrlName = this.parentObject.VarControlMap[vStruct.rfrVar].id;
						}
						if (typeof(ctrlName) != 'undefined')
						{
							filterValue = gx.fn.getHidden( this.gxComponentContext + ctrlName);
						}
						if (typeof(filterValue) == 'undefined')
						{
							filterValue = this.parentObject[vStruct.rfrVar];
						}
						if (typeof(filterValue) == 'object')
						{
							filterValue = gx.json.serializeJson(filterValue);
						}
					}
					refreshParms += encodeURIComponent(filterValue)+ ",";
				}
				else
				{
					if (!gx.lang.emptyObject(vStruct.hc))
						refreshParms += encodeURIComponent(this.parentObject[vStruct.hc])+ ",";
					else 
						refreshParms += this.getFormattedParm( vStruct) + ",";
					gx.fn.setHidden( this.gxComponentContext + 'GXH_' + vStruct.fld, vStruct.val());
				}
			}
			if (this.parentObject.IsComponent)
			{
				refreshParms += encodeURIComponent(this.parentObject.CmpContext)+ ",";
			}			
			return refreshParms;
		}
		
		this.initRefreshParms = function()
		{
			if (this.parentObject.autoRefresh)
			{
				this.lastRefreshParms = this.getRefreshParmsUrl();
			}
		}
		
		this.getFormattedParm = function( vStruct)
		{
			if( vStruct.type == 'date')
			{
				var ctrl = gx.dom.el( this.gxComponentContext + vStruct.fld);
				return encodeURIComponent(gx.date.urlDate(ctrl, gx.dateFormat));
			}
			else if( vStruct.type == 'dtime')
			{
				var ctrl = gx.dom.el( this.gxComponentContext + vStruct.fld);
				return encodeURIComponent(gx.date.urlDateTime(ctrl, gx.dateFormat));
			}
			return encodeURIComponent(vStruct.val());
		}
	
		this.callAsyncRefresh = function( refreshParms)
		{
			var eventThis = this;
			if (this.refreshTimer != null)
			{
				window.clearTimeout( this.refreshTimer);
				this.refreshTimer = null;
			}
			this.refreshTimer = window.setTimeout(function(){gx.ajax.refreshGrid(eventThis, refreshParms)}, 400);
		}
		
		this.updatePropsHidden = function( newProps)
		{
			var propsCtrlName = this.getDataHiddenName();
			gx.fn.setHidden(propsCtrlName, newProps);
		}
		
		this.loadAfterRefresh = function(gridRows)
		{
			var rowsLen1 = this.grid.rows.length;
			this.blankGridRows();
			if (this.usePaging)
			{
				var eof = this.grid.gxCmpContext + this.grid.gxGridName.toUpperCase() + "_nEOF";
				var firstPage = this.grid.gxCmpContext + this.grid.gxGridName.toUpperCase() + "_nFirstRecordOnPage";
				this.updatePagingVars(gridRows[eof], gridRows[firstPage]);
				gx.fn.setHidden(eof, gridRows[eof]);
				gx.fn.setHidden(firstPage, gridRows[firstPage]);
			}
			this.addRows(gridRows);
			var rowsLen2 = this.grid.rows.length;
			this.refreshGrid(null, true);
			gx.fx.obs.notify('grid.onafterrefresh', [this, rowsLen1, rowsLen2]);
		}
	
		this.getSelection = function()
		{
			if (this.allowSelection)
			{
				var len = this.grid.rows.length;
				for (var i=0; i<len; i++)
				{
					var row = this.grid.rows[i];
					if (row.selected)
					{
						return i;
					}
				}
			}
			return -1;
		}
		
		this.setSelection = function( idx)
		{
			if (this.allowSelection && idx >= 0)
			{
				var cRow = gx.grid.rowId(idx + 1);
				var rowCtrl = gx.dom.el(this.grid.gxCmpContext + this.grid.gxGridObject + "Row_" + cRow);
				if (rowCtrl)
					this.grid.setRowSelected( rowCtrl, cRow);
			}
		}
		
		this.blankGridRows = function()
		{
			this.lastRowId = 0;
			this.grid.rows = [];
		}
		
		this.setRowDeleted = function(rowCtrl)
		{
			var row = null;
			if (typeof(rowCtrl) == 'string')
			{
				row = this.grid.getRowByGxId( rowCtrl);
			}
			else
			{
				row = (rowCtrl.gxId == undefined)?this.getRowFromHtmlCtrl(rowCtrl):rowCtrl;
			}
			row.setDeleted(!row.gxDeleted());
			this.setRowModified(row.gxId);
			gx.fn.removeGridRow(row.gxId, this.gridId.toString());
			this.refreshGrid();
		}
		
		this.setFocusFirstControl = function( rowProps)
		{
			for(var i=0; i<rowProps.Count; i++)
			{
				var row = this.grid.getRowByGxId(gx.grid.rowId(this.lastRowId) + this.grid.gxParentRowId);
				if(row)
				{
					var focusCtrl = gx.dom.el(this.grid.gxCmpContext + this.grid.columns[i].htmlName + "_" + row.gxId);
					if(focusCtrl != undefined && gx.fn.isAccepted(focusCtrl))
					{
						gx.grid.lastFocusCtrl = this.grid.columns[i].gxId;
						gx.fn.setFocus(focusCtrl);
						break;
					}
				}
			}
		}
		
		this.instanciateRow = function( cRow)
		{
			try
			{
				gx.setGxO( this.parentObject.CmpContext, this.parentObject.IsMasterPage);
				var row = cRow;
				if (typeof(row) == "string")
				    row = this.grid.getRowByGxId(cRow);
				if(row != null)
				{
					gx.fn.setCurrentGridRow(this.gridId, row.gxId);
					var len = row.values.length;
					for (var i=0; i<len; i++)
					{
						var column = this.grid.columns[i];
						if (column.gxId != '')
						{
							var validStruct = this.parentObject.getValidStruct(column.gxId);
							if (validStruct)
							{
								if (this.isUsercontrol)
								{
									validStruct.v2v(this.grid.properties[row.id][column.index].value);
									gx.fn.setHidden(this.grid.properties[row.id][column.index].id, this.grid.properties[row.id][column.index].value);	
								}
								else
								{
									validStruct.c2v();
								}
							}
						}
					}
				}
				else
				{
					gx.fn.setCurrentGridRow(this.gridId, cRow);
					var len = this.grid.columns.length;
					for (var i=0; i<len; i++)
					{
						var column = this.grid.columns[i];
						if (column.gxId != '')
						{
							var validStruct = this.parentObject.getValidStruct(column.gxId);
							if (validStruct)
							{
								validStruct.c2v();
							}
						}
					}
				}
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxgrid.js', 'instanciateRow');
			}
			return true;
		}
		
		this.setRenderProperty = function( PropName, HiddenName, PropValue, PropType)
		{
			this.grid.setProperty( PropName, HiddenName, PropValue, PropType);
		}
		
		this.setRenderDynProperty = function( PropName, HiddenName, PropType)
		{
			this.grid.setDynProperty( PropName, HiddenName, PropType);
		}
		
		this.addRenderEventHandler = function( EventName, Handler)
		{
			this.grid.addEventHandler( EventName, Handler);
		}
		
		this.cleanup = function()
		{
			this.parentObject = null;
			this.parentGrid = null;
			this.grid.ownerGrid = null;
			this.grid.parentGxObject = null;
			this.grid.container = null;
			this.grid.ascLabel = null;
			this.grid.descLabel = null;
			this.grid.columns = null;
			this.grid.rows = null;
			this.grid = null;
		}
		
		this.loadGrid = function(postProps, fromPost)
		{
			var bkpObj = gx.O;
			gx.setGxO( this.parentObject.CmpContext, this.parentObject.IsMasterPage);
			this.isLoading = true;
			var isTrn = this.parentObject.isTransaction();
			if (isTrn && this.contextMenu == null)
				this.contextMenu = new gx.grid.contextMenu(this);
			if (postProps != undefined)
			{
				var divCtrl = this.getContainerControl();
				if (divCtrl != null)
				{
					if (fromPost == true)
					{
						var rowsValues = this.getValuesFromHidden();
						this.mergeValuesWithProps(postProps, rowsValues);
						if (this.isFreestyle && gx.lang.emptyObject(this.parentRow))
						{
							this.backupComponents();
						}
					}
					this.deleteGridData();
					this.grid.setContainerDelayed(divCtrl);
					this.clearHiddens();
					this.setRowsProperty();
					var sel = this.getSelection();
					this.blankGridRows();
					this.setHtmlTags( postProps);
					this.setGridStyles( postProps);
					this.setDeleteMethod( postProps.DeleteMethod);
					this.setSelectionAndHover( postProps.Allowselection, postProps.Selectioncolor, postProps.Allowhover, postProps.Hovercolor);
					this.setCollapsing( postProps.Allowcollapsing, postProps.Collapsed);
					this.setSflColumns( postProps.SflColumns);
					this.setColumnsProperties( postProps.Columns);
					this.updatePagingVars();
					this.addRows(postProps);
					this.updateOldComponents();
					this.initRefreshParms();
					this.refreshGrid();
					this.setSelection(sel);
				}
			}
			else
			{
				this.clearHiddens();
				this.setRowsProperty();
				this.grid.pageSize = (isTrn || this.isFreestyle)?9999:this.gridRows;
				var divCtrl = this.getContainerControl();
				if (divCtrl != null)
				{
					this.grid.setContainerDelayed(divCtrl);
					var rowsProps = this.getRowsFromHidden();
					if(rowsProps != null)
					{
						this.blankGridRows();
						this.setHtmlTags(rowsProps);
						this.setGridStyles( rowsProps);
						this.setDeleteMethod( rowsProps.DeleteMethod);
						this.setSelectionAndHover( rowsProps.Allowselection, rowsProps.Selectioncolor, rowsProps.Allowhover, rowsProps.Hovercolor);
						this.setCollapsing( rowsProps.Allowcollapsing, rowsProps.Collapsed);
						this.setSflColumns( rowsProps.SflColumns);
						this.setColumnsProperties( rowsProps.Columns);
						this.updatePagingVars();
						this.addRows( rowsProps);
						this.initRefreshParms();
	        				this.addingRows = true;
						this.refreshGrid();
	        				this.addingRows = false;
					}
					else
					{
						this.blankGridRows();
						this.updatePagingVars();
						this.initRefreshParms();
						this.refreshGrid();
					}
				}
				else
				{
					this.loadWrappedGridChilds();					
				}
			}
			this.isLoading = false;
			gx.setGxO( bkpObj.CmpContext, bkpObj.IsMasterPage);
		}
		
		this.loadWrappedGridChilds = function()
		{
			try
			{
				var rows = gx.fn.getHidden(this.grid.gxCmpContext + "nRC_" + this.gridName);
				if (typeof(rows) != 'undefined')
				{
					rows = parseInt(rows);
					for (var i=0; i<rows; i++)
					{
						var len = this.grid.columns.length;
						for (var j=0; j<len; j++)
						{
							var column = this.grid.columns[j];
							if (column.gxControl.type == gx.html.controls.types.userControl)
							{
								this.addUsercontrolToDraw({r:gx.grid.rowId(i + 1),c:column});
							}
						}
					}
					this.setupGridUsercontrols(this.GridUserControls);
				}
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxgrid.js', 'loadWrappedGridChilds');				
			}
		}
		
		this.getRowsFromHidden = function()
		{
			var propsCtrlName = this.getDataHiddenName();
			var ctrlsProps = gx.fn.getHidden(propsCtrlName);
			var rowsProps = null;
			if(!gx.lang.emptyObject(ctrlsProps))
			{
					gx.json.setNonSerializable( propsCtrlName);
					rowsProps = gx.json.evalJSON(ctrlsProps);
			}
			else
			{
				return null;
			}
			var rowsValues = this.getValuesFromHidden();
			this.mergeValuesWithProps(rowsProps, rowsValues);
			return rowsProps;
		}
		
		this.deleteGridData = function()
		{
			var propsCtrlName = this.getDataHiddenName();
			gx.json.setNonSerializable( propsCtrlName);
		}
		
		this.getValuesFromHidden = function()
		{
			var valCtrlId = this.getValuesHiddenName();
			var ctrlsValues = gx.fn.getHidden( valCtrlId);
			if (gx.lang.emptyObject(ctrlsValues))
				ctrlsValues = gx.fn.getControlValue(valCtrlId);
			gx.json.setNonSerializable( valCtrlId);
			var rowsValues = null;
			if(ctrlsValues != null && ctrlsValues != "")
				rowsValues = gx.json.evalJSON(ctrlsValues);
			return rowsValues;
		}
		
		this.mergeValuesWithProps = function( props, values)
		{
			var len = props.Count;
			if (!len)
				return;
			for (var i=0; i<len; i++)
			{
				var rowProps = props[i].Props;
				var rowValues = values[i];
				if (!rowValues)
					continue;
				var len1 = rowProps.length;
				for (var j=0; j<len1; j++)
				{
						rowProps[j].push( rowValues[j]);
				}
			}
		}
		
		this.getContainerControl = function()
		{
			var divCtrl = null;
			if (this.gxContainerDivName != undefined)
				divCtrl = gx.dom.byId(this.gxContainerDivName);
			else
				divCtrl = gx.dom.byId(this.grid.gxCmpContext + this.containerName+"Div");
			if (divCtrl) {
				this.gxContainerCtrl = divCtrl;
				divCtrl.setAttribute("gxgridid", this.gridId.toString());
				divCtrl.gxGridName = this.grid.gxGridName;
	            }
			return divCtrl;
		}
		
		this.getDataHiddenName = function()
		{
			var ctrlSuffix = (this.grid.gxParentRowId == '')?'':'_' + this.grid.gxParentRowId;
			var ctrlName = '';
			if (this.gxContainerDataName != undefined)
				ctrlName = this.gxContainerDataName;
			else
				ctrlName = this.grid.gxCmpContext + this.containerName+'Data' + ctrlSuffix;
			return ctrlName;
		}
		
		this.getValuesHiddenName = function()
		{
			var ctrlSuffix = (this.grid.gxParentRowId == "")?"":"_" + this.grid.gxParentRowId;
			var ctrlName = '';
			if (this.gxContainerValuesName != undefined)
				ctrlName = this.gxContainerValuesName;
			else
				ctrlName = this.grid.gxCmpContext + this.containerName+"DataV" + ctrlSuffix;
			return ctrlName;
		}
		
		this.setColumnsProperties = function( props)
		{
			try
			{
				var len = props.length;
				for (var i=0;i<len;i++)
				{
					var col = this.grid.columns[i];
					for (var prop in props[i])
					{
						var pValue = props[i][prop];
						prop = this.fixColumnPropName(prop);
						if (this.isUsercontrol)
						{
							col[prop] = pValue;
						}
						col[prop.toLowerCase()] = pValue;
					}
					this.checkPromptColumn( col);
				}
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxgrid.js', 'setColumnsProperties');
			}
		}
		
		this.checkPromptColumn = function( col)
		{
			try
			{
				if (this.isPromptColumn( col))
				{
					var ctrl = gx.fn.getAttachedCtrl( col.htmlName);
					if (ctrl && ctrl.info && ctrl.info.controls)
					{
						var anyVisible = false;
						var anyEnabled = false;
						var depLen = ctrl.info.controls.length;
						for (var j=0; j<depLen; j++)
						{
							var depId = ctrl.info.controls[j];
							var depCol = this.grid.getColumnByGxId(depId);
							var enabled = gx.lang.gxBoolean(depCol.enabled);
							var visible = gx.lang.gxBoolean(depCol.visible);
							if (enabled)
								anyEnabled = true;
							if (visible)
								anyVisible = true;
						}
						if (!anyEnabled)
							col.enabled = '0';
						if (!anyVisible)
							col.visible = '0';
					}
				}
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxgrid.js', 'checkPromptColumn');
			}
		}
		
		this.fixColumnPropName = function( propName)
		{
			if (propName == 'Horizontalalignment')
			{
				return 'align';
			}
			return propName;
		}
		
		this.setDeleteMethod = function( deleteMethod)
		{
			var isTrn = this.parentObject.isTransaction();
			if (isTrn)
			{
				var disableDelete = (this.parentObject.Gx_mode == 'DSP');
				if (!disableDelete && deleteMethod && (deleteMethod == 'none'))
				{
					disableDelete = true;
				}
				if (disableDelete)
				{
					this.deleteMethod = gx.grid.deleteMethods.none;
				}
				else
				{
					this.deleteMethod = gx.grid.deleteMethod;
				}
			}
		}
		
		this.setSelectionAndHover = function( Allowselection, Selectioncolor, Allowhover, Hovercolor)
		{
			try
			{
				this.allowSelection = (Allowselection == "true")?true:false;
				this.selectionColor = null;
				this.allowHovering = false;
				this.hoverColor = null;
				if (this.allowSelection)
				{
					this.allowHovering = (Allowhover == "true")?true:false;
					Selectioncolor = eval(Selectioncolor);
					if (typeof(Selectioncolor[0]) != 'undefined')
						this.selectionColor = gx.color.fromRGB(Selectioncolor[0], Selectioncolor[1],Selectioncolor[2]);
					else
						this.selectionColor = gx.color.html(Selectioncolor);
					if (this.allowHovering)
					{
						Hovercolor = eval(Hovercolor);
						if (typeof(Hovercolor[0]) != 'undefined')
							this.hoverColor = gx.color.fromRGB(Hovercolor[0], Hovercolor[1],Hovercolor[2]);
						else
							this.hoverColor = gx.color.html(Hovercolor);
					}
				}
				this.grid.gxAllowSelection = this.allowSelection;
				this.grid.gxSelectionColor = this.selectionColor;
				this.grid.gxAllowHovering = this.allowHovering;
				this.grid.gxHoverColor = this.hoverColor;
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxgrid.js', 'setSelectionAndHover');
			}
		}
		
		this.setCollapsing = function( Allowcollapsing, Collapsed)
		{
			try
			{
				this.allowCollapsing = (Allowcollapsing == "true")?true:false;
				this.collapsed = (Collapsed == 0)?false:true;
				
				this.grid.gxAllowCollapsing = this.allowCollapsing;
				this.grid.gxCollapsed = this.collapsed;
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxgrid.js', 'setCollapsing');
			}
		}
		
		this.setSflColumns = function( sflColumns)
		{
			try
			{
				if (!gx.lang.emptyObject(sflColumns))
				{
					this.gridCols = parseInt(sflColumns);
					this.grid.gxGridCols = this.gridCols;
				}			
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxgrid.js', 'setSflColumns');
			}
		}
		
		this.isPromptColumn = function( column)
		{
			if (column.gxAttId.indexOf && column.gxAttId.indexOf("prompt_") != -1)
				return true;
			return false;
		}
		
		this.setRowsProperty = function()
		{
				var rowsHiddenValue = gx.fn.getHidden(this.grid.gxCmpContext + this.gridName.toUpperCase() + "_Rows");
				if(rowsHiddenValue != null)
				{
					try {this.gridRows = parseInt(rowsHiddenValue, 10);}
					catch(e)
					{
						gx.dbg.logEx(e, 'gxgrid.js', 'setRowsProperty');
					}
					this.grid.pageSize = this.gridRows;
				}
		}
		
		this.crearInstalledSuggests = function()
		{
			var len = this.grid.columns.length;
			for (var i=0; i<len; i++)
			{
				var column = this.grid.columns[i];
				var vStruct = this.parentObject.getValidStructFld(column.htmlName);
				if (vStruct && vStruct.gxsgprm && vStruct.gxsgprm.installed)
				{
					vStruct.gxsgprm.installed = {};
				}
			}
		}
		
		this.refreshCollection = function( coll)
		{
			try
			{
				this.blankGridRows();
				this.updatePagingVars();
				this.initRefreshParms();
				var cLen = coll.length;
				for (var i=0; i<cLen; i++)
				{
					var rowProps = { Props:[] };
					var collItem = coll[i];
					var len = this.grid.columns.length;
					for (var j=0; j<len; j++)
					{
						var column = this.grid.columns[j];
						rowProps.Props[column.index] = [collItem[column.gxAttName]];
					}
					this.addRow(rowProps);
				}
				this.refreshGrid( false, false, true);
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxgrid.js', 'refreshCollection');
			}
		}
		
		this.refreshGrid = function(loadChildGrids, fromAutoRefresh, fromCollection)
		{
			this.DatePickersControls = [];
		  this.GridUserControls = [];
	  	this.GridComponents = [];
			this.clearDefaultEventHandlers();
			this.clearHiddens();
			this.crearInstalledSuggests();
			this.setRowsProperty();
			if ((this.parentRow != undefined) && (this.parentRow.Grids != undefined))
			{
				var gridProps = this.parentRow.Grids[this.realGridName];
				if(gridProps != null)
				{
					this.setHtmlTags(gridProps);
					this.setGridStyles( gridProps);
					this.setColumnsProperties( gridProps.Columns);
					if (!this.addingRows)
					{
						this.addRows( gridProps);
					}
				}
			}
			var firstTime = false;
			if(loadChildGrids == false)
			{
				this.grid.render(firstTime, false, fromCollection);
			}
			else
			{
				firstTime = true;
				this.grid.render(firstTime, fromAutoRefresh, fromCollection);
			}
			this.setupGridComponents(this.GridComponents);
			this.setupGridUsercontrols(this.GridUserControls);
	    this.triggerDatePickersSetup(this.DatePickersControls);
	    if(this.isFreestyle)
			{
	  		this.loadRowsGrids(firstTime);
	  	}
			this.updateRcdCount();
			this.setDefaultEventHandlers();
		}
		
		this.backupComponents = function()
		{
			try
			{
				var len1 = this.grid.rows.length;
			  	for(var i=0; i<len1; i++)
			  	{
			  		var row = this.grid.rows[i];
			  		var len2 = this.grid.columns.length;
			  		for (var j=0; j<len2; j++)
			  		{
			  			var column = this.grid.columns[j];
			  			if (column.gxControl.type == gx.html.controls.types.webComponent)
			  			{
			  				var cmpProps = row.gxProps[j];
			  				var controlName = cmpProps[0];
			  				var cmpPrefix = this.parentObject.getComponentPrefix( controlName);
							var cmpCtrlId = this.gxComponentContext + 'gxHTMLWrp' + cmpPrefix + row.gxId;
							var cmpCtrl = gx.dom.el( cmpCtrlId);
							if (cmpCtrl)
							{
								cmpCtrl.parentNode.removeChild(cmpCtrl);
								document.body.appendChild(cmpCtrl);
			  				}
			  			}
			  		}
			  		var len3 = row.gxGrids.length;
					for(var k=0; k<len3; k++)
					{
						var rowGrid = row.gxGrids[k];
						if (rowGrid && rowGrid.isFreestyle)
						{
							rowGrid.backupComponents();
						}
					}
			  	}
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxgrid.js', 'backupComponents');
			}  
		}
		
		this.setupGridComponents = function( GridComponents)
		{
			var len = GridComponents.length;
			for(var i=0; i<len; i++)
			{
				var cmp = GridComponents[i];
				if (cmp.create === false)
				{
					var hook = gx.dom.el(cmp.existingEl);
					var parent = hook.parentNode;
					var el = gx.dom.el(cmp.el);
					parent.removeChild(hook);
					parent.appendChild(el);
				}
				else
				{
					gx.html.processCode(cmp.c, false, function(obj) {
						var gxComp = gx.createComponent( obj.n, obj.p);
						if (gxComp != null)
						{
							gx.addComponent( gxComp);
							gxComp.readServerVars();
							if (obj.load)
								gxComp.onload();
						}
					}, [cmp]);
				}
			}
		}
		
		this.setupGridUsercontrols = function(GridUserControls)
	  {
	  	var len = GridUserControls.length;
			for(var i=0; i<len; i++)
			{
				var rowId = GridUserControls[i].r;
				var col = GridUserControls[i].c;
				var userControl = gx.uc.getNew(this.parentObject, col.gxUCId, col.gxUCLastId, col.gxUCClassName, col.gxUCContainerName + '_' + rowId, col.gxUCControlName, this.gridLvl, this.gridId, rowId);
				userControl.DesignContainerName = col.gxUCContainerName;
				userControl.setC2ShowFunction(col.gxShowFunc);
				var len1 = col.gxC2VFuncs.length;
				for(var j=0;j<len1;j++) { userControl.addC2VFunction(col.gxC2VFuncs[j]); };
				var len2 = col.gxV2CFuncs.length;
				for(var j=0;j<len2;j++) { userControl.addV2CFunction(col.gxV2CFuncs[j]); };
				userControl.setGridProperties();
				userControl.setGridEventHandlers();
				this.parentObject.setUserControl(userControl);
				userControl.execV2CFunctions();
				userControl.execShowFunction();
			}
	  }
	  
	  this.triggerDatePickersSetup = function(DatePickersControls)
	  {
	  	var len = DatePickersControls.length;
			for(var j=0; j<len; j++)
			{
				var controlId = DatePickersControls[j].CtrlId;
				var controlGrid = DatePickersControls[j].Grid;
				var controlRow = DatePickersControls[j].Row;
				var currentObject = gx.O;
				var validStruct = null;
				var ctrlIds = gx.fn.controlIds();
				var len1 = ctrlIds.length;
				for (var i=0;i<len1;i++)
				{
					validStruct = gx.fn.validStruct(ctrlIds[i]);
					if (validStruct.grid == controlGrid)
					{
						var vControlId = currentObject.CmpContext + validStruct.fld + "_" + controlRow;
						if (vControlId == controlId)
							break;
					}
				}
				if ((validStruct != null) && (validStruct.dp != undefined))
				{
					gx.fn.installDatePicker(controlId, validStruct.dp.f, validStruct.dp.st, validStruct.dp.wn, validStruct.dp.mf, gx.fn.datePickerFormat(validStruct.dp.pic, validStruct.dp.dec, validStruct.len));
				}
			}
	  }
	  
	  this.addComponentToDraw = function( cmpObj)
	  {
			this.GridComponents.push( cmpObj);
	  }
	  
	  this.addUsercontrolToDraw = function( ucObj)
	  {
			this.GridUserControls.push( ucObj);
	  }
	  
	  this.addDatepickerToSetup = function( dpObj)
	  {
			this.DatePickersControls.push( dpObj);
	  }
	  
	  this.loadRowsGrids = function(firstTime)
	  {
	  	var len = this.grid.rows.length;
	  	for(var i=0; i<len; i++)
	  	{
	  		this.loadRowGrids(this.grid.rows[i], firstTime);
	  	}
	  }
	  
		this.loadRowGrids = function(row, firstTime)
		{
			var len = row.gxGrids.length;
			for(var i=0; i<len; i++)
			{
				var rowGrid = row.gxGrids[i];
				rowGrid.grid.setContainerDelayed(gx.dom.el(rowGrid.gxContainerDivName));
				if(firstTime)
				{
					rowGrid.loadGrid();
				}
				else
				{
					rowGrid.refreshGrid();
				}
			}
		}
		
		this.updateRcdCount = function()
		{
			if (this.hasForEachLine || this.parentObject.isTransaction())
			{
				gx.fn.setHidden(this.grid.gxCmpContext + "nRC_" + this.gridName, this.lastRowId.toString());
			}
		}
		
		this.updateControlValue = function( vStruct, modifRow)
		{
			try
			{
				var gxgrid = this;
				var cRow = gx.fn.currentGridRow( vStruct.grid).toString();
				var iRow = cRow;
				var rLen = cRow.length;
				if (rLen > 4)
				{
					var pRow = cRow.substring( 4, rLen);
					gxgrid = gx.fn.gridObj(this.gxComponentContext, this.gridName + '_' + pRow, this.isMasterPageGrid);
					if (!gxgrid)
						return;
					iRow = cRow.substring( 0, 4);
				}
				var gridRow = parseInt(iRow, 10) - 1;
				if (modifRow == true)
					gxgrid.setRowModified(cRow);
				var colIdx = gxgrid.getColumnIndexByName(vStruct.fld);
				var ctrl = gx.dom.el(this.gxComponentContext + vStruct.fld + "_" + cRow);
				gxgrid.updateRowValue(colIdx, gridRow, ctrl);
				return gxgrid;
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxgrid.js', 'updateControlValue');
			}
			return null;
		}
		
		this.persistControlValue = function(ControlId, Value, validStruct)
		{
			var _Idx = ControlId.lastIndexOf("_");
			if(_Idx != -1)
			{
				var htmlName = ControlId.substring(0, _Idx);
				var rowGxId = ControlId.substring(_Idx + 1);
				var row = this.grid.getRowByGxId(rowGxId);
				if(row)
				{
					var column = this.grid.getColumnByHtmlName(htmlName);
					if(column)
					{
						var pValue = this.parentObject[validStruct.gxvar];
						if (validStruct.type=="decimal" && gx.lang.instanceOf(pValue, Number))
							pValue=pValue.toFixed(validStruct.dec);
						row.values[column.index] = pValue;
						if (!row.gxProps[column.index])
						    row.gxProps[column.index] = {};
						var cellCtrl = gx.dom.el(ControlId);
						if (cellCtrl && cellCtrl.tagName == 'SELECT')
						{
							row.gxProps[column.index].Values = gx.dom.controlToObj(cellCtrl);
						}
						row.gxProps[column.index].Value = pValue;
						row.gxProps[column.index].FormattedValue = Value;
					}
				}
			}
		}
		
		this.getColumnIndexByName = function(htmlName)
		{
			var cols = this.grid.columns;
			var len = cols.length;
			for(var i=0; i<len; i++)
			{
				if(cols[i].htmlName == htmlName)
					return i;
			}
			return -1;
		}
		
		this.setRowModified = function(cRow)
		{
			gx.fn.setHidden(this.grid.gxCmpContext + "nIsMod_" + this.gridLvl.toString() + "_" + cRow, 1);
			if(this.parentGrid != null)
			{
				this.parentGrid.setRowModified(this.grid.gxParentRowId);
			}
			this.grid.showDeleteImage( cRow);
		}
		
		this.validateRow = function( eventCtrl)
		{
			if (eventCtrl)
			{
				try
				{
					gx.fn.setCurrentGridRow(eventCtrl.gxgridid, eventCtrl.gxrow);
					var lastGridCtrl = gx.fn.lastGridControl( eventCtrl.gxgridid);
					gx.csv.validControls( gx.csv.lastId, lastGridCtrl + 1, true);
				}
				catch(e)
				{
					gx.dbg.logEx(e, 'gxgrid.js', 'validateRow');
				}
			}
		}
			
		this.updateRowValue = function(colIdx, rowId, ctrl)
		{
			var row = this.grid.getRowById(rowId);
			var column = this.grid.columns[colIdx];
			if(ctrl.type == "checkbox")
			{
				if(ctrl.checked) ctrl.value = column.gxChecked;
				else ctrl.value = column.gxUnChecked;
			}
			var ctrlVal = gx.fn.getControlValue(this.grid.columns[colIdx].htmlName + "_" + row.gxId);
			var validStruct = this.parentObject.getValidStructFld(this.grid.columns[colIdx].htmlName);
	        var pValue = validStruct.val();
			row.values[colIdx] = pValue;
			if (!gx.lang.emptyObject(row.gxProps[colIdx]))
			{
				row.gxProps[colIdx].Value = pValue;
				row.gxProps[colIdx].FormattedValue = ctrlVal;
			}
			if (this.parentObject.isTransaction())
			{
				var idxInKey = this.columnIndexInKey(column.gxAttId);
				if(idxInKey != -1)
				{
					row.gxKeyValues[idxInKey] = pValue;
				}
			}
			if(column.gxControl.type == gx.html.controls.types.blob)
			{
				gx.fn.setControlValue(this.grid.gxCmpContext + "gxBlob" + column.htmlName + "_" + row.gxId, pValue);
			}
		}
		
		this.expandCollapse = function( imgCtrl, event)
		{
			gx.evt.cancel( event, true);
			var gridTbl = gx.dom.el( this.gxComponentContext + this.containerName + "Tbl");
			if (gridTbl != null)
			{
				if (this.collapsed)
				{
					gridTbl.style.display = 'block';
					imgCtrl.src = gx.util.resourceUrl(gx.basePath + gx.staticDirectory + "collapse.gif", true);
				}
				else
				{
					gridTbl.style.display = 'none';
					imgCtrl.src = gx.util.resourceUrl(gx.basePath + gx.staticDirectory + "expand.gif", true);
				}
				this.collapsed = !this.collapsed;
				this.grid.gxCollapsed = this.collapsed;
				var gridNameCollapse;
				if (this.parentGrid)				
				{
					var lastIndex = this.gridName.lastIndexOf("_");
					var gridNumber = this.gridName.substring(lastIndex);
					gridNameCollapse =	this.gxComponentContext + this.realGridName.toUpperCase() + "_Collapsed" + gridNumber;
				}					 
				else
					gridNameCollapse =	this.gxComponentContext + this.realGridName.toUpperCase() + "_Collapsed";
				gx.fn.setHidden(gridNameCollapse, (this.collapsed)? "1":"0");
			}
		}
		
		this.getRowFromHtmlCtrl = function(rowCtrl)
		{
			var rowId = rowCtrl.gxrow;
			if (gx.lang.emptyObject(rowId))
			{
				var _Idx = rowCtrl.id.lastIndexOf("_");
				rowId = rowCtrl.id.substring(_Idx + 1);
			}
			return this.grid.getRowByGxId(rowId);
		}
		
		this.showContextMenu = function( rowCtrl, contextEvent)
		{
			this.contextMenu.show( rowCtrl, contextEvent);
		}
	},

	contextMenu: function( parentGrid) {
		this.gxgrid = parentGrid;
		this.controlName = this.gxgrid.containerName + "ContextMenu"
		this.rowClicked = null;
		this.contextEvent = null;
		this.eventSource = null;
		var buffer = new gx.text.stringBuffer();
		
		this.show = function( eventCtrl, cEvent)
		{
			this.gxgrid.validateRow( eventCtrl);
			this.contextEvent = cEvent;
			this.eventSource = gx.evt.source(this.contextEvent);
			gx.evt.cancel(cEvent, true);
			
			this.rowClicked = eventCtrl;
	    this.startMenu();
	    
			buffer.append("<div class=\"").append("menuItem").append("\" id=\"").append("deleteRow").append("\" align=\"center\">").append(gx.getMessage("GXM_deleterow")).append("</div>");
			//buffer.append("<div class=\"").append("menuItem").append("\" id=\"").append("undeleteRow").append("\" align=\"center\">").append("Undelete row").append("</div>");
			
			this.endMenu();
		}
		
		this.startMenu = function()
		{
			buffer.clear();
			
			var menuCoords = this.getMenuCoords();
			
			buffer.append("<div onclick=\"").append(this.gxgrid.grid.gridObject() + ".contextMenu.contextMenuClicked(event);").append("\" onmouseover=\"");
	   	buffer.append(this.gxgrid.grid.gridObject() + ".contextMenu.switchContextMenu();").append("\" onmouseout=\"").append(this.gxgrid.grid.gridObject() + ".contextMenu.switchContextMenu();").append("\" oncontextmenu=\"gx.evt.cancel(event, true);");
	    buffer.append("\" style=\"").append("position:absolute;width:100;background-Color:menu; border: outset 1px gray;");
	    buffer.append("top:" + menuCoords.top + "; left:" + menuCoords.left + ";").append("\">");
		}
		
		this.endMenu = function()
		{
			buffer.append("</div>");
			
			var ContextControl = gx.dom.byId( this.controlName);
			if (ContextControl == null)
			{
				ContextControl = document.createElement("SPAN");
				ContextControlShadow = document.createElement("SPAN");
				ContextControlShadow2 = document.createElement("SPAN");
				IFrameControl = document.createElement("IFRAME");
				ContextControl.id = this.controlName;
				ContextControlShadow.id = this.controlName + "Shadow";
				ContextControlShadow2.id = this.controlName + "Shadow2";
				IFrameControl.id= this.controlName + "GXiFrameIEHack";
				IFrameControl.src = "about:blank";
				IFrameControl.style.zIndex = 1;
				IFrameControl.style.visibility = "hidden";
				IFrameControl.style.position = "absolute";
				IFrameControl.frameBorder= "0";
			
				document.body.appendChild( ContextControl);
				document.body.appendChild( ContextControlShadow);
				document.body.appendChild( ContextControlShadow2);
				document.body.appendChild( IFrameControl);
			}
			
			ContextControl.innerHTML = buffer.toString();
		}
		
		this.hide = function()
		{
			this.rowClicked = null;
			this.contextEvent = null;
			gx.dom.removeControl( gx.dom.byId( this.controlName));
		}
		
		this.getMenuCoords = function()
		{
			var posx = 0;
			var posy = 0;
			var e = this.contextEvent;
			if (e.pageX || e.pageY)
			{
				posx = e.pageX;
				posy = e.pageY;
			}
			else if (e.clientX || e.clientY)
			{
				posx = e.clientX + document.body.scrollLeft	+ document.documentElement.scrollLeft;
				posy = e.clientY + document.body.scrollTop + document.documentElement.scrollTop;
			}
	
			return {left:posx, top:posy};
		}
		
		this.contextMenuClicked = function( mouseEvent)
		{
			var eSource = gx.evt.source(mouseEvent);
			this.handleContextMenuAction(eSource.id);
			this.hide();
		}
		
		this.handleContextMenuAction = function( actionId)
		{
			switch(actionId)
			{
				case "deleteRow":
					this.gxgrid.setRowDeleted( this.rowClicked);
					break;
				case "undeleteRow":
					this.gxgrid.setRowDeleted( this.rowClicked);
					break;
				default:
					break;
			}
		}
		
		this.switchContextMenu = function()
		{
			//Cambia la clase del elemento seleccionado para hacerle un highlight
		}
	},

	rowId: function( idx) {
			var strIdx = idx.toString();
			while(strIdx.length < 4)
			{
				strIdx = "0" + strIdx;
			}
			return strIdx;
	},
	
	_init: function() {
		if (!this.deleteMethod)
		{
			this.deleteMethod = this.deleteMethods.images;
		}
		if (this.deleteImage && (this.deleteMethod == this.deleteMethods.images))
		{
			this.deleteImage = gx.ajax.getImageUrl( this.deleteImage);
		}
		else
		{
			this.deleteImage = gx.util.resourceUrl(gx.basePath + gx.staticDirectory + 'delete_16x.jpg', true);
		}
		if (this.undeleteImage && (this.deleteMethod == this.deleteMethods.images))
		{
			this.undeleteImage = gx.ajax.getImageUrl( this.undeleteImage);
		}
		else
		{
			this.undeleteImage = this.deleteImage;
		}
		if (!this.deletePosition)
		{
			this.deletePosition = this.deletePositions.left;
		}
		if (!this.deletePositionFree)
		{
			this.deletePositionFree = this.deletePositions.topL;
		}
		if (this.deleteTooltip)
		{
			this.deleteTooltip = gx.getMessage(this.deleteTooltip);
		}
		else
		{
			this.deleteTooltip = '';
		}
		if (this.deleteTitle)
		{
			this.deleteTitle = gx.getMessage(this.deleteTitle);
		}
		else
		{
			this.deleteTitle = '';
		}
	},
	
	_deinit: function() {
		this.lastFocusCtrl = null;
	}
};
/* END OF FILE - gxgrid.js - */
/* START OF FILE - JavaScripTable.js - */
gx.grid.impl = function(id) {

	this.basePath = gx.basePath;
	this.imgsDir = gx.staticDirectory;

    this.columns = [];
    this.rows = [];
    this.fixedValues = [];
    this.width = '';
    this.align = '';
    this.border = '0';
    this.padding = '1';
    this.spacing =  '0';
    this.sortColumn = -1;
    this.ascSort = true;
    this.usePaging = true;
    this.eof = 1;
    this.firstRecordOnPage = 0;
    this.pageSize = 9999;
    this.currentPage = 1;
    this.gxLvl = 0;
    this.gxGridName = "";
    this.gxGridObject = null;
    this.gxBuffer = new gx.text.stringBuffer();
    this.gxParentRowId = "";

    this.tableClass = '';
    this.headerClass = '';
    this.footerClass = '';
    this.editControlClass = '';
    this.navigationClass = '';
    this.navigationLinkClass = '';
    this.highlightedNavigationLinkClass = '';
    this.columnHeaderClass = '';
    this.columnHeaderTextClass = '';
    this.oddRowClass = '';
    this.oddRowCellClass = '';
    this.evenRowClass = '';
    this.evenRowCellClass = '';

	this.ascLabel = new Image();
    this.descLabel = new Image();

    this.id = id;
    this.container = null;
    
    this.setContainerDelayed = function(gxContainer) {
    	this.container = gxContainer;
    }

    this.addColumn = function(column) {
        if (column.isGxRemove()) 
        {
            column.visible = false;
        }
    		var len = this.columns.length;
        column.index = len;
        column.table = this;
        this.columns[len] = column;
        return column;
    }
         
    this.getColumnByIndex = function(index) {
        return this.columns[index];
    }
    
    this.addRow = function(row, refresh) {       
        row.table = this;
        if (row == null) {
            return;
        }
        
        this.rows[this.rows.length] = row;
        
        if (gx.lang.booleanValue(refresh)) {
            this.render();
        }
        return row;
    }
    
    this.getColumnByHtmlName = function(htmlName) {
    		for(var i=0; i<this.columns.length; i++)
		{
			if ((this.columns[i].htmlName == htmlName) || (this.gxCmpContext + this.columns[i].htmlName == htmlName))
			{
				return this.columns[i];
			}
		}
		return null;
    }
    
    this.getColumnByGxId = function(id) {
    		for(var i=0; i<this.columns.length; i++)
		{
			if (this.columns[i].gxId == id)
			{
				return this.columns[i];
			}
		}
		return null;
    }
    
    this.getColumnForVar = function( varName) {
		for(var i=0; i<this.columns.length; i++)
		{
			var vStruct = this.parentGxObject.getValidStructFld(this.columns[i].htmlName);
			if (vStruct)
			{
				if(vStruct.gxvar == varName)
				{
					return this.columns[i];
				}
			}
		}
		return null;
    },
    
    this.getRowById = function(id) {
        var ret = null;
        var len = this.rows.length;
        for (var i = 0; (ret == null) && (i < len); i++) {
            row = this.rows[i];
            if (row.id == id) {
                ret = row;
            }
        }
        return ret;
    }
    
    this.getRowByGxId = function(gxId) {
        var ret = null;
        var len = this.rows.length;
        for (var i = 0; (ret == null) && (i < len); i++) {
            row = this.rows[i];
            if (row.gxId == gxId) {
                ret = row;
            }
        }
        return ret;
    }
    
    this.setSort = function(column, asc) {
        if (column == this.sortColumn) {
            if (asc == null) {
                this.ascSort = !this.ascSort;
            } else {
                this.ascSort = gx.lang.booleanValue(asc);
            }
        } else {
            this.sortColumn = column;
            this.ascSort = (asc == null ? true : gx.lang.booleanValue(asc));
        }

        this.rows.sort(this.sort);
        this.ownerGrid.refreshGrid();
    }

    this.getControlName = function(row, column) {
    		return this.gxCmpContext + column.htmlName + '_' + row.gxId;
    }

    this.getControlId = function(row, column) {
        return this.getControlName(row, column);
    }

    this.getRowCount = function() {
        return this.rows.length;
    }

    this.getMaxPage = function() {
        return Math.ceil(this.getRowCount() / this.pageSize);
    }
    
    this.isGxTrn = function() {
			return this.parentGxObject.isTransaction();
    }
    
    this.gridObject = function()
    {
    		return "gx.fn.gridObj('" + this.gxCmpContext + "','" + this.gxGridName + "'," + this.gxIsMasterPageGrid.toString() + ")"; 
    }
    
    this.deleteImgId = function( rowId)
    {
    		return this.gxCmpContext + 'delete' + this.gxGridName + '_' + rowId;
    }
    
    this.showDeleteImage = function( rowId)
    {
    		if (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.images)
    		{
    			var isGxTrn = this.isGxTrn();
    			if (isGxTrn)
    			{
		    		var imgCtrl = gx.dom.el( this.deleteImgId( rowId));
		    		if (imgCtrl)
		    		{
		    			if (!gx.fn.isVisible(imgCtrl))
		    			{
			    			imgCtrl.style.display = 'inline';
			    			if (imgCtrl.parentNode.nodeName == 'A')
			    			{
			    				imgCtrl.parentNode.style.display = 'inline';
			    			}
			    		}
		    		}
		    	}
    		}
    	}
    
    this.appendDeleteHeader = function( buffer, position)
    {
    		if (!this.gxIsFreestyle && (this.ownerGrid.deleteMethod != gx.grid.deleteMethods.none))
    		{
	    		var isGxTrn = this.isGxTrn();
	    		var correctPosition = false;
	    		if (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.menu)
			{
				if (position == gx.grid.deletePositions.left)
				{
					correctPosition = true;
				}
				else
				{
					return;
				}
			}
			else if (gx.grid.deletePosition == position)
			{
				correctPosition = true;
			}
	    		if(isGxTrn &&  correctPosition)
			{
				var text = '&nbsp;';
				if (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.images)
				{
					text = gx.grid.deleteTitle;
				}
				buffer.append('<th class="' + this.columnHeaderClass + '">' + text + '</th>');
			}
		}
    	}
    	
    	this.appendDeleteImage = function( buffer, row, position)
    	{
    		if (this.ownerGrid.deleteMethod != gx.grid.deleteMethods.none)
    		{
    			var isGxTrn = this.isGxTrn();
    			if (isGxTrn)
    			{
		    		var isDeleted = false;
				var canDelete = false;
				if ((this.parentGxObject.Gx_mode != 'DSP') && (this.parentGxObject.Gx_mode != 'DLT' ))
				{
					isDeleted = row.gxDeleted();
					canDelete = (row.gxIsMod() || row.gxExists());
				}
				var imgId = this.deleteImgId( row.gxId);
				var correctPosition = false;
				if (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.menu)
				{
					if (position == gx.grid.deletePositions.left)
					{
						correctPosition = true;
					}
					else
					{
						return;
					}
				}
				else
				{
					if (!this.gxIsFreestyle && (gx.grid.deletePosition == position))
					{
						correctPosition = true;
					}
					else if (this.gxIsFreestyle)
					{
						var posFree = gx.grid.deletePositionFree;
						if (position == gx.grid.deletePositions.left)
						{
							correctPosition = ((posFree == gx.grid.deletePositions.topL) || (posFree == gx.grid.deletePositions.topR));
						}
						else if (position == gx.grid.deletePositions.right)
						{
							correctPosition = ((posFree == gx.grid.deletePositions.bottomL) || (posFree == gx.grid.deletePositions.bottomR));
						}
						position = posFree;
					}
				}
		    		if(correctPosition)
				{
					var tagStart = '<td align="' + this.deleteImageAlign(position) + '">';
					var tagEnd = '</td>';
					var imgSrc = '';
					var showHidden = false;
					if(isDeleted && (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.images))
					{
						imgSrc = gx.grid.undeleteImage;
					}
					else if(canDelete && (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.images))
					{
						imgSrc = gx.grid.deleteImage;
					}
					else if(isDeleted && (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.menu))
					{
						imgSrc = gx.grid.deleteImage;
					}
					else
					{
						imgSrc = gx.grid.deleteImage;
						showHidden = true;
					}
					var tooltip = '';
					buffer.append(tagStart);
					if (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.images)
					{
						var firstGridCtrl = gx.fn.firstGridControl( this.ownerGrid.gridId);
						tooltip = gx.grid.deleteTooltip;
						buffer.append("<a gxfocusable=\"1\" href=\"javascript:" + this.gridObject() + ".setRowDeleted('" + row.gxId + "');\"");
						buffer.append(" onfocus=\"gx.evt.onfocus(this," + firstGridCtrl + ",'" + this.ownerGrid.gxComponentContext + "'," + this.ownerGrid.isMasterPageGrid + ",'" + row.gxId + "'," + this.ownerGrid.gridId + ")\"");
						var aStyle = '';
						if (showHidden)
						{
							aStyle += 'display:none;';
						}
						if (aStyle != '')
						{
							buffer.append(" style=\"" + aStyle + "\"");
						}
						buffer.append(">");
					}
					buffer.append('<img id="' + imgId + '" src="' + imgSrc + '"');
					if (tooltip != '')
					{
						buffer.append(' title="' + tooltip + '"');
					}
					buffer.append(' style="border-style: none;');
					if (showHidden)
					{
						buffer.append('display:none;');
					}
					buffer.append('"');
					buffer.append('/>');
					if (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.images)
					{
						buffer.append('</a>');
					}
					buffer.append(tagEnd);
				}
			}
		}
    	}
    	
    	this.deleteImageAlign = function(position)
    	{
    		if (this.gxIsFreestyle)
    		{
    			if (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.menu)
    			{
    				return 'left';
    			}
    			var styleAlign = 'right';
    			if ((position == gx.grid.deletePositions.bottomL) || (position == gx.grid.deletePositions.topL))
    			{
    				styleAlign = 'left';
    			}
    			return styleAlign;
    		}
    		return 'center';
    	}

    this.render = function(firstTime, fromAutoRefresh, fromCollection)
    {
        if (firstTime != false) {
            firstTime = true;
        }

        var isGxTrn = this.isGxTrn();
        var hasRowBreaks = this.gxIsFreestyle && (this.gxGridCols > 1);

        var cursorPointer = "cursor:" + (document.createTextRange ? "hand" : "pointer") + ";";
        var buffer = new gx.text.stringBuffer();
        var visibleColumnsArray = this.columns;
        var renderedColumnCount = renderedColumnCount = visibleColumnsArray.length;

        if(!this.gxIsFreestyle && isGxTrn)
        {
        	renderedColumnCount++;
        }
        
        var images = [];
        var editControls = [];
                
				var firstRow, lastRow, maxPage;
				if (this.pageSize != 0)
				{
					var maxPage = this.getMaxPage();
					if (this.currentPage <= 0)
					{
						this.currentPage = 1;
					}
					else if (this.currentPage > maxPage)
					{
						this.currentPage = maxPage;
					}
					firstRow = Math.max(this.pageSize * (this.currentPage-1), 0);
					lastRow = Math.min(firstRow + this.pageSize, this.rows.length);
				}
				else
				{
					firstRow = 0;
					lastRow = this.rows.length;
				}

				this.tableClass = this.gxCssClass;
				this.evenRowClass = this.gxEvenLinesClass;
				this.oddRowClass = this.gxOddLlinesClass;
				this.headerClass = this.gxTitleClass;
				this.columnHeaderClass = this.headerClass;
				this.columnHeaderTextClass = this.headerClass;
				this.evenRowCellClass = this.evenRowClass;
				this.oddRowCellClass = this.oddRowClass;

				var tblClassAtt = "";
				
				if (this.gxHtmlTags.indexOf("class=") == -1)
					tblClassAtt = " class=\"" + this.gxCssClass + "\"";

				var tblStyleAtt = "";
				if (!gx.lang.emptyObject(this.gxBackground))
				{
					tblStyleAtt += ";background-image:url('" + gx.util.resourceUrl(this.gxBackground, true) + "');";
				}
				if (!gx.lang.emptyObject(this.gxBorderWidth))
				{
					tblStyleAtt += ";border: solid " + this.gxBorderWidth + "px ";
				}
				if (!gx.lang.emptyObject(this.gxBordercolor))
				{
					tblStyleAtt += this.gxBordercolor + ";";
				}
				else
					tblStyleAtt += ";";
					
				if (this.ownerGrid.width > 0)
				{
					tblStyleAtt += "width:" + this.ownerGrid.width + this.ownerGrid.widthUnit + ";";
				}

				if (this.gxAllowCollapsing)
				{
					buffer.append("<table><tr valign=\"top\"><td>"),
					buffer.append("<img style=\"cursor:pointer;\" src=\"");
					if (this.gxCollapsed)
					{
						tblStyleAtt = "display:none;";
						buffer.append(gx.util.resourceUrl(gx.basePath + this.imgsDir + "expand.gif", true));
					}
					else
					{
						buffer.append(gx.util.resourceUrl(gx.basePath + this.imgsDir + "collapse.gif", true));
					}
					buffer.append("\" onclick=\"" + this.gridObject() + ".expandCollapse(this, event);" + "\"></td><td width=\"100%\">");
				}
				
				buffer.append("<table " + tblClassAtt + " id=\"" + this.gxCmpContext + this.gxGridObject + "Tbl" + "\" ");
				if (!gx.lang.emptyObject(this.gxToolTipText))
				{
				 	buffer.append("title=\"" + this.gxToolTipText + "\" ");
				}

				var styleRegex = /style="([^"]*)"/ig;
				var styleMatches = styleRegex.exec(this.gxHtmlTags);
				var styleValue = "";
				if (styleMatches && styleMatches.length > 1)
				{
					styleValue = styleMatches[1];
				}

				styleValue += tblStyleAtt;

				buffer.append("style=\"");
				buffer.append(styleValue);
				buffer.append("\" " + this.gxHtmlTags.replace(styleRegex, "") + ">");

				if (!gx.lang.emptyObject(this.headerText))
				{
					buffer.append("<tr><td colspan=\"" + renderedColumnCount + "\" class=\"" + this.headerClass + "\">" + this.headerText + "</td></tr>");
				}
				var colsLen = visibleColumnsArray.length;
				if(!this.gxIsFreestyle)
				{
					buffer.append("<tr>");
					
					this.appendDeleteHeader( buffer, gx.grid.deletePositions.left);
					
					var ascLabelSrc = gx.util.resourceUrl(gx.basePath + gx.staticDirectory + "asc.gif", true);
					var descLabelSrc = gx.util.resourceUrl(gx.basePath + gx.staticDirectory + "desc.gif", true);
					var cHIndex = 0;
					
					for (var i = 0; i < colsLen; i++)
					{       
						var column = visibleColumnsArray[i];
							
						buffer.append("<th nowrap=\"nowrap\" class=\"" + this.columnHeaderClass + "\"");
						var headerStyle = '';
						if (!gx.lang.gxBoolean(column.visible))
							headerStyle += 'display:none;';
						if (column.width != "")
						{
							if (column.gxWidthUnit == '')
								column.gxWidthUnit = 'px';
							headerStyle += "width:" + column.width + column.gxWidthUnit + ";";
						}
						if (column.align != '')
							headerStyle += "text-align:" + column.align + ";";
						if (!gx.lang.emptyObject(this.gxTitleBackColor) && (this.gxTitleBackstyle == gx.grid.styles.header || this.gxTitleBackstyle == gx.grid.styles.report))
						{
							headerStyle += "background-color:" + this.gxTitleBackColor + ";";
							this.gxRealTitleBackColor = this.gxTitleBackColor;
						}
						if (!gx.lang.emptyObject(this.gxBackColor) && (this.gxTitleBackstyle == gx.grid.styles.uniform))
						{
							headerStyle += "background-color:" + this.gxBackColor + ";";
							this.gxRealTitleBackColor = this.gxBackColor;
						}
						if (!gx.lang.emptyObject(this.gxTitleForeColor))
						{
							headerStyle += "color:" + this.gxTitleForeColor + ";";
						}        	        
						if (!gx.lang.emptyObject(this.gxTitleFont))
						{
							headerStyle += this.gxTitleFont;
						}
						buffer.append(" style=\"" + headerStyle)
						buffer.append(" colindex=\"" + cHIndex + "\"");
						buffer.append(">");
                                       
						cHIndex++;                
						
						if (gx.lang.emptyObject(gx.text.trim(column.title)))
						{
							buffer.append("&nbsp;");
						}
						else
						{
							buffer.append("<span");
							if (column.gxTooltip != undefined && column.gxTooltip != '')
							{
								buffer.append(" title=\"" + column.gxTooltip + "\"");
							}
							var headerStyle = "";
							if (column.sortable)
							{
								headerStyle = cursorPointer;
								buffer.append(" onclick=\"" + this.gridObject() + ".grid.setSort(" + column.index + ");\" onMouseOver=\"window.status='" + this.sortMessage + "';return true;\" onMouseOut=\"window.status='';return true;\"");
							}
							buffer.append("\">");
							
							buffer.append(column.title);
							
							this.ascLabel.src = ascLabelSrc;
							this.descLabel.src = descLabelSrc;
							if (column.sortable && this.sortColumn == column.index)
							{
								buffer.append("&nbsp;" + this.handleLabel(((this.ascSort) ? this.ascLabel : this.descLabel), images));
							}
							buffer.append("</span>");
						}
						buffer.append("</th>");
					}
					
					this.appendDeleteHeader( buffer, gx.grid.deletePositions.right);
					
					buffer.append("</tr>");
				}

				var even = true;
				for (var i = firstRow; i < lastRow; i++)
				{
					var row = this.rows[i];
					var rowDeleted = row.gxDeleted();
					even = !even;
					var rowClass = (even ? this.evenRowClass : this.oddRowClass) + (rowDeleted?' RowDeleted':'');
					if (this.gxIsFreestyle  && !(this.gxTitleBackstyle == gx.grid.styles.report || this.gxTitleBackstyle == gx.grid.styles.uniform))
					{
						rowClass = this.tableClass;
					}
					var trHtml = new gx.text.stringBuffer();

					var gxRowTag = "tr";
					var freestyleRowBreak = hasRowBreaks && this.gxIsFreestyle && (((i>0) && (i%this.gxGridCols == 0)) || ((i==0) && (this.gxGridCols > 0)));
					if(freestyleRowBreak)
					{
						if(i>0)
						{
							buffer.append("</tr>");
						}
						buffer.append("<tr>");
					}
					if (this.gxIsFreestyle)
					{
						gxRowTag = "td";
					}
					if (!this.gxIsFreestyle || (this.gxIsFreestyle && hasRowBreaks))
					{
						trHtml.append("<" + gxRowTag + " id='" + this.gxCmpContext + this.gxGridObject + "Row_" + row.gxId + "'");
						if (this.gxIsFreestyle && hasRowBreaks)
							trHtml.append(" gxrow=\"" + row.gxId.toString() + "\"" + "vAlign=\"" + this.columns[1].gxControl.verticalAlign + "\"");
						else
							trHtml.append(" gxrow=\"" + row.gxId.toString() + "\"");
						if(isGxTrn && (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.menu))
						{
							trHtml.append(" oncontextmenu=\"" + this.gridObject() + ".showContextMenu(this, event);\"");
						}
						if(this.gxAllowSelection && !this.gxIsFreestyle)
						{
							trHtml.append(" onmousedown=\"" + this.gridObject() + ".grid.setRowSelected(this, '" + row.gxId.toString() + "');\"");
						}
						if (isGxTrn)
						{
							trHtml.append(" onkeydown=\"" + this.gridObject() + ".rowKeyPressed(event);\"");
						}
						if (!this.gxIsFreestyle)
						{
							trHtml.append(" class=\"" + rowClass + "\"");
						}
						
						if (this.gxAllowHovering && !row.selected && !this.gxIsFreestyle)
						{
							trHtml.append(" onmouseover=\"" + this.gridObject() + ".grid.startRowHover(this, " + row.id + ");\" onmouseout=\"" + this.gridObject() + ".grid.endRowHover(this, " + row.id + ");\"");
						}
						var rStyle = "";
						var backColor = "";
						if (this.gxTitleBackstyle == gx.grid.styles.report)
							backColor = (even)?this.gxLinesBackcolorEven:this.gxLinesBackcolorOdd;
						if (this.gxTitleBackstyle == gx.grid.styles.header)
							backColor = this.gxLinesBackcolorOdd;
						if (this.gxTitleBackstyle == gx.grid.styles.uniform)
							backColor = this.gxBackColor;
						if (!gx.lang.emptyObject(backColor))
						{
							rStyle = "background-color:" + backColor + ";";
						}
						if (!gx.lang.emptyObject(this.gxLinesFont))
						{
							rStyle += this.gxLinesFont;
						}
						if (rStyle != "")
						{
							trHtml.append(" style=\"" + rStyle + "\" ");
						}
						trHtml.append(">");
						buffer.append(trHtml.toString());
					}
					
					if(this.gxIsFreestyle)
					{
						if (hasRowBreaks)
						{
							buffer.append("<table width='100%' cellspacing='0' cellpadding='0'");
							buffer.append("><tbody>");
						}
						var cellClass = (even ? this.evenRowCellClass : this.oddRowCellClass);
						var colHtmlCode = this.gxBuffer.toString();
						buffer.append(colHtmlCode);
					}
					
					this.appendDeleteImage( buffer, row, gx.grid.deletePositions.left);
	            
					for (var j = 0; j < colsLen; j++)
					{				
						var column = visibleColumnsArray[j];
						var columnDefaultVisible = gx.lang.gxBoolean(column.visible);
						var columnProps = row.gxProps[column.index];
						var columnValue = row.values[column.index];
						
						var gxCtrl = column.gxControl;
						if (this.gxIsFreestyle && gxCtrl.type == gx.html.controls.types.row)
						{
							if (column.index == 0)
							{
								gxCtrl.isFreestyleRow = true;
							}
						}
			          	gxCtrl.grid = this.ownerGrid;
			          	gxCtrl.row = row;
			          	gxCtrl.gridId = this.gxId;
			          	gxCtrl.gridRow = row.gxId;
			          	if (!fromCollection)
			          		gxCtrl.setProperties.apply( gxCtrl, columnProps);
			          	else
			          	{
			          		gxCtrl.value = columnValue;
			          		gxCtrl.id = column.htmlName + "_" + gxCtrl.gridRow;
			          		//Set all column properties (design and runtime properties)
			          	}
			          	if (rowDeleted)
			          	{
			          		gxCtrl.rtEnabled = true;
			          		gxCtrl.enabled = false;
			          	}
			          	if (columnProps.Value)
			          		gxCtrl.value = columnProps.Value;
			          	if (columnProps.FormattedValue)
			          		gxCtrl.formattedValue = columnProps.FormattedValue;
			          	if (columnProps.Values)
			          		gxCtrl.possibleValues = columnProps.Values.v;
						if (this.gxIsFreestyle && gxCtrl.type == gx.html.controls.types.row)
						{
							if (column.index == 0)
							{
								gxCtrl.id = this.gxCmpContext + this.gxGridObject + "Row_" + row.gxId;
								if(isGxTrn && (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.menu))
								{
									gxCtrl.oncontextmenu = this.gridObject() + ".showContextMenu(this, event);";
								}
							}
						}

						if(!this.gxIsFreestyle)
						{
							buffer.append("<td valign=\"" + column.valign + "\"");
							var rowStyle = '';
							if (!columnDefaultVisible)
            							rowStyle += 'display:none;';
							if (column.width != "")
							{
								if (column.gxWidthUnit == '')
									column.gxWidthUnit = 'px';
								rowStyle += "width:" + column.width + column.gxWidthUnit + ";";
							}
							if (column.align != '')
								rowStyle += "text-align:" + column.align + ";";
							if (gxCtrl.style)
								rowStyle += gxCtrl.style;
							if (rowStyle != '')
								buffer.append(" style=\"" + rowStyle + "\" ");
							buffer.append(">");
						}

			      buffer.append(gxCtrl.getHtml());
			      gxCtrl.persistValue();
			          	
						if(!this.gxIsFreestyle)
						{
							buffer.append("</td>");
						}
						if(this.gxIsFreestyle)
						{
							var colHtmlCode = column.buffer.toString();
							buffer.append(colHtmlCode);
						}
				}

				if(this.gxIsFreestyle && hasRowBreaks)
				{
					buffer.append("</tbody></table></td>");
				}
				
				this.appendDeleteImage( buffer, row, gx.grid.deletePositions.right);
			}
        
			if(this.gxIsFreestyle && (this.gxGridCols > 0) && hasRowBreaks)
			{
				buffer.append("</tr>");
			}
      var navBar = "";
      var gxShowNavBar = (isGxTrn || this.hasPagingButtons());
      if (gxShowNavBar) {
	      navBar = this.buildNavigation(renderedColumnCount);
      	buffer.append(navBar);
			}
				
			if (!gx.lang.emptyObject(this.footerText))
			{
				buffer.append("<tr><td colspan=\"" + renderedColumnCount + "\" class=\"" + this.footerClass + "\">" + this.footerText + "</td></tr>");
			}
			
			buffer.append("</table>");
			
			if (this.gxAllowCollapsing)
			{
				buffer.append("</td></tr></table>");
			}
			
			this.container.innerHTML = buffer.toString();
			buffer.clear();
			buffer = null;
		}
    
    this.changePage = function(page) {
        var maxPage = this.getMaxPage();
        page = parseInt(page);
        if (page <= 0) {
            page = 1;
        } else if (page > maxPage) {
            page = maxPage;
        }        
        this.currentPage = page;
        this.render();
    }

    this.setRowSelected = function(rowCtrl, cRow) {
    			if (rowCtrl.gxOriginalBackcolor == undefined)
				rowCtrl.gxOriginalBackcolor = rowCtrl.style.backgroundColor;
			gx.dom.forEachChild( rowCtrl, this, function(cellCtrl) {
				if (cellCtrl.gxOriginalBackcolor == undefined)
					cellCtrl.gxOriginalBackcolor = cellCtrl.style.backgroundColor;
			});
			this.instanciateSelectionVars(cRow);
			var even = false;
			var len = this.rows.length;
			for(var i=0; i<len; i++)
			{
				var row = this.rows[i];
				row.selected = (row.gxId == cRow);
				if(!row.selected)
				{
					var currRowCtrl = gx.dom.el(this.gxCmpContext + this.gxGridObject + "Row_" + row.gxId);
					if ((currRowCtrl != null) && (currRowCtrl.gxSBackcolor != undefined))
					{
						currRowCtrl.style.backgroundColor = currRowCtrl.gxSBackcolor;
						if (gx.util.browser.isIE())
						{
							gx.dom.forEachChild( currRowCtrl, this, function(cellCtrl) {
								if ((cellCtrl != null) && (cellCtrl.gxSBackcolor != undefined))
								{
									cellCtrl.style.backgroundColor = cellCtrl.gxSBackcolor;
								}
							});
						}
					}	
				}
				else
				{
					rowCtrl.gxSBackcolor = (rowCtrl.gxOriginalBackcolor != undefined)?rowCtrl.gxOriginalBackcolor:rowCtrl.style.backgroundColor;
					rowCtrl.style.backgroundColor = this.gxSelectionColor.Html;
					this.instanciateSelectedRow(row);
					if (gx.util.browser.isIE())
					{
						gx.dom.forEachChild( rowCtrl, this, function(cellCtrl) {
							cellCtrl.gxSBackcolor = (cellCtrl.gxOriginalBackcolor != undefined)?cellCtrl.gxOriginalBackcolor:cellCtrl.style.backgroundColor;
							cellCtrl.style.backgroundColor = this.gxSelectionColor.Html;
						});
					}
				}
				even = !even;
			}
		}
		
		this.instanciateSelectionVars = function( rowId)
		{
			gx.setGxO(this.parentGxObject.CmpContext, this.parentGxObject.IsMasterPage);
			gx.fn.setCurrentGridRow( this.gxId, rowId);
			gx.fn.setHidden(this.gxCmpContext + this.gxGridName.toUpperCase() + "_ROW", rowId);
		}
		
		this.instanciateSelectedRow = function(row)
		{
			this.setSelectedRowVars(row);
			if (this.gxOnLineActivate && !this.ownerGrid.isLoading)
			{
				this.parentGxObject[this.gxOnLineActivate].call(this.parentGxObject, row.gxId);
			}
		}
		
		this.setSelectedRowVars = function(row)
		{
			var gxObj = this.parentGxObject;
			var len = this.columns.length;
			for(var i=0; i<len; i++)
			{
				var column = this.columns[i];
				var validStruct = gxObj.GXValidFnc[column.gxId];
				if (validStruct != null)
				{
					var varValue = row.values[i];
					if (this.ownerGrid.isUsercontrol)
					{
						varValue = this.properties[row.id][column.index].value;
					}
					validStruct.v2v(varValue);
				}
			}
		}
		
		this.startRowHover = function(rowCtrl, rowId) {
			if (rowCtrl.gxOriginalBackcolor == undefined)
				rowCtrl.gxOriginalBackcolor = rowCtrl.style.backgroundColor;
			gx.dom.forEachChild( rowCtrl, this, function(cellCtrl) {
				if (cellCtrl.gxOriginalBackcolor == undefined)
					cellCtrl.gxOriginalBackcolor = cellCtrl.style.backgroundColor;
			});
			var row = this.getRowById(rowId);
			if (this.gxAllowHovering && this.gxHoverColor && !row.selected)
			{
				rowCtrl.gxHBackcolor = rowCtrl.style.backgroundColor;
				rowCtrl.style.backgroundColor = this.gxHoverColor.Html;
				if (gx.util.browser.isIE())
				{
					gx.dom.forEachChild( rowCtrl, this, function(cellCtrl) {
						cellCtrl.gxHBackcolor = cellCtrl.style.backgroundColor;
						cellCtrl.style.backgroundColor = this.gxHoverColor.Html;
					});
				}
			}
		}
		
		this.endRowHover = function(rowCtrl, rowId) {
			var row = this.getRowById(rowId);
			if (this.gxAllowHovering && !row.selected)
			{
				if (rowCtrl.gxHBackcolor != undefined)
				{
					rowCtrl.style.backgroundColor = rowCtrl.gxHBackcolor;
					if (gx.util.browser.isIE())
					{
						gx.dom.forEachChild( rowCtrl, this, function(cellCtrl) {
							if (cellCtrl.gxHBackcolor != undefined)
							{
								cellCtrl.style.backgroundColor = cellCtrl.gxHBackcolor;
							}
						});
					}
				}
			}
		}
    
    this.hasPagingButtons = function()
    {
    	return (this.usePaging && (!this.isFirstPage() || !this.isLastPage()));
    }
        
    this.buildNavigation = function(renderedColumnCount) {
        var cursorPointer = "cursor:" + (document.createTextRange ? "hand" : "pointer") + ";";
        var buffer = new gx.text.stringBuffer();
        var rowCount = this.getRowCount();
        var navColSpan = renderedColumnCount;
        this.navigationClass = this.gxTitleClass;
        if(this.gxIsFreestyle && this.gxGridCols > 1)
        {
       		navColSpan = this.gxGridCols;
      	}
	     	if (gx.lang.emptyObject(this.gxRealTitleBackColor))
   	    	buffer.append("<tr><td colspan=\"" + navColSpan + "\" class=\"" + this.navigationClass + "\" style=\"text-align: center;\">");
     		else
     	  	buffer.append("<tr><td colspan=\"" + navColSpan + "\" class=\"" + this.navigationClass + "\" style=\"text-align: center;background-color:" + this.gxRealTitleBackColor + ";\">");
        var linkClass = this.navigationLinkClass;
        var highlightedLinkClass = this.highlightedNavigationLinkClass;
        function buildLink(text, onclick, statusMsg, linkId, onfocusCode) {
        		var linkStr = (linkId != undefined)?"id=\"" + linkId + "\"":"";
            return "<a type='gxlink' onkeydown=\""+onclick+"\" style='text-decoration:none;' tabindex='0' onfocus=\"" + onfocusCode + "\" onblur=\"this.style.textDecoration = 'none';\"><span " + linkStr + 
            						" style=\"" + cursorPointer + "\" class=\"" + linkClass + "\" onclick=\"" + onclick + "\" " +
                        "onMouseOver=\"this.className='" + highlightedLinkClass + "';window.status='" + statusMsg + "';return true;\" " +
                        "onMouseOut=\"this.className='" + linkClass + "';window.status='';return true;\">" + text + "</span></a>";
        }
        
        var isIE = gx.util.browser.isIE();
        var btnStyle = "style=\"padding-left:20px;padding-bottom:5px;\""; //It is in the default Themes now. It is here just for older kbs.
       
        function buildPagingButton( CSSClass, OnClick)
        {
        	return "<span class=\"" + CSSClass + "\" onclick=\"" + OnClick + "\" " + btnStyle + ">&nbsp;&nbsp;</span>";
        }

        if (rowCount > 0) {
            if (this.usePaging) {
	          if (!isIE) buffer.append("<div>");
	          
        	  if (this.currentPage <= 0)
        	  {
        	  	this.currentPage = 1;
        	  }
				var maxPage = this.getMaxPage();
				if (!this.isFirstPage()) 
				{
					buffer.append(buildPagingButton( "PagingButtonsFirst", this.getPaginEvent("FIRST")));
					buffer.append(buildPagingButton( "PagingButtonsPrevious", this.getPaginEvent("PREV")));
				}
				if (!this.isLastPage()) 
				{
					buffer.append(buildPagingButton( "PagingButtonsNext", this.getPaginEvent("NEXT")));
					buffer.append(buildPagingButton( "PagingButtonsLast", this.getPaginEvent("LAST")));
				}
                if (!isIE) buffer.append("</div>&nbsp;");
            } 
        }
        if(this.isGxTrn() && !this.gxHasAddlines && (this.parentGxObject.Gx_mode != 'DSP'))
        {
        	buffer.append(buildLink("["+this.gxNewRowText+"]", this.gridObject()+".getNewRows(1,event);",this.gxNewRowText, this.gxGridObject + "_NewRow", this.gridObject()+".gxNewRowFocused(this);"));
      	}
        buffer.append("</td></tr>");
        return buffer.toString();
    }
    
    this.isLastPage = function()
    {
    	var isEOF = this.eof;
    	return (isEOF != "0");
    }
    
    this.isFirstPage = function()
    {
    	var isFirst = gx.lang.emptyObject(this.firstRecordOnPage)?"0":this.firstRecordOnPage;
    	return (isFirst == "0");
    }
    
    this.getPaginEvent = function(EventName)
    {
    	var hiddenName = this.gxGridName.toUpperCase() + "PAGING";
    	return "javascript:gx.fn.setHidden('" + this.gxCmpContext + hiddenName + "','" + EventName + "');gx.evt.execEvt('" + this.gxCmpContext + "E" + hiddenName + ".', gx.evt.dummyCtrl);";
    }
    
    this.getWebImageTag = function(source)
    {
    		return "<img border=\"0\" src=\"/" + this.basePath + this.imgsDir + source.toString() + "\"/>";
    }
    
    var imgId = 0;
    this.handleLabel = function(label, images) {
        if (label.src) {
            var id = "img" + imgId;
            imgId++;
            return "<img name='" + id + "' border='0' src='" + label.src + "'>";
        } else {
            return label;
        }
    }
    
    this.sort = function(row1, row2) {

				if(row1.table.isGxTrn())
				{
	    		if((!row1.gxExists() && !row2.gxExists()) && (!row1.gxIsMod() && !row2.gxIsMod()))
	    		{
	    			return 0;
	    		}
	    		else if((!row1.gxExists() && row2.gxExists()) || (!row1.gxIsMod() && row2.gxIsMod()))
	    		{
	    			return 1;
	    		}
	    		else if((row1.gxExists() && !row2.gxExists()) || (row1.gxIsMod() && !row2.gxIsMod()))
	    		{
	    			return -1;
	    		}
    		}
    		    		
        var theGrid = row1.table;
        var column = theGrid.getColumnByIndex(theGrid.sortColumn);
        var type = column.type;
        var value1, values2;
        
        values1 = row1.values[theGrid.sortColumn];
        values2 = row2.values[theGrid.sortColumn];
        
        if (!gx.lang.instanceOf(values1, Array)) {
            values1 = [values1];
        }
        if (!gx.lang.instanceOf(values2, Array)) {
            values2 = [values2];
        }

        var prepare;
        switch (column.type) {
            case gx.types.numeric:
                prepare = function(value) {
                	  value=gx.num.parseFloat(value, gx.thousandSeparator, gx.decimalPoint);
                    if (isNaN(value)) {
                        value = 0;
                    }
                    return value;
                }
                break;
            case gx.types.date:
            case gx.types.dateTime:
                prepare = function(value) {
                		try{value=new gx.date.gxdate(value).Value;}
                		catch(e)
                		{
                			gx.dbg.logEx(e, 'JSTable.js', 'sort');
                		}
                    return value.valueOf();
                }
                break;
            case gx.types.bool:
                prepare = function(value) {
                    return gx.lang.booleanValue(value) ? 1 : 0;
                }
                break;
            case gx.types.character:
            default:
                prepare = function(value) {
                    return String(value).replace(/\<[^\>]*\>/g,"").toUpperCase();
                }
                break;
        }
        
        var maxIndex = Math.max(values1.length, values2.length);
        var comp = 0;
        for (var i = 0; (comp == 0) && (i < maxIndex); i++) {
            var var1 = values1[i];
            if (var1 == null) {
                comp = -1;
            }
            var var2 = values2[i];
            if (var2 == null) {
                comp = 1;
            }
            if (comp == 0) {
                var1 = prepare(var1);
                var2 = prepare(var2);
                comp = (var1 == var2) ? 0 : (var1 > var2) ? 1 : -1;
            }
            if (comp != 0) {
                comp *= (theGrid.ascSort ? 1 : -1);
            }
        }
        return comp;
    }
};

gx.grid.column = function(title, type, width, align, valign) {
    this.table = null;
    this.index = -1;
    this.title = title || "";
    this.type = (typeof(type) != 'undefined')?type:gx.types.character;
    this.width = width || "";
    this.align = align || 'left';
    this.valign = valign || 'middle';
    this.htmlName = null;
    this.visible = true;
    this.enabled = true;
    this.sortable = true;
    this.colspan = 1;
    this.rowspan = 1;
    this.gxId = -1;
    this.gxAttId = -1;
    this.gxAttName = "";
    this.gxWidthUnit = '';
    this.gxChecked = undefined;
    this.gxUnChecked = undefined;
    this.buffer = new gx.text.stringBuffer();
    this.isGxRemove = function() {
        if (this.gxAttName)
            return (this.gxAttName.indexOf("GxRemove") != -1) || (this.gxAttName.indexOf("nRcdDeleted") != -1);
        else
            return false;
    }
};

gx.grid.row = function(id, rowProps, rowId, parentRowId) {
    this.table = null;
    this.id = id;
    this.gxParentRowId = parentRowId || "";
    this.gxId = rowId + this.gxParentRowId;
    this.gxCmpContext = "";
    this.values = [];
    this.selected = false;
    this.gxLvl = 0;
    this.gxProps = rowProps.Props || [];
    this.gxRenderProps = rowProps.RenderProps || [];
    this.gxGrids = [];
    this.gxKeyValues = [];
       
    this.gxExists = function() {
  		var rowExistCtrlValue = gx.fn.getHidden(this.gxCmpContext + "nRcdExists_"+this.gxLvl+"_"+this.gxId);
  		if(rowExistCtrlValue != null)
  		{
  			return (rowExistCtrlValue != 0);
  		}
  		return false;
    }
    
    this.gxIsMod = function() {
  		var rowIsModCtrlValue = gx.fn.getHidden(this.gxCmpContext + "nIsMod_"+this.gxLvl+"_"+this.gxId);
  		if(rowIsModCtrlValue != null)
  		{
  			return (rowIsModCtrlValue != 0);
  		}
  		return false;
    }
    
    this.gxDeleted = function() {
  		var rowDeletedCtrlValue = gx.fn.getHidden(this.gxCmpContext + "nRcdDeleted_"+this.gxLvl+"_"+this.gxId);
  		if(rowDeletedCtrlValue != null)
  		{
  			return (rowDeletedCtrlValue != 0);
  		}
  		return false;
    }
    
    this.setDeleted = function(boolDel) {
    		var intDel = (boolDel?1:0);
    		gx.fn.setHidden(this.gxCmpContext + "nRcdDeleted_"+this.gxLvl+"_"+this.gxId, intDel);
    }
};
/* END OF FILE - JavaScripTable.js - */
/* START OF FILE - gxfrmutl.js - */
gx.GxObject = function()
{
	this._isTrn = null;
	this.Gx_mode = "";
	this.ServerClass = "";
	this.ReadonlyForm = false;
	this.ObjectType = "web";
	this.MasterPage = null;
	this.IsMasterPage = false;
	this.IsComponent = false;
	this.AjaxSecurity = gx.ajax.securityLevels.high;
	this.JustCreated = false;
	this.CmpContext = "";
	this.WebComponents = [];
	this.Grids = [];
	this.UserControls = [];
	this.GridUCsProps = {};
	this.GridUCsEvts = {};
	this.UCBindings = [];
	this.GXValidFnc = [];
	this.GXLastCtrlId = 0;
	this.GXCtrlIds = [];
	this.MsgList = [];
	this.CmpControls = [];
	this.VarControlMap = [];
	this.FormBCs = [];
	this.LvlOlds = [];
	this.ServerEvents = [];
	this.hasEnterEvent = false;
	this.autoRefresh = false;
	this.conditionsChanged = false;
	
	this.setObjectType = function( Type)
	{
		this.ObjectType = Type;
	}
	
	this.getObjectType = function()
	{
		return this.ObjectType;
	}
	
	this.isTransaction = function()
	{
		if (this._isTrn != null)
		{
			return this._isTrn;
		}
		this._isTrn = (this.getObjectType() == 'trn');
		return this._isTrn;
	}
	
	this.setAjaxSecurity = function( level)
	{
		switch( level)
		{
			case 'Medium':
				this.AjaxSecurity = gx.ajax.securityLevels.medium;
				break;
			case 'Low':
				this.AjaxSecurity = gx.ajax.securityLevels.low;
				break;
			default:
				this.AjaxSecurity = gx.ajax.securityLevels.high;
				break;
		}
	}
	
	this.addKeyListener = function( fKey, evt)
	{
		gx.evt.addKeyListener( this.CmpContext, fKey, evt);
	}
	
	this.clearMessages = function()
	{
		this.MsgList.length = 0;
	}
	
	this.addMessage = function( Msg)
	{
		this.MsgList.push( Msg);
	}
	
	this.showMessages = function()
	{
		var msgsArr = [];
		var len = this.MsgList.length;
		for(var i=0; i<len; i++)
		{
			msgsArr.push( {att:'',type:2,text:this.MsgList[i]});
		}
		var msgs = {};
		var msgsKey = (this.CmpContext == '')?'MAIN':this.CmpContext;
		msgs[msgsKey] = msgsArr;
		gx.fn.setErrorViewer( msgs);
		this.clearMessages();
	}
	
	this.setPrompt = function( CtrlId, Deps)
	{
		gx.fn.attachCtrl( CtrlId, {isPrompt:true, wc:this.CmpContext, mp:this.IsMasterPage, controls:Deps});		
	}
	
	this.readServerVars = function()
	{
		if (!gx.lang.emptyObject(gx.csv.lastEvtResponse))
		{
			var objValues = [];
			var vals = gx.csv.lastEvtResponse.gxValues;
			var len = vals.length;
			for (var i=0; i<len; i++)
			{
				var objV = vals[i];
				if (objV.CmpContext == this.CmpContext && gx.lang.booleanValue(objV.IsMasterPage) == this.IsMasterPage)
				{
					objValues.push(objV);
					break;
				}
			}
			gx.fn.setPostValues( objValues);
		}
	}
	
	this.refreshInputs = function( Inputs)
	{
		var len = Inputs.length;
		for(var i=0; i<len; i++)
		{
			var inObj = Inputs[i];
			var validStruct = this.getValidStructFld(inObj[1]);
			if(validStruct != null)
				validStruct.c2v();
		}
	}
	
	this.refreshOutputs = function( Outputs)
	{
		var len = Outputs.length;
		for(var i=0; i<len; i++)
		{
			var outObj = Outputs[i];
			if (outObj.fld)
			{
				var validStruct = this.getValidStructFld(outObj.fld);
				if(validStruct != null)
				{
					validStruct.v2c();
				}
				else
				{
					var varValue = this.getVariable( outObj.av);
					if (varValue != null && typeof(varValue) == 'object')
					{
						var formBC = this.getFormBCForVar( outObj.av);
						if (formBC != null)
						{
							this.bcToScreen( formBC,  varValue);
						}
						var boundGrid = this.getGridForColl( outObj.av);
						if (boundGrid)
						{
							boundGrid.refreshCollection(varValue);
						}
					}
					gx.fn.setHidden( outObj.fld, varValue);
				}
			}
			else if (outObj.ctrl)
			{
				if (gx.uc.isUserControl(outObj.ctrl))
					outObj.ctrl.execShowFunction();
			}
		}
		this.showMessages();
	}
	
	this.refreshServerOutputs = function( Outputs)
	{
		var len = Outputs.length;
		for(var i=0; i<len; i++)
		{
			var outObj = Outputs[i];
			var hiddenValue = gx.fn.getHidden( this.CmpContext + outObj.fld);
			if (hiddenValue != undefined)
			{
				var vStruct = this.getValidStructFld(outObj.fld);
				if (vStruct)
				{
					vStruct.v2v(hiddenValue);
					vStruct.v2c();
				}
				else
				{
					this.setVariable( Outputs[i].av, hiddenValue);
				}
			}
		}
	}
	
	this.getContextObject = function( ControlId)
	{
		var validStruct = this.getValidStructFld(ControlId);
		if(validStruct != null)
		{
			var Value = gx.fn.getControlValue_impl( this.CmpContext + ControlId);
			if (Value != null)
				return Value;
		}
		return "";
	}
	
	this.getValidStructId = function( Fld)
	{
		if (!gx.lang.emptyObject(Fld))
		{
			var ctrlIds = this.getControlIds();
			for (var i=0;i<ctrlIds.length;i++)
			{
				validStruct = this.getValidStruct(ctrlIds[i]);
				if (this.isSameField(validStruct, Fld))
					return ctrlIds[i];
			}
		}
		return -1;
	}
	
	this.getValidStructFld = function( Fld)
	{
		if (!gx.lang.emptyObject(Fld))
		{
			var ctrlIds = this.getControlIds();
			var len = ctrlIds.length;
			for (var i=0;i<len;i++)
			{
				var validStruct = this.getValidStruct(ctrlIds[i]);
				if (this.isSameField(validStruct, Fld))
					return validStruct;
			}
		}
		return null;
	}
	
	this.isSameField = function( validStruct, TestFld)
	{
		var Fld = validStruct.fld;
		if (Fld == TestFld)
		{
			return true;
		}
		if (this.IsComponent)
		{
			var ctxIdx = TestFld.indexOf( this.CmpContext);
			if (ctxIdx == 0)
				TestFld = TestFld.substring(this.CmpContext.length);
		}
		if (validStruct.grid != 0)
		{
			var regEx = /^([\s\S]+)_((?:[0-9]{4})*)/;
			var parts = regEx.exec( TestFld);
			if (parts && parts.length == 3)
			{
				TestFld = parts[1];
			}
		}
		return (Fld == TestFld);
	}
	
	this.getUserFocus = function()
	{
		var usrFocusId = gx.fn.getControlValue(this.CmpContext + 'GX_FocusControl');
		if (gx.lang.emptyObject(usrFocusId))
		{
			if(this.hasMasterPage())
			{
				usrFocusId = this.MasterPage.getUserFocus();
				if (!gx.lang.emptyObject(usrFocusId))
					return usrFocusId;
			}
			for (var i=this.WebComponents.length-1; i>=0; i--)
			{
				usrFocusId = this.WebComponents[i].getUserFocus();
				if (!gx.lang.emptyObject(usrFocusId))
					return usrFocusId;
			}
		}
		return usrFocusId;
	}
	
	this.hasMasterPage = function()
	{
		return (this.MasterPage != null);
	}
	
	this.setComponent = function( CmpCtrl)
	{
		this.CmpControls[CmpCtrl.id.toLowerCase()] = CmpCtrl;
	}
	
	this.getComponentPrefix = function( CtrlName)
	{
		var wc = this.getComponentData( CtrlName);
		if (wc)
		{
			return (wc.Prefix || '');
		}
		return '';
	}
	
	this.getComponentData = function( CtrlName)
	{
		return this.CmpControls[CtrlName.toLowerCase()];
	}
	
	this.createWebComponent = function( CtrlName, PgmName, Parms, Row, TargetCtrlId, CmpPrefix)
	{
		var gRow = Row || '';
		var Prefix = CmpPrefix || this.getComponentPrefix( CtrlName);
		var srvResponse = gx.ajax.dynComponent( PgmName, Parms, Prefix, gRow);
		if (!srvResponse.DynComponentMap)
		{
			srvResponse.DynComponentMap = {};
		}
		srvResponse.DynComponentMap[CmpPrefix] = TargetCtrlId;
		gx.ajax.setPostResponse(srvResponse);
	}
	
	this.setWebComponent = function( gxComponent)
	{
		this.deleteComponent(gxComponent.CmpContext, gxComponent);
		this.WebComponents[gxComponent.CmpContext] = gxComponent;
		this.WebComponents.push(gxComponent);
		gxComponent.JustCreated = true;
	}
	
	this.getWebComponent = function( cmpCtx)
	{
		return this.WebComponents[cmpCtx];
	}
	
	this.deleteComponent = function( cmpCtx, newCompObj)
	{
		var cmpObj = this.getWebComponent( cmpCtx);
		if (cmpObj)
		{
			gx.fn.deleteHidden( cmpCtx);
			if (!gx.lang.emptyObject( newCompObj))
				gx.fn.setHidden( newCompObj.CmpContext, newCompObj.ServerClass);
			cmpObj.ondestroy();
			delete this.WebComponents[cmpCtx];
			var len = this.WebComponents.length;
			for (var i=0; i<len; i++)
			{
				if (this.WebComponents[i].CmpContext == cmpCtx)
				{
					this.WebComponents.removeAt(i);
					break;
				}
			}
			var localArray = this.WebComponents;
			for (var currentCtx in localArray)
			{
				if (isNaN(parseInt(currentCtx)))
				{
					if (currentCtx.indexOf(cmpCtx) == 0)
					{
						this.deleteComponent(currentCtx);
					}
				}
			}
		}
	}
	
	this.setCmpContext = function( cmpCtx)
	{
		if (cmpCtx != undefined)
		{
			if (cmpCtx != '')
				this.IsComponent = true;
			this.CmpContext = cmpCtx;
		}
	}
	
	this.getOldLvl = function( Name)
	{
		for (var lvl in this.LvlOlds)
		{
			var lvlOlds = this.LvlOlds[lvl];
			var len = lvlOlds.length;
			for( var i=0; i<len; i++)
			{
				if (lvlOlds[i] == Name)
					return lvl;
			}
		}
		return -1;
	}
	
	this.refreshDependantGrids = function( validStruct)
	{
		var len = this.Grids.length;
		for(var i=0;i<len;i++)
		{
			var gxGrid = this.Grids[i];
			var refreshVars = gxGrid.refreshVars;
			var len1 = refreshVars.length;
			for( var j=0; j<len1; j++)
			{
				if (refreshVars[j].fld == validStruct.fld)
				{
					gxGrid.filterVarChanged();
					break;
				}
			}
		}
	}
	
	this.setGrid = function( gxGrid)
	{
		this.Grids[gxGrid.gridName] = gxGrid;
		this.Grids.push(gxGrid);
	}
	
	this.getGrid = function( gridName)
	{
		return this.Grids[gridName];
	}
	
	this.getGridById = function( gridId)
	{
		var len = this.Grids.length;
		for(var i=0;i<len;i++)
		{
			var gxGrid = this.Grids[i];
			if (gxGrid.gridId == gridId)
				return gxGrid;
		}
		return null;
	}
	
	this.getGridForColl = function( collVarName)
	{
		var len = this.Grids.length;
		for(var i=0;i<len;i++)
		{
			var gxGrid = this.Grids[i];
			if (gxGrid.boundedCollName == collVarName)
				return gxGrid;
		}
		return null;
	}
	
	this.getFormBCForVar = function( varName)
	{
		for (var bcName in this.FormBCs)
		{
			var bc = this.FormBCs[bcName];
			if (bc && bc.gxvar == varName)
				return bc;
		}
		return null;
	}
	
	this.getFormBC = function( bcName)
	{
		var bcName1 = bcName;
		if (this.IsComponent)
		{
			var ctxIdx = bcName.indexOf( this.CmpContext);
			if (ctxIdx == 0)
				bcName1 = bcName.substring(this.CmpContext.length);
		}
		return this.FormBCs[bcName1];
	}
	
	this.addBCProperty = function( bcName, bcProp, vStruct, bcVarName)
	{
		var bc = this.getFormBC( bcName);
		if (typeof(bc) == 'undefined')
		{
			bc = {};
			bc.gxvar = bcVarName;
			this.FormBCs[bcName] = bc;
		}
		if (bcProp instanceof Array)
		{
			var obj = bc;
			var len = bcProp.length;
			for (var i=0; i<len; i++)
			{
				if (typeof(obj[bcProp[i]]) == 'undefined')
				{
					if (i < len -1)
					{
						obj[bcProp[i]] = {};
					}
					else
					{
						obj[bcProp[i]] = vStruct;
						if (typeof(this[bcVarName]) == 'object')
						{
							vStruct.v2bc = function() {
								var propValue = this[vStruct.gxvar];
								if (vStruct.type == 'date')
								{
									var dateObj = new gx.date.gxdate(propValue);
									propValue = dateObj.getString('Y4MD');
								}
								this.valueToBCProp( this[bcVarName], bcProp, propValue);
							};
						}
						break;
					}
				}
				obj = obj[bcProp[i]];
			}
		}
		else if (typeof(bcProp) == 'string')
		{
			bc[bcProp] = vStruct;
		}
	}
	
	this.valueToBCProp = function( bc, bcProp, pValue)
	{
		try
		{
		    var obj = bc;
		    var len = bcProp.length;
		    for (var i=0; i<len; i++)
		    {
			    if (typeof(obj[bcProp[i]]) == 'object')
			    {
				    obj = obj[bcProp[i]];
			    }
			    else
			    {
				    obj[bcProp[i]] = pValue;
				    break;
			    }
		    }
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'valueToBCProp');
		}
	}
	
	this.bcToScreen = function( bc, data)
	{
		for ( var prop in bc)
		{
			if (prop == 'gxvar')
			{
				continue;
			}
			try
			{
				if (typeof(data[prop]) == 'object')
				{
					this.bcToScreen( bc[prop], data[prop]);
				}
				else
				{
					var vStruct = bc[prop];
					if (vStruct.grid == 0)
					{
						vStruct.v2v( data[prop]);
						vStruct.v2c();
					}
				}
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxfrmutl.js', 'bcToScreen');
			}
		}
	}
	
	this.addGridUCEventHandler = function( CtrlName, EvtName, EvtHandler)
	{
		if (gx.lang.emptyObject(this.GridUCsEvts[CtrlName]))
			this.GridUCsEvts[CtrlName] = [];
		this.GridUCsEvts[CtrlName].push({e:EvtName, h:EvtHandler});
	}
	
	this.getGridUCEventHandlers = function( CtrlName)
	{
		var handlers = this.GridUCsEvts[CtrlName];
		if (gx.lang.emptyObject(handlers))
			return [];
		return handlers;
	}
	
	this.setGridUCDynProperty = function( CtrlName, PropName, HiddenName, PropType)
	{
		this.setGridUCProperty( CtrlName, PropName, HiddenName, undefined, PropType);
	}
	
	this.setGridUCProperty = function( CtrlName, PropName, HiddenName, Value, PropType)
	{
		if (gx.lang.emptyObject(this.GridUCsProps[CtrlName]))
			this.GridUCsProps[CtrlName] = [];
		this.GridUCsProps[CtrlName].push({p:PropName, h:HiddenName, v:Value, t:PropType});
	}
	
	this.getGridUCProperties = function( CtrlName)
	{
		var props = this.GridUCsProps[CtrlName];
		if (gx.lang.emptyObject(props))
			return [];
		return props;
	}
	
	this.addUsercontrolBinding = function( VarName, CtrlName)
	{
		this.UCBindings[VarName] = CtrlName;
	}
	
	this.setUserControl = function( gxUC)
	{
		this.UserControls[gxUC.ContainerName] = gxUC;
		this.UserControls.push(gxUC);
	}
	
	this.getUserControl = function( cName)
	{
		var uc = this.UserControls[cName];
		if (!uc && this.CmpContext != '')
		{
			uc = this.UserControls[this.CmpContext + cName];
		}
		return uc;
	}
		
	this.execV2CFunctions = function(Show)
	{
		var len = this.UserControls.length;
		for(var i=0;i<len;i++)
		{
			var uc = this.UserControls[i];
			try
			{
				uc.execV2CFunctions();
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxfrmutl.js', 'execV2CFunctions');
			}
			
			if (Show == true)
			{
				try
				{
					uc.execShowFunction();
				}
				catch(e)
				{
					gx.dbg.logEx(e, 'gxfrmutl.js', 'execV2CFunctions');
				}
			}
		}
	}
	
	this.execC2VFunctions = function()
	{
		var len = this.UserControls.length;
		for(var i=0;i<len;i++)
		{
			try{this.UserControls[i].execC2VFunctions();}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxfrmutl.js', 'execC2VFunctions');
			}
			try{this.UserControls[i].saveProperties();}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxfrmutl.js', 'execC2VFunctions');
			}
		}
	}

	this.setMode = function()
	{
		gx.fn.setHidden(this.CmpContext+"_MODE", this.Gx_mode);
		gx.fn.setHidden(this.CmpContext+"Mode", this.Gx_mode);
	}
	
	this.setVariable = function( VarName, Value)
	{
	    this[VarName] = Value;
	    FormattedValue = Value;
		if (VarName.indexOf(this.CmpContext) != 0)
			gx.fn.setHidden( this.CmpContext + VarName, Value);
		if (this.VarControlMap[VarName] != undefined)
		{
			var type = this.VarControlMap[VarName].type;
			if (type == "date" || type == "dtime")
			{
				if (typeof(Value) == "string")
				{
				    FormattedValue = new gx.date.gxdate(Value);
				}
				if (Value instanceof gx.date.gxdate)
				{
				    FormattedValue = Value.getStringWithFmt("Y4MD");
				}
            }
			if (type == "decimal" && gx.decimalPoint != '.') 
			{
			    FormattedValue = Value.toString().replace('.', gx.decimalPoint);
			}
            gx.fn.setHidden(this.CmpContext + this.VarControlMap[VarName].id, FormattedValue);
		}
		if (VarName == "Gx_mode")
			this.setMode();
		if (this.UCBindings[VarName] != undefined)
			gx.fn.setHidden( this.CmpContext + this.UCBindings[VarName], Value);
	}
	
	this.getVariable = function( VarName)
	{
		return this[VarName];
	}
	
	this.isServerEvent = function( EvtName)
	{
		var len = this.ServerEvents.length;
		for (var i=0; i<len; i++)
		{
			if (this.ServerEvents[i] == EvtName)
			{
				return true;
			}
		}
		return false;
	}
	
	this.setEventParameters = function( ParmsData, Values)
	{
		gx.csv.lastEvtRow = null;
		gx.O = this;
		var allSameGrid = true;
		var pGrid = -1;
		gx.csv.cmpCtx = this.CmpContext;
		var len = ParmsData.length;
		for (var i=0; i<len; i++)
		{
			var ParmName = ParmsData[i][0];
			var CtrlName = ParmsData[i][1];
			var VarName = ParmsData[i][2];
			var found = false;
			for (var valProp in Values)
			{
				if (valProp.toLowerCase() == ParmName.toLowerCase())
				{
					this.setVariable( VarName, Values[valProp]);
					found = true;
					break;
				}
			}
			if (!found)
				this.setVariable( VarName, Values);
			var validStruct = this.getValidStructFld(CtrlName);
			if(validStruct != null)
			{
				if ((validStruct.grid != 0) && (pGrid == -1))
					pGrid = validStruct.grid;
				else if ((validStruct.grid != 0) && (validStruct.grid != pGrid))
					allSameGrid = false;
				validStruct.v2c();
			}
			else
				gx.fn.setHidden( this.CmpContext + CtrlName, this.getVariable(VarName));
		}
		if (allSameGrid)
			gx.csv.lastEvtRow = gx.fn.currentGridRowImpl(pGrid);
	}
	
	this.executeServerEvent = function( EvtName, Synch, EvtRow)
	{
		gx.O = this;
		gx.csv.cmpCtx = this.CmpContext;
		var synchReq = true;
		if ((Synch != undefined) && (Synch == false))
			synchReq = false;
		var row = (typeof(EvtRow) == 'string')?EvtRow:'';
		if (!gx.lang.emptyObject(gx.csv.lastEvtRow))
			row = gx.csv.lastEvtRow;
		if ((row == '') && (!gx.lang.emptyObject(gx.csv.validatingGrid)))
			row = gx.csv.lastRow[gx.csv.validatingGrid.gridId];
		var evtName = this.CmpContext + "E" + EvtName + "." + row;
		gx.evt.execEvt(evtName, gx.evt.dummyCtrl, synchReq);
	}
	
	this.executeEnterEvent = function( evt, ctrl)
	{
		if (gx.evt.cancelAndRefresh( evt))
		{
			return;
		}
		if (gx.dom.hasSubmitControl())
		{
			gx.evt.cancel( evt, true);
		}
		if (ctrl && ctrl.nodeName == 'INPUT' && (ctrl.type == 'text' || ctrl.type == 'password'))
		{
			gx.evt.cancel( evt, true);
		}
		var gxOEnter = this.gxOWithEnter();
		if (gxOEnter != null)
		{
			gx.evt.enter = true;
			var enterName = 'ENTER';
			if (gxOEnter.IsMasterPage)
				enterName = enterName + '_MPAGE';
			enterName = gxOEnter.CmpContext + 'E' + enterName + '.';
			gx.evt.execEvt( enterName, gx.evt.dummyCtrl);
			gx.evt.enter = false;
			gx.evt.cancel( evt, true);
		}
	}
	
	this.gxOWithEnter = function()
	{
		if (this.hasEnterEvent)
		{
			return this;
		}
		else if(this.IsComponent)
		{
			var cmpRegex = /((?:(?:MP)?W[0-9]{4})*)((?:MP)?W[0-9]{4})/
			var cmpType = cmpRegex.exec(this.CmpContext);
			var isMPage = ((cmpType[1] == '') && (cmpType[0].indexOf('MP') == 0));
			var parent = gx.getObj( cmpType[1], isMPage);
			if (!gx.lang.emptyObject(parent))
			{
				return parent.gxOWithEnter();
			}
		}
		else if(this.hasMasterPage())
		{
			return this.MasterPage.gxOWithEnter();
		}
		return null;
	}
	
	this.getLastControlId = function()
	{
		return this.GXLastCtrlId;
	}
	
	this.getValidStruct = function( ctrlId)
	{
		return this.GXValidFnc[ctrlId];
	}
	
	this.getControlIds = function()
	{
		return this.GXCtrlIds;
	}
	
	this.getUsercontrolFromChild = function( Child)
	{
		var len = this.UserControls.length;
		for(var i=0;i<len;i++)
		{
			var ctrl = this.UserControls[i].getContainerControl();
			if (gx.dom.isChildNode( Child, ctrl))
				return this.UserControls[i];
		}
		return null;
	}
	
	this.installFlatLevelDatePickers = function()
	{
		var validStruct = null;
		var ctrlIds = this.getControlIds();
		var len = ctrlIds.length;
		for (var i=0;i<len;i++)
		{
			validStruct = this.getValidStruct(ctrlIds[i]);
			if ((validStruct != undefined) && (validStruct.grid == 0) && (validStruct.dp != undefined))
			{
				var controlId = this.CmpContext + validStruct.fld;
				gx.fn.installDatePicker(controlId, validStruct.dp.f, validStruct.dp.st, validStruct.dp.wn, validStruct.dp.mf, gx.fn.datePickerFormat(validStruct.dp.pic, validStruct.dp.dec, validStruct.len));
			}
		}
	}
	
	this.refreshOlds = function()
	{
		for (var lvl in this.LvlOlds)
		{
			var lvlOlds = this.LvlOlds[lvl];
			if (typeof(lvlOlds) != 'function')
			{
				var gridId = gx.fn.lvlGrid(parseInt(lvl));
				var gridRow = undefined;
				if (gridId != 0)
					gridRow = gx.fn.currentGridRow(gridId);
				var len = lvlOlds.length;
				for( var i=0; i<len; i++)
				{
					var name = lvlOlds[i];
					var varName = name;
					var oldVal = '';
					var vStruct = gx.fn.vStructForOld( varName);
					if (vStruct)
					{
						oldVal = gx.typedOld( vStruct.fld, varName, vStruct.type);
					}
					else
					{
						if (!gx.lang.emptyObject(gridRow))
							name += '_' + gridRow;
						oldVal = gx.fn.getHidden( name);
					}
					if (typeof( oldVal) != 'undefined')
					{
						if (!vStruct)
						{
							window[varName] = oldVal;
						}
						this[varName] = oldVal;
					}
				}
			}
		}
	}
	
	this.deleteEventHandlers = function()
	{
		try
		{
			gx.fx.ctx.deleteHandlers(this);
			gx.fx.dnd.deleteHandlers(this);
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'deleteEventHandlers');
		}
	}
	
	this.ondestroy = function()
	{
		try
		{
			this.deleteEventHandlers();
			var len = this.UserControls.length;
			for(var i=0;i<len;i++)
			{
				var uc = this.UserControls[i];
				if (!gx.lang.emptyObject(uc.destroy))
				{
					try
					{
						uc.destroy();
					}
					catch(e)
					{
						gx.dbg.logEx(e, 'gxfrmutl.js', 'ondestroy');
					}
				}
			}
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'ondestroy');
		}
	}
	
	this.onpost = function()
	{
		var gxO = gx.O;
		gx.setGxO( this.CmpContext, this.IsMasterPage);
		if (this.hasMasterPage())
			this.MasterPage.onpost();
		var len = this.WebComponents.length;
		for(var i=0;i<len;i++)
		{
			this.WebComponents[i].onpost();
		}
		if (this.ReadonlyForm && this.IsComponent && gxO != this)
		{
			this.roControlsAsHidden();
		}
		this.execC2VFunctions();
		gx.setGxO( gxO.CmpContext, gxO.IsMasterPage);
	}
	
	this.roControlsAsHidden = function()
	{
		var ctrlIds = this.getControlIds();
		var len = ctrlIds.length;
		for (var i=0;i<len;i++)
		{
			var validStruct = this.getValidStruct(ctrlIds[i]);
			if (validStruct.grid == 0)
			{
				var ctrlId = this.CmpContext + validStruct.fld;
				var ctrl = gx.dom.el( ctrlId);
				if (ctrl && !gx.fn.isAccepted( ctrl))
					gx.fn.setHidden( ctrlId, validStruct.val());
			}
		}
	}
	
	this.getCtrlIdx = function( CtrlId)
	{
		var ctrlIds = this.getControlIds();
		var len = ctrlIds.length;
		for (var i=0;i<len;i++)
		{
			var validStruct = this.getValidStruct(ctrlIds[i]);
			if (validStruct && this.CmpContext + validStruct.fld == CtrlId)
			{
			    return gx.fn.controlIds()[i];
			}
		}
		return null;
	}
	
	this.onload = function()
	{
		gx.setGxO( this.CmpContext, this.IsMasterPage);
		this.screenToVars();
		if (this.hasMasterPage())
			this.MasterPage.onload();
		var len = this.Grids.length;
		for(var i=0;i<len;i++)
		{
			this.Grids[i].loadGrid();
		}
		len = this.WebComponents.length;
		for(var i=0;i<len;i++)
		{
			this.WebComponents[i].onload();
		}
		this.installFlatLevelDatePickers();
		this.refreshOlds();
		this.execV2CFunctions(true);
		this.JustCreated = false;
	}
	
	this.onunload = function()
	{
		if (this.hasMasterPage())
			this.MasterPage.onunload();
		var len = this.Grids.length;
		for(var i=0;i<len;i++)
		{
			this.Grids[i].cleanup();
			this.Grids[i] = null;
		}
		this.Grids = [];
		len = this.WebComponents.length;
		for(var i=0;i<len;i++)
		{
			this.WebComponents[i].onunload();
			this.WebComponents[i] = null;
		}
		this.WebComponents = [];
	}
	
	this.screenToVars = function()
	{
		try
		{
			var ctrlIds = this.getControlIds();
			var len = ctrlIds.length;
			for (var i=0;i<len;i++)
			{
				var validStruct = this.getValidStruct(ctrlIds[i]);
				if (validStruct && validStruct.lvl == 0)
					validStruct.c2v();
			}
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'screenToVars');
		}
	}
	
	this.postbackLoad = function()
	{
		if (this.hasMasterPage())
			this.MasterPage.postbackLoad();
		var len = this.WebComponents.length;
		for(var i=0;i<len;i++)
		{
			this.WebComponents[i].postbackLoad();
		}
		if (this.IsComponent && this.JustCreated)
		{
			this.installFlatLevelDatePickers();
		}
		this.execV2CFunctions(true);
		this.JustCreated = false;
		this.conditionsChanged = false;
	}
	
	this.addDragSource = function( ControlId, CSSClass, Types, Handler)
	{
		gx.fx.dnd.addSource( this, ControlId, CSSClass, Types, Handler);
	}
	
	this.addDropTarget = function( ControlId, CSSClass, Types, Handler)
	{
		gx.fx.dnd.addTarget( this, ControlId, CSSClass, Types, Handler);
	}
	
	this.addContextSetter = function( ControlId, CSSClass, Types, Handler)
	{
		gx.fx.ctx.addSetter( this, ControlId, CSSClass, Types, Handler);
	}
	
	this.addContextTracker = function( ControlId, CSSClass, Types, Handler)
	{
		gx.fx.ctx.addTracker( this, Types, Handler);
	}
	
	this.addEventHandler = function( EvtType, ControlId, Handler)
	{
		gx.fx.dom.addEventHandler( this, EvtType, ControlId, Handler);
	}
}

gx.uc = {
	getNew: function( ParentObject, ControlId, LastId, ClassName, ContainerName, ControlName, GridLvl, GridId, GridRow) {
		var subclass = eval( ClassName);
		gx.lang.inherits( subclass, gx.uc.UserControl);
		var userCtrl = new subclass();
		userCtrl.ContainerName = ContainerName;
		userCtrl.DesignContainerName = ContainerName;
		userCtrl.setupControl( ParentObject, ControlName, ControlId, LastId, GridLvl, GridId, GridRow);
		return userCtrl;
	},
	
	fromChild: function( Child) {
		var gxUC = gx.pO.getUsercontrolFromChild(Child);
		if (gxUC != null)
			return gxUC; 
		if (gx.pO.hasMasterPage())
		{
			gxUC = gx.pO.MasterPage.getUsercontrolFromChild(Child);
			if (gxUC != null)
				return gxUC;
		}
		var len = gx.pO.WebComponents.length;
		for(var i=0;i<len;i++)
		{
			gxUC = gx.pO.WebComponents[i].getUsercontrolFromChild(Child);
			if (gxUC != null)
				return gxUC;
		}
		return null;
	},
	
	getUserControlObj: function( ContainerName) {
		var uc = gx.O.getUserControl(ContainerName);
		if (gx.lang.emptyObject(uc))
		{
			if(gx.pO.hasMasterPage())
			{
				uc = gx.pO.MasterPage.getUserControl(ContainerName);
				if (!gx.lang.emptyObject(uc))
					return uc;
			}
			var len = gx.pO.WebComponents.length;
			for (var i=0; i<len; i++)
			{
				uc = gx.pO.WebComponents[i].getUserControl(ContainerName);
				if (!gx.lang.emptyObject(uc))
					return uc;
			}
		}
		return uc;
	},
	
	userControlContainerId: function(ControlId) {
	    var _Idx = ControlId.lastIndexOf("_");
	    if (_Idx!=-1)
	    {
	        var gridCtrlContainerId = ControlId.substring(0, _Idx)  + "Container" + ControlId.substring(_Idx);
	        if (gx.dom.byId(gridCtrlContainerId)!=null)
	            return gridCtrlContainerId;
	    }
        return ControlId + "Container";
	},
	
	setProperties: function( ControlId, Properties) {
		var UC = gx.uc.getUserControlObj(gx.uc.userControlContainerId(ControlId));
		if (UC != null)
		{
			if (Properties.length != undefined)
			{
				var len = Properties.length;
				for (var i=0; i<len; i++)
				{
					for (var Prop in Properties[i])
					{
						var PropValue = Properties[i][Prop];
						UC[Prop] = PropValue;
					}
				}
			}
			else
			{
				for (var Prop in Properties)
				{
					var PropValue = Properties[Prop];
					UC[Prop] = PropValue;
				}
			}
		}
	},
	
	isUserControl: function( ControlId) {				
		if (ControlId instanceof gx.uc.UserControl)
			return true;
		else
		{
			var ctrlContainer = gx.dom.byId(gx.uc.userControlContainerId(ControlId));
			if (ctrlContainer != null)
			{
				if (ctrlContainer.tagName == "DIV")
					return true;
			}	
		}
		return false;
	},
	
	UserControl: function() {
		this.ParentObject = null;
		this.GridId = ""
		this.GridRow = "";
		this.ControlId = 0;
		this.ControlLvl = 0;
		this.ContainerName = "";
		this.ControlName = "";
		this.LastIdBefore = 0;
		this.Properties = [];
		this.DynProperties = [];
		this.PropTypes = [];
		this.ValidFunctions = [];
		this.V2CFunctions = [];
		this.C2VFunctions = [];
		this.C2ShowFunction = null;
		this.RealControl = null;
		this.IsPostBack = false;
		
		this.clearFunctions = function()
		{
			this.ValidFunctions = [];
			this.V2CFunctions = [];
			this.C2VFunctions = [];
			this.C2ShowFunction = null;
		}
		
		this.me = function()
		{
			return "gx.getObj('" + this.ParentObject.CmpContext + "', " + this.ParentObject.IsMasterPage.toString() + ").getUserControl('" + this.ContainerName + "')";
		}
		
		this.getChildContainer = function( Name)
		{
			var rowSuffix = (this.GridRow != '')?('_' + this.GridRow):'';
			return gx.dom.byId( this.DesignContainerName + Name + rowSuffix);
		}
		
		this.getContainerControl = function()
		{
			return gx.dom.byId( this.ContainerName);
		}
		
		this.getRealControl = function()
		{
			return this.RealControl;
		}
		
		this.setupControl = function( ParentObject, ControlName, ControlId, LastId, GridLvl, GridId, GridRow)
		{
			this.ParentObject = ParentObject;
			this.ControlName = ControlName;
			this.ControlId = ControlId;
			this.LastIdBefore = LastId;
			this.ControlLvl = (GridLvl != undefined)?GridLvl:0;
			this.GridId = (GridId != undefined)?GridId:0;
			this.GridRow = (GridRow != undefined)?GridRow:"";
			this.ParentObject.GXValidFnc[this.ControlId]={lvl:this.ControlLvl,grid:this.GridId,op:[],ip:[],isuc:true,uc:this,fnc:this.validateControl};
		}
		
		this.addValidFunction = function( Func, VarName, CtrlName)
		{
			this.ValidFunctions.push(Func);
			var rowSuffix = (this.GridRow == "")?"":"_"+this.GridRow;
			this.ParentObject.addUsercontrolBinding(VarName, CtrlName+rowSuffix);
		}
		
		this.validateControl = function()
		{
			gx.csv.validatingUC = this;
			var len = this.ValidFunctions.length;
			for(var i=0;i<len;i++)
			{
				var bRet = this.ValidFunctions[i].call(gx.O);
				if (!bRet)
				{
					gx.O.AnyError = 1;
					gx.csv.validatingUC = null;
					return false;
				}
			}
			gx.csv.validatingUC = null;
			return true;
		}
		
		this.attachEvents = function()
		{
			try
			{
				var ctrl = this.getContainerControl();
				if (!gx.lang.emptyObject(document.frames))
				{
					var docFrames = document.frames.length;
					if (docFrames > 0)
					{
						var i=0;
						for(i=0;i<docFrames;i++)
						{
							var frame = document.frames[i];
							if (gx.dom.isChildNode(frame, ctrl) == true)
							{
								frame.frameElement.onfocus = this.onfocus;
								this.RealControl = frame.frameElement;
								return;
							}
						}
					}
				}
				else
				{
					ctrl.onfocus = this.onfocus;
					this.RealControl = ctrl; 
				}
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxfrmutl.js', 'attachEvents');
			}
		}
		
		this.onfocus = function()
		{			
			gx.evt.onfocus(this.getRealControl(), this.ControlId, this.ParentObject.CmpContext, this.ParentObject.IsMasterPage, this.GridRow, this.GridId);
			this.execShowFunction();
				if (!gx.csv.anyError)
					this.setFocusBase();			
		}
		
		this.setFocusBase = function()
		{
			if (typeof(this.setFocus) == 'function')
			{
				this.setFocus();
			}
		}
		
		this.setHtml = function( InnerHtml)
		{
			this.getContainerControl().innerHTML = InnerHtml;
		}
		
		this.createWebComponent = function( CtrlName, PgmName, Parms, TargetCtrlId, CmpPrefix)
		{
			this.ParentObject.createWebComponent( CtrlName, PgmName, Parms, this.GridRow, TargetCtrlId, CmpPrefix);
		}
		
		this.deleteWebComponent = function( CtrlName)
		{
			var cmpCtx = gx.fn.cmpContextFromCtrl( CtrlName);
			this.ParentObject.deleteComponent( cmpCtx);
		}
		
		this.notifyContext = function( Types, Obj)
		{
			gx.fx.ctx.notify( null, Types, Obj);
		}
		
		this.addV2CFunction = function(Func)
		{
			this.V2CFunctions.push(Func);
		}
		
		this.addC2VFunction = function(Func)
		{
			this.C2VFunctions.push(Func);
		}
		
		this.setC2ShowFunction = function(ShowFunc)
		{
			this.C2ShowFunction = ShowFunc;
		}
		
		this.execV2CFunctions = function()
		{
			var tCmp = gx.csv.cmpCtx;
			gx.csv.cmpCtx = this.ParentObject.CmpContext;
			var i=0;
			var funcs = this.V2CFunctions;
			var len = funcs.length;
			for(i=0;i<len;i++)
			{
				try { funcs[i](this, this.GridRow); }
				catch(e)
				{
					gx.dbg.logEx(e, 'gxfrmutl.js', 'execV2CFunctions');
				}
			}
			gx.csv.cmpCtx = tCmp;
		}
		
		this.execC2VFunctions = function()
		{
			var tCmp = gx.csv.cmpCtx;
			gx.csv.cmpCtx = this.ParentObject.CmpContext;
			var i=0;
			var funcs = this.C2VFunctions;
			var len = funcs.length;
			for(i=0;i<len;i++)
			{
				try { funcs[i](this, this.GridRow); }
				catch(e)
				{
					gx.dbg.logEx(e, 'gxfrmutl.js', 'execC2VFunctions');
				}
			}
			gx.csv.cmpCtx = tCmp;
		}
		
		this.execShowFunction = function()
		{
			if (this.C2ShowFunction != null)
			{
				this.C2ShowFunction(this);
			}
			this.IsPostBack = true;
		}
		
		this.getEventRow = function()
		{
			return this.GridRow;
		}
		
		this.addEventHandler = function( EventName, Handler)
		{
			var outThis = this;
			this[EventName] = function() {
				gx.evt.userReady = false;
				gx.setGxO(outThis.ParentObject.CmpContext, outThis.ParentObject.IsMasterPage);
				if (outThis.GridId > 0)
				{
					var objVarName = outThis.DesignContainerName;
					var cRegex = new RegExp('^(?:' + outThis.ParentObject.CmpContext + ')?(.+)$');
					var isMatch = cRegex.exec(outThis.DesignContainerName);
					if (isMatch && isMatch[1])
					{
						objVarName = isMatch[1];
					}
					outThis.ParentObject[objVarName] = outThis;
					var gridObj = outThis.ParentObject.getGridById( outThis.GridId);
					if (gridObj)
					{
						gridObj.instanciateRow( outThis.GridRow);
					}
				}
				outThis.execC2VFunctions();
				Handler.call(outThis.ParentObject, outThis.getEventRow());
				gx.evt.userReady = true;
			};
		}
		
		this.addProperty = function( PropName, HiddenName)
		{
			this.Properties[PropName] = HiddenName;
		}
		
		this.setProperty = function( PropName, HiddenName, PropValue, PropType)
		{
			this.addProperty( PropName, HiddenName);
			this.PropTypes[PropName] = PropType;
			if (gx.lang.isBooleanType(PropType))
			    this[PropName] = gx.lang.gxBoolean(PropValue);
			else if (gx.lang.isNumericType(PropType))
			{
			    if (!gx.lang.emptyObject(PropValue))
			    {
			        this[PropName] = gx.num.parseFloat(PropValue);
			    }
			}
			else 
			    this[PropName] = PropValue;
		}
		
		this.setDynProperty = function( PropName, HiddenName, PropType)
		{
			this.DynProperties.push(PropName);
			this.setProperty(PropName, HiddenName, gx.fn.getHidden(this.getHiddenName(HiddenName)), PropType);
		}
		
		this.refreshDynProperties = function()
		{
			var len = this.DynProperties.length;
			for(var i=0; i<len; i++)
			{
				var propName = this.DynProperties[i];
				var hiddenName = this.Properties[propName];
				this[propName] = gx.fn.getHidden(this.getHiddenName(hiddenName));
			}
		}
		
		this.setGridProperties = function()
		{
			var props = this.ParentObject.getGridUCProperties(this.ControlName);
			var len = props.length;
			for(var i=0; i<len; i++)
			{
				var prop = props[i];
				var propValue = prop.v;
				if (typeof(propValue) == 'undefined')
				{
					var hiddenName = this.getHiddenName(prop.h);
					propValue = gx.fn.getHidden(hiddenName);
					if (prop.t == 'color')
					{
						propValue = gx.color.html(propValue);
					}
				}
				this.setProperty(prop.p, prop.h, propValue, prop.t);
			}
		}
		
		this.setGridEventHandlers = function()
		{
			var handlers = this.ParentObject.getGridUCEventHandlers(this.ControlName);
			var len = handlers.length;
			for(var i=0; i<len; i++)
			{
				var hdlr = handlers[i];
				this.addEventHandler( hdlr.e, hdlr.h);
			}
		}
		
		this.getHiddenName = function( HiddenName)
		{
			var gridRow = '';
			if (this.GridRow != '')
			{
				gridRow = '_' + this.GridRow;
			}
			return this.ParentObject.CmpContext + this.ControlName.toUpperCase() + (this.ParentObject.IsMasterPage?'_MPAGE':'') + "_" + HiddenName + gridRow;
		}
		
		this.saveProperties = function()
		{
			for(var prop in this.Properties)
			{
				var propValue = this[prop];
				if (typeof(this.Properties[prop]) != 'function')
				{
					if (typeof(propValue) != 'undefined' && typeof(propValue.R) != 'undefined' && typeof(propValue.G) != 'undefined' && typeof(propValue.B) != 'undefined')
					{
						propValue = gx.color.rgb( propValue.R, propValue.G, propValue.B);
					}
					if (gx.lang.isBooleanType(this.PropTypes[prop]))
					{
						propValue = (propValue?1:0);
					}
					gx.fn.setHidden(this.getHiddenName(this.Properties[prop]), propValue);
				}
			}
		}
	}
};

gx.printing = {
	loaded: false,
	tries: 0,
	waitInterval: 100,
	
	print: function( printInfo) {
		if (!this.loaded)
		{
			var fileUrl = gx.util.resourceUrl("printingappletsigned.jar", true);
			var html = '<applet name="GeneXusPrintAppletForWindows" archive="' + fileUrl + '" code="com/genexus/printing/Printer.class" width="0" height="0">';
			html += '<param name="path" value="' + gx.util.resourceUrl(gx.basePath, true) + '">'
			html += '<p>No java plugin detected. Click <a href="http://java.com/en/download/" target="new">here</a> to download it.</p>';
			html += '</applet>';
			document.body.appendChild(gx.html.nodesFromText(html)[0]);
			this.loaded = true;
		}
		if (this.tries == 0)
		{
			this.printWhenReady( printInfo);
		}
		else
		{
			gx.dbg.logMsg('Already trying to print a document.');
		}
	},
	
	printWhenReady: function( printInfo) {
		if (this.tries >= (this.waitInterval * 60))
		{
			this.tries = 0;
			gx.dbg.logMsg('The printing applet was not loaded.');
			return;
		}
		this.tries++;
		if (this.isReady())
		{
			document.GeneXusPrintAppletForWindows.printReport(printInfo.reportFile, printInfo.printerRule, 'GXPRN.INI');
			this.tries = 0;
		}
		else
		{
			setTimeout( function() { gx.printing.printWhenReady(printInfo); }, this.waitInterval);
		}
	},
	
	isReady: function() {
		var printingApplet = document.GeneXusPrintAppletForWindows;
		if (printingApplet)
		{
			if (typeof(printingApplet.isReady) == 'function' || typeof(printingApplet.isReady) == 'unknown')
			{
				return printingApplet.isReady();
			}
		}
		return false;
	}
};

gx.fn = {
	attachedControls: function() {
		return gx.attachedControls;
	},
	
	closeWindow: function( Parms) {
		if (typeof(Parms) == 'string')
		{
			if (this.closeFromServer(Parms))
			{
				return;
			}
			Parms = [];
		}
		if (!Parms)
		{
			Parms = [];
		}
		if (gx.popup.ispopup())
		{
			var popupObj = gx.popup.getPopup();
			if (!popupObj.frameWindow || (popupObj.frameWindow.location.href.indexOf(popupObj.url) != -1) || gx.grid.drawAtServer)
			{
				popupObj.close(Parms);
				return;
			}
		}
		if (location.href.indexOf('gxCalledAsPopup') != -1)
		{
			this.closeWindowImpl();
			return;
		}
		var sCaller = gx.fn.getControlValue("sCallerURL");

		if (!gx.lang.emptyObject(sCaller))
		{
		    gx.ajax.windowClosed(-1);
		    location.href = gx.ajax.absoluteurl(sCaller);
		}
		else
		{
			this.closeWindowImpl();
		}
	},
	
	closeWindowImpl: function() {
		if (gx.util.browser.isIE())
		{
			window.close();
		}
		else
		{
			if (history.length > 0)
				history.back();
			else
				window.location.assign("about:blank");
		}
	},
	
	closeFromServer: function( Parms) {
		try
		{
			if (window.parent && window.parent.gx)
			{
				if (gx.popup.ispopup() && !(gx.grid.drawAtServer || window.parent.gx.grid.drawAtServer))
					gx.fn.closeWindow( gx.json.evalJSON(Parms));
				else 
					window.parent.gx.fn.closeWindow( gx.json.evalJSON(Parms));
				return true;
			}
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'closeFromServer');
		}
		return false;
	},
	
	invalidEmptyValue: function( Values) {
		if (gx.lang.emptyObject(Values.s))
		{
			var len = Values.v.length;
			for (var i=0; i<len; i++)
			{
				if (Values.v[i][0] === Values.s)
				{
					return false;
				}
			}
			return true;
		}
		return false;
	},
	
	selectedDescription: function( Values) {
		var len = Values.v.length;
		for (var i=0; i<len; i++)
		{
			if (Values.v[i][0] === Values.s)
			{
				return Values.v[i][1];
			}
		}
		return null;
	},
	
	setGridCheckBoxValue: function( ControlId, sRow, Value, Checked) {
		this.setCheckBoxValue( ControlId + "_" + sRow, Value, Checked)
	},
	
	setGridDecimalValue: function( ControlId, sRow, Value, Dec, DecPoint) {
		Value = Value.toString().replace( DecPoint, '.');
		Value = Number( Value).toFixed( Dec);
		Value = Value.replace( '.', DecPoint);
		return this.setGridControlValue( ControlId, sRow, Value);
	},
	
	setGridControlValue: function( ControlId, sRow, PValue, GXCtrlFormat) {
		return this.setControlValue( ControlId + "_" + sRow, PValue, GXCtrlFormat);
	},
	
	setVarValues: function( VarIds, VarValues) {
		var len = VarIds.length;
		for (var i=0; i<len;i++)
		{
			var validStruct = gx.fn.vStructForVar(VarIds[i]);
			if(validStruct != null)
			{
				validStruct.v2v( VarValues[i]);
			}
			else
			{
				eval( VarIds[i] + '="' +  VarValues[i] + '"');
			}
		}
	},
	
	setControlValue: function( ControlId, Value, GXCtrlFormat) {
		ControlId = gx.csv.ctxControlId( ControlId);
		this.setControlValueAny( ControlId, Value, GXCtrlFormat);
	},
	
	setControlValueAny: function( ControlId, Value, GXCtrlFormat) {
		this.persistGridControlValue(ControlId, Value);
		var validStruct = gx.O.getValidStructFld(ControlId);
		if (validStruct && (validStruct.type == 'dtime' || validStruct.type == 'date') && Value === '')
		    Value = gx.date.nulldate_toc(validStruct.len, validStruct.dec);
		if (Value instanceof gx.date.gxdate)
		{
			validStruct = gx.O.getValidStructFld(ControlId);
			if (!gx.lang.emptyObject(validStruct))
			{
				var timeString = '';
				if (validStruct.type == 'dtime' && Value.HasTimePart)
					timeString = Value.getTimeString(validStruct.dec >=4, validStruct.dec >=8);
				var Fmt = gx.dateFormat;
				if (validStruct.dp !=undefined && validStruct.len > 8 && gx.dateFormat.indexOf("Y4") == -1)
					Fmt = Fmt.replace('Y', 'Y4');
				if (validStruct.len > 0)
					Value = Value.getStringWithFmt(Fmt) + ((Value.HasTimePart)? " " + timeString :"");
				else 
					Value = (Value.HasTimePart)? timeString :"";
			}
		}else if ( gx.lang.instanceOf(Value, Number) || (typeof(gx.num.dec)!="undefined" && Value instanceof gx.num.dec.bigDecimal))
		{
			validStruct = gx.O.getValidStructFld(ControlId);
			if (!gx.lang.emptyObject(validStruct) && validStruct.pic != undefined)
			{
				Value = gx.num.formatNumber(Value, validStruct.dec, validStruct.pic, validStruct.len, validStruct.sign, false);
			}
		}
		var CtrlFormat = GXCtrlFormat || 0;
		var Control = gx.dom.el( ControlId);	
		if ((Control != null) && (Control.nodeName != "SPAN"))
			this.setControlValue_impl( Control, Value, GXCtrlFormat);
		else
		  gx.fn.setHidden(ControlId, Value);
		var spanCtrl = ControlId;
		if ((Control != null) && (Control.nodeName == "SPAN"))
		{
			spanCtrl = Control;
		}
		this.setControlValue_span_safe( spanCtrl, Value, GXCtrlFormat);
	},
	
	setDecimalValue: function( ControlId, Value, Dec, DecPoint) {
		this.setControlValue( ControlId, Value);
	},
	
	toDecimalValue: function( Value, ThSep, DecPoint) {
		return gx.num.parseFloat(Value, ThSep, DecPoint);
	},
	
	toDatetimeValue: function( Value, sFmt) {
		return new gx.date.gxdate(Value, sFmt);
	},
	
	setCheckBoxValue: function( ControlId, Value, Checked) {
		try
		{
			ControlId = gx.csv.ctxControlId( ControlId);
			var Control = gx.dom.form()[ControlId];
			if (Control == null)
				Control = gx.dom.byId(ControlId);
			if (Control)
			{
				Control.checked = (Value.toString()==Checked.toString());
				Control.value = Value;
			}
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'setCheckBoxValue');
		}
	},
	
	persistGridControlValue: function(ControlId, Value) {
		var _Idx = ControlId.lastIndexOf("_");
		if(_Idx != -1)
		{
			var validStruct = gx.O.getValidStructFld(ControlId.substring(0, _Idx));
			if(validStruct)
			{
				var gxgrid = validStruct.gxgrid;
				if(gxgrid)
				{
					gxgrid.persistControlValue(ControlId, Value, validStruct);
				}
			}
		}
	},
	
	setControlValue_span_safe: function( Control, Value, GXCtrlFormat) {
		if(typeof(Control) == 'string')
			Control = gx.dom.el( 'span_' + Control);
		if (Control != null)
		{
		    if (Control.nodeName != "SPAN")
		    {
			    var controlId = "span_";
			    if(typeof(Control) == 'string')
				    controlId += Control;
			    else
				    controlId += gx.dom.id(Control);
			    Control = gx.dom.byId( controlId);
		    }
			this.setControlValue_fmt( Control, Value, GXCtrlFormat);
		}
	},
	
	setControlValue_fmt: function( Control, Value, GXCtrlFormat) {
	    if (Control != null)
		{
			if( GXCtrlFormat == 1 )
			{
				var gxlink = Control.getAttribute('gxlink');
				if (!gx.lang.emptyObject(gxlink)){
				//HTML textblock con evento asociado
				    if(Control.firstChild != null && Control.firstChild.nodeName == 'A')
					    Control = Control.firstChild;
				}
				gx.html.setInnerHtml(Control, Value, true);
			}
			else
			{
				if( GXCtrlFormat == 0 && typeof(Value) == 'string')
					Value = Value.replace( / +/g, ' ');
				while(Control.firstChild != null && Control.firstChild.nodeName != '#text')
					Control = Control.firstChild;
				gx.html.setInnerText( Control, Value, GXCtrlFormat);
			}
		}
	},
	
	setControlValue_impl: function( Control, Value, GXCtrlFormat) {
		if(typeof(Control) == 'string')
			Control = gx.dom.el( Control);
		if (Value instanceof gx.date.gxdate)
		{
			Value = Value.getString();
		}
	  if (Control != null)
	  {
	  	if ((Control != null) && (typeof(Control.length) != 'undefined') && (typeof(Control[0]) != 'undefined') && (Control[0].type == 'radio'))
	  	{
		  	this.setRadioValue( Control, Value);
		  	return;
		  }
	  	if(Control.type == "text" || Control.type == "textarea")
				Control.value = gx.lang.decodeValue( Value);
			else
			{
				if (Control.value != undefined)
					Control.value = Value;
				else
				{
			    this.setControlValue_span_safe( Control, Value, GXCtrlFormat);
			  }
			}
		}
	},
	
	setGridComboBoxValue: function(ControlId, sRow, Value) {
		this.setComboBoxValue(ControlId + "_" + sRow, Value);
	},
	
	setComboBoxValue: function(ControlId, Value) {
		var isIE = gx.util.browser.isIE();
		ControlId = gx.csv.ctxControlId( ControlId);
		var Ctrl = gx.dom.form()[ControlId];
		if (Ctrl == null)
			Ctrl = gx.dom.byId(ControlId);
		if (Ctrl == null)
			return;
		var sType = '';
		var vStruct = gx.O.getValidStructFld(ControlId);
		if (!gx.lang.emptyObject(vStruct))
			sType = vStruct.type;
		if (sType == 'int')
			Value = gx.text.trim(Value);
		else if (sType == 'date' && Value instanceof gx.date.gxdate)
		    Value = Value.getStringWithFmt("Y4MD");
		else if (sType != 'decimal')
			Value = gx.text.rtrim(Value);
		var descText = Value;
		var selected = false;
		try
		{
			var len = Ctrl.options.length;
			var selectedopt;
			for ( var i=0;i<len;i++)
			{
				var opt = Ctrl.options[i];
				if ((sType == 'decimal' && gx.num.parseFloat(opt.value)==Value)||
						(opt.value == Value))
				{
					if (typeof(opt.innerText) != 'undefined')
						descText = opt.innerText;
					else
						descText = opt.text;
					Ctrl.selectedIndex=i;
					selected = true;
					opt.setAttribute('selected', 'selected');
					selectedopt = opt;
					if (isIE)
					{
						break;
					}
				}
				else if (!isIE)
				{
					opt.removeAttribute('selected');
				}
			}
			if (selectedopt && selectedopt.value != Ctrl.value && gx.util.browser.isFirefox())
			{
					gx.dom.redrawControl( Ctrl);
			}
			if (!selected)
				Ctrl.selectedIndex=0;
			if (vStruct.grid > 0)
				vStruct.gxgrid.persistControlValue(ControlId, Value, vStruct);
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'setComboBoxValue');
		}
		this.setControlValue_span_safe( ControlId, descText, 0);
	},
	
	loadComboBox: function( ctrlId, values) {
		this.setComboValues( ctrlId, values);
	},
	
	setGridComboValues: function( ControlId, adata) {
		var ctrlGrid = this.controlGridId( ControlId);
		if( ctrlGrid == 0)
			this.setComboValues( ControlId, adata);
		else
		{
			for (var i=1; i < 999; i++) 
			{	
				var currentRowStr = gx.text.padr( i.toString(), 4, '0');
				var Control = gx.dom.el( ControlId + "_" + currentRowStr);
				if( Control == null)
					break;
				this.setComboValues( Control.name, adata);
			}
		}
	},
	
	setComboValues: function( ControlId, adata) {
		var Ctrl = gx.dom.el( ControlId);
		if (Ctrl == null)
			return;
		var currValue = '';
		if (Ctrl.selectedIndex != -1)
			currValue = Ctrl.options[Ctrl.selectedIndex].value;
		while( Ctrl.options.length > adata.length)
			Ctrl.remove( Ctrl.options.length - 1);
		while( adata.length > Ctrl.options.length)
		{
			var E = document.createElement("OPTION");
			Ctrl.options.add( E);
		}
		var len = adata.length;
		for ( var i=0;i<len;i++)
		{
			var E = Ctrl.options[i];
			E.value = adata[i][0];
			E.text = adata[i][1];
			if (E.value == currValue)
				Ctrl.selectedIndex=i;
		}
		if (Ctrl.options.length  == 0)
			Ctrl.selectedIndex = -1;
		else
		{
			if (Ctrl.selectedIndex == -1 || Ctrl.selectedIndex > Ctrl.options.length - 1)
			{
				Ctrl.options[0].selected = true;
			}
		}
	},
	
	getControlRef: function( ControlId, avoidPref) {
		if (!avoidPref)
			ControlId = gx.csv.ctxControlId( ControlId);
		if (ControlId == 'FORM')
			return document;
		var Control = gx.dom.el( ControlId);
		if (Control != null)
			return Control;		
		Control = gx.dom.el( "span_"+ControlId);
		if (Control != null)
			return Control;
		Control = gx.dom.el( "Object_"+ControlId);
		if (Control != null)
			return Control;
		Control = gx.dom.el( "_"+ControlId);
		if (Control != null)
			return Control;
		return null;
	},
	
	getControlRef_list: function( ControlId) {
		var ControlList = gx.dom.byName( ControlId);
		if (ControlList != null)
			return ControlList; 
		var Control = gx.dom.byId(ControlId);
		if (Control != null)
			return [Control];
		return null;
	},
	
	screen_CtrlRef: function( ControlId) {
		var Control = this.getControlGridRef( ControlId, this.controlGridId( ControlId));
		if (!gx.lang.emptyObject( Control))
		{
			if (Control.type == 'hidden')
				Control = gx.dom.el( "span_"+gx.dom.id(Control));	
			return Control;
		}
		return null;
	},
	
	getControlGridRef: function( ControlId, GridId, CurrentRow) {
		ControlId = gx.csv.ctxControlId( ControlId);
		try
		{
			if (GridId == 0)
				return gx.dom.el( ControlId);
			if (CurrentRow == undefined)
				CurrentRow = this.currentGridRow( GridId);
			return gx.dom.el( ControlId + "_" + CurrentRow);
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'getControlGridRef');
		}
	},
	
	setCurrentGridRow: function( GridId, Row) {
		if (Row != '0000')
		{
			try
			{
				return gx.currentRows[GridId] = Row;
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxfrmutl.js', 'setCurrentGridRow');
			}
		}
		return undefined;
	},
	
	currentGridRowImpl: function( GridId) {
		try
		{
			return gx.currentRows[GridId];
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'currentGridRowImpl');
		}
		return undefined;
	},
	
	currentGridRow: function( GridId) {
		var Ret = this.currentGridRowImpl( GridId);
		return (Ret == undefined)?'0001':Ret;
	},
	
	gridDuplicateKey: function( CtrlId) {
		var _GXValidStruct = gx.fn.validStruct(CtrlId);
		if (_GXValidStruct != undefined)
		{
			var gxgrid = _GXValidStruct.gxgrid;
			if( gxgrid != null)
			{
				gxgrid = gxgrid.updateControlValue( _GXValidStruct, true);
				if (gxgrid)
					return gxgrid.gxHasDuplicateKey();
			}
		}
		return false;
	},
	
	firstGridControl: function( GridId) {
		var ctrlIds = gx.fn.controlIds();
		var len = ctrlIds.length;
		for(i=0;i<len;i++)
		{
			var _GXValidStruct = gx.fn.validStruct(ctrlIds[i]);
			if (_GXValidStruct != undefined && _GXValidStruct.grid == GridId)
				return ctrlIds[i];
		}
		return -1;
	},
	
	lastGridControl: function( GridId) {
		var ctrlIds = gx.fn.controlIds();
		for(i=ctrlIds.length-1;i>=0;i--)
		{
			var _GXValidStruct = gx.fn.validStruct(ctrlIds[i]);
			if (_GXValidStruct != undefined && _GXValidStruct.grid == GridId)
				return ctrlIds[i];
		}
		return -1;	
	},
	
	getGridDecimalValue: function(ControlId, sRow, ThSep, DecPoint) {
		return this.getDecimalValue( ControlId + "_" + sRow, ThSep, DecPoint);
	},
	
	getGridIntegerValue: function(ControlId, sRow, ThSep) {
		return this.getIntegerValue( ControlId + "_" + sRow, ThSep);
	},
	
	getGridControlValue: function( ControlId, sRow) {
		return this.getControlValue( ControlId + "_" + sRow);
	},
	
	getGridCheckBoxValue: function(ControlId,sRow,Checked,Unchecked) {
		return this.getCheckBoxValue( ControlId + "_" + sRow, Checked, Unchecked)
	},
	
	getCheckBoxValue: function( ControlId, Checked, Unchecked) {
		ControlId = gx.csv.ctxControlId( ControlId);
		var Control = gx.dom.form()[ControlId];
		if (Control == null)
		{
			ControlList = gx.dom.byName( ControlId);
			if (ControlList != null)
				Control = ControlList[0];
		}
		if (Control == null)
			return 0;
		if (Control.checked)
			return Checked;
		return Unchecked;
	},
	
	getControlValue: function( ControlId) {
		return this.getControlValue_impl( gx.csv.ctxControlId( ControlId));
	},
	
	getControlValue_impl: function( ControlId) {
		try
		{
			var Control = gx.dom.el( ControlId);
			if (Control != null)
			{
				if ((Control.type == "hidden") || (Control.type == "text") || (Control.type == "textarea") || (Control.type == "checkbox"))
							return Control.value;
				if (Control.type == 'radio')
				{
					return gx.fn.getRadioValue(gx.dom.byName(ControlId));
				}
				var vStruct = gx.O.getValidStructFld( gx.dom.id(Control));
				if (!gx.lang.emptyObject(vStruct) && (vStruct.type != 'date') && (vStruct.type != 'dtime') && (vStruct.type != 'bits'))
					return Control.value;
				if (Control.nodeName == 'SELECT' && Control.options.length > 0)
				{
					if (Control.selectedIndex != -1)
						return Control.options[Control.selectedIndex].value;
					else
						return Control.options[0].value;
				}
				if (Control.nodeName == 'IMG')
				{
					return Control.src;
				}
			}
			Control = gx.dom.el( "span_"+ControlId);
	    if (Control != null)
	    {
	    	var hidVal = gx.fn.getHidden(ControlId);
	    	if (hidVal != undefined)
	    		return hidVal;
	    	else
	    		return gx.fn.getControlValue_span(Control);
	    }
			Control = gx.dom.form()[ControlId];
			if (Control != null)
				return this.getControlValueInt( Control);
			Control = gx.dom.byId( "_"+ControlId);
			if (Control != null)
	       		return Control.value;
			ControlList = gx.dom.byName( ControlId);
			if (ControlList && ControlList.length == 0)
				ControlList = gx.dom.byName( "_"+ControlId);
			if (ControlList != null)
			{
				var len = ControlList.length;
				for (var i=0;i<len;i++)
				{
					Control = ControlList[i];
					if (Control != null)
						return this.getControlValueInt( Control);
	    	}
	    	Control = ControlList[0];
	    	if (Control)
	    		return Control.value;
	    }
	    if (Control == null)
	    {
	        return gx.fn.getHidden(ControlId);
	    }
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'getControlValue_impl');
		}
		return "";
	},
	
	setRadioValue: function( ControlId, Value) {
		ControlId = gx.csv.ctxControlId( ControlId);
		var Control = gx.dom.byName(ControlId);
		if (Control == null)
			return;
		var len = Control.length;
		for (var i=0;i<len;i++)
		{
			if (gx.text.ltrim(Control[i].value) == gx.text.ltrim(Value))
			{
				Control[i].checked = true;
				return;
			}
		}
	},
	
	getRadioValue: function( Control) {
		var len = Control.length;
		for (var i=0;i<len;i++)
		{
			if (Control[i].checked)
				return Control[i].value;
		}
		return '';
	},
	
	getControlValueInt: function( Control) {
		if ((Control.length != undefined) && (Control[0].type == 'radio'))
			return this.getRadioValue( Control);
		if (Control.type == "checkbox")
			return Control.checked;
		if (Control.tagName == "SPAN")
		{
			var hidVal = gx.fn.getHidden(gx.dom.id(Control));
			if (hidVal != undefined)
				return hidVal;
			else
				return gx.fn.getControlValue_span( Control);
		}
		return Control.value;
	},
	
	getControlValue_span: function( Control) {
		while (Control && !Control.nodeValue)
		{
			Control = Control.childNodes[0];
		}
		if (Control && Control.nodeValue)
			return Control.nodeValue;
		return '';
	},
	
	getDateValue: function( ControlId) {
		try
		{
			var ctrlVal = gx.fn.getHidden( gx.csv.ctxControlId( ControlId));
			if(!gx.lang.emptyObject(ctrlVal))
				return new gx.date.gxdate( ctrlVal, "Y4MD");
			return new gx.date.gxdate( this.getControlValue(ControlId), gx.dateFormat);
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'getDateValue');
		}
		return "";
	},
	
	getIntegerValue: function( ControlId, ThSep) {
		var nIntVal = 0;
		var controlValue = this.getControlValue( ControlId);
		if (typeof(controlValue) != 'undefined')
		{
			controlValue = controlValue.toString();
		}
		else
		{
			controlValue = '';
		}
		if (controlValue.length < gx.num.maxNumericPrecision() || typeof(gx.num.dec)=="undefined")
		{
			nIntVal = gx.num.parseInt( controlValue, 10, ThSep);
		}
		else
		{
			nIntVal = new gx.num.dec.bigDecimal(controlValue).setScale(0, gx.num.dec.ROUND_UP).toString();
		}
		return isNaN( nIntVal) ? 0:nIntVal;
	},
	
	getDecimalValue: function( ControlId, ThSep, DecPoint) {
		var nDecVal = gx.num.parseFloat( this.getControlValue( ControlId), ThSep, DecPoint);
		return isNaN( nDecVal) ? 0:nDecVal;
	},
	
	getBlobValue: function( ControlId) {
		var blobCtrl = gx.dom.el("Object_"+ControlId);
		if (blobCtrl != null)
		{
			if (blobCtrl.data)
				return blobCtrl.data;
		}
		else
		{
			blobCtrl = gx.dom.el("Link_"+ControlId);
			if (blobCtrl != null)
				return blobCtrl.href;
		}
		return "";
	},
	
	getVarControlMap: function( ctrlName) {
		for (var varName in gx.O.VarControlMap)
		{
			if (typeof(varName) != 'function')
			{
				var mapping = gx.O.VarControlMap[varName];
				if (mapping.id == ctrlName || (gx.O.CmpContext + mapping.id) == ctrlName)
					return varName;
			}
		}
		return null;
	},
	
	getVarControlMapForVar: function( varName) {
		for (var objVar in gx.O.VarControlMap)
		{
			if (typeof(objVar) == 'string' && objVar == varName)
			{
				return gx.O.VarControlMap[objVar];
			}
		}
		return null;
	},
	
	v2cMap: function( VarName) {
		var mapping = this.getVarControlMapForVar( VarName);
		if (mapping != null)
		{
			var mapSuffix = '';
			if (typeof(mapping.grid) == 'number' && mapping.grid != 0)
			{
				mapSuffix = '_' + gx.fn.currentGridRowImpl(mapping.grid);
			}
			gx.fn.setHidden( gx.O.CmpContext + mapping.id + mapSuffix, gx.O[VarName]);
		}
	},
	
	c2vMap: function( VarName) {
		var mapping = this.getVarControlMapForVar( VarName);
		if (mapping != null)
		{
			var mapSuffix = '';
			if (typeof(mapping.grid) == 'number' && mapping.grid != 0)
			{
				mapSuffix = '_' + gx.fn.currentGridRowImpl(mapping.grid);
			}
			gx.O[VarName] = gx.fn.getHidden( gx.O.CmpContext + mapping.id + mapSuffix);
		}
	},
	
	depsToVars: function( Deps) {
		for (var i=0; i<Deps.length; i++)
		{
			var varName = Deps[i];
			var validStruct = gx.fn.vStructForVar( varName);
			if (!gx.lang.emptyObject(validStruct))
				validStruct.c2v();
			else
				this.c2vMap( varName);
		}
	},
	
	verticalFormula: function( VarName, Default, GridId, CondsFunc, RowFunc, Deps) {
		var validStruct = gx.fn.vStructForVar( VarName);
		if (!gx.lang.emptyObject(validStruct))
			validStruct.v2c();
		else
			this.v2cMap( VarName);
		var oldRow = gx.fn.currentGridRowImpl(GridId);
		var gridObj = gx.fn.getGridObj(GridId);
		var retVal = 0;
		var anyWithCond = false;
		var len = gridObj.grid.rows.length;
		for (var i=0; i < len; i++) 
		{	
			var rowObj = gridObj.grid.rows[i];
			var IsRemoved = rowObj.gxDeleted();
			var RecordExists = rowObj.gxExists();
			var RecordIsMod = rowObj.gxIsMod();
			if (!IsRemoved && (RecordExists || RecordIsMod))
			{
				gx.fn.setCurrentGridRow(GridId, rowObj.gxId);
				if (Deps && Deps.length > 0)
					this.depsToVars( Deps);
				else if (!gx.lang.emptyObject(validStruct))
					validStruct.c2v();
				else
					this.c2vMap( VarName);
				if (CondsFunc.call(gx.O))
				{
					anyWithCond = true;
					retVal += RowFunc();
				}
			}
		}
		gx.fn.setCurrentGridRow(GridId, oldRow);
		if (Deps && Deps.length > 0)
			this.depsToVars( Deps);
		else if (!gx.lang.emptyObject(validStruct))
			validStruct.c2v();
		else
			this.c2vMap( VarName);
		if (!anyWithCond)
			retVal = Default;
		return retVal;
	},
	
	sumFrm: function( VarName, Default, ThSep, DecPoint, GridId, CondsFunc, Deps) {
		return gx.fn.verticalFormula( VarName, Default, GridId, CondsFunc, function() {return gx.num.parseFloat( gx.O[VarName], ThSep, DecPoint);}, Deps);
	},
	
	countFrm: function( VarName, Default, GridId, CondsFunc, Deps) {
		return gx.fn.verticalFormula( VarName, Default, GridId, CondsFunc, function() {return 1}, Deps);
	},
	
	serialRule: function( LastCountAtt, CountAtt , GridId , Inc ) {
		var CurrentRow = gx.fn.currentGridRow( GridId);
		var RowMode = gx.fn.getGridRowMode( gx.fn.gridLvl( GridId), GridId)
		if (RowMode != 'INS' || gx.fn.isNewRow( GridId, CurrentRow) == false)
			return eval(LastCountAtt);
		gx.fn.setNewRow( GridId, CurrentRow, false);	
		var sAssignCode = gx.prefixVar(CountAtt) + '=' + LastCountAtt + '+' + Inc;
		eval( sAssignCode);
		var validStruct = gx.fn.vStructForVar(CountAtt);
		if (validStruct)
			validStruct.v2c();
		return eval(gx.prefixVar(CountAtt));
	},
	
	setReturnParms: function( gxObj, objVars, returnParms) {
		try
		{
			if (gxObj && objVars && returnParms)
			{
				var len = objVars.length;
				if (len == returnParms.length)
				{
					gx.setGxO( gxObj.CmpContext, gxObj.IsMasterPage);
					var lastCtrl = null;
					for (var i=0; i<len; i++)
					{
						var varName = objVars[i];
						var varValue = returnParms[i];
						var vStruct = gx.fn.vStructForVar(varName);
						if (vStruct)
						{
							var ctrl = gx.fn.screen_CtrlRef( gx.csv.ctxControlId(vStruct.fld));
							if (gx.fn.isAccepted(ctrl))
							{
								lastCtrl = ctrl;
							}
							vStruct.v2v( varValue);
							if (vStruct.v2c != null)
								vStruct.v2c();
						}
						else
						{
							gxObj.setVariable( varName, varValue);
						}
					}
					if (lastCtrl)
					{
						gx.fn.setFocus(lastCtrl);
					}
				}
			}
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'setReturnParms');
		}
	},
	
	checkPopupFocus: function( Ctrl) {
		if (gx.popup.ispopup())
		{
			var popup = gx.popup.getPopup();
			if (popup && popup.frameDocument)
			{
				var ctrlDoc = (Ctrl.ownerDocument?Ctrl.ownerDocument:Ctrl.document);
				if (ctrlDoc.URL != popup.frameWindow.location.href)
				{
					popup.setFocusFirst();
					return false;
				}
			}
		}
		return true;
	},
	
	setCtrlProperty: function( ControlId, Property, PValue) {
		var Control = null;
		if (ControlId == 'FORM')
			Control = document;
		else
			Control = gx.fn.screen_CtrlRef( gx.csv.ctxControlId(ControlId));
		if (Control == null)
			return;
		this.setCtrlPropertyImpl( Control, Property, PValue);
	},
	
	setGridCtrlProperty: function( ControlId, Property, PValue) {
		var Control = gx.fn.screen_CtrlRef( ControlId);
		if (Control == null)
			return;
		this.setCtrlPropertyImpl( Control, Property, PValue);
		var Cell = Control.parentElement;
		if (Cell.tagName != 'TD')
			return;
		this.setCtrlPropertyImpl( Cell, Property, PValue);	
	},
	
	setCtrlPropertyImpl: function( Control, Property, PValue) {
		if (Control == null)
			return;
		switch( Property)
		{	
			case "Caption":
				this.setCtrlCaption(Control, PValue);
				break;
			case "Tooltiptext":
				Control.title = PValue;
				break;
			case "Visible":
				if (Control.nodeName == 'INPUT' && Control.type == 'button')
				{
					this.setButtonVisibility( Control, !this.propertyValueFalse( PValue));
				}
				else
				{
					if (Control.nodeName == 'INPUT' && Control.type == 'checkbox')
					{
						if (Control.parentNode.nodeName == 'SPAN')
							Control = Control.parentNode;
					}
					var disp = '';
					var pValueFalse = this.propertyValueFalse(PValue);
					if (pValueFalse)
					{
						disp = 'none';
					}
					else if (Control.style.display == 'none')
					{
						disp = this.displayByType( Control.nodeName);
					}
					if (disp != '')
					{
						Control.style.display = disp;
					}
					gx.fn.showHideDatepicker(Control, !pValueFalse);
				}
				gx.fn.checkAttachedProperty( Control.id, Property, PValue);
				break;
			case "Enabled":	
				{
					var pValueFalse = this.propertyValueFalse( PValue);
				  if (Control.type == "text" || Control.type == "textarea" || Control.tagName=="SELECT")
				  {
				    var spanVal = gx.dom.el( 'span_' + Control.id);
				    if (spanVal)
				    {
			        spanVal.style.display = (!pValueFalse)?"none":"inline";
			        Control.style.display = (pValueFalse)?"none":"inline";
			        gx.fn.showHideDatepicker( Control, !pValueFalse);
				    }
				    gx.fn.checkAttachedProperty( Control.id, Property, PValue);
				  }
	   
					if (Control.type == "hidden")
						return;
					if (Control.tagName=="SPAN" && pValueFalse)
						return;
					if (Control.nodeName == 'INPUT' && Control.type == 'radio')
					{
						var allRadios = gx.dom.byName(gx.dom.id(Control));
						var len = allRadios.length;
						for (var i=0; i<len; i++)
						{
							this.setEnabledProperty( allRadios[i], !pValueFalse);
						}
						return;
					}
					this.setEnabledProperty( Control, !pValueFalse);
					break;
				}
			case "Class":	
					this.setCtrlClass( Control, PValue);
					break;
			case "Link":	
					this.setCtrlLink( Control, PValue);
					break;
			case "Linktarget":	
					this.setCtrlLinkTarget( Control, PValue);
					break;
			case "Backcolor":
					var htmlColor = gx.color.html(PValue);
					if (htmlColor && Control.gxGridName == undefined)
					{
						Control.style.backgroundColor = htmlColor.Html;
					}
					break;
			case "Forecolor":
					var htmlColor = gx.color.html(PValue);
					if (htmlColor)
					{
						Control.style.color = htmlColor.Html;
					}
					break;
			case "Fontbold":
					var pValueFalse = this.propertyValueFalse( PValue);
					Control.style.fontWeight = (pValueFalse?'normal':'bold');
					break;
			case "Fontitalic":
					var pValueFalse = this.propertyValueFalse( PValue);
					Control.style.fontStyle = (pValueFalse?'normal':'italic');
					break;
			case "Fontunderline":
					var pValueFalse = this.propertyValueFalse( PValue);
					Control.style.textDecoration = (pValueFalse?'none':'underline');
					break;
			case "Fontstrikethru":
					var pValueFalse = this.propertyValueFalse( PValue);
					Control.style.textDecoration = (pValueFalse?'none':'line-through');
					break;
			case "Fontname":
					Control.style.fontFamily = PValue;
					break;
			case "Fontsize":
					Control.style.fontSize = PValue;
					break;
			case "Filetype":
					this.setBlobFiletype( Control, PValue);
					break;
			case "URL":	
					this.setBlobUrl( Control, PValue);
					break;
			case "Bitmap":	
					Control.src = PValue;
					break;
			case "Jsonclick":
					Control.jsevent = PValue;
					break;
			case "Source":	
					if (PValue.indexOf(':') == -1 && PValue.indexOf('/') == -1)
						Control.src = gx.ajax.objectUrl(PValue);
					else
						Control.src = gx.util.resourceUrl(PValue, true);
					gx.evt.attach( Control, "load", gx.dom.autofitIFrame);
					break;
			case "Values":
					if ((Control.tagName == 'SELECT') || (Control.tagName == 'SPAN'))
					{
						PValue = gx.json.evalJSON(PValue);
						if (Control.tagName == 'SELECT')
						{
							gx.fn.loadComboBox(Control.id, PValue.v);
							gx.fn.setComboBoxValue(Control.id, PValue.s);
						}
						else
						{
							var ControlId = Control.id.substring(5);
							var sType = '';
							var Value = PValue.s;
							var vStruct = gx.O.getValidStructFld(ControlId);
							if (!gx.lang.emptyObject(vStruct))
								sType = vStruct.type;
							if (sType == 'int')
								Value = gx.text.trim(Value);
							else
								Value = gx.text.rtrim(Value);
							PValue.s = Value;
							gx.fn.setControlValue_span_safe( ControlId, gx.fn.selectedDescription(PValue));
						}
					}
					break;
			case "Width":
					if (Control.width)
						Control.width = PValue;
					Control.style.width = this.convertSize(PValue);
					break;
			case "Height":
					if (Control.height)
						Control.height = PValue;
					Control.style.height = this.convertSize(PValue);
					break;
		}
		var ctrlId = gx.dom.id(Control);
		if (ctrlId)
		{
			var propHidden = ctrlId + '_' + Property;
			if (gx.fn.isHidden(propHidden))
			{
				gx.fn.setHidden(propHidden, PValue);
			}
		}
	},
	
	convertSize: function(PValue){
	    if (gx.lang.instanceOf(PValue, Number) || (PValue.indexOf('%')==-1 && PValue.indexOf('px')==-1))
	        return PValue + 'px';
	    else 
	        return PValue;
	},
	
	setEnabledProperty: function( Control, Enabled) {
		var ctrlId = gx.dom.id(Control);
		if (gx.csv.validating == true)
		{
			if (Enabled && gx.csv.validActivatedControl == null && Control != gx.csv.lastControl)
			{
				var vStructId = gx.O.getValidStructId( ctrlId);
				if (vStructId > gx.csv.fromValid && vStructId <= gx.csv.toValid)
				{
					gx.csv.validActivatedControl = Control;
				}
			}
		}
		if (!Enabled)
			gx.util.addOnce( gx.disabledControls, Control, ctrlId);
		else
			delete gx.disabledControls[ctrlId];
		Control.gxusrdisabled = (!Enabled);
		if (Control.gxdisabled)
		{
			if (Control.gxdisabled == true)
				Control.disabled = true;
			else
				Control.disabled = Control.gxusrdisabled;
		}
		else
			Control.disabled = Control.gxusrdisabled;
	},
	
	showHideDatepicker: function( Control, Enabled) {
		var dpTable = gx.dom.el( gx.dom.id(Control) + '_dp_container');
		if (dpTable)
			dpTable.style.display = (Enabled)?'block':'none';
	},
	
	getGridCtrlProperty: function( gridId, ctrlId, prop) {
		try
		{
			if (gridId != 0)
			{
				var gridObj = this.getGridObj( gridId);
				if (gridObj)
				{
					var col = gridObj.grid.getColumnByHtmlName( ctrlId);
					if (col)
					{
						return col[prop.toLowerCase()];
					}
				}
			}
			else
			{
				return this.getCtrlProperty( ctrlId, prop);
			}
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'getGridCtrlProperty');
		}
		return  '';
	},
	
	getCtrlProperty: function( ControlId, Property) {
		var Control = this.screen_CtrlRef( ControlId);
		if (Control == null)
			return;
	  return this.getCtrlProperty_impl( Control, Property);
	},
	
	getCtrlProperty_impl: function( Control, Property) {
		if (Control == null)
			return "";
		switch( Property)
		{	
			case "Tooltiptext":	return Control.title;
			case "Visible": return Control.style.display != "none";
			case "Enabled": return Control.disabled == 0;
			case "Class": return Control.className;
			case "Backcolor": return gx.color.css( Control.style.backgroundColor);
			case "Forecolor": return gx.color.css( Control.style.color);
			case "Width": return gx.dom.dimensions(Control).w;
			case "Height": return gx.dom.dimensions(Control).h;
			case "Caption": return this.getCtrlCaption(Control);
			case "Fontbold": return (Control.style.fontWeight == 'bold');
			case "Fontitalic": return (Control.style.fontStyle == 'italic');
			case "Fontunderline": return (Control.style.textDecoration == 'underline');
			case "Fontstrikethru": return (Control.style.textDecoration == 'line-through');
			case "Fontname": return Control.style.fontFamily;
			case "Fontsize":
				{
					var size = parseInt(Control.style.fontSize);
					if (isNaN(size))
						return 12;
					return size;
				}
       		}
	},
	
	displayByType: function( NodeName) {
		switch( NodeName)
		{
			case 'TABLE':
			{
				if (!gx.util.browser.isIE() || (gx.util.browser.ieVersion() >= 8))
					return 'table';
				return 'block';
			}
			case 'P':
			case 'DIV': return 'block';
		}
		return 'inline';
	},
	
	setCtrlCaption: function( Control, PValue) {
		try
		{
			switch( Control.tagName)
			{
				case 'SPAN':
				case 'DIV':
				case 'FIELDSET':
					var ctrlFormat = Control.getAttribute('gxformat');
					if (ctrlFormat==null){
					    ctrlFormat=0;
					}
					gx.fn.setControlValue_fmt(Control, PValue, ctrlFormat);
					return;
				case 'INPUT':
					if (Control.type != 'checkbox')
						Control.value = PValue;
					return;
			}
			if (Control.nodeName == '#document')
			{
				Control.title = PValue;
			}
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'setCtrlCaption');			
		}
	},
	
	getCtrlCaption: function( Control) {
		switch( Control.tagName)
		{
			case 'SPAN':
			case 'DIV':
			case 'FIELDSET':
				var ctrlFormat = Control.getAttribute('gxformat');
				if (ctrlFormat!= null && ctrlFormat == '1')
					return Control.innerHTML;
				else
				{
					while(Control.firstChild != null && Control.firstChild.nodeName != '#text')
						Control = Control.firstChild;
					if (typeof(Control.innerText) != 'undefined')
						return Control.innerText;
					return Control.text;
				}
			case 'INPUT':
				if (Control.type != 'checkbox')
					return Control.value;
				break;
			default:
				return '';
		}
	},
	
	propertyValueFalse: function( Value) {
		if (typeof(Value) == "string")
		{
			Value = Value.toLowerCase();
			if ((Value == 'false') || (Value == '0'))
				return true;
		}
		return (Value == 0);
	},
	
	setButtonVisibility: function( Control, Visible) {
		var displayProp = Visible?'':'none';
		var buttonBackground = Control.parentNode;
		if (!gx.lang.emptyObject(buttonBackground) && buttonBackground.nodeName == 'SPAN')
		{
		
			buttonBackground.style.display = displayProp;
			var buttonRight = buttonBackground.parentNode;
			if (!gx.lang.emptyObject(buttonRight) && buttonRight.nodeName == 'SPAN')
		    {
				buttonRight.style.display = displayProp;
			    var buttonLeft = buttonRight.parentNode;
			    if (!gx.lang.emptyObject(buttonLeft) && buttonLeft.nodeName == 'SPAN')
				{
				    buttonLeft.style.display = displayProp;
				    var buttonRBtn = buttonLeft.parentNode;
			        if (!gx.lang.emptyObject(buttonRBtn) && buttonRBtn.nodeName == 'SPAN')
				        buttonRBtn.style.display = displayProp;
				}
			}
		}
		Control.style.display = displayProp;
	},
	
	setBlobValue: function( ControlId, Value) {
		var Control = gx.dom.el(ControlId) || gx.dom.el("Object_"+ControlId);
		this.setBlobUrl( Control, Value);
	},
	
	setBlobFiletype: function( Control, PValue) {
		if (Control != null)
		{
			var blobCtrl = Control;
			if (blobCtrl.nodeName == 'INPUT' && blobCtrl.type == 'file')
				blobCtrl = gx.dom.el("Object_"+Control.id);
			if (blobCtrl != null)
			{
				PValue = gx.util.getContentType( PValue);
				this.setObjectCtrlType( blobCtrl, PValue);
			}
		}
	},
	
	setBlobUrl: function( Control, PValue) {
		if (!PValue.match(/^[a-z]:[\S]*/i))
		{
			if (Control != null)
			{
				var blobCtrl = Control;
				if (blobCtrl.nodeName == 'INPUT' && blobCtrl.type == 'file')
					blobCtrl = gx.dom.el("Object_"+Control.id);
				if (blobCtrl != null)
				{
					var cType = gx.util.getContentTypeFromExt( PValue);
					blobCtrl = this.setObjectCtrlType( blobCtrl, cType);
				}
				if (blobCtrl != null)
				{
					if (blobCtrl.tagName == 'IMG')
					{
						if (PValue == '')
							PValue = gx.util.resourceUrl(gx.basePath + gx.staticDirectory + "blank.jpg", true);
						blobCtrl.src = PValue;
					}
					else
					{
						if (PValue == '')
							PValue = "about:blank";
						blobCtrl.data = PValue;
						this.resizeObject( blobCtrl);
					}
					gx.dom.redrawControl( blobCtrl);
				}
				else
				{
					blobCtrl = gx.dom.el("Link_"+Control.id);
					if (blobCtrl != null)
					{
						if (PValue != '')
							blobCtrl.style.display = "block";
						else
							blobCtrl.style.display = "none";
						blobCtrl.href = PValue;
					}
				}
				this.setFileSource( Control, '');
			}
		}
	},
	
	setFileSource: function( Control, Value) {
		if ((Control.tagName == 'INPUT') && (Control.type == 'file'))
		{
			if (Control.src != undefined)
				Control.src = Value;
			else
				Control.value = Value;
			gx.dom.redrawControl( Control);
		}
	},
	
	setObjectCtrlType: function( objCtrl, type) {
		var newCtrl = objCtrl;
		if (objCtrl.nodeName == 'IMG' && type.indexOf('image/') == 0)
			return newCtrl;
		if ((objCtrl.type != type) || (objCtrl.nodeName == 'OBJECT' && type.indexOf('image/') == 0))
		{
			if (type.indexOf('image/') == 0)
				newCtrl = gx.html.nodesFromText('<img id="' + objCtrl.id + '">')[0];
			else
				newCtrl = gx.html.nodesFromText('<object id="' + objCtrl.id + '" type="' + type + '">')[0];
			if (newCtrl)
			{
				try
				{
					for( var att in objCtrl.attributes)
					{
						if (att != "id" && att != "type" && att != "implementation")
						{
							if (objCtrl[att])
							{
								try{newCtrl[att] = objCtrl[att];}
								catch(e)
								{
									gx.dbg.logEx(e, 'gxfrmutl.js', 'setObjectCtrlType');
								}
							}
						}
					}
				}
				catch(e)
				{
					gx.dbg.logEx(e, 'gxfrmutl.js', 'setObjectCtrlType');
				}
				var pN = objCtrl.parentNode;
				if (pN)
				{
					var sibling = null;
					var childs = pN.childNodes.length;
					for (i=0; i<childs; i++)
					{
						if (pN.childNodes[i] == objCtrl)
						{
							if (i < childs-1)
								sibling = pN.childNodes[i+1];
							break;
						}
					}
					pN.removeChild( objCtrl);
					if (sibling != null)
						pN.insertBefore( newCtrl, sibling);
					else
						pN.appendChild( newCtrl);
				}
			}
		}
		return newCtrl;
	},
	
	resizeObject: function( oCtrl) {
		var eo = gx.lang.emptyObject;
		if (!eo(oCtrl.data) && oCtrl.data != 'about:blank')
		{
			if (eo(oCtrl.width) && eo(oCtrl.height) && eo(oCtrl.style.width) && eo(oCtrl.style.height))
			{
				oCtrl.style.width = '200px';
				oCtrl.style.height = '200px';
			}
		}
	},
	
	checkboxClick: function( Id, Control, Checked, UnChecked) {
		if (Control.checked)
			Control.value = Checked;
		else
			Control.value = UnChecked;
		var vStruct = gx.fn.validStruct( Id);
		if (vStruct)
			vStruct.c2v();
	},
	
	setCtrlClass: function( Control, Class) {
		if (Control == null)
			return;
		Control.className = Class;
	},
	
	setCtrlLink: function( Control, Link) {
		if (Control == null)
			return;
		if (Link == "")
		{
			this.unsetCtrlLink( Control);
			return;
		}
		var childCtrl = Control.firstChild;
		if (childCtrl && childCtrl.tagName == "A")
		{
			childCtrl.href = Link;
		}
		else
		{
			var ParentTag = Control.parentNode;
			if (ParentTag.tagName == "A")
			{
				ParentTag.href = Link;
			}
			else
			{
				var newA = document.createElement("A");
				newA.href = Link;
				if (childCtrl && childCtrl.nodeName == "#text")
				{
					newA.innerHTML = childCtrl.nodeValue;
					Control.replaceChild(newA, childCtrl);
				}
				else
				{
					ParentTag.replaceChild( newA, Control);
					newA.appendChild( Control);
				}
			}
		}
	},
	
	unsetCtrlLink: function( Control) {
		if (Control == null)
			return;
		var ParentTag = Control.parentNode;
		if (ParentTag.tagName == "A")
		{
			var ChildNode = ParentTag.firstChild;
			ParentTag2 = ParentTag.parentNode;
			if (ParentTag2 != null)
			{
				while( ChildNode != null)
				{
					ParentTag2.insertBefore( ChildNode,ParentTag);
					ChildNode = ParentTag.firstChild;					
				}
				ParentTag2.removeChild( ParentTag);
			}
		}
	},
	
	setCtrlLinkTarget: function( Control, target) {
		if (Control == null)
			return;
		if (Control.nodeName == 'SPAN' && Control.firstChild)
		{
			Control = Control.firstChild;
		}
		if (Control.nodeName == 'A')
		{
			if (Control.setAttribute)
			{
				Control.setAttribute('target', target);
			}
			else
			{
				Control.target = target;
			}
		}
	},
	
	isVisible: function( Control) {
		try
		{
			while (Control)
			{
				if ( Control.style && (Control.style.visibility == 'hidden' || Control.style.display == 'none'))
					return false;
				Control = Control.parentNode;
			}
		}
		catch( e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'isVisible');
		}
		return true;
	},
	
	gridRowIsMod: function( Lvl, Row) {
		var gxGrid = this.gridObjByLvl( Lvl);
	    var row = null;
	    if (gxGrid)
	    {
		    var row = gxGrid.grid.getRowByGxId(Row);
	        if (row)    	
		        return row.gxIsMod();
	        return true;
	    }
		var bRet = false;
		try
		{
			var isMod = this.getControlValue("nIsMod_" + Lvl + "_" + Row);
			bRet = (isMod == 1);
		}
		catch(e)
		{
			bRet = false;
		}
		return bRet;
	},
	
	gridObjByLvl: function( Lvl) {
		var objGrids = gx.O.Grids;
		var len = objGrids.length;
		for( var i=0;i<len;i++)
		{
		    if (objGrids[i].gridLvl == Lvl)
		        return objGrids[i];
		}
		return null;
	},
	
	forceEnableControls: function(Bool) {
		for( var Ctrl in gx.disabledControls)
		{
			Ctrl = this.getControlRef_list( Ctrl);
			var len = Ctrl.length;
			for( var i=0;i<len;i++)
			{
				try{
					if (Ctrl[i].type != 'button' && Ctrl[i].type != 'submit')
						Ctrl[i].disabled=Bool;
				}
				catch(e)
				{
					gx.dbg.logEx(e, 'gxfrmutl.js', 'forceEnableControls');
				}
			}
		}
	},
	
	alert: function( Ctrl, Message) {
		try
		{
			var gxballoon = gx.util.balloon.getNew(Ctrl.id);
			gxballoon.setError( Message);
			gxballoon.show();
			gx.csv.invalidForcedCtrl = Ctrl;
		}
		catch (e)
		{
			alert( Message);
		}
	},
	
	getGridRowMode: function( GXLvl, GridId) {
		var CurrentRow = this.currentGridRow( GridId);
		var IsRemoved = this.rowIsRemoved( GridId, CurrentRow);
		var RecordExists = this.getControlValue( "nRcdExists_" + GXLvl + '_' + CurrentRow);
		if (IsRemoved == "1")
			return "DLT";
		if (RecordExists == "0")
			return "INS";
		return "UPD";
	},
	
	rowIsRemoved: function( GridId, CurrentRow) {
		var gridCtrl = this.getGridObj( GridId);
		if( gridCtrl != null)
		{
			var gridCtrlRow = gridCtrl.grid.getRowByGxId(CurrentRow);
			if(gridCtrlRow)
			    return gridCtrlRow.gxDeleted();
		}
		return "0";
	},
	
	getGridObj: function( GridId) {
		return gx.O.getGridById(GridId);
	},
	
	changeCmpContext: function() {
		try
		{
			gx.O.SetStandaloneVars();
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'changeCmpContext');
		}
	},
	
	initOld: function(Ctrl) {
		if (gx.oldValues[Ctrl.id] == undefined)
		    gx.oldValues[Ctrl.id] = Ctrl.value;
	},
	
	setFocusOnError: function( ControlId) {
		var ctrlGrid = gx.fn.controlGridId( ControlId);
		var ctrlCmpId = gx.csv.ctxControlId( ControlId);
		var domCtrl = null;
		if (ctrlGrid == 0)
			domCtrl = gx.dom.el( ctrlCmpId);
		else
			domCtrl = gx.fn.getControlGridRef( ctrlCmpId, ctrlGrid);
		if(domCtrl != null)
		{
			gx.O.AnyError = 1;
			gx.csv.anyError = true;
			domCtrl.setAttribute( "gxvalid", "0");
			gx.fn.setFocus( domCtrl);
		}
	},
	
	usrSetFocus: function( ControlId) {
		ControlId = gx.csv.ctxControlId( ControlId);
		var Control = gx.dom.el( ControlId);
		if (Control != null)
			gx.fn.setFocus( Control);
	},
	
	setFocus: function( Control) {
		if (Control)
		{
			try
			{
				if (gx.popup.ispopup())
				{
					if (gx.util.browser.isIE() && window.parent.document.selection)
					{
						window.parent.document.selection.empty();
					}
					else if (window.parent.gx.csv.lastControl && window.parent.gx.csv.lastControl.blur)
					{
						window.parent.gx.csv.lastControl.blur();
					}
				}
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxfrmutl.js', 'setFocus');
			}
			try
			{
				try
				{
					if (!gx.lang.emptyObject(Control.id))
					{
						Control = gx.dom.byId(Control.id);
						gx.fn.setFocusSafe(Control);
					}
					else
					{
						gx.fn.setFocusSafe(Control);
					}
				}
				catch(e){gx.fn.setFocusSafe(Control);}
				gx.fn.setSelection( Control);
				Control.forcedFocus = true;
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxfrmutl.js', 'setFocus');
			}
		}
	},
	
	setFocusSafe: function( Control) {
		if (gx.util.browser.isFirefox())
		{
			gx.lang.doCallTimeout( Control.focus, Control, [], 100);
		}
		else
		{
			Control.focus();
		}
	},
	
	setFocusOnload: function() {
		var Control = null;
		var usrFocusId = gx.pO.getUserFocus();
		if (!gx.lang.emptyObject(usrFocusId))
		{
			if (usrFocusId == 'notset')
				return;
			var userControl = gx.pO.getUserControl( gx.uc.userControlContainerId(usrFocusId));
			if (!gx.lang.emptyObject(userControl))
			{
				userControl.setFocusBase();
				return;
			}
			else
			{
				gx.csv.userFocus = gx.fn.getControlRef( usrFocusId);
			}
		}
		if (gx.csv.userFocus == 'notset')
		{
			return;
		}
		Control = gx.csv.userFocus;
		if (!gx.fn.isAccepted(Control))
		{
			if (gx.csv.lastActiveControl && gx.fn.isAccepted(gx.csv.lastActiveControl))
			{
				Control = gx.csv.lastActiveControl;
			}
			else
			{
				var frmFirstEl = gx.fn.firstAcceptedControl(gx.popup.ispopup());
				Control = frmFirstEl;
			}
		}
	
		try
		{
			if (Control)
			{
				gx.csv.lastControl = Control;
				if (gx.fn.isAccepted( Control))
					gx.fn.setFocus( Control);
				else
					gx.popup.setFocus();
			}
			else
			{
				gx.popup.setFocus();
			}
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'setFocusOnload');
		}
	},
	
	setSelection: function( Control) {
		if (Control && gx.fn.isVisible(Control))
		{
			try
			{
				gx.csv.lastControl = Control;
				if (Control.type == "text" || Control.type == "password" || Control.type == "file")
					Control.select();
				else if (Control.nodeName == "TEXTAREA" || Control.nodeName == "SELECT")
					Control.focus();
				else
				{
					if( typeof(document.selection) != 'undefined')
					{
						setTimeout(function() { document.selection.empty(); }, 100);
					}
				}
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxfrmutl.js', 'setSelection');
			}
		}
	},
	
	isAccepted: function( Control) {
		var accepted = true;
		if (Control != null && Control.type != undefined && Control.type != "hidden" && gx.fn.isVisible( Control) 
				&& Control.disabled == false && (Control.readOnly == null || Control.readOnly == false))
		{
			var ControlId = gx.dom.id(Control); 
			var vStruct = gx.O.getValidStructFld(ControlId);
			var sMode = gx.getVar("Gx_mode");
			if (gx.csv.lastGrid > 0)
				gx.setVar("Gx_mode", gx.fn.getGridRowMode( gx.fn.gridLvl( gx.csv.lastGrid), gx.csv.lastGrid));
			if (!gx.lang.emptyObject(vStruct) && vStruct.nac)
				accepted = (vStruct.nac.call(gx.O)== false);
			else
				accepted = true;
			gx.setVar("Gx_mode", sMode);
		}
		else
		{
			accepted = false;
		}
		return accepted;
	},
	
	enterHasFocus: function() {
		gx.csv.lastControl;
		if (gx.csv.lastControl == null)
			return false;
		return gx.evt.isEnterEvtCtrl( gx.csv.lastControl);
	},
	
	skipFocus: function(skiponenter) {
		var el = gx.fn.getControlIndex( gx.csv.lastControl);
		if (el == -1)
			return true;
		var Control = null;
		for (Control = gx.fn.searchFocus( ++el, true);;Control = gx.fn.searchFocus( ++el, true))
		{
			if (Control == null || el == gx.dom.form().elements.length)
				el = -1;
			else
			{
			    if (skiponenter)
			        break;
				if (gx.evt.isEnterEvtCtrl( Control))
					break;
				if (Control.nodeName == 'INPUT' && Control.type != 'submit' && Control.type != 'button' && Control.type != 'image')
					break;
			}
		}
		gx.fn.setFocus( Control);	
	},
	
	getControlIndex: function( Ctrl) {
		var i_max = gx.dom.form().elements.length -1;
		var i_min = 0;
		el = this.controlIndex(Ctrl,i_min,i_max);	
		return el;
	},
	
	controlIndex: function( Ctrl,i_min,i_max) {
		if (!document.all)
		{
			return Ctrl.gxIndex;
		}
		else
		{	
			var frm = gx.dom.form();
			var i_minsi = frm.elements[i_min].sourceIndex;
			var i_maxsi = frm.elements[i_max].sourceIndex;
			var i_med = parseInt(i_min + ((i_max - i_min)/2)) + 1;
			var i_medsi = frm.elements[i_med].sourceIndex;
			if ((i_min == i_max) && (Ctrl.sourceIndex == i_minsi) && (Ctrl.sourceIndex == i_maxsi))
				return i_min;
			
			if (Ctrl.sourceIndex == i_minsi)
				return i_min;
			if (Ctrl.sourceIndex == i_maxsi)
				return i_max;
			if (Ctrl.sourceIndex == i_medsi)
				return i_med;
	
			if ((Ctrl.sourceIndex > i_medsi) && (Ctrl.sourceIndex < i_maxsi))
				return this.controlIndex(Ctrl,i_med+1,i_max-1);
				
			if ((Ctrl.sourceIndex > i_minsi) && (Ctrl.sourceIndex < i_medsi))
				return this.controlIndex(Ctrl,i_min+1,i_med-1);
		}	
	},
	
	searchFocus: function( el, Forward) {
		if ( Forward)
			return this.searchFocusFwd( el);
		return this.searchFocusBack( el);
	},
	
	searchFocusBack: function( el) {
		var frm = gx.dom.form();
		for(var i=el;i>=0;i--)
		{
			if (gx.fn.isAccepted( frm.elements[i]))
				return frm.elements[i];
		}
		return null;
	},
	
	searchFocusFwd: function( el) {
		var frm = gx.dom.form();
		var len = frm.elements.length;
		for(var i=el;i<len;i++)
		{
			if (gx.fn.isAccepted( frm.elements[i]))
				return frm.elements[i];
		}
		return null;
	},
	
	rowGridId: function( ctrl) {
		if (!ctrl || !ctrl.getAttribute)
			return null;
		var id = ctrl.getAttribute("gxgridid");
		if (id != null)
			return id;
		return gx.fn.rowGridId( ctrl.parentNode);
	},
	
	controlRowId: function( ctrl) {
		if (!ctrl  || !ctrl.getAttribute)
			return null;
		var id = ctrl.getAttribute("gxrow");
		if (id != null)
			return id;
		return gx.fn.controlRowId( ctrl.parentNode);
	},
	
	controlGridId: function( Fld) {
		try
		{
			var ctrlIds = gx.fn.controlIds();
			var len = ctrlIds.length;
			for (i=0;i<len;i++)
			{
			  var _GXValidStruct = gx.fn.validStruct(ctrlIds[i]);
				if (_GXValidStruct != undefined && _GXValidStruct.fld == Fld)
					return _GXValidStruct.grid;
			}
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'controlGridId');
		}
		return 0;
	},
	
	oldGridId: function( Name) {
		try
		{
			var ctrlIds = gx.fn.controlIds();
			var len = ctrlIds.length;
			for (i=0;i<len;i++)
			{
			  var _GXValidStruct = gx.fn.validStruct(ctrlIds[i]);
				if (_GXValidStruct != undefined && _GXValidStruct.gxold == Name)
					return _GXValidStruct.grid;
			}
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'oldGridId');
		}
		return 0;
	},
	
	saveLvlOldParm: function( Name, Value) {
		var gxMode = 'no_mode';
		if (gx.csv.validatingGrid != null)
		{
			if (this.isLvlParmOld( gx.csv.lastGrid, Name))
			{
				gxMode = gx.fn.getGridRowMode( gx.fn.gridLvl( gx.csv.lastGrid), gx.csv.lastGrid);
			}
		}
		else if (this.isLvlParmOld( 0, Name))
		{
			gxMode = gx.O.Gx_mode;
		}
		if (gxMode == 'no_mode')
			return true;
		if ((gxMode == "UPD") || (gx.csv.validatingGrid == null))
		{
			window[Name] = Value;
			return true;
		}
		return false;
	},
	
	isLvlParmOld: function( GridId, Name) {
		try
		{
			var oldLvl = gx.O.getOldLvl( Name);
			if (oldLvl >= 0)
			{
				if (GridId > 0)
				{
					var gridLvl = gx.fn.gridLvl( GridId);
					return (oldLvl < gridLvl);
				}
				return true;
			}
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'isLvlParmOld');
		}
		return false;
	},
	
	gridLvl: function( GridId) {
		try
		{
			var ctrlIds = gx.fn.controlIds();
			var len = ctrlIds.length;
			for (i=0;i<len;i++)
			{
			    var _GXValidStruct = gx.fn.validStruct(ctrlIds[i]);
				if (_GXValidStruct != undefined && _GXValidStruct.grid == GridId)
					return _GXValidStruct.lvl;
			}
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'gridLvl');
		}
		return 0;
	},
	
	lvlGrid: function( Lvl) {
		try
		{
			var ctrlIds = gx.fn.controlIds();
			var len = ctrlIds.length;
			for (i=0;i<len;i++)
			{
				var _GXValidStruct = gx.fn.validStruct(ctrlIds[i]);
				if (_GXValidStruct != undefined && _GXValidStruct.lvl == Lvl)
					return _GXValidStruct.grid;
			}
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'lvlGrid');
		}
		return 0;
	},
	
	vStructId: function( CtrlId) {
		try
		{
			var ctrlIds = gx.fn.controlIds();
			for (i=0;i<ctrlIds.length;i++)
			{
				var validStruct = gx.fn.validStruct(ctrlIds[i]);
				if (validStruct != undefined && validStruct.fld == CtrlId)
					return ctrlIds[i];
			}
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'vStructId');
		}
		return 0;
	},
	
	getVStruct: function( condFunc, allWCond) {
		try
		{
			var ret = null;
			if (allWCond)
			{
				ret = [];
			}
			var ctrlIds = gx.fn.controlIds();
			var len = ctrlIds.length;
			for (i=0;i<len;i++)
			{
				var vStruct = gx.fn.validStruct(ctrlIds[i]);
				if (vStruct != undefined && condFunc(vStruct))
				{
					vStruct.id = ctrlIds[i];
					if (allWCond)
					{
						ret.push(vStruct);
					}
					else
					{
						return vStruct;
					}
				}
			}
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'getVStruct');
		}
		return ret;
	},
	
	vStructForOld: function( GXVarName) {
		return gx.fn.getVStruct( function( vStruct) {
			return vStruct.gxold == GXVarName;
		});
	},
	
	vStructForVar: function( GXVarName) {
		return gx.fn.getVStruct( function( vStruct) {
			return vStruct.gxvar == GXVarName;
		});
	},
	
	vStructForVarWId: function( GXVarName, Id) {
		var vStructs = gx.fn.getVStruct( function( vStruct) {
									return vStruct.gxvar == GXVarName;
								}, true);
		var vStruct = vStructs[0];
		var len = vStructs.length;
		if (len > 1)
		{
			for (var i=0; i<len; i++)
			{
				vStruct = vStructs[i];
				if (vStruct.id == Id)
				{
					break;
				}
			}
		}
		return vStruct;
	},
	
	vStructForHC: function( GXVarName) {
		return gx.fn.getVStruct( function( vStruct) {
			return vStruct.hc == GXVarName;
		});
	},
	
	firstCtrlAfterGrid: function(fromCtrl, gridId) {
		var lastCtrl = gx.fn.lastCtrlId();
		for(var i=fromCtrl; i<lastCtrl; i++)
		{
			var validStruct = gx.fn.validStruct(i);
			if(validStruct != undefined && validStruct.grid != gridId)
				return i;
		}
		return lastCtrl;
	},
	
	clearOldKeys: function() {
		gx.oldKeyValues = [];
	},
	
	oldKey: function( Fld) {
		try
		{
			return gx.oldKeyValues[Fld];
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'oldKey');
		}
		return '';
	},
	
	oldGridKey: function( Fld, GridId) {
		try
		{
			return gx.oldKeyValues[Fld + gx.fn.currentGridRow( GridId)];
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'oldGridKey');
		}
		return '';
	},
	
	setKey: function( Fld, Var) {
		if (Fld != null)
		{
			gx.oldKeyValues[Fld] = Var;
		}
	},
	
	unsetKey: function( Fld) {
		if (Fld != null)
		{
			gx.oldKeyValues[Fld] = undefined;
		}
	},
	
	setGridKey: function( Fld, GridId, Var) {
		if (Fld != null)
		{
			gx.oldKeyValues[Fld + gx.fn.currentGridRow( GridId)] = Var;
		}
	},
	
	unsetGridKey: function( Fld, GridId) {
		if (Fld != null)
		{
			gx.oldKeyValues[Fld + gx.fn.currentGridRow( GridId)] = undefined;
		}
	},
	
	removeGridRow: function(CurrentRow, GridId) {
		var IsRemoved = gx.fn.rowIsRemoved( GridId, CurrentRow);
		try
		{
			var ctrlIds = gx.fn.controlIds();
			var len = ctrlIds.length;
			for (i=0;i<len;i++)
			{
				var _GXValidStruct = gx.fn.validStruct(ctrlIds[i]);
				if ( _GXValidStruct != undefined && _GXValidStruct.grid == GridId)
				{
					var Ctrl = gx.dom.el( _GXValidStruct.fld + "_" + CurrentRow);
					if (Ctrl != null)
					{
						Ctrl.gxdisabled = IsRemoved;
					}
				}
			}
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'removeGridRow');
		}
		gx.csv.validGridRow( GridId, CurrentRow);
	},
	
	controlIds: function() {
		return gx.O.getControlIds();
	},
	
	validStruct: function(Ctrl) {
		return gx.O.getValidStruct(Ctrl);
	},
	
	lastCtrlId: function() {
	  return gx.O.getLastControlId();
	},
	
	vStructsArray: function() {
		return gx.O.GXValidFnc;
	},
	
	firstAcceptedControl: function( mindButtons) {
		try
		{
			var vStructs = gx.fn.vStructsArray();
			var ctrlIds = gx.fn.controlIds();
			var len = ctrlIds.length;
			for (var i=0;i<len;i++)
			{
				var vStruct = vStructs[ctrlIds[i]];
				if (vStruct != null)
				{
					var control = gx.fn.getControlGridRef( vStruct.fld, vStruct.grid);
					if ((control != null) && gx.fn.isAccepted( control))
						return control;
				}
			}
			if (mindButtons)
			{
				var inputs = gx.dom.byTag('input');
				len = inputs.length;
				if (!len)
					return null;
				for (var i=0; i<len; i++)
				{
					var control = inputs[i];
					var inType = control.getAttribute('type').toLowerCase();
					if ((inType == 'submit') || (inType == 'image') || (inType == 'button'))
						return control;
				}
			}
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'firstAcceptedControl');
		}
		return null;
	},
	
	setNewRow: function( GridId, GXValidRow, state) {
		if (gx.newRows[GridId] == null)
			gx.newRows[GridId] = [];
		gx.newRows[GridId][GXValidRow] = state;
	},
	
	enableDisableDelete: function() {
		var btnDelete = gx.dom.el( gx.csv.cmpCtx+"BTN_DELETE");
		if(btnDelete != null)
			gx.fn.setCtrlPropertyImpl( btnDelete, "Enabled", (gx.getVar("Gx_mode") == 'INS')?0:1);
	},
	
	setFocusAfterLoad: function() {
		if (gx.csv.validating == true)
			return;
		gx.csv.invalidateForm();
		gx.csv.onloadFocus = true;
		if( !gx.lang.emptyObject(gx.usrFocusControl))
			gx.fn.setFocus( gx.dom.byId(gx.usrFocusControl));
		else if( !gx.lang.emptyObject(gx.csv.lastControl))
			gx.fn.setFocus( gx.csv.lastControl);
		else
			gx.fn.setFocus( gx.fn.firstAcceptedControl());
		gx.csv.onloadFocus = false;
	},
	
	isNewRow: function( GridId, GXValidRow) {
		try
		{
			return gx.newRows[GridId][GXValidRow];
		}
		catch(e)
		{
			return true;
		}
	},
	
	disableCtrl: function(ControlId) {
		try
		{
			var Control = gx.fn.getControlRef_list( ControlId);
			if (Control == null)
				return;
			var len = Control.length;
			for( var i=0;i<len;i++)
				gx.fn.setCtrlPropertyImpl( Control[i], "Enabled", 0);
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'disableCtrl');
		}
	},
	
	refreshFormBC: function( bcName, bcData) {
		try
		{
			var bc = gx.O.getFormBC( bcName);
			if (typeof(bc) != 'undefined')
			{
				gx.O.bcToScreen( bc, bcData);
				gx.setVar(bcName, bcData);
				gx.fn.setGridHidden(bcName, bcData);
				return true;
			}
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'refreshFormBC');
		}
		return false;
	},

	isHidden: function(HiddenName) {
		if (gx.http.viewState==null)
		{
			gx.http.loadState();
		}
		return (typeof(gx.http.viewState[HiddenName]) != 'undefined');
	},
	
	getHidden: function(HiddenName) {
		if (gx.http.viewState==null)
		{
			gx.http.loadState();
		}
		return gx.http.viewState[HiddenName];    
	},
	
	setHidden: function(HiddenName, Value) {
		if (gx.http.viewState==null)
		{
			gx.http.loadState();
		}
		gx.http.viewState[HiddenName] = Value;
	},
	
	setGridHidden: function(HiddenName, Value) {
		var GridHiddenName = HiddenName;
		var GridId = gx.fn.oldGridId( HiddenName);
		if (GridId > 0)
		{
			GridHiddenName = HiddenName + '_' + gx.fn.currentGridRowImpl(GridId);
		}
		gx.fn.setHidden(GridHiddenName, Value);
	},
	
	deleteHidden: function(HiddenName) {
		if (gx.http.viewState!=null)
		{
			try { eval( "delete gx.http.viewState." + HiddenName + ";"); }
			catch(e)
			{
				gx.dbg.logEx(e, 'gxfrmutl.js', 'deleteHidden');
			}
		}
	},
	
	setPostHiddens: function(gxHiddens) {
		for (var CtrlName in gxHiddens)
		{
			gx.fn.setGridHidden(CtrlName, gxHiddens[CtrlName]);
		}
	},
	
	setPostValues: function(gxValuesArr) {
		if (!gxValuesArr)
			return;
		var oldObj = gx.O;
		var len = gxValuesArr.length;
		for (var i=0; i<len; i++)
		{
			var gxValues = gxValuesArr[i];
			var cmpCtx = gxValues.CmpContext;
			var isMPage = gx.lang.booleanValue(gxValues.IsMasterPage);
			gx.setGxO( cmpCtx, isMPage);
			if (!gx.lang.emptyObject(gx.O))
			{
				for (var Property in gxValues)
				{
					if (Property == 'CmpContext' || Property == 'IsMasterPage')
						continue;
					if (typeof(gxValues[Property]) == 'object')
					{
						if (gx.fn.refreshFormBC( Property, gxValues[Property]))
							continue;
					}
					if (typeof(gxValues[Property]) != "function")
					{
						var validStruct = gx.fn.vStructForVar(Property);
						if(validStruct != null)
						{
							validStruct.v2v( gxValues[Property]);
							if (validStruct.v2c != null)
								validStruct.v2c();
						}
						else if( Property == "GX_FocusControl")
						{
							if ((oldObj.CmpContext == cmpCtx) && (oldObj.IsMasterPage == isMPage))
								gx.usrFocusControl = gxValues[Property];
						}
						else
						{
							var ctrlMap = gx.fn.getVarControlMap( Property);
							if (!gx.lang.emptyObject(ctrlMap))
								gx.setVar(ctrlMap, gxValues[Property]);
							else
								gx.setVar(Property, gxValues[Property]);
							gx.fn.setGridHidden(Property, gxValues[Property]);
						}
					}
				}
			}
		}
		gx.setGxO( oldObj.CmpContext, oldObj.IsMasterPage);
	},
	
	setPostProperties: function(gxPropertiesArr) {
		if (!gxPropertiesArr)
			return;
		var oldObj = gx.O;
		var len = gxPropertiesArr.length;
		for (var i=0; i<len; i++)
		{
			var gxProperties = gxPropertiesArr[i];
			var cmpCtx = gxProperties.CmpContext;
			var isMPage = gx.lang.booleanValue(gxProperties.IsMasterPage);
			gx.setGxO( cmpCtx, isMPage);
			if (!gx.lang.emptyObject(gx.O))
			{
				for (var Control in gxProperties)
				{
					if (Control == 'CmpContext' || Control == 'IsMasterPage')
						continue;
					if (gx.uc.isUserControl( Control))
						gx.uc.setProperties( Control, gxProperties[Control]);
					else if (typeof(gxProperties[Control]) != "function")
					{
						var domCtrl = gx.fn.getControlRef( Control, true);
						for (var Property in gxProperties[Control])
						{
							if (typeof(gxProperties[Control][Property]) == "object")
							{
								for (var InProperty in gxProperties[Control][Property])
								{
									gx.fn.setCtrlPropertyImpl( domCtrl, InProperty, gxProperties[Control][Property][InProperty]);
								}
							}
							else
							{
								gx.fn.setCtrlPropertyImpl( domCtrl, Property, gxProperties[Control][Property]);
							}
							if (Property == 'Filetype' || Property == 'URL')
								domCtrl = gx.fn.getControlRef( Control, true);
						}
					}
				}
			}
		}
		gx.setGxO( oldObj.CmpContext, oldObj.IsMasterPage);
	},
	
	loadPostGrids: function( PostGrids) {
		if(PostGrids != undefined)
		{
			var len = PostGrids.length;
			for (var i=0; i<len; i++)
			{
				try
				{
					var gGridProps = PostGrids[i];
					if (gGridProps.Count != undefined)
					{
						var cmpCtx = gGridProps.CmpContext;
						var gridName = gGridProps.GridName;
						var vGrid = gx.csv.validatingGrid;
						if (gx.lang.emptyObject(vGrid) || ((vGrid.gxComponentContext != cmpCtx) && (vGrid.gridName != gridName)))
						{
							var inMasterPage = (gGridProps.InMasterPage == "true")?true:false;
							gx.fn.gridObj( cmpCtx, gridName, inMasterPage).loadGrid( gGridProps, true);
						}
					}
				}
				catch(e)
				{
					gx.dbg.logEx(e, 'gxfrmutl.js', 'loadPostGrids');
				}
			}
		}
	},
	
	getErrorViewerCtrls: function() {
		var gxErrorViewers = gx.dom.byName("gxErrorViewer");
		if (gxErrorViewers.length == 0)
		{
			gxErrorViewers = [];
			var spans = gx.dom.byTag("span");
			var len = spans.length;
			for (var i=0; i<len; i++)
			{
				if (spans[i].name == "gxErrorViewer")
					gxErrorViewers.push(spans[i]);
			}
		}
		return gxErrorViewers;
	},
	
	setErrorViewer: function(Messages) {
		gx.O.AnyError = 0;
		if (!Messages)
			return;
		try
		{
			gx.fx.obs.notify('gx.onmessages', [Messages]);
		    for (var cmpCtx in Messages)
		    {
		        var locMessages = Messages[cmpCtx];
		        if (cmpCtx=="MAIN")
		        {
		            cmpCtx="";
		        }
		        var gxErrorViewer = gx.dom.byId(cmpCtx + "gxErrorViewer");
		        if (gxErrorViewer && typeof(locMessages) != 'undefined')
		        {
					var html = '';
					var sep = '';
					
					var balloons = {};
					for (var Property in locMessages)
					{   
						var ObjMessage = locMessages[Property];
						if (ObjMessage && ObjMessage.type == 1)
						{
							gx.O.AnyError = 1;
						}
						if (!gx.lang.emptyObject(ObjMessage.text))
						{
							if (typeof(ObjMessage) != "function")
							{
								if (ObjMessage.att != "")
								{
									var b = balloons[ObjMessage.att];
									if (!b)
									{
										b = gx.util.balloon.getNew(ObjMessage.att);
										balloons[ObjMessage.att] = b;
									}
									if (ObjMessage.type == 1)
										b.setError(ObjMessage.text);
									else
										b.setMessage(ObjMessage.text);
								}
								else
								{
									html += sep + '<span align="left">' + ObjMessage.text + '</span>';
									sep = '<BR/>';
								}
							}
						}
					}
					for (var att in balloons)
					{
						var b = balloons[att];
						if (b.show() == false)
						{
							gx.fn.setFocusOnError( att);
							break;
						}
					}
					
					if (gxErrorViewer.innerHTML != html)
					{
						gxErrorViewer.innerHTML = html;
						if (html != '')
						{
							var ef = gx.fx.dom.highlight(gxErrorViewer, [255,255,165], 2500);
							ef.play();
						}
					}
		        
		        }
		    }
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'setErrorViewer');
		}
	},
	
	cmpContextFromCtrl: function( CtrlName) {
		var cmpRegex = /((?:(?:MP)?W[0-9a-zA-Z\-]{4}[\S]*)*)gxHTMLWrp((?:MP)?W[0-9]{4}[\S]*)*/
		var cmpType = cmpRegex.exec(CtrlName);
		if (cmpType)
		{
			return cmpType[1] + cmpType[2];
		}
		return CtrlName;
	},
	
	setPostComponents: function(gxComponents, gxComponentsMap, callback) {
		try
		{
			var toCreate = [];
			var except = false;
			var isDotNet = gx.gen.isDotNet();
			for (var Component in gxComponents)
			{
				if (typeof(gxComponents[Component]) != "function")
				{
					try
					{
						var cmpHtml = gxComponents[Component];
						var Cmp = gx.dom.el( Component);
						if (!Cmp && gxComponentsMap)
						{
							Cmp = gx.dom.el(gxComponentsMap[Component]);
						}
						if (!gx.lang.emptyObject(Cmp))
						{
							gx.html.setInnerHtml(Cmp, cmpHtml);
							var cmpType = gx.fn.cmpContextFromCtrl(Component);
							var cmpName = gx.fn.getHidden(cmpType+'_CMPPGM');
							var parts = cmpName.split('.');
							var pLen = parts.length;
							if (isDotNet && (pLen > 1))
								cmpName = parts[pLen-2].toLowerCase();
							else
								cmpName = parts[pLen-1].toLowerCase();
							toCreate.push({ type:cmpType, name: cmpName, html: cmpHtml });
						}
					}
					catch(e)
					{
						except = true;
						gx.dbg.logEx(e, 'gxfrmutl.js', 'setPostComponents');
					}
				}
			}
		}
		catch(e)
		{
			except = true;
			gx.dbg.logEx(e, 'gxfrmutl.js', 'setPostComponents');
		}
		if ((toCreate.length == 0 || except) && typeof(callback) == 'function')
		{
			callback();
		}
		else
		{
			var component = null;
			var nextCmp = function() {
				if (toCreate.length > 0)
				{
					component = toCreate.shift();
					gx.fn.createComponentAsync( component, nextCmp);
				}
				else if (typeof(callback) == 'function')
				{
					callback();
				}
			};
			component = toCreate.shift();
			gx.fn.createComponentAsync( component, nextCmp);
		}
	},
	
	createComponentAsync: function( cmp, callback) {
		var cmpType = cmp.type;
		var cmpName = cmp.name;
		var cmpHtml = cmp.html;
		try
		{
			if (!gx.cache.codeLoaded(cmpType + cmpName))
			{
				gx.cache.addInlineCode( cmpType + cmpName);
				gx.html.processCode( cmpHtml, false, function(cName, cType) {
					gx.fn.createComponentObj( cName, cType);
					if (typeof(callback) == 'function')
					{
						callback();
						return;
					}
				}, [cmpName, cmpType], cmpName);
			}
			else
			{
				gx.fn.createComponentObj( cmpName, cmpType);
				if (typeof(callback) == 'function')
				{
					callback();
				}
			}
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'createComponentAsync');
			if (typeof(callback) == 'function')
			{
				callback();
			}
		}
	},
	
	createComponentObj: function( cmpName, cmpType) {
		var gxComp = gx.createComponent( cmpName, cmpType);
		if (gxComp != null)
		{
			gx.addComponent( gxComp);
		}
	},
	
	getAttachedCtrl: function( ControlId) {
		var len = gx.attachedControls.length;
		for (var j=0; j<len; j++)
		{
			var aCtrl = gx.attachedControls[j];
			if (aCtrl.id == ControlId)
				return aCtrl;
		}
		return null;
	},
	
	attachCtrl: function(ControlId, CtrlInfo) {
		var ctrl = gx.fn.getAttachedCtrl( ControlId);
		if (ctrl == null)
			gx.attachedControls.push( {id:ControlId, info:CtrlInfo});
	},
	
	doAttachs: function() {
		var attachedControls = gx.fn.attachedControls();
		var len = attachedControls.length;
		var gxO = gx.O;
	  	for (var j=0; j<len; j++)
	      {
			var aCtrl = attachedControls[j];
			gx.setGxO( aCtrl.info.wc, aCtrl.info.mp);
			if (aCtrl.info.isPrompt && gx.O.isTransaction() && gx.O.Gx_mode == 'DSP')
			{
				gx.fn.setCtrlPropertyImpl( gx.dom.el(aCtrl.info.wc + aCtrl.id), 'Visible', false);
			}
			else
			{
				var ArrCtrl = aCtrl.info.controls;
				var len1 = ArrCtrl.length;
				for( var i=0;i<len1;i++)
				{
					gx.fn.addAttach( ArrCtrl[i], aCtrl);
					var Field = gx.fn.validStruct(ArrCtrl[i]).fld;
					gx.fn.checkAttachedProperty( Field, "Visible", false);
					gx.fn.checkAttachedProperty( Field, "Enabled", false);
				}
			}
		}
		gx.setGxO( gxO.CmpContext, gxO.IsMasterPage);
	},
	
	addAttach: function( i, ref) {
	  var validStruct = gx.fn.validStruct(i);
	  if (validStruct.attachedCtrls == undefined)
	    validStruct.attachedCtrls = [];
	  validStruct.attachedCtrls.push( ref);
	},
	
	checkAttachedProperty: function( FieldId, Property, Enable) {
	  var validStruct = gx.O.getValidStructFld( FieldId);
	  if (validStruct == undefined)
	    return;
	  var attachedCtrls = validStruct.attachedCtrls;
	  if (attachedCtrls == undefined)
	    return;
	  var len = attachedCtrls.length;
	  for( var i=0;i<len;i++)
	    gx.fn.checkAttachedControlProperty( attachedCtrls[i], Property, Enable)
	},
	
	checkAttachedControlProperty: function( attachedCtrls, Property, Enable) {
		var ControlId = attachedCtrls.id;
		attachedCtrls = attachedCtrls.info;
		var ok = false;
		var ArrCtrl = attachedCtrls.controls;
		var WC = attachedCtrls.wc;
		var len = ArrCtrl.length;
		for( var i=0;i<len && !ok;i++)
		{
			if ( gx.fn.getCtrlProperty_impl( gx.dom.el(WC+gx.fn.validStruct(ArrCtrl[i]).fld), Property) == Enable)
			{
				ok = ((Enable == true) || (i == len - 1));
			}
		}
		if (ok)
		{
			gx.fn.setCtrlPropertyImpl( gx.dom.el(WC+ControlId), Property, Enable);
		}
	},
	
	changeControlOpacity: function( Control, OpacStart, OpacEnd, Milliseconds) { 
		var fadeSpeed = Math.round(Milliseconds); 
		var controlId = "";
		if(typeof(Control) == 'string')
			controlId = Control;
		else
			controlId = Control.id;
		if(OpacStart > OpacEnd)
		{ 
			gx.fn.setOpacity(OpacStart, controlId);
			setTimeout( function() {
										gx.fn.changeControlOpacity(Control, OpacStart-10, OpacEnd, Milliseconds);
									}, fadeSpeed);
		}
		else if(OpacStart < OpacEnd)
		{
			gx.fn.setOpacity(OpacStart, controlId);
			setTimeout( function() {
										gx.fn.changeControlOpacity(Control, OpacStart+10, OpacEnd, Milliseconds);
									}, fadeSpeed);
		}
		else
		{
			gx.fn.setOpacity(OpacEnd, controlId);
		}
	},
	
	setOpacity: function( Opacity, ControlId) { 
    var control = ControlId;
    if (typeof(ControlId) == "string")
    {
    	if (ControlId == "body")
				control = document.body;
			else
    		control = gx.dom.el(ControlId);
    }
    if (control != null)
    {
	    var styleObj = control.style; 
	    styleObj.opacity = (Opacity / 100); 
	    styleObj.MozOpacity = (Opacity / 100); 
	    styleObj.filter = "alpha(opacity=" + Opacity + ")";
  	}
	},
	
	fadeControl: function( Control, Direction, Milliseconds) {
		if (Direction == "in")
			gx.fn.changeControlOpacity( Control, 0, 100, Milliseconds);
		else
			gx.fn.changeControlOpacity( Control, 100, 0, Milliseconds);
	},
	
	fadeIn: function( Control, Milliseconds) {
		gx.fn.fadeControl( Control, "in", Milliseconds);
	},
	
	statusMsg: function( Txt) {
		window.status = Txt;
	},
	
	objectOnload: function() {
		if (gx.pO != null)
		{
			gx.pO.onload();
			gx.setGxO( gx.pO.CmpContext, gx.pO.IsMasterPage);
		}
	},
	
	objectOnUnload: function() {
		if (gx.pO != null)
		{
			gx.pO.onunload();
		}
	},
	
	objectOnpost: function() {
		if (gx.pO != null)
		{
			gx.pO.onpost();
		}
	},
	
	objectPostback: function() {
		if (gx.pO != null)
		{
			gx.pO.postbackLoad();
		}
	},
	
	gridObjFromGxO: function( GridName) {
		return gx.fn.gridObj( gx.O.CmpContext, GridName, gx.O.IsMasterPage);
	},
	
	gridObj: function( CmpCtx, GridName, InMasterPage) {
		return gx.getObj( CmpCtx, InMasterPage).getGrid( GridName);
	},
	
	installComponents: function() {
		var cmpObjs = gx.fn.getHidden("GX_CMP_OBJS");
		if (cmpObjs != undefined)
		{
			var isDotNet = gx.gen.isDotNet();
			for (var cmpCtx in cmpObjs)
			{
				var cmpType = cmpObjs[cmpCtx].toLowerCase();
				var parts = cmpType.split('.');
				var pLen = parts.length;
				if (isDotNet && (pLen > 1))
					cmpType = parts[pLen-2];
				else
					cmpType = parts[pLen-1];
				var gxComp = gx.createComponent( cmpType, cmpCtx);
				if (gxComp != null)
				{
					gx.addComponent( gxComp);
					setTimeout(function() {gx.fn.addComponentRemoteFiles(cmpCtx);}, 1);
				}
			}
		}
	},
	
	addComponentRemoteFiles: function( CmpCtx) {
		var cmpRegex = /((?:(?:MP)?W[0-9]{4})*)((?:MP)?W[0-9]{4})/
		var cmpType = cmpRegex.exec(CmpCtx);
		var cmpCtrl = gx.dom.el( cmpType[1] + "gxHTMLWrp" + cmpType[2]);
		if (cmpCtrl != null)
		{
			gx.html.processCode( cmpCtrl.innerHTML, true);
			gx.dom.fitToParent( cmpCtrl);
		}
	},
	
	datePickerFormat: function(Picture, Dec, Len) {
		var dateFmt = gx.dateFormat;
		var D1 = dateFmt.substr(0, 1);
		var D2 = dateFmt.substr(1, 1);
		var D3 = dateFmt.substr(2, 1);
		
		var DD1 = gx.fn.datePickerDateFormat(D1, Picture);
		var DD2 = gx.fn.datePickerDateFormat(D2, Picture);
		var DD3 = gx.fn.datePickerDateFormat(D3, Picture);
		var DT = gx.fn.datePickerTimeFormat(Dec);
		if (Len>0 && Dec>0)
			return DD1 + '/' + DD2 + '/' + DD3 + ' ' + DT;
		else if (Len>0)
			return DD1 + '/' + DD2 + '/' + DD3;
		else
			return DT;
	},
	
	datePickerDateFormat: function(FormatPart, Picture) {
		if (FormatPart=='Y' && Picture.substr(0, 10) == '99/99/9999')
			return '%Y';
		else if (FormatPart=='Y')
			return '%y';
		else if (FormatPart=='M')
			return '%m';
		else if (FormatPart=='D')
			return '%d';
		else return '';
	},
	
	datePickerTimeFormat: function(Dec) {
		var timeFmt = gx.timeFormat;
		var DPTF, AMPM, TimeFmt;
		if (timeFmt == 12)
		{
			DPTF = '%I';
			AMPM = ' %p';
		}else if (timeFmt == 24)
		{
			DPTF = '%H';
			AMPM = '';
		}else
		{
			DPTF = '';
			AMPM = '';
		}
		if (Dec == 2)
			TimeFmt = '';
		else if (Dec == 5)
			TimeFmt = ':%M';
		else if (Dec ==8)
			TimeFmt = ':%M:%S';
		else 
			return '';
		
		return DPTF + TimeFmt + AMPM;
	},
	
	installDatePicker: function(ControlId, Flat, ShowsTime, WeekNumbers, MondayFirst, Format) {
		gx.html.onTypeAvailable('Calendar', gx.fn.installDatePickerIfReady, [ControlId, Flat, ShowsTime, WeekNumbers, MondayFirst, Format]);
	},
	
	installDatePickerIfReady: function(ControlId, Flat, ShowsTime, WeekNumbers, MondayFirst, Format) {
		var dpCtrl = gx.dom.el( ControlId);
		if (!gx.lang.emptyObject( dpCtrl) && dpCtrl.nodeName == 'SELECT')
			return;
		if (Flat == 0)
			Calendar.setup( {inputField:ControlId, showsTime: ShowsTime, weekNumbers: WeekNumbers, mondayFirst: MondayFirst , ifFormat: Format, button:ControlId + "_dp_trigger", onSelect: gx.fn.datePickerChanged, align:"Bl",singleClick:true});
		else
		{
			if (!gx.lang.emptyObject( dpCtrl))
				dpCtrl.style.display = 'none';
			Calendar.setup( {inputField:ControlId, showsTime: ShowsTime, weekNumbers: WeekNumbers, mondayFirst: MondayFirst , ifFormat: Format, flat:ControlId + "_dp_container", flatCallback: gx.fn.datePickerChanged, align:"Bl",singleClick:true});
		}
	},
	
	datePickerChanged: function(calendar, date, control) {
		if (calendar && calendar.dateClicked)
		{
			if (!control)
				control = calendar.params.inputField;
			var currentObject = gx.O;
			var validStruct = null;
			var ctrlIds = gx.fn.controlIds();
			var len = ctrlIds.length;
			for (i=0;i<len;i++)
			{
				validStruct = gx.fn.validStruct(ctrlIds[i]);
				var sRow = (validStruct.grid != 0)?'_' + gx.fn.currentGridRow( validStruct.grid):'';
				var controlId = currentObject.CmpContext + validStruct.fld + sRow;
				if (control.id ==controlId)
					break;
			}
			if ((validStruct != null) && (validStruct.dp != undefined))
			{
				var newValue = calendar.date.print(gx.fn.datePickerFormat(validStruct.dp.pic, validStruct.dp.dec, validStruct.len));
				if (newValue != control.value)
				{
					control.setAttribute( "gxvalid", "0");
					control.value=newValue;			
					calendar.callCloseHandler();
					if (validStruct.grid > 0)
					{
						gx.fn.getGridObj(validStruct.grid).setRowModified(gx.fn.currentGridRow( validStruct.grid));
					}
					currentObject.refreshDependantGrids( validStruct);
				}
			}
		}
	}
};

gx.thread = {
	Map: function() {
		this.map = {};

		this.add = function( k, o)
		{
			this.map[k] = o;
		}
		
		this.remove = function( k)
		{
			delete this.map[k];
		}
		
		this.get = function( k)
		{
			return k==null ? null : this.map[k];
		}
		
		this.first = function()
		{
			return this.get( this.nextKey());
		}
		
		this.next = function( k)
		{
			return this.get( this.nextKey(k));
		}
		
		this.nextKey = function( k)
		{
			for (i in this.map)
			{
				if (!k)
				{
					return i;
				}
				if (k==i)
				{
					k=null;
				}
			}
			return null;
		}
	},
	
	Command: function(obj, func, args) {
		if (!gx.thread.Command.LastID)
		{
			gx.thread.Command.LastID = 0;
		}
		
		this.id = ++gx.thread.Command.LastID;

		this.execute = function()
		{
			func.apply(obj, args);
		}

		this.syncExecute = function()
		{
			new gx.thread.Mutex( this, 'execute');
		}
	},
	
	Mutex: function( obj, func, args, callback) {
		if (!gx.thread.Mutex.Wait)
		{
			gx.thread.Mutex.Wait = new gx.thread.Map();
		}
		
		gx.thread.Mutex.SLICE = function( cmdID, startID )
		{
			gx.thread.Mutex.Wait.get(cmdID).attempt( gx.thread.Mutex.Wait.get(startID));
		}
		
		this.attempt = function( start )
		{
			for (var j=start; j; j=gx.thread.Mutex.Wait.next(j.c.id))
			{
				if (j.enter || (j.number && (j.number < this.number || (j.number == this.number && j.c.id < this.c.id))))
					return setTimeout('gx.thread.Mutex.SLICE('+this.c.id+','+j.c.id+')',10);
			}
			try
			{
				retVal= this.c.execute();
			}
			catch(e)
			{
				gx.dbg.logEx(e, 'gxfrmutl.js', 'Mutex Call');
			}
			this.number = 0;
			gx.thread.Mutex.Wait.remove( this.c.id);
			if (typeof(callback) == 'function')
			{
				try
				{
					callback.call( obj, retVal);
				}
				catch(e)
				{
					gx.dbg.logEx(e, 'gxfrmutl.js', 'Mutex CallBack');
				}
			}
		}
		
		this.c = new gx.thread.Command(obj, func, args);
		gx.thread.Mutex.Wait.add( this.c.id, this);
		this.enter = true;
		this.number = (new Date()).getTime();
		this.enter = false;
		this.attempt( gx.thread.Mutex.Wait.first());
	}
};

gx.sec = {
	key: null,
	keyName: 'GX_AJAX_KEY',
	secToken: null,
	secTokenName: 'AJAX_SECURITY_TOKEN',
	
	loadKey: function() {
		var k = gx.fn.getHidden(this.keyName);
		if (gx.lang.emptyObject(k))
			this.key = null;
		else
			this.key = k;
		if (this.key != null)
		{
			this.loadSecToken();
		}
	},
	
	loadSecToken: function() {
		var t = gx.fn.getHidden(this.secTokenName);
		if (gx.lang.emptyObject(t))
			this.secToken = null;
		else
			this.secToken = t;
	},

	encrypt: function( Value, Key) {
		try
		{
			Key = (Key==null)?this.key:Key;
			if (Key != null)
			{
				var alg = this.rijndael;
				Key = alg.hexToByteArray(Key);
				var encrypted = alg.rijndaelEncrypt( Value, Key);
				var encoded = alg.byteArrayToHex(encrypted);
			 	return encoded;
			}
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'encrypt');
		}
		return Value;
	},

	decrypt: function( Value, Key) {
		try
		{
			Key = (Key==null)?this.key:Key;
			if (Key != null)
			{
				var alg = this.rijndael;
				Key = alg.hexToByteArray(Key);
				var decoded = alg.hexToByteArray(Value);
				var decrypted = alg.rijndaelDecrypt( decoded, Key);
			 	return alg.byteArrayToString(decrypted);
			}
		}
		catch(e)
		{
			gx.dbg.logEx(e, 'gxfrmutl.js', 'decrypt');
		}
		return Value;
	},
	
	_init: function() {
		this.rijndael._init();
	}
};

gx.base64 = {
	b64: [],
	f64: [],
	
	decode: function( encStr) {
		return this.bytesToString( this.bytesFromUTF8Bytes( this.decodeImpl(encStr)));
	},
	
	encode: function( decStr) {  
		return this.encodeImpl( this.UTF8BytesFromString(decStr));
	},

	bytesFromUTF8Bytes: function( Arr) {
		var outArr = [];
		var i = 0;
		var c = c1 = c2 = 0;
		var len = Arr.length;
		while ( i < len ) {
			c = Arr[i];
			if (c < 128) {
				outArr.push(c);
				i++;
			}
			else if((c > 191) && (c < 224)) {
				c2 = Arr[i+1];
				outArr.push(((c & 31) << 6) | (c2 & 63));
				i += 2;
			}
			else {
				c2 = Arr[i+1];
				c3 = Arr[i+2];
				outArr.push(((c & 15) << 12) | ((c2 & 63) << 6) | (c3 & 63));
				i += 3;
			}
		}
		return outArr;
	},
	
	UTF8BytesFromString: function( Str) {
		Str = Str.replace(/\r\n/g,"\n");
		
		var utf8Arr = [];
		var len = Str.length;
		for (var n = 0; n < len; n++)
		{
			var c = Str.charCodeAt(n);
			if (c < 128)
			{
				utf8Arr.push(c);
			}
			else if((c > 127) && (c < 2048))
			{
				utf8Arr.push((c >> 6) | 192);
				utf8Arr.push(((c & 63) | 128));
			}
			else
			{
				utf8Arr.push(((c >> 12) | 224));
				utf8Arr.push((((c >> 6) & 63) | 128));
				utf8Arr.push(((c & 63) | 128));
			}
		}
		return utf8Arr;
	},

	bytesToString: function( Arr) {
		var BUFFER_SIZE = 50000;
		var strOut = [];
		while(Arr.length >= BUFFER_SIZE)
		{
			strOut.push(eval("String.fromCharCode("+Arr.slice(0, BUFFER_SIZE).join(",")+");"));
			Arr = Arr.slice(BUFFER_SIZE);
		}
		if(Arr.length != 0)
		{
			strOut.push(eval("String.fromCharCode("+Arr.join(",")+");"));
		}
		return strOut.join("");
	},

	decodeImpl: function( t) {
		var f64 = this.f64;
		var d=[];
		var i=0;
		t=t.replace(/\n|\r/g,""); t=t.replace(/=/g,"");
		var len = t.length;
		while (i<len)
		{
			d[d.length] = (f64[t.charAt(i)]<<2) | (f64[t.charAt(i+1)]>>4);
			d[d.length] = (((f64[t.charAt(i+1)]&15)<<4) | (f64[t.charAt(i+2)]>>2));
			d[d.length] = (((f64[t.charAt(i+2)]&3)<<6) | (f64[t.charAt(i+3)]));
			i+=4;
		}
		if (t.length%4 == 2)
			d = d.slice(0, d.length-2);
		if (t.length%4 == 3)
			d = d.slice(0, d.length-1);
		return d;
	},
 
	encodeImpl: function( d) {
		var b64 = this.b64;
		var r=[];
		var i=0;
		var dl=d.length;
		if ((dl%3) == 1)
		{
			d[d.length] = 0;
			d[d.length] = 0;
		}
		if ((dl%3) == 2)
			d[d.length] = 0;
		var len = d.length;
		while (i<len)
		{
			r[r.length] = b64[d[i]>>2];
			r[r.length] = b64[((d[i]&3)<<4) | (d[i+1]>>4)];
			r[r.length] = b64[((d[i+1]&15)<<2) | (d[i+2]>>6)];
			r[r.length] = b64[d[i+2]&63];
			i+=3;
		}
		if ((dl%3) == 1)
			r[r.length-1] = r[r.length-2] = "=";
		if ((dl%3) == 2)
			r[r.length-1] = "=";
		var t=r.join("");
		return t;
	},
	
	_init: function() {
		var b64s='ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/';
		var len = b64s.length;
		for (var i=0; i<len;i++)
		{
			var c = b64s.charAt(i);
			this.b64[i] = c;
			this.f64[c] = i;
		}
	}
};
/* END OF FILE - gxfrmutl.js - */
/* START OF FILE - rijndael.js - */
/* rijndael.js      Rijndael Reference Implementation
   Copyright (c) 2001 Fritz Schneider
 
 This software is provided as-is, without express or implied warranty.  
 Permission to use, copy, modify, distribute or sell this software, with or
 without fee, for any purpose and by any individual or organization, is hereby
 granted, provided that the above copyright notice and this paragraph appear 
 in all copies. Distribution as a part of an application or binary must
 include the above copyright notice in the documentation and/or other materials
 provided with the application or distribution.


   As the above disclaimer notes, you are free to use this code however you
   want. However, I would request that you send me an email 
   (fritz /at/ cs /dot/ ucsd /dot/ edu) to say hi if you find this code useful
   or instructional. Seeing that people are using the code acts as 
   encouragement for me to continue development. If you *really* want to thank
   me you can buy the book I wrote with Thomas Powell, _JavaScript:
   _The_Complete_Reference_ :)

   This code is an UNOPTIMIZED REFERENCE implementation of Rijndael. 
   If there is sufficient interest I can write an optimized (word-based, 
   table-driven) version, although you might want to consider using a 
   compiled language if speed is critical to your application. As it stands,
   one run of the monte carlo test (10,000 encryptions) can take up to 
   several minutes, depending upon your processor. You shouldn't expect more
   than a few kilobytes per second in throughput.

   Also note that there is very little error checking in these functions. 
   Doing proper error checking is always a good idea, but the ideal 
   implementation (using the instanceof operator and exceptions) requires
   IE5+/NS6+, and I've chosen to implement this code so that it is compatible
   with IE4/NS4. 

   And finally, because JavaScript doesn't have an explicit byte/char data 
   type (although JavaScript 2.0 most likely will), when I refer to "byte" 
   in this code I generally mean "32 bit integer with value in the interval 
   [0,255]" which I treat as a byte.

   See http://www-cse.ucsd.edu/~fritz/rijndael.html for more documentation
   of the (very simple) API provided by this code.

                                               Fritz Schneider
                                               fritz at cs.ucsd.edu
 
*/

gx.sec.rijndael = {
	// Rijndael parameters --  Valid values are 128, 192, or 256
	
	keySizeInBits: 128,
	blockSizeInBits: 128,
	
	// The number of rounds for the cipher, indexed by [Nk][Nb]
	roundsArray: [ ,,,,[,,,,10,, 12,, 14],, 
	                   [,,,,12,, 12,, 14],, 
	                   [,,,,14,, 14,, 14] ],

	///////  You shouldn't have to modify anything below this line except for
	///////  the function getRandomBytes().
	//
	// Note: in the following code the two dimensional arrays are indexed as
	//       you would probably expect, as array[row][column]. The state arrays
	//       are 2d arrays of the form state[4][Nb].
	
	// The number of bytes to shift by in shiftRow, indexed by [Nb][row]
	shiftOffsets: [ ,,,,[,1, 2, 3],,[,1, 2, 3],,[,1, 3, 4] ],

	// The round constants used in subkey expansion
	Rcon: [ 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 
					0x40, 0x80, 0x1b, 0x36, 0x6c, 0xd8, 
					0xab, 0x4d, 0x9a, 0x2f, 0x5e, 0xbc, 
					0x63, 0xc6, 0x97, 0x35, 0x6a, 0xd4, 
					0xb3, 0x7d, 0xfa, 0xef, 0xc5, 0x91 ],

	// Precomputed lookup table for the SBox
	SBox: [ 99, 124, 119, 123, 242, 107, 111, 197,  48,   1, 103,  43, 254, 215, 171, 
				 118, 202, 130, 201, 125, 250,  89,  71, 240, 173, 212, 162, 175, 156, 164, 
				 114, 192, 183, 253, 147,  38,  54,  63, 247, 204,  52, 165, 229, 241, 113, 
				 216,  49,  21,   4, 199,  35, 195,  24, 150,   5, 154,   7,  18, 128, 226, 
				 235,  39, 178, 117,   9, 131,  44,  26,  27, 110,  90, 160,  82,  59, 214, 
				 179,  41, 227,  47, 132,  83, 209,   0, 237,  32, 252, 177,  91, 106, 203, 
				 190,  57,  74,  76,  88, 207, 208, 239, 170, 251,  67,  77,  51, 133,  69, 
				 249,   2, 127,  80,  60, 159, 168,  81, 163,  64, 143, 146, 157,  56, 245, 
				 188, 182, 218,  33,  16, 255, 243, 210, 205,  12,  19, 236,  95, 151,  68,  
				  23,  196, 167, 126,  61, 100,  93,  25, 115,  96, 129,  79, 220,  34,  42, 
				 144, 136,  70, 238, 184,  20, 222,  94,  11, 219, 224,  50,  58,  10,  73,
				   6,  36,  92, 194, 211, 172,  98, 145, 149, 228, 121, 231, 200,  55, 109, 
				 141, 213,  78, 169, 108,  86, 244, 234, 101, 122, 174,   8, 186, 120,  37,  
				  46,  28, 166, 180, 198, 232, 221, 116,  31,  75, 189, 139, 138, 112,  62, 
				 181, 102,  72,   3, 246,  14,  97,  53,  87, 185, 134, 193,  29, 158, 225,
				 248, 152,  17, 105, 217, 142, 148, 155,  30, 135, 233, 206,  85,  40, 223,
				 140, 161, 137,  13, 191, 230,  66, 104,  65, 153,  45,  15, 176,  84, 187,  
				  22 ],

	// Precomputed lookup table for the inverse SBox
	SBoxInverse: [ 82,   9, 106, 213,  48,  54, 165,  56, 191,  64, 163, 158, 129, 243, 215, 
								251, 124, 227,  57, 130, 155,  47, 255, 135,  52, 142,  67,  68, 196, 222, 
								233, 203,  84, 123, 148,  50, 166, 194,  35,  61, 238,  76, 149,  11,  66, 
								250, 195,  78,   8,  46, 161, 102,  40, 217,  36, 178, 118,  91, 162,  73, 
								109, 139, 209,  37, 114, 248, 246, 100, 134, 104, 152,  22, 212, 164,  92, 
								204,  93, 101, 182, 146, 108, 112,  72,  80, 253, 237, 185, 218,  94,  21,  
								 70,  87, 167, 141, 157, 132, 144, 216, 171,   0, 140, 188, 211,  10, 247, 
								228,  88,   5, 184, 179,  69,   6, 208,  44,  30, 143, 202,  63,  15,   2, 
								193, 175, 189,   3,   1,  19, 138, 107,  58, 145,  17,  65,  79, 103, 220, 
								234, 151, 242, 207, 206, 240, 180, 230, 115, 150, 172, 116,  34, 231, 173,
								 53, 133, 226, 249,  55, 232,  28, 117, 223, 110,  71, 241,  26, 113,  29, 
								 41, 197, 137, 111, 183,  98,  14, 170,  24, 190,  27, 252,  86,  62,  75, 
								198, 210, 121,  32, 154, 219, 192, 254, 120, 205,  90, 244,  31, 221, 168,
								 51, 136,   7, 199,  49, 177,  18,  16,  89,  39, 128, 236,  95,  96,  81,
								127, 169,  25, 181,  74,  13,  45, 229, 122, 159, 147, 201, 156, 239, 160,
								224,  59,  77, 174,  42, 245, 176, 200, 235, 187,  60, 131,  83, 153,  97, 
								 23,  43,   4, 126, 186, 119, 214,  38, 225, 105,  20,  99,  85,  33,  12,
								125 ],

	// This method circularly shifts the array left by the number of elements
	// given in its parameter. It returns the resulting array and is used for 
	// the ShiftRow step. Note that shift() and push() could be used for a more 
	// elegant solution, but they require IE5.5+, so I chose to do it manually. 
	
	cyclicShiftLeft: function(theArray, positions) {
	  var temp = theArray.slice(0, positions);
	  theArray = theArray.slice(positions).concat(temp);
	  return theArray;
	},

	// Multiplies the element "poly" of GF(2^8) by x. See the Rijndael spec.
	
	xtime: function(poly) {
	  poly <<= 1;
	  return ((poly & 0x100) ? (poly ^ 0x11B) : (poly));
	},

	// Multiplies the two elements of GF(2^8) together and returns the result.
	// See the Rijndael spec, but should be straightforward: for each power of
	// the indeterminant that has a 1 coefficient in x, add y times that power
	// to the result. x and y should be bytes representing elements of GF(2^8)
	
	mult_GF256: function(x, y) {
	  var bit, result = 0;
	  
	  for (bit = 1; bit < 256; bit *= 2, y = this.xtime(y)) {
	    if (x & bit) 
	      result ^= y;
	  }
	  return result;
	},

	// Performs the substitution step of the cipher. State is the 2d array of
	// state information (see spec) and direction is string indicating whether
	// we are performing the forward substitution ("encrypt") or inverse 
	// substitution (anything else)
	
	byteSub: function(state, direction) {
	  var S;
	  if (direction == "encrypt")           // Point S to the SBox we're using
	    S = this.SBox;
	  else
	    S = this.SBoxInverse;
	  for (var i = 0; i < 4; i++)           // Substitute for every byte in state
	    for (var j = 0; j < this.Nb; j++)
	       state[i][j] = S[state[i][j]];
	},

	// Performs the row shifting step of the cipher.
	
	shiftRow: function(state, direction) {
	  for (var i=1; i<4; i++)               // Row 0 never shifts
	    if (direction == "encrypt")
	       state[i] = this.cyclicShiftLeft(state[i], this.shiftOffsets[this.Nb][i]);
	    else
	       state[i] = this.cyclicShiftLeft(state[i], this.Nb - this.shiftOffsets[this.Nb][i]);
	},

	// Performs the column mixing step of the cipher. Most of these steps can
	// be combined into table lookups on 32bit values (at least for encryption)
	// to greatly increase the speed. 
	
	mixColumn: function(state, direction) {
	  var b = [];                            // Result of matrix multiplications
	  for (var j = 0; j < this.Nb; j++) {    // Go through each column...
	    for (var i = 0; i < 4; i++) {        // and for each row in the column...
	      if (direction == "encrypt")
	        b[i] = this.mult_GF256(state[i][j], 2) ^          // perform mixing
	               this.mult_GF256(state[(i+1)%4][j], 3) ^ 
	               state[(i+2)%4][j] ^ 
	               state[(i+3)%4][j];
	      else 
	        b[i] = this.mult_GF256(state[i][j], 0xE) ^ 
	               this.mult_GF256(state[(i+1)%4][j], 0xB) ^
	               this.mult_GF256(state[(i+2)%4][j], 0xD) ^
	               this.mult_GF256(state[(i+3)%4][j], 9);
	    }
	    for (var i = 0; i < 4; i++)          // Place result back into column
	      state[i][j] = b[i];
	  }
	},

	// Adds the current round key to the state information. Straightforward.
	
	addRoundKey: function(state, roundKey) {
	  for (var j = 0; j < this.Nb; j++) {            // Step through columns...
	    state[0][j] ^= (roundKey[j] & 0xFF);         // and XOR
	    state[1][j] ^= ((roundKey[j]>>8) & 0xFF);
	    state[2][j] ^= ((roundKey[j]>>16) & 0xFF);
	    state[3][j] ^= ((roundKey[j]>>24) & 0xFF);
	  }
	},

	// This function creates the expanded key from the input (128/192/256-bit)
	// key. The parameter key is an array of bytes holding the value of the key.
	// The returned value is an array whose elements are the 32-bit words that 
	// make up the expanded key.
	
	keyExpansion: function(key) {
	  var expandedKey = [];
	  var temp;
	
	  // in case the key size or parameters were changed...
	  this.Nk = this.keySizeInBits / 32;           
	  this.Nb = this.blockSizeInBits / 32;
	  this.Nr = this.roundsArray[this.Nk][this.Nb];
	
	  for (var j=0; j < this.Nk; j++)     // Fill in input key first
	    expandedKey[j] = 
	      (key[4*j]) | (key[4*j+1]<<8) | (key[4*j+2]<<16) | (key[4*j+3]<<24);
	
	  // Now walk down the rest of the array filling in expanded key bytes as
	  // per Rijndael's spec
	  for (j = this.Nk; j < this.Nb * (this.Nr + 1); j++) {    // For each word of expanded key
	    temp = expandedKey[j - 1];
	    if (j % this.Nk == 0) 
	      temp = ( (this.SBox[(temp>>8) & 0xFF]) |
	               (this.SBox[(temp>>16) & 0xFF]<<8) |
	               (this.SBox[(temp>>24) & 0xFF]<<16) |
	               (this.SBox[temp & 0xFF]<<24) ) ^ this.Rcon[Math.floor(j / this.Nk) - 1];
	    else if (this.Nk > 6 && j % this.Nk == 4)
	      temp = (this.SBox[(temp>>24) & 0xFF]<<24) |
	             (this.SBox[(temp>>16) & 0xFF]<<16) |
	             (this.SBox[(temp>>8) & 0xFF]<<8) |
	             (this.SBox[temp & 0xFF]);
	    expandedKey[j] = expandedKey[j-this.Nk] ^ temp;
	  }
	  return expandedKey;
	},

	// Rijndael's round functions... 
	
	Round: function(state, roundKey) {
	  this.byteSub(state, "encrypt");
	  this.shiftRow(state, "encrypt");
	  this.mixColumn(state, "encrypt");
	  this.addRoundKey(state, roundKey);
	},
	
	InverseRound: function(state, roundKey) {
	  this.addRoundKey(state, roundKey);
	  this.mixColumn(state, "decrypt");
	  this.shiftRow(state, "decrypt");
	  this.byteSub(state, "decrypt");
	},
	
	FinalRound: function(state, roundKey) {
	  this.byteSub(state, "encrypt");
	  this.shiftRow(state, "encrypt");
	  this.addRoundKey(state, roundKey);
	},
	
	InverseFinalRound: function(state, roundKey){
	  this.addRoundKey(state, roundKey);
	  this.shiftRow(state, "decrypt");
	  this.byteSub(state, "decrypt");  
	},

	// encrypt is the basic encryption function. It takes parameters
	// block, an array of bytes representing a plaintext block, and expandedKey,
	// an array of words representing the expanded key previously returned by
	// keyExpansion(). The ciphertext block is returned as an array of bytes.
	
	encrypt: function(block, expandedKey) {
	  var i;  
	  if (!block || block.length*8 != this.blockSizeInBits)
	     return; 
	  if (!expandedKey)
	     return;
	
	  block = this.packBytes(block);
	  this.addRoundKey(block, expandedKey);
	  for (i=1; i<this.Nr; i++) 
	    this.Round(block, expandedKey.slice(this.Nb*i, this.Nb*(i+1)));
	  this.FinalRound(block, expandedKey.slice(this.Nb*this.Nr)); 
	  return this.unpackBytes(block);
	},

	// decrypt is the basic decryption function. It takes parameters
	// block, an array of bytes representing a ciphertext block, and expandedKey,
	// an array of words representing the expanded key previously returned by
	// keyExpansion(). The decrypted block is returned as an array of bytes.
	
	decrypt: function(block, expandedKey) {
	  var i;
	  if (!block || block.length*8 != this.blockSizeInBits)
	     return;
	  if (!expandedKey)
	     return;
	
	  block = this.packBytes(block);
	  this.InverseFinalRound(block, expandedKey.slice(this.Nb*this.Nr)); 
	  for (i = this.Nr - 1; i>0; i--) 
	    this.InverseRound(block, expandedKey.slice(this.Nb*i, this.Nb*(i+1)));
	  this.addRoundKey(block, expandedKey);
	  return this.unpackBytes(block);
	},

	// This method takes a byte array (byteArray) and converts it to a string by
	// applying String.fromCharCode() to each value and concatenating the result.
	// The resulting string is returned. Note that this function SKIPS zero bytes
	// under the assumption that they are padding added in formatPlaintext().
	// Obviously, do not invoke this method on raw data that can contain zero
	// bytes. It is really only appropriate for printable ASCII/Latin-1 
	// values. Roll your own function for more robust functionality :)
	
	byteArrayToString: function(byteArray) {
	  var result = "";
	  var len = byteArray.length;
	  for(var i=0; i<len; i++)
	    if (byteArray[i] != 0) 
	      result += String.fromCharCode(byteArray[i]);
	  return result;
	},

	stringToByteArray: function( strText) {
		var result = [];
		var len = strText.length;
		for(var i=0; i<len; i++)
			result[result.length] = strText.charCodeAt();
		return result;
	},

	// This function takes an array of bytes (byteArray) and converts them
	// to a hexadecimal string. Array element 0 is found at the beginning of 
	// the resulting string, high nibble first. Consecutive elements follow
	// similarly, for example [16, 255] --> "10ff". The function returns a 
	// string.
	
	byteArrayToHex: function(byteArray) {
	  var result = "";
	  if (!byteArray)
	    return;
	  var len = byteArray.length;
	  for (var i=0; i<len; i++)
	    result += ((byteArray[i]<16) ? "0" : "") + byteArray[i].toString(16);
	
	  return result;
	},

	// This function converts a string containing hexadecimal digits to an 
	// array of bytes. The resulting byte array is filled in the order the
	// values occur in the string, for example "10FF" --> [16, 255]. This
	// function returns an array. 
	
	hexToByteArray: function(hexString) {
	  var byteArray = [];
	  if (hexString.length % 2)             // must have even length
	    return;
	  if (hexString.indexOf("0x") == 0 || hexString.indexOf("0X") == 0)
	    hexString = hexString.substring(2);
	  var len = hexString.length;
	  for (var i = 0; i<len; i += 2) 
	    byteArray[Math.floor(i/2)] = parseInt(hexString.slice(i, i+2), 16);
	  return byteArray;
	},

	// This function packs an array of bytes into the four row form defined by
	// Rijndael. It assumes the length of the array of bytes is divisible by
	// four. Bytes are filled in according to the Rijndael spec (starting with
	// column 0, row 0 to 3). This function returns a 2d array.
	
	packBytes: function(octets) {
	  var state = [];
	  if (!octets || octets.length % 4)
	    return;
	
	  state[0] = [];
	  state[1] = []; 
	  state[2] = [];
	  state[3] = [];
	  var len = octets.length;
	  for (var j=0; j<len; j+= 4) {
	     state[0][j/4] = octets[j];
	     state[1][j/4] = octets[j+1];
	     state[2][j/4] = octets[j+2];
	     state[3][j/4] = octets[j+3];
	  }
	  return state;  
	},

	// This function unpacks an array of bytes from the four row format preferred
	// by Rijndael into a single 1d array of bytes. It assumes the input "packed"
	// is a packed array. Bytes are filled in according to the Rijndael spec. 
	// This function returns a 1d array of bytes.
	
	unpackBytes: function(packed) {
	  var result = [];
	  var len = packed[0].length;
	  for (var j=0; j<len; j++) {
	    result[result.length] = packed[0][j];
	    result[result.length] = packed[1][j];
	    result[result.length] = packed[2][j];
	    result[result.length] = packed[3][j];
	  }
	  return result;
	},

	// This function takes a prospective plaintext (string or array of bytes)
	// and pads it with zero bytes if its length is not a multiple of the block 
	// size. If plaintext is a string, it is converted to an array of bytes
	// in the process. The type checking can be made much nicer using the 
	// instanceof operator, but this operator is not available until IE5.0 so I 
	// chose to use the heuristic below. 
	
	formatPlaintext: function(plaintext) {
	  var bpb = this.blockSizeInBits / 8;			// bytes per block
	  var i;
	
	  // if primitive string or String instance
	  if (typeof plaintext == "string" || plaintext.indexOf) {
	    plaintext = plaintext.split("");
	    // Unicode issues here (ignoring high byte)
	    var len = plaintext.length;
	    for (i=0; i<len; i++)
	      plaintext[i] = plaintext[i].charCodeAt(0) & 0xFF;
	  } 
	
	  for (i = bpb - (plaintext.length % bpb); i > 0 && i < bpb; i--) 
	    plaintext[plaintext.length] = 0;
	  
	  return plaintext;
	},

	// Returns an array containing "howMany" random bytes. YOU SHOULD CHANGE THIS
	// TO RETURN HIGHER QUALITY RANDOM BYTES IF YOU ARE USING THIS FOR A "REAL"
	// APPLICATION.
	
	getRandomBytes: function(howMany) {
	  var i;
	  var bytes = [];
	  for (i=0; i<howMany; i++)
	    bytes[i] = Math.round(Math.random()*255);
	  return bytes;
	},

	// rijndaelEncrypt(plaintext, key, mode)
	// Encrypts the plaintext using the given key and in the given mode. 
	// The parameter "plaintext" can either be a string or an array of bytes. 
	// The parameter "key" must be an array of key bytes. If you have a hex 
	// string representing the key, invoke hexToByteArray() on it to convert it 
	// to an array of bytes. The third parameter "mode" is a string indicating
	// the encryption mode to use, either "ECB" or "CBC". If the parameter is
	// omitted, ECB is assumed.
	// 
	// An array of bytes representing the cihpertext is returned. To convert 
	// this array to hex, invoke byteArrayToHex() on it. If you are using this 
	// "for real" it is a good idea to change the function getRandomBytes() to 
	// something that returns truly random bits.
	
	rijndaelEncrypt: function(plaintext, key, mode) {
	  var expandedKey, i, aBlock;
	  var bpb = this.blockSizeInBits / 8;     // bytes per block
	  var ct;                                 // ciphertext
	
	  if (!plaintext || !key)
	    return;
	  if (key.length*8 != this.keySizeInBits)
	    return; 
	  if (mode == "CBC")
	    ct = this.getRandomBytes(bpb);        // get IV
	  else {
	    mode = "ECB";
	    ct = [];
	  }
	
	  // convert plaintext to byte array and pad with zeros if necessary. 
	  plaintext = this.formatPlaintext(plaintext);
	
	  expandedKey = this.keyExpansion(key);
	  
	  for (var block=0; block<plaintext.length / bpb; block++) {
	    aBlock = plaintext.slice(block*bpb, (block+1)*bpb);
	    if (mode == "CBC")
	      for (var i=0; i<bpb; i++) 
	        aBlock[i] ^= ct[block*bpb + i];
	    ct = ct.concat(this.encrypt(aBlock, expandedKey));
	  }
	
	  return ct;
	},

	// rijndaelDecrypt(ciphertext, key, mode)
	// Decrypts the using the given key and mode. The parameter "ciphertext" 
	// must be an array of bytes. The parameter "key" must be an array of key 
	// bytes. If you have a hex string representing the ciphertext or key, 
	// invoke hexToByteArray() on it to convert it to an array of bytes. The
	// parameter "mode" is a string, either "CBC" or "ECB".
	// 
	// An array of bytes representing the plaintext is returned. To convert 
	// this array to a hex string, invoke byteArrayToHex() on it. To convert it 
	// to a string of characters, you can use byteArrayToString().
	
	rijndaelDecrypt: function(ciphertext, key, mode) {
	  var expandedKey;
	  var bpb = this.blockSizeInBits / 8;     // bytes per block
	  var pt = [];                   					// plaintext array
	  var aBlock;                             // a decrypted block
	  var block;                              // current block number
	
	  if (!ciphertext || !key || typeof ciphertext == "string")
	    return;
	  if (key.length*8 != this.keySizeInBits)
	    return; 
	  if (!mode)
	    mode = "ECB";                         // assume ECB if mode omitted
	
	  expandedKey = this.keyExpansion(key);
	 
	  // work backwards to accomodate CBC mode 
	  for (block=(ciphertext.length / bpb)-1; block>0; block--) {
	    aBlock = 
	     this.decrypt(ciphertext.slice(block*bpb,(block+1)*bpb), expandedKey);
	    if (mode == "CBC") 
	      for (var i=0; i<bpb; i++) 
	        pt[(block-1)*bpb + i] = aBlock[i] ^ ciphertext[(block-1)*bpb + i];
	    else 
	      pt = aBlock.concat(pt);
	  }
	
	  // do last block if ECB (skips the IV in CBC)
	  if (mode == "ECB")
	    pt = this.decrypt(ciphertext.slice(0, bpb), expandedKey).concat(pt);
	
	  return pt;
	},
	
	_init: function() {
		// Cipher parameters ... do not change these
		this.Nk = this.keySizeInBits / 32;
		this.Nb = this.blockSizeInBits / 32;
		this.Nr = this.roundsArray[this.Nk][this.Nb];
	}
};
/* END OF FILE - rijndael.js - */
/* START OF FILE - gxui.js - */
gx.ui = {
	grid: function() {
		this.gridContainer = null;
		this.firstTime = true;
		this.autoRefreshing = false;
		this.loadingCollection = false;
		this.properties = [];
		
		this.setContainerDelayed = function( container)
		{
			this.gridContainer = container;
			this.ContainerName = gx.dom.id( container);
			this.DesignContainerName = this.ContainerName;
		}
		
		this.getContainerControl = function()
		{
			return this.gridContainer;
		}
		
		this.me = function()
		{
			return this.gridObject() + '.grid';
		}
		
		this.render = function( firstTime, fromAutoRefresh, fromCollection)
		{
			this.clearFunctions();
			this.refreshDynProperties();
			this.properties = [];
			for (var i=0; i<this.rows.length; i++)
			{
				this.properties[i] = [];
				var row = this.rows[i];
				for (var j=0; j<this.columns.length; j++)
				{
					var column = this.columns[j];
					var columnProps = row.gxProps[column.index];
					var gxCtrl = column.gxControl;
					gxCtrl.grid = this.ownerGrid;
					gxCtrl.row = row;
					gxCtrl.gridId = this.gxId;
					gxCtrl.gridRow = row.gxId;
					if (!fromCollection)
						gxCtrl.setProperties.apply( gxCtrl, columnProps);
					else
						gxCtrl.value = columnProps[0];
					this.setRenderProperties( row.gxRenderProps[j], gxCtrl);
					if (!gxCtrl.enabled && gxCtrl.type <= gx.html.controls.types.checkBox)
					{
						if (gxCtrl.cssClass != '' && gxCtrl.cssClass.indexOf('Readonly') != 0)
							gxCtrl.cssClass = 'Readonly' + gxCtrl.cssClass;
					}
					this.properties[i][j] = gx.lang.clone(gxCtrl);
					this.addC2V( column, this.properties[i][j]);
				}
			}
			this.firstTime = firstTime;
			this.autoRefreshing = (fromAutoRefresh?true:false);
			this.loadingCollection = (fromCollection?true:false);
			if (this.show)
			{
				this.setC2ShowFunction( function(othis) { othis.show(); });
				if (this.autoRefreshing)
				{
					this.show();
				}
			}
			this.autoRefreshing = false;
		}
		
		this.addC2V = function( column, cellCtrl)
		{
			this.addC2VFunction(function(othis, oRow) {
				if (column.gxAttName != '')
				{
					var validStruct = othis.ParentObject.getValidStruct(column.gxId);
					if (validStruct)
					{
						othis.ParentObject[validStruct.gxvar] = cellCtrl.value;
					}
					gx.fn.setHidden(cellCtrl.id, cellCtrl.value);
				}
			});
		}
		
		this.setRenderProperties = function( props, gxCtrl)
		{
			if (props)
			{
				for (var prop in props)
				{
					gxCtrl[prop] = props[prop];
				}
			}
		}
		
		this.selectRow = function( index)
		{
			var row = this.rows[index];
			if (row)
			{
				this.instanciateSelectionVars(row.gxId);
				this.instanciateSelectedRow(row);
			}
		}
		
		this.getEventRow = function()
		{
			if (!gx.lang.emptyObject(this.GridRow))
			{
				return this.GridRow;
			}
			return '0001';
		}
		
		this.executeEvent = function( x, y)
		{
			if (x < this.columns.length && y < this.rows.length)
			{
				var gxCtrl = this.properties[y][x];
				var sEventJsCode = gx.html.controls.eventJSCode( gxCtrl.jsScrCode, gxCtrl.eventName, gxCtrl.jsDynCode, gxCtrl.grid, gxCtrl.row);
				if (sEventJsCode != '')
				{
					if (!gx.lang.emptyObject(gxCtrl.usrOnclick))
					{
						sEventJsCode = 'if(' + gxCtrl.usrOnclick + ') { ' + sEventJsCode + ' }';
					}
					var evtFnc = new Function(sEventJsCode);
					if (typeof(evtFnc) == 'function')
					{
						evtFnc();
					}
				}
			}
		}
	}
};
/* END OF FILE - gxui.js - */
/* START OF FILE - gxlast.js - */
gx._init();
/* END OF FILE - gxlast.js - */
