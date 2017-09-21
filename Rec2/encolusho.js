var clear = require('clear');
var top10 = {};
var backupTop10 = {};
var obj = {};
var regexp = /#[\w]+(?=\s|$)/g

var amqp = require('amqplib/callback_api');
var severity = "analytics";

amqp.connect('amqp://166.62.89.37:8080', function (err, conn) {
    conn.createChannel(function (err, ch) {
        var ex = 'direct_logs';

        ch.assertExchange(ex, 'direct', { durable: false });

        ch.assertQueue('', { exclusive: true }, function (err, q) {
            console.log(' [*] Waiting for logs. To exit press CTRL+C');

            ch.bindQueue(q.queue, ex, severity);

            ch.consume(q.queue, function (msg) {
                var message = msg.content.toString();
                message = message.match(regexp);
                if (message != null) {
                    message.forEach(function (element) {
                        !obj[element] ? obj[element] = 1 : obj[element]++;//se crea o se aumenta el hashtag en el arreglo
                        // console.log(obj);
                    }, this);

                    var cadenaOrdenada = Object.keys(obj).sort(function (a, b) { return obj[b] - obj[a] });

                    for (var i = 0; i < 10; i++) {
                        top10[cadenaOrdenada[i]] = obj[cadenaOrdenada[i]];
                    }
                    if (top10 != backupTop10) {
                        clear();
                        console.log(top10);
                    }
                    backupTop10 = top10;
                    top10 = {};
                }
                // console.log(" [x] %s: '%s'", msg.fields.routingKey, msg.content.toString());
            }, { noAck: true });
        });
    });
});