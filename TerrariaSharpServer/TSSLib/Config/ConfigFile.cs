using System;
using System.Collections.Generic;
using System.IO;

namespace TSSLib.Config
{
    public class ConfigFile
    {
        private Dictionary<string, string> data = new Dictionary<string, string>();

        private string path;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path"></param>
        public ConfigFile(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// Load the config file
        /// </summary>
        public void Load()
        {
            if (path == Config.ApplicationSettings.TSSConfigFileName)
                if (!File.Exists(path))
                    CreateServerConfigFile();
            string line;
            string[] lineSplit;
            byte lineNumber = 1;
            data.Clear();
            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (!line.StartsWith("//"))
                    {
                        try
                        {
                            lineSplit = line.Split('=');
                            data.Add(lineSplit[0], lineSplit[1]);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Error at line : " + lineNumber + ". More info : " + ex.Message);
                        }
                    }
                    lineNumber++;
                }
            }
        }

        /// <summary>
        /// Get data from configuration file
        /// </summary>
        /// <param name="key">Name of the data</param>
        /// <returns>Value</returns>
        public string GetData(string key)
        {
            if (data.ContainsKey(key))
                return data[key].Trim();
            else
                return null;
        }

        /// <summary>
        /// Create a default config file
        /// </summary>
        private static void CreateServerConfigFile()
        {
            using (StreamWriter sw = new StreamWriter(Config.ApplicationSettings.TSSConfigFileName))
            {
                sw.WriteLine("// " + Config.ApplicationSettings.ApplicationName + " - " + Config.ApplicationSettings.ApplicationVersion);
                sw.WriteLine("// " + DateTime.Now);
                sw.WriteLine("serverName=Default TerrariaSharpServer");
                sw.WriteLine("worldName=TSSworld");
                sw.WriteLine("maxPlayer=16");
                sw.WriteLine("serverPassword=");
                sw.WriteLine("serverPort=2048");
                sw.WriteLine("lang=fr");
            }
        }
    }
}
