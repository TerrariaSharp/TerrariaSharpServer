namespace TSSLib.Utils.Network
{
    public class Packet
    {

        public int Size { get { return size; } set { size = value; } }
        private int size;

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
        public Packet(int size, byte id, byte[] payload)
        {
            this.size = size;
            this.id = id;
            this.payload = payload;
        }
    }
}
