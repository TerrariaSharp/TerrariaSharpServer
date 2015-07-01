using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using TSSLib.Basics;
using TSSLib.Utils.Network;
using TSSLib.Utils.Others;
using System.Threading;

namespace TSSLib
{
    public class TerrariaServer
    {
        private Player[] players;

        private TCPServer tcpServer;

        public static Config.ConfigFile Configuration = new Config.ConfigFile(Config.ApplicationSettings.TSSConfigFileName);

        private Thread handleCommandsThread;

        private World world;

        /// <summary>
        /// Constructor
        /// </summary>
        public TerrariaServer()
        {
            players = new Player[256];
            ListHelper.FillArrayWithNull(ref players);
            Configuration.Load();
            world = new World(Configuration.GetData("worldName"));
            world.Load();
            tcpServer = new TCPServer(Convert.ToInt32(Configuration.GetData("serverPort")));
            tcpServer.OnPlayerConnect += tcpServer_OnPlayerConnect;
            tcpServer.OnPlayerDisconnect += tcpServer_OnPlayerDisconnect;
            tcpServer.OnReceiveData += tcpServer_OnReceiveData;
            handleCommandsThread = new Thread(new ThreadStart(HandleCommands));
            handleCommandsThread.Start();
        }

        /// <summary>
        /// Handle commands from server
        /// </summary>
        private void HandleCommands()
        {
            string message;
            while (true)
            {
                message = Console.ReadLine().Trim();
                if (message.StartsWith("/"))
                {

                }
                else
                {
                    if (message != "")
                        Warning(Config.Lang.GetString("commandNeedStart"));
                }

            }
        }

        /// <summary>
        /// Start the server
        /// </summary>
        public void Start()
        {
            tcpServer.Start();
            Log(Config.Lang.GetString("serverStarted"));
        }

        /// <summary>
        /// When server receive data from a client
        /// </summary>
        /// <param name="tcpClient">TcpClient</param>
        /// <param name="packet">Packet</param>
        private void tcpServer_OnReceiveData(TcpClient tcpClient, Packet packet)
        {
            //Log(packet.ID);
            switch (packet.ID)
            {
                case 1:
                    if (ListHelper.ArrayContains(tcpClient, players))
                    {
                        Player tempPlayer = ListHelper.GetPlayerFromTcpClient(tcpClient, players);
                        tempPlayer.TcpClient.Send(new Packet(3, new byte[1] { tempPlayer.Slot }).ToByteArray());
                    }
                    break;

                case 4:
                    tcpServer.SendToAll(packet);
                    break;
                case 68:
                    //tcpServer.SendToAll(packet);
                    break;
                case 16:
                    tcpServer.SendToAll(packet);
                    break;
                case 42:
                    tcpServer.SendToAll(packet);
                    break;
                case 50:
                    tcpServer.SendToAll(packet);
                    break;
                case 5:
                    tcpServer.SendToAll(packet);
                    break;
                case 6:
                    tcpClient.Send(new Packet(7, world.ToByteArray()).ToByteArray());
                    break;

                default:
                    Log(Config.Lang.GetString("unknownPacketReceived") + " : " + packet.ID);
                    break;

            }
        }

        /// <summary>
        /// When client connect
        /// </summary>
        /// <param name="tcpClient">TcpClient</param>
        private void tcpServer_OnPlayerConnect(TcpClient tcpClient)
        {
            Log(Config.Lang.GetString("playerConnected") + tcpClient.Client.RemoteEndPoint);
            Player tempPlayer = new Player(tcpClient);
            if (ListHelper.FirstIndexAvailable(players) != -1)
            {
                tempPlayer.Slot = (Byte)ListHelper.FirstIndexAvailable(players);
                players[tempPlayer.Slot] = tempPlayer;
            }
            else
            {
                string message = Config.Lang.GetString("serverFull");
                byte[] messageArray = new byte[Encoding.UTF8.GetBytes(message).Length + 3];
                using (MemoryStream ms = new MemoryStream(messageArray))
                {
                    using (BinaryWriter bw = new BinaryWriter(ms))
                    {
                        bw.Write(message);
                    }
                }
                tempPlayer.TcpClient.Send(new Packet(2, messageArray).ToByteArray());
            }
        }

        /// <summary>
        /// When client disconnect
        /// </summary>
        /// <param name="tcpClient">TcpClient</param>
        private void tcpServer_OnPlayerDisconnect(TcpClient tcpClient)
        {
            Log(Config.Lang.GetString("playerDisconnected") + tcpClient.Client.RemoteEndPoint);
            Player tempPlayer = new Player(tcpClient);
            players[tempPlayer.Slot] = null;
        }

        /// <summary>
        /// Log a message on the console
        /// </summary>
        /// <param name="message">Message to log</param>
        public static void Log(object message)
        {
            Console.WriteLine("[LOG] " + message);
        }

        /// <summary>
        /// Log a warning message on the console
        /// </summary>
        /// <param name="message">Message to log</param>
        public static void Warning(object message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[WARNING] ");
            Console.ResetColor();
            Console.WriteLine(message);
        }
    }
}
