using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCFrameWork.Model
{
    public class ModelA : BaseModel, IModelA
    {
        public void Init()
        {
            Console.WriteLine("Init ModelA!");
        }
    }
}
