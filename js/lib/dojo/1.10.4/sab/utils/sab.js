define([
	 // requirements
	 "dojo/_base/declare"
], function (declare) {
	// no slash separator, use dot with declare, 
	// use a reference and return on last line
	var sabUtil = declare(
	/// declaredClass: string, moduleUrl with dot-separater + filename /.js//
			"sab.utils.sab",
	/// base class: Array(mixins)
			[],
	/// class scope
			{
				_methodMeantToBePrivate: function() { },
				randomInstanceMethod: function() { }
			}
	); // end declare


	// set any aliases, which you want to expose (statics)
	sabUtil.xmlEncode = function(data)
	{
		return data
		.replace(/&/g, "&amp;")
		.replace(/</g, "&lt;")
		.replace(/>/g, "&gt;")
		.replace(/"/g, "&quot;");
	}

	sabUtil.serializeXml = function (obj) 
	{
		
		// careful with your scope access inhere
		var xml = "<T>";
		for (var key in obj) {
			xml = xml + "<R><K>" + key + "</K><V>" +  sabUtil.xmlEncode(obj[key]) + "</V></R>";
		}
		xml = xml + "</T>";
		return xml;
	}

	// return the declared class to 'define'
	return sabUtil;
}); // end define