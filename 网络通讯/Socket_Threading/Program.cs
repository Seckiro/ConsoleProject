using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;


namespace SocketConnect
{
    class Program
    {
        static void Main(string[] args)
        {
            NetIpInfo netIpInfo = new NetIpInfo()
            {
                ipAddress = NetUitl.GetHostIp().ToString(),
                import = 10086
            };
            ConfigUtils.SaveJsonConfigFile<NetIpInfo>(netIpInfo);
            Console.WriteLine(ConfigUtils.ReadJsonConfigFile<NetIpInfo>().ipAddress);
        }
    }
}
