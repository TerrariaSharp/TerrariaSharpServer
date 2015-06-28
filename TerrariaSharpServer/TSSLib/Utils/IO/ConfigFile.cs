using System;
using System.Collections.Generic;
using System.IO;

namespace TSSLib.Utils.IO
{
    public class ConfigFile
    {
        private Dictionary<string, object> data;

        public ConfigFile()
        {
            data = new Dictionary<string, object>();
        }

        public void Load(string path)
        {
            if (path.EndsWith(".cfg") && File.Exists(path))
            {
                string line;
                byte lineNumber = 1;
                data.Clear();
                using (StreamReader sr = new StreamReader(path))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        try
                        {
                            data.Add(line.Split('=')[0], line.Split('=')[1]);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Error at line : " + lineNumber + ". More info : " + ex.Message);
                        }
                        lineNumber++;
                    }
                }
            }
            else
            {
                throw new Exception("Invalid or non-existent file.");
            }
        }

        public T GetData<T>(string key) where T : class
        {
            if (data.ContainsKey(key))
                return (T)data[key];
            else
                return null;
        }

    }
}
