using System;

namespace 简单工场模式
{
    public enum MyFoodEnum
    {
        TomatoScrambledEggs = 0,
        ShreddedPorkWithPotatoes = 1,
    }
    public abstract class Food
    {
        public abstract void Print();
    }

    public class TomatoScrambledEggs : Food
    {
        public override void Print()
        {
            Console.WriteLine("一份西红柿炒蛋！");
        }
    }
    public class ShreddedPorkWithPotatoes : Food
    {
        public override void Print()
        {
            Console.WriteLine("一份土豆肉丝！");
        }
    }
    public class FoodSimpleFactory
    {
        public static Food CreateFood(MyFoodEnum foodtype)
        {
            return (Food)Activator.CreateInstance(Type.GetType($"简单工场模式.{foodtype.ToString()}"));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Food food1 = FoodSimpleFactory.CreateFood(MyFoodEnum.TomatoScrambledEggs);
            food1.Print();

            Food food2 = FoodSimpleFactory.CreateFood(MyFoodEnum.ShreddedPorkWithPotatoes);
            food2.Print();
        }
    }
}
