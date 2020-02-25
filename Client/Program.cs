using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(new IPEndPoint(IPAddress.Loopback, 6543));

            using(NetworkStream networkStream = new NetworkStream(socket))
            {
                using(StreamWriter writer = new StreamWriter(networkStream))
                {
                    int packageCount = 0;
                    while (true)
                    {
                        Console.WriteLine("writing");

                        writer.WriteLine($"Hello! This is packet {packageCount++}");
                        writer.Flush();

                        Thread.Sleep(5000);
                    }
                }
            }
        }
    }
}
