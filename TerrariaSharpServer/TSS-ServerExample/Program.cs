using System;
using TSSLib;

namespace TSS_ServerExample
{
    class Program
    {
        private static TerrariaServer terrariaServer;

        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">Execution's args</param>
        static void Main(string[] args)
        {

            terrariaServer = new TerrariaServer();
            terrariaServer.Start();
        }
    }
}
