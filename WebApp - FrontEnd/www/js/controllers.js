angular.module('app.controllers', [])

.controller('landingCtrl', function($scope, $state,$http) {

  $http.get('https://socialstrata.azurewebsites.net/api/notices/getallnotices').then(function(response){
    console.log(response.data);
    $scope.notices = response.data[0];
  }, function(error){
      console.log();
  });

  $scope.goLogin = function(){
      $state.go('login', {}, {cache: false });
  }
  $scope.goSignUp = function(){
      $state.go('signUp', {}, {cache: false });
  }
})

.controller('homeCtrl', function($scope, $state,$http) {

  $scope.goMenu = function(){
      $state.go('menu', {}, {cache: false });
  }





  $http.get('https://socialstrata.azurewebsites.net/api/notices/getallnotices').then(function(response){
    //var allNotices  = response.data;

    var topNotices = [];

    for (var i = 0; i < 2; i++) {
        topNotices.push({
            Description: response.data[i].Description,
            Title: response.data[i].Title
        });
    };

    $scope.notices = topNotices;
  }, function(error){
      console.log();
  });
})

.controller('signUpCtrl', function($scope, $state, $http, $ionicPopup) {
  $scope.joinFacebook = function(){
    var alertPopup = $ionicPopup.alert({
      title: 'Error',
      template: 'Not implemented yet'
    });
  }

  $scope.registration = function(form){
    $http({
      method: 'POST',
      url: 'https://socialstrata.azurewebsites.net/account/register',
      data: {
        Email: form.Email,
        Password: form.Password,
        ConfirmPassword: form.ConfirmPassword
      }
    }).then(function(response){
      if(response.data.Success){
        $state.go('home', {}, {cache: false });
      }
      else{
        console.log(response.data);
        var alertPopup = $ionicPopup.alert({
          title: 'Error',
          template: response.data.Messages
        });
      }
    }, function(error){
        console.log();
    });
  }
})

.controller('loginCtrl', function($scope, $state,$ionicPopup, $http, db) {

  $scope.goFacebook = function(){
    var alertPopup = $ionicPopup.alert({
      title: 'Error',
      template: 'Not implemented yet!'
    });
  }

  $scope.login = function(form){

    console.log(form);

    $http({
      method: 'POST',
      url: 'https://socialstrata.azurewebsites.net/account/login',
      data: {
        Email: form.user,
        Password: form.password,
      }
    }).then(function(response){
      if(response.data.Success){

        //console.log(response.data.UserId);
        db._add(response.data);

        $state.go('home', {}, {cache: false });
      }
      else{
        console.log(response.data);
        var alertPopup = $ionicPopup.alert({
          title: 'Error',
          template: response.data.Messages
        });
      }
    }, function(error){
        console.log(error);
    });
  }

  $scope.goRegister = function(){
      $state.go('signUp', {}, {cache: false });
  }
})

.controller('profileCtrl', function($scope,$state,$http,db) {
  $http({
    method: 'GET',
    url: 'https://socialstrata.azurewebsites.net/api/People/GetProfile/'+db._get().UserId,
  }).then(function(response){
    console.log(response.data);
  }, function(error){
      console.log();
  });

  $scope.updateProfile = function(){
      $state.go('home', {}, {cache: false });
  };

})

.controller('menuCtrl', function($scope) {

})

.controller('lostFoundCtrl', function($scope) {

})

.controller('requestsTenantCtrl', function($scope) {

})

.controller('requestsLandlordCtrl', function($scope) {

})

.controller('answerARequestsLandlordCtrl', function($scope) {

})

.controller('makeRequestTenantCtrl', function($scope) {

})

.controller('lostCtrl', function($scope) {

})

.controller('foundCtrl', function($scope) {

})

.controller('noticesCtrl', function($scope,$http) {
  $http.get('https://socialstrata.azurewebsites.net/api/notices/getallnotices').then(function(response){
    console.log(response.data);
    $scope.notices = response.data;
  }, function(error){
      console.log();
  });
})

.controller('eventsCtrl', function($scope) {

})

.controller('postANoticeCtrl', function($scope) {

})

.controller('hostAnEventCtrl', function($scope) {

})

.controller('newTopicCtrl', function($scope) {

})

.controller('notices2Ctrl', function($scope) {

})

.controller('addItemCtrl', function($scope) {

})

.controller('popUpCtrl', function($scope) {

})

.controller('paymentConfirmationCtrl', function($scope) {

})

.controller('socialCtrl', function($scope) {

})

.controller('chatCtrl', function($scope) {

})

.controller('groupsCtrl', function($scope) {

})

.controller('groupDetailsCtrl', function($scope) {

})

.controller('paymentCtrl', function($scope) {

})

.controller('proposalsIssuesCtrl', function($scope) {

})

.controller('proposalsIssueDetailsCtrl', function($scope) {

})

.controller('proposalsPollsCtrl', function($scope) {

})

.controller('bookingsCtrl', function($scope) {

})

.controller('bookingDetailsCtrl', function($scope) {

})

.controller('bookingConfirmationCtrl', function($scope) {

})

.controller('settingsCtrl', function($scope) {

})

.controller('settings2Ctrl', function($scope) {

})

.controller('settings3Ctrl', function($scope) {

})

.controller('addABuildingCtrl', function($scope) {

})

.controller('paymentHistoryCtrl', function($scope) {

})

.controller('paymentFullHistoryCtrl', function($scope) {

})

.controller('paymentDetailsCtrl', function($scope) {

})
