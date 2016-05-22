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
      $state.go('signIn', {}, {cache: false });
  }


})

.controller('homeCtrl', function($scope, $state) {
})

.controller('signInCtrl', function($scope, $state, $http) {
  $scope.joinFacebook = function(){
      window.location = "https://m.facebook.com/v2.6/dialog/oauth?redirect_uri=https%3A%2F%2Fsocialstrata.azurewebsites.net%2Fsignin-facebook&state=IFEUFjAkVan4yj1ynwM-SoBOV4QIwE54Vtd5Ts5nYg0IL4YPhb-9AabgtzoFwttHmxVqQrBpAtvPl8KrNxWkqetGXovwJWvFdBEmYb6YYCfpAa8YYa7FFcVbjnm9VV_mz-HI0xSzGy-3RzyKpQUqj-tV3DBYZAT_V6e2HdrOjw4Dgtua0TZl4uqYftRHHNG9ryl6UK4kQqElOBGkXNjUqfcwDdEPp-yNuIrmgLCI1JA&scope&response_type=code&client_id=467010280174696";
  }

  $scope.registration = function(form){
    $http({
      method: 'POST',
      url: 'https://socialstrata.azurewebsites.net/account/register',
      data: {
        Email: form.Password,
        Password: form.Password,
        ConfirmPassword: form.ConfirmPassword
      }
    }).then(function(response){
      console.log(response.data);
    }, function(error){
        console.log();
    });
  }
})

.controller('loginCtrl', function($scope, $state) {
  $scope.goHome = function(){
      $state.go('home', {}, {cache: false });
  }

  $scope.goRegister = function(){
      $state.go('home', {}, {cache: false });
  }
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

.controller('noticesCtrl', function($scope) {

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

.controller('registrationCtrl', function($scope) {

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
