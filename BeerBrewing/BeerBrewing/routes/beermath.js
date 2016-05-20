var express = require('express');
var router = express.Router();

/* GET users listing. */
router.get('/', function (req, res) {
    res.render('beermath', { title: 'BeerMath API' });
    
});


router.route('/abv')
    .get(function (req, res)
    {
        res.send("getting the abv dawg");
    });

module.exports = router;