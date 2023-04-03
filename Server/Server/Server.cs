using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Server_base
    {
        public IPHostEntry host { get; }
        public IPAddress ip { get; }
        public IPEndPoint endPoint { get; }
        public Socket Sserver { get; }
        public Socket Sclient { get; set; }

        public Server_base(string ip, int port)
        {
            this.host = Dns.GetHostEntry(ip);//.GetHostByName(ip);
            this.ip = host.AddressList[1];
            this.endPoint = new IPEndPoint(this.ip, port);

            this.Sserver = new Socket(this.ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            this.Sserver.Bind(this.endPoint);
            this.Sserver.Listen(1000);

        }

        public void start()
        {

            // por ahora solo trabajamos con cadenas de texto por tanto nos lo hace simple
            this.Sclient = this.Sserver.Accept();
            Console.WriteLine("cliente aceptado: {0}", Sclient.ReceiveBufferSize);
            string message = string.Empty;
            while (message != "0")
            {
                byte[] buffer = new byte[1024];
                this.Sclient.Receive(buffer);
                message = getMessage(buffer);
                Console.WriteLine(message);
            }

        }

        public string getMessage(byte[] buffer)
        {
            return Encoding.ASCII.GetString(buffer);
        }
    }
}
