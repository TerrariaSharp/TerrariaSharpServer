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

        public TerrariaServer(string configFilePath)
        {
            ConfigFile.Load(configFilePath);
        }

        public void Start()
        {

        }

    }
}
