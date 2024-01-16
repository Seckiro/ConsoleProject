using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    class Program
    {
        public delegate void NotifyEventHandler(object sender);

        public class TenXun
        {
            public NotifyEventHandler notifyEvent;

            public string Symbol { get; set; }
            public string Info { get; set; }
            public TenXun(string symbol, string info)
            {
                this.Symbol = symbol;
                this.Info = info;
            }
            public void AddObserver(NotifyEventHandler ob)
            {
                notifyEvent += ob;
                Console.WriteLine($"--{ob.Method}--{ob.Target}--");

            }
            public void RemoveObserver(NotifyEventHandler ob)
            {
                notifyEvent -= ob;
                Console.WriteLine($"--{ob.Method}--{ob.Target}--");
            }

            public void Update()
            {
                notifyEvent?.Invoke(this);
            }

        }

        public class TenXunGame : TenXun
        {
            public TenXunGame(string symbol, string info)
                : base(symbol, info)
            {
            }
        }

        public class Subscriber
        {
            public string Name { get; set; }
            public Subscriber(string name)
            {
                this.Name = name;
            }

            public void ReceiveAndPrint(Object obj)
            {
                TenXun tenxun = obj as TenXun;

                if (tenxun != null)
                {
                    Console.WriteLine("Notified {0} of {1}'s" + " Info is: {2}", Name, tenxun.Symbol, tenxun.Info);
                }
            }
        }


        static void Main(string[] args)
        {
            TenXun tenXun = new TenXunGame("TenXun Game", "Have a new game published ....");
            Subscriber one = new Subscriber("one");
            Subscriber tom = new Subscriber("Tom");
            // 添加订阅者
            tenXun.AddObserver(new NotifyEventHandler(one.ReceiveAndPrint));
            tenXun.AddObserver(new NotifyEventHandler(tom.ReceiveAndPrint));
            tenXun.Update();
            Console.WriteLine("移除Tom订阅者");
            tenXun.RemoveObserver(new NotifyEventHandler(tom.ReceiveAndPrint));
            tenXun.Update();
        }
    }
}
