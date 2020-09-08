using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class Receiver
    {
        public Receiver()
        {

        }
        public string Read(Object obj)
        {
            TcpClient tcpClient = (TcpClient)obj;
            StreamReader sReader = new StreamReader(tcpClient.GetStream());
            string message = null;
            
            try
            {
                message = sReader.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return message;
        }


    }
}
