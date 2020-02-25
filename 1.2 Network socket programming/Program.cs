using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace _1._2_Network_socket_programming
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Bind(new IPEndPoint(IPAddress.Any, 6543));

            socket.Listen(10);
            while (true)
            {
                Socket clientConnection = socket.Accept();

                TryHandleClient(clientConnection);
            }
        }

        private static void TryHandleClient(Socket clientConnection)
        {
            try
            {
                HandleClient(clientConnection);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                clientConnection.Close();
            }
        }

        private static void HandleClient(Socket clientConnection)
        {
            using (NetworkStream networkStream = new NetworkStream(clientConnection))
            {
                using (StreamReader reader = new StreamReader(networkStream))
                {
                    while (true)
                    {
                        if(clientConnection.Available > 0)
                        {
                            string receivedString = reader.ReadLine();
                            Console.WriteLine(receivedString);
                        }
                    }
                }
            }
        }
    }
}
