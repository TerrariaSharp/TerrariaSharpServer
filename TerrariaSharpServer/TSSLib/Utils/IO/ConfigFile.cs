using System;
using System.Collections.Generic;
using System.IO;

namespace TSSLib.Utils.IO
{
    public static class ConfigFile
    {
        private static Dictionary<string, string> data = new Dictionary<string, string>();

        /// <summary>
        /// Load the config file
        /// </summary>
        public static void Load()
        {
            if (!File.Exists(ApplicationSettings.TSSConfigFileName))
                CreateConfigFile();
            string line;
            string[] lineSplit;
            byte lineNumber = 1;
            data.Clear();
            using (StreamReader sr = new StreamReader(ApplicationSettings.TSSConfigFileName))
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
        public static string GetData(string key)
        {
            if (data.ContainsKey(key))
                return data[key];
            else
                return null;
        }

        /// <summary>
        /// Create a default config file
        /// </summary>
        private static void CreateConfigFile()
        {
            using (StreamWriter sw = new StreamWriter(ApplicationSettings.TSSConfigFileName))
            {
                sw.WriteLine("// " + ApplicationSettings.ApplicationName + " - " + ApplicationSettings.ApplicationVersion);
                sw.WriteLine("// " + DateTime.Now);
                sw.WriteLine("serverName=Default TerrariaSharpServer");
                sw.WriteLine("worldName=TSSworld");
                sw.WriteLine("maxPlayer=16");
                sw.WriteLine("serverPassword=");
                sw.WriteLine("serverPort=2048");
            }
        }
    }
}
