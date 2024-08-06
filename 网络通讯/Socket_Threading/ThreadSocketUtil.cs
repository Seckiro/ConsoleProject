using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
namespace SocketConnect
{
    public static class ThreadSocketUtil
    {
        public static BaseThreadSocket CearteSocket(IPAddress ip, int port, SocketCommucateType type, bool isClient, bool startThreadRightNow)
        {
            switch (type)
            {
                case SocketCommucateType.Send:
                    return new ThreadSocket_Send(ip, port, true, true);
                case SocketCommucateType.Receive:
                    return new ThreadSocket_Recieve(ip, port, false, true);
                case SocketCommucateType.Send_Receive:
                    break;
            }
            return null;
        }

    }

    public static class ConfigUtils
    {
        public static string ConfigIpFilePath = Directory.GetCurrentDirectory();

        public static void SaveJsonConfigFile<T>(T data, string fileName = "") where T : class
        {
            string filePath = ConfigIpFilePath + @"\" + fileName + ".json";
            if (fileName == String.Empty)
            {
                filePath = ConfigIpFilePath + @"\" + typeof(T).ToString() + ".json";
            }
            using (StreamWriter writer = File.CreateText(filePath))
            {
                string json = JsonConvert.SerializeObject(data);
                writer.Write(json);
                writer.Close();
            }
        }

        public static T ReadJsonConfigFile<T>(string fileName = "") where T : class
        {
            string filePath = ConfigIpFilePath + @"\" + fileName + ".json";
            if (fileName == String.Empty)
            {
                filePath = ConfigIpFilePath + @"\" + typeof(T).ToString() + ".json";
            }

            if (!File.Exists(filePath))
            {
                if (!File.Exists(ConfigIpFilePath + @"\" + typeof(T).ToString() + ".json"))
                {
                    filePath = ConfigIpFilePath + @"\" + typeof(T).ToString() + ".json";
                }
                else
                    return null;
            }

            T info;
            using (StreamReader writer = File.OpenText(filePath))
            {
                info = JsonConvert.DeserializeObject<T>(writer.ReadToEnd());

                writer.Close();
            }
            return info;
        }
    }

    public static class NetUitl
    {
        public static IPAddress GetHostIp()
        {
            string hostName = Dns.GetHostName();
            //Console.WriteLine($"Host Name:{hostName}");
            IPHostEntry ipEntry = Dns.GetHostEntry(hostName);

            foreach (IPAddress ip in ipEntry.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            return null;
        }
    }

}
