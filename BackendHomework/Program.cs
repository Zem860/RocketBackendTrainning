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

            //3-1寫一程式，輸入10個整數，求其最小值。
            //Console.WriteLine("輸入10個整數，求其最小值");
            //int minNum = int.MaxValue;
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.Write($"請輸入第{i + 1}數字:");
            //    int num = Convert.ToInt32(Console.ReadLine());
            //    if (num < minNum)
            //    {
            //        minNum = num;
            //    }

            //}
            //Console.WriteLine(minNum);
            //--------------------------------------------------------
            //3-1 while
            //Console.WriteLine("輸入10個整數，求其最小值");
            //int minNum = int.MaxValue;
            //int i = 0;
            //while(i < 10)
            //{

            //    Console.Write($"請輸入第{i + 1}數字:");
            //    int num = Convert.ToInt32(Console.ReadLine());
            //    if (num < minNum)
            //    {
            //        minNum = num;
            //    }
            //    i++;

            //}

            //Console.WriteLine(minNum);
            //------------------------------------------------------------
            //3-2 寫一程式，輸入N個整數，求其最小值。
            //Console.Write("自訂比較範圍，比較多少數字:");
            //int len = Convert.ToInt32(Console.ReadLine());
            //int minNum = int.MaxValue;
            //Console.WriteLine($"求{len}個數字中的最小值");
            //for (int i = 0; i <len; i++)
            //{
            //    Console.Write($"請輸入第{i + 1}數字:");
            //    int num = Convert.ToInt32(Console.ReadLine());
            //    if (num < minNum)
            //    {
            //        minNum = num;
            //    }

            //}
            //Console.WriteLine($"最小值是{minNum}");

            //3-2 while
            //Console.Write("自訂比較範圍，比較多少數字:");
            //int len = Convert.ToInt32(Console.ReadLine());
            //int minNum = int.MaxValue;
            //Console.WriteLine($"求{len}個數字中的最小值");
            //int i = 0;
            //while ( i < len){
            //    Console.Write($"請輸入第{i + 1}數字:");
            //    int num = Convert.ToInt32(Console.ReadLine());
            //    if (num < minNum)
            //    {
            //        minNum = num;
            //    }
            //    i++;
            //}
            //Console.WriteLine($"最小值是{minNum}");

            //-------------------------------------------------------------

            //3-3 寫一程式，輸入10個整數，列出其中所有大於12的數字。

            //Console.WriteLine("輸入10個整數，列出其中所有大於12的數字");
            //string moreThanTwelve = "";
            //for (int i = 0; i < 10; i++)
            //{
            //    int num = Convert.ToInt32(Console.ReadLine());
            //    if (num > 12)
            //    {
            //        moreThanTwelve += num + " ";
            //    }

            //    Console.WriteLine("後面這些數字大於12:" + moreThanTwelve);

            //}
            //----------------------------------------------------------------

            //3 - 3 while

            //Console.WriteLine("輸入10個整數，列出其中所有大於12的數字");
            //string moreThanTwelve = "";
            //int i = 0;
            //while (i < 10)
            //{

            //    int num = Convert.ToInt32(Console.ReadLine());
            //    if (num > 12)
            //    {
            //        moreThanTwelve += num + " ";
            //    }

            //    Console.WriteLine("後面這些數字大於12:" + moreThanTwelve);

            //    i++;
            //}

            //-------------------------------------------------------------------

            //3-4 寫一程式，輸入10個整數，列出其中所有大於12的數字的總和。
            //Console.WriteLine("輸入10個整數，列出其中所有大於12的數字的總和");
            //int moreThanTwelve = 0;
            //for (int i = 0; i < 10; i++)
            //{
            //    int num = Convert.ToInt32(Console.ReadLine());
            //    if (num > 12)
            //    {
            //        moreThanTwelve += num ;
            //    }

            //}
            //Console.WriteLine("大於12的數字總合為:" + moreThanTwelve);

            //-------------------------------------------------------------

            //Console.WriteLine("輸入10個整數，列出其中所有大於12的數字的總和");
            //int moreThanTwelve = 0;

            //int i = 0;

            //while (i < 10) {

            //    int num = Convert.ToInt32(Console.ReadLine());
            //    if (num > 12)
            //    {
            //        moreThanTwelve += num;
            //    }

            //    i++;
            //}

            //Console.WriteLine("大於12的數字總合為:" + moreThanTwelve);
            //---------------------------------------------------------------
            //3-5.寫一程式，輸入N個數字，求其所有奇數中的最大值。例如輸入11,12,3,24,15，答案是15。
            //Console.Write("自訂範圍，要比較奇數中的最大值:");
            //int len = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine($"請輸入{len}個數字:");
            //int maxNum = int.MinValue;
            //for (int i = 0; i < len; i++) 
            //{
            //    Console.Write($"數字{i+1}: ");
            //    int num = Convert.ToInt32(Console.ReadLine());
            //    bool isOddNum = num % 2 == 1;
            //    if (isOddNum)
            //    {
            //        if (num > maxNum)
            //        {
            //            maxNum = num;
            //        }
            //    }

            //}
            //Console.WriteLine($"奇數中的最大值為{maxNum}");
            //------------------------------------------------------
            // 3-5while
            //Console.Write("自訂範圍，要比較奇數中的最大值:");
            //int len = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine($"請輸入{len}個數字:");
            //int maxNum = int.MinValue;

            //int i = 0;
            //while (i < len) {
            //    Console.Write($"數字{i + 1}: ");
            //    int num = Convert.ToInt32(Console.ReadLine());
            //    bool isOddNum = num % 2 == 1;
            //    if (isOddNum)
            //    {
            //        if (num > maxNum)
            //        {
            //            maxNum = num;
            //        }
            //    }

            //    i++;
            //}
            //Console.WriteLine($"奇數中的最大值為{maxNum}");

            //-----------------------------------------------------------
            //3-6 寫一程式，輸入N個數字，求其所有正數之平方的加總。
            //Console.Write("自訂範圍，求其所有正數之平方的加總:");
            //int range = Convert.ToInt32(Console.ReadLine());
            //double result = 0;
            //for (int i =0; i < range; i++)
            //{
            //    Console.Write($"請輸入第{i+1}個數字: ");
            //    double num = Convert.ToDouble(Console.ReadLine());
            //    if (num > 0)
            //    {
            //        result += Math.Pow(num,2);
            //    }

            //    Console.WriteLine(result);

            //}
            //------------------------------------------------------------
            //3-6 while
            //Console.Write("自訂範圍，求其所有正數之平方的加總:");
            //int range = Convert.ToInt32(Console.ReadLine());
            //double result = 0;
            //int i = 0;

            //while (i < range)
            //{
            //    Console.Write($"請輸入第{i + 1}個數字: ");
            //    double num = Convert.ToDouble(Console.ReadLine());
            //    if (num > 0)
            //    {
            //        result += Math.Pow(num, 2);
            //    }

            //    Console.WriteLine(result);


            //    i++;
            //}

            //------------------------------------------------------
            //3-7寫一程式，輸入N個數字，其中有些是負數，將這些負數轉換成正數，例如-7會被轉換成7。
            //Console.Write("自訂範圍，將負數轉換成正數:");
            //int range = Convert.ToInt32(Console.ReadLine());
            //string result = "";
            //for (int i = 0; i < range; i++) 
            //{
            //    Console.Write($"第{i + 1}個數字為:" );
            //    int num = Convert.ToInt32( Console.ReadLine() );
            //    if (num < 0)
            //    {
            //        num = num*-1;
            //    }
            //    result += num + " ";
            //}
            //Console.Write(result);

            //3-7改成while
            //Console.Write("自訂範圍，將負數轉換成正數:");
            //int range = Convert.ToInt32(Console.ReadLine());
            //string result = "";
            //int i = 0;
            //while (i < range)
            //{
            //    Console.Write($"第{i + 1}個數字為:");
            //    int num = Convert.ToInt32(Console.ReadLine());
            //    if (num < 0)
            //    {
            //        num = num * -1;
            //    }
            //    result += num + " ";
            //    i++;
            //}
            //Console.Write(result);
            //--------------------------------------------------------------------------------
            //補充習題


            //string primeNum ="";
            //bool isPrime = true;
            //for (int i = 101; i <= 200; i++)
            //{

            //    for (int j = 2; j < i; j++)
            //    {
            //        if (i % j == 0)
            //        {
            //            isPrime = false;
            //            break;
            //        }
            //    }

            //    if (isPrime)
            //    {
            //        primeNum += i + " ";
            //    }
            //    isPrime = true;
            //}
            //Console.WriteLine(primeNum);


            //---------------------------------------------------
            //質數while

            //int i = 101;
            //string primeNum = "";
            //bool isPrime = true;
            //while(i <=200)
            //{
            //    int j = 2;
            //    while (j < i)
            //    {
            //        if (i % j == 0)
            //        {
            //            isPrime = false;
            //            break;
            //        }

            //        j++;
            //    }

            //    if (isPrime)
            //    {
            //        primeNum += i + " ";
            //    }
            //    isPrime = true;

            //    i++;
            //}

            //Console.WriteLine(primeNum);

            //-----------------------------------------------------------------

            //輸入一個數，輸出其質因數
            //Console.Write("隨便輸入一個數字，我會找出質因數: ");
            //int num = Convert.ToInt32(Console.ReadLine());
            //string primeFactors = "";
            //for (int i = 2; i < num; i++) { 
            //    if (num %i == 0) 
            //    {
            //        primeFactors += i+" ";

            //    }
            //}    

            //Console.WriteLine(primeFactors);
            //------------------------------------------------------------
            //質因數while
            //Console.Write("隨便輸入一個數字，我會找出質因數: ");
            //int num = Convert.ToInt32(Console.ReadLine());
            //string primeFactors = "";
            //int i = 2;
            //while (i < num)
            //{
            //    if (num % i == 0)
            //    {
            //        primeFactors += i + " ";

            //    }
            //    i++;
            //} 

            //Console.WriteLine(primeFactors);
            //--------------------------------------------------------------

            //求100到300中可以被3與7整除的個數。

            //string target = "";

            //for (int i = 100; i <= 300; i++)
            //{
            //    if (i%3 == 0 && i % 7 == 0) 
            //    {
            //        target += i + " ";
            //    }
            //}

            //Console.WriteLine(target);
            //----------------------------------------
            //求100到300中可以被3與7整除的個數while
            //string target = "";
            //int i = 100;
            //while (i <= 300)
            //{
            //    if (i % 3 == 0 && i % 7 == 0)
            //    {
            //        target += i + " ";
            //    }
            //    i++;
            //}

            //Console.WriteLine(target);
            //Console.ReadKey();
        }
    }
}
