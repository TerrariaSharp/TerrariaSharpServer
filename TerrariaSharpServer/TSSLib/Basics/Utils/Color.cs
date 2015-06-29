namespace TSSLib.Basics.Utils
{
    public class Color
    {
        public byte Red { get { return r; } set { r = value; } }
        public byte Green { get { return g; } set { g = value; } }
        public byte Blue { get { return b; } set { b = value; } }
        private byte r = 0, g = 0, b = 0;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Red">Red value</param>
        /// <param name="Green">Green value</param>
        /// <param name="Blue">Blue value</param>
        public Color(byte Red = 0, byte Green = 0, byte Blue = 0)
        {
            r = Red;
            g = Green;
            b = Blue;
        }
    }
}
