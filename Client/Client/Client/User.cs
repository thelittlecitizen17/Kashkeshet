using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    
    class User
    {

        private string _userName;
        private string _userLastName;
        private HashCode _code;
        public bool IsActive = false;

        public User( string userName , string userLastName)
        {
            _userName = userName;
            _userLastName = userLastName;
            _code = new HashCode();
        }
        public string GetUserName { get { return _userName; } }
        public string GetUserLastName { get { return _userLastName; }  }
        public TcpClient TcpClient { get; set; }
        public HashCode GetId { get { return _code; } }

    }
}
