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
                console.log(" [x] %s: '%s'", msg.fields.routingKey, msg.content.toString());
            }, { noAck: true });
        });
    });
});