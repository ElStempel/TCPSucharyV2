using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace TCPserver
{
    /// <summary>
    /// Klasa Program serwera TCP
    /// </summary>
    class Program
    {

        /// <summary>
        /// Metoda Main uruchamiająca serwer z klasy Server w bibliotece klas
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            TCPserverLibrary.ServerAPM server = new TCPserverLibrary.ServerAPM(IPAddress.Parse("127.0.0.1"), 8008);
            try
            {
                server.Start();
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
