using IOCFrameWork.Core;
using IOCFrameWork.Model;

namespace IOCFrameWork
{
    class Program
    {
        static void Main(string[] args)
        {
            IocContainer.Register<IModelA, ModelA>();
            IocContainer.Register<IModelB, ModelB>();
            IocContainer.Reslove<IModelA>().ModelFun();
            IocContainer.Reslove<IModelB>().ModelFun();
        }
    }
}
