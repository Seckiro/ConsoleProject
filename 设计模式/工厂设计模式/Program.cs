using System;

namespace 工厂设计模式
{
    public abstract class Food
    {
        public abstract void Print();
    }
    public abstract class Creator
    {
        public abstract Food CreateFoddFactory();
    }

    public class MincedMeatEggplant : Food
    {
        public override void Print()
        {
            Console.WriteLine("肉末茄子好了");
        }
    }
    public class MincedMeatEggplantFactory : Creator
    {
        public override Food CreateFoddFactory()
        {
            return new MincedMeatEggplant();
        }
    }
    public class TomatoScrambledEggs : Food
    {
        public override void Print()
        {
            Console.WriteLine("西红柿炒蛋好了！");
        }
    }
    public class TomatoScrambledEggsFactory : Creator
    {
        public override Food CreateFoddFactory()
        {
            return new TomatoScrambledEggs();
        }
    }
    public class ShreddedPorkWithPotatoes : Food
    {
        public override void Print()
        {
            Console.WriteLine("土豆肉丝好了");
        }
    }


    public class ShreddedPorkWithPotatoesFactory : Creator
    {
        public override Food CreateFoddFactory()
        {
            return new ShreddedPorkWithPotatoes();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Creator shreddedPorkWithPotatoesFactory = new ShreddedPorkWithPotatoesFactory();
            Creator tomatoScrambledEggsFactory = new TomatoScrambledEggsFactory();
            Creator mincedMeatEggplantFactory = new MincedMeatEggplantFactory();

            Food tomatoScrambleEggs = tomatoScrambledEggsFactory.CreateFoddFactory();
            tomatoScrambleEggs.Print();

            Food shreddedPorkWithPotatoes = shreddedPorkWithPotatoesFactory.CreateFoddFactory();
            shreddedPorkWithPotatoes.Print();

            Food mincedMeatEggplant = mincedMeatEggplantFactory.CreateFoddFactory();
            mincedMeatEggplant.Print();
        }
    }
}
