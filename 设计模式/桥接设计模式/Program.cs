using System;

namespace 桥接设计模式
{
    class Program
    {
        static void Main(string[] args)
        {
            ControlRemote control = new ControlRemote();

            control.Equipment = new Equipment_1();
            control.On();
            control.Off();
            control.OnDestroy();

            Console.WriteLine();

            control.Equipment = new Equipment_2();
            control.On();
            control.Off();
            control.OnDestroy();

        }
    }

    public abstract class EquipmentBase
    {
        public abstract void On();
        public abstract void Off();
        public abstract void OnDestroy();
    }

    public class Equipment_1 : EquipmentBase
    {
        public override void On()
        {
            Console.WriteLine($"{this.GetType().Name}已打开!");
        }

        public override void Off()
        {
            Console.WriteLine($"{this.GetType().Name}已关闭!");
        }

        public override void OnDestroy()
        {
            Console.WriteLine($"{this.GetType().Name}已摧毁!");
        }
    }

    public class Equipment_2 : EquipmentBase
    {
        public override void On()
        {
            Console.WriteLine($"{this.GetType().Name}已打开!");
        }

        public override void Off()
        {
            Console.WriteLine($"{this.GetType().Name}已关闭!");
        }

        public override void OnDestroy()
        {
            Console.WriteLine($"{this.GetType().Name}已摧毁!");
        }
    }


    public abstract class ControlBase
    {
        private EquipmentBase _equipment;

        public EquipmentBase Equipment
        {
            get { return _equipment; }
            set { _equipment = value; }
        }

        public virtual void On()
        {
            _equipment.On();
        }
        public virtual void Off()
        {
            _equipment.Off();
        }
        public virtual void OnDestroy()
        {
            _equipment.OnDestroy();
        }
    }

    public class ControlRemote : ControlBase
    {
        public override void OnDestroy()
        {
            Console.WriteLine("---------------------");
            base.OnDestroy();
            Console.WriteLine("---------------------");
        }
    }
}
