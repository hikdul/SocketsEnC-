using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I am the Server");
            var server = new Server_base("127.0.0.1", 9000);
            server.start();
        }
    }
}
