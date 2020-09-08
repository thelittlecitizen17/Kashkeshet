using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {

                Console.WriteLine("Please enter your name");
                var name = Console.ReadLine();
                Console.WriteLine("Please enter your last name");
                var lastName = Console.ReadLine();

                User user = new User( name, lastName);
                ClientManager clientManager = new ClientManager(user);
                clientManager.Start();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}




