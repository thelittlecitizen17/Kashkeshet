using System;
using System.Collections.Generic;
using System.Text;
using MenuBuilder;

namespace Client
{
    class ClientManager
    {
        public User ClientUser;
        public ClientManager(User clientUser)
        {
            ClientUser = clientUser;
        }

        public void Start()
        {
            List<string> myOptions = new List<string>() { "1) Enter to global chat", "2) Start private chat", "3) Enter/create private group", "5) Exit" };
            string menuName = "Main kashkeshet";


            GlobalChatRoom globalChatRoom = new GlobalChatRoom(ClientUser);

            Dictionary<string, IAction> dictOptions = new Dictionary<string, IAction>()
            {
                {"1",globalChatRoom }

            };

            IMenu mainMenu = new NumericMenu(myOptions, menuName, dictOptions);
            mainMenu.GetOptionFromMenu();

        }


    }
}
