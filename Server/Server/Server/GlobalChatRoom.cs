using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    class GlobalChatRoom
    {
        private TcpListener _tcpListener;
        private List<TcpClient> _tcpClients = new List<TcpClient>();
        private readonly object _lock = new object();

        public GlobalChatRoom(TcpListener tcpListener)
        {
            _tcpListener = tcpListener;
        }
        //public void Starter()
        //{
        //    TcpClient tcpClient = _tcpListener.AcceptTcpClient();
        //    _allClients.Add(tcpClient);

        //    Thread thread = new Thread(() => ClientListener(tcpClient));
        //    thread.Start();
        //}
        public void ClientListener(object obj, ref List<TcpClient> _tcpClients)
        {
            TcpClient tcpClient = (TcpClient)obj;
            StreamReader reader = new StreamReader(tcpClient.GetStream());

            Console.WriteLine("Client connected");
            string message = "start";

            while (true)
            {
                try
                {
                    message = reader.ReadLine();

                    //string message ="\nPlease enter your choice\n1)Global chat\n2)private ChatRoom\n3)private Message";
                    if (message != "exit")
                    {
                        Console.WriteLine("I am here");
                        BroadCast broadCast = new BroadCast();
                        broadCast.Publish(message, tcpClient, _tcpClients);
                    }
                    else
                    {
                        Console.WriteLine("I want to exit");
                        lock (_lock)
                        {
                            _tcpClients.Remove(tcpClient);
                        }
                        break;
                    }

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
                
            }
            tcpClient.Close();


        }

    }
}
