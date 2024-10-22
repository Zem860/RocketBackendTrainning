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
            //Console.Write("請輸入N個數字:");
            //int n = Convert.ToInt32(Console.ReadLine());
            //int temp = 0;
            //while (n > 0)
            //{
            //    Console.WriteLine("請輸入隨機數字:");
            //    int rndNum = Convert.ToInt32(Console.ReadLine());
            //    if (rndNum < 13)
            //    {
            //        temp += rndNum;
            //    }
            //    n--;
            //}
            //Console.WriteLine($"所有小於13的數字的和為{temp}");

            //4-4利用while寫一程式，讀入N個數字，找到第一個大於7而小於10的數字就停止，而且列印出這個數字。
            //int  X, N =0;
            //bool found = false;
            //while (!found) {
            //    try {
            //        Console.Write("輸入數字:");
            //        N = Convert.ToInt32(Console.ReadLine());
            //        if (N > 7 && N < 10)
            //        {
            //            found = true;
            //        }
            //    } catch (FormatException) {
            //        Console.WriteLine("請輸入正整數，目標是輸入7和10之間的數字");
            //    }
            //}
            //Console.WriteLine($"找到正確數字{N}");

            //4 - 5利用while寫一程式，讀入a1,a2,…,a5和b1,b2,…,b5。找到第一個ai > bi，即停止，並列印出ai及bi
            //照流程圖寫
            int count = 0;
            string ans = "";
            bool found = false;
            Console.WriteLine("題意要a1-a5和b1-b5的數字中找到第一個ai>bi");
            Console.Write("請輸一個範圍:");
            int i = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[i];
            int[] b = new int[i];
            while ( count < i)  //把a的範圍填滿
            {
                Console.Write($"請輸入a{count+1}:");
                int num = Convert.ToInt32(Console.ReadLine());
                a[count] = num;
                count++;    
            }
            int n = 1;
            //為了符合流程圖假設是1
            while (!found && n <= i) //輸入b之後就和a比對，如果符合題意或已超過範圍就跳出迴圈
            {
                Console.Write($"請輸入b{n}的範圍:");
                b[n-1] = Convert.ToInt32(Console.ReadLine());
                for (int x =0; x <a.Length; x++)
                {
                    if (a[x] > b[n - 1])
                    {

                        ans = $"a{x+1}:{a[x+1]}, b{n}:{b[n-1]}";
                        found = true;
                        break;
                    }
                }
                n++;
            }

            Console.WriteLine(ans);

            //補充習題1漢堡
            //Console.WriteLine("請輸入時間範圍，以分鐘為基準:");
            //int min = Convert.ToInt32(Console.ReadLine());
            //int count = 0;
            //while (min >= 5) {
            //    Console.WriteLine($"Eric吃了第{count += 1}個漢堡包");
            //    min -= 5;
            //}

            //補充習題2還錢 5,600,000
            //int yearPayment = (12*40000)+10000;
            //int totalLoan = 5600000;
            //int yearCount = 0;
            //int monthCount = 0;
            //while (totalLoan > 0)
            //{
            //    if (totalLoan - yearPayment >0)
            //    {
            //        totalLoan -= yearPayment;
            //        yearCount++;
            //    } else if (totalLoan - 40000 > 0)
            //    {
            //        totalLoan -= 40000;
            //        monthCount++;
            //    } else
            //    {
            //        totalLoan = 0;
            //        monthCount+=1;
            //        break;
            //    }
            //}
            //monthCount += yearCount * 12;
            //Console.WriteLine($"小明貸款還了{monthCount}個月");
            //補充習題3 猜數字
            //Random rnd =  new Random();
            //int high = rnd.Next(2, 10);
            //int low = rnd.Next(0, high);
            //int ans = rnd.Next(low, high);
            //bool found = false;
            //while (!found)
            //{
            //    Console.WriteLine($"請猜一個{low}到{high}之間的數字{ans}:");
            //    try {

            //        int guess = Convert.ToInt32(Console.ReadLine());
            //        if (guess == ans)
            //        {
            //            found = true;
            //        }
            //        else if (guess > high)
            //        {
            //            Console.WriteLine("請輸入範圍值");
            //        }
            //        else if (guess < low)
            //        {
            //            Console.WriteLine("請輸入範圍值");
            //        }
            //        else if (guess > ans)
            //        {
            //            Console.WriteLine("答案比你猜的數字小");
            //            high = guess;
            //        }
            //        else
            //        {
            //            Console.Write("答案比你猜的數字大");
            //            low = guess;
            //        }
            //    }
            //    catch (FormatException)
            //    {
            //        Console.WriteLine("請輸入整數");
            //    }
            //    catch (System.OverflowException)
            //    {
            //        Console.WriteLine("請輸入有效範圍值");
            //    }   
            //}
            //Console.WriteLine($"猜對了!答案是{ans}");
            Console.ReadKey();
        }
    }
}
