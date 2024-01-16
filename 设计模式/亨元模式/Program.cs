using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 亨元模式
{
    class Program
    {
        static void Main(string[] args)
        {
            // int 等价于要操作的外部状态
            int externalstate = 10;
            FlyweightFactory factory = new FlyweightFactory();
            Flyweight fa = factory.GetFlyweight("A");
            if (fa != null)
            {
                // 把外部状态作为享元对象的方法调用参数
                fa.Operation(--externalstate);
            }
            Flyweight fc = factory.GetFlyweight("C");
            if (fc != null)
            {
                fc.Operation(--externalstate);
            }
            // 判断是否已经创建了字母D
            Flyweight fd = factory.GetFlyweight("D");
            if (fd != null)
            {
                fd.Operation(--externalstate);
            }
            else
            {
                Console.WriteLine("驻留池中不存在字符串D");
                // 这时候就需要创建一个对象并放入驻留池中
                factory.SetFlyweight("D", new ConcreteFlyweight("D"));
            }
        }
    }

    public class FlyweightFactory
    {
        private Hashtable _flyweights = new Hashtable();

        public FlyweightFactory()
        {
            _flyweights.Add("A", new ConcreteFlyweight("A"));
            _flyweights.Add("B", new ConcreteFlyweight("B"));
            _flyweights.Add("C", new ConcreteFlyweight("C"));
        }

        public Flyweight GetFlyweight(string key)
        {
            return _flyweights[key] as Flyweight;
        }

        public void SetFlyweight(string key, ConcreteFlyweight concreteFlyweight)
        {
            _flyweights.Add(key, concreteFlyweight);
        }
    }

    public abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);
    }

    public class ConcreteFlyweight : Flyweight
    {
        private string _intrinsicstate;

        public ConcreteFlyweight(string innerState)
        {
            this._intrinsicstate = innerState;
        }

        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine($"具体实现类: intrinsicstate {_intrinsicstate}, extrinsicstate {extrinsicstate}");
        }
    }
}
