var http = require('http');
var serviceUrl = "localhost";
var express = require('express');
var router = express.Router();

/* GET users listing. */
router.get('/', function (req, res) {
    res.render('beermath', { title: 'BeerMath API' });
    
});


router.route('/abv/:starting_gravity/:final_gravity/:temp_fahrenheit').get(function (req, res){
    var calloptions = {
            host : serviceUrl, 
            port : 80,
            path : '/BeerBrewingApi/api/brewing/alcoholbyvolume/' + req.params.starting_gravity + '/' + req.params.final_gravity + '/' + req.params.temp_fahrenheit, 
            method : 'GET'
    };
    console.info(calloptions);
    var callback = function (res2) {
        var content = "";
        res2.on('data', function (chunk) {
            content += chunk;
        });
        res2.on('end', function () {
            theresults = content;
            res.send(theresults);
        });
    };
    http.request(calloptions, callback).end();
});

module.exports = router;