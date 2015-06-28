using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSSLib;

namespace TSS_ServerExample
{
    class Program
    {
        private static TerrariaServer terrariaServer;

        static void Main(string[] args)
        {

            terrariaServer = new TerrariaServer("config.cfg");
            terrariaServer.Start();
        
        }
    }
}
