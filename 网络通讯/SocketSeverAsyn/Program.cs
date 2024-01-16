using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace SokcetSeverAsyn
{
    class Program
    {
        static void Main(string[] args)
        {
            StartSocketAsync();
            Console.ReadKey();
        }

        public static void StartSocketAsync()
        {
            Socket socketSever = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 1000);
            socketSever.Bind(iPEndPoint);
            socketSever.Listen(10);
            socketSever.BeginAccept(AcceptCallback, socketSever);
        }

        static Message message = new Message();
        static byte[] dataBuffer = new byte[1024];

        static void ReceiveCallback(IAsyncResult result)
        {
            Socket socketClient = null;
            try
            {
                socketClient = result.AsyncState as Socket;
                int count = socketClient.EndReceive(result);
                if (count == 0)
                {
                    socketClient.Close();
                    Console.WriteLine($"Client Close!");
                    return;
                }
                message.AddCount(count);
                message.ReadMessage();

                socketClient.BeginReceive(message.DataBuffer, message.StartIndex, message.RemainSize, SocketFlags.None, ReceiveCallback, socketClient);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                if (socketClient != null)
                {
                    socketClient.Close();
                }
            }
        }

        static void AcceptCallback(IAsyncResult result)
        {
            Socket socketSever = result.AsyncState as Socket;
            Socket socketClient = socketSever.EndAccept(result);

            Console.WriteLine($"Client Accept:{socketClient.Connected}");

            string str = "Welcome Client!";
            socketClient.Send(Encoding.UTF8.GetBytes(str));
            Console.WriteLine($"Sever Send To Client:{str}");

            socketClient.BeginReceive(message.DataBuffer, message.StartIndex, message.RemainSize, SocketFlags.None, ReceiveCallback, socketClient);
            socketSever.BeginAccept(AcceptCallback, socketSever);

        }

        public static void StartSocket()
        {
            Socket socketSever = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress iPAddress = IPAddress.Parse("192.168.50.179");
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 10000);
            socketSever.Bind(iPEndPoint);
            socketSever.Listen(10);
            Socket socketClient = socketSever.Accept();

            string msg = "你好！！！客户端";
            socketClient.Send(Encoding.UTF8.GetBytes(msg));

            byte[] dataBuffer = new byte[1024];

            int count = socketClient.Receive(dataBuffer);
            string msgReceive = Encoding.UTF8.GetString(dataBuffer, 0, count);

            Console.WriteLine(msgReceive);

            socketClient.Close();
            socketSever.Close();
        }

    }


    class Message
    {
        private byte[] dataBuffer = new byte[1024];
        private int startIndex = 0;

        public byte[] DataBuffer
        {
            get => dataBuffer;
        }
        public int StartIndex
        {
            get => startIndex;
        }

        public int RemainSize
        {
            get => dataBuffer.Length - startIndex;
        }


        public void AddCount(int count)
        {
            startIndex += count;
        }

        public void ReadMessage()
        {
            while (true)
            {
                if (startIndex <= 4) return;

                int count = BitConverter.ToInt32(dataBuffer, 0);

                if ((startIndex - 4) >= count)
                {
                    string str = Encoding.UTF8.GetString(dataBuffer, 4, count);
                    Console.WriteLine($"From Client Received:{str}");
                    Array.Copy(dataBuffer, count + 4, dataBuffer, 0, startIndex - 4 - count);
                    startIndex -= (count + 4);
                }
                else
                {
                    return;
                }
            }
        }
    }
}
