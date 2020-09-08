using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Sender
    {
        public Sender()
        {
                
        }
        public void send(string msg, TcpClient tcpClient)
        {
            StreamWriter sWriter = new StreamWriter(tcpClient.GetStream());
            sWriter.WriteLine(msg);
            sWriter.Flush();
        }
        public void send(List<string> msg, TcpClient tcpClient)
        {
            StreamWriter sWriter = new StreamWriter(tcpClient.GetStream());
            sWriter.WriteLine(msg);
            sWriter.Flush();
        }

    }
}
