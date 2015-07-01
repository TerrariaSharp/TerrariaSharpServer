using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSSLib.Config
{
    public static class Lang
    {
        /// <summary>
        /// French language
        /// </summary>
        private static Dictionary<string, string> frenchDic = new Dictionary<string, string>()
        {
            {"serverStarted", "TerrariaSharpServer démarré !"},
            {"playerConnected", "Nouveau joueur connecté : "},
            {"playerDisconnected", "Joueur déconnecté : "},
            {"unknownPacketReceived", "Packet iconnu reçu"},
            {"serverFull", "Le serveur est plein. Veuillez réessayer plus tard."},
            {"commandNeedStart", "Les commandes doivent commencées par : /"}
        };

        /// <summary>
        /// English language
        /// </summary>
        private static Dictionary<string, string> englishDic = new Dictionary<string, string>()
        {
            {"serverStarted", "TerrariaSharpServer started !"},
            {"playerConnected", "New player connected : "},
            {"playerDisconnected", "Player disconnected : "},
            {"unknownPacketReceived", "Unknown packet received"},
            {"serverFull", "The server is full. Please try again later."},
            {"commandNeedStart", "Commands must start with : /"}
        };

        /// <summary>
        /// Languages available
        /// </summary>
        private static Dictionary<string, Dictionary<string, string>> languages = new Dictionary<string, Dictionary<string, string>>()
        {
            {"fr", frenchDic},
            {"en", englishDic}
        };

        /// <summary>
        /// Get string from specific language
        /// </summary>
        /// <param name="key">Key of the string</param>
        /// <returns>String in specific language</returns>
        public static string GetString(string key)
        {
            string word = "";
            string l = TerrariaServer.Configuration.GetData("lang");
            if (!languages.ContainsKey(l))
            {
                TerrariaServer.Warning("This language doesn't exists : " + l);
                l = "en";
            }
            if (languages[l].ContainsKey(key))
            {
                word = languages[l][key];
            }
            else
            {
                TerrariaServer.Warning("Problem with the language : " + l + " with the key : " + key);
                word = englishDic[key];
            }
            return word;
        }

    }
}
