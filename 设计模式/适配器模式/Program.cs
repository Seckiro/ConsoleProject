using System;

namespace 适配器模式
{
    /// <summary>
    /// 客户端，客户想要把2个孔的插头 转变成三个孔的插头，这个转变交给适配器就好
    /// 既然适配器需要完成这个功能，所以它必须同时具体2个孔插头和三个孔插头的特征
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IVariant variant = new InstanceClass();
            variant.Request();
        }
    }

    public interface IVariant
    {
        void Request();
    }

    public abstract class BaseClass
    {
        public void BaseRequest()
        {
            Console.WriteLine("Base Operation!");
        }
    }

    public class InstanceClass : BaseClass, IVariant
    {
        public void Request()
        {
            this.BaseRequest();
        }
    }
}
