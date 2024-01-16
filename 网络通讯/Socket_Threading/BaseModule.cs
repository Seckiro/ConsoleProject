/// <summary>
/// 基础设置,模板、枚举
/// </summary>
namespace SocketConnect
{
    /// <summary>
    /// 通讯端口选择
    /// </summary>
    public enum ConnectID
    {
        Connect_1 = 0,
        Connect_2 = 1,
        Connect_3 = 2,
    }

    /// <summary>
    /// Socket通讯类型
    /// </summary>
    public enum SocketCommucateType
    {
        Send,
        Receive,
        Send_Receive
    }

    public enum ModuleID
    {
        UiModule,
        NetSystemModule,
        InspectorModule,
        ControllerModule
    }

    public enum ConnectType
    {
        ClientConnetctToServer = 0,
        ServerAcceptClient = 1
    }
    /// <summary>
    /// 模组启动数据类型
    /// 抽象类 空类
    /// </summary>
    public abstract class ModuleStartupData { }

    /// <summary>
    /// 模块抽象基类
    /// </summary>
    public abstract class BaseModule
    {
        public ModuleID moduleID { get => _moduleID; }

        protected ModuleID _moduleID;

        public abstract void Startup(ModuleStartupData data);

        public abstract void Shutdown();
    }

    public class NetInfo
    {
        public string ipAddress { get; set; }
        public int basePort { get; set; }
        public NetInfo()
        {
        }
    }
}
