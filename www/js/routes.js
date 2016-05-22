angular.module('app.routes', [])

.config(function($stateProvider, $urlRouterProvider) {

  // Ionic uses AngularUI Router which uses the concept of states
  // Learn more here: https://github.com/angular-ui/ui-router
  // Set up the various states which the app can be in.
  // Each state's controller can be found in controllers.js
  $stateProvider

.state('landing', {
    url: '/landing',
    templateUrl: 'templates/landing.html',
    controller: 'landingCtrl'
  })

  .state('home', {
    url: '/home',
    templateUrl: 'templates/home.html',
    controller: 'homeCtrl'
  })

  .state('signUp', {
    url: '/signUp',
    templateUrl: 'templates/signUp.html',
    controller: 'signUpCtrl'
  })

  .state('login', {
    url: '/login',
    templateUrl: 'templates/login.html',
    controller: 'loginCtrl'
  })

  .state('menu', {
    url: '/page4',
    templateUrl: 'templates/menu.html',
    controller: 'menuCtrl'
  })

  .state('lostFound', {
    url: '/page5',
    templateUrl: 'templates/lostFound.html',
    controller: 'lostFoundCtrl'
  })

  .state('requestsTenant', {
    url: '/page19',
    templateUrl: 'templates/requestsTenant.html',
    controller: 'requestsTenantCtrl'
  })

  .state('requestsLandlord', {
    url: '/page13',
    templateUrl: 'templates/requestsLandlord.html',
    controller: 'requestsLandlordCtrl'
  })

  .state('answerARequestsLandlord', {
    url: '/page21',
    templateUrl: 'templates/answerARequestsLandlord.html',
    controller: 'answerARequestsLandlordCtrl'
  })

  .state('makeRequestTenant', {
    url: '/page20',
    templateUrl: 'templates/makeRequestTenant.html',
    controller: 'makeRequestTenantCtrl'
  })

  .state('lost', {
    url: '/page11',
    templateUrl: 'templates/lost.html',
    controller: 'lostCtrl'
  })

  .state('found', {
    url: '/page14',
    templateUrl: 'templates/found.html',
    controller: 'foundCtrl'
  })

  .state('notices', {
    url: '/page17',
    templateUrl: 'templates/notices.html',
    controller: 'noticesCtrl'
  })

  .state('events', {
    url: '/page36',
    templateUrl: 'templates/events.html',
    controller: 'eventsCtrl'
  })

  .state('postANotice', {
    url: '/page29',
    templateUrl: 'templates/postANotice.html',
    controller: 'postANoticeCtrl'
  })

  .state('hostAnEvent', {
    url: '/page37',
    templateUrl: 'templates/hostAnEvent.html',
    controller: 'hostAnEventCtrl'
  })

  .state('newTopic', {
    url: '/page38',
    templateUrl: 'templates/newTopic.html',
    controller: 'newTopicCtrl'
  })

  .state('notices2', {
    url: '/page18',
    templateUrl: 'templates/notices2.html',
    controller: 'notices2Ctrl'
  })

  .state('profile', {
    url: '/profile',
    templateUrl: 'templates/profile.html',
    controller: 'profileCtrl'
  })

  .state('addItem', {
    url: '/page9',
    templateUrl: 'templates/addItem.html',
    controller: 'addItemCtrl'
  })

  .state('popUp', {
    url: '/page12',
    templateUrl: 'templates/popUp.html',
    controller: 'popUpCtrl'
  })

  .state('paymentConfirmation', {
    url: '/page35',
    templateUrl: 'templates/paymentConfirmation.html',
    controller: 'paymentConfirmationCtrl'
  })

  .state('social', {
    url: '/page15',
    templateUrl: 'templates/social.html',
    controller: 'socialCtrl'
  })

  .state('chat', {
    url: '/page23',
    templateUrl: 'templates/chat.html',
    controller: 'chatCtrl'
  })

  .state('groups', {
    url: '/page41',
    templateUrl: 'templates/groups.html',
    controller: 'groupsCtrl'
  })

  .state('groupDetails', {
    url: '/page42',
    templateUrl: 'templates/groupDetails.html',
    controller: 'groupDetailsCtrl'
  })

  .state('payment', {
    url: '/page24',
    templateUrl: 'templates/payment.html',
    controller: 'paymentCtrl'
  })

  .state('proposalsIssues', {
    url: '/page25',
    templateUrl: 'templates/proposalsIssues.html',
    controller: 'proposalsIssuesCtrl'
  })

  .state('proposalsIssueDetails', {
    url: '/page40',
    templateUrl: 'templates/proposalsIssueDetails.html',
    controller: 'proposalsIssueDetailsCtrl'
  })

  .state('proposalsPolls', {
    url: '/page39',
    templateUrl: 'templates/proposalsPolls.html',
    controller: 'proposalsPollsCtrl'
  })

  .state('bookings', {
    url: '/page26',
    templateUrl: 'templates/bookings.html',
    controller: 'bookingsCtrl'
  })

  .state('bookingDetails', {
    url: '/page27',
    templateUrl: 'templates/bookingDetails.html',
    controller: 'bookingDetailsCtrl'
  })

  .state('bookingConfirmation', {
    url: '/page28',
    templateUrl: 'templates/bookingConfirmation.html',
    controller: 'bookingConfirmationCtrl'
  })

  .state('settings', {
    url: '/page10',
    templateUrl: 'templates/settings.html',
    controller: 'settingsCtrl'
  })

  .state('settings2', {
    url: '/page22',
    templateUrl: 'templates/settings2.html',
    controller: 'settings2Ctrl'
  })

  .state('settings3', {
    url: '/page30',
    templateUrl: 'templates/settings3.html',
    controller: 'settings3Ctrl'
  })

  .state('addABuilding', {
    url: '/page34',
    templateUrl: 'templates/addABuilding.html',
    controller: 'addABuildingCtrl'
  })

  .state('paymentHistory', {
    url: '/page31',
    templateUrl: 'templates/paymentHistory.html',
    controller: 'paymentHistoryCtrl'
  })

  .state('paymentFullHistory', {
    url: '/page32',
    templateUrl: 'templates/paymentFullHistory.html',
    controller: 'paymentFullHistoryCtrl'
  })

  .state('paymentDetails', {
    url: '/page33',
    templateUrl: 'templates/paymentDetails.html',
    controller: 'paymentDetailsCtrl'
  })

$urlRouterProvider.otherwise('/landing')

});
