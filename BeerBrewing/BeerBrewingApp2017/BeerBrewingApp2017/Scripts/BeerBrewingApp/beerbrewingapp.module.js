/* main: startup script creates the 'beerangular' module and adds custom Ng directives */

// 'beerangular' is the one Angular (Ng) module in this app
// 'beerangular' module is in global namespace
window.beerangular = angular.module('beerangular', ['ngRoute', 'ngCookies', 'highcharts-ng']);



beerangular.service('beerbrewingapp', ['$http', function ($http) {

    var currentRecipeId;
    var currentRecipe;

    var setCurrentRecipeId = function (recipeId) {
        currentRecipeId = recipeId;
    };
    var getRecipe = function (recpieId) {
        currentParticipantId = participantId;
        return $http.get("/api/recipe/getrecipe/" + recipeId)
            .then(function (response) {
                currentRecipe = response.data;
                return response.data;
            });
    };

    return {
        getRecipe: getRecipe
    };
}]);




// Configure routes  CheckInPlanCtrl
beerangular.config(function ($routeProvider) {
    $routeProvider.
        when('/', { templateUrl: '/Scripts/BeerBrewingApp/beerrecipes.view.html', controller: 'BeerRecipesCtrl' }).
        when('/about', { templateUrl: '/Scripts/FairApp/about.view.html', controller: 'AboutCtrl' }).
        otherwise({ redirectTo: '/' });
});

beerangular.filter('setDecimal', function ($filter) {
    return function (input, places) {
        if (isNaN(input)) return input;
        // If we want 1 decimal place, we want to mult/div by 10
        // If we want 2 decimal places, we want to mult/div by 100, etc
        // So use the following to create that factor
        var factor = "1" + Array(+(places > 0 && places + 1)).join("0");
        return Math.round(input * factor) / factor;
    };
});

beerangular.factory("HttpErrorInterceptorModule", ["$q", "$rootScope", "$location", "$window",
    function ($q, $rootScope, $location, $window) {
        var success = function (response) {
            // pass through
            return response;
        },
            error = function (response) {
                if (response.status === 401) {
                    // dostuff
                    $window.location.href = "https://localhost/BeerBrewingApp2017";
                    //$location.path('/').replace();
                    //$rootScope.$apply();
                }

                return $q.reject(response);
            };

        return function (httpPromise) {
            return httpPromise.then(success, error);
        };
    }
]).config(["$httpProvider",
    function ($httpProvider) {
        $httpProvider.interceptors.push("HttpErrorInterceptorModule");
    }
]);