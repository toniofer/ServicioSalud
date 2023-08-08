window.dhtmlHistory.create({
	debugMode: false,
	toJSON: function(o) {
		return JSON.stringify(o);
	},
	fromJSON: function(s) {
		return JSON.parse(s);
	},
	blankPagePath: gx.util.resourceUrl(gx.basePath + gx.staticDirectory + "HistoryManager/rsh/", true)
});
