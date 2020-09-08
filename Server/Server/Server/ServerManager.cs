using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    class ServerManager
    {
        private TcpListener _tcpListener;
        private List<TcpClient> _allClients = new List<TcpClient>();
        private List<TcpClient> _chatRoomClients = new List<TcpClient>();

        public ServerManager(TcpListener tcpListener)
        {
            _tcpListener = tcpListener;
        }
        
        public void Start()
        {
            GlobalChatRoom globalChatRoom = new GlobalChatRoom(_tcpListener);
            while (true)
            {
                TcpClient tcpClient = _tcpListener.AcceptTcpClient();
                _chatRoomClients.Add(tcpClient);

                Thread thread = new Thread(() => globalChatRoom.ClientListener(tcpClient, ref _chatRoomClients));
                thread.Start();
            }
        }
    }

}
