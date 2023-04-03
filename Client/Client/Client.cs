using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Client
{
    internal class Client_server
    {
        public IPHostEntry host { get; }
        public IPAddress ip { get; }
        public IPEndPoint endPoint { get; }

        Socket Sclient;

        public Client_server(string ip, int port)
        {
            this.host = Dns.GetHostEntry(ip);// GetHostByName(ip);
            this.ip = host.AddressList[1];
            this.endPoint = new IPEndPoint(this.ip, port);

            this.Sclient = new Socket(this.ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            //this.Sclient.ConnectAsync(this.endPoint);
        }

        public void start()
        {
            this.Sclient.Connect(this.endPoint);
        }

        public void Send(string message)
        {
            byte[] buff = Encoding.ASCII.GetBytes(message);
            
            Sclient.Send(buff);
            Console.WriteLine("Message Send");
        }
    }
}
