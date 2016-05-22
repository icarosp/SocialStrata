angular.module('app.controllers', [])

.controller('landingCtrl', function($scope, $state) {
  $scope.goLogin = function(){
      $state.go('login', {}, {cache: false });
  }

  $scope.goSignUp = function(){
      $state.go('signIn', {}, {cache: false });
  }
})

.controller('homeCtrl', function($scope, $state) {
})

.controller('signInCtrl', function($scope, $state) {

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
