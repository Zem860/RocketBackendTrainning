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

            //

            //2-1.寫一程式，輸入x和y，如果x>=y，則列印x，否則列印y
            //int x, y;
            //try {
            //    Console.WriteLine("請輸入x:");
            //    x = Convert.ToInt32(Console.ReadLine());
            //    Console.Write("請輸入y:");
            //    y = Convert.ToInt32(Console.ReadLine());
            //    if (x >= y)
            //    {
            //        Console.WriteLine($"x是{x}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"y是{y}");
            //    }
            //}
            //catch (FormatException) {
            //    Console.WriteLine("請輸入整數");
            //}

            //2-2.寫一程式，輸入x和y，如果x和y都是正數，令z=1，如兩者均為負數，令z=-1，否則令z=0
            //double x, y;
            //int z;
            //try {
            //Console.Write("請輸入x:");
            //x = Convert.ToDouble(Console.ReadLine());
            //Console.Write("請輸入y:");
            //y = Convert.ToDouble(Console.ReadLine());
            //if (x>=0 && y >= 0)
            //{
            //    z = 1;
            //} else if(x<0 && y < 0)
            //{
            //    z = -1;
            //} else
            //{
            //    z = 0;
            //}

            //Console.WriteLine($"x:{x} y:{y} z:{z}");
            //}
            //catch (FormatException)
            //{
            //    Console.WriteLine("請輸入x和y他們是數字");
            //}
            //2-3.寫一程式，輸入x、y、u、v，如果(x+y)>(u+v)，則令z=x+y，否則令z=u+v
            //int x, y, u, v, z;
            //try
            //{
            //    Console.Write("請輸入x:");
            //    x = Convert.ToInt32(Console.ReadLine());
            //    Console.Write("請輸入y:");
            //    y = Convert.ToInt32(Console.ReadLine());
            //    Console.Write("請輸入u:");
            //    u = Convert.ToInt32(Console.ReadLine());
            //    Console.Write("請輸入v:");
            //    v = Convert.ToInt32(Console.ReadLine());

            //    if ((x + y) > (u + v))
            //    {
            //        z = x + y;
            //    } else
            //    {
            //        z = u +v;
            //    }

            //    Console.WriteLine(z);
            //}
            //catch (FormatException) {

            //    Console.WriteLine("請輸入整數");
            //}

            //2-4.寫一程式，輸入x、y、u、v，如果((𝑥+𝑦))/((𝑢+𝑣))>=2，令z=x+y，否則令z=u+v。
            //double x, y, u, v,z;
            //try {
            //Console.Write("輸入x:");
            //x = Convert.ToDouble(Console.ReadLine());
            //Console.Write("輸入y:");
            //y = Convert.ToDouble(Console.ReadLine());
            //Console.Write("輸入u:");
            //u = Convert.ToDouble(Console.ReadLine());
            //Console.Write("輸入v:");
            //v = Convert.ToDouble(Console.ReadLine());

            //    Console.WriteLine((x + y) / (u + v));
            //if (((x + y) / (u + v)) >= 2)
            //{
            //    z = x + y;
            //} else
            //{
            //    z = u + v;
            //}
            //Console.WriteLine(z);
            //}
            //catch (FormatException)
            //{
            //    Console.WriteLine("請輸入數字");
            //}

            //2-5.寫一程式，輸入x和y，如果x>=y，令z=x2，否則令z=y2
            //int x, y, z;
            //try {
            //    Console.Write("請輸入x:");
            //    x = Convert.ToInt32(Console.ReadLine());
            //    Console.Write("請輸入y:");
            //    y = Convert.ToInt32(Console.ReadLine());
            //    if (x >= y)
            //    {
            //        z = x * 2;

            //    }
            //    else {
            //        z = y * 2;
            //    }

            //    Console.WriteLine($"z:{z}");
            //} catch (FormatException) {
            //    Console.WriteLine("請輸入整數");
            //}

            //2-6

            //int income;
            //double  tax, difference, rate;
            //Console.Write("請輸入收入計算所得稅:");
            //income = Convert.ToInt32(Console.ReadLine());
            //switch (income)
            //{
            //    case  int result when income > 4090000:
            //        rate = 0.4;
            //        difference = 721100;
            //        tax = (result * rate) - difference;
            //        Console.WriteLine(1);
            //        Console.WriteLine(tax);
            //        break;
            //    case int result when income > 2180000:
            //        rate = 0.3;
            //        difference = 312100;
            //        tax = (result * rate) - difference;
            //        Console.WriteLine(2);
            //        Console.WriteLine(tax);
            //        break;
            //    case int result when income > 1090000:
            //        rate = 0.21;
            //        difference = 115900;
            //        tax = (result * rate) - difference;
            //        Console.WriteLine(3);
            //        Console.WriteLine(tax);
            //        break;
            //    case int result when income > 410000:
            //        rate = 0.13;
            //        difference = 28700;
            //        tax = (result * rate) - difference;
            //        Console.WriteLine(4);
            //        Console.WriteLine(tax);
            //        break;
            //    case int result when income < 410000:
            //        rate = 0.06;
            //        difference = 0;
            //        tax = (result * rate) - difference;
            //        Console.WriteLine(5);
            //        Console.WriteLine(tax);
            //        break;
            //}

            //2-7象限
            //double x, y;
            //Console.Write("請輸入x座標");
            //x = Convert.ToDouble(Console.ReadLine());
            //Console.Write("請輸入y座標");
            //y = Convert.ToDouble(Console.ReadLine());

            //if (x >0 )
            //{
            //   if (y > 0)
            //    {
            //        Console.WriteLine("1st quadrian");
            //    } else if (y == 0)
            //    {
            //        Console.WriteLine("x axis");
            //    }else
            //    {
            //        Console.WriteLine("4th quadrian");
            //    }
            //} else if (x == 0)
            //{
            //    if (y == 0)
            //    {
            //        Console.WriteLine("Origin");
            //    } else
            //    {
            //        Console.WriteLine("y axis");
            //    }
            //}
            //else
            //{
            //    if (y > 0)
            //    {
            //        Console.WriteLine("2nd Quadrian");
            //    } else if (y == 0)
            //    {
            //        Console.WriteLine("X axis");
            //    } else
            //    {
            //        Console.WriteLine("3rd Quadrian");
            //    }
            //}

            //2-8 score
            //int scoreNum,score =0;
            //scoreNum = Convert.ToInt32(Console.ReadLine());
            //if (scoreNum <= 10)
            //{
            //    score = scoreNum * 6;
            //} else if (scoreNum <= 20)
            //{
            //    score = (scoreNum - 10) * 2 + 10 * 6;
            //}else if (scoreNum <= 40)
            //{
            //    score = (10 * 6) + (10 * 2) + (scoreNum - 20);
            //} else
            //{
            //    score = 100;
            //}

            //Console.WriteLine(score);

            //2.請輸入身高體重，輸出BMI並顯示這樣的BMI是正常還是過輕、過重。
            //18.5 24.9
            //double weight, height, BMI;
            //Console.Write("請輸入身高:");
            //height = Convert.ToDouble(Console.ReadLine());
            //Console.Write("請輸入體重:");
            //weight = Convert.ToDouble(Console.ReadLine());
            //double convertedHeight = height / 100;
            //BMI = Math.Round(weight / Math.Pow(convertedHeight, 2),2);
            //if (BMI < 18.5)
            //{
            //    Console.WriteLine("過輕");
            //}else if (BMI > 24.9)
            //{
            //    Console.WriteLine("過重");
            //}
            //else
            //{
            //    Console.WriteLine("正常");
            //}

            //3.請隨意輸入三個數，請由大到小依序印出。
            //int x, y, z,temp;
            //Console.Write("x:");
            //x = Convert.ToInt32(Console.ReadLine());
            //Console.Write("y:");
            //y = Convert.ToInt32(Console.ReadLine());
            //Console.Write("z:");
            //z = Convert.ToInt32(Console.ReadLine());
            //int[] numbers = { x, y, z };

            //for (int i = 0; i <numbers.Length; i++)
            //{
            //    for (int j = 0; j < numbers.Length -1; j++)
            //    {
            //        if (numbers[j + 1] < numbers[j])
            //        {
            //            temp = numbers[j + 1];
            //            numbers[j+1] = numbers[j];
            //            numbers[j] = temp;
            //        }
            //    }
            //}

            //foreach(int i in numbers)
            //{
            //    Console.Write($"{i} ");
            //}


            //補充習題四
            double profit, bonus=0;
            double initNum = 1000;

            profit = Convert.ToInt32(Console.ReadLine());
            double[] limits = { 100000, 200000, 400000, 600000, 1000000 };
            double[] rates = { 0.1, 0.075, 0.05, 0.03, 0.015, 0.01 };

            for (int limi = 0; limi <(limits.Length - 1); limi++)
            {
                if (profit >= limits[limi])
                {
                    double temp = profit - limits[limi];

                } else
                {
                    break;
                }
            }
           
            Console.WriteLine($"bonus是{bonus}");
            

            Console.ReadKey();


            MultiplicationTable2();

        }

     
        static void MultiplicationTable2()
        {
           
        }

        static void M(int n)
        {

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
