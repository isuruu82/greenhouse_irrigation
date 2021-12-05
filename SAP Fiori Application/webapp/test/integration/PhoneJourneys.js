jQuery.sap.require("sap.ui.qunit.qunit-css");
jQuery.sap.require("sap.ui.thirdparty.qunit");
jQuery.sap.require("sap.ui.qunit.qunit-junit");
QUnit.config.autostart = false;

sap.ui.require([
	"sap/ui/test/Opa5",
	"ZGH/test/integration/pages/Common",
	"sap/ui/test/opaQunit",
	"ZGH/test/integration/pages/App",
	"ZGH/test/integration/pages/Browser",
	"ZGH/test/integration/pages/Master",
	"ZGH/test/integration/pages/Detail",
	"ZGH/test/integration/pages/NotFound"
], function(Opa5, Common) {
	"use strict";
	Opa5.extendConfig({
		arrangements: new Common(),
		viewNamespace: "ZGH.view."
	});

	sap.ui.require([
		"ZGH/test/integration/NavigationJourneyPhone",
		"ZGH/test/integration/NotFoundJourneyPhone",
		"ZGH/test/integration/BusyJourneyPhone"
	], function() {
		QUnit.start();
	});
});