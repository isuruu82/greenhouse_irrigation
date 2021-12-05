jQuery.sap.require("sap.ui.qunit.qunit-css");
jQuery.sap.require("sap.ui.thirdparty.qunit");
jQuery.sap.require("sap.ui.qunit.qunit-junit");
QUnit.config.autostart = false;

// We cannot provide stable mock data out of the template.
// If you introduce mock data, by adding .json files in your webapp/localService/mockdata folder you have to provide the following minimum data:
// * At least 3 PL_LINE in the list

sap.ui.require([
	"sap/ui/test/Opa5",
	"ZGH/test/integration/pages/Common",
	"sap/ui/test/opaQunit",
	"ZGH/test/integration/pages/App",
	"ZGH/test/integration/pages/Browser",
	"ZGH/test/integration/pages/Master",
	"ZGH/test/integration/pages/Detail",
	"ZGH/test/integration/pages/Create",
	"ZGH/test/integration/pages/NotFound"
], function(Opa5, Common) {
	"use strict";
	Opa5.extendConfig({
		arrangements: new Common(),
		viewNamespace: "ZGH.view."
	});

	sap.ui.require([
		"ZGH/test/integration/MasterJourney",
		"ZGH/test/integration/NavigationJourney",
		"ZGH/test/integration/NotFoundJourney",
		"ZGH/test/integration/BusyJourney",
		"ZGH/test/integration/FLPIntegrationJourney"
	], function() {
		QUnit.start();
	});
});