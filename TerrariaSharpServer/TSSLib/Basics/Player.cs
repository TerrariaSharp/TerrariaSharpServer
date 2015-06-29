using System.Net.Sockets;
using TSSLib.Basics.Utils;

namespace TSSLib.Basics
{
    public class Player
    {
        public byte Slot { get { return playerSlot; } set { playerSlot = value; } }
        public byte Gender { get { return playerGender; } set { playerGender = value; } }
        public byte HairStyle { get { return hairStyle; } set { hairStyle = value; } }
        public byte HairDye { get { return hairDye; } set { hairDye = value; } }
        public byte HideVisual { get { return hideVisual; } set { hideVisual = value; } }
        public byte Difficulty { get { return difficulty; } set { difficulty = value; } }
        public string Name { get { return playerName; } set { playerName = value; } }
        public Color HairColor { get { return hairColor; } set { hairColor = value; } }
        public Color SkinColor { get { return skinColor; } set { skinColor = value; } }
        public Color EyeColor { get { return eyeColor; } set { eyeColor = value; } }
        public Color ShirtColor { get { return shirtColor; } set { shirtColor = value; } }
        public Color UndershirtColor { get { return undershirtColor; } set { undershirtColor = value; } }
        public Color PantsColor { get { return pantsColor; } set { pantsColor = value; } }
        public Color ShoeColor { get { return shoeColor; } set { shoeColor = value; } }
        public TcpClient TcpClient { get { return tcpClient; } }

        private byte playerSlot, playerGender, hairStyle, hairDye, hideVisual, difficulty;
        private string playerName;
        private Color hairColor, skinColor, eyeColor, shirtColor, undershirtColor, pantsColor, shoeColor;
        private TcpClient tcpClient;

        /// <summary>
        /// Constructor
        /// </summary>
        public Player(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;
        }



    }
}
