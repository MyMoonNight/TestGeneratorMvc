﻿/// <reference path="../_references.js" />

adminApplication.controller('TestController', ['$scope', 'webApiFactory', 'Notification', function ($scope, webApiFactory, Notification) {
    $scope.getTestsWithOwner = function () {
        webApiFactory.getTestsWithOwner(function (data) {
            $scope.tests = data
        });
    };

    $scope.getTestsCount = function () {
        webApiFactory.getTestsCount(function (data) {
            $scope.testsCount = data;
        });
    };

    $scope.getQuestionsForTest = function (index) {
        var test = $scope.tests[index];
        if (!test.questions) {
            webApiFactory.getQuestionsForTest(test.Id, function (data) {
                test.questions = data;
            });
        }
    };

    $scope.getTestsWithOwner();
    $scope.getTestsCount();
}]);
