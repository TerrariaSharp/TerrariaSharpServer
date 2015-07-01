using System;
using System.IO;
namespace TSSLib.Utils.Network
{
    public class Packet
    {

        public int Length { get { return length; } set { length = value; } }
        private int length;

        public byte ID { get { return id; } set { id = value; } }
        private byte id;

        public byte[] Payload { get { return payload; } set { payload = value; } }
        private byte[] payload;

        /// <summary>
        /// Packet constructor
        /// </summary>
        /// <param name="size">Size of all the message (Header + Payload)</param>
        /// <param name="id">ID of the packet</param>
        /// <param name="payload">Payload</param>
        public Packet(byte id, byte[] payload)
        {
            this.length = payload.Length + 3;
            this.id = id;
            this.payload = payload;
        }

        /// <summary>
        /// Convert the packet to byte array
        /// </summary>
        /// <returns>Packet as a byte array</returns>
        public byte[] ToByteArray()
        {
            byte[] data = new byte[length];
            using (MemoryStream ms = new MemoryStream(data))
            {
                using (BinaryWriter bw = new BinaryWriter(ms))
                {
                    bw.Write(Convert.ToInt16(length));
                    bw.Write(id);
                }
            }
            Array.Copy(payload, 0, data, 3, payload.Length);
            return data;
        }
    }
}
