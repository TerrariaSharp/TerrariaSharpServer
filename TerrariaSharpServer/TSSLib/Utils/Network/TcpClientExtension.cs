using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TSSLib.Utils.Network
{
    public static class TcpClientExtension
    {
        /// <summary>
        /// Write data on the stream
        /// </summary>
        /// <param name="client">TcpClient</param>
        /// <param name="data">Message to send as byte array</param>
        public static void Send(this TcpClient client, byte[] data)
        {
            if (data.Length > 0 && client.Connected)
            {
                try
                {
                    client.GetStream().Write(data, 0, data.Length);
                    client.GetStream().Flush();
                }
                catch(Exception ex)
                {
                    throw new Exception("Error while sending data. More info : " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Receive data from the stream
        /// </summary>
        /// <param name="client">TcpClient</param>
        /// <returns>Packet</returns>
        public static Packet Receive(this TcpClient client)
        {
            if (client.Connected)
            {
                try
                {
                    byte[] data;
                    byte[] size = new byte[2];
                    client.GetStream().Read(size, 0, 2);
                    Int16 sizeInt;
                    byte id;
                    using(MemoryStream ms = new MemoryStream(size))
                    {
                        using(BinaryReader br = new BinaryReader(ms))
                        {
                            sizeInt = br.ReadInt16();
                            id = br.ReadByte();
                        }
                    }
                    data = new byte[sizeInt - 3];
                    client.GetStream().Read(data, 0, data.Length);
                    return new Packet(sizeInt, id, data);
                }
                catch(Exception ex)
                {
                    throw new Exception("Error while receiving data. More info : " + ex.Message);
                }
            }
            return null;
        }

    }
}
