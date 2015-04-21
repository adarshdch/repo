define([
	"dojo/_base/declare", // declare
	"dojo/dom-attr", // domAttr.set
	"dojo/_base/kernel", // kernel.deprecated
	"dojo/sniff", // has("ie")
	//"../../dijit/_Widget",
	//"../../dijit/_TemplatedMixin",
	//"../../dijit/form/_FormMixin",
	"../../dijit/form/Form"
	//"../../dijit/layout/_ContentPaneResizeMixin"
], function (declare, domAttr, kernel, has, Form) {

	// module:
	//		sab/form/Form


	return declare("sab.form.Form", [Form], {
		// summary:	Widget corresponding to HTML form tag, for validation and serialization

		onReset: function (/*Event?*/ /*===== e =====*/) {
			// summary:
			//		Callback when user resets the form. This method is intended
			//		to be over-ridden. When the `reset` method is called
			//		programmatically, the return value from `onReset` is used
			//		to compute whether or not resetting should proceed
			// tags:
			//		callback
			return confirm('Press OK to reset values');
		},

		_onReset: function (e) {
			this.reset(e);
			e.stopPropagation();
			e.preventDefault();
			return false;
		},

		_onSubmit: function (e) {
			
			var fp = this.constructor.prototype;
			// TODO: remove this if statement beginning with 2.0
			if (this.execute != fp.execute || this.onExecute != fp.onExecute) {
				kernel.deprecated("dijit.form.Form:execute()/onExecute() are deprecated. Use onSubmit() instead.", "", "2.0");
				this.onExecute();
				this.execute(this.getValues());
			}
			if (this.onSubmit(e) === false) { // only exactly false stops submit
				e.stopPropagation();
				e.preventDefault();
			}
		},

		onSubmit: function (e/*Event?*/ /*===== e =====*/) {
			
			return true;
			// summary:
			//		Callback when user submits the form.
			// description:
			//		This method is intended to be over-ridden, but by default it checks and
			//		returns the validity of form elements. When the `submit`
			//		method is called programmatically, the return value from
			//		`onSubmit` is used to compute whether or not submission
			//		should proceed
			// tags:
			//		extension

			return this.isValid(); // Boolean
		},

		submit: function (t) {
			// summary:
			//		programmatically submit form if and only if the `onSubmit` returns true

			var formValues = this.getValues();
			formValues._PageCode = this.sid;
			formValues._Steps = "Update";

			require(["dojo/request"], function (request) {
				request("ttt", {
					data: formValues,
					method: "post",
					handleAs: "json"
				}).then(function (data) {
					if (data.Status == 'Success')
						alert(data.Message);
					else
						alert("Please try again");
				}, function (err) {
					alert("Error while posting data");
				}, function (evt) {
					// handle a progress event
				});
			});


			return false;

			if (!(this.onSubmit() === false)) {
				this.containerNode.submit();
			}
		}
	});
});
