using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入您需要的图形(square,circle,rectangle,triangle)：");
            string input=Console.ReadLine();
            switch (input) {
                case "square":
                    Console.WriteLine("请输入边长：");
                    double side;
                    if (double.TryParse(Console.ReadLine(), out side))
                    {
                        Square square = new Square(side);
                        Console.WriteLine("边长为" + side + "的正方形面积为：" + square.Area);
                    }
                    else {
                        Console.WriteLine("输入边长格式有误");
                    }
                    break;
                case "circle":
                    Console.WriteLine("请输入半径：");
                    double radius;
                    if (double.TryParse(Console.ReadLine(), out radius))
                    {
                        Circle circle = new Circle(radius);
                        Console.WriteLine("半径为" +radius + "的圆形面积为：" + circle.Area);
                    }
                    else
                    {
                        Console.WriteLine("输入边长格式有误");
                    }
                    break;
                case "rectangle":
                    Console.WriteLine("请输入长：");
                  
                    double length,width;
                    if (!double.TryParse(Console.ReadLine(), out length)) {
                        Console.WriteLine("长的格式输入有错");
                        break;
                    }
                    Console.WriteLine("请输入宽：");
                    if (double.TryParse(Console.ReadLine(), out width))
                    {
                        Rectangle rectangle = new Rectangle(length, width);
                        Console.WriteLine("长为"+length+"，宽为"+width+"的长方形面积为：" + rectangle.Area);
                    }
                    else
                    {
                        Console.WriteLine("输入边长格式有误");
                    }
                    break;
                case "triangle":

                    Console.WriteLine("请输入一个边长：");

                    double _side, height;
                    if (!double.TryParse(Console.ReadLine(), out _side))
                    {
                        Console.WriteLine("边长的格式输入有错");
                        break;
                    }
                    Console.WriteLine("请输入高：");
                    if (double.TryParse(Console.ReadLine(), out height))
                    {
                        Triangle triangle = new Triangle(_side, height);
                        Console.WriteLine("边长为" + _side + "，高为" + height + "的三角形面积为：" + triangle.Area);
                    }
                    else
                    {
                        Console.WriteLine("输入边长格式有误");
                    }
                    break;
                default:
                    Console.WriteLine("输入的图形格式错误或不存在");
                    break;

            }  
        }
    }
}
