using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.必考題--九九乘法表
            //MultiplicationTable();
            //輸入a,b,c,d，計算((𝑎+𝑏))/((𝑐−𝑑))×2。
            //double a, b, c, d,result;
            //Console.Write("請輸入a:");
            //a = Convert.ToDouble(Console.ReadLine());
            //Console.Write("請輸入b:");
            //b = Convert.ToDouble(Console.ReadLine());
            //Console.Write("請輸入c:");
            //c = Convert.ToDouble(Console.ReadLine());
            //Console.Write("請輸入d:");
            //d = Convert.ToDouble(Console.ReadLine());
            //result = ((a + b) / (c + d)) * 2;
            //Console.WriteLine($"結果為{result}");

            //假設有一組二元一次方程式如下：
            //double a1, b1, c1, a2, b2, c2,x,y;
            //Console.Write("請輸入a1:");
            //a1 = Convert.ToDouble(Console.ReadLine());
            //Console.Write("請輸入b1:");
            //b1 = Convert.ToDouble(Console.ReadLine());
            //Console.Write("請輸入c1:");
            //c1 = Convert.ToDouble(Console.ReadLine());
            //Console.Write("請輸入a2:");
            //a2 = Convert.ToDouble(Console.ReadLine());
            //Console.Write("請輸入b2:");
            //b2 = Convert.ToDouble(Console.ReadLine());
            //Console.Write("請輸入c2:");
            //c2 = Convert.ToDouble(Console.ReadLine());
            //x = ((c1 * b2) + (c2 * b1)) / ((a1 * b2) - (a2 * b1));
            //y = ((c1 * a2) - (c2 * a1)) / ((b1 * a2 - a1 * b2));

            //Console.Write($"x:{x},y:{y}");
            //y=  (𝑎^2+𝑏^2)/(𝑎^2−𝑏^2)
            //double a, b, result;
            //Console.Write("請輸入a:");
            //a = Convert.ToDouble(Console.ReadLine());
            //Console.Write("請輸入b:");
            //b = Convert.ToDouble(Console.ReadLine());
            //result = ((Math.Pow(a, 2) + Math.Pow(b, 2)) / (Math.Pow(a, 2) - Math.Pow(b, 2)));
            //Console.WriteLine($"計算結果為: {result}");
            //根號a平方+b平方
            //double a, b, result;
            //Console.Write("輸入a:");
            //a = Convert.ToDouble(Console.ReadLine());
            //Console.Write("輸入b:");
            //b = Convert.ToDouble(Console.ReadLine());
            //result = Math.Sqrt((Math.Pow(a, 2) + Math.Pow(b, 2)));
            //Console.Write(result);
            //輸入a、b和c，求：y = a - (b + c)(3a - c)
            //int a, b, c, result;
            //Console.Write("輸入a:");
            //a = Convert.ToInt32(Console.ReadLine());
            //Console.Write("輸入b:");
            //b = Convert.ToInt32(Console.ReadLine());
            //Console.Write("輸入c:");
            //c = Convert.ToInt32(Console.ReadLine());
            //result = a - (b + c) * (3 * a - c);
            //Console.Write(result);
            //1-6請隨意輸入正負數，取絕對值輸出
            //double target;
            //Console.Write("隨意輸入正負數，求絕對值:");
            //target =Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine(Math.Abs(target));
            ////1-7輸入的西元年份轉換成民國年份後輸出
            //Console.Write("輸入的西元年份轉換成民國年份後輸出");
            //int year = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(year-1911);
            ////請輸入身高體重，輸出BMI(體重/身高(公尺)^2)
            //double weight, height, result;
            //Console.Write("請輸入體重:");
            //weight = Convert.ToDouble(Console.ReadLine());
            //Console.Write("請輸入身高(公分):");
            //height = Convert.ToDouble(Console.ReadLine());
            //double convertedHeight = Math.Pow(height / 100,2);
            //result = Math.Round(weight / convertedHeight,2);
            //Console.Write($"BMI結果為{result}");
            Console.ReadKey(); 

        }


        static void MultiplicationTable()
        {
            //九九乘法表
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    Console.Write($"{j}x{i} = {i * j} \t");
                    Console.Write(" ");

                }
                Console.WriteLine();
            }

            Console.WriteLine();
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 4; j <= 6; j++)
                {
                    Console.Write($"{j}x{i} = {i * j} \t");
                    Console.Write(" ");

                }
                Console.WriteLine();
            }

            Console.WriteLine();
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 7; j <= 9; j++)
                {
                    Console.Write($"{j}x{i} = {i * j} \t");
                    Console.Write(" ");

                }
                Console.WriteLine();
            }
        }


    }
}
