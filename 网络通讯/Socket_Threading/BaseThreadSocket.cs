using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SocketConnect
{
    public class BaseThreadSocket
    {
        protected Socket socket;
        protected Socket socket_connected;
        protected Task task;
        protected IPAddress address;
        protected int port;
        protected int cacheSize;
        protected bool isClient;
        protected bool connected;
        protected bool taskActive;

        /// <summary>
        /// 连接断开
        /// </summary>
        protected System.Action<bool> onConnectionBreak;

        /// <summary>
        /// 连接委托
        /// </summary>
        protected System.Action<ConnectType> onConnected;

        /// <summary>
        /// 创建Socket对象
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="port"></param>
        /// <param name="isClient"></param>
        /// <param name="startThreadRightNow"></param>
        public BaseThreadSocket(IPAddress addr, int port, bool isClient, bool startThreadRightNow)
        {
            this.isClient = isClient;
            this.address = addr;
            this.port = port;
            if (startThreadRightNow) RestartThread();
        }

        /// <summary>
        /// 设置缓冲区大小
        /// </summary>
        /// <param name="cacheSize"></param>
        public virtual void SetCacheSize(int cacheSize)
        {
            this.cacheSize = cacheSize;
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="data"></param>
        public virtual void SendData(byte[] data)
        {
        }

        /// <summary>
        /// 重新启动线程
        /// 如果Socket对象不为空或thread不为空 则关闭对象  
        /// 重新建立新的线程和对象
        /// </summary>
        public void RestartThread()
        {
            if (socket != null || task != null) Close();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            task = new Task(__RunSocketWork__);
            task.Start();
        }

        /// <summary>
        /// 设置连接状态 
        /// 得到连接状态
        /// 调用onConnected.Invoke
        /// 调用onConnectionBreak.Invoke
        /// </summary>
        /// <param name="active"></param>
        protected virtual void SetConnectionState(bool active)
        {
            connected = active;
            if (active)
            {
                int binderNum = onConnected == null ? 0 : onConnected.GetInvocationList().Length;
                if (isClient)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                }
                onConnected?.Invoke(isClient ? ConnectType.ServerAcceptClient : ConnectType.ClientConnetctToServer);
            }
            else
            {
                onConnectionBreak?.Invoke(!isClient);
                if (isClient)
                {
                    Console.WriteLine($"客户端连接断开");
                }
                else
                {
                    Console.WriteLine($"服务器关闭，无法连接");
                }
            }
        }

        /// <summary>
        /// 启动服务端进行监听
        /// 启动客户端进行请求
        /// </summary>
        protected virtual void __RunSocketWork__()
        {
            taskActive = true;
            if (isClient)
            {
            socketLoop:
                try
                {
                    if (socket != null)
                    {
                        socket.Connect(new IPEndPoint(address, port));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    goto socketLoop;
                }
            }
            else
            {
                socket.Bind(new IPEndPoint(address, port));
                socket.Listen(1);
                socket_connected = socket.Accept();
            }
            SetConnectionState(true);
        }

        /// <summary>
        /// 关闭线程
        /// </summary>
        private void Close()
        {
            taskActive = false;
            if (task != null)
            {
                task.Dispose();
                task = null;
            }
            if (socket_connected != null)
            {
                socket_connected.Close();
                socket_connected = null;
            }
            if (socket != null)
            {
                socket.Close();
                socket = null;
            }
        }

        /// <summary>
        /// 注册数据接收成功事件
        /// </summary>
        /// <param name="callback"></param>
        public virtual void RegOnDataRevieveEvent(System.Action<byte[], int> callback)
        {
        }

        /// <summary>
        /// 注册连接断开事件
        /// </summary>
        /// <param name="callback"></param>
        public virtual void RegOnConnectionBreak(System.Action<bool> callback)
        {
            if (onConnectionBreak == null) onConnectionBreak = callback;
            else onConnectionBreak += callback;
        }

        /// <summary>
        /// 注册连接事件
        /// </summary>
        /// <param name="callback"></param>
        public virtual void RegOnConnected(System.Action<ConnectType> callback)
        {
            if (onConnected == null) onConnected = callback;
            else onConnected += callback;
        }
    }
}
