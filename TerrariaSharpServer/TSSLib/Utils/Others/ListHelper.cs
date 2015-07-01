using System;
using System.Collections.Generic;
using System.Net.Sockets;
using TSSLib.Basics;

namespace TSSLib.Utils.Others
{
    public static class ListHelper
    {
        /// <summary>
        /// Fill an array with null value
        /// </summary>
        /// <param name="array">The array to fill</param>
        public static void FillArrayWithNull(ref Player[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = null;
            }
        }

        /// <summary>
        /// Get the first available slot in array
        /// </summary>
        /// <param name="array">Player list</param>
        /// <returns></returns>
        public static int FirstIndexAvailable(Player[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Get a client from his TcpClient
        /// </summary>
        /// <param name="client">TcpClient</param>
        /// <param name="array">Player list</param>
        /// <returns></returns>
        public static Player GetPlayerFromTcpClient(TcpClient client, Player[] array)
        {
            foreach (Player p in array)
            {
                if (p.TcpClient == client)
                    return p;
            }
            return null;
        }

        /// <summary>
        /// Check if the array contains a TcpClient
        /// </summary>
        /// <param name="client">TcpClient to check</param>
        /// <param name="array">Player list</param>
        /// <returns></returns>
        public static bool ArrayContains(TcpClient client, Player[] array)
        {
            foreach(Player p in array)
            {
                if (p.TcpClient == client)
                    return true;
            }
            return false;
        }

    }
}
