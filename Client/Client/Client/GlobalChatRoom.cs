using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using MenuBuilder;

namespace Client
{
    class GlobalChatRoom:IAction
    {
        private User _user;
        private bool _flag = true;
        private readonly object _lock = new object();
        public GlobalChatRoom(User user)
        {
            _user = user;
        }
        public void RunOption()
        {
            Receiver receiver = new Receiver();
            try
            {
                TcpClient tcpClient = new TcpClient("10.1.0.25", 11000);
                Console.WriteLine("Connected to server.");
                Console.WriteLine("");
                _user.TcpClient = tcpClient;

                Thread thread = new Thread(Read);
                thread.Start(_user.TcpClient);

                StreamWriter sWriter = new StreamWriter(_user.TcpClient.GetStream());
                sWriter.WriteLine($"{_user.GetUserName + " " + _user.GetUserLastName + "Entered the group\n"}");
                sWriter.Flush();

                while (_flag)
                {
                    if (_user.TcpClient.Connected)
                    {
                        string input = Console.ReadLine();
                        if(input!="exit")
                        {
                            sWriter.WriteLine(_user.GetUserName + " " + _user.GetUserLastName + ": " + input);
                            sWriter.Flush();
                        }
                        else
                        {

                            lock (_lock)
                            {
                                sWriter.WriteLine(input);
                                sWriter.WriteLine($"{_user.GetUserName + " " + _user.GetUserLastName + "has left the group\n"}");
                                sWriter.Flush();

                                _flag = false;
                            }
                            break;
                        }
                        
                    }
                }
                lock (_lock)
                {
                    _user.TcpClient.Close();
                    _user.TcpClient.Dispose();
                }
           
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            Console.ReadKey();
        }
        public void Read(Object obj)
        {
            Receiver receiver = new Receiver();
            string msg = null;
            while(_flag)
            {
                msg = receiver.Read(obj);
                Console.WriteLine(msg);
                
            }
            lock (_lock)
            {
                _flag = true;
            }
            
        }


    }
}

