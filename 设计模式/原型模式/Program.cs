using System;

namespace 原型模式
{
    class Program
    {
        static void Main(string[] args)
        {
            OriginClass originClass = new Variant("Origin!");

            OriginClass originClone_1 = originClass.Clone() as Variant;
            Console.WriteLine($"Clone_1:\t{originClone_1.Id}");

            OriginClass originClone_2 = originClass.Clone() as Variant;
            Console.WriteLine($"Clone_2:\t{originClone_2.Id}");

            originClass.Id = $"Clone Variant!";
            originClass = new Variant("Variant!");

            Console.WriteLine($"Origin: \t{originClass.Id}");
            Console.WriteLine($"Clone_1:\t{originClone_1.Id}");
            Console.WriteLine($"Clone_2:\t{originClone_2.Id}");
        }
    }

    public abstract class OriginClass
    {
        private string _id = string.Empty;
        public string Id { get ; set ; }
        public OriginClass(string id)
        {
            this._id = id;
        }
        public abstract OriginClass Clone();
    }
    public class Variant : OriginClass
    {
        public Variant(string id) : base(id) { }

        /// <summary>
        /// 浅拷贝
        /// 浅拷贝是指当对象的字段值被拷贝时，字段引用的对象不会被拷贝
        /// </summary>
        /// <returns></returns>
        public override OriginClass Clone()
        {
            return (Variant)this.MemberwiseClone();
        }
    }

}
