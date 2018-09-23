using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    public abstract class Shape
    {
        public abstract double Area
        {
            get;
        }
    }

    public class Square : Shape
    {
        private double Side;
        public Square(double Side)
        {
            this.Side = Side;
        }
        public override double Area {
            get
            {
                return Side * Side;
            }
        } 
    }

    public class Circle : Shape
    {
        private double Radius;
        public Circle(double Radius) {
            this.Radius = Radius;
        }
        public override double Area  {
            get {
                return Math.PI * Radius * Radius;
            }
        }
    }
    public class Rectangle : Shape {
        private double Length;
        private double Width;
        public Rectangle(double Length, double Width) {
            this.Length = Length;
            this.Width = Width;
        }
        public override double Area {
            get {
                return Length * Width;
            }
        }
    }
    public class Triangle : Shape {
        private double Height;
        private double Side;
        public Triangle(double Height, double Side) {
            this.Height = Height;
            this.Side = Side;
        }
        public override double Area
        {
            get
            {
                return Height*Side/2;
            }
        }
    }
}
