using System;

namespace 代理模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Friend();
            person.BuyProduct();
        }
    }

    public abstract class Person
    {
        public abstract void BuyProduct();
    }

    public class RealBuyPerson : Person
    {
        public override void BuyProduct()
        {
            Console.WriteLine("帮我买一个IPhone和一台苹果电脑");
        }
    }

    public class Friend : Person
    {
        private RealBuyPerson _realBuyPerson;
        public override void BuyProduct()
        {
            Console.WriteLine("通过代理类访问真实实体对象的方法");
            if (_realBuyPerson == null)
            {
                _realBuyPerson = new RealBuyPerson();
            }
            this.PreBuyProduct();
            _realBuyPerson.BuyProduct();
            this.PostBuyProduct();
        }

        public void PreBuyProduct()
        {
            Console.WriteLine("我怕弄糊涂了，需要列一张清单，张三：要带相机，李四：要带Iphone...........");
        }

        public void PostBuyProduct()
        {
            Console.WriteLine("终于买完了，现在要对东西分一下，相机是张三的；Iphone是李四的..........");
        }
    }
}
