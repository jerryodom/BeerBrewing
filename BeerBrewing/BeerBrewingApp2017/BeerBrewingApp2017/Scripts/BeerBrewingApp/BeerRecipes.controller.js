beerangular.controller('BeerRecipesCtrl',
   ['$scope', '$cookies', 'beerservice', '$location', '$window', '$interval',
   function ($scope, $cookies, beerservice, $location, $window, $interval) {

       var onRecipeComplete = function (data) {
           $scope.participant = data;
       };

       var onRecipeError = function (reason) {
           $scope.error = reason;
           $window.location.href = "/Account/Login?returnurl=/Home/About";
       };

       beerservice.getRecipe(1).then(onRecipeComplete, onRecipeError);

   }]);