﻿using System;
using System.Collections.Generic;

namespace 组合体模式
{
    class Program
    {
        static void Main(string[] args)
        {
            ComplexGraphics complexGraphics = new ComplexGraphics("一个复杂图形和两条线段组成的复杂图形");
            complexGraphics.Add(new Line("线段A"));
            ComplexGraphics CompositeCG = new ComplexGraphics("一个圆和一条线组成的复杂图形");
            CompositeCG.Add(new Circle("圆"));
            CompositeCG.Add(new Circle("线段B"));
            complexGraphics.Add(CompositeCG);
            Line lineC = new Line("线段C");
            complexGraphics.Add(lineC);

            Console.WriteLine("---------------------");
            complexGraphics.Draw();
            Console.WriteLine("复杂图形绘制完成");
            Console.WriteLine("---------------------");
            Console.WriteLine();

            complexGraphics.Remove(lineC);
            Console.WriteLine("移除线段C后，复杂图形的绘制如下：");
            Console.WriteLine("---------------------");
            complexGraphics.Draw();
            Console.WriteLine("复杂图形绘制完成");
            Console.WriteLine("---------------------");
            Console.Read();
        }
    }

    public abstract class Graphics
    {
        public string Name { get; set; }
        public Graphics(string name)
        {
            this.Name = name;
        }

        public abstract void Draw();
    }

    public class Line : Graphics
    {
        public Line(string name) : base(name) { }

        public override void Draw()
        {
            Console.WriteLine("画  " + Name);
        }
    }

    public class Circle : Graphics
    {
        public Circle(string name) : base(name) { }

        public override void Draw()
        {
            Console.WriteLine("画  " + Name);
        }
    }

    public class ComplexGraphics : Graphics
    {
        private List<Graphics> complexGraphicsList = new List<Graphics>();
        public ComplexGraphics(string name) : base(name) { }

        public override void Draw()
        {
            foreach (Graphics g in complexGraphicsList)
            {
                g.Draw();
            }
        }

        public void Add(Graphics g)
        {
            complexGraphicsList.Add(g);
        }
        public void Remove(Graphics g)
        {
            complexGraphicsList.Remove(g);
        }

    }
}
