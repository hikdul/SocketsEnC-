using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I am the Client");
            Client_server client = new Client_server("127.0.0.1", 9000);
            client.start();
            string msg = string.Empty;

            while (msg != "0")
            {
                Console.WriteLine("Ingese mensaje a enviar o presione 0 para salir: ");
                msg = Console.ReadLine();
                client.Send( msg);
            }
        }
    }
}
