using System;

namespace IOCFrameWork.Model
{
    public class ModelB : IModelB
    {
        public void Init()
        {
            Console.WriteLine("Init ModelB!");
        }

        public void ModelFun()
        {
            Init();
        }
    }
}
