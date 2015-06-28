using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSSLib.Utils.IO;

namespace TSSLib
{
    public class TerrariaServer
    {

        private ConfigFile configFile;

        public TerrariaServer(string configFilePath)
        {
            configFile = new ConfigFile();
            configFile.Load(configFilePath);
        }

        public void Start()
        {

        }

    }
}
