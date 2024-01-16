using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SocketConnect
{
    public class ThreadSocket_Recieve : BaseThreadSocket
    {
        protected System.Action<byte[], int> onReceiveData;

        /// <summary>
        /// 判断该帧是否接受完毕
        /// </summary>
        private bool waitForDataTail;

        /// <summary>
        /// 最后帧的长度
        /// </summary>
        private int lastRcvedLen = 0;

        /// <summary>
        /// 完全帧的长度
        /// </summary>
        private int wholeFrameDataLen = 0;

        /// <summary>
        /// 接收数据的数组
        /// </summary>
        byte[] frameData;

        /// <summary>
        /// 线程的创建
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <param name="isClient"></param>
        /// <param name="startThread"></param>
        /// <param name="cacheSize"></param>
        public ThreadSocket_Recieve(IPAddress address, int port, bool isClient, bool startThread, int cacheSize = 1024)
         : base(address, port, isClient, startThread) { this.cacheSize = cacheSize; }

    }
}
