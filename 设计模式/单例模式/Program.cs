using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单例模式
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClass_A.Instance.Method();
        }
    }
    public class Singlenton<T>
    {
        private readonly static object lockObj = new object();
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObj)
                    {
                        if (_instance == null)
                        {
                            _instance = (T)System.Activator.CreateInstance(typeof(T));
                        }
                    }
                }
                return _instance;
            }
        }
        protected Singlenton()
        {
            Initialize();
        }
        public virtual void Initialize() { }
    }


    public class TestClass_A : Singlenton<TestClass_A>
    {
        public void Method()
        {
            Console.WriteLine($"{this.GetType()}--TestClass_A");
        }
    }
}
