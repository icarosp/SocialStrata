angular.module('app.services', ['ngResource'])

.factory('db', function ($resource) {
  return $resource = {
    _add: function(obj) {
      localStorage.setItem('SocialStrata', JSON.stringify(obj));
    },

    _get: function() {
      return JSON.parse(localStorage.getItem('SocialStrata'));
    }
  }
});
