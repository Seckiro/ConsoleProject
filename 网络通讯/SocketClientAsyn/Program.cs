using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketClientAsyn
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientSocket();
            Console.ReadLine();
        }

        static void ClientSocket()
        {
            Socket socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 1000);

            socketClient.Connect(iPEndPoint);
            byte[] dataBuffer = new byte[1024];
            int count = socketClient.Receive(dataBuffer);
            string msgReceive = Encoding.UTF8.GetString(dataBuffer, 0, count);
            Console.WriteLine(msgReceive);
            //while (true)
            //{
            //    string str = Console.ReadLine();
            //    if (str == "c" || str == "C")
            //    {
            //        socketClient.Close();
            //        Console.WriteLine($"Client Close!");
            //        return;
            //    }
            //    socketClient.Send(Encoding.UTF8.GetBytes(str));
            //    Console.WriteLine($"Client Send To Sever:{str}");
            //}

            for (int i = 0; i < 100; i++)
            {
                socketClient.Send(Message.GetBytes($"长度:100{i}"));
            }

        }

        static void ClientSocketAsyn()
        {

        }
    }

    class Message
    {
        public static byte[] GetBytes(string data)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            int dataLength = dataBytes.Length;
            byte[] lengthBytes = BitConverter.GetBytes(dataLength);
            byte[] sendBytes = lengthBytes.Concat(dataBytes).ToArray();
            return sendBytes;
        }
    }



}
