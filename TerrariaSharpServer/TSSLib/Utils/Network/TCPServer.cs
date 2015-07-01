using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TSSLib.Utils.Network
{
    public class TCPServer
    {

        private TcpListener listener;
        private Thread listenThread;

        private List<TcpClient> tcpClients;

        public delegate void ReceiveDataHandler(TcpClient tcpClient, Packet packet);
        public delegate void PlayerConnectedHandler(TcpClient tcpClient);
        public delegate void PlayerDisconnectedHandler(TcpClient tcpClient);

        public event ReceiveDataHandler OnReceiveData;
        public event PlayerConnectedHandler OnPlayerConnect;
        public event PlayerDisconnectedHandler OnPlayerDisconnect;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="port">Port for the server</param>
        public TCPServer(int port = 7777)
        {
            listener = new TcpListener(IPAddress.Any, port);
            listenThread = new Thread(new ThreadStart(Listen));
            tcpClients = new List<TcpClient>();
        }

        /// <summary>
        /// Start the server
        /// </summary>
        public void Start()
        {
            try
            {
                listener.Start();
                listenThread.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Stop the server
        /// </summary>
        public void Stop()
        {
            try
            {
                if (listenThread.ThreadState == ThreadState.Running)
                    listenThread.Abort();
                if (listener.Server.Connected)
                    listener.Stop();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Listen for new clients
        /// </summary>
        private void Listen()
        {
            while (true)
            {
                if (tcpClients.Count <= 256)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    tcpClients.Add(client);
                    if (OnPlayerConnect != null)
                        OnPlayerConnect.Invoke(client);
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));
                    clientThread.Start(client);
                }
            }
        }

        /// <summary>
        /// Handle clients
        /// </summary>
        /// <param name="c">TcpClient as object</param>
        private void HandleClient(object c)
        {
            TcpClient client = (TcpClient)c;

            while (true)
            {
                try
                {
                    Packet receivePacket = client.Receive();
                    if (OnReceiveData != null)
                        OnReceiveData.Invoke(client, receivePacket);
                }
                catch
                {
                    break;
                }
            }

            tcpClients.Remove(client);

            if (OnPlayerDisconnect != null)
                OnPlayerDisconnect.Invoke(client);

            client.Close();
        }

        /// <summary>
        /// Send packet to all connected clients
        /// </summary>
        /// <param name="packet">Packet to send</param>
        public void SendToAll(Packet packet)
        {
            foreach (TcpClient c in tcpClients)
            {
                c.Send(packet.ToByteArray());
            }
        }
    }
}
