using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPserverLibrary
{

    public class ServerAPM : ServerAbstract
    {

        static string negatyw = "Ja tylko serwuje suchary\n";
        static string instrukcja = "\n\"suchar\" wysyla suchara, \"quit\" rozlacza, \"nowy\" pozwala dodac suchar\n";
        static string dodaj = "\nNapisz tutaj suchara, enter wysyla.\n";
        byte[] instr = Encoding.ASCII.GetBytes(instrukcja);
        byte[] bytes = Encoding.ASCII.GetBytes(negatyw);
        byte[] dod = Encoding.ASCII.GetBytes(dodaj);

        Joke suchy = new Joke();


        public delegate void TransmissionDataDelegate(NetworkStream stream);

        public ServerAPM(IPAddress IP, int port) : base(IP, port)
        {

        }

        protected override void AcceptClient()
        {

            while (true)
            {

                TcpClient tcpClient = TcpListener.AcceptTcpClient();
                Stream = tcpClient.GetStream();
                TransmissionDataDelegate transmissionDelegate = new TransmissionDataDelegate(BeginDataTransmission);
                transmissionDelegate.BeginInvoke(Stream, TransmissionCallback, tcpClient);

            }

        }

        private void TransmissionCallback(IAsyncResult ar)
        {

        }

        protected override void BeginDataTransmission(NetworkStream stream)
        {
            char[] trim = { (char)0x0 };
            byte[] buffer = new byte[Buffer_size];
            //stream = tcpClient.GetStream();
            //suchy.saveToFile();

            while (true)
            {
                try
                {
                    stream.Write(instr, 0, instr.Length);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                //Odbieranie wiadomości

                //stream.Read(buffer,0,buffer.Length);
                //Array.Clear(buffer, 0, buffer.Length);
                //string text = Encoding.UTF8.GetString(buffer).Replace("\n", "").Replace("\0", "");
                //Console.Write(text);
                int dlugosc = stream.Read(buffer, 0, buffer.Length);
                if (Encoding.ASCII.GetString(buffer, 0, dlugosc) == "\r\n")
                {
                    stream.Read(buffer, 0, buffer.Length);
                }
                string text = Encoding.ASCII.GetString(buffer).Trim(trim);
                Array.Clear(buffer, 0, buffer.Length);
                Console.WriteLine(text);

                //Rozpoznawanie otrzymanego komunikatu i odpowiedzi
                //dodawanie suchara
                if (text == "nowy")
                {
                    Console.WriteLine("Dodawanie suchara\n");
                    stream.Write(dod, 0, dod.Length);
                    dlugosc = stream.Read(buffer, 0, buffer.Length);
                    if (Encoding.ASCII.GetString(buffer, 0, dlugosc) == "\r\n")
                    {
                        stream.Read(buffer, 0, buffer.Length);
                    }
                    string nowy = Encoding.ASCII.GetString(buffer).Trim(trim);
                    Array.Clear(buffer, 0, buffer.Length);
                    Console.WriteLine(nowy);
                    suchy.addJoke(nowy);
                }
                else if (text == "quit") //rozłączanie
                {
                    Console.WriteLine("Rozłączam\n");
                    try
                    {
                        stream.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    break;
                }
                else if (text == "suchar") //podawanie suchara
                {
                    Console.WriteLine("Potwierdzam\n");
                    String sucharek = suchy.genJoke();
                    byte[] pozytyw = Encoding.ASCII.GetBytes(sucharek);
                    stream.Write(pozytyw, 0, pozytyw.Length);

                }
                else
                {
                    Console.WriteLine("Odrzucam\n");
                    stream.Write(bytes, 0, bytes.Length);
                }
            }

        }

        public override void Start()
        {

            StartListening();
            //transmission starts within the accept function
            AcceptClient();

        }



    }

}