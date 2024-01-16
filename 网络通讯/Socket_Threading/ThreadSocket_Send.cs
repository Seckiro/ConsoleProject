using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SocketConnect
{
    class ThreadSocket_Send:BaseThreadSocket
    {
        private System.Action onDataSended;

        /// <summary>
        /// 发送数据
        /// </summary>
        protected byte[] dataToSend;

        /// <summary>
        /// 是否接收到新数据
        /// </summary>
        private bool HasNewMsg { get { return dataToSendCache != null && dataToSendCache.Count > 0; } }

        public bool IsSending { get; private set; }

        /// <summary>
        /// 发送缓存，应对带宽受限的问题
        /// </summary>
        private Queue<byte[]> dataToSendCache;

        public ThreadSocket_Send(IPAddress address, int port, bool isClient, bool startThreadRightNow) : base(address, port, isClient, startThreadRightNow)
        {
            dataToSendCache = new Queue<byte[]>();
        }
    }
}
