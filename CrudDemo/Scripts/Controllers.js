angular.module("CrudDemoApp.controllers", []).
controller("MainController", function ($scope,PlayerService) {
    $scope.message = "Main Controller";

    PlayerService.GetPlayersFromDB().then(function (response) {

        $scope.listPlayers = response.data.list;
    });

    $scope.DeletePlayer = function (id,index) {

        $scope.listPlayers.splice(index, 1);

        PlayerService.DeletePlayer(id);
    }

})
  .controller("AddPlayerController", function ($scope, PlayerService) {
      $scope.message = "Add player details";

      $scope.AddPlayer = function () {
         
          PlayerService.AddPlayer($scope.player);
      }

    })
  .controller("EditPlayerController", function ($scope,PlayerService,$routeParams) {
      $scope.message = "Update Player Details";

      PlayerService.GetPlayersByID($routeParams.id).then(function (response) {
          $scope.player = response.data.player;
      })

      $scope.UpdatePlayer = function () {

          PlayerService.UpdatePlayer($scope.player);
      }

    })
  .factory("PlayerService", ["$http", function ($http) {
    var fac = {};

    fac.GetPlayersFromDB = function () {

         return $http.get("/Player/GetPlayers");
    }

    fac.GetPlayersByID = function (id) {

        return $http.get("/Player/GetPlayerById", { params: { id:id }});
    }

    fac.AddPlayer = function (Player) {

        $http.post("/Player/AddPlayer", Player).then(function(response){
            alert(response.data.update);
        })      
    }

    fac.UpdatePlayer = function (Player) {

        $http.post("/Player/UpdatePlayer", Player).then(function (response) {
            alert(response.data.update);
        })
    }

    fac.DeletePlayer = function (id) {

        $http.post("/Player/DeletePlayer", {id:id}).then(function (response) {
            alert(response.data.update);
        })
    }


    return fac;

}])