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
            Console.Write("輸入範圍:");
            int range = Convert.ToInt32(Console.ReadLine());
            int i = 0;
            int maxNum = int.MinValue;
            while (i < range)
            {
                Console.Write($"數字{i+1}為:");
                int num = Convert.ToInt32(Console.ReadLine());
                if (num > maxNum)
                {
                    maxNum = num;
                }
                i++;
            }
            Console.WriteLine($"最大的數字為{maxNum}");
            Console.ReadKey();
        }
    }
}
