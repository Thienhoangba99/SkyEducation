
/**
* Theme: Xadmino
* Morris Chart
*/

!function($) {
    "use strict";

    var MorrisCharts = function() {};

    //creates line chart
    MorrisCharts.prototype.createLineChart = function(element, data, xkey, ykeys, labels, lineColors) {
        Morris.Line({
          element: element,
          data: data,
          xkey: xkey,
          ykeys: ykeys,
          labels: labels,
          gridLineColor: '#eef0f2',
          resize: true, //defaulted to true
          lineColors: lineColors
        });
    },
    //creates area chart
    MorrisCharts.prototype.createAreaChart = function(element, pointSize, lineWidth, data, xkey, ykeys, labels, lineColors) {
        Morris.Area({
            element: element,
            pointSize: 3,
            lineWidth: 0,
            data: data,
            xkey: xkey,
            ykeys: ykeys,
            labels: labels,
            resize: true,
            gridLineColor: '#eef0f2',
            lineColors: lineColors
        });
    },
    //creates Bar chart
    MorrisCharts.prototype.createBarChart  = function(element, data, xkey, ykeys, labels, lineColors) {
        Morris.Bar({
            element: element,
            data: data,
            xkey: xkey,
            ykeys: ykeys,
            labels: labels,
            gridLineColor: '#eef0f2',
            barColors: lineColors
        });
    },
    //creates Donut chart
    MorrisCharts.prototype.createDonutChart = function(element, data, colors) {
        Morris.Donut({
            element: element,
            data: data,
            colors: colors
        });
    },
    MorrisCharts.prototype.init = function() {

        //create line chart
        var $data  = [
            { y: '2015', a: 100, b: 90 },
            { y: '2016', a: 75,  b: 65 },
            { y: '2017', a: 50,  b: 40 },
            { y: '2018', a: 75,  b: 65 },
            { y: '2019', a: 50,  b: 40 },
            { y: '2020', a: 75,  b: 65 },
            { y: '2021', a: 100, b: 90 }
          ];
        this.createLineChart('morris-line-example', $data, 'y', ['a', 'b'], ['IT', 'Bussiness'], ['#03a9f4', 'Green']);

        //creating area chart
        var $areaData = [
            { y: '2015', a: 100, b: 90 },
            { y: '2016', a: 75, b: 65 },
            { y: '2017', a: 50, b: 40 },
            { y: '2018', a: 75, b: 65 },
            { y: '2019', a: 50, b: 40 },
            { y: '2020', a: 75, b: 65 },
            { y: '2021', a: 100, b: 90 }
            ];
        this.createAreaChart('morris-area-example', 0, 0, $areaData, 'y', ['a', 'b'], ['IT', 'Bussiness'], ['#03a9f4', 'Green']);

        //creating bar chart
        var $barData  = [
            { y: '12/2019', a: 75,  b: 65 },
            { y: '01/2021', a: 50,  b: 40 },
            { y: '02/2021', a: 75,  b: 65 },
            { y: '03/2021', a: 100, b: 90 }
        ];
        this.createBarChart('morris-bar-example', $barData, 'y', ['a', 'b'], ['IT', 'Bussiness'], ['#03a9f4', 'Green']);

        //creating donut chart
        var $donutData = [
            { label: "Bussiness", value: 260 },
            { label: "re-submit", value: 17},
            { label: "IT", value:300 }
            ];
        this.createDonutChart('morris-donut-example', $donutData, ['red', '#03a9f4', '#01ba9a']);
    },
    //init
    $.MorrisCharts = new MorrisCharts, $.MorrisCharts.Constructor = MorrisCharts
}(window.jQuery),

//initializing 
function($) {
    "use strict";
    $.MorrisCharts.init();
}(window.jQuery);