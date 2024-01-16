using System;

namespace 装饰者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBase phone = new ApplePhone();

            Decorator decoratorSticker = new Sticker(phone);
            decoratorSticker.Print();
            Console.WriteLine("----------------------");

            Decorator decoratorAccessories = new Accessories(phone);
            decoratorAccessories.Print();
            Console.WriteLine("----------------------");

            Sticker sticker = new Sticker(phone);
            Accessories accessories = new Accessories(sticker);
            accessories.Print();
        }
    }

    public abstract class PhoneBase
    {
        public abstract void Print();
    }

    public class ApplePhone : PhoneBase
    {
        public override void Print()
        {
            Console.WriteLine($"执行对象{this.GetType().Name}");
        }
    }

    public abstract class Decorator : PhoneBase
    {
        private PhoneBase _phone;
        public Decorator(PhoneBase phone)
        {
            this._phone = phone;
        }

        public override void Print()
        {
            if (_phone != null)
            {
                _phone.Print();
            }
        }
    }
    public class Sticker : Decorator
    {
        public Sticker(PhoneBase phone) : base(phone) { }

        public override void Print()
        {
            base.Print();
            AddSticker();
        }

        public void AddSticker()
        {
            Console.WriteLine("现在苹果手机有贴膜了");
        }
    }

    public class Accessories : Decorator
    {
        public Accessories(PhoneBase phone) : base(phone) { }

        public override void Print()
        {
            base.Print();
            AddAccessories();
        }

        public void AddAccessories()
        {
            Console.WriteLine("现在苹果手机有漂亮的挂件了");
        }
    }
}
