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
