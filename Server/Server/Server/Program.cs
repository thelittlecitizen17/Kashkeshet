using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading;

namespace Server
{
    class Program
    {
        private static TcpListener tcpListener;
        //private static List<TcpClient> tcpClientsList = new List<TcpClient>();

        static void Main(string[] args)
        {
            TcpListener tcpListener;
            List<TcpClient> tcpClientsList = new List<TcpClient>();
            tcpListener = new TcpListener(IPAddress.Any, 11000);
            tcpListener.Start();

            Console.WriteLine("Server started");

            ServerManager serverManager = new ServerManager(tcpListener);
            serverManager.Start();
   
        }
    }
}

 


//using System;
//using System.Collections.Generic;
//using System.Net;
//using System.Net.Sockets;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Server
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {

//            StartServer();

//        }
//        public static void StartServer()
//        {
//            TcpListener server = null;
//            int port = int.Parse("11000");
//            IPHostEntry host = Dns.GetHostEntry("10.1.0.25");
//            IPAddress ipAddress = host.AddressList[0];
//            server = new TcpListener(ipAddress, port);
//            server.Start();

//            List<TcpClient> clients = new List<TcpClient>();

//            try
//            {


//                Console.WriteLine("Waiting for a connection...");

//                while (true)
//                {
//                    TcpClient client = server.AcceptTcpClient();
//                    clients.Add(client);
//                    Task task = Task.Run(() => getMessage(client));
//                }

//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }


//        }
//        public static void getMessage(TcpClient client)
//        {

//                string data = null;
//                byte[] bytes = null;
//                Console.WriteLine("Connected!");

//                while (true)
//                {
//                    bytes = new byte[1024];

//                    NetworkStream stream = client.GetStream();
//                    int i = 0;
//                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
//                    {
//                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
//                        Console.WriteLine("Received: {0}", data);

//                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

//                        stream.Write(msg, 0, msg.Length);
//                        Console.WriteLine("Sent: {0}", data);
//                    }
//                    client.Close();


//            }
//        }
//    }
//}
