sap.ui.define([
	"ZGH/model/GroupSortState",
	"sap/ui/model/json/JSONModel",
	"sap/ui/thirdparty/sinon",
	"sap/ui/thirdparty/sinon-qunit"
], function(GroupSortState, JSONModel) {
	"use strict";

	QUnit.module("GroupSortState - grouping and sorting", {
		beforeEach: function() {
			this.oModel = new JSONModel({});
			// System under test
			this.oGroupSortState = new GroupSortState(this.oModel, function() {});
		}
	});

	QUnit.test("Should always return a sorter when sorting", function(assert) {
		// Act + Assert
		assert.strictEqual(this.oGroupSortState.sort("WTR_LVL").length, 1, "The sorting by WTR_LVL returned a sorter");
		assert.strictEqual(this.oGroupSortState.sort("LINE_DESCRIPTION").length, 1, "The sorting by LINE_DESCRIPTION returned a sorter");
	});

	QUnit.test("Should return a grouper when grouping", function(assert) {
		// Act + Assert
		assert.strictEqual(this.oGroupSortState.group("WTR_LVL").length, 1, "The group by WTR_LVL returned a sorter");
		assert.strictEqual(this.oGroupSortState.group("None").length, 0, "The sorting by None returned no sorter");
	});

	QUnit.test("Should set the sorting to WTR_LVL if the user groupes by WTR_LVL", function(assert) {
		// Act + Assert
		this.oGroupSortState.group("WTR_LVL");
		assert.strictEqual(this.oModel.getProperty("/sortBy"), "WTR_LVL", "The sorting is the same as the grouping");
	});

	QUnit.test("Should set the grouping to None if the user sorts by LINE_DESCRIPTION and there was a grouping before", function(assert) {
		// Arrange
		this.oModel.setProperty("/groupBy", "WTR_LVL");

		this.oGroupSortState.sort("LINE_DESCRIPTION");

		// Assert
		assert.strictEqual(this.oModel.getProperty("/groupBy"), "None", "The grouping got reset");
	});
});