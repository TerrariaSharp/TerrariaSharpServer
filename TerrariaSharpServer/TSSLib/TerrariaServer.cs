using System;
using System.Collections.Generic;
using TSSLib.Basics;
using TSSLib.Utils.IO;
using TSSLib.Utils.Network;

namespace TSSLib
{
    public class TerrariaServer
    {
        private List<Player> players;

        private TCPServer tcpServer;

        /// <summary>
        /// Constructor
        /// </summary>
        public TerrariaServer()
        {
            players = new List<Player>(256);
            ConfigFile.Load();
            tcpServer = new TCPServer(Convert.ToInt32(ConfigFile.GetData("serverPort")));
        }

        /// <summary>
        /// Start the server
        /// </summary>
        public void Start()
        {
            tcpServer.Start();
            Log("TerrariaSharpServer Started !");
        }

        /// <summary>
        /// Log a message on the console
        /// </summary>
        /// <param name="message">Message to log</param>
        private void Log(object message)
        {
            Console.WriteLine("[LOG] " + message);
        }

    }
}
