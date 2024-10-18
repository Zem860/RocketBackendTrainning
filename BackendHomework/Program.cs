using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackendHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //4-1利用while寫一程式求N個數字的最大值。
            //Console.Write("輸入範圍:");
            //int range = Convert.ToInt32(Console.ReadLine());
            //int i = 0;
            //int maxNum = int.MinValue;
            //while (i < range)
            //{
            //    Console.Write($"數字{i+1}為:");
            //    int num = Convert.ToInt32(Console.ReadLine());
            //    if (num > maxNum)
            //    {
            //        maxNum = num;
            //    }
            //    i++;
            //}
            //Console.WriteLine($"最大的數字為{maxNum}");

            //4-2 求等差級數數字的和
            //int startValue, n, difference, count = 0, sum = 0;
            //Console.Write("請輸入理想範圍: ");
            //n = Convert.ToInt32(Console.ReadLine());
            //Console.Write("請輸入起始值: ");
            //startValue = Convert.ToInt32(Console.ReadLine());
            //Console.Write("請輸入公差:");
            //difference = Convert.ToInt32(Console.ReadLine());
            //while (count < n)
            //{
            //    sum += startValue;
            //    startValue += difference;
            //    count++;
            //}

            //Console.Write($"等差級數數字的和{sum}");
            //4-3  利用while寫一程式，讀入N個數字，然後找出所有小於13的數，再求這些數字的和。

            Console.Write("請輸入N個數字:");
            int n = Convert.ToInt32(Console.ReadLine());

            int temp = 0;
            
            while (n > 0)
            {
                Console.WriteLine("請輸入隨機數字:");
                int rndNum = Convert.ToInt32(Console.ReadLine());
                if (rndNum < 13)
                {
                    temp += rndNum;
                }

                n--;
            }
            Console.WriteLine($"所有小於13的數字的和{temp}");
            Console.ReadKey();
        }
    }
}
