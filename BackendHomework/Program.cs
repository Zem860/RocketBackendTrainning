using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BackendHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //習題2-1(照上方流程圖)-------------------------------------------------
            //int x, y,z;
            //Console.WriteLine("請輸入整數: ");
            //Console.Write("x = ");
            //x = Convert.ToInt32(Console.ReadLine());
            //Console.Write("y=");
            //y = Convert.ToInt32(Console.ReadLine());
            //if (x >= y)
            //{
            //    z = x;
            //}
            //else
            //{
            //    z = y;
            //}
            //Console.WriteLine(z);
            //Console.ReadKey();
            //習題2-2-------------------------------------------------------------------
            //int x, y, z = 0;
            //Console.WriteLine("請輸入整數: ");
            //Console.Write("x = ");
            //x = Convert.ToInt32(Console.ReadLine());
            //Console.Write("y = ");
            //y = Convert.ToInt32(Console.ReadLine());
            //if ((x >= 0) && (y >= 0)) 
            //{
            //    z = 1;
            //    Console.WriteLine($"x和y均為正數 z = {z}");
            //}
            //else if ((x<0) && (y <0))
            //{
            //    z = -1;
            //    Console.WriteLine($"x和y均為負數 z = {z}");
            //}
            //else
            //{
            //    Console.WriteLine("z為" + z);
            //}
            //Console.ReadKey();
            //習題2-3-------------------------------------------------------------------
            //int x, y, u, v, z;
            //Console.WriteLine("請輸入整數: ");
            //Console.Write("x = ");
            //x = Convert.ToInt32(Console.ReadLine());
            //Console.Write("y = ");
            //y = Convert.ToInt32(Console.ReadLine());
            //Console.Write("u = ");
            //u = Convert.ToInt32(Console.ReadLine());
            //Console.Write("v = ");
            //v = Convert.ToInt32(Console.ReadLine());
            //if ((x + y) > (u + v))
            //{
            //    z = x + y;
            //}
            //else
            //{
            //    z = u + v;
            //}
            //Console.WriteLine($"z = {z}");
            //Console.ReadKey();
            //習題2-4-------------------------------------------------------------------
            //double x, y, u, v,z;
            //Console.WriteLine("請輸入數字: ");
            //Console.Write(" x= ");
            //x = Convert.ToDouble(Console.ReadLine());
            //Console.Write(" y= ");
            //y = Convert.ToDouble(Console.ReadLine());
            //Console.Write(" u= ");
            //u = Convert.ToDouble(Console.ReadLine());
            //Console.Write(" v = ");
            //v = Convert.ToDouble(Console.ReadLine());
            //if (((x+y)/(u+v))>=2)
            //{
            //    z = x + y;
            //}
            //else
            //{
            //    z = u + v;
            //}
            //Console.WriteLine($"z = {z}");
            //Console.ReadKey();
            //習題2-5-------------------------------------------------------------------
            //double x, y, z;
            //Console.WriteLine("請輸入整數: ");
            //Console.Write("x = ");
            //x= Convert.ToDouble(Console.ReadLine());
            //Console.Write("y = ");
            //y = Convert.ToDouble(Console.ReadLine());
            //if (x >= y)
            //{
            //    z = Math.Pow(x, 2);

            //} else
            //{
            //    z = Math.Pow(y, 2);
            //}
            //Console.WriteLine($"z = {z}");
            //Console.ReadKey();
            //習題2-6-------------------------------------------------------------------
            //int income;
            //double rate, difference, tax;
            //Console.WriteLine("輸入您的薪水計算所得稅:");
            //income = Convert.ToInt32(Console.ReadLine());
            //if (income > 4090000)
            //{
            //    rate = 0.4;
            //    difference = 721100;
            //}
            //else if (income > 2180000)
            //{
            //    rate = 0.3;
            //    difference = 312100;
            //}
            //else if (income > 1090000)
            //{
            //    rate = 0.21;
            //    difference = 115900;
            //}
            //else if (income > 410000)
            //{
            //    rate = 0.13;
            //    difference = 28700;
            //}
            //else
            //{
            //    rate = 0.06;
            //    difference = 0;
            //}
            //tax = (income * rate) - difference;
            //Console.WriteLine($"稅 = {tax}");
            //Console.ReadKey();

            //習題2-7-------------------------------------------------------------------
            //int x, y;
            //Console.WriteLine("請輸入x,y:");
            //Console.Write("x = ");
            //x = Convert.ToInt32(Console.ReadLine());
            //Console.Write("y = ");
            //y = Convert.ToInt32(Console.ReadLine());
            //if (x > 0)
            //{
            //    if (y > 0)
            //    {
            //        Console.WriteLine("1st quadrant.");
            //    }
            //    else if (y == 0)
            //    {
            //        Console.WriteLine("X-axis");
            //    }
            //    else
            //    {
            //        Console.WriteLine("4th quadrant.");
            //    }
            //}
            //else if (x == 0)
            //{
            //    if (y == 0)
            //    {
            //        Console.WriteLine("origin");
            //    } else
            //    {
            //        Console.WriteLine("Y-axis");
            //    }
            //}
            //else
            //{
            //    if (y > 0) 
            //    {
            //        Console.WriteLine("2nd quadrant");
            //    } else if (y == 0)
            //    {
            //        Console.WriteLine("X-axis");
            //    }
            //    else
            //    {
            //        Console.WriteLine("3rd quadrant");
            //    }
            //}
            //Console.ReadKey();

            //補充習題 1
            //int correctAnswerCount,score = 0;
            //Console.Write("請輸入答對題數:");
            //correctAnswerCount = Convert.ToInt32(Console.ReadLine());
            //if (correctAnswerCount > 40)
            //{
            //    score = 100;
            //}  
            //else if (correctAnswerCount <= 10)
            //{
            //    score = correctAnswerCount * 6;
            //} else if (correctAnswerCount>10 && correctAnswerCount <= 20)
            //{
            //    int elevenTotwenty = correctAnswerCount - 10;
            //    score = (elevenTotwenty * 2) + 60;
            //}
            //else if (correctAnswerCount > 20 && correctAnswerCount <= 40)
            //{
            //    int twentyOneToForty = correctAnswerCount - 20;
            //    score = (twentyOneToForty * 1) + 80;
            //}
            //Console.WriteLine($"得分:{score}");
            //Console.ReadKey();
            //補充習題2
            //BMI 體重÷身高(公尺)的平方
            //過輕BMI < 18.5  正常18.5 ≦ BMI < 24	過重 24 ≦ BMI < 27 過重肥胖BMI ≧ 27
            //double height, weight, BMI;
            //Console.WriteLine("要計算BMI，請計算身高體重: ");
            //Console.Write("身高 = ");
            //height = Convert.ToDouble(Console.ReadLine()) / 100;
            //Console.Write("體重 = ");
            //weight = Convert.ToDouble(Console.ReadLine());
            //BMI = Math.Round(weight / Math.Pow(height, 2), 2);
            //if (BMI < 18.5)
            //{
            //    Console.WriteLine($"你的BMI是{BMI}，過輕");
            //} else if (BMI >= 18.5 && BMI < 24)
            //{
            //    Console.WriteLine($"你的BMI是{BMI}，正常");
            //} else
            //{
            //    Console.WriteLine($"你的BMI是{BMI}，過重");
            //}
            //Console.ReadKey();

            //補充習題3
            //int num1, num2, num3, max;
            //string result="";
            //Console.WriteLine("隨意輸入3個數字");
            //Console.Write("num1 = ");
            //num1 = Convert.ToInt32(Console.ReadLine());
            //Console.Write("num2 = ");
            //num2 = Convert.ToInt32(Console.ReadLine());
            //Console.Write("num3 = ");
            //num3 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine($"{num1}, {num2}, {num3}");
            //max = Math.Max(num1, Math.Max(num2, num3));
            //if ((num1 - num2) > 0)
            //{
            //    result += Convert.ToString(num1);
            //    if ((num2 - num3) > 0)
            //    {
            //        result = result +" "+ Convert.ToString(num2);
            //        result = result +" "+ Convert.ToString(num3);
            //    }
            //    else
            //    {
            //        result = result + " "+ Convert.ToString(num3);
            //        result = result + " "+ Convert.ToString(num2);
            //    }
            //}
            //else
            //{
            //    if ((num1 - num3) > 0)
            //    {
            //        result = result + Convert.ToString(num2) +" "+ Convert.ToString(num1);
            //        result = result + Convert.ToString(num3);
            //    }
            //    else
            //    {
            //        result = result + Convert.ToString(num3) + " " + Convert.ToString(num2);
            //        result = result + Convert.ToString(num1);
            //    }

            //}
            //Console.WriteLine(result);
            //Console.WriteLine();
            //Console.ReadKey();



            //補充習題4
            //double profit, bonus =0, bonusRate = 0.1;
            //profit = Convert.ToDouble(Console.ReadLine());
            //if (profit <= 100000)
            //{
            //    bonus = profit * bonusRate;
            //}
            //else if (profit<200000)
            //{
            //    bonus = 100000 * bonusRate;
            //    bonusRate = 0.075;
            //    double aboveTwoHundred = (profit - 100000)*bonusRate;
            //    bonus += aboveTwoHundred;
            //} else if (profit < 400000)
            //{
            //    bonus = 100000 * bonusRate;
            //    bonusRate = 0.075;
            //    double toTwoHundred = 100000 * bonusRate;
            //    bonus += toTwoHundred;
            //    bonusRate = 0.05;
            //    double aboveThreeHundred = (profit - 200000) *bonusRate;
            //    bonus += aboveThreeHundred;
            //} else if (profit < 600000)
            //{
            //    bonus = 100000 * bonusRate;
            //    bonusRate = 0.075;
            //    double toTwoHundred = 100000 * bonusRate;
            //    bonus += toTwoHundred;
            //    bonusRate = 0.05;
            //    double toThreeHundred = 200000 * bonusRate;
            //    bonus += toThreeHundred;
            //    bonusRate = 0.03;
            //    double aboveFourHundred = (profit - 400000) * bonusRate;
            //    bonus += aboveFourHundred;

            //} else if (profit < 1000000)
            //{
            //    bonus = 100000 * bonusRate;
            //    bonusRate = 0.075;
            //    double toTwoHundred = 100000 * bonusRate;
            //    bonus += toTwoHundred;
            //    bonusRate = 0.05;
            //    double toThreeHundred = 200000 * bonusRate;
            //    bonus += toThreeHundred;
            //    bonusRate = 0.03;
            //    double toFourHundred = 200000 * bonusRate;
            //    bonus += toFourHundred;
            //    bonusRate = 0.015;
            //    double aboveSixHundred = (profit - 600000) * bonusRate;
            //    bonus += aboveSixHundred;
            //} else
            //{
            //    bonus = 100000 * bonusRate;
            //    bonusRate = 0.075;
            //    double toTwoHundred = 100000 * bonusRate;
            //    bonus += toTwoHundred;
            //    bonusRate = 0.05;
            //    double toThreeHundred = 200000 * bonusRate;
            //    bonus += toThreeHundred;
            //    bonusRate = 0.03;
            //    double toSixHundred = 200000 * bonusRate;
            //    bonus += toSixHundred;
            //    bonusRate = 0.015;
            //    double toOneThousand = 400000 * bonusRate;
            //    bonus += toOneThousand;
            //    bonusRate = 0.01;
            //    double aboveOneThousand = (profit - 1000000) * bonusRate;
            //    bonus += aboveOneThousand;
            //}
            //Console.WriteLine(bonus);
            //Console.ReadKey();

            //追加習題
            Console.Write("請輸入成績:");
            double score = Convert.ToDouble(Console.ReadLine());
            double result = Math.Floor(score/10);
            string grade;
            switch (result)
            {
                case 10:
                case 9:
                    grade = "A";
                    break;
                case 8:
                    grade = "B";
                    break;
                case 7:
                    grade = "C";
                    break;
                case 6:
                    grade = "D";
                    break;
                default:
                    grade = "F";
                    break;

            }

            Console.WriteLine($"分數為{grade}");

            Console.ReadKey();
        }
    }
}
