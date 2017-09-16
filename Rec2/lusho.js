var Twitter = require('twitter');
var Auth = require('./auth.js');

var client = new Twitter({
    consumer_key: Auth.consumer_key,
    consumer_secret: Auth.consumer_secret,
    access_token_key: Auth.access_token_key,
    access_token_secret: Auth.access_token_secret
});
// console.info(Auth.consumer_key); //probando probando xd

var params = { screen_name: 'nodejs' };
client.get('statuses/user_timeline', params, function (error, tweets, response) {
    if (!error) {
        console.log(tweets);
    }
});