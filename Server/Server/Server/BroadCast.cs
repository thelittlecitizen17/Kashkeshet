using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class BroadCast
    {
        public BroadCast()
        {
                
        }
        public void Publish(string msg, TcpClient excludeClient, List<TcpClient> tcpClients)
        {
            foreach (TcpClient client in tcpClients)
            {
                if (client != excludeClient)
                {
                    StreamWriter sWriter = new StreamWriter(client.GetStream());
                    sWriter.WriteLine(msg);
                    sWriter.Flush();
                }
            }
        }
    }

}
