var clear = require('clear');

var obj={};
var regexp = /#[\w]+(?=\s|$)/g

var msg="lusho #asd #fafa #fafa #asd #lusho #zc #zc #zc #zc #zc #zc #zc #asd #asd #dsnfjsd #mskmsdsd";

msg=msg.match(regexp);
msg.forEach(function(element) {
    !obj[element]?obj[element]=1:obj[element]++;//se crea o se aumenta el hashtag en el arreglo
    // console.log(obj);
}, this);

var cadenaOrdenada = Object.keys(obj).sort(function(a,b){return obj[b]-obj[a]});

var top10={};
for(var i=0;i<10;i++){
    top10[cadenaOrdenada[i]]=obj[cadenaOrdenada[i]];
}
clear();
console.log(top10);
