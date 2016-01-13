'use strict';

app.controller('DataController', ['$scope', 'backendHubProxy',
  function ($scope, backendHubProxy) {
      console.log('trying to connect to service')
      var dataHub = backendHubProxy(backendHubProxy.defaultServer, 'dataHub');
      console.log('connected to service')
      $scope.realtimeArea = [{ label: 'Layer 1', values: [] }];

      dataHub.on('broadcastData', function (data) {
          var chartEntry = [];

          console.log('received data');

          chartEntry.push({ time: data.timestamp, y: data.value });

          $scope.realtimeAreaFeed = chartEntry;
      });
      $scope.areaAxes = ['left', 'right', 'bottom'];
  }
]);