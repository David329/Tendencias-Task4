﻿using System;
using System.Linq;
using RabbitMQ.Client;
using System.Text;
using Tweetinvi;
namespace send
{
    class Program
    {
        public static void Main(string[] args)    
        {
            Auth.SetUserCredentials("lPZEzMHtQ2OVkLRgIyLVmyJet", "UHrpP7yJxbDJSCCkTcUaxANErFsVmYNnUOSx3jW1PE2NyRQ4zo", "ACCESS_TOKEN", "ACCESS_TOKEN_SECRET");

            // Publish the Tweet "Hello World" on your Timeline
            Tweet.PublishTweet("Hello World!");

            Console.ReadLine();

            // var factory = new ConnectionFactory() { HostName = "166.62.89.37",Port= 8080};
            // using(var connection = factory.CreateConnection())
            // using(var channel = connection.CreateModel())
            // {
            //     channel.ExchangeDeclare(exchange: "direct_logs",type: "direct");

            //     Pedido pedido=new Pedido();
            //     while(true)
            //     {
            //         Console.Write("--------------------------\n\tNUEVO PEDIDO\n--------------------------\n");
            //         Console.Write("Tipo: ");
            //         pedido.tipo=Console.ReadLine();
            //         Console.Write("Nombre: ");
            //         pedido.prod.nombre=Console.ReadLine();
            //         Console.Write("Precio: ");
            //         pedido.prod.precio=float.Parse(Console.ReadLine());
            //         Console.Write("Cantidad: ");
            //         pedido.prod.cantidad=Int32.Parse(Console.ReadLine());

            //         string message = JsonConvert.SerializeObject(pedido);

            //         var body = Encoding.UTF8.GetBytes(message);
            //         //severity=tipo de pedido
            //         channel.BasicPublish(exchange: "direct_logs",routingKey: pedido.tipo,basicProperties: null,body: body);
            //         Console.WriteLine(" [x] Sent '{0}':'{1}'", pedido.tipo, message);

            //         Console.WriteLine("Continuar?!(salir): ");
            //         if(Console.ReadLine()=="salir")break;
            //     }
            // }
            // Console.WriteLine("Fin.");
        }
    }
    // public class Pedido
    // {
    //     public string tipo;
    //     public Producto prod;
    //     public Pedido()
    //     {
    //         this.prod=new Producto();
    //     }
    // }
    // public class Producto
    // {
    //     public string nombre;
    //     public float precio;
    //     public int cantidad;
    // }
}