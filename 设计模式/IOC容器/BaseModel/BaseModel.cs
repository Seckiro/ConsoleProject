using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCFrameWork
{
    public abstract class BaseModel : IBaseModel
    {
        public void ModelFun()
        {
            Console.WriteLine("Init ModelBase!");
        }
    }
}
