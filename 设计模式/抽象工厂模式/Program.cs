using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 抽象工厂模式;

namespace 抽象工厂模式
{
    public abstract class AbstractFactory
    {
        public abstract YaBo CreateYaBo();
        public abstract YaJia CreateYaJia();
    }
    public abstract class YaBo
    {
        public abstract void Print();
    }
    public abstract class YaJia
    {
        public abstract void Print();
    }

    public class NanChangFactory : AbstractFactory
    {
        public override YaBo CreateYaBo()
        {
            return new NanChangYaBo();
        }
        public override YaJia CreateYaJia()
        {
            return new NanChangYaJia();
        }
    }
    public class NanChangYaJia : YaJia
    {
        public override void Print()
        {
            Console.WriteLine("南昌的鸭架子");
        }
    }
    public class NanChangYaBo : YaBo
    {
        public override void Print()
        {
            Console.WriteLine("南昌的鸭脖");
        }
    }

    public class ShangHaiFactory : AbstractFactory
    {
        public override YaBo CreateYaBo()
        {
            return new ShangHaiYaBo();
        }
        public override YaJia CreateYaJia()
        {
            return new ShangHaiYaJia();
        }
    }
    public class ShangHaiYaBo : YaBo
    {
        public override void Print()
        {
            Console.WriteLine("上海的鸭脖");
        }
    }
    public class ShangHaiYaJia : YaJia
    {
        public override void Print()
        {
            Console.WriteLine("上海的鸭架子");
        }
    }

    public class HuNanFactory : AbstractFactory
    {
        public override YaBo CreateYaBo()
        {
            return new HuNanYaBo();
        }

        public override YaJia CreateYaJia()
        {
            return new HuNanYaJia();
        }
    }
    public class HuNanYaBo : YaBo
    {
        public override void Print()
        {
            Console.WriteLine("湖南的鸭脖");
        }
    }
    public class HuNanYaJia : YaJia
    {
        public override void Print()
        {
            Console.WriteLine("湖南的鸭架子");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AbstractFactory nanChangFactory = new NanChangFactory();
            YaBo nanChangYabo = nanChangFactory.CreateYaBo();
            nanChangYabo.Print();
            YaJia nanChangYajia = nanChangFactory.CreateYaJia();
            nanChangYajia.Print();

            AbstractFactory shangHaiFactory = new ShangHaiFactory();
            shangHaiFactory.CreateYaBo().Print();
            shangHaiFactory.CreateYaJia().Print();

            AbstractFactory HuNanFactory = new HuNanFactory();
            HuNanFactory.CreateYaBo().Print();
            HuNanFactory.CreateYaJia().Print();
        }
    }
}
